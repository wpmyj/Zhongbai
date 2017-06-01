using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.transport;

namespace DasherStation.produce
{
    public partial class FrmEnergyConsumptionG : common.BaseForm 
    {
        public FrmEnergyConsumptionG()
        {
            InitializeComponent();
        }

        private long _drcsdId;
        public long DrcsdId
        {
            get { return _drcsdId; }
            set { _drcsdId = value; }
        }

        ProducePlan.pType type;
        public ProducePlan.pType Type
        {
            get { return type; }
            set { type = value; }
        }

        private string pname;
        public string Pname
        {
            get { return pname; }
            set { pname = value; }
        }

        private string pmodel;
        public string Pmodel
        {
            get { return pmodel; }
            set { pmodel = value; }
        }

        private string eNo;
        public string ENo
        {
            get { return eNo; }
            set { eNo = value; }
        }

        ProducePlan producePlan = new ProducePlan();

        FormHelper formHelper = new FormHelper();

        DasherResourceConsumeDailyStatistics dasherResourceConsumeDailyStatistics;

        AsphaltumConsumeDailyStatistics asphaltumConsumeDailyStatistics;

        RebuildAsphaltConsumeDailyStatistics rebuildAsphaltConsumeDailyStatistics;

        private void FrmEnergyConsumptionG_Load(object sender, EventArgs e)
        {
            new DoCombox(cmb_materialKind,cmb_materialName,cmb_materialModel,TransportLogic.TranType.material);
            if (DrcsdId != 0)
            {
                dataBind(DrcsdId);
            }

                checkType();

        }
        private void checkType()
        {
            switch (Type)
            {
                case ProducePlan.pType.Mixture:
                    this.Text="拌合机能源消耗日报表";
                    this.txt_quantity.Enabled=false;
                    break;
                case ProducePlan.pType.EmulsificationAsphaltum:
                    this.Text = "乳化能源消耗日报表";
                    break;
                case ProducePlan.pType.RestructureAsphaltum:
                    this.Text = "改性能源消耗日报表";
                    break;
                default:
                    this.Text = "能源消耗日报表";
                    break;
            }
        }
        private void dataBind(long id)
        {
            cmb_equipmentInfo.Text = this.ENo;
            cmb_productName.Text = this.Pname;
            cmb_productModel.Text = this.Pmodel;
            switch (Type)
            {
                case ProducePlan.pType.Mixture:
                    dasherResourceConsumeDailyStatistics = producePlan.GetDasherResourceConsumeDailyStatisticsObj(id);
                    if (dasherResourceConsumeDailyStatistics != null)
                    {
                        txt_produceDate.Text = dasherResourceConsumeDailyStatistics.Producedate.ToString();
                        txt_quantity.Text = dasherResourceConsumeDailyStatistics.quantity.ToString();
                        txt_manHour.Text = dasherResourceConsumeDailyStatistics.manHour.ToString();
                        txt_consumeRate1.Text = dasherResourceConsumeDailyStatistics.consumeRate1.ToString();
                        txt_consumeRate2.Text = dasherResourceConsumeDailyStatistics.consumeRate2.ToString();
                        txt_consumeCoulometry.Text = dasherResourceConsumeDailyStatistics.consumeCoulometry.ToString();
                    }
                    break;
                case ProducePlan.pType.EmulsificationAsphaltum:
                    rebuildAsphaltConsumeDailyStatistics = producePlan.GetRebuildAsphaltConsumeDailyStatisticsObj(id);
                    if (rebuildAsphaltConsumeDailyStatistics != null)
                    {
                        txt_produceDate.Text = rebuildAsphaltConsumeDailyStatistics.produceDate.ToString();
                        txt_manHour.Text = rebuildAsphaltConsumeDailyStatistics.manHour.ToString();
                        txt_consumeRate1.Text = rebuildAsphaltConsumeDailyStatistics.consumeRate1.ToString();
                        txt_consumeRate2.Text = rebuildAsphaltConsumeDailyStatistics.consumeRate2.ToString();
                        txt_consumeCoulometry.Text = rebuildAsphaltConsumeDailyStatistics.consumeCoulometry.ToString();
                        txt_quantity.Text = rebuildAsphaltConsumeDailyStatistics.quantity1.ToString();
                        txt_fuelWastage2.Text = rebuildAsphaltConsumeDailyStatistics.fuelWastage2.ToString();
                    }
                    break;
                case ProducePlan.pType.RestructureAsphaltum:
                    asphaltumConsumeDailyStatistics = producePlan.GetAsphaltumConsumeDailyStatisticsObj(id);
                    if (asphaltumConsumeDailyStatistics != null)
                    {
                        txt_produceDate.Text = asphaltumConsumeDailyStatistics.produceDate.ToString();
                        txt_manHour.Text = asphaltumConsumeDailyStatistics.manHour.ToString();
                        txt_consumeRate1.Text = asphaltumConsumeDailyStatistics.consumeRate1.ToString();
                        txt_consumeRate2.Text = asphaltumConsumeDailyStatistics.consumeRate2.ToString();
                        txt_consumeCoulometry.Text = asphaltumConsumeDailyStatistics.consumeCoulometry.ToString();
                        txt_quantity.Text = asphaltumConsumeDailyStatistics.quantity1.ToString();
                        txt_fuelWastage2.Text = asphaltumConsumeDailyStatistics.fuelWastage2.ToString();
                    }
                    break;

            }
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(panel1))
            {
                save();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void save()
        {
            switch (Type)
            {
                case ProducePlan.pType.Mixture:
                    if (dasherResourceConsumeDailyStatistics != null)
                    {
                        if (cmb_materialName.SelectedIndex > -1 && cmb_materialModel.SelectedIndex > -1)
                        {
                            dasherResourceConsumeDailyStatistics.mId = new Produce().queryMid(cmb_materialName.SelectedValue.ToString(), cmb_materialModel.SelectedValue.ToString());
                        }
                        dasherResourceConsumeDailyStatistics.manHour = decimal.Parse(txt_manHour.Text.Trim());
                        dasherResourceConsumeDailyStatistics.consumeCoulometry = decimal.Parse(txt_consumeCoulometry.Text.Trim());
                        dasherResourceConsumeDailyStatistics.inputMan = this.UserName;
                        producePlan.UpdateDasherResourceConsumeDailyStatistics(dasherResourceConsumeDailyStatistics);
                    }
                    break;
                case ProducePlan.pType.RestructureAsphaltum:
                    if (asphaltumConsumeDailyStatistics != null)
                    {
                        if (cmb_materialName.SelectedIndex > -1 && cmb_materialModel.SelectedIndex > -1)
                        {
                            asphaltumConsumeDailyStatistics.mId = new Produce().queryMid(cmb_materialName.SelectedValue.ToString(), cmb_materialModel.SelectedValue.ToString());
                        }
                        asphaltumConsumeDailyStatistics.manHour = decimal.Parse(txt_manHour.Text.Trim());
                        asphaltumConsumeDailyStatistics.consumeCoulometry = decimal.Parse(txt_consumeCoulometry.Text.Trim());
                        asphaltumConsumeDailyStatistics.fuelWastage2 = decimal.Parse(txt_fuelWastage2.Text.Trim());
                        asphaltumConsumeDailyStatistics.inputMan = this.UserName;
                        producePlan.UpdateAsphaltumConsumeDailyStatistics(asphaltumConsumeDailyStatistics);
                    }
                    break;
                case ProducePlan.pType.EmulsificationAsphaltum:
                    if (rebuildAsphaltConsumeDailyStatistics != null)
                    {
                        if (cmb_materialName.SelectedIndex > -1 && cmb_materialModel.SelectedIndex > -1)
                        {
                            rebuildAsphaltConsumeDailyStatistics.mId = new Produce().queryMid(cmb_materialName.SelectedValue.ToString(), cmb_materialModel.SelectedValue.ToString());
                        }
                        rebuildAsphaltConsumeDailyStatistics.manHour = decimal.Parse(txt_manHour.Text.Trim());
                        rebuildAsphaltConsumeDailyStatistics.consumeCoulometry = decimal.Parse(txt_consumeCoulometry.Text.Trim());
                        rebuildAsphaltConsumeDailyStatistics.fuelWastage2 = decimal.Parse(txt_fuelWastage2.Text.Trim());
                        rebuildAsphaltConsumeDailyStatistics.inputMan = this.UserName;
                        producePlan.UpdateRebuildAsphaltConsumeDailyStatistics(rebuildAsphaltConsumeDailyStatistics);
                    }
                    break;
            }
            
        }


    }
}
