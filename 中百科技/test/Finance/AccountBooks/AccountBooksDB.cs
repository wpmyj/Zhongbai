/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：AccountBooksDB.cs
* 文件功能描述：
*
* 创建人： 杨林
* 创建时间：2009-03-05
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Iori.DataAccess.SQLServerDAL;

namespace DasherStation.Finance.AccountBooks
{

    /// <summary>
    /// 销售核算账务管理数据库访问类
    /// </summary>
    public class SellBalanceDB
    {
        private string strConn;
        private const string SQLTABLEPARAMNAME = "tFundsRecorderParam";
        private const string INSERT_SQL = @"Insert Into fundsRecorder (
				customerId,ciid,tuid,paidUp,type,checkNo,inputMan,invoiceNo,remark,cash1,cash2
				) Values (
				@iCustomerId,@iClientID,@iTransCorpID,@mPaid,@cType,@cCheckNo,@cInputMan,@cInvoiceNo,@cMemo,@cash1,@cash2
				)";


        public SellBalanceDB()
        {
            using (DasherStation.common.SqlHelper oHelper = new DasherStation.common.SqlHelper())
            {
                this.strConn = oHelper.SqlConn;
            }
        }

        /// <summary>
        /// 新增收款/付款记录
        /// </summary>
        /// <param name="entity"></param>
        public void InsertPaidRecord(tFundsRecorderInfo entity)
        {
            if(entity.tFundsRecorder[0].IsinputManNull())
            {
                entity.tFundsRecorder[0].inputMan = "System";
            }
            using(BalanceDataContext oContext = new BalanceDataContext(this.strConn))
            {
                FundsRecorder linqEntity = new FundsRecorder();
                if (entity.tFundsRecorder[0].IscustomerIdNull() == false)
                {
                    linqEntity.customerId = entity.tFundsRecorder[0].customerId;
                }
                else if (entity.tFundsRecorder[0].IsciIdNull() == false)
                {
                    linqEntity.ciid = entity.tFundsRecorder[0].ciId;
                }
                else if (entity.tFundsRecorder[0].IstuIdNull() == false)
                {
                    linqEntity.tuid = entity.tFundsRecorder[0].tuId;
                }
                linqEntity.paidup = entity.tFundsRecorder[0].paidUp;
                linqEntity.type = entity.tFundsRecorder[0].type;
                if (entity.tFundsRecorder[0].IscheckNoNull() == false)
                {
                    linqEntity.checkNo = entity.tFundsRecorder[0].checkNo;
                }
                if (entity.tFundsRecorder[0].IsinvoiceNoNull() == false)
                {
                    linqEntity.invoiceNo = entity.tFundsRecorder[0].invoiceNo;
                }
                if (entity.tFundsRecorder[0].IsremarkNull() == false)
                {
                    linqEntity.remark = entity.tFundsRecorder[0].remark;
                }
                linqEntity.cash1 = entity.tFundsRecorder[0].cash1;
                linqEntity.cash2 = entity.tFundsRecorder[0].cash2;
                linqEntity.inputMan = entity.tFundsRecorder[0].inputMan;

                Arrearage arrearageEntity = new Arrearage() ;//欠款表
                arrearageEntity.due = entity.tFundsRecorder[0].cash1;
                arrearageEntity.@default = entity.tFundsRecorder[0].cash2;
                arrearageEntity.paidUp = arrearageEntity.due - arrearageEntity.@default;
                arrearageEntity.inputMan = entity.tFundsRecorder[0].inputMan;
                AccountReceivable receiveEntity = null; //应收款表
                if (entity.tFundsRecorder[0].type == EnumAccountType.付款.ToString()
                    && entity.tFundsRecorder[0].IscustomerIdNull() == false)
                {
                    //采购                    
                    arrearageEntity.piId = entity.tFundsRecorder[0].customerId;                    
                    var tempEntity = (from item in oContext.Arrearage
                                      where item.piId == arrearageEntity.piId
                                      select item).FirstOrDefault();
                    if (tempEntity != null)
                    {
                        tempEntity.due = arrearageEntity.due;
                        tempEntity.@default = arrearageEntity.@default;
                        tempEntity.paidUp = arrearageEntity.paidUp;
                        tempEntity.inputMan = arrearageEntity.inputMan;
                    }
                    else
                    {
                        oContext.Arrearage.InsertOnSubmit(arrearageEntity);
                    }
                }
                else if (entity.tFundsRecorder[0].type == EnumAccountType.运输款.ToString()
                    && entity.tFundsRecorder[0].IstuIdNull() == false)
                {
                    //运输                    
                    arrearageEntity.tuId = entity.tFundsRecorder[0].tuId;                    
                    var tempEntity = (from item in oContext.Arrearage
                                      where item.tuId == arrearageEntity.tuId
                                      select item).FirstOrDefault();
                    if (tempEntity != null)
                    {
                        tempEntity.due = arrearageEntity.due;
                        tempEntity.@default = arrearageEntity.@default;
                        tempEntity.paidUp = arrearageEntity.paidUp;
                        tempEntity.inputMan = arrearageEntity.inputMan;
                    }
                    else
                    {
                        oContext.Arrearage.InsertOnSubmit(arrearageEntity);
                    }
                }
                else if (entity.tFundsRecorder[0].type == EnumAccountType.备品备件.ToString()
                    && entity.tFundsRecorder[0].IscustomerIdNull() == false)
                {
                    //备品备件                    
                    arrearageEntity.piId = entity.tFundsRecorder[0].customerId;
                    var tempEntity = (from item in oContext.Arrearage
                                      where item.piId == arrearageEntity.piId
                                      select item).FirstOrDefault();
                    if (tempEntity != null)
                    {
                        tempEntity.due = arrearageEntity.due;
                        tempEntity.@default = arrearageEntity.@default;
                        tempEntity.paidUp = arrearageEntity.paidUp;
                        tempEntity.inputMan = arrearageEntity.inputMan;
                    }
                    else
                    {
                        oContext.Arrearage.InsertOnSubmit(arrearageEntity);
                    }
                }
                else if (entity.tFundsRecorder[0].type == EnumAccountType.收款.ToString()
                    && entity.tFundsRecorder[0].IsciIdNull() == false)
                {
                    //销售
                    receiveEntity = new AccountReceivable();
                    receiveEntity.ciId = entity.tFundsRecorder[0].ciId;
                    receiveEntity.accountReceivable1 = entity.tFundsRecorder[0].cash1;                    
                    receiveEntity.@default = entity.tFundsRecorder[0].cash2;
                    receiveEntity.accept = receiveEntity.accountReceivable1 - receiveEntity.@default;
                    receiveEntity.inputMan = entity.tFundsRecorder[0].inputMan;
                    var tempEntity = (from item in oContext.AccountReceivable
                                      where item.ciId == receiveEntity.ciId
                                      select item).FirstOrDefault();
                    if (tempEntity != null)
                    {
                        tempEntity.accountReceivable1 = receiveEntity.accountReceivable1;
                        tempEntity.@default = receiveEntity.@default;
                        tempEntity.accept = receiveEntity.accept;
                        tempEntity.inputMan = receiveEntity.inputMan;
                    }
                    else
                    {
                        oContext.AccountReceivable.InsertOnSubmit(receiveEntity);
                    }
                }

                oContext.FundsRecorder.InsertOnSubmit(linqEntity);
                oContext.SubmitChanges();
            }
            //System.Data.SqlClient.SqlConnection sqlConn = null;
            //System.Data.SqlClient.SqlTransaction sqlTrans = null;
            //System.Data.SqlClient.SqlParameter[] sqlpmParams = GetTableParameters();
            //SetParamsValue(entity, sqlpmParams);
            //try
            //{
            //    sqlConn = new SqlConnection(strConn);
            //    if (sqlConn.State != ConnectionState.Open)
            //    {
            //        sqlConn.Open();
            //    }
            //    sqlTrans = sqlConn.BeginTransaction();
            //    Iori.DataAccess.SQLServerDAL.SQLHelper.ExecuteNonQuery(sqlConn, CommandType.Text, INSERT_SQL, sqlpmParams);            //    
            //    sqlTrans.Commit();
            //}
            //catch (System.Data.SqlClient.SqlException)
            //{
            //    if (sqlTrans != null)
            //    {
            //        sqlTrans.Rollback();
            //    }
            //}
            //finally
            //{
            //    if (sqlConn != null && sqlConn.State != ConnectionState.Closed)
            //    {
            //        sqlConn.Close();
            //    }
            //}
        }

        /// <summary>
        /// 获取客户信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryClientInfo()
        {
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                DataSet dtsResult = new DataSet();
                new System.Data.SqlClient.SqlDataAdapter("select id,name from clientInfo", sqlConn).Fill(dtsResult);
                return dtsResult;
            }
        }

        /// <summary>
        /// 获取指定客户标识的销售核算单数据集
        /// </summary>
        /// <param name="id">客户标识</param>
        /// <returns></returns>
        public DataSet QuerySellBalanceByClientID(long id)
        {
            string strSQL = string.Format(@"
select 
c.id as '核算单编号', 
b.name as '合同名称',
c.totalWeight as '货物总重',
c.sum as '总金额', 
c.count as '票据数',
c.remark as '备注'
from clientInfo a
left join sellContract b on b.ciid = a.id
right join sellProductSettlement c on c.scid = b.id
where a.id = {0} and b.checkupman is not null
", id);
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                DataSet dtsResult = new DataSet();
                new System.Data.SqlClient.SqlDataAdapter(strSQL, sqlConn).Fill(dtsResult);
                return dtsResult;
            }
        }

        /// <summary>
        /// 获取指定客户标识的收款记录数据集
        /// </summary>
        /// <param name="iClientID">客户标识</param>
        /// <returns></returns>
        public DataSet QueryPaidRecord(long iClientID)
        {
            string strSQL = string.Format(@"
select * from fundsRecorder 
where ciid = {0} AND type = '{1}'
", iClientID, EnumAccountType.收款.ToString());
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                DataSet dtsResult = new DataSet();
                new System.Data.SqlClient.SqlDataAdapter(strSQL, sqlConn).Fill(dtsResult);
                return dtsResult;
            }
        }

        /// <summary>
        /// 获取指定客户的应收总额
        /// </summary>
        /// <param name="id">客户标识</param>
        /// <returns></returns>
        public decimal QueryAccountCount(long id)
        {
            string strSQL = string.Format(@"
select 
SUM(C.SUM) as '应收总额'
from clientInfo a
left join sellContract b on b.ciid = a.id
right join sellProductSettlement c on c.scid = b.id
where a.id = {0} and b.checkupman is not null
group by a.id", id);
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                object result = Iori.DataAccess.SQLServerDAL.SQLHelper.ExecuteScalar(this.strConn, CommandType.Text, strSQL, null);
                if (result == null)
                {
                    return 0;
                }
                decimal v;
                decimal.TryParse(result.ToString(), out v);
                return v;
            }
        }

        /// <summary>
        /// 获取指定客户的已收总额
        /// </summary>
        /// <param name="iClientID">客户标识</param>        
        /// <returns></returns>
        public decimal QueryPaidCount(long iClientID)
        {
            string strSQL = string.Format(@"
select sum(paidUp) as '已收总额' from fundsRecorder 
where ciid = {0} AND type = '{1}'
group by ciid", iClientID, EnumAccountType.收款.ToString());
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                object result = Iori.DataAccess.SQLServerDAL.SQLHelper.ExecuteScalar(this.strConn, CommandType.Text, strSQL, null);
                if (result == null)
                {
                    return 0;
                }
                decimal v;
                decimal.TryParse(result.ToString(), out v);
                return v;
            }
        }

        private static SqlParameter[] GetTableParameters()
        {
            SqlParameter[] sqlpmParms = SQLHelper.GetCachedParameters(SQLTABLEPARAMNAME);

            if (sqlpmParms == null)
            {
                sqlpmParms = new SqlParameter[] {
					new SqlParameter("@id", SqlDbType.BigInt)
					
						,new SqlParameter("@iCustomerId", SqlDbType.BigInt)
					
						,new SqlParameter("@iClientID", SqlDbType.BigInt)
					
						,new SqlParameter("@iTransCorpID", SqlDbType.BigInt)
					
						,new SqlParameter("@mPaid", SqlDbType.Money)
					
						,new SqlParameter("@cType", SqlDbType.VarChar, 50)
					
						,new SqlParameter("@cCheckNo", SqlDbType.VarChar, 50)
					
						,new SqlParameter("@dInputDate", SqlDbType.DateTime)
					
						,new SqlParameter("@cInputMan", SqlDbType.VarChar, 50)
					
						,new SqlParameter("@cInvoiceNo", SqlDbType.VarChar, 50)
					
						,new SqlParameter("@cMemo", SqlDbType.VarChar, 1000)

                        ,new SqlParameter("@cash1", SqlDbType.Money)

                        ,new SqlParameter("@cash2", SqlDbType.Money)					
				};

                Iori.DataAccess.SQLServerDAL.SQLHelper.CacheParameters(SQLTABLEPARAMNAME, sqlpmParms);
            }

            return sqlpmParms;

        }

        private static void SetParamsValue(tFundsRecorderInfo oEntity, SqlParameter[] sqlpmEntity)
        {

            sqlpmEntity[0].Value = oEntity.tFundsRecorder[0].id;

            sqlpmEntity[1].Value = oEntity.tFundsRecorder[0].IscustomerIdNull() ? (object)System.DBNull.Value : oEntity.tFundsRecorder[0].customerId;

            sqlpmEntity[2].Value = oEntity.tFundsRecorder[0].IsciIdNull() ? (object)System.DBNull.Value : oEntity.tFundsRecorder[0].ciId;

            sqlpmEntity[3].Value = oEntity.tFundsRecorder[0].IstuIdNull() ? (object)System.DBNull.Value : oEntity.tFundsRecorder[0].tuId;

            sqlpmEntity[4].Value = oEntity.tFundsRecorder[0].paidUp;

            sqlpmEntity[5].Value = oEntity.tFundsRecorder[0].type;

            sqlpmEntity[6].Value = oEntity.tFundsRecorder[0].IscheckNoNull() ? (object)System.DBNull.Value : oEntity.tFundsRecorder[0].checkNo;

            sqlpmEntity[7].Value = oEntity.tFundsRecorder[0].IsinputDateNull() ? (object)System.DBNull.Value : oEntity.tFundsRecorder[0].inputDate;

            sqlpmEntity[8].Value = oEntity.tFundsRecorder[0].IsinputManNull() ? (object)System.DBNull.Value : oEntity.tFundsRecorder[0].inputMan;

            sqlpmEntity[9].Value = oEntity.tFundsRecorder[0].IsinvoiceNoNull() ? (object)System.DBNull.Value : oEntity.tFundsRecorder[0].invoiceNo;

            sqlpmEntity[10].Value = oEntity.tFundsRecorder[0].IsremarkNull() ? (object)System.DBNull.Value : oEntity.tFundsRecorder[0].remark;

            sqlpmEntity[11].Value = oEntity.tFundsRecorder[0].Iscash1Null() ? (object)System.DBNull.Value : oEntity.tFundsRecorder[0].cash1;

            sqlpmEntity[12].Value = oEntity.tFundsRecorder[0].Iscash2Null() ? (object)System.DBNull.Value : oEntity.tFundsRecorder[0].cash2;
        }

    }

    /// <summary>
    /// 销售核算账务管理数据库访问类
    /// </summary>
    public class TransportBalanceDB
    {

        private string strConn;

        public TransportBalanceDB()
        {
            using (DasherStation.common.SqlHelper oHelper = new DasherStation.common.SqlHelper())
            {
                this.strConn = oHelper.SqlConn;
            }
        }

        /// <summary>
        /// 获取运输商信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryTransCorpInfo()
        {
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                DataSet dtsResult = new DataSet();
                new System.Data.SqlClient.SqlDataAdapter("select id,name from transportUnit", sqlConn).Fill(dtsResult);
                return dtsResult;
            }
        }

        /// <summary>
        /// 获取指定运输商标识的运输核算单数据集
        /// </summary>
        /// <param name="iTransCorpID">运输商标识</param>
        /// <returns></returns>
        public DataSet QueryBalance(long iTransCorpID)
        {
            string strSQL = string.Format(@"
select 
a.name,
b.id as contractid,
c.id as '核算单编号', 
b.contractName as '合同名称',
c.totalWeight as '货物总重',
c.sum as '总金额', 
c.count as '票据数',
c.remark as '备注'
from transportUnit a
left join transportContract b on b.tuid = a.id
right join transportSettlement c on c.tcid = b.id
where a.id = {0} and b.checkupman is not null
", iTransCorpID);
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                DataSet dtsResult = new DataSet();
                new System.Data.SqlClient.SqlDataAdapter(strSQL, sqlConn).Fill(dtsResult);
                return dtsResult;
            }
        }

        /// <summary>
        /// 获取指定运输商标识的付款记录数据集
        /// </summary>
        /// <param name="iTransCorpID">运输商标识</param>
        /// <returns></returns>
        public DataSet QueryRecord(long iTransCorpID)
        {
            string strSQL = string.Format(@"
select * from fundsRecorder 
where tuid = {0} AND type = '{1}'
", iTransCorpID, EnumAccountType.运输款.ToString());
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                DataSet dtsResult = new DataSet();
                new System.Data.SqlClient.SqlDataAdapter(strSQL, sqlConn).Fill(dtsResult);
                return dtsResult;
            }
        }

        /// <summary>
        /// 获取指定运输商标识的应付总额
        /// </summary>
        /// <param name="iTransCorpID">运输商标识</param>
        /// <returns></returns>
        public decimal QueryAccountPayable(long iTransCorpID)
        {
            string strSQL = string.Format(@"
select 
SUM(C.SUM) as '应付总额'
from transportUnit a
join transportContract b on b.tuid = a.id
right join transportSettlement c on c.tcid = b.id
where a.id = {0} and b.checkupman is not null
group by a.id", iTransCorpID);
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                object result = Iori.DataAccess.SQLServerDAL.SQLHelper.ExecuteScalar(this.strConn, CommandType.Text, strSQL, null);
                if (result == null)
                {
                    return 0;
                }
                decimal v;
                decimal.TryParse(result.ToString(), out v);
                return v;
            }
        }

        /// <summary>
        /// 获取指定运输商标识的已付总额
        /// </summary>
        /// <param name="iTransCorpID">运输商标识</param>
        /// <returns></returns>
        public decimal QueryPaidUp(long iTransCorpID)
        {
            string strSQL = string.Format(@"
select sum(paidup) as '已付总额' from fundsRecorder 
where tuid = {0} AND type = '{1}'
group by tuid", iTransCorpID, EnumAccountType.运输款.ToString());
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                object result = Iori.DataAccess.SQLServerDAL.SQLHelper.ExecuteScalar(this.strConn, CommandType.Text, strSQL, null);
                if (result == null)
                {
                    return 0;
                }
                decimal v;
                decimal.TryParse(result.ToString(), out v);
                return v;
            }
        }
    }


    /// <summary>
    /// 备品备件账务管理数据库访问类
    /// </summary>
    public class SparePartBanlanceDB
    {

        private string strConn;

        public SparePartBanlanceDB()
        {
            using (DasherStation.common.SqlHelper oHelper = new DasherStation.common.SqlHelper())
            {
                this.strConn = oHelper.SqlConn;
            }
        }

        /// <summary>
        /// 获取提供商信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryCustomInfo()
        {
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                DataSet dtsResult = new DataSet();
                new System.Data.SqlClient.SqlDataAdapter("select id,name from providerInfo", sqlConn).Fill(dtsResult);
                return dtsResult;
            }
        }

        /// <summary>
        /// 获取入库单信息
        /// </summary>
        /// <param name="iCustomerID">供应商标识</param>
        /// <returns></returns>
        public DataSet QueryBalance(long iCustomerID)
        {
            string strSQL = string.Format(@"
select 
a.name,
c.id as '入库单号', 
c.stockMan as '采购人',
stockDate as '入库时间',
c.sum as '总金额', 
c.invoiceNo as '发票号',
c.remark as '备注'
from providerInfo a
right join sparePartAdd c on c.piid = a.id
where a.id = {0} and c.checkupman is not null
", iCustomerID);
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                DataSet dtsResult = new DataSet();
                new System.Data.SqlClient.SqlDataAdapter(strSQL, sqlConn).Fill(dtsResult);
                return dtsResult;
            }
        }

        /// <summary>
        /// 获取付款记录
        /// </summary>
        /// <param name="iCustomerID">供应商标识</param>
        /// <returns></returns>
        public DataSet QueryRecord(long iCustomerID)
        {
            string strSQL = string.Format(@"
select * from fundsRecorder 
where customerId = {0} AND type = '{1}'
", iCustomerID, EnumAccountType.备品备件.ToString());
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                DataSet dtsResult = new DataSet();
                new System.Data.SqlClient.SqlDataAdapter(strSQL, sqlConn).Fill(dtsResult);
                return dtsResult;
            }
        }

        /// <summary>
        /// 获取应付额
        /// </summary>
        /// <param name="iCustomerID">供应商标识</param>
        /// <returns></returns>
        public decimal QueryAccountPayable(long iCustomerID)
        {
            string strSQL = string.Format(@"
select 
SUM(C.SUM) as '应付总额'
from providerInfo a
right join sparePartAdd c on c.piid = a.id
where a.id = {0} and c.checkupman is not null
group by a.id", iCustomerID);
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                object result = Iori.DataAccess.SQLServerDAL.SQLHelper.ExecuteScalar(this.strConn, CommandType.Text, strSQL, null);
                if (result == null)
                {
                    return 0;
                }
                decimal v;
                decimal.TryParse(result.ToString(), out v);
                return v;
            }
        }

        /// <summary>
        /// 获取已付总额
        /// </summary>
        /// <param name="iCustomerID">供应商标识</param>
        /// <returns></returns>
        public decimal QueryPaidUp(long iCustomerID)
        {
            string strSQL = string.Format(@"
select sum(paidup) as '已付总额' from fundsRecorder 
where customerId = {0} AND type = '{1}'
group by customerId", iCustomerID, EnumAccountType.备品备件.ToString());
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                object result = Iori.DataAccess.SQLServerDAL.SQLHelper.ExecuteScalar(this.strConn, CommandType.Text, strSQL, null);
                if (result == null)
                {
                    return 0;
                }
                decimal v;
                decimal.TryParse(result.ToString(), out v);
                return v;
            }
        }
    }



    /// <summary>
    /// 采购核算账务管理数据库访问类
    /// </summary>
    public class PurchaseBalanceDB
    {
        private string strConn;

        public PurchaseBalanceDB()
        {
            using (DasherStation.common.SqlHelper oHelper = new DasherStation.common.SqlHelper())
            {
                this.strConn = oHelper.SqlConn;
            }
        }

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <returns></returns>
        public DataSet QueryCustomInfo()
        {
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                DataSet dtsResult = new DataSet();
                new System.Data.SqlClient.SqlDataAdapter("select id,name from providerInfo", sqlConn).Fill(dtsResult);
                return dtsResult;
            }
        }

        /// <summary>
        /// 获取采购核算单信息
        /// </summary>
        /// <param name="iCustomID">供应商标识</param>
        /// <returns></returns>
        public DataSet QueryBalance(long iCustomID)
        {
            string strSQL = string.Format(@"
select 
a.name,
c.id as '核算单编号', 
b.name as '合同名称',
c.totalWeight as '货物总重',
c.sum as '总金额', 
c.count as '票据数',
c.remark as '备注'
from providerInfo a
left join stockContract b on b.piid = a.id
right join stockMaterialSettlement c on c.scid = b.id
where a.id = {0} and c.checkupMan is not null
", iCustomID);
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                DataSet dtsResult = new DataSet();
                new System.Data.SqlClient.SqlDataAdapter(strSQL, sqlConn).Fill(dtsResult);
                return dtsResult;
            }
        }

        /// <summary>
        /// 获取付款记录
        /// </summary>
        /// <param name="iCustomID">供应商标识</param>
        /// <returns></returns>
        public DataSet QueryRecord(long iCustomID)
        {
            string strSQL = string.Format(@"
select * from fundsRecorder 
where  customerId = {0} AND type = '{1}'
", iCustomID, EnumAccountType.付款.ToString());
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                DataSet dtsResult = new DataSet();
                new System.Data.SqlClient.SqlDataAdapter(strSQL, sqlConn).Fill(dtsResult);
                return dtsResult;
            }
        }

        /// <summary>
        /// 获取应付总额
        /// </summary>
        /// <param name="iCustomID">供应商标识</param>
        /// <returns></returns>
        public decimal QueryAccountPayable(long iCustomID)
        {
            string strSQL = string.Format(@"
select 
SUM(C.SUM) as '应付总额'
from providerInfo a
join stockContract b on b.piid = a.id
right join stockMaterialSettlement c on c.scid = b.id
where a.id = {0} and c.checkupMan is not null
group by a.id", iCustomID);
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                object result = Iori.DataAccess.SQLServerDAL.SQLHelper.ExecuteScalar(this.strConn, CommandType.Text, strSQL, null);
                if (result == null)
                {
                    return 0;
                }
                decimal v;
                decimal.TryParse(result.ToString(), out v);
                return v;
            }
        }

        /// <summary>
        /// 获取已付总额
        /// </summary>
        /// <param name="iCustomID">供应商标识</param>
        /// <returns></returns>
        public decimal QueryPaidUp(long iCustomID)
        {
            string strSQL = string.Format(@"
select sum(paidup) as '已付总额' from fundsRecorder 
where customerId = {0} AND type = '{1}'
group by customerId", iCustomID, EnumAccountType.付款.ToString());
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                object result = Iori.DataAccess.SQLServerDAL.SQLHelper.ExecuteScalar(this.strConn, CommandType.Text, strSQL, null);
                if (result == null)
                {
                    return 0;
                }
                decimal v;
                decimal.TryParse(result.ToString(), out v);
                return v;
            }
        }
    }
}
