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
    public class ProductOutAccount:StorageBase
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
            oArrayList.Add("stock_ProductOutAccount");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\ProductOutAccount.rdlc";
            frmRPT.HBody = 13.5;
            frmRPT.ShowEmptyRow = false;
            frmRPT.Param.Add("Unit", "2009");
            frmRPT.Param.Add("Num", "zhongbai");
            frmRPT.Param.Add("MakeTable", "11000111");
            frmRPT.Param.Add("StuffCheck", "aaa");
            frmRPT.Param.Add("Check", "bb");
            frmRPT.ShowDialog();
        }
    }
}
