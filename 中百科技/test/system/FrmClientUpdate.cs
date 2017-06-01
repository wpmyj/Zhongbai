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
    public partial class FrmClientUpdate : common.BaseForm
    {
        public FrmClientUpdate()
        {
            InitializeComponent();
        }

        FormHelper formHelper = new FormHelper();

        private ClientClass client;

        internal ClientClass Client
        {
            get { return client; }
            set { client = value; }
        }

        #region GetValue()
        private void GetValue()
        {
            txt_name.Text = Client.Name;
            txt_principal.Text = Client.Principal;
            txt_artificialMan.Text = Client.ArtficialMan;
            txt_address.Text = Client.Address;
            txt_eMail.Text = Client.EMail;
            txt_phone.Text = Client.Phone;
            txt_postCode.Text = Client.PostCode;
            txt_remark.Text = Client.Remark;
           
        }
        #endregion

        #region SetValue()
        private void SetValue()
        {
            Client.Name = txt_name.Text.Trim()  ;
            Client.Principal = txt_principal.Text.Trim();
            Client.ArtficialMan = txt_artificialMan.Text.Trim();
            Client.Address = txt_address.Text.Trim();
            Client.EMail = txt_eMail.Text.Trim();
            Client.Phone = txt_phone.Text.Trim();
            Client.PostCode = txt_postCode.Text.Trim();
            Client.Remark = txt_remark.Text.Trim();
        }
        #endregion

        private void FrmClientUpdate_Load(object sender, EventArgs e)
        {
            GetValue();
            txt_artificialMan.Focus();
        }

        private void FrmClientUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                SetValue();
                ClientLogic clientLogic = new ClientLogic();
                if (clientLogic.FrmCliientUpdate(Client))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
