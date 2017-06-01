using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using DasherStation.transport;

namespace DasherStation.system
{
    public partial class FrmWarehouseInfoUpdate : BaseForm
    {
        public FrmWarehouseInfoUpdate()
        {
            InitializeComponent();
        }

        FormHelper formHelper = new FormHelper();

        private warehouseInfo model;

        public warehouseInfo Model
        {
            get { return model; }
            set { model = value; }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(this.groupBox1))
            {
                Model.name = this.txt_name.Text.Trim();
                Model.no = this.txt_no.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
            
        }

        private void FrmWarehouseInfoUpdate_Load(object sender, EventArgs e)
        {
            if (Model != null)
            {
                this.txt_name.Text = Model.name;
                this.txt_no.Text = Model.no;
            }
        }
    }
}
