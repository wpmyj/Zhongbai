using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataProcessing.Util;
using DasherStation.DataProcessingService.DataAccess;

namespace DataProcessing.Model
{
    /// <summary>
    /// 处理液位信息
    /// </summary>
    public class YW : IDataRecive
    {
        public void Receive(object sender, DataNotifyEventArgs args)
        {            
            // 取字符串第一位标识,来判断是否属于液位仪的操作;
            if (args.Value.Substring(0,1) .Equals("Y"))
            {
                var db = new DataProcessingDB(args.ConnectionString);
                // 取字符串第一二位标识,获得该液位仪ID;
                long numberId = db.QueryLiquidPositionIDByNo(args.Value.Substring(0,2));
                // 取字符串长度;
                int length = args.Value.Length;
                // 获得液位数据;
                string str= args.Value.Substring(2,length -2);
                // 将液位累计值存入数据库中;
                db.InsertPositionHistory(new LiquidPositionHistory() { lpnId = numberId, value = decimal.Parse(str) });
            }
        }
    }
}
