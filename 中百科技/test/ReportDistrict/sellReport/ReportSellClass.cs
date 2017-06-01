using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DasherStation.common;
using System.Data;
using System.Collections;

namespace DasherStation.ReportDistrict.sellReport
{
    public class ReportSellClass
    {
        SqlHelper helper = new SqlHelper();

        // 单位名称;
        private string name_value()
        {
            string sql = "SELECT dasherName FROM basicInfo";
            DataTable dt = helper.QueryForDateSet(new ArrayList() {sql}).Tables[0];
            if (dt.Rows.Count != 0)
            {
                return  dt.Rows[0][0].ToString();
            }
            return "";
        }

        /*
        * 方法名称： RunYearSellPlan
        * 方法功能描述：打印年销售计划报表相关信息;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-21
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void RunYearSellPlan(long sellPlanId)
        {
            System.Collections.ArrayList oArrayList = new System.Collections.ArrayList();
            oArrayList.Add("select a.*, d.model, c.name, e.sort from sellPlanDetail a " +
                "inner join product b on a.pId = b.id " +
                "inner join productName c on b.pnId = c.id " +
                "inner join productModel d on b.pmId = d.id " +
                "inner join productKind e on c.pkId = e.id "+
                "where a.spId = " + sellPlanId
                );
            DataSet ds = helper.QueryForDateSet(oArrayList);

            YearSellPlan oYearSellPlan = new YearSellPlan();
            oYearSellPlan.Source = ds;

            oYearSellPlan.Year = "2009";
            oYearSellPlan.CoName = name_value();
            oYearSellPlan.Number = "11000111";
            oYearSellPlan.Tabler = "aaa";
            oYearSellPlan.Auditer = "bb";
            oYearSellPlan.Approvaler = "ccc";
            oYearSellPlan.ShowReport();
        }

        /*
        * 方法名称： RunProductSellClearing
        * 方法功能描述：打印销售票据报表相关信息;
        *
        * 创建人：冯雪
        * 创建时间：2009-04-21
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void RunProductSellClearing(long spsId)
        {
            string lSearchStr = " SELECT s3.id, s3.spsdId, s3.cnId, cn.id AS idx,cn.inputDate as inputDate";
            lSearchStr = lSearchStr + " ,productName.name as name,productModel.model as model";
            lSearchStr = lSearchStr + " ,clientInfo.name as cname,voitureInfo.no as no,transportUnit.name as scname";
            lSearchStr = lSearchStr + " ,cn.grossWeight as grossWeight,cn.tare as tare,cn.suttle as suttle,personnelInfo.name as surveyor";
            lSearchStr = lSearchStr + " FROM sellProductSettlementDetail AS s1 Left Outer Join  ";
            lSearchStr = lSearchStr + " sellProductNoteCorresponding AS s3 ON s1.id = s3.spsdId Left Outer Join  ";
            lSearchStr = lSearchStr + " consignmentNote AS cn ON s3.cnId = cn.id Left Outer Join voitureInfo ON  ";
            lSearchStr = lSearchStr + " cn.viId = voitureInfo.id Left Outer Join personnelInfo ON  ";
            lSearchStr = lSearchStr + " cn.piId1 = personnelInfo.id Left Outer Join transportGoodsInformationCorresponding ON  ";
            lSearchStr = lSearchStr + " cn.tgicId = transportGoodsInformationCorresponding.id Left Outer Join transportContract ON  ";
            lSearchStr = lSearchStr + " transportGoodsInformationCorresponding.tcId = transportContract.id Left Outer Join transportUnit ON  ";
            lSearchStr = lSearchStr + " transportContract.tuId = transportUnit.id Left Outer Join invoice ON  ";
            lSearchStr = lSearchStr + " cn.iId = invoice.id Left Outer Join sellContract ON  ";
            lSearchStr = lSearchStr + " invoice.scId = sellContract.id Left Outer Join clientInfo ON  ";
            lSearchStr = lSearchStr + " sellContract.ciId = clientInfo.id Left Outer Join product ON  ";
            lSearchStr = lSearchStr + " invoice.pId = product.id Left Outer Join productModel ON  ";
            lSearchStr = lSearchStr + " product.pmId = productModel.id Left Outer Join productName ON  ";
            lSearchStr = lSearchStr + " product.pnId = productName.id ";
            lSearchStr = lSearchStr + " WHERE s1.spsId = " + spsId ;

            DataSet ds = helper.QueryForDateSet(lSearchStr); 

            ClearBillDetail oClearBillDetail = new ClearBillDetail();
            oClearBillDetail.Source = ds;

            oClearBillDetail.CoName = name_value();
            oClearBillDetail.ShowReport();
        }
    }
}
