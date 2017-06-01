/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：FrmHandWeighing.cs
* 文件功能描述：手工称重
*
* 创建人：袁宇
* 创建时间：2009-02-20
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
using DasherStation.common;

namespace DasherStation.metage
{
    public partial class FrmHandWeighing : BaseForm
    {
        long recordId;
        WeighingLogic weighingLogic = new WeighingLogic();
        string style = "";

        public FrmHandWeighing()
        {
            InitializeComponent();
        }       

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (radioButton2.Checked)
            {
                //label1.ForeColor = Color.Tomato;
                style = WeighingStyle.InStyle;
                CBSB.Enabled = false;
                CBProjectName.Enabled = false;
                RadioChanged();
                ClearValue();
                this.BackgroundImage = DasherStation.Properties.Resources._1;
            }   
        }
        private void InitForm()
        {
            //取车牌号列表
            weighingLogic.GetTruckNoItem(ref CBTruckNo);
            //取设备信息
            weighingLogic.GetEquipmentItem(ref CBSB);
            //取运输合同
            //weighingLogic.GetTransportContract(ref CBTransportContract);
            //启运地  止运地
            weighingLogic.GetSite(ref CBSite1);
            weighingLogic.GetSite(ref CBSite2);
            //时间
            dateTimePicker1.Text = DateTime.Now.ToString();
            //工程项目
            weighingLogic.GetProjectName(ref CBProjectName);
            //仓库信息 
            weighingLogic.GetWarehouseInfo(ref CBWarehouseInfo);

            OtherWeighingLogic logic = new OtherWeighingLogic();
            logic.SetPersonnelInfo(ref CBPersonnelInfo);
            //取得合同
            RadioChanged();            

        }
        private void RadioChanged()
        {
            //采购销售合同
            weighingLogic.GetContractItem(style, ref CBContract);
            //
            weighingLogic.GetTransportInfo(style, ref CBTransportContract);
        }

        private void FrmHandWeighing_Load(object sender, EventArgs e)
        {
            //初始化窗体
            InitForm();
        }
        private void ClearValue()
        {
            weighingLogic.ClearCombobox("1", ref groupBox3);
            textGrossWeight.Text = "";
            textTare.Text = "";
            textSuttle.Text = "";
            button4.Enabled = false;
            recordId = -1;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (radioButton1.Checked)
            {
                //label1.ForeColor = Color.Green;
                style = WeighingStyle.OutStyle;
                CBSB.Enabled = true;
                CBProjectName.Enabled = true;
                RadioChanged();
                ClearValue();
                this.BackgroundImage = DasherStation.Properties.Resources._3;
            } 
        }
        private InWeighingClass SetInValue()
        {
            InWeighingClass info = new InWeighingClass();

            info.IId = CBName.SelectedValue == null ? "" : CBName.SelectedValue.ToString();
            info.GrossWeight = textGrossWeight.Text;
            info.Tare = textTare.Text;
            info.Suttle = textSuttle.Text;
            //info.AsphaltumSuttle = textAsphaltum.Text;
            //info.Surveyor = lblSurveyor.Text;
            info.ViId = CBTruckNo.SelectedValue == null ? "" : CBTruckNo.SelectedValue.ToString();
            info.SId1 = CBSite1.SelectedValue == null ? "" : CBSite1.SelectedValue.ToString();
            info.SId2 = CBSite2.SelectedValue == null ? "" : CBSite2.SelectedValue.ToString();
            //info.HydrousImpurityRate = textHSL.Text;
            info.InputDate = DateTime.Now.ToString();
            info.BarCode = CBBarCode.Text;
            info.ComputationMark = "2";
            //if (Check.CheckFloat(textHSL.Text))
            //    info.ComputationMark = "1";
            //else
            //    info.ComputationMark = "0";            
            info.Remark = CBRemark.Text;
            info.TgicId = CBTransportContract.SelectedValue == null ? "" : CBTransportContract.SelectedValue.ToString();
            info.UnloadTime = label11.Text;
            info.PiId3 = CBPersonnelInfo.SelectedValue == null ? "" : CBPersonnelInfo.SelectedValue.ToString();
            info.WiId = CBWarehouseInfo.SelectedValue == null ? "" : CBWarehouseInfo.SelectedValue.ToString();
            info.BatchNumber = CBBatchNumber.Text;
            info.BatchNo = CBBatchNo.Text;
            return info;
        }
        private OutWeighingClass SetOutValue()
        {
            OutWeighingClass info = new OutWeighingClass();

            info.IId = CBName.SelectedValue.ToString();
            info.GrossWeight = textGrossWeight.Text;
            info.Tare = textTare.Text;
            info.Suttle = textSuttle.Text;
            //info.Surveyor = lblSurveyor.Text;
            info.ViId = CBTruckNo.SelectedValue == null?"":CBTruckNo.SelectedValue.ToString();
            info.SId1 = CBSite1.SelectedValue == null ? "" : CBSite1.SelectedValue.ToString();
            info.SId2 = CBSite2.SelectedValue == null ? "" : CBSite2.SelectedValue.ToString();
            info.InputDate = DateTime.Now.ToString();
            info.BarCode = CBBarCode.Text;
            info.ComputationMark = "2";
            //if (Check.CheckFloat(textHSL.Text))
            //    info.ComputationMark = "1";
            //else
            //    info.ComputationMark = "0";
            info.EiId = CBSB.SelectedValue == null ? "" : CBSB.SelectedValue.ToString();
            info.PnId = CBProjectName.SelectedValue == null ? "" : CBProjectName.SelectedValue.ToString();
            info.Remark = CBRemark.Text;
            info.TgicId = CBTransportContract.SelectedValue == null ? "" : CBTransportContract.SelectedValue.ToString();
            info.LoadTime = label11.Text;
            info.PiId3 = CBPersonnelInfo.SelectedValue == null ? "" : CBPersonnelInfo.SelectedValue.ToString(); 
            return info;

        }
        private void SaveInfo()
        {
            if (MessageBox.Show("是否确定保存数据", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string str = "";
                switch (style)
                {
                    case WeighingStyle.OutStyle:
                        OutWeighingClass outInfo = new OutWeighingClass();
                        outInfo = SetOutValue();
                        str = IsFull();
                        if (str.Trim().Equals(""))
                        {
                            if (weighingLogic.SaveOutInfo(outInfo,out recordId))
                            {
                                MessageBox.Show("保存成功", "提示");
                                if (Check.CheckFloat(lblSuttle.Text))
                                    button4.Enabled = true;                                
                            }
                            else
                                MessageBox.Show("保存失败，请再次确认", "提示");
                        }
                        else
                            MessageBox.Show(str);
                        break;
                    case WeighingStyle.InStyle:
                        InWeighingClass inInfo = new InWeighingClass();
                        inInfo = SetInValue();
                        str = IsFull();

                        if (str.Trim().Equals(""))
                        {
                            if (weighingLogic.SaveInInfo(inInfo,out recordId))
                            {
                                MessageBox.Show("保存成功", "提示");
                                if (Check.CheckFloat(lblSuttle.Text))
                                    button4.Enabled = true;                                
                            }
                            else
                                MessageBox.Show("保存失败，请再次确认", "提示");
                        }
                        else
                            MessageBox.Show(str);
                        break;
                    default:
                        break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }
        private string IsFull()
        {
            string strText = "";

            if (CBTruckNo.Text.Equals(""))
                strText += "车牌号不能为空\n";
            if (CBContract.Text.Equals(""))
                strText += "合同信息不能为空\n";
            if (CBName.Text.Equals(""))
                strText += "产品/材料信息不能为空\n";
            if (textSuttle.Text.Equals(""))
                strText += "净重信息不能为空";
            switch (style)
            {
                case WeighingStyle.InStyle:
                    break;
                case WeighingStyle.OutStyle:
                    if (CBSB.Text.Equals(""))
                        strText += "生产设备名不能为空";
                    break;
                default:
                    break;
            }
            return strText;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCodingAdd frmCodingAdd = new FrmCodingAdd();
            frmCodingAdd.ShowDialog();

            CBBarCode.Text = frmCodingAdd.CodingNo;

            if (recordId != -1)
            {
                switch (style)
                {
                    case WeighingStyle.InStyle:
                        InWeighingClass info1 = new InWeighingClass();
                        InWeighingDBLayer dbLayer1 = new InWeighingDBLayer();

                        info1.Id = recordId.ToString();
                        info1.BarCode = frmCodingAdd.CodingNo;
                        if (dbLayer1.UpdateInfo(info1))
                        {
                            ClearValue();
                            CBTruckNo.SelectedIndex = -1;
                        }
                        else
                            MessageBox.Show("条码保存有问题！");
                        break;
                    case WeighingStyle.OutStyle:
                        OutWeighingClass info2 = new OutWeighingClass();
                        OutWeighingDBLayer dbLayer2 = new OutWeighingDBLayer();

                        info2.Id = recordId.ToString();
                        info2.BarCode = frmCodingAdd.CodingNo;
                        if (dbLayer2.UpdateInfo(info2))
                        {
                            ClearValue();
                            CBTruckNo.SelectedIndex = -1;
                        }
                        else
                            MessageBox.Show("条码保存有问题！");
                        break;
                    default:
                        break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            ClearValue();
        }

        private void CBContract_TextChanged(object sender, EventArgs e)
        {
            if ((CBContract.SelectedIndex >= 0) && (!CBContract.ValueMember.Equals("")))
            {
                weighingLogic.SetProvider(style, CBContract.SelectedValue.ToString(), ref CBProvider);
                weighingLogic.SetGoodsName(style, CBContract.SelectedValue.ToString(), ref CBName);
            }
            else
            {
                CBProvider.Text = "";
                CBName.Text = "";
            }
        }

        private void CBTruckNo_TextChanged(object sender, EventArgs e)
        {
            if (!CBTruckNo.Text.Trim().Equals(""))
            {
                ClearValue();
                CBOwner.Text = weighingLogic.GetOwner(CBTruckNo.Text);
                DataTable dt = new DataTable();
                if (CBTruckNo.SelectedValue != null)
                {
                    dt = weighingLogic.FindWeighingInfo(style, CBTruckNo.SelectedValue.ToString());
                    if ((dt != null) && (dt.Rows.Count > 0))
                    {
                        //CBTruckNo.Text = dt.Rows[0]["no"].ToString();
                        CBContract.Text = dt.Rows[0]["ContractName"].ToString();
                        CBName.Text = dt.Rows[0]["goodsName"].ToString() + dt.Rows[0]["goodsModel"].ToString();
                        CBTransportContract.Text = dt.Rows[0]["transportinfo"].ToString();
                        CBSite1.Text = dt.Rows[0]["site1"].ToString();
                        CBSite2.Text = dt.Rows[0]["site2"].ToString();
                        lblGrossWeight.Text = dt.Rows[0]["grossWeight"].ToString();
                        lblTare.Text = dt.Rows[0]["tare"].ToString();
                        lblSuttle.Text = dt.Rows[0]["suttle"].ToString();
                        CBBarCode.Text = dt.Rows[0]["barCode"].ToString();
                        switch (style)
                        {
                            //case WeighingStyle.InStyle:
                            //    textAsphaltum.Text = dt.Rows[0]["asphaltumSuttle"].ToString();
                            //    break;
                            case WeighingStyle.OutStyle:
                                CBProjectName.Text = dt.Rows[0]["projectName"].ToString() + dt.Rows[0]["position"].ToString();
                                CBSB.Text = dt.Rows[0]["equipmentName"].ToString();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            else
                CBOwner.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textGrossWeight_TextChanged(object sender, EventArgs e)
        {
            if ((!textGrossWeight.Text.Trim().Equals("")) && (!textTare.Text.Trim().Equals("")))
            {
                if ((Check.CheckFloat(textGrossWeight.Text)) && (Check.CheckFloat(textTare.Text)))
                {
                    textSuttle.Text = (Convert.ToDouble(textGrossWeight.Text) - Convert.ToDouble(textTare.Text)).ToString();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CBTruckNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
