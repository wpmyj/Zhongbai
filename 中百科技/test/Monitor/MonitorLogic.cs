/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：MonitorLogic.cs
* 文件功能描述：数据监控业务类
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
    /// 沥青罐储存记录逻辑类
    /// </summary>
    public class LiQingGuanLogic
    {
        /// <summary>
        /// 获取沥青罐数据
        /// </summary>
        /// <param name="dStart">起始日期</param>
        /// <param name="dEnd">结束日期</param>
        /// <param name="strNo">沥青罐编号</param>
        /// <returns></returns>
        public DataSet GetData(DateTime? dStart, DateTime? dEnd, string strNo)
        {
            return new LiQingGuanDB().QueryData(dStart, dEnd, strNo);
        }

        /// <summary>
        /// 获取全部可用沥青罐编号
        /// </summary>
        /// <returns></returns>
        public DataSet GetNo()
        {
            return new LiQingGuanDB().QueryNo();
        }
    }

    /// <summary>
    /// 沥青库存比对逻辑类
    /// </summary>
    public class LiQingKuChunLogic
    {
        /// <summary>
        /// 获取沥青罐库存数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            return new LiQingKuChunDB().QueryData();
        }
    }

    /// <summary>
    /// 流量设置逻辑类
    /// </summary>
    public class LLSettingLogic
    {
        private LLSettingDB oData = new LLSettingDB();

        /// <summary>
        /// 添加流量计设置
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string Add(FlowmeterNo entity)
        {
            if (oData.IsExistByNo(entity.no))
            {
                return "编号已经存在!";
            }
            if (oData.IsExistByName(entity.name))
            {
                return "名称已经存在!";
            }
            oData.Insert(entity);
            return null;
        }

        /// <summary>
        /// 更新流量计设置
        /// </summary>
        /// <param name="entity"></param>
        public void Update(FlowmeterNo entity)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(new DasherStation.common.SqlHelper().SqlConn))
            {
                var _entity = (from item in oContext.FlowmeterNo
                               where entity.id == item.id
                               select item).FirstOrDefault();
                _entity.name = entity.name;                
                _entity.position = entity.position;
                _entity.remark = entity.remark;
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 获取指定标识的流量计信息
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns></returns>
        public FlowmeterNo QueryByID(long id)
        {
            using (MonitorDataContext oContext = new MonitorDataContext(new DasherStation.common.SqlHelper().SqlConn))
            {
                var result = from item in oContext.FlowmeterNo
                             where item.id == id
                             select item;
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// 删除设置
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int[] id)
        {
            oData.Delete(id);
        }

        /// <summary>
        /// 获取流量计数据集
        /// </summary>
        /// <returns></returns>
        public List<FlowmeterNo> GetAll()
        {
            return oData.QueryAll();
        }
    }

    /// <summary>
    /// 汽车衡数据与流量数据比对逻辑类
    /// </summary>
    public class QCAndLLogic
    {
        /// <summary>
        /// 获取汽车衡数据与流量数据对比数据集
        /// </summary>
        /// <param name="dStart">开始日期</param>
        /// <param name="dEnd">结束日期</param>
        /// <param name="strNameID">材料名称标识</param>
        /// <param name="strModelID">规格型号标识</param>
        /// <returns></returns>
        public DataSet GetData(DateTime? dStart, DateTime? dEnd, string strNameID, string strModelID)
        {
            return new QCAndLLDB().Query(dStart, dEnd, strNameID, strModelID);
        }

        /// <summary>
        /// 获取全部可用的材料名称
        /// </summary>
        /// <returns></returns>
        public DataSet GetMaterialName()
        {
            return new QCAndLLDB().QueryMaterialName();
        }
    }

    /// <summary>
    /// 温度设置逻辑类
    /// </summary>
    public class WDSettingLogic
    {
        private WDSettingDB oData = new WDSettingDB();

        /// <summary>
        /// 增加温度设置
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string Add(TemperatureNo entity)
        {
            if (oData.IsExistByNo(entity.no))
            {
                return "编号已经存在!";
            }
            if (oData.IsExistByName(entity.name))
            {
                return "名称已经存在!";
            }
            oData.Insert(entity);
            return null;
        }

        /// <summary>
        /// 修改温度设置
        /// </summary>
        /// <param name="entity"></param>
        public void Edit(TemperatureNo entity)
        {
            oData.Update(entity);
        }

        /// <summary>
        /// 获取指定标识的温度计信息
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns></returns>
        public TemperatureNo GetByID(long id)
        {
            return oData.QueryByID(id);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int[] id)
        {
            oData.Delete(id);
        }

        /// <summary>
        /// 获取全部温度计数据
        /// </summary>
        /// <returns></returns>
        public List<TemperatureNo> GetAll()
        {
            return oData.QueryAll();
        }
    }

    /// <summary>
    /// 液位设置逻辑类
    /// </summary>
    public class YWSettingLogic
    {
        private YWSettingDB oData = new YWSettingDB();

        /// <summary>
        /// 增加液位设置
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string Add(LiquidPositionNo entity)
        {
            if (oData.IsExistByNo(entity.no))
            {
                return "编号已经存在!";
            }
            if (oData.IsExistByName(entity.name))
            {
                return "名称已经存在!";
            }
            oData.Insert(entity);
            return null;
        }

        /// <summary>
        /// 编辑液位设置
        /// </summary>
        /// <param name="entity"></param>
        public void Edit(LiquidPositionNo entity)
        {
            oData.Update(entity);
        }

        /// <summary>
        /// 获取指定标识液位仪信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LiquidPositionNo GetByID(long id)
        {
            return oData.QueryByID(id);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int[] id)
        {
            oData.Delete(id);
        }

        /// <summary>
        /// 获取全部液位仪信息
        /// </summary>
        /// <returns></returns>
        public List<LiquidPositionNo> GetAll()
        {
            return oData.QueryAll();
        }
    }
}
