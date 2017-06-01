/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：TruckInfo
     * 文件功能描述：车辆信息窗体
     *
     * 创建人：
     * 创建时间：
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
using DasherStation.transport;

namespace DasherStation.system
{
    public partial class FrmTruckInfo : common.BaseForm
    {
        public FrmTruckInfo()
        {
            InitializeComponent();
        }

        TruckLogic truckLogic = new TruckLogic();
        TruckClass truckClass = new TruckClass();
        TransportLogic tLogic = new TransportLogic();
        FormHelper formHelper = new FormHelper();

        #region SetPara() 插入、更新时提取文本框、下拉列表框内容
        /*
      * 方法名称： SetPara()
      * 方法功能描述：插入、更新时提取文本框、下拉列表框内容；
      *
      * 创建人：冯雪
      * 创建时间：2009-02-16
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void SetPara()
        {
            if (!txtNumber.Text.Trim().Equals(""))
            {
                truckClass.No = txtNumber.Text.Trim();
            }
            else
            {
                truckClass.No = "";
            }
            if (!cbxTUnit.Text.Trim().Equals(""))
            {
                truckClass.Conveyancer = Convert.ToInt32(cbxTUnit.SelectedValue.ToString());
            }
            else
            {
                truckClass.Conveyancer = 0;
            }
            if (!txtMName.Text.Trim().Equals(""))
            {
                truckClass.Owner = txtMName.Text.Trim();
            }
            else
            {
                truckClass.Owner = "";
            }
            if (!txtCName.Text.Trim().Equals(""))
            {
                truckClass.DriverName = txtCName.Text.Trim();
            }
            else
            {
                truckClass.DriverName = "";
            }
            if (!cbxCType.Text.Trim().Equals(""))
            {
                truckClass.Model = cbxCType.Text.Trim();
            }
            else
            {
                truckClass.Model = "";
            }
            if (!cbxCColor.Text.Trim().Equals(""))
            {
                truckClass.Color = cbxCColor.Text.Trim();
            }
            else
            {
                truckClass.Color = "";
            }
            if (!txtLength.Text.Trim().Equals(""))
            {
                truckClass.Lenth = decimal.Parse(txtLength.Text.Trim());
            }
            else
            {
                truckClass.Lenth = 0;
            }
            if (!txtWidth.Text.Trim().Equals(""))
            {
                truckClass.Width = decimal.Parse(txtWidth.Text.Trim());
            }
            else
            {
                truckClass.Width = 0;
            }
            if (!txtHeight.Text.Trim().Equals(""))
            {
                truckClass.Height = decimal.Parse(txtHeight.Text.Trim());
            }
            else
            {
                truckClass.Height = 0;
            }
            if (!txtTare.Text.Trim().Equals(""))
            {
                truckClass.Tare = decimal.Parse(txtTare.Text.Trim());
            }
            else
            {
                truckClass.Tare = 0;
            }
            if (!txtsTTare.Text.Trim().Equals(""))
            {
                truckClass.StandardTare = decimal.Parse(txtsTTare.Text.Trim());
            }
            else
            {
                truckClass.StandardTare = 0;
            }
            if (!txtSDWeight.Text.Trim().Equals(""))
            {
                truckClass.StandardDeadWeight = decimal.Parse(txtSDWeight.Text.Trim());
            }
            else
            {
                truckClass.StandardDeadWeight = 0;
            }
            if (!txtRemark.Text.Trim().Equals(""))
            {
                truckClass.Remark = txtRemark.Text.Trim();
            }
            else
            {
                truckClass.Remark = "";
            }
            truckClass.InputMan = this.userName;
            
        }
        #endregion

        #region ClearAction() 清空文本框、下拉列表框内容
        /*
      * 方法名称： ClearAction()
      * 方法功能描述：清空文本框、下拉列表框内容；
      *
      * 创建人：冯雪
      * 创建时间：2009-02-14
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void ClearAction()
        {
            txtNumber.Clear();            
            txtMName.Clear();
            txtCName.Clear();
            txtLength.Clear();
            txtWidth.Clear();
            txtHeight.Clear();
            txtsTTare.Clear();
            txtSDWeight.Clear();
            txtTare.Clear();
            txtRemark.Clear();

            cbxCColor.Text = "";
            cbxCColor.SelectedIndex = -1;
            cbxCType.Text = "";
            cbxCType.SelectedIndex = -1;
            cbxTUnit.Text = "";
            cbxTUnit.SelectedIndex = -1;
        }
        #endregion

        #region SetDataGridView() 为DataGridView赋值
        private void SetDataGridView()
        {
            dgvTruckInfo.DataSource = truckLogic.FrmTruckSearch("", 0);
            dgvTruckInfo.Columns["id"].Visible = false;
            dgvTruckInfo.Columns["录入日期"].Visible = false;
            dgvTruckInfo.Columns["录入人"].Visible = false;
            dgvTruckInfo.Columns["备注"].Visible = false;

            // 车辆型号、颜色赋值；
            cbxCType.DataSource = truckLogic.InitialTruckComboBox(1);
            cbxCType.DisplayMember = "model";
            cbxCType.Text = "";
            cbxCType.SelectedIndex = -1;

            cbxCColor.DataSource = truckLogic.InitialTruckComboBox(2);
            cbxCColor.DisplayMember = "color";
            cbxCColor.Text = "";
            cbxCColor.SelectedIndex = -1;
        }
        #endregion

        #region 设置运输单位信息
        private void SetUnit()
        {
            cbxTUnit.DataSource = tLogic.FrmTransportSearchAll("", 0);
            cbxTUnit.DisplayMember = "单位名称";
            cbxTUnit.ValueMember = "id";
            cbxTUnit.SelectedIndex = -1;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            { 
                // 提取下拉列表框内容；
                SetPara();

                #region  检查要插入的字段是否已存在；
                if (truckLogic.SearchTruckNo(txtNumber.Text.Trim()))
                {
                    MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearAction();
                    txtNumber.Focus();
                    return;
                }
                #endregion

                // 插入产品信息记录；
                if (truckLogic.FrmTruckInsert(truckClass))
                {
                    ClearAction();
                    MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetDataGridView();
                }
                else
                {
                    MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int truckId;

            //DialogResult strDelete = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.YesNo);

            //if (strDelete.ToString().Equals("No"))
            //{
            //    return;
            //}
            if (dgvTruckInfo.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (dgvTruckInfo.SelectedRows.Count >0)
                        {
                            truckId = Convert.ToInt32(dgvTruckInfo.SelectedCells[0].Value.ToString());

                            if (truckLogic.FrmTruckDelete(truckId))
                            {
                                //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                SetDataGridView();
                            }
                            //else
                            //{
                            //    MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("记录正在使用，无法删除！");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的行！");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // verifyBit用来标识查询条件；
            int verifyBit;
            string Condition;
            
            try
            {
                // 检查用条件文本框是否含有非法字符
                if (!Check.CheckQuery(txtCondition.Text.Trim()))
                {
                    MessageBox.Show("查询条件包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCondition.Focus();
                    return;
                }
                // 按查询框的信息进行模糊查询
                else
                {
                    // 取出查询条件;
                    Condition = cbxCondition.Text;

                    switch (Condition)
                    {
                        case "车牌号":
                            verifyBit = 1;
                            break;
                        case "运输单位":
                            verifyBit = 2;
                            break;
                        case "车主姓名":
                            verifyBit = 3;
                            break;
                        case "司机姓名":
                            verifyBit = 4;
                            break;
                        case "车辆型号":
                            verifyBit = 5;
                            break;
                        case "车辆颜色":
                            verifyBit = 6;
                            break;
                        default:
                            verifyBit = 0;
                            break;
                    }

                    dgvTruckInfo.DataSource = truckLogic.FrmTruckSearch(txtCondition.Text.Trim(), verifyBit);
                    dgvTruckInfo.Columns["id"].Visible = false;
                    dgvTruckInfo.Columns["录入日期"].Visible = false;
                    dgvTruckInfo.Columns["录入人"].Visible = false;
                    dgvTruckInfo.Columns["备注"].Visible = false;
                    txtCondition.Text = "";
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

        private void FrmTruckInfo_Load(object sender, EventArgs e)
        {
            SetDataGridView();
            txtNumber.Focus();
            SetUnit();
        }

        private void FrmTruckInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // 实现回车后焦点换到下一文本框中；
                
                if (e.KeyChar == (char)13)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
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

        private void btnTUnit_Click(object sender, EventArgs e)
        {
            FrmTransportCompaniesInfo frmTcInfo = new FrmTransportCompaniesInfo();
            if (frmTcInfo.ShowDialog(this) == DialogResult.OK)
            { 
                SetUnit();
            }
        }

        private void FrmTruckInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTruckInfo.CurrentRow != null)
            {
                truckClass.Id = Convert.ToInt64(dgvTruckInfo.CurrentRow.Cells["id"].Value.ToString());
                truckClass.Model = dgvTruckInfo.CurrentRow.Cells["车辆型号"].Value.ToString();
                truckClass.No = dgvTruckInfo.CurrentRow.Cells["车牌号"].Value.ToString();
                truckClass.Owner = dgvTruckInfo.CurrentRow.Cells["车主姓名"].Value.ToString();
                truckClass.Remark = dgvTruckInfo.CurrentRow.Cells["备注"].Value.ToString();
                truckClass.C_name = dgvTruckInfo.CurrentRow.Cells["运输单位"].Value.ToString();
                truckClass.Color = dgvTruckInfo.CurrentRow.Cells["车辆颜色"].Value.ToString();
                truckClass.DriverName = dgvTruckInfo.CurrentRow.Cells["司机姓名"].Value.ToString();

                if (!dgvTruckInfo.CurrentRow.Cells["车辆货箱高度"].Value.ToString().Equals(""))
                {
                    truckClass.Height = decimal.Parse(dgvTruckInfo.CurrentRow.Cells["车辆货箱高度"].Value.ToString());
                }
                else
                {
                    truckClass.Height = 0;
                }
                if (!dgvTruckInfo.CurrentRow.Cells["车辆货箱长度"].Value.ToString().Equals(""))
                {
                    truckClass.Lenth = decimal.Parse(dgvTruckInfo.CurrentRow.Cells["车辆货箱长度"].Value.ToString());
                }
                else
                {
                    truckClass.Lenth = 0;
                }
                if (!dgvTruckInfo.CurrentRow.Cells["标准载重量"].Value.ToString().Equals(""))
                {
                    truckClass.StandardDeadWeight = decimal.Parse(dgvTruckInfo.CurrentRow.Cells["标准载重量"].Value.ToString());
                }
                else
                {
                    truckClass.StandardDeadWeight = 0;
                }
                truckClass.StandardTare = decimal.Parse(dgvTruckInfo.CurrentRow.Cells["标准空载重量"].Value.ToString());
                if (!dgvTruckInfo.CurrentRow.Cells["车辆皮重"].Value.ToString().Equals(""))
                {
                    truckClass.Tare = decimal.Parse(dgvTruckInfo.CurrentRow.Cells["车辆皮重"].Value.ToString());
                }
                else
                {
                    truckClass.Tare = 0;
                }
                if (!dgvTruckInfo.CurrentRow.Cells["车辆货箱宽度"].Value.ToString().Equals(""))
                {
                    truckClass.Width = decimal.Parse(dgvTruckInfo.CurrentRow.Cells["车辆货箱宽度"].Value.ToString());
                }
                else
                {
                    truckClass.Width = 0;
                }

                FrmVoitureUpdate v_update = new FrmVoitureUpdate();
                v_update.Truck = truckClass;
                if (v_update.ShowDialog(this) == DialogResult.OK)
                {
                    SetDataGridView();
                }
            }
        }

    }
}
