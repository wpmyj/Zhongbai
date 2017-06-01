/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：FrmProcurementProgram.cs
     * 文件功能描述：采购计划
     *
     * 创建人：付中华
     * 创建时间：2009-3-2
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
using DasherStation.stock;
using DasherStation.common;
using DasherStation.ReportDistrict.stockReport;

namespace DasherStation.stock
{
    public partial class FrmProcurementProgram : common.BaseForm
    {
        AuditingAction auditingAction = new AuditingAction("id", "stockPlan");
        public FrmProcurementProgram()
        {
            InitializeComponent();
        }
        stockPlanLogic stockPlanLogic = new stockPlanLogic();
        purchaseScheDetaillogic stockPlanlogic = new purchaseScheDetaillogic();
        private void btnNew_Click(object sender, EventArgs e)
        {
            purchasePlan pcPform = new purchasePlan();           
            if (pcPform.ShowDialog(this) == DialogResult.OK)
            {
                stockPlan.DataSource = stockPlanLogic.prochaseSchemainLogic();
                //使新建完采购计划后返回主界面上时能选中新添加的计划
                stockPlan.Rows[0].Selected = false;

                int index = stockPlan.Rows.Count-1;
                stockPlan.Rows[index].Selected = true;
                stockPlan.FirstDisplayedScrollingRowIndex = index;
              
                
                stockPlanTablesChange();
                
            }
            
        }
        //搜索按钮
        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 校验年份 此输入只能是数字
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

            stockPlanLogic.compareYear(Convert.ToInt32(txtStartYear.Text), Convert.ToInt32(txtEndYear.Text), stockPlan);
            if (stockPlan.Rows.Count ==0)
            {
                deleteDetailDataGridView(dgvPurchaseDetail);
            }
            stockPlan.Refresh();
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

        private void FrmProcurementProgram_Load(object sender, EventArgs e)
        {
            try
            {
                this.userName = "fzh";
                txtStartYear.Text = DateTime.Now.Year.ToString();
                txtEndYear.Text = DateTime.Now.Year.ToString();
                //查询第一个表格的所有数据
                stockPlan.DataSource = stockPlanLogic.prochaseSchemainLogic();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
 
            }
        }
        //采购计划主表变时从表跟着也变
        private void stockPlanTablesChange()
        {
            if (this.stockPlan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(this.stockPlan.SelectedRows[0].Cells["id"].Value.ToString());

                this.dgvPurchaseDetail.DataSource = stockPlanlogic.prochaseSchedetaillogic(id);
            }
            else
            {
                foreach (DataGridViewRow dgvr in dgvPurchaseDetail.Rows)
                {
                    dgvPurchaseDetail.Rows.Remove(dgvr);
                }   
            }
        }
        private void stockPlan_SelectionChanged(object sender, EventArgs e)
        {
            stockPlanTablesChange();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool deleteStatus;
            try
            {
                if (stockPlan.SelectedRows.Count > 0)
                {
                    if (stockPlan.SelectedRows[0].Cells["assessor"].Value.ToString() != "")
                    {
                        MessageBox.Show("已审核或者审批过的计划不允许删除！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("确定删除所选中的采购计划以及它的明细信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        int deleteIndex = stockPlan.SelectedRows.Count;
                        for (int i = 1; i <= deleteIndex; i++)
                        {
                            deleteStatus = stockPlanLogic.stockPlanDeletelogic(Convert.ToInt32(stockPlan.SelectedRows[0].Cells["id"].Value.ToString().Trim()));
                            this.stockPlan.Rows.RemoveAt(stockPlan.SelectedRows[0].Index);
                            stockPlan.Refresh();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选择要删除的行！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // 审核按钮
        private void btn_assessor_Click(object sender, EventArgs e)
        {
            if (stockPlan.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确认审核选中采购计划", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in stockPlan.SelectedRows)
                    {
                        MessageBox.Show(auditingAction.DoAssessor(long.Parse(dgvr.Cells["id"].Value.ToString()), this.UserName).ToString());
                        dgvr.Cells["assessor"].Value = this.UserName;
                    }
                }
            }
        }
        // 审批按钮
        private void btn_checkupMan_Click(object sender, EventArgs e)
        {
            if (stockPlan.SelectedRows.Count > 0)
            {
                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    int result = auditingAction.DoConfirm(long.Parse(stockPlan.SelectedRows[0].Cells["id"].Value.ToString()), this.UserName, frmConfirm.Confirm);
                    switch (result)
                    {
                        case 0:
                            if (frmConfirm.Confirm)
                            {
                                stockPlan.SelectedRows[0].Cells["checkupman"].Value = this.UserName;
                            }
                            else
                            {
                                stockPlan.SelectedRows[0].Cells["checkupman"].Value = "";
                                stockPlan.SelectedRows[0].Cells["assessor"].Value = "";
                            }
                            break;

                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (this.stockPlan.SelectedRows.Count > 0)
            {
                ReportStockClass reportProc = new ReportStockClass();

                string id = this.stockPlan.SelectedRows[0].Cells["id"].Value.ToString();
                reportProc.RunStockPlan(id);
            }
        }                   
        }

       
    }


