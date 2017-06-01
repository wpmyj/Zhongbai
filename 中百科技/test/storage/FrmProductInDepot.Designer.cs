namespace DasherStation.storage
{
    partial class FrmProductInDepot
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
            this.cbxENo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxModel = new System.Windows.Forms.ComboBox();
            this.cbxName = new System.Windows.Forms.ComboBox();
            this.cbxKind = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbxENo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.cbxModel);
            this.groupBox1.Controls.Add(this.cbxName);
            this.groupBox1.Controls.Add(this.cbxKind);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtUnitPrice);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbxENo
            // 
            this.cbxENo.FormattingEnabled = true;
            this.cbxENo.Location = new System.Drawing.Point(331, 22);
            this.cbxENo.Name = "cbxENo";
            this.cbxENo.Size = new System.Drawing.Size(121, 20);
            this.cbxENo.TabIndex = 13;
            this.cbxENo.Tag = "E";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "设备编号";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(377, 108);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxModel
            // 
            this.cbxModel.FormattingEnabled = true;
            this.cbxModel.Location = new System.Drawing.Point(86, 81);
            this.cbxModel.Name = "cbxModel";
            this.cbxModel.Size = new System.Drawing.Size(121, 20);
            this.cbxModel.TabIndex = 12;
            this.cbxModel.Tag = "E";
            this.cbxModel.Leave += new System.EventHandler(this.cbxModel_Leave);
            // 
            // cbxName
            // 
            this.cbxName.FormattingEnabled = true;
            this.cbxName.Location = new System.Drawing.Point(86, 51);
            this.cbxName.Name = "cbxName";
            this.cbxName.Size = new System.Drawing.Size(121, 20);
            this.cbxName.TabIndex = 11;
            this.cbxName.Tag = "E";
            this.cbxName.SelectionChangeCommitted += new System.EventHandler(this.cbxName_SelectionChangeCommitted);
            // 
            // cbxKind
            // 
            this.cbxKind.FormattingEnabled = true;
            this.cbxKind.Location = new System.Drawing.Point(86, 22);
            this.cbxKind.Name = "cbxKind";
            this.cbxKind.Size = new System.Drawing.Size(121, 20);
            this.cbxKind.TabIndex = 10;
            this.cbxKind.Tag = "E";
            this.cbxKind.SelectionChangeCommitted += new System.EventHandler(this.cbxKind_SelectionChangeCommitted);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(331, 51);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(121, 21);
            this.txtAmount.TabIndex = 14;
            this.txtAmount.Tag = "EF";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Enabled = false;
            this.txtUnitPrice.Location = new System.Drawing.Point(331, 81);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(121, 21);
            this.txtUnitPrice.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(265, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "产品单价";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "入库数量";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "产品规格";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "产品名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "产品种类";
            // 
            // FrmProductInDepot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 150);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmProductInDepot";
            this.Tag = "FrmProductInDepot";
            this.Text = "产品手工入库";
            this.Load += new System.EventHandler(this.FrmProductInDepot_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmProductInDepot_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxModel;
        private System.Windows.Forms.ComboBox cbxName;
        private System.Windows.Forms.ComboBox cbxKind;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxENo;
        private System.Windows.Forms.Label label1;
    }
}