using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.ReportDistrict.storageReport;

namespace DasherStation.storage
{
    public partial class FrmStockStat : common.BaseForm
    {
        public FrmStockStat()
        {
            InitializeComponent();
        }
        StockStatLogic stockStatLogic = new StockStatLogic();
        

        #region  SetISockStat()材料入库统计查询方法
        /*
        * 方法名称：SetISockStat()
        * 方法功能描述：材料入库统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-16
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        private void SetMSockStat()
        {
            dgvStockStat.DataSource = stockStatLogic.InStat();
            ////dgvStockStat.Columns["最低库存量"].Visible = false;
            dgvStockStat.Columns["id"].Visible = false;
            //dgvStockStat.Columns["入库量"].Visible = false;
            //dgvStockStat.Columns["出库量"].Visible = false;

        }
        #endregion

        #region SetPSockStat() 产品入库统计查询方法
        /*
        * 方法名称：SetPSockStat()
        * 方法功能描述：产品入库统计查询方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-16
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        private void SetPSockStat()
        {
            dgvStockStat.DataSource = stockStatLogic.OutStat();
            dgvStockStat.Columns["id"].Visible = false;

        }
        #endregion

        private void FrmStockStat_Load(object sender, EventArgs e)
        {
            SetMSockStat();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMaterial.Checked)
            {
                SetMSockStat();
            }
        }

        private void rbtnProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnProduct.Checked)
            {
                SetPSockStat();
            }
        }

        private void dgvStockStat_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Color bgColor = dgvStockStat.RowsDefaultCellStyle.BackColor;

            foreach (DataGridViewRow dgv in dgvStockStat.Rows)
            {
                if (dgv.Cells["最低库存量"].Value.ToString().Equals(""))
                {
                    return;
                }
                else
                {
                    decimal nadirStock = Convert.ToDecimal(dgv.Cells["最低库存量"].Value.ToString());
                    decimal suttle = Convert.ToDecimal(dgv.Cells["库存量"].Value.ToString());

                    
                    if (suttle < nadirStock)
                    { 
                        dgv.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                    {
                        dgv.DefaultCellStyle.BackColor = bgColor;
                    }


                }

            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            string data = (DateTime.Now).ToString("yyyy-MM-dd"); 
            ReportStorageClass storage_Report = new ReportStorageClass();
            if (rbtnMaterial.Checked)
            {
                storage_Report.RunMonthStuffStorage(data);
            }
            if (rbtnProduct.Checked)
            {
                storage_Report.RunMonthProductStorage(data);
            }
        }

    }
}
