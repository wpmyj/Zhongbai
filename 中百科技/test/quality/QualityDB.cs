using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DasherStation.common;
using System.Windows.Forms;
using System.Collections;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;


namespace DasherStation.quality
{
    
    #region //质量管理数据层
    class QualityDB
    {
        DataSet ds = new DataSet();

        Database db = null;

        SqlHelper sqlHelperObj = new SqlHelper();

        ArrayList arrayList = new ArrayList();

        bool status;

        #region //试验仪器台帐

        /*
        * 方法名称：InitialCbxId
        * 方法功能描述：查询数据库并返回数据集
        *
        * 创建人：夏阳明
        * 创建时间：20090224
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet InitialCbxId()
        {
            #region
            string locSearchStr;

            locSearchStr = "select distinct no from experimentationEquipmentModel";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：InitialCbxUnitPrice
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090226
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet InitialCbxUnitPrice()
        {
            string locSearchStr;
            #region
         //   locSearchStr = "select distinct unitPrice,id from experimentationEquipmentModel";
            locSearchStr = "select distinct unitPrice from experimentationEquipmentModel";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
      * 方法名称：InitialCbxName
      * 方法功能描述：查询数据库并返回数据集
      *
      * 创建人：夏阳明
      * 创建时间：20090226
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataSet InitialCbxName()
        {
            string locSearchStr;
            #region
         //   locSearchStr = "select id,name from experimentationEquipmentName";
            locSearchStr = "select distinct name from experimentationEquipmentName";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
      * 方法名称：InitialCbxModel
      * 方法功能描述：查询数据库并返回数据集
      *
      * 创建人：夏阳明
      * 创建时间：20090226
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataSet InitialCbxModel()
        {
            string locSearchStr;
            #region
         //   locSearchStr = "select id,model from experimentationEquipmentModel";
            locSearchStr = "select distinct model from experimentationEquipmentModel";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
     * 方法名称：InitialCbxCheckUnit
     * 方法功能描述：查询数据库并返回数据集
     *
     * 创建人：夏阳明
     * 创建时间：20090226
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataSet InitialCbxCheckUnit()
        {
            string locSearchStr;
            #region
          //  locSearchStr = "select  distinct checkUnit,id from experimentationEquipmentInformation";
            locSearchStr = "select  distinct checkUnit from experimentationEquipmentInformation";
            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
     * 方法名称：InitialCbxMaker
     * 方法功能描述：查询数据库并返回数据集
     *
     * 创建人：夏阳明
     * 创建时间：20090226
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataSet InitialCbxMaker()
        {
            string locSearchStr;
            #region
          //  locSearchStr = "select distinct maker,id from experimentationEquipmentName";
            locSearchStr = "select distinct maker from experimentationEquipmentName";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：FrmExaminationEquipmentDetailSearch
       * 方法功能描述：根据用户查询信息返回用户查询所得数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090225
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet FrmExaminationEquipmentDetailSearch(string searchStr, int verifyBit, DataGridView dgv)
        {
            string locsearchStr;
            #region
            //如果仪器名称输入为空，查询全部
            if (verifyBit == 1)
            {
                locsearchStr = "select eCorr.id,eModel.no,eName.name,eModel.model,eName.maker,eModel.unitPrice,";
                locsearchStr = locsearchStr + "eModel.checkPeriod,eModel.depreciationYear,eModel.depreciationRate,";
                locsearchStr = locsearchStr + "eCorr.netWorth,eCorr.addUpSum,eCorr.buyDate,eCorr.checkUnit,";
                locsearchStr = locsearchStr + "eCorr.latestCheckDate,eCorr.state,eCorr.remark from ";
                locsearchStr = locsearchStr + "experimentationEquipmentName as eName,experimentationEquipmentModel ";
                locsearchStr = locsearchStr + "as eModel,experimentationEquipmentInformation as eCorr ";
                locsearchStr = locsearchStr + "where eName.id = eCorr.eenId and eModel.id = eCorr.eemId order by eCorr.inputDate DESC";

                ds = sqlHelperObj.QueryForDateSet(new ArrayList { locsearchStr });

            }
            //按用户输入的仪器名称进行模糊查询
            else if (verifyBit == 0)
            {
                locsearchStr = "select eCorr.id,eModel.no,eName.name,eModel.model,eName.maker,eModel.unitPrice,";
                locsearchStr = locsearchStr + "eModel.checkPeriod,eModel.depreciationYear,eModel.depreciationRate,";
                locsearchStr = locsearchStr + "eCorr.netWorth,eCorr.addUpSum,eCorr.buyDate,eCorr.checkUnit,";
                locsearchStr = locsearchStr + "eCorr.latestCheckDate,eCorr.state,eCorr.remark from ";
                locsearchStr = locsearchStr + "experimentationEquipmentName as eName,experimentationEquipmentModel ";
                locsearchStr = locsearchStr + "as eModel,experimentationEquipmentInformation as eCorr ";
                locsearchStr = locsearchStr + "where eName.id = eCorr.eenId and eModel.id = eCorr.eemId ";
                locsearchStr = locsearchStr + "and eName.name like '%" + searchStr + "%' order by eCorr.inputDate DESC";

                ds = sqlHelperObj.QueryForDateSet(new ArrayList { locsearchStr });

            }
            #endregion
            return ds;
        }

        /*
       * 方法名称：FrmExaminationEquipmentDetailCheckId
       * 方法功能描述：查询所有符合条件的仪器编号
       *
       * 创建人：夏阳明
       * 创建时间：20090226
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmExaminationEquipmentDetailCheckId(string id)
        {
            string locsearchStr;
            #region
            locsearchStr = "select * from experimentationEquipmentModel where no = '" + id + "'";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locsearchStr });

            if (ds.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            #endregion
            return false;
        }

        /*
      * 方法名称：FrmExaminationEquipmentDetailCheckUnitPrice
      * 方法功能描述：查询所有符合条件的仪器单价
      *
      * 创建人：夏阳明
      * 创建时间：20090226
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmExaminationEquipmentDetailCheckUnitPrice(double unitPrice)
        {
            string locsearchStr;
            #region
            locsearchStr = "select * from experimentationEquipmentModel where unitPrice = " + unitPrice;

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locsearchStr });

            if (ds.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            #endregion
            return false;
        }

        /*
      * 方法名称：FrmExaminationEquipmentDetailCheckName
      * 方法功能描述：查询所有符合条件的仪器名称
      *
      * 创建人：夏阳明
      * 创建时间：20090226
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmExaminationEquipmentDetailCheckName(string name)
        {
            string locsearchStr;
            #region
            locsearchStr = "select * from experimentationEquipmentName where name = '" + name + "'";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locsearchStr });

            if (ds.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            #endregion
            return false;
        }

        /*
     * 方法名称：FrmExaminationEquipmentDetailCheckModel
     * 方法功能描述：查询所有符合条件的规格型号
     *
     * 创建人：夏阳明
     * 创建时间：20090226
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool FrmExaminationEquipmentDetailCheckModel(string model)
        {
            string locsearchStr;
            #region
            locsearchStr = "select * from experimentationEquipmentModel where model = '" + model + "'";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locsearchStr });

            if (ds.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            #endregion
            return false;
        }

        /*
     * 方法名称：FrmExaminationEquipmentDetailCheckMaker
     * 方法功能描述：查询所有符合条件的生产厂家
     *
     * 创建人：夏阳明
     * 创建时间：20090228
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool FrmExaminationEquipmentDetailCheckMaker(string maker)
        {
            string locsearchStr;
            #region
            locsearchStr = "select * from experimentationEquipmentName where maker = '" + maker + "'";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locsearchStr });

            if (ds.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            #endregion
            return false;
        }


        /*
        * 方法名称：FrmExaminationEquipmentDetailSave
        * 方法功能描述：插入数据库操作并返回bool值（true为成功，false为失败）
        *
        * 创建人：夏阳明
        * 创建时间：20090226
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmExaminationEquipmentDetailSave(ExaminationEquipmentClass examinationEquipmentClass, string userName, int idName, int idModel)
        {
            string locInsertStr;

            bool status;
            #region

            locInsertStr = "insert into experimentationEquipmentInformation (eenId,eemId,netWorth,addUpSum,buyDate,";
            locInsertStr = locInsertStr + "checkUnit,latestCheckDate,state,inputMan,inputDate,remark) values(" + idName;
            locInsertStr = locInsertStr + "," + idModel + "," + examinationEquipmentClass.NetWorth + "," + examinationEquipmentClass.AddUpSum;
            locInsertStr = locInsertStr + ",'" + examinationEquipmentClass.BuyDate + "','" + examinationEquipmentClass.CheckUnit;
            locInsertStr = locInsertStr + "','" + examinationEquipmentClass.LatestCheckDate + "','" + examinationEquipmentClass.State;
            locInsertStr = locInsertStr + "','" + userName + "','" + DateTime.Now.ToString() + "','" + examinationEquipmentClass.Remark + "')";

            status = sqlHelperObj.Insert(new ArrayList { locInsertStr });

            #endregion
            return status;

        }
        /*
       * 方法名称：FrmExaminationEquipmentDetailLogicSearchName
       * 方法功能描述：查询给定名称的仪器的id值
       *
       * 创建人：夏阳明
       * 创建时间：20090226
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */

        public int FrmExaminationEquipmentDetailLogicSearchName(ExaminationEquipmentClass examinationEquipmentClass)
        {
            int idName;

            string locSelectStr;
            #region

            locSelectStr = "select id from experimentationEquipmentName where name = '" + examinationEquipmentClass.Name + "'";
            locSelectStr = locSelectStr + " and maker = '" + examinationEquipmentClass.Maker + "'";

            idName = Convert.ToInt32(sqlHelperObj.QueryForDateSet(new ArrayList { locSelectStr }).Tables[0].Rows[0][0]);
            #endregion
            return idName;
        }


        /*
      * 方法名称：FrmExaminationEquipmentDetailLogicSearchModel
      * 方法功能描述：查询给定规格的仪器的id值
      *
      * 创建人：夏阳明
      * 创建时间：20090226
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int FrmExaminationEquipmentDetailLogicSearchModel(ExaminationEquipmentClass examinationEquipmentClass)
        {
            int idModel;

            string locSelectStr;
            #region

            locSelectStr = "select id from experimentationEquipmentModel where model = '" + examinationEquipmentClass.Model + "'";
            locSelectStr = locSelectStr + " and no = '" + examinationEquipmentClass.No + "'";

            idModel = Convert.ToInt32(sqlHelperObj.QueryForDateSet(new ArrayList { locSelectStr }).Tables[0].Rows[0][0]);
            #endregion
            return idModel;
        }

        /*
        * 方法名称：FrmExaminationEquipmentDetailSearchAll
        * 方法功能描述：查询所有仪器台帐信息
        *
        * 创建人：夏阳明
        * 创建时间：20090226
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet FrmExaminationEquipmentDetailSearchAll()
        {
            string locSearchStr;
            #region
            locSearchStr = "select eCorr.id,eModel.no,eName.name,eModel.model,eName.maker,eModel.unitPrice,eModel.checkPeriod,eModel.depreciationYear,";
            locSearchStr = locSearchStr + "eModel.depreciationRate,eCorr.netWorth,eCorr.addUpSum,eCorr.buyDate,eCorr.checkUnit,";
            locSearchStr = locSearchStr + "eCorr.latestCheckDate,eCorr.state,eCorr.remark ";
            locSearchStr = locSearchStr + "from experimentationEquipmentName as eName,experimentationEquipmentModel as eModel,";
            locSearchStr = locSearchStr + "experimentationEquipmentInformation as eCorr where eName.id = eCorr.eenId and ";
            locSearchStr = locSearchStr + "eModel.id = eemId";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：FrmExaminationEquipmentDetailLogicUpdate
       * 方法功能描述：更新数据库操作并返回bool值（true为成功，false为失败）
       *
       * 创建人：夏阳明
       * 创建时间：20090226
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmExaminationEquipmentDetailLogicUpdate(ExaminationEquipmentClass examinationEquipmentClass, string userName,
                                                             int idName, int idModel, int id)
        {
            string locUpdateStr;

            ArrayList sqlList = new ArrayList();

            bool status;
            #region
            locUpdateStr = "update experimentationEquipmentInformation set eenId = " + idName + ",";
            locUpdateStr = locUpdateStr + "eemId = " + idModel + ",netWorth = " + examinationEquipmentClass.NetWorth + ",";
            locUpdateStr = locUpdateStr + "addUpSum = " + examinationEquipmentClass.AddUpSum + ",buyDate = '";
            locUpdateStr = locUpdateStr + examinationEquipmentClass.BuyDate + "'," + "checkUnit = '";
            locUpdateStr = locUpdateStr + examinationEquipmentClass.CheckUnit + "'," + "latestCheckDate = '";
            locUpdateStr = locUpdateStr + examinationEquipmentClass.LatestCheckDate + "',state = '";
            locUpdateStr = locUpdateStr + examinationEquipmentClass.State + "',inputMan = '";
            locUpdateStr = locUpdateStr + userName + "',inputDate = '" + DateTime.Now.ToString() + "',remark = '";
            locUpdateStr = locUpdateStr + examinationEquipmentClass.Remark + "' where id = " + id;

            sqlList.Add(locUpdateStr);

            locUpdateStr = "update experimentationEquipmentModel set model = '" + examinationEquipmentClass.Model + "',no = '";
            locUpdateStr = locUpdateStr + examinationEquipmentClass.No + "',unitPrice = " + examinationEquipmentClass.UnitPrice;
            locUpdateStr = locUpdateStr + ",checkPeriod = '" + examinationEquipmentClass.CheckPeriod + "',depreciationYear = '";
            locUpdateStr = locUpdateStr + examinationEquipmentClass.DepreciationYear + "',depreciationRate = ";
            locUpdateStr = locUpdateStr + examinationEquipmentClass.DepreciationRate + ",inputMan = '";
            locUpdateStr = locUpdateStr + userName + "',inputDate = '" + DateTime.Now.ToString() + "' ";
            locUpdateStr = locUpdateStr + "where id = " + idModel;

            sqlList.Add(locUpdateStr);

            locUpdateStr = "update experimentationEquipmentName set name = '" + examinationEquipmentClass.Name + "',maker = '";
            locUpdateStr = locUpdateStr + examinationEquipmentClass.Maker + "',inputMan = '";
            locUpdateStr = locUpdateStr + userName + "',inputDate = '" + DateTime.Now.ToString() + "' where ";
            locUpdateStr = locUpdateStr + "id = " + idName;

            sqlList.Add(locUpdateStr);

            status = sqlHelperObj.ExecuteTransaction(sqlList);

            #endregion
            return status;

        }
        /*
      * 方法名称：FrmExaminationEquipmentDetailLogicInsertName
      * 方法功能描述：插入仪器名称表并返回bool值（true为成功，false为失败）
      *
      * 创建人：夏阳明
      * 创建时间：20090226
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmExaminationEquipmentDetailLogicInsertName(ExaminationEquipmentClass examinationEquipmentClass, string userName)
        {
            string locInsertStr;

            bool status;
            #region
            locInsertStr = "insert into experimentationEquipmentName (name,maker,inputMan,inputDate) values('" + examinationEquipmentClass.Name;
            locInsertStr = locInsertStr + "','" + examinationEquipmentClass.Maker + "','" + userName + "','";
            locInsertStr = locInsertStr + DateTime.Now.ToString() + "')";

            status = sqlHelperObj.Insert(new ArrayList { locInsertStr });

            #endregion
            return status;

        }

        /*
     * 方法名称：FrmExaminationEquipmentDetailLogicInsertModel
     * 方法功能描述：插入仪器规格表并返回bool值（true为成功，false为失败）
     *
     * 创建人：夏阳明
     * 创建时间：20090226
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool FrmExaminationEquipmentDetailLogicInsertModel(ExaminationEquipmentClass examinationEquipmentClass, string userName)
        {
            string locInsertStr;

            bool status;
            #region
            locInsertStr = "insert into experimentationEquipmentModel (model,no,unitPrice,checkPeriod,depreciationYear,";
            locInsertStr = locInsertStr + "depreciationRate,inputMan,inputDate) values('" + examinationEquipmentClass.Model;
            locInsertStr = locInsertStr + "','" + examinationEquipmentClass.No + "'," + examinationEquipmentClass.UnitPrice + ",'";
            locInsertStr = locInsertStr + examinationEquipmentClass.CheckPeriod + "'," + examinationEquipmentClass.DepreciationYear;
            locInsertStr = locInsertStr + "," + examinationEquipmentClass.DepreciationRate + ",'" + userName + "','" + DateTime.Now.ToString() + "'";
            locInsertStr = locInsertStr + ")";

            status = sqlHelperObj.Insert(new ArrayList { locInsertStr });

            #endregion
            return status;

        }

        /*
       * 方法名称：FrmExaminationEquipmentDetailForDelete
       * 方法功能描述：删除数据库操作并返回bool值（true为成功，false为失败）
       *
       * 创建人：夏阳明
       * 创建时间：20090227
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmExaminationEquipmentDetailForDelete(int id)
        {
            string locUpdateStr;

            bool status;
            #region
            locUpdateStr = "delete from experimentationEquipmentInformation where id = " + id;

            status = sqlHelperObj.Delete(new ArrayList { locUpdateStr });

            #endregion
            return status;
        }

        /*
      * 方法名称：LoadInfo
      * 方法功能描述：查询数据库并返回数据集
      *
      * 创建人：夏阳明
      * 创建时间：20090410
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataSet LoadInfo(string id)
        {
            #region
            string locSearchStr;
            ArrayList arrayList = new ArrayList();

            locSearchStr = "select distinct EEN.name, EEM.model,EEI.buyDate,EEN.maker,EEM.unitPrice,EEM.depreciationYear ";
            locSearchStr = locSearchStr + "from experimentationEquipmentName EEN,experimentationEquipmentModel EEM,experimentationEquipmentInformation EEI ";
            locSearchStr = locSearchStr + "where EEI.eenId = EEN.id and EEI.eemId = EEM.id and EEM.no = '" + id + "'";


            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }


        /*
      * 方法名称：FrmExaminationEquipmentDetailPrintSearch
      * 方法功能描述：根据用户查询信息返回用户查询所得数据集
      *
      * 创建人：夏阳明
      * 创建时间：20090415
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataSet FrmExaminationEquipmentDetailPrintSearch(DateTime dt)
        {
            string locsearchStr;
            #region
                locsearchStr = "select eCorr.id,eModel.no,eName.name,eModel.model,eName.maker,eModel.unitPrice,";
                locsearchStr = locsearchStr + "eModel.checkPeriod,eModel.depreciationYear,eModel.depreciationRate,";
                locsearchStr = locsearchStr + "eCorr.netWorth,eCorr.addUpSum,eCorr.buyDate,eCorr.checkUnit,";
                locsearchStr = locsearchStr + "eCorr.latestCheckDate,eCorr.state,eCorr.remark from ";
                locsearchStr = locsearchStr + "experimentationEquipmentName as eName,experimentationEquipmentModel ";
                locsearchStr = locsearchStr + "as eModel,experimentationEquipmentInformation as eCorr ";
                locsearchStr = locsearchStr + "where eName.id = eCorr.eenId and eModel.id = eCorr.eemId ";
                locsearchStr = locsearchStr + "and Year(eCorr.latestCheckDate) = Year('" + dt +  "') order by eCorr.inputDate DESC";

                ds = sqlHelperObj.QueryForDateSet(new ArrayList { locsearchStr });

            #endregion
            return ds;
        }


        #endregion

        #region //新建目标配合比

        /*
        * 方法名称：InitialcbxPsort
        * 方法功能描述：查询数据库并返回数据集
        *
        * 创建人：夏阳明
        * 创建时间：20090303
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet InitialcbxPsort()
        {
            #region
            string locSearchStr;

            locSearchStr = "select distinct sort,id from productKind";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：InitialcbxProducer
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090303
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet InitialcbxProducer()
        {
            #region
            string locSearchStr;

            locSearchStr = "select distinct producer from targetProportion";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：InitialcbxProducerPP
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090305
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet InitialcbxProducerPP()
        {
            #region
            string locSearchStr;

            locSearchStr = "select distinct producer from produceProportion";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：InitialcbxKinds
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090303
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet InitialcbxKinds()
        {
            #region
            string locSearchStr;

            locSearchStr = "SELECT id, sort FROM materialKind";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
      * 方法名称：FrmMixtureRatioAddSearchDetail
      * 方法功能描述：查询数据库并返回数据集
      *
      * 创建人：夏阳明
      * 创建时间：20090303
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataSet FrmMixtureRatioAddSearchDetail(int id)
        {
            #region
            string locSearchStr;

            locSearchStr = "SELECT * FROM targetProportionDetail where tpId = " + id;

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
      * 方法名称：FrmMixtureRatioAddDeleteTargetProportion
      * 方法功能描述：执行删除操作
      *
      * 创建人：夏阳明
      * 创建时间：20090303
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmMixtureRatioAddDeleteTargetProportion(int id)
        {
            #region
            string locSearchStr;

            locSearchStr = "delete from targetProportion where id = " + id;

            status = sqlHelperObj.Delete(new ArrayList { locSearchStr });

            #endregion
            return status;
        }

        /*
      * 方法名称：FrmMixtureRatioAddNewTargetProportion
      * 方法功能描述：执行插入操作
      *
      * 创建人：夏阳明
      * 创建时间：20090303
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmMixtureRatioAddNewTargetProportion(TargetProportionClass TPClass, int id, string userName)
        {
            #region
            string locInsertStr;

            locInsertStr = "insert into targetProportion (pId,inputDate,inputMan,producer,remark) values (";
            locInsertStr = locInsertStr + id + ",'" + DateTime.Now.ToString() + "','" + userName;
            locInsertStr = locInsertStr + "','" + TPClass.Producer + "','" + TPClass.Remark + "')";

            status = sqlHelperObj.Insert(new ArrayList { locInsertStr });

            return status;

            #endregion
        }

        /*
     * 方法名称：FrmMixtureRatioAddNewTargetProportionDetail
     * 方法功能描述：执行插入操作
     *
     * 创建人：夏阳明
     * 创建时间：20090303
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool FrmMixtureRatioAddNewTargetProportionDetail(TargetProportionDetailClass TPDetailClass, string userName)
        {
            #region
            string locInsertStr;

            locInsertStr = "insert into targetProportionDetail (tpId,mId,targetProportionValue,inputDate,inputMan,producer) values (";
            locInsertStr = locInsertStr + TPDetailClass.TpId + "," + TPDetailClass.MnmcId + "," + TPDetailClass.TargetProportionValue;
            locInsertStr = locInsertStr + ",'" + DateTime.Now.ToString() + "','" + userName + "','" + TPDetailClass.Producer + "')";

            status = sqlHelperObj.Insert(new ArrayList { locInsertStr });

            return status;

            #endregion
        }

        /*
     * 方法名称：FrmMixtureRatioAddSearchId
     * 方法功能描述：查询数据库并返回数据集
     *
     * 创建人：夏阳明
     * 创建时间：20090303
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataSet FrmMixtureRatioAddSearchId()
        {
            #region
            string locSearchStr;

            locSearchStr = "SELECT Max(id) FROM targetProportion";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
     * 方法名称：FrmMixtureRatioAddSearchMaterialId
     * 方法功能描述：查询数据库并返回数据集
     *
     * 创建人：夏阳明
     * 创建时间：20090303
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataSet FrmMixtureRatioAddSearchMaterialId(int idName, int idModel)
        {
            #region
            string locSearchStr;

            locSearchStr = "SELECT id FROM material where mnId = " + idName + "and mmId = " + idModel;

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
     * 方法名称：FrmMixtureRatioAddSearchMaterialProductId
     * 方法功能描述：查询数据库并返回数据集
     *
     * 创建人：夏阳明
     * 创建时间：200903018
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataSet FrmMixtureRatioAddSearchMaterialProductId(int idName, int idModel,int verifyBit)
        {
            #region
            string locSearchStr = "";
            if (verifyBit == 1)
            {
                locSearchStr = "SELECT id FROM material where mnId = " + idName + "and mmId = " + idModel;
            }
            if (verifyBit == 2)
            {
                locSearchStr = "SELECT id FROM product where pnId = " + idName + "and pmId = " + idModel;
            }

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }


        /*
       * 方法名称：FrmMixtureRatioAddSearchAll
       * 方法功能描述：返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090304
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet FrmMixtureRatioAddSearchAll(int id)
        {
            string locsearchStr;
            #region

            locsearchStr = "select tpd.id,mlK.sort,mlN.name,mlM.model,tpd.targetProportionValue,tpd.inputDate,tpd.inputMan,tpd.producer from ";
            locsearchStr = locsearchStr + "targetProportionDetail as tpd,material as ml,materialModel as mlM,materialName as mlN,";
            locsearchStr = locsearchStr + "materialKind as mlK,targetProportion as tp where tpd.mId = ml.id and ml.mnId = mlN.id and ";
            locsearchStr = locsearchStr + "ml.mmId = mlM.id and mlN.mkId = mlK.id and tpd.tpId = " + id;

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locsearchStr });

            return ds;
            #endregion
        }

        /*
       * 方法名称：GetInsertSqlps
       * 方法功能描述：插入到目标配合比的主表中
       *
       * 创建人：夏阳明
       * 创建时间：20090304
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public string GetInsertSqlps(TargetProportionClass TPClass)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into targetProportion(");
            strsql.Append("pId,inputDate,inputMan,producer,remark)");
            strsql.Append("values(");
            strsql.Append(TPClass.PmId + ",");
            strsql.Append("'" + TPClass.InputDate + "','");
            strsql.Append(TPClass.InputMan + "','");
            strsql.Append(TPClass.Producer + "','");
            strsql.Append(TPClass.Remark + "')");
            strsql.Append(";declare  @tpId int");
            strsql.Append(";set @tpId=@@IDENTITY;");

            return strsql.ToString();
        }
        /*
      * 方法名称：GetInsertSqlpsd
      * 方法功能描述：插入到目标配合比的明细表中
      *
      * 创建人：夏阳明
      * 创建时间：20090304
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string GetInsertSqlpsd(TargetProportionDetailClass TPDetailClass)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into targetProportionDetail(");
            strsql.Append("tpId,mId,targetProportionValue,inputDate,inputMan,producer,pId");
            strsql.Append(")values(@tpId," + TPDetailClass.MnmcId + "," + TPDetailClass.TargetProportionValue + ",'");
            strsql.Append(TPDetailClass.InputDate + "','" + TPDetailClass.InputMan + "','" + TPDetailClass.Producer + "'," + TPDetailClass.PId);
            strsql.Append(") select @tpId from targetProportionDetail;");

            return strsql.ToString();
        }

        /*
      * 方法名称：FrmMixtureRatioAddDelete
      * 方法功能描述：删除数据库操作并返回bool值（true为成功，false为失败）
      *
      * 创建人：夏阳明
      * 创建时间：20090304
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmMixtureRatioAddDelete(int id)
        {
            string locUpdateStr;

            bool status;
            #region
            locUpdateStr = "delete from targetProportionDetail where id = " + id;

            status = sqlHelperObj.Delete(new ArrayList { locUpdateStr });

            #endregion
            return status;
        }

        /*
      * 方法名称：InitialcbxAddress
      * 方法功能描述：查询数据库并返回数据集
      *
      * 创建人：夏阳明
      * 创建时间：20090409
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataSet InitialcbxAddress()
        {
            #region
            string locSearchStr;

            locSearchStr = "select address,id from producer";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
     * 方法名称：InitialcbxMaker
     * 方法功能描述：查询数据库并返回数据集
     *
     * 创建人：夏阳明
     * 创建时间：20090409
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataSet InitialcbxMaker()
        {
            #region
            string locSearchStr;

            locSearchStr = "select id,name from producer";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
    * 方法名称：FrmMixtureRatioAddSearchDetailId
    * 方法功能描述：查询数据库并返回数据集
    *
    * 创建人：夏阳明
    * 创建时间：20090304
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        //public DataSet FrmMixtureRatioAddSearchDetailId()
        //{
        //    #region
        //    string locSearchStr;

        //    locSearchStr = "SELECT Max(id) FROM targetProportionDetail";

        //    ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

        //    #endregion
        //    return ds;
        //}



        #endregion

        #region //新建生产配合比

        /*
    * 方法名称：FrmMixtureRatioAddSearchPId
    * 方法功能描述：查询数据库并返回数据集
    *
    * 创建人：夏阳明
    * 创建时间：20090305
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataSet FrmMixtureRatioAddSearchPId(int idName, int idModel)
        {
            #region
            string locSearchStr;

            locSearchStr = "SELECT id FROM product where pnId = " + idName + " and pmId = " + idModel;

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }


        /*
      * 方法名称：GetPPInsertSqlps
      * 方法功能描述：插入到生产配合比的主表中
      *
      * 创建人：夏阳明
      * 创建时间：20090305
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string GetPPInsertSqlps(ProduceProportionClass PPClass)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into produceProportion(");
            strsql.Append("pId,inputDate,inputMan,producer,remark)");
            strsql.Append("values(");
            strsql.Append(PPClass.PId + ",");
            strsql.Append("'" + PPClass.InputDate + "','");
            strsql.Append(PPClass.InputMan + "','");
            strsql.Append(PPClass.Producer + "','");
            strsql.Append(PPClass.Remark + "')");
            strsql.Append(";declare  @ppId int");
            strsql.Append(";set @ppId=@@IDENTITY;");

            return strsql.ToString();
        }


        /*
      * 方法名称：GetPPInsertSqlpsd
      * 方法功能描述：插入到生产配合比的明细表中
      *
      * 创建人：夏阳明
      * 创建时间：20090305
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string GetPPInsertSqlpsd(ProduceProportionDetailClass PPDClass)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into produceProportionDetail(");
            strsql.Append("ppId,produceProportion,produceProportionValue,inputDate,inputMan,producer");
            strsql.Append(")values(@ppId,'" + PPDClass.ProduceProportion + "'," + PPDClass.ProduceProportionValue + ",'");
            strsql.Append(PPDClass.InputDate + "','" + PPDClass.InputMan + "','" + PPDClass.Producer + "'");
            strsql.Append(") select @ppId from produceProportionDetail;");

            return strsql.ToString();
        }

        #endregion

        #region//新建乳化沥青配合比

        /*
       * 方法名称：InitialcbxRProducer
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090306
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet InitialcbxRProducer()
        {
            #region
            string locSearchStr;

            locSearchStr = "select distinct producer from proportion";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }


        /*
    * 方法名称：FrmGYMixtureRatioSearchPId
    * 方法功能描述：查询数据库并返回数据集
    *
    * 创建人：夏阳明
    * 创建时间：20090306
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataSet FrmGYMixtureRatioSearchPId(int idName, int idModel)
        {
            #region
            string locSearchStr;

            locSearchStr = "SELECT id FROM product where pnId = " + idName + " and pmId = " + idModel;

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
      * 方法名称：GetPInsertSqlps
      * 方法功能描述：插入到目标配合比的主表中
      *
      * 创建人：夏阳明
      * 创建时间：20090306
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string GetPInsertSqlps(ProportionClass PClass)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into proportion(");
            strsql.Append("pId,inputDate,inputMan,producer,remark,mark2)");
            strsql.Append("values(");
            strsql.Append(PClass.PId + ",");
            strsql.Append("'" + PClass.InputDate + "','");
            strsql.Append(PClass.InputMan + "','");
            strsql.Append(PClass.Producer + "','");
            strsql.Append(PClass.Remark + "'," + PClass.Mark2 + ")");
            strsql.Append(";declare  @pId int");
            strsql.Append(";set @pId=@@IDENTITY;");

            return strsql.ToString();
        }
        /*
      * 方法名称：GetPInsertSqlpsd
      * 方法功能描述：插入到目标配合比的明细表中
      *
      * 创建人：夏阳明
      * 创建时间：20090306
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string GetPInsertSqlpsd(ProportionDetailClass PDClass)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into proportionDetail(");
            strsql.Append("pId,mId,proportionValue,inputDate,inputMan,producer,ppid");
            strsql.Append(")values(@pId,'" + PDClass.MId + "'," + PDClass.ProportionValue + ",'");
            strsql.Append(PDClass.InputDate + "','" + PDClass.InputMan + "','" + PDClass.Producer + "'," + PDClass.PpId);
            strsql.Append(") select @pId from proportionDetail;");

            return strsql.ToString();
        }

        #endregion

        #region //配合比查询

        /*
        * 方法名称：FrmMixtureRatioSearch
        * 方法功能描述：根据用户查询信息返回用户查询所得数据集
        *
        * 创建人：夏阳明
        * 创建时间：20090305
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet FrmMixtureRatioSearch(string searchStr, string condition, int verifyBit)
        {
            DataSet ds = new DataSet();

            ArrayList arrayList = new ArrayList();

            string locsearchStr;

            if (verifyBit == 0)
            {
                //目标配合比
                locsearchStr = "select TP.id,PK.sort,PN.name,PM.model,TP.inputDate,TP.inputMan,TP.producer,";
                locsearchStr = locsearchStr + "TP.remark,TP.assessor assessorT,TP.checkupMan checkupManT,TP.assessDate assessDateT,TP.checkupDate checkupDateT ";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,targetProportion as TP";
                locsearchStr = locsearchStr + " where TP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id order by inputDate DESC;";//把所有产品表中的外键连起来。

                arrayList.Add(locsearchStr);

                //生产配合比
                locsearchStr = "select PP.id,PK.sort,PN.name,PM.model,PP.inputDate,PP.inputMan,PP.producer,";
                locsearchStr = locsearchStr + "PP.remark,PP.assessor assessorP,PP.checkupMan checkupManP,PP.assessDate assessDateP,PP.checkupDate checkupDateP";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,produceProportion as PP";
                locsearchStr = locsearchStr + " where PP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id order by inputDate DESC;";//把所有产品表中的外键连起来。

                arrayList.Add(locsearchStr);

                //乳化沥青
                locsearchStr = "select proportion.id,PK.sort,PN.name,PM.model,proportion.inputDate,proportion.inputMan,proportion.producer,";
                locsearchStr = locsearchStr + "proportion.remark,proportion.assessor assessorR,proportion.checkupMan checkupManR,proportion.assessDate assessDateR,proportion.checkupDate checkupDateR";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,proportion";
                locsearchStr = locsearchStr + " where proportion.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and proportion.mark2 = 1 order by inputDate DESC;";//把所有产品表中的外键连起来。

                arrayList.Add(locsearchStr);

                //改性沥青
                locsearchStr = "select proportion.id,PK.sort,PN.name,PM.model,proportion.inputDate,proportion.inputMan,proportion.producer,";
                locsearchStr = locsearchStr + "proportion.remark,proportion.assessor assessorG,proportion.checkupMan checkupManG,proportion.assessDate assessDateG,proportion.checkupDate checkupDateG";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,proportion";
                locsearchStr = locsearchStr + " where proportion.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and proportion.mark2 = 0 order by inputDate DESC;";//把所有产品表中的外键连起来。

                arrayList.Add(locsearchStr);

                ds = sqlHelperObj.QueryForDateSet(arrayList);

            }
            if (verifyBit == 1)
            {
                //目标配合比
                locsearchStr = "select TP.id,PK.sort,PN.name,PM.model,TP.inputDate,TP.inputMan,TP.producer,";
                locsearchStr = locsearchStr + "TP.remark,TP.assessor assessorT,TP.checkupMan checkupManT,TP.assessDate assessDateT,TP.checkupDate checkupDateT";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,targetProportion as TP";
                locsearchStr = locsearchStr + " where TP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and " + condition + " like '%" + searchStr + "%' order by inputDate DESC;";//把所有产品表中的外键连起来。

                arrayList.Add(locsearchStr);

                //生产配合比
                locsearchStr = "select PP.id,PK.sort,PN.name,PM.model,PP.inputDate,PP.inputMan,PP.producer,";
                locsearchStr = locsearchStr + "PP.remark,PP.assessor assessorP,PP.checkupMan checkupManP,PP.assessDate assessDateP,PP.checkupDate checkupDateP";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,produceProportion as PP";
                locsearchStr = locsearchStr + " where PP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and " + condition + " like '%" + searchStr + "%' order by inputDate DESC;";//把所有产品表中的外键连起来。

                arrayList.Add(locsearchStr);

                //乳化沥青
                locsearchStr = "select proportion.id,PK.sort,PN.name,PM.model,proportion.inputDate,proportion.inputMan,proportion.producer,";
                locsearchStr = locsearchStr + "proportion.remark,proportion.assessor assessorR,proportion.checkupMan checkupManR,proportion.assessDate assessDateR,proportion.checkupDate checkupDateR";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,proportion";
                locsearchStr = locsearchStr + " where proportion.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and " + condition + " like '%" + searchStr + "%' order by inputDate DESC;";//把所有产品表中的外键连起来。

                arrayList.Add(locsearchStr);

                //改性沥青
                locsearchStr = "select proportion.id,PK.sort,PN.name,PM.model,proportion.inputDate,proportion.inputMan,proportion.producer,";
                locsearchStr = locsearchStr + "proportion.remark,proportion.assessor assessorG,proportion.checkupMan checkupManG,proportion.assessDate assessDateG,proportion.checkupDate checkupDateG";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,proportion";
                locsearchStr = locsearchStr + " where proportion.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and " + condition + " like '%" + searchStr + "%' order by inputDate DESC;";//把所有产品表中的外键连起来。


                arrayList.Add(locsearchStr);

                ds = sqlHelperObj.QueryForDateSet(arrayList);

            }
            return ds;
        }

        /*
       * 方法名称：FrmMixtureRatioDelete
       * 方法功能描述：删除数据库操作并返回bool值（true为成功，false为失败）
       *
       * 创建人：夏阳明
       * 创建时间：20090306
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmMixtureRatioDeleteT(int id)
        {
            string locUpdateStr;

            bool status;
            #region
            locUpdateStr = "delete from targetProportionDetail where tpId = " + id + ";delete from targetProportion where id = " + id;

            status = sqlHelperObj.Delete(new ArrayList { locUpdateStr });

            #endregion
            return status;
        }


        /*
       * 方法名称：FrmMixtureRatioDeleteP
       * 方法功能描述：删除数据库操作并返回bool值（true为成功，false为失败）
       *
       * 创建人：夏阳明
       * 创建时间：20090306
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmMixtureRatioDeleteP(int id)
        {
            string locUpdateStr;

            bool status;
            #region
            locUpdateStr = "delete from produceProportionDetail where ppId = " + id + ";delete from produceProportion where id = " + id;

            status = sqlHelperObj.Delete(new ArrayList { locUpdateStr });

            #endregion
            return status;
        }

        /*
       * 方法名称：FrmMixtureRatioDeleteR
       * 方法功能描述：删除数据库操作并返回bool值（true为成功，false为失败）
       *
       * 创建人：夏阳明
       * 创建时间：20090306
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmMixtureRatioDeleteR(int id)
        {
            string locUpdateStr;

            bool status;
            #region
            locUpdateStr = "delete from proportionDetail where pId = " + id + ";delete from proportion where id = " + id;

            status = sqlHelperObj.Delete(new ArrayList { locUpdateStr });

            #endregion
            return status;
        }



        /*
        * 方法名称：FrmMixtureRatioSearch
        * 方法功能描述：根据用户查询信息返回用户查询所得数据集
        *
        * 创建人：夏阳明
        * 创建时间：200903018
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet FrmMixtureRatioSearchDetail(int id)
        {
            DataSet ds = new DataSet();

            ArrayList arrayList = new ArrayList();

            string locsearchStr;

            //目标配合比
            locsearchStr = "select TPD.id,MK.sort,MN.name,MM.model,TPD.targetProportionValue,TPD.inputDate,TPD.inputMan,TPD.producer";
            locsearchStr = locsearchStr + " from materialKind as MK,materialName as MN,materialModel as MM,material,targetProportion as TP,";
            locsearchStr = locsearchStr + "targetProportionDetail as TPD where material.mnId = MN.id and MN.mkId = MK.id ";
            locsearchStr = locsearchStr + "and material.mmId = MM.id and material.id = TPD.mId and TPD.tpId = " + id;

            arrayList.Add(locsearchStr);

            ds = sqlHelperObj.QueryForDateSet(arrayList);
           
            return ds;
        }

        /*
      * 方法名称：FrmMixtureRatioSearchAssessor
      * 方法功能描述：查询数据库
      *
      * 创建人：夏阳明
      * 创建时间：20090413
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataSet FrmMixtureRatioSearchAssessor(long id)
        {
            string locUpdateStr;

            locUpdateStr = "select assessor from targetProportion where id = " + id;

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locUpdateStr });

            return ds;
        }
        /*
      * 方法名称：FrmMixtureRatioSearchCheckupMan
      * 方法功能描述：查询数据库
      *
      * 创建人：夏阳明
      * 创建时间：20090413
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataSet FrmMixtureRatioSearchCheckupMan(long id)
        {
            string locUpdateStr;

            locUpdateStr = "select checkupMan from targetProportion where id = " + id;

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locUpdateStr });

            return ds;
        }

        #endregion

        #region //检测项目管理

        /*
       * 方法名称：InitialcbxTestGuideline
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090307
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet InitialcbxTestGuideline()
        {
            #region
            string locSearchStr;

            locSearchStr = "SELECT distinct testGuideline FROM materialTestGuideline union ";
            locSearchStr = locSearchStr + "SELECT distinct testGuideline FROM productTestGuideline";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }


        /*
       * 方法名称：InitialcbxTestGuideline
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090307
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet InitialcbxFrequency()
        {
            #region
            string locSearchStr;

            locSearchStr = "SELECT distinct frequency FROM materialTestGuideline union ";
            locSearchStr = locSearchStr + "SELECT distinct frequency FROM productTestGuideline";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
      * 方法名称：InitialcbxGuideline
      * 方法功能描述：查询数据库并返回数据集
      *
      * 创建人：夏阳明
      * 创建时间：20090307
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataSet InitialcbxGuideline()
        {
            #region
            string locSearchStr;

            locSearchStr = "SELECT distinct eligibilityGuideline FROM materialTestGuideline union ";
            locSearchStr = locSearchStr + "SELECT distinct eligibilityGuideline FROM productTestGuideline";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
      * 方法名称：GetFInsertSqlpsd
      * 方法功能描述：插入到目标配合比的明细表中
      *
      * 创建人：夏阳明
      * 创建时间：20090307
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public string GetFInsertSqlpsd(MaterialTestGuidelineClass MTGClass,int verifyBit)
        {
            StringBuilder strsql = new StringBuilder();
            if (verifyBit == 1)
            {
                strsql.Append("insert into materialTestGuideline(");
                strsql.Append("testGuideline,frequency,mId,inputDate,inputMan,remark,eligibilityGuideline");
                strsql.Append(")values('" + MTGClass.TestGuideline + "','" + MTGClass.Frequency + "',");
                strsql.Append(MTGClass.MId + ",'" + MTGClass.InputDate + "','" + MTGClass.InputMan + "','");
                strsql.Append(MTGClass.Remark + "','" + MTGClass.Guideline + "');");
            }
            if (verifyBit == 2)
            {
                strsql.Append("insert into productTestGuideline(");
                strsql.Append("testGuideline,frequency,pId,inputDate,inputMan,remark,eligibilityGuideline");
                strsql.Append(")values('" + MTGClass.TestGuideline + "','" + MTGClass.Frequency + "',");
                strsql.Append(MTGClass.MId + ",'" + MTGClass.InputDate + "','" + MTGClass.InputMan + "','");
                strsql.Append(MTGClass.Remark + "','" + MTGClass.Guideline + "');");
            }
            
            return strsql.ToString();
        }

        /*
      * 方法名称：SearchAll
      * 方法功能描述：查询所有检测项目信息;
      *
      * 创建人：夏阳明
      * 创建时间：2009-03-07
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataSet SearchAll(string condition, int verifyBit, int raidoSelect)
        {
            StringBuilder sb = new StringBuilder();

            ArrayList al = new ArrayList();
            if (raidoSelect == 0)
            {
                sb.Append("select materialTestGuideline.id,materialKind.sort,materialName.name,materialModel.model,");
                sb.Append("materialTestGuideline.testGuideline,materialTestGuideline.frequency,materialTestGuideline.eligibilityGuideline,");
                sb.Append("materialTestGuideline.inputDate,materialTestGuideline.inputMan,Convert(Varchar(200),materialTestGuideline.remark) as 备注,");
                sb.Append("materialTestGuideline.mId from materialTestGuideline,material,materialModel,materialName,materialKind ");
                sb.Append("where materialKind.id = materialName.mkId and materialName.id = material.mnId and ");
                sb.Append("materialModel.id = material.mmId and material.id = materialTestGuideline.mId");
                switch (verifyBit)
                {
                    case 1:
                        {
                            sb.Append(" and materialKind.sort like " + "'%" + condition + "%'");
                            break;
                        }
                    case 2:
                        {
                            sb.Append(" and materialName.name like " + "'%" + condition + "%'");
                            break;
                        }
                    case 3:
                        {
                            sb.Append(" and materialModel.model like " + "'%" + condition + "%'");
                            break;
                        }
                    default:
                        {
                            sb.Append(" and 1 = 1");
                            break;
                        }
                }
            }
            //sb.Append(" union ");
            else
            {
                sb.Append("select productTestGuideline.id,productKind.sort,productName.name,productModel.model,");
                sb.Append("productTestGuideline.testGuideline,productTestGuideline.frequency,productTestGuideline.eligibilityGuideline,");
                sb.Append("productTestGuideline.inputDate,productTestGuideline.inputMan,Convert(varchar(200),productTestGuideline.remark) as 备注,");
                sb.Append("productTestGuideline.pId from productTestGuideline,product,productModel,productName,productKind ");
                sb.Append("where productKind.id = productName.pkId and productName.id = product.pnId and ");
                sb.Append("productModel.id = product.pmId and product.id = productTestGuideline.pId");

                switch (verifyBit)
                {
                    case 1:
                        {
                            sb.Append(" and productKind.sort like " + "'%" + condition + "%'");
                            break;
                        }
                    case 2:
                        {
                            sb.Append(" and productName.name like " + "'%" + condition + "%'");
                            break;
                        }
                    case 3:
                        {
                            sb.Append(" and productModel.model like " + "'%" + condition + "%'");
                            break;
                        }
                    default:
                        {
                            sb.Append(" and 1 = 1");
                            break;
                        }
                }
            }

            al.Add(sb.ToString());

            return ds = sqlHelperObj.QueryForDateSet(al);
        }

        /*
      * 方法名称：FrmInspectingfrequencyUpdateSave
      * 方法功能描述：查询数据库并返回数据集
      *
      * 创建人：夏阳明
      * 创建时间：20090414
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmInspectingfrequencyUpdateSave(MaterialTestGuidelineClass MTGDC)
        {
            #region
            string locSearchStr;
            if (MTGDC.VerityBit == 0)
            {
                locSearchStr = "Update materialTestGuideline set frequency = '" + MTGDC.Frequency + "',eligibilityGuideline = '" + MTGDC.Guideline + "',remark = '" + MTGDC.Remark + "' where id = " + MTGDC.Id;
            }
            else
            {
                locSearchStr = "Update productTestGuideline set frequency = '" + MTGDC.Frequency + "',eligibilityGuideline = '" + MTGDC.Guideline + "',remark = '" + MTGDC.Remark + "' where id = " + MTGDC.Id;
            }
            //locSearchStr = "Update case " + MTGDC.VerityBit + " when 0 then materialTestGuideline" + " when 1 then productTestGuideline end set frequency = '" + MTGDC.Frequency + "',eligibilityGuideline = '" + MTGDC.Guideline + "',remark = '" + MTGDC.Remark + "'";

            return sqlHelperObj.ExecuteTransaction(new ArrayList { locSearchStr });

            #endregion
            
        }


        #endregion

        #region //配合比发送

        /*
        * 方法名称：InitialCbxEiId
        * 方法功能描述：查询数据库并返回数据集
        *
        * 创建人：夏阳明
        * 创建时间：20090308
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet InitialCbxEiId()
        {
            #region
            string locSearchStr;

            locSearchStr = "select no,id from equipmentInformation";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
        * 方法名称：InitialcbxTId
        * 方法功能描述：查询数据库并返回数据集
        *
        * 创建人：夏阳明
        * 创建时间：20090308
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet InitialcbxTId()
        {
            #region
            string locSearchStr;

            locSearchStr = "select id from targetProportion where checkupMan is not null and checkupMan != ''";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：InitialcbxRTId
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090309
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet InitialcbxRTId()
        {
            #region
            string locSearchStr;

            locSearchStr = "select id from proportion where mark2 = 1 and checkupMan is not null and checkupMan != ''";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：InitialcbxGTId
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090309
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet InitialcbxGTId()
        {
            #region
            string locSearchStr;

            locSearchStr = "select id from proportion where mark2 = 0 and checkupMan is not null and checkupMan != ''";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：InitialcbxPId
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090308
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet InitialcbxPId()
        {
            #region
            string locSearchStr;

            locSearchStr = "select id from produceProportion where checkupMan is not null and checkupMan != ''";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }

        /*
       * 方法名称：InitialcbxInputMan
       * 方法功能描述：查询数据库并返回数据集
       *
       * 创建人：夏阳明
       * 创建时间：20090308
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataSet InitialcbxInputMan()
        {
            #region
            string locSearchStr;

            locSearchStr = "select distinct inputMan from sendProportion";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList { locSearchStr });

            #endregion
            return ds;
        }


        /*
     * 方法名称：FrmProportionSendSearchTP
     * 方法功能描述：查询目标配合比信息;
     *
     * 创建人：夏阳明
     * 创建时间：2009-03-08
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public DataSet FrmProportionSendSearchTP(string condition)
        {
            StringBuilder sb = new StringBuilder();

            ArrayList al = new ArrayList();

            sb.Append("select tPD.id,mK.sort,mN.name,mM.model,tPD.targetProportionValue,P.address,P.name,tPD.inputDate,tPD.inputMan,tPD.producer,tPD.mId,tPD.tpId");
            sb.Append(" from targetProportionDetail as tPD,material as m,materialModel as mM,materialName as mN,materialKind as mK,producer as P");
            sb.Append(" where tPD.mId = m.id and m.mmId = mM.id and m.mnId = mN.id and mN.mkId = mK.id and P.id = tPD.pId and tPD.tpId = " + condition);

            al.Add(sb.ToString());

            return ds = sqlHelperObj.QueryForDateSet(al);
        }

        /*
    * 方法名称：proportionBind
    * 方法功能描述：查询生产配合比信息;
    *
    * 创建人：夏阳明
    * 创建时间：2009-03-08
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataSet proportionBind(string ppId)
        {
            StringBuilder sb = new StringBuilder();

            ArrayList al = new ArrayList();

            al.Add("select produceProportion,produceProportionValue from produceProportionDetail where ppid=" + ppId);

            return ds = sqlHelperObj.QueryForDateSet(al);
        }

        /*
      * 方法名称：FrmProportionSendSend
      * 方法功能描述：执行插入操作
      *
      * 创建人：夏阳明
      * 创建时间：20090308
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmProportionSendSend(string inputMan, string remark, string eiId, string tId, string pId)
        {
            #region

            StringBuilder sb = null;

            ArrayList arrayList = new ArrayList();

            sb = new StringBuilder();
            sb.Append("insert into sendProportion (inputDate,inputMan,remark) values (");
            sb.Append("GetDate(),'" + inputMan + "','" + remark + "')");
            sb.Append(";declare  @spId int");
            sb.Append(";set @spId=@@IDENTITY;");

            arrayList.Add(sb.ToString());

            sb = new StringBuilder();
            sb.Append("insert into targetSendProportionDetail (tpId,eiId,spId) values (");
            sb.Append(tId + "," + eiId + ",@spId" + ");");

            arrayList.Add(sb.ToString());

            sb = new StringBuilder();
            sb.Append("insert into produceSendProportionDetail (ppId,eiId,spId) values (");
            sb.Append(pId + "," + eiId + ",@spId" + ");");

            arrayList.Add(sb.ToString());

            sb = new StringBuilder();
            sb.Append("update targetProportion set mark = 1 where id = " + tId);

            arrayList.Add(sb.ToString());

            sb = new StringBuilder();
            sb.Append(";update produceProportion set mark = 1 where id = " + tId);

            arrayList.Add(sb.ToString());



            status = sqlHelperObj.ExecuteTransaction(arrayList);

            return status;

            #endregion
        }

        /*
    * 方法名称：FrmProportionSendSearchP
    * 方法功能描述：查询目标配合比信息;
    *
    * 创建人：夏阳明
    * 创建时间：2009-03-09
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataSet FrmProportionSendSearchP(string condition)
        {
            StringBuilder sb = new StringBuilder();

            ArrayList al = new ArrayList();

            sb.Append("select PD.id,mK.sort,mN.name,mM.model,PD.proportionValue,producer.address,producer.name,PD.inputDate,PD.inputMan,PD.producer,PD.mId,PD.pId");
            sb.Append(" from proportionDetail as PD,material as m,materialModel as mM,materialName as mN,materialKind as mK,proportion as P,producer");
            sb.Append(" where PD.mId = m.id and m.mmId = mM.id and m.mnId = mN.id and mN.mkId = mK.id and producer.id = PD.ppId and PD.pId = " + condition);
            sb.Append(" and P.id = PD.pId and P.mark2 = 1");

            al.Add(sb.ToString());

            return ds = sqlHelperObj.QueryForDateSet(al);
        }

        /*
   * 方法名称：FrmProportionSendSearchPG
   * 方法功能描述：查询配合比信息;
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-09
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        public DataSet FrmProportionSendSearchPG(string condition)
        {
            StringBuilder sb = new StringBuilder();

            ArrayList al = new ArrayList();

            sb.Append("select PD.id,mK.sort,mN.name,mM.model,PD.proportionValue,producer.address,producer.name,PD.inputDate,PD.inputMan,PD.producer,PD.mId,PD.pId");
            sb.Append(" from proportionDetail as PD,material as m,materialModel as mM,materialName as mN,materialKind as mK,proportion as P,producer");
            sb.Append(" where PD.mId = m.id and m.mmId = mM.id and m.mnId = mN.id and mN.mkId = mK.id and producer.id = PD.ppId and PD.pId = " + condition);
            sb.Append(" and P.id = PD.pId");

            al.Add(sb.ToString());

            return ds = sqlHelperObj.QueryForDateSet(al);
        }

        /*
     * 方法名称：FrmProportionRSendSend
     * 方法功能描述：执行插入操作
     *
     * 创建人：夏阳明
     * 创建时间：20090309
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool FrmProportionRSendSend(string inputMan, string remark, string eiId, string tId)
        {
            #region

            StringBuilder sb = null;

            ArrayList arrayList = new ArrayList();

            sb = new StringBuilder();
            sb.Append("insert into sendProportion (inputDate,inputMan,remark) values (");
            sb.Append("GetDate(),'" + inputMan + "','" + remark + "')");
            sb.Append(";declare  @spId int");
            sb.Append(";set @spId=@@IDENTITY;");

            arrayList.Add(sb.ToString());

            sb = new StringBuilder();
            sb.Append("insert into sendProportionDetail (pId,eiId,spId) values (");
            sb.Append(tId + "," + eiId + ",@spId" + ");");

            arrayList.Add(sb.ToString());

            sb = new StringBuilder();
            sb.Append("update proportion set mark = 1 where id = " + tId);

            arrayList.Add(sb.ToString());

            status = sqlHelperObj.ExecuteTransaction(arrayList);

            return status;

            #endregion
        }

        /*
     * 方法名称：FrmProportionGSendSend
     * 方法功能描述：执行插入操作
     *
     * 创建人：夏阳明
     * 创建时间：20090309
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool FrmProportionGSendSend(string inputMan, string remark, string eiId, string tId)
        {
            #region

            StringBuilder sb = null;

            ArrayList arrayList = new ArrayList();

            sb = new StringBuilder();
            sb.Append("insert into sendProportion (inputDate,inputMan,remark) values (");
            sb.Append("GetDate(),'" + inputMan + "','" + remark + "')");
            sb.Append(";declare  @spId int");
            sb.Append(";set @spId=@@IDENTITY;");

            arrayList.Add(sb.ToString());

            sb = new StringBuilder();
            sb.Append("insert into sendProportionDetail (pId,eiId,spId) values (");
            sb.Append(tId + "," + eiId + ",@spId" + ");");

            arrayList.Add(sb.ToString());

            sb = new StringBuilder();
            sb.Append("update proportion set mark = 1 where id = " + tId);

            arrayList.Add(sb.ToString());

            status = sqlHelperObj.ExecuteTransaction(arrayList);

            return status;

            #endregion
        }


        /*
    * 方法名称：FrmMixtureRatioSearch
    * 方法功能描述：查询配合比发送信息
    *
    * 创建人：夏阳明
    * 创建时间：20090309
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataSet FormFrmProportionSendSearch()
        {
            DataSet ds = new DataSet();

            ArrayList arrayList = new ArrayList();

            string locsearchStr;

            locsearchStr = "select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,Convert(VarChar(200),SP.remark) as R,EI.no";
            locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP,";
            locsearchStr = locsearchStr + "sendProportionDetail as SPD,proportion as P,equipmentInformation as EI";
            locsearchStr = locsearchStr + " where P.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
            locsearchStr = locsearchStr + "and product.pmId = PM.id and SPD.pId = P.id and P.pId = product.id";
            locsearchStr = locsearchStr + " and SP.id = SPD.spId and SPD.eiId = EI.id union ";

            locsearchStr = locsearchStr + "select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,Convert(VarChar(200),SP.remark) as R,EI.no";
            locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP,";
            locsearchStr = locsearchStr + "targetSendProportionDetail as TSPD,targetProportion as TP,equipmentInformation as EI";
            locsearchStr = locsearchStr + " where TP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
            locsearchStr = locsearchStr + "and product.pmId = PM.id and TSPD.tpId = TP.id and TP.pId = product.id";
            locsearchStr = locsearchStr + " and SP.id = TSPD.spId and TSPD.eiId = EI.id union ";

            locsearchStr = locsearchStr + "select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,Convert(VarChar(200),SP.remark) as R,EI.no";
            locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP,";
            locsearchStr = locsearchStr + "produceSendProportionDetail as PSPD,produceProportion as PP,equipmentInformation as EI";
            locsearchStr = locsearchStr + " where PP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
            locsearchStr = locsearchStr + "and product.pmId = PM.id and PSPD.ppId = PP.id and PP.pId = product.id";
            locsearchStr = locsearchStr + " and SP.id = PSPD.spId and PSPD.eiId = EI.id order by inputDate DESC";

            arrayList.Add(locsearchStr);

            ds = sqlHelperObj.QueryForDateSet(arrayList);

            return ds;
        }

        /*
        * 方法名称：FrmProportionSendQuery
        * 方法功能描述：根据用户查询信息返回用户查询所得数据集
        *
        * 创建人：夏阳明
        * 创建时间：20090309
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet FrmProportionSendQuery(string searchStr, string condition, int verifyBit, DateTime searchStrD)
        {
            DataSet ds = new DataSet();

            ArrayList arrayList = new ArrayList();

            string locsearchStr;

            if (verifyBit == 0)
            {
                locsearchStr = "select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,Convert(VarChar(200),SP.remark) as R,EI.no";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP,";
                locsearchStr = locsearchStr + "sendProportionDetail as SPD,proportion as P,equipmentInformation as EI";
                locsearchStr = locsearchStr + " where P.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and SPD.pId = P.id and P.pId = product.id";
                locsearchStr = locsearchStr + " and SP.id = SPD.spId and SPD.eiId = EI.id union ";

                locsearchStr = locsearchStr + "select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,Convert(VarChar(200),SP.remark) as R,EI.no";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP,";
                locsearchStr = locsearchStr + "targetSendProportionDetail as TSPD,targetProportion as TP,equipmentInformation as EI";
                locsearchStr = locsearchStr + " where TP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and TSPD.tpId = TP.id and TP.pId = product.id";
                locsearchStr = locsearchStr + " and SP.id = TSPD.spId and TSPD.eiId = EI.id union ";

                locsearchStr = locsearchStr + "select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,Convert(VarChar(200),SP.remark) as R,EI.no";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP,";
                locsearchStr = locsearchStr + "produceSendProportionDetail as PSPD,produceProportion as PP,equipmentInformation as EI";
                locsearchStr = locsearchStr + " where PP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and PSPD.ppId = PP.id and PP.pId = product.id";
                locsearchStr = locsearchStr + " and SP.id = PSPD.spId and PSPD.eiId = EI.id ";

                arrayList.Add(locsearchStr);

                ds = sqlHelperObj.QueryForDateSet(arrayList);

            }
            if ((verifyBit == 1) && (condition != "inputDate"))
            {

                locsearchStr = "select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,Convert(VarChar(200),SP.remark) as R,EI.no";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP,";
                locsearchStr = locsearchStr + "sendProportionDetail as SPD,proportion as P,equipmentInformation as EI";
                locsearchStr = locsearchStr + " where P.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and SPD.pId = P.id and P.pId = product.id";
                locsearchStr = locsearchStr + " and SP.id = SPD.spId and SPD.eiId = EI.id and " + condition + " like '%" + searchStr + "%' union ";

                locsearchStr = locsearchStr + "select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,Convert(VarChar(200),SP.remark) as R,EI.no";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP,";
                locsearchStr = locsearchStr + "targetSendProportionDetail as TSPD,targetProportion as TP,equipmentInformation as EI";
                locsearchStr = locsearchStr + " where TP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and TSPD.tpId = TP.id and TP.pId = product.id";
                locsearchStr = locsearchStr + " and SP.id = TSPD.spId and TSPD.eiId = EI.id and " + condition + " like '%" + searchStr + "%' union ";

                locsearchStr = locsearchStr + "select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,Convert(VarChar(200),SP.remark) as R,EI.no";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP,";
                locsearchStr = locsearchStr + "produceSendProportionDetail as PSPD,produceProportion as PP,equipmentInformation as EI";
                locsearchStr = locsearchStr + " where PP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and PSPD.ppId = PP.id and PP.pId = product.id";
                locsearchStr = locsearchStr + " and SP.id = PSPD.spId and PSPD.eiId = EI.id and " + condition + " like '%" + searchStr + "%';";

                arrayList.Add(locsearchStr);

                ds = sqlHelperObj.QueryForDateSet(arrayList);
            }
            else
            {
                locsearchStr = "select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,Convert(VarChar(200),SP.remark) as R,EI.no";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP,";
                locsearchStr = locsearchStr + "sendProportionDetail as SPD,proportion as P,equipmentInformation as EI";
                locsearchStr = locsearchStr + " where P.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and SPD.pId = P.id and P.pId = product.id";
                locsearchStr = locsearchStr + " and SP.id = SPD.spId and SPD.eiId = EI.id and SP.inputDate between '" + searchStrD + "' and DateADD(dd,1,'" + searchStrD + "') union ";

                locsearchStr = locsearchStr + "select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,Convert(VarChar(200),SP.remark) as R,EI.no";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP,";
                locsearchStr = locsearchStr + "targetSendProportionDetail as TSPD,targetProportion as TP,equipmentInformation as EI";
                locsearchStr = locsearchStr + " where TP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and TSPD.tpId = TP.id and TP.pId = product.id";
                locsearchStr = locsearchStr + " and SP.id = TSPD.spId and TSPD.eiId = EI.id and SP.inputDate between '" + searchStrD + "' and DateADD(dd,1,'" + searchStrD + "') union ";

                locsearchStr = locsearchStr + "select SP.id,PK.sort,PN.name,PM.model,SP.inputDate,SP.inputMan,SP.confirmDate,Convert(VarChar(200),SP.remark) as R,EI.no";
                locsearchStr = locsearchStr + " from productKind as PK,productName as PN,productModel as PM,product,sendProportion as SP,";
                locsearchStr = locsearchStr + "produceSendProportionDetail as PSPD,produceProportion as PP,equipmentInformation as EI";
                locsearchStr = locsearchStr + " where PP.pId = product.id and product.pnId = PN.id and PN.pkId = PK.id ";
                locsearchStr = locsearchStr + "and product.pmId = PM.id and PSPD.ppId = PP.id and PP.pId = product.id";
                locsearchStr = locsearchStr + " and SP.id = PSPD.spId and PSPD.eiId = EI.id and SP.inputDate between '" + searchStrD + "' and DateADD(dd,1,'" + searchStrD + "')";

                arrayList.Add(locsearchStr);

                ds = sqlHelperObj.QueryForDateSet(arrayList);
            }
            return ds;
        }


        /*
    * 方法名称：FrmProportionSendSearchRG
    * 方法功能描述：查询是乳化沥青还是改性沥青
    *
    * 创建人：夏阳明
    * 创建时间：20090309
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public DataSet FrmProportionSendSearchRG(int id)
        {
            DataSet ds = new DataSet();

            ArrayList arrayList = new ArrayList();

            string locsearchStr;

            locsearchStr = "select proportion.mark2";
            locsearchStr = locsearchStr + " from proportion,sendProportion,sendProportionDetail";
            locsearchStr = locsearchStr + " where sendProportion.id = sendProportionDetail.spId and ";
            locsearchStr = locsearchStr + "sendProportionDetail.pId = proportion.id and sendProportion.id = " + id;

            arrayList.Add(locsearchStr);

            ds = sqlHelperObj.QueryForDateSet(arrayList);

            return ds;
        }


        /*
   * 方法名称：FrmProportionSendSearchPId
   * 方法功能描述：查询PId
   *
   * 创建人：夏阳明
   * 创建时间：20090309
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        public DataSet FrmProportionSendSearchPId(int id)
        {
            DataSet ds = new DataSet();

            ArrayList arrayList = new ArrayList();

            string locsearchStr;

            locsearchStr = "select proportion.id";
            locsearchStr = locsearchStr + " from proportion,sendProportion,sendProportionDetail";
            locsearchStr = locsearchStr + " where sendProportion.id = sendProportionDetail.spId and ";
            locsearchStr = locsearchStr + "sendProportionDetail.pId = proportion.id and proportion.mark2 = 1 and sendProportionDetail.spId = " + id;

            arrayList.Add(locsearchStr);

            ds = sqlHelperObj.QueryForDateSet(arrayList);

            return ds;
        }

        /*
   * 方法名称：FrmProportionSendSearchGPId
   * 方法功能描述：查询PId
   *
   * 创建人：夏阳明
   * 创建时间：20090309
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        public DataSet FrmProportionSendSearchGPId(int id)
        {
            DataSet ds = new DataSet();

            ArrayList arrayList = new ArrayList();

            string locsearchStr;

            locsearchStr = "select proportion.id";
            locsearchStr = locsearchStr + " from proportion,sendProportion,sendProportionDetail";
            locsearchStr = locsearchStr + " where sendProportion.id = sendProportionDetail.spId and ";
            locsearchStr = locsearchStr + "sendProportionDetail.pId = proportion.id and proportion.mark2 = 0 and sendProportionDetail.spId = " + id;

            arrayList.Add(locsearchStr);

            ds = sqlHelperObj.QueryForDateSet(arrayList);

            return ds;
        }

        /*
  * 方法名称：FrmProportionSendSearchTpId
  * 方法功能描述：查询TpId
  *
  * 创建人：夏阳明
  * 创建时间：20090309
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */
        public DataSet FrmProportionSendSearchTpId(int id)
        {
            DataSet ds = new DataSet();

            ArrayList arrayList = new ArrayList();

            string locsearchStr;

            locsearchStr = "select targetProportion.id";
            locsearchStr = locsearchStr + " from targetProportion,sendProportion,targetSendProportionDetail";
            locsearchStr = locsearchStr + " where sendProportion.id = targetSendProportionDetail.spId and ";
            locsearchStr = locsearchStr + "targetSendProportionDetail.tpId = targetProportion.id and targetSendProportionDetail.spId = " + id;

            arrayList.Add(locsearchStr);

            ds = sqlHelperObj.QueryForDateSet(arrayList);

            return ds;
        }

        /*
 * 方法名称：FrmProportionSendSearchPpId
 * 方法功能描述：查询PpId
 *
 * 创建人：夏阳明
 * 创建时间：20090309
 *
 * 修改人：
 * 修改时间：
 * 修改内容：
 *
 */
        public DataSet FrmProportionSendSearchPpId(int id)
        {
            DataSet ds = new DataSet();

            ArrayList arrayList = new ArrayList();

            string locsearchStr;

            locsearchStr = "select produceProportion.id";
            locsearchStr = locsearchStr + " from produceProportion,sendProportion,produceSendProportionDetail";
            locsearchStr = locsearchStr + " where sendProportion.id = produceSendProportionDetail.spId and ";
            locsearchStr = locsearchStr + "produceSendProportionDetail.ppId = produceProportion.id and produceSendProportionDetail.spId = " + id;

            arrayList.Add(locsearchStr);

            ds = sqlHelperObj.QueryForDateSet(arrayList);

            return ds;
        }

        /*
   * 方法名称：FrmProportionSendSearchM
   * 方法功能描述：查询拌合料目标配合比信息;
   *
   * 创建人：夏阳明
   * 创建时间：2009-03-09
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
        public DataSet FrmProportionSendSearchM(string condition)
        {
            StringBuilder sb = new StringBuilder();

            ArrayList al = new ArrayList();

            sb.Append("select PD.id,mK.sort,mN.name,mM.model,PD.proportionValue,PD.inputDate,PD.inputMan,PD.producer,PD.mId,PD.pId");
            sb.Append(" from proportionDetail as PD,material as m,materialModel as mM,materialName as mN,materialKind as mK,proportion as P");
            sb.Append(" where PD.mId = m.id and m.mmId = mM.id and m.mnId = mN.id and mN.mkId = mK.id and PD.pId = " + condition);
            sb.Append(" and P.id = PD.pId and P.mark2 = 0");

            al.Add(sb.ToString());

            return ds = sqlHelperObj.QueryForDateSet(al);
        }

        #endregion

    #endregion

    }



    /*
     * 类名称：DetectingRecordsDB
     * 类功能描述：为试验检测台帐提供数据库操作
     *
     * 创建人：关启学
     * 创建时间：2009-02-28
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */

    #region //为试验检测台帐提供数据库操作
    class DetectingRecordsDB
    {
        //用于“试验室软件”的数据库操作
        private SqlHelper sqlHelperLab = new SqlHelper("Lab");

        //用户“拌和站软件”的数据库操作
        private SqlHelper sqlHelper = new SqlHelper();

        public DetectingRecordsDB()
        {
            IniLabSQL();
            IniMaterialSQL();
            IniProductSQL();
        }



        #region //“试验室软件”相关操作方法

        //试验记录SQL:select
        private StringBuilder labTestSelectString = new StringBuilder();


        //初始化"试验信息"的相关操作的SQL语句
        private void IniLabSQL()
        {
            //由于“试验室软件”的数据库的“试验时间”字段为“字符型”，所以需要转换成datetime型
            //时间的比较为区间性比较，不能直接利用等号判等

            //试验记录SQL:select
            labTestSelectString.Append(" SELECT *");
            labTestSelectString.Append(" FROM");
            labTestSelectString.Append("   ( SELECT ");
            labTestSelectString.Append("       systest_number_manage.syxh                      AS   [试验编号],");
            labTestSelectString.Append("       systest_manage.symc                             AS   [试验名称],");
            labTestSelectString.Append("       systest_number_manage.jhwcrq                    AS   [试验员],");
            labTestSelectString.Append("       convert(datetime,systest_number_manage.syrq)    AS   [试验日期]");
            labTestSelectString.Append("     FROM systest_number_manage, systest_manage");
            labTestSelectString.Append("     WHERE systest_number_manage.sybh = systest_manage.sybh");
            labTestSelectString.Append("   ) AS testInfo");
            labTestSelectString.Append(" WHERE [试验日期] >= '{0}'");
            labTestSelectString.Append(" AND   [试验日期] < '{1}'");
            labTestSelectString.Append(" ORDER BY [试验编号],[试验日期]");
           
        }
       
        //试验室：按日期查询“试验信息”
        public DataTable GetLabTestInfo(DateTime dt)
        {
            string selectString = string.Format(labTestSelectString.ToString(), dt, dt.AddDays(1));
            return sqlHelperLab.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        #endregion


        #region //“材料”检测台帐相关数据库操作

        //材料检测台帐SQL
        private StringBuilder materialTestSelectString = new StringBuilder();
        private StringBuilder materialTestInsertString = new StringBuilder();
        private StringBuilder materialTestDeleteString = new StringBuilder();
        private StringBuilder materialTestUpdateString = new StringBuilder();
       

        //初始化“材料台帐”的相关操作的SQL语句
        private void IniMaterialSQL()
        {
            //id, mId, accountDate, dayQuantity, totalQuantity,  [no],     name,    man,    result, guideline,   mark,  frequency, remark,  inputDate, inputMan
            //id, mId, 台帐日期,    当日进货量,  累计进货量,   试验编号, 试验名称, 试验员, 试验结果, 合格指标, 是否合格, 实际频率,  备注,   录入时间,  录入人员

            //材料检测台帐SQL:select
            materialTestSelectString.Append("SELECT");
            materialTestSelectString.Append("   materialTestAccount.id              AS   [id],");
            materialTestSelectString.Append("   materialTestAccount.mId             AS   [mId],");
            materialTestSelectString.Append("   materialTestAccount.accountDate     AS   [台帐日期],");
            materialTestSelectString.Append("   materialKind.id                     AS   [mkId],");
            materialTestSelectString.Append("   materialKind.sort                   AS   [材料种类],");
            materialTestSelectString.Append("   materialName.id                     AS   [mnId],");
            materialTestSelectString.Append("   materialName.name                   AS   [材料名称],");
            materialTestSelectString.Append("   materialModel.id                    AS   [mmId],");
            materialTestSelectString.Append("   materialModel.model                 AS   [材料规格],");
            materialTestSelectString.Append("   materialTestAccount.dayQuantity     AS   [当日进货量],");
            materialTestSelectString.Append("   materialTestAccount.totalQuantity   AS   [累计进货量],");
            materialTestSelectString.Append("   materialTestAccount.[no]            AS   [试验编号],");
            materialTestSelectString.Append("   materialTestAccount.name            AS   [试验名称],");
            materialTestSelectString.Append("   materialTestAccount.man             AS   [试验员],");
            materialTestSelectString.Append("   materialTestAccount.result          AS   [试验结果],");
            materialTestSelectString.Append("   materialTestAccount.mark            AS   [是否合格],");
            materialTestSelectString.Append("   materialTestGuideline.frequency     AS   [设定频率],");
            materialTestSelectString.Append("   materialTestAccount.frequency       AS   [实际频率],");
            materialTestSelectString.Append("   materialTestAccount.remark          AS   [备注],");
            materialTestSelectString.Append("   materialTestAccount.inputDate       AS   [录入时间],");
            materialTestSelectString.Append("   materialTestAccount.inputMan        AS   [录入人员]");
            materialTestSelectString.Append(" FROM materialTestAccount LEFT JOIN materialTestGuideline ON  materialTestAccount.mId = materialTestGuideline.mId");
            materialTestSelectString.Append("    ,material,materialKind,materialName,materialModel");
            materialTestSelectString.Append(" WHERE materialTestAccount.mId = material.id");
            materialTestSelectString.Append(" AND material.mnId = materialName.id");
            materialTestSelectString.Append(" AND material.mmId = materialModel.id");
            materialTestSelectString.Append(" AND materialName.mkId = materialKind.id");
            materialTestSelectString.Append(" AND accountDate >= '{0}'");
            materialTestSelectString.Append(" AND accountDate < '{1}'");
            materialTestSelectString.Append(" ORDER BY [材料种类],[材料名称],[材料规格],[试验编号]");

            //材料检测台帐SQL:insert
            materialTestInsertString.Append("INSERT INTO materialTestAccount");
            materialTestInsertString.Append(" (mId,dayQuantity,totalQuantity,name,no,result,mark,man,frequency,inputDate,inputMan,accountDate,remark) ");
            materialTestInsertString.Append("VALUES ");
            materialTestInsertString.Append("({0},{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}','{12}')");

            //材料检测台帐SQL:delete
            materialTestDeleteString.Append("DELETE FROM materialTestAccount ");
            materialTestDeleteString.Append("WHERE id = {0}");

            //材料检测台帐SQL:update
            materialTestUpdateString.Append(" UPDATE materialTestAccount ");
            materialTestUpdateString.Append(" SET");
            materialTestUpdateString.Append("    mId = {0},");
            materialTestUpdateString.Append("    result = '{1}',");
            materialTestUpdateString.Append("    mark = '{2}',");
            materialTestUpdateString.Append("    remark = '{3}'");
            materialTestUpdateString.Append(" WHERE id = {4}");
            //mId,result,guideline,mark,remark


            
        }

        //材料：按日期查询“材料台帐”
        public DataTable GetMaterialTestAccount(DateTime dt)
        {
            string selectString = string.Format(materialTestSelectString.ToString(), dt, dt.AddDays(1));
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }        

        //材料：利用DataTable内记录的状态生成数据库操作SQL语句
        private ArrayList MaterialTableToSQLArray(DataTable table)
        {
            ArrayList list = new ArrayList();
            string sqlString = null;

            foreach (DataRow row in table.Rows)
            {
                switch (row.RowState)
                {
                    case DataRowState.Added:
                         //id, mId, accountDate, dayQuantity, totalQuantity,  [no],     name,    man,    result, guideline,   mark,  frequency, remark,  inputDate, inputMan
                         //id, mId, 台帐日期,    当日进货量,  累计进货量,   试验编号, 试验名称, 试验员, 试验结果, 合格指标, 是否合格, 实际频率,  备注,   录入时间,  录入人员
                         //mId,dayQuantity,totalQuantity,name,no,result,guideline,mark,man,frequency,inputDate,inputMan,accountDate,remark
                         sqlString = string.Format(materialTestInsertString.ToString()
                            , row["mId"].ToString(), row["当日进货量"].ToString(), row["累计进货量"].ToString(), row["试验名称"].ToString()
                            , row["试验编号"].ToString(), row["试验结果"].ToString(), row["是否合格"].ToString(), row["试验员"].ToString()
                            , row["实际频率"].ToString(),"getdate()" , row["录入人员"].ToString(), row["台帐日期"].ToString(), row["备注"].ToString());                        
                            break;
                    case DataRowState.Modified:
                        //mId,result,guideline,mark,remark
                        sqlString = string.Format(materialTestUpdateString.ToString()
                            , row["mId"].ToString(), row["试验结果"].ToString(), row["是否合格"].ToString(), row["备注"].ToString(),row["id"].ToString()); 
                        break;
                    //case DataRowState.Deleted:
                    //    sqlString = string.Format(materialTestDeleteString.ToString(), row["id"].ToString()); 
                    //    break;
                    default:
                        break;
                }

                list.Add(sqlString);
            }

            return list;
        }

        //材料：保存“材料试验台帐”
        public void SaveMartialTestAccount(DataTable materialTable)
        {
            //获得批量更新的SQL语句
            ArrayList sqlList = MaterialTableToSQLArray(materialTable);

            //执行批量更新
            sqlHelper.ExecuteTransaction(sqlList);

            materialTable.AcceptChanges();
        }

        //材料：获得指定材料的指定天的"当日进货量"
        public double GetMaterialDayQuantity(long mId, DateTime today)
        {
            DataTable table;
            string dayQuantity =
                "SELECT sum(stockNote.suttle) "
                + "FROM stockNote,indent "
                + "WHERE stockNote.iId = indent.id "
                + "AND indent.mId = {0} "
                + "AND stockNote.inputDate >= '{1}' "
                + "AND stockNote.inputDate < '{2}'";

            string selectString = string.Format(dayQuantity.ToString(), mId, today, today.AddDays(1));
            
            table = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            double quantity = 0;
            string temp = table.Rows[0][0].ToString();            
            if (temp != "")
            {
                quantity = Convert.ToDouble(temp);
            }

            return quantity;
                
        }

        //材料：获得指定材料的“累计进货量”
        public double GetMaterialTotalQuantity(long mId)
        {
            DataTable table;
            string totalQuantity =
                "SELECT sum(stockNote.suttle) "
                + "FROM stockNote,indent "
                + "WHERE stockNote.iId = indent.id "
                + "AND indent.mId = {0} ";


            string selectString = string.Format(totalQuantity, mId);

            table = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            double quantity = 0;
            string temp = table.Rows[0][0].ToString();
            if (temp != "")
            {
                quantity = Convert.ToDouble(temp);
            }

            return quantity;
        }

        //材料：获得指定材料，某个日期（台帐日期）之前（包括当日）的所做相同试验的次数
        private int GetMaterialTestCount(long mId, string testName, string accountDate)
        {
            DataTable table;
            string testCountString =
                "SELECT count(*) "
                + "FROM materialTestAccount "
                + "WHERE mId = {0} "
                + "AND [name] = '{1}' "
                + "AND accountDate <= '{2}' "
                + "GROUP BY [name]";


            string selectString = string.Format(testCountString, mId, testName, accountDate);

            table = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            int Count = 0;
            if (table.Rows.Count > 0)
            {
                string temp = table.Rows[0][0].ToString();
                if (temp != "")
                {
                    Count = Convert.ToInt32(temp);
                }
            }

            return Count;
        }

        //材料：获得指定材料，某个日期（台帐日期）之前（包括当日）的所做相同试验的频率 = 次数/吨
        public string GetMaterialFrequency(long mId, string testName, string accountDate)
        {
            double totalQuantity = GetMaterialTotalQuantity(mId);
            int testCount = GetMaterialTestCount(mId, testName, accountDate);

            
            string frenquencyString = "无";
            if (testCount != 0)
            {
                //四舍五入
                double frequency = Math.Round(totalQuantity / testCount + 0.1);
                frenquencyString = "1次/" + frequency.ToString() + "吨";
            }

            return frenquencyString;
        }

        #endregion


        #region //“产品”检测台帐相关数据库操作

        //产品检测台帐SQL
        private StringBuilder productTestSelectString = new StringBuilder();
        private StringBuilder productTestInsertString = new StringBuilder();
        private StringBuilder productTestDeleteString = new StringBuilder();
        private StringBuilder productTestUpdateString = new StringBuilder();

        //
        //private StringBuilder 

        //产品：初始化“产品台帐”的相关操作的SQL语句
        private void IniProductSQL()
        {
            //产品检测台帐SQL:select
            productTestSelectString.Append("SELECT ");
            productTestSelectString.Append("   productTestAccount.id         AS   [id],");
            productTestSelectString.Append("   productTestAccount.pId        AS   [pId],");
            productTestSelectString.Append("   accountDate                   AS   [台帐日期],");
            productTestSelectString.Append("   productKind.id                AS   [pkId],");
            productTestSelectString.Append("   productKind.sort              AS   [产品种类],");
            productTestSelectString.Append("   productName.id                AS   [pnId],");
            productTestSelectString.Append("   productName.name              AS   [产品名称],");
            productTestSelectString.Append("   productModel.id               AS   [pmId],");
            productTestSelectString.Append("   productModel.model            AS   [产品规格],");
            productTestSelectString.Append("   dayQuantity                   AS   [当日产量],");
            productTestSelectString.Append("   totalQuantity                 AS   [累计产量],");
            productTestSelectString.Append("   [no]                          AS   [试验编号],");
            productTestSelectString.Append("   productTestAccount.name       AS   [试验名称],");
            productTestSelectString.Append("   man                           AS   [试验员],");
            productTestSelectString.Append("   result                        AS   [试验结果],");
            productTestSelectString.Append("   mark                          AS   [是否合格],");
            productTestSelectString.Append("   frequency                     AS   [实际频率],");
            productTestSelectString.Append("   productTestAccount.remark     AS   [备注],");
            productTestSelectString.Append("   productTestAccount.inputDate  AS   [录入时间],");
            productTestSelectString.Append("   productTestAccount.inputMan   AS   [录入人员]");
            productTestSelectString.Append(" FROM productTestAccount,product,productKind,productName,productModel");
            productTestSelectString.Append(" WHERE productTestAccount.pId = product.id");
            productTestSelectString.Append(" AND product.pnId = productName.id");
            productTestSelectString.Append(" AND product.pmId = productModel.id");
            productTestSelectString.Append(" AND productName.pkId = productKind.id");
            productTestSelectString.Append(" AND accountDate >= '{0}'");
            productTestSelectString.Append(" AND accountDate < '{1}'");
            productTestSelectString.Append(" ORDER BY [产品种类],[产品名称],[产品规格],[试验编号]");

            //产品检测台帐SQL:insert
            productTestInsertString.Append("INSERT INTO productTestAccount");
            productTestInsertString.Append(" (pId,dayQuantity,totalQuantity,name,no,result,mark,man,frequency,inputDate,inputMan,accountDate,remark) ");
            productTestInsertString.Append("VALUES ");
            productTestInsertString.Append("({0},{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}','{12}')");

            //产品检测台帐SQL:delete
            productTestDeleteString.Append("DELETE FROM productTestAccount ");
            productTestDeleteString.Append("WHERE id = {0}");

            //产品检测台帐SQL:update
            productTestUpdateString.Append(" UPDATE productTestAccount ");
            productTestUpdateString.Append(" SET");
            productTestUpdateString.Append("    pId = {0},");
            productTestUpdateString.Append("    result = '{1}',");
            productTestUpdateString.Append("    mark = '{2}',");
            productTestUpdateString.Append("    remark = '{3}'");
            productTestUpdateString.Append(" WHERE id = {4}");
            //pId,result,guideline,mark,remark
        }

        //产品：按日期查询“产品台帐”
        public DataTable GetProductTestAccount(DateTime dt)
        {
            string selectString = string.Format(productTestSelectString.ToString(), dt, dt.AddDays(1));
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }
        
        //产品：利用DataTable内记录的状态生成数据库操作SQL语句
        private ArrayList ProductTableToSQLArray(DataTable table)
        {
            ArrayList list = new ArrayList();
            string sqlString = null;

            foreach (DataRow row in table.Rows)
            {
                switch (row.RowState)
                {
                    case DataRowState.Added:
                        sqlString = string.Format(productTestInsertString.ToString()
                           , row["pId"].ToString(), row["当日产量"].ToString(), row["累计产量"].ToString(), row["试验名称"].ToString()
                           , row["试验编号"].ToString(), row["试验结果"].ToString(), row["是否合格"].ToString(), row["试验员"].ToString()
                           , row["实际频率"].ToString(), "getdate()", row["录入人员"].ToString(), row["台帐日期"].ToString(), row["备注"].ToString());
                        break;
                    case DataRowState.Modified:
                        sqlString = string.Format(productTestUpdateString.ToString()
                            , row["pId"].ToString(), row["试验结果"].ToString(), row["是否合格"].ToString(), row["备注"].ToString(), row["id"].ToString());
                        break;
                    //case DataRowState.Deleted:
                    //    sqlString = string.Format(productTestDeleteString.ToString(), row["id"].ToString()); 
                    //    break;
                    default:
                        break;
                }

                list.Add(sqlString);
            }

            return list;
        }

        //产品：保存“产品试验台帐”
        public void SaveProductTestAccount(DataTable productTable)
        {
            //获得批量更新的SQL语句
            ArrayList sqlList = ProductTableToSQLArray(productTable);

            //执行批量更新
            sqlHelper.ExecuteTransaction(sqlList);

            productTable.AcceptChanges();
        }

        //产品：获得指定产品的指定天的"当日产量"
        public double GetProductDayQuantity(long pId, DateTime today)
        {
            DataTable table;
            string dayQuantity =
                "SELECT sum(consignmentNote.suttle) "
                + "FROM consignmentNote,invoice "
                + "WHERE consignmentNote.iId = invoice.id "
                + "AND invoice.pId = {0} "
                + "AND consignmentNote.inputDate >= '{1}' "
                + "AND consignmentNote.inputDate < '{2}'";

            string selectString = string.Format(dayQuantity.ToString(), pId, today, today.AddDays(1));

            table = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            double quantity = 0;
            string temp = table.Rows[0][0].ToString();
            if (temp != "")
            {
                quantity = Convert.ToDouble(temp);
            }

            return quantity;

        }

        //产品：获得指定产品的“累计产量”
        public double GetProductTotalQuantity(long pId)
        {
            DataTable table;
            string dayQuantity =
                "SELECT sum(consignmentNote.suttle) "
                + "FROM consignmentNote,invoice "
                + "WHERE consignmentNote.iId = invoice.id "
                + "AND invoice.pId = {0} ";


            string selectString = string.Format(dayQuantity.ToString(), pId);

            table = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            double quantity = 0;
            string temp = table.Rows[0][0].ToString();
            if (temp != "")
            {
                quantity = Convert.ToDouble(temp);
            }

            return quantity;
        }

        //产品：获得指定产品，某个日期（台帐日期）之前（包括当日）的所做相同试验的次数
        private int GetProductTestCount(long pId, string testName, string accountDate)
        {
            DataTable table;
            string testCountString =
                "SELECT count(*) "
                + "FROM productTestAccount "
                + "WHERE pId = {0} "
                + "AND [name] = '{1}' "
                + "AND accountDate <= '{2}' "
                + "GROUP BY [name]";


            string selectString = string.Format(testCountString, pId, testName, accountDate);

            table = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            int Count = 0;
            if (table.Rows.Count > 0)
            {
                string temp = table.Rows[0][0].ToString();
                if (temp != "")
                {
                    Count = Convert.ToInt32(temp);
                }
            }

            return Count;
        }

        //产品：获得指定产品，某个日期（台帐日期）之前（包括当日）的所做相同试验的频率 = 次数/吨
        public string GetProductFrequency(long pId, string testName, string accountDate)
        {
            double totalQuantity = GetProductTotalQuantity(pId);
            int testCount = GetProductTestCount(pId, testName, accountDate);


            string frenquencyString = "无";
            if (testCount != 0)
            {
                //四舍五入
                double frequency = Math.Round(totalQuantity / testCount + 0.1);
                frenquencyString = "1次/" + frequency.ToString() + "吨";
            }

            return frenquencyString;
        }


        #endregion

    }
    

    #endregion



    /*
    * 类名称：KindNameModel
    * 类功能描述：种类、名称、规格三表查询
    *
    * 创建人：关启学
    * 创建时间：2009-02-28
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

    #region //种类、名称、规格三表查询
    class KindNameModel
    {
        //
        private SqlHelper sqlHelper = new SqlHelper();
        

        /// <summary>
        /// 材料
        /// </summary>
        //获得材料种类表
        public DataTable GetMaterialKind()
        {
            string selectString = "SELECT id, sort FROM materialKind";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //获得材料名称表
        public DataTable GetMaterialName(long mkId)
        {
            string selectString = "SELECT id, name FROM materialName WHERE mkId = " + mkId;
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }
 
        //获得材料规格表
        public DataTable GetMaterialModel(long mnId)
        {
            string selectString = "SELECT materialModel.id AS [id], materialModel.model AS [model] FROM materialModel, material WHERE materialModel.id = material.mmId AND material.mnId = " + mnId;
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //获得材料id，根据材料名称id和材料规格id
        public long GetMaterialId(long mnId, long mmId)
        {
            string selectString = "SELECT id FROM material WHERE mnId = " + mnId + " AND mmId = " + mmId;
            DataTable table = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            long mId = 0;//表示：没查到
            if (table.Rows.Count != 0)
            {
                mId = Convert.ToInt64(table.Rows[0]["id"].ToString());
            }
            return mId;
        }


        /// <summary>
        /// 产品
        /// </summary>
        //获得材产品类表
        public DataTable GetProductKind()
        {
            string selectString = "SELECT id, sort FROM productKind";
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //获得产品名称表
        public DataTable GetProductName(long pkId)
        {
            string selectString = "SELECT id, name FROM productName WHERE pkId = " + pkId;
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //获得产品规格表
        public DataTable GetProductModel(long pnId)
        {
            string selectString = "SELECT productModel.id AS [id], productModel.model AS [model] FROM productModel, product WHERE productModel.id = product.pmId AND product.pnId = " + pnId;
            return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
        }

        //获得产品id，根据产品名称id和产品规格id
        public long GetProductId(long pnId, long pmId)
        {
            string selectString = "SELECT id FROM product WHERE pnId = " + pnId + " AND pmId = " + pmId;
            DataTable table = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

            long pId = 0;//表示：没查到
            if (table.Rows.Count != 0)
            {
                pId = Convert.ToInt64(table.Rows[0]["id"].ToString());
            }
            return pId;
        }


    }

    #endregion





}
