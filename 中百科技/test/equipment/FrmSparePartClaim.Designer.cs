namespace DasherStation.equipment
{
    partial class FrmSparePartClaim
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btnCheckUp = new System.Windows.Forms.Button();
            this.btnAudit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtQueryStr = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cbxQuery = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claimMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.claimDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkupMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkupDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btn_Print);
            this.groupBox1.Controls.Add(this.btnCheckUp);
            this.groupBox1.Controls.Add(this.btnAudit);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.txtQueryStr);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.cbxQuery);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 82);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(598, 48);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 23);
            this.btn_Print.TabIndex = 30;
            this.btn_Print.Text = "打印";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
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
            this.btnDelete.Text = "删除领料单";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(82, 48);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 26;
            this.btnNew.Text = "新建领料单";
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
            "领料单号",
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
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvInfo);
            this.groupBox2.Location = new System.Drawing.Point(2, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 219);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "领料单信息";
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.no,
            this.claimMan,
            this.name,
            this.claimDate,
            this.sum,
            this.assessor,
            this.checkupMan,
            this.auditingDate,
            this.checkupDate,
            this.inputDate,
            this.inputMan,
            this.no1});
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
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "领料单号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            this.no.HeaderText = "文档编号";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Visible = false;
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
            // no1
            // 
            this.no1.DataPropertyName = "no1";
            this.no1.HeaderText = "设备编号";
            this.no1.Name = "no1";
            this.no1.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dgvDetail);
            this.groupBox3.Location = new System.Drawing.Point(2, 306);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(768, 227);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "领料单详细信息";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.sort,
            this.dataGridViewTextBoxColumn2,
            this.model,
            this.unit,
            this.unitPrice,
            this.count,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(762, 207);
            this.dgvDetail.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "no";
            this.dataGridViewTextBoxColumn1.HeaderText = "备件编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "备件种类";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn2.HeaderText = "备件名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
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
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "sum";
            this.dataGridViewTextBoxColumn3.HeaderText = "金额";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "inputDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "录入时间";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "inputMan";
            this.dataGridViewTextBoxColumn5.HeaderText = "录入人";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // FrmSparePartClaim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 541);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSparePartClaim";
            this.Tag = "FrmSparePartClaim";
            this.Text = "备品配件领料单";
            this.Load += new System.EventHandler(this.FrmClaimSparePartBill_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtQueryStr;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cbxQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.Button btnCheckUp;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn claimMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn claimDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn assessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkupMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn auditingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkupDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn no1;
        private System.Windows.Forms.Button btn_Print;
    }
}