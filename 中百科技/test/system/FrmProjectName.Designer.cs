namespace DasherStation.system
{
    partial class FrmProjectName
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
            this.btn_edit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_position = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_subsectionProject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_unitProject = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_itemProject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_no = new System.Windows.Forms.TextBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.dgv_warehouseInfo = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subsectionProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_query = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.cmb_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_warehouseInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(216, 78);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(50, 23);
            this.btn_edit.TabIndex = 8;
            this.btn_edit.Text = "更新";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Visible = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_position);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_subsectionProject);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_unitProject);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_itemProject);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_no);
            this.groupBox1.Controls.Add(this.btn_edit);
            this.groupBox1.Controls.Add(this.btn_exit);
            this.groupBox1.Controls.Add(this.btn_del);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工程项目信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "工程部位";
            // 
            // txt_position
            // 
            this.txt_position.Location = new System.Drawing.Point(399, 47);
            this.txt_position.Name = "txt_position";
            this.txt_position.Size = new System.Drawing.Size(87, 21);
            this.txt_position.TabIndex = 5;
            this.txt_position.Tag = "S";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "工程名称";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(237, 16);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(87, 21);
            this.txt_name.TabIndex = 1;
            this.txt_name.Tag = "ES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "分部工程";
            // 
            // txt_subsectionProject
            // 
            this.txt_subsectionProject.Location = new System.Drawing.Point(73, 47);
            this.txt_subsectionProject.Name = "txt_subsectionProject";
            this.txt_subsectionProject.Size = new System.Drawing.Size(87, 21);
            this.txt_subsectionProject.TabIndex = 3;
            this.txt_subsectionProject.Tag = "S";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "单位工程";
            // 
            // txt_unitProject
            // 
            this.txt_unitProject.Location = new System.Drawing.Point(399, 16);
            this.txt_unitProject.Name = "txt_unitProject";
            this.txt_unitProject.Size = new System.Drawing.Size(87, 21);
            this.txt_unitProject.TabIndex = 2;
            this.txt_unitProject.Tag = "S";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "分项工程";
            // 
            // txt_itemProject
            // 
            this.txt_itemProject.Location = new System.Drawing.Point(237, 47);
            this.txt_itemProject.Name = "txt_itemProject";
            this.txt_itemProject.Size = new System.Drawing.Size(87, 21);
            this.txt_itemProject.TabIndex = 4;
            this.txt_itemProject.Tag = "S";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "工程编号";
            // 
            // txt_no
            // 
            this.txt_no.Location = new System.Drawing.Point(73, 16);
            this.txt_no.Name = "txt_no";
            this.txt_no.Size = new System.Drawing.Size(87, 21);
            this.txt_no.TabIndex = 0;
            this.txt_no.Tag = "ES";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(446, 78);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(50, 23);
            this.btn_exit.TabIndex = 8;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(75, 76);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(50, 23);
            this.btn_del.TabIndex = 7;
            this.btn_del.Text = "删除";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(9, 76);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(50, 23);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // dgv_warehouseInfo
            // 
            this.dgv_warehouseInfo.AllowUserToAddRows = false;
            this.dgv_warehouseInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_warehouseInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.no,
            this.name,
            this.unitProject,
            this.subsectionProject,
            this.itemProject,
            this.position,
            this.inputMan,
            this.inputDate});
            this.dgv_warehouseInfo.Location = new System.Drawing.Point(12, 178);
            this.dgv_warehouseInfo.Name = "dgv_warehouseInfo";
            this.dgv_warehouseInfo.ReadOnly = true;
            this.dgv_warehouseInfo.RowTemplate.Height = 23;
            this.dgv_warehouseInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_warehouseInfo.Size = new System.Drawing.Size(484, 279);
            this.dgv_warehouseInfo.TabIndex = 5;
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
            this.no.HeaderText = "工程编号";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "工程名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // unitProject
            // 
            this.unitProject.DataPropertyName = "unitProject";
            this.unitProject.HeaderText = "单位工程";
            this.unitProject.Name = "unitProject";
            this.unitProject.ReadOnly = true;
            // 
            // subsectionProject
            // 
            this.subsectionProject.DataPropertyName = "subsectionProject";
            this.subsectionProject.HeaderText = "分部工程";
            this.subsectionProject.Name = "subsectionProject";
            this.subsectionProject.ReadOnly = true;
            // 
            // itemProject
            // 
            this.itemProject.DataPropertyName = "itemProject";
            this.itemProject.HeaderText = "分项工程";
            this.itemProject.Name = "itemProject";
            this.itemProject.ReadOnly = true;
            // 
            // position
            // 
            this.position.DataPropertyName = "position";
            this.position.HeaderText = "工程部位";
            this.position.Name = "position";
            this.position.ReadOnly = true;
            // 
            // inputMan
            // 
            this.inputMan.DataPropertyName = "inputMan";
            this.inputMan.HeaderText = "inputMan";
            this.inputMan.Name = "inputMan";
            this.inputMan.ReadOnly = true;
            this.inputMan.Visible = false;
            // 
            // inputDate
            // 
            this.inputDate.DataPropertyName = "inputDate";
            this.inputDate.HeaderText = "inputDate";
            this.inputDate.Name = "inputDate";
            this.inputDate.ReadOnly = true;
            this.inputDate.Visible = false;
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(352, 22);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(50, 23);
            this.btn_query.TabIndex = 8;
            this.btn_query.Text = "搜索";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(216, 22);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(108, 21);
            this.txt_search.TabIndex = 1;
            this.txt_search.Tag = "ES";
            // 
            // cmb_type
            // 
            this.cmb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_type.FormattingEnabled = true;
            this.cmb_type.Items.AddRange(new object[] {
            "全部"});
            this.cmb_type.Location = new System.Drawing.Point(73, 22);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(116, 20);
            this.cmb_type.TabIndex = 0;
            this.cmb_type.Tag = "E";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "查询条件";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btn_query);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmb_type);
            this.groupBox2.Controls.Add(this.txt_search);
            this.groupBox2.Location = new System.Drawing.Point(0, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // FrmProjectName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 469);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_warehouseInfo);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmProjectName";
            this.Tag = "FrmProjectName";
            this.Text = "工程项目";
            this.Load += new System.EventHandler(this.FrmProjectName_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_warehouseInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_subsectionProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_unitProject;
        private System.Windows.Forms.DataGridView dgv_warehouseInfo;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.ComboBox cmb_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_position;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_itemProject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn subsectionProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDate;

    }
}