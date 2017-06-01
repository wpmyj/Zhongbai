/*
      * 版权单位：沈阳中百科技有限公司
      *
      * 文件名：FrmSalesSettlement.cs
      * 文件功能描述：销售结算界面
      *
      * 创建人：冯雪
      * 创建时间：2009-02-04
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
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using DasherStation.ReportDistrict.sellReport;

namespace DasherStation.sell
{
    public partial class FrmSalesSettlement : common.BaseForm
    {
        public FrmSalesSettlement()
        {
            InitializeComponent();
        }

        // 2009-4-18 修改人：付中华
        // 审核审批用
        AuditingAction auditingAction = new AuditingAction("id", "sellProductSettlement");


        SalesSettlementLogic salesSLogic = new SalesSettlementLogic();

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

        #region 为销售核算赋值
        private void DataGridView(string condition, int verifyBit)
        {
            dgvSettlement.DataSource = salesSLogic.SettlementSearch(condition, verifyBit);
        }
        #endregion

        private void FrmSalesSettlement_Load(object sender, EventArgs e)
        {
            this.userName = "fzh";
            DataGridView("", 0);
        }

        private void btn_page_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSalesSettlementAdd frmSalesSettlementAdd = new FrmSalesSettlementAdd();
            //DialogResult dialogResult =  frmSalesSettlementAdd.ShowDialog();


            if (frmSalesSettlementAdd.ShowDialog(this) == DialogResult.OK)
            {
                DataGridView("", 0);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            // verifyBit用来标识查询条件；
            int verifyBit;
            string Condition;

              // 检查用条件文本框是否含有非法字符
            if (!Check.CheckQuery(txtCondition.Text.Trim()))
            {
                MessageBox.Show("查询条件包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCondition.Focus();
                return;
            }
            else
            {
                // 取出查询条件;
                Condition = cbxCondition.Text.Trim();

                switch (Condition)
                {
                    case "合同编号":
                        verifyBit = 1;
                        break;
                    case "合同名称":
                        verifyBit = 2;
                        break;
                    case "客户名称":
                        verifyBit = 3;
                        break;
                    default:
                        verifyBit = 0;
                        break;
                }
            }

            DataGridView(txtCondition.Text.Trim(), verifyBit);
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            if (dgvSettlement.CurrentRow != null)
            {
                long pSId = Convert.ToInt64(dgvSettlement.CurrentRow.Cells["核算单号"].Value.ToString());

                FrmSalesSettlementAdd frmFSLAdd = new FrmSalesSettlementAdd();
                //frmFSLAdd.IsNew = false;
                frmFSLAdd.PSId = pSId;
                frmFSLAdd.Text = "核算单明细";
                frmFSLAdd.ShowDialog();

            }
            else
            {
                MessageBox.Show("请选择要查看的核算单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btn_Assess_Click(object sender, EventArgs e)
        {
            //if (dgvSettlement.CurrentRow != null)
            //{
            //    if (dgvSettlement.CurrentRow.Cells["审核"].Value.ToString() == "已审核")
            //    {
            //        MessageBox.Show("该记录已审核完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    var estate = assess();
            //    if (estate.ToString().Equals("Yes"))
            //    {
            //        long id = Convert.ToInt64(dgvSettlement.CurrentRow.Cells[0].Value.ToString());
            //        if (salesSLogic.Settlement_Assess(id, this.userName))
            //        {
            //            MessageBox.Show("审核成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            DataGridView("",0);
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("未选中任何一条记录，请选中一条记录后进行审核操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            // 2009-4-18 修改人：付中华
            // 用来审核
            if (dgvSettlement.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确认审核选中销售计划", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dgvSettlement.SelectedRows)
                    {
                        MessageBox.Show(auditingAction.DoAssessor(long.Parse(dgvr.Cells["核算单号"].Value.ToString()), this.UserName).ToString());
                        dgvr.Cells["审核人"].Value = this.UserName;
                    }
                }
            }

        }

        private void btn_Checkup_Click(object sender, EventArgs e)
        {
            //if (dgvSettlement.CurrentRow != null)
            //{
            //    if (dgvSettlement.CurrentRow.Cells["审批"].Value.ToString() == "已审批")
            //    {
            //        MessageBox.Show("该记录已审批完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    if (dgvSettlement.CurrentRow.Cells["审核"].Value.ToString() == "未审核")
            //    {
            //        MessageBox.Show("该记录未审核，请审核后在进行审批操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    long id = Convert.ToInt64(dgvSettlement.CurrentRow.Cells[0].Value.ToString());
            //    var estate = checkup();
            //    if (estate.ToString().Equals("Yes"))
            //    {
            //        if (salesSLogic.Settlement_Checkup(id, this.userName))
            //        {
            //            MessageBox.Show("审批成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            DataGridView("", 0);
            //        }
            //    }
            //    else
            //    {
            //        var i = salesSLogic.Settlement_Assess(id, "NULL");
            //        DataGridView("", 0);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("未选中任何一条记录，请选中一条记录后进行审核操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            // 2009-4-18 修改人：付中华
            // 用来审批
            if (dgvSettlement.SelectedRows.Count > 0)
            {
                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    int result = auditingAction.DoConfirm(long.Parse(dgvSettlement.SelectedRows[0].Cells["核算单号"].Value.ToString()), this.UserName, frmConfirm.Confirm);
                    switch (result)
                    {
                        case 0:
                            if (frmConfirm.Confirm)
                            {
                                dgvSettlement.SelectedRows[0].Cells["审批人"].Value = this.UserName;
                            }
                            else
                            {
                                dgvSettlement.SelectedRows[0].Cells["审批人"].Value = "";
                                dgvSettlement.SelectedRows[0].Cells["审核人"].Value = "";
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

        private void btn_Print_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Print.ContextMenuStrip.Show((Button)sender, new Point(e.X, e.Y));
        }

        private void TSMDetail_Click(object sender, EventArgs e)
        {
            // 打印销售核算单
            if (dgvSettlement.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgvSettlement.SelectedRows[0].Cells[0].Value.ToString());

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.SellProductSettlementDataSetTableAdapters.sellProductSettlementTableAdapter", "sellProductSettlement", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.SellProductSettlementDataSet";
                reportData.ReportName = "DasherStation.Report.SellProductSettlementReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }

        private void TSMBillDetail_Click(object sender, EventArgs e)
        {
            if (dgvSettlement.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgvSettlement.SelectedRows[0].Cells[0].Value.ToString());
                ReportSellClass sell_Report = new ReportSellClass();
                sell_Report.RunProductSellClearing(id);
            }
            
        }

    }
}
