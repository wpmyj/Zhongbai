using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.HumanResource
{
    public partial class FrmDepartment : DasherStation.common.BaseForm
    {
        private DepartmentLogic oModel = new DepartmentLogic();
        private EmployeeLogic oEmployeeModel = new EmployeeLogic();
        public FrmDepartment()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.BindDataGrid();
            this.BindYieldGroup();
            this.BindPosition();
            this.BindDepartment();
            this.BindEPInfo();
        }

        private void BindDataGrid()
        {
            this.dtgList.AutoGenerateColumns = false;
            this.dtgList.DataSource = this.oModel.GetDepartMents();
        }

        private void BindYieldGroup()
        {
            this.dtgYield.AutoGenerateColumns = false;
            this.dtgYield.DataSource = oEmployeeModel.GetYieldGroups();
        }

        private void BindPosition()
        {
            this.dtgPosition.AutoGenerateColumns = false;
            this.dtgPosition.DataSource = oEmployeeModel.GetPositions();
        }

        private void BindDepartment()
        {
            List<Department> datasource = new DepartmentLogic().GetDepartMents();            
            this.cboDepartment.DataSource = datasource;
            this.cboDepartment.DisplayMember = "name";
            this.cboDepartment.ValueMember = "id";
        }

        private void BindEPInfo()
        {
            this.cboEPInfo.DataSource = new EmployeeLogic().GetEPInfo().Tables[0];
            this.cboEPInfo.DisplayMember = "no";
            this.cboEPInfo.ValueMember = "id";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtNo.Text.Trim() == "")
            {
                CommUI.AlertError("部门编码不能为空!");
                return;
            }
            if (this.txtName.Text.Trim() == "")
            {
                CommUI.AlertError("部门名称不能为空!");
                return;
            }
            Department oEntity = new Department();
            oEntity.no = this.txtNo.Text.Trim();
            oEntity.name = this.txtName.Text.Trim();
            oEntity.inputDate = DateTime.Now;
            oEntity.inputMan = this.UserName;
            oEntity.remark = this.txtMemo.Text;            
            
            string strResult = new DepartmentLogic().Add(oEntity);
            if (string.IsNullOrEmpty(strResult) == false)
            {
                CommUI.AlertError(strResult);
                return;
            }
            this.txtNo.Text = "";
            this.txtName.Text = "";
            this.txtMemo.Text = "";
            this.BindDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dtgList.RowCount == 0
                || this.dtgList.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("确定要删除吗?", "请确认", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            int[] rowsID = (from System.Windows.Forms.DataGridViewRow row in this.dtgList.SelectedRows
                             select int.Parse(row.Cells[0].Value.ToString())).ToArray<int>();

            if (rowsID.Length == 0)
            {
                try
                {
                    rowsID = new int[1] { int.Parse(this.dtgList.CurrentRow.Cells[0].Value.ToString()) };
                }
                catch (System.Exception) { }
                if (rowsID.Length == 0) return;
            }
            try
            {
                new DepartmentLogic().Remove(rowsID);
            }
            catch
            {
                CommUI.AlertError("使用中的部门无法删除!");
            }
            this.BindDataGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOKYield_Click(object sender, EventArgs e)
        {
            if (this.txtYieldName.Text.Trim() == "")
            {
                CommUI.AlertError("生产班组名称不能为空!");
                return;
            }
            if (this.cboDepartment.Text.Trim() == "")
            {
                CommUI.AlertError("部门不能为空!");
                return;
            }
            if (this.cboEPInfo.Text.Trim() == "")
            {
                CommUI.AlertError("设备不能为空!");
                return;
            }
            ProduceTeam oEntity = new ProduceTeam();
            oEntity.name = this.txtYieldName.Text.Trim();
            oEntity.did = long.Parse(this.cboDepartment.SelectedValue.ToString());
            oEntity.count = long.Parse(this.txtPersonalCount.Text);
            oEntity.inputDate = DateTime.Now;
            oEntity.inputMan = this.UserName;
            oEntity.remark = this.txtYieldMemo.Text;
            oEntity.eiId = long.Parse(this.cboEPInfo.SelectedValue.ToString());

            string strResult = new EmployeeLogic().AddYieldGroup(oEntity);
            if (string.IsNullOrEmpty(strResult) == false)
            {
                CommUI.AlertError(strResult);
                return;
            }
            this.txtYieldName.Text = "";
            this.txtYieldMemo.Text = "";
            this.txtPersonalCount.Text = "10";
            this.BindYieldGroup();
        }

        private void btnDeleteYield_Click(object sender, EventArgs e)
        {
            if (this.dtgYield.RowCount == 0
                || this.dtgYield.SelectedRows.Count == 0)
            {
                return;
            }
            if (CommUI.Confirm("确定要删除吗?") == DialogResult.No)
            {
                return;
            }

            int[] rowsID = (from System.Windows.Forms.DataGridViewRow row in this.dtgYield.SelectedRows
                            select int.Parse(row.Cells[0].Value.ToString())).ToArray<int>();

            if (rowsID.Length == 0)
            {
                try
                {
                    rowsID = new int[1] { int.Parse(this.dtgYield.CurrentRow.Cells[0].Value.ToString()) };
                }
                catch (System.Exception) { }
                if (rowsID.Length == 0) return;
            }

            try
            {
                new EmployeeLogic().RemoveYieldGroup(rowsID);                
            }
            catch
            {
                CommUI.AlertError("使用中的生产班组无法删除!");                
            }
            this.BindYieldGroup();
        }

        private void btnOKPosition_Click(object sender, EventArgs e)
        {
            if (this.txtPositionName.Text.Trim() == "")
            {
                CommUI.AlertError("职位名称不能为空!");
                return;
            }
            Position oEntity = new Position();
            oEntity.inputDate = DateTime.Now;
            oEntity.inputMan = this.UserName;
            oEntity.name = this.txtPositionName.Text;
            string strResult = new EmployeeLogic().AddPosition(oEntity);
            if(string.IsNullOrEmpty(strResult) == false)
            {
                CommUI.AlertError(strResult);
                return;
            }
            this.txtPositionName.Text = "";
            this.BindPosition();
        }

        private void btnDeletePosition_Click(object sender, EventArgs e)
        {
            if (this.dtgPosition.RowCount == 0
                || this.dtgPosition.SelectedRows.Count == 0)
            {
                return;
            }
            if (CommUI.Confirm("确定要删除吗?") == DialogResult.No)
            {
                return;
            }

            int[] rowsID = (from System.Windows.Forms.DataGridViewRow row in this.dtgPosition.SelectedRows
                            select int.Parse(row.Cells[0].Value.ToString())).ToArray<int>();

            if (rowsID.Length == 0)
            {
                try
                {
                    rowsID = new int[1] { int.Parse(this.dtgPosition.CurrentRow.Cells[0].Value.ToString()) };
                }
                catch (System.Exception) { }
                if (rowsID.Length == 0) return;
            }

            try
            {
                new EmployeeLogic().RemovePosition(rowsID);
            }
            catch
            {
                CommUI.AlertError("使用中的职位无法删除!");
            }
            this.BindPosition();
        }

    }



}
