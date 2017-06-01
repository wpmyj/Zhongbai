namespace DasherStation.produce
{
    partial class FrmRawMaterialConsumption
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
            this.btn_all = new System.Windows.Forms.Button();
            this.cmb_productKind = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_query = new System.Windows.Forms.Button();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.cmb_equipmentInfo = new System.Windows.Forms.ComboBox();
            this.cmb_productModel = new System.Windows.Forms.ComboBox();
            this.cmb_productName = new System.Windows.Forms.ComboBox();
            this.cmb_materialModel = new System.Windows.Forms.ComboBox();
            this.cmb_materialName = new System.Windows.Forms.ComboBox();
            this.cmb_materialKind = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dgv_MaterialConsumption = new System.Windows.Forms.DataGridView();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmodel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mmid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eiid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MaterialConsumption)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btn_all);
            this.groupBox1.Controls.Add(this.cmb_productKind);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btn_query);
            this.groupBox1.Controls.Add(this.dtp_end);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtp_start);
            this.groupBox1.Controls.Add(this.cmb_equipmentInfo);
            this.groupBox1.Controls.Add(this.cmb_productModel);
            this.groupBox1.Controls.Add(this.cmb_productName);
            this.groupBox1.Controls.Add(this.cmb_materialModel);
            this.groupBox1.Controls.Add(this.cmb_materialName);
            this.groupBox1.Controls.Add(this.cmb_materialKind);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(7, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(713, 126);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btn_all
            // 
            this.btn_all.Location = new System.Drawing.Point(105, 97);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(75, 23);
            this.btn_all.TabIndex = 43;
            this.btn_all.Text = "全部";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // cmb_productKind
            // 
            this.cmb_productKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_productKind.FormattingEnabled = true;
            this.cmb_productKind.Location = new System.Drawing.Point(81, 70);
            this.cmb_productKind.Name = "cmb_productKind";
            this.cmb_productKind.Size = new System.Drawing.Size(121, 20);
            this.cmb_productKind.TabIndex = 42;
            this.cmb_productKind.SelectionChangeCommitted += new System.EventHandler(this.cmb_productKind_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 41;
            this.label9.Text = "产品名称";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(616, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(24, 97);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 38;
            this.btn_query.Text = "搜索";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // dtp_end
            // 
            this.dtp_end.Location = new System.Drawing.Point(233, 17);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(121, 21);
            this.dtp_end.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(210, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 36;
            this.label10.Text = "--";
            // 
            // dtp_start
            // 
            this.dtp_start.Location = new System.Drawing.Point(81, 17);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(121, 21);
            this.dtp_start.TabIndex = 35;
            // 
            // cmb_equipmentInfo
            // 
            this.cmb_equipmentInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_equipmentInfo.FormattingEnabled = true;
            this.cmb_equipmentInfo.Location = new System.Drawing.Point(570, 18);
            this.cmb_equipmentInfo.Name = "cmb_equipmentInfo";
            this.cmb_equipmentInfo.Size = new System.Drawing.Size(121, 20);
            this.cmb_equipmentInfo.TabIndex = 34;
            // 
            // cmb_productModel
            // 
            this.cmb_productModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_productModel.FormattingEnabled = true;
            this.cmb_productModel.Location = new System.Drawing.Point(570, 70);
            this.cmb_productModel.Name = "cmb_productModel";
            this.cmb_productModel.Size = new System.Drawing.Size(121, 20);
            this.cmb_productModel.TabIndex = 33;
            // 
            // cmb_productName
            // 
            this.cmb_productName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_productName.FormattingEnabled = true;
            this.cmb_productName.Location = new System.Drawing.Point(338, 70);
            this.cmb_productName.Name = "cmb_productName";
            this.cmb_productName.Size = new System.Drawing.Size(121, 20);
            this.cmb_productName.TabIndex = 32;
            this.cmb_productName.SelectionChangeCommitted += new System.EventHandler(this.cmb_productName_SelectionChangeCommitted);
            // 
            // cmb_materialModel
            // 
            this.cmb_materialModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_materialModel.FormattingEnabled = true;
            this.cmb_materialModel.Location = new System.Drawing.Point(570, 44);
            this.cmb_materialModel.Name = "cmb_materialModel";
            this.cmb_materialModel.Size = new System.Drawing.Size(121, 20);
            this.cmb_materialModel.TabIndex = 31;
            // 
            // cmb_materialName
            // 
            this.cmb_materialName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_materialName.FormattingEnabled = true;
            this.cmb_materialName.Location = new System.Drawing.Point(338, 44);
            this.cmb_materialName.Name = "cmb_materialName";
            this.cmb_materialName.Size = new System.Drawing.Size(121, 20);
            this.cmb_materialName.TabIndex = 30;
            this.cmb_materialName.SelectionChangeCommitted += new System.EventHandler(this.cmb_materialName_SelectionChangeCommitted);
            // 
            // cmb_materialKind
            // 
            this.cmb_materialKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_materialKind.FormattingEnabled = true;
            this.cmb_materialKind.Location = new System.Drawing.Point(81, 44);
            this.cmb_materialKind.Name = "cmb_materialKind";
            this.cmb_materialKind.Size = new System.Drawing.Size(121, 20);
            this.cmb_materialKind.TabIndex = 29;
            this.cmb_materialKind.SelectionChangeCommitted += new System.EventHandler(this.cmb_materialKind_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(490, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "设备编号";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(270, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "产品名称";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(490, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 26;
            this.label13.Text = "产品型号";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(490, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 25;
            this.label14.Text = "材料型号";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(270, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 24;
            this.label15.Text = "材料名称";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 23;
            this.label16.Text = "材料种类";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 22;
            this.label17.Text = "日期";
            // 
            // dgv_MaterialConsumption
            // 
            this.dgv_MaterialConsumption.AllowUserToAddRows = false;
            this.dgv_MaterialConsumption.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_MaterialConsumption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MaterialConsumption.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.quantity1,
            this.quantity2,
            this.produceDate,
            this.mname,
            this.model,
            this.scale,
            this.pname,
            this.pmodel,
            this.quantity,
            this.dataSource,
            this.consumption,
            this.ename,
            this.pnid,
            this.pmid,
            this.mnid,
            this.mmid,
            this.eiid});
            this.dgv_MaterialConsumption.Location = new System.Drawing.Point(7, 134);
            this.dgv_MaterialConsumption.Name = "dgv_MaterialConsumption";
            this.dgv_MaterialConsumption.RowTemplate.Height = 23;
            this.dgv_MaterialConsumption.Size = new System.Drawing.Size(713, 390);
            this.dgv_MaterialConsumption.TabIndex = 2;
            // 
            // pid
            // 
            this.pid.DataPropertyName = "pid";
            this.pid.HeaderText = "pid";
            this.pid.Name = "pid";
            this.pid.Visible = false;
            // 
            // quantity1
            // 
            this.quantity1.DataPropertyName = "quantity1";
            this.quantity1.HeaderText = "quantity1";
            this.quantity1.Name = "quantity1";
            this.quantity1.Visible = false;
            // 
            // quantity2
            // 
            this.quantity2.DataPropertyName = "quantity2";
            this.quantity2.HeaderText = "quantity2";
            this.quantity2.Name = "quantity2";
            this.quantity2.Visible = false;
            // 
            // produceDate
            // 
            this.produceDate.DataPropertyName = "produceDate";
            this.produceDate.HeaderText = "日期";
            this.produceDate.Name = "produceDate";
            // 
            // mname
            // 
            this.mname.DataPropertyName = "mname";
            this.mname.HeaderText = "材料名称";
            this.mname.Name = "mname";
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "材料型号";
            this.model.Name = "model";
            // 
            // scale
            // 
            this.scale.DataPropertyName = "scale";
            this.scale.HeaderText = "配合比定额";
            this.scale.Name = "scale";
            // 
            // pname
            // 
            this.pname.DataPropertyName = "pname";
            this.pname.HeaderText = "产品名称";
            this.pname.Name = "pname";
            // 
            // pmodel
            // 
            this.pmodel.DataPropertyName = "pmodel";
            this.pmodel.HeaderText = "产品型号";
            this.pmodel.Name = "pmodel";
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "产品产量";
            this.quantity.Name = "quantity";
            // 
            // dataSource
            // 
            this.dataSource.DataPropertyName = "dataSource";
            this.dataSource.HeaderText = "数据来源";
            this.dataSource.Name = "dataSource";
            // 
            // consumption
            // 
            this.consumption.DataPropertyName = "consumption";
            this.consumption.HeaderText = "消耗量";
            this.consumption.Name = "consumption";
            // 
            // ename
            // 
            this.ename.DataPropertyName = "ename";
            this.ename.HeaderText = "设备名称";
            this.ename.Name = "ename";
            // 
            // pnid
            // 
            this.pnid.DataPropertyName = "pnid";
            this.pnid.HeaderText = "pnid";
            this.pnid.Name = "pnid";
            this.pnid.Visible = false;
            // 
            // pmid
            // 
            this.pmid.DataPropertyName = "pmid";
            this.pmid.HeaderText = "pmid";
            this.pmid.Name = "pmid";
            this.pmid.Visible = false;
            // 
            // mnid
            // 
            this.mnid.DataPropertyName = "mnid";
            this.mnid.HeaderText = "mnid";
            this.mnid.Name = "mnid";
            this.mnid.Visible = false;
            // 
            // mmid
            // 
            this.mmid.DataPropertyName = "mmid";
            this.mmid.HeaderText = "mmid";
            this.mmid.Name = "mmid";
            this.mmid.Visible = false;
            // 
            // eiid
            // 
            this.eiid.DataPropertyName = "eiid";
            this.eiid.HeaderText = "eiid";
            this.eiid.Name = "eiid";
            this.eiid.Visible = false;
            // 
            // FrmRawMaterialConsumption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 536);
            this.Controls.Add(this.dgv_MaterialConsumption);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRawMaterialConsumption";
            this.Tag = "FrmRawMaterialConsumption";
            this.Text = "原材料消耗";
            this.Load += new System.EventHandler(this.FrmRawMaterialConsumption_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MaterialConsumption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_productKind;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.ComboBox cmb_equipmentInfo;
        private System.Windows.Forms.ComboBox cmb_productModel;
        private System.Windows.Forms.ComboBox cmb_productName;
        private System.Windows.Forms.ComboBox cmb_materialModel;
        private System.Windows.Forms.ComboBox cmb_materialName;
        private System.Windows.Forms.ComboBox cmb_materialKind;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dgv_MaterialConsumption;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity1;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity2;
        private System.Windows.Forms.DataGridViewTextBoxColumn produceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn mname;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn scale;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn pmodel;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumption;
        private System.Windows.Forms.DataGridViewTextBoxColumn ename;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pmid;
        private System.Windows.Forms.DataGridViewTextBoxColumn mnid;
        private System.Windows.Forms.DataGridViewTextBoxColumn mmid;
        private System.Windows.Forms.DataGridViewTextBoxColumn eiid;


    }
}