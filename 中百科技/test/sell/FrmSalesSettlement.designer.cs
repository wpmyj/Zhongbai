namespace DasherStation.sell
{
    partial class FrmSalesSettlement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalesSettlement));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cbxCondition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Print = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMBillDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.dgvSettlement = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btn_Checkup = new System.Windows.Forms.Button();
            this.btn_Assess = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettlement)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtCondition);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.cbxCondition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 43);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(220, 13);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(425, 21);
            this.txtCondition.TabIndex = 15;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(689, 12);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cbxCondition
            // 
            this.cbxCondition.FormattingEnabled = true;
            this.cbxCondition.Items.AddRange(new object[] {
            "合同名称",
            "合同编号",
            "客户名称"});
            this.cbxCondition.Location = new System.Drawing.Point(93, 14);
            this.cbxCondition.Name = "cbxCondition";
            this.cbxCondition.Size = new System.Drawing.Size(121, 20);
            this.cbxCondition.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询条件";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btn_Print);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnDisplay);
            this.groupBox2.Controls.Add(this.dgvSettlement);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btn_Checkup);
            this.groupBox2.Controls.Add(this.btn_Assess);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(3, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(788, 505);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "结算单信息";
            // 
            // btn_Print
            // 
            this.btn_Print.ContextMenuStrip = this.contextMenuStrip1;
            this.btn_Print.Location = new System.Drawing.Point(451, 20);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 23);
            this.btn_Print.TabIndex = 15;
            this.btn_Print.Text = "打印";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Print_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMDetail,
            this.TSMBillDetail});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 70);
            // 
            // TSMDetail
            // 
            this.TSMDetail.Name = "TSMDetail";
            this.TSMDetail.Size = new System.Drawing.Size(178, 22);
            this.TSMDetail.Text = "打印核算单明细";
            this.TSMDetail.Click += new System.EventHandler(this.TSMDetail_Click);
            // 
            // TSMBillDetail
            // 
            this.TSMBillDetail.Name = "TSMBillDetail";
            this.TSMBillDetail.Size = new System.Drawing.Size(178, 22);
            this.TSMBillDetail.Text = "打印核算单票具明细";
            this.TSMBillDetail.Click += new System.EventHandler(this.TSMBillDetail_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(689, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(118, 20);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 13;
            this.btnDisplay.Text = "显示核算单";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // dgvSettlement
            // 
            this.dgvSettlement.AllowUserToAddRows = false;
            this.dgvSettlement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSettlement.BackgroundColor = System.Drawing.Color.White;
            this.dgvSettlement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSettlement.Location = new System.Drawing.Point(3, 55);
            this.dgvSettlement.Name = "dgvSettlement";
            this.dgvSettlement.RowTemplate.Height = 23;
            this.dgvSettlement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSettlement.Size = new System.Drawing.Size(782, 439);
            this.dgvSettlement.TabIndex = 12;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "新增核算单";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Checkup
            // 
            this.btn_Checkup.Location = new System.Drawing.Point(338, 20);
            this.btn_Checkup.Name = "btn_Checkup";
            this.btn_Checkup.Size = new System.Drawing.Size(75, 23);
            this.btn_Checkup.TabIndex = 11;
            this.btn_Checkup.Text = "审批";
            this.btn_Checkup.UseVisualStyleBackColor = true;
            this.btn_Checkup.Click += new System.EventHandler(this.btn_Checkup_Click);
            // 
            // btn_Assess
            // 
            this.btn_Assess.Location = new System.Drawing.Point(228, 20);
            this.btn_Assess.Name = "btn_Assess";
            this.btn_Assess.Size = new System.Drawing.Size(75, 23);
            this.btn_Assess.TabIndex = 11;
            this.btn_Assess.Text = "审核";
            this.btn_Assess.UseVisualStyleBackColor = true;
            this.btn_Assess.Click += new System.EventHandler(this.btn_Assess_Click);
            // 
            // FrmSalesSettlement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSalesSettlement";
            this.Tag = "FrmSalesSettlement";
            this.Text = "销售结算";
            this.Load += new System.EventHandler(this.FrmSalesSettlement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettlement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cbxCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btn_Checkup;
        private System.Windows.Forms.Button btn_Assess;
        private System.Windows.Forms.DataGridView dgvSettlement;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMDetail;
        private System.Windows.Forms.ToolStripMenuItem TSMBillDetail;

    }
}