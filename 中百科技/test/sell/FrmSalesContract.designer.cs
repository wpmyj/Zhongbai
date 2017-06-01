namespace DasherStation.sell
{
    partial class FrmSalesContract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalesContract));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbContractStatus = new System.Windows.Forms.ComboBox();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cbxCondition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCStop = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btn_Checkup = new System.Windows.Forms.Button();
            this.btn_Assess = new System.Windows.Forms.Button();
            this.dgvSContract = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInvoiceStop = new System.Windows.Forms.Button();
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSContract)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbContractStatus);
            this.groupBox1.Controls.Add(this.txtCondition);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.cbxCondition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "合同状态";
            // 
            // cmbContractStatus
            // 
            this.cmbContractStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContractStatus.FormattingEnabled = true;
            this.cmbContractStatus.Items.AddRange(new object[] {
            "显示全部信息",
            "已终止合同",
            "未终止合同"});
            this.cmbContractStatus.Location = new System.Drawing.Point(68, 15);
            this.cmbContractStatus.Name = "cmbContractStatus";
            this.cmbContractStatus.Size = new System.Drawing.Size(121, 20);
            this.cmbContractStatus.TabIndex = 19;
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(429, 15);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(100, 21);
            this.txtCondition.TabIndex = 18;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(535, 14);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 17;
            this.btnQuery.Text = "搜索";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cbxCondition
            // 
            this.cbxCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCondition.FormattingEnabled = true;
            this.cbxCondition.Items.AddRange(new object[] {
            "未终止合同",
            "已终止合同",
            "合同名称",
            ""});
            this.cbxCondition.Location = new System.Drawing.Point(295, 15);
            this.cbxCondition.Name = "cbxCondition";
            this.cbxCondition.Size = new System.Drawing.Size(128, 20);
            this.cbxCondition.TabIndex = 14;
            this.cbxCondition.SelectionChangeCommitted += new System.EventHandler(this.cbxCondition_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "查询条件";
            // 
            // btnCStop
            // 
            this.btnCStop.Location = new System.Drawing.Point(98, 20);
            this.btnCStop.Name = "btnCStop";
            this.btnCStop.Size = new System.Drawing.Size(75, 23);
            this.btnCStop.TabIndex = 20;
            this.btnCStop.Text = "终止合同";
            this.btnCStop.UseVisualStyleBackColor = true;
            this.btnCStop.Click += new System.EventHandler(this.btnCStop_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(17, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "新建";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btn_Checkup);
            this.groupBox2.Controls.Add(this.btn_Assess);
            this.groupBox2.Controls.Add(this.dgvSContract);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnCStop);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(3, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(787, 245);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "合同信息";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(689, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 146;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(559, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 133;
            this.btnPrint.Text = "打印合同";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btn_Checkup
            // 
            this.btn_Checkup.Location = new System.Drawing.Point(339, 20);
            this.btn_Checkup.Name = "btn_Checkup";
            this.btn_Checkup.Size = new System.Drawing.Size(75, 23);
            this.btn_Checkup.TabIndex = 145;
            this.btn_Checkup.Text = "审批";
            this.btn_Checkup.UseVisualStyleBackColor = true;
            this.btn_Checkup.Click += new System.EventHandler(this.btn_Checkup_Click);
            // 
            // btn_Assess
            // 
            this.btn_Assess.Location = new System.Drawing.Point(258, 20);
            this.btn_Assess.Name = "btn_Assess";
            this.btn_Assess.Size = new System.Drawing.Size(75, 23);
            this.btn_Assess.TabIndex = 144;
            this.btn_Assess.Text = "审核";
            this.btn_Assess.UseVisualStyleBackColor = true;
            this.btn_Assess.Click += new System.EventHandler(this.btn_Assess_Click);
            // 
            // dgvSContract
            // 
            this.dgvSContract.AllowUserToAddRows = false;
            this.dgvSContract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSContract.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvSContract.Location = new System.Drawing.Point(4, 49);
            this.dgvSContract.Name = "dgvSContract";
            this.dgvSContract.ReadOnly = true;
            this.dgvSContract.RowTemplate.Height = 23;
            this.dgvSContract.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSContract.Size = new System.Drawing.Size(780, 192);
            this.dgvSContract.TabIndex = 22;
            this.dgvSContract.SelectionChanged += new System.EventHandler(this.dgvSContract_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btnInvoiceStop);
            this.groupBox3.Controls.Add(this.dgvInvoice);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(3, 301);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(787, 263);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "合同明细";
            // 
            // btnInvoiceStop
            // 
            this.btnInvoiceStop.Location = new System.Drawing.Point(17, 16);
            this.btnInvoiceStop.Name = "btnInvoiceStop";
            this.btnInvoiceStop.Size = new System.Drawing.Size(75, 23);
            this.btnInvoiceStop.TabIndex = 2;
            this.btnInvoiceStop.Text = "终止明细";
            this.btnInvoiceStop.UseVisualStyleBackColor = true;
            this.btnInvoiceStop.Click += new System.EventHandler(this.btnInvoiceStop_Click);
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoice.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoice.Location = new System.Drawing.Point(3, 45);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.RowTemplate.Height = 23;
            this.dgvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoice.Size = new System.Drawing.Size(781, 213);
            this.dgvInvoice.TabIndex = 1;
            // 
            // FrmSalesContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSalesContract";
            this.Tag = "FrmSalesContract";
            this.Text = "销售合同";
            this.Load += new System.EventHandler(this.FrmSalesContract_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSContract)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCStop;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cbxCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.DataGridView dgvSContract;
        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.Button btnInvoiceStop;
        private System.Windows.Forms.Button btn_Checkup;
        private System.Windows.Forms.Button btn_Assess;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbContractStatus;
    }
}