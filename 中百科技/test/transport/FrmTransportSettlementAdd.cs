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
    public partial class FrmTransportSettlementAdd : common.BaseForm
    {
        public FrmTransportSettlementAdd()
        {
            InitializeComponent();
        }

        TransportLogic transportLogic = new TransportLogic();

        private long? transportContractID;

        public long? TransportContractID
        {
            get { return transportContractID; }
            set { transportContractID = value; }
        }

        private void FrmTransportSettlementAdd_Load(object sender, EventArgs e)
        {
            transportLogic.siteBind(site1);
            transportLogic.siteBind(site2);
            transportLogic.siteBind(sid1);
            transportLogic.siteBind(sid2);
            transportLogic.transportSettlementMethodBind(tsmid);
            transportLogic.contractList(cmb_transportContract);
        }

        private void cmb_transportContract_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_transportContract.SelectedIndex > -1)
            {
                transportLogic.goodsInfoBind(dgv_transportGoodsInformationCorresponding,cmb_transportContract.SelectedValue.ToString());
                dgv_note.DataSource = null;
                this.txt_noteCount.Clear();
                this.txt_priceTotal.Clear();
                this.txt_suttleTotal.Clear();
            }
        }

        private void txt_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string code = this.txt_code.Text.ToString().Trim();
                if (!string.IsNullOrEmpty(code))
                {
                    if (transportLogic.checkNote(dgv_note, code))
                    {
                        DataTable dt = dgv_note.DataSource as DataTable;
                        DataTable dtNode = transportLogic.noteBind(code).Tables[0];
                        if (dtNode.Rows.Count > 0 && dtNode.Rows[0]["did"] != null && dtNode.Rows[0]["mark"] != null)
                        {
                            if ((bool)dtNode.Rows[0]["mark"]!= true)
                            {
                                if (transportLogic.checkDetail(dgv_transportGoodsInformationCorresponding, dtNode.Rows[0]["did"].ToString()))
                                {
                                    if (dt == null)
                                    {
                                        dgv_note.DataSource = dtNode;
                                    }
                                    else
                                    {
                                        dt.Merge(dtNode);
                                    }
                                    compute();
                                }
                                else
                                {
                                    MessageBox.Show("票据不属于该合同", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("票据已经核算过", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("票据编号错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else 
                    {
                        MessageBox.Show("票据信息已存在","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
                this.txt_code.Text = "";
                this.txt_code.Focus();
            }
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dgv_transportGoodsInformationCorresponding.SelectedRows[0].Cells["id"].Value.ToString());
        }

        private void dgv_transportGoodsInformationCorresponding_SelectionChanged(object sender, EventArgs e)
        {
            transportLogic.tgi_select(dgv_transportGoodsInformationCorresponding, dgv_note);
        }

        private void compute()
        {
            int noteCount = dgv_note.Rows.Count;
            float suttleTotal = 0;
            float priceTotal = 0;
            foreach (DataGridViewRow dgvrd in dgv_transportGoodsInformationCorresponding.Rows)
            {
                float settlementWeightTotal = 0;
                float settlementPriceTotal = 0;

                    foreach (DataGridViewRow dgvr in dgv_note.Rows)
                    {
                        if (dgvrd.Cells["id"].Value != null && dgvrd.Cells["id"].Value.ToString() == dgvr.Cells["did"].Value.ToString() && dgvrd.Cells["distance"].Value != null && dgvrd.Cells["price"].Value != null && dgvrd.Cells["formula"].Value != null)
                        {
                            suttleTotal += float.Parse(dgvr.Cells["suttle"].Value.ToString());
                            priceTotal += transportLogic.compute(dgvrd.Cells["price"].Value.ToString(), dgvr.Cells["suttle"].Value.ToString(), dgvrd.Cells["distance"].Value.ToString(), dgvrd.Cells["formula"].Value.ToString());
                            settlementPriceTotal += transportLogic.compute(dgvrd.Cells["price"].Value.ToString(), dgvr.Cells["suttle"].Value.ToString(), dgvrd.Cells["distance"].Value.ToString(), dgvrd.Cells["formula"].Value.ToString());
                            settlementWeightTotal += float.Parse(dgvr.Cells["suttle"].Value.ToString());
                        }
                    }
          
                 dgvrd.Cells["weightTotal"].Value = settlementWeightTotal;
                 dgvrd.Cells["priceTotal"].Value = settlementPriceTotal;
        
            }
            this.txt_noteCount.Text = noteCount.ToString();
            this.txt_suttleTotal.Text = Math.Round(suttleTotal, 2).ToString();
            this.txt_priceTotal.Text = Math.Round(priceTotal, 2).ToString();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (dgv_note.Rows.Count > 0)
            {
                if (MessageBox.Show("对所有票据进行结算", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    save();
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show("待结算票据数量为 0","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void save()
        {
            TransportSettlement transportSettlement = new TransportSettlement();
            transportSettlement.inputMan = this.UserName;
            transportSettlement.sum = decimal.Parse(txt_priceTotal.Text.Trim());
            transportSettlement.totalWeight = decimal.Parse(txt_suttleTotal.Text.Trim());
            transportSettlement.count = int.Parse(txt_noteCount.Text.Trim());
            transportSettlement.tcId = long.Parse(cmb_transportContract.SelectedValue.ToString());
            transportLogic.saveCompute(transportSettlement,dgv_transportGoodsInformationCorresponding,dgv_note,this.UserName);
        }
        
    }
}
