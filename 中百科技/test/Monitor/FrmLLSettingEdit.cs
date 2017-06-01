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
    public partial class FrmLLSettingEdit : DasherStation.common.BaseForm
    {
        public long id;
        public FrmLLSettingEdit()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var entity = new LLSettingLogic().QueryByID(this.id);
            this.txtNo.Text = entity.no;
            this.txtName.Text = entity.name;
            this.txtPosition.Text = entity.position;
            this.txtMemo.Text = entity.remark;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("流量名称不能为空!");
                this.DialogResult = DialogResult.None;
                return;
            }
            FlowmeterNo entity = new FlowmeterNo();
            entity.id = this.id;
            entity.no = this.txtNo.Text.Trim();
            entity.name = this.txtName.Text.Trim();
            entity.position = this.txtPosition.Text.Trim();
            entity.inputMan = this.UserName;
            entity.remark = this.txtMemo.Text;
            new LLSettingLogic().Update(entity);
            DasherStation.HumanResource.CommUI.MsgOK();                
            
        }
    }
}
