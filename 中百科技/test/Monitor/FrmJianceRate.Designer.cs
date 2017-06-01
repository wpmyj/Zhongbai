namespace DasherStation.Monitor
{
    partial class FrmJianceRate
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
            this.btn_query = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.cbx_name = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbx_model = new System.Windows.Forms.ComboBox();
            this.cbx_kind = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_test = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtn_product = new System.Windows.Forms.RadioButton();
            this.rbtn_material = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_being = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btn_query);
            this.groupBox1.Controls.Add(this.btn_print);
            this.groupBox1.Controls.Add(this.cbx_name);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbx_model);
            this.groupBox1.Controls.Add(this.cbx_kind);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbx_test);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rbtn_product);
            this.groupBox1.Controls.Add(this.rbtn_material);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp_end);
            this.groupBox1.Controls.Add(this.dtp_being);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(641, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(407, 102);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 29;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(526, 102);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 28;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            // 
            // cbx_name
            // 
            this.cbx_name.FormattingEnabled = true;
            this.cbx_name.Location = new System.Drawing.Point(273, 67);
            this.cbx_name.Name = "cbx_name";
            this.cbx_name.Size = new System.Drawing.Size(120, 20);
            this.cbx_name.TabIndex = 2;
            this.cbx_name.SelectionChangeCommitted += new System.EventHandler(this.cbx_name_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "材料规格";
            // 
            // cbx_model
            // 
            this.cbx_model.FormattingEnabled = true;
            this.cbx_model.Location = new System.Drawing.Point(492, 67);
            this.cbx_model.Name = "cbx_model";
            this.cbx_model.Size = new System.Drawing.Size(120, 20);
            this.cbx_model.TabIndex = 1;
            // 
            // cbx_kind
            // 
            this.cbx_kind.FormattingEnabled = true;
            this.cbx_kind.Location = new System.Drawing.Point(78, 67);
            this.cbx_kind.Name = "cbx_kind";
            this.cbx_kind.Size = new System.Drawing.Size(120, 20);
            this.cbx_kind.TabIndex = 0;
            this.cbx_kind.SelectionChangeCommitted += new System.EventHandler(this.cbx_kind_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "材料名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "材料种类";
            // 
            // cbx_test
            // 
            this.cbx_test.FormattingEnabled = true;
            this.cbx_test.Location = new System.Drawing.Point(492, 37);
            this.cbx_test.Name = "cbx_test";
            this.cbx_test.Size = new System.Drawing.Size(120, 20);
            this.cbx_test.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "检测指标";
            // 
            // rbtn_product
            // 
            this.rbtn_product.AutoSize = true;
            this.rbtn_product.Location = new System.Drawing.Point(215, 14);
            this.rbtn_product.Name = "rbtn_product";
            this.rbtn_product.Size = new System.Drawing.Size(47, 16);
            this.rbtn_product.TabIndex = 22;
            this.rbtn_product.Text = "产品";
            this.rbtn_product.UseVisualStyleBackColor = true;
            this.rbtn_product.CheckedChanged += new System.EventHandler(this.rbtn_product_CheckedChanged);
            // 
            // rbtn_material
            // 
            this.rbtn_material.AutoSize = true;
            this.rbtn_material.Checked = true;
            this.rbtn_material.Location = new System.Drawing.Point(41, 14);
            this.rbtn_material.Name = "rbtn_material";
            this.rbtn_material.Size = new System.Drawing.Size(47, 16);
            this.rbtn_material.TabIndex = 21;
            this.rbtn_material.TabStop = true;
            this.rbtn_material.Text = "材料";
            this.rbtn_material.UseVisualStyleBackColor = true;
            this.rbtn_material.CheckedChanged += new System.EventHandler(this.rbtn_material_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "--";
            // 
            // dtp_end
            // 
            this.dtp_end.Location = new System.Drawing.Point(273, 37);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.ShowUpDown = true;
            this.dtp_end.Size = new System.Drawing.Size(120, 21);
            this.dtp_end.TabIndex = 18;
            // 
            // dtp_being
            // 
            this.dtp_being.Location = new System.Drawing.Point(78, 36);
            this.dtp_being.Name = "dtp_being";
            this.dtp_being.ShowUpDown = true;
            this.dtp_being.Size = new System.Drawing.Size(120, 21);
            this.dtp_being.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(4, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(641, 276);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(635, 256);
            this.dataGridView1.TabIndex = 0;
            // 
            // FrmJianceRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 418);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmJianceRate";
            this.Tag = "FrmJianceRate";
            this.Text = "检测频率与实际对照";
            this.Load += new System.EventHandler(this.FrmJianceRate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.ComboBox cbx_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbx_model;
        private System.Windows.Forms.ComboBox cbx_kind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_test;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtn_product;
        private System.Windows.Forms.RadioButton rbtn_material;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.DateTimePicker dtp_being;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}