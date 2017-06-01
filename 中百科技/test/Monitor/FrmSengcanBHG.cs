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
    public partial class FrmSengcanBHG : DasherStation.common.BaseForm
    {
        public FrmSengcanBHG()
        {
            InitializeComponent();
        }

        MonitorLogin monitorL = new MonitorLogin();

        #region DataGridView()
        private void DataGridView()
        {
            string date_begin = (dtp_being.Value.Date).ToString();
            string date_end = dtp_end.Value.ToString();
            long eiid = 0;
            if (!string.IsNullOrEmpty(cbx_eiid.Text.Trim()))
            {
                eiid = Convert.ToInt64(cbx_eiid.SelectedValue.ToString());
            }
            string where = monitorL.where(eiid, date_begin, date_end);
            dgv_PMonitor.DataSource = monitorL.Search_PMonitor(where);
            dgv_PMonitor.Columns["id"].Visible = false;
            dgv_PMonitor.Columns["eiId"].Visible = false;

            dgv_PMonitor.Columns["1#仓"].Width = 60;
            dgv_PMonitor.Columns["2#仓"].Width = 60;
            dgv_PMonitor.Columns["3#仓"].Width = 60;
            dgv_PMonitor.Columns["4#仓"].Width = 60;
            dgv_PMonitor.Columns["5#仓"].Width = 60;
            dgv_PMonitor.Columns["6#仓"].Width = 60;
            dgv_PMonitor.Columns["石粉"].Width = 60;
            dgv_PMonitor.Columns["填料"].Width = 60;
            dgv_PMonitor.Columns["生产日期"].Width = 120;
            dgv_PMonitor.Columns["混合料温度(%)"].Width = 110;
            dgv_PMonitor.Columns["批次产量(吨)"].Width = 110;
            dgv_PMonitor.Columns["沥青"].Width = 60;

        }
        #endregion

        #region 为设备编号赋值
        private void SetEiId()
        {
            cbx_eiid.DataSource = monitorL.Search_eino(false);
            cbx_eiid.DisplayMember = "设备编号";
            cbx_eiid.ValueMember = "eiId";
            cbx_eiid.Text = "";
            cbx_eiid.SelectedIndex = -1;
        }
        #endregion

        private void FrmSengcanBHG_Load(object sender, EventArgs e)
        {
            DataGridView();
            SetEiId();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            DataGridView();
            cbx_eiid.Text = "";
            cbx_eiid.SelectedIndex = -1;
        }
    }
}
