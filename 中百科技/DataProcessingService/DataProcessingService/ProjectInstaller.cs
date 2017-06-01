using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;

namespace DasherStation.DataProcessingService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
       
        protected override void OnCommitted(IDictionary savedState)
        {
            base.OnCommitted(savedState);            
        }

        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
            FrmSettingPorts frmPorts = new FrmSettingPorts();
            frmPorts.InstallPath = this.Context.Parameters["assemblypath"];

            //AppDomain.CurrentDomain.ActivationContext.Form
            System.Windows.Forms.DialogResult result = frmPorts.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                
            }
            else
            {
                throw new ApplicationException("未设置监听端口,服务程序不能启动!");
            }
            FrmSettingConnectionString frmConn = new FrmSettingConnectionString();
            frmConn.InstallPath = frmPorts.InstallPath;
            result = frmConn.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                ServiceController service = new ServiceController("DataService");
                service.Start();
                System.Windows.Forms.MessageBox.Show("数据采集服务程序已启动!", "提示信息",
                 System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information,
                  System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly, false);
            }
            else
            {
                throw new ApplicationException("未设置数据库链接串,服务程序不能启动!");
            }
        } 
    }
}
