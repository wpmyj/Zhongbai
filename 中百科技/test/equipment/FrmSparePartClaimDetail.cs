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

namespace DasherStation.equipment
{
    public partial class FrmSparePartClaimDetail : common.BaseForm
    {
        EquipmentLogic equipmentLogic = new EquipmentLogic();

        ClaimSparePartBillClass CSPBClass = new ClaimSparePartBillClass();

        ClaimSparePartBillDetailClass CSPBDClass = new ClaimSparePartBillDetailClass();

        FormHelper formHelper = new FormHelper();

        SqlHelper sqlHelperObj = new SqlHelper();

        FrmEquipmentService formEquipmentService = new FrmEquipmentService();

        DataTable dt;

        DataSet ds;

        int id;

        int count1;

        public FrmSparePartClaimDetail()
        {
            InitializeComponent();
        }

        private void FrmSparePartClaimDetail_Load(object sender, EventArgs e)
        {
            equipmentLogic.FrmSparePartClaimDetailInitialCbxNo(cbxNo);
            cbxNo.DisplayMember = "no";
            cbxNo.ValueMember = "no";
            cbxNo.SelectedIndex = -1;

            equipmentLogic.FrmSparePartClaimDetailInitialCbxDrawDepartment(cbxDrawDepartment);
            cbxDrawDepartment.DisplayMember = "name";
            cbxDrawDepartment.ValueMember = "id";
            cbxDrawDepartment.SelectedIndex = -1;

            equipmentLogic.FrmSparePartClaimDetailInitialCbxENo(cbxENo);
            cbxENo.DisplayMember = "no";
            cbxENo.ValueMember = "id";
            cbxENo.SelectedIndex = -1;

            equipmentLogic.FrmSparePartClaimDetailInitialCbxFileNo(cbxFileNo);
            cbxFileNo.DisplayMember = "no";
            cbxFileNo.ValueMember = "id";
            cbxFileNo.SelectedIndex = -1;

            TableDetaildata();

        }

        private void cbxNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            equipmentLogic.FrmSparePartClaimDetailLoadEquipNo(cbxNo.SelectedValue.ToString(), txtSort, txtName, txtModel, txtUnit, txtUnitPrice, txtStockQuantity);
        }
        private void TableDetaildata()
        {
            try
            {
                DataTable table = new DataTable();
                ds = new DataSet();

                table.Columns.Add("no");
                table.Columns.Add("sort");
                table.Columns.Add("name");
                table.Columns.Add("model");
                table.Columns.Add("unit");
                table.Columns.Add("unitPrice");
                table.Columns.Add("count");
                table.Columns.Add("sum");
                table.Columns.Add("inputDate");
                table.Columns.Add("inputMan");

                ds.Tables.Add(table);

                dgvDetail.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }
        private List<ClaimSparePartBillDetailClass> GetTPDetail()
        {
            ClaimSparePartBillDetailClass CSPBDClass = null;
            List<ClaimSparePartBillDetailClass> list = new List<ClaimSparePartBillDetailClass>();
            try
            {

                foreach (DataGridViewRow dgvr in dgvDetail.Rows)
                {
                    CSPBDClass = new ClaimSparePartBillDetailClass();

                    CSPBDClass.No = dgvr.Cells["no"].Value.ToString();
                    CSPBDClass.Sort = dgvr.Cells["sort"].Value.ToString();
                    CSPBDClass.Name = dgvr.Cells["name"].Value.ToString();
                    CSPBDClass.Model = dgvr.Cells["model"].Value.ToString();
                    CSPBDClass.Unit = dgvr.Cells["unit"].Value.ToString();
                    CSPBDClass.UnitPrice = double.Parse(dgvr.Cells["unitPrice"].Value.ToString());
                    CSPBDClass.Count = int.Parse(dgvr.Cells["count"].Value.ToString());
                    CSPBDClass.Sum = double.Parse(dgvr.Cells["sum"].Value.ToString());
                    CSPBDClass.InputDate = DateTime.Parse(dgvr.Cells["inputDate"].Value.ToString());
                    CSPBDClass.InputMan = dgvr.Cells["inputMan"].Value.ToString();

                    list.Add(CSPBDClass);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return list;

        }
        private ClaimSparePartBillClass SetPara()
        {
            #region
            ClaimSparePartBillClass CSPBClass = new ClaimSparePartBillClass();
            try
            {
                CSPBClass.Fno = cbxFileNo.Text.Trim();
                CSPBClass.ClaimDate = DateTime.Parse(dtpDrawDate.Text.Trim());
                CSPBClass.ClaimMan = txtDrawMan.Text.Trim();
                CSPBClass.DId = int.Parse(cbxDrawDepartment.SelectedValue.ToString());
                CSPBClass.EiId = int.Parse(cbxENo.SelectedValue.ToString());
                CSPBClass.InputDate = DateTime.Now;
                CSPBClass.InputMan = this.UserName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return CSPBClass;
            #endregion

        }

        private void cbxENo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            equipmentLogic.FrmSparePartClaimDetailSearchEName(cbxENo.SelectedValue.ToString().Trim(),txtEName);
        }

        private void FrmSparePartClaimDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定关闭窗口吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true; ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
        public void SetParaDetail()
        {
            try
            {
                CSPBDClass.No = cbxNo.SelectedValue.ToString().Trim();
                CSPBDClass.Sort = txtSort.Text.Trim();
                CSPBDClass.Name = txtName.Text.Trim();
                CSPBDClass.Model = txtModel.Text.Trim();
                CSPBDClass.Unit = txtUnit.Text.Trim();
                CSPBDClass.UnitPrice = double.Parse(txtUnitPrice.Text.Trim());
                CSPBDClass.Count = int.Parse(txtCount.Text.Trim());
                CSPBDClass.Sum = (CSPBDClass.UnitPrice) * (CSPBDClass.Count);
                CSPBDClass.InputDate = DateTime.Now;
                CSPBDClass.InputMan = this.UserName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bool result = formHelper.inputCheck(groupBox2);

            if (result)
            {
                bool result2 = stockCheck();

                if (result2 == false)
                {
                    this.errorProvider1.SetError(txtCount, "领料数量不能大于库存数量");
                    txtCount.Clear();
                    return;
                }
                if (result && result2)
                {
                    SetParaDetail();

                    equipmentLogic.FrmSparePartClaimDetailAddNew(CSPBDClass, ds.Tables[0]);

                    formEquipmentService.ClearCtrls(groupBox2);
                    dgvDetail.Rows[0].Selected = false;
                }
            }
            
        }
        private bool stockCheck()
        {
            if ((int.Parse(txtCount.Text.Trim())) <= (int.Parse(txtStockQuantity.Text.Trim())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dgvr in dgvDetail.SelectedRows)
                {
                    this.dgvDetail.Rows.Remove(dgvr);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = formHelper.inputCheck(groupBox1);

            if (result)
            {
                count1 = dgvDetail.RowCount;

                if (count1 != 0)
                {
                    SaveAll();
                    for (int i = 0; i < count1; i++)
                    {
                        this.dgvDetail.Rows.Remove(dgvDetail.Rows[0]);
                    }
                    formEquipmentService.ClearCtrls(groupBox1);
                    txtDrawNo.Text = id.ToString();

                }
                else
                {
                    if (MessageBox.Show("还没有输入详细信息，确定退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) ==
                                 DialogResult.OK)
                    {
                        this.Close();
                    }

                }
            }
        }

        private void SaveAll()
        {
            try
            {

                List<ClaimSparePartBillDetailClass> list = GetTPDetail();

                ClaimSparePartBillClass CSPBClass = SetPara();

                id = Convert.ToInt32(equipmentLogic.SaveClaimSparePartAdd(CSPBClass, list).ToString());

                if (id != 0)
                {
                    txtDrawNo.Text = id.ToString();
                    equipmentLogic.SumAllDetail(id);
                    // this.DialogResult = DialogResult.OK;
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败，请重新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }
    }
}
