/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：FrmEquipmentRepairPlan.cs
 * 文件功能描述：设备保修计划 窗体
 *
 * 创建人：关启学
 * 创建时间：2009-03-18
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
    public partial class FrmEquipmentRepairPlan : common.BaseForm
    {
        
        #region//初始化方法

        // “设备使用计划”数据库操作对象
        private EquipmentRepairPlanDB euipmentRepairPlanDB = new EquipmentRepairPlanDB();

        // 构造方法
        public FrmEquipmentRepairPlan()
        {
            InitializeComponent();
        }        

        #endregion


        #region//窗体事件

        // 事件：窗体加载事件
        private void FrmEquipmentRepairPlan_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;

            SearchEquipmentRepairPlan();
            SearchEquipmentRepairPlanDetial();

        }

        // 事件：“查询按钮”点击事件
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEquipmentRepairPlan();
        }

        // 事件：“新建按钮”点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
             FrmEquipmentRepairPlanDetail frm = new FrmEquipmentRepairPlanDetail(this.userName);
             if (frm.ShowDialog() == DialogResult.OK)
             {
                 chbxAll.Checked = true;
                 SearchEquipmentRepairPlan();

                 foreach (DataGridViewRow row in dgvOverall.Rows)
                 {
                     if (frm.EquipmentRepairPlanId == Convert.ToInt64(row.Cells["id"].Value.ToString()))
                     {
                         row.Selected = true;
                         dgvOverall.FirstDisplayedScrollingRowIndex = row.Index;
                         break;
                     }
                 }

             }
        }

        // 事件：“删除按钮”点击事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteEquipmentRepairPlan();
        }

        // 事件：“审核按钮”点击事件
        private void btnAssess_Click(object sender, EventArgs e)
        {

        }

        // 事件：“审批按钮”点击事件
        private void btnCheck_Click(object sender, EventArgs e)
        {

        }

        // 事件：主表中选中记录改变事件
        private void dgvOverall_SelectionChanged(object sender, EventArgs e)
        {
            SearchEquipmentRepairPlanDetial();
        }

        // 事件：checkbox状态改变事件
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

            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.EquipmentRepairDataSetTableAdapters.basicInfoTableAdapter", "basicInfo", null));
            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.EquipmentRepairDataSetTableAdapters.EquipmentRepairPlanTableAdapter","EquipmentRepairPlan", new object[]{planId}));

            

            reportData.DataSetName = "DasherStation.dataSet.EquipmentRepairDataSet";
            reportData.ReportName = "DasherStation.Report.EquipmentRepairPlanReport.rdlc";

            reportData.ReportSourceList = reportSourceList;

            reportServer.ShowReport(reportData);

        }

        #endregion


        #region//事件处理方法

        // 方法：查询主表数据，查询全部“设备保修计划”
        private void SearchEquipmentRepairPlan()
        {
            if (chbxAll.Checked)
            {
                dgvOverall.DataSource = euipmentRepairPlanDB.GetEquipmentRepairPlan();
            }
            else
            {
                dgvOverall.DataSource = euipmentRepairPlanDB.GetEquipmentRepairPlan(dateTimePicker1.Value);
            }

            dgvOverall.Columns["inputMan"].Visible = false;
            dgvOverall.Columns["inputDate"].Visible = false;
            dgvOverall.Columns["id"].Visible = false;
        }

        // 方法：查询子表数据，根据设备使用记录中选中的记录，查询该记录的详细信息
        private void SearchEquipmentRepairPlanDetial()
        {
            long erpId = 0;
            if (dgvOverall.SelectedRows.Count > 0)
            {
                erpId = Convert.ToInt64(dgvOverall.SelectedRows[0].Cells["id"].Value.ToString());

            }

            //“设备信息明细”DataGridView数据源绑定
            dgvDetail.DataSource = euipmentRepairPlanDB.GetEquipmentRepairPlanDetail(erpId);
            dgvDetail.Columns["id"].Visible = false;
            dgvDetail.Columns["eiId"].Visible = false;
            dgvDetail.Columns["erpId"].Visible = false;
            dgvDetail.Columns["departmentId"].Visible = false;
            dgvDetail.Columns["inputDate"].Visible = false;
            dgvDetail.Columns["inputMan"].Visible = false;

        }
        
        // 方法：删除业务实体，删除“设备使用记录”方法
        private void DeleteEquipmentRepairPlan()
        {
            if (dgvOverall.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否要删除选中的“设备使用记录？”", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    long equipmentRepairPlanId = Convert.ToInt64(dgvOverall.SelectedRows[0].Cells["id"].Value.ToString());
                    euipmentRepairPlanDB.DeleteEquipmentRepairPlan(equipmentRepairPlanId);

                    SearchEquipmentRepairPlan();
                }
            }

        }

        #endregion

        

        

    }
}
