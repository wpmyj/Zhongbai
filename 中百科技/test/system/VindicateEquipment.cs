using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.transport;

namespace DasherStation.system
{
    public partial class VindicateEquipment : common.BaseForm
    {
        public VindicateEquipment()
        {
            InitializeComponent();
        }

        EquipmentInfoLogic eLogic = new EquipmentInfoLogic();
        FormHelper formHelper = new FormHelper();

        string condition;

        private long ekId;

        public long EkId
        {
            get { return ekId; }
            set { ekId = value; }
        }

        private void VindicateEquipment_Load(object sender, EventArgs e)
        {
            condition = this.Text.Trim();

            switch (condition)
            {
                case "新建生产设备类别":
                    {
                        label1.Text = "设备类别";
                        dgvEInfo.DataSource = eLogic.SearchEquipmentKindAll();
                        break;
                    }

                case "新建生产设备名称":
                    {
                        label1.Text = "设备名称";
                        dgvEInfo.DataSource = eLogic.SearchEquipmentNameAll(EkId);
                        break;
                    }
                case "新建生产设备规格":
                    {
                        label1.Text = "设备规格";
                        dgvEInfo.DataSource = eLogic.SearchEquipmentModelAll();
                        break;
                    }
            }

            dgvEInfo.Columns["id"].Visible = false;
            dgvEInfo.Columns["inputDate"].Visible = false;
            dgvEInfo.Columns["inputMan"].Visible = false;
            dgvEInfo.Columns["备注"].Visible = false;
            txtValue.Focus ();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool state;

            if (formHelper.inputCheck(panel1))
            {
                #region 获取要插入信息的内容
                EquipmentClass eClass = new EquipmentClass();

                if (!txtValue.Text.Trim().Equals(""))
                {
                    eClass.Sort = txtValue.Text.Trim();
                    eClass.Name = txtValue.Text.Trim();
                    eClass.Model = txtValue.Text.Trim();
                }
                if (!txtRemark.Text.Trim().Equals(""))
                {
                    eClass.Remark = txtRemark.Text.Trim();
                }

                eClass.EkId = EkId;
                eClass.InputMan = this.userName;
                #endregion
             switch (condition)
                {
                    case "新建生产设备类别":
                        #region 增加生产设备类别
                        {
                            if (eLogic.SearchKind(txtValue.Text.Trim()))
                            {
                                MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtValue.Clear();
                                txtValue.Focus();
                                return;
                            }

                            state = eLogic.InsertKind(eClass);
                            dgvEInfo.DataSource = eLogic.SearchEquipmentKindAll();

                            break;
                        }
                        #endregion
                    case "新建生产设备名称":
                        #region 增加生产设备名称
                        {
                            // 检查要输入生产设备名称的字段是否已存在；
                            if (eLogic.SearchName(txtValue.Text.Trim(),EkId)) 
                            {
                                MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtValue.Clear();
                                txtValue.Focus();
                                return;
                            }

                            state = eLogic.InsertName(eClass);
                            dgvEInfo.DataSource = eLogic.SearchEquipmentNameAll(EkId);

                            break;
                        }
                        #endregion
                    case "新建生产设备规格":
                        #region  增加生产设备规格
                        {
                            // 检查要输入生产设备规格的字段是否已存在；
                            if (eLogic.SearchModel(txtValue.Text.Trim()))
                            {
                                MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtValue.Clear();
                                txtValue.Focus();
                                return;
                            }

                            state = eLogic.InsertModel(eClass);
                            dgvEInfo.DataSource = eLogic.SearchEquipmentModelAll();

                            break;
                        }
                        #endregion  
                    default:
                        state = true;
                        break;
                }
                
                dgvEInfo.Columns["id"].Visible = false;
                dgvEInfo.Columns["inputDate"].Visible = false;
                dgvEInfo.Columns["inputMan"].Visible = false;
                dgvEInfo.Columns["备注"].Visible = false;
                
                if (state)
                {
                    //MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtValue.Clear();
                    txtValue.Focus();
                }
                else
                {
                    MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int eId;

            DialogResult strDelete = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.YesNo);

            if (strDelete.ToString().Equals("No"))
            {
                return;
            }

            try
            {
                if (dgvEInfo.CurrentRow != null)
                {
                    eId = Convert.ToInt32(dgvEInfo.CurrentRow.Cells[0].Value.ToString());

                    switch (condition)
                    {
                        case "新建生产设备类别":
                            {
                                if (eLogic.DeleteKind(eId))
                                {
                                    //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvEInfo.DataSource = eLogic.SearchEquipmentKindAll();
                                }
                                else
                                {
                                    MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                break;
                            }
                        case "新建生产设备名称":
                            {
                                if (eLogic.DeleteName(eId))
                                {
                                    //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvEInfo.DataSource = eLogic.SearchEquipmentNameAll(EkId);
                                }
                                else
                                {
                                    MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                break;  
                            }
                        case "新建生产设备规格":
                            {  
                                 if (eLogic.DeleteModel(eId))
                                {
                                    //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvEInfo.DataSource = eLogic.SearchEquipmentModelAll();
                                }
                                else
                                {
                                    MessageBox.Show("删除记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                break;
                            }
                        default:
                            break;
                    }

                    dgvEInfo.Columns["id"].Visible = false;
                    dgvEInfo.Columns["inputDate"].Visible = false;
                    dgvEInfo.Columns["inputMan"].Visible = false;
                    dgvEInfo.Columns["备注"].Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("记录正在使用,删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {

            }
        }

        private void VindicateEquipment_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void VindicateEquipment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
