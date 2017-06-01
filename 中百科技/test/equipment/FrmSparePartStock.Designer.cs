namespace DasherStation.equipment
{
    partial class FrmSparePartStock
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQueryStr = new System.Windows.Forms.TextBox();
            this.cbxQuery = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtQueryStr);
            this.groupBox1.Controls.Add(this.cbxQuery);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(545, 22);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 11;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "查询条件";
            // 
            // txtQueryStr
            // 
            this.txtQueryStr.Location = new System.Drawing.Point(236, 23);
            this.txtQueryStr.Name = "txtQueryStr";
            this.txtQueryStr.Size = new System.Drawing.Size(121, 21);
            this.txtQueryStr.TabIndex = 9;
            this.txtQueryStr.Tag = "S";
            // 
            // cbxQuery
            // 
            this.cbxQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQuery.FormattingEnabled = true;
            this.cbxQuery.Items.AddRange(new object[] {
            "备件编号",
            "备件种类",
            "备件名称",
            "规格型号"});
            this.cbxQuery.Location = new System.Drawing.Point(93, 24);
            this.cbxQuery.Name = "cbxQuery";
            this.cbxQuery.Size = new System.Drawing.Size(121, 20);
            this.cbxQuery.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvDetail);
            this.groupBox2.Location = new System.Drawing.Point(3, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 341);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "备品配件信息";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.sort,
            this.name,
            this.model,
            this.unitPrice,
            this.quantity,
            this.totalPrice,
            this.inputMan,
            this.inputDate});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(636, 321);
            this.dgvDetail.TabIndex = 0;
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            this.no.HeaderText = "备件编号";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "备件种类";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "备件名称";
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
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            this.unitPrice.HeaderText = "单价";
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "库存数量";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // totalPrice
            // 
            this.totalPrice.DataPropertyName = "totalPrice";
            this.totalPrice.HeaderText = "总金额";
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.ReadOnly = true;
            // 
            // inputMan
            // 
            this.inputMan.DataPropertyName = "inputMan";
            this.inputMan.HeaderText = "录入人";
            this.inputMan.Name = "inputMan";
            this.inputMan.ReadOnly = true;
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.HeaderText = "录入时间";
            this.inputDate.Name = "inputDate";
            this.inputDate.ReadOnly = true;
            // 
            // FrmSparePartStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 418);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSparePartStock";
            this.Tag = "FrmSparePartStock";
            this.Text = "备品配件库存查询";
            this.Load += new System.EventHandler(this.FrmSparePartStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQueryStr;
        private System.Windows.Forms.ComboBox cbxQuery;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
    }
}