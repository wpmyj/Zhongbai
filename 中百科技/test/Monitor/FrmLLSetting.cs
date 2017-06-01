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
    public partial class FrmLLSetting : DasherStation.common.BaseForm
    {
        public FrmLLSetting()
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
            this.dtgList.DataSource = new LLSettingLogic().GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtNo.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("流量编码不能为空!");
                return;
            }
            if (this.txtName.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("流量名称不能为空!");
                return;
            }
            FlowmeterNo entity = new FlowmeterNo();
            entity.no = this.txtNo.Text.Trim();
            entity.name = this.txtName.Text.Trim();
            entity.position = this.txtPosition.Text.Trim();
            entity.inputMan = this.UserName;            
            entity.remark = this.txtMemo.Text;
            string strResult = new LLSettingLogic().Add(entity);
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
                               select (int)(item.DataBoundItem as FlowmeterNo).id).ToArray();
                    new LLSettingLogic().Remove(ids);
                    this.BindList();
                }
            }
            else
            {
                DasherStation.HumanResource.CommUI.AlertError("请选择记录!");
            }      
        }

        private void FrmLLSetting_Load(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dtgList.SelectedRows.Count == 0)
            {
                DasherStation.HumanResource.CommUI.AlertError("请选择一条记录!");
                return;
            }
            var frmEdit = new FrmLLSettingEdit();
            frmEdit.id = (int)(this.dtgList.SelectedRows[0].DataBoundItem as FlowmeterNo).id;
            var result = frmEdit.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.BindList();
            }
        }
    }

    

}
