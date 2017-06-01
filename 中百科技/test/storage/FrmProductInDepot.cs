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
    public partial class FrmProductInDepot : common.BaseForm
    {
        public FrmProductInDepot()
        {
            InitializeComponent();
        }

        ProductLogic pLogic = new ProductLogic();
        FormHelper formHelper = new FormHelper();
        ProductInDepotLogic pInDepotLogic = new ProductInDepotLogic();
        ProductInDepotClass pInDepot = new ProductInDepotClass();

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

        #region 取出该产品的计划单价
        /*
         * 方法名称： Get_UnitPrice()
         * 方法功能描述：取出该产品的计划单价；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-11
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private string Get_UnitPrice()
        {
            ProductInDepotLogic productIDL = new ProductInDepotLogic();
            return productIDL.SearchplanPrice(Get_PID());
        }
	    #endregion

        #region 取出该产品ID
        /*
         * 方法名称： Get_PID()
         * 方法功能描述：取出该产品ID；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-11
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
                    pid = Convert.ToInt64( pLogic.PSearchID(pnid, pmid));
                }
            }
            return pid;
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
            pInDepot.Pid = Get_PID();

            if (!string.IsNullOrEmpty(cbxENo.Text.Trim()))
            {
                pInDepot.EiId = Convert.ToInt64(this.cbxENo.SelectedValue.ToString());
            }
            else
            {
                pInDepot.EiId = 0;
            }

            if (!string.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                pInDepot.Number = decimal.Parse(txtAmount.Text.Trim());
            }
            else
            {
                pInDepot.Number = 0;
            }

            if (!string.IsNullOrEmpty(txtUnitPrice.Text.Trim()))
            {
                pInDepot.UnitPrice = decimal.Parse(txtUnitPrice.Text.Trim());
            }
            else
            {
                pInDepot.UnitPrice = 0;
            }

            pInDepot.InputMan = this.userName;
            pInDepot.ComputationMark = "False";

        }
        #endregion

        private void FrmProductInDepot_Load(object sender, EventArgs e)
        {
            // 初始化,产品种类、名称、规格、设备编号；
            setCbxkind();
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
                if (pInDepotLogic.InsertProductInDepot(pInDepot))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmProductInDepot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cbxModel_Leave(object sender, EventArgs e)
        {
            txtUnitPrice.Text = Get_UnitPrice();
        }

    }
}
