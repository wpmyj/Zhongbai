using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DasherStation.sell
{
    class SellPublicClass
    {
    }

    #region 销售合同类 SalesContractClass
    /*
      * 类名称: SalesContractClass
      * 类功能描述：销售合同类
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class SalesContractClass
    {
        //合同名称;
        private string name;
        //合同编号;
        private string no;
        //关联客户ID;
        private int ciId;
        //制作人;
        private string producer;
        //金额; 
        private decimal? sum;
        //父合同ID;
        private int parentId;
        //审核人;
        private string assessor;
        //审批人;
        private string checkupMan;
        //开始日期;
        private DateTime? startDate;
        //结束日期;
        private DateTime? endDate;
        //制作人;
        private string inputMan;
        //录入记录时间;
        private DateTime? inputDate;
        //运输方;
        private string conveyancer;
        //执行状态;
        private bool finishMark;
        //备注;
        private string remark;

        /*
      * 方法名称：Name
      * 方法功能描述：name的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /*
      * 方法名称：No
      * 方法功能描述：no的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string No
        {
            get
            {
                return no;
            }
            set
            {
                no = value;
            }
        }

        /*
      * 方法名称：CiId
      * 方法功能描述：ciId的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int CiId
        {
            get
            {
                return ciId;
            }
            set
            {
                ciId = value;
            }
        }

        /*
      * 方法名称：Producer
      * 方法功能描述：producer的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Producer
        {
            get
            {
                return producer;
            }
            set
            {
                producer = value;
            }
        }

        /*
      * 方法名称：Sum
      * 方法功能描述：sum的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
            }
        }

        /*
      * 方法名称：ParentId
      * 方法功能描述：parentId的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int ParentId
        {
            get
            {
                return parentId;
            }
            set
            {
                parentId = value;
            }
        }

        /*
      * 方法名称：Assessor
      * 方法功能描述：assessor的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Assessor
        {
            get
            {
                return assessor;
            }
            set
            {
                assessor = value;
            }
        }

        /*
      * 方法名称：CheckupMan
      * 方法功能描述：checkupMan的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string CheckupMan
        {
            get
            {
                return checkupMan;
            }
            set
            {
                checkupMan = value;
            }
        }

        /*
      * 方法名称：Conveyancer
      * 方法功能描述：conveyancer的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Conveyancer
        {
            get
            {
                return conveyancer;
            }
            set
            {
                conveyancer = value;
            }
        }

        /*
      * 方法名称：StartDate
      * 方法功能描述：startDate的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DateTime? StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }

        /*
      * 方法名称：EndDate
      * 方法功能描述：endDate的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DateTime? EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }

        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DateTime? InputDate
        {
            get
            {
                return inputDate;
            }
            set
            {
                inputDate = value;
            }
        }

        /*
      * 方法名称：FinishMark
      * 方法功能描述：finishMark的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FinishMark
        {
            get
            {
                return finishMark;
            }
            set
            {
                finishMark = value;
            }
        }

        /*
      * 方法名称：InputMan
      * 方法功能描述：inputMan的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string InputMan
        {
            get
            {
                return inputMan;
            }
            set
            {
                inputMan = value;
            }
        }

        /*
      * 方法名称：Remark
      * 方法功能描述：remark的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }

    }
    #endregion

    #region 销售合同明细类 InvoiceClass
    /*
      * 类名称: InvoiceClass
      * 类功能描述：销售合同明细类
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class InvoiceClass
    {
        private int id;
        //关联产品规格型号ID;
        private int pId;
        //货物的数量;
        private int quantity;
        //采购货物的单价; 
        private decimal? unitPrice;
        //制作人;
        private string inputMan;
        //审核人;
        private string assessor;
        //审批人;
        private string checkupMan;
        //录入记录时间;
        private DateTime? inputDate;
        //状态;
        private bool finishMark; 
        //备注;
        private string remark;
        //关联销售合同id;
        private int scId;

        /*
      * 方法名称：Id
      * 方法功能描述：Id的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        /*
      * 方法名称：PmId
      * 方法功能描述：pmId的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int PId
        {
            get
            {
                return pId;
            }
            set
            {
                pId = value;
            }
        }
        /*
      * 方法名称：Quantity
      * 方法功能描述：quantity的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }
        /*
      * 方法名称：UnitPrice
      * 方法功能描述：unitPrice的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                unitPrice = value;
            }
        }
        /*
      * 方法名称：FinishMark
      * 方法功能描述：finishMark的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FinishMark
        {
            get
            {
                return finishMark;
            }
            set
            {
                finishMark = value;
            }
        }
        /*
      * 方法名称：InputMan
      * 方法功能描述：inputMan的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string InputMan
        {
            get
            {
                return inputMan;
            }
            set
            {
                inputMan = value;
            }
        }
        /*
      * 方法名称：Assessor
      * 方法功能描述：assessor的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Assessor
        {
            get
            {
                return assessor;
            }
            set
            {
                assessor = value;
            }
        }
        /*
      * 方法名称：CheckupMan
      * 方法功能描述：checkupMan的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string CheckupMan
        {
            get
            {
                return checkupMan;
            }
            set
            {
                checkupMan = value;
            }
        }
        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DateTime? InputDate
        {
            get
            {
                return inputDate;
            }
            set
            {
                inputDate = value;
            }
        }        
        /*
      * 方法名称：ScId
      * 方法功能描述：scId的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int ScId
        {
            get
            {
                return scId;
            }
            set
            {
                scId = value;
            }
        }
        /*
      * 方法名称：Remark
      * 方法功能描述：remark的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }

    }
    #endregion

    #region 销售计划明细 sellPlanDetailClass
    class sellPlanDetailClass
    {
        private long id;
        //产品表对应ID
        private long pId;
        //销售计划对应ID
        private long spId;
        //销售总量
        private decimal? quantity;
        //一月份
        private decimal? january;
        //二月份
        private decimal? february;
        //三月份
        private decimal? march;
        //四月份
        private decimal? april;
        //五月份
        private decimal? may;
        //六月份
        private decimal? june;
        //七月份
        private decimal? july;
        //八月份
        private decimal? august;
        //九月份
        private decimal? september;
        //十月份
        private decimal? october;
        //十一月份
        private decimal? november;
        //十二月份
        private decimal? december;
        //备注
        private string remark;
        //录入时间
        private DateTime? inputDate;
        /*
      * 方法名称：Id
      * 方法功能描述：id的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        /*
      * 方法名称：PId
      * 方法功能描述：pId的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long PId
        {
            get
            {
                return pId;
            }
            set
            {
                pId = value;
            }
        }
        /*
      * 方法名称：SpId
      * 方法功能描述：spId的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long SpId
        {
            get
            {
                return spId;
            }
            set
            {
                spId = value;
            }
        }
        /*
      * 方法名称：Quantity
      * 方法功能描述：quantity的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }
        /*
      * 方法名称：January
      * 方法功能描述：january的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? January
        {
            get
            {
                return january;
            }
            set
            {
                january = value;
            }
        }
        /*
      * 方法名称：February
      * 方法功能描述：february的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? February
        {
            get
            {
                return february;
            }
            set
            {
                february = value;
            }
        }
        /*
      * 方法名称：March
      * 方法功能描述：march的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? March
        {
            get
            {
                return march;
            }
            set
            {
                march = value;
            }
        }
        /*
      * 方法名称：April
      * 方法功能描述：april的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? April
        {
            get
            {
                return april;
            }
            set
            {
                april = value;
            }
        }
        /*
      * 方法名称：May
      * 方法功能描述：may的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? May
        {
            get
            {
                return may;
            }
            set
            {
                may = value;
            }
        }
        /*
      * 方法名称：June
      * 方法功能描述：june的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? June
        {
            get
            {
                return june;
            }
            set
            {
                june = value;
            }
        }
        /*
      * 方法名称：July
      * 方法功能描述：july的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? July
        {
            get
            {
                return july;
            }
            set
            {
                july = value;
            }
        }
        /*
      * 方法名称：August
      * 方法功能描述：august的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? August
        {
            get
            {
                return august;
            }
            set
            {
                august = value;
            }
        }
        /*
      * 方法名称：September
      * 方法功能描述：september的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? September
        {
            get
            {
                return september;
            }
            set
            {
                september = value;
            }
        }
        /*
      * 方法名称：October
      * 方法功能描述：october的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? October
        {
            get
            {
                return october;
            }
            set
            {
                october = value;
            }
        }
        /*
      * 方法名称：November
      * 方法功能描述：november的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? November
        {
            get
            {
                return november;
            }
            set
            {
                november = value;
            }
        }
        /*
      * 方法名称：December
      * 方法功能描述：december的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? December
        {
            get
            {
                return december;
            }
            set
            {
                december = value;
            }
        }
        /*
      * 方法名称：Remark
      * 方法功能描述：remark的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }
        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DateTime? InputDate
        {
            get
            {
                return inputDate;
            }
            set
            {
                inputDate = value;
            }
        }        
    }
    #endregion

    #region 销售计划 sellPlanClass
    class sellPlanClass
    {
        //计划制作人;
        private string producer;
        //审核人;
        private string assessor;
        //审批人;
        private string checkupMan;
        //备注
        private string remark;
        //录入人;
        private string inputMan;
        //录入时间
        private DateTime? inputDate;
        //制作计划年份；
        private string planYear;


        /*
      * 方法名称：Producer
      * 方法功能描述：producer的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Producer
        {
            get
            {
                return producer;
            }
            set
            {
                producer = value;
            }
        }
        /*
      * 方法名称：Assessor
      * 方法功能描述：assessor的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Assessor
        {
            get
            {
                return assessor;
            }
            set
            {
                assessor = value;
            }
        }
        /*
      * 方法名称：CheckupMan
      * 方法功能描述：checkupMan的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string CheckupMan
        {
            get
            {
                return checkupMan;
            }
            set
            {
                checkupMan = value;
            }
        }
        /*
      * 方法名称：InputMan
      * 方法功能描述：inputMan的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string InputMan
        {
            get
            {
                return inputMan;
            }
            set
            {
                inputMan = value;
            }
        }
        /*
      * 方法名称：Remark
      * 方法功能描述：remark的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }
        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DateTime? InputDate
        {
            get
            {
                return inputDate;
            }
            set
            {
                inputDate = value;
            }
        }        
        /*
      * 方法名称：PlanYear
      * 方法功能描述：planYear的set/get方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-09
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string PlanYear
        {
            get
            {
                return planYear;
            }
            set
            {
                planYear = value;
            }
        }        
    }
    #endregion

    #region 销售核算票据类 SettlementNoteClass
    /*
      * 类名称: SettlementClass
      * 类功能描述：销售核算票据类
      *
      * 创建人：冯雪
      * 创建时间：2009-03-17
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class SettlementNoteClass
    {
        // 票据ID;
        private long id;
        // 销售明细ID;
        private long iId;
        // 票据条码;
        private string barCode;
        // 核算日期;
        private DateTime? inputDate;
        // 合同名称;
        private string scname;
        // 产品种类;
        private string sort;
        // 产品名称;
        private string name;
        // 产品规格;
        private string model;
        // 毛重;
        private decimal grossWeight;
        // 皮重;
        private decimal tare;
        // 净重;
        private decimal suttle;
        // 客户名称;
        private string cname;
        // 起运地;
        private string sId1;
        // 止运地;
        private string sId2;
        
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public long IId
        {
            get { return iId; }
            set { iId = value; }
        }

        public string BarCode
        {
            get { return barCode; }
            set { barCode = value; }
        }

        public DateTime? InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }

        public string Scname
        {
            get { return scname; }
            set { scname = value; }
        }

        public decimal GrossWeight
        {
            get { return grossWeight; }
            set { grossWeight = value; }
        }

        public string SId2
        {
            get { return sId2; }
            set { sId2 = value; }
        }

        public string SId1
        {
            get { return sId1; }
            set { sId1 = value; }
        }

        public string Cname
        {
            get { return cname; }
            set { cname = value; }
        }

        public decimal Suttle
        {
            get { return suttle; }
            set { suttle = value; }
        }
        
        public decimal Tare
        {
            get { return tare; }
            set { tare = value; }
        }
        
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }


    }

    #endregion

    #region 销售核算票据类 PSettlementClass
    /*
      * 类名称: PSettlementClass
      * 类功能描述：销售合同明细类
      *
      * 创建人：冯雪
      * 创建时间：2009-03-17
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class PSettlementClass
    {
        // 产品总重量;
        private decimal totalWeight;
        // 销售明细ID
        private long scId;
        // 产品总金额;
        private decimal sum;
        // 录入人;
        private string inputMan;
        // 票据总数;
        private long count;

        public decimal TotalWeight
        {
            get { return totalWeight; }
            set { totalWeight = value; }
        }

        public long ScId
        {
            get { return scId; }
            set { scId = value; }
        }
        
        public decimal Sum
        {
            get { return sum; }
            set { sum = value; }
        }
        
        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }
        
        public long Count
        {
            get { return count; }
            set { count = value; }
        }

    }
    #endregion

    #region 销售核算明细类
    /*
      * 类名称: PSettlementselDetailClass
      * 类功能描述：销售核算明细类
      *
      * 创建人：冯雪
      * 创建时间：2009-03-17
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class PSettlementselDetailClass
    {
        //销售合同明细ID
        private long iId;
        //销售核算表ID
        private long spsId; 
        //票据总数
        private long count;  
        //总金额
        private decimal sum;
        //录入人;
        private string inputMan;
        
        public long IId
        {
            get { return iId; }
            set { iId = value; }
        }
        
        public long SpsId
        {
            get { return spsId; }
            set { spsId = value; }
        }
        
        public long Count
        {
            get { return count; }
            set { count = value; }
        }
        
        public decimal Sum
        {
            get { return sum; }
            set { sum = value; }
        }

        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }
    }
    #endregion



}
