using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using DasherStation.transport;

namespace DasherStation.system
{
    public partial class FrmProducer : common.BaseForm
    {
        public FrmProducer()
        {
            InitializeComponent();
        }

        ProducerLogic producerLogic = new ProducerLogic();
        FormHelper formHelper = new FormHelper();
        ProducerClass producerClass = new ProducerClass();

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
                producerClass.Name = txtName.Text.Trim();
            }
            else
            {
                producerClass.Name = "";
            }
            if (!txtAddress.Text.Trim().Equals(""))
            {
                producerClass.Address = txtAddress.Text.Trim();
            }
            else
            {
                producerClass.Address = "";
            }
            if (!txtPhone.Text.Trim().Equals(""))
            {
                producerClass.Phone = txtPhone.Text.Trim();
            }
            else
            {
                producerClass.Phone = "";
            }
            if (!txtRemark.Text.Trim().Equals(""))
            {
                producerClass.Remark = txtRemark.Text.Trim();
            }
            else
            {
                producerClass.Remark = "";
            }
            producerClass.InputMan = this.userName;
        }
        #endregion

        #region ClearAction()清空文本框内容;
        private void ClearAction()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtRemark.Clear();
        }
        #endregion

        #region SetDataGridView()为DataGridView赋值
        private void SetDataGridView()
        {
            dgvProducer.DataSource = producerLogic.SearchProducerAll("", 0);
            dgvProducer.Columns["id"].Visible = false;
            dgvProducer.Columns["inputDate"].Visible = false;
            dgvProducer.Columns["inputMan"].Visible = false;
            dgvProducer.Columns["生产厂家"].Width = 120;
            dgvProducer.Columns["厂家地址"].Width = 220;
        }
        #endregion

        private void FrmProducer_Load(object sender, EventArgs e)
        {
            //初始化DataGridView;
            SetDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                SetPara();

                #region 检查要插入的字段是否已存在
                if (producerLogic.SearchProducerName(producerClass.Name))
                {
                    MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearAction();
                    txtName.Focus();
                    return;
                }
                #endregion

                // 执行插入操作；
                if (producerLogic.FrmProducerInsert(producerClass))
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

            
        }

        private void FrmProducer_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {                       
            // 检查生产厂家是否为空;
            if (txtCondition.Text.Trim().Equals(""))
            {
                SetDataGridView();
            }
            else
            {
                // 检查生产厂家是否含有非法字符
                if (!Check.CheckQueryIsEmpty(txtCondition.Text.Trim()))
                {
                    MessageBox.Show("生产厂家不能包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCondition.Text = "";
                    txtCondition.Focus();
                    return;
                }
                // 根据输入的查询条件来查询数据;
                dgvProducer.DataSource = producerLogic.SearchProducerAll(txtCondition.Text.Trim(),1);
                dgvProducer.Columns["id"].Visible = false;
                dgvProducer.Columns["inputDate"].Visible = false;
                dgvProducer.Columns["inputMan"].Visible = false;
                dgvProducer.Columns["生产厂家"].Width = 120;
                dgvProducer.Columns["厂家地址"].Width = 220;
            }
            txtCondition.Clear();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int producerId;

            //DialogResult strDelete = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.YesNo);

            //if (strDelete.ToString().Equals("No"))
            //{
            //    return;
            //}
            if (dgvProducer.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确定要删除吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        if (dgvProducer.SelectedRows.Count >0)
                        {
                            producerId = Convert.ToInt32(dgvProducer.CurrentRow.Cells[0].Value.ToString());

                            if (producerLogic.FrmProducerDelete(producerId))
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
                        MessageBox.Show("记录在使用，无法删除！");
                    }
                }
                else
                {
                    MessageBox.Show("请选择要删除的记录！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }


            

        }

        private void FrmProducer_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


    }
}
