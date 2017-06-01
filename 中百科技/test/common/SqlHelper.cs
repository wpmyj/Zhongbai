/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：SqlHelper.cs
 * 文件功能描述：验证文本框输入的信息
 *
 * 创建人：金鹤 
 * 创建时间：20090210
 *
 * 修改人：金鹤 
 * 修改时间：20090224
 * 修改内容： 增加事务处理函数ExecuteTransaction
 *
 * 修改人：金鹤 
 * 修改时间：20090225
 * 修改内容： 增加接口继承IDisposable
 * 
 * 修改人：金鹤 
 * 修改时间：20090302
 * 修改内容： 为所有函数加事务(?)
 * 
 * 修改人：金鹤 
 * 修改时间：20090302
 * 修改内容： 删除DataBase跟DBconnection的返回函数
 * 
 * 修改人：金鹤 
 * 修改时间：20090302
 * 修改内容： 删除查询首行首列的函数
 * 
 * 修改人：金鹤 
 * 修改时间：20090302
 * 修改内容：新增对数据库的重载查询
 * 
 * 修改人：金鹤 
 * 修改时间：20090316
 * 修改内容：异常处理直接抛出原错误
 * 
 * 修改人：金鹤 
 * 修改时间：20090318
 * 修改内容：sql拼接方法后加入";"
 * 
 * 修改人：金鹤 
 * 修改时间：20090318
 * 修改内容：删除sql拼接方法后的";"
 * 
 * 修改人：金鹤 
 * 修改时间：20090319
 * 修改内容：加入用户级事务
 *
 * 修改人：金鹤 
 * 修改时间：20090320
 * 修改内容：查询方法中加入用户级事务
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;

namespace DasherStation.common
{
    /// <summary>
    /// 对数据库的基本操作类
    /// </summary>
    public class SqlHelper:IDisposable
    {
        private Database db = null;
        int ContectNum = 0;

        private bool userTransactionTag = false;

        private DbTransaction userTransaction;

        private bool m_disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {

                }
                m_disposed = true;
            }
        }

        public SqlHelper()
        {
            try
            {
                GetDb();
            }
            catch (Exception ex)
            {
                throw ;
            }
            finally
            {

            }          
        }

        public SqlHelper(string DbName)
        {
            try
            {
                GetDb(DbName);
            }
            catch (Exception ex)
            {
                throw ;
            }
            finally
            {

            }
        }

        private void GetDb()
        {
            try
            {
                db = DatabaseFactory.CreateDatabase();
            }
            catch (SqlException)
            {
                if (ContectNum < 3)
                {
                    GetDb();
                    ContectNum++;
                }
            }
            catch (Exception ex)
            {
                throw ;
            }
            finally
            {

            }
        }

        private void GetDb(string DbName)
        {
            try
            {
                db = DatabaseFactory.CreateDatabase(DbName);
            }
            catch (SqlException)
            {
                if (ContectNum < 3)
                {
                    GetDb(DbName);
                    ContectNum++;
                }
            }
            catch (Exception ex)
            {
                throw ;
            }
            finally
            {

            }
        }

        /// <summary>
        /// 启动用户事务
        /// </summary>
        public void BeginUserTran()
        {     
            DbConnection connection = db.CreateConnection();
            connection.Open();
            userTransaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
            userTransactionTag = true;
        }

        /// <summary>
        /// 提交用户事务
        /// </summary>
        public void CommitUserTran()
        {
            userTransaction.Commit();
            CloseUserConnection();
        }

        /// <summary>
        /// 回滚用户事务
        /// </summary>
        public void RollBackUserTran()
        {
            userTransaction.Rollback();
            CloseUserConnection();
        }

        /// <summary>
        /// 关闭用户事务连接
        /// </summary>
        private void CloseUserConnection()
        {
            if (userTransaction.Connection != null)
            {
                userTransaction.Connection.Close();
            }
            userTransactionTag = false;
        }

        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="sqlStr">SQL字符串</param>
        /// <returns>成功查询到结果返回DataSet,失败返回空DataSet</returns>
        public DataSet QueryForDateSet(string sqlStr)
        {
            return db.ExecuteDataSet(db.GetSqlStringCommand(sqlStr));
        }

        /// <summary>
        /// 对数据库的查询操作
        /// </summary>
        /// <param name="SqlStr">使用的SQL字符串列表</param>
        /// <returns>成功查询到结果返回DataSet,失败返回空DataSet</returns>
        public DataSet QueryForDateSet(ArrayList sqlStr)
        {
            using (DbConnection connection = db.CreateConnection())
            {

                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                StringBuilder SqlBuilder = new StringBuilder();
                foreach (string str in sqlStr)
                {
                    SqlBuilder.Append(str);
                }
                
                DbCommand dbCommand = db.GetSqlStringCommand(SqlBuilder.ToString());

                DataSet ds;

                if (!userTransactionTag)
                {
                    try
                    {
                       
                        ds=db.ExecuteDataSet(dbCommand, transaction);
                        transaction.Commit();
                        return ds;
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                   return db.ExecuteDataSet(dbCommand, userTransaction);       
                }
            }
        }

        /// <summary>
        /// 向数据库中插入一条数据
        /// </summary>
        /// <param name="SqlStr">使用的SQL字符串</param>
        /// <returns>成功返回True,失败返回False</returns>
        public bool Insert(ArrayList sqlStr)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                StringBuilder SqlBuilder = new StringBuilder();
                foreach (string str in sqlStr)
                {
                    SqlBuilder.Append(str);
                }

                DbCommand dbCommand = db.GetSqlStringCommand(SqlBuilder.ToString());

                if (!userTransactionTag)
                {
                    try
                    {
                        db.ExecuteNonQuery(dbCommand, transaction);
                        transaction.Commit();
                        return true;
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                    db.ExecuteNonQuery(dbCommand, userTransaction);
                    return true;
                }
            }
        }

        /// <summary>
        /// 删除数据库中的数据
        /// </summary>
        /// <param name="SqlStr">使用的SQL字符串</param>
        /// <returns>成功返回True,失败返回False</returns>
        public bool Delete(ArrayList sqlStr)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                StringBuilder SqlBuilder = new StringBuilder();
                foreach (string str in sqlStr)
                {
                    SqlBuilder.Append(str);
                }

                DbCommand dbCommand = db.GetSqlStringCommand(SqlBuilder.ToString());

                if (!userTransactionTag)
                {
                    try
                    {
                        db.ExecuteNonQuery(dbCommand, transaction);
                        transaction.Commit();
                        return true;
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                    db.ExecuteNonQuery(dbCommand, userTransaction);
                    return true;
                }
            }
            
        }

        /// <summary>
        /// 更新数据库中的数据
        /// </summary>
        /// <param name="SqlStr">使用的SQL字符串</param>
        /// <returns>成功返回True,失败返回False</returns>
        public bool Update(ArrayList sqlStr)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                StringBuilder SqlBuilder = new StringBuilder();
                foreach (string str in sqlStr)
                {
                    SqlBuilder.Append(str);
                }
                
                DbCommand dbCommand = db.GetSqlStringCommand(SqlBuilder.ToString());

                if (!userTransactionTag)
                {
                    try
                    {
                        db.ExecuteNonQuery(dbCommand, transaction);
                        transaction.Commit();
                        return true;
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                    db.ExecuteNonQuery(dbCommand, userTransaction);
                    return true;
                }
            }
        }

        /// <summary>
        /// 采用事务执行SQL语句,不成功自动回滚
        /// </summary>
        /// <param name="sqlStr">SQL语句的字符串数组</param>
        /// <returns>True:成功执行 False:执行失败，并已回滚</returns>
        public bool ExecuteTransaction(ArrayList sqlStr)
        {
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();

                StringBuilder SqlBuilder = new StringBuilder();
                foreach (string str in sqlStr)
                {
                    SqlBuilder.Append(str);
                }

                DbCommand dbCommand = db.GetSqlStringCommand(SqlBuilder.ToString());

                if (!userTransactionTag)
                {
                    try
                    {
                        db.ExecuteNonQuery(dbCommand, transaction);
                        transaction.Commit();
                        return true;
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                    db.ExecuteNonQuery(dbCommand, userTransaction);
                    return true;
                }
            }
        }

        /// <summary>
        /// 获取当前数据库链接串
        /// </summary>
        public string SqlConn
        {
            get
            {
                return this.db.ConnectionString;
            }
        }

    }
}
