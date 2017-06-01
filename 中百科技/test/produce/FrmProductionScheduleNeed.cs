using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.produce
{
    public partial class FrmProductionScheduleNeed : BaseForm
    {
        public FrmProductionScheduleNeed()
        {
            InitializeComponent();
        }

        ProducePlan producePlan = new ProducePlan();

        private string ppid;

        public string Ppid
        {
            get { return ppid; }
            set { ppid = value; }
        }

        private void FrmProductionScheduleNeed_Load(object sender, EventArgs e)
        {
            if (Ppid != null)
            {
                producePlan.GetMaterialNeed(dgv_need, Ppid);
            }
        }
    }
}
