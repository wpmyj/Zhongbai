/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：purchasePlan.cs
     * 文件功能描述：采购计划新增
     *
     * 创建人：付中华
     * 创建时间：2009-3-2
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using System.Data;

namespace DasherStation.stock
{
    public partial class purchasePlan : DasherStation.common.BaseForm
    {

        public purchasePlan()
        {
            InitializeComponent();
        }
        StockPlanDetailClass stockPlanDetail = new StockPlanDetailClass();
        purchaseScheDetaillogic purchaseSchedetaillogic = new purchaseScheDetaillogic();
        DataSet ds = null;
        #region//计算十二个月的采购计划总和
        private void caleTweleveMonthsTotal()
        {
            double sum = 0.0;
            foreach (Object obj in this.panel3.Controls)
            {
                if (obj.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    string value = ((TextBox)obj).Text.Trim();
                    if (!Check.CheckEmpty(value))
                    {
                        value = "0";
                    }
                    if (Check.CheckFloat(value))
                    {
                        sum += Convert.ToDouble(value);
                    }
                    else
                    {

                        MessageBox.Show("只能输入数字！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        ((TextBox)obj).Clear();
                        ((TextBox)obj).Focus();
                        return;
                    }
                    textBox1.Text = Convert.ToString(sum);
                }
            }
        }
        #endregion
        #region//清空十二个月的值
        private void clearText()
        {
            foreach (Object obj in this.panel3.Controls)
            {
                if (obj.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    ((TextBox)obj).Clear();
                }
            }            
            cbxKinds.Text = "";
            cbxName.Text = "";
            cbxModel.Text = "";
            textBox1.Text = "";
        }
        #endregion
        //委托的事件
        private void txt_Leave(object sender, EventArgs e)
        {
            caleTweleveMonthsTotal();
        }

        private void purchasePlan_Load(object sender, EventArgs e)
        {
            planYear.Text = DateTime.Now.Year.ToString();
            tableBindDgv();
            #region//初始化制作人
            cbxMaker.DataSource = purchaseSchedetaillogic.makerComboboxlogic();
            cbxMaker.DisplayMember = "name";
            cbxMaker.ValueMember = "id";
            cbxMaker.SelectedIndex = -1;
            #endregion
            #region//建立委托事件处理十二个月输入后计算生产产量
            foreach (Object obj in this.panel3.Controls)
            {
                if (obj.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    ((TextBox)obj).Leave += new EventHandler(txt_Leave);
                }
            }
            #endregion
            #region//初始化材料的种类名称规格
            int pkid, pnid;
            cbxKinds.DataSource = purchaseSchedetaillogic.materialKindlogic();
            cbxKinds.DisplayMember = "sort";
            cbxKinds.ValueMember = "id";
            cbxKinds.SelectedIndex = -1;

            if (cbxKinds.SelectedValue == null)
            {
                pkid = 0;
                return;
            }
            pkid = Convert.ToInt32(cbxKinds.SelectedValue.ToString());
            cbxName.DataSource = purchaseSchedetaillogic.materialNamelogic(pkid);
            cbxName.DisplayMember = "name";
            cbxName.ValueMember = "id";
            cbxName.SelectedIndex = -1;
            if (cbxName.SelectedValue == null)
            {
                pnid = 0;
                return;
            }
            pnid = Convert.ToInt32(cbxName.SelectedValue.ToString());
            cbxModel.DataSource = purchaseSchedetaillogic.materialModellogic(pnid);
            cbxModel.DisplayMember = "model";
            cbxModel.ValueMember = "id";
            cbxModel.SelectedIndex = -1;
            #endregion 
        }
        #region//自己定义个采购计划明细表和下面的datagridview绑定
        private void tableBindDgv()
        {
            ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("sort");
            dt.Columns.Add("name");
            dt.Columns.Add("model");
            dt.Columns.Add("january");
            dt.Columns.Add("february");
            dt.Columns.Add("march");
            dt.Columns.Add("april");
            dt.Columns.Add("may");
            dt.Columns.Add("june");
            dt.Columns.Add("july");
            dt.Columns.Add("august");
            dt.Columns.Add("september");
            dt.Columns.Add("october");
            dt.Columns.Add("november");
            dt.Columns.Add("december");
            dt.Columns.Add("quantity");
            dt.Columns.Add("mId");
            dt.Columns.Add("inputDate");
            ds.Tables.Add(dt);

            dgvPurchaseDetail.DataSource = ds.Tables[0];

        }        
        #endregion
        

        private void btnNew_Click(object sender, EventArgs e)
        {
            #region//对材料种类、名称、规格、采购总量的校验
            if (!Check.CheckEmpty(cbxKinds.Text.ToString()))
            {
                MessageBox.Show("材料种类不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxKinds.Focus();
                return;
            }
            if (!Check.CheckEmpty(cbxName.Text.ToString()))
            {
                MessageBox.Show("材料名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxName.Focus();
                return;
            }
            if (!Check.CheckEmpty(cbxModel.Text.ToString()))
            {
                MessageBox.Show("材料规格不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxModel.Focus();
                return;
            }
            if (!Check.CheckEmpty(textBox1.Text.ToString()))
            {
                MessageBox.Show("采购总量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            #endregion
            MaterialClass materialmodel = new MaterialClass();
            materialmodel.mnId = Convert.ToInt32(this.cbxName.SelectedValue.ToString());
            materialmodel.mmId = Convert.ToInt32(this.cbxModel.SelectedValue.ToString());

            getStockDetailInfo();
            stockPlanDetail.mId = (long)(purchaseSchedetaillogic.getObj(materialmodel).id);
            purchaseSchedetaillogic.stockPlanDetailAdd(stockPlanDetail, ds.Tables[0], cbxKinds.Text, cbxName.Text, cbxModel.Text);
            clearText();
            cbxKinds.SelectedIndex = -1;
            cbxName.SelectedIndex = -1;
            cbxModel.SelectedIndex = -1;
        }       
        public void getStockDetailInfo()
        {
            #region//采购计划明细信息
            if (this.txtJan.Text.Trim().ToString() != "")
            {
                stockPlanDetail.january = decimal.Parse(this.txtJan.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.january = null;
            }
            if (this.txtFeb.Text.Trim().ToString() != "")
            {
                stockPlanDetail.february = decimal.Parse(this.txtFeb.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.february = null;
            }
            if (this.txtMar.Text.Trim().ToString() != "")
            {
                stockPlanDetail.march = decimal.Parse(this.txtMar.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.march = null;
            }
            if (this.txtApr.Text.Trim().ToString() != "")
            {
                stockPlanDetail.april = decimal.Parse(this.txtApr.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.april = null;
            }
            if (this.txtMay.Text.Trim().ToString() != "")
            {
                stockPlanDetail.may = decimal.Parse(this.txtMay.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.may = null;
            }
            if (this.txtJun.Text.Trim().ToString() != "")
            {
                stockPlanDetail.june = decimal.Parse(this.txtJun.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.june = null;
            }
            if (txtJul.Text.Trim().ToString() != "")
            {
                stockPlanDetail.july = decimal.Parse(this.txtJul.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.july = null;
            }
            if (this.txtAug.Text.Trim().ToString() != "")
            {
                stockPlanDetail.august = decimal.Parse(this.txtAug.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.august = null;
            }
            if (this.txtSep.Text.Trim().ToString() != "")
            {
                stockPlanDetail.september = decimal.Parse(this.txtSep.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.september = null;
            }
            if (this.txtOct.Text.Trim().ToString() != "")
            {
                stockPlanDetail.october = decimal.Parse(this.txtOct.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.october = null;
            }
            if (this.txtNov.Text.Trim().ToString() != "")
            {
                stockPlanDetail.november = decimal.Parse(this.txtNov.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.november = null;
            }
            if (this.txtDec.Text.Trim().ToString() != "")
            {
                stockPlanDetail.december = decimal.Parse(this.txtDec.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.december = null;
            }
            if (this.textBox1.Text.Trim().ToString() != "")
            {
                stockPlanDetail.quantity = decimal.Parse(this.textBox1.Text.Trim().ToString());
            }
            else
            {
                stockPlanDetail.quantity = null;
            }
            stockPlanDetail.inputDate = DateTime.Now;
           #endregion
        }

        private void cbxKinds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtNadirStock.Text = "";
            txtNowStock.Text = "";
            #region//种类是否被选中决定名称和规格
            int pkid, pnid;
            if (cbxKinds.SelectedValue == null)
            {
                pkid = 0;
                cbxName.SelectedIndex = -1;
                return;
            }
            pkid = Convert.ToInt32(cbxKinds.SelectedValue.ToString());
            cbxName.DataSource = purchaseSchedetaillogic.materialNamelogic(pkid);
            cbxName.DisplayMember = "name";
            cbxName.ValueMember = "id";
            cbxName.Text = "";
            cbxName.SelectedIndex = -1;
            if (cbxName.SelectedValue == null)
            {
                pnid = 0;
                cbxModel.Text = "";
                cbxModel.SelectedIndex = -1;
                return;
            }
            pnid = Convert.ToInt32(cbxName.SelectedValue.ToString());
            cbxModel.DataSource = purchaseSchedetaillogic.materialModellogic(pnid);
            cbxModel.DisplayMember = "model";
            cbxModel.ValueMember = "id";
            cbxModel.SelectedIndex = -1;
            #endregion 
            
        }

        private void cbxName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtNadirStock.Text = "";
            txtNowStock.Text = "";
            #region//名称是否被选中决定规格的值
            int pnid;
            if (cbxName.SelectedValue == null)
            {
                pnid = 0;
                cbxModel.SelectedIndex = -1;
                return;
            }
            pnid = Convert.ToInt32(cbxName.SelectedValue.ToString());
            cbxModel.DataSource = purchaseSchedetaillogic.materialModellogic(pnid);
            cbxModel.DisplayMember = "model";
            cbxModel.ValueMember = "id";
            cbxModel.Text = "";
            cbxModel.SelectedIndex = -1;
            #endregion
           
        } 
        //批量保存的方法
        private void saveStockPlan()
        {
            StockPlanClass stockPlan = getStockPlan();
            List < StockPlanDetailClass > list= getStockPlanDetail();
            //purchaseSchedetaillogic.saveStockPlanAdd(stockPlan, list);
            if (purchaseSchedetaillogic.saveStockPlanAdd(stockPlan, list))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            { }
        }
        //采购计划信息
        private StockPlanClass getStockPlan()
        {
            StockPlanClass stockPlan = new StockPlanClass();
            stockPlan.inputDate = DateTime.Now;
            stockPlan.inputMan = this.userName;
            stockPlan.producer = cbxMaker.Text.Trim();
            //审核审批人还未做
            //stockPlan.assessor =
            //stockPlan.checkupMan =

            stockPlan.planYear = planYear.Text.ToString().Trim();
            stockPlan.remark = txtRemark.Text.Trim();

            return stockPlan;
        }
        //采购计划明细对象列表
        private List<StockPlanDetailClass> getStockPlanDetail()
        {
            StockPlanDetailClass stockPlanDetail = null;
            List<StockPlanDetailClass> list = new List<StockPlanDetailClass>();
            foreach (DataGridViewRow dgvr in dgvPurchaseDetail.Rows)
            {
                stockPlanDetail = new StockPlanDetailClass();
                stockPlanDetail.mId = int.Parse(dgvr.Cells["mId"].Value.ToString());
                if (dgvr.Cells["january"].FormattedValue.ToString() !="")
                {
                    stockPlanDetail.january = decimal.Parse(dgvr.Cells["january"].Value.ToString());
                }
                if (dgvr.Cells["february"].FormattedValue.ToString() != "")
                {
                    stockPlanDetail.february = decimal.Parse(dgvr.Cells["february"].Value.ToString());
                }
                if(dgvr.Cells["march"].FormattedValue.ToString() != "")
                {
                    stockPlanDetail.march =decimal.Parse(dgvr.Cells["march"].Value.ToString());
                }
                if(dgvr.Cells["april"].FormattedValue.ToString()!="")
                {
                    stockPlanDetail.april =decimal.Parse(dgvr.Cells["april"].Value.ToString());
                }
                if (dgvr.Cells["may"].FormattedValue.ToString() != "")
                {
                    stockPlanDetail.may=decimal.Parse(dgvr.Cells["may"].Value.ToString());
                }
                if (dgvr.Cells["june"].FormattedValue.ToString() != "")
                {
                    stockPlanDetail.june=decimal.Parse(dgvr.Cells["june"].Value.ToString());
                }
                if (dgvr.Cells["july"].FormattedValue.ToString() != "")
                {
                    stockPlanDetail.july =decimal.Parse(dgvr.Cells["july"].Value.ToString());
                }
                if (dgvr.Cells["august"].FormattedValue.ToString() != "")
                {
                    stockPlanDetail.august =decimal.Parse(dgvr.Cells["august"].Value.ToString());
                }
                if (dgvr.Cells["september"].FormattedValue.ToString() != "")
                {
                    stockPlanDetail.september =decimal.Parse(dgvr.Cells["september"].Value.ToString());
                }
                if (dgvr.Cells["october"].FormattedValue.ToString() != "")
                {
                    stockPlanDetail.october =decimal.Parse(dgvr.Cells["october"].Value.ToString());
                }
                if (dgvr.Cells["november"].FormattedValue.ToString() != "")
                {
                    stockPlanDetail.november =decimal.Parse(dgvr.Cells["november"].Value.ToString());
                }
                if (dgvr.Cells["december"].FormattedValue.ToString() != "")
                {
                    stockPlanDetail.december = decimal.Parse(dgvr.Cells["december"].Value.ToString());
                }
                if (dgvr.Cells["quantity"].FormattedValue.ToString() != "")
                {
                    stockPlanDetail.quantity = decimal.Parse(dgvr.Cells["quantity"].Value.ToString());
                }            
                stockPlanDetail.inputDate = DateTime.Now;
                list.Add(stockPlanDetail);
            }
                return list;            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region//校验制作人和计划年份
            if (!Check.CheckEmpty(cbxMaker.Text.ToString()))
            {
                MessageBox.Show("制作人不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxMaker.Focus();
                return;
            }
            if (!Check.CheckNumber(planYear.Text))
            {
                MessageBox.Show("请输入正确的计划年份，如“2009”！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                planYear.Focus();
                return;
            }
            #endregion
            if (dgvPurchaseDetail.RowCount != 0)
            {
                saveStockPlan();
            }
            else
            {
                if (MessageBox.Show("你还没有添加采购计划的详细信息", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    //this.Close(); 
                    return;
                
            }

        }
        //删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("你确定删除选择的采购计划明细吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)) == DialogResult.OK)
                    foreach (DataGridViewRow dgvr in dgvPurchaseDetail.SelectedRows)
                    {
                        this.dgvPurchaseDetail.Rows.Remove(dgvr);
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

        private void cbxModel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            long mmId, mnId;
            if (cbxModel.SelectedValue == null)
            {
                return;
            }
            else
            {
                mmId = Convert.ToInt32(this.cbxModel.SelectedValue.ToString());
                if (cbxName.SelectedValue == null)
                {
                    MessageBox.Show("选中材料名称后才能选择材料规格", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }
                mnId = Convert.ToInt32(this.cbxName.SelectedValue.ToString());
            }
            // 如果材料名称和材料规格对应的mnId和mmId值都存在的话那么可以到材料表中找到对应的最小库存量和他对应的id值
            // 用返回来的id值到材料库存列表中比对mId与其相等时查到的库存量即为现有库存量
            // 库存量有两个值优先取quantity2的值
            if ((mnId.ToString()!="") && (mmId.ToString()!=""))
            {
                DataTable idAndNadirStock = purchaseSchedetaillogic.findMinStockAndIdLogic(mnId, mmId);
                if (idAndNadirStock.Rows[0][1].ToString() != "")
                {
                    txtNadirStock.Text = idAndNadirStock.Rows[0][1].ToString();
                }
                if (idAndNadirStock.Rows[0][0].ToString() != "")
                {
                    long id = Convert.ToInt64(idAndNadirStock.Rows[0][0].ToString());
                    if (purchaseSchedetaillogic.findNowStockLogic(id) != "")
                    {
                        txtNowStock.Text = purchaseSchedetaillogic.findNowStockLogic(id);
                    }
                    else
                    {
                        txtNowStock.Text = "";
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            materialNeeding materialNeeding = new materialNeeding();
            materialNeeding.Show();            
        }
         
    }
}

