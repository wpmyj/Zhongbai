namespace DasherStation.storage
{
    partial class FrmStockCheck
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
            this.txtDCause = new System.Windows.Forms.TextBox();
            this.txtDiversity = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.rbtnPProduct = new System.Windows.Forms.RadioButton();
            this.rbtnPMaterial = new System.Windows.Forms.RadioButton();
            this.dtpCheck = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTheory = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtInventory = new System.Windows.Forms.TextBox();
            this.cbxPModel = new System.Windows.Forms.ComboBox();
            this.cbxPName = new System.Windows.Forms.ComboBox();
            this.cbxPKind = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCheck = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRetouch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheck)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDCause
            // 
            this.txtDCause.Location = new System.Drawing.Point(97, 131);
            this.txtDCause.Multiline = true;
            this.txtDCause.Name = "txtDCause";
            this.txtDCause.Size = new System.Drawing.Size(648, 44);
            this.txtDCause.TabIndex = 21;
            this.txtDCause.Tag = "S";
            // 
            // txtDiversity
            // 
            this.txtDiversity.Enabled = false;
            this.txtDiversity.Location = new System.Drawing.Point(97, 102);
            this.txtDiversity.Name = "txtDiversity";
            this.txtDiversity.Size = new System.Drawing.Size(120, 21);
            this.txtDiversity.TabIndex = 0;
            this.txtDiversity.Tag = "F";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(30, 134);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 20;
            this.label15.Text = "备注";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 19;
            this.label14.Text = "差异量";
            // 
            // rbtnPProduct
            // 
            this.rbtnPProduct.AutoSize = true;
            this.rbtnPProduct.Location = new System.Drawing.Point(183, 20);
            this.rbtnPProduct.Name = "rbtnPProduct";
            this.rbtnPProduct.Size = new System.Drawing.Size(47, 16);
            this.rbtnPProduct.TabIndex = 18;
            this.rbtnPProduct.Text = "产品";
            this.rbtnPProduct.UseVisualStyleBackColor = true;
            this.rbtnPProduct.CheckedChanged += new System.EventHandler(this.rbtnPProduct_CheckedChanged);
            // 
            // rbtnPMaterial
            // 
            this.rbtnPMaterial.AutoSize = true;
            this.rbtnPMaterial.Checked = true;
            this.rbtnPMaterial.Location = new System.Drawing.Point(32, 20);
            this.rbtnPMaterial.Name = "rbtnPMaterial";
            this.rbtnPMaterial.Size = new System.Drawing.Size(47, 16);
            this.rbtnPMaterial.TabIndex = 17;
            this.rbtnPMaterial.TabStop = true;
            this.rbtnPMaterial.Text = "材料";
            this.rbtnPMaterial.UseVisualStyleBackColor = true;
            this.rbtnPMaterial.CheckedChanged += new System.EventHandler(this.rbtnPMaterial_CheckedChanged);
            // 
            // dtpCheck
            // 
            this.dtpCheck.Location = new System.Drawing.Point(625, 73);
            this.dtpCheck.Name = "dtpCheck";
            this.dtpCheck.ShowUpDown = true;
            this.dtpCheck.Size = new System.Drawing.Size(120, 21);
            this.dtpCheck.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(559, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "盘点日期";
            // 
            // txtTheory
            // 
            this.txtTheory.Enabled = false;
            this.txtTheory.Location = new System.Drawing.Point(97, 73);
            this.txtTheory.Name = "txtTheory";
            this.txtTheory.Size = new System.Drawing.Size(120, 21);
            this.txtTheory.TabIndex = 15;
            this.txtTheory.Tag = "F";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "理论库存";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(0, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 1);
            this.panel1.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(671, 182);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtInventory
            // 
            this.txtInventory.Location = new System.Drawing.Point(361, 73);
            this.txtInventory.Name = "txtInventory";
            this.txtInventory.Size = new System.Drawing.Size(120, 21);
            this.txtInventory.TabIndex = 8;
            this.txtInventory.Tag = "F";
            this.txtInventory.Leave += new System.EventHandler(this.txtInventory_Leave);
            // 
            // cbxPModel
            // 
            this.cbxPModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPModel.FormattingEnabled = true;
            this.cbxPModel.Location = new System.Drawing.Point(625, 46);
            this.cbxPModel.Name = "cbxPModel";
            this.cbxPModel.Size = new System.Drawing.Size(120, 20);
            this.cbxPModel.TabIndex = 7;
            this.cbxPModel.Tag = "E";
            this.cbxPModel.Leave += new System.EventHandler(this.cbxPModel_Leave);
            // 
            // cbxPName
            // 
            this.cbxPName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPName.FormattingEnabled = true;
            this.cbxPName.Location = new System.Drawing.Point(361, 46);
            this.cbxPName.Name = "cbxPName";
            this.cbxPName.Size = new System.Drawing.Size(120, 20);
            this.cbxPName.TabIndex = 6;
            this.cbxPName.Tag = "E";
            this.cbxPName.SelectionChangeCommitted += new System.EventHandler(this.cbxPName_SelectionChangeCommitted);
            // 
            // cbxPKind
            // 
            this.cbxPKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPKind.FormattingEnabled = true;
            this.cbxPKind.Location = new System.Drawing.Point(97, 46);
            this.cbxPKind.Name = "cbxPKind";
            this.cbxPKind.Size = new System.Drawing.Size(120, 20);
            this.cbxPKind.TabIndex = 5;
            this.cbxPKind.Tag = "E";
            this.cbxPKind.SelectionChangeCommitted += new System.EventHandler(this.cbxPKind_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "盘点数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(559, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "规格型号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "材料名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "材料种类";
            // 
            // dgvCheck
            // 
            this.dgvCheck.AllowUserToAddRows = false;
            this.dgvCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCheck.BackgroundColor = System.Drawing.Color.White;
            this.dgvCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheck.Location = new System.Drawing.Point(3, 215);
            this.dgvCheck.Name = "dgvCheck";
            this.dgvCheck.RowTemplate.Height = 23;
            this.dgvCheck.Size = new System.Drawing.Size(788, 348);
            this.dgvCheck.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtRetouch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDCause);
            this.groupBox1.Controls.Add(this.txtDiversity);
            this.groupBox1.Controls.Add(this.rbtnPMaterial);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.dgvCheck);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbtnPProduct);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpCheck);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbxPKind);
            this.groupBox1.Controls.Add(this.txtTheory);
            this.groupBox1.Controls.Add(this.cbxPName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbxPModel);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.txtInventory);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 566);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtRetouch
            // 
            this.txtRetouch.Location = new System.Drawing.Point(361, 102);
            this.txtRetouch.Name = "txtRetouch";
            this.txtRetouch.Size = new System.Drawing.Size(120, 21);
            this.txtRetouch.TabIndex = 23;
            this.txtRetouch.Tag = "F";
            this.txtRetouch.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "修正数量";
            this.label5.Visible = false;
            // 
            // FrmStockCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmStockCheck";
            this.Tag = "FrmStockCheck";
            this.Text = "库存盘点";
            this.Load += new System.EventHandler(this.FrmStockCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheck)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtInventory;
        private System.Windows.Forms.ComboBox cbxPModel;
        private System.Windows.Forms.ComboBox cbxPName;
        private System.Windows.Forms.ComboBox cbxPKind;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTheory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbtnPProduct;
        private System.Windows.Forms.RadioButton rbtnPMaterial;
        private System.Windows.Forms.DateTimePicker dtpCheck;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDCause;
        private System.Windows.Forms.TextBox txtDiversity;
        private System.Windows.Forms.TextBox txtRetouch;
        private System.Windows.Forms.Label label5;


    }
}