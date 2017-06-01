using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.ReportDistrict.transportReport
{
    class TransportBase
    {
        /// <summary>
        /// 数据源
        /// </summary>
        protected DataSet dtsSource = null;
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
        /// 公司名称
        /// </summary>
        protected string strCoName;
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
        /// <summary>
        /// 文档编号
        /// </summary>
        protected string strDocNum;
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
        /// <summary>
        /// 制表
        /// </summary>
        protected string strTable;
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
        /// <summary>
        /// 审核
        /// </summary>
        protected string strExamine;
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
        /// <summary>
        /// 审核日期
        /// </summary>
        protected string strExamineYmd;
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
        /// <summary>
        /// 审批
        /// </summary>
        protected string strApprove;
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
        /// <summary>
        /// 审批日期
        /// </summary>
        protected string strApproveYmd;
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
        /// <summary>
        /// 编号
        /// </summary>
        protected string strNum;
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
        /// <summary>
        /// 结算单号
        /// </summary>
        protected string strAccountNum;
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
        /// <summary>
        /// 合同编号
        /// </summary>
        protected string strContractNum;
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
        /// <summary>
        /// 发票号码
        /// </summary>
        protected string strInvoiceNo;
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
        /// <summary>
        /// 供应商代表
        /// </summary>
        protected string strSupplier;
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
        /// <summary>
        /// 联系电话
        /// </summary>
        protected string strTelephone;
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
        /// <summary>
        /// 稽核员
        /// </summary>
        protected string strAuditor;
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
        /// <summary>
        /// 稽核日期
        /// </summary>
        protected string strAuditorYmd;
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
