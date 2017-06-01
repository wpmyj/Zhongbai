using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataProcessing.Util;

namespace DasherStation.DataProcessingService.DataAccess
{
    /// <summary>
    /// 数据采集服务数据库访问类
    /// </summary>
    public class DataProcessingDB
    {
        private string _strConn;

        /// <summary>
        /// 构造体
        /// </summary>
        /// <param name="strConn">数据库链接串</param>
        public DataProcessingDB(string strConn)
        {
            _strConn = strConn;
        }

        /// <summary>
        /// 插入生产计量监控
        /// </summary>
        /// <param name="entity"></param>
        public void InsertProduceMeasure(ProduceMeasureMonitor entity)
        {
            using (ProcessingTableDataContext oContext = new ProcessingTableDataContext(this._strConn))
            {                
                //entity.inputDate = DateTime.Now;
                entity.inputMan = "services";
                oContext.ProduceMeasureMonitor.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 插入执油炉能源消耗日报明细
        /// </summary>
        /// <param name="entity"></param>
        public void InsertDeepFatDetail(DeepFatConsumeDailyStatisticsDetail entity)
        {
            using (ProcessingTableDataContext oContext = new ProcessingTableDataContext(this._strConn))
            {                
                entity.inputDate = DateTime.Now;
                entity.inputMan = "services";
                oContext.DeepFatConsumeDailyStatisticsDetail.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 插入温度历史记录
        /// </summary>
        /// <param name="entity"></param>
        public void InsertTemperatureHistory(TemperatureHistory entity)
        {
            using (ProcessingTableDataContext oContext = new ProcessingTableDataContext(this._strConn))
            {
                entity.date = DateTime.Now;
                entity.inputDate = DateTime.Now;                
                entity.inputMan = "services";
                oContext.TemperatureHistory.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 插入液位仪历史记录
        /// </summary>
        /// <param name="entity"></param>
        public void InsertPositionHistory(LiquidPositionHistory entity)
        {
            using (ProcessingTableDataContext oContext = new ProcessingTableDataContext(this._strConn))
            {
                entity.date = DateTime.Now;
                entity.inputDate = DateTime.Now;
                entity.inputMan = "services";
                oContext.LiquidPositionHistory.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 插入流量计历史记录
        /// </summary>
        /// <param name="entity"></param>
        public void InsertFlowmeterHistory(FlowmeterHistory entity)
        {
            using (ProcessingTableDataContext oContext = new ProcessingTableDataContext(this._strConn))
            {
                entity.date = DateTime.Now;
                entity.inputDate = DateTime.Now;
                entity.inputMan = "services";
                oContext.FlowmeterHistory.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 插入乳化沥青采集记录
        /// </summary>
        /// <param name="entity"></param>
        public void InsertEmulGatherProduceLog(EmulsificationGatherProduceLog entity)
        {
            using (ProcessingTableDataContext oContext = new ProcessingTableDataContext(this._strConn))
            {                
                //entity.inputDate = DateTime.Now;                
                oContext.EmulsificationGatherProduceLog.InsertOnSubmit(entity);
                oContext.SubmitChanges();
            }
        }

        /// <summary>
        /// 查询设备信息
        /// </summary>
        /// <param name="strNo">设备编号</param>
        /// <returns></returns>
        public EquipmentInformation QueryEquipmentIDByNo(string strNo)
        {
            using (ProcessingTableDataContext oContext = new ProcessingTableDataContext(this._strConn))
            {
                var result = (from item in oContext.EquipmentInformation
                              where item.mark == strNo
                              select item).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// 查询温度计信息
        /// </summary>
        /// <param name="strNo">温度计编号</param>
        /// <returns></returns>
        public TemperatureNo QueryTemperatureIDByNo(string strNo)
        {
            using (ProcessingTableDataContext oContext = new ProcessingTableDataContext(this._strConn))
            {
                var result = (from item in oContext.TemperatureNo
                              where item.no == strNo
                              select item).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// 查询液位仪标识
        /// </summary>
        /// <param name="strNo">液位仪编号</param>
        /// <returns></returns>
        public long QueryLiquidPositionIDByNo(string strNo)
        {
            using (ProcessingTableDataContext oContext = new ProcessingTableDataContext(this._strConn))
            {
                var result = (from item in oContext.LiquidPositionNo
                              where item.no == strNo
                              select item.id).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// 查询流量计标识
        /// </summary>
        /// <param name="strNo">流量计编号</param>
        /// <returns></returns>
        public long QueryFlowmeterIDByNo(string strNo)
        {
            using (ProcessingTableDataContext oContext = new ProcessingTableDataContext(this._strConn))
            {
                var result = (from item in oContext.FlowmeterNo
                              where item.no == strNo
                              select item.id).FirstOrDefault();
                return result;
            }
        }


        /// <summary>
        /// 获取最后的流量历史值
        /// </summary>
        /// <param name="fnid">流量计标识</param>
        /// <returns></returns>
        public decimal QueryLastFlowmeterHistoryValue(long fnid)
        {
            using (ProcessingTableDataContext oContext = new ProcessingTableDataContext(this._strConn))
            {
                var result = (from item in oContext.FlowmeterHistory
                              where item.fnId == fnid && item.inputDate == ((from _item in oContext.FlowmeterHistory
                              where _item.fnId == fnid 
                              select _item).Max(p => p.inputDate))
                              select item);
                return result.FirstOrDefault().value.Value;
            }
        }

        /// <summary>
        /// 获取最后的燃油炉重量值
        /// </summary>
        /// <param name="eiid">设备标识</param>
        /// <returns></returns>
        public decimal QueryLastDeepFat(long eiid)
        {
            using (ProcessingTableDataContext oContext = new ProcessingTableDataContext(this._strConn))
            {
                var result = (from item in oContext.DeepFatConsumeDailyStatisticsDetail
                              where item.eiId == eiid && item.inputDate == ((from _item in oContext.DeepFatConsumeDailyStatisticsDetail
                                                                             where _item.eiId == eiid
                                                                             select _item).Max(p => p.inputDate))
                              select item);
                
                //var r = from item in oContext.DeepFatConsumeDailyStatisticsDetail
                //        group item by item.eiId into g1                        
                //        select g1.Where(p => p.eiId == eiid && p.inputDate == g1.Max(q=>q.inputDate)).Single();

                return result.FirstOrDefault().fuelWastage.Value;
            }
        }
    }
}
