using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.OleDb;
using System.Collections;
namespace FusionPrePlaner
{
    public partial class FM_Main : Form
    {
        DateTime dt_NextRun;
        private bool curAutoRunStat = false;

        //private static List<PrePlanner> _prePlannerList;

        public FM_Main()
        {
            InitializeComponent();
            this.dgv_STO.DataSource = ScrumTeamOwner.STO_FULL_LIST;
            
            this.txtInterval.DataBindings.Add("Text", Config.Instance, "PrePlanInterval", false, DataSourceUpdateMode.Never);
            this.chkAutoRun.DataBindings.Add("Checked", Config.Instance, "AutoRun", false, DataSourceUpdateMode.Never);
            this.chkRunOnStart.DataBindings.Add("Checked", Config.Instance, "RunOnStart", false, DataSourceUpdateMode.Never);

            this.txtRestApiPath.DataBindings.Add("Text", Config.Instance, "RestApi_Path", false, DataSourceUpdateMode.Never);
            this.txtUserName.DataBindings.Add("Text", Config.Instance, "UserName", false, DataSourceUpdateMode.Never);
            this.txtUserPassword.DataBindings.Add("Text", Config.Instance, "Password", false, DataSourceUpdateMode.Never);
            curAutoRunStat = Config.Instance.AutoRun;

         

        }

        private void chkSelectAllSTO_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in ScrumTeamOwner.STO_FULL_LIST)
                item.Selected = this.chkSelectAllSTO.Checked;
            this.dgv_STO.Invalidate();
        }

        private BindingSource bsAvail;
        private BindingSource bsUntouch;

        
        private void RefreshDgvSTOIssues()
        {
            if (dgv_STO.SelectedRows.Count > 0)
            {
                var obj = dgv_STO.SelectedRows[0].Cells["Code"].Value;
                string teamcode = obj == null ? null : obj.ToString();
                var preplanner = PrePlanner.GetPrePlannerFromTeamCode(teamcode);
                if (preplanner != null)
                {
                    bsAvail = new BindingSource();
                    bsAvail.DataSource = preplanner.DT_AvailIssues;
                   // bsAvail.Filter = "Status='Open'";
                    dgv_AvailableIssues.DataSource = bsAvail;

                    bsUntouch = new BindingSource();
                    bsUntouch.DataSource = preplanner.DT_UntouchableIssues;
                   // bsUntouch.Filter = "Status='Done'";
                    dgv_UntouchableIssues.DataSource = bsUntouch;


                }
            }

        }

        public delegate void RefreshUIDgvSTODele();
        public void RefreshUIDgvSTO()
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new RefreshUIDgvSTODele(RefreshUIDgvSTO),null);
            }
            else
            {
              
                CurrencyManager cm = dgv_STO.BindingContext[dgv_STO.DataSource] as CurrencyManager;
                cm.Refresh();
            }
        }
      

        public delegate void RefreshUIDgvIssuesDele();
        public void RefreshUIDgvAvailIssues()
        {
            
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new RefreshUIDgvIssuesDele(RefreshUIDgvAvailIssues));
            }
            else
            {
           
                try
                {
                    //CurrencyManager cm = dgv_AvailableIssues.BindingContext[dgv_AvailableIssues.DataSource] as CurrencyManager;
                    CurrencyManager cm = bsAvail.CurrencyManager;
                    cm.Refresh();
                }
                catch
                {
                    //nodo
                }
            }
            
          

        }
        public void RefreshUIDgvUntouchableIssues()
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new RefreshUIDgvIssuesDele(RefreshUIDgvUntouchableIssues));
            }
            else
            {

                try
                {
                    // CurrencyManager cm = dgv_UntouchableIssues.BindingContext[dgv_UntouchableIssues.DataSource] as CurrencyManager;
                    CurrencyManager cm = bsUntouch.CurrencyManager;
                    cm.Refresh();
                }
                catch
                {

                }
            }



        }

        private void dgv_STO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_STO.Columns[e.ColumnIndex].Name == "col_Preplan")
            {

                if ((STO_RUN_STAT)dgv_STO.Rows[e.RowIndex].Cells["col_runstat"].Value == STO_RUN_STAT.RUNNING)
                {
                    MessageBox.Show("Already Running");
                }
                else if ((STO_RUN_STAT)dgv_STO.Rows[e.RowIndex].Cells["col_runstat"].Value == STO_RUN_STAT.TO_RUN)
                {
                    var sto_name = dgv_STO.Rows[e.RowIndex].Cells["col_STO"].Value.ToString();
                    var sto = ScrumTeamOwner.GetSTO(sto_name);
                    var preplanner = PrePlanner.GetPrePlannerFromTeamCode(sto.Code);


                    preplanner.AsyncProcessSTO();

                }
            }
        }

        private void btnRunAll_Click(object sender, EventArgs e)
        {
            RunAllPrePlan();
        }
        
        private static void RunAllPrePlan()
        {
           

            foreach (var preplanner in PrePlanner.PrePlannerList)
            {
                preplanner.AsyncProcessSTO();
            }
        }

        private void FM_Main_Load(object sender, EventArgs e)
        {
            LoadFB();//add for show FB data
            if (Config.Instance.RunOnStart)
            {
                RunAllPrePlan();
            }

            timer1Sec.Start();
            if (Config.Instance.AutoRun)
            {
                dt_NextRun = DateTime.Now.AddMinutes(Config.Instance.PrePlanInterval);
            }

        }

        private void btnRunConfigApply_Click(object sender, EventArgs e)
        {
            try
            {
                Config.Instance.PrePlanInterval = int.Parse(txtInterval.Text);
                Config.Instance.AutoRun = chkAutoRun.Checked;
                Config.Instance.RunOnStart = chkRunOnStart.Checked;
                Config.Serialize(Config.Instance);
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, "Apply Configuration Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.btnRunConfigApply.Enabled = txtInterval.Text.Trim() != Config.Instance.PrePlanInterval.ToString();
            this.btnRunConfigCancel.Enabled = this.btnRunConfigApply.Enabled;
        }

        private void btnRunConfigCancel_Click(object sender, EventArgs e)
        {
            chkAutoRun.Checked = Config.Instance.AutoRun;
            txtInterval.Text = Config.Instance.PrePlanInterval.ToString();

            this.btnRunConfigApply.Enabled = txtInterval.Text.Trim() != Config.Instance.PrePlanInterval.ToString();
            this.btnRunConfigCancel.Enabled = this.btnRunConfigApply.Enabled;
        }

       
        private void btnRestApiConfigApply_Click(object sender, EventArgs e)
        {
            try
            {
                Config.Instance.RestApi_Path = txtRestApiPath.Text.Trim();
                Config.Instance.UserName = txtUserName.Text.Trim();
                Config.Instance.Password = txtUserPassword.Text.Trim();
                Config.Serialize(Config.Instance);
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, "Apply Configuration Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.btnRestApiConfigApply.Enabled = (!string.IsNullOrEmpty(txtUserName.Text.Trim()) && !string.IsNullOrEmpty(txtUserName.Text.Trim()) && !string.IsNullOrEmpty(txtUserName.Text.Trim()))
                                                 && (txtRestApiPath.Text.Trim() != Config.Instance.RestApi_Path.ToString()
                                                 || txtUserName.Text.Trim() != Config.Instance.UserName.ToString()
                                                 || txtUserPassword.Text.Trim() != Config.Instance.Password.ToString());
            this.btnRestApiConfigCancel.Enabled = this.btnRestApiConfigApply.Enabled;
        }
        private void btnRestApiConfigCancel_Click(object sender, EventArgs e)
        {

            txtRestApiPath.Text = Config.Instance.RestApi_Path.ToString();
            txtUserName.Text = Config.Instance.UserName.ToString();
            txtUserPassword.Text = Config.Instance.Password.ToString();


            this.btnRestApiConfigApply.Enabled = (!string.IsNullOrEmpty(txtUserName.Text.Trim()) && !string.IsNullOrEmpty(txtUserName.Text.Trim()) && !string.IsNullOrEmpty(txtUserName.Text.Trim()))
                                                 && (txtRestApiPath.Text.Trim() != Config.Instance.RestApi_Path.ToString()
                                                 || txtUserName.Text.Trim() != Config.Instance.UserName.ToString()
                                                 || txtUserPassword.Text.Trim() != Config.Instance.Password.ToString());
            this.btnRestApiConfigCancel.Enabled = this.btnRestApiConfigApply.Enabled;
        }
        private void RunConfig_Changed(object sender, EventArgs e)
        {
            int parsedSec;
            if (int.TryParse(txtInterval.Text, out parsedSec) && parsedSec > 0)
            {
                errProviderConfig.SetError(txtInterval, null);

            }
            else
            {
                errProviderConfig.SetError(txtInterval, "No less than 1 minute");


            }
            this.btnRunConfigApply.Enabled = (parsedSec > 0) && (txtInterval.Text.Trim() != Config.Instance.PrePlanInterval.ToString()
                                     || chkAutoRun.Checked != Config.Instance.AutoRun || chkRunOnStart.Checked != Config.Instance.RunOnStart);
            this.btnRunConfigCancel.Enabled = this.btnRunConfigApply.Enabled;
        }
        private void RestAPIConfig_Changed(object sender, EventArgs e)
        {
            var txtbox = sender as TextBox;
            if (string.IsNullOrEmpty(txtbox.Text.Trim())
                
                )
            {
                errProviderConfig.SetError(txtbox, "Can not be empty");

            }
            else
            {
                errProviderConfig.SetError(txtbox, null);
            }

            this.btnRestApiConfigApply.Enabled = txtRestApiPath.Text.Trim() != Config.Instance.RestApi_Path.ToString()
                                                || txtUserName.Text.Trim() != Config.Instance.UserName.ToString()
                                                || txtUserPassword.Text.Trim() != Config.Instance.Password.ToString();
            this.btnRestApiConfigCancel.Enabled = this.btnRestApiConfigApply.Enabled;
        }



        private void timer1Sec_Tick(object sender, EventArgs e)
        {
           
            if (Config.Instance.AutoRun)
            {
                if(curAutoRunStat != Config.Instance.AutoRun)
                {
                    dt_NextRun = DateTime.Now.AddMinutes(Config.Instance.PrePlanInterval);
                }
                this.txtNextRunDt.Text = this.dt_NextRun.ToString("yyyy-MM-dd HH:mm:ss");
                this.txtCountDown.Text = ((int)((this.dt_NextRun - DateTime.Now).TotalSeconds)).ToString();
                if (DateTime.Now >= this.dt_NextRun)
                {
                    this.dt_NextRun = DateTime.Now.AddMinutes(Config.Instance.PrePlanInterval);
                    RunAllPrePlan();
                }
            }
            else
            {
                this.txtNextRunDt.Text = "N/A";
                this.txtCountDown.Text = "N/A";
            }
            curAutoRunStat = Config.Instance.AutoRun;
        }
        
        private void btnTestConn_Click(object sender, EventArgs e)
        {
    
            string res = RestAPIAccess.ExecuteRestAPI_CURL(txtUserName.Text.Trim(), txtUserPassword.Text.Trim(), txtRestApiPath.Text.Trim(), "GET", "search?jql=cf[29790]=1312&startAt=0&maxResults=3");

            try
            {
                var jobj =JObject.Parse(res);
                int issuecount = 0;
                
                if(int.TryParse(jobj["total"].ToString(), out issuecount) && issuecount>0)
                {
                    MessageBox.Show("Test OK");
                }              
                else
                {
                    MessageBox.Show("Test Failed");
                }
                    
            }
            catch
            {
                MessageBox.Show("Test Failed");
            }

        }

        private void dgv_STO_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDgvSTOIssues();
           
        }

       

        /*
        private void btnTestConn_Click(object sender, EventArgs e)
        {
            //login

            var req = HttpWebRequest.Create("https://jiradc.int.net.nokia.com/rest/api/latest/search?jql=cf[29790]=1312");
            // var req = HttpWebRequest.Create(@"https://jiradc.int.net.nokia.com/rest/api/latest/issue/FCA_FZAP-2645");
            // var req = HttpWebRequest.Create(@"https://jiradc.int.net.nokia.com/rest/api/latest/search");
            req.Method = "GET";
            req.Credentials = new NetworkCredential("fuzengz", "Password9$");
            using (WebResponse wr = req.GetResponse())
            {
                StreamReader reader = new StreamReader(wr.GetResponseStream());

                // Console application output  
                Console.WriteLine(reader.ReadToEnd());
            }


        }
        */

        /*start to add for show FB data*/
        private string getExcelOleDBConnectStr(string filePath)
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
               + "Data Source=" + @filePath + ";" + "Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";

            return strConn;
        }

        private ArrayList getExcelSheetNames(string filePath)
        {
            ArrayList arrayNames = new ArrayList();
            string strConn = getExcelOleDBConnectStr(filePath);
            DataTable tb = null;

            try
            {
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                tb = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (System.Data.DataRow drow in tb.Rows)
                {
                    string sheetName = drow["TABLE_NAME"].ToString().Trim();
                    int pos = sheetName.LastIndexOf('$');
                    if (pos != -1 && (sheetName == "cap" || sheetName == "Dates"))
                    {
                        arrayNames.Add(sheetName.Substring(0, pos));
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return arrayNames;

        }

        private DataTable excelToDataSet(string filePath, string filterdata, string tobeOpenSheet)
        {
            string strConn = getExcelOleDBConnectStr(filePath);
            DataTable ds = null;
            OleDbConnection conn = new OleDbConnection(strConn);

            try
            {
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                strExcel = "select * from [" + tobeOpenSheet + "$]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ds = new DataTable();

                myCommand.Fill(ds);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }

        private void RemoveEmpty(DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsNull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {
                        IsNull = false;
                    }
                }
                if (IsNull)
                {
                    removelist.Add(dt.Rows[i]);
                }
            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
        }

        private DataTable UpdateDatatable1(DataTable DataTable1)
        {
            RemoveEmpty(DataTable1);
            for (int i = DataTable1.Columns.Count - 1; i > 2; i--)
            {
                //再向新表中加入DataTable2的列结构
                DataTable1.Columns.RemoveAt(i);
            }
            DataTable1.Rows[0].Delete();
            DataTable1.AcceptChanges();
            return DataTable1;
        }

        public DataTable GetDistinctPrimaryKeyColumnTable(DataTable dt, string[] PrimaryKeyColumns)
        {
            DataView dv = dt.DefaultView;
            DataTable dtDistinct = dv.ToTable(true, PrimaryKeyColumns);
            return dtDistinct;
        }

        private DataTable updateDatatable2(DataTable DataTable2)
        {
            RemoveEmpty(DataTable2);
            for (int i = 54; i >= 0; i--)
            {
                DataTable2.Rows.RemoveAt(i);
            }
            for (int i = DataTable2.Columns.Count - 1; i >= 0; i--)
            {
                if (i > 9)
                {
                    DataTable2.Columns.RemoveAt(i);
                }
                else if (i > 2 && i < 9)
                {
                    DataTable2.Columns.RemoveAt(i);
                }
                else if (i == 1)
                {
                    DataTable2.Columns.RemoveAt(i);
                }
            }
            return DataTable2;
        }

        private DataTable MergeDataTable(DataTable DataTable1, DataTable DataTable2)
        {
            DataTable newDataTable = DataTable1.Clone();
            for (int i = 1; i < DataTable2.Columns.Count; i++)
            {
                //再向新表中加入DataTable2的列结构
                newDataTable.Columns.Add(DataTable2.Columns[i].ColumnName);
            }
            object[] obj = new object[newDataTable.Columns.Count];
            //添加DataTable1的数据
            for (int i = 0; i < DataTable1.Rows.Count; i++)
            {
                DataTable1.Rows[i].ItemArray.CopyTo(obj, 0);
                newDataTable.Rows.Add(obj);
            }
            if (DataTable1.Rows.Count >= DataTable2.Rows.Count)
            {
                for (int i = 0; i < DataTable2.Rows.Count; i++)
                {
                    for (int j = 0; j < DataTable2.Columns.Count - 1; j++)
                    {
                        newDataTable.Rows[i][j + DataTable1.Columns.Count] = DataTable2.Rows[i][j + 1].ToString();
                    }
                }
            }
            else
            {
                DataRow dr3;
                //向新表中添加多出的几行
                for (int i = 0; i < DataTable2.Rows.Count - DataTable1.Rows.Count; i++)
                {
                    dr3 = newDataTable.NewRow();
                    newDataTable.Rows.Add(dr3);
                }
                for (int i = 0; i < DataTable2.Rows.Count; i++)
                {
                    for (int j = 0; j < DataTable2.Columns.Count; j++)
                    {
                        newDataTable.Rows[i][j + DataTable1.Columns.Count] = DataTable2.Rows[i][j].ToString();
                    }
                }
            }
            return newDataTable;
        }

        class Fb
        {
            public string FB { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string FZ01 { get; set; }
            public string FZ02 { get; set; }
        }
        private void LoadFB()
        {
            dataGridView2.DataSource = null; //每次打开清空内容
            DataTable dt_dates = excelToDataSet("FZM FBP tool.xlsb", "Feature Build,Start Date,End Date", "Dates");                         //调用GetData方发写上Excel文件所在的路径，这样就能获取到Excel表里面的数据了                                                                                                                              
            DataTable dt_cap = excelToDataSet("FZM FBP tool.xlsb", "Capacities,FT_FZ01_Dev,FT_FZ02_Dev", "cap");                         //调用GetData方发写上Excel文件所在的路径，这样就能获取到Excel表里面的数据了        
            DataTable dt_dates_update = UpdateDatatable1(dt_dates);
            DataTable dt_dates_distinct = GetDistinctPrimaryKeyColumnTable(dt_dates_update, new string[] { "Feature Build", "Start Date", "End Date" });
            DataTable dt_cap_update = updateDatatable2(dt_cap);
            DataTable dt_fb = MergeDataTable(dt_dates_distinct, dt_cap_update);
            int count = dt_fb.Rows.Count;
            if (dt_fb.Rows.Count > 0)
            {
                List<Fb> lists = new List<Fb>();
                for (int i = 0; i < dt_fb.Rows.Count; i++)
                {
                    Fb fb = new Fb();
                    fb.FB = Convert.ToString(dt_fb.Rows[i][0]);
                    fb.StartDate = Convert.ToDateTime(dt_fb.Rows[i][1]);
                    fb.EndDate = Convert.ToDateTime(dt_fb.Rows[i][2]);
                    fb.FZ01 = Convert.ToString(dt_fb.Rows[i][3]);
                    fb.FZ02 = Convert.ToString(dt_fb.Rows[i][4]);
                    lists.Add(fb);
                }
                dataGridView2.DataSource = lists;
            }
        }
    }
}
