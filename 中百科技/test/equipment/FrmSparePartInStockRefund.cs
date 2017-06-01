/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：FrmSparePartInStockRefund.cs
 * 文件功能描述：备品配件退货单 窗体
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
    public partial class FrmSparePartInStockRefund : common.BaseForm
    {

        #region//参数初始化

        // “备品配件退货单”数据库操作类
        private SparePartInStockDB sparePartInStockDB = new SparePartInStockDB();

        // “备品配件退货单”查询对象
        private SparePartInStockSeacher seacher = new SparePartInStockSeacher();

        // 构造方法
        public FrmSparePartInStockRefund()
        {
            InitializeComponent();
        }

        #endregion


        #region//窗体事件

        // 事件：窗体加载事件
        private void FrmSparePartInStockRefund_Load(object sender, EventArgs e)
        {
            dtpBegin.MaxDate = DateTime.Today;
            dtpEnd.MaxDate = DateTime.Today;

            BindCombroBox();

            SearchSparePartInStockRefund();
            SearchSparePartInStockRefundDetail();
        }

        // 事件：“查询按钮”点击事件
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchSparePartInStockRefund();
        }

        // 事件：“新建按钮”点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSparePartInStockRefundDetail frm = new FrmSparePartInStockRefundDetail(this.userName);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                chbxInStockId.Checked = true;
                SearchSparePartInStockRefund();

                foreach (DataGridViewRow row in dgvOverall.Rows)
                {
                    if (frm.SparePartInStockRefundId == Convert.ToInt64(row.Cells["id"].Value.ToString()))
                    {
                        row.Selected = true;
                        dgvOverall.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }

            }
        }

        // 事件：chbxInStockId状体改变事件，影响查询的条件
        private void chbxInStockId_CheckedChanged(object sender, EventArgs e)
        {
            tbInStockId.Enabled = chbxInStockId.Checked;
            tbInStockId.Text = "";

            dtpBegin.Enabled = !chbxInStockId.Checked;
            dtpEnd.Enabled = !chbxInStockId.Checked;

            cbStockMan.Enabled = !chbxInStockId.Checked;
            cbStockMan.Text = "";
            cbProvider.Enabled = !chbxInStockId.Checked;
            cbProvider.Text = "";

            cbSparePartNo.Enabled = !chbxInStockId.Checked;
            cbSparePartNo.Text = "";
            cbSparePartName.Enabled = !chbxInStockId.Checked;
            cbSparePartName.Text = "";
            cbSparePartSort.Enabled = !chbxInStockId.Checked;
            cbSparePartSort.Text = "";
            cbSparePartModel.Enabled = !chbxInStockId.Checked;
            cbSparePartModel.Text = "";

        }

        // 事件：主表选中记录变化事件
        private void dgvOverall_SelectionChanged(object sender, EventArgs e)
        {
            SearchSparePartInStockRefundDetail();
        }

        //事件：“审核按钮”点击事件
        private void btnAssess_Click(object sender, EventArgs e)
        {
            long id = 0;
            if (dgvOverall.SelectedRows.Count > 0)
            {
                id = Convert.ToInt64(dgvOverall.SelectedRows[0].Cells["id"].Value.ToString());
                sparePartInStockDB.SetAssessor(id, this.userName);
                SearchSparePartInStockRefund();
            }
        }

        //事件：“审批按钮”点击事件
        private void btnCheckup_Click(object sender, EventArgs e)
        {
            long id = 0;
            if (dgvOverall.SelectedRows.Count > 0)
            {
                id = Convert.ToInt64(dgvOverall.SelectedRows[0].Cells["id"].Value.ToString());
                DasherStation.common.FrmConfirm frm = new DasherStation.common.FrmConfirm();
                frm.ShowDialog();
                if (frm.Confirm)
                {
                    sparePartInStockDB.SetCheckupMan(id, this.userName);
                }
                else
                {
                    sparePartInStockDB.SetCheckupMan(id, "null");
                }

                SearchSparePartInStockRefund();
            }
        }

        #endregion


        #region//事件处理方法

        // 方法：初始化查询条件的所有下拉列表
        private void BindCombroBox()
        {
            //物料编码
            cbSparePartNo.DataSource = sparePartInStockDB.GetSparePartNo();
            cbSparePartNo.DisplayMember = "no";
            cbSparePartNo.ValueMember = "no";
            cbSparePartNo.Text = "";

            //物料名称
            cbSparePartName.DataSource = sparePartInStockDB.GetSparePartName();
            cbSparePartName.DisplayMember = "name";
            cbSparePartName.ValueMember = "name";
            cbSparePartName.Text = "";

            //物料种类
            cbSparePartSort.DataSource = sparePartInStockDB.GetSparePartSort();
            cbSparePartSort.DisplayMember = "sort";
            cbSparePartSort.ValueMember = "sort";
            cbSparePartSort.Text = "";

            //物料规格型号
            cbSparePartModel.DataSource = sparePartInStockDB.GetSparePartModel();
            cbSparePartModel.DisplayMember = "model";
            cbSparePartModel.ValueMember = "model";
            cbSparePartModel.Text = "";

            //采购人名称
            cbStockMan.DataSource = sparePartInStockDB.GetPersonnelName();
            cbStockMan.DisplayMember = "name";
            cbStockMan.ValueMember = "name";
            cbStockMan.Text = "";

            //供应商名称
            cbProvider.DataSource = sparePartInStockDB.GetProviderName();
            cbProvider.DisplayMember = "name";
            cbProvider.ValueMember = "name";
            cbProvider.Text = "";

        }

        // 方法：查询全部“备品配件退货记录”
        private void SearchSparePartInStockRefund()
        {
            if (chbxInStockId.Checked)
            {
                long inStockId = 0;
                if (long.TryParse(tbInStockId.Text, out inStockId))
                {
                    dgvOverall.DataSource = sparePartInStockDB.GetSparePartInStockRefund(inStockId);
                }
                else
                {
                    dgvOverall.DataSource = sparePartInStockDB.GetSparePartInStockRefund();
                }

            }
            else
            {
                seacher.StockDateBegin = dtpBegin.Value;
                seacher.StockDateEnd = dtpEnd.Value;

                seacher.StockMan = cbStockMan.Text.Trim();
                seacher.ProviderName = cbProvider.Text.Trim();

                seacher.SparePartNo = cbSparePartNo.Text.Trim();
                seacher.SparePartName = cbSparePartName.Text.Trim();
                seacher.SparePartSort = cbSparePartSort.Text.Trim();
                seacher.SparePartModel = cbSparePartModel.Text.Trim();

                dgvOverall.DataSource = sparePartInStockDB.GetSparePartInStockRefund(seacher);
            }

            dgvOverall.Columns["inputMan"].Visible = false;
            dgvOverall.Columns["inputDate"].Visible = false;
            dgvOverall.Columns["providerId"].Visible = false;
            //dgvOverall.Columns["parentId"].Visible = false;
        }

        // 方法：根据备品配件记录中选中的记录，查询该记录的详细信息
        private void SearchSparePartInStockRefundDetail()
        {
            long spaId = 0;
            if (dgvOverall.SelectedRows.Count > 0)
            {
                spaId = Convert.ToInt64(dgvOverall.SelectedRows[0].Cells["id"].Value.ToString());

            }

            //“设备信息明细”DataGridView数据源绑定
            dgvDetail.DataSource = sparePartInStockDB.GetSparePartInStockDetail(spaId);
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

        #endregion

        
    }
}
