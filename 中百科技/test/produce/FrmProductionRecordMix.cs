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
    public partial class FrmProductionRecordMix :common.BaseForm 
    {
        public FrmProductionRecordMix()
        {
            InitializeComponent();
        }

        ProducePlan producePlan = new ProducePlan();

        FormHelper formHelper = new FormHelper();

        private void FrmProductionRecordMix_Load(object sender, EventArgs e)
        {
            producePlan.produceTeamBind(cmb_produceTeam);
            producePlan.produceNoticeBind(this.dgv_notify, null, null, " and pnt.checkupMan is not null and pnt.checkupMan!='' ");
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (dgv_notify.SelectedRows.Count > 0)
            {
                if (producePlan.DateCheck(dtp_produceDate, dtp_startMachineTime, dtp_stopMachineTime, "mixtureProduceLog") && formHelper.inputCheck(this.groupBox1) && formHelper.inputCheck(this.groupBox2) && formHelper.inputCheck(this.groupBox3))
                {
                    save();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        
        private void save()
        {
            MixtureProduceLog mixtureProduceLog = new MixtureProduceLog();
            mixtureProduceLog.coarseMaterialHydratedRate = decimal.Parse(txt_coarseMaterialHydratedRate.Text.Trim());
            mixtureProduceLog.eiId = long.Parse(dgv_notify.SelectedRows[0].Cells["eiid"].Value.ToString());
            mixtureProduceLog.inputDate = DateTime.Now;
            mixtureProduceLog.inputMan = this.UserName;
            mixtureProduceLog.morningTemperature = decimal.Parse(txt_morningTemperature.Text.Trim());
            mixtureProduceLog.nightTemperature = decimal.Parse(txt_nightTemperature.Text.Trim());
            mixtureProduceLog.noonTemperature = decimal.Parse(txt_noonTemperature.Text.Trim());

            string pnId = dgv_notify.SelectedRows[0].Cells["pnId"].Value.ToString();
            string pmId = dgv_notify.SelectedRows[0].Cells["pmId"].Value.ToString();
            long pId=long.Parse(producePlan.getPid(pnId,pmId).ToString());

            mixtureProduceLog.pId = pId;
            mixtureProduceLog.ppId = long.Parse(dgv_notify.SelectedRows[0].Cells["ppid"].Value.ToString());
            mixtureProduceLog.tpId = long.Parse(dgv_notify.SelectedRows[0].Cells["tpid"].Value.ToString());
            mixtureProduceLog.produceDate = DateTime.Parse(dtp_produceDate.Value.ToShortDateString());
            mixtureProduceLog.ptId = long.Parse(cmb_produceTeam.SelectedValue.ToString());
            mixtureProduceLog.quantity1 = decimal.Parse(txt_quantity1.Text.Trim());
            

            if (!string.IsNullOrEmpty(txt_quantity2.Text.Trim()))
            {
                mixtureProduceLog.quantity2 = decimal.Parse(txt_quantity2.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txt_quantity3.Text.Trim()))
            {
                mixtureProduceLog.quantity3 = decimal.Parse(txt_quantity3.Text.Trim());
            }

            mixtureProduceLog.refinedMaterialHydratedRate = decimal.Parse(txt_refinedMaterialHydratedRate.Text.Trim());
            mixtureProduceLog.remark = txt_remark.Text.Trim();
            mixtureProduceLog.startMachineTime =DateTime.Parse(string.Format("{0} {1}",dtp_produceDate.Value.ToShortDateString(),dtp_startMachineTime.Text));
            mixtureProduceLog.stopMachineTime = DateTime.Parse(string.Format("{0} {1}", dtp_produceDate.Value.ToShortDateString(), dtp_stopMachineTime.Text));


            
            mixtureProduceLog.weather = txt_weather.Text.Trim();
            //mixtureProduceLog.total

            producePlan.saveProduceLog(mixtureProduceLog);
            
        }

        private void dgv_notify_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_notify.SelectedRows.Count > 0)
            {
                producePlan.proportionBind(panelTable, dgv_notify.SelectedRows[0].Cells["ppid"].Value.ToString());
                producePlan.targetBind(dgv_targetProportionDetail, dgv_notify.SelectedRows[0].Cells["tpid"].Value.ToString());

                cmb_produceTeam.SelectedIndex = new TransportLogic().FindIndex(cmb_produceTeam, dgv_notify.SelectedRows[0].Cells["ptid"].Value.ToString(),"id");
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (dgv_notify.SelectedRows.Count > 0)
            {
                if (producePlan.DateCheck(dtp_produceDate, dtp_startMachineTime, dtp_stopMachineTime, "mixtureProduceLog") && formHelper.inputCheck(this.groupBox1) && formHelper.inputCheck(this.groupBox2) && formHelper.inputCheck(this.groupBox3))
                {
                    save();

                    this.DialogResult = DialogResult.OK;
                }
            }
        }






    }
}
