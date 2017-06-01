/*
      * 版权单位：沈阳中百科技有限公司
      *
      * 文件名：SalesContract.cs
      * 文件功能描述：销量统计界面
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
using System.Linq;
using System.Windows.Forms;
using DasherStation.system;
using DasherStation.ReportDistrict.sellReport;

namespace DasherStation.sell
{
    public partial class FrmSalesVolumeStatistics : common.BaseForm
    {
        public FrmSalesVolumeStatistics()
        {
            InitializeComponent();
        }

        ProductLogic pLogic = new ProductLogic();
        SalesStatisticsLogic salesSLogic = new SalesStatisticsLogic();
        
        #region SetDataGridView()为DataGridView赋值
        /*
         * 方法名称： SetDataGridView()
         * 方法功能描述：为DataGridView赋值；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void SetDataGridView()
        {
            string beginTime, endtime;

            beginTime = Convert.ToDateTime(dtpBegin.Value.ToString()).ToString("yyyy-MM-dd");
            endtime = Convert.ToDateTime(dtpEnd.Value.ToString()).ToString("yyyy-MM-dd");

            dgvStatistics.DataSource = salesSLogic.ProductSearchAll(beginTime, endtime, 1);

        }
        #endregion

        private void SalesVolumeStatistics_Load(object sender, EventArgs e)
        {
            //初始化DataGridView;
            SetDataGridView();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string beginTime, endtime;
            string condition;
            int verifyBit;

            beginTime = Convert.ToDateTime(dtpBegin.Value.ToString()).ToString("yyyy-MM-dd");
            endtime = Convert.ToDateTime(dtpEnd.Value.ToString()).ToString("yyyy-MM-dd");
            condition = cbxCondition.Text.Trim();

            switch (condition)
            {
                case "按产品":
                    verifyBit = 1;
                    break; 
                case "按客户":
                    verifyBit = 2;
                    break;
                case "按运输单位":
                    verifyBit = 3;
                    break;
                    case "按工程项目":
                    verifyBit = 4;
                    break;
                default:
                    verifyBit = 0;                    
                    MessageBox.Show("查询条件不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxCondition.Focus();
                    return;
            }

            dgvStatistics.DataSource = salesSLogic.ProductSearchAll(beginTime, endtime, verifyBit);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvStatistics.DataSource == null || (this.dgvStatistics.DataSource as DataTable).Rows.Count == 0)
            {
                DasherStation.HumanResource.CommUI.AlertError("请先查询数据再打印!");
                return;
            }
            var result = (this.dgvStatistics.DataSource as DataTable).DataSet.Copy();
            result.Tables[0].Columns.Add("inputdate");
            foreach (DataRow row in result.Tables[0].Rows)
            {
                row["inputdate"] = this.dtpBegin.Value.ToShortDateString();
            }
            result.Tables[0].Columns["产品种类"].ColumnName = "sort";
            result.Tables[0].Columns["产品名称"].ColumnName = "name";
            result.Tables[0].Columns["出库量"].ColumnName = "suttle";
            result.Tables[0].Columns["小票数量"].ColumnName = "count";
            result.Tables[0].Columns["产品规格"].ColumnName = "model";
            result.Tables[0].Columns["当年出库量"].ColumnName = "totalSuttle";
            if(result.Tables[0].Columns.Contains("客户"))
            {                
                    SellOutByClient oSellOutByClient = new SellOutByClient();
                    result.Tables[0].Columns["客户"].ColumnName = "clientName";
                    oSellOutByClient.Source = result;
                    oSellOutByClient.CoName = "";
                    oSellOutByClient.Number = "";
                    oSellOutByClient.Tabler = "";
                    oSellOutByClient.Auditer = "";
                    oSellOutByClient.ShowReport();
            }else if(result.Tables[0].Columns.Contains("运输公司"))
            {    
                    SellOutByTransport oSellOutByTransport = new SellOutByTransport();
                    result.Tables[0].Columns["运输公司"].ColumnName = "transportName";
                    oSellOutByTransport.Source = result;
                    oSellOutByTransport.CoName = "";
                    oSellOutByTransport.Number = "";
                    oSellOutByTransport.Tabler = "";
                    oSellOutByTransport.Auditer = "";
                    oSellOutByTransport.ShowReport();
            }
            else if (result.Tables[0].Columns.Contains("工程项目"))
            {
                SellOutByProject oSellOutByProject = new SellOutByProject();
                result.Tables[0].Columns["工程项目"].ColumnName = "projectName";
                oSellOutByProject.Source = result;
                oSellOutByProject.CoName = "";
                oSellOutByProject.Number = "";
                oSellOutByProject.Tabler = "";
                oSellOutByProject.Auditer = "";
                oSellOutByProject.ShowReport();
            }
            else
            {
                SellOutByProduct oSellOutByProduct = new SellOutByProduct();
                oSellOutByProduct.Source = result;
                oSellOutByProduct.CoName = "";
                oSellOutByProduct.Number = "";
                oSellOutByProduct.Tabler = "";
                oSellOutByProduct.Auditer = "";
                oSellOutByProduct.ShowReport();
            }
        }
    }
}
