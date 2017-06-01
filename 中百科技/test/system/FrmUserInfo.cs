/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：UserInfo
* 文件功能描述：用户信息窗体
*
* 创建人：夏阳明
* 创建时间：20090216
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
using DasherStation.system;

namespace DasherStation.system
{
    public partial class FrmUserInfo : common.BaseForm
    {


        public FrmUserInfo()
        {
            InitializeComponent();
        }

        SystemLogic FrmUserInfoLogic = new SystemLogic();

        UserInfoClass userInfoClass = new UserInfoClass();

        private int index;         //DataGridView中点击某行的index

        private int deleteIndex;   //DataGridView中选择多行的行数

        private void FrmUserInfo_Load(object sender, EventArgs e)
        {
            #region
            try
            {
                //DisableCtrls();

                //btnDelete.Enabled = false;
                //btnSave.Enabled = false;
                //btnUpdate.Enabled = false;
                txtUserName.Focus();
                FrmUserInfoLogic.InitialCbxDuty(cbxDuty);
                cbxDuty.DisplayMember = "name";
                cbxDuty.ValueMember = "id";
                cbxDuty.SelectedIndex = -1;

                FrmUserInfoLogic.FrmUserInfoSearch("", 1, dgvUserInfo);
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

        private void btnCreat_Click(object sender, EventArgs e)
        {
            #region
            try
            {
                EnableCtrls();

                ClearAction();

                txtUserName.Focus();

                btnDelete.Enabled = false;

                btnUpdate.Enabled = false;

                btnSave.Enabled = true;

                cbxDuty.SelectedIndex = 0;

                btnSave.Tag = 1;

                radioButton1.Checked = true;
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
                //如果真实姓名输入为空，查询全部
                if (!Check.CheckEmpty(txtCondition.Text.Trim()))
                {
                    verifyBit = 1;
                }
                //检查真实姓名文本框是否含有非法字符
                else if (!Check.CheckQuery(txtCondition.Text.Trim()))
                {
                    MessageBox.Show("用户名包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //按用户输入的用户名进行模糊查询
                else
                {
                    verifyBit = 0;
                }

                FrmUserInfoLogic.FrmUserInfoSearch(txtCondition.Text.Trim(), verifyBit, dgvUserInfo);
                dgvUserInfo.Refresh();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region
            int sex;

            bool insertStatus;

            sex = 1;

            bool updateStatus;

            try
            {
                //if(Convert.ToInt32(btnSave.Tag) == 1)
                //{
                    //执行插入操作
                    //用户名输入不能为空
                    if (!Check.CheckEmpty(txtUserName.Text.Trim()))
                    {
                        MessageBox.Show("用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUserName.Focus();
                        return;
                    }
                    //检查用户名文本框是否含有非法字符
                    else if (!Check.CheckQuery(txtUserName.Text.Trim()))
                    {
                        MessageBox.Show("用户名包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUserName.Clear();
                        txtUserName.Focus();
                        return;
                    }
                    if (!Check.CheckEmpty(txtPassword.Text.Trim()))
                    {
                        MessageBox.Show("密码不能为空！");
                        txtPassword.Focus();
                        return;
                    }
                    //检查密码文本框是否含有非法字符
                    else if (!Check.CheckQuery(txtPassword.Text.Trim()))
                    {
                        MessageBox.Show("密码包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Clear();
                        txtPassword.Focus();
                        return;
                    }
                    //检查两次密码输入是否一致
                    if(txtPassword.Text.Trim() != txtRePassword.Text.Trim())
                    {
                        MessageBox.Show("密码输入不一致，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Clear();
                        txtRePassword.Clear();
                        txtPassword.Focus();
                        return;
                    }
                    if (!Check.CheckEmpty(txtName.Text.Trim()))
                    {
                        MessageBox.Show("真实姓名不能为空！");
                        txtName.Focus();
                        return;
                    }
                    //检查真实姓名文本框是否含有非法字符
                    else if (!Check.CheckQuery(txtName.Text.Trim()))
                    {
                        MessageBox.Show("真实姓名包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtName.Clear();
                        txtName.Focus();
                        return;
                    }
                    //检查年龄是否为正整数
                    if (!Check.CheckNumber(txtAge.Text.Trim()))
                    {
                        MessageBox.Show("年龄只能为正整数，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAge.Clear();
                        txtAge.Focus();
                        return;
                    }
                    //检查年龄是否在标准范围内
                    if ((Convert.ToInt32(txtAge.Text.Trim()) < 18) || (Convert.ToInt32(txtAge.Text.Trim()) > 70))
                    {
                        MessageBox.Show("年龄不在标准范围内，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAge.Clear();
                        txtAge.Focus();
                        return;
                    }
                    if (radioButton1.Checked)
                    {
                        sex = 1;
                    }
                    else if (radioButton2.Checked)
                    {
                        sex = 2;
                    }
                    //检查用户名唯一性
                    if (!FrmUserInfoLogic.FrmUserInfoSearchForUserName(txtUserName.Text.Trim()))
                    {
                        MessageBox.Show("用户名已存在，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUserName.Clear();
                        txtUserName.Focus();
                        return;
                    }

                    SetPara();

                    insertStatus = FrmUserInfoLogic.FrmUserInfoSave(userInfoClass, dgvUserInfo);

                    if (insertStatus)
                    {
                        //MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //dgvUserInfo.Rows[0].Selected = false;

                        ClearAction();
                        //btnSave.Enabled = false;
                        //设置刚添加完的记录为当前显示的加亮行（下面3行代码）
                        index = dgvUserInfo.Rows.Count - 1;
                        //dgvUserInfo.Rows[index].Selected = true;
                        //dgvUserInfo.FirstDisplayedScrollingRowIndex = index;

                        ClearAction();

                        txtUserName.Focus();

                        //cbxDuty.SelectedIndex = 0;

                        radioButton1.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ClearAction();
                        btnSave.Enabled = false;
                        return;
                    }
                    btnCreat.Enabled = true;
 //               }
                //else if (Convert.ToInt32(btnSave.Tag) == 2)
                //{
                //    //用户名输入不能为空
                //    if (!Check.CheckEmpty(txtUserName.Text.Trim()))
                //    {
                //        MessageBox.Show("用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtUserName.Focus();
                //        return;
                //    }
                //    //检查用户名文本框是否含有非法字符
                //    else if (!Check.CheckQuery(txtUserName.Text.Trim()))
                //    {
                //        MessageBox.Show("用户名包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtUserName.Clear();
                //        txtUserName.Focus();
                //        return;
                //    }
                //    if (!Check.CheckEmpty(txtPassword.Text.Trim()))
                //    {
                //        MessageBox.Show("密码不能为空！");
                //        txtPassword.Focus();
                //        return;
                //    }
                //    //检查密码文本框是否含有非法字符
                //    else if (!Check.CheckQuery(txtPassword.Text.Trim()))
                //    {
                //        MessageBox.Show("密码包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtPassword.Clear();
                //        txtPassword.Focus();
                //        return;
                //    }
                //    //检查两次密码输入是否一致
                //    if (txtPassword.Text.Trim() != txtRePassword.Text.Trim())
                //    {
                //        MessageBox.Show("密码输入不一致，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtPassword.Clear();
                //        txtPassword.Focus();
                //        return;
                //    }
                //    if (!Check.CheckEmpty(txtName.Text.Trim()))
                //    {
                //        MessageBox.Show("真实姓名不能为空！");
                //        txtName.Focus();
                //        return;
                //    }
                //    //检查真实姓名文本框是否含有非法字符
                //    else if (!Check.CheckQuery(txtName.Text.Trim()))
                //    {
                //        MessageBox.Show("真实姓名包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtName.Clear();
                //        txtName.Focus();
                //        return;
                //    }
                //    //检查年龄是否为正整数
                //    if (!Check.CheckNumber(txtAge.Text.Trim()))
                //    {
                //        MessageBox.Show("年龄只能为正整数，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtAge.Clear();
                //        txtAge.Focus();
                //        return;
                //    }
                //    //检查年龄是否在标准范围内
                //    if ((Convert.ToInt32(txtAge.Text.Trim()) < 18) || (Convert.ToInt32(txtAge.Text.Trim()) > 70))
                //    {
                //        MessageBox.Show("年龄不在标准范围内，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtAge.Clear();
                //        txtAge.Focus();
                //        return;
                //    }                    
                //    //执行更新操作
                //    if (radioButton1.Checked)
                //    {
                //        sex = 1;
                //    }
                //    else
                //    {
                //        sex = 2;
                //    }
                //    //检查用户名唯一性
                //    if (!FrmUserInfoLogic.FrmUserInfoSearchForUserName(txtUserName.Text.Trim()))
                //    {
                //        MessageBox.Show("用户名已存在，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        txtUserName.Clear();
                //        txtUserName.Focus();
                //        return;
                //    }

                //    SetPara();

                //    updateStatus = FrmUserInfoLogic.FrmUserInfoUpdate(userInfoClass,
                //                  Convert.ToInt32(dgvUserInfo.CurrentRow.Cells[0].Value.ToString().Trim()), dgvUserInfo);

                //    //点击选中行更新后该行仍然显示为选中状态（下面2行代码和起来用）
                //    dgvUserInfo.Rows[index].Selected = true;
                //    dgvUserInfo.FirstDisplayedScrollingRowIndex = index;

                //    if (updateStatus)
                //    {
                //        MessageBox.Show("更新记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //        ClearAction();
                //        btnUpdate.Enabled = false;
                //    }
                //    else
                //    {
                //        MessageBox.Show("更新记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //        ClearAction();
                //        btnUpdate.Enabled = false;
                //        return;
                //    }
                //}

                //DisableCtrls();
                //btnCreat.Enabled = true;
                //btnUpdate.Text = "更新";

                //if(Convert.ToInt32(btnUpdate.Tag) == 2)
                //{
                //    btnUpdate.Tag = 1;
                //}
                
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
        //清空文本框和下拉列表框
        private void ClearAction()
        {
            #region
            txtUserName.Clear();
            txtPassword.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtRePassword.Clear();
            cbxDuty.SelectedIndex = -1;
            #endregion
        }

        private void dgvUserInfo_Click(object sender, EventArgs e)
        {
            #region
            try
            {
                //DisableCtrls();

              //  btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                //txtUserName.Text = dgvUserInfo.CurrentRow.Cells[1].Value.ToString();
                //txtPassword.Text = dgvUserInfo.CurrentRow.Cells[2].Value.ToString();
                //txtName.Text = dgvUserInfo.CurrentRow.Cells[3].Value.ToString();
                //txtAge.Text = dgvUserInfo.CurrentRow.Cells[5].Value.ToString();
                //cbxDuty.Text = dgvUserInfo.CurrentRow.Cells[6].Value.ToString();

                txtUserName.Focus();

                if (dgvUserInfo.CurrentRow.Cells[4].Value.ToString() == "男")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                //点击某行的index
                index = dgvUserInfo.CurrentRow.Index;
                //选择多行的行数
                deleteIndex = dgvUserInfo.SelectedRows.Count;
                
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
                    dgvUserInfo_Click(sender, e);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            #region
            bool updateStatus;

            try
            {
                if (MessageBox.Show("确定删除所选中行吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {

                    for (int i = 1; i <= deleteIndex; i++)
                    {
                        updateStatus = FrmUserInfoLogic.FrmUserInfoUpdateForDelete(Convert.ToInt32(
                                                                  dgvUserInfo.SelectedRows[0].Cells[0].Value.ToString().Trim()), dgvUserInfo);

                        if (updateStatus)
                        {
                            //MessageBox.Show("删除第" + i + "条记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ClearAction();
                            btnUpdate.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("删除第" + i + "条记录不成功，请从新操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    if (dgvUserInfo.Rows.Count != 0)
                    {
                        dgvUserInfo.Rows[0].Selected = false;
                    }
                    ClearAction();
                    //btnDelete.Enabled = false;
                    txtUserName.Focus();
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
        private void DisableCtrls()
        {
            #region
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            txtName.Enabled = false;
            txtAge.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            cbxDuty.Enabled = false;
            txtRePassword.Enabled = false;
            #endregion
        }

        private void EnableCtrls()
        {
            #region
            txtUserName.Enabled = true;
            txtPassword.Enabled = true;
            txtName.Enabled = true;
            txtAge.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            cbxDuty.Enabled = true;
            txtRePassword.Enabled = true;
            #endregion
        }
        //实现回车后焦点换到下一文本框中
        private void FrmUserInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            #endregion
        }
    
       //插入、更新时提取文本框、下拉列表框内容；
        public void SetPara()
        {
            #region
            userInfoClass.UserName = txtUserName.Text;
            userInfoClass.Password = txtPassword.Text;
            userInfoClass.Name = txtName.Text;
            userInfoClass.Age = txtAge.Text;
            if (radioButton2.Checked)
            {
                userInfoClass.Sex = "2";
            }
            else
            {
                userInfoClass.Sex = "1";
            }
            userInfoClass.Duty = cbxDuty.SelectedValue!=null?  cbxDuty.SelectedValue.ToString():"";
            #endregion
        }
     
    }
}
