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
    public partial class FrmSparePartBasicInfo : common.BaseForm
    {
        EquipmentLogic equipmentLogic = new EquipmentLogic();

        SparePartBasicInfoClass SPBIClass = new SparePartBasicInfoClass();

        FormHelper formHelper = new FormHelper();

        SqlHelper sqlHelperObj = new SqlHelper();

        FrmEquipmentService ES = new FrmEquipmentService();

        DataTable dt;

        DataSet ds;

        int count;


        public FrmSparePartBasicInfo()
        {
            InitializeComponent();
        }

        private void FrmSparePartBasicInfo_Load(object sender, EventArgs e)
        {
            try
            {
                dt = equipmentLogic.FrmSparePartBasicInfoCreatTable();
                dt.TableName = "Mine";
                dgvDetail.DataSource = dt;

                QueryBind(cbxQuery);
                cbxQuery.SelectedIndex = -1;

                ds = equipmentLogic.FrmSparePartBasicInfoInitialSort();
                cbxSort.DataSource = ds.Tables[0];
                cbxSort.DisplayMember = "sort";
         //       cbxSort.ValueMember = "id";
                cbxSort.SelectedIndex = -1;

                dgvDetail.DataSource = equipmentLogic.FrmSparePartBasicInfoAllInfo("");
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
                row["id"] = "SPBI.no";
                row["Value"] = "备件编号";
                table.Rows.Add(row);

                row = table.NewRow();
                row["id"] = "SPBI.sort";
                row["Value"] = "备件种类";
                table.Rows.Add(row);

                row = table.NewRow();
                row["id"] = "SPBI.name";
                row["Value"] = "备件名称";
                table.Rows.Add(row);

                row = table.NewRow();
                row["id"] = "SPBI.model";
                row["Value"] = "规格型号";
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
            DataTable dataTable = dgvDetail.DataSource as DataTable;

            try
            {
                if (dataTable != null)
                {
                    if (dataTable.TableName.Equals("Mine"))
                    {
                        bool result = formHelper.inputCheck(groupBox2);

                        if (result)
                        {
                            if ((int.Parse(txtMaxStock.Text.Trim())) > (int.Parse(txtMinStock.Text.Trim())))
                            {
                                add_row();
                                ES.ClearCtrls(groupBox2);
                                dgvDetail.Rows[0].Selected = false;
                            }
                            else
                            {
                                MessageBox.Show("最大库存应大于最低库存，请正确填写", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtMaxStock.Clear();
                                txtMinStock.Clear();
                                return;
                            }

                        }
                    }
                    else
                    {
                        dgvDetail.DataSource = dt;
                        bool result = formHelper.inputCheck(groupBox2);

                        if (result)
                        {
                            if ((int.Parse(txtMaxStock.Text.Trim())) > (int.Parse(txtMinStock.Text.Trim())))
                            {
                                add_row();
                                ES.ClearCtrls(groupBox2);
                                dgvDetail.Rows[0].Selected = false;
                            }
                            else
                            {
                                MessageBox.Show("最大库存应大于最低库存，请正确填写", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtMaxStock.Clear();
                                txtMinStock.Clear();
                                return;
                            }
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

        private void add_row()
        {
            DataRow dr = dt.NewRow();

            try
            {
                dr["no"] = txtNo.Text.Trim();
                //dr["sort"] = txtSort.Text.Trim();
                dr["sort"] = cbxSort.Text.Trim();
                dr["name"] = txtName.Text.Trim();
                dr["model"] = txtModel.Text.Trim();
                dr["maxStock"] = txtMaxStock.Text.Trim();
                dr["minStock"] = txtMinStock.Text.Trim();
                dr["unit"] = txtUnit.Text.Trim();
                dr["inputDate"] = System.DateTime.Now;
                dr["inputMan"] = this.UserName;

                dt.Rows.Add(dr);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
        }

        private List<SparePartBasicInfoClass> getDetailInfo()
        {

            SparePartBasicInfoClass SPBIClass;

            List<SparePartBasicInfoClass> list = new List<SparePartBasicInfoClass>();

            try
            {
                foreach (DataGridViewRow dgvr in dgvDetail.Rows)
                {
                    SPBIClass = new SparePartBasicInfoClass();

                    SPBIClass.No = dgvr.Cells["no"].Value.ToString();
                    SPBIClass.Sort = dgvr.Cells["sort"].Value.ToString();
                    SPBIClass.Name = dgvr.Cells["name"].Value.ToString();
                    SPBIClass.Model = dgvr.Cells["model"].Value.ToString();
                    SPBIClass.MaxStock = dgvr.Cells["maxStock"].Value.ToString();
                    SPBIClass.MinStock = dgvr.Cells["minStock"].Value.ToString();
                    SPBIClass.Unit = dgvr.Cells["unit"].Value.ToString();
                    SPBIClass.InputDate = DateTime.Parse(dgvr.Cells["inputDate"].Value.ToString());
                    SPBIClass.InputMan = dgvr.Cells["inputMan"].Value.ToString();

                    list.Add(SPBIClass);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
           
            return list;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string str = txtQueryStr.Text.Trim();
            try
            {
                if ((this.cbxQuery.SelectedIndex != -1) && (!(string.IsNullOrEmpty(str))))
                {
                    //if (!Check.CheckQueryIsEmpty(str))
                    //{
                    //    MessageBox.Show("查询关键字中不能包含特殊字符或空格", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    bool result = formHelper.inputCheck(groupBox1);
                    if (result)
                    {
                        string SqlStr = this.cbxQuery.SelectedValue.ToString() + " like '%" + str + "%'";
                        dataBind(SqlStr);
                        if (dgvDetail.Rows.Count != 0)
                        {
                            dgvDetail.Rows[0].Selected = false;
                        }
                    }
                }
                else
                {
                    dgvDetail.DataSource = equipmentLogic.FrmSparePartBasicInfoAllInfo("");
                    if (dgvDetail.Rows.Count != 0)
                    {
                        dgvDetail.Rows[0].Selected = false;
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
                this.dgvDetail.DataSource = equipmentLogic.FrmSparePartBasicInfoAllInfo(strWhere);
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
            count = dgvDetail.RowCount;
            try
            {
                if (count != 0)
                {
                    equipmentLogic.FrmSparePartBasicInfoSaveAll(getDetailInfo());

                    for (int i = 0; i < count; i++)
                    {
                        this.dgvDetail.Rows.Remove(dgvDetail.Rows[0]);
                    }
                    MessageBox.Show("保存成功！");

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtQueryStr_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxQuery_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
