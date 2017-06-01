namespace DasherStation.equipment
{
    partial class FrmSparePartClaimDetail
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxFileNo = new System.Windows.Forms.ComboBox();
            this.txtEName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxENo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDrawMan = new System.Windows.Forms.TextBox();
            this.dtpDrawDate = new System.Windows.Forms.DateTimePicker();
            this.cbxDrawDepartment = new System.Windows.Forms.ComboBox();
            this.txtDrawNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStockQuantity = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.cbxNo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbxFileNo);
            this.groupBox1.Controls.Add(this.txtEName);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cbxENo);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtDrawMan);
            this.groupBox1.Controls.Add(this.dtpDrawDate);
            this.groupBox1.Controls.Add(this.cbxDrawDepartment);
            this.groupBox1.Controls.Add(this.txtDrawNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "领料单信息";
            // 
            // cbxFileNo
            // 
            this.cbxFileNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFileNo.FormattingEnabled = true;
            this.cbxFileNo.Location = new System.Drawing.Point(566, 72);
            this.cbxFileNo.Name = "cbxFileNo";
            this.cbxFileNo.Size = new System.Drawing.Size(143, 20);
            this.cbxFileNo.TabIndex = 1;
            this.cbxFileNo.Tag = "";
            this.cbxFileNo.Visible = false;
            // 
            // txtEName
            // 
            this.txtEName.Enabled = false;
            this.txtEName.Location = new System.Drawing.Point(566, 43);
            this.txtEName.Name = "txtEName";
            this.txtEName.ReadOnly = true;
            this.txtEName.Size = new System.Drawing.Size(143, 21);
            this.txtEName.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(499, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 18;
            this.label15.Text = "设备名称";
            // 
            // cbxENo
            // 
            this.cbxENo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxENo.FormattingEnabled = true;
            this.cbxENo.Location = new System.Drawing.Point(329, 45);
            this.cbxENo.Name = "cbxENo";
            this.cbxENo.Size = new System.Drawing.Size(143, 20);
            this.cbxENo.TabIndex = 17;
            this.cbxENo.Tag = "E";
            this.cbxENo.SelectionChangeCommitted += new System.EventHandler(this.cbxENo_SelectionChangeCommitted);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(262, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "设备编号";
            // 
            // txtDrawMan
            // 
            this.txtDrawMan.Location = new System.Drawing.Point(88, 44);
            this.txtDrawMan.Name = "txtDrawMan";
            this.txtDrawMan.Size = new System.Drawing.Size(143, 21);
            this.txtDrawMan.TabIndex = 15;
            this.txtDrawMan.Tag = "ES";
            // 
            // dtpDrawDate
            // 
            this.dtpDrawDate.Location = new System.Drawing.Point(566, 16);
            this.dtpDrawDate.Name = "dtpDrawDate";
            this.dtpDrawDate.Size = new System.Drawing.Size(143, 21);
            this.dtpDrawDate.TabIndex = 14;
            // 
            // cbxDrawDepartment
            // 
            this.cbxDrawDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDrawDepartment.FormattingEnabled = true;
            this.cbxDrawDepartment.Location = new System.Drawing.Point(329, 17);
            this.cbxDrawDepartment.Name = "cbxDrawDepartment";
            this.cbxDrawDepartment.Size = new System.Drawing.Size(143, 20);
            this.cbxDrawDepartment.TabIndex = 13;
            this.cbxDrawDepartment.Tag = "E";
            // 
            // txtDrawNo
            // 
            this.txtDrawNo.Enabled = false;
            this.txtDrawNo.Location = new System.Drawing.Point(88, 16);
            this.txtDrawNo.Name = "txtDrawNo";
            this.txtDrawNo.ReadOnly = true;
            this.txtDrawNo.Size = new System.Drawing.Size(143, 21);
            this.txtDrawNo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "领料部门";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "领料人";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "领取日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "文档编号";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "领料单号";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtStockQuantity);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.txtCount);
            this.groupBox2.Controls.Add(this.txtUnitPrice);
            this.groupBox2.Controls.Add(this.txtUnit);
            this.groupBox2.Controls.Add(this.txtModel);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtSort);
            this.groupBox2.Controls.Add(this.cbxNo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(2, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(738, 131);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "领料单详细信息";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "库存量";
            // 
            // txtStockQuantity
            // 
            this.txtStockQuantity.Enabled = false;
            this.txtStockQuantity.Location = new System.Drawing.Point(88, 76);
            this.txtStockQuantity.Name = "txtStockQuantity";
            this.txtStockQuantity.ReadOnly = true;
            this.txtStockQuantity.Size = new System.Drawing.Size(143, 21);
            this.txtStockQuantity.TabIndex = 27;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(634, 91);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(501, 91);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 25;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(329, 76);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(143, 21);
            this.txtCount.TabIndex = 24;
            this.txtCount.Tag = "EI";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Enabled = false;
            this.txtUnitPrice.Location = new System.Drawing.Point(566, 46);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(143, 21);
            this.txtUnitPrice.TabIndex = 23;
            // 
            // txtUnit
            // 
            this.txtUnit.Enabled = false;
            this.txtUnit.Location = new System.Drawing.Point(329, 46);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(143, 21);
            this.txtUnit.TabIndex = 22;
            // 
            // txtModel
            // 
            this.txtModel.Enabled = false;
            this.txtModel.Location = new System.Drawing.Point(88, 46);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(143, 21);
            this.txtModel.TabIndex = 21;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(566, 17);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(143, 21);
            this.txtName.TabIndex = 20;
            // 
            // txtSort
            // 
            this.txtSort.Enabled = false;
            this.txtSort.Location = new System.Drawing.Point(329, 17);
            this.txtSort.Name = "txtSort";
            this.txtSort.ReadOnly = true;
            this.txtSort.Size = new System.Drawing.Size(143, 21);
            this.txtSort.TabIndex = 19;
            // 
            // cbxNo
            // 
            this.cbxNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNo.FormattingEnabled = true;
            this.cbxNo.Location = new System.Drawing.Point(88, 18);
            this.cbxNo.Name = "cbxNo";
            this.cbxNo.Size = new System.Drawing.Size(143, 20);
            this.cbxNo.TabIndex = 18;
            this.cbxNo.Tag = "E";
            this.cbxNo.SelectionChangeCommitted += new System.EventHandler(this.cbxNo_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(499, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "备件名称";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "备件种类";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "备件编号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(260, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 12;
            this.label13.Text = "领取数量";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(499, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "单价";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(260, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "计量单位";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "规格型号";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dgvDetail);
            this.groupBox3.Location = new System.Drawing.Point(2, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(738, 233);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "领料单记录";
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
            this.unit,
            this.unitPrice,
            this.count,
            this.sum,
            this.inputDate,
            this.inputMan});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(732, 213);
            this.dgvDetail.TabIndex = 0;
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            this.no.HeaderText = "备件编号";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "备件种类";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "备件名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "规格型号";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            this.unit.HeaderText = "计量单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            this.unitPrice.HeaderText = "单价";
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.ReadOnly = true;
            // 
            // count
            // 
            this.count.DataPropertyName = "count";
            this.count.HeaderText = "领取数量";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // sum
            // 
            this.sum.DataPropertyName = "sum";
            this.sum.HeaderText = "金额";
            this.sum.Name = "sum";
            this.sum.ReadOnly = true;
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
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(636, 491);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmSparePartClaimDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 526);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSparePartClaimDetail";
            this.Tag = "FrmSparePartClaimDetail";
            this.Text = "领料单";
            this.Load += new System.EventHandler(this.FrmSparePartClaimDetail_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSparePartClaimDetail_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDrawNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDrawDate;
        private System.Windows.Forms.ComboBox cbxDrawDepartment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxNo;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSort;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStockQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputMan;
        private System.Windows.Forms.TextBox txtDrawMan;
        private System.Windows.Forms.ComboBox cbxENo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cbxFileNo;
    }
}