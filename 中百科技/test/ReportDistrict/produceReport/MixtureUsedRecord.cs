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
    public class MixtureUsedRecord:ProduceBase
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
            frmRPT.ReportName = "WReport";
            oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("ProduceDataSet_混合能源消耗记录");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\MixtureUsedRecord.rdlc";
            frmRPT.HBody = 18.5;
            frmRPT.Param.Add("CoName", "2009");
            frmRPT.Param.Add("Number", "zhongbai");
            frmRPT.Param.Add("Tabler", "11000111");
            frmRPT.Param.Add("Charge", "aaa");
            frmRPT.Param.Add("Time", "bbbb-bb-bb");
            frmRPT.ShowDialog();
        }
    }
}
