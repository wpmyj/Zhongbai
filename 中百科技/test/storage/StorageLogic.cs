using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DasherStation.storage
{
    class StorageLogic
    {
    }

    #region 入库台帐逻辑层方法
    /*
     * 类名称：StockInRLogic
     * 类功能描述：入库台帐逻辑层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-11
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class StockInRLogic
    {
        StockInRDB stockInRDB = new StockInRDB();
        /*
        * 方法名称：MaterialINSearch()
        * 方法功能描述：材料入库统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable MaterialINSearch(StockInRClass stockclass,int mkId,int mnId)
        {
            return stockInRDB.MaterialINSearch(stockclass, mkId, mnId);
        }

        /*
        * 方法名称：MaterialOutSearch()
        * 方法功能描述：材料入库统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable MaterialOutSearch(string sqlWhere)
        {
            return stockInRDB.MaterialOutSearch(sqlWhere);
        }

        /*
        * 方法名称：providerSearch()
        * 方法功能描述：入库供应商查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable providerSearch()
        {
            return stockInRDB.providerSearch();
        }

        /*
        * 方法名称：SearchEquipmentNO()
        * 方法功能描述：查询所有设备的编号
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchEquipmentNO()
        {
            return stockInRDB.SearchEquipmentNO();
        }
        /*
        * 方法名称：GetMaterialSQL()
        * 方法功能描述：生成按用户输入条件查询SQL语句
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string GetMaterialSQL(StockMOutRClass stockMOut, int mkId, int mnId)
        {
            return stockInRDB.GetMaterialSQL(stockMOut,mkId,mnId);
        }

        /*
        * 方法名称：Material_Assess()
        * 方法功能描述：材料台账审核方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Material_Assess(string state, long id, string assessor)
        {
            return stockInRDB.Material_Assess(state, id, assessor);
        }

        /*
        * 方法名称：Material_Checkup()
        * 方法功能描述：材料台账审批方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Material_Checkup(string state, long id, string checkup)
        {
            return stockInRDB.Material_Checkup(state, id, checkup);
        }
    }

    #endregion

    #region 产品台帐数据层方法

    /*
     * 类名称：StockOutRLogic
     * 类功能描述：产品台帐数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-11
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class StockOutRLogic
    {
        StockOutRDB stockODB = new StockOutRDB();
        /*
        * 方法名称：ProudctINSearch()
        * 方法功能描述： 产品入库统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-13
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable ProudctOutSearch(StockOutRClass stockORClass,int pkId,int pnId)
        {
            return stockODB.ProudctOutSearch(stockORClass, pkId, pnId);
        }

         /*
        * 方法名称：GetMaterialSQL()
        * 方法功能描述：生成按用户输入条件查询SQL语句
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string GetProudctSQL(StockPInRClass stockPIclass, int pkId, int pnId)
        {
            return stockODB.GetProudctSQL(stockPIclass,pkId,pnId);
        }

        /*
        * 方法名称：SearchClient()
        * 方法功能描述：查询所有客户名称
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchClient()
        {
            return stockODB.SearchClient();
        }

        /*
        * 方法名称：ProudctOutSearch()
        * 方法功能描述：产品入库统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable ProudctInSearch(string sqlWhere)
        {
            return stockODB.ProudctInSearch(sqlWhere);
        }

        /*
        * 方法名称：Proudct_Assess()
        * 方法功能描述：产品台账审核方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Proudct_Assess(string state, long id, string assessor)
        {
            return stockODB.Proudct_Assess(state, id, assessor);
        }

        /*
        * 方法名称：Proudct_Checkup()
        * 方法功能描述：产品台账审批方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Proudct_Checkup(string state, long id, string checkup)
        {
            return stockODB.Proudct_Checkup(state, id, checkup);
        }
    }
    #endregion

    #region 库存统计窗体数据层方法

    /*
     * 类名称：StockStatLogic
     * 类功能描述：库存统计窗体逻辑层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-16
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class StockStatLogic
    {
        StockStatDB stockStatDB = new StockStatDB();

        /*
        * 方法名称：OutStat()
        * 方法功能描述：产品库统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable OutStat()
        {
            return stockStatDB.OutStat();
        }

        /*
        * 方法名称：InStat()
        * 方法功能描述：材料库统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable InStat()
        {
            return stockStatDB.InStat();
        }

        /*
        * 方法名称：Stock_Material()
        * 方法功能描述：材料库存数量和金额计算方法;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-09
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Stock_Material()
        {
            return stockStatDB.Stock_Material();
        }

        /*
        * 方法名称：Stock_Product()
        * 方法功能描述：产品库存数量和金额计算方法;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-09
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Stock_Product()
        {
            return stockStatDB.Stock_Product();
        }
    }
    #endregion

    #region 库存盘点与休正逻辑层方法
    /*
     * 类名称：StockCheckRLogic
     * 类功能描述：库存盘点与休正逻辑层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-11
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class StockCheckRLogic
    {
        StockCheckRDB stockCheckDB = new StockCheckRDB();
        // 库存盘点材料种类、名称、规格联动方法；
        /*
        * 方法名称：SearchPMKind()
        * 方法功能描述：查询材料库存统计表中所有材料的种类
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPMKind()
        {
            return stockCheckDB.SearchPMKind();
        }
        /*
        * 方法名称：SearchPName()
        * 方法功能描述：根据库存统计表中的材料种类查询该种类下的所有材料厂名称
        *
        * 创建人：冯雪
        * 创建时间：2009-03-19
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPMName(long pkId)
        {
            return stockCheckDB.SearchPMName(pkId);
        }
        /*
        * 方法名称：SearchPModel()
        * 方法功能描述：根据库存统计表中的材料种类查询该种类下的所有材料规格
        *
        * 创建人：冯雪
        * 创建时间：2009-03-19
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPMModel(long pkId)
        {
            return stockCheckDB.SearchPMModel(pkId);
        }

        // 库存盘点产品种类、名称、规格联动方法；
        /*
        * 方法名称：SearchPPKind()
        * 方法功能描述：查询产品库存统计表中所有产品的种类
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPPKind()
        {
            return stockCheckDB.SearchPPKind();
        }
        /*
        * 方法名称：SearchPPName()
        * 方法功能描述：根据库存统计表中的产品种类查询该种类下的所有产品厂名称
        *
        * 创建人：冯雪
        * 创建时间：2009-03-19
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPPName(long mkId)
        {
            return stockCheckDB.SearchPPName(mkId);
        }
        /*
        * 方法名称：SearchPPModel()
        * 方法功能描述：根据库存统计表中的产品种类查询该种类下的所有产品规格
        *
        * 创建人：冯雪
        * 创建时间：2009-03-19
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPPModel(long mkId)
        {
            return stockCheckDB.SearchPPModel(mkId);
        }

        // 盘点时在材料库存表、产品库存表中，取出该材料、产品帐面库存量
        /*
        * 方法名称：SearchPMQuantity()
        * 方法功能描述：在材料库存表中，取出该材料帐面库存量
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPMQuantity(long mId)
        {
            return stockCheckDB.SearchPMQuantity(mId);
        }
        /*
        * 方法名称：SearchPPSuttle()
        * 方法功能描述：在产品库存表中，取出该产品帐面库存量
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPPSuttle(long PId)
        {
            return stockCheckDB.SearchPPSuttle(PId);
        }

        // 盘点材料、产品库存，向原料、产品库存修正表中插入盘点过后的数据
        /*
        * 方法名称：InsertPMaterial()
        * 方法功能描述：盘点材料库存，向原料库存修正表中插入盘点过后的数据
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertPMaterial(CheckStockClass checkstockClass)
        {
            return stockCheckDB.InsertPMaterial(checkstockClass);
        }
        /*
        * 方法名称：InsertPProduct()
        * 方法功能描述：盘点产品库存，向产品库存修正表中插入盘点过后的数据
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertPProduct(CheckStockClass checkstockClass)
        {
            return stockCheckDB.InsertPProduct(checkstockClass);
        }

        //查询盘点过的材料、产品库存信息；
        /*
        * 方法名称：SearchCheckM()
        * 方法功能描述：查询盘点过的材料库存信息
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchCheckM()
        {
            return stockCheckDB.SearchCheckM();
        }
        /*
        * 方法名称：SearchCheckP()
        * 方法功能描述：查询盘点过的产品库存信息
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchCheckP()
        {
            return stockCheckDB.SearchCheckP();
        }

    }
    #endregion

    #region 产品入库逻辑层方法
    /*
     * 类名称：ProductInDepotLogic
     * 类功能描述：产品入库逻辑层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-04-10
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class ProductInDepotLogic
    {
        ProductInDepotDB productID = new ProductInDepotDB();

        /*
        * 方法名称：SearchplanPrice()
        * 方法功能描述：查询该产品的计划单价
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string SearchplanPrice(long pId)
        {
            return productID.SearchplanPrice(pId);
        }

        /*
        * 方法名称：InsertProductInDepot()
        * 方法功能描述：插入产品手工入库存信息
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertProductInDepot(ProductInDepotClass pInDepot)
        {
            return productID.InsertProductInDepot(pInDepot);
        }
    }
    #endregion

    #region 材料出库数据层方法
    /*
     * 类名称：MaterialOutDepotLogic
     * 类功能描述：材料出库逻辑层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-04-10
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class MaterialOutDepotLogic
    {
        MaterialOutDepotDB mOutDepotDB = new MaterialOutDepotDB();
        /*
        * 方法名称：SearchplanPrice()
        * 方法功能描述：查询该材料的计划单价
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string SearchplanPrice(long mId)
        {
            return mOutDepotDB.SearchplanPrice(mId);
        }

        /*
        * 方法名称：InsertMaterialOutDepot()
        * 方法功能描述：插入材料出库信息
        *
        * 创建人：冯雪
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertMaterialOutDepot(MaterialOutDepotClass mOutDepot)
        {
            return mOutDepotDB.InsertMaterialOutDepot(mOutDepot);
        }
    }
    #endregion
}
