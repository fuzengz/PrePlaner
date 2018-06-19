using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FusionPrePlaner
{
    public partial class FM_Main : Form
    {
        DateTime dt_NextRun;
        private bool curAutoRunStat = false;
        public FM_Main()
        {
            InitializeComponent();
            this.dgv_STO.DataSource = ScrumTeamOwner.STO_FULL_LIST;

            this.txtInterval.DataBindings.Add("Text", Config.Instance, "PrePlanInterval", false, DataSourceUpdateMode.Never);
            this.chkAutoRun.DataBindings.Add("Checked", Config.Instance, "AutoRun", false, DataSourceUpdateMode.Never);
            this.chkRunOnStart.DataBindings.Add("Checked", Config.Instance, "RunOnStart", false, DataSourceUpdateMode.Never);

            curAutoRunStat = Config.Instance.AutoRun;



        }

        private void chkSelectAllSTO_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in ScrumTeamOwner.STO_FULL_LIST)
                item.Selected = this.chkSelectAllSTO.Checked;
            this.dgv_STO.Invalidate();
        }

        public delegate void RefreshUIDele();
        public void RefreshUI()
        {
            dgv_STO.Invalidate();
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
                    var preplanner = new PrePlanner(sto);


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
            var prePlannerList = new List<PrePlanner>();
            foreach (var sto in ScrumTeamOwner.STO_FULL_LIST)
            {
                if (sto.Selected && sto.Run_Stat == STO_RUN_STAT.TO_RUN)
                {
                    prePlannerList.Add(new PrePlanner(sto));

                }
            }

            foreach (var preplanner in prePlannerList)
            {
                preplanner.AsyncProcessSTO();
            }
        }

        private void FM_Main_Load(object sender, EventArgs e)
        {
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

        private void btnApply_Click(object sender, EventArgs e)
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
            this.btnApply.Enabled = txtInterval.Text.ToString().Trim() != Config.Instance.PrePlanInterval.ToString();
            this.btnCancel.Enabled = this.btnApply.Enabled;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            chkAutoRun.Checked = Config.Instance.AutoRun;
            txtInterval.Text = Config.Instance.PrePlanInterval.ToString();

            this.btnApply.Enabled = txtInterval.Text.ToString().Trim() != Config.Instance.PrePlanInterval.ToString();
            this.btnCancel.Enabled = this.btnApply.Enabled;
        }

        private void Config_Changed(object sender, EventArgs e)
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
            this.btnApply.Enabled = (parsedSec > 0) && (txtInterval.Text.ToString().Trim() != Config.Instance.PrePlanInterval.ToString()
                                     || chkAutoRun.Checked != Config.Instance.AutoRun || chkRunOnStart.Checked != Config.Instance.RunOnStart);
            this.btnCancel.Enabled = this.btnApply.Enabled;
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
    }
}
