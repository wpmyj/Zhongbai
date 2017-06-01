namespace DasherStation.transport.Report
{
    partial class ReportTest
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tranSport = new DasherStation.transport.TranSport();
            this.transportSettlementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transportSettlementTableAdapter = new DasherStation.transport.TranSportTableAdapters.transportSettlementTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tranSport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportSettlementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "TranSport_stockNote";
            reportDataSource1.Value = this.transportSettlementBindingSource;
            reportDataSource2.Name = "TranSport_consignmentNote";
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DasherStation.transport.Report.TransportSettlement.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(645, 412);
            this.reportViewer1.TabIndex = 0;
            // 
            // tranSport
            // 
            this.tranSport.DataSetName = "TranSport";
            this.tranSport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // transportSettlementBindingSource
            // 
            this.transportSettlementBindingSource.DataMember = "transportSettlement";
            this.transportSettlementBindingSource.DataSource = this.tranSport;
            // 
            // transportSettlementTableAdapter
            // 
            this.transportSettlementTableAdapter.ClearBeforeFill = true;
            // 
            // ReportTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 412);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportTest";
            this.Text = "ReportTest";
            this.Load += new System.EventHandler(this.ReportTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tranSport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportSettlementBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource transportSettlementBindingSource;
        private TranSport tranSport;
        private DasherStation.transport.TranSportTableAdapters.transportSettlementTableAdapter transportSettlementTableAdapter;
    }
}