using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.produce;
using DasherStation.transport;

namespace DasherStation.system
{
    public partial class FrmParameter : common.BaseForm
    {
        public FrmParameter()
        {
            InitializeComponent();
        }

        basicInfo basicInfoObj;

        BasicInfo basicInfoAct = new BasicInfo();

        FormHelper formHelper = new FormHelper();

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                basicInfoObj = new basicInfo();
                basicInfoObj.address = this.txt_address.Text.Trim();
                //basicInfoObj.asphaltumError = long.Parse(this.txt_asphaltumError.Text.Trim());
                basicInfoObj.dasherName = this.txt_dasherName.Text.Trim();
                basicInfoObj.enterpriseKind = this.txt_enterpriseKind.Text.Trim();
                basicInfoObj.fax = this.txt_fax.Text.Trim();
                basicInfoObj.inputMan = this.UserName;
                //basicInfoObj.maxHydrousImpurityRate = decimal.Parse(this.txt_maxHydrousImpurityRate.Text.Trim());
                basicInfoObj.phone = this.txt_phone.Text.Trim();
                basicInfoObj.postNo = this.txt_postNo.Text.Trim();
                basicInfoObj.systemUseTime = dtp_system.Value;
                basicInfoObj.updateMan = this.UserName;
                basicInfoObj.updateDate = DateTime.Now;
                basicInfoObj.piId = long.Parse(cbx_piId.SelectedValue.ToString());

                basicInfoAct.UpdateOrInsert(basicInfoObj);

                MessageBox.Show("参数修改成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }

        private void FrmParameter_Load(object sender, EventArgs e)
        {
            new ProduceLogic().makerR(cbx_piId);
            basicInfoObj = basicInfoAct.GetModel();
            databind(basicInfoObj);
        }
        private void databind(basicInfo model)
        {
            if (model != null)
            {
                this.txt_address.Text = model.address;
                //this.txt_asphaltumError.Text = model.asphaltumError.ToString();
                this.txt_dasherName.Text = model.dasherName;
                this.txt_enterpriseKind.Text = model.enterpriseKind;
                this.txt_fax.Text = model.fax;
                //this.txt_maxHydrousImpurityRate.Text = model.maxHydrousImpurityRate.ToString();
                this.txt_phone.Text = model.phone;
                this.txt_postNo.Text = model.postNo;
                this.dtp_system.Value =(DateTime)model.systemUseTime;
                new transport.TransportLogic().FindIndex(cbx_piId,model.piId.ToString(),"id");    
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

       
    }
}
