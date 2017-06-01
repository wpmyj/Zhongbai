/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：FrmSparePartStockPlan.cs
 * 文件功能描述：备品配件采购计划 窗体
 *
 * 创建人：关启学
 * 创建时间：2009-03-23
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
    public partial class FrmSparePartStockPlan : common.BaseForm
    {

        #region//参数初始化

        // “备品配件采购计划”数据库操作对象
        private SparePartStockPlanDB sparePartStockPlanDB = new SparePartStockPlanDB();

        // 构造方法
        public FrmSparePartStockPlan()
        {
            InitializeComponent();
        }

        #endregion


        #region//窗体事件

        // 事件：窗体加载事件
        private void FrmSparePartStockPlan_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;

            SearchSparePartStockPlan();
            SearchSparePartStockPlanDetial();

        }
           
        // 事件：“新建按钮”点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSparePartStockPlanDetail frm = new FrmSparePartStockPlanDetail(this.userName);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                chbxAll.Checked = true;
                SearchSparePartStockPlan();

                // 查询并选中刚刚新建的“采购计划”
                foreach (DataGridViewRow row in dgvOverall.Rows)
                {
                    if (frm.SparePartStockPlanId == Convert.ToInt64(row.Cells["id"].Value.ToString()))
                    {
                        row.Selected = true;
                        dgvOverall.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }

            }
        }

        // 事件：“查询按钮”点击事件
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchSparePartStockPlan();
        }

        // 事件：“删除按钮”点击事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSparePartStockPlan();
        }

        // 事件：主表选中记录变更事件
        private void dgvOverall_SelectionChanged(object sender, EventArgs e)
        {
            SearchSparePartStockPlanDetial();
        }

        // 事件：chbxAll状态改变时间，影响查询条件
        private void chbxAll_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = !chbxAll.Checked;
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

            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.SparePartStockPlanDataSetTableAdapters.basicInfoTableAdapter", "basicInfo", null));
            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.SparePartStockPlanDataSetTableAdapters.sparePartStockPlanTableAdapter", "sparePartStockPlan", new object[] { planId }));
            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.SparePartStockPlanDataSetTableAdapters.sparePartStockPlanDetailTableAdapter", "sparePartStockPlanDetail", new object[] { planId }));



            reportData.DataSetName = "DasherStation.dataSet.SparePartStockPlanDataSet";
            reportData.ReportName = "DasherStation.Report.SparePartStockPlanReport.rdlc";

            reportData.ReportSourceList = reportSourceList;

            reportServer.ShowReport(reportData);

        }

        #endregion
        

        #region//事件处理方法

        // 方法：查询全部“备品配件采购计划”
        private void SearchSparePartStockPlan()
        {
            if (chbxAll.Checked)
            {
                dgvOverall.DataSource = sparePartStockPlanDB.GetSparePartStockPlan();
            }
            else
            {
                dgvOverall.DataSource = sparePartStockPlanDB.GetSparePartStockPlan(dateTimePicker1.Value);
            }

            dgvOverall.Columns["inputMan"].Visible = false;
            dgvOverall.Columns["inputDate"].Visible = false;
            dgvOverall.Columns["departmentId"].Visible = false;
        }
        
        // 方法：根据设备使用记录中选中的记录，查询该记录的详细信息
        private void SearchSparePartStockPlanDetial()
        {
            long spspId = 0;
            if (dgvOverall.SelectedRows.Count > 0)
            {
                spspId = Convert.ToInt64(dgvOverall.SelectedRows[0].Cells["id"].Value.ToString());

            }

            //“设备信息明细”DataGridView数据源绑定
            dgvDetail.DataSource = sparePartStockPlanDB.GetSparePartStockPlanDetail(spspId);
            dgvDetail.Columns["id"].Visible = false;
            dgvDetail.Columns["spbiId"].Visible = false;
            dgvDetail.Columns["spspId"].Visible = false;
            dgvDetail.Columns["inputDate"].Visible = false;
            dgvDetail.Columns["inputMan"].Visible = false;

        }
        
        // 方法：删除“设备使用记录”方法
        private void DeleteSparePartStockPlan()
        {
            if (dgvOverall.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否要删除选中的“设备使用记录？”", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    long equipmentRepairPlanId = Convert.ToInt64(dgvOverall.SelectedRows[0].Cells["id"].Value.ToString());
                    sparePartStockPlanDB.DeleteSparePartStockPlan(equipmentRepairPlanId);

                    SearchSparePartStockPlan();
                }
            }

        }

        #endregion

        

    }
}
