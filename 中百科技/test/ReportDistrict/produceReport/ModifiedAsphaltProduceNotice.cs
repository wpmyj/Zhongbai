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
    /// <summary>
    /// 改性沥青生产通知单
    /// </summary>
    class ModifiedAsphaltProduceNotice : ProduceBase
    {

        private string str备注;
        /// <summary>
        /// 备注
        /// </summary>
        public string 备注
        {
            get
            {
                return this.备注;
            }
            set
            {
                this.str备注 = value;
            }
        }

        private string strManager;
        /// <summary>
        /// 部门主管
        /// </summary>
        public string Manager
        {
            get
            {
                return this.strManager;
            }
            set
            {
                this.strManager = value;
            }
        }

        private string strDate;
        /// <summary>
        /// 制表日期
        /// </summary>
        public string CDate
        {
            get
            {
                return this.strDate;
            }
            set
            {
                this.strDate = value;
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
            frmRPT.ReportName = "HReport";

            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("ProduceDataSet_ProduceInfo");
            oArrayList.Add("ProduceDataSet_目标配合比信息");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\ModifiedAsphaltProduceNotice.rdlc";

            frmRPT.Param.Add("coName", this.strCoName);
            frmRPT.Param.Add("number", this.strNumber);
            frmRPT.Param.Add("tabler", this.strTabler);
            frmRPT.Param.Add("manager", this.strManager);
            frmRPT.Param.Add("cDate", this.strDate);
            frmRPT.Param.Add("备注", this.str备注);

            frmRPT.ShowDialog();
        }
    }
}
