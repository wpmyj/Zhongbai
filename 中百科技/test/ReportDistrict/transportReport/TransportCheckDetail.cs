// 采购结算单 结算单明细 刘淼
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.ReportDistrict.transportReport
{
    class TransportCheckDetail : TransportBase
    {
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
            oArrayList.Add("Transport_transportCheckDetail");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\TransportCheckDetail.rdlc";
            frmRPT.Param.Add("coName", this.CoName);
            frmRPT.ShowDialog();
        }
    }
}
