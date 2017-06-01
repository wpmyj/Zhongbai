using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DasherStation.common;
namespace DasherStation.ReportDistrict.storageReport
{
    public class MonthStuffStorage:StorageBase
    {       
        /// <summary>
        /// 显示报表
        /// </summary>
        public void ShowReport()
        {
            ReportViewer frmRPT = new ReportViewer();
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            frmRPT.MainDataSet = this.Source;
            frmRPT.ReportName = "WReport";
            oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("stock_MonthStuffStorage");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\MonthStuffStorage.rdlc";
            frmRPT.ShowEmptyRow = false;
            frmRPT.HBody = 13.5;
            frmRPT.HeaderCount = 2;
            frmRPT.Param.Add("Unit", this.Unit);
            frmRPT.Param.Add("Num", this.Num);
            frmRPT.Param.Add("MakeTable",this.MakeTable);
            frmRPT.Param.Add("Check", this.Check);
            frmRPT.Param.Add("Approve", this.Approve);
            frmRPT.ShowDialog();
        }
    }
}
