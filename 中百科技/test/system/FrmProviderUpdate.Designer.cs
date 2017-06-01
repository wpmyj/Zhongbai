namespace DasherStation.system
{
    partial class FrmProviderUpdate
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
            this.txt_produceNo = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbx_mark = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.txt_principal = new System.Windows.Forms.TextBox();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.txt_eMail = new System.Windows.Forms.TextBox();
            this.txt_postCode = new System.Windows.Forms.TextBox();
            this.txt_artificialMan = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txt_produceNo);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cbx_mark);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.txt_phone);
            this.groupBox1.Controls.Add(this.txt_principal);
            this.groupBox1.Controls.Add(this.txt_remark);
            this.groupBox1.Controls.Add(this.txt_address);
            this.groupBox1.Controls.Add(this.txt_eMail);
            this.groupBox1.Controls.Add(this.txt_postCode);
            this.groupBox1.Controls.Add(this.txt_artificialMan);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 284);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txt_produceNo
            // 
            this.txt_produceNo.Location = new System.Drawing.Point(87, 102);
            this.txt_produceNo.Name = "txt_produceNo";
            this.txt_produceNo.Size = new System.Drawing.Size(274, 21);
            this.txt_produceNo.TabIndex = 6;
            this.txt_produceNo.Tag = "S";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(18, 107);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 38;
            this.label21.Text = "生产许可证";
            // 
            // cbx_mark
            // 
            this.cbx_mark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_mark.FormattingEnabled = true;
            this.cbx_mark.Items.AddRange(new object[] {
            "原材料供应商",
            "备品备件供应商"});
            this.cbx_mark.Location = new System.Drawing.Point(87, 74);
            this.cbx_mark.Name = "cbx_mark";
            this.cbx_mark.Size = new System.Drawing.Size(110, 20);
            this.cbx_mark.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "供应商类别";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(286, 250);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 20;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(263, 46);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(98, 21);
            this.txt_phone.TabIndex = 3;
            this.txt_phone.Tag = "S";
            // 
            // txt_principal
            // 
            this.txt_principal.Location = new System.Drawing.Point(263, 18);
            this.txt_principal.Name = "txt_principal";
            this.txt_principal.Size = new System.Drawing.Size(98, 21);
            this.txt_principal.TabIndex = 1;
            this.txt_principal.Tag = "S";
            // 
            // txt_remark
            // 
            this.txt_remark.Location = new System.Drawing.Point(87, 189);
            this.txt_remark.Multiline = true;
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(274, 51);
            this.txt_remark.TabIndex = 9;
            this.txt_remark.Tag = "S";
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(87, 160);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(274, 21);
            this.txt_address.TabIndex = 8;
            this.txt_address.Tag = "S";
            // 
            // txt_eMail
            // 
            this.txt_eMail.Location = new System.Drawing.Point(87, 131);
            this.txt_eMail.Name = "txt_eMail";
            this.txt_eMail.Size = new System.Drawing.Size(274, 21);
            this.txt_eMail.TabIndex = 7;
            this.txt_eMail.Tag = "S";
            // 
            // txt_postCode
            // 
            this.txt_postCode.Location = new System.Drawing.Point(263, 73);
            this.txt_postCode.Name = "txt_postCode";
            this.txt_postCode.Size = new System.Drawing.Size(98, 21);
            this.txt_postCode.TabIndex = 5;
            this.txt_postCode.Tag = "S";
            this.txt_postCode.Text = "15";
            // 
            // txt_artificialMan
            // 
            this.txt_artificialMan.Location = new System.Drawing.Point(87, 46);
            this.txt_artificialMan.Name = "txt_artificialMan";
            this.txt_artificialMan.Size = new System.Drawing.Size(111, 21);
            this.txt_artificialMan.TabIndex = 2;
            this.txt_artificialMan.Tag = "S";
            // 
            // txt_name
            // 
            this.txt_name.Enabled = false;
            this.txt_name.Location = new System.Drawing.Point(87, 18);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(111, 21);
            this.txt_name.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(218, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "负责人";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(218, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 8;
            this.label20.Text = "电话";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(218, 77);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 3;
            this.label16.Text = "邮编";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 190);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 6;
            this.label17.Text = "备注";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 1;
            this.label18.Text = "供应商名称";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 135);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 4;
            this.label19.Text = "E-mail";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(17, 49);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 12);
            this.label24.TabIndex = 2;
            this.label24.Text = "法人";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(17, 162);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 5;
            this.label25.Text = "地址";
            // 
            // FrmProviderUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 291);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "FrmProviderUpdate";
            this.Tag = "FrmProviderUpdate";
            this.Text = "供应商信息更新";
            this.Load += new System.EventHandler(this.FrmProviderUpdate_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmProviderUpdate_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.TextBox txt_principal;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.TextBox txt_eMail;
        private System.Windows.Forms.TextBox txt_postCode;
        private System.Windows.Forms.TextBox txt_artificialMan;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cbx_mark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_produceNo;
        private System.Windows.Forms.Label label21;
    }
}