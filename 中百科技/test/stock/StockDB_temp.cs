using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using DasherStation.common;
using DasherStation.system;

namespace DasherStation.stock
{
    class StockDB_temp
    {
        SqlHelper sqlHelper = new SqlHelper();

        //采购核算查询核算的合同信息
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
                sqlStr.Append(" and " + strWhere);
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
            sqlStr.Append("  where indent.scId=" + mainId + " and ");
            sqlStr.Append("indent.mId=material.id" + " and ");
            sqlStr.Append("material.mmid=materialModel.id" + " and ");
            sqlStr.Append("material.mnid=materialName.id" + " and ");
            sqlStr.Append("materialName.mkId=materialKind.id" + " and ");
            sqlStr.Append("providerInfo.id=stockContract.piId" + " and ");
            sqlStr.Append("stockContract.id=" + mainId);
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        //根据扫入的条码号查询出条码上的所有相关信息
        public DataTable barCodeInfo(string barCode)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
           
            sqlStr.Append("select stockNote.id,stockNote.inputDate,voitureInfo.no,providerInfo.name as pname,");
            sqlStr.Append("transportUnit.name as tname,materialKind.sort,materialName.name,materialModel.model,");
            sqlStr.Append("stockNote.grossWeight,stockNote.tare,stockNote.suttle,stockNote.surveyor,");
            //未查询以上信息所要查找的关联信息
            sqlStr.Append("stockNote.iId,stockNote.viId,indent.id as id1,");
            sqlStr.Append("indent.mId,material.id as id2,");
            sqlStr.Append("material.mnId,material.mmId,");
            sqlStr.Append("materialName.id as id3,materialName.mkId,");
            sqlStr.Append("materialModel.id as id4,");
            sqlStr.Append("materialKind.id as id5,");
            sqlStr.Append("indent.scId,stockContract.id as id6,");
            sqlStr.Append("stockContract.piId,providerInfo.id as id7,");
            sqlStr.Append("voitureInfo.tuId,voitureInfo.id as id8,transportUnit.id as id9,");
            sqlStr.Append("stockNote.barCode");
            sqlStr.Append("  from stockNote,indent,");
            sqlStr.Append("material,materialName,materialModel,materialKind,stockContract,providerInfo,voitureInfo,");
            sqlStr.Append("transportUnit");
            sqlStr.Append(" where stockNote.iId=indent.id  and ");
            sqlStr.Append("stockNote.viId=voitureInfo.id and ");
            sqlStr.Append("indent.mId=material.id and ");
            sqlStr.Append("material.mnId=materialName.id and ");
            sqlStr.Append("material.mmId=materialModel.id and ");
            sqlStr.Append("materialName.mkId=materialKind.id and ");
            sqlStr.Append("indent.scId=stockContract.id and ");
            sqlStr.Append("stockContract.piId=providerInfo.id and ");
            sqlStr.Append("voitureInfo.tuId=transportUnit.id and ");
            sqlStr.Append("stockNote.barCode=" + "'" + barCode + "'");
            list.Add(sqlStr.ToString());

            return sqlHelper.QueryForDateSet(list).Tables[0];
        }
        //向采购核算表中插入数据
        public string insertStockSettlement(stockMaterialSettlement stockSet)
        {
            StringBuilder sqlStr = new StringBuilder();

            sqlStr.Append("insert into stockMaterialSettlement(totalWeight,scId,sum,inputDate,");
            sqlStr.Append("inputMan,count)");
            sqlStr.Append("values(");
            sqlStr.Append("" + stockSet.totalWeight + "," + stockSet.scId + ",");
            sqlStr.Append("" + stockSet.sum + "," + "'" + stockSet.inputDate + "'" + ",");
            sqlStr.Append("" + "'" + stockSet.inputMan + "'" + ",");
            sqlStr.Append("" + stockSet.count);
            sqlStr.Append(")");
            sqlStr.Append("; declare @smsId int");
            sqlStr.Append("; set @smsId=@@IDENTITY;");

            return sqlStr.ToString();

        }
        //向核算明细表中插入数据
        public string insertStockSettlementDetail(stockMaterialSettlementDetail stockSetDetail)
        {
            StringBuilder sqlStr = new StringBuilder();

            sqlStr.Append("insert into stockMaterialSettlementDetail(smsId,iId,count,");
            sqlStr.Append("sum,inputDate,inputMan)");
            sqlStr.Append("values(");
            sqlStr.Append("" + "@smsId" + ",");
            sqlStr.Append("" + stockSetDetail.iId + ",");
            sqlStr.Append("" + stockSetDetail.count + ",");
            sqlStr.Append("" + stockSetDetail.sum + ",");
            sqlStr.Append("" + "'" + stockSetDetail.inputDate + "'" + ",");
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



        //核算单查询
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
            ls.Viewfields.Add("stockContract.[name] as 合同名称");
            ls.Viewfields.Add("stockContract.[no] as 合同编号");
            ls.Viewfields.Add("providerInfo.[name] as 供应商名");
            ls.Viewfields.Add("stockMaterialSettlement.sum as 总金额");
            ls.Viewfields.Add("stockMaterialSettlement.inputdate as 日期时间");
            ls.Viewfields.Add("stockMaterialSettlement.[name] as 录入人");
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
}
