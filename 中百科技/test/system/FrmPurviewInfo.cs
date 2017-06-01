/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：FrmPurviewInfo.cs
     * 文件功能描述：权限信息窗体
     *
     * 创建人： 冯雪
     * 创建时间：2009-02-11
     *
     * 修改人：金鹤 
     * 修改时间：20090217
     * 修改内容：编码实现
     *
     */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using System.Collections;


namespace DasherStation.system
{
    public partial class FrmPurviewInfo : common.BaseForm
    {

        //实力化数据库访问类
        SqlHelper sqlHelper = new SqlHelper();

        //记录当前被修改的用户ID
        string puiid = null;

        //记录当前被修改的用户名
        string pUserName = null;

        //负责当前数据库操作的基础类库
        Database db = DatabaseFactory.CreateDatabase();

        //系统所具有的所有菜单
        DataSet dsAll = null;

        //用户具有权限的
        DataSet dsUser = null;

        //权限数的节点集合
        private TreeNodeCollection tNodes;

        public FrmPurviewInfo()
        {
            InitializeComponent();
            
        }


        private void FrmPurviewInfo_Load(object sender, EventArgs e)
        {

            try
            {
                ArrayList list = new ArrayList();

                list.Add("select id,name,isnull(parentid,0) parentid  from menu");

                //从数据库中读取出全部菜单项
                dsAll = sqlHelper.QueryForDateSet(list);

                

                //绑定用户基本信息
                UserDataBind();

                //绑定权限摸版
                ModelBind();

                this.dataGridView1.SelectionChanged += (dataGridView1_SelectionChanged);
            }
            catch (Exception ex)
            {
                new Logging(6000, ex, "FrmPurviewInfo_Load加载窗体失败");
                MessageBox.Show("权限管理窗体加载失败");
            }
            finally
            {

            }

        }

        /*
        * 方法名称：UserDataBind
        * 方法功能描述：查询用户的基本信息,绑定到截面dataGridView上
        *
        * 创建人：金鹤
        * 创建时间：20080217
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        private void UserDataBind()
        {
            try
            {
                ArrayList list = new ArrayList();

                list.Add("select id,username,name from usersinfo");

                this.dataGridView1.DataSource = sqlHelper.QueryForDateSet(list).Tables[0];
            }
            catch (Exception ex)
            {
                new Logging(6001, ex, "UserDataBind()绑定用户基本信息执行错误");
                MessageBox.Show("用户基本信息绑定失败");
            }
            finally
            {

            }

        }

        /*
        * 方法名称：CreatTree
        * 方法功能描述：根据用户名查询出该用户具有权限的菜单,绑定到数据集中
        *
        * 创建人：金鹤
        * 创建时间：20080217
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        private void CreatTree(string username)
        {
            //try
            //{
                dsUser = new DataSet();

                ArrayList list = new ArrayList();

                list.Add("select um.id,um.uiid,um.mid from usersinfo ui,userPopedomCorresponding um where ui.id=um.uiid  and ui.username='" + username + "'");

                dsUser = sqlHelper.QueryForDateSet(list);

                dsUser.Tables[0].TableName = "UserMenu";

                CreatTreeView();
            //}
            //catch (Exception ex)
            //{
            //    new Logging(6002, ex, "CreatTree读取用户菜单失败");
            //    MessageBox.Show("读取用户菜单失败");
            //}
            //finally
            //{

            //}

        }

        /*
        * 方法名称：CreatTreeView
        * 方法功能描述：创建用户的权限树
        *
        * 创建人：金鹤
        * 创建时间：20080217
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        private void CreatTreeView()
        {
            //try
            //{
                treeView1.Nodes.Clear();
                tNodes = treeView1.Nodes;
                foreach (DataRowView datav in dsAll.Tables[0].DefaultView)
                {
                    if (datav["parentId"].ToString().Trim() == "0")
                    {

                        TreeNode tn = new TreeNode();
                        tn.Name = datav["id"].ToString();
                        tn.Text = datav["name"].ToString();
                        tn.Checked = checkUserMenu(tn);
                        tNodes.Add(tn);

                    }
                }

                foreach (TreeNode nodeP in tNodes)
                {
                    CreatNode(nodeP);
                }

            //}
            //catch (Exception ex)
            //{
            //    new Logging(6003, ex, "CreatTreeView用户权限树构建失败");
            //    MessageBox.Show("用户权限树构建失败");
            //}
            //finally
            //{

            //}
        }

        /*
        * 方法名称：CreatNode
        * 方法功能描述：创建用户的权限树
        *
        * 创建人：金鹤
        * 创建时间：20080217
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        private void CreatNode(TreeNode nodeP)
        {
            try
            {
                foreach (DataRowView datav in dsAll.Tables[0].DefaultView)
                {
                    if (datav["parentId"].ToString().Trim() == nodeP.Name)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Name = datav["id"].ToString();
                        tn.Text = datav["name"].ToString();
                        tn.Checked = checkUserMenu(tn);
                        nodeP.Nodes.Add(tn);
                        CreatNode(tn);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        /*
        * 方法名称：checkUserMenu
        * 方法功能描述：判断用户是否具有特定权限
        *
        * 创建人：金鹤
        * 创建时间：20080217
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        private bool checkUserMenu(TreeNode tn)
        {

                foreach (DataRowView datav in dsUser.Tables[0].DefaultView)
                {
                    if (tn.Name == datav["mid"].ToString())
                    {
                        return true;
                    }
                }
                return false;

            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
                //判断用户是否只选择了一行数据
                if (this.dataGridView1.SelectedRows.Count == 1)
                {
                    this.puiid = this.dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                    this.pUserName = this.dataGridView1.SelectedRows[0].Cells["userid"].Value.ToString();

                    //重新根据用户所选的用户权限构建权限树
                    CreatTree(this.pUserName);
                }
            //}
            //catch (Exception ex)
            //{
            //    new Logging(6004, ex, "dataGridView1_SelectionChanged用户权限树构建失败");
            //    MessageBox.Show("用户权限树构建失败");
            //}
            //finally
            //{

            //}          
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //try
            //{
                //修改单选框状态的同时更新用户的权限
                changeMenu(e.Node.Name.ToString());
                if (e.Node.Checked == true)
                {
                    //foreach(TreeNode tn in e.Node.Nodes)
                    //{
                    //    tn.Checked = true;
                    //}
                    upCheck(e.Node);
                }
                else
                {
                    downCheck(e.Node);
                }
            //}
            //catch (Exception ex)
            //{
            //    new Logging(6005, ex, "treeView1_AfterCheck更改用户权限失败");
            //    MessageBox.Show("更改用户权限失败");
            //}
            //finally
            //{

            //}       
        }

        //private void ChildCheck(TreeNode tn)
        //{
 
        //}

        /*
        * 方法名称：upCheck
        * 方法功能描述：判断父节点的状态并且更新父节点
        *
        * 创建人：金鹤
        * 创建时间：20080217
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        private void upCheck(TreeNode tn)
        {
            try
            {
                TreeNode ptn = tn.Parent;
                if (ptn != null)
                {
                    if (ptn.Checked != tn.Checked)
                    {
                        ptn.Checked = tn.Checked;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
           
        }

        /*
         * 方法名称：downCheck
         * 方法功能描述：判断子节点的状态并且更新子节点
         *
         * 创建人：金鹤
         * 创建时间：20080217
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void downCheck(TreeNode tn)
        {
            try
            {
                foreach (TreeNode ctn in tn.Nodes)
                {
                    if (ctn.Checked != tn.Checked)
                    {
                        ctn.Checked = tn.Checked;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
           
        }

        /*
         * 方法名称：changeMenu
         * 方法功能描述：修改数据集中用户的权限
         *
         * 创建人：金鹤
         * 创建时间：20080217
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void changeMenu(string mid)
        {
            try
            {
                foreach (DataRow datav in dsUser.Tables[0].Rows)
                {
                    if (datav.RowState != DataRowState.Deleted)
                    {
                        if (mid == datav["mid"].ToString())
                        {
                            datav.Delete();
                            //datav.AcceptChanges();
                            return;
                        }
                    }
                }
                AddNodes(mid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        /*
         * 方法名称：AddNodes
         * 方法功能描述：修改数据集增加新的用户的权限
         *
         * 创建人：金鹤
         * 创建时间：20080217
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void AddNodes(string mid)
        {
            try
            {
                foreach (DataRow datav in dsUser.Tables[0].Rows)
                {
                    if (datav.RowState == DataRowState.Deleted)
                    {
                        datav.RejectChanges();
                        if (mid == datav["mid"].ToString())
                        {
                            return;
                        }
                        datav.Delete();
                    }
                }
                DataRow dr = dsUser.Tables[0].NewRow();
                dr["uiid"] = this.puiid;
                dr["mid"] = mid;
                dsUser.Tables[0].Rows.Add(dr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                saveChange();
                CreatTree(this.pUserName);

            }
            catch (Exception ex)
            {
                new Logging(6006, ex, "btn_save_Click保存用户权限失败");
                MessageBox.Show("保存用户权限失败");
            }
            finally
            {

            }
           
        }

        /*
         * 方法名称：saveChange
         * 方法功能描述：保存用户的权限
         *
         * 创建人：金鹤
         * 创建时间：20080217
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void saveChange()
        {
            try
            {
                DbCommand insertCommand = db.GetSqlStringCommand("insert into userPopedomCorresponding(uiid,mId) values(@uiid,@mId)");
                db.AddInParameter(insertCommand, "uiid", DbType.Int32, "uiid", DataRowVersion.Current);
                db.AddInParameter(insertCommand, "mId", DbType.Int32, "mId", DataRowVersion.Current);

                DbCommand deleteCommand = db.GetSqlStringCommand("delete from userPopedomCorresponding where id=@id");
                db.AddInParameter(deleteCommand, "id", DbType.Int32, "id", DataRowVersion.Current);

                DbCommand updateCommand = db.GetSqlStringCommand("update userPopedomCorresponding set uiid=@uiid,mId=@mId where id=@id");
                db.AddInParameter(updateCommand, "id", DbType.Int32, "id", DataRowVersion.Current);
                db.AddInParameter(updateCommand, "uiid", DbType.Int32, "uiid", DataRowVersion.Current);
                db.AddInParameter(updateCommand, "mId", DbType.Int32, "mId", DataRowVersion.Current);
                
                int result = db.UpdateDataSet(dsUser, "UserMenu", insertCommand, updateCommand,
                                                   deleteCommand, UpdateBehavior.Standard);           
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TreeNode tn in treeView1.Nodes)
                {
                    if (tn.Checked == true)
                    {
                        tn.Checked = false;
                        downCheck(tn);
                    }
                }
            }
            catch (Exception ex)
            {
                new Logging(6007, ex, "btn_clear_Click清空权限失败");
                MessageBox.Show("清空权限失败");
            }
            finally
            {

            }
           
        }


        /*
         * 方法名称：ModelBind
         * 方法功能描述：用户权限模版绑定
         *
         * 创建人：金鹤
         * 创建时间：20080217
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void ModelBind()
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("ID");
                table.Columns.Add("Value");

                DataRow row = table.NewRow();
                row["id"] = "0";
                row["Value"] = "选择权限摸板";
                table.Rows.Add(row);

                row = table.NewRow();
                row["id"] = "1";
                row["Value"] = "库存管理员";
                table.Rows.Add(row);

                row = table.NewRow();
                row["id"] = "2";
                row["Value"] = "地衡称重员";
                table.Rows.Add(row);

                row = table.NewRow();
                row["id"] = "3";
                row["Value"] = "系统管理员";
                table.Rows.Add(row);

                comboBox1.DataSource = table;
                comboBox1.ValueMember = "ID";
                comboBox1.DisplayMember = "Value";
            }
            catch (Exception ex)
            {
                new Logging(6008, ex, "ModelBind权限模版绑定失败");
                DataTable table = new DataTable();
                table.Columns.Add("ID");
                table.Columns.Add("Value");

                DataRow row = table.NewRow();
                row["id"] = "0";
                row["Value"] = "权限模版绑定失败";
                table.Rows.Add(row);

                comboBox1.DataSource = table;
                comboBox1.ValueMember = "ID";
                comboBox1.DisplayMember = "Value";
                comboBox1.Enabled = false;           
            }
            finally
            {

            }
            
        }


        /*
         * 方法名称：ModeMenu
         * 方法功能描述：构建权限模板
         *
         * 创建人：金鹤
         * 创建时间：20080217
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void ModeMenu(string ModelId)
        {
            try
            {
                string[] str = null;
                switch (ModelId)
                {
                    case "1":
                        str = new string[] { "1", "2", "3", "4", "6", "7", "8", "9" };
                        break;
                    case "2":
                        str = new string[] { "1", "2", "3", "6", "7", "8", "9", "13" };
                        break;
                    case "3":
                        str = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" };
                        break;
                    default:
                        break;

                }
                if (str != null)
                {
                    CreateModelTree(str);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            
        }

        /*
         * 方法名称：CreateModelTree
         * 方法功能描述：根据权限模板,对数据集中的用户权限进行修改
         *
         * 创建人：金鹤
         * 创建时间：20080217
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void CreateModelTree(string[] ModelStr)
        {
            try
            {
                foreach (DataRowView datav in dsUser.Tables[0].DefaultView)
                {
                    datav.Delete();
                }
                foreach (string str in ModelStr)
                {
                    AddNodes(str);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            if (this.comboBox1.SelectedValue.ToString() != "0")
            {
                ModeMenu(this.comboBox1.SelectedValue.ToString());
                CreatTreeView();
            }
            //}
            //catch (Exception ex)
            //{
            //    new Logging(6009, ex, "comboBox1_SelectedIndexChanged权限模板加载失败");
            //    MessageBox.Show("权限模板加载失败");
            //}
            //finally
            //{

            //}
        }


    }
}
