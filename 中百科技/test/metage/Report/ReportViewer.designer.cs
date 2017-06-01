namespace RDLCPrint
{
    partial class ReportViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportViewer));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.TestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dnReport = new System.Windows.Forms.BindingNavigator(this.components);
            this.tspbPrint = new System.Windows.Forms.ToolStripSplitButton();
            this.toolPageSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStop = new System.Windows.Forms.ToolStripButton();
            this.toolBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExport = new System.Windows.Forms.ToolStripSplitButton();
            this.toolExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tspbZoom = new System.Windows.Forms.ToolStripSplitButton();
            this.tool25 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool50 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool200 = new System.Windows.Forms.ToolStripMenuItem();
            this.tool400 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolWhole = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPageWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.tspbSearch = new System.Windows.Forms.ToolStripSplitButton();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSearchNext = new System.Windows.Forms.ToolStripMenuItem();
            this.tspbNavigation = new System.Windows.Forms.ToolStripSplitButton();
            this.toolFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLast = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.toolNext = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolJump = new System.Windows.Forms.ToolStripMenuItem();
            this.txtJump = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.TestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dnReport)).BeginInit();
            this.dnReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // dnReport
            // 
            this.dnReport.AddNewItem = null;
            this.dnReport.CountItem = null;
            this.dnReport.DeleteItem = null;
            this.dnReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbPrint,
            this.toolStripSeparator1,
            this.toolRefresh,
            this.toolStop,
            this.toolBack,
            this.toolStripSeparator4,
            this.toolExport,
            this.toolStripSeparator5,
            this.tspbZoom,
            this.tspbSearch,
            this.tspbNavigation,
            this.toolStripButton1});
            this.dnReport.Location = new System.Drawing.Point(0, 0);
            this.dnReport.MoveFirstItem = null;
            this.dnReport.MoveLastItem = null;
            this.dnReport.MoveNextItem = null;
            this.dnReport.MovePreviousItem = null;
            this.dnReport.Name = "dnReport";
            this.dnReport.PositionItem = null;
            this.dnReport.Size = new System.Drawing.Size(641, 25);
            this.dnReport.TabIndex = 0;
            this.dnReport.Text = "bindingNavigator1";
            // 
            // tspbPrint
            // 
            this.tspbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspbPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolPageSettings,
            this.toolPreview,
            this.toolPrint});
            this.tspbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tspbPrint.Image")));
            this.tspbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbPrint.Name = "tspbPrint";
            this.tspbPrint.Size = new System.Drawing.Size(45, 22);
            this.tspbPrint.Text = "打印";
            // 
            // toolPageSettings
            // 
            this.toolPageSettings.Name = "toolPageSettings";
            this.toolPageSettings.Size = new System.Drawing.Size(152, 22);
            this.toolPageSettings.Text = "页面设置";
            this.toolPageSettings.Click += new System.EventHandler(this.toolPageSettings_Click);
            // 
            // toolPreview
            // 
            this.toolPreview.Name = "toolPreview";
            this.toolPreview.Size = new System.Drawing.Size(152, 22);
            this.toolPreview.Text = "预览";
            this.toolPreview.Click += new System.EventHandler(this.toolPreview_Click);
            // 
            // toolPrint
            // 
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(152, 22);
            this.toolPrint.Text = "打印";
            this.toolPrint.Click += new System.EventHandler(this.toolPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolRefresh
            // 
            this.toolRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRefresh.Name = "toolRefresh";
            this.toolRefresh.Size = new System.Drawing.Size(33, 22);
            this.toolRefresh.Text = "刷新";
            this.toolRefresh.Click += new System.EventHandler(this.toolRefresh_Click);
            // 
            // toolStop
            // 
            this.toolStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStop.Name = "toolStop";
            this.toolStop.Size = new System.Drawing.Size(33, 22);
            this.toolStop.Text = "停止";
            this.toolStop.Click += new System.EventHandler(this.toolStop_Click);
            // 
            // toolBack
            // 
            this.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBack.Name = "toolBack";
            this.toolBack.Size = new System.Drawing.Size(33, 22);
            this.toolBack.Text = "后退";
            this.toolBack.Click += new System.EventHandler(this.toolBack_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolExport
            // 
            this.toolExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolExcel});
            this.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExport.Name = "toolExport";
            this.toolExport.Size = new System.Drawing.Size(45, 22);
            this.toolExport.Text = "输出";
            // 
            // toolExcel
            // 
            this.toolExcel.Name = "toolExcel";
            this.toolExcel.Size = new System.Drawing.Size(136, 22);
            this.toolExcel.Text = "输出到Excel";
            this.toolExcel.Click += new System.EventHandler(this.toolExcel_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tspbZoom
            // 
            this.tspbZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspbZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool25,
            this.tool50,
            this.tool100,
            this.tool200,
            this.tool400,
            this.toolWhole,
            this.toolPageWidth});
            this.tspbZoom.Image = ((System.Drawing.Image)(resources.GetObject("tspbZoom.Image")));
            this.tspbZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbZoom.Name = "tspbZoom";
            this.tspbZoom.Size = new System.Drawing.Size(45, 22);
            this.tspbZoom.Text = "显示";
            // 
            // tool25
            // 
            this.tool25.Name = "tool25";
            this.tool25.Size = new System.Drawing.Size(130, 22);
            this.tool25.Text = "25%";
            this.tool25.Click += new System.EventHandler(this.tool25_Click);
            // 
            // tool50
            // 
            this.tool50.Name = "tool50";
            this.tool50.Size = new System.Drawing.Size(130, 22);
            this.tool50.Text = "50%";
            this.tool50.Click += new System.EventHandler(this.tool50_Click);
            // 
            // tool100
            // 
            this.tool100.Name = "tool100";
            this.tool100.Size = new System.Drawing.Size(130, 22);
            this.tool100.Text = "100%";
            this.tool100.Click += new System.EventHandler(this.tool100_Click);
            // 
            // tool200
            // 
            this.tool200.Name = "tool200";
            this.tool200.Size = new System.Drawing.Size(130, 22);
            this.tool200.Text = "200%";
            this.tool200.Click += new System.EventHandler(this.tool200_Click);
            // 
            // tool400
            // 
            this.tool400.Name = "tool400";
            this.tool400.Size = new System.Drawing.Size(130, 22);
            this.tool400.Text = "400%";
            this.tool400.Click += new System.EventHandler(this.tool400_Click);
            // 
            // toolWhole
            // 
            this.toolWhole.Name = "toolWhole";
            this.toolWhole.Size = new System.Drawing.Size(130, 22);
            this.toolWhole.Text = "&Whole Page";
            this.toolWhole.Click += new System.EventHandler(this.toolWhole_Click);
            // 
            // toolPageWidth
            // 
            this.toolPageWidth.Name = "toolPageWidth";
            this.toolPageWidth.Size = new System.Drawing.Size(130, 22);
            this.toolPageWidth.Text = "&Page Width";
            this.toolPageWidth.Click += new System.EventHandler(this.toolPageWidth_Click);
            // 
            // tspbSearch
            // 
            this.tspbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspbSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSearch,
            this.toolSearch,
            this.toolStripSeparator3,
            this.toolSearchNext});
            this.tspbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tspbSearch.Image")));
            this.tspbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbSearch.Name = "tspbSearch";
            this.tspbSearch.Size = new System.Drawing.Size(45, 22);
            this.tspbSearch.Text = "查找";
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 21);
            // 
            // toolSearch
            // 
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(160, 22);
            this.toolSearch.Text = "查找";
            this.toolSearch.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // toolSearchNext
            // 
            this.toolSearchNext.Name = "toolSearchNext";
            this.toolSearchNext.Size = new System.Drawing.Size(160, 22);
            this.toolSearchNext.Text = "查找下一个";
            this.toolSearchNext.Click += new System.EventHandler(this.toolSearchNext_Click);
            // 
            // tspbNavigation
            // 
            this.tspbNavigation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspbNavigation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFirst,
            this.toolLast,
            this.toolPrevious,
            this.toolNext,
            this.toolStripSeparator2,
            this.toolJump,
            this.txtJump});
            this.tspbNavigation.Image = ((System.Drawing.Image)(resources.GetObject("tspbNavigation.Image")));
            this.tspbNavigation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspbNavigation.Name = "tspbNavigation";
            this.tspbNavigation.Size = new System.Drawing.Size(45, 22);
            this.tspbNavigation.Text = "导航";
            // 
            // toolFirst
            // 
            this.toolFirst.Name = "toolFirst";
            this.toolFirst.Size = new System.Drawing.Size(178, 22);
            this.toolFirst.Text = "首页";
            this.toolFirst.Click += new System.EventHandler(this.toolFirst_Click);
            // 
            // toolLast
            // 
            this.toolLast.Name = "toolLast";
            this.toolLast.Size = new System.Drawing.Size(178, 22);
            this.toolLast.Text = "末页";
            this.toolLast.Click += new System.EventHandler(this.toolLast_Click);
            // 
            // toolPrevious
            // 
            this.toolPrevious.Name = "toolPrevious";
            this.toolPrevious.Size = new System.Drawing.Size(178, 22);
            this.toolPrevious.Text = "上页";
            this.toolPrevious.Click += new System.EventHandler(this.toolPrevious_Click);
            // 
            // toolNext
            // 
            this.toolNext.Name = "toolNext";
            this.toolNext.Size = new System.Drawing.Size(178, 22);
            this.toolNext.Text = "下页";
            this.toolNext.Click += new System.EventHandler(this.toolNext_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // toolJump
            // 
            this.toolJump.Name = "toolJump";
            this.toolJump.Size = new System.Drawing.Size(178, 22);
            this.toolJump.Text = "Jump to Specific：";
            this.toolJump.Click += new System.EventHandler(this.toolJump_Click);
            // 
            // txtJump
            // 
            this.txtJump.Name = "txtJump";
            this.txtJump.Size = new System.Drawing.Size(100, 21);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "dsTest_Test";
            reportDataSource3.Value = this.TestBindingSource;
            this.rptViewer.LocalReport.DataSources.Add(reportDataSource3);
            this.rptViewer.LocalReport.ReportEmbeddedResource = "ReportProject.Report1.rdlc";
            this.rptViewer.Location = new System.Drawing.Point(0, 25);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ShowToolBar = false;
            this.rptViewer.Size = new System.Drawing.Size(641, 486);
            this.rptViewer.TabIndex = 1;
            // 
            // PreviewDialog
            // 
            this.PreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.PreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.PreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.PreviewDialog.Enabled = true;
            this.PreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("PreviewDialog.Icon")));
            this.PreviewDialog.Name = "printPreviewDialog1";
            this.PreviewDialog.Visible = false;
            // 
            // ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 511);
            this.Controls.Add(this.rptViewer);
            this.Controls.Add(this.dnReport);
            this.Name = "ReportViewer";
            this.Text = "报表打印";
            this.Load += new System.EventHandler(this.ReportViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dnReport)).EndInit();
            this.dnReport.ResumeLayout(false);
            this.dnReport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator dnReport;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
        private System.Windows.Forms.PrintPreviewDialog PreviewDialog;
        private System.Windows.Forms.ToolStripSplitButton toolExport;
        private System.Windows.Forms.ToolStripMenuItem toolExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStop;
        private System.Windows.Forms.ToolStripSplitButton tspbNavigation;
        private System.Windows.Forms.ToolStripMenuItem toolFirst;
        private System.Windows.Forms.ToolStripMenuItem toolLast;
        private System.Windows.Forms.ToolStripMenuItem toolPrevious;
        private System.Windows.Forms.ToolStripMenuItem toolNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolJump;
        private System.Windows.Forms.ToolStripTextBox txtJump;
        private System.Windows.Forms.ToolStripSplitButton tspbSearch;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripMenuItem toolSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolSearchNext;
        private System.Windows.Forms.ToolStripSplitButton tspbZoom;
        private System.Windows.Forms.ToolStripMenuItem tool25;
        private System.Windows.Forms.ToolStripMenuItem tool50;
        private System.Windows.Forms.ToolStripMenuItem tool100;
        private System.Windows.Forms.ToolStripMenuItem tool200;
        private System.Windows.Forms.ToolStripMenuItem tool400;
        private System.Windows.Forms.ToolStripSplitButton tspbPrint;
        private System.Windows.Forms.ToolStripMenuItem toolPageSettings;
        private System.Windows.Forms.ToolStripMenuItem toolPreview;
        private System.Windows.Forms.ToolStripMenuItem toolPrint;
        private System.Windows.Forms.ToolStripMenuItem toolWhole;
        private System.Windows.Forms.ToolStripMenuItem toolPageWidth;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.BindingSource TestBindingSource;       

    }
}