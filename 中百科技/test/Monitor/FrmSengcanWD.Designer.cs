namespace DasherStation.Monitor
{
    partial class FrmSengcanWD
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
            this.lineCurvesChartType1 = new DasherStation.Monitor.LineCurvesChartType();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtn_no = new System.Windows.Forms.RadioButton();
            this.rbtn_name = new System.Windows.Forms.RadioButton();
            this.btn_query = new System.Windows.Forms.Button();
            this.cbx_no = new System.Windows.Forms.ComboBox();
            this.cbx_name = new System.Windows.Forms.ComboBox();
            this.dtp_data = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lineCurvesChartType1
            // 
            this.lineCurvesChartType1.BackColor = System.Drawing.Color.Transparent;
            this.lineCurvesChartType1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineCurvesChartType1.Location = new System.Drawing.Point(0, 52);
            this.lineCurvesChartType1.Name = "lineCurvesChartType1";
            this.lineCurvesChartType1.Size = new System.Drawing.Size(861, 459);
            this.lineCurvesChartType1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lineCurvesChartType1);
            this.groupBox1.Location = new System.Drawing.Point(4, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(861, 514);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(858, 23);
            this.label1.TabIndex = 1;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.rbtn_no);
            this.groupBox2.Controls.Add(this.rbtn_name);
            this.groupBox2.Controls.Add(this.btn_query);
            this.groupBox2.Controls.Add(this.cbx_no);
            this.groupBox2.Controls.Add(this.cbx_name);
            this.groupBox2.Controls.Add(this.dtp_data);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(869, 71);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // rbtn_no
            // 
            this.rbtn_no.AutoSize = true;
            this.rbtn_no.Location = new System.Drawing.Point(486, 31);
            this.rbtn_no.Name = "rbtn_no";
            this.rbtn_no.Size = new System.Drawing.Size(83, 16);
            this.rbtn_no.TabIndex = 8;
            this.rbtn_no.Text = "温度计编号";
            this.rbtn_no.UseVisualStyleBackColor = true;
            this.rbtn_no.CheckedChanged += new System.EventHandler(this.rbtn_no_CheckedChanged);
            // 
            // rbtn_name
            // 
            this.rbtn_name.AutoSize = true;
            this.rbtn_name.Checked = true;
            this.rbtn_name.Location = new System.Drawing.Point(209, 31);
            this.rbtn_name.Name = "rbtn_name";
            this.rbtn_name.Size = new System.Drawing.Size(83, 16);
            this.rbtn_name.TabIndex = 7;
            this.rbtn_name.TabStop = true;
            this.rbtn_name.Text = "温度计名称";
            this.rbtn_name.UseVisualStyleBackColor = true;
            this.rbtn_name.CheckedChanged += new System.EventHandler(this.rbtn_name_CheckedChanged);
            // 
            // btn_query
            // 
            this.btn_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_query.Location = new System.Drawing.Point(750, 30);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(93, 23);
            this.btn_query.TabIndex = 6;
            this.btn_query.Text = "绘制温度曲线";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // cbx_no
            // 
            this.cbx_no.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_no.Enabled = false;
            this.cbx_no.FormattingEnabled = true;
            this.cbx_no.Items.AddRange(new object[] {
            "",
            "1",
            "5"});
            this.cbx_no.Location = new System.Drawing.Point(575, 30);
            this.cbx_no.Name = "cbx_no";
            this.cbx_no.Size = new System.Drawing.Size(117, 20);
            this.cbx_no.TabIndex = 5;
            // 
            // cbx_name
            // 
            this.cbx_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_name.FormattingEnabled = true;
            this.cbx_name.Location = new System.Drawing.Point(297, 31);
            this.cbx_name.Name = "cbx_name";
            this.cbx_name.Size = new System.Drawing.Size(150, 20);
            this.cbx_name.TabIndex = 4;
            // 
            // dtp_data
            // 
            this.dtp_data.Location = new System.Drawing.Point(49, 29);
            this.dtp_data.Name = "dtp_data";
            this.dtp_data.ShowUpDown = true;
            this.dtp_data.Size = new System.Drawing.Size(120, 21);
            this.dtp_data.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "日期";
            // 
            // FrmSengcanWD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 589);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSengcanWD";
            this.Tag = "FrmSengcanWD";
            this.Text = "生产温度记录";
            this.Load += new System.EventHandler(this.FrmSengcanWD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LineCurvesChartType lineCurvesChartType1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.ComboBox cbx_no;
        private System.Windows.Forms.ComboBox cbx_name;
        private System.Windows.Forms.DateTimePicker dtp_data;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtn_no;
        private System.Windows.Forms.RadioButton rbtn_name;
        private System.Windows.Forms.Label label1;
    }
}