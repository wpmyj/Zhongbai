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
    /// 销售结算单
    /// </summary>
    public class ProductSellClearing : SellBase
    {
        protected string strNumber1;
        /// <summary>
        /// 结算单号
        /// </summary>
        public string Number1
        {
            get
            {
                return this.strNumber1;
            }
            set
            {
                this.strNumber1 = value;
            }
        }

       
        protected string strNumber2;
        /// <summary>
        /// 合同编号
        /// </summary>
        public string Number2
        {
            get
            {
                return this.strNumber2;
            }
            set
            {
                this.strNumber2 = value;
            }
        }

       
        protected string strNumber3;
        /// <summary>
        /// 发票号码
        /// </summary>
        public string Number3
        {
            get
            {
                return this.strNumber3;
            }
            set
            {
                this.strNumber3 = value;
            }
        }

       
        protected string strGuest;
        /// <summary>
        /// 客户联系人
        /// </summary>
        public string Guest
        {
            get
            {
                return this.strGuest;
            }
            set
            {
                this.strGuest = value;
            }
        }

        
        protected string strTel;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel
        {
            get
            {
                return this.strTel;
            }
            set
            {
                this.strTel = value;
            }
        }

        
        protected string strAudit1;
        /// <summary>
        /// 审核人
        /// </summary>
        public string Audit1
        {
            get
            {
                return this.strAudit1;
            }
            set
            {
                this.strAudit1 = value;
            }
        }

        
        protected string strAudit2;
        /// <summary>
        /// 稽核员
        /// </summary>
        public string Audit2
        {
            get
            {
                return this.strAudit2;
            }
            set
            {
                this.strAudit2 = value;
            }
        }

        
        protected string strAudit3;
        /// <summary>
        /// 审批人
        /// </summary>
        public string Audit3
        {
            get
            {
                return this.strAudit3;
            }
            set
            {
                this.strAudit3 = value;
            }
        }

        
        protected DateTime dAuditDate1;
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime AuditDate1
        {
            get
            {
                return this.dAuditDate1;
            }
            set
            {
                this.dAuditDate1 = value;
            }
        }

        
        protected DateTime dAuditDate2;
        /// <summary>
        /// 稽核时间
        /// </summary>
        public DateTime AuditDate2
        {
            get
            {
                return this.dAuditDate2;
            }
            set
            {
                this.dAuditDate2 = value;
            }
        }

        
        protected DateTime dAuditDate3;
        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime AuditDate3
        {
            get
            {
                return this.dAuditDate3;
            }
            set
            {
                this.dAuditDate3 = value;
            }
        }

        /// <summary>
        /// 显示报表
        /// </summary>
        public void ShowReport()
        {
            CReportTools oReportTools = new CReportTools();
            ReportViewer frmRPT = new ReportViewer();
            frmRPT.MainDataSet = this.dtsSource;

            decimal dTotal = 0;
            for (int i = 0; i < this.dtsSource.Tables[0].Rows.Count; i++)
            {
                dTotal += Convert.ToDecimal(this.dtsSource.Tables[0].Rows[i]["total"]);
            }

            frmRPT.HBody = 23.09;
            frmRPT.ReportName = "HReport";
            frmRPT.FooterCount = 10;

            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("sell_ProductSellClearing");
            frmRPT.MainDataSourceName = oArrayList;
            frmRPT.ReportPath = Application.StartupPath + @"\ProductSellClearing.rdlc";

            frmRPT.Param.Add("coName", this.strCoName);
            frmRPT.Param.Add("number", this.strNumber);
            frmRPT.Param.Add("number1", this.strNumber1);
            frmRPT.Param.Add("number2", this.strNumber2);
            frmRPT.Param.Add("number3", this.strNumber3);
            frmRPT.Param.Add("guest", this.strGuest);
            frmRPT.Param.Add("tel", this.strTel);
            frmRPT.Param.Add("audit1", this.strAudit1);
            frmRPT.Param.Add("audit2", this.strAudit2);
            frmRPT.Param.Add("audit3", this.strAudit3);
            frmRPT.Param.Add("auditDate1", this.dAuditDate1.Year + "年" + this.dAuditDate1.Month + "月" + this.dAuditDate1.Day + "日");
            frmRPT.Param.Add("auditDate2", this.dAuditDate2.Year + "年" + this.dAuditDate2.Month + "月" + this.dAuditDate2.Day + "日");
            frmRPT.Param.Add("auditDate3", this.dAuditDate3.Year + "年" + this.dAuditDate3.Month + "月" + this.dAuditDate3.Day + "日");
            frmRPT.Param.Add("total", oReportTools.ToUpper(dTotal));

            frmRPT.ShowDialog();
        }

    }
}
