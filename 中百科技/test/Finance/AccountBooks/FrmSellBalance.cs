/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：SellBalance.cs
* 文件功能描述：销售核算账务管理
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
using System.Data.SqlClient;
using System.Windows.Forms;
using Iori.DataAccess.SQLServerDAL;
using DasherStation.common;

namespace DasherStation.Finance.AccountBooks
{
    public partial class FrmSellBalance : DasherStation.common.BaseForm
    {
        public FrmSellBalance()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SellBalanceLogic model = new SellBalanceLogic();
            this.cboClient.DataSource = model.GetClientInfo().Tables[0];
            this.cboClient.DisplayMember = "name";
            this.cboClient.ValueMember = "id";
            if(this.cboClient.Items.Count >0)
            {
                this.InitForm(model);
            }
        }

        private void InitForm(SellBalanceLogic model)
        {
            long iClientID;
            long.TryParse(this.cboClient.SelectedValue.ToString(), out iClientID);
            this.dtgSettlement.AutoGenerateColumns = false;
            this.dtgSettlement.DataSource = model.GetSellBalance(iClientID);
            this.dtgSettlement.DataMember = "table";
            this.dtgRecord.AutoGenerateColumns = false;
            this.dtgRecord.DataSource = model.GetPaidRecord(iClientID);
            this.dtgRecord.DataMember = "table";
            decimal mCount = model.GetAccountCount(iClientID);
            decimal mPaid = model.GetPaidCount(iClientID);
            this.txtAccountReceivable.Text = string.Format("{0:N2}", mCount);
            this.txtPaid.Text = string.Format("{0:N2}", mPaid);
            this.txtArrearage.Text = (mCount - mPaid).ToString("N2");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtPayment.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("本次收款不能为空!");
                return;
            }
            decimal mValue;
            if (decimal.TryParse(this.txtPayment.Text.Trim(), out mValue) == false)
            {
                DasherStation.HumanResource.CommUI.AlertError("在本次收款中请输入数值!");
                return;
            }
            if (decimal.Parse(this.txtPaid.Text) + decimal.Parse(this.txtPayment.Text) > decimal.Parse(this.txtAccountReceivable.Text))
            {
                DasherStation.HumanResource.CommUI.AlertError("已收总额不能大于应收总额!");
                return;
            }

            tFundsRecorderInfo entity = new tFundsRecorderInfo();
            tFundsRecorderInfo.tFundsRecorderRow oRow = entity.tFundsRecorder.NewtFundsRecorderRow();
            oRow.ciId = long.Parse(this.cboClient.SelectedValue.ToString());
            oRow.paidUp = mValue;
            oRow.type = EnumAccountType.收款.ToString();
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
            oRow.cash1 = decimal.Parse(this.txtAccountReceivable.Text);
            oRow.cash2 = decimal.Parse(this.txtArrearage.Text) - decimal.Parse(this.txtPayment.Text);
            entity.tFundsRecorder.AddtFundsRecorderRow(oRow);
            new SellBalanceLogic().AddPaid(entity);
            this.txtPayment.Text = "";
            this.chkCheck.Checked = false;
            this.chkInvoice.Checked = false;
            this.txtCheckNo.Text = "";
            this.txtInvoiceNo.Text = "";
            this.txtMemo.Text = "";
            this.InitForm(new SellBalanceLogic());
        }

        private void btnViewSettlementDetail_Click(object sender, EventArgs e)
        {
            if (this.dtgSettlement.CurrentRow != null)
            {
                long pSId = Convert.ToInt64(this.dtgSettlement.CurrentRow.Cells[0].Value.ToString());

                DasherStation.sell.FrmSalesSettlementAdd frmFSLAdd = new DasherStation.sell.FrmSalesSettlementAdd();
                frmFSLAdd.PSId = pSId;
                frmFSLAdd.Text = "核算单明细";
                frmFSLAdd.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择要查看的核算单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void cboClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitForm(new SellBalanceLogic());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //ReportHelper reportServer = new ReportHelper();
            //ReportData reportData = new ReportData();
            //List<ReportSource> reportSourceList = new List<ReportSource>();

            ////long planId = 0;
            ////if (dgvOverall.SelectedRows.Count > 0)
            ////{
            ////    planId = Convert.ToInt64(dgvOverall.SelectedRows[0].Cells["id"].Value.ToString());

            ////}

            ////reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.EquipmentRepairDataSetTableAdapters.basicInfoTableAdapter", "basicInfo", null));
            ////reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.EquipmentRepairDataSetTableAdapters.EquipmentRepairPlanTableAdapter", "EquipmentRepairPlan", new object[] { planId }));
            //reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ReceiveDataSetTableAdapters.personnelInfoTableAdapter", "personnelInfo", null));
            
            

            //reportData.DataSetName = "DasherStation.dataSet.ReceiveDataSet";
            //reportData.ReportName = "DasherStation.Report.ReceiveReport.rdlc";

            //reportData.ReportSourceList = reportSourceList;

            //reportServer.ShowReport(reportData);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnPrint_MouseDown(object sender, MouseEventArgs e)
        {
            btnPrint.ContextMenuStrip.Show((Button)sender, new Point(e.X, e.Y));
        }



        private void 打印应付款ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (cboClient.SelectedIndex != -1)
            {
                long iClientID;
                long.TryParse(this.cboClient.SelectedValue.ToString(), out iClientID);                
                ReportFinanceClass reportFinance = new ReportFinanceClass();
                reportFinance.RunShouldInputRecord(iClientID.ToString());
            }

        }

        private void 打印收款记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cboClient.SelectedIndex != -1)
            {
                long iClientID;
                long.TryParse(this.cboClient.SelectedValue.ToString(), out iClientID);                
                ReportFinanceClass reportFinance = new ReportFinanceClass();
                reportFinance.RunReceivablesRecord(iClientID.ToString());
            }

        }
    }


}
