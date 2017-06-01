using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DasherStation.DataProcessingService.DataAccess;
using DataProcessing.Util;

namespace DataProcessing.Model
{

    /// <summary>
    /// 处理拌合机信息
    /// </summary>
    public class BJProcess : IDataRecive
    {
        public void Receive(object sender, DataNotifyEventArgs args)
        {     
            // 取字符串第一位标识,来判断是否属于流量的操作;
            if ((args.Value.Substring(0, 1).Equals("s")) || (args.Value.Substring(0, 1).Equals("a")))
            {
                var db = new DataProcessingDB(args.ConnectionString);
                string estate = args.Value.Substring(0, 1);
                var entity = db.QueryEquipmentIDByNo(estate);

                ProduceMeasureMonitor pmm = new ProduceMeasureMonitor();
                 pmm.eiId = Convert.ToInt64(entity.id);  
  
                string _string = args.Value.Remove(0,1);
                // 以‘，’将字符串分割成数据；
                string[] value = _string.Split(',');

                for (int i = 0; i < value.Length; i++)
                {
                    string state = value[i].Substring(0, 2);
                    string _value = value[i].Substring(2, value[i].Length - 2);

                    #region switch(state)判断是什么材料
                    switch (state)
                    {
                        case "S1":
                            {
                                // 石料1；
                                pmm.realMaterialWeight1 = Convert.ToDouble(_value);
                                break;
                            }
                        case "S2":
                            {
                                // 石料2；
                                pmm.realMaterialWeight2 = Convert.ToDouble(_value);
                                break;
                            }
                        case "S3":
                            {
                                // 石料3；
                                pmm.realMaterialWeight3 = Convert.ToDouble(_value);
                                break;
                            }
                        case "S4":
                            {
                                // 石料4；
                                pmm.realMaterialWeight4 = Convert.ToDouble(_value);
                                break;
                            }
                        case "S5":
                            {
                                // 石料5；
                                pmm.realMaterialWeight5 = Convert.ToDouble(_value);
                                break;
                            }
                        case "S6":
                            {
                                // 石料6；
                                pmm.realMaterialWeight6 = Convert.ToDouble(_value);
                                break;
                            }
                        case "F1":
                            {
                                // 矿粉；
                                pmm.blockWeight = Convert.ToDouble(_value);
                                break;
                            }
                        case "L1":
                            {
                                // 沥青；
                                pmm.asphaltumWeight = Convert.ToDouble(_value);
                                break;
                            }
                        case "G1":
                            {
                                // 混合料量；
                                pmm.sumWeight = decimal.Parse(_value);
                                break;
                            }
                        case "T1":
                            {
                                // 温度；
                                pmm.temperature = decimal.Parse(_value);
                                break;
                            }
                        case "DT":
                            {
                                // 日期；
                                pmm.inputDate = Convert.ToDateTime(_value);
                                break;
                            }
                    }

                    #endregion
                }
                db.InsertProduceMeasure(pmm);
            }
        }
    }
}
