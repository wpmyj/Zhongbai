using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DasherStation.common;
namespace DasherStation.ReportDistrict.sellReport
{
    /// <summary>
    /// 年销售计划
    /// </summary>
    public class YearSellPlan : SellBase
    {
        
        private string strYear;
        /// <summary>
        /// 年度
        /// </summary>
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
            frmRPT.HBody = 14.39;
            frmRPT.ReportName = "WReport";

            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("sell_YearSellPlan");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\YearSellPlan.rdlc";

            frmRPT.Param.Add("year", this.strYear);
            frmRPT.Param.Add("coName", this.strCoName);
            frmRPT.Param.Add("number", this.strNumber);
            frmRPT.Param.Add("tabler", this.strTabler);
            frmRPT.Param.Add("auditer", this.strAuditer);
            frmRPT.Param.Add("approvaler", this.strApprovaler);

            frmRPT.ShowDialog();
        }
    }
}
