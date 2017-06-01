using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DasherStation.DataProcessingService.DataAccess;
using DataProcessing.Util;

namespace DataProcessing.Model
{
    /// <summary>
    /// 处理流量信息
    /// </summary>
    public class LLProcess : IDataRecive
    {
        public void Receive(object sender, DataProcessing.Util.DataNotifyEventArgs args)
        {   
            // 取字符串第一位标识,来判断是否属于流量的操作;
            if (args.Value.Substring(0, 1).Equals("C"))
            {
                var db = new DataProcessingDB(args.ConnectionString);
                // 取字符串第一二位标识,获得该流量ID;
                long numberId = db.QueryFlowmeterIDByNo(args.Value.Substring(0, 2));
                // 取出上次流量计的值;
                decimal old_value = db.QueryLastFlowmeterHistoryValue(numberId);
                // 取字符串长度;
                int length = args.Value.Length;
                // 取表示累计值开始的位置;
                int location = args.Value.IndexOf("L") + 1;
                // 获得流量累计数据;
                string str = args.Value.Substring(location, length - location);
                // 计算出本次和上次的差值;
                decimal _value = 0;
                if (decimal.Parse(str) < old_value  )
                {
                    _value = decimal.Parse(str);
                }
                else
                {
                    _value = decimal.Parse(str) - old_value;
                }
                
                // 将流量累计值存入数据库中;
               db.InsertFlowmeterHistory(new FlowmeterHistory() 
               { 
                   fnId = numberId,
                   value = decimal.Parse(str),
                   value2 = _value 
               });
            }
        }
    }
}
