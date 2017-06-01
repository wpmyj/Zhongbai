using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataProcessing.Util;

namespace DataProcessing.Util
{
    /// <summary>
    /// UDP接收类必须实现的接口
    /// </summary>
    public interface IDataRecive
    {
        /// <summary>
        /// UDP接收类必须实现的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void Receive(object sender, DataNotifyEventArgs args);
    }      
}
