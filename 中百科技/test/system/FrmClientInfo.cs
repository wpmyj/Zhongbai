/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：ClientInfo
     * 文件功能描述：客户信息窗体
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
    public partial class FrmClientInfo : common.BaseForm
    {
        public FrmClientInfo()
        {
            InitializeComponent();
        }

        ClientClass clientClass = new ClientClass();
        ClientLogic clientLogic = new ClientLogic();
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
                clientClass.Name = txtName.Text.Trim();
            }
            else
            {
                clientClass.Name = "";
            }
            if (!txtArtificialMan.Text.Trim().Equals(""))
            {
                clientClass.ArtficialMan = txtArtificialMan.Text.Trim();
            }
            else
            {
                clientClass.ArtficialMan = "";
            }
            if (!cbxprincipal.Text.Trim().Equals(""))
            {
                clientClass.Principal = cbxprincipal.Text.Trim();
            }
            else
            {
                clientClass.Principal = "";
            }
            if (!txtAddress.Text.Trim().Equals(""))
            {
                clientClass.Address = txtAddress.Text.Trim();
            }
            else
            {
                clientClass.Address = "";
            }
            if (!txtPhone.Text.Trim().Equals(""))
            {
                clientClass.Phone = txtPhone.Text.Trim();
            }
            else
            {
                clientClass.Phone = "";
            }
            if (!cbxPostCode.Text.Trim().Equals(""))
            {
                clientClass.PostCode = cbxPostCode.Text.Trim();
            }
            else
            {
                clientClass.PostCode = "";
            }
            if (!txtEmail.Text.Trim().Equals(""))
            {
                clientClass.EMail = txtEmail.Text.Trim();
            }
            else
            {
                clientClass.EMail = "";
            }
            if (!txtRemark.Text.Trim().Equals(""))
            {
                clientClass.Remark = txtRemark.Text.Trim();
            }
            else
            {
                clientClass.Remark = "";
            }
            clientClass.InputMan = this.userName;
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
            txtName.Clear();
            txtArtificialMan.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtRemark.Clear();

            cbxPostCode.Text = "";
            //cbxPostCode.SelectedIndex = -1;
            cbxprincipal.Text = "";
            //cbxprincipal.SelectedIndex = -1;
        }
        #endregion

        #region SetDataGridView() 为DataGridView赋值
        /*
      * 方法名称： SetDataGridView()
      * 方法功能描述：为DataGridView赋值；
      *
      * 创建人：冯雪
      * 创建时间：2009-05-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void SetDataGridView()
        {
            dgvClient.DataSource = clientLogic.SearchClientAll("");
            dgvClient.Columns["id"].Visible = false;
            dgvClient.Columns["inputDate"].Visible = false;
            dgvClient.Columns["inputMan"].Visible = false;

        }
        #endregion

        #region 设置负责人、邮编；
        //private void setComboBox()
        //{
        //    cbxPostCode.DataSource = clientLogic.InitComboBox(2);
        //    cbxPostCode.DisplayMember = "邮编";
        //    cbxPostCode.SelectedIndex = -1;

        //    cbxprincipal.DataSource = clientLogic.InitComboBox(1);
        //    cbxprincipal.DisplayMember = "负责人";
        //    cbxprincipal.SelectedIndex = -1;
        //}
        #endregion

        private void FrmClientInfo_Load(object sender, EventArgs e)
        {

            // 初始化DataGridView;
            SetDataGridView();
            // 初始化负责人、邮编；
            //setComboBox();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{ 
                if (formHelper.inputCheck(groupBox1))
                {
                    // 获取要插入信息的内容；
                    SetPara();

                    #region  检查要插入的字段是否已存在；
                    if (clientLogic.SearchClientName(txtName.Text.Trim()))
                    {
                        MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearAction();
                        txtName.Focus();
                        return;
                    }
                    #endregion

                    // 插入产品信息记录；
                    if (clientLogic.FrmCliientInsert(clientClass))
                    {
                        ClearAction();
                        //MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            //}
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
            int clientId;

            DialogResult strDelete = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.YesNo);

            if (strDelete.ToString().Equals("No"))
            {
                return;
            }

            if (dgvClient.CurrentRow != null)
            {
                try
                {
                    clientId = Convert.ToInt32(dgvClient.CurrentRow.Cells[0].Value.ToString());
                        if (clientLogic.FrmCliientDelete(clientId))
                        {
                            //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information
                            SetDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("记录正在使用,删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 检查查询条件文本框是否含有非法字符
            if (!Check.CheckQueryIsEmpty(txtCondition.Text.Trim()))
            {
                MessageBox.Show("客户名称不能为空包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCondition.Text = "";
                txtCondition.Focus();
                return;
            }

            if (!Check.CheckEmpty(txtCondition.Text.Trim()))
            {
                SetDataGridView();
                return;
            }
            else
            {
                dgvClient.DataSource = clientLogic.SearchClientAll(txtCondition.Text.Trim());
                dgvClient.Columns["id"].Visible = false;
                dgvClient.Columns["inputDate"].Visible = false;
                dgvClient.Columns["inputMan"].Visible = false;
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

        private void FrmClientInfo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FrmClientInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvClient.CurrentRow != null)
            {
                clientClass.Id = Convert.ToInt32(dgvClient.CurrentRow.Cells["id"].Value.ToString());
                clientClass.Name = dgvClient.CurrentRow.Cells["客户名称"].Value.ToString();
                clientClass.ArtficialMan = dgvClient.CurrentRow.Cells["法人"].Value.ToString();
                clientClass.Address = dgvClient.CurrentRow.Cells["地址"].Value.ToString();
                clientClass.EMail = dgvClient.CurrentRow.Cells["Email"].Value.ToString();
                clientClass.Phone = dgvClient.CurrentRow.Cells["联系电话"].Value.ToString();
                clientClass.PostCode = dgvClient.CurrentRow.Cells["邮编"].Value.ToString();
                clientClass.Principal = dgvClient.CurrentRow.Cells["负责人"].Value.ToString();
                clientClass.Remark = dgvClient.CurrentRow.Cells["备注"].Value.ToString();

                FrmClientUpdate c_update = new FrmClientUpdate();
                c_update.Client = clientClass;
                if (c_update.ShowDialog(this) == DialogResult.OK)
                {
                    SetDataGridView();
                }
            }
        }
     
    }
}
