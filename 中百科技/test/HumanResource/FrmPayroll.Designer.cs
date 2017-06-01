namespace DasherStation.HumanResource
{
    partial class FrmPayroll
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgList = new System.Windows.Forms.DataGridView();
            this.iID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frontSub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.behindSub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adapterType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.txtPayName = new System.Windows.Forms.TextBox();
            this.cboAddType = new System.Windows.Forms.ComboBox();
            this.cboSub = new System.Windows.Forms.ComboBox();
            this.cboHumanType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgList
            // 
            this.dtgList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iID,
            this.colName,
            this.addType,
            this.frontSub,
            this.behindSub,
            this.adapterType,
            this.cMemo});
            this.dtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgList.Location = new System.Drawing.Point(3, 17);
            this.dtgList.Name = "dtgList";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgList.RowTemplate.Height = 23;
            this.dtgList.Size = new System.Drawing.Size(779, 200);
            this.dtgList.TabIndex = 0;
            // 
            // iID
            // 
            this.iID.DataPropertyName = "iID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.iID.DefaultCellStyle = dataGridViewCellStyle2;
            this.iID.Frozen = true;
            this.iID.HeaderText = "序号";
            this.iID.Name = "iID";
            this.iID.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "cName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colName.HeaderText = "工资项名称";
            this.colName.Name = "colName";
            // 
            // addType
            // 
            this.addType.DataPropertyName = "cMark";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.addType.DefaultCellStyle = dataGridViewCellStyle4;
            this.addType.HeaderText = "加项类别";
            this.addType.Name = "addType";
            this.addType.ReadOnly = true;
            // 
            // frontSub
            // 
            this.frontSub.DataPropertyName = "fMinusPlace";
            this.frontSub.HeaderText = "前减项";
            this.frontSub.Name = "frontSub";
            // 
            // behindSub
            // 
            this.behindSub.DataPropertyName = "bMinusPlace";
            this.behindSub.HeaderText = "后减项";
            this.behindSub.Name = "behindSub";
            this.behindSub.ReadOnly = true;
            this.behindSub.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.behindSub.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // adapterType
            // 
            this.adapterType.DataPropertyName = "cKind";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.adapterType.DefaultCellStyle = dataGridViewCellStyle5;
            this.adapterType.HeaderText = "适用类别";
            this.adapterType.Name = "adapterType";
            this.adapterType.ReadOnly = true;
            // 
            // cMemo
            // 
            this.cMemo.DataPropertyName = "cMemo";
            this.cMemo.HeaderText = "备注";
            this.cMemo.Name = "cMemo";
            this.cMemo.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "工资项名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(38, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "加项类别：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(38, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "减项类别：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(38, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "适用类别：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(62, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "备注：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.Location = new System.Drawing.Point(128, 267);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(225, 267);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(128, 155);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(259, 101);
            this.txtMemo.TabIndex = 8;
            // 
            // txtPayName
            // 
            this.txtPayName.Location = new System.Drawing.Point(128, 22);
            this.txtPayName.Name = "txtPayName";
            this.txtPayName.Size = new System.Drawing.Size(121, 21);
            this.txtPayName.TabIndex = 9;
            // 
            // cboAddType
            // 
            this.cboAddType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAddType.FormattingEnabled = true;
            this.cboAddType.Items.AddRange(new object[] {
            "薪水减",
            "薪水增"});
            this.cboAddType.Location = new System.Drawing.Point(128, 56);
            this.cboAddType.Name = "cboAddType";
            this.cboAddType.Size = new System.Drawing.Size(121, 20);
            this.cboAddType.TabIndex = 10;
            this.cboAddType.Tag = "";
            this.cboAddType.SelectedIndexChanged += new System.EventHandler(this.cboAddType_SelectedIndexChanged);
            // 
            // cboSub
            // 
            this.cboSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSub.FormattingEnabled = true;
            this.cboSub.Items.AddRange(new object[] {
            "前减项",
            "后减项"});
            this.cboSub.Location = new System.Drawing.Point(128, 89);
            this.cboSub.Name = "cboSub";
            this.cboSub.Size = new System.Drawing.Size(121, 20);
            this.cboSub.TabIndex = 11;
            this.cboSub.Tag = "";
            // 
            // cboHumanType
            // 
            this.cboHumanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHumanType.FormattingEnabled = true;
            this.cboHumanType.Items.AddRange(new object[] {
            "正式职工",
            "临时工",
            "全部员工"});
            this.cboHumanType.Location = new System.Drawing.Point(128, 122);
            this.cboHumanType.Name = "cboHumanType";
            this.cboHumanType.Size = new System.Drawing.Size(121, 20);
            this.cboHumanType.TabIndex = 12;
            this.cboHumanType.Tag = "";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboHumanType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboSub);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboAddType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPayName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMemo);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 310);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "录入区";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(322, 267);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dtgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 312);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(785, 220);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // FrmPayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 534);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPayroll";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Tag = "FrmPayroll";
            this.Text = "工资项";
            ((System.ComponentModel.ISupportInitialize)(this.dtgList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.TextBox txtPayName;
        private System.Windows.Forms.ComboBox cboAddType;
        private System.Windows.Forms.ComboBox cboSub;
        private System.Windows.Forms.ComboBox cboHumanType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn addType;
        private System.Windows.Forms.DataGridViewTextBoxColumn frontSub;
        private System.Windows.Forms.DataGridViewTextBoxColumn behindSub;
        private System.Windows.Forms.DataGridViewTextBoxColumn adapterType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMemo;
        private System.Windows.Forms.Button btnClose;
    }
}