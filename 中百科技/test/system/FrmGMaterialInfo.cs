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
    public partial class FrmGMaterialInfo : common.BaseForm
    {
        public FrmGMaterialInfo()
        {
            InitializeComponent();
        }

        MaterialLogic mLogic = new MaterialLogic();
        ProducerLogic producerLogic = new ProducerLogic();
        GMaterialClass GMclass = new GMaterialClass();
        GMaterialLogin gmLogic = new GMaterialLogin();
        FormHelper formHelper = new FormHelper();

        // 供应商ID
        private int providerId;
        public int ProviderId
        {
            get
            {
                return providerId;
            }
            set
            {
                providerId = value;
            }
        }


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
            int mnId = 0, mmId = 0;
            if (!cbxMName.Text.Trim().Equals(""))
            {
                mnId = Convert.ToInt32(cbxMName.SelectedValue.ToString());

                if (!cbxMModel.Text.Trim().Equals(""))
                {
                    mmId = Convert.ToInt32(cbxMModel.SelectedValue.ToString());
                    if (!mLogic.MaterialSearch(mnId, mmId).Equals(null))
                    {
                        GMclass.MaterialId = mLogic.MaterialSearch(mnId, mmId);
                    }
                    else
                    {
                        GMclass.MaterialId = 0;
                    }
                }
            }
            GMclass.ProviderId = providerId;
            if (!cbxPname.Text.Trim().Equals(""))
            {
                GMclass.ProducerId = Convert.ToInt32(cbxPname.SelectedValue.ToString());
            }
            else
            {
                GMclass.ProducerId = 0;
            }
            if (!txtDistance.Text.Trim().Equals(""))
            {
                GMclass.Distance = Convert.ToDouble(txtDistance.Text.Trim());
            }
            else
            {
                GMclass.Distance = 0;
            }
            if (!txtPCapability.Text.Trim().Equals(""))
            {
                GMclass.ProvideCapability = txtPCapability.Text.Trim();
            }
            else
            {
                GMclass.ProvideCapability = "";
            }
            if (!txtRemark.Text.Trim().Equals(""))
            {
                GMclass.Remark = txtRemark.Text.Trim();
            }
            else
            {
                GMclass.Remark = "";
            }
            GMclass.InputMan = this.userName;

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
            cbxMKind.Text = "";
            cbxMKind.SelectedIndex = -1;
            cbxMName.Text = "";
            cbxMName.SelectedIndex = -1;
            cbxMModel.Text = "";
            cbxMModel.SelectedIndex = -1;
            cbxPname.Text = "";
            cbxPname.SelectedIndex = -1;
            txtDistance.Clear();
            txtPCapability.Clear();
            txtRemark.Clear();
        }
        #endregion

        #region SetDataGridView()为DataGridView赋值
        /*
      * 方法名称： SetDataGridView()
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
            dgvGMaterial.DataSource = gmLogic.FrmGMaterialSearch(ProviderId,"",0);
            dgvGMaterial.Columns["id"].Visible = false;
            dgvGMaterial.Columns["inputDate"].Visible = false;
            dgvGMaterial.Columns["inputMan"].Visible = false;
        }

        #endregion

        #region SetMKind()设置材料种类
        /*
      * 方法名称： SetMKind()
      * 方法功能描述：为材料种类赋值；
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void SetMKind()
        {
            cbxMKind.DataSource = mLogic.InitialMKindComboBox();
            cbxMKind.DisplayMember = "材料种类";
            cbxMKind.ValueMember = "id";
            cbxMKind.Text = "";
            cbxMKind.SelectedIndex = -1;
        }
        #endregion

        #region cobBoBoxLinkage()选择种类后，材料名称联动
        /*
      * 方法名称： cobBoBoxLinkage()
      * 方法功能描述：选择种类后，材料名称联动；
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void cobBoBoxLinkage()
        {
            int mkId;

            if (cbxMKind.SelectedValue == null)
            {
                mkId = 0;
            }
            else
            {
                mkId = Convert.ToInt32(cbxMKind.SelectedValue.ToString());
            }
            if (mLogic.InitialMNameComboBox(mkId).Rows.Count != 0)
            {
                cbxMName.DataSource = mLogic.InitialMNameComboBox(mkId);
                cbxMName.DisplayMember = "材料名称";
                cbxMName.ValueMember = "id";
                cbxMName.Text = "";
                cbxMName.SelectedIndex = -1;
            }
            else
            {
                cbxMName.DataSource = mLogic.InitialMNameComboBox(mkId);
            }
            cbxMModel.Text = "";
            cbxMModel.SelectedIndex = -1;
        }
        #endregion

        #region cobBoBoxLinkage()选择名称后，材料型号联动
        /*
      * 方法名称： setCbxMmodel()
      * 方法功能描述：选择名称后，材料型号联动；
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        //选择名称后，材料型号联动；
        private void setCbxMmodel()
        {
            int mnId;
            if (cbxMName.SelectedValue == null)
            {
                mnId = 0;
            }
            else
            {
                mnId = Convert.ToInt32(cbxMName.SelectedValue.ToString());
            }
            if (mLogic.InitialMModelComboBox(mnId).Rows.Count != 0)
            {
                cbxMModel.DataSource = mLogic.InitialMModelComboBox(mnId);
                cbxMModel.DisplayMember = "材料规格";
                cbxMModel.ValueMember = "id";
                cbxMModel.Text = "";
                cbxMModel.SelectedIndex = -1;
            }
            else
            {
                cbxMModel.DataSource = mLogic.InitialMModelComboBox(mnId);
            }
        }
        #endregion

        #region setCbxMmodel()设置生产厂家
        /*
      * 方法名称： setCbxMmodel() 
      * 方法功能描述：设置生产厂家；
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void SetProducer()
        {
            cbxPname.DataSource = producerLogic.SearchProducerAll("", 0);
            cbxPname.DisplayMember = "生产厂家";
            cbxPname.ValueMember = "id";
            cbxPname.Text = "";
            cbxPname.SelectedIndex = -1;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                SetPara();

                #region 检查要插入的字段是否已存在
                if (gmLogic.FrmSearchGMP(GMclass.MaterialId, GMclass.ProviderId, GMclass.ProducerId))
                {
                    MessageBox.Show("该记录已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearAction();
                    cbxMKind.Focus();
                    return;
                }
                #endregion

                // 插入供应材料信息；
                if (gmLogic.FrmGMaterialInsert(GMclass))
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

        private void FrmGMaterialInfo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FrmGMaterialInfo_Load(object sender, EventArgs e)
        {
            #region 初始化材料种类、名称、规格型号 生产厂家；

            SetMKind();
            SetProducer();

            #endregion

            //初始化ataGridView;
            SetDataGridView();
        }

        private void cbxMKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cobBoBoxLinkage();
        }

        private void cbxMName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setCbxMmodel();
        }

        private void btnProvider_Click(object sender, EventArgs e)
        {
            FrmProducer frmProducer = new FrmProducer();
            if (frmProducer.ShowDialog(this) == DialogResult.OK)
            {
                SetProducer();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int pMaterialId;

             //DialogResult strDelete = MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.YesNo);

            //if (strDelete.ToString().Equals("No"))
            //{
            //    return;
            //}
            if (dgvGMaterial.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确定要删除吗？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Information)==DialogResult.OK)
                    try
                    {
                        if (dgvGMaterial.SelectedRows.Count > 0)
                        {
                            pMaterialId = Convert.ToInt32(dgvGMaterial.SelectedCells[0].Value.ToString());

                            if (pMaterialId.Equals(null))
                            {
                                MessageBox.Show("请选择一条记录，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            if (gmLogic.FrmGMaterialDelete(pMaterialId))
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string condition;
            int verifyBit;

            //检查用条件文本框是否含有非法字符
            if (!Check.CheckQuery(txtCondition.Text.Trim()))
            {
                MessageBox.Show("查询条件包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCondition.Focus();
                return;
            }
            else
            {
                condition = cbxCondition.Text.Trim();

                switch (condition)
                {
                    case "材料种类":
                        verifyBit = 1;
                        break;
                    case "材料名称":
                        verifyBit = 2;
                        break;
                    case "材料规格":
                        verifyBit = 3;
                        break;
                    default:
                        verifyBit = 0;
                        break;

                }
                dgvGMaterial.DataSource = gmLogic.FrmGMaterialSearch(ProviderId, txtCondition.Text.Trim(), verifyBit);
                dgvGMaterial.Columns["id"].Visible = false;
                dgvGMaterial.Columns["inputDate"].Visible = false;
                dgvGMaterial.Columns["inputMan"].Visible = false;
            }

        }

        private void FrmGMaterialInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


    }
}
