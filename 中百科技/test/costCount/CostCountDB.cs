using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DasherStation.common;
using DasherStation.system;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DasherStation.storage;

namespace DasherStation.costCount
{
    /*
     * 类名称：CostCountDB
     * 类功能描述：成本核算数据层基类
     *
     * 创建人：袁宇
     * 创建时间：2009-03-18
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class CostCountDB
    {
        //公共数据层实例
        SqlHelper sqlHelperObj = new SqlHelper();
        ////多表查询类，左连接
        //LinkSelect linkS = new LinkSelect();
        /*
         * 方法名称：UpdateTeble
         * 方法功能描述：更新字段与值对比字符串生成；  
         * 参数: list1 字段列表 
         *       List2 值列表
         *       Eval 操作符 
         *       compart  间隔符
         * 创建人：袁宇
         * 创建时间：2009-03-18
         * *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private string EvaluateString(ArrayList List1, ArrayList List2, string Eval, string Compart)
        {
            StringBuilder Ret = new StringBuilder("");
            int I, Count;

            if (List1.Count == List2.Count)
            {
                Count = List1.Count - 1;
                for (I = 0; I <= Count; I++)
                {
                    Ret.Append(List1[I].ToString() + ' ' + Eval + ' ' + List2[I].ToString());
                    if (I < Count)
                    {
                        Ret.Append(Compart);
                    }
                }
            }
            return Ret.ToString();
        }
        /*
         * 方法名称：CombinationString
         * 方法功能描述：由字符串列表提供的内容组合成为字符串，参数Compart为分隔符；  
         * 参数:  list 要生成字符串的列表
         *        compart 间隔符
         *        
         *       
         * 创建人：袁宇
         * 创建时间：2009-03-18
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         * *
         */
        private string CombinationString(ArrayList List, string Compart)
        {
            StringBuilder Ret = new StringBuilder("");
            int Count, I;
            Count = List.Count;
            for (I = 0; I < Count; I++)
            {
                Ret.Append(List[I].ToString());
                if (I < Count - 1)
                {
                    Ret.Append(Compart);
                }
            }
            return Ret.ToString();
        }
        /*
         * 方法名称：UpdateTeble
         * 方法功能描述：更新表,拼接sql语句   
         * 参数: TabName 表名 
         *       FieldList 字段名列表
         *       ValueList 值列表
         *       Cond      条件列表
         * 创建人：袁宇
         * 创建时间：2009-03-18
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public string UpdateTeble(string TabName, ArrayList FieldList, ArrayList ValueList, ArrayList Cond)
        {
            string Conds = "", Eval = "";
            StringBuilder SqlText = new StringBuilder("");

            if ((!TabName.Trim().Equals("")) && (FieldList.Count.Equals(ValueList.Count)) && (FieldList.Count > 0) && (ValueList.Count > 0))
            {
                Eval = EvaluateString(FieldList, ValueList, "=", ",");
                SqlText.Append("Update " + TabName + " Set " + Eval);
                Conds = CombinationString(Cond, " ");
                if (Conds.Trim() != "")
                {
                    SqlText.Append(" Where " + Conds);
                }
            }
            return SqlText.ToString();
        }
        /*
         * 方法名称：InsertTable
         * 方法功能描述：拼接insert语句  
         * 参数: TabName 表名 
         *       FieldList 字段名列表
         *       ValueList 值列表
         *       
         * 创建人：袁宇
         * 创建时间：2009-03-18
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public string InsertTable(string TabName, ArrayList FieldList, ArrayList ValueList)
        {
            string Fields, Values;
            string SqlText = "";

            if ((TabName.Trim() != "") && (FieldList.Count > 0) && (ValueList.Count > 0) && (FieldList.Count == ValueList.Count))
            {
                Fields = CombinationString(FieldList, ",");
                Values = CombinationString(ValueList, ",");
                SqlText = SqlText + "insert into " + TabName + "(" + Fields + ") values (" + Values + ")";
            }

            return SqlText;

        }      
        /*
        * 方法名称：SelectExpenditureName
        * 方法功能描述：查询表expenditureName
        * 参数:string parentId 说明:表parentId查询值,值为NULL时,查询表中parentId为NULL的记录,值为""时无条件筛选 
        *       
        * 创建人：付中华
        * 创建时间：2009-03-23
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectExpenditureName(string parentId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            if (parentId == "")
            {
                sqlStr.Append("select id,name,parentId,level,inputDate,inputMan  from expenditureName where parentId is null");
            }
            else
            {
                sqlStr.Append("select id,name,parentId,level,inputDate,inputMan  from expenditureName where parentId=" + parentId);
            }
            list.Add(sqlStr.ToString());

            return sqlHelperObj.QueryForDateSet(list).Tables[0];
        }

        /*
      * 方法名称：
      * 方法功能描述：查出费用科目表中的所有内容
      * 参数: 
      *       
      * 创建人：付中华
      * 创建时间：2009-03-24
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataTable expenditureNameTableDB()
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select * from expenditureName");
            list.Add(sqlStr.ToString());

            return sqlHelperObj.QueryForDateSet(list).Tables[0];
        }


        /*
       * 方法名称：InsertExpenditureName
       * 方法功能描述：向表expenditureName中插入一条记录
       * 参数: 
       *       
       * 创建人：付中华
       * 创建时间：2009-03-23
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public string InsertExpenditureName(expenditureNameClass info)
        {
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();

            if (!info.name.Trim().Equals(""))
            {
                fields.Add("name");
                values.Add("'" + info.name.Trim() + "'");
            }
            if (!info.parentId.Trim().Equals(""))
            {
                fields.Add("parentId");
                values.Add("'" + info.parentId.Trim() + "'");
            }
            if (!info.level.Trim().Equals(""))
            {
                fields.Add("level");
                values.Add("'" + info.level.Trim() + "'");
            }
            if ((info.inputDate != null) && (!info.inputDate.Trim().Equals("")))
            {
                fields.Add("inputDate");
                values.Add("'" + info.inputDate.Trim() + "'");
            }
            if ((info.inputMan != null) && (!info.inputMan.Trim().Equals("")))
            {
                fields.Add("inputMan");
                values.Add("'" + info.inputMan.Trim() + "'");
            }
            if ((info.remark != null) && (!info.remark.Trim().Equals("")))
            {
                fields.Add("remark");
                values.Add("'" + info.remark.Trim() + "'");
            }
            return this.InsertTable("expenditureName", fields, values);
        }

        /*
     * 方法名称：selectMaxInsertId
     * 方法功能描述：取出刚插入数据表中的最大id值赋值给刚添加的结点的Id
     * 参数: 
     *       
     * 创建人：付中华
     * 创建时间：2009-03-24
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataTable selectMaxInsertId()
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" select max(id) from expenditureName");
            list.Add(sqlStr.ToString());

            return sqlHelperObj.QueryForDateSet(list).Tables[0];

        }



        /*
      * 方法名称：UpdateExpenditureName
      * 方法功能描述：向表expenditureName中更新一条记录的sql语句
      * 参数: 
      *       
      * 创建人：付中华
      * 创建时间：2009-03-23
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string UpdateExpenditureName(expenditureNameClass info)
        {
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            ArrayList cond = new ArrayList();

            if (!info.name.Trim().Equals(""))
            {
                fields.Add("name");
                values.Add("'" + info.name.Trim() + "'");
            }
            if (!info.parentId.Trim().Equals(""))
            {
                fields.Add("parentId");
                values.Add("'" + info.parentId.Trim() + "'");
            }
            if (!info.level.Trim().Equals(""))
            {
                fields.Add("level");
                values.Add("'" + info.level.Trim() + "'");
            }
            if (!info.inputDate.Trim().Equals(""))
            {
                fields.Add("inputDate");
                values.Add("'" + info.inputDate.Trim() + "'");
            }
            if ((info.inputMan!=null)&&(!info.inputMan.Trim().Equals("")))
            {
                fields.Add("inputMan");
                values.Add("'" + info.inputMan.Trim() + "'");
            }
            if ((info.remark != null) && (!info.remark.Trim().Equals("")))
            {
                fields.Add("remark");
                values.Add("'" + info.remark.Trim() + "'");
            }
            cond.Add("id=" + info.id);
            return this.UpdateTeble("expenditureName", fields, values, cond);

        }
        /*
     * 方法名称：deleteExpenditureName
     * 方法功能描述：从表deleteExpenditureName中删除一条语句
     * 参数: 
     *       
     * 创建人：付中华
     * 创建时间：2009-03-24
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool deleteExpenditureName(string mainId)
        {
            bool deleteStatus;
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("delete from expenditureName where id=" + mainId);
            list.Add(sqlStr.ToString());

            deleteStatus = sqlHelperObj.Delete(list);

            return deleteStatus;
        }
        /*
        * 方法名称：ArrayList sqlStr  插入与更新操作的sql语句集合
        * 方法功能描述：批量插入或更新表expenditureName
        * 参数: 
        *       
        * 创建人：付中华
        * 创建时间：2009-03-23
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Transact(ArrayList sqlStr)
        {
            if (sqlHelperObj.ExecuteTransaction(sqlStr))
                return true;
            else
                return false;
        }
        /*
      * 方法名称：SelectExpenditureNameLevel
      * 方法功能描述：查询表expenditureName中,Level=参数的所有记录
      * 参数: 
      *       
      * 创建人：付中华
      * 创建时间：2009-03-25
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataTable SelectExpenditureNameLevel(int level)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select id,name,parentId,level,inputDate,inputMan from expenditureName where level=" + level);
            list.Add(sqlStr.ToString());

            return sqlHelperObj.QueryForDateSet(list).Tables[0];
        }
        /*
     * 方法名称：insertExpenditure
     * 方法功能描述：向expenditure表中插入一条记录
     * 参数: 
     *       
     * 创建人：付中华
     * 创建时间：2009-03-25
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public string insertExpenditure(expenditureClass info)
        {
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();

            if ((info.ekId != null) && (!info.ekId.Trim().ToString().Equals("")))
            {
                fields.Add("ekId");
                values.Add("'" + info.ekId.Trim() + "'");
            }
            if ((info.enId != null) && (!info.enId.Trim().ToString().Equals("")))
            {
                fields.Add("enId");
                values.Add("'" + info.enId.Trim() + "'");
            }
            if ((info.ecId != null) && (!info.ecId.Trim().ToString().Equals("")))
            {
                fields.Add("ecId");
                values.Add("'" + info.ecId.Trim() + "'");
            }
            if ((info.expenditureDepict != null) && (!info.expenditureDepict.Trim().ToString().Equals("")))
            {
                fields.Add("expenditureDepict");
                values.Add("'" + info.expenditureDepict.Trim() + "'");
            }
            if ((info.year != null) && (!info.year.Trim().ToString().Equals("")))
            {
                fields.Add("year");
                values.Add("'" + info.year.Trim() + "'");
            }
            if ((info.month != null) && (!info.month.Trim().ToString().Equals("")))
            {
                fields.Add("month");
                values.Add("'" + info.month.Trim() + "'");
            }
            if ((info.eiId != null) && (!info.eiId.Trim().ToString().Equals("")))
            {
                fields.Add("eiId");
                values.Add("'" + info.eiId.Trim() + "'");
            }
            if ((info.pId != null) && (!info.pId.Trim().ToString().Equals("")))
            {
                fields.Add("pId");
                values.Add("'" + info.pId.Trim() + "'");
            }
            if ((info.number != null) && (!info.number.Trim().ToString().Equals("")))
            {
                fields.Add("number");
                values.Add("'" + info.number.Trim() + "'");
            }
            if ((info.unitPrice != null) && (!info.unitPrice.Trim().ToString().Equals("")))
            {
                fields.Add("unitPrice");
                values.Add("'" + info.unitPrice.Trim() + "'");
            }
            if ((info.money != null) && (!info.money.Trim().ToString().Equals("")))
            {
                fields.Add("money");
                values.Add("'" + info.money.Trim() + "'");
            }
            if ((info.inputDate != null) && (!info.inputDate.Trim().ToString().Equals("")))
            {
                fields.Add("inputDate");
                values.Add("'" + info.inputDate.Trim() + "'");
            }
            if ((info.inputMan != null) && (!info.inputMan.Trim().ToString().Equals("")))
            {
                fields.Add("inputMan");
                values.Add("'" + info.inputMan.Trim() + "'");
            }
            if ((info.assessor!=null)&&(!info.assessor.Trim().ToString().Equals("")))
            {
                fields.Add("assessor");
                values.Add("'" + info.assessor.Trim() + "'");
            }
            if ((info.checkupMan != null) && (!info.checkupMan.Trim().ToString().Equals("")))
            {
                fields.Add("checkupMan");
                values.Add("'" + info.checkupMan.Trim() + "'");
            }
            if ((info.convert != null) && (!info.convert.Trim().ToString().Equals("")))
            {
                fields.Add("[convert]");
                values.Add("'" + info.convert.Trim() + "'");
            }
            if ((info.isFromDetach != null) && (!info.isFromDetach.Trim().ToString().Equals("")))
            {
                fields.Add("isFromDetach");
                values.Add("'" + info.isFromDetach.Trim() + "'");
            }
            if ((info.isAuto != null) && (!info.isAuto.Trim().ToString().Equals("")))
            {
                fields.Add("isAuto");
                values.Add("'" + info.isAuto.Trim() + "'");
            }

            if ((info.remark != null) && (!info.remark.Trim().ToString().Equals("")))
            {
                fields.Add("remark");
                values.Add("'" + info.remark.Trim() + "'");
            }
            return this.InsertTable("expenditure", fields, values);
        }
        /*
   * 方法名称：insertExpenditure
   * 方法功能描述：向bitumenExpenditure表中插入一条记录
   * 参数: 
   *       
   * 创建人：付中华
   * 创建时间：2009-03-28
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        public string insertExpenditure(bitumenExpenditureClass info)
        {
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();

            if ((info.ekId != null) && (!info.ekId.Trim().ToString().Equals("")))
            {
                fields.Add("ekId");
                values.Add("'" + info.ekId.Trim() + "'");
            }
            if ((info.enId != null) && (!info.enId.Trim().ToString().Equals("")))
            {
                fields.Add("enId");
                values.Add("'" + info.enId.Trim() + "'");
            }
            if ((info.ecId != null) && (!info.ecId.Trim().ToString().Equals("")))
            {
                fields.Add("ecId");
                values.Add("'" + info.ecId.Trim() + "'");
            }
            if ((info.expenditureDepict != null) && (!info.expenditureDepict.Trim().ToString().Equals("")))
            {
                fields.Add("expenditureDepict");
                values.Add("'" + info.expenditureDepict.Trim() + "'");
            }
            if ((info.year != null) && (!info.year.Trim().ToString().Equals("")))
            {
                fields.Add("year");
                values.Add("'" + info.year.Trim() + "'");
            }
            if ((info.month != null) && (!info.month.Trim().ToString().Equals("")))
            {
                fields.Add("month");
                values.Add("'" + info.month.Trim() + "'");
            }
            if ((info.eiId != null) && (!info.eiId.Trim().ToString().Equals("")))
            {
                fields.Add("eiId");
                values.Add("'" + info.eiId.Trim() + "'");
            }
            if ((info.pId != null) && (!info.pId.Trim().ToString().Equals("")))
            {
                fields.Add("pId");
                values.Add("'" + info.pId.Trim() + "'");
            }
            if ((info.number != null) && (!info.number.Trim().ToString().Equals("")))
            {
                fields.Add("number");
                values.Add("'" + info.number.Trim() + "'");
            }
            if ((info.unitPrice != null) && (!info.unitPrice.Trim().ToString().Equals("")))
            {
                fields.Add("unitPrice");
                values.Add("'" + info.unitPrice.Trim() + "'");
            }
            if ((info.money != null) && (!info.money.Trim().ToString().Equals("")))
            {
                fields.Add("money");
                values.Add("'" + info.money.Trim() + "'");
            }
            if ((info.inputDate != null) && (!info.inputDate.Trim().ToString().Equals("")))
            {
                fields.Add("inputDate");
                values.Add("'" + info.inputDate.Trim() + "'");
            }
            if ((info.inputMan != null) && (!info.inputMan.Trim().ToString().Equals("")))
            {
                fields.Add("inputMan");
                values.Add("'" + info.inputMan.Trim() + "'");
            }
            if ((info.assessor != null) && (!info.assessor.Trim().ToString().Equals("")))
            {
                fields.Add("assessor");
                values.Add("'" + info.assessor.Trim() + "'");
            }
            if ((info.checkupMan != null) && (!info.checkupMan.Trim().ToString().Equals("")))
            {
                fields.Add("checkupMan");
                values.Add("'" + info.checkupMan.Trim() + "'");
            }
            if ((info.convert != null) && (!info.convert.Trim().ToString().Equals("")))
            {
                fields.Add("[convert]");
                values.Add("'" + info.convert.Trim() + "'");
            }
            if ((info.isFromDetach != null) && (!info.isFromDetach.Trim().ToString().Equals("")))
            {
                fields.Add("isFromDetach");
                values.Add("'"+info.isFromDetach.Trim()+"'");
            }
            if ((info.isAuto != null) && (!info.isAuto.Trim().ToString().Equals("")))
            {
                fields.Add("isAuto");
                values.Add("'" + info.isAuto.Trim() + "'");
            }
            if ((info.remark != null) && (!info.remark.Trim().ToString().Equals("")))
            {
                fields.Add("remark");
                values.Add("'" + info.remark.Trim() + "'");
            }
            return this.InsertTable("bitumenExpenditure", fields, values);
        }


        /*
  * 方法名称：insertExpenditure
  * 方法功能描述：向alterBitumenExpenditure表中插入一条记录
  * 参数: 
  *       
  * 创建人：付中华
  * 创建时间：2009-03-28
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */
        public string insertExpenditure(alterBitumenExpenditureClass info)
        {
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();

            if ((info.ekId != null) && (!info.ekId.Trim().ToString().Equals("")))
            {
                fields.Add("ekId");
                values.Add("'" + info.ekId.Trim() + "'");
            }
            if ((info.enId != null) && (!info.enId.Trim().ToString().Equals("")))
            {
                fields.Add("enId");
                values.Add("'" + info.enId.Trim() + "'");
            }
            if ((info.ecId != null) && (!info.ecId.Trim().ToString().Equals("")))
            {
                fields.Add("ecId");
                values.Add("'" + info.ecId.Trim() + "'");
            }
            if ((info.expenditureDepict != null) && (!info.expenditureDepict.Trim().ToString().Equals("")))
            {
                fields.Add("expenditureDepict");
                values.Add("'" + info.expenditureDepict.Trim() + "'");
            }
            if ((info.year != null) && (!info.year.Trim().ToString().Equals("")))
            {
                fields.Add("year");
                values.Add("'" + info.year.Trim() + "'");
            }
            if ((info.month != null) && (!info.month.Trim().ToString().Equals("")))
            {
                fields.Add("month");
                values.Add("'" + info.month.Trim() + "'");
            }
            if ((info.eiId != null) && (!info.eiId.Trim().ToString().Equals("")))
            {
                fields.Add("eiId");
                values.Add("'" + info.eiId.Trim() + "'");
            }
            if ((info.pId != null) && (!info.pId.Trim().ToString().Equals("")))
            {
                fields.Add("pId");
                values.Add("'" + info.pId.Trim() + "'");
            }
            if ((info.number != null) && (!info.number.Trim().ToString().Equals("")))
            {
                fields.Add("number");
                values.Add("'" + info.number.Trim() + "'");
            }
            if ((info.unitPrice != null) && (!info.unitPrice.Trim().ToString().Equals("")))
            {
                fields.Add("unitPrice");
                values.Add("'" + info.unitPrice.Trim() + "'");
            }
            if ((info.money != null) && (!info.money.Trim().ToString().Equals("")))
            {
                fields.Add("money");
                values.Add("'" + info.money.Trim() + "'");
            }
            if ((info.inputDate != null) && (!info.inputDate.Trim().ToString().Equals("")))
            {
                fields.Add("inputDate");
                values.Add("'" + info.inputDate.Trim() + "'");
            }
            if ((info.inputMan != null) && (!info.inputMan.Trim().ToString().Equals("")))
            {
                fields.Add("inputMan");
                values.Add("'" + info.inputMan.Trim() + "'");
            }
            if ((info.assessor != null) && (!info.assessor.Trim().ToString().Equals("")))
            {
                fields.Add("assessor");
                values.Add("'" + info.assessor.Trim() + "'");
            }
            if ((info.checkupMan != null) && (!info.checkupMan.Trim().ToString().Equals("")))
            {
                fields.Add("checkupMan");
                values.Add("'" + info.checkupMan.Trim() + "'");
            }
            if ((info.convert != null) && (!info.convert.Trim().ToString().Equals("")))
            {
                fields.Add("[convert]");
                values.Add("'" + info.convert.Trim() + "'");
            }
            if ((info.isFromDetach != null) && (!info.isFromDetach.Trim().ToString().Equals("")))
            {
                fields.Add("isFromDetach");
                values.Add("'" + info.isFromDetach.Trim() + "'");
            }
            if ((info.isAuto != null) && (!info.isAuto.Trim().ToString().Equals("")))
            {
                fields.Add("isAuto");
                values.Add("'" + info.isAuto.Trim() + "'");
            }
            if ((info.remark != null) && (!info.remark.Trim().ToString().Equals("")))
            {
                fields.Add("remark");
                values.Add("'" + info.remark.Trim() + "'");
            }
            return this.InsertTable("alterBitumenExpenditure", fields, values);
        }
        /*
    * 方法名称：updateExpenditure
    * 方法功能描述：更新expenditure表中一条记录
    * 参数: 
    *       
    * 创建人：付中华
    * 创建时间：2009-03-25
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public string updateExpenditure(expenditureClass info)
        {
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            ArrayList cond = new ArrayList();

            if ((info.ekId != null) && (!info.ekId.Trim().ToString().Equals("")))
            {
                fields.Add("ekId");
                values.Add("'" + info.ekId.Trim() + "'");
            }
            if ((info.enId != null) && (!info.enId.Trim().ToString().Equals("")))
            {
                fields.Add("enId");
                values.Add("'" + info.enId.Trim() + "'");
            }
            if ((info.ecId != null) && (!info.ecId.Trim().ToString().Equals("")))
            {
                fields.Add("ecId");
                values.Add("'" + info.ecId.Trim() + "'");
            }
            if ((info.expenditureDepict != null) && (!info.expenditureDepict.Trim().ToString().Equals("")))
            {
                fields.Add("expenditureDepict");
                values.Add("'" + info.expenditureDepict.Trim() + "'");
            }
            if ((info.year != null) && (!info.year.Trim().ToString().Equals("")))
            {
                fields.Add("year");
                values.Add("'" + info.year.Trim() + "'");
            }
            if ((info.month != null) && (!info.month.Trim().ToString().Equals("")))
            {
                fields.Add("month");
                values.Add("'" + info.month.Trim() + "'");
            }
            if ((info.eiId != null) && (!info.eiId.Trim().ToString().Equals("")))
            {
                fields.Add("eiId");
                values.Add("'" + info.eiId.Trim() + "'");
            }
            if ((info.pId != null) && (!info.pId.Trim().ToString().Equals("")))
            {
                fields.Add("pId");
                values.Add("'" + info.pId.Trim() + "'");
            }
            if ((info.number != null) && (!info.number.Trim().ToString().Equals("")))
            {
                fields.Add("number");
                values.Add("'" + info.number.Trim() + "'");
            }
            if ((info.unitPrice != null) && (!info.unitPrice.Trim().ToString().Equals("")))
            {
                fields.Add("unitPrice");
                values.Add("'" + info.unitPrice.Trim() + "'");
            }
            if ((info.money != null) && (!info.money.Trim().ToString().Equals("")))
            {
                fields.Add("money");
                values.Add("'" + info.money.Trim() + "'");
            }
            if ((info.inputDate != null) && (!info.inputDate.Trim().ToString().Equals("")))
            {
                fields.Add("inputDate");
                values.Add("'" + info.inputDate.Trim() + "'");
            }
            if ((info.inputMan != null) && (!info.inputMan.Trim().ToString().Equals("")))
            {
                fields.Add("inputMan");
                values.Add("'" + info.inputMan.Trim() + "'");
            }
            if ((info.assessor != null) && (!info.assessor.Trim().ToString().Equals("")))
            {
                fields.Add("assessor");
                values.Add("'" + info.assessor.Trim() + "'");
            }
            if ((info.checkupMan != null) && (!info.checkupMan.Trim().ToString().Equals("")))
            {
                fields.Add("checkupMan");
                values.Add("'" + info.checkupMan.Trim() + "'");
            }
            if ((info.convert != null) && (!info.convert.Trim().ToString().Equals("")))
            {
                fields.Add("[convert]");
                values.Add("'" + info.convert.Trim() + "'");
            }
            if ((info.isFromDetach != null) && (!info.isFromDetach.Trim().ToString().Equals("")))
            {
                fields.Add("isFromDetach");
                values.Add("'" + info.isFromDetach.Trim() + "'");
            }
            if ((info.isAuto != null) && (!info.isAuto.Trim().ToString().Equals("")))
            {
                fields.Add("isAuto");
                values.Add("'" + info.isAuto.Trim() + "'");
            }
            if ((info.remark != null) && (!info.remark.Trim().ToString().Equals("")))
            {
                fields.Add("remark");
                values.Add("'" + info.remark.Trim() + "'");
            }
            cond.Add("id=" + info.id);
            return this.UpdateTeble("expenditure", fields, values, cond);

        }
        /*
       * 方法名称：waitDetachExpenditure
       * 方法功能描述：向waitDetachExpenditure表中插入一条记录
       * 参数: 
       *       
       * 创建人：付中华
       * 创建时间：2009-03-25
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public string insertWaitDetachExpenditure(waitDetachExpenditureClass info)
        {
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();

            if ((info.ekId != null) && (!info.ekId.Trim().ToString().Equals("")))
            {
                fields.Add("ekId");
                values.Add("'" + info.ekId.Trim() + "'");
            }
            if ((info.enId != null) && (!info.enId.Trim().ToString().Equals("")))
            {
                fields.Add("enId");
                values.Add("'" + info.enId.Trim() + "'");
            }
            if ((info.ecId != null) && (!info.ecId.Trim().ToString().Equals("")))
            {
                fields.Add("ecId");
                values.Add("'" + info.ecId.Trim() + "'");
            }
            if ((info.expenditureDepict != null) && (!info.expenditureDepict.Trim().ToString().Equals("")))
            {
                fields.Add("expenditureDepict");
                values.Add("'" + info.expenditureDepict.Trim() + "'");
            }
            if ((info.year != null) && (!info.year.Trim().ToString().Equals("")))
            {
                fields.Add("year");
                values.Add("'" + info.year.Trim() + "'");
            }
            if ((info.month != null) && (!info.month.Trim().ToString().Equals("")))
            {
                fields.Add("month");
                values.Add("'" + info.month.Trim() + "'");
            }
            if ((info.eiId != null) && (!info.eiId.Trim().ToString().Equals("")))
            {
                fields.Add("eiId");
                values.Add("'" + info.eiId.Trim() + "'");
            }
            if ((info.pId != null) && (!info.pId.Trim().ToString().Equals("")))
            {
                fields.Add("pId");
                values.Add("'" + info.pId.Trim() + "'");
            }
            if ((info.number != null) && (!info.number.Trim().ToString().Equals("")))
            {
                fields.Add("number");
                values.Add("'" + info.number.Trim() + "'");
            }
            if ((info.unitPrice != null) && (!info.unitPrice.Trim().ToString().Equals("")))
            {
                fields.Add("unitPrice");
                values.Add("'" + info.unitPrice.Trim() + "'");
            }
            if ((info.money != null) && (!info.money.Trim().ToString().Equals("")))
            {
                fields.Add("money");
                values.Add("'" + info.money.Trim() + "'");
            }
            if ((info.inputDate != null) && (!info.inputDate.Trim().ToString().Equals("")))
            {
                fields.Add("inputDate");
                values.Add("'" + info.inputDate.Trim() + "'");
            }
            if ((info.inputMan != null) && (!info.inputMan.Trim().ToString().Equals("")))
            {
                fields.Add("inputMan");
                values.Add("'" + info.inputMan.Trim() + "'");
            }
            if ((info.assessor != null) && (!info.assessor.Trim().ToString().Equals("")))
            {
                fields.Add("assessor");
                values.Add("'" + info.assessor.Trim() + "'");
            }
            if ((info.checkupMan != null) && (!info.checkupMan.Trim().ToString().Equals("")))
            {
                fields.Add("checkupMan");
                values.Add("'" + info.checkupMan.Trim() + "'");
            }
            if ((info.convert != null) && (!info.convert.Trim().ToString().Equals("")))
            {
                fields.Add("[convert]");
                values.Add("'" + info.convert.Trim() + "'");
            }
            if ((info.isDetach != null) && (!info.isDetach.Trim().ToString().Equals("")))
            {
                fields.Add("isDetach");
                values.Add("'" + info.isDetach.Trim() + "'");
            }
            if ((info.isAuto != null) && (!info.isAuto.Trim().ToString().Equals("")))
            {
                fields.Add("isAuto");
                values.Add("'" + info.isAuto.Trim() + "'");
            }
            if ((info.remark != null) && (!info.remark.Trim().ToString().Equals("")))
            {
                fields.Add("remark");
                values.Add("'" + info.remark.Trim() + "'");
            }
            return this.InsertTable("waitDetachExpenditure", fields, values);
        }

        /*
      * 方法名称：waitDetachExpenditure
      * 方法功能描述：向bitumenWaitDetachExpenditure表中插入一条记录
      * 参数: 
      *       
      * 创建人：付中华
      * 创建时间：2009-03-28
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string insertWaitDetachExpenditure(bitumenWaitDetachExpenditureClass info)
        {
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();

            if ((info.ekId != null) && (!info.ekId.Trim().ToString().Equals("")))
            {
                fields.Add("ekId");
                values.Add("'" + info.ekId.Trim() + "'");
            }
            if ((info.enId != null) && (!info.enId.Trim().ToString().Equals("")))
            {
                fields.Add("enId");
                values.Add("'" + info.enId.Trim() + "'");
            }
            if ((info.ecId != null) && (!info.ecId.Trim().ToString().Equals("")))
            {
                fields.Add("ecId");
                values.Add("'" + info.ecId.Trim() + "'");
            }
            if ((info.expenditureDepict != null) && (!info.expenditureDepict.Trim().ToString().Equals("")))
            {
                fields.Add("expenditureDepict");
                values.Add("'" + info.expenditureDepict.Trim() + "'");
            }
            if ((info.year != null) && (!info.year.Trim().ToString().Equals("")))
            {
                fields.Add("year");
                values.Add("'" + info.year.Trim() + "'");
            }
            if ((info.month != null) && (!info.month.Trim().ToString().Equals("")))
            {
                fields.Add("month");
                values.Add("'" + info.month.Trim() + "'");
            }
            if ((info.eiId != null) && (!info.eiId.Trim().ToString().Equals("")))
            {
                fields.Add("eiId");
                values.Add("'" + info.eiId.Trim() + "'");
            }
            if ((info.pId != null) && (!info.pId.Trim().ToString().Equals("")))
            {
                fields.Add("pId");
                values.Add("'" + info.pId.Trim() + "'");
            }
            if ((info.number != null) && (!info.number.Trim().ToString().Equals("")))
            {
                fields.Add("number");
                values.Add("'" + info.number.Trim() + "'");
            }
            if ((info.unitPrice != null) && (!info.unitPrice.Trim().ToString().Equals("")))
            {
                fields.Add("unitPrice");
                values.Add("'" + info.unitPrice.Trim() + "'");
            }
            if ((info.money != null) && (!info.money.Trim().ToString().Equals("")))
            {
                fields.Add("money");
                values.Add("'" + info.money.Trim() + "'");
            }
            if ((info.inputDate != null) && (!info.inputDate.Trim().ToString().Equals("")))
            {
                fields.Add("inputDate");
                values.Add("'" + info.inputDate.Trim() + "'");
            }
            if ((info.inputMan != null) && (!info.inputMan.Trim().ToString().Equals("")))
            {
                fields.Add("inputMan");
                values.Add("'" + info.inputMan.Trim() + "'");
            }
            if ((info.assessor != null) && (!info.assessor.Trim().ToString().Equals("")))
            {
                fields.Add("assessor");
                values.Add("'" + info.assessor.Trim() + "'");
            }
            if ((info.checkupMan != null) && (!info.checkupMan.Trim().ToString().Equals("")))
            {
                fields.Add("checkupMan");
                values.Add("'" + info.checkupMan.Trim() + "'");
            }
            if ((info.convert != null) && (!info.convert.Trim().ToString().Equals("")))
            {
                fields.Add("[convert]");
                values.Add("'" + info.convert.Trim() + "'");
            }
            if ((info.isDetach != null) && (!info.isDetach.Trim().ToString().Equals("")))
            {
                fields.Add("isDetach");
                values.Add("'" + info.isDetach.Trim() + "'");
            }
            if ((info.isAuto != null) && (!info.isAuto.Trim().ToString().Equals("")))
            {
                fields.Add("isAuto");
                values.Add("'" + info.isAuto.Trim() + "'");
            }
            if ((info.remark != null) && (!info.remark.Trim().ToString().Equals("")))
            {
                fields.Add("remark");
                values.Add("'" + info.remark.Trim() + "'");
            }
            return this.InsertTable("bitumenWaitDetachExpenditure", fields, values);
        }
        /*
      * 方法名称：waitDetachExpenditure
      * 方法功能描述：向alterBitumenWaitDetachExpenditure表中插入一条记录
      * 参数: 
      *       
      * 创建人：付中华
      * 创建时间：2009-03-28
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string insertWaitDetachExpenditure(alterBitumenWaitDetachExpenditureClass info)
        {
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();

            if ((info.ekId != null) && (!info.ekId.Trim().ToString().Equals("")))
            {
                fields.Add("ekId");
                values.Add("'" + info.ekId.Trim() + "'");
            }
            if ((info.enId != null) && (!info.enId.Trim().ToString().Equals("")))
            {
                fields.Add("enId");
                values.Add("'" + info.enId.Trim() + "'");
            }
            if ((info.ecId != null) && (!info.ecId.Trim().ToString().Equals("")))
            {
                fields.Add("ecId");
                values.Add("'" + info.ecId.Trim() + "'");
            }
            if ((info.expenditureDepict != null) && (!info.expenditureDepict.Trim().ToString().Equals("")))
            {
                fields.Add("expenditureDepict");
                values.Add("'" + info.expenditureDepict.Trim() + "'");
            }
            if ((info.year != null) && (!info.year.Trim().ToString().Equals("")))
            {
                fields.Add("year");
                values.Add("'" + info.year.Trim() + "'");
            }
            if ((info.month != null) && (!info.month.Trim().ToString().Equals("")))
            {
                fields.Add("month");
                values.Add("'" + info.month.Trim() + "'");
            }
            if ((info.eiId != null) && (!info.eiId.Trim().ToString().Equals("")))
            {
                fields.Add("eiId");
                values.Add("'" + info.eiId.Trim() + "'");
            }
            if ((info.pId != null) && (!info.pId.Trim().ToString().Equals("")))
            {
                fields.Add("pId");
                values.Add("'" + info.pId.Trim() + "'");
            }
            if ((info.number != null) && (!info.number.Trim().ToString().Equals("")))
            {
                fields.Add("number");
                values.Add("'" + info.number.Trim() + "'");
            }
            if ((info.unitPrice != null) && (!info.unitPrice.Trim().ToString().Equals("")))
            {
                fields.Add("unitPrice");
                values.Add("'" + info.unitPrice.Trim() + "'");
            }
            if ((info.money != null) && (!info.money.Trim().ToString().Equals("")))
            {
                fields.Add("money");
                values.Add("'" + info.money.Trim() + "'");
            }
            if ((info.inputDate != null) && (!info.inputDate.Trim().ToString().Equals("")))
            {
                fields.Add("inputDate");
                values.Add("'" + info.inputDate.Trim() + "'");
            }
            if ((info.inputMan != null) && (!info.inputMan.Trim().ToString().Equals("")))
            {
                fields.Add("inputMan");
                values.Add("'" + info.inputMan.Trim() + "'");
            }
            if ((info.assessor != null) && (!info.assessor.Trim().ToString().Equals("")))
            {
                fields.Add("assessor");
                values.Add("'" + info.assessor.Trim() + "'");
            }
            if ((info.checkupMan != null) && (!info.checkupMan.Trim().ToString().Equals("")))
            {
                fields.Add("checkupMan");
                values.Add("'" + info.checkupMan.Trim() + "'");
            }
            if ((info.convert != null) && (!info.convert.Trim().ToString().Equals("")))
            {
                fields.Add("[convert]");
                values.Add("'" + info.convert.Trim() + "'");
            }
            if ((info.isDetach != null) && (!info.isDetach.Trim().ToString().Equals("")))
            {
                fields.Add("isDetach");
                values.Add("'" + info.isDetach.Trim() + "'");
            }
            if ((info.isAuto != null) && (!info.isAuto.Trim().ToString().Equals("")))
            {
                fields.Add("isAuto");
                values.Add("'" + info.isAuto.Trim() + "'");
            }
            if ((info.remark != null) && (!info.remark.Trim().ToString().Equals("")))
            {
                fields.Add("remark");
                values.Add("'" + info.remark.Trim() + "'");
            }
            return this.InsertTable("alterBitumenWaitDetachExpenditure", fields, values);
        }
        /*
          * 方法名称：updateWaitDetachExpenditure
          * 方法功能描述：更新waitDetachExpenditure表中一条记录
          * 参数: 
          *       
          * 创建人：付中华
          * 创建时间：2009-03-25
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        public string updateWaitDetachExpenditure(waitDetachExpenditureClass info)
        {
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            ArrayList cond = new ArrayList();

            if ((info.ekId != null) && (!info.ekId.Trim().ToString().Equals("")))
            {
                fields.Add("ekId");
                values.Add("'" + info.ekId.Trim() + "'");
            }
            if ((info.enId != null) && (!info.enId.Trim().ToString().Equals("")))
            {
                fields.Add("enId");
                values.Add("'" + info.enId.Trim() + "'");
            }
            if ((info.ecId != null) && (!info.ecId.Trim().ToString().Equals("")))
            {
                fields.Add("ecId");
                values.Add("'" + info.ecId.Trim() + "'");
            }
            if ((info.expenditureDepict != null) && (!info.expenditureDepict.Trim().ToString().Equals("")))
            {
                fields.Add("expenditureDepict");
                values.Add("'" + info.expenditureDepict.Trim() + "'");
            }
            if ((info.year != null) && (!info.year.Trim().ToString().Equals("")))
            {
                fields.Add("year");
                values.Add("'" + info.year.Trim() + "'");
            }
            if ((info.month != null) && (!info.month.Trim().ToString().Equals("")))
            {
                fields.Add("month");
                values.Add("'" + info.month.Trim() + "'");
            }
            if ((info.eiId != null) && (!info.eiId.Trim().ToString().Equals("")))
            {
                fields.Add("eiId");
                values.Add("'" + info.eiId.Trim() + "'");
            }
            if ((info.pId != null) && (!info.pId.Trim().ToString().Equals("")))
            {
                fields.Add("pId");
                values.Add("'" + info.pId.Trim() + "'");
            }
            if ((info.number != null) && (!info.number.Trim().ToString().Equals("")))
            {
                fields.Add("number");
                values.Add("'" + info.number.Trim() + "'");
            }
            if ((info.unitPrice != null) && (!info.unitPrice.Trim().ToString().Equals("")))
            {
                fields.Add("unitPrice");
                values.Add("'" + info.unitPrice.Trim() + "'");
            }
            if ((info.money != null) && (!info.money.Trim().ToString().Equals("")))
            {
                fields.Add("money");
                values.Add("'" + info.money.Trim() + "'");
            }
            if ((info.inputDate != null) && (!info.inputDate.Trim().ToString().Equals("")))
            {
                fields.Add("inputDate");
                values.Add("'" + info.inputDate.Trim() + "'");
            }
            if ((info.inputMan != null) && (!info.inputMan.Trim().ToString().Equals("")))
            {
                fields.Add("inputMan");
                values.Add("'" + info.inputMan.Trim() + "'");
            }
            if ((info.assessor != null) && (!info.assessor.Trim().ToString().Equals("")))
            {
                fields.Add("assessor");
                values.Add("'" + info.assessor.Trim() + "'");
            }
            if ((info.checkupMan != null) && (!info.checkupMan.Trim().ToString().Equals("")))
            {
                fields.Add("checkupMan");
                values.Add("'" + info.checkupMan.Trim() + "'");
            }
            if ((info.convert != null) && (!info.convert.Trim().ToString().Equals("")))
            {
                fields.Add("[convert]");
                values.Add("'" + info.convert.Trim() + "'");
            }
            if ((info.isDetach != null) && (!info.isDetach.Trim().ToString().Equals("")))
            {
                fields.Add("isDetach");
                values.Add("'" + info.isDetach.Trim() + "'");
            }
            if ((info.isAuto != null) && (!info.isAuto.Trim().ToString().Equals("")))
            {
                fields.Add("isAuto");
                values.Add("'" + info.isAuto.Trim() + "'");
            }
            if ((info.remark != null) && (!info.remark.Trim().ToString().Equals("")))
            {
                fields.Add("remark");
                values.Add("'" + info.remark.Trim() + "'");
            }
            cond.Add("id=" + info.id);
            return this.UpdateTeble("waitDetachExpenditure", fields, values, cond);
        }
        /*
        * 方法名称：searchEquipmentName
        * 方法功能描述：设备的id 和名称
        * 参数: 
        *       
        * 创建人：付中华
        * 创建时间：2009-03-25
        *
        * 修改人：
        * 修改时间：2009-3-26
        * 修改内容：
        *
        */
        public DataTable searchEquipmentName()
        {
            #region // 此方法取得不是想要的修改为
            //StringBuilder sqlStr = new StringBuilder();
            //ArrayList list = new ArrayList();

            //sqlStr.Append("select id,name from equipmentName");
            //list.Add(sqlStr.ToString());

            //return sqlHelperObj.QueryForDateSet(list).Tables[0];
            #endregion

            LinkSelect linkS = new LinkSelect();
            linkS.TableNames.Add("equipmentInformation");
            linkS.TableNames.Add("equipmentModel");
            linkS.LinkConds.Add("equipmentInformation.emId=equipmentModel.id");
            linkS.TableNames.Add("equipmentName");
            linkS.LinkConds.Add("equipmentInformation.enId=equipmentName.id");
            linkS.Viewfields.Add("equipmentInformation.id");
            linkS.Viewfields.Add("equipmentName.name");
            linkS.Viewfields.Add("equipmentModel.model");

            DataTable dt = linkS.LeftLinkOpen().Tables[0];
            DataTable dtnew = new DataTable();
            dtnew.Columns.Add(new DataColumn("id"));
            dtnew.Columns.Add(new DataColumn("name"));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtnew.Rows.Add(dtnew.NewRow());
                dtnew.Rows[i][0] = dt.Rows[i][0].ToString();
                dtnew.Rows[i][1] = dt.Rows[i][1].ToString() + "_" + dt.Rows[i][2].ToString();
            }

            return dtnew;

        }
        /*
        * 方法名称：searchProductName
        * 方法功能描述：产品的id 和名称_规格组合为一个字段
        * 参数: 
        *       
        * 创建人：付中华
        * 创建时间：2009-03-25
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable searchProductName()
        {
            LinkSelect linkS = new LinkSelect();
            linkS.TableNames.Add("product");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmid=productModel.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnid=productName.id");
            linkS.Viewfields.Add("product.id");
            linkS.Viewfields.Add("productName.name");
            linkS.Viewfields.Add("productModel.model");

            DataTable dt = linkS.LeftLinkOpen().Tables[0];
            DataTable dtnew=new DataTable();
            dtnew.Columns.Add(new DataColumn("id"));
            dtnew.Columns.Add(new DataColumn("productName"));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtnew.Rows.Add(dtnew.NewRow());
                dtnew.Rows[i][0] = dt.Rows[i][0].ToString();
                dtnew.Rows[i][1] = dt.Rows[i][1].ToString() + "_" + dt.Rows[i][2].ToString();
            }

            return dtnew;

        }
        /*
        * 方法名称：expenditure
        * 方法功能描述：expenditure表删除一条记录
        * 参数:id 
        *       
        * 创建人：付中华
        * 创建时间：2009-03-25
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool deleteExpenditure(long id)
        {
            StringBuilder sqlStr=new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("delete from expenditure where id=" + id);
            list.Add(sqlStr.ToString());

            return sqlHelperObj.Delete(list);
        }
        /*
       * 方法名称：bitumenExpenditure
       * 方法功能描述：bitumenExpenditure表删除一条记录
       * 参数:id 
       *       
       * 创建人：付中华
       * 创建时间：2009-03-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool deleteBitumenExpenditure(long id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("delete from bitumenExpenditure where id=" + id);
            list.Add(sqlStr.ToString());

            return sqlHelperObj.Delete(list);
        }
        /*
       * 方法名称：alterBitumenExpenditure
       * 方法功能描述：alterBitumenExpenditure表删除一条记录
       * 参数:id 
       *       
       * 创建人：付中华
       * 创建时间：2009-03-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool deleteAlterBitumenExpenditure(long id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("delete from alterBitumenExpenditure where id=" + id);
            list.Add(sqlStr.ToString());

            return sqlHelperObj.Delete(list);
        }
        /*
       * 方法名称：waitDetachExpenditure
       * 方法功能描述：waitDetachExpenditure表删除一条记录
       * 参数:id 
       *       
       * 创建人：付中华
       * 创建时间：2009-03-25
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool deleteWaitDetachExpenditure(long id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("delete from waitDetachExpenditure where id= " + id);
            list.Add(sqlStr.ToString());

            return sqlHelperObj.Delete(list);
        }
        /*
      * 方法名称：bitumenWaitDetachExpenditure
      * 方法功能描述：bitumenWaitDetachExpenditure表删除一条记录
      * 参数:id 
      *       
      * 创建人：付中华
      * 创建时间：2009-03-28
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool deleteBitumenWaitDetachExpenditure(long id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("delete from bitumenWaitDetachExpenditure where id= " + id);
            list.Add(sqlStr.ToString());

            return sqlHelperObj.Delete(list);
        }
        /*
     * 方法名称：alterBitumenWaitDetachExpenditure
     * 方法功能描述：alterBitumenWaitDetachExpenditure表删除一条记录
     * 参数:id 
     *       
     * 创建人：付中华
     * 创建时间：2009-03-28
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool deleteAlterBitumenWaitDetachExpenditure(long id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("delete from alterBitumenWaitDetachExpenditure where id= " + id);
            list.Add(sqlStr.ToString());

            return sqlHelperObj.Delete(list);
        }
        /*
         * 方法名称：SelectAllExpenditure
         * 方法功能描述：根据实体类中，各条件，组合查询费用
         * 参数:conds 是实体类，代替查询条件 
         * *       
         * 创建人：袁宇
         * 创建时间：2009-03-26
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataTable SelectAllExpenditure(selectExpenditureClass conds)
        {
            LinkSelect linkS = new LinkSelect();
            DataTable dt = new DataTable();

            linkS.TableNames.Add("ViewAllExpenditure");
            linkS.TableNames.Add("expenditureName expenditureName1");
            linkS.LinkConds.Add("ViewAllExpenditure.ekId=expenditureName1.id");
            linkS.TableNames.Add("expenditureName expenditureName2");
            linkS.LinkConds.Add("ViewAllExpenditure.enId=expenditureName2.id");
            linkS.TableNames.Add("expenditureName expenditureName3");
            linkS.LinkConds.Add("ViewAllExpenditure.ecId=expenditureName3.id");
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("ViewAllExpenditure.eiId=equipmentInformation.id");
            linkS.TableNames.Add("equipmentName");
            linkS.LinkConds.Add("equipmentInformation.enid=equipmentName.id");
            linkS.TableNames.Add("equipmentModel");
            linkS.LinkConds.Add("equipmentInformation.emId=equipmentModel.id");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("ViewAllExpenditure.pId=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");

            linkS.Viewfields.Add("ViewAllExpenditure.id");
            linkS.Viewfields.Add("expenditureName1.name as 费用类别");
            linkS.Viewfields.Add("expenditureName2.name as 费用名称");
            linkS.Viewfields.Add("expenditureName3.name as 费用明细");
            linkS.Viewfields.Add("ViewAllExpenditure.expenditureDepict as 费用描述");
            linkS.Viewfields.Add("ViewAllExpenditure.[year] as 年份");
            linkS.Viewfields.Add("ViewAllExpenditure.[month] as 月份");
            linkS.Viewfields.Add("equipmentName.name as 设备名称");
            linkS.Viewfields.Add("equipmentModel.model as 设备型号");
            linkS.Viewfields.Add("productName.name as 产品名称");
            linkS.Viewfields.Add("productModel.model as 产品型号");
            linkS.Viewfields.Add("ViewAllExpenditure.unitPrice as 单价");
            linkS.Viewfields.Add("ViewAllExpenditure.number as 数量");
            linkS.Viewfields.Add("ViewAllExpenditure.[money] as 金额");
            linkS.Viewfields.Add("ViewAllExpenditure.inputDate as 录入时间");
            linkS.Viewfields.Add("ViewAllExpenditure.inputMan as 录入人");
            linkS.Viewfields.Add("ViewAllExpenditure.assessor as 审核人");
            linkS.Viewfields.Add("ViewAllExpenditure.checkupMan as 审批人");
            linkS.Viewfields.Add("ViewAllExpenditure.[convert] as 折算系数");
            linkS.Viewfields.Add("ViewAllExpenditure.remark as 备注");


            if ((conds.exSort != null))
                if (conds.exSort.Trim().Equals(""))
                    linkS.Conds.Add("(expenditureName1.name=" + "'" + conds.exSort + "' or expenditureName1.name is NULL)");
                else
                    linkS.Conds.Add("expenditureName1.name=" + "'" + conds.exSort + "'");

            if ((conds.exName != null))
                if (conds.exName.Trim().Equals(""))
                    linkS.Conds.Add("(expenditureName2.name=" + "'" + conds.exName + "' or expenditureName2.name is NULL)");
                else
                    linkS.Conds.Add("expenditureName2.name=" + "'" + conds.exName + "'");
                

            if ((conds.exDetail != null))
                if (conds.exDetail.Trim().Equals(""))
                    linkS.Conds.Add("(expenditureName3.name=" + "'" + conds.exDetail + "' or expenditureName3.name is NULL)");
                else
                    linkS.Conds.Add("expenditureName3.name=" + "'" + conds.exDetail + "'");                

            if ((conds.exDepict != null))
                if (conds.exDepict.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAllExpenditure.expenditureDepict=" + "'" + conds.exDepict + "' or ViewAllExpenditure.expenditureDepict is NULL)");
                else
                    linkS.Conds.Add("ViewAllExpenditure.expenditureDepict=" + "'" + conds.exDepict + "'");            

            if ((conds.exYear != null))
                if (conds.exYear.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAllExpenditure.[year]=" + "'" + conds.exYear + "' or ViewAllExpenditure.[year] is NULL)");
                else
                    linkS.Conds.Add("ViewAllExpenditure.[year]=" + "'" + conds.exYear + "'");                 

            if ((conds.exMonth != null))
                if (conds.exMonth.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAllExpenditure.[month]=" + "'" + conds.exMonth + "' or ViewAllExpenditure.[month] is NULL)");
                else
                    linkS.Conds.Add("ViewAllExpenditure.[month]=" + "'" + conds.exMonth + "'");

            if ((conds.eqName != null))
                if (conds.eqName.Trim().Equals(""))
                    linkS.Conds.Add("(equipmentName.name=" + "'" + conds.eqName + "' or equipmentName.name is NULL)");
                else
                    linkS.Conds.Add("equipmentName.name=" + "'" + conds.eqName + "'");             

            if ((conds.eqModel != null))
                if (conds.eqModel.Trim().Equals(""))
                    linkS.Conds.Add("(equipmentModel.model=" + "'" + conds.eqModel + "' or equipmentModel.model is NULL)");
                else
                    linkS.Conds.Add("equipmentModel.model=" + "'" + conds.eqModel + "'");  
            if ((conds.prName != null))
                if (conds.prName.Trim().Equals(""))
                    linkS.Conds.Add("(productName.name=" + "'" + conds.prName + "' or productName.name is NULL)");
                else
                    linkS.Conds.Add("productName.name=" + "'" + conds.prName + "'");  
            if ((conds.prModel != null))
                if (conds.prModel.Trim().Equals(""))
                    linkS.Conds.Add("(productModel.model=" + "'" + conds.prModel + "' or productModel.model is NULL)");
                else
                    linkS.Conds.Add("productModel.model=" + "'" + conds.prModel + "'");  
            if ((conds.exUnitPrice != null))
                if (conds.exUnitPrice.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAllExpenditure.unitPrice=" + "'" + conds.exUnitPrice + "' or ViewAllExpenditure.unitPrice is NULL)");
                else
                    linkS.Conds.Add("ViewAllExpenditure.unitPrice=" + "'" + conds.exUnitPrice + "'");  
            if ((conds.exNumber != null))
                if (conds.exNumber.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAllExpenditure.number=" + "'" + conds.exNumber + "' or ViewAllExpenditure.number is NULL)");
                else
                    linkS.Conds.Add("ViewAllExpenditure.number=" + "'" + conds.exNumber + "'");  
            if ((conds.exMoney != null))
                if (conds.exMoney.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAllExpenditure.[money]=" + "'" + conds.exMoney + "' or ViewAllExpenditure.[money] is NULL)");
                else
                    linkS.Conds.Add("ViewAllExpenditure.[money]=" + "'" + conds.exMoney + "'");           
            if ((conds.exInputMan != null))
                if (conds.exInputMan.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAllExpenditure.inputMan=" + "'" + conds.exInputMan + "' or ViewAllExpenditure.inputMan is NULL)");
                else
                    linkS.Conds.Add("ViewAllExpenditure.inputMan=" + "'" + conds.exInputMan + "'");
            if ((conds.exConvert != null))
                if (conds.exConvert.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAllExpenditure.[convert]=" + "'" + conds.exConvert + "' or ViewAllExpenditure.[convert] is NULL)");
                else
                    linkS.Conds.Add("ViewAllExpenditure.[convert]=" + "'" + conds.exConvert + "'");
            if ((conds.exRemark != null))
                if (conds.exRemark.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAllExpenditure.remark=" + "'" + conds.exRemark + "' or ViewAllExpenditure.remark is NULL)");
                else
                    linkS.Conds.Add("ViewAllExpenditure.remark=" + "'" + conds.exRemark + "'");

            if ((conds.beginDateTime != null) && (!conds.beginDateTime.Equals("")))
            {
                linkS.Conds.Add("ViewAllExpenditure.inputdate>=" + "'" + conds.beginDateTime + "'");
            }
            if ((conds.endDateTime != null) && (!conds.endDateTime.Equals("")))
            {
                linkS.Conds.Add("ViewAllExpenditure.inputdate<=" + "'" + conds.endDateTime + "'");
            }
            switch (conds.flag)
            {
                case "全部":
                    break;
                case "未审核未审批":
                    linkS.Conds.Add("((ViewAllExpenditure.assessor is NULL) or (ViewAllExpenditure.assessor = ''))");
                    linkS.Conds.Add("((ViewAllExpenditure.checkupMan is NULL) or (ViewAllExpenditure.checkupMan = ''))");
                    break;
                case "已审核未审批":
                    linkS.Conds.Add("(ViewAllExpenditure.assessor is not NULL) and (ViewAllExpenditure.assessor <>'') ");
                    linkS.Conds.Add("((ViewAllExpenditure.checkupMan is NULL) or (ViewAllExpenditure.checkupMan = ''))");
                    break;
                case "已审核已审批":
                    linkS.Conds.Add("(ViewAllExpenditure.assessor is not NULL) and (ViewAllExpenditure.assessor <> '')");
                    linkS.Conds.Add("(( ViewAllExpenditure.checkupMan is not NULL) and (ViewAllExpenditure.checkupMan <> ''))");
                    break;
                default:
                    break;
            }     

            dt = linkS.LeftLinkOpen().Tables[0];

            return dt;
                        
        }


        /*
         * 方法名称：SelectAllExpenditure
         * 方法功能描述：根据实体类中，各条件，组合查询费用
         * 参数:conds 是实体类，代替查询条件 
         * *       
         * 创建人：付中华
         * 创建时间：2009-03-28
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataTable SelectAllExpenditure(selectBitumenExpenditureClass conds)
        {
            LinkSelect linkS = new LinkSelect();
            DataTable dt = new DataTable();

            linkS.TableNames.Add("ViewbitmenExpenditure");
            linkS.TableNames.Add("expenditureName expenditureName1");
            linkS.LinkConds.Add("ViewbitmenExpenditure.ekId=expenditureName1.id");
            linkS.TableNames.Add("expenditureName expenditureName2");
            linkS.LinkConds.Add("ViewbitmenExpenditure.enId=expenditureName2.id");
            linkS.TableNames.Add("expenditureName expenditureName3");
            linkS.LinkConds.Add("ViewbitmenExpenditure.ecId=expenditureName3.id");
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("ViewbitmenExpenditure.eiId=equipmentInformation.id");
            linkS.TableNames.Add("equipmentName");
            linkS.LinkConds.Add("equipmentInformation.enid=equipmentName.id");
            linkS.TableNames.Add("equipmentModel");
            linkS.LinkConds.Add("equipmentInformation.emId=equipmentModel.id");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("ViewbitmenExpenditure.pId=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");

            linkS.Viewfields.Add("ViewbitmenExpenditure.id");
            linkS.Viewfields.Add("expenditureName1.name as 费用类别");
            linkS.Viewfields.Add("expenditureName2.name as 费用名称");
            linkS.Viewfields.Add("expenditureName3.name as 费用明细");
            linkS.Viewfields.Add("ViewbitmenExpenditure.expenditureDepict as 费用描述");
            linkS.Viewfields.Add("ViewbitmenExpenditure.[year] as 年份");
            linkS.Viewfields.Add("ViewbitmenExpenditure.[month] as 月份");
            linkS.Viewfields.Add("equipmentName.name as 设备名称");
            linkS.Viewfields.Add("equipmentModel.model as 设备型号");
            linkS.Viewfields.Add("productName.name as 产品名称");
            linkS.Viewfields.Add("productModel.model as 产品型号");
            linkS.Viewfields.Add("ViewbitmenExpenditure.unitPrice as 单价");
            linkS.Viewfields.Add("ViewbitmenExpenditure.number as 数量");
            linkS.Viewfields.Add("ViewbitmenExpenditure.[money] as 金额");
            linkS.Viewfields.Add("ViewbitmenExpenditure.inputDate as 录入时间");
            linkS.Viewfields.Add("ViewbitmenExpenditure.inputMan as 录入人");
            linkS.Viewfields.Add("ViewbitmenExpenditure.assessor as 审核人");
            linkS.Viewfields.Add("ViewbitmenExpenditure.checkupMan as 审批人");
            linkS.Viewfields.Add("ViewbitmenExpenditure.[convert] as 折算系数");
            linkS.Viewfields.Add("ViewbitmenExpenditure.remark as 备注");


            if ((conds.exSort != null))
                if (conds.exSort.Trim().Equals(""))
                    linkS.Conds.Add("(expenditureName1.name=" + "'" + conds.exSort + "' or expenditureName1.name is NULL)");
                else
                    linkS.Conds.Add("expenditureName1.name=" + "'" + conds.exSort + "'");

            if ((conds.exName != null))
                if (conds.exName.Trim().Equals(""))
                    linkS.Conds.Add("(expenditureName2.name=" + "'" + conds.exName + "' or expenditureName2.name is NULL)");
                else
                    linkS.Conds.Add("expenditureName2.name=" + "'" + conds.exName + "'");
                

            if ((conds.exDetail != null))
                if (conds.exDetail.Trim().Equals(""))
                    linkS.Conds.Add("(expenditureName3.name=" + "'" + conds.exDetail + "' or expenditureName3.name is NULL)");
                else
                    linkS.Conds.Add("expenditureName3.name=" + "'" + conds.exDetail + "'");                

            if ((conds.exDepict != null))
                if (conds.exDepict.Trim().Equals(""))
                    linkS.Conds.Add("(ViewbitmenExpenditure.expenditureDepict=" + "'" + conds.exDepict + "' or ViewbitmenExpenditure.expenditureDepict is NULL)");
                else
                    linkS.Conds.Add("ViewbitmenExpenditure.expenditureDepict=" + "'" + conds.exDepict + "'");            

            if ((conds.exYear != null))
                if (conds.exYear.Trim().Equals(""))
                    linkS.Conds.Add("(ViewbitmenExpenditure.[year]=" + "'" + conds.exYear + "' or ViewbitmenExpenditure.[year] is NULL)");
                else
                    linkS.Conds.Add("ViewbitmenExpenditure.[year]=" + "'" + conds.exYear + "'");                 

            if ((conds.exMonth != null))
                if (conds.exMonth.Trim().Equals(""))
                    linkS.Conds.Add("(ViewbitmenExpenditure.[month]=" + "'" + conds.exMonth + "' or ViewbitmenExpenditure.[month] is NULL)");
                else
                    linkS.Conds.Add("ViewbitmenExpenditure.[month]=" + "'" + conds.exMonth + "'");

            if ((conds.eqName != null))
                if (conds.eqName.Trim().Equals(""))
                    linkS.Conds.Add("(equipmentName.name=" + "'" + conds.eqName + "' or equipmentName.name is NULL)");
                else
                    linkS.Conds.Add("equipmentName.name=" + "'" + conds.eqName + "'");             

            if ((conds.eqModel != null))
                if (conds.eqModel.Trim().Equals(""))
                    linkS.Conds.Add("(equipmentModel.model=" + "'" + conds.eqModel + "' or equipmentModel.model is NULL)");
                else
                    linkS.Conds.Add("equipmentModel.model=" + "'" + conds.eqModel + "'");  
            if ((conds.prName != null))
                if (conds.prName.Trim().Equals(""))
                    linkS.Conds.Add("(productName.name=" + "'" + conds.prName + "' or productName.name is NULL)");
                else
                    linkS.Conds.Add("productName.name=" + "'" + conds.prName + "'");  
            if ((conds.prModel != null))
                if (conds.prModel.Trim().Equals(""))
                    linkS.Conds.Add("(productModel.model=" + "'" + conds.prModel + "' or productModel.model is NULL)");
                else
                    linkS.Conds.Add("productModel.model=" + "'" + conds.prModel + "'");  
            if ((conds.exUnitPrice != null))
                if (conds.exUnitPrice.Trim().Equals(""))
                    linkS.Conds.Add("(ViewbitmenExpenditure.unitPrice=" + "'" + conds.exUnitPrice + "' or ViewbitmenExpenditure.unitPrice is NULL)");
                else
                    linkS.Conds.Add("ViewbitmenExpenditure.unitPrice=" + "'" + conds.exUnitPrice + "'");  
            if ((conds.exNumber != null))
                if (conds.exNumber.Trim().Equals(""))
                    linkS.Conds.Add("(ViewbitmenExpenditure.number=" + "'" + conds.exNumber + "' or ViewbitmenExpenditure.number is NULL)");
                else
                    linkS.Conds.Add("ViewbitmenExpenditure.number=" + "'" + conds.exNumber + "'");  
            if ((conds.exMoney != null))
                if (conds.exMoney.Trim().Equals(""))
                    linkS.Conds.Add("(ViewbitmenExpenditure.[money]=" + "'" + conds.exMoney + "' or ViewbitmenExpenditure.[money] is NULL)");
                else
                    linkS.Conds.Add("ViewbitmenExpenditure.[money]=" + "'" + conds.exMoney + "'");           
            if ((conds.exInputMan != null))
                if (conds.exInputMan.Trim().Equals(""))
                    linkS.Conds.Add("(ViewbitmenExpenditure.inputMan=" + "'" + conds.exInputMan + "' or ViewbitmenExpenditure.inputMan is NULL)");
                else
                    linkS.Conds.Add("ViewbitmenExpenditure.inputMan=" + "'" + conds.exInputMan + "'");
            if ((conds.exConvert != null))
                if (conds.exConvert.Trim().Equals(""))
                    linkS.Conds.Add("(ViewbitmenExpenditure.[convert]=" + "'" + conds.exConvert + "' or ViewbitmenExpenditure.[convert] is NULL)");
                else
                    linkS.Conds.Add("ViewbitmenExpenditure.[convert]=" + "'" + conds.exConvert + "'");
            if ((conds.exRemark != null))
                if (conds.exRemark.Trim().Equals(""))
                    linkS.Conds.Add("(ViewbitmenExpenditure.remark=" + "'" + conds.exRemark + "' or ViewbitmenExpenditure.remark is NULL)");
                else
                    linkS.Conds.Add("ViewbitmenExpenditure.remark=" + "'" + conds.exRemark + "'");

            if ((conds.beginDateTime != null) && (!conds.beginDateTime.Equals("")))
            {
                linkS.Conds.Add("ViewbitmenExpenditure.inputdate>=" + "'" + conds.beginDateTime + "'");
            }
            if ((conds.endDateTime != null) && (!conds.endDateTime.Equals("")))
            {
                linkS.Conds.Add("ViewbitmenExpenditure.inputdate<=" + "'" + conds.endDateTime + "'");
            }
            switch (conds.flag)
            {
                case "全部":
                    break;
                case "未审核未审批":
                    //linkS.Conds.Add("( ViewbitmenExpenditure.assessor is null) and (ViewbitmenExpenditure.checkupMan is null)");

                    linkS.Conds.Add("((ViewbitmenExpenditure.assessor is NULL) or (ViewbitmenExpenditure.assessor = ''))");
                    linkS.Conds.Add("((ViewbitmenExpenditure.checkupMan is NULL) or (ViewbitmenExpenditure.checkupMan = ''))");
                    break;
                case "已审核未审批":
                    //linkS.Conds.Add("( ViewbitmenExpenditure.assessor is not null) and (ViewbitmenExpenditure.checkupMan is null)");

                    linkS.Conds.Add("(ViewbitmenExpenditure.assessor is not NULL) and (ViewbitmenExpenditure.assessor <>'') ");
                    linkS.Conds.Add("((ViewbitmenExpenditure.checkupMan is NULL) or (ViewbitmenExpenditure.checkupMan = ''))");
                    break;
                case "已审核已审批":
                    //linkS.Conds.Add("( ViewbitmenExpenditure.assessor is not null) and ( ViewbitmenExpenditure.checkupMan is not null)");

                    linkS.Conds.Add("(ViewbitmenExpenditure.assessor is not NULL) and (ViewbitmenExpenditure.assessor <> '')");
                    linkS.Conds.Add("(( ViewbitmenExpenditure.checkupMan is not NULL) and (ViewbitmenExpenditure.checkupMan <> ''))");

                    break;
                default:
                    break;
            }
      

            dt = linkS.LeftLinkOpen().Tables[0];

            return dt;
                        
        }

        /*
         * 方法名称：SelectAllExpenditure
         * 方法功能描述：根据实体类中，各条件，组合查询费用
         * 参数:conds 是实体类，代替查询条件 
         * *       
         * 创建人：付中华
         * 创建时间：2009-03-28
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataTable SelectAllExpenditure(selectAlterBitumenWaitDetachExpenditure conds)
        {
            LinkSelect linkS = new LinkSelect();
            DataTable dt = new DataTable();

            linkS.TableNames.Add("ViewAlterBitumenExpenditure");
            linkS.TableNames.Add("expenditureName expenditureName1");
            linkS.LinkConds.Add("ViewAlterBitumenExpenditure.ekId=expenditureName1.id");
            linkS.TableNames.Add("expenditureName expenditureName2");
            linkS.LinkConds.Add("ViewAlterBitumenExpenditure.enId=expenditureName2.id");
            linkS.TableNames.Add("expenditureName expenditureName3");
            linkS.LinkConds.Add("ViewAlterBitumenExpenditure.ecId=expenditureName3.id");
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("ViewAlterBitumenExpenditure.eiId=equipmentInformation.id");
            linkS.TableNames.Add("equipmentName");
            linkS.LinkConds.Add("equipmentInformation.enid=equipmentName.id");
            linkS.TableNames.Add("equipmentModel");
            linkS.LinkConds.Add("equipmentInformation.emId=equipmentModel.id");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("ViewAlterBitumenExpenditure.pId=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");

            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.id");
            linkS.Viewfields.Add("expenditureName1.name as 费用类别");
            linkS.Viewfields.Add("expenditureName2.name as 费用名称");
            linkS.Viewfields.Add("expenditureName3.name as 费用明细");
            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.expenditureDepict as 费用描述");
            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.[year] as 年份");
            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.[month] as 月份");
            linkS.Viewfields.Add("equipmentName.name as 设备名称");
            linkS.Viewfields.Add("equipmentModel.model as 设备型号");
            linkS.Viewfields.Add("productName.name as 产品名称");
            linkS.Viewfields.Add("productModel.model as 产品型号");
            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.unitPrice as 单价");
            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.number as 数量");
            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.[money] as 金额");
            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.inputDate as 录入时间");
            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.inputMan as 录入人");
            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.assessor as 审核人");
            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.checkupMan as 审批人");
            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.[convert] as 折算系数");
            linkS.Viewfields.Add("ViewAlterBitumenExpenditure.remark as 备注");


            if ((conds.exSort != null))
                if (conds.exSort.Trim().Equals(""))
                    linkS.Conds.Add("(expenditureName1.name=" + "'" + conds.exSort + "' or expenditureName1.name is NULL)");
                else
                    linkS.Conds.Add("expenditureName1.name=" + "'" + conds.exSort + "'");

            if ((conds.exName != null))
                if (conds.exName.Trim().Equals(""))
                    linkS.Conds.Add("(expenditureName2.name=" + "'" + conds.exName + "' or expenditureName2.name is NULL)");
                else
                    linkS.Conds.Add("expenditureName2.name=" + "'" + conds.exName + "'");


            if ((conds.exDetail != null))
                if (conds.exDetail.Trim().Equals(""))
                    linkS.Conds.Add("(expenditureName3.name=" + "'" + conds.exDetail + "' or expenditureName3.name is NULL)");
                else
                    linkS.Conds.Add("expenditureName3.name=" + "'" + conds.exDetail + "'");

            if ((conds.exDepict != null))
                if (conds.exDepict.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAlterBitumenExpenditure.expenditureDepict=" + "'" + conds.exDepict + "' or ViewAlterBitumenExpenditure.expenditureDepict is NULL)");
                else
                    linkS.Conds.Add("ViewAlterBitumenExpenditure.expenditureDepict=" + "'" + conds.exDepict + "'");

            if ((conds.exYear != null))
                if (conds.exYear.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAlterBitumenExpenditure.[year]=" + "'" + conds.exYear + "' or ViewAlterBitumenExpenditure.[year] is NULL)");
                else
                    linkS.Conds.Add("ViewAlterBitumenExpenditure.[year]=" + "'" + conds.exYear + "'");

            if ((conds.exMonth != null))
                if (conds.exMonth.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAlterBitumenExpenditure.[month]=" + "'" + conds.exMonth + "' or ViewAlterBitumenExpenditure.[month] is NULL)");
                else
                    linkS.Conds.Add("ViewAlterBitumenExpenditure.[month]=" + "'" + conds.exMonth + "'");

            if ((conds.eqName != null))
                if (conds.eqName.Trim().Equals(""))
                    linkS.Conds.Add("(equipmentName.name=" + "'" + conds.eqName + "' or equipmentName.name is NULL)");
                else
                    linkS.Conds.Add("equipmentName.name=" + "'" + conds.eqName + "'");

            if ((conds.eqModel != null))
                if (conds.eqModel.Trim().Equals(""))
                    linkS.Conds.Add("(equipmentModel.model=" + "'" + conds.eqModel + "' or equipmentModel.model is NULL)");
                else
                    linkS.Conds.Add("equipmentModel.model=" + "'" + conds.eqModel + "'");
            if ((conds.prName != null))
                if (conds.prName.Trim().Equals(""))
                    linkS.Conds.Add("(productName.name=" + "'" + conds.prName + "' or productName.name is NULL)");
                else
                    linkS.Conds.Add("productName.name=" + "'" + conds.prName + "'");
            if ((conds.prModel != null))
                if (conds.prModel.Trim().Equals(""))
                    linkS.Conds.Add("(productModel.model=" + "'" + conds.prModel + "' or productModel.model is NULL)");
                else
                    linkS.Conds.Add("productModel.model=" + "'" + conds.prModel + "'");
            if ((conds.exUnitPrice != null))
                if (conds.exUnitPrice.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAlterBitumenExpenditure.unitPrice=" + "'" + conds.exUnitPrice + "' or ViewAlterBitumenExpenditure.unitPrice is NULL)");
                else
                    linkS.Conds.Add("ViewAlterBitumenExpenditure.unitPrice=" + "'" + conds.exUnitPrice + "'");
            if ((conds.exNumber != null))
                if (conds.exNumber.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAlterBitumenExpenditure.number=" + "'" + conds.exNumber + "' or ViewAlterBitumenExpenditure.number is NULL)");
                else
                    linkS.Conds.Add("ViewAlterBitumenExpenditure.number=" + "'" + conds.exNumber + "'");
            if ((conds.exMoney != null))
                if (conds.exMoney.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAlterBitumenExpenditure.[money]=" + "'" + conds.exMoney + "' or ViewAlterBitumenExpenditure.[money] is NULL)");
                else
                    linkS.Conds.Add("ViewAlterBitumenExpenditure.[money]=" + "'" + conds.exMoney + "'");         
            if ((conds.exInputMan != null))
                if (conds.exInputMan.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAlterBitumenExpenditure.inputMan=" + "'" + conds.exInputMan + "' or ViewAlterBitumenExpenditure.inputMan is NULL)");
                else
                    linkS.Conds.Add("ViewAlterBitumenExpenditure.inputMan=" + "'" + conds.exInputMan + "'");
            if ((conds.exConvert != null))
                if (conds.exConvert.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAlterBitumenExpenditure.[convert]=" + "'" + conds.exConvert + "' or ViewbitumenExpenditure.[convert] is NULL)");
                else
                    linkS.Conds.Add("ViewAlterBitumenExpenditure.[convert]=" + "'" + conds.exConvert + "'");
            if ((conds.exRemark != null))
                if (conds.exRemark.Trim().Equals(""))
                    linkS.Conds.Add("(ViewAlterBitumenExpenditure.remark=" + "'" + conds.exRemark + "' or ViewAlterBitumenExpenditure.remark is NULL)");
                else
                    linkS.Conds.Add("ViewAlterBitumenExpenditure.remark=" + "'" + conds.exRemark + "'");

            if ((conds.beginDateTime != null) && (!conds.beginDateTime.Equals("")))
            {
                linkS.Conds.Add("ViewAlterBitumenExpenditure.inputdate>=" + "'" + conds.beginDateTime + "'");
            }
            if ((conds.endDateTime != null) && (!conds.endDateTime.Equals("")))
            {
                linkS.Conds.Add("ViewAlterBitumenExpenditure.inputdate<=" + "'" + conds.endDateTime + "'");
            }
            switch (conds.flag)
            {
                case "全部":
                    break;
                case "未审核未审批":
                    //linkS.Conds.Add("( ViewAlterBitumenExpenditure.assessor is null) and (ViewAlterBitumenExpenditure.checkupMan is null)");

                    linkS.Conds.Add("((ViewAlterBitumenExpenditure.assessor is NULL) or (ViewAlterBitumenExpenditure.assessor = ''))");
                    linkS.Conds.Add("((ViewAlterBitumenExpenditure.checkupMan is NULL) or (ViewAlterBitumenExpenditure.checkupMan = ''))");

                    break;
                case "已审核未审批":
                    //linkS.Conds.Add("( ViewAlterBitumenExpenditure.assessor is not null) and (ViewAlterBitumenExpenditure.checkupMan is null)");

                    linkS.Conds.Add("(ViewAlterBitumenExpenditure.assessor is not NULL) and (ViewAlterBitumenExpenditure.assessor <>'') ");
                    linkS.Conds.Add("((ViewAlterBitumenExpenditure.checkupMan is NULL) or (ViewAlterBitumenExpenditure.checkupMan = ''))");
                    break;
                case "已审核已审批":
                    //linkS.Conds.Add("( ViewAlterBitumenExpenditure.assessor is not null) and ( ViewAlterBitumenExpenditure.checkupMan is not null)");

                    linkS.Conds.Add("(ViewAlterBitumenExpenditure.assessor is not NULL) and (ViewAlterBitumenExpenditure.assessor <> '')");
                    linkS.Conds.Add("(( ViewAlterBitumenExpenditure.checkupMan is not NULL) and (ViewAlterBitumenExpenditure.checkupMan <> ''))");

                    break;
                default:
                    break;
            }


            dt = linkS.LeftLinkOpen().Tables[0];

            return dt;

        }

    }

    /*
     * 类名称：ManExpenditureDB
     * 类功能描述：直接人工费用类，继承CostCountDB
     *
     * 创建人：袁宇
     * 创建时间：2009-03-18
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class ManExpenditureDB : CostCountDB
    {
        SqlHelper sqlHelperObj = new SqlHelper();
        /*
         * 方法名称：SelectProduceTeam
         * 方法功能描述：查询生产班组列表
         * 参数:
         * *       
         * 创建人：袁宇
         * 创建时间：2009-03-27
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataTable SelectProduceTeam()
        {
            ArrayList sqlStr = new ArrayList();

            sqlStr.Add("select id,[name] from ProduceTeam");
            return sqlHelperObj.QueryForDateSet(sqlStr).Tables[0];            
        }
    }
    /*
     * 类名称：MakeExpenditureDB
     * 类功能描述：制造费用类，继承CostCountDB
     *
     * 创建人：袁宇
     * 创建时间：2009-03-18
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class MakeExpenditureDB : CostCountDB
    {

    }
    /*
     * 类名称：ShutdownExpenditureDB
     * 类功能描述：季节停工损失类，继承CostCountDB
     *
     * 创建人：袁宇
     * 创建时间：2009-03-18
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class ShutdownExpenditureDB : CostCountDB
    {

    }
    /*
     * 类名称：ScrapExpenditureDB
     * 类功能描述：废料损失类，继承CostCountDB
     *
     * 创建人：袁宇
     * 创建时间：2009-03-18
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class ScrapExpenditureDB : CostCountDB
    {

    }
    /*
     * 类名称：StuffExpenditureDB
     * 类功能描述：直接材料类，继承CostCountDB
     *
     * 创建人：袁宇
     * 创建时间：2009-03-18
     *
     * 修改人：付中华
     * 修改时间：2009-4-10
     * 修改内容：
     *
     */
    class StuffExpenditureDB : CostCountDB
    {
        SqlHelper sqlHelper = new SqlHelper();
        bitumenCostCountDB bitumendb = new bitumenCostCountDB();

        public DataTable SelectMixStuff(string year, string month)
        {
            DataTable recDt = new DataTable();
            DataTable dt = new DataTable();
            // 
            dt = this.getAutoDirectMaterialMixer(year, month, "混合料");
            //dt = SelectMixUseBitumen(year, month, "混合料");
            #region
            //recDt.Columns.Add("产品编号");
            //recDt.Columns.Add("产品名称");
            //recDt.Columns.Add("年份");
            //recDt.Columns.Add("月份");
            //recDt.Columns.Add("费用描述");
            //recDt.Columns.Add("设备编号");
            //recDt.Columns.Add("设备序号");
            //recDt.Columns.Add("数量");
            //recDt.Columns.Add("单价");
            //recDt.Columns.Add("金额");

            //foreach (DataRow row in dt.Rows)
            //{
            //    DataRow recRow = recDt.NewRow();
            //    recRow["产品编号"] = row["pId"].ToString();
            //    recRow["产品名称"] = row["产品名称"].ToString() + row["产品规格"].ToString();
            //    recRow["年份"] = year;
            //    recRow["月份"] = month;
            //    recRow["费用描述"] = row["材料名称"].ToString() + "_" + row["材料规格"].ToString();
            //    recRow["设备编号"] = row["设备编号"].ToString();
            //    recRow["设备序号"] = row["设备序号"].ToString();
            //    if (double.Parse(row["手动消耗量"].ToString()) != 0)
            //        recRow["数量"] = row["手动消耗量"].ToString();
            //    else
            //        recRow["数量"] = row["自动消耗量"].ToString();
            //    recRow["单价"] = GetunitPrice(row["材料编号"].ToString(), year, month);
            //    try
            //    {
            //        recRow["金额"] = (double.Parse(recRow["数量"].ToString()) * double.Parse(recRow["单价"].ToString())).ToString();
            //    }
            //    catch
            //    {
            //        recRow["金额"] = "0";
            //    }
            //    recDt.Rows.Add(recRow);
            //} 
            #endregion
             recDt.Columns.Add("费用类别");
            recDt.Columns.Add("费用描述");
            recDt.Columns.Add("年份");
            recDt.Columns.Add("月份");
            recDt.Columns.Add("设备编号");
            recDt.Columns.Add("设备序号");
            recDt.Columns.Add("产品编号");
            recDt.Columns.Add("产品名称");
            recDt.Columns.Add("数量");
            recDt.Columns.Add("单价");
            recDt.Columns.Add("金额");
            recDt.Columns.Add("ekid");

            foreach (DataRow row in dt.Rows)
            {
                DataRow recRow = recDt.NewRow();
                recRow["费用类别"] = "直接材料费用";
                recRow["产品编号"] = row["pId"].ToString();
                recRow["ekid"] = bitumendb.getExpenditureTypeId("直接材料费用").Rows[0][0];
                recRow["产品名称"] = row["产品名称"].ToString() + row["产品规格"].ToString();
                recRow["年份"] = year;
                recRow["月份"] = month;
                recRow["费用描述"] = row["材料名称"].ToString() + "_" + row["材料规格"].ToString();
                recRow["设备编号"] = row["设备编号"].ToString();
                recRow["设备序号"] = row["设备序号"].ToString();
                //if (double.Parse(row["手动消耗量"].ToString()) != 0)
                //    recRow["数量"] = row["手动消耗量"].ToString();
                //else
                //    recRow["数量"] = row["自动消耗量"].ToString();
                recRow["数量"] = row["数量"].ToString();
                if (row["单价"] != null)
                {
                    if (row["材料种类"].ToString() == "沥青")
                    {
                        double unitPrice = this.getBitumenHeatCost(year, month, Convert.ToInt64(row["pId"].ToString()));
                        recRow["单价"] = Convert.ToString(double.Parse(row["单价"].ToString()) + unitPrice);
                    }
                    else
                    { recRow["单价"] = row["单价"].ToString(); }
                }
                else
                {
                    recRow["单价"] = "0";
                }

                 //  2009-4-10 付中华修改
                directMaterialClass directMaterial = new directMaterialClass();

                directMaterial.ekId = recRow["ekid"].ToString();
                directMaterial.eiId = recRow["设备序号"].ToString();
                directMaterial.expenditureDepict = recRow["费用描述"].ToString();
                directMaterial.year = recRow["年份"].ToString();
                directMaterial.month = recRow["月份"].ToString();

                string number;
                if ((recRow["产品名称"] != null) && (!recRow["产品名称"].Equals("")))
                {
                    // 到改性沥青表中查找匹配的信息
                     number = this.directMaterialIsAutoMixer(directMaterial);
                     if (number == "-10000")
                     { }
                     else
                     {
                         recRow["数量"] = Convert.ToString(double.Parse(recRow["数量"].ToString()) - double.Parse(number));
                     }
                }
                else
                {
                    // 到改性沥青分摊表中查找匹配的信息
                    number = this.directMaterialIsAutoMixerDetach(directMaterial);
                    if (number == "-10000")
                    { }
                    else
                    {
                        recRow["数量"] = Convert.ToString(double.Parse(recRow["数量"].ToString()) - double.Parse(number));
                    }
                }

                if ((!recRow["数量"].ToString().Equals("")) && (double.Parse(recRow["数量"].ToString())) > 0)
                {
                    //recRow["单价"] = GetunitPrice(row["材料编号"].ToString(), year, month);
                    try
                    {
                        recRow["金额"] = (double.Parse(recRow["数量"].ToString()) * double.Parse(recRow["单价"].ToString())).ToString();
                    }
                    catch
                    {
                        recRow["金额"] = "0";
                    }
                    recDt.Rows.Add(recRow);
                }
                //  2009-4-10 付中华修改
            }                               
            return recDt; 
        }
        /* 
         * 方法名称：getAutoDirectMaterialMixer
         * 方法功能描述：此方法代替SelectMixUseBitumen方法  不用查询混合料消耗沥青的方法 直接到材料出库表中查询材料名称等于乳化沥青，改性沥青的
         * 参数: 
         * 
         * 创建人：付中华
         * 创建时间：2009-04-14
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataTable getAutoDirectMaterialMixer(string year, string month, string pName)
        {
            DataTable dt = new DataTable();
            LinkSelect linkS = new LinkSelect();
            linkS.TableNames.Add("materialOutDepot ");
            linkS.TableNames.Add("equipmentInformation ");
            linkS.LinkConds.Add("materialOutDepot.eiId=equipmentInformation.id");
            linkS.TableNames.Add("equipmentName");
            linkS.LinkConds.Add("equipmentInformation.enId=equipmentName.id");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("materialOutDepot.pId=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");
            linkS.TableNames.Add("productKind");
            linkS.LinkConds.Add("productName.pkId=productKind.id");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("materialOutDepot.mId=material.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnId=materialName.id");
            linkS.TableNames.Add("materialModel");
            linkS.LinkConds.Add("material.mmId=materialModel.id");
            linkS.TableNames.Add("materialKind");
            linkS.LinkConds.Add("materialName.mkId=materialKind.id");

            linkS.Viewfields.Add("materialOutDepot.pId as pId");
            linkS.Viewfields.Add("materialKind.sort as 材料种类");
            linkS.Viewfields.Add("materialName.name as 材料名称");
            linkS.Viewfields.Add("materialModel.model as 材料规格");
            linkS.Viewfields.Add("productName.name as 产品名称");
            linkS.Viewfields.Add("productModel.model as 产品规格");
            linkS.Viewfields.Add("equipmentInformation.no as 设备编号");
            linkS.Viewfields.Add("equipmentInformation.id as 设备序号");
            linkS.Viewfields.Add("equipmentName.name as 设备名称");
            linkS.Viewfields.Add("materialOutDepot.number as 数量");
            linkS.Viewfields.Add("materialOutDepot.unitPrice as 单价 ");




            linkS.Conds.Add("productKind.sort=" + "'" + "混合料" + "'");
            linkS.Conds.Add("Year(materialOutDepot.inputDate)=" + "'" + year + "'");
            linkS.Conds.Add("Month(materialOutDepot.inputDate)=" + "'" + month + "'");
            linkS.Conds.Add(" (not assessor is NULL)");
            linkS.Conds.Add("(not checkupMan is NULL)");
            linkS.Conds.Add("kindMark=" + 0);

            dt = linkS.LeftLinkOpen().Tables[0];

            return dt;

        }
        /*
          * 方法名称：directMaterialIsAutoMixer
          * 方法功能描述：到混合料的费用表中查询
          * 参数: 
          * 
          * 创建人：付中华
          * 创建时间：2009-04-10
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        private string directMaterialIsAutoMixer(directMaterialClass directMaterial)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select sum(number) from expenditure ");
            sqlStr.Append("where ekId=" + "'" + directMaterial.ekId + "'");
            sqlStr.Append(" and expenditureDepict=" + "'" + directMaterial.expenditureDepict + "'");
            sqlStr.Append(" and year=" + "'" + directMaterial.year + "'");
            sqlStr.Append(" and month=" + "'" + directMaterial.month + "'");
            sqlStr.Append(" and isAuto=" + 1);

            list.Add(sqlStr.ToString());

            DataTable dt = sqlHelper.QueryForDateSet(list).Tables[0];

            if (!dt.Rows[0][0].ToString().Equals(""))
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "-10000";
            }
        }
        /*
          * 方法名称：directMaterialIsAutoMixerDetach
          * 方法功能描述：到混合料待摊的费用表中查询
          * 参数: 
          * 
          * 创建人：付中华
          * 创建时间：2009-04-10
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        private string directMaterialIsAutoMixerDetach(directMaterialClass directMaterial)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select sum(number) from waitDetachExpenditure ");
            sqlStr.Append("where ekId=" + "'" + directMaterial.ekId + "'");
            sqlStr.Append(" and expenditureDepict=" + "'" + directMaterial.expenditureDepict + "'");
            sqlStr.Append(" and year=" + "'" + directMaterial.year + "'");
            sqlStr.Append(" and month=" + "'" + directMaterial.month + "'");
            sqlStr.Append(" and isAuto=" + 1);

            list.Add(sqlStr.ToString());

            DataTable dt = sqlHelper.QueryForDateSet(list).Tables[0];

            if (!dt.Rows[0][0].ToString().Equals(""))
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "-10000";
            }
        }
        /*
         * 方法名称：SelectBitumenStuff
         * 方法功能描述：取得沥青直接材料
         * 参数: 
         * 
         * 创建人：袁宇
         * 创建时间：2009-03-28
         *
         * 修改人：付中华
         * 修改时间：2009-4-10
         * 修改内容：
         *
         */
        public DataTable SelectBitumenStuff(string year,string month)
        {
            DataTable recDt = new DataTable();
            DataTable dt = new DataTable();
            bitumenCostCountDB bitumendb = new bitumenCostCountDB();

            //dt = SelectMixUseBitumen(year, month, "乳化沥青", "改性沥青");
            dt = this.getAutoDirectMaterialAlter(year, month, "乳化沥青", "改性沥青");
         
            recDt.Columns.Add("费用类别");
            recDt.Columns.Add("费用描述");
            recDt.Columns.Add("年份");
            recDt.Columns.Add("月份");
            recDt.Columns.Add("设备编号");
            recDt.Columns.Add("设备序号");
            recDt.Columns.Add("产品编号");
            recDt.Columns.Add("产品名称");
            recDt.Columns.Add("数量");
            recDt.Columns.Add("单价");
            recDt.Columns.Add("金额");
            recDt.Columns.Add("ekid");

            foreach (DataRow row in dt.Rows)
            {
                DataRow recRow = recDt.NewRow();
                recRow["费用类别"] = "直接材料费用";
                recRow["ekid"] = bitumendb.getExpenditureTypeId("直接材料费用").Rows[0][0];
                recRow["产品编号"] = row["pId"].ToString();
                recRow["产品名称"] = row["产品名称"].ToString() + row["产品规格"].ToString();
                recRow["年份"] = year;
                recRow["月份"] = month;
                recRow["费用描述"] = "自动归集:"+row["材料名称"].ToString() + "_" + row["材料规格"].ToString();
                recRow["设备编号"] = row["设备编号"].ToString();
                recRow["设备序号"] = row["设备序号"].ToString();
                
                //if (double.Parse(row["手动消耗量"].ToString())!= 0)
                //    recRow["数量"] = row["手动消耗量"].ToString();
                //else 
                //    recRow["数量"] = row["自动消耗量"].ToString();

                recRow["数量"] = row["数量"].ToString();
                if (row["单价"] != null)
                {
                    if (row["材料种类"].ToString() == "沥青")
                    {
                        double unitPrice = this.getBitumenHeatCost(year, month, Convert.ToInt64(row["pId"].ToString()));
                        recRow["单价"] = Convert.ToString(double.Parse(row["单价"].ToString()) + unitPrice);
                    }
                    else
                    { recRow["单价"] = row["单价"].ToString(); }
                }
                else
                {
                    recRow["单价"] = "0";
                }
                //  2009-4-10 付中华修改
                directMaterialClass directMaterial = new directMaterialClass();

                directMaterial.ekId = recRow["ekid"].ToString();
                directMaterial.eiId = recRow["设备序号"].ToString();
                directMaterial.expenditureDepict = recRow["费用描述"].ToString();
                directMaterial.year = recRow["年份"].ToString();
                directMaterial.month = recRow["月份"].ToString();

                string number;
                if ((recRow["产品名称"] != null) && (!recRow["产品名称"].Equals("")))
                {
                    // 到改性沥青表中查找匹配的信息
                     number = this.directMaterialIsAutoAlterBitumen(directMaterial);
                     if (number == "-10000")
                     { }
                     else
                     {
                         recRow["数量"] = Convert.ToString(double.Parse(recRow["数量"].ToString()) - double.Parse(number));
                     }
                }
                else
                {
                    // 到改性沥青分摊表中查找匹配的信息
                    number = this.directMaterialIsAutoAlterBitumenDetach(directMaterial);
                    if (number == "-10000")
                    { }
                    else
                    {
                        recRow["数量"] = Convert.ToString(double.Parse(recRow["数量"].ToString()) - double.Parse(number));
                    }
                }

                if ((!recRow["数量"].ToString().Equals("")) && (double.Parse(recRow["数量"].ToString())) > 0)
                {
                //单价这回可以直接取到了  见上面直接赋值出来的
                //recRow["单价"] = GetunitPrice(row["材料编号"].ToString(),year,month);
                
                try
                {
                    recRow["金额"] = Convert.ToString(double.Parse(recRow["数量"].ToString()) * double.Parse(recRow["单价"].ToString()));
                }
                catch
                {
                    recRow["金额"] = "0"; 
                }               
                    recDt.Rows.Add(recRow);
                }
                //  2009-4-10 付中华修改
            }
            return recDt;
        }
      
        /*
         * 方法名称：getAutoDirectMaterialAlter
         * 方法功能描述：此方法代替SelectMixUseBitumen方法  不用查询混合料消耗沥青的方法 直接到材料出库表中查询材料名称等于乳化沥青，改性沥青的
         * 参数: 
         * 
         * 创建人：付中华
         * 创建时间：2009-04-14
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataTable getAutoDirectMaterialAlter(string year, string month, string pName1, string pName2)
        {
            DataTable dt = new DataTable();
            LinkSelect linkS = new LinkSelect();
            linkS.TableNames.Add("materialOutDepot ");
            linkS.TableNames.Add("equipmentInformation ");
            linkS.LinkConds.Add("materialOutDepot.eiId=equipmentInformation.id");
            linkS.TableNames.Add("equipmentName");
            linkS.LinkConds.Add("equipmentInformation.enId=equipmentName.id");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("materialOutDepot.pId=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");
            linkS.TableNames.Add("productKind");
            linkS.LinkConds.Add("productName.pkId=productKind.id");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("materialOutDepot.mId=material.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnId=materialName.id");
            linkS.TableNames.Add("materialModel");
            linkS.LinkConds.Add("material.mmId=materialModel.id");
            linkS.TableNames.Add("materialKind");
            linkS.LinkConds.Add("materialName.mkId=materialKind.id");
            
            linkS.Viewfields.Add("materialOutDepot.pId as pId");
            linkS.Viewfields.Add("materialKind.sort as 材料种类");
            linkS.Viewfields.Add("materialName.name as 材料名称");
            linkS.Viewfields.Add("materialModel.model as 材料规格");
            linkS.Viewfields.Add("productName.name as 产品名称");
            linkS.Viewfields.Add("productModel.model as 产品规格");
            linkS.Viewfields.Add("equipmentInformation.no as 设备编号");
            linkS.Viewfields.Add("equipmentInformation.id as 设备序号");
            linkS.Viewfields.Add("equipmentName.name as 设备名称");            
            linkS.Viewfields.Add("materialOutDepot.number as 数量");
            linkS.Viewfields.Add("materialOutDepot.unitPrice as 单价 ");




            linkS.Conds.Add("productKind.sort=" + "'" + "沥青" + "'");
            linkS.Conds.Add("Year(materialOutDepot.inputDate)=" + "'" + year + "'");
            linkS.Conds.Add("Month(materialOutDepot.inputDate)=" + "'" + month + "'");
            linkS.Conds.Add("(productName.name =" + "'" + pName1 + "'" + " or " + "productName.name="+"'"+pName2 +"')");
            linkS.Conds.Add(" (not assessor is NULL)");
            linkS.Conds.Add("(not checkupMan is NULL)");
            linkS.Conds.Add("kindMark=" + 0);

            dt = linkS.LeftLinkOpen().Tables[0];

            return dt;

        }
        /*
* 方法名称：getBitumenHeatCost
* 方法功能描述：获取沥青加热成本 返回的是加热的单价
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-14
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public double getBitumenHeatCost(string year, string month, long pId)
        {
            CaleBitumenHeatCostLogic caleBitument = new CaleBitumenHeatCostLogic();
            CaleBitumenHeatCostClass conds = new CaleBitumenHeatCostClass();
            conds.YearDate = year;
            conds.MonthDate = month;

            DataTable dt = caleBitument.gatherBitumenHeatCostEquipLogic(conds);
            caleBitument.OneDataTable(dt, 1);
            // 以上是获得要显示的沥青加热成本的表
            double heatUnitPrice = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt64(dr["pId"].ToString()) == pId)
                {
                    heatUnitPrice = double.Parse(dr["unitPrice"].ToString());
                }
            }
            return heatUnitPrice;
          

        }

       

       

       


       



        /*
           * 方法名称：directMaterialIsAutoAlterBitumen
           * 方法功能描述：到改性沥青与乳化沥青的费用表中查询
           * 参数: 
           * 
           * 创建人：付中华
           * 创建时间：2009-04-10
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        private string directMaterialIsAutoAlterBitumen(directMaterialClass directMaterial)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select sum(number) from alterBitumenExpenditure ");
            sqlStr.Append("where ekId=" + "'" + directMaterial.ekId + "'");
            sqlStr.Append(" and expenditureDepict=" + "'" + directMaterial.expenditureDepict + "'");
            sqlStr.Append(" and year=" + "'" + directMaterial.year + "'");
            sqlStr.Append(" and month=" + "'" + directMaterial.month + "'");
            sqlStr.Append(" and isAuto=" + 1);

            list.Add(sqlStr.ToString());

            DataTable dt = sqlHelper.QueryForDateSet(list).Tables[0];

            if  (!dt.Rows[0][0].ToString().Equals(""))
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "-10000";
            }
        }
        /*
          * 方法名称：directMaterialIsAutoAlterBitumenDetach
          * 方法功能描述：到改性沥青与乳化沥青的分摊费用表中查询
          * 参数: 
          * 
          * 创建人：付中华
          * 创建时间：2009-04-10
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        private string directMaterialIsAutoAlterBitumenDetach(directMaterialClass directMaterial)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select sum(number) from alterBitumenWaitDetachExpenditure ");
            sqlStr.Append("where ekId=" + "'" + directMaterial.ekId + "'");
            sqlStr.Append(" and expenditureDepict=" + "'" + directMaterial.expenditureDepict + "'");
            sqlStr.Append(" and year=" + "'" + directMaterial.year + "'");
            sqlStr.Append(" and month=" + "'" + directMaterial.month + "'");
            sqlStr.Append(" and isAuto=" + 1);

            list.Add(sqlStr.ToString());

            DataTable dt = sqlHelper.QueryForDateSet(list).Tables[0];

            if ((dt.Rows[0][0] != null) && (!dt.Rows[0][0].Equals("")))
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "-10000";
            }
        }


        //取得材料单价
        //材料编号mId
        private string GetunitPrice(string mId, string year,string month)
        {
            ArrayList sqlStr = new ArrayList();

            sqlStr.Add("select * from stuffUnitPrice where mId=" + mId);
            sqlStr.Add(" and [year]=" + year);
            sqlStr.Add(" and [month]=" + month);

            DataTable dt = new DataTable();
            dt = sqlHelper.QueryForDateSet(sqlStr).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["unitPrice"].ToString();
            else
                return "";
            
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
            ArrayList arrayList = new ArrayList();
            string lSearchStr;

            lSearchStr = "select pl.pid ,pl.produceDate as 日期,mk.sort as 材料种类,mn.name as 材料名称,mm.model as 材料规格,m.id as 材料编号,ei.Id as 设备序号";
            lSearchStr = lSearchStr + ",Convert(varchar(10),CAST(pd.targetProportionValue/(select sum(targetProportionValue) ";
            lSearchStr = lSearchStr + "from targetProportionDetail where tpid=pd.tpid)*100 as decimal(38, 2)))+'%' as 配合比定额";
            lSearchStr = lSearchStr + ",pk.sort as 产品种类,pn.name as 产品名称,pm.model as 产品规格,ei.no as 设备编号,en.name as 设备名称";
            lSearchStr = lSearchStr + ",CAST(pl.quantity1*pd.targetProportionValue/(select sum(targetProportionValue)";
            lSearchStr = lSearchStr + " from targetProportionDetail ";
            lSearchStr = lSearchStr + " where tpid=pd.tpid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0)) as decimal(38, 2)) as 自动消耗量";
            lSearchStr = lSearchStr + " ,cast(pl.quantity2*pd.targetProportionValue/(select sum(targetProportionValue) ";
            lSearchStr = lSearchStr + " from targetProportionDetail ";
            lSearchStr = lSearchStr + " where tpid=pd.tpid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0))as decimal(38, 2)) as 手动消耗量 ";
            lSearchStr = lSearchStr + " from targetProportionDetail pd,mixtureProduceLog pl,product p,productKind pk,productName pn ,productModel pm,material m";
            lSearchStr = lSearchStr + " ,materialKind mk,materialName mn,materialModel mm,equipmentName en,equipmentInformation ei";
            lSearchStr = lSearchStr + " where pd.tpid=pl.tpid and pl.pid=p.id and p.pnid=pn.id and pn.pkId = pk.id and p.pmid=pm.id and pd.mid=m.id ";
            lSearchStr = lSearchStr + " and m.mnid=mn.id and mn.mkId = mk.id and m.mmid=mm.id and ei.enid=en.id and pl.eiid=ei.id ";

            if (!sqlWhere.Equals(""))
            {
                lSearchStr = lSearchStr + sqlWhere;
            }
            arrayList.Add(lSearchStr);


            //增加查询条件;
            arrayList.Add(" union all ");

            lSearchStr = "";
            lSearchStr = " select pl.pid,pl.produceDate 日期,mk.sort as 材料种类,mn.name as 材料名称,mm.model as 材料规格,m.id as 材料编号,ei.Id as 设备序号";
            lSearchStr = lSearchStr + " ,Convert(varchar(10),CAST(pd.proportionValue/(select sum(proportionValue) ";
            lSearchStr = lSearchStr + " from proportionDetail where pid=pd.pid)*100 as decimal(38, 2)))+'%' as 配合比定额";
            lSearchStr = lSearchStr + " ,pk.sort as 产品种类,pn.name as 产品名称,pm.model as 产品规格,ei.no as 设备编号,en.name as 设备名称";
            lSearchStr = lSearchStr + " ,CAST(pl.quantity1*pd.proportionValue/(select sum(proportionValue) ";
            lSearchStr = lSearchStr + " from proportionDetail  ";
            lSearchStr = lSearchStr + " where pid=pd.pid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0)) as decimal(38, 2)) as 自动消耗量";
            lSearchStr = lSearchStr + " ,cast(pl.quantity2*pd.proportionValue/(select sum(proportionValue) ";
            lSearchStr = lSearchStr + " from proportionDetail  ";
            lSearchStr = lSearchStr + " where pid=pd.pid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0))as decimal(38, 2)) as 手动消耗量";
            lSearchStr = lSearchStr + " from proportionDetail pd,emulsificationAsphaltumProduceLog pl,product p,productKind pk,productName pn";
            lSearchStr = lSearchStr + " ,productModel pm,material m,materialKind mk,materialName mn,materialModel mm,equipmentName en,equipmentInformation ei ";
            lSearchStr = lSearchStr + " where pd.pid=pl.pid and pl.pid2=p.id and p.pnid=pn.id and pn.pkId = pk.id and p.pmid=pm.id  ";
            lSearchStr = lSearchStr + " and pd.mid=m.id and m.mnid=mn.id and mn.mkId = mk.id and m.mmid=mm.id and ei.enid=en.id and pl.eiid=ei.id ";

            if (!sqlWhere.Equals(""))
            {
                lSearchStr = lSearchStr + sqlWhere;
            }

            arrayList.Add(lSearchStr);
            //增加查询条件;
            arrayList.Add(" union all ");

            lSearchStr = "";
            lSearchStr = " select pl.pid,pl.produceDate as 日期,mk.sort as 材料种类,mn.name as 材料名称,mm.model as 材料规格,m.id as 材料编号,ei.Id as 设备序号";
            lSearchStr = lSearchStr + " ,Convert(varchar(10),CAST(pd.proportionValue/(select sum(proportionValue) ";
            lSearchStr = lSearchStr + " from proportionDetail where pid=pd.pid)*100 as decimal(38, 2)))+'%' as 配合比定额";
            lSearchStr = lSearchStr + " ,pk.sort as 产品种类,pn.name as 产品名称,pm.model as 产品规格,ei.no as 设备编号,en.name as 设备名称";
            lSearchStr = lSearchStr + " ,CAST(pl.quantity1*pd.proportionValue/(select sum(proportionValue) ";
            lSearchStr = lSearchStr + " from proportionDetail  ";
            lSearchStr = lSearchStr + " where pid=pd.pid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0)) as decimal(38, 2)) as 自动消耗量";
            lSearchStr = lSearchStr + " ,cast(pl.quantity2*pd.proportionValue/(select sum(proportionValue) ";
            lSearchStr = lSearchStr + " from proportionDetail ";
            lSearchStr = lSearchStr + " where pid=pd.pid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0))as decimal(38, 2)) as 手动消耗量";
            lSearchStr = lSearchStr + " from proportionDetail pd,restructureAsphaltumProduceLog pl,product p,productKind pk,productName pn";
            lSearchStr = lSearchStr + " ,productModel pm,material m,materialKind mk,materialName mn,materialModel mm,equipmentName en,equipmentInformation ei ";
            lSearchStr = lSearchStr + " where pd.pid=pl.pid and pl.pid2=p.id and p.pnid=pn.id and pn.pkId = pk.id and p.pmid=pm.id and  ";
            lSearchStr = lSearchStr + " pd.mid=m.id and m.mnid=mn.id  and mn.mkId = mk.id and m.mmid=mm.id and ei.enid=en.id and pl.eiid=ei.id  ";

            if (!sqlWhere.Equals(""))
            {
                lSearchStr = lSearchStr + sqlWhere;
            }
            arrayList.Add(lSearchStr);

            return sqlHelper.QueryForDateSet(arrayList).Tables[0];
        }
        ////查询某类型产品出库信息
        //private DataTable SelectOutput(string productKind,string year, string month)
        //{
        //    LinkSelect linkS = new LinkSelect();

        //    linkS.TableNames.Add("consignmentNote");
        //    linkS.TableNames.Add("invoice");
        //    linkS.LinkConds.Add("consignmentNote.iId=invoice.id");
        //    linkS.TableNames.Add("product");
        //    linkS.LinkConds.Add("invoice.pid=product.id");
        //    linkS.TableNames.Add("productName");
        //    linkS.LinkConds.Add("product.pnid=productName.id");
        //    linkS.TableNames.Add("productModel");
        //    linkS.LinkConds.Add("product.pmid=productModel.id");
        //    linkS.TableNames.Add("productKind");
        //    linkS.LinkConds.Add("productName.pkId=productKind.id");
        //    linkS.TableNames.Add("sellContract");
        //    linkS.LinkConds.Add("invoice.scId=sellContract.id");
        //    linkS.TableNames.Add("voitureInfo");
        //    linkS.LinkConds.Add("consignmentNote.viId=voitureInfo.id");
        //    linkS.TableNames.Add("transportUnit");
        //    linkS.LinkConds.Add("voitureInfo.tuId=transportUnit.id");
        //    linkS.TableNames.Add("site site1");
        //    linkS.LinkConds.Add("consignmentNote.sId1=site1.id");
        //    linkS.TableNames.Add("site site2");
        //    linkS.LinkConds.Add("consignmentNote.sId2=site2.id");
        //    linkS.TableNames.Add("transportGoodsInformationCorresponding");
        //    linkS.LinkConds.Add("consignmentNote.tgicId=transportGoodsInformationCorresponding.id");
        //    linkS.TableNames.Add("transportContract");
        //    linkS.LinkConds.Add("transportGoodsInformationCorresponding.tcId=transportContract.id");
        //    linkS.TableNames.Add("equipmentInformation");
        //    linkS.LinkConds.Add("consignmentNote.eiId=equipmentInformation.id");
        //    linkS.TableNames.Add("projectName");
        //    linkS.LinkConds.Add("consignmentNote.pnId=projectName.id");
        //    linkS.TableNames.Add("equipmentModel");
        //    linkS.LinkConds.Add("equipmentInformation.emId=equipmentModel.id");
        //    linkS.TableNames.Add("equipmentName");
        //    linkS.LinkConds.Add("equipmentInformation.enId=equipmentName.id");
        //    //产品名称
        //    linkS.Viewfields.Add("productName.[name]");
        //    //产品型号
        //    linkS.Viewfields.Add("productModel.model");
        //    linkS.Viewfields.Add("consignmentNote.pid");
        //    //设备编号
        //    linkS.Viewfields.Add("consignmentNote.eiId");
        //    //净重
        //    linkS.Viewfields.Add("consignmentNote.suttle");
        //    //单价
        //    linkS.Viewfields.Add("invoice.unitPrice");
        //    //
        //    linkS.Conds.Add("productKind.sort=" + "'" + productKind + "'");
        //    linkS.Conds.Add("datepart(month,consignmentNote.inputDate))=" + "'" + month + "'");
        //    linkS.Conds.Add("datepart(year,consignmentNote.inputDate))=" + "'" + month + "'");
        //    return linkS.LeftLinkOpen().Tables[0]; 
 
        //}
        //查询混合料生产用沥青量
        //month 月份
        //mName 材料名称;
        private DataTable SelectMixUseBitumen(string year,string month,string mName)
        {
            string conds;

            conds = "and datepart(month,pl.produceDate) =" + "'" + month + "'";
            conds += " and datepart(year,pl.produceDate) =" + "'" + year + "'";
            conds += " and pk.sort=" + "'" + mName + "'";
            
            return MaterialOutSearch(conds); 
        }
        private DataTable SelectMixUseBitumen(string year, string month, string pName1,string pName2)
        {
            string conds;

            conds = "and datepart(month,pl.produceDate) =" + "'" + month + "'";
            conds += " and datepart(year,pl.produceDate) =" + "'" + year + "'";
            conds += " and (pn.name=" + "'" + pName1 + "' or pn.name=" + "'" + pName2 + "')";

            return MaterialOutSearch(conds);
        }
    }
    /*
    * 类名称：CostparameterDB
    * 类功能描述：产品工时参数设置
    *
    * 创建人：付中华
    * 创建时间：2009-03-19
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class CostparameterDB
    {
        //公共数据层实例
        SqlHelper sqlHelperObj = new SqlHelper();
        CostCountDB costcountDB = new CostCountDB();
        //多表查询类，左连接       
        /*
      * 方法名称：SelectProduceQuotiety
      * 方法功能描述：调出已经保存过的工时系数表
      * 参数: 
      * 
      * 创建人：付中华
      * 创建时间：2009-03-20
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataTable SelectProduceQuotiety()
        {
            LinkSelect linkS = new LinkSelect();
            linkS.TableNames.Add("product");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmid=productModel.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnid=productName.id");
            linkS.TableNames.Add("produceQuotiety");
            linkS.LinkConds.Add("produceQuotiety.pId=product.id");
            linkS.Viewfields.Add("product.id");
            linkS.Viewfields.Add("productName.name");
            linkS.Viewfields.Add("productModel.model");


            return linkS.LeftLinkOpen().Tables[0];

            //StringBuilder sqlStr = new StringBuilder();
            //ArrayList list = new ArrayList();

            //sqlStr.Append("SELECT produceQuotiety.pId,productName.name, productModel.model,produceQuotiety.quotiety,produceQuotiety.id");
            //sqlStr.Append(" FROM product ,produceQuotiety,productName,productModel ");
            //sqlStr.Append(" where produceQuotiety.pId=product.id and product.pnId = productName.id and ");
            //sqlStr.Append(" product.pmId = productModel.id");
            //list.Add(sqlStr.ToString());

            //return sqlHelperObj.QueryForDateSet(list).Tables[0];
        }
        public string InsertProduceQuotiety(produceQuotiety info)
        {
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            //ArrayList sqlStr = new ArrayList();

            fields.Add("pId");
            values.Add(info.pId.ToString());
            fields.Add("quotiety");
            values.Add(info.quotiety.ToString());
            if ((info.remark != null) && (!info.remark.Trim().Equals("")))
            {
                fields.Add("remark");
                values.Add("'" + info.remark + "'");
            }
            return costcountDB.InsertTable("produceQuotiety", fields, values);
            //sqlStr.Add(costcountDB.InsertTable("produceQuotiety", fields, values));
            //if (sqlHelperObj.Insert(sqlStr))
            //    return true;
            //else
            //    return false;

        }

        /*
       * 方法名称：updatePerProductHours
       * 方法功能描述：更新操作
       * 参数: 
       * 
       * 创建人：付中华
       * 创建时间：2009-03-22
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public string updatePerProductHours(produceQuotiety info)
        {
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            ArrayList cond = new ArrayList();
            //ArrayList sqlStr = new ArrayList();

            fields.Add("pId");
            values.Add(info.pId.ToString());
            fields.Add("quotiety");
            values.Add(info.quotiety.ToString());
            if ((info.remark != null) && (!info.remark.Trim().Equals("")))
            {
                fields.Add("remark");
                values.Add("'" + info.remark + "'");
            }
            cond.Add("pid=" + info.pId);
            return costcountDB.UpdateTeble("produceQuotiety", fields, values, cond);
            //sqlStr.Add(costcountDB.UpdateTeble("produceQuotiety", fields, values,cond));
            ////if (sqlHelperObj.Update(sqlStr))
            //    return true;
            //else
            //    return false;     

        }
        // 执行事务处理
        public bool Transact(ArrayList sqlStr)
        {
            if (sqlHelperObj.ExecuteTransaction(sqlStr))
                return true;
            else
                return false;

        }
        /*
  * 方法名称：isProductAdd
  * 方法功能描述：判断是否有新增的产品 传产品的id到工时系数表中的pId查找是否存在  是新增产品则返回true 不是新增产品返回false
  * 参数: 
  * 
  * 创建人：付中华
  * 创建时间：2009-03-22
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */
        public bool isProductAdd(long id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select pid from produceQuotiety where pid=" + id);
            list.Add(sqlStr.ToString());

            DataTable dt = sqlHelperObj.QueryForDateSet(list).Tables[0];
            if (dt.Rows.Count == 0)
                return true;
            else
                return false;
        }
        /*
  * 方法名称：
  * 方法功能描述：如果不是新增的产品在产品工时系数表中的数值查询出来 
  * 参数: 
  * 
  * 创建人：付中华
  * 创建时间：2009-03-23
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */
        public DataTable returnQuotiety(long id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select quotiety from produceQuotiety where pid=" + id);
            list.Add(sqlStr.ToString());

            return sqlHelperObj.QueryForDateSet(list).Tables[0];
        }
    }
    /*
    * 类名称：CostCountDetailDB
    * 类功能描述：成本核算中的combobox提值以及删除等方法
    *
    * 创建人：付中华
    * 创建时间：2009-03-26
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class CostCountDetailDB
    {
        //公共数据层实例
        SqlHelper sqlHelperObj = new SqlHelper();

        /*
     * 方法名称：distillProductNameDb
     * 方法功能描述：产品表中提取产品的名称及对应的id值
     * 参数: 
     * 
     * 创建人：付中华
     * 创建时间：2009-03-26
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataTable distillProductNameDb()
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("product");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.Viewfields.Add("product.pnId");
            linkS.Viewfields.Add("productName.name");

            return linkS.LeftLinkOpen().Tables[0];
        }
        /*
    * 方法名称：distillProductModeDb
    * 方法功能描述：产品名称定下来了取得产品的规格
    * 参数: 
    * 
    * 创建人：付中华
    * 创建时间：2009-03-26
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataTable distillProductModeDb(long pnId)
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("product");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");
            linkS.Viewfields.Add("product.pmId");
            linkS.Viewfields.Add("productModel.model");
            linkS.Conds.Add("product.pnId=" + pnId);

            return linkS.LeftLinkOpen().Tables[0];
        }
        /*
   * 方法名称：distillEquipmentNameDb
   * 方法功能描述：设备信息表中取出设备的名称以及id值
   * 参数: 
   * 
   * 创建人：付中华
   * 创建时间：2009-03-26
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        public DataTable distillEquipmentName()
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("equipmentInformation");
            linkS.TableNames.Add("equipmentName");
            linkS.LinkConds.Add("equipmentInformation.enId=equipmentName.id");
            linkS.Viewfields.Add("equipmentInformation.enId");
            linkS.Viewfields.Add("equipmentName.name");

            return linkS.LeftLinkOpen().Tables[0];
        }
        /*
  * 方法名称：distillEquipmentModelDb
  * 方法功能描述：设备名称定下来了取得设备的规格
  * 参数: 
  * 
  * 创建人：付中华
  * 创建时间：2009-03-26
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */
        public DataTable distillEquipmentModelDb(long enId)
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("equipmentInformation");
            linkS.TableNames.Add("equipmentModel");
            linkS.LinkConds.Add("equipmentInformation.emId=equipmentModel.id");
            linkS.Viewfields.Add("equipmentInformation.emId");
            linkS.Viewfields.Add("equipmentModel.model");
            linkS.Conds.Add("equipmentInformation.enId=" + enId);

            return linkS.LeftLinkOpen().Tables[0];
        }
        /*
 * 方法名称：
 * 方法功能描述：用于删除费用的方法
 * 参数: 
 * 
 * 创建人：付中华
 * 创建时间：2009-03-26
 *
 * 修改人：
 * 修改时间：
 * 修改内容：
 *
 */
        //public DataTable deleteShowTable(long id)
        //{
        //    StringBuilder sqlStr = new StringBuilder();
        //    ArrayList list = new ArrayList();

        //    sqlStr.Append("delete ")
        //}

    }

    /*
   * 类名称：bitumenCostCountDB
   * 类功能描述：
   *
   * 创建人：付中华
   * 创建时间：2009-03-30
   *
   * 修改人：
   * 修改时间：
   * 修改内容：  SqlHelper sqlHelperObj = new SqlHelper();
   *
   */
    class bitumenCostCountDB
    {
        SqlHelper sqlHelperObj = new SqlHelper();

        /*
* 方法名称：autoFuelDriveExpenditure
* 方法功能描述：自动获取燃料动力费的数据层方法 沥青加热自动获取中的方法
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-14
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable autoFuelDriveExpenditure(string year,string month)
        {
            DataTable dt = new DataTable();
            LinkSelect linkS = new LinkSelect();
            linkS.TableNames.Add("materialOutDepot ");
            linkS.TableNames.Add("equipmentInformation ");
            linkS.LinkConds.Add("materialOutDepot.eiId=equipmentInformation.id");
            linkS.TableNames.Add("equipmentName");
            linkS.LinkConds.Add("equipmentInformation.enId=equipmentName.id");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("materialOutDepot.pId=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");
            linkS.TableNames.Add("productKind");
            linkS.LinkConds.Add("productName.pkId=productKind.id");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("materialOutDepot.mId=material.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnId=materialName.id");
            linkS.TableNames.Add("materialModel");
            linkS.LinkConds.Add("material.mmId=materialModel.id");

            linkS.Viewfields.Add("Year(materialOutDepot.inputDate)");
            linkS.Viewfields.Add("Month(materialOutDepot.inputDate)");
            linkS.Viewfields.Add("equipmentInformation.no");
            linkS.Viewfields.Add("equipmentInformation.id");
            linkS.Viewfields.Add("productName.name ");
            linkS.Viewfields.Add("materialOutDepot.number");
            linkS.Viewfields.Add("materialOutDepot.unitPrice");
            
            linkS.Viewfields.Add("materialName.name");
            linkS.Viewfields.Add("materialModel.model");
            linkS.Viewfields.Add("materialOutDepot.pId");

            linkS.Conds.Add("productKind.sort=" + "'" + "沥青" + "'");
            linkS.Conds.Add("Year(materialOutDepot.inputDate)="+"'"+year+"'");
            linkS.Conds.Add("Month(materialOutDepot.inputDate)="+"'"+month+"'");
            linkS.Conds.Add(" (not assessor is NULL)");
            linkS.Conds.Add("(not checkupMan is NULL)");
            linkS.Conds.Add("kindMark=" + 1);

            dt = linkS.LeftLinkOpen().Tables[0];

            return dt;
        }

        /*
* 方法名称：isAutoBitumen
* 方法功能描述：查找直接人工费用在待摊费用表中是否已经存在了此方法对应的是沥青加热试验
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-09
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public string isAutoBitumen(directManEntityClass directManEntity)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select sum(money) from bitumenWaitDetachExpenditure ");
            sqlStr.Append("where ");
            sqlStr.Append(" ekId=" + "'" + directManEntity.ekId + "'");
            sqlStr.Append("  and expenditureDepict=" + "'" + directManEntity.expenditureDepict + "'");
            sqlStr.Append("  and year=" + "'" + directManEntity.yearDate + "'");
            sqlStr.Append("  and month=" + "'" + directManEntity.monthDate + "'");
            if((directManEntity.equipmentId!=null)&&(!directManEntity.equipmentId.Equals("")))
            { sqlStr.Append("  and eiId=" + "'" + directManEntity.equipmentId + "'"); }           

            sqlStr.Append(" and  isAuto=" + 1);           

            list.Add(sqlStr.ToString());

            DataTable dt = sqlHelperObj.QueryForDateSet(list).Tables[0];

            if (!dt.Rows[0][0].ToString().Equals(""))
            { return dt.Rows[0][0].ToString(); }
            else
            { return "-10000"; }                
        }
        /*
* 方法名称：isAutoAlterBitumen
* 方法功能描述：查找直接人工费用在待摊费用表中是否已经存在了此方法对应的是改性沥青和乳化沥青试验
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-10
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public string isAutoAlterBitumen(directManEntityClass directManEntity)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select sum(money) from alterBitumenWaitDetachExpenditure ");
            sqlStr.Append("where ");
            sqlStr.Append(" ekId=" + "'" + directManEntity.ekId + "'");
            sqlStr.Append("  and expenditureDepict=" + "'" + directManEntity.expenditureDepict + "'");
            sqlStr.Append("  and year=" + "'" + directManEntity.yearDate + "'");
            sqlStr.Append("  and month=" + "'" + directManEntity.monthDate + "'");
            if ((directManEntity.equipmentId != null) && (!directManEntity.equipmentId.Equals("")))
            { sqlStr.Append("  and eiId=" + "'" + directManEntity.equipmentId + "'"); }

            sqlStr.Append(" and  isAuto=" + 1);

            list.Add(sqlStr.ToString());

            DataTable dt = sqlHelperObj.QueryForDateSet(list).Tables[0];

            if (!dt.Rows[0][0].ToString().Equals(""))
            { return dt.Rows[0][0].ToString(); }
            else
            { return "-10000"; }
        }
        /*
* 方法名称：isAutoMixer
* 方法功能描述：查找直接人工费用在待摊费用表中是否已经存在了此方法对应的是混合料试验
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-10
*
* 修改人：
* 修改时间：
* 修改内容：
*x
*/
        public string isAutoMixer(directManEntityClass directManEntity)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select sum(money) from WaitDetachExpenditure ");
            sqlStr.Append("where ");
            sqlStr.Append(" ekId=" + "'" + directManEntity.ekId + "'");
            sqlStr.Append("  and expenditureDepict=" + "'" + directManEntity.expenditureDepict + "'");
            sqlStr.Append("  and year=" + "'" + directManEntity.yearDate + "'");
            sqlStr.Append("  and month=" + "'" + directManEntity.monthDate + "'");
            if ((directManEntity.equipmentId != null) && (!directManEntity.equipmentId.Equals("")))
            { sqlStr.Append("  and eiId=" + "'" + directManEntity.equipmentId + "'"); }

            sqlStr.Append(" and  isAuto=" + 1);

            list.Add(sqlStr.ToString());

            DataTable dt = sqlHelperObj.QueryForDateSet(list).Tables[0];

            if (!dt.Rows[0][0].ToString().Equals(""))
            { return dt.Rows[0][0].ToString(); }
            else
            { return "-10000"; }
        }
        /*
* 方法名称：getDirectPersonCost
* 方法功能描述：用于获取沥青费用中的直接人工费用方法
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-03-30
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable getDirectPersonCost(long id,int month,string year)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("  SELECT SUM(realIncome) AS TotalRealIncome ");
            sqlStr.Append(" FROM payOffGather ");
            sqlStr.Append(" WHERE (piId IN ");
            sqlStr.Append(" (SELECT id ");
            sqlStr.Append("  FROM personnelInfo ");
            sqlStr.Append(" WHERE (ptId = "+ id +"))) ");
            sqlStr.Append(" AND (MONTH(date) = "+month+") ");
            sqlStr.Append(" and (id in (select pogId from payOffGather2 where (not assessor is null) and (not checkupMan is null)))");
            sqlStr.Append(" and (Year(date)=" + "'" + year + "')");

            list.Add(sqlStr.ToString());

            return sqlHelperObj.QueryForDateSet(list).Tables[0];            
           
        }
        /*
* 方法名称：
* 方法功能描述：用于获取沥青费用中的直接人工费用根据生产班组的不通找到设备的编号和id
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-03-30
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable getEquipmentNoAndId(long id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" SELECT id, no");
            sqlStr.Append(" FROM equipmentInformation ");
            sqlStr.Append(" WHERE (id = ");
            sqlStr.Append(" (SELECT eiId ");
            sqlStr.Append(" FROM produceTeam");
            sqlStr.Append(" WHERE (id = "+id+"))) ");
            list.Add(sqlStr.ToString());

            return sqlHelperObj.QueryForDateSet(list).Tables[0];
   
        }
        /*
* 方法名称：
* 方法功能描述：根据费用类别名称获得费用类别的Id号码
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-03-30
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable getExpenditureTypeId(string expenditureType)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            if (expenditureType != "")
            {
                sqlStr.Append("select id as ekId from expenditureName where name=" + "'" + expenditureType + "'");
                list.Add(sqlStr.ToString());

                return sqlHelperObj.QueryForDateSet(list).Tables[0];
            }
            else
            {
                return null;
            }
        }
    }
    /*
     * 类名称：costDetachDB
     * 类功能描述： 成本分滩
     *
     * 创建人：袁宇
     * 创建时间：2009-03-30
     *
     * 修改人：
     * 修改时间：
     * 修改内容：  
     *
     */
    class costDetachDB
    {
        SqlHelper sqlHelperObj = new SqlHelper();

        public DataTable SelectbitumenDetachParameter(string year, string month,int formSort)
        {
            DataTable dt = new DataTable();                       
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("produceQuotiety");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("produceQuotiety.pId=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");
            linkS.TableNames.Add("productKind");
            linkS.LinkConds.Add("productName.pkId=productKind.id");
            linkS.Viewfields.Add("produceQuotiety.pId");
            linkS.Viewfields.Add("productName.name as 产品名称");
            linkS.Viewfields.Add("productModel.model as 产品型号");
            linkS.Viewfields.Add("produceQuotiety.quotiety as 分配系数");

            switch (formSort)
            { 
                case 1:
                    linkS.Conds.Add("productKind.sort="+"'"+"沥青"+"'");
                    linkS.Conds.Add("productName.name=" + "'" + "基质沥青" + "'"); 
                    break;
                case 2:
                    linkS.Conds.Add("productKind.sort=" + "'" + "沥青" + "'");
                    linkS.Conds.Add("productName.name=" + "'" + "改性沥青" + "'" + "or " + "productName.name=" + "'" + "乳化沥青" + "'");
                    break;
                case 3:
                    linkS.Conds.Add("productKind.sort=" + "'" + "混合料" + "'");
                    break;
            }
            dt = linkS.LeftLinkOpen().Tables[0];

            DataTable recDt = new DataTable();
            recDt.Columns.Add("pId");
            recDt.Columns.Add("设备编号");
            recDt.Columns.Add("产品名称");
            recDt.Columns.Add("产品型号");
            recDt.Columns.Add("分配系数");
            //recDt.Columns.Add("eiId");
            recDt.Columns.Add("产量");
            recDt.Columns.Add("工时");            

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable getDt1 = null;
                //沥青消耗量
                if (formSort == 1)
                    getDt1 = SelectBitumenConsumes(year, month, dt.Rows[i]["产品名称"].ToString(), dt.Rows[i]["产品型号"].ToString());
                else
                    getDt1 = SelectProductInDepot(year, month, dt.Rows[i]["产品名称"].ToString(), dt.Rows[i]["产品型号"].ToString());
                //if (formSort == 3)
                //    getDt1 = SelectMixConsume(year, month, dt.Rows[i]["产品名称"].ToString(), dt.Rows[i]["产品型号"].ToString());
                //else
                //    getDt1 = SelectBitumenConsumes(year, month, dt.Rows[i]["产品名称"].ToString(), dt.Rows[i]["产品型号"].ToString());


                for (int j = 0; j < getDt1.Rows.Count; j++)
                {
                    bool isHave = false;
                    for (int k = 0; k < recDt.Rows.Count; k++)
                    {
                        if ((recDt.Rows[k]["设备编号"].ToString().Trim().Equals(getDt1.Rows[j]["设备编号"].ToString().Trim())) &&
                            (recDt.Rows[k]["pid"].ToString().Trim().Equals(getDt1.Rows[j]["pid"].ToString().Trim())))
                        {
                            isHave = true;
                            recDt.Rows[k]["产量"] = StrtoDouble(recDt.Rows[k]["产量"].ToString())+StrtoDouble(getDt1.Rows[j]["数量"].ToString()).ToString();
                            //if (double.Parse(getDt1.Rows[j]["手动消耗量"].ToString()) != 0)
                            //    recDt.Rows[k]["产量"] = (StrtoDouble(recDt.Rows[k]["产量"].ToString()) + StrtoDouble(getDt1.Rows[j]["手动消耗量"].ToString()));
                            //else
                            //    recDt.Rows[k]["产量"] = (StrtoDouble(recDt.Rows[k]["产量"].ToString()) + StrtoDouble(getDt1.Rows[j]["自动消耗量"].ToString()));
                            recDt.Rows[k]["工时"] = StrtoDouble(recDt.Rows[k]["分配系数"].ToString()) * StrtoDouble(recDt.Rows[k]["产量"].ToString());

                            break;
                        }
                    }
                    if (!isHave)
                    {
                        DataRow row = recDt.NewRow();
                        row["pid"] = dt.Rows[i]["pid"].ToString();
                        row["产品名称"] = dt.Rows[i]["产品名称"].ToString();
                        row["产品型号"] = dt.Rows[i]["产品型号"].ToString();
                        row["分配系数"] = dt.Rows[i]["分配系数"].ToString();
                        //row["eiId"] = getDt1.Rows[j]["设备序号"].ToString();
                        row["设备编号"] = getDt1.Rows[j]["设备编号"].ToString();
                        row["产量"] = StrtoDouble(row["产量"].ToString()) + StrtoDouble(getDt1.Rows[j]["数量"].ToString()).ToString();
                        //if (double.Parse(getDt1.Rows[j]["手动消耗量"].ToString()) != 0)
                        //    row["产量"] = (StrtoDouble(row["产量"].ToString()) + StrtoDouble(getDt1.Rows[j]["手动消耗量"].ToString()));
                        //else
                        //    row["产量"] = (StrtoDouble(row["产量"].ToString()) + StrtoDouble(getDt1.Rows[j]["自动消耗量"].ToString()));
                        row["工时"] = StrtoDouble(row["分配系数"].ToString()) * StrtoDouble(row["产量"].ToString());
                        recDt.Rows.Add(row);
                    }

                }
                DataTable getDt = getDt = SelectBitumenOutInput(year, month, dt.Rows[i]["pId"].ToString());

                for (int j = 0; j < getDt.Rows.Count; j++)
                {
                    bool isHave = false;
                    for (int k = 0; k < recDt.Rows.Count; k++)
                    {
                        if ((recDt.Rows[k]["设备编号"].ToString().Trim().Equals(getDt.Rows[j]["设备编号"].ToString().Trim())) &&
                            (recDt.Rows[k]["pid"].ToString().Trim().Equals(dt.Rows[i]["pid"].ToString().Trim())))
                        {
                            isHave = true;
                            recDt.Rows[k]["产量"] = (StrtoDouble(recDt.Rows[k]["产量"].ToString()) + StrtoDouble(getDt.Rows[j]["sut"].ToString()));
                            recDt.Rows[k]["工时"] = StrtoDouble(recDt.Rows[k]["分配系数"].ToString()) * StrtoDouble(recDt.Rows[k]["产量"].ToString());
                            break;
                        }
                    }
                    if (!isHave)
                    {
                        DataRow row = recDt.NewRow();
                        row["pid"] = dt.Rows[i]["pid"].ToString();
                        row["产品名称"] = dt.Rows[i]["产品名称"].ToString();
                        row["产品型号"] = dt.Rows[i]["产品型号"].ToString();
                        row["分配系数"] = dt.Rows[i]["分配系数"].ToString();
                        //row["eiId"] = getDt.Rows[j][].ToString();
                        row["设备编号"] = getDt.Rows[j]["设备编号"].ToString();
                        row["产量"] = (StrtoDouble(row["产量"].ToString()) + StrtoDouble(getDt.Rows[j]["sut"].ToString()));
                        row["工时"] = StrtoDouble(row["分配系数"].ToString()) * StrtoDouble(row["产量"].ToString());
                        recDt.Rows.Add(row);
                    }
                }
            }
            return recDt;

        }       
        private DataTable SelectBitumenConsume(string year, string month,string name,string model)
        {
            string conds;
            StuffExpenditureDB stuffExpenditureDB = new StuffExpenditureDB();

            conds = "and datepart(month,pl.produceDate) =" + "'" + month + "'";
            conds += " and datepart(year,pl.produceDate) =" + "'" + year + "'";
            conds += " and mn.name=" + "'" + name + "'";
            conds += " and mm.model=" + "'" + model + "'";

            return stuffExpenditureDB.MaterialOutSearch(conds); 
        }
        private DataTable SelectBitumenConsumes(string year, string month, string name, string model)
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("materialOutDepot");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("materialOutDepot.pId=product.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("materialOutDepot.eiId=equipmentInformation.id");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("materialOutDepot.mId=material.id");
            linkS.TableNames.Add("materialModel");
            linkS.LinkConds.Add("material.mmId=materialModel.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnId=materialName.id");
            linkS.Viewfields.Add("equipmentInformation.[no] as 设备编号");
            linkS.Viewfields.Add("materialOutDepot.pId");
            linkS.Viewfields.Add("materialOutDepot.number as 数量");
            linkS.Conds.Add("materialName.[name]=" + "'" + name + "'");
            linkS.Conds.Add("materialModel.Model=" + "'" + model + "'");
            linkS.Conds.Add("datepart(month,materialOutDepot.inputDate) =" + "'" + month + "'");
            linkS.Conds.Add("datepart(year,materialOutDepot.inputDate) =" + "'" + year + "'");
            linkS.Conds.Add("not (materialOutDepot.assessor is NULL)");
            linkS.Conds.Add("not (materialOutDepot.checkupMan is NULL)");

            return linkS.LeftLinkOpen().Tables[0]; 
        }

        private DataTable SelectMixConsume(string year, string month, string name, string model)
        {
            string conds;
            StuffExpenditureDB stuffExpenditureDB = new StuffExpenditureDB();

            conds = "and datepart(month,pl.produceDate) =" + "'" + month + "'";
            conds += " and datepart(year,pl.produceDate) =" + "'" + year + "'";
            conds += " and pn.name=" + "'" + name + "'";
            conds += " and pm.model=" + "'" + model + "'";

            return stuffExpenditureDB.MaterialOutSearch(conds);
        }
        private DataTable SelectProductInDepot(string year, string month, string name, string model)
        {

            LinkSelect linkS = new LinkSelect();
            linkS.TableNames.Add("productInDepot");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("productInDepot.pId=product.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("productInDepot.eiId=equipmentInformation.id");            
            linkS.Viewfields.Add("equipmentInformation.[no] as 设备编号");
            linkS.Viewfields.Add("productInDepot.pId");
            linkS.Viewfields.Add("productInDepot.number as 数量");
            linkS.Conds.Add("productName.[name]=" + "'" + name + "'");
            linkS.Conds.Add("productModel.Model=" + "'" + model + "'");
            linkS.Conds.Add("datepart(month,productInDepot.inputDate) =" + "'" + month + "'");
            linkS.Conds.Add("datepart(year,productInDepot.inputDate) =" + "'" + year + "'");
            linkS.Conds.Add("not (productInDepot.assessor is NULL)");
            linkS.Conds.Add("not (productInDepot.checkupMan is NULL)");


            return linkS.LeftLinkOpen().Tables[0]; 
        }

        private DataTable SelectBitumenOutInput(string year, string month,string pId)
        {
            ArrayList sqlStr = new ArrayList();

            sqlStr.Add("select sum(suttle) as sut,equipmentInformation.[no] as 设备编号 ");
            sqlStr.Add("from consignmentNote LEFT OUTER JOIN invoice");
            sqlStr.Add(" ON consignmentNote.iId = invoice.id");
            sqlStr.Add(" LEFT OUTER JOIN equipmentInformation");
            sqlStr.Add(" ON consignmentNote.eiId = equipmentInformation.id");
            sqlStr.Add(" where 1=1 ");
            sqlStr.Add(" and datepart(year,consignmentNote.inputDate)=" + "'" + year + "'");
            sqlStr.Add(" and datepart(month,consignmentNote.inputDate)=" + "'" + month + "'");
            sqlStr.Add(" and invoice.pId=" + pId);

            sqlStr.Add("group by equipmentInformation.[no]");

            return sqlHelperObj.QueryForDateSet(sqlStr).Tables[0];

            //LinkSelect linkS = new LinkSelect();

            //linkS.TableNames.Add("consignmentNote");
            //linkS.TableNames.Add("invoice");            
            //linkS.LinkConds.Add("consignmentNote.iId=invoice.id");
            //linkS.Viewfields.Add("sum(suttle) as sut");
            //linkS.Conds.Add("datepart(year,consignmentNote.inputDate)=" + "'" + year + "'");
            //linkS.Conds.Add("datepart(month,consignmentNote.inputDate)=" + "'" + month + "'");
            //linkS.Conds.Add("invoice.pId="+pId);

            //return linkS.LeftLinkOpen().Tables[0];       
        }
        private double StrtoDouble(string str)
        {
            if (!str.Trim().Equals(""))
            {
                try
                {
                    return Double.Parse(str);
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }
        
    }
    /*
    * 类名称：CaleBitumenHeatCostDb
    * 类功能描述： 计算单位成本
    *
    * 创建人：付中华
    * 创建时间：2009-04-01
    *
    * 修改人：
    * 修改时间：
    * 修改内容：  
    *
    */
    class CaleBitumenHeatCostDb
    {
        // 写到数据层里面的 
        SqlHelper sqlHelpObj = new SqlHelper();

        /*
* 方法名称：gatherBitumenHeatCost
* 方法功能描述：计算沥青加热成本
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-01
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable gatherBitumenHeatCost(string year, string month)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" SELECT SUM(bitumenExpenditure.money) AS money, bitumenExpenditure.pId, ");
            sqlStr.Append(" productName.name, productModel.model, ");
            sqlStr.Append(" bitumenExpenditure.year, bitumenExpenditure.month ");
            sqlStr.Append(" FROM bitumenExpenditure INNER JOIN ");
            sqlStr.Append(" product ON bitumenExpenditure.pId = product.id INNER JOIN ");
            sqlStr.Append(" productName ON product.pnId = productName.id INNER JOIN ");
            sqlStr.Append(" productModel ON product.pmId = productModel.id ");
            sqlStr.Append(" WHERE (bitumenExpenditure.year = " + year + ") ");
            sqlStr.Append(" AND (bitumenExpenditure.month =" + month + ") ");
            sqlStr.Append(" GROUP BY bitumenExpenditure.pId, productName.name, productModel.model, ");
            sqlStr.Append(" bitumenExpenditure.year, bitumenExpenditure.month ");
            list.Add(sqlStr.ToString());

            return sqlHelpObj.QueryForDateSet(list).Tables[0];
        }
        /*
* 方法名称：gatherAlterBitumenCost
* 方法功能描述：计算改性沥青和乳化沥青加热成本
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-01
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable gatherAlterBitumenCost(string year, string month)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" SELECT SUM(alterBitumenExpenditure.money) AS money, alterBitumenExpenditure.pId, ");
            sqlStr.Append(" productName.name, productModel.model, ");
            sqlStr.Append(" alterBitumenExpenditure.year, alterBitumenExpenditure.month ");
            sqlStr.Append(" FROM alterBitumenExpenditure INNER JOIN ");
            sqlStr.Append(" product ON alterBitumenExpenditure.pId = product.id INNER JOIN ");
            sqlStr.Append(" productName ON product.pnId = productName.id INNER JOIN ");
            sqlStr.Append(" productModel ON product.pmId = productModel.id ");
            sqlStr.Append(" WHERE (alterBitumenExpenditure.year = " + year + ") ");
            sqlStr.Append(" AND (alterBitumenExpenditure.month =" + month + ") ");
            sqlStr.Append(" GROUP BY alterBitumenExpenditure.pId, productName.name, productModel.model, ");
            sqlStr.Append(" alterBitumenExpenditure.year, alterBitumenExpenditure.month ");
            list.Add(sqlStr.ToString());

            return sqlHelpObj.QueryForDateSet(list).Tables[0];
        }
        /*
* 方法名称：gatherMixCost
* 方法功能描述：计算混合料加热成本
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-01
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/

        public DataTable gatherMixCost(string year, string month)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" SELECT SUM(Expenditure.money) AS money, Expenditure.pId, ");
            sqlStr.Append(" productName.name, productModel.model, ");
            sqlStr.Append(" Expenditure.year, Expenditure.month ");
            sqlStr.Append(" FROM Expenditure INNER JOIN ");
            sqlStr.Append(" product ON Expenditure.pId = product.id INNER JOIN ");
            sqlStr.Append(" productName ON product.pnId = productName.id INNER JOIN ");
            sqlStr.Append(" productModel ON product.pmId = productModel.id ");
            sqlStr.Append(" WHERE (Expenditure.year = " + year + ") ");
            sqlStr.Append(" AND (Expenditure.month =" + month + ") ");
            sqlStr.Append(" GROUP BY Expenditure.pId, productName.name, productModel.model, ");
            sqlStr.Append(" Expenditure.year, Expenditure.month ");
            list.Add(sqlStr.ToString());

            return sqlHelpObj.QueryForDateSet(list).Tables[0];
        }
        /*
* 方法名称：gatherBitumenHeatCostEquip
* 方法功能描述：计算沥青单位成本的方法 其中根据需求的变化添加了按设备归集的条件
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-02
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable gatherBitumenHeatCostEquip(CaleBitumenHeatCostClass conds)
        {
            LinkSelect linkS = new LinkSelect();
            DataTable dt = new DataTable();

            linkS.TableNames.Add("bitumenExpenditure");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("bitumenExpenditure.pId=product.id");
            linkS.TableNames.Add("productName ");
            linkS.TableNames.Add("productModel ");
            linkS.LinkConds.Add("product.pnId =productName.id");
            linkS.LinkConds.Add("product.pmId=productModel.id");
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("bitumenExpenditure.eiId=equipmentInformation.id");

            // 选中按设备归集
            if (conds.Equipment == "1")
            {
                linkS.Viewfields.Add(" equipmentInformation.no as equipmentNo");
            }
            linkS.Viewfields.Add(" productName.name");
            linkS.Viewfields.Add(" productModel.model");
            linkS.Viewfields.Add(" bitumenExpenditure.year");
            linkS.Viewfields.Add(" bitumenExpenditure.month");
            linkS.Viewfields.Add(" SUM(bitumenExpenditure.money) AS money");
            linkS.Viewfields.Add(" bitumenExpenditure.pId");           
                       

            if ((conds.YearDate != null) && (!conds.YearDate.Trim().Equals("")))
            {
                linkS.Conds.Add("bitumenExpenditure.year=" + "'" + conds.YearDate.Trim() + "'");
            }
            if ((conds.MonthDate != null) && (!conds.MonthDate.Trim().Equals("")))
            {
                linkS.Conds.Add("bitumenExpenditure.month=" + "'" + conds.MonthDate.Trim() + "'");
            }
            if ((conds.StartDate != null) && (!conds.StartDate.Trim().Equals("")))
            {
                linkS.Conds.Add("bitumenExpenditure.inputDate>=" + "'" + conds.StartDate.Trim() + "'");
            }
            if ((conds.EndDate != null) && (!conds.EndDate.Trim().Equals("")))
            {
                linkS.Conds.Add("bitumenExpenditure.inputDate<=" + "'" + conds.EndDate.Trim() + "'");
            }
            linkS.Conds.Add("not (bitumenExpenditure.pid is NULL) ");

            if (conds.Equipment == "1")
            {
                linkS.GroupBy = " GROUP BY bitumenExpenditure.eiId, bitumenExpenditure.pId, productName.name, productModel.model,bitumenExpenditure.year, bitumenExpenditure.month,equipmentInformation.no";
            }
            else
            {
                linkS.GroupBy = "GROUP BY bitumenExpenditure.pId, productName.name, productModel.model,  bitumenExpenditure.year, bitumenExpenditure.month ";
            }

            dt = linkS.LeftLinkOpen().Tables[0];

            return dt;
        }
        /*
* 方法名称：gatherMixCostEquip
* 方法功能描述：计算混合料单位成本的方法 其中根据需求的变化添加了按设备归集的条件
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-02
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable gatherMixCostEquip(CaleBitumenHeatCostClass conds)
        {
            LinkSelect linkS = new LinkSelect();
            DataTable dt = new DataTable();

            linkS.TableNames.Add("Expenditure");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("Expenditure.pId=product.id");
            linkS.TableNames.Add("productName ");
            linkS.TableNames.Add("productModel ");
            linkS.LinkConds.Add("product.pnId =productName.id");
            linkS.LinkConds.Add("product.pmId=productModel.id");
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("Expenditure.eiId=equipmentInformation.id");

            // 选中按设备归集
            if (conds.Equipment == "1")
            {
                linkS.Viewfields.Add(" equipmentInformation.no as equipmentNo");
            }
            linkS.Viewfields.Add(" productName.name");
            linkS.Viewfields.Add(" productModel.model");
            linkS.Viewfields.Add(" expenditure.year");
            linkS.Viewfields.Add(" expenditure.month");
            linkS.Viewfields.Add(" SUM(expenditure.money) AS money");
            linkS.Viewfields.Add(" expenditure.pId");
            
            

            if ((conds.YearDate != null) && (!conds.YearDate.Trim().Equals("")))
            {
                linkS.Conds.Add("expenditure.year=" + "'" + conds.YearDate.Trim() + "'");
            }
            if ((conds.MonthDate != null) && (!conds.MonthDate.Trim().Equals("")))
            {
                linkS.Conds.Add("expenditure.month=" + "'" + conds.MonthDate.Trim() + "'");
            }
            if ((conds.StartDate != null) && (!conds.StartDate.Trim().Equals("")))
            {
                linkS.Conds.Add("expenditure.inputDate>=" + "'" + conds.StartDate.Trim() + "'");
            }
            if ((conds.EndDate != null) && (!conds.EndDate.Trim().Equals("")))
            {
                linkS.Conds.Add("expenditure.inputDate<=" + "'" + conds.EndDate.Trim() + "'");
            }
            linkS.Conds.Add("not (expenditure.pid is NULL) ");
            if (conds.Equipment == "1")
            {
                linkS.GroupBy = " GROUP BY expenditure.eiId, expenditure.pId, productName.name, productModel.model,expenditure.year, expenditure.month,equipmentInformation.no";
            }
            else
            {
                linkS.GroupBy = "GROUP BY Expenditure.pId, productName.name, productModel.model,  Expenditure.year, Expenditure.month ";
            }

            dt = linkS.LeftLinkOpen().Tables[0];

            return dt;
        }
        /*
* 方法名称：gatherAlterBitumenCostEquip
* 方法功能描述：计算改性沥青和乳化沥青加热单位成本
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-02
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable gatherAlterBitumenCostEquip(CaleBitumenHeatCostClass conds)
        {
            LinkSelect linkS = new LinkSelect();
            DataTable dt = new DataTable();

            linkS.TableNames.Add("alterBitumenExpenditure");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("alterBitumenExpenditure.pId=product.id");
            linkS.TableNames.Add("productName ");
            linkS.TableNames.Add("productModel ");
            linkS.LinkConds.Add("product.pnId =productName.id");
            linkS.LinkConds.Add("product.pmId=productModel.id");
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("alterBitumenExpenditure.eiId=equipmentInformation.id");

            // 选中按设备归集
            if (conds.Equipment == "1")
            {
                linkS.Viewfields.Add(" equipmentInformation.no as equipmentNo");
            }
            linkS.Viewfields.Add(" productName.name");
            linkS.Viewfields.Add(" productModel.model");
            linkS.Viewfields.Add(" alterBitumenExpenditure.year");
            linkS.Viewfields.Add(" alterBitumenExpenditure.month");
            linkS.Viewfields.Add(" SUM(alterBitumenExpenditure.money) AS money");
            linkS.Viewfields.Add(" alterBitumenExpenditure.pId");
            
           

            if ((conds.YearDate != null) && (!conds.YearDate.Trim().Equals("")))
            {
                linkS.Conds.Add("alterBitumenExpenditure.year=" + "'" + conds.YearDate.Trim() + "'");
            }
            if ((conds.MonthDate != null) && (!conds.MonthDate.Trim().Equals("")))
            {
                linkS.Conds.Add("alterBitumenExpenditure.month=" + "'" + conds.MonthDate.Trim() + "'");
            }
            if ((conds.StartDate != null) && (!conds.StartDate.Trim().Equals("")))
            {
                linkS.Conds.Add("alterBitumenExpenditure.inputDate>=" + "'" + conds.StartDate.Trim() + "'");
            }
            if ((conds.EndDate != null) && (!conds.EndDate.Trim().Equals("")))
            {
                linkS.Conds.Add("alterBitumenExpenditure.inputDate<=" + "'" + conds.EndDate.Trim() + "'");
            }
            linkS.Conds.Add("not (alterBitumenExpenditure.pid is NULL) ");

            if (conds.Equipment == "1")
            {
                linkS.GroupBy = " GROUP BY alterBitumenExpenditure.eiId, alterBitumenExpenditure.pId, productName.name, productModel.model,alterBitumenExpenditure.year, alterBitumenExpenditure.month,equipmentInformation.no";
            }
            else
            {
                linkS.GroupBy = "GROUP BY alterBitumenExpenditure.pId, productName.name, productModel.model,  alterBitumenExpenditure.year, alterBitumenExpenditure.month ";
            }

            dt = linkS.LeftLinkOpen().Tables[0];

            return dt;
        }
    }


}



   
   
    
        
   

