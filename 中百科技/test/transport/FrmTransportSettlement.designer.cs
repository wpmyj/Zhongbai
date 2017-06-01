namespace DasherStation.transport
{
    partial class FrmTransportSettlement
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_query = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.运输结算单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运输结算统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_checkupMan = new System.Windows.Forms.Button();
            this.btn_assessor = new System.Windows.Forms.Button();
            this.btn_view = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_transportSettlement = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_quertStr = new System.Windows.Forms.TextBox();
            this.cmb_query = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transportSettlement)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(650, 13);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 14;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(6, 55);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 11;
            this.btn_new.Text = "新建核算单";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(347, 12);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 10;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_checkupMan);
            this.panel1.Controls.Add(this.btn_assessor);
            this.panel1.Controls.Add(this.btn_view);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btn_new);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 536);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.ContextMenuStrip = this.contextMenuStrip1;
            this.button1.Location = new System.Drawing.Point(330, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "打印";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.运输结算单ToolStripMenuItem,
            this.运输结算统计ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 48);
            // 
            // 运输结算单ToolStripMenuItem
            // 
            this.运输结算单ToolStripMenuItem.Name = "运输结算单ToolStripMenuItem";
            this.运输结算单ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.运输结算单ToolStripMenuItem.Text = "运输结算单";
            this.运输结算单ToolStripMenuItem.Click += new System.EventHandler(this.运输结算单ToolStripMenuItem_Click);
            // 
            // 运输结算统计ToolStripMenuItem
            // 
            this.运输结算统计ToolStripMenuItem.Name = "运输结算统计ToolStripMenuItem";
            this.运输结算统计ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.运输结算统计ToolStripMenuItem.Text = "运输结算统计";
            this.运输结算统计ToolStripMenuItem.Click += new System.EventHandler(this.运输结算统计ToolStripMenuItem_Click);
            // 
            // btn_checkupMan
            // 
            this.btn_checkupMan.Location = new System.Drawing.Point(249, 55);
            this.btn_checkupMan.Name = "btn_checkupMan";
            this.btn_checkupMan.Size = new System.Drawing.Size(75, 23);
            this.btn_checkupMan.TabIndex = 13;
            this.btn_checkupMan.Text = "审批";
            this.btn_checkupMan.UseVisualStyleBackColor = true;
            this.btn_checkupMan.Click += new System.EventHandler(this.btn_checkupMan_Click);
            // 
            // btn_assessor
            // 
            this.btn_assessor.Location = new System.Drawing.Point(168, 55);
            this.btn_assessor.Name = "btn_assessor";
            this.btn_assessor.Size = new System.Drawing.Size(75, 23);
            this.btn_assessor.TabIndex = 13;
            this.btn_assessor.Text = "审核";
            this.btn_assessor.UseVisualStyleBackColor = true;
            this.btn_assessor.Click += new System.EventHandler(this.btn_assessor_Click);
            // 
            // btn_view
            // 
            this.btn_view.Location = new System.Drawing.Point(87, 55);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(75, 23);
            this.btn_view.TabIndex = 12;
            this.btn_view.Text = "查看核算单";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgv_transportSettlement);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox2.Location = new System.Drawing.Point(6, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(731, 449);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "结算单信息";
            // 
            // dgv_transportSettlement
            // 
            this.dgv_transportSettlement.AllowUserToAddRows = false;
            this.dgv_transportSettlement.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_transportSettlement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_transportSettlement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_transportSettlement.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_transportSettlement.Location = new System.Drawing.Point(2, 20);
            this.dgv_transportSettlement.Name = "dgv_transportSettlement";
            this.dgv_transportSettlement.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_transportSettlement.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_transportSettlement.RowTemplate.Height = 23;
            this.dgv_transportSettlement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_transportSettlement.Size = new System.Drawing.Size(723, 420);
            this.dgv_transportSettlement.TabIndex = 0;
            this.dgv_transportSettlement.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_transportSettlement_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txt_quertStr);
            this.groupBox1.Controls.Add(this.btn_close);
            this.groupBox1.Controls.Add(this.btn_query);
            this.groupBox1.Controls.Add(this.cmb_query);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(731, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txt_quertStr
            // 
            this.txt_quertStr.Location = new System.Drawing.Point(220, 13);
            this.txt_quertStr.Name = "txt_quertStr";
            this.txt_quertStr.Size = new System.Drawing.Size(121, 21);
            this.txt_quertStr.TabIndex = 16;
            // 
            // cmb_query
            // 
            this.cmb_query.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_query.FormattingEnabled = true;
            this.cmb_query.Items.AddRange(new object[] {
            "全部",
            "合同编号",
            "合同名称",
            "运输商名称"});
            this.cmb_query.Location = new System.Drawing.Point(93, 14);
            this.cmb_query.Name = "cmb_query";
            this.cmb_query.Size = new System.Drawing.Size(121, 20);
            this.cmb_query.TabIndex = 7;
            this.cmb_query.TextChanged += new System.EventHandler(this.cmb_query_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询条件";
            // 
            // FrmTransportSettlement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 536);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTransportSettlement";
            this.Tag = "FrmTransportSettlement";
            this.Text = "运输核算";
            this.Load += new System.EventHandler(this.FrmTransportSettlement_Load);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transportSettlement)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_transportSettlement;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_query;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_quertStr;
        private System.Windows.Forms.Button btn_checkupMan;
        private System.Windows.Forms.Button btn_assessor;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 运输结算单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运输结算统计ToolStripMenuItem;


    }
}