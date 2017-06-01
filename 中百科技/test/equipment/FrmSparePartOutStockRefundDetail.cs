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
    public partial class FrmSparePartOutStockRefundDetail : common.BaseForm
    {
        EquipmentLogic equipmentLogic = new EquipmentLogic();

        OutStockClass OSClass = new OutStockClass();

        OutStockBillDetailClass OSBDClass = new OutStockBillDetailClass();

        FrmEquipmentService formEquipmentService = new FrmEquipmentService();

        FormHelper formHelper = new FormHelper();

        SqlHelper sqlHelperObj = new SqlHelper();

        DataSet ds;

        int count1;
        int id;

        public FrmSparePartOutStockRefundDetail()
        {
            InitializeComponent();
        }

        private void FrmSparePartOutStockRefundDetail_Load(object sender, EventArgs e)
        {
            try
            {
                equipmentLogic.FrmSparePartOutStockRefundDetailInitialCbxOutNo(cbxOutNo);
                cbxOutNo.DisplayMember = "id";
                cbxOutNo.ValueMember = "id";
                cbxOutNo.SelectedIndex = -1;

                equipmentLogic.FrmSparePartClaimDetailInitialCbxStoreKeeper(cbxStoreKeeper);
                cbxStoreKeeper.DisplayMember = "name";
                //cbxStoreKeeper.ValueMember = "id";
                cbxStoreKeeper.SelectedIndex = -1;

                TableDetaildata();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
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
                table.Columns.Add("TCount");                             
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

        private List<OutStockBillDetailClass> GetTPDetail()
        {
            OutStockBillDetailClass OSBDClass = null;
            List<OutStockBillDetailClass> list = new List<OutStockBillDetailClass>();
            try
            {

                foreach (DataGridViewRow dgvr in dgvDetail.Rows)
                {
                    OSBDClass = new OutStockBillDetailClass();

                    OSBDClass.No = dgvr.Cells["no1"].Value.ToString();
                    OSBDClass.Sort = dgvr.Cells["sort"].Value.ToString();
                    OSBDClass.Name = dgvr.Cells["name1"].Value.ToString();
                    OSBDClass.Model = dgvr.Cells["model"].Value.ToString();
                    OSBDClass.Unit = dgvr.Cells["unit"].Value.ToString();
                    OSBDClass.UnitPrice = double.Parse(dgvr.Cells["unitPrice"].Value.ToString());
                    OSBDClass.Count = int.Parse(dgvr.Cells["count"].Value.ToString());
                    OSBDClass.TCount = int.Parse(dgvr.Cells["TCount"].Value.ToString());
                    OSBDClass.Sum = double.Parse(dgvr.Cells["sum1"].Value.ToString());
                    OSBDClass.InputDate = DateTime.Parse(dgvr.Cells["inputDate1"].Value.ToString());
                    OSBDClass.InputMan = dgvr.Cells["inputMan1"].Value.ToString();

                    list.Add(OSBDClass);
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

        private OutStockClass SetPara()
        {
            #region
            OutStockClass OSClass = new OutStockClass();
            try
            {
                OSClass.Fno1 = txtFNo.Text.Trim();
                //OSClass.DId2 = equipmentLogic.SearchDID2(txtFNo.Text.Trim());
                OSClass.CspbId = int.Parse(txtDrawNo.Text.Trim());
                OSClass.StoreKeeper = cbxStoreKeeper.Text.Trim();
                OSClass.OutStockDate = dtpTDate.Value;
                OSClass.InputDate1 = DateTime.Now;
                OSClass.InputMan1 = this.UserName;
                OSClass.TDate = dtpTDate.Value;
                OSClass.TID = int.Parse(cbxOutNo.SelectedValue.ToString().Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return OSClass;
            #endregion

        }

        public void SetParaDetail()
        {
            try
            {
                //OSBDClass.Id = cbxNo.SelectedValue.ToString().Trim();
                OSBDClass.No = cbxNo.SelectedValue.ToString().Trim(); //备件
                OSBDClass.Sort = txtSort.Text.Trim();
                OSBDClass.Name = txtName.Text.Trim();
                OSBDClass.Model = txtModel.Text.Trim();
                OSBDClass.Unit = txtUnit.Text.Trim();
                OSBDClass.UnitPrice = double.Parse(txtUnitPrice.Text.Trim());
                OSBDClass.Count = int.Parse(txtOutCount.Text.Trim());
                OSBDClass.TCount = int.Parse(txtTNo.Text.Trim());
                OSBDClass.Sum = (OSBDClass.UnitPrice) * (OSBDClass.TCount);
                OSBDClass.InputDate = DateTime.Now;
                OSBDClass.InputMan = this.UserName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void cbxOutNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //equipmentLogic.FrmSparePartOutStockRefundDetailLoadOutNo(int.Parse(cbxOutNo.SelectedValue.ToString()), txtFNo, txtDrawNo, txtDrawMan, txtDept, txtDrawDate, txtEquiNo, txtEName, txtOutDate);
                equipmentLogic.FrmSparePartOutStockRefundDetailLoadOutNo(int.Parse(cbxOutNo.SelectedValue.ToString()),txtDrawNo, txtDrawMan, txtDept, txtDrawDate, txtEquiNo, txtEName, txtOutDate);

                equipmentLogic.FrmSparePartOutStockRefundDetailInitialCbxNo(cbxNo, int.Parse(cbxOutNo.SelectedValue.ToString()));
                cbxNo.DisplayMember = "no";
                cbxNo.ValueMember = "id";
                cbxNo.SelectedIndex = -1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
        }

        private void cbxNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                equipmentLogic.FrmSparePartOutStockRefundDetailLoadEquipNo(cbxNo.SelectedValue.ToString(), txtSort, txtName, txtModel, txtUnit, txtUnitPrice, txtDrawQuantity, int.Parse(cbxOutNo.SelectedValue.ToString()), txtOutCount);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
           
        }

        private void FrmSparePartOutStockRefundDetail_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = formHelper.inputCheck(groupBox2);

                bool result2 = stockCheck();

                if (result2 == false)
                {
                    this.errorProvider1.SetError(txtTNo, "退库数量不能大于出库数量");
                    txtTNo.Clear();
                    return;
                }
                if (result && result2)
                {
                    SetParaDetail();

                    equipmentLogic.FrmSparePartOutStockRefundDetailAddNew(OSBDClass, ds.Tables[0]);

                    formEquipmentService.ClearCtrls(groupBox2);
                    dgvDetail.Rows[0].Selected = false;

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
        private bool stockCheck()
        {
           
            if ((int.Parse(txtTNo.Text.Trim())) <= (int.Parse(txtOutCount.Text.Trim())))
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
            try
            {
                if (dgvDetail.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dgvr in dgvDetail.SelectedRows)
                    {
                        this.dgvDetail.Rows.Remove(dgvr);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
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
                        txtTId.Text = id.ToString();

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
           
        }
        private void SaveAll()
        {
            try
            {

                List<OutStockBillDetailClass> list = GetTPDetail();

                OutStockClass OSClass = SetPara();

                id = Convert.ToInt32(equipmentLogic.SaveTOutStockBill(OSClass, list, int.Parse(cbxOutNo.SelectedValue.ToString().Trim())));

                if (id != 0)
                {
                    txtTId.Text = id.ToString();
                    equipmentLogic.SumOutStockAllDetail(id);
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
