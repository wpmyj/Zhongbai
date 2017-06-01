/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：ProviderInfo
     * 文件功能描述：供应商信息窗体
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
    public partial class FrmDetail : common.BaseForm
    {
        public FrmDetail()
        {
            InitializeComponent();
        }

        ProviderLogic providerLogic = new ProviderLogic();
        ProviderClass providerClass = new ProviderClass();
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
            if (!txtName.Text.Trim().Equals(""))
            {
                providerClass.Name = txtName.Text.Trim();
            }
            else
            {
                providerClass.Name = "";
            }
            if (!cbxArtificialMan.Text.Trim().Equals(""))
            {
                providerClass.ArtificialMan = cbxArtificialMan.Text.Trim();
            }
            else
            {
                providerClass.ArtificialMan = "";
            }
            if (!cbxPrincipal.Text.Trim().Equals(""))
            {
                providerClass.Principal = cbxPrincipal.Text.Trim();
            }
            else
            {
                providerClass.Principal = "";
            }
            if (!txtPhone.Text.Trim().Equals(""))
            {
                providerClass.Phone = txtPhone.Text.Trim();
            }
            else
            {
                providerClass.Phone = "";
            }
            if (!cbxPostCode.Text.Trim().Equals(""))
            {
                providerClass.PostCode = cbxPostCode.Text.Trim();
            }
            else
            {
                providerClass.PostCode = "";
            }
            if (!txtAddress.Text.Trim().Equals(""))
            {
                providerClass.Address = txtAddress.Text.Trim();
            }
            else
            {
                providerClass.Address = "";
            }
            if (!txtRemark.Text.Trim().Equals(""))
            {
                providerClass.Remark = txtRemark.Text.Trim();
            }
            else
            {
                providerClass.Remark = "";
            }
            if (!txtEmail.Text.Trim().Equals(""))
            {
                providerClass.EMail = txtEmail.Text.Trim();
            }
            else
            {
                providerClass.EMail = "";
            }
            providerClass.InputMan = this.userName;
            if (!cbx_Mark.Text.Trim().Equals(""))
            {
                if (cbx_Mark.Text.Trim().Equals("原材料供应商"))
                {
                    providerClass.Mark = 0;
                }
                if (cbx_Mark.Text.Trim().Equals("备品备件供应商"))
                {
                    providerClass.Mark = 1;
                }
            }
            else
            {
                providerClass.Mark = 0;
            }
            if (!txtProduceNo.Text.Trim().Equals(""))
            {
                providerClass.ProduceNo = txtProduceNo.Text.Trim();
            }
            else
            {
                providerClass.ProduceNo = "";
            }
        }
        #endregion

        #region ClearAction()清空文本框、下拉列表框内容
        /*
      * 方法名称： ClearAction()
      * 方法功能描述：清空文本框、下拉列表框内容；
      *
      * 创建人：冯雪
      * 创建时间：2009-02-23
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void ClearAction()
        {
            txtName.Text = "";
            cbxArtificialMan.Text= "";
            //cbxArtificialMan.SelectedIndex = -1;
            cbxPrincipal.Text = "";
            //cbxPrincipal.SelectedIndex = -1;
            cbxPostCode.Text = "";
            //cbxPostCode.SelectedIndex = -1;
            cbx_Mark.Text = "";
            cbx_Mark.SelectedIndex = -1;

            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtRemark.Clear();
            txtProduceNo.Clear();
        }
        #endregion

        #region 设置供应商名称、法人、负责人、邮编
        /*
      * 方法名称： SetProvider()
      * 方法功能描述：设置供应商名称、法人、负责人、邮编；
      *
      * 创建人：冯雪
      * 创建时间：2009-02-23
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        //private void SetProvider()
        //{
        //    providerLogic.InitialProviderComboBox(cbxArtificialMan,2);
        //    cbxArtificialMan.DisplayMember = "artificialMan";
        //    cbxArtificialMan.SelectedIndex = -1;

        //    providerLogic.InitialProviderComboBox(cbxPrincipal,3);
        //    cbxPrincipal.DisplayMember = "principal";
        //    cbxPrincipal.SelectedIndex = -1;

        //    providerLogic.InitialProviderComboBox(cbxPostCode,4);
        //    cbxPostCode.DisplayMember = "postCode";
        //    cbxPostCode.SelectedIndex = -1;
        //}
        #endregion

        #region 设置DataGridView
        /*
      * 方法名称： SetDataGridView()
      * 方法功能描述：设置DataGridView；
      *
      * 创建人：冯雪
      * 创建时间：2009-02-23
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void SetDataGridView()
        {
            dgvProvider.DataSource = providerLogic.FrmProviderSearch("", 0);
            dgvProvider.Columns["id"].Visible = false;
            dgvProvider.Columns["生产许可证编号"].Width = 115;
            dgvProvider.Columns["法人"].Width = 70;
            dgvProvider.Columns["负责人"].Width = 70;

        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (formHelper.inputCheck(groupBox1))
            {
                // 提取下拉列表框内容；
                SetPara();
                      
                #region 检查要插入的数据在库中是否已存在；
                if (providerLogic.PSearchPName(txtName.Text.Trim()))
                {
                    MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearAction();
                    txtName.Focus();
                    return;
                }
                #endregion 

                if (providerLogic.FrmProviderInsert(providerClass))
                {
                    //MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearAction();

                    SetDataGridView();
                }
                else
                {
                    MessageBox.Show("新增记录失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
 
            }
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int truckId;
         
            //DialogResult strDelete = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.YesNo);
            if (dgvProvider.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    //if (strDelete.ToString().Equals("No"))
                    //{
                    //    return;
                    //}
                    try
                    {
                        if (dgvProvider.SelectedRows.Count > 0)
                        {
                            truckId = Convert.ToInt32(dgvProvider.SelectedCells[0].Value.ToString());

                            if (providerLogic.FrmProviderDelete(truckId))
                            {
                                //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                SetDataGridView();
                            }
                            else
                            {
                                MessageBox.Show("删除记录失败,请重新选择记录进行删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("记录正在使用，无法删除！");
                    }
            }
            else
            {
                MessageBox.Show("请选择要删除的行！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // verifyBit用来标识查询条件；
            int verifyBit;
            string Condition;

                // 检查用条件文本框是否含有非法字符
                if (!Check.CheckQuery(txtCondition.Text.Trim()))
                {
                    MessageBox.Show("查询条件包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCondition.Focus();
                    return;
                }
                else
                {
                    // 取出查询条件;
                    Condition = cbxCondition.Text.Trim();

                    switch (Condition)
                    {
                        case "供应商名称":        
                            verifyBit = 1;
                            break;
                        case "材料名称":
                            verifyBit = 2;
                            break;
                        case "负责人":
                            verifyBit = 3;
                            break;
                        default:
                            verifyBit = 0;
                            break;
                    }

                    // 执行查询;
                    dgvProvider.DataSource = providerLogic.FrmProviderSearch(txtCondition.Text.Trim(), verifyBit);
                    dgvProvider.Refresh();
                    txtCondition.Text = "";
                }
        }

        private void btnParticula_Click(object sender, EventArgs e)
        {
            int providerId;

            if (dgvProvider.CurrentRow != null)
            {
                providerId = Convert.ToInt32(dgvProvider.CurrentRow.Cells[0].Value.ToString());

                FrmGMaterialInfo gmaterialInfo = new FrmGMaterialInfo();
                gmaterialInfo.ProviderId = providerId;
                DialogResult result = gmaterialInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("无选中记录,请重新选择记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FrmDetail_Load(object sender, EventArgs e)
        {
            txtName.Focus();
            // 供应商名称、法人、负责人、邮编；
            //SetProvider();
            SetDataGridView();
        }

        private void FrmDetail_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FrmDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProvider.CurrentRow != null)
            {
                providerClass.Id = Convert.ToInt64(dgvProvider.CurrentRow.Cells["id"].Value.ToString());
                providerClass.Name = dgvProvider.CurrentRow.Cells["供应商名称"].Value.ToString();
                if (dgvProvider.CurrentRow.Cells["供应商类型"].Value.ToString().Equals("原材料供应商"))
                {
                    providerClass.Mark = 0;
                }
                if (dgvProvider.CurrentRow.Cells["供应商类型"].Value.ToString().Equals("备品备件供应商"))
                {
                    providerClass.Mark = 1;
                }
                providerClass.Phone = dgvProvider.CurrentRow.Cells["电话"].Value.ToString();
                providerClass.PostCode = dgvProvider.CurrentRow.Cells["邮编"].Value.ToString();
                providerClass.Principal = dgvProvider.CurrentRow.Cells["负责人"].Value.ToString();
                providerClass.ProduceNo = dgvProvider.CurrentRow.Cells["生产许可证编号"].Value.ToString();
                providerClass.Remark = dgvProvider.CurrentRow.Cells["备注"].Value.ToString();
                providerClass.Address = dgvProvider.CurrentRow.Cells["地址"].Value.ToString();
                providerClass.ArtificialMan = dgvProvider.CurrentRow.Cells["法人"].Value.ToString();

                FrmProviderUpdate P_Update = new FrmProviderUpdate();
                P_Update.Provider = providerClass;
                if (P_Update.ShowDialog(this) == DialogResult.OK)
                {
                    SetDataGridView();
                }
            }
        }



    }
}
