namespace DasherStation.equipment
{
    partial class FrmSparePartStockPlan
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
            this.chbxAll = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.requirementDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sparePartUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbOverall = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvOverall = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proposer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applicationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkupMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.gbSearch.Controls.Add(this.chbxAll);
            this.gbSearch.Controls.Add(this.dateTimePicker1);
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Location = new System.Drawing.Point(12, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(622, 48);
            this.gbSearch.TabIndex = 6;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "查询条件";
            // 
            // chbxAll
            // 
            this.chbxAll.AutoSize = true;
            this.chbxAll.Checked = true;
            this.chbxAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxAll.Location = new System.Drawing.Point(236, 19);
            this.chbxAll.Name = "chbxAll";
            this.chbxAll.Size = new System.Drawing.Size(72, 16);
            this.chbxAll.TabIndex = 5;
            this.chbxAll.Text = "所有计划";
            this.chbxAll.UseVisualStyleBackColor = true;
            this.chbxAll.CheckedChanged += new System.EventHandler(this.chbxAll_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(77, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(110, 21);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "计划时间";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(531, 15);
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
            this.gbDetail.Location = new System.Drawing.Point(12, 300);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(625, 308);
            this.gbDetail.TabIndex = 5;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "备品配件采购计划明细";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.requirementDate,
            this.sparePartNo,
            this.sparePartName,
            this.sparePartSort,
            this.sparePartModel,
            this.sparePartUnit,
            this.currentQuantity,
            this.maxStock,
            this.minStock,
            this.producer,
            this.provider,
            this.contactMan,
            this.contactMethod,
            this.count,
            this.unitPrice});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(619, 288);
            this.dgvDetail.TabIndex = 0;
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
            // sparePartUnit
            // 
            this.sparePartUnit.DataPropertyName = "sparePartUnit";
            this.sparePartUnit.HeaderText = "物料单位";
            this.sparePartUnit.Name = "sparePartUnit";
            this.sparePartUnit.ReadOnly = true;
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
            // gbOverall
            // 
            this.gbOverall.BackColor = System.Drawing.Color.Transparent;
            this.gbOverall.Controls.Add(this.btnPrint);
            this.gbOverall.Controls.Add(this.dgvOverall);
            this.gbOverall.Controls.Add(this.btnDelete);
            this.gbOverall.Controls.Add(this.btnAdd);
            this.gbOverall.Location = new System.Drawing.Point(12, 66);
            this.gbOverall.Name = "gbOverall";
            this.gbOverall.Size = new System.Drawing.Size(625, 228);
            this.gbOverall.TabIndex = 4;
            this.gbOverall.TabStop = false;
            this.gbOverall.Text = "备品配件采购计划";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(236, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
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
            this.documentNo,
            this.documentName,
            this.departmentName,
            this.proposer,
            this.applicationDate,
            this.totalSum,
            this.assessor,
            this.checkupMan});
            this.dgvOverall.Location = new System.Drawing.Point(3, 59);
            this.dgvOverall.MultiSelect = false;
            this.dgvOverall.Name = "dgvOverall";
            this.dgvOverall.ReadOnly = true;
            this.dgvOverall.RowTemplate.Height = 23;
            this.dgvOverall.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOverall.Size = new System.Drawing.Size(619, 169);
            this.dgvOverall.TabIndex = 2;
            this.dgvOverall.SelectionChanged += new System.EventHandler(this.dgvOverall_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "采购单号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // documentNo
            // 
            this.documentNo.DataPropertyName = "documentNo";
            this.documentNo.HeaderText = "文档编号";
            this.documentNo.Name = "documentNo";
            this.documentNo.ReadOnly = true;
            this.documentNo.Visible = false;
            // 
            // documentName
            // 
            this.documentName.DataPropertyName = "documentName";
            this.documentName.HeaderText = "文档名称";
            this.documentName.Name = "documentName";
            this.documentName.ReadOnly = true;
            this.documentName.Visible = false;
            // 
            // departmentName
            // 
            this.departmentName.DataPropertyName = "departmentName";
            this.departmentName.HeaderText = "申请部门";
            this.departmentName.Name = "departmentName";
            this.departmentName.ReadOnly = true;
            // 
            // proposer
            // 
            this.proposer.DataPropertyName = "proposer";
            this.proposer.HeaderText = "申请人";
            this.proposer.Name = "proposer";
            this.proposer.ReadOnly = true;
            // 
            // applicationDate
            // 
            this.applicationDate.DataPropertyName = "applicationDate";
            this.applicationDate.HeaderText = "申请日期";
            this.applicationDate.Name = "applicationDate";
            this.applicationDate.ReadOnly = true;
            // 
            // totalSum
            // 
            this.totalSum.DataPropertyName = "totalSum";
            this.totalSum.HeaderText = "金额";
            this.totalSum.Name = "totalSum";
            this.totalSum.ReadOnly = true;
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
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(531, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(438, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新建";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmSparePartStockPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 622);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.gbOverall);
            this.Name = "FrmSparePartStockPlan";
            this.Tag = "FrmSparePartStockPlan";
            this.Text = "备品配件采购计划";
            this.Load += new System.EventHandler(this.FrmSparePartStockPlan_Load);
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
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox chbxAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirementDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn sparePartUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn minStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn producer;
        private System.Windows.Forms.DataGridViewTextBoxColumn provider;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn proposer;
        private System.Windows.Forms.DataGridViewTextBoxColumn applicationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn assessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkupMan;
        private System.Windows.Forms.Button btnPrint;
    }
}