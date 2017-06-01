namespace DasherStation.produce
{
    partial class FrmProductionStatistics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_Statistics = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.badQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_all = new System.Windows.Forms.Button();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_equipmentInfo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_query = new System.Windows.Forms.Button();
            this.cmb_productName = new System.Windows.Forms.ComboBox();
            this.cmb_productKind = new System.Windows.Forms.ComboBox();
            this.cmb_productModel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Statistics)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.dgv_Statistics);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 534);
            this.panel1.TabIndex = 0;
            // 
            // dgv_Statistics
            // 
            this.dgv_Statistics.AllowUserToAddRows = false;
            this.dgv_Statistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Statistics.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_Statistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Statistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.produceDate,
            this.pname,
            this.model,
            this.ename,
            this.quantity,
            this.dataSource,
            this.goodQuantity,
            this.badQuantity,
            this.eid,
            this.pnid,
            this.pmid});
            this.dgv_Statistics.Location = new System.Drawing.Point(3, 107);
            this.dgv_Statistics.Name = "dgv_Statistics";
            this.dgv_Statistics.ReadOnly = true;
            this.dgv_Statistics.RowTemplate.Height = 23;
            this.dgv_Statistics.Size = new System.Drawing.Size(715, 422);
            this.dgv_Statistics.TabIndex = 1;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // produceDate
            // 
            this.produceDate.DataPropertyName = "produceDate";
            dataGridViewCellStyle1.Format = "D";
            dataGridViewCellStyle1.NullValue = null;
            this.produceDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.produceDate.HeaderText = "日期";
            this.produceDate.Name = "produceDate";
            this.produceDate.ReadOnly = true;
            // 
            // pname
            // 
            this.pname.DataPropertyName = "pname";
            dataGridViewCellStyle2.NullValue = null;
            this.pname.DefaultCellStyle = dataGridViewCellStyle2;
            this.pname.HeaderText = "产品名称";
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "规格型号";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            // 
            // ename
            // 
            this.ename.DataPropertyName = "ename";
            this.ename.HeaderText = "设备名称";
            this.ename.Name = "ename";
            this.ename.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            dataGridViewCellStyle3.NullValue = null;
            this.quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.quantity.HeaderText = "产量";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // dataSource
            // 
            this.dataSource.DataPropertyName = "dataSource";
            this.dataSource.HeaderText = "数据来源";
            this.dataSource.Name = "dataSource";
            this.dataSource.ReadOnly = true;
            // 
            // goodQuantity
            // 
            this.goodQuantity.DataPropertyName = "goodQuantity";
            this.goodQuantity.HeaderText = "正品数量";
            this.goodQuantity.Name = "goodQuantity";
            this.goodQuantity.ReadOnly = true;
            // 
            // badQuantity
            // 
            this.badQuantity.DataPropertyName = "badQuantity";
            this.badQuantity.HeaderText = "废品数量";
            this.badQuantity.Name = "badQuantity";
            this.badQuantity.ReadOnly = true;
            // 
            // eid
            // 
            this.eid.DataPropertyName = "eid";
            this.eid.HeaderText = "eid";
            this.eid.Name = "eid";
            this.eid.ReadOnly = true;
            this.eid.Visible = false;
            // 
            // pnid
            // 
            this.pnid.DataPropertyName = "pnid";
            this.pnid.HeaderText = "pnid";
            this.pnid.Name = "pnid";
            this.pnid.ReadOnly = true;
            this.pnid.Visible = false;
            // 
            // pmid
            // 
            this.pmid.DataPropertyName = "pmid";
            this.pmid.HeaderText = "pmid";
            this.pmid.Name = "pmid";
            this.pmid.ReadOnly = true;
            this.pmid.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_all);
            this.groupBox1.Controls.Add(this.dtp_start);
            this.groupBox1.Controls.Add(this.dtp_end);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmb_equipmentInfo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btn_query);
            this.groupBox1.Controls.Add(this.cmb_productName);
            this.groupBox1.Controls.Add(this.cmb_productKind);
            this.groupBox1.Controls.Add(this.cmb_productModel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_all
            // 
            this.btn_all.Location = new System.Drawing.Point(102, 71);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(75, 23);
            this.btn_all.TabIndex = 15;
            this.btn_all.Text = "全部";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // dtp_start
            // 
            this.dtp_start.Location = new System.Drawing.Point(91, 44);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(121, 21);
            this.dtp_start.TabIndex = 14;
            // 
            // dtp_end
            // 
            this.dtp_end.Location = new System.Drawing.Point(233, 44);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(121, 21);
            this.dtp_end.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "-";
            // 
            // cmb_equipmentInfo
            // 
            this.cmb_equipmentInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_equipmentInfo.FormattingEnabled = true;
            this.cmb_equipmentInfo.Location = new System.Drawing.Point(588, 40);
            this.cmb_equipmentInfo.Name = "cmb_equipmentInfo";
            this.cmb_equipmentInfo.Size = new System.Drawing.Size(121, 20);
            this.cmb_equipmentInfo.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(516, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "设备名称";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(631, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "打印";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(21, 71);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 8;
            this.btn_query.Text = "搜索";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // cmb_productName
            // 
            this.cmb_productName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_productName.FormattingEnabled = true;
            this.cmb_productName.Location = new System.Drawing.Point(340, 14);
            this.cmb_productName.Name = "cmb_productName";
            this.cmb_productName.Size = new System.Drawing.Size(121, 20);
            this.cmb_productName.TabIndex = 7;
            this.cmb_productName.SelectionChangeCommitted += new System.EventHandler(this.cmb_productName_SelectionChangeCommitted);
            // 
            // cmb_productKind
            // 
            this.cmb_productKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_productKind.FormattingEnabled = true;
            this.cmb_productKind.Location = new System.Drawing.Point(91, 14);
            this.cmb_productKind.Name = "cmb_productKind";
            this.cmb_productKind.Size = new System.Drawing.Size(121, 20);
            this.cmb_productKind.TabIndex = 6;
            this.cmb_productKind.SelectionChangeCommitted += new System.EventHandler(this.cmb_productKind_SelectionChangeCommitted);
            // 
            // cmb_productModel
            // 
            this.cmb_productModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_productModel.FormattingEnabled = true;
            this.cmb_productModel.Location = new System.Drawing.Point(588, 14);
            this.cmb_productModel.Name = "cmb_productModel";
            this.cmb_productModel.Size = new System.Drawing.Size(121, 20);
            this.cmb_productModel.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(516, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "规格型号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "产品名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "产品种类";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // FrmProductionStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 534);
            this.Controls.Add(this.panel1);
            this.Name = "FrmProductionStatistics";
            this.Tag = "FrmProductionStatistics";
            this.Text = "生产统计";
            this.Load += new System.EventHandler(this.FrmProductionStatistics_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Statistics)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Statistics;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.ComboBox cmb_productName;
        private System.Windows.Forms.ComboBox cmb_productKind;
        private System.Windows.Forms.ComboBox cmb_productModel;
        private System.Windows.Forms.ComboBox cmb_equipmentInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn produceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn ename;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn badQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn eid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pmid;
    }
}