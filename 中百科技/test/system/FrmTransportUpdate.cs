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
    public partial class FrmTransportUpdate : common.BaseForm
    {
        public FrmTransportUpdate()
        {
            InitializeComponent();
        }

        FormHelper formHelper = new FormHelper();

        private TransportClass transport;

        internal TransportClass Transport
        {
            get { return transport; }
            set { transport = value; }
        }

        #region GetValue()
        private void GetValue()
        {
            txt_address.Text = Transport.Address;
            txt_capability.Text = Transport.Capability;
            txt_corporation.Text = Transport.Corporation;
            txt_Email.Text = Transport.Email;
            txt_name.Text = Transport.Name;
            txt_phone.Text = Transport.Phone;
            txt_postCode.Text = Transport.PostCode;
            txt_principal.Text = Transport.Principal;
            txt_remark.Text = Transport.Remark;
        }
        #endregion

        #region SetValue()
        private void SetValue()
        {
            Transport.Address = txt_address.Text.Trim();
            Transport.Capability = txt_capability.Text.Trim();
            Transport.Corporation = txt_corporation.Text.Trim();
            Transport.Email = txt_Email.Text.Trim();
            Transport.Name = txt_name.Text.Trim();
            Transport.Phone = txt_phone.Text.Trim();
            Transport.PostCode = txt_postCode.Text.Trim();
            Transport.Principal = txt_principal.Text.Trim();
            Transport.Remark = txt_remark.Text.Trim();
        }
        #endregion

        private void FrmTransportUpdate_Load(object sender, EventArgs e)
        {
            GetValue();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                 SetValue();
                 TransportLogic transportLogic = new TransportLogic();
                 if (transportLogic.FrmTransportUpdate(Transport))
                 {
                     this.DialogResult = DialogResult.OK;
                     this.Close();
                 }
            }
        }

        private void FrmTransportUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

    }
}
