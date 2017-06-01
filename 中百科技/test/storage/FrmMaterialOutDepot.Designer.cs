namespace DasherStation.storage
{
    partial class FrmMaterialOutDepot
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.cbxModel = new System.Windows.Forms.ComboBox();
            this.cbxMModel = new System.Windows.Forms.ComboBox();
            this.cbxName = new System.Windows.Forms.ComboBox();
            this.cbxENo = new System.Windows.Forms.ComboBox();
            this.cbxKind = new System.Windows.Forms.ComboBox();
            this.cbxMKind = new System.Windows.Forms.ComboBox();
            this.cbxMName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Controls.Add(this.txtUnitPrice);
            this.groupBox1.Controls.Add(this.cbxModel);
            this.groupBox1.Controls.Add(this.cbxMModel);
            this.groupBox1.Controls.Add(this.cbxName);
            this.groupBox1.Controls.Add(this.cbxENo);
            this.groupBox1.Controls.Add(this.cbxKind);
            this.groupBox1.Controls.Add(this.cbxMKind);
            this.groupBox1.Controls.Add(this.cbxMName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(379, 134);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(100, 133);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(120, 21);
            this.txtNumber.TabIndex = 14;
            this.txtNumber.Tag = "EF";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Enabled = false;
            this.txtUnitPrice.Location = new System.Drawing.Point(334, 104);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(120, 21);
            this.txtUnitPrice.TabIndex = 20;
            // 
            // cbxModel
            // 
            this.cbxModel.FormattingEnabled = true;
            this.cbxModel.Location = new System.Drawing.Point(334, 75);
            this.cbxModel.Name = "cbxModel";
            this.cbxModel.Size = new System.Drawing.Size(120, 20);
            this.cbxModel.TabIndex = 17;
            this.cbxModel.Tag = "E";
            // 
            // cbxMModel
            // 
            this.cbxMModel.FormattingEnabled = true;
            this.cbxMModel.Location = new System.Drawing.Point(100, 75);
            this.cbxMModel.Name = "cbxMModel";
            this.cbxMModel.Size = new System.Drawing.Size(120, 20);
            this.cbxMModel.TabIndex = 12;
            this.cbxMModel.Tag = "E";
            this.cbxMModel.Leave += new System.EventHandler(this.cbxMModel_Leave);
            // 
            // cbxName
            // 
            this.cbxName.FormattingEnabled = true;
            this.cbxName.Location = new System.Drawing.Point(334, 46);
            this.cbxName.Name = "cbxName";
            this.cbxName.Size = new System.Drawing.Size(120, 20);
            this.cbxName.TabIndex = 16;
            this.cbxName.Tag = "E";
            this.cbxName.SelectionChangeCommitted += new System.EventHandler(this.cbxName_SelectionChangeCommitted);
            // 
            // cbxENo
            // 
            this.cbxENo.FormattingEnabled = true;
            this.cbxENo.Location = new System.Drawing.Point(100, 104);
            this.cbxENo.Name = "cbxENo";
            this.cbxENo.Size = new System.Drawing.Size(120, 20);
            this.cbxENo.TabIndex = 13;
            this.cbxENo.Tag = "E";
            // 
            // cbxKind
            // 
            this.cbxKind.FormattingEnabled = true;
            this.cbxKind.Location = new System.Drawing.Point(334, 17);
            this.cbxKind.Name = "cbxKind";
            this.cbxKind.Size = new System.Drawing.Size(120, 20);
            this.cbxKind.TabIndex = 15;
            this.cbxKind.Tag = "E";
            this.cbxKind.SelectionChangeCommitted += new System.EventHandler(this.cbxKind_SelectionChangeCommitted);
            // 
            // cbxMKind
            // 
            this.cbxMKind.FormattingEnabled = true;
            this.cbxMKind.Location = new System.Drawing.Point(100, 17);
            this.cbxMKind.Name = "cbxMKind";
            this.cbxMKind.Size = new System.Drawing.Size(120, 20);
            this.cbxMKind.TabIndex = 10;
            this.cbxMKind.Tag = "E";
            this.cbxMKind.SelectionChangeCommitted += new System.EventHandler(this.cbxMKind_SelectionChangeCommitted);
            // 
            // cbxMName
            // 
            this.cbxMName.FormattingEnabled = true;
            this.cbxMName.Location = new System.Drawing.Point(100, 46);
            this.cbxMName.Name = "cbxMName";
            this.cbxMName.Size = new System.Drawing.Size(120, 20);
            this.cbxMName.TabIndex = 11;
            this.cbxMName.Tag = "E";
            this.cbxMName.SelectionChangeCommitted += new System.EventHandler(this.cbxMName_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "设备编号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(249, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "材料单价";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "出库数量";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "生产产品规格";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "生产产品名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "生产产品种类";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "出库材料规格";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "出库材料名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "出库材料种类";
            // 
            // FrmMaterialOutDepot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 169);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmMaterialOutDepot";
            this.Tag = "FrmMaterialOutDepot";
            this.Text = "材料手工出库";
            this.Load += new System.EventHandler(this.FrmMaterialOutDepot_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmMaterialOutDepot_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.ComboBox cbxModel;
        private System.Windows.Forms.ComboBox cbxMModel;
        private System.Windows.Forms.ComboBox cbxName;
        private System.Windows.Forms.ComboBox cbxENo;
        private System.Windows.Forms.ComboBox cbxKind;
        private System.Windows.Forms.ComboBox cbxMKind;
        private System.Windows.Forms.ComboBox cbxMName;
        private System.Windows.Forms.Label label9;
    }
}