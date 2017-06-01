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
    public partial class FrmProductionRecordRBitumen : common.BaseForm 
    {
        public FrmProductionRecordRBitumen()
        {
            InitializeComponent();
        }

        private int mark2;

        public int Mark2
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

        private void FrmProductionRecordRBitumen_Load(object sender, EventArgs e)
        {
           // producePlan.equipmentInfoBind(cmb_equipmentInfo);
            producePlan.produceTeamBind(cmb_produceTeam);
           // producePlan.productNameBind(cmb_productName, producePlan.getProductKindId("沥青"));
            checkType();
        }

        private void checkType()
        {
            string strWhere = " and pnt.checkupMan is not null and pnt.checkupMan!='' ";
            if (this.Mark2 == 0)
            {
                this.Text = "改性沥青生产记录";
                producePlan.produceNoticeBind(null, this.dgv_notify_1, null, strWhere);
                //producePlan.produceNoticeBind(null, null, this.dgv_notify_1, strWhere);
            }
            else
            {
                this.Text = "乳化沥青生产记录";
                producePlan.produceNoticeBind(null, null, this.dgv_notify_1, strWhere);
                //producePlan.produceNoticeBind(null, this.dgv_notify_1, null, strWhere);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (dgv_notify_1.SelectedRows.Count > 0)
            {
                if (TimeCheck() && formHelper.inputCheck(this.groupBox8) && formHelper.inputCheck(groupBox2))
                {
                    save();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool TimeCheck()
        {
            string logTable;
            if (this.Mark2 == 0)
            {
                logTable = "restructureAsphaltumProduceLog";
            }
            else
            {
                logTable = "emulsificationAsphaltumProduceLog";
            }

            return producePlan.DateCheck(dtp_produceDate, dtp_startMachineTime, dtp_stopMachineTime, logTable);
        }

        private void save()
        {
            if (Mark2 == 1)
            {
                EmulsificationAsphaltumProduceLog model = new EmulsificationAsphaltumProduceLog();
                model.eiId = long.Parse(dgv_notify_1.SelectedRows[0].Cells["eiid"].Value.ToString());
                model.inputDate = DateTime.Now;
                model.inputMan = this.UserName;

                model.pId = long.Parse(dgv_notify_1.SelectedRows[0].Cells["ppid"].Value.ToString());
                model.pId2 = long.Parse(dgv_notify_1.SelectedRows[0].Cells["pid"].Value.ToString());
                model.produceDate = DateTime.Parse(dtp_produceDate.Value.ToShortDateString());
                model.ptId = long.Parse(cmb_produceTeam.SelectedValue.ToString());
                model.quantity1 = decimal.Parse(txt_quantity1.Text.Trim());

                if (!string.IsNullOrEmpty(txt_quantity2.Text.Trim()))
                {
                    model.quantity2 = decimal.Parse(txt_quantity2.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txt_quantity3.Text.Trim()))
                {
                    model.quantity3 = decimal.Parse(txt_quantity3.Text.Trim());
                }

                model.remark = txt_remark.Text.Trim();
                model.startMachineTime = DateTime.Parse(string.Format("{0} {1}", dtp_produceDate.Value.ToShortDateString(), dtp_startMachineTime.Text));
                model.stopMachineTime = DateTime.Parse(string.Format("{0} {1}", dtp_produceDate.Value.ToShortDateString(), dtp_stopMachineTime.Text));
                model.weather = txt_weather.Text.Trim();
                producePlan.saveProduceLog(model);
            }
            else
            {
                RestructureAsphaltumProduceLog model = new RestructureAsphaltumProduceLog();
                model.eiId = long.Parse(dgv_notify_1.SelectedRows[0].Cells["eiid"].Value.ToString());
                model.inputDate = DateTime.Now;
                model.inputMan = this.UserName;

                model.pId = long.Parse(dgv_notify_1.SelectedRows[0].Cells["ppid"].Value.ToString());
                model.pId2 = long.Parse(dgv_notify_1.SelectedRows[0].Cells["pid"].Value.ToString());
                model.produceDate = DateTime.Parse(dtp_produceDate.Value.ToShortDateString());
                model.ptId = long.Parse(cmb_produceTeam.SelectedValue.ToString());
                model.quantity1 = decimal.Parse(txt_quantity1.Text.Trim());

                if (!string.IsNullOrEmpty(txt_quantity2.Text.Trim()))
                {
                    model.quantity2 = decimal.Parse(txt_quantity2.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txt_quantity3.Text.Trim()))
                {
                    model.quantity3 = decimal.Parse(txt_quantity3.Text.Trim());
                }

                model.remark = txt_remark.Text.Trim();
                model.startMachineTime = DateTime.Parse(string.Format("{0} {1}", dtp_produceDate.Value.ToShortDateString(), dtp_startMachineTime.Text));
                model.stopMachineTime = DateTime.Parse(string.Format("{0} {1}", dtp_produceDate.Value.ToShortDateString(), dtp_stopMachineTime.Text));
                model.weather = txt_weather.Text.Trim();
                producePlan.saveProduceLog(model);
            }

            
        }

        private void dgv_notify_1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_notify_1.SelectedRows.Count > 0)
            {
                producePlan.proportionDetailBind(dgv_proportionDetail, dgv_notify_1.SelectedRows[0].Cells["ppid"].Value.ToString());
                cmb_produceTeam.SelectedIndex = new TransportLogic().FindIndex(cmb_produceTeam, dgv_notify_1.SelectedRows[0].Cells["ptid"].Value.ToString(), "id");
            }
        }

    }
}
