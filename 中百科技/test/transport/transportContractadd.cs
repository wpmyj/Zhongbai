using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.produce;

namespace DasherStation.transport
{
    public partial class transportContractadd : common.BaseForm 
    {
        public transportContractadd()
        {
            InitializeComponent();
        }

        TransportLogic transportLogic = new TransportLogic();

        FormHelper formHelper = new FormHelper();

        DoCombox doCombox;

        DataTable dt;

        private void transportContractadd_Load(object sender, EventArgs e)
        {
            doCombox = new DoCombox(cmb_kind, cmb_name, cmb_model, transportLogic.getType(rbttype1, rbttype2));
            rbttype1.CheckedChanged += rbttype_CheckedChanged;
            rbttype2.CheckedChanged += rbttype_CheckedChanged;
            transportLogic.transportUnitBind(cmb_transportUnit);
            transportLogic.siteBind(cmb_site1);
            transportLogic.siteBind(cmb_site2);
            transportLogic.transportSettlementMethodBind(cmb_transportSettlementMethod);
            transportLogic.contractNoList(cmb_no);
            dt = transportLogic.CreatTable();
            dgv_transportGoods.DataSource = dt;
        }
        
        private void rbttype_CheckedChanged(object sender, EventArgs e)
        {
            doCombox = new DoCombox(cmb_kind, cmb_name, cmb_model, transportLogic.getType(rbttype1,rbttype2));
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            bool result=formHelper.inputCheck(groupBox2);
            if (result)
            {
                add_row();
            }
        }

        private void add_row()
        {
            DataRow dr = dt.NewRow();
            dr["name"] = cmb_name.Text;
            dr["model"] = cmb_model.Text;
            dr["site1"] = cmb_site1.Text;
            dr["site2"] = cmb_site2.Text;
            dr["distance"] = txt_distance.Text.Trim();
            dr["price"] = txt_price.Text.Trim();
            dr["Method"] = cmb_transportSettlementMethod.Text;
            dr["tsmid"] = cmb_transportSettlementMethod.SelectedValue.ToString();
            dr["nId"] = cmb_name.SelectedValue.ToString();
            dr["mId"] = cmb_model.SelectedValue.ToString();
            dr["Type"] = transportLogic.getType(rbttype1, rbttype2);
            dr["sid1"]=cmb_site1.SelectedValue.ToString();
            dr["sid2"] = cmb_site2.SelectedValue.ToString();

            dt.Rows.Add(dr);
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //if (dgv_transportGoods.SelectedRows.Count > 0)
            //{
            //    foreach (DataGridViewRow dgvr in dgv_transportGoods.SelectedRows)
            //    {
            //        this.dgv_transportGoods.Rows.Remove(dgvr);
            //    }
            //}
            MessageBox.Show(cmb_transportSettlementMethod.SelectedIndex.ToString());
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                if (checkContract())
                {
                    MessageBox.Show("合同名称或合同编号已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dgv_transportGoods.Rows.Count == 0)
                {
                    MessageBox.Show("合同明细数量不能为 0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    transportLogic.saveContract(getTransportContract(), getTransportGoodsInformationCorresponding());
                    this.DialogResult = DialogResult.OK;
                }
  

            }
        }

        private bool checkContract()
        {
            if (transportLogic.getcType(rbcType1, rbcType2) == 0)
            {
                return transportLogic.AlonekContract(cmb_no.Text.Trim(),txt_name.Text.Trim());
            }
            else
            {
                return transportLogic.AlonekContract(txt_sno.Text.Trim(), txt_name.Text.Trim());
            }
        }

        private TransportContract getTransportContract()
        {
            TransportContract transportContract = new TransportContract();

            transportContract.contractEndDate = dtp_contractEndDate.Value;
            transportContract.contractInkDate = dtp_contractInkDate.Value;
            transportContract.contractName = txt_name.Text.Trim();
            transportContract.contractStartDate = dtp_contractStartDate.Value;
            transportContract.inputMan = this.UserName;
            transportContract.remark = txt_remark.Text.Trim();
            if (transportLogic.getcType(rbcType1, rbcType2) == 0)
            {
                transportContract.no = cmb_no.Text.Trim();
            }
            else
            {
                transportContract.no = txt_sno.Text.Trim();
                transportContract.ParentId = long.Parse(cmb_no.SelectedValue.ToString());
            }
            transportContract.tuId = long.Parse(cmb_transportUnit.SelectedValue.ToString());

            return transportContract;
        }

        private List<TransportGoodsInformationCorresponding> getTransportGoodsInformationCorresponding()
        {

            TransportGoodsInformationCorresponding transportGoodsInformationCorresponding = null;

            List<TransportGoodsInformationCorresponding> list =new List<TransportGoodsInformationCorresponding>();

            foreach (DataGridViewRow dgvr in dgv_transportGoods.Rows)
            {
                transportGoodsInformationCorresponding = new TransportGoodsInformationCorresponding();
                transportGoodsInformationCorresponding.distance = decimal.Parse(dgvr.Cells["distance"].Value.ToString());
                transportGoodsInformationCorresponding.inputMan = this.UserName;

                string mnid = dgvr.Cells["nid"].Value.ToString();
                string mmid = dgvr.Cells["mid"].Value.ToString();

                if (dgvr.Cells["Type"].Value.ToString() == TransportLogic.TranType.material.ToString())
                {  
                    transportGoodsInformationCorresponding.mId = long.Parse(new Produce().queryMid(mnid, mmid).ToString());
                }
                else
                {
                    transportGoodsInformationCorresponding.pId = long.Parse(new Produce().queryPid(mnid, mmid).ToString());
                }

                transportGoodsInformationCorresponding.price = decimal.Parse(dgvr.Cells["price"].Value.ToString());
                transportGoodsInformationCorresponding.sId1 = long.Parse(dgvr.Cells["sid1"].Value.ToString());
                transportGoodsInformationCorresponding.sId2 = long.Parse(dgvr.Cells["sid2"].Value.ToString());
                transportGoodsInformationCorresponding.tsmId = long.Parse(dgvr.Cells["tsmid"].Value.ToString());

                list.Add(transportGoodsInformationCorresponding);
            }

            return list;
        }

        private void rbcType_CheckedChanged(object sender, EventArgs e)
        {
            if (transportLogic.getcType(rbcType1, rbcType2) == 0)
            {          
                cmb_no.DropDownStyle = ComboBoxStyle.DropDown;
                cmb_no.Text = string.Empty;
                lbl_sno.Visible = false;
                txt_sno.Visible = false;
                txt_sno.Tag = string.Empty;
            }
            else
            {
                cmb_no.DropDownStyle = ComboBoxStyle.DropDownList;
                cmb_no.SelectedIndex = -1;
                lbl_sno.Visible = true;
                txt_sno.Visible = true;
                txt_sno.Tag = "ES";
            }
        }




        








        
        

     

       
    }
}
