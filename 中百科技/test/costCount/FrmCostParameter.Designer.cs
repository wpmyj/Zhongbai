namespace DasherStation.costCount
{
    partial class FrmCostParameter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSetParameters = new System.Windows.Forms.DataGridView();
            this.Pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perProductHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetParameters)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dgvSetParameters);
            this.groupBox1.Location = new System.Drawing.Point(6, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 314);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgvSetParameters
            // 
            this.dgvSetParameters.AllowUserToAddRows = false;
            this.dgvSetParameters.AllowUserToResizeColumns = false;
            this.dgvSetParameters.AllowUserToResizeRows = false;
            this.dgvSetParameters.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSetParameters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSetParameters.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSetParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSetParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pid,
            this.productName,
            this.perProductHours,
            this.id});
            this.dgvSetParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSetParameters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSetParameters.Location = new System.Drawing.Point(3, 17);
            this.dgvSetParameters.Name = "dgvSetParameters";
            this.dgvSetParameters.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSetParameters.RowHeadersWidth = 10;
            this.dgvSetParameters.RowTemplate.Height = 23;
            this.dgvSetParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSetParameters.Size = new System.Drawing.Size(401, 294);
            this.dgvSetParameters.TabIndex = 0;
            // 
            // Pid
            // 
            this.Pid.DataPropertyName = "Pid";
            this.Pid.HeaderText = "Pid";
            this.Pid.Name = "Pid";
            this.Pid.Visible = false;
            // 
            // productName
            // 
            this.productName.DataPropertyName = "productName";
            this.productName.HeaderText = "产品名称";
            this.productName.Name = "productName";
            this.productName.ReadOnly = true;
            this.productName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.productName.Width = 150;
            // 
            // perProductHours
            // 
            this.perProductHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.perProductHours.DataPropertyName = "perProductHours";
            dataGridViewCellStyle1.Format = "N2";
            this.perProductHours.DefaultCellStyle = dataGridViewCellStyle1;
            this.perProductHours.HeaderText = "单位产品工时";
            this.perProductHours.Name = "perProductHours";
            this.perProductHours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.perProductHours.Width = 150;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "说明";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "单位产品工时，即 生产每吨产品所用工时";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品参数设定，用于确定工时计算系数";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btnUse);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnOk);
            this.groupBox3.Location = new System.Drawing.Point(6, 368);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(407, 51);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnUse
            // 
            this.btnUse.Location = new System.Drawing.Point(326, 20);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(75, 23);
            this.btnUse.TabIndex = 2;
            this.btnUse.Text = "应用";
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(245, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(164, 20);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmCostParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 431);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "FrmCostParameter";
            this.Tag = "FrmCostParameter";
            this.Text = "产品工时参数设置";
            this.Load += new System.EventHandler(this.FrmCostParameter_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetParameters)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSetParameters;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn perProductHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}