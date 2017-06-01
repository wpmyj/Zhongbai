namespace DasherStation.quality
{
    partial class FrmMixtureRatioAdd
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbxProducer = new System.Windows.Forms.ComboBox();
            this.cbxPName = new System.Windows.Forms.ComboBox();
            this.dtpMadeDate = new System.Windows.Forms.DateTimePicker();
            this.cbxPModel = new System.Windows.Forms.ComboBox();
            this.cbxPsort = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtPId = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.btnSaveMain = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.gbxDetail = new System.Windows.Forms.GroupBox();
            this.cbxMaker = new System.Windows.Forms.ComboBox();
            this.cbxAddress = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbxModel = new System.Windows.Forms.ComboBox();
            this.cbxKinds = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxName = new System.Windows.Forms.ComboBox();
            this.txtRatio = new System.Windows.Forms.TextBox();
            this.txtPDId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetProportionValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox7.SuspendLayout();
            this.gbxDetail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.cbxProducer);
            this.groupBox7.Controls.Add(this.cbxPName);
            this.groupBox7.Controls.Add(this.dtpMadeDate);
            this.groupBox7.Controls.Add(this.cbxPModel);
            this.groupBox7.Controls.Add(this.cbxPsort);
            this.groupBox7.Controls.Add(this.label45);
            this.groupBox7.Controls.Add(this.label46);
            this.groupBox7.Controls.Add(this.label47);
            this.groupBox7.Controls.Add(this.txtRemark);
            this.groupBox7.Controls.Add(this.txtPId);
            this.groupBox7.Controls.Add(this.label40);
            this.groupBox7.Controls.Add(this.label42);
            this.groupBox7.Controls.Add(this.label43);
            this.groupBox7.Controls.Add(this.label44);
            this.groupBox7.ForeColor = System.Drawing.Color.Black;
            this.groupBox7.Location = new System.Drawing.Point(4, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(715, 100);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "配合比概要信息";
            // 
            // cbxProducer
            // 
            this.cbxProducer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxProducer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxProducer.FormattingEnabled = true;
            this.cbxProducer.Location = new System.Drawing.Point(566, 47);
            this.cbxProducer.Name = "cbxProducer";
            this.cbxProducer.Size = new System.Drawing.Size(129, 20);
            this.cbxProducer.TabIndex = 38;
            // 
            // cbxPName
            // 
            this.cbxPName.FormattingEnabled = true;
            this.cbxPName.Location = new System.Drawing.Point(566, 20);
            this.cbxPName.Name = "cbxPName";
            this.cbxPName.Size = new System.Drawing.Size(129, 20);
            this.cbxPName.TabIndex = 37;
            this.cbxPName.SelectionChangeCommitted += new System.EventHandler(this.cbxPName_SelectionChangeCommitted);
            // 
            // dtpMadeDate
            // 
            this.dtpMadeDate.Location = new System.Drawing.Point(332, 46);
            this.dtpMadeDate.Name = "dtpMadeDate";
            this.dtpMadeDate.Size = new System.Drawing.Size(129, 21);
            this.dtpMadeDate.TabIndex = 36;
            // 
            // cbxPModel
            // 
            this.cbxPModel.FormattingEnabled = true;
            this.cbxPModel.Location = new System.Drawing.Point(103, 46);
            this.cbxPModel.Name = "cbxPModel";
            this.cbxPModel.Size = new System.Drawing.Size(129, 20);
            this.cbxPModel.TabIndex = 34;
            // 
            // cbxPsort
            // 
            this.cbxPsort.FormattingEnabled = true;
            this.cbxPsort.Location = new System.Drawing.Point(332, 20);
            this.cbxPsort.Name = "cbxPsort";
            this.cbxPsort.Size = new System.Drawing.Size(129, 20);
            this.cbxPsort.TabIndex = 33;
            this.cbxPsort.SelectionChangeCommitted += new System.EventHandler(this.cbxPsort_SelectionChangeCommitted);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(253, 49);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(53, 12);
            this.label45.TabIndex = 31;
            this.label45.Text = "制定日期";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(24, 48);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(53, 12);
            this.label46.TabIndex = 30;
            this.label46.Text = "产品型号";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(253, 23);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(53, 12);
            this.label47.TabIndex = 29;
            this.label47.Text = "产品种类";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(103, 72);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(592, 21);
            this.txtRemark.TabIndex = 60;
            // 
            // txtPId
            // 
            this.txtPId.Enabled = false;
            this.txtPId.Location = new System.Drawing.Point(103, 19);
            this.txtPId.Name = "txtPId";
            this.txtPId.Size = new System.Drawing.Size(129, 21);
            this.txtPId.TabIndex = 24;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(25, 77);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(29, 12);
            this.label40.TabIndex = 23;
            this.label40.Text = "备注";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(487, 50);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 12);
            this.label42.TabIndex = 21;
            this.label42.Text = "制定人";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(488, 23);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(53, 12);
            this.label43.TabIndex = 20;
            this.label43.Text = "产品名称";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(25, 22);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(65, 12);
            this.label44.TabIndex = 19;
            this.label44.Text = "配合比编号";
            // 
            // btnSaveMain
            // 
            this.btnSaveMain.Location = new System.Drawing.Point(590, 493);
            this.btnSaveMain.Name = "btnSaveMain";
            this.btnSaveMain.Size = new System.Drawing.Size(94, 28);
            this.btnSaveMain.TabIndex = 39;
            this.btnSaveMain.Text = "保存";
            this.btnSaveMain.UseVisualStyleBackColor = true;
            this.btnSaveMain.Click += new System.EventHandler(this.btnSaveMain_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(466, 79);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 35;
            this.btnNew.Text = "新增明细";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // gbxDetail
            // 
            this.gbxDetail.BackColor = System.Drawing.Color.Transparent;
            this.gbxDetail.Controls.Add(this.cbxMaker);
            this.gbxDetail.Controls.Add(this.cbxAddress);
            this.gbxDetail.Controls.Add(this.label7);
            this.gbxDetail.Controls.Add(this.label6);
            this.gbxDetail.Controls.Add(this.btnDelete);
            this.gbxDetail.Controls.Add(this.btnNew);
            this.gbxDetail.Controls.Add(this.cbxModel);
            this.gbxDetail.Controls.Add(this.cbxKinds);
            this.gbxDetail.Controls.Add(this.label4);
            this.gbxDetail.Controls.Add(this.label5);
            this.gbxDetail.Controls.Add(this.cbxName);
            this.gbxDetail.Controls.Add(this.txtRatio);
            this.gbxDetail.Controls.Add(this.txtPDId);
            this.gbxDetail.Controls.Add(this.label1);
            this.gbxDetail.Controls.Add(this.label2);
            this.gbxDetail.Controls.Add(this.label3);
            this.gbxDetail.ForeColor = System.Drawing.Color.Black;
            this.gbxDetail.Location = new System.Drawing.Point(4, 109);
            this.gbxDetail.Name = "gbxDetail";
            this.gbxDetail.Size = new System.Drawing.Size(715, 114);
            this.gbxDetail.TabIndex = 5;
            this.gbxDetail.TabStop = false;
            this.gbxDetail.Text = "配合比详细信息";
            // 
            // cbxMaker
            // 
            this.cbxMaker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMaker.FormattingEnabled = true;
            this.cbxMaker.Location = new System.Drawing.Point(566, 51);
            this.cbxMaker.Name = "cbxMaker";
            this.cbxMaker.Size = new System.Drawing.Size(129, 20);
            this.cbxMaker.TabIndex = 213;
            this.cbxMaker.Tag = "E";
            // 
            // cbxAddress
            // 
            this.cbxAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAddress.FormattingEnabled = true;
            this.cbxAddress.Location = new System.Drawing.Point(332, 51);
            this.cbxAddress.Name = "cbxAddress";
            this.cbxAddress.Size = new System.Drawing.Size(129, 20);
            this.cbxAddress.TabIndex = 212;
            this.cbxAddress.Tag = "E";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(488, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 211;
            this.label7.Text = "生产厂家";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 210;
            this.label6.Text = "材料产地";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(621, 79);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 209;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbxModel
            // 
            this.cbxModel.FormattingEnabled = true;
            this.cbxModel.Location = new System.Drawing.Point(566, 20);
            this.cbxModel.Name = "cbxModel";
            this.cbxModel.Size = new System.Drawing.Size(129, 20);
            this.cbxModel.TabIndex = 20;
            // 
            // cbxKinds
            // 
            this.cbxKinds.FormattingEnabled = true;
            this.cbxKinds.Location = new System.Drawing.Point(103, 20);
            this.cbxKinds.Name = "cbxKinds";
            this.cbxKinds.Size = new System.Drawing.Size(129, 20);
            this.cbxKinds.TabIndex = 19;
            this.cbxKinds.SelectionChangeCommitted += new System.EventHandler(this.cbxKinds_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(488, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "规格型号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "原料种类";
            // 
            // cbxName
            // 
            this.cbxName.FormattingEnabled = true;
            this.cbxName.Location = new System.Drawing.Point(332, 20);
            this.cbxName.Name = "cbxName";
            this.cbxName.Size = new System.Drawing.Size(129, 20);
            this.cbxName.TabIndex = 16;
            this.cbxName.SelectionChangeCommitted += new System.EventHandler(this.cbxName_SelectionChangeCommitted);
            // 
            // txtRatio
            // 
            this.txtRatio.Location = new System.Drawing.Point(103, 50);
            this.txtRatio.Name = "txtRatio";
            this.txtRatio.Size = new System.Drawing.Size(129, 21);
            this.txtRatio.TabIndex = 15;
            // 
            // txtPDId
            // 
            this.txtPDId.Enabled = false;
            this.txtPDId.Location = new System.Drawing.Point(103, 81);
            this.txtPDId.Name = "txtPDId";
            this.txtPDId.Size = new System.Drawing.Size(129, 21);
            this.txtPDId.TabIndex = 14;
            this.txtPDId.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "原料比例";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "原料名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "配合比编号";
            this.label3.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvDetail);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(4, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(716, 253);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "详细信息列表";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.sort,
            this.name,
            this.model,
            this.targetProportionValue,
            this.address,
            this.name1,
            this.inputDate,
            this.inputMan,
            this.producer,
            this.mId,
            this.tpId,
            this.Pid});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(710, 233);
            this.dgvDetail.TabIndex = 1;
            this.dgvDetail.Click += new System.EventHandler(this.dgvDetail_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "序号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "原料种类";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "原料名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "原料型号";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            // 
            // targetProportionValue
            // 
            this.targetProportionValue.DataPropertyName = "targetProportionValue";
            this.targetProportionValue.HeaderText = "原料比例";
            this.targetProportionValue.Name = "targetProportionValue";
            this.targetProportionValue.ReadOnly = true;
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            this.address.HeaderText = "材料产地";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // name1
            // 
            this.name1.DataPropertyName = "name1";
            this.name1.HeaderText = "生产厂家";
            this.name1.Name = "name1";
            this.name1.ReadOnly = true;
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.HeaderText = "录入时间";
            this.inputDate.Name = "inputDate";
            this.inputDate.ReadOnly = true;
            // 
            // inputMan
            // 
            this.inputMan.DataPropertyName = "inputMan";
            this.inputMan.HeaderText = "录入人";
            this.inputMan.Name = "inputMan";
            this.inputMan.ReadOnly = true;
            // 
            // producer
            // 
            this.producer.DataPropertyName = "producer";
            this.producer.HeaderText = "制作人";
            this.producer.Name = "producer";
            this.producer.ReadOnly = true;
            // 
            // mId
            // 
            this.mId.DataPropertyName = "mId";
            this.mId.HeaderText = "材料编号";
            this.mId.Name = "mId";
            this.mId.ReadOnly = true;
            this.mId.Visible = false;
            // 
            // tpId
            // 
            this.tpId.DataPropertyName = "tpId";
            this.tpId.HeaderText = "配合比编号";
            this.tpId.Name = "tpId";
            this.tpId.ReadOnly = true;
            this.tpId.Visible = false;
            // 
            // Pid
            // 
            this.Pid.DataPropertyName = "Pid";
            this.Pid.HeaderText = "Pid";
            this.Pid.Name = "Pid";
            this.Pid.ReadOnly = true;
            this.Pid.Visible = false;
            // 
            // FrmMixtureRatioAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 536);
            this.Controls.Add(this.btnSaveMain);
            this.Controls.Add(this.gbxDetail);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Name = "FrmMixtureRatioAdd";
            this.Tag = "FrmMixtureRatioAdd";
            this.Text = "新建目标配合比";
            this.Load += new System.EventHandler(this.FrmMixtureRatioAdd_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMixtureRatioAdd_FormClosing);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.gbxDetail.ResumeLayout(false);
            this.gbxDetail.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ComboBox cbxPModel;
        private System.Windows.Forms.ComboBox cbxPsort;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtPId;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.GroupBox gbxDetail;
        private System.Windows.Forms.ComboBox cbxModel;
        private System.Windows.Forms.ComboBox cbxKinds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxName;
        private System.Windows.Forms.TextBox txtRatio;
        private System.Windows.Forms.TextBox txtPDId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DateTimePicker dtpMadeDate;
        private System.Windows.Forms.ComboBox cbxPName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbxProducer;
        private System.Windows.Forms.Button btnSaveMain;
        private System.Windows.Forms.ComboBox cbxMaker;
        private System.Windows.Forms.ComboBox cbxAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetProportionValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn producer;
        private System.Windows.Forms.DataGridViewTextBoxColumn mId;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pid;
    }
}