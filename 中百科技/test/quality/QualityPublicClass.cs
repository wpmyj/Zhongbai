using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DasherStation.quality
{


    #region //试验仪器信息属性类
   /*
   * 类名称：ExaminationEquipmentClass
   * 类功能描述：试验仪器信息属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-02-25
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        class ExaminationEquipmentClass
        {
            
            //仪器名
            private string name;
            //型号
            private string model;
            //设备编号
            private string no;
            //生产厂家
            private string maker;
            //单价
            private double unitPrice;
            //检定周期
            private string checkPeriod;
            //折旧年限
            private int depreciationYear;
            //折旧率
            private double depreciationRate;
            //净值
            private double netWorth;
            //累计折旧额
            private double addUpSum;
            //购置日期
            private string buyDate;
            //检定单位
            private string checkUnit;
            //最近检定日期
            private string latestCheckDate;
            //状态
            private string state;
            //备注信息
            private string remark;

            /*
          * 方法名称：Name
          * 方法功能描述：Name的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-25
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
          * 方法名称：Model
          * 方法功能描述：Model的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-25
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public string Model
            {
                get
                {
                    return model;
                }
                set
                {
                    model = value;
                }
            }

            /*
          * 方法名称：No
          * 方法功能描述：No的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-25
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
          * 方法名称：Maker
          * 方法功能描述：Maker的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-25
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public string Maker
            {
                get
                {
                    return maker;
                }
                set
                {
                    maker = value;
                }
            }

            /*
          * 方法名称：UnitPrice
          * 方法功能描述：UnitPrice的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-25
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public double UnitPrice
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
          * 方法名称：CheckPeriod
          * 方法功能描述：CheckPeriod的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-25
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public string CheckPeriod
            {
                get
                {
                    return checkPeriod;
                }
                set
                {
                    checkPeriod = value;
                }
            }
            /*
        * 方法名称：DepreciationYear
        * 方法功能描述：DepreciationYear的get\set方法;
        *
        * 创建人：夏阳明
        * 创建时间：2009-02-25
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
            public int DepreciationYear
            {
                get
                {
                    return depreciationYear;
                }
                set
                {
                    depreciationYear = value;
                }
            }
            /*
            * 方法名称：DepreciationRate
            * 方法功能描述：DepreciationRate的get\set方法;
            *
            * 创建人：夏阳明
            * 创建时间：2009-02-25
            *
            * 修改人：
            * 修改时间：
            * 修改内容：
            *
            */
            public double DepreciationRate
            {
                get
                {
                    return depreciationRate;
                }
                set
                {
                    depreciationRate = value;
                }
            }
            /*
            * 方法名称：NetWorth
            * 方法功能描述：NetWorth的get\set方法;
            *
            * 创建人：夏阳明
            * 创建时间：2009-02-25
            *
            * 修改人：
            * 修改时间：
            * 修改内容：
            *
            */
            public double NetWorth
            {
                get
                {
                    return netWorth;
                }
                set
                {
                    netWorth = value;
                }
            }
            /*
            * 方法名称：AddUpSum
            * 方法功能描述：AddUpSum的get\set方法;
            *
            * 创建人：夏阳明
            * 创建时间：2009-02-25
            *
            * 修改人：
            * 修改时间：
            * 修改内容：
            *
            */
            public double AddUpSum
            {
                get
                {
                    return addUpSum;
                }
                set
                {
                    addUpSum = value;
                }
            }
            /*
           * 方法名称：BuyDate
           * 方法功能描述：BuyDate的get\set方法;
           *
           * 创建人：夏阳明
           * 创建时间：2009-02-25
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
            public string BuyDate
            {
                get
                {
                    return buyDate;
                }
                set
                {
                    buyDate = value;
                }
            }
            /*
          * 方法名称：CheckUnit
          * 方法功能描述：CheckUnit的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-25
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public string CheckUnit
            {
                get
                {
                    return checkUnit;
                }
                set
                {
                    checkUnit = value;
                }
            }
            /*
         * 方法名称：LatestCheckDate
         * 方法功能描述：LatestCheckDate的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-25
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
            public string LatestCheckDate
            {
                get
                {
                    return latestCheckDate;
                }
                set
                {
                    latestCheckDate = value;
                }
            }
            /*
       * 方法名称：State
       * 方法功能描述：State的get\set方法;
       *
       * 创建人：夏阳明
       * 创建时间：2009-02-25
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
            public string State
            {
                get
                {
                    return state;
                }
                set
                {
                    state = value;
                }
            }
            /*
      * 方法名称：Remark
      * 方法功能描述：Remark的get\set方法;
      *
      * 创建人：夏阳明
      * 创建时间：2009-02-25
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

    #region //目标配合比概要信息属性类

        /*
   * 类名称：TargetProportionClass
   * 类功能描述：目标配合比概要信息属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-02-28
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        class TargetProportionClass
        {

            //目标配合比编号(数据库自增长)
            private int id;
            //产品表编号
            private int pmId;
            //制作人姓名
            private string producer;
            //备注信息
            private string remark;
            //输入时间
            private System.DateTime inputDate;
            //录入人姓名
            private string inputMan;

            /*
          * 方法名称：Id
          * 方法功能描述：Id的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法功能描述：PmId的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public int PmId
            {
                get
                {
                    return pmId;
                }
                set
                {
                    pmId = value;
                }
            }

            /*
          * 方法名称：Producer
          * 方法功能描述：Producer的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：Remark
          * 方法功能描述：Remark的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
         * 方法功能描述：InputDate的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
            public System.DateTime InputDate
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
         * 方法名称：InputMan
         * 方法功能描述：InputMan的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
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

            
        }

        #endregion

    #region //目标配合比详细信息属性类

        /*
   * 类名称：TargetProportionDetailClass
   * 类功能描述：目标配合比详细信息属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-02-28
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        class TargetProportionDetailClass
        {

            //目标配合比详细信息序号(数据库自增长)
            private int id;
            //目标配合比编号
            private int tpId;
            //材料名称规格型号对应表id
            private int mnmcId;
            //原料的比例
            private double targetProportionValue;
            //制作人姓名
            private string producer;
            //输入时间
            private System.DateTime inputDate;
            //录入人姓名
            private string inputMan;
            private string address;

            public string Address
            {
                get { return address; }
                set { address = value; }
            }
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private int pId;

            public int PId
            {
                get { return pId; }
                set { pId = value; }
            }

            /*
          * 方法名称：Id
          * 方法功能描述：Id的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：TpId
          * 方法功能描述：TpId的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public int TpId
            {
                get
                {
                    return tpId;
                }
                set
                {
                    tpId = value;
                }
            }

            /*
          * 方法名称：MnmcId
          * 方法功能描述：MnmcId的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public int MnmcId
            {
                get
                {
                    return mnmcId;
                }
                set
                {
                    mnmcId = value;
                }
            }

            /*
          * 方法名称：TargetProportionValue
          * 方法功能描述：TargetProportionValue的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public double TargetProportionValue
            {
                get
                {
                    return targetProportionValue;
                }
                set
                {
                    targetProportionValue = value;
                }
            }

            /*
         * 方法名称：Producer
         * 方法功能描述：Producer的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
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
        * 方法名称：InputDate
        * 方法功能描述：InputDate的get\set方法;
        *
        * 创建人：夏阳明
        * 创建时间：2009-02-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
            public System.DateTime InputDate
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
        * 方法名称：InputMan
        * 方法功能描述：InputMan的get\set方法;
        *
        * 创建人：夏阳明
        * 创建时间：2009-02-28
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

        }

        #endregion

    #region //生产配合比概要信息属性类

        /*
   * 类名称：ProduceProportionClass
   * 类功能描述：生产配合比概要信息属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-05
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        class ProduceProportionClass
        {

            //生产配合比编号(数据库自增长)
            private int id;
            //产品表编号
            private int pId;
            //制作人姓名
            private string producer;
            //备注信息
            private string remark;
            //输入时间
            private System.DateTime inputDate;
            //录入人姓名
            private string inputMan;

            /*
          * 方法名称：Id
          * 方法功能描述：Id的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法功能描述：PmId的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：Producer
          * 方法功能描述：Producer的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：Remark
          * 方法功能描述：Remark的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
         * 方法功能描述：InputDate的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
            public System.DateTime InputDate
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
         * 方法名称：InputMan
         * 方法功能描述：InputMan的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
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


        }

        #endregion

    #region //生产配合比详细信息属性类

        /*
   * 类名称：ProduceProportionDetailClass
   * 类功能描述：生产配合比详细信息属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-05
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        class ProduceProportionDetailClass
        {

            //生产配合比详细信息序号(数据库自增长)
            private int id;
            //生产配合比编号
            private int ppId;
            //热料仓名称
            private string produceProportion;
            //原料的比例
            private double produceProportionValue;
            //制作人姓名
            private string producer;
            //输入时间
            private System.DateTime inputDate;
            //录入人姓名
            private string inputMan;

            /*
          * 方法名称：Id
          * 方法功能描述：Id的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：PpId
          * 方法功能描述：PpId的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public int PpId
            {
                get
                {
                    return ppId;
                }
                set
                {
                    ppId = value;
                }
            }

            /*
          * 方法名称：ProduceProportion
          * 方法功能描述：ProduceProportion的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public string ProduceProportion
            {
                get
                {
                    return produceProportion;
                }
                set
                {
                    produceProportion = value;
                }
            }

            /*
          * 方法名称：ProduceProportionValue
          * 方法功能描述：ProduceProportionValue的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public double ProduceProportionValue
            {
                get
                {
                    return produceProportionValue;
                }
                set
                {
                    produceProportionValue = value;
                }
            }

            /*
         * 方法名称：Producer
         * 方法功能描述：Producer的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
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
        * 方法名称：InputDate
        * 方法功能描述：InputDate的get\set方法;
        *
        * 创建人：夏阳明
        * 创建时间：2009-02-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
            public System.DateTime InputDate
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
        * 方法名称：InputMan
        * 方法功能描述：InputMan的get\set方法;
        *
        * 创建人：夏阳明
        * 创建时间：2009-02-28
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

        }

        #endregion

    #region //沥青概要信息属性类

        /*
   * 类名称：ProportionClass
   * 类功能描述：沥青概要信息属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-06
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        class ProportionClass
        {

            //配合比编号(数据库自增长)
            private int id;
            //产品表编号
            private int pId;
            //标识位
            private int mark2;
            //制作人姓名
            private string producer;
            //备注信息
            private string remark;
            //输入时间
            private System.DateTime inputDate;
            //录入人姓名
            private string inputMan;

            /*
          * 方法名称：Id
          * 方法功能描述：Id的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：PId
          * 方法功能描述：PId的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：Mark2
          * 方法功能描述：Mark2的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public int Mark2
            {
                get
                {
                    return mark2;
                }
                set
                {
                    mark2 = value;
                }
            }

            /*
          * 方法名称：Producer
          * 方法功能描述：Producer的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：Remark
          * 方法功能描述：Remark的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
         * 方法功能描述：InputDate的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
            public System.DateTime InputDate
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
         * 方法名称：InputMan
         * 方法功能描述：InputMan的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
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


        }

        #endregion

    #region //沥青详细信息属性类

        /*
   * 类名称：ProportionDetailClass
   * 类功能描述：沥青详细信息属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-06
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        class ProportionDetailClass
        {

            //配合比详细信息序号(数据库自增长)
            private int id;
            //配合比编号
            private int pId;
            //原料名称表Id
            private int mId;
            //原料的比例
            private double proportionValue;
            //制作人姓名
            private string producer;
            //输入时间
            private System.DateTime inputDate;
            //录入人姓名
            private string inputMan;
            private string address;

            public string Address
            {
                get { return address; }
                set { address = value; }
            }
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private int ppId; //厂商id

            public int PpId
            {
                get { return ppId; }
                set { ppId = value; }
            }

            /*
          * 方法名称：Id
          * 方法功能描述：Id的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：PId
          * 方法功能描述：PId的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：MId
          * 方法功能描述：Proportion的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public int MId
            {
                get
                {
                    return mId;
                }
                set
                {
                    mId = value;
                }
            }

            /*
          * 方法名称：ProportionValue
          * 方法功能描述：ProportionValue的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public double ProportionValue
            {
                get
                {
                    return proportionValue;
                }
                set
                {
                    proportionValue = value;
                }
            }

            /*
         * 方法名称：Producer
         * 方法功能描述：Producer的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
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
        * 方法名称：InputDate
        * 方法功能描述：InputDate的get\set方法;
        *
        * 创建人：夏阳明
        * 创建时间：2009-02-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
            public System.DateTime InputDate
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
        * 方法名称：InputMan
        * 方法功能描述：InputMan的get\set方法;
        *
        * 创建人：夏阳明
        * 创建时间：2009-02-28
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

        }

        #endregion

    #region //检验项目管理属性类

        /*
   * 类名称：MaterialTestGuidelineClass
   * 类功能描述：检验项目管理属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-07
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
      public class MaterialTestGuidelineClass
        {

            //材料检测指标序号(数据库自增长)
            private int id;
            //材料表编号
            private int mId;
            private int verityBit;     // 标识是产品还是材料

            public int VerityBit
            {
                get { return verityBit; }
                set { verityBit = value; }
            }
            private string sort;

            public string Sort
            {
                get { return sort; }
                set { sort = value; }
            }
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private string model;

            public string Model
            {
                get { return model; }
                set { model = value; }
            }
            //检验的频率
            private string frequency;
            //合格指标
            private string guideline;
            //检测指标
            private string testGuideline;
            //输入时间
            private System.DateTime inputDate;
            //录入人姓名
            private string inputMan;
            //备注
            private string remark;

            /*
          * 方法名称：Id
          * 方法功能描述：Id的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：MId
          * 方法功能描述：MId的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public int MId
            {
                get
                {
                    return mId;
                }
                set
                {
                    mId = value;
                }
            }

            /*
          * 方法名称：Frequency
          * 方法功能描述：Frequency的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public string Frequency
            {
                get
                {
                    return frequency;
                }
                set
                {
                    frequency = value;
                }
            }

            /*
          * 方法名称：Guideline
          * 方法功能描述：Guideline的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public string Guideline
            {
                get
                {
                    return guideline;
                }
                set
                {
                    guideline = value;
                }
            }

            /*
         * 方法名称：TestGuideline
         * 方法功能描述：TestGuideline的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
            public string TestGuideline
            {
                get
                {
                    return testGuideline;
                }
                set
                {
                    testGuideline = value;
                }
            }

            /*
        * 方法名称：InputDate
        * 方法功能描述：InputDate的get\set方法;
        *
        * 创建人：夏阳明
        * 创建时间：2009-02-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
            public System.DateTime InputDate
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
        * 方法名称：InputMan
        * 方法功能描述：InputMan的get\set方法;
        *
        * 创建人：夏阳明
        * 创建时间：2009-02-28
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
       * 方法功能描述：Remark的get\set方法;
       *
       * 创建人：夏阳明
       * 创建时间：2009-02-28
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

    #region //配合比发送单属性类

        /*
   * 类名称：ProportionSendClass
   * 类功能描述：配合比发送单属性类
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-09
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        public class ProportionSendClass
        {

            //发送配合比表序号(数据库自增长)
            private int id;
            //产品种类
            private string sort;
            //产品名称
            private string name;
            //规格型号
            private string model;
            //通知时间
            private System.DateTime inputDate;
            //通知人姓名
            private string inputMan;
            //确认时间
            private System.DateTime confirmDate;
            //备注
            private string remark;
            //设备编号
            private string eiId;

            /*
          * 方法名称：Id
          * 方法功能描述：Id的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：Sort
          * 方法功能描述：Sort的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public string Sort
            {
                get
                {
                    return sort;
                }
                set
                {
                    sort = value;
                }
            }

            /*
          * 方法名称：Name
          * 方法功能描述：Name的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
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
          * 方法名称：Model
          * 方法功能描述：Model的get\set方法;
          *
          * 创建人：夏阳明
          * 创建时间：2009-02-28
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
            public string Model
            {
                get
                {
                    return model;
                }
                set
                {
                    model = value;
                }
            }

            /*
         * 方法名称：InputDate
         * 方法功能描述：inputDate的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
            public DateTime InputDate
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
         * 方法名称：InputMan
         * 方法功能描述：InputMan的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
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
        * 方法名称：ConfirmDate
        * 方法功能描述：ConfirmDate的get\set方法;
        *
        * 创建人：夏阳明
        * 创建时间：2009-02-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
            public System.DateTime ConfirmDate
            {
                get
                {
                    return confirmDate;
                }
                set
                {
                    confirmDate = value;
                }
            }


            /*
       * 方法名称：Remark
       * 方法功能描述：Remark的get\set方法;
       *
       * 创建人：夏阳明
       * 创建时间：2009-02-28
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
         * 方法名称：EiId
         * 方法功能描述：EiId的get\set方法;
         *
         * 创建人：夏阳明
         * 创建时间：2009-02-28
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
            public string EiId
            {
                get
                {
                    return eiId;
                }
                set
                {
                    eiId = value;
                }
            }

        }

        #endregion
    }
