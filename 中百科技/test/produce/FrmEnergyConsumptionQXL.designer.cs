namespace DasherStation.produce
{
    partial class FrmEnergyConsumptionQXL
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_Consume = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eiid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_close = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_query = new System.Windows.Forms.Button();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_close1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_edit1 = new System.Windows.Forms.Button();
            this.btn_query1 = new System.Windows.Forms.Button();
            this.dtp_end1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_start1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_Consume1 = new System.Windows.Forms.DataGridView();
            this.id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Consume)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Consume1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 508);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_Consume);
            this.tabPage1.Controls.Add(this.btn_close);
            this.tabPage1.Controls.Add(this.button14);
            this.tabPage1.Controls.Add(this.btn_edit);
            this.tabPage1.Controls.Add(this.btn_query);
            this.tabPage1.Controls.Add(this.dtp_end);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.dtp_start);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(712, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "热油炉能源消耗";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv_Consume
            // 
            this.dgv_Consume.AllowUserToAddRows = false;
            this.dgv_Consume.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_Consume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Consume.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.eiid});
            this.dgv_Consume.Location = new System.Drawing.Point(8, 75);
            this.dgv_Consume.MultiSelect = false;
            this.dgv_Consume.Name = "dgv_Consume";
            this.dgv_Consume.ReadOnly = true;
            this.dgv_Consume.RowTemplate.Height = 23;
            this.dgv_Consume.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Consume.Size = new System.Drawing.Size(696, 398);
            this.dgv_Consume.TabIndex = 41;
            this.dgv_Consume.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Consume_CellDoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // eiid
            // 
            this.eiid.DataPropertyName = "eiid";
            this.eiid.HeaderText = "eiid";
            this.eiid.Name = "eiid";
            this.eiid.ReadOnly = true;
            this.eiid.Visible = false;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(629, 46);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 39;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(170, 46);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 37;
            this.button14.Text = "打印";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(89, 46);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 36;
            this.btn_edit.Text = "编辑";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(8, 46);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 33;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // dtp_end
            // 
            this.dtp_end.Location = new System.Drawing.Point(255, 14);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(152, 21);
            this.dtp_end.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(232, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 29;
            this.label11.Text = "--";
            // 
            // dtp_start
            // 
            this.dtp_start.Location = new System.Drawing.Point(74, 14);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(152, 21);
            this.dtp_start.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 27;
            this.label15.Text = "日期";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_close1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.btn_edit1);
            this.tabPage2.Controls.Add(this.btn_query1);
            this.tabPage2.Controls.Add(this.dtp_end1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dtp_start1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.dgv_Consume1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(712, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "热油炉用煤消耗";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_close1
            // 
            this.btn_close1.Location = new System.Drawing.Point(629, 46);
            this.btn_close1.Name = "btn_close1";
            this.btn_close1.Size = new System.Drawing.Size(75, 23);
            this.btn_close1.TabIndex = 58;
            this.btn_close1.Text = "关闭";
            this.btn_close1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 57;
            this.button2.Text = "打印";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_edit1
            // 
            this.btn_edit1.Location = new System.Drawing.Point(89, 46);
            this.btn_edit1.Name = "btn_edit1";
            this.btn_edit1.Size = new System.Drawing.Size(75, 23);
            this.btn_edit1.TabIndex = 56;
            this.btn_edit1.Text = "编辑";
            this.btn_edit1.UseVisualStyleBackColor = true;
            this.btn_edit1.Click += new System.EventHandler(this.btn_edit1_Click);
            // 
            // btn_query1
            // 
            this.btn_query1.Location = new System.Drawing.Point(8, 46);
            this.btn_query1.Name = "btn_query1";
            this.btn_query1.Size = new System.Drawing.Size(75, 23);
            this.btn_query1.TabIndex = 55;
            this.btn_query1.Text = "查询";
            this.btn_query1.UseVisualStyleBackColor = true;
            this.btn_query1.Click += new System.EventHandler(this.btn_query1_Click);
            // 
            // dtp_end1
            // 
            this.dtp_end1.Location = new System.Drawing.Point(255, 14);
            this.dtp_end1.Name = "dtp_end1";
            this.dtp_end1.Size = new System.Drawing.Size(152, 21);
            this.dtp_end1.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 53;
            this.label1.Text = "--";
            // 
            // dtp_start1
            // 
            this.dtp_start1.Location = new System.Drawing.Point(74, 14);
            this.dtp_start1.Name = "dtp_start1";
            this.dtp_start1.Size = new System.Drawing.Size(152, 21);
            this.dtp_start1.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 51;
            this.label2.Text = "日期";
            // 
            // dgv_Consume1
            // 
            this.dgv_Consume1.AllowUserToAddRows = false;
            this.dgv_Consume1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_Consume1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Consume1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id1,
            this.dataGridViewTextBoxColumn2});
            this.dgv_Consume1.Location = new System.Drawing.Point(8, 75);
            this.dgv_Consume1.MultiSelect = false;
            this.dgv_Consume1.Name = "dgv_Consume1";
            this.dgv_Consume1.ReadOnly = true;
            this.dgv_Consume1.RowTemplate.Height = 23;
            this.dgv_Consume1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Consume1.Size = new System.Drawing.Size(696, 398);
            this.dgv_Consume1.TabIndex = 50;
            this.dgv_Consume1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Consume1_CellDoubleClick);
            // 
            // id1
            // 
            this.id1.DataPropertyName = "id";
            this.id1.HeaderText = "id";
            this.id1.Name = "id1";
            this.id1.ReadOnly = true;
            this.id1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "eiid";
            this.dataGridViewTextBoxColumn2.HeaderText = "eiid";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // FrmEnergyConsumptionQXL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 508);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmEnergyConsumptionQXL";
            this.Tag = "FrmEnergyConsumptionQXL";
            this.Text = "热油炉能源消耗";
            this.Load += new System.EventHandler(this.FrmEnergyConsumptionQXL_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Consume)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Consume1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView dgv_Consume;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn eiid;
        private System.Windows.Forms.DataGridView dgv_Consume1;
        private System.Windows.Forms.Button btn_close1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_edit1;
        private System.Windows.Forms.Button btn_query1;
        private System.Windows.Forms.DateTimePicker dtp_end1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_start1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}