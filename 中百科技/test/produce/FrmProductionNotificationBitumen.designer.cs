﻿namespace DasherStation.produce
{
    partial class FrmProductionNotificationBitumen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgv_proportion = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ppid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblbazhu = new System.Windows.Forms.Label();
            this.cmb_produceTeam = new System.Windows.Forms.ComboBox();
            this.txt_notifyMan = new System.Windows.Forms.TextBox();
            this.txt_ps = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_notify = new System.Windows.Forms.DateTimePicker();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.cmb_equipmentInfo = new System.Windows.Forms.ComboBox();
            this.txt_planQuantity = new System.Windows.Forms.TextBox();
            this.cmb_productModel = new System.Windows.Forms.ComboBox();
            this.cmb_productName = new System.Windows.Forms.ComboBox();
            this.cmb_productKind = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_proportionDetail = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_proportion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_proportionDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 521);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgv_proportion);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(647, 142);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "配合比通知单";
            // 
            // dgv_proportion
            // 
            this.dgv_proportion.AllowUserToAddRows = false;
            this.dgv_proportion.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_proportion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_proportion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.model,
            this.ename,
            this.inputDate,
            this.inputMan,
            this.confirmDate,
            this.remark,
            this.sort,
            this.tpid,
            this.ppid,
            this.eid,
            this.pkid,
            this.pnid,
            this.pmid});
            this.dgv_proportion.Location = new System.Drawing.Point(7, 21);
            this.dgv_proportion.MultiSelect = false;
            this.dgv_proportion.Name = "dgv_proportion";
            this.dgv_proportion.ReadOnly = true;
            this.dgv_proportion.RowTemplate.Height = 23;
            this.dgv_proportion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_proportion.Size = new System.Drawing.Size(634, 115);
            this.dgv_proportion.TabIndex = 0;
            this.dgv_proportion.SelectionChanged += new System.EventHandler(this.dgv_proportion_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "材料名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "材料规格";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            // 
            // ename
            // 
            this.ename.DataPropertyName = "ename";
            this.ename.HeaderText = "设备编号";
            this.ename.Name = "ename";
            this.ename.ReadOnly = true;
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.HeaderText = "发送时间";
            this.inputDate.Name = "inputDate";
            this.inputDate.ReadOnly = true;
            // 
            // inputMan
            // 
            this.inputMan.DataPropertyName = "inputMan";
            this.inputMan.HeaderText = "下发人";
            this.inputMan.Name = "inputMan";
            this.inputMan.ReadOnly = true;
            // 
            // confirmDate
            // 
            this.confirmDate.DataPropertyName = "confirmDate";
            this.confirmDate.HeaderText = "确认时间";
            this.confirmDate.Name = "confirmDate";
            this.confirmDate.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "sort";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            this.sort.Visible = false;
            // 
            // tpid
            // 
            this.tpid.DataPropertyName = "tpid";
            this.tpid.HeaderText = "tpid";
            this.tpid.Name = "tpid";
            this.tpid.ReadOnly = true;
            this.tpid.Visible = false;
            // 
            // ppid
            // 
            this.ppid.DataPropertyName = "ppid";
            this.ppid.HeaderText = "ppid";
            this.ppid.Name = "ppid";
            this.ppid.ReadOnly = true;
            this.ppid.Visible = false;
            // 
            // eid
            // 
            this.eid.DataPropertyName = "eid";
            this.eid.HeaderText = "eid";
            this.eid.Name = "eid";
            this.eid.ReadOnly = true;
            this.eid.Visible = false;
            // 
            // pkid
            // 
            this.pkid.DataPropertyName = "pkid";
            this.pkid.HeaderText = "pkid";
            this.pkid.Name = "pkid";
            this.pkid.ReadOnly = true;
            this.pkid.Visible = false;
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
            this.groupBox1.Controls.Add(this.lblbazhu);
            this.groupBox1.Controls.Add(this.cmb_produceTeam);
            this.groupBox1.Controls.Add(this.txt_notifyMan);
            this.groupBox1.Controls.Add(this.txt_ps);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtp_notify);
            this.groupBox1.Controls.Add(this.dtp_start);
            this.groupBox1.Controls.Add(this.cmb_equipmentInfo);
            this.groupBox1.Controls.Add(this.txt_planQuantity);
            this.groupBox1.Controls.Add(this.cmb_productModel);
            this.groupBox1.Controls.Add(this.cmb_productName);
            this.groupBox1.Controls.Add(this.cmb_productKind);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(4, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 117);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生产信息";
            // 
            // lblbazhu
            // 
            this.lblbazhu.AutoSize = true;
            this.lblbazhu.Location = new System.Drawing.Point(220, 71);
            this.lblbazhu.Name = "lblbazhu";
            this.lblbazhu.Size = new System.Drawing.Size(53, 12);
            this.lblbazhu.TabIndex = 20;
            this.lblbazhu.Text = "生产班主";
            // 
            // cmb_produceTeam
            // 
            this.cmb_produceTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_produceTeam.FormattingEnabled = true;
            this.cmb_produceTeam.Location = new System.Drawing.Point(289, 68);
            this.cmb_produceTeam.Name = "cmb_produceTeam";
            this.cmb_produceTeam.Size = new System.Drawing.Size(123, 20);
            this.cmb_produceTeam.TabIndex = 19;
            this.cmb_produceTeam.Tag = "E";
            // 
            // txt_notifyMan
            // 
            this.txt_notifyMan.Location = new System.Drawing.Point(80, 68);
            this.txt_notifyMan.Name = "txt_notifyMan";
            this.txt_notifyMan.Size = new System.Drawing.Size(121, 21);
            this.txt_notifyMan.TabIndex = 18;
            this.txt_notifyMan.Tag = "ES";
            // 
            // txt_ps
            // 
            this.txt_ps.Location = new System.Drawing.Point(80, 93);
            this.txt_ps.Name = "txt_ps";
            this.txt_ps.Size = new System.Drawing.Size(332, 21);
            this.txt_ps.TabIndex = 17;
            this.txt_ps.Tag = "S";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "备注";
            // 
            // dtp_notify
            // 
            this.dtp_notify.Location = new System.Drawing.Point(508, 67);
            this.dtp_notify.Name = "dtp_notify";
            this.dtp_notify.Size = new System.Drawing.Size(121, 21);
            this.dtp_notify.TabIndex = 15;
            // 
            // dtp_start
            // 
            this.dtp_start.Location = new System.Drawing.Point(508, 41);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(121, 21);
            this.dtp_start.TabIndex = 14;
            // 
            // cmb_equipmentInfo
            // 
            this.cmb_equipmentInfo.Enabled = false;
            this.cmb_equipmentInfo.FormattingEnabled = true;
            this.cmb_equipmentInfo.Location = new System.Drawing.Point(80, 42);
            this.cmb_equipmentInfo.Name = "cmb_equipmentInfo";
            this.cmb_equipmentInfo.Size = new System.Drawing.Size(121, 20);
            this.cmb_equipmentInfo.TabIndex = 13;
            this.cmb_equipmentInfo.Tag = "E";
            // 
            // txt_planQuantity
            // 
            this.txt_planQuantity.Location = new System.Drawing.Point(289, 42);
            this.txt_planQuantity.Name = "txt_planQuantity";
            this.txt_planQuantity.Size = new System.Drawing.Size(123, 21);
            this.txt_planQuantity.TabIndex = 11;
            this.txt_planQuantity.Tag = "EF";
            // 
            // cmb_productModel
            // 
            this.cmb_productModel.Enabled = false;
            this.cmb_productModel.FormattingEnabled = true;
            this.cmb_productModel.Location = new System.Drawing.Point(508, 14);
            this.cmb_productModel.Name = "cmb_productModel";
            this.cmb_productModel.Size = new System.Drawing.Size(121, 20);
            this.cmb_productModel.TabIndex = 10;
            this.cmb_productModel.Tag = "E";
            this.cmb_productModel.SelectionChangeCommitted += new System.EventHandler(this.cmb_productModel_SelectionChangeCommitted);
            // 
            // cmb_productName
            // 
            this.cmb_productName.Enabled = false;
            this.cmb_productName.FormattingEnabled = true;
            this.cmb_productName.Location = new System.Drawing.Point(290, 14);
            this.cmb_productName.Name = "cmb_productName";
            this.cmb_productName.Size = new System.Drawing.Size(122, 20);
            this.cmb_productName.TabIndex = 9;
            this.cmb_productName.Tag = "E";
            this.cmb_productName.SelectionChangeCommitted += new System.EventHandler(this.cmb_productName_SelectionChangeCommitted);
            // 
            // cmb_productKind
            // 
            this.cmb_productKind.Enabled = false;
            this.cmb_productKind.FormattingEnabled = true;
            this.cmb_productKind.Location = new System.Drawing.Point(80, 14);
            this.cmb_productKind.Name = "cmb_productKind";
            this.cmb_productKind.Size = new System.Drawing.Size(121, 20);
            this.cmb_productKind.TabIndex = 8;
            this.cmb_productKind.Tag = "E";
            this.cmb_productKind.SelectionChangeCommitted += new System.EventHandler(this.cmb_productKind_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(444, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "通知日期";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "通知人";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "设备编号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "开始日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "计划产量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "规格型号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "产品名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品种类";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(567, 486);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 22;
            this.button5.Text = "打印";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.dgv_proportionDetail);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(4, 279);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 201);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "生产配合比信息";
            // 
            // dgv_proportionDetail
            // 
            this.dgv_proportionDetail.AllowUserToAddRows = false;
            this.dgv_proportionDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_proportionDetail.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_proportionDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_proportionDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgv_proportionDetail.GridColor = System.Drawing.SystemColors.ControlText;
            this.dgv_proportionDetail.Location = new System.Drawing.Point(10, 20);
            this.dgv_proportionDetail.Name = "dgv_proportionDetail";
            this.dgv_proportionDetail.ReadOnly = true;
            this.dgv_proportionDetail.RowTemplate.Height = 23;
            this.dgv_proportionDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_proportionDetail.Size = new System.Drawing.Size(628, 176);
            this.dgv_proportionDetail.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "name";
            this.Column3.HeaderText = "材料名称";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "model";
            this.Column4.HeaderText = "规格型号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "proportionValue";
            this.Column5.HeaderText = "材料比例";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(471, 486);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 24;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // FrmProductionNotificationBitumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 521);
            this.Controls.Add(this.panel1);
            this.Name = "FrmProductionNotificationBitumen";
            this.Tag = "FrmProductionNotificationBitumen";
            this.Text = "改性乳化沥青通知单";
            this.Load += new System.EventHandler(this.FrmProductionNotificationBitumen_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_proportion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_proportionDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_proportionDetail;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblbazhu;
        private System.Windows.Forms.ComboBox cmb_produceTeam;
        private System.Windows.Forms.TextBox txt_notifyMan;
        private System.Windows.Forms.TextBox txt_ps;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_notify;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.ComboBox cmb_equipmentInfo;
        private System.Windows.Forms.TextBox txt_planQuantity;
        private System.Windows.Forms.ComboBox cmb_productModel;
        private System.Windows.Forms.ComboBox cmb_productName;
        private System.Windows.Forms.ComboBox cmb_productKind;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgv_proportion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn ename;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ppid;
        private System.Windows.Forms.DataGridViewTextBoxColumn eid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pmid;
    }
}