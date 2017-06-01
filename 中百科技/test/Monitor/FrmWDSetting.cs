using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.Monitor
{
    public partial class FrmWDSetting : DasherStation.common.BaseForm
    {
        public FrmWDSetting()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.BindList();
        }

        private void BindList()
        {
            this.dtgList.AutoGenerateColumns = false;
            this.dtgList.DataSource = new WDSettingLogic().GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtNo.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("编码不能为空!");
                return;
            }
            if (this.txtName.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("名称不能为空!");
                return;
            }
            if (this.txtPosition.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("存放位置不能为空!");
                return;
            }
            if (this.txtMin.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("温度下限值不能为空!");
                return;
            }
            if (this.txtMax.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("温度上限值不能为空!");
                return;
            }
            decimal tem;
            if (decimal.TryParse(this.txtMin.Text.Trim(), out tem) == false)
            {
                DasherStation.HumanResource.CommUI.AlertError("温度下限值不是有效数值!");
                return;
            }
            if (decimal.TryParse(this.txtMax.Text.Trim(), out tem) == false)
            {
                DasherStation.HumanResource.CommUI.AlertError("温度上限值不是有效数值!");
                return;
            }
            TemperatureNo entity = new TemperatureNo();
            entity.no = this.txtNo.Text.Trim();
            entity.name = this.txtName.Text.Trim();
            entity.position = this.txtPosition.Text.Trim();
            entity.inputMan = this.UserName;
            entity.minTemperature = decimal.Parse(this.txtMin.Text.Trim());
            entity.maxTemperature = decimal.Parse(this.txtMax.Text.Trim());
            entity.remark = this.txtMemo.Text;
            string strResult = new WDSettingLogic().Add(entity);
            if (string.IsNullOrEmpty(strResult) == false)
            {
                DasherStation.HumanResource.CommUI.AlertError(strResult);
            }
            else
            {
                //DasherStation.HumanResource.CommUI.MsgOK();
                this.txtNo.Text = "";
                this.txtName.Text = "";
                this.txtPosition.Text = "";
                this.txtMin.Text = "";
                this.txtMax.Text = "";
                this.txtMemo.Text = "";
                this.BindList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {            
            if (this.dtgList.SelectedRows.Count > 0)
            {
                if (DasherStation.HumanResource.CommUI.Confirm("确认要删除吗?") == DialogResult.OK)
                {
                    var ids = (from DataGridViewRow item in dtgList.SelectedRows
                               select (int)(item.DataBoundItem as TemperatureNo).id).ToArray();
                    new WDSettingLogic().Remove(ids);
                    this.BindList();
                }
            }
            else
            {
                DasherStation.HumanResource.CommUI.AlertError("请选择记录!");
            }            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dtgList.SelectedRows.Count == 0)
            {
                DasherStation.HumanResource.CommUI.AlertError("请选择一条记录!");
                return;
            }
            var frmEdit = new FrmWDSettingEdit();
            frmEdit.ID = (int)(this.dtgList.SelectedRows[0].DataBoundItem as TemperatureNo).id;
            var result = frmEdit.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.BindList();
            }
        }
    }

   

   
}
