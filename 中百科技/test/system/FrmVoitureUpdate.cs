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
    public partial class FrmVoitureUpdate : common.BaseForm
    {
        public FrmVoitureUpdate()
        {
            InitializeComponent();
        }

        FormHelper formHelper = new FormHelper();

        private TruckClass truck;

        internal TruckClass Truck
        {
            get { return truck; }
            set { truck = value; }
        }

        #region 设置运输单位信息
        private void SetUnit()
        {
            TransportLogic tLogic = new TransportLogic();
            cbx_tname.DataSource = tLogic.FrmTransportSearchAll("", 0);
            cbx_tname.DisplayMember = "单位名称";
            cbx_tname.ValueMember = "id";
            cbx_tname.SelectedIndex = -1;
        }
        #endregion

        #region GetValue()
        private void GetValue()
        {
            txt_dname.Text = Truck.DriverName;
            txt_height.Text = Truck.Height.ToString();
            txt_lenth.Text = Truck.Lenth.ToString();
            txt_no.Text = Truck.No;
            txt_owner.Text = Truck.Owner;
            txt_remark.Text = Truck.Remark;
            txt_sdWeight.Text = Truck.StandardDeadWeight.ToString();
            txt_stare.Text = Truck.StandardTare.ToString();
            txt_tare.Text = Truck.Tare.ToString();
            txt_width.Text = Truck.Width.ToString();
            txt_color.Text = Truck.Color;
            txt_model.Text = Truck.Model;
            cbx_tname.Text = Truck.C_name;
        }
        #endregion

        #region SetValue()
        private void SetValue()
        {
            Truck.DriverName = txt_dname.Text.Trim();
            Truck.No = txt_no.Text.Trim();
            Truck.Owner = txt_owner.Text.Trim();
            Truck.Remark = txt_remark.Text.Trim();
            Truck.Color = txt_color.Text.Trim();
            Truck.Model = txt_model.Text.Trim();

            if (!txt_height.Text.Trim().Equals(""))
            {
                Truck.Height = decimal.Parse(txt_height.Text.Trim());
            }
            else
            {
                Truck.Height = 0;
            }
            if (!txt_lenth.Text.Trim().Equals(""))
            {
                Truck.Lenth = decimal.Parse(txt_lenth.Text.Trim());
            }
            else
            {
                Truck.Lenth = 0;
            }
            if (!txt_sdWeight.Text.Trim().Equals(""))
            {
                Truck.StandardDeadWeight = decimal.Parse(txt_sdWeight.Text.Trim());
            }
            else
            {
                Truck.StandardDeadWeight = 0;
            }
            if (!txt_stare.Text.Trim().Equals(""))
            {
                Truck.StandardTare = decimal.Parse(txt_stare.Text.Trim());
            }
            else
            {
                Truck.StandardTare = 0;
            }
            if (!txt_tare.Text.Trim().Equals(""))
            {
                Truck.Tare = decimal.Parse(txt_tare.Text.Trim());
            }
            else
            {
                Truck.Tare = 0;
            }
            if (!txt_width.Text.Trim().Equals(""))
            {
                Truck.Width = decimal.Parse(txt_width.Text.Trim());
            }
            else
            {
                Truck.Width = 0;
            }
            if (!cbx_tname.Text.Trim().Equals(""))
            {
                Truck.Conveyancer = Convert.ToInt32(cbx_tname.SelectedValue.ToString());
            }
            else
            {
                Truck.Conveyancer = 1;
            }
        }
        #endregion

        private void FrmVoitureUpdate_Load(object sender, EventArgs e)
        {
            SetUnit();
            GetValue();
            cbx_tname.Focus();
        }

        private void FrmVoitureUpdate_KeyPress(object sender, KeyPressEventArgs e)
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
                TruckLogic truckLogic = new TruckLogic();
                if (truckLogic.FrmTruckUpdate(Truck))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
