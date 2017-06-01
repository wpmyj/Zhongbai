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
    public partial class FrmWDSettingEdit : DasherStation.common.BaseForm
    {
        public int ID;

        public FrmWDSettingEdit()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var entity = new WDSettingLogic().GetByID((long)this.ID);
            this.txtNo.Text = entity.no;
            this.txtName.Text = entity.name;
            this.txtPosition.Text = entity.position;
            this.txtMin.Text = entity.minTemperature.ToString();
            this.txtMax.Text = entity.maxTemperature.ToString();
            this.txtMemo.Text = entity.remark;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtMin.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("温度下限值不能为空!");
                this.DialogResult = DialogResult.None;
                return;
            }
            if (this.txtMax.Text.Trim() == "")
            {
                DasherStation.HumanResource.CommUI.AlertError("温度上限值不能为空!");
                this.DialogResult = DialogResult.None;
                return;
            }
            decimal tem;
            if (decimal.TryParse(this.txtMin.Text.Trim(), out tem) == false)
            {
                DasherStation.HumanResource.CommUI.AlertError("温度下限值不是有效数值!");
                this.DialogResult = DialogResult.None;
                return;
            }
            if (decimal.TryParse(this.txtMax.Text.Trim(), out tem) == false)
            {
                DasherStation.HumanResource.CommUI.AlertError("温度上限值不是有效数值!");
                this.DialogResult = DialogResult.None;
                return;
            }
            TemperatureNo entity = new TemperatureNo();
            entity.id = this.ID;
            entity.name = this.txtName.Text.Trim();
            entity.position = this.txtPosition.Text.Trim();
            entity.minTemperature = decimal.Parse(this.txtMin.Text.Trim());
            entity.maxTemperature = decimal.Parse(this.txtMax.Text.Trim());
            entity.remark = this.txtMemo.Text;
            new WDSettingLogic().Edit(entity);     
        }
    }
}
