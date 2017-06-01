namespace DasherStation.system
{
    partial class FrmTruckInfo
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
            this.btnTUnit = new System.Windows.Forms.Button();
            this.cbxTUnit = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxCColor = new System.Windows.Forms.ComboBox();
            this.cbxCType = new System.Windows.Forms.ComboBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSDWeight = new System.Windows.Forms.TextBox();
            this.txtsTTare = new System.Windows.Forms.TextBox();
            this.txtTare = new System.Windows.Forms.TextBox();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxCondition = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvTruckInfo = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTruckInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnTUnit);
            this.groupBox1.Controls.Add(this.cbxTUnit);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbxCColor);
            this.groupBox1.Controls.Add(this.cbxCType);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSDWeight);
            this.groupBox1.Controls.Add(this.txtsTTare);
            this.groupBox1.Controls.Add(this.txtTare);
            this.groupBox1.Controls.Add(this.txtCName);
            this.groupBox1.Controls.Add(this.txtMName);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.txtLength);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 254);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnTUnit
            // 
            this.btnTUnit.Font = new System.Drawing.Font("宋体", 4F, System.Drawing.FontStyle.Bold);
            this.btnTUnit.Location = new System.Drawing.Point(162, 40);
            this.btnTUnit.Name = "btnTUnit";
            this.btnTUnit.Size = new System.Drawing.Size(25, 23);
            this.btnTUnit.TabIndex = 75;
            this.btnTUnit.Text = "...";
            this.btnTUnit.UseVisualStyleBackColor = true;
            this.btnTUnit.Click += new System.EventHandler(this.btnTUnit_Click);
            // 
            // cbxTUnit
            // 
            this.cbxTUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTUnit.FormattingEnabled = true;
            this.cbxTUnit.Location = new System.Drawing.Point(76, 42);
            this.cbxTUnit.Name = "cbxTUnit";
            this.cbxTUnit.Size = new System.Drawing.Size(87, 20);
            this.cbxTUnit.TabIndex = 2;
            this.cbxTUnit.Tag = "E";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(200, 226);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(50, 23);
            this.btnUpdate.TabIndex = 73;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(256, 226);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 23);
            this.btnSave.TabIndex = 72;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(312, 226);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 23);
            this.btnDelete.TabIndex = 71;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(206, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 12);
            this.label11.TabIndex = 54;
            this.label11.Text = "标准空载重量(t)";
            // 
            // cbxCColor
            // 
            this.cbxCColor.FormattingEnabled = true;
            this.cbxCColor.Location = new System.Drawing.Point(76, 145);
            this.cbxCColor.Name = "cbxCColor";
            this.cbxCColor.Size = new System.Drawing.Size(110, 20);
            this.cbxCColor.TabIndex = 10;
            this.cbxCColor.Tag = "S";
            // 
            // cbxCType
            // 
            this.cbxCType.FormattingEnabled = true;
            this.cbxCType.Location = new System.Drawing.Point(76, 119);
            this.cbxCType.Name = "cbxCType";
            this.cbxCType.Size = new System.Drawing.Size(110, 20);
            this.cbxCType.TabIndex = 8;
            this.cbxCType.Tag = "S";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(76, 171);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(287, 51);
            this.txtRemark.TabIndex = 12;
            this.txtRemark.Tag = "S";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(206, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 53;
            this.label10.Text = "车辆皮重(t)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "车辆颜色";
            // 
            // txtSDWeight
            // 
            this.txtSDWeight.Location = new System.Drawing.Point(307, 145);
            this.txtSDWeight.Name = "txtSDWeight";
            this.txtSDWeight.Size = new System.Drawing.Size(56, 21);
            this.txtSDWeight.TabIndex = 11;
            this.txtSDWeight.Tag = "F";
            // 
            // txtsTTare
            // 
            this.txtsTTare.Location = new System.Drawing.Point(307, 119);
            this.txtsTTare.Name = "txtsTTare";
            this.txtsTTare.Size = new System.Drawing.Size(56, 21);
            this.txtsTTare.TabIndex = 9;
            this.txtsTTare.Tag = "F";
            // 
            // txtTare
            // 
            this.txtTare.Location = new System.Drawing.Point(307, 93);
            this.txtTare.Name = "txtTare";
            this.txtTare.Size = new System.Drawing.Size(56, 21);
            this.txtTare.TabIndex = 7;
            this.txtTare.Tag = "F";
            // 
            // txtCName
            // 
            this.txtCName.Location = new System.Drawing.Point(76, 93);
            this.txtCName.Name = "txtCName";
            this.txtCName.Size = new System.Drawing.Size(110, 21);
            this.txtCName.TabIndex = 6;
            this.txtCName.Tag = "S";
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(76, 67);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(110, 21);
            this.txtMName.TabIndex = 4;
            this.txtMName.Tag = "S";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(307, 67);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(56, 21);
            this.txtHeight.TabIndex = 5;
            this.txtHeight.Tag = "F";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(307, 41);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(56, 21);
            this.txtWidth.TabIndex = 3;
            this.txtWidth.Tag = "F";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(307, 15);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(56, 21);
            this.txtLength.TabIndex = 1;
            this.txtLength.Tag = "F";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(76, 15);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(110, 21);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.Tag = "ES";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(206, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 12);
            this.label12.TabIndex = 55;
            this.label12.Text = "标准载重量(t)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(206, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 12);
            this.label9.TabIndex = 52;
            this.label9.Text = "车辆货箱高度(m)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(206, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 51;
            this.label8.Text = "车辆货箱宽度(m)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 56;
            this.label13.Text = "备注";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 12);
            this.label7.TabIndex = 50;
            this.label7.Text = "车辆货箱长度(m)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "车主姓名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 48;
            this.label5.Text = "车辆型号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 47;
            this.label4.Text = "司机姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 45;
            this.label2.Text = "运输单位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 44;
            this.label1.Text = "车牌号";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cbxCondition);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.dgvTruckInfo);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtCondition);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Location = new System.Drawing.Point(6, 254);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 205);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // cbxCondition
            // 
            this.cbxCondition.FormattingEnabled = true;
            this.cbxCondition.Items.AddRange(new object[] {
            "全部",
            "车牌号",
            "运输单位",
            "车主姓名",
            "司机姓名",
            "车辆型号",
            "车辆颜色"});
            this.cbxCondition.Location = new System.Drawing.Point(76, 15);
            this.cbxCondition.Name = "cbxCondition";
            this.cbxCondition.Size = new System.Drawing.Size(102, 20);
            this.cbxCondition.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(1, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 2);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // dgvTruckInfo
            // 
            this.dgvTruckInfo.AllowUserToAddRows = false;
            this.dgvTruckInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvTruckInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTruckInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTruckInfo.Location = new System.Drawing.Point(3, 47);
            this.dgvTruckInfo.Name = "dgvTruckInfo";
            this.dgvTruckInfo.ReadOnly = true;
            this.dgvTruckInfo.RowTemplate.Height = 23;
            this.dgvTruckInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTruckInfo.Size = new System.Drawing.Size(376, 155);
            this.dgvTruckInfo.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(313, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(204, 15);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(87, 21);
            this.txtCondition.TabIndex = 1;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(17, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 4;
            this.label22.Text = "查询条件";
            // 
            // FrmTruckInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(394, 464);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "FrmTruckInfo";
            this.Text = "车辆信息";
            this.Load += new System.EventHandler(this.FrmTruckInfo_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmTruckInfo_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTruckInfo_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTruckInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxCColor;
        private System.Windows.Forms.ComboBox cbxCType;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSDWeight;
        private System.Windows.Forms.TextBox txtsTTare;
        private System.Windows.Forms.TextBox txtTare;
        private System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvTruckInfo;
        protected System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnUpdate;
        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbxTUnit;
        private System.Windows.Forms.ComboBox cbxCondition;
        private System.Windows.Forms.Button btnTUnit;

        //private System.Windows.Forms.DataGridView dgvTruckInfo;
        //private System.Windows.Forms.Label label10;
        //private System.Windows.Forms.Label label9;
        //private System.Windows.Forms.Label label8;
        //private System.Windows.Forms.Label label11;
        //private System.Windows.Forms.Label label13;
        //private System.Windows.Forms.Label label12;
        //private System.Windows.Forms.Label label7;
        //private System.Windows.Forms.Label label6;
        //private System.Windows.Forms.Label label5;
        //private System.Windows.Forms.Label label4;
        //private System.Windows.Forms.Label label3;
        //private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.Label label2;
        //private System.Windows.Forms.TextBox txtLength;
        //private System.Windows.Forms.TextBox txtCName;
        //private System.Windows.Forms.TextBox txtMName;
        //private System.Windows.Forms.TextBox txtTUnit;
        //private System.Windows.Forms.TextBox txtNumber;
        //private System.Windows.Forms.TextBox txtRemark;
        //private System.Windows.Forms.ComboBox cbxCColor;
        //private System.Windows.Forms.ComboBox cbxCType;
        //private System.Windows.Forms.TextBox txtSDWeight;
        //private System.Windows.Forms.TextBox txtsTTare;
        //private System.Windows.Forms.TextBox txtTare;
        //private System.Windows.Forms.TextBox txtHeight;
        //private System.Windows.Forms.TextBox txtWidth;
        //private System.Windows.Forms.TextBox txtCondition;
        //private System.Windows.Forms.Label label14;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Ttare;
        //private System.Windows.Forms.Button btnUpdate;
        //private System.Windows.Forms.DataGridViewTextBoxColumn CNumber;
        //private System.Windows.Forms.DataGridViewTextBoxColumn id;
        //private System.Windows.Forms.DataGridViewTextBoxColumn CUnit;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Mname;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Cname;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Mtype;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Mcolor;
        //private System.Windows.Forms.DataGridViewTextBoxColumn MLength;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Mwidth;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Mheight;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Mtare;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Ctare;
        //private System.Windows.Forms.DataGridViewTextBoxColumn SDweight;
        //private System.Windows.Forms.Label label15;
        //private System.Windows.Forms.TextBox txtId;
    }
}