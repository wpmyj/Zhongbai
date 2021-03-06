﻿// 应付记录 刘淼
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.financeReport.stockReport
{
    class ShouldOutRecord
    {

        protected DataSet dtsSource = null;
        /// <summary>
        /// 数据源
        /// </summary>
        public DataSet Source
        {
            get
            {
                return this.dtsSource;
            }
            set
            {
                this.dtsSource = value;
            }
        }
        /// <summary>
        /// 显示报表
        /// </summary>
        public void ShowReport()
        {
            ReportViewer frmRPT = new ReportViewer();
            frmRPT.MainDataSet = this.dtsSource;
            frmRPT.HBody = 23;
            frmRPT.ReportName = "HReport";
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("finance_shouldOutputRecord");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\ShouldOutputRecord.rdlc";
            frmRPT.ShowDialog();
        }
    }
}
