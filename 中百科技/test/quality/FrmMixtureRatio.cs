/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：MixtureRatio
     * 文件功能描述：配合比
     *
     * 创建人：  夏阳明
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
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.quality
{
    public partial class FrmMixtureRatio : common.BaseForm
    {
        QualityLogic qualityLogic = new QualityLogic();

        private int deleteIndex;   // DataGridView中选择多行的行数
        private int Tid;            // 点击DataGridView时所取得的id；
        private int Pid;            // 点击DataGridView时所取得的Pid

        AuditingAction auditingActionT = new AuditingAction("id", "targetProportion");
        AuditingAction auditingActionP = new AuditingAction("id", "produceProportion");
        AuditingAction auditingActionRG = new AuditingAction("id", "proportion");

        public FrmMixtureRatio()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl.SelectedTab.Name == tbpT.Name)
                {
                    FrmMixtureRatioAdd formMixture = new FrmMixtureRatioAdd();
                    formMixture.ShowDialog();
                }

                if (tabControl.SelectedTab.Name == tbpP.Name)
                {  
                    FrmPMixtureRatio formPmixture = new FrmPMixtureRatio();
                    formPmixture.ShowDialog();
                }

                if (tabControl.SelectedTab.Name == tbpR.Name)
                {
                    FrmGYMixtureRatio formGYmixture = new FrmGYMixtureRatio();
                    formGYmixture.Text = "乳化沥青配合比";
                    formGYmixture.ShowDialog();
                }

                if (tabControl.SelectedTab.Name == tbpG.Name)
                {
                    FrmGYMixtureRatio formGYmixture = new FrmGYMixtureRatio();
                    formGYmixture.Text = "改性沥青配合比";
                    formGYmixture.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }

        }

        private void btnTNew_Click(object sender, EventArgs e)
        {
            FrmMixtureRatioAdd formMixture = new FrmMixtureRatioAdd();
            try
            {
                if (formMixture.ShowDialog() == DialogResult.OK)
                {
                    qualityLogic.FrmMixtureRatioSearch("", "", 0, dgvT, dgvP, dgvR, dgvG);
                    if (dgvT.Rows.Count != 0)
                    {
                        dgvT.Rows[0].Selected = false;
                    }
                }
                if (formMixture.DialogResult == DialogResult.OK)
                {
                    qualityLogic.FrmMixtureRatioSearch("", "", 0, dgvT, dgvP, dgvR, dgvG);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void btnPNew_Click(object sender, EventArgs e)
        {
            FrmPMixtureRatio formPmixture = new FrmPMixtureRatio();
            try
            {
                if (formPmixture.ShowDialog() == DialogResult.OK)
                {
                    qualityLogic.FrmMixtureRatioSearch("", "", 0, dgvT, dgvP, dgvR, dgvG);
                    if (dgvP.Rows.Count != 0)
                    {
                        dgvP.Rows[0].Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
            
        }

        private void btnRNew_Click(object sender, EventArgs e)
        {
            FrmGYMixtureRatio formGYmixture = new FrmGYMixtureRatio();
            try
            {
                formGYmixture.Text = "乳化沥青配合比";
                if (formGYmixture.ShowDialog() == DialogResult.OK)
                {
                    qualityLogic.FrmMixtureRatioSearch("", "", 0, dgvT, dgvP, dgvR, dgvG);
                    if (dgvR.Rows.Count != 0)
                    {
                        dgvR.Rows[0].Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void btnGNew_Click(object sender, EventArgs e)
        {
            FrmGYMixtureRatio formGYmixture = new FrmGYMixtureRatio();
            try
            {
                formGYmixture.Text = "改性沥青配合比";
                if (formGYmixture.ShowDialog() == DialogResult.OK)
                {
                    qualityLogic.FrmMixtureRatioSearch("", "", 0, dgvT, dgvP, dgvR, dgvG);
                    if (dgvG.Rows.Count != 0)
                    {
                        dgvG.Rows[0].Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void FrmMixtureRatio_Load(object sender, EventArgs e)
        {
            try
            {
                this.UserName = "夏阳明";
                qualityLogic.FrmMixtureRatioSearch("", "", 0, dgvT, dgvP, dgvR, dgvG);
                if (dgvT.Rows.Count != 0)
                {
                    dgvT.Rows[0].Selected = false;
                }
                if (dgvP.Rows.Count != 0)
                {
                    dgvP.Rows[0].Selected = false;
                }
                if (dgvR.Rows.Count != 0)
                {
                    dgvR.Rows[0].Selected = false;
                }
                if (dgvG.Rows.Count != 0)
                {
                    dgvG.Rows[0].Selected = false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
            
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string conditionStr;
            string condition;
            string searchStr;

            try
            {
                conditionStr = cbxCond.Text.Trim();

                searchStr = txtSearchStr.Text.Trim();

                switch (conditionStr)
                {
                    case "产品种类":
                        condition = "sort";
                        break;
                    case "产品名称":
                        condition = "name";
                        break;
                    case "规格型号":
                        condition = "model";
                        break;
                    case "录入时间":
                        condition = "inputDate";
                        break;
                    default:
                        condition = "1";
                        break;

                }
                if ((condition != "1") && (searchStr != ""))
                {
                    qualityLogic.FrmMixtureRatioSearch(searchStr, condition, 1, dgvT, dgvP, dgvR, dgvG);
                }
                else
                {
                    qualityLogic.FrmMixtureRatioSearch(searchStr, condition, 0, dgvT, dgvP, dgvR, dgvG);
                }
                dgvTDetail.DataSource = null;
                dgvRDetail.DataSource = null;
                dgvGDetail.DataSource = null;
                foreach (Object obj in panelTable.Controls)
                {
                    if (obj.GetType() == typeof(TextBox))
                    {
                        ((TextBox)obj).Text = "";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
            
        }

        private void btnTDelete_Click(object sender, EventArgs e)
        {
            bool deleteStatus;

            try
            {
                if (MessageBox.Show("确定删除所选中行吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    for (int i = 1; i <= deleteIndex; i++)
                    {
                        deleteStatus = qualityLogic.FrmMixtureRatioDeleteT(Convert.ToInt32(
                                                                  dgvT.SelectedRows[0].Cells[0].Value.ToString().Trim()), dgvT);

                        if (deleteStatus)
                        {
                            MessageBox.Show("删除第" + i + "条记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("删除第" + i + "条记录不成功，请从新操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void dgvT_Click(object sender, EventArgs e)
        {
            if (dgvT.SelectedRows.Count > 0)
            {
                deleteIndex = dgvT.SelectedRows.Count;

                if (dgvT.CurrentRow.Cells[0].Value != null)
                {
                    int.TryParse(dgvT.CurrentRow.Cells[0].Value.ToString(), out Tid);
                    dgvTDetail.DataSource = (qualityLogic.FrmProportionSendSearchTP(Tid.ToString())).Tables[0];
                }
            }

        }

        private void dgvP_Click(object sender, EventArgs e)
        {
            if (dgvP.SelectedRows.Count > 0)
            {
                deleteIndex = dgvP.SelectedRows.Count;

                if (dgvP.CurrentRow.Cells[0].Value != null)
                {
                    int.TryParse(dgvP.CurrentRow.Cells[0].Value.ToString(), out Tid);
                    qualityLogic.proportionBind(this.panelTable, Tid.ToString());
                }
            }
            
        }

        private void dgvR_Click(object sender, EventArgs e)
        {
            if (dgvR.SelectedRows.Count > 0)
            {
                deleteIndex = dgvR.SelectedRows.Count;

                if (dgvR.CurrentRow.Cells[0].Value != null)
                {
                    int.TryParse(dgvR.CurrentRow.Cells[0].Value.ToString(), out Tid);
                    dgvRDetail.DataSource = (qualityLogic.FrmProportionSendSearchP(Tid.ToString())).Tables[0];
                }
            }
            
        }

        private void dgvG_Click(object sender, EventArgs e)
        {
            if (dgvG.SelectedRows.Count > 0)
            {
                deleteIndex = dgvG.SelectedRows.Count;

                if (dgvG.CurrentRow.Cells[0].Value != null)
                {
                    int.TryParse(dgvG.CurrentRow.Cells[0].Value.ToString(), out Tid);
                    dgvGDetail.DataSource = (qualityLogic.FrmProportionSendSearchPG(Tid.ToString())).Tables[0];
                }
            }
            
        }

        private void btnPDelete_Click(object sender, EventArgs e)
        {
            bool deleteStatus;

            try
            {
                if (MessageBox.Show("确定删除所选中行吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    for (int i = 1; i <= deleteIndex; i++)
                    {
                        deleteStatus = qualityLogic.FrmMixtureRatioDeleteP(Convert.ToInt32(
                                                                  dgvP.SelectedRows[0].Cells[0].Value.ToString().Trim()), dgvP);

                        if (deleteStatus)
                        {
                            MessageBox.Show("删除第" + i + "条记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("删除第" + i + "条记录不成功，请从新操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void btnRDelete_Click(object sender, EventArgs e)
        {
            bool deleteStatus;

            try
            {
                if (MessageBox.Show("确定删除所选中行吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    for (int i = 1; i <= deleteIndex; i++)
                    {
                        deleteStatus = qualityLogic.FrmMixtureRatioDeleteR(Convert.ToInt32(
                                                                  dgvR.SelectedRows[0].Cells[0].Value.ToString().Trim()), dgvR);

                        if (deleteStatus)
                        {
                            MessageBox.Show("删除第" + i + "条记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("删除第" + i + "条记录不成功，请从新操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void btnGDelete_Click(object sender, EventArgs e)
        {
            bool deleteStatus;

            try
            {
                if (MessageBox.Show("确定删除所选中行吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    for (int i = 1; i <= deleteIndex; i++)
                    {
                        deleteStatus = qualityLogic.FrmMixtureRatioDeleteG(Convert.ToInt32(
                                                                  dgvG.SelectedRows[0].Cells[0].Value.ToString().Trim()), dgvG);

                        if (deleteStatus)
                        {
                            MessageBox.Show("删除第" + i + "条记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("删除第" + i + "条记录不成功，请从新操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvT.Rows.Count != 0)
                {
                    dgvT.Rows[0].Selected = false;
                }
                if (dgvP.Rows.Count != 0)
                {
                    dgvP.Rows[0].Selected = false;
                }
                if (dgvR.Rows.Count != 0)
                {
                    dgvR.Rows[0].Selected = false;
                }
                if (dgvG.Rows.Count != 0)
                {
                    dgvG.Rows[0].Selected = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }   
        }

        private void btnAssessT_Click(object sender, EventArgs e)
        {
            int status;

            if (dgvT.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确认审核选中目标配合比", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dgvT.SelectedRows)
                    {
                        status = auditingActionT.DoAssessor(long.Parse(dgvr.Cells[0].Value.ToString()), this.UserName);
                        dgvr.Cells["assessorT"].Value = this.UserName;
                        dgvr.Cells["assessDateT"].Value = DateTime.Now;
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

        private void btnCheckupT_Click(object sender, EventArgs e)
        {
            if (dgvT.SelectedRows.Count > 0)
            {
                if (qualityLogic.FrmMixtureRatioSearchAssessor(long.Parse(dgvT.SelectedRows[0].Cells[0].Value.ToString())))
                {
                    MessageBox.Show("尚未审核不能审批！");
                    return;
                }
                else
                {
                    if (!qualityLogic.FrmMixtureRatioSearchCheckupMan(long.Parse(dgvT.SelectedRows[0].Cells[0].Value.ToString())))
                    {
                        MessageBox.Show("已经审批过不能再次审批");
                        return;
                    }
                }
                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    int result = auditingActionT.DoConfirm(long.Parse(dgvT.SelectedRows[0].Cells[0].Value.ToString()), this.UserName, frmConfirm.Confirm);
                    switch (result)
                    {
                        case 0:
                            if (frmConfirm.Confirm)
                            {
                                dgvT.SelectedRows[0].Cells["checkupManT"].Value = this.UserName;
                                dgvT.SelectedRows[0].Cells["checkupDateT"].Value = DateTime.Now;
                                MessageBox.Show("审批成功");
                            }
                            else
                            {
                                dgvT.SelectedRows[0].Cells["checkupManT"].Value = "";
                                dgvT.SelectedRows[0].Cells["assessorT"].Value = "";
                                dgvT.SelectedRows[0].Cells["assessDateT"].Value = "";
                                dgvT.SelectedRows[0].Cells["checkupDateT"].Value = "";
                            }
                            break;
                    }
                }

            }
        }

        private void btnAssessP_Click(object sender, EventArgs e)
        {
            string status;

            if (dgvP.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确认审核选中生产配合比", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dgvP.SelectedRows)
                    {
                        status = auditingActionP.DoAssessor(long.Parse(dgvr.Cells[0].Value.ToString()), this.UserName).ToString();
                        dgvr.Cells["assessorP"].Value = this.UserName;
                        dgvr.Cells["assessDateP"].Value = DateTime.Now;
                        if (status.Equals("0"))
                        {
                            MessageBox.Show("审核成功");
                        }
                        else
                        {
                            MessageBox.Show("出错，请重新操作");
                        }
                    }
                }
            }
        }

        private void btnCheckupP_Click(object sender, EventArgs e)
        {
            if (dgvP.SelectedRows.Count > 0)
            {
                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    int result = auditingActionP.DoConfirm(long.Parse(dgvP.SelectedRows[0].Cells[0].Value.ToString()), this.UserName, frmConfirm.Confirm);
                    switch (result)
                    {
                        case 0:
                            if (frmConfirm.Confirm)
                            {
                                dgvP.SelectedRows[0].Cells["checkupManP"].Value = this.UserName;
                                dgvP.SelectedRows[0].Cells["checkupDateP"].Value = DateTime.Now;
                                MessageBox.Show("审批成功");
                            }
                            else
                            {
                                dgvP.SelectedRows[0].Cells["checkupManP"].Value = "";
                                dgvP.SelectedRows[0].Cells["assessorP"].Value = "";
                                dgvP.SelectedRows[0].Cells["assessDateP"].Value = "";
                                dgvP.SelectedRows[0].Cells["checkupDateP"].Value = "";
                            }
                            break;
                    }
                }

            }
        }

        private void btnAssessR_Click(object sender, EventArgs e)
        {
            string status;

            if (dgvR.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确认审核选中乳化沥青配合比", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dgvR.SelectedRows)
                    {
                        status = auditingActionRG.DoAssessor(long.Parse(dgvr.Cells[0].Value.ToString()), this.UserName).ToString();
                        dgvr.Cells["assessorR"].Value = this.UserName;
                        dgvr.Cells["assessDateR"].Value = DateTime.Now;
                        if (status.Equals("0"))
                        {
                            MessageBox.Show("审核成功");
                        }
                        else
                        {
                            MessageBox.Show("出错，请重新操作");
                        }
                    }
                }
            }
        }

        private void btnCheckupR_Click(object sender, EventArgs e)
        {
            if (dgvR.SelectedRows.Count > 0)
            {
                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    int result = auditingActionRG.DoConfirm(long.Parse(dgvR.SelectedRows[0].Cells[0].Value.ToString()), this.UserName, frmConfirm.Confirm);
                    switch (result)
                    {
                        case 0:
                            if (frmConfirm.Confirm)
                            {
                                dgvR.SelectedRows[0].Cells["checkupManR"].Value = this.UserName;
                                dgvR.SelectedRows[0].Cells["checkupDateR"].Value = DateTime.Now;
                                MessageBox.Show("审批成功");
                            }
                            else
                            {
                                dgvR.SelectedRows[0].Cells["checkupManR"].Value = "";
                                dgvR.SelectedRows[0].Cells["assessorR"].Value = "";
                                dgvR.SelectedRows[0].Cells["assessDateR"].Value = "";
                                dgvR.SelectedRows[0].Cells["checkupDateR"].Value = "";
                            }
                            break;
                    }
                }

            }
        }

        private void btnAssessG_Click(object sender, EventArgs e)
        {
            string status;

            if (dgvG.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确认审核选中改性沥青配合比", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dgvG.SelectedRows)
                    {
                        status = auditingActionRG.DoAssessor(long.Parse(dgvr.Cells[0].Value.ToString()), this.UserName).ToString();
                        dgvr.Cells["assessorG"].Value = this.UserName;
                        dgvr.Cells["assessDateG"].Value = DateTime.Now;
                        if (status.Equals("0"))
                        {
                            MessageBox.Show("审核成功");
                        }
                        else
                        {
                            MessageBox.Show("出错，请重新操作");
                        }
                    }
                }
            }
        }

        private void btnCheckupG_Click(object sender, EventArgs e)
        {
            if (dgvG.SelectedRows.Count > 0)
            {
                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    int result = auditingActionRG.DoConfirm(long.Parse(dgvG.SelectedRows[0].Cells[0].Value.ToString()), this.UserName, frmConfirm.Confirm);
                    switch (result)
                    {
                        case 0:
                            if (frmConfirm.Confirm)
                            {
                                dgvG.SelectedRows[0].Cells["checkupManG"].Value = this.UserName;
                                dgvG.SelectedRows[0].Cells["checkupDateG"].Value = DateTime.Now;
                                MessageBox.Show("审批成功");
                            }
                            else
                            {
                                dgvG.SelectedRows[0].Cells["checkupManG"].Value = "";
                                dgvG.SelectedRows[0].Cells["assessorG"].Value = "";
                                dgvG.SelectedRows[0].Cells["assessDateG"].Value = "";
                                dgvG.SelectedRows[0].Cells["checkupDateG"].Value = "";
                            }
                            break;
                    }
                }

            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (dgvT.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgvT.SelectedRows[0].Cells[0].Value.ToString());

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.TargetProportionDataSetTableAdapters.targetProportionTableAdapter", "targetProportion", new object[] { id }));
                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.TargetProportionDataSetTableAdapters.targetProportionDetailTableAdapter", "targetProportionDetail", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.TargetProportionDataSet";
                reportData.ReportName = "DasherStation.Report.TargetProportionReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }

        private void btn_printP_Click(object sender, EventArgs e)
        {
            if (dgvP.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgvP.SelectedRows[0].Cells[0].Value.ToString());

                foreach (DataGridViewRow dr in dgvP.SelectedRows)
                {
                    dr.Cells[0].Value.ToString();
                }

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProduceProportionDataSetTableAdapters.produceProportionTableAdapter", "produceProportion", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.ProduceProportionDataSet";
                reportData.ReportName = "DasherStation.Report.ProduceProportionReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }

        private void btn_PrintR_Click(object sender, EventArgs e)
        {
            if (dgvR.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgvR.SelectedRows[0].Cells[0].Value.ToString());

                foreach (DataGridViewRow dr in dgvR.SelectedRows)
                {
                    dr.Cells[0].Value.ToString();
                }

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProportionDataSetTableAdapters.proportionTableAdapter", "proportion", new object[] { id }));
                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProportionDataSetTableAdapters.proportionDetailTableAdapter", "proportionDetail", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.ProportionDataSet";
                reportData.ReportName = "DasherStation.Report.ProportionReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }

        private void btn_PrintG_Click(object sender, EventArgs e)
        {
            if (dgvG.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgvG.SelectedRows[0].Cells[0].Value.ToString());

                foreach (DataGridViewRow dr in dgvG.SelectedRows)
                {
                    dr.Cells[0].Value.ToString();
                }

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProportionGDataSetTableAdapters.proportionTableAdapter", "proportion", new object[] { id }));
                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProportionGDataSetTableAdapters.proportionDetailTableAdapter", "proportionDetail", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.ProportionGDataSet";
                reportData.ReportName = "DasherStation.Report.ProportionGReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }

       
    }
}
