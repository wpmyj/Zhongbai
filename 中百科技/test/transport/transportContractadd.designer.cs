using System.Data;
namespace DasherStation.transport
{
    partial class transportContractadd
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
            this.btn_save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbltransportSettlementMethod = new System.Windows.Forms.Label();
            this.cmb_transportSettlementMethod = new System.Windows.Forms.ComboBox();
            this.rbttype2 = new System.Windows.Forms.RadioButton();
            this.rbttype1 = new System.Windows.Forms.RadioButton();
            this.cmb_model = new System.Windows.Forms.ComboBox();
            this.lblmodel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_kind = new System.Windows.Forms.ComboBox();
            this.dgv_transportGoods = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.site1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.site2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sid1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sid2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsmid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.cmb_site2 = new System.Windows.Forms.ComboBox();
            this.cmb_site1 = new System.Windows.Forms.ComboBox();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.txt_distance = new System.Windows.Forms.TextBox();
            this.cmb_name = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lblkind = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_sno = new System.Windows.Forms.TextBox();
            this.lbl_sno = new System.Windows.Forms.Label();
            this.cmb_no = new System.Windows.Forms.ComboBox();
            this.rbcType2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbcType1 = new System.Windows.Forms.RadioButton();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.dtp_contractEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_contractStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_contractInkDate = new System.Windows.Forms.DateTimePicker();
            this.cmb_transportUnit = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transportGoods)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 604);
            this.panel1.TabIndex = 0;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(611, 553);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(116, 39);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbltransportSettlementMethod);
            this.groupBox2.Controls.Add(this.cmb_transportSettlementMethod);
            this.groupBox2.Controls.Add(this.rbttype2);
            this.groupBox2.Controls.Add(this.rbttype1);
            this.groupBox2.Controls.Add(this.cmb_model);
            this.groupBox2.Controls.Add(this.lblmodel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmb_kind);
            this.groupBox2.Controls.Add(this.dgv_transportGoods);
            this.groupBox2.Controls.Add(this.btn_del);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.cmb_site2);
            this.groupBox2.Controls.Add(this.cmb_site1);
            this.groupBox2.Controls.Add(this.txt_price);
            this.groupBox2.Controls.Add(this.txt_distance);
            this.groupBox2.Controls.Add(this.cmb_name);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblname);
            this.groupBox2.Controls.Add(this.lblkind);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(3, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(735, 428);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "运输合同详细信息";
            // 
            // lbltransportSettlementMethod
            // 
            this.lbltransportSettlementMethod.AutoSize = true;
            this.lbltransportSettlementMethod.Location = new System.Drawing.Point(499, 81);
            this.lbltransportSettlementMethod.Name = "lbltransportSettlementMethod";
            this.lbltransportSettlementMethod.Size = new System.Drawing.Size(53, 12);
            this.lbltransportSettlementMethod.TabIndex = 43;
            this.lbltransportSettlementMethod.Text = "结算方式";
            // 
            // cmb_transportSettlementMethod
            // 
            this.cmb_transportSettlementMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_transportSettlementMethod.FormattingEnabled = true;
            this.cmb_transportSettlementMethod.Location = new System.Drawing.Point(585, 76);
            this.cmb_transportSettlementMethod.Name = "cmb_transportSettlementMethod";
            this.cmb_transportSettlementMethod.Size = new System.Drawing.Size(121, 20);
            this.cmb_transportSettlementMethod.TabIndex = 42;
            this.cmb_transportSettlementMethod.Tag = "E";
            // 
            // rbttype2
            // 
            this.rbttype2.AutoSize = true;
            this.rbttype2.Location = new System.Drawing.Point(161, 20);
            this.rbttype2.Name = "rbttype2";
            this.rbttype2.Size = new System.Drawing.Size(47, 16);
            this.rbttype2.TabIndex = 41;
            this.rbttype2.Tag = "2";
            this.rbttype2.Text = "产品";
            this.rbttype2.UseVisualStyleBackColor = true;
            // 
            // rbttype1
            // 
            this.rbttype1.AutoSize = true;
            this.rbttype1.Checked = true;
            this.rbttype1.Location = new System.Drawing.Point(97, 20);
            this.rbttype1.Name = "rbttype1";
            this.rbttype1.Size = new System.Drawing.Size(47, 16);
            this.rbttype1.TabIndex = 40;
            this.rbttype1.TabStop = true;
            this.rbttype1.Tag = "1";
            this.rbttype1.Text = "原料";
            this.rbttype1.UseVisualStyleBackColor = true;
            // 
            // cmb_model
            // 
            this.cmb_model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_model.FormattingEnabled = true;
            this.cmb_model.Location = new System.Drawing.Point(585, 46);
            this.cmb_model.Name = "cmb_model";
            this.cmb_model.Size = new System.Drawing.Size(121, 20);
            this.cmb_model.TabIndex = 39;
            this.cmb_model.Tag = "E";
            // 
            // lblmodel
            // 
            this.lblmodel.AutoSize = true;
            this.lblmodel.Location = new System.Drawing.Point(499, 49);
            this.lblmodel.Name = "lblmodel";
            this.lblmodel.Size = new System.Drawing.Size(29, 12);
            this.lblmodel.TabIndex = 38;
            this.lblmodel.Text = "规格";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 37;
            this.label5.Text = "货物类型";
            // 
            // cmb_kind
            // 
            this.cmb_kind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_kind.FormattingEnabled = true;
            this.cmb_kind.Location = new System.Drawing.Point(100, 46);
            this.cmb_kind.Name = "cmb_kind";
            this.cmb_kind.Size = new System.Drawing.Size(121, 20);
            this.cmb_kind.TabIndex = 36;
            this.cmb_kind.Tag = "E";
            // 
            // dgv_transportGoods
            // 
            this.dgv_transportGoods.AllowUserToAddRows = false;
            this.dgv_transportGoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_transportGoods.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_transportGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_transportGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.model,
            this.site1,
            this.site2,
            this.distance,
            this.price,
            this.Method,
            this.nid,
            this.mid,
            this.Type,
            this.sid1,
            this.sid2,
            this.tsmid,
            this.formula});
            this.dgv_transportGoods.Location = new System.Drawing.Point(11, 135);
            this.dgv_transportGoods.Name = "dgv_transportGoods";
            this.dgv_transportGoods.RowTemplate.Height = 23;
            this.dgv_transportGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_transportGoods.Size = new System.Drawing.Size(713, 287);
            this.dgv_transportGoods.TabIndex = 35;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "货物名称";
            this.name.Name = "name";
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "规格型号";
            this.model.Name = "model";
            // 
            // site1
            // 
            this.site1.DataPropertyName = "site1";
            this.site1.HeaderText = "起运地";
            this.site1.Name = "site1";
            this.site1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // site2
            // 
            this.site2.DataPropertyName = "site2";
            this.site2.HeaderText = "止运地";
            this.site2.Name = "site2";
            this.site2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // distance
            // 
            this.distance.DataPropertyName = "distance";
            this.distance.HeaderText = "运输距离";
            this.distance.Name = "distance";
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "运输单价";
            this.price.Name = "price";
            // 
            // Method
            // 
            this.Method.DataPropertyName = "Method";
            this.Method.HeaderText = "结算方式";
            this.Method.Name = "Method";
            this.Method.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // nid
            // 
            this.nid.DataPropertyName = "nid";
            this.nid.HeaderText = "nid";
            this.nid.Name = "nid";
            this.nid.Visible = false;
            // 
            // mid
            // 
            this.mid.DataPropertyName = "mid";
            this.mid.HeaderText = "mid";
            this.mid.Name = "mid";
            this.mid.Visible = false;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.Visible = false;
            // 
            // sid1
            // 
            this.sid1.DataPropertyName = "sid1";
            this.sid1.HeaderText = "sid1";
            this.sid1.Name = "sid1";
            this.sid1.Visible = false;
            // 
            // sid2
            // 
            this.sid2.DataPropertyName = "sid2";
            this.sid2.HeaderText = "sid2";
            this.sid2.Name = "sid2";
            this.sid2.Visible = false;
            // 
            // tsmid
            // 
            this.tsmid.DataPropertyName = "tsmid";
            this.tsmid.HeaderText = "tsmid";
            this.tsmid.Name = "tsmid";
            this.tsmid.Visible = false;
            // 
            // formula
            // 
            this.formula.DataPropertyName = "formula";
            this.formula.HeaderText = "formula";
            this.formula.Name = "formula";
            this.formula.Visible = false;
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(631, 106);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 29;
            this.btn_del.Text = "删除明细";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(548, 106);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 32;
            this.btn_add.Text = "新增明细";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // cmb_site2
            // 
            this.cmb_site2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_site2.FormattingEnabled = true;
            this.cmb_site2.Location = new System.Drawing.Point(336, 76);
            this.cmb_site2.Name = "cmb_site2";
            this.cmb_site2.Size = new System.Drawing.Size(121, 20);
            this.cmb_site2.TabIndex = 24;
            this.cmb_site2.Tag = "E";
            // 
            // cmb_site1
            // 
            this.cmb_site1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_site1.FormattingEnabled = true;
            this.cmb_site1.Location = new System.Drawing.Point(100, 76);
            this.cmb_site1.Name = "cmb_site1";
            this.cmb_site1.Size = new System.Drawing.Size(121, 20);
            this.cmb_site1.TabIndex = 23;
            this.cmb_site1.Tag = "E";
            // 
            // txt_price
            // 
            this.txt_price.Location = new System.Drawing.Point(336, 106);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(121, 21);
            this.txt_price.TabIndex = 22;
            this.txt_price.Tag = "EF";
            // 
            // txt_distance
            // 
            this.txt_distance.Location = new System.Drawing.Point(100, 106);
            this.txt_distance.Name = "txt_distance";
            this.txt_distance.Size = new System.Drawing.Size(121, 21);
            this.txt_distance.TabIndex = 21;
            this.txt_distance.Tag = "EF";
            // 
            // cmb_name
            // 
            this.cmb_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_name.FormattingEnabled = true;
            this.cmb_name.Location = new System.Drawing.Point(336, 46);
            this.cmb_name.Name = "cmb_name";
            this.cmb_name.Size = new System.Drawing.Size(121, 20);
            this.cmb_name.TabIndex = 16;
            this.cmb_name.Tag = "E";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 7;
            this.label17.Text = "运距（公里）";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(243, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 12);
            this.label16.TabIndex = 6;
            this.label16.Text = "运输单价（元）";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(243, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 5;
            this.label15.Text = "止运地";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "起运地";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(243, 49);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(29, 12);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "名称";
            // 
            // lblkind
            // 
            this.lblkind.AutoSize = true;
            this.lblkind.Location = new System.Drawing.Point(6, 49);
            this.lblkind.Name = "lblkind";
            this.lblkind.Size = new System.Drawing.Size(29, 12);
            this.lblkind.TabIndex = 0;
            this.lblkind.Text = "种类";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_sno);
            this.groupBox1.Controls.Add(this.lbl_sno);
            this.groupBox1.Controls.Add(this.cmb_no);
            this.groupBox1.Controls.Add(this.rbcType2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbcType1);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.txt_remark);
            this.groupBox1.Controls.Add(this.dtp_contractEndDate);
            this.groupBox1.Controls.Add(this.dtp_contractStartDate);
            this.groupBox1.Controls.Add(this.dtp_contractInkDate);
            this.groupBox1.Controls.Add(this.cmb_transportUnit);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运输合同基本信息";
            // 
            // txt_sno
            // 
            this.txt_sno.Location = new System.Drawing.Point(336, 18);
            this.txt_sno.Name = "txt_sno";
            this.txt_sno.Size = new System.Drawing.Size(121, 21);
            this.txt_sno.TabIndex = 33;
            this.txt_sno.Tag = "";
            this.txt_sno.Visible = false;
            // 
            // lbl_sno
            // 
            this.lbl_sno.AutoSize = true;
            this.lbl_sno.Location = new System.Drawing.Point(243, 23);
            this.lbl_sno.Name = "lbl_sno";
            this.lbl_sno.Size = new System.Drawing.Size(77, 12);
            this.lbl_sno.TabIndex = 32;
            this.lbl_sno.Text = "补充合同编号";
            this.lbl_sno.Visible = false;
            // 
            // cmb_no
            // 
            this.cmb_no.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_no.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_no.FormattingEnabled = true;
            this.cmb_no.Location = new System.Drawing.Point(100, 47);
            this.cmb_no.Name = "cmb_no";
            this.cmb_no.Size = new System.Drawing.Size(121, 20);
            this.cmb_no.TabIndex = 31;
            // 
            // rbcType2
            // 
            this.rbcType2.AutoSize = true;
            this.rbcType2.Location = new System.Drawing.Point(150, 20);
            this.rbcType2.Name = "rbcType2";
            this.rbcType2.Size = new System.Drawing.Size(71, 16);
            this.rbcType2.TabIndex = 30;
            this.rbcType2.Text = "补充合同";
            this.rbcType2.UseVisualStyleBackColor = true;
            this.rbcType2.CheckedChanged += new System.EventHandler(this.rbcType_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "合同类型";
            // 
            // rbcType1
            // 
            this.rbcType1.AutoSize = true;
            this.rbcType1.Checked = true;
            this.rbcType1.Location = new System.Drawing.Point(73, 19);
            this.rbcType1.Name = "rbcType1";
            this.rbcType1.Size = new System.Drawing.Size(71, 16);
            this.rbcType1.TabIndex = 28;
            this.rbcType1.TabStop = true;
            this.rbcType1.Text = "一般合同";
            this.rbcType1.UseVisualStyleBackColor = true;
            this.rbcType1.CheckedChanged += new System.EventHandler(this.rbcType_CheckedChanged);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(336, 47);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(121, 21);
            this.txt_name.TabIndex = 26;
            this.txt_name.Tag = "ES";
            // 
            // txt_remark
            // 
            this.txt_remark.Location = new System.Drawing.Point(336, 77);
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(121, 21);
            this.txt_remark.TabIndex = 18;
            this.txt_remark.Tag = "S";
            // 
            // dtp_contractEndDate
            // 
            this.dtp_contractEndDate.Location = new System.Drawing.Point(585, 76);
            this.dtp_contractEndDate.Name = "dtp_contractEndDate";
            this.dtp_contractEndDate.Size = new System.Drawing.Size(144, 21);
            this.dtp_contractEndDate.TabIndex = 17;
            // 
            // dtp_contractStartDate
            // 
            this.dtp_contractStartDate.Location = new System.Drawing.Point(585, 47);
            this.dtp_contractStartDate.Name = "dtp_contractStartDate";
            this.dtp_contractStartDate.Size = new System.Drawing.Size(144, 21);
            this.dtp_contractStartDate.TabIndex = 16;
            // 
            // dtp_contractInkDate
            // 
            this.dtp_contractInkDate.Location = new System.Drawing.Point(585, 19);
            this.dtp_contractInkDate.Name = "dtp_contractInkDate";
            this.dtp_contractInkDate.Size = new System.Drawing.Size(144, 21);
            this.dtp_contractInkDate.TabIndex = 15;
            // 
            // cmb_transportUnit
            // 
            this.cmb_transportUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_transportUnit.FormattingEnabled = true;
            this.cmb_transportUnit.Location = new System.Drawing.Point(100, 77);
            this.cmb_transportUnit.Name = "cmb_transportUnit";
            this.cmb_transportUnit.Size = new System.Drawing.Size(121, 20);
            this.cmb_transportUnit.TabIndex = 10;
            this.cmb_transportUnit.Tag = "E";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(243, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "备注";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(499, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "合同截止日期";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "合同生效日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(499, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "合同签订日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "运输单位名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "合同名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "合同编号";
            // 
            // transportContractadd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 604);
            this.Controls.Add(this.panel1);
            this.Name = "transportContractadd";
            this.Text = "运输合同添加";
            this.Load += new System.EventHandler(this.transportContractadd_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transportGoods)).EndInit();
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
        private System.Windows.Forms.ComboBox cmb_transportUnit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_contractInkDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.DateTimePicker dtp_contractEndDate;
        private System.Windows.Forms.DateTimePicker dtp_contractStartDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblkind;
        private System.Windows.Forms.ComboBox cmb_site2;
        private System.Windows.Forms.ComboBox cmb_site1;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.TextBox txt_distance;
        private System.Windows.Forms.ComboBox cmb_name;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgv_transportGoods;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cmb_kind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_model;
        private System.Windows.Forms.Label lblmodel;
        private System.Windows.Forms.RadioButton rbttype2;
        private System.Windows.Forms.RadioButton rbttype1;
        private System.Windows.Forms.ComboBox cmb_transportSettlementMethod;
        private System.Windows.Forms.Label lbltransportSettlementMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn site1;
        private System.Windows.Forms.DataGridViewTextBoxColumn site2;
        private System.Windows.Forms.DataGridViewTextBoxColumn distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Method;
        private System.Windows.Forms.DataGridViewTextBoxColumn nid;
        private System.Windows.Forms.DataGridViewTextBoxColumn mid;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn sid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sid2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tsmid;
        private System.Windows.Forms.DataGridViewTextBoxColumn formula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.ComboBox cmb_no;
        private System.Windows.Forms.RadioButton rbcType2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbcType1;
        private System.Windows.Forms.TextBox txt_sno;
        private System.Windows.Forms.Label lbl_sno;
    }
}