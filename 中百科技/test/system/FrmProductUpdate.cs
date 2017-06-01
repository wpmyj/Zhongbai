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
    public partial class FrmProductUpdate : common.BaseForm
    {
        public FrmProductUpdate()
        {
            InitializeComponent();
        }
        
        FormHelper formHelper = new FormHelper();

        private ProductClass product;

        internal ProductClass Product
        {
            get { return product; }
            set { product = value; }
        }

        #region GetValue()
        private void GetValue()
        {
            txt_density.Text = Product.Density;
            txt_kind.Text = Product.Kind;
            txt_model.Text = Product.Model;
            txt_name.Text = Product.Name;
            txt_nstock.Text = Product.NadirStock.ToString();
            txt_planPrice.Text = Product.PlanPrice.ToString();
            txt_rate.Text = Product.Rate.ToString();
            txt_remark.Text = Product.Remark;
        }
        #endregion

        #region SetValue()
        private void SetValue()
        {
            Product.Density = txt_density.Text.Trim();
            if (!string.IsNullOrEmpty(txt_nstock.Text.Trim()))
            {
                Product.NadirStock = decimal.Parse(txt_nstock.Text.Trim());
            }
            else
            {
                Product.NadirStock = 0;
            }
            if (!string.IsNullOrEmpty(txt_planPrice.Text.Trim()))
            {
                Product.PlanPrice = decimal.Parse(txt_planPrice.Text.Trim());
            }
            else
            {
                Product.PlanPrice = 0;
            }
            if (!string.IsNullOrEmpty(txt_rate.Text.Trim()))
            {
                Product.Rate = decimal.Parse(txt_rate.Text.Trim());
            }
            else
            {
                Product.Rate = 0;
            }
            Product.Remark = txt_remark.Text.Trim();
        }
        #endregion

        private void FrmProductUpdate_Load(object sender, EventArgs e)
        {
            GetValue();
            txt_rate.Focus();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                SetValue(); 
                ProductLogic pLogic = new ProductLogic();
                if (pLogic.FrmPoeductUpdate(Product))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            
        }
    }
}
