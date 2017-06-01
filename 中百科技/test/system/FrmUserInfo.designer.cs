namespace DasherStation.system
{
    partial class FrmUserInfo
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
            this.txtRePassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreat = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbxDuty = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labPassword = new System.Windows.Forms.Label();
            this.labDuty = new System.Windows.Forms.Label();
            this.labSex = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.labAge = new System.Windows.Forms.Label();
            this.labUserName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvUserInfo = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtRePassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnCreat);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.cbxDuty);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.labPassword);
            this.groupBox1.Controls.Add(this.labDuty);
            this.groupBox1.Controls.Add(this.labSex);
            this.groupBox1.Controls.Add(this.labName);
            this.groupBox1.Controls.Add(this.labAge);
            this.groupBox1.Controls.Add(this.labUserName);
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtRePassword
            // 
            this.txtRePassword.Location = new System.Drawing.Point(79, 81);
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '*';
            this.txtRePassword.Size = new System.Drawing.Size(110, 21);
            this.txtRePassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 68;
            this.label1.Text = "密码确认";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(212, 145);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 23);
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(312, 145);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 23);
            this.btnDelete.TabIndex = 66;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreat
            // 
            this.btnCreat.Location = new System.Drawing.Point(17, 145);
            this.btnCreat.Name = "btnCreat";
            this.btnCreat.Size = new System.Drawing.Size(50, 23);
            this.btnCreat.TabIndex = 65;
            this.btnCreat.Text = "新建";
            this.btnCreat.UseVisualStyleBackColor = true;
            this.btnCreat.Visible = false;
            this.btnCreat.Click += new System.EventHandler(this.btnCreat_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(77, 145);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(50, 23);
            this.btnUpdate.TabIndex = 47;
            this.btnUpdate.Tag = "1";
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbxDuty
            // 
            this.cbxDuty.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbxDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDuty.FormattingEnabled = true;
            this.cbxDuty.Location = new System.Drawing.Point(259, 80);
            this.cbxDuty.Name = "cbxDuty";
            this.cbxDuty.Size = new System.Drawing.Size(104, 20);
            this.cbxDuty.TabIndex = 4;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(327, 17);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(35, 16);
            this.radioButton2.TabIndex = 45;
            this.radioButton2.Text = "女";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(259, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(35, 16);
            this.radioButton1.TabIndex = 44;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "男";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(79, 16);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(110, 21);
            this.txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(79, 48);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(110, 21);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Tag = "1";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(259, 48);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(104, 21);
            this.txtAge.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(79, 115);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(110, 21);
            this.txtName.TabIndex = 5;
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Location = new System.Drawing.Point(17, 53);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(29, 12);
            this.labPassword.TabIndex = 39;
            this.labPassword.Text = "密码";
            // 
            // labDuty
            // 
            this.labDuty.AutoSize = true;
            this.labDuty.Location = new System.Drawing.Point(206, 84);
            this.labDuty.Name = "labDuty";
            this.labDuty.Size = new System.Drawing.Size(29, 12);
            this.labDuty.TabIndex = 38;
            this.labDuty.Text = "职位";
            // 
            // labSex
            // 
            this.labSex.AutoSize = true;
            this.labSex.Location = new System.Drawing.Point(206, 21);
            this.labSex.Name = "labSex";
            this.labSex.Size = new System.Drawing.Size(29, 12);
            this.labSex.TabIndex = 37;
            this.labSex.Text = "性别";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(17, 119);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(53, 12);
            this.labName.TabIndex = 36;
            this.labName.Text = "真实姓名";
            // 
            // labAge
            // 
            this.labAge.AutoSize = true;
            this.labAge.Location = new System.Drawing.Point(206, 53);
            this.labAge.Name = "labAge";
            this.labAge.Size = new System.Drawing.Size(29, 12);
            this.labAge.TabIndex = 35;
            this.labAge.Text = "年龄";
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Location = new System.Drawing.Point(17, 21);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(41, 12);
            this.labUserName.TabIndex = 34;
            this.labUserName.Text = "用户名";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvUserInfo);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtCondition);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Location = new System.Drawing.Point(6, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 202);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // dgvUserInfo
            // 
            this.dgvUserInfo.AllowUserToAddRows = false;
            this.dgvUserInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.userName,
            this.password,
            this.name,
            this.sex,
            this.age,
            this.duty});
            this.dgvUserInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvUserInfo.Location = new System.Drawing.Point(3, 44);
            this.dgvUserInfo.Name = "dgvUserInfo";
            this.dgvUserInfo.ReadOnly = true;
            this.dgvUserInfo.RowTemplate.Height = 23;
            this.dgvUserInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserInfo.Size = new System.Drawing.Size(376, 155);
            this.dgvUserInfo.TabIndex = 13;
            this.dgvUserInfo.Click += new System.EventHandler(this.dgvUserInfo_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // userName
            // 
            this.userName.DataPropertyName = "name";
            this.userName.HeaderText = "用户名";
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            // 
            // password
            // 
            this.password.DataPropertyName = "password";
            this.password.HeaderText = "密码";
            this.password.Name = "password";
            this.password.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "真实姓名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // sex
            // 
            this.sex.DataPropertyName = "sex";
            this.sex.HeaderText = "性别";
            this.sex.Name = "sex";
            this.sex.ReadOnly = true;
            // 
            // age
            // 
            this.age.DataPropertyName = "age";
            this.age.HeaderText = "年龄";
            this.age.Name = "age";
            this.age.ReadOnly = true;
            // 
            // duty
            // 
            this.duty.DataPropertyName = "positionname";
            this.duty.HeaderText = "职位";
            this.duty.Name = "duty";
            this.duty.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(0, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 2);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(313, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(79, 13);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(80, 21);
            this.txtCondition.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 9;
            this.label22.Text = "真实姓名";
            // 
            // FrmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(394, 372);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.KeyPreview = true;
            this.Name = "FrmUserInfo";
            this.Tag = "FrmUserInfo";
            this.Text = "用户信息";
            this.Load += new System.EventHandler(this.FrmUserInfo_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmUserInfo_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cbxDuty;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.Label labDuty;
        private System.Windows.Forms.Label labSex;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labAge;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Label label22;
        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.Button btnDelete;
        protected System.Windows.Forms.Button btnCreat;
        private System.Windows.Forms.DataGridViewTextBoxColumn userInfoName;
        private System.Windows.Forms.TextBox txtRePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvUserInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn age;
        private System.Windows.Forms.DataGridViewTextBoxColumn duty;

        //private System.Windows.Forms.ComboBox cbxDuty;
        //private System.Windows.Forms.RadioButton radioButton2;
        //private System.Windows.Forms.RadioButton radioButton1;
        //private System.Windows.Forms.TextBox txtUserName;
        //private System.Windows.Forms.TextBox txtPassword;
        //private System.Windows.Forms.TextBox txtAge;
        //private System.Windows.Forms.TextBox txtName;
        //private System.Windows.Forms.Label labPassword;
        //private System.Windows.Forms.Label labDuty;
        //private System.Windows.Forms.Label labSex;
        //private System.Windows.Forms.Label labName;
        //private System.Windows.Forms.Label labAge;
        //private System.Windows.Forms.Label labUserName;
        //private System.Windows.Forms.TextBox txtQusername;
        //private System.Windows.Forms.Label labQusername;
        //private System.Windows.Forms.DataGridView dgvUserInfo;
        //private System.Windows.Forms.Button btnUpdate;
        //private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        //private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        //private System.Windows.Forms.DataGridViewTextBoxColumn password;
        //private System.Windows.Forms.DataGridViewTextBoxColumn name;
        //private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        //private System.Windows.Forms.DataGridViewTextBoxColumn age;
        //private System.Windows.Forms.DataGridViewTextBoxColumn pId;


    }
}