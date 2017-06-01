using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DasherStation.storage
{
    class StoragePublicClass
    {
    }

    /*
     * 类名称：StockInRClass
     * 类功能描述：入库台帐类
     *
     * 创建人：冯雪
     * 创建时间：2009-03-11
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    public class StockInRClass
    {
        // 材料ID;
        private long mid;
        // 供应商ID;
        private long providerid;
        // 运输公司ID;    
        private long transportid;
        // 车牌ID;
        private long voitureid;
        // 开始日期;
        private string beginTime;
        // 结束日期;
        private string endTime;
        // 审核、审批状态；
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public long Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        public long Providerid
        {
            get { return providerid; }
            set { providerid = value; }
        }

        public long Transportid
        {
            get { return transportid; }
            set { transportid = value; }
        }

        public long Voitureid
        {
            get { return voitureid; }
            set { voitureid = value; }
        }

        public string BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
    }

    /*
     * 类名称：StockMOutRClass
     * 类功能描述：材料出库台帐类
     *
     * 创建人：冯雪
     * 创建时间：2009-03-12
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    public class StockMOutRClass
    {
        // 材料ID;
        private long mid;
        // 设备ID;
        private long equipmentid;
        // 开始日期;
        private string beginTime;
        // 结束日期;
        private string endTime;
        // 审核、审批状态；
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public long Mid
        {
            get { return mid; }
            set { mid = value; }
        }
        
        public long Equipmentid
        {
            get { return equipmentid; }
            set { equipmentid = value; }
        }
 
        public string BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
    }

    /*
    * 类名称：StockOutRClass
    * 类功能描述：产品出库台帐类
    *
    * 创建人：冯雪
    * 创建时间：2009-03-13
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    public class StockOutRClass
    {
        // 产品ID;
        private long pid;
        // 客户ID;
        private long clientid;
        // 运输公司ID;    
        private long transportid;
        // 车牌ID;
        private long voitureid;
        // 开始日期;
        private string beginTime;
        // 结束日期;
        private string endTime;
        // 审核、审批状态；
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public long Pid
        {
            get { return pid; }
            set { pid = value; }
        }      
        public long Clientid
        {
            get { return clientid; }
            set { clientid = value; }
        }
        public long Transportid
        {
            get { return transportid; }
            set { transportid = value; }
        }
                public long Voitureid
        {
            get { return voitureid; }
            set { voitureid = value; }
        }
        public string BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }
        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
    }

    /*
     * 类名称：StockPInRClass
     * 类功能描述：产入出库台帐类
     *
     * 创建人：冯雪
     * 创建时间：2009-03-12
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    public class StockPInRClass
    {
        // 材料ID;
        private long pid;
        // 设备ID;
        private long equipmentid;
        // 开始日期;
        private string beginTime;
        // 结束日期;
        private string endTime;
        // 审核、审批状态；
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public long Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public long Equipmentid
        {
            get { return equipmentid; }
            set { equipmentid = value; }
        }

        public string BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
    }

    /*
     * 类名称：CheckStock
     * 类功能描述：库存盘点类
     *
     * 创建人：冯雪
     * 创建时间：2009-03-20
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class CheckStockClass
    {
        // 材料库存表ID
        private long mslId;
        // 产品库存表ID
        private long pslId;
        // 盘点库存量
        private decimal? checkStock;
        // 差异量；
        private decimal? balance;
        // 修正值；
        private decimal? retouch;
        // 修正后的库存；
        private decimal? retouchStock;
        // 录入人；
        private string inputMan;
        // 差异原因
        private string remark;
        // 盘点日期；
        private string inputDate; 
        
        public long MslId
        {
            get { return mslId; }
            set { mslId = value; }
        }
        public long PslId
        {
            get { return pslId; }
            set { pslId = value; }
        }
        public decimal? CheckStock
        {
            get { return checkStock; }
            set { checkStock = value; }
        }
        public decimal? Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public decimal? Retouch
        {
            get { return retouch; }
            set { retouch = value; }
        }
        public decimal? RetouchStock
        {
            get { return retouchStock; }
            set { retouchStock = value; }
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
        public string InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }
    }

    /*
     * 类名称：ProductInDepotClass
     * 类功能描述：产品手工入库
     *
     * 创建人：冯雪
     * 创建时间：2009-04-10
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class ProductInDepotClass
    {
        // 产品ID;
        private long pid;
        // 入库数量;
        private decimal number;
        // 产品入库单价;
        private decimal unitPrice;
        // 设备ID;
        private long eiId;
        // 录入人;
        private string inputMan;
        // 是否为自动获取的数据;
        private string computationMark;
  
        public long Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        public decimal Number
        {
            get { return number; }
            set { number = value; }
        }
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }        
        public long EiId
        {
            get { return eiId; }
            set { eiId = value; }
        }
        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }
        public string ComputationMark
        {
            get { return computationMark; }
            set { computationMark = value; }
        }

    }

    /*
     * 类名称：MaterialOutDepotClass
     * 类功能描述：材料手工出库
     *
     * 创建人：冯雪
     * 创建时间：2009-04-10
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class MaterialOutDepotClass
    {
        // 材料ID;
        private long mid;
        // 生产产品ID;
        private long pid;
        // 出库数量;
        private decimal number;
        // 材料库单价;
        private decimal unitPrice;
        // 设备ID;
        private long eiId;
        // 录入人;
        private string inputMan;
        // 是否为自动获取的数据;
        private string computationMark;

        public long Mid
        {
            get { return mid; }
            set { mid = value; }
        }
        public long Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        public decimal Number
        {
            get { return number; }
            set { number = value; }
        }
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        public long EiId
        {
            get { return eiId; }
            set { eiId = value; }
        }
        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }
        public string ComputationMark
        {
            get { return computationMark; }
            set { computationMark = value; }
        }
    }

}
