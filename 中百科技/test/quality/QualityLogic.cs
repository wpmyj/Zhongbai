using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using DasherStation.common;

namespace DasherStation.quality
{
    class QualityLogic
    {
        QualityDB qualityDb = new QualityDB();

        DataSet ds = new DataSet();

        TargetProportionDetailClass TPDObj = new TargetProportionDetailClass();

        ProduceProportionClass PPClass = new ProduceProportionClass();

        ProduceProportionDetailClass PPDClass = new ProduceProportionDetailClass();

        MaterialTestGuidelineClass MTGClass = new MaterialTestGuidelineClass();

        SqlHelper sqlHelperObj = new SqlHelper();

        private bool status;
        private bool statusName;
        private bool statusModel;

        int idName;
        int idModel;
        int idNo;

        #region //试验仪器台帐

        /*
        * 方法名称：InitialCbxId
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090224
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialCbxId(ComboBox cbx)
        {
            ds = qualityDb.InitialCbxId();
            cbx.DataSource = ds.Tables[0];
        }

        /*
       * 方法名称：InitialCbxUnitPrice
       * 方法功能描述：给Combobox赋值
       *
       * 创建人：夏阳明
       * 创建时间：20090226
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void InitialCbxUnitPrice(ComboBox cbx)
        {
            ds = qualityDb.InitialCbxUnitPrice();
            cbx.DataSource = ds.Tables[0];
        }

        /*
        * 方法名称：InitialCbxName
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090226
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialCbxName(ComboBox cbx)
        {
            ds = qualityDb.InitialCbxName();
            cbx.DataSource = ds.Tables[0];
        }

        /*
        * 方法名称：InitialCbxModel
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090226
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialCbxModel(ComboBox cbx)
        {
            ds = qualityDb.InitialCbxModel();
            cbx.DataSource = ds.Tables[0];
        }

        /*
       * 方法名称：InitialCbxCheckUnit
       * 方法功能描述：给Combobox赋值
       *
       * 创建人：夏阳明
       * 创建时间：20090226
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void InitialCbxCheckUnit(ComboBox cbx)
        {
            ds = qualityDb.InitialCbxCheckUnit();
            cbx.DataSource = ds.Tables[0];
        }

        /*
      * 方法名称：InitialCbxMaker
      * 方法功能描述：给Combobox赋值
      *
      * 创建人：夏阳明
      * 创建时间：20090226
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public void InitialCbxMaker(ComboBox cbx)
        {
            ds = qualityDb.InitialCbxMaker();
            cbx.DataSource = ds.Tables[0];
        }

        /*
        * 方法名称：FrmExaminationEquipmentDetailSearch
        * 方法功能描述： 初始化DataGridView
        *
        * 创建人：夏阳明
        * 创建时间：20090225
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */

        public void FrmExaminationEquipmentDetailSearch(string searchStr, int verifyBit, DataGridView dgv)
        {
            ds = qualityDb.FrmExaminationEquipmentDetailSearch(searchStr, verifyBit, dgv);
            dgv.DataSource = ds.Tables[0];
        }



        /*
       * 方法名称：FrmExaminationEquipmentDetailCheckId
       * 方法功能描述：调用数据类方法查询仪器记录中符合条件的编号返回bool值判断是否有该编号
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
            return qualityDb.FrmExaminationEquipmentDetailCheckId(id);
        }

        /*
      * 方法名称：FrmExaminationEquipmentDetailCheckUnitPrice
      * 方法功能描述：调用数据类方法查询仪器记录中符合条件的单价返回bool值判断是否有该单价
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
            return qualityDb.FrmExaminationEquipmentDetailCheckUnitPrice(unitPrice);
        }

        /*
      * 方法名称：FrmExaminationEquipmentDetailCheckName
      * 方法功能描述：调用数据类方法查询仪器记录中符合条件的仪器名称返回bool值判断是否有该仪器名称
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
            return qualityDb.FrmExaminationEquipmentDetailCheckName(name);
        }

        /*
     * 方法名称：FrmExaminationEquipmentDetailCheckModel
     * 方法功能描述：调用数据类方法查询仪器记录中符合条件的规格型号返回bool值判断是否有该规格型号
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
            return qualityDb.FrmExaminationEquipmentDetailCheckModel(model);
        }

        /*
     * 方法名称：FrmExaminationEquipmentDetailCheckMaker
     * 方法功能描述：调用数据类方法查询仪器记录中符合条件的生产厂家返回bool值判断是否有该厂家
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
            return qualityDb.FrmExaminationEquipmentDetailCheckMaker(maker);
        }

        /*
       * 方法名称：FrmExaminationEquipmentDetailSave
       * 方法功能描述：调用数据类方法将仪器信息插入到数据库中并返回bool值判断是否插入成功
       *
       * 创建人：夏阳明
       * 创建时间：20090226
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmExaminationEquipmentDetailSave(ExaminationEquipmentClass examinationEquipmentClass, string userName, DataGridView dgv,
                                                      int verifyBitId, int verifyBitName, int verifyBitModel, int verifyBitMaker)
        {
            #region
            //如果仪器名称和生产厂家组合数据库中已经有了，不执行插入名称表操作，只取id值
            if ((verifyBitName == 1) && (verifyBitMaker == 1))
            {
                idName = qualityDb.FrmExaminationEquipmentDetailLogicSearchName(examinationEquipmentClass);
            }
            //如果仪器规格，编号组合数据库中已经有了，不执行插入名称表操作，只取id值
            if ((verifyBitId == 1) && (verifyBitModel == 1))
            {
                idModel = qualityDb.FrmExaminationEquipmentDetailLogicSearchModel(examinationEquipmentClass);
            }
            //如果仪器名称或者生产厂家数据库中没有，就先往名称表插入一条记录，然后在查出对应的id值，用于插入对应表
            if ((verifyBitName != 1) || (verifyBitMaker != 1))
            {
                statusName = qualityDb.FrmExaminationEquipmentDetailLogicInsertName(examinationEquipmentClass, userName);
                idName = qualityDb.FrmExaminationEquipmentDetailLogicSearchName(examinationEquipmentClass);
            }
            //如果仪器型号和编号数据库中没有，就先往规格表插入一条记录，然后在查出对应的id值，用于插入对应表
            if ((verifyBitModel != 1) || (verifyBitId != 1))
            {
                statusName = qualityDb.FrmExaminationEquipmentDetailLogicInsertModel(examinationEquipmentClass, userName);
                idModel = qualityDb.FrmExaminationEquipmentDetailLogicSearchModel(examinationEquipmentClass);
            }
            //if ((verifyBitId != 1) && (verifyBitName != 1) && (verifyBitModel != 1))
            //{
            status = qualityDb.FrmExaminationEquipmentDetailSave(examinationEquipmentClass, userName,idName, idModel);
            //}
           
            if (status)
            {
                ds = qualityDb.FrmExaminationEquipmentDetailSearchAll();
                dgv.DataSource = ds.Tables[0];
                return true;
            }
            #endregion
            return false;
        }

        /*
       * 方法名称：FrmExaminationEquipmentDetailLogicUpdate
       * 方法功能描述：调用数据类方法将台帐信息更新到数据库中并返回bool值判断是否更新成功
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
                                                DataGridView dgv,int verifyBitId,int verifyBitName,int verifyBitModel,int id,int verifyBitMaker)
        {
            #region
            //如果仪器名称,生产厂家组合数据库中已经有了，不执行插入名称表操作，只取id值
            if ((verifyBitName == 1) && (verifyBitMaker == 1))
            {
                idName = qualityDb.FrmExaminationEquipmentDetailLogicSearchName(examinationEquipmentClass);
            }
            //如果仪器规格，编号组合数据库中已经有了，不执行插入名称表操作，只取id值
            if ((verifyBitId == 1) && (verifyBitModel == 1))
            {
                idModel = qualityDb.FrmExaminationEquipmentDetailLogicSearchModel(examinationEquipmentClass);
            }
            //如果仪器名称,生产厂家组合数据库中没有，就先往名称表插入一条名称记录，然后在查出对应的id值，用于更新对应表
            if ((verifyBitName != 1) || (verifyBitMaker != 1))
            {
                statusName = qualityDb.FrmExaminationEquipmentDetailLogicInsertName(examinationEquipmentClass, userName);
                idName = qualityDb.FrmExaminationEquipmentDetailLogicSearchName(examinationEquipmentClass);
            }
            //如果仪器型号和编号组合数据库中没有，就先往规格表插入一条记录，然后在查出对应的id值，用于更新对应表
            if ((verifyBitModel != 1) || (verifyBitId != 1))
            {
                statusName = qualityDb.FrmExaminationEquipmentDetailLogicInsertModel(examinationEquipmentClass, userName);
                idModel = qualityDb.FrmExaminationEquipmentDetailLogicSearchModel(examinationEquipmentClass);
            }


            status = qualityDb.FrmExaminationEquipmentDetailLogicUpdate(examinationEquipmentClass, userName, idName, idModel, id);

            if (status)
            {
                ds = qualityDb.FrmExaminationEquipmentDetailSearchAll();
                dgv.DataSource = ds.Tables[0];
                return true;
            }
            #endregion
            return false;
        }

        /*
       * 方法名称：FrmExaminationEquipmentDetailForDelete
       * 方法功能描述：调用数据类方法数据库中相应记录返回bool值判断是否更新成功
       *
       * 创建人：夏阳明
       * 创建时间：20090227
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmExaminationEquipmentDetailForDelete(int id, DataGridView dgv)
        {
            status = qualityDb.FrmExaminationEquipmentDetailForDelete(id);

            if (status)
            {
                ds = qualityDb.FrmExaminationEquipmentDetailSearchAll();
                dgv.DataSource = ds.Tables[0];
                return true;
            }

            return false;
        }

        /*
     * 方法名称：LoadInfo
     * 方法功能描述：根据选择的仪器编号联动查询备件信息
     *
     * 创建人：夏阳明
     * 创建时间：20090410
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public void LoadInfo(string id, ComboBox cbxName, ComboBox cbxModel, DateTimePicker dtpBuyDate, ComboBox cbxMaker, ComboBox cbxUnitPrice, TextBox txtDepreciationYear)
        {
            ds = qualityDb.LoadInfo(id);

            if (ds.Tables[0].Rows[0][0] != null)
            {
                cbxName.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            if (ds.Tables[0].Rows[0][1] != null)
            {
                cbxModel.Text = ds.Tables[0].Rows[0][1].ToString();
            }
            if (ds.Tables[0].Rows[0][2] != null)
            {
                dtpBuyDate.Value = DateTime.Parse(ds.Tables[0].Rows[0][2].ToString());
            }
            if (ds.Tables[0].Rows[0][3] != null)
            {
                cbxMaker.Text = ds.Tables[0].Rows[0][3].ToString();
            }
            if (ds.Tables[0].Rows[0][4] != null)
            {
                cbxUnitPrice.Text = ds.Tables[0].Rows[0][4].ToString();
            }
            if (ds.Tables[0].Rows[0][5] != null)
            {
                txtDepreciationYear.Text = ds.Tables[0].Rows[0][5].ToString();
            }
        }

        /*
        * 方法名称：FrmExaminationEquipmentDetailPrintSearch
        * 方法功能描述： 初始化DataGridView
        *
        * 创建人：夏阳明
        * 创建时间：20090415
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */

        public void FrmExaminationEquipmentDetailPrintSearch(DateTime dt, DataGridView dgv)
        {
            ds = qualityDb.FrmExaminationEquipmentDetailPrintSearch(dt);
            dgv.DataSource = ds.Tables[0];
        }

        #endregion

        #region //新建目标配合比

        /*
        * 方法名称：InitialcbxPsort
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090303
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialcbxPsort(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxPsort();
            cbx.DataSource = ds.Tables[0];
        }

        /*
        * 方法名称：InitialcbxProducer
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090303
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialcbxProducer(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxProducer();
            cbx.DataSource = ds.Tables[0];
        }

        /*
        * 方法名称：InitialcbxProducerPP
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090305
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialcbxProducerPP(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxProducerPP();
            cbx.DataSource = ds.Tables[0];
        }

        /*
       * 方法名称：InitialcbxKinds
       * 方法功能描述：给Combobox赋值
       *
       * 创建人：夏阳明
       * 创建时间：20090303
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void InitialcbxKinds(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxKinds();
            cbx.DataSource = ds.Tables[0];
        }

        /*
       * 方法名称：FrmMixtureRatioAddSearchDetail
       * 方法功能描述：查询目标配合比明细表，看对应配合比表是否有详细信息记录，如没有，删除主表记录
       *
       * 创建人：夏阳明
       * 创建时间：20090303
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmMixtureRatioAddSearchDetail(int id)
        {
            status = false;

            ds = qualityDb.FrmMixtureRatioAddSearchDetail(id);
            if(ds.Tables[0].Rows.Count == 0)
            {
                status = qualityDb.FrmMixtureRatioAddDeleteTargetProportion(id);
            }
            return status;
            
        }

        /*
      * 方法名称：FrmMixtureRatioAddNewTargetProportion
      * 方法功能描述：保存目标配合比概要信息记录
      *
      * 创建人：夏阳明
      * 创建时间：20090303
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmMixtureRatioAddNewTargetProportion(TargetProportionClass TPClass,int id,string userName)
        {
            status = qualityDb.FrmMixtureRatioAddNewTargetProportion(TPClass,id,userName);

            return status;

        }

        /*
      * 方法名称：FrmMixtureRatioAddSearchId
      * 方法功能描述：获取配合比概要信息记录id值
      *
      * 创建人：夏阳明
      * 创建时间：20090303
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int FrmMixtureRatioAddSearchId()
        {
            int id;

            ds = qualityDb.FrmMixtureRatioAddSearchId();

            id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id;

        }

        /*
       * 方法名称：FrmMixtureRatioAddSearchMaterialId
       * 方法功能描述：查询材料表中对应特定名称及型号的id
       *
       * 创建人：夏阳明
       * 创建时间：20090303
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public int FrmMixtureRatioAddSearchMaterialId(int idName,int idModel)
        {
            int id;

            ds = qualityDb.FrmMixtureRatioAddSearchMaterialId(idName, idModel);

            id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id;
        }

        /*
      * 方法名称：FrmMixtureRatioAddSearchMaterialProductId
      * 方法功能描述：查询材料表或产品表中对应特定名称及型号的id
      *
      * 创建人：夏阳明
      * 创建时间：200903018
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int FrmMixtureRatioAddSearchMaterialProductId(int idName, int idModel,int verifyBit)
        {
            int id;

            ds = qualityDb.FrmMixtureRatioAddSearchMaterialProductId(idName, idModel, verifyBit);

            id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id;
        }

        /*
       * 方法名称：FrmMixtureRatioAddNewTargetProportionDetail
       * 方法功能描述：将目标配合比详细信息插入数据库
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
            status = qualityDb.FrmMixtureRatioAddNewTargetProportionDetail(TPDetailClass, userName);

            return status;
        }

        /*
        * 方法名称：FrmMixtureRatioAddSearchAll
        * 方法功能描述： 初始化DataGridView
        *
        * 创建人：夏阳明
        * 创建时间：20090304
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */

        public void FrmMixtureRatioAddSearchAll(DataGridView dgv,int id)
        {
            ds = qualityDb.FrmMixtureRatioAddSearchAll(id);
            dgv.DataSource = ds.Tables[0];
        }

        /*
      * 方法名称：FrmMixtureRatioAddDelete
      * 方法功能描述：删除一条目标配合比明细
      *
      * 创建人：夏阳明
      * 创建时间：20090304
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmMixtureRatioAddDelete(int id, DataGridView dgv,int conId)
        {
            status = qualityDb.FrmMixtureRatioAddDelete(id);

            if (status)
            {
                ds = qualityDb.FrmMixtureRatioAddSearchAll(conId);
                dgv.DataSource = ds.Tables[0];
                return true;
            }

            return false;
        }

        /*
     * 方法名称：FrmMixtureRatioAddNew
     * 方法功能描述：给新建目标配合比明细表的datagridview添加行
     *
     * 创建人：夏阳明
     * 创建时间：20090304
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */

        public void FrmMixtureRatioAddNew(TargetProportionDetailClass TPDObj, DataTable dt,string Kinds,
                                             string Name, string Model)
        {
            DataRow dr = dt.NewRow();

            dr["id"] = TPDObj.Id;
            dr["sort"] = Kinds;
            dr["name"] = Name;
            dr["model"] = Model;
            dr["targetProportionValue"] = TPDObj.TargetProportionValue;
            dr["inputDate"] = TPDObj.InputDate;
            dr["inputMan"] = TPDObj.InputMan;
            dr["producer"] = TPDObj.Producer;
            dr["mId"] = TPDObj.MnmcId;
            dr["address"] = TPDObj.Address;
            dr["name1"] = TPDObj.Name;
            dr["Pid"] = TPDObj.PId;
            
            dt.Rows.Add(dr);
        }
        /*
     * 方法名称：SaveTargetProportionAdd
     * 方法功能描述：同时将目标配合比主表和明细表保存到数据库中的方法 插入到两个表中
     *
     * 创建人：夏阳明
     * 创建时间：20090304
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */

        public int SaveTargetProportionAdd(TargetProportionClass TPClass, List<TargetProportionDetailClass> list)
        {
            int id;

            ArrayList sqllist = new ArrayList();

            sqllist.Add(qualityDb.GetInsertSqlps(TPClass));

            foreach (TargetProportionDetailClass TPDClass in list)
            {
                sqllist.Add(qualityDb.GetInsertSqlpsd(TPDClass));
            }
            ds = sqlHelperObj.QueryForDateSet(sqllist);

            id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id;
        }

        /*
       * 方法名称：FrmMixtureRatioAddSearchPId
       * 方法功能描述：查询产品表中对应特定名称及型号的id
       *
       * 创建人：夏阳明
       * 创建时间：20090305
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public int FrmMixtureRatioAddSearchPId(int idName, int idModel)
        {
            int id;

            ds = qualityDb.FrmMixtureRatioAddSearchPId(idName, idModel);

            id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id;
        }


        /*
    * 方法名称：ProduceProportion
    * 方法功能描述：同时将生产配合比主表和明细表保存到数据库中的方法 插入到两个表中
    *
    * 创建人：夏阳明
    * 创建时间：20090305
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

        public int ProduceProportion(ProduceProportionClass PPClass, List<ProduceProportionDetailClass> list)
        {
            int id;

            ArrayList sqllist = new ArrayList();

            sqllist.Add(qualityDb.GetPPInsertSqlps(PPClass));

            foreach (ProduceProportionDetailClass PPDClass in list)
            {
                sqllist.Add(qualityDb.GetPPInsertSqlpsd(PPDClass));
            }
            ds = sqlHelperObj.QueryForDateSet(sqllist);

            id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id;
        }


        /*
       * 方法名称：InitialcbxAddress
       * 方法功能描述：给Combobox赋值
       *
       * 创建人：夏阳明
       * 创建时间：20090409
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void InitialcbxAddress(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxAddress();
            cbx.DataSource = ds.Tables[0];
        }


        /*
      * 方法名称：InitialcbxMaker
      * 方法功能描述：给Combobox赋值
      *
      * 创建人：夏阳明
      * 创建时间：20090409
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public void InitialcbxMaker(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxMaker();
            cbx.DataSource = ds.Tables[0];
        }

        /*
  * 方法名称：FrmMixtureRatioAddSearchDetailId
  * 方法功能描述：查询目标配合比明细表Id最大值
  *
  * 创建人：夏阳明
  * 创建时间：20090304
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */

        //public int FrmMixtureRatioAddSearchDetailId()
        //{
        //    int id;

        //    ds = qualityDb.FrmMixtureRatioAddSearchDetailId();

        //    id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + 1;

        //    return id;
        //}
        #endregion

        #region //乳化沥青配合比

        /*
        * 方法名称：InitialcbxRProducer
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090306
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialcbxRProducer(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxRProducer();
            cbx.DataSource = ds.Tables[0];
        }
        
        
        
        /*
       * 方法名称：FrmGYMixtureRatioSearchPId
       * 方法功能描述：查询产品表中对应特定名称及型号的id
       *
       * 创建人：夏阳明
       * 创建时间：20090306
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public int FrmGYMixtureRatioSearchPId(int idName, int idModel)
        {
            int id;

            ds = qualityDb.FrmGYMixtureRatioSearchPId(idName, idModel);

            id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id;
        }

        /*
     * 方法名称：SaveProportionAdd
     * 方法功能描述：同时将配合比主表和明细表保存到数据库中的方法 插入到两个表中
     *
     * 创建人：夏阳明
     * 创建时间：20090306
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */

        public int SaveProportionAdd(ProportionClass PClass, List<ProportionDetailClass> list)
        {
            int id;

            ArrayList sqllist = new ArrayList();

            sqllist.Add(qualityDb.GetPInsertSqlps(PClass));

            foreach (ProportionDetailClass PDClass in list)
            {
                sqllist.Add(qualityDb.GetPInsertSqlpsd(PDClass));
            }

            ds = sqlHelperObj.QueryForDateSet(sqllist);

            id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            return id;
        }


        /*
    * 方法名称：FrmGYMRatioAddNew
    * 方法功能描述：给新建配合比明细表的datagridview添加行
    *
    * 创建人：夏阳明
    * 创建时间：20090306
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

        public void FrmGYMRatioAddNew(ProportionDetailClass PDClass, DataTable dt, string Kinds,
                                             string Name, string Model)
        {
            DataRow dr = dt.NewRow();

            dr["id"] = PDClass.Id;
            dr["sort"] = Kinds;
            dr["name"] = Name;
            dr["model"] = Model;
            dr["proportionValue"] = PDClass.ProportionValue;
            dr["address"] = PDClass.Address;
            dr["name1"] = PDClass.Name;
            dr["inputDate"] = PDClass.InputDate;
            dr["inputMan"] = PDClass.InputMan;
            dr["producer"] = PDClass.Producer;
            dr["mId"] = PDClass.MId;
            dr["Ppid"] = PDClass.PpId;

            dt.Rows.Add(dr);
        }

        #endregion

        #region //配合比查询

        /*
        * 方法名称：FrmMixtureRatioSearch
        * 方法功能描述：调用数据类方法获得用户查询所得数据集并绑定DataGridView
        *
        * 创建人：夏阳明
         * * 创建时间：20090305
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void FrmMixtureRatioSearch(string searchStr, string condition, int verifyBit, DataGridView dgvT, 
                                                           DataGridView dgvP, DataGridView dgvR, DataGridView dgvG)
        {
            //verifyBit = 0:查询全部，verifyBit = 1：按条件查询

            if(verifyBit == 0)
            {
                ds = qualityDb.FrmMixtureRatioSearch(searchStr, condition, verifyBit);

                dgvT.DataSource = ds.Tables[0];
                dgvP.DataSource = ds.Tables[1];
                dgvR.DataSource = ds.Tables[2];
                dgvG.DataSource = ds.Tables[3];
            }
            if(verifyBit == 1)
            {
                ds = qualityDb.FrmMixtureRatioSearch(searchStr, condition, verifyBit);
                
                dgvT.DataSource = ds.Tables[0];
                dgvP.DataSource = ds.Tables[1];
                dgvR.DataSource = ds.Tables[2];
                dgvG.DataSource = ds.Tables[3];
            }

        }

        /*
       * 方法名称：FrmMixtureRatioDeleteT
       * 方法功能描述：调用数据类方法数据库中相应记录返回bool值判断是否更新成功
       *
       * 创建人：夏阳明
       * 创建时间：20090306
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmMixtureRatioDeleteT(int id, DataGridView dgv)
        {
            status = qualityDb.FrmMixtureRatioDeleteT(id);

            if (status)
            {
                ds = qualityDb.FrmMixtureRatioSearch("", "", 0);
                dgv.DataSource = ds.Tables[0];
                return true;
            }

            return false;
        }


        /*
       * 方法名称：FrmMixtureRatioDeleteP
       * 方法功能描述：调用数据类方法数据库中相应记录返回bool值判断是否更新成功
       *
       * 创建人：夏阳明
       * 创建时间：20090306
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmMixtureRatioDeleteP(int id, DataGridView dgv)
        {
            status = qualityDb.FrmMixtureRatioDeleteP(id);

            if (status)
            {
                ds = qualityDb.FrmMixtureRatioSearch("", "", 0);
                dgv.DataSource = ds.Tables[1];
                return true;
            }

            return false;
        }

        /*
       * 方法名称：FrmMixtureRatioDeleteR
       * 方法功能描述：调用数据类方法数据库中相应记录返回bool值判断是否更新成功
       *
       * 创建人：夏阳明
       * 创建时间：20090306
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmMixtureRatioDeleteR(int id, DataGridView dgv)
        {
            status = qualityDb.FrmMixtureRatioDeleteR(id);

            if (status)
            {
                ds = qualityDb.FrmMixtureRatioSearch("", "", 0);
                dgv.DataSource = ds.Tables[2];
                return true;
            }

            return false;
        }

        /*
      * 方法名称：FrmMixtureRatioDeleteG
      * 方法功能描述：调用数据类方法数据库中相应记录返回bool值判断是否更新成功
      *
      * 创建人：夏阳明
      * 创建时间：20090306
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmMixtureRatioDeleteG(int id, DataGridView dgv)
        {
            status = qualityDb.FrmMixtureRatioDeleteR(id);

            if (status)
            {
                ds = qualityDb.FrmMixtureRatioSearch("", "", 0);
                dgv.DataSource = ds.Tables[3];
                return true;
            }

            return false;
        }


        /*
        * 方法名称：FrmMixtureRatioSearchDetail
        * 方法功能描述：调用数据类方法获得用户所要查询数据集
        *
        * 创建人：夏阳明
         * * 创建时间：200903018
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet FrmMixtureRatioSearchDetail(int id)
        {
            ds = qualityDb.FrmMixtureRatioSearchDetail(id);
            return ds;
        }

        /*
      * 方法名称：FrmMixtureRatioSearchAssessor
      * 方法功能描述：调用数据类方法数据库中相应记录返回bool值判断是否有该记录
      *
      * 创建人：夏阳明
      * 创建时间：20090413
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmMixtureRatioSearchAssessor(long id)
        {
            DataSet ds = new DataSet();
 
            ds = qualityDb.FrmMixtureRatioSearchAssessor(id);
            if (string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
            {
                return true;
            }

            return false;
            
        }
        /*
      * 方法名称：FrmMixtureRatioSearchCheckupMan
      * 方法功能描述：调用数据类方法数据库中相应记录返回bool值判断是否有该记录
      *
      * 创建人：夏阳明
      * 创建时间：20090413
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool FrmMixtureRatioSearchCheckupMan(long id)
        {
            DataSet ds = new DataSet();

            ds = qualityDb.FrmMixtureRatioSearchCheckupMan(id);
            if (string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
            {
                return true;
            }

            return false;

        }

        #endregion

        #region //检测项目管理

        /*
       * 方法名称：InitialcbxTestGuideline
       * 方法功能描述：给Combobox赋值
       *
       * 创建人：夏阳明
       * 创建时间：20090307
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void InitialcbxTestGuideline(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxTestGuideline();
            cbx.DataSource = ds.Tables[0];
        }


        /*
       * 方法名称：InitialcbxFrequency
       * 方法功能描述：给Combobox赋值
       *
       * 创建人：夏阳明
       * 创建时间：20090307
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void InitialcbxFrequency(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxFrequency();
            cbx.DataSource = ds.Tables[0];
        }

        /*
      * 方法名称：InitialcbxGuideline
      * 方法功能描述：给Combobox赋值
      *
      * 创建人：夏阳明
      * 创建时间：20090307
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public void InitialcbxGuideline(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxGuideline();
            cbx.DataSource = ds.Tables[0];
        }

        /*
    * 方法名称：FrmInspectingfrequencyAddNew
    * 方法功能描述：给新建目标配合比明细表的datagridview添加行
    *
    * 创建人：夏阳明
    * 创建时间：20090307
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

        public void FrmInspectingfrequencyAddNew(MaterialTestGuidelineClass MTGClass, DataTable dt, string Kinds,
                                             string Name, string Model)
        {
            DataRow dr = dt.NewRow();

            dr["id"] = MTGClass.Id;
            dr["sort"] = Kinds;
            dr["name"] = Name;
            dr["model"] = Model;
            dr["testGuideline"] = MTGClass.TestGuideline;
            dr["frequency"] = MTGClass.Frequency;
            dr["eligibilityGuideline"] = MTGClass.Guideline;
            dr["inputDate"] = MTGClass.InputDate;
            dr["inputMan"] = MTGClass.InputMan;
            dr["remark"] = MTGClass.Remark;
            dr["mId"] = MTGClass.MId;

            dt.Rows.Add(dr);
        }


        /*
    * 方法名称：SaveFrmInspectingfrequency
    * 方法功能描述：将材料检测指标保存到数据库中的方法
    *
    * 创建人：夏阳明
    * 创建时间：20090307
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */

        public bool SaveFrmInspectingfrequency(List<MaterialTestGuidelineClass> list,int verifyBit)
        {

            ArrayList sqllist = new ArrayList();

            foreach (MaterialTestGuidelineClass MTGClass in list)
            {
                sqllist.Add(qualityDb.GetFInsertSqlpsd(MTGClass,verifyBit));
            }
            return sqlHelperObj.ExecuteTransaction(sqllist);

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
        public DataSet SearchAll(string condition, int verifyBit,int raidoSelect)
        {
            return qualityDb.SearchAll(condition, verifyBit, raidoSelect);
        }


        /*
    * 方法名称：FrmInspectingfrequencyUpdateSave
    * 方法功能描述：更新
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

            return qualityDb.FrmInspectingfrequencyUpdateSave(MTGDC);

        }
        #endregion
       
        #region //配合比发送
        /*
        * 方法名称：InitialCbxEiId
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090308
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialCbxEiId(ComboBox cbx)
        {
            ds = qualityDb.InitialCbxEiId();
            cbx.DataSource = ds.Tables[0];
        }


        /*
        * 方法名称：InitialcbxTId
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090308
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialcbxTId(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxTId();
            cbx.DataSource = ds.Tables[0];
        }

        /*
        * 方法名称：InitialcbxRTId
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090309
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialcbxRTId(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxRTId();
            cbx.DataSource = ds.Tables[0];
        }

        /*
       * 方法名称：InitialcbxGTId
       * 方法功能描述：给Combobox赋值
       *
       * 创建人：夏阳明
       * 创建时间：20090309
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void InitialcbxGTId(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxGTId();
            cbx.DataSource = ds.Tables[0];
        }

        /*
        * 方法名称：InitialcbxPId
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090308
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialcbxPId(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxPId();
            cbx.DataSource = ds.Tables[0];
        }

        /*
        * 方法名称：InitialcbxInputMan
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090308
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialcbxInputMan(ComboBox cbx)
        {
            ds = qualityDb.InitialcbxInputMan();
            cbx.DataSource = ds.Tables[0];
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
            return qualityDb.FrmProportionSendSearchTP(condition);
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
        public void proportionBind(Panel proportionTable, string ppId)
        {
            DataSet ds = new DataSet();

            ds = qualityDb.proportionBind(ppId);
            
            string proportionTag = null;

            foreach (Object obj in proportionTable.Controls)
            {
                if (obj.GetType() == typeof(TextBox))
                {
                    proportionTag = ((TextBox)obj).Tag.ToString();
                    ((TextBox)obj).Text = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (dr["produceProportion"].ToString().IndexOf(proportionTag) > -1)
                        {
                            ((TextBox)obj).Text = dr["produceProportionValue"].ToString();
                        }
                    }
                }
            }
        }

        /*
     * 方法名称：FrmProportionSendSend
     * 方法功能描述：保存拌和料配合比发送信息记录
     *
     * 创建人：夏阳明
     * 创建时间：20090308
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool FrmProportionSendSend(string inputMan,string remark,string eiId,string tId,string pId)
        {
            status = qualityDb.FrmProportionSendSend(inputMan, remark, eiId, tId, pId);

            return status;

        }

        /*
      * 方法名称：FrmProportionSendSearchP
      * 方法功能描述：查询乳化沥青配合比信息;
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
            return qualityDb.FrmProportionSendSearchP(condition);
        }


        /*
      * 方法名称：FrmProportionSendSearchPG
      * 方法功能描述：查询改性沥青配合比信息;
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
            return qualityDb.FrmProportionSendSearchPG(condition);
        }
        /*
     * 方法名称：FrmProportionRSendSend
     * 方法功能描述：保存乳化沥青配合比发送信息记录
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
            status = qualityDb.FrmProportionRSendSend(inputMan, remark, eiId, tId);

            return status;

        }

        /*
    * 方法名称：FrmProportionGSendSend
    * 方法功能描述：保存改性沥青配合比发送信息记录
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
            status = qualityDb.FrmProportionGSendSend(inputMan, remark, eiId, tId);

            return status;

        }

        /*
        * 方法名称：FormFrmProportionSendSearch
        * 方法功能描述：调用数据类方法获得用户查询所得数据集并绑定DataGridView
        *
        * 创建人：夏阳明
         * * 创建时间：20090309
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void FormFrmProportionSendSearch(DataGridView dgvG)
        {
            ds = qualityDb.FormFrmProportionSendSearch();
            dgvG.DataSource = ds.Tables[0];
                
        }

        /*
       * 方法名称：FrmProportionSendQuery
       * 方法功能描述：调用数据类方法获得用户查询所得数据集并绑定DataGridView
       *
       * 创建人：夏阳明
        * * 创建时间：20090309
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void FrmProportionSendQuery(string searchStr, string condition, int verifyBit, DataGridView dgvT, DateTime searchStrD)
        {
            //verifyBit = 0:查询全部，verifyBit = 1：按条件查询
            ds = qualityDb.FrmProportionSendQuery(searchStr, condition, verifyBit, searchStrD);

            dgvT.DataSource = ds.Tables[0];

        }

        /*
       * 方法名称：FrmProportionSendSearchRG
       * 方法功能描述：返回标识位，确定是乳化沥青还是改性沥青
       *
       * 创建人：夏阳明
        * * 创建时间：20090309
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public int FrmProportionSendSearchRG(int id)
        {
            int verifyBit;

            bool status;
            //verifyBit = 1:乳化沥青，verifyBit = 0：改性沥青
            ds = qualityDb.FrmProportionSendSearchRG(id);
            if (ds.Tables[0].Rows.Count == 0)
            {
                verifyBit = 2;
            }
            else
            {
                status = Convert.ToBoolean(ds.Tables[0].Rows[0][0].ToString());
                if (status == true)
                {
                    verifyBit = 1;
                }
                else
                {
                    verifyBit = 0;
                }
            }

            return verifyBit;
        }

        /*
      * 方法名称：FrmProportionSendSearchPId
      * 方法功能描述：返回PID
      *
      * 创建人：夏阳明
       * * 创建时间：20090309
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int FrmProportionSendSearchPId(int id)
        {
            int PId;

            ds = qualityDb.FrmProportionSendSearchPId(id);
            
            PId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            
            return PId;
        }

        /*
     * 方法名称：FrmProportionSendSearchGPId
     * 方法功能描述：返回GPID
     *
     * 创建人：夏阳明
      * * 创建时间：20090309
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public int FrmProportionSendSearchGPId(int id)
        {
            int PId;

            ds = qualityDb.FrmProportionSendSearchGPId(id);

            PId = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return PId;
        }

        /*
      * 方法名称：FrmProportionSendSearchTpId
      * 方法功能描述：返回TpId
      *
      * 创建人：夏阳明
       * * 创建时间：20090309
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int FrmProportionSendSearchTpId(int id)
        {
            int TpId;

            ds = qualityDb.FrmProportionSendSearchTpId(id);

            TpId = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return TpId;
        }

        /*
      * 方法名称：FrmProportionSendSearchPpId
      * 方法功能描述：返回PpId
      *
      * 创建人：夏阳明
       * * 创建时间：20090309
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int FrmProportionSendSearchPpId(int id)
        {
            int TpId;

            ds = qualityDb.FrmProportionSendSearchPpId(id);

            TpId = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return TpId;
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
            return qualityDb.FrmProportionSendSearchM(condition);
        }

        #endregion






    }
}
