﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.transport.Report
{
    public partial class ReportTest : Form
    {
        public ReportTest()
        {
            InitializeComponent();
        }

        private void ReportTest_Load(object sender, EventArgs e)
        {
            //为数据实例填充数据
            //this.transportSettlementTableAdapter.Fill(this.tranSport.stockNote);

            //填充完成后刷新报表
            this.reportViewer1.RefreshReport();
        }
    }
}
