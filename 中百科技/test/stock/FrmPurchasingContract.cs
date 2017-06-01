/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：FrmPurchasingContract.cs
     * 文件功能描述：采购合同
     *
     * 创建人：付中华
     * 创建时间：2009-3-5
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
using DasherStation.common;
using System.Data.SqlClient;

using Microsoft.Reporting.WinForms;

namespace DasherStation.stock
{
    public partial class FrmPurchasingContract : common.BaseForm
    {

        AuditingAction auditingAction = new AuditingAction("id", "stockContract");
        public FrmPurchasingContract()
        {
            InitializeComponent();
        }
        stockContractLogic stockContractLogic = new stockContractLogic();
        stockContractDetailLogic stockDetailLogic = new stockContractDetailLogic();
        private void FrmPurchasingContract_Load(object sender, EventArgs e)
        {
            this.userName = "fzh";
            stockContractLogic.QueryBind(this.cmb_query);
            // 合同状态全部信息为all 已终止信息hasFinish 未终止信息notFinish 2009-4-13
            stockContractLogic.contractStatus(this.cmbContractStatus);
            dataBind();
            btn_print.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPurchasingContractNew fpcnform = new FrmPurchasingContractNew();
            if (fpcnform.ShowDialog(this) == DialogResult.OK)
            {
                dataGridView1.DataSource = stockContractLogic.getContractListLogic("","");
                //使新建完采购合同后返回主界面上时能选中新添加的合同
                dataGridView1.Rows[0].Selected = false;

                int index = dataGridView1.Rows.Count - 1;
                dataGridView1.Rows[index].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = index;

                if (this.dataGridView1.SelectedRows.Count == 1)
                {
                    int mainId = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString());
                    this.dataGridView2.DataSource = stockContractLogic.getContractListDetailLogic(mainId);
                }
                //stockPlanTablesChange();
            }
        }
        private void dataBind()
        {
            this.dataGridView1.DataSource = stockContractLogic.getContractListLogic("","");
        }
        private void dataBind(string strWhere, string contractStatus)
        {
            this.dataGridView1.DataSource = stockContractLogic.getContractListLogic(strWhere, contractStatus);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                int mainId = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString());
                this.dataGridView2.DataSource = stockContractLogic.getContractListDetailLogic(mainId);
            }
        }
        // 2009-4-16 付中华修改
        private void btn_search_Click(object sender, EventArgs e)
        {
            int varBit;
            string condition;
            // 合同状态的条件
            condition = this.cmbContractStatus.Text;

            switch (condition)
            {
                case "已终止合同":
                    varBit = 1;
                    break;
                case "未终止合同":
                    varBit = 2;
                    break;
                default:
                    varBit = 0;
                    break;
            }
            // 搜索条件
            string str = txtSearch.Text.Trim();

            string sqlCondition = "";
            // 针对不同的合同状态向sql语句中加入不同的条件
            switch (varBit)
            {
                case 0:
                    sqlCondition = "";
                    break;
                case 1:
                    sqlCondition = "finishMark" + "=" + 1;
                    break;
                case 2:
                    sqlCondition = "finishMark" + "=" + 0;
                    break;
            }

            if ((this.cmb_query.Text != "") && (this.cmb_query.SelectedValue.ToString() != ""))
            {
                if (!Check.CheckEmpty(str))
                {
                    MessageBox.Show("查询关键字不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Check.CheckQueryIsEmpty(str))
                {
                    MessageBox.Show("查询关键字中不能包含特殊字符或空格", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string SqlStr = this.cmb_query.SelectedValue.ToString() + "='" + str + "'";


                dataBind(SqlStr, sqlCondition);
                dataGridView1.Refresh();
                if (dataGridView1.Rows.Count == 0)
                {
                    deleteDetailDataGridView(dataGridView2);
                }
            }
            else
            {
                dataGridView1.DataSource = stockContractLogic.getContractListLogic("", sqlCondition);
                if (dataGridView1.Rows.Count == 0)
                {
                    deleteDetailDataGridView(dataGridView2);
                }
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
        
        private void button4_Click(object sender, EventArgs e)
        {
            bool endStatus = false;
           
            int mainContractId = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString());
            // 查询主合同编号对应的parentId是"是否中的哪一个" 如果是则此合同本身是补充合同
            var row = this.dataGridView1.Rows.Cast<DataGridViewRow>().Where(p => p.Cells[0].Value.ToString() == mainContractId.ToString()).First();
            var cellValue = row.Cells["parentId"].FormattedValue.ToString();
            // cellValue=="是" 为真说明是补充合同 为假说明是主合同            

            //事务域 by 杨林 200-03-17
            //using(System.Transactions.TransactionScope oScoap = new System.Transactions.TransactionScope())
            //{
            if (cellValue == "是")
            {
                endSupplyContract();
            }
            else
            {
                if (MessageBox.Show("确定终止选中的合同和它的所有明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    int endIndex = this.dataGridView1.SelectedRows.Count;
                    for (int i = 1; i <= endIndex; i++)
                    {
                        endStatus = stockContractLogic.endMainContractLogic(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString().Trim()));
                    }
                }
            }
            //oScoap.Complete();//提交事务域,该语句必须有,否则不会提交数据库.
            //}

            if (endStatus)
            {
                dataBind();
                dataGridView2.DataSource = stockContractLogic.getContractListDetailLogic(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString().Trim()));
            }
        }
        // 终止分合同
        private void endSupplyContract()
        {
            bool endStatus;
            bool endAll;
            // 分合同的Id号
            int supplyId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString());
            // 对应的主合同id 命名为useParentId
            int parentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["useParentId"].Value.ToString());
            // 调用终止分合同的方法
            if (MessageBox.Show("确定终止选中的合同和它的所有明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int endIndex = this.dataGridView1.SelectedRows.Count;
                for (int i = 1; i <= endIndex; i++)
                {
                    endStatus = stockContractLogic.endSupplyContractLogic(supplyId, parentId);
                    endAll = stockContractLogic.isEndAll(parentId, parentId);
                    if (endAll)
                    {
                        endStatus = stockContractLogic.endSupplyContractLogic(supplyId, parentId);
                    }
                    if (endStatus)
                    {
                        dataBind();
                        dataGridView2.DataSource = stockContractLogic.getContractListDetailLogic(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString().Trim()));
                    }
                }
            }
        }
        // 终止主合同的明细
        private void endMainContractDetail()
        {
            bool endStatus;
            bool endAll;
            // 主合同明细的id
            int mainContractDetailId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value.ToString());
            // 对应主合同的id
            int mainContractId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["scId"].Value.ToString());
            if (MessageBox.Show("确定终止选中的合同明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int endIndex = this.dataGridView2.SelectedRows.Count;
                for (int i = 1; i <= endIndex; i++)
                {
                    endStatus = stockContractLogic.endMainContractDetailLogic(mainContractDetailId, mainContractId);
                    endAll = stockContractLogic.isEndAll(mainContractId, mainContractId);
                    if (endAll)
                    {
                        endStatus = stockContractLogic.endMainContractDetailLogic(mainContractDetailId, mainContractId);
                    }
                    if (endStatus)
                    {
                        dataBind();
                        dataGridView2.DataSource = stockContractLogic.getContractListDetailLogic(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString().Trim()));
                    }
                }
            }

        }
        // 终止分合同的明细
        private void endSupplyContractDetail()
        {
            bool endStatus;
            bool endAll;
            bool endAllSupply;

            //  定出主合同的编号
            int mainContract = Convert.ToInt32(this.dataGridView2.SelectedRows[0].Cells["scId"].Value.ToString().Trim());
            var row = this.dataGridView1.Rows.Cast<DataGridViewRow>().Where(p => p.Cells[0].Value.ToString() == mainContract.ToString()).First();
            var cellValue = Convert.ToInt32(row.Cells["useParentId"].FormattedValue.ToString());
            // 分合同明细的id
            int supplyDetailId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value.ToString());
            // 分合同对应的主合同id
            int parentId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["scId"].Value.ToString());
            if (MessageBox.Show("确定终止选中的合同明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int endIndex = this.dataGridView2.SelectedRows.Count;
                for (int i = 1; i <= endIndex; i++)
                {
                    endStatus = stockContractLogic.endSupplyContractDetailLogic(supplyDetailId, parentId);
                    endAll = stockContractLogic.isEndAll(parentId, parentId);
                    if (endAll)
                    {
                        endStatus = stockContractLogic.endSupplyContractDetailLogic(supplyDetailId, parentId);
                        endAllSupply = stockContractLogic.endSupplyContractDetailLogic(supplyDetailId, cellValue);
                    }
                    if (endStatus)
                    {
                        dataBind();
                        dataGridView2.DataSource = stockContractLogic.getContractListDetailLogic(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString().Trim()));
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btl_stopIndent_Click(object sender, EventArgs e)
        {
            // 先判断是终止主合同还是终止补充合同的明细  mainContract能得到主合同的编号
            int mainContract = Convert.ToInt32(this.dataGridView2.SelectedRows[0].Cells["scId"].Value.ToString().Trim());
            // 查询主合同编号对应的parentId是"是否中的哪一个" 如果是则此合同本身是补充合同
            var row = this.dataGridView1.Rows.Cast<DataGridViewRow>().Where(p => p.Cells[0].Value.ToString() == mainContract.ToString()).First();
            var cellValue = row.Cells["parentId"].FormattedValue.ToString();
            if (cellValue == "是")
            {
                endSupplyContractDetail();
            }
            else
            {
                endMainContractDetail();
            }


        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                long id = long.Parse(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString());

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.stock.StockDataSetTableAdapters.indentTableAdapter", "indent", new object[] { id }));
                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.stock.StockDataSetTableAdapters.stockContractTableAdapter", "stockContract", new object[] { id }));

                reportData.DataSetName = "DasherStation.stock.StockDataSet";
                reportData.ReportName = "DasherStation.stock.Report.stockContract.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
    

        }
        // 审核按钮
        private void button1_Click(object sender, EventArgs e)
        {
            int status;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0].Cells["finishMark"].Value.ToString() == "已终止")
                {
                    MessageBox.Show("已终止的合同不能进行审核！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("是否确认审核选中采购合同", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                    {
                        status=auditingAction.DoAssessor(long.Parse(dgvr.Cells["htid"].Value.ToString()),this.UserName);
                        dgvr.Cells["assessor"].Value = this.UserName;
                        switch (status)
                        {
                            case 0:
                                MessageBox.Show("审核成功");
                                break;
                            case 1:
                                MessageBox.Show("该条记录已经被审核过,不能再次审核！");
                                break;
                            default:
                                MessageBox.Show("出错，请重新操作");
                                break;
                        }
                    }
                }

            }
        }
        // 审批按钮
        private void btn_checkupMan_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0].Cells["finishMark"].Value.ToString() == "已终止")
                {
                    MessageBox.Show("已终止的合同不能进行审批！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }
                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    int result = auditingAction.DoConfirm(long.Parse(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString()), this.UserName, frmConfirm.Confirm);
                    switch (result)
                    {
                        case 0:
                            if (frmConfirm.Confirm)
                            {
                                dataGridView1.SelectedRows[0].Cells["checkupMan"].Value = this.UserName;
                            }
                            else
                            {
                                dataGridView1.SelectedRows[0].Cells["checkupMan"].Value = "";
                                dataGridView1.SelectedRows[0].Cells["assessor"].Value = "";
                            }
                            break;

                    }
                }             
            }

        }

        private void cmb_query_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmb_query.SelectedValue.ToString() == "")
            {
                this.txtSearch.Text = "";
            }
        }
    }
}
