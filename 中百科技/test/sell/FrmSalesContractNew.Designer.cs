namespace DasherStation.sell
{
    partial class FrmSalesContractNew
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
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.cbxCiId = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtScNo = new System.Windows.Forms.TextBox();
            this.cbxProducer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxPModel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxPName = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtnHT = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvdetail = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmodle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cbxPKind = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtminQuantity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSupplycNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbtnCHT = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxScNo = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(109, 95);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 21);
            this.dtpEndDate.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 32;
            this.label10.Text = "结束时间";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(359, 95);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 21);
            this.dtpStartDate.TabIndex = 31;
            // 
            // txtSum
            // 
            this.txtSum.Enabled = false;
            this.txtSum.Location = new System.Drawing.Point(359, 67);
            this.txtSum.Name = "txtSum";
            this.txtSum.Size = new System.Drawing.Size(120, 21);
            this.txtSum.TabIndex = 25;
            this.txtSum.Tag = "F";
            // 
            // cbxCiId
            // 
            this.cbxCiId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCiId.FormattingEnabled = true;
            this.cbxCiId.Location = new System.Drawing.Point(602, 41);
            this.cbxCiId.Name = "cbxCiId";
            this.cbxCiId.Size = new System.Drawing.Size(121, 20);
            this.cbxCiId.TabIndex = 1;
            this.cbxCiId.Tag = "S";
            this.cbxCiId.SelectionChangeCommitted += new System.EventHandler(this.cbxCiId_SelectionChangeCommitted);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(359, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 21);
            this.txtName.TabIndex = 24;
            this.txtName.Tag = "S";
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(279, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "合同名称";
            // 
            // txtScNo
            // 
            this.txtScNo.Location = new System.Drawing.Point(109, 40);
            this.txtScNo.Name = "txtScNo";
            this.txtScNo.Size = new System.Drawing.Size(120, 21);
            this.txtScNo.TabIndex = 15;
            this.txtScNo.Tag = "ES";
            this.txtScNo.Leave += new System.EventHandler(this.txtScNo_Leave);
            // 
            // cbxProducer
            // 
            this.cbxProducer.AllowDrop = true;
            this.cbxProducer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProducer.FormattingEnabled = true;
            this.cbxProducer.Location = new System.Drawing.Point(109, 68);
            this.cbxProducer.Name = "cbxProducer";
            this.cbxProducer.Size = new System.Drawing.Size(120, 20);
            this.cbxProducer.TabIndex = 11;
            this.cbxProducer.Tag = "S";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(537, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "客户名称";
            // 
            // cbxPModel
            // 
            this.cbxPModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPModel.FormattingEnabled = true;
            this.cbxPModel.Location = new System.Drawing.Point(352, 19);
            this.cbxPModel.Name = "cbxPModel";
            this.cbxPModel.Size = new System.Drawing.Size(120, 20);
            this.cbxPModel.TabIndex = 35;
            this.cbxPModel.Tag = "E";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "产品名称";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(279, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 34;
            this.label11.Text = "产品规格";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "制作人";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "预计总额";
            // 
            // cbxPName
            // 
            this.cbxPName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPName.FormattingEnabled = true;
            this.cbxPName.Location = new System.Drawing.Point(89, 49);
            this.cbxPName.Name = "cbxPName";
            this.cbxPName.Size = new System.Drawing.Size(120, 20);
            this.cbxPName.TabIndex = 32;
            this.cbxPName.Tag = "E";
            this.cbxPName.SelectionChangeCommitted += new System.EventHandler(this.cbxPName_SelectionChangeCommitted);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(649, 49);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "删除明细";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "合同编号";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(604, 18);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(120, 21);
            this.txtUnitPrice.TabIndex = 29;
            this.txtUnitPrice.Tag = "F";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "销售单价";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(624, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 39);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(539, 49);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "新增明细";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "合同类型";
            // 
            // rbtnHT
            // 
            this.rbtnHT.AutoSize = true;
            this.rbtnHT.Checked = true;
            this.rbtnHT.Location = new System.Drawing.Point(91, 19);
            this.rbtnHT.Name = "rbtnHT";
            this.rbtnHT.Size = new System.Drawing.Size(71, 16);
            this.rbtnHT.TabIndex = 38;
            this.rbtnHT.TabStop = true;
            this.rbtnHT.Text = "一般合同";
            this.rbtnHT.UseVisualStyleBackColor = true;
            this.rbtnHT.CheckedChanged += new System.EventHandler(this.rbtnHT_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 568);
            this.panel1.TabIndex = 1;
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
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbxPModel);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbxPName);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.txtUnitPrice);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.dgvdetail);
            this.groupBox2.Controls.Add(this.txtQuantity);
            this.groupBox2.Controls.Add(this.cbxPKind);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(3, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(747, 402);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "合同明细信息";
            // 
            // dgvdetail
            // 
            this.dgvdetail.AllowUserToAddRows = false;
            this.dgvdetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvdetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdetail.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.pid,
            this.pkind,
            this.pname,
            this.pmodle,
            this.quantity,
            this.unitPrice,
            this.inputDate,
            this.finishMark,
            this.inputMan,
            this.备注});
            this.dgvdetail.Location = new System.Drawing.Point(3, 78);
            this.dgvdetail.Name = "dgvdetail";
            this.dgvdetail.ReadOnly = true;
            this.dgvdetail.RowTemplate.Height = 23;
            this.dgvdetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdetail.Size = new System.Drawing.Size(740, 272);
            this.dgvdetail.TabIndex = 21;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // pid
            // 
            this.pid.DataPropertyName = "pid";
            this.pid.HeaderText = "pid";
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            this.pid.Visible = false;
            // 
            // pkind
            // 
            this.pkind.DataPropertyName = "sort";
            this.pkind.HeaderText = "产品种类";
            this.pkind.Name = "pkind";
            this.pkind.ReadOnly = true;
            this.pkind.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // pname
            // 
            this.pname.DataPropertyName = "name";
            this.pname.HeaderText = "产品名称";
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            this.pname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // pmodle
            // 
            this.pmodle.DataPropertyName = "model";
            this.pmodle.HeaderText = "产品型号";
            this.pmodle.Name = "pmodle";
            this.pmodle.ReadOnly = true;
            this.pmodle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "销售数量";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            this.unitPrice.HeaderText = "销售单价";
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.ReadOnly = true;
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.HeaderText = "录入时间";
            this.inputDate.Name = "inputDate";
            this.inputDate.ReadOnly = true;
            // 
            // finishMark
            // 
            this.finishMark.DataPropertyName = "finishMark";
            this.finishMark.HeaderText = "状态";
            this.finishMark.Name = "finishMark";
            this.finishMark.ReadOnly = true;
            // 
            // inputMan
            // 
            this.inputMan.DataPropertyName = "inputMan";
            this.inputMan.HeaderText = "inputMan";
            this.inputMan.Name = "inputMan";
            this.inputMan.ReadOnly = true;
            this.inputMan.Visible = false;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "remark";
            this.备注.HeaderText = "remark";
            this.备注.Name = "备注";
            this.备注.ReadOnly = true;
            this.备注.Visible = false;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(352, 48);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(120, 21);
            this.txtQuantity.TabIndex = 18;
            this.txtQuantity.Tag = "F";
            // 
            // cbxPKind
            // 
            this.cbxPKind.BackColor = System.Drawing.SystemColors.Window;
            this.cbxPKind.FormattingEnabled = true;
            this.cbxPKind.Location = new System.Drawing.Point(89, 19);
            this.cbxPKind.Name = "cbxPKind";
            this.cbxPKind.Size = new System.Drawing.Size(120, 20);
            this.cbxPKind.TabIndex = 12;
            this.cbxPKind.Tag = "E";
            this.cbxPKind.SelectionChangeCommitted += new System.EventHandler(this.cbxPKind_SelectionChangeCommitted);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(279, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 4;
            this.label17.Text = "销售数量";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "产品种类";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtminQuantity);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSupplycNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.rbtnCHT);
            this.groupBox1.Controls.Add(this.rbtnHT);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.txtSum);
            this.groupBox1.Controls.Add(this.cbxCiId);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cbxProducer);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cbxScNo);
            this.groupBox1.Controls.Add(this.txtScNo);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "合同基本信息";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "拌和站"});
            this.comboBox1.Location = new System.Drawing.Point(602, 96);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 46;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(537, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 45;
            this.label13.Text = "运输方";
            // 
            // txtminQuantity
            // 
            this.txtminQuantity.Enabled = false;
            this.txtminQuantity.Location = new System.Drawing.Point(602, 67);
            this.txtminQuantity.Name = "txtminQuantity";
            this.txtminQuantity.Size = new System.Drawing.Size(122, 21);
            this.txtminQuantity.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(537, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 43;
            this.label9.Text = "销售总量";
            // 
            // txtSupplycNo
            // 
            this.txtSupplycNo.Location = new System.Drawing.Point(109, 122);
            this.txtSupplycNo.Name = "txtSupplycNo";
            this.txtSupplycNo.Size = new System.Drawing.Size(120, 21);
            this.txtSupplycNo.TabIndex = 42;
            this.txtSupplycNo.Tag = "";
            this.txtSupplycNo.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 41;
            this.label8.Text = "补充合同编号";
            this.label8.Visible = false;
            // 
            // rbtnCHT
            // 
            this.rbtnCHT.AutoSize = true;
            this.rbtnCHT.Location = new System.Drawing.Point(168, 19);
            this.rbtnCHT.Name = "rbtnCHT";
            this.rbtnCHT.Size = new System.Drawing.Size(71, 16);
            this.rbtnCHT.TabIndex = 39;
            this.rbtnCHT.Text = "补充合同";
            this.rbtnCHT.UseVisualStyleBackColor = true;
            this.rbtnCHT.Click += new System.EventHandler(this.rbtnCHT_Click);
            this.rbtnCHT.CheckedChanged += new System.EventHandler(this.rbtnCHT_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(279, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "开始时间";
            // 
            // cbxScNo
            // 
            this.cbxScNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxScNo.FormattingEnabled = true;
            this.cbxScNo.Location = new System.Drawing.Point(109, 40);
            this.cbxScNo.Name = "cbxScNo";
            this.cbxScNo.Size = new System.Drawing.Size(120, 20);
            this.cbxScNo.TabIndex = 40;
            this.cbxScNo.Tag = "E";
            this.cbxScNo.Visible = false;
            this.cbxScNo.SelectionChangeCommitted += new System.EventHandler(this.cbxScNo_SelectionChangeCommitted);
            // 
            // FrmSalesContractNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 568);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSalesContractNew";
            this.Tag = "FrmSalesContractNew";
            this.Text = "销售合同";
            this.Load += new System.EventHandler(this.FrmSalesContractNew_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.ComboBox cbxCiId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtScNo;
        private System.Windows.Forms.ComboBox cbxProducer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxPModel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxPName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnHT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.ComboBox cbxPKind;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnCHT;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxScNo;
        private System.Windows.Forms.DataGridView dgvdetail;
        private System.Windows.Forms.TextBox txtSupplycNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtminQuantity;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkind;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn pmodle;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
    }
}