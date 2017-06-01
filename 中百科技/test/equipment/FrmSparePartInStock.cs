/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：FrmSparePartInStock.cs
 * 文件功能描述：备品配件入库单 窗体
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


using DasherStation.common;

namespace DasherStation.equipment
{
    public partial class FrmSparePartInStock : common.BaseForm
    {

        #region//参数初始化

        // “备品配件入库单”数据库操作对象
        private SparePartInStockDB sparePartInStockDB = new SparePartInStockDB();

        // “备品配件入库单”实体对象，在关闭窗体时，用于返回所选中的“备品配件入库”信息
        public SparePartInStock sparePartInStock = new SparePartInStock(); 

        // “备品配件入库单”查询条件对象
        private SparePartInStockSeacher seacher = new SparePartInStockSeacher();

        // 构造方法
        public FrmSparePartInStock()
        {
            InitializeComponent();
        }

        // 构造方法(用于账务，根据入库单id查询入库单明细)
        public FrmSparePartInStock(long id)
        {
            InitializeComponent();

            gbOverall.Location = new Point(9, 12);
            gbOverall.Size = new Size(697, 185);
            dgvOverall.Location = new Point(3, 15);

            gbDetail.Location = new Point(9, 12 + gbOverall.Location.Y + gbOverall.Size.Height);

            this.Height = gbDetail.Location.Y + gbDetail.Size.Height + 45;
            
            //gbDetail.Size = new Size((this.Size.Width - 10 * 2),(this.Size.Height - 30 * 2));
            //gbDetail.Anchor = AnchorStyles.Bottom;
            //gbDetail.Location = new Point(9,12);

            tbInStockId.Text = id.ToString();
            SearchSparePartInStock();

        }

        #endregion


        #region//窗体事件

        // 事件：窗体加载事件
        private void FrmSparePartInStock_Load(object sender, EventArgs e)
        {
            dtpBegin.MaxDate = DateTime.Today;
            dtpEnd.MaxDate = DateTime.Today;

            BindCombroBox();

            SearchSparePartInStock();
            SearchSparePartInStockDetail();
        }

        // 事件：“查询按钮”点击事件
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchSparePartInStock();
        }

        // 事件：“新建按钮”点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSparePartInStockDetail frm = new FrmSparePartInStockDetail(this.userName);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                chbxInStockId.Checked = true;
                SearchSparePartInStock();

                foreach (DataGridViewRow row in dgvOverall.Rows)
                {
                    if (frm.SparePartInStockId == Convert.ToInt64(row.Cells["id"].Value.ToString()))
                    {
                        row.Selected = true;
                        dgvOverall.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }

            }
        }

        // 事件：“选择按钮”点击事件，记录所选择的备品配件的入库信息，并关闭窗体
        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;

            if (dgvOverall.SelectedRows.Count > 0)
            {
                sparePartInStock.Id = Convert.ToInt64(dgvOverall.SelectedRows[0].Cells["id"].Value.ToString());
                sparePartInStock.InvoiceNo = dgvOverall.SelectedRows[0].Cells["invoiceNo"].Value.ToString();
                sparePartInStock.StockDate = (DateTime)(dgvOverall.SelectedRows[0].Cells["stockDate"].Value);
                sparePartInStock.StockMan = dgvOverall.SelectedRows[0].Cells["stockMan"].Value.ToString();
                sparePartInStock.PiId = Convert.ToInt64(dgvOverall.SelectedRows[0].Cells["providerId"].Value.ToString());
                sparePartInStock.Remark = dgvOverall.SelectedRows[0].Cells["remark"].Value.ToString();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 事件：主表选中记录变换事件
        private void dgvOverall_SelectionChanged(object sender, EventArgs e)
        {
            SearchSparePartInStockDetail();
        }

        // 事件：chbxInStockId状体变化时间，影响查询条件
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

        //事件：“审核按钮”点击事件
        private void btnAssess_Click(object sender, EventArgs e)
        {
            long id = 0;
            if (dgvOverall.SelectedRows.Count > 0)
            {
                id = Convert.ToInt64(dgvOverall.SelectedRows[0].Cells["id"].Value.ToString());
                sparePartInStockDB.SetAssessor(id, this.userName);
                SearchSparePartInStock();
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

                SearchSparePartInStock();
            }
        }

        // 事件：“打印按钮”点击事件
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportHelper reportServer = new ReportHelper();
            ReportData reportData = new ReportData();
            List<ReportSource> reportSourceList = new List<ReportSource>();

            long planId = 0;
            if (dgvOverall.SelectedRows.Count > 0)
            {
                planId = Convert.ToInt64(dgvOverall.SelectedRows[0].Cells["id"].Value.ToString());

            }

            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.SparePartInStockDataSetTableAdapters.basicInfoTableAdapter", "basicInfo", null));
            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.SparePartInStockDataSetTableAdapters.SparePartInStockTableAdapter", "SparePartInStock", new object[] { planId }));
            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.SparePartInStockDataSetTableAdapters.SparePartInStockDetailTableAdapter", "SparePartInStockDetail", new object[] { planId }));



            reportData.DataSetName = "DasherStation.dataSet.SparePartInStockDataSet";
            reportData.ReportName = "DasherStation.Report.SparePartInStockReport.rdlc";

            reportData.ReportSourceList = reportSourceList;

            reportServer.ShowReport(reportData);

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

        // 方法：查询全部“备品配件采购计划”
        private void SearchSparePartInStock()
        {
            if (chbxInStockId.Checked)
            {
                long inStockId = 0;
                if (long.TryParse(tbInStockId.Text, out inStockId))
                {
                    dgvOverall.DataSource = sparePartInStockDB.GetSparePartInStock(inStockId);
                }
                else
                {
                    dgvOverall.DataSource = sparePartInStockDB.GetSparePartInStock();
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

                dgvOverall.DataSource = sparePartInStockDB.GetSparePartInStock(seacher);
            }

            dgvOverall.Columns["inputMan"].Visible = false;
            dgvOverall.Columns["inputDate"].Visible = false;
            dgvOverall.Columns["providerId"].Visible = false;
            dgvOverall.Columns["parentId"].Visible = false;
        }

        // 方法：根据设备使用记录中选中的记录，查询该记录的详细信息
        private void SearchSparePartInStockDetail()
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

        // 方法：隐藏窗体中的“审核”、“审批”和“新建”按钮，并显示“选择”按钮
        public void HideButtons()
        {
            btnSelect.Visible = true;
            btnAdd.Visible = false;
            
        }
        
        #endregion

        

        

    }
}
