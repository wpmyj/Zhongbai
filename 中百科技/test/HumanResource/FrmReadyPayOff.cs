/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：FrmReadyPayOff.cs
* 文件功能描述：人力资源工资发放窗体
*
* 创建人： 杨林
* 创建时间：2009-03-05
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

namespace DasherStation.HumanResource
{
    public partial class FrmReadyPayOff : DasherStation.common.BaseForm
    {
        /// <summary>
        /// 全部工资项
        /// </summary>
        private PayRollItem[] payRollItems = new PayOffLogic().GetPayRollItems();

        public FrmReadyPayOff()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.panPayRoll_flp.SuspendLayout();
            foreach (PayRollItem item in payRollItems)
            {
                CheckBox chkItem = new CheckBox();                
                chkItem.Text = item.Name;
                chkItem.Tag = item;
                this.panPayRoll_flp.Controls.Add(chkItem);
            }
            this.panPayRoll_flp.ResumeLayout();
            this.InitTemplate();
        }

        private void InitTemplate()
        {
            string[] strResult = new PayRollTemplateLogic().GetAllTemplateName();
            this.cboRollTemplate.DataSource = strResult;            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.CheckForm())
            {
                DialogResult result = new FrmPayRollTmpSetting().ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    new DasherStation.common.FormTools().showFrom(this.MdiParent, new FrmPayOff());
                }
            }
        }

        private void cboRollTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var allCheck = this.panPayRoll_flp.Controls.OfType<CheckBox>();
            foreach (var chk in allCheck)
            {
                chk.Checked = false;
            }
            if(this.cboRollTemplate.Items.Count > 0)
            {
                var result = new PayRollTemplateLogic().GetTemplateByName(this.cboRollTemplate.Text);
                //数据库中有多少个工资项字段
                var pItems = result.GetType().GetProperties().Where(p => p.Name.StartsWith("item"));
                for (int i = 0; i < pItems.Count(); i++)
                {
                    //取出工资项名称
                    var strName = pItems.ElementAt(i).GetValue(result, null);
                    if (strName != null)
                    {
                        //找到工资项名称与chkbox的名子相同的项,选中它.
                        var chkBox = this.panPayRoll_flp.Controls.OfType<CheckBox>().Where(p => p.Text == strName.ToString()).First();
                        if (chkBox != null)
                        {
                            chkBox.Checked = true;
                        }
                    }
                }
            }
        }

        private void btnOK2_Click(object sender, EventArgs e)
        {
            if (this.CheckForm())
            {
                new DasherStation.common.FormTools().showFrom(this.MdiParent, new FrmPayOff());
            }
        }

        private bool CheckForm()
        {
            var chkBoxs = panPayRoll_flp.Controls.OfType<CheckBox>().Where(p => p.Checked == true);
            if (chkBoxs.Count() == 0)
            {
                CommUI.AlertError("请您选择至少一个要发放的工资项!");
                return false;
            }
            //没有选择增项
            var bIsAllMinus = panPayRoll_flp.Controls.OfType<CheckBox>().Where(p => p.Checked == true && (p.Tag as PayRollItem).IsMinus == false).Count() == 0;
            if (bIsAllMinus)
            {
                CommUI.AlertError("您目前选择的工资项无法发放,请再选择能够发放的工资项!");
                return false;
            }
            string[] strInsuranceItems = new string[] { "养老保险", "医疗保险", "失业保险", "医疗大额保险", "住房公积金", "扣税" };
            //选中保险了,但没有选"基本工资"提示不能发放.
            bool bChkedInsurance = (from control in panPayRoll_flp.Controls.OfType<CheckBox>()
                                    where strInsuranceItems.Contains(control.Text) && control.Checked == true
                                    select control).Count() > 0;
            if (bChkedInsurance == true)
            {
                var chkBase = (from control in panPayRoll_flp.Controls.OfType<CheckBox>()
                               where control.Text == "基本工资"
                               select control).FirstOrDefault();
                if (chkBase == null)
                {
                    CommUI.AlertError("没有基本工资项,不能发放工资!");
                    return false;
                }
                if (chkBase.Checked == false)
                {
                    if (CommUI.Confirm("发放保险或扣税必须选择基本工资项!") != DialogResult.OK)
                    {
                        return false;
                    }
                    else
                    {
                        chkBase.Checked = true;
                    }
                }
            }
            return true;
        }
    }
}
