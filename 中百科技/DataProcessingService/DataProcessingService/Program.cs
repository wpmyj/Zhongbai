using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;


namespace DasherStation.DataProcessingService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            //CDataObserver O = new CDataObserver();
            //O.NotifyEventHandler += new DataProcessing.Model.WD().Receive;
            //O.NotifyEventHandler += new DataProcessing.Model.YW().Receive;
            //O.Start();
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new DataService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
