/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：FrmSparePartInStockDetail.cs
 * 文件功能描述：备品配件入库单明细 窗体
 *
 * 创建人：关启学
 * 创建时间：2009-03-25
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
    public partial class FrmSparePartInStockDetail : common.BaseForm
    {

        #region//参数初始化

        // “备品配件入库单”数据库操作对象
        private SparePartInStockDB sparePartInStockDB = new SparePartInStockDB();

        // “备品配件入库单”实体对象
        private SparePartInStock sparePartInStock = new SparePartInStock();

        // “备品配件”实体对象
        private SparePart sparePart;

        // 用于该子窗体关闭后，其父窗体能够访问在子窗体加入的设备保修计划id值
        public long SparePartInStockId
        {
            get { return sparePartInStock.Id; }
        }

        // 构造方法
        public FrmSparePartInStockDetail()
        {
            InitializeComponent();
        }

        // 构造方法
        public FrmSparePartInStockDetail(string inputMan)
        {
            InitializeComponent();
            this.userName = inputMan;
        }

        #endregion


        #region//窗体事件

        // 事件：窗体加载事件
        private void FrmSparePartInStockDetail_Load(object sender, EventArgs e)
        {
            InitialOverall();
            InitailDetail();
        }

        // 事件：“新建明细按钮”点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDetailRow();
            ClearDetail();
        }

        // 事件：“删除明细按钮”点击事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteDetailRow();
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

            //如果不存在该条记录，就插入
            DataTable dt = (DataTable)(dgvDetail.DataSource);
            sparePartInStockDB.InsertSparePartInStock(sparePartInStock, dt);


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 事件：“备品配件编码下拉列表”下拉提交事件
        private void cbSparePartNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SearchSparePartInfo();
        }



        //  避免金额与单价改动时，相互影响各自的计算
        private bool computeUnitPrice = true;

        // 事件：根据金额和数量计算单价
        private void tbTotalPrice_TextChanged(object sender, EventArgs e)
        {
            computeUnitPrice = true;
            ComputeUnitPrice();
            computeUnitPrice = false;
        }

        // 事件：根据单价和数量计算金额
        private void tbUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (!computeUnitPrice)
            {
                ComputeTotalPrice();
            }
        }

        // 事件：根据金额和数量计算单价
        private void tbCount_TextChanged(object sender, EventArgs e)
        {
            computeUnitPrice = true;
            ComputeUnitPrice();
            computeUnitPrice = false;
        }


        #endregion


        #region//事件处理方法

        // 方法：初始化主表信息
        private void InitialOverall()
        {
            dtpStockDate.MaxDate = DateTime.Now;
            
            //供应商
            cbProvider.DataSource = sparePartInStockDB.GetProviderInfo();
            cbProvider.ValueMember = "id";
            cbProvider.DisplayMember = "name";

            //采购人
            cbStockMan.DataSource = sparePartInStockDB.GetPersonnelInfo();
            cbStockMan.ValueMember = "name";
            cbStockMan.DisplayMember = "name";            
        }

        // 方法：初始化子表信息
        private void InitailDetail()
        {
            //物料信息
            cbSparePartNo.DataSource = sparePartInStockDB.GetSparePartInfo();
            cbSparePartNo.ValueMember = "id";
            cbSparePartNo.DisplayMember = "no";
            SearchSparePartInfo();

            //设置计划明细的DataGridView
            dgvDetail.DataSource = sparePartInStockDB.GetSparePartInStockDetail(0);
            dgvDetail.Columns["id"].Visible = false;
            dgvDetail.Columns["spaId"].Visible = false;
            dgvDetail.Columns["spbiId"].Visible = false;
            dgvDetail.Columns["inStockCount"].Visible = false;
            dgvDetail.Columns["inStockUnitPrice"].Visible = false;
            dgvDetail.Columns["inStockTotalPrice"].Visible = false;
            dgvDetail.Columns["inputDate"].Visible = false;
            dgvDetail.Columns["inputMan"].Visible = false;

            dgvDetail.Columns["storage"].Visible = false;
            dgvDetail.Columns["position"].Visible = false;

        }

        // 方法：根据“备品配件id”，查询“备品配件”的“名称”、“种类”和“规格”，并赋予相应的控件进行表示
        private void SearchSparePartInfo()
        {
            sparePart = sparePartInStockDB.GetSparePart(Convert.ToInt64(cbSparePartNo.SelectedValue.ToString()));
            tbSparePartName.Text = sparePart.Name;
            tbSparePartSort.Text = sparePart.Sort;
            tbSparePartModel.Text = sparePart.Model;
        }

        // 方法：从表添加记录
        private void AddDetailRow()
        {
            DataTable dt = (DataTable)(dgvDetail.DataSource);

            

            DataRow row = dt.NewRow();
            row["sparePartNo"] = cbSparePartNo.Text;
            row["sparePartName"] = tbSparePartName.Text;
            row["sparePartSort"] = tbSparePartSort.Text;
            row["sparePartModel"] = tbSparePartModel.Text;
            row["producer"] = tbProducer.Text;
            row["contactMan"] = tbContactMan.Text;
            row["contactMethod"] = tbContactMethod.Text;
            row["storage"] = tbStorage.Text;
            row["position"] = tbPosition.Text;

            long i = 0;
            if (tbCount.Text != "")
            {
                i = Convert.ToInt64(tbCount.Text);
            }
            row["count"] = i;

            decimal d = 0;
            if (tbUnitPrice.Text != "")
            {
                d = Convert.ToDecimal(tbUnitPrice.Text);
            }
            row["unitPrice"] = d;

            d = 0;
            if (tbTotalPrice.Text != "")
            {
                d = Convert.ToDecimal(tbTotalPrice.Text);
            }
            row["totalPrice"] = d;

            row["inputMan"] = this.userName;
            row["spbiId"] = Convert.ToInt64(cbSparePartNo.SelectedValue.ToString());

            dt.Rows.Add(row);
        }

        // 方法：清空为从表提供数据的控件内容，以便于下一次的新增记录
        private void ClearDetail()
        {
            cbSparePartNo.SelectedIndex = 0;
            SearchSparePartInfo();

            tbProducer.Text = "";
            tbContactMan.Text = "";
            tbContactMethod.Text = "";
            tbCount.Text = "";
            tbUnitPrice.Text = "";
            tbTotalPrice.Text = "";
            tbStorage.Text = "";
            tbPosition.Text = "";
        }

        // 方法：从表现层view获得后面绑定的数据层model源
        private void DeleteDetailRow()
        {
            if (dgvDetail.SelectedRows.Count > 0)
            {
                DataTable dt = (DataTable)(dgvDetail.DataSource);
                DataRowView rowView = dgvDetail.CurrentRow.DataBoundItem as DataRowView;
                DataRow row = rowView.Row;

                dt.Rows.Remove(row);
            }
        }

        // 方法：计算入库金额，根据入库数量和入库单价
        private void ComputeTotalPrice()
        {
            long quantity = 0;
            decimal tPrice = 0;
            decimal uPrice = 0;

            if (long.TryParse(tbCount.Text.Trim() , out quantity) && decimal.TryParse(tbUnitPrice.Text.Trim(), out uPrice))
            {
                tPrice = quantity * uPrice;
            }

            tbTotalPrice.Text = tPrice.ToString();
        }

        // 方法：计算入库单价，根据入库数量和入库金额
        private void ComputeUnitPrice()
        {
            long quantity = 0;
            decimal tPrice = 0;
            decimal uPrice = 0;

            if (long.TryParse(tbCount.Text.Trim(), out quantity) && decimal.TryParse(tbTotalPrice.Text.Trim(), out tPrice))
            {
                if (quantity != 0)
                {
                    uPrice = tPrice / quantity;
                }                
            }

            tbUnitPrice.Text = uPrice.ToString();
        }

        #endregion


        
    }
}
