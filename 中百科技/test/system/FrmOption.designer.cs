namespace DasherStation.system
{
    partial class FrmOption
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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("地点");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("运输结算方式");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlPositin = new System.Windows.Forms.Panel();
            this.lstPositin = new System.Windows.Forms.ListBox();
            this.txtPositin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTeam = new System.Windows.Forms.Panel();
            this.dgvPTeam = new System.Windows.Forms.DataGridView();
            this.cbxPiId = new System.Windows.Forms.ComboBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSite = new System.Windows.Forms.Panel();
            this.lstSite = new System.Windows.Forms.ListBox();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlMethod = new System.Windows.Forms.Panel();
            this.lstMethod = new System.Windows.Forms.ListBox();
            this.txtMethod = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.pnlPositin.SuspendLayout();
            this.pnlTeam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPTeam)).BeginInit();
            this.pnlSite.SuspendLayout();
            this.pnlMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(15, 12);
            this.treeView1.Name = "treeView1";
            treeNode3.Name = "site";
            treeNode3.Text = "地点";
            treeNode4.Name = "settlementMethod";
            treeNode4.Text = "运输结算方式";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(108, 210);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(270, 236);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(329, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.pnlPositin);
            this.groupBox2.Controls.Add(this.pnlTeam);
            this.groupBox2.Controls.Add(this.pnlSite);
            this.groupBox2.Controls.Add(this.pnlMethod);
            this.groupBox2.Location = new System.Drawing.Point(6, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 229);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(127, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2, 227);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // pnlPositin
            // 
            this.pnlPositin.Controls.Add(this.lstPositin);
            this.pnlPositin.Controls.Add(this.label1);
            this.pnlPositin.Controls.Add(this.txtPositin);
            this.pnlPositin.Location = new System.Drawing.Point(130, 10);
            this.pnlPositin.Name = "pnlPositin";
            this.pnlPositin.Size = new System.Drawing.Size(255, 218);
            this.pnlPositin.TabIndex = 9;
            this.pnlPositin.Visible = false;
            this.pnlPositin.Leave += new System.EventHandler(this.pnlPositin_Leave);
            // 
            // lstPositin
            // 
            this.lstPositin.FormattingEnabled = true;
            this.lstPositin.ItemHeight = 12;
            this.lstPositin.Location = new System.Drawing.Point(90, 37);
            this.lstPositin.Name = "lstPositin";
            this.lstPositin.Size = new System.Drawing.Size(122, 172);
            this.lstPositin.TabIndex = 2;
            // 
            // txtPositin
            // 
            this.txtPositin.Location = new System.Drawing.Point(90, 10);
            this.txtPositin.Multiline = true;
            this.txtPositin.Name = "txtPositin";
            this.txtPositin.Size = new System.Drawing.Size(122, 21);
            this.txtPositin.TabIndex = 1;
            this.txtPositin.Tag = "S";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "职位名称";
            // 
            // pnlTeam
            // 
            this.pnlTeam.Controls.Add(this.dgvPTeam);
            this.pnlTeam.Controls.Add(this.cbxPiId);
            this.pnlTeam.Controls.Add(this.txtCount);
            this.pnlTeam.Controls.Add(this.txtDepartment);
            this.pnlTeam.Controls.Add(this.txtTeamName);
            this.pnlTeam.Controls.Add(this.label6);
            this.pnlTeam.Controls.Add(this.label5);
            this.pnlTeam.Controls.Add(this.label4);
            this.pnlTeam.Controls.Add(this.label3);
            this.pnlTeam.Location = new System.Drawing.Point(130, 10);
            this.pnlTeam.Name = "pnlTeam";
            this.pnlTeam.Size = new System.Drawing.Size(255, 218);
            this.pnlTeam.TabIndex = 3;
            this.pnlTeam.Visible = false;
            this.pnlTeam.Leave += new System.EventHandler(this.pnlTeam_Leave);
            // 
            // dgvPTeam
            // 
            this.dgvPTeam.BackgroundColor = System.Drawing.Color.White;
            this.dgvPTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPTeam.Location = new System.Drawing.Point(4, 104);
            this.dgvPTeam.Name = "dgvPTeam";
            this.dgvPTeam.RowTemplate.Height = 23;
            this.dgvPTeam.Size = new System.Drawing.Size(244, 109);
            this.dgvPTeam.TabIndex = 8;
            // 
            // cbxPiId
            // 
            this.cbxPiId.FormattingEnabled = true;
            this.cbxPiId.Location = new System.Drawing.Point(90, 56);
            this.cbxPiId.Name = "cbxPiId";
            this.cbxPiId.Size = new System.Drawing.Size(122, 20);
            this.cbxPiId.TabIndex = 7;
            this.cbxPiId.Tag = "S";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(90, 78);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(122, 21);
            this.txtCount.TabIndex = 6;
            this.txtCount.Tag = "I";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(90, 33);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(122, 21);
            this.txtDepartment.TabIndex = 5;
            this.txtDepartment.Tag = "S";
            // 
            // txtTeamName
            // 
            this.txtTeamName.Location = new System.Drawing.Point(90, 10);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(122, 21);
            this.txtTeamName.TabIndex = 4;
            this.txtTeamName.Tag = "S";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "总人数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "组长";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "生产部门";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "班组名称";
            // 
            // pnlSite
            // 
            this.pnlSite.Controls.Add(this.lstSite);
            this.pnlSite.Controls.Add(this.txtSite);
            this.pnlSite.Controls.Add(this.label2);
            this.pnlSite.Location = new System.Drawing.Point(130, 10);
            this.pnlSite.Name = "pnlSite";
            this.pnlSite.Size = new System.Drawing.Size(255, 218);
            this.pnlSite.TabIndex = 6;
            this.pnlSite.Visible = false;
            this.pnlSite.Leave += new System.EventHandler(this.pnlSite_Leave);
            // 
            // lstSite
            // 
            this.lstSite.FormattingEnabled = true;
            this.lstSite.ItemHeight = 12;
            this.lstSite.Location = new System.Drawing.Point(90, 37);
            this.lstSite.Name = "lstSite";
            this.lstSite.Size = new System.Drawing.Size(122, 172);
            this.lstSite.TabIndex = 2;
            // 
            // txtSite
            // 
            this.txtSite.Location = new System.Drawing.Point(90, 10);
            this.txtSite.Name = "txtSite";
            this.txtSite.Size = new System.Drawing.Size(122, 21);
            this.txtSite.TabIndex = 1;
            this.txtSite.Tag = "S";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "地点";
            // 
            // pnlMethod
            // 
            this.pnlMethod.BackColor = System.Drawing.Color.Transparent;
            this.pnlMethod.Controls.Add(this.lstMethod);
            this.pnlMethod.Controls.Add(this.txtMethod);
            this.pnlMethod.Controls.Add(this.label7);
            this.pnlMethod.Location = new System.Drawing.Point(130, 10);
            this.pnlMethod.Name = "pnlMethod";
            this.pnlMethod.Size = new System.Drawing.Size(250, 219);
            this.pnlMethod.TabIndex = 7;
            this.pnlMethod.Visible = false;
            this.pnlMethod.Leave += new System.EventHandler(this.pnlMethod_Leave);
            // 
            // lstMethod
            // 
            this.lstMethod.FormattingEnabled = true;
            this.lstMethod.ItemHeight = 12;
            this.lstMethod.Location = new System.Drawing.Point(90, 37);
            this.lstMethod.Name = "lstMethod";
            this.lstMethod.Size = new System.Drawing.Size(122, 172);
            this.lstMethod.TabIndex = 2;
            // 
            // txtMethod
            // 
            this.txtMethod.Location = new System.Drawing.Point(90, 10);
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.Size = new System.Drawing.Size(122, 21);
            this.txtMethod.TabIndex = 1;
            this.txtMethod.Tag = "S";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "结算方式";
            // 
            // FrmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "FrmOption";
            this.Tag = "FrmOption";
            this.Text = "选项";
            this.Load += new System.EventHandler(this.FrmOption_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOption_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.pnlPositin.ResumeLayout(false);
            this.pnlPositin.PerformLayout();
            this.pnlTeam.ResumeLayout(false);
            this.pnlTeam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPTeam)).EndInit();
            this.pnlSite.ResumeLayout(false);
            this.pnlSite.PerformLayout();
            this.pnlMethod.ResumeLayout(false);
            this.pnlMethod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlSite;
        private System.Windows.Forms.ListBox lstSite;
        private System.Windows.Forms.TextBox txtSite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlTeam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPTeam;
        private System.Windows.Forms.ComboBox cbxPiId;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Panel pnlMethod;
        private System.Windows.Forms.TextBox txtMethod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstMethod;
        private System.Windows.Forms.Panel pnlPositin;
        private System.Windows.Forms.ListBox lstPositin;
        private System.Windows.Forms.TextBox txtPositin;
        private System.Windows.Forms.Label label1;
    }
}