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
    public partial class FrmRawMaterialConsumption :common.BaseForm 
    {
        public FrmRawMaterialConsumption()
        {
            InitializeComponent();
        }

        ProducePlan producePlan = new ProducePlan();
        private void FrmRawMaterialConsumption_Load(object sender, EventArgs e)
        {
            producePlan.equipmentInfoBind(cmb_equipmentInfo);
            producePlan.productKindBind(cmb_productKind);
            producePlan.materialKindBind(cmb_materialKind);
            dgvBind();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = producePlan.getProduceSqlString(dtp_start,dtp_end,cmb_productName,cmb_productModel,cmb_equipmentInfo,cmb_materialName,cmb_materialModel);
            query(strWhere);
        }

        private void dgvBind()
        {
            query(null);
        }

        private void query(string strWhere)
        {
            producePlan.produceMaterialConsumptionBind(dgv_MaterialConsumption, strWhere);

            #region // 关启学修改内容

            //修改人：关启学，在dgv_MaterialConsumption的最后一行追加统计行
            if (dgv_MaterialConsumption.RowCount > 0)
            {
                double quantity = 0;
                double quantitySum = 0;
                double consumption = 0;
                double consumptionSum = 0;


                DataTable dt = (DataTable)(dgv_MaterialConsumption.DataSource);
                foreach (DataRow r in dt.Rows)
                {
                    double.TryParse(r["quantity"].ToString(), out quantity);
                    double.TryParse(r["consumption"].ToString(), out consumption);

                    quantitySum += quantity;
                    consumptionSum += consumption;
                }

                DataRow row = dt.NewRow();
                row["quantity"] = quantitySum;
                row["consumption"] = consumptionSum;

                dt.Rows.Add(row);
            }

            #endregion



        }

        private void cmb_materialKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_materialKind.SelectedIndex != -1)
            {
                cmb_materialName.DataSource = null;
                cmb_materialName.Items.Clear();
                producePlan.materialNameBind(cmb_materialName, cmb_materialKind.SelectedValue.ToString());
                cmb_materialModel.DataSource = null;
                cmb_materialModel.Items.Clear();
            }
        }

        private void cmb_productName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productName.SelectedIndex != -1)
            {
                producePlan.productModelBind(cmb_productModel, cmb_productName.SelectedValue.ToString());
            }
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

        private void btn_all_Click(object sender, EventArgs e)
        {
            dgvBind();
        }

        private void cmb_materialName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_materialName.SelectedIndex != -1)
            {
                producePlan.materialModelBind(cmb_materialModel, cmb_materialName.SelectedValue.ToString());
            }
        }
        
    }
}
