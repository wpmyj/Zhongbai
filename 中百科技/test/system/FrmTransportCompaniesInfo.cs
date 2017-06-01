/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：TransportCompaniesInfo
     * 文件功能描述：运输单位信息窗体
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
    public partial class FrmTransportCompaniesInfo : common.BaseForm
    {
        public FrmTransportCompaniesInfo()
        {
            InitializeComponent();
        }

        TransportLogic transportLogic = new TransportLogic();
        TransportClass transportClass = new TransportClass();
        FormHelper formHelper = new FormHelper();

        #region SetPara()
        /*
      * 方法名称： SetPara() 插入、更新时提取文本框、下拉列表框内容
      * 方法功能描述：插入、更新时提取文本框、下拉列表框内容；
      *
      * 创建人：冯雪
      * 创建时间：2009-02-17
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void SetPara()
        {
            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                transportClass.Name = txtName.Text.Trim();
            }
            else
            {
                transportClass.Name = "";
            }
            if (!string.IsNullOrEmpty(txtCoproration.Text.Trim()))
            {
                transportClass.Corporation = txtCoproration.Text.Trim();
            }
            else
            {
                transportClass.Corporation = "";
            }
            if (!string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                transportClass.Address = txtAddress.Text.Trim();
            }
            else
            {
                transportClass.Address = "";
            }
            if (!string.IsNullOrEmpty(cbxprincipal.Text.Trim()))
            {
                transportClass.Principal = cbxprincipal.Text.Trim();
            }
            else
            {
                transportClass.Principal = "";
            }
            if (!string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                transportClass.Phone = txtPhone.Text.Trim();
            }
            else
            {
                transportClass.Phone = "";
            }
            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                transportClass.Email = txtEmail.Text.Trim();
            }
            else
            {
                transportClass.Email = "";
            }
            if (!string.IsNullOrEmpty(cbxPostCode.Text.Trim()))
            {
                transportClass.PostCode = cbxPostCode.Text.Trim();
            }
            else
            {
                transportClass.PostCode = "";
            }
            if (!string.IsNullOrEmpty(txtCapability.Text.Trim()))
            {
                transportClass.Capability = txtCapability.Text.Trim();
            }
            else
            {
                transportClass.Capability = "";
            }
            transportClass.InputMan = this.userName;
            if (!string.IsNullOrEmpty(txtRemark.Text.Trim()))
            {
                transportClass.Remark = txtRemark.Text.Trim();
            }
            else
            {
                transportClass.Remark = "";
            }
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
            cbxprincipal.Text ="";
            //cbxprincipal.SelectedIndex = -1;
            cbxPostCode.Text = "";
            //cbxPostCode.SelectedIndex = -1;

            txtName.Clear();
            txtCoproration.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtCapability.Clear();
            txtRemark.Clear();
        }
        #endregion

        #region SetDataGridView 为DataGridView赋值
        /*
      * 方法名称： SetDataGridView()
      * 方法功能描述：为DataGridView赋值；
      *
      * 创建人：冯雪
      * 创建时间：2009-03-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void SetDataGridView()
        {
            dgvTranspor.DataSource = transportLogic.FrmTransportSearchAll("", 0);
            dgvTranspor.Columns["id"].Visible = false;
            dgvTranspor.Columns["inputDate"].Visible = false;
            dgvTranspor.Columns["inputMan"].Visible = false;
            //dgvTranspor.Rows[0].Selected = false;

            // 为负责人、邮编赋值；
            //cbxprincipal.DataSource = transportLogic.InitComboBox(1);
            //cbxprincipal.DisplayMember = "负责人";
            //cbxprincipal.SelectedIndex = -1;

            //cbxPostCode.DataSource = transportLogic.InitComboBox(2);
            //cbxPostCode.DisplayMember = "邮编";
            //cbxPostCode.SelectedIndex = -1;
        }
        #endregion

        private void FrmTransportCompaniesInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                SetPara();

                #region  检查要插入的字段是否已存在
               if (transportLogic.SearchTransportName(txtName.Text.Trim()))
               {
                   MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   ClearAction();
                   txtName.Focus(); 
                   return;
               }
               #endregion

               // 插入运输单位信息记录；
                if ( transportLogic.FrmTransportInsert(transportClass))
               {
                   ClearAction();
                   //MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   SetDataGridView();
               }
               else
               {
                   MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }

                //cbxprincipal.DataSource = transportLogic.FrmTransportSearchAll("", 0);
                //cbxprincipal.DisplayMember = "负责人";
                //cbxprincipal.SelectedIndex = -1;

                //cbxPostCode.DataSource = transportLogic.FrmTransportSearchAll("", 0);
                //cbxPostCode.DisplayMember = "邮编";
                //cbxPostCode.SelectedIndex = -1;
 
            }

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int transportId;

            //DialogResult strDelete = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.YesNo);

            //if (strDelete.ToString().Equals("No"))
            //{
            //    return;
            //}
            if (dgvTranspor.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (dgvTranspor.SelectedRows.Count > 0)
                        {
                            transportId = Convert.ToInt32(dgvTranspor.SelectedCells[0].Value.ToString());
                            if (transportLogic.FrmTransportDelete(transportId))
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
                MessageBox.Show("选择要删除的行！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {        
            // verifyBit用来标识校验位；
            int verifyBit;
            string Condition;

            // 检查用条件文本框是否含有非法字符
            if (!Check.CheckQuery(txtCondition.Text.Trim()))
            {
                MessageBox.Show("查询条件包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // 按查询框的信息进行模糊查询
            else
            {
                // 取出查询条件;
                Condition = cbxCondition.Text;

                switch (Condition)
                {
                    case "单位名称":     
                        verifyBit = 1;
                        break;
                    case "法人":
                        verifyBit = 2;
                        break;
                    case "负责人":
                        verifyBit = 3;
                        break;
                    default:
                        verifyBit = 0;
                        break;
                }

                dgvTranspor.DataSource = transportLogic.FrmTransportSearchAll(txtCondition.Text.Trim(), verifyBit);
                dgvTranspor.Columns["id"].Visible = false;
                dgvTranspor.Columns["inputDate"].Visible = false;
                dgvTranspor.Columns["inputMan"].Visible = false;
                dgvTranspor.Rows[0].Selected = false;

                txtCondition.Text = "";
           }
        }

        private void FrmTransportCompaniesInfo_Load(object sender, EventArgs e)
        {
            // 为DataGridView赋值；
            SetDataGridView();
            txtName.Focus();
            txtCoproration.Focus();
        }

        private void FrmTransportCompaniesInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTranspor.CurrentRow != null)
            {
                transportClass.Id = Convert.ToInt64(dgvTranspor.CurrentRow.Cells["id"].Value.ToString());
                transportClass.Name = dgvTranspor.CurrentRow.Cells["单位名称"].Value.ToString();
                transportClass.Phone = dgvTranspor.CurrentRow.Cells["联系电话"].Value.ToString();
                transportClass.PostCode = dgvTranspor.CurrentRow.Cells["邮编"].Value.ToString();
                transportClass.Principal = dgvTranspor.CurrentRow.Cells["负责人"].Value.ToString();
                transportClass.Remark = dgvTranspor.CurrentRow.Cells["备注"].Value.ToString();
                transportClass.Address = dgvTranspor.CurrentRow.Cells["单位地址"].Value.ToString();
                transportClass.Capability = dgvTranspor.CurrentRow.Cells["运输能力"].Value.ToString();
                transportClass.Corporation = dgvTranspor.CurrentRow.Cells["法人"].Value.ToString();
                transportClass.Email = dgvTranspor.CurrentRow.Cells["Email"].Value.ToString();

                FrmTransportUpdate T_Update = new FrmTransportUpdate();
                T_Update.Transport = transportClass;
                if (T_Update.ShowDialog(this) == DialogResult.OK)
                {
                    SetDataGridView();
                }
            }
        }


    }
}
