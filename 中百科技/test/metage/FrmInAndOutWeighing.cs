/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：FrmInAndOutWeighing.cs
* 文件功能描述：自动称重
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
using DasherStation.system;
using DasherStation.produce;
//using RDLCPrint;
using System.Collections;
namespace DasherStation.metage
{
    public partial class FrmInAndOutWeighing : BaseForm
    {
        //误差范围 百分比
        const int bound = 1;
        long recordId;
        WeighingLogic weighingLogic = new WeighingLogic();
        string style = "";
        // 实例化一个凯泰读卡接口;
        ICardHelper iCardHelper = CardFactory.Creat();
        int icdev;

        public FrmInAndOutWeighing()
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
                CBWarehouseInfo.Enabled = true;
                CBBatchNumber.Enabled = true;
                RadioChanged();
                ClearValue();
                CBTruckNo.SelectedIndex = -1;
                this.BackgroundImage = DasherStation.Properties.Resources._1;
                dt = weighingLogic.FindWeighingInfo(style, "");
                dataGridView1.DataSource = dt;
            }           
                
        }
        
        private void InitForm()
        {
            //取车牌号列表
            weighingLogic.GetTruckNoItem(ref CBTruckNo);
            //取设备信息
            weighingLogic.GetEquipmentItem(ref CBSB);            
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
            // 未换卡前的初始化串口;
            //-------------------------------------------------------------------------------------------
            //icdev = CardClass.dc_init(0, 9600);      
            //-------------------------------------------------------------------------------------------

            // 换卡后的初始化串口;
            icdev = iCardHelper.Init_Port(0, 9600);
        }
        private void RadioChanged()
        {
            //采购销售合同
            weighingLogic.GetContractItem(style, ref CBContract);
            //取运输合同
            weighingLogic.GetTransportInfo(style, ref CBTransportContract);
            
        }
        private void FrmInAndOutWeighing_Load(object sender, EventArgs e)
        {
            //初始化窗体
            InitForm();
        }
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            //弹出左键菜单
            if (Check.CheckFloat(label1.Text))
                button1.ContextMenuStrip.Show((Button)sender, new Point(e.X, e.Y));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //关闭窗口
            Close();
        }

        private void CBTruckNo_TextChanged(object sender, EventArgs e)
        {            
            //取得
            if ((!CBTruckNo.Text.Trim().Equals("")) && (!CBTruckNo.ValueMember.Equals("")))
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
                        //MessageBox.Show(dt.Rows[0]["transportinfo"].ToString());
                        CBTransportContract.Text = dt.Rows[0]["transportinfo"].ToString();
                        CBSite1.Text = dt.Rows[0]["site1"].ToString();
                        CBSite2.Text = dt.Rows[0]["site2"].ToString();
                        lblGrossWeight.Text = dt.Rows[0]["grossWeight"].ToString();
                        lblTare.Text = dt.Rows[0]["tare"].ToString();
                        lblSuttle.Text = dt.Rows[0]["suttle"].ToString();
                        CBBarCode.Text = dt.Rows[0]["barCode"].ToString();                       

                        switch (style)
                        {
                            case WeighingStyle.InStyle:
                                textAsphaltum.Text = dt.Rows[0]["asphaltumSuttle"].ToString();
                                CBWarehouseInfo.Text = dt.Rows[0]["warehouseName"].ToString();
                                CBBatchNo.Text = dt.Rows[0]["produceNo"].ToString();
                                CBBatchNumber.Text = dt.Rows[0]["batchNumber"].ToString();
                                break;
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
        private void CBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
                CBWarehouseInfo.Enabled = false;
                CBBatchNumber.Enabled = false;
                RadioChanged();
                ClearValue();
                CBTruckNo.SelectedIndex = -1;
                this.BackgroundImage = DasherStation.Properties.Resources._3;
                dt = weighingLogic.FindWeighingInfo(style, "");
                dataGridView1.DataSource = dt;

            } 
        }
        private void ClearValue()
        {
            weighingLogic.ClearCombobox("1", ref groupBox3);
            lblGrossWeight.Text = "";
            lblTare.Text = "";
            lblSuttle.Text = "";
            button4.Enabled = false;
            recordId = -1;
            button2.Enabled = false;
            //CBTruckNo.SelectedIndex = -1;

        }

        private void ToolStrip1_Click(object sender, EventArgs e)
        {
            if ((Check.CheckFloat(label1.Text))&&(!label1.Text.Trim().Equals("")))
            {
                if ((!Check.CheckFloat(lblGrossWeight.Text))||(lblGrossWeight.Text.Trim().Equals("")))
                    lblGrossWeight.Text = "0";
                lblGrossWeight.Text = (Convert.ToDouble(lblGrossWeight.Text) + Convert.ToDouble(label1.Text)).ToString(); 
            }
        }

        private void ToolStrip2_Click(object sender, EventArgs e)
        {
            if ((Check.CheckFloat(label1.Text))&&(!label1.Text.Trim().Equals("")))
            {
                if ((!Check.CheckFloat(lblTare.Text)) || (lblTare.Text.Trim().Equals("")))
                    lblTare.Text = "0";
                lblTare.Text = (Convert.ToDouble(lblTare.Text) + Convert.ToDouble(label1.Text)).ToString();
            }
        }

        private void lblGrossWeight_TextChanged(object sender, EventArgs e)
        {
            if ((Check.CheckFloat(lblGrossWeight.Text)) && (Check.CheckFloat(lblTare.Text)) && (!lblGrossWeight.Text.Trim().Equals("")) && (!lblTare.Text.Trim().Equals("")))
            {
                lblSuttle.Text = (Convert.ToDouble(lblGrossWeight.Text) - Convert.ToDouble(lblTare.Text)).ToString();
                if ((Check.CheckFloat(textHSL.Text)) && (!textHSL.Text.Trim().Equals("")))
                    lblSuttle.Text = (Convert.ToDouble(lblSuttle.Text) - Convert.ToDouble(textHSL.Text)).ToString();
            }
        }

        private void textHSL_TextChanged(object sender, EventArgs e)
        {
            if ((Check.CheckFloat(lblGrossWeight.Text)) && (Check.CheckFloat(lblTare.Text)) && (!lblGrossWeight.Text.Trim().Equals("")) && (!lblTare.Text.Trim().Equals("")))
            {
                lblSuttle.Text = (Convert.ToDouble(lblGrossWeight.Text) - Convert.ToDouble(lblTare.Text)).ToString();
                if ((Check.CheckFloat(textHSL.Text))&& (!textHSL.Text.Trim().Equals("")))
                    lblSuttle.Text = (Convert.ToDouble(lblSuttle.Text) - Convert.ToDouble(textHSL.Text)).ToString();
            }          

        }
        private InWeighingClass SetInValue()
        {
            InWeighingClass info = new InWeighingClass();

            info.IId = CBName.SelectedValue == null ? "" : CBName.SelectedValue.ToString();
            info.GrossWeight = lblGrossWeight.Text;
            info.Tare = lblTare.Text;
            info.Suttle = lblSuttle.Text;
            info.AsphaltumSuttle = textAsphaltum.Text;
            //info.Surveyor = lblSurveyor.Text;
            info.ViId = CBTruckNo.SelectedValue == null ? "" : CBTruckNo.SelectedValue.ToString();
            info.SId1 = CBSite1.SelectedValue == null ? "" : CBSite1.SelectedValue.ToString();
            info.SId2 = CBSite2.SelectedValue == null ? "" : CBSite2.SelectedValue.ToString();
            info.HydrousImpurityRate = textHSL.Text;
            info.InputDate = DateTime.Now.ToString();
            info.BarCode = CBBarCode.Text;
            if (Check.CheckFloat(textHSL.Text))
                info.ComputationMark = "1";
            else
                info.ComputationMark = "0";
            //info.LegalityMark???????????????????????
            //info.FlowmeterReading;
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

            info.IId = CBName.SelectedValue == null ? "" : CBName.SelectedValue.ToString();
            info.GrossWeight = lblGrossWeight.Text;
            info.Tare = lblTare.Text;
            info.Suttle = lblTare.Text;
            //info.Surveyor = lblSurveyor.Text;
            info.ViId = CBTruckNo.SelectedValue == null ? "" : CBTruckNo.SelectedValue.ToString();
            info.SId1 = CBSite1.SelectedValue == null ? "" : CBSite1.SelectedValue.ToString();
            info.SId2 = CBSite2.SelectedValue == null ? "" : CBSite2.SelectedValue.ToString();        
            info.InputDate = DateTime.Now.ToString();
            info.BarCode = CBBarCode.Text;            
            if (Check.CheckFloat(textHSL.Text))
                info.ComputationMark = "1";
            else
                info.ComputationMark = "0";
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
                                if ((Check.CheckFloat(lblSuttle.Text))&&(!lblSuttle.Text.Trim().Equals("")))
                                {
                                    button4.Enabled = true;
                                    button2.Enabled = true;
                                    //recordId = 
                                }
                                DataTable dt1 = new DataTable();
                                dt1 = weighingLogic.FindWeighingInfo(style, "");
                                dataGridView1.DataSource = dt1;
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
                                {
                                    button4.Enabled = true;
                                    button2.Enabled = true;
                                }
                                DataTable dt2 = new DataTable();
                                dt2 = weighingLogic.FindWeighingInfo(style, "");
                                dataGridView1.DataSource = dt2;
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

        private void button4_Click(object sender, EventArgs e)
        {
            InWeighingDBLayer dbLayer = new InWeighingDBLayer();           
            DataSet ds = new DataSet();
            DataTable stockNote = new DataTable("stockNote");
            stockNote = dbLayer.GetInWeighingReport(recordId.ToString());            
            //ds.ReadXml(Application.StartupPath + @"\TestData.xml");  
            ds.Tables.Add(stockNote);
            ReportViewer frmRPT = new ReportViewer();
            frmRPT.MainDataSet = ds;
            frmRPT.ReportName = "stockNote";
            ArrayList dsName = new ArrayList();
            dsName.Add("DataSet1_stockNote");
            frmRPT.MainDataSourceName = dsName;
            frmRPT.ReportPath = Application.StartupPath + @"\Report1.rdlc";
            
            frmRPT.ShowDialog();
            //button4.Enabled = false;
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

        private void FrmInAndOutWeighing_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 未换卡前的关闭串口;
            //CardClass.dc_exit(icdev);

            // 换卡后的关闭串口;
            iCardHelper.Exit_Port(icdev);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BindInfoLogic bindLogic = new BindInfoLogic();
            DataSet ds = new DataSet();
            string strText = "";
            // 换读卡器前的读卡号调用的方法;
            //strText = weighingLogic.GetCardNo(icdev);

            // 换读卡器后的读卡号调用的方法;
            strText = weighingLogic.Get_CardNo();
            if (!strText.Trim().Equals(""))
            {
                if (strText.Length > 15)
                {
                    strText = strText.Remove(15, strText.Length - 15);
                    ds = bindLogic.GetBindInfo("", "", strText);
                    if (ds.Tables[0].Rows.Count > 0)
                        CBTruckNo.Text = ds.Tables[0].Rows[0]["车牌号"].ToString();
                }
            }
        }
        private void 称重ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                CBTruckNo.Text = dataGridView1.SelectedRows[0].Cells["Column2"].Value.ToString();
        }

        private void 归档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FrmRegressArchives form = new FrmRegressArchives();
            switch (style)
            {
                case WeighingStyle.InStyle:
                    InWeighingClass info1 = new InWeighingClass();          

                    form.TruckNo = dataGridView1.SelectedRows[0].Cells["Column2"].Value.ToString();
                    form.GrossWeight = dataGridView1.SelectedRows[0].Cells["Column6"].Value.ToString();
                    form.Tare = dataGridView1.SelectedRows[0].Cells["Column7"].Value.ToString();
                    form.Suttle = dataGridView1.SelectedRows[0].Cells["Column8"].Value.ToString();
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        info1.Id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                        info1.GrossWeight = form.GrossWeight;
                        info1.Tare = form.Tare;
                        info1.Suttle = form.Suttle;

                        if (weighingLogic.UpdateIninfo(info1))
                            MessageBox.Show("归档成功");
                        DataTable dt1 = new DataTable();
                        dt1 = weighingLogic.FindWeighingInfo(style, "");
                        dataGridView1.DataSource = dt1;
                    }
                    break;
                case WeighingStyle.OutStyle:
                    OutWeighingClass info2 = new OutWeighingClass();

                    form.TruckNo = dataGridView1.SelectedRows[0].Cells["Column2"].Value.ToString();
                    form.GrossWeight = dataGridView1.SelectedRows[0].Cells["Column6"].Value.ToString();
                    form.Tare = dataGridView1.SelectedRows[0].Cells["Column7"].Value.ToString();
                    form.Suttle = dataGridView1.SelectedRows[0].Cells["Column8"].Value.ToString();
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        info2.Id = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
                        info2.GrossWeight = form.GrossWeight;
                        info2.Tare = form.Tare;
                        info2.Suttle = form.Suttle;
                        if (weighingLogic.UpdateOutinfo(info2))
                            MessageBox.Show("归档成功");
                        DataTable dt2 = new DataTable();
                        dt2 = weighingLogic.FindWeighingInfo(style, "");
                        dataGridView1.DataSource = dt2;
                    }
                    break;
                default:
                    ;
                    break;
            }            
        }

        private void CBTransportContract_TextChanged(object sender, EventArgs e)
        {
            if ((CBTransportContract.SelectedIndex >= 0) && (!CBTransportContract.ValueMember.Equals("")))
            {
                MetageFindClass findClass = new MetageFindClass();

                findClass.GetSiteValue(CBTransportContract.SelectedValue.ToString(), ref CBSite1, ref CBSite2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }  

    }
}
