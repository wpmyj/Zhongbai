namespace DasherStation.equipment
{
    partial class FrmEquipmentRepairPlanDetail
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
            this.gbOverall = new System.Windows.Forms.GroupBox();
            this.tbDocumentName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbProducer = new System.Windows.Forms.TextBox();
            this.dtpPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbDocumentNo = new System.Windows.Forms.ComboBox();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.cbPreviousServiceKind = new System.Windows.Forms.ComboBox();
            this.dtpPreviousRepairDate = new System.Windows.Forms.DateTimePicker();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.equipmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repairTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planConsume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repairMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previousRepairDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previousServiceKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFinshDate = new System.Windows.Forms.DateTimePicker();
            this.cbRepaireMan = new System.Windows.Forms.ComboBox();
            this.tbPlanConsume = new System.Windows.Forms.TextBox();
            this.tbRepairTime = new System.Windows.Forms.TextBox();
            this.tbWorkTime = new System.Windows.Forms.TextBox();
            this.cbServiceKind = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEquipmentName = new System.Windows.Forms.TextBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEquipmentNo = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbOverall.SuspendLayout();
            this.gbDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOverall
            // 
            this.gbOverall.BackColor = System.Drawing.Color.Transparent;
            this.gbOverall.Controls.Add(this.tbDocumentName);
            this.gbOverall.Controls.Add(this.label12);
            this.gbOverall.Controls.Add(this.tbProducer);
            this.gbOverall.Controls.Add(this.dtpPlanDate);
            this.gbOverall.Controls.Add(this.label16);
            this.gbOverall.Controls.Add(this.label14);
            this.gbOverall.Controls.Add(this.label13);
            this.gbOverall.Controls.Add(this.cbDocumentNo);
            this.gbOverall.Location = new System.Drawing.Point(20, 12);
            this.gbOverall.Name = "gbOverall";
            this.gbOverall.Size = new System.Drawing.Size(811, 53);
            this.gbOverall.TabIndex = 5;
            this.gbOverall.TabStop = false;
            this.gbOverall.Text = "设备保修计划";
            // 
            // tbDocumentName
            // 
            this.tbDocumentName.Location = new System.Drawing.Point(485, 18);
            this.tbDocumentName.Name = "tbDocumentName";
            this.tbDocumentName.ReadOnly = true;
            this.tbDocumentName.Size = new System.Drawing.Size(121, 21);
            this.tbDocumentName.TabIndex = 32;
            this.tbDocumentName.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(426, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "文档名称";
            this.label12.Visible = false;
            // 
            // tbProducer
            // 
            this.tbProducer.Location = new System.Drawing.Point(675, 19);
            this.tbProducer.Name = "tbProducer";
            this.tbProducer.ReadOnly = true;
            this.tbProducer.Size = new System.Drawing.Size(121, 21);
            this.tbProducer.TabIndex = 30;
            this.tbProducer.Visible = false;
            // 
            // dtpPlanDate
            // 
            this.dtpPlanDate.Location = new System.Drawing.Point(76, 18);
            this.dtpPlanDate.Name = "dtpPlanDate";
            this.dtpPlanDate.Size = new System.Drawing.Size(121, 21);
            this.dtpPlanDate.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(628, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 28;
            this.label16.Text = "制表人";
            this.label16.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(220, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 26;
            this.label14.Text = "文档编号";
            this.label14.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "计划时间";
            // 
            // cbDocumentNo
            // 
            this.cbDocumentNo.FormattingEnabled = true;
            this.cbDocumentNo.Location = new System.Drawing.Point(279, 19);
            this.cbDocumentNo.Name = "cbDocumentNo";
            this.cbDocumentNo.Size = new System.Drawing.Size(121, 20);
            this.cbDocumentNo.TabIndex = 16;
            this.cbDocumentNo.Visible = false;
            this.cbDocumentNo.SelectionChangeCommitted += new System.EventHandler(this.cbDocumentNo_SelectionChangeCommitted);
            // 
            // gbDetail
            // 
            this.gbDetail.BackColor = System.Drawing.Color.Transparent;
            this.gbDetail.Controls.Add(this.cbPreviousServiceKind);
            this.gbDetail.Controls.Add(this.dtpPreviousRepairDate);
            this.gbDetail.Controls.Add(this.dgvDetail);
            this.gbDetail.Controls.Add(this.dtpFinshDate);
            this.gbDetail.Controls.Add(this.cbRepaireMan);
            this.gbDetail.Controls.Add(this.tbPlanConsume);
            this.gbDetail.Controls.Add(this.tbRepairTime);
            this.gbDetail.Controls.Add(this.tbWorkTime);
            this.gbDetail.Controls.Add(this.cbServiceKind);
            this.gbDetail.Controls.Add(this.label11);
            this.gbDetail.Controls.Add(this.label10);
            this.gbDetail.Controls.Add(this.label9);
            this.gbDetail.Controls.Add(this.label8);
            this.gbDetail.Controls.Add(this.tbEquipmentName);
            this.gbDetail.Controls.Add(this.cbDepartment);
            this.gbDetail.Controls.Add(this.label7);
            this.gbDetail.Controls.Add(this.label6);
            this.gbDetail.Controls.Add(this.label5);
            this.gbDetail.Controls.Add(this.label4);
            this.gbDetail.Controls.Add(this.label3);
            this.gbDetail.Controls.Add(this.label2);
            this.gbDetail.Controls.Add(this.label1);
            this.gbDetail.Controls.Add(this.cbEquipmentNo);
            this.gbDetail.Controls.Add(this.btnDelete);
            this.gbDetail.Controls.Add(this.btnAdd);
            this.gbDetail.Location = new System.Drawing.Point(20, 71);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(811, 461);
            this.gbDetail.TabIndex = 32;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "设备保修计划明细";
            // 
            // cbPreviousServiceKind
            // 
            this.cbPreviousServiceKind.FormattingEnabled = true;
            this.cbPreviousServiceKind.Items.AddRange(new object[] {
            "日常维修",
            "小修",
            "中修",
            "大修"});
            this.cbPreviousServiceKind.Location = new System.Drawing.Point(509, 96);
            this.cbPreviousServiceKind.Name = "cbPreviousServiceKind";
            this.cbPreviousServiceKind.Size = new System.Drawing.Size(97, 20);
            this.cbPreviousServiceKind.TabIndex = 55;
            // 
            // dtpPreviousRepairDate
            // 
            this.dtpPreviousRepairDate.Location = new System.Drawing.Point(303, 96);
            this.dtpPreviousRepairDate.Name = "dtpPreviousRepairDate";
            this.dtpPreviousRepairDate.Size = new System.Drawing.Size(110, 21);
            this.dtpPreviousRepairDate.TabIndex = 54;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equipmentNo,
            this.equipmentName,
            this.dId,
            this.serviceKind,
            this.workTime,
            this.repairTime,
            this.planConsume,
            this.repairMan,
            this.finishDate,
            this.previousRepairDate,
            this.previousServiceKind});
            this.dgvDetail.Location = new System.Drawing.Point(6, 176);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(799, 279);
            this.dgvDetail.TabIndex = 53;
            // 
            // equipmentNo
            // 
            this.equipmentNo.DataPropertyName = "equipmentNo";
            this.equipmentNo.HeaderText = "设备编号";
            this.equipmentNo.Name = "equipmentNo";
            this.equipmentNo.ReadOnly = true;
            // 
            // equipmentName
            // 
            this.equipmentName.DataPropertyName = "equipmentName";
            this.equipmentName.HeaderText = "设备名称";
            this.equipmentName.Name = "equipmentName";
            this.equipmentName.ReadOnly = true;
            // 
            // dId
            // 
            this.dId.DataPropertyName = "departmentName";
            this.dId.HeaderText = "使用部门";
            this.dId.Name = "dId";
            this.dId.ReadOnly = true;
            // 
            // serviceKind
            // 
            this.serviceKind.DataPropertyName = "serviceKind";
            this.serviceKind.HeaderText = "保修类别";
            this.serviceKind.Name = "serviceKind";
            this.serviceKind.ReadOnly = true;
            // 
            // workTime
            // 
            this.workTime.DataPropertyName = "workTime";
            this.workTime.HeaderText = "工作工时";
            this.workTime.Name = "workTime";
            this.workTime.ReadOnly = true;
            // 
            // repairTime
            // 
            this.repairTime.DataPropertyName = "repairTime";
            this.repairTime.HeaderText = "维修工时";
            this.repairTime.Name = "repairTime";
            this.repairTime.ReadOnly = true;
            // 
            // planConsume
            // 
            this.planConsume.DataPropertyName = "planConsume";
            this.planConsume.HeaderText = "计划费用";
            this.planConsume.Name = "planConsume";
            this.planConsume.ReadOnly = true;
            // 
            // repairMan
            // 
            this.repairMan.DataPropertyName = "repairMan";
            this.repairMan.HeaderText = "主修人";
            this.repairMan.Name = "repairMan";
            this.repairMan.ReadOnly = true;
            // 
            // finishDate
            // 
            this.finishDate.DataPropertyName = "finishDate";
            this.finishDate.HeaderText = "完成时间";
            this.finishDate.Name = "finishDate";
            this.finishDate.ReadOnly = true;
            // 
            // previousRepairDate
            // 
            this.previousRepairDate.DataPropertyName = "previousRepairDate";
            this.previousRepairDate.HeaderText = "上次维修时间";
            this.previousRepairDate.Name = "previousRepairDate";
            this.previousRepairDate.ReadOnly = true;
            // 
            // previousServiceKind
            // 
            this.previousServiceKind.DataPropertyName = "previousServiceKind";
            this.previousServiceKind.HeaderText = "上次保修类别";
            this.previousServiceKind.Name = "previousServiceKind";
            this.previousServiceKind.ReadOnly = true;
            // 
            // dtpFinshDate
            // 
            this.dtpFinshDate.Location = new System.Drawing.Point(76, 96);
            this.dtpFinshDate.Name = "dtpFinshDate";
            this.dtpFinshDate.Size = new System.Drawing.Size(121, 21);
            this.dtpFinshDate.TabIndex = 50;
            // 
            // cbRepaireMan
            // 
            this.cbRepaireMan.FormattingEnabled = true;
            this.cbRepaireMan.Location = new System.Drawing.Point(675, 58);
            this.cbRepaireMan.Name = "cbRepaireMan";
            this.cbRepaireMan.Size = new System.Drawing.Size(121, 20);
            this.cbRepaireMan.TabIndex = 49;
            // 
            // tbPlanConsume
            // 
            this.tbPlanConsume.Location = new System.Drawing.Point(675, 24);
            this.tbPlanConsume.Name = "tbPlanConsume";
            this.tbPlanConsume.Size = new System.Drawing.Size(121, 21);
            this.tbPlanConsume.TabIndex = 48;
            // 
            // tbRepairTime
            // 
            this.tbRepairTime.Location = new System.Drawing.Point(485, 58);
            this.tbRepairTime.Name = "tbRepairTime";
            this.tbRepairTime.Size = new System.Drawing.Size(121, 21);
            this.tbRepairTime.TabIndex = 47;
            // 
            // tbWorkTime
            // 
            this.tbWorkTime.Location = new System.Drawing.Point(279, 58);
            this.tbWorkTime.Name = "tbWorkTime";
            this.tbWorkTime.Size = new System.Drawing.Size(121, 21);
            this.tbWorkTime.TabIndex = 46;
            // 
            // cbServiceKind
            // 
            this.cbServiceKind.FormattingEnabled = true;
            this.cbServiceKind.Items.AddRange(new object[] {
            "日常维修",
            "小修",
            "中修",
            "大修"});
            this.cbServiceKind.Location = new System.Drawing.Point(76, 58);
            this.cbServiceKind.Name = "cbServiceKind";
            this.cbServiceKind.Size = new System.Drawing.Size(121, 20);
            this.cbServiceKind.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(616, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 44;
            this.label11.Text = "计划费用";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(628, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 43;
            this.label10.Text = "主修人";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 42;
            this.label9.Text = "完成时间";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 41;
            this.label8.Text = "上次维修时间";
            // 
            // tbEquipmentName
            // 
            this.tbEquipmentName.Location = new System.Drawing.Point(279, 24);
            this.tbEquipmentName.Name = "tbEquipmentName";
            this.tbEquipmentName.ReadOnly = true;
            this.tbEquipmentName.Size = new System.Drawing.Size(121, 21);
            this.tbEquipmentName.TabIndex = 40;
            // 
            // cbDepartment
            // 
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(485, 24);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(121, 20);
            this.cbDepartment.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "设备编号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(426, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "使用部门";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "设备名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 35;
            this.label4.Text = "保修类别";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 34;
            this.label3.Text = "工作工时";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "维修工时";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(426, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "上次保修类别";
            // 
            // cbEquipmentNo
            // 
            this.cbEquipmentNo.FormattingEnabled = true;
            this.cbEquipmentNo.Location = new System.Drawing.Point(76, 24);
            this.cbEquipmentNo.Name = "cbEquipmentNo";
            this.cbEquipmentNo.Size = new System.Drawing.Size(121, 20);
            this.cbEquipmentNo.TabIndex = 31;
            this.cbEquipmentNo.SelectionChangeCommitted += new System.EventHandler(this.cbEquipmentNo_SelectionChangeCommitted);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.Location = new System.Drawing.Point(721, 137);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除明细";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdd.Location = new System.Drawing.Point(630, 137);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新建明细";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(695, 541);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 30);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "保存计划";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmEquipmentRepairPlanDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 583);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.gbOverall);
            this.Name = "FrmEquipmentRepairPlanDetail";
            this.Tag = "FrmEquipmentRepairPlanDetail";
            this.Text = "新建设备保修计划";
            this.Load += new System.EventHandler(this.FrmEquipmentRepairPlanDetail_Load);
            this.gbOverall.ResumeLayout(false);
            this.gbOverall.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOverall;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbDocumentNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dtpPlanDate;
        private System.Windows.Forms.TextBox tbProducer;
        private System.Windows.Forms.ComboBox cbEquipmentNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.TextBox tbEquipmentName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbRepaireMan;
        private System.Windows.Forms.TextBox tbPlanConsume;
        private System.Windows.Forms.TextBox tbRepairTime;
        private System.Windows.Forms.TextBox tbWorkTime;
        private System.Windows.Forms.ComboBox cbServiceKind;
        private System.Windows.Forms.DateTimePicker dtpFinshDate;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbDocumentName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dId;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn workTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn repairTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn planConsume;
        private System.Windows.Forms.DataGridViewTextBoxColumn repairMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn previousRepairDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn previousServiceKind;
        private System.Windows.Forms.DateTimePicker dtpPreviousRepairDate;
        private System.Windows.Forms.ComboBox cbPreviousServiceKind;
    }
}