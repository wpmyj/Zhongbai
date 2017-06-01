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
    public partial class FrmEnergyConsumptionQXLr : common.BaseForm 
    {
        public FrmEnergyConsumptionQXLr()
        {
            InitializeComponent();
        }

        private long dtfId;

        public long DtfId
        {
            get { return dtfId; }
            set { dtfId = value; }
        }

        private string eNo;

        public string ENo
        {
            get { return eNo; }
            set { eNo = value; }
        }

        ProducePlan producePlan = new ProducePlan();

        FormHelper formHelper = new FormHelper();

        DeepFatConsumeDailyStatistics deepFatConsumeDailyStatistics;

        private void FrmEnergyConsumptionQXLr_Load(object sender, EventArgs e)
        {
            new DoCombox(cmb_materialKind, cmb_materialName, cmb_materialModel, TransportLogic.TranType.material);
            if (DtfId != 0)
            {
                dataBind(DtfId);
            }
        }

        private void dataBind(long id)
        {
            cmb_eNo.Text = ENo;
            deepFatConsumeDailyStatistics = producePlan.GetDeepFatConsumeDailyStatisticsObj(id);
            if (deepFatConsumeDailyStatistics != null)
            {
                txt_produceDate.Text = deepFatConsumeDailyStatistics.produceDate.ToString();
                txt_consumeCoulometry.Text = deepFatConsumeDailyStatistics.consumeCoulometry.ToString();
                txt_manHour.Text = deepFatConsumeDailyStatistics.manHour.ToString();
                txt_fuelWastage2.Text = deepFatConsumeDailyStatistics.fuelWastage2.ToString();
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
        private void save()
        {
            if (deepFatConsumeDailyStatistics != null)
            {
                if (cmb_materialName.SelectedIndex > -1 && cmb_materialModel.SelectedIndex > -1)
                {
                    deepFatConsumeDailyStatistics.mId = new Produce().queryMid(cmb_materialName.SelectedValue.ToString(), cmb_materialModel.SelectedValue.ToString());
                }
                deepFatConsumeDailyStatistics.manHour = decimal.Parse(txt_manHour.Text.Trim());
                deepFatConsumeDailyStatistics.consumeCoulometry = decimal.Parse(txt_consumeCoulometry.Text.Trim());
                deepFatConsumeDailyStatistics.inputMan = this.UserName;
                producePlan.UpdateDeepFatConsumeDailyStatistics(deepFatConsumeDailyStatistics);
            }
        }




    }
}
