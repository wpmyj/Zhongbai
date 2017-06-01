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
    /// 按工程统计
    /// </summary>
    public class SellOutByProject : SellBase
    {
        
        protected int iType = 0;
        /// <summary>
        /// 统计类别 日：0 月：1
        /// </summary>
        public int Type
        {
            get
            {
                return this.iType;
            }
            set
            {
                this.iType = value;
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
            oArrayList.Add("sell_SellOutByProject");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\SellOutByProject.rdlc";

            DataTable dttSource = this.dtsSource.Tables[0];
            dttSource.Columns.Add("unitname");
            for (int i = 0; i < dttSource.Rows.Count; i++)
            {
                dttSource.Rows[i]["unitname"] = "吨";
            }

            frmRPT.Param.Add("coName", this.strCoName);
            frmRPT.Param.Add("number", this.strNumber);
            frmRPT.Param.Add("tabler", this.strTabler);
            frmRPT.Param.Add("auditer", this.strAuditer);
            if (iType == 0)
            {
                frmRPT.Param.Add("title", "日");
            }
            if (iType == 1)
            {
                frmRPT.Param.Add("title", "月");
            }

            frmRPT.ShowDialog();
        }
    }
}
