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
    public partial class FrmProductionRecordBitumenWarm : common.BaseForm 
    {
        public FrmProductionRecordBitumenWarm()
        {
            InitializeComponent();
        }

        ProducePlan producePlan = new ProducePlan();

        FormHelper formHelper = new FormHelper();

        private void FrmProductionRecordBitumenWarm_Load(object sender, EventArgs e)
        {
            producePlan.equipmentInfoBind(cmb_equipmentInfo);
            producePlan.produceTeamBind(cmb_produceTeam);
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox2))
            {
                save();
                this.DialogResult = DialogResult.OK;
            }          
        }
        private void save()
        {
            AgainCalefactionProduceLog againCalefactionProduceLog = new AgainCalefactionProduceLog();

            againCalefactionProduceLog.eiId = long.Parse(cmb_equipmentInfo.SelectedValue.ToString());
            againCalefactionProduceLog.inputDate=DateTime.Now;
            againCalefactionProduceLog.inputMan=this.UserName;
            againCalefactionProduceLog.piId=long.Parse(cmb_personnelInfo.SelectedValue.ToString());
            againCalefactionProduceLog.produceDate=DateTime.Parse(dtp_produceDate.Value.ToShortDateString());
            againCalefactionProduceLog.ptId=long.Parse(cmb_produceTeam.SelectedValue.ToString());
            againCalefactionProduceLog.remark=txt_remark.Text.Trim();
            againCalefactionProduceLog.startMachineTime=dtp_startMachineTime.Value;
            againCalefactionProduceLog.stopMachineTime=dtp_stopMachineTime.Value;
            againCalefactionProduceLog.weather = txt_weather.Text.Trim();

            producePlan.saveProduceLog(againCalefactionProduceLog);
        }

        private void cmb_produceTeam_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_produceTeam.SelectedIndex > -1)
            {
                producePlan.personnelInfoBind(cmb_personnelInfo, cmb_produceTeam.SelectedValue.ToString());
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }




    }
}
