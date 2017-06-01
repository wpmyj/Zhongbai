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
    public class StorageBase
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

        protected string strUnit;
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Unit
        {
            get
            {
                return this.strUnit;
            }
            set
            {
                this.strUnit = value;
            }
        }

        protected string strNum;
        /// <summary>
        /// 文档编号
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

        protected string strMakeTable;
        /// <summary>
        /// 制表
        /// </summary>
        public string MakeTable
        {
            get
            {
                return this.strMakeTable;
            }
            set
            {
                this.strMakeTable = value;
            }
        }

        protected string strStuffCheck;
        /// <summary>
        /// 材料稽核
        /// </summary>
        public string StuffCheck
        {
            get
            {
                return this.strStuffCheck;
            }
            set
            {
                this.strStuffCheck = value;
            }
        }

        protected string strCheck;
        /// <summary>
        /// 审核
        /// </summary>
        public string Check
        {
            get
            {
                return this.strCheck;
            }
            set
            {
                this.strCheck = value;
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
    }
}