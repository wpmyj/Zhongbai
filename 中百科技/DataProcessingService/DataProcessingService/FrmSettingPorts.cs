using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace DasherStation.DataProcessingService
{
    public partial class FrmSettingPorts : Form
    {
        public string InstallPath;

        public FrmSettingPorts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var appConfig = ConfigurationManager.OpenExeConfiguration(this.InstallPath);
            if (appConfig.AppSettings.Settings.AllKeys.Contains("ListenPorts") == false)
            {
                appConfig.AppSettings.Settings.Add(new KeyValueConfigurationElement("ListenPorts", this.txtPort.Text.Trim()));
                appConfig.Save(ConfigurationSaveMode.Modified);
            }
        }
    }
}
