using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.system
{
    public partial class FrmPersonnelInfo : common.BaseForm
    {
        public FrmPersonnelInfo()
        {
            InitializeComponent();
        }

        PersonnelClass personnelClass = new PersonnelClass();
        PersonnelLogic pLogic = new PersonnelLogic();
        OptionLogic oLogic = new OptionLogic();

        #region SetPara() 插入时提取文本框、下拉列表框内容
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
            personnelClass.Name = txtName.Text.Trim();
            if (!cbxPosition.Text.Trim().Equals(""))
            {
                personnelClass.PId = Convert.ToInt32(cbxPosition.SelectedValue.ToString());
            }
            else
            {
                personnelClass.PId = 0;
            }
            if (!cbxTeam.Text.Trim().Equals(""))
            {
                personnelClass.PtId = Convert.ToInt32(cbxTeam.SelectedValue.ToString());
            }
            else
            {
                personnelClass.PtId = 0;
            }
            if (!txtAge.Text.Trim().Equals(""))
            {
                personnelClass.Age = Convert.ToInt32(txtAge.Text.Trim());
            }
            else
            {
                personnelClass.Age = 0;
            }
            if (rbtnMan.Checked)
            {
                personnelClass.Sex = 0;
            }
            else
            {
                 personnelClass.Sex = 1;
            }


            if (rbtnEmployee.Checked)
            {
                personnelClass.Kind = 0;
            }
            else
            {
                personnelClass.Kind = 1;
            }

            if (txtRemark.Text.Trim().Equals(""))
            {
                personnelClass.Remark = txtRemark.Text.Trim();
            }
            else
            {
                personnelClass.Remark = "";
            }

            personnelClass.InputMan = this.userName;


        }
        #endregion

        # region ClearAction() 清空文本框、下拉列表框内容
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
            txtAge.Clear();
            txtRemark.Clear();
            rbtnMan.Checked = true;
            rbtnEmployee.Checked = true;

            cbxPosition.Text = "";
            cbxTeam.Text = "";
        }
        #endregion

        #region SetDataGridView()为DataGridView赋值
        /*
      * 方法名称： SetDataGrid()
      * 方法功能描述：为DataGridView赋值；
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void SetDataGridView()
        {
            dgvProductInfo.DataSource = pLogic.SearchPersonnelAll("", 0);
            dgvProductInfo.Columns["id"].Visible = false;
            dgvProductInfo.Columns["录入日期"].Visible = false;
            dgvProductInfo.Columns["录入人"].Visible = false;
            dgvProductInfo.Columns["性别"].Width = 60;
        }
        #endregion

        #region SetPosition()设置职位信息；
        /*
         * 方法名称： SetPosition()
         * 方法功能描述：设置职位信息；
         *
         * 创建人：冯雪
         * 创建时间：2009-02-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void SetPosition()
        {
            cbxPosition.DataSource = oLogic.SearchPosition();
            cbxPosition.DisplayMember = "职位名称";
            cbxPosition.ValueMember = "id";
            cbxPosition.SelectedIndex = -1;
        }
        #endregion

        #region SetTeam()设置生产班组；
        /*
      * 方法名称： SetTeam()
      * 方法功能描述：设置生产班组；
      *
      * 创建人：冯雪
      * 创建时间：2009-02-17
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */  
        private void SetTeam()
        {
            cbxTeam.DataSource = oLogic.SearchTeam();
            cbxTeam.DisplayMember = "生产班组";
            cbxTeam.ValueMember = "id";
        }
        #endregion

        private void FrmPersonnelInfo_KeyPress(object sender, KeyPressEventArgs e)
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
                SetPara(); 
              
                #region  对输入数据进行校验;
                // 检查姓名文本框是否为空;
                if (!Check.CheckEmpty(txtName.Text.Trim()))
                {
                    MessageBox.Show("姓名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return;
                }
                // 检查姓名文本框是否含有非法字符
                if (!Check.CheckQueryIsEmpty(txtName.Text.Trim()))
                {
                    MessageBox.Show("姓名不能包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Text = "";
                    txtName.Focus();
                    return;
                }
                // 检查职位文本框是否为空;
                if (!Check.CheckEmpty(cbxPosition.Text.Trim())) 
                {
                    MessageBox.Show("职位不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return;
                }
                // 检查班组文本框是否为空;
                if (!Check.CheckEmpty(cbxTeam.Text.Trim())) 
                {
                    MessageBox.Show("班组不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                    return;
                }
                // 检查职位文本框是否含有非法字符
                if (!Check.CheckQueryIsEmpty(cbxPosition.Text.Trim()))
                {
                    MessageBox.Show("职位不能包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxPosition.Text = "";
                    cbxPosition.Focus();
                    return;
                }
                // 检查年龄文本框是否含有非法字符
                if (!Check.CheckNumber(txtAge.Text.Trim()))
                {
                    MessageBox.Show("年龄不能包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAge.Text = "";
                    txtAge.Focus();
                    return;
                }
                // 检查备注文本框是否含有非法字符
                if (!Check.CheckQuery(txtRemark.Text.Trim()))
                {
                    MessageBox.Show("备注不能包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRemark.Text = "";
                    txtRemark.Focus();
                    return;
                }


                #endregion

                #region  检查要插入的字段是否已存在；
                if (pLogic.SearchPersonnelName(personnelClass.Name))
                {
                    MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearAction();
                    txtName.Focus();
                    return;
                }
                #endregion

                // 插入人员信息记录；
                if (pLogic.FrmPersonnelInsert(personnelClass))
                {
                    ClearAction();
                    MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetDataGridView();
                }
                else
                {
                    MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int personnelId;

            DialogResult strDelete = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.YesNo);

            if (strDelete.ToString().Equals("No"))
            {
                return;
            }

            if (dgvProductInfo.CurrentRow != null)
            {
                personnelId = Convert.ToInt32(dgvProductInfo.CurrentRow.Cells[0].Value.ToString());

                if (pLogic.FrmPersonnelDelete(personnelId) )
                {
                    MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SetDataGridView();
                }
                else
                {
                    MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void FrmPersonnelInfo_Load(object sender, EventArgs e)
        {
            //默认性别为男，职工类别为正式；
            rbtnMan.Checked = true;
            rbtnEmployee.Checked = true;
            txtName.Focus();

            //初始化职位、生产班组；
            SetPosition();
            SetTeam();

            SetDataGridView();
            
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int verifyBit;
            string Condition;

            //检查用条件文本框是否含有非法字符
            if (!Check.CheckQuery(txtCondition.Text.Trim()))
            {
                MessageBox.Show("查询条件包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCondition.Focus();
                return;
            }
            else
            {
                //取出查询条件;
                Condition = cbxCondition.Text;

                switch (Condition)   
                {
                    case "姓名":
                        verifyBit = 1;
                        break;
                    case "性别":
                        verifyBit = 2;
                        break;
                    case "职工类别":
                        verifyBit = 3;
                        break;
                    default:
                        verifyBit = 0;
                        break;
                }

                //执行查询;
                dgvProductInfo.DataSource = pLogic.SearchPersonnelAll(txtCondition.Text.Trim(), verifyBit);
                dgvProductInfo.Columns["id"].Visible = false;
                dgvProductInfo.Columns["录入日期"].Visible = false;
                dgvProductInfo.Columns["录入人"].Visible = false;
                dgvProductInfo.Columns["性别"].Width = 60;

                txtCondition.Clear();
            }
        }

        private void dgvProductInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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

        private void btnTeam_Click(object sender, EventArgs e)
        {
            FrmOption frmOption = new FrmOption();
            frmOption.OptionName = "生产班组";
            if (frmOption.ShowDialog() == DialogResult.OK)
            {
                SetTeam();
            }
        }

        private void FrmPersonnelInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定关闭窗口吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

    }
}
