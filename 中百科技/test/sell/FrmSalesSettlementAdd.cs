using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DasherStation.sell
{
    public partial class FrmSalesSettlementAdd : common.BaseForm
    {
        public FrmSalesSettlementAdd()
        {
            InitializeComponent();
        }

        SalesSettlementLogic salesCLogic = new SalesSettlementLogic();
        DataSet ds = new DataSet();

        //private bool isNew;
        //public bool IsNew
        //{
        //    get { return isNew; }
        //    set { isNew = value; }
        //}

        // 销售核算ID;
        private long pSId;

        public long PSId
        {
            get { return pSId; }
            set { pSId = value; }
        }



        #region 初始化合同编号
        private void setCbxCNo()
        {
            cbxContractNO.DataSource = salesCLogic.SearchCNo();
            cbxContractNO.DisplayMember = "name";
            cbxContractNO.ValueMember = "id";
            cbxContractNO.SelectedItem = -1;
            cbxContractNO.Text = "";
        }
        #endregion

        #region  票据信息添加表信息绑定datagridview
        /*
      * 方法名称： detailBinding()
      * 方法功能描述：票据明细添加表信息绑定datagridview；
      *
      * 创建人：冯雪
      * 创建时间：2009-03-17
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void detailBinding()
        {
            ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("iId");
            dt.Columns.Add("barCode");
            dt.Columns.Add("inputDate");
            dt.Columns.Add("scname");
            dt.Columns.Add("sort");
            dt.Columns.Add("name");
            dt.Columns.Add("model");
            dt.Columns.Add("grossWeight");
            dt.Columns.Add("tare");
            dt.Columns.Add("suttle");
            dt.Columns.Add("cname");
            dt.Columns.Add("sId1");
            dt.Columns.Add("sId2");

            ds.Tables.Add(dt);
            dgvBillDetail.DataSource = ds.Tables[0]; 

        }
        #endregion

        #region GetIndent()销售合同明细信息
        /*
         * 方法名称： GetIndent()
         * 方法功能描述：票据信息；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private List<PSettlementselDetailClass> GetIndent()
        {
            PSettlementselDetailClass psdClass = new PSettlementselDetailClass();
            List<PSettlementselDetailClass> list = new List<PSettlementselDetailClass>();
            foreach (DataGridViewRow dgvr in dgvInvoice.Rows)   
            {
                psdClass.IId = Convert.ToInt64(dgvr.Cells["id"].Value.ToString());
                psdClass.Sum = Convert.ToDecimal(dgvr.Cells["money"].Value.ToString());
                psdClass.Count = Convert.ToInt64(dgvr.Cells["count"].Value.ToString());
                psdClass.InputMan = this.userName;

                list.Add(psdClass);
            }

            return list;
        }
        #endregion

        #region 计算采购合同明细的总金额
        private void caleContractDetailMoney()
        {
            foreach (DataGridViewRow dgvr1 in dgvInvoice.Rows)
            {
                int count = 0;
                decimal totalWeight = 0;
                decimal unitPrice = 0;
                
                foreach (DataGridViewRow dgvr2 in dgvBillDetail.Rows) 
                {
                    if (decimal.Parse(dgvr2.Cells["iId"].Value.ToString()) == decimal.Parse(dgvr1.Cells["id"].Value.ToString()))
                    {
                        unitPrice = decimal.Parse(dgvr1.Cells["unitPrice"].Value.ToString());
                        totalWeight += decimal.Parse(dgvr2.Cells["suttle"].Value.ToString());
                        dgvr1.Cells["quantity"].Value = Convert.ToString(totalWeight);
                        dgvr1.Cells["money"].Value = Convert.ToString(unitPrice * totalWeight);
                        count = count + 1;
                        dgvr1.Cells["count"].Value = Convert.ToString(count);
                    }
                }
                unitPrice = 0;
                count = 0;
                totalWeight = 0;
            }
            totalWeightSumCount();
        }
        #endregion

        #region 计算总金额总重量小票总数
        private void totalWeightSumCount()
        {
            decimal totalWeight = 0;
            decimal totalMoney = 0;
            int totalCount = 0;
            foreach (DataGridViewRow dgvr in dgvInvoice.Rows) 
            {
                if ((dgvr.Cells["quantity"].Value != null) && (dgvr.Cells["money"].Value != null))
                {
                    totalWeight += decimal.Parse(dgvr.Cells["quantity"].Value.ToString());
                    totalMoney += decimal.Parse(dgvr.Cells["money"].Value.ToString());

                }
                if (dgvr.Cells["count"].Value != null)
                    totalCount += int.Parse(dgvr.Cells["count"].Value.ToString());
            }
            txtQuantity.Text = Convert.ToString(totalWeight);
            txtMoney.Text = Convert.ToString(totalMoney);
            txtCount.Text = Convert.ToString(totalCount);
        }
        #endregion

        private void btn_ok_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvBillDetail.DataSource as DataTable;
            PSettlementClass psClass = new PSettlementClass();

            //psClass.ScId = Convert.ToInt64(this.cbxContractNO.SelectedValue.ToString());
            //psClass.InputMan = this.userName;
            //psClass.Sum = Convert.ToDecimal(txtMoney.Text.Trim().ToString());
            //psClass.TotalWeight = Convert.ToDecimal(txtQuantity.Text.Trim().ToString());
            //psClass.Count = Convert.ToInt64(txtCount.Text.Trim().ToString());

            if (dt == null)
            {
                MessageBox.Show("无核算票据信息,无法进行核算,请打描或输入票据条码！");
                return;
            }
            else
            {
                psClass.ScId = Convert.ToInt64(this.cbxContractNO.SelectedValue.ToString());
                psClass.InputMan = this.userName;
                psClass.Sum = Convert.ToDecimal(txtMoney.Text.Trim().ToString());
                psClass.TotalWeight = Convert.ToDecimal(txtQuantity.Text.Trim().ToString());
                psClass.Count = Convert.ToInt64(txtCount.Text.Trim().ToString());

                if (salesCLogic.InsertSPSettlement(psClass, this.userName, dgvInvoice, dgvBillDetail))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("无法进行核算,请重新进行核算！");
                    return;
                }

            }

        }

        private void FrmSalesSettlementAdd_Load(object sender, EventArgs e)
        {
            //初始化合同编号
            string condition = this.Text.Trim();
            if (condition.Equals("新建核算单"))
            {
                setCbxCNo();
            }
            else
            {
                txtBill.Enabled = false;
                cbxContractNO.Enabled = false;
                btn_ok.Enabled = false;
                dgvInvoice.AutoGenerateColumns = false;
                dgvInvoice.DataSource = salesCLogic.SettlementDisplay(PSId);
                //dgvInvoice.Columns["quantity"].Visible = false;
                //dgvInvoice.Columns["money"].Visible = false;
                //dgvInvoice.Columns["count"].Visible = false;

                dgvBillDetail.AutoGenerateColumns = false;
                dgvBillDetail.DataSource = salesCLogic.SellNoteDisplay(PSId);
            }
            
            
           
        }

        private void cbxContractNO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 提取所选择的合同
            long id = Convert.ToInt64(this.cbxContractNO.SelectedValue.ToString()); 
            // 显示该合同下的所有明细
            dgvInvoice.DataSource = salesCLogic.SearchCInvoice(id);

        }

        private void txtBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string barCode = this.txtBill.Text.ToString(); 
                DataTable dt = dgvBillDetail.DataSource as DataTable;
                long cid = Convert.ToInt64(this.cbxContractNO.SelectedValue.ToString());

                #region 判断小票是否存在
                 foreach (DataGridViewRow dgvr in dgvBillDetail.Rows)
                {
                    if (dgvr.Cells["barCode"].Value.ToString() == Convert.ToString(barCode))
                    {
                        MessageBox.Show("此票据的条码已经存在,请重新扫描！");
                        txtBill.Clear();
                        txtBill.Focus();
                        return;
                    }
                }
                #endregion 
               
                #region 判断票据是否存在
                 if (salesCLogic.SearchMarkExist(barCode))
                 {
                     MessageBox.Show("此票据的条码不存在,请重新扫描！");
                     txtBill.Clear();
                     txtBill.Focus();
                     return;
                 }

                #endregion

                #region 判断票据是否核算过
                if (salesCLogic.SearchCMark(barCode))
                {
                    MessageBox.Show("此票据的条码已经核算过,请重新扫描！");
                    txtBill.Clear();
                    txtBill.Focus();
                    return;
                }
                 #endregion

                #region 判断票据是否属于选定的合同
                if (salesCLogic.SearchCExist(cid, barCode))
                {
                    MessageBox.Show("此票据不存在于该合同下,请重新扫描！");
                    //cbxContractNO.Text = "";
                    txtBill.Clear();
                    txtBill.Focus();
                    return;
                }
                #endregion
                
                // 显示票据信息;
                if (dt == null)
                {
                    dgvBillDetail.DataSource = salesCLogic.SearchSellNote(barCode);
                }
                else
                {
                    salesCLogic.SearchNote(barCode, dt);
                }

                // 将票据信息与合同明细合并;
                caleContractDetailMoney();
                txtBill.Clear();

            }
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {

        }





    }
}
