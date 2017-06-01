using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DasherStation.common;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DasherStation.produce;


namespace DasherStation.produce
{
    public class ProduceDB
    {
        SqlHelper sqlHelperObj = new SqlHelper();
        DataSet ds = new DataSet();
        Database db = null;
        ArrayList list = new ArrayList();

        //产品种类
        public DataSet proSort()
        {
            list.Clear();
            string sqlstr;

            sqlstr = "select  sort,id from productKind";
            list.Add(sqlstr);
            ds = sqlHelperObj.QueryForDateSet(list);

            return ds;
        }
        //产品名称
        public DataSet proName(string pkid)
        {
            list.Clear();
            string sqlstr;

            sqlstr = "select id,name,pkid from productName where pkid=" + pkid;
            list.Add(sqlstr);
            ds = sqlHelperObj.QueryForDateSet(list);

            return ds;

        }
        //产品规格型号
        public DataSet proType(string pnid)
        {
            list.Clear();
            string sqlstr = "select pm.id,pm.model from product p,productModel pm where p.pmid=pm.id and p.pnid=" + pnid;

            
            list.Add(sqlstr);
            ds = sqlHelperObj.QueryForDateSet(list);

            return ds;

        }
        //制作人
        public DataSet makerR()
        {
            list.Clear();
            string sqlstr;

            sqlstr = "select id,name from personnelInfo";
            list.Add(sqlstr);
            ds = sqlHelperObj.QueryForDateSet(list);

            return ds;

        }
        //目标配合比
        public DataSet targetmp(string kindName)
        {
            list.Clear();
            string sqlstr;

            if (kindName == "混合料")
            {
                sqlstr = "select id from targetProportion";
            }
            else
            {
                sqlstr = "select id from proportion";
            }
            list.Add(sqlstr);
            ds = sqlHelperObj.QueryForDateSet(list);

            return ds;
        }
        //按日期查询生产计划
        public DataSet frmproductShedule(string startyear, string endyear)
        {
            list.Clear();
            string sqlstr;

            sqlstr = "select  id,produceTime,producer,assessor,checkupMan,remark from productionPlan";
            sqlstr = sqlstr + " where (Year(produceTime) >= " + startyear + ")";
            sqlstr = sqlstr + "and (Year(produceTime) <=" + endyear + ")";
            sqlstr = sqlstr + "order by produceTime asc";
            list.Add(sqlstr);
            ds = sqlHelperObj.QueryForDateSet(list);

            return ds;

        }
  
        /*
       * 方法名称：productId
       * 方法功能描述：查询生产配合比编号
       *
       * 创建人：付中华
       * 创建时间：2009-2-25
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       */
        public DataSet productId()
        {
            list.Clear();
            string sqlstr;

            sqlstr = "select id from produceProportion";
            list.Add(sqlstr);
            ds = sqlHelperObj.QueryForDateSet(list);

            return ds;
        }
        /*
        * 方法名称：targetId
        * 方法功能描述：查询目标配合比编号
        *
        * 创建人：付中华
        * 创建时间：2009-2-25
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        */
        public DataSet targetId()
        {
            list.Clear();
            string sqlstr;

            sqlstr = "select id from targetProportion";
            list.Add(sqlstr);
            ds = sqlHelperObj.QueryForDateSet(list);

            return ds;
        }
        //插入到生产计划的主表中
         public string getInsertSqlps(productionSchedule proSchedule)
        {
            list.Clear();
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into productionPlan(");
             //少插入个inputman
            strsql.Append("producer,produceTime,remark,inputDate)");
            strsql.Append("values(");
            strsql.Append("'" + proSchedule.producer +"'"+ ",");
            strsql.Append("'" + proSchedule.produceTime + "',");
            strsql.Append("'" + proSchedule.remark + "'"+",");
            strsql.Append("Getdate()");
            //strsql.Append("," + proSchedule.inputMan +",");
            strsql.Append(")");
            strsql.Append(";declare  @ppId int");
            strsql.Append(";set @ppId=@@IDENTITY;");
            list.Add(strsql);

            return strsql.ToString();
        }
        //插入到生产计划的明细表中
        public string getInsertSqlpsd(productionScheduleDetail proScheduledetail)
        {
            list.Clear();
            #region
            //StringBuilder strsql = new StringBuilder();
            //strsql.Append("insert into productionPlanDetail(");
            //strsql.Append("Pid ,Tpid ,Inputdate ,January ,February ,March " + ",");
            //strsql.Append("April ,May ,June ,July ,August ,September ,October ,November ,December" + ",");
            //strsql.Append("Producequantity " +","+"ppId"+ ")");
            //strsql.Append("values(");
            //strsql.Append("" + proScheduledetail.Pid + ",");
            //strsql.Append(""  + proScheduledetail.Tpid + ",");
            //strsql.Append("'" + proScheduledetail.Inputdate + "',");
            //strsql.Append("" + proScheduledetail.January + "," + proScheduledetail.February + "," + proScheduledetail.March + ",");
            //strsql.Append("" + proScheduledetail.April + "," + proScheduledetail.May + "," + proScheduledetail.June + ",");
            //strsql.Append("" + proScheduledetail.July + "," + proScheduledetail.August + "," + proScheduledetail.September + ",");
            //strsql.Append("" + proScheduledetail.October + "," + proScheduledetail.November + "," + proScheduledetail.December + ",");
            //strsql.Append("" + proScheduledetail.Producequantity + ",");
            
            //strsql.Append("@ppId");
            //strsql.Append(")");
            //list.Add(strsql);

            //return strsql.ToString();
            #endregion

            StringBuilder sqlStr = new StringBuilder();
            StringBuilder sqlStr1 = new StringBuilder();
            StringBuilder sqlStr2 = new StringBuilder();

            if (proScheduledetail.January!=null)
            {
                sqlStr1.Append("January,");
                sqlStr2.Append("" + proScheduledetail.January+",");
            }
            if (proScheduledetail.February!=null)
            {
                sqlStr1.Append("February,");
                sqlStr2.Append("" + proScheduledetail.February + ",");
            }
            if (proScheduledetail.March!=null)
            {
                sqlStr1.Append("March,");
                sqlStr2.Append("" +proScheduledetail.March+",");
            }
            if (proScheduledetail.April!=null)
            {
                sqlStr1.Append("April,");
                sqlStr2.Append("" +proScheduledetail.April+",");
            }
            if (proScheduledetail.May!=null)
            {
                sqlStr1.Append("May,");
                sqlStr2.Append("" +proScheduledetail.May+",");
            }
            if (proScheduledetail.June!=null)
            {
                sqlStr1.Append("June,");
                sqlStr2.Append("" +proScheduledetail.June+",");
            }
            if (proScheduledetail.July!=null)
            {
                sqlStr1.Append("July,");
                sqlStr2.Append("" +proScheduledetail.July +",");
            }
            if (proScheduledetail.August!=null)
            {
                sqlStr1.Append("August,");
                sqlStr2.Append("" +proScheduledetail.August+",");
            }
            if (proScheduledetail.September!=null)
            {
                sqlStr1.Append("September,");
                sqlStr2.Append("" +proScheduledetail.September+",");
            }
            if (proScheduledetail.October!=null)
            {
                sqlStr1.Append("October,");
                sqlStr2.Append("" +proScheduledetail.October+",");
            }
            if (proScheduledetail.November!=null)
            {
                sqlStr1.Append("November,");
                sqlStr2.Append("" +proScheduledetail.November+",");
            }
            if (proScheduledetail.December!=null)
            {
                sqlStr1.Append("December,");
                sqlStr2.Append("" + proScheduledetail.December + ",");
            }
            sqlStr.Append("insert into productionPlanDetail(Pid ,Tpid ,Inputdate ,");
            sqlStr.Append(sqlStr1.ToString());
            sqlStr.Append("ppId)");
            sqlStr.Append("values(" + proScheduledetail.Pid + "," + proScheduledetail.Tpid + ",'" + proScheduledetail.Inputdate + "',");
            sqlStr.Append(sqlStr2.ToString());
            sqlStr.Append("@ppId)");

            return sqlStr.ToString();

        }
        //执行事务
        public bool excuteTransaction(ArrayList sqlstr)
        {
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction transaction = conn.BeginTransaction();

                DbCommand dbcmd = null;

                try
                {
                    StringBuilder sqlbuilder = new StringBuilder();
                    foreach (string str in sqlstr)
                    {
                        sqlbuilder.Append(str);
                    }
                    dbcmd = db.GetSqlStringCommand(sqlbuilder.ToString());

                    db.ExecuteNonQuery(dbcmd, transaction);

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //重新查询已经更新的表针对的是生产计划主界面的第一个显示表
        public DataSet getList()
        {
            list.Clear();
            string sqlstr;

            sqlstr = "select id,year(produceTime) as produceTime,producer,assessor,checkupMan,remark from productionPlan";
            list.Add(sqlstr);
            ds = sqlHelperObj.QueryForDateSet(list);

            return ds;
        }
        //更新从表内容
        public DataSet getListchild(string strwhere)
        {
            list.Clear();
            string sqlstr;

            sqlstr = "select ppd.*,name,model from productionPlanDetail ppd,product p,productModel pm,productName pn where p.pnid=pn.id and p.pmid=pm.id and ppd.pid=p.id and ppId=" + strwhere;
            
            list.Add(sqlstr);
            ds = sqlHelperObj.QueryForDateSet(list);

            return ds;
        }

        /// <summary>
        /// 删除生产计划
        /// </summary>
        /// <param name="pId">生产计划ID</param>
        /// <returns>True:成功 False:失败</returns>
        public bool ProductionDel(string pId)
        {
            list.Clear();
            string sqlStr = "delete from productionPlanDetail where ppid=" + pId + ";delete from productionPlan where id=" + pId;
            list.Add(sqlStr);
            

            return sqlHelperObj.Delete(list);
        }

        /// <summary>
        /// 根据产品名称规格，查询出产品ID
        /// </summary>
        /// <param name="pNid">产品名称</param>
        /// <param name="pMid">产品规格</param>
        /// <returns></returns>
        public DataSet queryPid(string pNid, string pMid)
        {
            ArrayList sqlList = new ArrayList();
            sqlList.Add("select id from product p where p.pnid=" + pNid + " and p.pmid=" + pMid);

            return sqlHelperObj.QueryForDateSet(sqlList);  
        }

        /// <summary>
        /// 根据材料名称规格，查询出材料ID
        /// </summary>
        /// <param name="pNid">材料名称ID</param>
        /// <param name="pMid">材料规格ID</param>
        /// <returns></returns>
        public DataSet queryMid(string mNid, string mMid)
        {
            ArrayList sqlList = new ArrayList();
            sqlList.Add("select id from material m where m.mnid=" + mNid + " and m.mmid=" + mMid);

            return sqlHelperObj.QueryForDateSet(sqlList);
        }
    }


    public class ProducePlanDB
    {
        SqlHelper sqlHelper = new SqlHelper();
        public DataSet QueryForDataSet(ArrayList sqlList)
        {
            return sqlHelper.QueryForDateSet(sqlList);
        }

        public bool ExecuteTransaction(ArrayList sqlList)
        {
            return sqlHelper.ExecuteTransaction(sqlList);
        }

        ArrayList sqlList = null;
//====================================================================================================================        

        /// <summary>
        /// 目标配合必绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        /// <param name="pId">配合必编号</param>
        public void targetProportionBind(ComboBox cmb, string pId)
        {
            sqlList = new ArrayList();

            sqlList.Add("select * from targetProportion where pId=" + pId);

            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "id";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 人员信息绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        /// <param name="ptId">生产班组ID</param>
        public void personInfoBind(ComboBox cmb, string ptId)
        {
            sqlList = new ArrayList();

            sqlList.Add("select * from personnelInfo");

            if (ptId != null)
            {
                sqlList.Add(" where ptId=" + ptId);
            }

            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "name";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 生产配合必绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        /// <param name="pId">配合必编号</param>
        public void produceProportionBind(ComboBox cmb, string pId)
        {
            sqlList = new ArrayList();

            sqlList.Add("select * from produceProportion where pId=" + pId);

            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "id";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;

        }

        /// <summary>
        /// 生产配合比绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
       
        public void produceProportionBind(ComboBox cmb)
        {
            sqlList = new ArrayList();

            sqlList.Add("select * from produceProportion");

            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "id";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;

        }

        /// <summary>
        /// 沥青配合比绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        /// <param name="pId">配合必编号</param>
        /// <param name="mark2">配合比类型 0:乳化沥青 1:改性沥青</param>
        public void proportionDetailBind(ComboBox cmb, string pId, int mark2)
        {
            sqlList = new ArrayList();

            sqlList.Add("select * from proportion where mark2='" + mark2 + "' and  pId=" + pId);

            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "id";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 配合比明细绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="pId">配合比编号</param>
        public void proportionDetailBind(DataGridView dgv, string pId)
        {
            sqlList = new ArrayList();

            sqlList.Add("select pd.pid as id,mn.name,mm.model,pd.proportionValue from proportionDetail pd,material m,materialName mn,materialModel mm where m.mmid=mm.id and m.mnid=mn.id and pd.mid=m.id and pd.pid=" + pId);

            dgv.DataSource = QueryForDataSet(sqlList).Tables[0];
        }

        /// <summary>
        /// 产品种类绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void productKindBind(ComboBox cmb)
        {
            sqlList = new ArrayList();

            sqlList.Add("select * from productKind");

            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "sort";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;

        }

        /// <summary>
        /// 原料种类绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void materialKindBind(ComboBox cmb)
        {
            sqlList = new ArrayList();

            sqlList.Add("select * from materialKind");

            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "sort";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;

        }

        /// <summary>
        /// 材料名称绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void materialNameBind(ComboBox cmb, string mkId)
        {
            sqlList = new ArrayList();
            sqlList.Add("select * from materialName where mkid=" + mkId);
            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "name";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;

        }

        /// <summary>
        /// 产品名称绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void productNameBind(ComboBox cmb, string pkId)
        {
            sqlList = new ArrayList();

            sqlList.Add("select * from productName where pkid=" + pkId);

            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "name";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;

        }

        /// <summary>
        /// 产品名称绑定
        /// </summary>
        /// <param name="string">筛选条件</param>
        public DataSet productNameBind(string strWhere)
        {
            sqlList = new ArrayList();

            sqlList.Add("select * from productName ");

            if (strWhere != "" && strWhere != null)
            {
                sqlList.Add(strWhere);
            }

            return QueryForDataSet(sqlList);
   
        }

        /// <summary>
        /// 产品规格绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void productModelBind(ComboBox cmb, string pnId)
        {
            sqlList = new ArrayList();

            sqlList.Add("select pm.id,pm.model from product p,productModel pm where p.pmid=pm.id and p.pnid=" + pnId);

            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "model";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 材料规格绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void materialModelBind(ComboBox cmb, string mnId)
        {
            sqlList = new ArrayList();

            if (string.IsNullOrEmpty(mnId))
            {
                sqlList.Add("select mm.id,mm.model from materialModel mm ");
            }
            else
            {
                sqlList.Add("select mm.id,mm.model from material m,materialModel mm where m.mmid=mm.id and m.mnid=" + mnId);

            }
            
            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "model";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 机械设备绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void equipmentInfoBind(ComboBox cmb)
        {
            sqlList = new ArrayList();

            sqlList.Add("select ei.id,ei.no from equipmentInformation ei");

            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "no";
            cmb.ValueMember = "id";
            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 生产班主绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void produceTeamBind(ComboBox cmb)
        {
            sqlList = new ArrayList();

            sqlList.Add("select * from produceTeam");

            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "name";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;

        }

        /// <summary>
        /// 人员信息表绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void personnelInfoBind(ComboBox cmb, string ptId)
        {
            sqlList = new ArrayList();

            sqlList.Add("select * from personnelInfo where ptid=" + ptId);

            cmb.DataSource = QueryForDataSet(sqlList).Tables[0];
            cmb.DisplayMember = "name";
            cmb.ValueMember = "id";

            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 查询目标配合比
        /// </summary>
        /// <param name="tpId">目标配合比编号</param>
        /// <returns>DataSet</returns>
        public DataSet quaryTargetProportion(string tpId)
        {
            sqlList = new ArrayList();

            sqlList.Add("select * from targetProportion where id=" + tpId);

            return QueryForDataSet(sqlList);

        }

        /// <summary>
        /// 生产配合比绑定
        /// </summary>
        /// <param name="proportionTable">包含了指定热料仓信息TextBox的Panel</param>
        /// <param name="ppId">配合比编号</param>
        public void proportionBind(Panel proportionTable, string ppId)
        {
            DataSet ds = new DataSet();

            sqlList = new ArrayList();

            sqlList.Add("select produceProportion,produceProportionValue from produceProportionDetail where ppid=" + ppId);

            ds = QueryForDataSet(sqlList);

            string proportionTag = null;

            foreach (Object obj in proportionTable.Controls)
            {
                TextBox txtObj = obj as TextBox;
                
                if (txtObj!=null)
                {

                    proportionTag = txtObj.Tag.ToString();
                    txtObj.Text = "";
                    foreach (DataRowView dv in ds.Tables[0].DefaultView)
                    {
                        if (dv["produceProportion"].ToString().IndexOf(proportionTag) > -1)
                        {
                            txtObj.Text = dv["produceProportionValue"].ToString();
                        }
                    }

                }
            }

        }

        /// <summary>
        /// 获取配合比基数
        /// </summary>
        /// <param name="proportionTable"></param>
        /// <returns></returns>
        public float getproduceMeasurTotal(Panel proportionTable)
        {
            float total=0;
            foreach (Object obj in proportionTable.Controls)
            {
                TextBox txtObj = obj as TextBox;
                if (txtObj!=null)
                {
                    if (txtObj.Tag.ToString().Length == 1)
                    {
                        if (txtObj.Text != "")
                        {
                            total += float.Parse(txtObj.Text.Trim());
                        }
                    }  
                }
            }
            return total;
        }

        /// <summary>
        /// 获取骨料配合比误差最大值
        /// </summary>
        /// <returns></returns>
        public void getProportionError(out float proportionError1, out float proportionError2)
        {
            sqlList = new ArrayList();

            sqlList.Add("select top 1 asphaltumError,stoneError from produceMeasureParameter order by inputDate desc");

            DataTable dt = QueryForDataSet(sqlList).Tables[0];

            if (dt.Rows.Count > 0)
            {
                proportionError1 = float.Parse(dt.Rows[0][0].ToString());
                proportionError2 = float.Parse(dt.Rows[0][1].ToString());
            }
            else
            {
                proportionError1 = 1;
                proportionError2 = 1;
            }

        }

        /// <summary>
        /// 目标配合比绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="tpId">配合比编号</param>
        public void targetBind(DataGridView dgv, string tpId)
        {
            sqlList = new ArrayList();

            sqlList.Add("select tpd.tpid as id,mn.name,mm.model,tpd.targetProportionValue from targetProportionDetail tpd,material m,materialName mn,materialModel mm where m.mmid=mm.id and m.mnid=mn.id and tpd.mid=m.id and tpd.tpid=" + tpId);

            dgv.DataSource = QueryForDataSet(sqlList).Tables[0];

        }

        /// <summary>
        /// 保存生产通知单
        /// </summary>
        /// <param name="producenotice">通知单对象</param>
        /// <param name="sendproportion">发送通知单对象</param>
        /// <param name="producesendProportionDetail">生产配合比发送明细</param>
        /// <param name="targetsendProportionDetail">目标配合比发送明细</param>
        /// <param name="sendproportionDetail">配合比明细</param>
        /// <returns>True:成功 false:失败</returns>
        public bool saveProduceNotice(ProduceNotice producenotice, SendProportion sendproportion, ProduceSendProportionDetail producesendProportionDetail, TargetSendProportionDetail targetsendProportionDetail, SendProportionDetail sendproportionDetail)
        {

            ArrayList sqlList = new ArrayList();
            if (sendproportion != null)
            {
                sqlList.Add(new SendProportionAction().GetUpdateSql(sendproportion));
            }
            if (producenotice != null)
            {
                sqlList.Add(new ProduceNoticeAction().GetInsertSql(producenotice));
            }
            if (producesendProportionDetail != null)
            {
                sqlList.Add(new ProduceSendProportionDetailAction().GetInsertSql(producesendProportionDetail));
            }
            if (targetsendProportionDetail != null)
            {
                sqlList.Add(new TargetSendProportionDetailAction().GetInsertSql(targetsendProportionDetail));
            }
            if (sendproportionDetail != null)
            {
                sqlList.Add(new SendProportionDetailAction().GetInsertSql(sendproportionDetail));
            }

            return ExecuteTransaction(sqlList);
        }

        /// <summary>
        /// 保存生产记录
        /// </summary>
        /// <param name="mixtureProduceLog">生产记录对象</param>
        /// <returns></returns>
        public bool saveProduceLog(MixtureProduceLog mixtureProduceLog)
        {
            ArrayList sqlList = new ArrayList();
            if (mixtureProduceLog != null)
            {
                sqlList.Add(new MixtureProduceLogAction().GetInsertSql(mixtureProduceLog));
            }

            return ExecuteTransaction(sqlList);
        }

        /// <summary>
        /// 保存生产记录
        /// </summary>
        /// <param name="mixtureProduceLog">生产记录对象</param>
        /// <returns></returns>
        public bool saveProduceLog(AgainCalefactionProduceLog againCalefactionProduceLog)
        {
            ArrayList sqlList = new ArrayList();
            if (againCalefactionProduceLog != null)
            {
                sqlList.Add(new AgainCalefactionProduceLogAction().GetInsertSql(againCalefactionProduceLog));
            }

            return ExecuteTransaction(sqlList);
        }

        /// <summary>
        /// 保存生产记录
        /// </summary>
        /// <param name="mixtureProduceLog">生产记录对象</param>
        /// <returns></returns>
        public bool saveProduceLog(EmulsificationAsphaltumProduceLog emulsificationAsphaltumProduceLog)
        {
            ArrayList sqlList = new ArrayList();
            if (emulsificationAsphaltumProduceLog != null)
            {
                sqlList.Add(new EmulsificationAsphaltumProduceLogAction().GetInsertSql(emulsificationAsphaltumProduceLog));
            }

            return ExecuteTransaction(sqlList);
        }

        /// <summary>
        /// 保存生产记录
        /// </summary>
        /// <param name="mixtureProduceLog">生产记录对象</param>
        /// <returns></returns>
        public bool saveProduceLog(RestructureAsphaltumProduceLog restructureAsphaltumProduceLog)
        {
            ArrayList sqlList = new ArrayList();
            if (restructureAsphaltumProduceLog != null)
            {
                sqlList.Add(new RestructureAsphaltumProduceLogAction().GetInsertSql(restructureAsphaltumProduceLog));
            }

            return ExecuteTransaction(sqlList);
        }

        /// <summary>
        /// 删除生产通知单
        /// </summary>
        /// <param name="spId">发送配合比表ID</param>
        /// <returns>True:成功 False:失败</returns>
        public bool delProduceNotice(string pnId)
        {
            ArrayList sqlList = new ArrayList();

            //sqlList.Add("delete from targetsendProportionDetail where spId=" + spId);
            //sqlList.Add("delete from producesendProportionDetail where spId=" + spId);
            //sqlList.Add("delete from sendProportionDetail where spid=" + spId);
            sqlList.Add("delete from producenotice where Id=" + pnId);
            


            return ExecuteTransaction(sqlList);
        }

        /// <summary>
        /// 删除生产记录
        /// </summary>
        /// <param name="spId">生产记录ID</param>
        /// <returns>True:成功 False:失败</returns>
        public bool delProduceLog(string plId,ProducePlan.pType type)
        {
            ArrayList sqlList = new ArrayList();
            switch (type)
            {
                case ProducePlan.pType.Mixture:
                    sqlList.Add(new MixtureProduceLogAction().GetDeleteSql(plId));
                    break;
                case ProducePlan.pType.EmulsificationAsphaltum:
                    sqlList.Add(new EmulsificationAsphaltumProduceLogAction().GetDeleteSql(plId));
                    break;
                case ProducePlan.pType.RestructureAsphaltum:
                    sqlList.Add(new RestructureAsphaltumProduceLogAction().GetDeleteSql(plId));
                    break;
                case ProducePlan.pType.AgainCalefaction:
                    sqlList.Add(new AgainCalefactionProduceLogAction().GetDeleteSql(plId));
                    break;
            }
            return ExecuteTransaction(sqlList);
        }

        /// <summary>
        /// 查询对应产品的ID
        /// </summary>
        /// <param name="pnId">名称ID</param>
        /// <param name="pmId">型号ID</param>
        /// <returns></returns>
        public int getPid(string pnId, string pmId)
        {
            Produce produce = new Produce();
            return produce.queryPid(pnId, pmId);
        }

        /// <summary>
        /// 生产通知单信息绑定
        /// </summary>
        /// <param name="dgv">拌合料对应DataGridView</param>
        /// <param name="dgv1">改行沥青对应DataGridView</param>
        /// <param name="dgv2">乳化沥青对应DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        public void produceNoticeBind(DataGridView dgv, DataGridView dgv1, DataGridView dgv2, string sqlWhere)
        {
            sqlList = new ArrayList();

            sqlList.Add("select pnt.id,p.pnid,p.pmid,pn.name,pm.model,pnt.planQuantity,Convert(varchar");
            sqlList.Add("(10),pnt.startDate,120) as startDate,ei.no,pnt.assessor,pnt.checkupMan,pnt.notifyMan,Convert");
            sqlList.Add("(varchar(10),pnt.notifyDate,120) as notifyDate,psp.ppid,tsp.tpid,ptId,psp.eiid from ");
            sqlList.Add("produceNotice pnt,produceSendProportionDetail psp,produceProportion ");
            sqlList.Add(" pp,product p,productName pn,productModel pm,targetSendProportionDetail ");
            sqlList.Add("tsp,equipmentInformation ei where ei.id=psp.eiid and pnt.spId=psp.spId and psp.ppid=pp.id and pp.pid=p.id and ");
            sqlList.Add(" p.pnid=pn.id and p.pmid=pm.id and pnt.spid=tsp.spid ");
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlList.Add(sqlWhere);
            }
            sqlList.Add(" order by notifyDate desc;");

            sqlList.Add("select pnt.id,pn.name,pm.model,pnt.planQuantity,Convert(varchar(10)");
            sqlList.Add(",pnt.startDate,120) as startDate,ei.no,pnt.assessor,pnt.checkupMan,pnt.notifyMan,Convert(varchar(10)");
            sqlList.Add(",pnt.notifyDate,120) as notifyDate,pp.id ppid,ptId,spd.eiid,p.id pid from produceNotice pnt,Proportion pp");
            sqlList.Add(",sendProportionDetail spd,product p,productName pn,productModel pm,equipmentInformation ei");
            sqlList.Add(" where ei.id=spd.eiid and spd.spId=pnt.spid and spd.pid=pp.id and pp.pid=p.id and p.pnid=pn.id and p.pmid=pm.id  and pp.mark2=0 ");
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlList.Add(sqlWhere);
            }
            sqlList.Add(" order by notifyDate desc;");

            sqlList.Add("select pnt.id,pn.name,pm.model,pnt.planQuantity,Convert(varchar(10)");
            sqlList.Add(",pnt.startDate,120) as startDate,ei.no,pnt.assessor,pnt.checkupMan,pnt.notifyMan,Convert(varchar(10)");
            sqlList.Add(",pnt.notifyDate,120) as notifyDate,pp.id ppid,ptId,spd.eiid,p.id pid from produceNotice pnt,Proportion pp");
            sqlList.Add(",sendProportionDetail spd,product p,productName pn,productModel pm,equipmentInformation ei");
            sqlList.Add(" where ei.id=spd.eiid and spd.spId=pnt.spid and spd.pid=pp.id and pp.pid=p.id and p.pnid=pn.id and p.pmid=pm.id  and pp.mark2=1 ");
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlList.Add(sqlWhere);
            }
            sqlList.Add(" order by notifyDate desc;");

            DataSet ds = QueryForDataSet(sqlList);
            //混合料
            if (dgv != null)
            {
                dgv.DataSource = ds.Tables[0];
            }
            //改性沥青
            if (dgv1 != null)
            {
                dgv1.DataSource = ds.Tables[1];
            }
            //乳化沥青
            if (dgv2 != null)
            {
                dgv2.DataSource = ds.Tables[2];
            }
            
        }

        /// <summary>
        /// 生产记录信息绑定
        /// </summary>
        /// <param name="dgv">拌合料对应DataGridView</param>
        /// <param name="dgv1">改行沥青对应DataGridView</param>
        /// <param name="dgv2">乳化沥青对应DataGridView</param>
        /// <param name="dgv3">沥青再加温对应DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        public void ProduceLogBind(DataGridView dgv, string sqlWhere,ProducePlan.pType type)
        {
            sqlList = new ArrayList();
            sqlList = ProduceLogBind(sqlWhere, type);
            dgv.DataSource = QueryForDataSet(sqlList).Tables[0];          
        }

        /// <summary>
        /// 生产计量信息绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        public void produceMeasureBind(DataGridView dgv, string sqlWhere)
        {
            sqlList = new ArrayList();

            sqlList.Add("select pmm.id,ei.no,temperature,asphaltumWeight,blockWeight,realMaterialWeight1,realMaterialWeight2,realMaterialWeight3,realMaterialWeight4,realMaterialWeight5,realMaterialWeight6,stuffingWeight,pmm.inputDate,result from produceMeasureMonitor pmm,equipmentInformation ei where pmm.eiId=ei.id ");

            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlList.Add(sqlWhere);
            }
            sqlList.Add(" order by  pmm.inputDate desc");

            dgv.DataSource = QueryForDataSet(sqlList).Tables[0];
        }

        /// <summary>
        /// 生产统计信息绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="sqlWhere">筛选查询语句</param>
        public void ProduceStatisticsBind(DataGridView dgv, string sqlWhere)
        {
            sqlList = new ArrayList();

            sqlList.Add("select pl.id,Convert(varchar(10),pl.produceDate,120) as produceDate");
            sqlList.Add(",pn.name as pname,pm.model,en.name as ename");


            #region // 关启学修改，新增四列：“quantity（产量，以手动录入为主）,dataSource（产量数据来源：手动、自动）,goodQuantity（合格产量）,badQuantity（不合格产量）”
            
            //sqlList.Add(",LTRIM(str(quantity1))+'(自动)'+'|'+LTRIM(str(quantity2))+'(手动)' as quantity,en.id as eid");

            //用以下代码替换上面原来代码（上面被注释掉的代码）
            sqlList.Add(",isnull(pl.quantity2,pl.quantity1) as quantity,");
            sqlList.Add(" case");
            sqlList.Add("    when pl.quantity2 is null then '自动'");
            sqlList.Add("    else '手动'");
            sqlList.Add(" end dataSource,");
            sqlList.Add(" pl.quantity3 as goodQuantity,");
            sqlList.Add(" (isnull(pl.quantity2,pl.quantity1) - pl.quantity3) as badQuantity,");
            sqlList.Add(" en.id as eid");           
            
            #endregion


            
            sqlList.Add(",p.pnid,p.pmid from mixtureProduceLog pl,equipmentInformation ei,equipmentName en");
            sqlList.Add(",product p,productName pn,productModel pm where ei.enid=en.id ");
            sqlList.Add(" and pl.eiid=ei.id and pl.pid=p.id and p.pnid=pn.id and p.pmid=pm.id ");
            if (sqlWhere!= "" && sqlWhere != null)
            {
                sqlList.Add(sqlWhere);
            }
            sqlList.Add(" union all ");

            sqlList.Add("select pl.id,Convert(varchar(10),pl.produceDate,120) as produceDate");
            sqlList.Add(",pn.name as pname,pm.model,en.name as ename");


            #region // 关启学修改，新增四列：“quantity（产量，以手动录入为主）,dataSource（产量数据来源：手动、自动）,goodQuantity（合格产量）,badQuantity（不合格产量）”

            //sqlList.Add(",LTRIM(str(quantity1))+'(自动)'+'|'+LTRIM(str(quantity2))+'(手动)' as quantity,en.id as eid");

            //用以下代码替换上面原来代码（上面被注释掉的代码）
            sqlList.Add(",isnull(pl.quantity2,pl.quantity1) as quantity,");
            sqlList.Add(" case");
            sqlList.Add("    when pl.quantity2 is null then '自动'");
            sqlList.Add("    else '手动'");
            sqlList.Add(" end dataSource,");
            sqlList.Add(" pl.quantity3 as goodQuantity,");
            sqlList.Add(" (isnull(pl.quantity2,pl.quantity1) - pl.quantity3) as badQuantity,");
            sqlList.Add(" en.id as eid");

            #endregion

            
            sqlList.Add(",p.pnid,p.pmid from emulsificationAsphaltumProduceLog pl,equipmentInformation ei,equipmentName en");
            sqlList.Add(",product p,productName pn,productModel pm where ei.enid=en.id ");
            sqlList.Add(" and pl.eiid=ei.id and pl.pid2=p.id and p.pnid=pn.id and p.pmid=pm.id ");
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlList.Add(sqlWhere);
            }
            sqlList.Add(" union all ");

            sqlList.Add("select pl.id,Convert(varchar(10),pl.produceDate,120) as produceDate");
            sqlList.Add(",pn.name as pname,pm.model,en.name as ename");


            #region // 关启学修改，新增四列：“quantity（产量，以手动录入为主）,dataSource（产量数据来源：手动、自动）,goodQuantity（合格产量）,badQuantity（不合格产量）”

            //sqlList.Add(",LTRIM(str(quantity1))+'(自动)'+'|'+LTRIM(str(quantity2))+'(手动)' as quantity,en.id as eid");

            //用以下代码替换上面原来代码（上面被注释掉的代码）
            sqlList.Add(",isnull(pl.quantity2,pl.quantity1) as quantity,");
            sqlList.Add(" case");
            sqlList.Add("    when pl.quantity2 is null then '自动'");
            sqlList.Add("    else '手动'");
            sqlList.Add(" end dataSource,");
            sqlList.Add(" pl.quantity3 as goodQuantity,");
            sqlList.Add(" (isnull(pl.quantity2,pl.quantity1) - pl.quantity3) as badQuantity,");
            sqlList.Add(" en.id as eid");

            #endregion

            
            sqlList.Add(",p.pnid,p.pmid from restructureAsphaltumProduceLog pl,equipmentInformation ei,equipmentName en");
            sqlList.Add(",product p,productName pn,productModel pm where ei.enid=en.id ");
            sqlList.Add(" and pl.eiid=ei.id and pl.pid2=p.id and p.pnid=pn.id and p.pmid=pm.id ");
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlList.Add(sqlWhere);
            }

            sqlList.Add(" order by  produceDate desc");
            dgv.DataSource = QueryForDataSet(sqlList).Tables[0];
        }

        /// <summary>
        /// 配合比通知单信息绑定
        /// </summary>
        /// <param name="dgv">对应DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        /// <param name="Type">类型枚举</param>
        public void ProduceProportionBind(DataGridView dgv, string sqlWhere,ProducePlan.pType type)
        {
            sqlList = new ArrayList();
            sqlList = getProduceProportionBind(sqlWhere, type);
            dgv.DataSource = QueryForDataSet(sqlList).Tables[0];     
        }

        private ArrayList getProduceProportionBind(string sqlWhere, ProducePlan.pType type)
        {
            sqlList = new ArrayList();
            switch (type)
            {
                case ProducePlan.pType.Mixture:
                    sqlList.Add("select SP.id,PN.name,PM.model,ei.no as ename,SP.inputDate,SP.inputMan,SP.confirmDate,SP.remark,ei.id as eid,tspd.tpid ,pspd.ppid,pk.id as pkid,product.pnid,product.pmid,pk.sort ");
                    sqlList.Add("from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP");
                    sqlList.Add(",targetSendProportionDetail as TSPD,produceSendProportionDetail pspd,targetProportion as TP");
                    sqlList.Add(",equipmentInformation as EI,equipmentName en ");
                    sqlList.Add("where TP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id and product.pmId = PM.id and TSPD.tpId = TP.id and TP.pId = product.id and SP.id = TSPD.spId and pSPD.eiId = EI.id  and ei.enid=en.id and pspd.spid=sp.id");
                    

                    if (!string.IsNullOrEmpty(sqlWhere))
                    {
                        sqlList.Add(sqlWhere);
                    }
                    sqlList.Add(" order by SP.inputDate desc;");
                    break;
                case ProducePlan.pType.EmulsificationAsphaltum:
                    sqlList.Add("select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,SP.remark,ei.id as eid,ei.no as ename,p.id as ppid,pk.id as pkid,pnid,pmid ");
                    sqlList.Add("from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP");
                    sqlList.Add(",sendProportionDetail as SPD,proportion as P,equipmentInformation as EI,equipmentName en ");
                    sqlList.Add("where P.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ");
                    sqlList.Add("and product.pmId = PM.id and SPD.pId = P.id and P.pId = product.id");
                    sqlList.Add(" and SP.id = SPD.spId and SPD.eiId = EI.id and  ei.enid=en.id and  p.mark2=1 ");

                    if (!string.IsNullOrEmpty(sqlWhere))
                    {
                        sqlList.Add(sqlWhere);
                    }
                    sqlList.Add(" order by SP.inputDate desc;");
                    break;
                case ProducePlan.pType.RestructureAsphaltum:
                    sqlList.Add("select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,SP.remark,ei.id as eid,ei.no as ename,p.id as ppid,pk.id as pkid,pnid,pmid ");
                    sqlList.Add("from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP");
                    sqlList.Add(",sendProportionDetail as SPD,proportion as P,equipmentInformation as EI,equipmentName en ");
                    sqlList.Add("where P.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ");
                    sqlList.Add("and product.pmId = PM.id and SPD.pId = P.id and P.pId = product.id");
                    sqlList.Add(" and SP.id = SPD.spId and SPD.eiId = EI.id and  ei.enid=en.id and p.mark2=0 ");

                    if (!string.IsNullOrEmpty(sqlWhere))
                    {
                        sqlList.Add(sqlWhere);
                    }
                    sqlList.Add(" order by SP.inputDate desc;");
                    break;
                default:
                    break;

            }
            return sqlList;
        }

        /// <summary>
        /// 能源消耗信息绑定
        /// </summary>
        /// <param name="sqlWhere">筛选条件</param>
        public DataSet produceEnergyConsumptionBind(string sqlWhere, ProducePlan.pType type)
        {
            sqlList = new ArrayList();
            sqlList = getEnergyConsumptionBind(sqlWhere, type);
            return QueryForDataSet(sqlList); 
        }

        private ArrayList getEnergyConsumptionBind(string sqlWhere, ProducePlan.pType type)
        {

            sqlList = new ArrayList();
            switch (type)
            {
                case ProducePlan.pType.Mixture:
                    sqlList.Add("select pl.id,pn.name as pname,pm.model,LTRIM(str(quantity1))+'(自动)'+'|'+LTRIM(str(quantity2))+'(手动)' as quantity");
                    sqlList.Add(",Convert(varchar(10),produceDate,120) as produceDate,en.name as ename,startMachineTime");
                    sqlList.Add(",stopMachineTime,weather");
                    sqlList.Add(",coarseMaterialHydratedRate,refinedMaterialHydratedRate,tpId,ppid from mixtureProduceLog pl");
                    sqlList.Add(" ,equipmentInformation ei,equipmentName en,product p,productName pn,productModel pm");
                    sqlList.Add("  where ei.enid=en.id and pl.eiid=ei.id and pl.pid=p.id and p.pnid=pn.id and p.pmid=pm.id ");

                    if (!string.IsNullOrEmpty(sqlWhere))
                    {
                        sqlList.Add(sqlWhere);
                    }
                    sqlList.Add(" order by pl.inputDate desc;");
                    break;
                case ProducePlan.pType.EmulsificationAsphaltum:
                    sqlList.Add("select pl.id,pn.name as pname,pm.model,LTRIM(str(quantity1))+'(自动)'+'|'+LTRIM(str(quantity2))+'(手动)' as quantity");
                    sqlList.Add(",Convert(varchar(10),produceDate,120) as produceDate,en.name as ename");
                    sqlList.Add(",startMachineTime,stopMachineTime,weather,pl.pid from emulsificationAsphaltumProduceLog pl");
                    sqlList.Add(",equipmentInformation ei,equipmentName en,product p,productName pn,productModel pm ");
                    sqlList.Add(" where ei.enid=en.id and pl.eiid=ei.id and pl.pid=p.id and p.pnid=pn.id and p.pmid=pm.id ");

                    if (!string.IsNullOrEmpty(sqlWhere))
                    {
                        sqlList.Add(sqlWhere);
                    }
                    sqlList.Add(" order by pl.inputDate desc;");
                    break;
                case ProducePlan.pType.RestructureAsphaltum:
                    sqlList.Add("select pl.id,pn.name as pname,pm.model,LTRIM(str(quantity1))+'(自动)'+'|'+LTRIM(str(quantity2))+'(手动)' as quantity");
                    sqlList.Add(",Convert(varchar(10),produceDate,120) as produceDate,en.name as ename");
                    sqlList.Add(",startMachineTime,stopMachineTime,weather,pl.pid from restructureAsphaltumProduceLog pl");
                    sqlList.Add(",equipmentInformation ei,equipmentName en,product p,productName pn,productModel pm ");
                    sqlList.Add(" where ei.enid=en.id and pl.eiid=ei.id and pl.pid=p.id and p.pnid=pn.id and p.pmid=pm.id ");

                    if (!string.IsNullOrEmpty(sqlWhere))
                    {
                        sqlList.Add(sqlWhere);
                    }
                    sqlList.Add(" order by pl.inputDate desc;");
                    break;
                default:
                    break;

            }
            return sqlList;

        }

        /// <summary>
        /// 原料消耗信息绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        public void ProduceMaterialConsumptionBind(DataGridView dgv, string sqlWhere)
        {
            sqlList = new ArrayList();

            sqlList.Add("select pl.pid,pl.produceDate,mn.name as mname,mm.model ");
            sqlList.Add(",Convert(varchar(10),CAST(pd.targetProportionValue/(select sum(targetProportionValue) from targetProportionDetail where tpid=pd.tpid)*100 as decimal(38, 2)))+'%' as scale,pn.name as pname");
            sqlList.Add(",pm.model as pmodel,pl.quantity1,pl.quantity2,en.name as ename");


            #region // 关启学修改，新增三列：“quantity（产量，以手动录入为主）,dataSource（产量数据来源：手动、自动）,consumption（材料消耗，以手动录入的产量为主进行计算）”

            //sqlList.Add(",CAST(pl.quantity1*pd.targetProportionValue/(select sum(targetProportionValue) from targetProportionDetail where tpid=pd.tpid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0)) as decimal(38, 2)) as Consumption1");
            //sqlList.Add(",cast(pl.quantity2*pd.targetProportionValue/(select sum(targetProportionValue) from targetProportionDetail where tpid=pd.tpid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0))as decimal(38, 2)) as Consumption2 ");

            //用以下代码替换上面原来代码（上面被注释掉的代码）
            sqlList.Add(",isnull(pl.quantity2,pl.quantity1) as quantity,");
            sqlList.Add(" case");
            sqlList.Add("    when pl.quantity2 is null then '自动'");
            sqlList.Add("    else '手动'");
            sqlList.Add(" end dataSource,");
            sqlList.Add(" case");
            sqlList.Add("    when pl.quantity2 is null then CAST(pl.quantity1*pd.targetProportionValue/(select sum(targetProportionValue) from targetProportionDetail where tpid=pd.tpid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0)) as decimal(38, 2))");
            sqlList.Add("	 else CAST(pl.quantity2*pd.targetProportionValue/(select sum(targetProportionValue) from targetProportionDetail where tpid=pd.tpid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0))as decimal(38, 2))");
            sqlList.Add(" end consumption");

            #endregion


            sqlList.Add(",p.pnid,p.pmid,m.mnid,m.mmid,pl.eiid ");
            sqlList.Add("from targetProportionDetail pd,mixtureProduceLog pl,product p,productName pn,productModel pm,material m,materialName mn,materialModel mm,equipmentName en,equipmentInformation ei ");
            sqlList.Add("where pd.tpid=pl.tpid and pl.pid=p.id and p.pnid=pn.id and ");
            sqlList.Add("p.pmid=pm.id and pd.mid=m.id and m.mnid=mn.id and m.mmid=mm.id and ei.enid=en.id and pl.eiid=ei.id ");

            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlList.Add(sqlWhere);
            }
            sqlList.Add(" union all ");

            sqlList.Add("select pl.pid,pl.produceDate,mn.name as mname,mm.model ");
            sqlList.Add(",Convert(varchar(10),CAST(pd.proportionValue/(select sum(proportionValue) from proportionDetail where pid=pd.pid)*100 as decimal(38, 2)))+'%' as scale ");
            sqlList.Add(",pn.name as pname,pm.model,pl.quantity1,pl.quantity2,en.name as ename");

            
            #region // 关启学修改，新增三列：“quantity（产量，以手动录入为主）,dataSource（产量数据来源：手动、自动）,consumption（材料消耗，以手动录入的产量为主进行计算）”

            //sqlList.Add(",CAST(pl.quantity1*pd.proportionValue/(select sum(proportionValue) from proportionDetail where pid=pd.pid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0)) as decimal(38, 2)) as Consumption1 ");
            //sqlList.Add(",cast(pl.quantity2*pd.proportionValue/(select sum(proportionValue) from proportionDetail where pid=pd.pid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0))as decimal(38, 2)) as Consumption2 ");

            //用以下代码替换上面原来代码（上面被注释掉的代码）
            sqlList.Add(",isnull(pl.quantity2,pl.quantity1) as quantity,");
            sqlList.Add(" case");
            sqlList.Add("    when pl.quantity2 is null then '自动'");
            sqlList.Add("    else '手动'");
            sqlList.Add(" end dataSource,");
            sqlList.Add(" case");
            sqlList.Add("    when pl.quantity2 is null then CAST(pl.quantity1*pd.proportionValue/(select sum(proportionValue) from proportionDetail where pid=pd.pid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0)) as decimal(38, 2))");
            sqlList.Add("	 else cast(pl.quantity2*pd.proportionValue/(select sum(proportionValue) from proportionDetail where pid=pd.pid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0))as decimal(38, 2))");
            sqlList.Add(" end consumption");

            #endregion


            sqlList.Add(",p.pnid,p.pmid,m.mnid,m.mmid,pl.eiid ");
            sqlList.Add("from proportionDetail pd,emulsificationAsphaltumProduceLog pl,product p,productName pn,productModel pm,material m,materialName mn,materialModel mm,equipmentName en,equipmentInformation ei ");
            sqlList.Add("where pd.pid=pl.pid and pl.pid2=p.id and p.pnid=pn.id and p.pmid=pm.id  ");
            sqlList.Add("and pd.mid=m.id and m.mnid=mn.id and m.mmid=mm.id and ei.enid=en.id and pl.eiid=ei.id  ");

            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlList.Add(sqlWhere);
            }
            sqlList.Add(" union all ");

            sqlList.Add("select pl.pid,pl.produceDate,mn.name as mname,mm.model ");
            sqlList.Add(",Convert(varchar(10),CAST(pd.proportionValue/(select sum(proportionValue) from proportionDetail where pid=pd.pid)*100 as decimal(38, 2)))+'%' as scale ");
            sqlList.Add(",pn.name as pname,pm.model,pl.quantity1,pl.quantity2,en.name as ename");


            #region // 关启学修改，新增三列：“quantity（产量，以手动录入为主）,dataSource（产量数据来源：手动、自动）,consumption（材料消耗，以手动录入的产量为主进行计算）”

            //sqlList.Add(",CAST(pl.quantity1*pd.proportionValue/(select sum(proportionValue) from proportionDetail where pid=pd.pid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0)) as decimal(38, 2)) as Consumption1 ");
            //sqlList.Add(",cast(pl.quantity2*pd.proportionValue/(select sum(proportionValue) from proportionDetail where pid=pd.pid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0))as decimal(38, 2)) as Consumption2 ");



            //用以下代码替换上面原来代码（上面被注释掉的代码）
            sqlList.Add(",isnull(pl.quantity2,pl.quantity1) as quantity,");
            sqlList.Add(" case");
            sqlList.Add("    when pl.quantity2 is null then '自动'");
            sqlList.Add("    else '手动'");
            sqlList.Add(" end dataSource,");
            sqlList.Add(" case");
            sqlList.Add("    when pl.quantity2 is null then CAST(pl.quantity1*pd.proportionValue/(select sum(proportionValue) from proportionDetail where pid=pd.pid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0)) as decimal(38, 2))");
            sqlList.Add("	 else cast(pl.quantity2*pd.proportionValue/(select sum(proportionValue) from proportionDetail where pid=pd.pid)*(1+isnull((select rate from ullage u where u.mid=pd.mid),0))as decimal(38, 2))");
            sqlList.Add(" end consumption");

            #endregion


            sqlList.Add(",p.pnid,p.pmid,m.mnid,m.mmid,pl.eiid ");
            sqlList.Add("from proportionDetail pd,restructureAsphaltumProduceLog pl,product p,productName pn,productModel pm,material m,materialName mn,materialModel mm,equipmentName en,equipmentInformation ei ");
            sqlList.Add("where pd.pid=pl.pid and pl.pid2=p.id and p.pnid=pn.id and p.pmid=pm.id  ");
            sqlList.Add("and pd.mid=m.id and m.mnid=mn.id and m.mmid=mm.id and ei.enid=en.id and pl.eiid=ei.id  ");

            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlList.Add(sqlWhere);
            }

            sqlList.Add(" order by  pl.produceDate desc");

            dgv.DataSource = QueryForDataSet(sqlList).Tables[0];
        }

        /// <summary>
        /// 改性沥青消耗数据
        /// </summary>
        /// <param name="dgv">待绑定DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        public void rAsphaltumConsumeBind(DataGridView dgv, string sqlWhere)
        {
            sqlList = new ArrayList();

            sqlList.Add("select va.Date '日期',va.model '规格型号',sum(mixtureConsume) '混合料消耗' ");
            sqlList.Add(",sum(eAsphaltumConsume) '乳化沥青消耗'");
            sqlList.Add(",sum(consignmentConsume)  '直接销售出库'");
            sqlList.Add(",(select sum(vai.mixtureConsume)+sum(vai.eAsphaltumConsume)+sum(vai.consignmentConsume) from v_asphaltumConsume vai where vai.Date<=va.date and name='改性沥青' and vai.model=va.model) '总消耗量'");
            sqlList.Add(",(select sum(stockSuttle) from v_asphaltumConsume vai where vai.Date<=va.date and name='改性沥青' and vai.model=va.model)  '采购入库数量'");
            sqlList.Add(",(select sum(produceSuttle) from v_asphaltumConsume vai where vai.Date<=va.date and name='改性沥青' and vai.model=va.model) '生产量'");
            sqlList.Add(",(select sum(stockSuttle)+sum(produceSuttle)-(sum(vai.mixtureConsume)+sum(vai.eAsphaltumConsume)+sum(vai.consignmentConsume)) from v_asphaltumConsume vai where vai.Date<=va.date and name='改性沥青' and vai.model=va.model) '理论库存量'");
            sqlList.Add("from v_asphaltumConsume va ");
            sqlList.Add("where Date is not null and name='改性沥青' ");

            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlList.Add(sqlWhere);
            }

            sqlList.Add("  group by Date,model order by date desc;");

            dgv.DataSource = QueryForDataSet(sqlList).Tables[0];
        }

        /// <summary>
        /// 基质沥青消耗数据
        /// </summary>
        /// <param name="dgv">待绑定DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        public void AsphaltumConsumeBind(DataGridView dgv, string sqlWhere)
        {
            sqlList = new ArrayList();

            sqlList.Add("select va.Date '日期',va.model '规格型号',sum(mixtureConsume) '混合料消耗'  ");
            sqlList.Add(",sum(rAsphaltumConsume) '改性沥青消耗'");
            sqlList.Add(",sum(eAsphaltumConsume) '乳化沥青消耗'");
            sqlList.Add(",sum(consignmentConsume)  '直接销售出库'");
            sqlList.Add(",(select sum(vai.mixtureConsume)+sum(vai.eAsphaltumConsume)+sum(vai.consignmentConsume)+sum(vai.rAsphaltumConsume) from v_asphaltumConsume vai where vai.Date<=va.date and name='基质沥青' and vai.model=va.model) '总消耗量'");
            sqlList.Add(",(select sum(stockSuttle) from v_asphaltumConsume vai where vai.Date<=va.date and name='基质沥青' and vai.model=va.model)  '采购入库数量'");
            sqlList.Add(",(select sum(stockSuttle)-(sum(vai.mixtureConsume)+sum(vai.eAsphaltumConsume)+sum(vai.consignmentConsume)+sum(vai.rAsphaltumConsume)) from v_asphaltumConsume vai where vai.Date<=va.date and name='基质沥青' and vai.model=va.model) '理论库存量'");
            sqlList.Add("from v_asphaltumConsume va ");
            sqlList.Add("where Date is not null and name='基质沥青' ");

            if (!string.IsNullOrEmpty(sqlWhere))
            {
                sqlList.Add(sqlWhere);
            }

            sqlList.Add("  group by Date,model order by date desc;");

            dgv.DataSource = QueryForDataSet(sqlList).Tables[0];
        }

        public ArrayList ProduceLogBind(string sqlWhere,ProducePlan.pType type)
        {
            
            sqlList = new ArrayList();
            switch (type)
            {
                   
                case ProducePlan.pType.Mixture:
                    sqlList.Add("select pl.id,pn.name as pname,pm.model");
                    sqlList.Add(",coalesce(");
                    sqlList.Add("case when quantity2 is not null and quantity2!=0 then quantity2 end");
                    sqlList.Add(",case when quantity1 is not null and quantity1!=0 then quantity1 end");
                    sqlList.Add(") quantity ");
                    sqlList.Add(",case when quantity2 is not null and quantity2!=0 then '手动输入' else '自动采集' end Source");
                    sqlList.Add(",coalesce(");
                    sqlList.Add("case when quantity3 is not null and quantity3!=0 then quantity3 end");
                    sqlList.Add(",case when quantity2 is not null and quantity2!=0 then quantity2 end");
                    sqlList.Add(",case when quantity1 is not null and quantity1!=0 then quantity1 end");
                    sqlList.Add(") quantity3");
                    sqlList.Add(",Convert(varchar(10),pl.produceDate,120) as produceDate,en.name as ename,startMachineTime");
                    sqlList.Add(",stopMachineTime,pl.assessor,pl.checkupMan,pl.assessDate,pl.checkupDate,weather");
                    sqlList.Add(",coarseMaterialHydratedRate,refinedMaterialHydratedRate,tpId,ppid from mixtureProduceLog pl");
                    sqlList.Add(" ,equipmentInformation ei,equipmentName en,product p,productName pn,productModel pm");
                    sqlList.Add("  where ei.enid=en.id and pl.eiid=ei.id and pl.pid=p.id and p.pnid=pn.id and p.pmid=pm.id ");

                    if (!string.IsNullOrEmpty(sqlWhere))
                    {
                        sqlList.Add(sqlWhere);
                    }
                    sqlList.Add(" order by pl.inputDate desc;");
                    break;
                case ProducePlan.pType.EmulsificationAsphaltum:
                    sqlList.Add("select pl.id,pn.name as pname,pm.model");
                    sqlList.Add(",coalesce(");
                    sqlList.Add("case when quantity2 is not null and quantity2!=0 then quantity2 end");
                    sqlList.Add(",case when quantity1 is not null and quantity1!=0 then quantity1 end");
                    sqlList.Add(") quantity ");
                    sqlList.Add(",case when quantity2 is not null and quantity2!=0 then '手动输入' else '自动采集' end Source");
                    sqlList.Add(",coalesce(");
                    sqlList.Add("case when quantity3 is not null and quantity3!=0 then quantity3 end");
                    sqlList.Add(",case when quantity2 is not null and quantity2!=0 then quantity2 end");
                    sqlList.Add(",case when quantity1 is not null and quantity1!=0 then quantity1 end");
                    sqlList.Add(") quantity3");
                    sqlList.Add(",Convert(varchar(10),pl.produceDate,120) as produceDate,en.name as ename");
                    sqlList.Add(",startMachineTime,stopMachineTime,pl.assessor,pl.checkupMan,pl.assessDate,pl.checkupDate,weather,pl.pid from emulsificationAsphaltumProduceLog pl");
                    sqlList.Add(",equipmentInformation ei,equipmentName en,product p,productName pn,productModel pm ");
                    sqlList.Add(" where ei.enid=en.id and pl.eiid=ei.id and pl.pid2=p.id and p.pnid=pn.id and p.pmid=pm.id ");
                    
                    if (!string.IsNullOrEmpty(sqlWhere))
                    {
                        sqlList.Add(sqlWhere);
                    }
                    sqlList.Add(" order by pl.inputDate desc;");
                    break;
                case ProducePlan.pType.RestructureAsphaltum:
                    sqlList.Add("select pl.id,pn.name as pname,pm.model");
                    sqlList.Add(",coalesce(");
                    sqlList.Add("case when quantity2 is not null and quantity2!=0 then quantity2 end");
                    sqlList.Add(",case when quantity1 is not null and quantity1!=0 then quantity1 end");
                    sqlList.Add(") quantity ");
                    sqlList.Add(",case when quantity2 is not null and quantity2!=0 then '手动输入' else '自动采集' end Source");
                    sqlList.Add(",coalesce(");
                    sqlList.Add("case when quantity3 is not null and quantity3!=0 then quantity3 end");
                    sqlList.Add(",case when quantity2 is not null and quantity2!=0 then quantity2 end");
                    sqlList.Add(",case when quantity1 is not null and quantity1!=0 then quantity1 end");
                    sqlList.Add(") quantity3");
                    sqlList.Add(",Convert(varchar(10),pl.produceDate,120) as produceDate,en.name as ename");
                    sqlList.Add(",startMachineTime,stopMachineTime,pl.assessor,pl.checkupMan,pl.assessDate,pl.checkupDate,weather,pl.pid from restructureAsphaltumProduceLog pl");
                    sqlList.Add(",equipmentInformation ei,equipmentName en,product p,productName pn,productModel pm ");
                    sqlList.Add(" where ei.enid=en.id and pl.eiid=ei.id and pl.pid2=p.id and p.pnid=pn.id and p.pmid=pm.id ");
                    
                    if (!string.IsNullOrEmpty(sqlWhere))
                    {
                        sqlList.Add(sqlWhere);
                    }
                    sqlList.Add(" order by pl.inputDate desc;");
                    break;
                case ProducePlan.pType.AgainCalefaction:
                    sqlList.Add("select pl.id,pl.produceDate,en.name as ename");
                    sqlList.Add(",startMachineTime,stopMachineTime,pi.name as piname,pt.name as ptname");
                    sqlList.Add(",weather from againCalefactionProduceLog pl,equipmentInformation ei");
                    sqlList.Add(",personnelInfo pi,produceTeam pt");
                    sqlList.Add(",equipmentName en where pl.eiid=ei.id and pl.piid=pi.id and pl.ptid=pt.id and ei.enid=en.id ");
                    if (!string.IsNullOrEmpty(sqlWhere))
                    {
                        sqlList.Add(sqlWhere);
                    }
                    sqlList.Add(" order by pl.inputDate desc;");
                    break;
                default:
                    break;
    

            }
            return sqlList;
            
        }

        /// <summary>
        /// 根据用户选择条件查询获得查询条件字符串
        /// </summary>
        /// <param name="dtpStart">开始时间控件</param>
        /// <param name="dtpEnd">结束时间控件</param>
        /// <returns></returns>
        public string getAsphaltumConsumeSql(DateTimePicker dtpStart, DateTimePicker dtpEnd, ComboBox cmb_model)
        {
            StringBuilder SqlBuilder = new StringBuilder();
            if (dtpStart.Value == dtpEnd.Value)
            {
                SqlBuilder.Append(" and Date between '" + dtpStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd") + "' ");
            }
            else
            {
                SqlBuilder.Append(" and Date between '" + dtpStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpEnd.Value.ToString("yyyy-MM-dd") + "' ");
            }
            if (cmb_model != null)
            {
                if (cmb_model.SelectedIndex > -1)
                {
                    SqlBuilder.Append(" and model='"+cmb_model.Text.Trim()+"'"  );
                }
            }

            return SqlBuilder.ToString();
        }

        /// <summary>
        /// 根据用户选择条件查询获得查询条件字符串
        /// </summary>
        /// <param name="dtpStart">开始日期</param>
        /// <param name="dtpEnd">结束日期</param>
        /// <param name="cmb_name">产品名称</param>
        /// <param name="cmb_model">产品规格</param>
        /// <returns></returns>
        public string getNoticeSqlString(DateTimePicker dtpStart, DateTimePicker dtpEnd, ComboBox cmb_name, ComboBox cmb_model)
        {
            StringBuilder SqlBuilder = new StringBuilder();
            if (dtpStart.Value == dtpEnd.Value)
            {
                SqlBuilder.Append(" and notifyDate between '" + dtpStart.Value.ToShortDateString().ToString() + "' and '" + dtpEnd.Value.AddDays(1).ToShortDateString().ToString() + "' ");
            }
            else
            {
                SqlBuilder.Append(" and notifyDate between '" + dtpStart.Value.ToShortDateString().ToString() + "' and '" + dtpEnd.Value.ToShortDateString().ToString() + "' ");
            }

            if (cmb_name.SelectedIndex > -1)
            {
                SqlBuilder.Append(" and pnid=" + cmb_name.SelectedValue.ToString());
            }
            if (cmb_model.SelectedIndex > -1)
            {
                SqlBuilder.Append(" and pmid=" + cmb_model.SelectedValue.ToString());
            }





            return SqlBuilder.ToString();
        }

        /// <summary>
        /// 根据用户选择条件查询获得查询条件字符串
        /// </summary>
        /// <param name="dtpStart">开始日期</param>
        /// <param name="dtpEnd">结束日期</param>
        /// <param name="cmb_name">产品名称</param>
        /// <param name="cmb_model">产品规格</param>
        /// <returns></returns>
        public string getProduceSqlString(DateTimePicker dtpStart, DateTimePicker dtpEnd, ComboBox cmb_name, ComboBox cmb_model, ComboBox cmb_equipment,ComboBox cmb_mname,ComboBox cmb_mmodel)
        {
            StringBuilder SqlBuilder = new StringBuilder();
            if (dtpStart != null && dtpEnd!=null)
            {
                if (dtpStart.Value == dtpEnd.Value)
                {
                    SqlBuilder.Append(" and pl.produceDate between '" + dtpStart.Value.ToShortDateString().ToString() + "' and '" + dtpEnd.Value.AddDays(1).ToShortDateString().ToString() + "' ");
                }
                else
                {
                    SqlBuilder.Append(" and pl.produceDate between '" + dtpStart.Value.ToShortDateString().ToString() + "' and '" + dtpEnd.Value.ToShortDateString().ToString() + "' ");
                }
            }
            if (cmb_name != null)
            {
                if (cmb_name.SelectedIndex > -1)
                {
                    SqlBuilder.Append(" and pnid=" + cmb_name.SelectedValue.ToString());
                }
            }
            if (cmb_model != null)
            {
                if (cmb_model.SelectedIndex > -1)
                {
                    SqlBuilder.Append(" and pmid=" + cmb_model.SelectedValue.ToString());
                }
            }
            if (cmb_equipment != null)
            {
                if (cmb_equipment.SelectedIndex > -1)
                {
                    SqlBuilder.Append(" and eiid=" + cmb_equipment.SelectedValue.ToString());
                }
            }
            if (cmb_mname != null)
            {
                if (cmb_mname.SelectedIndex > -1)
                {
                    SqlBuilder.Append(" and mnid=" + cmb_mname.SelectedValue.ToString());
                }
            }
            if (cmb_mmodel != null)
            {
                if (cmb_mmodel.SelectedIndex > -1)
                {
                    SqlBuilder.Append(" and mmid=" + cmb_mmodel.SelectedValue.ToString());
                }
            }





            return SqlBuilder.ToString();
        }

        /// <summary>
        /// 根据用户选择条件查询获得查询条件字符串
        /// </summary>
        /// <param name="dtpStart">开始日期</param>
        /// <param name="dtpEnd">结束日期</param>
        /// <returns></returns>
        public string getproduceMeasureSqlString(DateTimePicker dtpStart, DateTimePicker dtpEnd, ComboBox cmbE, ComboBox cbxC)
        {
            StringBuilder SqlBuilder = new StringBuilder();
            if (dtpStart != null && dtpEnd != null)
            {
                if (dtpStart.Value == dtpEnd.Value)
                {
                    SqlBuilder.Append(" and pmm.inputDate between '" + dtpStart.Value.ToShortDateString().ToString() + "' and '" + dtpEnd.Value.AddDays(1).ToShortDateString().ToString() + "' ");
                }
                else
                {
                    SqlBuilder.Append(" and pmm.inputDate between '" + dtpStart.Value.ToShortDateString().ToString() + "' and '" + dtpEnd.Value.ToShortDateString() + "' ");
                }
            }
            if (cmbE.SelectedValue != null)
            {
                SqlBuilder.Append(" and eiId=" + cmbE.SelectedValue.ToString());
            }

            if (!string.IsNullOrEmpty(cbxC.Text.Trim()))
            {
                if (cbxC.Text.Trim() == "合格")
                {
                    SqlBuilder.Append(" and result=1");
                }
                else
                {
                    SqlBuilder.Append(" and result=0");
                }
            }

            return SqlBuilder.ToString();
        }

        /// <summary>
        /// 模糊查询包含关键字的种类ID
        /// </summary>
        /// <param name="kindStr">模糊关键字</param>
        /// <returns>成功返回ID,失败抛出异常</returns>
        public string getProductKindId(string kindStr)
        {
            sqlList = new ArrayList();

            sqlList.Add("select id from ProductKind where sort like '%" + kindStr + "%'");

            DataSet ds=QueryForDataSet(sqlList);

            if (ds.Tables[0].Rows.Count ==1)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                throw new Exception("查询产品种类名称失败");
            }

        }

        /// <summary>
        /// 绑定沥青型号
        /// </summary>
        /// <param name="cmb_model">待绑定ComboBox</param>
        /// <param name="name">材料名称</param>
        public void consumeModelBind(ComboBox cmb_model, string name)
        {
            cmb_model.DataSource = QueryForDataSet(new ArrayList() {" select mm.id,mm.model from material m,materialName mn,materialModel mm where m.mnid=mn.id and m.mmid=mm.id and mn.name='"+name+"'"}).Tables[0];
            cmb_model.ValueMember = "id";
            cmb_model.DisplayMember = "model";
            cmb_model.SelectedIndex = -1;
        }

        public DataSet ConsumeDailyBind(string strWhere, ProducePlan.pType type)
        {
            sqlList = new ArrayList();
            sqlList = GetConsumeDailySql(strWhere, type);
            return QueryForDataSet(sqlList);
        }

        private ArrayList GetConsumeDailySql(string strWhere, ProducePlan.pType type)
        {
            sqlList = new ArrayList();
            switch (type)
            {
                case ProducePlan.pType.Mixture:
                    sqlList.Add("select drcds.id,eiid,p.pnid,p.pmid,Convert(varchar(10),drcds.produceDate,120) 生产日期  ");
                    sqlList.Add(",ei.no 设备编号,pn.name 产品名称,pm.model 规格型号,quantity '产品产量'");
                    sqlList.Add(",manHour 生产工时,mn.name 原料名称,mm.model 原料规格");
                    sqlList.Add(",case when fuelWastage2 is not null then fuelWastage2 else fuelWastage1 end 消耗,case when fuelWastage2 is not null then '手动' else '自动' end 数据来源");
                    sqlList.Add(",consumeCoulometry 电量消耗,consumeRate1 原料消耗率,consumeRate2 用电消耗率 ");
                    sqlList.Add("from dasherResourceConsumeDailyStatistics drcds left join  product p on drcds.pid=p.id ");
                    sqlList.Add("left join productName pn on p.pnid=pn.id left join productModel pm on p.pmid=pm.id ");
                    sqlList.Add("left join equipmentInformation ei on drcds.eiid=ei.id  ");
                    sqlList.Add("left join material m on drcds.mid=m.id ");
                    sqlList.Add("left join materialName mn on m.mnid=mn.id ");
                    sqlList.Add("left join materialModel mm on m.mmid=mm.id ");
                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        sqlList.Add(strWhere);
                    }
                    sqlList.Add(" order by drcds.produceDate desc;");
                    break;
                case ProducePlan.pType.EmulsificationAsphaltum:
                    sqlList.Add("select drcds.id,eiid,p.pnid,p.pmid,Convert(varchar(10),drcds.produceDate,120) 生产日期  ");
                    sqlList.Add(",ei.no 设备编号,pn.name 产品名称,pm.model 规格型号");
                    sqlList.Add(",case when quantity2 is not null then quantity2 else quantity1 end '产品产量'");
                    sqlList.Add(",case when quantity2 is not null then '手动录入' else '自动采集' end '数量来源'");
                    sqlList.Add(",manHour 生产工时,mn.name 原料名称,mm.model 原料规格");
                    sqlList.Add(",case when fuelWastage2 is not null then fuelWastage2 else fuelWastage1 end 消耗,case when fuelWastage2 is not null then '手动' else '自动' end 数据来源");
                    sqlList.Add(",consumeCoulometry 电量消耗,consumeRate1 原料消耗率,consumeRate2 用电消耗率 ");
                    sqlList.Add("from rebuildAsphaltConsumeDailyStatistics drcds left join  product p on drcds.pid=p.id ");
                    sqlList.Add("left join productName pn on p.pnid=pn.id left join productModel pm on p.pmid=pm.id ");
                    sqlList.Add("left join equipmentInformation ei on drcds.eiid=ei.id  ");
                    sqlList.Add("left join material m on drcds.mid=m.id ");
                    sqlList.Add("left join materialName mn on m.mnid=mn.id ");
                    sqlList.Add("left join materialModel mm on m.mmid=mm.id ");
                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        sqlList.Add(strWhere);
                    }
                    sqlList.Add(" order by drcds.produceDate desc;");
                    break;
                case ProducePlan.pType.RestructureAsphaltum:
                    sqlList.Add("select drcds.id,eiid,p.pnid,p.pmid,Convert(varchar(10),drcds.produceDate,120) 生产日期  ");
                    sqlList.Add(",ei.no 设备编号,pn.name 产品名称,pm.model 规格型号");
                    sqlList.Add(",case when quantity2 is not null then quantity2 else quantity1 end '产品产量'");
                    sqlList.Add(",case when quantity2 is not null then '手动录入' else '自动采集' end '数量来源'");
                    sqlList.Add(",manHour 生产工时,mn.name 原料名称,mm.model 原料规格");
                    sqlList.Add(",case when fuelWastage2 is not null then fuelWastage2 else fuelWastage1 end 消耗,case when fuelWastage2 is not null then '手动' else '自动' end 数据来源");
                    sqlList.Add(",consumeCoulometry 电量消耗,consumeRate1 原料消耗率,consumeRate2 用电消耗率 ");
                    sqlList.Add("from asphaltumConsumeDailyStatistics drcds left join  product p on drcds.pid=p.id ");
                    sqlList.Add("left join productName pn on p.pnid=pn.id left join productModel pm on p.pmid=pm.id ");
                    sqlList.Add("left join equipmentInformation ei on drcds.eiid=ei.id  ");
                    sqlList.Add("left join material m on drcds.mid=m.id ");
                    sqlList.Add("left join materialName mn on m.mnid=mn.id ");
                    sqlList.Add("left join materialModel mm on m.mmid=mm.id ");

                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        sqlList.Add(strWhere);
                    }
                    sqlList.Add(" order by drcds.produceDate desc;");
                    break;
                case ProducePlan.pType.deepFatConsume:
                    sqlList.Add("select drcds.id,eiid,Convert(varchar(10),drcds.produceDate,120) 生产日期    ");
                    sqlList.Add(",ei.no 设备编号,manHour 生产工时,mn.name 原料名称,mm.model 原料规格");
                    sqlList.Add(",case when fuelWastage2 is not null then fuelWastage2 else fuelWastage1 end 消耗,case when fuelWastage2 is not null then '手动' else '自动' end 数据来源");
                    sqlList.Add(",consumeCoulometry 电量消耗,consumeRate1 原料消耗率,consumeRate2 用电消耗率 ");
                    sqlList.Add("from deepFatConsumeDailyStatistics drcds  ");
                    sqlList.Add("left join equipmentInformation ei on drcds.eiid=ei.id  ");
                    sqlList.Add("left join material m on drcds.mid=m.id ");
                    sqlList.Add("left join materialName mn on m.mnid=mn.id ");
                    sqlList.Add("left join materialModel mm on m.mmid=mm.id ");

                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        sqlList.Add(strWhere);
                    }
                    sqlList.Add(" order by drcds.produceDate desc;");
                    break;
                case ProducePlan.pType.deepFatConsumeDetail:
                    sqlList.Add("select dfcds.id,dfcds.inputDate 日期,ei.no 设备编号 ");
                    sqlList.Add(",en.name 设备名称 ");
                    sqlList.Add(",dfcds.value 消耗量,pi.name 操作员,dfcds.remark 备注 ");
                    sqlList.Add("from deepFatConsumeDailyStatisticsDetail dfcds ");
                    sqlList.Add("left join equipmentInformation ei on dfcds.eiid=ei.id ");
                    sqlList.Add("left join equipmentName en on ei.enid=en.id ");
                    sqlList.Add("left join personnelInfo pi on pi.id=dfcds.piid ");


                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        sqlList.Add(strWhere);
                    }
                    sqlList.Add(" order by dfcds.inputDate desc;");
                    break;
                default:
                    break;
            }
            return sqlList;
        }

        /// <summary>
        /// 根据用户选择条件查询获得查询条件字符串
        /// </summary>
        /// <param name="dtpStart">开始日期</param>
        /// <param name="dtpEnd">结束日期</param>
        /// <param name="cmb_name">产品名称</param>
        /// <param name="cmb_model">产品规格</param>
        /// <param name="cmb_equipment">设备名称</param>
        /// <returns></returns>
        public string getConsumeDailySql(DateTimePicker dtpStart, DateTimePicker dtpEnd, ComboBox cmb_name, ComboBox cmb_model, ComboBox cmb_equipment)
        {
            StringBuilder SqlBuilder = new StringBuilder();
            if (dtpStart != null && dtpEnd != null)
            {
                if (dtpStart.Value == dtpEnd.Value)
                {
                    SqlBuilder.Append(" where drcds.produceDate between '" + dtpStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd") + "' ");
                }
                else
                {
                    SqlBuilder.Append(" where drcds.produceDate between '" + dtpStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpEnd.Value.ToString("yyyy-MM-dd") + "' ");
                }
            }
            if (cmb_name != null)
            {
                if (cmb_name.SelectedIndex > -1)
                {
                    SqlBuilder.Append(" and pnid=" + cmb_name.SelectedValue.ToString());
                }
            }
            if (cmb_model != null)
            {
                if (cmb_model.SelectedIndex > -1)
                {
                    SqlBuilder.Append(" and pmid=" + cmb_model.SelectedValue.ToString());
                }
            }
            if (cmb_equipment != null)
            {
                if (cmb_equipment.SelectedIndex > -1)
                {
                    SqlBuilder.Append(" and eiid=" + cmb_equipment.SelectedValue.ToString());
                }
            }
            return SqlBuilder.ToString();
        }

        /// <summary>
        /// 根据用户选择条件查询获得查询条件字符串
        /// </summary>
        /// <param name="dtpStart">开始日期</param>
        /// <param name="dtpEnd">结束日期</param>
        /// <returns></returns>
        public string getConsumeDailyDetailSql(DateTimePicker dtpStart, DateTimePicker dtpEnd)
        {
            StringBuilder SqlBuilder = new StringBuilder();
            if (dtpStart != null && dtpEnd != null)
            {
                if (dtpStart.Value == dtpEnd.Value)
                {
                    SqlBuilder.Append(" where dfcds.inputDate between '" + dtpStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd") + "' ");
                }
                else
                {
                    SqlBuilder.Append(" where dfcds.inputDate between '" + dtpStart.Value.ToString("yyyy-MM-dd") + "' and '" + dtpEnd.Value.ToString("yyyy-MM-dd") + "' ");
                }
            }
            return SqlBuilder.ToString();
        }
        /// <summary>
        /// 验证生产时间不重复
        /// </summary>
        /// <param name="Start">开机时间</param>
        /// <param name="End">关机时间</param>
        /// <returns>True:有重复的时间</returns>
        public bool CheckInterval(DateTime Start, DateTime End,string tableName)
        {
            DataTable dt=sqlHelper.QueryForDateSet("select * from " + tableName + " where startMachineTime between '" + Start.ToString() + "' and '" + End.ToString() + "' or stopMachineTime between '" + Start.ToString() + "' and '" + End.ToString() + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 生成产品入库SQl语句
        /// </summary>
        /// <param name="id">生产记录ID</param>
        /// <param name="type">生产记录类型</param>
        /// <returns></returns>
        public string GetInDepotSqlFromLog(long id,ProducePlan.pType type)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("INSERT INTO productInDepot(pId,number,unitPrice,eiId,inputMan,inputDate");
            sqlStr.Append(",computationMark,assessor,checkupMan,assessDate,checkupDate)");
            switch (type)
            {
                case ProducePlan.pType.Mixture:
                    sqlStr.Append(" select pId ");
                    sqlStr.Append(" ,coalesce(case when quantity3!=0 then quantity3 end,case when quantity2!=0 then quantity2 end,case when quantity1!=0 then quantity1 end) quantity  ");
                    sqlStr.Append(" ,p.planPrice,eiid,'自动入库',getdate(),1,'自动入库','自动入库',getdate(),getdate() ");
                    sqlStr.Append(" from mixtureProduceLog lg ");
                    sqlStr.Append(" inner join product  p on p.id=lg.pid  ");
                    break;
                case ProducePlan.pType.EmulsificationAsphaltum:
                    sqlStr.Append(" select pId2 ");
                    sqlStr.Append(" ,coalesce(case when quantity3!=0 then quantity3 end,case when quantity2!=0 then quantity2 end,case when quantity1!=0 then quantity1 end) quantity  ");
                    sqlStr.Append(" ,p.planPrice,eiid,'自动入库',getdate(),1,'自动入库','自动入库',getdate(),getdate() ");
                    sqlStr.Append(" from emulsificationAsphaltumProduceLog lg ");
                    sqlStr.Append(" inner join product  p on p.id=lg.pid2  ");
                    break;
                case ProducePlan.pType.RestructureAsphaltum:
                    sqlStr.Append(" select pId2 ");
                    sqlStr.Append(" ,coalesce(case when quantity3!=0 then quantity3 end,case when quantity2!=0 then quantity2 end,case when quantity1!=0 then quantity1 end) quantity  ");
                    sqlStr.Append(" ,p.planPrice,eiid,'自动入库',getdate(),1,'自动入库','自动入库',getdate(),getdate() ");
                    sqlStr.Append(" from restructureAsphaltumProduceLog lg ");
                    sqlStr.Append(" inner join product  p on p.id=lg.pid2  ");
                    break;
            }
            sqlStr.Append(" where lg.id='" + id .ToString()+ "' ");

            return sqlStr.ToString();
        }

        /// <summary>
        /// 生成产品出库SQl语句
        /// </summary>
        /// <param name="id">生产记录ID</param>
        /// <param name="type">生产记录类型</param>
        /// <returns></returns>
        public string GetOutDepotSqlFromLog(long id, ProducePlan.pType type)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("INSERT INTO materialOutDepot(mId,number,pid,eiId,inputMan,inputDate");
            sqlStr.Append(",computationMark,assessor,checkupMan,assessDate,checkupDate)");
            //sqlStr.Append(" select mid,cast(quantity*Proportion*(1+isnull((select top 1 rate from ullage u where u.mid=mid),0)) as decimal(38, 2) ) ");
            //袁宇修改
            sqlStr.Append(" select mid,cast(quantity*Proportion as decimal(38, 2) ) ");
            sqlStr.Append(" Proportion,pid,eiid,'自动出库',getdate(),1,'自动出库','自动出库',getdate(),getdate() from  ");
            switch (type)
            {
                case ProducePlan.pType.Mixture:
                    sqlStr.Append(" (select tpd.mid,tpd.tpid,tpd.targetProportionValue/(select sum(targetProportionValue)  ");
                    sqlStr.Append(" from targetProportionDetail where tpId=tpd.tpid) Proportion    ");
                    sqlStr.Append(" from targetProportionDetail tpd) Proportion  ");
                    sqlStr.Append(" ,(select id,pid,tpId ");
                    sqlStr.Append(" ,coalesce(case when quantity3!=0 then quantity3 end  ");
                    sqlStr.Append(" ,case when quantity2!=0 then quantity2 end ");
                    sqlStr.Append(",case when quantity1!=0 then quantity1 end) quantity ");
                    sqlStr.Append(",eiid from mixtureProduceLog) lg ");
                    break;
                case ProducePlan.pType.EmulsificationAsphaltum:
                    sqlStr.Append(" (select pd.mid,pd.pid as tpid,pd.proportionValue/(select sum(proportionValue)   ");
                    sqlStr.Append(" from proportionDetail where pId=pd.pid) Proportion      ");
                    sqlStr.Append(" from proportionDetail pd) Proportion   ");
                    sqlStr.Append(" ,(select id,pid2 pid,pid tpId ");
                    sqlStr.Append(" ,coalesce(case when quantity3!=0 then quantity3 end  ");
                    sqlStr.Append(" ,case when quantity2!=0 then quantity2 end ");
                    sqlStr.Append(",case when quantity1!=0 then quantity1 end) quantity ");
                    sqlStr.Append(",eiid from emulsificationAsphaltumProduceLog) lg ");
                    break;
                case ProducePlan.pType.RestructureAsphaltum:
                    sqlStr.Append(" (select pd.mid,pd.pid as tpid,pd.proportionValue/(select sum(proportionValue)   ");
                    sqlStr.Append(" from proportionDetail where pId=pd.pid) Proportion      ");
                    sqlStr.Append(" from proportionDetail pd) Proportion   ");
                    sqlStr.Append(" ,(select id,pid2 pid,pid tpId ");
                    sqlStr.Append(" ,coalesce(case when quantity3!=0 then quantity3 end  ");
                    sqlStr.Append(" ,case when quantity2!=0 then quantity2 end ");
                    sqlStr.Append(",case when quantity1!=0 then quantity1 end) quantity ");
                    sqlStr.Append(",eiid from restructureAsphaltumProduceLog) lg ");
                    break;
            }
            sqlStr.Append(" where lg.tpid=Proportion.tpid and id='" + id .ToString() + "' ");

            return sqlStr.ToString();
        }

        /// <summary>
        /// 查询材料需求
        /// </summary>
        /// <param name="ppid">生产计划ID</param>
        /// <returns></returns>
        public DataSet GetMaterialNeed(string ppid)
        {
            StringBuilder sqlstr = new StringBuilder();

            //sqlstr.Append(" select tpd.mid,mn.name,mm.model ");
            //sqlstr.Append(",cast(produceQuantity*Proportion as decimal(38, 2))quantity ");
            //sqlstr.Append(",cast(january*Proportion as decimal(38, 2))january");
            //sqlstr.Append(",cast(february*Proportion as decimal(38, 2)) february");
            //sqlstr.Append(",cast(march*Proportion as decimal(38, 2)) march");
            //sqlstr.Append(",cast(april*Proportion as decimal(38, 2)) april");
            //sqlstr.Append(",cast(may*Proportion as decimal(38, 2)) may");
            //sqlstr.Append(",cast(june*Proportion as decimal(38, 2)) june");
            //sqlstr.Append(",cast(july*Proportion as decimal(38, 2))july");
            //sqlstr.Append(",cast(august*Proportion as decimal(38, 2)) august");
            //sqlstr.Append(",cast(september*Proportion as decimal(38, 2))september");
            //sqlstr.Append(",cast(october*Proportion as decimal(38, 2))october");
            //sqlstr.Append(",cast(november*Proportion as decimal(38, 2))november");
            //sqlstr.Append(",cast(december*Proportion as decimal(38, 2))december");
            ////sqlstr.Append(",getdate() ");
            //sqlstr.Append(" from productionPlanDetail ppd");
            //sqlstr.Append(",(");
            //sqlstr.Append("	select tpd.tpId,mId,targetProportionValue value,'1' type from targetProportionDetail tpd");
            //sqlstr.Append("		union all");
            //sqlstr.Append("	select pd.pid tpid,mid,proportionValue value,'2' type from proportionDetail pd");
            //sqlstr.Append(") as tpd");
            //sqlstr.Append(",(");
            //sqlstr.Append("	select tpd.mid,tpd.tpid,tpd.targetProportionValue/(select sum(targetProportionValue) from targetProportionDetail where tpId=tpd.tpid) Proportion,'1' type from targetProportionDetail tpd");
            //sqlstr.Append("	union all");
            //sqlstr.Append("	select pd.mid,pd.pid as tpid,pd.proportionValue/(select sum(proportionValue) from proportionDetail where pId=pd.pid) Proportion,'2' type from proportionDetail pd");
            //sqlstr.Append(") as Proportion");
            //sqlstr.Append(",(");
            //sqlstr.Append("	select p.id,sort from product p,productName pn,productKind pk where p.pnid=pn.id and pn.pkid=pk.id");
            //sqlstr.Append(") as p ,material m,materialName mn,materialModel mm ");
            //sqlstr.Append("where ppd.tpid=tpd.tpid and ppd.tpid=Proportion.tpid and tpd.mid=Proportion.mid and ppd.pid=p.id ");
            //sqlstr.Append(" and tpd.mid=m.id and m.mnid=mn.id and m.mmid=mm.id ");
            //sqlstr.Append("and Proportion.type=(select case when p.sort='混合料' then 1 else 2 end) ");
            //sqlstr.Append("and tpd.type=(select case when p.sort='混合料' then 1 else 2 end) ");
            //sqlstr.Append("and ppid="+ppid);
            sqlstr.Append(" select mn.name,mm.model ,");
            sqlstr.Append("sum(cast(produceQuantity*Proportion as decimal(38, 2)))quantity,");
            sqlstr.Append("sum(cast(january*Proportion as decimal(38, 2)))january ,");
            sqlstr.Append("sum(cast(february*Proportion as decimal(38, 2))) february,");
            sqlstr.Append("sum(cast(march*Proportion as decimal(38, 2))) march,");
            sqlstr.Append("sum(cast(april*Proportion as decimal(38, 2))) april,");
            sqlstr.Append("sum(cast(may*Proportion as decimal(38, 2))) may,");
            sqlstr.Append("sum(cast(june*Proportion as decimal(38, 2))) june,");
            sqlstr.Append("sum(cast(july*Proportion as decimal(38, 2))) july,");
            sqlstr.Append("sum(cast(august*Proportion as decimal(38, 2))) august,");
            sqlstr.Append("sum(cast(september*Proportion as decimal(38, 2)))september,");
            sqlstr.Append("sum(cast(october*Proportion as decimal(38, 2))) october,");
            sqlstr.Append("sum(cast(november*Proportion as decimal(38, 2)))november,");
            sqlstr.Append("sum(cast(december*Proportion as decimal(38, 2)))december ");
            sqlstr.Append("from productionPlanDetail ppd,");
            sqlstr.Append("(	select tpd.tpId,mId,targetProportionValue value,");
            sqlstr.Append("'1' type from targetProportionDetail tpd		union all	");
            sqlstr.Append("select pd.pid tpid,mid,proportionValue value,'2' type from proportionDetail pd) as tpd,");
            sqlstr.Append("(	select tpd.mid,tpd.tpid,tpd.targetProportionValue/(select sum(targetProportionValue) from targetProportionDetail where tpId=tpd.tpid) Proportion,");
            sqlstr.Append("'1' type from targetProportionDetail tpd	union all	");
            sqlstr.Append("select pd.mid,pd.pid as tpid,pd.proportionValue/(select sum(proportionValue) from proportionDetail where pId=pd.pid) Proportion,");
            sqlstr.Append("'2' type from proportionDetail pd) as Proportion,(	select p.id,sort from product p,productName pn,productKind pk where p.pnid=pn.id and pn.pkid=pk.id) as p ,material m,materialName mn,materialModel mm ");
            sqlstr.Append("where ppd.tpid=tpd.tpid and ppd.tpid=Proportion.tpid and tpd.mid=Proportion.mid and ppd.pid=p.id  and tpd.mid=m.id and m.mnid=mn.id and m.mmid=mm.id and Proportion.type=(select case when p.sort='混合料' then 1 else 2 end) and tpd.type=(select case when p.sort='混合料' then 1 else 2 end) ");
            sqlstr.Append(" and ppid="+ppid);
            sqlstr.Append(" group by name,model ");
            return sqlHelper.QueryForDateSet(sqlstr.ToString());



        }
    }

    public class ProduceNoticeAction
    {
        /// <summary>
        /// 根据实体类获取S插入字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetInsertSql(ProduceNotice model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into produceNotice(");
            strSql.Append("spId,planQuantity,startDate,ptId,notifyDate,inputDate,remark,notifyMan,inputMan");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + model.spId+ "',");
            strSql.Append("" + model.planQuantity + ",");
            strSql.Append("'" + model.startDate + "',");
            strSql.Append("" + model.ptId + ",");
            strSql.Append("'" + model.notifyDate + "',");
            strSql.Append("'" + model.inputDate + "',");
            strSql.Append("'" + model.remark + "',");
            strSql.Append("'" + model.notifyMan + "',");
            strSql.Append("'" + model.inputMan + "'");
            strSql.Append(")");
            strSql.Append(";declare  @pId int");
            strSql.Append(";set @pId=@@IDENTITY;");

            return strSql.ToString();
        }

        /// <summary>
        /// 根据实体类获取SQL更新字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetUpdateSql(ProduceNotice model)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update produceNotice set ");
            if (model.spId != null) { strSql.Append("spId=" + model.spId + ","); }
            if (model.planQuantity != null) { strSql.Append("planQuantity=" + model.planQuantity + ","); }
            if (model.startDate != null) { strSql.Append("startDate='" + model.startDate + "',"); }
            if (model.ptId != null) { strSql.Append("ptId=" + model.ptId + ","); }
            if (model.notifyDate != null) { strSql.Append("notifyDate='" + model.notifyDate + "',"); }
            if (model.inputDate != null) { strSql.Append("inputDate='" + model.inputDate + "',"); }
            if (model.remark != null) { strSql.Append("remark='" + model.remark + "',"); }
            if (model.notifyMan != null) { strSql.Append("notifyMan='" + model.notifyMan + "',"); }
            if (model.inputMan != null) { strSql.Append("inputMan='" + model.inputMan + "'"); }
            if (model.id != null) { strSql.Append(" where id=" + model.id + " "); }
      
            return strSql.ToString();
        }
    }

    public class SendProportionAction
    {
        /// <summary>
        /// 根据实体类获取SQL插入字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetInsertSql(SendProportion model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sendProportion(");
            strSql.Append("inputMan,inputDate,remark,confirm,confirmDate");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + model.inputMan + "',");
            strSql.Append("'" + model.inputDate + "',");
            strSql.Append("'" + model.remark + "',");
            strSql.Append("0,");
            strSql.Append("'" + model.confirmDate + "'");
            strSql.Append(")");
            strSql.Append(";declare  @spId int");
            strSql.Append(";set @spId=@@IDENTITY;");

            return strSql.ToString();
        }

        /// <summary>
        /// 根据实体类获取SQL更新字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        /// 
        public string GetUpdateSql(SendProportion model)
        {

            StringBuilder strSql = new StringBuilder();

            strSql.Append("update sendProportion set ");

            //if (model.inputMan != null) { strSql.Append("inputMan='" + model.inputMan + "',"); }
            //if (model.inputDate != null) { strSql.Append("inputDate='" + model.inputDate + "',"); }
            //if (model.remark != null) { strSql.Append("remark='" + model.remark + "',"); }
             strSql.Append("confirmDate=getdate(),"); 
             strSql.Append("confirm=1"); 



            strSql.Append(" where id=" + model.id + " ;");
            return strSql.ToString();
        }

       
    }

    public class ProduceSendProportionDetailAction
    {
        /// <summary>
        /// 根据实体类获取S插入字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetInsertSql(ProduceSendProportionDetail model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into produceSendProportionDetail(");
            strSql.Append("ppId,eiId,spId");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.ppId + ",");
            strSql.Append("" + model.eiId + ",");
            strSql.Append("@spId");
            strSql.Append(");");


            return strSql.ToString();
        }
    }

    public class TargetSendProportionDetailAction
    {
        /// <summary>
        /// 根据实体类获取S插入字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetInsertSql(TargetSendProportionDetail model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into targetSendProportionDetail(");
            strSql.Append("tpId,eiId,spId");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.tpId + ",");
            strSql.Append("" + model.eiId + ",");
            strSql.Append("@spId");
            strSql.Append(");");


            return strSql.ToString();
        }
    }

    public class SendProportionDetailAction
    {
        /// <summary>
        /// 根据实体类获取SQL插入字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetInsertSql(SendProportionDetail model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sendProportionDetail(");
            strSql.Append("pId,eiId,spId");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("" + model.pId + ",");
            strSql.Append("" + model.eiId + ",");
            strSql.Append("@spid");
            strSql.Append(")");


            return strSql.ToString();
        }
    }

    public class MixtureProduceLogAction
    {
        /// <summary>
        /// 根据实体类获取SQL插入字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetInsertSql(MixtureProduceLog model)
        {

            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.startMachineTime != null)
            {
                strSql1.Append("startMachineTime,");
                strSql2.Append("'" + model.startMachineTime + "',");
            }
            if (model.pId != null)
            {
                strSql1.Append("pId,");
                strSql2.Append("" + model.pId + ",");
            }
            if (model.tpId != null)
            {
                strSql1.Append("tpId,");
                strSql2.Append("" + model.tpId + ",");
            }
            if (model.ppId != null)
            {
                strSql1.Append("ppId,");
                strSql2.Append("" + model.ppId + ",");
            }
            if (model.eiId != null)
            {
                strSql1.Append("eiId,");
                strSql2.Append("" + model.eiId + ",");
            }
            if (model.quantity1 != null)
            {
                strSql1.Append("quantity1,");
                strSql2.Append("" + model.quantity1 + ",");
            }
            if (model.quantity2 != null)
            {
                strSql1.Append("quantity2,");
                strSql2.Append("" + model.quantity2 + ",");
            }
            if (model.inputDate != null)
            {
                strSql1.Append("inputDate,");
                strSql2.Append("'" + model.inputDate + "',");
            }
            if (model.inputMan != null)
            {
                strSql1.Append("inputMan,");
                strSql2.Append("'" + model.inputMan + "',");
            }
            if (model.stopMachineTime != null)
            {
                strSql1.Append("stopMachineTime,");
                strSql2.Append("'" + model.stopMachineTime + "',");
            }
            if (model.produceDate != null)
            {
                strSql1.Append("produceDate,");
                strSql2.Append("'" + model.produceDate + "',");
            }
            if (model.weather != null)
            {
                strSql1.Append("weather,");
                strSql2.Append("'" + model.weather + "',");
            }
            if (model.coarseMaterialHydratedRate != null)
            {
                strSql1.Append("coarseMaterialHydratedRate,");
                strSql2.Append("" + model.coarseMaterialHydratedRate + ",");
            }
            if (model.refinedMaterialHydratedRate != null)
            {
                strSql1.Append("refinedMaterialHydratedRate,");
                strSql2.Append("" + model.refinedMaterialHydratedRate + ",");
            }
            if (model.morningTemperature != null)
            {
                strSql1.Append("morningTemperature,");
                strSql2.Append("" + model.morningTemperature + ",");
            }
            if (model.noonTemperature != null)
            {
                strSql1.Append("noonTemperature,");
                strSql2.Append("" + model.noonTemperature + ",");
            }
            if (model.nightTemperature != null)
            {
                strSql1.Append("nightTemperature,");
                strSql2.Append("" + model.nightTemperature + ",");
            }
            if (model.ptId != null)
            {
                strSql1.Append("ptId,");
                strSql2.Append("" + model.ptId + ",");
            }
            if (model.total != null)
            {
                strSql1.Append("total,");
                strSql2.Append("" + model.total + ",");
            }
            if (model.remark != null)
            {
                strSql1.Append("remark,");
                strSql2.Append("'" + model.remark + "',");
            }
            if (model.quantity3 != null)
            {
                strSql1.Append("quantity3,");
                strSql2.Append("" + model.quantity3 + ",");
            }
            else if (model.quantity2 != null)
            {
                strSql1.Append("quantity3,");
                strSql2.Append("" + model.quantity2 + ",");
            }
            else
            {
                strSql1.Append("quantity3,");
                strSql2.Append("" + model.quantity1 + ",");
            }
            strSql.Append("insert into mixtureProduceLog(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");


            return strSql.ToString();
        }

        /// <summary>
        /// 根据实体类获取SQL删除字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetDeleteSql(string plId)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" delete from mixtureProduceLog where id=" + plId);

            return strSql.ToString();
        }
    }

    public class EmulsificationAsphaltumProduceLogAction
    {
        /// <summary>
        /// 根据实体类获取SQL插入字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetInsertSql(EmulsificationAsphaltumProduceLog model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.eiId != null)
            {
                strSql1.Append("eiId,");
                strSql2.Append("" + model.eiId + ",");
            }
            if (model.produceDate != null)
            {
                strSql1.Append("produceDate,");
                strSql2.Append("'" + model.produceDate + "',");
            }
            if (model.startMachineTime != null)
            {
                strSql1.Append("startMachineTime,");
                strSql2.Append("'" + model.startMachineTime + "',");
            }
            if (model.stopMachineTime != null)
            {
                strSql1.Append("stopMachineTime,");
                strSql2.Append("'" + model.stopMachineTime + "',");
            }
            if (model.pId2 != null)
            {
                strSql1.Append("pId2,");
                strSql2.Append("" + model.pId2 + ",");
            }
            if (model.pId != null)
            {
                strSql1.Append("pId,");
                strSql2.Append("" + model.pId + ",");
            }
            if (model.quantity1 != null)
            {
                strSql1.Append("quantity1,");
                strSql2.Append("" + model.quantity1 + ",");
            }
            if (model.quantity2 != null)
            {
                strSql1.Append("quantity2,");
                strSql2.Append("" + model.quantity2 + ",");
            }
            if (model.ptId != null)
            {
                strSql1.Append("ptId,");
                strSql2.Append("" + model.ptId + ",");
            }
            if (model.weather != null)
            {
                strSql1.Append("weather,");
                strSql2.Append("'" + model.weather + "',");
            }
            if (model.inputDate != null)
            {
                strSql1.Append("inputDate,");
                strSql2.Append("'" + model.inputDate + "',");
            }
            if (model.inputMan != null)
            {
                strSql1.Append("inputMan,");
                strSql2.Append("'" + model.inputMan + "',");
            }
            if (model.remark != null)
            {
                strSql1.Append("remark,");
                strSql2.Append("'" + model.remark + "',");
            }
            if (model.quantity3 != null)
            {
                strSql1.Append("quantity3,");
                strSql2.Append("" + model.quantity3 + ",");
            }
            else if (model.quantity2 != null)
            {
                strSql1.Append("quantity3,");
                strSql2.Append("" + model.quantity2 + ",");
            }
            else
            {
                strSql1.Append("quantity3,");
                strSql2.Append("" + model.quantity1 + ",");
            }
            if (model.assessor != null)
            {
                strSql1.Append("assessor,");
                strSql2.Append("'" + model.assessor + "',");
            }
            if (model.checkupMan != null)
            {
                strSql1.Append("checkupMan,");
                strSql2.Append("'" + model.checkupMan + "',");
            }
            if (model.assessDate != null)
            {
                strSql1.Append("assessDate,");
                strSql2.Append("'" + model.assessDate + "',");
            }
            if (model.checkupDate != null)
            {
                strSql1.Append("checkupDate,");
                strSql2.Append("'" + model.checkupDate + "',");
            }
            strSql.Append("insert into emulsificationAsphaltumProduceLog(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }

        /// <summary>
        /// 根据实体类获取SQL删除字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetDeleteSql(string plId)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" delete from EmulsificationAsphaltumProduceLog where id=" + plId);

            return strSql.ToString();
        }
    }

    public class RestructureAsphaltumProduceLogAction
    {
        /// <summary>
        /// 根据实体类获取SQL插入字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetInsertSql(RestructureAsphaltumProduceLog model)
        {

            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.eiId != null)
            {
                strSql1.Append("eiId,");
                strSql2.Append("" + model.eiId + ",");
            }
            if (model.produceDate != null)
            {
                strSql1.Append("produceDate,");
                strSql2.Append("'" + model.produceDate + "',");
            }
            if (model.startMachineTime != null)
            {
                strSql1.Append("startMachineTime,");
                strSql2.Append("'" + model.startMachineTime + "',");
            }
            if (model.stopMachineTime != null)
            {
                strSql1.Append("stopMachineTime,");
                strSql2.Append("'" + model.stopMachineTime + "',");
            }
            if (model.pId2 != null)
            {
                strSql1.Append("pId2,");
                strSql2.Append("" + model.pId2 + ",");
            }
            if (model.pId != null)
            {
                strSql1.Append("pId,");
                strSql2.Append("" + model.pId + ",");
            }
            if (model.quantity1 != null)
            {
                strSql1.Append("quantity1,");
                strSql2.Append("" + model.quantity1 + ",");
            }
            if (model.quantity2 != null)
            {
                strSql1.Append("quantity2,");
                strSql2.Append("" + model.quantity2 + ",");
            }
            if (model.ptId != null)
            {
                strSql1.Append("ptId,");
                strSql2.Append("" + model.ptId + ",");
            }
            if (model.weather != null)
            {
                strSql1.Append("weather,");
                strSql2.Append("'" + model.weather + "',");
            }
            if (model.inputDate != null)
            {
                strSql1.Append("inputDate,");
                strSql2.Append("'" + model.inputDate + "',");
            }
            if (model.inputMan != null)
            {
                strSql1.Append("inputMan,");
                strSql2.Append("'" + model.inputMan + "',");
            }
            if (model.remark != null)
            {
                strSql1.Append("remark,");
                strSql2.Append("'" + model.remark + "',");
            }
            //if (model.computationMark != null)
            //{
                strSql1.Append("computationMark,");
                strSql2.Append("1,");
            //}
            if (model.quantity3 != null)
            {
                strSql1.Append("quantity3,");
                strSql2.Append("" + model.quantity3 + ",");
            }
            else if (model.quantity2 != null)
            {
                strSql1.Append("quantity3,");
                strSql2.Append("" + model.quantity2 + ",");
            }
            else
            {
                strSql1.Append("quantity3,");
                strSql2.Append("" + model.quantity1 + ",");
            }
            if (model.assessor != null)
            {
                strSql1.Append("assessor,");
                strSql2.Append("'" + model.assessor + "',");
            }
            if (model.checkupMan != null)
            {
                strSql1.Append("checkupMan,");
                strSql2.Append("'" + model.checkupMan + "',");
            }
            if (model.assessDate != null)
            {
                strSql1.Append("assessDate,");
                strSql2.Append("'" + model.assessDate + "',");
            }
            if (model.checkupDate != null)
            {
                strSql1.Append("checkupDate,");
                strSql2.Append("'" + model.checkupDate + "',");
            }
            strSql.Append("insert into restructureAsphaltumProduceLog(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }

        /// <summary>
        /// 根据实体类获取SQL删除字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetDeleteSql(string plId)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" delete from RestructureAsphaltumProduceLog where id=" + plId);

            return strSql.ToString();
        }
    }

    public class AgainCalefactionProduceLogAction
    {
        /// <summary>
        /// 根据实体类获取SQL插入字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetInsertSql(AgainCalefactionProduceLog model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into againCalefactionProduceLog(");
            strSql.Append("produceDate,eiId,startMachineTime,stopMachineTime,piId,ptId,weather,inputDate,inputMan,remark");
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append("'" + model.produceDate + "',");
            strSql.Append("'" + model.eiId + "',");
            strSql.Append("'" + model.startMachineTime + "',");
            strSql.Append("'" + model.stopMachineTime + "',");
            strSql.Append("'" + model.piId + "',");
            strSql.Append("'" + model.ptId + "',");
            strSql.Append("'" + model.weather + "',");
            strSql.Append("'" + model.inputDate + "',");
            strSql.Append("'" + model.inputMan + "',");
            strSql.Append("'" + model.remark + "'");
            strSql.Append(")");
            return strSql.ToString();
        }

        /// <summary>
        /// 根据实体类获取SQL删除字符串
        /// </summary>
        /// <param name="model">实体类对象</param>
        /// <returns></returns>
        public string GetDeleteSql(string plId)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(" delete from AgainCalefactionProduceLog where id=" + plId);

            return strSql.ToString();
        }
    }

    public class DasherResourceConsumeDailyStatisticsAction
    {
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DasherResourceConsumeDailyStatistics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dasherResourceConsumeDailyStatistics set ");
            if (model.inputDate != null)
            {
                strSql.Append("inputDate='" + model.inputDate + "',");
            }
            if (model.eiId != null)
            {
                strSql.Append("eiId=" + model.eiId + ",");
            }
            if (model.pId != null)
            {
                strSql.Append("pId=" + model.pId + ",");
            }
            if (model.quantity != null)
            {
                strSql.Append("quantity=" + model.quantity + ",");
            }
            if (model.manHour != null)
            {
                strSql.Append("manHour=" + model.manHour + ",");
            }
            if (model.fuelWastage1 != null)
            {
                strSql.Append("fuelWastage1=" + model.fuelWastage1 + ",");
            }
            if (model.fuelWastage2 != null)
            {
                strSql.Append("fuelWastage2=" + model.fuelWastage2 + ",");
            }
            if (model.mId != null)
            {
                strSql.Append("mId=" + model.mId + ",");
            }
            if (model.consumeRate1 != null)
            {
                strSql.Append("consumeRate1=" + model.consumeRate1 + ",");
            }
            if (model.consumeRate2 != null)
            {
                strSql.Append("consumeRate2=" + model.consumeRate2 + ",");
            }
            if (model.consumeCoulometry != null)
            {
                strSql.Append("consumeCoulometry=" + model.consumeCoulometry + ",");
            }
            if (model.inputMan != null)
            {
                strSql.Append("inputMan='" + model.inputMan + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + " ");
            new SqlHelper().Update(new ArrayList() { strSql.ToString() });
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DasherResourceConsumeDailyStatistics GetModel(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,produceDate,eiId,pId,quantity,manHour,fuelWastage1,fuelWastage2,mId,consumeRate1,consumeRate2,consumeCoulometry,inputMan ");
            strSql.Append(" from dasherResourceConsumeDailyStatistics ");
            strSql.Append(" where id=" + id + " ");
            DasherResourceConsumeDailyStatistics model = new DasherResourceConsumeDailyStatistics();
            DataSet ds = new SqlHelper().QueryForDateSet(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["produceDate"].ToString() != "")
                {
                    model.inputDate = DateTime.Parse(ds.Tables[0].Rows[0]["inputDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["eiId"].ToString() != "")
                {
                    model.eiId = long.Parse(ds.Tables[0].Rows[0]["eiId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pId"].ToString() != "")
                {
                    model.pId = long.Parse(ds.Tables[0].Rows[0]["pId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["quantity"].ToString() != "")
                {
                    model.quantity = decimal.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["manHour"].ToString() != "")
                {
                    model.manHour = decimal.Parse(ds.Tables[0].Rows[0]["manHour"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuelWastage1"].ToString() != "")
                {
                    model.fuelWastage1 = decimal.Parse(ds.Tables[0].Rows[0]["fuelWastage1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuelWastage2"].ToString() != "")
                {
                    model.fuelWastage2 = decimal.Parse(ds.Tables[0].Rows[0]["fuelWastage2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mId"].ToString() != "")
                {
                    model.mId = long.Parse(ds.Tables[0].Rows[0]["mId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["consumeRate1"].ToString() != "")
                {
                    model.consumeRate1 = decimal.Parse(ds.Tables[0].Rows[0]["consumeRate1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["consumeRate2"].ToString() != "")
                {
                    model.consumeRate2 = decimal.Parse(ds.Tables[0].Rows[0]["consumeRate2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["consumeCoulometry"].ToString() != "")
                {
                    model.consumeCoulometry = decimal.Parse(ds.Tables[0].Rows[0]["consumeCoulometry"].ToString());
                }
                model.inputMan = ds.Tables[0].Rows[0]["inputMan"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
    }

    public class AsphaltumConsumeDailyStatisticsAction
    {
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(AsphaltumConsumeDailyStatistics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update asphaltumConsumeDailyStatistics set ");
            if (model.produceDate != null)
            {
                strSql.Append("produceDate='" + model.produceDate + "',");
            }
            if (model.eiId != null)
            {
                strSql.Append("eiId=" + model.eiId + ",");
            }
            if (model.pId != null)
            {
                strSql.Append("pId=" + model.pId + ",");
            }
            if (model.mId != null)
            {
                strSql.Append("mId=" + model.mId + ",");
            }
            if (model.quantity2 != null)
            {
                strSql.Append("quantity2=" + model.quantity2 + ",");
            }
            if (model.quantity1 != null)
            {
                strSql.Append("quantity1=" + model.quantity1 + ",");
            }
            if (model.manHour != null)
            {
                strSql.Append("manHour=" + model.manHour + ",");
            }
            if (model.fuelWastage1 != null)
            {
                strSql.Append("fuelWastage1=" + model.fuelWastage1 + ",");
            }
            if (model.fuelWastage2 != null)
            {
                strSql.Append("fuelWastage2=" + model.fuelWastage2 + ",");
            }
            if (model.consumeRate1 != null)
            {
                strSql.Append("consumeRate1=" + model.consumeRate1 + ",");
            }
            if (model.consumeRate2 != null)
            {
                strSql.Append("consumeRate2=" + model.consumeRate2 + ",");
            }
            if (model.consumeCoulometry != null)
            {
                strSql.Append("consumeCoulometry=" + model.consumeCoulometry + ",");
            }
            if (model.inputMan != null)
            {
                strSql.Append("inputMan='" + model.inputMan + "',");
            }
            if (model.inputDate != null)
            {
                strSql.Append("inputDate='" + model.inputDate + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + " ");
            new SqlHelper().Update(new ArrayList() { strSql.ToString() });
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AsphaltumConsumeDailyStatistics GetModel(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,produceDate,eiId,pId,quantity2,quantity1,manHour,fuelWastage1,fuelWastage2,consumeRate1,consumeRate2,consumeCoulometry,inputMan,inputDate ");
            strSql.Append(" from asphaltumConsumeDailyStatistics ");
            strSql.Append(" where id=" + id + " ");
            AsphaltumConsumeDailyStatistics model = new AsphaltumConsumeDailyStatistics();
            DataSet ds = new SqlHelper().QueryForDateSet(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["produceDate"].ToString() != "")
                {
                    model.produceDate = DateTime.Parse(ds.Tables[0].Rows[0]["produceDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["eiId"].ToString() != "")
                {
                    model.eiId = long.Parse(ds.Tables[0].Rows[0]["eiId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pId"].ToString() != "")
                {
                    model.pId = long.Parse(ds.Tables[0].Rows[0]["pId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["quantity2"].ToString() != "")
                {
                    model.quantity2 = decimal.Parse(ds.Tables[0].Rows[0]["quantity2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["quantity1"].ToString() != "")
                {
                    model.quantity1 = decimal.Parse(ds.Tables[0].Rows[0]["quantity1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["manHour"].ToString() != "")
                {
                    model.manHour = decimal.Parse(ds.Tables[0].Rows[0]["manHour"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuelWastage1"].ToString() != "")
                {
                    model.fuelWastage1 = decimal.Parse(ds.Tables[0].Rows[0]["fuelWastage1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuelWastage2"].ToString() != "")
                {
                    model.fuelWastage2 = decimal.Parse(ds.Tables[0].Rows[0]["fuelWastage2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["consumeRate1"].ToString() != "")
                {
                    model.consumeRate1 = decimal.Parse(ds.Tables[0].Rows[0]["consumeRate1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["consumeRate2"].ToString() != "")
                {
                    model.consumeRate2 = decimal.Parse(ds.Tables[0].Rows[0]["consumeRate2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["consumeCoulometry"].ToString() != "")
                {
                    model.consumeCoulometry = decimal.Parse(ds.Tables[0].Rows[0]["consumeCoulometry"].ToString());
                }
                model.inputMan = ds.Tables[0].Rows[0]["inputMan"].ToString();
                if (ds.Tables[0].Rows[0]["inputDate"].ToString() != "")
                {
                    model.inputDate = DateTime.Parse(ds.Tables[0].Rows[0]["inputDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }

    public class RebuildAsphaltConsumeDailyStatisticsAction
    {
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(RebuildAsphaltConsumeDailyStatistics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update rebuildAsphaltConsumeDailyStatistics set ");
            if (model.produceDate != null)
            {
                strSql.Append("produceDate='" + model.produceDate + "',");
            }
            if (model.eiId != null)
            {
                strSql.Append("eiId=" + model.eiId + ",");
            }
            if (model.pId != null)
            {
                strSql.Append("pId=" + model.pId + ",");
            }
            if (model.mId != null)
            {
                strSql.Append("mId=" + model.mId + ",");
            }
            if (model.quantity2 != null)
            {
                strSql.Append("quantity2=" + model.quantity2 + ",");
            }
            if (model.quantity1 != null)
            {
                strSql.Append("quantity1=" + model.quantity1 + ",");
            }
            if (model.manHour != null)
            {
                strSql.Append("manHour=" + model.manHour + ",");
            }
            if (model.consumeCoulometry != null)
            {
                strSql.Append("consumeCoulometry=" + model.consumeCoulometry + ",");
            }
            if (model.fuelWastage1 != null)
            {
                strSql.Append("fuelWastage1=" + model.fuelWastage1 + ",");
            }
            if (model.fuelWastage2 != null)
            {
                strSql.Append("fuelWastage2=" + model.fuelWastage2 + ",");
            }
            if (model.consumeRate1 != null)
            {
                strSql.Append("consumeRate1=" + model.consumeRate1 + ",");
            }
            if (model.consumeRate2 != null)
            {
                strSql.Append("consumeRate2=" + model.consumeRate2 + ",");
            }
            if (model.inputMan != null)
            {
                strSql.Append("inputMan='" + model.inputMan + "',");
            }
            if (model.inputDate != null)
            {
                strSql.Append("inputDate='" + model.inputDate + "',");
            }
            if (model.remark != null)
            {
                strSql.Append("remark='" + model.remark + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + " ");
            new SqlHelper().Update(new ArrayList() { strSql.ToString() });
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RebuildAsphaltConsumeDailyStatistics GetModel(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,produceDate,eiId,pId,quantity2,quantity1,manHour,consumeCoulometry,fuelWastage1,fuelWastage2,consumeRate1,consumeRate2,inputMan,inputDate,remark ");
            strSql.Append(" from rebuildAsphaltConsumeDailyStatistics ");
            strSql.Append(" where id=" + id + " ");
            RebuildAsphaltConsumeDailyStatistics model = new RebuildAsphaltConsumeDailyStatistics();
            DataSet ds = new SqlHelper().QueryForDateSet(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["produceDate"].ToString() != "")
                {
                    model.produceDate = DateTime.Parse(ds.Tables[0].Rows[0]["produceDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["eiId"].ToString() != "")
                {
                    model.eiId = long.Parse(ds.Tables[0].Rows[0]["eiId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pId"].ToString() != "")
                {
                    model.pId = long.Parse(ds.Tables[0].Rows[0]["pId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["quantity2"].ToString() != "")
                {
                    model.quantity2 = decimal.Parse(ds.Tables[0].Rows[0]["quantity2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["quantity1"].ToString() != "")
                {
                    model.quantity1 = decimal.Parse(ds.Tables[0].Rows[0]["quantity1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["manHour"].ToString() != "")
                {
                    model.manHour = decimal.Parse(ds.Tables[0].Rows[0]["manHour"].ToString());
                }
                if (ds.Tables[0].Rows[0]["consumeCoulometry"].ToString() != "")
                {
                    model.consumeCoulometry = decimal.Parse(ds.Tables[0].Rows[0]["consumeCoulometry"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuelWastage1"].ToString() != "")
                {
                    model.fuelWastage1 = decimal.Parse(ds.Tables[0].Rows[0]["fuelWastage1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuelWastage2"].ToString() != "")
                {
                    model.fuelWastage2 = decimal.Parse(ds.Tables[0].Rows[0]["fuelWastage2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["consumeRate1"].ToString() != "")
                {
                    model.consumeRate1 = decimal.Parse(ds.Tables[0].Rows[0]["consumeRate1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["consumeRate2"].ToString() != "")
                {
                    model.consumeRate2 = decimal.Parse(ds.Tables[0].Rows[0]["consumeRate2"].ToString());
                }
                model.inputMan = ds.Tables[0].Rows[0]["inputMan"].ToString();
                if (ds.Tables[0].Rows[0]["inputDate"].ToString() != "")
                {
                    model.inputDate = DateTime.Parse(ds.Tables[0].Rows[0]["inputDate"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
    }

    public class DeepFatConsumeDailyStatisticsAction
    {
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DeepFatConsumeDailyStatistics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update deepFatConsumeDailyStatistics set ");
            if (model.produceDate != null)
            {
                strSql.Append("produceDate='" + model.produceDate + "',");
            }
            if (model.eiId != null)
            {
                strSql.Append("eiId=" + model.eiId + ",");
            }
            if (model.manHour != null)
            {
                strSql.Append("manHour=" + model.manHour + ",");
            }
            if (model.fuelWastage1 != null)
            {
                strSql.Append("fuelWastage1=" + model.fuelWastage1 + ",");
            }
            if (model.fuelWastage2 != null)
            {
                strSql.Append("fuelWastage2=" + model.fuelWastage2 + ",");
            }
            if (model.mId != null)
            {
                strSql.Append("mId=" + model.mId + ",");
            }
            if (model.consumeRate1 != null)
            {
                strSql.Append("consumeRate1=" + model.consumeRate1 + ",");
            }
            if (model.consumeRate2 != null)
            {
                strSql.Append("consumeRate2=" + model.consumeRate2 + ",");
            }
            if (model.consumeCoulometry != null)
            {
                strSql.Append("consumeCoulometry=" + model.consumeCoulometry + ",");
            }
            if (model.inputMan != null)
            {
                strSql.Append("inputMan='" + model.inputMan + "',");
            }
            if (model.inputDate != null)
            {
                strSql.Append("inputDate='" + model.inputDate + "',");
            }
            if (model.remark != null)
            {
                strSql.Append("remark='" + model.remark + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + " ");
            new SqlHelper().Update(new ArrayList() { strSql.ToString() });
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DeepFatConsumeDailyStatistics GetModel(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,produceDate,eiId,manHour,fuelWastage1,fuelWastage2,mId,consumeRate1,consumeRate2,consumeCoulometry,inputMan,inputDate,remark ");
            strSql.Append(" from deepFatConsumeDailyStatistics ");
            strSql.Append(" where id=" + id + " ");
            DeepFatConsumeDailyStatistics model = new DeepFatConsumeDailyStatistics();
            DataSet ds = new SqlHelper().QueryForDateSet(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["produceDate"].ToString() != "")
                {
                    model.produceDate = DateTime.Parse(ds.Tables[0].Rows[0]["produceDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["eiId"].ToString() != "")
                {
                    model.eiId = long.Parse(ds.Tables[0].Rows[0]["eiId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["manHour"].ToString() != "")
                {
                    model.manHour = decimal.Parse(ds.Tables[0].Rows[0]["manHour"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuelWastage1"].ToString() != "")
                {
                    model.fuelWastage1 = decimal.Parse(ds.Tables[0].Rows[0]["fuelWastage1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fuelWastage2"].ToString() != "")
                {
                    model.fuelWastage2 = decimal.Parse(ds.Tables[0].Rows[0]["fuelWastage2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mId"].ToString() != "")
                {
                    model.mId = long.Parse(ds.Tables[0].Rows[0]["mId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["consumeRate1"].ToString() != "")
                {
                    model.consumeRate1 = decimal.Parse(ds.Tables[0].Rows[0]["consumeRate1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["consumeRate2"].ToString() != "")
                {
                    model.consumeRate2 = decimal.Parse(ds.Tables[0].Rows[0]["consumeRate2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["consumeCoulometry"].ToString() != "")
                {
                    model.consumeCoulometry = decimal.Parse(ds.Tables[0].Rows[0]["consumeCoulometry"].ToString());
                }
                model.inputMan = ds.Tables[0].Rows[0]["inputMan"].ToString();
                if (ds.Tables[0].Rows[0]["inputDate"].ToString() != "")
                {
                    model.inputDate = DateTime.Parse(ds.Tables[0].Rows[0]["inputDate"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
    }

    public class DeepFatConsumeDailyStatisticsDetailAction
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DeepFatConsumeDailyStatisticsDetail GetModel(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,eiId,fuelWastage,piId,inputMan,inputDate,remark ");
            strSql.Append(" from deepFatConsumeDailyStatisticsDetail ");
            strSql.Append(" where id=" + id + " ");
            DeepFatConsumeDailyStatisticsDetail model = new DeepFatConsumeDailyStatisticsDetail();
            DataSet ds = new SqlHelper().QueryForDateSet(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["eiId"].ToString() != "")
                {
                    model.eiId = long.Parse(ds.Tables[0].Rows[0]["eiId"].ToString());
                }
                //if (ds.Tables[0].Rows[0]["mId"].ToString() != "")
                //{
                //    model.mId = long.Parse(ds.Tables[0].Rows[0]["mId"].ToString());
                //}
                if (ds.Tables[0].Rows[0]["fuelWastage"].ToString() != "")
                {
                    model.fuelWastage = decimal.Parse(ds.Tables[0].Rows[0]["fuelWastage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["piId"].ToString() != "")
                {
                    model.piId = long.Parse(ds.Tables[0].Rows[0]["piId"].ToString());
                }
                model.inputMan = ds.Tables[0].Rows[0]["inputMan"].ToString();
                if (ds.Tables[0].Rows[0]["inputDate"].ToString() != "")
                {
                    model.inputDate = DateTime.Parse(ds.Tables[0].Rows[0]["inputDate"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DeepFatConsumeDailyStatisticsDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update deepFatConsumeDailyStatisticsDetail set ");
            if (model.eiId != null)
            {
                strSql.Append("eiId=" + model.eiId + ",");
            }
            if (model.mId != null)
            {
                strSql.Append("mId=" + model.mId + ",");
            }
            if (model.fuelWastage != null)
            {
                strSql.Append("fuelWastage=" + model.fuelWastage + ",");
            }
            if (model.piId != null)
            {
                strSql.Append("piId=" + model.piId + ",");
            }
            if (model.inputMan != null)
            {
                strSql.Append("inputMan='" + model.inputMan + "',");
            }
            if (model.inputDate != null)
            {
                strSql.Append("inputDate='" + model.inputDate + "',");
            }
            if (model.remark != null)
            {
                strSql.Append("remark='" + model.remark + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + " ");
            new SqlHelper().Update(new ArrayList() { strSql.ToString() });
        }


    }

    #region  //数据库操作类：生产参数

    /*
    * 类名称：ProductionParameterDB
    * 类功能描述：为“生产参数”提供数据库操作
    *
    * 创建人：关启学
    * 创建时间：2009-04-15
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

    class ProductionParameterDB
    {
        #region // 参数初始化部分

        // 用户“拌和站软件”的数据库操作
        private SqlHelper sqlHelper = new SqlHelper();


        // 生产参数 SQL字符串
        private string productionParameterSelectStr =
            "   SELECT "
            + "   equipmentInformation.no                   AS [equipmentNo],"      //设备编号
            + "   equipmentName.name                        AS [equipmentName],"    //设备名称
            + "   equipmentModel.model                      AS [equipmentModel],"   //设备规格
            + "   produceMeasureParameter.maxTemperature    AS [maxTemperature],"   //温度上限
            + "   produceMeasureParameter.minTemperature    AS [minTemperature],"   //温度下限
            + "   produceMeasureParameter.asphaltumError    AS [asphaltumError],"   //沥青偏差
            + "   produceMeasureParameter.stoneError        AS [stoneError],"       //石料偏差
            + "   produceMeasureParameter.mark              AS [mark],"             //使用标记（标明该条记录是否使用）


            + "   produceMeasureParameter.inputDate         AS [inputDate],"        //录入时间
            + "   produceMeasureParameter.inputMan          AS [inputMan],"         //录入人
            + "   produceMeasureParameter.id                AS [id],"               //id
            + "   produceMeasureParameter.eiId              AS [eiId]"              //设备信息表id
            + " FROM produceMeasureParameter, equipmentInformation, equipmentName, equipmentModel"
            + " WHERE produceMeasureParameter.eiId = equipmentInformation.id"
            + " AND   equipmentInformation.enId = equipmentName.id"
            + " AND   equipmentInformation.emId = equipmentModel.id";

        #endregion


        #region//用于填充“下拉列表”、与下拉列表相关控件数据的方法

        //查询“设备信息”：用于下拉列表
        public DataTable GetEquipmentInfo()
        {
            string selectString = "SELECT id, no FROM equipmentInformation";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“设备名称”，根据“设备id”
        public string GetEquipmentName(long enId)
        {
            string selectString =
                " SELECT equipmentName.name FROM equipmentName, equipmentInformation "
                + "WHERE equipmentName.id = equipmentInformation.enId AND equipmentInformation.id = " + enId;

            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            string name = "";
            if (dt.Rows.Count > 0)
            {
                name = dt.Rows[0]["name"].ToString();
            }

            return name;
        }

        //查询“设备规格”，根据“设备id”
        public string GetEquipmentModel(long emId)
        {
            string selectString =
                " SELECT equipmentModel.model FROM equipmentModel, equipmentInformation "
                + "WHERE equipmentModel.id = equipmentInformation.emId AND equipmentInformation.id = " + emId;

            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            string name = "";
            if (dt.Rows.Count > 0)
            {
                name = dt.Rows[0]["model"].ToString();
            }

            return name;
        }


        #endregion


        #region // 用于填充“DataGridView”数据内容的方法

        //查询“生产参数”
        public DataTable GetProductionParameter()
        {
            string select = productionParameterSelectStr + " ORDER BY produceMeasureParameter.inputDate DESC";
            return sqlHelper.QueryForDateSet(new ArrayList() { select }).Tables[0];
        }

        //查询“生产参数”，按“设备编号”查询
        public DataTable GetProductionParameterByNo(string equipmentNo)
        {
            string select = productionParameterSelectStr + " AND equipmentInformation.no LIKE '%" + equipmentNo + "%'"
                + " ORDER BY produceMeasureParameter.inputDate DESC";
            return sqlHelper.QueryForDateSet(new ArrayList() { select }).Tables[0];
        }

        //查询“生产参数”，按“设备名称”查询
        public DataTable GetProductionParameterByName(string equipmentName)
        {
            string select = productionParameterSelectStr + " AND equipmentName.name LIKE '%" + equipmentName + "%'"
                + " ORDER BY produceMeasureParameter.inputDate DESC";
            return sqlHelper.QueryForDateSet(new ArrayList() { select }).Tables[0];
        }

        //查询“生产参数”，按“设备名称”查询
        public DataTable GetProductionParameterByDate(DateTime dt)
        {
            string select = productionParameterSelectStr + " AND produceMeasureParameter.inputDate >= '" + dt
                + "' AND produceMeasureParameter.inputDate < '" + dt.AddDays(1) + "'"
                + " ORDER BY produceMeasureParameter.inputDate DESC";
            return sqlHelper.QueryForDateSet(new ArrayList() { select }).Tables[0];
        }

        #endregion


        #region//业务实体操作方法

        //插入新的“生产参数”
        public bool InsertProductionParameter(ProductionParameter productionParameter)
        {
            string insertStr =
                "   INSERT INTO produceMeasureParameter"
                + " (maxTemperature, minTemperature, asphaltumError, stoneError, mark, eiId, inputDate, inputMan)"
                + " VALUES"
                + " ({0},{1},{2},{3},'{4}',{5},getdate(),'{6}')";


            string sqlString = string.Format(insertStr, productionParameter.MaxTemperature, productionParameter.MinTemperature, productionParameter.AsphaltumError
                , productionParameter.StoneError, productionParameter.Mark, productionParameter.EiId, productionParameter.InputMan);
            return sqlHelper.ExecuteTransaction(new ArrayList() { sqlString });

        }

        //删除“生产参数”，根据生产参数id
        public void DeleteProductionParameter(long id)
        {
            string sqlString = "DELETE FROM produceMeasureParameter WHERE id = " + id;
            sqlHelper.ExecuteTransaction(new ArrayList() { sqlString });
        }

        #endregion

    }

    #endregion

}




