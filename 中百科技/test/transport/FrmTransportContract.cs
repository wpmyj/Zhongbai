using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

using DasherStation.transport.TranSportTableAdapters;
using Microsoft.Reporting.WinForms;

namespace DasherStation.transport
{
    public partial class FrmTransportContract:common.BaseForm 
    {
        public FrmTransportContract()
        {
            InitializeComponent();

        }

        TransportLogic transportLogic = new TransportLogic();

        AuditingAction auditingAction = new AuditingAction("id", "transportContract");

        private void FrmTransportContract_Load(object sender, EventArgs e)
        {
            this.UserName = "kimha";
            //button1.Visible = false;

            transportLogic.siteBind(site1);
            transportLogic.siteBind(site2);
            transportLogic.transportSettlementMethodBind(tsmid);

            // 2009-4-20 修改人：付中华
            transportLogic.QueryBind(this.cmb_query);
            // 合同状态全部信息为all 已终止信息hasFinish 未终止信息notFinish 2009-4-20
            transportLogic.contractStatus(this.cmbContractStatus);
            dataBind();
            //query(null);
            

            auditingAction.AuditingEvent += new AuditingEventHandler(transportLogic.AfterConfirmInsert);
            auditingAction.AuditingEvent += new AuditingEventHandler(transportLogic.AfterConfirmUpdate);
        }

        //private void query(string strWhere)
        //{
        //    transportLogic.contractBind(dgv_transportContract,strWhere);
        //}
        // 2009-4-20 修改人：付中华
        private void dataBind()
        {
            this.dgv_transportContract.DataSource = transportLogic.getContractListLogic("", "");
           
        }
        // 2009-4-20 修改人：付中华
        private void dataBind(string strWhere, string contractStatus)
        {
            this.dgv_transportContract.DataSource = transportLogic.getContractListLogic(strWhere, contractStatus);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            FrmTransportContractadd tCaform = new FrmTransportContractadd();
            if (tCaform.ShowDialog() == DialogResult.OK)
            {
                //query(null);
                // 2009-4-20 修改人：付中华
                dgv_transportContract.DataSource = transportLogic.getContractListLogic("", "");
                //使新建完运输合同后返回主界面上时能选中新添加的合同
                dgv_transportContract.Rows[0].Selected = false;

                int index = dgv_transportContract.Rows.Count - 1;
                dgv_transportContract.Rows[index].Selected = true;
                dgv_transportContract.FirstDisplayedScrollingRowIndex = index;

                if (this.dgv_transportContract.SelectedRows.Count == 1)
                {
                    string mainId = this.dgv_transportContract.SelectedRows[0].Cells["id"].Value.ToString();
                    transportLogic.goodsInfoBind(dgv_transportGoodsInformationCorresponding, mainId);
                }
            }
        }

        private void dgv_transportContract_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_transportContract.SelectedRows.Count > 0)
            {
                transportLogic.goodsInfoBind(dgv_transportGoodsInformationCorresponding, dgv_transportContract.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            //FormHelper formHelper = new FormHelper();
            //if (formHelper.inputCheck(this.groupBox1))
            //{
            //    MessageBox.Show("1111");
            //}

            //query(transportLogic.getQueryStr(cmb_query , txt_quertStr));

            // 2009-4-20 修改人：付中华
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
            string str = txt_quertStr.Text.Trim();

            string sqlCondition = "";
            // 针对不同的合同状态向sql语句中加入不同的条件
            switch (varBit)
            {
                case 0:
                    sqlCondition = "";
                    break;
                case 1:
                    sqlCondition = "mark" + "=" + 1;
                    break;
                case 2:
                    sqlCondition = "mark" + "=" + 0;
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
                dgv_transportContract.Refresh();
                if (dgv_transportContract.Rows.Count == 0)
                {
                    deleteDetailDataGridView(dgv_transportGoodsInformationCorresponding);
                }
            }
            else
            {
                dgv_transportContract.DataSource = transportLogic.getContractListLogic("", sqlCondition);
                if (dgv_transportContract.Rows.Count == 0)
                {
                    deleteDetailDataGridView(dgv_transportGoodsInformationCorresponding);
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

        private void btn_stop_Click(object sender, EventArgs e)
        {
            //if (dgv_transportContract.SelectedRows.Count > 0)
            //{
            //    if (MessageBox.Show("是否要终止选中运输合同", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {
            //        foreach (DataGridViewRow dgvr in dgv_transportContract.SelectedRows)
            //        {
            //            transportLogic.contractStop(dgvr.Cells[0].Value.ToString());
            //            dgvr.Cells[9].Value = "已终止";
            //        }        
            //    }
            //}

            // 2009-4-20 修改人：付中华
            bool endStatus = false;

            int mainContractId = Convert.ToInt32(this.dgv_transportContract.SelectedRows[0].Cells["id"].Value.ToString());
            // 查询主合同编号对应的parentId是"是否中的哪一个" 如果是则此合同本身是补充合同
            var row = this.dgv_transportContract.Rows.Cast<DataGridViewRow>().Where(p => p.Cells[0].Value.ToString() == mainContractId.ToString()).First();
            var cellValue = row.Cells["补充合同"].FormattedValue.ToString();
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
                    int endIndex = this.dgv_transportContract.SelectedRows.Count;
                    for (int i = 1; i <= endIndex; i++)
                    {
                        endStatus = transportLogic.endMainContractLogic(Convert.ToInt32(dgv_transportContract.SelectedRows[0].Cells["id"].Value.ToString().Trim()));
                    }
                }
            }
            //oScoap.Complete();//提交事务域,该语句必须有,否则不会提交数据库.
            //}

            if (endStatus)
            {
                dataBind();
                //dataGridView2.DataSource = stockContractLogic.getContractListDetailLogic(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString().Trim()));
                transportLogic.goodsInfoBind(dgv_transportGoodsInformationCorresponding, dgv_transportContract.SelectedRows[0].Cells["id"].Value.ToString());
            }
        }
        // 2009-4-20 修改人：付中华 终止分合同
        private void endSupplyContract()
        {
            bool endStatus;
            bool endAll;
            // 分合同的Id号
            int supplyId = Convert.ToInt32(dgv_transportContract.SelectedRows[0].Cells["id"].Value.ToString());
            // 对应的主合同id
            int parentId = Convert.ToInt32(dgv_transportContract.SelectedRows[0].Cells["parentId"].Value.ToString());
            // 调用终止分合同的方法
            if (MessageBox.Show("确定终止选中的合同和它的所有明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int endIndex = this.dgv_transportContract.SelectedRows.Count;
                for (int i = 1; i <= endIndex; i++)
                {
                    endStatus = transportLogic.endSupplyContractLogic(supplyId, parentId);
                    endAll = transportLogic.isEndAll(parentId, parentId);
                    if (endAll)
                    {
                        endStatus = transportLogic.endSupplyContractLogic(supplyId, parentId);
                    }
                    if (endStatus)
                    {
                        dataBind();
                        //dataGridView2.DataSource = stockContractLogic.getContractListDetailLogic(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString().Trim()));
                        transportLogic.goodsInfoBind(dgv_transportGoodsInformationCorresponding, dgv_transportContract.SelectedRows[0].Cells["id"].Value.ToString());
                    }
                }
            }
        }
        // 2009-4-20 修改人：付中华 终止主合同的明细
        private void endMainContractDetail()
        {
            bool endStatus;
            bool endAll;
            // 主合同明细的id
            int mainContractDetailId = Convert.ToInt32(dgv_transportGoodsInformationCorresponding.SelectedRows[0].Cells["did"].Value.ToString());
            // 对应主合同的id
            int mainContractId = Convert.ToInt32(dgv_transportGoodsInformationCorresponding.SelectedRows[0].Cells["tcId"].Value.ToString());
            if (MessageBox.Show("确定终止选中的合同明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int endIndex = this.dgv_transportGoodsInformationCorresponding.SelectedRows.Count;
                for (int i = 1; i <= endIndex; i++)
                {
                    endStatus = transportLogic.endMainContractDetailLogic(mainContractDetailId, mainContractId);
                    endAll = transportLogic.isEndAll(mainContractId, mainContractId);
                    if (endAll)
                    {
                        endStatus = transportLogic.endMainContractDetailLogic(mainContractDetailId, mainContractId);
                    }
                    if (endStatus)
                    {
                        dataBind();
                        //dataGridView2.DataSource = stockContractLogic.getContractListDetailLogic(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString().Trim()));
                        transportLogic.goodsInfoBind(dgv_transportGoodsInformationCorresponding, dgv_transportContract.SelectedRows[0].Cells["id"].Value.ToString());
                    }
                }
            }

        }
        // 2009-4-20 修改人：付中华 终止分合同的明细
        private void endSupplyContractDetail()
        {
            bool endStatus;
            bool endAll;
            bool endAllSupply;

            //  定出主合同的编号
            int mainContract = Convert.ToInt32(this.dgv_transportGoodsInformationCorresponding.SelectedRows[0].Cells["tcId"].Value.ToString().Trim());
            var row = this.dgv_transportContract.Rows.Cast<DataGridViewRow>().Where(p => p.Cells[0].Value.ToString() == mainContract.ToString()).First();
            var cellValue = Convert.ToInt32(row.Cells["parentId"].FormattedValue.ToString());
            // 分合同明细的id
            int supplyDetailId = Convert.ToInt32(dgv_transportGoodsInformationCorresponding.SelectedRows[0].Cells["did"].Value.ToString());
            // 分合同对应的主合同id
            int parentId = Convert.ToInt32(dgv_transportGoodsInformationCorresponding.SelectedRows[0].Cells["tcId"].Value.ToString());
            if (MessageBox.Show("确定终止选中的合同明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int endIndex = this.dgv_transportGoodsInformationCorresponding.SelectedRows.Count;
                for (int i = 1; i <= endIndex; i++)
                {
                    endStatus = transportLogic.endSupplyContractDetailLogic(supplyDetailId, parentId);
                    endAll = transportLogic.isEndAll(parentId, parentId);
                    if (endAll)
                    {
                        endStatus = transportLogic.endSupplyContractDetailLogic(supplyDetailId, parentId);
                        endAllSupply = transportLogic.endSupplyContractDetailLogic(supplyDetailId, cellValue);
                    }
                    if (endStatus)
                    {
                        dataBind();
                        //dataGridView2.DataSource = stockContractLogic.getContractListDetailLogic(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["htid"].Value.ToString().Trim()));
                        transportLogic.goodsInfoBind(dgv_transportGoodsInformationCorresponding, dgv_transportContract.SelectedRows[0].Cells["id"].Value.ToString());
                    }
                }
            }
        }
        private void btn_assessor_Click(object sender, EventArgs e)
        {
            int status;

            if ((dgv_transportContract.SelectedRows.Count > 0)&&(dgv_transportContract.SelectedRows[0].Cells[9].Value.ToString() != "已终止"))
            {
                if (MessageBox.Show("是否确认审核选中运输合同", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dgv_transportContract.SelectedRows)
                    {
                       // transportLogic.contractAssessor(dgvr.Cells[0].Value.ToString(), this.UserName);
                        status = auditingAction.DoAssessor(long.Parse(dgvr.Cells[0].Value.ToString()), this.UserName);
                        dgvr.Cells[7].Value = this.UserName;
                        //dgvr.Cells["审核日期"].Value = DateTime.Now;
                        switch (status)
                        {
                            case 0:
                                //MessageBox.Show("审核成功");
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
            else
            {
                MessageBox.Show("已终止的合同不能进行审核！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btn_checkupMan_Click(object sender, EventArgs e)
        {
            if (dgv_transportContract.SelectedRows.Count > 0)
            {
                if (dgv_transportContract.SelectedRows[0].Cells[9].Value.ToString() == "已终止")
                {
                    MessageBox.Show("已终止的合同不能进行审批！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }
                        FrmConfirm frmConfirm = new FrmConfirm();

                        if (frmConfirm.ShowDialog() == DialogResult.OK)
                        {
                            int result = auditingAction.DoConfirm(long.Parse(dgv_transportContract.SelectedRows[0].Cells[0].Value.ToString()), this.UserName, frmConfirm.Confirm);
                            switch(result)
                            {
                                case 0:
                                    if (frmConfirm.Confirm)
                                    {
                                        dgv_transportContract.SelectedRows[0].Cells[8].Value = this.UserName;
                                        //dgv_transportContract.SelectedRows[0].Cells["审批日期"].Value = DateTime.Now;
                                        MessageBox.Show("审批成功");
                                    }
                                    else
                                    {
                                        dgv_transportContract.SelectedRows[0].Cells[8].Value ="";
                                        dgv_transportContract.SelectedRows[0].Cells[7].Value = "";
                                        //dgv_transportContract.SelectedRows[0].Cells["审核日期"].Value = "";
                                        //dgv_transportContract.SelectedRows[0].Cells["审批日期"].Value = "";
                                    }
                                   break;

                            }
                        }         
                    //}
                
            }
        }

        private void btn_stopDatail_Click(object sender, EventArgs e)
        {
            //if (dgv_transportGoodsInformationCorresponding.SelectedRows.Count > 0)
            //{
            //    if (MessageBox.Show("是否要终止选中运输合同明细", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {
            //        foreach (DataGridViewRow dgvr in dgv_transportGoodsInformationCorresponding.SelectedRows)
            //        {
            //            transportLogic.contractDatailStop(dgvr.Cells[0].Value.ToString());
            //            dgvr.Cells[8].Value = "已终止";
            //        }
            //    }
            //}

            // 2009-4-20 修改人：付中华
            // 先判断是终止主合同还是终止补充合同的明细  mainContract能得到主合同的编号
            int mainContract = Convert.ToInt32(this.dgv_transportGoodsInformationCorresponding.SelectedRows[0].Cells["tcId"].Value.ToString().Trim());
            // 查询主合同编号对应的parentId是"是否中的哪一个" 如果是则此合同本身是补充合同
            var row = this.dgv_transportContract.Rows.Cast<DataGridViewRow>().Where(p => p.Cells[0].Value.ToString() == mainContract.ToString()).First();
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

        //private void button1_Click(object sender, EventArgs e)
        //{

        //    //ReportHelper reportServer = new ReportHelper();
        //    //ReportData reportData = new ReportData();
        //    //List<ReportSource> reportSourceList = new List<ReportSource>();

        //    //reportSourceList.Add(reportServer.CreatReportSource("DasherStation.transport.TranSportTableAdapters.stockNoteTableAdapter", "stockNote", new object[] { DateTime.Parse("2009-03-03"), DateTime.Parse("2009-03-10") }));
        //    //reportSourceList.Add(reportServer.CreatReportSource("DasherStation.transport.TranSportTableAdapters.consignmentNoteTableAdapter", "consignmentNote", null));

        //    //reportData.DataSetName = "DasherStation.transport.TranSport";
        //    //reportData.ReportName = "DasherStation.transport.Report.TransportSettlement.rdlc";

        //    //reportData.ReportSourceList = reportSourceList;

        //    //reportServer.ShowReport(reportData);
            
        //}

        private void cmb_query_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmb_query.SelectedValue.ToString() == "")
            {
                this.txt_quertStr.Text = "";
            }
        }

       
    }
}
