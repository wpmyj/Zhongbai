namespace DasherStation.sell
{
    partial class FrmSalesSettlementAdd
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
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmodel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_scan = new System.Windows.Forms.Button();
            this.txtBill = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxContractNO = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvBillDetail = new System.Windows.Forms.DataGridView();
            this.nid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grossWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suttle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sId1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoice.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.pkind,
            this.pname,
            this.pmodel,
            this.cname,
            this.unitPrice,
            this.quantity,
            this.money,
            this.count});
            this.dgvInvoice.Location = new System.Drawing.Point(6, 16);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.RowTemplate.Height = 23;
            this.dgvInvoice.Size = new System.Drawing.Size(727, 147);
            this.dgvInvoice.TabIndex = 7;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // pkind
            // 
            this.pkind.DataPropertyName = "sort";
            this.pkind.HeaderText = "产品种类";
            this.pkind.Name = "pkind";
            // 
            // pname
            // 
            this.pname.DataPropertyName = "name";
            this.pname.HeaderText = "产品名称";
            this.pname.Name = "pname";
            // 
            // pmodel
            // 
            this.pmodel.DataPropertyName = "model";
            this.pmodel.HeaderText = "产品规格";
            this.pmodel.Name = "pmodel";
            // 
            // cname
            // 
            this.cname.DataPropertyName = "cname";
            this.cname.HeaderText = "客户名称";
            this.cname.Name = "cname";
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            this.unitPrice.HeaderText = "产品单价";
            this.unitPrice.Name = "unitPrice";
            // 
            // quantity
            // 
            this.quantity.HeaderText = "产品数量";
            this.quantity.Name = "quantity";
            // 
            // money
            // 
            this.money.HeaderText = "总金额";
            this.money.Name = "money";
            // 
            // count
            // 
            this.count.HeaderText = "票据总数";
            this.count.Name = "count";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btn_scan);
            this.groupBox1.Controls.Add(this.txtBill);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxContractNO);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 49);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btn_scan
            // 
            this.btn_scan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_scan.Location = new System.Drawing.Point(653, 16);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(75, 23);
            this.btn_scan.TabIndex = 5;
            this.btn_scan.Text = "开始扫描";
            this.btn_scan.UseVisualStyleBackColor = true;
            this.btn_scan.Visible = false;
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // txtBill
            // 
            this.txtBill.Location = new System.Drawing.Point(302, 16);
            this.txtBill.Name = "txtBill";
            this.txtBill.Size = new System.Drawing.Size(345, 21);
            this.txtBill.TabIndex = 4;
            this.txtBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBill_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "合同编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "票据条码";
            // 
            // cbxContractNO
            // 
            this.cbxContractNO.FormattingEnabled = true;
            this.cbxContractNO.Location = new System.Drawing.Point(76, 17);
            this.cbxContractNO.Name = "cbxContractNO";
            this.cbxContractNO.Size = new System.Drawing.Size(149, 20);
            this.cbxContractNO.TabIndex = 1;
            this.cbxContractNO.SelectionChangeCommitted += new System.EventHandler(this.cbxContractNO_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(653, 552);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 30);
            this.btn_ok.TabIndex = 9;
            this.btn_ok.Text = "票据结算";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvInvoice);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(5, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 171);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "合同明细";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtCount);
            this.groupBox3.Controls.Add(this.txtMoney);
            this.groupBox3.Controls.Add(this.txtQuantity);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.dgvBillDetail);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(5, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(736, 299);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "票据信息";
            // 
            // txtCount
            // 
            this.txtCount.Enabled = false;
            this.txtCount.Location = new System.Drawing.Point(483, 269);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(100, 21);
            this.txtCount.TabIndex = 6;
            // 
            // txtMoney
            // 
            this.txtMoney.Enabled = false;
            this.txtMoney.Location = new System.Drawing.Point(276, 269);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(100, 21);
            this.txtMoney.TabIndex = 5;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Location = new System.Drawing.Point(57, 269);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 21);
            this.txtQuantity.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(436, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "票据数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "总金额";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "总重量";
            // 
            // dgvBillDetail
            // 
            this.dgvBillDetail.AllowUserToAddRows = false;
            this.dgvBillDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBillDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvBillDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nid,
            this.iid,
            this.barCode,
            this.inputDate,
            this.scname,
            this.ccname,
            this.sort,
            this.name,
            this.model,
            this.grossWeight,
            this.tare,
            this.suttle,
            this.sId1,
            this.sId2});
            this.dgvBillDetail.Location = new System.Drawing.Point(6, 17);
            this.dgvBillDetail.Name = "dgvBillDetail";
            this.dgvBillDetail.RowTemplate.Height = 23;
            this.dgvBillDetail.Size = new System.Drawing.Size(727, 243);
            this.dgvBillDetail.TabIndex = 0;
            // 
            // nid
            // 
            this.nid.DataPropertyName = "id";
            this.nid.HeaderText = "nid";
            this.nid.Name = "nid";
            this.nid.Visible = false;
            // 
            // iid
            // 
            this.iid.DataPropertyName = "iId";
            this.iid.HeaderText = "iid";
            this.iid.Name = "iid";
            this.iid.Visible = false;
            // 
            // barCode
            // 
            this.barCode.DataPropertyName = "barCode";
            this.barCode.HeaderText = "票据条码";
            this.barCode.Name = "barCode";
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.HeaderText = "日期";
            this.inputDate.Name = "inputDate";
            // 
            // scname
            // 
            this.scname.DataPropertyName = "scname";
            this.scname.HeaderText = "合同名称";
            this.scname.Name = "scname";
            // 
            // ccname
            // 
            this.ccname.DataPropertyName = "cname";
            this.ccname.HeaderText = "客户名称";
            this.ccname.Name = "ccname";
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "产品种类";
            this.sort.Name = "sort";
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "产品名称";
            this.name.Name = "name";
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "产品规格";
            this.model.Name = "model";
            // 
            // grossWeight
            // 
            this.grossWeight.DataPropertyName = "grossWeight";
            this.grossWeight.HeaderText = "毛重";
            this.grossWeight.Name = "grossWeight";
            // 
            // tare
            // 
            this.tare.DataPropertyName = "tare";
            this.tare.HeaderText = "皮重";
            this.tare.Name = "tare";
            // 
            // suttle
            // 
            this.suttle.DataPropertyName = "suttle";
            this.suttle.HeaderText = "净重";
            this.suttle.Name = "suttle";
            // 
            // sId1
            // 
            this.sId1.DataPropertyName = "sId1";
            this.sId1.HeaderText = "起运地";
            this.sId1.Name = "sId1";
            // 
            // sId2
            // 
            this.sId2.DataPropertyName = "sId2";
            this.sId2.HeaderText = "止运地";
            this.sId2.Name = "sId2";
            // 
            // FrmSalesSettlementAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 590);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSalesSettlementAdd";
            this.Text = "新建核算单";
            this.Load += new System.EventHandler(this.FrmSalesSettlementAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.TextBox txtBill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxContractNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvBillDetail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkind;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn pmodel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn money;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn nid;
        private System.Windows.Forms.DataGridViewTextBoxColumn iid;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn scname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccname;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn grossWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn tare;
        private System.Windows.Forms.DataGridViewTextBoxColumn suttle;
        private System.Windows.Forms.DataGridViewTextBoxColumn sId1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sId2;
    }
}