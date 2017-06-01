using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Collections;
using DasherStation.common;
using System.Windows.Forms;

namespace DasherStation.sell
{
    class SellLogic
    {
    }

    #region 销售合同窗体逻辑层方法
    /*
     * 类名称：SalesContractLogic
     * 类功能描述：销售合同窗体逻辑层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-02-25
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */

    class SalesContractLogic
    {
        SalesContractDB salesContractDB = new SalesContractDB();
        /*
        * 方法名称：
        * 方法功能描述：终止分合同
        *
        * 创建人：付中华
        * 创建时间：2009-4-18
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */        
        public bool endSupplyContractLogic(int supplyId, int parentId)
        {
            return salesContractDB.endSupplyContract(supplyId, parentId);
        }
        /*
        * 方法名称：
        * 方法功能描述：判断是否都终止
        *
        * 创建人：付中华
        * 创建时间：2009-4-18
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */         
        public bool isEndAll(int mainId, int parentId)
        {
            return salesContractDB.isEndAll(mainId, parentId);
        }
        /*
      * 方法名称：
      * 方法功能描述：终止主合同明细
      *
      * 创建人：付中华
      * 创建时间：2009-4-18
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool endMainContractDetailLogic(int mainContractDetailId, int mainContractId)
        {
            return salesContractDB.endMainContractDetail(mainContractDetailId, mainContractId);
        }
        /*
     * 方法名称：
     * 方法功能描述：终止分合同明细
     *
     * 创建人：付中华
     * 创建时间：2009-4-18
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */       
        public bool endSupplyContractDetailLogic(int supplyDetailId, int parentId)
        {
            return salesContractDB.endSupplyContractDetail(supplyDetailId, parentId);
        }

        /*
        * 方法名称：FrmSalesCSearch()
        * 方法功能描述：
        *
        * 创建人：冯雪
        * 创建时间：2009-02-25
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable FrmSalesCSearch(string Condition, int verifyBit)
        {
             return salesContractDB.FrmSalesCSearch(Condition, verifyBit);
        }
        /*
      * 方法名称：
      * 方法功能描述：
      *
      * 创建人：付中华
      * 创建时间：2009-04-18
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataTable getContractListLogic(string strWhere, string contractStatus)
        {
            return salesContractDB.getContractList(strWhere, contractStatus);
        }
        /*
     * 方法名称：
     * 方法功能描述：查询条件的绑定
     *
     * 创建人：付中华
     * 创建时间：2009-04-18
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */      
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
            row["id"] = "cI.name";
            row["Value"] = "供应商名称";
            table.Rows.Add(row);

            cmb.DataSource = table;
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "Value";
            cmb.SelectedIndex = -1;
        }
        /*
     * 方法名称：
     * 方法功能描述：合同状态的绑定
     *
     * 创建人：付中华
     * 创建时间：2009-04-18
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
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

        /*
        * 方法名称：FrmSalesCSearchList()
        * 方法功能描述：查询合同明细的详细内容;
        *
        * 创建人：冯雪
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable FrmSalesCSearchList(int id)
        {
            return salesContractDB.FrmSalesCSearchList(id);
        }

        /*
        * 方法名称：SearchinvoiceList()
        * 方法功能描述：查询合同下的合同明细是否全部终止;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-08
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool SearchinvoiceList(int contractId)
        {
            return salesContractDB.SearchinvoiceList(contractId);
        }

        /*
        * 方法名称：FrmSalesCStop()
        * 方法功能描述：终止合同及该合同下的所有明细;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-08
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmSalesCStop(int contractId)
        {
            return salesContractDB.FrmSalesCStop(contractId);
        }

        /*
        * 方法名称：Contract_Assess()
        * 方法功能描述：销售合同审核方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-13
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Contract_Assess(long id, string assessor)
        {
            return salesContractDB.Contract_Assess(id, assessor);
        }

        /*
        * 方法名称：Contract_Checkup()
        * 方法功能描述：销售合同审批方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-13
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Contract_Checkup(long id, string checkup)
        {
            return salesContractDB.Contract_Checkup(id, checkup);
        }

    }
    #endregion

    #region 新建销售合同窗体逻辑层方法
    /*
      * 类名称: AddSalesContractLogic
      * 类功能描述：新建销售合同窗体逻辑层方法
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class AddSalesContractLogic
    {
        AddSalesContractDB addSalesContractDB = new AddSalesContractDB();

        /*
        * 方法名称：InitialASalesComboBox()
        * 方法功能描述：查询所有未终止的合同编号;
        *
        * 创建人：冯雪
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable InitialASalesComboBox(int state)
        {
            return addSalesContractDB.InitialASalesComboBox(state);
        }
        /*
        * 方法名称：initialMakerLogic
        * 方法功能描述：初始化合同制作人
        *
        * 创建人：付中华
        * 创建时间：2009-04-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable initialMakerLogic()
        {
            return addSalesContractDB.initialMakerDb();
        }
        /*
       * 方法名称：findClientNameLogic
       * 方法功能描述：根据选中的主合同编号后查找出客户名称显示到界面上同时保证其不可修改
       *
       * 创建人：付中华
       * 创建时间：2009-04-17
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable findClientNameLogic(int id)
        {
            return addSalesContractDB.findClientNameDb(id);
        }
        /*
      * 方法名称：
      * 方法功能描述：判断合同名称在数据库表中是否存在
      *
      * 创建人：付中华
      * 创建时间：2009-04-18
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool compareContractNameLogic(string contractName)
        {
            return addSalesContractDB.compareContractName(contractName);
        }
        /*
      * 方法名称：
      * 方法功能描述：判断合同编号在数据库表中是否存在
      *
      * 创建人：付中华
      * 创建时间：2009-04-19
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool compareContractNoLogic(string contractNo)
        {
            return addSalesContractDB.compareContractNo(contractNo);
        }


        /*
        * 方法名称：ASalesSearchNO()
        * 方法功能描述：查询要插入的合同编号、合同名称是否已存在表中;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool ASalesSearchNO(string scNo, string scName)
        {
            return addSalesContractDB.ASalesSearchNO(scNo, scName);
        }

        public bool SellContractAdd(SalesContractClass scClass, List<InvoiceClass> list)
        {
            return addSalesContractDB.SellContractAdd(scClass,list);
        }
        /*
        * 方法名称：SearchPersonnel()
        * 方法功能描述：查询要插入的合同制作人是否已存在于人员信息表中;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool SearchPersonnel(string name)
        {
            return addSalesContractDB.SearchPersonnel(name);
        }

        /*
        * 方法名称：FrmASalesStop()
        * 方法功能描述：终止合同明细 ;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-07
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmASalesStop(int id)
        {
            return addSalesContractDB.FrmASalesStop(id);
        }
        /*
        * 方法名称：SearchClientInfo()
        * 方法功能描述：在客户信息表中查询所有客户信息;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchClient()
        {
            return addSalesContractDB.SearchClient();
        }
        /*
        * 方法名称：DataGrilViedAddRow()
        * 方法功能描述：向table中增加一行;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-07
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void DataGrilViedAddRow(InvoiceClass invoiceClass, DataTable dt, string pKind, string pName, string pModel)
        {           
            DataRow dr = dt.NewRow();

            dr["id"] = invoiceClass.Id;
            dr["pid"] = invoiceClass.PId;

            dr["sort"] = pKind;
            dr["name"] = pName;
            dr["model"] = pModel;

            dr["quantity"] = invoiceClass.Quantity;
            dr["unitPrice"] = invoiceClass.UnitPrice;
            dr["inputMan"] = invoiceClass.InputMan;
            dr["inputDate"] = invoiceClass.InputDate;
            dr["finishMark"] = invoiceClass.FinishMark ? "执行" : "可编辑";
            
            dt.Rows.Add(dr);
        }

    }

    


    #endregion

     #region  销售计划窗体逻辑层方法
    /*
     * 类名称：SellPlanLogic
     * 类功能描述：销售计划窗体逻辑层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-08
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class SellPlanLogic
    {
        SellPlanDB sellPlanDB = new SellPlanDB();

        /*
        * 方法名称：FrmSPlanSearch()
        * 方法功能描述：
        *
        * 创建人：冯雪
        * 创建时间：
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable FrmSPlanSearch(string beginYear,string endYear)
        {
            return sellPlanDB.FrmSPlanSearch(beginYear,endYear);
        }
        /*
        * 方法名称：FrmSPlanDetailSearch()
        * 方法功能描述：
        *
        * 创建人：冯雪
        * 创建时间：
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable FrmSPlanDetailSearch(long sellPlanId)
        {
            return sellPlanDB.FrmSPlanDetailSearch(sellPlanId);
        }
        /*
        * 方法名称：FrmSPlanDelete()
        * 方法功能描述：
        *
        * 创建人：冯雪
        * 创建时间：
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmSPlanDelete(int sellPlanId)
        {
            return sellPlanDB.FrmSPlanDelete(sellPlanId);
        }

        /*
        * 方法名称：Proudct_Assess()
        * 方法功能描述：销售计划审核方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-13
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Plan_Assess(long id, string assessor)
        {
            return sellPlanDB.Plan_Assess(id, assessor);
        }

        /*
        * 方法名称：Proudct_Checkup()
        * 方法功能描述：销售计划审批方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-13
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Plan_Checkup(long id, string checkup)
        {
            return sellPlanDB.Plan_Checkup(id,checkup);
        }
    }
     #endregion

    #region 新建销售计划窗体逻辑层方法
    /*
     * 类名称：VenditionPlanLogic
     * 类功能描述：新建销售计划窗体逻辑层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-09
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class VenditionPlanLogic
    {
        VenditionPlanDB venditionPlanDB = new VenditionPlanDB();
        SqlHelper sqlHelper = new SqlHelper();
        /*
        * 方法名称：DataGrilViedAddRow()
        * 方法功能描述：向table中增加一行;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-07
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void DataGrilViedAddRow(sellPlanDetailClass sPDclass, DataTable dt, string pKind, string pName, string pModel)
        {
            DataRow dr = dt.NewRow();

            dr["id"] = sPDclass.Id;
            dr["pId"] = sPDclass.PId;

            dr["sort"] = pKind;
            dr["name"] = pName;
            dr["model"] = pModel;

            dr["january"] = sPDclass.January;
            dr["february"] = sPDclass.February;
            dr["march"] = sPDclass.March;
            dr["april"] = sPDclass.April;
            dr["may"] = sPDclass.May;
            dr["june"] = sPDclass.June;
            dr["july"] = sPDclass.July;
            dr["august"] = sPDclass.August;
            dr["september"] = sPDclass.September;
            dr["october"] = sPDclass.October;
            dr["november"] = sPDclass.November;
            dr["december"] = sPDclass.December;
            dr["quantity"] = sPDclass.Quantity;
            dr["inputDate"] = sPDclass.InputDate;
            dr["spId"] = sPDclass.SpId;

            dt.Rows.Add(dr);
        }
 
        public bool saveSellPlanAdd(sellPlanClass sellPlanClass, List<sellPlanDetailClass> list)
        {
            return venditionPlanDB.saveSellPlanAdd(sellPlanClass, list);
        }
    }
    
    #endregion

    #region 销售统计数据层方法
    /*
     * 类名称：SalesStatisticsLogic
     * 类功能描述：销售统计逻辑层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-10
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class SalesStatisticsLogic
    {
        SalesStatisticsDB salesSDB = new SalesStatisticsDB();
        /*
        * 方法名称：StatisticsSearchAll()
        * 方法功能描述：销售统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-10
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable ProductSearchAll(string beginTime, string endTime, int verifyBit)
        {
            return salesSDB.ProductSearchAll(beginTime, endTime, verifyBit);
        }
    }
    #endregion

    #region 销售核算逻辑层方法
    /*
     * 类名称：SalesSettlementLogic
     * 类功能描述：销售核算逻辑层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-17
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class SalesSettlementLogic
    {
        SalesSettlementDB salesSDB = new SalesSettlementDB();

        /*
        * 方法名称：SettlementSearch()
        * 方法功能描述：在销售核算表中根据条件查询
        *
        * 创建人：冯雪
        * 创建时间：2009-03-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SettlementSearch(string condition, int verifyBit)
        {
            return salesSDB.SettlementSearch(condition, verifyBit);
        }

        /*
        * 方法名称：SettlementDisplay()
        * 方法功能描述：选择一条销售核算明细显示;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-18
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SettlementDisplay(long spsId)
        {
            return salesSDB.SettlementDisplay(spsId);
        }

        /*
        * 方法名称：SearchCNo()
        * 方法功能描述：在销售合同中查询所在未结算的合同编号
        *
        * 创建人：冯雪
        * 创建时间：2009-03-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchCNo()
        {
            return salesSDB.SearchCNo();
        }

        /*
        * 方法名称：SearchCInvoice()
        * 方法功能描述：在销售合同明细中查询该合同所有的明细信息
        *
        * 创建人：冯雪
        * 创建时间：2009-03-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchCInvoice(long scId)
        {
            return salesSDB.SearchCInvoice(scId);
        }

        /*
        * 方法名称：SearchSellNote()
        * 方法功能描述：根据输入的条码号查询票据信息
        *
        * 创建人：冯雪
        * 创建时间：2009-03-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchSellNote(string barCode)
        {
            return salesSDB.SearchSellNote(barCode);
        }

        /*
        * 方法名称：SellNoteDisplay()
        * 方法功能描述：选择一条销售核算记录显示该明细下所有核算过后的票据信息
        *
        * 创建人：冯雪
        * 创建时间：2009-03-18
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SellNoteDisplay(long scId)
        {
            return salesSDB.SellNoteDisplay(scId);
        }

        /*
        * 方法名称：SearchNote()
        * 方法功能描述：根据输入的条码号查询票据信息
        *
        * 创建人：冯雪
        * 创建时间：2009-03-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void SearchNote(string barCode, DataTable dt)
        {
            
            DataTable dataTable = new DataTable();
            SettlementNoteClass sclass =  salesSDB.SearchNote(barCode);

            if (sclass != null)
            {
                DataRow dr = dt.NewRow();
 
                dr["id"] = sclass.Id;
                dr["iId"] = sclass.IId;

                dr["barCode"] = sclass.BarCode;
                dr["inputDate"] = sclass.InputDate;
                dr["scname"] = sclass.Scname;
                
                dr["sort"] = sclass.Sort;
                dr["name"] = sclass.Name;
                dr["model"] = sclass.Model;

                dr["grossWeight"] = sclass.GrossWeight;
                dr["tare"] = sclass.Tare;
                dr["suttle"] = sclass.Suttle; 
                dr["cname"] = sclass.Cname;
                dr["sId1"] = sclass.SId1;
                dr["sId2"] = sclass.SId2;

                dt.Rows.Add(dr);
            }
            
            


        }

        /*
        * 方法名称：SearchCMark()
        * 方法功能描述：在发货票据表中查询该小票是否核算过.
        *
        * 创建人：冯雪
        * 创建时间：2009-03-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool SearchCMark(string barCode)
        {
            return salesSDB.SearchMark(barCode);
        }

        /*
        * 方法名称：SearchMarkExist()
        * 方法功能描述：在发货票据表中查询该小票是存在.
        *
        * 创建人：冯雪
        * 创建时间：2009-03-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool SearchMarkExist(string barCode)
        {
            return salesSDB.SearchMarkExist(barCode);
        }

        /*
        * 方法名称：SearchCExist()
        * 方法功能描述：在发货票据是否属于选定的合同.
        *
        * 创建人：冯雪
        * 创建时间：2009-03-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool SearchCExist(long id, string barCode)
        {
            return salesSDB.SearchCExist(id, barCode);
        }

        /*
        * 方法名称：InsertSPSettlement()
        * 方法功能描述：向销售核算表中插入核算记录.
        *
        * 创建人：冯雪
        * 创建时间：2009-03-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertSPSettlement(PSettlementClass psClass, string username, DataGridView dgvMain, DataGridView dgvDetail)
        {
            return salesSDB.InsertSPSettlement(psClass, username, dgvMain, dgvDetail);
        }

        /*
        * 方法名称：Settlement_Assess()
        * 方法功能描述：销售核算审核方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-13
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Settlement_Assess(long id, string assessor)
        {
            return salesSDB.Settlement_Assess(id, assessor);
        }

        /*
        * 方法名称：Settlement_Checkup()
        * 方法功能描述：销售核算审批方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-13
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Settlement_Checkup(long id, string checkup)
        {
            return salesSDB.Settlement_Checkup(id, checkup);
        }
    }
    #endregion

}
