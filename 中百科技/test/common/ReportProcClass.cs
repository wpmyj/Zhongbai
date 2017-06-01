using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DasherStation.ReportDistrict.stockReport;
using DasherStation.system;
using System.Collections;
using DasherStation.ReportDistrict.transportReport;
using DasherStation.financeReport.stockReport;
using DasherStation.Finance.AccountBooks;
using DasherStation.ReportDistrict.produceReport;

namespace DasherStation.common
{
    class ReportStockClass
    {
        //材料年度采购计划
        public void RunStockPlan(string id)
        {
            LinkSelect linkS = new LinkSelect();
            linkS.TableNames.Add("stockPlanDetail");
            linkS.TableNames.Add("stockPlan");
            linkS.LinkConds.Add("stockPlanDetail.spId=stockPlan.Id");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("stockPlanDetail.mId=material.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnId=materialName.id");
            linkS.TableNames.Add("materialModel");
            linkS.LinkConds.Add("material.mmId=materialModel.id");
            linkS.TableNames.Add("materialKind");
            linkS.LinkConds.Add("materialName.mkId=materialKind.id");
            linkS.Viewfields.Add(" * ");
            linkS.Conds.Add("stockPlan.id=" + id);
            DataSet ds = linkS.LeftLinkOpen();            

            StockPlan oStockPlan = new StockPlan();
            oStockPlan.Source = ds;

            oStockPlan.Year = "2009";
            oStockPlan.CoName = "中百";
            oStockPlan.DocNum = "11000111";
            oStockPlan.Table = "刘淼";
            oStockPlan.Examine = "bb";
            oStockPlan.Approve = "ccc";
            oStockPlan.ShowReport();
        }
        public void RunStockCheck(string id)
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("stockMaterialSettlementDetail");
            linkS.TableNames.Add("stockMaterialSettlement");
            linkS.LinkConds.Add("stockMaterialSettlementDetail.smsId=stockMaterialSettlement.id");
            linkS.TableNames.Add("indent");
            linkS.LinkConds.Add("stockMaterialSettlementDetail.iId=indent.id");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("indent.mId=material.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnId=materialName.id");
            linkS.TableNames.Add("materialModel");
            linkS.LinkConds.Add("material.mmId=materialModel.id");
            linkS.TableNames.Add("materialKind");
            linkS.LinkConds.Add("materialName.mkId=materialKind.id");
            linkS.Viewfields.Add("materialKind.sort");
            linkS.Viewfields.Add("materialName.[name]");
            linkS.Viewfields.Add("materialModel.model");
            linkS.Viewfields.Add("stockMaterialSettlementDetail.[sum] as money");
            linkS.Viewfields.Add("stockMaterialSettlementDetail.count as suttle");
            linkS.Viewfields.Add("indent.unitPrice");
            linkS.Conds.Add("stockMaterialSettlement.id="+id);
            DataSet ds = linkS.LeftLinkOpen();

            //SqlHelper helper = new SqlHelper();
            //String sql = "Select voitureInfo.[no] as sort,stockContract.[name],stockNote.iId as 合同明细编号,materialName.[name] as 材料名称,materialModel.model,stockNote.grossWeight as 车辆毛重,stockNote.tare as 车辆皮重,stockNote.suttle,site1.site as 起运地,site2.site as 止运地,stockNote.inputdate as 日期时间,stockNote.remark as 备注,stockNote.barCode as 条形码,unitPrice,unitPrice * stockNote.suttle as money From stockMaterialNoteCorresponding Left Outer Join stockNote ON stockMaterialNoteCorresponding.snId=stockNote.id Left Outer Join stockMaterialSettlementDetail ON stockMaterialNoteCorresponding.smsdId=stockMaterialSettlementDetail.id Left Outer Join stockMaterialSettlement ON stockMaterialSettlementDetail.smsId=stockMaterialSettlement.id Left Outer Join stockContract ON stockMaterialSettlement.scId=stockContract.id Left Outer Join voitureInfo ON stockNote.viId=voitureInfo.id Left Outer Join transportUnit ON voitureInfo.tuId=transportUnit.id Left Outer Join site site1 ON stockNote.sId1=site1.id Left Outer Join site site2 ON stockNote.sId2=site2.id Left Outer Join transportGoodsInformationCorresponding ON stockNote.tgicId=transportGoodsInformationCorresponding.id Left Outer Join transportContract ON transportGoodsInformationCorresponding.tcId=transportContract.id Left Outer Join indent ON stockNote.iId=indent.id Left Outer Join material ON indent.mId=material.id Left Outer Join materialName ON material.mnId=materialName.id Left Outer Join materialModel ON material.mmId=materialModel.id where 1=1  ";
            //System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            //oArrayList.Add(sql);
            //DataSet ds = helper.QueryForDateSet(oArrayList);

            StockCheck oStockCheck = new StockCheck();
            oStockCheck.Source = ds;
            CReportTools tools = new CReportTools();
            DataTable dt = ds.Tables[0];
            Decimal money = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                money += Convert.ToDecimal(dt.Rows[i]["money"]);
            }
            oStockCheck.SumMoney = tools.ToUpper(money);
            oStockCheck.AccountNum = id.ToString();
            oStockCheck.ContractNum = "100086";
            oStockCheck.CoName = "中百科技有限公司";
            oStockCheck.Num = "1111";
            oStockCheck.InvoiceNo = "0001";
            oStockCheck.Supplier = "中百";
            oStockCheck.Telephone = "138888888";
            oStockCheck.Auditor = "刘淼";
            oStockCheck.Examine = "bbb";
            oStockCheck.Approve = "ccc";
            oStockCheck.AuditorYmd = "2008年5月21号";
            oStockCheck.ExamineYmd = "2008年5月22号";
            oStockCheck.ApproveYmd = "2008年5月23号";
            oStockCheck.ShowReport();

        }
        public void RunInputDayStatistics(string startyear,string endyear)
        {
            //日期		date
            //材料种类	sort
            //材料名称	materialName
            //规格型号	model
            //入库数量	inputNum
            //计量单位	measure
            //单据数量	num
            //累计入库量	aggregateInputNum
            SqlHelper sqlHelper = new SqlHelper();
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append(" SELECT f.sort, d.name as materialName, a.mnId, a.mmId, e.model, SUM(c.suttle) AS inputNum,");
            sqlStr.Append(" COUNT(*) AS num, b.mId,");
            sqlStr.Append("(SELECT SUM(sn.suttle) AS ysuttle FROM stockNote AS sn INNER JOIN");
            sqlStr.Append(" indent AS mi ON sn.iId = mi.id ");
            sqlStr.Append(" WHERE (mi.mId = b.mId) AND (sn.inputDate< = " + "'" + endyear + "'" + ")) AS aggregateInputNum ");
            sqlStr.Append("FROM material AS a INNER JOIN");
            sqlStr.Append(" indent AS b ON a.id = b.mId INNER JOIN ");
            sqlStr.Append("stockNote AS c ON b.id = c.iId INNER JOIN ");
            sqlStr.Append("materialName AS d ON a.mnId = d.id INNER JOIN ");
            sqlStr.Append("materialModel AS e ON a.mmId = e.id INNER JOIN ");
            sqlStr.Append("materialKind AS f ON d.mkId = f.id ");
            //sqlStr.Append(" WHERE (c.inputDate BETWEEN '2009-1-1' AND '2009-3-5') ");
            sqlStr.Append(" WHERE (c.inputDate >= " + "'" + startyear + "'" + ")");
            sqlStr.Append(" and (c.inputDate<=" + "'" + endyear + "'" + ")");
            sqlStr.Append("GROUP BY d.name, f.sort, e.model, a.mnId, a.mmId, b.mId");
            list.Add(sqlStr.ToString());
            DataSet ds = sqlHelper.QueryForDateSet(list);            
            InputDayStatistics oInputDayStatistics = new InputDayStatistics();
            oInputDayStatistics.Source = ds;
            oInputDayStatistics.CoName = "中百";
            oInputDayStatistics.Num = "1112222";
            oInputDayStatistics.Table = "刘淼";
            oInputDayStatistics.Examine = "刘淼";
            oInputDayStatistics.Date = startyear + "--" + endyear;
            oInputDayStatistics.ShowReport(); 
        }
        public void RunSupplierDayStatistics(string startyear, string endyear)
        {
            //日期		    date
            //供应商名称	supplierName
            //材料种类	    sort
            //材料名称	    materialName
            //规格型号	    model
            //入库数量	    inputNum
            //单据数量	    num
            //累计入库量	aggregateInputNum
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            SqlHelper sqlHelper = new SqlHelper();
            sqlStr.Append("SELECT pr.name AS supplierName, mk.sort, mn.name AS materialName, mm.model,");
            //sqlStr.Append("SUM(sn.suttle) AS inweight,COUNT(*) AS notecount,(select SUM(isn.suttle) as suttle ");
            sqlStr.Append("SUM(sn.suttle) AS inputNum,COUNT(*) AS num, ");
            sqlStr.Append("(SELECT SUM(isn.suttle) AS suttle ");
            sqlStr.Append(" FROM stockNote AS isn INNER JOIN ");
            sqlStr.Append("indent AS ii ON isn.iId = ii.id INNER JOIN ");
            sqlStr.Append("stockContract AS sc ON ii.scId = sc.id INNER JOIN ");
            sqlStr.Append("providerInfo AS ipr ON sc.piId = ipr.id ");
            sqlStr.Append(" WHERE (ii.mId = it.mId) AND   ");
            sqlStr.Append("(ipr.name = pr.name)");
            //sqlStr.Append("from stockNote isn,indent ii where isn.iid=ii.id and ii.mid=it.mid ");
            //sqlStr.Append("and year(isn.inputDate)='2009' group by ii.mid) as ysuttle ");
            sqlStr.Append("and isn.inputDate <= " + "'" + endyear + "'" + " group by ii.mid,ipr.name) as aggregateInputNum ");
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
            sqlStr.Append(" sn.inputDate>=" + "'" + startyear + "'" + "and sn.inputdate <=" + "'" + endyear + "'");
            sqlStr.Append("group by i.mid) ");
            sqlStr.Append("GROUP BY it.mid,pr.name, mk.sort, mn.name, mm.model ");
            list.Add(sqlStr.ToString());
            DataSet ds = sqlHelper.QueryForDateSet(list);

            SupplierDayStatistics oSupplierStatistics = new SupplierDayStatistics();
            oSupplierStatistics.Source = ds;
            oSupplierStatistics.CoName = "中百";
            oSupplierStatistics.Num = "1112222";
            oSupplierStatistics.Table = "刘淼";
            oSupplierStatistics.Examine = "刘淼";
            oSupplierStatistics.Date = startyear + "--" + endyear;
            oSupplierStatistics.ShowReport();
        }
        public void RunStockCheckDetail(string id)
        {
            //日期		    date
            //车牌号码	    no
            //供应商名称	supplierName
            //运输单位名称	transportName
            //材料种类	    sort
            //材料名称	    materialName
            //规格型号	    model
            //毛重		    grossWeight
            //皮重		    tare
            //净重		    suttle
            //检斤员		personnel
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("stockMaterialNoteCorresponding");
            linkS.TableNames.Add("stockMaterialSettlementDetail");
            linkS.LinkConds.Add("stockMaterialNoteCorresponding.smsdId=stockMaterialSettlementDetail.id");
            linkS.TableNames.Add("stockMaterialSettlement");
            linkS.LinkConds.Add("stockMaterialSettlementDetail.smsId=stockMaterialSettlement.id");
            linkS.TableNames.Add("stockNote");
            linkS.LinkConds.Add("stockMaterialNoteCorresponding.snId=stockNote.id");
            linkS.TableNames.Add("personnelInfo");
            linkS.LinkConds.Add("stockNote.piId1=personnelInfo.id");
            linkS.TableNames.Add("indent");
            linkS.LinkConds.Add("stockNote.iId=indent.id");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("indent.mid=material.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnid=materialName.id");
            linkS.TableNames.Add("materialModel");           
            linkS.LinkConds.Add("material.mmid=materialModel.id");
            linkS.TableNames.Add("materialKind");
            linkS.LinkConds.Add("materialName.mkId=materialKind.id");            
            linkS.TableNames.Add("stockContract");
            linkS.LinkConds.Add("indent.scId=stockContract.id");
            linkS.TableNames.Add("providerInfo");
            linkS.LinkConds.Add("stockContract.piId=providerInfo.Id");
            linkS.TableNames.Add("voitureInfo");
            linkS.LinkConds.Add("stockNote.viId=voitureInfo.id");
            linkS.TableNames.Add("transportUnit");
            linkS.LinkConds.Add("voitureInfo.tuId=transportUnit.id");            
            linkS.TableNames.Add("transportGoodsInformationCorresponding");
            linkS.LinkConds.Add("stockNote.tgicId=transportGoodsInformationCorresponding.id");
            linkS.TableNames.Add("transportContract");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.tcId=transportContract.id");
            linkS.Viewfields.Add("stockMaterialNoteCorresponding.inputDate as date");
            linkS.Viewfields.Add("voitureInfo.[no]");
            linkS.Viewfields.Add("providerInfo.[name] as supplierName");
            linkS.Viewfields.Add("transportUnit.[name] as transportName");
            linkS.Viewfields.Add("materialKind.sort");
            linkS.Viewfields.Add("materialModel.model");
            linkS.Viewfields.Add("materialName.[name] as materialName");
            linkS.Viewfields.Add("stockNote.grossWeight");
            linkS.Viewfields.Add("stockNote.tare");
            linkS.Viewfields.Add("stockNote.suttle");
            linkS.Viewfields.Add("personnelInfo.[name] as personnel");
            linkS.Conds.Add("stockMaterialSettlement.id="+id);            
            DataSet ds = linkS.LeftLinkOpen();           

            StockCheckDetail oStockCheckDetail = new StockCheckDetail();
            oStockCheckDetail.Source = ds;           

            oStockCheckDetail.CoName = "中百";            
            oStockCheckDetail.ShowReport();
        }
        public void RunTransportDayStatistics(string startyear, string endyear)
        {
            SqlHelper sqlHelper = new SqlHelper();
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("SELECT tu.name AS transportName, site.site as startSite , mk.sort, mn.name AS materialName, mm.model,");
            sqlStr.Append("SUM(sn.suttle) AS num ");
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
            sqlStr.Append("WHERE (sn.inputDate >= " + "'" + startyear + "'" + ")");
            sqlStr.Append("AND (sn.inputDate <= " + "'" + endyear + "'" + ")");
            sqlStr.Append("GROUP BY tu.name, site.site, mk.sort, mn.name, mm.model ");
            list.Add(sqlStr.ToString());

            DataSet ds = sqlHelper.QueryForDateSet(list);
            //日期		    date
            //运输单位名称	transportName
            //起运地		startSite
            //运输距离	    distance
            //材料种类	    sort
            //材料名称	    materialName
            //材料规格	    model
            //入库数量	    num            

            TransportDayStatistics oTransportStatistics = new TransportDayStatistics();
            oTransportStatistics.Source = ds;
            oTransportStatistics.CoName = "中百";
            oTransportStatistics.Num = "1112222";
            oTransportStatistics.Table = "刘淼";
            oTransportStatistics.Examine = "刘淼";
            oTransportStatistics.Date = startyear + "--" + endyear;
            oTransportStatistics.ShowReport();
        }
        
    }
    class ReporttransportClass
    {
        public void RunTransportCheck(string id)
        {
            //材料种类	    sort
            //材料名称	    materialName
            //规格		    model
            //起运地		startSite
            //止运地		endSite
            //运输数量	    quantity
            //运输距离	    distance
            //单价		    unitPrice
            //金额（元）	money
            SqlHelper helper = new SqlHelper();
            String sql = "select tsmd.id, coalesce(pn.name,mn.name) as materialName,coalesce(pm.model,mm.model) as model,coalesce(pk.sort,mk.sort) as sort ";
            sql += ",site1.site as startSite,site2.site as endSite,distance,price as unitPrice,tsmId,case mark when 1 then '已终止' else '执行中' end mark,tsmd.count as quantity,tsmd.sum as money,tsm.remark as formula";
            sql += " from transportGoodsInformationCorresponding tgi inner join transportSettlementMethod tsm on tsmid=tsm.id";
            sql += " inner join transportSettlementDetail tsmd on tsmd.tgicId=tgi.id ";
            sql += " left join material m on m.id=mid";
            sql += " left join materialName mn on m.mnid=mn.id left join materialModel mm on m.mmid=mm.id ";
            sql += " left join materialKind mk on mn.mkid=mk.id";
            sql += " left join product p on p.id=pid left join productName pn on p.pnid=pn.id ";
            sql += " left join productModel pm on p.pmid=pm.id ";
            sql += " left join productKind pk on pn.pkid=pk.id";
            sql += " left join site site1 on tgi.sid1=site1.id";
            sql += " left join site site2 on tgi.sid1=site2.id";
            sql += " where tsmd.tsid=" + id;
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add(sql);
            DataSet ds = helper.QueryForDateSet(oArrayList);

            TransportCheck oYearStockPlan = new TransportCheck();
            oYearStockPlan.Source = ds;
            CReportTools tools = new CReportTools();
            DataTable dt = ds.Tables[0];
            Decimal money = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                money += Convert.ToDecimal(dt.Rows[i]["money"]);
            }
            oYearStockPlan.SumMoney = tools.ToUpper(money);
            oYearStockPlan.AccountNum = "3444";
            oYearStockPlan.ContractNum = "100086";
            oYearStockPlan.CoName = "中百";
            oYearStockPlan.Num = "1111";
            oYearStockPlan.InvoiceNo = "0001";
            oYearStockPlan.Supplier = "中百";
            oYearStockPlan.Telephone = "138888888";
            oYearStockPlan.Auditor = "刘淼";
            oYearStockPlan.Examine = "bbb";
            oYearStockPlan.Approve = "ccc";
            oYearStockPlan.AuditorYmd = "2008年5月21号";
            oYearStockPlan.ExamineYmd = "2008年5月22号";
            oYearStockPlan.ApproveYmd = "2008年5月23号";
            oYearStockPlan.ShowReport();
        }
        
        public void RunTransportCheckDetail(string id)
        {
            string sql = "select coalesce(pn.name,mn.name) as materialName,coalesce(pm.model,mm.model) as model  ";
            sql += ",site1.site,site2.site,suttle,tgic.id did,tnc.inputDate,barcode,checkAccountMark2 mark, sn.inputdate as date";
            sql += " ,vi.[no],providerInfo.name as supplierName,transportUnit.[name] as transportName,coalesce(pk.sort,mk.sort) as sort";
            sql += ", sn.grossWeight,sn.tare,sn.suttle,personnelInfo.[name] as personnel";
            sql += " from transportGoodsInformationCorresponding tgic ";
            sql += " inner join transportSettlementDetail tsd on tsd.tgicid=tgic.id ";
            sql += " inner join transportNoteCorresponding tnc on tnc.tsdid=tsd.id ";
            sql += " inner join stockNote sn on sn.id=tnc.snid ";
            sql += " left join material m on mid=m.id ";
            sql += " left join materialName mn on m.mnid=mn.id left join materialModel mm on m.mmid=mm.id ";
            sql += " left join product p on p.id=pid left join productName pn on p.pnid=pn.id ";
            sql += " left join productModel pm on p.pmid=pm.id  ";
            sql += " left join site site1 on tgic.sid1=site1.id ";
            sql += " left join site site2 on tgic.sid2=site2.id ";
            sql += " left join transportSettlement ts on tsd.tsid=ts.id ";
            sql += " left join voitureInfo vi on sn.viid=vi.id";
            sql += " left join indent on sn.iId=indent.id";
            sql += " left join stockContract on indent.scid=stockContract.id";
            sql += " left join providerInfo on stockContract.piId=providerInfo.id";
            sql += " left join personnelInfo on sn.piId1=personnelInfo.id";
            sql += " left join transportUnit on vi.tuid=transportUnit.id";
            sql += " left join materialKind mk on mn.mkid=mk.id";
            sql += " left join productKind pk on pn.pkid=pk.id";

            if (!string.IsNullOrEmpty(id))
                sql += " where ts.id=" + id;
            sql += " union all ";

            sql += "select coalesce(pn.name,mn.name) as materialName,coalesce(pm.model,mm.model) as model  ";
            sql += ",site1.site,site2.site,suttle,tgic.id did,tnc.inputDate,barcode,checkAccountMark2 mark,cn.inputdate as date";
            sql += " ,vi.[no],clientInfo.name as supplierName,transportUnit.[name] as transportName,coalesce(pk.sort,mk.sort) as sort";
            sql += ", cn.grossWeight,cn.tare,cn.suttle,personnelInfo.[name] as personnel";
            sql += " from transportGoodsInformationCorresponding tgic ";
            sql += " inner join transportSettlementDetail tsd on tsd.tgicid=tgic.id ";
            sql += " inner join transportNoteCorresponding tnc on tnc.tsdid=tsd.id ";
            sql += " inner join consignmentNote cn on cn.id=tnc.snid ";
            sql += " left join material m on mid=m.id ";
            sql += " left join materialName mn on m.mnid=mn.id left join materialModel mm on m.mmid=mm.id ";
            sql += " left join product p on p.id=pid left join productName pn on p.pnid=pn.id ";
            sql += " left join productModel pm on p.pmid=pm.id  ";
            sql += " left join site site1 on tgic.sid1=site1.id ";
            sql += " left join site site2 on tgic.sid2=site2.id ";
            sql += " left join transportSettlement ts on tsd.tsid=ts.id ";
            sql += " left join voitureInfo vi on cn.viid=vi.id";
            sql += " left join invoice on cn.iId=invoice.id";
            sql += " left join sellContract on invoice.scid=sellContract.id";
            sql += " left join clientInfo on sellContract.ciId=clientInfo.id";
            sql += " left join personnelInfo on cn.piId1=personnelInfo.id";
            sql += " left join transportUnit on vi.tuid=transportUnit.id";
            sql += " left join materialKind mk on mn.mkid=mk.id";
            sql += " left join productKind pk on pn.pkid=pk.id";
            if (!string.IsNullOrEmpty(id))
                sql += " where ts.id=" + id;
            //日期		    date
            //车牌号码	    no
            //供应商名称	supplierName
            //运输单位名称	transportName
            //材料种类	    sort
            //材料名称	    materialName
            //规格型号	    model
            //毛重		    grossWeight
            //皮重		    tare
            //净重		    suttle
            //检斤员		personnel
            SqlHelper helper = new SqlHelper();
            
            ArrayList oArrayList = new ArrayList();
            oArrayList.Add(sql);
            DataSet ds = helper.QueryForDateSet(oArrayList);

            TransportCheckDetail oTransportCheckDetail = new TransportCheckDetail();
            oTransportCheckDetail.Source = ds;

            oTransportCheckDetail.CoName = "中百";
            oTransportCheckDetail.ShowReport();

        }

 
    }
    class ReportFinanceClass
    {
        public void RunShouldInputRecord(string id)
        {
            //单据号码		        docNum
            //供应商/运输单位名称	supplierName
            //合同名称		        invoiceNum
            //总重量		        shouldMoney
            //总金额		        alreadyMoney
            //票具总数		        arrearsMoney
            SqlHelper helper = new SqlHelper();

            String sql = "select a.[name] as supplierName,c.id as docNum,b.name as invoiceNum,c.totalWeight as shouldMoney,c.sum as alreadyMoney,c.count as arrearsMoney,c.remark as '备注'from clientInfo a left join sellContract b on b.ciid = a.id right join sellProductSettlement c on c.scid = b.id ";
            sql += " where a.id = " + id;
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add(sql);
            DataSet ds = helper.QueryForDateSet(oArrayList);

            ShouldInputRecord oShouldInputRecord = new ShouldInputRecord();
            oShouldInputRecord.Source = ds;
            oShouldInputRecord.ShowReport();
        }
        public void RunReceivablesRecord(string id)
        {
            //收款日期	    date
            //客户名称	    guestName
            //支票号码	    invoiceNum
            //金额      	historyAlreadyMoney
            //拖欠总金额	arrearsTotalMoney
            //发票号	TheIncludeMoney
            //备注		    backup
            SqlHelper helper = new SqlHelper();
            String sql = "SELECT fundsRecorder.inputDate as date,clientInfo.name as guestName, fundsRecorder.checkNo as invoiceNum,fundsRecorder.paidUp as historyAlreadyMoney,fundsRecorder.cash2 as arrearsTotalMoney,fundsRecorder.invoiceNo as TheIncludeMoney,fundsRecorder.remark as [backup]";
            sql +=" FROM dbo.fundsRecorder LEFT OUTER JOIN dbo.clientInfo ON dbo.fundsRecorder.id = dbo.clientInfo.id";
            sql += " where type='收款' ";
            sql += " and customerId=" + id;
                        
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add(sql);
            DataSet ds = helper.QueryForDateSet(oArrayList);

            ReceivablesRecord oReceivablesRecord = new ReceivablesRecord();
            oReceivablesRecord.Source = ds;
            oReceivablesRecord.ShowReport(); 
        }
        public void RunShouldOutRecord(string id)
        {
            //单据号码		        docNum
            //供应商/运输单位名称	supplierName
            //合同名称		        invoiceNum
            //货物总重		        shouldMoney
            //总金额		        alreadyMoney
            //票据数		        arrearsMoney
            SqlHelper helper = new SqlHelper();
            string strSQL = string.Format(@"
                select 
                a.name as supplierName,
                c.id as docNum, 
                b.name as invoiceNum,
                c.totalWeight as shouldMoney,
                c.sum as alreadyMoney, 
                c.count as arrearsMoney               
                from providerInfo a
                left join stockContract b on b.piid = a.id
                right join stockMaterialSettlement c on c.scid = b.id
                where a.id = {0} and c.checkupMan is not null
                ", id);
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add(strSQL);
            DataSet ds = helper.QueryForDateSet(oArrayList);

            ShouldOutRecord oShouldOutRecord = new ShouldOutRecord();
            oShouldOutRecord.Source = ds;
            oShouldOutRecord.ShowReport();
        }
        public void RunPayablesRecord(string id)
        {
            //收款日期	    date
            //客户名称	    guestName
            //支票号码	    invoiceNum
            //发生金额  	historyAlreadyMoney
            //拖欠总金额	arrearsTotalMoney
            //发票号	TheIncludeMoney
            //备注		    backup
            SqlHelper helper = new SqlHelper();
            string strSQL = "SELECT  fundsRecorder.inputdate as date,providerInfo.name as guestName,fundsRecorder.checkNo as invoiceNum,";
	        strSQL += " fundsRecorder.paidUp as historyAlreadyMoney,fundsRecorder.cash2 as arrearsTotalMoney,";
	        strSQL += " fundsRecorder.invoiceNo as TheIncludeMoney,fundsRecorder.remark as [backup]";
            strSQL += " FROM dbo.fundsRecorder LEFT OUTER JOIN";
            strSQL += " dbo.providerInfo ON dbo.fundsRecorder.customerId = dbo.providerInfo.id";
            strSQL += " where type='付款'";
            strSQL += " and customerId=" + id;
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add(strSQL);
            DataSet ds = helper.QueryForDateSet(oArrayList);

            PayablesRecord oPayablesRecord = new PayablesRecord();
            oPayablesRecord.Source = ds;
            oPayablesRecord.ShowReport(); 
        }
    }
    class ReportProductClass
    {
        public void RunYearProducePlan(string id)
        {
            SqlHelper helper = new SqlHelper();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT productionPlanDetail.*,name ,model ,sort");    
            sql.Append(" FROM dbo.productionPlan RIGHT OUTER JOIN");
            sql.Append(" dbo.productionPlanDetail ON dbo.productionPlan.id = dbo.productionPlanDetail.ppId LEFT OUTER JOIN");
            sql.Append(" dbo.productKind INNER JOIN");
            sql.Append("  dbo.productName ON dbo.productKind.id = dbo.productName.pkId INNER JOIN");
            sql.Append("  dbo.product INNER JOIN");
            sql.Append("  dbo.productModel ON dbo.product.pmId = dbo.productModel.id ON dbo.productName.id = dbo.product.pnId ON ");
            sql.Append(" dbo.productionPlanDetail.pId = dbo.product.id");
            sql.Append(" where productionPlan.id="+id);
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add(sql.ToString());
            DataSet ds = helper.QueryForDateSet(oArrayList);

            YearProducePlan oYearProducePlan = new YearProducePlan();
            oYearProducePlan.Source = ds;
            //年度
            oYearProducePlan.Year = "2009";
            //公司名称
            oYearProducePlan.CoName = "中百";
            //文档编号
            oYearProducePlan.Number = "20090101";
            //制表
            oYearProducePlan.Tabler = "张三";
            //审核
            oYearProducePlan.Auditer = "李四";
            //审批
            oYearProducePlan.Approvaler = "王五";
            // 显示报表
            oYearProducePlan.ShowReport(); 
        }
        public void RunYearMaterialRequirementsPlanning(string ppid)
        {
            SqlHelper helper = new SqlHelper();
            StringBuilder sqlstr = new StringBuilder();

            sqlstr.Append(" select tpd.mid,mn.name,mm.model,mk.sort ");
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
            //sqlstr.Append(",getdate() ");
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
            sqlstr.Append(") as p ,material m,materialName mn,materialModel mm, materialKind mk ");
            sqlstr.Append("where ppd.tpid=tpd.tpid and ppd.tpid=Proportion.tpid and tpd.mid=Proportion.mid and ppd.pid=p.id ");
            sqlstr.Append(" and tpd.mid=m.id and m.mnid=mn.id and m.mmid=mm.id and mn.mkId=mk.id ");
            sqlstr.Append("and Proportion.type=(select case when p.sort='混合料' then 1 else 2 end) ");
            sqlstr.Append("and tpd.type=(select case when p.sort='混合料' then 1 else 2 end) ");
            sqlstr.Append("and ppid=" + ppid);

            

            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add(sqlstr.ToString());
            DataSet ds = helper.QueryForDateSet(oArrayList);

            YearMaterialRequirementsPlanning oYearMaterialRequirementsPlanning = new YearMaterialRequirementsPlanning();
            oYearMaterialRequirementsPlanning.Source = ds;
            //年度
            oYearMaterialRequirementsPlanning.Year = "2009";
            //公司名称
            oYearMaterialRequirementsPlanning.CoName = "中百";
            //文档编号
            oYearMaterialRequirementsPlanning.Number = "20090101";
            //制表
            oYearMaterialRequirementsPlanning.Tabler = "张三";
            //审核
            oYearMaterialRequirementsPlanning.Auditer = "李四";
            //审批
            oYearMaterialRequirementsPlanning.Approvaler = "王五";
            // 显示报表
            oYearMaterialRequirementsPlanning.ShowReport(); 
        }
        public void RunMixingMachineProduceNotice(string id)
        {
            SqlHelper helper = new SqlHelper();
            StringBuilder sql = new StringBuilder();

            sql.Append(" select pk.sort, pnt.id,p.pnid,p.pmid,pn.name,pm.model,pnt.planQuantity,Convert(varchar ");
            sql.Append(" (10),pnt.startDate,120) as startDate,ei.no,pnt.assessor,pnt.checkupMan,pnt.notifyMan,Convert ");
            sql.Append(" (varchar(10),pnt.notifyDate,120) as notifyDate,psp.ppid,tsp.tpid,ptId,psp.eiid from ");
            sql.Append(" produceNotice pnt,produceSendProportionDetail psp,produceProportion  ");
            sql.Append("  pp,product p,productName pn,productModel pm,productKind pk,targetSendProportionDetail ");

            sql.Append(" tsp,equipmentInformation ei where ei.id=psp.eiid and pnt.spId=psp.spId and psp.ppid=pp.id and pp.pid=p.id and ");
            sql.Append("  p.pnid=pn.id and p.pmid=pm.id and pn.pkid=pk.id and pnt.spid=tsp.spid  ");
            sql.Append(" and pnt.id=" + id);
            sql.Append(" order by notifyDate desc ");
            
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add(sql.ToString());
            DataSet ds = helper.QueryForDateSet(oArrayList);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    string sendProportionId = ds.Tables[0].Rows[0]["id"];

            //    ArrayList sqlStr = new ArrayList();

            //    sqlStr.Add("");

            //    ProduceDataSet.生产配合比信息DataTable o生产配合比信息DataTable = new ProduceDataSet.生产配合比信息DataTable();
            //    ProduceDataSet.生产配合比信息Row o生产配合比信息Row = (ProduceDataSet.生产配合比信息Row)o生产配合比信息DataTable.NewRow();
            //    o生产配合比信息Row.Proportion1 = "生产配合比编号001";
            //    o生产配合比信息Row.Proportion2 = "沥青1";
            //    o生产配合比信息Row.Proportion3 = "石粉1";
            //    o生产配合比信息Row.Proportion4 = "4_热料仓1";
            //    o生产配合比信息Row.Proportion5 = "5_热料仓1";
            //    o生产配合比信息Row.Proportion6 = "生产配合比编号001";
            //    o生产配合比信息Row.Proportion7 = "沥青1";
            //    o生产配合比信息Row.Proportion8 = "石粉1";
            //    o生产配合比信息Row.ProportionValue1 = "生产配合比编号001";
            //    o生产配合比信息Row.ProportionValue2 = "沥青1";
            //    o生产配合比信息Row.ProportionValue3 = "石粉1";
            //    o生产配合比信息Row.ProportionValue4 = "4_热料仓1";
            //    o生产配合比信息Row.ProportionValue5 = "5_热料仓1";
            //    o生产配合比信息Row.ProportionValue6 = "生产配合比编号001";
            //    o生产配合比信息Row.ProportionValue7 = "沥青1";
            //    o生产配合比信息Row.ProportionValue8 = "石粉1";
                
            //    o生产配合比信息DataTable.Add生产配合比信息Row(o生产配合比信息Row);
            //    ds.Tables.Add(o生产配合比信息DataTable);

            //    ProduceDataSet.目标配合比信息DataTable o目标配合比信息DataTable = new ProduceDataSet.目标配合比信息DataTable();
            //    ProduceDataSet.目标配合比信息Row o目标配合比信息Row1 = (ProduceDataSet.目标配合比信息Row)o目标配合比信息DataTable.NewRow();
            //    ProduceDataSet.目标配合比信息Row o目标配合比信息Row2 = (ProduceDataSet.目标配合比信息Row)o目标配合比信息DataTable.NewRow();
            //    o目标配合比信息Row1.目标配合比编号 = "目标配合比编号001";
            //    o目标配合比信息Row1.序号 = "序号1";
            //    o目标配合比信息Row1.材料种类 = "材料种类1";
            //    o目标配合比信息Row1.材料名称 = "材料名称1";
            //    o目标配合比信息Row1.规格型号 = "规格型号1";
            //    o目标配合比信息Row1.油石比 = "油石比1";
            //    o目标配合比信息Row1.产地 = "产地1";
            //    o目标配合比信息Row1.生产厂家 = "生产厂家1";

            //    o目标配合比信息Row2.目标配合比编号 = "目标配合比编号001";
            //    o目标配合比信息Row2.序号 = "序号2";
            //    o目标配合比信息Row2.材料种类 = "材料种类2";
            //    o目标配合比信息Row2.材料名称 = "材料名称2";
            //    o目标配合比信息Row2.规格型号 = "规格型号2";
            //    o目标配合比信息Row2.油石比 = "油石比2";
            //    o目标配合比信息Row2.产地 = "产地2";
            //    o目标配合比信息Row2.生产厂家 = "生产厂家2";
            //    o目标配合比信息DataTable.Add目标配合比信息Row(o目标配合比信息Row1);
            //    o目标配合比信息DataTable.Add目标配合比信息Row(o目标配合比信息Row2);

            //    ds.Tables.Add(o目标配合比信息DataTable);
            //}
            MixingMachineProduceNotice oMixingMachineProduceNotice = new MixingMachineProduceNotice();
            oMixingMachineProduceNotice.Source = ds;

            //公司名称
            oMixingMachineProduceNotice.CoName = "中百";
            //编号
            oMixingMachineProduceNotice.Number = "20090101";
            //制表
            oMixingMachineProduceNotice.Tabler = "张三";
            // 部门主管
            oMixingMachineProduceNotice.Manager = "李四";
            //制表日期
            oMixingMachineProduceNotice.CDate = "2009年13月36日";

            oMixingMachineProduceNotice.备注 = "备注";
            // 显示报表
            oMixingMachineProduceNotice.ShowReport(); 
        }
    }
}
