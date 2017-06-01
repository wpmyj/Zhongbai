using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DasherStation.common;
using System.Data;
using DasherStation.system;
using System.Collections;

namespace DasherStation.metage
{
    /*
     * 类名称：WeighingDBlayer
     * 类功能描述：称重信息数据层基类
     *
     * 创建人：袁宇
     * 创建时间：2009-03-03
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class WeighingDBlayer
    {
        SqlHelper sqlHelperObj = new SqlHelper();
        
        //public DataTable GetOutWeighingReport(string Id)
        //{

        //}

        public DataTable SelectWarehouseInfo()
        {
            ArrayList sqlStr = new ArrayList();
            sqlStr.Add("select * from WarehouseInfo");
            DataTable dt = sqlHelperObj.QueryForDateSet(sqlStr).Tables[0];

            DataTable recDt = new DataTable();
            recDt.Columns.Add("id");
            recDt.Columns.Add("fullName");
            foreach (DataRow row in dt.Rows)
            {
                DataRow r = recDt.NewRow();
                r["id"] = row["id"].ToString();
                r["fullName"] = row["name"].ToString() + "_" + row["no"].ToString();
                recDt.Rows.Add(r);
            }
            return recDt;
        }
        /*
        * 方法名称：SelectTruckInfo
        * 方法功能描述：车辆信息与运输单位信息查询   
        * 参数: truckNo 车牌号码        
        * 返回: DataSet
        * 创建人：袁宇
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectTruckInfo(string truckNo)
        {
            LinkSelect linkS = new LinkSelect();
            DataSet ds = new DataSet();

            linkS.TableNames.Add("voitureInfo");
            linkS.TableNames.Add("transportUnit");
            linkS.LinkConds.Add("voitureInfo.tuId=transportUnit.id");
            linkS.Viewfields.Add("voitureInfo.id"); 
            linkS.Viewfields.Add("voitureInfo.[no]");
            linkS.Viewfields.Add("transportUnit.[name]");
            linkS.Viewfields.Add("voitureInfo.owner");
            linkS.Viewfields.Add("voitureInfo.driverName");
            linkS.Viewfields.Add("voitureInfo.model");
            linkS.Viewfields.Add("voitureInfo.standardTare");
            linkS.Viewfields.Add("voitureInfo.standardDeadWeight");
            if ((truckNo!=null) && (!truckNo.Equals("")))
            {
                linkS.Conds.Add("voitureInfo.[no]=" + "'" + truckNo + "'"); 
            }
            ds = linkS.LeftLinkOpen();
            return ds.Tables[0];
        }
        /*
        * 方法名称：SelectSiteValue
        * 方法功能描述：根据运输合同明细ID 取得止运地与启运地   
        * 参数:        
        * 返回: DataTable 数据
        * 创建人：袁宇
        * 创建时间：2009-03-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectSiteValue(string transportInfo)
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("transportGoodsInformationCorresponding");
            linkS.TableNames.Add("site site1");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.sId1=site1.id");
            linkS.TableNames.Add("site site2");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.sId2=site2.id");
            linkS.Viewfields.Add("site1.site as sname1");
            linkS.Viewfields.Add("site2.site as sname2");
            linkS.Conds.Add("transportGoodsInformationCorresponding.id=" + transportInfo);

            return linkS.LeftLinkOpen().Tables[0];
        }
        /*
       * 方法名称：SelectSite
       * 方法功能描述：取得止运地与启运地   
       * 参数:        
       * 返回: DataTable 数据
       * 创建人：袁宇
       * 创建时间：2009-03-03
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable SelectSite()
        {
            ArrayList sqlList = new ArrayList();
            DataSet ds = new DataSet();

            sqlList.Add("select id,site from site");
            ds = sqlHelperObj.QueryForDateSet(sqlList);
            return ds.Tables[0];
        }
        /*
        * 方法名称：SelectTransportContract
        * 方法功能描述：取得运输合同列表
        * 参数:        
        * 返回: DataTable 数据
        * 创建人：袁宇
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectTransportContract()
        {
            ArrayList sqlList = new ArrayList();
            DataSet ds = new DataSet();

            sqlList.Add("Select id,contractName from transportContract");
            ds = sqlHelperObj.QueryForDateSet(sqlList);
            return ds.Tables[0];
        }
        public DataTable SelectTransportMaterialInfo()
        {
            LinkSelect linkS = new LinkSelect();
            DataSet ds = new DataSet();

            linkS.TableNames.Add("transportGoodsInformationCorresponding");
            linkS.TableNames.Add("transportContract");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.tcId=transportContract.id");
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.mId=material.id");
            linkS.TableNames.Add("materialModel");
            linkS.LinkConds.Add("material.mmId=materialModel.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnId=materialName.id");
            linkS.TableNames.Add("site site1");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.sId1=site1.id");
            linkS.TableNames.Add("site site2");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.sId2=site2.id");

            linkS.Viewfields.Add("transportGoodsInformationCorresponding.id");
            linkS.Viewfields.Add("transportContract.contractName+'|材料:'+materialName.[name]+materialModel.model+'|'+site1.site+'-'+site2.site as contractName");
            linkS.Conds.Add("not (transportContract.contractName is NULL)");
            linkS.Conds.Add("not (materialName.[name] is NULL)");
            linkS.Conds.Add("not (materialModel.model is NULL)");
            linkS.Conds.Add("(not (transportContract.assessor is NULL) and transportContract.assessor!='')");
            linkS.Conds.Add("(not (transportContract.checkupMan is NULL) and transportContract.checkupMan!='')");
            ds = linkS.LeftLinkOpen();
            return ds.Tables[0];
        }
        public DataTable SelectTransportProductInfo()
        {
            LinkSelect linkS = new LinkSelect();
            DataSet ds = new DataSet();

            linkS.TableNames.Add("transportGoodsInformationCorresponding");
            linkS.TableNames.Add("transportContract");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.tcId=transportContract.id");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.pId=product.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("site site1");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.sId1=site1.id");
            linkS.TableNames.Add("site site2");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.sId2=site2.id");

            linkS.Viewfields.Add("transportGoodsInformationCorresponding.id");
            linkS.Viewfields.Add("transportContract.contractName+'|材料:'+productName.[name]+productModel.model+'|'+site1.site+'-'+site2.site as contractName");
            linkS.Conds.Add("not (transportContract.contractName is NULL)");
            linkS.Conds.Add("not (productName.[name] is NULL)");
            linkS.Conds.Add("not (productModel.model is NULL)");
            linkS.Conds.Add("(not (transportContract.assessor is NULL) and transportContract.assessor!='')");
            linkS.Conds.Add("(not (transportContract.checkupMan is NULL) and transportContract.checkupMan!='')");
            ds = linkS.LeftLinkOpen();
            return ds.Tables[0];
        }
        /*
        * 方法名称：SelectMaterialName
        * 方法功能描述：取得材料名称
        * 参数:        
        * 返回: DataTable 数据
        * 创建人：袁宇
        * 创建时间：2009-03-08
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectMaterialName()
        {
            ArrayList sqlList = new ArrayList();
            DataSet ds = new DataSet();

            sqlList.Add("Select id,[name] from materialName");
            ds = sqlHelperObj.QueryForDateSet(sqlList);
            return ds.Tables[0];
        }        
        /*
        * 方法名称：SelectMaterialModel
        * 方法功能描述：取得材料型号
        * 参数:        
        * 返回: DataTable 数据
        * 创建人：袁宇
        * 创建时间：2009-03-08
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectMaterialModel(string name)
        {
            ArrayList sqlList = new ArrayList();
            DataSet ds = new DataSet();
            LinkSelect ls = new LinkSelect();

            ls.TableNames.Add("material");
            ls.TableNames.Add("materialModel");
            ls.LinkConds.Add("material.mmId = materialModel.id");
            ls.TableNames.Add("materialName");
            ls.LinkConds.Add("material.mnId = materialName.id");
            ls.Viewfields.Add("materialModel.model");
            ls.Viewfields.Add("material.id");
            ls.Conds.Add("materialName.name=" + "'" + name + "'");

            ds = ls.LeftLinkOpen();
            return ds.Tables[0];
        }
        /*
        * 方法名称：SelectproductName
        * 方法功能描述：取得产品名称
        * 参数:        
        * 返回: DataTable 数据
        * 创建人：袁宇
        * 创建时间：2009-03-08
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectproductName()
        {
            ArrayList sqlList = new ArrayList();
            DataSet ds = new DataSet();

            sqlList.Add("Select id,[name] from productName");
            ds = sqlHelperObj.QueryForDateSet(sqlList);
            return ds.Tables[0];
        }
        /*
        * 方法名称：SelectproductModel
        * 方法功能描述：取得产品型号
        * 参数:        
        * 返回: DataTable 数据
        * 创建人：袁宇
        * 创建时间：2009-03-08
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectproductModel(string name)
        {
            ArrayList sqlList = new ArrayList();
            DataSet ds = new DataSet();
            LinkSelect ls = new LinkSelect();

            ls.TableNames.Add("product");
            ls.TableNames.Add("productModel");
            ls.LinkConds.Add("product.mmId = productModel.id");
            ls.TableNames.Add("productName");
            ls.LinkConds.Add("product.mnId = productName.id");
            ls.Viewfields.Add("product.id");
            ls.Viewfields.Add("productModel.model");
            ls.Conds.Add("productName.name=" + "'" + name + "'");

            ds = ls.LeftLinkOpen();
            return ds.Tables[0];
        }
    }
    class OutWeighingDBLayer : WeighingDBlayer
    {
        SqlHelper sqlHelperObj = new SqlHelper();
        /*
        * 方法名称：SelectsellContract
        * 方法功能描述：查询销售合同   
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectsellContract()
        {
            ArrayList sqlList = new ArrayList();
            DataSet ds = new DataSet();

            sqlList.Add("select id,[name],[no] from sellContract where finishMark=0");
            sqlList.Add(" and (not(assessor is NULL) and assessor!='')");
            sqlList.Add("  and (not(checkupMan is NULL) and checkupMan!='')");
            //sqlList.Add(" and (not(assessor is NULL) or assessor='')");
            //sqlList.Add(" and (not(checkupMan is NULL) or checkupMan='')");
            ds = sqlHelperObj.QueryForDateSet(sqlList);
            return ds.Tables[0];
        }
        /*
        * 方法名称：SelectInvoice
        * 方法功能描述：取得销售合同明细   
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectInvoice(string scId,string name)
        {
            LinkSelect linkS = new LinkSelect();
            DataSet ds = new DataSet();

            linkS.TableNames.Add("Invoice");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("invoice.pid=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnid=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmid=productModel.id");
            linkS.Viewfields.Add("Invoice.id");
            linkS.Viewfields.Add("productName.[name]+productModel.model as name");
            //linkS.Viewfields.Add("productModel.model");
            if (!scId.Equals(""))
                linkS.Conds.Add("Invoice.scid=" + scId);
            if (!name.Equals(""))
                linkS.Conds.Add("productName.[name]="+""+name+"");
            linkS.Conds.Add("finishMark=0");
            ds = linkS.LeftLinkOpen();
            return ds.Tables[0];
        }
        /*
        * 方法名称：SelectOutWeighInfo
        * 方法功能描述：取得出库未处理完数据   
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectOutWeighInfo(string truckId)
        {
            LinkSelect linkS = new LinkSelect();
            DataSet ds = new DataSet();

            linkS.TableNames.Add("consignmentNote");
            linkS.TableNames.Add("invoice");
            linkS.LinkConds.Add("consignmentNote.iId=invoice.id");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("invoice.pid=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnid=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmid=productModel.id");
            linkS.TableNames.Add("sellContract");
            linkS.LinkConds.Add("invoice.scId=sellContract.id");
            linkS.TableNames.Add("voitureInfo");
            linkS.LinkConds.Add("consignmentNote.viId=voitureInfo.id");
            linkS.TableNames.Add("transportUnit");
            linkS.LinkConds.Add("voitureInfo.tuId=transportUnit.id");
            linkS.TableNames.Add("site site1");
            linkS.LinkConds.Add("consignmentNote.sId1=site1.id");
            linkS.TableNames.Add("site site2");
            linkS.LinkConds.Add("consignmentNote.sId2=site2.id");
            linkS.TableNames.Add("transportGoodsInformationCorresponding");
            linkS.LinkConds.Add("consignmentNote.tgicId=transportGoodsInformationCorresponding.id");
            linkS.TableNames.Add("transportContract");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.tcId=transportContract.id");            
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("consignmentNote.eiId=equipmentInformation.id");
            linkS.TableNames.Add("projectName");
            linkS.LinkConds.Add("consignmentNote.pnId=projectName.id");
            linkS.TableNames.Add("equipmentModel");
            linkS.LinkConds.Add("equipmentInformation.emId=equipmentModel.id");
            linkS.TableNames.Add("equipmentName");
            linkS.LinkConds.Add("equipmentInformation.enId=equipmentName.id");
            linkS.TableNames.Add("personnelInfo as personnelInfo1");
            linkS.LinkConds.Add("consignmentNote.piId1=personnelInfo1.id");
            linkS.TableNames.Add("personnelInfo as personnelInfo2");
            linkS.LinkConds.Add("consignmentNote.piId2=personnelInfo2.id");
            //序号
            linkS.Viewfields.Add("consignmentNote.id");
            //车牌号
            linkS.Viewfields.Add("voitureInfo.[no]");
            //销售合同名称
            linkS.Viewfields.Add("sellContract.[name] as ContractName");
            //材料名称
            linkS.Viewfields.Add("productName.[name] as goodsName");
            //材料型号
            linkS.Viewfields.Add("productModel.model as goodsModel");
            //车辆毛重
            linkS.Viewfields.Add("consignmentNote.grossWeight");
            //车辆皮重
            linkS.Viewfields.Add("consignmentNote.tare");
            //净重
            linkS.Viewfields.Add("consignmentNote.suttle");
            //检斤员姓名
            linkS.Viewfields.Add("personnelInfo1.name as surveyor");
            //复检员姓名
            linkS.Viewfields.Add("personnelInfo2.name as inspector");
            //运输单位
            linkS.Viewfields.Add("transportUnit.[name] as UnitName");
            //起运地
            linkS.Viewfields.Add("site1.site as site1");
            //此运地
            linkS.Viewfields.Add("site2.site as site2");
            //录入时间
            linkS.Viewfields.Add("consignmentNote.inputdate");
            //是否是自动采集
            linkS.Viewfields.Add("consignmentNote.computationMark");
            //审核人
            linkS.Viewfields.Add("consignmentNote.assessor");
            //审批人
            linkS.Viewfields.Add("consignmentNote.checkupMan");
            //小票是否打印过
            linkS.Viewfields.Add("consignmentNote.finishMark");
            //备注信息
            linkS.Viewfields.Add("consignmentNote.remark");
            //运输合同名
            linkS.Viewfields.Add("transportContract.contractName+'|材料:'+productName.[name]+productModel.model+'|'+site1.site+'-'+site2.site as transportinfo");
            //生产设备名称
            linkS.Viewfields.Add("equipmentName.[name] as equipmentName");
            //生产设备型号
            linkS.Viewfields.Add("equipmentModel.Model");
            //工程项目名
            linkS.Viewfields.Add("projectName.name as projectName");
            //施工单位名
            linkS.Viewfields.Add("projectName.position");
            //条码
            linkS.Viewfields.Add("consignmentNote.barCode");
            if ((!truckId.Equals(null)) && (!truckId.Equals("")))
            {
                linkS.Conds.Add("consignmentNote.viId=" + "'" + truckId + "'");
            }
            linkS.Conds.Add("(consignmentNote.suttle is NULL or consignmentNote.suttle=0)");
            ds = linkS.LeftLinkOpen();
            return ds.Tables[0];
        }
        /*
        * 方法名称：SelectOutInfo
        * 方法功能描述：取得出库数据   
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-08
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectOutInfo(FindCondClass conds)
        {
            LinkSelect linkS = new LinkSelect();
            DataSet ds = new DataSet();

            linkS.TableNames.Add("consignmentNote");
            linkS.TableNames.Add("invoice");
            linkS.LinkConds.Add("consignmentNote.iId=invoice.id");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("invoice.pid=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnid=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmid=productModel.id");
            linkS.TableNames.Add("sellContract");
            linkS.LinkConds.Add("invoice.scId=sellContract.id");
            linkS.TableNames.Add("voitureInfo");
            linkS.LinkConds.Add("consignmentNote.viId=voitureInfo.id");
            linkS.TableNames.Add("transportUnit");
            linkS.LinkConds.Add("voitureInfo.tuId=transportUnit.id");
            linkS.TableNames.Add("site site1");
            linkS.LinkConds.Add("consignmentNote.sId1=site1.id");
            linkS.TableNames.Add("site site2");
            linkS.LinkConds.Add("consignmentNote.sId2=site2.id");
            linkS.TableNames.Add("transportGoodsInformationCorresponding");
            linkS.LinkConds.Add("consignmentNote.tgicId=transportGoodsInformationCorresponding.id");
            linkS.TableNames.Add("transportContract");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.tcId=transportContract.id");
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("consignmentNote.eiId=equipmentInformation.id");
            linkS.TableNames.Add("projectName");
            linkS.LinkConds.Add("consignmentNote.pnId=projectName.id");
            linkS.TableNames.Add("equipmentModel");
            linkS.LinkConds.Add("equipmentInformation.emId=equipmentModel.id");
            linkS.TableNames.Add("equipmentName");
            linkS.LinkConds.Add("equipmentInformation.enId=equipmentName.id");
            linkS.TableNames.Add("personnelInfo as personnelInfo1");
            linkS.LinkConds.Add("consignmentNote.piId1=personnelInfo1.id");
            linkS.TableNames.Add("personnelInfo as personnelInfo2");
            linkS.LinkConds.Add("consignmentNote.piId2=personnelInfo2.id");
            //序号
            linkS.Viewfields.Add("consignmentNote.id");
            //车牌号
            linkS.Viewfields.Add("voitureInfo.[no] as 车牌号");
            //销售合同名称
            linkS.Viewfields.Add("sellContract.[name] as 销售合同");
            //材料名称
            linkS.Viewfields.Add("productName.[name] as 材料名称");
            //材料型号
            linkS.Viewfields.Add("productModel.model as 材料型号");
            //车辆毛重
            linkS.Viewfields.Add("consignmentNote.grossWeight as 毛重");
            //车辆皮重
            linkS.Viewfields.Add("consignmentNote.tare as 皮重");
            //净重
            linkS.Viewfields.Add("consignmentNote.suttle as 净重");
            //检斤员姓名
            //linkS.Viewfields.Add("consignmentNote.surveyor as 检斤员");
            //复检员姓名
            //linkS.Viewfields.Add("consignmentNote.inspector as 复检员");
            //检斤员姓名
            linkS.Viewfields.Add("personnelInfo1.name as 检斤员");
            //复检员姓名
            linkS.Viewfields.Add("personnelInfo2.name as 复检员");
            //运输单位
            linkS.Viewfields.Add("transportUnit.[name] as 运输单位");
            //起运地
            linkS.Viewfields.Add("site1.site as 起运地");
            //此运地
            linkS.Viewfields.Add("site2.site as 此运地");
            //录入时间
            linkS.Viewfields.Add("consignmentNote.inputdate as 时间");
            //是否是自动采集
            linkS.Viewfields.Add("consignmentNote.computationMark as 采集方式");
            //审核人
            linkS.Viewfields.Add("consignmentNote.assessor as 审核人");
            //审批人
            linkS.Viewfields.Add("consignmentNote.checkupMan as 审批人");
            //小票是否打印过
            linkS.Viewfields.Add("consignmentNote.finishMark as 票具打印");
            //备注信息
            linkS.Viewfields.Add("consignmentNote.remark as 备注");
            //运输合同名
            linkS.Viewfields.Add("transportContract.contractName as 运输合同");
            //生产设备名称
            linkS.Viewfields.Add("equipmentName.[name] as 生产设备");
            //生产设备型号
            linkS.Viewfields.Add("equipmentModel.Model as 设备型号");
            //工程项目名
            linkS.Viewfields.Add("projectName.name as 工程项目名");
            //施工单位名
            linkS.Viewfields.Add("projectName.position as 施工单位");
            //条码
            linkS.Viewfields.Add("consignmentNote.barCode as 条码");

            linkS.Viewfields.Add("voitureInfo.owner as 车主姓名");
            linkS.Viewfields.Add("voitureInfo.driverName as 司机姓名");
            linkS.Viewfields.Add("voitureInfo.model as 车辆型号");
            linkS.Viewfields.Add("voitureInfo.color as 车辆颜色");
            linkS.Viewfields.Add("voitureInfo.lenth as 货箱长度");
            linkS.Viewfields.Add("voitureInfo.width as 货箱宽度");
            linkS.Viewfields.Add("voitureInfo.height as 货箱高度");
            linkS.Viewfields.Add("transportContract.[no] as 运输合同编号");            
            linkS.Viewfields.Add("transportUnit.corporation as 运输单位法人");
            linkS.Viewfields.Add("transportUnit.principal as 运输负责人");
            linkS.Viewfields.Add("transportUnit.phone as 运输单位电话");
            linkS.Viewfields.Add("transportUnit.Email as 运输单位邮箱");
            linkS.Viewfields.Add("transportUnit.capability as 运输能力");

            if ((conds.Id != null) && (!conds.Id.Equals("")))
            {
                linkS.Conds.Add("consignmentNote.id=" + conds.Id);
            }
            if ((conds.ContractName != null) && (!conds.ContractName.Equals("")))
            {
                linkS.Conds.Add("sellContract.[name]=" + "'" + conds.ContractName + "'");
            }
            if ((conds.GoodsName != null) && (!conds.GoodsName.Equals("")))
            {
                linkS.Conds.Add("productName.[name]=" + "'" + conds.GoodsName + "'");
            }
            if ((conds.GoodsModel != null) && (!conds.GoodsModel.Equals("")))
            {
                linkS.Conds.Add("productModel.model=" + "'" + conds.GoodsModel + "'");
            }            
            if ((conds.InSite != null) && (!conds.InSite.Equals("")))
            {
                linkS.Conds.Add("site1.site=" + "'" + conds.InSite + "'");
            }
            if ((conds.ToSite != null) && (!conds.ToSite.Equals("")))
            {
                linkS.Conds.Add("site2.site=" + "'" + conds.ToSite + "'");
            }
            if ((conds.TransportName != null) && (!conds.TransportName.Equals("")))
            {
                linkS.Conds.Add("transportContract.contractName=" + "'" + conds.TransportName + "'");
            }
            if ((conds.InDate != null) && (!conds.InDate.Equals("")))
            {
                linkS.Conds.Add("consignmentNote.inputdate>=" + "'" + conds.InDate + "'");
            }
            if ((conds.ToDate != null) && (!conds.ToDate.Equals("")))
            {
                linkS.Conds.Add("consignmentNote.inputdate>=" + "'" + conds.ToDate + "'");
            }
            if ((conds.TruckNo != null) && (!conds.TruckNo.Equals("")))
            {
                linkS.Conds.Add("voitureInfo.[no]=" + "'" + conds.TruckNo + "'");
            }
            if (conds.Style != null)
            {
                switch (conds.Style)
                {
                    case "0":
                        linkS.Conds.Add("(stockNote.assessor='' or stockNote.assessor is NULL)");
                        linkS.Conds.Add("(stockNote.checkupMan='' or stockNote.checkupMan is NULL)");
                        break;
                    case "1":
                        linkS.Conds.Add("(stockNote.assessor<>'' and not(stockNote.assessor is NULL))");
                        linkS.Conds.Add("(stockNote.checkupMan='' or stockNote.checkupMan is NULL)");
                        break;
                    case "2":
                        linkS.Conds.Add("(stockNote.assessor<>'' and not(stockNote.assessor is NULL))");
                        linkS.Conds.Add("(stockNote.checkupMan<>'' and not(stockNote.checkupMan is NULL))");
                        break;
                    default:
                        ;
                        break;
                }
            }
            linkS.Conds.Add("( not (consignmentNote.suttle is NULL) and consignmentNote.suttle<>0)");
            ds = linkS.LeftLinkOpen();
            return ds.Tables[0];
        } 
        /*
        * 方法名称：SelectEquipmentInfo
        * 方法功能描述：取得生产设备列表 
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectEquipmentInfo()
        {
            LinkSelect linkS = new LinkSelect();
            DataSet ds = new DataSet();

            linkS.TableNames.Add("equipmentInformation");
            linkS.TableNames.Add("equipmentName");
            linkS.LinkConds.Add("equipmentInformation.enId=equipmentName.id");
            linkS.TableNames.Add("equipmentModel");
            linkS.LinkConds.Add("equipmentInformation.emId=equipmentModel.id");
            linkS.Viewfields.Add("equipmentName.[name] + equipmentModel.Model as names");
            linkS.Viewfields.Add("equipmentInformation.id");
            linkS.Viewfields.Add("equipmentInformation.[no]");
            ds = linkS.LeftLinkOpen();
            return ds.Tables[0];
        }
        /*
        * 方法名称：SelectProvider
        * 方法功能描述：通过采购合同，取得供应商   
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-05
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectClientInfo(string scid)
        {
            LinkSelect linkS = new LinkSelect();
            DataSet ds = new DataSet();

            linkS.TableNames.Add("sellContract");
            linkS.TableNames.Add("clientInfo");
            linkS.LinkConds.Add("sellContract.ciId=clientInfo.id");
            linkS.Viewfields.Add("sellContract.[name] as name1");
            linkS.Viewfields.Add("clientInfo.id");
            linkS.Viewfields.Add("clientInfo.[name] as name2");
            linkS.Conds.Add("sellContract.id="+scid);
            ds = linkS.LeftLinkOpen();
            return ds.Tables[0];
        }
        public long GetMaxInRecId()
        {
            DataSet ds = new DataSet();
            ArrayList sqlText = new ArrayList();
            sqlText.Add("SELECT MAX(id) AS RegID FROM consignmentNote");
            ds = sqlHelperObj.QueryForDateSet(sqlText);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
            }
            else
                return -1;

        }
        /*
        * 方法名称：InsertInfo
        * 方法功能描述：新建入库数据  
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-05
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertInfo(OutWeighingClass info)
        {
            DataVar var = new DataVar();
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            if ((info.IId != null) && (!info.IId.Equals("")))
            {
                fields.Add("iId");
                values.Add(info.IId);
            }
            if ((info.GrossWeight != null) && (!info.GrossWeight.Equals("")))
            {
                fields.Add("grossWeight");
                values.Add(info.GrossWeight);
            }
            if ((info.Tare != null) && (!info.Tare.Equals("")))
            {
                fields.Add("Tare");
                values.Add(info.Tare);
            }

            if ((info.Suttle != null) && (!info.Suttle.Equals("")))
            {
                fields.Add("Suttle");
                values.Add(info.Suttle);
            }
            if ((info.Surveyor != null) && (!info.Surveyor.Equals("")))
            {
                fields.Add("Surveyor");
                values.Add("'" + info.Surveyor + "'");
            }
            if ((info.Inspector != null) && (!info.Inspector.Equals("")))
            {
                fields.Add("Inspector");
                values.Add("'" + info.Inspector + "'");
            }
            if ((info.ViId != null) && (!info.ViId.Equals("")))
            {
                fields.Add("ViId");
                values.Add(info.ViId);
            }
            if ((info.SId1 != null) && (!info.SId1.Equals("")))
            {
                fields.Add("SId1");
                values.Add(info.SId1);
            }
            if ((info.SId2 != null) && (!info.SId2.Equals("")))
            {
                fields.Add("SId2");
                values.Add(info.SId2);
            }
            if ((info.InputDate != null) && (!info.InputDate.Equals("")))
            {
                fields.Add("InputDate");
                values.Add("'"+info.InputDate+"'");
            }
            if ((info.ComputationMark != null) && (!info.ComputationMark.Equals("")))
            {
                fields.Add("ComputationMark");
                values.Add(info.ComputationMark);
            }

            if ((info.CheckAccountMark1 != null) && (!info.CheckAccountMark1.Equals("")))
            {
                fields.Add("CheckAccountMark1");
                values.Add(info.CheckAccountMark1);
            }
            if ((info.CheckAccountMark2 != null) && (!info.CheckAccountMark2.Equals("")))
            {
                fields.Add("CheckAccountMark2");
                values.Add(info.CheckAccountMark2);
            }
            if ((info.Assessor != null) && (!info.Assessor.Equals("")))
            {
                fields.Add("Assessor");
                values.Add("'"+info.Assessor+"'");
            }
            if ((info.CheckupMan != null) && (!info.CheckupMan.Equals("")))
            {
                fields.Add("CheckupMan");
                values.Add("'"+info.CheckupMan+"'");
            }

            if ((info.FinishMark != null) && (!info.FinishMark.Equals("")))
            {
                fields.Add("FinishMark");
                values.Add(info.FinishMark);
            }
            if ((info.Remark != null) && (!info.Remark.Equals("")))
            {
                fields.Add("Remark");
                values.Add("'"+info.Remark+"'");
            }
            if ((info.TgicId != null) && (!info.TgicId.Equals("")))
            {
                fields.Add("tgicId");
                values.Add(info.TgicId);
            }

            if ((info.EiId != null) && (!info.EiId.Equals("")))
            {
                fields.Add("EiId");
                values.Add(info.EiId);
            }
            if ((info.PnId != null) && (!info.PnId.Equals("")))
            {
                fields.Add("PnId");
                values.Add(info.PnId);
            }
            if ((info.BarCode != null) && (!info.BarCode.Equals("")))
            {
                fields.Add("BarCode");
                values.Add("'"+info.BarCode+"'");
            }
            if ((info.PiId3 != null) && (!info.PiId3.Equals("")))
            {
                fields.Add("PiId3");
                values.Add(info.PiId3);
            }
            if ((info.LoadTime != null) && (!info.LoadTime.Equals("")))
            {
                fields.Add("LoadTime");
                values.Add("'" + info.LoadTime + "'");
            }
            return var.InsertTable("consignmentNote", fields, values);
        }
        /*
        * 方法名称：UpdateInfo
        * 方法功能描述：新增入库数据  
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-05
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool UpdateInfo(OutWeighingClass info)
        {
            DataVar var = new DataVar();
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            if ((info.IId != null) && (!info.IId.Equals("")))
            {
                fields.Add("iId");
                values.Add(info.IId);
            }
            if ((info.GrossWeight != null) && (!info.GrossWeight.Equals("")))
            {
                fields.Add("grossWeight");
                values.Add(info.GrossWeight);
            }
            if ((info.Tare != null) && (!info.Tare.Equals("")))
            {
                fields.Add("Tare");
                values.Add(info.Tare);
            }

            if ((info.Suttle != null) && (!info.Suttle.Equals("")))
            {
                fields.Add("Suttle");
                values.Add(info.Suttle);
            }
            if ((info.Surveyor != null) && (!info.Surveyor.Equals("")))
            {
                fields.Add("Surveyor");
                values.Add("'" + info.Surveyor + "'");
            }
            if ((info.Inspector != null) && (!info.Inspector.Equals("")))
            {
                fields.Add("Inspector");
                values.Add("'" + info.Inspector + "'");
            }
            if ((info.ViId != null) && (!info.ViId.Equals("")))
            {
                fields.Add("ViId");
                values.Add(info.ViId);
            }
            if ((info.SId1 != null) && (!info.SId1.Equals("")))
            {
                fields.Add("SId1");
                values.Add(info.SId1);
            }
            if ((info.SId2 != null) && (!info.SId2.Equals("")))
            {
                fields.Add("SId2");
                values.Add(info.SId2);
            }
            if ((info.InputDate != null) && (!info.InputDate.Equals("")))
            {
                fields.Add("InputDate");
                values.Add("'" + info.InputDate + "'");
            }
            if ((info.ComputationMark != null) && (!info.ComputationMark.Equals("")))
            {
                fields.Add("ComputationMark");
                values.Add(info.ComputationMark);
            }

            if ((info.CheckAccountMark1 != null) && (!info.CheckAccountMark1.Equals("")))
            {
                fields.Add("CheckAccountMark1");
                values.Add(info.CheckAccountMark1);
            }
            if ((info.CheckAccountMark2 != null) && (!info.CheckAccountMark2.Equals("")))
            {
                fields.Add("CheckAccountMark2");
                values.Add(info.CheckAccountMark2);
            }
            if ((info.Assessor != null) && (!info.Assessor.Equals("")))
            {
                fields.Add("Assessor");
                values.Add("'" + info.Assessor + "'");
            }
            if ((info.CheckupMan != null) && (!info.CheckupMan.Equals("")))
            {
                fields.Add("CheckupMan");
                values.Add("'" + info.CheckupMan + "'");
            }

            if ((info.FinishMark != null) && (!info.FinishMark.Equals("")))
            {
                fields.Add("FinishMark");
                values.Add(info.FinishMark);
            }
            if ((info.Remark != null) && (!info.Remark.Equals("")))
            {
                fields.Add("Remark");
                values.Add("'" + info.Remark + "'");
            }
            if ((info.TgicId != null) && (!info.TgicId.Equals("")))
            {
                fields.Add("tgicId");
                values.Add(info.TgicId);
            }

            if ((info.EiId != null) && (!info.EiId.Equals("")))
            {
                fields.Add("EiId");
                values.Add(info.EiId);
            }
            if ((info.PnId != null) && (!info.PnId.Equals("")))
            {
                fields.Add("PnId");
                values.Add(info.PnId);
            }
            if ((info.BarCode != null) && (!info.BarCode.Equals("")))
            {
                fields.Add("BarCode");
                values.Add("'"+info.BarCode+"'");
            }
            if ((info.LoadTime != null) && (!info.LoadTime.Equals("")))
            {
                fields.Add("LoadTime");
                values.Add("'" + info.LoadTime + "'");
            }
            if ((info.PiId3 != null) && (!info.PiId3.Equals("")))
            {
                fields.Add("PiId3");
                values.Add(info.PiId3);
            }
            
            ArrayList conds = new ArrayList();
            conds.Add("id=" + info.Id);
            return var.UpdateTeble("consignmentNote", fields, values,conds);
        }
        public DataTable SelectProjectName()
        {
            DataSet dt = new DataSet();
            DataTable recDt = new DataTable();
            ArrayList sqlList = new ArrayList();
            recDt.Columns.Add("id");
            recDt.Columns.Add("projectName");

            sqlList.Add("Select * from projectName");
            dt = sqlHelperObj.QueryForDateSet(sqlList);
            foreach (DataRow row in dt.Tables[0].Rows)
            {
                DataRow r = recDt.NewRow();
                r["id"] = row["id"].ToString();
                r["projectName"] = "工程名称:" + row["name"].ToString() + "|" +
                                    "工程部位:" + row["position"].ToString() + "|" +
                                    "单位工程:" + row["unitProject"].ToString() + "|" +
                                    "分部工程:" + row["subsectionProject"].ToString() + "|" +
                                    "分项工程:" + row["itemProject"].ToString() + "|" +
                                    "工程编号:" + row["no"].ToString() + "|";
                recDt.Rows.Add(r);
 
            }
            return recDt;
        }
    }
    class InWeighingDBLayer : WeighingDBlayer
    {
        SqlHelper sqlHelperObj = new SqlHelper();

        public DataTable GetInWeighingReport(string Id)
        {
            DataTable recDt = new DataTable("stockNote");
            recDt.Columns.Add("称重类型");
            recDt.Columns.Add("inputDate");
            recDt.Columns.Add("运输单位");
            recDt.Columns.Add("车牌号码");
            recDt.Columns.Add("车主姓名");
            recDt.Columns.Add("供应商");
            recDt.Columns.Add("产品名称");
            recDt.Columns.Add("规格型号");
            recDt.Columns.Add("毛重");
            recDt.Columns.Add("皮重");
            recDt.Columns.Add("净重");
            recDt.Columns.Add("司机姓名");
            recDt.Columns.Add("施工路线");
            recDt.Columns.Add("起运地");
            recDt.Columns.Add("施工位置");
            recDt.Columns.Add("止运地");

            FindCondClass conds = new FindCondClass();
            conds.Id = Id;
            DataTable dt = SelectInInfo(conds);
            if (dt.Rows.Count > 0)
            {
                DataRow row = recDt.NewRow();
                row["称重类型"] = "入厂称重";
                row["inputDate"] = dt.Rows[0]["日期"].ToString();
                row["运输单位"] = dt.Rows[0]["运输单位"].ToString();
                row["车牌号码"] = dt.Rows[0]["车牌号"].ToString();
                row["车主姓名"] = dt.Rows[0]["车主姓名"].ToString();
                //row["供应商"] = dt.Rows[0]["供应商"].ToString();
                row["产品名称"] = dt.Rows[0]["材料名称"].ToString();
                row["规格型号"] = dt.Rows[0]["材料型号"].ToString();
                row["毛重"] = dt.Rows[0]["毛重"].ToString();
                row["皮重"] = dt.Rows[0]["皮重"].ToString();
                row["净重"] = dt.Rows[0]["净重"].ToString();
                row["司机姓名"] = dt.Rows[0]["司机姓名"].ToString();
                //row["施工路线"] = dt.Rows[0]["inputDate"].ToString();
                row["起运地"] = dt.Rows[0]["起运地"].ToString();
                row["止运地"] = dt.Rows[0]["止运地"].ToString();

                recDt.Rows.Add(row);
            }
            return recDt;
        }
        /*
        * 方法名称：SelectStockContract
        * 方法功能描述：查询采购合同   
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */ 
        public DataTable SelectStockContract()
        {
            ArrayList sqlList = new ArrayList();
            DataSet ds = new DataSet();

            sqlList.Add("select id,[name],[no] from stockContract where finishMark=0");
            sqlList.Add(" and (not(assessor is NULL) and assessor!='')");
            sqlList.Add("  and (not(checkupMan is NULL) and checkupMan!='')");
            ds = sqlHelperObj.QueryForDateSet(sqlList);
            return ds.Tables[0];
        }
        /*
        * 方法名称：SelectIndent
        * 方法功能描述：取得合同明细   
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectIndent(string scId,string name)
        {
            LinkSelect linkS = new LinkSelect();
            DataSet ds = new DataSet();

            linkS.TableNames.Add("indent");            
            linkS.TableNames.Add("material");
            linkS.LinkConds.Add("indent.mid=material.id");
            linkS.TableNames.Add("materialName");
            linkS.LinkConds.Add("material.mnid=materialName.id");
            linkS.TableNames.Add("materialModel");
            linkS.LinkConds.Add("material.mmid=materialModel.id");
            linkS.Viewfields.Add("indent.id");
            linkS.Viewfields.Add("materialName.[name]+materialModel.model as name");
            //linkS.Viewfields.Add("materialModel.model");
            if (!scId.Equals(""))
                linkS.Conds.Add("indent.scid="+scId);
            if (!name.Equals(""))
                linkS.Conds.Add("materialName.[name]="+""+name+"");
            linkS.Conds.Add("finishMark=0");
            ds = linkS.LeftLinkOpen();
            return ds.Tables[0];
        }
        //public bool UpdateInWeighInfo()
        //{
 
        //}
        /*
        * 方法名称：SelectinWeighInfo
        * 方法功能描述：取得入库未处理完数据   
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectinWeighInfo(string truckId)
        {
            LinkSelect linkS = new LinkSelect();
            DataSet ds = new DataSet();

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
            linkS.TableNames.Add("transportGoodsInformationCorresponding");
            linkS.LinkConds.Add("stockNote.tgicId=transportGoodsInformationCorresponding.id");
            linkS.TableNames.Add("transportContract");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.tcId=transportContract.id");
            linkS.TableNames.Add("warehouseInfo");
            linkS.LinkConds.Add("stockNote.WiId=warehouseInfo.Id");
            linkS.TableNames.Add("personnelInfo as personnelInfo1");
            linkS.LinkConds.Add("stockNote.piId1=personnelInfo1.id");
            linkS.TableNames.Add("personnelInfo as personnelInfo2");
            linkS.LinkConds.Add("stockNote.piId2=personnelInfo2.id");
            

            linkS.Viewfields.Add("stockNote.id");
            //车牌号
            linkS.Viewfields.Add("voitureInfo.[no]");
            //销售合同名称
            linkS.Viewfields.Add("stockContract.[name] as ContractName");
            //材料名称
            linkS.Viewfields.Add("materialName.[name] as goodsName");
            //材料型号
            linkS.Viewfields.Add("materialModel.model as goodsModel");
            //车辆毛重
            linkS.Viewfields.Add("stockNote.grossWeight");
            //车辆皮重
            linkS.Viewfields.Add("stockNote.tare");
            //净重
            linkS.Viewfields.Add("stockNote.suttle");
            ////检斤员姓名
            //linkS.Viewfields.Add("stockNote.surveyor");
            ////复检员姓名
            //linkS.Viewfields.Add("stockNote.inspector");
            //检斤员姓名
            linkS.Viewfields.Add("personnelInfo1.name as surveyor");
            //复检员姓名
            linkS.Viewfields.Add("personnelInfo2.name as inspector");
            //运输单位
            linkS.Viewfields.Add("transportUnit.[name] as UnitName");
            //发货单内容
            linkS.Viewfields.Add("stockNote.asphaltumSuttle");
            //起运地
            linkS.Viewfields.Add("site1.site as site1");
            //此运地
            linkS.Viewfields.Add("site2.site as site2");
            //录入时间
            linkS.Viewfields.Add("stockNote.inputdate");
            //是否是自动采集
            linkS.Viewfields.Add("stockNote.computationMark");
            //审核人
            linkS.Viewfields.Add("stockNote.assessor");
            //审批人
            linkS.Viewfields.Add("stockNote.checkupMan");
            //小票是否打印过
            linkS.Viewfields.Add("stockNote.finishMark");
            //备注信息
            linkS.Viewfields.Add("stockNote.remark");
            //运输合同名
            linkS.Viewfields.Add("transportContract.contractName+'|材料:'+materialName.[name]+materialModel.model+'|'+site1.site+'-'+site2.site as transportinfo");
            //条码
            linkS.Viewfields.Add("stockNote.barCode");
            linkS.Viewfields.Add("warehouseInfo.[name]+'_'+warehouseInfo.[no] as warehouseName");            
            linkS.Viewfields.Add("stockNote.batchNumber");
            linkS.Viewfields.Add("stockNote.produceNo");

            if ((!truckId.Equals(null)) && (!truckId.Equals("")))
            {
                linkS.Conds.Add("stockNote.viId=" + "'" + truckId + "'");
            }
            linkS.Conds.Add("(stockNote.suttle is NULL or stockNote.suttle=0)");
            ds = linkS.LeftLinkOpen();
            return ds.Tables[0];
        }
        /*
        * 方法名称：SelectinWeighInfo
        * 方法功能描述：取得入库数据   
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-03
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectInInfo(FindCondClass conds)
        {
            LinkSelect linkS = new LinkSelect();
            DataSet ds = new DataSet();

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
            linkS.TableNames.Add("transportGoodsInformationCorresponding");
            linkS.LinkConds.Add("stockNote.tgicId=transportGoodsInformationCorresponding.id");
            linkS.TableNames.Add("transportContract");
            linkS.LinkConds.Add("transportGoodsInformationCorresponding.tcId=transportContract.id");
            linkS.TableNames.Add("personnelInfo as personnelInfo1");
            linkS.LinkConds.Add("stockNote.piId1=personnelInfo1.id");
            linkS.TableNames.Add("personnelInfo as personnelInfo2");
            linkS.LinkConds.Add("stockNote.piId2=personnelInfo2.id");
            linkS.Viewfields.Add("stockNote.id");
            //车牌号
            linkS.Viewfields.Add("voitureInfo.[no] as 车牌号");
            //销售合同名称
            linkS.Viewfields.Add("stockContract.[name] as 采购合同");
            //材料名称
            linkS.Viewfields.Add("materialName.[name] as 材料名称");
            //材料型号
            linkS.Viewfields.Add("materialModel.model as 材料型号");
            //车辆毛重
            linkS.Viewfields.Add("stockNote.grossWeight as 毛重");
            //车辆皮重
            linkS.Viewfields.Add("stockNote.tare as 皮重");
            //净重
            linkS.Viewfields.Add("stockNote.suttle as 净重");
            ////检斤员姓名
            //linkS.Viewfields.Add("stockNote.surveyor as 检斤员");
            ////复检员姓名
            //linkS.Viewfields.Add("stockNote.inspector as 复核员");
            //检斤员姓名
            linkS.Viewfields.Add("personnelInfo1.name as 检斤员");
            //复检员姓名
            linkS.Viewfields.Add("personnelInfo2.name as 复核员");
            //运输单位
            linkS.Viewfields.Add("transportUnit.[name] as 运输单位");
            //发货单内容
            linkS.Viewfields.Add("stockNote.asphaltumSuttle as 发货单");
            //起运地
            linkS.Viewfields.Add("site1.site as 起运地");
            //此运地
            linkS.Viewfields.Add("site2.site as 止运地");
            //录入时间
            linkS.Viewfields.Add("stockNote.inputdate as 日期");
            //是否是自动采集
            linkS.Viewfields.Add("stockNote.computationMark as 采集方式");
            //审核人
            linkS.Viewfields.Add("stockNote.assessor as 审核人");
            //审批人
            linkS.Viewfields.Add("stockNote.checkupMan as 审批人");
            //小票是否打印过
            linkS.Viewfields.Add("stockNote.finishMark as 票具打印");
            //备注信息
            linkS.Viewfields.Add("stockNote.remark as 备注");
            //运输合同名
            linkS.Viewfields.Add("transportContract.contractName as 运输合同");
            //条码
            linkS.Viewfields.Add("stockNote.barCode as 条码");
            linkS.Viewfields.Add("voitureInfo.owner as 车主姓名");
            linkS.Viewfields.Add("voitureInfo.driverName as 司机姓名");
            linkS.Viewfields.Add("voitureInfo.model as 车辆型号");
            linkS.Viewfields.Add("voitureInfo.color as 车辆颜色");
            linkS.Viewfields.Add("voitureInfo.lenth as 货箱长度");
            linkS.Viewfields.Add("voitureInfo.width as 货箱宽度");
            linkS.Viewfields.Add("voitureInfo.height as 货箱高度");
            linkS.Viewfields.Add("transportContract.[no] as 运输合同编号");            
            linkS.Viewfields.Add("transportUnit.corporation as 运输单位法人");
            linkS.Viewfields.Add("transportUnit.principal as 运输负责人");
            linkS.Viewfields.Add("transportUnit.phone as 运输单位电话");
            linkS.Viewfields.Add("transportUnit.Email as 运输单位邮箱");
            linkS.Viewfields.Add("transportUnit.capability as 运输能力");

            if ((conds.Id != null) && (!conds.Id.Equals("")))
            {
                linkS.Conds.Add("stockNote.id=" + conds.Id);
            }
            if ((conds.ContractName != null) && (!conds.ContractName.Equals("")))
            {
                linkS.Conds.Add("stockContract.[name]=" + "'" + conds.ContractName + "'");
            }
            if ((conds.GoodsName != null) && (!conds.GoodsName.Equals("")))
            {
                linkS.Conds.Add("materialName.[name]=" + "'" + conds.GoodsName + "'");
            }
            if ((conds.GoodsModel != null) && (!conds.GoodsModel.Equals("")))
            {
                linkS.Conds.Add("materialModel.model=" + "'" + conds.GoodsModel + "'");
            }            
            if ((conds.InSite != null) && (!conds.InSite.Equals("")))
            {
                linkS.Conds.Add("site1.site=" + "'" + conds.InSite + "'");
            }
            if ((conds.ToSite != null) && (!conds.ToSite.Equals("")))
            {
                linkS.Conds.Add("site2.site=" + "'" + conds.ToSite + "'");
            }
            if ((conds.TransportName != null) && (!conds.TransportName.Equals("")))
            {
                linkS.Conds.Add("transportContract.contractName=" + "'" + conds.TransportName + "'");
            }
            if ((conds.InDate != null) && (!conds.InDate.Equals("")))
            {
                linkS.Conds.Add("stockNote.inputdate>=" + "'" + conds.InDate + "'");
            }
            if ((conds.ToDate != null) && (!conds.ToDate.Equals("")))
            {
                linkS.Conds.Add("stockNote.inputdate<=" + "'" + conds.ToDate + "'");
            }
            if ((conds.TruckNo != null) && (!conds.TruckNo.Equals("")))
            {
                linkS.Conds.Add("voitureInfo.[no]=" + "'" + conds.TruckNo + "'");
            }
            if (conds.Style != null) 
            {
                switch (conds.Style)
                {
                    case "0":
                        linkS.Conds.Add("(stockNote.assessor='' or stockNote.assessor is NULL)");
                        linkS.Conds.Add("(stockNote.checkupMan='' or stockNote.checkupMan is NULL)");
                        break;
                    case "1":
                        linkS.Conds.Add("(stockNote.assessor<>'' and not(stockNote.assessor is NULL))");
                        linkS.Conds.Add("(stockNote.checkupMan='' or stockNote.checkupMan is NULL)");
                        break;
                    case "2":
                        linkS.Conds.Add("(stockNote.assessor<>'' and not(stockNote.assessor is NULL))");
                        linkS.Conds.Add("(stockNote.checkupMan<>'' and not(stockNote.checkupMan is NULL))");
                        break;
                    default:
                        ;
                        break;
                }
            }
            linkS.Conds.Add("( not (stockNote.suttle is NULL) and stockNote.suttle<>0)");
            ds = linkS.LeftLinkOpen();
            return ds.Tables[0];
        }
        /*
        * 方法名称：SelectProvider
        * 方法功能描述：通过采购合同，取得供应商   
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-05
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectProvider(string scId)
        {
            LinkSelect linkS = new LinkSelect();
            DataSet ds = new DataSet();

            linkS.TableNames.Add("stockContract");
            linkS.TableNames.Add("providerInfo");
            linkS.LinkConds.Add("stockContract.piId=providerInfo.id");
            linkS.Viewfields.Add("stockContract.[name] as name1");
            linkS.Viewfields.Add("providerInfo.id");
            linkS.Viewfields.Add("providerInfo.[name] as name2");
            linkS.Conds.Add("stockContract.id="+scId);
            ds = linkS.LeftLinkOpen();
            return ds.Tables[0];
        }
        public long GetMaxInRecId()
        {
            DataSet ds  = new DataSet();
            ArrayList sqlText = new ArrayList();
            sqlText.Add("SELECT MAX(id) AS RegID FROM stockNote");
            ds = sqlHelperObj.QueryForDateSet(sqlText);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
            }
            else
                return -1;
 
        }
        /*
        * 方法名称：InsertInfo
        * 方法功能描述：新建入库数据  
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-05
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertInfo(InWeighingClass info)
        {
            DataVar var = new DataVar();
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            if ((info.IId!=null) && (!info.IId.Equals("")))
            {
                fields.Add("iId");
                values.Add(info.IId);
            }
            if ((info.GrossWeight!=null) && (!info.GrossWeight.Equals("")))
            {
                fields.Add("grossWeight");
                values.Add(info.GrossWeight);
            }
            if ((info.Tare != null) && (!info.Tare.Equals("")))
            {
                fields.Add("Tare");
                values.Add(info.Tare);
            }

            if ((info.Suttle != null) && (!info.Suttle.Equals("")))
            {
                fields.Add("Suttle");
                values.Add(info.Suttle);
            }
            if ((info.AsphaltumSuttle != null) && (!info.AsphaltumSuttle.Equals("")))
            {
                fields.Add("AsphaltumSuttle");
                values.Add(info.AsphaltumSuttle);
            }
            if ((info.Surveyor != null) && (!info.Surveyor.Equals("")))
            {
                fields.Add("Surveyor");
                values.Add("'" + info.Surveyor + "'");
            }
            if ((info.Inspector!=null) && (!info.Inspector.Equals("")))
            {
                fields.Add("Inspector");
                values.Add("'" + info.Inspector + "'");
            }
            if ((info.ViId != null) && (!info.ViId.Equals("")))
            {
                fields.Add("ViId");
                values.Add(info.ViId);
            }
            if ((info.SId1 != null) && (!info.SId1.Equals("")))
            {
                fields.Add("SId1");
                values.Add(info.SId1);
            }
            if ((info.SId2 != null) && (!info.SId2.Equals("")))
            {
                fields.Add("SId2");
                values.Add(info.SId2);
            }
            if ((info.InputDate != null) && (!info.InputDate.Equals("")))
            {
                fields.Add("InputDate");
                values.Add("'" + info.InputDate + "'");
            }
            if ((info.ComputationMark != null) && (!info.ComputationMark.Equals("")))
            {
                fields.Add("ComputationMark");
                values.Add(info.ComputationMark);
            }

            if ((info.CheckAccountMark1 != null) && (!info.CheckAccountMark1.Equals("")))
            {
                fields.Add("CheckAccountMark1");
                values.Add(info.CheckAccountMark1);
            }
            if ((info.CheckAccountMark2 != null) && (!info.CheckAccountMark2.Equals("")))
            {
                fields.Add("CheckAccountMark2");
                values.Add(info.CheckAccountMark2);
            }
            if ((info.Assessor != null) && (!info.Assessor.Equals("")))
            {
                fields.Add("Assessor");
                values.Add("'" + info.Assessor + "'");
            }
            if ((info.CheckupMan != null) && (!info.CheckupMan.Equals("")))
            {
                fields.Add("CheckupMan");
                values.Add("'" + info.CheckupMan + "'");
            }

            if ((info.FinishMark != null) && (!info.FinishMark.Equals("")))
            {
                fields.Add("FinishMark");
                values.Add(info.FinishMark);
            }
            if ((info.Remark != null) && (!info.Remark.Equals("")))
            {
                fields.Add("Remark");
                values.Add("'" + info.Remark + "'");
            }
            if ((info.TgicId != null) && (!info.TgicId.Equals("")))
            {
                fields.Add("tgicId");
                values.Add(info.TgicId);
            }
            if ((info.BarCode != null) && (!info.BarCode.Equals("")))
            {
                fields.Add("BarCode");
                values.Add("'" + info.BarCode + "'");
            }
            if ((info.UnloadTime != null) && (!info.UnloadTime.Equals("")))
            {
                fields.Add("UnloadTime");
                values.Add("'" + info.UnloadTime + "'");
            }
            if ((info.PiId3 != null) && (!info.PiId3.Equals("")))
            {
                fields.Add("PiId3");
                values.Add(info.PiId3);
            }
            if ((info.WiId != null) && (!info.WiId.Equals("")))
            {
                fields.Add("WiId");
                values.Add(info.WiId);
            }
            if ((info.BatchNumber != null) && (!info.BatchNumber.Equals("")))
            {
                fields.Add("BatchNumber");
                values.Add("'" + info.BatchNumber + "'");
            }
            if ((info.BatchNo != null) && (!info.BatchNo.Equals("")))
            {
                fields.Add("produceNo");
                values.Add("'" + info.BatchNo + "'");
            }
            return var.InsertTable("stockNote", fields, values);        

        }
        /*
        * 方法名称：UpdateInfo
        * 方法功能描述：更新入库数据  
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-03-05
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool UpdateInfo(InWeighingClass info)
        {
            DataVar var = new DataVar();
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            if ((info.IId != null) && (!info.IId.Equals("")))
            {
                fields.Add("iId");
                values.Add(info.IId);
            }
            if ((info.GrossWeight != null) && (!info.GrossWeight.Equals("")))
            {
                fields.Add("grossWeight");
                values.Add(info.GrossWeight);
            }
            if ((info.Tare != null) && (!info.Tare.Equals("")))
            {
                fields.Add("Tare");
                values.Add(info.Tare);
            }

            if ((info.Suttle != null) && (!info.Suttle.Equals("")))
            {
                fields.Add("Suttle");
                values.Add(info.Suttle);
            }
            if ((info.AsphaltumSuttle != null) && (!info.AsphaltumSuttle.Equals("")))
            {
                fields.Add("AsphaltumSuttle");
                values.Add(info.AsphaltumSuttle);
            }
            if ((info.Surveyor != null) && (!info.Surveyor.Equals("")))
            {
                fields.Add("Surveyor");
                values.Add("'" + info.Surveyor + "'");
            }
            if ((info.Inspector != null) && (!info.Inspector.Equals("")))
            {
                fields.Add("Inspector");
                values.Add("'" + info.Inspector + "'");
            }
            if ((info.ViId != null) && (!info.ViId.Equals("")))
            {
                fields.Add("ViId");
                values.Add(info.ViId);
            }
            if ((info.SId1 != null) && (!info.SId1.Equals("")))
            {
                fields.Add("SId1");
                values.Add(info.SId1);
            }
            if ((info.SId2 != null) && (!info.SId2.Equals("")))
            {
                fields.Add("SId2");
                values.Add(info.SId2);
            }
            if ((info.InputDate != null) && (!info.InputDate.Equals("")))
            {
                fields.Add("InputDate");
                values.Add("'" + info.InputDate + "'");
            }
            if ((info.ComputationMark != null) && (!info.ComputationMark.Equals("")))
            {
                fields.Add("ComputationMark");
                values.Add(info.ComputationMark);
            }

            if ((info.CheckAccountMark1 != null) && (!info.CheckAccountMark1.Equals("")))
            {
                fields.Add("CheckAccountMark1");
                values.Add(info.CheckAccountMark1);
            }
            if ((info.CheckAccountMark2 != null) && (!info.CheckAccountMark2.Equals("")))
            {
                fields.Add("CheckAccountMark2");
                values.Add(info.CheckAccountMark2);
            }
            if ((info.Assessor != null) && (!info.Assessor.Equals("")))
            {
                fields.Add("Assessor");
                values.Add("'" + info.Assessor + "'");
            }
            if ((info.CheckupMan != null) && (!info.CheckupMan.Equals("")))
            {
                fields.Add("CheckupMan");
                values.Add("'" + info.CheckupMan + "'");
            }

            if ((info.FinishMark != null) && (!info.FinishMark.Equals("")))
            {
                fields.Add("FinishMark");
                values.Add(info.FinishMark);
            }
            if ((info.Remark != null) && (!info.Remark.Equals("")))
            {
                fields.Add("Remark");
                values.Add("'" + info.Remark + "'");
            }
            if ((info.TgicId != null) && (!info.TgicId.Equals("")))
            {
                fields.Add("tgicId");
                values.Add(info.TgicId);
            }
            if ((info.BarCode != null) && (!info.BarCode.Equals("")))
            {
                fields.Add("BarCode");
                values.Add("'" + info.BarCode + "'");
            }
            if ((info.UnloadTime != null) && (!info.UnloadTime.Equals("")))
            {
                fields.Add("UnloadTime");
                values.Add("'" + info.UnloadTime + "'");
            }
            if ((info.PiId3 != null) && (!info.PiId3.Equals("")))
            {
                fields.Add("PiId3");
                values.Add(info.PiId3);
            }
            if ((info.WiId != null) && (!info.WiId.Equals("")))
            {
                fields.Add("WiId");
                values.Add(info.WiId);
            }
            if ((info.BatchNumber != null) && (!info.BatchNumber.Equals("")))
            {
                fields.Add("BatchNumber");
                values.Add("'" + info.BatchNumber + "'");
            }
            if ((info.BatchNo != null) && (!info.BatchNo.Equals("")))
            {
                fields.Add("produceNo");
                values.Add("'" + info.BatchNo + "'");
            }            
            ArrayList conds = new ArrayList();
            conds.Add("id=" + info.Id);
            return var.UpdateTeble("stockNote", fields, values,conds);
        }
 
    }
    /*
     * 类名称：OtherWeighingDB
     * 类功能描述：第三方称重数据层类
     *
     * 创建人：袁宇
     * 创建时间：2009-03-03
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class OtherWeighingDB
    {
        SqlHelper sqlHelperObj = new SqlHelper();
        /*
       * 方法名称：SelectPersonnelInfo
       * 方法功能描述：取得人员信息
       * 参数:        
       * 返回: DataTable 数据
       * 创建人：袁宇
       * 创建时间：2009-04-11
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable SelectPersonnelInfo()
        {
            
            ArrayList sqlStr = new ArrayList();

            sqlStr.Add("select id,[name] from personnelInfo");

            return sqlHelperObj.QueryForDateSet(sqlStr).Tables[0];
        }
        /*
        * 方法名称：SelectThirdPartyWeight
        * 方法功能描述：查询第三方称重数据
        * 参数:        
        * 返回: DataTable 数据
        * 创建人：袁宇
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectThirdPartyWeight(string name, string model, string Client)
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("thirdPartyWeight");
            linkS.TableNames.Add("personnelInfo");
            linkS.LinkConds.Add("thirdPartyWeight.piId=personnelInfo.id");
            linkS.Viewfields.Add("thirdPartyWeight.id");
            linkS.Viewfields.Add("thirdPartyWeight.[name] as 货物名称");
            linkS.Viewfields.Add("thirdPartyWeight.model as 货物型号");
            linkS.Viewfields.Add("thirdPartyWeight.[no] as 车牌号码");
            linkS.Viewfields.Add("thirdPartyWeight.client as 客户名称");
            linkS.Viewfields.Add("thirdPartyWeight.grossWeight as 毛重");
            linkS.Viewfields.Add("thirdPartyWeight.tare as 皮重");
            linkS.Viewfields.Add("thirdPartyWeight.suttle as 净重");
            linkS.Viewfields.Add("personnelInfo.[name] as 检斤员");
            linkS.Viewfields.Add("thirdPartyWeight.money as 检斤费用");
            linkS.Viewfields.Add("thirdPartyWeight.inputDate as 录入时间");
            linkS.Viewfields.Add("thirdPartyWeight.inputMan as 录入人");
            if (!name.Trim().Equals(""))
                linkS.Conds.Add("thirdPartyWeight.[name]=" + "'" + name + "'");
            if (!model.Trim().Equals(""))
                linkS.Conds.Add("thirdPartyWeight.model=" + "'" + model + "'");
            if (!Client.Trim().Equals(""))
                linkS.Conds.Add("thirdPartyWeight.client=" + "'" + Client + "'");
            return linkS.LeftLinkOpen().Tables[0];
        }
        /*
        * 方法名称：SelectThirdPartyWeight
        * 方法功能描述：查询第三方称重数据
        * 参数:        
        * 返回: DataTable 数据
        * 创建人：袁宇
        * 创建时间：2009-04-11
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertThirdPartyWeight(OtherweighingClass info)
        {
            if (info != null)
            {
                DataVar var = new DataVar();
                ArrayList fields = new ArrayList();
                ArrayList values = new ArrayList();
                if ((info.Name != null)&&(!info.Name.Trim().Equals("")))
                {
                    fields.Add("name");
                    values.Add("'"+info.Name+"'");
                }
                if ((info.Model != null) && (!info.Model.Trim().Equals("")))
                {
                    fields.Add("Model");
                    values.Add("'" + info.Model + "'");
                }
                if ((info.No != null) && (!info.No.Trim().Equals("")))
                {
                    fields.Add("No");
                    values.Add("'" + info.No + "'");
                }
                if ((info.Client != null) && (!info.Client.Trim().Equals("")))
                {
                    fields.Add("Client");
                    values.Add("'" + info.Client + "'");
                }
                if ((info.Date != null) && (!info.Date.Trim().Equals("")))
                {
                    fields.Add("Date");
                    values.Add("'" + info.Date + "'");
                }
                if ((info.PiId != null) && (!info.PiId.Trim().Equals("")))
                {
                    fields.Add("PiId");
                    values.Add(info.PiId);
                }
                if ((info.Money != null) && (!info.Money.Trim().Equals("")))
                {
                    fields.Add("Money");
                    values.Add(info.Money);
                }
                if ((info.GrossWeight != null) && (!info.GrossWeight.Trim().Equals("")))
                {
                    fields.Add("GrossWeight");
                    values.Add("'" + info.GrossWeight + "'");
                }
                if ((info.Tare != null) && (!info.Tare.Trim().Equals("")))
                {
                    fields.Add("Tare");
                    values.Add(info.Tare);
                }
                if ((info.Suttle != null) && (!info.Suttle.Trim().Equals("")))
                {
                    fields.Add("Suttle");
                    values.Add(info.Suttle);
                }
                fields.Add("inputDate");
                values.Add("'" + DateTime.Now.ToString() + "'");
                fields.Add("inputMan");
                values.Add("'测试'");
                return var.InsertTable("thirdPartyWeight",fields,values);               
                
            }
            else
                return false;
        }
        public bool DeleteThirdPartyWeight(string id)
        {
            ArrayList sqlStr = new ArrayList();
            sqlStr.Add("delete from thirdPartyWeight where id="+id);
            return sqlHelperObj.Delete(sqlStr);
        }
    }
    class RDLCWeighingDB
    {
        public string GetWeighingKind()
        {
            return "";
        }
    }
}
