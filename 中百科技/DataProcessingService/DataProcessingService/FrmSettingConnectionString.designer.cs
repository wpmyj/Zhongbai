namespace DasherStation.DataProcessingService
{
    partial class FrmSettingConnectionString
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDatabaseName = new System.Windows.Forms.ComboBox();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(108, 26);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(159, 21);
            this.txtAddr.TabIndex = 1;
            this.txtAddr.Text = "192.168.1.202";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(108, 56);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(90, 21);
            this.txtUserID.TabIndex = 2;
            this.txtUserID.Text = "sa";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(108, 86);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(90, 21);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.Text = "123";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(139, 167);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据库名称:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboDatabaseName
            // 
            this.cboDatabaseName.DisplayMember = "DasherStation";
            this.cboDatabaseName.FormattingEnabled = true;
            this.cboDatabaseName.Items.AddRange(new object[] {
            "DasherStation"});
            this.cboDatabaseName.Location = new System.Drawing.Point(108, 117);
            this.cboDatabaseName.Name = "cboDatabaseName";
            this.cboDatabaseName.Size = new System.Drawing.Size(159, 20);
            this.cboDatabaseName.Sorted = true;
            this.cboDatabaseName.TabIndex = 4;
            this.cboDatabaseName.Enter += new System.EventHandler(this.cboDatabaseName_Enter);
            // 
            // btnTestConn
            // 
            this.btnTestConn.Location = new System.Drawing.Point(280, 115);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(63, 23);
            this.btnTestConn.TabIndex = 5;
            this.btnTestConn.Text = "测试链接";
            this.btnTestConn.UseVisualStyleBackColor = true;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // FrmSettingConnectionString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 218);
            this.Controls.Add(this.btnTestConn);
            this.Controls.Add(this.cboDatabaseName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtAddr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettingConnectionString";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置数据库链接";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDatabaseName;
        private System.Windows.Forms.Button btnTestConn;
    }
}