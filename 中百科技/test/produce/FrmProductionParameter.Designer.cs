namespace DasherStation.produce
{
    partial class FrmProductionParameter
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
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSeachText = new System.Windows.Forms.TextBox();
            this.cbxSeachCondition = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.gbSingle = new System.Windows.Forms.GroupBox();
            this.tbStoneError = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbAsphaltumError = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbMinTemperature = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMaxTemperature = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEquipmentModel = new System.Windows.Forms.TextBox();
            this.tbEquipmentName = new System.Windows.Forms.TextBox();
            this.cbEquipmentNo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbGather = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asphaltumError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stoneError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSearch.SuspendLayout();
            this.gbSingle.SuspendLayout();
            this.gbGather.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearch.BackColor = System.Drawing.Color.Transparent;
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.tbSeachText);
            this.gbSearch.Controls.Add(this.cbxSeachCondition);
            this.gbSearch.Controls.Add(this.dtpDate);
            this.gbSearch.Location = new System.Drawing.Point(12, 2);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(625, 48);
            this.gbSearch.TabIndex = 7;
            this.gbSearch.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "查询条件";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(532, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSeachText
            // 
            this.tbSeachText.Location = new System.Drawing.Point(221, 17);
            this.tbSeachText.Name = "tbSeachText";
            this.tbSeachText.Size = new System.Drawing.Size(121, 21);
            this.tbSeachText.TabIndex = 1;
            this.tbSeachText.Tag = "";
            // 
            // cbxSeachCondition
            // 
            this.cbxSeachCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSeachCondition.FormattingEnabled = true;
            this.cbxSeachCondition.Items.AddRange(new object[] {
            "设备编号",
            "设备名称",
            "设定时间"});
            this.cbxSeachCondition.Location = new System.Drawing.Point(77, 17);
            this.cbxSeachCondition.Name = "cbxSeachCondition";
            this.cbxSeachCondition.Size = new System.Drawing.Size(121, 20);
            this.cbxSeachCondition.TabIndex = 0;
            this.cbxSeachCondition.SelectionChangeCommitted += new System.EventHandler(this.cbxSeachCondition_SelectionChangeCommitted);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(221, 17);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(121, 21);
            this.dtpDate.TabIndex = 4;
            // 
            // gbSingle
            // 
            this.gbSingle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSingle.BackColor = System.Drawing.Color.Transparent;
            this.gbSingle.Controls.Add(this.tbStoneError);
            this.gbSingle.Controls.Add(this.label14);
            this.gbSingle.Controls.Add(this.tbAsphaltumError);
            this.gbSingle.Controls.Add(this.label3);
            this.gbSingle.Controls.Add(this.label11);
            this.gbSingle.Controls.Add(this.label13);
            this.gbSingle.Controls.Add(this.tbMinTemperature);
            this.gbSingle.Controls.Add(this.label10);
            this.gbSingle.Controls.Add(this.label9);
            this.gbSingle.Controls.Add(this.tbMaxTemperature);
            this.gbSingle.Controls.Add(this.label8);
            this.gbSingle.Controls.Add(this.tbEquipmentModel);
            this.gbSingle.Controls.Add(this.tbEquipmentName);
            this.gbSingle.Controls.Add(this.cbEquipmentNo);
            this.gbSingle.Controls.Add(this.label12);
            this.gbSingle.Controls.Add(this.label7);
            this.gbSingle.Controls.Add(this.label6);
            this.gbSingle.Controls.Add(this.label5);
            this.gbSingle.Controls.Add(this.label4);
            this.gbSingle.Controls.Add(this.label2);
            this.gbSingle.Location = new System.Drawing.Point(12, 56);
            this.gbSingle.Name = "gbSingle";
            this.gbSingle.Size = new System.Drawing.Size(625, 114);
            this.gbSingle.TabIndex = 5;
            this.gbSingle.TabStop = false;
            this.gbSingle.Text = "生产参数";
            // 
            // tbStoneError
            // 
            this.tbStoneError.Location = new System.Drawing.Point(299, 81);
            this.tbStoneError.Name = "tbStoneError";
            this.tbStoneError.Size = new System.Drawing.Size(83, 21);
            this.tbStoneError.TabIndex = 60;
            this.tbStoneError.Tag = "EF";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(278, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 61;
            this.label14.Text = "±";
            // 
            // tbAsphaltumError
            // 
            this.tbAsphaltumError.Location = new System.Drawing.Point(299, 51);
            this.tbAsphaltumError.Name = "tbAsphaltumError";
            this.tbAsphaltumError.Size = new System.Drawing.Size(83, 21);
            this.tbAsphaltumError.TabIndex = 54;
            this.tbAsphaltumError.Tag = "EF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 59;
            this.label3.Text = "±";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(388, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 58;
            this.label11.Text = "%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(388, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 57;
            this.label13.Text = "%";
            // 
            // tbMinTemperature
            // 
            this.tbMinTemperature.Location = new System.Drawing.Point(77, 81);
            this.tbMinTemperature.Name = "tbMinTemperature";
            this.tbMinTemperature.Size = new System.Drawing.Size(97, 21);
            this.tbMinTemperature.TabIndex = 53;
            this.tbMinTemperature.Tag = "EF";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(180, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 52;
            this.label10.Text = "℃";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 51;
            this.label9.Text = "℃";
            // 
            // tbMaxTemperature
            // 
            this.tbMaxTemperature.Location = new System.Drawing.Point(77, 50);
            this.tbMaxTemperature.Name = "tbMaxTemperature";
            this.tbMaxTemperature.Size = new System.Drawing.Size(97, 21);
            this.tbMaxTemperature.TabIndex = 50;
            this.tbMaxTemperature.Tag = "EF";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 48;
            this.label8.Text = "温度下限";
            // 
            // tbEquipmentModel
            // 
            this.tbEquipmentModel.Location = new System.Drawing.Point(486, 20);
            this.tbEquipmentModel.Name = "tbEquipmentModel";
            this.tbEquipmentModel.ReadOnly = true;
            this.tbEquipmentModel.Size = new System.Drawing.Size(121, 21);
            this.tbEquipmentModel.TabIndex = 47;
            // 
            // tbEquipmentName
            // 
            this.tbEquipmentName.Location = new System.Drawing.Point(278, 20);
            this.tbEquipmentName.Name = "tbEquipmentName";
            this.tbEquipmentName.ReadOnly = true;
            this.tbEquipmentName.Size = new System.Drawing.Size(121, 21);
            this.tbEquipmentName.TabIndex = 46;
            // 
            // cbEquipmentNo
            // 
            this.cbEquipmentNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentNo.FormattingEnabled = true;
            this.cbEquipmentNo.Location = new System.Drawing.Point(76, 20);
            this.cbEquipmentNo.Name = "cbEquipmentNo";
            this.cbEquipmentNo.Size = new System.Drawing.Size(121, 20);
            this.cbEquipmentNo.TabIndex = 35;
            this.cbEquipmentNo.Tag = "";
            this.cbEquipmentNo.SelectionChangeCommitted += new System.EventHandler(this.cbEquipmentNo_SelectionChangeCommitted);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 28;
            this.label12.Text = "设备编号";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "石料偏差";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "沥青偏差";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "设备规格";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "设备名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "温度上限";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(451, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "新建";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(532, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gbGather
            // 
            this.gbGather.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGather.BackColor = System.Drawing.Color.Transparent;
            this.gbGather.Controls.Add(this.dgvDetail);
            this.gbGather.Controls.Add(this.btnDelete);
            this.gbGather.Controls.Add(this.btnAdd);
            this.gbGather.Location = new System.Drawing.Point(12, 176);
            this.gbGather.Name = "gbGather";
            this.gbGather.Size = new System.Drawing.Size(625, 368);
            this.gbGather.TabIndex = 6;
            this.gbGather.TabStop = false;
            this.gbGather.Text = "生产参数列表";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inputDate,
            this.equipmentNo,
            this.equipmentName,
            this.equipmentModel,
            this.maxTemperature,
            this.minTemperature,
            this.asphaltumError,
            this.stoneError});
            this.dgvDetail.Location = new System.Drawing.Point(3, 63);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(619, 301);
            this.dgvDetail.TabIndex = 0;
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.HeaderText = "设定时间";
            this.inputDate.Name = "inputDate";
            this.inputDate.ReadOnly = true;
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
            // equipmentModel
            // 
            this.equipmentModel.DataPropertyName = "equipmentModel";
            this.equipmentModel.HeaderText = "设备规格";
            this.equipmentModel.Name = "equipmentModel";
            this.equipmentModel.ReadOnly = true;
            // 
            // maxTemperature
            // 
            this.maxTemperature.DataPropertyName = "maxTemperature";
            this.maxTemperature.HeaderText = "温度上限";
            this.maxTemperature.Name = "maxTemperature";
            this.maxTemperature.ReadOnly = true;
            // 
            // minTemperature
            // 
            this.minTemperature.DataPropertyName = "minTemperature";
            this.minTemperature.HeaderText = "温度下限";
            this.minTemperature.Name = "minTemperature";
            this.minTemperature.ReadOnly = true;
            // 
            // asphaltumError
            // 
            this.asphaltumError.DataPropertyName = "asphaltumError";
            this.asphaltumError.HeaderText = "沥青偏差";
            this.asphaltumError.Name = "asphaltumError";
            this.asphaltumError.ReadOnly = true;
            // 
            // stoneError
            // 
            this.stoneError.DataPropertyName = "stoneError";
            this.stoneError.HeaderText = "石料偏差";
            this.stoneError.Name = "stoneError";
            this.stoneError.ReadOnly = true;
            // 
            // FrmProductionParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 556);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbSingle);
            this.Controls.Add(this.gbGather);
            this.Name = "FrmProductionParameter";
            this.Tag = "FrmProductionParameter";
            this.Text = "生产参数";
            this.Load += new System.EventHandler(this.FrmProductionParameter_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbSingle.ResumeLayout(false);
            this.gbSingle.PerformLayout();
            this.gbGather.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSeachText;
        private System.Windows.Forms.ComboBox cbxSeachCondition;
        private System.Windows.Forms.GroupBox gbSingle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbEquipmentModel;
        private System.Windows.Forms.TextBox tbEquipmentName;
        private System.Windows.Forms.ComboBox cbEquipmentNo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbGather;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.TextBox tbMaxTemperature;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbAsphaltumError;
        private System.Windows.Forms.TextBox tbMinTemperature;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbStoneError;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn minTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn asphaltumError;
        private System.Windows.Forms.DataGridViewTextBoxColumn stoneError;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}