/*
      * 版权单位：沈阳中百科技有限公司
      *
      * 文件名：Index.cs
      * 文件功能描述：拌合站信息管理系统主界面
      *
      * 创建人：冯雪
      * 创建时间：2009-02-04
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
using System.Text;
using System.Windows.Forms;
using DasherStation.stock;
using DasherStation.system;
using DasherStation.transport;
using DasherStation.quality;
using DasherStation.produce;
using DasherStation.sell;
using DaxherStation;
using DasherStation.common;
using DasherStation.metage;
using DasherStation.storage;
using DasherStation.costCount;
using DasherStation.equipment;
using DasherStation.Monitor;

namespace DasherStation
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            Login loginfrom = new Login();            
            Rectangle rect = new Rectangle();

            loginfrom.Close();
            //设置窗体显示成工作区大小
            rect = Screen.GetWorkingArea(this);
            loginfrom.Close();
            this.Top = 0;
            this.Left = 0;
            this.Width = rect.Width;
            this.Height = rect.Height;

            DasherStation.common.CNotifyDelegate.NotifyAlert(this);

            this.SysteMenu.Enabled = true;
            MIEPurviewInfo.Enabled = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (this.oNotify != null)
            {
                this.oNotify.Visible = false;
            }
        }

      
        private void MIProSettlement_Click(object sender, EventArgs e)
        {
            FrmProSettlement fppform = new FrmProSettlement();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, fppform);
            //}
            //catch
            //{

            //}
        }

        private void MISalesContract_Click(object sender, EventArgs e)
        {
            FrmSalesContract scform = new FrmSalesContract();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, scform);
            //}
            //catch
            //{

            //}
        }

        private void MISalesVolumeStatistics_Click(object sender, EventArgs e)
        {
            FrmSalesVolumeStatistics svsform = new FrmSalesVolumeStatistics();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, svsform);
            //}
            //catch
            //{

            //}
        }

        private void MISalesMeasurement_Click(object sender, EventArgs e)
        {
            FrmSalesMeasurement smform = new FrmSalesMeasurement();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, smform);
            //}
            //catch
            //{

            //}
        }

        private void MISalesSettlement_Click(object sender, EventArgs e)
        {
            FrmSalesSettlement ssform = new FrmSalesSettlement();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, ssform);
            //}
            //catch
            //{

            //}
        }

        private void MIProductionSchedule_Click(object sender, EventArgs e)
        {
            //FrmProductionSchedule fpsform = new FrmProductionSchedule();

            //try
            //{
            //    FormTools formTools = new FormTools();
            //    formTools.showFrom(this, fpsform);
            //}
            //catch
            //{

            // }
            FrmProductionScheduleMain fpsmform = new FrmProductionScheduleMain();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, fpsmform);
            //}
            //catch
            //{

            //}
        }

        private void MIProductionRecord_Click(object sender, EventArgs e)
        {
            //FrmProductionRecord fprform = new FrmProductionRecord();

            ////try
            ////{
            //    FormTools formTools = new FormTools();
            //    formTools.showFrom(this, fprform);
            ////}
            ////catch
            ////{

            ////}
        }

        private void MIProductionMeasureControl_Click(object sender, EventArgs e)
        {
            //FrmProductionMeasureControl fpmcform = new FrmProductionMeasureControl();

            ////try
            ////{
            //    FormTools formTools = new FormTools();
            //    formTools.showFrom(this, fpmcform);
            ////}
            ////catch
            ////{

            ////}
        }

        private void MIProductionStatistics_Click(object sender, EventArgs e)
        {
            FrmProductionStatistics fpstform = new FrmProductionStatistics();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, fpstform);
            //}
            //catch
            //{

            //}
        }

        private void MIMixtureRatio_Click(object sender, EventArgs e)
        {
            FrmMixtureRatio mrform = new FrmMixtureRatio();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, mrform);
            //}
            //catch
            //{

            //}
        }

        private void MIInspectingFrequency_Click(object sender, EventArgs e)
        {
            FrmInspectingfrequency infform = new FrmInspectingfrequency();

            
            
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, infform);
            //}
            //catch
            //{

            //}
        }

        private void MIInspectingReports_Click(object sender, EventArgs e)
        {
            InspectingReports irform = new InspectingReports();
            
            //启动“试验室软件”
            irform.RunLabApp();     
        }

        private void MIDetectingRecords_Click(object sender, EventArgs e)
        {
            FrmDetectingRecords drform = new FrmDetectingRecords();
            FormTools formTools = new FormTools();
            formTools.showFrom(this, drform);
            
        }

        private void MIEquipment_Click(object sender, EventArgs e)
        {
            FrmExaminationEquipmentDetail equipmentform = new FrmExaminationEquipmentDetail();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, equipmentform);
            //}
            //catch
            //{

            //}
        }

        private void MIExperimentalSystem_Click(object sender, EventArgs e)
        {
            FrmQualitySystemFiles esform = new FrmQualitySystemFiles();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, esform);
            //}
            //catch
            //{

            //}
        }

        private void MICorrectionPrevention_Click(object sender, EventArgs e)
        {
            FrmCorrectionPrevention cpform = new FrmCorrectionPrevention();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, cpform);
            //}
            //catch
            //{

            //}
        }

        private void MITransportContract_Click(object sender, EventArgs e)
        {
            FrmTransportContract ftcform = new FrmTransportContract();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, ftcform);
            //}
            //catch
            //{

            //}
        }

        private void MITransportSettlement_Click(object sender, EventArgs e)
        {
            FrmTransportSettlement ftsform = new FrmTransportSettlement();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, ftsform);
            //}
            //catch
            //{

            //}
        }

        private void MIUserInfo_Click(object sender, EventArgs e)
        {
            FrmUserInfo userform = new FrmUserInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, userform);
            //}
            //catch
            //{

            //}
        }


        private void MIMaterialInfo_Click(object sender, EventArgs e)
        {
            FrmMaterialInfo materialform = new FrmMaterialInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, materialform);
            //}
            //catch
            //{

            //}
        }

        private void MIProductInfo_Click(object sender, EventArgs e)
        {
            FrmProductInfo productform = new FrmProductInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, productform);
            //}
            //catch
            //{

            //}
        }

        private void MIProviderInfo_Click(object sender, EventArgs e)
        {
            FrmDetail providerform = new FrmDetail();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, providerform);
            //}
            //catch
            //{

            //}
        }

        private void MIClientInfo_Click(object sender, EventArgs e)
        {
            FrmClientInfo clientform = new FrmClientInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, clientform);
            //}
            //catch
            //{

            //}
        }

        private void MITruckInfo_Click(object sender, EventArgs e)
        {
            FrmTruckInfo truckform = new FrmTruckInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, truckform);
            //}
            //catch
            //{

            //}
        }

        private void MIBindInfo_Click(object sender, EventArgs e)
        {
            FrmBindInfo bindform = new FrmBindInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, bindform);
            //}
            //catch
            //{

            //}
        }

        private void MITuansportCInfo_Click(object sender, EventArgs e)
        {
            FrmTransportCompaniesInfo tciform = new FrmTransportCompaniesInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, tciform);
            //}
            //catch
            //{

            //}
        }

        private void MIEquipmentInfo_Click(object sender, EventArgs e)
        {
            FrmEquipmentInfo equipmentform = new FrmEquipmentInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, equipmentform);
            //}
            //catch
            //{

            //}
        }

        private void MIClientRelation_Click(object sender, EventArgs e)
        {

        }

        private void MIProcurementProgram_Click(object sender, EventArgs e)
        {

            FrmProcurementProgram fppform = new FrmProcurementProgram();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, fppform);
            //}
            //catch
            //{

            //}


        }

        private void MIabout_Click(object sender, EventArgs e)
        {
            About aboutform = new About();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, aboutform);
            //}
            //catch
            //{

            //}


        }


        private void Index_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MIRawMaterialConsumption_Click_1(object sender, EventArgs e)
        {
            //FrmRawMaterialConsumption frmcform = new FrmRawMaterialConsumption();

            ////try
            ////{
            //    FormTools formTools = new FormTools();
            //    formTools.showFrom(this, frmcform);
            ////}
            ////catch
            ////{

            ////}
        }

        private void MIEnergyConsumption_Click_1(object sender, EventArgs e)
        {
            //FrmEnergyConsumption fecform = new FrmEnergyConsumption();

            ////try
            ////{
            //    FormTools formTools = new FormTools();
            //    formTools.showFrom(this, fecform);
            ////}
            ////catch
            ////{

            ////}
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MIMetageIO_Click(object sender, EventArgs e)
        {
            //FrmInAndOutWeighing fiaowform = new FrmInAndOutWeighing();
            ////try
            ////{
            //    FormTools formTools = new FormTools();
            //    formTools.showFrom(this, fiaowform);
            ////}
            //catch
            //{

            //}
        }

        private void MIQueryStat_Click(object sender, EventArgs e)
        {
            FrmOutquiryStatistics fisform = new FrmOutquiryStatistics();
            //try
            //{
            FormTools formTools = new FormTools();
            formTools.showFrom(this, fisform);
        }

        private void MIHandiworkPigeonhole_Click(object sender, EventArgs e)
        {
            FrmManagerialSkill fmsform = new FrmManagerialSkill();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, fmsform);
            //}
            //catch
            //{

            //}
        }        

        private void MIProductionMessage_Click(object sender, EventArgs e)
        {
            //FrmProductionNotification fpnform = new FrmProductionNotification();
            ////try
            ////{
            //    FormTools formTools = new FormTools();
            //    formTools.showFrom(this, fpnform);
            ////}
            ////catch
            ////{

            ////}
        }

        private void MIProductionMonitor_Click(object sender, EventArgs e)
        {
            FrmProductionControl fpcform = new FrmProductionControl();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, fpcform);
            //}
            //catch
            //{

            //}
        }

        private void MIEPurviewInfo_Click(object sender, EventArgs e)
        {
            FrmPurviewInfo fpiform = new FrmPurviewInfo();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, fpiform);
            //}
            //catch
            //{

            //}
        }

        private void MIEparameter_Click(object sender, EventArgs e)
        {
            FrmParameter fpform = new FrmParameter();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, fpform);
            //}
            //catch
            //{

            //}
        }

        private void MIEDatabase_Click(object sender, EventArgs e)
        {
            FrmDatabase fdform = new FrmDatabase();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, fdform);
            //}
            //catch
            //{

            //}
        }

        private void MISalesProject_Click(object sender, EventArgs e)
        {
            FrmSalseProgram fspform = new FrmSalseProgram();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, fspform);
            //}
            //catch
            //{

            //}
        }

        private void MIMaterialInfonew_Click(object sender, EventArgs e)
        {
            FrmMaterialInfo materialform = new FrmMaterialInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, materialform);
            //}
            //catch
            //{

            //}
        }

        private void MIProductInfonew_Click(object sender, EventArgs e)
        {
            FrmProductInfo productform = new FrmProductInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, productform);
            //}
            //catch
            //{

            //}
        }

        private void MIProviderInfonew_Click(object sender, EventArgs e)
        {
            FrmDetail providerform = new FrmDetail();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, providerform);
            //}
            //catch
            //{

            //}
        }

        private void MIClientInfonew_Click(object sender, EventArgs e)
        {
            FrmClientInfo clientform = new FrmClientInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, clientform);
            //}
            //catch
            //{

            //}
        }

        private void MITruckInfonew_Click(object sender, EventArgs e)
        {
            FrmTruckInfo truckform = new FrmTruckInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, truckform);
            //}
            //catch
            //{

            //}
        }

        private void MIBindInfo_Click_1(object sender, EventArgs e)
        {

        }

        private void MITuansportCInfonew_Click(object sender, EventArgs e)
        {
            FrmTransportCompaniesInfo tciform = new FrmTransportCompaniesInfo();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, tciform);
            //}
            //catch
            //{

            //}
        }

        private void MIEparameternew_Click(object sender, EventArgs e)
        {
            FrmParameter fpform = new FrmParameter();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, fpform);
            //}
            //catch
            //{

            //}
        }

        private void MIEquipmentInfonew_Click(object sender, EventArgs e)
        {
            FrmEquipmentDetail equipmentform = new FrmEquipmentDetail();

            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, equipmentform);
            //}
            //catch
            //{

            //}
        }

        private void MIBindInfonew_Click(object sender, EventArgs e)
        {
            FrmBindInfo bindInfo = new FrmBindInfo();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, bindInfo);
            //}
            //catch
            //{

            //}
        }

        private void MIpurchasing_Click(object sender, EventArgs e)
        {

           
            FrmPurchasing bindInfo = new FrmPurchasing();
            //try
            //{
                   FormTools formTools = new FormTools();
                    formTools.showFrom(this, bindInfo);
            //}
            //catch
            //{

            //}
        }

        private void MIStockInR_Click(object sender, EventArgs e)
        {
            FrmStockInR frmStockInR = new FrmStockInR();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, frmStockInR);
            //}
            //catch
            //{

            //}
        }

        private void MIStockOutR_Click(object sender, EventArgs e)
        {
            FrmStockOutR frmStockOutR = new FrmStockOutR();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, frmStockOutR);
            //}
            //catch
            //{

            //}
        }

        private void MIStockStat_Click(object sender, EventArgs e)
        {
            FrmStockStat frmStockStat = new FrmStockStat();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, frmStockStat);
            //}
            //catch
            //{

            //}
        }

        private void MIStockCheck_Click(object sender, EventArgs e)
        {
            FrmStockCheck frmStockCheck = new FrmStockCheck();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, frmStockCheck);
            //}
            //catch
            //{

            //}
        }

        private void MIHMetageIO_Click(object sender, EventArgs e)
        {
            FrmHandWeighing handWeighing = new FrmHandWeighing();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, handWeighing);
            //}
            //catch
            //{

            //}
        }

        private void MIRawMaterialConsumptionBitumen_Click(object sender, EventArgs e)
        {
            FrmRawMaterialConsumptionBitumen frmcbform = new FrmRawMaterialConsumptionBitumen();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, frmcbform);
            //}
            //catch
            //{

            //}
        }

        private void MIEnergyConsumptionQXL_Click(object sender, EventArgs e)
        {
            FrmEnergyConsumptionQXL fecqxlform = new FrmEnergyConsumptionQXL();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, fecqxlform);
            //}
            //catch
            //{

            //}
        }

        private void MIOption_Click(object sender, EventArgs e)
        {
            FrmOption option = new FrmOption();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, option);
            //}
            //catch
            //{

            //}
        }

        private void MIPersonnelInfo_Click(object sender, EventArgs e)
        {
            FrmPersonnelInfo personnel = new FrmPersonnelInfo();
            //try
            //{
                FormTools formTools = new FormTools();
                formTools.showFrom(this, personnel);
            //}
            //catch
            //{

            //}
        }

        private void 配合比发送单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProportionSendQuery formProportionSendQuery = new FrmProportionSendQuery();

            FormTools formTools = new FormTools();

            formTools.showFrom(this, formProportionSendQuery);
            
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            FrmInquiryStatistics fisform = new FrmInquiryStatistics();
            //try
            //{
            FormTools formTools = new FormTools();
            formTools.showFrom(this, fisform);
            //}
            //catch
            //{

            //}
        }

        private void MIPayroll_Click(object sender, EventArgs e)
        {
            DasherStation.HumanResource.FrmPayroll formPayroll = new DasherStation.HumanResource.FrmPayroll();
            new FormTools().showFrom(this, formPayroll);
        }

        private void MIPayOff_Click(object sender, EventArgs e)
        {
            DasherStation.HumanResource.FrmReadyPayOff win = new DasherStation.HumanResource.FrmReadyPayOff();
            new FormTools().showFrom(this, win);
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQualitySystemFiles esform = new FrmQualitySystemFiles();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, esform);
        }

        private void MIPaySearch_Click(object sender, EventArgs e)
        {
            DasherStation.HumanResource.FrmPaySearch win = new DasherStation.HumanResource.FrmPaySearch();
            new FormTools().showFrom(this, win);
        }

        private void MIEmplyeesInfo_Click(object sender, EventArgs e)
        {
            DasherStation.HumanResource.FrmEmployeeInfo win = new DasherStation.HumanResource.FrmEmployeeInfo();
            new FormTools().showFrom(this, win);
        }

        private void 成本预算统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBitumenCostCount formBitumenCC = new FrmBitumenCostCount();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, formBitumenCC);            
        }

        private void MIEquipmentRepairPlan_Click(object sender, EventArgs e)
        {
            equipment.FrmEquipmentRepairPlan frm = new equipment.FrmEquipmentRepairPlan();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);
        }

        private void MIEquipmentService_Click(object sender, EventArgs e)
        {
            equipment.FrmEquipmentService frm = new equipment.FrmEquipmentService();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);
        }

        private void MIEquipmentFillOil_Click(object sender, EventArgs e)
        {
            equipment.FrmEquipmentFillOil frm = new equipment.FrmEquipmentFillOil();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);
        }

        private void MIEquipmentUse_Click(object sender, EventArgs e)
        {
            equipment.FrmEquipmentUse frm = new equipment.FrmEquipmentUse();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);
        }

        private void toolStripCostOption_Click(object sender, EventArgs e)
        {
            FrmCostParameter costParameter = new FrmCostParameter();

            FormTools formTools = new FormTools();
            formTools.showFrom(this,costParameter);
        }

        private void MIDepartment_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.HumanResource.FrmDepartment());
        }

        private void MISparePartBasicInfo_Click(object sender, EventArgs e)
        {
            equipment.FrmSparePartBasicInfo frm = new equipment.FrmSparePartBasicInfo();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);
        }

        private void MISparePartStockPlan_Click(object sender, EventArgs e)
        {
            equipment.FrmSparePartStockPlan frm = new equipment.FrmSparePartStockPlan();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);
        }

        private void MISparePartAdd_Click(object sender, EventArgs e)
        {
            equipment.FrmSparePartInStock frm = new equipment.FrmSparePartInStock();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);
        }

        private void MISparePartClaim_Click(object sender, EventArgs e)
        {
            equipment.FrmSparePartClaim frm = new equipment.FrmSparePartClaim();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);
        }

        private void MISparePartAddRefund_Click(object sender, EventArgs e)
        {
            equipment.FrmSparePartInStockRefund frm = new equipment.FrmSparePartInStockRefund();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);
        }

        private void MISparePartOut_Click(object sender, EventArgs e)
        {
            equipment.FrmSparePartOutStock frm = new equipment.FrmSparePartOutStock();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);
        }

        private void MISparePartOutRefund_Click(object sender, EventArgs e)
        {
            equipment.FrmSparePartOutStockRefund frm = new equipment.FrmSparePartOutStockRefund();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);
        }

        private void MISellSettlement_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Finance.AccountBooks.FrmSellBalance());
        }

        private void ToolStripCostbudget_Click(object sender, EventArgs e)
        {
            FrmExpenditureSubject formExpendSubject = new FrmExpenditureSubject();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, formExpendSubject);
        }

        private void MIPurchaseBalance_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Finance.AccountBooks.FrmPurchaseBalance());
        }

        private void MITransportBalance_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Finance.AccountBooks.FrmTransportBalance());
        }

        private void MIPartBanlance_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Finance.AccountBooks.FrmSparePartBanlance());
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            FrmAlterBitumenCostCount formAlterBitumenCC = new FrmAlterBitumenCostCount();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, formAlterBitumenCC);
           
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            FrmCostCount costCountForm = new FrmCostCount();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, costCountForm);           
        }       

        private void menuRightClcik_About_Click(object sender, EventArgs e)
        {
            About aboutform = new About();
            FormTools formTools = new FormTools();
            formTools.showFrom(this, aboutform);
        }

        private void menuRightClick_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MIShowMainWin_Click(object sender, EventArgs e)
        {
            this.Activate();
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            FrmOtherWeighing otherWeighingForm = new FrmOtherWeighing();
            FormTools formTools = new FormTools();
            formTools.showFrom(this, otherWeighingForm);
        }

        private void MISparePartStock_Click(object sender, EventArgs e)
        {
            FrmSparePartStock frm = new FrmSparePartStock();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);  
        }

        private void Fixasset_Click(object sender, EventArgs e)
        {

        }

        private void MIAudit_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.HumanResource.FrmPayoffAudit());
        }

        private void MIWDSetting_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Monitor.FrmWDSetting());
        }

        private void MIYWSetting_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Monitor.FrmYWSetting());
        }

        private void LLSetting_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Monitor.FrmLLSetting());
        }

        private void MIMonitor_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Monitor.FrmMonitor());
        }

        private void MIProductionParameter_Click(object sender, EventArgs e)
        {
            FrmProductionParameter frm = new FrmProductionParameter();

            FormTools formTools = new FormTools();
            formTools.showFrom(this, frm);
            
        }

        private void MIQCvsLL_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Monitor.FrmQCvsLL());
        }


        private void MIJianceRate_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Monitor.FrmJianceRate());
        }

        private void MILiqingguan_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Monitor.FrmLiqingguan());
        }

        private void MILiQinKuChun_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Monitor.FrmLiQinKuChun());
        }

        private void MISengcanBHG_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Monitor.FrmSengcanBHG());
        }

        private void MISengCanLvsXiaoSouL_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Monitor.FrmSengCanLvsXiaoSouL());
        }

        private void MITempMonitor_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Monitor.FrmSengcanWD());
        }

        private void MIFlowmeter_Click(object sender, EventArgs e)
        {
            new FormTools().showFrom(this, new DasherStation.Monitor.FrmLiQin_Stat());
        }       
    }
}
