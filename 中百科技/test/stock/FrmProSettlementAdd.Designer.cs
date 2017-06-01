namespace DasherStation.stock
{
    partial class FrmProSettlementAdd
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
            this.btn_scan = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.indentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indentMid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.piId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mmid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btn_scan);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 49);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btn_scan
            // 
            this.btn_scan.Location = new System.Drawing.Point(658, 15);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(75, 23);
            this.btn_scan.TabIndex = 5;
            this.btn_scan.Text = "开始扫描";
            this.btn_scan.UseVisualStyleBackColor = true;
            this.btn_scan.Visible = false;
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(302, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(347, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "合同名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "票据条码";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(76, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(149, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetail.RowHeadersWidth = 20;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(730, 271);
            this.dgvDetail.TabIndex = 4;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(658, 554);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 32);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "票据结算";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvMain);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(5, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 164);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "合同明细";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indentId,
            this.scId,
            this.indentMid,
            this.piId,
            this.id2,
            this.id3,
            this.mmid,
            this.mnid,
            this.id6,
            this.sort,
            this.id5,
            this.name,
            this.mkId,
            this.id4,
            this.model,
            this.Column1,
            this.provider,
            this.quantity,
            this.unitPrice,
            this.money,
            this.Column16,
            this.countNote});
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(3, 17);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMain.RowHeadersWidth = 20;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(733, 144);
            this.dgvMain.TabIndex = 0;
            // 
            // indentId
            // 
            this.indentId.DataPropertyName = "id";
            this.indentId.HeaderText = "indentId";
            this.indentId.Name = "indentId";
            this.indentId.ReadOnly = true;
            this.indentId.Visible = false;
            // 
            // scId
            // 
            this.scId.DataPropertyName = "scId";
            this.scId.HeaderText = "scId";
            this.scId.Name = "scId";
            this.scId.ReadOnly = true;
            this.scId.Visible = false;
            // 
            // indentMid
            // 
            this.indentMid.DataPropertyName = "mId";
            this.indentMid.HeaderText = "indentMid";
            this.indentMid.Name = "indentMid";
            this.indentMid.ReadOnly = true;
            this.indentMid.Visible = false;
            // 
            // piId
            // 
            this.piId.DataPropertyName = "piId";
            this.piId.HeaderText = "piId";
            this.piId.Name = "piId";
            this.piId.ReadOnly = true;
            this.piId.Visible = false;
            // 
            // id2
            // 
            this.id2.DataPropertyName = "id2";
            this.id2.HeaderText = "采购合同的id";
            this.id2.Name = "id2";
            this.id2.ReadOnly = true;
            this.id2.Visible = false;
            // 
            // id3
            // 
            this.id3.DataPropertyName = "id3";
            this.id3.HeaderText = "材料的id";
            this.id3.Name = "id3";
            this.id3.ReadOnly = true;
            this.id3.Visible = false;
            // 
            // mmid
            // 
            this.mmid.DataPropertyName = "mmid";
            this.mmid.HeaderText = "mmid";
            this.mmid.Name = "mmid";
            this.mmid.ReadOnly = true;
            this.mmid.Visible = false;
            // 
            // mnid
            // 
            this.mnid.DataPropertyName = "mnid";
            this.mnid.HeaderText = "mnid";
            this.mnid.Name = "mnid";
            this.mnid.ReadOnly = true;
            this.mnid.Visible = false;
            // 
            // id6
            // 
            this.id6.DataPropertyName = "id6";
            this.id6.HeaderText = "材料种类的id";
            this.id6.Name = "id6";
            this.id6.ReadOnly = true;
            this.id6.Visible = false;
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "材料种类";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            // 
            // id5
            // 
            this.id5.DataPropertyName = "id5";
            this.id5.HeaderText = "材料名称id";
            this.id5.Name = "id5";
            this.id5.ReadOnly = true;
            this.id5.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "mname";
            this.name.HeaderText = "材料名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // mkId
            // 
            this.mkId.DataPropertyName = "mkId";
            this.mkId.HeaderText = "名称里对应种类的id";
            this.mkId.Name = "mkId";
            this.mkId.ReadOnly = true;
            this.mkId.Visible = false;
            this.mkId.Width = 120;
            // 
            // id4
            // 
            this.id4.DataPropertyName = "id4";
            this.id4.HeaderText = "材料规格id";
            this.id4.Name = "id4";
            this.id4.ReadOnly = true;
            this.id4.Visible = false;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "材料规格";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id1";
            this.Column1.HeaderText = "供应商的id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // provider
            // 
            this.provider.DataPropertyName = "pname";
            this.provider.HeaderText = "供应商名称";
            this.provider.Name = "provider";
            this.provider.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "货物数量";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            this.unitPrice.HeaderText = "货物单价";
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.ReadOnly = true;
            // 
            // money
            // 
            this.money.HeaderText = "金额";
            this.money.Name = "money";
            this.money.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "quantity";
            this.Column16.HeaderText = "Column16";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Visible = false;
            // 
            // countNote
            // 
            this.countNote.HeaderText = "小票数量";
            this.countNote.Name = "countNote";
            this.countNote.ReadOnly = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(302, 17);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "总金额";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(76, 17);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "总重量";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(5, 504);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(736, 47);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(546, 17);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(478, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "票据总数";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.dgvDetail);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(5, 221);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(736, 291);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "小票信息";
            // 
            // FrmProSettlementAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 590);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmProSettlementAdd";
            this.Tag = "FrmProSettlementAdd";
            this.Text = "新建核算单";
            this.Load += new System.EventHandler(this.FrmProSettlementAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn indentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn scId;
        private System.Windows.Forms.DataGridViewTextBoxColumn indentMid;
        private System.Windows.Forms.DataGridViewTextBoxColumn piId;
        private System.Windows.Forms.DataGridViewTextBoxColumn id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id3;
        private System.Windows.Forms.DataGridViewTextBoxColumn mmid;
        private System.Windows.Forms.DataGridViewTextBoxColumn mnid;
        private System.Windows.Forms.DataGridViewTextBoxColumn id6;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn id5;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn mkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn id4;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn provider;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn money;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn countNote;
    }
}