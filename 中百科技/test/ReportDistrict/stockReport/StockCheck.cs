// 采购结算单 刘淼
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
    class StockCheck : StockBase
    {
        
        protected string strSumMoney;
        /// <summary>
        /// 合计
        /// </summary>
        public string SumMoney
        {
            get
            {
                return this.strSumMoney;
            }
            set
            {
                this.strSumMoney = value;
            }
        }
        
        public void ShowReport()
        {
            ReportViewer frmRPT = new ReportViewer();
            frmRPT.MainDataSet = this.dtsSource;
            frmRPT.HBody = 14;
            frmRPT.HeaderCount = 2;
            frmRPT.FooterCount = 10;
            frmRPT.ReportName = "HReport";
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("Storage_stockcheck");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\StockCheck.rdlc";
            frmRPT.Param.Add("sumMoney", this.SumMoney);
            frmRPT.Param.Add("accountNum", this.AccountNum);
            frmRPT.Param.Add("contractNum", this.ContractNum);
            frmRPT.Param.Add("coName", this.CoName);
            frmRPT.Param.Add("num", this.Num);
            frmRPT.Param.Add("invoiceNo", this.InvoiceNo);
            frmRPT.Param.Add("supplier", this.Supplier);
            frmRPT.Param.Add("telephone", this.Telephone);
            frmRPT.Param.Add("auditor", this.Auditor);
            frmRPT.Param.Add("examine", this.Examine);
            frmRPT.Param.Add("approve", this.Approve);
            frmRPT.Param.Add("auditorYmd", this.AuditorYmd);
            frmRPT.Param.Add("examineYmd", this.ExamineYmd);
            frmRPT.Param.Add("approveYmd", this.ApproveYmd);
            frmRPT.ShowDialog();
        }
    }
}
