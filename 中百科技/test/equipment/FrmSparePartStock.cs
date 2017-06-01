using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.equipment
{
    public partial class FrmSparePartStock : common.BaseForm
    {
        EquipmentLogic equipmentLogic = new EquipmentLogic();

        public FrmSparePartStock()
        {
            InitializeComponent();
        }

        private void FrmSparePartStock_Load(object sender, EventArgs e)
        {
            try
            {
                equipmentLogic.FormFrmSparePartStockSearch("","",0,dgvDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string conditionStr;
            string condition;
            string searchStr;
            DateTime searchStrD;

            try
            {
                conditionStr = cbxQuery.Text.Trim();

                searchStr = txtQueryStr.Text.Trim();

                switch (conditionStr)
                {
                    case "备件编号":
                        condition = "no";
                        break;
                    case "备件种类":
                        condition = "sort";
                        break;
                    case "备件名称":
                        condition = "name";
                        break;
                    case "规格型号":
                        condition = "model";
                        break;
                    default:
                        condition = "1";
                        break;

                }
                if ((condition != "1") && (searchStr != ""))
                {
                    equipmentLogic.FormFrmSparePartStockSearch(searchStr, condition, 1, dgvDetail);
                    txtQueryStr.Clear();
                }
                else
                {
                    equipmentLogic.FormFrmSparePartStockSearch(searchStr, condition, 0, dgvDetail);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }  
        }
        private void dataBind(string strWhere)
        {
            //this.dgvDetail.DataSource = equipmentLogic.FrmSparePartBasicInfoAllInfo(strWhere);
        }
    }
}
