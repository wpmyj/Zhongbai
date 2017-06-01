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
    public partial class FrmLiQinKuChun : DasherStation.common.BaseForm
    {
        public FrmLiQinKuChun()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.dtgList.AutoGenerateColumns = false;
            DataSet dtsResult = new LiQingKuChunLogic().GetData();
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
                        row["存储数量"] = 2d * l * p *
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
            var _result = (from DataRow row in dtsResult.Tables[0].Rows
                           group row by new { pid = row["产品标识"].ToString(), mid = row["材料标识"].ToString() } into g
                           select new
                           {
                               材料种类 = g.First()["材料种类"],
                               材料名称 = g.First()["沥青名称"],
                               规格型号 = g.First()["规格型号"],
                               理论库存 = Double.Parse(g.First()["理论库存"].ToString()),
                               帐面库存 = (from item in g
                                       select Double.Parse(item["存储数量"].ToString())).Sum(),
                               差额 = 0.0,
                               误差率 = 0.0,
                               日期 = g.First()["日期"]
                           }).ToList();
            var result = from item in _result
                         group item by new { name = item.材料名称, model = item.规格型号 } into g
                         select new
                         {
                             材料种类 = g.First().材料种类,
                             材料名称 = g.First().材料名称,
                             规格型号 = g.First().规格型号,
                             理论库存 = (from item in g
                                     select item.理论库存).Sum(),
                             帐面库存 = (from item in g
                                     select item.帐面库存).Sum(),
                             差额 = (from item in g
                                   select item.帐面库存).Sum()
                                    - (from item in g
                                       select item.理论库存).Sum(),
                             误差率 =
                             (
                                Math.Abs((
                                (from item in g
                                 select item.帐面库存).Sum()
                                    - (from item in g
                                       select item.理论库存).Sum()
                                )
                                / (from item in g
                                   select item.帐面库存).Sum()
                                   * 100)
                             ),
                             日期 = g.First().日期
                         };
            this.dtgList.DataSource = result.ToList();
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
