/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：
     * 文件功能描述：
     *
     * 创建人：付中华
     * 创建时间：2009-3-2
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.stock
{
    public partial class FrmPurchasing : common.BaseForm
    {
        public FrmPurchasing()
        {
            InitializeComponent();
        }
        purchaseScheDetaillogic purchaseSchedetaillogic = new purchaseScheDetaillogic();
        stockStaticsLogic stockStaticsLogic = new stockStaticsLogic();
        private void FrmPurchasing_Load(object sender, EventArgs e)
        {
            setMaterial();          
        }      
                
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 查询条件有三种情况 1、种类、名称、规格  2、种类、名称、规格、供应商  3、种类、名称、规格、供应商、运输单位
            selectCond();
        }
        // 按材料查询时设置的datagridview
        private void setMaterial()
        {
            // 时间段需要再进行处理
            string startyear = Convert.ToString(dateTimePicker1.Value.ToShortDateString());
            string endyear = Convert.ToString(dateTimePicker2.Value.ToShortDateString());

            dataGridView1.DataSource = stockStaticsLogic.stockMaterialIntervalSelectLogic(startyear, endyear);
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView1.Visible = true;

            if (this.dataGridView1.DataSource != null)
            {
                DataTable dt = dataGridView1.DataSource as DataTable;
                DataRow[] row = stockStaticsLogic.GetA(stockStaticsLogic.stockMaterialSelectlogic(endyear), stockStaticsLogic.stockMaterialIntervalSelectLogic(startyear, endyear));
                foreach (var I in row)
                {
                    dt.ImportRow(I);
                }
            }
        }
        // 按供应商时设置的datagridview
        private void setProviderInfo()
        {
            string startyear = Convert.ToString(dateTimePicker1.Value.ToShortDateString());
            string endyear = Convert.ToString(dateTimePicker2.Value.ToShortDateString());
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView1.Visible = false;
            dataGridView3.Visible = false;
            dataGridView2.Visible = true;
            dataGridView2.DataSource = stockStaticsLogic.stockProviderInfoLogic(startyear, endyear);
        }
        // 按运输单位时设置的datagridview
        private void setTransportUnit()
        {
            // 时间段内需要处理
            string startyear = Convert.ToString(dateTimePicker1.Value.ToShortDateString());
            string endyear = Convert.ToString(dateTimePicker2.Value.ToShortDateString());
            dataGridView3.Dock = DockStyle.Fill;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            dataGridView3.DataSource = stockStaticsLogic.stockTransportUnitLogic(startyear, endyear);
        }
        // 按选择的条件进行查询
        private void selectCond()
        {
            if (this.comboBox1.Text == "")
            {
                MessageBox.Show("请选择查询条件！");
                return;
            }
            int switchId = 0;
            if (this.comboBox1.Text == "材料")
            {
                switchId = 0;
            }
            if (this.comboBox1.Text == "供应商")
            {
                switchId = 1;
            }
            if (this.comboBox1.Text == "运输单位")
            {
                switchId = 2;
            }

            string startyear = Convert.ToString(dateTimePicker1.Value.ToShortDateString());
            string endyear = Convert.ToString(dateTimePicker2.Value.ToShortDateString());

            DateTime d1 = DateTime.Parse(startyear);
            DateTime d2 = DateTime.Parse(endyear);
            if (d1 > d2)
            {
                MessageBox.Show("起始日期不能大于终止日期！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            else
            {
                switch (switchId)
                {
                    case 0:
                        setMaterial();
                        dataGridView1.Refresh();
                        break;
                    case 1:
                        setProviderInfo();
                        dataGridView2.Refresh();
                        break;
                    case 2:
                        setTransportUnit();
                        dataGridView3.Refresh();
                        break;
                    default:
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Trim().Equals(""))
            {
                ReportStockClass retportRtock = new ReportStockClass();
                if (this.comboBox1.Text == "材料")
                {
                    retportRtock.RunInputDayStatistics(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                }
                if (this.comboBox1.Text == "供应商")
                {
                    retportRtock.RunSupplierDayStatistics(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                }
                if (this.comboBox1.Text == "运输单位")
                {
                    retportRtock.RunTransportDayStatistics(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                }               
                
            }
        }

        
    }
}
