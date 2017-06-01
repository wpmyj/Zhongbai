using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using DasherStation.common;
using System.Data.SqlClient;

namespace DasherStation.transport
{
    public class TransportDB
    {
        SqlHelper sqlHelper = new SqlHelper();

        public bool ExecuteTransaction(ArrayList sqlList)
        {
            return sqlHelper.ExecuteTransaction(sqlList);
        }

        public static DataSet Query(ArrayList SqlList)
        {          
            SqlHelper sqlHelper = new SqlHelper();
            return sqlHelper.QueryForDateSet(SqlList);
        }

        public static DataSet Query(string sqlStr)
        {
            ArrayList sqlList = new ArrayList();
            sqlList.Add(sqlStr);
            SqlHelper sqlHelper = new SqlHelper();
            return sqlHelper.QueryForDateSet(sqlList);

            
        }

        public DataSet kindBind(TransportLogic.TranType type,string strWhere)
        {
            string sqlStr = null;
            switch (type)
            {
                case TransportLogic.TranType.material:
                    sqlStr = "select id,sort from materialKind";
                    break;
                case TransportLogic.TranType.product:
                    sqlStr = "select id,sort from productKind";
                    break;
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqlStr += " where id= " + strWhere;
            }
            return TransportDB.Query(sqlStr);
        }

        public DataSet nameBind(TransportLogic.TranType type, string strWhere)
        {
            string sqlStr = null;
            switch (type)
            {
                case TransportLogic.TranType.material:
                    sqlStr = "select id,name from materialName";
                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        sqlStr += " where mkid= " + strWhere;
                    }
                    break;
                case TransportLogic.TranType.product:
                    sqlStr = "select id,name from productName";
                    if (!string.IsNullOrEmpty(strWhere))
                    {
                        sqlStr += " where pkid= " + strWhere;
                    }
                    break;
            }          
            return TransportDB.Query(sqlStr);
        }

        public DataSet modelBind(TransportLogic.TranType type, string strWhere)
        {
            string sqlStr = null;
            switch (type)
            {
                case TransportLogic.TranType.material:
                    sqlStr = "select mm.id,mm.model from material m,materialModel mm where m.mmid=mm.id and m.mnid=" + strWhere;
                    break;
                case TransportLogic.TranType.product:
                    sqlStr = "select pm.id,pm.model from product p,productModel pm where p.pmid=pm.id and p.pnid=" + strWhere;
                    break;
            }
            return TransportDB.Query(sqlStr);
        }

        public DataSet transportUnitBind()
        {
            return Query("select id,name from transportUnit");
        }

        public DataSet siteBind()
        {
            return Query("select id,site from site");
        }

        public DataSet transportSettlementMethodBind()
        {
            return Query("select id,method from transportSettlementMethod");
        }

        /// <summary>
        /// 保存运输合同
        /// </summary>
        /// <param name="transportContract">运输合同对象</param>
        /// <param name="list">合同明细集合</param>
        /// <returns>True:成功,False:失败</returns>
        public bool saveContract(TransportContract transportContract, List<TransportGoodsInformationCorresponding> list)
        {
            ArrayList sqllist = new ArrayList();
            sqllist.Add(new transportContractAction().GetInsertSql(transportContract));

            foreach (TransportGoodsInformationCorresponding transportGoodsInformationCorresponding in list)
            {
                sqllist.Add(new TransportGoodsInformationCorrespondingAction().GetInsertSql(transportGoodsInformationCorresponding));
            }
            return sqlHelper.ExecuteTransaction(sqllist);
        }
        // 2009-4-20 修改人：付中华 给定编号返回运输单位
        public DataTable findConveyAncerdb(int id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("select transportUnit.name ");
            sqlStr.Append(" from transportContract,transportUnit");
            sqlStr.Append(" where transportContract.tuId=transportUnit.id and ");
            sqlStr.Append(" transportContract.id=" + id);

            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        public DataSet contractBind(string strWhere)
        {
            ArrayList sqllist = new ArrayList();
            sqllist.Add("select tc.id,contractName 合同名称,no 合同编号,tu.name 运输单位 ");
            sqllist.Add(",contractInkDate '签定日期',contractStartDate '生效日期'");
            sqllist.Add(",contractEndDate '截止日期',assessor '审核人',checkupMan '审批人'");
            sqllist.Add(",case mark when 1 then '已终止' else '执行中' end  状态");
            sqllist.Add(",'补充合同'=case when parentId is null then '否' else '是' end, assessDate 审核日期,checkupDate 审批日期 ");
            sqllist.Add("FROM transportContract tc,transportUnit tu  where tc.tuid=tu.id ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqllist.Add(strWhere);
            }

            sqllist.Add(" order by tc.inputDate desc ");

            return sqlHelper.QueryForDateSet(sqllist);
        }
        /*
   * 方法名称：getContractList
   * 方法功能描述：主合同的查询信息
   * 参数: 
   * 
   * 创建人：付中华
   * 创建时间：2009-04-20
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        public DataTable getContractList(string strWhere, string contractStatus)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            sqlStr.Append("select tc.id,contractName 合同名称,no 合同编号,tu.name 运输单位");
            sqlStr.Append(",contractInkDate '签定日期',contractStartDate '生效日期'");
            sqlStr.Append(",contractEndDate '截止日期',assessor '审核人',checkupMan '审批人'");
            sqlStr.Append(",case mark when 1 then '已终止' else '未终止' end  合同状态");
            sqlStr.Append(" ,'补充合同'=case when parentId is null then '否' else '是' end ");
            sqlStr.Append(",parentId as parentId");
            //sqlStr.Append(" ,'补充合同'=case when parentId is null then '否' else '是' end, assessDate 审核日期,checkupDate 审批日期 ");
            sqlStr.Append(" FROM transportContract tc,transportUnit tu  where tc.tuid=tu.id");

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
        /*
  * 方法名称：endMainContract
  * 方法功能描述：终止主合同要做的操作  停止主合同下的所有明细 停止主合同的所有补充合同以及他们下面的所有明细
  * 参数: 
  * 
  * 创建人：付中华
  * 创建时间：2009-04-20
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */      
        public bool endMainContract(int mainId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            // 停止主合同
            sqlStr.Append(" update transportContract set mark=1  where id=" + mainId + ";");
            // 停止主合同对应的所有明细
            sqlStr.Append(" update transportGoodsInformationCorresponding set mark=1 where tcId=" + mainId + ";");
            // 停止所有的分合同
            sqlStr.Append(" update transportContract set mark=1 where parentId=" + mainId + ";");
            // 先查找所有份合同的id号 再根据id号查找对应的说有分合同明细
            string sqlSelect = " select id from transportContract where parentId=" + mainId;
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { sqlSelect }).Tables[0];

            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sqlStr.Append(" update transportGoodsInformationCorresponding set mark=1 where tcId=" + Convert.ToInt32(dt.Rows[i][0].ToString()) + ";");
                }
            }
            list.Add(sqlStr.ToString());

            return sqlHelper.Update(list);
        }
        /*
          * 方法名称：
          * 方法功能描述：终止分合同的操作 终止分合同及分合同的明细 同时要判断同级合同是否全部终止 对应的主合同的明细是否全部终止
          * 参数: 
          * 
          * 创建人：付中华
          * 创建时间：2009-04-20
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        public bool endSupplyContract(int supplyId, int parentId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" update transportContract set mark=1 where id=" + supplyId + ";");
            sqlStr.Append(" update transportGoodsInformationCorresponding set mark=1 where tcId=" + supplyId + ";");

            bool endAll = isEndAll(parentId, parentId);
            if (endAll)
            {
                sqlStr.Append(" update transportContract set mark=1 where id=" + parentId + ";");
            }
            list.Add(sqlStr.ToString());

            return sqlHelper.Update(list);

        }
        /*
          * 方法名称：
          * 方法功能描述：判断主合同的所有分合同是否全部终止以及判断主合同的明细是否全部终止 如果所有都已终止则返回true
          * 参数: 
          * 
          * 创建人：付中华
          * 创建时间：2009-04-20
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        public bool isEndAll(int mainId, int parentId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            bool supplyMark = true;
            bool detailMark = true;

            // 查找出所有的分合同判断是否全部终止
            string sqlSelect = " select mark from transportContract where parentId=" + mainId;
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
            string sqlSelectS = " select mark from transportGoodsInformationCorresponding where tcId=" + parentId;
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
        /*
         * 方法名称：
         * 方法功能描述：终止主合同明细
         * 参数: 
         * 
         * 创建人：付中华
         * 创建时间：2009-04-20
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public bool endMainContractDetail(int mainContractDetailId, int mainContractId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" update transportGoodsInformationCorresponding set mark=1 where id=" + mainContractDetailId + ";");
            bool endAll = isEndAll(mainContractId, mainContractId);
            if (endAll)
            {
                sqlStr.Append(" update transportContract set mark=1 where id=" + mainContractId + ";");
            }
            list.Add(sqlStr.ToString());

            return sqlHelper.Update(list);

        }
        /*
         * 方法名称：
         * 方法功能描述：终止分合同明细
         * 参数: 
         * 
         * 创建人：付中华
         * 创建时间：2009-04-20
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public bool endSupplyContractDetail(int supplyDetailId, int parentId)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" update transportGoodsInformationCorresponding set mark=1 where id=" + supplyDetailId + ";");
            bool endAll = isEndAll(parentId, parentId);
            if (endAll)
            {
                sqlStr.Append(" update transportContract set mark=1 where id=" + parentId + ";");
            }
            list.Add(sqlStr.ToString());

            return sqlHelper.Update(list);
        }
        /*
        * 方法名称：
        * 方法功能描述：有主合同调出明细来
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-04-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet goodsInfoBind(string tcid)
        {
            ArrayList sqllist = new ArrayList();

            sqllist.Add("select tgi.id, coalesce(pn.name,mn.name) as name,coalesce(pm.model,mm.model) as model ");
            sqllist.Add(",sid1,sid2,distance,price,tsmId,case mark when 1 then '已终止' else '未终止' end mark,tsm.remark as formula ,tgi.tcId as tcId ");
            sqllist.Add("from transportGoodsInformationCorresponding tgi inner join transportSettlementMethod tsm on tsmid=tsm.id left join material m on m.id=mid    ");
            sqllist.Add("left join materialName mn on m.mnid=mn.id left join materialModel mm on m.mmid=mm.id ");
            sqllist.Add("left join product p on p.id=pid left join productName pn on p.pnid=pn.id  ");
            sqllist.Add("left join productModel pm on p.pmid=pm.id  ");

            if (!string.IsNullOrEmpty(tcid))
            {
                sqllist.Add("where tcid='" + tcid + "'");
            }

            return sqlHelper.QueryForDateSet(sqllist);
        }
        //public DataSet goodsInfoBind(string tcid)
        //{
        //    ArrayList sqllist = new ArrayList();

        //    sqllist.Add("select tgi.id, coalesce(pn.name,mn.name) as name,coalesce(pm.model,mm.model) as model ");
        //    sqllist.Add(",sid1,sid2,distance,price,tsmId,case mark when 1 then '已终止' else '未终止' end mark,tsm.remark as formula ,tgi.tcId as tcId ");
        //    sqllist.Add("from transportGoodsInformationCorresponding tgi inner join transportSettlementMethod tsm on tsmid=tsm.id left join material m on m.id=mid    ");
        //    sqllist.Add("left join materialName mn on m.mnid=mn.id left join materialModel mm on m.mmid=mm.id ");
        //    sqllist.Add("left join product p on p.id=pid left join productName pn on p.pnid=pn.id  ");
        //    sqllist.Add("left join productModel pm on p.pmid=pm.id  ");

        //    if (!string.IsNullOrEmpty(tcid))
        //    {
        //        sqllist.Add("where tcid in (select id from transportContract where parentid='"+tcid+"' or id='"+tcid+"')");
        //    }

        //    return sqlHelper.QueryForDateSet(sqllist);
        //}

        public DataSet SettlementDetail(string tsid)
        {
            ArrayList sqllist = new ArrayList();

            sqllist.Add("select tsmd.id, coalesce(pn.name,mn.name) as name,coalesce(pm.model,mm.model) as model ");
            sqllist.Add(",sid1,sid2,distance,price,tsmId,case mark when 1 then '已终止' else '未终止' end mark,tsmd.count,tsmd.sum,tsm.remark as formula  ");
            sqllist.Add("from transportGoodsInformationCorresponding tgi inner join transportSettlementMethod tsm on tsmid=tsm.id ");
            sqllist.Add(" inner join transportSettlementDetail tsmd on tsmd.tgicId=tgi.id ");
            sqllist.Add(" left join material m on m.id=mid ");   
            sqllist.Add("left join materialName mn on m.mnid=mn.id left join materialModel mm on m.mmid=mm.id ");
            sqllist.Add("left join product p on p.id=pid left join productName pn on p.pnid=pn.id  ");
            sqllist.Add("left join productModel pm on p.pmid=pm.id  ");

            if (!string.IsNullOrEmpty(tsid))
            {
                sqllist.Add("where tsmd.tsid=" + tsid);
            }

            return sqlHelper.QueryForDateSet(sqllist);
        }

        /// <summary>
        /// 小票信息绑定
        /// </summary>
        /// <param name="code">小票条码</param>
        /// <returns></returns>
        public DataSet noteBind(string code)
        {
            ArrayList sqllist = new ArrayList();

            sqllist.Add("select coalesce(pn.name,mn.name) as name,coalesce(pm.model,mm.model) as model ");
            sqllist.Add(",sn.sid1,sn.sid2,suttle,tgi.id did,sn.inputDate,barcode,checkAccountMark2 mark,pid,mid from stockNote sn inner join  ");
            sqllist.Add("transportGoodsInformationCorresponding tgi on sn.tgicid=tgi.id left join material m on mid=m.id ");
            sqllist.Add("left join materialName mn on m.mnid=mn.id left join materialModel mm on m.mmid=mm.id ");
            sqllist.Add("left join product p on p.id=pid left join productName pn on p.pnid=pn.id ");
            sqllist.Add("left join productModel pm on p.pmid=pm.id  ");

            if (!string.IsNullOrEmpty(code))
            {
                sqllist.Add(" where barCode='"+code+"'" );
            }

            sqllist.Add(" union all ");

            sqllist.Add("select coalesce(pn.name,mn.name) as name,coalesce(pm.model,mm.model) as model ");
            sqllist.Add(",cn.sid1,cn.sid2,suttle,tgi.id did,cn.inputDate,barcode,checkAccountMark2 mark,pid,mid from consignmentNote cn inner join ");
            sqllist.Add("transportGoodsInformationCorresponding tgi on cn.tgicid=tgi.id left join material m on mid=m.id ");
            sqllist.Add("left join materialName mn on m.mnid=mn.id left join materialModel mm on m.mmid=mm.id ");
            sqllist.Add("left join product p on p.id=pid left join productName pn on p.pnid=pn.id ");
            sqllist.Add("left join productModel pm on p.pmid=pm.id  ");

            if (!string.IsNullOrEmpty(code))
            {
                sqllist.Add(" where barCode='" + code + "'");
            }

            return sqlHelper.QueryForDateSet(sqllist);
        }

        /// <summary>
        /// 已结算小票信息绑定
        /// </summary>
        /// <param name="code">合同编号</param>
        /// <returns></returns>
        public DataSet noteViewBind(string tsid)
        {
            ArrayList sqllist = new ArrayList();

            sqllist.Add("select coalesce(pn.name,mn.name) as name,coalesce(pm.model,mm.model) as model  ");
            sqllist.Add(",sn.sid1,sn.sid2,suttle,tgic.id did,tnc.inputDate,barcode,checkAccountMark2 mark,pid,mid ");
            sqllist.Add("from transportGoodsInformationCorresponding tgic ");
            sqllist.Add("inner join transportSettlementDetail tsd on tsd.tgicid=tgic.id ");
            sqllist.Add("inner join transportNoteCorresponding tnc on tnc.tsdid=tsd.id ");
            sqllist.Add("inner join stockNote sn on sn.id=tnc.snid ");
            sqllist.Add("left join material m on mid=m.id ");
            sqllist.Add("left join materialName mn on m.mnid=mn.id left join materialModel mm on m.mmid=mm.id ");
            sqllist.Add("left join product p on p.id=pid left join productName pn on p.pnid=pn.id ");
            sqllist.Add("left join productModel pm on p.pmid=pm.id  ");

            if (!string.IsNullOrEmpty(tsid))
            {
                sqllist.Add(" where tsd.id='" + tsid + "'");
            }

            sqllist.Add(" union all ");

            sqllist.Add("select coalesce(pn.name,mn.name) as name,coalesce(pm.model,mm.model) as model  ");
            sqllist.Add(",cn.sid1,cn.sid2,suttle,tgic.id did,tnc.inputDate,barcode,checkAccountMark2 mark,pid,mid ");
            sqllist.Add("from transportGoodsInformationCorresponding tgic ");
            sqllist.Add("inner join transportSettlementDetail tsd on tsd.tgicid=tgic.id ");
            sqllist.Add("inner join transportNoteCorresponding tnc on tnc.tsdid=tsd.id ");
            sqllist.Add("inner join consignmentNote cn on cn.id=tnc.cnid ");
            sqllist.Add("left join material m on mid=m.id ");
            sqllist.Add("left join materialName mn on m.mnid=mn.id left join materialModel mm on m.mmid=mm.id ");
            sqllist.Add("left join product p on p.id=pid left join productName pn on p.pnid=pn.id ");
            sqllist.Add("left join productModel pm on p.pmid=pm.id  ");

            if (!string.IsNullOrEmpty(tsid))
            {
                sqllist.Add(" where tsd.id='" + tsid + "'");
            }

            return sqlHelper.QueryForDateSet(sqllist);
        }

        public long? queryStockNoteID(string code)
        {
            DataSet ds = sqlHelper.QueryForDateSet(new ArrayList() { "select id from stockNote where barcode='"+code+"'"  });
            if (ds.Tables[0].Rows.Count > 0)
            {
                return long.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            return null;
        }

        public long? queryConsignmentNoteID(string code)
        {
            DataSet ds = sqlHelper.QueryForDateSet(new ArrayList() { "select id from consignmentNote where barcode='"+code+"'"  });
            if (ds.Tables[0].Rows.Count > 0)
            {
                return long.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            return null;
        }

        /// <summary>
        /// 运输核算信息绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="strWhere">筛选条件</param>
        public DataSet settlementBind(string strWhere)
        {
            ArrayList sqllist = new ArrayList();
            sqllist.Add("select ts.id '核算单号',tc.no '合同编号',tc.contractName '合同名称',tu.name '运输商名称',ts.totalWeight '总重量',ts.sum '总金额',ts.count '票据总数',ts.assessor '审核人',ts.checkupMan '审批人'");
            //ts.assessDate '审核日期',ts.checkupDate '审批日期'   ");
            sqllist.Add(" from transportSettlement ts,transportContract tc,transportUnit tu ");
            sqllist.Add(" where ts.tcid=tc.id and tc.tuid=tu.id ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                sqllist.Add(strWhere);
            }
            sqllist.Add(" order by ts.inputDate desc");
            return sqlHelper.QueryForDateSet(sqllist);
        }

        /// <summary>
        /// 终止运输合同
        /// </summary>
        /// <param name="tcid">合同ID</param>
        public bool contractStop(string tcid)
        {
            ArrayList sqllist = new ArrayList();
            sqllist.Add("declare @parentId bigint;");
            sqllist.Add("set @parentId=(select parentId from transportContract where id='" + tcid + "') ");
            sqllist.Add("update transportContract set mark=1 where parentId='" + tcid + "' or id='" + tcid + "'  ");
            sqllist.Add("update transportGoodsInformationCorresponding set mark=1 where tcId='" + tcid + "' ");
            sqllist.Add("if(@parentId is null) ");
            sqllist.Add("BEGIN ");
            sqllist.Add("	update transportGoodsInformationCorresponding set mark=1 where tcId in (select id from transportContract where parentId='" + tcid + "') ");
            sqllist.Add("END ");
            sqllist.Add("else ");
            sqllist.Add("BEGIN ");
            sqllist.Add("if((select count(*) from transportGoodsInformationCorresponding where tcId in (select id from transportContract where parentId=@parentId or id=@parentId) and mark=0)=0) ");
            sqllist.Add("begin ");
            sqllist.Add("update transportContract set mark=1 where id=@parentId ");
            sqllist.Add("end ");
            sqllist.Add("end ");
            return sqlHelper.Update(sqllist);

        }

        /// <summary>
        /// 终止运输合同明细
        /// </summary>
        /// <param name="tcid">合同明细ID</param>
        /// <returns>True:成功 False:失败</returns>
        public bool contractDatailStop(string tciid)
        {
            ArrayList sqllist = new ArrayList();
            sqllist.Add("declare @Id bigint;set @id=" + tciid + " ");
            sqllist.Add("declare @tcId bigint; ");
            sqllist.Add("declare @parentid bigint; ");
            sqllist.Add("set @tcId=(select tcId from transportGoodsInformationCorresponding where id=@id);  ");
            sqllist.Add("update transportGoodsInformationCorresponding set mark=1 where id=@id; ");
            sqllist.Add("set @parentid=(select parentid from transportContract where id=@tcId) ");
            sqllist.Add("if(@tcId is not null) ");
            sqllist.Add("BEGIN ");
            sqllist.Add("	if((select count(*) from transportGoodsInformationCorresponding where tcId=@tcId and mark=0)=0) ");
            sqllist.Add("	begin ");
            sqllist.Add("	    if((select parentid from transportContract where id=@tcId) is not null) ");
            sqllist.Add("	    begin ");
            sqllist.Add("		    update transportContract set mark=1 where id=@tcId; ");
            sqllist.Add("           set @tcId=@parentid; ");                        
            sqllist.Add("	    end ");
            sqllist.Add("		if((select count(*) from transportGoodsInformationCorresponding where tcId in (select id from transportContract where parentId=@tcId or id=@tcId) and mark=0)=0) ");
            sqllist.Add("		begin ");
            sqllist.Add("			update transportContract set mark=1 where id=@tcId or parentId=@tcId; ");
            sqllist.Add("		end ");
            sqllist.Add("	end ");
            sqllist.Add("end ");
            return sqlHelper.Update(sqllist);
        }

        /// <summary>
        /// 审核运输合同
        /// </summary>
        /// <param name="tcid">合同ID</param>
        /// <param name="userName">用户名</param>
        /// <returns>True:成功 False:失败</returns>
        public bool contractAssessor(string tcid ,string userName)
        {
            return sqlHelper.Update(new ArrayList() { "update transportContract set assessor='" + userName + "' where id=" + tcid });
        }

        /// <summary>
        /// 审批运输合同
        /// </summary>
        /// <param name="tcid">合同ID</param>
        /// <param name="userName">用户名</param>
        /// <returns>True:成功 False:失败</returns>
        public bool contractCheckup(string tcid , string userName)
        {
            return sqlHelper.Update(new ArrayList() { "update transportContract set checkupMan='" + userName + "' where id=" + tcid });
        }

        public string getNodeSql(string code)
        {
            if (code.Length > 0)
            {
                code = code.Substring(1);
                return "update stockNote set checkAccountMark2=1 where barcode in (" + code + ");update consignmentNote set checkAccountMark2=1 where barcode in (" + code + ");";
            }
            else
            {
                return "";
            }
            
        }
    }


//============================================================================================================================//

    /// <summary>
    /// 数据访问类transportContractAction。(运输合同表)
    /// </summary>
    public class transportContractAction
    {
        #region  成员方法
        /// <summary>
        /// 获取增加操作SQL字符串
        /// </summary>
        public string GetInsertSql(TransportContract model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.contractName != null)
            {
                strSql1.Append("contractName,");
                strSql2.Append("'" + model.contractName + "',");
            }
            if (model.no != null)
            {
                strSql1.Append("no,");
                strSql2.Append("'" + model.no + "',");
            }
            if (model.tuId != null)
            {
                strSql1.Append("tuId,");
                strSql2.Append("" + model.tuId + ",");
            }
            if (model.contractInkDate != null)
            {
                strSql1.Append("contractInkDate,");
                strSql2.Append("'" + model.contractInkDate + "',");
            }
            if (model.contractStartDate != null)
            {
                strSql1.Append("contractStartDate,");
                strSql2.Append("'" + model.contractStartDate + "',");
            }
            if (model.contractEndDate != null)
            {
                strSql1.Append("contractEndDate,");
                strSql2.Append("'" + model.contractEndDate + "',");
            }

                strSql1.Append("inputDate,");
                strSql2.Append("getdate(),");
       
            if (model.inputMan != null)
            {
                strSql1.Append("inputMan,");
                strSql2.Append("'" + model.inputMan + "',");
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
 
                strSql1.Append("mark,");
                strSql2.Append("0,");
       
            if (model.remark != null)
            {
                strSql1.Append("remark,");
                strSql2.Append("'" + model.remark + "',");
            }
            if (model.ParentId != null)
            {
                strSql1.Append("ParentId,");
                strSql2.Append("'" + model.ParentId + "',");
            }
            strSql.Append("insert into transportContract(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";declare  @pid int;");
            strSql.Append("set @pid=@@IDENTITY;");
           

            return strSql.ToString();
        }
        #endregion  成员方法
    }

    public class TransportGoodsInformationCorrespondingAction
    {
        #region  成员方法

        /// <summary>
        /// 获取增加操作SQL字符串
        /// </summary>
        public string GetInsertSql(TransportGoodsInformationCorresponding model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

                strSql1.Append("tcId,");
                strSql2.Append(" @pid,");
            
            if (model.mId != null)
            {
                strSql1.Append("mId,");
                strSql2.Append("" + model.mId + ",");
            }
            if (model.pId != null)
            {
                strSql1.Append("pId,");
                strSql2.Append("" + model.pId + ",");
            }
            if (model.sId1 != null)
            {
                strSql1.Append("sId1,");
                strSql2.Append("" + model.sId1 + ",");
            }
            if (model.sId2 != null)
            {
                strSql1.Append("sId2,");
                strSql2.Append("" + model.sId2 + ",");
            }
            if (model.distance != null)
            {
                strSql1.Append("distance,");
                strSql2.Append("" + model.distance + ",");
            }

                strSql1.Append("inputDate,");
                strSql2.Append("getdate(),");

            if (model.inputMan != null)
            {
                strSql1.Append("inputMan,");
                strSql2.Append("'" + model.inputMan + "',");
            }
            if (model.price != null)
            {
                strSql1.Append("price,");
                strSql2.Append("" + model.price + ",");
            }
            if (model.tsmId != null)
            {
                strSql1.Append("tsmId,");
                strSql2.Append("" + model.tsmId + ",");
            }
            strSql.Append("insert into transportGoodsInformationCorresponding(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY;");

            return strSql.ToString();
        }

        #endregion  成员方法
    }

    /// <summary>
    /// 实体类transportSettlement 。(运输核算表)
    /// </summary>
    public class TransportSettlementAction
    {
        #region 成员方法
        public string GetInsertSql(TransportSettlement model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

            if (model.totalWeight != null)
            {
                strSql1.Append("totalWeight,");
                strSql2.Append("" + model.totalWeight + ",");
            }
            if (model.tcId != null)
            {
                strSql1.Append("tcId,");
                strSql2.Append("" + model.tcId + ",");
            }
            if (model.sum != null)
            {
                strSql1.Append("sum,");
                strSql2.Append("" + model.sum + ",");
            }
            if (model.inputDate != null)
            {
                strSql1.Append("inputDate,");
                strSql2.Append("getdate()',");
            }
            if (model.inputMan != null)
            {
                strSql1.Append("inputMan,");
                strSql2.Append("'" + model.inputMan + "',");
            }
            if (model.count != null)
            {
                strSql1.Append("count,");
                strSql2.Append("" + model.count + ",");
            }
            if (model.remark != null)
            {
                strSql1.Append("remark,");
                strSql2.Append("'" + model.remark + "',");
            }
            strSql.Append("insert into transportSettlement(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";declare  @tsdid int;");
            strSql.Append(";declare  @tsid int;");
            strSql.Append(";set @tsid=@@IDENTITY;");


            return strSql.ToString();
        }
        #endregion 
    }

    /// <summary>
    /// 实体类transportSettlementDetail 。(运输核算明细表)
    /// </summary>
    public class TransportSettlementDetailAction
    {
        #region 成员方法
        public string GetInsertSql(TransportSettlementDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

                strSql1.Append("tsId,");
                strSql2.Append("@tsid,");

            if (model.tgicId != null)
            {
                strSql1.Append("tgicId,");
                strSql2.Append("" + model.tgicId + ",");
            }
            if (model.count != null)
            {
                strSql1.Append("count,");
                strSql2.Append("" + model.count + ",");
            }
            if (model.sum != null)
            {
                strSql1.Append("sum,");
                strSql2.Append("" + model.sum + ",");
            }
            if (model.inputDate != null)
            {
                strSql1.Append("inputDate,");
                strSql2.Append("getdate(),");
            }
            if (model.inputMan != null)
            {
                strSql1.Append("inputMan,");
                strSql2.Append("'" + model.inputMan + "',");
            }
            strSql.Append("insert into transportSettlementDetail(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";set @tsdid=@@IDENTITY;");

            return strSql.ToString();
        }
        #endregion 
    }

    /// <summary>
    /// 实体类transportNoteCorresponding 。(运输票据对应表)
    /// </summary>
    public class TransportNoteCorrespondingAction
    {
        #region 成员方法
        public string GetInsertSql(TransportNoteCorresponding model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

                strSql1.Append("tsdId,");
                strSql2.Append("@tsdid,");
            
            if (model.snId != null)
            {
                strSql1.Append("snId,");
                strSql2.Append("" + model.snId + ",");
            }
            if (model.cnId != null)
            {
                strSql1.Append("cnId,");
                strSql2.Append("" + model.cnId + ",");
            }

                strSql1.Append("inputDate,");
                strSql2.Append("getdate(),");
     
            if (model.inputMan != null)
            {
                strSql1.Append("inputMan,");
                strSql2.Append("'" + model.inputMan + "',");
            }
            strSql.Append("insert into transportNoteCorresponding(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(");");

            return strSql.ToString();
        }
        #endregion       
    }





}
