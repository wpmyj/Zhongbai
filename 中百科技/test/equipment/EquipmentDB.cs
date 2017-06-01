using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DasherStation.common;
using System.Collections;
using Microsoft.ReportingServices.ReportRendering;


namespace DasherStation.equipment
{
    class EquipmentDB
    {
        DataSet ds = new DataSet();

        SqlHelper sqlHelper = new SqlHelper();

        ArrayList arrayList = new ArrayList();


        #region/设备维修保养记录

        /*
        * 方法名称：FrmEquipmentServiceInitialCbxENO
        * 方法功能描述：查询数据库并返回数据集
        *
        * 创建人：夏阳明
        * 创建时间：200903020
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet FrmEquipmentServiceInitialCbxENO()
        {
            #region
            string locSearchStr;

            locSearchStr = "select distinct no from equipmentInformation";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
        * 方法名称：FrmEquipmentServiceLoadEquipNo
        * 方法功能描述：查询数据库并返回数据集
        *
        * 创建人：夏阳明
        * 创建时间：200903020
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet FrmEquipmentServiceLoadEquipNo(string equipNO)
        {
            #region
            string locSearchStr;
            ArrayList arrayList = new ArrayList();

            locSearchStr = "select sort from equmentKind, equipmentName,equipmentInformation where equmentKind.id = equipmentName.ekId and equipmentName.id = equipmentInformation.enId and equipmentInformation.no = '" + equipNO.Trim() + "'";

            arrayList.Add(locSearchStr);


            locSearchStr = "select name from equipmentName,equipmentInformation where equipmentInformation.enId = equipmentName.id and equipmentInformation.no = '" + equipNO.Trim() + "'";


            arrayList.Add(locSearchStr);


            locSearchStr = "select model from equipmentModel,equipmentInformation where equipmentInformation.emId = equipmentModel.id and equipmentInformation.no = '" + equipNO.Trim() + "'";

            arrayList.Add(locSearchStr);


            ds = sqlHelper.QueryForDateSet(arrayList);

            #endregion
            return ds;
        }


        /*
       * 方法名称：FrmEquipmentServiceSearchDasherName
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：200903020
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet FrmEquipmentServiceSearchDasherName()
        {
            #region
            string locSearchStr;

            locSearchStr = "select dasherName from basicInfo";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
      * 方法名称：FrmEquipmentServiceSaveAll
      * 方法功能描述：查询数据库并返回数据集
      *
      * 创建人：夏阳明
      * 创建时间：200903020
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmEquipmentServiceSaveAll(List<EquipmentServiceClass> list)
        {
            ArrayList sqllist = new ArrayList();

            foreach (EquipmentServiceClass ESClass in list)
            {
                sqllist.Add(FrmEquipmentServiceGetInsertSql(ESClass));
            }
            return sqlHelper.ExecuteTransaction(sqllist);
        }

        /*
     * 方法名称：FrmEquipmentServiceGetEiId
     * 方法功能描述：获得设备信息表id
     *
     * 创建人：夏阳明
     * 创建时间：200903020
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public int FrmEquipmentServiceGetEiId(string no)
        {
            #region
            string locSearchStr;
            int id = 0;

            locSearchStr = "select id from equipmentInformation where no = '" + no + "'";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            if (ds.Tables[0].Rows.Count != 0)
            {
                id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }

            #endregion
            return id;
        }


        /*
     * 方法名称：FrmEquipmentServiceGetInsertSql
     * 方法功能描述：插入到设备维修保养记录表中
     *
     * 创建人：夏阳明
     * 创建时间：200903020
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public string FrmEquipmentServiceGetInsertSql(EquipmentServiceClass ESClass)
        {
            StringBuilder strsql = new StringBuilder();
            int id;

            id = FrmEquipmentServiceGetEiId(ESClass.No);

            strsql.Append("insert into equipmentService(");
            strsql.Append("eiId,expenses,serviceKind,timeConsuming,serviceDate,finishDate,interval,no,serviceExplain,changeAccessory,attemptRunExplain,testResult,inputDate,inputMan");
            strsql.Append(")values(" + id + "," + ESClass.Expenses + ",'" + ESClass.ServiceKind + "','" + ESClass.TimeConsuming + "','" + ESClass.ServiceDate + "','" + ESClass.FinishDate + "','");
            strsql.Append(ESClass.Interval + "','" + ESClass.Fno + "','" + ESClass.ServiceExplain + "','" + ESClass.ChangeAccessory + "','" + ESClass.AttemptRunExplain + "','");
            strsql.Append(ESClass.TestResult + "','" + ESClass.InputDate + "','" + ESClass.InputMan + "')");

            return strsql.ToString();
        }

        /*
     * 方法名称：FrmEquipmentServiceAllInfo
     * 方法功能描述：查询设备维修保养记录
     *
     * 创建人：夏阳明
     * 创建时间：200903020
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataTable FrmEquipmentServiceAllInfo(string strWhere)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            sqlStr.Append("select EI.no,EK.sort,EN.name,EM.model,ES.expenses,ES.serviceKind,ES.timeConsuming,ES.serviceDate,");
            sqlStr.Append("ES.finishDate,ES.interval,ES.no as fno,ES.serviceExplain,ES.changeAccessory,ES.attemptRunExplain,");
            sqlStr.Append("ES.testResult,ES.inputDate,ES.inputMan");
            sqlStr.Append(" from equipmentInformation EI,equmentKind EK,equipmentName EN,equipmentModel EM,equipmentService ES");
            sqlStr.Append(" where ES.eiId = EI.id and EI.enId = EN.id and EN.ekId = EK.id and EI.emId = EM.id");

            if (strWhere.Trim() != "")
            {
                sqlStr.Append(" and " + strWhere);
            }
            list.Add(sqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];

        }


        #endregion

        #region//设备加油记录

        /*
     * 方法名称：FrmEquipmentFillOilAllInfo
     * 方法功能描述：查询设备加油记录
     *
     * 创建人：夏阳明
     * 创建时间：200903021
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataTable FrmEquipmentFillOilAllInfo(string strWhere)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            sqlStr.Append("select EI.no,EK.sort,EN.name,EM.model,EFO.fillOilDate,materialName.Name Name1,materialModel.Model Model1,EFO.quantity,EFO.unit,");
            sqlStr.Append("EFO.sum,EFO.unitPrice,EFO.fillOilMan,EFO.no as fno,EFO.inputDate,EFO.inputMan,EFO.remark,EFO.mId ");
            sqlStr.Append(" from equipmentInformation EI,equmentKind EK,equipmentName EN,equipmentModel EM,equipmentFillOil EFO,material,materialName,materialModel ");
            sqlStr.Append(" where EFO.eiId = EI.id and EI.enId = EN.id and EN.ekId = EK.id and EI.emId = EM.id and EFO.mId = material.id and material.mnId = materialName.id and material.mmId = materialModel.id");

            if (strWhere.Trim() != "")
            {
                sqlStr.Append(" and " + strWhere);
            }
            list.Add(sqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];

        }

        /*
       * 方法名称：FrmEquipmentServiceInitialCbxFillOilMan
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：200903021
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet FrmEquipmentServiceInitialCbxFillOilMan()
        {
            #region
            string locSearchStr;

            locSearchStr = "select distinct name from personnelInfo";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
     * 方法名称：FrmEquipmentFillOilSaveAll
     * 方法功能描述：查询数据库并返回数据集
     *
     * 创建人：夏阳明
     * 创建时间：200903021
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool FrmEquipmentFillOilSaveAll(List<EquipmentFillOilClass> list)
        {
            ArrayList sqllist = new ArrayList();

            foreach (EquipmentFillOilClass EFOClass in list)
            {
                sqllist.Add(EquipmentFillOilGetInsertSql(EFOClass));
            }
            return sqlHelper.ExecuteTransaction(sqllist);
        }

        /*
     * 方法名称：EquipmentFillOilGetInsertSql
     * 方法功能描述：插入到设备维修保养记录表中
     *
     * 创建人：夏阳明
     * 创建时间：200903021
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public string EquipmentFillOilGetInsertSql(EquipmentFillOilClass EFOClass)
        {
            StringBuilder strsql = new StringBuilder();
            int id;

            id = FrmEquipmentServiceGetEiId(EFOClass.No);

            //strsql.Append("insert into equipmentFillOil(");
            //strsql.Append("eiId,unitPrice,remark,no,fillOilMan,sum,unit,quantity,oilModel,oilName,fillOilDate,inputDate,inputMan");
            //strsql.Append(")values(" + id + "," + EFOClass.UnitPrice + ",'" + EFOClass.Remark + "','" + EFOClass.No + "','" + EFOClass.FillOilMan + "'," + EFOClass.Sum + ",'");
            //strsql.Append(EFOClass.Unit + "'," + EFOClass.Quantity + ",'" + EFOClass.OilModel + "','" + EFOClass.OilName + "','" + EFOClass.FillOilDate + "','");
            //strsql.Append(EFOClass.InputDate + "','" + EFOClass.InputMan + "')");

            strsql.Append("insert into equipmentFillOil(");
            strsql.Append("eiId,unitPrice,remark,no,fillOilMan,sum,unit,quantity,fillOilDate,inputDate,inputMan,mId");
            strsql.Append(")values(" + id + "," + EFOClass.UnitPrice + ",'" + EFOClass.Remark + "','" + EFOClass.No + "','" + EFOClass.FillOilMan + "'," + EFOClass.Sum + ",'");
            strsql.Append(EFOClass.Unit + "'," + EFOClass.Quantity + ",'" + EFOClass.FillOilDate + "','");
            strsql.Append(EFOClass.InputDate + "','" + EFOClass.InputMan + "'," + EFOClass.Id + ")");

            return strsql.ToString();
        }

        /*
    * 方法名称：FrmEquipmentFillOilGetMid
    * 方法功能描述：查询材料表id
    *
    * 创建人：夏阳明
    * 创建时间：20090409
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataSet FrmEquipmentFillOilGetMid(string mnid, string mmid)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            sqlStr.Append("select id from material where mnId = " + int.Parse(mnid) + " and mmId = " + int.Parse(mmid));

            list.Add(sqlStr.ToString());
            return sqlHelper.QueryForDateSet(list);

        }

       
        #endregion

        #region//备品备件基本信息

        /*
     * 方法名称：FrmSparePartBasicInfoAllInfo
     * 方法功能描述：查询备品备件基本信息记录
     *
     * 创建人：夏阳明
     * 创建时间：200903022
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataTable FrmSparePartBasicInfoAllInfo(string strWhere)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            sqlStr.Append("select SPBI.no,SPBI.sort,SPBI.name,SPBI.model,SPBI.maxStock,SPBI.minStock,SPBI.unit,");
            sqlStr.Append("SPBI.inputDate,SPBI.inputMan from sparePartBasicInfo SPBI");
            sqlStr.Append(" where 1 = 1");

            if (strWhere.Trim() != "")
            {
                sqlStr.Append(" and " + strWhere);
            }
            list.Add(sqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];

        }

        /*
  * 方法名称：FrmSparePartBasicInfoSaveAll
  * 方法功能描述：查询数据库并返回数据集
  *
  * 创建人：夏阳明
  * 创建时间：200903022
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */
        public bool FrmSparePartBasicInfoSaveAll(List<SparePartBasicInfoClass> list)
        {
            ArrayList sqllist = new ArrayList();

            foreach (SparePartBasicInfoClass SPBIClass in list)
            {
                sqllist.Add(SparePartBasicInfoGetInsertSql(SPBIClass));
            }
            return sqlHelper.ExecuteTransaction(sqllist);
        }

        /*
    * 方法名称：SparePartBasicInfoGetInsertSql
    * 方法功能描述：插入到备品备件基本信息记录表中
    *
    * 创建人：夏阳明
    * 创建时间：200903022
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public string SparePartBasicInfoGetInsertSql(SparePartBasicInfoClass SPBIClass)
        {
            StringBuilder strsql = new StringBuilder();

            strsql.Append("insert into sparePartBasicInfo(");
            strsql.Append("no,sort,name,model,maxStock,minStock,unit,inputDate,inputMan");
            strsql.Append(")values('" + SPBIClass.No + "','" + SPBIClass.Sort + "','" + SPBIClass.Name + "','" + SPBIClass.Model + "'," + SPBIClass.MaxStock + "," + SPBIClass.MinStock + ",'");
            strsql.Append(SPBIClass.Unit + "','" + SPBIClass.InputDate + "','" + SPBIClass.InputMan + "')");

            return strsql.ToString();
        }


        /*
       * 方法名称：FrmSparePartBasicInfoInitialSort
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090401
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet FrmSparePartBasicInfoInitialSort()
        {
            #region
            string locSearchStr;

            locSearchStr = "select distinct sort from sparePartBasicInfo";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        #endregion

        #region//新建领料单

        /*
        * 方法名称：FrmSparePartClaimDetailLoadEquipNo
        * 方法功能描述：查询数据库并返回数据集
        *
        * 创建人：夏阳明
        * 创建时间：20090323
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet FrmSparePartClaimDetailLoadEquipNo(string equipNO)
        {
            #region
            string locSearchStr;
            ArrayList arrayList = new ArrayList();

            locSearchStr = "select sparePartBasicInfo.sort from sparePartBasicInfo where sparePartBasicInfo.no = '" + equipNO.Trim() + "'";

            arrayList.Add(locSearchStr);


            locSearchStr = "select sparePartBasicInfo.name from sparePartBasicInfo where sparePartBasicInfo.no = '" + equipNO.Trim() + "'";


            arrayList.Add(locSearchStr);


            locSearchStr = "select sparePartBasicInfo.model from sparePartBasicInfo where sparePartBasicInfo.no = '" + equipNO.Trim() + "'";

            arrayList.Add(locSearchStr);


            locSearchStr = "select sparePartBasicInfo.unit from sparePartBasicInfo where sparePartBasicInfo.no = '" + equipNO.Trim() + "'";

            arrayList.Add(locSearchStr);


            locSearchStr = "select sparePartStock.unitPrice from sparePartStock,sparePartBasicInfo where sparePartStock.spbiId = sparePartBasicInfo.id and sparePartBasicInfo.no = '" + equipNO.Trim() + "'";

            arrayList.Add(locSearchStr);


            locSearchStr = "select sparePartStock.quantity from sparePartStock,sparePartBasicInfo where sparePartStock.spbiId = sparePartBasicInfo.id and sparePartBasicInfo.no = '" + equipNO.Trim() + "'";

            arrayList.Add(locSearchStr);


            ds = sqlHelper.QueryForDateSet(arrayList);

            #endregion
            return ds;
        }

        /*
       * 方法名称：FrmSparePartClaimDetailInitialCbxNo
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090323
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet FrmSparePartClaimDetailInitialCbxNo()
        {
            #region
            string locSearchStr;

            locSearchStr = "select distinct no from sparePartBasicInfo";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }


        /*
      * 方法名称：FrmSparePartClaimDetailInitialCbxDrawDepartment
      * 方法功能描述：查询数据库并返回数据集
      *
      * 创建人：夏阳明
      * 创建时间：20090323
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataSet FrmSparePartClaimDetailInitialCbxDrawDepartment()
        {
            #region
            string locSearchStr;

            locSearchStr = "select id,name from department";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
     * 方法名称：FrmSparePartClaimDetailInitialCbxENo
     * 方法功能描述：查询数据库并返回数据集
     *
     * 创建人：夏阳明
     * 创建时间：20090323
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataSet FrmSparePartClaimDetailInitialCbxENo()
        {
            #region
            string locSearchStr;

            locSearchStr = "select no,id from equipmentInformation";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
    * 方法名称：FrmSparePartClaimDetailSearchEName
    * 方法功能描述：查询数据库并返回数据集
    *
    * 创建人：夏阳明
    * 创建时间：20090323
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataSet FrmSparePartClaimDetailSearchEName(string ENo)
        {
            #region
            string locSearchStr;

            locSearchStr = "select equipmentName.name from equipmentName,equipmentInformation where equipmentInformation.enId = equipmentName.id and equipmentInformation.id = " + int.Parse(ENo);

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：GetInsertSqlps
       * 方法功能描述：插入到领料单的主表中
       *
       * 创建人：夏阳明
       * 创建时间：20090324
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public string GetInsertSqlps(ClaimSparePartBillClass CSPBClass)
        {
            int id = 0;

            DataSet ds = new DataSet();

            string str;

            str = "select id from document where no = '" + CSPBClass.Fno + "'";

            ds = sqlHelper.QueryForDateSet(new ArrayList { str });

            if (ds.Tables[0].Rows.Count != 0)
            {
                id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }



            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into claimSparePartBill(");
            strsql.Append("dId2,claimMan,dId,claimDate,inputDate,inputMan,eiId)");
            strsql.Append("values(");
            strsql.Append(id + ",'");
            strsql.Append(CSPBClass.ClaimMan + "',");
            strsql.Append(CSPBClass.DId + ",'");
            strsql.Append(CSPBClass.ClaimDate + "','");
            strsql.Append(CSPBClass.InputDate + "','");
            strsql.Append(CSPBClass.InputMan + "',");
            strsql.Append(CSPBClass.EiId + ")");
            strsql.Append(";declare  @cspbId bigint");
            strsql.Append(";set @cspbId=@@IDENTITY;");

            return strsql.ToString();
        }

        /*
     * 方法名称：GetInsertSqlpsd
     * 方法功能描述：插入到领料单的明细表中
     *
     * 创建人：夏阳明
     * 创建时间：20090324
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public string GetInsertSqlpsd(ClaimSparePartBillDetailClass CSPBDClass)
        {
            int id = 0;

            DataSet ds = new DataSet();

            string str;

            str = "select id from sparePartBasicInfo where no = '" + CSPBDClass.No + "'";

            ds = sqlHelper.QueryForDateSet(new ArrayList { str });

            if (ds.Tables[0].Rows.Count != 0)
            {
                id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }

            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into claimSparePartBillDetail(");
            strsql.Append("spbiId,unitPrice,count,sum,inputDate,cspbId,inputMan");
            strsql.Append(")values(" + id + "," + CSPBDClass.UnitPrice + ",");
            strsql.Append(CSPBDClass.Count + "," + CSPBDClass.Sum + ",'" + CSPBDClass.InputDate + "',@cspbId,'");
            strsql.Append(CSPBDClass.InputMan + "') select @cspbId;");

            return strsql.ToString();
        }


        /*
    * 方法名称：SumAllDetail
    * 方法功能描述：根据领料单号插入总金额
    *
    * 创建人：夏阳明
    * 创建时间：20090324
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public void SumAllDetail(int id)
        {
            #region
            string locSearchStr;
            string str;

            DataSet ds = new DataSet();

            double sum = 0;

            str = "select sum(sum) from claimSparePartBillDetail where claimSparePartBillDetail.cspbId = " + id;

            ds = sqlHelper.QueryForDateSet(new ArrayList { str });

            if (ds.Tables[0].Rows.Count != 0)
            {
                sum = double.Parse(ds.Tables[0].Rows[0][0].ToString());
            }

            locSearchStr = "update claimSparePartBill set sum = " + sum + " where claimSparePartBill.id = " + id;

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
        }


        /*
    * 方法名称：FrmSparePartClaimDetailInitialCbxFileNo
    * 方法功能描述：查询数据库并返回数据集
    *
    * 创建人：夏阳明
    * 创建时间：20090324
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataSet FrmSparePartClaimDetailInitialCbxFileNo()
        {
            #region
            string locSearchStr;

            locSearchStr = "select no,id from document";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }
        #endregion

        #region//领料单查询

        /*
     * 方法名称：FrmClaimSparePartBillAllInfo
     * 方法功能描述：查询领料单
     *
     * 创建人：夏阳明
     * 创建时间：20090324
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataTable FrmClaimSparePartBillAllInfo(string strWhere)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            //sqlStr.Append("select CSPB.id,d.no,CSPB.claimMan,department.name,CSPB.claimDate,CSPB.sum,CSPB.assessor,CSPB.checkupMan,CSPB.auditingDate,CSPB.checkupDate,CSPB.inputDate,CSPB.inputMan,EI.no no1");
            //sqlStr.Append(" from claimSparePartBill CSPB,document d,department,equipmentInformation EI");
            //sqlStr.Append(" where CSPB.dId2 = d.id and CSPB.dId = department.id and CSPB.eiId = EI.id");
            sqlStr.Append("select CSPB.id,CSPB.claimMan,department.name,CSPB.claimDate,CSPB.sum,CSPB.assessor,CSPB.checkupMan,CSPB.auditingDate,CSPB.checkupDate,CSPB.inputDate,CSPB.inputMan,EI.no no1");
            sqlStr.Append(" from claimSparePartBill CSPB,department,equipmentInformation EI");
            sqlStr.Append(" where CSPB.dId = department.id and CSPB.eiId = EI.id");

            if (strWhere.Trim() != "")
            {
                sqlStr.Append(" and " + strWhere);
            }
            list.Add(sqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];

        }

        /*
    * 方法名称：FrmClaimSparePartBillSearchDetailInfo
    * 方法功能描述：查询领料单明细
    *
    * 创建人：夏阳明
    * 创建时间：20090324
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataTable FrmClaimSparePartBillSearchDetailInfo(string id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            sqlStr.Append("select SPBI.no,SPBI.sort,SPBI.name,SPBI.model,SPBI.unit,CSPBD.count,CSPBD.sum,CSPBD.inputDate,CSPBD.inputMan");
            sqlStr.Append(" from claimSparePartBillDetail CSPBD,sparePartBasicInfo SPBI,sparePartStock SPS");
            sqlStr.Append(" where CSPBD.spbiId = SPBI.id and SPBI.id = SPS.spbiId and CSPBD.cspbId = " + int.Parse(id));

            list.Add(sqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];

        }

        /*
   * 方法名称：DeleteFrmClaimSparePartBill
   * 方法功能描述：删除所选领料单及明细
   *
   * 创建人：夏阳明
   * 创建时间：20090324
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        public bool DeleteFrmClaimSparePartBill(List<long> list1)
        {
            ArrayList list = new ArrayList();

            StringBuilder locStr = new StringBuilder();

            foreach (long id in list1)
            {
                locStr.Append("DELETE FROM claimSparePartBillDetail WHERE cspbId = " + id);
                locStr.Append("DELETE FROM claimSparePartBill WHERE id = " + id);
            }

            //注意顺序：先删子表，再删主表
            list.Add(locStr.ToString());

            return sqlHelper.ExecuteTransaction(list);

        }


        #endregion

        #region//新建出库单

        /*
    * 方法名称：FrmSparePartOutStockDetailInitialCbxDrawNo
    * 方法功能描述：查询数据库并返回数据集
    *
    * 创建人：夏阳明
    * 创建时间：20090324
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataSet FrmSparePartOutStockDetailInitialCbxDrawNo()
        {
            #region
            string locSearchStr;

            locSearchStr = "select id from claimSparePartBill";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：FrmSparePartOutStockDetailLoadDrawInfo
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090324
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet FrmSparePartOutStockDetailLoadDrawInfo(int DrawNo)
        {
            #region
            string locSearchStr;
            ArrayList arrayList = new ArrayList();

            locSearchStr = "select claimMan from claimSparePartBill where id = " + DrawNo;

            arrayList.Add(locSearchStr);


            locSearchStr = "select department.name from department,claimSparePartBill where claimSparePartBill.dId = department.id and claimSparePartBill.id = " + DrawNo;


            arrayList.Add(locSearchStr);


            locSearchStr = "select claimDate from claimSparePartBill where id = " + DrawNo;

            arrayList.Add(locSearchStr);


            locSearchStr = "select equipmentInformation.no from equipmentInformation,claimSparePartBill where claimSparePartBill.eiId = equipmentInformation.id and claimSparePartBill.id = " + DrawNo;

            arrayList.Add(locSearchStr);


            locSearchStr = "select equipmentName.name from equipmentName,equipmentInformation, claimSparePartBill where equipmentName.id = equipmentInformation.enId and equipmentInformation.id = claimSparePartBill.eiId and claimSparePartBill.id = " + DrawNo;

            arrayList.Add(locSearchStr);


            ds = sqlHelper.QueryForDateSet(arrayList);

            #endregion
            return ds;
        }


        /*
      * 方法名称：GetOSInsertSqlps
      * 方法功能描述：插入到出库单的主表中
      *
      * 创建人：夏阳明
      * 创建时间：20090325
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string GetOSInsertSqlps(OutStockClass OSClass,int id)
        {
            //int id = 0;

            //DataSet ds = new DataSet();

            //string str;

            //str = "select id from document where no = '" + CSPBClass.Fno + "'";

            //ds = sqlHelper.QueryForDateSet(new ArrayList { str });

            //if (ds.Tables[0].Rows.Count != 0)
            //{
            //    id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            //}


            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into outStockBill(");
            strsql.Append("dId2,cspbId,storeKeeper,outStockDate,inputDate,inputMan)");
            strsql.Append("values(");
            strsql.Append(id + ",");
            strsql.Append(OSClass.CspbId + ",'");
            strsql.Append(OSClass.StoreKeeper + "','");
            strsql.Append(OSClass.OutStockDate + "','");
            strsql.Append(OSClass.InputDate1 + "','");
            strsql.Append(OSClass.InputMan1 + "')");
            strsql.Append(";declare  @osbId bigint");
            strsql.Append(";set @osbId=@@IDENTITY;");

            return strsql.ToString();
        }


        /*
     * 方法名称：GetOSBDInsertSqlpsd
     * 方法功能描述：插入到出库单的明细表中
     *
     * 创建人：夏阳明
     * 创建时间：20090325
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public string GetOSBDInsertSqlpsd(OutStockBillDetailClass OSBDClass)
        {
            //int id = 0;

            //DataSet ds = new DataSet();

            //string str;

            //str = "select id from sparePartBasicInfo where no = '" + OSBDClass.No + "'";

            //ds = sqlHelper.QueryForDateSet(new ArrayList { str });

            //if (ds.Tables[0].Rows.Count != 0)
            //{
            //    id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            //}

            StringBuilder strsql = new StringBuilder();
            strsql.Append("declare @unitPrice money;set @unitPrice = (select totalPrice/quantity from sparePartStock where spbiId = " + int.Parse(OSBDClass.No) + ");insert into outStockBillDetail(");
            strsql.Append("spbiId,unitPrice,count,sum,inputDate,osbId,inputMan");
            strsql.Append(")values(" + int.Parse(OSBDClass.No) + ",@unitPrice,");
            strsql.Append(OSBDClass.Count + "," + OSBDClass.Count + " * @unitPrice" + ",'" + OSBDClass.InputDate + "',@osbId,'");
            strsql.Append(OSBDClass.InputMan + "'); Update sparePartStock set quantity = (select quantity from sparePartStock where spbiId = " + int.Parse(OSBDClass.No) + ") - " + OSBDClass.Count + ",totalPrice = ((select totalPrice from sparePartStock where spbiId = " + int.Parse(OSBDClass.No) + ") - (" + OSBDClass.Count + " * @unitPrice" + ")) where spbiId = " + int.Parse(OSBDClass.No) + ";select @osbId;");

            return strsql.ToString();
        }

        /*
   * 方法名称：SumOutStockAllDetail
   * 方法功能描述：根据出库单号插入总金额
   *
   * 创建人：夏阳明
   * 创建时间：20090325
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        public void SumOutStockAllDetail(int id)
        {
            #region
            string locSearchStr;
            string str;

            DataSet ds = new DataSet();

            double sum = 0;

            str = "select sum(sum) from outStockBillDetail where outStockBillDetail.osbId = " + id;

            ds = sqlHelper.QueryForDateSet(new ArrayList { str });

            if (ds.Tables[0].Rows.Count != 0)
            {
                sum = double.Parse(ds.Tables[0].Rows[0][0].ToString());
            }

            locSearchStr = "update outStockBill set sum = " + sum + " where outStockBill.id = " + id;

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
        }

        /*
      * 方法名称：FrmSparePartOutStockDetailInitialCbxNo
      * 方法功能描述：根据领料单号查询数据库并返回数据集
      *
      * 创建人：夏阳明
      * 创建时间：20090325
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataSet FrmSparePartOutStockDetailInitialCbxNo(int id)
        {
            #region
            string locSearchStr;

            locSearchStr = "select no,sparePartBasicInfo.id from sparePartBasicInfo,claimSparePartBillDetail where claimSparePartBillDetail.spbiId = sparePartBasicInfo.id and claimSparePartBillDetail.cspbId = " + id;

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }


        /*
       * 方法名称：FrmSparePartOutStockDetailLoadEquipNo
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090325
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet FrmSparePartOutStockDetailLoadEquipNo(string equipNO,int id1)
        {
            #region
            string locSearchStr;
            ArrayList arrayList = new ArrayList();

            int id;

            id = int.Parse(equipNO.Trim());

            locSearchStr = "select sparePartBasicInfo.sort from sparePartBasicInfo where sparePartBasicInfo.id = " + id;

            arrayList.Add(locSearchStr);


            locSearchStr = "select sparePartBasicInfo.name from sparePartBasicInfo where sparePartBasicInfo.id = " + id;


            arrayList.Add(locSearchStr);


            locSearchStr = "select sparePartBasicInfo.model from sparePartBasicInfo where sparePartBasicInfo.id = " + id;

            arrayList.Add(locSearchStr);


            locSearchStr = "select sparePartBasicInfo.unit from sparePartBasicInfo where sparePartBasicInfo.id = " + id;

            arrayList.Add(locSearchStr);


            //locSearchStr = "select sparePartStock.unitPrice from sparePartStock,sparePartBasicInfo where sparePartStock.spbiId = sparePartBasicInfo.id and sparePartBasicInfo.id = " + id;

            //arrayList.Add(locSearchStr);


            locSearchStr = "select claimSparePartBillDetail.count from claimSparePartBillDetail where cspbId = " + id1 + "and spbiId = " + id;

            arrayList.Add(locSearchStr);


            locSearchStr = "select sparePartStock.quantity from sparePartStock,sparePartBasicInfo where sparePartStock.spbiId = sparePartBasicInfo.id and sparePartStock.spbiId = " + id;

            arrayList.Add(locSearchStr);


            ds = sqlHelper.QueryForDateSet(arrayList);

            #endregion
            return ds;
        }

        /*
  * 方法名称：FrmSparePartClaimDetailInitialCbxStoreKeeper
  * 方法功能描述：查询数据库并返回数据集
  *
  * 创建人：夏阳明
  * 创建时间：20090401
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */
        public DataSet FrmSparePartClaimDetailInitialCbxStoreKeeper()
        {
            #region
            string locSearchStr;

            locSearchStr = "select distinct name from personnelInfo";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        #endregion

        #region//出库单查询

        /*
     * 方法名称：FrmFrmSparePartOutAllInfo
     * 方法功能描述：查询出库单
     *
     * 创建人：夏阳明
     * 创建时间：20090325
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataTable FrmFrmSparePartOutAllInfo(string strWhere)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            //sqlStr.Append("select OSB.id,d.no,OSB.cspbId CSPBID,CSPB.claimMan,department.name,CSPB.claimDate,OSB.sum,EI.no no1,OSB.assessor,OSB.checkupMan,OSB.auditingDate,OSB.checkupDate,OSB.storeKeeper,OSB.outStockDate,OSB.inputDate,OSB.inputMan");
            //sqlStr.Append(" from outStockBill OSB,document d,department,equipmentInformation EI,claimSparePartBill CSPB");
            //sqlStr.Append(" where OSB.dId2 = d.id and CSPB.dId = department.id and CSPB.eiId = EI.id and OSB.cspbId = CSPB.id and OSB.parentId is null");
            
            //sqlStr.Append("select OSB.id,OSB.cspbId CSPBID,CSPB.claimMan,department.name,CSPB.claimDate,OSB.sum,EI.no no1,OSB.assessor,OSB.checkupMan,OSB.auditingDate,OSB.checkupDate,OSB.storeKeeper,OSB.outStockDate,OSB.inputDate,OSB.inputMan");
            //sqlStr.Append(" from outStockBill OSB,department,equipmentInformation EI,claimSparePartBill CSPB");
            //sqlStr.Append(" where CSPB.dId = department.id and CSPB.eiId = EI.id and OSB.cspbId = CSPB.id and OSB.parentId is null");

            sqlStr.Append("select OSB.id,OSB.cspbId CSPBID,CSPB.claimMan,department.name,CSPB.claimDate,EI.no no1,OSB.assessor,OSB.checkupMan,OSB.auditingDate,OSB.checkupDate,OSB.storeKeeper,OSB.outStockDate,OSB.inputDate,OSB.inputMan");
            sqlStr.Append(" from outStockBill OSB,department,equipmentInformation EI,claimSparePartBill CSPB");
            sqlStr.Append(" where CSPB.dId = department.id and CSPB.eiId = EI.id and OSB.cspbId = CSPB.id and OSB.parentId is null");

            if (strWhere.Trim() != "")
            {
                sqlStr.Append(" and " + strWhere);
            }
            list.Add(sqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];

        }

        /*
    * 方法名称：FrmFrmSparePartOutSearchDetailInfo
    * 方法功能描述：查询出库单明细
    *
    * 创建人：夏阳明
    * 创建时间：20090325
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataTable FrmFrmSparePartOutSearchDetailInfo(string id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            //sqlStr.Append("select SPBI.no,SPBI.sort,SPBI.name,SPBI.model,SPBI.unit,OSBD.count,OSBD.sum,OSBD.inputDate,OSBD.inputMan");
            //sqlStr.Append(" from outStockBillDetail OSBD,sparePartBasicInfo SPBI,sparePartStock SPS");
            //sqlStr.Append(" where OSBD.spbiId = SPBI.id and SPBI.id = SPS.spbiId and OSBD.osbId = " + int.Parse(id));

            sqlStr.Append("select SPBI.no,SPBI.sort,SPBI.name,SPBI.model,SPBI.unit,OSBD.count,OSBD.inputDate,OSBD.inputMan");
            sqlStr.Append(" from outStockBillDetail OSBD,sparePartBasicInfo SPBI,sparePartStock SPS");
            sqlStr.Append(" where OSBD.spbiId = SPBI.id and SPBI.id = SPS.spbiId and OSBD.osbId = " + int.Parse(id));


            list.Add(sqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];

        }

        /*
  * 方法名称：DeleteFrmFrmSparePartOut
  * 方法功能描述：删除所选出库单及明细
  *
  * 创建人：夏阳明
  * 创建时间：20090325
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */
        public bool DeleteFrmFrmSparePartOut(List<long> list1)
        {
            ArrayList list = new ArrayList();

            StringBuilder locStr = new StringBuilder();

            foreach (long id in list1)
            {
                locStr.Append("DELETE FROM outStockBillDetail WHERE osbId = " + id);
                locStr.Append("DELETE FROM outStockBill WHERE id = " + id);
            }

            //注意顺序：先删子表，再删主表
            list.Add(locStr.ToString());

            return sqlHelper.ExecuteTransaction(list);

        }

        #endregion

        #region//新建退库单

        /*
    * 方法名称：FrmSparePartOutStockRefundDetailInitialCbxOutNo
    * 方法功能描述：查询数据库并返回数据集
    *
    * 创建人：夏阳明
    * 创建时间：20090326
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataSet FrmSparePartOutStockRefundDetailInitialCbxOutNo()
        {
            #region
            string locSearchStr;

            locSearchStr = "select id from outStockBill where parentId is null";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：FrmSparePartOutStockRefundDetailLoadOutNo
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090326
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet FrmSparePartOutStockRefundDetailLoadOutNo(int OutNo)
        {
            #region
            string locSearchStr;
            ArrayList arrayList = new ArrayList();


            //locSearchStr = "select document.no,outStockBill.cspbId,claimSparePartBill.claimMan,department.name,claimSparePartBill.claimDate,equipmentInformation.no,equipmentName.name,outStockBill.outStockDate ";
            //locSearchStr = locSearchStr + "from document,outStockBill,claimSparePartBill,department,equipmentInformation,equipmentName ";
            //locSearchStr = locSearchStr + "where document.id = outStockBill.dId2 and outStockBill.cspbId = claimSparePartBill.id and claimSparePartBill.dId = department.id and claimSparePartBill.eiId = equipmentInformation.id and equipmentInformation.enId = equipmentName.id";
            //locSearchStr = locSearchStr + " and outStockBill.id = " + OutNo;
            locSearchStr = "select outStockBill.cspbId,claimSparePartBill.claimMan,department.name,claimSparePartBill.claimDate,equipmentInformation.no,equipmentName.name,outStockBill.outStockDate ";
            locSearchStr = locSearchStr + "from outStockBill,claimSparePartBill,department,equipmentInformation,equipmentName ";
            locSearchStr = locSearchStr + "where outStockBill.cspbId = claimSparePartBill.id and claimSparePartBill.dId = department.id and claimSparePartBill.eiId = equipmentInformation.id and equipmentInformation.enId = equipmentName.id";
            locSearchStr = locSearchStr + " and outStockBill.id = " + OutNo;


            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
     * 方法名称：FrmSparePartOutStockRefundDetailInitialCbxNo
     * 方法功能描述：根据出库单号查询数据库并返回数据集
     *
     * 创建人：夏阳明
     * 创建时间：20090326
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataSet FrmSparePartOutStockRefundDetailInitialCbxNo(int id)
        {
            #region
            string locSearchStr;

            locSearchStr = "select no,sparePartBasicInfo.id from sparePartBasicInfo,claimSparePartBillDetail,outStockBill,claimSparePartBill where claimSparePartBillDetail.spbiId = sparePartBasicInfo.id and claimSparePartBillDetail.cspbId = claimSparePartBill.id and claimSparePartBill.id = outStockBill.cspbId and outStockBill.id = " + id;

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：FrmSparePartOutStockRefundDetailLoadEquipNo
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090326
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet FrmSparePartOutStockRefundDetailLoadEquipNo(string equipNO, int id1)
        {
            #region
            string locSearchStr;
            ArrayList arrayList = new ArrayList();

            int id; // 备件编号

            id = int.Parse(equipNO.Trim());
            // 出库数量 = 出库数量 - 所有出库单号相同的退库数量
            locSearchStr = "select sparePartBasicInfo.sort,sparePartBasicInfo.name,sparePartBasicInfo.model,sparePartBasicInfo.unit,outStockBillDetail.unitPrice,claimSparePartBillDetail.count,(outStockBillDetail.count + IsNull((select Sum(outStockBillDetail.count) from outStockBillDetail,outStockBill where outStockBill.id = outStockBillDetail.osbId and parentId = " + id1 + " Group by parentId),0)) OutCount ";
            locSearchStr = locSearchStr + "from sparePartBasicInfo,outStockBillDetail,claimSparePartBillDetail,outStockBill ";
            locSearchStr = locSearchStr + "where sparePartBasicInfo.id = outStockBillDetail.spbiId and  outStockBillDetail.osbId = outStockBill.id and outStockBill.cspbId = claimSparePartBillDetail.cspbId and claimSparePartBillDetail.spbiId = sparePartBasicInfo.id and sparePartBasicInfo.id = " + id + " and outStockBill.id = " + id1 + " and outStockBill.parentId is null";


            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：SearchDID2
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090326
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet SearchDID2(string no)
        {
            #region
            string locSearchStr;

            int id; // 备件编号

            locSearchStr = "select id from document where no = '" + no + "'";

            ds = sqlHelper.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
     * 方法名称：GetTOSInsertSqlps
     * 方法功能描述：插入到出库单的主表中(退库)
     *
     * 创建人：夏阳明
     * 创建时间：20090326
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public string GetTOSInsertSqlps(OutStockClass OSClass,int OutId)
        {
            int id = 0;

            DataSet ds = new DataSet();

            string str;

            str = "select id from document where no = '" + OSClass.Fno1 + "'";

            ds = sqlHelper.QueryForDateSet(new ArrayList { str });

            if (ds.Tables[0].Rows.Count != 0)
            {
                id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }


            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into outStockBill(");
            strsql.Append("dId2,cspbId,storeKeeper,outStockDate,inputDate,inputMan,parentId)");
            strsql.Append("values(");
            strsql.Append(id + ",");
            strsql.Append(OSClass.CspbId + ",'");
            strsql.Append(OSClass.StoreKeeper + "','");
            strsql.Append(OSClass.OutStockDate + "','");
            strsql.Append(OSClass.InputDate1 + "','");
            strsql.Append(OSClass.InputMan1 + "'," + OutId + ")");
            strsql.Append(";declare  @osbId bigint");
            strsql.Append(";set @osbId=@@IDENTITY;");

            return strsql.ToString();
        }

        /*
     * 方法名称：GetTOSBDInsertSqlpsd
     * 方法功能描述：插入到出库单的明细表中（退库）
     *
     * 创建人：夏阳明
     * 创建时间：20090326
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public string GetTOSBDInsertSqlpsd(OutStockBillDetailClass OSBDClass)
        {
            //int id = 0;

            //DataSet ds = new DataSet();

            //string str;

            //str = "select id from sparePartBasicInfo where no = '" + OSBDClass.No + "'";

            //ds = sqlHelper.QueryForDateSet(new ArrayList { str });

            //if (ds.Tables[0].Rows.Count != 0)
            //{
            //    id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            //}

            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into outStockBillDetail(");
            strsql.Append("spbiId,unitPrice,count,sum,inputDate,osbId,inputMan");
            strsql.Append(")values(" + int.Parse(OSBDClass.No) + "," + OSBDClass.UnitPrice + ",-");
            strsql.Append(OSBDClass.TCount + ",-" + OSBDClass.Sum + ",'" + OSBDClass.InputDate + "',@osbId,'");
            strsql.Append(OSBDClass.InputMan + "'); Update sparePartStock set sparePartStock.quantity = (select quantity from sparePartStock where spbiId = " + int.Parse(OSBDClass.No) + ") + " + OSBDClass.TCount + ",sparePartStock.totalPrice = (" + OSBDClass.UnitPrice + " * " + OSBDClass.TCount + " + (select totalPrice from sparePartStock where spbiId = " + int.Parse(OSBDClass.No) + ")" + ") where spbiId = " + int.Parse(OSBDClass.No) + ";select @osbId;");

            

            return strsql.ToString();
        }

        #endregion

        #region//退库单查询

        /*
     * 方法名称：FrmSparePartRefoundAllInfo
     * 方法功能描述：查询退库单单
     *
     * 创建人：夏阳明
     * 创建时间：20090327
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataTable FrmSparePartRefoundAllInfo(string strWhere)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            //sqlStr.Append("select OSB.id TId,OSB.parentId Pid,d.no,OSB.cspbId CSPBID,CSPB.claimMan,department.name,CSPB.claimDate,abs(OSB.sum) sum,EI.no no1,OSB.assessor,OSB.checkupMan,OSB.auditingDate,OSB.checkupDate,OSB.storeKeeper,(select outStockDate from outStockBill where id = OSB.parentId) ODate,OSB.outStockDate TDate,OSB.inputDate,OSB.inputMan");
            //sqlStr.Append(" from outStockBill OSB,document d,department,equipmentInformation EI,claimSparePartBill CSPB");
            //sqlStr.Append(" where OSB.dId2 = d.id and CSPB.dId = department.id and CSPB.eiId = EI.id and OSB.cspbId = CSPB.id and OSB.parentId is not null");
           
            //sqlStr.Append("select OSB.id TId,OSB.parentId Pid,OSB.cspbId CSPBID,CSPB.claimMan,department.name,CSPB.claimDate,abs(OSB.sum) sum,EI.no no1,OSB.assessor,OSB.checkupMan,OSB.auditingDate,OSB.checkupDate,OSB.storeKeeper,(select outStockDate from outStockBill where id = OSB.parentId) ODate,OSB.outStockDate TDate,OSB.inputDate,OSB.inputMan");
            //sqlStr.Append(" from outStockBill OSB,department,equipmentInformation EI,claimSparePartBill CSPB");
            //sqlStr.Append(" where CSPB.dId = department.id and CSPB.eiId = EI.id and OSB.cspbId = CSPB.id and OSB.parentId is not null");

            sqlStr.Append("select OSB.id TId,OSB.parentId Pid,OSB.cspbId CSPBID,CSPB.claimMan,department.name,CSPB.claimDate,EI.no no1,OSB.assessor,OSB.checkupMan,OSB.auditingDate,OSB.checkupDate,OSB.storeKeeper,(select outStockDate from outStockBill where id = OSB.parentId) ODate,OSB.outStockDate TDate,OSB.inputDate,OSB.inputMan");
            sqlStr.Append(" from outStockBill OSB,department,equipmentInformation EI,claimSparePartBill CSPB");
            sqlStr.Append(" where CSPB.dId = department.id and CSPB.eiId = EI.id and OSB.cspbId = CSPB.id and OSB.parentId is not null");

            if (strWhere.Trim() != "")
            {
                sqlStr.Append(" and " + strWhere);
            }
            list.Add(sqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];

        }

        /*
   * 方法名称：FrmSparePartRefoundSearchDetailInfo
   * 方法功能描述：查询退库库单明细
   *
   * 创建人：夏阳明
   * 创建时间：20090327
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        public DataTable FrmSparePartRefoundSearchDetailInfo(string id)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            //sqlStr.Append("select SPBI.no Bno,SPBI.sort,SPBI.name Bname,SPBI.model,SPBI.unit,SPS.unitPrice,(select sum(outStockBillDetail.count) from outStockBillDetail where outStockBillDetail.osbId = (select parentId from outStockBill where id = " + int.Parse(id) + ")) count,abs(OSBD.count) TCount,abs(OSBD.sum) Bsum,OSBD.inputDate BinputDate,OSBD.inputMan BinputMan");
            //sqlStr.Append(" from outStockBillDetail OSBD,sparePartBasicInfo SPBI,sparePartStock SPS");
            //sqlStr.Append(" where OSBD.spbiId = SPBI.id and SPBI.id = SPS.spbiId and OSBD.osbId = " + int.Parse(id));
            sqlStr.Append("select SPBI.no Bno,SPBI.sort,SPBI.name Bname,SPBI.model,SPBI.unit,(select sum(outStockBillDetail.count) from outStockBillDetail where outStockBillDetail.osbId = (select parentId from outStockBill where id = " + int.Parse(id) + ")) count,abs(OSBD.count) TCount,OSBD.inputDate BinputDate,OSBD.inputMan BinputMan");
            sqlStr.Append(" from outStockBillDetail OSBD,sparePartBasicInfo SPBI,sparePartStock SPS");
            sqlStr.Append(" where OSBD.spbiId = SPBI.id and SPBI.id = SPS.spbiId and OSBD.osbId = " + int.Parse(id));

            list.Add(sqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];

        }

        /*
 * 方法名称：DeleteFrmSparePartRefound
 * 方法功能描述：删除所选退库单及明细
 *
 * 创建人：夏阳明
 * 创建时间：20090327
 *
 * 修改人：
 * 修改时间：
 * 修改内容：
 *
 */
        public bool DeleteFrmSparePartRefound(List<long> list1)
        {
            ArrayList list = new ArrayList();

            StringBuilder locStr = new StringBuilder();

            foreach (long id in list1)
            {
                locStr.Append("DELETE FROM outStockBillDetail WHERE osbId = " + id);
                locStr.Append("DELETE FROM outStockBill WHERE id = " + id);
            }

            //注意顺序：先删子表，再删主表
            list.Add(locStr.ToString());

            return sqlHelper.ExecuteTransaction(list);

        }


        #endregion

        #region //备品配件库存查询

        /*
    * 方法名称：FormFrmSparePartStockSearch
    * 方法功能描述：查询备品配件库存信息
    *
    * 创建人：夏阳明
    * 创建时间：20090413
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataSet FormFrmSparePartStockSearch(string searchStr, string condition, int verifyBit)
        {
            DataSet ds = new DataSet();

            ArrayList arrayList = new ArrayList();

            string locsearchStr;

            if (verifyBit == 0)
            {
                locsearchStr = "select no,sort,name,model,(totalPrice / quantity) unitPrice,SPS.quantity,SPS.totalPrice,SPS.inputMan,SPS.inputDate";
                locsearchStr = locsearchStr + " from sparePartBasicInfo SPBI,sparePartStock SPS";
                locsearchStr = locsearchStr + " where SPBI.id = SPS.spbiId";


                arrayList.Add(locsearchStr);

                ds = sqlHelper.QueryForDateSet(arrayList);
            }
            else
            {
                locsearchStr = "select no,sort,name,model,(totalPrice / quantity) unitPrice,SPS.quantity,SPS.totalPrice,SPS.inputMan,SPS.inputDate";
                locsearchStr = locsearchStr + " from sparePartBasicInfo SPBI,sparePartStock SPS";
                locsearchStr = locsearchStr + " where SPBI.id = SPS.spbiId and " + condition + " like '%" + searchStr + "%'";


                arrayList.Add(locsearchStr);

                ds = sqlHelper.QueryForDateSet(arrayList);
            }
            return ds;
        }


        #endregion
    }



    #region  //数据库操作类：设备使用记录

    /*
    * 类名称：EquipmnetUseDB
    * 类功能描述：为“设备使用记录”提供数据库操作
    *
    * 创建人：关启学
    * 创建时间：2009-03-20
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

    class EquipmnetUseDB
    {
        #region//参数初始化

        //用户“拌和站软件”的数据库操作
        private SqlHelper sqlHelper = new SqlHelper();

        //设备使用记录 SQL字符串
        private string equipmentUseSelectStr =
            "   SELECT "
            + "   equipmentUse.date          AS [useMonth],"         //使用月份
            + "   equipmentInformation.no    AS [equipmentNo],"      //设备编号
            + "   equipmentName.name         AS [equipmentName],"    //设备名称
            + "   equipmentUse.no            AS [documentNo],"       //文档编号

            + "   equipmentUse.inputDate     AS [inputDate],"        //录入时间
            + "   equipmentUse.inputMan      AS [inputMan],"         //录入人
            + "   equipmentUse.id            AS [id],"               //id
            + "   equipmentUse.eiId          AS [eiId]"              //设备信息表id
            + " FROM equipmentUse, equipmentInformation, equipmentName"
            + " WHERE equipmentUse.eiId = equipmentInformation.id"
            + " AND   equipmentInformation.enId = equipmentName.id";


        //设备使用记录明细 SQL字符串
        private string equipmentUseDetailSelectStr =
            "   SELECT "
            + "   equipmentUseDetail.useDate       AS [useDate],"       //使用日期
            + "   equipmentUseDetail.[content]     AS [content],"       //工作内容
            + "   equipmentUseDetail.workTime      AS [workTime],"      //工作台时
            + "   equipmentUseDetail.noWorkTime    AS [noWorkTime],"    //非工作时间
            + "   equipmentUseDetail.piId          AS [piId],"          //操作员

            + "   equipmentUseDetail.inputDate     AS [inputDate],"     //录入时间
            + "   equipmentUseDetail.inputMan      AS [inputMan],"      //录入人
            + "   equipmentUseDetail.id            AS [id],"            //id
            + "   equipmentUseDetail.euId          AS [euId]"           //设备使用记录id（父表）
            + " FROM equipmentUseDetail"
            + " WHERE equipmentUseDetail.euId = {0}";

        #endregion


        #region//用于填充“下拉列表”、与下拉列表相关控件数据的方法

        //查询“设备信息”：用于下拉列表
        public DataTable GetEquipmentInfo()
        {
            string selectString = "SELECT id, no FROM equipmentInformation";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“人员信息”：设备信息明细datagridview内的下拉列表
        public DataTable GetPersonnelInfo()
        {
            string selectString = "SELECT id, name FROM personnelInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“设备名称”，根据“设备id”
        public string GetEquipmentName(long enId)
        {
            string selectString =
                " SELECT equipmentName.name FROM equipmentName, equipmentInformation "
                + "WHERE equipmentName.id = equipmentInformation.enId AND equipmentInformation.id = " + enId;

            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            string name = "";
            if (dt.Rows.Count > 0)
            {
                name = dt.Rows[0]["name"].ToString();
            }

            return name;
        }

        #endregion


        #region//用于填充“DataGridView”数据内容的方法

        //查询“设备使用记录”
        public DataTable GetEquipmentUse()
        {
            return sqlHelper.QueryForDateSet(new ArrayList() { equipmentUseSelectStr }).Tables[0];
        }

        //查询“设备使用记录”，按“年”、“月”和“设备编号”查询
        public DataTable GetEquipmentUse(DateTime dt, string equipmentNo)
        {
            string select = equipmentUseSelectStr
                + " AND   year(equipmentUse.date) = '{0}'"
                + " AND   month(equipmentUse.date) = '{1}'"
                + " AND   equipmentInformation.no like '%{2}%'";

            string selectString = string.Format(select, dt.Year, dt.Month, equipmentNo);
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }


        //查询“设备使用记录明细”，按“设备使用记录id”查询
        public DataTable GetEquipmentUseDetail(long euId)
        {
            string selectString = string.Format(equipmentUseDetailSelectStr, euId);
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }


        //查询“设备使用记录表”中是否存在指定的设备使用记录，如果该使用记录存在，则返回该记录的id，否则返回0
        private long SearchId(EquipmentUse equipmentUse)
        {
            long euId = 0;
            string select =
                "   SELECT id FROM equipmentUse"
                + " WHERE year(equipmentUse.date) = '{0}'"
                + " AND   month(equipmentUse.date) = '{1}'"
                + " AND   equipmentUse.eiId = {2}";

            string selectString = string.Format(select, equipmentUse.Date.Year, equipmentUse.Date.Month, equipmentUse.EiId);

            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
            if (dt.Rows.Count > 0)
            {
                euId = Convert.ToInt64(dt.Rows[0]["id"].ToString());
            }

            return euId;
        }

        #endregion


        #region//业务实体操作方法：插入方法

        //级联插入新的“设备使用记录”，并将equipmentUse的id值赋值为新增记录的id或查询出已有的id
        public void InsertEquipmentUse(EquipmentUse equipmentUse)
        {
            long euId = SearchId(equipmentUse);

            //如果数据库中不存在该设备使用记录，则执行插入操作
            if (euId == 0)
            {
                //主表insert操作：向“设备使用记录表”增加信息
                string insertEquipmentUse =
                    "   INSERT INTO equipmentUse"
                    + " (date, eiId, no, inputDate, inputMan)"
                    + " VALUES"
                    + " ('{0}',{1},'{2}',{3},'{4}')"
                    + " ;DECLARE  @euId bigint"
                    + " ;SET @euId = @@IDENTITY";
                string main = string.Format(insertEquipmentUse, equipmentUse.Date, equipmentUse.EiId, equipmentUse.No, "getdate()", equipmentUse.InputMan);


                //从表insert操作：向“设备使用记录明细表”增加信息，为本月每一天添加一条空记录
                string insertEquipmentUseDetail =
                    "   INSERT INTO equipmentUseDetail"
                    + " ( euId, inputDate, inputMan, useDate)"
                    + " VALUES"
                    + " ( @euId, getdate(), '" + equipmentUse.InputMan + "','{0}')";

                //形成本月的使用记录明细（一天一条记录）
                int firstDay = 1;
                int lastDay = DateTime.DaysInMonth(equipmentUse.Date.Year, equipmentUse.Date.Month);
                string detial = "";
                DateTime date;
                for (int i = firstDay; i < lastDay + 1; ++i)
                {
                    date = new DateTime(equipmentUse.Date.Year, equipmentUse.Date.Month, i);
                    detial += string.Format(insertEquipmentUseDetail, date);
                }

                //最终合并的SQL语句
                string sqlString = main + detial + " SELECT @euId";
                DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { sqlString }).Tables[0];

                euId = Convert.ToInt64(dt.Rows[0][0].ToString());
            }

            //返回查询或插入的设备使用记录id值
            equipmentUse.Id = euId;
        }

        //设备使用信息明细：利用DataTable内记录的状态生成数据库操作SQL语句
        private ArrayList EquipmentUseDetailToSQLArray(DataTable table)
        {
            ArrayList list = new ArrayList();
            string sqlString = null;
            string insertSQL =
                "   UPDATE equipmentUseDetail"
                + " SET"
                + "    [content] = '{0}',"
                + "    workTime = '{1}',"
                + "    noWorkTime = '{2}',"
                + "    piId = {3}"
                + " WHERE id = {4}";
            long piId = 0;

            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Modified)
                {
                    if (row["piId"].ToString().Equals(""))
                    {
                        sqlString = string.Format(insertSQL
                        , row["content"].ToString(), row["workTime"].ToString(), row["noWorkTime"].ToString(), "null", row["id"].ToString());
                    }
                    else
                    {
                        sqlString = string.Format(insertSQL
                        , row["content"].ToString(), row["workTime"].ToString(), row["noWorkTime"].ToString(), row["piId"].ToString(), row["id"].ToString());
                    }

                    list.Add(sqlString);
                }
            }

            return list;
        }

        //设备使用信息明细：保存“设备使用信息明细”
        public void SaveEquipmentUseDetail(DataTable table)
        {
            //获得批量更新的SQL语句
            ArrayList sqlList = EquipmentUseDetailToSQLArray(table);

            //执行批量更新
            sqlHelper.ExecuteTransaction(sqlList);

            table.AcceptChanges();
        }

        #endregion


        #region//业务实体操作方法：删除方法

        //删除“设备使用记录”，级联删除明细从表，根据设备使用记录id
        public void DeleteEquipmentUse(long equipmentUseId)
        {
            ArrayList sqlList = new ArrayList();
            string deleteEquipmentUseDetail = "DELETE FROM equipmentUseDetail WHERE euId = " + equipmentUseId;
            string deleteEquipmentUse = "DELETE FROM equipmentUse WHERE id = " + equipmentUseId;

            //注意顺序：先删子表，再删主表
            sqlList.Add(deleteEquipmentUseDetail);
            sqlList.Add(deleteEquipmentUse);

            sqlHelper.ExecuteTransaction(sqlList);

        }


        #endregion       

    }

    #endregion

    #region  //数据库操作类：设备保修计划

    /*
    * 类名称：EquipmentRepairPlanDB
    * 类功能描述：为“设备保修计划”提供数据库操作
    *
    * 创建人：关启学
    * 创建时间：2009-03-22
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

    class EquipmentRepairPlanDB
    {
        #region//参数初始化

        //用户“拌和站软件”的数据库操作
        private SqlHelper sqlHelper = new SqlHelper();

        //设备保修计划 SQL字符串
        private string equipmentRepairPlanSelectStr =
            "   SELECT "
            + "   equipmentRepairPlan.date          AS [planDate],"         //计划时间
            + "   equipmentRepairPlan.producer      AS [producer],"         //制表人
            + "   equipmentRepairPlan.assessor      AS [assessor],"         //审核人
            + "   equipmentRepairPlan.checkupMan    AS [checkupMan],"       //审批人           

            + "   equipmentRepairPlan.inputDate     AS [inputDate],"        //录入时间
            + "   equipmentRepairPlan.inputMan      AS [inputMan],"         //录入人
            + "   equipmentRepairPlan.id            AS [id]"                //id
            + " FROM equipmentRepairPlan, document";



        //设备保修计划明细 SQL字符串
        private string equipmentRepairPlanDetailSelectStr =
            "   SELECT "
            + "   equipmentInformation.no                             AS [equipmentNo],"          //设备编号
            + "   equipmentName.name                                  AS [equipmentName],"        //设备名称
            + "   department.name                                     AS [departmentName],"       //部门名称
            + "   equipmentRepairPlanDetail.serviceKind               AS [serviceKind],"          //保修类别
            + "   equipmentRepairPlanDetail.workTime                  AS [workTime],"             //工作工时
            + "   equipmentRepairPlanDetail.repairTime                AS [repairTime],"           //维修工时
            + "   equipmentRepairPlanDetail.planConsume               AS [planConsume],"          //计划费用
            + "   equipmentRepairPlanDetail.repairMan                 AS [repairMan],"            //主修人
            + "   equipmentRepairPlanDetail.finishDate                AS [finishDate],"           //完成时间
            + "   equipmentRepairPlanDetail.previousRepairDate        AS [previousRepairDate],"   //上次维修时间
            + "   equipmentRepairPlanDetail.previousServiceKind       AS [previousServiceKind],"  //上次保修类别

            + "   equipmentRepairPlanDetail.inputDate                 AS [inputDate],"            //录入时间
            + "   equipmentRepairPlanDetail.inputMan                  AS [inputMan],"             //录入人
            + "   equipmentRepairPlanDetail.id                        AS [id],"                   //id
            + "   equipmentRepairPlanDetail.eiId                      AS [eiId],"                 //设备信息表id
            + "   equipmentRepairPlanDetail.erpId                     AS [erpId],"                //设备保修计划表id（父表）
            + "   equipmentRepairPlanDetail.dId                       AS [departmentId]"          //部门表id
            + " FROM equipmentRepairPlanDetail, equipmentInformation, equipmentName, department"
            + " WHERE equipmentRepairPlanDetail.eiId = equipmentInformation.id"
            + " AND   equipmentInformation.enId = equipmentName.id"
            + " AND   equipmentRepairPlanDetail.dId = department.id"
            + " AND   equipmentRepairPlanDetail.erpId = {0}";

        #endregion


        #region//用于填充“下拉列表”、与下拉列表相关控件数据的方法

        //查询“设备信息”：用于下拉列表
        public DataTable GetEquipmentInfo()
        {
            string selectString = "SELECT id, no FROM equipmentInformation";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“文档信息”：用于下拉列表
        public DataTable GetDocument()
        {
            string selectString = "SELECT id, no FROM document";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“部门信息”：用于下拉列表
        public DataTable GetDepartment()
        {
            string selectString = "SELECT id, name FROM department";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“人员信息”：设备信息明细datagridview内的下拉列表
        public DataTable GetPersonnelInfo()
        {
            string selectString = "SELECT id, name FROM personnelInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }
        
        
        //查询“设备名称”，根据“设备id”
        public string GetEquipmentName(long enId)
        {
            string selectString =
                " SELECT equipmentName.name FROM equipmentName, equipmentInformation "
                + "WHERE equipmentName.id = equipmentInformation.enId AND equipmentInformation.id = " + enId;

            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            string name = "";
            if (dt.Rows.Count > 0)
            {
                name = dt.Rows[0]["name"].ToString();
            }

            return name;
        }        

        //查询“文档名称”，根据“文档id”
        public string GetDocumentName(long id)
        {
            string selectString = "SELECT name FROM document WHERE id = " + id;

            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            string name = "";
            if (dt.Rows.Count > 0)
            {
                name = dt.Rows[0]["name"].ToString();
            }

            return name;
        }

        #endregion


        #region//用于填充“DataGridView”数据内容的方法

        //查询“设备保修计划”
        public DataTable GetEquipmentRepairPlan()
        {
            return sqlHelper.QueryForDateSet(new ArrayList() { equipmentRepairPlanSelectStr }).Tables[0];
        }

        //查询“设备保修计划”，按“制定时间”查询
        public DataTable GetEquipmentRepairPlan(DateTime dt)
        {
            string select = equipmentRepairPlanSelectStr
                + " AND   equipmentRepairPlan.date >= '{0}'"
                + " AND   equipmentRepairPlan.date < '{1}'";

            string selectString = string.Format(select, dt, dt.AddDays(1));
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“设备保修计划明细”，按“设备保修计划id”查询
        public DataTable GetEquipmentRepairPlanDetail(long erpId)
        {
            string selectString = string.Format(equipmentRepairPlanDetailSelectStr, erpId);
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        #endregion


        #region//业务实体操作方法：插入方法

        //级联插入新的“设备保修计划”
        public void InsertEquipmentRepairPlan(EquipmentRepairPlan plan, DataTable dtPlanDetail)
        {
            //主表insert操作：向“设备保修计划表”增加信息
            string insertOverall =
                "   INSERT INTO equipmentRepairPlan"
                + " (date, dId, producer, inputDate, inputMan)"
                + " VALUES"
                + " ('{0}',{1},'{2}',getdate(),'{3}')"
                + " ;DECLARE  @erpId bigint"
                + " ;SET @erpId = @@IDENTITY";
            string main = string.Format(insertOverall, plan.Date, plan.DId, plan.Producer, plan.InputMan);


            //从表insert操作：向“设备保修计划明细表”增加信息
            string insertDetail =
                "   INSERT INTO equipmentRepairPlanDetail"
                + " ( erpId, eiId, dId, serviceKind, workTime, repairTime, planConsume, repairMan, finishDate, previousRepairDate, previousServiceKind, inputDate, inputMan)"
                + " VALUES"
                + " ( @erpId, {0}, {1}, '{2}', '{3}', '{4}', {5}, '{6}', '{7}', '{8}', '{9}', getdate(), '{10}')";

            //形成本月的使用记录明细（一天一条记录）
            string detail = "";
            foreach (DataRow row in dtPlanDetail.Rows)
            {
                detail += string.Format(insertDetail,
                    row["eiId"], row["departmentId"], row["serviceKind"], row["workTime"], row["repairTime"], row["planConsume"]
                    , row["repairMan"], row["finishDate"], row["previousRepairDate"], row["previousServiceKind"], row["inputMan"]);
            }

            //最终合并的SQL语句
            string sqlString = main + detail + " SELECT @erpId";
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { sqlString }).Tables[0];

            //返回查询或插入的设备使用记录id值
            plan.Id = Convert.ToInt64(dt.Rows[0][0].ToString());

        }


        #endregion


        #region//业务实体操作方法：删除方法

        //删除“设备保修计划”，级联删除明细从表，根据设备保修计划id
        public void DeleteEquipmentRepairPlan(long equipmentRepairPlanId)
        {
            ArrayList sqlList = new ArrayList();
            string deleteEquipmentRepairPlanDetail = "DELETE FROM equipmentRepairPlanDetail WHERE erpId = " + equipmentRepairPlanId;
            string deleteEquipmentRepairPlane = "DELETE FROM equipmentRepairPlan WHERE id = " + equipmentRepairPlanId;

            //注意顺序：先删子表，再删主表
            sqlList.Add(deleteEquipmentRepairPlanDetail);
            sqlList.Add(deleteEquipmentRepairPlane);

            sqlHelper.ExecuteTransaction(sqlList);

        }

        #endregion
        


    }

    #endregion

    #region  //数据库操作类：备品配件采购计划


    /*
    * 类名称：SparePartStockPlanDB
    * 类功能描述：为“备品配件采购计划”提供数据库操作
    *
    * 创建人：关启学
    * 创建时间：2009-03-22
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

    class SparePartStockPlanDB
    {
        #region//参数初始化部门

        //用户“拌和站软件”的数据库操作
        private SqlHelper sqlHelper = new SqlHelper();


        //备品配件采购计划 SQL字符串
        private string sparePartStockPlanSelectStr =
            "   SELECT "
            + "   sparePartStockPlan.id                 AS [id],"                      //采购单号id
            + "   department.name                       AS [departmentName],"          //申请部门名称
            + "   sparePartStockPlan.proposer           AS [proposer],"                //申请人
            + "   sparePartStockPlan.applicationDate    AS [applicationDate],"         //申请日期
            + "   sparePartStockPlan.sum                AS [totalSum],"                //总金额
            + "   sparePartStockPlan.assessor           AS [assessor],"                //审核人
            + "   sparePartStockPlan.checkupMan         AS [checkupMan],"              //审批人

            + "   sparePartStockPlan.inputDate          AS [inputDate],"               //录入时间
            + "   sparePartStockPlan.inputMan           AS [inputMan],"                //录入人
            + "   sparePartStockPlan.dId                AS [departmentId]"             //部门表的id
            + " FROM sparePartStockPlan, department"
            + " WHERE sparePartStockPlan.dId = department.id";



        //备品配件计划明细 SQL字符串
        private string sparePartStockPlanDetailSelectStr =
            "   SELECT "
            + "   sparePartBasicInfo.no                         AS [sparePartNo],"          //备品配件编码
            + "   sparePartBasicInfo.name                       AS [sparePartName],"        //备品配件名称
            + "   sparePartBasicInfo.sort                       AS [sparePartSort],"        //备品配件种类
            + "   sparePartBasicInfo.model                      AS [sparePartModel],"       //备品配件规格
            + "   sparePartBasicInfo.unit                       AS [sparePartUnit],"        //备品配件单位
            + "   sparePartStockPlanDetail.currentQuantity      AS [currentQuantity],"      //当前库存数量
            + "   sparePartBasicInfo.maxStock                   AS [maxStock],"             //最大库存
            + "   sparePartBasicInfo.minStock                   AS [minStock],"             //最小库存
            + "   sparePartStockPlanDetail.requirementDate      AS [requirementDate],"      //需求时间
            + "   sparePartStockPlanDetail.producer             AS [producer],"             //生产厂家
            + "   sparePartStockPlanDetail.provider             AS [provider],"             //供应商
            + "   sparePartStockPlanDetail.contactMan           AS [contactMan],"           //联系人
            + "   sparePartStockPlanDetail.contactMethod        AS [contactMethod],"        //联系方式
            + "   sparePartStockPlanDetail.count                AS [count],"                //采购数量
            + "   sparePartStockPlanDetail.unitPrice            AS [unitPrice],"            //单价

            + "   sparePartStockPlanDetail.inputDate            AS [inputDate],"            //录入时间
            + "   sparePartStockPlanDetail.inputMan             AS [inputMan],"             //录入人
            + "   sparePartStockPlanDetail.id                   AS [id],"                   //id
            + "   sparePartStockPlanDetail.spbiId               AS [spbiId],"               //备品配件基本信息表id
            + "   sparePartStockPlanDetail.spspId               AS [spspId]"                //备品配件采购计划表id（父表）
            + " FROM sparePartStockPlanDetail, sparePartBasicInfo"
            + " WHERE sparePartStockPlanDetail.spbiId = sparePartBasicInfo.id"
            + " AND   sparePartStockPlanDetail.spspId = {0}";


        #endregion


        #region//用于填充“下拉列表”、与下拉列表相关控件数据的方法

        //查询“备品配件编码”：用于下拉列表
        public DataTable GetSparePartNo()
        {
            string selectString = "SELECT id, no FROM sparePartBasicInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“文档信息”：用于下拉列表
        public DataTable GetDocument()
        {
            string selectString = "SELECT id, no FROM document";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“部门信息”：用于下拉列表
        public DataTable GetDepartment()
        {
            string selectString = "SELECT id, name FROM department";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }


        //查询“人员信息”：设备信息明细datagridview内的下拉列表
        public DataTable GetPersonnelInfo()
        {
            string selectString = "SELECT id, name FROM personnelInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“备品配件信息”，根据“备品配件id”
        public string GetEquipmentName(long enId)
        {
            string selectString =
                " SELECT equipmentName.name FROM equipmentName, equipmentInformation "
                + "WHERE equipmentName.id = equipmentInformation.enId AND equipmentInformation.id = " + enId;

            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            string name = "";
            if (dt.Rows.Count > 0)
            {
                name = dt.Rows[0]["name"].ToString();
            }

            return name;
        }       

        //查询“文档名称”，根据“文档id”
        public string GetDocumentName(long id)
        {
            string selectString = "SELECT name FROM document WHERE id = " + id;

            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            string name = "";
            if (dt.Rows.Count > 0)
            {
                name = dt.Rows[0]["name"].ToString();
            }

            return name;
        }


        //根据“备品配件id”查询“备品配件”的“名称”“种类”“规格型号”“单位”“当期库存数量”
        public SparePart GetSparePart(long id)
        {
            string selectStr =
                "   SELECT "
            + "   sparePartBasicInfo.[name]	    AS [name],"             //备品配件 名称
            + "   sparePartBasicInfo.sort		AS [sort],"             //备品配件 种类
            + "   sparePartBasicInfo.model	    AS [model],"            //备品配件 规格型号
            + "   sparePartBasicInfo.unit	    AS [unit],"             //备品配件 单位
            + "   sparePartStock.quantity		AS [currentQuantity]"   //当前库存数量
            + " FROM sparePartBasicInfo, sparePartStock"
            + " WHERE sparePartBasicInfo.id = sparePartStock.spbiId"
            + " AND   sparePartBasicInfo.id = " + id;

            SparePart sparePart = new SparePart();
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { selectStr }).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sparePart.Name = dt.Rows[0]["name"].ToString();
                sparePart.Sort = dt.Rows[0]["sort"].ToString();
                sparePart.Model = dt.Rows[0]["model"].ToString();
                sparePart.Unit = dt.Rows[0]["unit"].ToString();
                sparePart.CurrentQuantity = Convert.ToInt64(dt.Rows[0]["CurrentQuantity"].ToString());
            }

            return sparePart;
        }


        #endregion


        #region//用于填充“DataGridView”数据内容的方法


        //查询“备品配件采购计划”
        public DataTable GetSparePartStockPlan()
        {
            return sqlHelper.QueryForDateSet(new ArrayList() { sparePartStockPlanSelectStr }).Tables[0];
        }

        //查询“备品配件采购计划”，按“制定时间”查询
        public DataTable GetSparePartStockPlan(DateTime dt)
        {
            string select = sparePartStockPlanSelectStr
                + " AND   sparePartStockPlan.applicationDate >= '{0}'"
                + " AND   sparePartStockPlan.applicationDate < '{1}'";

            string selectString = string.Format(select, dt, dt.AddDays(1));
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“备品配件采购计划明细”，按“备品配件采购计划id”查询
        public DataTable GetSparePartStockPlanDetail(long spspId)
        {
            string selectString = string.Format(sparePartStockPlanDetailSelectStr, spspId);
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        #endregion


        #region//业务实体操作方法：插入方法

        //级联插入新的“备品配件采购计划”
        public void InsertSparePartStockPlan(SparePartStockPlan plan, DataTable dtPlanDetail)
        {
            //主表insert操作：向“备品配件采购计划表”增加信息
            string insertOverall =
                "   INSERT INTO sparePartStockPlan"
                + " (proposer, applicationDate, dId, inputDate, inputMan)"
                + " VALUES"
                + " ('{0}','{1}',{2},getdate(),'{3}')"
                + " ;DECLARE  @spspId bigint"
                + " ;SET @spspId = @@IDENTITY";
            string main = string.Format(insertOverall, plan.Proposer, plan.ApplicationDate, plan.DId, plan.InputMan);


            //从表insert操作：向“备品配件采购计划明细表”增加信息
            string insertDetail =
                "   INSERT INTO sparePartStockPlanDetail"
                + " ( spspId, spbiId, currentQuantity, requirementDate, producer, provider, contactMan, contactMethod, count, unitPrice, inputDate, inputMan)"
                + " VALUES"
                + " ( @spspId, {0}, {1}, '{2}', '{3}', '{4}', '{5}', '{6}', {7}, {8}, getdate(), '{9}')";


            string detail = "";
            decimal sum = 0;

            foreach (DataRow row in dtPlanDetail.Rows)
            {
                detail += string.Format(insertDetail,
                    row["spbiId"], row["currentQuantity"], row["requirementDate"], row["producer"], row["provider"], row["contactMan"]
                    , row["contactMethod"], row["count"], row["unitPrice"], row["inputMan"]);


                sum += (Convert.ToInt64(row["count"].ToString())) * (Convert.ToInt64(row["unitPrice"].ToString()));

            }


            //主表update操作：将子表“备品配件采购计划明细”中的“金额”合计后更新回相应主表的“备品配件采购计划”
            string updateOverall = " UPDATE sparePartStockPlan SET sum = " + sum + " WHERE id = @spspId";


            //最终合并的SQL语句
            string sqlString = main + detail + updateOverall + " SELECT @spspId";
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { sqlString }).Tables[0];

            //返回查询或插入的备品配件采购计划id值
            plan.Id = Convert.ToInt64(dt.Rows[0][0].ToString());

        }

        #endregion

        #region//业务实体操作方法：删除方法

        //删除“备品配件采购计划”，级联删除明细从表，根据备品配件采购计划id
        public void DeleteSparePartStockPlan(long id)
        {
            ArrayList sqlList = new ArrayList();
            string deleteSparePartStockPlanDetail = "DELETE FROM sparePartStockPlanDetail WHERE spspId = " + id;
            string deleteSparePartStockPlan = "DELETE FROM sparePartStockPlan WHERE id = " + id;

            //注意顺序：先删子表，再删主表
            sqlList.Add(deleteSparePartStockPlanDetail);
            sqlList.Add(deleteSparePartStockPlan);

            sqlHelper.ExecuteTransaction(sqlList);

        }

        #endregion

    }

    #endregion

    #region  //数据库操作类：备品配件入库单、退货单

    /*
    * 类名称：SparePartInStockDB
    * 类功能描述：为“备品配件入库单、退货单”提供数据库操作
    *
    * 创建人：关启学
    * 创建时间：2009-03-25
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

    class SparePartInStockDB
    {
        #region//参数初始化部门

        //用户“拌和站软件”的数据库操作
        private SqlHelper sqlHelper = new SqlHelper();


        //备品配入库单 SQL字符串
        private string sparePartInStockSelectStr =
            "   SELECT "
            + "   sparePartAdd.id                 AS [id],"                 //入库单号id
            + "   providerInfo.name               AS [providerName],"       //供应商名称
            + "   sparePartAdd.invoiceNo          AS [invoiceNo],"          //发票号
            + "   sparePartAdd.stockMan           AS [stockMan],"           //采购人
            + "   sparePartAdd.stockDate          AS [stockDate],"          //入库时间
            + "   ABS(sparePartAdd.sum)           AS [sum],"                //金额
            + "   sparePartAdd.remark             AS [remark],"             //备注
            + "   sparePartAdd.assessor           AS [assessor],"           //审核人
            + "   sparePartAdd.checkupMan         AS [checkupMan],"         //审批人
            + "   sparePartAdd.auditingDate       AS [auditingDate],"       //审核时间
            + "   sparePartAdd.checkupDate        AS [checkupDate],"        //审批时间

            + "   sparePartAdd.inputDate          AS [inputDate],"          //录入时间
            + "   sparePartAdd.inputMan           AS [inputMan],"           //录入人
            + "   sparePartAdd.piId               AS [providerId],"         //供应商表id
            + "   sparePartAdd.parentId           AS [parentId]"            //自关联id：表示与退货相关联的入库单id
            + " FROM sparePartAdd, providerInfo"
            + " WHERE sparePartAdd.piId = providerInfo.id";



        //备品配入库单明细 SQL字符串
        private string sparePartInStockDetailSelectStr =
            "   SELECT "
            + "   sparePartBasicInfo.no                   AS [sparePartNo],"          //物料编码
            + "   sparePartBasicInfo.name                 AS [sparePartName],"        //物料名称
            + "   sparePartBasicInfo.sort                 AS [sparePartSort],"        //物料种类
            + "   sparePartBasicInfo.model                AS [sparePartModel],"       //物料规格信号

            + "   sparePartAddDetail.producer             AS [producer],"             //生产厂家            
            + "   sparePartAddDetail.contactMan           AS [contactMan],"           //联系人
            + "   sparePartAddDetail.contactMethod        AS [contactMethod],"        //联系方式

            + "   ABS(sparePartAddDetail.count)           AS [inStockCount],"         //采购数量（用于退货时，显示）
            + "   sparePartAddDetail.unitPrice            AS [inStockUnitPrice],"     //采购单价（用于退货时，显示）
            + "   ABS(sparePartAddDetail.totalPrice)      AS [inStockTotalPrice],"    //采购金额（用于退货时，显示）
            + "   ABS(sparePartAddDetail.count)           AS [count],"                //采购数量/退货数量
            + "   sparePartAddDetail.unitPrice            AS [unitPrice],"            //采购单价/退货单价
            + "   ABS(sparePartAddDetail.totalPrice)      AS [totalPrice],"           //采购金额/退货金额

            + "   sparePartAddDetail.storage              AS [storage],"              //仓库名称
            + "   sparePartAddDetail.position             AS [position],"             //库位号

            + "   sparePartAddDetail.inputDate            AS [inputDate],"            //录入时间
            + "   sparePartAddDetail.inputMan             AS [inputMan],"             //录入人
            + "   sparePartAddDetail.id                   AS [id],"                   //id
            + "   sparePartAddDetail.spbiId               AS [spbiId],"               //备品配件基本信息表id
            + "   sparePartAddDetail.spaId                AS [spaId]"                 //备品配件入库单表id（父表）
            + " FROM sparePartAddDetail, sparePartBasicInfo"
            + " WHERE sparePartAddDetail.spbiId = sparePartBasicInfo.id"
            + " AND   sparePartAddDetail.spaId = {0}";


        #endregion


        #region//用于填充“下拉列表”、与下拉列表相关控件数据的方法

        //查询“供应商名称”：用于下拉列表
        public DataTable GetProviderName()
        {
            string selectString = "SELECT distinct name FROM providerInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“备品配件编码”：用于下拉列表
        public DataTable GetSparePartNo()
        {
            string selectString = "SELECT distinct no FROM sparePartBasicInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“备品配件名称”：用于下拉列表
        public DataTable GetSparePartName()
        {
            string selectString = "SELECT distinct name FROM sparePartBasicInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“备品配件种类”：用于下拉列表
        public DataTable GetSparePartSort()
        {
            string selectString = "SELECT distinct sort FROM sparePartBasicInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“备品配件规格”：用于下拉列表
        public DataTable GetSparePartModel()
        {
            string selectString = "SELECT distinct model FROM sparePartBasicInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“人员名称”：用于下拉列表
        public DataTable GetPersonnelName()
        {
            string selectString = "SELECT distinct name FROM personnelInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }


        //查询“备品配件编码和id”：用于子窗体的下拉列表
        public DataTable GetSparePartInfo()
        {
            string selectString = "SELECT id, no FROM sparePartBasicInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“供应商名称和id”：用于子窗体的下拉列表
        public DataTable GetProviderInfo()
        {
            string selectString = "SELECT id, name FROM providerInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“人员名称和id”：用于子窗体的下拉列表
        public DataTable GetPersonnelInfo()
        {
            string selectString = "SELECT id, name FROM personnelInfo";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }



        //用于初始化，窗体中根据下拉列表联动的内容
        //查询对象：根据“备品配件id”查询“备品配件”的“名称”“种类”“规格型号”“单位”“当期库存数量”
        public SparePart GetSparePart(long id)
        {
            string selectStr =
                "   SELECT "
            + "   sparePartBasicInfo.[name]	    AS [name],"             //备品配件 名称
            + "   sparePartBasicInfo.sort		AS [sort],"             //备品配件 种类
            + "   sparePartBasicInfo.model	    AS [model],"            //备品配件 规格型号
            + "   sparePartBasicInfo.unit	    AS [unit],"             //备品配件 单位
            + "   sparePartStock.quantity		AS [currentQuantity]"   //当前库存数量
            + " FROM sparePartBasicInfo, sparePartStock"
            + " WHERE sparePartBasicInfo.id = sparePartStock.spbiId"
            + " AND   sparePartBasicInfo.id = " + id;

            SparePart sparePart = new SparePart();
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { selectStr }).Tables[0];
            if (dt.Rows.Count > 0)
            {
                sparePart.Name = dt.Rows[0]["name"].ToString();
                sparePart.Sort = dt.Rows[0]["sort"].ToString();
                sparePart.Model = dt.Rows[0]["model"].ToString();
                sparePart.Unit = dt.Rows[0]["unit"].ToString();
                sparePart.CurrentQuantity = Convert.ToInt64(dt.Rows[0]["CurrentQuantity"].ToString());
            }

            return sparePart;
        }

        #endregion


        #region//用于填充“DataGridView”数据内容的方法

        //查询“入库单”附加条件
        private string inStockCondition = " AND sparePartAdd.parentId is null";
        //查询“退货单”附加条件
        private string inStockRefundCondition = " AND sparePartAdd.parentId is not null";


        #region//主表查询方法

        //查询“备品配件入库单”
        public DataTable GetSparePartInStock()
        {
            string select = sparePartInStockSelectStr + inStockCondition;
            return sqlHelper.QueryForDateSet(new ArrayList() { select }).Tables[0];
        }

        //查询“备品配件退货单”
        public DataTable GetSparePartInStockRefund()
        {
            string select = sparePartInStockSelectStr + inStockRefundCondition;
            return sqlHelper.QueryForDateSet(new ArrayList() { select }).Tables[0];
        }

        //查询“备品配件入库单”，按“备品配件入库单id”查询
        public DataTable GetSparePartInStock(long id)
        {
            string select = sparePartInStockSelectStr + inStockCondition
                + " AND   sparePartAdd.id = {0}";

            string selectString = string.Format(select, id);
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //查询“备品配件退货单”，按“备品配件退货单id”查询
        public DataTable GetSparePartInStockRefund(long id)
        {
            string select = sparePartInStockSelectStr + inStockRefundCondition
                + " AND   sparePartAdd.id = {0}";

            string selectString = string.Format(select, id);
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }


        ////查询“备品配件入库单”，按“查询对象”的内容
        public DataTable GetSparePartInStock(SparePartInStockSeacher seacher)
        {
            string select = sparePartInStockSelectStr + inStockCondition
                + " AND   sparePartAdd.id in ({0})";

            string conditon =
                "    SELECT distinct inStockId "
                + "  FROM"
                + "     (SELECT"
                + "         sparePartAdd.id				    as [inStockId],"        // 入库单id
                + "         sparePartAdd.stockMan			as [stockMan],"         // 采购人
                + "         sparePartAdd.stockDate			as [stockDate],"        // 采购日期
                + "         providerInfo.name			    as [providerName],"     // 供应商名称
                + "         sparePartBasicInfo.no			as [sparePartNo],"      // 物料编码
                + "         sparePartBasicInfo.name			as [sparePartName],"    // 物料名称
                + "         sparePartBasicInfo.sort			as [sparePartSort],"    // 物料种类
                + "         sparePartBasicInfo.model		as [sparePartModel]"    // 物料规格型号
                + "      FROM sparePartAddDetail,sparePartBasicInfo,sparePartAdd"
                + "      WHERE sparePartAddDetail.spbiId = sparePartBasicInfo.id"
                + "      AND sparePartAddDetail.spaId = sparePartAdd.id"
                + "      AND sparePartAdd.piId = providerInfo.id"
                + "     ) AS seachCondition"    // 将所有入库单明细记录与欲查询条件结合成一个“条件查询表”
                + "  WHERE stockMan       LIKE '%{0}%'"
                + "  AND   providerName   LIKE '%{1}%'"
                + "  AND   sparePartNo    LIKE '%{2}%'"
                + "  AND   sparePartName  LIKE '%{3}%'"
                + "  AND   sparePartSort  LIKE '%{4}%'"
                + "  AND   sparePartModel LIKE '%{5}%'"
                + "  AND   stockDate      >=    '{6}'"
                + "  AND   stockDate      <=    '{7}'";
            conditon = string.Format(conditon, seacher.StockMan, seacher.ProviderName, seacher.SparePartNo
                , seacher.SparePartName, seacher.SparePartSort, seacher.SparePartModel, seacher.StockDateBegin, seacher.StockDateEnd);

            string selectString = string.Format(select, conditon);
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        ////查询“备品配件退货单”，按“查询对象”的内容
        public DataTable GetSparePartInStockRefund(SparePartInStockSeacher seacher)
        {
            string select = sparePartInStockSelectStr + inStockRefundCondition
                + " AND   sparePartAdd.id in ({0})";

            string conditon =
                "    SELECT distinct inStockId "
                + "  FROM"
                + "     (SELECT"
                + "         sparePartAdd.id				    as [inStockId],"        // 入库单id
                + "         sparePartAdd.stockMan			as [stockMan],"         // 采购人
                + "         sparePartAdd.stockDate			as [stockDate],"        // 采购日期
                + "         providerInfo.name			    as [providerName],"     // 供应商名称
                + "         sparePartBasicInfo.no			as [sparePartNo],"      // 物料编码
                + "         sparePartBasicInfo.name			as [sparePartName],"    // 物料名称
                + "         sparePartBasicInfo.sort			as [sparePartSort],"    // 物料种类
                + "         sparePartBasicInfo.model		as [sparePartModel]"    // 物料规格型号
                + "      FROM sparePartAddDetail,sparePartBasicInfo,sparePartAdd"
                + "      WHERE sparePartAddDetail.spbiId = sparePartBasicInfo.id"
                + "      AND sparePartAddDetail.spaId = sparePartAdd.id"
                + "      AND sparePartAdd.piId = providerInfo.id"
                + "     ) AS seachCondition"    // 将所有入库单明细记录与欲查询条件结合成一个“条件查询表”
                + "  WHERE stockMan       LIKE '%{0}%'"
                + "  AND   providerName   LIKE '%{1}%'"
                + "  AND   sparePartNo    LIKE '%{2}%'"
                + "  AND   sparePartName  LIKE '%{3}%'"
                + "  AND   sparePartSort  LIKE '%{4}%'"
                + "  AND   sparePartModel LIKE '%{5}%'"
                + "  AND   stockDate      >=    '{6}'"
                + "  AND   stockDate      <=    '{7}'";
            conditon = string.Format(conditon, seacher.StockMan, seacher.ProviderName, seacher.SparePartNo
                , seacher.SparePartName, seacher.SparePartSort, seacher.SparePartModel, seacher.StockDateBegin, seacher.StockDateEnd);

            string selectString = string.Format(select, conditon);
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        #endregion


        #region//从表查询方法
        //查询“备品配件入库单明细/退货明细”，按“备品配件入库单id/退货单id”查询
        public DataTable GetSparePartInStockDetail(long spaId)
        {
            string selectString = string.Format(sparePartInStockDetailSelectStr, spaId);
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        #endregion

        #endregion


        #region//业务实体操作方法：插入方法

        //级联插入新的“备品配件入库单”
        public void InsertSparePartInStock(SparePartInStock inStock, DataTable dtDetail)
        {
            //主表insert操作：向“备品配件入库单表”增加信息
            string insertOverall =
                "   ;DECLARE @quantity bigint"  //备品配件库存 数量
                + " ;DECLARE @totalPrice money" //备品配件库存 金额
                + " ;DECLARE @id bigint"        //备品配件库存id
                + " ;DECLARE @spaId bigint"     //入库单号id

                + " INSERT INTO sparePartAdd"
                + " (invoiceNo, stockMan, stockDate, remark, piId, inputDate, inputMan)"
                + " VALUES"
                + " ('{0}','{1}','{2}','{3}',{4},getdate(),'{5}')"
                + " ;SET @spaId = @@IDENTITY";
            string main = string.Format(insertOverall, inStock.InvoiceNo, inStock.StockMan, inStock.StockDate
                , inStock.Remark, inStock.PiId, inStock.InputMan);


            //从表insert操作：向“备品配件入库单明细表”增加信息
            string insertDetail =
                "   INSERT INTO sparePartAddDetail"
                + " ( spaId, spbiId, producer, contactMan, contactMethod, count, unitPrice, totalPrice, storage, position, inputDate, inputMan)"
                + " VALUES"
                + " ( @spaId, {0}, '{1}', '{2}', '{3}', {4}, {5}, {6}, '{7}', '{8}', getdate(), '{9}')";

            //“备品配件库存表SparePartStock”操作：根据该备品配件是否在库存中存在记录而执行相应的insert/update语句
            string inStockString =
                "   ;SET @id = ("
                + "     SELECT id"
                + "     FROM sparePartStock"
                + "     WHERE spbiId = {0}"
                + "     )"
                + " IF @id is null"
                + "     BEGIN"
                + "         INSERT sparePartStock (spbiId, quantity, totalPrice, inputDate, inputMan) "
                + "         VALUES ({0},{1},{2},getdate(),'{3}')"
                + "     END"
                + " ELSE"
                + "     BEGIN"
                + "         SELECT"
                + "             @quantity = quantity,"
                + "             @totalPrice = totalPrice"
                + "         FROM sparePartStock"
                + "         WHERE id = @id"

                + "         UPDATE sparePartStock"
                + "         SET quantity = @quantity + {1},"
                + "             totalPrice = @totalPrice + {2}"
                + "         WHERE id = @id"
                + "     END";


            string detail = "";
            string stock = "";
            decimal sum = 0;
            decimal totalPrice = 0;
            long count = 0;

            foreach (DataRow row in dtDetail.Rows)
            {
                totalPrice = 0;
                decimal.TryParse(row["totalPrice"].ToString(), out totalPrice);

                count = 0;
                long.TryParse(row["count"].ToString(), out count);

                detail += string.Format(insertDetail,
                    row["spbiId"], row["producer"], row["contactMan"], row["contactMethod"], count, row["unitPrice"], totalPrice
                    , row["storage"], row["position"], row["inputMan"]);

                //正数：表示入库

                sum += totalPrice;

                //库存操作语句
                stock += string.Format(inStockString, row["spbiId"], count, totalPrice, row["inputMan"]);

            }


            //主表update操作：将子表“备品配件入库单明细”中的“金额”合计后更新回相应主表的“备品配件入库单表”
            string updateOverall = " UPDATE sparePartAdd SET sum = " + sum + " WHERE id = @spaId";


            //最终合并的SQL语句
            string sqlString = main + detail + updateOverall + stock + " SELECT @spaId";
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { sqlString }).Tables[0];

            //返回查询或插入的备品配件入库单id值
            inStock.Id = Convert.ToInt64(dt.Rows[0][0].ToString());

        }


        //级联插入新的“备品配件退货单”
        public void InsertSparePartInStockRefund(SparePartInStock inStock, DataTable dtDetail)
        {
            //主表insert操作：向“备品配件退货单表”增加信息
            string insertOverall =
                "   ;DECLARE @quantity bigint"
                + " ;DECLARE @totalPrice money"
                + " ;DECLARE @id bigint"
                + " ;DECLARE @spaId bigint"

                + " INSERT INTO sparePartAdd"
                + " (invoiceNo, stockMan, stockDate, remark, piId, inputDate, inputMan, parentId)"
                + " VALUES"
                + " ('{0}','{1}','{2}','{3}',{4},getdate(),'{5}',{6})"
                + " ;SET @spaId = @@IDENTITY";
            string main = string.Format(insertOverall, inStock.InvoiceNo, inStock.StockMan, inStock.StockDate
                , inStock.Remark, inStock.PiId, inStock.InputMan, inStock.ParentId);


            //从表insert操作：向“备品配件退货单明细表”增加信息
            string insertDetail =
                "   INSERT INTO sparePartAddDetail"
                + " ( spaId, spbiId, producer, contactMan, contactMethod, count, unitPrice, totalPrice, storage, position, inputDate, inputMan)"
                + " VALUES"
                + " ( @spaId, {0}, '{1}', '{2}', '{3}', -{4}, {5}, -{6}, '{7}', '{8}', getdate(), '{9}')";

            //“备品配件库存表SparePartStock”操作：根据该备品配件是否在库存中存在记录而执行相应的insert/update语句
            string inStockString =
                "   ;SET @id = ("
                + "     SELECT id"
                + "     FROM sparePartStock"
                + "     WHERE spbiId = {0}"
                + "     )"
                + " IF @id is null"
                + "     BEGIN"
                + "         INSERT sparePartStock (spbiId, quantity, totalPrice, inputDate, inputMan) "
                + "         VALUES ({0},-{1},-{2},getdate(),'{3}')"
                + "     END"
                + " ELSE"
                + "     BEGIN"
                + "         SELECT"
                + "             @quantity = quantity,"
                + "             @totalPrice = totalPrice"
                + "         FROM sparePartStock"
                + "         WHERE id = @id"

                + "         UPDATE sparePartStock"
                + "         SET quantity = @quantity + (-{1}),"
                + "             totalPrice = @totalPrice + (-{2})"
                + "         WHERE id = @id"
                + "     END";


            string detail = "";
            string stock = "";
            decimal sum = 0;
            decimal totalPrice = 0;
            long count = 0;

            foreach (DataRow row in dtDetail.Rows)
            {
                totalPrice = 0;
                decimal.TryParse(row["totalPrice"].ToString(), out totalPrice);

                count = 0;
                long.TryParse(row["count"].ToString(),out count);

                detail += string.Format(insertDetail,
                    row["spbiId"], row["producer"], row["contactMan"], row["contactMethod"], count, row["unitPrice"], totalPrice
                    , row["storage"], row["position"], row["inputMan"]);

                //负数：表示“退货”
                
                sum += -(totalPrice);

                //库存操作语句
                stock += string.Format(inStockString, row["spbiId"], count, totalPrice, row["inputMan"]);

            }


            //主表update操作：将子表“备品配件退货单明细”中的“金额”合计后更新回相应主表的“备品配件退货单表”
            string updateOverall = " UPDATE sparePartAdd SET sum = " + sum + " WHERE id = @spaId";


            //最终合并的SQL语句
            string sqlString = main + detail + updateOverall + stock + " SELECT @spaId";
            DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { sqlString }).Tables[0];

            //返回查询或插入的退货单id值
            inStock.Id = Convert.ToInt64(dt.Rows[0][0].ToString());

        }


        //设置审核人，只记录审核人、审核时间两个信息，不完成其他额外操作
        public void SetAssessor(long id, string userName)
        {
            string sqlString =
                "   ;DECLARE @assessor varchar(50)"
                + " ;SET @assessor = ("
                + "     SELECT assessor"
                + "     FROM sparePartAdd"
                + "     WHERE id = {0}"
                + "     )"
                + " IF @assessor is null"
                + "     BEGIN"
                + "         UPDATE sparePartAdd SET assessor = '{1}', auditingDate = getdate()  WHERE id = {0}"
                + "     END";

            sqlString = string.Format(sqlString, id, userName);
            sqlHelper.ExecuteTransaction(new ArrayList() { sqlString });
        }

        //设置审核人，只影响“审批人”“审批时间”“审核人”三个字段，不完成其他业务操作
        public void SetCheckupMan(long id, string userName)
        {
            string sqlString = "";

            //审批不通过
            if (userName.Equals("null"))
            {
                sqlString =
                    "   ;DECLARE @checkupMan varchar(50)"
                    + " ;SET @checkupMan = ("
                    + "     SELECT checkupMan"
                    + "     FROM sparePartAdd"
                    + "     WHERE id = {0}"
                    + "     )"
                    + " IF @checkupMan is null"
                    + "     BEGIN"
                    + "         UPDATE sparePartAdd SET checkupMan = NULL, checkupDate = getdate(), assessor = NULL  WHERE id = {0}"
                    + "     END"; 
              
                sqlString = string.Format(sqlString, id);
            }
            //审批通过
            else
            {
                sqlString =
                    "   ;DECLARE @checkupMan varchar(50)"
                    + " ;DECLARE @assessor varchar(50)"
                    + "     SELECT @checkupMan = checkupMan, @assessor = assessor"
                    + "     FROM sparePartAdd"
                    + "     WHERE id = {0}"
                    + " IF (@checkupMan IS NULL) AND (@assessor IS NOT NULL)"
                    + "     BEGIN"
                    + "         UPDATE sparePartAdd SET checkupMan = '{1}', checkupDate = getdate()  WHERE id = {0}"
                    + "     END";
                sqlString = string.Format(sqlString, id, userName);
            }
            
            sqlHelper.ExecuteTransaction(new ArrayList() { sqlString });
        }

        #endregion
        

    }

    #endregion



}
