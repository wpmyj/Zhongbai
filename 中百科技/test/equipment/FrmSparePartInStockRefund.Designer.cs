namespace DasherStation.equipment
{
    partial class FrmSparePartInStockRefund
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
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.cbSparePartName = new System.Windows.Forms.ComboBox();
            this.cbSparePartModel = new System.Windows.Forms.ComboBox();
            this.cbSparePartSort = new System.Windows.Forms.ComboBox();
            this.cbSparePartNo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbProvider = new System.Windows.Forms.ComboBox();
            this.cbStockMan = new System.Windows.Forms.ComboBox();
            this.tbInStockId = new System.Windows.Forms.TextBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chbxInStockId = new System.Windows.Forms.CheckBox();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.sparePartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbOverall = new System.Windows.Forms.GroupBox();
            this.btnAssess = new System.Windows.Forms.Button();
            this.btnCheckup = new System.Windows.Forms.Button();
            this.dgvOverall = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.providerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkupMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkupDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbSearch.SuspendLayout();
            this.gbDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.gbOverall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverall)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.BackColor = System.Drawing.Color.Transparent;
            this.gbSearch.Controls.Add(this.cbSparePartName);
            this.gbSearch.Controls.Add(this.cbSparePartModel);
            this.gbSearch.Controls.Add(this.cbSparePartSort);
            this.gbSearch.Controls.Add(this.cbSparePartNo);
            this.gbSearch.Controls.Add(this.label9);
            this.gbSearch.Controls.Add(this.label7);
            this.gbSearch.Controls.Add(this.label6);
            this.gbSearch.Controls.Add(this.cbProvider);
            this.gbSearch.Controls.Add(this.cbStockMan);
            this.gbSearch.Controls.Add(this.tbInStockId);
            this.gbSearch.Controls.Add(this.dtpEnd);
            this.gbSearch.Controls.Add(this.label5);
            this.gbSearch.Controls.Add(this.label4);
            this.gbSearch.Controls.Add(this.label3);
            this.gbSearch.Controls.Add(this.label2);
            this.gbSearch.Controls.Add(this.chbxInStockId);
            this.gbSearch.Controls.Add(this.dtpBegin);
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Location = new System.Drawing.Point(12, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(694, 110);
            this.gbSearch.TabIndex = 6;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "查询条件";
            // 
            // cbSparePartName
            // 
            this.cbSparePartName.Enabled = false;
            this.cbSparePartName.FormattingEnabled = true;
            this.cbSparePartName.Location = new System.Drawing.Point(93, 74);
            this.cbSparePartName.Name = "cbSparePartName";
            this.cbSparePartName.Size = new System.Drawing.Size(110, 20);
            this.cbSparePartName.TabIndex = 70;
            // 
            // cbSparePartModel
            // 
            this.cbSparePartModel.Enabled = false;
            this.cbSparePartModel.FormattingEnabled = true;
            this.cbSparePartModel.Location = new System.Drawing.Point(459, 74);
            this.cbSparePartModel.Name = "cbSparePartModel";
            this.cbSparePartModel.Size = new System.Drawing.Size(110, 20);
            this.cbSparePartModel.TabIndex = 69;
            // 
            // cbSparePartSort
            // 
            this.cbSparePartSort.Enabled = false;
            this.cbSparePartSort.FormattingEnabled = true;
            this.cbSparePartSort.Location = new System.Drawing.Point(276, 74);
            this.cbSparePartSort.Name = "cbSparePartSort";
            this.cbSparePartSort.Size = new System.Drawing.Size(110, 20);
            this.cbSparePartSort.TabIndex = 68;
            // 
            // cbSparePartNo
            // 
            this.cbSparePartNo.Enabled = false;
            this.cbSparePartNo.FormattingEnabled = true;
            this.cbSparePartNo.Location = new System.Drawing.Point(93, 46);
            this.cbSparePartNo.Name = "cbSparePartNo";
            this.cbSparePartNo.Size = new System.Drawing.Size(110, 20);
            this.cbSparePartNo.TabIndex = 67;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 66;
            this.label9.Text = "物料名称";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 64;
            this.label7.Text = "物料规格";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 63;
            this.label6.Text = "物料种类";
            // 
            // cbProvider
            // 
            this.cbProvider.Enabled = false;
            this.cbProvider.FormattingEnabled = true;
            this.cbProvider.Location = new System.Drawing.Point(459, 46);
            this.cbProvider.Name = "cbProvider";
            this.cbProvider.Size = new System.Drawing.Size(110, 20);
            this.cbProvider.TabIndex = 62;
            // 
            // cbStockMan
            // 
            this.cbStockMan.Enabled = false;
            this.cbStockMan.FormattingEnabled = true;
            this.cbStockMan.Location = new System.Drawing.Point(276, 46);
            this.cbStockMan.Name = "cbStockMan";
            this.cbStockMan.Size = new System.Drawing.Size(110, 20);
            this.cbStockMan.TabIndex = 61;
            // 
            // tbInStockId
            // 
            this.tbInStockId.Location = new System.Drawing.Point(93, 17);
            this.tbInStockId.Name = "tbInStockId";
            this.tbInStockId.Size = new System.Drawing.Size(110, 21);
            this.tbInStockId.TabIndex = 60;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Location = new System.Drawing.Point(415, 19);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(110, 21);
            this.dtpEnd.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "—";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "物料编码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "供应商";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "采购人";
            // 
            // chbxInStockId
            // 
            this.chbxInStockId.AutoSize = true;
            this.chbxInStockId.Checked = true;
            this.chbxInStockId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxInStockId.Location = new System.Drawing.Point(15, 22);
            this.chbxInStockId.Name = "chbxInStockId";
            this.chbxInStockId.Size = new System.Drawing.Size(72, 16);
            this.chbxInStockId.TabIndex = 5;
            this.chbxInStockId.Text = "退货单号";
            this.chbxInStockId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbxInStockId.UseVisualStyleBackColor = true;
            this.chbxInStockId.CheckedChanged += new System.EventHandler(this.chbxInStockId_CheckedChanged);
            // 
            // dtpBegin
            // 
            this.dtpBegin.Enabled = false;
            this.dtpBegin.Location = new System.Drawing.Point(276, 19);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(110, 21);
            this.dtpBegin.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "退货时间";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(603, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbDetail
            // 
            this.gbDetail.BackColor = System.Drawing.Color.Transparent;
            this.gbDetail.Controls.Add(this.dgvDetail);
            this.gbDetail.Location = new System.Drawing.Point(9, 362);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(697, 308);
            this.gbDetail.TabIndex = 5;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "备品配件退货单明细";
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
            this.producer,
            this.contactMan,
            this.contactMethod,
            this.storage,
            this.position});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(691, 288);
            this.dgvDetail.TabIndex = 0;
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
            this.count.ReadOnly = true;
            // 
            // totalPrice
            // 
            this.totalPrice.DataPropertyName = "totalPrice";
            this.totalPrice.HeaderText = "退货金额";
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.ReadOnly = true;
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            this.unitPrice.HeaderText = "退货单价";
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.ReadOnly = true;
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
            // gbOverall
            // 
            this.gbOverall.BackColor = System.Drawing.Color.Transparent;
            this.gbOverall.Controls.Add(this.btnAssess);
            this.gbOverall.Controls.Add(this.btnCheckup);
            this.gbOverall.Controls.Add(this.dgvOverall);
            this.gbOverall.Controls.Add(this.btnDelete);
            this.gbOverall.Controls.Add(this.btnAdd);
            this.gbOverall.Location = new System.Drawing.Point(9, 128);
            this.gbOverall.Name = "gbOverall";
            this.gbOverall.Size = new System.Drawing.Size(697, 228);
            this.gbOverall.TabIndex = 4;
            this.gbOverall.TabStop = false;
            this.gbOverall.Text = "备品配件退货单";
            // 
            // btnAssess
            // 
            this.btnAssess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssess.Location = new System.Drawing.Point(18, 20);
            this.btnAssess.Name = "btnAssess";
            this.btnAssess.Size = new System.Drawing.Size(75, 23);
            this.btnAssess.TabIndex = 4;
            this.btnAssess.Text = "审核";
            this.btnAssess.UseVisualStyleBackColor = true;
            this.btnAssess.Click += new System.EventHandler(this.btnAssess_Click);
            // 
            // btnCheckup
            // 
            this.btnCheckup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckup.Location = new System.Drawing.Point(131, 20);
            this.btnCheckup.Name = "btnCheckup";
            this.btnCheckup.Size = new System.Drawing.Size(75, 23);
            this.btnCheckup.TabIndex = 3;
            this.btnCheckup.Text = "审批";
            this.btnCheckup.UseVisualStyleBackColor = true;
            this.btnCheckup.Click += new System.EventHandler(this.btnCheckup_Click);
            // 
            // dgvOverall
            // 
            this.dgvOverall.AllowUserToAddRows = false;
            this.dgvOverall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOverall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverall.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.parentId,
            this.providerName,
            this.invoiceNo,
            this.stockMan,
            this.stockDate,
            this.sum,
            this.remark,
            this.assessor,
            this.checkupMan,
            this.auditingDate,
            this.checkupDate});
            this.dgvOverall.Location = new System.Drawing.Point(3, 59);
            this.dgvOverall.MultiSelect = false;
            this.dgvOverall.Name = "dgvOverall";
            this.dgvOverall.ReadOnly = true;
            this.dgvOverall.RowTemplate.Height = 23;
            this.dgvOverall.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOverall.Size = new System.Drawing.Size(691, 169);
            this.dgvOverall.TabIndex = 2;
            this.dgvOverall.SelectionChanged += new System.EventHandler(this.dgvOverall_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "退货单号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // parentId
            // 
            this.parentId.DataPropertyName = "parentId";
            this.parentId.HeaderText = "入库单号";
            this.parentId.Name = "parentId";
            this.parentId.ReadOnly = true;
            // 
            // providerName
            // 
            this.providerName.DataPropertyName = "providerName";
            this.providerName.HeaderText = "供应商";
            this.providerName.Name = "providerName";
            this.providerName.ReadOnly = true;
            // 
            // invoiceNo
            // 
            this.invoiceNo.DataPropertyName = "invoiceNo";
            this.invoiceNo.HeaderText = "发票号";
            this.invoiceNo.Name = "invoiceNo";
            this.invoiceNo.ReadOnly = true;
            // 
            // stockMan
            // 
            this.stockMan.DataPropertyName = "stockMan";
            this.stockMan.HeaderText = "采购人";
            this.stockMan.Name = "stockMan";
            this.stockMan.ReadOnly = true;
            // 
            // stockDate
            // 
            this.stockDate.DataPropertyName = "stockDate";
            this.stockDate.HeaderText = "退货时间";
            this.stockDate.Name = "stockDate";
            this.stockDate.ReadOnly = true;
            // 
            // sum
            // 
            this.sum.DataPropertyName = "sum";
            this.sum.HeaderText = "金额";
            this.sum.Name = "sum";
            this.sum.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // assessor
            // 
            this.assessor.DataPropertyName = "assessor";
            this.assessor.HeaderText = "审核人";
            this.assessor.Name = "assessor";
            this.assessor.ReadOnly = true;
            // 
            // checkupMan
            // 
            this.checkupMan.DataPropertyName = "checkupMan";
            this.checkupMan.HeaderText = "审批人";
            this.checkupMan.Name = "checkupMan";
            this.checkupMan.ReadOnly = true;
            // 
            // auditingDate
            // 
            this.auditingDate.DataPropertyName = "auditingDate";
            this.auditingDate.HeaderText = "审核时间";
            this.auditingDate.Name = "auditingDate";
            this.auditingDate.ReadOnly = true;
            // 
            // checkupDate
            // 
            this.checkupDate.DataPropertyName = "checkupDate";
            this.checkupDate.HeaderText = "审批时间";
            this.checkupDate.Name = "checkupDate";
            this.checkupDate.ReadOnly = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(603, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(510, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新建";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmSparePartInStockRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 682);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.gbOverall);
            this.Name = "FrmSparePartInStockRefund";
            this.Tag = "FrmSparePartInStockRefund";
            this.Text = "备品配件退货单";
            this.Load += new System.EventHandler(this.FrmSparePartInStockRefund_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.gbOverall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.GroupBox gbOverall;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvOverall;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.CheckBox chbxInStockId;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInStockId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbProvider;
        private System.Windows.Forms.ComboBox cbStockMan;
        private System.Windows.Forms.ComboBox cbSparePartNo;
        private System.Windows.Forms.ComboBox cbSparePartName;
        private System.Windows.Forms.ComboBox cbSparePartModel;
        private System.Windows.Forms.ComboBox cbSparePartSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn providerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn assessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkupMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn auditingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkupDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn producer;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn storage;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.Button btnAssess;
        private System.Windows.Forms.Button btnCheckup;
    }
}