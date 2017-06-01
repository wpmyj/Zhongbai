/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：FrmEquipmentUse.cs
 * 文件功能描述：设备使用记录 窗体
 *
 * 创建人：关启学
 * 创建时间：2009-03-20
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
    public partial class FrmEquipmentUse : common.BaseForm
    {
        
        #region//参数初始化

        // “设备使用记录”数据库操作对象
        private EquipmnetUseDB equipmentDB = new EquipmnetUseDB();
        
        // 构造方法
        public FrmEquipmentUse()
        {
            InitializeComponent();
        }

        #endregion


        #region//窗体事件

        // 事件：窗体加载事件
        private void FrmEquipmentUse_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;
            
            cbEquipmentNo.DataSource = equipmentDB.GetEquipmentInfo();
            cbEquipmentNo.DisplayMember = "no";
            cbEquipmentNo.ValueMember = "id";
            cbEquipmentNo.SelectedIndex = -1;


            SearchEquipmentUse();
            SearchEquipmentUseDetial();  
        }

        // 事件：“查询按钮”点击事件
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEquipmentUse();
        }

        // 事件：“新建按钮”点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmEquipmentUseDetail frm = new FrmEquipmentUseDetail(this.userName);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                chbxAll.Checked = true;
                SearchEquipmentUse();

                foreach (DataGridViewRow row in dgvUseOverall.Rows)
                {
                    if (frm.EquipmentUseId == Convert.ToInt64(row.Cells["id"].Value.ToString()))
                    {
                        row.Selected = true;
                        dgvUseOverall.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
        }

        // 事件：“删除按钮”点击事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteEquipmentUse();
        }

        // 事件：“保存按钮”点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)(dgvUseDetial.DataSource);

            equipmentDB.SaveEquipmentUseDetail(dt);
        }

        // 事件：chbxNoCondition选中事件
        private void chbxNoCondition_CheckedChanged(object sender, EventArgs e)
        {
            cbEquipmentNo.Enabled = !chbxAll.Checked;
            dateTimePicker1.Enabled = !chbxAll.Checked;
        }

        // 事件：“设备使用记录”中选中的记录变化事件
        private void dgvUseOverall_SelectionChanged(object sender, EventArgs e)
        {
            SearchEquipmentUseDetial();
            SumWorkTime();
        }

        // 事件：“子表数据”变化事件
        private void dgvUseDetial_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SumWorkTime();
        }

        // 事件：“打印按钮”点击事件，报表打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportHelper reportServer = new ReportHelper();
            ReportData reportData = new ReportData();
            List<ReportSource> reportSourceList = new List<ReportSource>();

            long uId = 0;
            if (dgvUseOverall.SelectedRows.Count > 0)
            {
                uId = Convert.ToInt64(dgvUseOverall.SelectedRows[0].Cells["id"].Value.ToString());

            }

            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.EquipmentUseDataSetTableAdapters.basicInfoTableAdapter", "basicInfo", null));
            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.EquipmentUseDataSetTableAdapters.equipmentUseTableAdapter", "equipmentUse", new object[] { uId }));
            reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.EquipmentUseDataSetTableAdapters.equipmentTableAdapter", "equipment", new object[] { uId }));


            reportData.DataSetName = "DasherStation.dataSet.EquipmentUseDataSet";
            reportData.ReportName = "DasherStation.Report.EquipmentUseReport.rdlc";

            reportData.ReportSourceList = reportSourceList;

            reportServer.ShowReport(reportData);
        }


        #endregion


        #region//事件处理方法

        // 方法：查询全部“设备使用记录”
        private void SearchEquipmentUse()
        {
            if (chbxAll.Checked)
            {
                dgvUseOverall.DataSource = equipmentDB.GetEquipmentUse();
            }
            else
            {
                dgvUseOverall.DataSource = equipmentDB.GetEquipmentUse(dateTimePicker1.Value, cbEquipmentNo.Text);
            }

            dgvUseOverall.Columns["inputMan"].Visible = false;
            dgvUseOverall.Columns["inputDate"].Visible = false;
            dgvUseOverall.Columns["id"].Visible = false;
            dgvUseOverall.Columns["eiId"].Visible = false;
        }        
        
        // 方法：根据设备使用记录中选中的记录，查询该记录的详细信息
        private void SearchEquipmentUseDetial()
        {
            long euId = 0;
            if (dgvUseOverall.SelectedRows.Count > 0)
            {
                euId = Convert.ToInt64(dgvUseOverall.SelectedRows[0].Cells["id"].Value.ToString());
                
            }

            //“设备信息明细”DataGridView内“操作员”下拉列表内容绑定
            this.operateMan.DataSource = equipmentDB.GetPersonnelInfo();
            this.operateMan.DisplayMember = "name";
            this.operateMan.ValueMember = "id";

            //“设备信息明细”DataGridView数据源绑定
            dgvUseDetial.DataSource = equipmentDB.GetEquipmentUseDetail(euId);

            dgvUseDetial.Columns["inputMan"].Visible = false;
            dgvUseDetial.Columns["inputDate"].Visible = false;
            dgvUseDetial.Columns["id"].Visible = false;
            dgvUseDetial.Columns["euId"].Visible = false;

        }        

        // 方法：删除“设备使用记录”方法
        private void DeleteEquipmentUse()
        {
            if (dgvUseOverall.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否要删除选中的“设备使用记录？”", "警告",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    long equipmentUseId = Convert.ToInt64(dgvUseOverall.SelectedRows[0].Cells["id"].Value.ToString());
                    equipmentDB.DeleteEquipmentUse(equipmentUseId);

                    SearchEquipmentUse(); 
                }
            }            

        }
        
        // 方法：计算所选中的月份的“当月累计台时”
        private void SumWorkTime()
        {
            if (dgvUseOverall.SelectedRows.Count > 0)
            {                
                string timeStr = "";
                long sum = 0;
                long time = 0;

                foreach (DataGridViewRow row in dgvUseDetial.Rows)
                {
                    timeStr = row.Cells["workTime"].Value.ToString();
                    if (Int64.TryParse(timeStr,out time))
                    {
                        sum += time;
                    }
                }
                dgvUseOverall.SelectedRows[0].Cells["workTimeSum"].Value = sum;
            } 
        }        

        #endregion

        

    }
}
