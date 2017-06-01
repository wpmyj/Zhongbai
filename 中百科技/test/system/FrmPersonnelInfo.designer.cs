namespace DasherStation.system
{
    partial class FrmPersonnelInfo
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
            this.btnTeam = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnEmployee = new System.Windows.Forms.RadioButton();
            this.rbtnTemporary = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnWoman = new System.Windows.Forms.RadioButton();
            this.rbtnMan = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreat = new System.Windows.Forms.Button();
            this.cbxTeam = new System.Windows.Forms.ComboBox();
            this.cbxPosition = new System.Windows.Forms.ComboBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxCondition = new System.Windows.Forms.ComboBox();
            this.dgvProductInfo = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnTeam);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnCreat);
            this.groupBox1.Controls.Add(this.cbxTeam);
            this.groupBox1.Controls.Add(this.cbxPosition);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnTeam
            // 
            this.btnTeam.Font = new System.Drawing.Font("宋体", 4F, System.Drawing.FontStyle.Bold);
            this.btnTeam.Location = new System.Drawing.Point(338, 80);
            this.btnTeam.Name = "btnTeam";
            this.btnTeam.Size = new System.Drawing.Size(26, 23);
            this.btnTeam.TabIndex = 63;
            this.btnTeam.Text = "...";
            this.btnTeam.UseVisualStyleBackColor = true;
            this.btnTeam.Click += new System.EventHandler(this.btnTeam_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnEmployee);
            this.panel2.Controls.Add(this.rbtnTemporary);
            this.panel2.Location = new System.Drawing.Point(72, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(121, 26);
            this.panel2.TabIndex = 41;
            // 
            // rbtnEmployee
            // 
            this.rbtnEmployee.AutoSize = true;
            this.rbtnEmployee.Location = new System.Drawing.Point(1, 3);
            this.rbtnEmployee.Name = "rbtnEmployee";
            this.rbtnEmployee.Size = new System.Drawing.Size(47, 16);
            this.rbtnEmployee.TabIndex = 13;
            this.rbtnEmployee.TabStop = true;
            this.rbtnEmployee.Text = "正式";
            this.rbtnEmployee.UseVisualStyleBackColor = true;
            // 
            // rbtnTemporary
            // 
            this.rbtnTemporary.AutoSize = true;
            this.rbtnTemporary.Location = new System.Drawing.Point(59, 4);
            this.rbtnTemporary.Name = "rbtnTemporary";
            this.rbtnTemporary.Size = new System.Drawing.Size(59, 16);
            this.rbtnTemporary.TabIndex = 14;
            this.rbtnTemporary.TabStop = true;
            this.rbtnTemporary.Text = "临时工";
            this.rbtnTemporary.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnWoman);
            this.panel1.Controls.Add(this.rbtnMan);
            this.panel1.Location = new System.Drawing.Point(60, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 28);
            this.panel1.TabIndex = 40;
            // 
            // rbtnWoman
            // 
            this.rbtnWoman.AutoSize = true;
            this.rbtnWoman.Location = new System.Drawing.Point(71, 10);
            this.rbtnWoman.Name = "rbtnWoman";
            this.rbtnWoman.Size = new System.Drawing.Size(35, 16);
            this.rbtnWoman.TabIndex = 12;
            this.rbtnWoman.TabStop = true;
            this.rbtnWoman.Text = "女";
            this.rbtnWoman.UseVisualStyleBackColor = true;
            // 
            // rbtnMan
            // 
            this.rbtnMan.AutoSize = true;
            this.rbtnMan.Location = new System.Drawing.Point(15, 10);
            this.rbtnMan.Name = "rbtnMan";
            this.rbtnMan.Size = new System.Drawing.Size(35, 16);
            this.rbtnMan.TabIndex = 11;
            this.rbtnMan.TabStop = true;
            this.rbtnMan.Text = "男";
            this.rbtnMan.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 62;
            this.label6.Text = "职工类别";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(60, 165);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(50, 23);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(257, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(313, 165);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 23);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreat
            // 
            this.btnCreat.Location = new System.Drawing.Point(8, 165);
            this.btnCreat.Name = "btnCreat";
            this.btnCreat.Size = new System.Drawing.Size(50, 23);
            this.btnCreat.TabIndex = 16;
            this.btnCreat.Text = "新建";
            this.btnCreat.UseVisualStyleBackColor = true;
            this.btnCreat.Visible = false;
            // 
            // cbxTeam
            // 
            this.cbxTeam.FormattingEnabled = true;
            this.cbxTeam.Location = new System.Drawing.Point(253, 81);
            this.cbxTeam.Name = "cbxTeam";
            this.cbxTeam.Size = new System.Drawing.Size(85, 20);
            this.cbxTeam.TabIndex = 3;
            // 
            // cbxPosition
            // 
            this.cbxPosition.FormattingEnabled = true;
            this.cbxPosition.Location = new System.Drawing.Point(253, 51);
            this.cbxPosition.Name = "cbxPosition";
            this.cbxPosition.Size = new System.Drawing.Size(110, 20);
            this.cbxPosition.TabIndex = 2;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(252, 20);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(110, 21);
            this.txtAge.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(68, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(110, 21);
            this.txtName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "生产班组";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "职位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "年龄";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "性别";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "姓名";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(60, 108);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(303, 51);
            this.txtRemark.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "备注";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cbxCondition);
            this.groupBox2.Controls.Add(this.dgvProductInfo);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtCondition);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Location = new System.Drawing.Point(6, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 204);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // cbxCondition
            // 
            this.cbxCondition.FormattingEnabled = true;
            this.cbxCondition.Items.AddRange(new object[] {
            "姓名",
            "性别",
            "职工类别"});
            this.cbxCondition.Location = new System.Drawing.Point(77, 15);
            this.cbxCondition.Name = "cbxCondition";
            this.cbxCondition.Size = new System.Drawing.Size(110, 20);
            this.cbxCondition.TabIndex = 0;
            // 
            // dgvProductInfo
            // 
            this.dgvProductInfo.AllowUserToAddRows = false;
            this.dgvProductInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProductInfo.Location = new System.Drawing.Point(3, 46);
            this.dgvProductInfo.Name = "dgvProductInfo";
            this.dgvProductInfo.RowTemplate.Height = 23;
            this.dgvProductInfo.Size = new System.Drawing.Size(376, 155);
            this.dgvProductInfo.TabIndex = 24;
            this.dgvProductInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductInfo_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(0, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 2);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(312, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(203, 14);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(83, 21);
            this.txtCondition.TabIndex = 1;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(17, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 9;
            this.label22.Text = "查询条件";
            // 
            // FrmPersonnelInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 397);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.KeyPreview = true;
            this.Name = "FrmPersonnelInfo";
            this.Tag = "FrmPersonnelInfo";
            this.Text = "人员信息";
            this.Load += new System.EventHandler(this.FrmPersonnelInfo_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmPersonnelInfo_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPersonnelInfo_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvProductInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxTeam;
        private System.Windows.Forms.ComboBox cbxPosition;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.RadioButton rbtnWoman;
        private System.Windows.Forms.RadioButton rbtnMan;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnUpdate;
        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.Button btnDelete;
        protected System.Windows.Forms.Button btnCreat;
        private System.Windows.Forms.ComboBox cbxCondition;
        private System.Windows.Forms.RadioButton rbtnTemporary;
        private System.Windows.Forms.RadioButton rbtnEmployee;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTeam;

    }
}