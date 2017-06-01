/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：HumanResourceLogic.cs
* 文件功能描述：人力资源业务逻辑类
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
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DasherStation.HumanResource
{
    /*
      * 类名称：HumanResourceLogic
      * 类功能描述：人力资源逻辑静态类
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
    /// 人力资源逻辑静态类
    /// </summary>
    public class HumanResourceLogic
    {

        #region 扣税标准
        private const string strTax = @"
<configuration>
  
  <taxLevel>
    <from>-1000000000000000000000000000</from>
    <to>500</to>
    <taxRate>5</taxRate>
    <deduction>0</deduction>
  </taxLevel>

  <taxLevel>
    <from>500</from>
    <to>2000</to>
    <taxRate>10</taxRate>
    <deduction>25</deduction>
  </taxLevel>

  <taxLevel>
    <from>2000</from>
    <to>5000</to>
    <taxRate>15</taxRate>
    <deduction>125</deduction>
  </taxLevel>

  <taxLevel>
    <from>5000</from>
    <to>20000</to>
    <taxRate>20</taxRate>
    <deduction>375</deduction>
  </taxLevel>

  <taxLevel>
    <from>20000</from>
    <to>40000</to>
    <taxRate>25</taxRate>
    <deduction>1375</deduction>
  </taxLevel>

  <taxLevel>
    <from>40000</from>
    <to>60000</to>
    <taxRate>30</taxRate>
    <deduction>3375</deduction>
  </taxLevel>

  <taxLevel>
    <from>60000</from>
    <to>80000</to>
    <taxRate>35</taxRate>
    <deduction>6375</deduction>
  </taxLevel>

  <taxLevel>
    <from>80000</from>
    <to>100000</to>
    <taxRate>40</taxRate>
    <deduction>10375</deduction>
  </taxLevel>

  <taxLevel>
    <from>100000</from>
    <to>1000000000000000000000000000</to>
    <taxRate>45</taxRate>
    <deduction>15375</deduction>
  </taxLevel>
  
</configuration>
";
        #endregion

        /// <summary>
        /// 扣税标准xml表达式
        /// </summary>
        private static XDocument xmlTax = XDocument.Parse(strTax);
        /// <summary>
        /// 扣税基数
        /// </summary>
        private static decimal mTaxBase = 0m;

        static HumanResourceLogic()
        {
            mTaxBase = HumanResourceDB.QueryTaxBase();
        }

        /*
        * 方法名称：GetAllPersonnel
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
        public static PersonnelInfo[] GetAllPersonnel()
        {
            return HumanResourceDB.QueryAllPersonnel();
        }

        /*
        * 方法名称：GetAnnuities
        * 方法功能描述：获取养老金数额
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
        /// 获取养老金数额
        /// </summary>
        /// <param name="mBase">基本工资</param>
        /// <returns>应交养老金数额</returns>
        public static decimal GetAnnuities(decimal mBase)
        {
            return mBase * 0.6m * 0.08m;//工资基数*60% 代收8%
        }

        /*
        * 方法名称：GetMedicare
        * 方法功能描述：获取医疗保险金数额
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
        /// 获取医疗保险金数额
        /// </summary>
        /// <param name="mBase">基本工资</param>
        /// <returns></returns>
        public static decimal GetMedicare(decimal mBase)
        {
            return mBase * 0.6m * 0.02m;
        }

        /*
        * 方法名称：GetHousingFund
        * 方法功能描述：获取住房公积金
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
        /// 获取住房公积金
        /// </summary>
        /// <param name="mBase">基本工资</param>
        /// <returns></returns>
        public static decimal GetHousingFund(decimal mBase)
        {
            return mBase * 0.6m * 0.08m;
        }

        /*
        * 方法名称：GetBigMedicare
        * 方法功能描述：获取医保大额
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
        /// 获取医保大额
        /// </summary>
        /// <returns></returns>
        public static decimal GetBigMedicare()
        {
            return 48m;
        }

        /*
        * 方法名称：GetUnemployment
        * 方法功能描述：获取失业保险
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
        /// 获取失业保险
        /// </summary>
        /// <param name="mBase">基本工资</param>
        /// <returns></returns>
        public static decimal GetUnemployment(decimal mBase)
        {
            return mBase * 0.6m * 0.01m;
        }

        /*
        * 方法名称：GetPersonnelIncomeTax
        * 方法功能描述：获取扣税额
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
        /// 获取扣税额
        /// </summary>
        /// <param name="mValue">税前额</param>
        /// <returns></returns>
        public static decimal GetPersonnelIncomeTax(decimal mValue)
        {
            var result = mValue - mTaxBase;
            var vPoint = (from XElement ele in xmlTax.Root.Elements("taxLevel")
                         where result > decimal.Parse(ele.Element("from").Value)
                         && result <= decimal.Parse(ele.Element("to").Value)
                         select new
                         {
                             taxRate = decimal.Parse(ele.Element("taxRate").Value),
                             deduction = decimal.Parse(ele.Element("deduction").Value)
                         }).FirstOrDefault();

            result = result * (vPoint.taxRate/100m) - vPoint.deduction;
            return result < 0 ? 0 : result;
        }

        /// <summary>
        /// 获取指定人员标识的基本工资
        /// </summary>
        /// <param name="iHumanID"></param>
        /// <returns></returns>
        public static decimal? GetBaseByHumanID(int iHumanID)
        {
            return HumanResourceDB.QueryBase(iHumanID);
        }

    }

    /*
      * 类名称：PayrollLogic
      * 类功能描述：工资项业务逻辑类
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
    /// 工资项业务逻辑类
    /// </summary>
    public class PayrollLogic
    {
        /*
        * 方法名称：AddPayroll
        * 方法功能描述：增加工资项
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
        /// 增加工资项
        /// </summary>
        /// <param name="args">工资项实体</param>
        /// <returns>错误描述</returns>
        public string AddPayroll(PayrollAdd args)
        {
            string strResult = null;
            try
            {
                strResult = new PayrollDB().InsertPayroll(args);                
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                strResult = e.Message;
            }
            return strResult;
        }

        /*
        * 方法名称：RemovePayroll
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
        /// <param name="id">标识数组</param>
        /// <returns>错误描述</returns>
        public string RemovePayroll(long[] id)
        {
            string strResult = null;
            try
            {
                strResult = new PayrollDB().DeletePayroll(id);               
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                strResult = "指定的工资项可能正在使用中，不能删除！";
            }
            return strResult;
        }

        /*
        * 方法名称：GetAllPayroll
        * 方法功能描述：查询所有员工指定年月的工资
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
        /// 获取全部工资项
        /// </summary>
        /// <returns>数据集</returns>
        public System.Data.DataSet GetAllPayroll()
        {
            System.Data.DataSet dtsResult = null;
            try
            {
               dtsResult = new PayrollDB().QueryPayroll();                
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return dtsResult;
        }
    }

    /*
      * 类名称：工姿发放逻辑类
      * 类功能描述：
      *
      * 创建人：杨林
      * 创建时间：2008-03-12
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
    */
    /// <summary>
    /// 工姿发放逻辑类
    /// </summary>
    public class PayOffLogic
    {
        /*
        * 方法名称：GetPayrollItemName
        * 方法功能描述：获取工资项名称数组
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
        /// 获取工资项名称数组
        /// </summary>
        /// <returns></returns>
        public string[] GetPayrollItemName()
        {
            return new PayOffDB().QueryPayrollItemName();
        }

        /*
        * 方法名称：GetPayRollItems
        * 方法功能描述：获取工资项实体数组
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
        /// 获取工资项实体数组
        /// </summary>
        /// <returns></returns>
        public PayRollItem[] GetPayRollItems()
        {
            return new PayOffDB().QueryPayRollItems();
        }

        /*
        * 方法名称：AddPayOff
        * 方法功能描述：发放工资
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
        /// 发放工资
        /// </summary>
        /// <param name="args">工资数据集</param>
        /// <param name="strMsg">返回的错误信息</param>
        /// <returns>结果为真代表成功,否则失败,错误信息在strMsg中</returns>
        public void AddPayOff(PayOffDTS args)
        {
            try
            {
                new PayOffDB().InsertPayOff(args);                
            }
            catch (System.Exception e)
            {
                new DasherStation.common.Logging().LogWrite(new DasherStation.common.LogEntry() { ID=0, LogEx=e, LogMessage=e.Message+":"+e.StackTrace });
                throw;
            }
        }

        /*
        * 方法名称：GetPay
        * 方法功能描述：查询所有员工指定年月的工资
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
        /// 查询所有员工指定年月的工资
        /// </summary>
        /// <param name="iYear">年</param>
        /// <param name="iMonth">月</param>
        /// <returns>数据集</returns>
        public System.Data.DataSet GetPay(int iYear, int iMonth, string strPayoffName)
        {
            try
            {
                System.Data.DataSet dtsResult = new PayOffDB().QueryPay(iYear, iMonth, strPayoffName);
                DataSet dtsDataSource = new DataSet();
                dtsDataSource.Tables.Add(new DataTable());
                PayRollItem[] oPayRollItems = new PayOffLogic().GetPayRollItems();
                //生成全部工资项列
                dtsDataSource.Tables[0].Columns.Add("员工姓名");                
                foreach (PayRollItem item in oPayRollItems)
                {
                    dtsDataSource.Tables[0].Columns.Add(new DataColumn(item.Name));
                }
                dtsDataSource.Tables[0].Columns.Add("实际所得");

                var result = (from DataRow row in dtsResult.Tables[0].Rows
                              group row by row["cHumanName"] into Humans // 获取全部人员工资列表,按照人员名称进行分组,因为结果集中单个人员对应多个工资项;
                              // 将分组结果连接结果集中的所有行数据,条件为人员名称相同的记录,结果存储在变量RollItems中.
                              join DataRow row in dtsResult.Tables[0].Rows on Humans.Key.ToString() equals row["cHumanName"].ToString() into RollItems
                              // 映射投影,建立一个匿名对象,三个属性分别为[人员名称],[该人员的工资项集合{工资项名称,工资项值}],[实际所得].
                              select new
                              {
                                  HumanName = Humans.Key,
                                  // 工资项匿名对象集合,用来表示每个员工的工资项.
                                  // 联合前面分组后的结果集与数据列.获取全部工资项.但从原始结果集中去掉了[人员名称]原始数据列.
                                  Rows = from DataRow row in RollItems
                                         from System.Data.DataColumn col in dtsResult.Tables[0].Columns
                                         where col.ColumnName != "cHumanName" && col.ColumnName != "realInCome"
                                         select new
                                         {
                                             ColName = row["cPayRollName"],  // 列名称
                                             ColValue = row["realInCome"]    // 列值
                                         },
                                  RealyInCome = (from DataRow row in RollItems
                                                 from System.Data.DataColumn col in dtsResult.Tables[0].Columns
                                                 where col.ColumnName == "realInCome" && row["cPayRollName"].ToString() == "实际所得"
                                                 select row[col]).First() //该员工实际所得,去掉重项.
                              });

                int iCount = 0;
                //循环人员工资
                foreach (var item in result)
                {
                    //设置数据源DataSet列数
                    dtsDataSource.Tables[0].Rows.Add(new string[dtsResult.Tables[0].Columns.Count]);
                    //设置员工姓名
                    dtsDataSource.Tables[0].Rows[iCount]["员工姓名"] = item.HumanName;
                    //循环配置人员的列与数据源的列,将值付给数据源Dataset
                    foreach (DataColumn column in dtsDataSource.Tables[0].Columns)
                    {
                        var rollItem = item.Rows.Where(p => p.ColName.ToString() == column.ColumnName).FirstOrDefault();
                        //如果人员的列与数据源的列匹配
                        if(rollItem != null)
                        {
                            dtsDataSource.Tables[0].Rows[iCount][column.ColumnName] = rollItem.ColValue;
                        }
                    }
                    iCount++;                    
                }
                return dtsDataSource;

                #region 原数据结构
                //黎明	    基本工资	    2777.00	3226.7798
                //黎明	    项目奖金	    1000.00	3226.7798
                //黎明	    养老保险	    181.296	3226.7798
                //黎明	    医疗保险	    45.324	3226.7798
                //黎明	    失业保险	    22.662	3226.7798
                //黎明	    医疗大额保险	0.00	3226.7798
                //黎明	    住房公积金	181.296	3226.7798
                //黎明	    扣税	        109.64	3226.7798
                //黎明	    考勤	        10.00	3226.7798
                //夏阳明	    基本工资	    2700.00	2446.76
                //夏阳明	    项目奖金	    100.00	2446.76
                //夏阳明	    养老保险	    134.40	2446.76
                //夏阳明	    医疗保险	    33.60	2446.76
                //夏阳明	    失业保险	    16.80	2446.76
                //夏阳明	    医疗大额保险	0.00	2446.76
                //夏阳明	    住房公积金	134.40	2446.76
                //夏阳明	    扣税	        24.04	2446.76
                //夏阳明	    考勤	        10.00	2446.76

                // 循环每人员工资行,item变量代表每个员工的工资记录行.
                // 匿名对象结构图
                //{
                //    HumanNmae = "",
                //    Rows = {
                //            ColName = "", //值类似为"cPayRollName"或者"mPayRollValue"
                //            ColValue=""   //值类似为"养老保险"或者"189.00"
                //            },
                //    RealyInCome = ""
                //}
                

                //var result = (from DataRow row in dtsResult.Tables[0].Rows
                //              group row by row["cHumanName"] into Humans // 获取全部人员工资列表,按照人员名称进行分组,因为结果集中单个人员对应多个工资项;
                //              // 将分组集果连接结果集中的所有行数据,条件为人员名称相同的记录,结果存储在变量ABC中.
                //              join DataRow row in dtsResult.Tables[0].Rows on Humans.Key.ToString() equals row["cHumanName"].ToString() into ABC
                //              // 映射投影,建立一个匿名对象,三个属性分别为[人员名称],[该人员的工资项集合{工资项名称,工资项值}],[实际所得].
                //              select new
                //              {
                //                  HumanName = Humans.Key,
                //                  // 工资项匿名对象集合,用来表示每个员工的工资项.
                //                  // 联合前面分组后的结果集与数据列.获取全部工资项.但从原始结果集中去掉了[人员名称]与[实际所得]原始数据列.
                //                  Rows = from DataRow row in ABC
                //                         from System.Data.DataColumn col in dtsResult.Tables[0].Columns
                //                         where col.ColumnName != "cHumanName" && col.ColumnName != "realInCome"
                //                         select new
                //                         {
                //                             ColName = col.ColumnName,  // 列名称
                //                             ColValue = row[col]        // 列值
                //                         },
                //                  RealyInCome = (from DataRow row in ABC
                //                                 from System.Data.DataColumn col in dtsResult.Tables[0].Columns
                //                                 where col.ColumnName == "realInCome"
                //                                 select row[col]).First() //该员工实际所得,去掉重项.
                //              });//.Distinct();//仅返回结果集中的非重复人员.
                
                //dtsDataSource.Tables[0].Columns.Add("员工姓名");
                //dtsDataSource.Tables[0].Columns.Add("实际所得");
                //foreach (var item in result)
                //{
                //    // 如果数据源表没有列,则产生列名.
                //    //if (dtsDataSource.Tables[0].Columns.Count == 0)
                //    //{
                        
                //        var oColumns = item.Rows.Where(Lambda => Lambda.ColName == "cPayRollName");
                //        var temp = (from DataColumn t in dtsDataSource.Tables[0].Columns
                //                    select t).ToList();
                //        foreach (var col in oColumns)
                //        {                                      
                //            if(temp.Where(p=>p.ColumnName == col.ColValue.ToString()).Count() ==0)
                //            {
                //                dtsDataSource.Tables[0].Columns.Add(new DataColumn(col.ColValue.ToString()));
                //            }
                //        }
                        
                //    //}
                //    // 确定列数,好添充列值
                //    string[] strValues = new string[dtsDataSource.Tables[0].Columns.Count];
                //    strValues[0] = item.HumanName.ToString();
                //    strValues[1] = item.RealyInCome.ToString();
                //    // 从该员工的工资项集中获取工资项的金额对象数组
                //    var colValues = item.Rows.Where(lambda => lambda.ColName == "mPayRollValue").ToList();
                //    // 将工资项金额添充到数组中
                //    for (int i = 2, j = 0; i < strValues.Length; i++, j++)
                //    {
                //        strValues[i] = colValues[j].ColValue.ToString();
                //    }                    
                    
                //    dtsDataSource.Tables[0].Rows.Add(strValues);                    
                //}
                //return dtsDataSource;
                #endregion
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return null;
            }
        }

        /// <summary>
        /// 查询指定年月,工资发放名称的全部员工工资(包括未审批的)
        /// </summary>
        /// <param name="iYear">年</param>
        /// <param name="iMonth">月</param>
        /// <param name="strPayoffName">工资发放名称</param>
        /// <returns></returns>
        public System.Data.DataSet GetPayAudit(int iYear, int iMonth, string strPayoffName)
        {
            try
            {
                System.Data.DataSet dtsResult = new PayOffDB().QueryPayAudit(iYear, iMonth, strPayoffName);
                DataSet dtsDataSource = new DataSet();
                dtsDataSource.Tables.Add(new DataTable());
                PayRollItem[] oPayRollItems = new PayOffLogic().GetPayRollItems();
                //生成全部工资项列
                dtsDataSource.Tables[0].Columns.Add("员工姓名");
                foreach (PayRollItem item in oPayRollItems)
                {
                    dtsDataSource.Tables[0].Columns.Add(new DataColumn(item.Name));
                }
                dtsDataSource.Tables[0].Columns.Add("实际所得");
                dtsDataSource.Tables[0].Columns.Add("id");
                dtsDataSource.Tables[0].Columns.Add("审核状态");
                dtsDataSource.Tables[0].Columns.Add("审批状态");


                var result = (from DataRow row in dtsResult.Tables[0].Rows
                              group row by row["cHumanName"] into Humans 
                              join DataRow row in dtsResult.Tables[0].Rows on Humans.Key.ToString() equals row["cHumanName"].ToString() into RollItems                              
                              select new
                              {
                                  ID = Humans.First()["id"],
                                  HumanName = Humans.Key,                                  
                                  Rows = from DataRow row in RollItems
                                         from System.Data.DataColumn col in dtsResult.Tables[0].Columns
                                         where col.ColumnName != "cHumanName" && col.ColumnName != "realInCome"
                                         select new
                                         {
                                             ColName = row["cPayRollName"],  // 列名称
                                             ColValue = row["realInCome"]    // 列值
                                         },
                                  RealyInCome = (from DataRow row in RollItems
                                                 from System.Data.DataColumn col in dtsResult.Tables[0].Columns
                                                 where col.ColumnName == "realInCome" && row["cPayRollName"].ToString() == "实际所得"
                                                 select row[col]).First()
                                 ,AssessState = Humans.First()["AssessState"]
                                 ,
                                  checkupState = Humans.First()["checkupState"]
                              });

                int iCount = 0;
                
                foreach (var item in result)
                {                    
                    dtsDataSource.Tables[0].Rows.Add(new string[dtsResult.Tables[0].Columns.Count]);                    
                    dtsDataSource.Tables[0].Rows[iCount]["员工姓名"] = item.HumanName;                    
                    foreach (DataColumn column in dtsDataSource.Tables[0].Columns)
                    {
                        var rollItem = item.Rows.Where(p => p.ColName.ToString() == column.ColumnName).FirstOrDefault();                        
                        if (rollItem != null)
                        {
                            dtsDataSource.Tables[0].Rows[iCount][column.ColumnName] = rollItem.ColValue;
                        }
                    }
                    dtsDataSource.Tables[0].Rows[iCount]["id"] = item.ID;
                    dtsDataSource.Tables[0].Rows[iCount]["审核状态"] = item.AssessState;
                    dtsDataSource.Tables[0].Rows[iCount]["审批状态"] = item.checkupState;
                    iCount++;
                }
                return dtsDataSource;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return null;
            }
        }

        /// <summary>
        /// 审核工资
        /// </summary>
        /// <param name="gatherID"></param>
        public void Assess(long gatherID, bool bPass, string strHumanName)
        {
            new PayOffDB().Assess(gatherID, bPass, strHumanName);
        }

        /// <summary>
        /// 审批工资
        /// </summary>
        /// <param name="gatherID"></param>
        /// <param name="bPass"></param>
        /// <param name="strHumanName"></param>
        /// <returns>真为审批通过,假为未审核不能审批</returns>
        public bool Checkup(long gatherID, bool bPass, string strHumanName)
        {

            var oData = new PayOffDB();
            if(oData.IsAssess(gatherID) == false)
            {
                return false;
            }
            oData.Checkup(gatherID, bPass, strHumanName);
            return true;
        }

        /// <summary>
        /// 获取全部工资发放名称
        /// </summary>
        /// <returns></returns>
        public string[] GetPayoffName()
        {
            return new PayOffDB().QueryPayoffName();
        }

        /// <summary>
        /// 判断指定工资发放名称是否存在
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public bool IsExistPayName(string strName)
        {
            return new PayOffDB().IsExistPayName(strName);
        }
    }


    /// <summary>
    /// 员工逻辑类
    /// </summary>
    public class EmployeeLogic
    {
        private EmployeeDB oData = new EmployeeDB();

        /// <summary>
        /// 增加员工
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string Add(PersonnelInfo entity)
        {
            if (oData.IsExistByNo(entity.no))
            {
                return "职工编号己经存在!";
            }
            if (oData.IsExistByName(entity.name))
            {
                return "职工名称己经存在!";
            }
            oData.Insert(entity);
            return null;
        }

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="entity"></param>
        public void Update(PersonnelInfo entity)
        {
            this.oData.Update(entity);
        }

        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int[] id)
        {
            oData.Delete(id);
        }

        /// <summary>
        /// 删除生产班组
        /// </summary>
        /// <param name="id"></param>
        public void RemoveYieldGroup(int[] id)
        {
            oData.DeleteYieldGroup(id);
        }

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="id"></param>
        public void RemovePosition(int[] id)
        {
            oData.DeletePosition(id);
        }

        /// <summary>
        /// 获取全部员工实体列表
        /// </summary>
        /// <returns></returns>
        public List<PersonnelInfo> GetEmployees()
        {
            return oData.QueryEmployees();
        }

        public PersonnelInfo GetEmployeeByID(long id)
        {
            return oData.QueryEmployeeByID(id);
        }

        /// <summary>
        /// 获取全部员工数据集
        /// </summary>
        /// <returns></returns>
        public DataSet GetTSForEmployees()
        {
            return oData.QueryDTSForEmployees();
        }

        /// <summary>
        /// 插入职位信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string AddPosition(Position entity)
        {
            if(oData.IsExistPosition(entity.name))
            {
                return "该职位名称已经存在!";
            }
            oData.InsertPosition(entity);
            return "";
        }

        /// <summary>
        /// 获取全部职位信息
        /// </summary>
        /// <returns></returns>
        public List<Position> GetPositions()
        {
            return oData.QueryPositions();
        }

        /// <summary>
        /// 新增生产班组
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string AddYieldGroup(ProduceTeam entity)
        {
            if(oData.IsExistYieldGroup(entity.name, entity.did.Value))
            {
                return "该生产班组已经存在!";
            }
            oData.InsertYieldGroup(entity);
            return "";
        }

        /// <summary>
        /// 获取全部生产班组信息
        /// </summary>
        /// <returns></returns>
        public List<ProduceTeam> GetYieldGroups()
        {
            return oData.QueryYieldGroups();
        }

        /// <summary>
        /// 查询指定部门的生产班组
        /// </summary>
        /// <param name="id">部门标识</param>
        /// <returns></returns>
        public List<ProduceTeam> GetYieldGroupByDepID(long id)
        {
            return oData.QueryYieldGroupByDepID(id);
        }

        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetEPInfo()
        {
            return this.oData.QueryEPInfo();
        }
    }


    /// <summary>
    /// 工资项模板逻辑类
    /// </summary>
    public class PayRollTemplateLogic
    {
        /// <summary>
        /// 插入模板
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string AddTemplate(SalaryItemTemplet entity)
        {
            PayRollTempalteDB oTemplateDB = new PayRollTempalteDB();
            if (oTemplateDB.IsExist(entity.name))
            {
                return "指定名称己经存在,请换个名称!";
            }
            try
            {
                oTemplateDB.Insert(entity);
                return null;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return "写数据库出错,请再试一次!";
            }
        }

        /// <summary>
        /// 查询指定模板名称的模板
        /// </summary>
        /// <param name="strName">模板名称</param>
        /// <returns></returns>
        public SalaryItemTemplet GetTemplateByName(string strName)
        {
            return new PayRollTempalteDB().Query(strName);
        }

        /// <summary>
        /// 获取全部模板名称列表
        /// </summary>
        /// <returns></returns>
        public string[] GetAllTemplateName()
        {
            return new PayRollTempalteDB().QueryAllTemplateName();
        }
    }

    /// <summary>
    /// 部门业务类
    /// </summary>
    public class DepartmentLogic
    {
        private DepartmentDB oData = new DepartmentDB();

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string Add(Department entity)
        {
            if (oData.IsExistByName(entity.name))
            {
                return "部门名称己经存在!";
            }
            if (oData.IsExistByNo(entity.no))
            {
                return "部门编码己经存在!";
            }
            oData.Insert(entity);
            return null;
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int[] id)
        {
            oData.Delete(id);
        }

        /// <summary>
        /// 查询部门
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartMents()
        {
            return oData.QueryDepartMents();
        }
    }
}
