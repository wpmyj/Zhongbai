namespace DasherStation.stock
{
    partial class materialNeeding
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.january = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.february = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.march = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.april = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.may = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.june = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.july = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.august = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.september = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.october = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.november = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.december = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "年份";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(14, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 297);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "年度材料需求计划";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mId,
            this.inputDate,
            this.sort,
            this.name,
            this.model,
            this.quantity,
            this.january,
            this.february,
            this.march,
            this.april,
            this.may,
            this.june,
            this.july,
            this.august,
            this.september,
            this.october,
            this.november,
            this.december});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(625, 277);
            this.dataGridView1.TabIndex = 0;
            // 
            // mId
            // 
            this.mId.DataPropertyName = "mId";
            this.mId.HeaderText = "mId";
            this.mId.Name = "mId";
            this.mId.Visible = false;
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.HeaderText = "录入时间";
            this.inputDate.Name = "inputDate";
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "材料种类";
            this.sort.Name = "sort";
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "材料名称";
            this.name.Name = "name";
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "规格型号";
            this.model.Name = "model";
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "采购总量";
            this.quantity.Name = "quantity";
            // 
            // january
            // 
            this.january.DataPropertyName = "january";
            this.january.HeaderText = "一月份";
            this.january.Name = "january";
            // 
            // february
            // 
            this.february.DataPropertyName = "february";
            this.february.HeaderText = "二月份";
            this.february.Name = "february";
            // 
            // march
            // 
            this.march.DataPropertyName = "march";
            this.march.HeaderText = "三月份";
            this.march.Name = "march";
            // 
            // april
            // 
            this.april.DataPropertyName = "april";
            this.april.HeaderText = "四月份";
            this.april.Name = "april";
            // 
            // may
            // 
            this.may.DataPropertyName = "may";
            this.may.HeaderText = "五月份";
            this.may.Name = "may";
            // 
            // june
            // 
            this.june.DataPropertyName = "june";
            this.june.HeaderText = "六月份";
            this.june.Name = "june";
            // 
            // july
            // 
            this.july.DataPropertyName = "july";
            this.july.HeaderText = "七月份";
            this.july.Name = "july";
            // 
            // august
            // 
            this.august.DataPropertyName = "august";
            this.august.HeaderText = "八月份";
            this.august.Name = "august";
            // 
            // september
            // 
            this.september.DataPropertyName = "september";
            this.september.HeaderText = "九月份";
            this.september.Name = "september";
            // 
            // october
            // 
            this.october.DataPropertyName = "october";
            this.october.HeaderText = "十月份";
            this.october.Name = "october";
            // 
            // november
            // 
            this.november.DataPropertyName = "november";
            this.november.HeaderText = "十一月份";
            this.november.Name = "november";
            // 
            // december
            // 
            this.december.DataPropertyName = "december";
            this.december.HeaderText = "十二月份";
            this.december.Name = "december";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(457, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "将选中的内容复制到采购计划中";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(47, 4);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(62, 21);
            this.txtYear.TabIndex = 6;
            // 
            // materialNeeding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 340);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "materialNeeding";
            this.Tag = "materialNeeding";
            this.Text = "材料需求计划";
            this.Load += new System.EventHandler(this.materialNeeding_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mId;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn january;
        private System.Windows.Forms.DataGridViewTextBoxColumn february;
        private System.Windows.Forms.DataGridViewTextBoxColumn march;
        private System.Windows.Forms.DataGridViewTextBoxColumn april;
        private System.Windows.Forms.DataGridViewTextBoxColumn may;
        private System.Windows.Forms.DataGridViewTextBoxColumn june;
        private System.Windows.Forms.DataGridViewTextBoxColumn july;
        private System.Windows.Forms.DataGridViewTextBoxColumn august;
        private System.Windows.Forms.DataGridViewTextBoxColumn september;
        private System.Windows.Forms.DataGridViewTextBoxColumn october;
        private System.Windows.Forms.DataGridViewTextBoxColumn november;
        private System.Windows.Forms.DataGridViewTextBoxColumn december;
        private System.Windows.Forms.TextBox txtYear;
    }
}