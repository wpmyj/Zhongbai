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
    public partial class FrmPayoffAudit : DasherStation.common.BaseForm
    {
        public FrmPayoffAudit()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.cboPayoffName.DataSource = new PayOffLogic().GetPayoffName();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet dtsResult = new PayOffLogic().GetPayAudit(this.datePayOff.Value.Year, this.datePayOff.Value.Month, this.cboPayoffName.Text.Trim());

            dtgList.DataSource = dtsResult.Tables[0];
            dtgList.Columns["id"].Visible = false;
            dtgList.Columns[0].Frozen = true;
        }

        private void btnAudit1_Click(object sender, EventArgs e)
        {
            if (this.dtgList.SelectedRows.Count > 0)
            {
                var oModel = new PayOffLogic();
                if (MessageBox.Show("确定要审核通过吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in this.dtgList.SelectedRows)
                    {
                        oModel.Assess(long.Parse(dgvr.Cells["id"].Value.ToString()), true, this.UserName);
                    }
                }
                else
                {
                    foreach (DataGridViewRow dgvr in this.dtgList.SelectedRows)
                    {
                        oModel.Assess(long.Parse(dgvr.Cells["id"].Value.ToString()), false, this.UserName);
                    }
                }
                this.btnSearch_Click(null, null);
            }
            else
            {
                CommUI.AlertError("请选择数据行!");
            }
        }

        private void btnAudit2_Click(object sender, EventArgs e)
        {
            if (this.dtgList.SelectedRows.Count > 0)
            {
                var oModel = new PayOffLogic();
                if (MessageBox.Show("确定要审批通过吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in this.dtgList.SelectedRows)
                    {
                        oModel.Checkup(long.Parse(dgvr.Cells["id"].Value.ToString()), true, this.UserName);
                    }
                }
                else
                {
                    foreach (DataGridViewRow dgvr in this.dtgList.SelectedRows)
                    {
                        oModel.Checkup(long.Parse(dgvr.Cells["id"].Value.ToString()), false, this.UserName);
                    }
                }
                this.btnSearch_Click(null, null);
            }
            else
            {
                CommUI.AlertError("请选择数据行!");
            }         
        }

    }
}
