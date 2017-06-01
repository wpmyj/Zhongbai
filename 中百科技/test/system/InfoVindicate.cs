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
    public partial class InfoVindicate : common.BaseForm
    {
        public InfoVindicate()
        {
            InitializeComponent();           
        }

        VindicateLogic vLogic = new VindicateLogic();
        ProductLogic pLogic = new ProductLogic();
        MaterialLogic mLogic = new MaterialLogic();
        FormHelper formHelper = new FormHelper();

        string condition ;
        // 用来获取产品或材料种类的ID；
        private int kindId;
        public int KindId
        {
            get
            {
                return kindId;
            }
            set
            {
                kindId = value;
            }
        }


        #region  清空文本框内容;
        private void ClearAction()
        {
            txtValue.Clear();
            txtRemark.Clear();
        }
        #endregion

        private void InfoVindicate_Load(object sender, EventArgs e)
        {
            condition = this.Text.Trim();
            switch (condition)
            {
                case "新建产品种类":
                    {
                        label1.Text = "产品种类";
                        dgvInfo.DataSource = pLogic.InitialPKindComboBox();
                        break;
                    }
                case "新建产品名称":
                    {
                        label1.Text = "产品名称";
                        dgvInfo.DataSource = pLogic.InitialPNameComboBox(kindId);
                        break;
                    }
                case "新建产品规格":
                    {
                        label1.Text = "产品规格";
                        dgvInfo.DataSource = vLogic.PModelSearch();
                        break;
                    }

                case "新建材料种类":
                    {
                        label1.Text = "材料种类";
                        dgvInfo.DataSource = mLogic.InitialMKindComboBox();
                        break;
                    }
                case "新建材料名称":
                    {
                        label1.Text = "材料名称";
                        dgvInfo.DataSource = mLogic.InitialMNameComboBox(kindId);                        
                        break;
                    }
                case "新建材料规格":
                    {
                        label1.Text = "材料规格";
                        dgvInfo.DataSource = vLogic.MModelSearch();
                        break;
                    }   
            }
            dgvInfo.Columns["id"].Visible = false;

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
            ProductClass productClass = new ProductClass();
            MaterialClass materialClass = new MaterialClass();

            
            bool state;            
            condition = this.Text.Trim();

            if (formHelper.inputCheck(pnlMKind))
            {
                #region  获取下拉列表框的内容 分别放入产品和材料类实例中
                if (!string.IsNullOrEmpty(txtValue.Text.Trim()))
                {
                    productClass.Kind = txtValue.Text.Trim();
                    productClass.Name = txtValue.Text.Trim();
                    productClass.Model = txtValue.Text.Trim();
                    materialClass.Kind = txtValue.Text.Trim();
                    materialClass.Name = txtValue.Text.Trim();
                    materialClass.Model = txtValue.Text.Trim();
                }
                else
                {
                    productClass.Kind = "";
                    productClass.Name = "";
                    productClass.Model = "";
                    materialClass.Kind = "";
                    materialClass.Name = "";
                    materialClass.Model = "";
                }
                productClass.PkId = kindId;
                productClass.InputMan = this.userName;
                if (!string.IsNullOrEmpty(txtRemark.Text.Trim()))
                {
                    productClass.Remark = txtRemark.Text.Trim();
                    materialClass.Remark = txtRemark.Text.Trim();
                }
                else
                {
                    productClass.Remark = "";
                    materialClass.Remark = "";
                }
                
                materialClass.MkId = kindId;
                materialClass.InputMan = this.userName;
                
                #endregion

                switch (condition)
                {
                    case "新建产品种类":
                        #region 增加产品种类
                        {                     
                            // 检查要输入种类的字段是否已存在；
                            if (vLogic.PSearchName(txtValue.Text.Trim(),1))
                            {
                                MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtValue.Clear();
                                return;
                            }
                            //if (!Check.CheckQueryIsEmpty(txtValue.Text.Trim()))
                            //{
                            //    MessageBox.Show("产品种类中含有非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    txtValue.Clear();
                            //    return;
                            //}

                            state = vLogic.PKindInsert(productClass);
                            dgvInfo.DataSource = pLogic.InitialPKindComboBox();

                            break;
                        }
                        #endregion 
                    case "新建产品名称":
                        #region  增加产品名称
                        {
                            // 检查要输入名称的字段是否已存在；
                            if (vLogic.PSearchName(txtValue.Text.Trim(), 2))
                            {
                                MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtValue.Clear();
                                return;
                            }
                            //if (!Check.CheckQueryIsEmpty(txtValue.Text.Trim()))
                            //{
                            //    MessageBox.Show("产品名称中含有非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    txtValue.Clear();
                            //    return;
                            //}
                           
                            state = vLogic.PNameInsert(productClass);
                            dgvInfo.DataSource = pLogic.InitialPNameComboBox(kindId);

                            break;
                        }
                        #endregion
                    case "新建产品规格":
                        #region  增加产品规格
                        {
                            // 检查要输入规格的字段是否已存在；
                            if (vLogic.PSearchName(txtValue.Text.Trim(), 3))
                            {
                                MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtValue.Clear();
                                return;
                            }
                            //if (!Check.CheckQueryIsEmpty(txtValue.Text.Trim()))
                            //{
                            //    MessageBox.Show("产品规格中含有非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    txtValue.Clear();
                            //    return;
                            //}

                            state = vLogic.PModelInsert(productClass);
                            dgvInfo.DataSource = vLogic.PModelSearch();

                            break;
                        }
                        #endregion
                    case "新建材料种类":
                        #region  增加材料种类
                        {
                            // 检查要输入种类的字段是否已存在；
                            if (vLogic.PSearchName(txtValue.Text.Trim(),4))
                            {
                                MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtValue.Clear();
                                return;
                            }
                            //if (!Check.CheckQueryIsEmpty(txtValue.Text.Trim()))
                            //{
                            //    MessageBox.Show("材料种类种类中含有非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    txtValue.Clear();
                            //    return;
                            //}
                           
                            state = vLogic.MKindInsert(materialClass);
                            dgvInfo.DataSource = mLogic.InitialMKindComboBox();

                            break;
                        }
                        #endregion
                    case "新建材料名称":
                        #region  增加材料名称
                        {
                            // 检查要输入名称的字段是否已存在；
                            if (vLogic.PSearchName(txtValue.Text.Trim(),5))
                            {
                                MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtValue.Clear();
                                return;
                            }
                            //if (!Check.CheckQueryIsEmpty(txtValue.Text.Trim()))
                            //{
                            //    MessageBox.Show("材料名称中含有非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    txtValue.Clear();
                            //    return;
                            //}

                            state = vLogic.MNameInsert(materialClass);
                            dgvInfo.DataSource = mLogic.InitialMNameComboBox(kindId);

                            break;
                        }
                        #endregion
                    case "新建材料规格":
                        #region  增加材料规格
                        {
                            // 检查要输入规格的字段是否已存在；
                            if (vLogic.PSearchName(txtValue.Text.Trim(),6))
                            {
                                MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtValue.Clear();
                                return;
                            }
                            //if (!Check.CheckQueryIsEmpty(txtValue.Text.Trim()))
                            //{
                            //    MessageBox.Show("材料规格中含有非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    txtValue.Clear();
                            //    return;
                            //}

                            state = vLogic.MModleInsert(materialClass);
                            dgvInfo.DataSource = vLogic.MModelSearch();

                            break;
                        }
                        #endregion
                    default:
                        state = true;
                        break;
                }

                dgvInfo.Columns["id"].Visible = false;

                // 清空文本框内容；
                ClearAction();

                if (state)
                {
                    //MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
            }    
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int pId;
            if (dgvInfo.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                //}
                //else
                //{
                //    return;
                //}

                //if (strDelete.ToString().Equals("No"))
                //{
                //    return;
                //}
                {
                //    if (dgvInfo.CurrentRow != null)
                    if(dgvInfo.SelectedRows.Count>0)
                    {
                        pId = Convert.ToInt32(dgvInfo.SelectedCells[0].Value.ToString());
                        try
                        {
                            switch (condition)
                            {
                                case "新建产品种类":
                                    #region 删除产品种类
                                    {
                                        if (vLogic.PKindDelete(pId))
                                        {
                                            // MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            dgvInfo.DataSource = pLogic.InitialPKindComboBox();
                                        }
                                        else
                                        {
                                            MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        break;
                                    }
                                    #endregion
                                case "新建产品名称":
                                    #region 删除产品名称
                                    {
                                        if (vLogic.PNameDelete(pId))
                                        {
                                            //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            dgvInfo.DataSource = pLogic.InitialPNameComboBox(kindId);
                                        }
                                        else
                                        {
                                            MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        break;
                                    }
                                    #endregion
                                case "新建产品规格":
                                    #region 删除产品规格
                                    {
                                        if (vLogic.PModleDelete(pId))
                                        {
                                            //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            dgvInfo.DataSource = vLogic.PModelSearch();
                                        }
                                        else
                                        {
                                            MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        break;
                                    }
                                    #endregion
                                case "新建材料种类":
                                    #region 删除材料种类
                                    {
                                        if (vLogic.MKindDelete(pId))
                                        {
                                            //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            dgvInfo.DataSource = mLogic.InitialMKindComboBox();
                                        }
                                        else
                                        {
                                            MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        break;
                                    }
                                    #endregion
                                case "新建材料名称":
                                    #region 删除材料名称
                                    {
                                        if (vLogic.MNameDelete(pId))
                                        {
                                            //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            dgvInfo.DataSource = mLogic.InitialMNameComboBox(kindId);
                                        }
                                        else
                                        {
                                            MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        break;
                                    }
                                    #endregion
                                case "新建材料规格":
                                    #region 删除材料规格
                                    {
                                        if (vLogic.MModleDelete(pId))
                                        {
                                            //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            dgvInfo.DataSource = vLogic.MModelSearch();
                                        }
                                        else
                                        {
                                            MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        break;
                                    }
                                    #endregion
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("记录正在使用,删除失败!");
                        }
                        // 清空文本框内容；
                        dgvInfo.Columns["id"].Visible = false;
                        ClearAction();
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                     
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InfoVindicate_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCreat_Click(object sender, EventArgs e)
        {

        }

    }
}
