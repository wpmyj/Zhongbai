namespace DasherStation.equipment
{
    partial class FrmSparePartStockPlanDetail
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
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.cbProposer = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpApplicationDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.tbCurrentQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaxStock = new System.Windows.Forms.TextBox();
            this.tbMinStock = new System.Windows.Forms.TextBox();
            this.tbSparePartUnit = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbProvider = new System.Windows.Forms.TextBox();
            this.tbContactMan = new System.Windows.Forms.TextBox();
            this.tbContactMethod = new System.Windows.Forms.TextBox();
            this.tbProducer = new System.Windows.Forms.TextBox();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.tbSparePartModel = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.requirementDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpRequirementDate = new System.Windows.Forms.DateTimePicker();
            this.tbSparePartName = new System.Windows.Forms.TextBox();
            this.tbUnitPrice = new System.Windows.Forms.TextBox();
            this.tbSparePartSort = new System.Windows.Forms.TextBox();
            this.cbSparePartNo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.gbOverall.Controls.Add(this.cbDepartment);
            this.gbOverall.Controls.Add(this.cbProposer);
            this.gbOverall.Controls.Add(this.label18);
            this.gbOverall.Controls.Add(this.label17);
            this.gbOverall.Controls.Add(this.dtpApplicationDate);
            this.gbOverall.Controls.Add(this.label13);
            this.gbOverall.Location = new System.Drawing.Point(12, 12);
            this.gbOverall.Name = "gbOverall";
            this.gbOverall.Size = new System.Drawing.Size(811, 53);
            this.gbOverall.TabIndex = 5;
            this.gbOverall.TabStop = false;
            this.gbOverall.Text = "备品配件采购计划";
            // 
            // cbDepartment
            // 
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(279, 20);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(121, 20);
            this.cbDepartment.TabIndex = 38;
            // 
            // cbProposer
            // 
            this.cbProposer.FormattingEnabled = true;
            this.cbProposer.Location = new System.Drawing.Point(479, 20);
            this.cbProposer.Name = "cbProposer";
            this.cbProposer.Size = new System.Drawing.Size(121, 20);
            this.cbProposer.TabIndex = 37;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(432, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 36;
            this.label18.Text = "申请人";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(220, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 35;
            this.label17.Text = "申请部门";
            // 
            // dtpApplicationDate
            // 
            this.dtpApplicationDate.Location = new System.Drawing.Point(76, 19);
            this.dtpApplicationDate.Name = "dtpApplicationDate";
            this.dtpApplicationDate.Size = new System.Drawing.Size(121, 21);
            this.dtpApplicationDate.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "申请日期";
            // 
            // gbDetail
            // 
            this.gbDetail.BackColor = System.Drawing.Color.Transparent;
            this.gbDetail.Controls.Add(this.tbCurrentQuantity);
            this.gbDetail.Controls.Add(this.label3);
            this.gbDetail.Controls.Add(this.tbMaxStock);
            this.gbDetail.Controls.Add(this.tbMinStock);
            this.gbDetail.Controls.Add(this.tbSparePartUnit);
            this.gbDetail.Controls.Add(this.label21);
            this.gbDetail.Controls.Add(this.label20);
            this.gbDetail.Controls.Add(this.label19);
            this.gbDetail.Controls.Add(this.tbProvider);
            this.gbDetail.Controls.Add(this.tbContactMan);
            this.gbDetail.Controls.Add(this.tbContactMethod);
            this.gbDetail.Controls.Add(this.tbProducer);
            this.gbDetail.Controls.Add(this.tbCount);
            this.gbDetail.Controls.Add(this.tbSparePartModel);
            this.gbDetail.Controls.Add(this.label16);
            this.gbDetail.Controls.Add(this.dgvDetail);
            this.gbDetail.Controls.Add(this.dtpRequirementDate);
            this.gbDetail.Controls.Add(this.tbSparePartName);
            this.gbDetail.Controls.Add(this.tbUnitPrice);
            this.gbDetail.Controls.Add(this.tbSparePartSort);
            this.gbDetail.Controls.Add(this.cbSparePartNo);
            this.gbDetail.Controls.Add(this.label11);
            this.gbDetail.Controls.Add(this.label10);
            this.gbDetail.Controls.Add(this.label9);
            this.gbDetail.Controls.Add(this.label8);
            this.gbDetail.Controls.Add(this.label7);
            this.gbDetail.Controls.Add(this.label6);
            this.gbDetail.Controls.Add(this.label5);
            this.gbDetail.Controls.Add(this.label4);
            this.gbDetail.Controls.Add(this.label2);
            this.gbDetail.Controls.Add(this.label1);
            this.gbDetail.Controls.Add(this.btnDelete);
            this.gbDetail.Controls.Add(this.btnAdd);
            this.gbDetail.Location = new System.Drawing.Point(12, 71);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(811, 538);
            this.gbDetail.TabIndex = 32;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "备品配件采购计划明细";
            // 
            // tbCurrentQuantity
            // 
            this.tbCurrentQuantity.Location = new System.Drawing.Point(76, 62);
            this.tbCurrentQuantity.Name = "tbCurrentQuantity";
            this.tbCurrentQuantity.ReadOnly = true;
            this.tbCurrentQuantity.Size = new System.Drawing.Size(121, 21);
            this.tbCurrentQuantity.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 71;
            this.label3.Text = "当前库存";
            // 
            // tbMaxStock
            // 
            this.tbMaxStock.Location = new System.Drawing.Point(279, 62);
            this.tbMaxStock.Name = "tbMaxStock";
            this.tbMaxStock.ReadOnly = true;
            this.tbMaxStock.Size = new System.Drawing.Size(121, 21);
            this.tbMaxStock.TabIndex = 70;
            // 
            // tbMinStock
            // 
            this.tbMinStock.Location = new System.Drawing.Point(479, 62);
            this.tbMinStock.Name = "tbMinStock";
            this.tbMinStock.ReadOnly = true;
            this.tbMinStock.Size = new System.Drawing.Size(121, 21);
            this.tbMinStock.TabIndex = 69;
            // 
            // tbSparePartUnit
            // 
            this.tbSparePartUnit.Location = new System.Drawing.Point(675, 62);
            this.tbSparePartUnit.Name = "tbSparePartUnit";
            this.tbSparePartUnit.ReadOnly = true;
            this.tbSparePartUnit.Size = new System.Drawing.Size(121, 21);
            this.tbSparePartUnit.TabIndex = 68;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(220, 68);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 67;
            this.label21.Text = "最大库存";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(420, 68);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 66;
            this.label20.Text = "最小库存";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(616, 68);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 65;
            this.label19.Text = "物料单位";
            // 
            // tbProvider
            // 
            this.tbProvider.Location = new System.Drawing.Point(76, 143);
            this.tbProvider.Name = "tbProvider";
            this.tbProvider.Size = new System.Drawing.Size(121, 21);
            this.tbProvider.TabIndex = 64;
            // 
            // tbContactMan
            // 
            this.tbContactMan.Location = new System.Drawing.Point(279, 143);
            this.tbContactMan.Name = "tbContactMan";
            this.tbContactMan.Size = new System.Drawing.Size(121, 21);
            this.tbContactMan.TabIndex = 63;
            // 
            // tbContactMethod
            // 
            this.tbContactMethod.Location = new System.Drawing.Point(479, 143);
            this.tbContactMethod.Name = "tbContactMethod";
            this.tbContactMethod.Size = new System.Drawing.Size(121, 21);
            this.tbContactMethod.TabIndex = 62;
            // 
            // tbProducer
            // 
            this.tbProducer.Location = new System.Drawing.Point(675, 102);
            this.tbProducer.Name = "tbProducer";
            this.tbProducer.Size = new System.Drawing.Size(121, 21);
            this.tbProducer.TabIndex = 61;
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(279, 102);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(121, 21);
            this.tbCount.TabIndex = 59;
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
            this.label16.Location = new System.Drawing.Point(444, 106);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 57;
            this.label16.Text = "单价";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.requirementDate,
            this.sparePartNo,
            this.sparePartName,
            this.sparePartSort,
            this.sparePartModel,
            this.currentQuantity,
            this.maxStock,
            this.minStock,
            this.sparePartUnit,
            this.producer,
            this.provider,
            this.contactMan,
            this.contactMethod,
            this.count,
            this.unitPrice});
            this.dgvDetail.Location = new System.Drawing.Point(3, 221);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(802, 313);
            this.dgvDetail.TabIndex = 56;
            // 
            // requirementDate
            // 
            this.requirementDate.DataPropertyName = "requirementDate";
            this.requirementDate.HeaderText = "需求日期";
            this.requirementDate.Name = "requirementDate";
            this.requirementDate.ReadOnly = true;
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
            this.sparePartSort.HeaderText = "物料类别";
            this.sparePartSort.Name = "sparePartSort";
            this.sparePartSort.ReadOnly = true;
            // 
            // sparePartModel
            // 
            this.sparePartModel.DataPropertyName = "sparePartModel";
            this.sparePartModel.HeaderText = "物料规格型号";
            this.sparePartModel.Name = "sparePartModel";
            this.sparePartModel.ReadOnly = true;
            // 
            // currentQuantity
            // 
            this.currentQuantity.DataPropertyName = "currentQuantity";
            this.currentQuantity.HeaderText = "当前库存";
            this.currentQuantity.Name = "currentQuantity";
            this.currentQuantity.ReadOnly = true;
            // 
            // maxStock
            // 
            this.maxStock.DataPropertyName = "maxStock";
            this.maxStock.HeaderText = "最大库存";
            this.maxStock.Name = "maxStock";
            this.maxStock.ReadOnly = true;
            // 
            // minStock
            // 
            this.minStock.DataPropertyName = "minStock";
            this.minStock.HeaderText = "最小库存";
            this.minStock.Name = "minStock";
            this.minStock.ReadOnly = true;
            // 
            // sparePartUnit
            // 
            this.sparePartUnit.DataPropertyName = "sparePartUnit";
            this.sparePartUnit.HeaderText = "物料单位";
            this.sparePartUnit.Name = "sparePartUnit";
            this.sparePartUnit.ReadOnly = true;
            // 
            // producer
            // 
            this.producer.DataPropertyName = "producer";
            this.producer.HeaderText = "生产厂家";
            this.producer.Name = "producer";
            this.producer.ReadOnly = true;
            // 
            // provider
            // 
            this.provider.DataPropertyName = "provider";
            this.provider.HeaderText = "供应商";
            this.provider.Name = "provider";
            this.provider.ReadOnly = true;
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
            // count
            // 
            this.count.DataPropertyName = "count";
            this.count.HeaderText = "采购数量";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            this.unitPrice.HeaderText = "单价";
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.ReadOnly = true;
            // 
            // dtpRequirementDate
            // 
            this.dtpRequirementDate.Location = new System.Drawing.Point(76, 102);
            this.dtpRequirementDate.Name = "dtpRequirementDate";
            this.dtpRequirementDate.Size = new System.Drawing.Size(121, 21);
            this.dtpRequirementDate.TabIndex = 50;
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
            this.tbUnitPrice.Location = new System.Drawing.Point(479, 102);
            this.tbUnitPrice.Name = "tbUnitPrice";
            this.tbUnitPrice.Size = new System.Drawing.Size(121, 21);
            this.tbUnitPrice.TabIndex = 47;
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
            this.label10.Location = new System.Drawing.Point(29, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 43;
            this.label10.Text = "供应商";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(232, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 42;
            this.label9.Text = "联系人";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(420, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 41;
            this.label8.Text = "联系方式";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "需求日期";
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
            this.label2.Location = new System.Drawing.Point(616, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "生产厂家";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "采购数量";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(721, 177);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除明细";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(630, 177);
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
            this.btnSave.Text = "保存计划";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmSparePartStockPlanDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 667);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.gbOverall);
            this.Name = "FrmSparePartStockPlanDetail";
            this.Tag = "FrmSparePartStockPlanDetail";
            this.Text = "新建备品配件采购计划";
            this.Load += new System.EventHandler(this.FrmSparePartStockPlanDetail_Load);
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
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dtpApplicationDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbSparePartName;
        private System.Windows.Forms.TextBox tbUnitPrice;
        private System.Windows.Forms.TextBox tbSparePartSort;
        private System.Windows.Forms.ComboBox cbSparePartNo;
        private System.Windows.Forms.DateTimePicker dtpRequirementDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.ComboBox cbProposer;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.TextBox tbSparePartModel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbProvider;
        private System.Windows.Forms.TextBox tbContactMan;
        private System.Windows.Forms.TextBox tbContactMethod;
        private System.Windows.Forms.TextBox tbProducer;
        private System.Windows.Forms.TextBox tbMaxStock;
        private System.Windows.Forms.TextBox tbMinStock;
        private System.Windows.Forms.TextBox tbSparePartUnit;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirementDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn minStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn producer;
        private System.Windows.Forms.DataGridViewTextBoxColumn provider;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCurrentQuantity;
    }
}