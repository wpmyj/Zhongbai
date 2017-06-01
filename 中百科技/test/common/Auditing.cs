using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections;
using System.Data;

namespace DasherStation.common
{
    public delegate void AuditingEventHandler(Auditing auditing, SqlHelper sqlHelper);

    public class Auditing
    {
        private long id;
        /// <summary>
        /// 待审核表ID
        /// </summary>
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string idName;
        /// <summary>
        /// ID对应的字段名称
        /// </summary>
        public string IdName
        {
            get { return idName; }
            set { idName = value; }
        }

        private string tableName;
        /// <summary>
        /// 待审核表名称
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        private string assessor;
        /// <summary>
        /// 审核人
        /// </summary>
        public string Assessor
        {
            get { return assessor; }
            set { assessor = value; }
        }

        private string checkupMan;
        /// <summary>
        /// 审批人
        /// </summary>
        public string CheckupMan
        {
            get { return checkupMan; }
            set { checkupMan = value; }
        }

        private bool confirm;
        /// <summary>
        /// 审核意见
        /// </summary>
        public bool Confirm
        {
            get { return confirm; }
            set { confirm = value; }
        }
        /// <summary>
        ///  审核时间
        /// </summary>
        private string assessDate;

        public string AssessDate
        {
            get { return assessDate; }
            set { assessDate = value; }
        }
        /// <summary>
        /// 审批时间
        /// </summary>
        private string checkupDate;

        public string CheckupDate
        {
            get { return checkupDate; }
            set { checkupDate = value; }
        }
    }

    public class AuditingAction
    {
        SqlHelper sqlHelper = new SqlHelper();

        public AuditingEventHandler AuditingEvent;

        public Auditing auditing;

        public AuditingAction(string idName, string tableName)
        {
            auditing = new Auditing();
            auditing.IdName = idName;
            auditing.TableName = tableName;
        }

        /// <summary>
        /// 执行审核操作
        /// </summary>
        /// <param name="auditing">审核表对象</param>
        /// <returns>0：审核成功 1：该信息已被审核 2：未查询到该条信息</returns>
        public int DoAssessor(long id, string assessor)
        {
            auditing.Id = id;
            auditing.Assessor = assessor;
            auditing.AssessDate = "'"+DateTime.Now.ToString()+"'";
            auditing.CheckupDate = null;
            auditing.CheckupMan = null;
            return DoAssessor(auditing);
        }

        /// <summary>
        /// 执行审核操作
        /// </summary>
        /// <param name="auditing">审核表对象</param>
        /// <returns>0：审核成功 1：该信息已被审核 2：未查询到该条信息</returns>
        public int DoAssessor(Auditing auditing)
        {
            DataTable dt = GetConfirmName(auditing);
            if (dt.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dt.Rows[0]["assessor"].ToString()))
                {
                    UpdateConfirm(auditing);
                    return 0;//审核成功
                }
                else
                {
                    return 1;//已被审核过
                }
            }
            else
            {
                return 2;//未查询到该信息
            }        
        }

        /// <summary>
        /// 执行审批操作
        /// </summary>
        /// <param name="auditing">审核表对象</param>
        /// <returns>0：审批成功 1：该信息已被审批 2：未查询到该条信息 3：未审核的信息不能被审批</returns>
        public int DoConfirm(long id,string checkupMan,bool confirm)
        {
            auditing.Id = id;
            auditing.Assessor = null;
            auditing.CheckupMan = checkupMan;
            auditing.CheckupDate = "'"+DateTime.Now.ToString()+"'";
            auditing.AssessDate = null;
            auditing.Confirm = confirm;
            return DoConfirm(auditing);
        }

        /// <summary>
        /// 执行审批操作
        /// </summary>
        /// <param name="auditing">审核表对象</param>
        /// <returns>0：审批成功 1：该信息已被审批 2：未查询到该条信息 3：未审核的信息不能被审批</returns>
        public int DoConfirm(Auditing auditing)
        {
            DataTable dt = GetConfirmName(auditing);
            if (dt.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dt.Rows[0]["assessor"].ToString()))
                {
                    return 3;//尚未审核的信息不能审批
                }
                else if (!string.IsNullOrEmpty(dt.Rows[0]["checkupMan"].ToString()))
                {
                    return 1;//已被审批过
                }
                else
                {
                    try
                    {
                        sqlHelper.BeginUserTran();
                        if (!auditing.Confirm)
                        {

                            auditing.Assessor = "" ;
                            auditing.CheckupMan = "";
                            auditing.AssessDate = "null";
                            auditing.CheckupDate = "null";
           
                        }
                        UpdateConfirm(auditing);
                        if (AuditingEvent != null)
                        {
                            AuditingEvent(auditing, sqlHelper);
                        }
                        sqlHelper.CommitUserTran();
                        return 0;
                    }
                    catch
                    {
                        sqlHelper.RollBackUserTran();
                        throw;
                    }
                   
                }
            }
            else
            {
                return 2;//未查询到该信息
            }        
            
        }

        public DataTable GetConfirmName(Auditing auditing)
        {
            return sqlHelper.QueryForDateSet("select assessor,checkupMan from " + auditing.TableName + " where " + auditing.IdName + "=" + auditing.Id.ToString()).Tables[0];
        }

        public bool UpdateConfirm(Auditing auditing)
        {
           return sqlHelper.Update(new ArrayList() { GetUpdateSql(auditing) });
        }

        private string GetUpdateSql(Auditing model)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("update " + model.TableName + " set ");

            if (model.Assessor!= null)
            {
                strSql.Append("Assessor='" + model.Assessor + "',");
            }
            if (model.CheckupMan!= null)
            {
                strSql.Append("CheckupMan='" + model.CheckupMan + "',");
            }
            if (model.AssessDate != null)
            {

                strSql.Append("assessDate= " + model.AssessDate + ",");

            }
            if (model.CheckupDate != null)
            {
                strSql.Append("checkupDate=" + model.CheckupDate + ",");
            }
          

          
            int n = strSql.ToString().LastIndexOf(",");

            strSql.Remove(n, 1);

            if (model.IdName != null)
            {
                strSql.Append(" where " + model.IdName + "=" + model.Id + " ");
            }
            return strSql.ToString();
        }
    }
}
