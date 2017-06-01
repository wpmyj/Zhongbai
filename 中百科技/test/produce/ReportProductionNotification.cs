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
using Microsoft.Reporting.WinForms;

namespace DasherStation.produce
{
    public partial class ReportProductionNotification : Form
    {
        public ReportProductionNotification()
        {
            InitializeComponent();
        }
        SqlHelper sqlHelper = new SqlHelper();

        private string pnId;

        public string PNID
        {
            get { return pnId; }
            set { pnId = value; }
        }

        private void ReportProductionNotification_Load(object sender, EventArgs e)
        {
            //// TODO: 这行代码将数据加载到表“dataSet1.targetProportionDetail”中。您可以根据需要移动或移除它。
            ////this.targetProportionDetailTableAdapter.Fill(this.dataSet1.targetProportionDetail);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DasherStation.produce.Report.ProductionNotification.rdlc";

            ArrayList list = new ArrayList();
            list.Add("select m.id as id,mn.name,mm.model,tpd.targetProportionValue from produceNotice pn,targetSendProportionDetail tsp,targetProportionDetail tpd,material m,materialName mn,materialModel mm where m.mmid=mm.id and m.mnid=mn.id and tpd.mid=m.id and tsp.tpid=tpd.tpid and tsp.spid=pn.spid and pn.id=" + this.PNID);
            ReportDataSource reportDataSource1 = new ReportDataSource();
            reportDataSource1.Name = "DataSet_Report";

            DataTable dtResult=sqlHelper.QueryForDateSet(list).Tables[0];
            while (dtResult.Rows.Count < 6)
            {
                DataRow dr=dtResult.NewRow();
                dtResult.Rows.Add(dr);
            }
            reportDataSource1.Value = dtResult;


            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

            list = new ArrayList();
            list.Add("select pnt.id,pn.name,pm.model,pnt.planQuantity,Convert(varchar(10),pnt.startDate,120) as startDate,psp.eiid,pnt.notifyMan,Convert(varchar(10),pnt.notifyDate,120) as notifyDate,psp.ppid,tsp.tpid from produceNotice pnt,produceSendProportionDetail psp,produceProportion  pp,product p,productName pn,productModel pm,targetSendProportionDetail tsp where pnt.spId=psp.spId and psp.ppid=pp.id and pp.pid=p.id and  p.pnid=pn.id and p.pmid=pm.id and pnt.spid=tsp.spid and pnt.id=" + this.PNID);
            DataTable dt = sqlHelper.QueryForDateSet(list).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ReportParameter[] reportParameter = new ReportParameter[] {
                    new ReportParameter("pname",dt.Rows[0]["name"].ToString()),
                    new ReportParameter("pmodel",dt.Rows[0]["model"].ToString()),
                    new ReportParameter("planQuantity",dt.Rows[0]["planQuantity"].ToString()),
                    new ReportParameter("startDate",dt.Rows[0]["startDate"].ToString()),
                    new ReportParameter("eid",dt.Rows[0]["eiid"].ToString()),
                    new ReportParameter("notifyMan",dt.Rows[0]["notifyMan"].ToString()),
                    new ReportParameter("notifyDate",dt.Rows[0]["notifyDate"].ToString()),
                };
                this.reportViewer1.LocalReport.SetParameters(reportParameter);
            }
           
            //资源名 rdlc 默认会编译为坠入资源
            this.reportViewer1.RefreshReport();

        }
    }
}
