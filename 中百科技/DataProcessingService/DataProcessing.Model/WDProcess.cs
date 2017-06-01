using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataProcessing.Util;
using DasherStation.DataProcessingService.DataAccess;

namespace DataProcessing.Model
{
    public class WD : IDataRecive
    {

        #region IDataRecive 成员

        void IDataRecive.Receive(object sender, DataNotifyEventArgs args)
        {
            
            // 取字符串第一位标识,来判断是否属于温度计的操作;
            if (args.Value.Substring(0, 1).Equals("W"))
            {
                var db = new DataProcessingDB(args.ConnectionString);
                // 取字符串第一二位标识,获得该温度计ID,温度计的上、下限值;
                var temperature = db.QueryTemperatureIDByNo(args.Value.Substring(0, 2));
                long numberId = temperature.id;
                var _min = temperature.minTemperature;
                var _max = temperature.maxTemperature;
                // 取字符串长度;
                int length = args.Value.Length;
                // 获得温度数据;
                string str = args.Value.Substring(2, length - 2);
                // 将温度值存入数据库中;
                db.InsertTemperatureHistory(new TemperatureHistory()
                {
                    tId = numberId,
                    value = decimal.Parse(str),
                    maxTemperature = _max,
                    minTemperature = _min
                });
            }
        }

        #endregion
    }

}
