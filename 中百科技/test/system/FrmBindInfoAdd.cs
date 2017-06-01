using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using DasherStation.metage;

namespace DasherStation.system
{
    public partial class FrmBindInfoAdd : common.BaseForm
    {
        

        private BindInfoLogic logicLayer = new BindInfoLogic();
        //标注窗体模式，0 为 新建窗体 1 : 补卡窗体
        private int formMode = 0;
        //运输单位信息
        private string unit;
        //车牌号信息
        private string truckNo;
        //卡号
        private string cardNo;
        public int FormMode
        {
            get { return formMode; }
            set { formMode = value; }
        }
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        public string TruckNo
        {
            get { return truckNo; }
            set { truckNo = value; }
        }

        public FrmBindInfoAdd()
        {
            InitializeComponent();
        }
        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindInfoLogic dil = new BindInfoLogic();

            CBCardNo.Text = dil.CreateCardNo();
            button1.Enabled = true;
        }

        private void FrmBindInfoAdd_Load(object sender, EventArgs e)
        {
            logicLayer.SetTransportUnit(ref CBUnit);
            logicLayer.SetVoitureNo(ref CBNo, "");
            //如果是补卡窗体，则对数据进行处理
            if (formMode.Equals(1))
            {
                CBUnit.Text = unit;
                CBNo.Text = truckNo;
                CBCardNo.Text = cardNo;
            }
        }    

        private void CBUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            logicLayer.SetVoitureNo(ref CBNo, CBUnit.Text);
        }

        private void CBNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CBNo.Text.Equals(""))
            {
                BindInfoClass bindInfo = new BindInfoClass();
                bindInfo = logicLayer.GetTruckInfo(CBNo.Text);
                CBName.Text = bindInfo.Owner;
                CBModel.Text = bindInfo.Model;
                CBColor.Text = bindInfo.Color;
                CBLength.Text = bindInfo.Lenth;
                CBWidth.Text = bindInfo.Width;
                CBHeight.Text = bindInfo.Heigth;
                CBTare.Text = bindInfo.Tare;
                CBStandardTare.Text = bindInfo.StandardTare;
                CBDeadWeight.Text = bindInfo.StandardDeadWeight;
                rtbRemark.AppendText(bindInfo.Remark);
            }
            else
            {
                logicLayer.ClearCombobox("1", ref groupBox1);
                rtbRemark.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (logicLayer.WriteCard(CBCardNo.Text))
            {
                string Str = "";

                if (CBNo.Text.Trim().Equals(""))
                    Str += "车辆号不能为空\n";
                if (CBCardNo.Text.Trim().Equals(""))
                    Str += "卡号未生成\n";
                if (Str.Trim().Equals(""))
                {
                    logicLayer.BindCardNo(CBNo.SelectedValue.ToString(), CBCardNo.Text);
                    MessageBox.Show("写卡完成");
                }
                else
                    MessageBox.Show(Str + "\n请输认后操作");
            }
            else
                MessageBox.Show("写卡不成功，请检查设备");

            button1.Enabled = false;

        }
    }
}
