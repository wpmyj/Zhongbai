using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.system;

namespace DasherStation.Monitor
{
    public partial class FrmLiQin_Stat : DasherStation.common.BaseForm
    {
        public FrmLiQin_Stat()
        {
            InitializeComponent();
        }

        MonitorLogin monitor_L = new MonitorLogin();


        #region DataGridView()为DataGridView赋值
        private void Set_DataGridView()
        {
            string begin_data = (txtStartDate.Value.Date).ToString("yyyy-MM-dd") + " 00:00:00";
            string end_data = (txtEndDate.Value.Date).ToString("yyyy-MM-dd") + " 23:59:59";

            dgv_liQin.DataSource = monitor_L.Stat_FlowmeterStat(begin_data, end_data);
            dgv_liQin.Columns["stat"].Width = 130;
            
        }
        #endregion

        private void FrmLiQin_Stat_Load(object sender, EventArgs e)
        {
            Set_DataGridView();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            Set_DataGridView();
        }
    }
}
