namespace DasherStation.produce
{
    partial class FrmProductionMeasureControl
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
            this.btn_all = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbx_result = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_equipmentInfo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.btn_query = new System.Windows.Forms.Button();
            this.dgv_produceMeasureMonitor = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asphaltumWeight_t = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blockWeight_t = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realMaterialWeight_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realMaterialWeight_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realMaterialWeight_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realMaterialWeight_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realMaterialWeight_5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realMaterialWeight_6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stuffingWeight_t = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_produceMeasureMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btn_all);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.cbx_result);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmb_equipmentInfo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp_end);
            this.groupBox1.Controls.Add(this.dtp_start);
            this.groupBox1.Controls.Add(this.btn_query);
            this.groupBox1.Controls.Add(this.dgv_produceMeasureMonitor);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 510);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生产数据";
            // 
            // btn_all
            // 
            this.btn_all.Location = new System.Drawing.Point(468, 52);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(76, 23);
            this.btn_all.TabIndex = 26;
            this.btn_all.Text = "全部";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(615, 52);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(76, 23);
            this.btnExit.TabIndex = 25;
            this.btnExit.Text = "关闭";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbx_result
            // 
            this.cbx_result.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_result.FormattingEnabled = true;
            this.cbx_result.Items.AddRange(new object[] {
            "合格",
            "不合格"});
            this.cbx_result.Location = new System.Drawing.Point(264, 54);
            this.cbx_result.Name = "cbx_result";
            this.cbx_result.Size = new System.Drawing.Size(95, 20);
            this.cbx_result.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "对比结果";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "设备编号";
            // 
            // cmb_equipmentInfo
            // 
            this.cmb_equipmentInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_equipmentInfo.FormattingEnabled = true;
            this.cmb_equipmentInfo.Location = new System.Drawing.Point(94, 54);
            this.cmb_equipmentInfo.Name = "cmb_equipmentInfo";
            this.cmb_equipmentInfo.Size = new System.Drawing.Size(95, 20);
            this.cmb_equipmentInfo.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "时间区间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "-";
            // 
            // dtp_end
            // 
            this.dtp_end.Location = new System.Drawing.Point(238, 22);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(121, 21);
            this.dtp_end.TabIndex = 18;
            // 
            // dtp_start
            // 
            this.dtp_start.Location = new System.Drawing.Point(94, 22);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(121, 21);
            this.dtp_start.TabIndex = 17;
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(377, 52);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(76, 23);
            this.btn_query.TabIndex = 12;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // dgv_produceMeasureMonitor
            // 
            this.dgv_produceMeasureMonitor.AllowUserToAddRows = false;
            this.dgv_produceMeasureMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_produceMeasureMonitor.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_produceMeasureMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_produceMeasureMonitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.no,
            this.inputDate,
            this.temperature,
            this.asphaltumWeight_t,
            this.blockWeight_t,
            this.realMaterialWeight_1,
            this.realMaterialWeight_2,
            this.realMaterialWeight_3,
            this.realMaterialWeight_4,
            this.realMaterialWeight_5,
            this.realMaterialWeight_6,
            this.stuffingWeight_t,
            this.result});
            this.dgv_produceMeasureMonitor.Location = new System.Drawing.Point(2, 92);
            this.dgv_produceMeasureMonitor.Name = "dgv_produceMeasureMonitor";
            this.dgv_produceMeasureMonitor.ReadOnly = true;
            this.dgv_produceMeasureMonitor.RowTemplate.Height = 23;
            this.dgv_produceMeasureMonitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_produceMeasureMonitor.Size = new System.Drawing.Size(689, 412);
            this.dgv_produceMeasureMonitor.TabIndex = 1;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            this.no.HeaderText = "设备编号";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.HeaderText = "采集时间";
            this.inputDate.Name = "inputDate";
            this.inputDate.ReadOnly = true;
            // 
            // temperature
            // 
            this.temperature.DataPropertyName = "temperature";
            this.temperature.HeaderText = "温度";
            this.temperature.Name = "temperature";
            this.temperature.ReadOnly = true;
            // 
            // asphaltumWeight_t
            // 
            this.asphaltumWeight_t.DataPropertyName = "asphaltumWeight";
            this.asphaltumWeight_t.HeaderText = "沥青计量";
            this.asphaltumWeight_t.Name = "asphaltumWeight_t";
            this.asphaltumWeight_t.ReadOnly = true;
            // 
            // blockWeight_t
            // 
            this.blockWeight_t.DataPropertyName = "blockWeight";
            this.blockWeight_t.HeaderText = "石粉计量";
            this.blockWeight_t.Name = "blockWeight_t";
            this.blockWeight_t.ReadOnly = true;
            // 
            // realMaterialWeight_1
            // 
            this.realMaterialWeight_1.DataPropertyName = "realMaterialWeight1";
            this.realMaterialWeight_1.HeaderText = "1#热料仓";
            this.realMaterialWeight_1.Name = "realMaterialWeight_1";
            this.realMaterialWeight_1.ReadOnly = true;
            // 
            // realMaterialWeight_2
            // 
            this.realMaterialWeight_2.DataPropertyName = "realMaterialWeight2";
            this.realMaterialWeight_2.HeaderText = "2#热料仓";
            this.realMaterialWeight_2.Name = "realMaterialWeight_2";
            this.realMaterialWeight_2.ReadOnly = true;
            // 
            // realMaterialWeight_3
            // 
            this.realMaterialWeight_3.DataPropertyName = "realMaterialWeight3";
            this.realMaterialWeight_3.HeaderText = "3#热料仓";
            this.realMaterialWeight_3.Name = "realMaterialWeight_3";
            this.realMaterialWeight_3.ReadOnly = true;
            // 
            // realMaterialWeight_4
            // 
            this.realMaterialWeight_4.DataPropertyName = "realMaterialWeight4";
            this.realMaterialWeight_4.HeaderText = "4#热料仓";
            this.realMaterialWeight_4.Name = "realMaterialWeight_4";
            this.realMaterialWeight_4.ReadOnly = true;
            // 
            // realMaterialWeight_5
            // 
            this.realMaterialWeight_5.DataPropertyName = "realMaterialWeight5";
            this.realMaterialWeight_5.HeaderText = "5#热料仓";
            this.realMaterialWeight_5.Name = "realMaterialWeight_5";
            this.realMaterialWeight_5.ReadOnly = true;
            // 
            // realMaterialWeight_6
            // 
            this.realMaterialWeight_6.DataPropertyName = "realMaterialWeight6";
            this.realMaterialWeight_6.HeaderText = "6#热料仓";
            this.realMaterialWeight_6.Name = "realMaterialWeight_6";
            this.realMaterialWeight_6.ReadOnly = true;
            // 
            // stuffingWeight_t
            // 
            this.stuffingWeight_t.DataPropertyName = "stuffingWeight";
            this.stuffingWeight_t.HeaderText = "填料";
            this.stuffingWeight_t.Name = "stuffingWeight_t";
            this.stuffingWeight_t.ReadOnly = true;
            // 
            // result
            // 
            this.result.DataPropertyName = "result";
            this.result.HeaderText = "result";
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Visible = false;
            // 
            // FrmProductionMeasureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 534);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmProductionMeasureControl";
            this.Tag = "FrmProductionMeasureControl";
            this.Text = "生产计量监控";
            this.Load += new System.EventHandler(this.FrmProductionMeasureControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_produceMeasureMonitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.DataGridView dgv_produceMeasureMonitor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbx_result;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_equipmentInfo;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn temperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn asphaltumWeight_t;
        private System.Windows.Forms.DataGridViewTextBoxColumn blockWeight_t;
        private System.Windows.Forms.DataGridViewTextBoxColumn realMaterialWeight_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn realMaterialWeight_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn realMaterialWeight_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn realMaterialWeight_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn realMaterialWeight_5;
        private System.Windows.Forms.DataGridViewTextBoxColumn realMaterialWeight_6;
        private System.Windows.Forms.DataGridViewTextBoxColumn stuffingWeight_t;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
    }
}