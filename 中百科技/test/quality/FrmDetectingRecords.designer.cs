namespace DasherStation.quality
{
    partial class FrmDetectingRecords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetectingRecords));
            this.dgvLabTestInfo = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMaterial = new System.Windows.Forms.TabPage();
            this.btn_PrintM = new System.Windows.Forms.Button();
            this.tbMAccountDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbMTotalQuantity = new System.Windows.Forms.TextBox();
            this.tbMDayQuantity = new System.Windows.Forms.TextBox();
            this.cbxMaterialModel = new System.Windows.Forms.ComboBox();
            this.cbxMaterialName = new System.Windows.Forms.ComboBox();
            this.cbxMaterialKind = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMaterialTest = new System.Windows.Forms.DataGridView();
            this.tpProduct = new System.Windows.Forms.TabPage();
            this.btn_PrintP = new System.Windows.Forms.Button();
            this.tbPAccountDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tbPTotalQuantity = new System.Windows.Forms.TextBox();
            this.tbPDayQuantity = new System.Windows.Forms.TextBox();
            this.cbxProductModel = new System.Windows.Forms.ComboBox();
            this.cbxProductName = new System.Windows.Forms.ComboBox();
            this.cbxProductKind = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvProductTest = new System.Windows.Forms.DataGridView();
            this.btnMoveIn = new System.Windows.Forms.Button();
            this.btnMoveOut = new System.Windows.Forms.Button();
            this.dgvMaterialTestAccount = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dgvProductTestAccount = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabTestInfo)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialTest)).BeginInit();
            this.tpProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialTestAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductTestAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLabTestInfo
            // 
            this.dgvLabTestInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvLabTestInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabTestInfo.Location = new System.Drawing.Point(12, 62);
            this.dgvLabTestInfo.Name = "dgvLabTestInfo";
            this.dgvLabTestInfo.ReadOnly = true;
            this.dgvLabTestInfo.RowTemplate.Height = 23;
            this.dgvLabTestInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLabTestInfo.Size = new System.Drawing.Size(326, 338);
            this.dgvLabTestInfo.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMaterial);
            this.tabControl1.Controls.Add(this.tpProduct);
            this.tabControl1.Location = new System.Drawing.Point(417, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(613, 381);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tpMaterial
            // 
            this.tpMaterial.Controls.Add(this.btn_PrintM);
            this.tpMaterial.Controls.Add(this.tbMAccountDate);
            this.tpMaterial.Controls.Add(this.label7);
            this.tpMaterial.Controls.Add(this.btnSave);
            this.tpMaterial.Controls.Add(this.tbMTotalQuantity);
            this.tpMaterial.Controls.Add(this.tbMDayQuantity);
            this.tpMaterial.Controls.Add(this.cbxMaterialModel);
            this.tpMaterial.Controls.Add(this.cbxMaterialName);
            this.tpMaterial.Controls.Add(this.cbxMaterialKind);
            this.tpMaterial.Controls.Add(this.label5);
            this.tpMaterial.Controls.Add(this.label4);
            this.tpMaterial.Controls.Add(this.label3);
            this.tpMaterial.Controls.Add(this.label2);
            this.tpMaterial.Controls.Add(this.label1);
            this.tpMaterial.Controls.Add(this.dgvMaterialTest);
            this.tpMaterial.Location = new System.Drawing.Point(4, 21);
            this.tpMaterial.Name = "tpMaterial";
            this.tpMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.tpMaterial.Size = new System.Drawing.Size(605, 356);
            this.tpMaterial.TabIndex = 0;
            this.tpMaterial.Text = "材料";
            this.tpMaterial.UseVisualStyleBackColor = true;
            // 
            // btn_PrintM
            // 
            this.btn_PrintM.Location = new System.Drawing.Point(377, 319);
            this.btn_PrintM.Name = "btn_PrintM";
            this.btn_PrintM.Size = new System.Drawing.Size(75, 23);
            this.btn_PrintM.TabIndex = 16;
            this.btn_PrintM.Text = "打印";
            this.btn_PrintM.UseVisualStyleBackColor = true;
            this.btn_PrintM.Click += new System.EventHandler(this.btn_PrintM_Click);
            // 
            // tbMAccountDate
            // 
            this.tbMAccountDate.Location = new System.Drawing.Point(468, 54);
            this.tbMAccountDate.Name = "tbMAccountDate";
            this.tbMAccountDate.ReadOnly = true;
            this.tbMAccountDate.Size = new System.Drawing.Size(121, 21);
            this.tbMAccountDate.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(409, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "台帐时间";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(514, 319);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbMTotalQuantity
            // 
            this.tbMTotalQuantity.Location = new System.Drawing.Point(274, 54);
            this.tbMTotalQuantity.Name = "tbMTotalQuantity";
            this.tbMTotalQuantity.ReadOnly = true;
            this.tbMTotalQuantity.Size = new System.Drawing.Size(100, 21);
            this.tbMTotalQuantity.TabIndex = 11;
            // 
            // tbMDayQuantity
            // 
            this.tbMDayQuantity.Location = new System.Drawing.Point(85, 54);
            this.tbMDayQuantity.Name = "tbMDayQuantity";
            this.tbMDayQuantity.ReadOnly = true;
            this.tbMDayQuantity.Size = new System.Drawing.Size(100, 21);
            this.tbMDayQuantity.TabIndex = 10;
            // 
            // cbxMaterialModel
            // 
            this.cbxMaterialModel.FormattingEnabled = true;
            this.cbxMaterialModel.Location = new System.Drawing.Point(468, 18);
            this.cbxMaterialModel.Name = "cbxMaterialModel";
            this.cbxMaterialModel.Size = new System.Drawing.Size(121, 20);
            this.cbxMaterialModel.TabIndex = 9;
            this.cbxMaterialModel.SelectionChangeCommitted += new System.EventHandler(this.cbxMaterialModel_SelectionChangeCommitted);
            // 
            // cbxMaterialName
            // 
            this.cbxMaterialName.FormattingEnabled = true;
            this.cbxMaterialName.Location = new System.Drawing.Point(274, 18);
            this.cbxMaterialName.Name = "cbxMaterialName";
            this.cbxMaterialName.Size = new System.Drawing.Size(121, 20);
            this.cbxMaterialName.TabIndex = 8;
            this.cbxMaterialName.SelectionChangeCommitted += new System.EventHandler(this.cbxMaterialName_SelectionChangeCommitted);
            // 
            // cbxMaterialKind
            // 
            this.cbxMaterialKind.FormattingEnabled = true;
            this.cbxMaterialKind.Location = new System.Drawing.Point(85, 18);
            this.cbxMaterialKind.Name = "cbxMaterialKind";
            this.cbxMaterialKind.Size = new System.Drawing.Size(121, 20);
            this.cbxMaterialKind.TabIndex = 7;
            this.cbxMaterialKind.SelectionChangeCommitted += new System.EventHandler(this.cbxMaterialKind_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "累计进厂量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "当日进场量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "材料规格";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "材料名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "材料种类";
            // 
            // dgvMaterialTest
            // 
            this.dgvMaterialTest.BackgroundColor = System.Drawing.Color.White;
            this.dgvMaterialTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterialTest.Location = new System.Drawing.Point(18, 90);
            this.dgvMaterialTest.Name = "dgvMaterialTest";
            this.dgvMaterialTest.RowTemplate.Height = 23;
            this.dgvMaterialTest.Size = new System.Drawing.Size(571, 214);
            this.dgvMaterialTest.TabIndex = 12;
            // 
            // tpProduct
            // 
            this.tpProduct.Controls.Add(this.btn_PrintP);
            this.tpProduct.Controls.Add(this.tbPAccountDate);
            this.tpProduct.Controls.Add(this.label8);
            this.tpProduct.Controls.Add(this.button2);
            this.tpProduct.Controls.Add(this.tbPTotalQuantity);
            this.tpProduct.Controls.Add(this.tbPDayQuantity);
            this.tpProduct.Controls.Add(this.cbxProductModel);
            this.tpProduct.Controls.Add(this.cbxProductName);
            this.tpProduct.Controls.Add(this.cbxProductKind);
            this.tpProduct.Controls.Add(this.label9);
            this.tpProduct.Controls.Add(this.label10);
            this.tpProduct.Controls.Add(this.label11);
            this.tpProduct.Controls.Add(this.label12);
            this.tpProduct.Controls.Add(this.label13);
            this.tpProduct.Controls.Add(this.dgvProductTest);
            this.tpProduct.Location = new System.Drawing.Point(4, 21);
            this.tpProduct.Name = "tpProduct";
            this.tpProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tpProduct.Size = new System.Drawing.Size(605, 356);
            this.tpProduct.TabIndex = 1;
            this.tpProduct.Text = "产品";
            this.tpProduct.UseVisualStyleBackColor = true;
            // 
            // btn_PrintP
            // 
            this.btn_PrintP.Location = new System.Drawing.Point(377, 319);
            this.btn_PrintP.Name = "btn_PrintP";
            this.btn_PrintP.Size = new System.Drawing.Size(75, 23);
            this.btn_PrintP.TabIndex = 32;
            this.btn_PrintP.Text = "打印";
            this.btn_PrintP.UseVisualStyleBackColor = true;
            this.btn_PrintP.Click += new System.EventHandler(this.btn_PrintP_Click);
            // 
            // tbPAccountDate
            // 
            this.tbPAccountDate.Location = new System.Drawing.Point(468, 54);
            this.tbPAccountDate.Name = "tbPAccountDate";
            this.tbPAccountDate.ReadOnly = true;
            this.tbPAccountDate.Size = new System.Drawing.Size(121, 21);
            this.tbPAccountDate.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(409, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "台帐时间";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(514, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbPTotalQuantity
            // 
            this.tbPTotalQuantity.Location = new System.Drawing.Point(274, 54);
            this.tbPTotalQuantity.Name = "tbPTotalQuantity";
            this.tbPTotalQuantity.ReadOnly = true;
            this.tbPTotalQuantity.Size = new System.Drawing.Size(100, 21);
            this.tbPTotalQuantity.TabIndex = 27;
            // 
            // tbPDayQuantity
            // 
            this.tbPDayQuantity.Location = new System.Drawing.Point(85, 54);
            this.tbPDayQuantity.Name = "tbPDayQuantity";
            this.tbPDayQuantity.ReadOnly = true;
            this.tbPDayQuantity.Size = new System.Drawing.Size(100, 21);
            this.tbPDayQuantity.TabIndex = 26;
            // 
            // cbxProductModel
            // 
            this.cbxProductModel.FormattingEnabled = true;
            this.cbxProductModel.Location = new System.Drawing.Point(468, 18);
            this.cbxProductModel.Name = "cbxProductModel";
            this.cbxProductModel.Size = new System.Drawing.Size(121, 20);
            this.cbxProductModel.TabIndex = 25;
            this.cbxProductModel.SelectionChangeCommitted += new System.EventHandler(this.cbxProductModel_SelectionChangeCommitted);
            // 
            // cbxProductName
            // 
            this.cbxProductName.FormattingEnabled = true;
            this.cbxProductName.Location = new System.Drawing.Point(274, 18);
            this.cbxProductName.Name = "cbxProductName";
            this.cbxProductName.Size = new System.Drawing.Size(121, 20);
            this.cbxProductName.TabIndex = 24;
            this.cbxProductName.SelectionChangeCommitted += new System.EventHandler(this.cbxProductName_SelectionChangeCommitted);
            // 
            // cbxProductKind
            // 
            this.cbxProductKind.FormattingEnabled = true;
            this.cbxProductKind.Location = new System.Drawing.Point(85, 18);
            this.cbxProductKind.Name = "cbxProductKind";
            this.cbxProductKind.Size = new System.Drawing.Size(121, 20);
            this.cbxProductKind.TabIndex = 23;
            this.cbxProductKind.SelectionChangeCommitted += new System.EventHandler(this.cbxProductKind_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(203, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "累计进厂量";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "当日进场量";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(409, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "材料规格";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(215, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "材料名称";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 17;
            this.label13.Text = "材料种类";
            // 
            // dgvProductTest
            // 
            this.dgvProductTest.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductTest.Location = new System.Drawing.Point(18, 90);
            this.dgvProductTest.Name = "dgvProductTest";
            this.dgvProductTest.RowTemplate.Height = 23;
            this.dgvProductTest.Size = new System.Drawing.Size(571, 214);
            this.dgvProductTest.TabIndex = 28;
            // 
            // btnMoveIn
            // 
            this.btnMoveIn.Location = new System.Drawing.Point(355, 209);
            this.btnMoveIn.Name = "btnMoveIn";
            this.btnMoveIn.Size = new System.Drawing.Size(42, 23);
            this.btnMoveIn.TabIndex = 2;
            this.btnMoveIn.Text = ">>";
            this.btnMoveIn.UseVisualStyleBackColor = true;
            this.btnMoveIn.Click += new System.EventHandler(this.btnMoveIn_Click);
            // 
            // btnMoveOut
            // 
            this.btnMoveOut.Location = new System.Drawing.Point(355, 249);
            this.btnMoveOut.Name = "btnMoveOut";
            this.btnMoveOut.Size = new System.Drawing.Size(42, 23);
            this.btnMoveOut.TabIndex = 3;
            this.btnMoveOut.Text = "<<";
            this.btnMoveOut.UseVisualStyleBackColor = true;
            this.btnMoveOut.Click += new System.EventHandler(this.btnMoveOut_Click);
            // 
            // dgvMaterialTestAccount
            // 
            this.dgvMaterialTestAccount.AllowUserToAddRows = false;
            this.dgvMaterialTestAccount.BackgroundColor = System.Drawing.Color.White;
            this.dgvMaterialTestAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterialTestAccount.Location = new System.Drawing.Point(12, 424);
            this.dgvMaterialTestAccount.MultiSelect = false;
            this.dgvMaterialTestAccount.Name = "dgvMaterialTestAccount";
            this.dgvMaterialTestAccount.ReadOnly = true;
            this.dgvMaterialTestAccount.RowTemplate.Height = 23;
            this.dgvMaterialTestAccount.Size = new System.Drawing.Size(1014, 262);
            this.dgvMaterialTestAccount.TabIndex = 4;
            this.dgvMaterialTestAccount.SelectionChanged += new System.EventHandler(this.dgvMaterialTestAccount_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(67, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "试验时间";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(138, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dgvProductTestAccount
            // 
            this.dgvProductTestAccount.AllowUserToAddRows = false;
            this.dgvProductTestAccount.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductTestAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductTestAccount.Location = new System.Drawing.Point(12, 424);
            this.dgvProductTestAccount.MultiSelect = false;
            this.dgvProductTestAccount.Name = "dgvProductTestAccount";
            this.dgvProductTestAccount.ReadOnly = true;
            this.dgvProductTestAccount.RowTemplate.Height = 23;
            this.dgvProductTestAccount.Size = new System.Drawing.Size(1014, 262);
            this.dgvProductTestAccount.TabIndex = 7;
            this.dgvProductTestAccount.SelectionChanged += new System.EventHandler(this.dgvProductTestAccount_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            // 
            // FrmDetectingRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 700);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnMoveOut);
            this.Controls.Add(this.btnMoveIn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgvLabTestInfo);
            this.Controls.Add(this.dgvMaterialTestAccount);
            this.Controls.Add(this.dgvProductTestAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDetectingRecords";
            this.Tag = "FrmDetectingRecords";
            this.Text = "检测记录台帐";
            this.Load += new System.EventHandler(this.DetectingRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabTestInfo)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpMaterial.ResumeLayout(false);
            this.tpMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialTest)).EndInit();
            this.tpProduct.ResumeLayout(false);
            this.tpProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialTestAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductTestAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLabTestInfo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMaterial;
        private System.Windows.Forms.TabPage tpProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxMaterialName;
        private System.Windows.Forms.ComboBox cbxMaterialKind;
        private System.Windows.Forms.ComboBox cbxMaterialModel;
        private System.Windows.Forms.TextBox tbMTotalQuantity;
        private System.Windows.Forms.TextBox tbMDayQuantity;
        private System.Windows.Forms.DataGridView dgvMaterialTest;
        private System.Windows.Forms.Button btnMoveIn;
        private System.Windows.Forms.Button btnMoveOut;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvMaterialTestAccount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPAccountDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvProductTest;
        private System.Windows.Forms.TextBox tbPTotalQuantity;
        private System.Windows.Forms.TextBox tbPDayQuantity;
        private System.Windows.Forms.ComboBox cbxProductModel;
        private System.Windows.Forms.ComboBox cbxProductName;
        private System.Windows.Forms.ComboBox cbxProductKind;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvProductTestAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.TextBox tbMAccountDate;
        private System.Windows.Forms.Button btn_PrintM;
        private System.Windows.Forms.Button btn_PrintP;
    }
}