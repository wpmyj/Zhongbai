using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Reflection;

namespace RDLCPrint
{
    public partial class ReportViewer : System.Windows.Forms.Form
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        private string m_ReportName = string.Empty;

        public string ReportName
        {
            get
            {
                return this.m_ReportName;
            }
            set
            {
                this.m_ReportName = value;
            }
        }

        /// <summary>
        /// DataSource of the Main Report
        /// </summary>
        private object m_MainDataSet = null;
        public object MainDataSet
        {
            get
            {
                return this.m_MainDataSet;
            }
            set
            {
                this.m_MainDataSet = value;
            }
        }

        /// <summary>
        /// DataSource of the DrillThrough Report
        /// </summary>
        private object m_DrillDataSet = null;
        public object DrillDataSet
        {
            get
            {
                return this.m_DrillDataSet;
            }
            set
            {
                this.m_DrillDataSet = value;
            }
        }
                
        //Report Path
        public string ReportPath
        {
            get
            {
                return this.rptViewer.LocalReport.ReportPath;
            }
            set
            {
                this.rptViewer.LocalReport.ReportPath = value;
            }
        }

        /// <summary>
        /// Data Source Name of the DrillThrough Report
        /// </summary>
        private string m_DrillDataSourceName = string.Empty;
        public string DrillDataSourceName
        {
            get
            {
                return this.m_DrillDataSourceName;
            }
            set
            {
                this.m_DrillDataSourceName = value;
            }
        }

        /// <summary>
        /// Data Source Name of the Main Report
        /// </summary>
        private string m_MainDataSourceName = string.Empty;
        public string MainDataSourceName
        {
            get
            {
                return this.m_MainDataSourceName;
            }
            set
            {
                this.m_MainDataSourceName = value;
            }
        }        

        /// <summary>
        /// Set the DataSource for the report using a strong-typed dataset
        /// Call it in Form_Load event
        /// </summary>
        private void AddReportDataSource(object ReportSource, string ReportDataSetName)
        {
            Type type = ReportSource.GetType();

            if (type == null)
            {
                MessageBox.Show("提示: \r\n   这是个无效类型!");
                return;
            }
            else
            {
                PropertyInfo[] picData = type.GetProperties();
                bool bolExist = false;
                foreach (PropertyInfo piData in picData)
                {
                    if (piData.Name == "Tables")
                    {
                        bolExist = true;

                        if (ReportDataSetName == string.Empty)
                        {
                            MessageBox.Show("提示: \r\n    数据集名称不能为空!");
                            return;
                        }

                        this.rptViewer.LocalReport.DataSources.Add(
                            new ReportDataSource(ReportDataSetName,
                            (piData.GetValue(ReportSource, null) as DataTableCollection)[0])
                            );
                        this.rptViewer.RefreshReport();

                        break;
                    }
                }

                if (!bolExist)
                {
                    MessageBox.Show("提示: \r\n   这是个无效类型!");
                    return;
                }
            }
        }       
        
        private void ReportViewer_Load(object sender, EventArgs e)
        {
            
            if (this.m_MainDataSet == null)
            {
                MessageBox.Show("提示: \r\n    数据集不能为空!");
                return;
            }
            else
                AddReportDataSource(this.m_MainDataSet, this.m_MainDataSourceName);

            PrintDocument pd = new PrintDocument();
        }      

        private void toolPrint_Click(object sender, EventArgs e)
        {
            //if (this.printDoc == null )
            //{
            //    this.printDoc = new EMFStreamPrintDocument(this.rptViewer.LocalReport, this.m_ReportName);
            //    if (this.printDoc.ErrorMessage != string.Empty)
            //    {
            //        MessageBox.Show("Report Viewer: \r\n    " + this.printDoc.ErrorMessage);
            //        this.printDoc = null;
            //        return;
            //    }
            //}

            //this.printDoc.Print();
            //this.printDoc = null;
            SunPrint();
        }
        public void SunPrint()
        {
            if (this.printDoc == null)
            {
                this.printDoc = new EMFStreamPrintDocument(this.rptViewer.LocalReport, this.m_ReportName);
                if (this.printDoc.ErrorMessage != string.Empty)
                {
                    MessageBox.Show("Report Viewer: \r\n    " + this.printDoc.ErrorMessage);
                    this.printDoc = null;
                    return;
                }
            }

            this.printDoc.Print();
            this.printDoc = null; 
        }
        private RDLCPrint.EMFStreamPrintDocument printDoc = null;
               
        private void toolPreview_Click(object sender, EventArgs e)
        {
            if (this.printDoc == null)
            {
                this.printDoc = new EMFStreamPrintDocument(this.rptViewer.LocalReport, this.m_ReportName);
                if (this.printDoc.ErrorMessage != string.Empty)
                {
                    MessageBox.Show("Report Viewer:\r\n    " + this.printDoc.ErrorMessage);
                    this.printDoc = null;
                    return;
                }
            }

            this.PreviewDialog.Document = this.printDoc;
            this.PreviewDialog.ShowDialog();
            this.printDoc = null;

        }

        private string GetTimeStamp()
        {
            string strRet = string.Empty;
            System.DateTime dtNow = System.DateTime.Now;
            strRet +=   dtNow.Year.ToString() +
                        dtNow.Month.ToString("00") +
                        dtNow.Day.ToString("00") +
                        dtNow.Hour.ToString("00") +
                        dtNow.Minute.ToString("00") +
                        dtNow.Second.ToString("00") +
                        System.DateTime.Now.Millisecond.ToString("000");
            return strRet;

        }

        private void toolExcel_Click(object sender, EventArgs e)
        {

            Microsoft.Reporting.WinForms.Warning[] Warnings;
            string[] strStreamIds;
            string strMimeType;
            string strEncoding;
            string strFileNameExtension;

            byte[] bytes = this.rptViewer.LocalReport.Render("Excel", null, out strMimeType, out strEncoding, out strFileNameExtension, out strStreamIds, out Warnings);

            string strFilePath = @"D:\" + this.GetTimeStamp() + ".xls";

            using (System.IO.FileStream fs = new FileStream(strFilePath, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            if (System.Windows.Forms.MessageBox.Show("提示: \r\n    输出 excel 文件!" + strFilePath + "\r\n    你是否想打开文件" + strFilePath + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(strFilePath);
            }

        }

        private void toolRefresh_Click(object sender, EventArgs e)
        {
            this.rptViewer.RefreshReport();
        }

        private void toolStop_Click(object sender, EventArgs e)
        {
            this.rptViewer.CancelRendering(0);
        }

        private void toolBack_Click(object sender, EventArgs e)
        {
            if (this.rptViewer.LocalReport.IsDrillthroughReport)
                this.rptViewer.PerformBack();
        }

        private void toolPageSettings_Click(object sender, EventArgs e)
        {
            frmPageSettings frm = new frmPageSettings(this.m_ReportName);
            frm.ShowDialog();
        }

        private void toolFirst_Click(object sender, EventArgs e)
        {
            this.rptViewer.CurrentPage = 1;
        }

        private void toolLast_Click(object sender, EventArgs e)
        {
            this.rptViewer.CurrentPage = this.rptViewer.LocalReport.GetTotalPages();
        }

        private void tool25_Click(object sender, EventArgs e)
        {
            this.rptViewer.ZoomMode = ZoomMode.Percent;
            this.rptViewer.ZoomPercent = 25;
        }

        private void tool50_Click(object sender, EventArgs e)
        {
            this.rptViewer.ZoomMode = ZoomMode.Percent;
            this.rptViewer.ZoomPercent = 50;
        }

        private void tool100_Click(object sender, EventArgs e)
        {
            this.rptViewer.ZoomMode = ZoomMode.Percent;
            this.rptViewer.ZoomPercent = 100;
        }

        private void tool200_Click(object sender, EventArgs e)
        {
            this.rptViewer.ZoomMode = ZoomMode.Percent;
            this.rptViewer.ZoomPercent = 200;
        }

        private void tool400_Click(object sender, EventArgs e)
        {
            this.rptViewer.ZoomMode = ZoomMode.Percent;
            this.rptViewer.ZoomPercent = 400;
        }

        private void toolWhole_Click(object sender, EventArgs e)
        {
            this.rptViewer.ZoomMode = ZoomMode.FullPage;
        }

        private void toolPageWidth_Click(object sender, EventArgs e)
        {
            this.rptViewer.ZoomMode = ZoomMode.PageWidth;
        }

        private void toolSearch_Click(object sender, EventArgs e)
        {
            if (this.txtSearch.Text.Trim() == string.Empty)
                return;

            this.rptViewer.Find(this.txtSearch.Text.Trim(), 1);
        }

        private void toolSearchNext_Click(object sender, EventArgs e)
        {
            if (this.txtSearch.Text.Trim() == string.Empty)
                return;

            this.rptViewer.FindNext();
        }

        private void toolPrevious_Click(object sender, EventArgs e)
        {
            if (this.rptViewer.CurrentPage != 1)
                this.rptViewer.CurrentPage--;
        }

        private void toolNext_Click(object sender, EventArgs e)
        {
            if (this.rptViewer.CurrentPage != this.rptViewer.LocalReport.GetTotalPages())
                this.rptViewer.CurrentPage++;
        }

        private void toolJump_Click(object sender, EventArgs e)
        {
            if (this.txtJump.Text.Trim() == string.Empty)
                return;

            int intJump = 0;

            if (System.Int32.TryParse(this.txtJump.Text.Trim(), out intJump))
                if (intJump <= this.rptViewer.LocalReport.GetTotalPages())
                    this.rptViewer.CurrentPage = intJump;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }


    }
}