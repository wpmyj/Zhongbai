using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Reflection;

namespace DasherStation.common
{
    public class ReportServer
    {

        Assembly a;
        Type t;
        public void ShowReport(string DataSetName, string DataAdapterName,string DataTableName,string ReportName,string DataSourceName,long pid)
        {
            a = Assembly.GetExecutingAssembly();

            t = a.GetType(DataSetName);

            Type sda = a.GetType(DataAdapterName);

            object DataSetObj = Activator.CreateInstance(t);

            object obj = Activator.CreateInstance(sda);

            MethodInfo mi = sda.GetMethod("Fill");

            object DataOjb = t.GetProperty(DataTableName).GetValue(DataSetObj, null);

            object[] para = { DataOjb };

            mi.Invoke(obj, para);

            ShowReport(DataSetObj, sda, DataTableName, ReportName, DataSourceName, pid);
        }

        public void ShowReport(object DataSetObj, object DataAdapterObj, string DataTableName, string ReportName, string DataSourceName, long pid)
        {
            BaseReportView frmReport = new BaseReportView();

            BindingSource ReportBindingSource = new BindingSource();

            ReportBindingSource.DataSource = DataSetObj;
            ReportBindingSource.DataMember = DataTableName;

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = DataSourceName;
            reportDataSource.Value = ReportBindingSource;

            frmReport.ReportResource = ReportName;

            frmReport.ReportDataSource = new List<ReportDataSource>() { reportDataSource };

            frmReport.Show();

        }
    }
}
