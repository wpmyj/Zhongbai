/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：MaterialInfo
     * 文件功能描述：原料信息窗体
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
    public partial class FrmMaterialInfo : common.BaseForm
    {
        public FrmMaterialInfo()
        {
            InitializeComponent();
        }

        MaterialClass materialClass = new MaterialClass();
        VindicateLogic vLogic = new VindicateLogic();
        MaterialLogic mLogic = new MaterialLogic();
        FormHelper formHelper = new FormHelper();

        #region  SetPara()插入、更新时提取文本框、下拉列表框内容
        /*
         * 方法名称： SetPara()
         * 方法功能描述：插入、更新时提取文本框、下拉列表框内容；
         *
         * 创建人：冯雪
         * 创建时间：2009-02-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public void SetPara()
        {
            if (!cbxMKind.Text.Trim().Equals(""))
            {
                materialClass.MkId = Convert.ToInt32(cbxMKind.SelectedValue.ToString());
            }
            else
            {
                materialClass.MkId = 0;
            }
            if (!cbxName.Text.Trim().Equals(""))
            {
                materialClass.MnId = Convert.ToInt32(cbxName.SelectedValue.ToString());
            }
            else
            {
                materialClass.MkId = 0;
            }
            if (!cbxSModel.Text.Trim().Equals(""))
            {
                materialClass.MmId = Convert.ToInt32(cbxSModel.SelectedValue.ToString());
            }
            else
            {
                materialClass.MmId = 0;
            }
            if (!txtDensity.Text.Trim().Equals(""))
            {
                materialClass.Density = txtDensity.Text.Trim();
            }
            else
            {
                materialClass.Density = "";
            }
            if (!txtNStock.Text.Trim().Equals(""))
            {
                materialClass.NadirStock = decimal.Parse(txtNStock.Text.Trim());
            }
            else
            {
                materialClass.NadirStock = 0;
            }
            if (!txtRemark.Text.Trim().Equals(""))
            {
                materialClass.Remark = txtRemark.Text.Trim();
            }
            else
            {
                materialClass.Remark = "";
            }
            if (!string.IsNullOrEmpty(txtRate.Text.Trim()))
            {
                materialClass.Rate = decimal.Parse(txtRate.Text.Trim());
            }
            else
            {
                materialClass.Rate = 0;
            }
            materialClass.InputMan = this.userName;
           
        }
        #endregion

        #region  ClearAction()清空文本框、下拉列表框内容
        /*
      * 方法名称： ClearAction()
      * 方法功能描述：清空文本框、下拉列表框内容；
      *
      * 创建人：冯雪
      * 创建时间：2009-02-17
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void ClearAction()
        {
            cbxMKind.Text = "";
            cbxMKind.SelectedIndex = -1;
            cbxName.Text = "";
            cbxName.SelectedIndex = -1;
            cbxSModel.Text = "";
            cbxSModel.SelectedIndex = -1;
            txtDensity.Clear();
            txtRemark.Clear();
            txtNStock.Clear();
            txtRate.Clear();

        }
        #endregion

        #region SetMKind()设置材料种类
        /*
      * 方法名称： SetMKind()
      * 方法功能描述：为材料种类赋值；
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void SetMKind()
        {
            cbxMKind.DataSource = mLogic.InitialMKindComboBox();
            cbxMKind.DisplayMember = "材料种类";
            cbxMKind.ValueMember = "id";
            cbxMKind.Text = "";
            cbxMKind.SelectedIndex = -1;
        }
        #endregion

        #region cobBoBoxLinkage()选择种类后，材料名称联动
        /*
      * 方法名称： cobBoBoxLinkage()
      * 方法功能描述：选择种类后，材料名称联动；
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void cobBoBoxLinkage()
        {
            int mkId;

            if (cbxMKind.SelectedValue == null)
            {
                mkId = 0;
            }
            else
            {
                mkId = Convert.ToInt32(cbxMKind.SelectedValue.ToString());
            }
            if (mLogic.InitialMNameComboBox(mkId).Rows.Count != 0)
            {
                cbxName.DataSource = mLogic.InitialMNameComboBox(mkId);
                cbxName.DisplayMember = "材料名称";
                cbxName.ValueMember = "id";
                cbxName.Text = "";
                cbxName.SelectedIndex = -1;
            }
            else
            {
                cbxName.DataSource = mLogic.InitialMNameComboBox(mkId);
            }
            cbxSModel.Text = "";
            cbxSModel.SelectedIndex = -1;
        }
        #endregion

        #region SetMModel()设置材料规格
        /*
      * 方法名称： SetMModel()
      * 方法功能描述：为材料规格赋值；
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void SetMModel()
        {
            cbxSModel.DataSource = vLogic.MModelSearch();
            cbxSModel.DisplayMember = "材料规格";
            cbxSModel.ValueMember = "id";
            cbxSModel.Text = "";
            cbxSModel.SelectedIndex = -1;
        }
        #endregion

        #region SetDataGridView() 设置DataGridView
        private void SetDataGridView(string condition, int verifyBit)
        {
            dgvMaterial.DataSource = mLogic.MSearchAll(condition, verifyBit);
            dgvMaterial.Columns["id"].Visible = false;
        }
        #endregion

        private void FrmMaterialInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                SetPara();

                #region 检查要插入的数据在库中是否已存在
                if (mLogic.MSearchNameModel(materialClass.MnId, materialClass.MmId))
                {
                    MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearAction();
                    cbxMKind.Focus();
                    return;
                }

                #endregion
                
                // 插入产品信息记录；
                if (mLogic.FrmMaterialInsert(materialClass))
                {
                    ClearAction();
                    //MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetDataGridView("", 0);
                }
                else
                {
                    MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //try
            //{
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
            //finally
            //{

            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int materialId;

            //DialogResult strDelete = MessageBox.Show("确定要删除选定记录吗?", "提示", MessageBoxButtons.YesNo);
            //if (strDelete.ToString().Equals("No"))
            //{
            //    return;
            //}
            if (dgvMaterial.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确定要删除选定记录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (dgvMaterial.SelectedRows.Count >0)
                        {
                            materialId = Convert.ToInt32((dgvMaterial.SelectedRows[0].DataBoundItem as DataRowView).Row["id"].ToString());
                            if (mLogic.FrmMaterialDelete(materialId))
                            {
                                //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                SetDataGridView("", 0);
                            }
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
            MaterialLogic mLogic = new MaterialLogic();
            string condition;
            int verifyBit;

            if (!Check.CheckQuery(txtCondition.Text.Trim()))
            {
                MessageBox.Show("查询条件包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                condition = cbxCondition.Text.Trim();

                switch (condition)
                {
                    case "材料种类":
                        verifyBit = 1;
                        break;
                    case "材料名称":
                        verifyBit = 2;
                        break;
                    case "材料规格":
                        verifyBit = 3;
                        break;
                    default:
                        verifyBit = 0;
                        break;
                }

                SetDataGridView(txtCondition.Text.Trim(), verifyBit);

                txtCondition.Text = "";
            }

            //try
            //{
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
            //finally
            //{

            //}
        }

        private void FrmMaterialInfo_Load(object sender, EventArgs e)
        {
            // 初始化DataGridView;
            SetDataGridView("", 0);
            // 初始化材料种类、名称、规格；
            SetMKind();
            SetMModel();
            
            //try
            //{    

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
            //finally
            //{

            //}
        }

        private void btnMKind_Click(object sender, EventArgs e)
        {
            InfoVindicate frmIV = new InfoVindicate();
            frmIV.Text = "新建材料种类";
            if (frmIV.ShowDialog(this) == DialogResult.OK)
            {
                SetMKind();
            }
        }

        private void btnKName_Click(object sender, EventArgs e)
        {
            
            InfoVindicate frmIV = new InfoVindicate();
            frmIV.Text = "新建材料名称";
            if (!string.IsNullOrEmpty(cbxMKind.Text.Trim()))
            {
                frmIV.KindId = Convert.ToInt32(cbxMKind.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("材料种类不能为空！请选择材料各类!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxMKind.Focus();
                return;
            }
            if (frmIV.ShowDialog(this) == DialogResult.OK)
            {
                // 检查材料种类是否为空;
                if (!Check.CheckEmpty(cbxMKind.Text.Trim()))
                {
                    MessageBox.Show("材料种类不能为空！请选择材料各类后在录入材料名称!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxMKind.Focus();
                    return;
                }
                else
                {
                    int mkId = Convert.ToInt32(cbxMKind.SelectedValue.ToString());

                    if (mLogic.InitialMNameComboBox(mkId).Rows.Count != 0)
                    {
                        cobBoBoxLinkage();
                    }
                    else
                    {
                        cbxName.DataSource = mLogic.InitialMNameComboBox(mkId);
                    }
                }
            }
        }

        private void btnMModle_Click(object sender, EventArgs e)
        {
            InfoVindicate frmIV = new InfoVindicate();
            frmIV.Text = "新建材料规格";
            if (frmIV.ShowDialog() == DialogResult.OK)
            {
                SetMModel();
            }
        }

        private void cbxMKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cobBoBoxLinkage();
        }

        private void FrmMaterialInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMaterial.CurrentRow != null)
            {
                materialClass.Id = Convert.ToInt32(dgvMaterial.CurrentRow.Cells["id"].Value.ToString());
                materialClass.Kind = dgvMaterial.CurrentRow.Cells["材料种类"].Value.ToString();
                materialClass.Name = dgvMaterial.CurrentRow.Cells["材料名称"].Value.ToString();
                materialClass.Model = dgvMaterial.CurrentRow.Cells["材料规格"].Value.ToString();
                if (!dgvMaterial.CurrentRow.Cells["最低库存量"].Value.ToString().Equals(""))
                {
                    materialClass.NadirStock = decimal.Parse(dgvMaterial.CurrentRow.Cells["最低库存量"].Value.ToString());
                }
                else
                {
                    materialClass.NadirStock = null;
                }
                materialClass.Density = dgvMaterial.CurrentRow.Cells["密度"].Value.ToString();
                if (!dgvMaterial.CurrentRow.Cells["损耗率"].Value.ToString().Equals(""))
                {
                    materialClass.Rate = decimal.Parse(dgvMaterial.CurrentRow.Cells["损耗率"].Value.ToString());
                }
                else
                {
                    materialClass.Rate = null;
                }
                materialClass.Remark = dgvMaterial.CurrentRow.Cells["备注"].Value.ToString();

                FrmMaterialUpdate m_Update = new FrmMaterialUpdate();
                m_Update.Material = materialClass;
                if (m_Update.ShowDialog(this) == DialogResult.OK)
                {
                    SetDataGridView("", 0);
                }
                
            }
        }

    }
}
