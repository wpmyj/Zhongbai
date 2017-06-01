namespace DasherStation.equipment
{
    partial class FrmEquipmentFillOil
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
            this.gbSingle = new System.Windows.Forms.GroupBox();
            this.cbxOilSort = new System.Windows.Forms.ComboBox();
            this.cbxOilModel = new System.Windows.Forms.ComboBox();
            this.cbxOilName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.cbxENO = new System.Windows.Forms.ComboBox();
            this.cbxFillOilMan = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFNO = new System.Windows.Forms.TextBox();
            this.txtOilQuantity = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.cbxOilUnit = new System.Windows.Forms.ComboBox();
            this.dtpFillOilDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbGather = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fillOilDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oilName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oilModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fillOilMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dasherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtQueryStr = new System.Windows.Forms.TextBox();
            this.cbxQuery = new System.Windows.Forms.ComboBox();
            this.gbSingle.SuspendLayout();
            this.gbGather.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSingle
            // 
            this.gbSingle.BackColor = System.Drawing.Color.Transparent;
            this.gbSingle.Controls.Add(this.cbxOilSort);
            this.gbSingle.Controls.Add(this.cbxOilModel);
            this.gbSingle.Controls.Add(this.cbxOilName);
            this.gbSingle.Controls.Add(this.label8);
            this.gbSingle.Controls.Add(this.txtModel);
            this.gbSingle.Controls.Add(this.txtName);
            this.gbSingle.Controls.Add(this.txtSort);
            this.gbSingle.Controls.Add(this.cbxENO);
            this.gbSingle.Controls.Add(this.cbxFillOilMan);
            this.gbSingle.Controls.Add(this.label15);
            this.gbSingle.Controls.Add(this.txtRemark);
            this.gbSingle.Controls.Add(this.label14);
            this.gbSingle.Controls.Add(this.btnNew);
            this.gbSingle.Controls.Add(this.label12);
            this.gbSingle.Controls.Add(this.txtFNO);
            this.gbSingle.Controls.Add(this.txtOilQuantity);
            this.gbSingle.Controls.Add(this.txtUnitPrice);
            this.gbSingle.Controls.Add(this.cbxOilUnit);
            this.gbSingle.Controls.Add(this.dtpFillOilDate);
            this.gbSingle.Controls.Add(this.label13);
            this.gbSingle.Controls.Add(this.label11);
            this.gbSingle.Controls.Add(this.label10);
            this.gbSingle.Controls.Add(this.label9);
            this.gbSingle.Controls.Add(this.label7);
            this.gbSingle.Controls.Add(this.label6);
            this.gbSingle.Controls.Add(this.label5);
            this.gbSingle.Controls.Add(this.label4);
            this.gbSingle.Controls.Add(this.label3);
            this.gbSingle.Controls.Add(this.label2);
            this.gbSingle.Controls.Add(this.btnDelete);
            this.gbSingle.Location = new System.Drawing.Point(3, 50);
            this.gbSingle.Name = "gbSingle";
            this.gbSingle.Size = new System.Drawing.Size(840, 200);
            this.gbSingle.TabIndex = 0;
            this.gbSingle.TabStop = false;
            this.gbSingle.Text = "加油信息";
            // 
            // cbxOilSort
            // 
            this.cbxOilSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOilSort.FormattingEnabled = true;
            this.cbxOilSort.Location = new System.Drawing.Point(281, 51);
            this.cbxOilSort.Name = "cbxOilSort";
            this.cbxOilSort.Size = new System.Drawing.Size(121, 20);
            this.cbxOilSort.TabIndex = 52;
            this.cbxOilSort.Tag = "E";
            // 
            // cbxOilModel
            // 
            this.cbxOilModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOilModel.FormattingEnabled = true;
            this.cbxOilModel.Location = new System.Drawing.Point(693, 50);
            this.cbxOilModel.Name = "cbxOilModel";
            this.cbxOilModel.Size = new System.Drawing.Size(121, 20);
            this.cbxOilModel.TabIndex = 51;
            this.cbxOilModel.Tag = "E";
            // 
            // cbxOilName
            // 
            this.cbxOilName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOilName.FormattingEnabled = true;
            this.cbxOilName.Location = new System.Drawing.Point(485, 50);
            this.cbxOilName.Name = "cbxOilName";
            this.cbxOilName.Size = new System.Drawing.Size(121, 20);
            this.cbxOilName.TabIndex = 50;
            this.cbxOilName.Tag = "E";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 48;
            this.label8.Text = "燃油种类";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(693, 19);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(121, 21);
            this.txtModel.TabIndex = 47;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(485, 20);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(121, 21);
            this.txtName.TabIndex = 46;
            // 
            // txtSort
            // 
            this.txtSort.Location = new System.Drawing.Point(281, 20);
            this.txtSort.Name = "txtSort";
            this.txtSort.ReadOnly = true;
            this.txtSort.Size = new System.Drawing.Size(121, 21);
            this.txtSort.TabIndex = 45;
            // 
            // cbxENO
            // 
            this.cbxENO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxENO.FormattingEnabled = true;
            this.cbxENO.Location = new System.Drawing.Point(76, 20);
            this.cbxENO.Name = "cbxENO";
            this.cbxENO.Size = new System.Drawing.Size(121, 20);
            this.cbxENO.TabIndex = 35;
            this.cbxENO.Tag = "E";
            this.cbxENO.SelectionChangeCommitted += new System.EventHandler(this.cbxENO_SelectionChangeCommitted);
            // 
            // cbxFillOilMan
            // 
            this.cbxFillOilMan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFillOilMan.FormattingEnabled = true;
            this.cbxFillOilMan.Location = new System.Drawing.Point(693, 80);
            this.cbxFillOilMan.Name = "cbxFillOilMan";
            this.cbxFillOilMan.Size = new System.Drawing.Size(121, 20);
            this.cbxFillOilMan.TabIndex = 34;
            this.cbxFillOilMan.Tag = "E";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(635, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 33;
            this.label15.Text = "加油人";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(76, 112);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(530, 42);
            this.txtRemark.TabIndex = 32;
            this.txtRemark.Tag = "S";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 31;
            this.label14.Text = "备注";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(633, 160);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 30;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
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
            // txtFNO
            // 
            this.txtFNO.Location = new System.Drawing.Point(689, 133);
            this.txtFNO.Name = "txtFNO";
            this.txtFNO.Size = new System.Drawing.Size(121, 21);
            this.txtFNO.TabIndex = 24;
            this.txtFNO.Tag = "";
            this.txtFNO.Visible = false;
            // 
            // txtOilQuantity
            // 
            this.txtOilQuantity.Location = new System.Drawing.Point(485, 79);
            this.txtOilQuantity.Name = "txtOilQuantity";
            this.txtOilQuantity.Size = new System.Drawing.Size(121, 21);
            this.txtOilQuantity.TabIndex = 22;
            this.txtOilQuantity.Tag = "EF";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(281, 79);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(121, 21);
            this.txtUnitPrice.TabIndex = 21;
            this.txtUnitPrice.Tag = "EF";
            // 
            // cbxOilUnit
            // 
            this.cbxOilUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOilUnit.FormattingEnabled = true;
            this.cbxOilUnit.Items.AddRange(new object[] {
            "升",
            "公斤"});
            this.cbxOilUnit.Location = new System.Drawing.Point(77, 79);
            this.cbxOilUnit.Name = "cbxOilUnit";
            this.cbxOilUnit.Size = new System.Drawing.Size(121, 20);
            this.cbxOilUnit.TabIndex = 20;
            this.cbxOilUnit.Tag = "E";
            // 
            // dtpFillOilDate
            // 
            this.dtpFillOilDate.Location = new System.Drawing.Point(77, 50);
            this.dtpFillOilDate.Name = "dtpFillOilDate";
            this.dtpFillOilDate.Size = new System.Drawing.Size(120, 21);
            this.dtpFillOilDate.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(219, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "单价";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "计量单位";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(630, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "文档编号";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(426, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "加油数量";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(634, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "燃油型号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(427, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "燃油名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(634, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "设备规格";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "设备名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "设备类别";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "加油日期";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(736, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(738, 565);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbGather
            // 
            this.gbGather.BackColor = System.Drawing.Color.Transparent;
            this.gbGather.Controls.Add(this.dgvDetail);
            this.gbGather.Location = new System.Drawing.Point(3, 256);
            this.gbGather.Name = "gbGather";
            this.gbGather.Size = new System.Drawing.Size(840, 296);
            this.gbGather.TabIndex = 1;
            this.gbGather.TabStop = false;
            this.gbGather.Text = "加油信息列表";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.sort,
            this.name,
            this.model,
            this.fillOilDate,
            this.oilName,
            this.oilModel,
            this.quantity,
            this.unit,
            this.sum,
            this.unitPrice,
            this.fillOilMan,
            this.fno,
            this.inputDate,
            this.dasherName,
            this.inputMan,
            this.remark,
            this.mId});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(834, 276);
            this.dgvDetail.TabIndex = 0;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            this.no.HeaderText = "设备编号";
            this.no.Name = "no";
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "设备类别";
            this.sort.Name = "sort";
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "设备名称";
            this.name.Name = "name";
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "设备型号";
            this.model.Name = "model";
            // 
            // fillOilDate
            // 
            this.fillOilDate.DataPropertyName = "fillOilDate";
            this.fillOilDate.HeaderText = "加油日期";
            this.fillOilDate.Name = "fillOilDate";
            // 
            // oilName
            // 
            this.oilName.DataPropertyName = "Name1";
            this.oilName.HeaderText = "燃油名称";
            this.oilName.Name = "oilName";
            // 
            // oilModel
            // 
            this.oilModel.DataPropertyName = "Model1";
            this.oilModel.HeaderText = "燃油型号";
            this.oilModel.Name = "oilModel";
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "加油数量";
            this.quantity.Name = "quantity";
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            this.unit.HeaderText = "计量单位";
            this.unit.Name = "unit";
            // 
            // sum
            // 
            this.sum.DataPropertyName = "sum";
            this.sum.HeaderText = "金额";
            this.sum.Name = "sum";
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            this.unitPrice.HeaderText = "单价";
            this.unitPrice.Name = "unitPrice";
            // 
            // fillOilMan
            // 
            this.fillOilMan.DataPropertyName = "fillOilMan";
            this.fillOilMan.HeaderText = "加油人";
            this.fillOilMan.Name = "fillOilMan";
            // 
            // fno
            // 
            this.fno.DataPropertyName = "fno";
            this.fno.HeaderText = "文档编号";
            this.fno.Name = "fno";
            this.fno.Visible = false;
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.HeaderText = "录入记录时间";
            this.inputDate.Name = "inputDate";
            // 
            // dasherName
            // 
            this.dasherName.DataPropertyName = "dasherName";
            this.dasherName.HeaderText = "单位名称";
            this.dasherName.Name = "dasherName";
            this.dasherName.Visible = false;
            // 
            // inputMan
            // 
            this.inputMan.DataPropertyName = "inputMan";
            this.inputMan.HeaderText = "录入人";
            this.inputMan.Name = "inputMan";
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            // 
            // mId
            // 
            this.mId.DataPropertyName = "mId";
            this.mId.HeaderText = "mId";
            this.mId.Name = "mId";
            this.mId.Visible = false;
            // 
            // gbSearch
            // 
            this.gbSearch.BackColor = System.Drawing.Color.Transparent;
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.btnQuery);
            this.gbSearch.Controls.Add(this.txtQueryStr);
            this.gbSearch.Controls.Add(this.cbxQuery);
            this.gbSearch.Location = new System.Drawing.Point(3, -1);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(840, 48);
            this.gbSearch.TabIndex = 3;
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
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(735, 15);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQueryStr
            // 
            this.txtQueryStr.Location = new System.Drawing.Point(221, 17);
            this.txtQueryStr.Name = "txtQueryStr";
            this.txtQueryStr.Size = new System.Drawing.Size(121, 21);
            this.txtQueryStr.TabIndex = 1;
            this.txtQueryStr.Tag = "S";
            // 
            // cbxQuery
            // 
            this.cbxQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuery.FormattingEnabled = true;
            this.cbxQuery.Items.AddRange(new object[] {
            "设备编号",
            "设备类别",
            "设备名称",
            "规格型号"});
            this.cbxQuery.Location = new System.Drawing.Point(77, 17);
            this.cbxQuery.Name = "cbxQuery";
            this.cbxQuery.Size = new System.Drawing.Size(121, 20);
            this.cbxQuery.TabIndex = 0;
            // 
            // FrmEquipmentFillOil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 600);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbSingle);
            this.Controls.Add(this.gbGather);
            this.Controls.Add(this.btnSave);
            this.Name = "FrmEquipmentFillOil";
            this.Tag = "FrmEquipmentFillOil";
            this.Text = "设备加油记录";
            this.Load += new System.EventHandler(this.FrmEquipmentFillOil_Load);
            this.gbSingle.ResumeLayout(false);
            this.gbSingle.PerformLayout();
            this.gbGather.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSingle;
        private System.Windows.Forms.GroupBox gbGather;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtQueryStr;
        private System.Windows.Forms.ComboBox cbxQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpFillOilDate;
        private System.Windows.Forms.TextBox txtOilQuantity;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.ComboBox cbxOilUnit;
        private System.Windows.Forms.TextBox txtFNO;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxFillOilMan;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxENO;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSort;
        private System.Windows.Forms.ComboBox cbxOilModel;
        private System.Windows.Forms.ComboBox cbxOilName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxOilSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn fillOilDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn oilName;
        private System.Windows.Forms.DataGridViewTextBoxColumn oilModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn fillOilMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn fno;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dasherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn mId;

    }
}