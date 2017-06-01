using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DasherStation.DataProcessingService.DataAccess;
using DataProcessing.Util;

namespace DataProcessing.Model
{


    /// <summary>
    /// 处理煤称重信息
    /// </summary>
    public class MCZProcess : IDataRecive
    {
        public void Receive(object sender, DataNotifyEventArgs args)
        {            
            // 取字符串第一位标识,来判断是否属于煤称重的操作;
            if (args.Value.Substring(0, 1).Equals("M"))
            {
                var db = new DataProcessingDB(args.ConnectionString);
                var entity = db.QueryEquipmentIDByNo("M");
                // 查询热油炉ID;
                long numberId = entity.id;

                // 获得煤称重数据;
                int i = args.Value.IndexOf("C");
                string str = args.Value.Remove(0, i+1);
                // 获得上次煤称重数据; 
                decimal old_value = db.QueryLastDeepFat(numberId);

                // 注当数据大于99999.9公斤后,数据被清零;
                decimal new_old = 0;
                if (decimal.Parse(str) < old_value)
                {
                    new_old = 100000 - old_value + decimal.Parse(str);
                }
                else
                {
                    new_old = decimal.Parse(str) - old_value;
                }

                // 将煤称重数据存入数据库中;
                db.InsertDeepFatDetail(new DeepFatConsumeDailyStatisticsDetail()
                {
                    eiId = numberId
                    ,fuelWastage = decimal.Parse(str)
                    ,value = new_old
                });
            }
        }
    }
}
