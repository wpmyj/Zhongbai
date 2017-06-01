namespace DasherStation.equipment
{
    partial class FrmSparePartInStockDetail
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
            this.gbOverall = new System.Windows.Forms.GroupBox();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.cbStockMan = new System.Windows.Forms.ComboBox();
            this.cbProvider = new System.Windows.Forms.ComboBox();
            this.tbInvoiceNo = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpStockDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTotalPrice = new System.Windows.Forms.TextBox();
            this.tbPosition = new System.Windows.Forms.TextBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.sparePartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.tbStorage = new System.Windows.Forms.TextBox();
            this.tbContactMan = new System.Windows.Forms.TextBox();
            this.tbContactMethod = new System.Windows.Forms.TextBox();
            this.tbProducer = new System.Windows.Forms.TextBox();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.tbSparePartModel = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbSparePartName = new System.Windows.Forms.TextBox();
            this.tbUnitPrice = new System.Windows.Forms.TextBox();
            this.tbSparePartSort = new System.Windows.Forms.TextBox();
            this.cbSparePartNo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
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
            this.gbOverall.Controls.Add(this.cbProvider);
            this.gbOverall.Controls.Add(this.tbInvoiceNo);
            this.gbOverall.Controls.Add(this.label18);
            this.gbOverall.Controls.Add(this.label15);
            this.gbOverall.Controls.Add(this.label12);
            this.gbOverall.Controls.Add(this.dtpStockDate);
            this.gbOverall.Controls.Add(this.label14);
            this.gbOverall.Controls.Add(this.label13);
            this.gbOverall.Location = new System.Drawing.Point(12, 12);
            this.gbOverall.Name = "gbOverall";
            this.gbOverall.Size = new System.Drawing.Size(811, 90);
            this.gbOverall.TabIndex = 5;
            this.gbOverall.TabStop = false;
            this.gbOverall.Text = "备品配件入库单";
            // 
            // tbRemark
            // 
            this.tbRemark.Location = new System.Drawing.Point(479, 21);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRemark.Size = new System.Drawing.Size(317, 54);
            this.tbRemark.TabIndex = 41;
            // 
            // cbStockMan
            // 
            this.cbStockMan.FormattingEnabled = true;
            this.cbStockMan.Location = new System.Drawing.Point(279, 21);
            this.cbStockMan.Name = "cbStockMan";
            this.cbStockMan.Size = new System.Drawing.Size(121, 20);
            this.cbStockMan.TabIndex = 40;
            // 
            // cbProvider
            // 
            this.cbProvider.FormattingEnabled = true;
            this.cbProvider.Location = new System.Drawing.Point(76, 54);
            this.cbProvider.Name = "cbProvider";
            this.cbProvider.Size = new System.Drawing.Size(121, 20);
            this.cbProvider.TabIndex = 39;
            // 
            // tbInvoiceNo
            // 
            this.tbInvoiceNo.Location = new System.Drawing.Point(279, 54);
            this.tbInvoiceNo.Name = "tbInvoiceNo";
            this.tbInvoiceNo.Size = new System.Drawing.Size(121, 21);
            this.tbInvoiceNo.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(444, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 36;
            this.label18.Text = "备注";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 33;
            this.label15.Text = "供应商";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(232, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "采购人";
            // 
            // dtpStockDate
            // 
            this.dtpStockDate.Location = new System.Drawing.Point(76, 20);
            this.dtpStockDate.Name = "dtpStockDate";
            this.dtpStockDate.Size = new System.Drawing.Size(121, 21);
            this.dtpStockDate.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(232, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 26;
            this.label14.Text = "发票号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "入库时间";
            // 
            // gbDetail
            // 
            this.gbDetail.BackColor = System.Drawing.Color.Transparent;
            this.gbDetail.Controls.Add(this.label7);
            this.gbDetail.Controls.Add(this.tbTotalPrice);
            this.gbDetail.Controls.Add(this.tbPosition);
            this.gbDetail.Controls.Add(this.dgvDetail);
            this.gbDetail.Controls.Add(this.label3);
            this.gbDetail.Controls.Add(this.tbStorage);
            this.gbDetail.Controls.Add(this.tbContactMan);
            this.gbDetail.Controls.Add(this.tbContactMethod);
            this.gbDetail.Controls.Add(this.tbProducer);
            this.gbDetail.Controls.Add(this.tbCount);
            this.gbDetail.Controls.Add(this.tbSparePartModel);
            this.gbDetail.Controls.Add(this.label16);
            this.gbDetail.Controls.Add(this.tbSparePartName);
            this.gbDetail.Controls.Add(this.tbUnitPrice);
            this.gbDetail.Controls.Add(this.tbSparePartSort);
            this.gbDetail.Controls.Add(this.cbSparePartNo);
            this.gbDetail.Controls.Add(this.label11);
            this.gbDetail.Controls.Add(this.label10);
            this.gbDetail.Controls.Add(this.label9);
            this.gbDetail.Controls.Add(this.label8);
            this.gbDetail.Controls.Add(this.label6);
            this.gbDetail.Controls.Add(this.label5);
            this.gbDetail.Controls.Add(this.label4);
            this.gbDetail.Controls.Add(this.label2);
            this.gbDetail.Controls.Add(this.label1);
            this.gbDetail.Controls.Add(this.btnDelete);
            this.gbDetail.Controls.Add(this.btnAdd);
            this.gbDetail.Location = new System.Drawing.Point(12, 108);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(811, 511);
            this.gbDetail.TabIndex = 32;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "备品配件入库单明细";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(640, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 76;
            this.label7.Text = "金额";
            // 
            // tbTotalPrice
            // 
            this.tbTotalPrice.Location = new System.Drawing.Point(675, 65);
            this.tbTotalPrice.Name = "tbTotalPrice";
            this.tbTotalPrice.Size = new System.Drawing.Size(121, 21);
            this.tbTotalPrice.TabIndex = 75;
            this.tbTotalPrice.TextChanged += new System.EventHandler(this.tbTotalPrice_TextChanged);
            // 
            // tbPosition
            // 
            this.tbPosition.Location = new System.Drawing.Point(479, 101);
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(121, 21);
            this.tbPosition.TabIndex = 74;
            this.tbPosition.Visible = false;
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
            this.contactMethod,
            this.producer,
            this.contactMan,
            this.storage,
            this.position});
            this.dgvDetail.Location = new System.Drawing.Point(3, 178);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(805, 329);
            this.dgvDetail.TabIndex = 73;
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
            this.count.HeaderText = "采购数量";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // totalPrice
            // 
            this.totalPrice.DataPropertyName = "totalPrice";
            this.totalPrice.HeaderText = "金额";
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.ReadOnly = true;
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            this.unitPrice.HeaderText = "采购单价";
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.ReadOnly = true;
            // 
            // contactMethod
            // 
            this.contactMethod.DataPropertyName = "contactMethod";
            this.contactMethod.HeaderText = "联系方式";
            this.contactMethod.Name = "contactMethod";
            this.contactMethod.ReadOnly = true;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 71;
            this.label3.Text = "仓位号";
            this.label3.Visible = false;
            // 
            // tbStorage
            // 
            this.tbStorage.Location = new System.Drawing.Point(279, 101);
            this.tbStorage.Name = "tbStorage";
            this.tbStorage.Size = new System.Drawing.Size(121, 21);
            this.tbStorage.TabIndex = 64;
            this.tbStorage.Visible = false;
            // 
            // tbContactMan
            // 
            this.tbContactMan.Location = new System.Drawing.Point(76, 101);
            this.tbContactMan.Name = "tbContactMan";
            this.tbContactMan.Size = new System.Drawing.Size(121, 21);
            this.tbContactMan.TabIndex = 63;
            // 
            // tbContactMethod
            // 
            this.tbContactMethod.Location = new System.Drawing.Point(279, 65);
            this.tbContactMethod.Name = "tbContactMethod";
            this.tbContactMethod.Size = new System.Drawing.Size(121, 21);
            this.tbContactMethod.TabIndex = 62;
            // 
            // tbProducer
            // 
            this.tbProducer.Location = new System.Drawing.Point(76, 62);
            this.tbProducer.Name = "tbProducer";
            this.tbProducer.Size = new System.Drawing.Size(121, 21);
            this.tbProducer.TabIndex = 61;
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(479, 65);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(121, 21);
            this.tbCount.TabIndex = 59;
            this.tbCount.TextChanged += new System.EventHandler(this.tbCount_TextChanged);
            // 
            // tbSparePartModel
            // 
            this.tbSparePartModel.Location = new System.Drawing.Point(675, 24);
            this.tbSparePartModel.Name = "tbSparePartModel";
            this.tbSparePartModel.ReadOnly = true;
            this.tbSparePartModel.Size = new System.Drawing.Size(121, 21);
            this.tbSparePartModel.TabIndex = 58;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(640, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 57;
            this.label16.Text = "单价";
            // 
            // tbSparePartName
            // 
            this.tbSparePartName.Location = new System.Drawing.Point(279, 24);
            this.tbSparePartName.Name = "tbSparePartName";
            this.tbSparePartName.ReadOnly = true;
            this.tbSparePartName.Size = new System.Drawing.Size(121, 21);
            this.tbSparePartName.TabIndex = 48;
            // 
            // tbUnitPrice
            // 
            this.tbUnitPrice.Location = new System.Drawing.Point(675, 101);
            this.tbUnitPrice.Name = "tbUnitPrice";
            this.tbUnitPrice.Size = new System.Drawing.Size(121, 21);
            this.tbUnitPrice.TabIndex = 47;
            this.tbUnitPrice.TextChanged += new System.EventHandler(this.tbUnitPrice_TextChanged);
            // 
            // tbSparePartSort
            // 
            this.tbSparePartSort.Location = new System.Drawing.Point(479, 24);
            this.tbSparePartSort.Name = "tbSparePartSort";
            this.tbSparePartSort.ReadOnly = true;
            this.tbSparePartSort.Size = new System.Drawing.Size(121, 21);
            this.tbSparePartSort.TabIndex = 46;
            // 
            // cbSparePartNo
            // 
            this.cbSparePartNo.FormattingEnabled = true;
            this.cbSparePartNo.Location = new System.Drawing.Point(76, 24);
            this.cbSparePartNo.Name = "cbSparePartNo";
            this.cbSparePartNo.Size = new System.Drawing.Size(121, 20);
            this.cbSparePartNo.TabIndex = 45;
            this.cbSparePartNo.SelectionChangeCommitted += new System.EventHandler(this.cbSparePartNo_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(420, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 44;
            this.label11.Text = "物料类别";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(220, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 43;
            this.label10.Text = "仓库名称";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 42;
            this.label9.Text = "联系人";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 41;
            this.label8.Text = "联系方式";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "物料名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "物料编码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(616, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 35;
            this.label4.Text = "物料规格";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "生产厂家";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "采购数量";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.Location = new System.Drawing.Point(721, 138);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除明细";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdd.Location = new System.Drawing.Point(630, 138);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新建明细";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(687, 625);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 30);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "保存入库单";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmSparePartInStockDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 667);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.gbOverall);
            this.Name = "FrmSparePartInStockDetail";
            this.Tag = "FrmSparePartInStockDetail";
            this.Text = "新建备品配件入库单";
            this.Load += new System.EventHandler(this.FrmSparePartInStockDetail_Load);
            this.gbOverall.ResumeLayout(false);
            this.gbOverall.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOverall;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dtpStockDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSparePartName;
        private System.Windows.Forms.TextBox tbUnitPrice;
        private System.Windows.Forms.TextBox tbSparePartSort;
        private System.Windows.Forms.ComboBox cbSparePartNo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbInvoiceNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.TextBox tbSparePartModel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbStorage;
        private System.Windows.Forms.TextBox tbContactMan;
        private System.Windows.Forms.TextBox tbContactMethod;
        private System.Windows.Forms.TextBox tbProducer;
        private System.Windows.Forms.ComboBox cbProvider;
        private System.Windows.Forms.ComboBox cbStockMan;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn producer;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn storage;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
    }
}