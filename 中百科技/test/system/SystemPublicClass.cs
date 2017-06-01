
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DasherStation.system
{
    #region 车辆属性类
    /*
     * 类名称：TruckClass
     * 类功能描述：车辆属性类
     *
     * 创建人：冯雪
     * 创建时间：2009-02-16
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class TruckClass
    {
        // 车辆信息ID;
        private long id;

        
        // 车牌号
        private string no;
        // 运输单位
        private int conveyancer;
        // 运输单位名称
        private string c_name;

        
        // 车主姓名
        private string owner;
        // 司机姓名
        private string driverName;
        // 车辆型号
        private string model;
        // 车辆颜色
        private string color;
        // 货箱长度
        private decimal? lenth;
        // 货箱宽度
        private decimal? width;
        // 货箱高度
        private decimal? height;
        // 车辆皮重`
        private decimal? tare;
        // 标准空载重量
        private decimal? standardTare;
        // 标准载重量
        private decimal? standardDeadWeight;
        // 录入人；
        private string inputMan;
        // 备注
        private string remark;

        /*
      * 方法名称：Id
      * 方法功能描述：id的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        /*
      * 方法名称：No
      * 方法功能描述：no的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：C_name
      * 方法功能描述：c_name的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string C_name
        {
            get { return c_name; }
            set { c_name = value; }
        }

        /*
      * 方法名称：Conveyancer
      * 方法功能描述：conveyancer的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int  Conveyancer 
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
      * 方法名称：Owner
      * 方法功能描述：conveyancer的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }

        /*
      * 方法名称：DriverName
      * 方法功能描述：conveyancer的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string DriverName
        {
            get
            {
                return driverName;
            }
            set
            {
                driverName = value;
            }
        }

        /*
      * 方法名称：Model
      * 方法功能描述：model的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：Color
      * 方法功能描述：color的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        /*
      * 方法名称：Lenth
      * 方法功能描述：lenth的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? Lenth
        {
            get
            {
                return lenth;
            }
            set
            {
                lenth = value;
            }
        }

        /*
      * 方法名称：Width
      * 方法功能描述：Width的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        /*
      * 方法名称：Height
      * 方法功能描述：Height的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        /*
      * 方法名称：Tare
      * 方法功能描述：tare的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? Tare
        {
            get
            {
                return tare;
            }
            set
            {
                tare = value;
            }
        }

        /*
      * 方法名称：StandardTare
      * 方法功能描述：standardTare的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? StandardTare
        {
            get
            {
                return standardTare;
            }
            set
            {
                standardTare = value;
            }
        }

        /*
      * 方法名称：StandardDeadWeight
      * 方法功能描述：standerdDeadWeight的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? StandardDeadWeight
        {
            get
            {
                return standardDeadWeight;
            }
            set
            {
                standardDeadWeight = value;
            }
        }

        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
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
      * 方法功能描述：remark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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

    #region 运输单位属性类
    /*
     * 类名称：TransportClass
     * 类功能描述：运输单位属性类
     *
     * 创建人：冯雪
     * 创建时间：2009-02-16
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class TransportClass
    {
        // 运输单位ID;
        private long id;
        // 运输单位名称;
        private string name;
        // 法人;
        private string corporation;
        // 单位地址;
        private string address;
        // 运输负责人;
        private string principal;
        // 联系电话;
        private string phone;
        // E-mail;
        private string email;
        // 邮编;
        private string postCode;
        // 运输能力;
        private string capability;
        // 录入人；
        private string inputMan;
        // 备注
        private string remark;

        /*
      * 方法名称：Name
      * 方法功能描述：name的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：Corporation
      * 方法功能描述：corporation的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Corporation
        {
            get
            {
                return corporation;
            }
            set
            {
                corporation = value;
            }
        }

        /*
      * 方法名称：Address
      * 方法功能描述：address的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        /*
      * 方法名称：Principal
      * 方法功能描述：principal的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Principal
        {
            get
            {
                return principal;
            }
            set
            {
                principal = value;
            }
        }

        /*
      * 方法名称：Phone
      * 方法功能描述：phone的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        /*
      * 方法名称：Email
      * 方法功能描述：email的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        /*
      * 方法名称：PostCode
      * 方法功能描述：postCode的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string PostCode
        {
            get
            {
                return postCode;
            }
            set
            {
                postCode = value;
            }
        }

        /*
      * 方法名称：Capability
      * 方法功能描述：capability的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Capability
        {
            get
            {
                return capability;
            }
            set
            {
                capability= value;
            }
        }

        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
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
      * 方法功能描述：remark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：Id
      * 方法功能描述：id的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

    }
    #endregion

    #region   供应商属性类
    /*
     * 类名称：ProviderClass
     * 类功能描述：供应商属性类
     *
     * 创建人：冯雪
     * 创建时间：2009-02-16
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class ProviderClass
    {
        // 供应商ID;
        private long id;
        // 供应商名称
        private string name;
        // 法人;
        private string artificialMan;
        // 材料名称;
        private int miId;
        // 负责人:
        private string principal;
        // 电话;
        private string phone;
        // 邮编;
        private string postCode;
        // e-mail;
        private string eMail;
        // 地址;
        private string address;
        // 录入人;
        private string inputMan;
        // 标明生产许可证编号
        private string produceNo;
        // 供应商类别;
        private int mark;
        // 备注
        private string remark;

        /*
      * 方法名称：Id
      * 方法功能描述：id的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        /*
      * 方法名称：Name
      * 方法功能描述：Name的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：ArtificialMan
      * 方法功能描述：artificialMan的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string ArtificialMan
        {
            get
            {
                return artificialMan;
            }
            set
            {
                artificialMan = value;
            }
        }
        /*
      * 方法名称：MiId
      * 方法功能描述：miId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int MiId
        {
            get
            {
                return miId;
            }
            set
            {
                miId = value;
            }
        }
        /*
      * 方法名称：Principal
      * 方法功能描述：principal的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Principal
        {
            get
            {
                return principal;
            }
            set
            {
                principal = value;
            }
        }
        /*
      * 方法名称：Phone
      * 方法功能描述：phone的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        /*
      * 方法名称：PostCode
      * 方法功能描述：PostCode的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string PostCode
        {
            get
            {
                return postCode;
            }
            set
            {
                postCode = value;
            }
        }
        /*
      * 方法名称：EMail
      * 方法功能描述：eMail的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string EMail
        {
            get
            {
                return eMail;
            }
            set
            {
                eMail = value;
            }
        }
        /*
      * 方法名称：Address
      * 方法功能描述：address的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        /*
      * 方法名称：InputMan
      * 方法功能描述：inputMan的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }
        /*
      * 方法名称：Remark
      * 方法功能描述：remark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：Mark
      * 方法功能描述：mark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        /*
      * 方法名称：ProduceNo
      * 方法功能描述：produceNo的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string ProduceNo
        {
            get { return produceNo; }
            set { produceNo = value; }
        }
    }
    #endregion

    #region 供应商供应材料属性类
    /*
     * 类名称：GMaterialClass
     * 类功能描述：供应商供应材料属性类
     *
     * 创建人：冯雪
     * 创建时间：2009-03-04
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class GMaterialClass
    {   
        // 供应商ID；
        private int providerId;
        // 材料ID；
        private int materialId;
        // 生产厂家ID；
        private int producerId;
        // 运输距离；
        private double distance;
        // 供货能力；
        private string provideCapability;
        // 录入人；
        private string inputMan;
        // 备注;
        private string remark;

        /*
      * 方法名称：ProviderId
      * 方法功能描述：providerId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int ProviderId
        {
            get
            {
                return providerId;
            }
            set
            {
                providerId = value;
            }
        }
        /*
      * 方法名称：MaterialId
      * 方法功能描述：materialId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int MaterialId
        {
            get
            {
                return materialId;
            }
            set
            {
                materialId = value;
            }
        }
        /*
      * 方法名称：ProducerId
      * 方法功能描述：producerId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int ProducerId
        {
            get
            {
                return producerId;
            }
            set
            {
                producerId = value;
            }
        }
        /*
      * 方法名称：Distance
      * 方法功能描述：distance的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public double Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
            }
        }
        /*
      * 方法名称：ProvideCapability
      * 方法功能描述：provideCapability的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string ProvideCapability
        {
            get
            {
                return provideCapability;
            }
            set
            {
                provideCapability = value;
            }
        }
        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
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
      * 方法功能描述：remark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
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

    #region 客户属性类
    /*
     * 类名称：ClientClass
     * 类功能描述：客户属性类
     *
     * 创建人：冯雪
     * 创建时间：2009-02-16
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class ClientClass
    {
        // 客户ID;
        private long id;
        // 客户名称;
        private string name;
        // 法人;
        private string artificialMan;
        // 地址;
        private string address;
        // 负责人;
        private string principal;
        // 电话;
        private string phone;
        // 邮编;
        private string postCode;
        // e-mail;
        private string eMail;
        // 录入人；
        private string inputMan;
        // 备注;
        private string remark;
        
        /*
      * 方法名称：Id
      * 方法功能描述：id的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        /*
      * 方法名称：Name
      * 方法功能描述：name的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：ArtficialMan
      * 方法功能描述：artficialMan的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string ArtficialMan
        {
            get
            {
                return artificialMan;
            }
            set
            {
                artificialMan = value;
            }
        }
        /*
      * 方法名称：Address
      * 方法功能描述：address的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        /*
      * 方法名称：Principal
      * 方法功能描述：principal的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Principal
        {
            get
            {
                return principal;
            }
            set
            {
                principal = value;
            }
        }
        /*
      * 方法名称：Phone
      * 方法功能描述：phone的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        /*
      * 方法名称：PostCode
      * 方法功能描述：postCode的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string PostCode
        {
            get
            {
                return postCode;
            }
            set
            {
                postCode = value;
            }
        }
        /*
      * 方法名称：EMail
      * 方法功能描述：eMail的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string EMail
        {
            get
            {
                return eMail;
            }
            set
            {
                eMail = value;
            }
        }
        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法功能描述：remark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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

    #region 生产设备属性类
    /*
     * 类名称：EquipmentClass
     * 类功能描述：设备属性类
     *
     * 创建人：冯雪
     * 创建时间：2009-02-16
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class EquipmentClass
    {
        // 设备ID;
        private long id;
        // 设备编号;
        private string no;
        // 设备类别;
        private string sort;
        // 设备名称;
        private string name;
        // 规格型号;
        private string model;
        // 设备名称ID;
        private long enId;
        // 设备类别ID;
        private long ekId;
        // 设备规格ID;
        private long emId;
        // 文档的编号;
        private long? dId2;
        // 设备数量；
        private long count;
        // 牌照号码;
        private string registrationMark;
        // 部门id
        private long dId;
        // 安装位置;
        private string installationPosition;
        // 总功率;
        private decimal? sumPower;
        // 增置方式;
        private string addMethod;
        // 设备原值;
        private decimal? primaryValue;
        // 设备残值;
        private decimal? remainsValue;
        // 折旧年限;
        private long depreciationYear;
        // 生产日期;
        private DateTime produceDate;
        // 出厂编号;
        private string factoryNo;
        // 联系方式;
        private string contactMethod;
        // 厂家地址;
        private string factoryAddress;
        // 厂家邮政编码;
        private string postCode;
        // 经办人;
        private string workMan;
        // 联系人;
        private string contactMan;
        // 生产厂家
        private string producer;
        // 额定产量;
        private DateTime inputDate;
        // 投入使用时间;
        private DateTime? beginUseTime;
        // 录入人；
        private string inputMan;
        // 备注;
        private string remark;
        // 沥青罐的直径;
        private decimal? diameter;
        // 沥青罐的高度;
        private decimal? height;
        // 材料ID:
        private long? pId;
        // 产品ID;
        private long? mId;
        // 储罐类型;
        private string potKind;
        // 设备标识
        private string mark;
        // 沥青罐对应液位议编号;
        private long lpnId;
        // 沥青罐对应温度计编号; 
        private long tnId;

        /*
      * 方法名称：LpnId
      * 方法功能描述：lpnId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long LpnId
        {
            get { return lpnId; }
            set { lpnId = value; }
        }
        /*
      * 方法名称：TnId
      * 方法功能描述：tnId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long TnId
        {
            get { return tnId; }
            set { tnId = value; }
        }
        /*
      * 方法名称：Mark
      * 方法功能描述：mark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        /*
      * 方法名称：Id
      * 方法功能描述：id的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        /*
      * 方法名称：No
      * 方法功能描述：no的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：Sort
      * 方法功能描述：sort的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        /*
      * 方法名称：Name
      * 方法功能描述：name的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：EnId
      * 方法功能描述：enId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long EnId
        {
            get
            {
                return enId;
            }
            set
            {
                enId = value;
            }
        }
        /*
      * 方法名称：EkId
      * 方法功能描述：ekId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long EkId
        {
            get { return ekId; }
            set { ekId = value; }
        }
        /*
      * 方法名称：DId2
      * 方法功能描述：dId2的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long? DId2
        {
            get { return dId2; }
            set { dId2 = value; }
        }
        /*
      * 方法名称：Model
      * 方法功能描述：model的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：EmId
      * 方法功能描述：emId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long EmId
        {
            get
            {
                return emId;
            }
            set
            {
                emId = value;
            }
        }
        /*
      * 方法名称：Count
      * 方法功能描述：count的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long Count
        {
            get { return count; }
            set { count = value; }
        }
        /*
      * 方法名称：RegistrationMark
      * 方法功能描述：registrationMark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string RegistrationMark
        {
            get { return registrationMark; }
            set { registrationMark = value; }
        }
        /*
      * 方法名称：DId
      * 方法功能描述：dId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long DId
        {
            get { return dId; }
            set { dId = value; }
        }
        /*
      * 方法名称：InstallationPosition
      * 方法功能描述：installationPosition的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string InstallationPosition
        {
            get { return installationPosition; }
            set { installationPosition = value; }
        }
        /*
      * 方法名称：SumPower
      * 方法功能描述：sumPower的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? SumPower
        {
            get { return sumPower; }
            set { sumPower = value; }
        }
        /*
      * 方法名称：AddMethod
      * 方法功能描述：addMethod的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string AddMethod
        {
            get { return addMethod; }
            set { addMethod = value; }
        }
        /*
      * 方法名称：PrimaryValue
      * 方法功能描述：primaryValue的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? PrimaryValue
        {
            get { return primaryValue; }
            set { primaryValue = value; }
        }
        /*
      * 方法名称：RemainsValue
      * 方法功能描述：remainsValue的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? RemainsValue
        {
            get { return remainsValue; }
            set { remainsValue = value; }
        }
        /*
      * 方法名称：DepreciationYear
      * 方法功能描述：depreciationYear的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long DepreciationYear
        {
            get { return depreciationYear; }
            set { depreciationYear = value; }
        }
        /*
      * 方法名称：WorkMan
      * 方法功能描述：workMan的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string WorkMan
        {
            get { return workMan; }
            set { workMan = value; }
        }
        /*
      * 方法名称：ProduceDate
      * 方法功能描述：produceDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DateTime ProduceDate
        {
            get { return produceDate; }
            set { produceDate = value; }
        }
        /*
      * 方法名称：FactoryNo
      * 方法功能描述：factoryNo的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string FactoryNo
        {
            get { return factoryNo; }
            set { factoryNo = value; }
        }
        /*
      * 方法名称：ContactMethod
      * 方法功能描述：contactMethod的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string ContactMethod
        {
            get { return contactMethod; }
            set { contactMethod = value; }
        }
        /*
      * 方法名称：FactoryAddress
      * 方法功能描述：factoryAddress的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string FactoryAddress
        {
            get { return factoryAddress; }
            set { factoryAddress = value; }
        }
        /*
      * 方法名称：PostCode
      * 方法功能描述：postCode的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }
        /*
      * 方法名称：ContactMan
      * 方法功能描述：contactMan的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-22
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string ContactMan
        {
            get { return contactMan; }
            set { contactMan = value; }
        }
        /*
      * 方法名称：ProducerName
      * 方法功能描述：producerName的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法功能描述：inputDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：BeginUseTime
      * 方法功能描述：beginUseTime的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DateTime? BeginUseTime
        {
            get
            {
                return beginUseTime;
            }
            set
            {
                beginUseTime = value;
            }
        }
        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法功能描述：remark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：Diameter
      * 方法功能描述：diameter的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }
        /*
      * 方法名称：Height
      * 方法功能描述：height的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? Height
        {
            get { return height; }
            set { height = value; }
        }
        /*
      * 方法名称：PId
      * 方法功能描述：pId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long? PId
        {
            get { return pId; }
            set { pId = value; }
        }
        /*
      * 方法名称：MId
      * 方法功能描述：mId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long? MId
        {
            get { return mId; }
            set { mId = value; }
        }
        /*
      * 方法名称：PotKind
      * 方法功能描述：potKind的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string PotKind
        {
            get { return potKind; }
            set { potKind = value; }
        }
    }

    #endregion

    #region 材料属性类
    /*
     * 类名称：MaterialClass
     * 类功能描述：材料属性类
     *
     * 创建人：冯雪
     * 创建时间：2009-02-16
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class MaterialClass
    {
        // 材料ID;
        private long id;

        
        // 材料类别;
        private string kind;
        // 材料类别ID；
        private int mkId;
        // 材料名称;
        private string name;
        // 材料名称ID：
        private int mnId;
        // 规格型号;
        private string model;
        // 规格型号ID；
        private int mmId;
        // 密度;
        private string density;
        // 损耗率;
        private decimal? rate;
        // 最低库存量;
        private decimal? nadirStock;
        // 录入人；
        private string inputMan;
        // 备注;
        private string remark;
        
        /*
      * 方法名称：Id
      * 方法功能描述：id的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        /*
      * 方法名称：Kind
      * 方法功能描述：dind的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Kind
        {
            get
            {
                return kind;
            }
            set
            {
                kind = value;
            }
        }
        /*
      * 方法名称：MkId
      * 方法功能描述：mkId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int MkId
        {
            get
            {
                return mkId;
            }
            set
            {
                mkId = value;
            }
        }
        /*
      * 方法名称：Name
      * 方法功能描述：name的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：MnId
      * 方法功能描述：mnId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int MnId
        {
            get
            {
                return mnId;
            }
            set
            {
                mnId = value;
            }
        }
        /*
      * 方法名称：Model
      * 方法功能描述：model的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：MmId
      * 方法功能描述：mmId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int MmId
        {
            get
            {
                return mmId;
            }
            set
            {
                mmId = value;
            }
        }
        /*
      * 方法名称：Density
      * 方法功能描述：density的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Density
        {
            get
            {
                return density;
            }
            set
            {
                density = value;
            }
        }
        /*
      * 方法名称：Rate
      * 方法功能描述：rate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        /*
      * 方法名称：NadirStock
      * 方法功能描述：nadirStock的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? NadirStock
        {
            get { return nadirStock; }
            set { nadirStock = value; }
        }
        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法功能描述：remark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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

    #region 产品属性类
    /*
     * 类名称：ProductClass
     * 类功能描述：产品属性类
     *
     * 创建人：冯雪
     * 创建时间：2009-02-16
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class ProductClass
    {
        // 产品ID;
        private long id;
        // 产品类别;
        private string kind;
        // 产品类型ID；
        private int pkId;
        // 产品名称;
        private string name;
        // 产品名称ID；
        private int pnId;
        // 规格型号;
        private string model;
        // 规格型号ID；
        private int pmId;
        // 密度
        private string density;
        // 损耗率;
        private decimal? rate;
        // 最低为库存量;
        private decimal? nadirStock;
        // 初始库存量
        private decimal? planPrice;
        // 录入人；
        private string inputMan;
        // 备注;
        private string remark;
        
        /*
      * 方法名称：Id
      * 方法功能描述：id的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        /*
      * 方法名称：Kind
      * 方法功能描述：kind的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Kind
        {
            get
            {
                return kind;
            }
            set
            {
                kind = value;
            }
        }
        /*
      * 方法名称：PkId
      * 方法功能描述：pkId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int PkId
        {
            get
            {
                return pkId;
            }
            set
            {
                pkId = value;
            }
        }
        /*
      * 方法名称：Name
      * 方法功能描述：name的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：PnId
      * 方法功能描述：pnId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int PnId
        {
            get
            {
                return pnId;
            }
            set
            {
                pnId = value;
            }
        }
        /*
      * 方法名称：Model
      * 方法功能描述：model的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：PmId
      * 方法功能描述：pmId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：Density
      * 方法功能描述：density的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Density
        {
            get
            {
                return density;
            }
            set
            {
                density = value;
            }
        }
        /*
      * 方法名称：Rate
      * 方法功能描述：rate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        /*
      * 方法名称：NadirStock
      * 方法功能描述：nadirStock的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? NadirStock
        {
            get { return nadirStock; }
            set { nadirStock = value; }
        }
        /*
      * 方法名称：InitStock
      * 方法功能描述：initStock的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public decimal? PlanPrice
        {
            get { return planPrice; }
            set { planPrice = value; }
        }
        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法功能描述：remark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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

    #region 人员属性类
    /*
     * 类名称：PersonnelClass
     * 类功能描述：人员属性类
     *
     * 创建人：冯雪
     * 创建时间：2009-02-16
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class PersonnelClass
    {
        // 姓名; 
        private string name;
        // 性别;
        private int sex;
        // 职工类别
        private int kind;
        // 年龄;
        private int age;
        // 职位;
        private int pId;
        // 生产班组;
        private int ptId;
        // 录入人；
        private string inputMan;
        // 备注;
        private string remark;

        /*
      * 方法名称：Name
      * 方法功能描述：name的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：Sex
      * 方法功能描述：sex的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }
        /*
      * 方法名称：Kind
      * 方法功能描述：kind的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int Kind
        {
            get
            {
                return kind;
            }
            set
            {
                kind = value;
            }
        }
        /*
      * 方法名称：Age
      * 方法功能描述：age的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        /*
      * 方法名称：PId
      * 方法功能描述：pId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法名称：PId
      * 方法功能描述：pId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int PtId
        {
            get
            {
                return ptId;
            }
            set
            {
                ptId = value;
            }
        }
        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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
      * 方法功能描述：remark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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

    #region 生产厂家属性类
    /*
     * 类名称：ProducerClass
     * 类功能描述：生产厂家属性类
     *
     * 创建人：冯雪
     * 创建时间：2009-03-04
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class ProducerClass
    {
        //生产厂家; 
        private string name;
        //厂家地址;
        private string address;
        //联系电话;
        private string phone; 
        //录入人；
        private string inputMan;
        //备注;
        private string remark;

        /*
      * 方法名称：Name
      * 方法功能描述：name的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
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
      * 方法名称：Address
      * 方法功能描述：address的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        /*
      * 方法名称：Phone
      * 方法功能描述：phone的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
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
      * 方法功能描述：remark的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
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

    #region 选项属性类
    /*
     * 类名称：OptionClass
     * 类功能描述：选项属性类
     *
     * 创建人：冯雪
     * 创建时间：2009-03-06
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class OptionClass
    {
        // 职位；
        private string positionName;
        // 地点；
        private string site;
        // 生产班组名称
        private string pTeamName;
        // 生产部门；
        private string department;
        // 部门人数；
        private int count;
        // 液态罐编号；
        private int liquidPitcherNo;
        // 材料检测指标;
        private string mTestGuideline;
        // 材料检测频率;
        private string mFrequency;
        // 材料ID；
        private int mId;
        // 产品检测指标;
        private string pTestGuideline;
        // 产品检测频率;
        private string pFrequency;
        // 产品ID；
        private int pId;
        // 运输结算方式；
        private string tMethod;
        // 录入人；
        private string inputMan;

        /*
      * 方法名称：TMethod
      * 方法功能描述：tMethod的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string TMethod
        {
            get
            {
                return tMethod;
            }
            set
            {
                tMethod = value;
            }
        }
        /*
      * 方法名称：PFrequency
      * 方法功能描述：pFrequency的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string PFrequency
        {
            get
            {
                return pFrequency;
            }
            set
            {
                pFrequency = value;
            }
        }
        /*
      * 方法名称：MFrequency
      * 方法功能描述：mFrequency的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string MFrequency
        {
            get
            {
                return mFrequency;
            }
            set
            {
                mFrequency = value;
            }
        }
        /*
      * 方法名称：PTestGuideline
      * 方法功能描述：ptestGuideline的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string PTestGuideline
        {
            get
            {
                return pTestGuideline;
            }
            set
            {
                pTestGuideline = value;
            }
        }
        /*
      * 方法名称：MTestGuideline
      * 方法功能描述：mtestGuideline的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string MTestGuideline
        {
            get
            {
                return mTestGuideline;
            }
            set
            {
                mTestGuideline = value;
            }
        }
        /*
      * 方法名称：MId
      * 方法功能描述：mId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-06
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
      * 方法名称：PId
      * 方法功能描述：pId的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-06
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
      * 方法名称：LiquidPitcherNo
      * 方法功能描述：liquidPitcherNo的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int LiquidPitcherNo
        {
            get
            {
                return liquidPitcherNo;
            }
            set
            {
                liquidPitcherNo = value;
            }
        }
        /*
      * 方法名称：Count
      * 方法功能描述：count的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
        /*
      * 方法名称：Department
      * 方法功能描述：department的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
            }
        }
        /*
      * 方法名称：PTeamName
      * 方法功能描述：pTeamName的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string PTeamName
        {
            get
            {
                return pTeamName;
            }
            set
            {
                pTeamName = value;
            }
        }
        /*
      * 方法名称：Site
      * 方法功能描述：site的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Site
        {
            get
            {
                return site;
            }
            set
            {
                site = value;
            }
        }
        /*
      * 方法名称：PositionName
      * 方法功能描述：positionName的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string PositionName
        {
            get
            {
                return positionName;
            }
            set
            {
                positionName = value;
            }
        }
        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        /*
      * 方法名称：InputDate
      * 方法功能描述：inputDate的get\set方法;
      *
      * 创建人：冯雪
      * 创建时间：2009-02-24
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

    #region //用户信息属性类
    /*
    * 类名称：UserInfoClass
    * 类功能描述：用户信息属性类
    *
    * 创建人：夏阳明
    * 创建时间：2009-02-25
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class UserInfoClass
    {
        //用户名
        private string userName;
        //密码
        private string password;
        //真实姓名
        private string name;
        ////性别
        //private int sex;
        ////年龄
        //private int age;
        ////职位
        //private int duty;
        //性别
        private string  sex;
        //年龄
        private string age;
        //职位
        private string duty;

        /*
      * 方法名称：UserName
      * 方法功能描述：UserName的get\set方法;
      *
      * 创建人：夏阳明
      * 创建时间：2009-02-25
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        /*
      * 方法名称：Password
      * 方法功能描述：Password的get\set方法;
      *
      * 创建人：夏阳明
      * 创建时间：2009-02-25
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

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
      * 方法名称：Sex
      * 方法功能描述：Sex的get\set方法;
      *
      * 创建人：夏阳明
      * 创建时间：2009-02-25
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }

        /*
      * 方法名称：Age
      * 方法功能描述：Age的get\set方法;
      *
      * 创建人：夏阳明
      * 创建时间：2009-02-25
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        /*
      * 方法名称：Duty
      * 方法功能描述：Duty的get\set方法;
      *
      * 创建人：夏阳明
      * 创建时间：2009-02-25
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string Duty
        {
            get
            {
                return duty;
            }
            set
            {
                duty = value;
            }
        }
    }
    #endregion
    /*
    * 类名称：BindInfoClass
    * 类功能描述：车卡绑定实体类
    *
    * 创建人：袁宇
    * 创建时间：2009-02-26
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class BindInfoClass
    {        
        //运输单位
        private string unitName;
        //车牌号
        private string voitureNo;
        //车主姓名
        private string owner;
        //车辆名称型号
        private string model;
        //车辆颜色
        private string color;
        //车辆长
        private string lenth;
        //车辆宽
        private string width;
        //车辆高
        private string heigth;
        //车辆皮重
        private string tare;
        //标准空载重量
        private string standardTare;
        //准备载重量
        private string standardDeadWeight;
        //备注信息
        private string remark;
        //卡号
        private string cardNo;
        
        public string UnitName
        {
            get { return unitName; }
            set { unitName = value; }
        }
        public string VoitureNo
        {
            get { return voitureNo; }
            set { voitureNo = value; }
        }
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public string Lenth
        {
            get { return lenth; }
            set { lenth = value; }
        }
        public string Width
        {
            get { return width; }
            set { width = value; }
        }
        public string Heigth
        {
            get { return heigth; }
            set { heigth = value; }
        }
        public string Tare
        {
            get { return tare; }
            set { tare = value; }
        }
        public string StandardTare
        {
            get { return standardTare; }
            set { standardTare = value; }
        }
        public string StandardDeadWeight
        {
            get { return standardDeadWeight; }
            set { standardDeadWeight = value; }
        }
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }
    }

    /// <summary>
    /// 实体类warehouseInfo 。(仓库信息表)
    /// </summary>
    public class warehouseInfo
    {
        public warehouseInfo()
        { }
        #region Model
        private long _id;
        private string _name;
        private string _no;
        private string _remark;
        private DateTime? _inputdate;
        private string _inputman;
        /// <summary>
        /// 
        /// </summary>
        public long id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string no
        {
            set { _no = value; }
            get { return _no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? inputDate
        {
            set { _inputdate = value; }
            get { return _inputdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string inputMan
        {
            set { _inputman = value; }
            get { return _inputman; }
        }
        #endregion Model

    }

    /// <summary>
    /// 实体类projectName 。(工程项目表)
    /// </summary>
    public class projectName
    {
        public projectName()
        { }
        #region Model
        private long _id;
        private string _name;
        private string _position;
        private DateTime? _inputdate;
        private string _unitproject;
        private string _subsectionproject;
        private string _no;
        private string _itemproject;
        private string _inputman;
        /// <summary>
        /// 
        /// </summary>
        public long id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? inputDate
        {
            set { _inputdate = value; }
            get { return _inputdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string unitProject
        {
            set { _unitproject = value; }
            get { return _unitproject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string subsectionProject
        {
            set { _subsectionproject = value; }
            get { return _subsectionproject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string no
        {
            set { _no = value; }
            get { return _no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string itemProject
        {
            set { _itemproject = value; }
            get { return _itemproject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string inputMan
        {
            set { _inputman = value; }
            get { return _inputman; }
        }
        #endregion Model
    }

    /// <summary>
    /// 实体类basicInfo 。(参数)
    /// </summary>
    public class basicInfo
    {
        public basicInfo()
        { }
        #region Model
        private decimal? _maxhydrousimpurityrate;
        private long _asphaltumerror;
        private DateTime? _systemusetime;
        private string _dashername;
        private DateTime? _inputdate;
        private string _inputman;
        private DateTime? _updatedate;
        private string _updateman;
        private string _address;
        private long _piid;
        private string _enterprisekind;
        private string _phone;
        private string _fax;
        private string _postno;
        /// <summary>
        /// 
        /// </summary>
        public decimal? maxHydrousImpurityRate
        {
            set { _maxhydrousimpurityrate = value; }
            get { return _maxhydrousimpurityrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long asphaltumError
        {
            set { _asphaltumerror = value; }
            get { return _asphaltumerror; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? systemUseTime
        {
            set { _systemusetime = value; }
            get { return _systemusetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dasherName
        {
            set { _dashername = value; }
            get { return _dashername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? inputDate
        {
            set { _inputdate = value; }
            get { return _inputdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string inputMan
        {
            set { _inputman = value; }
            get { return _inputman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? updateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string updateMan
        {
            set { _updateman = value; }
            get { return _updateman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long piId
        {
            set { _piid = value; }
            get { return _piid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string enterpriseKind
        {
            set { _enterprisekind = value; }
            get { return _enterprisekind; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string postNo
        {
            set { _postno = value; }
            get { return _postno; }
        }
        #endregion Model

    }

}
