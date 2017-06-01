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
    public partial class FrmEnergyConsumptionQXLm :common.BaseForm 
    {
        public FrmEnergyConsumptionQXLm()
        {
            InitializeComponent();
        }

        private long dfcdsId;

        public long DfcdsId
        {
            get { return dfcdsId; }
            set { dfcdsId = value; }
        }

        private string eNo;
        public string ENo
        {
            get { return eNo; }
            set { eNo = value; }
        }

        ProducePlan producePlan = new ProducePlan();

        FormHelper formHelper = new FormHelper();

        DeepFatConsumeDailyStatisticsDetail deepFatConsumeDailyStatisticsDetail;

        private void FrmEnergyConsumptionQXLm_Load(object sender, EventArgs e)
        {
            producePlan.personInfoBind(cmb_personinfo, null);
            //new DoCombox(cmb_materialKind, cmb_materialName, cmb_materialModel, TransportLogic.TranType.material);
            if (DfcdsId != 0)
            {
                dataBind(DfcdsId);
            }
        }
        private void dataBind(long id)
        {
            cmb_equipmentInfo.Text = ENo;
            deepFatConsumeDailyStatisticsDetail = producePlan.GetDeepFatConsumeDailyStatisticsDetailObj(id);
            if (deepFatConsumeDailyStatisticsDetail != null)
            {
                txt_inputDate.Text = deepFatConsumeDailyStatisticsDetail.inputDate.ToString();
                txt_fuelWastage2.Text = deepFatConsumeDailyStatisticsDetail.fuelWastage.ToString();
                txt_remark.Text = deepFatConsumeDailyStatisticsDetail.remark.ToString();
            }
        }
        private void save()
        {
            if (deepFatConsumeDailyStatisticsDetail != null)
            {
                //if (cmb_materialName.SelectedIndex > -1 && cmb_materialModel.SelectedIndex > -1)
                //{
                //    deepFatConsumeDailyStatisticsDetail.mId = new Produce().queryMid(cmb_materialName.SelectedValue.ToString(), cmb_materialModel.SelectedValue.ToString());
                //}
                if (cmb_personinfo.SelectedIndex > -1)
                {
                    deepFatConsumeDailyStatisticsDetail.piId =long.Parse(cmb_personinfo.SelectedValue.ToString());
                }
                deepFatConsumeDailyStatisticsDetail.remark = txt_remark.Text.Trim();

                producePlan.UpdateDeepFatConsumeDailyStatisticsDetail(deepFatConsumeDailyStatisticsDetail);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(panel1))
            {
                 save();
                this.DialogResult = DialogResult.OK;
            }
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }

}
