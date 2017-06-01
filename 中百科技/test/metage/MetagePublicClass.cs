using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DasherStation.metage
{
    class OutWeighingClass
    {
        //主键，自增长
        private string id;
        //关联invoice（销售合同明细表）的id值，表示该条数据属于哪个销售合同明细
        private string iId;
        //车辆的毛重（单位：吨）
        private string grossWeight;
        //车辆的皮重（单位：吨）
        private string tare;
        //货物称量净重（单位：吨）
        private string suttle;
        //检斤员姓名
        private string surveyor;
        //复检员姓名
        private string inspector;
        //关联voitureInfo（车辆信息表）的id值，表示该货物是由哪辆车运送的
        private string viId;
        //关联site（地点表）的id，标明货物的起运地点
        private string sId1;
        //关联site（地点表）的id，标明货物的止运地点
        private string sId2;
        //录入记录时间，默认值：数据库时间
        private string inputDate;
        //标明是否是自动采集，注：值等于0为自动采集，值等于1为手工录入货物净重，值等于2为手工归档
        private string computationMark;
        //销售结算的对账标记，FALSE：未对账，TRUE：已对账
        private string checkAccountMark1;
        //运输结算的对账标记，FALSE：未对账，TRUE：已对账
        private string checkAccountMark2;
        //审核人
        private string assessor;
        //审批人
        private string checkupMan;
        //小票一旦被打印一次此标志将被置为TRUE表示小票上的数据不能再被修改，默认值为FALSE
        private string finishMark;
        //备注信息
        private string remark;
        //关联transportContract（运输合同表）的id，标明该记录属于哪个运输合同
        private string tgicId;
        //关联equipmentInformation（设备信息表）的id，标明是哪个拌和机生产的产品
        private string eiId;
        //关联projectName（工程项目表）的id，标明工程项目信息
        private string pnId;
        //小票上的条形码信息
        private string barCode;

        //审核时间
        private string assessDate;
        //审批时间
        private string checkupDate;
        //装卸货时间
        private string loadTime;
        //材料员
        private string piId3;

        public string AssessDate
        {
            get { return assessDate; }
            set { assessDate = value; }
        }
        public string CheckupDate
        {
            get { return checkupDate; }
            set { checkupDate = value; }
        }
        public string LoadTime
        {
            get { return loadTime; }
            set { loadTime = value; }
        }
        public string PiId3
        {
            get { return piId3; }
            set { piId3 = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string IId
        {
            get { return iId; }
            set { iId = value; }
        }
        public string GrossWeight
        {
            get { return grossWeight; }
            set { grossWeight = value; }
        }
        public string Tare
        {
            get { return tare; }
            set { tare = value; }
        }
        public string Suttle
        {
            get { return suttle; }
            set { suttle = value; }
        }
        public string Surveyor
        {
            get { return surveyor; }
            set { surveyor = value; }
        }
        public string Inspector
        {
            get { return inspector; }
            set { inspector = value; }
        }
        public string ViId
        {
            get { return viId; }
            set { viId = value; }
        }
        public string SId1
        {
            get { return sId1; }
            set { sId1 = value; }
        }
        public string SId2
        {
            get { return sId2; }
            set { sId2 = value; }
        }
        public string InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }
        public string ComputationMark
        {
            get { return computationMark; }
            set { computationMark = value; }
        }
        public string CheckAccountMark1
        {
            get { return checkAccountMark1; }
            set { checkAccountMark1 = value; }
 
        }
        public string CheckAccountMark2
        {
            get { return checkAccountMark2; }
            set { checkAccountMark2 = value; }

        }
        public string Assessor
        {
            get { return assessor; }
            set { assessor = value; } 
        }
        public string CheckupMan
        {
            get { return checkupMan; }
            set { checkupMan = value; }
        }
        public string FinishMark
        {
            get { return finishMark; }
            set { finishMark = value; }
        }
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        public string TgicId
        {
            get { return tgicId; }
            set { tgicId = value; }
        }
        public string EiId
        {
            get { return eiId; }
            set { eiId = value; }
        }
        public string PnId
        {
            get { return pnId; }
            set { pnId = value; }
        }
        public string BarCode
        {
            get { return barCode; }
            set { barCode = value; }
        }
    }
    class InWeighingClass
    {
        //主键，自增长
        private string id;
        //关联indent（采购合同明细表）的id值，表示该条数据属于哪个采购合同明细
        private string iId;
        //车辆的毛重（单位：吨）
        private string grossWeight;
        //车辆的皮重（单位：吨）
        private string tare;
        //手工录入货物的体积（单位：立方米）
        private string volume;
        //货物称量净重（单位：吨）
        private string suttle;
        //发货单上沥青的净重
        private string asphaltumSuttle;
        //检斤员姓名
        private string surveyor;
        //复检员姓名
        private string inspector;
        //关联voitureInfo（车辆信息表）的id值，表示该货物是由哪辆车运送的
        private string viId;
        //关联site（地点表）的id，标明货物的起运地点
        private string sId1;
        //关联site（地点表）的id，标明货物的止运地点
        private string sId2;
        //标明货物的含水率和杂质率
        private string hydrousImpurityRate;
        //录入时间
        private string inputDate;
        //标明是否是自动采集，注：值等于0为自动采集，值等于1为手工录入含水率、杂质率，值等于2为手工录入货物净重，
        //3为手工归档
        private string computationMark;
        //若材料为沥青则标明发货单的重量与实际称得的重量差是否在误差范围内，若货物不是沥青或在误差范围内合法则为0，
        //若不在误差范围内则为1，经过领导调整后的重量不论是否在误差范围内值均为2"
        private string legalityMark;        
        //标明流量计的读数（单位：吨）
        private string flowmeterReading;
        //采购核算的对账标记，FALSE：未对账，TRUE：已对账
        private string checkAccountMark1;
        //运输核算的对账标记，FALSE：未对账，TRUE：已对账
        private string checkAccountMark2;
        //审核人
        private string assessor;
        //审批人
        private string checkupMan;
        //小票一旦被打印一次此标志将被置为TRUE表示小票上的数据不能再被修改，默认值为FALSE
        private string finishMark;
        //备注信息
        private string remark;
        //关联transportContract（运输合同表）的id，标明该记录属于哪个运输合同
        private string tgicId;
        //小票上的条形码信息
        private string barCode;

        //审核时间
        private string assessDate;
        //审批时间
        private string checkupDate;
        //装卸货时间
        private string unloadTime;
        //材料员ID
        private string piId3;
        //仓库信息ID
        private string wiId;
        //批生产量
        private string batchNumber;
        //生产批号
        private string batchNo;

        public string BatchNo
        {
            get { return batchNo; }
            set { batchNo = value; }
        }
        public string AssessDate
        {
            get { return assessDate; }
            set { assessDate = value; }
        }
        public string CheckupDate
        {
            get { return checkupDate; }
            set { checkupDate = value; }
        }
        public string UnloadTime
        {
            get { return unloadTime; }
            set { unloadTime = value; }
        }
        public string PiId3
        {
            get { return piId3; }
            set { piId3 = value; }
        }
        public string WiId
        {
            get { return wiId; }
            set { wiId = value; }
        }
        public string BatchNumber
        {
            get { return batchNumber; }
            set { batchNumber = value; }
        }

        public string Id
        {
            get { return id;}
            set { id = value;}
        }
        public string IId
        {
            get { return iId;}
            set { iId = value;}
        }
        public string GrossWeight
        {
            get { return grossWeight; }
            set { grossWeight = value; }
        }
        public string Tare
        {
            get { return tare; }
            set { tare = value; }
        }
        public string Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        public string Suttle
        {
            get { return suttle; }
            set { suttle = value; }
        }
        public string AsphaltumSuttle
        {
            get { return asphaltumSuttle; }
            set { asphaltumSuttle = value; }
        }
        public string Surveyor
        {
            get { return surveyor; }
            set { surveyor = value; }
        }
        public string Inspector
        {
            get { return inspector; }
            set { inspector = value; }
        }
        public string ViId
        {
            get { return viId; }
            set { viId = value; }
        }
        public string SId1
        {
            get { return sId1; }
            set { sId1 = value; }
        }
        public string SId2
        {
            get { return sId2; }
            set { sId2 = value; }
        }
        public string HydrousImpurityRate
        {
            get { return hydrousImpurityRate; }
            set { hydrousImpurityRate = value; }
        }
        public string InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }
        public string ComputationMark
        {
            get { return computationMark; }
            set { computationMark = value; }
        }
        public string LegalityMark
        {
            get { return legalityMark; }
            set { legalityMark = value; }
        }
        public string FlowmeterReading
        {
            get { return flowmeterReading; }
            set { flowmeterReading = value; }
        }
        public string CheckAccountMark1
        {
            get { return checkAccountMark1; }
            set { checkAccountMark1 = value; }
        }
        public string CheckAccountMark2
        {
            get { return checkAccountMark2; }
            set { checkAccountMark2 = value; }
        }
        public string Assessor
        {
            get { return assessor; }
            set { assessor = value; }
        }
        public string CheckupMan
        {
            get { return checkupMan; }
            set { checkupMan = value; }
        }
        public string FinishMark
        {
            get { return finishMark; }
            set { finishMark = value; }
        }
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        public string TgicId
        {
            get { return tgicId; }
            set { tgicId = value; }
        }
        public string BarCode
        {
            get { return barCode; }
            set { barCode = value; }
        }

    }
    class WeighingStyle
    {
        public const string InStyle = "入库称重";
        public const string OutStyle = "出库称重";
    }
    class FindCondClass
    {
        //主键，自增长
        private string id;
        //表示该条数据属于哪个采购合同
        private string contractName;       
        //表示该货物是由哪辆车运送的
        private string truckNo;
        //标明货物的起运地点
        private string inSite;
        //标明货物的止运地点
        private string toSite;        
        //开始时间
        private string inDate;
        //结束时间
        private string toDate;
        //标明是否是自动采集，注：值等于0为自动采集，值等于1为手工录入含水率、杂质率，值等于2为手工录入货物净重，
        //3为手工归档
        private string computationMark;        
        //关联transportContract（运输合同表）的id，标明该记录属于哪个运输合同
        private string transportName;
        //物品名称
        private string goodsName;
        //物品型号
        private string goodsModel;
        //状态 0 没处理 1 审核通过待审批 2 审核审批通过
        private string style;

        public string Style
        {
            get { return style; }
            set { style = value; }
        }       
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string ContractName
        {
            get { return contractName; }
            set { contractName = value; }
        }
        public string TruckNo
        {
            get { return truckNo; }
            set { truckNo = value; }
        }
        public string InSite
        {
            get { return inSite; }
            set { inSite = value; }
        }
        public string ToSite
        {
            get { return toSite; }
            set { toSite = value; }
        }
        public string InDate
        {
            get { return inDate; }
            set { inDate = value; }
        }
        public string ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }
        public string ComputationMark
        {
            get { return computationMark; }
            set { computationMark = value; }
        }
        public string TransportName
        {
            get { return transportName; }
            set { transportName = value; }
        }
        public string GoodsName
        {
            get { return goodsName; }
            set { goodsName = value; }
        }
        public string GoodsModel
        {
            get { return goodsModel; }
            set { goodsModel = value; }
        } 

    }
    /*
     * 类名称：OtherweighingClass
     * 类功能描述：第三方称重实体类
     *
     * 创建人：袁宇
     * 创建时间：2009-4-11
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class OtherweighingClass
    {
        private string id;
        private string date;
        private string name;
        private string model;
        private string no;
        private string client;
        private string grossWeight;
        private string tare;
        private string suttle;
        private string assessor;
        private string checkupMan;
        private string assessDate;
        private string checkupDate;
        private string piId;
        private string money;
        private string inputDate;
        private string inputMan;

        public string Id
        {
            get { return id; }
            set { id = value; } 
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string No
        {
            get { return no; }
            set { no = value; }
        }
        public string Client
        {
            get { return client; }
            set { client = value; }
        }
        public string GrossWeight
        {
            get { return grossWeight; }
            set { grossWeight = value; }
        }
        public string Tare
        {
            get { return tare; }
            set { tare = value; }
        }
        public string Suttle
        {
            get { return suttle; }
            set { suttle = value; }
        }
        public string Assessor
        {
            get { return assessor; }
            set { assessor = value; }
        }
        public string CheckupMan
        {
            get { return checkupMan; }
            set { checkupMan = value; }
        }
        public string AssessDate
        {
            get { return assessDate; }
            set { assessDate = value; }
        }
        public string CheckupDate
        {
            get { return checkupDate; }
            set { checkupDate = value; }
        }
        public string PiId
        {
            get { return piId; }
            set { piId = value; }
        }
        public string Money
        {
            get { return money; }
            set { money = value; }
        }
        public string InputDate
        {
            get { return inputDate; }
            set { inputDate = value; }
        }
        public string InputMan
        {
            get { return inputMan; }
            set { inputMan = value; }
        }
    }
}
