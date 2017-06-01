using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.metage
{
    public partial class FrmRegressArchives : BaseForm
    {
        private string truckNo;
        public string TruckNo
        {
            get { return truckNo; }
            set { truckNo = value; }
        }
        private string grossWeight;
        public string GrossWeight
        {
            get { return grossWeight; }
            set { grossWeight = value; }
        }
        private string tare;
        public string Tare
        {
            get { return tare; }
            set { tare = value; }
        }
        private string suttle;
        public string Suttle
        {
            get { return suttle; }
            set { suttle = value; }
        }
        public FrmRegressArchives()
        {
            InitializeComponent();
        }

        private void FrmRegressArchives_Load(object sender, EventArgs e)
        {
            
            TextGrossWeight.Text = grossWeight;
            TextTare.Text = tare;
            TextSuttle.Text = suttle;
            textBox4.Text = truckNo;

        }
        //public void SetInWeighingValue(InWeighingClass info)
        //{
        //    inInfo = info;
        //}
        //public void SetOutWeighingValue(OutWeighingClass info)
        //{
        //    outInfo = info;
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认归档", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Check.CheckFloat(TextSuttle.Text))
                {
                    grossWeight = TextGrossWeight.Text;
                    tare = TextTare.Text;
                    suttle = TextSuttle.Text;
                    this.DialogResult = DialogResult.OK;   
                }
            }

        }

        private void TextGrossWeight_TextChanged(object sender, EventArgs e)
        {
            if ((Check.CheckFloat(TextGrossWeight.Text)) && (Check.CheckFloat(TextTare.Text)))
            {
                TextSuttle.Text = (Convert.ToDouble(TextGrossWeight.Text) - Convert.ToDouble(TextTare.Text)).ToString();
                
            }
        }
    }
}
