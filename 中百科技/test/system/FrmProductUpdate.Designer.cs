namespace DasherStation.system
{
    partial class FrmProductUpdate
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
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_planPrice = new System.Windows.Forms.TextBox();
            this.txt_nstock = new System.Windows.Forms.TextBox();
            this.txt_density = new System.Windows.Forms.TextBox();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.txt_rate = new System.Windows.Forms.TextBox();
            this.txt_model = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_kind = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.txt_planPrice);
            this.groupBox1.Controls.Add(this.txt_nstock);
            this.groupBox1.Controls.Add(this.txt_density);
            this.groupBox1.Controls.Add(this.txt_remark);
            this.groupBox1.Controls.Add(this.txt_rate);
            this.groupBox1.Controls.Add(this.txt_model);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.txt_kind);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Location = new System.Drawing.Point(5, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(288, 191);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 92;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_planPrice
            // 
            this.txt_planPrice.Location = new System.Drawing.Point(275, 72);
            this.txt_planPrice.Name = "txt_planPrice";
            this.txt_planPrice.Size = new System.Drawing.Size(88, 21);
            this.txt_planPrice.TabIndex = 5;
            this.txt_planPrice.Tag = "S";
            // 
            // txt_nstock
            // 
            this.txt_nstock.Location = new System.Drawing.Point(275, 44);
            this.txt_nstock.Name = "txt_nstock";
            this.txt_nstock.Size = new System.Drawing.Size(88, 21);
            this.txt_nstock.TabIndex = 3;
            this.txt_nstock.Tag = "S";
            // 
            // txt_density
            // 
            this.txt_density.Location = new System.Drawing.Point(275, 17);
            this.txt_density.Name = "txt_density";
            this.txt_density.Size = new System.Drawing.Size(88, 21);
            this.txt_density.TabIndex = 1;
            this.txt_density.Tag = "F";
            // 
            // txt_remark
            // 
            this.txt_remark.Location = new System.Drawing.Point(76, 111);
            this.txt_remark.Multiline = true;
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(287, 51);
            this.txt_remark.TabIndex = 7;
            this.txt_remark.Tag = "S";
            // 
            // txt_rate
            // 
            this.txt_rate.Location = new System.Drawing.Point(88, 192);
            this.txt_rate.Name = "txt_rate";
            this.txt_rate.Size = new System.Drawing.Size(118, 21);
            this.txt_rate.TabIndex = 6;
            this.txt_rate.Tag = "S";
            this.txt_rate.Visible = false;
            // 
            // txt_model
            // 
            this.txt_model.Enabled = false;
            this.txt_model.Location = new System.Drawing.Point(76, 72);
            this.txt_model.Name = "txt_model";
            this.txt_model.Size = new System.Drawing.Size(118, 21);
            this.txt_model.TabIndex = 4;
            // 
            // txt_name
            // 
            this.txt_name.Enabled = false;
            this.txt_name.Location = new System.Drawing.Point(76, 44);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(118, 21);
            this.txt_name.TabIndex = 2;
            // 
            // txt_kind
            // 
            this.txt_kind.Enabled = false;
            this.txt_kind.Location = new System.Drawing.Point(76, 17);
            this.txt_kind.Name = "txt_kind";
            this.txt_kind.Size = new System.Drawing.Size(118, 21);
            this.txt_kind.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(204, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 83;
            this.label14.Text = "计划价格";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(204, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 12);
            this.label12.TabIndex = 82;
            this.label12.Text = "最低库存(t)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 81;
            this.label7.Text = "密度(t/m³)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(29, 196);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 80;
            this.label16.Text = "损耗率";
            this.label16.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 77;
            this.label8.Text = "产品名称";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 78;
            this.label11.Text = "产品规格";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 79;
            this.label13.Text = "备注";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 76;
            this.label15.Text = "产品种类";
            // 
            // FrmProductUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 231);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmProductUpdate";
            this.Tag = "FrmProductUpdate";
            this.Text = "产品信息更新";
            this.Load += new System.EventHandler(this.FrmProductUpdate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_planPrice;
        private System.Windows.Forms.TextBox txt_nstock;
        private System.Windows.Forms.TextBox txt_density;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.TextBox txt_rate;
        private System.Windows.Forms.TextBox txt_model;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_kind;
        private System.Windows.Forms.Button btn_save;
    }
}