using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.quality
{
    public partial class FrmExaminationEquipmentDetail : common.BaseForm
    {
        public FrmExaminationEquipmentDetail()
        {
            InitializeComponent();
        }

        QualityLogic FrmExaminationEquipmentDetailLogic = new QualityLogic();

        ExaminationEquipmentClass examinationEquipmentClass = new ExaminationEquipmentClass();

        private int index;         //DataGridView中点击某行的index

        private int deleteIndex;   //DataGridView中选择多行的行数

        private void FrmExaminationEquipmentDetail_Load(object sender, EventArgs e)
        {
            #region
            try
            {
               // DisableCtrls();
                cbxId.Focus();

                FrmExaminationEquipmentDetailLogic.InitialCbxId(cbxId);
                cbxId.DisplayMember = "no";
                cbxId.ValueMember = "no";
                cbxId.SelectedIndex = -1;

                FrmExaminationEquipmentDetailLogic.InitialCbxUnitPrice(cbxUnitPrice);
                cbxUnitPrice.DisplayMember = "unitPrice";
            //    cbxUnitPrice.ValueMember = "id";
                cbxUnitPrice.SelectedIndex = -1;

                FrmExaminationEquipmentDetailLogic.InitialCbxName(cbxName);
                cbxName.DisplayMember = "name";
            //    cbxName.ValueMember = "id";
                cbxName.SelectedIndex = -1;
                

                FrmExaminationEquipmentDetailLogic.InitialCbxModel(cbxModel);
                cbxModel.DisplayMember = "model";
          //      cbxModel.ValueMember = "id";
                cbxModel.SelectedIndex = -1;

                FrmExaminationEquipmentDetailLogic.InitialCbxCheckUnit(cbxCheckUnit);
                cbxCheckUnit.DisplayMember = "checkUnit";
                cbxCheckUnit.SelectedIndex = -1;

                FrmExaminationEquipmentDetailLogic.InitialCbxMaker(cbxMaker);
                cbxMaker.DisplayMember = "maker";
           //     cbxMaker.ValueMember = "id";
                cbxMaker.SelectedIndex = -1;

                FrmExaminationEquipmentDetailLogic.FrmExaminationEquipmentDetailSearch("", 1, dgvEquipment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
            #endregion
        }
        public void DisableCtrls()
        {
            #region
            cbxId.Enabled = false;
            cbxUnitPrice.Enabled = false;
            cbxName.Enabled = false;
            txtCheckPeriod.Enabled = false;
            cbxModel.Enabled = false;
            txtDepreciationYear.Enabled = false;
            txtDepreciationRate.Enabled = false;
            txtNetWorth.Enabled = false;
            txtAddUpSum.Enabled = false;
            dtpBuyDate.Enabled = false;
            txtState.Enabled = false;
            dptLatestCheckDate.Enabled = false;
            cbxCheckUnit.Enabled = false;
            cbxMaker.Enabled = false;
            txtRemark.Enabled = false;
            #endregion
        }
        public void EnableCtrls()
        {
            #region
            cbxId.Enabled = true;
            cbxUnitPrice.Enabled = true;
            cbxName.Enabled = true;
            txtCheckPeriod.Enabled = true;
            cbxModel.Enabled = true;
            txtDepreciationYear.Enabled = true;
            dtpBuyDate.Enabled = true;
            txtState.Enabled = true;
            dptLatestCheckDate.Enabled = true;
            cbxCheckUnit.Enabled = true;
            cbxMaker.Enabled = true;
            txtRemark.Enabled = true;
            #endregion
        }

        public void btnCreat_Click(object sender, EventArgs e)
        {
            #region
            ClearAction();
            EnableCtrls();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            cbxId.Focus();
            #endregion
        }

        public void ClearAction()
        {
            #region
            cbxId.SelectedIndex = -1;
            cbxUnitPrice.SelectedIndex = -1;
            cbxName.SelectedIndex = -1;
            txtCheckPeriod.Clear();
            cbxModel.SelectedIndex = -1;
            txtDepreciationYear.Clear();
            txtDepreciationRate.Clear();
            txtNetWorth.Clear();
            txtAddUpSum.Clear();
            dtpBuyDate.Value = DateTime.Now;
            txtState.Clear();
            dptLatestCheckDate.Value = DateTime.Now;
            cbxCheckUnit.SelectedIndex = -1;
            cbxMaker.SelectedIndex = -1;
            txtRemark.Clear();
            txtCondition.Clear();
            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region
            int verifyBitId = 0;
            int verifyBitMaker = 0;
            int verifyBitName = 0;
            int verifyBitModel = 0;
            int verifyBitCheckPeriod = 0;
            int verifyBitDepreciationYear = 0;

            bool insertStatus;
            bool updateStatus;

            try
            {
                //if (Convert.ToInt32(btnSave.Tag) == 1)
                //{
                    //执行插入操作
                    //仪器编号输入不能为空
                    if (!Check.CheckEmpty(cbxId.Text.Trim()))
                    {
                        MessageBox.Show("仪器编号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxId.Focus();
                        return;
                    }
                    //检查仪器编号是否含有非法字符
                    else if (!Check.CheckQuery(cbxId.Text.Trim()))
                    {
                        MessageBox.Show("仪器编号包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxId.Text = "";
                        cbxId.Focus();
                        return;
                    }
                    if (!Check.CheckEmpty(cbxUnitPrice.Text.Trim()))
                    {
                        MessageBox.Show("单价不能为空！");
                        cbxUnitPrice.Focus();
                        return;
                    }
                    //检查单价是否为正符点数
                    else if (!Check.CheckFloat(cbxUnitPrice.Text.Trim()))
                    {
                        MessageBox.Show("单价只能是数字，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxUnitPrice.Text = "";
                        cbxUnitPrice.Focus();
                        return;
                    }

                    if (!Check.CheckEmpty(cbxName.Text.Trim()))
                    {
                        MessageBox.Show("仪器名称不能为空！");
                        cbxName.Focus();
                        return;
                    }
                    //检查仪器名称是否含有非法字符
                    else if (!Check.CheckQuery(cbxName.Text.Trim()))
                    {
                        MessageBox.Show("仪器名称包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxName.Text = "";
                        cbxName.Focus();
                        return;
                    }
                    if (!Check.CheckEmpty(cbxModel.Text.Trim()))
                    {
                        MessageBox.Show("规格型号不能为空！");
                        cbxModel.Focus();
                        return;
                    }
                    //检查规格型号是否含有非法字符
                    if (!Check.CheckQuery(cbxModel.Text.Trim()))
                    {
                        MessageBox.Show("规格型号包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxModel.Text = "";
                        cbxModel.Focus();
                        return;
                    }
                    if (!Check.CheckEmpty(txtCheckPeriod.Text.Trim()))
                    {
                        MessageBox.Show("检定周期不能为空！");
                        txtCheckPeriod.Focus();
                        return;
                    }
                    //检查检定周期是否含有非法字符
                    if (!Check.CheckQuery(txtCheckPeriod.Text.Trim()))
                    {
                        MessageBox.Show("检定周期包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCheckPeriod.Clear();
                        txtCheckPeriod.Focus();
                        return;
                    }
                    if (!Check.CheckEmpty(txtDepreciationYear.Text.Trim()))
                    {
                        MessageBox.Show("折旧年限不能为空！");
                        txtDepreciationYear.Focus();
                        return;
                    }
                    //检查折旧年限是否含有非数字字符
                    if (!Check.CheckFloat(txtDepreciationYear.Text.Trim()))
                    {
                        MessageBox.Show("折旧年限只包含数字，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDepreciationYear.Clear();
                        txtDepreciationYear.Focus();
                        return;
                    }
                    if (!Check.CheckEmpty(txtState.Text.Trim()))
                    {
                        MessageBox.Show("状态不能为空！");
                        txtState.Focus();
                        return;
                    }
                    //检查状态是否含有非法字符
                    if (!Check.CheckQuery(txtState.Text.Trim()))
                    {
                        MessageBox.Show("状态包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtState.Clear();
                        txtState.Focus();
                        return;
                    }
                    if (!Check.CheckEmpty(cbxCheckUnit.Text.Trim()))
                    {
                        MessageBox.Show("检定单位不能为空！");
                        cbxCheckUnit.Focus();
                        return;
                    }
                    //检查检定单位是否含有非法字符
                    if (!Check.CheckQuery(cbxCheckUnit.Text.Trim()))
                    {
                        MessageBox.Show("检定单位包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxCheckUnit.Text = "";
                        cbxCheckUnit.Focus();
                        return;
                    }
                    if (!Check.CheckEmpty(cbxMaker.Text.Trim()))
                    {
                        MessageBox.Show("生产厂家不能为空！");
                        cbxMaker.Focus();
                        return;
                    }
                    //检查生产厂家是否含有非法字符
                    if (!Check.CheckQuery(cbxMaker.Text.Trim()))
                    {
                        MessageBox.Show("生产厂家包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxMaker.Text = "";
                        cbxMaker.Focus();
                        return;
                    }
                    //检查备注是否含有非法字符
                    if (!Check.CheckQuery(txtRemark.Text.Trim()))
                    {
                        MessageBox.Show("备注包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRemark.Text= "";
                        txtRemark.Focus();
                        return;
                    }
                    

                    //检查仪器编号唯一性
                    if (!FrmExaminationEquipmentDetailLogic.FrmExaminationEquipmentDetailCheckId(cbxId.Text.Trim()))
                    {
                        //仪器编号标识位置为1，不执行插入试验仪器规格型号表操作
                        verifyBitId = 1;
                    }
                    //检查单价唯一性
                    //if (!FrmExaminationEquipmentDetailLogic.FrmExaminationEquipmentDetailCheckUnitPrice(Convert.ToDouble(cbxUnitPrice.Text.Trim())))
                    //{
                        //单价标识位置为1，不执行插入试验仪器规格型号表操作
                    //    verifyBitUnitPrice = 1;
                    //}
                    //检查仪器名称唯一性
                    if (!FrmExaminationEquipmentDetailLogic.FrmExaminationEquipmentDetailCheckName(cbxName.Text.Trim()))
                    {
                        //仪器名称标识位置为1，不执行插入试验仪器名称表操作
                        verifyBitName = 1;
                    }
                    //检查规格型号唯一性
                    if (!FrmExaminationEquipmentDetailLogic.FrmExaminationEquipmentDetailCheckModel(cbxModel.Text.Trim()))
                    {
                        //规格型号标识位置为1，不执行插入试验仪器规格型号表操作
                        verifyBitModel = 1;
                    }
                    //检查生产厂家唯一性
                    if (!FrmExaminationEquipmentDetailLogic.FrmExaminationEquipmentDetailCheckMaker(cbxMaker.Text.Trim()))
                    {
                        //生产厂家标识位置为1，不执行插入试验仪器名称表操作
                        verifyBitMaker = 1;
                    }

                    SetPara();
                    Cal();

                    insertStatus = FrmExaminationEquipmentDetailLogic.FrmExaminationEquipmentDetailSave(examinationEquipmentClass,
                                   this.UserName, dgvEquipment, verifyBitId,verifyBitName, verifyBitModel,verifyBitMaker);

                    if (insertStatus)
                    {
                        MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FrmExaminationEquipmentDetailLogic.InitialCbxId(cbxId);
                        cbxId.DisplayMember = "no";

                        FrmExaminationEquipmentDetailLogic.InitialCbxUnitPrice(cbxUnitPrice);
                        cbxUnitPrice.DisplayMember = "unitPrice";
                  //      cbxUnitPrice.ValueMember = "id";

                        FrmExaminationEquipmentDetailLogic.InitialCbxName(cbxName);
                        cbxName.DisplayMember = "name";
                  //      cbxName.ValueMember = "id";

                        FrmExaminationEquipmentDetailLogic.InitialCbxModel(cbxModel);
                        cbxModel.DisplayMember = "model";
                  //      cbxModel.ValueMember = "id";

                        FrmExaminationEquipmentDetailLogic.InitialCbxCheckUnit(cbxCheckUnit);
                        cbxCheckUnit.DisplayMember = "checkUnit";

                        FrmExaminationEquipmentDetailLogic.InitialCbxMaker(cbxMaker);
                        cbxMaker.DisplayMember = "maker";
                 //       cbxMaker.ValueMember = "id";

                        ClearAction();

                        //设置刚添加完的记录为当前显示的加亮行（下面3行代码）
                        dgvEquipment.Rows[0].Selected = false;
                        index = dgvEquipment.Rows.Count - 1;
                        dgvEquipment.Rows[index].Selected = true;
                        dgvEquipment.FirstDisplayedScrollingRowIndex = index;
                    }
                    else
                    {
                        MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ClearAction();

                        return;
                    }
                    btnCreat.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
            #endregion
        }

        private void txtDepreciationYear_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDepreciationYear.Text != "")
                {
                    Cal();
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
        //计算方法，计算净值，累计折旧额等
        private void Cal()
        {
            #region
            try
            {
                //折旧率 = 1/折旧年限
                txtDepreciationRate.Text = (1 / double.Parse(txtDepreciationYear.Text)).ToString();
                //累计折旧额 = 使用年 * 年折旧额
                //年折旧额 = 单价 * 折旧率
                //txtAddUpSum.Text = ((DateTime.Now.Year - dtpBuyDate.Value.Year) *
                //                   examinationEquipmentClass.DepreciationRate * double.Parse(cbxUnitPrice.Text)).ToString();
                txtAddUpSum.Text = ((DateTime.Now.Year - dtpBuyDate.Value.Year) *
                                   (double.Parse(txtDepreciationRate.Text)) * (double.Parse(cbxUnitPrice.Text))).ToString();
                //净值 = 单价 - 累计折旧额
                txtNetWorth.Text = (double.Parse(cbxUnitPrice.Text) - double.Parse(txtAddUpSum.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
            #endregion
        }

        //插入、更新时提取文本框、下拉列表框内容；
        public void SetPara()
        {
            #region
            try
            {
                examinationEquipmentClass.No = cbxId.Text;
                examinationEquipmentClass.UnitPrice = Convert.ToDouble(cbxUnitPrice.Text);
                examinationEquipmentClass.Name = cbxName.Text;
                examinationEquipmentClass.CheckPeriod = txtCheckPeriod.Text;
                examinationEquipmentClass.Model = cbxModel.Text;
                examinationEquipmentClass.DepreciationYear = Convert.ToInt32(txtDepreciationYear.Text);
                examinationEquipmentClass.DepreciationRate = Convert.ToDouble(txtDepreciationRate.Text);
                examinationEquipmentClass.NetWorth = Convert.ToDouble(txtNetWorth.Text);
                examinationEquipmentClass.AddUpSum = Convert.ToDouble(txtAddUpSum.Text);
                examinationEquipmentClass.BuyDate = dtpBuyDate.Value.ToString();
                examinationEquipmentClass.State = txtState.Text;
                examinationEquipmentClass.LatestCheckDate = dptLatestCheckDate.Value.ToString();
                examinationEquipmentClass.CheckUnit = cbxCheckUnit.Text;
                examinationEquipmentClass.Maker = cbxMaker.Text;
                examinationEquipmentClass.Remark = txtRemark.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
            
            #endregion

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            #region
            try
            {
                //判断更新按钮，点击‘更新’，文本框变可编辑状态，按钮变成‘取消’；点‘取消’文本框又变成不可编辑状态，按钮变‘更新’
                if (Convert.ToInt32(btnUpdate.Tag) == 1)
                {
                    btnUpdate.Text = "取消";
                    EnableCtrls();
                    btnUpdate.Tag = 2;
                    btnSave.Tag = 2;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    btnCreat.Enabled = false;
                }
                else if (Convert.ToInt32(btnUpdate.Tag) == 2)
                {
                    btnUpdate.Text = "更新";
                    dgvEquipment_Click(sender, e);
                    btnUpdate.Tag = 1;
                    btnSave.Enabled = false;
                    btnCreat.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    ClearAction();
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
            #endregion
        }

        private void dgvEquipment_Click(object sender, EventArgs e)
        {
            #region
            try
            {
                //DisableCtrls();

                //btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                //cbxId.Text = dgvEquipment.CurrentRow.Cells[1].Value.ToString();
                //cbxName.Text = dgvEquipment.CurrentRow.Cells[2].Value.ToString();
                //cbxModel.Text = dgvEquipment.CurrentRow.Cells[3].Value.ToString();
                //cbxMaker.Text = dgvEquipment.CurrentRow.Cells[4].Value.ToString();
                //cbxUnitPrice.Text = dgvEquipment.CurrentRow.Cells[5].Value.ToString();
                //txtCheckPeriod.Text = dgvEquipment.CurrentRow.Cells[6].Value.ToString();
                //txtDepreciationYear.Text = dgvEquipment.CurrentRow.Cells[7].Value.ToString();
                //txtDepreciationRate.Text = dgvEquipment.CurrentRow.Cells[8].Value.ToString();
                //txtNetWorth.Text = dgvEquipment.CurrentRow.Cells[9].Value.ToString();
                //txtAddUpSum.Text = dgvEquipment.CurrentRow.Cells[10].Value.ToString();
                //dtpBuyDate.Text = dgvEquipment.CurrentRow.Cells[11].Value.ToString();
                //cbxCheckUnit.Text = dgvEquipment.CurrentRow.Cells[12].Value.ToString();
                //dptLatestCheckDate.Text = dgvEquipment.CurrentRow.Cells[13].Value.ToString();
                //txtState.Text = dgvEquipment.CurrentRow.Cells[14].Value.ToString();
                //txtRemark.Text = dgvEquipment.CurrentRow.Cells[15].Value.ToString();

                cbxId.Focus();

                //点击某行的index
                index = dgvEquipment.CurrentRow.Index;
                //选择多行的行数
                deleteIndex = dgvEquipment.SelectedRows.Count;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
            #endregion
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            #region
            bool deleteStatus;

            try
            {
                if (MessageBox.Show("确定删除所选中行吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    for (int i = 1; i <= deleteIndex; i++)
                    {
                        deleteStatus = FrmExaminationEquipmentDetailLogic.FrmExaminationEquipmentDetailForDelete(Convert.ToInt32(
                                                                  dgvEquipment.SelectedRows[0].Cells[0].Value.ToString().Trim()), dgvEquipment);

                        if (deleteStatus)
                        {
                            MessageBox.Show("删除第" + i + "条记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearAction();
                            btnUpdate.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("删除第" + i + "条记录不成功，请从新操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    ClearAction();
                    btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
            #endregion
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region
            int verifyBit;

            try
            {
                //如果仪器名称输入为空，查询全部
                if (!Check.CheckEmpty(txtCondition.Text.Trim()))
                {
                    verifyBit = 1;
                }
                //检查仪器名称文本框是否含有非法字符
                else if (!Check.CheckQuery(txtCondition.Text.Trim()))
                {
                    MessageBox.Show("仪器名称含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //按用户输入的仪器名称进行模糊查询
                else
                {
                    verifyBit = 0;
                }

                FrmExaminationEquipmentDetailLogic.FrmExaminationEquipmentDetailSearch(txtCondition.Text.Trim(), verifyBit, dgvEquipment);
                dgvEquipment.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
            #endregion
        }

        private void dtpBuyDate_Leave(object sender, EventArgs e)
        {
            Cal();
        }

        private void dptLatestCheckDate_Leave(object sender, EventArgs e)
        {
            Cal();
        }

        private void cbxId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FrmExaminationEquipmentDetailLogic.LoadInfo(cbxId.SelectedValue.ToString().Trim(),cbxName, cbxModel, dtpBuyDate, cbxMaker, cbxUnitPrice, txtDepreciationYear);
            Cal();
        }

        private void btn_PrintSearch_Click(object sender, EventArgs e)
        {
            FrmExaminationEquipmentDetailLogic.FrmExaminationEquipmentDetailPrintSearch(dtpCheckDate.Value, dgvEquipment);
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dtpCheckDate.Value.ToString()))
            {
                decimal id = decimal.Parse(dtpCheckDate.Value.ToString().Substring(0, 4));

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ExaminationEquipmentDetailDataSetTableAdapters.experimentationEquipmentInformationTableAdapter", "experimentationEquipmentInformation", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.ExaminationEquipmentDetailDataSet";
                reportData.ReportName = "DasherStation.Report.ExaminationEquipmentDetailReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }  
    }
}
