namespace DasherStation.equipment
{
    partial class FrmEquipmentUse
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbEquipmentNo = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.dgvUseDetial = new System.Windows.Forms.DataGridView();
            this.useDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noWorkTime = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.operateMan = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gbOverall = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvUseOverall = new System.Windows.Forms.DataGridView();
            this.useMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workTimeSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSearch.SuspendLayout();
            this.gbDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUseDetial)).BeginInit();
            this.gbOverall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUseOverall)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.BackColor = System.Drawing.Color.Transparent;
            this.gbSearch.Controls.Add(this.chbxAll);
            this.gbSearch.Controls.Add(this.dateTimePicker1);
            this.gbSearch.Controls.Add(this.label2);
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.cbEquipmentNo);
            this.gbSearch.Location = new System.Drawing.Point(12, 3);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(703, 49);
            this.gbSearch.TabIndex = 6;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "查询条件";
            // 
            // chbxAll
            // 
            this.chbxAll.AutoSize = true;
            this.chbxAll.Checked = true;
            this.chbxAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxAll.Location = new System.Drawing.Point(473, 21);
            this.chbxAll.Name = "chbxAll";
            this.chbxAll.Size = new System.Drawing.Size(96, 16);
            this.chbxAll.TabIndex = 6;
            this.chbxAll.Text = "所有使用记录";
            this.chbxAll.UseVisualStyleBackColor = true;
            this.chbxAll.CheckedChanged += new System.EventHandler(this.chbxNoCondition_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy年 MM月";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(80, 17);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(99, 21);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "使用月份";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "设备编号";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(614, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbEquipmentNo
            // 
            this.cbEquipmentNo.Enabled = false;
            this.cbEquipmentNo.FormattingEnabled = true;
            this.cbEquipmentNo.Location = new System.Drawing.Point(278, 17);
            this.cbEquipmentNo.Name = "cbEquipmentNo";
            this.cbEquipmentNo.Size = new System.Drawing.Size(147, 20);
            this.cbEquipmentNo.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(451, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "新建";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(613, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gbDetail
            // 
            this.gbDetail.BackColor = System.Drawing.Color.Transparent;
            this.gbDetail.Controls.Add(this.dgvUseDetial);
            this.gbDetail.Location = new System.Drawing.Point(12, 279);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(703, 406);
            this.gbDetail.TabIndex = 5;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "设备使用记录明细";
            // 
            // dgvUseDetial
            // 
            this.dgvUseDetial.AllowUserToAddRows = false;
            this.dgvUseDetial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUseDetial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.useDate,
            this.content,
            this.workTime,
            this.noWorkTime,
            this.operateMan});
            this.dgvUseDetial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUseDetial.Location = new System.Drawing.Point(3, 17);
            this.dgvUseDetial.Name = "dgvUseDetial";
            this.dgvUseDetial.RowTemplate.Height = 23;
            this.dgvUseDetial.Size = new System.Drawing.Size(697, 386);
            this.dgvUseDetial.TabIndex = 0;
            this.dgvUseDetial.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUseDetial_CellValueChanged);
            // 
            // useDate
            // 
            this.useDate.DataPropertyName = "useDate";
            this.useDate.HeaderText = "使用日期";
            this.useDate.Name = "useDate";
            this.useDate.ReadOnly = true;
            // 
            // content
            // 
            this.content.DataPropertyName = "content";
            this.content.HeaderText = "工作内容";
            this.content.Name = "content";
            // 
            // workTime
            // 
            this.workTime.DataPropertyName = "workTime";
            this.workTime.HeaderText = "工作台时";
            this.workTime.Name = "workTime";
            // 
            // noWorkTime
            // 
            this.noWorkTime.DataPropertyName = "noWorkTime";
            this.noWorkTime.HeaderText = "非工作时间";
            this.noWorkTime.Items.AddRange(new object[] {
            "机修",
            "气候",
            "待工"});
            this.noWorkTime.Name = "noWorkTime";
            this.noWorkTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.noWorkTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // operateMan
            // 
            this.operateMan.DataPropertyName = "piId";
            this.operateMan.HeaderText = "操作员";
            this.operateMan.Name = "operateMan";
            this.operateMan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.operateMan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gbOverall
            // 
            this.gbOverall.BackColor = System.Drawing.Color.Transparent;
            this.gbOverall.Controls.Add(this.btnPrint);
            this.gbOverall.Controls.Add(this.btnSave);
            this.gbOverall.Controls.Add(this.dgvUseOverall);
            this.gbOverall.Controls.Add(this.btnAdd);
            this.gbOverall.Controls.Add(this.btnDelete);
            this.gbOverall.Location = new System.Drawing.Point(13, 58);
            this.gbOverall.Name = "gbOverall";
            this.gbOverall.Size = new System.Drawing.Size(702, 215);
            this.gbOverall.TabIndex = 4;
            this.gbOverall.TabStop = false;
            this.gbOverall.Text = "设备使用记录";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(349, 17);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(532, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvUseOverall
            // 
            this.dgvUseOverall.AllowUserToAddRows = false;
            this.dgvUseOverall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUseOverall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUseOverall.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.useMonth,
            this.equipmentNo,
            this.workTimeSum,
            this.equipmentName,
            this.documentNo});
            this.dgvUseOverall.Location = new System.Drawing.Point(3, 57);
            this.dgvUseOverall.MultiSelect = false;
            this.dgvUseOverall.Name = "dgvUseOverall";
            this.dgvUseOverall.ReadOnly = true;
            this.dgvUseOverall.RowTemplate.Height = 23;
            this.dgvUseOverall.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUseOverall.Size = new System.Drawing.Size(696, 158);
            this.dgvUseOverall.TabIndex = 0;
            this.dgvUseOverall.SelectionChanged += new System.EventHandler(this.dgvUseOverall_SelectionChanged);
            // 
            // useMonth
            // 
            this.useMonth.DataPropertyName = "useMonth";
            dataGridViewCellStyle1.Format = "y";
            dataGridViewCellStyle1.NullValue = null;
            this.useMonth.DefaultCellStyle = dataGridViewCellStyle1;
            this.useMonth.HeaderText = "使用时间";
            this.useMonth.Name = "useMonth";
            this.useMonth.ReadOnly = true;
            // 
            // equipmentNo
            // 
            this.equipmentNo.DataPropertyName = "equipmentNo";
            this.equipmentNo.HeaderText = "设备编号";
            this.equipmentNo.Name = "equipmentNo";
            this.equipmentNo.ReadOnly = true;
            // 
            // workTimeSum
            // 
            this.workTimeSum.DataPropertyName = "workTimeSum";
            this.workTimeSum.HeaderText = "本月使用台时";
            this.workTimeSum.Name = "workTimeSum";
            this.workTimeSum.ReadOnly = true;
            // 
            // equipmentName
            // 
            this.equipmentName.DataPropertyName = "equipmentName";
            this.equipmentName.HeaderText = "设备名称";
            this.equipmentName.Name = "equipmentName";
            this.equipmentName.ReadOnly = true;
            // 
            // documentNo
            // 
            this.documentNo.DataPropertyName = "documentNo";
            this.documentNo.HeaderText = "文档编号";
            this.documentNo.Name = "documentNo";
            this.documentNo.ReadOnly = true;
            this.documentNo.Visible = false;
            // 
            // FrmEquipmentUse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 697);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.gbOverall);
            this.Name = "FrmEquipmentUse";
            this.Tag = "FrmEquipmentUse";
            this.Text = "设备使用记录";
            this.Load += new System.EventHandler(this.FrmEquipmentUse_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUseDetial)).EndInit();
            this.gbOverall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUseOverall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbEquipmentNo;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.DataGridView dgvUseDetial;
        private System.Windows.Forms.GroupBox gbOverall;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvUseOverall;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn useDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn content;
        private System.Windows.Forms.DataGridViewTextBoxColumn workTime;
        private System.Windows.Forms.DataGridViewComboBoxColumn noWorkTime;
        private System.Windows.Forms.DataGridViewComboBoxColumn operateMan;
        private System.Windows.Forms.CheckBox chbxAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn useMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn workTimeSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentNo;
        private System.Windows.Forms.Button btnPrint;

    }
}