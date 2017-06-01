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
    public partial class FrmStockOutR : common.BaseForm
    {
        public FrmStockOutR()
        {
            InitializeComponent();
        }

        StockOutRLogic stockORLogic = new StockOutRLogic();
        StockOutRClass stockORClass = new StockOutRClass();
        StockPInRClass stockIrClass = new StockPInRClass();
        ProductLogic pLogic = new ProductLogic();
        StockStatLogic ssl = new StockStatLogic();
        string sqlWhere;
        int pkId ,pnId , pmId ;

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

        #region 为产品种类赋值;
        private void SetPKind()
        {
            cbxOPkind.DataSource = pLogic.InitialPKindComboBox();
            cbxOPkind.DisplayMember = "产品种类";
            cbxOPkind.ValueMember = "id";
            cbxOPkind.Text = "";
            cbxOPkind.SelectedIndex = -1;

            cbxkind.DataSource = pLogic.InitialPKindComboBox();
            cbxkind.DisplayMember = "产品种类";
            cbxkind.ValueMember = "id";
            cbxkind.Text = "";
            cbxkind.SelectedIndex = -1;

        }
        #endregion

        #region 为选择产品种类后产品名称跟着联动;
        private void cobBoBoxLinkage(ComboBox pName, int pkId)
        {

            if (pLogic.InitialPNameComboBox(pkId).Rows.Count !=0)
            {
                pName.DataSource = pLogic.InitialPNameComboBox(pkId);
                pName.DisplayMember = "产品名称";
                pName.ValueMember = "id";
                pName.Text = "";
                pName.SelectedIndex = -1;
            }
            else
            {
                pName.DataSource = pLogic.InitialPNameComboBox(pkId);
            }
            cbxmodel.Text = "";
            cbxmodel.SelectedIndex = -1;
            cbxOPmodle.Text = "";
            cbxOPmodle.SelectedIndex = -1;

        }
        #endregion

        #region 选择产品名称后，规格联动
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
        private void setCbxPmodel(ComboBox pModel, int pnId)
        {
            if (pLogic.InitialPModelComboBox(pnId).Rows.Count !=0)
            {
                pModel.DataSource = pLogic.InitialPModelComboBox(pnId);

                pModel.DisplayMember = "产品规格";
                pModel.ValueMember = "id";
                pModel.Text = "";
                pModel.SelectedIndex = -1;
            }
            else
            {
                pModel.DataSource = pLogic.InitialPModelComboBox(pnId);
            }
        }
        #endregion

        #region 对产品出库的数量和金额进行汇总
        private void Collect_POut()
        {
            // 在dgvPstockOut的最后一行追加统计行
            if (dgvPstockOut.RowCount > 0)
            {
                double quantity = 0;
                double quantitySum = 0;
                double goodQuantity = 0;
                double goodQuantitySum = 0;

                DataTable dt = (DataTable)(dgvPstockOut.DataSource);
                foreach (DataRow r in dt.Rows)
                {
                    quantity = 0;
                    goodQuantity = 0;

                    double.TryParse(r["净重"].ToString(), out quantity);
                    double.TryParse(r["销售金额"].ToString(), out goodQuantity);

                    quantitySum += quantity;
                    goodQuantitySum += goodQuantity;
                }

                DataRow row = dt.NewRow();
                row["净重"] = quantitySum;
                row["销售金额"] = goodQuantitySum;
                dt.Rows.Add(row);
            }
        }
        #endregion
        
        #region  为产品出库DataGridView赋值
        private void setOutDataGridView()
        {
            dgvPstockOut.DataSource = stockORLogic.ProudctOutSearch(stockORClass,pkId,pnId);
            Collect_POut();
        }
        #endregion

        #region 对产品出库的数量和金额进行汇总
        private void Collect_PIN()
        {
            // 在dgvPstockIn的最后一行追加统计行
            if (dgvPstockIn.RowCount > 0)
            {
                double quantity = 0;
                double quantitySum = 0;
                double goodQuantity = 0;
                double goodQuantitySum = 0;

                DataTable dt = (DataTable)(dgvPstockIn.DataSource);
                foreach (DataRow r in dt.Rows)
                {
                    quantity = 0;
                    goodQuantity = 0;

                    double.TryParse(r["入库数量"].ToString(), out quantity);
                    double.TryParse(r["入库金额"].ToString(), out goodQuantity);

                    quantitySum += quantity;
                    goodQuantitySum += goodQuantity;
                }

                DataRow row = dt.NewRow();
                row["入库数量"] = quantitySum;
                row["入库金额"] = goodQuantitySum;
                dt.Rows.Add(row);
            }
        }
        #endregion

        #region  为产品入库DataGridView赋值
        private void setINDataGridView()
        {
            getInPara();
            sqlWhere = stockORLogic.GetProudctSQL(stockIrClass,pkId,pnId);
            dgvPstockIn.DataSource = stockORLogic.ProudctInSearch(sqlWhere);
            Collect_PIN();
        }
        #endregion

        #region 为车牌号赋值
        private void setVoiture()
        {
            TruckLogic truckLogic = new TruckLogic();
            cbxVoiture.DataSource = truckLogic.InitialTruckComboBox(3);
            cbxVoiture.DisplayMember = "no";
            cbxVoiture.ValueMember = "id";
            cbxVoiture.Text = "";
            cbxVoiture.SelectedIndex = -1;
        }
        #endregion 

        #region setCbxTUnit()为运输公司赋值
        /*
         * 方法名称： setCbxMTUnit()
         * 方法功能描述：为运输公司赋值；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-12
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setCbxTUnit()
        {
            TruckLogic truckLogic = new TruckLogic();
            cbxTUnit.DataSource = truckLogic.InitialTruckComboBox1();
            cbxTUnit.DisplayMember = "name";
            cbxTUnit.ValueMember = "id";
            cbxTUnit.Text = "";
            cbxTUnit.SelectedIndex = -1;
        }
        #endregion

        #region setClient()为客户赋值
        /*
         * 方法名称： setClient()
         * 方法功能描述：为客户赋值；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-13
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setClient()
        {
            cbxClient.DataSource = stockORLogic.SearchClient();
            cbxClient.DisplayMember = "name";
            cbxClient.ValueMember = "id";
            cbxClient.Text = "";
            cbxClient.SelectedIndex = -1;
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

            cbxEquipment.DataSource = sIRLogic.SearchEquipmentNO();
            cbxEquipment.DisplayMember = "no";
            cbxEquipment.ValueMember = "id";
            cbxEquipment.Text = "";
            cbxEquipment.SelectedIndex = -1;
        }
        #endregion

        #region 取出产品出库台帐查询条件
        /*
         * 方法名称： getPara()
         * 方法功能描述：取出产品出库台帐查询条件；
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
            pkId = 0; 
            pnId = 0; 
            pmId = 0;
            #region 取出查询条件
            // 取出产品ID;
            if (!cbxOPkind.Text.Trim().Equals(""))
            {
                pkId = Convert.ToInt32(this.cbxOPkind.SelectedValue.ToString());
            }
            if (!cbxOPname.Text.Trim().Equals(""))  
            {
                pnId = Convert.ToInt32(this.cbxOPname.SelectedValue.ToString());
                if (!cbxOPmodle.Text.Trim().Equals(""))   
                {
                    pmId = Convert.ToInt32(this.cbxOPmodle.SelectedValue.ToString());
                    stockORClass.Pid = (long)pLogic.PSearchID(pnId, pmId);
                }
                else
                {
                    stockORClass.Pid = 0; 
                }
            }
            else
            {
                stockORClass.Pid = 0;
            }

            // 取出时间;
            if (checkBegin.Checked)
            {
                stockORClass.BeginTime = Convert.ToDateTime(dtpOBegin.Text).ToString("yyyy-MM-dd");
            }
            else
            {
                stockORClass.BeginTime = "";
            }
            if (checkEnd.Checked)      
            {
                stockORClass.EndTime = Convert.ToDateTime(dtpOEnd.Text).ToString("yyyy-MM-dd");
            }
            else
            {
                stockORClass.EndTime = "";
            }
            // 取出车牌号码;
            if (!cbxVoiture.Text.Trim().Equals(""))  
            {
                stockORClass.Voitureid = Convert.ToInt32(this.cbxVoiture.SelectedValue.ToString());
            }
            else
            {
                stockORClass.Voitureid = 0;
            }
            // 取出运输公司;
            if (!cbxTUnit.Text.Trim().Equals(""))  
            {
                stockORClass.Transportid = Convert.ToInt32(this.cbxTUnit.SelectedValue.ToString());
            }
            else
            {
                stockORClass.Transportid = 0;
            }
            // 取出客户;
            if (!cbxClient.Text.Trim().Equals("")) 
            {
                stockORClass.Clientid = Convert.ToInt32(this.cbxClient.SelectedValue.ToString());
            }
            else
            {
                stockORClass.Clientid = 0;
            }
            // 取出审核、审批状态；
            if (!string.IsNullOrEmpty(cbx_state.Text.Trim()))
            {
                stockORClass.State = cbx_state.Text.Trim();
            }
            else
            {
                stockORClass.State = "";
            } 

            #endregion
        }
        #endregion

        #region 取出产品入库台帐查询条件
        /*
         * 方法名称： getInPara()
         * 方法功能描述：取出产品入库台帐查询条件；
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
            pkId = 0;
            pnId = 0;
            pmId = 0;
            // 取出产品ID;
            if (!cbxkind.Text.Trim().Equals(""))
            {
                pkId = Convert.ToInt32(this.cbxkind.SelectedValue.ToString());
            }
            if (!cbxName.Text.Trim().Equals(""))  
            {
                pnId = Convert.ToInt32(this.cbxName.SelectedValue.ToString());
                if (!cbxmodel.Text.Trim().Equals("")) 
                {
                    pmId = Convert.ToInt32(this.cbxmodel.SelectedValue.ToString());
                    stockIrClass.Pid = (long)pLogic.PSearchID(pnId, pmId);
                }
                else
                {
                    stockIrClass.Pid = 0;
                }
            }
            else
            {
                stockIrClass.Pid = 0;
            }

            // 取出时间;
            if (chkBegin.Checked)   
            {
                stockIrClass.BeginTime = Convert.ToDateTime(dtpBegin.Text).ToString("yyyy-MM-dd");
            }
            else
            {
                stockIrClass.BeginTime = "";
            }
            if (chkEnd.Checked)
            {
                stockIrClass.EndTime = Convert.ToDateTime(dtpEnd.Text).ToString("yyyy-MM-dd");
            }
            else
            {
                stockIrClass.EndTime = "";
            }
          
            //取出设备;
            if (!cbxEquipment.Text.Trim().Equals(""))  
            {
                stockIrClass.Equipmentid= Convert.ToInt32(this.cbxEquipment.SelectedValue.ToString());
            }
            else
            {
                stockIrClass.Equipmentid = 0;
            }
            // 取出审核、审批状态；
            if (!string.IsNullOrEmpty(cbxState.Text.Trim()))  
            {
                stockIrClass.State = cbxState.Text.Trim();
            }
            else
            {
                stockIrClass.State = "";
            }
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
            cbxkind.Text = "";    
            cbxkind.SelectedIndex = -1;
            cbxName.Text = "";
            cbxName.SelectedIndex = -1;
            cbxmodel.Text = "";
            cbxmodel.SelectedIndex = -1;
            cbxVoiture.Text = "";
            cbxVoiture.SelectedIndex = -1;
            cbxClient.Text = "";
            cbxClient.SelectedIndex = -1;
            cbxTUnit.Text = "";
            cbxTUnit.SelectedIndex = -1;

            cbxOPkind.Text = "";
            cbxOPkind.SelectedIndex = -1;
            cbxOPname.Text = "";
            cbxOPname.SelectedIndex = -1;
            cbxOPmodle.Text = "";
            cbxOPmodle.SelectedIndex = -1;

            cbxEquipment.Text = "";
            cbxEquipment.SelectedIndex = -1;
        }
        #endregion

        private void FrmStockOutR_Load(object sender, EventArgs e)
        {
            // 初始化 产品出库DataGridView;
            setOutDataGridView();
            setINDataGridView();
            // 初始化车牌号码;
            setVoiture();
            // 初始化运输公司;
            setCbxTUnit();
            // 初始化客户信息;
            setClient();
            // 初始化产品种类;
            SetPKind();
            // 初始化设备编号;
            setEquipment();

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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            setINDataGridView();
            ClearAction();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab.Name == tabPage1.Name)
                {
                    groupBox2.Visible = false;
                    groupBox1.Visible = true;
                    setINDataGridView();
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

        private void checkBegin_CheckedChanged(object sender, EventArgs e)
        {
            // 控制日期控件是否可用;
            if (checkBegin.Checked)
            {
                dtpOBegin.Enabled = true;
            }
            else
            {
                dtpOBegin.Enabled = false;
            }
        }

        private void checkOut_CheckedChanged(object sender, EventArgs e)
        {
            // 控制日期控件是否可用;
            if (checkEnd.Checked)
            {
                dtpOEnd.Enabled = true;
            }
            else
            {
                dtpOEnd.Enabled = false;
            }
        }

        private void cbxkind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 选择产品种类后,名称联动
            int pkId;

            if (cbxkind.SelectedValue == null) 
            {
                pkId = 0;
            }
            else
            {
                pkId = Convert.ToInt32(cbxkind.SelectedValue.ToString());   
            }

            cobBoBoxLinkage(cbxName, pkId); 
        }

        private void cbxOPkind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //选择产品种类后,名称联动;
            int pkId;

            if (cbxOPkind.SelectedValue == null)
            {
                pkId = 0;
            }
            else
            {
                pkId = Convert.ToInt32(cbxOPkind.SelectedValue.ToString());
            }

            cobBoBoxLinkage(cbxOPname, pkId);  
        }

        private void cbxOPname_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //选择产品名称后,规格联动;
            int pnId;
            if (cbxOPname.SelectedValue == null)
            {
                pnId = 0;
            }
            else
            {
                pnId = Convert.ToInt32(cbxOPname.SelectedValue.ToString());
            }

            setCbxPmodel(cbxOPmodle, pnId);
        }

        private void cbxName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //选择产品名称后,规格联动
            int pnId;
            if (cbxName.SelectedValue == null)
            {
                pnId = 0;
            }
            else
            {
                pnId = Convert.ToInt32(cbxName.SelectedValue.ToString());
            }

            setCbxPmodel(cbxmodel, pnId);
        }

        private void btnPOQuery_Click(object sender, EventArgs e)
        {
            //查询产品出库信息;
            getPara();
            setOutDataGridView();
            ClearAction();
        }

        private void chkBegin_CheckedChanged(object sender, EventArgs e)
        {
            // 控制日期控件是否可用;
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
            // 控制日期控件是否可用;
            if (chkEnd.Checked)
            {
                dtpEnd.Enabled = true; 
            }
            else
            {
                dtpEnd.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmProductInDepot frmProductInDepot = new FrmProductInDepot();
            frmProductInDepot.ShowDialog();
        }

        private void btnAssess_Click(object sender, EventArgs e)
        {
            if (dgvPstockIn.CurrentRow != null)
            {
                if (dgvPstockIn.CurrentRow.Cells["流水号"].Value.ToString().Equals(""))
                {
                    return;
                }
                if (!dgvPstockIn.CurrentRow.Cells["审核"].Value.ToString().Equals(""))
                {
                    MessageBox.Show("该记录已审核完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var estate = assess();
                if (estate.ToString().Equals("Yes"))
                {
                    long id = Convert.ToInt64(dgvPstockIn.CurrentRow.Cells[0].Value.ToString());
                    if (stockORLogic.Proudct_Assess("I", id, this.userName))
                    {
                        MessageBox.Show("审核成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setINDataGridView();
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
            if (dgvPstockIn.CurrentRow != null)
            {
                if (dgvPstockIn.CurrentRow.Cells["流水号"].Value.ToString().Equals(""))
                {
                    return;
                }
                if (!dgvPstockIn.CurrentRow.Cells["审批"].Value.ToString().Equals(""))
                {
                    MessageBox.Show("该记录已审批完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dgvPstockIn.CurrentRow.Cells["审核"].Value.ToString().Equals(""))
                {
                    MessageBox.Show("该记录未审核，请审核后在进行审批操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                long id = Convert.ToInt64(dgvPstockIn.CurrentRow.Cells[0].Value.ToString());
                var estate = checkup();
                if (estate.ToString().Equals("Yes"))
                {
                    if (stockORLogic.Proudct_Checkup("I", id, this.userName))
                    {
                        MessageBox.Show("审批成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setINDataGridView();
                    }
                }
                else
                {
                    var i = stockORLogic.Proudct_Assess("I", id, "NULL");
                    setINDataGridView();
                }
            }
            else
            {
                MessageBox.Show("未选中任何一条记录，请选中一条记录后进行审核操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 执行完审批操作后,执行计算库存的方法
            var s = ssl.Stock_Product();
        }

        private void btn_assess_Click(object sender, EventArgs e)
        {
            if (dgvPstockOut.CurrentRow != null)  
            {
                if (dgvPstockOut.CurrentRow.Cells["流水号"].Value.ToString().Equals(""))
                {
                    return;
                }
                if (!dgvPstockOut.CurrentRow.Cells["审核"].Value.ToString().Equals(""))
                {
                    MessageBox.Show("该记录已审核完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var estate = assess();
                if (estate.ToString().Equals("Yes"))
                {
                    long id = Convert.ToInt64(dgvPstockOut.CurrentRow.Cells[0].Value.ToString());
                    if (stockORLogic.Proudct_Assess("O", id, this.userName))
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

        private void btn_checkup_Click(object sender, EventArgs e)
        {
            if (dgvPstockOut.CurrentRow != null)
            {
                if (dgvPstockOut.CurrentRow.Cells["流水号"].Value.ToString().Equals(""))
                {
                    return;
                }
                if (!dgvPstockOut.CurrentRow.Cells["审批"].Value.ToString().Equals(""))
                {
                    MessageBox.Show("该记录已审批完，请选择其它记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dgvPstockOut.CurrentRow.Cells["审核"].Value.ToString().Equals(""))
                {
                    MessageBox.Show("该记录未审核，请审核后在进行审批操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                long id = Convert.ToInt64(dgvPstockOut.CurrentRow.Cells[0].Value.ToString());
                var estate = checkup();
                if (estate.ToString().Equals("Yes"))
                {
                    if (stockORLogic.Proudct_Checkup("O", id, this.userName))
                    {
                        MessageBox.Show("审批成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setOutDataGridView();
                    }
                }
                else
                {
                    var i = stockORLogic.Proudct_Assess("O", id, "NULL");
                    setOutDataGridView();
                }
            }
            else
            {
                MessageBox.Show("未选中任何一条记录，请选中一条记录后进行审核操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 执行完审批操作后,执行计算库存的方法
            var s = ssl.Stock_Product();
        }

        private void btn_print_in_Click(object sender, EventArgs e)
        {
            ReportStorageClass storage_report = new ReportStorageClass();
            storage_report.RunProductInAccount(sqlWhere);
        }

        private void btn_print_out_Click(object sender, EventArgs e)
        {
            ReportStorageClass storage_report = new ReportStorageClass();
            storage_report.RunProductOutAccount(stockORClass, pkId, pnId);
        }

    }
}
