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
    public class SellBase
    {
        
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
        
        protected string strNumber;
        /// <summary>
        /// 文档编号
        /// </summary>
        public string Number
        {
            get
            {
                return this.strNumber;
            }
            set
            {
                this.strNumber = value;
            }
        }
        
        protected string strTabler;
        /// <summary>
        /// 制表
        /// </summary>
        public string Tabler
        {
            get
            {
                return this.strTabler;
            }
            set
            {
                this.strTabler = value;
            }
        }
        
        protected string strAuditer;
        /// <summary>
        /// 审核
        /// </summary>
        public string Auditer
        {
            get
            {
                return this.strAuditer;
            }
            set
            {
                this.strAuditer = value;
            }
        }
        
        protected string strApprovaler;
        /// <summary>
        /// 审批
        /// </summary>
        public string Approvaler
        {
            get
            {
                return this.strApprovaler;
            }
            set
            {
                this.strApprovaler = value;
            }
        }
        
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
    }
}
