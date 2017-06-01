/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：AccountBooksLogic.cs
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
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DasherStation.Finance.AccountBooks
{
    class AccountBooksLogic
    {
    }


    /// <summary>
    /// 销售核算账务管理业务逻辑类
    /// </summary>
    public class SellBalanceLogic
    {
        private SellBalanceDB oData = new SellBalanceDB();

        public DataSet GetClientInfo()
        {
            return this.oData.QueryClientInfo();
        }

        /// <summary>
        /// 新增收款/付款记录
        /// </summary>
        /// <param name="entity"></param>
        public void AddPaid(tFundsRecorderInfo entity)
        {
            this.oData.InsertPaidRecord(entity);
        }

        /// <summary>
        /// 获取指定客户标识的销售核算单数据集
        /// </summary>
        /// <param name="id">客户标识</param>
        /// <returns></returns>
        public DataSet GetSellBalance(long id)
        {
            return this.oData.QuerySellBalanceByClientID(id);
        }

        /// <summary>
        /// 获取指定客户标识的收款记录数据集
        /// </summary>
        /// <param name="iClientID"></param>
        /// <returns></returns>
        public DataSet GetPaidRecord(long iClientID)
        {
            return this.oData.QueryPaidRecord(iClientID);
        }

        /// <summary>
        /// 获取指定客户的应收总额
        /// </summary>
        /// <param name="id">客户标识</param>
        /// <returns></returns>
        public decimal GetAccountCount(long id)
        {
            return this.oData.QueryAccountCount(id);
        }

        /// <summary>
        /// 获取指定客户的已收总额
        /// </summary>
        /// <param name="iClientID">客户标识</param>
        /// <returns></returns>
        public decimal GetPaidCount(long iClientID)
        {
            return this.oData.QueryPaidCount(iClientID);
        }
    }


    /// <summary>
    /// 销售核算账务管理业务逻辑类
    /// </summary>
    public class TransportBalanceLogic : SellBalanceLogic
    {
        private TransportBalanceDB oData = new TransportBalanceDB();

        /// <summary>
        /// 获取运输商信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetTransCorpInfo()
        {
            return oData.QueryTransCorpInfo();
        }

        /// <summary>
        /// 获取指定运输商标识的运输核算单数据集
        /// </summary>
        /// <param name="iTransCorpID">运输商标识</param>
        /// <returns></returns>
        public DataSet GetBalance(long iTransCorpID)
        {
            return oData.QueryBalance(iTransCorpID);
        }

        /// <summary>
        /// 获取指定运输商标识的付款记录数据集
        /// </summary>
        /// <param name="iTransCorpID">运输商标识</param>
        /// <returns></returns>
        public DataSet GetRecord(long iTransCorpID)
        {
            return oData.QueryRecord(iTransCorpID);
        }

        /// <summary>
        /// 获取指定运输商标识的应付总额
        /// </summary>
        /// <param name="iTransCorpID">运输商标识</param>
        /// <returns></returns>
        public decimal GetAccountPayable(long iTransCorpID)
        {
            return oData.QueryAccountPayable(iTransCorpID);
        }

        /// <summary>
        /// 获取指定运输商标识的已付总额
        /// </summary>
        /// <param name="iTransCorpID">运输商标识</param>
        /// <returns></returns>
        public decimal GetPaidUp(long iTransCorpID)
        {
            return oData.QueryPaidUp(iTransCorpID);
        }
    }



    /// <summary>
    /// 备品备件账务管理业务逻辑类
    /// </summary>
    public class SparePartBanlanceLogic : SellBalanceLogic
    {
        private SparePartBanlanceDB oData = new SparePartBanlanceDB();

        /// <summary>
        /// 获取提供商信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetCustomInfo()
        {
            return oData.QueryCustomInfo();
        }

        /// <summary>
        /// 获取入库单信息
        /// </summary>
        /// <param name="iCustomerID">供应商标识</param>
        /// <returns></returns>
        public DataSet GetBalance(long iCustomerID)
        {
            return oData.QueryBalance(iCustomerID);
        }

        /// <summary>
        /// 获取付款记录
        /// </summary>
        /// <param name="iCustomerID">供应商标识</param>
        /// <returns></returns>
        public DataSet GetRecord(long iCustomerID)
        {
            return oData.QueryRecord(iCustomerID);
        }

        /// <summary>
        /// 获取应付额
        /// </summary>
        /// <param name="iCustomerID">供应商标识</param>
        /// <returns></returns>
        public decimal GetAccountPayable(long iCustomerID)
        {
            return oData.QueryAccountPayable(iCustomerID);
        }

        /// <summary>
        /// 获取已付总额
        /// </summary>
        /// <param name="iCustomerID">供应商标识</param>
        /// <returns></returns>
        public decimal GetPaidUp(long iCustomerID)
        {
            return oData.QueryPaidUp(iCustomerID);
        }
    }


    /// <summary>
    /// 采购核算账务管理业务逻辑类
    /// </summary>
    public class PurchaseBalanceLogic : SellBalanceLogic
    {
        private PurchaseBalanceDB oData = new PurchaseBalanceDB();

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetCustomInfo()
        {
            return oData.QueryCustomInfo();
        }

        /// <summary>
        /// 获取采购核算单信息
        /// </summary>
        /// <param name="iCustomID">供应商标识</param>
        /// <returns></returns>
        public DataSet GetBalance(long iCustomID)
        {
            return oData.QueryBalance(iCustomID);
        }

        /// <summary>
        /// 获取付款记录
        /// </summary>
        /// <param name="iCustomID">供应商标识</param>
        /// <returns></returns>
        public DataSet GetRecord(long iCustomID)
        {
            return oData.QueryRecord(iCustomID);
        }

        /// <summary>
        /// 获取应付总额
        /// </summary>
        /// <param name="iCustomID">供应商标识</param>
        /// <returns></returns>
        public decimal GetAccountPayable(long iCustomID)
        {
            return oData.QueryAccountPayable(iCustomID);
        }

        /// <summary>
        /// 获取已付总额
        /// </summary>
        /// <param name="iCustomID">供应商标识</param>
        /// <returns></returns>
        public decimal GetPaidUp(long iCustomID)
        {
            return oData.QueryPaidUp(iCustomID);
        }
    }
}
