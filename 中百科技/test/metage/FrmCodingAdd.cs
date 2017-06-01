using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.metage
{
    public partial class FrmCodingAdd : common.BaseForm
    {
        private string codingNo;
        public string CodingNo
        {
            get { return codingNo; }
            set { codingNo = value; }
        }
        public FrmCodingAdd()
        {
            InitializeComponent();
        }

        private void FrmCodingAdd_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                codingNo = textBox1.Text;
                Close();
            }
        }
    }
}
