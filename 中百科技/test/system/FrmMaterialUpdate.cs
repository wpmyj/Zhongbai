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
    public partial class FrmMaterialUpdate : common.BaseForm
    {
        public FrmMaterialUpdate()
        {
            InitializeComponent();
        }

        FormHelper formHelper = new FormHelper();

        private MaterialClass material;

        internal MaterialClass Material
        {
            get { return material; }
            set { material = value; }
        }

        #region GetValue()
        private void GetValue()
        {
            txt_kind.Text = Material.Kind;
            txt_name.Text = Material.Name;
            txt_model.Text = Material.Model;
            txt_density.Text = Material.Density;
            txt_rate.Text = Material.Rate.ToString();
            txt_nstock.Text = Material.NadirStock.ToString();
            txt_remark.Text = Material.Remark;
        }
        #endregion

        #region SetValue()
        private void SetValue()
        {
            if (!string.IsNullOrEmpty(txt_density.Text.Trim()))
            {
                Material.Density = txt_density.Text.Trim();
            }
            else
            {
                Material.Density = "";
            }
            if (!string.IsNullOrEmpty(txt_rate.Text.Trim()))
            {
                Material.Rate = decimal.Parse(txt_rate.Text.Trim());
            }
            else
            {
                Material.Rate = 0;
            }
            if (!string.IsNullOrEmpty(txt_nstock.Text.Trim()))
            {
                Material.NadirStock = decimal.Parse(txt_nstock.Text.Trim());
            }
            else
            {
                Material.NadirStock = 0;
            }
            if (!string.IsNullOrEmpty(txt_remark.Text.Trim()))
            {
                Material.Remark = txt_remark.Text.Trim();
            }
            else
            {
                Material.Remark = "";
            }
        }
        #endregion

        private void FrmMaterialUpdate_Load(object sender, EventArgs e)
        {
            GetValue();
            txt_density.Focus();
        }

        private void FrmMaterialUpdate_KeyPress(object sender, KeyPressEventArgs e)
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
                MaterialLogic mLogic = new MaterialLogic();
                if (mLogic.MaterialUpdate(Material))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
