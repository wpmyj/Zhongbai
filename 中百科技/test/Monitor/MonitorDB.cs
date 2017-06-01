/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：MonitorDB.CS
* 文件功能描述：数据监控数据库访问类
*
* 创建人： 杨林
* 创建时间：2009-4-15
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DasherStation.Monitor
{

    /// <summary>
    /// 数据库访问类
    /// </summary>
    public class LiQingGuanDB
    {
        /// <summary>
        /// 获取沥青罐当前数据
        /// </summary>
        /// <param name="dStart">开始日期</param>
        /// <param name="dEnd">结束日期</param>
        /// <param name="strNo">沥青罐编号</param>
        /// <returns></returns>
        public DataSet QueryData(DateTime? dStart, DateTime? dEnd, string strNo)
        {
            using (DasherStation.common.SqlHelper oData = new DasherStation.common.SqlHelper())
            {
                string strSQL = string.Format(@"
select 
a.pId as '产品标识',
a.mId as '材料标识',
a.eiId as '设备标识',
b.no as '沥青罐编号',
case 
	when a.pid is not null then g.name
	when a.mid is not null then f.name
end as '沥青名称',
case 
	when a.pid is not null then pm.model
	when a.mid is not null then mm.model
end as '规格型号',
b.diameter as '罐直径',
b.height as '罐子高度',
b.kind as '罐子样式',
c.value as '液位高度',
case 
	when a.pid is not null and e.density is null then 1
	when a.pid is not null and e.density is not null then cast(e.density as float)
	when a.mid is not null and d.density is null then 1
	when a.mid is not null and d.density is not null then cast(d.density as float)
end as '沥青密度', 
d.density as '材料密度',
e.density as '产品密度',
c.date as '日期',
0.0 as '存储数量'
from liquidMatterStockList a
inner join equipmentInformation b on a.eiid = b.id
inner join liquidPositionHistory c on a.lpnid = c.lpnid
left join material d on a.mid = d.id
left join materialName f on d.mnid = f.id
left join materialModel mm on d.mmid = mm.id
left join product e on a.pid = e.id
left join productName g on e.pnid = g.id
left join productModel pm on e.pmid=pm.id
join (select lpnid,max(date) as date from liquidPositionHistory group by lpnid) mmm on a.lpnid = mmm.lpnid and c.date = mmm.date
where 1=1
and c.date >= '{0}'  
and c.date <= '{1}'
and b.no = '{2}' 
", dStart.Value.ToString(), dEnd.Value.ToString(), strNo);
                return oData.QueryForDateSet(strSQL);
            }
        }

        /// <summary>
        /// 获取可用沥青罐编号
        /// </summary>
        /// <returns></returns>
        public DataSet QueryNo()
        {
            string strSQL = @"
select distinct b.id,b.no
from liquidMatterStockList a
inner join equipmentInformation b on a.eiid = b.id
inner join liquidPositionHistory c on a.lpnid = c.id
left join material d on a.mid = d.id
left join materialName f on d.mnid = f.id
left join materialModel mm on d.mmid = mm.id
left join product e on a.pid = e.id
left join productName g on e.pnid = g.id
left join productModel pm on e.pmid=pm.id
";
            using (DasherStation.common.SqlHelper oData = new DasherStation.common.SqlHelper())
            {
                return oData.QueryForDateSet(strSQL);
            }
        }
    }



    /// <summary>
    /// 沥青库存比对数据库访问类
    /// </summary>
    public class LiQingKuChunDB
    {
        /// <summary>
        /// 获取沥青罐当前库存数据
        /// </summary>
        /// <returns></returns>
        public DataSet QueryData()
        {
            using (DasherStation.common.SqlHelper oData = new DasherStation.common.SqlHelper())
            {
                string strSQL = @"
select 
a.pId as '产品标识',a.mId as '材料标识',a.eiId as '设备标识',
case 
	when a.pid is not null then pk.sort
	when a.mid is not null then mk.sort
end as '材料种类',
b.no as '沥青罐编号',
case 
	when a.pid is not null then g.name
	when a.mid is not null then f.name
end as '沥青名称',
case 
	when a.pid is not null then pm.model
	when a.mid is not null then mm.model
end as '规格型号',
b.diameter as '罐直径',b.height as '罐子高度',b.kind as '罐子样式',c.value as '液位高度',
case 
	when a.pid is not null and e.density is null then 1
	when a.pid is not null and e.density is not null then cast(e.density as float)
	when a.mid is not null and d.density is null then 1
	when a.mid is not null and d.density is not null then cast(d.density as float)
end as '沥青密度', d.density as '材料密度',e.density as '产品密度',
getDate() as '日期',
0.0 as '存储数量',
psl.suttle1 as '产品库存量',
msl.quantity1 as '材料库存量',
case 
	when a.pid is not null then psl.suttle1
	when a.mid is not null then msl.quantity1
end as '理论库存',
0.0 as '差额',
0.0 as '误差率'
from liquidMatterStockList a
join equipmentInformation b on a.eiid = b.id
left join liquidPositionHistory c on a.lpnid = c.lpnid
left join material d on a.mid = d.id
left join materialName f on d.mnid = f.id
left join materialModel mm on d.mmid = mm.id
left join product e on a.pid = e.id
left join productName g on e.pnid = g.id
left join productModel pm on e.pmid=pm.id
left join productStockList psl on a.pid = psl.pid
left join materialStockList msl on a.mid = msl.mid
left join productKind pk on g.pkid = pk.id
left join materialKind mk on f.mkid = mk.id
join (select lpnid,max(date) as date from liquidPositionHistory group by lpnid) mmm on a.lpnid = mmm.lpnid and c.date = mmm.date
";
                return oData.QueryForDateSet(strSQL);
            }
        }
    }


    /// <summary>
    /// 流量设置数据库访问类
    /// </summary>
    public class LLSettingDB
    {
        private string _strConn;

        public LLSettingDB()
        {
            using (DasherStation.common.SqlHelper h = new DasherStation.common.SqlHelper())
            {
                _strConn = h.SqlConn;
            }
        }

        /// <summary>
        /// 添加设置
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(FlowmeterNo entity)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                entity.inputDate = DateTime.Now;
                oContext.FlowmeterNo.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }




        /// <summary>
        /// 判断指定编号是否存在
        /// </summary>
        /// <param name="strNo">流量计编号</param>
        /// <returns></returns>
        public bool IsExistByNo(string strNo)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                var result = (from item in oContext.FlowmeterNo
                              where item.no.Trim() == strNo.Trim()
                              select item.id).Count();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 判断指定名称是否存在
        /// </summary>
        /// <param name="strName">流量计名称</param>
        /// <returns></returns>
        public bool IsExistByName(string strName)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                var result = (from item in oContext.FlowmeterNo
                              where item.name.Trim() == strName.Trim()
                              select item.id).Count();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int[] id)
        {
            MonitorDataContext oHumanContext = new MonitorDataContext(this._strConn);
            var deleting =
                from item in oHumanContext.FlowmeterNo
                where id.Contains((int)item.id)
                select item;

            foreach (var item in deleting)
            {
                try
                {
                    oHumanContext.FlowmeterNo.DeleteOnSubmit(item);
                    oHumanContext.SubmitChanges();
                }
                catch
                {
                }
            }


        }


        /// <summary>
        /// 获取流量计数据集
        /// </summary>
        /// <returns></returns>
        public List<FlowmeterNo> QueryAll()
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                var result = from item in oContext.FlowmeterNo
                             select item;
                return result.ToList();
            }
        }
    }

    /// <summary>
    /// 汽车衡数据与流量数据比对数据库访问类
    /// </summary>
    public class QCAndLLDB
    {
        
        /// <summary>
        /// 获取汽车衡数据与流量数据对比数据集
        /// </summary>
        /// <param name="dStart">开始日期</param>
        /// <param name="dEnd">结束日期</param>
        /// <param name="strNameID">材料名称标识</param>
        /// <param name="strModelID">规格型号标识</param>
        /// <returns></returns>
        public DataSet Query(DateTime? dStart, DateTime? dEnd, string strNameID, string strModelID)
        {
            using (DasherStation.common.SqlHelper oData = new DasherStation.common.SqlHelper())
            {
                if (strNameID != null && strNameID != "")
                {
                    strNameID = "and e.id = " + strNameID;
                }
                if (strModelID != null && strModelID != "")
                {
                    strModelID = "and f.id= " + strModelID;
                }
                string strSQL = string.Format(@"
select 
a.inputdate as 日期,
b.no as 车牌号码,
e.name as 沥青名称,
f.model as 规格型号,
a.suttle as 称重数量,
a.flowmetervalue 流量数量,
a.flowmetervalue - a.suttle as 差异量,
(a.flowmetervalue - a.suttle)/a.suttle as 误差率
from stockNote a
left join voitureInfo b on a.viid = b.id
left join indent c on a.iid = c.id
left join material d on c.mid = d.id
left join materialName e on d.mnid = e.id
left join materialModel f on d.mmid = f.id
where a.flowmetervalue is not null 
and a.inputDate >= '{0}' 
and a.inputDate <= '{1}' 
{2} 
{3} 
", dStart.Value.ToString(), dEnd.Value.ToString(), strNameID, strModelID);
                return oData.QueryForDateSet(strSQL);
            }
        }

        /// <summary>
        /// 获取可用材料名称
        /// </summary>
        /// <returns></returns>
        public DataSet QueryMaterialName()
        {
            string strSQL = @"
select distinct
e.id,e.name
from stockNote a
left join voitureInfo b on a.viid = b.id
left join indent c on a.iid = c.id
left join material d on c.mid = d.id
left join materialName e on d.mnid = e.id
where a.flowmetervalue is not null
";
            using (DasherStation.common.SqlHelper oData = new DasherStation.common.SqlHelper())
            {
                return oData.QueryForDateSet(strSQL);
            }
        }
    }

    /// <summary>
    /// 温度设置数据库访问类
    /// </summary>
    public class WDSettingDB
    {
        private string _strConn;

        public WDSettingDB()
        {
            using (DasherStation.common.SqlHelper h = new DasherStation.common.SqlHelper())
            {
                _strConn = h.SqlConn;
            }
        }

        /// <summary>
        /// 插入温度计信息
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TemperatureNo entity)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                entity.inputDate = DateTime.Now;
                oContext.TemperatureNo.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 更新温度计信息
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TemperatureNo entity)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                var _entity = (from item in oContext.TemperatureNo
                               where entity.id == item.id
                               select item).FirstOrDefault();
                _entity.name = entity.name;
                _entity.minTemperature = entity.minTemperature;
                _entity.maxTemperature = entity.maxTemperature;
                _entity.position = entity.position;
                _entity.remark = entity.remark;
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 获取指定标识的温度计信息
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns></returns>
        public TemperatureNo QueryByID(long id)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                var result = from item in oContext.TemperatureNo
                             where item.id == id
                             select item;
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// 判断指定编号是否存在
        /// </summary>
        /// <param name="strNo">温度计编号</param>
        /// <returns></returns>
        public bool IsExistByNo(string strNo)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                var result = (from item in oContext.TemperatureNo
                              where item.no.Trim() == strNo.Trim()
                              select item.id).Count();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 判断指定名称是否存在
        /// </summary>
        /// <param name="strName">温度计名称</param>
        /// <returns></returns>
        public bool IsExistByName(string strName)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                var result = (from item in oContext.TemperatureNo
                              where item.name.Trim() == strName.Trim()
                              select item.id).Count();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int[] id)
        {
            MonitorDataContext oHumanContext = new MonitorDataContext(this._strConn);
            var deleting =
                from item in oHumanContext.TemperatureNo
                where id.Contains((int)item.id)
                select item;

            foreach (var item in deleting)
            {
                try
                {
                    oHumanContext.TemperatureNo.DeleteOnSubmit(item);
                    oHumanContext.SubmitChanges();
                }
                catch
                {
                }
            }


        }


        /// <summary>
        /// 查询温度计数据集
        /// </summary>
        /// <returns></returns>
        public List<TemperatureNo> QueryAll()
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                var result = from item in oContext.TemperatureNo
                             select item;
                return result.ToList();
            }
        }
    }



    /// <summary>
    /// 液位设置数据库访问类
    /// </summary>
    public class YWSettingDB
    {
        private string _strConn;

        public YWSettingDB()
        {
            using (DasherStation.common.SqlHelper h = new DasherStation.common.SqlHelper())
            {
                _strConn = h.SqlConn;
            }
        }

        /// <summary>
        /// 插入液位仪信息
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(LiquidPositionNo entity)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                entity.inputDate = DateTime.Now;
                oContext.LiquidPositionNo.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 更新液位仪信息
        /// </summary>
        /// <param name="entity"></param>
        public void Update(LiquidPositionNo entity)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                var _entity = (from item in oContext.LiquidPositionNo
                               where entity.id == item.id
                               select item).FirstOrDefault();
                _entity.name = entity.name;
                _entity.minValue = entity.minValue;
                _entity.maxValue = entity.maxValue;
                _entity.position = entity.position;
                _entity.remark = entity.remark;
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 获取指定标识的液位仪信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LiquidPositionNo QueryByID(long id)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                return (from item in oContext.LiquidPositionNo where item.id == id select item).FirstOrDefault();
            }
        }


        /// <summary>
        /// 判断指定编号是否存在
        /// </summary>
        /// <param name="strNo">液位仪编号</param>
        /// <returns></returns>
        public bool IsExistByNo(string strNo)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                var result = (from item in oContext.LiquidPositionNo
                              where item.no.Trim() == strNo.Trim()
                              select item.id).Count();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 判断指定名称是否存在
        /// </summary>
        /// <param name="strName">液位仪名称</param>
        /// <returns></returns>
        public bool IsExistByName(string strName)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                var result = (from item in oContext.LiquidPositionNo
                              where item.name.Trim() == strName.Trim()
                              select item.id).Count();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int[] id)
        {
            MonitorDataContext oHumanContext = new MonitorDataContext(this._strConn);
            var deleting =
                from item in oHumanContext.LiquidPositionNo
                where id.Contains((int)item.id)
                select item;

            foreach (var item in deleting)
            {
                try
                {
                    oHumanContext.LiquidPositionNo.DeleteOnSubmit(item);
                    oHumanContext.SubmitChanges();
                }
                catch
                {
                }
            }


        }


        /// <summary>
        /// 获取全部液位仪信息
        /// </summary>
        /// <returns></returns>
        public List<LiquidPositionNo> QueryAll()
        {
            using (MonitorDataContext oContext = new MonitorDataContext(this._strConn))
            {
                var result = from item in oContext.LiquidPositionNo
                             select item;
                return result.ToList();
            }
        }
    }
}
