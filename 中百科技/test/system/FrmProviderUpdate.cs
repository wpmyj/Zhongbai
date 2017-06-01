using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.transport;

namespace DasherStation.system
{
    public partial class FrmProviderUpdate : common.BaseForm
    {
        public FrmProviderUpdate()
        {
            InitializeComponent();
        }


        
        FormHelper formHelper = new FormHelper();

        private ProviderClass provider;

        internal ProviderClass Provider
        {
            get { return provider; }
            set { provider = value; }
        }

        #region GetValue()
        private void GetValue()
        {
            txt_address.Text = Provider.Address;
            txt_artificialMan.Text = Provider.ArtificialMan;
            txt_eMail.Text = Provider.EMail;
            txt_name.Text = Provider.Name;
            txt_phone.Text = Provider.Phone;
            txt_postCode.Text = Provider.PostCode;
            txt_principal.Text = Provider.Principal;
            txt_remark.Text = Provider.Remark;
            if (provider.Mark == 0)
            {
                cbx_mark.Text = "原材料供应商";
            }
            if (provider.Mark == 1)
            {
                cbx_mark.Text = "备品备件供应商";
            }
            txt_produceNo.Text = provider.ProduceNo;
        }
        #endregion

        #region SetValue()
        private void SetValue()
        {
            Provider.Address = txt_address.Text.Trim();
            Provider.ArtificialMan = txt_artificialMan.Text.Trim();
            Provider.EMail = txt_eMail.Text.Trim();
            Provider.Name = txt_name.Text.Trim();
            Provider.Phone = txt_phone.Text.Trim();
            Provider.PostCode = txt_postCode.Text.Trim();
            Provider.Principal = txt_principal.Text.Trim();
            Provider.Remark = txt_remark.Text.Trim();
            if (cbx_mark.Text.Trim().Equals("原材料供应商"))
            {
                provider.Mark = 0;
            }
            if (cbx_mark.Text.Trim().Equals("备品备件供应商"))
            {
                provider.Mark = 1;
            }
            provider.ProduceNo = txt_produceNo.Text.Trim();
        }
        #endregion

        private void FrmProviderUpdate_Load(object sender, EventArgs e)
        {
            GetValue();
            txt_artificialMan.Focus();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                SetValue();
                ProviderLogic providerLogic = new ProviderLogic();
                if (providerLogic.FrmProviderUpdate(Provider))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void FrmProviderUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
