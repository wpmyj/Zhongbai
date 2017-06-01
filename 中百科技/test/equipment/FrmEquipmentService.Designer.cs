namespace DasherStation.equipment
{
    partial class FrmEquipmentService
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQueryStr = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cbxQuery = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtExpenses = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtFNO = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTestResult = new System.Windows.Forms.TextBox();
            this.txtAttemptRunExplain = new System.Windows.Forms.TextBox();
            this.txtChangeAccessory = new System.Windows.Forms.TextBox();
            this.txtServiceExplain = new System.Windows.Forms.TextBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.dtpFinishDate = new System.Windows.Forms.DateTimePicker();
            this.dtpServiceDate = new System.Windows.Forms.DateTimePicker();
            this.cbxRSort = new System.Windows.Forms.ComboBox();
            this.cbxENO = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expenses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeConsuming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceExplain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeAccessory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attemptRunExplain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dasherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Print = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtQueryStr);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.cbxQuery);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtQueryStr
            // 
            this.txtQueryStr.Location = new System.Drawing.Point(209, 18);
            this.txtQueryStr.Name = "txtQueryStr";
            this.txtQueryStr.Size = new System.Drawing.Size(121, 21);
            this.txtQueryStr.TabIndex = 25;
            this.txtQueryStr.Tag = "E";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(773, 18);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 24;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cbxQuery
            // 
            this.cbxQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuery.FormattingEnabled = true;
            this.cbxQuery.Items.AddRange(new object[] {
            "设备编号",
            "设备类别",
            "设备名称",
            "规格型号"});
            this.cbxQuery.Location = new System.Drawing.Point(82, 18);
            this.cbxQuery.Name = "cbxQuery";
            this.cbxQuery.Size = new System.Drawing.Size(121, 20);
            this.cbxQuery.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "查询条件";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtTime);
            this.groupBox2.Controls.Add(this.txtExpenses);
            this.groupBox2.Controls.Add(this.txtModel);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtSort);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.txtFNO);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtTestResult);
            this.groupBox2.Controls.Add(this.txtAttemptRunExplain);
            this.groupBox2.Controls.Add(this.txtChangeAccessory);
            this.groupBox2.Controls.Add(this.txtServiceExplain);
            this.groupBox2.Controls.Add(this.txtInterval);
            this.groupBox2.Controls.Add(this.dtpFinishDate);
            this.groupBox2.Controls.Add(this.dtpServiceDate);
            this.groupBox2.Controls.Add(this.cbxRSort);
            this.groupBox2.Controls.Add(this.cbxENO);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(4, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(875, 281);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设备维修保养信息";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(536, 48);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(121, 21);
            this.txtTime.TabIndex = 45;
            this.txtTime.Tag = "ES";
            // 
            // txtExpenses
            // 
            this.txtExpenses.Location = new System.Drawing.Point(92, 47);
            this.txtExpenses.Name = "txtExpenses";
            this.txtExpenses.Size = new System.Drawing.Size(121, 21);
            this.txtExpenses.TabIndex = 26;
            this.txtExpenses.Tag = "EF";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(735, 16);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(121, 21);
            this.txtModel.TabIndex = 44;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(536, 17);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(121, 21);
            this.txtName.TabIndex = 43;
            // 
            // txtSort
            // 
            this.txtSort.Location = new System.Drawing.Point(311, 18);
            this.txtSort.Name = "txtSort";
            this.txtSort.ReadOnly = true;
            this.txtSort.Size = new System.Drawing.Size(121, 21);
            this.txtSort.TabIndex = 42;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(627, 249);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 41;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(773, 249);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtFNO
            // 
            this.txtFNO.Location = new System.Drawing.Point(735, 81);
            this.txtFNO.Name = "txtFNO";
            this.txtFNO.Size = new System.Drawing.Size(121, 21);
            this.txtFNO.TabIndex = 38;
            this.txtFNO.Tag = "";
            this.txtFNO.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(671, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 37;
            this.label16.Text = "文档编号";
            this.label16.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "维修保养费用";
            // 
            // txtTestResult
            // 
            this.txtTestResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTestResult.Location = new System.Drawing.Point(438, 197);
            this.txtTestResult.Multiline = true;
            this.txtTestResult.Name = "txtTestResult";
            this.txtTestResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTestResult.Size = new System.Drawing.Size(412, 42);
            this.txtTestResult.TabIndex = 36;
            this.txtTestResult.Tag = "ES";
            // 
            // txtAttemptRunExplain
            // 
            this.txtAttemptRunExplain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAttemptRunExplain.Location = new System.Drawing.Point(26, 197);
            this.txtAttemptRunExplain.Multiline = true;
            this.txtAttemptRunExplain.Name = "txtAttemptRunExplain";
            this.txtAttemptRunExplain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAttemptRunExplain.Size = new System.Drawing.Size(412, 42);
            this.txtAttemptRunExplain.TabIndex = 35;
            this.txtAttemptRunExplain.Tag = "ES";
            // 
            // txtChangeAccessory
            // 
            this.txtChangeAccessory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChangeAccessory.Location = new System.Drawing.Point(438, 134);
            this.txtChangeAccessory.Multiline = true;
            this.txtChangeAccessory.Name = "txtChangeAccessory";
            this.txtChangeAccessory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChangeAccessory.Size = new System.Drawing.Size(412, 42);
            this.txtChangeAccessory.TabIndex = 34;
            this.txtChangeAccessory.Tag = "ES";
            // 
            // txtServiceExplain
            // 
            this.txtServiceExplain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServiceExplain.Location = new System.Drawing.Point(26, 134);
            this.txtServiceExplain.Multiline = true;
            this.txtServiceExplain.Name = "txtServiceExplain";
            this.txtServiceExplain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServiceExplain.Size = new System.Drawing.Size(412, 42);
            this.txtServiceExplain.TabIndex = 28;
            this.txtServiceExplain.Tag = "ES";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(536, 81);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(121, 21);
            this.txtInterval.TabIndex = 27;
            this.txtInterval.Tag = "ES";
            // 
            // dtpFinishDate
            // 
            this.dtpFinishDate.Location = new System.Drawing.Point(92, 81);
            this.dtpFinishDate.Name = "dtpFinishDate";
            this.dtpFinishDate.Size = new System.Drawing.Size(121, 21);
            this.dtpFinishDate.TabIndex = 24;
            this.dtpFinishDate.Tag = "E";
            // 
            // dtpServiceDate
            // 
            this.dtpServiceDate.Location = new System.Drawing.Point(735, 47);
            this.dtpServiceDate.Name = "dtpServiceDate";
            this.dtpServiceDate.Size = new System.Drawing.Size(121, 21);
            this.dtpServiceDate.TabIndex = 23;
            this.dtpServiceDate.Tag = "E";
            // 
            // cbxRSort
            // 
            this.cbxRSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRSort.FormattingEnabled = true;
            this.cbxRSort.Items.AddRange(new object[] {
            "日常维修",
            "小修",
            "中修",
            "大修"});
            this.cbxRSort.Location = new System.Drawing.Point(312, 48);
            this.cbxRSort.Name = "cbxRSort";
            this.cbxRSort.Size = new System.Drawing.Size(121, 20);
            this.cbxRSort.TabIndex = 20;
            this.cbxRSort.Tag = "E";
            // 
            // cbxENO
            // 
            this.cbxENO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxENO.FormattingEnabled = true;
            this.cbxENO.Location = new System.Drawing.Point(92, 17);
            this.cbxENO.Name = "cbxENO";
            this.cbxENO.Size = new System.Drawing.Size(121, 20);
            this.cbxENO.TabIndex = 16;
            this.cbxENO.Tag = "E";
            this.cbxENO.SelectionChangeCommitted += new System.EventHandler(this.cbxENO_SelectionChangeCommitted);
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(438, 176);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(412, 21);
            this.label15.TabIndex = 13;
            this.label15.Text = "检验结论意见";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(26, 176);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(413, 21);
            this.label14.TabIndex = 12;
            this.label14.Text = "试运转情况说明";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(438, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(412, 21);
            this.label13.TabIndex = 11;
            this.label13.Text = "更换主要配件";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(26, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(413, 21);
            this.label12.TabIndex = 10;
            this.label12.Text = "维修保养项目说明";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(229, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(293, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "本次维修保养距上次维修保养实际作业小时或间隔里程";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "完竣日期";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(671, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "送修日期";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(453, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "维修保养工时";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "维修保养类别";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(671, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "规格型号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "设备名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "设备类别";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "设备编号";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(777, 619);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dgvDetail);
            this.groupBox3.Location = new System.Drawing.Point(4, 342);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(875, 268);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "设备维修保养记录";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.sort,
            this.name,
            this.model,
            this.expenses,
            this.serviceKind,
            this.timeConsuming,
            this.serviceDate,
            this.finishDate,
            this.interval,
            this.fno,
            this.serviceExplain,
            this.changeAccessory,
            this.attemptRunExplain,
            this.testResult,
            this.inputDate,
            this.dasherName,
            this.inputMan});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.Name = "dgvDetail";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetail.RowHeadersWidth = 10;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(869, 248);
            this.dgvDetail.TabIndex = 0;
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            this.no.FillWeight = 226.7002F;
            this.no.HeaderText = "设备编号";
            this.no.Name = "no";
            this.no.Width = 78;
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.FillWeight = 200.0157F;
            this.sort.HeaderText = "设备类别";
            this.sort.Name = "sort";
            this.sort.Width = 78;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.FillWeight = 176.692F;
            this.name.HeaderText = "设备名称";
            this.name.Name = "name";
            this.name.Width = 78;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.FillWeight = 156.3058F;
            this.model.HeaderText = "规格型号";
            this.model.Name = "model";
            this.model.Width = 78;
            // 
            // expenses
            // 
            this.expenses.DataPropertyName = "expenses";
            this.expenses.FillWeight = 138.4871F;
            this.expenses.HeaderText = "维修保养费用";
            this.expenses.Name = "expenses";
            this.expenses.Width = 102;
            // 
            // serviceKind
            // 
            this.serviceKind.DataPropertyName = "serviceKind";
            this.serviceKind.FillWeight = 122.9125F;
            this.serviceKind.HeaderText = "维修保养类别";
            this.serviceKind.Name = "serviceKind";
            this.serviceKind.Width = 102;
            // 
            // timeConsuming
            // 
            this.timeConsuming.DataPropertyName = "timeConsuming";
            this.timeConsuming.FillWeight = 109.2995F;
            this.timeConsuming.HeaderText = "维修保养工时";
            this.timeConsuming.Name = "timeConsuming";
            this.timeConsuming.Width = 102;
            // 
            // serviceDate
            // 
            this.serviceDate.DataPropertyName = "serviceDate";
            this.serviceDate.FillWeight = 97.40102F;
            this.serviceDate.HeaderText = "送修日期";
            this.serviceDate.Name = "serviceDate";
            this.serviceDate.Width = 78;
            // 
            // finishDate
            // 
            this.finishDate.DataPropertyName = "finishDate";
            this.finishDate.FillWeight = 87.00106F;
            this.finishDate.HeaderText = "完竣日期";
            this.finishDate.Name = "finishDate";
            this.finishDate.Width = 78;
            // 
            // interval
            // 
            this.interval.DataPropertyName = "interval";
            this.interval.FillWeight = 77.91091F;
            this.interval.HeaderText = "距上次实际工作小时或里程";
            this.interval.Name = "interval";
            this.interval.Width = 174;
            // 
            // fno
            // 
            this.fno.DataPropertyName = "fno";
            this.fno.FillWeight = 69.96563F;
            this.fno.HeaderText = "文档编号";
            this.fno.Name = "fno";
            this.fno.Visible = false;
            this.fno.Width = 78;
            // 
            // serviceExplain
            // 
            this.serviceExplain.DataPropertyName = "serviceExplain";
            this.serviceExplain.FillWeight = 63.02099F;
            this.serviceExplain.HeaderText = "项目说明";
            this.serviceExplain.Name = "serviceExplain";
            this.serviceExplain.Width = 78;
            // 
            // changeAccessory
            // 
            this.changeAccessory.DataPropertyName = "changeAccessory";
            this.changeAccessory.FillWeight = 56.95101F;
            this.changeAccessory.HeaderText = "更换配件";
            this.changeAccessory.Name = "changeAccessory";
            this.changeAccessory.Width = 78;
            // 
            // attemptRunExplain
            // 
            this.attemptRunExplain.DataPropertyName = "attemptRunExplain";
            this.attemptRunExplain.FillWeight = 51.6455F;
            this.attemptRunExplain.HeaderText = "试运转情况";
            this.attemptRunExplain.Name = "attemptRunExplain";
            this.attemptRunExplain.Width = 90;
            // 
            // testResult
            // 
            this.testResult.DataPropertyName = "testResult";
            this.testResult.FillWeight = 47.00819F;
            this.testResult.HeaderText = "检验结论意见";
            this.testResult.Name = "testResult";
            this.testResult.Width = 102;
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.FillWeight = 42.95493F;
            this.inputDate.HeaderText = "录入时间";
            this.inputDate.Name = "inputDate";
            this.inputDate.Width = 78;
            // 
            // dasherName
            // 
            this.dasherName.DataPropertyName = "dasherName";
            this.dasherName.FillWeight = 39.41216F;
            this.dasherName.HeaderText = "单位名称";
            this.dasherName.Name = "dasherName";
            this.dasherName.Visible = false;
            this.dasherName.Width = 78;
            // 
            // inputMan
            // 
            this.inputMan.DataPropertyName = "inputMan";
            this.inputMan.FillWeight = 36.31559F;
            this.inputMan.HeaderText = "录入人";
            this.inputMan.Name = "inputMan";
            this.inputMan.Width = 66;
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(562, 619);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 23);
            this.btn_Print.TabIndex = 40;
            this.btn_Print.Text = "打印";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // FrmEquipmentService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 654);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmEquipmentService";
            this.Tag = "FrmEquipmentService";
            this.Text = "设备维修保养记录";
            this.Load += new System.EventHandler(this.FrmEquipmentService_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtQueryStr;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cbxQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFinishDate;
        private System.Windows.Forms.DateTimePicker dtpServiceDate;
        private System.Windows.Forms.ComboBox cbxRSort;
        private System.Windows.Forms.ComboBox cbxENO;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.TextBox txtServiceExplain;
        private System.Windows.Forms.TextBox txtTestResult;
        private System.Windows.Forms.TextBox txtAttemptRunExplain;
        private System.Windows.Forms.TextBox txtChangeAccessory;
        private System.Windows.Forms.TextBox txtFNO;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSort;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtExpenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn expenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeConsuming;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn interval;
        private System.Windows.Forms.DataGridViewTextBoxColumn fno;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceExplain;
        private System.Windows.Forms.DataGridViewTextBoxColumn changeAccessory;
        private System.Windows.Forms.DataGridViewTextBoxColumn attemptRunExplain;
        private System.Windows.Forms.DataGridViewTextBoxColumn testResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dasherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputMan;
        private System.Windows.Forms.Button btn_Print;
    }
}