using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.system;
using DasherStation.ReportDistrict.storageReport;

namespace DasherStation.storage
{
    public partial class FrmStockInR : common.BaseForm
    {
        public FrmStockInR()
        {
            InitializeComponent();
        }

        StockInRLogic sIRLogic = new StockInRLogic();
        MaterialLogic mLogic = new MaterialLogic();
        StockInRClass stockClass = new StockInRClass();
        StockMOutRClass stockOutMclass = new StockMOutRClass();
        StockStatLogic ssl = new StockStatLogic();
        int mnId, mmId,mkId;

        #region 为材料种类赋值;
        private void SetMKind(ComboBox mKind)
        {
            mKind.DataSource = mLogic.InitialMKindComboBox();
            mKind.DisplayMember = "材料种类";
            mKind.ValueMember = "id";
            mKind.Text = "";
            mKind.SelectedIndex = -1;
        }
        #endregion

        #region 为选择材料种类后材料名称跟着联动;
        private void cobBoBoxLinkage(ComboBox mName, int mkId)
        {

            if (mLogic.InitialMNameComboBox(mkId).Rows.Count != 0)
            {
                mName.DataSource = mLogic.InitialMNameComboBox(mkId);
                mName.DisplayMember = "材料名称";
                mName.ValueMember = "id";
                mName.Text = "";
                mName.SelectedIndex = -1;
            }
            else
            {
                mName.DataSource = mLogic.InitialMNameComboBox(mkId);
            }
            cbxType.Text = "";
            cbxType.SelectedIndex = -1;
            cbxmModel.Text = "";
            cbxmModel.SelectedIndex = -1;

        }
        #endregion

        #region setCbxMmodel()选择材料名称后，规格联动
        /*
         * 方法名称： setCbxMmodel()
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
        private void setCbxMmodel(ComboBox mModel,int mnId)
        {
            if (mLogic.InitialMModelComboBox(mnId).Rows.Count != 0)
            {
                mModel.DataSource = mLogic.InitialMModelComboBox(mnId);

                mModel.DisplayMember = "材料规格";
                mModel.ValueMember = "id";
                mModel.Text = "";
                mModel.SelectedIndex = -1;
            }
            else
            {
                mModel.DataSource = mLogic.InitialMModelComboBox(mnId);
            }
        }
        #endregion

        #region setCbxMmodel()为车辆号赋值
        /*
         * 方法名称： setCbxVoiture()
         * 方法功能描述：为车辆号赋值；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-11
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setCbxVoiture()
        {
            TruckLogic truckLogic = new TruckLogic();
            cbxVoiture.DataSource = truckLogic.InitialTruckComboBox(3);
            cbxVoiture.DisplayMember = "no";
            cbxVoiture.ValueMember = "id";
            cbxVoiture.Text = "";
            cbxVoiture.SelectedIndex = -1;
        }
        #endregion

        #region setCbxMTUnit()为运输公司赋值
        /*
         * 方法名称： setCbxMTUnit()
         * 方法功能描述：为运输公司赋值；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-11
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setCbxMTUnit()
        {
            TruckLogic truckLogic = new TruckLogic();
            cbxTransport.DataSource = truckLogic.InitialTruckComboBox1();
            cbxTransport.DisplayMember = "name";
            cbxTransport.ValueMember = "id";
            cbxTransport.Text = "";
            cbxTransport.SelectedIndex = -1;
        }
        #endregion

        #region setCbxMProvider()为供应商赋值
        /*
         * 方法名称： setCbxMProvider()
         * 方法功能描述：为供应商赋值；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-11
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setCbxMProvider()
        {
            cbxProvider.DataSource = sIRLogic.providerSearch();
            cbxProvider.DisplayMember = "name";
            cbxProvider.ValueMember = "id";
            cbxProvider.Text = "";
            cbxProvider.SelectedIndex = -1;
        }

        #endregion

        #region getPara()取出材料出库台帐查询条件
        /*
         * 方法名称： getPara()
         * 方法功能描述：取出材料出库台帐查询条件；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-11
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void getPara()
        {
            // 取出材料ID;
            if (!cbxmKind.Text.Trim().Equals(""))
            {
                mkId = Convert.ToInt32(this.cbxmKind.SelectedValue.ToString());
            }
            else
            {
                mkId = 0;
            }
            if (!cbxmName.Text.Trim().Equals(""))
            {
                mnId = Convert.ToInt32(this.cbxmName.SelectedValue.ToString());
                if (!cbxmModel.Text.Trim().Equals(""))
                {
                    mmId = Convert.ToInt32(this.cbxmModel.SelectedValue.ToString());
                    stockOutMclass.Mid = mLogic.MaterialSearch(mnId, mmId);
                }
                else
                {
                    mmId = 0;
                    stockOutMclass.Mid = 0;
                }
            }
            else
            {
                mnId = 0;
                stockOutMclass.Mid = 0;
            }

            // 取出时间;
            if (checkBegin.Checked)
            {
                stockOutMclass.BeginTime = Convert.ToDateTime(dtpBegionO.Text).ToString("yyyy-MM-dd");
            }
            else
            {
                stockOutMclass.BeginTime = "";
            }
            if (checkEnd.Checked)
            {
                stockOutMclass.EndTime = Convert.ToDateTime(dtpEndO.Text).ToString("yyyy-MM-dd");
            }
            else
            {
                stockOutMclass.EndTime = "";
            }
            // 取出设备编号;
            if (!cbxEquipment.Text.Trim().Equals(""))
            {
                stockOutMclass.Equipmentid = Convert.ToInt32(this.cbxEquipment.SelectedValue.ToString());
            }
            else
            {
                stockOutMclass.Equipmentid = 0;
            }
            // 取出审核、审批查询条件；
            if (!string.IsNullOrEmpty(cbxState.Text.Trim()))
            {
                stockOutMclass.State = cbxState.Text.Trim();
            }
            else
            {
                stockOutMclass.State = "";
            }

        }
            #endregion

        #region getInPara()取出材料入库台帐查询条件
        /*
         * 方法名称： getInPara()
         * 方法功能描述：取出材料入库台帐查询条件；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-11
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void getInPara()
        {
            // 材料入库;
            // 取出材料ID;
            if (!cbxKind.Text.Trim().Equals(""))
            {
                mkId = Convert.ToInt32(this.cbxKind.SelectedValue.ToString());
            }
            else
            {
                mkId = 0;
            }
            if (!cbxName.Text.Trim().Equals(""))
            {
                mnId = Convert.ToInt32(this.cbxName.SelectedValue.ToString());
                if (!cbxType.Text.Trim().Equals(""))
                {
                    mmId = Convert.ToInt32(this.cbxType.SelectedValue.ToString());
                    stockClass.Mid = (long)mLogic.MaterialSearch(mnId, mmId);
                }
                else
                {
                    mmId = 0;
                }
            }
            else
            {
                mnId = 0;
                stockClass.Mid = 0;
            }
            // 取出车牌ID;
            if (!cbxVoiture.Text.Trim().Equals(""))
            {
                stockClass.Voitureid = Convert.ToInt64(this.cbxVoiture.SelectedValue.ToString());
            }
            else
            {
                stockClass.Voitureid = 0;
            }
            // 取出供应商ID;
            if (!cbxProvider.Text.Trim().Equals(""))
            {
                stockClass.Providerid = Convert.ToInt64(this.cbxProvider.SelectedValue.ToString());
            }
            else
            {
                stockClass.Providerid = 0;
            }
            // 取出运输单位ID;
            if (!cbxTransport.Text.Trim().Equals(""))
            {
                stockClass.Transportid = Convert.ToInt64(this.cbxTransport.SelectedValue.ToString());
            }
            else
            {
                stockClass.Transportid = 0;
            }
            // 取出时间;
            if (chkBegin.Checked)
            {
                stockClass.BeginTime = Convert.ToDateTime(dtpBegin.Text).ToString("yyyy-MM-dd");
            }
            else
            {
                stockClass.BeginTime = "";
            }
            if (chkEnd.Checked)
            {
                stockClass.EndTime = Convert.ToDateTime(dtpEnd.Text).ToString("yyyy-MM-dd");
            }
            else
            {
                stockClass.EndTime = "";
            }
            // 取出审核、审批状态；
            if (!string.IsNullOrEmpty(cbx_state.Text.Trim()))
            {
                stockClass.State = cbx_state.Text.Trim();
            }
            else
            {
                stockClass.State = "";
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
            cbxEquipment.DataSource = sIRLogic.SearchEquipmentNO();
            cbxEquipment.DisplayMember = "no";
            cbxEquipment.ValueMember = "id";
            cbxEquipment.Text = "";
            cbxEquipment.SelectedIndex = -1;
        }
        #endregion

        #region 对材料入库的数量和金额进行汇总
        private void Collect_MIN()
        {
            // 在dgvStockIn的最后一行追加统计行
            if (dgvStockIn.RowCount > 0)
            {
                double quantity = 0;
                double quantitySum = 0;
                double goodQuantity = 0;
                double goodQuantitySum = 0;

                DataTable dt = (DataTable)(dgvStockIn.DataSource);
                foreach (DataRow r in dt.Rows)
                {
                    quantity = 0;
                    goodQuantity = 0;

                    double.TryParse(r["净重"].ToString(), out quantity);
                    double.TryParse(r["入库金额"].ToString(), out goodQuantity);

                    quantitySum += quantity;
                    goodQuantitySum += goodQuantity;
                }

                DataRow row = dt.NewRow();
                row["净重"] = quantitySum;
                row["入库金额"] = goodQuantitySum;
                dt.Rows.Add(row);
            }
        }
        #endregion

        #region setDataGridView()为材料入库台帐DataGridView赋值
        /*
         * 方法名称： setDataGridView()
         * 方法功能描述：为DataGridView赋值；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-11
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setDataGridView()
        {
            getInPara();
            dgvStockIn.DataSource = sIRLogic.MaterialINSearch(stockClass,mkId, mnId);
            Collect_MIN();
        }
        #endregion

        #region 审核操作
        private DialogResult assess()
        {
            DialogResult result = MessageBox.Show("是否同意审核操作", "提示", MessageBoxButtons.YesNo);
            return result;
        }
        #endregion

        #region 审批操作
        private DialogResult checkup()
        {
            DialogResult result = MessageBox.Show("是否同意审批操作", "提示", MessageBoxButtons.YesNo);
            return result;
        }
        #endregion

        #region 对材料出库的数量和金额进行汇总
        private void Collect_MOut()
        {
            // 在dgvStorageOut的最后一行追加统计行
            if (dgvStorageOut.RowCount > 0)
            {
                double quantity = 0;
                double quantitySum = 0;
                double goodQuantity = 0;
                double goodQuantitySum = 0;

                DataTable dt = (DataTable)(dgvStorageOut.DataSource);
                foreach (DataRow r in dt.Rows)
                {
                    quantity = 0;
                    goodQuantity = 0;

                    double.TryParse(r["出库数量"].ToString(), out quantity);
                    double.TryParse(r["出库金额"].ToString(), out goodQuantity);

                    quantitySum += quantity;
                    goodQuantitySum += goodQuantity;
                }

                DataRow row = dt.NewRow();
                row["出库数量"] = quantitySum;
                row["出库金额"] = goodQuantitySum;
                dt.Rows.Add(row);
            }
        }
        #endregion

        #region setOutDataGridView()为材料出库台帐DataGridView赋值
        /*
         * 方法名称： setOutDataGridView()
         * 方法功能描述：为DataGridView赋值；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-11
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setOutDataGridView()
        {
            string sqlwhere;
            getPara();
            sqlwhere = sIRLogic.GetMaterialSQL(stockOutMclass,mkId,mnId);
            dgvStorageOut.DataSource = sIRLogic.MaterialOutSearch(sqlwhere);
            Collect_MOut();
        }
        #endregion

        #region ClearAction()清空控件
        /*
         * 方法名称： ClearAction()
         * 方法功能描述：清空控件；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-11
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void ClearAction()
        {
            cbxKind.Text = "";
            cbxKind.SelectedIndex = -1;
            cbxName.Text = "";
            cbxName.SelectedIndex = -1;
            cbxType.Text = "";
            cbxType.SelectedIndex = -1;
            cbxVoiture.Text = "";
            cbxVoiture.SelectedIndex = -1;
            cbxProvider.Text = "";
            cbxProvider.SelectedIndex = -1;
            cbxTransport.Text = "";
            cbxTransport.SelectedIndex = -1;

            cbxmKind.Text = "";
            cbxmKind.SelectedIndex = -1;
            cbxmName.Text = "";
            cbxmName.SelectedIndex = -1;
            cbxmModel.Text = "";
            cbxmModel.SelectedIndex = -1;
            cbxEquipment.Text = "";
            cbxEquipment.SelectedIndex = -1;

            cbxState.Text = "";

        }
        #endregion

        private void FrmStockInR_Load(object sender, EventArgs e)
        {
            // 初始化材料入库DataGridView
            setDataGridView();
            // 初始化材料出库DataGridView
            setOutDataGridView();
            // 初始化材料种类
            SetMKind(cbxKind);
            SetMKind(cbxmKind);
            // 初始化车牌号码
            setCbxVoiture();
            // 初始化运输公司
            setCbxMTUnit();
            // 初始化供应商
            setCbxMProvider();
            // 初始化设备编号;
            setEquipment();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 材料入库台帐查询;
            setDataGridView();
            ClearAction();   
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ( tabControl1.SelectedTab.Name == tabPage1.Name )
                {
                    groupBox2.Visible = false;
                    groupBox1.Visible = true;
                    setDataGridView();
                }
                if (tabControl1.SelectedTab.Name == tabPage2.Name)
                {
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    setOutDataGridView();
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

        private void cbxKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 选择材料种类后,名称联动;
            int mkId;

            if (cbxKind.SelectedValue == null)
            {
                mkId = 0;
            }
            else    
            {
                mkId = Convert.ToInt32(cbxKind.SelectedValue.ToString());
            }

            cobBoBoxLinkage(cbxName, mkId);

        }

        private void cbxmKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 选择材料种类后,名称联动;
            int mkId;

            if (cbxmKind.SelectedValue == null)
            {
                mkId = 0;
            }
            else
            {
                mkId = Convert.ToInt32(cbxmKind.SelectedValue.ToString());
            }
           
            cobBoBoxLinkage(cbxmName, mkId);
        }

        private void cbxmName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 选择材料名称后,规格联动;
            int mnId;
            if (cbxmName.SelectedValue == null)  
            {
                mnId = 0;
            }
            else
            {
                mnId = Convert.ToInt32(cbxmName.SelectedValue.ToString());
            }

            setCbxMmodel(cbxmModel, mnId);
        }

        private void cbxName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 选择材料名称后,规格联动;
            int mnId;
            if (cbxName.SelectedValue == null)
            {
                mnId = 0;
            }
            else
            {
                mnId = Convert.ToInt32(cbxName.SelectedValue.ToString());
            }

            setCbxMmodel(cbxType, mnId);
        }

        private void chkBegin_CheckedChanged(object sender, EventArgs e)
        {
            // 单选按钮,控件时间控件是否可用;
            if (chkBegin.Checked)
            {
                dtpBegin.Enabled = true; 
            }
            else
            {
                dtpBegin.Enabled = false;
            }
        }

        private void chkEnd_CheckedChanged(object sender, EventArgs e)
        {
            // 选择材料名称后,规格联动;
            if (chkEnd.Checked) 
            {
                dtpEnd.Enabled = true;
            }
            else
            {
                dtpEnd.Enabled = false;
            }
        }

        private void btnOutQuery_Click(object sender, EventArgs e)
        {
            // 材料出库台帐查询;
            getPara();
            setOutDataGridView();
            ClearAction();
        }

        private void checkBegin_CheckedChanged(object sender, EventArgs e)
        {
            // 选择材料名称后,规格联动;
            if (checkBegin.Checked)
            {
                dtpBegionO.Enabled = true;
            }
            else
            {
                dtpBegionO.Enabled = false;
            }
        }

        private void checkEnd_CheckedChanged(object sender, EventArgs e)
        {
            // 选择材料名称后,规格联动;
            if (checkEnd.Checked)
            {
                dtpEndO.Enabled = true;
            }
            else
            {
                dtpEndO.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMaterialOutDepot frmMaterialOutDepot = new FrmMaterialOutDepot();

            if (frmMaterialOutDepot.ShowDialog(this) == DialogResult.OK)
            {
                setOutDataGridView();
            }
        }

        private void btn_assess_Click(object sender, EventArgs e)
        {
            if (dgvStockIn.CurrentRow != null)
            {
                if (dgvStockIn.CurrentRow.Cells["流水号"].Value.ToString().Equals(""))
                {
                    return;
                }
                if (!dgvStockIn.CurrentRow.Cells["审核"].Value.ToString().Equals(""))
                {
                    MessageBox.Show("该记录已审核完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var estate = assess();
                if ( estate.ToString().Equals("Yes"))
                {
                    long id = Convert.ToInt64(dgvStockIn.CurrentRow.Cells[0].Value.ToString());
                    if (sIRLogic.Material_Assess("I",id,this.userName))
                    {
                        MessageBox.Show("审核成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setDataGridView();
                    }
                }
            }
            else
            {
                MessageBox.Show("未选中任何一条记录，请选中一条记录后进行审核操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_checkup_Click(object sender, EventArgs e)
        {
            if (dgvStockIn.CurrentRow != null)
            {
                if (dgvStockIn.CurrentRow.Cells["流水号"].Value.ToString().Equals(""))
                {
                    return;
                }
                if (!dgvStockIn.CurrentRow.Cells["审批"].Value.ToString().Equals(""))
                {
                    MessageBox.Show("该记录已审批完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dgvStockIn.CurrentRow.Cells["审核"].Value.ToString().Equals(""))
                {
                    MessageBox.Show("该记录未审核，请审核后在进行审批操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                long id = Convert.ToInt64(dgvStockIn.CurrentRow.Cells[0].Value.ToString());
                var estate = checkup();
                if (estate.ToString().Equals("Yes"))
                {
                    if (sIRLogic.Material_Checkup("I", id, this.userName))
                    {
                        MessageBox.Show("审批成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setDataGridView();
                        
                        // 执行审批操作后,执行计算库存的方法;
                        var s = ssl.Stock_Material();
                    }
                }
                else
                {
                    var i = sIRLogic.Material_Assess("I", id, "NULL");
                    setDataGridView();
                }
            }
            else
            {
                MessageBox.Show("未选中任何一条记录，请选中一条记录后进行审核操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAssess_Click(object sender, EventArgs e)
        {
            if (dgvStorageOut.CurrentRow != null)   
            {
                if (dgvStorageOut.CurrentRow.Cells["流水号"].Value.ToString().Equals(""))
                {
                    return;
                }
                if (! dgvStorageOut.CurrentRow.Cells["审核"].Value.ToString() .Equals(""))
                {
                    MessageBox.Show("该记录已审核完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var estate = assess();
                if (estate.ToString().Equals("Yes"))
                {
                    long id = Convert.ToInt64(dgvStorageOut.CurrentRow.Cells[0].Value.ToString());
                    if (sIRLogic.Material_Assess("O", id, this.userName))
                    {
                        MessageBox.Show("审核成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setOutDataGridView();
                    }
                }
            }
            else
            {
                MessageBox.Show("未选中任何一条记录，请选中一条记录后进行审核操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckup_Click(object sender, EventArgs e)
        {
            if (dgvStorageOut.CurrentRow != null)
            {
                if (dgvStorageOut.CurrentRow.Cells["流水号"].Value.ToString().Equals(""))
                {
                    return;
                }
                if (!dgvStorageOut.CurrentRow.Cells["审批"].Value.ToString().Equals(""))
                {
                    MessageBox.Show("该记录已审批完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dgvStorageOut.CurrentRow.Cells["审核"].Value.ToString() .Equals(""))
                {
                    MessageBox.Show("该记录未审核，请审核后在进行审批操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                long id = Convert.ToInt64(dgvStorageOut.CurrentRow.Cells[0].Value.ToString());
                var estate = checkup();
                if (estate.ToString().Equals("Yes"))
                {
                    if (sIRLogic.Material_Checkup("O", id, this.userName))
                    {
                        MessageBox.Show("审批成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setOutDataGridView();
                        // 执行审批操作后,执行计算库存的方法;
                        var s = ssl.Stock_Material();
                    }
                }
                else
                {
                    var i = sIRLogic.Material_Assess("O", id, "NULL");
                    setOutDataGridView();
                }
            }
            else
            {
                MessageBox.Show("未选中任何一条记录，请选中一条记录后进行审核操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_print_out_Click(object sender, EventArgs e)
        {
            ReportStorageClass storage_report = new ReportStorageClass();

            storage_report.RunStuffInAccount(stockClass, mkId, mnId);
        }

    }
}
