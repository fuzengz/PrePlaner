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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_STO = new System.Windows.Forms.DataGridView();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_STO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Squad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_CA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Preplan = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_runstat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCountDown = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSelectAllSTO = new System.Windows.Forms.CheckBox();
            this.btnRunAll = new System.Windows.Forms.Button();
            this.txtNextRunDt = new System.Windows.Forms.TextBox();
            this.tp_config = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkRunOnStart = new System.Windows.Forms.CheckBox();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.errProviderConfig = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1Sec = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tp_main.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_STO)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tp_config.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderConfig)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(1194, 802);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_main
            // 
            this.tp_main.Controls.Add(this.statusStrip1);
            this.tp_main.Controls.Add(this.tableLayoutPanel1);
            this.tp_main.Location = new System.Drawing.Point(4, 22);
            this.tp_main.Name = "tp_main";
            this.tp_main.Padding = new System.Windows.Forms.Padding(3);
            this.tp_main.Size = new System.Drawing.Size(1186, 776);
            this.tp_main.TabIndex = 0;
            this.tp_main.Text = "Main";
            this.tp_main.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(3, 751);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1180, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.80851F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.46809F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.68539F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1175, 742);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(318, 499);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(540, 179);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Untouchable ITEMS";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToOrderColumns = true;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(3, 16);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(534, 160);
            this.dataGridView3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_STO);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 2);
            this.groupBox1.Size = new System.Drawing.Size(309, 675);
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
            this.dgv_STO.Location = new System.Drawing.Point(3, 16);
            this.dgv_STO.MultiSelect = false;
            this.dgv_STO.Name = "dgv_STO";
            this.dgv_STO.RowHeadersVisible = false;
            this.dgv_STO.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_STO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_STO.Size = new System.Drawing.Size(303, 656);
            this.dgv_STO.TabIndex = 0;
            this.dgv_STO.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_STO_CellContentClick);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(864, 3);
            this.groupBox3.Name = "groupBox3";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox3, 2);
            this.groupBox3.Size = new System.Drawing.Size(308, 675);
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
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 16);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(302, 656);
            this.dataGridView2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(318, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 490);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available ITEMS";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(534, 471);
            this.dataGridView1.TabIndex = 0;
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
            this.panel1.Location = new System.Drawing.Point(3, 684);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(855, 55);
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
            // tp_config
            // 
            this.tp_config.Controls.Add(this.groupBox5);
            this.tp_config.Location = new System.Drawing.Point(4, 22);
            this.tp_config.Name = "tp_config";
            this.tp_config.Padding = new System.Windows.Forms.Padding(3);
            this.tp_config.Size = new System.Drawing.Size(1189, 640);
            this.tp_config.TabIndex = 1;
            this.tp_config.Text = "Configuration";
            this.tp_config.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkRunOnStart);
            this.groupBox5.Controls.Add(this.chkAutoRun);
            this.groupBox5.Controls.Add(this.btnCancel);
            this.groupBox5.Controls.Add(this.btnApply);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtInterval);
            this.groupBox5.Location = new System.Drawing.Point(8, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(630, 143);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Configuration Parameters";
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
            this.chkRunOnStart.CheckedChanged += new System.EventHandler(this.Config_Changed);
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
            this.chkAutoRun.CheckedChanged += new System.EventHandler(this.Config_Changed);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(529, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(448, 97);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 25);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
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
            this.txtInterval.TextChanged += new System.EventHandler(this.Config_Changed);
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
            // FM_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 802);
            this.Controls.Add(this.tabControl1);
            this.Name = "FM_Main";
            this.Text = "Fusion Pre-Planer";
            this.Load += new System.EventHandler(this.FM_Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tp_main.ResumeLayout(false);
            this.tp_main.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_STO)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tp_config.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderConfig)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView3;
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
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ErrorProvider errProviderConfig;
        private System.Windows.Forms.TextBox txtNextRunDt;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.CheckBox chkRunOnStart;
        private System.Windows.Forms.Timer timer1Sec;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCountDown;
        private System.Windows.Forms.Label label3;
    }
}

