using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DasherStation;
using DaxherStation;
using DasherStation.sell;
using DasherStation.common;

namespace DasherStation
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //System.Threading.ThreadExceptionEventHandler errHandler = delegate(object sender, System.Threading.ThreadExceptionEventArgs e)
            //{
            //    new Logging().LogWrite(new LogEntry(){ID=0, LogEx = e.Exception, LogMessage = e.Exception.Message + " : " + e.Exception.StackTrace});
            //    MessageBox.Show("发生未知错误,请重新操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //};
            //UnhandledExceptionEventHandler errOthersThreadHandler = delegate(object sender, UnhandledExceptionEventArgs e)
            //{
            //    new Logging().LogWrite(new LogEntry(){ID=0, LogEx = e.ExceptionObject as Exception, LogMessage = e.ToString()});
            //};

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.ThreadException += errHandler;
            //AppDomain.CurrentDomain.UnhandledException += errOthersThreadHandler;
            
            Application.Run(new Login());

            ////清除异常资源,防止内存漏洞
            //Application.ThreadException -= errHandler;
            //AppDomain.CurrentDomain.UnhandledException -= errOthersThreadHandler;
        }
    }
}
