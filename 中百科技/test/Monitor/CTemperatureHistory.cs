/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：CTemperatureHistory.cs
* 文件功能描述：画温度曲线帮助类
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

namespace DasherStation.Monitor
{
    /// <summary>
    /// 温度历史类
    /// </summary>
    public class CTemperatureHistory
    {
        /// <summary>
        /// 温度最大值
        /// </summary>
        public double MaxValue;

        /// <summary>
        /// 温度最小值
        /// </summary>
        public double MinValue;

        /// <summary>
        /// 温度值数组
        /// </summary>
        public Point[] Points
        {
            set;
            get;
        }
    }

    /// <summary>
    /// 温度值类
    /// </summary>
    public class Point
    {
        public DateTime X
        {
            set;
            get;
        }

        public double Y
        {
            get;
            set;
        }
    }
}
