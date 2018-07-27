using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using NLog;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FusionPrePlaner.Algorithm;


namespace FusionPrePlaner
{
    class PrePlanner
    {

        public static Logger logger = LogManager.GetLogger("PrePlan");

        private static List<PrePlanner> _prePlannerList ;

        public static List<PrePlanner> PrePlannerList
        {
            get
            {
                if(_prePlannerList == null)
                {
                    _prePlannerList = new List<PrePlanner>();
                    foreach (var sto in ScrumTeamOwner.STO_FULL_LIST)
                    {

                        _prePlannerList.Add(new PrePlanner(sto));
                    }
                }
                
                return _prePlannerList;
            }
        }

        public static PrePlanner GetPrePlannerFromTeamCode(string code )
        {
            return  PrePlannerList.Where<PrePlanner>(planner => planner.Sto.Code == code).ToList()[0];
           
        }
            


        private ScrumTeamOwner Sto;
        private DataTable _sto_allIssues;
        public DataTable STO_AllIssues
        {
            get
            {
                if(_sto_allIssues == null)
                {
                    _sto_allIssues = new DataTable("Issues");
                    _sto_allIssues.Columns.Add(new DataColumn("Key", typeof(string)));
                    _sto_allIssues.Columns.Add(new DataColumn("Item ID", typeof(string)));
                    _sto_allIssues.Columns.Add(new DataColumn("FP", typeof(string)));                 
                    _sto_allIssues.Columns.Add(new DataColumn("Priority", typeof(string)));
                    _sto_allIssues.Columns.Add(new DataColumn("Type", typeof(string)));
                    _sto_allIssues.Columns.Add(new DataColumn("STO", typeof(string)));
                    _sto_allIssues.Columns.Add(new DataColumn("Entity REL", typeof(string)));
                    _sto_allIssues.Columns.Add(new DataColumn("Status", typeof(string)));

                    _sto_allIssues.Columns.Add(new DataColumn("Start FB", typeof(string)));
                    _sto_allIssues.Columns.Add(new DataColumn("End FB", typeof(string)));
                    _sto_allIssues.Columns.Add(new DataColumn("Target FB", typeof(string)));

                    _sto_allIssues.Columns.Add(new DataColumn("Ori Eff", typeof(string)));
                    _sto_allIssues.Columns.Add(new DataColumn("Rem Eff", typeof(string)));
                    _sto_allIssues.Columns.Add(new DataColumn("Parent", typeof(string)));
                   
                }
                return _sto_allIssues;
            }
        }


        private DataTable _dtAvai;
        private DataTable _dtUntouch;
        private DataTable _dtCA;
        public DataTable DT_AvailIssues
        {
            get
            {
                if (_dtAvai == null)
                {
                    _dtAvai = STO_AllIssues.Clone();
                    _dtAvai.Columns.Add(new DataColumn("Assigned", typeof(string)));
                    _dtAvai.Columns.Add(new DataColumn("Note", typeof(string)));
                }
                return _dtAvai;
            }
        }
        public DataTable DT_UntouchableIssues
        {
            get
            {
                if (_dtUntouch == null)
                {
                    _dtUntouch = STO_AllIssues.Clone();

                }
                return _dtUntouch;
            }
        }
        public DataTable DT_CA
        {
            get
            {
                if (_dtCA == null)
                {
                    _dtCA = STO_AllIssues.Clone();

                }
                return _dtCA;
            }
        }


        private static DataTable _dtFB;
        private static DataTable _dtRel;


        public static DataTable DT_FB
        {
            get
            {
                return _dtFB;
            }
            set
            {
                _dtFB = value;
            }
        }
        public static DataTable DT_REL
        {
            get
            {
                return _dtRel;
            }
            set
            {
                _dtRel = value;
            }
        }
       



        public static void load_fb()
        {
            DataTable dt_xls_dates = FeatureBuild.excelToDataSet("FZM FBP tool.xlsb", "Feature Build,Start Date,End Date", "Dates");                         //调用GetData方发写上Excel文件所在的路径，这样就能获取到Excel表里面的数据了                                                                                                                              
            DataTable dt_xls_cap = FeatureBuild.excelToDataSet("FZM FBP tool.xlsb", "Capacities,FT_FZ01_Dev,FT_FZ02_Dev", "cap");                         //调用GetData方发写上Excel文件所在的路径，这样就能获取到Excel表里面的数据了        

            var dt_dates = FeatureBuild.FormatDataTableDates(dt_xls_dates);
            var dt_cap = FeatureBuild.FormatDataTableCap(dt_xls_cap);

            DT_REL = FeatureBuild.FormatDataTableRelease(dt_xls_dates);
            DT_FB = FeatureBuild.MergeDataTable(dt_dates, dt_cap);
        }
     
        

        public PrePlanner(ScrumTeamOwner sto)
        {
            Sto = sto;
            fbChecker = new FeatureBuildChecker();
        }
        private delegate void ProcessSTO_delegate();
        public void AsyncProcessSTO()
        {
            ProcessSTO_delegate dele = new ProcessSTO_delegate(ProcessSTO);
            var res = dele.BeginInvoke(null, null);        
        }

        
        public void ProcessSTO()
        {
            if(Sto.Selected == true && Sto.Run_Stat == STO_RUN_STAT.TO_RUN)
            {
                Sto.Run_Stat = STO_RUN_STAT.RUNNING;
                Program.fmMainWindow.RefreshUIDgvSTO();
                
                ExecuteAlgorithm();
                Sto.Run_Stat = STO_RUN_STAT.TO_RUN;
                Program.fmMainWindow.RefreshUIDgvSTO();
            }

        }
        private string fb;
        private FeatureBuildChecker fbChecker;
        private List<DataRow> PrepareItemList(string team)
        {

            try
            {
                List<DataRow> list = DT_AvailIssues.Select(/*"STO=" + ScrumTeamOwner.DicTeamToCode[team] + "and Status = 'Open' "*/"Assigned is NULL").ToList();

                list.Sort(SortItemListByPriority);

                return list;
            }
            catch
            {
                return null;
            }
        }

        private int SortItemListByPriority(DataRow row_a, DataRow row_b)
        {
            if (row_a["Priority"].ToString() == "") return 1;
            if (row_b["Priority"].ToString() == "") return -1;
            if ((Convert.ToDouble(row_a["Priority"].ToString()) > Convert.ToDouble(row_b["Priority"].ToString())))
            {
                return 1;
            }
            return -1;
        }

        private bool HasCapacityEntry(string team, string fb)
        {
            try
            {
                return string.IsNullOrEmpty(DT_FB.Select("fb=" + fb)[0][team].ToString()) == false;

            }
            catch
            {
                return false;
            }

        }

        private double GetTeamCapacity(String team, string fb)
        {

            return Convert.ToDouble(DT_FB.Select("fb=" + fb)[0][team].ToString());
        }

        private double GetAvaliableFrame(string team, string fb, double capacity)
        {

            double capacity_untouchable;
            capacity_untouchable = 0;

            List<DataRow> list = DT_UntouchableIssues
                .Select("[Target FB]= " + fb + " and STO= " + ScrumTeamOwner.DicTeamToCode[team])
                .ToList();
            foreach (DataRow row in list)
            {
                string eff = row["Rem Eff"].ToString();
                capacity_untouchable += Convert.ToDouble(eff.Remove(eff.Length - 1, 1));
            }

            list = DT_AvailIssues.Select("[Target FB]= " + fb + " and STO= " + ScrumTeamOwner.DicTeamToCode[team] + " and Assigned is not NULL").ToList();
            foreach (DataRow row in list)
            {
                string eff = row["Rem Eff"].ToString();
                capacity_untouchable += Convert.ToDouble(eff.Remove(eff.Length - 1, 1));
            }
            return capacity - capacity_untouchable;
        }
        public bool IsOverloadAllowed(DataRow r, string fb, string team)
        {
            string upperBound = r["End FB"].ToString();

            if (upperBound == "") return false;

            upperBound = r["End FB"].ToString();

            return fbChecker.isValid(upperBound) && !fbChecker.isLater(upperBound, fb);
        }

        private bool AppliesToRow(DataRow r, string team)
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
            // return FbFitsInFeatureReleaseRange(row)&& FitsInBounds(row,fb);
            return FbFitsInFeatureReleaseRange(row) && CanBeAssignedToFb(row, fb, team);
        }

        private bool FbFitsInFeatureReleaseRange(DataRow row)
        {
            string release = row["Entity REL"].ToString();
            DataRow[] dr = DT_REL.Select("Release = '" + release + "'");

            if (dr.Count() > 0)
            {
                List<DataRow> releaseItem = dr.ToList();
                var startFb = releaseItem[0]["Start FB"].ToString();
                if (fbChecker.isValid(startFb))
                    return !fbChecker.isEarlier(fb, startFb);
            }

            return true;
        }

        public bool CanBeAssignedToFb(DataRow r, string fb, string team)
        {
            return FitsInBounds(r, fb) && MeetsEtInboundDependency(r, fb) && MeetsSeEfsInboundDependency(r, fb);
        }
        private bool MeetsEtInboundDependency(DataRow row, string fb)
        {
            /*
            if (row.FeatureType.IsEt && row.Status.IsScInternal && row.HasParent(backlog))
            {
                var devSiblings = row.Parent(backlog).Children(backlog).Where(item => item.Status.IsScInternal && !item.FeatureType.IsEt && fbChecker.isValid(item[Names.Development.TargetFb].Value));
                return devSiblings.All(item => fbChecker.isEarlier(item[Names.Development.TargetFb].Value, fb));
            }
            */
            return true;
        }
        private bool MeetsSeEfsInboundDependency(DataRow r, string fb)
        {
            /*
            var efsFb = r[Names.SePlanning.FB_FZMEfsFBexit].Value;

            if (fbChecker.isValid(efsFb))
                return !fbChecker.isEarlier(fb, efsFb);
                */

            return true;
        }
        private bool FitsInBounds(DataRow r, string fb)
        {
            bool isTooEarly = false;
            bool isTooLate = false;

            string lowerBound = r["Start FB"].ToString();
            string upperBound = r["End FB"].ToString();

            if (lowerBound != "")
            {

                if (fbChecker.isValid(lowerBound) && fbChecker.isFromFuture(lowerBound))
                    isTooEarly = fbChecker.isEarlier(fb, lowerBound);
            }

            if (upperBound != "")
            {

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
            var tablerow = DT_AvailIssues.Select("[Item ID]='" + row["Item ID"].ToString() + "'")[0];
            if (tablerow["Target FB"].ToString() != fb || tablerow["Status"].ToString() != "Scheduled")
            {
                tablerow["Target FB"] = fb;
                tablerow["Status"] = "Scheduled";
                tablerow["Assigned"] = "M";
            }

            list.Remove(row);
        }

        private bool FitsInTheFrame(string team, double frame, DataRow row)
        {
            return (frame - getTotalEffort(row, team, fb)) >= 0;
        }


        private double getTotalEffort(DataRow row, string team, string fb)
        {
            string eff = row["Rem Eff"].ToString();
            return Convert.ToDouble(eff.Remove(eff.Length - 1, 1));
        }

        private bool CanSplitTheWork(DataRow row)
        {
            //To be finished...
            return false;
        }
        public void Process(string team)
        {

            fb = fbChecker.GetNextFb(fbChecker.GetCurrentFeatureBuild());

            List<DataRow> list = PrepareItemList(team);


            while (list != null && list.Count > 0 && HasCapacityEntry(team, fb))
            {
                double frame = GetAvaliableFrame(team, fb, GetTeamCapacity(team, fb));

                List<DataRow> extraItems = list.Where(r => IsOverloadAllowed(r, fb, team)).ToList();

                if (frame > 0 || extraItems.Count() > 0)
                    SplitIfNeededAndFillTheFrame(list, frame, team);
                else
                    fb = fbChecker.GetNextFb(fb);

            }

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
        private void ExecuteAlgorithm()
        {
           
            logger.Info("ExecuteAlgorithm for STO " + Sto.Name);

            Program.fmMainWindow.RefreshUIDgvAvailIssues();
            Program.fmMainWindow.RefreshUIDgvUntouchableIssues();
            GetAllIssues();
           
            Process(Sto.Name);
            Program.fmMainWindow.RefreshUIDgvAvailIssues();
            Program.fmMainWindow.RefreshUIDgvUntouchableIssues();


        }


        
        JObject JOBJ_JSON = null;
        public  void GetAllIssues()
        {
       
            JOBJ_JSON = null;
            STO_AllIssues.Rows.Clear();
            DT_AvailIssues.Rows.Clear();
            DT_UntouchableIssues.Rows.Clear();
            string strFilter = string.Format("search?jql=cf[29790]={0}", Sto.Code);
            string strFields = "&fields=issuelinks,issuetype,customfield_37381,customfield_38702,customfield_38719,customfield_29790,status,customfield_38751,customfield_38694,customfield_38693,timetracking,customfield_38725";
            string strOrderby = "+order+by+cf[38719]";
            string strSearch = strFilter + strOrderby + strFields;
            string url = System.IO.Path.Combine(Config.Instance.RestApi_Path, strSearch);
          
            int curIssueNum = 0;
            int totalIssueNum = 1;

            while (curIssueNum < totalIssueNum)
            {
                string cmd = "&startAt=" + curIssueNum.ToString();
                string json = RestAPIAccess.ExecuteRestAPI_CURL(Config.Instance.UserName, Config.Instance.Password, url, "GET", cmd);
                try
                {
                    RootObject rb = JsonConvert.DeserializeObject<RootObject>(json);
                    JOBJ_JSON = JObject.Parse(json);
                   
                    

                    if (rb.issues == null)
                    {
                        logger.Error("Data error:" + json);
                        return;
                    }
                    foreach (Issues issue in rb.issues)
                    {
                        TableObject newTabObj = new TableObject(issue);
                        newTabObj.Parent = GetParentIssue(issue.key, JOBJ_JSON);


                        STO_AllIssues.Rows.Add(newTabObj.Key, newTabObj.ItemID, newTabObj.FP, newTabObj.UnifiedPriority,newTabObj.IssueType, newTabObj.ScrumTeamOwner, newTabObj.LeadRelease,
                           newTabObj.Status, newTabObj.StartFB, newTabObj.EndFB, newTabObj.TargetFB, newTabObj.OriginalEffort, newTabObj.RemWorkEffort, newTabObj.Parent);

                        DataTable dt = null;
                        if(newTabObj.IssueType == "Epic")
                        {
                            dt = (newTabObj.Status == "Open" || newTabObj.Status == "Scheduled" )? DT_AvailIssues : DT_UntouchableIssues;
                        }
                        else if(newTabObj.IssueType == "Competence Area")
                        {
                            dt = DT_CA;
                        }


                        dt.Rows.Add(newTabObj.Key,newTabObj.ItemID, newTabObj.FP, newTabObj.UnifiedPriority, newTabObj.IssueType, newTabObj.ScrumTeamOwner, newTabObj.LeadRelease,
                           newTabObj.Status, newTabObj.StartFB, newTabObj.EndFB, newTabObj.TargetFB, newTabObj.OriginalEffort, newTabObj.RemWorkEffort, newTabObj.Parent);
                    }
                    totalIssueNum = Convert.ToInt32(rb.total);
                    curIssueNum += rb.issues.Count;
                }
                catch(SystemException exp)
                {
                    logger.Error("exception:" + exp.Message +"---" + json);
                    return;
                }   
               
            }
            
        }
        
        private string GetParentIssue(string key, JObject jobj)
        {
            if (jobj == null) return null;

            var ilks = jobj.SelectToken("$.issues[?(@.key == '" + key + "')]")["fields"]["issuelinks"];
            string parentkey = null;
            foreach (var ilk in ilks)
            {
                try
                {
                    parentkey = ilk["inwardIssue"]["key"].ToString();
                    break;
                }
                catch
                {
                    continue;
                }
            }
            return parentkey;
        }

        private DataTable _issue_lookup_table;
        public DataTable Issue_Lookup_Table
        {
            get
            {
                if (_issue_lookup_table == null)
                {
                    _issue_lookup_table = STO_AllIssues.Clone();
                    _issue_lookup_table.Columns.Add("JOBJECT");

                }
                return _issue_lookup_table;
            }
        }

        private DataRow GetParentIssue(string parentkey)
        {
            var rows = Issue_Lookup_Table.Select("Key='" + parentkey + "'");
            if (rows.Count() > 0)
            {
                return rows[0];
            }
            else //using Rest API get 
            {
                string strFilter = string.Format("search?jql=Key={0}", parentkey);
                string strFields = "&fields=issuelinks,issuetype,customfield_37381,customfield_38702,customfield_38719,customfield_29790,status,customfield_38751,customfield_38694,customfield_38693,timetracking,customfield_38725";
                string strOrderby = "+order+by+cf[38719]";
                string strSearch = strFilter + strOrderby + strFields;
                string url = System.IO.Path.Combine(Config.Instance.RestApi_Path, strSearch);

                string json = RestAPIAccess.ExecuteRestAPI_CURL(Config.Instance.UserName, Config.Instance.Password, url, "GET", string.Empty);

                try
                {

                    RootObject rb = JsonConvert.DeserializeObject<RootObject>(json);
                    JObject JOBJ_JSON = JObject.Parse(json);
                    if (rb.issues == null)
                    {
                        logger.Error("Data error:" + json);
                        return null;
                    }
                    foreach (Issues issue in rb.issues)
                    {
                        TableObject newTabObj = new TableObject(issue);
                        newTabObj.Parent = GetParentIssue(issue.key, JOBJ_JSON);
                        if(string.IsNullOrEmpty(newTabObj.Parent))
                        {
                            return null;
                        }
                        
                        return Issue_Lookup_Table.Rows.Add(newTabObj.Key, newTabObj.ItemID, newTabObj.FP, newTabObj.UnifiedPriority, newTabObj.IssueType, newTabObj.ScrumTeamOwner, newTabObj.LeadRelease,
                           newTabObj.Status, newTabObj.StartFB, newTabObj.EndFB, newTabObj.TargetFB, newTabObj.OriginalEffort, newTabObj.RemWorkEffort, newTabObj.Parent,JOBJ_JSON);
                    }
                }
                catch
                {
                    return null;
                }
                return null;
            }

            
        }

        private DataRow GetParentIssue_until_type(string parentkey, string issueType)  //Entity Item,  Competence Area ,  Epic
        {
            DataRow row = null;
            do
            {
                row = GetParentIssue(parentkey);

            } while (row != null || row["IssueType"].ToString() != issueType);

            return row;
        }

        public DataRow[] Get_Relevant_CA(DataRow epicRow, string filter)
        {
            var EntityRow = GetParentIssue_until_type(epicRow["Parent"].ToString(), "Entity Item");
            var jobj = (JObject)EntityRow["JOBJECT"];
            var ilks = jobj.SelectToken("$.issues[?(@.key == '" + EntityRow["Key"] + "')]")["fields"]["issuelinks"];
            string childKey = null;
            foreach (var ilk in ilks)
            {
                try
                {
                    childKey = ilk["outwardIssue"]["key"].ToString();
                    break;
                }
                catch
                {
                    continue;
                }
            }
            return null;

        }
    }
}
