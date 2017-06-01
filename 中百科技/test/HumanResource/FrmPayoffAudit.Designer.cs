namespace DasherStation.HumanResource
{
    partial class FrmPayoffAudit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtgList = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cboPayoffName = new System.Windows.Forms.ComboBox();
            this.btnAudit2 = new System.Windows.Forms.Button();
            this.btnAudit1 = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.datePayOff = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgList)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "工资发放名称";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(897, 433);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询区";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dtgList);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 79);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(891, 351);
            this.panel6.TabIndex = 11;
            // 
            // dtgList
            // 
            this.dtgList.AllowUserToAddRows = false;
            this.dtgList.AllowUserToDeleteRows = false;
            this.dtgList.AllowUserToOrderColumns = true;
            this.dtgList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgList.Location = new System.Drawing.Point(0, 0);
            this.dtgList.Name = "dtgList";
            this.dtgList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgList.RowTemplate.Height = 23;
            this.dtgList.Size = new System.Drawing.Size(891, 351);
            this.dtgList.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboPayoffName);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.btnAudit2);
            this.panel5.Controls.Add(this.btnAudit1);
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.datePayOff);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(891, 62);
            this.panel5.TabIndex = 10;
            // 
            // cboPayoffName
            // 
            this.cboPayoffName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayoffName.FormattingEnabled = true;
            this.cboPayoffName.Location = new System.Drawing.Point(292, 15);
            this.cboPayoffName.Name = "cboPayoffName";
            this.cboPayoffName.Size = new System.Drawing.Size(121, 20);
            this.cboPayoffName.TabIndex = 5;
            // 
            // btnAudit2
            // 
            this.btnAudit2.Location = new System.Drawing.Point(626, 13);
            this.btnAudit2.Name = "btnAudit2";
            this.btnAudit2.Size = new System.Drawing.Size(75, 23);
            this.btnAudit2.TabIndex = 2;
            this.btnAudit2.Text = "审批";
            this.btnAudit2.UseVisualStyleBackColor = true;
            this.btnAudit2.Click += new System.EventHandler(this.btnAudit2_Click);
            // 
            // btnAudit1
            // 
            this.btnAudit1.Location = new System.Drawing.Point(534, 13);
            this.btnAudit1.Name = "btnAudit1";
            this.btnAudit1.Size = new System.Drawing.Size(75, 23);
            this.btnAudit1.TabIndex = 2;
            this.btnAudit1.Text = "审核";
            this.btnAudit1.UseVisualStyleBackColor = true;
            this.btnAudit1.Click += new System.EventHandler(this.btnAudit1_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(442, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询月份";
            // 
            // datePayOff
            // 
            this.datePayOff.CustomFormat = "yyyy年 MM";
            this.datePayOff.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePayOff.Location = new System.Drawing.Point(80, 15);
            this.datePayOff.Name = "datePayOff";
            this.datePayOff.ShowUpDown = true;
            this.datePayOff.Size = new System.Drawing.Size(100, 21);
            this.datePayOff.TabIndex = 0;
            // 
            // FrmPayoffAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 441);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPayoffAudit";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Tag = "FrmPayoffAudit";
            this.Text = "薪资审核审批";
            this.groupBox1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgList)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dtgList;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePayOff;
        private System.Windows.Forms.ComboBox cboPayoffName;
        private System.Windows.Forms.Button btnAudit2;
        private System.Windows.Forms.Button btnAudit1;
    }
}