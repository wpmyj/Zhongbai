using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DasherStation.common;
using System.Data;
using System.Collections;

namespace DasherStation.ReportDistrict.produceReport
{
    class ReportProduceClass
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
        * 方法名称： RunOvenUsedEnergyRecord
        * 方法功能描述：打印热油炉能源消耗记录相关信息;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-22
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void RunOvenUsedEnergyRecord(string where)
        {
            string lSearchStr = "select drcds.id,eiid,Convert(varchar(10),drcds.produceDate,120) 生产日期 ,ei.no 设备编号";
            lSearchStr = lSearchStr + " ,mn.name 燃料名称,mm.model 规格型号";
            lSearchStr = lSearchStr + ",case when fuelWastage2 is not null then fuelWastage2 else fuelWastage1 end 燃油煤量";
            lSearchStr = lSearchStr + ",consumeCoulometry 电量消耗,consumeRate1 原料消耗率,consumeRate2 用电量 ";
            lSearchStr = lSearchStr + " from deepFatConsumeDailyStatistics drcds  ";
            lSearchStr = lSearchStr + " left join equipmentInformation ei on drcds.eiid=ei.id  ";
            lSearchStr = lSearchStr + " left join material m on drcds.mid=m.id ";
            lSearchStr = lSearchStr + " left join materialName mn on m.mnid=mn.id ";
            lSearchStr = lSearchStr + " left join materialModel mm on m.mmid=mm.id ";
            lSearchStr = lSearchStr + " " + where;

            DataSet ds = helper.QueryForDateSet(lSearchStr);
            OvenUsedEnergyRecord oOvenUsedEnergyRecord = new OvenUsedEnergyRecord();
            oOvenUsedEnergyRecord.Source = ds;
            oOvenUsedEnergyRecord.CoName = name_value();
            oOvenUsedEnergyRecord.Number = "1001";
            oOvenUsedEnergyRecord.Tabler = "ccc";
            oOvenUsedEnergyRecord.Charge = "111";
            oOvenUsedEnergyRecord.Time = "ffff-ff-ff";
            oOvenUsedEnergyRecord.ShowReport();
        }

        /*
        * 方法名称： RunOvenUsedEnergyRecord
        * 方法功能描述：打印生产统计报表（日统计）相关信息;
        * 
        * 创建人：冯雪 
        * 创建时间：2009-04-22
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void RunDayProduceCount(string where)
        {
            string lSearchStr = "SELECT  CONVERT(varchar(10), pl.produceDate, 120)as 日期 ";
            lSearchStr = lSearchStr + " , pk.sort AS 产品种类, pn.name AS 产品名称, pm.model AS 规格型号";
            lSearchStr = lSearchStr + " , en.name AS 设备名称, ei.no AS 设备编号,pl.pid";
            lSearchStr = lSearchStr + " , (select sum(ISNULL(mpl.quantity2, mpl.quantity1)) from  mixtureProduceLog mpl where mpl.pid = pl.pid and CONVERT(varchar(10), mpl.produceDate, 120) = CONVERT(varchar(10), pl.produceDate, 120))AS 日生产量";
            lSearchStr = lSearchStr + " ,(select sum(ISNULL(mpl.quantity2, mpl.quantity1)) from mixtureProduceLog mpl where mpl.pid = pl.pid and mpl.produceDate <= pl.produceDate ) as 累计生产量";
            lSearchStr = lSearchStr + " FROM equipmentName AS en INNER JOIN";
            lSearchStr = lSearchStr + "  equipmentInformation AS ei ON en.id = ei.enId INNER  JOIN";
            lSearchStr = lSearchStr + "  mixtureProduceLog AS pl ON ei.id = pl.eiId INNER   JOIN";
            lSearchStr = lSearchStr + "  product AS p ON pl.pId = p.id INNER JOIN";
            lSearchStr = lSearchStr + "  productName AS pn ON p.pnId = pn.id INNER  JOIN";
            lSearchStr = lSearchStr + "  productKind AS pk ON pn.pkId = pk.id INNER  JOIN";
            lSearchStr = lSearchStr + " productModel AS pm ON p.pmId = pm.id ";
            lSearchStr = lSearchStr + " where 1=1 " + where;
            lSearchStr = lSearchStr + " group by pl.produceDate,pk.sort, pn.name, pm.model,en.name,ei.no,pl.pid ";
            lSearchStr = lSearchStr + " union all ";
            lSearchStr = lSearchStr + " SELECT CONVERT(varchar(10), pl.produceDate, 120)as 日期 ";
            lSearchStr = lSearchStr + " , pk.sort AS 产品种类, pn.name AS 产品名称, pm.model AS 规格型号";
            lSearchStr = lSearchStr + " , ei.no AS 设备编号, en.name AS 设备名称,pl.pid ";
            lSearchStr = lSearchStr + " ,(select sum(ISNULL(mpl.quantity2, mpl.quantity1)) from emulsificationAsphaltumProduceLog mpl where mpl.pid = pl.pid and CONVERT(varchar(10), mpl.produceDate, 120) = CONVERT(varchar(10), pl.produceDate, 120))AS 日生产量";
            lSearchStr = lSearchStr + " ,(select sum(ISNULL(mpl.quantity2, mpl.quantity1)) from emulsificationAsphaltumProduceLog mpl where mpl.pid = pl.pid and mpl.produceDate <= pl.produceDate ) as 累计生产量";
            lSearchStr = lSearchStr + " FROM equipmentName AS en INNER  JOIN";
            lSearchStr = lSearchStr + "  equipmentInformation AS ei ON en.id = ei.enId INNER  JOIN";
            lSearchStr = lSearchStr + "  emulsificationAsphaltumProduceLog AS pl ON ei.id = pl.eiId INNER  JOIN";
            lSearchStr = lSearchStr + "  product AS p ON pl.pId2 = p.id INNER  JOIN";
            lSearchStr = lSearchStr + "  productName AS pn ON p.pnId = pn.id INNER  JOIN";
            lSearchStr = lSearchStr + "  productKind AS pk ON pn.pkId = pk.id INNER  JOIN";
            lSearchStr = lSearchStr + "  productModel AS pm ON p.pmId = pm.id ";
            lSearchStr = lSearchStr + " where 1=1 " + where;
            lSearchStr = lSearchStr + "  group by pl.produceDate,pk.sort, pn.name, pm.model,en.name,ei.no,pl.pid ";
            lSearchStr = lSearchStr + " union all ";
            lSearchStr = lSearchStr + " SELECT CONVERT(varchar(10), pl.produceDate, 120)as 日期 ";
            lSearchStr = lSearchStr + " , pk.sort AS 产品种类, pn.name AS 产品名称, pm.model as 规格型号";
            lSearchStr = lSearchStr + " , ei.no AS 设备编号, en.name AS 设备名称,pl.pid";
            lSearchStr = lSearchStr + " ,(select sum(ISNULL(mpl.quantity2, mpl.quantity1)) from restructureAsphaltumProduceLog mpl where mpl.pid = pl.pid and CONVERT(varchar(10), mpl.produceDate, 120) = CONVERT(varchar(10), pl.produceDate, 120))AS 日生产量";
            lSearchStr = lSearchStr + " ,(select sum(ISNULL(mpl.quantity2, mpl.quantity1)) from restructureAsphaltumProduceLog mpl where mpl.pid = pl.pid and mpl.produceDate <= pl.produceDate ) as 累计生产量 ";
            lSearchStr = lSearchStr + "  FROM equipmentName AS en INNER  JOIN";
            lSearchStr = lSearchStr + "  equipmentInformation AS ei ON en.id = ei.enId INNER  JOIN";
            lSearchStr = lSearchStr + "  restructureAsphaltumProduceLog AS pl ON ei.id = pl.eiId INNER  JOIN";
            lSearchStr = lSearchStr + "  product AS p ON pl.pId2 = p.id INNER  JOIN";
            lSearchStr = lSearchStr + "  productName AS pn ON p.pnId = pn.id INNER  JOIN";
            lSearchStr = lSearchStr + "  productKind AS pk ON pn.pkId = pk.id INNER  JOIN";
            lSearchStr = lSearchStr + "  productModel AS pm ON p.pmId = pm.id ";
            lSearchStr = lSearchStr + " where 1=1 " + where;
            lSearchStr = lSearchStr + "  group by pl.produceDate,pk.sort, pn.name, pm.model,en.name,ei.no,pl.pid ";
            
            DataSet ds = helper.QueryForDateSet(lSearchStr);
            DayProduceCount oDayProduceCount = new DayProduceCount();
            oDayProduceCount.Source = ds;
            oDayProduceCount.CoName = name_value();
            oDayProduceCount.Number = "";
            oDayProduceCount.Tabler = "";
            oDayProduceCount.Charge = "";
            oDayProduceCount.Time = (DateTime.Now).ToString("yyyy-MM-dd");
            oDayProduceCount.ShowReport();
        }

    }

}
