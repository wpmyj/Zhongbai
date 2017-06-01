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
using Microsoft.ReportingServices.ReportRendering;
using DasherStation.transport;

namespace DasherStation.sell
{
    public partial class FrmVenditionPlan : common.BaseForm
    {
        public FrmVenditionPlan()
        {
            InitializeComponent();
        }

        ProductLogic pLogic = new ProductLogic();
        FormHelper formHelper = new FormHelper(); 
        sellPlanDetailClass sPDclass = new sellPlanDetailClass();
        VenditionPlanLogic vplanLogic = new VenditionPlanLogic();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        decimal[] month = new decimal[12];
        //bool state = true;

        #region DataGridViewBinding() 绑定DataGridView
        private void DataGridViewBinding()
        {
            ds = new DataSet();

            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("pId");
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
            dt.Columns.Add("inputDate");
            dt.Columns.Add("spId");
            ds.Tables.Add(dt);

            dgvSPDetail.DataSource = ds.Tables[0];
        }
        #endregion

        #region getSellPlanDetail()销售计划明细对象列表
        private List<sellPlanDetailClass> getSellPlanDetail()
        {
            sellPlanDetailClass sPDclass = null;
            List<sellPlanDetailClass> list = new List<sellPlanDetailClass>();
            foreach (DataGridViewRow dgvr in dgvSPDetail.Rows)
            {
                sPDclass = new sellPlanDetailClass();
                sPDclass.PId = int.Parse(dgvr.Cells["PId"].Value.ToString());
                // 2009-4-17 修改人：付中华
                // 对于所有DataGridView中的单格进行校验
                if (dgvr.Cells["january"].FormattedValue.ToString() != "")
                {
                    sPDclass.January = decimal.Parse(dgvr.Cells["january"].Value.ToString());
                }
                if (dgvr.Cells["february"].FormattedValue.ToString() != "")
                {
                    sPDclass.February = decimal.Parse(dgvr.Cells["february"].Value.ToString());
                }
                if (dgvr.Cells["march"].FormattedValue.ToString() != "")
                {
                    sPDclass.March = decimal.Parse(dgvr.Cells["march"].Value.ToString());
                }
                if (dgvr.Cells["april"].FormattedValue.ToString() != "")
                {
                    sPDclass.April  = decimal.Parse(dgvr.Cells["april"].Value.ToString());
                }
                if (dgvr.Cells["may"].FormattedValue.ToString() != "")
                {
                    sPDclass.May = decimal.Parse(dgvr.Cells["may"].Value.ToString());
                }
                if (dgvr.Cells["june"].FormattedValue.ToString() != "")
                {
                    sPDclass.June = decimal.Parse(dgvr.Cells["june"].Value.ToString());
                }
                if (dgvr.Cells["july"].FormattedValue.ToString() != "")
                {
                    sPDclass.July = decimal.Parse(dgvr.Cells["july"].Value.ToString());
                }
                if (dgvr.Cells["august"].FormattedValue.ToString() != "")
                {
                    sPDclass.August = decimal.Parse(dgvr.Cells["august"].Value.ToString());
                }
                if (dgvr.Cells["september"].FormattedValue.ToString() != "")
                {
                    sPDclass.September = decimal.Parse(dgvr.Cells["september"].Value.ToString());
                }
                if (dgvr.Cells["october"].FormattedValue.ToString() != "")
                {
                    sPDclass.October = decimal.Parse(dgvr.Cells["october"].Value.ToString());
                }
                if (dgvr.Cells["november"].FormattedValue.ToString() != "")
                {
                    sPDclass.November = decimal.Parse(dgvr.Cells["november"].Value.ToString());
                }
                if (dgvr.Cells["december"].FormattedValue.ToString() != "")
                {
                    sPDclass.December = decimal.Parse(dgvr.Cells["december"].Value.ToString());
                }
                if (dgvr.Cells["quantity"].FormattedValue.ToString() != "")
                {
                    sPDclass.Quantity = decimal.Parse(dgvr.Cells["quantity"].Value.ToString());
                }            
                //sPDclass.January = decimal.Parse(dgvr.Cells["january"].Value.ToString());
                //sPDclass.February = decimal.Parse(dgvr.Cells["february"].Value.ToString());
                //sPDclass.March = decimal.Parse(dgvr.Cells["march"].Value.ToString());
                //sPDclass.April = decimal.Parse(dgvr.Cells["april"].Value.ToString());
                //sPDclass.May = decimal.Parse(dgvr.Cells["may"].Value.ToString());
                //sPDclass.June = decimal.Parse(dgvr.Cells["june"].Value.ToString());
                //sPDclass.July = decimal.Parse(dgvr.Cells["july"].Value.ToString());
                //sPDclass.August = decimal.Parse(dgvr.Cells["august"].Value.ToString());
                //sPDclass.September = decimal.Parse(dgvr.Cells["september"].Value.ToString());
                //sPDclass.October = decimal.Parse(dgvr.Cells["october"].Value.ToString());
                //sPDclass.November = decimal.Parse(dgvr.Cells["november"].Value.ToString());
                //sPDclass.December = decimal.Parse(dgvr.Cells["december"].Value.ToString());
                //sPDclass.Quantity = decimal.Parse(dgvr.Cells["quantity"].Value.ToString());
                sPDclass.InputDate = DateTime.Now;

                list.Add(sPDclass);
            }
            return list;
        }
        #endregion

        #region ClearAction()清空文本框、下拉列表框内容
        private void ClearAction()
        {
            cbxPKind.SelectedIndex = -1;
            cbxPName.SelectedIndex = -1;
            cbxPModel.SelectedIndex = -1;

            txtQuantity.Clear();
            txtJanuary.Clear();
            txtFebruary.Clear();
            txtMarch.Clear();
            txtApril.Clear();
            txtMay.Clear();
            txtJune.Clear();
            txtJuly.Clear();
            txtAugust.Clear();
            txtSeptember.Clear();
            txtOctober.Clear();
            txtNovember.Clear();
            txtDecember.Clear();
        }
        #endregion

        #region GetVenditionPlan() 获取计划明细内容;
        private void GetVenditionPlan()
        {
            int pNId, pMId;
            //decimal? quantity;

            if (!cbxPName.Text.Trim().Equals(""))
            {
                pNId = Convert.ToInt32(cbxPName.SelectedValue.ToString());
                if (!cbxPModel.Text.Trim().Equals(""))
                {
                    pMId = Convert.ToInt32(cbxPModel.SelectedValue.ToString());
                    sPDclass.PId = (long)(pLogic.PSearchID(pNId, pMId));
                }
            }
            // 2009-4-17 修改人：付中华
            // 采购计划明细信息
            #region
            if (this.txtJanuary.Text.Trim().ToString() != "")
            {
                sPDclass.January = decimal.Parse(this.txtJanuary.Text.Trim().ToString());
            }
            else
            {
                sPDclass.January = null;
            }
            if (this.txtFebruary.Text.Trim().ToString() != "")
            {
                sPDclass.February = decimal.Parse(this.txtFebruary.Text.Trim().ToString());
            }
            else
            {
                sPDclass.February = null;
            }
            if (this.txtMarch.Text.Trim().ToString() != "")
            {
                sPDclass.March = decimal.Parse(this.txtMarch.Text.Trim().ToString());
            }
            else
            {
                sPDclass.March = null;
            }
            if (this.txtApril.Text.Trim().ToString() != "")
            {
                sPDclass.April = decimal.Parse(this.txtApril.Text.Trim().ToString());
            }
            else
            {
                sPDclass.April = null;
            }
            if (this.txtMay.Text.Trim().ToString() != "")
            {
                sPDclass.May = decimal.Parse(this.txtMay.Text.Trim().ToString());
            }
            else
            {
                sPDclass.May = null;
            }
            if (this.txtJune.Text.Trim().ToString() != "")
            {
                sPDclass.June = decimal.Parse(this.txtJune.Text.Trim().ToString());
            }
            else
            {
                sPDclass.June = null;
            }
            if (txtJuly.Text.Trim().ToString() != "")
            {
                sPDclass.July = decimal.Parse(this.txtJuly.Text.Trim().ToString());
            }
            else
            {
                sPDclass.July = null;
            }
            if (this.txtAugust.Text.Trim().ToString() != "")
            {
                sPDclass.August = decimal.Parse(this.txtAugust.Text.Trim().ToString());
            }
            else
            {
                sPDclass.August = null;
            }
            if (this.txtSeptember.Text.Trim().ToString() != "")
            {
                sPDclass.September = decimal.Parse(this.txtSeptember.Text.Trim().ToString());
            }
            else
            {
                sPDclass.September = null;
            }
            if (this.txtOctober.Text.Trim().ToString() != "")
            {
                sPDclass.October = decimal.Parse(this.txtOctober.Text.Trim().ToString());
            }
            else
            {
                sPDclass.October = null;
            }
            if (this.txtNovember.Text.Trim().ToString() != "")
            {
                sPDclass.November = decimal.Parse(this.txtNovember.Text.Trim().ToString());
            }
            else
            {
                sPDclass.November = null;
            }
            if (this.txtDecember.Text.Trim().ToString() != "")
            {
                sPDclass.December = decimal.Parse(this.txtDecember.Text.Trim().ToString());
            }
            else
            {
                sPDclass.December = null;
            }
            if (this.txtQuantity.Text.Trim().ToString() != "")
            {
                sPDclass.Quantity = decimal.Parse(this.txtQuantity.Text.Trim().ToString());
            }
            else
            {
                sPDclass.Quantity = null;
            }
           
            #endregion
            //if (txtJanuary.Text.Trim().Equals(""))
            //{
            //    sPDclass.January = 0;
            //}
            //else
            //{
            //    sPDclass.January = decimal.Parse(txtJanuary.Text.Trim().ToString());
            //}
            //if (txtFebruary.Text.Trim().Equals(""))
            //{
            //    sPDclass.February = 0;
            //}
            //else
            //{
            //    sPDclass.February = decimal.Parse(txtFebruary.Text.Trim().ToString());
            //}
            //if (txtMarch.Text.Trim().Equals(""))
            //{
            //    sPDclass.March = 0;
            //}
            //else
            //{
            //    sPDclass.March = decimal.Parse(txtMarch.Text.Trim().ToString());
            //}
            //if (txtApril.Text.Trim().Equals(""))
            //{
            //    sPDclass.April = 0;
            //}
            //else
            //{
            //    sPDclass.April = decimal.Parse(txtApril.Text.Trim().ToString());
            //}
            //if (txtMay.Text.Trim().Equals(""))
            //{
            //    sPDclass.May = 0;
            //}
            //else
            //{
            //    sPDclass.May = decimal.Parse(txtMay.Text.Trim().ToString());
            //}
            //if (txtJune.Text.Trim().Equals(""))
            //{
            //    sPDclass.June = 0;
            //}
            //else
            //{
            //    sPDclass.June = decimal.Parse(txtJune.Text.Trim().ToString());
            //}
            //if (txtJuly.Text.Trim().Equals(""))
            //{
            //    sPDclass.July = 0;
            //}
            //else
            //{
            //    sPDclass.July = decimal.Parse(txtJuly.Text.Trim().ToString());
            //}
            //if (txtAugust.Text.Trim().Equals(""))
            //{
            //    sPDclass.August = 0;
            //}
            //else
            //{
            //    sPDclass.August = decimal.Parse(txtAugust.Text.Trim().ToString());
            //}
            //if (txtSeptember.Text.Trim().Equals(""))
            //{
            //    sPDclass.September = 0;
            //}
            //else
            //{
            //    sPDclass.September = decimal.Parse(txtSeptember.Text.Trim().ToString());
            //}
            //if (txtOctober.Text.Trim().Equals(""))
            //{
            //    sPDclass.October = 0;
            //}
            //else
            //{
            //    sPDclass.October = decimal.Parse(txtOctober.Text.Trim().ToString());
            //}
            //if (txtNovember.Text.Trim().Equals(""))
            //{
            //    sPDclass.November = 0;
            //}
            //else
            //{
            //    sPDclass.November = decimal.Parse(txtNovember.Text.Trim().ToString());
            //}
            //if (txtDecember.Text.Trim().Equals(""))
            //{
            //    sPDclass.December = 0;
            //}
            //else
            //{
            //    sPDclass.December = decimal.Parse(txtDecember.Text.Trim().ToString());
            //}

            sPDclass.InputDate = DateTime.Now;

            //对十二个月份销售量进行汇总,添入到销售总量中;
            //quantity = sPDclass.January + sPDclass.February + sPDclass.March + sPDclass.April + sPDclass.May;
            //quantity = quantity + sPDclass.October + sPDclass.June + sPDclass.July + sPDclass.August;
            //quantity = quantity + sPDclass.September + sPDclass.November + sPDclass.December;

            //txtQuantity.Text = quantity.ToString();
            //sPDclass.Quantity = quantity;

        }
        #endregion

        #region SetQuantity()动态变化年销售计划总量



        //private void SetQuantity()
        //{
        //    Verify();
        //    decimal sum = 0;
        //    for (int i = 0; i < 12; i++)
        //    {
        //        sum = sum + month[i];
        //    }
        //    txtQuantity.Text = sum.ToString();  
        
        //}
        #endregion

        #region Verify()校验十二个月份是否均有输入值
        private void Verify()
        {
            // 2009-4-17 修改人：付中华
            // 销售计划明细信息
            #region
            if (this.txtJanuary.Text.Trim().ToString() != "")
            {
                sPDclass.January = decimal.Parse(this.txtJanuary.Text.Trim().ToString());
            }
            else
            {
                sPDclass.January = null;
            }
            if (this.txtFebruary.Text.Trim().ToString() != "")
            {
                sPDclass.February = decimal.Parse(this.txtFebruary.Text.Trim().ToString());
            }
            else
            {
                sPDclass.February = null;
            }
            if (this.txtMarch.Text.Trim().ToString() != "")
            {
                sPDclass.March = decimal.Parse(this.txtMarch.Text.Trim().ToString());
            }
            else
            {
                sPDclass.March = null;
            }
            if (this.txtApril.Text.Trim().ToString() != "")
            {
                sPDclass.April = decimal.Parse(this.txtApril.Text.Trim().ToString());
            }
            else
            {
                sPDclass.April = null;
            }
            if (this.txtMay.Text.Trim().ToString() != "")
            {
                sPDclass.May = decimal.Parse(this.txtMay.Text.Trim().ToString());
            }
            else
            {
                sPDclass.May = null;
            }
            if (this.txtJune.Text.Trim().ToString() != "")
            {
                sPDclass.June = decimal.Parse(this.txtJune.Text.Trim().ToString());
            }
            else
            {
                sPDclass.June = null;
            }
            if (this.txtJuly.Text.Trim().ToString() != "")
            {
                sPDclass.July = decimal.Parse(this.txtJuly.Text.Trim().ToString());
            }
            else
            {
                sPDclass.July = null;
            }
            if (this.txtAugust.Text.Trim().ToString() != "")
            {
                sPDclass.August = decimal.Parse(this.txtAugust.Text.Trim().ToString());
            }
            else
            {
                sPDclass.August = null;
            }
            if (this.txtSeptember.Text.Trim().ToString() != "")
            {
                sPDclass.September = decimal.Parse(this.txtSeptember.Text.Trim().ToString());
            }
            else
            {
                sPDclass.September = null;
            }
            if (this.txtOctober.Text.Trim().ToString() != "")
            {
                sPDclass.October = decimal.Parse(this.txtOctober.Text.Trim().ToString());
            }
            else
            {
                sPDclass.October = null;
            }
            if (this.txtNovember.Text.Trim().ToString() != "")
            {
                sPDclass.November = decimal.Parse(this.txtNovember.Text.Trim().ToString());
            }
            else
            {
                sPDclass.November = null;
            }
            if (this.txtDecember.Text.Trim().ToString() != "")
            {
                sPDclass.December = decimal.Parse(this.txtDecember.Text.Trim().ToString());
            }
            else
            {
                sPDclass.December = null;
            }
            if (this.txtQuantity.Text.Trim().ToString() != "")
            {
                sPDclass.Quantity = decimal.Parse(this.txtQuantity.Text.Trim().ToString());
            }
            else
            {
                sPDclass.Quantity = null;
            }
            sPDclass.InputDate = DateTime.Now;
            #endregion
            //if (string.IsNullOrEmpty(txtJanuary.Text.Trim()) || !Check.CheckFloat(txtJanuary.Text.Trim()))
            //{
            //    month[0] = 0;
            //}
            //else
            //{
            //    month[0] = decimal.Parse(txtJanuary.Text.Trim());
            //}
            //if (string.IsNullOrEmpty(txtFebruary.Text.Trim()) || !Check.CheckFloat(txtFebruary.Text.Trim()))
            //{
            //    month[1] = 0;
            //}
            //else
            //{
            //    month[1] = decimal.Parse(txtFebruary.Text.Trim()); ;
            //}
            //if (string.IsNullOrEmpty(txtMarch.Text.Trim()) || !Check.CheckFloat(txtMarch.Text.Trim()))
            //{
            //    month[2] = 0;
            //}
            //else
            //{
            //    month[2] = decimal.Parse(txtMarch.Text.Trim()); ;
            //}
            //if (string.IsNullOrEmpty(txtApril.Text.Trim()) || !Check.CheckFloat(txtApril.Text.Trim()))
            //{
            //    month[3] = 0;
            //}
            //else
            //{
            //    month[3] = decimal.Parse(txtApril.Text.Trim()); ;
            //}
            //if (string.IsNullOrEmpty(txtMay.Text.Trim()) || !Check.CheckFloat(txtMay.Text.Trim()))
            //{
            //    month[4] = 0;
            //}
            //else
            //{
            //    month[4] = decimal.Parse(txtMay.Text.Trim()); ;
            //}
            //if (string.IsNullOrEmpty(txtJune.Text.Trim()) || !Check.CheckFloat(txtJune.Text.Trim()))
            //{
            //    month[5] = 0;
            //}
            //else
            //{
            //    month[5] = decimal.Parse(txtJune.Text.Trim()); ;
            //}
            //if (string.IsNullOrEmpty(txtJuly.Text.Trim()) || !Check.CheckFloat(txtJuly.Text.Trim()))
            //{
            //    month[6] = 0;
            //}
            //else
            //{
            //    month[6] = decimal.Parse(txtJuly.Text.Trim()); ;
            //}
            //if (string.IsNullOrEmpty(txtAugust.Text.Trim()) || !Check.CheckFloat(txtAugust.Text.Trim()))
            //{
            //    month[7] = 0;
            //}
            //else
            //{
            //    month[7] = decimal.Parse(txtAugust.Text.Trim()); ;
            //}
            //if (string.IsNullOrEmpty(txtSeptember.Text.Trim()) || !Check.CheckFloat(txtSeptember.Text.Trim()))
            //{
            //    month[8] = 0;
            //}
            //else
            //{
            //    month[8] = decimal.Parse(txtSeptember.Text.Trim()); ;
            //}
            //if (string.IsNullOrEmpty(txtOctober.Text.Trim()) || !Check.CheckFloat(txtOctober.Text.Trim()))
            //{
            //    month[9] = 0;
            //}
            //else
            //{
            //    month[9] = decimal.Parse(txtOctober.Text.Trim()); ;
            //}
            //if (string.IsNullOrEmpty(txtNovember.Text.Trim()) || !Check.CheckFloat(txtNovember.Text.Trim()))
            //{
            //    month[10] = 0;
            //}
            //else
            //{
            //    month[10] = decimal.Parse(txtNovember.Text.Trim()); ;
            //}
            //if (string.IsNullOrEmpty(txtDecember.Text.Trim()) || !Check.CheckFloat(txtDecember.Text.Trim()))
            //{
            //    month[11] = 0;
            //}
            //else
            //{
            //    month[11] = decimal.Parse(txtDecember.Text.Trim()); ;
            //}
        }
        #endregion

        private void FrmVenditionPlan_Load(object sender, EventArgs e)
        {
            int pkId, pnId;
            // 209-4-17 修改人：付中华
            // 将销售计划年份默认为当前时间的年份

             #region//建立委托事件处理十二个月输入后计算生产产量
            foreach (Object obj in this.panel1.Controls)
            {
                if (obj.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    ((System.Windows.Forms.TextBox)obj).Leave += new EventHandler(txt_Leave);
                }
            }          
            #endregion
            planYear.Text = DateTime.Now.Year.ToString();
            DataGridViewBinding();
            
            // 209-4-17 修改人：付中华
            //初始化制作人
            #region
            cbxProducer.DataSource = pLogic.makerComboboxLogic();
            cbxProducer.DisplayMember = "name";
            cbxProducer.ValueMember = "id";
            cbxProducer.SelectedIndex = -1;
            #endregion

            #region  初始化,产品种类、名称、规格

            cbxPKind.DataSource = pLogic.InitialPKindComboBox();
            cbxPKind.DisplayMember = "产品种类";
            cbxPKind.ValueMember = "id";
            cbxPKind.SelectedIndex = 1;
            cbxPKind.Text = "";
            cbxPKind.SelectedIndex = -1;

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

            }
            #endregion

        }

        private void cbxPKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pkId, pnId;

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
            else
            {
                cbxPName.DataSource = pLogic.InitialPNameComboBox(pkId);
            }
        }

        private void cbxPName_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void FrmVenditionPlan_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if (e.KeyChar == (char)13)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
           
            // try
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
        // 2009-4-17 修改人：付中华
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (formHelper.inputCheck(groupBox2) && formHelper.inputCheck(panel1))
            //{
            #region//对产品种类、名称、规格、采购总量的校验
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
                MessageBox.Show("产品总量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Focus();
                return;
            }
            #endregion
                //Verify();

                //for (int i = 0; i < 12; i++)
                //{
                //    if (month[i] != 0)
                //    {
                //        state = false;
                //    }
                //}
                //if (state)
                //{
                //    MessageBox.Show("月份计划不能都为空,请输入至少一个月份的计划！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtJanuary.Focus();
                //    return;
                //}

                GetVenditionPlan();

                vplanLogic.DataGrilViedAddRow(sPDclass, ds.Tables[0], cbxPKind.Text, cbxPName.Text, cbxPModel.Text);

                ClearAction();
            //}

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvSPDetail.SelectedRows)
            {
                this.dgvSPDetail.Rows.Remove(dgvr); 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sellPlanClass sellPlanClass = new sellPlanClass();
            // 2009-4-17 修改人：付中华
            //校验制作人和计划年份
            #region
            if (!Check.CheckEmpty(cbxProducer.Text.ToString()))
            {
                MessageBox.Show("制作人不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxProducer.Focus();
                return;
            }
            if (!Check.CheckNumber(planYear.Text))
            {
                MessageBox.Show("请输入正确的计划年份，如“2009”！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                planYear.Focus();
                return;
            }
            #endregion
            //if (formHelper.inputCheck(groupBox1))
            //{
                sellPlanClass.Producer = cbxProducer.Text.Trim();
                sellPlanClass.Remark = txtRemark.Text.Trim();
                sellPlanClass.PlanYear = planYear.Text.ToString().Trim();
                sellPlanClass.InputMan = this.userName;

                if (dgvSPDetail.RowCount != 0)
                {

                    List<sellPlanDetailClass> list = getSellPlanDetail();

                    if (vplanLogic.saveSellPlanAdd(sellPlanClass, list))
                    {
                        this.DialogResult = DialogResult.OK;
                        //MessageBox.Show("新增添加销售计划成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                //else
                //{
                //if (MessageBox.Show("你还没有添加销售计划的详细信息", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                //    this.Close();

                //}
            }

        //private void txt_Leave(object sender, EventArgs e)
        //{
        //    if (formHelper.inputCheck(panel1))
        //    {
        //        SetQuantity();
        //    }
        //}
        // 2009-4-17 修改人：付中华
        // 委托的事件
        private void txt_Leave(object sender, EventArgs e)
        {
            caleTweleveMonthsTotal();
        }
        // 2009-4-17 修改人：付中华
        //计算十二个月的销售计划总和
        #region
        private void caleTweleveMonthsTotal()
        {
            double sum = 0.0;
            foreach (Object obj in this.panel1.Controls)
            {
                if (obj.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    string value = ((System.Windows.Forms.TextBox)obj).Text.Trim();
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
                        ((System.Windows.Forms.TextBox)obj).Clear();
                        ((System.Windows.Forms.TextBox)obj).Focus();
                        return;
                    }
                    txtQuantity.Text = Convert.ToString(sum);
                }
            }
        }
        #endregion
    }

}



