namespace DasherStation.system
{
    partial class FrmProjectNameUpdate
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
            this.label5 = new System.Windows.Forms.Label();
            this.txt_position = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_itemProject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_no = new System.Windows.Forms.TextBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_subsectionProject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_unitProject = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_position);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_itemProject);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_no);
            this.groupBox1.Controls.Add(this.btn_exit);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_subsectionProject);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_unitProject);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 109);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "仓库信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "工程部位";
            // 
            // txt_position
            // 
            this.txt_position.Location = new System.Drawing.Point(397, 47);
            this.txt_position.Name = "txt_position";
            this.txt_position.Size = new System.Drawing.Size(87, 21);
            this.txt_position.TabIndex = 5;
            this.txt_position.Tag = "ES";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "工程名称";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(237, 47);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(87, 21);
            this.txt_name.TabIndex = 4;
            this.txt_name.Tag = "ES";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "分项工程";
            // 
            // txt_itemProject
            // 
            this.txt_itemProject.Location = new System.Drawing.Point(73, 47);
            this.txt_itemProject.Name = "txt_itemProject";
            this.txt_itemProject.Size = new System.Drawing.Size(87, 21);
            this.txt_itemProject.TabIndex = 3;
            this.txt_itemProject.Tag = "ES";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "工程编号";
            // 
            // txt_no
            // 
            this.txt_no.Location = new System.Drawing.Point(397, 20);
            this.txt_no.Name = "txt_no";
            this.txt_no.Size = new System.Drawing.Size(87, 21);
            this.txt_no.TabIndex = 2;
            this.txt_no.Tag = "ES";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(446, 78);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(50, 23);
            this.btn_exit.TabIndex = 7;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(15, 78);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(50, 23);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "分部工程";
            // 
            // txt_subsectionProject
            // 
            this.txt_subsectionProject.Location = new System.Drawing.Point(237, 20);
            this.txt_subsectionProject.Name = "txt_subsectionProject";
            this.txt_subsectionProject.Size = new System.Drawing.Size(87, 21);
            this.txt_subsectionProject.TabIndex = 1;
            this.txt_subsectionProject.Tag = "ES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "单位工程";
            // 
            // txt_unitProject
            // 
            this.txt_unitProject.Location = new System.Drawing.Point(73, 20);
            this.txt_unitProject.Name = "txt_unitProject";
            this.txt_unitProject.Size = new System.Drawing.Size(87, 21);
            this.txt_unitProject.TabIndex = 0;
            this.txt_unitProject.Tag = "ES";
            // 
            // FrmProjectNameUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 124);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmProjectNameUpdate";
            this.Tag = "FrmProjectNameUpdate";
            this.Text = "FrmProjectNameUpdate";
            this.Load += new System.EventHandler(this.FrmProjectNameUpdate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_position;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_itemProject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_no;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_subsectionProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_unitProject;
        private System.Windows.Forms.Button btn_save;
    }
}