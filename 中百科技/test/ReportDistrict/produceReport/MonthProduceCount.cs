using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.ReportDistrict.produceReport
{
    public class MonthProduceCount :ProduceBase
    {
        protected string strCharge;
        /// <summary>
        /// 部门主管
        /// </summary>
        public string Charge
        {
            get
            {
                return this.strCharge;
            }
            set
            {
                this.strCharge = value;
            }
        }
        /// <summary>
        /// 显示报表
        /// </summary>
        public void ShowReport()
        {

            ReportViewer frmRPT = new ReportViewer();
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();

            frmRPT.MainDataSet = this.Source;
            frmRPT.ReportName = "HReport";
            oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("ProduceDataSet_生产月统计报表");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\MonthProduceCount.rdlc";
            frmRPT.HBody = 22.2;
            frmRPT.Param.Add("CoName", "2009");
            frmRPT.Param.Add("Number", "zhongbai");
            frmRPT.Param.Add("Tabler", "11000111");
            frmRPT.Param.Add("Charge", "aaa");
            frmRPT.ShowDialog();
        }
    }
}
