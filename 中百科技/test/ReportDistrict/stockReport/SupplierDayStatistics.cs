using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.ReportDistrict.stockReport
{
    class SupplierDayStatistics : StockBase
    {
        protected string date;
        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
        /// <summary>
        /// 显示报表
        /// </summary>
        public void ShowReport()
        {
            ReportViewer frmRPT = new ReportViewer();
            frmRPT.MainDataSet = this.dtsSource;
            frmRPT.HBody = 23;
            frmRPT.HeaderCount = 2;
            frmRPT.ReportName = "HReport";
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("Storage_supplierDayStatistics");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\SupplierDayStatistics.rdlc";
            frmRPT.Param.Add("coName", this.CoName);
            frmRPT.Param.Add("num", this.Num);
            frmRPT.Param.Add("table", this.Table);
            frmRPT.Param.Add("examine", this.Examine);
            frmRPT.Param.Add("date",this.date);
            frmRPT.ShowDialog();
        }
    }
}
