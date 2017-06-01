using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.transport
{
    public partial class FrmTransportSettlementView : common.BaseForm
    {
        public FrmTransportSettlementView()
        {
            InitializeComponent();
        }

        TransportLogic transportLogic = new TransportLogic();

        private long? transportSettlementDetailID;

        public long? TransportSettlementDetailID
        {
            get { return transportSettlementDetailID; }
            set { transportSettlementDetailID = value; }
        }

        private string transportContractName;

        public string TransportContractName
        {
            get { return transportContractName; }
            set { transportContractName = value; }
        }

        private void FrmTransportSettlementView_Load(object sender, EventArgs e)
        {
            transportLogic.siteBind(site1);
            transportLogic.siteBind(site2);
            transportLogic.siteBind(sid1);
            transportLogic.siteBind(sid2);
            transportLogic.transportSettlementMethodBind(tsmid);
            transportLogic.contractViewList(cmb_transportContract);

            this.cmb_transportContract.Text = TransportContractName;

            if (TransportSettlementDetailID != null)
            {
                //cmb_transportContract.SelectedIndex = transportLogic.FindIndex(cmb_transportContract, transportSettlementDetailID.ToString());
                GoodsInfoBind(transportSettlementDetailID.ToString());
            }
        }

        private void cmb_transportContract_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_transportContract.SelectedIndex > -1)
            {
                GoodsInfoBind(cmb_transportContract.SelectedValue.ToString());
            }
        }
        
        private void GoodsInfoBind(string tsid)
        {
            transportLogic.SettlementDetail(dgv_transportGoodsInformationCorresponding, tsid);
            //dgv_note.DataSource = null;
            this.txt_noteCount.Clear();
            this.txt_priceTotal.Clear();
            this.txt_suttleTotal.Clear();

            //NoteBind(tsid);
        }

        private void NoteBind(string tsid)
        {
            dgv_note.DataSource = transportLogic.noteViewBind(tsid).Tables[0];
            compute();
        }

        private void dgv_transportGoodsInformationCorresponding_SelectionChanged(object sender, EventArgs e)
        {
            //transportLogic.tgi_select(dgv_transportGoodsInformationCorresponding, dgv_note);
            if (dgv_transportGoodsInformationCorresponding.SelectedRows.Count > 0)
            {
                NoteBind(dgv_transportGoodsInformationCorresponding.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void compute()
        {
            int noteCount = dgv_note.Rows.Count;
            float suttleTotal = 0;
            float priceTotal = 0;
            foreach (DataGridViewRow dgvr in dgv_note.Rows)
            {
                if (dgvr.Cells["did"].Value != null && dgvr.Cells["suttle"].Value != null)
                {
                    suttleTotal += float.Parse(dgvr.Cells["suttle"].Value.ToString());
                    foreach (DataGridViewRow dgvrd in dgv_transportGoodsInformationCorresponding.Rows)
                    {
                        if (dgvrd.Cells["id"].Value != null && dgvrd.Cells["id"].Value.ToString() == dgvr.Cells["did"].Value.ToString() && dgvrd.Cells["distance"].Value != null && dgvrd.Cells["price"].Value != null && dgvrd.Cells["formula"].Value != null)
                        {
                            priceTotal += transportLogic.compute(dgvrd.Cells["price"].Value.ToString(), dgvr.Cells["suttle"].Value.ToString(), dgvrd.Cells["distance"].Value.ToString(), dgvrd.Cells["formula"].Value.ToString());
                        }
                    }
                }
            }
            this.txt_noteCount.Text = noteCount.ToString();
            this.txt_suttleTotal.Text = Math.Round(suttleTotal, 2).ToString();
            this.txt_priceTotal.Text = Math.Round(priceTotal, 2).ToString();
        }
    }
}
