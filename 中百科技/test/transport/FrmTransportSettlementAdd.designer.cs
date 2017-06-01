namespace DasherStation.transport
{
    partial class FrmTransportSettlementAdd
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
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_transportContract = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_noteCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_priceTotal = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_suttleTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_note = new System.Windows.Forms.DataGridView();
            this.did = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sid1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sid2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.suttle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_transportGoodsInformationCorresponding = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.site1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.site2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsmid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_note)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transportGoodsInformationCorresponding)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txt_code);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_transportContract);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 49);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(302, 16);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(200, 21);
            this.txt_code.TabIndex = 4;
            this.txt_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_code_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "合同名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "票据条码";
            // 
            // cmb_transportContract
            // 
            this.cmb_transportContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_transportContract.FormattingEnabled = true;
            this.cmb_transportContract.Location = new System.Drawing.Point(76, 17);
            this.cmb_transportContract.Name = "cmb_transportContract";
            this.cmb_transportContract.Size = new System.Drawing.Size(149, 20);
            this.cmb_transportContract.TabIndex = 1;
            this.cmb_transportContract.SelectionChangeCommitted += new System.EventHandler(this.cmb_transportContract_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // txt_noteCount
            // 
            this.txt_noteCount.Enabled = false;
            this.txt_noteCount.Location = new System.Drawing.Point(626, 17);
            this.txt_noteCount.Name = "txt_noteCount";
            this.txt_noteCount.Size = new System.Drawing.Size(100, 21);
            this.txt_noteCount.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(567, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "票据总数";
            // 
            // txt_priceTotal
            // 
            this.txt_priceTotal.Enabled = false;
            this.txt_priceTotal.Location = new System.Drawing.Point(344, 17);
            this.txt_priceTotal.Name = "txt_priceTotal";
            this.txt_priceTotal.Size = new System.Drawing.Size(100, 21);
            this.txt_priceTotal.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txt_noteCount);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txt_priceTotal);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txt_suttleTotal);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 512);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(736, 47);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "总重量";
            // 
            // txt_suttleTotal
            // 
            this.txt_suttleTotal.Enabled = false;
            this.txt_suttleTotal.Location = new System.Drawing.Point(76, 17);
            this.txt_suttleTotal.Name = "txt_suttleTotal";
            this.txt_suttleTotal.Size = new System.Drawing.Size(100, 21);
            this.txt_suttleTotal.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "总金额";
            // 
            // dgv_note
            // 
            this.dgv_note.AllowUserToAddRows = false;
            this.dgv_note.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_note.BackgroundColor = System.Drawing.Color.White;
            this.dgv_note.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_note.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.did,
            this.inputDate,
            this.barcode,
            this.name,
            this.model,
            this.sid1,
            this.sid2,
            this.suttle,
            this.mark,
            this.mid,
            this.pid});
            this.dgv_note.Location = new System.Drawing.Point(3, 17);
            this.dgv_note.Name = "dgv_note";
            this.dgv_note.ReadOnly = true;
            this.dgv_note.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_note.RowHeadersWidth = 20;
            this.dgv_note.RowTemplate.Height = 23;
            this.dgv_note.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_note.Size = new System.Drawing.Size(730, 260);
            this.dgv_note.TabIndex = 4;
            // 
            // did
            // 
            this.did.DataPropertyName = "did";
            this.did.HeaderText = "id";
            this.did.Name = "did";
            this.did.ReadOnly = true;
            this.did.Visible = false;
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.HeaderText = "录入时间";
            this.inputDate.Name = "inputDate";
            this.inputDate.ReadOnly = true;
            // 
            // barcode
            // 
            this.barcode.DataPropertyName = "barcode";
            this.barcode.HeaderText = "条码信息";
            this.barcode.Name = "barcode";
            this.barcode.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "货物名称";
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
            // sid1
            // 
            this.sid1.DataPropertyName = "sid1";
            this.sid1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.sid1.HeaderText = "起运地";
            this.sid1.Name = "sid1";
            this.sid1.ReadOnly = true;
            this.sid1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sid1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // sid2
            // 
            this.sid2.DataPropertyName = "sid2";
            this.sid2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.sid2.HeaderText = "止运地";
            this.sid2.Name = "sid2";
            this.sid2.ReadOnly = true;
            this.sid2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sid2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // suttle
            // 
            this.suttle.DataPropertyName = "suttle";
            this.suttle.HeaderText = "货物净重";
            this.suttle.Name = "suttle";
            this.suttle.ReadOnly = true;
            // 
            // mark
            // 
            this.mark.DataPropertyName = "mark";
            this.mark.HeaderText = "mark";
            this.mark.Name = "mark";
            this.mark.ReadOnly = true;
            this.mark.Visible = false;
            // 
            // mid
            // 
            this.mid.DataPropertyName = "mid";
            this.mid.HeaderText = "mid";
            this.mid.Name = "mid";
            this.mid.ReadOnly = true;
            this.mid.Visible = false;
            // 
            // pid
            // 
            this.pid.DataPropertyName = "pid";
            this.pid.HeaderText = "pid";
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            this.pid.Visible = false;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(662, 565);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 32);
            this.btn_ok.TabIndex = 10;
            this.btn_ok.Text = "票据结算";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgv_transportGoodsInformationCorresponding);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(12, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 164);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "合同明细";
            // 
            // dgv_transportGoodsInformationCorresponding
            // 
            this.dgv_transportGoodsInformationCorresponding.AllowUserToAddRows = false;
            this.dgv_transportGoodsInformationCorresponding.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_transportGoodsInformationCorresponding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_transportGoodsInformationCorresponding.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.dataGridViewTextBoxColumn4,
            this.Column1,
            this.site1,
            this.site2,
            this.distance,
            this.price,
            this.tsmid,
            this.formula,
            this.weightTotal,
            this.priceTotal,
            this.Column2});
            this.dgv_transportGoodsInformationCorresponding.Location = new System.Drawing.Point(3, 13);
            this.dgv_transportGoodsInformationCorresponding.MultiSelect = false;
            this.dgv_transportGoodsInformationCorresponding.Name = "dgv_transportGoodsInformationCorresponding";
            this.dgv_transportGoodsInformationCorresponding.ReadOnly = true;
            this.dgv_transportGoodsInformationCorresponding.RowTemplate.Height = 23;
            this.dgv_transportGoodsInformationCorresponding.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_transportGoodsInformationCorresponding.Size = new System.Drawing.Size(730, 145);
            this.dgv_transportGoodsInformationCorresponding.TabIndex = 1;
            this.dgv_transportGoodsInformationCorresponding.SelectionChanged += new System.EventHandler(this.dgv_transportGoodsInformationCorresponding_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn4.HeaderText = "货物名称";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 76;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "model";
            this.Column1.HeaderText = "规格型号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 77;
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
            this.site1.Width = 76;
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
            this.site2.Width = 76;
            // 
            // distance
            // 
            this.distance.DataPropertyName = "distance";
            this.distance.HeaderText = "运输距离";
            this.distance.Name = "distance";
            this.distance.ReadOnly = true;
            this.distance.Width = 77;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "运输单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 76;
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
            this.tsmid.Width = 76;
            // 
            // formula
            // 
            this.formula.DataPropertyName = "formula";
            this.formula.HeaderText = "计算公式";
            this.formula.Name = "formula";
            this.formula.ReadOnly = true;
            this.formula.Visible = false;
            // 
            // weightTotal
            // 
            this.weightTotal.HeaderText = "总重";
            this.weightTotal.Name = "weightTotal";
            this.weightTotal.ReadOnly = true;
            this.weightTotal.Width = 77;
            // 
            // priceTotal
            // 
            this.priceTotal.HeaderText = "总价";
            this.priceTotal.Name = "priceTotal";
            this.priceTotal.ReadOnly = true;
            this.priceTotal.Width = 76;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "mark";
            this.Column2.HeaderText = "状态";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.dgv_note);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox4.Location = new System.Drawing.Point(12, 229);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(736, 294);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "小票信息";
            // 
            // FrmTransportSettlementAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 607);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Name = "FrmTransportSettlementAdd";
            this.Tag = "FrmTransportSettlementAdd";
            this.Text = "新建核算单";
            this.Load += new System.EventHandler(this.FrmTransportSettlementAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_note)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_transportGoodsInformationCorresponding)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_transportContract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_noteCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_priceTotal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_suttleTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_note;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgv_transportGoodsInformationCorresponding;
        private System.Windows.Forms.DataGridViewTextBoxColumn did;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewComboBoxColumn sid1;
        private System.Windows.Forms.DataGridViewComboBoxColumn sid2;
        private System.Windows.Forms.DataGridViewTextBoxColumn suttle;
        private System.Windows.Forms.DataGridViewTextBoxColumn mark;
        private System.Windows.Forms.DataGridViewTextBoxColumn mid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn site1;
        private System.Windows.Forms.DataGridViewComboBoxColumn site2;
        private System.Windows.Forms.DataGridViewTextBoxColumn distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewComboBoxColumn tsmid;
        private System.Windows.Forms.DataGridViewTextBoxColumn formula;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;


    }
}