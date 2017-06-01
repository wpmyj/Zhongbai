/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：FrmPurchaseBalance.cs
* 文件功能描述：采购核算账务管理
*
* 创建人： 杨林
* 创建时间：2009-03-05
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

namespace DasherStation.Finance.AccountBooks
{
    public partial class FrmPurchaseBalance : DasherStation.common.BaseForm
    {
        public FrmPurchaseBalance()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PurchaseBalanceLogic model = new PurchaseBalanceLogic();
            this.cboClient.DataSource = model.GetCustomInfo().Tables[0];
            this.cboClient.DisplayMember = "name";
            this.cboClient.ValueMember = "id";
            if (this.cboClient.Items.Count > 0)
            {
                this.InitForm(model);
            }
        }

        private void InitForm(PurchaseBalanceLogic model)
        {
            long iClientID;
            long.TryParse(this.cboClient.SelectedValue.ToString(), out iClientID);
            this.dtgSettlement.AutoGenerateColumns = false;
            this.dtgSettlement.DataSource = model.GetBalance(iClientID);
            this.dtgSettlement.DataMember = "table";
            this.dtgRecord.AutoGenerateColumns = false;
            this.dtgRecord.DataSource = model.GetRecord(iClientID);
            this.dtgRecord.DataMember = "table";
            decimal mCount = model.GetAccountPayable(iClientID);
            decimal mPaid = model.GetPaidUp(iClientID);
            this.txtCount1.Text = mCount.ToString();
            this.txtCount2.Text = mPaid.ToString();
            this.txtCount3.Text = (mCount - mPaid).ToString();
        }

        private void btnViewSettlementDetail_Click(object sender, EventArgs e)
        {
            if (this.dtgSettlement.CurrentRow != null)
            {
                long pSId = Convert.ToInt64(this.dtgSettlement.CurrentRow.Cells[0].Value.ToString());
                
                DasherStation.stock.FrmProSettlementAdd frmProSettlementAdd = new DasherStation.stock.FrmProSettlementAdd();

                frmProSettlementAdd.IsNew = false;
                frmProSettlementAdd.Text = "核算单明细";
                frmProSettlementAdd.StockContractId = pSId.ToString();
                frmProSettlementAdd.ScName = this.dtgSettlement.CurrentRow.Cells[2].Value.ToString();
                frmProSettlementAdd.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择要查看的核算单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            if (this.txtPayment.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("本次付款不能为空!");
                return;
            }
            decimal mValue;
            if (decimal.TryParse(this.txtPayment.Text.Trim(), out mValue) == false)
            {
                DasherStation.HumanResource.CommUI.AlertError("在本次付款中请输入数值!");
                return;
            }
            if (decimal.Parse(this.txtCount2.Text) + decimal.Parse(this.txtPayment.Text) > decimal.Parse(this.txtCount1.Text))
            {
                DasherStation.HumanResource.CommUI.AlertError("已付总额不能大于应付总额!");
                return;
            }
            tFundsRecorderInfo entity = new tFundsRecorderInfo();
            tFundsRecorderInfo.tFundsRecorderRow oRow = entity.tFundsRecorder.NewtFundsRecorderRow();
            oRow.customerId = long.Parse(this.cboClient.SelectedValue.ToString());
            oRow.paidUp = mValue;
            oRow.type = EnumAccountType.付款.ToString();
            if (this.chkCheck.Checked)
            {
                oRow.checkNo = this.txtCheckNo.Text.Trim();
            }
            if (this.chkInvoice.Checked)
            {
                oRow.invoiceNo = this.txtInvoiceNo.Text.Trim();
            }
            oRow.inputMan = this.UserName;
            if (this.txtMemo.Text.Trim() != "")
            {
                oRow.remark = this.txtMemo.Text.Trim();
            }
            oRow.cash1 = decimal.Parse(this.txtCount1.Text);
            oRow.cash2 = decimal.Parse(this.txtCount3.Text) - decimal.Parse(this.txtPayment.Text);
            entity.tFundsRecorder.AddtFundsRecorderRow(oRow);
            PurchaseBalanceLogic model = new PurchaseBalanceLogic();
            model.AddPaid(entity);
            this.txtPayment.Text = "";
            this.chkCheck.Checked = false;
            this.chkInvoice.Checked = false;
            this.txtCheckNo.Text = "";
            this.txtInvoiceNo.Text = "";
            this.txtMemo.Text = "";
            this.InitForm(model);
        }

        private void cboClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitForm(new PurchaseBalanceLogic());
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            long iClientID;
            long.TryParse(this.cboClient.SelectedValue.ToString(), out iClientID);
            ReportFinanceClass reportFinance = new ReportFinanceClass();
            reportFinance.RunShouldOutRecord(iClientID.ToString());


        }

        private void button2_Click(object sender, EventArgs e)
        {
            long iClientID;
            long.TryParse(this.cboClient.SelectedValue.ToString(), out iClientID);
            ReportFinanceClass reportFinance = new ReportFinanceClass();
            reportFinance.RunShouldOutRecord(iClientID.ToString());
        }
    }

}
