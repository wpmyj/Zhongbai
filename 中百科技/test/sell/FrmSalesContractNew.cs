using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using DasherStation.system;
using DasherStation.transport;

namespace DasherStation.sell
{
    public partial class FrmSalesContractNew : BaseForm
    {
        public FrmSalesContractNew()
        {
            InitializeComponent();
        }

        AddSalesContractLogic aSCLogic = new AddSalesContractLogic();
        ProductLogic pLogic = new ProductLogic();
        FormHelper formHelper = new FormHelper();
        SalesContractClass sCClass = new SalesContractClass();
        DataSet ds = new DataSet();

        #region SetPara()插入时提取销售合同相关内容
        /*
      * 方法名称： SetPara()
      * 方法功能描述：插入、更新时提取文本框、下拉列表框内容；
      *
      * 创建人：冯雪
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public void SetPara()
        {
            //合同名称；
            sCClass.Name = txtName.Text.Trim();
            //合同编号；
            if (rbtnHT.Checked)
            {
                sCClass.No = txtScNo.Text.Trim();
            }
            else
            {
                sCClass.No = txtSupplycNo.Text.Trim();
            }
            //客户信息；
            sCClass.CiId = Convert.ToInt32(cbxCiId.SelectedValue.ToString());
            //合同制作人信息；
            sCClass.Producer = cbxProducer.Text.Trim();
            //预计金额；
            sCClass.Sum = decimal.Parse(this.txtSum.Text.Trim());
            
            //如果不是补充合同,则输入合同编号;
            if (rbtnHT.Checked)
            {
                sCClass.ParentId = 0;
            }
            else
            {
                sCClass.ParentId = Convert.ToInt32(cbxScNo.SelectedValue.ToString());
            }

            sCClass.StartDate = dtpEndDate.Value ;
            sCClass.EndDate =  dtpStartDate.Value;            
            if (rbtnHT.Checked)
            {
                sCClass.ParentId = 0;
            }
            else
            {
                sCClass.ParentId = Convert.ToInt32(cbxScNo.SelectedValue.ToString());
            }
            sCClass.InputDate = DateTime.Now;
            sCClass.InputMan = this.userName;
        }
        #endregion

        #region ClearAction() 清空文本框、下拉列表框内容;
        private void ClearAction()
        {
            txtUnitPrice.Clear();
            txtQuantity.Clear();

            cbxPKind.SelectedIndex = -1;
            cbxPName.SelectedIndex = -1;
            cbxPModel.SelectedIndex = -1;
        }
        #endregion

        #region 销售合同明细添加表信息绑定datagridview
        /*
      * 方法名称： detailBinding()
      * 方法功能描述：销售合同明细添加表信息绑定datagridview；
      *
      * 创建人：冯雪
      * 创建时间：2009-03-07
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void detailBinding()
        {
            ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("pid");
            dt.Columns.Add("sort");
            dt.Columns.Add("name");
            dt.Columns.Add("model");
            dt.Columns.Add("quantity");
            dt.Columns.Add("unitPrice");
            dt.Columns.Add("inputMan");
            dt.Columns.Add("inputDate");
            dt.Columns.Add("finishMark");

            ds.Tables.Add(dt);
            dgvdetail.DataSource = ds.Tables[0];

        }
        #endregion

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
        private void setCbxPkind()
        {
            cbxPKind.DataSource = pLogic.InitialPKindComboBox();
            cbxPKind.DisplayMember = "产品种类";
            cbxPKind.ValueMember = "id";
            cbxPKind.Text = "";
            cbxPKind.SelectedIndex = -1;
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

            if (cbxPKind.SelectedValue == null)
            {
                pkId = 0;
            }
            else
            {
                pkId = Convert.ToInt32(cbxPKind.SelectedValue.ToString());
            }
            if (pLogic.InitialPNameComboBox(pkId).Rows.Count != 0)
            {
                cbxPName.DataSource = pLogic.InitialPNameComboBox(pkId);
                cbxPName.DisplayMember = "产品名称";
                cbxPName.ValueMember = "id";
                cbxPName.Text = "";
                cbxPName.SelectedIndex = -1;
            }
            else
            {
                cbxPName.DataSource = pLogic.InitialPNameComboBox(pkId);
            }
            cbxPModel.Text = "";
            cbxPModel.SelectedIndex = -1;
        }
        #endregion

        #region setCbxPmodel()选择产品名称后，规格联动
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
        private void setCbxPmodel()
        {
            int pnId;
            if (cbxPName.SelectedValue == null)
            {
                pnId = 0;
            }
            else
            {
                pnId = Convert.ToInt32(cbxPName.SelectedValue.ToString());
            }
            if (pLogic.InitialPModelComboBox(pnId).Rows.Count != 0)
            {
                cbxPModel.DataSource = pLogic.InitialPModelComboBox(pnId);
                cbxPModel.DisplayMember = "产品规格";
                cbxPModel.ValueMember = "id";
                cbxPModel.Text = "";
                cbxPModel.SelectedIndex = -1;
            }
            else
            {
                cbxPModel.DataSource = pLogic.InitialPModelComboBox(pnId);
            }
        }
        #endregion

        #region GetIndent()销售合同明细信息
        /*
         * 方法名称： GetIndent()
         * 方法功能描述：销售合同明细信息；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private List<InvoiceClass> GetIndent()
        {
            InvoiceClass invoiceClass = null;
            List<InvoiceClass> list = new List<InvoiceClass>();
            foreach (DataGridViewRow dgvr in dgvdetail.Rows) 
            {
                invoiceClass = new InvoiceClass();
                invoiceClass.PId = int.Parse(dgvr.Cells["pid"].Value.ToString());
                invoiceClass.Quantity = Convert.ToInt32(dgvr.Cells["quantity"].Value.ToString());
                invoiceClass.UnitPrice= decimal.Parse(dgvr.Cells["unitPrice"].Value.ToString());
                invoiceClass.InputMan= dgvr.Cells["inputMan"].Value.ToString();
                invoiceClass.InputDate = DateTime.Parse(dgvr.Cells["inputDate"].Value.ToString());

                list.Add(invoiceClass);

            }

            return list;
        }
        #endregion

        private void rbtnCHT_Click(object sender, EventArgs e)
        {
            //如果是补充合同,则选择合同编号;    
            //if (rbtnCHT.Checked)
            //    {
            //        cbxScNo.Visible = true;
            //        txtScNo.Visible = false;
            //        label1.Text = "主合同编号";
            //        label12.Text = "补充合同名称";
            //        txtSupplycNo.Visible = true;
            //        label8.Visible = true;

            //        //初始化销售合同编号；
            //        cbxScNo.DataSource = aSCLogic.InitialASalesComboBox(1);
            //        cbxScNo.DisplayMember = "no";
            //        cbxScNo.ValueMember = "id";

            //    }

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

        private void rbtnHT_CheckedChanged(object sender, EventArgs e)
        {
            //如果不是补充合同,则输入合同编号;
            if (rbtnHT.Checked)
            {
                cbxScNo.Visible = false;
                txtScNo.Visible = true;
                label1.Text = "合同编号";
                label12.Text = "合同名称";
                txtSupplycNo.Visible = false;
                label8.Visible = false;
                cbxCiId.Enabled = true;

                cbxCiId.Enabled = true;
                cbxCiId.SelectedIndex = -1;
            }
            if ((rbtnHT.Checked) && (cbxScNo.DataSource != null))
            {
                cbxScNo.DataSource = null;
            }      
                     
        }

        private void FrmSalesContractNew_Load(object sender, EventArgs e)
        {
            #region  初始化,产品种类、名称、规格，合同制作人，客户名称；
            setCbxPkind();
            cobBoBoxLinkage();

            // 合同制作人；
            // 2009-4-17 修改人：付中华 初始化合同制作人
            //cbxProducer.DataSource = aSCLogic.InitialASalesComboBox(2);
            cbxProducer.DataSource = aSCLogic.initialMakerLogic();
            cbxProducer.DisplayMember = "name";
            cbxProducer.ValueMember = "id";
            cbxProducer.SelectedIndex = -1;
            //cbxProducer.DisplayMember = "producer";

            // 客户名称；
            cbxCiId.DataSource = aSCLogic.SearchClient();
            cbxCiId.DisplayMember = "name";
            cbxCiId.ValueMember = "id";
            cbxCiId.SelectedIndex = -1;
            #endregion

            detailBinding();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 2009-4-17 修改人：付中华
            //对所有明细信息进行校验
            #region
            if (!Check.CheckEmpty(cbxPKind.Text.ToString()))
            {
                MessageBox.Show("产品种类不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxPKind.Focus();
                return;
            }
            if (!Check.CheckEmpty(cbxPName.Text.ToString()))
            {
                MessageBox.Show("产品名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxPName.Focus();
                return;
            }
            if (!Check.CheckEmpty(cbxPModel.Text.ToString()))
            {
                MessageBox.Show("产品规格不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxPModel.Focus();
                return;
            }
            if (!Check.CheckEmpty(txtQuantity.Text.ToString()))
            {
                MessageBox.Show("销售数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Focus();
                return;
            }
            else
            {
                if (!Check.CheckFloat(txtQuantity.Text.ToString()))
                {
                    MessageBox.Show("销售总数量含非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantity.Clear();
                    txtQuantity.Focus();
                    return;
                }
            }
            if (!Check.CheckEmpty(txtUnitPrice.Text.ToString()))
            {
                MessageBox.Show("销售单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUnitPrice.Focus();
                return;
            }
            else
            {
                if (!Check.CheckFloat(txtUnitPrice.Text.ToString()))
                {
                    MessageBox.Show("销售单价含有非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUnitPrice.Clear();
                    txtUnitPrice.Focus();
                    return;
                }
            }

            #endregion

            // 处理两条明细相同时给予提示信息
            if (dgvdetail.Rows.Count != 0)
            {
                foreach (DataGridViewRow dgvr in dgvdetail.Rows)
                {
                    if (dgvr.Cells["pkind"].Value.ToString() == cbxPKind.Text.ToString() &&
                        dgvr.Cells["pname"].Value.ToString() == cbxPName.Text.ToString() &&
                        dgvr.Cells["pmodle"].Value.ToString() == cbxPModel.Text.ToString())
                    {
                        if (MessageBox.Show("确定添加相同种类名称规格的产品合同明细吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        { }
                        else
                        { return; }
                    }
                }
            }
            //if (formHelper.inputCheck(groupBox2))
            //{
                InvoiceClass invoiceClass = new InvoiceClass();

                int pnid = Convert.ToInt32(this.cbxPName.SelectedValue.ToString());
                int pmid = Convert.ToInt32(this.cbxPModel.SelectedValue.ToString());

                // 提取销售合同明细内容；
                invoiceClass.PId = pLogic.PSearchID(pnid, pmid);
                invoiceClass.InputMan = this.userName;
                invoiceClass.InputDate = DateTime.Now;
                invoiceClass.UnitPrice = decimal.Parse(this.txtUnitPrice.Text.Trim());
                invoiceClass.Quantity = Convert.ToInt32(this.txtQuantity.Text.Trim());

                aSCLogic.DataGrilViedAddRow(invoiceClass, ds.Tables[0], cbxPKind.Text, cbxPName.Text, cbxPModel.Text);
                // 2009-4-17 添加调用方法
                caleTotalMoneyAndTotalWeight();
                ClearAction();
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 2009-4-17 修改人：付中华
            // 对主表信息的所有内容进行校验
            #region
            if (!Check.CheckEmpty(txtName.Text.ToString()))
            {
                MessageBox.Show("合同名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            if (!Check.CheckQueryIsEmpty(txtName.Text.ToString()))
            {
                MessageBox.Show("合同名称不能含有非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            if (!Check.CheckEmpty(cbxCiId.Text.ToString()))
            {
                MessageBox.Show("供应商名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxCiId.Focus();
                return;
            }
            if (!Check.CheckEmpty(comboBox1.Text.ToString()))
            {
                MessageBox.Show("运输方不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
            if (!Check.CheckFloat(txtSum.Text.ToString()))
            {
                MessageBox.Show("预计总额不能为空,应添加合同明细信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSum.Focus();
                return;
            }
            if ((!rbtnHT.Checked) && (!rbtnCHT.Checked))
            {
                MessageBox.Show("必须选择是哪种合同！");
            }
            if (rbtnCHT.Checked)
            {
                if (!Check.CheckEmpty(cbxScNo.Text))
                {
                    MessageBox.Show("主合同编号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Check.CheckQueryIsEmpty(cbxScNo.Text))
                {
                    MessageBox.Show("主合同编号不能含有非法字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Check.CheckEmpty(txtSupplycNo.Text))
                {
                    MessageBox.Show("补充合同编号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Check.CheckQueryIsEmpty(txtSupplycNo.Text))
                {
                    MessageBox.Show("补充合同编号不能含有非法字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (rbtnHT.Checked)
            {
                if (!Check.CheckEmpty(txtScNo.Text))
                {
                    MessageBox.Show("合同编号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!Check.CheckQueryIsEmpty(txtScNo.Text))
                {
                    MessageBox.Show("合同编号不能含有非法字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            #endregion
            //if (formHelper.inputCheck(groupBox1))
            //{
            if (dgvdetail.RowCount != 0)
            {
                SetPara();
                List<InvoiceClass> list = GetIndent();

                if (aSCLogic.SellContractAdd(sCClass, list))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                //}
            }
            else
            {
                if (MessageBox.Show("你还没有添加销售合同的详细信息", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)                 
                    return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvdetail.SelectedRows) 
            {
                this.dgvdetail.Rows.Remove(dgvr);
            }
        }

        private void cbxPKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cobBoBoxLinkage();
        }

        private void cbxPName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setCbxPmodel();
        }
        // 2009-4-17 修改人：付中华
        // 此方法用于计算销售合同上的预计总额=所有销售单价和数量相乘的累加 销售总量是所有销售数量的累加        
        private void caleTotalMoneyAndTotalWeight()
        {
            if (dgvdetail.RowCount != 0)
            {
                decimal totalWeight = 0;
                decimal totalMoney = 0;
                foreach (DataGridViewRow row in dgvdetail.Rows)
                {
                    totalWeight += decimal.Parse(row.Cells["quantity"].Value.ToString());
                    totalMoney += decimal.Parse(row.Cells["quantity"].Value.ToString()) * decimal.Parse(row.Cells["unitPrice"].Value.ToString());
                }
                txtSum.Text = Convert.ToString(totalMoney);
                txtminQuantity.Text = Convert.ToString(totalWeight);
            }
        }
        // 2009-4-17 修改人：付中华
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
        // 2009-4-17 修改人：付中华
        // 客户名称提交的时候要进入到运输方的下拉列表框中
        private void cbxCiId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string client = this.cbxCiId.Text.ToString();
            if (client != "")
            {
                if (isExist(client))
                { }
                else
                {
                    comboBox1.Items.Add(client);
                }
            }
        }

        private void rbtnCHT_CheckedChanged(object sender, EventArgs e)
        {
            //如果是补充合同,则选择合同编号;    
            if (rbtnCHT.Checked)
            {
                cbxScNo.Visible = true;
                txtScNo.Visible = false;
                label1.Text = "主合同编号";
                label12.Text = "补充合同名称";
                txtSupplycNo.Visible = true;
                label8.Visible = true;

                //初始化销售合同编号；
                cbxScNo.DataSource = aSCLogic.InitialASalesComboBox(1);
                cbxScNo.DisplayMember = "no";
                cbxScNo.ValueMember = "id";
                cbxScNo.SelectedIndex = -1;

            }
        }
        // 2009-4-17 修改人：付中华
        // 当是补充合同时 选中主合同编号后默认客户就应该上去了并且是不可以修改的
        private void cbxScNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbxCiId.Enabled = true;
            if (cbxScNo.SelectedValue.ToString() != "")
            {
                cbxCiId.Text = aSCLogic.findClientNameLogic(Convert.ToInt32(cbxScNo.SelectedValue.ToString())).Rows[0][0].ToString();
            }
            cbxCiId.Enabled = false;
            if (cbxCiId.Text != "")
            {
                string client = this.cbxCiId.Text.ToString();
                if (client != "")
                {
                    if (isExist(client))
                    { }
                    else
                    {
                        comboBox1.Items.Add(client);
                    }
                }
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            // 判断合同名称在数据库表中是否已经存在
            bool existName = false;
            if (txtName.Text.Trim() != "")
            {
                string contractName = txtName.Text.Trim();
                existName = aSCLogic.compareContractNameLogic(contractName);
                if (existName)
                {
                    MessageBox.Show("此合同名称已经存在,请重新输入合同名称");
                    txtName.Clear();
                    //txtname.Focus();
                }
            }
        }

        private void txtScNo_Leave(object sender, EventArgs e)
        {
            // 判断合同编号在数据库表中是否已经存在
            bool existName=false;
            if (txtScNo.Text.Trim() != "")
            {
                string contractNo = txtScNo.Text.Trim();
                existName = aSCLogic.compareContractNoLogic(contractNo);
                if (existName)
                {
                    MessageBox.Show("此合同编号已经存在,请重新输入合同编号");
                    txtScNo.Clear();                    
                }
            }

        }

        
        
        

   
    }
}
