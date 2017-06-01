namespace DasherStation.produce
{
    partial class FrmProductionScheduleNeed
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
            this.dgv_need = new System.Windows.Forms.DataGridView();
            this.mId = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_need)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_need
            // 
            this.dgv_need.AllowUserToAddRows = false;
            this.dgv_need.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_need.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_need.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mId,
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
            this.dgv_need.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_need.Location = new System.Drawing.Point(0, 0);
            this.dgv_need.Name = "dgv_need";
            this.dgv_need.ReadOnly = true;
            this.dgv_need.RowTemplate.Height = 23;
            this.dgv_need.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_need.Size = new System.Drawing.Size(642, 444);
            this.dgv_need.TabIndex = 1;
            // 
            // mId
            // 
            this.mId.DataPropertyName = "mId";
            this.mId.HeaderText = "mId";
            this.mId.Name = "mId";
            this.mId.ReadOnly = true;
            this.mId.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "材料名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "规格型号";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "采购总量";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // january
            // 
            this.january.DataPropertyName = "january";
            this.january.HeaderText = "一月份";
            this.january.Name = "january";
            this.january.ReadOnly = true;
            // 
            // february
            // 
            this.february.DataPropertyName = "february";
            this.february.HeaderText = "二月份";
            this.february.Name = "february";
            this.february.ReadOnly = true;
            // 
            // march
            // 
            this.march.DataPropertyName = "march";
            this.march.HeaderText = "三月份";
            this.march.Name = "march";
            this.march.ReadOnly = true;
            // 
            // april
            // 
            this.april.DataPropertyName = "april";
            this.april.HeaderText = "四月份";
            this.april.Name = "april";
            this.april.ReadOnly = true;
            // 
            // may
            // 
            this.may.DataPropertyName = "may";
            this.may.HeaderText = "五月份";
            this.may.Name = "may";
            this.may.ReadOnly = true;
            // 
            // june
            // 
            this.june.DataPropertyName = "june";
            this.june.HeaderText = "六月份";
            this.june.Name = "june";
            this.june.ReadOnly = true;
            // 
            // july
            // 
            this.july.DataPropertyName = "july";
            this.july.HeaderText = "七月份";
            this.july.Name = "july";
            this.july.ReadOnly = true;
            // 
            // august
            // 
            this.august.DataPropertyName = "august";
            this.august.HeaderText = "八月份";
            this.august.Name = "august";
            this.august.ReadOnly = true;
            // 
            // september
            // 
            this.september.DataPropertyName = "september";
            this.september.HeaderText = "九月份";
            this.september.Name = "september";
            this.september.ReadOnly = true;
            // 
            // october
            // 
            this.october.DataPropertyName = "october";
            this.october.HeaderText = "十月份";
            this.october.Name = "october";
            this.october.ReadOnly = true;
            // 
            // november
            // 
            this.november.DataPropertyName = "november";
            this.november.HeaderText = "十一月份";
            this.november.Name = "november";
            this.november.ReadOnly = true;
            // 
            // december
            // 
            this.december.DataPropertyName = "december";
            this.december.HeaderText = "十二月份";
            this.december.Name = "december";
            this.december.ReadOnly = true;
            // 
            // FrmProductionScheduleNeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 444);
            this.Controls.Add(this.dgv_need);
            this.Name = "FrmProductionScheduleNeed";
            this.Tag = "FrmProductionScheduleNeed";
            this.Text = "计划对应材料需求";
            this.Load += new System.EventHandler(this.FrmProductionScheduleNeed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_need)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_need;
        private System.Windows.Forms.DataGridViewTextBoxColumn mId;
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
    }
}