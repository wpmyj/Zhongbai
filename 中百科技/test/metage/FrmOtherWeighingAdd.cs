using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.metage
{
    public partial class FrmOtherWeighingAdd : BaseForm
    {
        OtherWeighingLogic logic = new OtherWeighingLogic();
        public FrmOtherWeighingAdd()
        {
            InitializeComponent();
        }
        private void InitForm()
        {
            logic.SetPersonnelInfo(ref CBWeighMan);
            dtpDate.Text = DateTime.Now.ToString();
        }
        private string isFull()
        {
            string str = "";
            if (CBName.Text.Trim().Equals(""))
                str += "货物名称不能为空\n";
            if (CBModel.Text.Trim().Equals(""))
                str += "货物名称不能为空\n";
            if (CBTruckNo.Text.Trim().Equals(""))
                str += "车牌号码不能为空\n";
            if (CBClientName.Text.Trim().Equals(""))
                str += "客户信息不能为空\n";
            if (CBSuttle.Text.Trim().Equals(""))
                str += "净重数量不能为空\n";
            if (!Check.CheckFloat(CBExpenditure.Text))
                str += "检斤费用要输入数字型\n";
            if (!Check.CheckFloat(CBGrossWeight.Text))
                str += "毛重要输入数字型\n";
            if (!Check.CheckFloat(CBTare.Text))
                str += "皮重要输入数字型\n";
            if (!Check.CheckFloat(CBSuttle.Text))
                str += "净重要输入数字型\n";
            return str;
        }
        private OtherweighingClass GetValue()
        {
            OtherweighingClass info = new OtherweighingClass();

            info.Name = CBName.Text;
            info.Model = CBModel.Text;
            info.No = CBTruckNo.Text;
            info.Client = CBClientName.Text;
            info.Date = dtpDate.Value.ToString();
            info.Money = CBExpenditure.Text;
            info.PiId = CBWeighMan.SelectedValue == null ? "" : CBWeighMan.SelectedValue.ToString();
            info.GrossWeight = CBGrossWeight.Text;
            info.Tare = CBTare.Text;
            info.Suttle = CBSuttle.Text;

            return info;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定保存数据", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string temp = isFull();
                if (temp.Trim().Equals(""))
                {
                    OtherweighingClass info = GetValue();
                    if (logic.saveData(info))
                    {
                        MessageBox.Show("保存成功");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("保存失败");
                }
                else
                    MessageBox.Show(temp);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CBGrossWeight_TextChanged(object sender, EventArgs e)
        {
            if ((Check.CheckFloat(CBGrossWeight.Text)) && (Check.CheckFloat(CBTare.Text)))
            {
                if ((!CBGrossWeight.Text.Trim().Equals("")) && (!CBTare.Text.Trim().Equals("")))
                    CBSuttle.Text = (Convert.ToDouble(CBGrossWeight.Text) - Convert.ToDouble(CBTare.Text)).ToString();
            }
        }
    }
}
