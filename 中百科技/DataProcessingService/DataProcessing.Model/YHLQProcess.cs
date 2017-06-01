using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DasherStation.DataProcessingService.DataAccess;
using DataProcessing.Util;

namespace DataProcessing.Model
{

    /// <summary>
    /// 处理乳化沥青信息
    /// </summary>
    public class YHLQProcess : IDataRecive
    {
        public void Receive(object sender, DataNotifyEventArgs args)
        {
            
            // 取字符串第一位标识,来判断是否属于乳化沥青的操作;
            if (args.Value.Substring(0, 1).Equals("r"))
            {
                var db = new DataProcessingDB(args.ConnectionString);
                var egp = new EmulsificationGatherProduceLog();

                var entity = db.QueryEquipmentIDByNo("r");
                // 查询乳化沥青机ID;
                egp.eiId = entity.id;
                // 获得乳化沥青机数据;
                string str = args.Value.Remove(0, 1);
                // 将乳化沥青机值存入数据库中;
                egp.quantity = decimal.Parse(str.Substring(0, str.IndexOf(",")));
                str = str.Remove(0, str.IndexOf(",") + 1);
                egp.asphaltumConsume = decimal.Parse(str.Substring(0, str.IndexOf(",")));
                str = str.Remove(0, str.IndexOf(",") + 1);
                egp.inputDate = Convert.ToDateTime (str.Substring(0, str.Length));
                db.InsertEmulGatherProduceLog(egp);
            }
        }
    }

}
