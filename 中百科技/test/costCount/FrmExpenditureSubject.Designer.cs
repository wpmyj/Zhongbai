namespace DasherStation.costCount
{
    partial class FrmExpenditureSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExpenditureSubject));
            this.treevEditSubject = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddChildSubject = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treevEditSubject
            // 
            this.treevEditSubject.ImageIndex = 0;
            this.treevEditSubject.ImageList = this.imageList1;
            this.treevEditSubject.Location = new System.Drawing.Point(12, 35);
            this.treevEditSubject.Name = "treevEditSubject";
            this.treevEditSubject.SelectedImageIndex = 0;
            this.treevEditSubject.Size = new System.Drawing.Size(456, 300);
            this.treevEditSubject.TabIndex = 0;
            this.treevEditSubject.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treevEditSubject_AfterSelect_1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "treebmp1.bmp");
            this.imageList1.Images.SetKeyName(1, "treebmp2.bmp");
            this.imageList1.Images.SetKeyName(2, "treebmp3.bmp");
            this.imageList1.Images.SetKeyName(3, "treebmp4.bmp");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择要编辑的科目";
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(71, 367);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(397, 21);
            this.txtSubjectName.TabIndex = 2;
            this.txtSubjectName.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "科目名称";
            // 
            // btnAddChildSubject
            // 
            this.btnAddChildSubject.BackColor = System.Drawing.Color.Transparent;
            this.btnAddChildSubject.Location = new System.Drawing.Point(129, 338);
            this.btnAddChildSubject.Name = "btnAddChildSubject";
            this.btnAddChildSubject.Size = new System.Drawing.Size(103, 23);
            this.btnAddChildSubject.TabIndex = 5;
            this.btnAddChildSubject.Text = "添加子科目";
            this.btnAddChildSubject.UseVisualStyleBackColor = false;
            this.btnAddChildSubject.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Location = new System.Drawing.Point(375, 404);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "关闭";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.Location = new System.Drawing.Point(363, 338);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(103, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "删除";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(12, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "添加科目";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.Transparent;
            this.btnModify.Location = new System.Drawing.Point(246, 338);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(103, 23);
            this.btnModify.TabIndex = 8;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmExpenditureSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 439);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAddChildSubject);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treevEditSubject);
            this.Name = "FrmExpenditureSubject";
            this.Tag = "FrmExpenditureSubject";
            this.Text = "费用科目维护";
            this.Load += new System.EventHandler(this.FrmExpenditureSubject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treevEditSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddChildSubject;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.ImageList imageList1;
    }
}