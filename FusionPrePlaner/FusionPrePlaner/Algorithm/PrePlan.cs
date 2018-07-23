using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FusionPrePlaner.Algorithm
{
    class PrePlan
    {
        private DataTable AvailIssues;
        private DataTable UntouchableIssues;
        private DataTable DT_FB;
        private DataTable DT_REL;
        private FeatureBuildChecker fbChecker;
        private string fb;
        
        public PrePlan(DataTable DT_AvailIssues, DataTable DT_UntouchableIssues, FeatureBuildChecker fbChecker, DataTable DT_FB, DataTable DT_REL)
        {
            this.AvailIssues = DT_AvailIssues;
            this.UntouchableIssues = DT_UntouchableIssues;
            this.DT_FB = DT_FB;
            this.DT_REL = DT_REL;
            this.fbChecker = fbChecker;
            
        }

        public void Process(string team)
        {

            fb = fbChecker.GetNextFb(fbChecker.GetCurrentFeatureBuild());
    
            List <DataRow> list = PrepareItemList(team);
            while (list.Count>0&& HasCapacityEntry(team, fb))
            {
                double frame = GetAvaliableFrame(team, fb, GetTeamCapacity(team, fb));

                List<DataRow>  extraItems = list.Where(r => IsOverloadAllowed(r, fb, team)).ToList();

                if (frame > 0 || extraItems.Count() > 0)
                    SplitIfNeededAndFillTheFrame(list, frame, team);
                else
                    fb = fbChecker.GetNextFb(fb);

            }
            /*
            for (int i = 0; i < AvailIssues.Rows.Count; i++)
            {
                Console.WriteLine(AvailIssues.Rows[i]["Target FB"].ToString());
            }
            Console.WriteLine(list.Count);
            */
        }

        private void SplitIfNeededAndFillTheFrame(List<DataRow> list, double frame, string team)
        {
            double capacity = GetTeamCapacity(team, fb);
            DataRow first = GetFirstItemOtherwiseMoveFb(list, fb);
            if (first != null)
            {
                if (CanSplitTheWork(first))
                {
                    //To be finished...
                }
                PackFb(list, team, frame, first);
            }
        }

        private List<DataRow> PrepareItemList(string team)
        {
            List<DataRow> list = AvailIssues
                .Select("STO=" + ScrumTeamOwner.DicTeamToCode[team] + "and Status = 'Open' ")
                .ToList();

            list.Sort(SortItemListByPriority);
         
            return list;
        }

        private int SortItemListByPriority(DataRow row_a,DataRow row_b)
        {
            if (row_a["Priority"].ToString() == "") return 1;
            if (row_b["Priority"].ToString() == "") return -1;
            if ((Convert.ToDouble(row_a["Priority"].ToString())> Convert.ToDouble(row_b["Priority"].ToString())))
            {
                return 1;
            }
            return -1;
        }

        private bool HasCapacityEntry(string team,string fb)
        {
            //to be finished
            return true;
        }
        private double GetTeamCapacity(String team, string fb)
        {
            string fb_column = fb;
            fb_column=fb_column.Remove(0,2).Remove(2, 1);
            return Convert.ToDouble(DT_FB.Select("fb=" + fb_column)[0][team].ToString());
        }

        private double GetAvaliableFrame(string team,string fb,double capacity)
        {
            string fb_column = fb;
            double capacity_untouchable;
            capacity_untouchable = 0;
            fb_column = fb_column.Remove(0, 2).Remove(2, 1);
            List<DataRow> list = UntouchableIssues
                .Select("[Target FB]= " + fb_column + " and STO= " + ScrumTeamOwner.DicTeamToCode[team])
                .ToList();
            foreach(DataRow row in list)
            {
                string eff = row["Rem Eff"].ToString();
                capacity_untouchable += Convert.ToDouble(eff.Remove(eff.Length-1,1));
            }
            return capacity- capacity_untouchable;
        }

        public bool IsOverloadAllowed(DataRow r, string fb, string team)
        {
            string upperBound = r["End FB"].ToString();

            if (upperBound == "") return false;

            upperBound = r["End FB"].ToString()
                .Insert(0,"fb")
                .Insert(4,".");

            return fbChecker.isValid(upperBound) && !fbChecker.isLater(upperBound, fb);
        }

        private bool AppliesToRow(DataRow r,string team)
        {
            return true;
        }

       private DataRow GetFirstItemOtherwiseMoveFb(List<DataRow> list, string team)
       {
            if (!list.Any(r => DoesItemApplyToThisFb(r, team)))
            {
                fb = fbChecker.GetNextFb(fb);
                return default(DataRow);
            }

            return list.First(r => DoesItemApplyToThisFb(r, team));
       }

        private bool DoesItemApplyToThisFb(DataRow row, string team)
        {
            return FbFitsInFeatureReleaseRange(row)&& FitsInBounds(row,fb);
        }

        private bool FbFitsInFeatureReleaseRange(DataRow row)
        {
            string release = row["Entity REL"].ToString();
            DataRow[] dr = DT_REL.Select("Release = '" + release+"'");
            
            if (dr.Count() > 0)
            {
                List<DataRow> releaseItem = dr.ToList();
                var startFb = releaseItem[0]["Start FB"].ToString();
                if (fbChecker.isValid(startFb))
                    return !fbChecker.isEarlier(fb, startFb);
            }

            return true;
        }

        private bool FitsInBounds(DataRow r, string fb)
        {
            bool isTooEarly = false;
            bool isTooLate = false;

            string lowerBound = r["Start FB"].ToString();
            string upperBound = r["End FB"].ToString();

            if(lowerBound!="")
            {   lowerBound = lowerBound
                    .Insert(0, "fb")
                    .Insert(4, ".");
                if (fbChecker.isValid(lowerBound) && fbChecker.isFromFuture(lowerBound))
                    isTooEarly = fbChecker.isEarlier(fb, lowerBound);
            }

            if (upperBound != "")
            {
                upperBound = upperBound
                    .Insert(0, "fb")
                    .Insert(4, ".");

                if (fbChecker.isValid(upperBound) && fbChecker.isFromFuture(upperBound))
                    isTooLate = fbChecker.isLater(fb, upperBound);
            }

            return !isTooEarly && !isTooLate;
        }

        private void PackFb(List<DataRow> list, string team, double frame, DataRow first)
        {
            if (FitsInTheFrame(team, frame, first) || IsOverloadAllowed(first, fb, team))
                AssignFb(list, team, first, frame);
            else
            {
                var gapFiller = list.FirstOrDefault(r => (FitsInTheFrame(team, frame, r) || IsOverloadAllowed(r, fb, team)) && DoesItemApplyToThisFb(r, team));
                if (gapFiller != null)
                    AssignFb(list, team, gapFiller, frame);
                else
                    fb = fbChecker.GetNextFb(fb);
            }
        }

        private void AssignFb(List<DataRow> list, string team, DataRow row, double frame)
        {
            
            string temp = row["Key"].ToString();
            AvailIssues.Select("[Item ID]='" + row["Item ID"].ToString()+"'")[0]["Target FB"] = fb.Remove(0, 2).Remove(2, 1);
           // Console.WriteLine("remove " + row["Item ID"].ToString() +"   "+ fb);
            list.Remove(row);
        }

        private bool FitsInTheFrame(string team, double frame, DataRow row)
        {
            return (frame - getTotalEffort(row, team, fb)) >= 0;
        }


        private double getTotalEffort(DataRow row, string team,string fb)
        {
            string eff = row["Rem Eff"].ToString();
            return Convert.ToDouble(eff.Remove(eff.Length - 1, 1));
        }

        private bool CanSplitTheWork(DataRow row)
        {
            //To be finished...
            return false;
        }
    }
}
