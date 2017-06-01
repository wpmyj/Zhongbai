namespace DasherStation.system
{
    partial class FrmParameter
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_piId = new System.Windows.Forms.ComboBox();
            this.dtp_system = new System.Windows.Forms.DateTimePicker();
            this.txt_postNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_fax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_enterpriseKind = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_dasherName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(90, 174);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(7, 174);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "保存";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbx_piId);
            this.groupBox1.Controls.Add(this.dtp_system);
            this.groupBox1.Controls.Add(this.txt_postNo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txt_phone);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_fax);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_enterpriseKind);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_address);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_dasherName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 161);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数";
            // 
            // cbx_piId
            // 
            this.cbx_piId.FormattingEnabled = true;
            this.cbx_piId.Location = new System.Drawing.Point(113, 73);
            this.cbx_piId.Name = "cbx_piId";
            this.cbx_piId.Size = new System.Drawing.Size(100, 20);
            this.cbx_piId.TabIndex = 47;
            // 
            // dtp_system
            // 
            this.dtp_system.Location = new System.Drawing.Point(113, 16);
            this.dtp_system.Name = "dtp_system";
            this.dtp_system.Size = new System.Drawing.Size(148, 21);
            this.dtp_system.TabIndex = 46;
            // 
            // txt_postNo
            // 
            this.txt_postNo.Location = new System.Drawing.Point(113, 127);
            this.txt_postNo.Name = "txt_postNo";
            this.txt_postNo.Size = new System.Drawing.Size(100, 21);
            this.txt_postNo.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 44;
            this.label11.Text = "邮编";
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(113, 100);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(100, 21);
            this.txt_phone.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 40;
            this.label9.Text = "联系电话";
            // 
            // txt_fax
            // 
            this.txt_fax.Location = new System.Drawing.Point(328, 100);
            this.txt_fax.Name = "txt_fax";
            this.txt_fax.Size = new System.Drawing.Size(100, 21);
            this.txt_fax.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(267, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 38;
            this.label8.Text = "传真";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "负责人";
            // 
            // txt_enterpriseKind
            // 
            this.txt_enterpriseKind.Location = new System.Drawing.Point(328, 73);
            this.txt_enterpriseKind.Name = "txt_enterpriseKind";
            this.txt_enterpriseKind.Size = new System.Drawing.Size(100, 21);
            this.txt_enterpriseKind.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(267, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "企业性质";
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(113, 44);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(315, 21);
            this.txt_address.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "单位地址";
            // 
            // txt_dasherName
            // 
            this.txt_dasherName.Location = new System.Drawing.Point(328, 17);
            this.txt_dasherName.Name = "txt_dasherName";
            this.txt_dasherName.Size = new System.Drawing.Size(100, 21);
            this.txt_dasherName.TabIndex = 31;
            this.txt_dasherName.Tag = "S";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "单位名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "系统使用日期";
            // 
            // FrmParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 205);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmParameter";
            this.Tag = "FrmParameter";
            this.Text = "参数设定";
            this.Load += new System.EventHandler(this.FrmParameter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbx_piId;
        private System.Windows.Forms.DateTimePicker dtp_system;
        private System.Windows.Forms.TextBox txt_postNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_fax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_enterpriseKind;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_dasherName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;

      
    }
}