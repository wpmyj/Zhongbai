using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Net.Sockets;
using System.Net;
using DataProcessing.Util;
using System.Reflection;

namespace DasherStation.DataProcessingService
{

    /// <summary>
    /// 数据采集服务程序类
    /// </summary>
    public partial class DataService : ServiceBase
    {
        public DataService()
        {
            InitializeComponent();            
        }        

        /// <summary>
        /// 服务程序启动函数
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            //System.Windows.Forms.MessageBox.Show("数据采集服务程序已启动!", "提示信息",
            //     System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information,
            //      System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.ServiceNotification, false);
            //实例化UDP监控服务类
            CDataObserver server = new CDataObserver();
            //获取配置文件中DataProcesser.Config设置的UDP数据接收类方法
            foreach(var item in this.GetDataProcessers())
            {
                server.NotifyEventHandler += item.Receive;
            }           
            //启动线程监控UDP端口
            var listener = new System.Threading.Thread(server.Start);
            listener.IsBackground = true;
            listener.Start();            
        }

        /// <summary>
        /// 获取配置文件中的数据处理类
        /// </summary>
        /// <returns></returns>
        private IDataRecive[] GetDataProcessers()
        {
            List<IDataRecive> _list = new List<IDataRecive>();
            System.Xml.XmlDocument oXml = new System.Xml.XmlDocument();
            oXml.Load(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\" + "DataProcesser.config");
            System.Xml.XmlNodeList oAssemblyList = oXml.SelectNodes("//assembly");
            for (int k = 0; k < oAssemblyList.Count; k++)
            {
                System.Xml.XmlNodeList oClassList = oAssemblyList[k].SelectNodes("//class");
                System.Reflection.Assembly oCurrentAssembly = null;
                try
                {
                    oCurrentAssembly = System.Reflection.Assembly.LoadFile(
                        AppDomain.CurrentDomain.SetupInformation.ApplicationBase +"\\"
                        + oAssemblyList[k].Attributes["filename"].InnerText);
                }
                catch (System.IO.FileNotFoundException)
                {                    
                }
                if (oCurrentAssembly == null)
                {
                    continue;
                }
                string strTypeName = null;
                for (int i = 0; i < oClassList.Count; i++)
                {
                    strTypeName = oClassList[i].Attributes["type"].InnerText;
                    System.Type oType = oCurrentAssembly.GetType(strTypeName);
                    if (oType == null )
                    {
                        //throw new NullReferenceException("指定类型不存在:" + strTypeName);
                        continue;
                    }
                    var type = oType.GetInterface(typeof(IDataRecive).Name);
                    if (type != null)
                    {
                        try
                        {
                            var interfaceProcess = (IDataRecive)oCurrentAssembly.CreateInstance(oType.FullName);
                            _list.Add(interfaceProcess);
                        }
                        catch
                        {
                        }
                    }                    
                }
            }
            return _list.ToArray();
        }
    }

    /// <summary>
    /// UDP数据接收监控类
    /// </summary>
    public class CDataObserver
    {        
        //接收到数据时触发的事件委托
        public event EventHandler<DataNotifyEventArgs> NotifyEventHandler;

        /// <summary>
        /// 监控启动函数
        /// </summary>
        public void Start()
        {
            UdpClient listener = null;
            try
            {
                int iPort = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["ListenPorts"]);
                listener = new UdpClient(iPort);
                while (true)
                {
                    IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, iPort);

                    //Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);
                    //Console.WriteLine("Received broadcast from {0} :\n {1}\n",
                    //    groupEP.ToString(),
                    //    Encoding.ASCII.GetString(bytes, 0, bytes.Length));


                    string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["DasherStationSqlConn"].ConnectionString;
                    this.OnDataRecived(new DataNotifyEventArgs()
                    {
                        Value = Encoding.ASCII.GetString(bytes),
                        ConnectionString = strConn
                    });
                    System.Threading.Thread.Sleep(2000);
                }
            }
            catch
            {
            }
            finally
            {
                if (listener != null)
                {
                    listener.Close();
                }
            }
        }

        /// <summary>
        /// 触发事件函数
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnDataRecived(DataNotifyEventArgs args)
        {            
            var delegateHandles = NotifyEventHandler.GetInvocationList();
            foreach (Delegate item in delegateHandles)
            {
                try
                {
                    item.DynamicInvoke(this, args);                    
                }
                catch
                {
                }
            }
        }
    }
}
