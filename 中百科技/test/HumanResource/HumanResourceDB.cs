/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：HumanResourceDB.cs
* 文件功能描述：人力资源数据库访问类
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DasherStation.common;

namespace DasherStation.HumanResource
{
    /*
      * 类名称：HumanResourceDB
      * 类功能描述：人力资源数据库静态类
      *
      * 创建人：杨林
      * 创建时间：2009-03-12
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    /// <summary>
    /// 人力资源数据库静态类
    /// </summary>
    public class HumanResourceDB
    {
       /*
       * 方法名称：QueryAllPersonnel
       * 方法功能描述：获取全部员工实体数组
       *
       * 创建人：杨林
       * 创建时间：2009-03-12
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        /// <summary>
        /// 获取全部员工实体数组
        /// </summary>
        /// <returns></returns>
        public static PersonnelInfo[] QueryAllPersonnel()
        {
            HumanResourceDataContext oHumanContext = new HumanResourceDataContext(new SqlHelper().SqlConn);
            oHumanContext.ObjectTrackingEnabled = false;
            var result = from item in oHumanContext.PersonnelInfo
                         select item;
            try
            {

                return result.ToArray<PersonnelInfo>();
            }
            catch (System.Data.SqlClient.SqlException)
            {                
                return new PersonnelInfo[]{new PersonnelInfo{name="读取数据库出错!"}};
            }
        }

        /*
       * 方法名称：QueryTaxBase
       * 方法功能描述：获取扣税基数
       *
       * 创建人：杨林
       * 创建时间：2009-03-12
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        /// <summary>
        /// 获取扣税基数
        /// </summary>
        /// <returns></returns>
        public static decimal QueryTaxBase()
        {
            HumanResourceDataContext oHumanContext = new HumanResourceDataContext(new SqlHelper().SqlConn);           
            try
            {

                return decimal.Parse(
                    (from taxBas in oHumanContext.SalaryParameter
                    select taxBas.taxBase).First().ToString()
                    );
            }
            catch (System.Data.SqlClient.SqlException)
            {
                throw;
            }
        }

        public static decimal? QueryBase(int iHumanID)
        {
            using (SqlHelper oHelper = new SqlHelper())
            {
                using (HumanResourceDataContext oHumanContext = new HumanResourceDataContext(oHelper.SqlConn))
                {
                    oHumanContext.ObjectTrackingEnabled = false;
                    var result = from item in oHumanContext.PersonnelInfo 
                                 where item.id == iHumanID
                                 select item.basicSalary;
                    return result.FirstOrDefault();
                }
            }
        }
    }


    /*
      * 类名称：PayrollDB
      * 类功能描述：工资项数据访问类
      *
      * 创建人：杨林
      * 创建时间：2009-03-05
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    /// <summary>
    /// 工资项数据访问类
    /// </summary>
    public class PayrollDB
    {
        private DasherStation.common.SqlHelper oSqlHelper = new SqlHelper();

        /*
       * 方法名称：InsertPayroll
       * 方法功能描述：插入工资项
       *
       * 创建人：杨林
       * 创建时间：2009-03-12
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        /// <summary>
        /// 插入工资项
        /// </summary>
        /// <param name="arg">工资项实体类</param>
        /// <returns>返回错误描述,如果为空串则为执行成功</returns>
        public string InsertPayroll(PayrollAdd arg)
        {
            try
            {
                HumanResourceDataContext oHumanContext = new HumanResourceDataContext(this.oSqlHelper.SqlConn);
                oHumanContext.ObjectTrackingEnabled = false;
                var result = from item in oHumanContext.PayrollAdd.AsQueryable<PayrollAdd>()
                             where item.name == arg.name
                             select item.name;
                if (result.Count() > 0) return "指定工资项名称己存在!";
                oHumanContext.ObjectTrackingEnabled = true;

                oHumanContext.PayrollAdd.InsertOnSubmit(arg);
                oHumanContext.SubmitChanges();
                return "";
            }
            catch (System.Data.SqlClient.SqlException)
            {
                throw;
            }
            finally
            {
            }
            
        }

        /*
       * 方法名称：DeletePayroll
       * 方法功能描述：删除工资项
       *
       * 创建人：杨林
       * 创建时间：2009-03-12
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        /// <summary>
        /// 删除工资项
        /// </summary>
        /// <param name="id">工资项标识数组</param>
        /// <returns>返回错误描述,如果为空串则为执行成功</returns>
        public string DeletePayroll(long[] id)
        {
            try
            {
                HumanResourceDataContext oHumanContext = new HumanResourceDataContext(this.oSqlHelper.SqlConn);
                // Query the database for the rows to be deleted.
                var deletePayroll =
                    from items in oHumanContext.PayrollAdd
                    where id.Contains(items.id)
                    select items;

                foreach (var item in deletePayroll)
                {
                    oHumanContext.PayrollAdd.DeleteOnSubmit(item);
                }

                oHumanContext.SubmitChanges();
                return "";
            }
            catch (System.Data.SqlClient.SqlException)
            {
                throw;
            }
            finally
            {
            }
            
        }

        /*
       * 方法名称：QueryPayroll
       * 方法功能描述：获取全部工资项数据集
       *
       * 创建人：杨林
       * 创建时间：2009-03-12
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        /// <summary>
        /// 获取全部工资项数据集
        /// </summary>
        /// <returns>DataSet</returns>
        public System.Data.DataSet QueryPayroll()
        {
            try
            {
                string strSQL = @"
SELECT id as iID, name as cName, inputDate as dInput, inputMan as cInputMan, 
remark as cMemo, updateDate as dUpdate, updateMan as cUpdateMan, 
case kind 
	when 0 then '正式员工' 
	when 1 then '临时工' 
	else '全部员工' end as cKind, 
case  
	when (minusPlace=0 and mark=0) then '税前减项'
	when (minusPlace=1) then ''
	end as fMinusPlace,
case minusPlace 
	when 0 then ''
	when 1 then '税后减项'
	end as bMinusPlace,
MinusPlace,
CASE mark 
	WHEN 0 THEN '薪水减项' 
	ELSE '薪水增项' END as cMark
FROM payrollAdd";

                System.Collections.ArrayList al = new System.Collections.ArrayList();
                al.Add(strSQL);
                return this.oSqlHelper.QueryForDateSet(al);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                throw;
            }
            finally
            {
            }            
        }
    }



    /*
      * 类名称：PayOffDB
      * 类功能描述：工资发放数据库访问类
      *
      * 创建人：杨林
      * 创建时间：2009-03-05
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    /// <summary>
    /// 工资发放数据库访问类
    /// </summary>
    public class PayOffDB
    {
        private DasherStation.common.SqlHelper oSqlHelper = new DasherStation.common.SqlHelper();

        public string[] QueryPayrollItemName()
        {
            HumanResourceDataContext oHumanContext = new HumanResourceDataContext(this.oSqlHelper.SqlConn);
            oHumanContext.ObjectTrackingEnabled = false;
            var result = from item in oHumanContext.PayrollAdd
                         select item.name;
            try
            {
                return result.ToArray<string>();
            }
            catch (System.Data.SqlClient.SqlException)
            {                
                return null;
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PayRollItem[] QueryPayRollItems()
        {
            string strSQL = @"select id,name,kind,mark,minusPlace from PayrollAdd";
            ArrayList sqlArray = new ArrayList();
            System.Data.DataSet dtsResult = null;
            sqlArray.Add(strSQL);
            try
            {
                dtsResult = this.oSqlHelper.QueryForDateSet(sqlArray);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return null;
            }
            if(dtsResult.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            PayRollItem[] oReturnValue = new PayRollItem[dtsResult.Tables[0].Rows.Count];
            for (int i = 0; i < dtsResult.Tables[0].Rows.Count; i++ )
            {
                System.Data.DataRow row = dtsResult.Tables[0].Rows[i];
                var item = new PayRollItem();
                item.ID = Int32.Parse(row["id"].ToString());
                item.Name = row["name"].ToString();
                object oEmployeeType = row["kind"];
                if (oEmployeeType.ToString() == "0")
                {
                    item.EmployeeType = EnumEmployeeType.Official;
                }
                else if (oEmployeeType.ToString() == "1")
                {
                    item.EmployeeType = EnumEmployeeType.Temp;
                }
                else if (oEmployeeType.ToString() == "2")
                {
                    item.EmployeeType = EnumEmployeeType.Staff;
                }
                item.IsMinus = row["mark"].ToString().ToLower() == "false" ? true : false;
                item.IsFirstMinus = row["minusPlace"].ToString().ToLower() == "false" ? true : false;
                oReturnValue[i] = item;
            }
            return oReturnValue;
        }

        /*
       * 方法名称：InsertPayOff
       * 方法功能描述：插入工资
       *
       * 创建人：杨林
       * 创建时间：2009-03-12
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        /// <summary>
        /// 插入工资
        /// </summary>
        /// <param name="args">工资强类型</param>
        /// <returns></returns>
        public void InsertPayOff(PayOffDTS args)
        {
            if (args.payOffGather.Count <= 0)
            {
                return;
            }            
            using (System.Transactions.TransactionScope oScope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, TimeSpan.MaxValue))
            {                
                using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(new DasherStation.common.SqlHelper().SqlConn))
                {
                    sqlConn.Open();
                    System.Data.SqlClient.SqlCommand cmdExec = new System.Data.SqlClient.SqlCommand();
                    cmdExec.Connection = sqlConn;
                    foreach(PayOffDTS.payOffGatherRow oRow in args.payOffGather.Rows)
                    {
                        cmdExec.Parameters.Clear();
                        cmdExec.CommandText = @"
INSERT INTO [dbo].[payOffGather] ([piId], [realIncome], [date], [inputDate], [inputMan], name) 
VALUES (@piId, @realIncome, @month, getdate(), @inputMan, @name);select SCOPE_IDENTITY()";                       
                        cmdExec.Parameters.Add(new System.Data.SqlClient.SqlParameter("@piId", oRow.IspiIdNull() ? (object)System.DBNull.Value : oRow.piId));
                        cmdExec.Parameters.Add(new System.Data.SqlClient.SqlParameter("@realIncome", oRow.IsrealIncomeNull() ? (object)System.DBNull.Value : oRow.realIncome));
                        cmdExec.Parameters.Add(new System.Data.SqlClient.SqlParameter("@month", oRow.IsmonthNull() ? (object)System.DBNull.Value : oRow.month));
                        cmdExec.Parameters.Add(new System.Data.SqlClient.SqlParameter("@inputMan", oRow.IsinputManNull() ? (object)System.DBNull.Value : oRow.inputMan));
                        cmdExec.Parameters.Add(new System.Data.SqlClient.SqlParameter("@name", oRow.name));
                        // 插入人员实际所得;
                        string strPogId = cmdExec.ExecuteScalar().ToString();

                        // 遍历薪水项目将该项及值插入到数据库payOffDetail（薪水发放明细表）中.
                        foreach (PayOffDTS.payOffDetailRow rollRow in args.payOffDetail.Where(arg => arg.piId == oRow.piId))
                        {
                            rollRow.pogId = int.Parse(strPogId);
                            cmdExec.Parameters.Clear();
                            cmdExec.CommandText = @"
INSERT INTO [dbo].[payOffDetail] ([paid], [piId], [money], [month], [inputDate], [inputMan],pogid) 
VALUES (@paid, @piId, @money, @month, getDate(), @inputMan, @pogid)";
                            cmdExec.Parameters.Add(new System.Data.SqlClient.SqlParameter("@paid", rollRow.IspaidNull() ? (object)System.DBNull.Value : rollRow.paid));
                            cmdExec.Parameters.Add(new System.Data.SqlClient.SqlParameter("@piId", rollRow.IspiIdNull() ? (object)System.DBNull.Value : rollRow.piId));
                            cmdExec.Parameters.Add(new System.Data.SqlClient.SqlParameter("@money", rollRow.IsmoneyNull() ? (object)System.DBNull.Value : rollRow.money));
                            cmdExec.Parameters.Add(new System.Data.SqlClient.SqlParameter("@month", rollRow.IsmonthNull() ?(object)System.DBNull.Value : rollRow.month));
                            cmdExec.Parameters.Add(new System.Data.SqlClient.SqlParameter("@inputMan", rollRow.IsinputManNull() ? (object)System.DBNull.Value : rollRow.inputMan));
                            cmdExec.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pogid", rollRow.IspogIdNull() ? (object)System.DBNull.Value : rollRow.pogId));                            
                            cmdExec.ExecuteNonQuery();
                        }
                    }
                }
                oScope.Complete();
            }
        }

        /*
       * 方法名称：QueryPay
       * 方法功能描述：查询指定年月,工资发放名称的员工工资
       *
       * 创建人：杨林
       * 创建时间：2009-03-12
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        /// <summary>
        /// 查询指定年月,工资发放名称的并且审批通过的员工工资
        /// </summary>
        /// <param name="iYear">年</param>
        /// <param name="iMonth">月</param>
        /// <param name="strPayoffName">工资发放名称</param>
        /// <returns></returns>
        public System.Data.DataSet QueryPay(int iYear, int iMonth, string strPayoffName)
        {       
            string _strPayoffName = "";
            if (string.IsNullOrEmpty(strPayoffName) == false)
            {
                _strPayoffName = " and a.name = @cPayoffName ";
            }

            string strSQL = string.Format(@"
select d.name as cHumanName,c.name as cPayRollName,sum(money)as realInCome FROM payOffDetail b 
		join payOffGather a on a.id = b.pogid
		join PayrollAdd c on b.paid = c.id
		join personnelInfo d on b.piid = d.id
        join payOffGather2 e on a.id = e.pogid
	where (b.month = @month and year(a.date)=@year)
    and e.checkupman is not null 
	{0} 
	group by d.name,c.name
union
select d.name,'实际所得',sum(realIncome) from payOffGather a, personnelInfo d ,payOffGather2 e
	where (month(a.date)=@month and year(a.date)=@year) 
	and a.piId = d.id 	
    and a.id = e.pogid
    and e.checkupman is not null
	{0} 
group by d.name
", _strPayoffName);
            
            System.Data.DataSet dtsResult = new System.Data.DataSet();

            System.Data.SqlClient.SqlCommand sqlCmdExec = new System.Data.SqlClient.SqlCommand(strSQL, new System.Data.SqlClient.SqlConnection(this.oSqlHelper.SqlConn));
            sqlCmdExec.Parameters.AddWithValue("@month", iMonth);
            sqlCmdExec.Parameters.AddWithValue("@year", iYear);
            if (string.IsNullOrEmpty(strPayoffName) == false)
            {
                sqlCmdExec.Parameters.AddWithValue("@cPayoffName", strPayoffName);
            }
            new System.Data.SqlClient.SqlDataAdapter(sqlCmdExec).Fill(dtsResult);
            return dtsResult;
        }

        /// <summary>
        /// 查询指定年月,工资发放名称的全部员工工资(包括未审批的)
        /// </summary>
        /// <param name="iYear">年</param>
        /// <param name="iMonth">月</param>
        /// <param name="strPayoffName">工资发放名称</param>
        /// <returns></returns>
        public System.Data.DataSet QueryPayAudit(int iYear, int iMonth, string strPayoffName)
        {            
            if (string.IsNullOrEmpty(strPayoffName))
            {
                return null;
            }

            string strSQL = @"
select a.id,d.name as cHumanName,c.name as cPayRollName,sum(money)as realInCome,
		case 
			when e.assessor is null then '未审核'
			else '已审核'
		end as AssessState,
		case 
			when e.checkupman is null then '未审批'
			else '已审批'
		end as checkupState
		FROM payOffDetail b 
		join payOffGather a on a.id = b.pogid
		join PayrollAdd c on b.paid = c.id
		join personnelInfo d on b.piid = d.id        
        left join payOffGather2 e on a.id = e.pogid
	where (b.month = @month and year(a.date)=@year)    
	and a.name = @cPayoffName  
	group by a.id,d.name,c.name,e.assessor,e.checkupman
union
select a.id,d.name,'实际所得',sum(realIncome),
	case 
		when e.assessor is null then '未审核'
		else '已审核'
	end as AssessState,
	case 
		when e.checkupman is null then '未审批'
		else '已审批'
	end as checkupState
	from payOffGather a
	inner join personnelInfo d on a.piId = d.id 	    
	left join payOffGather2 e on a.id = e.pogid    
	where (month(a.date)=@month and year(a.date)=@year) 	
	and a.name = @cPayoffName 
group by a.id,d.name,e.assessor,e.checkupman
";

            System.Data.DataSet dtsResult = new System.Data.DataSet();

            System.Data.SqlClient.SqlCommand sqlCmdExec = new System.Data.SqlClient.SqlCommand(strSQL, new System.Data.SqlClient.SqlConnection(this.oSqlHelper.SqlConn));
            sqlCmdExec.Parameters.AddWithValue("@month", iMonth);
            sqlCmdExec.Parameters.AddWithValue("@year", iYear);            
            sqlCmdExec.Parameters.AddWithValue("@cPayoffName", strPayoffName);            
            new System.Data.SqlClient.SqlDataAdapter(sqlCmdExec).Fill(dtsResult);
            return dtsResult;
        }

        /// <summary>
        /// 审核工资
        /// </summary>
        /// <param name="gatherID"></param>
        public void Assess(long gatherID, bool bPass,  string strHumanName)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.oSqlHelper.SqlConn))
            {
                PayOffGather2 result;
                bool bExist = false;
                result = (from item in oContext.PayOffGather2
                              where item.pogid == gatherID
                              select item).FirstOrDefault();
                if (result == null)
                {
                    result = new PayOffGather2();
                    result.pogid = gatherID;
                }
                else
                {
                    bExist = true;
                }
                if (bPass)
                {
                    result.inputman = strHumanName;
                    result.assessor = strHumanName;
                    result.assessordate = DateTime.Now;
                    result.checkupdate = null;
                    result.checkupman = null;
                }
                else
                {                                        
                    result.assessor = null;
                    result.assessordate = null;
                    result.checkupdate = null;
                    result.checkupman = null;
                }
                if(bExist == false)
                {
                    oContext.PayOffGather2.InsertOnSubmit(result);
                }
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 判断工资是否已审核
        /// </summary>
        /// <param name="gatherID"></param>
        /// <returns></returns>
        public bool IsAssess(long gatherID)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.oSqlHelper.SqlConn))
            {
                var result= (from item in oContext.PayOffGather2
                        where item.pogid == gatherID && item.assessor != null
                        select item);
                return result.Count() > 0;
            }
        }

        /// <summary>
        /// 审批工资
        /// </summary>
        /// <param name="gatherID"></param>
        public void Checkup(long gatherID, bool bPass, string strHumanName)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.oSqlHelper.SqlConn))
            {
                PayOffGather2 result;
                bool bExist = false;
                result = (from item in oContext.PayOffGather2
                          where item.pogid == gatherID
                          select item).FirstOrDefault();
                if (result == null)
                {
                    result = new PayOffGather2();
                    result.pogid = gatherID;
                }
                else
                {
                    bExist = true;
                }
                if (bPass)
                {                    
                    result.checkupdate = DateTime.Now;
                    result.checkupman = strHumanName;
                }
                else
                {                    
                    result.assessor = null;
                    result.assessordate = null;
                    result.checkupdate = null;
                    result.checkupman = null;
                }
                if (bExist == false)
                {
                    oContext.PayOffGather2.InsertOnSubmit(result);
                }
                oContext.SubmitChanges();
            }
        }

        public bool IsExistPayName(string strName)
        {
            string strSQL = @"
SELECT count(name) from payOffGather
where (name=@name)";
            System.Data.DataSet dtsResult = new System.Data.DataSet();
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(this.oSqlHelper.SqlConn))
            {
                sqlConn.Open();
                System.Data.SqlClient.SqlCommand sqlCmdExec = new System.Data.SqlClient.SqlCommand(strSQL, sqlConn);
                sqlCmdExec.Parameters.AddWithValue("@name", strName);
                return sqlCmdExec.ExecuteScalar().ToString() != "0";
            }
        }

        /// <summary>
        /// 获取全部工资发放名称
        /// </summary>
        /// <returns></returns>
        public string[] QueryPayoffName()
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.oSqlHelper.SqlConn))
            {
                return (from item in oContext.PayOffGather
                        select item.name).ToArray();
            }
        }
    }


    /// <summary>
    /// 员工数据库访问类
    /// </summary>
    public class EmployeeDB
    {
        string strConn = null;

        public EmployeeDB()
        {
            using (DasherStation.common.SqlHelper h = new DasherStation.common.SqlHelper())
            {
                strConn = h.SqlConn;
            }
        }

        /// <summary>
        /// 添加新员工
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(PersonnelInfo entity)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                oContext.PersonnelInfo.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 插入职位信息
        /// </summary>
        /// <param name="entity"></param>
        public void InsertPosition(Position entity)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                //entity.inputDate = DateTime.Now;
                oContext.Position.InsertOnSubmit(entity);
                oContext.SubmitChanges();                
            }
        }

        /// <summary>
        /// 查询指定职位名称是否存在
        /// </summary>
        /// <param name="strPositionName"></param>
        /// <returns></returns>
        public bool IsExistPosition(string strPositionName)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                return (from Position item in oContext.Position
                        where item.name == strPositionName
                        select item.id).Count() > 0;
            }
        }

        /// <summary>
        /// 查询全部职位信息
        /// </summary>
        /// <returns></returns>
        public List<Position> QueryPositions()
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                return (from item in oContext.Position select item).ToList();
            }
        }

        /// <summary>
        /// 插入生产班组信息
        /// </summary>
        /// <param name="entity"></param>        
        public void InsertYieldGroup(ProduceTeam entity)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                //entity.inputDate = DateTime.Now;
                oContext.ProduceTeam.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 查询指定生产班组是否存在
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public bool IsExistYieldGroup(string strName, long strDID)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                return (from ProduceTeam item in oContext.ProduceTeam
                        where item.name == strName && item.did == strDID
                        select item.id).Count() > 0;
            }
        }

        /// <summary>
        /// 查询全部生产班组信息
        /// </summary>
        /// <returns></returns>
        public List<ProduceTeam> QueryYieldGroups()
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                var options = new System.Data.Linq.DataLoadOptions();
                options.LoadWith<ProduceTeam>(p => p.Department);
                options.LoadWith<ProduceTeam>(p => p.EquipmentInformation);
                oContext.LoadOptions = options;
                var result = from item in oContext.ProduceTeam 
                             select item;
                return result.ToList();
            }
        }

        
        /// <summary>
        /// 获取指定部门下的生产班组信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ProduceTeam> QueryYieldGroupByDepID(long iDepid)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {   
                return (from item in oContext.ProduceTeam
                        where item.did == iDepid
                        select item).ToList();
            }
        }

        /// <summary>
        /// 更新员工
        /// </summary>
        /// <param name="entity"></param>
        public void Update(PersonnelInfo entity)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                PersonnelInfo ori = (from p in oContext.PersonnelInfo
                                     where p.id == entity.id
                                     select p).First();
                ori.no = entity.no;
                ori.name = entity.name;
                ori.address = entity.address;
                ori.basicSalary = entity.basicSalary;
                ori.birthday = entity.birthday;
                ori.competencyCertificate = entity.competencyCertificate;
                ori.contactMethod = entity.contactMethod;
                ori.contractNo = entity.contractNo;
                ori.dId = entity.dId;
                ori.dimissionDate = entity.dimissionDate;
                ori.dimissionReason = entity.dimissionReason;
                ori.function = entity.function;
                ori.functionAssessDate = entity.functionAssessDate;
                ori.hortationCastigate = entity.hortationCastigate;
                ori.IDCard = entity.IDCard;
                ori.judgeMarry = entity.judgeMarry;
                ori.kind = entity.kind;
                ori.mark = entity.mark;                
                ori.nationality = entity.nationality;
                ori.nativePlace = entity.nativePlace;                
                ori.pId = entity.pId;
                ori.politicalVisage = entity.politicalVisage;
                ori.ptId = entity.ptId;
                ori.remark = entity.remark;
                ori.resume = entity.resume;
                ori.salaryMethod = entity.salaryMethod;
                ori.sex = entity.sex;
                ori.specialty = entity.specialty;
                ori.startWorkDate = entity.startWorkDate;
                ori.tiptopDegree = entity.tiptopDegree;
                ori.workDate = entity.workDate;

                try
                {
                    oContext.SubmitChanges();
                }
                catch (System.Data.Linq.ChangeConflictException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 判断指定员工编号是否存在
        /// </summary>
        /// <param name="strNo"></param>
        /// <returns></returns>
        public bool IsExistByNo(string strNo)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                var result = (from item in oContext.PersonnelInfo
                              where item.no.Trim() == strNo.Trim()
                              select item.id).Count();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 判断指定员工名称是否存在
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public bool IsExistByName(string strName)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                var result = (from item in oContext.PersonnelInfo
                              where item.name.Trim() == strName.Trim()
                              select item.id).Count();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int[] id)
        {
            HumanResourceDataContext oHumanContext = new HumanResourceDataContext(this.strConn);
            var deleting =
                from item in oHumanContext.PersonnelInfo
                where id.Contains((int)item.id)
                select item;

            foreach (var item in deleting)
            {
                oHumanContext.PersonnelInfo.DeleteOnSubmit(item);
            }

            oHumanContext.SubmitChanges();
        }

        /// <summary>
        /// 删除生产班组
        /// </summary>
        /// <param name="id"></param>
        public void DeleteYieldGroup(int[] id)
        {
            HumanResourceDataContext oHumanContext = new HumanResourceDataContext(this.strConn);
            var deleting =
                from item in oHumanContext.ProduceTeam
                where id.Contains((int)item.id)
                select item;

            foreach (var item in deleting)
            {
                oHumanContext.ProduceTeam.DeleteOnSubmit(item);
            }

            oHumanContext.SubmitChanges();
        }

        /// <summary>
        /// 删除职位信息
        /// </summary>
        /// <param name="id"></param>
        public void DeletePosition(int[] id)
        {
            HumanResourceDataContext oHumanContext = new HumanResourceDataContext(this.strConn);
            var deleting =
                from item in oHumanContext.Position
                where id.Contains((int)item.id)
                select item;

            foreach (var item in deleting)
            {
                oHumanContext.Position.DeleteOnSubmit(item);
            }

            oHumanContext.SubmitChanges();
        }

        /// <summary>
        /// 获取全部员工实体列表
        /// </summary>
        /// <returns></returns>
        public List<PersonnelInfo> QueryEmployees()
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                var result = from item in oContext.PersonnelInfo
                             orderby item.id descending
                             select item;
                return result.ToList();
            }
        }

        public PersonnelInfo QueryEmployeeByID(long id)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                var result = from item in oContext.PersonnelInfo
                             where item.id == id
                             select item;
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取全部员工数据集
        /// </summary>
        /// <returns></returns>
        public DataSet QueryDTSForEmployees()
        {
            string strSQL = @"
select 
a.no as '职工编号', 
a.name as 'name',
sex as '性别',
b.name as '职位',--position
c.name as '部门',--department
d.name as '生产班组',--ptId produceTeam
case kind
when 0 then '正式'
when 1 then '临时' 
end as '职工类别' ,
workDate as '入职日期',
basicSalary as '基本工资'
from personnelinfo a
left join position b on a.pid = b.id
left join department c on a.did = c.id
left join produceTeam d on a.ptId = d.id
";
            using (System.Data.SqlClient.SqlConnection sqlconn = new System.Data.SqlClient.SqlConnection(this.strConn))
            {
                using (System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(strSQL, sqlconn))
                {
                    DataSet dtsResult = new DataSet();
                    adapter.Fill(dtsResult);
                    return dtsResult;
                }
            }
        }

        public DataSet QueryEPInfo()
        {
            string strSQL = "select id,no from equipmentInformation";
            using (DasherStation.common.SqlHelper h = new DasherStation.common.SqlHelper())
            {
                return h.QueryForDateSet(strSQL);
            }
        }
    }



    /// <summary>
    /// 工资模板数据访问类
    /// </summary>
    public class PayRollTempalteDB
    {
        private string strConn = null;

        public PayRollTempalteDB()
        {
            using (DasherStation.common.SqlHelper sqlHelper = new DasherStation.common.SqlHelper())
            {
                this.strConn = sqlHelper.SqlConn;
            }
        }

        /// <summary>
        /// 判断指定模板名称的模板是否存在
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public bool IsExist(string strName)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                var result = (from item in oContext.SalaryItemTemplet
                              where item.name.Trim() == strName.Trim()
                              select item.id).Count();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 插入模板
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(DasherStation.HumanResource.SalaryItemTemplet entity)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                oContext.SalaryItemTemplet.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 查询指定模板名称的模板
        /// </summary>
        /// <param name="strName">模板名称</param>
        /// <returns></returns>
        public SalaryItemTemplet Query(string strName)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                var result = (from item in oContext.SalaryItemTemplet
                              where item.name == strName
                              select item).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// 获取全部模板名称列表
        /// </summary>
        /// <returns></returns>
        public string[] QueryAllTemplateName()
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                var result = from item in oContext.SalaryItemTemplet
                             select item.name;
                return result.ToArray();
            }
        }
    }

    /// <summary>
    /// 部门数据库访问类
    /// </summary>
    public class DepartmentDB
    {
        string strConn = null;
        public DepartmentDB()
        {
            using (DasherStation.common.SqlHelper h = new DasherStation.common.SqlHelper())
            {
                strConn = h.SqlConn;
            }
        }

        /// <summary>
        /// 插入部门信息
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(Department entity)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                oContext.Department.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 判断指定部门编号是否存在
        /// </summary>
        /// <param name="strNo"></param>
        /// <returns></returns>
        public bool IsExistByNo(string strNo)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                var result = (from item in oContext.Department
                              where item.no.Trim() == strNo.Trim()
                              select item.id).Count();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 判断指定部门名称是否存在
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public bool IsExistByName(string strName)
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                var result = (from item in oContext.Department
                              where item.name.Trim() == strName.Trim()
                              select item.id).Count();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 删除指定标识的部门
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int[] id)
        {
            HumanResourceDataContext oHumanContext = new HumanResourceDataContext(this.strConn);
            var deleting =
                from item in oHumanContext.Department
                where id.Contains((int)item.id)
                select item;

            foreach (var item in deleting)
            {
                oHumanContext.Department.DeleteOnSubmit(item);
            }

            oHumanContext.SubmitChanges();
        }

        /// <summary>
        /// 获取全部部门信息
        /// </summary>
        /// <returns></returns>
        public List<Department> QueryDepartMents()
        {
            using (HumanResourceDataContext oContext = new HumanResourceDataContext(this.strConn))
            {
                var result = from item in oContext.Department
                             select item;
                return result.ToList();
            }
        }

    }
}
