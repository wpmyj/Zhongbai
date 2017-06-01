/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：Logging.cs
 * 文件功能描述：验证文本框输入的信息
 *
 * 创建人：金鹤 
 * 创建时间：20090211
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
using System.IO;
using System.Diagnostics;


namespace DasherStation.common
{
    /// <summary>
    /// 日志属性类
    /// </summary>
    public class LogEntry
    {

        //异常编号
        private int id;
        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }

        //异常类实例
        private Exception logEx;
        public Exception LogEx
        {
            get { return logEx; }
            set { this.logEx = value; }
        }

        //异常描述
        private string logMessage;
        public string LogMessage
        {
            get { return logMessage; }
            set { this.logMessage = value; }
        }

    }//class LogEntry

    /// <summary>
    /// 日志的操作类
    /// </summary>
    public class Logging
    {

        //日志文件保存地址
        string path = "c:/DasherStationLog/DasherStationLog.txt";


        public Logging()
        {
        }

        public Logging(int id, Exception logEx, string logMessage)
        {
            try
            {
                LogEntry logEntry = new LogEntry();
                logEntry.ID = id;
                logEntry.LogEx = logEx;
                logEntry.LogMessage = logMessage;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }
           
        }

        /// <summary>
        /// 向文件中写入日志的对象
        /// </summary>
        /// <param name="logEntry">日志对象</param>
        public void LogWrite(LogEntry logEntry)
        {
            try
            {
                 if (GetPath(path))
                 {
                     StreamWriter sw = new StreamWriter(path, true);

                     sw.WriteLine("编号:{0}", logEntry.ID.ToString());
                     sw.WriteLine("时间:{0}", DateTime.Now.ToString());
                     sw.WriteLine("描述:{0}", logEntry.LogMessage);
                     sw.WriteLine("异常明细:{0}", logEntry.LogEx.ToString());
                     sw.WriteLine("=======================================================================================");

                     sw.Flush();
                     sw.Close();
                 }
            }
            catch(Exception e)
            {
                EventLogWriter eventLogWriter = new EventLogWriter();
                eventLogWriter.LogEvent(e.Message);
            }

        }

        
        private bool GetPath(string path)
        {
            try
            {
                //取得日志文件所在的目录
                string directory = path.Substring(0, path.LastIndexOf('/'));
                if (!Directory.Exists(directory))
                {
                    CreatDirectory(directory);
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private void CreatDirectory(string directory)
        {
            try
            {
                Directory.CreateDirectory(directory);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }//class Logging

    /// <summary>
    /// 事务日志操作类
    /// </summary>
    class EventLogWriter
    {
        private string eventSourceName;
        private string EventSourceName
        {
            set { eventSourceName = value; }
        }
        EventLogEntryType eventLogType;
        private EventLogEntryType EventLogType
        {
            set { eventLogType = value; }

        }

        public  EventLogWriter()
        {
            eventSourceName = "DasherStation";
            eventLogType = EventLogEntryType.Error;
        }

        
        /// <summary>
        /// 向事务日志中写入信息
        /// </summary>
        /// <param name="message">写入信息的字符串</param>
        public void LogEvent(string message)
        {
            try
            {
                if (!EventLog.SourceExists(eventSourceName))
                {
                    EventLog.CreateEventSource(eventSourceName, "Application");

                }
                EventLog.WriteEntry(eventSourceName, message, EventLogEntryType.Error);
            }
            catch
            {

            }
        }

    }//class EventLogWriter

}//namespace DasherTools
