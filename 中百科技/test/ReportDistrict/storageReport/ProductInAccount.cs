using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DasherStation.common;
namespace DasherStation.ReportDistrict.storageReport
{
    public class ProductInAccount:StorageBase
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
            frmRPT.ReportName = "WReport";
            oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("stock_ProductInAccount");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\ProductInAccount.rdlc";
            frmRPT.HBody = 13.5;
            frmRPT.ShowEmptyRow = false;
            frmRPT.Param.Add("Unit", this.Unit);
            frmRPT.Param.Add("Num", this.Num);
            frmRPT.Param.Add("MakeTable",this.MakeTable);
            frmRPT.Param.Add("Charge",this.Charge);
            frmRPT.ShowDialog();
        }
    }
}
