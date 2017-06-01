/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：
     * 文件功能描述：采购逻辑层
     *
     * 创建人：付中华
     * 创建时间：2009-3-2
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using DasherStation.common;

namespace DasherStation.stock
{
    public class StockLogic
    {


    }
    //采购计划类
    public class stockPlanLogic
    {
        DataSet ds = new DataSet();
        SqlHelper sqlHelper = new SqlHelper();
        stockPlanDb stockPlanDb = new stockPlanDb();
        //按年份查询
        public void compareYear(int startyear, int endyear, DataGridView dgv)
        {
            if (startyear <= endyear)
            {
                ds = stockPlanDb.compareYear(startyear, endyear);
                dgv.DataSource = ds.Tables[0];

            }
            else
            {
                MessageBox.Show("起始年份不能大于结束年份");
            }
        }
        //采购计划主界面的主表信息
        public DataTable prochaseSchemainLogic()
        {
            return stockPlanDb.prochaseSchemain();
        }
        //调用采购计划的级联删除主表及从表全部删除
        public bool stockPlanDeletelogic(int id)
        {
            bool status;
            status = stockPlanDb.stockPlanDelete(id);

            return status;
        }
    }
    //采购计划明细类
    public class purchaseScheDetaillogic
    {
        DataSet ds = new DataSet();
        purchaseSchedetailDb purchadetail = new purchaseSchedetailDb();
        stockPlanDb stockPlanDb = new stockPlanDb();
        SqlHelper sqlHelper = new SqlHelper();
        #region
        public MaterialClass getObj(MaterialClass material)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from material");
            if (material != null)
            {
                strSql.Append(" where 1=1 ");
                if (material.id != null)
                {
                    strSql.Append(" and id='" + material.id + "'");
                }
                if (material.inputDate != null)
                {
                    strSql.Append(" and inputDate='" + material.inputDate + "'");
                }
                if (material.inputMan != null)
                {
                    strSql.Append(" and inputMan='" + material.inputMan + "'");
                }
                if (material.mnId != null)
                {
                    strSql.Append(" and mnId ='" + material.mnId + "'");
                }
                if (material.mmId != null)
                {
                    strSql.Append(" and mmId='" + material.mmId + "'");
                }
                if (material.density != null)
                {
                    strSql.Append(" and density='" + material.density + "'");
                }
                if (material.remark != null)
                {
                    strSql.Append(" and remark='" + material.remark + "'");
                }
            }
            return purchadetail.queryObj(strSql.ToString());
        }
        #endregion
        #region//添加采购计划明细的一行
        public void stockPlanDetailAdd(StockPlanDetailClass stockPlanDetail, DataTable dt, string sort, string name, string model)
        {
            DataRow dr = dt.NewRow();
            dr["id"] = stockPlanDetail.id;
            dr["sort"] = sort;
            dr["name"] = name;
            dr["model"] = model;

            dr["january"] = stockPlanDetail.january;
            dr["february"] = stockPlanDetail.february;
            dr["march"] = stockPlanDetail.march;
            dr["april"] = stockPlanDetail.april;
            dr["may"] = stockPlanDetail.may;
            dr["june"] = stockPlanDetail.june;
            dr["july"] = stockPlanDetail.july;
            dr["august"] = stockPlanDetail.august;
            dr["september"] = stockPlanDetail.september;
            dr["october"] = stockPlanDetail.october;
            dr["november"] = stockPlanDetail.november;
            dr["december"] = stockPlanDetail.december;
            dr["quantity"] = stockPlanDetail.quantity;
            dr["mId"] = stockPlanDetail.mId;
            dr["inputDate"] = stockPlanDetail.inputDate;

            dt.Rows.Add(dr);

        }
        #endregion
        //制作人的初始化
        public DataTable makerComboboxlogic()
        {
            return purchadetail.makerCombobox();
        }
        #region//调用种类名称规格的方法
        public DataTable materialKindlogic()
        {
            return purchadetail.materialKind();
        }
        public DataTable materialNamelogic(int kindId, int providerId)
        {
            return purchadetail.materialName(kindId,providerId);
        }
        public DataTable materialNamelogic(int kindId)
        {
            return purchadetail.materialName(kindId);
        }
        public DataTable materialModellogic(int nameId, int providerId)
        {
            return purchadetail.materialModel(nameId, providerId);
        }
        public DataTable materialModellogic(int nameId)
        {
            return purchadetail.materialModel(nameId);
        }
        #endregion
        //批量保存的方法
        public bool saveStockPlanAdd(StockPlanClass stockPlan, List<StockPlanDetailClass> list)
        {
            ArrayList sqlList = new ArrayList();
            sqlList.Add(stockPlanDb.insertStockPlan(stockPlan));
            foreach (StockPlanDetailClass stockPlanDetail in list)
            {
                sqlList.Add(purchadetail.insertStockPlanDetail(stockPlanDetail));
            }
            return sqlHelper.Insert(sqlList);
            //return false;
            ////return new stockPlanDb().insertStockPlan(stockPlan, list);
           
        }
        //采购计划明细表的信息
        public DataTable prochaseSchedetaillogic(int id)
        {
            return purchadetail.prochaseSchedetail(id);
        }

        /*
        * 方法名称：findMinStockAndIdLogic
        * 方法功能描述：根据材料名称和材料规格查找最小库存量逻辑类
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable findMinStockAndIdLogic(long mnId, long mmId)
        {
            return purchadetail.findMinStockAndId(mnId, mmId);
        }

        /*
       * 方法名称：
       * 方法功能描述：根据材料名称和材料规格查找到的id值对应库存列表中的mId取出现有库存量逻辑类
       * 参数: 
       * 
       * 创建人：付中华
       * 创建时间：2009-04-11
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public string findNowStockLogic(long id)
        {
            return purchadetail.findNowStock(id);
        }

        /*
      * 方法名称：materialNeedPlanShowLogic
      * 方法功能描述：调出分类统计出材料需求计划表中的内容
      * 参数: 
      * 
      * 创建人：付中华
      * 创建时间：2009-04-11
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataTable materialNeedPlanShowLogic(string year)
        {
            return purchadetail.materialNeedPlanShow(year);
        }

    }
    //采购合同类
    public class stockContractLogic
    {
        stockContractDb stockContractdb = new stockContractDb();
        //SqlHelper sqlHelper = new SqlHelper();

        #region//调用供应商信息的方法
        public DataTable initialProviderLogin()
        {
            return stockContractdb.initialProvider();
        }
        #endregion
        #region//调用合同制作人的方法
        public DataTable initialMakerLogic()
        {
            return stockContractdb.initialMaker();
        }
        #endregion
        #region//确定供应商后调出的材料种类的方法
        public DataTable initialSortLogic(int providerId)
        {
            return stockContractdb.initialSort(providerId);
        }
        #endregion
        #region//调用合同编号方法
        public DataTable initialContractNo()
        {
            return stockContractdb.initialContractNo();
        }
        // 当获得主合同编号时查询供应商的值返回到界面
        public DataTable findConveyAncer(int id)
        {
            return stockContractdb.findConveyAncerdb(id);
        }
        #endregion
        //调用主合同的查询信息
        public DataTable getContractListLogic(string strWhere, string contractStatus)
        {
            return stockContractdb.getContractList(strWhere, contractStatus);
        }
        //调用由主合同得出的合同明细
        public DataTable getContractListDetailLogic(int mainId)
        {
            return stockContractdb.getContractListDetail(mainId);
        }
        //2009-4-16  合同状态的绑定
        public void contractStatus(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("value");

            DataRow dr = dt.NewRow();
            dr["id"] = "all";
            dr["value"] = "显示全部信息";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["id"] = "hasFinish";
            dr["value"] = "已终止合同";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["id"] = "notFinish";
            dr["value"] = "未终止合同";
            dt.Rows.Add(dr);

            cmb.DataSource = dt;
            cmb.DisplayMember = "value";
            cmb.ValueMember = "id";
        }
        //查询条件的绑定
        public void QueryBind(ComboBox cmb)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Value");

            DataRow row = table.NewRow();
            row["id"] = "";
            row["Value"] = "无条件";
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = "sc.no";
            row["Value"] = "合同编号";
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = "sc.name";
            row["Value"] = "合同名称";
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = "pr.name";
            row["Value"] = "供应商名称";
            table.Rows.Add(row);

            cmb.DataSource = table;
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "Value";
            cmb.SelectedIndex = -1;
        }
        //级联终止合同
        public bool endContractandDetailLogic(int id)
        {
            bool status;
            status = stockContractdb.endContractandDetail(id);

            return status;
        }
        //仅终止合同
        public bool endContractandDetailLogicOnly(int id)
        {
            bool status;
            status = stockContractdb.endContractandDetail(id);

            return status;
        }
        //调出主合同对应打所有明细行数
        public DataTable totalMainIdLogic(int mainId)
        {
            return stockContractdb.totalMainId(mainId);
        }
        //查询已经终止的合同明细个数
        public DataTable condtotalDetailLogic(int mainId)
        {
            return stockContractdb.condtotalDetail(mainId);
        }
        // 给定合同编号找到parentId 的值
        public DataTable finishMarkTableLogic(int mainId)
        {
            return stockContractdb.finishMarkTable(mainId);
        }


        // 终止主合同及其相关的所有
        public bool endMainContractLogic(int mainId)
        {
            return stockContractdb.endMainContract(mainId);
        }
        // 终止分合同
        public bool endSupplyContractLogic(int supplyId, int parentId)
        {
            return stockContractdb.endSupplyContract(supplyId, parentId);
        }
        // 终止主合同明细
        public bool endMainContractDetailLogic(int mainContractDetailId, int mainContractId)
        {
            return stockContractdb.endMainContractDetail(mainContractDetailId, mainContractId);
        }
        // 终止分合同明细
        public bool endSupplyContractDetailLogic(int supplyDetailId, int parentId)
        {
            return stockContractdb.endSupplyContractDetail(supplyDetailId, parentId);
        }
        // 判断是否都终止
        public bool isEndAll(int mainId, int parentId)
        {
            return stockContractdb.isEndAll(mainId, parentId);
        }
    }
    //采购合同明细
    public class stockContractDetailLogic
    {
        stockContractDetailDb stockContractDetailDb = new stockContractDetailDb();
        SqlHelper sqlHelper = new SqlHelper();
        public void indentNewRow(Indent indent, DataTable dt, string cbm_materialKind, string materialInformation, string materialModel)
        {
            DataRow dr = dt.NewRow();
            dr["id"] = indent.id;
            dr["mid"] = indent.mId;

            dr["sort"] = cbm_materialKind;
            dr["materialInformation"] = materialInformation;
            dr["materialModel"] = materialModel;

            dr["quantity"] = indent.quantity;
            dr["unitPrice"] = indent.unitPrice;
            dr["inputMan"] = indent.inputMan;
            dr["inputDate"] = indent.inputDate;
            if (indent.finishMark)
            {
                dr["finishMark"] = "执行";
            }
            else
            {
                dr["finishMark"] = "可编辑";
            }
            //dr["finishMark"] = indent.finishMark ? "执行" : "可编辑";

            dt.Rows.Add(dr);
        }
        public bool StockContractAdd(stockContract stockContract, List<Indent> list)
        {
            ArrayList sqlLIst = new ArrayList();
            sqlLIst.Add(stockContractDetailDb.getInsertSqlMain(stockContract));
            foreach (Indent indent in list)
            {
                sqlLIst.Add(stockContractDetailDb.getInsertSqlSub(indent));
            }
            return sqlHelper.ExecuteTransaction(sqlLIst);
        }
        //终止合同明细
        public bool endContractandDetailLogic(int id)
        {
            bool status;
            status = stockContractDetailDb.endContractandDetail(id);

            return status;
        }
        // 判断合同名称在数据库表中是否存在
        public bool compareContractNameLogic(string contractName)
        {
            return stockContractDetailDb.compareContractName(contractName);
        }
        // 判读合同编号在数据库中是否存在
        public bool compareContractNoLogic(string contractNo)
        {
            return stockContractDetailDb.compareContractNo(contractNo);
        }
        // 根据供应商的名称去查找他的Id值
        public int findProviderId(string providerName)
        {
            return Convert.ToInt32(stockContractDetailDb.findProviderIdDb(providerName).Rows[0][0].ToString());
        }
    }

    //采购核算
    public class stockSettlementLogic
    {
        stockSettlementDb stockSettlementdb = new stockSettlementDb();
        SqlHelper sqlHelper = new SqlHelper();
        //调用采购核算上的合同信息
        public DataTable getContractListLogic(string strWhere)
        {
            return stockSettlementdb.getStockSettlementList(strWhere);
        }
        //调用初始化采购核算的合同名称
        public DataTable initialContractComboboxLogic()
        {
            return stockSettlementdb.initialContractCombobox();
        }
        // 维护采购核算的合同名称重新调用
        public DataTable initialContractComboboxSupplyLogic()
        {
            return stockSettlementdb.initialContractComboboxSupply();
        }
        //选中合同后获得合同对应的明细信息
        public DataTable correspondingContractDetailInfoLogic(long mainId)
        {
            return stockSettlementdb.correspondingContractDetailInfo(mainId);
        }
        //给定条码值查询出它所有的信息
        public DataTable barCodeInfoLogic(string barCode)
        {
            return stockSettlementdb.barCodeInfo(barCode);
        }
        // 给定条码值查询他是否已经结算过了
        public DataTable checkBarCode(string barCode)
        {
            return stockSettlementdb.checkBarCodeDb(barCode);
        }
        //提取核算单小票数据
        public DataTable GetStockNote(string scId)
        {
            return stockSettlementdb.SelectStockCheck(scId); 
        }
        //核算和核算明细的保存
        public long saveStockSettlementAdd(stockMaterialSettlement stockSet, List<stockMaterialSettlementDetail> list)
        {
            ArrayList sqlList = new ArrayList();
            sqlList.Add(stockSettlementdb.insertStockSettlement(stockSet));
            foreach (stockMaterialSettlementDetail stockSetDetail in list)
            {
                sqlList.Add(stockSettlementdb.insertStockSettlementDetail(stockSetDetail));
            }
            
            if (sqlHelper.Insert(sqlList))
            {
                return stockSettlementdb.GetMaxInRecId();
            }
            else
            {
                return -1;
            }
            
        }
        //插入小票信息
        public bool saveMaterialNoteCorresponding(List<stockMaterialNoteCorresponding> info,List<string> UpdateInfo)
        {
            ArrayList sqlList = new ArrayList();
            foreach (stockMaterialNoteCorresponding node in info)
            {
                sqlList.Add(stockSettlementdb.InsertStockNote(node));
            }
            foreach (string str in UpdateInfo)
            {
                sqlList.Add(stockSettlementdb.UpdateStockNode(str));
            }
            return sqlHelper.Insert(sqlList);
        }
        
        //返回要插入Id
        public DataTable getNeedIdLogic()
        {
            return stockSettlementdb.getNeedId();
        }
        /*
        * 方法名称：FindStockSettlement
        * 方法功能描述：查询核算主表   
        * 参数: contractNo 合同编号  contractName 合同名称 providerName 供应商信息     
        * 返回: DataTable
        * 创建人：袁宇
        * 创建时间：2009-03-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable FindStockSettlement(string contractNo, string contractName, string providerName)
        {
            return stockSettlementdb.SelectStockMaterialSettlement(contractNo, contractName, providerName);
        }
        /*
       * 方法名称：SetFindFieldItem
       * 方法功能描述：设备查询字段下拉   
       * 参数: cb 下拉列表框     
       * 返回: 
       * 创建人：袁宇
       * 创建时间：2009-03-11
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void SetFindFieldItem(ref ComboBox cb)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Value");

            DataRow row = table.NewRow();
            row["Id"] = "all";
            row["Value"] = "全部";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Id"] = "1";
            row["Value"] = "合同编号";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Id"] = "2";
            row["Value"] = "合同名称";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Id"] = "3";
            row["Value"] = "供应商名称";
            table.Rows.Add(row);
           

            cb.DataSource = table;
            cb.DisplayMember = "Value";
            cb.ValueMember = "Id";
        }
        public long GetDetailNo(string SettlementNo,string indentId)
        {
            return stockSettlementdb.GetMaterialSettlementDetailNo(SettlementNo, indentId); 
        }

    }

    // 采购统计逻辑层
    public class stockStaticsLogic
    {
        stockStaticsDb stockStaticsdb = new stockStaticsDb();      
        public void queryBind(ComboBox cmb)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Value");

            DataRow row = table.NewRow();
            row["id"] = "material";
            row["Value"] = "材料";
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = "provider";
            row["Value"] = "供应商";
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = "transportUnit";
            row["Value"] = "运输单位";
            table.Rows.Add(row);

            cmb.DataSource = table;
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "Value";
        }       
        // 按材料年
        public DataTable stockMaterialSelectlogic(string endyear)
        {
            return stockStaticsdb.stockMaterialSelect(endyear);
        }
        // 按材料时间段
        public DataTable stockMaterialIntervalSelectLogic(string startyear, string endyear)
        {
            return stockStaticsdb.stockMaterialIntervalSelect(startyear, endyear);
        }
        #region// 年度和按时间段的差集中的行用来与时间段上显示的数据相合并
        public DataRow[] GetA(DataTable dtMain, DataTable dtSecond)
        {
            var result1 = from DataRow oRow1 in dtMain.Rows
                          select oRow1["mid"].ToString();
            var result2 = from DataRow oRow2 in dtSecond.Rows
                          select oRow2["mid"].ToString();

            var result = result1.Except(result2);
            StringBuilder strResult = new StringBuilder();
            foreach (var I in result)
            {
                if (strResult.Length == 0)
                {
                    strResult.Append(I);
                }
                else
                {
                    strResult.Append("," + I);
                }
            }

            if (!string.IsNullOrEmpty(strResult.ToString()))
            {
                var B = dtMain.Select(string.Format("mid in ({0}) ", strResult.ToString()));
                foreach (DataRow row in B)
                {
                    row["inweight"] = System.DBNull.Value;
                    row["notecount"] = System.DBNull.Value;
                }
                return B;
            }
            return new DataRow[] { };
        }
        #endregion
        // 按运输单位统计
        public DataTable stockTransportUnitLogic(string startyear, string endyear)
        {
            return stockStaticsdb.stockTransportUnit(startyear, endyear);
        }
        // 按供应商统计
        public DataTable stockProviderInfoLogic(string startyear, string endyear)
        {
            return stockStaticsdb.stockProviderInfo(startyear, endyear);
        }
    }
}

