namespace DasherStation.Monitor
{
    partial class FrmSengcanBHG
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_printer = new System.Windows.Forms.Button();
            this.btn_query = new System.Windows.Forms.Button();
            this.cbx_eiid = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_being = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_PMonitor = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_printer);
            this.groupBox1.Controls.Add(this.btn_query);
            this.groupBox1.Controls.Add(this.cbx_eiid);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp_end);
            this.groupBox1.Controls.Add(this.dtp_being);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(641, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "设备编号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "日期";
            // 
            // btn_printer
            // 
            this.btn_printer.Location = new System.Drawing.Point(533, 70);
            this.btn_printer.Name = "btn_printer";
            this.btn_printer.Size = new System.Drawing.Size(75, 23);
            this.btn_printer.TabIndex = 15;
            this.btn_printer.Text = "打印";
            this.btn_printer.UseVisualStyleBackColor = true;
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(432, 70);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 14;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // cbx_eiid
            // 
            this.cbx_eiid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_eiid.FormattingEnabled = true;
            this.cbx_eiid.Location = new System.Drawing.Point(87, 67);
            this.cbx_eiid.Name = "cbx_eiid";
            this.cbx_eiid.Size = new System.Drawing.Size(126, 20);
            this.cbx_eiid.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "--";
            // 
            // dtp_end
            // 
            this.dtp_end.Location = new System.Drawing.Point(250, 25);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.ShowUpDown = true;
            this.dtp_end.Size = new System.Drawing.Size(126, 21);
            this.dtp_end.TabIndex = 11;
            // 
            // dtp_being
            // 
            this.dtp_being.Location = new System.Drawing.Point(87, 25);
            this.dtp_being.Name = "dtp_being";
            this.dtp_being.ShowUpDown = true;
            this.dtp_being.Size = new System.Drawing.Size(126, 21);
            this.dtp_being.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgv_PMonitor);
            this.groupBox2.Location = new System.Drawing.Point(4, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(641, 305);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgv_PMonitor
            // 
            this.dgv_PMonitor.AllowUserToAddRows = false;
            this.dgv_PMonitor.BackgroundColor = System.Drawing.Color.White;
            this.dgv_PMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_PMonitor.Location = new System.Drawing.Point(3, 17);
            this.dgv_PMonitor.Name = "dgv_PMonitor";
            this.dgv_PMonitor.RowTemplate.Height = 23;
            this.dgv_PMonitor.Size = new System.Drawing.Size(635, 285);
            this.dgv_PMonitor.TabIndex = 0;
            // 
            // FrmSengcanBHG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 418);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSengcanBHG";
            this.Tag = "FrmSengcanBHG";
            this.Text = "混合料生产不合格记录";
            this.Load += new System.EventHandler(this.FrmSengcanBHG_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PMonitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_PMonitor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_printer;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.ComboBox cbx_eiid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.DateTimePicker dtp_being;
    }
}