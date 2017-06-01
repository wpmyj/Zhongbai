using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.Monitor
{
    public partial class FrmLiqingguan : DasherStation.common.BaseForm
    {
        public FrmLiqingguan()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.dtgList.AutoGenerateColumns = false;
            this.txtStartDate.Value = DateTime.Now.AddDays(-1);
            this.cboNo.DisplayMember = "no";
            this.cboNo.ValueMember = "id";
            this.cboNo.DataSource = new LiQingGuanLogic().GetNo().Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.txtEndDate.Value < this.txtStartDate.Value)
            {
                DasherStation.HumanResource.CommUI.AlertError("结止日期不能小于开始日期!");
                return;
            }
            DataSet dtsResult = new LiQingGuanLogic().GetData(
                this.txtStartDate.Value,
                this.txtEndDate.Value,
                this.cboNo.Text);
            foreach (DataRow row in dtsResult.Tables[0].Rows)
            {
                try
                {
                    var r = double.Parse(row["罐直径"].ToString()) / 2d;
                    var h = double.Parse(row["液位高度"].ToString());
                    var l = double.Parse(row["罐子高度"].ToString());
                    var p = double.Parse(row["沥青密度"].ToString());

                    if (row["罐子样式"].ToString() == "立罐")
                    {
                        row["存储数量"] = Math.PI * Math.Pow(r, 2) * h * p;
                    }
                    else if (row["罐子样式"].ToString() == "卧罐")
                    {
                        row["存储数量"] = 2d * l * 
                            (Math.PI * Math.Pow(r, 2) 
                            * (this.GetAngel(Math.Acos((r - h) / r)) / 360) 
                            - ((r - h) / 2) * r * Math.Sin(Math.Acos((r - h) / r)));
                    }
                }
                catch
                {
                }
            }
            if (dtsResult.HasChanges())
            {
                dtsResult.AcceptChanges();
            }
            this.dtgList.DataSource = dtsResult.Tables[0];

            cboNo.Text = "";
            cboNo.SelectedIndex = - 1;
        }

        private double GetAngel(double args)
        {
            return args * 180 / Math.PI;
        }

        private double GetArc(double args)
        {
            return args * Math.PI / 180;
        }
    }


}
