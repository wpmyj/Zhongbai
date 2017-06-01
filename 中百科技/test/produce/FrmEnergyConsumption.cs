using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.transport;
using DasherStation.common;


namespace DasherStation.produce
{
    public partial class FrmEnergyConsumption : common.BaseForm
    {
        public FrmEnergyConsumption()
        {
            InitializeComponent();
        }

        ProducePlan producePlan = new ProducePlan();



        private void frmEnergyConsumption_Load(object sender, EventArgs e)
        {
            query(dgv_Consume, null, ProducePlan.pType.Mixture);
            producePlan.Collect((DataTable)(dgv_Consume.DataSource), new string[] { "产品产量", "生产工时", "消耗", "电量消耗" });
            new DoCombox(cmb_productKind, cmb_productName, cmb_productModel, TransportLogic.TranType.product);
            new DoCombox(cmb_productKind1, cmb_productName1, cmb_productModel1, TransportLogic.TranType.product);
            new DoCombox(cmb_productKind2, cmb_productName2, cmb_productModel2, TransportLogic.TranType.product);
            producePlan.equipmentInfoBind(cmb_equipmentInfo);
            producePlan.equipmentInfoBind(cmb_equipmentInfo1);
            producePlan.equipmentInfoBind(cmb_equipmentInfo2);
        }
        private void query(DataGridView dgv, string strWhere, ProducePlan.pType type)
        {
            producePlan.ConsumeDailyBind(dgv, strWhere, type);

        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            FrmEnergyConsumptionH fechform = new FrmEnergyConsumptionH();
            if (fechform.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            string strWhere = producePlan.getConsumeDailySql(dtp_start, dtp_end, cmb_productName, cmb_productModel, cmb_equipmentInfo);
            query(dgv_Consume, strWhere, ProducePlan.pType.Mixture);
        }

        private void btn_queryAll_Click(object sender, EventArgs e)
        {
            query(dgv_Consume, null, ProducePlan.pType.Mixture);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    query(dgv_Consume, null, ProducePlan.pType.Mixture);
                    producePlan.Collect((DataTable)(dgv_Consume.DataSource), new string[] { "产品产量", "生产工时", "消耗", "电量消耗" });
                    break;
                case 1:
                    query(dgv_Consume1, null, ProducePlan.pType.RestructureAsphaltum);
                    producePlan.Collect((DataTable)(dgv_Consume1.DataSource), new string[] { "产品产量", "生产工时", "消耗", "电量消耗" });
                    break;
                case 2:
                    query(dgv_Consume2, null, ProducePlan.pType.EmulsificationAsphaltum);
                    producePlan.Collect((DataTable)(dgv_Consume2.DataSource), new string[] { "产品产量", "生产工时", "消耗", "电量消耗" });
                    break;
                default:
                    break;
            }
        }

        private void btn_query1_Click(object sender, EventArgs e)
        {
            string strWhere = producePlan.getConsumeDailySql(dtp_start1, dtp_end1, cmb_productName1, cmb_productModel1, cmb_equipmentInfo1);
            query(dgv_Consume1, strWhere, ProducePlan.pType.RestructureAsphaltum);
        }

        private void btn_query2_Click(object sender, EventArgs e)
        {
            string strWhere = producePlan.getConsumeDailySql(dtp_start2, dtp_end2, cmb_productName2, cmb_productModel2, cmb_equipmentInfo2);
            query(dgv_Consume2, strWhere, ProducePlan.pType.EmulsificationAsphaltum);
        }

        private void dgv_Consume_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showDetail(ProducePlan.pType.Mixture);
        }

        private void showDetail(ProducePlan.pType type)
        {
            switch (type)
            {
                case ProducePlan.pType.Mixture:
                    if (dgv_Consume.SelectedRows.Count > 0)
                    {
                        FrmEnergyConsumptionG frmEnergyConsumptionG = new FrmEnergyConsumptionG();
                        frmEnergyConsumptionG.Type = type;
                        frmEnergyConsumptionG.DrcsdId = long.Parse(dgv_Consume.SelectedRows[0].Cells["id"].Value.ToString());
                        frmEnergyConsumptionG.ENo = dgv_Consume.SelectedRows[0].Cells[5].Value.ToString();
                        frmEnergyConsumptionG.Pname = dgv_Consume.SelectedRows[0].Cells[6].Value.ToString();
                        frmEnergyConsumptionG.Pmodel = dgv_Consume.SelectedRows[0].Cells[7].Value.ToString();
                        frmEnergyConsumptionG.ShowDialog();
                    }
                    break;
                case ProducePlan.pType.RestructureAsphaltum:
                    if (dgv_Consume1.SelectedRows.Count > 0)
                    {
                        FrmEnergyConsumptionG frmEnergyConsumptionG = new FrmEnergyConsumptionG();
                        frmEnergyConsumptionG.Type = type;
                        frmEnergyConsumptionG.DrcsdId = long.Parse(dgv_Consume1.SelectedRows[0].Cells[0].Value.ToString());
                        frmEnergyConsumptionG.ENo = dgv_Consume1.SelectedRows[0].Cells[5].Value.ToString();
                        frmEnergyConsumptionG.Pname = dgv_Consume1.SelectedRows[0].Cells[6].Value.ToString();
                        frmEnergyConsumptionG.Pmodel = dgv_Consume1.SelectedRows[0].Cells[7].Value.ToString();
                        frmEnergyConsumptionG.ShowDialog();
                    }
                    break;
                case ProducePlan.pType.EmulsificationAsphaltum:
                    if (dgv_Consume2.SelectedRows.Count > 0)
                    {
                        FrmEnergyConsumptionG frmEnergyConsumptionG = new FrmEnergyConsumptionG();
                        frmEnergyConsumptionG.Type = type;
                        frmEnergyConsumptionG.DrcsdId = long.Parse(dgv_Consume2.SelectedRows[0].Cells[0].Value.ToString());
                        frmEnergyConsumptionG.ENo = dgv_Consume2.SelectedRows[0].Cells[5].Value.ToString();
                        frmEnergyConsumptionG.Pname = dgv_Consume2.SelectedRows[0].Cells[6].Value.ToString();
                        frmEnergyConsumptionG.Pmodel = dgv_Consume2.SelectedRows[0].Cells[7].Value.ToString();
                        frmEnergyConsumptionG.ShowDialog();
                    }
                    break;
            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            showDetail(ProducePlan.pType.Mixture);
        }

        private void dgv_Consume1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showDetail(ProducePlan.pType.RestructureAsphaltum);
        }

        private void dgv_Consume2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showDetail(ProducePlan.pType.EmulsificationAsphaltum);
        }

        private void btn_edit2_Click(object sender, EventArgs e)
        {
            showDetail(ProducePlan.pType.EmulsificationAsphaltum);
        }

        private void btn_edit1_Click(object sender, EventArgs e)
        {
            showDetail(ProducePlan.pType.RestructureAsphaltum);
        }

        private void btn_queryAll1_Click(object sender, EventArgs e)
        {
            query(dgv_Consume1, null, ProducePlan.pType.RestructureAsphaltum);
        }

        private void btn_queryAll2_Click(object sender, EventArgs e)
        {
            query(dgv_Consume2, null, ProducePlan.pType.EmulsificationAsphaltum);
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (dgv_Consume.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgv_Consume.SelectedRows[0].Cells["id"].Value.ToString());

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.DasherResourceConsumeDailyStatisticsDataSetTableAdapters.dasherResourceConsumeDailyStatisticsTableAdapter", "dasherResourceConsumeDailyStatistics", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.DasherResourceConsumeDailyStatisticsDataSet";
                reportData.ReportName = "DasherStation.Report.DasherResourceConsumeDailyStatisticsReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }

        private void btn_PrintG_Click(object sender, EventArgs e)
        {
            if (dgv_Consume1.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgv_Consume1.SelectedRows[0].Cells[0].Value.ToString());

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.AsphaltumConsumeDailyStatisticsDataSetTableAdapters.asphaltumConsumeDailyStatisticsTableAdapter", "asphaltumConsumeDailyStatistics", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.AsphaltumConsumeDailyStatisticsDataSet";
                reportData.ReportName = "DasherStation.Report.AsphaltumConsumeDailyStatisticsReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }



        private void btnPrintAll_Click_1(object sender, EventArgs e)
        {
            ReportHelper reportServer = new ReportHelper();
            ReportData reportData = new ReportData();
            List<ReportSource> reportSourceList = new List<ReportSource>();

            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ResourceConsumeDataSetTableAdapters.resourceConsumeTableAdapter", "resourceConsume", null));
            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ResourceConsumeDataSetTableAdapters.basicInfoTableAdapter", "basicInfo", null));

            reportData.DataSetName = "DasherStation.dataSet.ResourceConsumeDataSet";
            reportData.ReportName = "DasherStation.Report.ResourceConsumeReport.rdlc";

            reportData.ReportSourceList = reportSourceList;

            reportServer.ShowReport(reportData);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dgv_Consume2.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgv_Consume2.SelectedRows[0].Cells[0].Value.ToString());

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.RebuildAsphaltConsumeDailyStatisticsDataSetTableAdapters.rebuildAsphaltConsumeDailyStatisticsTableAdapter", "rebuildAsphaltConsumeDailyStatistics", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.RebuildAsphaltConsumeDailyStatisticsDataSet";
                reportData.ReportName = "DasherStation.Report.RebuildAsphaltConsumeDailyStatisticsReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


    }
}
