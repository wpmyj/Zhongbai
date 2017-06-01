/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：FrmSalseProgram.cs
     * 文件功能描述：销售计划
     *
     * 创建人：
     * 创建时间：
     *
     * 修改人：付中华
     * 修改时间：2009-4-17
     * 修改内容：所有错误和评审后的修改建议
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
using DasherStation.common;
using DasherStation.ReportDistrict.sellReport;

namespace DasherStation.sell
{
    public partial class FrmSalseProgram : common.BaseForm
    {
        public FrmSalseProgram()
        {
            InitializeComponent();
        }
        // 2009-4-18 修改人：付中华
        // 用来做审核审批用
        AuditingAction auditingAction = new AuditingAction("id", "sellPlan");

        SellPlanLogic sPLogic = new SellPlanLogic();

        #region 为销售计划主表赋值
        private void DataGridView()
        {
            //string begin_year = (dtp_BeginYear.Value.Year).ToString();
            //string end_year = (dtp_endYear.Value.Year).ToString();

            // 2009-4-17 修改人付中华 
            //首先要对输入的年份进行校验
            if (!Check.CheckEmpty(txtStartYear.Text))
            {
                MessageBox.Show("年份不能为空，请输入年份！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (!Check.CheckNumber(txtStartYear.Text))
            {
                MessageBox.Show("有非法字符,请输入正确的年份，如“2009”！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (!Check.CheckEmpty(txtEndYear.Text))
            {
                MessageBox.Show("年份不能为空，请输入年份！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (!Check.CheckNumber(txtEndYear.Text))
            {
                MessageBox.Show("有非法字符,请输入正确的年份，如“2009”！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            string begin_year = txtStartYear.Text;
            string end_year = txtEndYear.Text;
            dgvPurchasePlan.DataSource = sPLogic.FrmSPlanSearch(begin_year,end_year);
            dgvPurchasePlan.Columns["id"].Visible = false;
            dgvPurchasePlan.Columns["录入人"].Visible = false;

            // 2009-4-17 修改人付中华 
            // 对于个字段显示的宽度予以设置
            dgvPurchasePlan.Columns["制作日期"].Width = 120;
            dgvPurchasePlan.Columns["销售计划年份"].Width = 120;
            dgvPurchasePlan.Columns["销售计划制作人"].Width = 120;
            dgvPurchasePlan.Columns["审核人"].Width = 100;
            dgvPurchasePlan.Columns["审批人"].Width = 100;
            dgvPurchasePlan.Columns["备注"].Width = 100;

        }
        #endregion
        
        #region 主表变化,从表也跟着变化;
        //主表变化,从表也跟着变化
        private void DataGridviewChange()
        {
            
            if (dgvPurchasePlan.CurrentRow != null)
            {
                long sellPlanId;

                sellPlanId = Convert.ToInt64(dgvPurchasePlan.CurrentRow.Cells[0].Value.ToString());

                dgvPurchaseDetail.DataSource = sPLogic.FrmSPlanDetailSearch(sellPlanId);
            }
            //else
            //{
            //    dgvPurchaseDetail.DataSource = sPLogic.FrmSPlanDetailSearch(0);
            //}

            dgvPurchaseDetail.Columns["id"].Visible = false;
        }
        #endregion 

        #region 审核操作
        private DialogResult assess()
        {
            DialogResult result = MessageBox.Show("是否同意审核操作", "提示", MessageBoxButtons.YesNo);
            return result;
        }
        #endregion

        #region 审批操作
        private DialogResult checkup()
        {
            DialogResult result = MessageBox.Show("是否同意审批操作", "提示", MessageBoxButtons.YesNo);
            return result;
        }
        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmVenditionPlan frmVenditionPlan= new FrmVenditionPlan();
            if (frmVenditionPlan.ShowDialog(this) == DialogResult.OK)
            {
                DataGridView();
                DataGridviewChange();
            }
        }

        private void FrmSalseProgram_Load(object sender, EventArgs e)
        {
            // 2009-4-17  修改人：付中华 
            //增加初始化窗体时给年份赋默认值 
            txtStartYear.Text = DateTime.Now.Year.ToString();
            txtEndYear.Text = DateTime.Now.Year.ToString();

            this.userName = "fzh";
            //初始化销售计划;
            DataGridView();
            if (dgvPurchasePlan.CurrentRow != null)
            {
                long sellPlanId;

                sellPlanId = Convert.ToInt64(dgvPurchasePlan.CurrentRow.Cells[0].Value.ToString());

                dgvPurchaseDetail.DataSource = sPLogic.FrmSPlanDetailSearch(sellPlanId);
            }
            
            //初始化销售计划明细;
            //DataGridviewChange();
            //setButtonVisible(dgvPurchasePlan, btn_Assess, btn_Checkup);
           
            
        }
        // 在审核审批前要判断是否已经审核审批过了如果已经审核审批过了就让审核审批按钮不可用
        //private void setButtonVisible(DataGridView dgvr,Button btnAssessor,Button btnCheckup)
        //{
        //    if (dgvr.SelectedRows.Count == 1)
        //    {
        //        if (dgvr.SelectedRows[0].Cells["审核人"].Value.ToString() != "")
        //            btnAssessor.Enabled = false;
        //        else
        //            btnAssessor.Enabled = true;
        //        if (dgvr.SelectedRows[0].Cells["审批人"].Value.ToString() != "")
        //            btnCheckup.Enabled = false;
        //        else
        //            btnCheckup.Enabled = true;
        //    }
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvPurchasePlan.SelectedRows.Count == 1)
            {
                if (dgvPurchasePlan.SelectedRows[0].Cells["审核人"].Value.ToString() != "")
                {
                    MessageBox.Show("已审核或者审批过的计划不允许删除！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }
                DialogResult strDelete = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.YesNo);

                if (strDelete.ToString().Equals("No"))
                {
                    return;
                }

                if (this.dgvPurchasePlan.SelectedRows.Count == 1)
                {
                    int sellPlanId;

                    sellPlanId = Convert.ToInt32(dgvPurchasePlan.CurrentRow.Cells[0].Value.ToString());
                   
                    if (sPLogic.FrmSPlanDelete(sellPlanId))
                    {
                        //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridView();
                        DataGridviewChange();
                    }
                    else
                    {
                        MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
       
                    }              
            }
            else
            {
                MessageBox.Show("请选中一条记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvPurchasePlan.SelectedRows.Count > 0)
            {
                ReportSellClass report = new ReportSellClass();
                long id = 0;
                long.TryParse(dgvPurchasePlan.SelectedRows[0].Cells["id"].Value.ToString(),out id);

                report.RunYearSellPlan(id);
            }
        }

        private void dgvPurchasePlan_SelectionChanged(object sender, EventArgs e)
        {
            DataGridviewChange();
            //setButtonVisible(dgvPurchasePlan, btn_Assess, btn_Checkup);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataGridView();
            if (dgvPurchasePlan.Rows.Count == 0)
            {
                deleteDetailDataGridView(dgvPurchaseDetail);
            }
        }
        // 此方法用与当主datagridview的内容为空时 从的datagridview 如果不为空将其全部删除
        private void deleteDetailDataGridView(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow dgvr in dgv.Rows)
                {
                    dgv.Rows.Remove(dgvr);
                }
            }
        }

        private void btn_Assess_Click(object sender, EventArgs e)
        {
            //if (dgvPurchasePlan.CurrentRow != null)
            //{
            //    if (dgvPurchasePlan.CurrentRow.Cells["审核"].Value.ToString() == "已审核")
            //    {
            //        MessageBox.Show("该记录已审核完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    var estate = assess();
            //    if (estate.ToString().Equals("Yes"))
            //    {
            //        long id = Convert.ToInt64(dgvPurchasePlan.CurrentRow.Cells[0].Value.ToString());
            //        if (sPLogic.Plan_Assess(id, this.userName))
            //        {
            //            MessageBox.Show("审核成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            DataGridView();
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("未选中任何一条记录，请选中一条记录后进行审核操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            // 2009-4-18 修改人：付中华
            // 用来审核
            long status;
            if (dgvPurchasePlan.SelectedRows.Count > 0)
            {
                if (dgvPurchasePlan.SelectedRows[0].Cells["审核人"].Value.ToString() != "")
                {
                    MessageBox.Show("已经审核过的计划不能再审核！");
                    return;
                }
                if (MessageBox.Show("是否确认审核选中销售计划", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dgvPurchasePlan.SelectedRows)
                    {
                        //MessageBox.Show(auditingAction.DoAssessor(long.Parse(dgvr.Cells["id"].Value.ToString()), this.UserName).ToString());
                        status = auditingAction.DoAssessor(long.Parse(dgvr.Cells["id"].Value.ToString()), this.UserName);                       
                        dgvr.Cells["审核人"].Value = this.UserName;
                        switch (status)
                        {
                            case 0:
                                // 审核成功，不提示
                                break;
                            default:
                                MessageBox.Show("审核失败，请重新操作！");
                                break;
                        }
                    }
                }
            }
        }

        private void btn_Checkup_Click(object sender, EventArgs e)
        {
            //if (dgvPurchasePlan.CurrentRow != null)
            //{
            //    if (dgvPurchasePlan.CurrentRow.Cells["审批"].Value.ToString() == "已审批")
            //    {
            //        MessageBox.Show("该记录已审批完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    if (dgvPurchasePlan.CurrentRow.Cells["审核"].Value.ToString() == "未审核")
            //    {
            //        MessageBox.Show("该记录未审核，请审核后在进行审批操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    long id = Convert.ToInt64(dgvPurchasePlan.CurrentRow.Cells[0].Value.ToString());
            //    var estate = checkup();
            //    if (estate.ToString().Equals("Yes"))
            //    {
            //        if (sPLogic .Plan_Checkup(id, this.userName))
            //        {
            //            MessageBox.Show("审批成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            DataGridView();
            //        }
            //    }
            //    else
            //    {
            //        var i = sPLogic.Plan_Assess(id, "NULL");
            //        DataGridView();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("未选中任何一条记录，请选中一条记录后进行审核操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            // 2009-4-18 修改人：付中华
            // 用来审批
            if (dgvPurchasePlan.SelectedRows.Count > 0)
            {
                if (dgvPurchasePlan.SelectedRows[0].Cells["审批人"].Value.ToString() != "")
                {
                    MessageBox.Show("已经审批过的计划不允许再审批！");
                    return;
                }
                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    int result = auditingAction.DoConfirm(long.Parse(dgvPurchasePlan.SelectedRows[0].Cells["id"].Value.ToString()), this.UserName, frmConfirm.Confirm);
                    switch (result)
                    {
                        case 0:
                            if (frmConfirm.Confirm)
                            {
                                dgvPurchasePlan.SelectedRows[0].Cells["审批人"].Value = this.UserName;
                            }
                            else
                            {
                                dgvPurchasePlan.SelectedRows[0].Cells["审批人"].Value = "";
                                dgvPurchasePlan.SelectedRows[0].Cells["审核人"].Value = "";
                            }
                            break;

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
