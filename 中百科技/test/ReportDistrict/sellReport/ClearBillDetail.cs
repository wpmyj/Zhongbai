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
    /// 结算单明细
    /// </summary>
    public class ClearBillDetail : SellBase
    {
        /// <summary>
        /// 显示报表
        /// </summary>
        public void ShowReport()
        {
            ReportViewer frmRPT = new ReportViewer();
            frmRPT.MainDataSet = this.dtsSource;
            frmRPT.HBody = 14.39;
            frmRPT.ReportName = "WReport";

            DataTable dttSource = this.dtsSource.Tables[0];
            ////dttSource.Columns.Add("idx");
            //for (int i = 0; i < dttSource.Rows.Count; i++)
            //{
            //    dttSource.Rows[i]["idx"] = i + 1;
            //}

            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("sell_ClearBillDetail");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\ClearBillDetail.rdlc";

            frmRPT.Param.Add("coName", this.strCoName);

            frmRPT.ShowDialog();
        }
    }
}
