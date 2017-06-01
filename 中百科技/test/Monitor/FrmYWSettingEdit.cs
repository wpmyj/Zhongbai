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
    public partial class FrmYWSettingEdit : DasherStation.common.BaseForm
    {
        public int ID;

        public FrmYWSettingEdit()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var entity = new YWSettingLogic().GetByID((long)this.ID);
            this.txtNo.Text = entity.no;
            this.txtName.Text = entity.name;
            this.txtPosition.Text = entity.position;
            this.txtMin.Text = entity.minValue.ToString();
            this.txtMax.Text = entity.maxValue.ToString();
            this.txtMemo.Text = entity.remark;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtMin.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("最小液位值不能为空!");
                this.DialogResult = DialogResult.None;
                return;
            }
            if (this.txtMax.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("最大液位值不能为空!");
                this.DialogResult = DialogResult.None;
                return;
            }
            decimal tem;
            if (decimal.TryParse(this.txtMin.Text.Trim(), out tem) == false)
            {
                DasherStation.HumanResource.CommUI.AlertError("最小液位值不是有效数值!");
                this.DialogResult = DialogResult.None;
                return;
            }
            if (decimal.TryParse(this.txtMax.Text.Trim(), out tem) == false)
            {
                DasherStation.HumanResource.CommUI.AlertError("最大液位值不是有效数值!");
                this.DialogResult = DialogResult.None;
                return;
            }
            LiquidPositionNo entity = new LiquidPositionNo();
            entity.id = this.ID;
            entity.name = this.txtName.Text.Trim();
            entity.position = this.txtPosition.Text.Trim();            
            entity.minValue = decimal.Parse(this.txtMin.Text.Trim());
            entity.maxValue = decimal.Parse(this.txtMax.Text.Trim());
            entity.remark = this.txtMemo.Text;
            new YWSettingLogic().Edit(entity);            
        }
    }
}
