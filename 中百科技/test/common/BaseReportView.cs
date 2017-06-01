using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace DasherStation.common
{
    public  partial class BaseReportView : BaseForm
    {
        public BaseReportView()
        {
            InitializeComponent();
        }

        //List<ReportDataSource> reportDataSource;

        //public List<ReportDataSource> ReportDataSource
        //{
        //    get { return reportDataSource; }
        //    set { reportDataSource = value; }
        //}

        //private string reportResource;

        //public string ReportResource
        //{
        //    get { return reportResource; }
        //    set { reportResource = value; }
        //}

        private void BaseReportView_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        //protected virtual void DataFill()
        //{
        //    this.reportViewer1.LocalReport.ReportEmbeddedResource = reportResource;
        //}

        //protected void show()
        //{
        //   foreach(ReportDataSource rds in this.ReportDataSource)
        //   {
        //       this.reportViewer1.LocalReport.DataSources.Add(rds);
        //   }
        //   this.reportViewer1.RefreshReport();
        //}
    }
}
