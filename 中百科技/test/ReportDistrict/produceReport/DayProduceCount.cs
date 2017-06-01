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
    public class DayProduceCount:ProduceBase
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
        protected string strTime;
        /// <summary>
        /// 制表日期
        /// </summary>
        public string Time
        {
            get
            {
                return this.strTime;
            }
            set
            {
                this.strTime = value;
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
            oArrayList.Add("ProduceDataSet_生产日统计报表");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\DayProduceCount.rdlc";
            frmRPT.HBody = 22.2;
            frmRPT.Param.Add("CoName", this.CoName);
            frmRPT.Param.Add("Number", this.Number);
            frmRPT.Param.Add("Tabler", this.Tabler);
            frmRPT.Param.Add("Charge", this.Charge);
            frmRPT.Param.Add("Time", this.Time);
            frmRPT.ShowDialog();
        }
    }
}
