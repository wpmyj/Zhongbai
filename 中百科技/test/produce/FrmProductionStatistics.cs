using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.ReportDistrict.produceReport;

namespace DasherStation.produce
{
    public partial class FrmProductionStatistics : common.BaseForm 
    {
        public FrmProductionStatistics()
        {
            InitializeComponent();
        }

        ProducePlan producePlan = new ProducePlan();
        string print_where = "";
        private void FrmProductionStatistics_Load(object sender, EventArgs e)
        {
            producePlan.equipmentInfoBind(cmb_equipmentInfo);
            producePlan.productKindBind(cmb_productKind);
            dgvBind();
        }
        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = producePlan.getProduceSqlString(dtp_start, dtp_end, cmb_productName, cmb_productModel,cmb_equipmentInfo,null,null);
            print_where = strWhere;
            query(strWhere);
        }

        private void cmb_productKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productKind.SelectedIndex != -1)
            {
                cmb_productName.DataSource = null;
                cmb_productName.Items.Clear();
                producePlan.productNameBind(cmb_productName, cmb_productKind.SelectedValue.ToString());
                cmb_productModel.DataSource = null;
                cmb_productModel.Items.Clear();
            }
        }

        private void cmb_productName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productName.SelectedIndex != -1)
            {
                producePlan.productModelBind(cmb_productModel, cmb_productName.SelectedValue.ToString());
            }
        }

        private void dgvBind()
        {
            query(null);
        }

        private void query(string strWhere)
        {
            producePlan.ProduceStatisticsBind(dgv_Statistics, strWhere);

            #region // 关启学修改内容

            //修改人：关启学，在dgv_Statistics的最后一行追加统计行
            if (dgv_Statistics.RowCount > 0)
            {
                double quantity = 0;
                double quantitySum = 0;
                double goodQuantity = 0;
                double goodQuantitySum = 0;
                double badQuantity = 0;
                double badQuantitySum = 0;

                DataTable dt = (DataTable)(dgv_Statistics.DataSource);
                foreach (DataRow r in dt.Rows)
                {
                   quantity = 0;
                   goodQuantity = 0;
                   badQuantity = 0;

                   double.TryParse(r["quantity"].ToString(), out quantity);
                   double.TryParse(r["goodQuantity"].ToString(), out goodQuantity);
                   double.TryParse(r["badQuantity"].ToString(), out badQuantity);

                   quantitySum += quantity;
                   goodQuantitySum += goodQuantity;
                   badQuantitySum += badQuantity;
                }
                
                DataRow row = dt.NewRow();
                row["quantity"] = quantitySum;
                row["goodQuantity"] = goodQuantitySum;
                row["badQuantity"] = badQuantitySum;
                dt.Rows.Add(row);
            }

            #endregion
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            dgvBind();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportProduceClass produce_report = new ReportProduceClass();
            produce_report.RunDayProduceCount(print_where);
            print_where = "";
        }

    }
}
