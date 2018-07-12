using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json;

namespace FusionPrePlaner
{
    class JsonToClass
    {
        public static DataTable resultsTable = new DataTable();

        public static void initTable()
        {
            resultsTable = new DataTable("results");

            DataColumn dc_0 = new DataColumn("id", typeof(string));
            DataColumn dc_1 = new DataColumn("FP", typeof(string));
            DataColumn dc_2 = new DataColumn("Item ID", typeof(string));
            DataColumn dc_3 = new DataColumn("Unified Priority", typeof(string));
            DataColumn dc_4 = new DataColumn("Scrum Team Owner", typeof(string));
            //DataColumn dc_5 = new DataColumn("Status", typeof(string));
            //DataColumn dc_6 = new DataColumn("Target FB", typeof(string));
            DataColumn dc_7 = new DataColumn("pre-plan lower bound", typeof(string));
            DataColumn dc_8 = new DataColumn("pre-plan upper bound", typeof(string));
            DataColumn dc_9 = new DataColumn("Original Effort", typeof(string));
            DataColumn dc_10 = new DataColumn("Rem. Work Effort", typeof(string));
            //DataColumn dc_11 = new DataColumn("Lead Release", typeof(string));

            resultsTable.Columns.Add(dc_0);
            resultsTable.Columns.Add(dc_1);
            resultsTable.Columns.Add(dc_2);
            resultsTable.Columns.Add(dc_3);
            resultsTable.Columns.Add(dc_4);
            //resultsTable.Columns.Add(dc_5);
            //resultsTable.Columns.Add(dc_6);
            resultsTable.Columns.Add(dc_7);
            resultsTable.Columns.Add(dc_8);
            resultsTable.Columns.Add(dc_9);
            resultsTable.Columns.Add(dc_10);
            //resultsTable.Columns.Add(dc_11);
        }

        public static void translate(string url, string cmd)
        {
            string json = RestAPIAcess.ExecuteRestAPI_CURL("fuzengz", "Password9$", url, "GET", cmd);
            if (json == null) {
                Console.WriteLine("json text is null, some erorrs");
                return;
            }
            RootObject rb = JsonConvert.DeserializeObject<RootObject>(json);
            int issueNum = rb.issues.Count;
            foreach(Issues issue in rb.issues)
            {
                TableObject newTabObj = new TableObject(issue);
                resultsTable.Rows.Add(newTabObj.id,newTabObj.FP,newTabObj.ItemID,newTabObj.UnifiedPriority,newTabObj.ScrumTeamOwner,
                    newTabObj.PrePlanLowerBound,newTabObj.PrePlanUpperBound,newTabObj.OriginalEffort,newTabObj.RemWorkEffort);
            }

            if (Convert.ToUInt32(rb.startAt) + Convert.ToUInt32(rb.maxResults) < Convert.ToUInt32(rb.total))
            {
                cmd = "&startAt=" + (Convert.ToUInt32(rb.startAt) + Convert.ToUInt32(rb.maxResults)).ToString();
                translate(url, cmd);
            }
        }
    }
}
