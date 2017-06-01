using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;


using System.Collections;

namespace DasherStation.costCount
{
    public partial class FrmCaleBitumenHeatCost :BaseForm 
    {
        public FrmCaleBitumenHeatCost()
        {
            InitializeComponent();
        }
        //标注窗体是属于哪个核算，1沥青加热，2乳化沥青与改性沥青核算，3混合料生产
        private int formSort;

        public int FormSort
        {
            get { return formSort; }
            set { formSort = value; }
        }

        CaleBitumenHeatCostLogic caleBitument = new CaleBitumenHeatCostLogic();
            
      
        private void button1_Click(object sender, EventArgs e)
        {                     
                switch (formSort)
                {
                    case 1:
                        // 调用沥青加热成成本
                        //dataGridView1.DataSource = caleBitument.gatherBitumenHeatCostLogic(year, month);  

                        //DataTable dt = caleBitument.gatherBitumenHeatCostLogic(year, month);
                        //DataTable dtQuantity = db.SelectbitumenDetachParameter(year, month, 1);

                        //twoDataTable(dt, dtQuantity);
                        //dataGridView1.DataSource = dt;
                        DataTable dt = caleBitument.gatherBitumenHeatCostEquipLogic(distillHeatTable());
                        caleBitument.OneDataTable(dt, 1);
                        dataGridView1.DataSource = dt;

                        break;
                    case 2:
                        // 调用改性沥青和乳化沥青陈本
                        //dataGridView1.DataSource = caleBitument.gatherAlterBitumenCostLogic(year, month); 

                        DataTable dt1 = caleBitument.gatherAlterBitumenCostEquipLogic(distillHeatTable());
                        caleBitument.OneDataTable(dt1, 2);
                        dataGridView1.DataSource = dt1;
                        break;
                    case 3:                      
                                              
                        DataTable dt2 = caleBitument.getherMaxCostEquipLogic(distillHeatTable());

                        caleBitument.OneDataTable(dt2, 3);
                        dataGridView1.DataSource = dt2;
                        break;
                }
        }
        #region// 传两个datatable 查找出匹配的pid 的产量值 并计算出单价 此函数暂时不用
        private void twoDataTable(DataTable dt, DataTable dtQuantity)
        {
            dt.Columns.Add("quantity");
            dt.Columns.Add("unitPrice");
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataRow drq in dtQuantity.Rows)
                {
                    if (dr["pId"].ToString() == drq["pId"].ToString())
                    {
                        dr["quantity"] = drq["产量"];
                        if (drq["产量"].ToString() != "")
                        {
                            //dr["unitPrice"] = Convert.ToString(Convert.ToDouble(dr["money"]) / Convert.ToDouble(dr["quantity"]));
                            dr["unitPrice"] =Convert.ToString(Math.Round((Convert.ToDouble(dr["money"]) / Convert.ToDouble(dr["quantity"])),2));
                        }
                    }
                }
            }
        }
        

        // 需求变化改变twoDataTable 函数
        //private void OneDataTable(DataTable dt,int conds)
        //{            
        //    dt.Columns.Add("quantity");
        //    dt.Columns.Add("unitPrice");
        //    var bExist = (from DataColumn col in dt.Columns
        //                  where col.ColumnName == "equipmentNo"
        //                  select col).Count() > 0;
        //    if (!bExist)
        //    { 
        //        dt.Columns.Add("equipmentNo");                
        //    }       
                       
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        string year = dr["year"].ToString();
        //        string month = dr["month"].ToString();

        //        switch (conds)
        //        {
        //            case 1:
        //               DataTable dtQuantity = db.SelectbitumenDetachParameter(year, month, 1);
        //               foreach (DataRow drq in dtQuantity.Rows)
        //               {
        //                   if (dr["pId"].ToString() == drq["pId"].ToString())
        //                   {
        //                       dr["quantity"] = drq["产量"];
        //                       if (drq["产量"].ToString() != "")
        //                       {
        //                           dr["unitPrice"] = Convert.ToString(Math.Round((Convert.ToDouble(dr["money"]) / Convert.ToDouble(dr["quantity"])), 2));
        //                       }
        //                   }
        //               }
        //                break;
        //            case 2:
        //                DataTable dtQuantity1 = db.SelectbitumenDetachParameter(year, month, 2);
        //                foreach (DataRow drq in dtQuantity1.Rows)
        //                {
        //                    if (dr["pId"].ToString() == drq["pId"].ToString())
        //                    {
        //                        dr["quantity"] = drq["产量"];
        //                        if (drq["产量"].ToString() != "")
        //                        {
        //                            dr["unitPrice"] = Convert.ToString(Math.Round((Convert.ToDouble(dr["money"]) / Convert.ToDouble(dr["quantity"])), 2));
        //                        }
        //                    }
        //                }
        //                break;
        //            case 3:
        //                DataTable dtQuantity2 = db.SelectbitumenDetachParameter(year, month, 3);
        //                foreach (DataRow drq in dtQuantity2.Rows)
        //                {
        //                    if (dr["pId"].ToString() == drq["pId"].ToString())
        //                    {
        //                        dr["quantity"] = drq["产量"];
        //                        if (drq["产量"].ToString() != "")
        //                        {
        //                            dr["unitPrice"] = Convert.ToString(Math.Round((Convert.ToDouble(dr["money"]) / Convert.ToDouble(dr["quantity"])), 2));
        //                        }
        //                    }
        //                }
        //                break;
        //        }
        //    }
        //}
        #endregion

        private void FrmCaleBitumenHeatCost_Load(object sender, EventArgs e)
        {
            cmbYear.Text = DateTime.Now.Year.ToString();
            //cmbMonth.Text = DateTime.Now.Month.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                dtpEnd.Enabled = true;
            }
            else
            {
                dtpEnd.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                dtpStart.Enabled = true;
            }
            else
            {
                dtpStart.Enabled = false;
            }
        }

        // 根据条件提取数据返回表
        private CaleBitumenHeatCostClass distillHeatTable()
        {
            DataTable dt = new DataTable();
            CaleBitumenHeatCostClass conds= new CaleBitumenHeatCostClass();
            if (cmbYear.Text != "")
            {
                conds.YearDate = cmbYear.Text;
            }
            if (cmbMonth.Text != "")
            {
                conds.MonthDate = cmbMonth.Text;
            }
            if (checkBox3.Checked)
            {
                conds.StartDate = dtpStart.Value.ToString();
            }
            if (checkBox2.Checked)
            {
                conds.EndDate = dtpEnd.Value.ToString();
            }
            if (checkBox1.Checked)
            {
                conds.Equipment = "1";
            }
            else
            {
                conds.Equipment = "0";
            }
            return conds;

            //dt = caleBitument.getherMaxCostEquipLogic(conds);
            //return dt;

        }

       

        
       
    }
}
