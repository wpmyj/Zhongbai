namespace DasherStation.produce
{
    partial class FrmRawMaterialConsumptionBitumen
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
            this.btn_query = new System.Windows.Forms.Button();
            this.dgv_rAsphaltumConsume = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.btn_print = new System.Windows.Forms.Button();
            this.cmb_model = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_print1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_end1 = new System.Windows.Forms.DateTimePicker();
            this.dtp_start1 = new System.Windows.Forms.DateTimePicker();
            this.cmb_model1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_query1 = new System.Windows.Forms.Button();
            this.dgv_AsphaltumConsume = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rAsphaltumConsume)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AsphaltumConsume)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(257, 42);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(74, 23);
            this.btn_query.TabIndex = 3;
            this.btn_query.Text = "搜索";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // dgv_rAsphaltumConsume
            // 
            this.dgv_rAsphaltumConsume.AllowUserToAddRows = false;
            this.dgv_rAsphaltumConsume.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_rAsphaltumConsume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_rAsphaltumConsume.Location = new System.Drawing.Point(6, 74);
            this.dgv_rAsphaltumConsume.Name = "dgv_rAsphaltumConsume";
            this.dgv_rAsphaltumConsume.ReadOnly = true;
            this.dgv_rAsphaltumConsume.RowTemplate.Height = 23;
            this.dgv_rAsphaltumConsume.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_rAsphaltumConsume.Size = new System.Drawing.Size(698, 432);
            this.dgv_rAsphaltumConsume.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(719, 534);
            this.tabControl1.TabIndex = 13;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dtp_end);
            this.tabPage1.Controls.Add(this.dtp_start);
            this.tabPage1.Controls.Add(this.btn_print);
            this.tabPage1.Controls.Add(this.cmb_model);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btn_query);
            this.tabPage1.Controls.Add(this.dgv_rAsphaltumConsume);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(711, 509);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "改性沥青消耗";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "--";
            // 
            // dtp_end
            // 
            this.dtp_end.Location = new System.Drawing.Point(257, 9);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(153, 21);
            this.dtp_end.TabIndex = 11;
            // 
            // dtp_start
            // 
            this.dtp_start.Location = new System.Drawing.Point(79, 9);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(153, 21);
            this.dtp_start.TabIndex = 10;
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(631, 43);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(74, 23);
            this.btn_print.TabIndex = 8;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            // 
            // cmb_model
            // 
            this.cmb_model.FormattingEnabled = true;
            this.cmb_model.Location = new System.Drawing.Point(79, 45);
            this.cmb_model.Name = "cmb_model";
            this.cmb_model.Size = new System.Drawing.Size(151, 20);
            this.cmb_model.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "规格型号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "日期";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_print1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.dtp_end1);
            this.tabPage2.Controls.Add(this.dtp_start1);
            this.tabPage2.Controls.Add(this.cmb_model1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btn_query1);
            this.tabPage2.Controls.Add(this.dgv_AsphaltumConsume);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(711, 509);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "基质沥青消耗";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_print1
            // 
            this.btn_print1.Location = new System.Drawing.Point(630, 43);
            this.btn_print1.Name = "btn_print1";
            this.btn_print1.Size = new System.Drawing.Size(74, 23);
            this.btn_print1.TabIndex = 20;
            this.btn_print1.Text = "打印";
            this.btn_print1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "--";
            // 
            // dtp_end1
            // 
            this.dtp_end1.Location = new System.Drawing.Point(257, 9);
            this.dtp_end1.Name = "dtp_end1";
            this.dtp_end1.Size = new System.Drawing.Size(153, 21);
            this.dtp_end1.TabIndex = 18;
            // 
            // dtp_start1
            // 
            this.dtp_start1.Location = new System.Drawing.Point(79, 9);
            this.dtp_start1.Name = "dtp_start1";
            this.dtp_start1.Size = new System.Drawing.Size(153, 21);
            this.dtp_start1.TabIndex = 17;
            // 
            // cmb_model1
            // 
            this.cmb_model1.FormattingEnabled = true;
            this.cmb_model1.Location = new System.Drawing.Point(79, 45);
            this.cmb_model1.Name = "cmb_model1";
            this.cmb_model1.Size = new System.Drawing.Size(151, 20);
            this.cmb_model1.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "规格型号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "日期";
            // 
            // btn_query1
            // 
            this.btn_query1.Location = new System.Drawing.Point(257, 42);
            this.btn_query1.Name = "btn_query1";
            this.btn_query1.Size = new System.Drawing.Size(74, 23);
            this.btn_query1.TabIndex = 13;
            this.btn_query1.Text = "搜索";
            this.btn_query1.UseVisualStyleBackColor = true;
            this.btn_query1.Click += new System.EventHandler(this.btn_query1_Click);
            // 
            // dgv_AsphaltumConsume
            // 
            this.dgv_AsphaltumConsume.AllowUserToAddRows = false;
            this.dgv_AsphaltumConsume.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_AsphaltumConsume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AsphaltumConsume.Location = new System.Drawing.Point(6, 74);
            this.dgv_AsphaltumConsume.Name = "dgv_AsphaltumConsume";
            this.dgv_AsphaltumConsume.ReadOnly = true;
            this.dgv_AsphaltumConsume.RowTemplate.Height = 23;
            this.dgv_AsphaltumConsume.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_AsphaltumConsume.Size = new System.Drawing.Size(698, 432);
            this.dgv_AsphaltumConsume.TabIndex = 0;
            // 
            // FrmRawMaterialConsumptionBitumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 536);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmRawMaterialConsumptionBitumen";
            this.Tag = "FrmRawMaterialConsumptionBitumen";
            this.Text = "沥青消耗明细";
            this.Load += new System.EventHandler(this.FrmRawMaterialConsumptionBitumen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rAsphaltumConsume)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AsphaltumConsume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.DataGridView dgv_rAsphaltumConsume;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmb_model;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.Button btn_print1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_end1;
        private System.Windows.Forms.DateTimePicker dtp_start1;
        private System.Windows.Forms.ComboBox cmb_model1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_query1;
        private System.Windows.Forms.DataGridView dgv_AsphaltumConsume;
    }
}