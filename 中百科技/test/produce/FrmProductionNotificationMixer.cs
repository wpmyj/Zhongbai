using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.quality;
using DasherStation.transport;

namespace DasherStation.produce
{
    public partial class FrmProductionNotificationMixer :common.BaseForm 
    {
        public FrmProductionNotificationMixer()
        {
            InitializeComponent();
        }

        ProducePlan producePlan = new ProducePlan();

        FormHelper formHelper = new FormHelper();

        private void FrmProductionNotificationMixer_Load(object sender, EventArgs e)
        {
            //producePlan.productKindBind(cmb_productKind);
            //producePlan.equipmentInfoBind(cmb_equipmentInfo);
            producePlan.produceTeamBind(cmb_produceTeam);
            producePlan.ProduceProportionBind(dgv_proportion, " and checkupMan is not null and checkupMan!='' ", ProducePlan.pType.Mixture);
        }


        private void cmb_productKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cmb_productKind.SelectedIndex!=-1)
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

        private void cmb_produceProportion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (cmb_produceProportion.SelectedIndex != -1)
            //{
            //    string ppid = cmb_produceProportion.SelectedValue.ToString();
            //    producePlan.proportionBind(this.panelTable, ppid);

            //}
          
        }

        private void cmb_targetProportion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (cmb_targetProportion.SelectedIndex != -1)
            //{
            //    string tpId = cmb_targetProportion.SelectedValue.ToString();
            //    producePlan.targetBind(dgv_targetProportionDetail, tpId);
            //}
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(this.groupBox1))
            {
                save();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void save()
        {
            #region produceNotice
            ProduceNotice produceNotice = new ProduceNotice();
            produceNotice.spId = long.Parse(dgv_proportion.SelectedRows[0].Cells["id"].Value.ToString());
            produceNotice.inputDate = DateTime.Now;
            produceNotice.inputMan = this.UserName;
            produceNotice.notifyDate =DateTime.Parse(dtp_notify.Value.ToShortDateString());
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

            producePlan.saveProduceNotice(produceNotice, sendProportion, null, null,null);
        }

        private void cmb_productModel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productName.SelectedIndex>-1&&cmb_productModel.SelectedIndex>-1)
            {
                //string pNid = cmb_productName.SelectedValue.ToString();
                //string pMid = cmb_productModel.SelectedValue.ToString();

                //string pId = producePlan.getPid(pNid, pMid).ToString();

                //producePlan.targetProportionBind(cmb_targetProportion, pId);
                //producePlan.produceProportionBind(cmb_produceProportion, pId);
            }
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if (dgv_proportion.SelectedRows.Count > 0)
            //{
            //    ReportProductionNotification reportProductionNotification = new ReportProductionNotification();
            //    reportProductionNotification.PNID = dgv_proportion.SelectedRows[0].Cells["id"].Value.ToString();
            //    reportProductionNotification.ShowDialog();
            //}
           
        }

        private void dgv_proportion_SelectionChanged(object sender, EventArgs e)
        {
            if(dgv_proportion.SelectedRows.Count>0)
            {
                cmb_productKind.Text=dgv_proportion.SelectedRows[0].Cells["sort"].Value.ToString();
                cmb_productName.Text=dgv_proportion.SelectedRows[0].Cells["name"].Value.ToString();
                cmb_productModel.Text=dgv_proportion.SelectedRows[0].Cells["model"].Value.ToString();
                cmb_equipmentInfo.Text=dgv_proportion.SelectedRows[0].Cells["ename"].Value.ToString();

                string ppid = dgv_proportion.SelectedRows[0].Cells["ppid"].Value.ToString();
                if (!String.IsNullOrEmpty(ppid))
                {
                    producePlan.proportionBind(this.panelTable, ppid);
                }
                string tpId = dgv_proportion.SelectedRows[0].Cells["tpid"].Value.ToString();
                if (!string.IsNullOrEmpty(tpId))
                {
                    producePlan.targetBind(dgv_targetProportionDetail, tpId);
                }
                
            }
        }








    }
}
