namespace DasherStation.stock
{
    partial class FrmPurchasingContractNew
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_detail = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbm_materialModel = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_del = new System.Windows.Forms.Button();
            this.txtunitPrice = new System.Windows.Forms.TextBox();
            this.cbm_materialInformation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_detailAdd = new System.Windows.Forms.Button();
            this.txtquantity = new System.Windows.Forms.TextBox();
            this.cbm_materialKind = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtno2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtno = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtminQuantity = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpendDate = new System.Windows.Forms.DateTimePicker();
            this.txtsquareMode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpstartDate = new System.Windows.Forms.DateTimePicker();
            this.txtsum = new System.Windows.Forms.TextBox();
            this.cbm_providerInfo = new System.Windows.Forms.ComboBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_personnelInfo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 568);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(753, 568);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_detail);
            this.groupBox2.Controls.Add(this.cbm_materialModel);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btn_del);
            this.groupBox2.Controls.Add(this.txtunitPrice);
            this.groupBox2.Controls.Add(this.cbm_materialInformation);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btn_save);
            this.groupBox2.Controls.Add(this.btn_detailAdd);
            this.groupBox2.Controls.Add(this.txtquantity);
            this.groupBox2.Controls.Add(this.cbm_materialKind);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(3, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(742, 409);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "合同明细信息";
            // 
            // dgv_detail
            // 
            this.dgv_detail.AllowUserToAddRows = false;
            this.dgv_detail.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.mid,
            this.sort,
            this.materialInformation,
            this.materialModel,
            this.quantity,
            this.unitPrice,
            this.inputman,
            this.InputDate,
            this.finishMark});
            this.dgv_detail.Location = new System.Drawing.Point(6, 79);
            this.dgv_detail.Name = "dgv_detail";
            this.dgv_detail.ReadOnly = true;
            this.dgv_detail.RowTemplate.Height = 23;
            this.dgv_detail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_detail.Size = new System.Drawing.Size(724, 279);
            this.dgv_detail.TabIndex = 21;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 68;
            // 
            // mid
            // 
            this.mid.DataPropertyName = "mid";
            this.mid.HeaderText = "mid";
            this.mid.Name = "mid";
            this.mid.ReadOnly = true;
            this.mid.Visible = false;
            this.mid.Width = 68;
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "材料种类";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            // 
            // materialInformation
            // 
            this.materialInformation.DataPropertyName = "materialInformation";
            this.materialInformation.HeaderText = "材料名称";
            this.materialInformation.Name = "materialInformation";
            this.materialInformation.ReadOnly = true;
            // 
            // materialModel
            // 
            this.materialModel.DataPropertyName = "materialModel";
            this.materialModel.HeaderText = "材料规格";
            this.materialModel.Name = "materialModel";
            this.materialModel.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "采购数量";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            this.unitPrice.HeaderText = "采购单价";
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.ReadOnly = true;
            // 
            // inputman
            // 
            this.inputman.DataPropertyName = "inputman";
            this.inputman.HeaderText = "inputman";
            this.inputman.Name = "inputman";
            this.inputman.ReadOnly = true;
            this.inputman.Visible = false;
            this.inputman.Width = 68;
            // 
            // InputDate
            // 
            this.InputDate.DataPropertyName = "InputDate";
            this.InputDate.HeaderText = "录入时间";
            this.InputDate.Name = "InputDate";
            this.InputDate.ReadOnly = true;
            // 
            // finishMark
            // 
            this.finishMark.DataPropertyName = "finishMark";
            this.finishMark.HeaderText = "状态";
            this.finishMark.Name = "finishMark";
            this.finishMark.ReadOnly = true;
            // 
            // cbm_materialModel
            // 
            this.cbm_materialModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbm_materialModel.FormattingEnabled = true;
            this.cbm_materialModel.Location = new System.Drawing.Point(321, 20);
            this.cbm_materialModel.Name = "cbm_materialModel";
            this.cbm_materialModel.Size = new System.Drawing.Size(121, 20);
            this.cbm_materialModel.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(260, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 34;
            this.label11.Text = "材料规格";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "材料名称";
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(642, 50);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 31;
            this.btn_del.Text = "删除明细";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // txtunitPrice
            // 
            this.txtunitPrice.Location = new System.Drawing.Point(595, 19);
            this.txtunitPrice.Name = "txtunitPrice";
            this.txtunitPrice.Size = new System.Drawing.Size(122, 21);
            this.txtunitPrice.TabIndex = 29;
            this.txtunitPrice.Leave += new System.EventHandler(this.txtunitPrice_Leave);
            // 
            // cbm_materialInformation
            // 
            this.cbm_materialInformation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbm_materialInformation.FormattingEnabled = true;
            this.cbm_materialInformation.Location = new System.Drawing.Point(75, 49);
            this.cbm_materialInformation.Name = "cbm_materialInformation";
            this.cbm_materialInformation.Size = new System.Drawing.Size(121, 20);
            this.cbm_materialInformation.TabIndex = 32;
            this.cbm_materialInformation.SelectionChangeCommitted += new System.EventHandler(this.cbm_materialInformation_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(516, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "采购单价";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(614, 363);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(116, 39);
            this.btn_save.TabIndex = 25;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_detailAdd
            // 
            this.btn_detailAdd.Location = new System.Drawing.Point(518, 50);
            this.btn_detailAdd.Name = "btn_detailAdd";
            this.btn_detailAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_detailAdd.TabIndex = 22;
            this.btn_detailAdd.Text = "新增明细";
            this.btn_detailAdd.UseVisualStyleBackColor = true;
            this.btn_detailAdd.Click += new System.EventHandler(this.btn_detailAdd_Click);
            // 
            // txtquantity
            // 
            this.txtquantity.Location = new System.Drawing.Point(321, 49);
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(121, 21);
            this.txtquantity.TabIndex = 18;
            this.txtquantity.Leave += new System.EventHandler(this.txtquantity_Leave);
            // 
            // cbm_materialKind
            // 
            this.cbm_materialKind.BackColor = System.Drawing.SystemColors.Window;
            this.cbm_materialKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbm_materialKind.FormattingEnabled = true;
            this.cbm_materialKind.Location = new System.Drawing.Point(75, 20);
            this.cbm_materialKind.Name = "cbm_materialKind";
            this.cbm_materialKind.Size = new System.Drawing.Size(121, 20);
            this.cbm_materialKind.TabIndex = 12;
            this.cbm_materialKind.SelectionChangeCommitted += new System.EventHandler(this.cbm_materialKind_SelectionChangeCommitted);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(259, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 4;
            this.label17.Text = "采购数量";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "材料种类";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtno2);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtno);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.rdb2);
            this.groupBox1.Controls.Add(this.rdb1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtminQuantity);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.dtpendDate);
            this.groupBox1.Controls.Add(this.txtsquareMode);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtpstartDate);
            this.groupBox1.Controls.Add(this.txtsum);
            this.groupBox1.Controls.Add(this.cbm_providerInfo);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmb_personnelInfo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "合同基本信息";
            // 
            // txtno2
            // 
            this.txtno2.Location = new System.Drawing.Point(595, 119);
            this.txtno2.Name = "txtno2";
            this.txtno2.Size = new System.Drawing.Size(122, 21);
            this.txtno2.TabIndex = 47;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(516, 123);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 12);
            this.label18.TabIndex = 46;
            this.label18.Text = "检验报告编号";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(89, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 21);
            this.textBox2.TabIndex = 45;
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(348, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 21);
            this.textBox1.TabIndex = 44;
            this.textBox1.Visible = false;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(258, 122);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 12);
            this.label16.TabIndex = 43;
            this.label16.Text = "补充合同编号";
            this.label16.Visible = false;
            // 
            // txtno
            // 
            this.txtno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtno.FormattingEnabled = true;
            this.txtno.Location = new System.Drawing.Point(89, 39);
            this.txtno.Name = "txtno";
            this.txtno.Size = new System.Drawing.Size(121, 20);
            this.txtno.TabIndex = 42;
            this.txtno.SelectionChangeCommitted += new System.EventHandler(this.txtno_SelectionChangeCommitted);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "拌和站"});
            this.comboBox1.Location = new System.Drawing.Point(89, 117);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 40;
            this.label9.Text = "运输方";
            // 
            // rdb2
            // 
            this.rdb2.AutoSize = true;
            this.rdb2.Location = new System.Drawing.Point(152, 17);
            this.rdb2.Name = "rdb2";
            this.rdb2.Size = new System.Drawing.Size(71, 16);
            this.rdb2.TabIndex = 39;
            this.rdb2.Text = "补充合同";
            this.rdb2.UseVisualStyleBackColor = true;
            this.rdb2.CheckedChanged += new System.EventHandler(this.rdb2_CheckedChanged);
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Checked = true;
            this.rdb1.Location = new System.Drawing.Point(75, 17);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(71, 16);
            this.rdb1.TabIndex = 38;
            this.rdb1.TabStop = true;
            this.rdb1.Text = "一般合同";
            this.rdb1.UseVisualStyleBackColor = true;
            this.rdb1.CheckedChanged += new System.EventHandler(this.rdb1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "合同类型";
            // 
            // txtminQuantity
            // 
            this.txtminQuantity.Enabled = false;
            this.txtminQuantity.Location = new System.Drawing.Point(595, 66);
            this.txtminQuantity.Name = "txtminQuantity";
            this.txtminQuantity.Size = new System.Drawing.Size(122, 21);
            this.txtminQuantity.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(516, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 35;
            this.label13.Text = "采购总量";
            // 
            // dtpendDate
            // 
            this.dtpendDate.Location = new System.Drawing.Point(347, 92);
            this.dtpendDate.Name = "dtpendDate";
            this.dtpendDate.Size = new System.Drawing.Size(121, 21);
            this.dtpendDate.TabIndex = 33;
            // 
            // txtsquareMode
            // 
            this.txtsquareMode.Location = new System.Drawing.Point(595, 92);
            this.txtsquareMode.Name = "txtsquareMode";
            this.txtsquareMode.Size = new System.Drawing.Size(122, 21);
            this.txtsquareMode.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 32;
            this.label10.Text = "结束时间";
            // 
            // dtpstartDate
            // 
            this.dtpstartDate.Location = new System.Drawing.Point(89, 91);
            this.dtpstartDate.Name = "dtpstartDate";
            this.dtpstartDate.Size = new System.Drawing.Size(121, 21);
            this.dtpstartDate.TabIndex = 31;
            // 
            // txtsum
            // 
            this.txtsum.Enabled = false;
            this.txtsum.Location = new System.Drawing.Point(347, 66);
            this.txtsum.Name = "txtsum";
            this.txtsum.Size = new System.Drawing.Size(121, 21);
            this.txtsum.TabIndex = 25;
            // 
            // cbm_providerInfo
            // 
            this.cbm_providerInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbm_providerInfo.FormattingEnabled = true;
            this.cbm_providerInfo.Location = new System.Drawing.Point(595, 41);
            this.cbm_providerInfo.Name = "cbm_providerInfo";
            this.cbm_providerInfo.Size = new System.Drawing.Size(122, 20);
            this.cbm_providerInfo.TabIndex = 1;
            this.cbm_providerInfo.SelectionChangeCommitted += new System.EventHandler(this.cbm_providerInfo_SelectionChangeCommitted);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(347, 40);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(121, 21);
            this.txtname.TabIndex = 24;
            this.txtname.Leave += new System.EventHandler(this.txtname_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(259, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "合同名称";
            // 
            // cmb_personnelInfo
            // 
            this.cmb_personnelInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_personnelInfo.FormattingEnabled = true;
            this.cmb_personnelInfo.Location = new System.Drawing.Point(89, 66);
            this.cmb_personnelInfo.Name = "cmb_personnelInfo";
            this.cmb_personnelInfo.Size = new System.Drawing.Size(121, 20);
            this.cmb_personnelInfo.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(516, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "结算方式";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(516, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "供应商名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "预计总额";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "合同制作人";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "合同编号";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "开始时间";
            // 
            // FrmPurchasingContractNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 568);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmPurchasingContractNew";
            this.Tag = "FrmPurchasingContractNew";
            this.Text = "采购合同";
            this.Load += new System.EventHandler(this.FrmPurchasingContractNew_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_detailAdd;
        private System.Windows.Forms.DataGridView dgv_detail;
        private System.Windows.Forms.TextBox txtquantity;
        private System.Windows.Forms.ComboBox cbm_materialKind;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_personnelInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.ComboBox cbm_providerInfo;
        private System.Windows.Forms.TextBox txtsum;
        private System.Windows.Forms.TextBox txtsquareMode;
        private System.Windows.Forms.TextBox txtunitPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpendDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpstartDate;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.ComboBox cbm_materialModel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbm_materialInformation;
        private System.Windows.Forms.TextBox txtminQuantity;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox txtno;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mid;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputman;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishMark;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtno2;
    }
}