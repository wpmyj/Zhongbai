/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：StockDB.cs
     * 文件功能描述：采购数据层
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
using DasherStation.common;
using System.Data;
using System.Collections;
using DasherStation.system;
using System.Data.SqlClient;

namespace DasherStation.stock
{
    class StockDB
    {

    }
    //采购计划类
    public class stockPlanDb
    {
        DataSet ds = new DataSet();
        SqlHelper sqlHelper = new SqlHelper();
        ArrayList list = new ArrayList();
        //向采购计划表中插入数据
        public string insertStockPlan(StockPlanClass stockPlan)
        {
            StringBuilder sqlStr = new StringBuilder();
            //审核审批人先不进行插入处理assessor,checkupMan
            sqlStr.Append("insert into stockPlan(inputDate,inputMan,producer,");
            sqlStr.Append("planYear,remark)");
            sqlStr.Append("values(");
            sqlStr.Append("" + "Getdate()" + "," + "'" + stockPlan.inputMan + "'" + ",");
            sqlStr.Append("" + "'" + stockPlan.producer + "'" + ",");
            sqlStr.Append("" + "'" + stockPlan.planYear + "'" + ",");
            sqlStr.Append("" + "'" + stockPlan.remark + "'");
            sqlStr.Append(")");
            sqlStr.Append(";declare @spId int");
            sqlStr.Append(";set @spId=@@IDENTITY;");
            

            return sqlStr.ToString();
        }
        //按年份查询方法
        public DataSet compareYear(int startyear, int endyear)
        {
            string SqlStr;

            SqlStr = "select id,inputDate, year(planYear) as planYear, producer, assessor, checkupMan, remark";
            SqlStr = SqlStr + " from stockPlan where (year(planYear)>=" + startyear + ")" + "and (year(planYear)<=" + endyear + ")";
            SqlStr = SqlStr + "order by planYear asc";


            ArrayList list = new ArrayList();
            list.Add(SqlStr);
            return sqlHelper.QueryForDateSet(list);
        }
        //采购计划的主界面上的主表信息查询
        public DataTable prochaseSchemain()
        {
            string SqlStr;

            SqlStr = "SELECT id, inputDate, producer, assessor, checkupMan, Year(planYear) as planYear, remark FROM stockPlan";


            ArrayList list = new ArrayList();
            list.Add(SqlStr);
            return sqlHelper.QueryForDateSet(list).Tables[0];

        }
        #region//删除年度采购计划其相应的明细信息也将被删除
        public bool stockPlanDelete(int id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            bool deletestatus;

            sqlStr.Append("delete from stockPlanDetail where spId=" + id + ";");
            sqlStr.Append(" " + "delete from stockPlan where id=" + id);
            list.Add(sqlStr.ToString());

            deletestatus = sqlHelper.Delete(list);

            return deletestatus;

        }
        #endregion
        
    }
    //采购计划明细类
    public class purchaseSchedetailDb
    {
        DataSet ds = new DataSet();
        DataTable dtable = new DataTable();
        SqlHelper sqlHelper = new SqlHelper();
        ArrayList list = new ArrayList();
        #region //获得材料表中的信息主要是mmid,mnid,id
        public MaterialClass queryObj(string SqlStr)
        {
            try
            {
                MaterialClass materialmodel = new MaterialClass();
                ArrayList list = new ArrayList();
                list.Add(SqlStr);
                DataSet ds = sqlHelper.QueryForDateSet(list);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                    {
                        materialmodel.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["mnId"].ToString() != "")
                    {
                        materialmodel.mnId = int.Parse(ds.Tables[0].Rows[0]["mnId"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["mmId"].ToString() != "")
                    {
                        materialmodel.mmId = int.Parse(ds.Tables[0].Rows[0]["mmId"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["inputDate"].ToString() != "")
                    {
                        materialmodel.inputDate = DateTime.Parse(ds.Tables[0].Rows[0]["inputDate"].ToString());
                    }
                    materialmodel.inputMan = ds.Tables[0].Rows[0]["inputMan"].ToString();
                    materialmodel.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                    materialmodel.density = ds.Tables[0].Rows[0]["density"].ToString();
                    return materialmodel;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
        #endregion 
        }
        #region//初始化制作人
        public DataTable makerCombobox()
        {
            string SqlStr;

            SqlStr = "select id,name from usersInfo";
            ArrayList list = new ArrayList();
            list.Add(SqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        #endregion 
        #region//初始化材料种类名称规格      
        //查询材料总类
        public DataTable materialKind()
        {
            string SqlStr;

            SqlStr = "SELECT id, sort FROM materialKind";
            ArrayList list = new ArrayList();
            list.Add(SqlStr);
            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        //种类选中后传过来它的id值对应查出材料的名称
        public DataTable materialName(int kindId)
        {
            string SqlStr;

            SqlStr = "SELECT id, name, mkId FROM materialName";
            SqlStr = SqlStr + " where mkId=" + kindId;
            ArrayList list = new ArrayList();
            list.Add(SqlStr);
            return sqlHelper.QueryForDateSet(list).Tables[0]; 
        }
        public DataTable materialName(int kindId,int providerId)
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("providerMaterialCorresponding");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("providerMaterialCorresponding.mid=material.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnid=materialName.id");
            linkS.TableNames.Add("materialKind");
            linkS.LinkConds.Add("materialName.mkId=materialKind.id");
            linkS.Viewfields.Add("distinct materialName.id");
            //linkS.Viewfields.Add("materialKind.sort");
            linkS.Viewfields.Add("materialName.name");
            //linkS.Viewfields.Add("materialName.mkId");
            linkS.Conds.Add("materialKind.id=" + kindId.ToString());
            if (providerId != null)
                linkS.Conds.Add("providerMaterialCorresponding.piid=" + providerId.ToString());
            return linkS.LeftLinkOpen().Tables[0];


            //string SqlStr;

            //SqlStr = "SELECT id, name, mkId FROM materialName";
            //SqlStr = SqlStr + " where mkId=" + kindId;
            //ArrayList list = new ArrayList();
            //list.Add(SqlStr);
            //return sqlHelper.QueryForDateSet(list).Tables[0];

        }
        public DataTable materialModel(int nameId)
        {
            string SqlStr;

            SqlStr = "select mnmc.mnid,mnmc.mmid,mm.id,mm.model";
            SqlStr = SqlStr + " from material mnmc,materialModel mm ";
            SqlStr = SqlStr + " where (mnmc.mmid=mm.id) and (mnmc.mnid=" + nameId + ")";
            ArrayList list = new ArrayList();
            list.Add(SqlStr);
            return sqlHelper.QueryForDateSet(list).Tables[0]; 
        }
        //种类和名称定出来了查询材料的规格型号 要在材料种类名称规格反查出来材料的规格型号
        public DataTable materialModel(int nameId, int providerId)
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("providerMaterialCorresponding");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("providerMaterialCorresponding.mid=material.id");
            linkS.TableNames.Add("materialModel");
            linkS.LinkConds.Add("material.mmid=materialModel.id");
            //linkS.Viewfields.Add("material.mnid");
            //linkS.Viewfields.Add("material.mmid");
            linkS.Viewfields.Add("distinct materialModel.id");
            linkS.Viewfields.Add("materialModel.model");
            linkS.Conds.Add("material.mnid=" + nameId.ToString());
            if (providerId != null)
                linkS.Conds.Add("providerMaterialCorresponding.piid=" + providerId.ToString());
            return linkS.LeftLinkOpen().Tables[0];

            //string SqlStr;

            //SqlStr = "select mnmc.mnid,mnmc.mmid,mm.id,mm.model";
            //SqlStr = SqlStr + " from material mnmc,materialModel mm ";
            //SqlStr = SqlStr + " where (mnmc.mmid=mm.id) and (mnmc.mnid=" + nameId + ")";
            //ArrayList list = new ArrayList();
            //list.Add(SqlStr);
            //return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        #endregion
        //向采购计划明细表中插入数据
        //public string insertStockPlanDetail(StockPlanDetailClass stockPlanDetail)
        public string insertStockPlanDetail(StockPlanDetailClass stockPlanDetail)
        {
            StringBuilder sqlStr = new StringBuilder();

            sqlStr.Append("insert into stockPlanDetail(mId,spId,quantity,january,february,march,april,may,june,");
            sqlStr.Append("july,august,september,october,november,december,inputDate");
            sqlStr.Append(")");
            sqlStr.Append("values(" + stockPlanDetail.mId + ",");
            sqlStr.Append("@spId" + ",");
            #region//处理数值型的空
            if (stockPlanDetail.quantity.ToString() != null)
            {
                sqlStr.Append("" + stockPlanDetail.quantity + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (stockPlanDetail.january.ToString() != "")
            {
                sqlStr.Append("" + stockPlanDetail.january + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (stockPlanDetail.february.ToString() !="")
            {
                sqlStr.Append("" + stockPlanDetail.february + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (stockPlanDetail.march.ToString() != "")
            {
                sqlStr.Append("" + stockPlanDetail.march + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (stockPlanDetail.april.ToString() != "")
            {
                sqlStr.Append("" + stockPlanDetail.april + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (stockPlanDetail.may.ToString() != "")
            {
                sqlStr.Append("" + stockPlanDetail.may + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (stockPlanDetail.june.ToString() != "")
            {
                sqlStr.Append("" + stockPlanDetail.june + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (stockPlanDetail.july.ToString() != "")
            {
                sqlStr.Append("" + stockPlanDetail.july + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (stockPlanDetail.august.ToString() != "")
            {
                sqlStr.Append("" + stockPlanDetail.august + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (stockPlanDetail.september.ToString() != "")
            {
                sqlStr.Append("" + stockPlanDetail.september + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (stockPlanDetail.october.ToString() != "")
            {
                sqlStr.Append("" + stockPlanDetail.october + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (stockPlanDetail.november.ToString() != "")
            {
                sqlStr.Append("" + stockPlanDetail.november + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            if (stockPlanDetail.december.ToString() != "")
            {
                sqlStr.Append("" + stockPlanDetail.december + ",");
            }
            else
            {
                sqlStr.Append("null,");
            }
            #endregion       
            sqlStr.Append("Getdate()");
            sqlStr.Append(")");
           

            return sqlStr.ToString();
           
        }
        //采购计划主界面上的明细信息
        //采购计划主界面上的明细表
        public DataTable prochaseSchedetail(int stockplanId)
        {
            #region//采购计划选中相应的选出对应的明细表信息
            string SqlStr;          

            SqlStr = "select mK.sort,mN.name,mM.model,spd.january,spd.february,spd.march,spd.april,spd.may,";
            SqlStr = SqlStr + "spd.june,spd.july,spd.august,spd.september,spd.october,spd.november,spd.december,spd.quantity,";
            SqlStr = SqlStr + "M.id as id1,mN.id as id2,mM.id as id3,mK.id as id4,mN.mkId,M.mnId,M.mmId,spd.mId,spd.spId";
            SqlStr = SqlStr + " from materialKind mK,materialName mN,materialModel mM,material M,stockPlanDetail spd";
            SqlStr = SqlStr + " where (mK.id=mN.mkId) and (mN.id=M.mnId) and (M.mmId=mM.id) and (M.id=spd.mId) ";
            SqlStr = SqlStr + "and (spd.spId=" + stockplanId + ")";

            ArrayList list = new ArrayList();
            list.Add(SqlStr);
            return sqlHelper.QueryForDateSet(list).Tables[0];
            #endregion
        }

        /*
         * 方法名称：findMinStockAndId
         * 方法功能描述：根据材料名称和材料规格查找最小库存量
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
        public DataTable findMinStockAndId(long mnId, long mmId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" SELECT id, nadirStock");
            sqlStr.Append(" FROM material");
            sqlStr.Append(" WHERE (mnId = "+mnId+")");
            sqlStr.Append(" AND (mmId = "+mmId+")");
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        /*
        * 方法名称：findNowStock
        * 方法功能描述：根据材料名称和材料规格查找到的id值对应库存列表中的mId取出现有库存量
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
        public string findNowStock(long id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("SELECT quantity1,quantity2 ");
            sqlStr.Append(" FROM materialStockList ");
            sqlStr.Append(" WHERE mId =" + id);
            list.Add(sqlStr.ToString());

            DataTable dt = sqlHelper.QueryForDateSet(list).Tables[0];
            if (dt.Rows.Count != 0)
            {
                if ((dt.Rows[0][0].ToString() != "") && (dt.Rows[0][1].ToString() != ""))
                {
                    return dt.Rows[0][1].ToString();
                }
                else
                {
                    return dt.Rows[0][0].ToString();
                }
            }
            else
            {
                return "";
            }
        }
        /*
       * 方法名称：materialNeedPlanShow
       * 方法功能描述：分类统计出材料需求计划表中的内容
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
        //public DataTable materialNeedPlanShow(string year)
        //{
        //    StringBuilder sqlStr = new StringBuilder();
        //    ArrayList list = new ArrayList();

        //    sqlStr.Append(" SELECT materialNeedPlan.mId,materialKind.sort, materialName.name, materialModel.model, ");
        //    sqlStr.Append(" SUM(materialNeedPlan.quantity) AS quantity, SUM(materialNeedPlan.january) AS january,");
        //    sqlStr.Append(" SUM(materialNeedPlan.february) AS february, ");
        //    sqlStr.Append(" SUM(materialNeedPlan.march) AS march, SUM(materialNeedPlan.april) AS april, ");
        //    sqlStr.Append(" SUM(materialNeedPlan.may) AS may, SUM(materialNeedPlan.june) AS june,");
        //    sqlStr.Append(" SUM(materialNeedPlan.july) AS july, SUM(materialNeedPlan.august) AS august,");
        //    sqlStr.Append(" SUM(materialNeedPlan.september) AS september, SUM(materialNeedPlan.october) AS october,");
        //    sqlStr.Append(" SUM(materialNeedPlan.november) AS november,SUM(materialNeedPlan.december) AS december");
        //    sqlStr.Append(" FROM materialNeedPlan INNER JOIN");
        //    sqlStr.Append(" material ON materialNeedPlan.mId = material.id INNER JOIN");
        //    sqlStr.Append(" materialName ON material.mnId = materialName.id INNER JOIN");
        //    sqlStr.Append(" materialModel ON material.mmId = materialModel.id INNER JOIN");
        //    sqlStr.Append(" materialKind ON materialName.mkId = materialKind.id");
        //    sqlStr.Append(" WHERE (YEAR(materialNeedPlan.inputDate) ="+"'"+year+"'"+")");
        //    sqlStr.Append(" GROUP BY materialNeedPlan.mId,materialKind.sort, materialName.name, materialModel.model");
        //    list.Add(sqlStr.ToString());

        //    return sqlHelper.QueryForDateSet(list).Tables[0];
      
        //}
        public DataTable materialNeedPlanShow(string year)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" SELECT materialNeedPlan.mId,materialNeedPlan.inputDate,materialKind.sort, materialName.name, materialModel.model, ");
            sqlStr.Append(" SUM(materialNeedPlan.quantity) AS quantity, SUM(materialNeedPlan.january) AS january,");
            sqlStr.Append(" SUM(materialNeedPlan.february) AS february, ");
            sqlStr.Append(" SUM(materialNeedPlan.march) AS march, SUM(materialNeedPlan.april) AS april, ");
            sqlStr.Append(" SUM(materialNeedPlan.may) AS may, SUM(materialNeedPlan.june) AS june,");
            sqlStr.Append(" SUM(materialNeedPlan.july) AS july, SUM(materialNeedPlan.august) AS august,");
            sqlStr.Append(" SUM(materialNeedPlan.september) AS september, SUM(materialNeedPlan.october) AS october,");
            sqlStr.Append(" SUM(materialNeedPlan.november) AS november,SUM(materialNeedPlan.december) AS december");
            sqlStr.Append(" FROM materialNeedPlan INNER JOIN");
            sqlStr.Append(" material ON materialNeedPlan.mId = material.id INNER JOIN");
            sqlStr.Append(" materialName ON material.mnId = materialName.id INNER JOIN");
            sqlStr.Append(" materialModel ON material.mmId = materialModel.id INNER JOIN");
            sqlStr.Append(" materialKind ON materialName.mkId = materialKind.id");
            sqlStr.Append(" WHERE (YEAR(materialNeedPlan.inputDate) ="+"'"+year+"'"+")");
            sqlStr.Append(" GROUP BY materialNeedPlan.inputDate,materialNeedPlan.mId,materialKind.sort, materialName.name, materialModel.model");
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];

        }
        
    }
    //采购合同
    public class stockContractDb
    {
        DataSet ds = new DataSet();
        DataTable dtable = new DataTable();
        SqlHelper sqlHelper = new SqlHelper();
        
        
        #region//初始化供应商
        public DataTable initialProvider()
        {
            string sqlStr;
            ArrayList list = new ArrayList();

            sqlStr ="select id,name from providerInfo";
            list.Add(sqlStr);

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        #endregion
        #region//初始化合同制作人
        public DataTable initialMaker()
        {
            string SqlStr;
            ArrayList list = new ArrayList();

            SqlStr = "select id,name from usersInfo";
            
            list.Add(SqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        #endregion 
        #region//当供应商定下来了查询出对应的材料种类
        public DataTable initialSort(int providerId)
        {
            //袁宇改
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("providerMaterialCorresponding");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("providerMaterialCorresponding.mid=material.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnid=materialName.id");
            linkS.TableNames.Add("materialKind");
            linkS.LinkConds.Add("materialName.mkId=materialKind.id");
            linkS.Viewfields.Add("distinct materialKind.id");
            linkS.Viewfields.Add("materialKind.sort");
            linkS.Conds.Add("providerMaterialCorresponding.piid=" + providerId);
            return linkS.LeftLinkOpen().Tables[0];

            //袁宇注
            //string sqlStr;
            //ArrayList list = new ArrayList();

            ////sqlStr = "select pmc.mid,pmc.piid,m.id,m.mnid,mn.id,mn.mkid,mk.id as id,mk.sort as sort";
            //sqlStr = "select distinct mk.id as id,mk.sort as sort";
            //sqlStr = sqlStr + " from providerMaterialCorresponding pmc,material m,materialName mn,materialKind mk";
            //sqlStr = sqlStr + " where (pmc.mid=m.id) and (mn.id=m.mnid) and (mn.mkid=mk.id) and (pmc.piid=" + providerId;
            //sqlStr = sqlStr + ")";
            //list.Add(sqlStr.ToString());

            //return sqlHelper.QueryForDateSet(list).Tables[0];
            //LinkSelect LinkS = new LinkSelect();
            //DataTable dt=new DataTable();
            //LinkS.TableNames.Add("providerMaterialCorresponding");
            //LinkS.TableNames.Add("material");
            //LinkS.LinkConds.Add("providerMaterialCorresponding.mId=material.id");
            //LinkS.TableNames.Add("materialName");
            //LinkS.LinkConds.Add("material.mnId=materialName.id");
            //LinkS.TableNames.Add("materialKind");
            //LinkS.LinkConds.Add("materialName.mkId=materialKind.id");

            //LinkS.Viewfields.Add("materialKind.id as id");
            //LinkS.Viewfields.Add("materialKind.sort as sort");
            //LinkS.Conds.Add("providerMaterialCorresponding.piid=" + providerId);

            //dt = LinkS.LeftLinkOpen().Tables[0];

            // return dt;
                                  
        }
        #endregion 
        #region//如果合同不为空的话查询所有的合同编号
        public DataTable initialContractNo()
        {
            string sqlstr;
            ArrayList list = new ArrayList();

            sqlstr = "select id,no from stockContract  WHERE (finishMark = 0)";            
            list.Add(sqlstr);

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }

        // 根据主合同编号得到的ID值查询供应商的名称
        public DataTable findConveyAncerdb(int id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select providerInfo.name ");
            sqlStr.Append(" from stockContract,providerInfo");
            sqlStr.Append(" where stockContract.piId=providerInfo.id and ");
            sqlStr.Append(" stockContract.id="+id);
  
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }

        #endregion

        #region//获得采购合同主界面上的主列表
        public DataTable getContractList(string strWhere, string contractStatus)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            sqlStr.Append("select sc.id,sc.no,sc.name as sname,pr.name as pname,sc.producer,sc.assessor,sc.checkupMan,sc.sum,sc.minQuantity,");
            sqlStr.Append("sc.startDate,sc.endDate,sc.squareMode,sc.conveyancer,sc.no2,");
            sqlStr.Append("case finishMark when 0 then '未终止' else '已终止' end as finishMark ,");
            sqlStr.Append("case when parentId is null then '否' else '是' end as parentId,sc.parentId as useParentId,pr.id as prid,sc.piId");
            sqlStr.Append(" from stockContract sc,providerInfo pr");
            sqlStr.Append(" where sc.piId=pr.id ");    

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
        #endregion
        #region//主表信息有了选中一行合同明细显示
        public DataTable getContractListDetail(int mainId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            sqlStr.Append("select iT.id as htid,iT.mId,mK.sort,mN.name,mM.model,iT.quantity,iT.unitPrice,");
            sqlStr.Append("case finishMark when 0 then '未终止' else  '已终止' end as finishMark,");
            sqlStr.Append("mK.id as id2,mN.id as id3,mM.id as id4,M.id as id5,mN.mkId,M.mnId,");
            sqlStr.Append("M.mmId,iT.scId");
            sqlStr.Append(" from indent iT,material m,materialKind mK,materialName mN,materialModel mM");
            sqlStr.Append(" where (iT.mId=m.id) and(m.mnid=mN.id) and (m.mmId=Mm.id) and (mN.mkId=mK.id)");
            sqlStr.Append("and iT.scId="+mainId);
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        #endregion
        #region//终止合同以及它对应的明细 同时终止相对应的补充合同及明细
        public bool endContractandDetail(int id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            bool endstatus;

            sqlStr.Append("update indent set finishMark=1 where scId=" + id+";");
            sqlStr.Append("update stockContract set finishMark=1 where id="+id);
            list.Add(sqlStr.ToString());

            //查询该合同下的所有补充合同及补充合同的所有明细 对他们进行终止
           
            StringBuilder supplyId = new StringBuilder();
            supplyId.Append("select id from stockContract where parentId=" + id);
            list.Add(supplyId.ToString());
            DataTable dt = sqlHelper.QueryForDateSet(list).Tables[0];

            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StringBuilder updateStr = new StringBuilder();
                    updateStr.Append("update indent set finishMark=1 where scId=" );
                    updateStr.Append(Convert.ToInt32(dt.Rows[i][0].ToString()));
                    updateStr.Append(" update stockContract set finishMark=1 where id=");
                    updateStr.Append( Convert.ToInt32(dt.Rows[i][0].ToString()));
                    list.Add(updateStr.ToString());
                }
            }

            endstatus = sqlHelper.Update(list);

            return endstatus;
        }
        #endregion
        //终止合同
        public bool endContractandDetailOnly(int id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            bool endstatus;

            //sqlStr.Append("update indent set finishMark=1 where scId=" + id + ";");
            sqlStr.Append("update stockContract set finishMark=1 where id=" + id);
            list.Add(sqlStr.ToString());

            endstatus = sqlHelper.Update(list);

            return endstatus;
        }
        //查询给定主合同的所有明细
        public DataTable totalMainId(int mainId)
        {
            string sqlstr;
            ArrayList list = new ArrayList();

            sqlstr = "select count(*) from indent where scId="+mainId;
            list.Add(sqlstr);

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        //查询已经终止的明细个数
        public DataTable condtotalDetail(int mainId)
        {
            string sqlstr;
            ArrayList list = new ArrayList();

            sqlstr = "select count(finishMark) from indent where finishMark=1 and scId=" + mainId;
            list.Add(sqlstr);

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }

        // 给定主合同编号查找它的parentId的值 并通过此parentId值找到对应的所有补充合同的finishMark 查找所有补充合同的所有标志是否都终止 true为终止
        public DataTable finishMarkTable(int mainId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            //sqlStr.Append(" SELECT finishMark ");
            //sqlStr.Append(" FROM stockContract ");
            //sqlStr.Append("WHERE (parentId = ");
            //sqlStr.Append(" (SELECT parentId ");
            //sqlStr.Append(" FROM stockContract AS stockContract_1 ");
            sqlStr.Append("select finishMark ");
            sqlStr.Append("FROM stockContract ");
            sqlStr.Append(" WHERE id = " + mainId );
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        // 终止主合同要做的操作  停止主合同下的所有明细 停止主合同的所有补充合同以及他们下面的所有明细
        public bool endMainContract(int mainId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            // 停止主合同
            sqlStr.Append(" update stockContract set finishMark=1  where id="+mainId+";");
            // 停止主合同对应的所有明细
            sqlStr.Append(" update indent set finishMark=1 where scId=" + mainId+";");
            // 停止所有的分合同
            sqlStr.Append(" update stockContract set finishMark=1 where parentId=" + mainId+";");
            // 先查找所有份合同的id号 再根据id号查找对应的说有分合同明细
            string sqlSelect = " select id from stockContract where parentId=" + mainId;
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { sqlSelect }).Tables[0];

            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sqlStr.Append(" update indent set finishMark=1 where scId=" + Convert.ToInt32(dt.Rows[i][0].ToString())+";");                    
                }
            }
            list.Add(sqlStr.ToString());

            return sqlHelper.Update(list);
        }
        // 终止分合同的操作 终止分合同及分合同的明细 同时要判断同级合同是否全部终止 对应的主合同的明细是否全部终止
        public bool endSupplyContract(int supplyId,int parentId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();            

            sqlStr.Append(" update stockContract set finishMark=1 where id="+supplyId+";");
            sqlStr.Append(" update indent set finishMark=1 where scId=" + supplyId + ";");           

            bool endAll=isEndAll(parentId,parentId);
            if (endAll)
            {
                sqlStr.Append(" update stockContract set finishMark=1 where id=" + parentId + ";");
            }
            list.Add(sqlStr.ToString());

            return sqlHelper.Update(list);

        }
        // 终止主合同明细
        public bool endMainContractDetail(int mainContractDetailId, int mainContractId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" update indent set finishMark=1 where id=" + mainContractDetailId + ";");
            bool endAll = isEndAll(mainContractId, mainContractId);
            if (endAll)
            {
                sqlStr.Append(" update stockContract set finishMark=1 where id=" + mainContractId+";");
            }
            list.Add(sqlStr.ToString());

            return sqlHelper.Update(list);

        }
        // 终止分合同明细
        public bool endSupplyContractDetail(int supplyDetailId, int parentId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" update indent set finishMark=1 where id=" + supplyDetailId + ";");
            bool endAll = isEndAll(parentId, parentId);
            if (endAll)
            {
                sqlStr.Append(" update stockContract set finishMark=1 where id=" + parentId+";");
            }
            list.Add(sqlStr.ToString());

            return sqlHelper.Update(list);
        }

        // 判断主合同的所有分合同是否全部终止以及判断主合同的明细是否全部终止 如果所有都已终止则返回true
        public bool isEndAll(int mainId, int parentId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            bool supplyMark = true;
            bool detailMark = true;

            // 查找出所有的分合同判断是否全部终止
            string sqlSelect = " select finishMark from stockContract where parentId=" + mainId;
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
            string sqlSelectS = " select finishMark from indent where scId=" + parentId;
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
    }
    //采购合同明细类
    public class stockContractDetailDb
    {
        DataSet ds = new DataSet();
        DataTable dtable = new DataTable();
        SqlHelper sqlHelper = new SqlHelper();
        public string getInsertSqlMain(stockContract model)
       {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into stockContract(");
            strSql.Append("name,no,piId,producer,sum,inputDate,squareMode,inputMan,assessor,checkupMan,");           
            if (model.parentId != 0)
            {
                strSql.Append(" parentId,");
            }
            strSql.Append("remark,startDate,endDate,minQuantity,conveyancer,no2,finishMark");                      
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + model.name + "',");
            strSql.Append("'" + model.no + "',");
            strSql.Append("" + model.piId + ",");
            if (model.producer == null)
            {
                strSql.Append("null,");
            }
            else
            {
                strSql.Append("'" + model.producer + "',");
            }
            strSql.Append("" + model.sum + ",");
            strSql.Append("'" + model.inputDate + "',");

            if (model.squareMode == null)
            {
                strSql.Append("null,");
            }
            else
            {
                strSql.Append("'" + model.squareMode + "',");
            }
            strSql.Append("'" + model.inputMan + "',");
            strSql.Append("'" + model.assessor + "',");
            strSql.Append("'" + model.checkupMan + "',");
            if (model.parentId != 0)
            {               
                strSql.Append("'" + model.parentId + "',");
            }                      
            strSql.Append("'" + model.remark + "',");
            strSql.Append("'" + model.startDate + "',");
            strSql.Append("'" + model.endDate + "',");
            strSql.Append("" + model.minQuantity + ",");
            strSql.Append("'" + model.conveyancer + "'"+",");            
            strSql.Append("'" + model.no2.Trim() + "'" + ",");            
            strSql.Append("" + 0 + "");
            strSql.Append(")");
            strSql.Append(";declare  @scId bigint");
            strSql.Append(";set @scId=@@IDENTITY;");


            return strSql.ToString();
        }
        public string getInsertSqlSub(Indent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into indent(");
            strSql.Append("mId,quantity,unitPrice,inputMan,inputDate,finishMark,scId");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.mId + ",");
            strSql.Append("" + model.quantity + ",");
            strSql.Append("" + model.unitPrice + ",");
            strSql.Append("'" + model.inputMan + "',");
            strSql.Append("'" + model.inputDate + "',");
            strSql.Append("" + 0 + ",");
            strSql.Append("@scId");
            strSql.Append(")");

            return strSql.ToString();
        }
        private DataTable contractId(stockContract model)
        {
            string sqlstr;
            ArrayList list = new ArrayList();

            sqlstr = "select id,no from stockContract where no=" + model.no;
            list.Add(sqlstr);

            return sqlHelper.QueryForDateSet(list).Tables[0];

        }
        //终止合同明细的方法
        public bool endContractandDetail(int id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            bool endstatus;

            sqlStr.Append("update indent set finishMark=1 where Id=" + id );           
            list.Add(sqlStr.ToString());

            endstatus = sqlHelper.Update(list);

            return endstatus;
        }
        // 判断合同名称在数据库表中是否存在 若存在不能再插入的数据库表中
        public bool compareContractName(string contractName)
        {
            string sqlSelect = "select name from stockContract where  name=" + "'"+contractName+"'";
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { sqlSelect }).Tables[0];

            if (dt.Rows.Count != 0)
            {
                return true;
            }
            return false;
        }
        // 判断合同编号在数据库表中是否存在 若存在则不能插入到数据库表中
        public bool compareContractNo(string contractNo)
        {           
            string sqlSelect = " select no from stockContract where no=" + "'" + contractNo + "'";
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { sqlSelect }).Tables[0];

            if (dt.Rows.Count != 0)
            {
                return true;
            }
            return false;
        }
        // 根据供应商名称去查找他的id值
        public DataTable findProviderIdDb(string providerName)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select id from providerInfo ");
            sqlStr.Append(" where name =" + "'" + providerName + "'");
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];

        }

    }

    //采购核算
    public class stockSettlementDb
    {
        DataSet ds = new DataSet();
        DataTable dtable = new DataTable();
        SqlHelper sqlHelper = new SqlHelper();

        // 查询核算单
        public DataTable SelectStockCheck(string scId)
        {
            LinkSelect linkS = new LinkSelect();            

            linkS.TableNames.Add("stockMaterialNoteCorresponding");
            linkS.TableNames.Add("stockNote");
            linkS.LinkConds.Add("stockMaterialNoteCorresponding.snId=stockNote.id");
            linkS.TableNames.Add("stockMaterialSettlementDetail");
            linkS.LinkConds.Add("stockMaterialNoteCorresponding.smsdId=stockMaterialSettlementDetail.id");
            linkS.TableNames.Add("stockMaterialSettlement");
            linkS.LinkConds.Add("stockMaterialSettlementDetail.smsId=stockMaterialSettlement.id");
            linkS.TableNames.Add("stockContract");
            linkS.LinkConds.Add("stockMaterialSettlement.scId=stockContract.id");
            linkS.TableNames.Add("voitureInfo");
            linkS.LinkConds.Add("stockNote.viId=voitureInfo.id");

            linkS.TableNames.Add("transportUnit");
            linkS.LinkConds.Add("voitureInfo.tuId=transportUnit.id");
            linkS.TableNames.Add("site site1");
            linkS.LinkConds.Add("stockNote.sId1=site1.id");
            linkS.TableNames.Add("site site2");
            linkS.LinkConds.Add("stockNote.sId2=site2.id");
            linkS.TableNames.Add("transportGoodsInformationCorresponding");
            //linkS.TableNames.Add("transportContract");
           // linkS.LinkConds.Add("stockNote.tcId=transportContract.id");
            linkS.LinkConds.Add("stockNote.tgicId=transportGoodsInformationCorresponding.id");
            linkS.TableNames.Add("transportContract");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.tcId=transportContract.id");

            linkS.TableNames.Add("indent");
            linkS.LinkConds.Add("stockNote.iId=indent.id");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("indent.mId=material.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnId=materialName.id");
            linkS.TableNames.Add("materialModel");
            linkS.LinkConds.Add("material.mmId=materialModel.id");

            //linkS.Viewfields.Add("stockNote.id");
            //车牌号
            linkS.Viewfields.Add("voitureInfo.[no] as 车牌号");
            //销售合同名称
            linkS.Viewfields.Add("stockContract.[name] as 合同名称");
            linkS.Viewfields.Add("stockNote.iId as 合同明细编号");
            //材料名称
            linkS.Viewfields.Add("materialName.[name] as 材料名称");
            //材料型号
            linkS.Viewfields.Add("materialModel.model as 材料型号");
            //车辆毛重
            linkS.Viewfields.Add("stockNote.grossWeight as 车辆毛重");
            //车辆皮重
            linkS.Viewfields.Add("stockNote.tare as 车辆皮重");
            //净重
            linkS.Viewfields.Add("stockNote.suttle as 车辆净重");
            //起运地
            linkS.Viewfields.Add("site1.site as 起运地");
            //此运地
            linkS.Viewfields.Add("site2.site as 止运地");
            //录入时间
            linkS.Viewfields.Add("stockNote.inputdate as 日期时间");
            //备注信息
            linkS.Viewfields.Add("stockNote.remark as 备注");
            //条码
            linkS.Viewfields.Add("stockNote.barCode as 条形码");
            if ((scId != null) && (!scId.Trim().Equals("")))
            {
                linkS.Conds.Add("stockMaterialSettlement.id=" + scId); 
            }

            return linkS.LeftLinkOpen().Tables[0];
        }

        // 采购核算查询核算的合同信息
        public DataTable getStockSettlementList(string strWhere)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select sc.id,sc.name,sc.no,pr.name as pname,sc.sum,sc.assessor,sc.checkupMan,");
            sqlStr.Append("case finishMark when 0 then '未终止'  else  '已终止' end as finishMark,");
            sqlStr.Append("sc.piId,pr.id as pid");
            sqlStr.Append("  from stockContract sc,providerInfo pr");
            sqlStr.Append(" where sc.piId=pr.id");
            sqlStr.Append(" and finishMark=0");

            if (strWhere.Trim() != "")
            {
                sqlStr.Append(" and " + strWhere.Trim());
            }
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        //新增采购核算中的合同名称绑定界面上的combobox
        public DataTable initialContractCombobox()
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select id,name from stockContract where finishMark=0");
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        // 维护采购核算时要反对合同名称因此不需要设置条件finishMark=0
        public DataTable initialContractComboboxSupply()
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select id,name from stockContract ");
            sqlStr.Append("WHERE (assessor IS NOT NULL) AND (checkupMan IS NOT NULL) AND (assessor <> '') AND (checkupMan <> '') and finishMark=0");
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }

        //选中合同名称后获得合同对应的明细信息
        public DataTable correspondingContractDetailInfo(long mainId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select indent.id,indent.scId,indent.mId,");            
            sqlStr.Append("stockContract.piId,stockContract.id as id2,");
            sqlStr.Append("material.id as id3,material.mmid,material.mnid,");            
            sqlStr.Append("materialKind.id as id6,materialKind.sort,");
            sqlStr.Append("materialName.id as id5,materialName.name as mname,materialName.mkId,");
            sqlStr.Append("materialModel.id as id4,materialModel.model,");
            sqlStr.Append("providerInfo.id as id1,providerInfo.name as pname,indent.quantity,indent.unitPrice");
            sqlStr.Append(" from indent,stockContract,providerInfo,material,materialModel,");
            sqlStr.Append("materialName,materialKind");
            sqlStr.Append("  where indent.scId="+mainId+" and ");
            sqlStr.Append("indent.mId=material.id" + " and ");
            sqlStr.Append("material.mmid=materialModel.id"+" and ");
            sqlStr.Append("material.mnid=materialName.id" + " and ");
            sqlStr.Append("materialName.mkId=materialKind.id"+" and ");
            sqlStr.Append("providerInfo.id=stockContract.piId"+" and ");
            sqlStr.Append("stockContract.id="+mainId);
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        public long GetMaxInRecId()
        {
            DataSet ds = new DataSet();
            ArrayList sqlText = new ArrayList();
            sqlText.Add("SELECT MAX(id) AS RegID FROM stockMaterialSettlement");
            ds = sqlHelper.QueryForDateSet(sqlText);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
            }
            else
                return -1;

        }
        public long GetMaterialSettlementDetailNo(string MaterialSettlementNo, string indentId)
        {
            LinkSelect linkS = new LinkSelect();
            DataSet dt = new DataSet();

            linkS.TableNames.Add("stockMaterialSettlementDetail");
            linkS.TableNames.Add("stockMaterialSettlement");
            linkS.LinkConds.Add("stockMaterialSettlementDetail.smsId=stockMaterialSettlement.id");
            linkS.TableNames.Add("indent");
            linkS.LinkConds.Add("stockMaterialSettlementDetail.iId=indent.id");
            linkS.Viewfields.Add("stockMaterialSettlementDetail.id");
            
            if ((MaterialSettlementNo != null) && (!indentId.Trim().Equals("")))
            {
                linkS.Conds.Add("stockMaterialSettlementDetail.smsId=" + MaterialSettlementNo);
            }
            if ((indentId != null) && (!indentId.Trim().Equals("")))
            {
                linkS.Conds.Add("stockMaterialSettlementDetail.iId=" + indentId);
            }
            dt = linkS.LeftLinkOpen();
            if (dt.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt64(dt.Tables[0].Rows[0]["id"].ToString());
            }
            else
                return -1;
            
 
        }
        // 根据小票的条码查询出它是否已经结算过了
        public DataTable checkBarCodeDb(string barCode)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" select * from stockNote where (checkAccountMark1 = 1) and ");
            sqlStr.Append(" barCode="+"'"+barCode +"'");
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        //根据扫入的条码号查询出条码上的所有相关信息
        public DataTable barCodeInfo(string barCode)
        {
            LinkSelect linkS = new LinkSelect();
            linkS.TableNames.Add("stockNote");
            linkS.TableNames.Add("indent");
            linkS.LinkConds.Add("stockNote.iId=indent.id");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("indent.mid=material.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnid=materialName.id");
            linkS.TableNames.Add("materialModel");
            linkS.LinkConds.Add("material.mmid=materialModel.id");
            linkS.TableNames.Add("stockContract");
            linkS.LinkConds.Add("indent.scId=stockContract.id");
            linkS.TableNames.Add("voitureInfo");
            linkS.LinkConds.Add("stockNote.viId=voitureInfo.id");
            linkS.TableNames.Add("transportUnit");
            linkS.LinkConds.Add("voitureInfo.tuId=transportUnit.id");
            linkS.TableNames.Add("site as site1");
            linkS.LinkConds.Add("stockNote.sId1=site1.id");
            linkS.TableNames.Add("site as site2");
            linkS.LinkConds.Add("stockNote.sId2=site2.id");
            //linkS.TableNames.Add("transportContract");
            //linkS.LinkConds.Add("stockNote.tcId=transportContract.id");
            linkS.TableNames.Add("transportGoodsInformationCorresponding");
            linkS.LinkConds.Add("stockNote.tgicId=transportGoodsInformationCorresponding.id");
            linkS.TableNames.Add("transportContract");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.tcId=transportContract.id");

            linkS.Viewfields.Add("stockNote.id");
            //车牌号
            linkS.Viewfields.Add("voitureInfo.[no] as 车牌号");
            //销售合同名称
            linkS.Viewfields.Add("stockContract.[name] as 合同名称");
            linkS.Viewfields.Add("stockNote.iId as 合同明细编号");
            //材料名称
            linkS.Viewfields.Add("materialName.[name] as 材料名称");
            //材料型号
            linkS.Viewfields.Add("materialModel.model as 材料型号");
            //车辆毛重
            linkS.Viewfields.Add("stockNote.grossWeight as 车辆毛重");
            //车辆皮重
            linkS.Viewfields.Add("stockNote.tare as 车辆皮重");
            //净重
            linkS.Viewfields.Add("stockNote.suttle as 车辆净重");            
            //起运地
            linkS.Viewfields.Add("site1.site as 起运地");
            //此运地
            linkS.Viewfields.Add("site2.site as 止运地");
            //录入时间
            linkS.Viewfields.Add("stockNote.inputdate as 日期时间");            
            //备注信息
            linkS.Viewfields.Add("stockNote.remark as 备注");            
            //条码
            linkS.Viewfields.Add("stockNote.barCode as 条形码");
            if ((!barCode.Equals(null)) && (!barCode.Equals("")))
            {
                linkS.Conds.Add("stockNote.barCode=" + "'" + barCode + "'");
            }
            linkS.Conds.Add("(stockNote.assessor is not null and stockNote.assessor <> '')");
            linkS.Conds.Add("(stockNote.checkupMan is not null and stockNote.checkupMan <> '')");
            linkS.Conds.Add("stockNote.checkAccountMark1=0");

            return linkS.LeftLinkOpen().Tables[0];
        }
        //向采购核算表中插入数据
        public string insertStockSettlement(stockMaterialSettlement stockSet)
        {
            StringBuilder sqlStr = new StringBuilder();

            sqlStr.Append("insert into stockMaterialSettlement(totalWeight,scId,sum,inputDate,");
            sqlStr.Append("inputMan,count)");
            sqlStr.Append("values(");
            sqlStr.Append("" + stockSet.totalWeight + "," + stockSet.scId + ",");
            sqlStr.Append("" + stockSet.sum + "," + "'" + stockSet.inputDate+"'"+",");
            sqlStr.Append("" + "'" + stockSet.inputMan + "'" + ",");
            sqlStr.Append("" + stockSet.count);
            sqlStr.Append(")");
            sqlStr.Append("; declare @smsId int");
            sqlStr.Append("; set @smsId=@@IDENTITY;");

            return sqlStr.ToString();

        }
        /*
            * 方法名称：InsertStockNote
            * 方法功能描述：向指定表中，用指定字段和值插入一条数据  
            * 参数: info 值内容
            *       
            *       
            *       
            * 创建人：袁宇
            * 创建时间：2009-03-06
            *
            * 修改人：
            * 修改时间：
            * 修改内容：
            *
            */
        public string InsertStockNote(stockMaterialNoteCorresponding info)
        {
            DataVar var = new DataVar();
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            fields.Add("smsdId");
            values.Add(info.smsdId.ToString());
            if (info.inputDate != null)
            {
                fields.Add("inputDate");
                values.Add("'" + info.inputDate.ToString() + "'");
            }
            if (info.inputMan != null)
            {
                fields.Add("inputMan");
                values.Add(info.inputMan.ToString());
            }
            fields.Add("snId");
            values.Add(info.snId.ToString());
            return InsertTable("stockMaterialNoteCorresponding", fields, values);
 
        }
        public string UpdateStockNode(string Str)
        {
            DataVar var = new DataVar();
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            ArrayList conds = new ArrayList();

            conds.Add("id="+Str);
            fields.Add("checkAccountMark1");
            values.Add("1");
            return UpdateTeble("stockNote", fields, values, conds) +" ";
        }
        /*
            * 方法名称：InsertTable
            * 方法功能描述：向指定表中，用指定字段和值插入一条数据  
            * 参数: TabName 表名 
            *       FieldList 字段名列表
            *       ValueList 值列表
            *       
            * 创建人：袁宇
            * 创建时间：2009-03-06
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
                return SqlText;
            }
            return SqlText;

        }
        /*
            * 方法名称：UpdateTeble
            * 方法功能描述：更新字段与值对比字符串生成；  
            * 参数: list1 字段列表 
            *       List2 值列表
            *       Eval 操作符 
            *       compart  间隔符
            * 创建人：袁宇
            * 创建时间：2009-02-26
            *
            * 修改人：
            * 修改时间：
            * 修改内容：
            *
            */
        private string UpdateTeble(string TabName, ArrayList FieldList, ArrayList ValueList, ArrayList Cond)
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
            return SqlText.ToString() ;
        }
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
        * 创建时间：2009-02-26
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
        //向核算明细表中插入数据
        public string insertStockSettlementDetail(stockMaterialSettlementDetail stockSetDetail)
        {
            StringBuilder sqlStr=new StringBuilder();

            sqlStr.Append("insert into stockMaterialSettlementDetail(smsId,iId,count,");
            sqlStr.Append("sum,inputDate,inputMan)");
            sqlStr.Append("values(");
            sqlStr.Append("" + "@smsId" + ",");
            sqlStr.Append("" + stockSetDetail.iId+",");
            sqlStr.Append("" + stockSetDetail.count + ",");
            sqlStr.Append("" + stockSetDetail.sum+",");
            sqlStr.Append("" + "'" + stockSetDetail.inputDate +"'"+",");
            sqlStr.Append("" + "'" + stockSetDetail.inputMan + "'");
            sqlStr.Append(")");            

            return sqlStr.ToString();
        }
        // 查询采购核算明细表的id和采购合同明细的id
        public DataTable getNeedId()
        {
            //bool status;
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select stockMaterialSettlementDetail.id as id1,stockMaterialSettlementDetail.iId as iId1,");
            sqlStr.Append("indent.id as id2,stockNote.iId as iId2,stockNote.id as id3");
            sqlStr.Append(" from stockMaterialSettlementDetail,indent,stockNote");
            sqlStr.Append(" where stockMaterialSettlementDetail.iId=indent.id and ");
            sqlStr.Append("indent.id=stockNote.id");
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];

            //return status;
        }
        // 查询采购核算主界面上面的核算单列表
        public DataTable SelectStockMaterialSettlement(string ContractNo, string ContractName, string providerName)
        {
            LinkSelect ls = new LinkSelect();
            DataSet ds = new DataSet();

            ls.TableNames.Add("stockMaterialSettlement");
            ls.TableNames.Add("stockContract");
            ls.LinkConds.Add("stockMaterialSettlement.scId=stockContract.id");
            ls.TableNames.Add("providerInfo");
            ls.LinkConds.Add("stockContract.piId=providerInfo.id");
            ls.Viewfields.Add("stockMaterialSettlement.id");
            ls.Viewfields.Add("stockMaterialSettlement.id as 核算单号");
            ls.Viewfields.Add("stockContract.[name] as 合同名称");
            ls.Viewfields.Add("stockContract.[no] as 合同编号");
            ls.Viewfields.Add("providerInfo.[name] as 供应商名");
            ls.Viewfields.Add("stockMaterialSettlement.sum as 总金额");
            ls.Viewfields.Add("stockMaterialSettlement.inputdate as 日期时间");
            ls.Viewfields.Add("stockMaterialSettlement.inputMan as 录入人");
            ls.Viewfields.Add("stockMaterialSettlement.assessor as 审核人");
            ls.Viewfields.Add("stockMaterialSettlement.checkupMan as 审批人");
            ls.Viewfields.Add("stockMaterialSettlement.count as 票具总数");
            ls.Viewfields.Add("stockMaterialSettlement.remark as 备注");
            if (!ContractNo.Trim().Equals(""))
            {
                ls.Conds.Add("stockContract.[no]=" + "'" + ContractNo + "'");
            }
            if (!ContractName.Trim().Equals(""))
            {
                ls.Conds.Add("stockContract.[name]=" + "'" + ContractName + "'");
            }
            if (!providerName.Trim().Equals(""))
            {
                ls.Conds.Add("providerInfo.[name]=" + "'" + providerName + "'");
            }
            ds = ls.LeftLinkOpen();

            return ds.Tables[0];
        }
    }

    // 采购统计数据层方法
    public class stockStaticsDb
    {
        DataSet ds = new DataSet();
        DataTable dtable = new DataTable();
        SqlHelper sqlHelper = new SqlHelper();     
               
        // 按材料查询从年初到截止时间的净重
        public DataTable stockMaterialSelect(string endyear)      
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" SELECT f.sort, d.name, a.mnId, a.mmId, e.model, SUM(c.suttle) AS inweight,");
            sqlStr.Append(" COUNT(*) AS notecount, b.mId,");
            sqlStr.Append("(SELECT SUM(sn.suttle) AS ysuttle FROM stockNote AS sn INNER JOIN");
            sqlStr.Append(" indent AS mi ON sn.iId = mi.id ");
            //sqlStr.Append(" WHERE (mi.mId = b.mId) AND (year(sn.inputDate) = '2009')) AS ysuttle ");
            sqlStr.Append(" WHERE (mi.mId = b.mId) AND (sn.inputDate <= " + "'" + endyear + "'" + ")) AS ysuttle ");
            sqlStr.Append("FROM material AS a INNER JOIN" );
            sqlStr.Append(" indent AS b ON a.id = b.mId INNER JOIN ");
            sqlStr.Append("stockNote AS c ON b.id = c.iId INNER JOIN ");
            sqlStr.Append("materialName AS d ON a.mnId = d.id INNER JOIN ");
            sqlStr.Append("materialModel AS e ON a.mmId = e.id INNER JOIN ");
            sqlStr.Append("materialKind AS f ON d.mkId = f.id ");
            sqlStr.Append("where  (SELECT SUM(sn.suttle) AS ysuttle FROM stockNote AS sn INNER JOIN indent AS mi ON sn.iId = mi.id  WHERE (mi.mId = b.mId) AND (sn.inputDate <= " + "'" + endyear + "'" + "))<>0 ");
            sqlStr.Append("GROUP BY d.name, f.sort, e.model, a.mnId, a.mmId, b.mId");
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        // 按材料查询时间段内的净重
        public DataTable stockMaterialIntervalSelect(string startyear,string endyear)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" SELECT f.sort, d.name, a.mnId, a.mmId, e.model, SUM(c.suttle) AS inweight,");
            sqlStr.Append(" COUNT(*) AS notecount, b.mId,");
            sqlStr.Append("(SELECT SUM(sn.suttle) AS ysuttle FROM stockNote AS sn INNER JOIN");
            sqlStr.Append(" indent AS mi ON sn.iId = mi.id ");
            sqlStr.Append(" WHERE (mi.mId = b.mId) AND (sn.inputDate< = "+"'"+endyear+"'"+")) AS ysuttle ");
            sqlStr.Append("FROM material AS a INNER JOIN");
            sqlStr.Append(" indent AS b ON a.id = b.mId INNER JOIN ");
            sqlStr.Append("stockNote AS c ON b.id = c.iId INNER JOIN ");
            sqlStr.Append("materialName AS d ON a.mnId = d.id INNER JOIN ");
            sqlStr.Append("materialModel AS e ON a.mmId = e.id INNER JOIN ");
            sqlStr.Append("materialKind AS f ON d.mkId = f.id ");
            //sqlStr.Append(" WHERE (c.inputDate BETWEEN '2009-1-1' AND '2009-3-5') ");
            sqlStr.Append(" WHERE (c.inputDate >= "+"'"+startyear+"'"+")");
            sqlStr.Append(" and (c.inputDate<="+"'"+endyear+"'"+")");
            sqlStr.Append("GROUP BY d.name, f.sort, e.model, a.mnId, a.mmId, b.mId");
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        // 按运输单位的名称进行统计
        public DataTable stockTransportUnit(string startyear,string endyear)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("SELECT tu.name AS tname, site.site , mk.sort, mn.name AS mname, mm.model,");
            sqlStr.Append("SUM(sn.suttle) AS suttle ");
            sqlStr.Append("FROM materialKind AS mk INNER JOIN ");
            sqlStr.Append("indent AS it INNER JOIN ");
            sqlStr.Append("transportContract AS tc INNER JOIN ");
            sqlStr.Append(" transportGoodsInformationCorresponding AS tgic ON tgic.tcId = tc.id INNER JOIN ");
            sqlStr.Append("stockNote AS sn ON tgic.id = sn.tgicId INNER JOIN ");
            sqlStr.Append("transportUnit AS tu ON tc.tuId = tu.id ON it.id = sn.iId INNER JOIN ");                 
            sqlStr.Append("material AS m ON it.mId = m.id INNER JOIN ");
            sqlStr.Append("materialName AS mn ON m.mnId = mn.id INNER JOIN ");
            sqlStr.Append("materialModel AS mm ON m.mmId = mm.id ON mk.id = mn.mkId INNER JOIN ");
            sqlStr.Append("site ON sn.sId1 = site.id ");
            sqlStr.Append("WHERE (sn.inputDate >= "+"'"+startyear+"'"+")");
            sqlStr.Append("AND (sn.inputDate <= "+"'"+endyear+"'"+")");
            sqlStr.Append("GROUP BY tu.name, site.site, mk.sort, mn.name, mm.model ");
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        // 按供应商名称统计
        public DataTable stockProviderInfo(string startyear,string endyear)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("SELECT pr.name AS provider, mk.sort, mn.name AS mname, mm.model,");
            //sqlStr.Append("SUM(sn.suttle) AS inweight,COUNT(*) AS notecount,(select SUM(isn.suttle) as suttle ");
            sqlStr.Append("SUM(sn.suttle) AS inweight,COUNT(*) AS notecount, ");
            sqlStr.Append("(SELECT SUM(isn.suttle) AS suttle ");
            sqlStr.Append(" FROM stockNote AS isn INNER JOIN ");
            sqlStr.Append("indent AS ii ON isn.iId = ii.id INNER JOIN ");
            sqlStr.Append("stockContract AS sc ON ii.scId = sc.id INNER JOIN ");
            sqlStr.Append("providerInfo AS ipr ON sc.piId = ipr.id ");
            sqlStr.Append(" WHERE (ii.mId = it.mId) AND   ");
            sqlStr.Append("(ipr.name = pr.name)");
            //sqlStr.Append("from stockNote isn,indent ii where isn.iid=ii.id and ii.mid=it.mid ");
            //sqlStr.Append("and year(isn.inputDate)='2009' group by ii.mid) as ysuttle ");
            sqlStr.Append("and isn.inputDate <= " + "'" + endyear + "'" + " group by ii.mid,ipr.name) as ysuttle ");
            sqlStr.Append("FROM stockNote AS sn INNER JOIN ");
            sqlStr.Append("indent AS it ON sn.iId = it.id INNER JOIN ");
            sqlStr.Append("stockContract AS sc ON it.scId = sc.id INNER JOIN ");
            sqlStr.Append(" providerInfo AS pr ON sc.piId = pr.id INNER JOIN ");
            sqlStr.Append("material AS m ON it.mId = m.id INNER JOIN ");
            sqlStr.Append(" materialName AS mn ON m.mnId = mn.id INNER JOIN ");
            sqlStr.Append("materialModel AS mm ON m.mmId = mm.id INNER JOIN ");
            sqlStr.Append("materialKind AS mk ON mn.mkId = mk.id ");
            //sqlStr.Append("WHERE (sn.inputDate >= '2009-3-9') AND (sn.inputDate <= '2009-4-9') ");
            sqlStr.Append("WHERE (sn.inputDate >= " + "'" + startyear + "'" + ") AND (sn.inputDate <= " + "'" + endyear + "'" + ") ");
            sqlStr.Append("GROUP BY it.mid,pr.name, mk.sort, mn.name, mm.model ");
            sqlStr.Append(" union all ");
            sqlStr.Append("SELECT pr.name AS provider, mk.sort, mn.name AS mname, mm.model,0, 0, ");
            sqlStr.Append("(select SUM(isn.suttle) as suttle ");
            //sqlStr.Append("from stockNote isn,indent ii where isn.iid=ii.id and ii.mid=it.mid and year(isn.inputDate)='2009' ");
            sqlStr.Append("from stockNote isn,indent ii where isn.iid=ii.id and ii.mid=it.mid and isn.inputDate<=" + "'" + endyear + "' ");
            sqlStr.Append("group by ii.mid) as ysuttle ");
            sqlStr.Append("FROM stockNote AS sn INNER JOIN ");
            sqlStr.Append("indent AS it ON sn.iId = it.id INNER JOIN ");
            sqlStr.Append("stockContract AS sc ON it.scId = sc.id INNER JOIN ");
            sqlStr.Append("providerInfo AS pr ON sc.piId = pr.id INNER JOIN ");
            sqlStr.Append("material AS m ON it.mId = m.id INNER JOIN ");
            sqlStr.Append(" materialName AS mn ON m.mnId = mn.id INNER JOIN ");
            sqlStr.Append("materialModel AS mm ON m.mmId = mm.id INNER JOIN ");
            sqlStr.Append("materialKind AS mk ON mn.mkId = mk.id ");
            //sqlStr.Append("WHERE (sn.inputDate >= '2009-1-1') AND (sn.inputDate <= '2009-3-9') and ");
            sqlStr.Append("WHERE (sn.inputDate >= " + "'" + startyear + "'" + ") AND (sn.inputDate <=" + "'" + endyear + "'" + ") and ");
            sqlStr.Append("m.id not in(select i.mid from stockNote sn,indent i where sn.iid=i.id and ");
            sqlStr.Append(" sn.inputDate>="+"'"+startyear+"'"+"and sn.inputdate <="+"'"+endyear+"'");
            sqlStr.Append("group by i.mid) ");            
            sqlStr.Append("GROUP BY it.mid,pr.name, mk.sort, mn.name, mm.model ");
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
    }

    }

