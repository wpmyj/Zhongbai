using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DasherStation.common;
using System.Windows.Forms;
using System.Drawing;
using MSScriptControl;
using System.Collections;


namespace DasherStation.transport
{
    public class TransportLogic
    {
        TransportDB transportDB = new TransportDB();

        /// <summary>
        /// 运输信息类型
        /// </summary>
        public enum TranType
        {
            material, product
        }
        /// <summary>
        /// 运输货物对应的种类
        /// </summary>
        /// <param name="rb1">种类一的单选框</param>
        /// <param name="rb2">种类二的单选框</param>
        /// <returns>TranType枚举</returns>
        public TranType getType(RadioButton rb1, RadioButton rb2)
        {
            if (rb1.Checked)
            {
                return TranType.material;
            }
            else
            {
                return TranType.product;
            }
        }

        /// <summary>
        /// 合同类型
        /// </summary>
        /// <param name="rb1">种类一的单选框</param>
        /// <param name="rb2">种类二的单选框</param>
        /// <returns>0:一般合同 1:补充合同</returns>
        public int getcType(RadioButton rb1, RadioButton rb2)
        {
            if (rb1.Checked)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        // 2009-4-20 修改人：付中华 给订编号返回运输单位的名称
        public DataTable findConveyAncer(int id)
        {
            return transportDB.findConveyAncerdb(id);
        }


        /// <summary>
        /// 绑定合同名称列表
        /// </summary>
        /// <param name="cmb">ComboBox</param>
        public void contractList(ComboBox cmb)
        {
            cmb.DataSource = transportDB.contractBind(" and (assessor IS NOT NULL) AND (checkupMan IS NOT NULL) AND (assessor <> '') AND (checkupMan <> '') and mark=0 ").Tables[0];           
            cmb.DisplayMember = "合同名称";
            cmb.ValueMember = "id";
            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 绑定合同名称列表
        /// </summary>
        /// <param name="cmb">ComboBox</param>
        public void contractViewList(ComboBox cmb)
        {
            cmb.DataSource = transportDB.contractBind("").Tables[0];
            cmb.DisplayMember = "合同名称";
            cmb.ValueMember = "id";
            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 查找ComboBox值对应项的索引
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int FindIndex(ComboBox cmb, string value,string valueRow)
        {
            for (int i = 0; i < cmb.Items.Count; i++)
            {

                if (((DataRowView)cmb.Items[i]).Row[valueRow].ToString() == value)
                {
                    cmb.SelectedIndex = i;
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 检查数据库中是否含有同名合同
        /// </summary>
        /// <param name="no"></param>
        /// <param name="contractName"></param>
        public bool AlonekContract(string no, string contractName)
        {
            return transportDB.contractBind(" and no='" + no + "' or contractName='" + contractName + "'").Tables[0].Rows.Count>0;
        }

        /// <summary>
        /// 绑定合同编号列表
        /// </summary>
        /// <param name="cmb">ComboBox</param>
        public void contractNoList(ComboBox cmb)
        {
            cmb.DataSource = transportDB.contractBind(" and mark=0 ").Tables[0];
            cmb.DisplayMember = "合同编号";
            cmb.ValueMember = "id";
            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 获得查询条件字符串
        /// </summary>
        /// <param name="cmb">条件ComboBox</param>
        /// <param name="txt">查询关键字</param>
        /// <returns></returns>
        public string getQueryStr(ComboBox cmb, TextBox txt)
        {
            string sqlStr = null;
            switch (cmb.SelectedIndex)
            {
                case 1:
                    sqlStr = " and no='"+txt.Text.Trim()+"'" ;
                    break;
                case 2:
                    sqlStr = " and contractName like '%" + txt.Text.Trim() + "%'";
                    break;
                case 3:
                    sqlStr = " and name like '%" + txt.Text.Trim() + "%'";
                    break;
                default:
                    break;
            }
            return sqlStr;
        }

        /// <summary>
        /// 运输商信息绑定
        /// </summary>
        /// <param name="cmb">需要绑定的ComboBox对象</param>
        public void transportUnitBind(ComboBox cmb)
        {
            cmb.DataSource = transportDB.transportUnitBind().Tables[0];
            cmb.DisplayMember = "name";
            cmb.ValueMember = "id";
            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 运输商信息绑定
        /// </summary>
        /// <param name="cmb">需要绑定的DataGridViewComboBoxColumn对象</param>
        public void transportUnitBind(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = transportDB.transportUnitBind().Tables[0];
            cmb.DisplayMember = "name";
            cmb.ValueMember = "id";

        }

        /// <summary>
        /// 运输地点信息绑定
        /// </summary>
        /// <param name="cmb">需要绑定的ComboBox对象</param>
        public void siteBind(ComboBox cmb)
        {
            cmb.DataSource = transportDB.siteBind().Tables[0];
            cmb.DisplayMember = "site";
            cmb.ValueMember = "id";
            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 运输地点信息绑定
        /// </summary>
        /// <param name="cmb">需要绑定的DataGridViewComboBoxColumn对象</param>
        public void siteBind(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = transportDB.siteBind().Tables[0];
            cmb.DisplayMember = "site";
            cmb.ValueMember = "id";
        }

        /// <summary>
        /// 运输地点信息绑定
        /// </summary>
        /// <param name="cmb">需要绑定的ComboBox对象</param>
        public void transportSettlementMethodBind(ComboBox cmb)
        {
            cmb.DataSource = transportDB.transportSettlementMethodBind().Tables[0];
            cmb.DisplayMember = "method";
            cmb.ValueMember = "id";
            cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// 运输地点信息绑定
        /// </summary>
        /// <param name="cmb">需要绑定的ComboBox对象</param>
        public void transportSettlementMethodBind(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = transportDB.transportSettlementMethodBind().Tables[0];
            cmb.DisplayMember = "method";
            cmb.ValueMember = "id";

        }
        /*
      * 方法名称：QueryBind
      * 方法功能描述：查询条件的绑定
      * 参数: 
      * 
      * 创建人：付中华
      * 创建时间：2009-04-20
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */      
        public void QueryBind(ComboBox cmb)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Value");

            DataRow row = table.NewRow();
            row["id"] = "";
            row["Value"] = "无条件";
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = "no";
            row["Value"] = "合同编号";
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = "contractName";
            row["Value"] = "合同名称";
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = "tu.name";
            row["Value"] = "运输单位名称";
            table.Rows.Add(row);

            cmb.DataSource = table;
            cmb.ValueMember = "ID";
            cmb.DisplayMember = "Value";
            cmb.SelectedIndex = -1;
        }
        /*
     * 方法名称：contractStatus
     * 方法功能描述： 合同状态的绑定
     * 参数: 
     * 
     * 创建人：付中华
     * 创建时间：2009-04-20
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */       
        public void contractStatus(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("value");

            DataRow dr = dt.NewRow();
            dr["id"] = "all";
            dr["value"] = "显示全部信息";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["id"] = "hasFinish";
            dr["value"] = "已终止合同";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["id"] = "notFinish";
            dr["value"] = "未终止合同";
            dt.Rows.Add(dr);

            cmb.DataSource = dt;
            cmb.DisplayMember = "value";
            cmb.ValueMember = "id";
        }

        /// <summary>
        /// 生成默认的Table容器
        /// </summary>
        /// <param name="dgv">待绑定控件</param>
        /// <returns></returns>
        public DataTable CreatTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("model");
            dt.Columns.Add("site1");
            dt.Columns.Add("site2");
            dt.Columns.Add("distance");
            dt.Columns.Add("price");
            dt.Columns.Add("Method");
            dt.Columns.Add("tsmId");
            dt.Columns.Add("nId");
            dt.Columns.Add("mId");
            dt.Columns.Add("Type");
            dt.Columns.Add("sid1");
            dt.Columns.Add("sid2");

            return dt;
        }

        /// <summary>
        /// 保存运输合同
        /// </summary>
        /// <param name="transportContract">运输合同对象</param>
        /// <param name="list">合同明细集合</param>
        /// <returns>True:成功,False:失败</returns>
        public bool saveContract(TransportContract transportContract, List<TransportGoodsInformationCorresponding> list)
        {
            return transportDB.saveContract(transportContract, list);
        }

        /// <summary>
        /// 运输合同信息绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="strWhere">筛选条件</param>
        //public void contractBind(DataGridView dgv, string strWhere)
        //{
        //    dgv.DataSource = transportDB.contractBind(strWhere).Tables[0];
        //}
        /*
     * 方法名称：
     * 方法功能描述：调用主合同的查询信息 
     * 参数: 
     * 
     * 创建人：付中华
     * 创建时间：2009-04-20
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */      
        public DataTable getContractListLogic(string strWhere, string contractStatus)
        {
            return transportDB.getContractList(strWhere, contractStatus);
        }
        /*
    * 方法名称：
    * 方法功能描述：终止主合同及其相关的所有
    * 参数: 
    * 
    * 创建人：付中华
    * 创建时间：2009-04-20
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */        
        public bool endMainContractLogic(int mainId)
        {
            return transportDB.endMainContract(mainId);
        }
        /*
    * 方法名称：
    * 方法功能描述：终止分合同
    * 参数: 
    * 
    * 创建人：付中华
    * 创建时间：2009-04-20
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
        public bool endSupplyContractLogic(int supplyId, int parentId)
        {
            return transportDB.endSupplyContract(supplyId, parentId);
        }
        /*
  * 方法名称：
  * 方法功能描述： 判断是否都终止
  * 参数: 
  * 
  * 创建人：付中华
  * 创建时间：2009-04-20
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */        
        public bool isEndAll(int mainId, int parentId)
        {
            return transportDB.isEndAll(mainId, parentId);
        }
        /*
           * 方法名称：
           * 方法功能描述：终止主合同明细
           * 参数: 
           * 
           * 创建人：付中华
           * 创建时间：2009-04-20
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool endMainContractDetailLogic(int mainContractDetailId, int mainContractId)
        {
            return transportDB.endMainContractDetail(mainContractDetailId, mainContractId);
        }
        /*
 * 方法名称：
 * 方法功能描述：  终止分合同明细
 * 参数: 
 * 
 * 创建人：付中华
 * 创建时间：2009-04-20
 *
 * 修改人：
 * 修改时间：
 * 修改内容：
 *
 */
        public bool endSupplyContractDetailLogic(int supplyDetailId, int parentId)
        {
            return transportDB.endSupplyContractDetail(supplyDetailId, parentId);
        }

        /// <summary>
        /// 运输明细绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="tcid">运输合同ID</param>
        public void goodsInfoBind(DataGridView dgv, string tcid)
        {
            dgv.DataSource = transportDB.goodsInfoBind(tcid).Tables[0];
        }

        public void SettlementDetail(DataGridView dgv, string tsid)
        {
            dgv.DataSource = transportDB.SettlementDetail(tsid).Tables[0];
        }

        public DataSet noteBind(string code)
        {
            return transportDB.noteBind(code);
        }

        public DataSet noteViewBind(string tcid)
        {
            return transportDB.noteViewBind(tcid);
        }

        public bool checkDetail(DataGridView dgv_detail, string did)
        {
            
            foreach (DataGridViewRow dgv in dgv_detail.Rows)
            {
               
                if (dgv.Cells["id"].Value != null && (dgv.Cells["id"].Value.ToString() == did))
                {
                    dgv.Selected = true;
                    return true;
                }
            }
            return false;
        }

        public bool checkNote(DataGridView dgv_note, string code)
        {
            foreach (DataGridViewRow dgv in dgv_note.Rows)
            {
                if (dgv.Cells["barcode"].Value != null && (dgv.Cells["barcode"].Value.ToString() == code))
                {
                    dgv.Selected = true;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 运输核算信息绑定
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="strWhere">筛选条件</param>
        public void settlementBind(DataGridView dgv, string strWhere)
        {
            dgv.DataSource = transportDB.settlementBind(strWhere).Tables[0];
        }

        /// <summary>
        /// 终止运输合同
        /// </summary>
        /// <param name="tcid">合同ID</param>
        /// <returns>True:成功 False:失败</returns>
        public bool contractStop(string tcid)
        {
            return transportDB.contractStop(tcid);
        }

        /// <summary>
        /// 终止运输合同明细
        /// </summary>
        /// <param name="tcid">合同明细ID</param>
        /// <returns>True:成功 False:失败</returns>
        public bool contractDatailStop(string tcid)
        {
            return transportDB.contractDatailStop(tcid);
        }

        /// <summary>
        /// 审核运输合同
        /// </summary>
        /// <param name="tcid">合同ID</param>
        /// <param name="userName">用户名</param>
        /// <returns>True:成功 False:失败</returns>
        public bool contractAssessor(string tcid, string userName)
        {
            return transportDB.contractAssessor(tcid, userName);
        }

        /// <summary>
        /// 审批运输合同
        /// </summary>
        /// <param name="tcid">合同ID</param>
        /// <param name="userName">用户名</param>
        /// <returns>True:成功 False:失败</returns>
        public bool contractCheckup(string tcid, string userName)
        {
            return transportDB.contractCheckup(tcid, userName);
        }

        public void tgi_select(DataGridView dgv_detail, DataGridView dgv_note)
        {
             if (dgv_detail.SelectedRows.Count > 0)
             {
                foreach (DataGridViewRow dgvr in dgv_detail.SelectedRows)
                {
                    if (dgvr.Cells["id"].Value != null)
                    {
                        note_selete(dgv_note, dgvr.Cells["id"].Value.ToString());
                    }
                }
             }
        }

        private void note_selete(DataGridView dgv_note,string tgicid)
        {
            if (!string.IsNullOrEmpty(tgicid))
            {
                foreach (DataGridViewRow dgvr in dgv_note.Rows)
                {
                    dgvr.Selected = (dgvr.Cells["did"].Value != null && dgvr.Cells["did"].Value.ToString() == tgicid);
                }
            }
        }

        /// <summary>
        /// 按数学公式计算数据
        /// </summary>
        /// <param name="x">单价</param>
        /// <param name="y">重量</param>
        /// <param name="z">运距</param>
        /// <param name="f">公式</param>
        /// <returns>计算结果</returns>
        public float compute(string x, string y, string z, string f)
        {
            if (f.IndexOf("x") > -1)
            {
                f=f.Replace("x", x);
            }
            if (f.IndexOf("y") > -1)
            {
                f=f.Replace("y", y);
            }
            if (f.IndexOf("z") > -1)
            {
                f=f.Replace("z", z);
            }
            ScriptControl sc = new ScriptControlClass();
            sc.Language = "Javascript";
            return float.Parse(sc.Eval(f).ToString()); 
        }

        public void saveCompute(TransportSettlement transportSettlement, DataGridView dgv_detail, DataGridView dgv_note,string userName)
        {
            ArrayList sqlList = new ArrayList();

            TransportSettlementDetail transportSettlementDetail=null;

            TransportNoteCorresponding transportNoteCorresponding = null;
            
            List<TransportNoteCorresponding> tnList=null;

            string nodeCode = null;

            int count = 0;

            decimal sum = 0;

            sqlList.Add(new TransportSettlementAction().GetInsertSql(transportSettlement));

            foreach(DataGridViewRow dgvr in dgv_detail.Rows)
            {
                if (dgvr.Cells["id"].Value != null)
                {
                    tnList=new List<TransportNoteCorresponding>();
                    transportSettlementDetail = new TransportSettlementDetail();
                    transportSettlementDetail.tgicId = long.Parse(dgvr.Cells["id"].Value.ToString());
                    transportSettlementDetail.inputMan = userName;
                    count = 0;
                    sum = 0;
                    foreach (DataGridViewRow dgvrn in dgv_note.Rows)
                    {
                        if (dgvr.Cells["id"].Value.ToString() == dgvrn.Cells["did"].Value.ToString())
                        {

                            count += 1;
                            sum += decimal.Parse(Math.Round(compute(dgvr.Cells["price"].Value.ToString(), dgvrn.Cells["suttle"].Value.ToString(), dgvr.Cells["distance"].Value.ToString(), dgvr.Cells["formula"].Value.ToString()),2).ToString());
                            string code = dgvrn.Cells["barcode"].Value.ToString();
                            nodeCode += ",'" + code+"'";
                            transportNoteCorresponding = new TransportNoteCorresponding();
                            transportNoteCorresponding.cnId = transportDB.queryConsignmentNoteID(code);
                            transportNoteCorresponding.snId = transportDB.queryStockNoteID(code);
                            transportNoteCorresponding.inputMan = userName;
                            tnList.Add(transportNoteCorresponding);
                        }
                    }
                    transportSettlementDetail.count = count;
                    transportSettlementDetail.sum = sum;
                    if (count > 0)
                    {
                        sqlList.Add(new TransportSettlementDetailAction().GetInsertSql(transportSettlementDetail));
                        foreach (TransportNoteCorresponding tnc in tnList)
                        {
                            sqlList.Add(new TransportNoteCorrespondingAction().GetInsertSql(tnc));
                        }
                    }
                    
                }
            }//运输明细循环
            if (nodeCode != null)
            {
                sqlList.Add(transportDB.getNodeSql(nodeCode));
            }
            transportDB.ExecuteTransaction(sqlList);
        }



        public void AfterConfirmUpdate(object auditing, SqlHelper sqlHelper)
        {
           // MessageBox.Show("审核之后执行的更新操作");
            //sqlHelper.Update(new ArrayList(){"asdasdasddddddddddasdasd"});
        }

        public void AfterConfirmInsert(object auditing, SqlHelper sqlHelper)
        {
           // MessageBox.Show("审核之后执行的增加操作");
        }



    }

    /// <summary>
    /// 处理任何窗体上Combox,种类,名称,规格的联动
    /// </summary>
    public class DoCombox
    {
        TransportDB transportDB = new TransportDB();

        private ComboBox cmb1;
        public ComboBox Cmb1
        {
            get { return cmb1; }
            set { cmb1 = value; }
        }

        private ComboBox cmb2;
        public ComboBox Cmb2
        {
            get { return cmb2; }
            set { cmb2 = value; }
        }

        private ComboBox cmb3;
        public ComboBox Cmb3
        {
            get { return cmb3; }
            set { cmb3 = value; }
        }

        private TransportLogic.TranType tranType;
        public TransportLogic.TranType TranType
        {
            get { return tranType; }
            set { tranType = value; }
        }

        /// <summary>
        /// 类构造函数
        /// </summary>
        /// <param name="cmb1">类别</param>
        /// <param name="cmb2">名称</param>
        /// <param name="cmb3">规格</param>
        /// <param name="tranType"></param>
        public DoCombox(ComboBox cmb1, ComboBox cmb2, ComboBox cmb3, TransportLogic.TranType tranType)
        {
            this.Cmb1 = cmb1;
            this.Cmb2 = cmb2;
            this.Cmb3 = cmb3;

            Cmb1.SelectionChangeCommitted += cmb_1_SelectionChangeCommitted;
            Cmb2.SelectionChangeCommitted += cmb_2_SelectionChangeCommitted;

            this.TranType = tranType;

            cmb1.DataSource = null;
            cmb2.DataSource = null;
            cmb3.DataSource = null;

            kindBind(this.Cmb1, tranType, null);

        }

        private void cmb_1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            if (cmb1.SelectedIndex > -1)
            {
                cmb2.DataSource = null;
                cmb3.DataSource = null;
                
                nameBind(Cmb2, this.TranType, Cmb1.SelectedValue.ToString());
            }
        }

        private void cmb_2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb2.SelectedIndex > -1)
            {
                modelBind(cmb3, this.TranType, cmb2.SelectedValue.ToString());
            }
        }

        public void kindBind(ComboBox cmb, TransportLogic.TranType type, string strWhere)
        {
            cmb.DataSource = transportDB.kindBind(type, strWhere).Tables[0];
            cmb.DisplayMember = "sort";
            cmb.ValueMember = "id";
            cmb.SelectedIndex = -1;
        }

        public void nameBind(ComboBox cmb, TransportLogic.TranType type, string strWhere)
        {
            cmb.DataSource = transportDB.nameBind(type, strWhere).Tables[0];
            cmb.DisplayMember = "name";
            cmb.ValueMember = "id";
            cmb.SelectedIndex = -1;
        }

        public void modelBind(ComboBox cmb, TransportLogic.TranType type, string strWhere)
        {
            cmb.DataSource = transportDB.modelBind(type, strWhere).Tables[0];
            cmb.DisplayMember = "model";
            cmb.ValueMember = "id";
            cmb.SelectedIndex = -1;
        }

    }

    /// <summary>
    /// 处理窗体操作
    /// </summary>
    public class FormHelper
    {

        List<ErrorProvider> validationList=new List<ErrorProvider>();

        public bool inputCheck(Panel inputPanel)
        {
           
            bool result = true;
            foreach (object obj in inputPanel.Controls)
            {
                TextBox txt = obj as TextBox;
                if (txt != null && txt.Tag != null)
                {
                    #region 文本框的验证
                    if (!txtCheck(txt))
                    {
                        result = false;
                    }
                    #endregion
                }
                ComboBox cmb = obj as ComboBox;
                if (cmb != null && cmb.Tag != null)
                {
                    #region 下拉框的验证
                    if (!cmbCheck(cmb))
                    {
                        result = false;
                    }
                    #endregion
                }
            }
            return result;
        }

        public bool inputCheck(GroupBox gpb)
        {        
            bool result = true;
            foreach (object obj in gpb.Controls)
            {

                TextBox txt = obj as TextBox;
                if (txt != null && txt.Tag != null)
                {
                    #region 文本框的验证
                    if (!txtCheck(txt))
                    {
                        result = false;
                    }
                    #endregion
                }
                ComboBox cmb = obj as ComboBox;
                if (cmb != null && cmb.Tag != null)
                {
                    #region 下拉框的验证
                    if (!cmbCheck(cmb))
                    {
                        result = false;
                    }
                    #endregion
                }
            }
            return result;
        }

        public bool txtCheck(TextBox txt)
        {
            bool result = true;
            if ((txt.Tag.ToString().IndexOf('E') > -1) && (result == true))
            {
                if (!Check.CheckEmpty(txt.Text.Trim()))
                {
                    txt.Enter += new EventHandler(txt_GotFocus);
                    result = ValidationAdd(txt,"信息不能为空");
                }
                else
                {
                    ValidationClear(txt.Name);
                }
            }
            if ((txt.Tag.ToString().IndexOf('I') > -1) && (result == true))
            {
                if (!Check.CheckNumber(txt.Text.Trim()))
                {
                    txt.Enter += new EventHandler(txt_GotFocus);

                    result = ValidationAdd(txt,"只能输入正整数");
                }
                else
                {
                    ValidationClear(txt.Name);
                }
            }
            if ((txt.Tag.ToString().IndexOf('F') > -1) && (result == true))
            {
                if (!Check.CheckFloat(txt.Text.Trim()))
                {
                    txt.Enter += new EventHandler(txt_GotFocus);
                    result = ValidationAdd(txt, "只能输入正符点数");
                }
                else
                {
                    ValidationClear(txt.Name);
                }
            }
            if ((txt.Tag.ToString().IndexOf('S') > -1) && (result == true))
            {
                if (!Check.CheckQuery(txt.Text.Trim()))
                {
                    txt.Enter += new EventHandler(txt_GotFocus);
                    result = ValidationAdd(txt, "信息中不能包含非法字符");
                }
                else
                {
                    ValidationClear(txt.Name);
                }
            }
            return result;

        }

        public bool cmbCheck(ComboBox cmb)
        {
            bool result = true;

            if (cmb.DropDownStyle == ComboBoxStyle.DropDown)
            {
                if ((cmb.Tag.ToString().IndexOf('E') > -1) && (result == true))
                {
                    if (!Check.CheckEmpty(cmb.Text.Trim()))
                    {
                        cmb.Enter += new EventHandler(cmb_GotFocus);
                        result = ValidationAdd(cmb, "信息不能为空");
                    }
                    else
                    {
                        ValidationClear(cmb.Name);
                    }
                }

                if ((cmb.Tag.ToString().IndexOf('I') > -1) && (result == true))
                {
                    if (!Check.CheckNumber(cmb.Text.Trim()))
                    {
                        cmb.Enter += new EventHandler(cmb_GotFocus);
                         result = ValidationAdd(cmb, "只能输入正整数");
                    }
                    else
                    {
                        ValidationClear(cmb.Name);
                    }
                }
                if ((cmb.Tag.ToString().IndexOf('F') > -1) && (result == true))
                {
                    if (!Check.CheckFloat(cmb.Text.Trim()))
                    {
                        cmb.Enter += new EventHandler(cmb_GotFocus);
                        result = ValidationAdd(cmb, "只能输入正符点数");
                    }
                    else
                    {
                        ValidationClear(cmb.Name);
                    }
                }
                if ((cmb.Tag.ToString().IndexOf('S') > -1) && (result == true))
                {
                    if (!Check.CheckQuery(cmb.Text.Trim()))
                    {
                        cmb.Enter += new EventHandler(cmb_GotFocus);
                        result = ValidationAdd(cmb, "信息中不能包含非法字符");
                    }
                    else
                    {
                        ValidationClear(cmb.Name);
                    }
                }
            }
            else if (cmb.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                if ((cmb.Tag.ToString().IndexOf('E') > -1) && (result == true))
                {
                    if (cmb.SelectedIndex == -1)
                    {
                        cmb.Enter += new EventHandler(cmb_GotFocus);
                        result = ValidationAdd(cmb, "必须选择该项");
                    }
                    else
                    {
                        ValidationClear(cmb.Name);
                    }
                }
            }

            return result;
        }

        private void cmb_GotFocus(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (cmb != null)
            {
                ValidationClear(cmb.Name);
            }
        }

        private void txt_GotFocus(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                ValidationClear(txt.Name);
            }
        }

        private void ValidationClear(string objName)
        {
            foreach (ErrorProvider Validation in validationList)
            {
                if (Validation.Tag.ToString() == objName)
                {
                    Validation.Clear();
                }
            }
        }

        private bool ValidationAdd(TextBox txt,string error)
        {
            ErrorProvider errorProvider = new ErrorProvider();
            errorProvider.SetError(txt, error);
            errorProvider.Tag = txt.Name;
            validationList.Add(errorProvider);
            return false;
        }

        private bool ValidationAdd(ComboBox cmb, string error)
        {
            ErrorProvider errorProvider = new ErrorProvider();
            errorProvider.SetError(cmb, error);
            errorProvider.Tag = cmb.Name;
            validationList.Add(errorProvider);
            return false;
        }



    }




}
