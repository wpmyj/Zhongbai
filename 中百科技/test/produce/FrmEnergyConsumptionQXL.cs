using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.ReportDistrict.produceReport;

namespace DasherStation.produce
{
    public partial class FrmEnergyConsumptionQXL :common.BaseForm 
    {
        public FrmEnergyConsumptionQXL()
        {
            InitializeComponent();
        }

        ProducePlan producePlan = new ProducePlan();

        string print_where = "";

        private void button3_Click(object sender, EventArgs e)
        {
            FrmEnergyConsumptionQXLr fecqrform = new FrmEnergyConsumptionQXLr();
            fecqrform.ShowDialog();
        }
             
        
        private void button10_Click(object sender, EventArgs e)
        {
            FrmEnergyConsumptionQXLm fecqmform = new FrmEnergyConsumptionQXLm();
            fecqmform.ShowDialog();
        }

        private void FrmEnergyConsumptionQXL_Load(object sender, EventArgs e)
        {
            query(dgv_Consume, null, ProducePlan.pType.deepFatConsume);
            producePlan.Collect((DataTable)(dgv_Consume.DataSource), new string[] {  "生产工时", "消耗", "电量消耗" });
        }
        private void query(DataGridView dgv, string strWhere, ProducePlan.pType type)
        {
            producePlan.ConsumeDailyBind(dgv, strWhere, type);
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = producePlan.getConsumeDailySql(dtp_start, dtp_end,null,null,null);
            print_where = strWhere;
            query(dgv_Consume, strWhere, ProducePlan.pType.deepFatConsume);
        }

        private void dgv_Consume_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showDetail(ProducePlan.pType.deepFatConsume);
        }

        private void showDetail(ProducePlan.pType type)
        {
                switch (type)
                {
                    case ProducePlan.pType.deepFatConsume:
                        if (dgv_Consume.SelectedRows.Count > 0)
                        {
                            FrmEnergyConsumptionQXLr frmEnergyConsumptionQXLr = new FrmEnergyConsumptionQXLr();

                            frmEnergyConsumptionQXLr.DtfId = (long)dgv_Consume.SelectedRows[0].Cells[0].Value;
                            frmEnergyConsumptionQXLr.ENo = dgv_Consume.SelectedRows[0].Cells[3].Value.ToString();

                            frmEnergyConsumptionQXLr.ShowDialog();
                        }                     
                        break;
                    case ProducePlan.pType.deepFatConsumeDetail:
                        if (dgv_Consume1.SelectedRows.Count > 0)
                        {
                            FrmEnergyConsumptionQXLm frmEnergyConsumptionQXLm = new FrmEnergyConsumptionQXLm();

                            frmEnergyConsumptionQXLm.DfcdsId = (long)dgv_Consume1.SelectedRows[0].Cells["id1"].Value;
                            frmEnergyConsumptionQXLm.ENo = dgv_Consume.SelectedRows[0].Cells[2].Value.ToString();

                            frmEnergyConsumptionQXLm.ShowDialog();
                        }
                        break;
                }
            
        }

        private void btn_query1_Click(object sender, EventArgs e)
        {
            string strWhere = producePlan.getConsumeDailyDetailSql(dtp_start1, dtp_end1);
            query(dgv_Consume1, strWhere, ProducePlan.pType.deepFatConsumeDetail);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    query(dgv_Consume, null, ProducePlan.pType.deepFatConsume);
                    producePlan.Collect((DataTable)(dgv_Consume.DataSource), new string[] { "生产工时", "消耗", "电量消耗" });
                    break;
                case 1:
                    query(dgv_Consume1, null, ProducePlan.pType.deepFatConsumeDetail);
                    producePlan.Collect((DataTable)(dgv_Consume1.DataSource), new string[] { "消耗量"});
                    break;
             
                default:
                    break;
            }
        }

        private void dgv_Consume1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showDetail(ProducePlan.pType.deepFatConsumeDetail);
        }

        private void btn_edit1_Click(object sender, EventArgs e)
        {
            showDetail(ProducePlan.pType.deepFatConsumeDetail);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            showDetail(ProducePlan.pType.deepFatConsume);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ReportProduceClass produce_report = new ReportProduceClass();
            produce_report.RunOvenUsedEnergyRecord(print_where);
            print_where = "";

        }





    }
}
