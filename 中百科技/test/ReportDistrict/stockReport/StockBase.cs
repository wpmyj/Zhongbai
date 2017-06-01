using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.ReportDistrict.stockReport
{
    class StockBase
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
       
        protected string strCoName;
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CoName
        {
            get
            {
                return this.strCoName;
            }
            set
            {
                this.strCoName = value;
            }
        }
        
        protected string strDocNum;
        /// <summary>
        /// 文档编号
        /// </summary>
        public string DocNum
        {
            get
            {
                return this.strDocNum;
            }
            set
            {
                this.strDocNum = value;
            }
        }
        
        protected string strTable;
        /// <summary>
        /// 制表
        /// </summary>
        public string Table
        {
            get
            {
                return this.strTable;
            }
            set
            {
                this.strTable = value;
            }
        }
        
        protected string strExamine;
        /// <summary>
        /// 审核
        /// </summary>
        public string Examine
        {
            get
            {
                return this.strExamine;
            }
            set
            {
                this.strExamine = value;
            }
        }
        
        protected string strExamineYmd;
        /// <summary>
        /// 审核日期
        /// </summary>
        public string ExamineYmd
        {
            get
            {
                return this.strExamineYmd;
            }
            set
            {
                this.strExamineYmd = value;
            }
        }
        
        protected string strApprove;
        /// <summary>
        /// 审批
        /// </summary>
        public string Approve
        {
            get
            {
                return this.strApprove;
            }
            set
            {
                this.strApprove = value;
            }
        }
        
        protected string strApproveYmd;
        /// <summary>
        /// 审批日期
        /// </summary>
        public string ApproveYmd
        {
            get
            {
                return this.strApproveYmd;
            }
            set
            {
                this.strApproveYmd = value;
            }
        }
        
        protected string strNum;
        /// <summary>
        /// 编号
        /// </summary>
        public string Num
        {
            get
            {
                return this.strNum;
            }
            set
            {
                this.strNum = value;
            }
        }
        
        protected string strAccountNum;
        /// <summary>
        /// 结算单号
        /// </summary>
        public string AccountNum
        {
            get
            {
                return this.strAccountNum;
            }
            set
            {
                this.strAccountNum = value;
            }
        }
        
        protected string strContractNum;
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNum
        {
            get
            {
                return this.strContractNum;
            }
            set
            {
                this.strContractNum = value;
            }
        }        
        
        protected string strInvoiceNo;
        /// <summary>
        /// 发票号码
        /// </summary>
        public string InvoiceNo
        {
            get
            {
                return this.strInvoiceNo;
            }
            set
            {
                this.strInvoiceNo = value;
            }
        } 
        
        protected string strSupplier;
        /// <summary>
        /// 供应商代表
        /// </summary>
        public string Supplier
        {
            get
            {
                return this.strSupplier;
            }
            set
            {
                this.strSupplier = value;
            }
        } 
        
        protected string strTelephone;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone
        {
            get
            {
                return this.strTelephone;
            }
            set
            {
                this.strTelephone = value;
            }
        }
        
        protected string strAuditor;
        /// <summary>
        /// 稽核员
        /// </summary>
        public string Auditor
        {
            get
            {
                return this.strAuditor;
            }
            set
            {
                this.strAuditor = value;
            }
        } 
        
        protected string strAuditorYmd;
        /// <summary>
        /// 稽核日期
        /// </summary>
        public string AuditorYmd
        {
            get
            {
                return this.strAuditorYmd;
            }
            set
            {
                this.strAuditorYmd = value;
            }
        }
    }
}
