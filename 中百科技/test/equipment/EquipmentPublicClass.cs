using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DasherStation.equipment
{

    #region //设备维修保养记录属性类
    /*
   * 类名称：EquipmentServiceClass
   * 类功能描述：设备维修保养记录属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-20
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */

    class EquipmentServiceClass
    {
        private string no;               // 设备编号
        private string sort;             // 设备类别
        private string name;             // 设备名称
        private string model;            // 规格型号
        private double expenses;         // 维修保养费用
        private string serviceKind;      // 维修类别
        private string timeConsuming;    // 维修保养工时
        private DateTime serviceDate;    // 送修日期
        private DateTime finishDate;     // 完竣日期
        private string interval;         // 本次维修保养距上次维修保养实际作业小时或间隔里程
        private string fno;              // 文档编号
        private string serviceExplain;   // 维修保养项目说明
        private string changeAccessory;  // 更换主要配件
        private string attemptRunExplain;// 试运转情况说明
        private string testResult;       // 检验结论意见
        private DateTime inputDate;      // 录入记录时间
        private string dasherName;       // 单位名称
        private string inputMan;         // 录入人
       
        
        public string No
        {
            get { return no; }
            set { no = value; }
        }

        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double Expenses
        {
            get { return expenses; }
            set { expenses = value; }
        }

        public string ServiceKind
        {
            get { return serviceKind; }
            set { serviceKind = value; }
        }

        public string TimeConsuming
        {
            get { return timeConsuming; }
            set { timeConsuming = value; }
        }

        public DateTime ServiceDate
        {
            get { return serviceDate; }
            set { serviceDate = value; }
        }

        public DateTime FinishDate
        {
            get { return finishDate; }
            set { finishDate = value; }
        }

        public string Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        public string Fno
        {
            get { return fno; }
            set { fno = value; }
        }

        public string ServiceExplain
        {
            get { return serviceExplain; }
            set { serviceExplain = value; }
        }

        public string ChangeAccessory
        {
            get { return changeAccessory; }
            set { changeAccessory = value; }
        }

        public string AttemptRunExplain
        {
            get { return attemptRunExplain; }
            set { attemptRunExplain = value; }
        }

        public string TestResult
        {
            get { return testResult; }
            set { testResult = value; }
        }

        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }

        public string DasherName
        {
            get { return dasherName; }
            set { dasherName = value; }
        }

        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }
    }


    #endregion

    #region//设备加油记录

     /*
   * 类名称：EquipmentFillOilClass
   * 类功能描述：设备加油记录属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-21
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */

    class EquipmentFillOilClass
    {
        private string no;               // 设备编号
        private string sort;             // 设备类别
        private string name;             // 设备名称
        private string model;            // 设备型号
        private DateTime fillOilDate;    // 加油日期
        private string oilName;          // 燃油名称
        private string oilModel;         // 燃油型号
        private double quantity;         // 加油数量
        private string unit;             // 计量单位
        private double sum;              // 金额
        private double unitPrice;        // 单价
        private string fillOilMan;       // 加油人
        private string fno;              // 文档编号
        private DateTime inputDate;      // 录入记录时间
        private string dasherName;       // 单位名称
        private string inputMan;         // 录入人
        private string remark;           // 备注
        private int id;                  // 材料表id

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string No
        {
            get { return no; }
            set { no = value; }
        }


        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public DateTime FillOilDate
        {
            get { return fillOilDate; }
            set { fillOilDate = value; }
        }


        public string OilName
        {
            get { return oilName; }
            set { oilName = value; }
        }


        public string OilModel
        {
            get { return oilModel; }
            set { oilModel = value; }
        }


        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }


        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }


        public double Sum
        {
            get { return sum; }
            set { sum = value; }
        }


        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }


        public string FillOilMan
        {
            get { return fillOilMan; }
            set { fillOilMan = value; }
        }


        public string Fno
        {
            get { return fno; }
            set { fno = value; }
        }


        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }


        public string DasherName
        {
            get { return dasherName; }
            set { dasherName = value; }
        }


        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }


        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

    }

    #endregion

    #region//备品备件基本信息

     /*
   * 类名称：SparePartBasicInfoClass
   * 类功能描述：备品备件基本信息属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-22
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */

    class SparePartBasicInfoClass
    {
        private string no;               // 备件编号

        public string No
        {
            get { return no; }
            set { no = value; }
        }
        private string sort;             // 备件种类

        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        private string name;             // 备件名称

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string model;            // 规格型号

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private string maxStock;         // 最大库存

        public string MaxStock
        {
            get { return maxStock; }
            set { maxStock = value; }
        }
        private string minStock;         // 最小库存

        public string MinStock
        {
            get { return minStock; }
            set { minStock = value; }
        }
        private string unit;             // 计量单位

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        private DateTime inputDate;      // 录入记录时间

        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }
        private string inputMan;         // 录入人

        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }
    }
        

    #endregion

    #region//领料单概要信息

    /*
   * 类名称：ClaimSparePartBillClass
   * 类功能描述：领料单概要信息属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-23
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */

    class ClaimSparePartBillClass
    {
        private string claimNo;          // 领料单号
        private string fno;              // 文档编号
        private string claimMan;         // 领料人
        private int dId;                 // 领料部门id
        private DateTime claimDate;      // 领取日期
        private double sum;              // 总金额
        private string assessor;         // 审核人
        private string checkupMan;       // 审批人
        private DateTime auditingDate;   // 审核日期
        private DateTime checkupDate;    // 审批日期
        private DateTime inputDate;      // 录入记录时间
        private string inputMan;         // 录入人
        private int eiId;                // 设备信息表id

        public int EiId
        {
            get { return eiId; }
            set { eiId = value; }
        }

        public string Fno
        {
            get { return fno; }
            set { fno = value; }
        }

        public string ClaimMan
        {
            get { return claimMan; }
            set { claimMan = value; }
        }

        public int DId
        {
            get { return dId; }
            set { dId = value; }
        }

        public DateTime ClaimDate
        {
            get { return claimDate; }
            set { claimDate = value; }
        }

        public double Sum
        {
            get { return sum; }
            set { sum = value; }
        }

        public string Assessor
        {
            get { return assessor; }
            set { assessor = value; }
        }

        public string CheckupMan
        {
            get { return checkupMan; }
            set { checkupMan = value; }
        }

        public DateTime AuditingDate
        {
            get { return auditingDate; }
            set { auditingDate = value; }
        }

        public DateTime CheckupDate
        {
            get { return checkupDate; }
            set { checkupDate = value; }
        }

        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }

        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }

        public string ClaimNo
        {
            get { return claimNo; }
            set { claimNo = value; }
        }
    }

    #endregion

    #region//领料单详细信息

    /*
   * 类名称：ClaimSparePartBillDetailClass
   * 类功能描述：领料单详细信息属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-23
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */

    class ClaimSparePartBillDetailClass
    {
        private string cspbId;           // 领料单id

        public string CspbId
        {
            get { return cspbId; }
            set { cspbId = value; }
        }
        private string no;               // 备件编号

        public string No
        {
            get { return no; }
            set { no = value; }
        }
        private string sort;             // 备件种类

        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        private string name;             // 备件名称

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string model;            // 规格型号

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private double unitPrice;        // 单价（库存表取）

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        private string unit;             // 计量单位

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private int count;               // 领取数量

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private double sum;              // 总金额

        public double Sum
        {
            get { return sum; }
            set { sum = value; }
        }
        private DateTime inputDate;      // 录入记录时间

        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }
        private string inputMan;         // 录入人

        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }



    }


    #endregion

    #region//出、退库单概要信息属性类

    /*
   * 类名称：OutStockClass
   * 类功能描述：出、退库单概要信息属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-24
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */

    class OutStockClass
    {
        private int outId;               // 出库单id

        public int OutId
        {
            get { return outId; }
            set { outId = value; }
        }
        private int tID;                 // 退库单对应的出库单id（父id）

        public int TID
        {
            get { return tID; }
            set { tID = value; }
        }
        private int dId2;                // 文档管理表的id

        public int DId2
        {
            get { return dId2; }
            set { dId2 = value; }
        }
        private string fno;              // 文档编号

        public string Fno1
        {
            get { return fno; }
            set { fno = value; }
        }
        private int cspbId;              // 领料单Id

        public int CspbId
        {
            get { return cspbId; }
            set { cspbId = value; }
        }
        private double sum;              // 总金额

        public double Sum1
        {
            get { return sum; }
            set { sum = value; }
        }
        private string storeKeeper;      // 库管员

        public string StoreKeeper
        {
            get { return storeKeeper; }
            set { storeKeeper = value; }
        }
        private DateTime outStockDate;   // 出库日期

        public DateTime OutStockDate
        {
            get { return outStockDate; }
            set { outStockDate = value; }
        }
        private DateTime tDate;          // 退库日期

        public DateTime TDate
        {
            get { return tDate; }
            set { tDate = value; }
        }
        private string assessor;         // 审核人

        public string Assessor1
        {
            get { return assessor; }
            set { assessor = value; }
        }
        private string checkupMan;       // 审批人

        public string CheckupMan1
        {
            get { return checkupMan; }
            set { checkupMan = value; }
        }
        private DateTime auditingDate;   // 审核日期

        public DateTime AuditingDate1
        {
            get { return auditingDate; }
            set { auditingDate = value; }
        }
        private DateTime checkupDate;    // 审批日期

        public DateTime CheckupDate1
        {
            get { return checkupDate; }
            set { checkupDate = value; }
        }
        private DateTime inputDate;      // 录入记录时间

        public DateTime InputDate1
        {
            get { return inputDate; }
            set { inputDate = value; }
        }
        private string inputMan;         // 录入人

        public string InputMan1
        {
            get { return inputMan; }
            set { inputMan = value; }
        }


    }


    #endregion

    #region//出、退库单详细信息属性类

    /*
   * 类名称：OutStockBillDetailClass
   * 类功能描述：出、退库单详细信息属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-24
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */

    class OutStockBillDetailClass
    {
        private int id;                  // 备件表id

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string osbId;            // 出库单id

        public string OsbId
        {
            get { return osbId; }
            set { osbId = value; }
        }
        private string no;               // 备件编号

        public string No
        {
            get { return no; }
            set { no = value; }
        }
        private string sort;             // 备件种类

        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        private string name;             // 备件名称

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string model;            // 规格型号

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private double unitPrice;        // 单价（库存表取）

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        private string unit;             // 计量单位

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private int count;               // 出库数量

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int tCount;              // 退库数量

        public int TCount
        {
            get { return tCount; }
            set { tCount = value; }
        }
        private double sum;              // 总金额

        public double Sum
        {
            get { return sum; }
            set { sum = value; }
        }
        private DateTime inputDate;      // 录入记录时间

        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }
        private string inputMan;         // 录入人

        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }



    }

    #endregion
    







    #region//设备使用记录

    /*
    * 类名称：EquipmentUse
    * 类功能描述：设备使用记录
    *
    * 创建人：关启学
    * 创建时间：2009-03-22
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class EquipmentUse
    {
        private DateTime date;      //使用年月
        private string no;          //文档编号        
        private long eiId;          //设备信息表ID

        private DateTime inputDate; //录入记录时间
        private string inputMan;    //录入人
        private long id;            //id


        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string No
        {
            get { return no; }
            set { no = value; }
        }

        public long EiId
        {
            get { return eiId; }
            set { eiId = value; }
        }

        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }

        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }


    }


    #endregion

    #region//设备使用记录明细

    /*
    * 类名称：EquipmentUseDetail
    * 类功能描述：设备使用记录明细
    *
    * 创建人：关启学
    * 创建时间：2009-03-22
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    //设备使用记录明细
    class EquipmentUseDetail
    {
        private DateTime useDate;   //使用日期
        private string content;     //工作内容
        private string workTime;    //工作台时
        private string noWorkTime;  //非工作时间（三种选择：机修、气候、待工）
        private string orperateMan; //操作员        
        private long euId;          //设备使用记录表ID

        private DateTime inputDate; //录入记录时间
        private string inputMan;    //录入人

        
        public DateTime UseDate
        {
            get { return useDate; }
            set { useDate = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public string WorkTime
        {
            get { return workTime; }
            set { workTime = value; }
        }

        public string NoWorkTime
        {
            get { return noWorkTime; }
            set { noWorkTime = value; }
        }

        public string OrperateMan
        {
            get { return orperateMan; }
            set { orperateMan = value; }
        }

        public long EuId
        {
            get { return euId; }
            set { euId = value; }
        }

        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }

        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }
    }

    #endregion


    #region//设备保修记录

    /*
    * 类名称：EquipmentRepairPlan
    * 类功能描述：设备保修记录
    *
    * 创建人：关启学
    * 创建时间：2009-03-22
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class EquipmentRepairPlan
    {
        private long id;            //id
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime date;      //计划时间
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private long dId;           //文档表id
        public long DId
        {
            get { return dId; }
            set { dId = value; }
        }

        private string producer;    //制表人
        public string Producer
        {
            get { return producer; }
            set { producer = value; }
        }

        private string assessor;    //审核人
        public string Assessor
        {
            get { return assessor; }
            set { assessor = value; }
        }

        private string checkupMan;  //审批人
        public string CheckupMan
        {
            get { return checkupMan; }
            set { checkupMan = value; }
        }

        private DateTime inputDate; //录入时间
        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }

        private string inputMan;    //录入人
        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }



    }

    #endregion

    #region//设备保修记录明细

    /*
    * 类名称：EquipmentRepairPlanDetail
    * 类功能描述：设备保修记录明细
    *
    * 创建人：关启学
    * 创建时间：2009-03-22
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class EquipmentRepairPlanDetail
    {
        private long id;                        //id
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long eiId;                      //设备信息表id
        public long EiId
        {
            get { return eiId; }
            set { eiId = value; }
        }

        private long dId;                       //部门表id
        public long DId
        {
            get { return dId; }
            set { dId = value; }
        }

        private long erpId;                     //设备保修计划（主表）id
        public long ErpId
        {
            get { return erpId; }
            set { erpId = value; }
        }

        private string serviceKind;             //保修类别
        public string ServiceKind
        {
            get { return serviceKind; }
            set { serviceKind = value; }
        }

        private string workTime;                //工作工时
        public string WorkTime
        {
            get { return workTime; }
            set { workTime = value; }
        }

        private string repairTime;              //维修工时
        public string RepairTime
        {
            get { return repairTime; }
            set { repairTime = value; }
        }

        private decimal planConsume;            //计划费用
        public decimal PlanConsume
        {
            get { return planConsume; }
            set { planConsume = value; }
        }

        private string repairMan;               //主修人
        public string RepairMan
        {
            get { return repairMan; }
            set { repairMan = value; }
        }

        private DateTime finishDate;            //完成时间
        public DateTime FinishDate
        {
            get { return finishDate; }
            set { finishDate = value; }
        }

        private DateTime previousRepairDate;    //上次维修时间
        public DateTime PreviousRepairDate
        {
            get { return previousRepairDate; }
            set { previousRepairDate = value; }
        }

        private string previousServiceKind;     //上次保修类别
        public string PreviousServiceKind
        {
            get { return previousServiceKind; }
            set { previousServiceKind = value; }
        }

        private DateTime inputDate;             //录入时间
        public DateTime InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }

        private string inputMan;                //录入人 
        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }
    }

    #endregion


    #region//备品配件采购计划

    /*
    * 类名称：SparePartStockPlan
    * 类功能描述：备品配件采购计划
    *
    * 创建人：关启学
    * 创建时间：2009-03-24
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    public class SparePartStockPlan
    {
        private long id;                     // 备品配件采购计划id
        private long dId2;                   // 文档id
        private decimal sum;                // 金额
        private long dId;                    // 部门id
        private string proposer;            // 申请人
        private DateTime applicationDate;   // 申请日期
        private string assessor;            // 审核人               
        private string checkupMan;          // 审批人

        private DateTime inputDate;         // 录入时间
        private string inputMan;            // 录入人       


        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public long DId2
        {
            get { return this.dId2; }
            set { this.dId2 = value; }
        }

        public decimal Sum
        {
            get { return this.sum; }
            set { this.sum = value; }
        }

        public long DId
        {
            get { return this.dId; }
            set { this.dId = value; }
        }

        public string Proposer
        {
            get { return this.proposer; }
            set { this.proposer = value; }
        }

        public System.DateTime ApplicationDate
        {
            get { return this.applicationDate; }
            set { this.applicationDate = value; }
        }

        public string Assessor
        {
            get { return this.assessor; }
            set { this.assessor = value; }
        }

        public System.DateTime InputDate
        {
            get { return this.inputDate; }
            set { this.inputDate = value; }
        }

        public string InputMan
        {
            get { return this.inputMan; }
            set { this.inputMan = value; }
        }

        public string CheckupMan
        {
            get { return this.checkupMan; }
            set { this.checkupMan = value; }
        }
    }

    #endregion

    #region//备品配件采购计划明细

    /*
    * 类名称：SparePartStockPlanDetail
    * 类功能描述：备品配件采购计划明细
    *
    * 创建人：关启学
    * 创建时间：2009-03-24
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    public class SparePartStockPlanDetail
    {
        private long id;                    // 备品配件采购计划明细id
        private DateTime inputDate;         // 录入时间
        private string inputMan;            // 录入人
        private DateTime requirementDate;   // 需求人气
        private long spbiId;                // 备品配件基本信息id
        private long currentQuantity;       // 当前库存数量
        private string producer;            // 生产厂商
        private string provider;            // 供应商
        private string contactMan;          // 联系人
        private string contactMethod;       // 联系方式
        private long count;                 // 采购数量
        private long spspId;                // 备品配件采购计划id（主表）
        private decimal unitPrice;          // 采购单价

        public long Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public DateTime InputDate
        {
            get { return this.inputDate; }
            set { this.inputDate = value; }
        }

        public string InputMan
        {
            get { return this.inputMan; }
            set { this.inputMan = value; }
        }

        public DateTime RequirementDate
        {
            get { return this.requirementDate; }
            set { this.requirementDate = value; }
        }

        public long SpbiId
        {
            get { return this.spbiId; }
            set { this.spbiId = value; }
        }

        public string Producer
        {
            get { return this.producer; }
            set { this.producer = value; }
        }

        public string Provider
        {
            get { return this.provider; }
            set { this.provider = value; }
        }

        public string ContactMan
        {
            get { return this.contactMan; }
            set { this.contactMan = value; }
        }

        public string ContactMethod
        {
            get { return this.contactMethod; }
            set { this.contactMethod = value; }
        }

        public long Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        public long SpspId
        {
            get { return this.spspId; }
            set { this.spspId = value; }
        }

        public decimal UnitPrice
        {
            get { return this.unitPrice; }
            set { this.unitPrice = value; }
        }
    }

    #endregion


    #region//备品配件（用于“备品配件采购计划明细”根据备品配件id查询）

    /*
    * 类名称：SparePart
    * 类功能描述：备品配件,用于根据备品配件id查询该备品配件的其他信息
    *
    * 创建人：关启学
    * 创建时间：2009-03-24
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class SparePart
    {
        private long id;                // id
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;            // 备品配件名称
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string sort;            // 备品配件种类
        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        private string model;           // 备品配件规格型号
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private string unit;            // 单位
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        private long maxStock;          // 最大库存
        public long MaxStock
        {
            get { return maxStock; }
            set { maxStock = value; }
        }
        private long minStock;          // 最小库存
        public long MinStock
        {
            get { return minStock; }
            set { minStock = value; }
        }
        private long currentQuantity;   // 当前库存数量
        public long CurrentQuantity
        {
            get { return currentQuantity; }
            set { currentQuantity = value; }
        }


    }

    #endregion


    #region//备品配件入库单

    /*
    * 类名称：SparePartInStock
    * 类功能描述：备品配件入库单
    *
    * 创建人：关启学
    * 创建时间：2009-03-25
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    public class SparePartInStock
    {

        private long id;                // 备品配件入库单id
        private long piId;              // 供应商表id
        private string invoiceNo;       // 发票号
        private string stockMan;        // 采购员
        private DateTime stockDate;     // 采购日期
        private decimal sum;            // 金额
        private DateTime inputDate;     // 录入日期
        private string inputMan;        // 录入人
        private long parentId;          // 自关联id（非空时，用于表明该记录为退货单，并且该列表示相应的入库单id）
        private string remark;          // 备注
        private string assessor;        // 审核人
        private string checkupMan;      // 审批人
        private DateTime auditingDate;  // 审核时间
        private DateTime checkupDate;   // 审批时间

        public long Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public long PiId
        {
            get
            {
                return this.piId;
            }
            set
            {
                this.piId = value;
            }
        }

        public string InvoiceNo
        {
            get
            {
                return this.invoiceNo;
            }
            set
            {
                this.invoiceNo = value;
            }
        }

        public string StockMan
        {
            get
            {
                return this.stockMan;
            }
            set
            {
                this.stockMan = value;
            }
        }

        public DateTime StockDate
        {
            get
            {
                return this.stockDate;
            }
            set
            {
                this.stockDate = value;
            }
        }

        public decimal Sum
        {
            get
            {
                return this.sum;
            }
            set
            {
                this.sum = value;
            }
        }

        public DateTime InputDate
        {
            get
            {
                return this.inputDate;
            }
            set
            {
                this.inputDate = value;
            }
        }

        public string InputMan
        {
            get
            {
                return this.inputMan;
            }
            set
            {
                this.inputMan = value;
            }
        }

        public long ParentId
        {
            get
            {
                return this.parentId;
            }
            set
            {
                this.parentId = value;
            }
        }

        public string Remark
        {
            get
            {
                return this.remark;
            }
            set
            {
                this.remark = value;
            }
        }

        public string Assessor
        {
            get
            {
                return this.assessor;
            }
            set
            {
                this.assessor = value;
            }
        }

        public string CheckupMan
        {
            get
            {
                return this.checkupMan;
            }
            set
            {
                this.checkupMan = value;
            }
        }

        public DateTime AuditingDate
        {
            get
            {
                return this.auditingDate;
            }
            set
            {
                this.auditingDate = value;
            }
        }

        public DateTime CheckupDate
        {
            get
            {
                return this.checkupDate;
            }
            set
            {
                this.checkupDate = value;
            }
        }
    }

    #endregion

    #region//备品配件入库单明细

    /*
    * 类名称：SparePartInStockDetail
    * 类功能描述：备品配件入库单明细
    *
    * 创建人：关启学
    * 创建时间：2009-03-25
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    public class SparePartInStockDetail
    {
        private long id;                // 备品配件入库单明细id
        private long spbiId;            // 备品配件基本信息表id
        private string producer;        // 生产厂商
        private string contactMan;      // 联系人
        private string contactMethod;   // 联系方式
        private long count;             // 采购数量
        private decimal unitPrice;      // 采购单价
        private string storage;         // 仓库名称
        private string position;        // 库位号
        private long spaId;             // 备品配件入库单id（主表）
        private DateTime inputDate;     // 录入时间
        private string inputMan;        // 录入人

        public long Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public long SpbiId
        {
            get
            {
                return this.spbiId;
            }
            set
            {
                this.spbiId = value;
            }
        }

        public string Producer
        {
            get
            {
                return this.producer;
            }
            set
            {
                this.producer = value;
            }
        }

        public string ContactMan
        {
            get
            {
                return this.contactMan;
            }
            set
            {
                this.contactMan = value;
            }
        }

        public string ContactMethod
        {
            get
            {
                return this.contactMethod;
            }
            set
            {
                this.contactMethod = value;
            }
        }

        public long Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return this.unitPrice;
            }
            set
            {
                this.unitPrice = value;
            }
        }

        public string Storage
        {
            get
            {
                return this.storage;
            }
            set
            {
                this.storage = value;
            }
        }

        public string Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public long SpaId
        {
            get
            {
                return this.spaId;
            }
            set
            {
                this.spaId = value;
            }
        }

        public DateTime InputDate
        {
            get
            {
                return this.inputDate;
            }
            set
            {
                this.inputDate = value;
            }
        }

        public string InputMan
        {
            get
            {
                return this.inputMan;
            }
            set
            {
                this.inputMan = value;
            }
        }

    }

    #endregion

    #region//查询对象（针对“备品配件入库单”）

    /*
    * 类名称：SparePartInStockSeacher
    * 类功能描述：查询对象（针对“备品配件入库单”）
    *
    * 创建人：关启学
    * 创建时间：2009-03-26
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    public class SparePartInStockSeacher
    {

        private long inStockId;            // 备品配件入库单id
        public long InStockId
        {
            get { return inStockId; }
            set { inStockId = value; }
        }
        private string stockMan;           // 采购人
        public string StockMan
        {
            get { return stockMan; }
            set { stockMan = value; }
        }
        private DateTime stockDateBegin;   // 采购日期（之后）
        public DateTime StockDateBegin
        {
            get { return stockDateBegin; }
            set { stockDateBegin = value; }
        }

        private DateTime stockDateEnd;    // 采购日期（之前）
        public DateTime StockDateEnd
        {
            get { return stockDateEnd; }
            set { stockDateEnd = value; }
        }

        private string providerName;      // 供应商名称
        public string ProviderName
        {
            get { return providerName; }
            set { providerName = value; }
        }
        private string sparePartNo;       // 物料编码
        public string SparePartNo
        {
            get { return sparePartNo; }
            set { sparePartNo = value; }
        }
        private string sparePartName;     // 物料名称
        public string SparePartName
        {
            get { return sparePartName; }
            set { sparePartName = value; }
        }
        private string sparePartSort;     // 物料种类
        public string SparePartSort
        {
            get { return sparePartSort; }
            set { sparePartSort = value; }
        }
        private string sparePartModel;    // 物料规格型号
        public string SparePartModel
        {
            get { return sparePartModel; }
            set { sparePartModel = value; }
        }


    }

    #endregion


    #region//备品配件库存

    /*
    * 类名称：SparePartStock
    * 类功能描述：备品配件库存
    *
    * 创建人：关启学
    * 创建时间：2009-03-26
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class SparePartStock
    {
        private long id;                // 备品配件库存id
        private long dId;               // 文档编号id

        private long spbiId;            // 备品配件基本信息表id
        private long quantity;          // 库存数量
        private decimal unitPrice;      // 库存价格

        private DateTime inputDate;     // 录入时间
        private string inputMan;        // 录入人
        

        public long Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public long DId
        {
            get
            {
                return this.dId;
            }
            set
            {
                this.dId = value;
            }
        }

        public long SpbiId
        {
            get
            {
                return this.spbiId;
            }
            set
            {
                this.spbiId = value;
            }
        }

        public long Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }

        public DateTime InputDate
        {
            get
            {
                return this.inputDate;
            }
            set
            {
                this.inputDate = value;
            }
        }

        public string InputMan
        {
            get
            {
                return this.inputMan;
            }
            set
            {
                this.inputMan = value;
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return this.unitPrice;
            }
            set
            {
                this.unitPrice = value;
            }
        }
    }

    #endregion
}
