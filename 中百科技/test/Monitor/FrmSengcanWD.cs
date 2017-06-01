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
    public partial class FrmSengcanWD : DasherStation.common.BaseForm
    {
        private CTemperatureHistory cthistory = new CTemperatureHistory();
        public FrmSengcanWD()
        {
            InitializeComponent();
        }

        protected override void  OnLoad(EventArgs e)
        {
             base.OnLoad(e);
        }

        MonitorLogin monitorL = new MonitorLogin();

        #region 生成绘制温度曲线的数组 t_value
        private void t_value()
        {
            string data = (dtp_data.Value.Date).ToString("yyyy-MM-dd");
            long tid = 0;
            if (!string.IsNullOrEmpty(cbx_name.Text.Trim()))
            {
                tid = Convert.ToInt64(cbx_name.SelectedValue.ToString());
            }
            if (!string.IsNullOrEmpty(cbx_no.Text.Trim()))
            {
                tid = Convert.ToInt64(cbx_no.SelectedValue.ToString());
            }

            label1.Text = monitorL.Search_TName(tid) + "的温度曲线";

            List<Point>  point = new List<Point> ();
            DataTable table = monitorL.Search_TemperatureValue(tid,data);

            foreach (DataRow dt in table.Rows)
            {  
                cthistory.MinValue = double.Parse(dt["minTemperature"].ToString());
                cthistory.MaxValue = double.Parse(dt["maxTemperature"].ToString());
                
                DateTime date = DateTime.Parse( dt["date"].ToString());
                double value = double.Parse(dt["value"].ToString());
                point.Add(new Point(){ X = date, Y = value});
            }
            cthistory.Points = point.ToArray();
            this.lineCurvesChartType1.Value = cthistory;
        }
        #endregion

        #region set_NameNo()
        private void set_NameNo()
        {
            cbx_name.DataSource = monitorL.Search_T_NoName();
            cbx_name.DisplayMember = "name";
            cbx_name.ValueMember = "id";
            cbx_name.Text = "";
            cbx_name.SelectedIndex = -1;

            cbx_no.DataSource = monitorL.Search_T_NoName();
            cbx_no.DisplayMember = "no";
            cbx_no.ValueMember = "id";
            cbx_no.Text = "";
            cbx_no.SelectedIndex = -1;
        }
        #endregion

        #region ClearAction()
        private void ClearAction()
        {
            cbx_name.Text = "";
            cbx_name.SelectedIndex = -1;
            cbx_no.Text = "";
            cbx_no.SelectedIndex = -1;
        }
        #endregion

        private void btn_query_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(cbx_name.Text.Trim())) && (string.IsNullOrEmpty(cbx_no.Text.Trim())))
            {
                MessageBox.Show("请选择温度名称或温度编号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbx_name.Focus();
            }
            t_value();
            ClearAction();

        }

        private void FrmSengcanWD_Load(object sender, EventArgs e)
        {
            set_NameNo();
        }

        private void rbtn_name_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_name.Checked)
            {
                cbx_name.Enabled = true;
                cbx_no.Enabled = false;
            }
        }

        private void rbtn_no_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_no.Checked)
            {
                cbx_name.Enabled = false;
                cbx_no.Enabled = true;
            }
        }
    }
}
