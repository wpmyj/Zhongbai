namespace DasherStation.storage
{
    partial class FrmStockInR
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_state = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_checkup = new System.Windows.Forms.Button();
            this.btn_assess = new System.Windows.Forms.Button();
            this.btn_print_out = new System.Windows.Forms.Button();
            this.chkEnd = new System.Windows.Forms.CheckBox();
            this.chkBegin = new System.Windows.Forms.CheckBox();
            this.cbxKind = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxTransport = new System.Windows.Forms.ComboBox();
            this.cbxProvider = new System.Windows.Forms.ComboBox();
            this.cbxVoiture = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblP2 = new System.Windows.Forms.Label();
            this.lblP1 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.cbxName = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvStockIn = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvStorageOut = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAssess = new System.Windows.Forms.Button();
            this.btnCheckup = new System.Windows.Forms.Button();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.checkEnd = new System.Windows.Forms.CheckBox();
            this.checkBegin = new System.Windows.Forms.CheckBox();
            this.btn_print = new System.Windows.Forms.Button();
            this.cbxmKind = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxEquipment = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOutQuery = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxmModel = new System.Windows.Forms.ComboBox();
            this.cbxmName = new System.Windows.Forms.ComboBox();
            this.dtpEndO = new System.Windows.Forms.DateTimePicker();
            this.dtpBegionO = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIn)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorageOut)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbx_state);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.btn_checkup);
            this.groupBox1.Controls.Add(this.btn_assess);
            this.groupBox1.Controls.Add(this.btn_print_out);
            this.groupBox1.Controls.Add(this.chkEnd);
            this.groupBox1.Controls.Add(this.chkBegin);
            this.groupBox1.Controls.Add(this.cbxKind);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbxTransport);
            this.groupBox1.Controls.Add(this.cbxProvider);
            this.groupBox1.Controls.Add(this.cbxVoiture);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblP2);
            this.groupBox1.Controls.Add(this.lblP1);
            this.groupBox1.Controls.Add(this.cbxType);
            this.groupBox1.Controls.Add(this.cbxName);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(789, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbx_state
            // 
            this.cbx_state.FormattingEnabled = true;
            this.cbx_state.Items.AddRange(new object[] {
            "全部",
            "已审核",
            "已审批",
            "未审核、审批"});
            this.cbx_state.Location = new System.Drawing.Point(88, 101);
            this.cbx_state.Name = "cbx_state";
            this.cbx_state.Size = new System.Drawing.Size(128, 20);
            this.cbx_state.TabIndex = 39;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 38;
            this.label14.Text = "状态";
            // 
            // btn_checkup
            // 
            this.btn_checkup.Location = new System.Drawing.Point(572, 99);
            this.btn_checkup.Name = "btn_checkup";
            this.btn_checkup.Size = new System.Drawing.Size(75, 23);
            this.btn_checkup.TabIndex = 26;
            this.btn_checkup.Text = "审批";
            this.btn_checkup.UseVisualStyleBackColor = true;
            this.btn_checkup.Click += new System.EventHandler(this.btn_checkup_Click);
            // 
            // btn_assess
            // 
            this.btn_assess.Location = new System.Drawing.Point(480, 98);
            this.btn_assess.Name = "btn_assess";
            this.btn_assess.Size = new System.Drawing.Size(75, 23);
            this.btn_assess.TabIndex = 25;
            this.btn_assess.Text = "审核";
            this.btn_assess.UseVisualStyleBackColor = true;
            this.btn_assess.Click += new System.EventHandler(this.btn_assess_Click);
            // 
            // btn_print_out
            // 
            this.btn_print_out.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_print_out.Location = new System.Drawing.Point(665, 99);
            this.btn_print_out.Name = "btn_print_out";
            this.btn_print_out.Size = new System.Drawing.Size(75, 23);
            this.btn_print_out.TabIndex = 24;
            this.btn_print_out.Text = "打印";
            this.btn_print_out.UseVisualStyleBackColor = true;
            this.btn_print_out.Click += new System.EventHandler(this.btn_print_out_Click);
            // 
            // chkEnd
            // 
            this.chkEnd.AutoSize = true;
            this.chkEnd.Location = new System.Drawing.Point(343, 74);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(15, 14);
            this.chkEnd.TabIndex = 23;
            this.chkEnd.UseVisualStyleBackColor = true;
            this.chkEnd.CheckedChanged += new System.EventHandler(this.chkEnd_CheckedChanged);
            // 
            // chkBegin
            // 
            this.chkBegin.AutoSize = true;
            this.chkBegin.Location = new System.Drawing.Point(88, 75);
            this.chkBegin.Name = "chkBegin";
            this.chkBegin.Size = new System.Drawing.Size(15, 14);
            this.chkBegin.TabIndex = 2;
            this.chkBegin.UseVisualStyleBackColor = true;
            this.chkBegin.CheckedChanged += new System.EventHandler(this.chkBegin_CheckedChanged);
            // 
            // cbxKind
            // 
            this.cbxKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKind.FormattingEnabled = true;
            this.cbxKind.Location = new System.Drawing.Point(86, 15);
            this.cbxKind.Name = "cbxKind";
            this.cbxKind.Size = new System.Drawing.Size(128, 20);
            this.cbxKind.TabIndex = 22;
            this.cbxKind.SelectionChangeCommitted += new System.EventHandler(this.cbxKind_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "材料种类";
            // 
            // cbxTransport
            // 
            this.cbxTransport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTransport.FormattingEnabled = true;
            this.cbxTransport.Location = new System.Drawing.Point(346, 43);
            this.cbxTransport.Name = "cbxTransport";
            this.cbxTransport.Size = new System.Drawing.Size(128, 20);
            this.cbxTransport.TabIndex = 20;
            // 
            // cbxProvider
            // 
            this.cbxProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProvider.FormattingEnabled = true;
            this.cbxProvider.Location = new System.Drawing.Point(86, 43);
            this.cbxProvider.Name = "cbxProvider";
            this.cbxProvider.Size = new System.Drawing.Size(128, 20);
            this.cbxProvider.TabIndex = 19;
            // 
            // cbxVoiture
            // 
            this.cbxVoiture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVoiture.FormattingEnabled = true;
            this.cbxVoiture.Location = new System.Drawing.Point(612, 43);
            this.cbxVoiture.Name = "cbxVoiture";
            this.cbxVoiture.Size = new System.Drawing.Size(128, 20);
            this.cbxVoiture.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(540, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "车牌号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "运输单位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "供应商";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "时间";
            // 
            // lblP2
            // 
            this.lblP2.AutoSize = true;
            this.lblP2.Location = new System.Drawing.Point(540, 19);
            this.lblP2.Name = "lblP2";
            this.lblP2.Size = new System.Drawing.Size(53, 12);
            this.lblP2.TabIndex = 12;
            this.lblP2.Text = "材料型号";
            // 
            // lblP1
            // 
            this.lblP1.AutoSize = true;
            this.lblP1.Location = new System.Drawing.Point(275, 19);
            this.lblP1.Name = "lblP1";
            this.lblP1.Size = new System.Drawing.Size(53, 12);
            this.lblP1.TabIndex = 11;
            this.lblP1.Text = "材料名称";
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(612, 16);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(128, 20);
            this.cbxType.TabIndex = 9;
            // 
            // cbxName
            // 
            this.cbxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxName.FormattingEnabled = true;
            this.cbxName.Location = new System.Drawing.Point(346, 15);
            this.cbxName.Name = "cbxName";
            this.cbxName.Size = new System.Drawing.Size(128, 20);
            this.cbxName.TabIndex = 8;
            this.cbxName.SelectionChangeCommitted += new System.EventHandler(this.cbxName_SelectionChangeCommitted);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Location = new System.Drawing.Point(364, 71);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(110, 21);
            this.dtpEnd.TabIndex = 7;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Enabled = false;
            this.dtpBegin.Location = new System.Drawing.Point(105, 72);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.ShowUpDown = true;
            this.dtpBegin.Size = new System.Drawing.Size(110, 21);
            this.dtpBegin.TabIndex = 6;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(665, 69);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 131);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(789, 434);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvStockIn);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(781, 409);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "入库台帐";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvStockIn
            // 
            this.dgvStockIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStockIn.BackgroundColor = System.Drawing.Color.White;
            this.dgvStockIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockIn.Location = new System.Drawing.Point(2, 4);
            this.dgvStockIn.Name = "dgvStockIn";
            this.dgvStockIn.RowTemplate.Height = 23;
            this.dgvStockIn.Size = new System.Drawing.Size(775, 403);
            this.dgvStockIn.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvStorageOut);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(781, 409);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "出库台帐";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvStorageOut
            // 
            this.dgvStorageOut.BackgroundColor = System.Drawing.Color.White;
            this.dgvStorageOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStorageOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStorageOut.Location = new System.Drawing.Point(3, 3);
            this.dgvStorageOut.Name = "dgvStorageOut";
            this.dgvStorageOut.RowTemplate.Height = 23;
            this.dgvStorageOut.Size = new System.Drawing.Size(775, 403);
            this.dgvStorageOut.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnAssess);
            this.groupBox2.Controls.Add(this.btnCheckup);
            this.groupBox2.Controls.Add(this.cbxState);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.checkEnd);
            this.groupBox2.Controls.Add(this.checkBegin);
            this.groupBox2.Controls.Add(this.btn_print);
            this.groupBox2.Controls.Add(this.cbxmKind);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbxEquipment);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnOutQuery);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cbxmModel);
            this.groupBox2.Controls.Add(this.cbxmName);
            this.groupBox2.Controls.Add(this.dtpEndO);
            this.groupBox2.Controls.Add(this.dtpBegionO);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(794, 127);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // btnAssess
            // 
            this.btnAssess.Location = new System.Drawing.Point(424, 84);
            this.btnAssess.Name = "btnAssess";
            this.btnAssess.Size = new System.Drawing.Size(75, 23);
            this.btnAssess.TabIndex = 39;
            this.btnAssess.Text = "审核";
            this.btnAssess.UseVisualStyleBackColor = true;
            this.btnAssess.Click += new System.EventHandler(this.btnAssess_Click);
            // 
            // btnCheckup
            // 
            this.btnCheckup.Location = new System.Drawing.Point(543, 84);
            this.btnCheckup.Name = "btnCheckup";
            this.btnCheckup.Size = new System.Drawing.Size(75, 23);
            this.btnCheckup.TabIndex = 38;
            this.btnCheckup.Text = "审批";
            this.btnCheckup.UseVisualStyleBackColor = true;
            this.btnCheckup.Click += new System.EventHandler(this.btnCheckup_Click);
            // 
            // cbxState
            // 
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Items.AddRange(new object[] {
            "全部",
            "已审核",
            "已审批",
            "未审核、审批"});
            this.cbxState.Location = new System.Drawing.Point(87, 99);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(128, 20);
            this.cbxState.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 36;
            this.label12.Text = "状态";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(303, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 35;
            this.button4.Text = "手工出库";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkEnd
            // 
            this.checkEnd.AutoSize = true;
            this.checkEnd.Location = new System.Drawing.Point(345, 46);
            this.checkEnd.Name = "checkEnd";
            this.checkEnd.Size = new System.Drawing.Size(15, 14);
            this.checkEnd.TabIndex = 34;
            this.checkEnd.UseVisualStyleBackColor = true;
            this.checkEnd.CheckedChanged += new System.EventHandler(this.checkEnd_CheckedChanged);
            // 
            // checkBegin
            // 
            this.checkBegin.AutoSize = true;
            this.checkBegin.Location = new System.Drawing.Point(86, 46);
            this.checkBegin.Name = "checkBegin";
            this.checkBegin.Size = new System.Drawing.Size(15, 14);
            this.checkBegin.TabIndex = 33;
            this.checkBegin.UseVisualStyleBackColor = true;
            this.checkBegin.CheckedChanged += new System.EventHandler(this.checkBegin_CheckedChanged);
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_print.Location = new System.Drawing.Point(665, 84);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 32;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            // 
            // cbxmKind
            // 
            this.cbxmKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxmKind.FormattingEnabled = true;
            this.cbxmKind.Location = new System.Drawing.Point(87, 15);
            this.cbxmKind.Name = "cbxmKind";
            this.cbxmKind.Size = new System.Drawing.Size(128, 20);
            this.cbxmKind.TabIndex = 31;
            this.cbxmKind.SelectionChangeCommitted += new System.EventHandler(this.cbxmKind_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "材料种类";
            // 
            // cbxEquipment
            // 
            this.cbxEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEquipment.FormattingEnabled = true;
            this.cbxEquipment.Location = new System.Drawing.Point(87, 73);
            this.cbxEquipment.Name = "cbxEquipment";
            this.cbxEquipment.Size = new System.Drawing.Size(128, 20);
            this.cbxEquipment.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 28;
            this.label13.Text = "设备编号";
            // 
            // btnOutQuery
            // 
            this.btnOutQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutQuery.Location = new System.Drawing.Point(665, 47);
            this.btnOutQuery.Name = "btnOutQuery";
            this.btnOutQuery.Size = new System.Drawing.Size(75, 23);
            this.btnOutQuery.TabIndex = 27;
            this.btnOutQuery.Text = "查询";
            this.btnOutQuery.UseVisualStyleBackColor = true;
            this.btnOutQuery.Click += new System.EventHandler(this.btnOutQuery_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(275, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "--";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "时间";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(540, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "材料型号";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(275, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "材料名称";
            // 
            // cbxmModel
            // 
            this.cbxmModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxmModel.FormattingEnabled = true;
            this.cbxmModel.Location = new System.Drawing.Point(612, 16);
            this.cbxmModel.Name = "cbxmModel";
            this.cbxmModel.Size = new System.Drawing.Size(128, 20);
            this.cbxmModel.TabIndex = 20;
            // 
            // cbxmName
            // 
            this.cbxmName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxmName.FormattingEnabled = true;
            this.cbxmName.Location = new System.Drawing.Point(346, 15);
            this.cbxmName.Name = "cbxmName";
            this.cbxmName.Size = new System.Drawing.Size(128, 20);
            this.cbxmName.TabIndex = 19;
            this.cbxmName.SelectionChangeCommitted += new System.EventHandler(this.cbxmName_SelectionChangeCommitted);
            // 
            // dtpEndO
            // 
            this.dtpEndO.Enabled = false;
            this.dtpEndO.Location = new System.Drawing.Point(364, 43);
            this.dtpEndO.Name = "dtpEndO";
            this.dtpEndO.ShowUpDown = true;
            this.dtpEndO.Size = new System.Drawing.Size(110, 21);
            this.dtpEndO.TabIndex = 18;
            // 
            // dtpBegionO
            // 
            this.dtpBegionO.Enabled = false;
            this.dtpBegionO.Location = new System.Drawing.Point(105, 43);
            this.dtpBegionO.Name = "dtpBegionO";
            this.dtpBegionO.ShowUpDown = true;
            this.dtpBegionO.Size = new System.Drawing.Size(110, 21);
            this.dtpBegionO.TabIndex = 17;
            // 
            // FrmStockInR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmStockInR";
            this.Tag = "FrmStockInR";
            this.Text = "材料台帐";
            this.Load += new System.EventHandler(this.FrmStockInR_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIn)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorageOut)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label lblP2;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.ComboBox cbxName;
        private System.Windows.Forms.DataGridView dgvStockIn;
        private System.Windows.Forms.DataGridView dgvStorageOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxVoiture;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxEquipment;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnOutQuery;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxmModel;
        private System.Windows.Forms.ComboBox cbxmName;
        private System.Windows.Forms.DateTimePicker dtpEndO;
        private System.Windows.Forms.DateTimePicker dtpBegionO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxTransport;
        private System.Windows.Forms.ComboBox cbxProvider;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.ComboBox cbxmKind;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxKind;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkEnd;
        private System.Windows.Forms.CheckBox chkBegin;
        private System.Windows.Forms.Button btn_print_out;
        private System.Windows.Forms.CheckBox checkEnd;
        private System.Windows.Forms.CheckBox checkBegin;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAssess;
        private System.Windows.Forms.Button btnCheckup;
        private System.Windows.Forms.Button btn_checkup;
        private System.Windows.Forms.Button btn_assess;
        private System.Windows.Forms.ComboBox cbx_state;
        private System.Windows.Forms.Label label14;
    }
}