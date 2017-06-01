namespace DasherStation.Finance.AccountBooks
{
    partial class FrmSellBalance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkInvoice = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtgRecord = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnViewSettlementDetail = new System.Windows.Forms.Button();
            this.dtgSettlement = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCheck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArrearage = new System.Windows.Forms.TextBox();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.txtAccountReceivable = new System.Windows.Forms.TextBox();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打印应付款ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印收款记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecord)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSettlement)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(343, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 12);
            this.label8.TabIndex = 33;
            this.label8.Text = "欠款余额";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(181, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "己收总额";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(19, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "应收总额";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.chkInvoice);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtInvoiceNo);
            this.groupBox4.Location = new System.Drawing.Point(451, 436);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(245, 44);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            // 
            // chkInvoice
            // 
            this.chkInvoice.AutoSize = true;
            this.chkInvoice.Location = new System.Drawing.Point(6, 16);
            this.chkInvoice.Name = "chkInvoice";
            this.chkInvoice.Size = new System.Drawing.Size(48, 16);
            this.chkInvoice.TabIndex = 7;
            this.chkInvoice.Text = "发票";
            this.chkInvoice.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "发票号";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(114, 14);
            this.txtInvoiceNo.MaxLength = 20;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(100, 21);
            this.txtInvoiceNo.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dtgRecord);
            this.groupBox3.Location = new System.Drawing.Point(7, 274);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(703, 156);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "收款记录";
            // 
            // dtgRecord
            // 
            this.dtgRecord.AllowUserToAddRows = false;
            this.dtgRecord.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgRecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16,
            this.Column18,
            this.Column4,
            this.Column5,
            this.Column17});
            this.dtgRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgRecord.Location = new System.Drawing.Point(3, 17);
            this.dtgRecord.Name = "dtgRecord";
            this.dtgRecord.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgRecord.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgRecord.RowTemplate.Height = 23;
            this.dtgRecord.Size = new System.Drawing.Size(697, 136);
            this.dtgRecord.TabIndex = 15;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "id";
            this.Column15.HeaderText = "收款记录编号";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "paidUp";
            this.Column16.HeaderText = "收款额";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "inputdate";
            dataGridViewCellStyle2.Format = "f";
            dataGridViewCellStyle2.NullValue = null;
            this.Column18.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column18.HeaderText = "收款时间";
            this.Column18.MinimumWidth = 100;
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 130;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "checkNo";
            this.Column4.HeaderText = "支票号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "invoiceNo";
            this.Column5.HeaderText = "发票号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "remark";
            this.Column17.HeaderText = "备注";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 150;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnViewSettlementDetail);
            this.groupBox2.Controls.Add(this.dtgSettlement);
            this.groupBox2.Location = new System.Drawing.Point(7, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(703, 164);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "销售核算单";
            // 
            // btnViewSettlementDetail
            // 
            this.btnViewSettlementDetail.Location = new System.Drawing.Point(10, 135);
            this.btnViewSettlementDetail.Name = "btnViewSettlementDetail";
            this.btnViewSettlementDetail.Size = new System.Drawing.Size(106, 23);
            this.btnViewSettlementDetail.TabIndex = 14;
            this.btnViewSettlementDetail.Text = "查看核算单明细";
            this.btnViewSettlementDetail.UseVisualStyleBackColor = true;
            this.btnViewSettlementDetail.Click += new System.EventHandler(this.btnViewSettlementDetail_Click);
            // 
            // dtgSettlement
            // 
            this.dtgSettlement.AllowUserToAddRows = false;
            this.dtgSettlement.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSettlement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgSettlement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSettlement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column6,
            this.Column3,
            this.Column7,
            this.Column14,
            this.Column8});
            this.dtgSettlement.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtgSettlement.Location = new System.Drawing.Point(3, 17);
            this.dtgSettlement.Name = "dtgSettlement";
            this.dtgSettlement.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSettlement.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgSettlement.RowTemplate.Height = 23;
            this.dtgSettlement.Size = new System.Drawing.Size(697, 112);
            this.dtgSettlement.TabIndex = 13;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "核算单编号";
            this.Column1.HeaderText = "核算单编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "核算单对应合同";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "合同名称";
            this.Column6.HeaderText = "合同名称";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "货物总重";
            this.Column3.HeaderText = "货物总重";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "票据数";
            this.Column7.HeaderText = "票据数";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "总金额";
            dataGridViewCellStyle5.Format = "N2";
            this.Column14.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column14.HeaderText = "总金额";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "备注";
            this.Column8.HeaderText = "备注";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(22, 497);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "备注";
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(72, 493);
            this.txtMemo.MaxLength = 20;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(207, 51);
            this.txtMemo.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkCheck);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCheckNo);
            this.groupBox1.Location = new System.Drawing.Point(193, 436);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 44);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // chkCheck
            // 
            this.chkCheck.AutoSize = true;
            this.chkCheck.Location = new System.Drawing.Point(6, 16);
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.Size = new System.Drawing.Size(72, 16);
            this.chkCheck.TabIndex = 7;
            this.chkCheck.Text = "支票付款";
            this.chkCheck.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "支票号";
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Location = new System.Drawing.Point(132, 14);
            this.txtCheckNo.MaxLength = 20;
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(100, 21);
            this.txtCheckNo.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(161, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "元";
            // 
            // txtArrearage
            // 
            this.txtArrearage.BackColor = System.Drawing.Color.White;
            this.txtArrearage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArrearage.Location = new System.Drawing.Point(402, 50);
            this.txtArrearage.MaxLength = 50;
            this.txtArrearage.Name = "txtArrearage";
            this.txtArrearage.ReadOnly = true;
            this.txtArrearage.Size = new System.Drawing.Size(95, 21);
            this.txtArrearage.TabIndex = 23;
            // 
            // txtPaid
            // 
            this.txtPaid.BackColor = System.Drawing.Color.White;
            this.txtPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaid.Location = new System.Drawing.Point(239, 50);
            this.txtPaid.MaxLength = 50;
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.ReadOnly = true;
            this.txtPaid.Size = new System.Drawing.Size(95, 21);
            this.txtPaid.TabIndex = 22;
            // 
            // txtAccountReceivable
            // 
            this.txtAccountReceivable.BackColor = System.Drawing.Color.White;
            this.txtAccountReceivable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountReceivable.Location = new System.Drawing.Point(76, 50);
            this.txtAccountReceivable.MaxLength = 50;
            this.txtAccountReceivable.Name = "txtAccountReceivable";
            this.txtAccountReceivable.ReadOnly = true;
            this.txtAccountReceivable.Size = new System.Drawing.Size(95, 21);
            this.txtAccountReceivable.TabIndex = 25;
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(74, 448);
            this.txtPayment.MaxLength = 20;
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(77, 21);
            this.txtPayment.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(19, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "本次收款";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.Location = new System.Drawing.Point(72, 570);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(76, 15);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(158, 20);
            this.cboClient.TabIndex = 19;
            this.cboClient.SelectedIndexChanged += new System.EventHandler(this.cboClient_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(45, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 12);
            this.label9.TabIndex = 44;
            this.label9.Text = "客户";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.ContextMenuStrip = this.contextMenuStrip1;
            this.btnPrint.Location = new System.Drawing.Point(179, 570);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 45;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btnPrint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPrint_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打印应付款ToolStripMenuItem,
            this.打印收款记录ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 打印应付款ToolStripMenuItem
            // 
            this.打印应付款ToolStripMenuItem.Name = "打印应付款ToolStripMenuItem";
            this.打印应付款ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.打印应付款ToolStripMenuItem.Text = "打印应付款";
            this.打印应付款ToolStripMenuItem.Click += new System.EventHandler(this.打印应付款ToolStripMenuItem_Click_1);
            // 
            // 打印收款记录ToolStripMenuItem
            // 
            this.打印收款记录ToolStripMenuItem.Name = "打印收款记录ToolStripMenuItem";
            this.打印收款记录ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.打印收款记录ToolStripMenuItem.Text = "打印收款记录";
            this.打印收款记录ToolStripMenuItem.Click += new System.EventHandler(this.打印收款记录ToolStripMenuItem_Click);
            // 
            // FrmSellBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 603);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtArrearage);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.txtAccountReceivable);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboClient);
            this.Name = "FrmSellBalance";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "销售核算账务管理";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecord)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSettlement)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkInvoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgRecord;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnViewSettlementDetail;
        private System.Windows.Forms.DataGridView dtgSettlement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArrearage;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.TextBox txtAccountReceivable;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cboClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打印应付款ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印收款记录ToolStripMenuItem;
    }
}