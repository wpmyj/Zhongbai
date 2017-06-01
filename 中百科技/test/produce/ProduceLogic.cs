using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using DasherStation.common;
using DasherStation.storage;

namespace DasherStation.produce
{
    class ProduceLogic
    {
        ProduceDB produceDb = new ProduceDB();
        SqlHelper sqlHelperObj = new SqlHelper();
        DataSet ds = new DataSet();
        /*
      * 方法名称：proSort
      * 方法功能描述：将产品种类赋值给Combobox
      *
      * 创建人：付中华
      * 创建时间：2009-2-25
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      */
        public void proSort(ComboBox cbx)
        {
            ds = produceDb.proSort();
            cbx.DataSource = ds.Tables[0];
            cbx.DisplayMember = "sort";
            cbx.ValueMember = "id";
            cbx.SelectedIndex = -1;
        }

        //产品名称
        public void proName(ComboBox cbx, string pkid)
        {
            ds = produceDb.proName(pkid);
            cbx.DataSource = ds.Tables[0];
            cbx.DisplayMember = "name";
            cbx.ValueMember = "id";
            cbx.SelectedIndex = -1;
        }

        //产品规格型号
        public void proType(ComboBox cbx, string pnid)
        {
            ds = produceDb.proType(pnid);
            cbx.DataSource = ds.Tables[0];
            cbx.DisplayMember = "model";
            cbx.ValueMember = "id";
            cbx.SelectedIndex = -1;
        }
        //目标配合比
        public void targetmp(ComboBox cbxKind, ComboBox cbx)
        {
            string kindName = cbxKind.Text.Trim();
            ds = produceDb.targetmp(kindName);
            cbx.DataSource = ds.Tables[0];
            cbx.DisplayMember = "id";
            cbx.ValueMember = "id";
            cbx.SelectedIndex = -1;
        }
        //制作人
        public void makerR(ComboBox cbx)
        {
            ds = produceDb.makerR();
            cbx.DataSource = ds.Tables[0];
            cbx.DisplayMember = "name";
            cbx.ValueMember = "id";
            cbx.SelectedIndex = -1;
        }
        //按日期查询生产计划
        public void frmproductShedule(string startyear, string endyear, DataGridView dgv)
        {
            ds = produceDb.frmproductShedule(startyear, endyear);
            dgv.DataSource = ds.Tables[0];
        }
        /*
       * 方法名称：productId
       * 方法功能描述：将生产配合比编号赋值给Combobox
       *
       * 创建人：付中华
       * 创建时间：2009-2-25
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       */
        public void productId(ComboBox cbx)
        {
            ds = produceDb.productId();
            cbx.DataSource = ds.Tables[0];
            cbx.DisplayMember = "id";
            cbx.ValueMember = "id";
        }
        /*
       * 方法名称：targetId
       * 方法功能描述：将目标配合比编号赋值给Combobox
       *
       * 创建人：付中华
       * 创建时间：2009-2-25
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       */
        public void targetId(ComboBox cbx)
        {
            ds = produceDb.targetId();
            cbx.DataSource = ds.Tables[0];
            cbx.DisplayMember = "id";
            cbx.ValueMember = "id";
        }
        //同时将生产计划主表和明细表保存到数据库中的方法 插入到两个表中
        public bool saveProScheduleAdd(productionSchedule proSchedule, List<productionScheduleDetail> list)
        {
            ArrayList sqllist = new ArrayList();
            sqllist.Add(produceDb.getInsertSqlps(proSchedule));
            foreach (productionScheduleDetail proScheduledetail in list)
            {
                sqllist.Add(produceDb.getInsertSqlpsd(proScheduledetail));
            }

            sqllist.Add(GetMaterialNeedPlanSql());

            return sqlHelperObj.ExecuteTransaction(sqllist);
        }

        private string GetMaterialNeedPlanSql()
        {
            StringBuilder sqlstr = new StringBuilder();
            sqlstr.Append(" insert into materialNeedPlan (mId,quantity,january,february,march,april,may,june,july,august,september,october,november,december,inputDate) ");
            sqlstr.Append(" select tpd.mid ");
            sqlstr.Append(",cast(produceQuantity*Proportion as decimal(38, 2))quantity ");
            sqlstr.Append(",cast(january*Proportion as decimal(38, 2))january");
            sqlstr.Append(",cast(february*Proportion as decimal(38, 2)) february");
            sqlstr.Append(",cast(march*Proportion as decimal(38, 2)) march");
            sqlstr.Append(",cast(april*Proportion as decimal(38, 2)) april");
            sqlstr.Append(",cast(may*Proportion as decimal(38, 2)) may");
            sqlstr.Append(",cast(june*Proportion as decimal(38, 2)) june");
            sqlstr.Append(",cast(july*Proportion as decimal(38, 2))july");
            sqlstr.Append(",cast(august*Proportion as decimal(38, 2)) august");
            sqlstr.Append(",cast(september*Proportion as decimal(38, 2))september");
            sqlstr.Append(",cast(october*Proportion as decimal(38, 2))october");
            sqlstr.Append(",cast(november*Proportion as decimal(38, 2))november");
            sqlstr.Append(",cast(december*Proportion as decimal(38, 2))december");
            sqlstr.Append(",getdate() ");
            sqlstr.Append(" from productionPlanDetail ppd");
            sqlstr.Append(",(");
            sqlstr.Append("	select tpd.tpId,mId,targetProportionValue value,'1' type from targetProportionDetail tpd");
            sqlstr.Append("		union all");
            sqlstr.Append("	select pd.pid tpid,mid,proportionValue value,'2' type from proportionDetail pd");
            sqlstr.Append(") as tpd");
            sqlstr.Append(",(");
            sqlstr.Append("	select tpd.mid,tpd.tpid,tpd.targetProportionValue/(select sum(targetProportionValue) from targetProportionDetail where tpId=tpd.tpid) Proportion,'1' type from targetProportionDetail tpd");
            sqlstr.Append("	union all");
            sqlstr.Append("	select pd.mid,pd.pid as tpid,pd.proportionValue/(select sum(proportionValue) from proportionDetail where pId=pd.pid) Proportion,'2' type from proportionDetail pd");
            sqlstr.Append(") as Proportion");
            sqlstr.Append(",(");
            sqlstr.Append("	select p.id,sort from product p,productName pn,productKind pk where p.pnid=pn.id and pn.pkid=pk.id");
            sqlstr.Append(") as p ");
            sqlstr.Append("where ppd.tpid=tpd.tpid and ppd.tpid=Proportion.tpid and tpd.mid=Proportion.mid and ppd.pid=p.id ");
            sqlstr.Append("and Proportion.type=(select case when p.sort='混合料' then 1 else 2 end) ");
            sqlstr.Append("and tpd.type=(select case when p.sort='混合料' then 1 else 2 end) ");
            sqlstr.Append("and ppid=@ppId ");

            return sqlstr.ToString();
        }
        //给生产计划明细表的datagridview添加行
        public void proScheDeAdd(productionScheduleDetail proShedDetail, DataTable dt, string prosort, string proname, string protype, string targetpm)
        {
            DataRow dr = dt.NewRow();
            //dr["id"] = proShedDetail.Id;
            dr["prosort"] = prosort;
            dr["name"] = proname;
            dr["model"] = protype;
            dr["measure"] = targetpm;
            dr["inputDate"] = proShedDetail.Inputdate;
            //dr["inputMan"] = proShedDetail.Inputman;
            dr["one"] = proShedDetail.January;
            dr["two"] = proShedDetail.February;
            dr["three"] = proShedDetail.March;
            dr["four"] = proShedDetail.April;
            dr["five"] = proShedDetail.May;
            dr["six"] = proShedDetail.June;
            dr["seven"] = proShedDetail.July;
            dr["eight"] = proShedDetail.August;
            dr["nine"] = proShedDetail.September;
            dr["ten"] = proShedDetail.October;
            dr["eleven"] = proShedDetail.November;
            dr["twelve"] = proShedDetail.December;
            dr["total"] = proShedDetail.Producequantity;

            dr["pid"] = proShedDetail.Pid;
            dr["tpid"] = proShedDetail.Tpid;

            dt.Rows.Add(dr);
        }
        //刷新生产计划主界面上的表
        public void getList(DataGridView dgv)
        {
            ds = produceDb.getList();
            dgv.DataSource = ds.Tables[0];
        }
        //刷新从表
        public void getListchild(string strwhere, DataGridView dgv)
        {
            ds = produceDb.getListchild(strwhere);
            dgv.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// 删除生产计划主表信息
        /// </summary>
        /// <param name="pId">生产计划ID</param>
        public bool productionDel(string pId)
        {
            return produceDb.ProductionDel(pId);
        }
    }

    public class Produce
    {
        ProduceDB produceDb = new ProduceDB();

        public int queryPid(string pNid, string pMid)
        {
            DataSet ds = produceDb.queryPid(pNid, pMid);

            if (ds.Tables[0].Rows.Count != 1)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }

        }

        public int queryMid(string mNid, string mMid)
        {
            DataSet ds = produceDb.queryMid(mNid, mMid);

            if (ds.Tables[0].Rows.Count != 1)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }

        }

        public void yearBind(ComboBox cmb)
        {

            int theYear = DateTime.Now.Year;
            for (int i = -10; i <= 10; i++)
            {
                cmb.Items.Add(theYear + i);
            }
            cmb.SelectedIndex = cmb.Items.IndexOf(theYear);

        }
    }

    /// <summary>
    /// 生产通知操作类
    /// </summary>
    public class ProducePlan
    {

        ArrayList sqlList = null;
        ProducePlanDB producePlanDB = new ProducePlanDB();

        ProductInDepotDB productInDepotDB = new ProductInDepotDB();

        /// <summary>
        /// 生产记录类型
        /// </summary>
        public enum pType
        {
            Mixture,// 混合料
            EmulsificationAsphaltum, // 乳化沥青
            RestructureAsphaltum, // 改性沥青
            AgainCalefaction, // 再加温
            deepFatConsume,// 热油炉
            deepFatConsumeDetail // 煤消耗明细
        }

        /// <summary>
        /// 目标配合必绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        /// <param name="pId">配合必编号</param>
        public void targetProportionBind(ComboBox cmb, string pId)
        {
            producePlanDB.targetProportionBind(cmb, pId);
        }

        /// <summary>
        /// 人员信息绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        /// <param name="ptId">生产班组ID</param>
        public void personInfoBind(ComboBox cmb, string ptId)
        {
            producePlanDB.personInfoBind(cmb, ptId);
        }

        /// <summary>
        /// 生产配合必绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        /// <param name="pId">配合必编号</param>
        public void produceProportionBind(ComboBox cmb, string pId)
        {
            producePlanDB.produceProportionBind(cmb, pId);
        }

        /// <summary>
        /// 生产配合比绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param> 
        public void produceProportionBind(ComboBox cmb)
        {
            producePlanDB.produceProportionBind(cmb);
        }

        /// <summary>
        /// 沥青配合比绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        /// <param name="pId">配合必编号</param>
        /// <param name="mark2">配合比类型 0:乳化沥青 1:改性沥青</param>
        public void proportionDetailBind(ComboBox cmb, string pId, int mark2)
        {
            producePlanDB.proportionDetailBind(cmb, pId, mark2);
        }

        /// <summary>
        /// 配合比明细绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="pId">配合比编号</param>
        public void proportionDetailBind(DataGridView dgv, string pId)
        {
            producePlanDB.proportionDetailBind(dgv, pId);
        }

        /// <summary>
        /// 产品种类绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void productKindBind(ComboBox cmb)
        {
            producePlanDB.productKindBind(cmb);
        }

        /// <summary>
        /// 产品名称绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void productNameBind(ComboBox cmb, string pkId)
        {
            producePlanDB.productNameBind(cmb, pkId);
        }

        /// <summary>
        /// 产品规格绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void productModelBind(ComboBox cmb, string pnId)
        {
            producePlanDB.productModelBind(cmb, pnId);
        }

        /// <summary>
        /// 材料种类绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void materialKindBind(ComboBox cmb)
        {
            producePlanDB.materialKindBind(cmb);
        }

        /// <summary>
        /// 材料名称绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void materialNameBind(ComboBox cmb, string mkId)
        {
            producePlanDB.materialNameBind(cmb, mkId);
        }

        /// <summary>
        /// 材料规格绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void materialModelBind(ComboBox cmb, string mnId)
        {
            producePlanDB.materialModelBind(cmb, mnId);
        }

        /// <summary>
        /// 机械设备绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void equipmentInfoBind(ComboBox cmb)
        {
            producePlanDB.equipmentInfoBind(cmb);
        }

        /// <summary>
        /// 生产班主绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void produceTeamBind(ComboBox cmb)
        {
            producePlanDB.produceTeamBind(cmb);
        }

        /// <summary>
        /// 人员信息绑定
        /// </summary>
        /// <param name="cmb">需要绑定的Combox</param>
        public void personnelInfoBind(ComboBox cmb, string ptId)
        {
            producePlanDB.personnelInfoBind(cmb, ptId);
        }

        /// <summary>
        /// 查询目标配合比
        /// </summary>
        /// <param name="tpId">目标配合比编号</param>
        /// <returns>DataSet</returns>
        public DataSet quaryTargetProportion(string tpId)
        {
            return producePlanDB.quaryTargetProportion(tpId);
        }

        /// <summary>
        /// 生产配合比绑定
        /// </summary>
        /// <param name="proportionTable">包含了指定热料仓信息TextBox的Panel</param>
        /// <param name="ppId">配合比编号</param>
        public void proportionBind(Panel proportionTable, string ppId)
        {
            producePlanDB.proportionBind(proportionTable, ppId);
        }

        /// <summary>
        /// 获取配合比
        /// </summary>
        /// <param name="proportionTable"></param>
        /// <returns></returns>
        public float getproduceMeasurTotal(Panel proportionTable)
        {
            return producePlanDB.getproduceMeasurTotal(proportionTable);
        }

        /// <summary>
        /// 获取骨料配合比误差最大值
        /// </summary>
        /// <returns></returns>
        public void getProportionError(out float ProportionError1, out float ProportionError2)
        {
            producePlanDB.getProportionError(out ProportionError1, out ProportionError2);
        }

        /// <summary>
        /// 目标配合比绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="tpId">配合比编号</param>
        public void targetBind(DataGridView dgv, string tpId)
        {
            producePlanDB.targetBind(dgv, tpId);
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
            return producePlanDB.saveProduceNotice(producenotice, sendproportion, producesendProportionDetail, targetsendProportionDetail, sendproportionDetail);
        }

        /// <summary>
        /// 保存生产记录
        /// </summary>
        /// <param name="mixtureProduceLog">生产记录对象</param>
        /// <returns></returns>
        public bool saveProduceLog(MixtureProduceLog mixtureProduceLog)
        {
            return producePlanDB.saveProduceLog(mixtureProduceLog);
        }

        /// <summary>
        /// 保存生产记录
        /// </summary>
        /// <param name="mixtureProduceLog">生产记录对象</param>
        /// <returns></returns>
        public bool saveProduceLog(RestructureAsphaltumProduceLog restructureAsphaltumProduceLog)
        {
            return producePlanDB.saveProduceLog(restructureAsphaltumProduceLog);
        }

        /// <summary>
        /// 保存生产记录
        /// </summary>
        /// <param name="mixtureProduceLog">生产记录对象</param>
        /// <returns></returns>
        public bool saveProduceLog(EmulsificationAsphaltumProduceLog emulsificationAsphaltumProduceLog)
        {
            return producePlanDB.saveProduceLog(emulsificationAsphaltumProduceLog);
        }

        /// <summary>
        /// 保存生产记录
        /// </summary>
        /// <param name="mixtureProduceLog">生产记录对象</param>
        /// <returns></returns>
        public bool saveProduceLog(AgainCalefactionProduceLog againCalefactionProduceLog)
        {
            return producePlanDB.saveProduceLog(againCalefactionProduceLog);
        }

        /// <summary>
        /// 删除生产通知单
        /// </summary>
        /// <param name="spId">发送配合比表ID</param>
        /// <returns>True:成功 False:失败</returns>
        public bool delProduceNotice(string pnId)
        {
            return producePlanDB.delProduceNotice(pnId);
        }

        /// <summary>
        /// 删除生产记录
        /// </summary>
        /// <param name="spId">生产记录ID</param>
        /// <returns>True:成功 False:失败</returns>
        public bool delProduceLog(string plId, pType type)
        {
            return producePlanDB.delProduceLog(plId, type);
        }

        /// <summary>
        /// 查询对应产品的ID
        /// </summary>
        /// <param name="pnId">名称ID</param>
        /// <param name="pmId">型号ID</param>
        /// <returns></returns>
        public int getPid(string pnId, string pmId)
        {
            return producePlanDB.getPid(pnId, pmId);
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
            producePlanDB.produceNoticeBind(dgv, dgv1, dgv2, sqlWhere);
        }

        /// <summary>
        /// 生产记录信息绑定
        /// </summary>
        /// <param name="dgv">对应DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        /// <param name="Type">类型枚举</param>
        public void ProduceLogBind(DataGridView dgv, string sqlWhere, pType type)
        {
            producePlanDB.ProduceLogBind(dgv, sqlWhere, type);
        }

        /// <summary>
        /// 配合比通知单信息绑定
        /// </summary>
        /// <param name="dgv">对应DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        /// <param name="Type">类型枚举</param>
        public void ProduceProportionBind(DataGridView dgv, string sqlWhere, pType type)
        {
            producePlanDB.ProduceProportionBind(dgv, sqlWhere, type);
        }

        /// <summary>
        /// 生产统计信息绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="sqlWhere">筛选查询语句</param>
        public void ProduceStatisticsBind(DataGridView dgv, string sqlWhere)
        {
            producePlanDB.ProduceStatisticsBind(dgv, sqlWhere);
        }

        /// <summary>
        /// 生产计量信息绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        public void produceMeasureBind(DataGridView dgv, string sqlWhere)
        {
            producePlanDB.produceMeasureBind(dgv, sqlWhere);
        }

        /// <summary>
        /// 原料消耗信息绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        public void produceMaterialConsumptionBind(DataGridView dgv, string sqlWhere)
        {
            producePlanDB.ProduceMaterialConsumptionBind(dgv, sqlWhere);
        }

        /// <summary>
        /// 能源消耗信息绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        /// <param name="Type">查询类型</param>
        public void produceEnergyConsumptionBind(DataGridView dgv, string sqlWhere, ProducePlan.pType type)
        {
            dgv.DataSource = producePlanDB.produceEnergyConsumptionBind(sqlWhere, type).Tables[0];
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
            return producePlanDB.getNoticeSqlString(dtpStart, dtpEnd, cmb_name, cmb_model);
        }

        /// <summary>
        /// 根据用户选择条件查询获得查询条件字符串
        /// </summary>
        /// <param name="dtpStart">开始日期</param>
        /// <param name="dtpEnd">结束日期</param>
        /// <param name="cmb_name">产品名称</param>
        /// <param name="cmb_model">产品规格</param>
        /// <returns></returns>
        public string getProduceSqlString(DateTimePicker dtpStart, DateTimePicker dtpEnd, ComboBox cmb_name, ComboBox cmb_model, ComboBox cmb_equipment, ComboBox cmb_mname, ComboBox cmb_mmodel)
        {
            return producePlanDB.getProduceSqlString(dtpStart, dtpEnd, cmb_name, cmb_model, cmb_equipment, cmb_mname, cmb_mmodel);
        }

        /// <summary>
        /// 根据用户选择条件查询获得查询条件字符串
        /// </summary>
        /// <param name="dtpStart">开始日期</param>
        /// <param name="dtpEnd">结束日期</param>
        /// <returns></returns>
        public string getproduceMeasureSqlString(DateTimePicker dtpStart, DateTimePicker dtpEnd, ComboBox cmbE,ComboBox cbxC)
        {
            return producePlanDB.getproduceMeasureSqlString(dtpStart, dtpEnd, cmbE, cbxC);
        }

        /// <summary>
        /// 获得种类ID
        /// </summary>
        /// <param name="kindStr">种类名称</param>
        /// <returns></returns>
        public string getProductKindId(string kindStr)
        {
            return producePlanDB.getProductKindId(kindStr);
        }

        /// <summary>
        /// 改性沥青消耗数据
        /// </summary>
        /// <param name="dgv">待绑定DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        public void rAsphaltumConsumeBind(DataGridView dgv, string sqlWhere)
        {
            producePlanDB.rAsphaltumConsumeBind(dgv, sqlWhere);
        }

        /// <summary>
        /// 基质沥青消耗数据
        /// </summary>
        /// <param name="dgv">待绑定DataGridView</param>
        /// <param name="sqlWhere">筛选条件</param>
        public void AsphaltumConsumeBind(DataGridView dgv, string sqlWhere)
        {
            producePlanDB.AsphaltumConsumeBind(dgv, sqlWhere);
        }

        /// <summary>
        /// 根据用户选择条件查询获得查询条件字符串
        /// </summary>
        /// <param name="dtpStart">开始时间控件</param>
        /// <param name="dtpEnd">结束时间控件</param>
        /// <returns></returns>
        public string getAsphaltumConsumeSql(DateTimePicker dtpStart, DateTimePicker dtpEnd, ComboBox cmb_model)
        {
            return producePlanDB.getAsphaltumConsumeSql(dtpStart, dtpEnd, cmb_model);
        }

        /// <summary>
        /// 绑定沥青型号
        /// </summary>
        /// <param name="cmb_model">待绑定ComboBox</param>
        /// <param name="name">材料名称</param>
        public void consumeModelBind(ComboBox cmb_model, string name)
        {
            producePlanDB.consumeModelBind(cmb_model, name);
        }

        /// <summary>
        /// 资源消耗日报表绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="strWhere">筛选条件</param>
        /// <param name="Type">消耗资源的生产类型</param>
        public void ConsumeDailyBind(DataGridView dgv, string strWhere, ProducePlan.pType type)
        {
            dgv.DataSource = producePlanDB.ConsumeDailyBind(strWhere, type).Tables[0];
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
            return producePlanDB.getConsumeDailySql(dtpStart, dtpEnd, cmb_name, cmb_model, cmb_equipment);
        }

        /// <summary>
        /// 根据用户选择条件查询获得查询条件字符串
        /// </summary>
        /// <param name="dtpStart">开始日期</param>
        /// <param name="dtpEnd">结束日期</param>
        /// <returns></returns>
        public string getConsumeDailyDetailSql(DateTimePicker dtpStart, DateTimePicker dtpEnd)
        {
            return producePlanDB.getConsumeDailyDetailSql(dtpStart, dtpEnd);
        }

        /// <summary>
        /// 获得一个实体类对象
        /// </summary>
        /// <param name="id">对象的ID</param>
        /// <returns></returns>
        public DasherResourceConsumeDailyStatistics GetDasherResourceConsumeDailyStatisticsObj(long id)
        {
            return new DasherResourceConsumeDailyStatisticsAction().GetModel(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="obj">实例对象</param>
        public void UpdateDasherResourceConsumeDailyStatistics(DasherResourceConsumeDailyStatistics obj)
        {
            new DasherResourceConsumeDailyStatisticsAction().Update(obj);
        }

        /// <summary>
        /// 获得一个实体类对象
        /// </summary>
        /// <param name="id">对象的ID</param>
        /// <returns></returns>
        public AsphaltumConsumeDailyStatistics GetAsphaltumConsumeDailyStatisticsObj(long id)
        {
            return new AsphaltumConsumeDailyStatisticsAction().GetModel(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="obj">实例对象</param>
        public void UpdateAsphaltumConsumeDailyStatistics(AsphaltumConsumeDailyStatistics obj)
        {
            new AsphaltumConsumeDailyStatisticsAction().Update(obj);
        }

        /// <summary>
        /// 获得一个实体类对象
        /// </summary>
        /// <param name="id">对象的ID</param>
        /// <returns></returns>
        public RebuildAsphaltConsumeDailyStatistics GetRebuildAsphaltConsumeDailyStatisticsObj(long id)
        {
            return new RebuildAsphaltConsumeDailyStatisticsAction().GetModel(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="obj">实例对象</param>
        public void UpdateRebuildAsphaltConsumeDailyStatistics(RebuildAsphaltConsumeDailyStatistics obj)
        {
            new RebuildAsphaltConsumeDailyStatisticsAction().Update(obj);
        }

        /// <summary>
        /// 获得一个实体类对象
        /// </summary>
        /// <param name="id">对象的ID</param>
        /// <returns></returns>
        public DeepFatConsumeDailyStatistics GetDeepFatConsumeDailyStatisticsObj(long id)
        {
            return new DeepFatConsumeDailyStatisticsAction().GetModel(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="obj">实例对象</param>
        public void UpdateDeepFatConsumeDailyStatistics(DeepFatConsumeDailyStatistics obj)
        {
            new DeepFatConsumeDailyStatisticsAction().Update(obj);
        }

        /// <summary>
        /// 获得一个实体类对象
        /// </summary>
        /// <param name="id">对象的ID</param>
        /// <returns></returns>
        public DeepFatConsumeDailyStatisticsDetail GetDeepFatConsumeDailyStatisticsDetailObj(long id)
        {
            return new DeepFatConsumeDailyStatisticsDetailAction().GetModel(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="obj">实例对象</param>
        public void UpdateDeepFatConsumeDailyStatisticsDetail(DeepFatConsumeDailyStatisticsDetail obj)
        {
            new DeepFatConsumeDailyStatisticsDetailAction().Update(obj);
        }

        ErrorProvider errorProviderStart;

        ErrorProvider errorProviderEnd;

        /// <summary>
        /// 验证生产时间
        /// </summary>
        /// <param name="dtp">生产日期控件</param>
        /// <param name="mtxtStart">开机时间</param>
        /// <param name="mtxtEnd">关机时间</param>
        /// <param name="tableName">记录表名</param>
        /// <returns></returns>
        public bool DateCheck(DateTimePicker dtp, MaskedTextBox mtxtStart, MaskedTextBox mtxtEnd, string tableName)
        {

            bool result = true; ;

            errorProviderStart = new ErrorProvider();
            errorProviderEnd = new ErrorProvider();

            mtxtStart.Enter += new EventHandler(TxtStart_Enter);
            mtxtEnd.Enter += new EventHandler(TxtEnd_Enter);

            //MessageBox.Show(mtxtStart.Text.Replace(" ", ""));

            if (!Check.CheckTime(mtxtStart.Text.Replace(" ", "")))
            {
                errorProviderStart.SetError(mtxtStart, "信息格式不正确");
                result = false;
            }

            if (!Check.CheckTime(mtxtEnd.Text.Replace(" ", "")))
            {
                errorProviderEnd.SetError(mtxtEnd, "信息格式不正确");
                result = false;
            }

            DateTime StartTime;

            DateTime.TryParse(dtp.Value.ToShortDateString() + " " + mtxtStart.Text, out StartTime);

            DateTime EndTime;

            DateTime.TryParse(dtp.Value.ToShortDateString() + " " + mtxtEnd.Text, out EndTime);


            if (StartTime.ToString() != "0001-1-1 0:00:00" && EndTime.ToString() != "0001-1-1 0:00:00")
            {
                if (StartTime > EndTime)
                {
                    errorProviderStart.SetError(mtxtStart, "开机时间不能晚于关机时间");
                    errorProviderEnd.SetError(mtxtEnd, "开机时间不能晚于关机时间");
                    result = false;
                }
                else if (producePlanDB.CheckInterval(StartTime, EndTime, tableName))
                {
                    errorProviderStart.SetError(mtxtStart, "该生产时间已存在于生产记录中");
                    errorProviderEnd.SetError(mtxtEnd, "该生产时间已存在于生产记录中");
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        private void TxtStart_Enter(object sender, EventArgs e)
        {
            errorProviderStart.Clear();
        }

        private void TxtEnd_Enter(object sender, EventArgs e)
        {
            errorProviderEnd.Clear();
        }

        /// <summary>
        /// 混合料生产记录审批后生成出入库单据
        /// </summary>
        /// <param name="auditing">审核对象</param>
        /// <param name="sqlHelper">数据库对象</param>
        public void AfterRecordConfirmInsert(Auditing auditing, SqlHelper sqlHelper)
        {
            sqlHelper.Insert(new ArrayList() { producePlanDB.GetInDepotSqlFromLog(auditing.Id,pType.Mixture) });
            sqlHelper.Insert(new ArrayList() { producePlanDB.GetOutDepotSqlFromLog(auditing.Id, pType.Mixture) }); 
        }

        /// <summary>
        /// 乳化沥青生产记录审批后生成出入库单据
        /// </summary>
        /// <param name="auditing">审核对象</param>
        /// <param name="sqlHelper">数据库对象</param>
        public void AfterRecordConfirmInsert1(Auditing auditing, SqlHelper sqlHelper)
        {
            sqlHelper.Insert(new ArrayList() { producePlanDB.GetInDepotSqlFromLog(auditing.Id, pType.EmulsificationAsphaltum) });
            sqlHelper.Insert(new ArrayList() { producePlanDB.GetOutDepotSqlFromLog(auditing.Id, pType.EmulsificationAsphaltum) });
        }

        /// <summary>
        /// 改性沥青生产记录审批后生成出入库单据
        /// </summary>
        /// <param name="auditing">审核对象</param>
        /// <param name="sqlHelper">数据库对象</param>
        public void AfterRecordConfirmInsert2(Auditing auditing, SqlHelper sqlHelper)
        {
            sqlHelper.Insert(new ArrayList() { producePlanDB.GetInDepotSqlFromLog(auditing.Id, pType.RestructureAsphaltum) });
            sqlHelper.Insert(new ArrayList() { producePlanDB.GetOutDepotSqlFromLog(auditing.Id, pType.RestructureAsphaltum) });
        } 

        /// <summary>
        /// 新增加汇总列
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="collectCol">要汇总的列名集合</param>
        public void Collect(DataTable dt, string[] collectCol)
        {
            DataRow dr = dt.NewRow();
            foreach (string colStr in collectCol)
            {
                decimal total = 0;
                decimal rowValue = 0;
                foreach (DataRow r in dt.Rows)
                {
                    rowValue = 0;
                    decimal.TryParse(r[colStr].ToString(), out rowValue);
                    total += rowValue;
                }
                dr[colStr] = total;
            }
            dt.Rows.Add(dr);
        }

        /// <summary>
        /// 查询材料需求列表
        /// </summary>
        /// <param name="dgv">待绑定DataGridView</param>
        /// <param name="ppid">生产计划ID</param>
        public void GetMaterialNeed(DataGridView dgv,string ppid)
        {
            dgv.DataSource=producePlanDB.GetMaterialNeed(ppid).Tables[0];
        }

        /// <summary>
        /// 打印拌合料生产记录
        /// </summary>
        /// <param name="id">记录ID</param>
        /// <param name="ppid">生产配合比编号</param>
        /// <param name="tpid">目标配合比ID</param>
        public void PrintRecordMix(long id, long ppid, long tpid)
        {
            ReportHelper reportServer = new ReportHelper();
            ReportData reportData = new ReportData();
            List<ReportSource> reportSourceList = new List<ReportSource>();

            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.produceTableAdapters.mixtureProduceLogTableAdapter", "mixtureProduceLog", new object[] { id }));
            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.produceTableAdapters.produceProportionTableAdapter", "produceProportion", new object[] { ppid }));
            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.produceTableAdapters.targetProportionTableAdapter", "targetProportion", new object[] { tpid }));



            reportData.DataSetName = "DasherStation.dataSet.produce";
            reportData.ReportName = "DasherStation.ReportDistrict.produceReport.MixtureProduceRecords.rdlc";

            reportData.ReportSourceList = reportSourceList;

            reportServer.ShowReport(reportData);
        }

        /// <summary>
        /// 打印乳化沥青生产记录
        /// </summary>
        /// <param name="id">记录ID</param>
        /// <param name="pid">生产配合比编号</param>
        public void PrintRecordRBitumen(long id, long pid)
        {
            ReportHelper reportServer = new ReportHelper();
            ReportData reportData = new ReportData();
            List<ReportSource> reportSourceList = new List<ReportSource>();

            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.produceTableAdapters.emulsificationAsphaltumProduceLogTableAdapter", "emulsificationAsphaltumProduceLog", new object[] { id }));
            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.produceTableAdapters.proportionTableAdapter", "proportion", new object[] { pid }));
           
            reportData.DataSetName = "DasherStation.dataSet.produce";
            reportData.ReportName = "DasherStation.ReportDistrict.produceReport.EmulsifiedAsphaltProduceRecords.rdlc";

            reportData.ReportSourceList = reportSourceList;

            reportServer.ShowReport(reportData);
        }

        /// <summary>
        /// 打印改性沥青生产记录
        /// </summary>
        /// <param name="id">记录ID</param>
        /// <param name="pid">生产配合比编号</param>
        public void PrintRecordRecordGBitumen(long id, long pid)
        {
            ReportHelper reportServer = new ReportHelper();
            ReportData reportData = new ReportData();
            List<ReportSource> reportSourceList = new List<ReportSource>();

            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.produceTableAdapters.restructureAsphaltumProduceLogTableAdapter", "restructureAsphaltumProduceLog", new object[] { id }));
            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.produceTableAdapters.proportionTableAdapter", "proportion", new object[] { pid }));
            
            reportData.DataSetName = "DasherStation.dataSet.produce";
            reportData.ReportName = "DasherStation.ReportDistrict.produceReport.ModifiedAsphaltProduceRecords.rdlc";

            reportData.ReportSourceList = reportSourceList;

            reportServer.ShowReport(reportData);
        }

        /// <summary>
        /// 打印沥青再加温记录
        /// </summary>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        public void PrintBitumenWarm(DateTime start,DateTime end)
        {
            ReportHelper reportServer = new ReportHelper();
            ReportData reportData = new ReportData();
            List<ReportSource> reportSourceList = new List<ReportSource>();

            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.produceTableAdapters.againCalefactionProduceLogTableAdapter", "againCalefactionProduceLog", new object[] { start,end }));
            
            reportData.DataSetName = "DasherStation.dataSet.produce";
            reportData.ReportName = "DasherStation.ReportDistrict.produceReport.HeatingAsphaltProduceRecords.rdlc";

            reportData.ReportSourceList = reportSourceList;

            reportServer.ShowReport(reportData);
        }

    }
}






