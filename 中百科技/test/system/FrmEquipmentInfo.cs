/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：EquipmentInfo
     * 文件功能描述：设备信息窗体
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
    public partial class FrmEquipmentInfo : common.BaseForm
    {
        public FrmEquipmentInfo()
        {
            InitializeComponent();
        }
        EquipmentClass eclass = new EquipmentClass();
        EquipmentInfoLogic eLogic = new EquipmentInfoLogic();
        MaterialLogic mLogic = new MaterialLogic();
        ProductLogic pLogic = new ProductLogic();
        FormHelper formHelper = new FormHelper();
        DataTable datatable, dt;

        DasherStation.transport.TransportLogic transportLogic = new DasherStation.transport.TransportLogic();

        // 设备ID；
        private long eId;
        public long EId
        {
            get { return eId; }
            set { eId = value; }
        }

        // 设备编号;
        private string no;
        public string No
        {
            get { return no; }
            set { no = value; }
        }
        // 设备名称;
        private string eName;
        public string EName
        {
            get { return eName; }
            set { eName = value; }
        }
     

        #region SetPara() 取只文本、下拉列表框内容
        private void SetPara()
        {
            int mnId,mmId,pnId,pmId;
            
            eclass.No = No;
            eclass.Id = Id;
            eclass.InputMan = this.userName;

            if (!string.IsNullOrEmpty(txtHeight.Text.Trim()))
            {
                eclass.Height = decimal.Parse(txtHeight.Text.Trim());
            }
            else
            {
                eclass.Height = null;
            }
            if (!string.IsNullOrEmpty(txtDiameter.Text.Trim()))
            {
                eclass.Diameter = decimal.Parse(txtDiameter.Text.Trim());
            }
            else
            {
                eclass.Diameter = null;
            }
            if (rbtnMaterial.Checked)
            #region 查出材料ID；
            {
                if (!string.IsNullOrEmpty(cbxName.Text.Trim()))
                {
                    mnId = Convert.ToInt32(this.cbxName.SelectedValue.ToString());
                    if (!string.IsNullOrEmpty(cbxModel.Text.Trim()))
                    {
                        mmId = Convert.ToInt32(this.cbxModel.SelectedValue.ToString());
                    }
                    else
                    {
                        mmId = 0;
                    }
                }
                else
                {
                    mnId = 0;
                    mmId = 0;
                }
                if ((mnId != 0) && (mmId != 0))
                {
                    eclass.MId = mLogic.MaterialSearch(mnId, mmId);
                }
                else
                {
                    eclass.MId = null;
                }
            }
            #endregion

            if (rbtnProduct.Checked)
            #region 查出产品ID；
            {
                
                if (!string.IsNullOrEmpty(cbxName.Text.Trim()))
                {
                    pnId = Convert.ToInt32(this.cbxName.SelectedValue.ToString());
                    if (!string.IsNullOrEmpty(cbxModel.Text.Trim()))
                    {
                        pmId = Convert.ToInt32(this.cbxModel.SelectedValue.ToString());
                    }
                    else
                    {
                        pmId = 0;
                    }
                }
                else
                {
                    pnId = 0;
                    pmId = 0;
                }
                if ((pnId != 0) && (pmId != 0))
                {
                    eclass.PId = pLogic.PSearchID(pnId, pmId); 
                }
                else
                {
                    eclass.PId = null;
                }
            }
            #endregion

            if (!string.IsNullOrEmpty(txtHeight.Text.Trim()))
            {
                eclass.Height = decimal.Parse(txtHeight.Text.Trim());
            }
            else
            {
                eclass.Height = 0;
            }

            if (!string.IsNullOrEmpty(txtDiameter.Text.Trim()))
            {
                eclass.Diameter = decimal.Parse(txtDiameter.Text.Trim());
            }
            else
            {
                eclass.Diameter = 0;
            }
            if (!string.IsNullOrEmpty(cbxType.Text.Trim()))
            {
                eclass.PotKind = cbxType.Text.Trim();
            }
            else
            {
                eclass.PotKind = " ";
            }
            if (!string.IsNullOrEmpty(txtRemark.Text.Trim()))
            {
                eclass.Remark = txtRemark.Text.Trim();
            }
            else
            {
                eclass.Remark = " ";
            }

            if (!string.IsNullOrEmpty(cbx_yno.Text.Trim()))
            {
                eclass.LpnId = Convert.ToInt64(this.cbx_yno.SelectedValue.ToString());
            }
            else
            {
                eclass.LpnId = 0;
            }
        }
        #endregion

        #region 为材料种类赋值
        private void setMKind()
        {
            cbxKind.DataSource = mLogic.InitialMKindComboBox();
            cbxKind.DisplayMember = "材料种类";
            cbxKind.ValueMember = "id";
        }
        #endregion

        #region MLinkage() 选择材料种类后,材料名称联动;
        /*
         * 方法名称： MLinkage()
         * 方法功能描述：选择材料名称后，规格联动；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-19
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void MLinkage()
        {
            int mkId;

            if (cbxKind.Text.Trim().Equals("")) 
            {
                mkId = 0;
            }
            else
            {
                mkId = Convert.ToInt32(cbxKind.SelectedValue.ToString());
            }

            cbxName.DataSource = mLogic.InitialMNameComboBox(mkId);

            if (mLogic.InitialMNameComboBox(mkId).Rows.Count != 0)
            {
                cbxName.DisplayMember = "材料名称";
                cbxName.ValueMember = "id";
                cbxName.Text = "";
                cbxName.SelectedIndex = -1;
            }

            cbxModel.Text = "";
            cbxModel.SelectedIndex = -1;
        }
        #endregion

        #region setMmodel()选择材料名称后，规格联动
        /*
         * 方法名称： setMmodel()
         * 方法功能描述：选择材料名称后，规格联动；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-20
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setMmodel()
        {
            int mnId;
            if (cbxName.SelectedValue == null)
            {
                mnId = 0;
            }
            else
            {
                mnId = Convert.ToInt32(cbxName.SelectedValue.ToString());
            }

            cbxModel.DataSource = mLogic.InitialMModelComboBox(mnId);

            if (mLogic.InitialMModelComboBox(mnId).Rows.Count != 0)
            {
                cbxModel.DisplayMember = "材料规格";
                cbxModel.ValueMember = "id";
                cbxModel.Text = "";
                cbxModel.SelectedIndex = -1;
            }
        }
        #endregion

        #region 为产品种类赋值
        private void setPKind()
        {
            cbxKind.DataSource = pLogic.InitialPKindComboBox();
            cbxKind.DisplayMember = "产品种类";
            cbxKind.ValueMember = "id";
        }
        #endregion

        #region PLinkage() 选择产品种类后,产品名称联动;
        /*
         * 方法名称： PLinkage()
         * 方法功能描述：选择材料名称后，规格联动；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-26
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void PLinkage()
        {
            int pkId;

            if (cbxKind.SelectedValue == null)
            {
                pkId = 0;
            }
            else
            {
                pkId = Convert.ToInt32(cbxKind.SelectedValue.ToString());
            }

            cbxName.DataSource = pLogic.InitialPNameComboBox(pkId);

            if (pLogic.InitialPNameComboBox(pkId).Rows.Count != 0)
            {
                cbxName.DisplayMember = "产品名称";
                cbxName.ValueMember = "id";
                cbxName.Text = "";
                cbxName.SelectedIndex = -1;
            }

            cbxModel.Text = "";
            cbxModel.SelectedIndex = -1;
        }
        #endregion

        #region setPmodel()选择产品名称后，规格联动
        /*
         * 方法名称： setPmodel()
         * 方法功能描述：选择产品名称后，规格联动；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-20
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setPmodel()
        {
            int pnId;
            if (cbxName.SelectedValue == null)
            {
                pnId = 0;
            }
            else
            {
                pnId = Convert.ToInt32(cbxName.SelectedValue.ToString());
            }

            cbxModel.DataSource = pLogic.InitialPModelComboBox(pnId);

            if (pLogic.InitialPModelComboBox(pnId).Rows.Count != 0)
            {
                cbxModel.DisplayMember = "产品规格";
                cbxModel.ValueMember = "id";
                cbxModel.Text = "";
                cbxModel.SelectedIndex = -1;
            }
        }
        #endregion

        #region SetData() 更新数据时，将原数据显示在文本、下拉列表框中；
        /*
         * 方法名称： SetData()
         * 方法功能描述：更新数据时，将原数据显示在文本、下拉列表框中；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-26
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void SetData()
        {
            datatable = eLogic.SearchLiquidMatter(Id);
            if (datatable.Rows.Count == 0)
            {
                return;
            }
            else
            {
                txtHeight.Text = datatable.Rows[0]["eHeight"].ToString();
                txtDiameter.Text = datatable.Rows[0]["diameter"].ToString();
                cbxType.Text = datatable.Rows[0]["kind"].ToString();
                cbx_yno.Text = datatable.Rows[0]["no"].ToString();
                txtRemark.Text = datatable.Rows[0]["remark"].ToString();

                if ( datatable.Rows[0]["mId"].ToString() != "")
                {
                    setMKind();
                    rbtnMaterial.Checked = true;

                    dt = eLogic.searchMPInfo(Convert.ToInt64(datatable.Rows[0]["mId"].ToString()), 1);
                    cbxKind.SelectedIndex = transportLogic.FindIndex(cbxKind, dt.Rows[0]["sort"].ToString(), "材料种类");
                    MLinkage();
                    cbxName.SelectedIndex = transportLogic.FindIndex(cbxName, dt.Rows[0]["name"].ToString(), "材料名称");
                    setMmodel();
                    cbxModel.SelectedIndex = transportLogic.FindIndex(cbxModel, dt.Rows[0]["model"].ToString(), "材料规格");
                    return;
                }
                if ( datatable.Rows[0]["pId"].ToString() != "")
                {
                    setPKind();
                    rbtnProduct.Checked = true;

                    dt = eLogic.searchMPInfo(Convert.ToInt64(datatable.Rows[0]["pId"].ToString()), 2);
                    cbxKind.SelectedIndex=transportLogic.FindIndex(cbxKind, dt.Rows[0]["sort"].ToString(), "产品种类");
                    PLinkage();
                    cbxName.SelectedIndex = transportLogic.FindIndex(cbxName, dt.Rows[0]["name"].ToString(), "产品名称");
                    setPmodel();
                    cbxModel.SelectedIndex = transportLogic.FindIndex(cbxModel, dt.Rows[0]["model"].ToString(), "产品规格");
                    return;
                }
            }
        }
        #endregion

        #region Set_yeweino()
        private void Set_yeweino()
        {
            cbx_yno.DataSource = eLogic.searchYNO();
            cbx_yno.DisplayMember = "no";
            cbx_yno.ValueMember = "id";
            cbx_yno.Text = "";
            cbx_yno.SelectedIndex = -1;
        }
        #endregion

        private void FrmEquipmentInfo_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FrmEquipmentInfo_Load(object sender, EventArgs e)
        {
            txtNo.Text = No.ToString();
            txtName.Text = EName;
            
            if (this.Text.Trim().Equals("更新沥青罐参数"))
            {
                Set_yeweino();
                setPKind();
                setMKind();
                SetData();
            }
            else
            {
                setMKind();

                cbxKind.Text = "";
                cbxKind.SelectedIndex = -1;
                Set_yeweino();
            }
        }

        private void rbtnProduct_CheckedChanged(object sender, EventArgs e)
        {
            setPKind();

            label17.Text = "产品种类";
            label16.Text = "产品名称";
            label15.Text = "产品规格";

            cbxKind.Text = "";
            cbxKind.SelectedIndex = -1;
            cbxName.Text = "";
            cbxName.SelectedIndex = -1;
            cbxModel.Text = "";
            cbxModel.SelectedIndex = -1;
        }

        private void rbtnMaterial_CheckedChanged(object sender, EventArgs e)
        {
            setMKind();
            label17.Text = "材料种类";
            label16.Text = "材料名称";
            label15.Text = "材料规格";

            cbxKind.Text = "";
            cbxKind.SelectedIndex = -1;
            cbxName.Text = "";
            cbxName.SelectedIndex = -1;
            cbxModel.Text = "";
            cbxModel.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                
                SetPara();

                if (this.Text.Trim().Equals("更新沥青罐参数"))
                {
                    if (eLogic.InsertLiquidMatter(eclass, 2))
                    {
                        //MessageBox.Show("修改记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("修改记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (eLogic.InsertLiquidMatter(eclass,1))
                    {
                        //MessageBox.Show("新增记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cbxKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (rbtnMaterial.Checked)
            {
                if (this.Text.Trim().Equals("更新沥青罐参数"))
                {
                    return;
                }
                else
                {
                    MLinkage();

                }
            }
            if (rbtnProduct.Checked)
            {
                PLinkage();
            }
        }

        private void cbxName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (rbtnMaterial.Checked)
            {
                setMmodel();
            }
            if (rbtnProduct.Checked)
            {
                setPmodel();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbxKind.SelectedValue.ToString());
        }

        private void FrmEquipmentInfo_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        } 
    }
}
