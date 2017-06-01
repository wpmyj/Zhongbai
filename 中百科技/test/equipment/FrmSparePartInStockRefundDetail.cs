/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：FrmSparePartInStockRefundDetail.cs
 * 文件功能描述：备品配件退货单明细 窗体
 *
 * 创建人：关启学
 * 创建时间：2009-03-26
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

namespace DasherStation.equipment
{
    public partial class FrmSparePartInStockRefundDetail : common.BaseForm
    {

        #region//参数初始化

        // “备品配件退货单”数据库操作对象
        private SparePartInStockDB sparePartInStockDB = new SparePartInStockDB();

        // “备品配件退货单”实体对象
        private SparePartInStock sparePartInStock = new SparePartInStock();

        // “备品配件”实体对象
        private SparePart sparePart;

        // 用于该子窗体关闭后，其父窗体能够访问在子窗体加入的设备保修计划id值
        public long SparePartInStockRefundId
        {
            get { return sparePartInStock.Id; }
        }

        // 构造方法
        public FrmSparePartInStockRefundDetail()
        {
            InitializeComponent();
        }

        // 构造方法
        public FrmSparePartInStockRefundDetail(string inputMan)
        {
            InitializeComponent();
            this.userName = inputMan;
        }

        #endregion


        #region//窗体事件

        // 事件：窗体加载事件
        private void FrmSparePartInStockRefundDetail_Load(object sender, EventArgs e)
        {
            InitialOverall();
            InitailDetail();
        }

        // 事件：“选择入库单按钮”点击事件，记录入库单信息，并关闭窗体
        private void btnSelectInStock_Click(object sender, EventArgs e)
        {
            FrmSparePartInStock frm = new FrmSparePartInStock();
            frm.HideButtons();


            if (frm.ShowDialog() == DialogResult.OK)
            {
                tbInStockId.Text = frm.sparePartInStock.Id.ToString();
                dtpInStockDate.Value = frm.sparePartInStock.StockDate;
                tbStockMan.Text = frm.sparePartInStock.StockMan;
                cbProvider.SelectedValue = frm.sparePartInStock.PiId;
                tbInvoiceNo.Text = frm.sparePartInStock.InvoiceNo;
                tbInStockRemark.Text = frm.sparePartInStock.Remark;

                //“设备信息明细”DataGridView数据源绑定
                dgvDetail.DataSource = sparePartInStockDB.GetSparePartInStockDetail(frm.sparePartInStock.Id);
                dgvDetail.Columns["id"].Visible = false;
                dgvDetail.Columns["spaId"].Visible = false;
                dgvDetail.Columns["spbiId"].Visible = false;
                dgvDetail.Columns["inputDate"].Visible = false;
                dgvDetail.Columns["inputMan"].Visible = false;

            }
        }

        // 事件：“保存入库单按钮”点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;

            sparePartInStock.StockDate = dtpStockDate.Value;
            sparePartInStock.StockMan = cbStockMan.Text;
            sparePartInStock.PiId = Convert.ToInt64(cbProvider.SelectedValue.ToString());
            sparePartInStock.InvoiceNo = tbInvoiceNo.Text;
            sparePartInStock.Remark = tbRemark.Text;
            sparePartInStock.ParentId = Convert.ToInt64(tbInStockId.Text);

            //如果不存在该条记录，就插入
            DataTable dt = (DataTable)(dgvDetail.DataSource);
            sparePartInStockDB.InsertSparePartInStockRefund(sparePartInStock, dt);


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 事件：根据退货金额、退货数量、退货单价三者的变化，计算退货金额（当退货数量或退货单价变动），计算退货单价（当退货单价变动）
        private void dgvDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            long refundCount = 0;
            decimal tPrice = 0;
            decimal uPrice = 0;

            DataGridView dgvDetail = sender as DataGridView;
            if (dgvDetail.CurrentRow != null)
            {
                long.TryParse(dgvDetail.CurrentRow.Cells["count"].Value.ToString(), out refundCount);
                decimal.TryParse(dgvDetail.CurrentRow.Cells["totalPrice"].Value.ToString(), out tPrice);
                decimal.TryParse(dgvDetail.CurrentRow.Cells["unitPrice"].Value.ToString(), out uPrice);


                if (dgvDetail.CurrentRow.Cells["count"].ColumnIndex == e.ColumnIndex)
                {
                    dgvDetail.CurrentRow.Cells["totalPrice"].Value = uPrice * refundCount;
                }

                if (dgvDetail.CurrentRow.Cells["unitPrice"].ColumnIndex == e.ColumnIndex)
                {
                    dgvDetail.CurrentRow.Cells["totalPrice"].Value = uPrice * refundCount;
                }


                if (dgvDetail.CurrentRow.Cells["totalPrice"].ColumnIndex == e.ColumnIndex)
                {
                    if (refundCount != 0)
                    {
                        dgvDetail.CurrentRow.Cells["unitPrice"].Value = tPrice / refundCount;
                    }
                }

            }

        }

        #endregion


        #region//事件处理方法

        // 方法：初始化主表信息
        private void InitialOverall()
        {
            dtpStockDate.MaxDate = DateTime.Now;            

            //退货人
            cbStockMan.DataSource = sparePartInStockDB.GetPersonnelInfo();
            cbStockMan.ValueMember = "name";
            cbStockMan.DisplayMember = "name";
        }

        // 方法：初始化从表信息
        private void InitailDetail()
        {            
            //供应商
            cbProvider.DataSource = sparePartInStockDB.GetProviderInfo();
            cbProvider.ValueMember = "id";
            cbProvider.DisplayMember = "name";

            //设置计划明细的DataGridView
            dgvDetail.DataSource = sparePartInStockDB.GetSparePartInStockDetail(0);
            dgvDetail.Columns["id"].Visible = false;
            dgvDetail.Columns["spaId"].Visible = false;
            dgvDetail.Columns["spbiId"].Visible = false;
            dgvDetail.Columns["inputDate"].Visible = false;
            dgvDetail.Columns["inputMan"].Visible = false;

            dgvDetail.Columns["storage"].Visible = false;
            dgvDetail.Columns["position"].Visible = false;

        }

        // 方法：

        #endregion        
        

    }
}
