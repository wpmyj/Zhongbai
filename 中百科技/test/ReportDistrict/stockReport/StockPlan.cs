// 年采购计划 刘淼
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
    class StockPlan : StockBase
    {
        /// <summary>
        /// 年度
        /// </summary>
        private string strYear;
        public string Year
        {
            get
            {
                return this.strYear;
            }
            set
            {
                this.strYear = value;
            }
        }

        /// <summary>
        /// 显示报表
        /// </summary>
        public void ShowReport()
        {
            ReportViewer frmRPT = new ReportViewer();
            frmRPT.MainDataSet = this.dtsSource;
            frmRPT.HBody = 14;
            frmRPT.ReportName = "WReport";
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("Storage_material");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\StockPlan.rdlc";
            frmRPT.Param.Add("year", this.strYear);
            frmRPT.Param.Add("coName", this.strCoName);
            frmRPT.Param.Add("docNum", this.strDocNum);
            frmRPT.Param.Add("table", this.strTable);
            frmRPT.Param.Add("examine", this.strExamine);
            frmRPT.Param.Add("approve", this.strApprove);
            frmRPT.ShowDialog();
        }
    }
}
