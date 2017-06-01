using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProcessing.Util
{
    /// <summary>
    /// 接收到UDP数据触发事件的参数类
    /// </summary>
    public class DataNotifyEventArgs : EventArgs
    {
        /// <summary>
        /// 接收到的UDP值
        /// </summary>
        public string Value
        {
            set;
            get;
        }

        /// <summary>
        /// 数据库链接串,具体实现类需要此链接进行数据库操作
        /// </summary>
        public string ConnectionString
        {
            set;
            get;
        }
    }
}
