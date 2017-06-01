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
    public partial class FrmSparePartClaim : common.BaseForm
    {
        EquipmentLogic equipmentLogic = new EquipmentLogic();

        SqlHelper sqlHelperObj = new SqlHelper();

        int count1;


        public FrmSparePartClaim()
        {
            InitializeComponent();
        }

        private void FrmClaimSparePartBill_Load(object sender, EventArgs e)
        {
            try
            {
                QueryBind(cbxQuery);
                cbxQuery.SelectedIndex = -1;

                dgvInfo.DataSource = equipmentLogic.FrmClaimSparePartBillAllInfo("");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
        //查询条件的绑定
        public void QueryBind(ComboBox cmb)
        {
            DataTable table = new DataTable();
            try
            {
                table.Columns.Add("ID");
                table.Columns.Add("Value");

                DataRow row = table.NewRow();

                row = table.NewRow();
                row["id"] = "CSPB.id";
                row["Value"] = "领料单号";
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }   
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmSparePartClaimDetail formSparePartClaimDetail = new FrmSparePartClaimDetail();

            try
            {
                if (formSparePartClaimDetail.ShowDialog() == DialogResult.OK)
                {
                    dgvInfo.DataSource = equipmentLogic.FrmClaimSparePartBillAllInfo("");
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
            try
            {
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
                    dgvInfo.DataSource = equipmentLogic.FrmClaimSparePartBillAllInfo("");
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
        private void dataBind(string strWhere)
        {
            try
            {
                this.dgvInfo.DataSource = equipmentLogic.FrmClaimSparePartBillAllInfo(strWhere);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void dgvInfo_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDetail.DataSource = equipmentLogic.FrmClaimSparePartBillSearchDetailInfo(dgvInfo.CurrentRow.Cells["id"].Value.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool status;

            List<long> list = new List<long> ();

            try
            {
                if (dgvInfo.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("是否要删除选中的“领料单？”", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //long id = Convert.ToInt64(dgvInfo.SelectedRows[0].Cells["id"].Value.ToString());

                        foreach (DataGridViewRow dr in dgvInfo.SelectedRows)
                        {
                            list.Add(long.Parse(dr.Cells["id"].Value.ToString()));
                        }

                        status = equipmentLogic.DeleteFrmClaimSparePartBill(list);

                        //status = equipmentLogic.DeleteFrmClaimSparePartBill(id);
                        if (status)
                        {
                            MessageBox.Show("删除成功！");
                        }
                        else
                        {
                            MessageBox.Show("删除时出错！！");
                        }
                        dgvInfo.DataSource = equipmentLogic.FrmClaimSparePartBillAllInfo("");

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

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

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ClaimSparePartBillDataSetTableAdapters.claimSparePartBillTableAdapter", "claimSparePartBill", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.ClaimSparePartBillDataSet";
                reportData.ReportName = "DasherStation.Report.ClaimSparePartBillReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }
    }
}
