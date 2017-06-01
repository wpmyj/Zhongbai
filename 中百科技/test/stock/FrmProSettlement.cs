/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：
     * 文件功能描述：
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
using DasherStation.common;
using System.Collections;

namespace DasherStation.stock
{
    public partial class FrmProSettlement : common.BaseForm
    {
        stockSettlementLogic SettlementLogic = new stockSettlementLogic();
        stockContractLogic ContractLogic = new stockContractLogic();

        AuditingAction auditingAction = new AuditingAction("id", "stockMaterialSettlement");
        public FrmProSettlement()
        {
            InitializeComponent();
        }
        private void FrmProSettlement_Load(object sender, EventArgs e)
        {
            this.userName = "fzh";
            InitForm();
            FindInfo();
        }
        private void InitForm()
        {
            SettlementLogic.SetFindFieldItem(ref comboBox1);
        }
        private void FindInfo()
        {
            DataTable dt = new DataTable();
            switch (comboBox1.SelectedValue.ToString())
            {
                case "1":
                    dt = SettlementLogic.FindStockSettlement(txtCondition.Text, "", "");
                    break;
                case "2":
                    dt = SettlementLogic.FindStockSettlement("", txtCondition.Text, "");
                    break;
                case "3":
                    dt = SettlementLogic.FindStockSettlement("", "", txtCondition.Text);
                    break;
                default:
                    dt = SettlementLogic.FindStockSettlement("", "", "");
                    break;
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Id"].Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FrmProSettlementAdd frmProSettlementAdd = new FrmProSettlementAdd();
            //frmProSettlementAdd.IsNew = true;

            //frmProSettlementAdd.ShowDialog();
            if (frmProSettlementAdd.ShowDialog(this) == DialogResult.OK)
            {
                FindInfo();
                dataGridView1.Refresh();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string str = txtCondition.Text.Trim();
            if (this.comboBox1.SelectedValue.ToString() != "all")
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
            }
            this.FindInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FrmProSettlementAdd frmProSettlementAdd = new FrmProSettlementAdd();

                frmProSettlementAdd.IsNew = false;
                frmProSettlementAdd.StockContractId = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                frmProSettlementAdd.ScName = dataGridView1.SelectedRows[0].Cells["合同名称"].Value.ToString();
                frmProSettlementAdd.Text = "核算单信息";
                frmProSettlementAdd.ShowDialog();
            }

        }
        // 审核按钮
        private void btn_assessor_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确认审核选中采购核算", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                    {
                        MessageBox.Show(auditingAction.DoAssessor(long.Parse(dgvr.Cells["id"].Value.ToString()), this.UserName).ToString());
                        dgvr.Cells["审核人"].Value = this.UserName;
                    }
                }
            }
        }
        // 审批按钮
        private void btn_checkupMan_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    int result = auditingAction.DoConfirm(long.Parse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString()), this.UserName, frmConfirm.Confirm);
                    switch (result)
                    {
                        case 0:
                            if (frmConfirm.Confirm)
                            {
                                dataGridView1.SelectedRows[0].Cells["审批人"].Value = this.UserName;
                            }
                            else
                            {
                                dataGridView1.SelectedRows[0].Cells["审批人"].Value = "";
                                dataGridView1.SelectedRows[0].Cells["审核人"].Value = "";
                            }
                            break;

                    }
                }
            }


        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                ReportStockClass reportProc = new ReportStockClass();

                string id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                reportProc.RunStockCheck(id);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.ContextMenuStrip.Show((Button)sender, new Point(e.X, e.Y));
        }

        private void 打印核算单票具明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                ReportStockClass reportProc = new ReportStockClass();

                string id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                reportProc.RunStockCheckDetail(id);

            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("全部"))
            {
                txtCondition.Text = "";
            }
        }

        
    }
}
