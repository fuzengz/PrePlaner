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
            return  PrePlannerList.Where<PrePlanner>(planner => planner.Sto.TeamCode == code).ToList()[0];
           
        }
            


        private ScrumTeamOwner Sto;
        private DataTable _availableIssues;
        public DataTable AvailableIssues
        {
            get
            {
                if(_availableIssues == null)
                {
                    _availableIssues = new DataTable("Issues");

                    _availableIssues.Columns.Add(new DataColumn("Item ID", typeof(string)));
                    _availableIssues.Columns.Add(new DataColumn("FP", typeof(string)));                 
                    _availableIssues.Columns.Add(new DataColumn("Priority", typeof(string)));
                    _availableIssues.Columns.Add(new DataColumn("STO", typeof(string)));
                    _availableIssues.Columns.Add(new DataColumn("Entity REL", typeof(string)));
                    _availableIssues.Columns.Add(new DataColumn("Status", typeof(string)));

                    _availableIssues.Columns.Add(new DataColumn("Start FB", typeof(string)));
                    _availableIssues.Columns.Add(new DataColumn("End FB", typeof(string)));
                    _availableIssues.Columns.Add(new DataColumn("Target FB", typeof(string)));

                    _availableIssues.Columns.Add(new DataColumn("Ori Eff", typeof(string)));
                    _availableIssues.Columns.Add(new DataColumn("Rem Eff", typeof(string)));

                }
                return _availableIssues;
            }
        }  

        public PrePlanner(ScrumTeamOwner sto)
        {
            Sto = sto;
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
                Program.fmMainWindow.RefreshUI();
                
                ExecuteAlgorithm();
                Sto.Run_Stat = STO_RUN_STAT.TO_RUN;
                Program.fmMainWindow.RefreshUI();
            }

        }
        private void ExecuteAlgorithm()
        {
           
            logger.Info("ExecuteAlgorithm for STO " + Sto.Name);

            Program.fmMainWindow.RefreshUIDgvAvailIssues(null);
            AvailableIssues.Rows.Clear();
            
            GetAvailableIssues();
              Program.fmMainWindow.RefreshUIDgvAvailIssues(AvailableIssues);


        }

        public  void GetAvailableIssues()
        {
            string strFilter = string.Format("search?jql=cf[29790]={0}%20and%20status=Open", Sto.TeamCode) ;
            string strFields = "&fields=customfield_37381,customfield_38702,customfield_38719,customfield_29790,status,customfield_38751,customfield_38694,customfield_38693,timetracking,customfield_38725";
            string strOrderby = "+order+by+cf[38719]";
            string strSearch = strFilter + strOrderby + strFields;
            string url = System.IO.Path.Combine(Config.Instance.RestApi_Path, strSearch);
          
            int curIssueNum = 0;
            int totalIssueNum = 1;

            while (curIssueNum < totalIssueNum)
            {
                string cmd = "&startAt=" + curIssueNum.ToString();
                string json = RestAPIAccess.ExecuteRestAPI_CURL(Config.Instance.UserName, Config.Instance.Password, url, "GET", cmd);
                
                RootObject rb = JsonConvert.DeserializeObject<RootObject>(json);
                foreach (Issues issue in rb.issues)
                {
                    TableObject newTabObj = new TableObject(issue);
                    AvailableIssues.Rows.Add(newTabObj.ItemID, newTabObj.FP,newTabObj.UnifiedPriority, newTabObj.ScrumTeamOwner, newTabObj.LeadRelease,
                       newTabObj.Status, newTabObj.StartFB, newTabObj.EndFB, newTabObj.TargetFB, newTabObj.OriginalEffort, newTabObj.RemWorkEffort);
                }
                totalIssueNum = Convert.ToInt32(rb.total);
                curIssueNum += rb.issues.Count;
            }
            
        }
        

        

    }
}
