namespace DasherStation
{
    partial class About
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.txtAboutUs = new System.Windows.Forms.RichTextBox();
            this.company = new System.Windows.Forms.Label();
            this.copyright = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.product = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(481, 95);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.txtAboutUs);
            this.panel1.Controls.Add(this.company);
            this.panel1.Controls.Add(this.copyright);
            this.panel1.Controls.Add(this.version);
            this.panel1.Controls.Add(this.product);
            this.panel1.Controls.Add(this.logoPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(9, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 310);
            this.panel1.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(406, 274);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "关闭";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtAboutUs
            // 
            this.txtAboutUs.Location = new System.Drawing.Point(0, 155);
            this.txtAboutUs.Name = "txtAboutUs";
            this.txtAboutUs.Size = new System.Drawing.Size(386, 144);
            this.txtAboutUs.TabIndex = 18;
            this.txtAboutUs.Text = "";
            // 
            // company
            // 
            this.company.AutoSize = true;
            this.company.Location = new System.Drawing.Point(8, 140);
            this.company.Name = "company";
            this.company.Size = new System.Drawing.Size(53, 12);
            this.company.TabIndex = 17;
            this.company.Text = "公司名称";
            // 
            // copyright
            // 
            this.copyright.AutoSize = true;
            this.copyright.Location = new System.Drawing.Point(8, 126);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(29, 12);
            this.copyright.TabIndex = 16;
            this.copyright.Text = "版权";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(8, 112);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(29, 12);
            this.version.TabIndex = 15;
            this.version.Text = "版本";
            // 
            // product
            // 
            this.product.AutoSize = true;
            this.product.Location = new System.Drawing.Point(8, 98);
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(53, 12);
            this.product.TabIndex = 14;
            this.product.Text = "产品名称";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 326);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Tag = "About";
            this.Text = "关于...";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label company;
        private System.Windows.Forms.Label copyright;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label product;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox txtAboutUs;

    }
}
