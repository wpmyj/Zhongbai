using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.common
{
    public partial class FrmConfirm : BaseForm
    {
        public FrmConfirm()
        {
            InitializeComponent();
        }

        private bool confirm;

        public bool Confirm
        {
            get { return confirm; }
            set { confirm = value; }
        }

        private void FrmConfirm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Confirm = true;
            submit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Confirm = false;
            submit();
        }
        private void submit()
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
