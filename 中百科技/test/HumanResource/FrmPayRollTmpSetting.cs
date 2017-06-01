using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.HumanResource
{
    public partial class FrmPayRollTmpSetting : DasherStation.common.BaseForm
    {
        public FrmPayRollTmpSetting()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtTemplateName.Text.Trim()))
            {
                CommUI.MsgOK("模板名称不能为空!");
                this.txtTemplateName.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }
            SalaryItemTemplet entity = new SalaryItemTemplet();
            FrmReadyPayOff pWin = this.Owner.ActiveMdiChild as FrmReadyPayOff;
            //被选中的工资项
            var chkBoxs = pWin.panPayRoll_flp.Controls.OfType<CheckBox>().Where(p=>p.Checked==true);
            //数据库中有多少个工资项字段
            var pItems = entity.GetType().GetProperties().Where(p => p.Name.StartsWith("item"));
            if(chkBoxs.Count() > pItems.Count())
            {
                CommUI.AlertError("您选的工资项太多,数据库不能存储,请偿试减少工资项!");
                return;
            }
            //设置工资模板的工资项
            for (int i = 0; i < chkBoxs.Count(); i++)
            {
                pItems.ElementAt(i).SetValue(entity, chkBoxs.ElementAt(i).Text, null);
            }
            
            entity.name = this.txtTemplateName.Text.Trim();
            entity.inputDate = DateTime.Now;
            entity.inputMan = this.UserName;
            string strResult = new PayRollTemplateLogic().AddTemplate(entity);
            if (string.IsNullOrEmpty(strResult))
            {
                //CommUI.MsgOK();
            }
            else
            {
                CommUI.AlertError(strResult);
            }
        }        
    }



}
