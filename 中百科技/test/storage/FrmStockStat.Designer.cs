namespace DasherStation.storage
{
    partial class FrmStockStat
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
            this.rbtnProduct = new System.Windows.Forms.RadioButton();
            this.rbtnMaterial = new System.Windows.Forms.RadioButton();
            this.dgvStockStat = new System.Windows.Forms.DataGridView();
            this.btn_print = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockStat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btn_print);
            this.groupBox1.Controls.Add(this.rbtnProduct);
            this.groupBox1.Controls.Add(this.rbtnMaterial);
            this.groupBox1.Controls.Add(this.dgvStockStat);
            this.groupBox1.Location = new System.Drawing.Point(3, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 565);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbtnProduct
            // 
            this.rbtnProduct.AutoSize = true;
            this.rbtnProduct.Location = new System.Drawing.Point(215, 17);
            this.rbtnProduct.Name = "rbtnProduct";
            this.rbtnProduct.Size = new System.Drawing.Size(71, 16);
            this.rbtnProduct.TabIndex = 2;
            this.rbtnProduct.Text = "产品库存";
            this.rbtnProduct.UseVisualStyleBackColor = true;
            this.rbtnProduct.CheckedChanged += new System.EventHandler(this.rbtnProduct_CheckedChanged);
            // 
            // rbtnMaterial
            // 
            this.rbtnMaterial.AutoSize = true;
            this.rbtnMaterial.Checked = true;
            this.rbtnMaterial.Location = new System.Drawing.Point(40, 17);
            this.rbtnMaterial.Name = "rbtnMaterial";
            this.rbtnMaterial.Size = new System.Drawing.Size(71, 16);
            this.rbtnMaterial.TabIndex = 1;
            this.rbtnMaterial.TabStop = true;
            this.rbtnMaterial.Text = "材料库存";
            this.rbtnMaterial.UseVisualStyleBackColor = true;
            this.rbtnMaterial.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // dgvStockStat
            // 
            this.dgvStockStat.AllowUserToAddRows = false;
            this.dgvStockStat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStockStat.BackgroundColor = System.Drawing.Color.White;
            this.dgvStockStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockStat.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvStockStat.Location = new System.Drawing.Point(6, 41);
            this.dgvStockStat.Name = "dgvStockStat";
            this.dgvStockStat.RowTemplate.Height = 23;
            this.dgvStockStat.Size = new System.Drawing.Size(777, 519);
            this.dgvStockStat.TabIndex = 0;
            this.dgvStockStat.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvStockStat_DataBindingComplete);
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(641, 14);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 3;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // FrmStockStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmStockStat";
            this.Tag = "FrmStockStat";
            this.Text = "库存统计";
            this.Load += new System.EventHandler(this.FrmStockStat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockStat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvStockStat;
        internal System.Windows.Forms.RadioButton rbtnProduct;
        internal System.Windows.Forms.RadioButton rbtnMaterial;
        private System.Windows.Forms.Button btn_print;
    }
}