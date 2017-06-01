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
    public partial class FrmSengCanLvsXiaoSouL : DasherStation.common.BaseForm
    {
        public FrmSengCanLvsXiaoSouL()
        {
            InitializeComponent();
        }
        MonitorLogin monitorL = new MonitorLogin();

        #region 为设备编号赋值
        private void SetEiId()
        {
            cbx_eiid.DataSource = monitorL.Search_eino(true);
            cbx_eiid.DisplayMember = "设备编号";
            cbx_eiid.ValueMember = "eiid";
            cbx_eiid.Text = "";
            cbx_eiid.SelectedIndex = -1;
        }
        #endregion

        #region contrast()
        private void contrast()
        {
            foreach (DataGridViewRow dgv in dgv_contrast_PS.Rows)
            {
                dgv.Cells["date"].Value = dtp_end.Value.ToString("yyyy-MM-dd");

                string yield = dgv.Cells["psum"].Value.ToString();
                string sell = dgv.Cells["ssum"].Value.ToString();
                if ((!yield.Equals("")) && (!sell.Equals("")))
                {
                    dgv.Cells["diversity"].Value = (decimal.Parse(sell) - decimal.Parse(yield)).ToString();
                    dgv.Cells["error"].Value = (Math.Abs (decimal.Parse(dgv.Cells["diversity"].Value.ToString()) / decimal.Parse(sell) * 100)).ToString("0.00");
                }
            }
        }
        #endregion

        #region DataGridView()
        private void DataGridView()
        {
            string date_begin = (dtp_being.Value.Date).ToString();
            string date_end = dtp_end.Value.ToString();
            long eiid = 0;
            if (! string.IsNullOrEmpty(cbx_eiid.Text.Trim()))
            {
                eiid = Convert.ToInt64(cbx_eiid.SelectedValue.ToString());
            }
            string where = monitorL.where(eiid, date_begin, date_end);
            dgv_contrast_PS.DataSource = monitorL.Search_mixturePSsell(where);
            dgv_contrast_PS.Columns["pid"].Visible = false;
            dgv_contrast_PS.Columns["eiid"].Visible = false;

            contrast();
        }
        #endregion
        private void FrmSengCanLvsXiaoSouL_Load(object sender, EventArgs e)
        {
            SetEiId();
            DataGridView();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            DataGridView();
            cbx_eiid.Text = "";
            cbx_eiid.SelectedIndex = -1;
        }
    }
}
