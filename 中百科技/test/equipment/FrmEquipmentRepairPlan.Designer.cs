namespace DasherStation.equipment
{
    partial class FrmEquipmentRepairPlan
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
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.chbxAll = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.equipmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repairTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planConsume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repairMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previousRepairDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previousServiceKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbOverall = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvOverall = new System.Windows.Forms.DataGridView();
            this.planDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkupMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbSearch.SuspendLayout();
            this.gbDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.gbOverall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverall)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.BackColor = System.Drawing.Color.Transparent;
            this.gbSearch.Controls.Add(this.chbxAll);
            this.gbSearch.Controls.Add(this.dateTimePicker1);
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Location = new System.Drawing.Point(12, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(622, 48);
            this.gbSearch.TabIndex = 6;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "查询条件";
            // 
            // chbxAll
            // 
            this.chbxAll.AutoSize = true;
            this.chbxAll.Checked = true;
            this.chbxAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxAll.Location = new System.Drawing.Point(236, 19);
            this.chbxAll.Name = "chbxAll";
            this.chbxAll.Size = new System.Drawing.Size(72, 16);
            this.chbxAll.TabIndex = 5;
            this.chbxAll.Text = "所有计划";
            this.chbxAll.UseVisualStyleBackColor = true;
            this.chbxAll.CheckedChanged += new System.EventHandler(this.chbxAll_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(77, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(110, 21);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "计划时间";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(531, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbDetail
            // 
            this.gbDetail.BackColor = System.Drawing.Color.Transparent;
            this.gbDetail.Controls.Add(this.dgvDetail);
            this.gbDetail.Location = new System.Drawing.Point(12, 300);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(625, 308);
            this.gbDetail.TabIndex = 5;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "设备保修计划明细";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equipmentNo,
            this.equipmentName,
            this.departmentName,
            this.serviceKind,
            this.workTime,
            this.repairTime,
            this.planConsume,
            this.repairMan,
            this.finishDate,
            this.previousRepairDate,
            this.previousServiceKind});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(619, 288);
            this.dgvDetail.TabIndex = 0;
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
            // departmentName
            // 
            this.departmentName.DataPropertyName = "departmentName";
            this.departmentName.HeaderText = "使用部门";
            this.departmentName.Name = "departmentName";
            this.departmentName.ReadOnly = true;
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
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.finishDate.DefaultCellStyle = dataGridViewCellStyle1;
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
            // gbOverall
            // 
            this.gbOverall.BackColor = System.Drawing.Color.Transparent;
            this.gbOverall.Controls.Add(this.btnPrint);
            this.gbOverall.Controls.Add(this.dgvOverall);
            this.gbOverall.Controls.Add(this.btnDelete);
            this.gbOverall.Controls.Add(this.btnAdd);
            this.gbOverall.Location = new System.Drawing.Point(12, 66);
            this.gbOverall.Name = "gbOverall";
            this.gbOverall.Size = new System.Drawing.Size(625, 228);
            this.gbOverall.TabIndex = 4;
            this.gbOverall.TabStop = false;
            this.gbOverall.Text = "设备保修计划";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(236, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgvOverall
            // 
            this.dgvOverall.AllowUserToAddRows = false;
            this.dgvOverall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOverall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverall.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.planDate,
            this.documentNo,
            this.documentName,
            this.producer,
            this.assessor,
            this.checkupMan});
            this.dgvOverall.Location = new System.Drawing.Point(3, 59);
            this.dgvOverall.MultiSelect = false;
            this.dgvOverall.Name = "dgvOverall";
            this.dgvOverall.ReadOnly = true;
            this.dgvOverall.RowTemplate.Height = 23;
            this.dgvOverall.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOverall.Size = new System.Drawing.Size(619, 169);
            this.dgvOverall.TabIndex = 2;
            this.dgvOverall.SelectionChanged += new System.EventHandler(this.dgvOverall_SelectionChanged);
            // 
            // planDate
            // 
            this.planDate.DataPropertyName = "planDate";
            this.planDate.HeaderText = "计划时间";
            this.planDate.Name = "planDate";
            this.planDate.ReadOnly = true;
            // 
            // documentNo
            // 
            this.documentNo.DataPropertyName = "documentNo";
            this.documentNo.HeaderText = "文档编号";
            this.documentNo.Name = "documentNo";
            this.documentNo.ReadOnly = true;
            this.documentNo.Visible = false;
            // 
            // documentName
            // 
            this.documentName.DataPropertyName = "documentName";
            this.documentName.HeaderText = "文档名称";
            this.documentName.Name = "documentName";
            this.documentName.ReadOnly = true;
            this.documentName.Visible = false;
            // 
            // producer
            // 
            this.producer.DataPropertyName = "producer";
            this.producer.HeaderText = "制表人";
            this.producer.Name = "producer";
            this.producer.ReadOnly = true;
            // 
            // assessor
            // 
            this.assessor.DataPropertyName = "assessor";
            this.assessor.HeaderText = "审核人";
            this.assessor.Name = "assessor";
            this.assessor.ReadOnly = true;
            // 
            // checkupMan
            // 
            this.checkupMan.DataPropertyName = "checkupMan";
            this.checkupMan.HeaderText = "审批人";
            this.checkupMan.Name = "checkupMan";
            this.checkupMan.ReadOnly = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(531, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(438, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新建";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmEquipmentRepairPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 622);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.gbOverall);
            this.Name = "FrmEquipmentRepairPlan";
            this.Tag = "FrmEquipmentRepairPlan";
            this.Text = "设备保修计划";
            this.Load += new System.EventHandler(this.FrmEquipmentRepairPlan_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.gbOverall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.GroupBox gbOverall;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvOverall;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox chbxAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn workTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn repairTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn planConsume;
        private System.Windows.Forms.DataGridViewTextBoxColumn repairMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn previousRepairDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn previousServiceKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn planDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn producer;
        private System.Windows.Forms.DataGridViewTextBoxColumn assessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkupMan;
        private System.Windows.Forms.Button btnPrint;
    }
}