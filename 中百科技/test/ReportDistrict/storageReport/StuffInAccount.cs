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
    public class StuffInAccount : StorageBase
    {
        /// <summary>
        /// 显示报表
        /// </summary>
        public void ShowReport()
        {
            ReportViewer frmRPT = new ReportViewer();
            frmRPT.MainDataSet = this.dtsSource;
            frmRPT.HBody = 13.5;
            frmRPT.ReportName = "WReport";

            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("stock_StuffInAccount");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\StuffInAccount.rdlc";
            frmRPT.ShowEmptyRow = false;
            frmRPT.Param.Add("Unit", this.Unit);
            frmRPT.Param.Add("Num", this.Num);
            frmRPT.Param.Add("MakeTable",this.MakeTable);
            frmRPT.Param.Add("StuffCheck", this.StuffCheck);
            frmRPT.Param.Add("Check", this.Check);

            frmRPT.ShowDialog();
        }
    }
}
