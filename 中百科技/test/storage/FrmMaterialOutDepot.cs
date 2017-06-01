using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.system;
using DasherStation.transport;

namespace DasherStation.storage
{
    public partial class FrmMaterialOutDepot : common.BaseForm
    {
        public FrmMaterialOutDepot()
        {
            InitializeComponent();
        }

        ProductLogic pLogic = new ProductLogic();
        MaterialLogic mLogic = new MaterialLogic();
        FormHelper formHelper = new FormHelper();
        MaterialOutDepotLogic mOutDepotLogic = new MaterialOutDepotLogic();
        MaterialOutDepotClass mOutDepot = new MaterialOutDepotClass();

        #region setCbxPkind()设置产品种类
        /*
         * 方法名称： setCbxPkind()
         * 方法功能描述：设置产品种类；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setCbxkind()
        {
            cbxKind.DataSource = pLogic.InitialPKindComboBox();
            cbxKind.DisplayMember = "产品种类";
            cbxKind.ValueMember = "id";
            cbxKind.Text = "";
            cbxKind.SelectedIndex = -1;
        }
        #endregion

        #region cobBoBoxLinkage()选择产品种类后,产品名称联动;
        /*
         * 方法名称： cobBoBoxLinkage()
         * 方法功能描述：选择产品名称后，规格联动；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void cobBoBoxLinkage()
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
            if (pLogic.InitialPNameComboBox(pkId).Rows.Count != 0)
            {
                cbxName.DataSource = pLogic.InitialPNameComboBox(pkId);
                cbxName.DisplayMember = "产品名称";
                cbxName.ValueMember = "id";
                cbxName.Text = "";
                cbxName.SelectedIndex = -1;
            }
            else
            {
                cbxName.DataSource = pLogic.InitialPNameComboBox(pkId);
            }
            cbxModel.Text = "";
            cbxModel.SelectedIndex = -1;
        }
        #endregion

        #region setCbxmodel()选择产品名称后，规格联动
        /*
         * 方法名称： setCbxPmodel()
         * 方法功能描述：选择产品名称后，规格联动；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setCbxmodel()
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
            if (pLogic.InitialPModelComboBox(pnId).Rows.Count != 0)
            {
                cbxModel.DataSource = pLogic.InitialPModelComboBox(pnId);
                cbxModel.DisplayMember = "产品规格";
                cbxModel.ValueMember = "id";
                cbxModel.Text = "";
                cbxModel.SelectedIndex = -1;
            }
            else
            {
                cbxModel.DataSource = pLogic.InitialPModelComboBox(pnId);
            }
        }
        #endregion

        #region 为材料种类赋值;
        private void SetMKind()
        {
            cbxMKind.DataSource = mLogic.InitialMKindComboBox();
            cbxMKind.DisplayMember = "材料种类";
            cbxMKind.ValueMember = "id";
            cbxMKind.Text = "";
            cbxMKind.SelectedIndex = -1;
        }
        #endregion

        #region 为选择材料种类后材料名称跟着联动;
        private void McobBoBoxLinkage()
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

        #region setCbxMmodel()选择材料名称后，规格联动
        /*
         * 方法名称： setCbxMmodel()
         * 方法功能描述：选择材料名称后，规格联动；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
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

        #region 为设备编号赋值
        /*
         * 方法名称： setEquipment()
         * 方法功能描述：为设备编号赋值；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-11
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setEquipment()
        {
            StockInRLogic sIRLogic = new StockInRLogic();
            cbxENo.DataSource = sIRLogic.SearchEquipmentNO();
            cbxENo.DisplayMember = "no";
            cbxENo.ValueMember = "id";
            cbxENo.Text = "";
            cbxENo.SelectedIndex = -1;
        }
        #endregion

        #region 取出该产品ID
        /*
         * 方法名称： Get_PID()
         * 方法功能描述：取出该产品ID；
         *
         * 创建人：冯雪
         * 创建时间：2009-04-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private long Get_PID()
        {
            long pid = 0;
            if (!string.IsNullOrEmpty(cbxName.Text.Trim()))
            {
                int pnid = Convert.ToInt32(this.cbxName.SelectedValue.ToString());
                if (!string.IsNullOrEmpty(cbxModel.Text.Trim()))
                {
                    int pmid = Convert.ToInt32(this.cbxModel.SelectedValue.ToString());
                    // 提取产品ID；
                    pid = Convert.ToInt64(pLogic.PSearchID(pnid, pmid));
                }
            }
            return pid;
        }
        #endregion

        #region 取出材料ID
        /*
         * 方法名称： Get_MID()
         * 方法功能描述：取出该材料ID；
         *
         * 创建人：冯雪
         * 创建时间：2009-04-11
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private long Get_MID()
        {
            long mid = 0;
            if (!string.IsNullOrEmpty(cbxMName.Text.Trim())) 
            {
                int mnid = Convert.ToInt32(this.cbxMName.SelectedValue.ToString());
                if (!string.IsNullOrEmpty(cbxMModel.Text.Trim())) 
                {
                    int mmid = Convert.ToInt32(this.cbxMModel.SelectedValue.ToString());
                    // 提取材料ID；
                    mid = Convert.ToInt64(mLogic.MaterialSearch(mnid, mmid)); 
                }
            }
            return mid;
        }
        #endregion

        #region 取出该材料的平均单价
        /*
         * 方法名称： Get_UnitPrice()
         * 方法功能描述：取出该材料的平均单价；
         *
         * 创建人：冯雪
         * 创建时间：2009-04-11
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private string Get_UnitPrice()
        {
            ProductInDepotLogic productIDL = new ProductInDepotLogic();
            return productIDL.SearchplanPrice(Get_MID());
        }
        #endregion

        #region Get_para() 获得要插入的数据
        /*
         * 方法名称： Get_para()
         * 方法功能描述：获得要插入的数据；
         *
         * 创建人：冯雪
         * 创建时间：2009-04-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public void Get_para()
        {
            mOutDepot.Pid = Get_PID();
            mOutDepot.Mid = Get_MID();

            if (!string.IsNullOrEmpty(cbxENo.Text.Trim()))
            {
                mOutDepot.EiId = Convert.ToInt64(this.cbxENo.SelectedValue.ToString());
            }
            else
            {
                mOutDepot.EiId = 0;
            }

            if (!string.IsNullOrEmpty(txtNumber.Text.Trim())) 
            {
                mOutDepot.Number = decimal.Parse(txtNumber.Text.Trim());
            }
            else
            {
                mOutDepot.Number = 0;
            }

            if (!string.IsNullOrEmpty(txtUnitPrice.Text.Trim()))
            {
                mOutDepot.UnitPrice = decimal.Parse(txtUnitPrice.Text.Trim());
            }
            else
            {
                mOutDepot.UnitPrice = 0;
            }

            mOutDepot.InputMan = this.userName;
            mOutDepot.ComputationMark = "False";

        }
        #endregion

        private void FrmMaterialOutDepot_Load(object sender, EventArgs e)
        {
            // 设置产品种类、材料种类、设备编号；
            setCbxkind();
            SetMKind();
            setEquipment();
        }

        private void cbxKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cobBoBoxLinkage();
        }

        private void cbxName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setCbxmodel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(groupBox1))
            {
                Get_para();
                if (mOutDepotLogic.InsertMaterialOutDepot(mOutDepot))
                {
                    // 材料手工出库成功后，自动算一下材料库存；
                    StockStatLogic ssl = new StockStatLogic();
                    ssl.Stock_Material();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbxMName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setCbxMmodel();
        }

        private void cbxMKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            McobBoBoxLinkage();
        }

        private void cbxMModel_Leave(object sender, EventArgs e)
        {
            txtUnitPrice.Text = Get_UnitPrice();
        }

        private void FrmMaterialOutDepot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
