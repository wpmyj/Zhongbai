/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：FrmEquipmentUseDetail.cs
 * 文件功能描述：设备使用记录明细 窗体
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

namespace DasherStation.equipment
{
    public partial class FrmEquipmentUseDetail : common.BaseForm
    {
        #region//参数初始化

        // “设备使用记录”数据库操作对象
        private EquipmnetUseDB equipmentDB = new EquipmnetUseDB();

        // “设备使用记录”实体对象
        private EquipmentUse equipmentUse = new EquipmentUse();

        // 用于该子窗体关闭后，其父窗体能够访问在子窗体加入的设备使用记录id值
        public long EquipmentUseId
        {
            get { return equipmentUse.Id; }
        }

        // 构造方法
        public FrmEquipmentUseDetail()
        {
            InitializeComponent();
        }

        // 构造方法：将打开父窗体的“用户名”传入该子窗体，以便数据库记录“录入人”数据项
        public FrmEquipmentUseDetail(string inputMan)
        {
            InitializeComponent();
            this.userName = inputMan;
        }

        #endregion


        #region//窗体事件

        // 事件：窗体加载事件
        private void FrmEquipmentUseDetail_Load(object sender, EventArgs e)
        {
            cbEquipmentNo.DataSource = equipmentDB.GetEquipmentInfo();
            cbEquipmentNo.DisplayMember = "no";
            cbEquipmentNo.ValueMember = "id";

            tbEquipmentName.Text = equipmentDB.GetEquipmentName(Convert.ToInt64(cbEquipmentNo.SelectedValue.ToString()));
        }

        // 事件：“保存按钮”点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;

            equipmentUse.Date = dateTimePicker1.Value;
            equipmentUse.EiId = Convert.ToInt64(cbEquipmentNo.SelectedValue.ToString());
            equipmentUse.No = tbDocumentNo.Text;
            equipmentUse.InputMan = this.userName;

            //如果不存在该条记录，就插入
            equipmentDB.InsertEquipmentUse(equipmentUse);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 事件：“关闭按钮”点击事件
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        // 事件：“设备编号下拉列表”下拉提交事件
        private void cbEquipmentNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbEquipmentName.Text = equipmentDB.GetEquipmentName(Convert.ToInt64(cbEquipmentNo.SelectedValue.ToString()));
        }

        #endregion

       
    }
}
