namespace DasherStation.system
{
    partial class FrmProductInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductInfo));
            this.dgvProductInfo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDensity = new System.Windows.Forms.TextBox();
            this.cbxPKind = new System.Windows.Forms.ComboBox();
            this.cbxPName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxUnit1 = new System.Windows.Forms.ComboBox();
            this.cbxUnit2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTerm = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtSModel = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPlanPrice = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNStock = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPdensity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxModel = new System.Windows.Forms.ComboBox();
            this.btnPModel = new System.Windows.Forms.Button();
            this.cbxName = new System.Windows.Forms.ComboBox();
            this.cbxKind = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtPremark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnPKind = new System.Windows.Forms.Button();
            this.btnPName = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxCondition = new System.Windows.Forms.ComboBox();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductInfo
            // 
            this.dgvProductInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductInfo.Location = new System.Drawing.Point(2, 2);
            this.dgvProductInfo.Name = "dgvProductInfo";
            this.dgvProductInfo.RowTemplate.Height = 23;
            this.dgvProductInfo.Size = new System.Drawing.Size(354, 148);
            this.dgvProductInfo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "产品名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "产品种类";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "规格型号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "密度(t/m³)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "备注";
            // 
            // txtDensity
            // 
            this.txtDensity.Location = new System.Drawing.Point(270, 62);
            this.txtDensity.Name = "txtDensity";
            this.txtDensity.Size = new System.Drawing.Size(68, 21);
            this.txtDensity.TabIndex = 25;
            // 
            // cbxPKind
            // 
            this.cbxPKind.FormattingEnabled = true;
            this.cbxPKind.Location = new System.Drawing.Point(79, 12);
            this.cbxPKind.Name = "cbxPKind";
            this.cbxPKind.Size = new System.Drawing.Size(96, 20);
            this.cbxPKind.TabIndex = 31;
            // 
            // cbxPName
            // 
            this.cbxPName.FormattingEnabled = true;
            this.cbxPName.Location = new System.Drawing.Point(79, 37);
            this.cbxPName.Name = "cbxPName";
            this.cbxPName.Size = new System.Drawing.Size(96, 20);
            this.cbxPName.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(202, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 33;
            this.label9.Text = "计量单位1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(202, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 34;
            this.label10.Text = "计量单位2";
            // 
            // cbxUnit1
            // 
            this.cbxUnit1.FormattingEnabled = true;
            this.cbxUnit1.Location = new System.Drawing.Point(270, 12);
            this.cbxUnit1.Name = "cbxUnit1";
            this.cbxUnit1.Size = new System.Drawing.Size(68, 20);
            this.cbxUnit1.TabIndex = 35;
            // 
            // cbxUnit2
            // 
            this.cbxUnit2.FormattingEnabled = true;
            this.cbxUnit2.Location = new System.Drawing.Point(270, 37);
            this.cbxUnit2.Name = "cbxUnit2";
            this.cbxUnit2.Size = new System.Drawing.Size(68, 20);
            this.cbxUnit2.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "查询条件";
            // 
            // txtTerm
            // 
            this.txtTerm.Location = new System.Drawing.Point(79, 5);
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(91, 21);
            this.txtTerm.TabIndex = 3;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(79, 89);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(260, 51);
            this.txtRemark.TabIndex = 37;
            // 
            // txtSModel
            // 
            this.txtSModel.Location = new System.Drawing.Point(79, 62);
            this.txtSModel.Name = "txtSModel";
            this.txtSModel.Size = new System.Drawing.Size(96, 21);
            this.txtSModel.TabIndex = 38;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtPlanPrice);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtNStock);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtPdensity);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbxModel);
            this.groupBox1.Controls.Add(this.btnPModel);
            this.groupBox1.Controls.Add(this.cbxName);
            this.groupBox1.Controls.Add(this.cbxKind);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.txtPremark);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.btnPKind);
            this.groupBox1.Controls.Add(this.btnPName);
            this.groupBox1.Location = new System.Drawing.Point(5, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(76, 152);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(118, 21);
            this.txtRate.TabIndex = 7;
            this.txtRate.Tag = "";
            this.txtRate.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 158);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 75;
            this.label16.Text = "损耗率";
            this.label16.Visible = false;
            // 
            // txtPlanPrice
            // 
            this.txtPlanPrice.Location = new System.Drawing.Point(276, 67);
            this.txtPlanPrice.Name = "txtPlanPrice";
            this.txtPlanPrice.Size = new System.Drawing.Size(87, 21);
            this.txtPlanPrice.TabIndex = 5;
            this.txtPlanPrice.Tag = "F";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(205, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 26;
            this.label14.Text = "计划价格";
            // 
            // txtNStock
            // 
            this.txtNStock.Location = new System.Drawing.Point(275, 42);
            this.txtNStock.Name = "txtNStock";
            this.txtNStock.Size = new System.Drawing.Size(88, 21);
            this.txtNStock.TabIndex = 3;
            this.txtNStock.Tag = "F";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(204, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "最低库存(t)";
            // 
            // txtPdensity
            // 
            this.txtPdensity.Location = new System.Drawing.Point(275, 17);
            this.txtPdensity.Name = "txtPdensity";
            this.txtPdensity.Size = new System.Drawing.Size(88, 21);
            this.txtPdensity.TabIndex = 1;
            this.txtPdensity.Tag = "F";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "密度(t/m³)";
            // 
            // cbxModel
            // 
            this.cbxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxModel.FormattingEnabled = true;
            this.cbxModel.Location = new System.Drawing.Point(76, 67);
            this.cbxModel.Name = "cbxModel";
            this.cbxModel.Size = new System.Drawing.Size(95, 20);
            this.cbxModel.TabIndex = 4;
            this.cbxModel.Tag = "E";
            // 
            // btnPModel
            // 
            this.btnPModel.Font = new System.Drawing.Font("宋体", 4F, System.Drawing.FontStyle.Bold);
            this.btnPModel.Location = new System.Drawing.Point(170, 66);
            this.btnPModel.Name = "btnPModel";
            this.btnPModel.Size = new System.Drawing.Size(26, 23);
            this.btnPModel.TabIndex = 16;
            this.btnPModel.Text = "...";
            this.btnPModel.UseVisualStyleBackColor = true;
            this.btnPModel.Click += new System.EventHandler(this.btnPModel_Click);
            // 
            // cbxName
            // 
            this.cbxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxName.FormattingEnabled = true;
            this.cbxName.Location = new System.Drawing.Point(76, 42);
            this.cbxName.Name = "cbxName";
            this.cbxName.Size = new System.Drawing.Size(95, 20);
            this.cbxName.TabIndex = 2;
            this.cbxName.Tag = "E";
            // 
            // cbxKind
            // 
            this.cbxKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKind.FormattingEnabled = true;
            this.cbxKind.Location = new System.Drawing.Point(76, 17);
            this.cbxKind.Name = "cbxKind";
            this.cbxKind.Size = new System.Drawing.Size(95, 20);
            this.cbxKind.TabIndex = 0;
            this.cbxKind.Tag = "E";
            this.cbxKind.SelectionChangeCommitted += new System.EventHandler(this.cbxKind_SelectionChangeCommitted);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(201, 152);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(50, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(257, 152);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(313, 152);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtPremark
            // 
            this.txtPremark.Location = new System.Drawing.Point(76, 95);
            this.txtPremark.Multiline = true;
            this.txtPremark.Name = "txtPremark";
            this.txtPremark.Size = new System.Drawing.Size(287, 51);
            this.txtPremark.TabIndex = 6;
            this.txtPremark.Tag = "S";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "产品名称";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "产品规格";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "备注";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 3;
            this.label15.Text = "产品种类";
            // 
            // btnPKind
            // 
            this.btnPKind.Font = new System.Drawing.Font("宋体", 4F, System.Drawing.FontStyle.Bold);
            this.btnPKind.Location = new System.Drawing.Point(170, 16);
            this.btnPKind.Name = "btnPKind";
            this.btnPKind.Size = new System.Drawing.Size(26, 23);
            this.btnPKind.TabIndex = 12;
            this.btnPKind.Text = "...";
            this.btnPKind.UseVisualStyleBackColor = true;
            this.btnPKind.Click += new System.EventHandler(this.btnPKind_Click);
            // 
            // btnPName
            // 
            this.btnPName.Font = new System.Drawing.Font("宋体", 4F, System.Drawing.FontStyle.Bold);
            this.btnPName.Location = new System.Drawing.Point(170, 40);
            this.btnPName.Name = "btnPName";
            this.btnPName.Size = new System.Drawing.Size(26, 23);
            this.btnPName.TabIndex = 14;
            this.btnPName.Text = "...";
            this.btnPName.UseVisualStyleBackColor = true;
            this.btnPName.Click += new System.EventHandler(this.btnPName_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cbxCondition);
            this.groupBox2.Controls.Add(this.dgvProduct);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtCondition);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Location = new System.Drawing.Point(5, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 219);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // cbxCondition
            // 
            this.cbxCondition.FormattingEnabled = true;
            this.cbxCondition.Items.AddRange(new object[] {
            "产品种类",
            "产品名称",
            "规格型号"});
            this.cbxCondition.Location = new System.Drawing.Point(77, 15);
            this.cbxCondition.Name = "cbxCondition";
            this.cbxCondition.Size = new System.Drawing.Size(110, 20);
            this.cbxCondition.TabIndex = 0;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvProduct.Location = new System.Drawing.Point(3, 44);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.RowTemplate.Height = 23;
            this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduct.Size = new System.Drawing.Size(376, 172);
            this.dgvProduct.TabIndex = 24;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(0, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 2);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(313, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(203, 15);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(83, 21);
            this.txtCondition.TabIndex = 1;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(17, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 10;
            this.label22.Text = "查询条件";
            // 
            // FrmProductInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 405);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmProductInfo";
            this.Text = "产品信息";
            this.Load += new System.EventHandler(this.FrmProductInfo_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmProductInfo_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProductInfo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDensity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxPKind;
        private System.Windows.Forms.ComboBox cbxPName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxUnit2;
        private System.Windows.Forms.ComboBox cbxUnit1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTerm;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtSModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPremark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxKind;
        private System.Windows.Forms.ComboBox cbxName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cbxCondition;
        private System.Windows.Forms.Button btnPKind;
        private System.Windows.Forms.Button btnPName;
        private System.Windows.Forms.ComboBox cbxModel;
        private System.Windows.Forms.Button btnPModel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPdensity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNStock;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPlanPrice;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label16;
    }
}