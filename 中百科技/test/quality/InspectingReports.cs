/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：InspectingReports.cs
 * 文件功能描述：检验报告界面，调用已经安装在本机的“试验室软件”
 *
 * 创建人：关启学
 * 创建时间：2009-03-09
 *
 * 修改人：
 * 修改时间：
 * 修改内容：
 *
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace DasherStation.quality
{
    public class InspectingReports
    {       
        
        
        #region //方法：启动“试验室软件”

        /*
        * 方法名称：RunLabApp
        * 方法功能描述：用于启动“试验室软件”
        *
        * 创建人：关启学
        * 创建时间：20090309
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void RunLabApp()
        {
            System.Diagnostics.Process labProcess = new System.Diagnostics.Process();
            
            //获取“试验室软件”的安装路径
            labProcess.StartInfo.FileName = System.Configuration.ConfigurationManager.AppSettings["LabAppPath"]; 
            bool fileIsExists = System.IO.File.Exists(labProcess.StartInfo.FileName);

            //判断“试验室软件”是否安装在配置文件中相应的路径
            if (fileIsExists)
            {
                labProcess.Start();
            }
            else
            {
                MessageBox.Show("请确认“试验室软件”的安装路径是否为：'" + labProcess.StartInfo.FileName + "'", "路径错误！");
            }



            ////获取配置文件
            //System.Configuration.Configuration config = 
            //    System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);

            ////获取配置文件中的“appSettings”节
            //System.Configuration.AppSettingsSection appSettings = 
            //    (System.Configuration.AppSettingsSection)config.GetSection("appSettings");


            //if (appSettings != null)
            //{
            //    System.Diagnostics.Process labProcess = new System.Diagnostics.Process();
            //    labProcess.StartInfo.FileName = appSettings.Settings["LabAppPath"].Value;

            //    bool fileIsExists = System.IO.File.Exists(labProcess.StartInfo.FileName);

            //    //判断“试验室软件”是否安装在配置文件中相应的路径
            //    if (fileIsExists)
            //    {
            //        labProcess.Start();                    
            //    }
            //    else
            //    {
            //        MessageBox.Show("请确认“试验室软件”的安装路径是否为：'" + labProcess.StartInfo.FileName + "'","路径错误！");
            //    }
            //}

        }

        #endregion
        
    }
}
