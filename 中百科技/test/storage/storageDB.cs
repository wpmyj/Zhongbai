using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DasherStation.system;
using System.Data;
using System.Collections;
using DasherStation.common;
using DasherStation.produce;

namespace DasherStation.storage
{
    public class storageDB
    {
        SqlHelper sqlHelper = new SqlHelper();
        /*
        * 方法名称：Update_Assess()
        * 方法功能描述：更新审核人方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Update_Assess(string tableName,long id,string assessor)
        {
            string lUpdateStr = "UPDATE " + tableName + " SET ";
            if (assessor != "NULL")
            {
                lUpdateStr = lUpdateStr + "assessor = '" + assessor + "' ,assessDate = getdate()";
            }
            else
            {
                lUpdateStr = lUpdateStr + "assessor = " + assessor + " ,assessDate = getdate()";
            }
            lUpdateStr = lUpdateStr + " WHERE id = " + id ;

            return sqlHelper.Update(new ArrayList() { lUpdateStr });
        }

        /*
        * 方法名称：Update_Checkup()
        * 方法功能描述：更新审批人方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Update_Checkup(string tableName, long id, string checkup)
        {
            string lUpdateStr = "UPDATE " + tableName + " SET ";
            lUpdateStr = lUpdateStr + "checkupMan = '" + checkup + "' ,checkupDate = getdate()";
            lUpdateStr = lUpdateStr + " WHERE id = " + id;

            return sqlHelper.Update(new ArrayList() { lUpdateStr });
        }
    }

    #region 材料台帐数据层方法
    /*
     * 类名称：StockInRDB
     * 类功能描述：材料台帐数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-11
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class StockInRDB
    {
        SqlHelper sqlHelper = new SqlHelper();
        /*
        * 方法名称：MaterialINSearch()
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
        public DataTable MaterialINSearch(StockInRClass stockclass, int mkId, int mnId)
        {
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("stockNote.id as 流水号");
            ls.Viewfields.Add("stockNote.inputDate as 日期");
            ls.Viewfields.Add("materialKind.sort as 材料种类");
            ls.Viewfields.Add("materialName.name as 材料名称");
            ls.Viewfields.Add("materialModel.model as 材料规格");
            ls.Viewfields.Add("providerInfo.name as 供应商");
            ls.Viewfields.Add("voitureInfo.no as 车辆号码");
            ls.Viewfields.Add("transportUnit.name as 运输单位");
            ls.Viewfields.Add("stockNote.grossWeight as 毛重");
            ls.Viewfields.Add("stockNote.tare as 皮重");
            ls.Viewfields.Add("stockNote.suttle as 净重");
            ls.Viewfields.Add("indent.unitPrice  as 入库单价");
            ls.Viewfields.Add("(stockNote.suttle * indent.unitPrice)  as 入库金额");
            ls.Viewfields.Add("personnelInfo.name as 检斤员 ");
            ls.Viewfields.Add("case stockNote.computationMark when 0 then '手动录入' else '自动采集' end as 采集状态");
            ls.Viewfields.Add("stockNote.assessor as 审核");   
            ls.Viewfields.Add("stockNote.checkupMan as 审批");
            
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
            return dataTable = ls.LeftLinkOpen().Tables[0];
        }

        /*
        * 方法名称：MaterialOutSearch()
        * 方法功能描述：材料出库统计查询方法
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
     
            string lSearchStr = "SELECT mod.Id as 流水号, mod.inputDate AS 日期";
            lSearchStr = lSearchStr + ", mk.sort AS 材料种类, mn.name AS 材料名称, mm.model AS 材料规格";
            lSearchStr = lSearchStr + ", pk.sort AS 产品种类, pn.name AS 产品名称,pm.model AS 产品规格";
            lSearchStr = lSearchStr + ", ei.no AS 设备编号, en.name AS 设备名称";
            lSearchStr = lSearchStr + ", mod.number as 出库数量,mod.unitPrice as 出库单价";
            lSearchStr = lSearchStr + ",(mod.number*mod.unitPrice )as 出库金额 ";
            lSearchStr = lSearchStr + ",case mod.computationMark when 0 then '手动录入' else '自动采集' end as 采集状态 ";
            lSearchStr = lSearchStr + ",mod.assessor as 审核 ";
            lSearchStr = lSearchStr + ",mod.checkupMan as 审批 ";
            lSearchStr = lSearchStr + " FROM materialOutDepot mod INNER JOIN ";
            lSearchStr = lSearchStr + " equipmentInformation AS ei ON mod.eiId = ei.id INNER JOIN ";
            lSearchStr = lSearchStr + " equipmentName AS en ON ei.enId = en.id INNER JOIN ";
            lSearchStr = lSearchStr + " product AS p ON mod.pId = p.id INNER JOIN ";
            lSearchStr = lSearchStr + " productName AS pn ON p.pnId = pn.id INNER JOIN ";
            lSearchStr = lSearchStr + " productKind AS pk ON pn.pkId = pk.id INNER JOIN ";
            lSearchStr = lSearchStr + " productModel AS pm ON p.pmId = pm.id INNER JOIN ";
            lSearchStr = lSearchStr + " material AS m ON mod.mId = m.id INNER JOIN ";
            lSearchStr = lSearchStr + " materialName AS mn ON m.mnId = mn.id INNER JOIN ";
            lSearchStr = lSearchStr + " materialKind AS mk ON mn.mkId = mk.id INNER JOIN ";
            lSearchStr = lSearchStr + " materialModel AS mm ON m.mmId = mm.id";
            
            if (!sqlWhere.Equals(""))
            {
                lSearchStr = lSearchStr + " Where 1=1" + sqlWhere;
            }
            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }

        /*
        * 方法名称：SearchEquipmentNO()
        * 方法功能描述：查询所有设备的编号
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchEquipmentNO()
        {
            string lSearchStr;

            lSearchStr = "SELECT id ,no FROM equipmentInformation";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }

        /*
        * 方法名称：GetMaterialSQL()
        * 方法功能描述：生成按用户输入条件查询SQL语句
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string GetMaterialSQL(StockMOutRClass stockMOut, int mkId, int mnId)
        {
            string sqlWhere;
            sqlWhere = "";

            if ((stockMOut.BeginTime != null) && (!stockMOut.BeginTime.Equals("")))
            {
                sqlWhere = sqlWhere + " and mod.inputDate>= '" + stockMOut.BeginTime + " 00:00:00'";
            }
            if ((stockMOut.EndTime != null) && (!stockMOut.EndTime.Equals("")))
            {
                sqlWhere = sqlWhere + " and mod.inputDate<= '" + stockMOut.EndTime + " 23:59:59'";
            }
            if (!stockMOut.Mid.Equals(0))
            {
                sqlWhere = sqlWhere + " and m.id = " + stockMOut.Mid;
            }
            if (!stockMOut.Equipmentid.Equals(0))
            {
                sqlWhere = sqlWhere + " and ei.id = " + stockMOut.Equipmentid;
            }
            if (!string.IsNullOrEmpty(stockMOut.State))
            {
                switch (stockMOut.State)
                {
                    case "已审核":
                        {
                            sqlWhere = sqlWhere + " and mod.assessor is not NULL ";
                            break;
                        }
                    case "已审批":
                        {
                            sqlWhere = sqlWhere + " and mod.checkupMan is not NULL ";
                            break;
                        }
                    case "未审核、审批":
                        {
                            sqlWhere = sqlWhere + " and mod.assessor is NULL and mod.checkupMan is NULL ";
                            break;
                        }
                }

            }
            if ((mkId != 0) && (stockMOut.Mid == 0))
            {
                sqlWhere = sqlWhere + " and mk.id = " + mkId;
            }
            if ((mnId != 0) && (stockMOut.Mid == 0))
            {
                sqlWhere = sqlWhere + " and mn.id = " + mnId;
            }

            return sqlWhere;
        }

        /*
        * 方法名称：providerSearch()
        * 方法功能描述：入库供应商查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable providerSearch()
        {
            string lSearchStr;

            lSearchStr = "SELECT id ,name FROM providerInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }

        /*
        * 方法名称：Material_Assess()
        * 方法功能描述：材料台账审核方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Material_Assess(string state, long id, string assessor)
        {
            storageDB sDB = new storageDB();
            if (state.Equals("I"))
            {
                return sDB.Update_Assess("stockNote", id, assessor);
            }
            else
            {
                return sDB.Update_Assess("materialOutDepot", id, assessor);
            }
        }

        /*
        * 方法名称：Material_Checkup()
        * 方法功能描述：材料台账审批方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Material_Checkup(string state, long id, string checkup)
        {
            storageDB sDB = new storageDB();
            if (state.Equals("I"))
            {
                return sDB.Update_Checkup("stockNote", id, checkup);
            }
            else
            {
                return sDB.Update_Checkup("materialOutDepot", id, checkup);
            }
        }

    }
    #endregion

    #region 产品台帐数据层方法

    /*
     * 类名称：StockOutRDB
     * 类功能描述：产品台帐数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-11
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class StockOutRDB
    {
        SqlHelper sqlHelper = new SqlHelper();
        /*
        * 方法名称：ProudctINSearch()
        * 方法功能描述： 产品入库统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-13
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable ProudctOutSearch(StockOutRClass stockORClass, int pkId, int pnId)
        {
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("consignmentNote.id as 流水号");
            ls.Viewfields.Add("consignmentNote.inputDate as 日期");
            ls.Viewfields.Add("productKind.sort as 产品种类");
            ls.Viewfields.Add("productName.name as 产品名称");
            ls.Viewfields.Add("productModel.model as 产品规格");
            ls.Viewfields.Add("clientInfo.name as 客户");
            ls.Viewfields.Add("voitureInfo.no as 车辆号码");
            ls.Viewfields.Add("transportUnit.name as 运输单位");
            ls.Viewfields.Add("consignmentNote.grossWeight as 毛重");
            ls.Viewfields.Add("consignmentNote.tare as 皮重");
            ls.Viewfields.Add("consignmentNote.suttle as 净重");
            ls.Viewfields.Add("invoice.unitPrice as 销售单价");
            ls.Viewfields.Add("consignmentNote.suttle * invoice.unitPrice as 销售金额");
            ls.Viewfields.Add("personnelInfo.name as 检斤员 ");
            ls.Viewfields.Add("case consignmentNote.computationMark when 0 then '手动录入' else '自动采集' end as 采集状态");
            ls.Viewfields.Add("consignmentNote.assessor as 审核");
            ls.Viewfields.Add("consignmentNote.checkupMan as 审批");
            
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

            if ((pkId != 0) &&  (stockORClass.Pid == 0))
            {
                ls.Conds.Add("productKind.id = " + pkId);
            }

            if ((pnId != 0)&&  (stockORClass.Pid == 0))
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

            return dataTable = ls.LeftLinkOpen().Tables[0];
        }

        /*
        * 方法名称：ProudctOutSearch()
        * 方法功能描述：产品入库统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable ProudctInSearch(string sqlWhere)
        {
           
            string lSearchStr;

            lSearchStr = "select pp.id as 流水号,pp.inputDate as 日期";
            lSearchStr = lSearchStr + ", pk.sort AS 产品种类, pn.name AS 产品名称, pm.model AS 产品规格";
            lSearchStr = lSearchStr + ", ei.no AS 设备编号, en.name AS 设备名称,pp.number as 入库数量";
            lSearchStr = lSearchStr + ",pp.unitPrice as 入库单价,(pp.number*pp.unitPrice )as 入库金额";
            lSearchStr = lSearchStr + ",case pp.computationMark when 0 then '手动录入' else '自动采集' end as 采集状态 ";
            lSearchStr = lSearchStr + ", pp.assessor as 审核 ";
            lSearchStr = lSearchStr + ", pp.checkupMan as 审批 ";
            lSearchStr = lSearchStr + " FROM productInDepot pp INNER JOIN  equipmentInformation AS ei ON ";
            lSearchStr = lSearchStr + " pp.eiId = ei.id INNER JOIN  equipmentName AS en ON ei.enId = en.id INNER JOIN  product AS p ON ";
            lSearchStr = lSearchStr + " pp.pId = p.id INNER JOIN  productName AS pn ON  p.pnId = pn.id INNER JOIN  productKind AS pk ON ";
            lSearchStr = lSearchStr + " pn.pkId = pk.id INNER JOIN  productModel AS pm ON p.pmId = pm.id ";
            lSearchStr = lSearchStr + " Where 1=1";

            
            if (!sqlWhere.Equals(""))
            {
                lSearchStr = lSearchStr + sqlWhere;
            }

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr}).Tables[0];
        }

        /*
        * 方法名称：GetMaterialSQL()
        * 方法功能描述：生成按用户输入条件查询SQL语句
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string GetProudctSQL(StockPInRClass stockPIclass, int pkId, int pnId)
        {
            string sqlWhere;
            sqlWhere = "";

            if ((stockPIclass.BeginTime != null) && (!stockPIclass.BeginTime.Equals("")))
            {
                sqlWhere = " and pp.inputDate>=" + "'" + stockPIclass.BeginTime + "'";
            }
            if ((stockPIclass.EndTime != null) && (!stockPIclass.EndTime.Equals("")))
            {
                sqlWhere = sqlWhere + " and mppp.inputDate<=" + "'" + stockPIclass.EndTime + "'";
            }
            if (!stockPIclass.Equipmentid.Equals(0))
            {
                sqlWhere = sqlWhere + " and ei.id = " + stockPIclass.Equipmentid;
            }
            if (!string.IsNullOrEmpty(stockPIclass.State))
            {
                switch (stockPIclass.State)
                {
                    case "已审核":
                        {
                            sqlWhere = sqlWhere + " and pp.assessor is not NULL ";
                            break;
                        }
                    case "已审批":
                        {
                            sqlWhere = sqlWhere + " and pp.checkupMan is not NULL ";
                            break;
                        }
                    case "未审核、审批":
                        {
                            sqlWhere = sqlWhere + " and pp.assessor is NULL and pp.checkupMan is NULL ";
                            break;
                        }
                }

            }
            if (!stockPIclass.Pid.Equals(0))
            {
                sqlWhere = sqlWhere + " and p.id = " + stockPIclass.Pid;
            }
            if ((pkId != 0) && (stockPIclass.Pid ==0))
            {
                sqlWhere = sqlWhere + " and pk.id =" + pkId;
            }
            if ((pnId != 0) && (stockPIclass.Pid ==0))
            {
                sqlWhere = sqlWhere + " and pn.id =" + pnId;
            }
            return sqlWhere;
        }

        /*
        * 方法名称：SearchClient()
        * 方法功能描述：查询所有客户名称
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchClient()
        {
            string lSearchStr;

            lSearchStr = "SELECT id ,name FROM clientInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }

        /*
        * 方法名称：Proudct_Assess()
        * 方法功能描述：产品台账审核方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Proudct_Assess(string state, long id, string assessor)
        {
            storageDB sDB = new storageDB();
            if (state.Equals("I"))
            {
                return sDB.Update_Assess("productInDepot", id, assessor);
            }
            else
            {
                return sDB.Update_Assess("consignmentNote", id, assessor);
            }
        }

        /*
        * 方法名称：Proudct_Checkup()
        * 方法功能描述：产品台账审批方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Proudct_Checkup(string state, long id, string checkup)
        {
            storageDB sDB = new storageDB();
            if (state.Equals("I"))
            {
                return sDB.Update_Checkup("productInDepot", id, checkup);
            }
            else
            {
                return sDB.Update_Checkup("consignmentNote", id, checkup);
            }
        }
    }
    #endregion

    #region 库存统计窗体数据层方法

    /*
     * 类名称：StockStatDB
     * 类功能描述：库存统计窗体数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-16
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class StockStatDB
    {
        SqlHelper sqlHelper = new SqlHelper();

        /*
        * 方法名称：InStat()
        * 方法功能描述：材料库统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable InStat()
        {
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("materialStockList.id ");
            ls.Viewfields.Add("materialKind.sort as 材料种类");
            ls.Viewfields.Add("materialName.name as 材料名称");
            ls.Viewfields.Add("materialModel.model as 材料规格");
            ls.Viewfields.Add("material.nadirStock as 最低库存量");
            ls.Viewfields.Add("materialStockList.inputStock as 入库量");
            ls.Viewfields.Add("materialStockList.outputStock as 出库量");
            ls.Viewfields.Add("materialStockList.quantity1 as 库存量");

            ls.TableNames.Add("materialStockList");
            ls.TableNames.Add("material");
            ls.LinkConds.Add("materialStockList.mId = material.id");

            ls.TableNames.Add("materialModel");
            ls.LinkConds.Add("material.mmId = materialModel.id");

            ls.TableNames.Add("materialName");
            ls.LinkConds.Add("material.mnId = materialName.id");
            ls.TableNames.Add("materialKind");
            ls.LinkConds.Add("materialName.mKId = materialKind.id");
            
            return dataTable = ls.LeftLinkOpen().Tables[0];
        }

        /*
        * 方法名称：OutStat()
        * 方法功能描述：产品库统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable OutStat()
        {
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;
         
            ls.Viewfields.Add("productStockList.id ");
            ls.Viewfields.Add("productKind.sort as 产品种类");
            ls.Viewfields.Add("productName.name as 产品名称");
            ls.Viewfields.Add("productModel.model as 产品规格");
            ls.Viewfields.Add("product.nadirStock as 最低库存量");
            ls.Viewfields.Add("productStockList.inputStock as 入库量");
            ls.Viewfields.Add("productStockList.outputStock as 出库量");
            ls.Viewfields.Add("productStockList.suttle1 as 库存量");

            ls.TableNames.Add("productStockList");
            ls.TableNames.Add("product");
            ls.LinkConds.Add("productStockList.pId = product.id");

            ls.TableNames.Add("productModel");
            ls.LinkConds.Add("product.pmId = productModel.id");

            ls.TableNames.Add("productName");
            ls.LinkConds.Add("product.pnId = productName.id");
            ls.TableNames.Add("productKind");
            ls.LinkConds.Add("productName.pkId = productKind.id");

            ls.LinkConds.Add("productStockList.pkId = productKind.id");
   
            return dataTable = ls.LeftLinkOpen().Tables[0];
        }

        /*
        * 方法名称：GetMaxDate()
        * 方法功能描述：材料和产品库存统计时,取出最后存入库存的日期;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-16
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string GetMaxDate(string name)
        {
            string lSearchStr;
            DataTable dataTable = new DataTable();
            string date;

            lSearchStr = "SELECT max(inputDate) FROM " + name ;
            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                date = dataTable.Rows[0][0].ToString().Substring(0,10);
                return name + ".inputDate = '" + date +"'";
            }

        }

        /*
        * 方法名称：Stock_Material()
        * 方法功能描述：材料库存数量和金额计算方法;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-09
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Stock_Material()
        {
            string lSearchStr;
            bool state = true;

            lSearchStr = "Select material.id as 材料ID";
            lSearchStr = lSearchStr + ",(select sum(sn.suttle) from stockNote sn,indent i where sn.iId = i.id and i.mid = material.id and sn.checkupMan is not NULL) as 材料入库总数量";
            lSearchStr = lSearchStr + ",(select sum(mm.number) from materialOutDepot mm where mm.mid = material.id and mm.checkupMan is not NULL) as 材料出库总数量";
            lSearchStr = lSearchStr + ",(select sum(sn.suttle*i.unitPrice) from stockNote sn,indent i  where sn.iId = i.id and i.mid = material.id and sn.checkupMan is not NULL) as 材料入库总金额";
            lSearchStr = lSearchStr + ",(select sum(mm.number*mm.unitPrice) from materialOutDepot mm where mm.mid = material.id and mm.checkupMan is not NULL) as 材料出库总金额";
            lSearchStr = lSearchStr + " From stockNote Left Outer Join indent ON stockNote.iId = indent.id Left Outer Join material ON indent.mId = material.id ";
            lSearchStr = lSearchStr + " Where stockNote.checkupMan is not NULL group by material.id ";
            lSearchStr = lSearchStr + " union ";
            lSearchStr = lSearchStr + " Select m.mid as 材料ID";
            lSearchStr = lSearchStr + ",(select sum(sn.suttle) from stockNote sn,indent i where sn.iId = i.id and i.mid = m.mid and sn.checkupMan is not NULL) as 材料入库总数量";
            lSearchStr = lSearchStr + ",(select sum(mm.number) from materialOutDepot mm where mm.mid = m.mid and mm.checkupMan is not NULL) as 材料出库总数量";
            lSearchStr = lSearchStr + ",(select sum(sn.suttle*i.unitPrice) from stockNote sn,indent i  where sn.iId = i.id and i.mid = m.mid and sn.checkupMan is not NULL) as 材料入库总金额";
            lSearchStr = lSearchStr + ",(select sum(mm.number*mm.unitPrice) from materialOutDepot mm where mm.mid = m.mid and mm.checkupMan is not NULL) as 材料出库总金额";
            lSearchStr = lSearchStr + " From materialOutDepot m  Where m.checkupMan is not NULL  group by m.mid ";

            var table = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            int id = table.Rows.Count;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                long mid = Convert.ToInt64(table.Rows[i][0].ToString());

                #region 取出材料出\入库总数量和金额
                // 材料入库总数量
                decimal in_number = 0;
                if (!(table.Rows[i][1].Equals(null)))
                {
                    decimal.TryParse(table.Rows[i][1].ToString(), out in_number);
                }
                // 材料入库总金额 
                decimal in_money = 0;
                if (!table.Rows[i][3].Equals(null))
                {
                    decimal.TryParse(table.Rows[i][3].ToString(), out in_money);
                }

                // 材料出库总数量 
                decimal out_number = 0;
                if (!(table.Rows[i][2].Equals(null)))
                {
                    decimal.TryParse(table.Rows[i][2].ToString(), out out_number);
                }
                // 材料出库总金额 
                decimal out_money = 0;
                if (!table.Rows[i][4].Equals(null))
                {
                    decimal.TryParse(table.Rows[i][4].ToString(), out out_money);
                }
                #endregion

                if (Search_MStockId(mid))
                {
                    // 该材料在库存中已存在,执行更新库存操作
                    string lUpdateStr = "UPDATE  materialStockList SET  quantity1 =" + (in_number - out_number);
                    lUpdateStr = lUpdateStr + " ,money =" + (in_money + out_money);
                    lUpdateStr = lUpdateStr + " ,inputStock = " + in_number;
                    lUpdateStr = lUpdateStr + " ,outputStock = " + out_number;
                    lUpdateStr = lUpdateStr +" WHERE mId = " + mid;
                    
                    state = sqlHelper.Update(new ArrayList() { lUpdateStr });   
                }
                else
                {
                    // 该材料在库存中不存在,执行插入库存操作
                    string lInsertStr = "INSERT INTO materialStockList (mId ,quantity1 ,money) VALUES (";
                    lInsertStr = lInsertStr + mid + ","; 
                    if (in_number == 0)
                    {
                        lInsertStr = lInsertStr + (0 - out_number) + "," + (0 - out_money) + ")";
                    }
                    else
                    {
                        lInsertStr = lInsertStr + in_number + "," + in_money + ")";
                    }

                    state = sqlHelper.Insert(new ArrayList() { lInsertStr });
                }
            }
                return state;
        }

        /*
        * 方法名称：Search_MStockId()
        * 方法功能描述：查询要更新材料库存的ID是否存在;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-09
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Search_MStockId(long mId)
        {
            string lSearchStr = "select * from materialStockList where mId = " + mId;
            var table = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
            if (table.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
        * 方法名称：Stock_Product()
        * 方法功能描述：产品库存数量和金额计算方法;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-09
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Stock_Product()
        {
            string lSearchStr;
            bool state = true;


            lSearchStr = "Select p.pid as 产品ID";
            lSearchStr = lSearchStr + ",(select sum(pp.number) from productInDepot pp where pp.pid = p.pid and pp.checkupMan is not NULL) as 产品入库总数量";
            lSearchStr = lSearchStr + ",(select sum(cn.suttle) from consignmentNote cn,invoice i where cn.iId = i.id and i.pid = p.pid and cn.checkupMan is not NULL)as 产品出库总数量";
            lSearchStr = lSearchStr + ",(select sum(pp.number * pp.unitPrice) from productInDepot pp where pp.pid = p.pid and pp.checkupMan is not NULL) as 产品入库总金额  ";
            lSearchStr = lSearchStr + ",(select sum(cn.suttle * i.unitPrice)from consignmentNote cn,invoice i where cn.iId = i.id and i.pid = p.pid and cn.checkupMan is not NULL)as 产品出库总金额 ";
            lSearchStr = lSearchStr + " From productInDepot p Where p.checkupMan is not NULL group by p.pid";
            lSearchStr = lSearchStr + " union ";
            lSearchStr = lSearchStr + " Select product.id as 产品ID";
            lSearchStr = lSearchStr + ",(select sum(pp.number) from productInDepot pp where pp.pid = product.id and pp.checkupMan is not NULL) as 产品入库总数量";
            lSearchStr = lSearchStr + ",(select sum(cn.suttle) from consignmentNote cn,invoice i where cn.iId = i.id and i.pid = product.id and cn.checkupMan is not NULL)as 产品出库总数量";
            lSearchStr = lSearchStr + ",(select sum(pp.number * pp.unitPrice) from productInDepot pp where pp.pid = product.id and pp.checkupMan is not NULL) as 产品入库总金额";
            lSearchStr = lSearchStr + ",(select sum(cn.suttle * i.unitPrice)from consignmentNote cn,invoice i where cn.iId = i.id and i.pid = product.id and cn.checkupMan is not NULL)as 产品出库总金额";
            lSearchStr = lSearchStr + " From consignmentNote Left Outer Join invoice ON consignmentNote.iId = invoice.id Left Outer Join product ON invoice.pId = product.id ";
            lSearchStr = lSearchStr + " Where consignmentNote.checkupMan is not NULL group by product.id";

            var table = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            int id = table.Rows.Count;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                long pid = Convert.ToInt64(table.Rows[i][0].ToString());

                #region 取出产品出\入库总数量和金额
                // 产品入库总数量
                decimal in_number = 0;
                if ( ! (table.Rows[i][1].Equals(null)))
                {
                    decimal.TryParse(table.Rows[i][1].ToString(), out in_number);
                }
                // 产品入库总金额 
                decimal in_money = 0;
                if (!table.Rows[i][3].Equals(null))
                {
                    decimal.TryParse(table.Rows[i][3].ToString(), out in_money);
                }

                // 产品出库总数量 
                decimal out_number = 0;
                if (!(table.Rows[i][2].Equals(null)))
                {
                    decimal.TryParse(table.Rows[i][2].ToString(), out out_number);
                }
                // 产品出库总金额 
                decimal out_money = 0;
                if (!table.Rows[i][4].Equals(null))
                {
                    decimal.TryParse(table.Rows[i][4].ToString(), out out_money);
                }
                #endregion

                if (Search_PStockId(pid))
                {
                    // 该产品在库存中已存在,执行更新库存操作
                    string lUpdateStr = "UPDATE  productStockList SET suttle1 =" + (in_number - out_number);
                    lUpdateStr = lUpdateStr + " ,money =" + (in_money + out_money);
                    lUpdateStr = lUpdateStr + " ,inputStock = " + in_number;
                    lUpdateStr = lUpdateStr + " ,outputStock = " + out_number;
                    lUpdateStr = lUpdateStr + " WHERE pId = " + pid;

                    state = sqlHelper.Update(new ArrayList() { lUpdateStr });
                }
                else
                {
                    // 该产品在库存中不存在,执行插入库存操作
                    string lInsertStr = "INSERT INTO productStockList (pId ,suttle1 ,money) VALUES (";
                    lInsertStr = lInsertStr + pid + ",";
                    if (in_number == 0)
                    {
                        lInsertStr = lInsertStr + (0 - out_number) + "," + (0 - out_money) + ")";
                    }
                    else
                    {
                        lInsertStr = lInsertStr + in_number + "," + in_money + ")";
                    }
                    
                    state = sqlHelper.Insert(new ArrayList() { lInsertStr });
                }
            }
            return state;
        }

        /*
        * 方法名称：Search_PStockId()
        * 方法功能描述：查询要更新产品库存的ID是否存在;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-09
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool Search_PStockId(long pId)
        {
            string lSearchStr = "select * from productStockList where pId = " + pId;
            var table = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
            if (table.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    #endregion

    #region 库存盘点收休正数据层方法
    /*
     * 类名称：StockCheckRDB
     * 类功能描述：库存盘点收休正数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-11
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class StockCheckRDB
    {
        SqlHelper sqlHelper = new SqlHelper();
        StockStatDB sStatDB = new StockStatDB();
       
        // 盘点时材料库存表中，材料种类、名称、规格联动
        /*
        * 方法名称：SearchPMKind()()
        * 方法功能描述：查询材料库存统计表中所有材料的种类
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPMKind()
        {
            string lSearchStr;

            lSearchStr = " SELECT DISTINCT materialKind.id, materialKind.sort";
            lSearchStr = lSearchStr + " FROM materialStockList INNER JOIN ";
            lSearchStr = lSearchStr + " material ON materialStockList.mId = material.id INNER JOIN";
            lSearchStr = lSearchStr + " materialName ON material.mnId = materialName.id INNER JOIN";
            lSearchStr = lSearchStr + " materialKind ON materialName.mkId = materialKind.id";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
        * 方法名称：SearchPName()
        * 方法功能描述：根据库存统计表中的材料种类查询该种类下的所有材料厂名称
        *
        * 创建人：冯雪
        * 创建时间：2009-03-19
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPMName(long pkId)
        {
            string lSearchStr;

            lSearchStr = " SELECT DISTINCT materialName.id, materialName.name ";
            lSearchStr = lSearchStr + " FROM materialStockList INNER JOIN  material ON ";
            lSearchStr = lSearchStr + " materialStockList.mId = material.id INNER JOIN materialName ON ";
            lSearchStr = lSearchStr + " material.mnId = materialName.id ";
            lSearchStr = lSearchStr + " where materialName.mkId = " + pkId;

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
        * 方法名称：SearchPMModel()
        * 方法功能描述：根据库存统计表中的材料种类查询该种类下的所有材料规格
        *
        * 创建人：冯雪
        * 创建时间：2009-03-19
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPMModel(long pkId)
        {
            string lSearchStr;

            lSearchStr = " SELECT DISTINCT materialModel.id, materialModel.model  ";
            lSearchStr = lSearchStr + " FROM materialStockList INNER JOIN  material ON";
            lSearchStr = lSearchStr + " materialStockList.mId = material.id INNER JOIN materialModel ON ";
            lSearchStr = lSearchStr + " material.mmId = materialModel.id INNER JOIN materialName ON ";
            lSearchStr = lSearchStr + " material.mnId = materialName.id  ";
            lSearchStr = lSearchStr + " where materialName.mkId = " + pkId;

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        
        // 盘点时产品库存表中，产品种类、名称、规格联动
        /*
        * 方法名称：SearchPPKind()
        * 方法功能描述：查询产品库存统计表中所有产品的种类
        *
        * 创建人：冯雪
        * 创建时间：2009-03-12
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPPKind()
        {
            string lSearchStr;

            lSearchStr = " SELECT DISTINCT productKind.id, productKind.sort";
            lSearchStr = lSearchStr + " FROM productStockList INNER JOIN ";
            lSearchStr = lSearchStr + " product ON productStockList.pId = product.id INNER JOIN";
            lSearchStr = lSearchStr + " productName ON product.pnId = productName.id INNER JOIN";
            lSearchStr = lSearchStr + " productKind ON productName.pkId = productKind.id";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
        * 方法名称：SearchPPName()
        * 方法功能描述：根据库存统计表中的产品种类查询该种类下的所有产品厂名称
        *
        * 创建人：冯雪
        * 创建时间：2009-03-19
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPPName(long mkId)
        {
            string lSearchStr;

            lSearchStr = " SELECT DISTINCT productName.id, productName.name  ";
            lSearchStr = lSearchStr + " FROM productStockList INNER JOIN  product ON  ";
            lSearchStr = lSearchStr + " productStockList.pId = product.id INNER JOIN productName ON  ";
            lSearchStr = lSearchStr + " product.pnId = productName.id  ";
            lSearchStr = lSearchStr + " where productName.pkId = " + mkId;

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
        * 方法名称：SearchPPModel()
        * 方法功能描述：根据库存统计表中的产品种类查询该种类下的所有产品规格
        *
        * 创建人：冯雪
        * 创建时间：2009-03-19
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPPModel(long mkId)
        {
            string lSearchStr;

            lSearchStr = " SELECT DISTINCT productModel.id, productModel.model  ";
            lSearchStr = lSearchStr + " FROM productStockList INNER JOIN  product ON   ";
            lSearchStr = lSearchStr + " productStockList.pId = product.id INNER JOIN productModel ON ";
            lSearchStr = lSearchStr + " product.pmId = productModel.id INNER JOIN productName ON  ";
            lSearchStr = lSearchStr + " product.pnId = productName.id ";
            lSearchStr = lSearchStr + " where productName.pkId =" + mkId;

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }

        // 盘点时在材料库存表、产品库存表中，取出该材料、产品库存量
        /*
        * 方法名称：SearchPMQuantity()
        * 方法功能描述：在材料库存表中，取出该材料帐面库存量
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPMQuantity(long mId)
        {
            string lSearchStr;

            lSearchStr = "select mid,quantity1,id from materialStockList where mid = " + mId ;

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
        * 方法名称：SearchPPQuantity()
        * 方法功能描述：在产品库存表中，取出该产品帐面库存量
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchPPSuttle(long PId)
        {
            string lSearchStr;

            lSearchStr = "select pid,suttle1,id from productStockList where pid =  " + PId;

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }

        // 盘点材料、产品库存，向原料、产品库存修正表中插入盘点过后的数据
        /*
        * 方法名称：InsertPMaterial()
        * 方法功能描述：盘点材料库存，向原料库存修正表中插入盘点过后的数据
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertPMaterial(CheckStockClass checkstockClass)
        {
            string lInsertStr;

            lInsertStr = "INSERT INTO materialStockAmend (mslId,checkStock ,balance ";
            lInsertStr = lInsertStr + ",inputDate,inputMan,remark) VALUES(";
            lInsertStr = lInsertStr + checkstockClass.MslId + "," + checkstockClass.CheckStock + ","  ;
            lInsertStr = lInsertStr + checkstockClass.Balance + ",getdate(),'";
            lInsertStr = lInsertStr + checkstockClass.InputMan + "','" + checkstockClass.Remark + "')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr } );
        }
        /*
        * 方法名称：InsertPProduct()
        * 方法功能描述：盘点产品库存，向产品库存修正表中插入盘点过后的数据
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertPProduct(CheckStockClass checkstockClass)
        {
            string lInsertStr;

            lInsertStr = "INSERT INTO productStockAmend (pslId ,checkStock ,balance ";
            lInsertStr = lInsertStr + ",inputDate ,inputMan,remark ) VALUES (";
            lInsertStr = lInsertStr + checkstockClass.PslId + "," + checkstockClass.CheckStock + ",";
            lInsertStr = lInsertStr + checkstockClass.Balance + ",getdate(),'";
            lInsertStr = lInsertStr + checkstockClass.InputMan + "','" + checkstockClass.Remark + "')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
        }

        //查询盘点过的材料、产品库存信息；
        /*
        * 方法名称：SearchCheckM()
        * 方法功能描述：查询盘点过的材料库存信息
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchCheckM()
        {
            string lSearchStr;

            lSearchStr = "SELECT msa.id, msl.id as 库存ID, msl.mId,msa.inputDate as 盘点日期";
            lSearchStr = lSearchStr + ", mk.sort AS 材料种类, mn.name AS 材料名称, mm.model As 材料规格";
            lSearchStr = lSearchStr + ", msl.quantity1 AS 库存数量, msa.checkStock AS 盘点数量";
            lSearchStr = lSearchStr + ",msa.balance AS 差异值, msa.remark AS 备注 ";
            lSearchStr = lSearchStr + " FROM materialStockList AS msl INNER JOIN";
            lSearchStr = lSearchStr + " materialStockAmend AS msa ON msl.id = msa.mslId INNER JOIN";
            lSearchStr = lSearchStr + " material AS m ON msl.mId = m.id INNER JOIN";
            lSearchStr = lSearchStr + " materialModel AS mm ON m.mmId = mm.id INNER JOIN";
            lSearchStr = lSearchStr + " materialName AS mn ON m.mnId = mn.id INNER JOIN";
            lSearchStr = lSearchStr + " materialKind AS mk ON mn.mkId = mk.id";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
        * 方法名称：SearchCheckP()
        * 方法功能描述：查询盘点过的产品库存信息
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchCheckP()
        {
            string lSearchStr;

            lSearchStr = "SELECT psa.id, psl.id as 库存ID, psl.pId,psa.inputDate as 盘点日期";
            lSearchStr = lSearchStr + ", pk.sort AS 产品种类, pn.name AS 产品名称, pm.model As 产品规格";
            lSearchStr = lSearchStr + ", psl.suttle1 AS 库存数量, psa.checkStock AS 盘点数量";
            lSearchStr = lSearchStr + ",psa.balance AS 差异值 , psa.remark AS 备注 ";
            lSearchStr = lSearchStr + " FROM productStockList AS psl INNER JOIN ";
            lSearchStr = lSearchStr + " productStockAmend AS psa ON psl.id = psa.pslId INNER JOIN ";
            lSearchStr = lSearchStr + " product AS p ON psl.pId = p.id INNER JOIN ";
            lSearchStr = lSearchStr + " productModel AS pm ON p.pmId = pm.id INNER JOIN ";
            lSearchStr = lSearchStr + " productName AS pn ON p.pnId = pn.id INNER JOIN";
            lSearchStr = lSearchStr + " productKind AS pk ON pn.pkId = pk.id";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
    }

    #endregion

    #region 产品入库数据层方法
    /*
     * 类名称：ProductInDepotDB
     * 类功能描述：产品入库数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-11
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class ProductInDepotDB
    {
        SqlHelper sqlHelper = new SqlHelper();

        /*
        * 方法名称：SearchplanPrice()
        * 方法功能描述：查询该产品的计划单价
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */ 
        public string SearchplanPrice(long pId)
        {
            string lSearchStr = "SELECT planPrice FROM  product WHERE id = " + pId;

            var table = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (table.Rows.Count != 0)
            {
                return table.Rows[0][0].ToString();
            }
            else
            {
                return "0";
            }
        }

        /*
        * 方法名称：InsertProductInDepot()
        * 方法功能描述：插入产品入库信息
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertProductInDepot(ProductInDepotClass pInDepot)
        {
            string lInsertStr = "INSERT INTO productInDepot(pId,number,unitPrice,eiId,inputMan";
            lInsertStr = lInsertStr + ",inputDate,computationMark)VALUES(";
            lInsertStr = lInsertStr + pInDepot.Pid + "," + pInDepot.Number + ",";
            lInsertStr = lInsertStr + pInDepot.UnitPrice + "," + pInDepot.EiId + ",'";
            lInsertStr = lInsertStr + pInDepot.InputMan + "',getdate(),'";
            lInsertStr = lInsertStr + pInDepot.ComputationMark  + "')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
        }

        /*
        * 方法名称：InsertPInDepot_SQL()
        * 方法功能描述：生成产品入库信息的SQL
        *
        * 创建人：冯雪
        * 创建时间：2009-04-15
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        //public string InsertPInDepot_SQL(long id, ProducePlan.pType type)
        //{
        //    // 材料出库,按quantity2算,,如其无值按quantity1算,
        //    long pid = 0;
        //    long eiId = 0 ;
        //    decimal unitPrice = 0;
        //    decimal number = 0;

        //    #region 取出产品入库的Pid,eiId,quantity;
        //    string lSearchStr = "select pId2,quantity1,quantity2,quantity3,eiId ";
        //    switch (type)
        //    {
        //        case ProducePlan.pType.EmulsificationAsphaltum:
        //            {
        //                // 乳化沥青
        //                lSearchStr = lSearchStr + " from mixtureProduceLog";
        //                break;
        //            }
        //        case ProducePlan.pType.RestructureAsphaltum:
        //            {
        //                // 改性沥青
        //                break;
        //            }
        //        default:
        //            {
        //                // 混合料
        //                lSearchStr = "select pId,eiId,quantity1,quantity2,quantity3 from mixtureProduceLog";
        //                break;
        //            }
        //    }
        //    lSearchStr = lSearchStr + " Where id = " + id;

        //    var table = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

        //    if (table.Rows.Count != 0)
        //    {
        //        pid = Convert.ToInt64(table.Rows[0][0].ToString());
        //        eiId = Convert.ToInt64(table.Rows[0][1].ToString());
        //        unitPrice = decimal.Parse(SearchplanPrice(pid));
        //        number = 0;

        //        if ((string.IsNullOrEmpty(table.Rows[0][4].ToString())) || (!(table.Rows[0][4].Equals("0"))))
        //        {
        //            decimal.TryParse(table.Rows[0][4].ToString(), out number);
        //        }

        //        if ((string.IsNullOrEmpty(table.Rows[0][3].ToString())) || (!(table.Rows[0][3].Equals("0"))))
        //        {
        //            decimal.TryParse(table.Rows[0][3].ToString(), out number);
        //        }

        //        else
        //        {
        //            decimal.TryParse(table.Rows[0][2].ToString(), out number);
        //        }

        //    }
        //    else
        //    {
        //         return "";
        //    }
        //    #endregion

        //    // 生成自动产品入库SQL语句;
        //    string lInsertStr = "INSERT INTO productInDepot(pId,number,unitPrice,eiId,inputMan,inputDate";
        //    lInsertStr = lInsertStr + ",computationMark,assessor,checkupMan,assessDate,checkupDate)VALUES(";
        //    lInsertStr = lInsertStr + pid + "," + number + "," + unitPrice + "," + eiId + ",'自动输入'";
        //    lInsertStr = lInsertStr + ",getdate(),'True','自动审核','自动审批',getdate(),getdate())";

        //    return lInsertStr;
        //}
    }
    #endregion

    #region 材料出库数据层方法
    /*
     * 类名称：MaterialOutDepotDB
     * 类功能描述：材料出库数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-04-11
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class MaterialOutDepotDB
    {
        SqlHelper sqlHelper = new SqlHelper();

        /*
        * 方法名称：SearchplanPrice()
        * 方法功能描述：查询该材料的计划单价
        *
        * 创建人：冯雪
        * 创建时间：2009-03-20
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string SearchplanPrice(long mId)
        {
            string lSearchStr = "select (money/quantity1) from materialStockList where mid = " + mId;

            var table = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (table.Rows.Count != 0)
            {
                return table.Rows[0][0].ToString();
            }
            else
            {
                return "0";
            }
        }

        /*
        * 方法名称：InsertMaterialOutDepot()
        * 方法功能描述：插入材料出库信息
        *
        * 创建人：冯雪
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertMaterialOutDepot(MaterialOutDepotClass mOutDepot)
        {
            string lInsertStr = "INSERT INTO  materialOutDepot(mId,number,unitPrice,pid,eiId,inputMan";
            lInsertStr = lInsertStr + ",inputDate,computationMark)VALUES(";
            lInsertStr = lInsertStr + mOutDepot.Mid + "," + mOutDepot.Number + ",";
            lInsertStr = lInsertStr + mOutDepot.UnitPrice + "," + mOutDepot.Pid + ",";
            lInsertStr = lInsertStr + mOutDepot.EiId + ",'" + mOutDepot.InputMan;
            lInsertStr = lInsertStr + "',getdate(),'" + mOutDepot.ComputationMark + "')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
        }

    }
    #endregion

}   
