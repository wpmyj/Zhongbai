/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：FrmPurchasingContractNew.cs
     * 文件功能描述：采购合同新增
     *
     * 创建人：付中华
     * 创建时间：2009-3-5
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using System.Data.SqlClient;

namespace DasherStation.stock
{
    public partial class FrmPurchasingContractNew : common.BaseForm 
    {
        public FrmPurchasingContractNew()
        {
            InitializeComponent();
        }
        DataSet ds = null;
        stockContractLogic stockContractLogic = new stockContractLogic();
        purchaseScheDetaillogic purchaseSchedetaillogic = new purchaseScheDetaillogic();
        stockContractDetailLogic stockContractDetailLogic = new stockContractDetailLogic();

        private void FrmPurchasingContractNew_Load(object sender, EventArgs e)
        {
            #region//初始化供应商
            cbm_providerInfo.DataSource = stockContractLogic.initialProviderLogin();
            cbm_providerInfo.DisplayMember = "name";
            cbm_providerInfo.ValueMember = "id";
            cbm_providerInfo.SelectedIndex = -1;
            #endregion
            #region//初始化合同制作人
            cmb_personnelInfo.DataSource = stockContractLogic.initialMakerLogic();
            cmb_personnelInfo.DisplayMember = "name";
            cmb_personnelInfo.ValueMember = "id";
            cmb_personnelInfo.SelectedIndex = -1;
            #endregion           
            detailBinding();
           
        }

        private void cbm_providerInfo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string provider = this.cbm_providerInfo.Text.ToString();
            if (provider != "")
            {
                if (isExist(provider))
                { }
                else
                {
                    comboBox1.Items.Add(provider);
                }

            }
            
            int providerId = Convert.ToInt32(this.cbm_providerInfo.SelectedValue.ToString());
            #region//供应商选中后将其id值取出获取材料的种类信息
            cbm_materialKind.DataSource = stockContractLogic.initialSortLogic(providerId);
            cbm_materialKind.DisplayMember = "sort";
            cbm_materialKind.ValueMember = "id";
            cbm_materialKind.SelectedIndex = -1;
            if (cbm_materialInformation.SelectedIndex >= 0)
            { cbm_materialInformation.SelectedIndex = -1; }
            if (cbm_materialModel.SelectedIndex >= 0)
            { cbm_materialModel.SelectedIndex = -1; }
            int pkid, pnid;
            if (cbm_materialKind.SelectedValue == null)
            {
                pkid = 0;
                return;
            }
            pkid = Convert.ToInt32(cbm_materialKind.SelectedValue.ToString());
            cbm_materialInformation.DataSource = purchaseSchedetaillogic.materialNamelogic(pkid,providerId);
            cbm_materialInformation.DisplayMember = "name";
            cbm_materialInformation.ValueMember = "id";
            cbm_materialInformation.SelectedIndex = -1;
            if (cbm_materialInformation.SelectedValue == null)
            {
                pnid = 0;
                return;
            }
            pnid = Convert.ToInt32(cbm_materialInformation.SelectedValue.ToString());
            cbm_materialModel.DataSource = purchaseSchedetaillogic.materialModellogic(pnid, providerId);
            cbm_materialModel.DisplayMember = "model";
            cbm_materialModel.ValueMember = "id";
            cbm_materialModel.SelectedIndex = -1;
            #endregion
            
        }
        // 向combobox中插入数据时要判断是否已经存在了如果存在则不加入不存在加入
        private bool isExist(string providerName)
        {
            bool exist = false;
            foreach (Object obj in comboBox1.Items)
            {
                if (obj.ToString() == providerName)
                {
                    exist = true;
                }
            }
            return exist;
        }

        private void cbm_materialKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            #region//种类是否被选中决定名称和规格
            if (cbm_providerInfo.SelectedValue == null)
                return;
            int providerId = Convert.ToInt32(this.cbm_providerInfo.SelectedValue.ToString());
            int pkid, pnid;
            if (cbm_materialKind.SelectedValue == null)
            {
                pkid = 0;
                cbm_materialInformation.SelectedIndex = -1;
                return;
            }
            pkid = Convert.ToInt32(cbm_materialKind.SelectedValue.ToString());
            cbm_materialInformation.DataSource = purchaseSchedetaillogic.materialNamelogic(pkid, providerId);
            cbm_materialInformation.DisplayMember = "name";
            cbm_materialInformation.ValueMember = "id";
            cbm_materialInformation.Text = "";
            cbm_materialInformation.SelectedIndex = -1;
            if (cbm_materialInformation.SelectedValue == null)
            {
                pnid = 0;
                cbm_materialModel.Text = "";
                cbm_materialModel.SelectedIndex = -1;
                return;
            }
            pnid = Convert.ToInt32(cbm_materialInformation.SelectedValue.ToString());
            cbm_materialModel.DataSource = purchaseSchedetaillogic.materialModellogic(pnid, providerId);
            cbm_materialModel.DisplayMember = "model";
            cbm_materialModel.ValueMember = "id";
            cbm_materialModel.SelectedIndex = -1;
            #endregion 
        }

        private void cbm_materialInformation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            #region//名称是否被选中决定规格的值
            if (cbm_providerInfo.SelectedValue == null)
                return;
            int providerId = Convert.ToInt32(this.cbm_providerInfo.SelectedValue.ToString());
            int pnid;
            if (cbm_materialInformation.SelectedValue == null)
            {
                pnid = 0;
                cbm_materialModel.SelectedIndex = -1;
                return;
            }
            pnid = Convert.ToInt32(cbm_materialInformation.SelectedValue.ToString());
            cbm_materialModel.DataSource = purchaseSchedetaillogic.materialModellogic(pnid, providerId);
            cbm_materialModel.DisplayMember = "model";
            cbm_materialModel.ValueMember = "id";
            cbm_materialModel.Text = "";
            cbm_materialModel.SelectedIndex = -1;
            #endregion
        }
       // 采购合同明细添加表信息绑定datagridview
        private void detailBinding()
        {
            ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("mid");
            dt.Columns.Add("sort");
            dt.Columns.Add("materialInformation");
            dt.Columns.Add("materialModel");
            dt.Columns.Add("quantity");
            dt.Columns.Add("unitPrice");
            dt.Columns.Add("inputMan");
            dt.Columns.Add("inputDate");
            dt.Columns.Add("finishMark");

            ds.Tables.Add(dt);
            dgv_detail.DataSource = ds.Tables[0];

        }

        private void btn_detailAdd_Click(object sender, EventArgs e)
        {
            #region//对所有明细信息进行校验
            if (!Check.CheckEmpty(cbm_materialKind.Text.ToString()))
            {
                MessageBox.Show("材料种类不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbm_materialKind.Focus();
                return;
            }
            if (!Check.CheckEmpty(cbm_materialInformation.Text.ToString()))
            {
                MessageBox.Show("材料名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbm_materialInformation.Focus();
                return;
            }
            if (!Check.CheckEmpty(cbm_materialModel.Text.ToString()))
            {
                MessageBox.Show("材料规格不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbm_materialModel.Focus();
                return;
            }
            if (!Check.CheckEmpty(txtquantity.Text.ToString()))
            {
                MessageBox.Show("采购数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtquantity.Focus();
                return;
            }
            else
            {
                if (!Check.CheckFloat(txtquantity.Text.ToString()))
                {
                    MessageBox.Show("采购总数量含非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtquantity.Clear();
                    txtquantity.Focus();
                    return;
                }
            }
            if (!Check.CheckEmpty(txtunitPrice.Text.ToString()))
            {
                MessageBox.Show("采购单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtunitPrice.Focus();
                return;
            }
            else
            {
                if (!Check.CheckFloat(txtunitPrice.Text.ToString()))
                {
                    MessageBox.Show("采购单价含有非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtunitPrice.Clear();
                    txtunitPrice.Focus();
                    return;
                }
            }
           
            #endregion
            // 处理两条明细相同时给予提示信息
            if (dgv_detail.Rows.Count != 0)
            {
                foreach (DataGridViewRow dgvr in dgv_detail.Rows)
                {
                    if (dgvr.Cells["sort"].Value.ToString() == cbm_materialKind.Text.ToString() &&
                        dgvr.Cells["materialInformation"].Value.ToString() == cbm_materialInformation.Text.ToString() &&
                        dgvr.Cells["materialModel"].Value.ToString() == cbm_materialModel.Text.ToString())
                    {
                        if (MessageBox.Show("确定添加相同种类名称规格的材料合同明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        { }
                        else
                        {return;}
                    }
                }
            }
            MaterialClass materialmodel = new MaterialClass();
            materialmodel.mnId = Convert.ToInt32(this.cbm_materialInformation.SelectedValue.ToString());
            materialmodel.mmId = Convert.ToInt32(this.cbm_materialModel.SelectedValue.ToString());

            Indent indent =new Indent();
           
            indent.mId = (long)(purchaseSchedetaillogic.getObj(materialmodel).id);
            indent.inputMan = this.UserName;
            indent.inputDate = DateTime.Now;
            indent.unitPrice = decimal.Parse(this.txtunitPrice.Text.Trim());            
            indent.quantity = decimal.Parse(this.txtquantity.Text.Trim());     
            stockContractDetailLogic.indentNewRow(indent, ds.Tables[0], cbm_materialKind.Text, cbm_materialInformation.Text, cbm_materialModel.Text);
            
            clearComboboxAndTextBox();
            caleTotalMoneyAndTotalWeight();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            #region//对主表信息的所有内容进行校验
            if (!Check.CheckEmpty(txtname.Text.ToString()))
            {
                MessageBox.Show("合同名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Focus();
                return;
            }
            if (!Check.CheckQueryIsEmpty(txtname.Text.ToString()))
            {
                MessageBox.Show("合同名称不能是非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Focus();
                return;
            }
            if (!Check.CheckEmpty(cbm_providerInfo.Text.ToString()))
            {
                MessageBox.Show("供应商名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbm_providerInfo.Focus();
                return;
            }
            if (!Check.CheckEmpty(comboBox1.Text.ToString()))
            {
                MessageBox.Show("运输方不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
            if (!Check.CheckFloat(txtsum.Text.ToString()))
            {
                MessageBox.Show("预计总金额不能为空,应添加合同明细信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsum.Focus();
                return;
            }
            //if (!Check.CheckEmpty(txtsquareMode.Text.ToString()))
            //{
            //    MessageBox.Show("结算方式不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtsquareMode.Focus();
            //    return;
            //}
            if((!rdb2.Checked)&&(!rdb1.Checked))
            {
                MessageBox.Show("必须选择是哪种合同！");
            }
            if (rdb2.Checked)
            {
                if (!Check.CheckEmpty(txtno.Text))
                {
                    MessageBox.Show("主合同编号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Check.CheckQueryIsEmpty(txtno.Text))
                {
                    MessageBox.Show("主合同编号不能含有非法字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Check.CheckEmpty(textBox1.Text))
                {
                    MessageBox.Show("补充合同编号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);                  
                    return;
                }
                if (!Check.CheckQueryIsEmpty(textBox1.Text))
                {
                    MessageBox.Show("补充合同编号不能含有非法字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (rdb1.Checked)
            {
                if (!Check.CheckEmpty(textBox2.Text))
                {
                    MessageBox.Show("合同编号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Check.CheckQueryIsEmpty(textBox2.Text))
                {
                    MessageBox.Show("合同编号不能含有非法字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            

            #endregion
            if (dgv_detail.RowCount != 0)
            {
                saveContract();
            }
            else
            {
                if (MessageBox.Show("你还没有添加采购合同的详细信息", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)                 
                    return;
            }
        }
        //保存合同
        private void saveContract()
        {


            stockContract stockContract = GetStockContract();
            List<Indent> list = GetIndent();


            if (stockContractDetailLogic.StockContractAdd(stockContract, list))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
           

        }
        //采购合同主表信息
        private stockContract GetStockContract()
        {           
            stockContract stockContract = new stockContract();            
            // 分一般合同和补充合同两种情况
            if (rdb1.Checked)
            {
                stockContract.no = textBox2.Text.Trim();
            }
            else
            {
                stockContract.no = textBox1.Text.Trim();
            }
            //stockContract.no = txtno.Text.Trim();
            stockContract.name = txtname.Text.Trim();
            stockContract.piId = int.Parse(cbm_providerInfo.SelectedValue.ToString());
            if (cmb_personnelInfo.Text != "")
            {
                stockContract.producer = cmb_personnelInfo.Text;
            }            
            stockContract.sum = decimal.Parse(txtsum.Text.Trim());          
            stockContract.minQuantity = decimal.Parse(txtminQuantity.Text.Trim());
            stockContract.no2 = txtno2.Text.Trim();
            stockContract.startDate = dtpstartDate.Value;
            stockContract.endDate = dtpendDate.Value;
            if (txtsquareMode.Text.Trim() != "")
            {
                stockContract.squareMode = txtsquareMode.Text.Trim();
            }
            stockContract.conveyancer = comboBox1.Text.Trim();
            // 如果是一般合同则parentId存储0 是补充合同parentId返回主合同编号的id值
            if (rdb1.Checked)
            {
                stockContract.parentId = 0;
            }
            else
            {
                stockContract.parentId = Convert.ToInt32(txtno.SelectedValue.ToString());
            }
            return stockContract;
        }
        //采购合同明细信息
        private List<Indent> GetIndent()
        {
            Indent indent = null;
            List<Indent> list = new List<Indent>();
            foreach (DataGridViewRow dgvr in dgv_detail.Rows)
            {
                indent = new Indent();
                indent.mId = int.Parse(dgvr.Cells["mid"].Value.ToString());                
                indent.quantity = decimal.Parse(dgvr.Cells["quantity"].Value.ToString());
                indent.unitPrice = decimal.Parse(dgvr.Cells["unitPrice"].Value.ToString());
                indent.inputMan = dgvr.Cells["inputMan"].Value.ToString();
                indent.inputDate = DateTime.Parse(dgvr.Cells["inputDate"].Value.ToString());

                list.Add(indent);

            }

            return list;
        }

        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb2.Checked)
            {
                label1.Text = "主合同编号";
                label12.Text = "补充合同名称";
                label16.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = false;
                txtno.Visible = true;

                txtno.DataSource = stockContractLogic.initialContractNo();
                txtno.DisplayMember = "no";
                txtno.ValueMember = "id";
                txtno.SelectedIndex = -1;
                
                cbm_providerInfo.TextChanged += cbm_providerInfo_TextChanged;
                
            }
        }

        private object cbm_providerInfo_TextChanged()
        {
            throw new NotImplementedException();
        }

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb1.Checked)
            {
                label1.Text = "合同编号";
                textBox2.Visible = true;
                txtno.Visible = false;
                //label8.Visible = false;
                textBox1.Visible = false;
                label12.Text = "合同名称";
                label16.Visible = false;

                cbm_providerInfo.Enabled = true;
                cbm_providerInfo.SelectedIndex = -1;

                cbm_providerInfo.TextChanged -= cbm_providerInfo_TextChanged;
            }
            if ((rdb1.Checked) &&(txtno.DataSource !=null))
            {
                txtno.DataSource = null;               
            }            
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgv_detail.SelectedRows)
            {
                this.dgv_detail.Rows.Remove(dgvr);
            }
            caleTotalMoneyAndTotalWeight();
            if ((dgv_detail.RowCount == 0))
            {
                txtsum.Clear();
                txtminQuantity.Clear();
            }
        }
        private void clearComboboxAndTextBox()
        {
            txtunitPrice.Clear();
            txtquantity.Clear();
            cbm_materialKind.SelectedIndex = -1;
            cbm_materialInformation.SelectedIndex = -1;
            cbm_materialModel.SelectedIndex = -1;
        }
        // 采购合同明细离开采购数量时进行校验
        private void txtquantity_Leave(object sender, EventArgs e)
        {
            //if (!Check.CheckEmpty(txtquantity.Text.ToString()))
            //{
            //    MessageBox.Show("采购数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtquantity.Focus();
            //    return;
            //}
            //else
            //{
            //    if (!Check.CheckFloat(txtquantity.Text.ToString()))
            //    {
            //        MessageBox.Show("采购数量含非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtquantity.Clear();
            //        txtquantity.Focus();
            //        return;
            //    }
            //}
        }
        // 采购合同明细离开采购单价时进行校验
        private void txtunitPrice_Leave(object sender, EventArgs e)
        {
            //if (!Check.CheckEmpty(txtunitPrice.Text.ToString()))
            //{
            //    MessageBox.Show("采购单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtunitPrice.Focus();
            //    return;
            //}
            //else
            //{
            //    if (!Check.CheckFloat(txtunitPrice.Text.ToString()))
            //    {
            //        MessageBox.Show("采购单价含有非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtunitPrice.Clear();
            //        txtunitPrice.Focus();
            //        return;
            //    }
            //}
        }

        #region// 计算采购合同上的预计总额=所有采购单价和数量相乘的累加 采购总量是所有采购数量的累加
        private void caleTotalMoneyAndTotalWeight()
        {
            if (dgv_detail.RowCount != 0)
            {
                decimal totalWeight = 0;
                decimal totalMoney = 0;
                foreach (DataGridViewRow row in dgv_detail.Rows)
                {
                    totalWeight += decimal.Parse(row.Cells["quantity"].Value.ToString());
                    totalMoney += decimal.Parse(row.Cells["quantity"].Value.ToString()) * decimal.Parse(row.Cells["unitPrice"].Value.ToString());        
                }
                txtsum.Text = Convert.ToString(totalMoney);
                txtminQuantity.Text = Convert.ToString(totalWeight);
            }
        }
        #endregion

        private void txtname_Leave(object sender, EventArgs e)
        {
            // 判断合同名称在数据库表中是否已经存在
            bool existName=false;
            if (txtname.Text.Trim() != "")
            {
                string contractName = txtname.Text.Trim();
                existName = stockContractDetailLogic.compareContractNameLogic(contractName);
                if (existName)
                {
                    MessageBox.Show("此合同名称已经存在,请重新输入合同名称");
                    txtname.Clear();
                    //txtname.Focus();
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            // 判断合同编号在数据库表中是否已经存在
            bool existName=false;
            if (textBox2.Text.Trim()!= "")
            {
                string contractNo = textBox2.Text.Trim();
                existName = stockContractDetailLogic.compareContractNoLogic(contractNo);
                if (existName)
                {
                    MessageBox.Show("此合同编号已经存在,请重新输入合同编号");
                    textBox2.Clear();                    
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            // 判断合同编号在数据库表中是否已经存在
            bool existName;
            if (textBox1.Text.Trim() != "")
            {
                string contractNo = textBox1.Text.Trim();
                existName = stockContractDetailLogic.compareContractNoLogic(contractNo);
                if (existName)
                {
                    MessageBox.Show("此补充合同编号已经存在,请重新输入补充合同编号");
                    textBox1.Clear();
                    //textBox1.Focus();
                }
            }
        }
        // 当为主合同编号时 被选中此时运输单位就应该默认上去同时不允许更改
        private void txtno_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbm_providerInfo.Enabled = true;
            if (txtno.SelectedValue.ToString() != "")
            {
                cbm_providerInfo.Text = stockContractLogic.findConveyAncer(Convert.ToInt32(txtno.SelectedValue.ToString())).Rows[0][0].ToString();
            }
            cbm_providerInfo.Enabled = false;
            if (cbm_providerInfo.Text != "")
            {
                string provider = this.cbm_providerInfo.Text.ToString();
                if (provider != "")
                {
                    if (isExist(provider))
                    { }
                    else
                    {
                        comboBox1.Items.Add(provider);
                    }
                }
                int providerId = stockContractDetailLogic.findProviderId(cbm_providerInfo.Text);
                #region//供应商选中后将其id值取出获取材料的种类信息
                cbm_materialKind.DataSource = stockContractLogic.initialSortLogic(providerId);
                cbm_materialKind.DisplayMember = "sort";
                cbm_materialKind.ValueMember = "id";
                cbm_materialKind.SelectedIndex = -1;
                int pkid, pnid;
                if (cbm_materialKind.SelectedValue == null)
                {
                    pkid = 0;
                    return;
                }
                pkid = Convert.ToInt32(cbm_materialKind.SelectedValue.ToString());
                cbm_materialInformation.DataSource = purchaseSchedetaillogic.materialNamelogic(pkid);
                cbm_materialInformation.DisplayMember = "name";
                cbm_materialInformation.ValueMember = "id";
                cbm_materialInformation.SelectedIndex = -1;
                if (cbm_materialInformation.SelectedValue == null)
                {
                    pnid = 0;
                    return;
                }
                pnid = Convert.ToInt32(cbm_materialInformation.SelectedValue.ToString());
                cbm_materialModel.DataSource = purchaseSchedetaillogic.materialModellogic(pnid);
                cbm_materialModel.DisplayMember = "model";
                cbm_materialModel.ValueMember = "id";
                cbm_materialModel.SelectedIndex = -1;
            }
            #endregion

        }

        private void cbm_providerInfo_TextChanged(object sender, EventArgs e)
        {
            //string provider = this.cbm_providerInfo.Text.ToString();
            //if (provider != "")
            //{
            //    comboBox1.Items.Add(provider);
            //}
           
        }








    }
}
