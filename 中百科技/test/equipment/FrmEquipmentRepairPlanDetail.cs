/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：FrmEquipmentRepairPlanDetail.cs
 * 文件功能描述：设备保修计划明细 窗体
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

namespace DasherStation.equipment
{
    public partial class FrmEquipmentRepairPlanDetail : common.BaseForm
    {

        #region//初始化方法

        // “设备使用计划”数据库操作对象
        private EquipmentRepairPlanDB equipmentRepairPlanDB = new EquipmentRepairPlanDB();

        // “设备使用计划”实体对象
        private EquipmentRepairPlan equipmentRepairPlan = new EquipmentRepairPlan();

        //用于该子窗体关闭后，其父窗体能够访问在子窗体加入的设备保修计划id值
        public long EquipmentRepairPlanId
        {
            get { return equipmentRepairPlan.Id; }
        }


        // 构造方法
        public FrmEquipmentRepairPlanDetail()
        {
            InitializeComponent();
        }
        
        // 构造方法
        public FrmEquipmentRepairPlanDetail(string inputMan)
        {
            InitializeComponent();
            this.userName = inputMan;
        } 

        #endregion


        #region//窗体事件

        // 事件：窗体加载事件
        private void FrmEquipmentRepairPlanDetail_Load(object sender, EventArgs e)
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

        // 事件：“保存计划按钮”点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;

            equipmentRepairPlan.Date = dtpPlanDate.Value;
            equipmentRepairPlan.DId = Convert.ToInt64(cbDocumentNo.SelectedValue.ToString());
            equipmentRepairPlan.Producer = tbProducer.Text;
            equipmentRepairPlan.InputMan = this.userName;


            //如果不存在该条记录，就插入
            DataTable dt = (DataTable)(dgvDetail.DataSource);
            equipmentRepairPlanDB.InsertEquipmentRepairPlan(equipmentRepairPlan, dt);


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 事件：“文档编号下拉列表”下拉提交事件
        private void cbDocumentNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbDocumentName.Text = equipmentRepairPlanDB.GetDocumentName(Convert.ToInt64(cbDocumentNo.SelectedValue.ToString()));
        }

        // 事件：“设备编号下拉列表”下拉提交事件
        private void cbEquipmentNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbEquipmentName.Text = equipmentRepairPlanDB.GetEquipmentName(Convert.ToInt64(cbEquipmentNo.SelectedValue.ToString()));
        }

        #endregion


        #region//事件处理方法

        // 方法：初始化主表数据方法
        private void InitialOverall()
        {
            tbProducer.Text = this.userName;

            //文档编号、名称
            cbDocumentNo.DataSource = equipmentRepairPlanDB.GetDocument();
            cbDocumentNo.ValueMember = "id";
            cbDocumentNo.DisplayMember = "no";
            tbDocumentName.Text = equipmentRepairPlanDB.GetDocumentName(Convert.ToInt64(cbDocumentNo.SelectedValue.ToString()));
        }

        // 方法：初始化从表数据方法
        private void InitailDetail()
        {
            //设备编号、名称
            cbEquipmentNo.DataSource = equipmentRepairPlanDB.GetEquipmentInfo();
            cbEquipmentNo.ValueMember = "id";
            cbEquipmentNo.DisplayMember = "no";
            tbEquipmentName.Text = equipmentRepairPlanDB.GetEquipmentName(Convert.ToInt64(cbEquipmentNo.SelectedValue.ToString()));

            //主修人
            cbRepaireMan.DataSource = equipmentRepairPlanDB.GetPersonnelInfo();
            cbRepaireMan.ValueMember = "name";
            cbRepaireMan.DisplayMember = "name";

            //使用部门
            cbDepartment.DataSource = equipmentRepairPlanDB.GetDepartment();
            cbDepartment.ValueMember = "id";
            cbDepartment.DisplayMember = "name";

            //保修类别
            cbServiceKind.SelectedIndex = 0;

            //上次保修类别
            cbPreviousServiceKind.SelectedIndex = 0;

            //设置计划明细的DataGridView
            dgvDetail.DataSource = equipmentRepairPlanDB.GetEquipmentRepairPlanDetail(0);
            dgvDetail.Columns["id"].Visible = false;
            dgvDetail.Columns["eiId"].Visible = false;
            dgvDetail.Columns["erpId"].Visible = false;
            dgvDetail.Columns["departmentId"].Visible = false;
            dgvDetail.Columns["inputDate"].Visible = false;
            dgvDetail.Columns["inputMan"].Visible = false;

        }

        // 方法：新建从表记录
        private void AddDetailRow()
        {
            DataTable dt = (DataTable)(dgvDetail.DataSource);

            //相同编号的设备在同一个计划中不能出现两次以上
            foreach(DataRow r in dt.Rows)
            {
                if (r["equipmentNo"].ToString().Equals(cbEquipmentNo.Text))
                {
                    MessageBox.Show("编号“" + cbEquipmentNo.Text + "”的设备已经计划产生计划！不能再次计划！");
                    return;
                }
            }
            
            
            
            
            DataRow row = dt.NewRow();
            row["equipmentNo"] = cbEquipmentNo.Text;
            row["equipmentName"] = tbEquipmentName.Text;
            row["departmentName"] = cbDepartment.Text;
            row["serviceKind"] = cbServiceKind.Text;
            row["workTime"] = tbWorkTime.Text;
            row["repairTime"] = tbRepairTime.Text;

            decimal planConsume = 0;
            if (tbPlanConsume.Text != "")
            {
                planConsume = Convert.ToDecimal(tbPlanConsume.Text);
            }
            row["planConsume"] = planConsume;

            row["repairMan"] = cbRepaireMan.SelectedValue.ToString();
            row["finishDate"] = dtpFinshDate.Value;
            row["previousRepairDate"] = dtpPreviousRepairDate.Value;
            row["previousServiceKind"] = cbPreviousServiceKind.Text;
            row["inputMan"] = this.userName;
            row["departmentId"] = Convert.ToInt64(cbDepartment.SelectedValue.ToString());
            row["eiId"] = Convert.ToInt64(cbEquipmentNo.SelectedValue.ToString());
            //row["erpId"] =

            dt.Rows.Add(row);
        }

        // 方法：清除子表控件中的内容
        private void ClearDetail()
        {
            cbEquipmentNo.SelectedIndex = 0;
            tbEquipmentName.Text = equipmentRepairPlanDB.GetEquipmentName(Convert.ToInt64(cbEquipmentNo.SelectedValue.ToString())); 

            cbDepartment.SelectedIndex = 0;
            cbServiceKind.SelectedIndex = 0;
            tbWorkTime.Text = "";
            tbRepairTime.Text = "";
            tbPlanConsume.Text = "";
            cbRepaireMan.SelectedIndex = 0;
            dtpFinshDate.Value = DateTime.Now;
            dtpPreviousRepairDate.Value = DateTime.Now;
            cbPreviousServiceKind.SelectedIndex = 0;

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

        #endregion

       
    }
}
