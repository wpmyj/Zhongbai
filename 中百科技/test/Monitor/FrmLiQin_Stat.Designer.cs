namespace DasherStation.Monitor
{
    partial class FrmLiQin_Stat
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
            this.btn_query = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtStartDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_liQin = new System.Windows.Forms.DataGridView();
            this.fnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_liQin)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btn_query);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(641, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(528, 28);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 10;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "日期";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(254, 28);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.ShowUpDown = true;
            this.txtEndDate.Size = new System.Drawing.Size(112, 21);
            this.txtEndDate.TabIndex = 2;
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(73, 28);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.ShowUpDown = true;
            this.txtStartDate.Size = new System.Drawing.Size(112, 21);
            this.txtStartDate.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgv_liQin);
            this.groupBox2.Location = new System.Drawing.Point(4, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(641, 343);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgv_liQin
            // 
            this.dgv_liQin.BackgroundColor = System.Drawing.Color.White;
            this.dgv_liQin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_liQin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fnid,
            this.fno,
            this.fname,
            this.stat});
            this.dgv_liQin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_liQin.Location = new System.Drawing.Point(3, 17);
            this.dgv_liQin.Name = "dgv_liQin";
            this.dgv_liQin.RowTemplate.Height = 23;
            this.dgv_liQin.Size = new System.Drawing.Size(635, 323);
            this.dgv_liQin.TabIndex = 0;
            // 
            // fnid
            // 
            this.fnid.DataPropertyName = "fnid";
            this.fnid.HeaderText = "fnid";
            this.fnid.Name = "fnid";
            this.fnid.Visible = false;
            // 
            // fno
            // 
            this.fno.DataPropertyName = "fno";
            this.fno.HeaderText = "流量计编号";
            this.fno.Name = "fno";
            // 
            // fname
            // 
            this.fname.DataPropertyName = "fname";
            this.fname.HeaderText = "流量计名称";
            this.fname.Name = "fname";
            // 
            // stat
            // 
            this.stat.DataPropertyName = "fstat";
            this.stat.HeaderText = "累计流量读数(吨)";
            this.stat.Name = "stat";
            // 
            // FrmLiQin_Stat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 418);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmLiQin_Stat";
            this.Text = "流量历史记录查询";
            this.Load += new System.EventHandler(this.FrmLiQin_Stat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_liQin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtEndDate;
        private System.Windows.Forms.DateTimePicker txtStartDate;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.DataGridView dgv_liQin;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnid;
        private System.Windows.Forms.DataGridViewTextBoxColumn fno;
        private System.Windows.Forms.DataGridViewTextBoxColumn fname;
        private System.Windows.Forms.DataGridViewTextBoxColumn stat;
    }
}