using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DasherStation.common;
using System.Data;
using DasherStation.storage;
using DasherStation.system;
using System.Collections;

namespace DasherStation.ReportDistrict.storageReport
{
    
    class ReportStorageClass
    {
        SqlHelper helper = new SqlHelper();

        // 单位名称;
        private string name_value()
        {
            string sql = "SELECT dasherName FROM basicInfo";
            DataTable dt = helper.QueryForDateSet(new ArrayList() { sql }).Tables[0];
            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "";
        }

        /*
        * 方法名称： RunStuffInAccount
        * 方法功能描述：打印材料入库台帐相关信息;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-21
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void RunStuffInAccount(StockInRClass stockclass, int mkId, int mnId)
        {
            LinkSelect ls = new LinkSelect();
            ls.Viewfields.Add("stockNote.inputDate as snInputDate");
            ls.Viewfields.Add("materialKind.sort as mkSort");
            ls.Viewfields.Add("materialName.name as mnName");
            ls.Viewfields.Add("materialModel.model as mmModel");
            ls.Viewfields.Add("providerInfo.name as piName");
            ls.Viewfields.Add("voitureInfo.no as viNo");
            ls.Viewfields.Add("transportUnit.name as tuName");
            ls.Viewfields.Add("stockNote.suttle as snSuttle");
            ls.Viewfields.Add("indent.unitPrice  as unitPrice");
            ls.Viewfields.Add("(stockNote.suttle * indent.unitPrice)  as totalPrice");
            ls.Viewfields.Add("personnelInfo.name as snSurveyor ");

            ls.TableNames.Add("stockNote");
            ls.TableNames.Add("voitureInfo");
            ls.LinkConds.Add("stockNote.viId = voitureInfo.id");

            ls.TableNames.Add("personnelInfo");
            ls.LinkConds.Add("stockNote.piId1 = personnelInfo.id");
            ls.TableNames.Add("transportGoodsInformationCorresponding");
            ls.LinkConds.Add("stockNote.tgicId = transportGoodsInformationCorresponding.id");
            ls.TableNames.Add("transportContract");
            ls.LinkConds.Add("transportGoodsInformationCorresponding.tcId = transportContract.id");
            ls.TableNames.Add("transportUnit");
            ls.LinkConds.Add("transportContract.tuId = transportUnit.id");

            ls.TableNames.Add("indent");
            ls.LinkConds.Add("stockNote.iId = indent.id");

            ls.TableNames.Add("stockContract");
            ls.LinkConds.Add("indent.scId = stockContract.id");
            ls.TableNames.Add("providerInfo");
            ls.LinkConds.Add("stockContract.piId = providerInfo.id");
            ls.TableNames.Add("material");
            ls.LinkConds.Add("indent.mId = material.id");
            ls.TableNames.Add("materialModel");
            ls.LinkConds.Add("material.mmId = materialModel.id");
            ls.TableNames.Add("materialName");
            ls.LinkConds.Add("material.mnId = materialName.id");
            ls.TableNames.Add("materialKind");
            ls.LinkConds.Add("materialName.mKId = materialKind.id");

            if (!stockclass.Mid.Equals(0))
            {
                ls.Conds.Add("indent.mId = " + stockclass.Mid);
            }

            if (!stockclass.Providerid.Equals(0))
            {
                ls.Conds.Add("providerInfo.id = " + stockclass.Providerid);
            }

            if (!stockclass.Transportid.Equals(0))
            {
                ls.Conds.Add("transportUnit.id = " + stockclass.Transportid);
            }

            if (!stockclass.Voitureid.Equals(0))
            {
                ls.Conds.Add("voitureInfo.id = " + stockclass.Voitureid);
            }

            if ((stockclass.BeginTime != null) && (!stockclass.BeginTime.Equals("")))
            {
                ls.Conds.Add("stockNote.inputdate>=" + "'" + stockclass.BeginTime + "'");
            }
            if ((stockclass.EndTime != null) && (!stockclass.EndTime.Equals("")))
            {
                ls.Conds.Add("stockNote.inputdate<=" + "'" + stockclass.EndTime + "'");
            }
            if ((stockclass.State != null) && (!stockclass.State.Equals("")))
            {
                switch (stockclass.State)
                {
                    case "已审核":
                        {
                            ls.Conds.Add("stockNote.assessor is not NULL");
                            break;
                        }
                    case "已审批":
                        {
                            ls.Conds.Add("stockNote.checkupMan is not NULL");
                            break;
                        }
                    case "未审核、审批":
                        {
                            ls.Conds.Add("stockNote.assessor is NULL");
                            ls.Conds.Add("stockNote.checkupMan is NULL");
                            break;
                        }
                }
            }
            if ((mkId != 0) && (stockclass.Mid == 0))
            {
                ls.Conds.Add("materialKind.id = " + mkId);
            }
            if ((mnId != 0) && (stockclass.Mid == 0))
            {
                ls.Conds.Add("materialName.id = " + mnId);
            }

            DataSet ds = ls.LeftLinkOpen();
            StuffInAccount oStuffInAccount = new StuffInAccount();
            oStuffInAccount.Source = ds;
            oStuffInAccount.Unit = name_value();
            oStuffInAccount.Num = "";
            oStuffInAccount.MakeTable = "";
            oStuffInAccount.StuffCheck = "";
            oStuffInAccount.Check = "";
            oStuffInAccount.ShowReport();
        }

        /*
        * 方法名称： RunStuffInAccount
        * 方法功能描述：打印产品入库台帐相关信息;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-21
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void RunProductInAccount(string sqlWhere)
        {
            string lSearchStr = "select pp.inputDate as 生产日期";
            lSearchStr = lSearchStr + ", pk.sort AS 产品种类, pn.name AS 产品名称, pm.model AS 产品规格";
            lSearchStr = lSearchStr + ", en.name AS 设备名称,pp.number as 入库数量";
            lSearchStr = lSearchStr + ",pp.unitPrice as 入库单价,(pp.number*pp.unitPrice )as 入库金额";
            lSearchStr = lSearchStr + " FROM productInDepot pp INNER JOIN  equipmentInformation AS ei ON ";
            lSearchStr = lSearchStr + " pp.eiId = ei.id INNER JOIN  equipmentName AS en ON ei.enId = en.id INNER JOIN  product AS p ON ";
            lSearchStr = lSearchStr + " pp.pId = p.id INNER JOIN  productName AS pn ON  p.pnId = pn.id INNER JOIN  productKind AS pk ON ";
            lSearchStr = lSearchStr + " pn.pkId = pk.id INNER JOIN  productModel AS pm ON p.pmId = pm.id ";
            lSearchStr = lSearchStr + " Where 1=1";

            if (!sqlWhere.Equals(""))
            {
                lSearchStr = lSearchStr + sqlWhere;
            }

            DataSet ds = helper.QueryForDateSet(new ArrayList() { lSearchStr });
            ProductInAccount oProductInAccount = new ProductInAccount();
            oProductInAccount.Source = ds;
            oProductInAccount.Unit = name_value();
            oProductInAccount.Num = "";
            oProductInAccount.MakeTable = "";
            oProductInAccount.Charge = "";
            oProductInAccount.ShowReport();
        }

        /*
        * 方法名称： RunStuffOutAccount
        * 方法功能描述：打印产品出库台帐相关信息;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-21
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void RunProductOutAccount(StockOutRClass stockORClass, int pkId, int pnId)
        { 
            LinkSelect ls = new LinkSelect();

            ls.Viewfields.Add("consignmentNote.inputDate as 时间");
            ls.Viewfields.Add("productKind.sort as 产品种类");
            ls.Viewfields.Add("productName.name as 产品名称");
            ls.Viewfields.Add("productModel.model as 产品规格");
            ls.Viewfields.Add("clientInfo.name as 客户名称");
            ls.Viewfields.Add("voitureInfo.no as 车牌号");
            ls.Viewfields.Add("transportUnit.name as 运输单位");
            ls.Viewfields.Add("consignmentNote.suttle as 净重");
            ls.Viewfields.Add("invoice.unitPrice as 销售单价");
            ls.Viewfields.Add("consignmentNote.suttle * invoice.unitPrice as 销售金额");
            ls.Viewfields.Add("personnelInfo.name as 检斤员 ");

            ls.TableNames.Add("consignmentNote");
            ls.TableNames.Add("voitureInfo");
            ls.LinkConds.Add("consignmentNote.viId = voitureInfo.id");

            ls.TableNames.Add("personnelInfo");
            ls.LinkConds.Add("consignmentNote.piId1 = personnelInfo.id");
            ls.TableNames.Add("transportGoodsInformationCorresponding");
            ls.LinkConds.Add("consignmentNote.tgicId = transportGoodsInformationCorresponding.id");

            ls.TableNames.Add("transportContract");
            ls.LinkConds.Add("transportGoodsInformationCorresponding.tcId = transportContract.id");

            ls.TableNames.Add("transportUnit");
            ls.LinkConds.Add("transportContract.tuId = transportUnit.id");

            ls.TableNames.Add("invoice");
            ls.LinkConds.Add("consignmentNote.iId = invoice.id");

            ls.TableNames.Add("sellContract");
            ls.LinkConds.Add("invoice.scId = sellContract.id");

            ls.TableNames.Add("clientInfo");
            ls.LinkConds.Add("sellContract.ciId = clientInfo.id");

            ls.TableNames.Add("product");
            ls.LinkConds.Add("invoice.pId = product.id");

            ls.TableNames.Add("productModel");
            ls.LinkConds.Add("product.pmId = productModel.id");

            ls.TableNames.Add("productName");
            ls.LinkConds.Add("product.pnId = productName.id");
            ls.TableNames.Add("productKind");
            ls.LinkConds.Add("productName.pkId = productKind.id");

            if ((pkId != 0) && (stockORClass.Pid == 0))
            {
                ls.Conds.Add("productKind.id = " + pkId);
            }

            if ((pnId != 0) && (stockORClass.Pid == 0))
            {
                ls.Conds.Add("productName.id = " + pnId);
            }

            if (!stockORClass.Pid.Equals(0))
            {
                ls.Conds.Add("invoice.pId = " + stockORClass.Pid);
            }

            if (!stockORClass.Clientid.Equals(0))
            {
                ls.Conds.Add("clientInfo.id = " + stockORClass.Clientid);
            }

            if (!stockORClass.Transportid.Equals(0))
            {
                ls.Conds.Add("transportUnit.id = " + stockORClass.Transportid);
            }

            if (!stockORClass.Voitureid.Equals(0))
            {
                ls.Conds.Add("voitureInfo.id = " + stockORClass.Voitureid);
            }

            if ((stockORClass.BeginTime != null) && (!stockORClass.BeginTime.Equals("")))
            {
                ls.Conds.Add("consignmentNote.inputdate>=" + "'" + stockORClass.BeginTime + "'");
            }
            if ((stockORClass.EndTime != null) && (!stockORClass.EndTime.Equals("")))
            {
                ls.Conds.Add("consignmentNote.inputdate<=" + "'" + stockORClass.EndTime + "'");
            }
            if ((stockORClass.State != null) && (!stockORClass.State.Equals("")))
            {
                switch (stockORClass.State)
                {
                    case "已审核":
                        {
                            ls.Conds.Add("consignmentNote.assessor is not NULL");
                            break;
                        }
                    case "已审批":
                        {
                            ls.Conds.Add("consignmentNote.checkupMan is not NULL");
                            break;
                        }
                    case "未审核、审批":
                        {
                            ls.Conds.Add("consignmentNote.assessor is NULL");
                            ls.Conds.Add("consignmentNote.checkupMan is NULL");
                            break;
                        }
                }
            }

            DataSet ds = ls.LeftLinkOpen();
            ProductOutAccount oProductOutAccount = new ProductOutAccount();
            oProductOutAccount.Source = ds;
            oProductOutAccount.Unit = name_value();
            oProductOutAccount.Num = "";
            oProductOutAccount.MakeTable = "";
            oProductOutAccount.Check = "";
            oProductOutAccount.Approve = "";
            oProductOutAccount.ShowReport();
        }

        /*
        * 方法名称： RunMonthStuffStorage
        * 方法功能描述：打印材料库存月报相关信息;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-21
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void RunMonthStuffStorage(string data)
        {
            string data_begion = data.Substring(0,7);
            string lSearchStr = " Select material.id as 材料ID,mk.sort as mkSort,mn.name as mnName ,mm.model as mmModel ";
            lSearchStr = lSearchStr + " ,(select sum(sn.suttle) from stockNote sn,indent i where sn.iId = i.id and i.mid = material.id and sn.checkupMan is not NULL) as tmInNumber";
            lSearchStr = lSearchStr + " ,(select sum(mm.number) from materialOutDepot mm where mm.mid = material.id and mm.checkupMan is not NULL) as tmOutNumber";
            lSearchStr = lSearchStr + " ,(select sum(sn.suttle*i.unitPrice) from stockNote sn,indent i  where sn.iId = i.id and i.mid = material.id and sn.checkupMan is not NULL) as tmInPrice";
            lSearchStr = lSearchStr + " ,(select sum(mm.number*mm.unitPrice) from materialOutDepot mm where mm.mid = material.id and mm.checkupMan is not NULL) as tmOutPrice";
            lSearchStr = lSearchStr + " ,(select msl.quantity1 from materialStockList msl where msl.mid = material.id) as tmTotalNumber";
            lSearchStr = lSearchStr + " ,(select msl.money  from materialStockList msl where msl.mid = material.id) as tmTotalPrice ";
            lSearchStr = lSearchStr + " ,0.0 as lmNumber,0.0 as lmPrice, '' as inputDate";
            lSearchStr = lSearchStr + " From stockNote Left Outer Join indent ON stockNote.iId = indent.id Left Outer Join material ON indent.mId = material.id  ";
            lSearchStr = lSearchStr + " Left Outer Join materialName mn on material.mnid = mn.id Left Outer Join materialKind mk on mn.mkid = mk.id Left Outer Join materialModel mm On material.mmid = mm.id";
            lSearchStr = lSearchStr + " Where stockNote.checkupMan is not NULL and stockNote.inputDate between '" + data_begion + "-01' and ' " +  data + " ' ";
            lSearchStr = lSearchStr + " group by material.id,mk.sort,mn.name,mm.model";
            lSearchStr = lSearchStr + " union  ";
            lSearchStr = lSearchStr + " Select m.mid as 材料ID,mk.sort as mkSort,mn.name as mnName ,mm.model as mmModel";
            lSearchStr = lSearchStr + " ,(select sum(sn.suttle) from stockNote sn,indent i where sn.iId = i.id and i.mid = m.mid and sn.checkupMan is not NULL) as tmInNumber";
            lSearchStr = lSearchStr + " ,(select sum(mm.number) from materialOutDepot mm where mm.mid = m.mid and mm.checkupMan is not NULL) as tmOutNumber";
            lSearchStr = lSearchStr + " ,(select sum(sn.suttle*i.unitPrice) from stockNote sn,indent i  where sn.iId = i.id and i.mid = m.mid and sn.checkupMan is not NULL) as tmInPrice";
            lSearchStr = lSearchStr + " ,(select sum(mm.number*mm.unitPrice) from materialOutDepot mm where mm.mid = m.mid and mm.checkupMan is not NULL) as tmOutPrice ";
            lSearchStr = lSearchStr + " ,(select msl.quantity1 from materialStockList msl where msl.mid = m.mid) as tmTotalNumber";
            lSearchStr = lSearchStr + " ,(select msl.money  from materialStockList msl where msl.mid = m.mid) as tmTotalPrice";
            lSearchStr = lSearchStr + " ,0.0 as lmNumber,0.0 as lmPrice, '' as inputDate";
            lSearchStr = lSearchStr + " From materialOutDepot m ,material ma, materialName mn ,materialKind mk, materialModel mm Where m.mid = ma.id and ma.mnid = mn.id and mn.mkid = mk.id and ma.mmid = mm.id ";
            lSearchStr = lSearchStr + " and m.checkupMan is not NULL  and m.inputDate between ' " + data_begion + "-01' and  '" + data  + "'";
            lSearchStr = lSearchStr + " group by m.mid ,mk.sort,mn.name,mm.model";

            DataSet ds = helper.QueryForDateSet(lSearchStr);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["tmInNumber"].ToString().Equals(""))
                {
                    row["tmInNumber"] = 0;
                }
                if (row["tmInPrice"].ToString().Equals(""))
                {
                    row["tmInPrice"] = 0;
                }
                if (row["tmOutNumber"].ToString().Equals(""))
                {
                    row["tmOutNumber"] = 0;
                }
                if (row["tmOutPrice"].ToString().Equals(""))
                {
                    row["tmOutPrice"] = 0;
                }
                if (row["tmTotalNumber"].ToString().Equals(""))
                {
                    row["tmTotalNumber"] = 0;
                }
                if (row["tmTotalPrice"].ToString().Equals(""))
                {
                    row["tmTotalPrice"] = 0;
                }
                row["lmNumber"] = decimal.Parse(row["tmTotalNumber"].ToString()) - (decimal.Parse(row["tmInNumber"].ToString()) - decimal.Parse(row["tmOutNumber"].ToString()));
                row["lmPrice"] = decimal.Parse(row["tmTotalPrice"].ToString()) - (decimal.Parse(row["tmInPrice"].ToString()) - decimal.Parse(row["tmOutPrice"].ToString()));
                
                row["inputDate"] = data_begion;
            }

            MonthStuffStorage oMonthStuffStorage = new MonthStuffStorage();
            
            oMonthStuffStorage.Source = ds;
            oMonthStuffStorage.Unit = name_value();
            oMonthStuffStorage.Num = "";
            oMonthStuffStorage.MakeTable = "";
            oMonthStuffStorage.Approve = "";
            oMonthStuffStorage.Check = "";
            oMonthStuffStorage.ShowReport();
        }

        /*
        * 方法名称： RunMonthProductStorage
        * 方法功能描述：打印产品库存月报相关信息;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-21
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void RunMonthProductStorage(string data)
        {
            string data_begion = data.Substring(0, 7);
            string lSearchStr = " Select p.pid as 产品ID,pk.sort as 产品种类,pn.name as 产品名称 ,pm.model as 规格型号 ";
            lSearchStr = lSearchStr + ",(select sum(pp.number) from productInDepot pp where pp.pid = p.pid and pp.checkupMan is not NULL) as 本月入库数量";
            lSearchStr = lSearchStr + ",(select sum(cn.suttle) from consignmentNote cn,invoice i where cn.iId = i.id and i.pid = p.pid and cn.checkupMan is not NULL)as 本月出库数量";
            lSearchStr = lSearchStr + ",(select sum(pp.number * pp.unitPrice) from productInDepot pp where pp.pid = p.pid and pp.checkupMan is not NULL) as 本月入库金额  ";
            lSearchStr = lSearchStr + ",(select sum(cn.suttle * i.unitPrice)from consignmentNote cn,invoice i where cn.iId = i.id and i.pid = p.pid and cn.checkupMan is not NULL)as 本月出库金额  ";
            lSearchStr = lSearchStr + ",(select psl.suttle1 from productStockList psl where psl.pid = p.pid) as 月底结存数量 ";
            lSearchStr = lSearchStr + ",(select psl.money  from productStockList psl where psl.pid = p.pid) as 月底结存金额 ";
            lSearchStr = lSearchStr + ", 0.0 as '上月结存数量' , 0.0 as '上月结存金额','' as '年月'";
            lSearchStr = lSearchStr + " From productInDepot p , product pr , productKind pk,productName pn, productModel pm ";
            lSearchStr = lSearchStr + " Where p.pid = pr.id and pr.pnid = pn.id and pr.pmid = pm.id and pn.pkid = pk.id and p.checkupMan is not NULL  ";
            lSearchStr = lSearchStr + " and p.inputDate between '" + data_begion + "-01' and '" + data + "'";
            lSearchStr = lSearchStr + " group by p.pid ,pk.sort,pn.name,pm.model union";
            lSearchStr = lSearchStr + " Select product.id as 产品ID,pk.sort as 产品种类,pn.name as 产品名称 ,pm.model as 规格型号";
            lSearchStr = lSearchStr + " ,(select sum(pp.number) from productInDepot pp where pp.pid = product.id and pp.checkupMan is not NULL) as 本月入库数量";
            lSearchStr = lSearchStr + " ,(select sum(cn.suttle) from consignmentNote cn,invoice i where cn.iId = i.id and i.pid = product.id and cn.checkupMan is not NULL)as 本月出库数量";
            lSearchStr = lSearchStr + " ,(select sum(pp.number * pp.unitPrice) from productInDepot pp where pp.pid = product.id and pp.checkupMan is not NULL) as 本月入库金额";
            lSearchStr = lSearchStr + " ,(select sum(cn.suttle * i.unitPrice)from consignmentNote cn,invoice i where cn.iId = i.id and i.pid = product.id and cn.checkupMan is not NULL)as 本月出库金额 ";
            lSearchStr = lSearchStr + " ,(select psl.suttle1 from productStockList psl where psl.pid = product.id) as 月底结存数量";
            lSearchStr = lSearchStr + " ,(select psl.money  from productStockList psl where psl.pid = product.id) as 月底结存金额";
            lSearchStr = lSearchStr + " , 0.0 as '上月结存数量', 0.0 as '上月结存金额','' as '年月'";
            lSearchStr = lSearchStr + " From consignmentNote,invoice,product, productKind pk,productName pn, productModel pm";
            lSearchStr = lSearchStr + " Where  product.pnid = pn.id and product.pmid = pm.id and pn.pkid = pk.id and";
            lSearchStr = lSearchStr + " consignmentNote.inputDate between '" + data_begion + "-01' and '" + data + "'";
            lSearchStr = lSearchStr + " and consignmentNote.iId = invoice.id and invoice.pId = product.id and consignmentNote.checkupMan is not NULL and consignmentNote.inputDate between '2009-4-01' and '2009-4-20'";
            lSearchStr = lSearchStr + " group by product.id ,pk.sort,pn.name,pm.model";

            DataSet ds = helper.QueryForDateSet(lSearchStr);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["本月入库数量"].ToString().Equals(""))
                {
                    row["本月入库数量"] = 0;
                }
                if (row["本月入库金额"].ToString().Equals(""))
                {
                    row["本月入库金额"] = 0;
                }
                if (row["本月出库数量"].ToString().Equals(""))
                {
                    row["本月出库数量"] = 0;
                }
                if (row["本月出库金额"].ToString().Equals(""))
                {
                    row["本月出库金额"] = 0;
                }
                if (row["月底结存数量"].ToString().Equals(""))
                {
                    row["月底结存数量"] = 0;
                }
                if (row["月底结存金额"].ToString().Equals(""))
                {
                    row["月底结存金额"] = 0;
                }
                row["上月结存数量"] = decimal.Parse(row["月底结存数量"].ToString()) - (decimal.Parse(row["本月入库数量"].ToString()) - decimal.Parse(row["本月出库数量"].ToString()));
                row["上月结存金额"] = decimal.Parse(row["月底结存金额"].ToString()) - (decimal.Parse(row["本月入库金额"].ToString()) - decimal.Parse(row["本月出库金额"].ToString()));
                row["年月"] = data_begion;
            }
            
            MonthProductStorage oMonthProductStorage = new MonthProductStorage();
            oMonthProductStorage.Source = ds;
            oMonthProductStorage.Unit = name_value();
            oMonthProductStorage.Num = "";
            oMonthProductStorage.MakeTable = "";
            oMonthProductStorage.Approve = "";
            oMonthProductStorage.Check = "";
            oMonthProductStorage.ShowReport();
        }

    }
}
