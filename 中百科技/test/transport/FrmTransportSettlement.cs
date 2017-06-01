using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.transport
{
    public partial class FrmTransportSettlement : common.BaseForm
    {
        public FrmTransportSettlement()
        {
            InitializeComponent();
        }

        TransportLogic transportLogic = new TransportLogic();

        AuditingAction auditingAction = new AuditingAction("id", "transportSettlement");

        private void FrmTransportSettlement_Load(object sender, EventArgs e)
        {
            query(null);
        }

        private void query(string strWhere)
        {
            transportLogic.settlementBind(dgv_transportSettlement, strWhere);
        }

  

        private void btn_query_Click(object sender, EventArgs e)
        {
            query(transportLogic.getQueryStr(cmb_query, txt_quertStr));
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            FrmTransportSettlementAdd transportSettlementAdd = new FrmTransportSettlementAdd();            
            if (transportSettlementAdd.ShowDialog() == DialogResult.OK)
            {
                query(null);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_assessor_Click(object sender, EventArgs e)
        {
            
            int status;

            if (dgv_transportSettlement.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确认审核选中运输合同", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dgv_transportSettlement.SelectedRows)
                    {
                        // transportLogic.contractAssessor(dgvr.Cells[0].Value.ToString(), this.UserName);
                        status = auditingAction.DoAssessor(long.Parse(dgvr.Cells[0].Value.ToString()), this.UserName);
                        dgvr.Cells[7].Value = this.UserName;
                        //dgvr.Cells["审核日期"].Value = DateTime.Now;
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

        private void btn_view_Click(object sender, EventArgs e)
        {
            TransportSettlementView();
        }

        private void TransportSettlementView()
        {
            if (dgv_transportSettlement.SelectedRows.Count > 0)
            {
                FrmTransportSettlementView frmTransportSettlementView = new FrmTransportSettlementView();
                frmTransportSettlementView.Text = "核算单信息";
                frmTransportSettlementView.TransportSettlementDetailID = long.Parse(dgv_transportSettlement.SelectedRows[0].Cells[0].Value.ToString());
                frmTransportSettlementView.TransportContractName = dgv_transportSettlement.SelectedRows[0].Cells[2].Value.ToString();
                frmTransportSettlementView.ShowDialog();
            }
        }

        private void dgv_transportSettlement_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TransportSettlementView();
        }

        private void btn_checkupMan_Click(object sender, EventArgs e)
        {
            if (dgv_transportSettlement.SelectedRows.Count > 0)
            {

                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    int result = auditingAction.DoConfirm(long.Parse(dgv_transportSettlement.SelectedRows[0].Cells[0].Value.ToString()), this.UserName, frmConfirm.Confirm);
                    switch (result)
                    {
                        case 0:
                            if (frmConfirm.Confirm)
                            {
                                dgv_transportSettlement.SelectedRows[0].Cells["审批人"].Value = this.UserName;
                                //dgv_transportSettlement.SelectedRows[0].Cells["审批日期"].Value = DateTime.Now;
                                MessageBox.Show("审批成功");
                            }
                            else
                            {
                                dgv_transportSettlement.SelectedRows[0].Cells["审批人"].Value = "";
                                dgv_transportSettlement.SelectedRows[0].Cells["审核人"].Value = "";
                                //dgv_transportSettlement.SelectedRows[0].Cells["审核日期"].Value = "";
                                //dgv_transportSettlement.SelectedRows[0].Cells["审批日期"].Value = "";
                            }
                            break;

                    }
                }
                //}

            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.ContextMenuStrip.Show((Button)sender, new Point(e.X, e.Y));
        }

        private void 运输结算单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_transportSettlement.SelectedRows.Count > 0)
            {
                ReporttransportClass reportTransport = new ReporttransportClass();
                reportTransport.RunTransportCheck(dgv_transportSettlement.SelectedRows[0].Cells[0].Value.ToString());               
                
            }
        }

        private void 运输结算统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (dgv_transportSettlement.SelectedRows.Count > 0)
            {
                ReporttransportClass reportTransport = new ReporttransportClass();
                reportTransport.RunTransportCheckDetail(dgv_transportSettlement.SelectedRows[0].Cells[0].Value.ToString());               
                
            }
        }

        private void cmb_query_TextChanged(object sender, EventArgs e)
        {
            if (cmb_query.Text.Equals("全部"))
            {
                txt_quertStr.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

      

       


    }
}
