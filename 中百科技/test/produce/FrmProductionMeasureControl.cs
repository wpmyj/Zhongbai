using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.transport;

namespace DasherStation.produce
{
    public partial class FrmProductionMeasureControl : common.BaseForm
    {
        public FrmProductionMeasureControl()
        {
            InitializeComponent();
            producePlan.equipmentInfoBind(cmb_equipmentInfo);
        }

        ProducePlan producePlan = new ProducePlan();

        FormHelper formHelper = new FormHelper();

        private void FrmProductionMeasureControl_Load(object sender, EventArgs e)
        {
            dgvBind();
            check();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvBind()
        {
            producePlan.produceMeasureBind(dgv_produceMeasureMonitor, null);
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            string sqlStr = producePlan.getproduceMeasureSqlString(dtp_start, dtp_end, cmb_equipmentInfo, cbx_result);
            query(sqlStr);
            check();
        }

        private void query(string sqlStr)
        {
            producePlan.produceMeasureBind(dgv_produceMeasureMonitor, sqlStr);
        }

        private void check()
        {
            foreach(DataGridViewRow dgvr in dgv_produceMeasureMonitor.Rows)
            {
                if (dgvr.Cells["result"].Value.ToString().ToLower()=="false")
                {
                    dgvr.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            dgvBind();
            check();
        }
    }
}
