/*
      * 版权单位：沈阳中百科技有限公司
      *
      * 文件名：FrmEquipmentFillOil.cs
      * 文件功能描述：设备加油记录
      *
      * 创建人：夏阳明
      * 创建时间：2009-03-20
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
using DasherStation.transport;
using DasherStation.common;

namespace DasherStation.equipment
{
    public partial class FrmEquipmentFillOil : common.BaseForm
    {
        EquipmentLogic equipmentLogic = new EquipmentLogic();

        EquipmentFillOilClass EFOClass = new EquipmentFillOilClass();

        FormHelper formHelper = new FormHelper();

        SqlHelper sqlHelperObj = new SqlHelper();

        FrmEquipmentService ES = new FrmEquipmentService();

        DataTable dt;

        DoCombox doCombox;

        int count;


        public FrmEquipmentFillOil()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            count = dgvDetail.RowCount;

            if (count != 0)
            {
                equipmentLogic.FrmEquipmentFillOilSaveAll(getDetailInfo());

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

        private void FrmEquipmentFillOil_Load(object sender, EventArgs e)
        {
            equipmentLogic.FrmEquipmentServiceInitialCbxENO(cbxENO);
            cbxENO.DisplayMember = "no";
            cbxENO.ValueMember = "no";
            cbxENO.SelectedIndex = -1;

            cbxOilUnit.SelectedIndex = -1;

            cbxFillOilMan.SelectedIndex = -1;

            dt = equipmentLogic.FrmEquipmentFillOilCreatTable();
            dt.TableName = "Mine";
            dgvDetail.DataSource = dt;

            ES.QueryBind(cbxQuery);
            cbxQuery.SelectedIndex = -1;

            equipmentLogic.FrmEquipmentServiceInitialCbxFillOilMan(cbxFillOilMan);
            cbxFillOilMan.DisplayMember = "name";
            cbxFillOilMan.ValueMember = "name";
            cbxFillOilMan.SelectedIndex = -1;

            doCombox = new DoCombox(cbxOilSort, cbxOilName, cbxOilModel, TransportLogic.TranType.material);

            dgvDetail.DataSource = equipmentLogic.FrmEquipmentFillOilAllInfo("");
        }

        private void cbxENO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            equipmentLogic.FrmEquipmentServiceLoadEquipNo(cbxENO.SelectedValue.ToString(), txtSort, txtName, txtModel);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dgvDetail.DataSource as DataTable;

            if (dataTable != null)
            {
                if (formHelper.inputCheck(gbSingle))
                {
                    if (!dataTable.TableName.Equals("Mine"))
                    {
                        dgvDetail.DataSource = dt;
                    }
                    add_row();
                    ES.ClearCtrls(gbSingle);
                    dgvDetail.Rows[0].Selected = false;
                }
            }
        }

        private void add_row()
        {
            DataRow dr = dt.NewRow();

            dr["no"] = cbxENO.SelectedValue.ToString();
            dr["sort"] = txtSort.Text.Trim();
            dr["name"] = txtName.Text.Trim();
            dr["model"] = txtModel.Text.Trim();
            dr["fillOilDate"] = Convert.ToDateTime(dtpFillOilDate.Text.Trim());
            //dr["oilName"] = txtOilName.Text.Trim();
            dr["Name1"] = cbxOilName.Text.Trim();
            //dr["oilModel"] = txtOilModel.Text.Trim();
            dr["Model1"] = cbxOilModel.Text.Trim();
            dr["quantity"] = Double.Parse(txtOilQuantity.Text.Trim());
            dr["unit"] = cbxOilUnit.Text.Trim();
            dr["sum"] = ((Double.Parse(txtOilQuantity.Text.Trim())) * (Double.Parse(txtUnitPrice.Text.Trim())));
            dr["unitPrice"] = Double.Parse(txtUnitPrice.Text.Trim());
            dr["fillOilMan"] = cbxFillOilMan.Text.Trim();
            dr["fno"] = txtFNO.Text.Trim();
            dr["inputDate"] = System.DateTime.Now;
//            dr["dasherName"] = equipmentLogic.FrmEquipmentServiceSearchDasherName();
            dr["inputMan"] = this.UserName;
            dr["remark"] = txtRemark.Text.Trim();
            dr["mId"] = equipmentLogic.FrmEquipmentFillOilGetMid(cbxOilName.SelectedValue.ToString(), cbxOilModel.SelectedValue.ToString());

            dt.Rows.Add(dr);
        }

        private List<EquipmentFillOilClass> getDetailInfo()
        {

            EquipmentFillOilClass EFOClass;

            List<EquipmentFillOilClass> list = new List<EquipmentFillOilClass>();

            foreach (DataGridViewRow dgvr in dgvDetail.Rows)
            {
                EFOClass = new EquipmentFillOilClass();

                EFOClass.No = dgvr.Cells["no"].Value.ToString();
                EFOClass.Sort = dgvr.Cells["sort"].Value.ToString();
                EFOClass.Name = dgvr.Cells["name"].Value.ToString();
                EFOClass.Model = dgvr.Cells["model"].Value.ToString();
                EFOClass.FillOilDate = Convert.ToDateTime(dgvr.Cells["fillOilDate"].Value.ToString());
                EFOClass.OilName = dgvr.Cells["oilName"].Value.ToString();
                EFOClass.OilModel = dgvr.Cells["oilModel"].Value.ToString();
                EFOClass.Quantity = Double.Parse(dgvr.Cells["quantity"].Value.ToString());
                EFOClass.Unit = dgvr.Cells["unit"].Value.ToString();
                EFOClass.Sum = Double.Parse(dgvr.Cells["sum"].Value.ToString());
                EFOClass.UnitPrice = Double.Parse(dgvr.Cells["unitPrice"].Value.ToString());
                EFOClass.FillOilMan = dgvr.Cells["fillOilMan"].Value.ToString();
                EFOClass.Fno = dgvr.Cells["fno"].Value.ToString();
                EFOClass.InputDate = DateTime.Parse(dgvr.Cells["inputDate"].Value.ToString());
 //               EFOClass.DasherName = dgvr.Cells["dasherName"].Value.ToString();
                EFOClass.InputMan = dgvr.Cells["inputMan"].Value.ToString();
                EFOClass.Remark = dgvr.Cells["remark"].Value.ToString();
                EFOClass.Id = int.Parse(dgvr.Cells["mId"].Value.ToString());

                list.Add(EFOClass);
            }

            return list;
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
                if (dgvDetail.Rows.Count != 0)
                {
                    dgvDetail.Rows[0].Selected = false;
                }
            }
            else
            {
                dgvDetail.DataSource = equipmentLogic.FrmEquipmentFillOilAllInfo("");
                if (dgvDetail.Rows.Count != 0)
                {
                    dgvDetail.Rows[0].Selected = false;
                }
            }
        }
        private void dataBind(string strWhere)
        {
            this.dgvDetail.DataSource = equipmentLogic.FrmEquipmentFillOilAllInfo(strWhere);
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

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
