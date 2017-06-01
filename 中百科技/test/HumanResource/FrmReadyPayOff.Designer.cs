namespace DasherStation.HumanResource
{
    partial class FrmReadyPayOff
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
            this.panPayRoll = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panPayRoll_flp = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOK2 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboRollTemplate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panPayRoll.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panPayRoll
            // 
            this.panPayRoll.BackColor = System.Drawing.Color.Transparent;
            this.panPayRoll.Controls.Add(this.panel3);
            this.panPayRoll.Controls.Add(this.panel2);
            this.panPayRoll.Controls.Add(this.panel1);
            this.panPayRoll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPayRoll.Location = new System.Drawing.Point(0, 0);
            this.panPayRoll.Name = "panPayRoll";
            this.panPayRoll.Size = new System.Drawing.Size(649, 246);
            this.panPayRoll.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panPayRoll_flp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(649, 147);
            this.panel3.TabIndex = 3;
            // 
            // panPayRoll_flp
            // 
            this.panPayRoll_flp.BackColor = System.Drawing.Color.Transparent;
            this.panPayRoll_flp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPayRoll_flp.Location = new System.Drawing.Point(0, 0);
            this.panPayRoll_flp.Name = "panPayRoll_flp";
            this.panPayRoll_flp.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.panPayRoll_flp.Size = new System.Drawing.Size(649, 147);
            this.panPayRoll_flp.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOK2);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 207);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 39);
            this.panel2.TabIndex = 2;
            // 
            // btnOK2
            // 
            this.btnOK2.Location = new System.Drawing.Point(166, 8);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(75, 23);
            this.btnOK2.TabIndex = 1;
            this.btnOK2.Text = "直接发放工资";
            this.btnOK2.UseVisualStyleBackColor = true;
            this.btnOK2.Click += new System.EventHandler(this.btnOK2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(14, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(132, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "保存模板并发放工资";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboRollTemplate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 60);
            this.panel1.TabIndex = 1;
            // 
            // cboRollTemplate
            // 
            this.cboRollTemplate.DisplayMember = "无";
            this.cboRollTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRollTemplate.FormattingEnabled = true;
            this.cboRollTemplate.Location = new System.Drawing.Point(93, 17);
            this.cboRollTemplate.Name = "cboRollTemplate";
            this.cboRollTemplate.Size = new System.Drawing.Size(121, 20);
            this.cboRollTemplate.TabIndex = 1;
            this.cboRollTemplate.SelectedIndexChanged += new System.EventHandler(this.cboRollTemplate_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工资项目模板";
            // 
            // FrmReadyPayOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 246);
            this.Controls.Add(this.panPayRoll);
            this.MaximizeBox = false;
            this.Name = "FrmReadyPayOff";
            this.Tag = "FrmReadyPayOff";
            this.Text = "选择发放工资项目";
            this.panPayRoll.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panPayRoll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboRollTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.FlowLayoutPanel panPayRoll_flp;
        private System.Windows.Forms.Button btnOK2;
    }
}