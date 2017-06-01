using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.system;
using DasherStation.common;
using DasherStation.transport;

namespace DasherStation.equipment
{
    public partial class FrmEquipmentDetail : common.BaseForm
    {
        public FrmEquipmentDetail()
        {
            InitializeComponent();
        }

        EquipmentInfoLogic eLogic = new EquipmentInfoLogic();
        FormHelper formHelper = new FormHelper();
        EquipmentClass eClass = new EquipmentClass();

        #region getPara() 获取设备信息;
        private void getPara()
        {
            if (!string.IsNullOrEmpty(cbx_mark.Text.Trim()))
            {
                switch (cbx_mark.Text.Trim())
                {
                    case "拌合机一":
                        eClass.Mark = "s";
                        break;
                    case "拌合机二":
                        eClass.Mark = "a";
                        break;
                    case "热油炉":
                        eClass.Mark = "M";
                        break;
                    case "乳化沥青机" :
                        eClass.Mark = "r";
                        break;
                }
            }
            if (!string.IsNullOrEmpty(txtNo.Text.Trim()))
            {
                eClass.No = txtNo.Text.Trim();
            }
            else
            {
                eClass.No = "";
            }
            if (!string.IsNullOrEmpty(cbxKind.Text.Trim()))
            {
                eClass.EkId = Convert.ToInt64(this.cbxKind.SelectedValue.ToString());
            }
            else
            {
                eClass.EkId = 0;
            }
            if (!string.IsNullOrEmpty(cbxName.Text.Trim()))
            {
                eClass.EnId = Convert.ToInt64(this.cbxName.SelectedValue.ToString());
            }
            else
            {
                eClass.EnId = 0;
            }
            if (!string.IsNullOrEmpty(cbxModel.Text.Trim()))
            {
                eClass.EmId = Convert.ToInt64(this.cbxModel.SelectedValue.ToString());
            }
            else
            {
                eClass.EmId = 0;
            }
            if (!string.IsNullOrEmpty(txtCount.Text.Trim()))
            {
                eClass.Count = Convert.ToInt64(this.txtCount.Text.Trim());
            }
            else
            {
                eClass.Count = 0;
            }
            if (!string.IsNullOrEmpty(txtPosition.Text.Trim()))
            {
                eClass.InstallationPosition = this.txtPosition.Text.Trim();
            }
            else
            {
                eClass.InstallationPosition = "";
            }
            if (!string.IsNullOrEmpty(txtRemainsValue.Text.Trim()))
            {
                eClass.RemainsValue = decimal.Parse(this.txtRemainsValue.Text.Trim());
            }
            else
            {
                eClass.RemainsValue = 0;
            }
            if (!string.IsNullOrEmpty(cbxWorkMan.Text.Trim()))
            {
                eClass.WorkMan = this.cbxWorkMan.Text.Trim();
            }
            else
            {
                eClass.WorkMan = "";
            }
            if (!string.IsNullOrEmpty(txtProducer.Text.Trim()))
            {
                eClass.Producer = this.txtProducer.Text.Trim();
            }
            else
            {
                eClass.Producer = "";
            }
            if (!string.IsNullOrEmpty(cbxFAddress.Text.Trim()))
            {
                eClass.FactoryAddress = this.cbxFAddress.Text.Trim();
            }
            else
            {
                eClass.FactoryAddress = "";
            }
            if (!string.IsNullOrEmpty(cbxContactMan.Text.Trim()))
            {
                eClass.ContactMan = this.cbxContactMan.Text.Trim();
            }
            else
            {
                eClass.ContactMan = "";
            }
            if (!string.IsNullOrEmpty(txtDYear.Text.Trim()))
            {
                eClass.DepreciationYear = Convert.ToInt64(this.txtDYear.Text.Trim());
            }
            else
            {
                eClass.DepreciationYear = 0;
            }
            if (!string.IsNullOrEmpty(txtSumPower.Text.Trim()))
            {
                eClass.SumPower = decimal.Parse(this.txtSumPower.Text.Trim());
            }
            else
            {
                eClass.SumPower = 0;
            }
            if (!string.IsNullOrEmpty(txtRMark.Text.Trim()))
            {
                eClass.RegistrationMark = this.txtRMark.Text.Trim();
            }
            else
            {
                eClass.RegistrationMark = "";
            }
            if (!string.IsNullOrEmpty(txtAddMethod.Text.Trim()))
            {
                eClass.AddMethod = this.txtAddMethod.Text.Trim();
            }
            else
            {
                eClass.AddMethod = "";
            }
            if (!string.IsNullOrEmpty(txtFactoryNo.Text.Trim()))
            {
                eClass.FactoryNo = this.txtFactoryNo.Text.Trim();
            }
            else
            {
                eClass.FactoryNo = "";
            }
            if (!string.IsNullOrEmpty(txtCMethod.Text.Trim()))
            {
                eClass.ContactMethod = this.txtCMethod.Text.Trim();
            }
            else
            {
                eClass.ContactMethod = "";
            }
            if (!string.IsNullOrEmpty(cbxDocument.Text.Trim()))
            {
                eClass.DId2 = Convert.ToInt64(this.cbxDocument.Text.Trim());
            }
            else
            {
                eClass.DId2 = 0;
            }
            if (!string.IsNullOrEmpty(cbxPostCode.Text.Trim()))
            {
                eClass.PostCode = this.cbxPostCode.Text.Trim();
            }
            else
            {
                eClass.PostCode = "";
            }
            if (!string.IsNullOrEmpty(txtPValue.Text.Trim()))
            {
                eClass.PrimaryValue = decimal.Parse(this.txtPValue.Text.Trim());
            }
            else
            {
                eClass.PrimaryValue = 0;
            }
            if (!string.IsNullOrEmpty(cbxDId.Text.Trim()))
            {
                eClass.DId = Convert.ToInt64(this.cbxDId.SelectedValue.ToString());
            }
            else
            {
                eClass.DId = 0;
            }

            eClass.BeginUseTime = dtpBegin.Value;
            eClass.ProduceDate = dtpProduce.Value;
            eClass.InputMan = this.userName;
        }
        #endregion
        
        #region SetKind()设置设备类别
        private void SetKind()
        {
            cbxKind.DataSource = eLogic.SearchEquipmentKindAll();
            cbxKind.DisplayMember = "设备类别";
            cbxKind.ValueMember = "id";
            cbxKind.Text = "";
            cbxKind.SelectedIndex = -1;

        }
        #endregion

        #region cobBoBoxLinkage()选择类别后，设备名称联动
        /*
      * 方法名称： cobBoBoxLinkage()
      * 方法功能描述：选择类别后，设备名称联动；
      *
      * 创建人：冯雪
      * 创建时间：2009-03-21
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void cobBoBoxLinkage()
        {
            long ekId;

            if (cbxKind.SelectedValue == null) 
            {
                ekId = 0;
            }
            else
            {
                ekId = Convert.ToInt64(cbxKind.SelectedValue.ToString());
            }
            if (eLogic.InitialEName(ekId).Rows.Count != 0)
            {
                cbxName.DataSource = eLogic.InitialEName(ekId);
                cbxName.DisplayMember = "设备名称";
                cbxName.ValueMember = "id";
                cbxName.Text = "";
                cbxName.SelectedIndex = -1;
            }
            else
            {
                cbxName.DataSource = eLogic.InitialEName(ekId);
            }
            cbxModel.Text = "";
            cbxModel.SelectedIndex = -1;
        }
        #endregion

        #region SetModel() 设置设备规格
        private void SetModel()
        {
            cbxModel.DataSource = eLogic.SearchEquipmentModelAll();
            cbxModel.DisplayMember = "设备规格";
            cbxModel.ValueMember = "id";
            cbxModel.Text = "";
            cbxModel.SelectedIndex = -1;
        }
        #endregion

        #region ClearAction() 清空文本、下拉列表框；
        private void ClearAction()
        {
            txtNo.Clear();
            txtCount.Clear();
            txtPosition.Clear();
            txtRemainsValue.Clear();
            txtRMark.Clear();
            txtSumPower.Clear();
            txtDYear.Clear();
            txtAddMethod.Clear();
            txtPValue.Clear();            
            txtFactoryNo.Clear();
            txtProducer.Clear();
            txtCMethod.Clear();

            cbxContactMan.Text = "";
            cbxContactMan.SelectedIndex = -1;
            
            cbxName.Text = "";
            cbxName.SelectedIndex = -1;
            
            cbxDId.Text = "";
            cbxDId.SelectedIndex = -1;
            
            cbxPostCode.Text = "";
            cbxPostCode.SelectedIndex = -1;
            
            cbxModel.Text = "";
            cbxModel.SelectedIndex = -1;
            
            cbxFAddress.Text = "";
            cbxFAddress.SelectedIndex = -1;
            
            cbxDocument.Text = "";
            cbxDocument.SelectedIndex = -1;
            
            cbxWorkMan.Text = "";
            cbxWorkMan.SelectedIndex = -1;

            cbxKind.Text = "";
            cbxKind.SelectedIndex = -1;
        }
        #endregion

        #region SetDataGridView() 为dgvEquipment赋值
        private void SetDataGridView(string no)
        {
            dgvEquipment.DataSource = eLogic.SearchEquipmentAll(no);
            dgvEquipment.Columns["id"].Visible = false;
            dgvEquipment.Columns["inputDate"].Visible = false;
            dgvEquipment.Columns["inputMan"].Visible = false;
            dgvEquipment.Columns["备注"].Visible = false;
            dgvEquipment.Columns["文档编号"].Visible = false;

        }
        #endregion

        #region setDepartment() 设置部门名称;
        private void setDepartment()
        {
            cbxDId.DataSource = eLogic.SearchDepartment();
            cbxDId.DisplayMember = "name";
            cbxDId.ValueMember = "id";
            cbxDId.Text = "";
            cbxDId.SelectedIndex = -1;
        }
        #endregion

        #region setDocument() 设置文档编号;
        private void setDocument()
        {
            cbxDocument.DataSource = eLogic.SearchDocument();
            cbxDocument.DisplayMember = "no";
            cbxDocument.ValueMember = "id";
            cbxDocument.Text = "";
            cbxDocument.SelectedIndex = -1;
        }
        #endregion

        #region setComboBox() 设置经办人、联系人、邮编
        private void setComboBox()
        {
            cbxWorkMan.DataSource = eLogic.InitComboBox(2);
            cbxWorkMan.DisplayMember = "经办人";
            cbxWorkMan.Text = "";
            cbxWorkMan.SelectedIndex = -1;

            cbxContactMan.DataSource = eLogic.InitComboBox(1);
            cbxContactMan.DisplayMember = "联系人";
            cbxContactMan.Text = "";
            cbxContactMan.SelectedIndex = -1;

            cbxPostCode.DataSource = eLogic.InitComboBox(3);
            cbxPostCode.DisplayMember = "邮编";
            cbxPostCode.Text = "";
            cbxPostCode.SelectedIndex = -1;

            cbxNO.DataSource = eLogic.SearchAll_NO();
            cbxNO.DisplayMember = "no";
            cbxNO.Text = "";
            cbxNO.SelectedIndex = -1;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                getPara();

                #region  检查要插入的字段是否已存在；
                if (eLogic.SearchNO(txtNo.Text.Trim()))
                {
                    MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearAction();
                    txtNo.Focus();
                    return;
                }
                #endregion
                //try
                //{
                // 插入设备信息；
                    if (eLogic.FrmEquipmentInsert(eClass))
                    {
                        ClearAction();
                        //MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setComboBox();
                        SetDataGridView("");
                    }
                    else
                    {
                        MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                //}
                //catch(Exception)
                //{
                //    MessageBox.Show("插入信息失败，请标明文档编号！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //}                
            }
        }

        private void btnModel_Click(object sender, EventArgs e)
        {
            //新建生产设备规格后刷新设备规格;
            VindicateEquipment frmVindicate = new VindicateEquipment();
            frmVindicate.Text = "新建生产设备规格";
            if (frmVindicate.ShowDialog(this) == DialogResult.OK)
            {
                SetModel();
            }
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            //新建生产设备名称后刷新设备名称；
            

            if (!Check.CheckEmpty(cbxKind.Text.Trim()))
            {
                MessageBox.Show("设备类别不能为空,请选择设备类别后在输入设备名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxKind.Focus();
                return;
            }
            else
            {
                VindicateEquipment frmVindicate = new VindicateEquipment();
                frmVindicate.Text = "新建生产设备名称";

                frmVindicate.EkId  = Convert.ToInt64(cbxKind.SelectedValue.ToString());
                
                if (frmVindicate.ShowDialog(this) == DialogResult.OK)
                {
                    cobBoBoxLinkage();
                }
            }
        }

        private void btnKind_Click(object sender, EventArgs e)
        {
            //新建生产设备类别后刷新设备类别；
            VindicateEquipment frmVindicate = new VindicateEquipment();
            frmVindicate.Text = "新建生产设备类别";
            if (frmVindicate.ShowDialog(this) == DialogResult.OK)
            {
                SetKind();
            }
        }

        private void FrmEquipmentDetail_Load(object sender, EventArgs e)
        {
            txtNo.Focus();
            SetKind();
            SetModel();
            setDepartment();
            setDocument();
            setComboBox();
            SetDataGridView("");
        }

        private void cbxKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cobBoBoxLinkage();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            long eId;
            DialogResult strDelete = MessageBox.Show("确定要删除选定记录吗?", "提示", MessageBoxButtons.YesNo);
            
            if (strDelete.ToString().Equals("No"))
            {
                return;
            }

            if (dgvEquipment.CurrentRow != null) 
            {
                eId = Convert.ToInt32(dgvEquipment.CurrentRow.Cells["id"].Value.ToString());
                if (eLogic.FrmEquipmentDelete(eId))
                {
                    //MessageBox.Show("删除记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAction();
                    SetDataGridView("");
                }
                else
                {
                    MessageBox.Show("删除记录失败，请从新选择记录操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox2))
            {
                SetDataGridView(cbxNO.Text.Trim());
                cbxNO.Text = "";
                cbxNO.SelectedIndex = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvEquipment.CurrentRow != null)
            {
                FrmEquipmentInfo frmequipment = new FrmEquipmentInfo();
                long eiId = Convert.ToInt64(dgvEquipment.CurrentRow.Cells["id"].Value.ToString());
                if (eLogic.ExistLiquidMatter(eiId))
                {
                    // 为修改液态罐信息；
                    frmequipment.Text = "更新沥青罐参数";
                }
                else
                {
                    // 为新建液态罐信息；
                    frmequipment.Text = "新建沥青罐参数";
                }

                frmequipment.Id = eiId;
                frmequipment.No = dgvEquipment.CurrentRow.Cells["设备编号"].Value.ToString();
                frmequipment.EName = dgvEquipment.CurrentRow.Cells["设备名称"].Value.ToString() + dgvEquipment.CurrentRow.Cells["设备规格"].Value.ToString();
                frmequipment.ShowDialog();
            }
            else
            {
                MessageBox.Show("增加液态罐信息失败，请从新选择记录操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvEquipment.SelectedRows.Count == 0)
            {
                DasherStation.HumanResource.CommUI.AlertError("请选择一条记录!");
                return;
            }
            FrmEquipmentUpdate frmEdit = new FrmEquipmentUpdate();
            frmEdit.id= long.Parse(this.dgvEquipment.SelectedRows[0].Cells["id"].Value.ToString());
            var result = frmEdit.ShowDialog();
            if (result == DialogResult.OK)
            {
                SetDataGridView("");
            }
        }

        private void FrmEquipmentDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
