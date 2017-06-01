/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：ProductInfo
     * 文件功能描述：产品信息窗体
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
    public partial class FrmProductInfo : common.BaseForm
    {
        public FrmProductInfo()
        {
            InitializeComponent();
        }

        ProductClass productClass = new ProductClass();
        ProductLogic pLogic = new ProductLogic();
        VindicateLogic vLogic = new VindicateLogic();
        FormHelper formHelper = new FormHelper();

        #region SetPara() 插入、更新时提取文本框、下拉列表框内容
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
        private void SetPara()
        {
            if (!cbxKind.SelectedValue.ToString().Equals(""))
            {
                productClass.PkId = Convert.ToInt32(cbxKind.SelectedValue.ToString());
            }
            else
            {
                productClass.PkId = 0;
            }
            if (!cbxName.Text.Trim().Equals(""))
            {
                productClass.PnId = Convert.ToInt32(cbxName.SelectedValue.ToString());
            }
            else
            {
                productClass.PnId = 0;
            }
            if (!cbxModel.Text.Trim().Equals(""))
            {
                productClass.PmId = Convert.ToInt32(cbxModel.SelectedValue.ToString());
            }
            else
            {
                productClass.PmId = 0;
            }
            if (!txtPdensity.Text.Trim().Equals(""))
            {
                productClass.Density = txtPdensity.Text.Trim();
            }
            else
            {
                productClass.Density = "";
            }
            if (!txtNStock.Text.Trim().Equals(""))
            {
                productClass.NadirStock = decimal.Parse(txtNStock.Text.Trim().ToString());
            }
            else
            {
                productClass.NadirStock = 0;
            }
            if (!txtPlanPrice.Text.Trim().Equals(""))
            {
                productClass.PlanPrice = decimal.Parse(txtPlanPrice.Text.Trim().ToString());
            }
            else
            {
                productClass.PlanPrice = 0;
            }
            if (!txtPremark.Text.Trim().Equals(""))
            {
                productClass.Remark = txtPremark.Text.Trim();
            }
            else
            {
                productClass.Remark = "";
            }
            if (!string.IsNullOrEmpty(txtRate.Text.Trim()))
            {
                productClass.Rate = decimal.Parse(txtRate.Text.Trim());
            }
            else
            {
                productClass.Rate = 0;
            }
            productClass.InputMan = this.userName;
        }
        #endregion

        #region ClearAction() 清空文本框、下拉列表框内容
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
            cbxKind.Text = "";
            cbxKind.SelectedIndex = -1;
            cbxName.Text = "";
            cbxName.SelectedIndex = -1;
            cbxModel.Text = "";
            cbxModel.SelectedIndex = -1;

            txtPdensity.Clear();
            txtRemark.Clear();
            txtNStock.Clear();
            txtPlanPrice.Clear();
            txtPremark.Clear();
            txtRate.Clear();
            
        }
        #endregion

        #region SetDataGridView() 为datagridview赋值
        private void SetDataGridView(string condition, int verifyBit)
        {
            dgvProduct.DataSource = pLogic.PSearchAll(condition, verifyBit);
            dgvProduct.Columns["id"].Visible = false;
        }
        #endregion

        #region SetcbxKind()设置产品种类
        /*
          * 方法名称： SetcbxKind()
          * 方法功能描述：设置产品种类；
          *
          * 创建人：冯雪
          * 创建时间：2009-02-17
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        private void SetcbxKind()
        {
            cbxKind.DataSource = pLogic.InitialPKindComboBox();
            cbxKind.DisplayMember = "产品种类";
            cbxKind.ValueMember = "id";
            cbxKind.SelectedIndex = -1;
        }
        #endregion

        #region cobBoBoxLinkage()选择产品种类后名称跟着联动
        /*
          * 方法名称： cobBoBoxLinkage()
          * 方法功能描述：选择产品种类后名称跟着联动；
          *
          * 创建人：冯雪
          * 创建时间：2009-02-17
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        private void cobBoBoxLinkage()
        {
            int pkId;

            if (cbxKind.SelectedValue == null)
            {
                pkId = 0;
            }
            else
            {
                pkId = Convert.ToInt32(cbxKind.SelectedValue.ToString());
            }
            if (pLogic.InitialPNameComboBox(pkId).Rows.Count != 0)
            {
                cbxName.DataSource = pLogic.InitialPNameComboBox(pkId);
                cbxName.DisplayMember = "产品名称";
                cbxName.ValueMember = "id";
                cbxName.SelectedIndex = -1;
            }
            else
            {
                cbxName.DataSource = pLogic.InitialPNameComboBox(pkId);
            }
            cbxModel.Text = "";
            cbxModel.SelectedIndex = -1;
        }
        #endregion

        #region SetcbxModel()设置产品规格
        /*
          * 方法名称： SetcbxModel()
          * 方法功能描述：设置产品规格；
          *
          * 创建人：冯雪
          * 创建时间：2009-02-17
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        private void SetcbxModel()
        {
            cbxModel.DataSource = vLogic.PModelSearch();
            cbxModel.DisplayMember = "产品规格";
            cbxModel.ValueMember = "id";
            cbxModel.SelectedIndex = -1;
        }
        #endregion


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                SetPara();
                
                #region  检查要插入的字段是否已存在；    
                if (pLogic.PSearchNameModel(productClass.PnId, productClass.PmId))
                {
                    MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearAction();
                    cbxPKind.Focus();
                    return;
                }
                #endregion
    
                #region 插入产品信息记录
                if (pLogic.FrmPoeductInsert(productClass))
                {
                    ClearAction();
                  //  MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetDataGridView("", 0);
                }
                else
                {
                    MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
                #endregion

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

        private void FrmProductInfo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnPKind_Click(object sender, EventArgs e)
        {
            InfoVindicate frmVindicate = new InfoVindicate();
            frmVindicate.Text = "新建产品种类";
            if (frmVindicate.ShowDialog(this) == DialogResult.OK)
            {
                SetcbxKind();
            }
        }

        private void FrmProductInfo_Load(object sender, EventArgs e)
        {
            // 初始化DataGrilView 
            SetDataGridView("",0);

            // 窗体初始状态设置所有下拉列表框、文本框不可编辑；
            SetcbxKind();
            cobBoBoxLinkage();
            SetcbxModel();

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

        private void cbxKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cobBoBoxLinkage();
        }

        private void btnPName_Click(object sender, EventArgs e)
        {
            InfoVindicate frmVindicate = new InfoVindicate();
            if (!string.IsNullOrEmpty(cbxKind.Text.Trim()))
            {
                frmVindicate.KindId = Convert.ToInt32(cbxKind.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("产品种类不能为空！请选择材料各类!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxKind.Focus();
                return;
            }
            frmVindicate.Text = "新建产品名称";
            if (frmVindicate.ShowDialog(this) == DialogResult.OK)
            {
                cobBoBoxLinkage();
            }
        }

        private void btnPModel_Click(object sender, EventArgs e)
        {
            
            InfoVindicate frmVindicate = new InfoVindicate();
            frmVindicate.Text = "新建产品规格";
            if (frmVindicate.ShowDialog(this) == DialogResult.OK)
            {
                SetcbxModel();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int productId;

            //DialogResult strDelete = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.YesNo);

            //if (strDelete.ToString().Equals("No"))
            //{
            //    return;
            //}
            if (dgvProduct.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (dgvProduct.SelectedRows.Count >0)
                        {
                            //productId = Convert.ToInt32(dgvProduct.CurrentRow.Cells["id"].Value.ToString());
                            productId = Convert.ToInt32((dgvProduct.SelectedRows[0].DataBoundItem as DataRowView).Row["id"].ToString());
                            if (pLogic.FrmPoeductDelete(productId))
                            {
                                //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                SetDataGridView("", 0);
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
        }
                  
        private void btnSearch_Click(object sender, EventArgs e)
        {
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
                    case "产品种类":
                            verifyBit = 1;
                            break;
                    case "产品名称":
                            verifyBit = 2;
                            break;
                    case "规格型号":
                            verifyBit = 3;
                            break;
                    default:
                            verifyBit = 0;
                            break;
                     
                }

                SetDataGridView(txtCondition.Text.Trim(), verifyBit);

                txtCondition.Text = "";
            }
        }

        private void FrmProductInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            productClass.Id = Convert.ToInt64(dgvProduct.CurrentRow.Cells["id"].Value.ToString());
            productClass.Kind = dgvProduct.CurrentRow.Cells["产品种类"].Value.ToString();
            productClass.Name = dgvProduct.CurrentRow.Cells["产品名称"].Value.ToString();
            productClass.Model = dgvProduct.CurrentRow.Cells["产品规格"].Value.ToString();
            if (!string.IsNullOrEmpty(dgvProduct.CurrentRow.Cells["最低库存量"].Value.ToString()))
            {
                productClass.NadirStock = decimal.Parse(dgvProduct.CurrentRow.Cells["最低库存量"].Value.ToString());
            }
            else
            {
                productClass.NadirStock = 0;
            }
            if (!string.IsNullOrEmpty(dgvProduct.CurrentRow.Cells["计划价格"].Value.ToString()))
            {
                productClass.PlanPrice = decimal.Parse(dgvProduct.CurrentRow.Cells["计划价格"].Value.ToString());
            }
            else
            {
                productClass.PlanPrice = 0;
            }
            //if (!string.IsNullOrEmpty(dgvProduct.CurrentRow.Cells["损耗率"].Value.ToString()))
            //{
            //    productClass.Rate = decimal.Parse(dgvProduct.CurrentRow.Cells["损耗率"].Value.ToString());
            //}
            //else
            //{
            //    productClass.Rate = 0;
            //}
            productClass.Density = dgvProduct.CurrentRow.Cells["密度"].Value.ToString();
            productClass.Remark = dgvProduct.CurrentRow.Cells["备注"].Value.ToString();

            FrmProductUpdate p_update = new FrmProductUpdate();

            p_update.Product = productClass;

            if (p_update.ShowDialog(this) == DialogResult.OK)
            {
                SetDataGridView("", 0);
            }
        }
    }
}
