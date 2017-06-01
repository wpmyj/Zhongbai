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

namespace DasherStation.costCount
{
    public partial class FrmExpenditureSubject : BaseForm
    {
        public FrmExpenditureSubject()
        {
            InitializeComponent();
        }
        expenditureNameLogic expenNameLogic = new expenditureNameLogic();
       
        DataTable dt = null;
        //树的结点集合
        private TreeNodeCollection tNodes;

        private void FrmExpenditureSubject_Load(object sender, EventArgs e)
        {           
            pickTree();            
        }
        /*
          * 方法名称： 提树
          * 方法功能描述：
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
        private void pickTree()
        {
            dt = expenNameLogic.expenditureNameTableDBLogic();
            createTreeView();
        }
        /*
          * 方法名称：  
          * 方法功能描述：添加根结点 对应的按钮是添加科目 目前此按钮不为用户提供功能
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
        private void button1_Click(object sender, EventArgs e)
        {
            TreeNode tn = new TreeNode(txtSubjectName.Text);
            if (txtSubjectName.Text == "")
            {
                MessageBox.Show("科目名称不能为空！");
                return;
            }
            else
            {
                treevEditSubject.Nodes.Add(tn);
            }

            expenditureNameClass expenditure = new expenditureNameClass();
            expenditure.name = tn.Text;
            expenditure.parentId = "";
            expenditure.level = tn.Level.ToString(); 
            expenditure.inputDate = Convert.ToString(DateTime.Now);
            expenditure.inputMan = this.userName;
            expenditure.remark = "";
            expenNameLogic.saveAddSubject(expenditure);
            //pickTree();
            tn.Expand();           
        }
        /*
          * 方法名称：  
          * 方法功能描述：添加子结点
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
        private void button2_Click(object sender, EventArgs e)
        {            
            TreeNode newNode = new TreeNode(txtSubjectName.Text);
            if (txtSubjectName.Text == "")
            {
                MessageBox.Show("科目名称不能为空！");
                return;
            }           
            treevEditSubject.SelectedNode.Nodes.Add(newNode);
            expenditureNameClass expenditure = new expenditureNameClass();
            expenditure.name = newNode.Text;
            expenditure.parentId = newNode.Parent.Name.ToString();
            expenditure.level = newNode.Level.ToString();
            expenditure.inputDate = Convert.ToString(DateTime.Now);
            expenditure.inputMan = this.userName;
            expenditure.remark = "";
            if (int.Parse(expenditure.level) > 2)
            {
                treevEditSubject.Nodes.Remove(newNode);
                MessageBox.Show("不能再添加下级结点！");
            }
            else
            {
                expenNameLogic.saveAddSubject(expenditure);
                newNode.Name = expenNameLogic.selectMaxInsertIdLogic().ToString();                
            }
            //pickTree();
            newNode.Expand();
            txtSubjectName.Text = "";
                       
        }
        // 删除结点 如果是根结点的话要查找出所有的子结点的id值 现将所有的子结点删除之后再删除根结点 如果是根结点则之间删除等于此结点的id就行了
        private void button6_Click(object sender, EventArgs e)
        {           
            childNode(treevEditSubject.SelectedNode);
            txtSubjectName.Text = "";
        }
        /*
         * 方法名称：childNode  
         * 方法功能描述：取出所有子结点的id值
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
        private void childNode(TreeNode tn)
        {
            ArrayList list = new ArrayList();
            string mainId;
            if (treevEditSubject.SelectedNode.Nodes.Count> 0)
            {
                foreach (TreeNode node in treevEditSubject.SelectedNode.Nodes)
                {
                    if (node.Nodes.Count > 0)
                    {
                        foreach (TreeNode nodeChild in node.Nodes)
                        {                           
                            list.Add(nodeChild.Name);
                        }                      
                        list.Add(node.Name);
                    }
                    else
                    {                      
                        list.Add(node.Name);
                    }                 
                }              
                list.Add(treevEditSubject.SelectedNode.Name);
            }
            else
            {               
                list.Add(treevEditSubject.SelectedNode.Name);
            }
            foreach (object obj in list)
            {                
                mainId = obj.ToString();
                expenNameLogic.deleteNode(mainId);
            }
            treevEditSubject.SelectedNode.Remove();
            //pickTree();
        }

        /*
        * 方法名称：createTreeView
        * 方法功能描述： 创建树
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
        private void createTreeView()
        {
            treevEditSubject.Nodes.Clear();
            tNodes = treevEditSubject.Nodes;
            foreach (DataRow row in dt.Rows)
            {
                if (row["parentId"].ToString().Trim() == "")
                {
                    TreeNode tn = new TreeNode();
                    tn.Name = row["id"].ToString();
                    tn.Text = row["name"].ToString();
                    tNodes.Add(tn);
                }
            }
            foreach (TreeNode nodeP in tNodes)
            {
                CreatNode(nodeP);
            }
            foreach (TreeNode tn in treevEditSubject.Nodes)
            {
                tn.Expand();
            }
        }
        /*
       * 方法名称：CreatNode
       * 方法功能描述： 创建结点
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
        private void CreatNode(TreeNode nodeP)
        {
            foreach (DataRowView datav in dt.DefaultView)
            {

                if (datav["parentId"].ToString().Trim() == nodeP.Name)
                {

                    TreeNode tn = new TreeNode();
                    tn.Name = datav["id"].ToString();
                    tn.Text = datav["name"].ToString();
                    nodeP.Nodes.Add(tn);
                    CreatNode(tn);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 更新时要判断是更新子结点还是根结点 如果更新的是根结点那么parentId=""
        // 如果为子节点那么parentId就能找到 是此结点的name属性 判断根结点的方法是结点的层为0
        private void button3_Click(object sender, EventArgs e)
        {
            expenditureNameClass expenditure = new expenditureNameClass();
            TreeNode newNode = new TreeNode(txtSubjectName.Text);
            string parentId;
          
            if (txtSubjectName.Text == "")
            {
                MessageBox.Show("科目名称不能为空！");
                return;
            }
            if (treevEditSubject.SelectedNode.Level != 0)
            {
                parentId = treevEditSubject.SelectedNode.Parent.Name;
            }
            else
            {
                parentId = "";
            }                    
            expenditure.id = treevEditSubject.SelectedNode.Name;
            expenditure.name = newNode.Text;
            expenditure.parentId = parentId;
            expenditure.level = treevEditSubject.SelectedNode.Level.ToString();
            expenditure.inputDate = Convert.ToString(DateTime.Now);
            expenditure.inputMan = this.userName;
            expenditure.remark = "";
            treevEditSubject.SelectedNode.Text = newNode.Text;
            expenNameLogic.updateNode(expenditure);
            //pickTree();
            newNode.Expand();
            txtSubjectName.Text = "";
        }
       
        private void SetNodesBackColor(TreeNodeCollection tn)
        {
            foreach (TreeNode ctn in tn)
            {
                ctn.BackColor = Color.White;
                SetNodesBackColor(ctn.Nodes);
            }
        }      
        private void textBox1_Click(object sender, EventArgs e)
        {
            //textBox1.Select();
            //textBox1.SelectAll();
            //if (textBox1.Focused)
            //    textBox1.Select();               
        }

        private void treevEditSubject_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            txtSubjectName.Text = treevEditSubject.SelectedNode.Text;
            //textBox1.Select();
            //textBox1.SelectAll();
            SetNodesBackColor(this.treevEditSubject.Nodes);

            this.treevEditSubject.SelectedNode.BackColor = Color.LightGray;
        }     
                
    }
}
