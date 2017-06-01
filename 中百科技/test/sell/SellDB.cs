using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DasherStation.common;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using DasherStation.system;
using System.Windows.Forms;
using DasherStation.storage;

namespace DasherStation.sell
{
   
    class SellDB
    {
    }

    #region 销售合同窗体数据层方法

    /*
     * 类名称：SalesContractDB
     * 类功能描述：销售合同窗体数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-02-25
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class SalesContractDB
    {
        DataSet ds = new DataSet();
        SqlHelper sqlHelper = new SqlHelper();

        /*
       * 方法名称：
       * 方法功能描述：终止分合同的操作 终止分合同及分合同的明细 同时要判断同级合同是否全部终止 对应的主合同的明细是否全部终止
       *
       * 创建人：付中华
       * 创建时间：2009-4-18
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */       
        public bool endSupplyContract(int supplyId, int parentId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" update sellContract set finishMark=1 where id=" + supplyId + ";");
            sqlStr.Append(" update invoice set finishMark=1 where scId=" + supplyId + ";");

            bool endAll = isEndAll(parentId, parentId);
            if (endAll)
            {
                sqlStr.Append(" update sellContract set finishMark=1 where id=" + parentId + ";");
            }
            list.Add(sqlStr.ToString());

            return sqlHelper.Update(list);

        }
        /*
      * 方法名称：
      * 方法功能描述：判断主合同的所有分合同是否全部终止以及判断主合同的明细是否全部终止 如果所有都已终止则返回true

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
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            bool supplyMark = true;
            bool detailMark = true;

            // 查找出所有的分合同判断是否全部终止
            string sqlSelect = " select finishMark from sellContract where parentId=" + mainId;
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { sqlSelect }).Tables[0];

            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() == "False")
                    {
                        supplyMark = false;
                    }
                }
            }

            // 查找出所有的主合同明细判断是否全部终止
            string sqlSelectS = " select finishMark from invoice where scId=" + parentId;
            DataTable dts = sqlHelper.QueryForDateSet(new ArrayList() { sqlSelectS }).Tables[0];

            if (dts.Rows.Count != 0)
            {
                for (int j = 0; j < dts.Rows.Count; j++)
                {
                    if (dts.Rows[j][0].ToString() == "False")
                    {
                        detailMark = false;
                    }
                }
            }

            // 所有的都终止才能确定终止才可以将对应的主合同终止
            if (supplyMark && detailMark)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public bool endMainContractDetail(int mainContractDetailId, int mainContractId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" update invoice set finishMark=1 where id=" + mainContractDetailId + ";");
            bool endAll = isEndAll(mainContractId, mainContractId);
            if (endAll)
            {
                sqlStr.Append(" update sellContract set finishMark=1 where id=" + mainContractId + ";");
            }
            list.Add(sqlStr.ToString());

            return sqlHelper.Update(list);

        }
        /*
     * 方法名称：
     * 方法功能描述： 终止分合同明细
     *
     * 创建人：付中华
     * 创建时间：2009-4-18
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool endSupplyContractDetail(int supplyDetailId, int parentId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" update invoice set finishMark=1 where id=" + supplyDetailId + ";");
            bool endAll = isEndAll(parentId, parentId);
            if (endAll)
            {
                sqlStr.Append(" update sellContract set finishMark=1 where id=" + parentId + ";");
            }
            list.Add(sqlStr.ToString());

            return sqlHelper.Update(list);
        }
        /*
        * 方法名称：FrmSalesCSearch()
        * 方法功能描述：查询销售合同内容
        *
        * 创建人：冯雪
        * 创建时间：2009-02-06
        *
        * 修改人：付中华
        * 修改时间：2009-4-17
        * 修改内容：查询字段的名称及显示顺序
        *
        */
        public DataTable FrmSalesCSearch(string searchStr, int verifyBit)
        {
            string lSearchStr;
            DataTable dataTable = new DataTable();

            lSearchStr = "select sellContract.id, sellContract.no as 合同编号, sellContract.name as 合同名称, clientInfo.name AS 客户名称, sellContract.producer as 制作人 ";
            lSearchStr = lSearchStr + ",assessor as 审核人";
            lSearchStr = lSearchStr + ",checkupMan as 审批人";
            //lSearchStr = lSearchStr + ",case when sellContract.assessor is null then '未审核' else '已审核' end as 审核人";
            //lSearchStr = lSearchStr + ",case when sellContract.checkupMan is null then '未审批' else '已审批' end as 审批人";
            lSearchStr = lSearchStr + ", sellContract.sum as 预计总额, CONVERT(varchar(10) , sellContract.startDate, 120 ) as 开始时间";
            lSearchStr = lSearchStr + ",  CONVERT(varchar(10) , sellContract.endDate, 120) as 结束时间";
            lSearchStr = lSearchStr + ",case sellContract.finishMark when 0 THEN '未终止' else '终止' end  as 合同状态";
            // 增加一个补充合同对应的父合同的parentId
            lSearchStr = lSearchStr + ",sellContract.parentId as parentId";
            lSearchStr = lSearchStr + ",case when sellContract.parentId is null then '否' else '是' end as 补充合同";
            //lSearchStr = lSearchStr + ",case sellContract.finishMark when 0 THEN '未终止' else '终止' end  as 合同状态";
            //lSearchStr = lSearchStr + ",case when sellContract.assessor is null then '未审核' else '已审核' end as 审核人";
            //lSearchStr = lSearchStr + ",case when sellContract.checkupMan is null then '未审批' else '已审批' end as 审批人";
            lSearchStr = lSearchStr + " from  sellContract INNER JOIN clientInfo ON sellContract.ciId = clientInfo.id ";

            switch (verifyBit)
            {
                case 1:
                    lSearchStr = lSearchStr + " where sellContract.finishMark = 0";
                    break;
                case 2:    
                    lSearchStr = lSearchStr + " where sellContract.finishMark = 1";
                    break;
                case 3:
                    lSearchStr = lSearchStr + " where sellContract.name like " + "'%" + searchStr + "%'";
                    break;
                default:
                    break;
            }

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            return dataTable;
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
        //获得采购合同主界面上的主列表
        public DataTable getContractList(string strWhere, string contractStatus)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            sqlStr.Append("select sc.id as id,sc.no as 合同编号,sc.name as 合同名称,cI.name as 客户名称 ,sc.producer as 制作人,sc.assessor as 审核人,sc.checkupMan as 审批人,sc.sum as 预计总额,");
            sqlStr.Append("sc.startDate as 开始时间,sc.endDate as 结束时间,");
            sqlStr.Append("case finishMark when 0 then '未终止' else '已终止' end as 合同状态 ,sc.parentId as parentId,");
            sqlStr.Append("case when parentId is null then '否' else '是' end as 补充合同");
            sqlStr.Append(" from sellContract sc,clientInfo cI");
            sqlStr.Append(" where sc.ciId=cI.id ");

            if (strWhere.Trim() != "")
            {
                sqlStr.Append(" and " + strWhere);
            }
            if (contractStatus.Trim() != "")
            {
                sqlStr.Append(" and " + contractStatus);
            }
            list.Add(sqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];

        }


        /*
        * 方法名称：FrmSalesCSearchList()
        * 方法功能描述：查询合同明细的详细内容;
        *
        * 创建人：冯雪
        * 创建时间：2009-02-26
        *
        * 修改人：付中华
        * 修改时间：2009-4-17
        * 修改内容：显示字段的名称
        *
        */
        public DataTable FrmSalesCSearchList(int id)
        {
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("invoice.id");
            ls.Viewfields.Add("productKind.sort as 产品种类");
            ls.Viewfields.Add("productName.name as 产品名称");
            ls.Viewfields.Add("productModel.model as 产品规格");
            ls.Viewfields.Add("invoice.quantity as 销售数量");
            ls.Viewfields.Add("invoice.unitPrice as 销售单价");
            ls.Viewfields.Add("case invoice.finishMark when 0 THEN '未终止' else '终止' end  as 明细状态");
            ls.Viewfields.Add("invoice.scId as scId");
            //ls.Viewfields.Add("invoice.inputDate as 录入日期");
            //ls.Viewfields.Add("invoice.inputMan as 录入人 ");
            //ls.Viewfields.Add("invoice.remark as 备注");

            ls.TableNames.Add("invoice");
            ls.TableNames.Add("product");
            ls.LinkConds.Add("invoice.pId = product.id");

            ls.TableNames.Add("productModel");
            ls.LinkConds.Add("product.pmId = productModel.id");
            ls.TableNames.Add("productName");
            ls.LinkConds.Add("product.pnId = productName.id");
            ls.TableNames.Add("productKind");
            ls.LinkConds.Add("productName.pKId = productKind.id");

            ls.Conds.Add("invoice.scId = " + id);

            return dataTable = ls.LeftLinkOpen().Tables[0];
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
            int id,cId;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "SELECT * FROM invoice WHERE finishMark = 0 and scId = " + contractId; 

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

            lSearchStr = "SELECT * FROM  sellContract WHERE finishMark = 0 and parentId = " + contractId;

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            cId = dataTable.Rows.Count;

            if (id == 0 && cId == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            ArrayList arrayList = new ArrayList();
            string lUpdateStr,lSearchStr;
            DataTable dataTable = new DataTable();

            //将该合同置为终止状态；
            lUpdateStr = "UPDATE  sellContract SET finishMark = 1 WHERE id = " + contractId;
            arrayList.Add(lUpdateStr);
            //将该合同下所有明细置为终止状态；
            lUpdateStr = "UPDATE invoice SET finishMark = 1 WHERE scId =" + contractId;
            arrayList.Add(lUpdateStr);

            //查询该合同下的所有补充合同
            lSearchStr = "SELECT id FROM sellContract WHERE parentId = " + contractId;
            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count != 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    //将该补充合同置为终止状态；
                    lUpdateStr = "UPDATE  sellContract SET finishMark = 1 WHERE id = " + Convert.ToInt32(dataTable.Rows[i][0].ToString());
                    arrayList.Add(lUpdateStr);
                    //将该补充合同下的所有明细置为终止状态；
                    lUpdateStr = "UPDATE invoice SET finishMark = 1 WHERE scId = " + Convert.ToInt32(dataTable.Rows[i][0].ToString());
                    arrayList.Add(lUpdateStr);
                }
            }
            return sqlHelper.Update(arrayList);
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
            storageDB sDB = new storageDB();
            return sDB.Update_Assess("sellContract", id, assessor);
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
            storageDB sDB = new storageDB();
            {
                return sDB.Update_Checkup("sellContract", id, checkup);
            }

        }
    }
     

    #endregion

    #region 新建销售合同窗体数据层方法
    /*
      * 类名称: AddSalesContractDB
      * 类功能描述：新建销售合同窗体数据层方法
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class AddSalesContractDB
    {   
        DataSet ds = new DataSet();
        SqlHelper sqlHelper = new SqlHelper();

        /*
        * 方法名称：InitialASalesComboBox()
        * 方法功能描述：查询所有合同编号和合同制作人;
        *
        * 创建人：冯雪
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        #region 此方法可能没用上
        public DataTable InitialASalesComboBox(int state)
        {
            string lSearchStr;
            DataTable dataTable = new DataTable();

            lSearchStr = "select distinct ";

            switch (state)
            {
                case 1:
                    {
                        lSearchStr = lSearchStr + "id,no";
                        break;
                    }
                case 2:
                    {
                        lSearchStr = lSearchStr + "producer";
                        break;
                    }
            }

            lSearchStr = lSearchStr + " from sellContract where finishMark = 0";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            return dataTable;
        }
        #endregion 
        /*
       * 方法名称：initialMakerDb
       * 方法功能描述：初始化销售合同制作人
       *
       * 创建人：付中华
       * 创建时间：2009-04-17
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable initialMakerDb()
        {
            string SqlStr;
            ArrayList list = new ArrayList();

            SqlStr = "select id,name from usersInfo";

            list.Add(SqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        /*
      * 方法名称：
      * 方法功能描述：查找客户名称
      *
      * 创建人：付中华
      * 创建时间：2009-04-17
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataTable findClientNameDb(int id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select clientInfo.name ");
            sqlStr.Append(" from sellContract,clientInfo");
            sqlStr.Append(" where sellContract.ciId=clientInfo.id and ");
            sqlStr.Append(" sellContract.id=" + id);

            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        /*
     * 方法名称：
     * 方法功能描述：判断合同名称在数据库表中是否存在 若存在不能再插入的数据库表中
     *
     * 创建人：付中华
     * 创建时间：2009-04-18
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool compareContractName(string contractName)
        {
            string sqlSelect = "select name from sellContract where  name=" + "'" + contractName + "'";
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { sqlSelect }).Tables[0];

            if (dt.Rows.Count != 0)
            {
                return true;
            }
            return false;
        }
        /*
    * 方法名称：
    * 方法功能描述：判断合同编号在数据库表中是否存在 若存在则不能插入到数据库表中
    *
    * 创建人：付中华
    * 创建时间：2009-04-18
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public bool compareContractNo(string contractNo)
        {
            string sqlSelect = " select no from sellContract where no=" + "'" + contractNo + "'";
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { sqlSelect }).Tables[0];

            if (dt.Rows.Count != 0)
            {
                return true;
            }
            return false;
        }
        /*
        * 方法名称：ASalesSearchId()
        * 方法功能描述：查询合同编号;
        *
        * 创建人：冯雪
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public int ASalesSearchId(string no)
        {
            int id;
            string lSearchStr;
            DataTable dataTable = new DataTable();

            lSearchStr = "select id from sellContract where no = " + "'" + no + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
            id = Convert.ToInt32(dataTable.Rows[0][0].ToString()) ;

            return id;
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
        public bool ASalesSearchNO(string scNo,string scName)
        {
            string lSearchStr;
            DataTable dataTable = new DataTable();

            lSearchStr = "SELECT  id,name,no FROM sellContract where name = '" + scName + "'" ;
            lSearchStr = lSearchStr + " and no = '" + scNo + "'";
            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

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
            string lSearchStr;
            DataTable dataTable = new DataTable();

            lSearchStr = "SELECT name FROM personnelInfo WHERE name = '" + name + "'";
            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

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
            string lUpdateStr; 

            lUpdateStr = "UPDATE  invoice SET finishMark = 1 WHERE id = " + id;
            return sqlHelper.Update(new ArrayList() { lUpdateStr });

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
            string lSearchStr;

            lSearchStr = "SELECT id,name FROM clientInfo";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
        * 方法名称：SellContractAdd()
        * 方法功能描述：批量保存的方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-08
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool SellContractAdd(SalesContractClass scClass, List<InvoiceClass> list)
        {
            ArrayList sqlLIst = new ArrayList();
            sqlLIst.Add(getInsertSqlMain(scClass));
            foreach (InvoiceClass invoiceClass in list)
            {
                sqlLIst.Add(getInsertSqlSub(invoiceClass));
            }
            return sqlHelper.ExecuteTransaction(sqlLIst);
        }
        /*
        * 方法名称：getInsertSqlMain()
        * 方法功能描述：生成SQL向销售合同中插入数据
        *
        * 创建人：冯雪
        * 创建时间：2009-03-08
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string getInsertSqlMain(SalesContractClass scClass)
       {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("INSERT INTO  sellContract (");
            strSql.Append("name ,no ,ciId ,producer ,[sum] ,inputDate ,assessor ,checkupMan ,");

            if (scClass.ParentId!= 0)
            {
                strSql.Append(" parentId ,");
            }
            else
            { }
            strSql.Append("startDate ,endDate ,remark ,conveyancer ,finishMark");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + scClass.Name + "',");
            strSql.Append("'" + scClass.No + "',");
            strSql.Append("" + scClass.CiId+ ",");
            strSql.Append("'" + scClass.Producer + "',");
            strSql.Append("" + scClass.Sum + ",");
            strSql.Append("'" + scClass.InputDate + "',");
            strSql.Append("'" + scClass.Assessor + "',");
            strSql.Append("'" + scClass.CheckupMan + "',");

            if (scClass.ParentId != 0)
            {
                strSql.Append("" + scClass.ParentId + ",");
            }
            else
            {}
            strSql.Append("'" +scClass.StartDate+ "',");
            strSql.Append("'" + scClass.EndDate + "',");
            strSql.Append("'" + scClass.Remark+ "',");
            strSql.Append("'" + scClass.Conveyancer+ "',");       
            strSql.Append("" + 0 + "");
            strSql.Append(")");
            strSql.Append(";declare  @scId bigint");
            strSql.Append(";set @scId=@@IDENTITY;");


            return strSql.ToString();
        }
        /*
        * 方法名称：getInsertSqlSub()
        * 方法功能描述：生成SQL向销售合同明细中插入数据
        *
        * 创建人：冯雪
        * 创建时间：2009-03-07
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string getInsertSqlSub(InvoiceClass invoiceClass)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into invoice(");
            strSql.Append("pId,quantity,unitPrice,inputMan,inputDate,finishMark,scId");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + invoiceClass.PId+ ",");
            strSql.Append("" + invoiceClass.Quantity + ",");
            strSql.Append("" + invoiceClass.UnitPrice + ",");
            strSql.Append("'" + invoiceClass.InputMan + "',");
            strSql.Append("'" + invoiceClass.InputDate + "',");
            strSql.Append("" + 0 + ",");
            strSql.Append("@scId");
            strSql.Append(")");

            return strSql.ToString();
        }


    }

    #endregion

    #region 销售计划窗体数据层方法

    /*
     * 类名称：SellPlanDB
     * 类功能描述：销售计划窗体数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-08
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class SellPlanDB
    {
        SqlHelper sqlHelper = new SqlHelper();

        /*
        * 方法名称：FrmSPlanSearch()
        * 方法功能描述：
        *
        * 创建人：冯雪
        * 创建时间：
        *
        * 修改人：付中华
        * 修改时间：2009-4-18
        * 修改内容：审核人审批人
        *
        */
        public DataTable FrmSPlanSearch(string beginYear, string endYear)
        {
            string lSearchStr;

            lSearchStr = "SELECT id ,inputDate as 制作日期 , Year( planYear) as 销售计划年份,inputMan as 录入人";
            lSearchStr = lSearchStr + ",producer as 销售计划制作人";
            lSearchStr = lSearchStr + ",assessor as 审核人";
            lSearchStr = lSearchStr + ",checkupMan as 审批人";
            //lSearchStr = lSearchStr + ",case when assessor is null then '未审核' else '已审核' end as 审核人";
            //lSearchStr = lSearchStr + ",case when checkupMan is null then '未审批' else '已审批' end as 审批人 ";
            lSearchStr = lSearchStr + ",remark as 备注 FROM sellPlan ";
            if (beginYear.Equals(endYear))
            {
                lSearchStr = lSearchStr + " Where Year( planYear) = " + beginYear;
            }
            else
            {
                lSearchStr = lSearchStr + " Where Year( planYear) between " + beginYear + " and " + endYear;
            }

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }

        /*
        * 方法名称：FrmSPlanDetailSearch()
        * 方法功能描述：
        *
        * 创建人：冯雪
        * 创建时间：
        *
        * 修改人：付中华
        * 修改时间：2009-4-17
        * 修改内容：把月份后的销售量全部去掉以统一风格
        *
        */
        public DataTable FrmSPlanDetailSearch(long sellPlanId)
        {
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("sellPlanDetail.id");
            ls.Viewfields.Add("productKind.sort as 产品种类");
            ls.Viewfields.Add("productName.name as 产品名称");
            ls.Viewfields.Add("productModel.model as 产品规格");
            ls.Viewfields.Add("sellPlanDetail.quantity as 销售总量");
            ls.Viewfields.Add("sellPlanDetail.january as 一月份");
            ls.Viewfields.Add("sellPlanDetail.february as 二月份");
            ls.Viewfields.Add("sellPlanDetail.march as 三月份");
            ls.Viewfields.Add("sellPlanDetail.april as 四月份");
            ls.Viewfields.Add("sellPlanDetail.may as 五月份");
            ls.Viewfields.Add("sellPlanDetail.june as 六月份");
            ls.Viewfields.Add("sellPlanDetail.july as 七月份");
            ls.Viewfields.Add("sellPlanDetail.august as 八月份");
            ls.Viewfields.Add("sellPlanDetail.september as 九月份");
            ls.Viewfields.Add("sellPlanDetail.october as 十月份");
            ls.Viewfields.Add("sellPlanDetail.november as 十一月份");
            ls.Viewfields.Add("sellPlanDetail.december as 十二月份");
            //ls.Viewfields.Add("sellPlanDetail.remark as 备注");

            ls.TableNames.Add("sellPlanDetail");
            ls.TableNames.Add("product");
            ls.LinkConds.Add("sellPlanDetail.pId = product.id");

            ls.TableNames.Add("productModel");
            ls.LinkConds.Add("product.pmId = productModel.id");
            ls.TableNames.Add("productName");
            ls.LinkConds.Add("product.pnId = productName.id");
            ls.TableNames.Add("productKind");
            ls.LinkConds.Add("productName.pKId = productKind.id");

            if (sellPlanId != 0)
            {
                ls.Conds.Add("sellPlanDetail.spId = " + sellPlanId);
            }
            return dataTable = ls.LeftLinkOpen().Tables[0];
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
            ArrayList arrayList = new ArrayList();
            string lDeleteStr;

            lDeleteStr = "DELETE FROM sellPlanDetail WHERE spId = " + sellPlanId;

            arrayList.Add(lDeleteStr);

            lDeleteStr = "DELETE FROM sellPlan WHERE id = " + sellPlanId;

            arrayList.Add(lDeleteStr);

            return sqlHelper.Delete(arrayList);           
        }

        /*
        * 方法名称：Plan_Assess()
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
        public bool Plan_Assess( long id, string assessor)
        {
            storageDB sDB = new storageDB();
            return sDB.Update_Assess("sellPlan", id, assessor);
        }

        /*
        * 方法名称：Plan_Checkup()
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
            storageDB sDB = new storageDB();
            {
                return sDB.Update_Checkup("sellPlan", id, checkup);
            }

        }
    }


    #endregion

    #region 新建销售计划数据层方法
    /*
     * 类名称：VenditionPlanDB
     * 类功能描述：新建销售计划窗体数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-09
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class VenditionPlanDB
    {
        SqlHelper sqlHelper = new SqlHelper();

        /*
        * 方法名称：saveSellPlanAdd()
        * 方法功能描述：批量保存的方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-09
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool saveSellPlanAdd(sellPlanClass sellPlanClass, List<sellPlanDetailClass> list)
        {
            ArrayList sqlList = new ArrayList();
            sqlList.Add(insertSellPlan(sellPlanClass));
            foreach (sellPlanDetailClass sPDclass in list)
            {
                sqlList.Add(insertSellPlanDetail(sPDclass));
            }
            return sqlHelper.Insert(sqlList);
        }
        /*
        * 方法名称：insertSellPlan()
        * 方法功能描述：向销售计划中插入数据
        *
        * 创建人：冯雪
        * 创建时间：2009-03-09
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string insertSellPlan(sellPlanClass sellPlanClass)
        {
            StringBuilder sqlStr = new StringBuilder();
            //审核审批人先不进行插入处理assessor,checkupMan
            sqlStr.Append("INSERT INTO sellPlan (inputDate ,inputMan ,producer ,");
            sqlStr.Append("remark ,planYear)");
            sqlStr.Append("values(");
            sqlStr.Append(""+"Getdate()" + "," + "'" + sellPlanClass.InputMan + "'" + ",");
            sqlStr.Append("" + "'" + sellPlanClass.Producer + "'" + ",");
            sqlStr.Append("" + "'" + sellPlanClass.Remark  + "'" + ",");
            sqlStr.Append("" + "'" + sellPlanClass.PlanYear + "'");
            sqlStr.Append(")");
            sqlStr.Append(";declare @spId int");
            sqlStr.Append(";set @spId=@@IDENTITY;");                
        
            return sqlStr.ToString();
          }
        /*
        * 方法名称：insertSellPlanDetail()
        * 方法功能描述：向销售计划明细表中插入数据
        *
        * 创建人：冯雪
        * 创建时间：2009-03-09
        *
        * 修改人：付中华
        * 修改时间：2009-4-17
        * 修改内容：原插入方法未考虑数值是否为空
        *
        */
        public string insertSellPlanDetail(sellPlanDetailClass sPDclass)
        {
            StringBuilder sqlStr = new StringBuilder();

            sqlStr.Append("INSERT INTO sellPlanDetail (pId ,spId,quantity ,january ,february ,march ,april ,may ,june ,");
            sqlStr.Append("july ,august ,september ,october ,november ,december ,inputDate");
            sqlStr.Append(")");
            sqlStr.Append("values(" + sPDclass.PId + ",");
            sqlStr.Append("@spId" + ",");

            #region//处理数值型的空
            if (sPDclass.Quantity.ToString() != null)
            {
                sqlStr.Append("" + sPDclass.Quantity + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (sPDclass.January.ToString() != "")
            {
                sqlStr.Append("" + sPDclass.January + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (sPDclass.February.ToString() != "")
            {
                sqlStr.Append("" + sPDclass.February + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (sPDclass.March.ToString() != "")
            {
                sqlStr.Append("" + sPDclass.March + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (sPDclass.April.ToString() != "")
            {
                sqlStr.Append("" + sPDclass.April + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (sPDclass.May.ToString() != "")
            {
                sqlStr.Append("" + sPDclass.May + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (sPDclass.June.ToString() != "")
            {
                sqlStr.Append("" + sPDclass.June + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (sPDclass.July.ToString() != "")
            {
                sqlStr.Append("" + sPDclass.July + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (sPDclass.August.ToString() != "")
            {
                sqlStr.Append("" + sPDclass.August + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (sPDclass.September.ToString() != "")
            {
                sqlStr.Append("" + sPDclass.September + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (sPDclass.October.ToString() != "")
            {
                sqlStr.Append("" + sPDclass.October + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (sPDclass.November.ToString() != "")
            {
                sqlStr.Append("" + sPDclass.November + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (sPDclass.December.ToString() != "")
            {
                sqlStr.Append("" + sPDclass.December + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            #endregion       
            //sqlStr.Append("" + sPDclass.Quantity + "," + sPDclass.January + ",");
            //sqlStr.Append("" + sPDclass.February + "," + sPDclass.March + ",");
            //sqlStr.Append("" + sPDclass.April + ",");
            //sqlStr.Append("" + sPDclass.May + "," + sPDclass .June+ ",");
            //sqlStr.Append("" + sPDclass.July + "," + sPDclass.August + ",");
            //sqlStr.Append("" + sPDclass.September + "," + sPDclass.October + ",");
            //sqlStr.Append("" + sPDclass.November + "," + sPDclass.December + ",");
            sqlStr.Append("Getdate()");
            sqlStr.Append(")");

            return sqlStr.ToString();

        }
    }


    #endregion

    #region 销售统计数据层方法
    /*
     * 类名称：SalesStatisticsDB
     * 类功能描述：销售统计数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-10
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class SalesStatisticsDB
    {
        SqlHelper sqlHelper = new SqlHelper();
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
            DataTable dt = new DataTable();
            switch (verifyBit)
            {
                case 1:
                    {
                        dt = sqlHelper.QueryForDateSet( ProductSQL(beginTime,endTime) ).Tables[0];
                        break;
                    }
                case 2:
                    {
                        dt = sqlHelper.QueryForDateSet(ClientSQL(beginTime, endTime)).Tables[0];
                        break;
                    }
                case 3:
                    {
                        dt = sqlHelper.QueryForDateSet(TransportUSQL(beginTime, endTime)).Tables[0];
                        break;
                    }
                case 4:
                    {
                        dt = sqlHelper.QueryForDateSet(ProjectSQL(beginTime, endTime)).Tables[0];
                        break;
                    }
            }
            return dt;

        }
        /*
        * 方法名称：ProductSQL()
        * 方法功能描述：生成按产品汇总销售统计的SQL语句方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public ArrayList ProductSQL(string beginTime, string endTime)
        {
            ArrayList arrayList = new ArrayList();
            string lSearchStr;
            string date = DateTime.Today.ToString("yyyy") ;
            string year = date + "-01-01";

            lSearchStr = "SELECT  pk.sort as '产品种类', pn.name AS '产品名称', pm.model as '产品规格'";
            lSearchStr = lSearchStr + " , SUM(cn.suttle) AS '出库量', COUNT(*) AS '小票数量' ";
            lSearchStr = lSearchStr + " ,(SELECT SUM(csn.suttle) as suttle";
            lSearchStr = lSearchStr + " FROM consignmentNote csn,invoice ci ";
            lSearchStr = lSearchStr + " where csn.iid=ci.id and ci.pid=it.pid and year(csn.inputDate)='" + date + "' group by ci.pid) as '当年出库量'";
            lSearchStr = lSearchStr + " FROM consignmentNote AS cn INNER JOIN invoice AS it ON cn.iId = it.id INNER JOIN ";
            lSearchStr = lSearchStr + " sellContract AS sc ON it.scId = sc.id INNER JOIN ";
            lSearchStr = lSearchStr + " product AS p ON it.pId = p.id INNER JOIN ";
            lSearchStr = lSearchStr + " productName AS pn ON p.pnId = pn.id INNER JOIN ";
            lSearchStr = lSearchStr + " productModel AS pm ON p.pmId = pm.id INNER JOIN ";
            lSearchStr = lSearchStr + " productKind AS pk ON pn.pkId = pk.id";
            lSearchStr = lSearchStr + " WHERE (cn.inputDate >= '" + beginTime + "') AND (cn.inputDate <= '" + endTime + "')";
            lSearchStr = lSearchStr + " And cn.checkupMan is not NULL";
            lSearchStr = lSearchStr + " GROUP BY it.pid,pk.sort, pn.name, pm.model";
            
            arrayList.Add(lSearchStr);
            
            lSearchStr =" UNION ALL";

            arrayList.Add(lSearchStr);

            lSearchStr = "";
            lSearchStr = " SELECT  pk.sort as '产品种类', pn.name AS '产品名称', pm.model as '产品规格'";
            lSearchStr = lSearchStr + " , 0 AS '出库量', 0 AS '小票数量',(select SUM(csn.suttle) from consignmentNote csn,invoice ci ";
            lSearchStr = lSearchStr + " where csn.iid=ci.id and ci.pid=it.pid and year(csn.inputDate)='" + date + "' group by ci.pid) as '当年出库量'";
            lSearchStr = lSearchStr + " FROM consignmentNote AS cn INNER JOIN";
            lSearchStr = lSearchStr + " invoice AS it ON cn.iId = it.id INNER JOIN";
            lSearchStr = lSearchStr + " sellContract AS sc ON it.scId = sc.id INNER JOIN";
            lSearchStr = lSearchStr + " product AS p ON it.pId = p.id INNER JOIN";
            lSearchStr = lSearchStr + " productName AS pn ON p.pnId = pn.id INNER JOIN";
            lSearchStr = lSearchStr + " productModel AS pm ON p.pmId = pm.id INNER JOIN";
            lSearchStr = lSearchStr + " productKind AS pk ON pn.pkId = pk.id";
            lSearchStr = lSearchStr + " WHERE (cn.inputDate >= '" + year + "') AND (cn.inputDate <= '" + beginTime + "') and p.id not in";
            lSearchStr = lSearchStr + " (select i.pid from consignmentNote con,invoice i ";
            lSearchStr = lSearchStr + " where con.iid=i.id and con.inputDate between '" + beginTime + "' and '" + endTime + "' group by i.pid)";
            lSearchStr = lSearchStr + " And cn.checkupMan is not NULL";
            lSearchStr = lSearchStr + "  GROUP BY it.pid, pk.sort, pn.name, pm.model";

            arrayList.Add(lSearchStr);
            
            return arrayList;
        }

        /*
        * 方法名称：ClientSQL()
        * 方法功能描述：生成按客户汇总销售统计的SQL语句方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-14
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public ArrayList ClientSQL(string beginTime, string endTime)
        {
            ArrayList arrayList = new ArrayList();
            string lSearchStr;
            string date = DateTime.Today.ToString("yyyy");
            string year = date + "-01-01";

            lSearchStr = "SELECT ci.name AS '客户', pk.sort as '产品种类', pn.name AS '产品名称', pm.model as '产品规格'";
            lSearchStr = lSearchStr + ", SUM(cn.suttle) AS '出库量', COUNT(*) AS '小票数量',(select SUM(csn.suttle)";
            lSearchStr = lSearchStr + " from consignmentNote csn,invoice ci ";
            lSearchStr = lSearchStr + " where csn.iid=ci.id and ci.pid=it.pid and year(csn.inputDate)='" + date + "' group by ci.pid) as '当年出库量'";
            lSearchStr = lSearchStr + " FROM consignmentNote AS cn INNER JOIN";
            lSearchStr = lSearchStr + " invoice AS it ON cn.iId = it.id INNER JOIN";
            lSearchStr = lSearchStr + " sellContract AS sc ON it.scId = sc.id INNER JOIN ";
            lSearchStr = lSearchStr + " clientInfo AS ci ON sc.ciId = ci.id INNER JOIN";
            lSearchStr = lSearchStr + " product AS p ON it.pId = p.id INNER JOIN ";
            lSearchStr = lSearchStr + " productName AS pn ON p.pnId = pn.id INNER JOIN ";
            lSearchStr = lSearchStr + " productModel AS pm ON p.pmId = pm.id INNER JOIN ";
            lSearchStr = lSearchStr + " productKind AS pk ON pn.pkId = pk.id";
            lSearchStr = lSearchStr + " WHERE (cn.inputDate >= '" + beginTime + "') AND (cn.inputDate <= '" + endTime + "')";
            lSearchStr = lSearchStr + " And cn.checkupMan is not NULL";
            lSearchStr = lSearchStr + " GROUP BY it.pid,ci.name, pk.sort, pn.name, pm.model";

            arrayList.Add(lSearchStr);

            lSearchStr = " UNION ALL";

            arrayList.Add(lSearchStr);

            lSearchStr = "";
            lSearchStr = " SELECT ci.name AS '客户', pk.sort as '产品种类', pn.name AS '产品名称', pm.model as '产品规格'";
            lSearchStr = lSearchStr + ", 0 AS '出库量', 0 AS '小票数量',(select SUM(csn.suttle) from consignmentNote csn,invoice ci";
            lSearchStr = lSearchStr + " where csn.iid=ci.id and ci.pid=it.pid and year(csn.inputDate)='" + date + "' group by ci.pid) as '当年出库量'";
            lSearchStr = lSearchStr + " FROM consignmentNote AS cn INNER JOIN";
            lSearchStr = lSearchStr + " invoice AS it ON cn.iId = it.id INNER JOIN";
            lSearchStr = lSearchStr + " sellContract AS sc ON it.scId = sc.id INNER JOIN ";
            lSearchStr = lSearchStr + " clientInfo AS ci ON sc.ciId = ci.id INNER JOIN";
            lSearchStr = lSearchStr + " product AS p ON it.pId = p.id INNER JOIN ";
            lSearchStr = lSearchStr + " productName AS pn ON p.pnId = pn.id INNER JOIN ";
            lSearchStr = lSearchStr + " productModel AS pm ON p.pmId = pm.id INNER JOIN ";
            lSearchStr = lSearchStr + " productKind AS pk ON pn.pkId = pk.id";
            lSearchStr = lSearchStr + " WHERE (cn.inputDate >= '" + year + "') AND (cn.inputDate <= '" + beginTime + "') and p.id not in";
            lSearchStr = lSearchStr + " (select i.pid from consignmentNote con,invoice i ";
            lSearchStr = lSearchStr + " where con.iid=i.id and con.inputDate between '" + beginTime + "' and '" + endTime + "' group by i.pid)";
            lSearchStr = lSearchStr + " And cn.checkupMan is not NULL";
            lSearchStr = lSearchStr + " GROUP BY it.pid,ci.name, pk.sort, pn.name, pm.model";

            arrayList.Add(lSearchStr);

            return arrayList;
        }

        /*
        * 方法名称：TransportUSQL()
        * 方法功能描述：生成按运输公司汇总销售统计的SQL语句方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-14
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public ArrayList TransportUSQL(string beginTime, string endTime)
        {
            ArrayList arrayList = new ArrayList();
            string lSearchStr;
            string date = DateTime.Today.ToString("yyyy");
            string year = date + "-01-01";

            lSearchStr = "SELECT tu.name AS '运输公司', pk.sort as '产品种类', pn.name AS '产品名称', pm.model as '产品规格'";
            lSearchStr = lSearchStr + ", SUM(cn.suttle) AS '出库量', COUNT(*) AS '小票数量',(select SUM(csn.suttle)";
            lSearchStr = lSearchStr + " from consignmentNote csn,invoice ci ";
            lSearchStr = lSearchStr + " where csn.iid=ci.id and ci.pid=it.pid and year(csn.inputDate)='" + date + "' group by ci.pid) as '当年出库量'";
            lSearchStr = lSearchStr + " FROM consignmentNote AS cn INNER JOIN";
            lSearchStr = lSearchStr + " invoice AS it ON cn.iId = it.id INNER JOIN";
            lSearchStr = lSearchStr + " transportGoodsInformationCorresponding AS tgic ON cn.tgicId = tgic.id INNER JOIN ";
            lSearchStr = lSearchStr + " transportContract AS tc ON tgic.tcId = tc.id INNER JOIN  ";
            lSearchStr = lSearchStr + " transportUnit AS tu ON tc.tuId = tu.id INNER JOIN";
            lSearchStr = lSearchStr + " product AS p ON it.pId = p.id INNER JOIN ";
            lSearchStr = lSearchStr + " productName AS pn ON p.pnId = pn.id INNER JOIN ";
            lSearchStr = lSearchStr + " productModel AS pm ON p.pmId = pm.id INNER JOIN ";
            lSearchStr = lSearchStr + " productKind AS pk ON pn.pkId = pk.id";
            lSearchStr = lSearchStr + " WHERE (cn.inputDate >= '" + beginTime + "') AND (cn.inputDate <= '" + endTime + "')";
            lSearchStr = lSearchStr + " And cn.checkupMan is not NULL";
            lSearchStr = lSearchStr + " GROUP BY it.pid,tu.name, pk.sort, pn.name, pm.model";

            arrayList.Add(lSearchStr);

            lSearchStr = " UNION ALL";

            arrayList.Add(lSearchStr);

            lSearchStr = "";
            lSearchStr = " SELECT tu.name AS '运输公司', pk.sort as '产品种类', pn.name AS '产品名称', pm.model as '产品规格'";
            lSearchStr = lSearchStr + ", 0 AS '出库量', 0 AS notecount,(select SUM(csn.suttle) from consignmentNote csn,invoice ci";
            lSearchStr = lSearchStr + " where csn.iid=ci.id and ci.pid=it.pid and year(csn.inputDate)='" + date + "' group by ci.pid) as '当年出库量'";
            lSearchStr = lSearchStr + " FROM consignmentNote AS cn INNER JOIN";
            lSearchStr = lSearchStr + " invoice AS it ON cn.iId = it.id INNER JOIN";
            lSearchStr = lSearchStr + " transportGoodsInformationCorresponding AS tgic ON cn.tgicId = tgic.id INNER JOIN ";
            lSearchStr = lSearchStr + " transportContract AS tc ON tgic.tcId = tc.id INNER JOIN  ";
            lSearchStr = lSearchStr + " transportUnit AS tu ON tc.tuId = tu.id INNER JOIN";
            lSearchStr = lSearchStr + " product AS p ON it.pId = p.id INNER JOIN ";
            lSearchStr = lSearchStr + " productName AS pn ON p.pnId = pn.id INNER JOIN ";
            lSearchStr = lSearchStr + " productModel AS pm ON p.pmId = pm.id INNER JOIN ";
            lSearchStr = lSearchStr + " productKind AS pk ON pn.pkId = pk.id";
            lSearchStr = lSearchStr + " WHERE (cn.inputDate >= '" + year + "') AND (cn.inputDate <= '" + beginTime + "') and p.id not in";
            lSearchStr = lSearchStr + " (select i.pid from consignmentNote con,invoice i ";
            lSearchStr = lSearchStr + " where con.iid=i.id and con.inputDate between '" + beginTime + "' and '" + endTime + "' group by i.pid)";
            lSearchStr = lSearchStr + " And cn.checkupMan is not NULL";
            lSearchStr = lSearchStr + " GROUP BY it.pid,tu.name, pk.sort, pn.name, pm.model";

            arrayList.Add(lSearchStr);

            return arrayList;
        }

        /*
        * 方法名称：ProjectSQL()
        * 方法功能描述：生成按工程项目汇总销售统计的SQL语句方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-14
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public ArrayList ProjectSQL(string beginTime, string endTime)
        {
            ArrayList arrayList = new ArrayList();
            string lSearchStr;
            string date = DateTime.Today.ToString("yyyy");
            string year = date + "-01-01";

            lSearchStr = "SELECT pjn.name AS '工程项目', pk.sort as '产品种类', pn.name AS '产品名称', pm.model as '产品规格'";
            lSearchStr = lSearchStr + ", SUM(cn.suttle) AS '出库量', COUNT(*) AS '小票数量',(select SUM(csn.suttle)";
            lSearchStr = lSearchStr + " from consignmentNote csn,invoice ci ";
            lSearchStr = lSearchStr + " where csn.iid=ci.id and ci.pid=it.pid and year(csn.inputDate)='" + date + "' group by ci.pid ) as '当年出库量'";
            lSearchStr = lSearchStr + " FROM consignmentNote AS cn INNER JOIN";
            lSearchStr = lSearchStr + " invoice AS it ON cn.iId = it.id INNER JOIN";
            lSearchStr = lSearchStr + " projectName AS pjn ON cn.pnId = pjn.id INNER JOIN ";
            lSearchStr = lSearchStr + " product AS p ON it.pId = p.id INNER JOIN ";
            lSearchStr = lSearchStr + " productName AS pn ON p.pnId = pn.id INNER JOIN ";
            lSearchStr = lSearchStr + " productModel AS pm ON p.pmId = pm.id INNER JOIN ";
            lSearchStr = lSearchStr + " productKind AS pk ON pn.pkId = pk.id";
            lSearchStr = lSearchStr + " WHERE (cn.inputDate >= '" + beginTime + "') AND (cn.inputDate <= '" + endTime + "')";
            lSearchStr = lSearchStr + " And cn.checkupMan is not NULL";
            lSearchStr = lSearchStr + " GROUP BY it.pid,pjn.name, pk.sort, pn.name, pm.model";

            arrayList.Add(lSearchStr);

            lSearchStr = " UNION ALL";

            arrayList.Add(lSearchStr);

            lSearchStr = "";
            lSearchStr = " SELECT pjn.name AS '工程项目', pk.sort as '产品种类', pn.name AS '产品名称', pm.model as '产品规格'";
            lSearchStr = lSearchStr + ", 0 AS '出库量', 0 AS notecount,(select SUM(csn.suttle) from consignmentNote csn,invoice ci";
            lSearchStr = lSearchStr + " where csn.iid=ci.id and ci.pid=it.pid and year(csn.inputDate)='" + date + "' group by ci.pid ) as '当年出库量'";
            lSearchStr = lSearchStr + " FROM consignmentNote AS cn INNER JOIN";
            lSearchStr = lSearchStr + " invoice AS it ON cn.iId = it.id INNER JOIN";
            lSearchStr = lSearchStr + " projectName AS pjn ON cn.pnId = pjn.id INNER JOIN";
            lSearchStr = lSearchStr + " product AS p ON it.pId = p.id INNER JOIN ";
            lSearchStr = lSearchStr + " productName AS pn ON p.pnId = pn.id INNER JOIN ";
            lSearchStr = lSearchStr + " productModel AS pm ON p.pmId = pm.id INNER JOIN ";
            lSearchStr = lSearchStr + " productKind AS pk ON pn.pkId = pk.id";
            lSearchStr = lSearchStr + " WHERE (cn.inputDate >= '" + year + "') AND (cn.inputDate <= '" + beginTime + "') and p.id not in";
            lSearchStr = lSearchStr + " (select i.pid from consignmentNote con,invoice i ";
            lSearchStr = lSearchStr + " where con.iid=i.id and con.inputDate between '" + beginTime + "' and '" + endTime + "' group by i.pid)";
            lSearchStr = lSearchStr + " GROUP BY it.pid,pjn.name, pk.sort, pn.name, pm.model";

            arrayList.Add(lSearchStr);

            return arrayList;
        }
    }

    #endregion

    #region 销售核算数据层方法
    /*
     * 类名称：SalesSettlementDB
     * 类功能描述：销售核算数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-17
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class SalesSettlementDB
    {
        SqlHelper sqlHelper = new SqlHelper();

        /*
        * 方法名称：SettlementSearch()
        * 方法功能描述：在销售核算表中根据条件查询
        *
        * 创建人：冯雪
        * 创建时间：2009-03-17
        *
        * 修改人：付中华
        * 修改时间：2009-4-18
        * 修改内容：审核审批
        *
        */
        public DataTable SettlementSearch(string condition, int verifyBit)
        {
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("sellProductSettlement.id as 核算单号");
            ls.Viewfields.Add("sellContract.no as 合同编号");
            ls.Viewfields.Add("sellContract.name as 合同名称");
            ls.Viewfields.Add("clientInfo.name as 客户名称");
            ls.Viewfields.Add("sellProductSettlement.[sum] as 总金额");
            ls.Viewfields.Add("sellProductSettlement.[count] as 票据数量");
            ls.Viewfields.Add("sellProductSettlement.inputDate as 核算日期");
            ls.Viewfields.Add("sellProductSettlement.assessor  as 审核人");
            ls.Viewfields.Add("sellProductSettlement.checkupMan  as 审批人");
            //ls.Viewfields.Add("case when sellProductSettlement.assessor is null then '未审核' else '已审核' end as 审核");
            //ls.Viewfields.Add("case when sellProductSettlement.checkupMan is null then '未审批' else '已审批' end as 审批");
            ls.Viewfields.Add("sellProductSettlement.inputMan as 录入人 ");
            ls.Viewfields.Add("sellProductSettlement.remark as 备注");

            ls.TableNames.Add("sellProductSettlement");
            ls.TableNames.Add("sellContract");
            ls.LinkConds.Add("sellProductSettlement.scId = sellContract.id");

            ls.TableNames.Add("clientInfo");
            ls.LinkConds.Add("sellContract.ciId = clientInfo.id");

            switch (verifyBit)
            {
                case 1:
                    {
                        ls.Conds.Add("sellContract.no = '" + condition + "'");
                        break;
                    }
                case 2:
                    {
                        ls.Conds.Add("sellContract.name like " + "'%" + condition + "%'");
                        break;
                    }
                case 3:
                    {
                        ls.Conds.Add("clientInfo.name like " + "'%" + condition + "%'");
                        break;
                    }
            }

            return dataTable = ls.LeftLinkOpen().Tables[0];
        }

        /*
        * 方法名称：SettlementDisplay()
        * 方法功能描述：选择一条销售核算记录显示销售核算明细;
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
            LinkSelect ls = new LinkSelect();

            ls.Viewfields.Add("invoice.id ");
            ls.Viewfields.Add("productKind.sort");
            ls.Viewfields.Add("productName.name ");
            ls.Viewfields.Add("productModel.model");
            ls.Viewfields.Add("clientInfo.name as cname");
            ls.Viewfields.Add("invoice.unitPrice");
            ls.Viewfields.Add("sellProductSettlementDetail.[totalWeight] as 货物数量");
            ls.Viewfields.Add("sellProductSettlementDetail.[sum] as 总金额");
            ls.Viewfields.Add("sellProductSettlementDetail.[count] as 票据数量");
            ls.Viewfields.Add("sellProductSettlementDetail.inputDate as 核算日期");

            ls.TableNames.Add("sellProductSettlementDetail");
            ls.TableNames.Add("invoice");
            ls.LinkConds.Add("sellProductSettlementDetail.iId = invoice.id");

            ls.TableNames.Add("sellContract");
            ls.LinkConds.Add("invoice.scId = sellContract.id");

            ls.TableNames.Add("clientInfo");
            ls.LinkConds.Add("sellContract.ciId = clientInfo.id");

            ls.TableNames.Add("product");
            ls.LinkConds.Add("invoice.pId = product.id");

            ls.TableNames.Add("productModel");
            ls.LinkConds.Add("product.pmId = productModel.id");
            ls.TableNames.Add("productName");
            ls.LinkConds.Add("product.pnId = productName.id");
            ls.TableNames.Add("productKind");
            ls.LinkConds.Add("productName.pKId = productKind.id");

            ls.Conds.Add("sellProductSettlementDetail.spsId = " + spsId);

            return ls.LeftLinkOpen().Tables[0];
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
            string lSearchStr;

            lSearchStr = "select id,no,name from sellContract ";
            lSearchStr = lSearchStr + "WHERE (assessor IS NOT NULL) AND (checkupMan IS NOT NULL) AND (assessor <> '') AND (checkupMan <> '') and finishMark=0";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr;

            lSearchStr = " select invoice.id ,productKind.sort ,productName.name ";
            lSearchStr = lSearchStr + " ,productModel.model ,clientInfo.name as cname";
            lSearchStr = lSearchStr + " ,invoice.unitPrice ";
            lSearchStr = lSearchStr + " from invoice,sellContract,clientInfo,product";
            lSearchStr = lSearchStr + " ,productModel,productName,productKind ";
            lSearchStr = lSearchStr + " where invoice.scId = " + scId ;
            lSearchStr = lSearchStr + " and invoice.pId=product.id and product.pmid=productModel.id";
            lSearchStr = lSearchStr + " and product.pnid=productName.id and productName.pkId=productKind.id ";
            lSearchStr = lSearchStr + " and sellContract.ciId =clientInfo.id and sellContract.id = " + scId;

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("consignmentNote.id ");
            ls.Viewfields.Add("consignmentNote.iId ");
            ls.Viewfields.Add("consignmentNote.barCode ");
            ls.Viewfields.Add("consignmentNote.inputDate ");
            ls.Viewfields.Add("sellContract.name as scname");
            ls.Viewfields.Add("productKind.sort ");
            ls.Viewfields.Add("productName.name ");
            ls.Viewfields.Add("productModel.model ");
            ls.Viewfields.Add("consignmentNote.grossWeight ");
            ls.Viewfields.Add("consignmentNote.tare ");
            ls.Viewfields.Add("consignmentNote.suttle ");
            ls.Viewfields.Add("clientInfo.name as cname");
            ls.Viewfields.Add("consignmentNote.sId1 ");
            ls.Viewfields.Add("consignmentNote.sId2 ");

            ls.TableNames.Add("consignmentNote");
            ls.TableNames.Add("invoice");
            ls.LinkConds.Add("consignmentNote.iId = invoice.id");

            ls.TableNames.Add("sellContract");
            ls.LinkConds.Add("invoice.scId = sellContract.id");

            ls.TableNames.Add("clientInfo");
            ls.LinkConds.Add("sellContract.ciId = clientInfo.id");

            ls.TableNames.Add("product");
            ls.LinkConds.Add("invoice.pId = product.id");
            ls.TableNames.Add("productModel");
            ls.LinkConds.Add("product.pmId = productModel.id");

            ls.TableNames.Add("productName");
            ls.LinkConds.Add("product.pnId = productName.id");
            ls.TableNames.Add("productKind");
            ls.LinkConds.Add("productName.pKId = productKind.id");

            ls.Conds.Add("consignmentNote.barCode = '" + barCode + "'");

            return dataTable = ls.LeftLinkOpen().Tables[0];
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
            string lSearchStr;

            lSearchStr = "Select consignmentNote.id,consignmentNote.iId,consignmentNote.barCode,consignmentNote.inputDate ";
            lSearchStr = lSearchStr + " ,sellContract.name as scname,productKind.sort ,productName.name,productModel.model ";
            lSearchStr = lSearchStr + " ,consignmentNote.grossWeight,consignmentNote.tare,consignmentNote.suttle ";
            lSearchStr = lSearchStr + " ,clientInfo.name as cname,consignmentNote.sId1,consignmentNote.sId2 ";

            lSearchStr = lSearchStr + " From sellProductNoteCorresponding Left Outer Join consignmentNote ON ";
            lSearchStr = lSearchStr + " sellProductNoteCorresponding.cnId = consignmentNote.id Left Outer Join invoice ON";
            lSearchStr = lSearchStr + " consignmentNote.iId = invoice.id Left Outer Join sellContract ON ";
            lSearchStr = lSearchStr + " invoice.scId = sellContract.id Left Outer Join clientInfo ON";
            lSearchStr = lSearchStr + " sellContract.ciId = clientInfo.id Left Outer Join product ON ";
            lSearchStr = lSearchStr + " invoice.pId = product.id Left Outer Join productModel ON ";
            lSearchStr = lSearchStr + " product.pmId = productModel.id Left Outer Join productName ON ";
            lSearchStr = lSearchStr + " product.pnId = productName.id Left Outer Join productKind ON ";
            lSearchStr = lSearchStr + " productName.pKId = productKind.id ";

            lSearchStr = lSearchStr + " where sellProductNoteCorresponding.spsdId in (";
            lSearchStr = lSearchStr + " select id from sellProductSettlementDetail where spsId =" + scId + ")";

            return sqlHelper.QueryForDateSet(new ArrayList() {lSearchStr}).Tables[0];  
        }

        /*
        * 方法名称：SearchNote()
        * 方法功能描述：根据输入的条码号查询票据信息并赋值给对象
        *
        * 创建人：冯雪
        * 创建时间：2009-03-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public SettlementNoteClass SearchNote(string barCode)
        {
            SettlementNoteClass sclass = new SettlementNoteClass();
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("consignmentNote.id ");
            ls.Viewfields.Add("consignmentNote.iId ");
            ls.Viewfields.Add("consignmentNote.barCode as 票据条码");
            ls.Viewfields.Add("consignmentNote.inputDate as 日期");
            ls.Viewfields.Add("sellContract.name as 合同名称");
            ls.Viewfields.Add("clientInfo.name as 客户名称");
            ls.Viewfields.Add("productKind.sort as 产品种类");
            ls.Viewfields.Add("productName.name as 产品名称");
            ls.Viewfields.Add("productModel.model as 产品规格");
            ls.Viewfields.Add("consignmentNote.grossWeight as 毛重");
            ls.Viewfields.Add("consignmentNote.tare as 皮重");
            ls.Viewfields.Add("consignmentNote.suttle as 净重");
            ls.Viewfields.Add("consignmentNote.sId1 as 起运地");
            ls.Viewfields.Add("consignmentNote.sId2 as 止运地");
            ls.Viewfields.Add("consignmentNote.remark as 备注");

            ls.TableNames.Add("consignmentNote");
            ls.TableNames.Add("invoice");
            ls.LinkConds.Add("consignmentNote.iId = invoice.id");

            ls.TableNames.Add("sellContract");
            ls.LinkConds.Add("invoice.scId = sellContract.id");

            ls.TableNames.Add("clientInfo");
            ls.LinkConds.Add("sellContract.ciId = clientInfo.id");
            
            ls.TableNames.Add("product");
            ls.LinkConds.Add("invoice.pId = product.id");
            ls.TableNames.Add("productModel");
            ls.LinkConds.Add("product.pmId = productModel.id");

            ls.TableNames.Add("productName");
            ls.LinkConds.Add("product.pnId = productName.id");
            ls.TableNames.Add("productKind");
            ls.LinkConds.Add("productName.pKId = productKind.id");

            ls.Conds.Add("consignmentNote.barCode = '" + barCode + "'");

            dataTable = ls.LeftLinkOpen().Tables[0];

            if (dataTable.Rows.Count > 0)
            {
                sclass.Id = Convert.ToInt64(dataTable.Rows[0][0].ToString());
                sclass.IId = Convert.ToInt64(dataTable.Rows[0][1].ToString());
                sclass.BarCode = dataTable.Rows[0][2].ToString();
                sclass.InputDate = Convert.ToDateTime(dataTable.Rows[0][3].ToString());
                sclass.Scname = dataTable.Rows[0][4].ToString();
                sclass.Sort = dataTable.Rows[0][5].ToString();
                sclass.Name = dataTable.Rows[0][6].ToString();
                sclass.Model = dataTable.Rows[0][7].ToString();
                sclass.GrossWeight = Convert.ToDecimal(dataTable.Rows[0][8].ToString());
                sclass.Tare = Convert.ToDecimal(dataTable.Rows[0][9].ToString());
                sclass.Suttle = Convert.ToDecimal(dataTable.Rows[0][10].ToString());
                sclass.Cname = dataTable.Rows[0][11].ToString();
                sclass.SId1 = dataTable.Rows[0][12].ToString();
                sclass.SId2 = dataTable.Rows[0][13].ToString();

            }

            return sclass;
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
        public bool SearchMark(string barCode)
        {
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "select * from consignmentNote where checkAccountMark1 = 1 and barCode = '" + barCode + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

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
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "select id from consignmentNote where barCode = '" + barCode + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

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
        public bool SearchCExist(long id,string barCode)
        {
            string lSearchStr;
            long iid;
            DataTable dataTable;

            lSearchStr = "select iId from consignmentNote where  barCode = '" + barCode + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count > 0)
            {
                iid = Convert.ToInt64(dataTable.Rows[0][0].ToString()) ;
            
                lSearchStr = "select * from invoice where scId = " + id + " and id = " + iid ;

                dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

                if (dataTable.Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

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
            string lInsertStr,lUpdateStr;
            ArrayList arrayList = new ArrayList();

            #region 生成插入销售核算表的SQL语句;
            lInsertStr = " INSERT INTO  sellProductSettlement (totalWeight ,scId ,[sum] ";
            lInsertStr = lInsertStr + ",inputDate ,inputMan ,[count]) VALUES ( ";
            lInsertStr = lInsertStr + psClass.TotalWeight + "," + psClass.ScId + "," + psClass.Sum;
            lInsertStr = lInsertStr + ", getdate()" + ",'" + psClass.InputMan + "',";
            lInsertStr = lInsertStr + psClass.Count + ")";
            lInsertStr = lInsertStr + ";declare  @spsId bigint ";
            lInsertStr = lInsertStr + ";set @spsId=@@IDENTITY;";
            lInsertStr = lInsertStr + ";declare  @spsdId bigint ";

            #endregion

            arrayList.Add(lInsertStr);

            
            foreach (DataGridViewRow dgvr in dgvMain.Rows)
            {
                if (dgvr.Cells["count"].Value.Equals(null))
                {
                    break;
                }
                else
                {
                    #region 生成插入销售核算明细表的SQL语句;
                    lInsertStr = "insert into sellProductSettlementDetail( iId,count,sum,totalWeight,inputMan,inputDate,spsId";
                    lInsertStr = lInsertStr + ") values (";
                    lInsertStr = lInsertStr + decimal.Parse(dgvr.Cells["id"].Value.ToString()) + ",";
                    lInsertStr = lInsertStr + decimal.Parse(dgvr.Cells["count"].Value.ToString()) + ",";
                    lInsertStr = lInsertStr + decimal.Parse(dgvr.Cells["money"].Value.ToString()) + ",";
                    lInsertStr = lInsertStr + decimal.Parse(dgvr.Cells["quantity"].Value.ToString()) + ",'";
                    lInsertStr = lInsertStr + username + "',";
                    lInsertStr = lInsertStr + " getdate() , @spsId )";
                    lInsertStr = lInsertStr + ";set @spsdId=@@IDENTITY;";
                    #endregion
                    arrayList.Add(lInsertStr);

                    foreach (DataGridViewRow dgvd in dgvDetail.Rows)
                    {
                        if (decimal.Parse(dgvr.Cells["id"].Value.ToString()) == decimal.Parse(dgvd.Cells["iid"].Value.ToString()))
                        {
                            #region 生成插入销售票据对应表的SQL语句;
                            lInsertStr = "insert into sellProductNoteCorresponding ( cnId ,inputDate ,inputMan,spsdId";
                            lInsertStr = lInsertStr + ") values (";
                            lInsertStr = lInsertStr + decimal.Parse(dgvd.Cells["nid"].Value.ToString()) + ",'";
                            lInsertStr = lInsertStr + username + "',getdate() ,@spsdId )";
                            #endregion
                            arrayList.Add(lInsertStr);

                            lUpdateStr = "UPDATE  consignmentNote SET  checkAccountMark1 = 1 WHERE id = " + decimal.Parse(dgvd.Cells["nid"].Value.ToString());
                            arrayList.Add(lUpdateStr);
                        }
                    }
                }
            }

            return sqlHelper.ExecuteTransaction(arrayList);
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
            storageDB sDB = new storageDB();
            return sDB.Update_Assess("sellProductSettlement", id, assessor);
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
            storageDB sDB = new storageDB();
            {
                return sDB.Update_Checkup("sellProductSettlement", id, checkup);
            }

        }
    }

    #endregion

}
