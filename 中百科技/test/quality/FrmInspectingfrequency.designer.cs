namespace DasherStation.quality
{
    partial class FrmInspectingfrequency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInspectingfrequency));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.rbttype2 = new System.Windows.Forms.RadioButton();
            this.rbttype1 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxModel = new System.Windows.Forms.ComboBox();
            this.cbxKinds = new System.Windows.Forms.ComboBox();
            this.cbxName = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.cbxGuideline = new System.Windows.Forms.ComboBox();
            this.cbxFrequency = new System.Windows.Forms.ComboBox();
            this.cbxTestGuideline = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxCondition = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testGuideline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guideline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.rbttype2);
            this.groupBox1.Controls.Add(this.rbttype1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbxModel);
            this.groupBox1.Controls.Add(this.cbxKinds);
            this.groupBox1.Controls.Add(this.cbxName);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.cbxGuideline);
            this.groupBox1.Controls.Add(this.cbxFrequency);
            this.groupBox1.Controls.Add(this.cbxTestGuideline);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(294, 168);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(50, 23);
            this.btnUpdate.TabIndex = 45;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // rbttype2
            // 
            this.rbttype2.AutoSize = true;
            this.rbttype2.Location = new System.Drawing.Point(164, 16);
            this.rbttype2.Name = "rbttype2";
            this.rbttype2.Size = new System.Drawing.Size(47, 16);
            this.rbttype2.TabIndex = 44;
            this.rbttype2.Tag = "2";
            this.rbttype2.Text = "产品";
            this.rbttype2.UseVisualStyleBackColor = true;
            this.rbttype2.Click += new System.EventHandler(this.rbttype2_Click);
            // 
            // rbttype1
            // 
            this.rbttype1.AutoSize = true;
            this.rbttype1.Checked = true;
            this.rbttype1.Location = new System.Drawing.Point(100, 16);
            this.rbttype1.Name = "rbttype1";
            this.rbttype1.Size = new System.Drawing.Size(47, 16);
            this.rbttype1.TabIndex = 43;
            this.rbttype1.TabStop = true;
            this.rbttype1.Tag = "1";
            this.rbttype1.Text = "原料";
            this.rbttype1.UseVisualStyleBackColor = true;
            this.rbttype1.Click += new System.EventHandler(this.rbttype1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 42;
            this.label8.Text = "检测类型";
            // 
            // cbxModel
            // 
            this.cbxModel.FormattingEnabled = true;
            this.cbxModel.Location = new System.Drawing.Point(78, 107);
            this.cbxModel.Name = "cbxModel";
            this.cbxModel.Size = new System.Drawing.Size(129, 20);
            this.cbxModel.TabIndex = 3;
            // 
            // cbxKinds
            // 
            this.cbxKinds.FormattingEnabled = true;
            this.cbxKinds.Location = new System.Drawing.Point(78, 46);
            this.cbxKinds.Name = "cbxKinds";
            this.cbxKinds.Size = new System.Drawing.Size(129, 20);
            this.cbxKinds.TabIndex = 1;
            this.cbxKinds.SelectionChangeCommitted += new System.EventHandler(this.cbxKinds_SelectionChangeCommitted);
            // 
            // cbxName
            // 
            this.cbxName.FormattingEnabled = true;
            this.cbxName.Location = new System.Drawing.Point(78, 76);
            this.cbxName.Name = "cbxName";
            this.cbxName.Size = new System.Drawing.Size(129, 20);
            this.cbxName.TabIndex = 2;
            this.cbxName.SelectionChangeCommitted += new System.EventHandler(this.cbxName_SelectionChangeCommitted);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(376, 168);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 23);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(206, 168);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(50, 23);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(78, 138);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(349, 21);
            this.txtRemark.TabIndex = 7;
            // 
            // cbxGuideline
            // 
            this.cbxGuideline.FormattingEnabled = true;
            this.cbxGuideline.Location = new System.Drawing.Point(306, 107);
            this.cbxGuideline.Name = "cbxGuideline";
            this.cbxGuideline.Size = new System.Drawing.Size(121, 20);
            this.cbxGuideline.TabIndex = 6;
            // 
            // cbxFrequency
            // 
            this.cbxFrequency.FormattingEnabled = true;
            this.cbxFrequency.Location = new System.Drawing.Point(306, 76);
            this.cbxFrequency.Name = "cbxFrequency";
            this.cbxFrequency.Size = new System.Drawing.Size(121, 20);
            this.cbxFrequency.TabIndex = 5;
            // 
            // cbxTestGuideline
            // 
            this.cbxTestGuideline.FormattingEnabled = true;
            this.cbxTestGuideline.Location = new System.Drawing.Point(306, 46);
            this.cbxTestGuideline.Name = "cbxTestGuideline";
            this.cbxTestGuideline.Size = new System.Drawing.Size(121, 20);
            this.cbxTestGuideline.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "备注";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "合格标准";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "检测频率";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "检测指标";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "规格型号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "种类";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cbxCondition);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtCondition);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Location = new System.Drawing.Point(4, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // cbxCondition
            // 
            this.cbxCondition.FormattingEnabled = true;
            this.cbxCondition.Items.AddRange(new object[] {
            "种类",
            "名称",
            "规格型号"});
            this.cbxCondition.Location = new System.Drawing.Point(68, 18);
            this.cbxCondition.Name = "cbxCondition";
            this.cbxCondition.Size = new System.Drawing.Size(110, 20);
            this.cbxCondition.TabIndex = 25;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(376, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 23);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(196, 18);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(107, 21);
            this.txtCondition.TabIndex = 26;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 24;
            this.label22.Text = "查询条件";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.dgvDetail);
            this.groupBox3.Location = new System.Drawing.Point(4, 241);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(444, 202);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.sort,
            this.name,
            this.model,
            this.testGuideline,
            this.frequency,
            this.guideline,
            this.inputDate,
            this.inputMan,
            this.remark,
            this.mId});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(438, 182);
            this.dgvDetail.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "种类";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "规格型号";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            // 
            // testGuideline
            // 
            this.testGuideline.DataPropertyName = "testGuideline";
            this.testGuideline.HeaderText = "检测指标";
            this.testGuideline.Name = "testGuideline";
            this.testGuideline.ReadOnly = true;
            // 
            // frequency
            // 
            this.frequency.DataPropertyName = "frequency";
            this.frequency.HeaderText = "检测频率";
            this.frequency.Name = "frequency";
            this.frequency.ReadOnly = true;
            // 
            // guideline
            // 
            this.guideline.DataPropertyName = "eligibilityGuideline";
            this.guideline.HeaderText = "合格标准";
            this.guideline.Name = "guideline";
            this.guideline.ReadOnly = true;
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.HeaderText = "录入时间";
            this.inputDate.Name = "inputDate";
            this.inputDate.ReadOnly = true;
            // 
            // inputMan
            // 
            this.inputMan.DataPropertyName = "inputMan";
            this.inputMan.HeaderText = "录入人";
            this.inputMan.Name = "inputMan";
            this.inputMan.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "备注";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // mId
            // 
            this.mId.DataPropertyName = "mId";
            this.mId.HeaderText = "mId";
            this.mId.Name = "mId";
            this.mId.ReadOnly = true;
            this.mId.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(380, 451);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmInspectingfrequency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 486);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInspectingfrequency";
            this.Tag = "FrmInspectingfrequency";
            this.Text = "检验项目管理";
            this.Load += new System.EventHandler(this.frmInspectingfrequency_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInspectingfrequency_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.ComboBox cbxGuideline;
        private System.Windows.Forms.ComboBox cbxFrequency;
        private System.Windows.Forms.ComboBox cbxTestGuideline;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCondition;
        protected System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.ComboBox cbxModel;
        private System.Windows.Forms.ComboBox cbxKinds;
        private System.Windows.Forms.ComboBox cbxName;
        private System.Windows.Forms.RadioButton rbttype2;
        private System.Windows.Forms.RadioButton rbttype1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn testGuideline;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn guideline;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn mId;
    }
}