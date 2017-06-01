namespace DasherStation.transport
{
    partial class FrmTransportContract
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_stopDatail = new System.Windows.Forms.Button();
            this.dgv_transportGoodsInformationCorresponding = new System.Windows.Forms.DataGridView();
            this.did = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.site1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.site2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsmid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.markd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_transportContract = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_checkupMan = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_assessor = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbContractStatus = new System.Windows.Forms.ComboBox();
            this.txt_quertStr = new System.Windows.Forms.TextBox();
            this.btn_query = new System.Windows.Forms.Button();
            this.cmb_query = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transportGoodsInformationCorresponding)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transportContract)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 568);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_stopDatail);
            this.groupBox3.Controls.Add(this.dgv_transportGoodsInformationCorresponding);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(7, 294);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(784, 262);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "明细信息";
            // 
            // btn_stopDatail
            // 
            this.btn_stopDatail.Location = new System.Drawing.Point(10, 21);
            this.btn_stopDatail.Name = "btn_stopDatail";
            this.btn_stopDatail.Size = new System.Drawing.Size(75, 23);
            this.btn_stopDatail.TabIndex = 1;
            this.btn_stopDatail.Text = "终止明细";
            this.btn_stopDatail.UseVisualStyleBackColor = true;
            this.btn_stopDatail.Click += new System.EventHandler(this.btn_stopDatail_Click);
            // 
            // dgv_transportGoodsInformationCorresponding
            // 
            this.dgv_transportGoodsInformationCorresponding.AllowUserToAddRows = false;
            this.dgv_transportGoodsInformationCorresponding.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_transportGoodsInformationCorresponding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_transportGoodsInformationCorresponding.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.did,
            this.dataGridViewTextBoxColumn4,
            this.Column1,
            this.site1,
            this.site2,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.tsmid,
            this.markd,
            this.formula,
            this.tcId});
            this.dgv_transportGoodsInformationCorresponding.Location = new System.Drawing.Point(3, 50);
            this.dgv_transportGoodsInformationCorresponding.Name = "dgv_transportGoodsInformationCorresponding";
            this.dgv_transportGoodsInformationCorresponding.ReadOnly = true;
            this.dgv_transportGoodsInformationCorresponding.RowTemplate.Height = 23;
            this.dgv_transportGoodsInformationCorresponding.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_transportGoodsInformationCorresponding.Size = new System.Drawing.Size(775, 206);
            this.dgv_transportGoodsInformationCorresponding.TabIndex = 0;
            // 
            // did
            // 
            this.did.DataPropertyName = "id";
            this.did.HeaderText = "id";
            this.did.Name = "did";
            this.did.ReadOnly = true;
            this.did.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn4.HeaderText = "货物名称";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "model";
            this.Column1.HeaderText = "规格型号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // site1
            // 
            this.site1.DataPropertyName = "sid1";
            this.site1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.site1.HeaderText = "起运地";
            this.site1.Name = "site1";
            this.site1.ReadOnly = true;
            this.site1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.site1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // site2
            // 
            this.site2.DataPropertyName = "sid2";
            this.site2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.site2.HeaderText = "止运地";
            this.site2.Name = "site2";
            this.site2.ReadOnly = true;
            this.site2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.site2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "distance";
            this.dataGridViewTextBoxColumn7.HeaderText = "运输距离";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "price";
            this.dataGridViewTextBoxColumn8.HeaderText = "运输单价";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // tsmid
            // 
            this.tsmid.DataPropertyName = "tsmid";
            this.tsmid.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.tsmid.HeaderText = "结算方式";
            this.tsmid.Name = "tsmid";
            this.tsmid.ReadOnly = true;
            this.tsmid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tsmid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // markd
            // 
            this.markd.DataPropertyName = "mark";
            this.markd.HeaderText = "明细状态";
            this.markd.Name = "markd";
            this.markd.ReadOnly = true;
            // 
            // formula
            // 
            this.formula.DataPropertyName = "formula";
            this.formula.HeaderText = "formula";
            this.formula.Name = "formula";
            this.formula.ReadOnly = true;
            this.formula.Visible = false;
            // 
            // tcId
            // 
            this.tcId.DataPropertyName = "tcId";
            this.tcId.HeaderText = "tcId";
            this.tcId.Name = "tcId";
            this.tcId.ReadOnly = true;
            this.tcId.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgv_transportContract);
            this.groupBox2.Controls.Add(this.btn_checkupMan);
            this.groupBox2.Controls.Add(this.btn_close);
            this.groupBox2.Controls.Add(this.btn_assessor);
            this.groupBox2.Controls.Add(this.btn_new);
            this.groupBox2.Controls.Add(this.btn_stop);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox2.Location = new System.Drawing.Point(3, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(788, 231);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "合同信息";
            // 
            // dgv_transportContract
            // 
            this.dgv_transportContract.AllowUserToAddRows = false;
            this.dgv_transportContract.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_transportContract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_transportContract.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.parentId});
            this.dgv_transportContract.Location = new System.Drawing.Point(4, 49);
            this.dgv_transportContract.MultiSelect = false;
            this.dgv_transportContract.Name = "dgv_transportContract";
            this.dgv_transportContract.ReadOnly = true;
            this.dgv_transportContract.RowTemplate.Height = 23;
            this.dgv_transportContract.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_transportContract.Size = new System.Drawing.Size(778, 176);
            this.dgv_transportContract.TabIndex = 0;
            this.dgv_transportContract.SelectionChanged += new System.EventHandler(this.dgv_transportContract_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // parentId
            // 
            this.parentId.DataPropertyName = "parentId";
            this.parentId.HeaderText = "parentId";
            this.parentId.Name = "parentId";
            this.parentId.ReadOnly = true;
            this.parentId.Visible = false;
            // 
            // btn_checkupMan
            // 
            this.btn_checkupMan.Location = new System.Drawing.Point(315, 20);
            this.btn_checkupMan.Name = "btn_checkupMan";
            this.btn_checkupMan.Size = new System.Drawing.Size(75, 23);
            this.btn_checkupMan.TabIndex = 24;
            this.btn_checkupMan.Text = "审批";
            this.btn_checkupMan.UseVisualStyleBackColor = true;
            this.btn_checkupMan.Click += new System.EventHandler(this.btn_checkupMan_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(704, 20);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 14;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_assessor
            // 
            this.btn_assessor.Location = new System.Drawing.Point(224, 20);
            this.btn_assessor.Name = "btn_assessor";
            this.btn_assessor.Size = new System.Drawing.Size(75, 23);
            this.btn_assessor.TabIndex = 23;
            this.btn_assessor.Text = "审核";
            this.btn_assessor.UseVisualStyleBackColor = true;
            this.btn_assessor.Click += new System.EventHandler(this.btn_assessor_Click);
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(11, 20);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 18;
            this.btn_new.Text = "新建合同";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(92, 20);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 19;
            this.btn_stop.Text = "终止合同";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbContractStatus);
            this.groupBox1.Controls.Add(this.txt_quertStr);
            this.groupBox1.Controls.Add(this.btn_query);
            this.groupBox1.Controls.Add(this.cmb_query);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "合同状态";
            // 
            // cmbContractStatus
            // 
            this.cmbContractStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContractStatus.FormattingEnabled = true;
            this.cmbContractStatus.Items.AddRange(new object[] {
            "显示全部信息",
            "已终止合同",
            "未终止合同"});
            this.cmbContractStatus.Location = new System.Drawing.Point(68, 17);
            this.cmbContractStatus.Name = "cmbContractStatus";
            this.cmbContractStatus.Size = new System.Drawing.Size(121, 20);
            this.cmbContractStatus.TabIndex = 26;
            // 
            // txt_quertStr
            // 
            this.txt_quertStr.Location = new System.Drawing.Point(436, 17);
            this.txt_quertStr.Name = "txt_quertStr";
            this.txt_quertStr.Size = new System.Drawing.Size(100, 21);
            this.txt_quertStr.TabIndex = 21;
            this.txt_quertStr.Tag = "E";
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(542, 15);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 10;
            this.btn_query.Text = "搜索";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // cmb_query
            // 
            this.cmb_query.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_query.FormattingEnabled = true;
            this.cmb_query.Items.AddRange(new object[] {
            "无条件",
            "合同编号",
            "合同名称",
            "运输单位名称\t"});
            this.cmb_query.Location = new System.Drawing.Point(309, 17);
            this.cmb_query.Name = "cmb_query";
            this.cmb_query.Size = new System.Drawing.Size(121, 20);
            this.cmb_query.TabIndex = 7;
            this.cmb_query.SelectionChangeCommitted += new System.EventHandler(this.cmb_query_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "查询条件";
            // 
            // FrmTransportContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTransportContract";
            this.Tag = "FrmTransportContract";
            this.Text = "运输合同";
            this.Load += new System.EventHandler(this.FrmTransportContract_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transportGoodsInformationCorresponding)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transportContract)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_transportContract;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_transportGoodsInformationCorresponding;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_query;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_checkupMan;
        private System.Windows.Forms.Button btn_assessor;
        private System.Windows.Forms.TextBox txt_quertStr;
        private System.Windows.Forms.Button btn_stopDatail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbContractStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn did;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn site1;
        private System.Windows.Forms.DataGridViewComboBoxColumn site2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewComboBoxColumn tsmid;
        private System.Windows.Forms.DataGridViewTextBoxColumn markd;
        private System.Windows.Forms.DataGridViewTextBoxColumn formula;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcId;
    }
}