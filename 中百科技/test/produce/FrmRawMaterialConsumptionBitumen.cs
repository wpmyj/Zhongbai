using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.produce
{
    public partial class FrmRawMaterialConsumptionBitumen : common.BaseForm 
    {
        public FrmRawMaterialConsumptionBitumen()
        {
            InitializeComponent();
        }

        ProducePlan producePlan = new ProducePlan();

        private void FrmRawMaterialConsumptionBitumen_Load(object sender, EventArgs e)
        {
            query(null, 0);
            producePlan.consumeModelBind(cmb_model, "改性沥青");
            producePlan.consumeModelBind(cmb_model1, "基质沥青");
        }

        private void query(string strWhere,int queryIndex)
        {
            if (queryIndex == 0)
            {
                producePlan.rAsphaltumConsumeBind(dgv_rAsphaltumConsume, strWhere);
            }
            else
            {
                producePlan.AsphaltumConsumeBind(dgv_AsphaltumConsume, strWhere);
            }
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            query(producePlan.getAsphaltumConsumeSql(dtp_start,dtp_end,cmb_model), 0);
        }

        private void btn_query1_Click(object sender, EventArgs e)
        {
            query(producePlan.getAsphaltumConsumeSql(dtp_start1, dtp_end1, cmb_model1), 1);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                query(null, 0);
            }
            else
            {
                query(null, 1);
            }
        }
    }
}
