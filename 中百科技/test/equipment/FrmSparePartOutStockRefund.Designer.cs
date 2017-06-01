namespace DasherStation.equipment
{
    partial class FrmSparePartOutStockRefund
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.Bno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bsum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BinputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BinputMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.TId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSPBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claimMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claimDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkupMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkupDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storeKeeper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ODate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheckUp = new System.Windows.Forms.Button();
            this.btnAudit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtQueryStr = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cbxQuery = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dgvDetail);
            this.groupBox3.Location = new System.Drawing.Point(2, 309);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(768, 227);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "退库单详细信息";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bno,
            this.sort,
            this.Bname,
            this.model,
            this.unit,
            this.unitPrice,
            this.count,
            this.TCount,
            this.Bsum,
            this.BinputDate,
            this.BinputMan});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(762, 207);
            this.dgvDetail.TabIndex = 1;
            // 
            // Bno
            // 
            this.Bno.DataPropertyName = "Bno";
            this.Bno.HeaderText = "备件编号";
            this.Bno.Name = "Bno";
            this.Bno.ReadOnly = true;
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "备件种类";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            // 
            // Bname
            // 
            this.Bname.DataPropertyName = "Bname";
            this.Bname.HeaderText = "备件名称";
            this.Bname.Name = "Bname";
            this.Bname.ReadOnly = true;
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
            this.unitPrice.Visible = false;
            // 
            // count
            // 
            this.count.DataPropertyName = "count";
            this.count.HeaderText = "出库数量";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // TCount
            // 
            this.TCount.DataPropertyName = "TCount";
            this.TCount.HeaderText = "退库数量";
            this.TCount.Name = "TCount";
            this.TCount.ReadOnly = true;
            // 
            // Bsum
            // 
            this.Bsum.DataPropertyName = "Bsum";
            this.Bsum.HeaderText = "金额";
            this.Bsum.Name = "Bsum";
            this.Bsum.ReadOnly = true;
            this.Bsum.Visible = false;
            // 
            // BinputDate
            // 
            this.BinputDate.DataPropertyName = "BinputDate";
            this.BinputDate.HeaderText = "录入时间";
            this.BinputDate.Name = "BinputDate";
            this.BinputDate.ReadOnly = true;
            // 
            // BinputMan
            // 
            this.BinputMan.DataPropertyName = "BinputMan";
            this.BinputMan.HeaderText = "录入人";
            this.BinputMan.Name = "BinputMan";
            this.BinputMan.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvInfo);
            this.groupBox2.Location = new System.Drawing.Point(2, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 219);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "退库单信息";
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TId,
            this.Pid,
            this.no,
            this.CSPBID,
            this.claimMan,
            this.name,
            this.claimDate,
            this.sum,
            this.no1,
            this.assessor,
            this.checkupMan,
            this.auditingDate,
            this.checkupDate,
            this.storeKeeper,
            this.ODate,
            this.TDate,
            this.inputDate,
            this.inputMan});
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.ReadOnly = true;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(762, 199);
            this.dgvInfo.TabIndex = 0;
            this.dgvInfo.Click += new System.EventHandler(this.dgvInfo_Click);
            // 
            // TId
            // 
            this.TId.DataPropertyName = "TId";
            this.TId.HeaderText = "退库单号";
            this.TId.Name = "TId";
            this.TId.ReadOnly = true;
            // 
            // Pid
            // 
            this.Pid.DataPropertyName = "Pid";
            this.Pid.HeaderText = "出库单号";
            this.Pid.Name = "Pid";
            this.Pid.ReadOnly = true;
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            this.no.HeaderText = "文档编号";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Visible = false;
            // 
            // CSPBID
            // 
            this.CSPBID.DataPropertyName = "CSPBID";
            this.CSPBID.HeaderText = "领料单号";
            this.CSPBID.Name = "CSPBID";
            this.CSPBID.ReadOnly = true;
            // 
            // claimMan
            // 
            this.claimMan.DataPropertyName = "claimMan";
            this.claimMan.HeaderText = "领料人";
            this.claimMan.Name = "claimMan";
            this.claimMan.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "领料部门";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // claimDate
            // 
            this.claimDate.DataPropertyName = "claimDate";
            this.claimDate.HeaderText = "领取日期";
            this.claimDate.Name = "claimDate";
            this.claimDate.ReadOnly = true;
            // 
            // sum
            // 
            this.sum.DataPropertyName = "sum";
            this.sum.HeaderText = "金额";
            this.sum.Name = "sum";
            this.sum.ReadOnly = true;
            this.sum.Visible = false;
            // 
            // no1
            // 
            this.no1.DataPropertyName = "no1";
            this.no1.HeaderText = "设备编号";
            this.no1.Name = "no1";
            this.no1.ReadOnly = true;
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
            this.auditingDate.HeaderText = "审核日期";
            this.auditingDate.Name = "auditingDate";
            this.auditingDate.ReadOnly = true;
            // 
            // checkupDate
            // 
            this.checkupDate.DataPropertyName = "checkupDate";
            this.checkupDate.HeaderText = "审批日期";
            this.checkupDate.Name = "checkupDate";
            this.checkupDate.ReadOnly = true;
            // 
            // storeKeeper
            // 
            this.storeKeeper.DataPropertyName = "storeKeeper";
            this.storeKeeper.HeaderText = "库管员";
            this.storeKeeper.Name = "storeKeeper";
            this.storeKeeper.ReadOnly = true;
            // 
            // ODate
            // 
            this.ODate.DataPropertyName = "ODate";
            this.ODate.HeaderText = "出库时间";
            this.ODate.Name = "ODate";
            this.ODate.ReadOnly = true;
            // 
            // TDate
            // 
            this.TDate.DataPropertyName = "TDate";
            this.TDate.HeaderText = "退库时间";
            this.TDate.Name = "TDate";
            this.TDate.ReadOnly = true;
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnCheckUp);
            this.groupBox1.Controls.Add(this.btnAudit);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.txtQueryStr);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.cbxQuery);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 82);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnCheckUp
            // 
            this.btnCheckUp.Location = new System.Drawing.Point(467, 48);
            this.btnCheckUp.Name = "btnCheckUp";
            this.btnCheckUp.Size = new System.Drawing.Size(75, 23);
            this.btnCheckUp.TabIndex = 29;
            this.btnCheckUp.Text = "审批";
            this.btnCheckUp.UseVisualStyleBackColor = true;
            // 
            // btnAudit
            // 
            this.btnAudit.Location = new System.Drawing.Point(370, 48);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(75, 23);
            this.btnAudit.TabIndex = 28;
            this.btnAudit.Text = "审核";
            this.btnAudit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(209, 48);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "删除退库单";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(82, 48);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 26;
            this.btnNew.Text = "新建退库单";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtQueryStr
            // 
            this.txtQueryStr.Location = new System.Drawing.Point(237, 18);
            this.txtQueryStr.Name = "txtQueryStr";
            this.txtQueryStr.Size = new System.Drawing.Size(121, 21);
            this.txtQueryStr.TabIndex = 25;
            this.txtQueryStr.Tag = "E";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(671, 18);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 24;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cbxQuery
            // 
            this.cbxQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuery.FormattingEnabled = true;
            this.cbxQuery.Items.AddRange(new object[] {
            "退库单号",
            "出库单号",
            "领料人",
            "领料部门",
            "设备编号"});
            this.cbxQuery.Location = new System.Drawing.Point(82, 18);
            this.cbxQuery.Name = "cbxQuery";
            this.cbxQuery.Size = new System.Drawing.Size(121, 20);
            this.cbxQuery.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "查询条件";
            // 
            // FrmSparePartOutStockRefund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 541);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSparePartOutStockRefund";
            this.Tag = "FrmSparePartOutStockRefund";
            this.Text = "备品配件退库单";
            this.Load += new System.EventHandler(this.FrmSparePartRefound_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCheckUp;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtQueryStr;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cbxQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bname;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn TCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bsum;
        private System.Windows.Forms.DataGridViewTextBoxColumn BinputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BinputMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSPBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn claimMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn claimDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn no1;
        private System.Windows.Forms.DataGridViewTextBoxColumn assessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkupMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn auditingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkupDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn storeKeeper;
        private System.Windows.Forms.DataGridViewTextBoxColumn ODate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputMan;
    }
}