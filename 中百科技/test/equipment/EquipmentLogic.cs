using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DasherStation.common;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace DasherStation.equipment
{
    class EquipmentLogic
    {
        SqlHelper sqlHelperObj = new SqlHelper();

        DataSet ds = new DataSet();

        EquipmentDB equipmentDb = new EquipmentDB();

        EquipmentServiceClass ESClass = new EquipmentServiceClass();

        SparePartBasicInfoClass SPBIClass = new SparePartBasicInfoClass();


        #region//设备维修保养记录

        /*
        * 方法名称：FrmEquipmentServiceInitialCbxENO
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：200903020
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void FrmEquipmentServiceInitialCbxENO(ComboBox cbx)
        {
            ds = equipmentDb.FrmEquipmentServiceInitialCbxENO();
            cbx.DataSource = ds.Tables[0];
        }


        /*
        * 方法名称：FrmEquipmentServiceLoadEquipNo
        * 方法功能描述：根据选择的设备编号联动查询设备信息
        *
        * 创建人：夏阳明
        * 创建时间：200903020
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void FrmEquipmentServiceLoadEquipNo(string equipNO, TextBox txtSort, TextBox txtName, TextBox txtModel)
        {
            ds = equipmentDb.FrmEquipmentServiceLoadEquipNo(equipNO);
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtSort.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            if (ds.Tables[1].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[1].Rows[0][0].ToString();
            }
            if (ds.Tables[2].Rows.Count != 0)
            {
                txtModel.Text = ds.Tables[2].Rows[0][0].ToString();
            }
        }

        /*
        * 方法名称：FrmEquipmentServiceSearchDasherName
        * 方法功能描述：查询单位名称
        *
        * 创建人：夏阳明
        * 创建时间：200903020
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string FrmEquipmentServiceSearchDasherName()
        {
            string dasherName = "";
            ds = equipmentDb.FrmEquipmentServiceSearchDasherName();
            if (ds.Tables[0].Rows.Count != 0)
            {
                dasherName = ds.Tables[0].Rows[0][0].ToString().Trim();
            }

            return dasherName;
        }

        /*
        * 方法名称：CreatTable
        * 方法功能描述：生产默认的table容器
        *
        * 创建人：夏阳明
        * 创建时间：200903020
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable CreatTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("no");
            dt.Columns.Add("sort");
            dt.Columns.Add("name");
            dt.Columns.Add("model");
            dt.Columns.Add("expenses");
            dt.Columns.Add("serviceKind");
            dt.Columns.Add("timeConsuming");
            dt.Columns.Add("serviceDate");
            dt.Columns.Add("finishDate");
            dt.Columns.Add("interval");
            dt.Columns.Add("fno");
            dt.Columns.Add("serviceExplain");
            dt.Columns.Add("changeAccessory");
            dt.Columns.Add("attemptRunExplain");
            dt.Columns.Add("testResult");
            dt.Columns.Add("inputDate");
 //           dt.Columns.Add("dasherName");
            dt.Columns.Add("inputMan");

            return dt;
        }
        /*
       * 方法名称：FrmEquipmentServiceSaveAll
       * 方法功能描述：保存到数据库
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
            return equipmentDb.FrmEquipmentServiceSaveAll(list);
        }

        /*
       * 方法名称：FrmEquipmentServiceAllInfo
       * 方法功能描述：查询
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
            return equipmentDb.FrmEquipmentServiceAllInfo(strWhere);
        }

        #endregion

        #region//设备加油记录

        /*
       * 方法名称：FrmEquipmentFillOilAllInfo
       * 方法功能描述：查询
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
            return equipmentDb.FrmEquipmentFillOilAllInfo(strWhere);
        }

        /*
       * 方法名称：FrmEquipmentServiceInitialCbxFillOilMan
       * 方法功能描述：给Combobox赋值
       *
       * 创建人：夏阳明
       * 创建时间：200903021
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void FrmEquipmentServiceInitialCbxFillOilMan(ComboBox cbx)
        {
            ds = equipmentDb.FrmEquipmentServiceInitialCbxFillOilMan();
            cbx.DataSource = ds.Tables[0];
        }

        /*
       * 方法名称：FrmEquipmentFillOilSaveAll
       * 方法功能描述：保存到数据库
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
            return equipmentDb.FrmEquipmentFillOilSaveAll(list);
        }

        /*
       * 方法名称：FrmEquipmentFillOilCreatTable
       * 方法功能描述：生产默认的table容器
       *
       * 创建人：夏阳明
       * 创建时间：200903021
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable FrmEquipmentFillOilCreatTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("no");
            dt.Columns.Add("sort");
            dt.Columns.Add("name");
            dt.Columns.Add("model");
            dt.Columns.Add("fillOilDate");
            dt.Columns.Add("Name1");
            dt.Columns.Add("Model1");
            dt.Columns.Add("quantity");
            dt.Columns.Add("unit");
            dt.Columns.Add("sum");
            dt.Columns.Add("unitPrice");
            dt.Columns.Add("fillOilMan");
            dt.Columns.Add("fno");
            dt.Columns.Add("inputDate");
//            dt.Columns.Add("dasherName");
            dt.Columns.Add("inputMan");
            dt.Columns.Add("remark");
            dt.Columns.Add("mId");

            return dt;
        }

        /*
       * 方法名称：FrmEquipmentFillOilGetMid
       * 方法功能描述：查询
       *
       * 创建人：夏阳明
       * 创建时间：20090409
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public int FrmEquipmentFillOilGetMid(string mnid,string mmid)
        {
            int id;

            id = int.Parse((equipmentDb.FrmEquipmentFillOilGetMid(mnid, mmid)).Tables[0].Rows[0][0].ToString());

            return id;
        }

        #endregion

        #region//备品备件基本信息

        /*
       * 方法名称：FrmSparePartBasicInfoCreatTable
       * 方法功能描述：生产默认的table容器
       *
       * 创建人：夏阳明
       * 创建时间：200903022
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable FrmSparePartBasicInfoCreatTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("no");
            dt.Columns.Add("sort");
            dt.Columns.Add("name");
            dt.Columns.Add("model");
            dt.Columns.Add("maxStock");
            dt.Columns.Add("minStock");
            dt.Columns.Add("unit");
            dt.Columns.Add("inputDate");
            dt.Columns.Add("inputMan");

            return dt;
        }

        /*
      * 方法名称：FrmSparePartBasicInfoAllInfo
      * 方法功能描述：查询
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
            return equipmentDb.FrmSparePartBasicInfoAllInfo(strWhere);
        }

        /*
      * 方法名称：FrmSparePartBasicInfoSaveAll
      * 方法功能描述：保存到数据库
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
            return equipmentDb.FrmSparePartBasicInfoSaveAll(list);
        }

        /*
        * 方法名称：FrmSparePartBasicInfoInitialSort
        * 方法功能描述：给Combobox赋值
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
            ds = equipmentDb.FrmSparePartBasicInfoInitialSort();
            return ds;
        }

        #endregion

        #region//新建领料单

        /*
        * 方法名称：FrmSparePartClaimDetailLoadEquipNo
        * 方法功能描述：根据选择的备件编号联动查询备件信息
        *
        * 创建人：夏阳明
        * 创建时间：20090323
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void FrmSparePartClaimDetailLoadEquipNo(string equipNO, TextBox txtSort, TextBox txtName, TextBox txtModel, TextBox txtUnit, TextBox txtUnitPrice, TextBox txtStockQuantity)
        {
            ds = equipmentDb.FrmSparePartClaimDetailLoadEquipNo(equipNO);
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtSort.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            if (ds.Tables[1].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[1].Rows[0][0].ToString();
            }
            if (ds.Tables[2].Rows.Count != 0)
            {
                txtModel.Text = ds.Tables[2].Rows[0][0].ToString();
            }
            if (ds.Tables[3].Rows.Count != 0)
            {
                txtUnit.Text = ds.Tables[3].Rows[0][0].ToString();
            }
            if (ds.Tables[4].Rows.Count != 0)
            {
                txtUnitPrice.Text = ds.Tables[4].Rows[0][0].ToString();
            }
            if (ds.Tables[5].Rows.Count != 0)
            {
                txtStockQuantity.Text = ds.Tables[5].Rows[0][0].ToString();
            }
        }

        /*
       * 方法名称：FrmSparePartClaimDetailInitialCbxNo
       * 方法功能描述：给Combobox赋值
       *
       * 创建人：夏阳明
       * 创建时间：20090323
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void FrmSparePartClaimDetailInitialCbxNo(ComboBox cbx)
        {
            ds = equipmentDb.FrmSparePartClaimDetailInitialCbxNo();
            cbx.DataSource = ds.Tables[0];
        }

        /*
       * 方法名称：FrmSparePartClaimDetailInitialCbxDrawDepartment
       * 方法功能描述：给Combobox赋值
       *
       * 创建人：夏阳明
       * 创建时间：20090323
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void FrmSparePartClaimDetailInitialCbxDrawDepartment(ComboBox cbx)
        {
            ds = equipmentDb.FrmSparePartClaimDetailInitialCbxDrawDepartment();
            cbx.DataSource = ds.Tables[0];
        }

        /*
      * 方法名称：FrmSparePartClaimDetailInitialCbxENo
      * 方法功能描述：给Combobox赋值
      *
      * 创建人：夏阳明
      * 创建时间：20090323
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public void FrmSparePartClaimDetailInitialCbxENo(ComboBox cbx)
        {
            ds = equipmentDb.FrmSparePartClaimDetailInitialCbxENo();
            cbx.DataSource = ds.Tables[0];
        }

        /*
      * 方法名称：FrmSparePartClaimDetailSearchEName
      * 方法功能描述：根据设备编号查找名称
      *
      * 创建人：夏阳明
      * 创建时间：20090323
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public void FrmSparePartClaimDetailSearchEName(string ENo,TextBox txt)
        {
            ds = equipmentDb.FrmSparePartClaimDetailSearchEName(ENo);
            txt.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        /*
    * 方法名称：FrmSparePartClaimDetailAddNew
    * 方法功能描述：给新建领料单的datagridview添加行
    *
    * 创建人：夏阳明
    * 创建时间：20090323
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

        public void FrmSparePartClaimDetailAddNew(ClaimSparePartBillDetailClass CSPBDClass, DataTable dt)
        {
            DataRow dr = dt.NewRow();

            dr["no"] = CSPBDClass.No;
            dr["sort"] = CSPBDClass.Sort;
            dr["name"] = CSPBDClass.Name;
            dr["model"] = CSPBDClass.Model;
            dr["unit"] = CSPBDClass.Unit;
            dr["unitPrice"] = CSPBDClass.UnitPrice;
            dr["count"] = CSPBDClass.Count;
            dr["sum"] = CSPBDClass.Sum;
            dr["inputDate"] = CSPBDClass.InputDate;
            dr["inputMan"] = CSPBDClass.InputMan;

            dt.Rows.Add(dr);
        }

        /*
    * 方法名称：SaveClaimSparePartAdd
    * 方法功能描述：同时将领料单主表和明细表保存到数据库中的方法 插入到两个表中
    *
    * 创建人：夏阳明
    * 创建时间：20090324
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

        public int SaveClaimSparePartAdd(ClaimSparePartBillClass CSPBClass, List<ClaimSparePartBillDetailClass> list)
        {
            int id;

            ArrayList sqllist = new ArrayList();

            sqllist.Add(equipmentDb.GetInsertSqlps(CSPBClass));

            foreach (ClaimSparePartBillDetailClass CSPBDClass in list)
            {
                sqllist.Add(equipmentDb.GetInsertSqlpsd(CSPBDClass));
            }
            ds = sqlHelperObj.QueryForDateSet(sqllist);

            id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id;
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
            equipmentDb.SumAllDetail(id);
        }

        /*
      * 方法名称：FrmSparePartClaimDetailInitialCbxFileNo
      * 方法功能描述：给Combobox赋值
      *
      * 创建人：夏阳明
      * 创建时间：20090324
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public void FrmSparePartClaimDetailInitialCbxFileNo(ComboBox cbx)
        {
            ds = equipmentDb.FrmSparePartClaimDetailInitialCbxFileNo();
            cbx.DataSource = ds.Tables[0];
        }

        #endregion

        #region//领料单查询

        /*
       * 方法名称：FrmClaimSparePartBillAllInfo
       * 方法功能描述：查询
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
            return equipmentDb.FrmClaimSparePartBillAllInfo(strWhere);
        }

        /*
      * 方法名称：FrmClaimSparePartBillSearchDetailInfo
      * 方法功能描述：查询
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
            return equipmentDb.FrmClaimSparePartBillSearchDetailInfo(id);
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
        public bool DeleteFrmClaimSparePartBill(List<long> list)
        {
            return equipmentDb.DeleteFrmClaimSparePartBill(list);
        }

        #endregion

        #region//新建出库单

        /*
      * 方法名称：FrmSparePartOutStockDetailInitialCbxDrawNo
      * 方法功能描述：给Combobox赋值
      *
      * 创建人：夏阳明
      * 创建时间：20090324
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public void FrmSparePartOutStockDetailInitialCbxDrawNo(ComboBox cbx)
        {
            ds = equipmentDb.FrmSparePartOutStockDetailInitialCbxDrawNo();
            cbx.DataSource = ds.Tables[0];
        }

        /*
       * 方法名称：FrmSparePartOutStockDetailLoadDrawInfo
       * 方法功能描述：根据选择的备件编号联动查询备件信息
       *
       * 创建人：夏阳明
       * 创建时间：20090324
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void FrmSparePartOutStockDetailLoadDrawInfo(int DrawNo, TextBox txtDrawMan, TextBox txtDept, TextBox txtDrawDate, TextBox txtEquiNo, TextBox txtEName)
        {
            ds = equipmentDb.FrmSparePartOutStockDetailLoadDrawInfo(DrawNo);
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtDrawMan.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            if (ds.Tables[1].Rows.Count != 0)
            {
                txtDept.Text = ds.Tables[1].Rows[0][0].ToString();
            }
            if (ds.Tables[2].Rows.Count != 0)
            {
                txtDrawDate.Text = ds.Tables[2].Rows[0][0].ToString();
            }
            if (ds.Tables[3].Rows.Count != 0)
            {
                txtEquiNo.Text = ds.Tables[3].Rows[0][0].ToString();
            }
            if (ds.Tables[4].Rows.Count != 0)
            {
                txtEName.Text = ds.Tables[4].Rows[0][0].ToString();
            }
            
        }

        /*
   * 方法名称：FrmSparePartOutStockDetailAddNew
   * 方法功能描述：给新建领料单的datagridview添加行
   *
   * 创建人：夏阳明
   * 创建时间：20090325
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */

        public void FrmSparePartOutStockDetailAddNew(OutStockBillDetailClass OSBDClass, DataTable dt)
        {
            DataRow dr = dt.NewRow();

            dr["no"] = OSBDClass.No;
            dr["sort"] = OSBDClass.Sort;
            dr["name"] = OSBDClass.Name;
            dr["model"] = OSBDClass.Model;
            dr["unit"] = OSBDClass.Unit;
            //dr["unitPrice"] = OSBDClass.UnitPrice;
            dr["count"] = OSBDClass.Count;
            dr["sum"] = OSBDClass.Sum;
            dr["inputDate"] = OSBDClass.InputDate;
            dr["inputMan"] = OSBDClass.InputMan;

            dt.Rows.Add(dr);
        }


        /*
    * 方法名称：SaveOutStockBill
    * 方法功能描述：同时将出库单主表和明细表保存到数据库中的方法 插入到两个表中
    *
    * 创建人：夏阳明
    * 创建时间：20090325
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

        public int SaveOutStockBill(OutStockClass OSClass, List<OutStockBillDetailClass> list,int id)
        {
            int id1;

            ArrayList sqllist = new ArrayList();

            sqllist.Add(equipmentDb.GetOSInsertSqlps(OSClass,id));

            foreach (OutStockBillDetailClass OSBDClass in list)
            {
                sqllist.Add(equipmentDb.GetOSBDInsertSqlpsd(OSBDClass));
            }
            ds = sqlHelperObj.QueryForDateSet(sqllist);

            id1 = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id1;
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
            equipmentDb.SumOutStockAllDetail(id);
        }

        /*
       * 方法名称：FrmSparePartOutStockDetailInitialCbxNo
       * 方法功能描述：给Combobox赋值
       *
       * 创建人：夏阳明
       * 创建时间：20090325
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void FrmSparePartOutStockDetailInitialCbxNo(ComboBox cbx,int id)
        {
            ds = equipmentDb.FrmSparePartOutStockDetailInitialCbxNo(id);
            cbx.DataSource = ds.Tables[0];
        }

        /*
       * 方法名称：FrmSparePartOutStockDetailLoadEquipNo
       * 方法功能描述：根据选择的备件编号联动查询备件信息
       *
       * 创建人：夏阳明
       * 创建时间：20090325
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void FrmSparePartOutStockDetailLoadEquipNo(string equipNO, TextBox txtSort, TextBox txtName, TextBox txtModel, TextBox txtUnit,TextBox txtDrawQuantity,int id,TextBox txtStockQuantity)
        {
            ds = equipmentDb.FrmSparePartOutStockDetailLoadEquipNo(equipNO,id);
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtSort.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            if (ds.Tables[1].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[1].Rows[0][0].ToString();
            }
            if (ds.Tables[2].Rows.Count != 0)
            {
                txtModel.Text = ds.Tables[2].Rows[0][0].ToString();
            }
            if (ds.Tables[3].Rows.Count != 0)
            {
                txtUnit.Text = ds.Tables[3].Rows[0][0].ToString();
            }
            //if (ds.Tables[4].Rows.Count != 0)
            //{
            //    txtUnitPrice.Text = ds.Tables[4].Rows[0][0].ToString();
            //}
            if (ds.Tables[4].Rows.Count != 0)
            {
                txtDrawQuantity.Text = ds.Tables[4].Rows[0][0].ToString();
            }
            if (ds.Tables[5].Rows.Count != 0)
            {
                txtStockQuantity.Text = ds.Tables[5].Rows[0][0].ToString();
            }
        }

        /*
      * 方法名称：FrmSparePartClaimDetailInitialCbxStoreKeeper
      * 方法功能描述：给Combobox赋值
      *
      * 创建人：夏阳明
      * 创建时间：20090401
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public void FrmSparePartClaimDetailInitialCbxStoreKeeper(ComboBox cbx)
        {
            ds = equipmentDb.FrmSparePartClaimDetailInitialCbxStoreKeeper();
            cbx.DataSource = ds.Tables[0];
        }

        #endregion

        #region//出库单查询

        /*
       * 方法名称：FrmFrmSparePartOutAllInfo
       * 方法功能描述：查询
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
            return equipmentDb.FrmFrmSparePartOutAllInfo(strWhere);
        }

        /*
     * 方法名称：FrmFrmSparePartOutSearchDetailInfo
     * 方法功能描述：查询
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
            return equipmentDb.FrmFrmSparePartOutSearchDetailInfo(id);
        }

        /*
     * 方法名称：DeleteFrmFrmSparePartOut
     * 方法功能描述：删除所选领料单及明细
     *
     * 创建人：夏阳明
     * 创建时间：20090325
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool DeleteFrmFrmSparePartOut(List<long> list)
        {
            return equipmentDb.DeleteFrmFrmSparePartOut(list);
        }

        #endregion

        #region//新建退库单

        /*
      * 方法名称：FrmSparePartOutStockRefundDetailInitialCbxOutNo
      * 方法功能描述：给Combobox赋值
      *
      * 创建人：夏阳明
      * 创建时间：20090326
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public void FrmSparePartOutStockRefundDetailInitialCbxOutNo(ComboBox cbx)
        {
            ds = equipmentDb.FrmSparePartOutStockRefundDetailInitialCbxOutNo();
            cbx.DataSource = ds.Tables[0];
        }

        /*
       * 方法名称：FrmSparePartOutStockRefundDetailLoadOutNo
       * 方法功能描述：根据选择的出库单号联动查询出库信息
       *
       * 创建人：夏阳明
       * 创建时间：20090326
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        //public void FrmSparePartOutStockRefundDetailLoadOutNo(int OutNo, TextBox txtFNo,TextBox txtDrawNo,TextBox txtDrawMan, TextBox txtDept, TextBox txtDrawDate, TextBox txtEquiNo, TextBox txtEName,TextBox txtOutDate)
        public void FrmSparePartOutStockRefundDetailLoadOutNo(int OutNo, TextBox txtDrawNo, TextBox txtDrawMan, TextBox txtDept, TextBox txtDrawDate, TextBox txtEquiNo, TextBox txtEName, TextBox txtOutDate)
        {
            ds = equipmentDb.FrmSparePartOutStockRefundDetailLoadOutNo(OutNo);

            //if (ds.Tables[0].Rows[0][0] != null)
            //{
            //    txtFNo.Text = ds.Tables[0].Rows[0][0].ToString();
            //}
            if (ds.Tables[0].Rows[0][0] != null)
            {
                txtDrawNo.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            if (ds.Tables[0].Rows[0][1] != null)
            {
                txtDrawMan.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            if (ds.Tables[0].Rows[0][2] != null)
            {
                txtDept.Text = ds.Tables[0].Rows[0][2].ToString();
            }
            if (ds.Tables[0].Rows[0][3] != null)
            {
                txtDrawDate.Text = ds.Tables[0].Rows[0][3].ToString();
            }
            if (ds.Tables[0].Rows[0][4] != null)
            {
                txtEquiNo.Text = ds.Tables[0].Rows[0][4].ToString();
            }
            if (ds.Tables[0].Rows[0][5] != null)
            {
                txtEName.Text = ds.Tables[0].Rows[0][5].ToString();
            }
            if (ds.Tables[0].Rows[0][6] != null)
            {
                txtOutDate.Text = ds.Tables[0].Rows[0][6].ToString();
            }

        }

        /*
      * 方法名称：FrmSparePartOutStockRefundDetailInitialCbxNo
      * 方法功能描述：给Combobox赋值
      *
      * 创建人：夏阳明
      * 创建时间：20090326
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public void FrmSparePartOutStockRefundDetailInitialCbxNo(ComboBox cbx, int id)
        {
            ds = equipmentDb.FrmSparePartOutStockRefundDetailInitialCbxNo(id);
            cbx.DataSource = ds.Tables[0];
        }

        /*
      * 方法名称：FrmSparePartOutStockRefundDetailLoadEquipNo
      * 方法功能描述：根据选择的备件编号联动查询备件信息
      *
      * 创建人：夏阳明
      * 创建时间：20090326
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public void FrmSparePartOutStockRefundDetailLoadEquipNo(string equipNO, TextBox txtSort, TextBox txtName, TextBox txtModel, TextBox txtUnit, TextBox txtUnitPrice, TextBox txtDrawQuantity, int id, TextBox txtOutCount)
        {
            ds = equipmentDb.FrmSparePartOutStockRefundDetailLoadEquipNo(equipNO, id);

            if (ds.Tables[0].Rows[0][0] != null)
            {
                txtSort.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            if (ds.Tables[0].Rows[0][1] != null)
            {
                txtName.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            if (ds.Tables[0].Rows[0][2] != null)
            {
                txtModel.Text = ds.Tables[0].Rows[0][2].ToString();
            }
            if (ds.Tables[0].Rows[0][3] != null)
            {
                txtUnit.Text = ds.Tables[0].Rows[0][3].ToString();
            }
            if (ds.Tables[0].Rows[0][4] != null)
            {
                txtUnitPrice.Text = ds.Tables[0].Rows[0][4].ToString();
            }
            if (ds.Tables[0].Rows[0][5] != null)
            {
                txtDrawQuantity.Text = ds.Tables[0].Rows[0][5].ToString();
            }
            if (ds.Tables[0].Rows[0][6] != null)
            {
                txtOutCount.Text = ds.Tables[0].Rows[0][6].ToString();
            }
        }

        /*
      * 方法名称：SearchDID2
      * 方法功能描述：查询文档id
      *
      * 创建人：夏阳明
      * 创建时间：20090326
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int SearchDID2(string no)
        {
            ds = equipmentDb.SearchDID2(no);

            return int.Parse(ds.Tables[0].Rows[0][0].ToString());
           
        }

        /*
  * 方法名称：FrmSparePartOutStockRefundDetailAddNew
  * 方法功能描述：给新建退库单的datagridview添加行
  *
  * 创建人：夏阳明
  * 创建时间：20090326
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */

        public void FrmSparePartOutStockRefundDetailAddNew(OutStockBillDetailClass OSBDClass, DataTable dt)
        {
            DataRow dr = dt.NewRow();

            dr["no"] = OSBDClass.No;
            dr["sort"] = OSBDClass.Sort;
            dr["name"] = OSBDClass.Name;
            dr["model"] = OSBDClass.Model;
            dr["unit"] = OSBDClass.Unit;
            dr["unitPrice"] = OSBDClass.UnitPrice;
            dr["count"] = OSBDClass.Count;
            dr["TCount"] = OSBDClass.TCount;
            dr["sum"] = OSBDClass.Sum;
            dr["inputDate"] = OSBDClass.InputDate;
            dr["inputMan"] = OSBDClass.InputMan;

            dt.Rows.Add(dr);
        }

        /*
    * 方法名称：SaveTOutStockBill
    * 方法功能描述：同时将出库单主表和明细表保存到数据库中的方法 插入到两个表中(退库)
    *
    * 创建人：夏阳明
    * 创建时间：20090325
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

        public int SaveTOutStockBill(OutStockClass OSClass, List<OutStockBillDetailClass> list,int OutId)
        {
            int id1;

            ArrayList sqllist = new ArrayList();

            sqllist.Add(equipmentDb.GetTOSInsertSqlps(OSClass, OutId));

            foreach (OutStockBillDetailClass OSBDClass in list)
            {
                sqllist.Add(equipmentDb.GetTOSBDInsertSqlpsd(OSBDClass));
            }
            ds = sqlHelperObj.QueryForDateSet(sqllist);

            id1 = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id1;
        }

        #endregion

        #region//退库单查询

        /*
       * 方法名称：FrmSparePartRefoundAllInfo
       * 方法功能描述：查询
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
            return equipmentDb.FrmSparePartRefoundAllInfo(strWhere);
        }

        /*
    * 方法名称：FrmSparePartRefoundSearchDetailInfo
    * 方法功能描述：查询
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
            return equipmentDb.FrmSparePartRefoundSearchDetailInfo(id);
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
        public bool DeleteFrmSparePartRefound(List<long> list)
        {
            return equipmentDb.DeleteFrmSparePartRefound(list);
        }


        #endregion

        #region//备品配件库存查询

        /*
        * 方法名称：FormFrmSparePartStockSearch
        * 方法功能描述：调用数据类方法获得用户查询所得数据集并绑定DataGridView
        *
        * 创建人：夏阳明
        * 创建时间：20090413
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void FormFrmSparePartStockSearch(string searchStr, string condition, int verifyBit, DataGridView dgv)
        {
            //verifyBit = 0:查询全部，verifyBit = 1：按条件查询
            ds = equipmentDb.FormFrmSparePartStockSearch(searchStr, condition, verifyBit);

            dgv.DataSource = ds.Tables[0];

        }


        #endregion
    }
}
