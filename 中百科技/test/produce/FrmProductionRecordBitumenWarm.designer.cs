namespace DasherStation.produce
{
    partial class FrmProductionRecordBitumenWarm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_weather = new System.Windows.Forms.TextBox();
            this.dtp_startMachineTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_stopMachineTime = new System.Windows.Forms.DateTimePicker();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_produceTeam = new System.Windows.Forms.ComboBox();
            this.label61 = new System.Windows.Forms.Label();
            this.cmb_personnelInfo = new System.Windows.Forms.ComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.dtp_produceDate = new System.Windows.Forms.DateTimePicker();
            this.cmb_equipmentInfo = new System.Windows.Forms.ComboBox();
            this.label60 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txt_weather);
            this.groupBox2.Controls.Add(this.dtp_startMachineTime);
            this.groupBox2.Controls.Add(this.dtp_stopMachineTime);
            this.groupBox2.Controls.Add(this.btn_close);
            this.groupBox2.Controls.Add(this.btn_save);
            this.groupBox2.Controls.Add(this.txt_remark);
            this.groupBox2.Controls.Add(this.label57);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmb_produceTeam);
            this.groupBox2.Controls.Add(this.label61);
            this.groupBox2.Controls.Add(this.cmb_personnelInfo);
            this.groupBox2.Controls.Add(this.label55);
            this.groupBox2.Controls.Add(this.label56);
            this.groupBox2.Controls.Add(this.dtp_produceDate);
            this.groupBox2.Controls.Add(this.cmb_equipmentInfo);
            this.groupBox2.Controls.Add(this.label60);
            this.groupBox2.Location = new System.Drawing.Point(3, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 175);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txt_weather
            // 
            this.txt_weather.Location = new System.Drawing.Point(68, 102);
            this.txt_weather.Name = "txt_weather";
            this.txt_weather.Size = new System.Drawing.Size(123, 21);
            this.txt_weather.TabIndex = 74;
            this.txt_weather.Tag = "S";
            // 
            // dtp_startMachineTime
            // 
            this.dtp_startMachineTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_startMachineTime.Location = new System.Drawing.Point(68, 48);
            this.dtp_startMachineTime.Name = "dtp_startMachineTime";
            this.dtp_startMachineTime.Size = new System.Drawing.Size(123, 21);
            this.dtp_startMachineTime.TabIndex = 73;
            // 
            // dtp_stopMachineTime
            // 
            this.dtp_stopMachineTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_stopMachineTime.Location = new System.Drawing.Point(303, 48);
            this.dtp_stopMachineTime.Name = "dtp_stopMachineTime";
            this.dtp_stopMachineTime.Size = new System.Drawing.Size(123, 21);
            this.dtp_stopMachineTime.TabIndex = 72;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(351, 138);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 70;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(259, 138);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 69;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_remark
            // 
            this.txt_remark.Location = new System.Drawing.Point(303, 102);
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(123, 21);
            this.txt_remark.TabIndex = 68;
            this.txt_remark.Tag = "S";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(9, 52);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(53, 12);
            this.label57.TabIndex = 55;
            this.label57.Text = "开机时间";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(245, 52);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(53, 12);
            this.label58.TabIndex = 56;
            this.label58.Text = "停机时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 66;
            this.label2.Text = "天气情况";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 64;
            this.label1.Text = "备注";
            // 
            // cmb_produceTeam
            // 
            this.cmb_produceTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_produceTeam.FormattingEnabled = true;
            this.cmb_produceTeam.Location = new System.Drawing.Point(68, 75);
            this.cmb_produceTeam.Name = "cmb_produceTeam";
            this.cmb_produceTeam.Size = new System.Drawing.Size(123, 20);
            this.cmb_produceTeam.TabIndex = 63;
            this.cmb_produceTeam.Tag = "E";
            this.cmb_produceTeam.SelectionChangeCommitted += new System.EventHandler(this.cmb_produceTeam_SelectionChangeCommitted);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(10, 78);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(53, 12);
            this.label61.TabIndex = 62;
            this.label61.Text = "生产班组";
            // 
            // cmb_personnelInfo
            // 
            this.cmb_personnelInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_personnelInfo.FormattingEnabled = true;
            this.cmb_personnelInfo.Location = new System.Drawing.Point(303, 75);
            this.cmb_personnelInfo.Name = "cmb_personnelInfo";
            this.cmb_personnelInfo.Size = new System.Drawing.Size(123, 20);
            this.cmb_personnelInfo.TabIndex = 61;
            this.cmb_personnelInfo.Tag = "E";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(245, 78);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(41, 12);
            this.label55.TabIndex = 60;
            this.label55.Text = "负责人";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(10, 24);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(53, 12);
            this.label56.TabIndex = 54;
            this.label56.Text = "生产日期";
            // 
            // dtp_produceDate
            // 
            this.dtp_produceDate.Location = new System.Drawing.Point(68, 20);
            this.dtp_produceDate.Name = "dtp_produceDate";
            this.dtp_produceDate.Size = new System.Drawing.Size(123, 21);
            this.dtp_produceDate.TabIndex = 57;
            // 
            // cmb_equipmentInfo
            // 
            this.cmb_equipmentInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_equipmentInfo.FormattingEnabled = true;
            this.cmb_equipmentInfo.Location = new System.Drawing.Point(303, 21);
            this.cmb_equipmentInfo.Name = "cmb_equipmentInfo";
            this.cmb_equipmentInfo.Size = new System.Drawing.Size(123, 20);
            this.cmb_equipmentInfo.TabIndex = 52;
            this.cmb_equipmentInfo.Tag = "E";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(245, 24);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(53, 12);
            this.label60.TabIndex = 50;
            this.label60.Text = "设备名称";
            // 
            // FrmProductionRecordBitumenWarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 181);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmProductionRecordBitumenWarm";
            this.Tag = "FrmProductionRecordBitumenWarm";
            this.Text = "沥青加温生产记录";
            this.Load += new System.EventHandler(this.FrmProductionRecordBitumenWarm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_produceTeam;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.ComboBox cmb_personnelInfo;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.DateTimePicker dtp_produceDate;
        private System.Windows.Forms.ComboBox cmb_equipmentInfo;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.DateTimePicker dtp_stopMachineTime;
        private System.Windows.Forms.DateTimePicker dtp_startMachineTime;
        private System.Windows.Forms.TextBox txt_weather;
    }
}