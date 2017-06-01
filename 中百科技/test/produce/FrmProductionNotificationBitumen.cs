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
    public partial class FrmProductionNotificationBitumen : common.BaseForm 
    {
        public FrmProductionNotificationBitumen()
        {
            InitializeComponent();
        }
        private ProducePlan.pType mark2;
        public ProducePlan.pType Mark2
        {
            get
            {
                return this.mark2;
            }
            set
            {
                this.mark2 = value;
            }
        }
        ProducePlan producePlan = new ProducePlan();

        FormHelper formHelper = new FormHelper();

        private void FrmProductionNotificationBitumen_Load(object sender, EventArgs e)
        {
            //producePlan.productKindBind(cmb_productKind);
            //producePlan.equipmentInfoBind(cmb_equipmentInfo);
            producePlan.ProduceProportionBind(dgv_proportion, null,this.Mark2);
            producePlan.produceTeamBind(cmb_produceTeam);
            checkType();
        }

        private void checkType()
        {
            if (this.Mark2 == ProducePlan.pType.RestructureAsphaltum)
            {
                this.Text = "改性沥青通知单";
            }
            else
            {
                this.Text = "乳化沥青通知单";
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

        private void cmb_productName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productName.SelectedIndex != -1)
            {
                producePlan.productModelBind(cmb_productModel, cmb_productName.SelectedValue.ToString());
            }
        }

        private void cmb_productModel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (cmb_productName.SelectedIndex > -1 && cmb_productModel.SelectedIndex > -1)
            //{
            //    string pNid = cmb_productName.SelectedValue.ToString();
            //    string pMid = cmb_productModel.SelectedValue.ToString();

            //    string pId = producePlan.getPid(pNid, pMid).ToString();

            //    producePlan.proportionDetailBind(cmb_proportionDetail, pId,Mark2);            
            //}
        }

        private void cmb_proportionDetail_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (cmb_proportionDetail.SelectedIndex != -1)
            //{
            //    string pId = cmb_proportionDetail.SelectedValue.ToString();
            //    producePlan.proportionDetailBind(dgv_proportionDetail, pId);
            //}
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                if (dgv_proportionDetail.Rows.Count > 0)
                {
                    save();

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("配合比信息数量不能为 0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void save()
        {

            #region produceNotice
            ProduceNotice produceNotice = new ProduceNotice();
            produceNotice.spId = long.Parse(dgv_proportion.SelectedRows[0].Cells["id"].Value.ToString());
            produceNotice.inputDate = DateTime.Now;
            produceNotice.inputMan = this.UserName;
            produceNotice.notifyDate = DateTime.Parse(dtp_notify.Value.ToShortDateString());
            produceNotice.notifyMan = txt_notifyMan.Text.ToString().Trim();
            produceNotice.planQuantity = decimal.Parse(txt_planQuantity.Text.ToString().Trim());
            produceNotice.ptId = long.Parse(cmb_produceTeam.SelectedValue.ToString().Trim());
            produceNotice.remark = txt_ps.Text.ToString().Trim();
            produceNotice.startDate = DateTime.Parse(dtp_start.Value.ToShortDateString());
            #endregion

            #region sendproportion

            SendProportion sendProportion = new SendProportion();
            sendProportion.id = long.Parse(dgv_proportion.SelectedRows[0].Cells["id"].Value.ToString());
            sendProportion.inputMan = this.UserName;

            #endregion

            producePlan.saveProduceNotice(produceNotice, sendProportion, null, null, null);
        }

        private void dgv_proportion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_proportion.SelectedRows.Count > 0)
            {
                cmb_productKind.Text = dgv_proportion.SelectedRows[0].Cells["sort"].Value.ToString();
                cmb_productName.Text = dgv_proportion.SelectedRows[0].Cells["name"].Value.ToString();
                cmb_productModel.Text = dgv_proportion.SelectedRows[0].Cells["model"].Value.ToString();
                cmb_equipmentInfo.Text = dgv_proportion.SelectedRows[0].Cells["ename"].Value.ToString();

                string ppId = dgv_proportion.SelectedRows[0].Cells["ppid"].Value.ToString();
                if (!string.IsNullOrEmpty(ppId))
                {
                    producePlan.proportionDetailBind(dgv_proportionDetail, ppId);
                }
            }
        }




    }
}
