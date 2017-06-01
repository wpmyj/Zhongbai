using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.Monitor
{
    public partial class FrmQCvsLL : DasherStation.common.BaseForm
    {
        public FrmQCvsLL()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.txtStartDate.Value = DateTime.Now.AddDays(-1);
            QCAndLLogic oModel = new QCAndLLogic();
            this.cboName.DisplayMember = "name";
            this.cboName.ValueMember = "id";
            cboName.Text = "";
            cboName.SelectedIndex = -1;
            this.cboName.DataSource = oModel.GetMaterialName().Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtEndDate.Value < this.txtStartDate.Value)
            {
                DasherStation.HumanResource.CommUI.AlertError("结止日期不能小于开始日期!");
                return;
            }
            this.dtgList.DataSource = new QCAndLLogic().GetData(
                this.txtStartDate.Value, 
                this.txtEndDate.Value, 
                cboName.SelectedValue != null ? cboName.SelectedValue.ToString() : null, 
                cboModel.SelectedValue != null ? cboModel.SelectedValue.ToString() : null );
            this.dtgList.DataMember = "table";

            // 清空查询条件;
            cboName.Text = "";
            cboName.SelectedIndex = -1;
            cboModel.Text = "";
            cboModel.SelectedIndex = -1;
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboName.SelectedValue != null)
            {
                this.cboModel.DisplayMember = "材料规格";
                this.cboModel.ValueMember = "id";
                cboModel.Text = "";
                cboModel.SelectedIndex = -1;
                this.cboModel.DataSource = new DasherStation.system.MaterialLogic().InitialMModelComboBox(int.Parse(this.cboName.SelectedValue.ToString()));
            }
            else
            {
                this.cboModel.DataSource = null;
            }
        }
    }



    
}
