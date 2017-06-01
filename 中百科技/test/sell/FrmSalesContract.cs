/*
      * 版权单位：沈阳中百科技有限公司
      *
      * 文件名：SalesContract.cs
      * 文件功能描述：销售合同界面
      *
      * 创建人：冯雪
      * 创建时间：2009-02-04
      *
      * 修改人：付中华
      * 修改时间：2009-4-17
      * 修改内容：所有的测试错误及评审建议及与采购形式的统一
      *
      */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.sell
{
    public partial class FrmSalesContract : common.BaseForm
    {
        public FrmSalesContract()
        {
            InitializeComponent();
        }
        // 2009-4-18 修改人：付中华
        // 审核审批用
        AuditingAction auditingAction = new AuditingAction("id", "sellContract");

        SalesContractLogic sCLogin = new SalesContractLogic();

        #region 为销售合同主表赋值
        private void DataGridView()
        {
            dgvSContract.DataSource = sCLogin.FrmSalesCSearch("", 0);
            dgvSContract.Columns["id"].Visible = false;
            dgvSContract.Columns["parentId"].Visible = false;
        }
        #endregion

        #region 主表变化,从表也跟着变化;
        //主表变化,从表也跟着变化
        private void DataGridviewChange()
        {
            if (this.dgvSContract.SelectedRows.Count == 1 )
            {
                int searchId;

                searchId = Convert.ToInt32(dgvSContract.CurrentRow.Cells[0].Value.ToString());

                dgvInvoice.DataSource = sCLogin.FrmSalesCSearchList(searchId);
                dgvInvoice.Columns["scId"].Visible = false;
            }
            else
            {
                dgvInvoice.DataSource = sCLogin.FrmSalesCSearchList(0);
                dgvInvoice.Columns["scId"].Visible = false;
            }

            dgvInvoice.Columns["id"].Visible = false;
            dgvInvoice.Columns["scId"].Visible = false;
        }
        #endregion

        #region 审核操作
        //private DialogResult assess()
        //{
        //    DialogResult result = MessageBox.Show("是否同意审核操作", "提示", MessageBoxButtons.YesNo);
        //    return result;
        //}
        #endregion

        #region 审批操作
        //private DialogResult checkup()
        //{
        //    DialogResult result = MessageBox.Show("是否同意审批操作", "提示", MessageBoxButtons.YesNo);
        //    return result;
        //}
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSalesContractNew frmSalesContractNew = new FrmSalesContractNew();
            if (frmSalesContractNew.ShowDialog(this) == DialogResult.OK)
            {
                DataGridView();
                DataGridviewChange();
            }
        }

        private void FrmSalesContract_Load(object sender, EventArgs e)
        {
            //查询dgvSContract所有数据
            //DataGridView();

            this.userName = "fzh";

            //选择合同后,,相应的出来明细的相应信息;
            //if (this.dgvSContract.SelectedRows.Count == 1)
            //{
            //    dgvInvoice.DataSource = sCLogin.FrmSalesCSearchList(1);
            //    dgvInvoice.Columns["id"].Visible = false;
            //    dgvSContract.Columns["parentId"].Visible = false;
            //}
            //DataGridviewChange();

            //try
            //{  
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
            //finally
            //{

            //}
            sCLogin.QueryBind(this.cbxCondition);
            // 合同状态全部信息为all 已终止信息hasFinish 未终止信息notFinish 2009-4-13
            sCLogin.contractStatus(this.cmbContractStatus);
            dataBind();
            btnPrint.Visible = false;

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //verifyBit用来标识查询条件；
            //int verifyBit;
            //string Condition;
            
            //    //检查用条件文本框是否含有非法字符
            //    if (!Check.CheckQuery(txtCondition.Text.Trim()))
            //    {
            //        MessageBox.Show("查询条件包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtCondition.Focus();
            //        return;
            //    }
            //    //按查询框的信息进行模糊查询
            //    else
            //    {
            //        Condition = cbxCondition.Text.Trim();

            //        switch (Condition)
            //        {
            //            case "未终止合同":
            //                verifyBit = 1;
            //                break;
            //            case "已终止合同":
            //                verifyBit = 2;
            //                break;
            //            case "合同名称":
            //                verifyBit = 3;
            //                break;
            //            default:
            //                verifyBit = 0;
            //                break;
            //        }

            //        dgvSContract.DataSource = sCLogin.FrmSalesCSearch(txtCondition.Text.Trim(), verifyBit);
            //        // 2009-4-17 修改人：付中华
            //        // 在DataGridView中要显示的字段的宽度

            //        dgvSContract.Columns["合同编号"].Width = 100;
            //        dgvSContract.Columns["合同名称"].Width = 100;
            //        dgvSContract.Columns["客户名称"].Width = 100;
            //        dgvSContract.Columns["制作人"].Width = 100;
            //        dgvSContract.Columns["审核人"].Width = 100;
            //        dgvSContract.Columns["审批人"].Width = 100;
            //        dgvSContract.Columns["预计总额"].Width = 100;
            //        dgvSContract.Columns["开始时间"].Width = 100;
            //        dgvSContract.Columns["结束时间"].Width = 100;
            //        dgvSContract.Columns["合同状态"].Width = 100;
            //        dgvSContract.Columns["补充合同"].Width = 100;

            //        cbxCondition.SelectedIndex = -1;
            //        txtCondition.Clear();
            //    }
            
            //try
            //{
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
            //finally
            //{
            //}


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
            string str = txtCondition.Text.Trim();

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

            if ((this.cbxCondition.Text != "") && (this.cbxCondition.SelectedValue.ToString() != ""))
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

                string SqlStr = this.cbxCondition.SelectedValue.ToString() + "='" + str + "'";


                dataBind(SqlStr, sqlCondition);
                dgvSContract.Refresh();
                if (dgvSContract.Rows.Count == 0)
                {
                    deleteDetailDataGridView(dgvInvoice);
                }
            }
            else
            {
                dgvSContract.DataSource = sCLogin.getContractListLogic("", sqlCondition);
                if (dgvSContract.Rows.Count == 0)
                {
                    deleteDetailDataGridView(dgvInvoice);
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
        // 2009-4-18 修改人：付中华 
        private void dataBind()
        {
            this.dgvSContract.DataSource = sCLogin.getContractListLogic("", "");
            dgvSContract.Columns["id"].Visible = false;
            dgvSContract.Columns["parentId"].Visible = false;
            
        }
        // 2009-4-18 修改人：付中华 
        private void dataBind(string strWhere, string contractStatus)
        {
            this.dgvSContract.DataSource = sCLogin.getContractListLogic(strWhere, contractStatus);
            dgvSContract.Columns["id"].Visible = false;
            dgvSContract.Columns["parentId"].Visible = false;
        }

        private void btnInvoiceStop_Click(object sender, EventArgs e)
        {
            //int invoiceId, searchId;
            //AddSalesContractLogic aSCLogic = new AddSalesContractLogic();

            //DialogResult strDelete = MessageBox.Show("确定要终止合同明细吗?", "提示", MessageBoxButtons.YesNo);

            //if (strDelete.ToString().Equals("No"))
            //{
            //    return;
            //}

            //invoiceId = Convert.ToInt32(dgvInvoice.CurrentRow.Cells[0].Value.ToString());
            //searchId = Convert.ToInt32(dgvSContract.CurrentRow.Cells[0].Value.ToString());
           
            //if (aSCLogic.FrmASalesStop(invoiceId))
            //{
            //    MessageBox.Show("终止记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    dgvInvoice.DataSource = sCLogin.FrmSalesCSearchList(searchId);
            //    dgvInvoice.Columns["id"].Visible = false;
            //    dgvSContract.Columns["parentId"].Visible = false;
            //}
            //else
            //{
            //    MessageBox.Show("终止记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}   

            //if (sCLogin.SearchinvoiceList(searchId))
            //{
            //    //如果合同下的所有明细全部终止的话,,将合同终止;   加个条件，，所有补充合同和其明细终止，，大合同才自动终止；
            //    sCLogin.FrmSalesCStop(searchId);
            //    dgvSContract.DataSource = sCLogin.FrmSalesCSearch("", 0);
            //    dgvSContract.Columns["id"].Visible = false;
            //    dgvSContract.Columns["parentId"].Visible = false;
            //}

            // 先判断是终止主合同还是终止补充合同的明细  mainContract能得到主合同的编号
            int mainContract = Convert.ToInt32(this.dgvInvoice.SelectedRows[0].Cells["scId"].Value.ToString().Trim());
            // 查询主合同编号对应的parentId是"是否中的哪一个" 如果是则此合同本身是补充合同
            var row = this.dgvSContract.Rows.Cast<DataGridViewRow>().Where(p => p.Cells[0].Value.ToString() == mainContract.ToString()).First();
            var cellValue = row.Cells["补充合同"].FormattedValue.ToString();
            if (cellValue == "是")
            {
                endSupplyContractDetail();
            }
            else
            {
                endMainContractDetail();
            }         

        }

        // 终止主合同的明细
        private void endMainContractDetail()
        {
            bool endStatus;
            bool endAll;
            // 主合同明细的id
            int mainContractDetailId = Convert.ToInt32(dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString());
            // 对应主合同的id
            int mainContractId = Convert.ToInt32(dgvInvoice.SelectedRows[0].Cells["scId"].Value.ToString());
            if (MessageBox.Show("确定终止选中的合同明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int endIndex = this.dgvInvoice.SelectedRows.Count;
                for (int i = 1; i <= endIndex; i++)
                {
                    endStatus = sCLogin.endMainContractDetailLogic(mainContractDetailId, mainContractId);
                    endAll = sCLogin.isEndAll(mainContractId, mainContractId);
                    if (endAll)
                    {
                        endStatus = sCLogin.endMainContractDetailLogic(mainContractDetailId, mainContractId);
                    }
                    if (endStatus)
                    {
                        //dataBind();
                        //dataGridView2.DataSource = stockContractLogic.getContractListDetailLogic(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString().Trim()));
                        DataGridView();                       
                        DataGridviewChange();
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
            int mainContract = Convert.ToInt32(this.dgvInvoice.SelectedRows[0].Cells["scId"].Value.ToString().Trim());
            var row = this.dgvSContract.Rows.Cast<DataGridViewRow>().Where(p => p.Cells[0].Value.ToString() == mainContract.ToString()).First();
            var cellValue = Convert.ToInt32(row.Cells["parentId"].FormattedValue.ToString());
            // 分合同明细的id
            int supplyDetailId = Convert.ToInt32(dgvInvoice.SelectedRows[0].Cells["id"].Value.ToString());
            // 分合同对应的主合同id
            int parentId = Convert.ToInt32(dgvInvoice.SelectedRows[0].Cells["scId"].Value.ToString());
            if (MessageBox.Show("确定终止选中的合同明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int endIndex = this.dgvInvoice.SelectedRows.Count;
                for (int i = 1; i <= endIndex; i++)
                {
                    endStatus = sCLogin.endSupplyContractDetailLogic(supplyDetailId, parentId);
                    endAll = sCLogin.isEndAll(parentId, parentId);
                    if (endAll)
                    {
                        endStatus = sCLogin.endSupplyContractDetailLogic(supplyDetailId, parentId);
                        endAllSupply = sCLogin.endSupplyContractDetailLogic(supplyDetailId, cellValue);
                    }
                    if (endStatus)
                    {
                        //dataBind();
                        //dataGridView2.DataSource = stockContractLogic.getContractListDetailLogic(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString().Trim()));
                        DataGridView();
                        DataGridviewChange();
                    }
                }
            }
        }

        private void btnCStop_Click(object sender, EventArgs e)
        {
            //DialogResult strDelete = MessageBox.Show("确定要终止合同及其补充合同以及其明细吗?", "提示", MessageBoxButtons.YesNo);

            //if (strDelete.ToString().Equals("No"))
            //{
            //    return;
            //}           
            
            //if (this.dgvSContract.SelectedRows.Count >0)
            //{
                int searchId;

                //searchId = Convert.ToInt32(dgvSContract.CurrentRow.Cells[0].Value.ToString());

                searchId = Convert.ToInt32(this.dgvSContract.SelectedRows[0].Cells["id"].Value.ToString());              
                // 2009-4-18 修改人：付中华
                // 查询主合同编号对应的parentId是"是否中的哪一个" 如果是则此合同本身是补充合同
                var row = this.dgvSContract.Rows.Cast<DataGridViewRow>().Where(p => p.Cells[0].Value.ToString() == searchId.ToString()).First();                
                
                var cellValue = row.Cells["补充合同"].FormattedValue.ToString();

                if (cellValue == "是")
                {
                    endSupplyContract();
                }
                else
                {
                    if (MessageBox.Show("确定终止选中的合同和它的所有明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        if (sCLogin.FrmSalesCStop(searchId))
                        {
                            //MessageBox.Show("终止合同成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvSContract.DataSource = sCLogin.FrmSalesCSearch("", 0);
                            dgvSContract.Columns["id"].Visible = false;
                            dgvSContract.Columns["parentId"].Visible = false;
                            DataGridviewChange();
                        }
                    }
                }
                
            //}
        }

        // 终止分合同
        private void endSupplyContract()
        {
            bool endStatus;
            bool endAll;
            // 分合同的Id号
            int supplyId = Convert.ToInt32(dgvSContract.SelectedRows[0].Cells["id"].Value.ToString());
            // 对应的主合同id 命名为useParentId
            int parentId = Convert.ToInt32(dgvSContract.SelectedRows[0].Cells["parentId"].Value.ToString());
            // 调用终止分合同的方法
            if (MessageBox.Show("确定终止选中的合同和它的所有明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int endIndex = this.dgvSContract.SelectedRows.Count;
                for (int i = 1; i <= endIndex; i++)
                {
                    endStatus = sCLogin.endSupplyContractLogic(supplyId, parentId);
                    endAll = sCLogin.isEndAll(parentId, parentId);
                    if (endAll)
                    {
                        endStatus = sCLogin.endSupplyContractLogic(supplyId, parentId);
                    }
                    if (endStatus)
                    {
                        DataGridView();
                        // 主表重新查询 
                        DataGridviewChange();
                    }
                }
            }
        }

        private void dgvSContract_SelectionChanged(object sender, EventArgs e)
        {
            DataGridviewChange();
        }

        private void btn_Assess_Click(object sender, EventArgs e)
        {
            //if (dgvSContract.CurrentRow != null)
            //{
            //    if (dgvSContract.CurrentRow.Cells["审核"].Value.ToString() == "已审核")
            //    {
            //        MessageBox.Show("该记录已审核完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    var estate = assess();
            //    if (estate.ToString().Equals("Yes"))
            //    {
            //        long id = Convert.ToInt64(dgvSContract.CurrentRow.Cells[0].Value.ToString());
            //        if (sCLogin.Contract_Assess(id, this.userName))
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
            int status;
            if (dgvSContract.SelectedRows.Count > 0)
            {
                if (dgvSContract.SelectedRows[0].Cells["合同状态"].Value.ToString() == "已终止")
                {
                    MessageBox.Show("已终止的合同不能进行审核！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("是否确认审核选中销售计划", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dgvSContract.SelectedRows)
                    {
                        status=auditingAction.DoAssessor(long.Parse(dgvr.Cells["id"].Value.ToString()), this.UserName);
                        dgvr.Cells["审核人"].Value = this.UserName;
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

        private void btn_Checkup_Click(object sender, EventArgs e)
        {
        //    if (dgvSContract.CurrentRow != null)
        //    {
        //        if (dgvSContract.CurrentRow.Cells["审批"].Value.ToString() == "已审批")
        //        {
        //            MessageBox.Show("该记录已审批完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        if (dgvSContract.CurrentRow.Cells["审核"].Value.ToString() == "未审核")
        //        {
        //            MessageBox.Show("该记录未审核，请审核后在进行审批操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        long id = Convert.ToInt64(dgvSContract.CurrentRow.Cells[0].Value.ToString());
        //        var estate = checkup();
        //        if (estate.ToString().Equals("Yes"))
        //        {
        //            if (sCLogin.Contract_Checkup(id, this.userName))
        //            {
        //                MessageBox.Show("审批成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                DataGridView();
        //            }
        //        }
        //        else
        //        {
        //            var i = sCLogin.Contract_Assess(id, "NULL");
        //            DataGridView();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("未选中任何一条记录，请选中一条记录后进行审核操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

            // 2009-4-18 修改人：付中华
            // 用来审批
            if (dgvSContract.SelectedRows.Count > 0)
            {
                if (dgvSContract.SelectedRows[0].Cells["合同状态"].Value.ToString() == "已终止")
                {
                    MessageBox.Show("已终止的合同不能进行审批！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }
                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    int result = auditingAction.DoConfirm(long.Parse(dgvSContract.SelectedRows[0].Cells["id"].Value.ToString()), this.UserName, frmConfirm.Confirm);
                    switch (result)
                    {
                        case 0:
                            if (frmConfirm.Confirm)
                            {
                                dgvSContract.SelectedRows[0].Cells["审批人"].Value = this.UserName;
                            }
                            else
                            {
                                dgvSContract.SelectedRows[0].Cells["审批人"].Value = "";
                                dgvSContract.SelectedRows[0].Cells["审核人"].Value = "";
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

        private void cbxCondition_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cbxCondition.SelectedValue.ToString() == "")
            {
                this.txtCondition.Text = "";
            }
        }
    }
}
