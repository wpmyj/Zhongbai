/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：FrmPayroll.cs
* 文件功能描述：人力资源工资项录入窗体
*
* 创建人： 杨林
* 创建时间：2009-03-05
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

namespace DasherStation.HumanResource
{
    /// <summary>
    /// 工资项录入窗体
    /// </summary>
    public partial class FrmPayroll : DasherStation.common.BaseForm
    {
        public FrmPayroll()
        {
            InitializeComponent();
        }

        private void BindDataGrid()
        {
            this.dtgList.AutoGenerateColumns = false;
            this.dtgList.DataSource = new PayrollLogic().GetAllPayroll().Tables[0];
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.cboAddType.SelectedIndex = 0;
            this.cboHumanType.SelectedIndex = 0;
            this.cboSub.SelectedIndex = 0;
            this.BindDataGrid();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtPayName.Text.Trim() == "")
            {
                MessageBox.Show("工资项名不能为空！","提示");
                return;
            }
            PayrollAdd oEntity = new PayrollAdd();
            oEntity.name = this.txtPayName.Text;
            oEntity.inputDate = DateTime.Now;
            oEntity.inputMan = this.UserName;
            oEntity.remark = this.txtMemo.Text;
            oEntity.kind = this.cboHumanType.SelectedIndex;
            if (this.cboAddType.SelectedIndex == 0)
            {
                oEntity.minusPlace = this.cboSub.SelectedIndex == 0 ? false:true;
            }
            oEntity.mark = this.cboAddType.SelectedIndex == 0 ? false:true;
            string strResult = new PayrollLogic().AddPayroll(oEntity);
            if (strResult != "")
            {
                System.Windows.Forms.MessageBox.Show(strResult);
                return;
            }
            this.txtPayName.Text = "";
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
            
            long[] rowsID = (from System.Windows.Forms.DataGridViewRow row in this.dtgList.SelectedRows
                               select long.Parse(row.Cells[0].Value.ToString())).ToArray<long>();
           
            if (rowsID.Length == 0)
            {
                try
                {
                    rowsID = new long[1] { long.Parse(this.dtgList.CurrentRow.Cells[0].Value.ToString()) };
                }catch(System.Exception){                }
                if (rowsID.Length == 0) return;
            }

            string strResult = new PayrollLogic().RemovePayroll(rowsID);
            if (strResult != "")
            {
                System.Windows.Forms.MessageBox.Show(strResult, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.BindDataGrid();
        }

        private void cboAddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboAddType.SelectedIndex == 0)
            {
                this.cboSub.Enabled = true;
            }
            else
            {
                this.cboSub.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
