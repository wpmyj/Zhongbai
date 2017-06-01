using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace DasherStation.costCount
{
    /*
     * 类名称：CostFactory
     * 类功能描述：成本核算数据层工厂类
     *
     * 创建人：袁宇
     * 创建时间：2009-03-18
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class CostFactory
    {
        /*
         * 方法名称：NewCostDB
         * 方法功能描述：根据费用类型，创建数据层类 
         * 参数: style 费用类型
         * 
         * 创建人：袁宇
         * 创建时间：2009-03-18
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */        
        public CostCountDB NewCostDB(CostStyle style)
        {
            CostCountDB CostDB = null;
            switch (style)
            {
                //直接人工数据层
                case CostStyle.ManExpenditure:
                    CostDB = new ManExpenditureDB();
                    break;
                //制造费用数据层
                case CostStyle.MakeExpenditure:
                    CostDB = new MakeExpenditureDB();
                    break;
                //季节性停工损失数据层
                case CostStyle.ShutdownExpenditure:
                    CostDB = new ShutdownExpenditureDB();
                    break;
                //废品损失数据层
                case CostStyle.ScrapExpenditure:
                    CostDB = new ScrapExpenditureDB();
                    break;
                //直接材料费用数据层
                case CostStyle.StuffExpenditure:
                    CostDB = new StuffExpenditureDB();
                    break;
                //数据层基类
                default:
                    CostDB = new CostCountDB();
                    break;
            }
            return CostDB;
 
        }
    }
    /*
    * 类名称：CostCountLogic
    * 类功能描述：成本核算逻辑
    *
    * 创建人：袁宇
    * 创建时间：2009-03-20
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class CostCountLogic
    {
        /*
         * 方法名称：CreateTree
         * 方法功能描述：根据所选字段值，创建树
         * 参数: tree 要被操作的树
         *       dt   数据来源
         *       fields 数据来源字段名
         * 
         * 创建人：袁宇
         * 创建时间：2009-03-20
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */

        public void CreateTree(ref TreeView tree, DataTable dt, ArrayList fields)
        {
            
            if ((dt.Rows.Count > 0) && (fields.Count > 0)) 
            {
                ArrayList values = new ArrayList();

                tree.BeginUpdate();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    values.Clear();
                    for (int j = 0; j < fields.Count; j++)
                    {
                        values.Add(dt.Rows[i][fields[j].ToString()].ToString());
                    }
                    AddTreeNode(ref tree,values);                                         
                }
                tree.EndUpdate();
            }            
        }
        /*
         * 方法名称：AddTreeNode
         * * 方法功能描述：添加树节点
         * 参数: tree 要被操作的树
         *       values 树的值列表
         *       
         * 
         * 创建人：袁宇
         * 创建时间：2009-03-20
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void AddTreeNode(ref TreeView tree, ArrayList values)
        {
            TreeNode node = null;
            TreeNode ThisNode = null;
            if (values.Count > 0)
            {            
                for (int i = 0; i < values.Count; i++)
                {
                    TreeNode nodeTemp = null;
                    nodeTemp = FindTreeNode(tree,node, values[i].ToString());
                    if (nodeTemp != null)
                    {
                        node = nodeTemp;
                        continue;
                    } 
                    if (node==null)
                    {                        
                        node = new TreeNode();
                        node.Text = values[i].ToString();                        
                        tree.Nodes.Add(node);
                    }
                    else
                    {
                        ThisNode = new TreeNode();
                        ThisNode.Text = values[i].ToString();
                        node.Nodes.Add(ThisNode);
                        node = ThisNode;
                    } 
                }
            }
        }
        /*
         * 方法名称：FindTreeNode
         * 方法功能描述：查找树结点相同名
         * 参数: tree 要被操作的树
         *       name 查询值
         *       treeNode 当前结点
         * 
         * 创建人：袁宇
         * 创建时间：2009-03-20
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private TreeNode FindTreeNode(TreeView tree, TreeNode treeNode, string name)
        {
            TreeNode recNode = null;
            if (treeNode == null)
            {
                foreach (TreeNode node in tree.Nodes)
                {
                    if (node.Text == name)
                    {
                        recNode = node;
                    }
                } 
            }
            else
                foreach (TreeNode node in treeNode.Nodes)
                {
                    if (node.Text == name)
                    {                    
                        recNode = node;
                    }
                }
            return recNode;
        }
        /*
         * 方法名称：CreateExpenditureTree
         * 方法功能描述：对费用类别表提树操作
         * 参数: tree 要被操作的树
         *       
         * 
         * 创建人：袁宇
         * 创建时间：2009-03-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public void CreateExpenditureTree(TreeView tree)
        {
            CostCountDB dbLayer = new CostCountDB();
            DataTable dt = new DataTable();

            dt = dbLayer.SelectExpenditureName("");
            foreach (DataRow row in dt.Rows)
            {
                TreeNode node = new TreeNode();
                TreeTagType tag = new TreeTagType();
                node.Text = row["name"].ToString();
                tag.id = row["id"].ToString();
                tag.parentId = row["parentId"].ToString();
                node.Tag = tag;                
                tree.Nodes.Add(node);
                CreateChildTree(node);  
            }
        }
        /*
         * 方法名称：CreateExpenditureTree
         * 方法功能描述：对费用类别表提树操作
         * 参数: tree 要被操作的树
         *       
         * 
         * 创建人：袁宇
         * 创建时间：2009-03-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void CreateChildTree(TreeNode node)
        {
            CostCountDB dbLayer = new CostCountDB();
            DataTable dt = new DataTable();

            dt = dbLayer.SelectExpenditureName(((TreeTagType)node.Tag).id);

            foreach (DataRow row in dt.Rows)
            {
                TreeNode childNode = new TreeNode();
                TreeTagType tag = new TreeTagType();
                childNode.Text = row["name"].ToString();
                tag.id = row["id"].ToString();
                tag.parentId = row["parentId"].ToString();
                childNode.Tag = tag;                
                node.Nodes.Add(childNode);
                CreateChildTree(childNode);                
            }
        }     


        
        /*
       * 方法名称：DataRowToWaitDetachExpenditure
       * 方法功能描述：DataRow转换为实体类信息
       * 参数: 
       *       
       * 
       * 创建人：付中华
       * 创建时间：2009-03-25
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public waitDetachExpenditureClass DataRowToWaitDetachExpenditure(DataRow dr)
        {
            waitDetachExpenditureClass info = new waitDetachExpenditureClass();
            info.id = dr["id"].ToString();
            info.ekId = dr["ekId"].ToString();
            info.enId = dr["enId"].ToString();
            info.ecId = dr["ecId"].ToString();
            info.expenditureDepict = dr["expenditureDepict"].ToString();
            info.year = dr["year"].ToString();
            info.month = dr["month"].ToString();
            info.eiId = dr["eiId"].ToString();
            info.pId = dr["pId"].ToString();
            info.number = dr["number"].ToString();
            info.unitPrice = dr["unitPrice"].ToString();
            info.money = dr["money"].ToString();
            info.inputDate = dr["inputDate"].ToString();
            info.inputMan = dr["inputMan"].ToString();
            info.assessor = dr["assessor"].ToString();
            info.checkupMan = dr["checkupMan"].ToString();
            info.convert = dr["convert"].ToString();
            info.remark = dr["remark"].ToString();

            return info;
        }

         /*
        * 方法名称：DataRowToExpenditure
        * 方法功能描述：DataRow转换为实体类信息
        * 参数: 
        *      
        * 
        * 创建人：付中华
        * 创建时间：2009-03-25
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public expenditureClass DataRowToExpenditure(DataRow dr)
        {
            expenditureClass info = new expenditureClass();
            info.id = dr["id"].ToString();
            info.ekId = dr["ekId"].ToString();
            info.enId = dr["enId"].ToString();
            info.ecId = dr["ecId"].ToString();
            info.expenditureDepict = dr["expenditureDepict"].ToString();
            info.year = dr["year"].ToString();
            info.month = dr["month"].ToString();
            info.eiId = dr["eiId"].ToString();
            info.pId = dr["pId"].ToString();
            info.number = dr["number"].ToString();
            info.unitPrice = dr["unitPrice"].ToString();
            info.money = dr["money"].ToString();
            info.inputDate = dr["inputDate"].ToString();
            info.inputMan = dr["inputMan"].ToString();
            info.assessor = dr["assessor"].ToString();
            info.checkupMan = dr["checkupMan"].ToString();
            info.convert = dr["convert"].ToString();
            info.remark = dr["remark"].ToString();

            return info;
        } 


    }
    /*
    * 类名称：Costparameter
    * 类功能描述：产品工时参数设置
    *
    * 创建人：付中华
    * 创建时间：2009-03-19
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class CostparameterLogic
    {
        CostparameterDB costparamDB = new CostparameterDB();

        /*
          * 方法名称：productNameLogic
          * 方法功能描述：从产品表中取出id,名称和规格表中分别取出name,model 判断工时系数表中是否存在此Id如果存在则取出存入工时
          *                  系数字段中显示 如果不存在则此值为空显示为空 
          * 参数: 
          * 
          * 创建人：付中华
          * 创建时间：2009-03-23
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        public DataTable productNameLogic()
        {
            // 产品的Id在工时系数表中的PId是否存在 如果存在则返回TRUE同时要去表中查询工时系数的值 如果不存在则返回FALSE
            bool isExist;
            DataTable dt = costparamDB.SelectProduceQuotiety();
            DataTable dtnew = new DataTable();

            dtnew.Columns.Add(new DataColumn("Pid"));
            dtnew.Columns.Add(new DataColumn("productName"));
            dtnew.Columns.Add(new DataColumn("perProductHours"));

            for(int i=0;i<dt.Rows.Count;i++)
            {
                dtnew.Rows.Add(dtnew.NewRow());
                dtnew.Rows[i][0] = dt.Rows[i][0].ToString();
                dtnew.Rows[i][1] = dt.Rows[i][1].ToString() + "_" + dt.Rows[i][2].ToString();

                isExist = costparamDB.isProductAdd(Convert.ToInt64(dtnew.Rows[i][0]));
                if (isExist)
                {
                    dtnew.Rows[i][2] = 0;                    
                }
                else
                {
                    dtnew.Rows[i][2] = costparamDB.returnQuotiety(Convert.ToInt64(dtnew.Rows[i][0])).Rows[0][0];
                }
            }
            return dtnew;
        }
        /*
         * 方法名称：saveQuotietytable
         * 方法功能描述：保存对datagridview的所有行的更改 保存时要对其判断看是要执行插入操作还是要执行更新操作
         * 参数: 
         * 
         * 创建人：付中华
         * 创建时间：2009-03-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public bool saveQuotietytable(List<produceQuotiety> list)
        {
            // 判断此产品的产品工时系数在工时系数表中是否存在 存在为false 不存在为true
            bool isExist;
            ArrayList sqlList = new ArrayList();
            string sqlStr;
            foreach (produceQuotiety proQuotiety in list)
            {
                isExist = costparamDB.isProductAdd(proQuotiety.pId);
                if (isExist)
                {
                    // 是新增的产品 执行插入操作
                    sqlStr = costparamDB.InsertProduceQuotiety(proQuotiety);
                }
                else
                {
                    // 不是新增的 执行更新操作
                    sqlStr = costparamDB.updatePerProductHours(proQuotiety);
                }
                sqlList.Add(sqlStr);
            }
            return costparamDB.Transact(sqlList);
        } 
    }
    /*
       * 类名称：expenditureName
       * 类功能描述：费用科目维护的逻辑类
       *
       * 创建人：付中华
       * 创建时间：2009-03-24
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
    class expenditureNameLogic
    {
        CostCountDB costcountDB = new CostCountDB();
        /*
         * 方法名称：saveAddSubject
         * 方法功能描述：添加科目和子科目的方法的保存操作
         * 参数: 
         * 
         * 创建人：付中华
         * 创建时间：2009-03-24
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public bool saveAddSubject(expenditureNameClass expenditureName)
        {
            ArrayList list = new ArrayList();
            string sqlStr;
            sqlStr = costcountDB.InsertExpenditureName(expenditureName);
            list.Add(sqlStr);

            return costcountDB.Transact(list);
        }
        /*
       * 方法名称：selectMaxInsertIdLogic
       * 方法功能描述：取出刚插入数据表中的最大id值赋值给刚添加的结点的Id
       * 参数: 
       *       
       * 创建人：付中华
       * 创建时间：2009-03-24
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public long selectMaxInsertIdLogic()
        {
            DataTable dt = costcountDB.selectMaxInsertId();
            long nodeId = Convert.ToInt64(dt.Rows[0][0].ToString());

            return nodeId;
        }

        /*
        * 方法名称：updateNode
        * 方法功能描述：更新结点的方法
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-03-24
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool updateNode(expenditureNameClass expenditureName)
        {
            ArrayList list = new ArrayList();
            string sqlStr;
            sqlStr = costcountDB.UpdateExpenditureName(expenditureName);
            list.Add(sqlStr);

            return costcountDB.Transact(list);
        }
        /*
        * 方法名称：
        * 方法功能描述：删除结点的方法
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-03-24
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool deleteNode(string mainId)
        {
            return costcountDB.deleteExpenditureName(mainId);
        }

        /*
       * 方法名称：expenditureNameTableDBLogic
       * 方法功能描述：查询表用来创建树
       * 参数: 
       * 
       * 创建人：付中华
       * 创建时间：2009-03-24
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable expenditureNameTableDBLogic()
        {
            return costcountDB.expenditureNameTableDB();
        }
        
    }
    /*
       * 类名称：CostEditLogic
       * 类功能描述：成本费用编辑逻辑类
       *
       * 创建人：袁宇
       * 创建时间：2009-03-25
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
    class CostEditLogic
    {
        CostCountDB dbLayer = new CostCountDB();
        /*
       * 方法名称：SetExpenditureKind
       * 方法功能描述：设置费用类别下拉列表框值
       * 参数: 
       * 
       * 创建人：袁宇
       * 创建时间：2009-03-25
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void SetExpenditureKind(ref ComboBox cb)
        {
            DataTable dt = dbLayer.SelectExpenditureNameLevel(0);
            cb.DataSource = dt;
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.SelectedIndex = -1;
        }
        /*
       * 方法名称：SetExpenditureName
       * 方法功能描述：设置费用名称下拉列表框值
       * 参数: 
       * 
       * 创建人：袁宇
       * 创建时间：2009-03-25
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void SetExpenditureName(ref ComboBox cb)
        {
            DataTable dt = dbLayer.SelectExpenditureNameLevel(1);
            cb.DataSource = dt;
            cb.DisplayMember = "name";            
            cb.ValueMember = "id";
            cb.SelectedIndex = -1;
        }
        /*
       * 方法名称：SetExpenditureDetail
       * 方法功能描述：设置费用明细下拉列表框值
       * 参数: 
       * 
       * 创建人：袁宇
       * 创建时间：2009-03-25
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void SetExpenditureDetail(ref ComboBox cb)
        {
            DataTable dt = dbLayer.SelectExpenditureNameLevel(2);
            cb.DataSource = dt;
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.SelectedIndex = -1;
 
        }
        /*
          * 方法名称：SetEquipmentName
          * 方法功能描述：设置设备名称下拉列表框值
          * 参数: 
          * 
          * 创建人：袁宇
          * 创建时间：2009-03-25
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        public void SetEquipmentName(ref ComboBox cb)
        {
            DataTable dt = dbLayer.searchEquipmentName();

            cb.DataSource = dt;
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.SelectedIndex = -1;
        }
        /*
          * 方法名称：SetProductName
          * 方法功能描述：设置产品名称下拉列表框值
          * 参数: 
          * 
          * 创建人：袁宇
          * 创建时间：2009-03-25
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        public void SetProductName(ref ComboBox cb)
        {
            DataTable dt = dbLayer.searchProductName();

            cb.DataSource = dt;
            cb.DisplayMember = "productName";
            cb.ValueMember = "id";
            cb.SelectedIndex = -1;
        }
        /*
          * 方法名称：
          * 方法功能描述：保存界面上添加的datagridview中表的内容 判断如果是eiId和pId 同时存在则保存的费用表中否则保存在待摊费用表中
          * 参数: 
          * 
          * 创建人：付中华
          * 创建时间：2009-03-26
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        public bool saveLastTable(DataTable dtLast)
        {
            expenditureClass infoOne = new expenditureClass();
            waitDetachExpenditureClass infoTwo=new waitDetachExpenditureClass();

            ArrayList sqlList = new ArrayList();
            string sqlStr;
            foreach (DataRow dr in dtLast.Rows)
            {
                if ((!dr["eiId"].ToString().Equals("")) && (!dr["pId"].ToString().Equals("")))
                {
                    infoOne.ekId = dr["ekId"].ToString();
                    infoOne.enId = dr["enId"].ToString();
                    infoOne.ecId = dr["ecId"].ToString();
                    infoOne.expenditureDepict = dr["expenditureDepict"].ToString();
                    infoOne.year = dr["year"].ToString();
                    infoOne.month = dr["month"].ToString();
                    infoOne.eiId = dr["eiId"].ToString();
                    infoOne.pId = dr["pId"].ToString();
                    infoOne.number = dr["number"].ToString();
                    infoOne.unitPrice = dr["unitPrice"].ToString();
                    infoOne.money = dr["money"].ToString();
                    infoOne.inputDate = dr["inputDate"].ToString();
                    infoOne.inputMan = dr["inputMan"].ToString();
                    infoOne.convert = dr["convert"].ToString();
                    infoOne.isAuto = "0";
                    infoOne.remark = dr["remark"].ToString();

                    sqlStr = dbLayer.insertExpenditure(infoOne);
                }
                else
                {
                    infoTwo.ekId = dr["ekId"].ToString();
                    infoTwo.enId = dr["enId"].ToString();
                    infoTwo.ecId = dr["ecId"].ToString();
                    infoTwo.expenditureDepict = dr["expenditureDepict"].ToString();
                    infoTwo.year = dr["year"].ToString();
                    infoTwo.month = dr["month"].ToString();
                    infoTwo.eiId = dr["eiId"].ToString();
                    infoTwo.pId = dr["pId"].ToString();
                    infoTwo.number = dr["number"].ToString();
                    infoTwo.unitPrice = dr["unitPrice"].ToString();
                    infoTwo.money = dr["money"].ToString();
                    infoTwo.inputDate = dr["inputDate"].ToString();
                    infoTwo.inputMan = dr["inputMan"].ToString();
                    infoTwo.convert = dr["convert"].ToString();
                    infoTwo.isAuto = "0";
                    infoTwo.remark = dr["remark"].ToString();

                    sqlStr = dbLayer.insertWaitDetachExpenditure(infoTwo);
                }
                sqlList.Add(sqlStr);
            }

            return dbLayer.Transact(sqlList);
        }
        /*
         * 方法名称：
         * 方法功能描述：保存界面上添加的datagridview中表的内容 判断如果是eiId和pId 同时存在则保存的费用表中否则保存在待摊费用表中
         * 参数: 
         * 
         * 创建人：付中华
         * 创建时间：2009-03-28
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public bool saveLastBitumenTable(DataTable dtLast)
        {
            bitumenExpenditureClass infoOne = new bitumenExpenditureClass();
            bitumenWaitDetachExpenditureClass infoTwo = new bitumenWaitDetachExpenditureClass();

            ArrayList sqlList = new ArrayList();
            string sqlStr;
            foreach (DataRow dr in dtLast.Rows)
            {
                if ((!dr["eiId"].ToString().Equals("")) && (!dr["pId"].ToString().Equals("")))
                {
                    infoOne.ekId = dr["ekId"].ToString();
                    infoOne.enId = dr["enId"].ToString();
                    infoOne.ecId = dr["ecId"].ToString();
                    infoOne.expenditureDepict = dr["expenditureDepict"].ToString();
                    infoOne.year = dr["year"].ToString();
                    infoOne.month = dr["month"].ToString();
                    infoOne.eiId = dr["eiId"].ToString();
                    infoOne.pId = dr["pId"].ToString();
                    infoOne.number = dr["number"].ToString();
                    infoOne.unitPrice = dr["unitPrice"].ToString();
                    infoOne.money = dr["money"].ToString();
                    infoOne.inputDate = dr["inputDate"].ToString();
                    infoOne.inputMan = dr["inputMan"].ToString();
                    infoOne.convert = dr["convert"].ToString();
                    infoOne.isAuto = "0";
                    infoOne.remark = dr["remark"].ToString();

                    sqlStr = dbLayer.insertExpenditure(infoOne);
                }
                else
                {
                    infoTwo.ekId = dr["ekId"].ToString();
                    infoTwo.enId = dr["enId"].ToString();
                    infoTwo.ecId = dr["ecId"].ToString();
                    infoTwo.expenditureDepict = dr["expenditureDepict"].ToString();
                    infoTwo.year = dr["year"].ToString();
                    infoTwo.month = dr["month"].ToString();
                    infoTwo.eiId = dr["eiId"].ToString();
                    infoTwo.pId = dr["pId"].ToString();
                    infoTwo.number = dr["number"].ToString();
                    infoTwo.unitPrice = dr["unitPrice"].ToString();
                    infoTwo.money = dr["money"].ToString();
                    infoTwo.inputDate = dr["inputDate"].ToString();
                    infoTwo.inputMan = dr["inputMan"].ToString();
                    infoTwo.convert = dr["convert"].ToString();
                    infoTwo.isAuto = "0";
                    infoTwo.remark = dr["remark"].ToString();

                    sqlStr = dbLayer.insertWaitDetachExpenditure(infoTwo);
                }
                sqlList.Add(sqlStr);
            }

            return dbLayer.Transact(sqlList);
        }
        /*
        * 方法名称：
        * 方法功能描述：保存界面上添加的datagridview中表的内容 判断如果是eiId和pId 同时存在则保存的费用表中否则保存在待摊费用表中
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-03-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool saveLastAlterBitumenTable(DataTable dtLast)
        {
            alterBitumenExpenditureClass infoOne = new alterBitumenExpenditureClass();
            alterBitumenWaitDetachExpenditureClass infoTwo = new alterBitumenWaitDetachExpenditureClass();

            ArrayList sqlList = new ArrayList();
            string sqlStr;
            foreach (DataRow dr in dtLast.Rows)
            {
                if ((!dr["eiId"].ToString().Equals("")) && (!dr["pId"].ToString().Equals("")))
                {
                    infoOne.ekId = dr["ekId"].ToString();
                    infoOne.enId = dr["enId"].ToString();
                    infoOne.ecId = dr["ecId"].ToString();
                    infoOne.expenditureDepict = dr["expenditureDepict"].ToString();
                    infoOne.year = dr["year"].ToString();
                    infoOne.month = dr["month"].ToString();
                    infoOne.eiId = dr["eiId"].ToString();
                    infoOne.pId = dr["pId"].ToString();
                    infoOne.number = dr["number"].ToString();
                    infoOne.unitPrice = dr["unitPrice"].ToString();
                    infoOne.money = dr["money"].ToString();
                    infoOne.inputDate = dr["inputDate"].ToString();
                    infoOne.inputMan = dr["inputMan"].ToString();
                    infoOne.convert = dr["convert"].ToString();
                    infoOne.isAuto = "0";
                    infoOne.remark = dr["remark"].ToString();

                    sqlStr = dbLayer.insertExpenditure(infoOne);
                }
                else
                {
                    infoTwo.ekId = dr["ekId"].ToString();
                    infoTwo.enId = dr["enId"].ToString();
                    infoTwo.ecId = dr["ecId"].ToString();
                    infoTwo.expenditureDepict = dr["expenditureDepict"].ToString();
                    infoTwo.year = dr["year"].ToString();
                    infoTwo.month = dr["month"].ToString();
                    infoTwo.eiId = dr["eiId"].ToString();
                    infoTwo.pId = dr["pId"].ToString();
                    infoTwo.number = dr["number"].ToString();
                    infoTwo.unitPrice = dr["unitPrice"].ToString();
                    infoTwo.money = dr["money"].ToString();
                    infoTwo.inputDate = dr["inputDate"].ToString();
                    infoTwo.inputMan = dr["inputMan"].ToString();
                    infoTwo.convert = dr["convert"].ToString();
                    infoTwo.isAuto = "0";
                    infoTwo.remark = dr["remark"].ToString();

                    sqlStr = dbLayer.insertWaitDetachExpenditure(infoTwo);
                }
                sqlList.Add(sqlStr);
            }

            return dbLayer.Transact(sqlList);
        }
        /*
          * 方法名称：DistillExpenditureTree
          * 方法功能描述：提取查询费用总信息的查询树
          * 参数: 
          * 
          * 创建人：袁宇
          * 创建时间：2009-03-26
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        public void DistillExpenditureTree(ref TreeView tree, ArrayList fields)
        {
            CostCountLogic countLogic = new CostCountLogic();
            selectExpenditureClass conds = new selectExpenditureClass();
            DataTable dt = new DataTable();
            CostCountDB dbLayer = new CostCountDB();

            dt = dbLayer.SelectAllExpenditure(conds);

            countLogic.CreateTree(ref tree,dt,fields);
        }

        public void DistillBitumenExpenditureTree(ref TreeView tree, ArrayList fields)
        {
            CostCountLogic countLogic = new CostCountLogic();
            selectBitumenExpenditureClass conds = new selectBitumenExpenditureClass();
            DataTable dt = new DataTable();
            CostCountDB dbLayer = new CostCountDB();

            dt = dbLayer.SelectAllExpenditure(conds);

            countLogic.CreateTree(ref tree,dt,fields);
        }
        public void DistillAlterBitumenExpenditureTree(ref TreeView tree, ArrayList fields)
        {
            CostCountLogic countLogic = new CostCountLogic();
            selectAlterBitumenWaitDetachExpenditure conds = new selectAlterBitumenWaitDetachExpenditure();            
            DataTable dt = new DataTable();
            CostCountDB dbLayer = new CostCountDB();
            dt = dbLayer.SelectAllExpenditure(conds);

            countLogic.CreateTree(ref tree, dt, fields);
        }
        /*
         * 方法名称：SelectAllData
         * 方法功能描述：查询混合料
         * 参数: 
         * 
         * 创建人：袁宇
         * 创建时间：2009-03-26
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataTable SelectAllData(selectExpenditureClass conds)
        {
            CostCountDB dbLayer = new CostCountDB();
            DataTable dt = new DataTable();

            dt = dbLayer.SelectAllExpenditure(conds);

            return dt;
        }
        /*
        * 方法名称：SelectAllData
        * 方法功能描述：查询沥青
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-03-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SelectAllData(selectBitumenExpenditureClass conds)
        {
            CostCountDB dbLayer = new CostCountDB();
            DataTable dt = new DataTable();

            dt = dbLayer.SelectAllExpenditure(conds);

            return dt;
        }
        /*
       * 方法名称：SelectAllData
       * 方法功能描述：查询改性沥青和乳化沥青
       * 参数: 
       * 
       * 创建人：付中华
       * 创建时间：2009-03-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable SelectAllData(selectAlterBitumenWaitDetachExpenditure conds)
        {
            CostCountDB dbLayer = new CostCountDB();
            DataTable dt = new DataTable();

            dt = dbLayer.SelectAllExpenditure(conds);

            return dt;
        }
    }
    /*
      * 类名称：CostCountDetailLogic
      * 类功能描述：成本核算中的combobox提值以及删除等方法的逻辑类
      *
      * 创建人：付中华
      * 创建时间：2009-03-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class CostCountDetailLogic
    {
        CostCountDetailDB costCountDetailLogic = new CostCountDetailDB();
        CostCountDB costDb = new CostCountDB();
        /*
        * 方法名称：distillProductNameLogic
        * 方法功能描述：返回产品名称 pnId name
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-03-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable distillProductNameLogic()
        {
            return costCountDetailLogic.distillProductNameDb();
        }
        /*
        * 方法名称：distillProductModelLogic
        * 方法功能描述：返回产品规格 pmId name
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-03-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable distillProductModelLogic(long pnId)
        {
            return costCountDetailLogic.distillProductModeDb(pnId);
        }
        /*
        * 方法名称：distillEquipmentNameLogic
        * 方法功能描述：返回设备名称 enId name
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-03-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable distillEquipmentNameLogic()
        {
            return costCountDetailLogic.distillEquipmentName();
        }
        /*
        * 方法名称：distillEquipmentModelLogic
        * 方法功能描述：返回设备规格 emId model
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-03-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable distillEquipmentModelLogic(long enId)
        {
            return costCountDetailLogic.distillEquipmentModelDb(enId);
        }
        /*
        * 方法名称：
        * 方法功能描述：删除混合料费用表中的一行
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-03-27
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool deleteExpenditureLogic(long id)
        {
            return costDb.deleteExpenditure(id);
        }
        /*
         * * 方法名称：
       * 方法功能描述：删除沥青费用表中的一行
       * 参数: 
       * 
       * 创建人：付中华
       * 创建时间：2009-03-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool deleteBitumenExpenditureLogic(long id)
        {
            return costDb.deleteBitumenExpenditure(id);
        }
        /*
     * 方法名称：
     * 方法功能描述：删除改性沥青和乳化沥青费用表中的一行
     * 参数: 
     * 
     * 创建人：付中华
     * 创建时间：2009-03-28
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        public bool deleteAlterBitumenExpenditureLogic(long id)
        {
            return costDb.deleteAlterBitumenExpenditure(id);
        }
        /*
        * 方法名称：
        * 方法功能描述：删除混合料待摊费用表中的一行
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-03-27
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool deleteWaitDetachExpenditureLogic(long id)
        {
            return costDb.deleteWaitDetachExpenditure(id);
        }
        /*
        * 方法名称：
        * 方法功能描述：删除沥青待摊费用表中的一行
        * 参数: 
        * 
        * 创建人：付中华
        * 创建时间：2009-03-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool deleteBitumenWaitDetachExpenditureLogic(long id)
        {
            return costDb.deleteBitumenWaitDetachExpenditure(id);
        }
        /*
       * 方法名称：
       * 方法功能描述：删除改性沥青和乳化沥青待摊费用表中的一行
       * 参数: 
       * 
       * 创建人：付中华
       * 创建时间：2009-03-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool deleteAlterBitumenWaitDetachExpenditureLogic(long id)
        {
            return costDb.deleteAlterBitumenWaitDetachExpenditure(id);
        }

    }
    /*
      * 类名称：ManExpenditureLogic
      * 类功能描述：直接人工费用获取逻辑
      *
      * 创建人：袁宇
      * 创建时间：2009-03-27
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class ManExpenditureLogic
    {
        ManExpenditureDB dbLayer = new ManExpenditureDB();

        public DataTable SetProduceTeam()
        {
            return dbLayer.SelectProduceTeam();
        }
 
    }
    /*
      * 类名称：StuffExpenditureLogic
      * 类功能描述：直接材料费用获取逻辑
      *
      * 创建人：袁宇
      * 创建时间：2009-03-27
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class StuffExpenditureLogic
    {
        StuffExpenditureDB dbLayer = new StuffExpenditureDB();

        public DataTable GetBitumenStuffExpenditure(string year, string month)
        {
            DataTable dt = new DataTable();

            dt = dbLayer.SelectBitumenStuff(year, month);
            return dt;
        }
        public DataTable GetMixStuffExpenditure(string year, string month)
        {
            DataTable dt = new DataTable();

            dt = dbLayer.SelectMixStuff(year, month);
            return dt;
        }

        public DataTable groupBitumenStuffExpenditure(ref DataTable dt)
        {
            DataTable recDt = new DataTable();
            #region
            //recDt.Columns.Add("产品编号"); 
            //recDt.Columns.Add("产品名称");
            //recDt.Columns.Add("年份");
            //recDt.Columns.Add("月份");
            //recDt.Columns.Add("费用描述");
            //recDt.Columns.Add("设备编号");            
            //recDt.Columns.Add("数量");
            //recDt.Columns.Add("单价");
            //recDt.Columns.Add("金额");
            //var g = from DataRow row in dt.Rows
            //        group row by new { no = row["产品编号"], memo = row["费用描述"] ,sb = row["设备编号"]} into group1                    
            //        select new
            //        {                   
            //            产品编号     = group1.First()["产品编号"],
            //            产品名称     = group1.First()["产品名称"],
            //            年份         = group1.First()["年份"],
            //            月份         = group1.First()["月份"],
            //            费用描述     = group1.First()["费用描述"],
            //            设备编号     = group1.First()["设备编号"],                        
            //            单价        = group1.First()["单价"],
            //            总数量      = (from ele in group1
            //                           select Double.Parse(ele["数量"].ToString())).Sum(),
            //            金额        = (from el in group1
            //                           select Double.Parse(el["金额"].ToString())).Sum()
            //        };
            //foreach (var e in g)
            //{
            //    recDt.Rows.Add(e.产品编号, e.产品名称, e.年份, e.月份, e.费用描述, e.设备编号, e.总数量, e.单价, e.金额);

            //} 
            #endregion
            recDt.Columns.Add("expenditureType");
            recDt.Columns.Add("expenditureDepict");
            recDt.Columns.Add("yearDate");
            recDt.Columns.Add("monthDate");
            recDt.Columns.Add("equipmentNo");
            recDt.Columns.Add("equipmentId");

            recDt.Columns.Add("pId");
            
            recDt.Columns.Add("productName");                      
            recDt.Columns.Add("quantity");
            recDt.Columns.Add("unitPrice");
            recDt.Columns.Add("totalExpenditure");
            recDt.Columns.Add("ekId");
            var g = from DataRow row in dt.Rows
                    group row by new { no = row["产品编号"], memo = row["费用描述"], sb = row["设备编号"] } into group1
                    select new
                    {
                        expenditureType=group1.First()["费用类别"],
                        expenditureDepict = group1.First()["费用描述"],
                        yearDate = group1.First()["年份"],
                        monthDate = group1.First()["月份"],
                        equipmentNo = group1.First()["设备编号"],
                        equipmentId = group1.First()["设备序号"],
                        pId = group1.First()["产品编号"],
                        productName = group1.First()["产品名称"],
                        quantity = (from ele in group1
                                    select Double.Parse(ele["数量"].ToString())).Sum(),              
                     
                        unitPrice = group1.First()["单价"],
                        
                        totalExpenditure = (from el in group1
                                            select Double.Parse(el["金额"].ToString())).Sum(),
                        ID = group1.First()["ekid"]
                    };
            foreach (var e in g)
            {
                recDt.Rows.Add(e.expenditureType ,e.expenditureDepict, e.yearDate, e.monthDate, e.equipmentNo, e.equipmentId, e.pId ,e.productName, e.quantity, e.unitPrice, e.totalExpenditure, e.ID);
            }              
                        
            return recDt;
 
        }
      
        private CaleBitumenHeatCostClass distillHeatTable()
        {
            throw new NotImplementedException();
        }

    }
    /*
          * 类名称：bitumenCostCountLogic
          * 类功能描述：沥青费用中的直接材料费用的获取
          *
          * 创建人：付中华
          * 创建时间：2009-03-30
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
    class bitumenCostCountLogic
    {
        bitumenCostCountDB bitumenCostLogic = new bitumenCostCountDB();

        CostCountDB dbLayer = new CostCountDB();
        /*
* 方法名称：
* 方法功能描述：用于获取沥青费用中的直接人工费用的方法主要是归集工资额
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-03-30
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable getDirectPersonCostLogic(long id, int month,string year)
        {
            return bitumenCostLogic.getDirectPersonCost(id, month,year);
        }

        /*
* 方法名称：autoFuelDriveExpenditureLogic
* 方法功能描述：沥青加热成本自动获取中的燃料动力费
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-14
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable autoFuelDriveExpenditureLogic(string year,string  month)
        {
            DataTable dtnew = new DataTable();
            DataTable dt=bitumenCostLogic.autoFuelDriveExpenditure(year, month);


            dtnew.Columns.Add(new DataColumn("expenditureType"));
            dtnew.Columns.Add(new DataColumn("expenditureDepict"));
            dtnew.Columns.Add(new DataColumn("yearDate"));
            dtnew.Columns.Add(new DataColumn("monthDate"));
            dtnew.Columns.Add(new DataColumn("equipmentNo"));
            dtnew.Columns.Add(new DataColumn("equipmentId"));
            dtnew.Columns.Add(new DataColumn("productName"));
            dtnew.Columns.Add(new DataColumn("quantity"));
            dtnew.Columns.Add(new DataColumn("unitPrice"));
            dtnew.Columns.Add(new DataColumn("totalExpenditure"));

            dtnew.Columns.Add(new DataColumn("ekId"));
            dtnew.Columns.Add(new DataColumn("pId"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtnew.Rows.Add(dtnew.NewRow());

                dtnew.Rows[i][0] = "燃料动力费";
                dtnew.Rows[i][1] = "自动归集:" + dt.Rows[i][7].ToString() + "_" + dt.Rows[i][8].ToString();
                dtnew.Rows[i][2] = dt.Rows[i][0];
                dtnew.Rows[i][3] = dt.Rows[i][1];
                dtnew.Rows[i][4] = dt.Rows[i][2];
                dtnew.Rows[i][5] = dt.Rows[i][3];
                dtnew.Rows[i][6] = dt.Rows[i][4];
                dtnew.Rows[i][7] = dt.Rows[i][5];
                dtnew.Rows[i][8] = dt.Rows[i][6];
                dtnew.Rows[i][9] = Convert.ToString(float.Parse(dt.Rows[i][5].ToString()) * float.Parse(dt.Rows[i][6].ToString()));
                dtnew.Rows[i][10] = this.getExpenditureTypeIdLogic("燃料动力费").Rows[0][0];
                dtnew.Rows[i][11] = dt.Rows[i][9];
            }

            return dtnew;          

        }
        /*
* 方法名称：groupBitumenFuelDrive
* 方法功能描述：沥青加热成本自动获取中的燃料动力费分组方法
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-14
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/

        public DataTable groupBitumenFuelDrive(ref DataTable dt)
        {
            DataTable recDt = new DataTable();
          
            recDt.Columns.Add("expenditureType");
            recDt.Columns.Add("expenditureDepict");
            recDt.Columns.Add("yearDate");
            recDt.Columns.Add("monthDate");
            recDt.Columns.Add("equipmentNo");
            recDt.Columns.Add("equipmentId");           
            recDt.Columns.Add("productName");
            recDt.Columns.Add("quantity");
            recDt.Columns.Add("unitPrice");
            recDt.Columns.Add("totalExpenditure");
            recDt.Columns.Add("ekId");
            recDt.Columns.Add("pId");
            var g = from DataRow row in dt.Rows
                    group row by new { no = row["pId"], memo = row["expenditureDepict"], sb = row["equipmentNo"] } into group1
                    select new
                    {
                        expenditureType = group1.First()["expenditureType"],
                        expenditureDepict = group1.First()["expenditureDepict"],
                        yearDate = group1.First()["yearDate"],
                        monthDate = group1.First()["monthDate"],
                        equipmentNo = group1.First()["equipmentNo"],
                        equipmentId = group1.First()["equipmentId"],

                        productName = group1.First()["productName"],
                        quantity = (from ele in group1
                                    select Double.Parse(ele["quantity"].ToString())).Sum(),

                        unitPrice = group1.First()["unitPrice"],

                        totalExpenditure = (from el in group1
                                            select Double.Parse(el["totalExpenditure"].ToString())).Sum(),
                        ID = group1.First()["ekid"],
                        pId=group1.First()["pId"]
                    };
            foreach (var e in g)
            {
                recDt.Rows.Add(e.expenditureType, e.expenditureDepict, e.yearDate, e.monthDate, e.equipmentNo, e.equipmentId, e.productName, e.quantity, e.unitPrice, e.totalExpenditure, e.ID,e.pId );
            }
            return recDt;

        }
        /*
* 方法名称：
* 方法功能描述：用于获取沥青费用中的直接人工费用的方法 主要是取设备编号和设备的idz值
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-03-30
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable getEquipmentNoAndIdLogic(long id)
        {
            return bitumenCostLogic.getEquipmentNoAndId(id);
        }
        /*
* 方法名称：saveAutoCostTable
* 方法功能描述：自动获取费用界面中的各种费用的保存即界面中的成本导入按钮的方法要先判断是分摊的费用还是直接分配到产品上的费用
         * 混合料的导入成本
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-03-31
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public bool saveAutoCostTable(DataTable dtLast)
        {
            expenditureClass infoOne = new expenditureClass();
            waitDetachExpenditureClass infoTwo = new waitDetachExpenditureClass();

            ArrayList sqlList = new ArrayList();
            string sqlStr;
            foreach (DataRow dr in dtLast.Rows)
            {
                // 如果设备编号不为空同时产品不为空的时候插入到沥青费用表中否则插入到沥青待摊费用表中
                if ((!dr["equipmentId"].ToString().Equals("")) && (!dr["productName"].ToString().Equals(""))&&((!dr["pId"].ToString().Equals(""))))
                {
                    infoOne.ekId = dr["ekId"].ToString();
                    
                    infoOne.expenditureDepict = dr["expenditureDepict"].ToString();
                    infoOne.year = dr["yearDate"].ToString();
                    infoOne.month = dr["monthDate"].ToString();
                    infoOne.eiId = dr["equipmentId"].ToString();
                    infoOne.pId =dr["pId"].ToString();
                    infoOne.number = dr["quantity"].ToString();
                    infoOne.unitPrice = dr["unitPrice"].ToString();
                    infoOne.money = dr["totalExpenditure"].ToString();
                    infoOne.isAuto = "1";
                   

                    sqlStr = dbLayer.insertExpenditure(infoOne);
                }
                else
                {
                    infoTwo.ekId = dr["ekId"].ToString();
                    
                    infoTwo.expenditureDepict = dr["expenditureDepict"].ToString();
                    infoTwo.year = dr["yearDate"].ToString();
                    infoTwo.month = dr["monthDate"].ToString();
                    infoTwo.eiId = dr["equipmentId"].ToString();
                    infoTwo.pId =dr["pId"].ToString();
                    infoTwo.number = dr["quantity"].ToString();
                    infoTwo.unitPrice = dr["unitPrice"].ToString();
                    infoTwo.money = dr["totalExpenditure"].ToString();
                    infoTwo.isAuto = "1";
                  

                    sqlStr = dbLayer.insertWaitDetachExpenditure(infoTwo);
                }
                sqlList.Add(sqlStr);
            }
            return dbLayer.Transact(sqlList);
        }
        /*
* 方法名称：
* 方法功能描述：根据名称取得费用类别的Id号
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-03-31
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public DataTable getExpenditureTypeIdLogic(string expenditureType)
        {
            if (bitumenCostLogic.getExpenditureTypeId(expenditureType).Rows.Count != 0)
            {
                return bitumenCostLogic.getExpenditureTypeId(expenditureType);
            }
            else
            {
                return null;
            }
        }
        /*
* 方法名称：saveAutoLastBitumenTable
* 方法功能描述：沥青的导入成本
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-03-31
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public bool saveAutoLastBitumenTable(DataTable dtLast)
        {
            bitumenExpenditureClass infoOne = new bitumenExpenditureClass();
            bitumenWaitDetachExpenditureClass infoTwo = new bitumenWaitDetachExpenditureClass();

            ArrayList sqlList = new ArrayList();
            string sqlStr;
            foreach (DataRow dr in dtLast.Rows)
            {
                if (dr["totalExpenditure"].ToString().Equals(""))
                { }
                else
                {
                    if ((!dr["equipmentId"].ToString().Equals("")) && (!dr["productName"].ToString().Equals("")&&(!dr["pId"].ToString().Equals(""))))
                    {
                        infoOne.ekId = dr["ekId"].ToString();

                        infoOne.expenditureDepict = dr["expenditureDepict"].ToString();
                        infoOne.year = dr["yearDate"].ToString();
                        infoOne.month = dr["monthDate"].ToString();
                        infoOne.eiId = dr["equipmentId"].ToString();
                        infoOne.pId = dr["pId"].ToString();

                        infoOne.number = dr["quantity"].ToString();
                        infoOne.unitPrice = dr["unitPrice"].ToString();
                        infoOne.money = dr["totalExpenditure"].ToString();
                        infoOne.isAuto = "1";

                        sqlStr = dbLayer.insertExpenditure(infoOne);
                    }
                    else
                    {
                        infoTwo.ekId = dr["ekId"].ToString();

                        infoTwo.expenditureDepict = dr["expenditureDepict"].ToString();
                        infoTwo.year = dr["yearDate"].ToString();
                        infoTwo.month = dr["monthDate"].ToString();
                        infoTwo.eiId = dr["equipmentId"].ToString();
                        infoTwo.pId = dr["pId"].ToString();

                        infoTwo.number = dr["quantity"].ToString();
                        infoTwo.unitPrice = dr["unitPrice"].ToString();
                        infoTwo.money = dr["totalExpenditure"].ToString();
                        infoTwo.isAuto = "1";
                        sqlStr = dbLayer.insertWaitDetachExpenditure(infoTwo);
                    }
                    sqlList.Add(sqlStr);
                }
            }

            return dbLayer.Transact(sqlList);
        }
        /*
* 方法名称：saveAutoAlterExpenditure
* 方法功能描述：改性沥青和乳化沥青中的导入成本方法
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-03-31
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public bool saveAutoAlterExpenditure(DataTable dtLast)
        {
            alterBitumenExpenditureClass infoOne = new alterBitumenExpenditureClass();
            alterBitumenWaitDetachExpenditureClass infoTwo = new alterBitumenWaitDetachExpenditureClass();

            ArrayList sqlList = new ArrayList();
            string sqlStr;
            foreach (DataRow dr in dtLast.Rows)
            {
                if (!dr["totalExpenditure"].ToString().Equals(""))
                {
                    if ((!dr["equipmentId"].ToString().Equals("")) && (!dr["productName"].ToString().Equals("")&&(!dr["pId"].ToString().Equals(""))))
                    {
                        infoOne.ekId = dr["ekId"].ToString();
                      
                        infoOne.expenditureDepict = dr["expenditureDepict"].ToString();
                        infoOne.year = dr["yearDate"].ToString();
                        infoOne.month = dr["monthDate"].ToString();
                        infoOne.eiId = dr["equipmentId"].ToString();
                        infoOne.pId = dr["pId"].ToString();                      
                        infoOne.number = dr["quantity"].ToString();
                        infoOne.unitPrice = dr["unitPrice"].ToString();
                        infoOne.money = dr["totalExpenditure"].ToString();
                        infoOne.isAuto = "1";
                       

                        sqlStr = dbLayer.insertExpenditure(infoOne);
                    }
                    else
                    {
                        infoTwo.ekId = dr["ekId"].ToString();
                      
                        infoTwo.expenditureDepict = dr["expenditureDepict"].ToString();
                        infoTwo.year = dr["yearDate"].ToString();
                        infoTwo.month = dr["monthDate"].ToString();
                        infoTwo.eiId = dr["equipmentId"].ToString();
                        infoTwo.pId = dr["pId"].ToString();
                        infoTwo.number = dr["quantity"].ToString();
                        infoTwo.unitPrice = dr["unitPrice"].ToString();
                        infoTwo.money = dr["totalExpenditure"].ToString();
                        infoTwo.isAuto = "1";
                      

                        sqlStr = dbLayer.insertWaitDetachExpenditure(infoTwo);
                    }
                    sqlList.Add(sqlStr);
                }
            }

            return dbLayer.Transact(sqlList);
        }
        /*
* 方法名称：isAutoBitumemLogic
* 方法功能描述：查找直接人工费用在待摊费用表中是否已经存储过了针对沥青加热的自动获取费用
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-09
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public string isAutoBitumemLogic(directManEntityClass directManEntity)
        {
            return bitumenCostLogic.isAutoBitumen(directManEntity);
        }

        /*
* 方法名称：isAutoAlterBitumenLogic
* 方法功能描述：查找直接人工费用在待摊费用表中是否已经存储过了针对改性沥青和乳化沥青试验的自动获取费用
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-10
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public string isAutoAlterBitumenLogic(directManEntityClass directManEntity)
        {
            return bitumenCostLogic.isAutoAlterBitumen(directManEntity);
        }

        /*
* 方法名称：
* 方法功能描述：查找直接人工费用在待摊费用表中是否已经存储过了针对改性沥青和乳化沥青试验的自动获取费用
* 参数: 
* 
* 创建人：付中华
* 创建时间：2009-04-10
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
        public string isAutoMixerLogic(directManEntityClass directManEntity)
        {
            return bitumenCostLogic.isAutoMixer(directManEntity);
        }
    }
    class CaleBitumenHeatCostLogic
    {
        CaleBitumenHeatCostDb caleBitumen=new CaleBitumenHeatCostDb();
        costDetachDB db = new costDetachDB();   
        #region
        //public DataTable gatherBitumenHeatCostLogic(string year, string month)
        //{
        //    return caleBitumen.gatherBitumenHeatCost(year, month);
        //}

        //public DataTable gatherAlterBitumenCostLogic(string year, string month)
        //{
        //    return caleBitumen.gatherAlterBitumenCost(year, month);
        //}

        //public DataTable gatherMixCostLogic(string year, string month)
        //{
        //    return caleBitumen.gatherMixCost(year, month);
        //}
        #endregion 

        public DataTable getherMaxCostEquipLogic(CaleBitumenHeatCostClass conds)
        {
            return caleBitumen.gatherMixCostEquip(conds); 
        }
        public DataTable gatherBitumenHeatCostEquipLogic(CaleBitumenHeatCostClass conds)
        {
            return caleBitumen.gatherBitumenHeatCostEquip(conds);
        }
        public DataTable gatherAlterBitumenCostEquipLogic(CaleBitumenHeatCostClass conds)
        {
            return caleBitumen.gatherAlterBitumenCostEquip(conds);
        }
        public void OneDataTable(DataTable dt, int conds)
        {
            dt.Columns.Add("quantity");
            dt.Columns.Add("unitPrice");
            var bExist = (from DataColumn col in dt.Columns
                          where col.ColumnName == "equipmentNo"
                          select col).Count() > 0;
            if (!bExist)
            {
                dt.Columns.Add("equipmentNo");
            }

            foreach (DataRow dr in dt.Rows)
            {
                string year = dr["year"].ToString();
                string month = dr["month"].ToString();

                switch (conds)
                {
                    case 1:
                        DataTable dtQuantity = db.SelectbitumenDetachParameter(year, month, 1);
                        foreach (DataRow drq in dtQuantity.Rows)
                        {
                            if (dr["pId"].ToString() == drq["pId"].ToString())
                            {
                                dr["quantity"] = drq["产量"];
                                if (drq["产量"].ToString() != "")
                                {
                                    dr["unitPrice"] = Convert.ToString(Math.Round((Convert.ToDouble(dr["money"]) / Convert.ToDouble(dr["quantity"])), 2));
                                }
                            }
                        }
                        break;
                    case 2:
                        DataTable dtQuantity1 = db.SelectbitumenDetachParameter(year, month, 2);
                        foreach (DataRow drq in dtQuantity1.Rows)
                        {
                            if (dr["pId"].ToString() == drq["pId"].ToString())
                            {
                                dr["quantity"] = drq["产量"];
                                if (drq["产量"].ToString() != "")
                                {
                                    dr["unitPrice"] = Convert.ToString(Math.Round((Convert.ToDouble(dr["money"]) / Convert.ToDouble(dr["quantity"])), 2));
                                }
                            }
                        }
                        break;
                    case 3:
                        DataTable dtQuantity2 = db.SelectbitumenDetachParameter(year, month, 3);
                        foreach (DataRow drq in dtQuantity2.Rows)
                        {
                            if (dr["pId"].ToString() == drq["pId"].ToString())
                            {
                                dr["quantity"] = drq["产量"];
                                if (drq["产量"].ToString() != "")
                                {
                                    dr["unitPrice"] = Convert.ToString(Math.Round((Convert.ToDouble(dr["money"]) / Convert.ToDouble(dr["quantity"])), 2));
                                }
                            }
                        }
                        break;
                }
            }
        }

    }
}
