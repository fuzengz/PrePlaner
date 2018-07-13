namespace FusionPrePlaner
{
    partial class FM_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_main = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_STO = new System.Windows.Forms.DataGridView();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_STO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Squad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Preplan = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_runstat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCountDown = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSelectAllSTO = new System.Windows.Forms.CheckBox();
            this.btnRunAll = new System.Windows.Forms.Button();
            this.txtNextRunDt = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_AvailableIssues = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.FB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FZ01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FZ02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tp_config = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnRestApiConfigCancel = new System.Windows.Forms.Button();
            this.btnRestApiConfigApply = new System.Windows.Forms.Button();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtRestApiPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkRunOnStart = new System.Windows.Forms.CheckBox();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.btnRunConfigCancel = new System.Windows.Forms.Button();
            this.btnRunConfigApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.errProviderConfig = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1Sec = new System.Windows.Forms.Timer(this.components);
            this.dgv_UntouchableIssues = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tp_main.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_STO)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AvailableIssues)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tp_config.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UntouchableIssues)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_main);
            this.tabControl1.Controls.Add(this.tp_config);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1362, 742);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_main
            // 
            this.tp_main.Controls.Add(this.statusStrip1);
            this.tp_main.Controls.Add(this.tableLayoutPanel1);
            this.tp_main.Location = new System.Drawing.Point(4, 22);
            this.tp_main.Name = "tp_main";
            this.tp_main.Padding = new System.Windows.Forms.Padding(3);
            this.tp_main.Size = new System.Drawing.Size(1354, 716);
            this.tp_main.TabIndex = 0;
            this.tp_main.Text = "Main";
            this.tp_main.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(3, 691);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1348, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.19355F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.09187F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.73852F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 313F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1348, 710);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_STO);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 2);
            this.groupBox1.Size = new System.Drawing.Size(320, 643);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "STO";
            // 
            // dgv_STO
            // 
            this.dgv_STO.AllowUserToAddRows = false;
            this.dgv_STO.AllowUserToDeleteRows = false;
            this.dgv_STO.AllowUserToOrderColumns = true;
            this.dgv_STO.AllowUserToResizeRows = false;
            this.dgv_STO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_STO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_STO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.col_STO,
            this.col_Squad,
            this.col_CA,
            this.col_Preplan,
            this.col_runstat});
            this.dgv_STO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_STO.Location = new System.Drawing.Point(3, 17);
            this.dgv_STO.MultiSelect = false;
            this.dgv_STO.Name = "dgv_STO";
            this.dgv_STO.RowHeadersVisible = false;
            this.dgv_STO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_STO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_STO.Size = new System.Drawing.Size(314, 623);
            this.dgv_STO.TabIndex = 0;
            this.dgv_STO.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_STO_CellContentClick);
            this.dgv_STO.SelectionChanged += new System.EventHandler(this.dgv_STO_SelectionChanged);
            // 
            // selected
            // 
            this.selected.DataPropertyName = "Selected";
            this.selected.HeaderText = "";
            this.selected.Name = "selected";
            // 
            // col_STO
            // 
            this.col_STO.DataPropertyName = "Name";
            this.col_STO.HeaderText = "STO";
            this.col_STO.Name = "col_STO";
            this.col_STO.ReadOnly = true;
            // 
            // col_Squad
            // 
            this.col_Squad.DataPropertyName = "Squad";
            this.col_Squad.HeaderText = "Squad";
            this.col_Squad.Name = "col_Squad";
            this.col_Squad.ReadOnly = true;
            // 
            // col_CA
            // 
            this.col_CA.DataPropertyName = "CA";
            this.col_CA.HeaderText = "CA";
            this.col_CA.Name = "col_CA";
            this.col_CA.ReadOnly = true;
            // 
            // col_Preplan
            // 
            this.col_Preplan.DataPropertyName = "Str_Run_Stat";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "Run";
            this.col_Preplan.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Preplan.HeaderText = "Run";
            this.col_Preplan.Name = "col_Preplan";
            this.col_Preplan.ReadOnly = true;
            // 
            // col_runstat
            // 
            this.col_runstat.DataPropertyName = "Run_Stat";
            this.col_runstat.HeaderText = "Run Stat";
            this.col_runstat.Name = "col_runstat";
            this.col_runstat.ReadOnly = true;
            this.col_runstat.Visible = false;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCountDown);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkSelectAllSTO);
            this.panel1.Controls.Add(this.btnRunAll);
            this.panel1.Controls.Add(this.txtNextRunDt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 652);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 55);
            this.panel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Count down(sec)";
            // 
            // txtCountDown
            // 
            this.txtCountDown.Location = new System.Drawing.Point(473, 5);
            this.txtCountDown.Name = "txtCountDown";
            this.txtCountDown.ReadOnly = true;
            this.txtCountDown.Size = new System.Drawing.Size(55, 20);
            this.txtCountDown.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Next AutoRun";
            // 
            // chkSelectAllSTO
            // 
            this.chkSelectAllSTO.AutoSize = true;
            this.chkSelectAllSTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAllSTO.Location = new System.Drawing.Point(13, 6);
            this.chkSelectAllSTO.Name = "chkSelectAllSTO";
            this.chkSelectAllSTO.Size = new System.Drawing.Size(42, 20);
            this.chkSelectAllSTO.TabIndex = 4;
            this.chkSelectAllSTO.Text = "All";
            this.chkSelectAllSTO.UseVisualStyleBackColor = true;
            this.chkSelectAllSTO.CheckedChanged += new System.EventHandler(this.chkSelectAllSTO_CheckedChanged);
            // 
            // btnRunAll
            // 
            this.btnRunAll.Location = new System.Drawing.Point(70, 3);
            this.btnRunAll.Name = "btnRunAll";
            this.btnRunAll.Size = new System.Drawing.Size(47, 23);
            this.btnRunAll.TabIndex = 5;
            this.btnRunAll.Text = "RUN";
            this.btnRunAll.UseVisualStyleBackColor = true;
            this.btnRunAll.Click += new System.EventHandler(this.btnRunAll_Click);
            // 
            // txtNextRunDt
            // 
            this.txtNextRunDt.Location = new System.Drawing.Point(221, 5);
            this.txtNextRunDt.Name = "txtNextRunDt";
            this.txtNextRunDt.ReadOnly = true;
            this.txtNextRunDt.Size = new System.Drawing.Size(153, 20);
            this.txtNextRunDt.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgv_UntouchableIssues);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(329, 339);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(776, 307);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Untouchable ITEMS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_AvailableIssues);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(329, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 330);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available ITEMS";
            // 
            // dgv_AvailableIssues
            // 
            this.dgv_AvailableIssues.AllowUserToAddRows = false;
            this.dgv_AvailableIssues.AllowUserToDeleteRows = false;
            this.dgv_AvailableIssues.AllowUserToOrderColumns = true;
            this.dgv_AvailableIssues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_AvailableIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AvailableIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_AvailableIssues.Location = new System.Drawing.Point(3, 17);
            this.dgv_AvailableIssues.Name = "dgv_AvailableIssues";
            this.dgv_AvailableIssues.ReadOnly = true;
            this.dgv_AvailableIssues.RowHeadersVisible = false;
            this.dgv_AvailableIssues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_AvailableIssues.Size = new System.Drawing.Size(770, 310);
            this.dgv_AvailableIssues.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1111, 3);
            this.groupBox3.Name = "groupBox3";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox3, 2);
            this.groupBox3.Size = new System.Drawing.Size(234, 643);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Feature Builds";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FB,
            this.StartDate,
            this.EndDate,
            this.FZ01,
            this.FZ02});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 17);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(228, 623);
            this.dataGridView2.TabIndex = 0;
            // 
            // FB
            // 
            this.FB.DataPropertyName = "FB";
            this.FB.HeaderText = "FB";
            this.FB.Name = "FB";
            this.FB.ReadOnly = true;
            this.FB.Width = 50;
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "StartDate";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Width = 60;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "EndDate";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            this.EndDate.Width = 60;
            // 
            // FZ01
            // 
            this.FZ01.DataPropertyName = "FZ01";
            this.FZ01.HeaderText = "FZ01";
            this.FZ01.Name = "FZ01";
            this.FZ01.ReadOnly = true;
            this.FZ01.Width = 40;
            // 
            // FZ02
            // 
            this.FZ02.DataPropertyName = "FZ02";
            this.FZ02.HeaderText = "FZ02";
            this.FZ02.Name = "FZ02";
            this.FZ02.ReadOnly = true;
            this.FZ02.Width = 40;
            // 
            // tp_config
            // 
            this.tp_config.Controls.Add(this.groupBox6);
            this.tp_config.Controls.Add(this.groupBox5);
            this.tp_config.Location = new System.Drawing.Point(4, 22);
            this.tp_config.Name = "tp_config";
            this.tp_config.Padding = new System.Windows.Forms.Padding(3);
            this.tp_config.Size = new System.Drawing.Size(1354, 716);
            this.tp_config.TabIndex = 1;
            this.tp_config.Text = "Configuration";
            this.tp_config.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnRestApiConfigCancel);
            this.groupBox6.Controls.Add(this.btnRestApiConfigApply);
            this.groupBox6.Controls.Add(this.btnTestConn);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.txtUserPassword);
            this.groupBox6.Controls.Add(this.txtUserName);
            this.groupBox6.Controls.Add(this.txtRestApiPath);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Location = new System.Drawing.Point(8, 118);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(637, 161);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "REST API Configuration";
            // 
            // btnRestApiConfigCancel
            // 
            this.btnRestApiConfigCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRestApiConfigCancel.Enabled = false;
            this.btnRestApiConfigCancel.Location = new System.Drawing.Point(539, 120);
            this.btnRestApiConfigCancel.Name = "btnRestApiConfigCancel";
            this.btnRestApiConfigCancel.Size = new System.Drawing.Size(75, 25);
            this.btnRestApiConfigCancel.TabIndex = 17;
            this.btnRestApiConfigCancel.Text = "Cancel";
            this.btnRestApiConfigCancel.UseVisualStyleBackColor = true;
            this.btnRestApiConfigCancel.Click += new System.EventHandler(this.btnRestApiConfigCancel_Click);
            // 
            // btnRestApiConfigApply
            // 
            this.btnRestApiConfigApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRestApiConfigApply.Enabled = false;
            this.btnRestApiConfigApply.Location = new System.Drawing.Point(458, 120);
            this.btnRestApiConfigApply.Name = "btnRestApiConfigApply";
            this.btnRestApiConfigApply.Size = new System.Drawing.Size(75, 25);
            this.btnRestApiConfigApply.TabIndex = 16;
            this.btnRestApiConfigApply.Text = "Apply";
            this.btnRestApiConfigApply.UseVisualStyleBackColor = true;
            this.btnRestApiConfigApply.Click += new System.EventHandler(this.btnRestApiConfigApply_Click);
            // 
            // btnTestConn
            // 
            this.btnTestConn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTestConn.Location = new System.Drawing.Point(458, 28);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(156, 25);
            this.btnTestConn.TabIndex = 15;
            this.btnTestConn.Text = "Test Connection";
            this.btnTestConn.UseVisualStyleBackColor = true;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "REST API Path";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Password";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(106, 86);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(241, 20);
            this.txtUserPassword.TabIndex = 13;
            this.txtUserPassword.TextChanged += new System.EventHandler(this.RestAPIConfig_Changed);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(106, 60);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(241, 20);
            this.txtUserName.TabIndex = 11;
            this.txtUserName.TextChanged += new System.EventHandler(this.RestAPIConfig_Changed);
            // 
            // txtRestApiPath
            // 
            this.txtRestApiPath.Location = new System.Drawing.Point(106, 33);
            this.txtRestApiPath.Name = "txtRestApiPath";
            this.txtRestApiPath.Size = new System.Drawing.Size(241, 20);
            this.txtRestApiPath.TabIndex = 7;
            this.txtRestApiPath.TextChanged += new System.EventHandler(this.RestAPIConfig_Changed);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "User ID";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkRunOnStart);
            this.groupBox5.Controls.Add(this.chkAutoRun);
            this.groupBox5.Controls.Add(this.btnRunConfigCancel);
            this.groupBox5.Controls.Add(this.btnRunConfigApply);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtInterval);
            this.groupBox5.Location = new System.Drawing.Point(8, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(637, 106);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Run Configuration";
            // 
            // chkRunOnStart
            // 
            this.chkRunOnStart.AutoSize = true;
            this.chkRunOnStart.Location = new System.Drawing.Point(356, 28);
            this.chkRunOnStart.Name = "chkRunOnStart";
            this.chkRunOnStart.Size = new System.Drawing.Size(86, 17);
            this.chkRunOnStart.TabIndex = 6;
            this.chkRunOnStart.Text = "Run on Start";
            this.chkRunOnStart.UseVisualStyleBackColor = true;
            this.chkRunOnStart.CheckedChanged += new System.EventHandler(this.RunConfig_Changed);
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.Location = new System.Drawing.Point(258, 28);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(71, 17);
            this.chkAutoRun.TabIndex = 5;
            this.chkAutoRun.Text = "Auto Run";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            this.chkAutoRun.CheckedChanged += new System.EventHandler(this.RunConfig_Changed);
            // 
            // btnRunConfigCancel
            // 
            this.btnRunConfigCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRunConfigCancel.Enabled = false;
            this.btnRunConfigCancel.Location = new System.Drawing.Point(539, 69);
            this.btnRunConfigCancel.Name = "btnRunConfigCancel";
            this.btnRunConfigCancel.Size = new System.Drawing.Size(75, 25);
            this.btnRunConfigCancel.TabIndex = 4;
            this.btnRunConfigCancel.Text = "Cancel";
            this.btnRunConfigCancel.UseVisualStyleBackColor = true;
            this.btnRunConfigCancel.Click += new System.EventHandler(this.btnRunConfigCancel_Click);
            // 
            // btnRunConfigApply
            // 
            this.btnRunConfigApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRunConfigApply.Enabled = false;
            this.btnRunConfigApply.Location = new System.Drawing.Point(458, 69);
            this.btnRunConfigApply.Name = "btnRunConfigApply";
            this.btnRunConfigApply.Size = new System.Drawing.Size(75, 25);
            this.btnRunConfigApply.TabIndex = 3;
            this.btnRunConfigApply.Text = "Apply";
            this.btnRunConfigApply.UseVisualStyleBackColor = true;
            this.btnRunConfigApply.Click += new System.EventHandler(this.btnRunConfigApply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "MIN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pre-plan Interval";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(106, 26);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(100, 20);
            this.txtInterval.TabIndex = 0;
            this.txtInterval.TextChanged += new System.EventHandler(this.RunConfig_Changed);
            // 
            // errProviderConfig
            // 
            this.errProviderConfig.ContainerControl = this;
            // 
            // timer1Sec
            // 
            this.timer1Sec.Interval = 1000;
            this.timer1Sec.Tick += new System.EventHandler(this.timer1Sec_Tick);
            // 
            // dgv_UntouchableIssues
            // 
            this.dgv_UntouchableIssues.AllowUserToAddRows = false;
            this.dgv_UntouchableIssues.AllowUserToDeleteRows = false;
            this.dgv_UntouchableIssues.AllowUserToOrderColumns = true;
            this.dgv_UntouchableIssues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_UntouchableIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_UntouchableIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_UntouchableIssues.Location = new System.Drawing.Point(3, 17);
            this.dgv_UntouchableIssues.Name = "dgv_UntouchableIssues";
            this.dgv_UntouchableIssues.ReadOnly = true;
            this.dgv_UntouchableIssues.RowHeadersVisible = false;
            this.dgv_UntouchableIssues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_UntouchableIssues.Size = new System.Drawing.Size(770, 287);
            this.dgv_UntouchableIssues.TabIndex = 1;
            // 
            // FM_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 742);
            this.Controls.Add(this.tabControl1);
            this.Name = "FM_Main";
            this.Text = "Fusion Pre-Planer";
            this.Load += new System.EventHandler(this.FM_Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tp_main.ResumeLayout(false);
            this.tp_main.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_STO)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AvailableIssues)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tp_config.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UntouchableIssues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_main;
        private System.Windows.Forms.TabPage tp_config;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_STO;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_AvailableIssues;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckBox chkSelectAllSTO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_STO;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Squad;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_CA;
        private System.Windows.Forms.DataGridViewButtonColumn col_Preplan;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_runstat;
        private System.Windows.Forms.Button btnRunAll;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Button btnRunConfigCancel;
        private System.Windows.Forms.Button btnRunConfigApply;
        private System.Windows.Forms.ErrorProvider errProviderConfig;
        private System.Windows.Forms.TextBox txtNextRunDt;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.CheckBox chkRunOnStart;
        private System.Windows.Forms.Timer timer1Sec;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCountDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtRestApiPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRestApiConfigCancel;
        private System.Windows.Forms.Button btnRestApiConfigApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn FB;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FZ01;
        private System.Windows.Forms.DataGridViewTextBoxColumn FZ02;
        private System.Windows.Forms.DataGridView dgv_UntouchableIssues;
    }
}

