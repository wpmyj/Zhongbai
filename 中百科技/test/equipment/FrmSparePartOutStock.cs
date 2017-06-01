using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.equipment
{
    public partial class FrmSparePartOutStock : common.BaseForm
    {
        EquipmentLogic equipmentLogic = new EquipmentLogic();

        SqlHelper sqlHelperObj = new SqlHelper();

        int count1;

        public FrmSparePartOutStock()
        {
            InitializeComponent();
        }

        private void FrmFrmSparePartOut_Load(object sender, EventArgs e)
        {
            QueryBind(cbxQuery);
            cbxQuery.SelectedIndex = -1;

            dgvInfo.DataSource = equipmentLogic.FrmFrmSparePartOutAllInfo("");

            if (dgvInfo.Rows.Count != 0)
            {
                dgvInfo.Rows[0].Selected = false;
            }
        }

        //查询条件的绑定
        public void QueryBind(ComboBox cmb)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Value");

            DataRow row = table.NewRow();

            row = table.NewRow();
            row["id"] = "OSB.id";
            row["Value"] = "出库单号";
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = "CSPB.claimMan";
            row["Value"] = "领料人";
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = "department.name";
            row["Value"] = "领料部门";
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = "EI.no";
            row["Value"] = "设备编号";
            table.Rows.Add(row);

            cmb.DataSource = table;
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "Value";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmSparePartOutStockDetail formOutStockDetail = new FrmSparePartOutStockDetail();

            try
            {
                if (formOutStockDetail.ShowDialog() == DialogResult.OK)
                {
                    dgvInfo.DataSource = equipmentLogic.FrmFrmSparePartOutAllInfo("");
                    if (dgvInfo.Rows.Count != 0)
                    {
                        dgvInfo.Rows[0].Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string str = txtQueryStr.Text.Trim();
            if ((this.cbxQuery.SelectedIndex != -1) && (!(string.IsNullOrEmpty(str))))
            {
                if (!Check.CheckQueryIsEmpty(str))
                {
                    MessageBox.Show("查询关键字中不能包含特殊字符或空格", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string SqlStr = this.cbxQuery.SelectedValue.ToString() + " like '%" + str + "%'";
                dataBind(SqlStr);
                if (dgvInfo.Rows.Count != 0)
                {
                    dgvInfo.Rows[0].Selected = false;
                }
            }
            else
            {
                dgvInfo.DataSource = equipmentLogic.FrmFrmSparePartOutAllInfo("");
                if (dgvInfo.Rows.Count != 0)
                {
                    dgvInfo.Rows[0].Selected = false;
                }
            }
            count1 = dgvDetail.RowCount;

            if (count1 != 0)
            {
                for (int i = 0; i < count1; i++)
                {
                    this.dgvDetail.Rows.Remove(dgvDetail.Rows[0]);
                }
            }
        }
        private void dataBind(string strWhere)
        {
            this.dgvInfo.DataSource = equipmentLogic.FrmFrmSparePartOutAllInfo(strWhere);
        }

        private void dgvInfo_Click(object sender, EventArgs e)
        {
            dgvDetail.DataSource = equipmentLogic.FrmFrmSparePartOutSearchDetailInfo(dgvInfo.CurrentRow.Cells["id"].Value.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool status;

            List<long> list = new List<long>();

            if (dgvInfo.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否要删除选中的“出库单？”", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //long id = Convert.ToInt64(dgvInfo.SelectedRows[0].Cells["id"].Value.ToString());

                    foreach (DataGridViewRow dr in dgvInfo.SelectedRows)
                    {
                        list.Add(long.Parse(dr.Cells["id"].Value.ToString()));
                    }

                    status = equipmentLogic.DeleteFrmFrmSparePartOut(list);

                    //status = equipmentLogic.DeleteFrmClaimSparePartBill(id);
                    if (status)
                    {
                        MessageBox.Show("删除成功！");
                    }
                    else
                    {
                        MessageBox.Show("删除时出错！！");
                    }
                    dgvInfo.DataSource = equipmentLogic.FrmFrmSparePartOutAllInfo("");

                    count1 = dgvDetail.RowCount;

                    if (count1 != 0)
                    {
                        for (int i = 0; i < count1; i++)
                        {
                            this.dgvDetail.Rows.Remove(dgvDetail.Rows[0]);
                        }
                    }

                    dgvInfo.Rows[0].Selected = false;

                }
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (dgvInfo.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgvInfo.SelectedRows[0].Cells["id"].Value.ToString());

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.OutStockBillDataSetTableAdapters.outStockBillTableAdapter", "outStockBill", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.OutStockBillDataSet";
                reportData.ReportName = "DasherStation.Report.OutStockBillReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }
    }
}
