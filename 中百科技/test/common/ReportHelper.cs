using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Reflection;
using System.Data;

namespace DasherStation.common
{
    public class ReportHelper
    {

        Assembly a= Assembly.GetExecutingAssembly();

        public void ShowReport(ReportData reportData)
        {
            BaseReportView frmReport = new BaseReportView();
            List<ReportDataSource> reportDataSource = CreatReportDataSource(reportData);
            foreach (ReportDataSource rds in reportDataSource)
            {
                frmReport.reportViewer1.LocalReport.DataSources.Add(rds);
            }
            frmReport.reportViewer1.LocalReport.ReportEmbeddedResource = reportData.ReportName;

            List<ReportParameter> paraList = new List<ReportParameter>();

            foreach (ReportParameterInfo rpi in frmReport.reportViewer1.LocalReport.GetParameters())
            {
                if (rpi.Prompt.Equals("单位名称"))
                {
                    paraList.Add(new ReportParameter(rpi.Name, "单位名称测试"));
                }
            }

            frmReport.reportViewer1.LocalReport.SetParameters(paraList);

            frmReport.Show();

        }

        public List<ReportDataSource> CreatReportDataSource(ReportData reportData)
        {
            List<ReportDataSource> list = new List<ReportDataSource>();

            Type DataSetType = a.GetType(reportData.DataSetName);

            object DataSetObj = Activator.CreateInstance(DataSetType);

            ((DataSet)DataSetObj).EnforceConstraints = false;

            ReportDataSource reportDataSource;

            BindingSource ReportBindingSource;

            foreach (ReportSource rs in reportData.ReportSourceList)
            {
                ReportBindingSource = new BindingSource();
                ReportBindingSource.DataSource = DataSetObj;
                ReportBindingSource.DataMember = rs.DataTableName;

                reportDataSource = new ReportDataSource();
                reportDataSource.Name = reportData.DataSetName.Substring(reportData.DataSetName.LastIndexOf('.')+1) + "_" + rs.DataTableName;
                reportDataSource.Value = ReportBindingSource;

                Type DataAdapterType = a.GetType(rs.DataAdapterName);
                object DataAdapterObj = Activator.CreateInstance(DataAdapterType);

                object DataOjb = DataSetType.GetProperty(rs.DataTableName).GetValue(DataSetObj, null);

                object[] para = { DataOjb };

                if (rs.Para != null)
                {
                    object[] FillPara = new object[para.Length + rs.Para.Length];
                    Array.Copy(para, 0, FillPara, 0, para.Length);
                    Array.Copy(rs.Para, 0, FillPara, para.Length, rs.Para.Length);
                    DataAdapterType.GetMethod("Fill").Invoke(DataAdapterObj, FillPara);
                }
                else
                {
                    DataAdapterType.GetMethod("Fill").Invoke(DataAdapterObj, para);
                }
                

                list.Add(reportDataSource);
            }

            return list;

        }

        /// <summary>
        /// 生成报表数据对象
        /// </summary>
        /// <param name="DataAdapterName">DataAdapter全名称(包含命名空间)</param>
        /// <param name="DataTableName">DataTableName名称(不包含命名空间)</param>
        /// <param name="DataSourceName">报表对应的数据源名称</param>
        /// <returns></returns>
        public ReportSource CreatReportSource(string DataAdapterName,string DataTableName,object[] para)
        {
            ReportSource reportSource = new ReportSource();
            reportSource.DataAdapterName = DataAdapterName;
           
            reportSource.DataTableName = DataTableName;

            reportSource.Para = para;

            return reportSource;
        }
    }

    public class ReportData
    {
        private string dataSetName;
        /// <summary>
        /// DataSet全名称(包括命名空间)
        /// </summary>
        public string DataSetName
        {
            get { return dataSetName; }
            set { dataSetName = value; }
        }
        private string reportName;
        /// <summary>
        /// 报表全名称(包括命名空间)
        /// </summary>
        public string ReportName
        {
            get { return reportName; }
            set { reportName = value; }
        }
        
        private List<ReportSource> reportSourceList;
        /// <summary>
        /// 报表数据对象
        /// </summary>
        public List<ReportSource> ReportSourceList
        {
            get { return reportSourceList; }
            set { reportSourceList = value; }
        }
       
    }

    public class ReportSource
    {
        private string dataAdapterName;
        /// <summary>
        /// DataAdapter全名称(包含命名空间)
        /// </summary>
        public string DataAdapterName
        {
            get { return dataAdapterName; }
            set { dataAdapterName = value; }
        }
        private string dataTableName;
        /// <summary>
        /// DataTableName名称(不包含命名空间)
        /// </summary>
        public string DataTableName
        {
            get { return dataTableName; }
            set { dataTableName = value; }
        }
        private object[] para;
        /// <summary>
        /// Fill参数集合
        /// </summary>
        public object[] Para
        {
            get { return para; }
            set { para = value; }
        }
    }
}
