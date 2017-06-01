namespace DasherStation.equipment
{
    partial class FrmSparePartInStockRefundDetail
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
            this.gbOverall = new System.Windows.Forms.GroupBox();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.cbStockMan = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpStockDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.tbStockMan = new System.Windows.Forms.TextBox();
            this.tbInStockRemark = new System.Windows.Forms.TextBox();
            this.tbInStockId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbInvoiceNo = new System.Windows.Forms.TextBox();
            this.cbProvider = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.sparePartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inStockCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inStockTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inStockUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpInStockDate = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.btnSelectInStock = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbOverall.SuspendLayout();
            this.gbDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOverall
            // 
            this.gbOverall.BackColor = System.Drawing.Color.Transparent;
            this.gbOverall.Controls.Add(this.tbRemark);
            this.gbOverall.Controls.Add(this.cbStockMan);
            this.gbOverall.Controls.Add(this.label18);
            this.gbOverall.Controls.Add(this.label12);
            this.gbOverall.Controls.Add(this.dtpStockDate);
            this.gbOverall.Controls.Add(this.label13);
            this.gbOverall.Location = new System.Drawing.Point(12, 12);
            this.gbOverall.Name = "gbOverall";
            this.gbOverall.Size = new System.Drawing.Size(811, 90);
            this.gbOverall.TabIndex = 5;
            this.gbOverall.TabStop = false;
            this.gbOverall.Text = "备品配件退货单";
            // 
            // tbRemark
            // 
            this.tbRemark.Location = new System.Drawing.Point(279, 21);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRemark.Size = new System.Drawing.Size(517, 54);
            this.tbRemark.TabIndex = 41;
            // 
            // cbStockMan
            // 
            this.cbStockMan.FormattingEnabled = true;
            this.cbStockMan.Location = new System.Drawing.Point(76, 55);
            this.cbStockMan.Name = "cbStockMan";
            this.cbStockMan.Size = new System.Drawing.Size(121, 20);
            this.cbStockMan.TabIndex = 40;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(244, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 36;
            this.label18.Text = "备注";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "退货人";
            // 
            // dtpStockDate
            // 
            this.dtpStockDate.Location = new System.Drawing.Point(76, 20);
            this.dtpStockDate.Name = "dtpStockDate";
            this.dtpStockDate.Size = new System.Drawing.Size(121, 21);
            this.dtpStockDate.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "退货时间";
            // 
            // gbDetail
            // 
            this.gbDetail.BackColor = System.Drawing.Color.Transparent;
            this.gbDetail.Controls.Add(this.tbStockMan);
            this.gbDetail.Controls.Add(this.tbInStockRemark);
            this.gbDetail.Controls.Add(this.tbInStockId);
            this.gbDetail.Controls.Add(this.label1);
            this.gbDetail.Controls.Add(this.label14);
            this.gbDetail.Controls.Add(this.tbInvoiceNo);
            this.gbDetail.Controls.Add(this.cbProvider);
            this.gbDetail.Controls.Add(this.label19);
            this.gbDetail.Controls.Add(this.label15);
            this.gbDetail.Controls.Add(this.dgvDetail);
            this.gbDetail.Controls.Add(this.label17);
            this.gbDetail.Controls.Add(this.dtpInStockDate);
            this.gbDetail.Controls.Add(this.label20);
            this.gbDetail.Controls.Add(this.btnSelectInStock);
            this.gbDetail.Location = new System.Drawing.Point(12, 108);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(811, 511);
            this.gbDetail.TabIndex = 32;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "备品配件退货单明细";
            // 
            // tbStockMan
            // 
            this.tbStockMan.Enabled = false;
            this.tbStockMan.Location = new System.Drawing.Point(479, 20);
            this.tbStockMan.Name = "tbStockMan";
            this.tbStockMan.ReadOnly = true;
            this.tbStockMan.Size = new System.Drawing.Size(121, 21);
            this.tbStockMan.TabIndex = 77;
            // 
            // tbInStockRemark
            // 
            this.tbInStockRemark.Location = new System.Drawing.Point(279, 57);
            this.tbInStockRemark.Name = "tbInStockRemark";
            this.tbInStockRemark.ReadOnly = true;
            this.tbInStockRemark.Size = new System.Drawing.Size(517, 21);
            this.tbInStockRemark.TabIndex = 76;
            // 
            // tbInStockId
            // 
            this.tbInStockId.Location = new System.Drawing.Point(76, 20);
            this.tbInStockId.Name = "tbInStockId";
            this.tbInStockId.ReadOnly = true;
            this.tbInStockId.Size = new System.Drawing.Size(121, 21);
            this.tbInStockId.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 74;
            this.label1.Text = "入库单号";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(244, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 36;
            this.label14.Text = "备注";
            // 
            // tbInvoiceNo
            // 
            this.tbInvoiceNo.Location = new System.Drawing.Point(76, 54);
            this.tbInvoiceNo.Name = "tbInvoiceNo";
            this.tbInvoiceNo.ReadOnly = true;
            this.tbInvoiceNo.Size = new System.Drawing.Size(121, 21);
            this.tbInvoiceNo.TabIndex = 34;
            // 
            // cbProvider
            // 
            this.cbProvider.Enabled = false;
            this.cbProvider.FormattingEnabled = true;
            this.cbProvider.Location = new System.Drawing.Point(675, 21);
            this.cbProvider.Name = "cbProvider";
            this.cbProvider.Size = new System.Drawing.Size(121, 20);
            this.cbProvider.TabIndex = 39;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(29, 57);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 26;
            this.label19.Text = "发票号";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(628, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 33;
            this.label15.Text = "供应商";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sparePartNo,
            this.sparePartName,
            this.sparePartSort,
            this.sparePartModel,
            this.count,
            this.totalPrice,
            this.unitPrice,
            this.inStockCount,
            this.inStockTotalPrice,
            this.inStockUnitPrice,
            this.producer,
            this.contactMan,
            this.contactMethod,
            this.storage,
            this.position});
            this.dgvDetail.Location = new System.Drawing.Point(3, 151);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(805, 356);
            this.dgvDetail.TabIndex = 73;
            this.dgvDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellValueChanged);
            // 
            // sparePartNo
            // 
            this.sparePartNo.DataPropertyName = "sparePartNo";
            this.sparePartNo.HeaderText = "物料编码";
            this.sparePartNo.Name = "sparePartNo";
            this.sparePartNo.ReadOnly = true;
            // 
            // sparePartName
            // 
            this.sparePartName.DataPropertyName = "sparePartName";
            this.sparePartName.HeaderText = "物料名称";
            this.sparePartName.Name = "sparePartName";
            this.sparePartName.ReadOnly = true;
            // 
            // sparePartSort
            // 
            this.sparePartSort.DataPropertyName = "sparePartSort";
            this.sparePartSort.HeaderText = "物料种类";
            this.sparePartSort.Name = "sparePartSort";
            this.sparePartSort.ReadOnly = true;
            // 
            // sparePartModel
            // 
            this.sparePartModel.DataPropertyName = "sparePartModel";
            this.sparePartModel.HeaderText = "物料型号";
            this.sparePartModel.Name = "sparePartModel";
            this.sparePartModel.ReadOnly = true;
            // 
            // count
            // 
            this.count.DataPropertyName = "count";
            this.count.HeaderText = "退货数量";
            this.count.Name = "count";
            // 
            // totalPrice
            // 
            this.totalPrice.DataPropertyName = "totalPrice";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.totalPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.totalPrice.HeaderText = "退货金额";
            this.totalPrice.Name = "totalPrice";
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            this.unitPrice.HeaderText = "退货单价";
            this.unitPrice.Name = "unitPrice";
            // 
            // inStockCount
            // 
            this.inStockCount.DataPropertyName = "inStockCount";
            this.inStockCount.HeaderText = "采购数量";
            this.inStockCount.Name = "inStockCount";
            this.inStockCount.ReadOnly = true;
            // 
            // inStockTotalPrice
            // 
            this.inStockTotalPrice.DataPropertyName = "inStockTotalPrice";
            this.inStockTotalPrice.HeaderText = "采购金额";
            this.inStockTotalPrice.Name = "inStockTotalPrice";
            // 
            // inStockUnitPrice
            // 
            this.inStockUnitPrice.DataPropertyName = "inStockUnitPrice";
            this.inStockUnitPrice.HeaderText = "采购单价";
            this.inStockUnitPrice.Name = "inStockUnitPrice";
            this.inStockUnitPrice.ReadOnly = true;
            // 
            // producer
            // 
            this.producer.DataPropertyName = "producer";
            this.producer.HeaderText = "生产厂家";
            this.producer.Name = "producer";
            this.producer.ReadOnly = true;
            // 
            // contactMan
            // 
            this.contactMan.DataPropertyName = "contactMan";
            this.contactMan.HeaderText = "联系人";
            this.contactMan.Name = "contactMan";
            this.contactMan.ReadOnly = true;
            // 
            // contactMethod
            // 
            this.contactMethod.DataPropertyName = "contactMethod";
            this.contactMethod.HeaderText = "联系方式";
            this.contactMethod.Name = "contactMethod";
            this.contactMethod.ReadOnly = true;
            // 
            // storage
            // 
            this.storage.DataPropertyName = "storage";
            this.storage.HeaderText = "仓库名称";
            this.storage.Name = "storage";
            this.storage.ReadOnly = true;
            // 
            // position
            // 
            this.position.DataPropertyName = "position";
            this.position.HeaderText = "仓位号";
            this.position.Name = "position";
            this.position.ReadOnly = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(432, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 31;
            this.label17.Text = "采购人";
            // 
            // dtpInStockDate
            // 
            this.dtpInStockDate.Enabled = false;
            this.dtpInStockDate.Location = new System.Drawing.Point(279, 20);
            this.dtpInStockDate.Name = "dtpInStockDate";
            this.dtpInStockDate.Size = new System.Drawing.Size(121, 21);
            this.dtpInStockDate.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(220, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 13;
            this.label20.Text = "入库时间";
            // 
            // btnSelectInStock
            // 
            this.btnSelectInStock.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSelectInStock.Location = new System.Drawing.Point(721, 98);
            this.btnSelectInStock.Name = "btnSelectInStock";
            this.btnSelectInStock.Size = new System.Drawing.Size(75, 23);
            this.btnSelectInStock.TabIndex = 0;
            this.btnSelectInStock.Text = "选择入库单";
            this.btnSelectInStock.UseVisualStyleBackColor = true;
            this.btnSelectInStock.Click += new System.EventHandler(this.btnSelectInStock_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(687, 625);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 30);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "保存退货单";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmSparePartInStockRefundDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 667);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.gbOverall);
            this.Name = "FrmSparePartInStockRefundDetail";
            this.Tag = "FrmSparePartInStockRefundDetail";
            this.Text = "新建备品配件退货单";
            this.Load += new System.EventHandler(this.FrmSparePartInStockRefundDetail_Load);
            this.gbOverall.ResumeLayout(false);
            this.gbOverall.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOverall;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.Button btnSelectInStock;
        private System.Windows.Forms.DateTimePicker dtpStockDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbStockMan;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbInvoiceNo;
        private System.Windows.Forms.ComboBox cbProvider;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpInStockDate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbInStockRemark;
        private System.Windows.Forms.TextBox tbInStockId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStockMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn inStockCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn inStockTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn inStockUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn producer;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn storage;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
    }
}