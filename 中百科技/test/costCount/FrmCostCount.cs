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
    public partial class FrmCostCount : BaseForm
    {

        private ArrayList treefields = new ArrayList();
        public FrmCostCount()
        {
            InitializeComponent();
        }
        AuditingAction auditingActionExpenditure = new AuditingAction("id", "Expenditure");
        AuditingAction auditingActionExpenditureDetach = new AuditingAction("id", "WaitDetachExpenditure");
        CostCountDetailLogic costDetailLogic = new CostCountDetailLogic();

        private void FrmCostCount_Load(object sender, EventArgs e)
        {
            this.userName = "fzh";
            #region// 初始化产品名称和设备名称
            // 产品名称和设备名称的初始化
            cmbProductName.DataSource = costDetailLogic.distillProductNameLogic();
            cmbProductName.DisplayMember = "name";
            cmbProductName.ValueMember = "pnId";
            cmbProductName.SelectedIndex = -1;

            // 设备名称的初始化
            cmbEquipmentName.DataSource = costDetailLogic.distillEquipmentNameLogic();
            cmbEquipmentName.DisplayMember = "name";
            cmbEquipmentName.ValueMember = "enId";
            cmbEquipmentName.SelectedIndex = -1;
            #endregion

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnExpenditureAdd_Click(object sender, EventArgs e)
        {
            //////////////ArrayList sql = new ArrayList();

            //////////////ArrayList fields = new ArrayList();
            //////////////DataTable dt = new DataTable();

            //////////////fields.Add("grossWeight");
            //////////////fields.Add("tare");
            ////////////////fields.Add("inputdate");
            //////////////sql.Add("select * from stockNote");
            //////////////SqlHelper sqlobj = new SqlHelper();
            //////////////dt = sqlobj.QueryForDateSet(sql).Tables[0];
            //////////////CostCountLogic logic = new CostCountLogic();

            //////////////logic.CreateTree(ref treeView1, dt, fields);
            FrmExpenditureEdit form = new FrmExpenditureEdit();

            form.ShowDialog();


        }

        private void btnExpenditureModify_Click(object sender, EventArgs e)
        {
            FrmAutomatismExpenditure AutomatismExpenditure = new FrmAutomatismExpenditure();
            AutomatismExpenditure.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bottonSearch();
            //treefields.Clear();
            //treefields.Add("产品名称");
            //treefields.Add("产品型号");
            //treefields.Add("费用类别");
            //CostEditLogic logic = new CostEditLogic();
            //treeView1.Nodes.Clear();
            //logic.DistillExpenditureTree(ref treeView1, treefields);
            //viewStatus();
        }

        private void bottonSearch()
        {
            CostEditLogic logic = new CostEditLogic();
            DataTable dt = new DataTable();
            selectExpenditureClass conds = new selectExpenditureClass();
            conds.prName = cmbProductName.Text.Trim().Equals("") ? null : cmbProductName.Text;
            conds.prModel = cmbProductmodel.Text.Trim().Equals("") ? null : cmbProductmodel.Text;
            conds.eqName = cmbEquipmentName.Text.Trim().Equals("") ? null : cmbEquipmentName.Text;
            conds.eqModel = cmbEquipmentModel.Text.Trim().Equals("") ? null : cmbEquipmentModel.Text;
            conds.flag = CBFlag.Text;
            if (checkBox1.Checked)
                conds.beginDateTime = dtpStart.Value.ToString();
            if (checkBox2.Checked)
                conds.endDateTime = dtpEnd.Value.ToString();

            dt = logic.SelectAllData(conds);
            dgvShow.DataSource = dt;
            caleRecordAndMoney(dt);
            dgvShow.Columns["id"].Visible = false;
        }
       
        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                selectExpenditureClass conds = new selectExpenditureClass();
                TreeNode nodes = new TreeNode();
                nodes = treeView1.SelectedNode;
                for (int i = treeView1.SelectedNode.Level; i >= 0; i--)
                {
                    switch (treefields[i].ToString().Trim())
                    {
                        case "费用类别":
                            conds.exSort = nodes.Text;
                            break;
                        case "费用名称":
                            conds.exName = nodes.Text;
                            break;
                        case "费用明细":
                            conds.exDetail = nodes.Text;
                            break;
                        case "费用描述":
                            conds.exDepict = nodes.Text;
                            break;
                        case "年份":
                            conds.exYear = nodes.Text;
                            break;
                        case "月份":
                            conds.exMonth = nodes.Text;
                            break;
                        case "设备名称":
                            conds.eqName = nodes.Text;
                            break;
                        case "设备型号":
                            conds.eqModel = nodes.Text;
                            break;
                        case "产品名称":
                            conds.prName = nodes.Text;
                            break;
                        case "产品型号":
                            conds.prModel = nodes.Text;
                            break;
                        case "单价":
                            conds.exUnitPrice = nodes.Text;
                            break;
                        case "数量":
                            conds.exNumber = nodes.Text;
                            break;
                        case "金额":
                            conds.exMoney = nodes.Text;
                            break;
                        case "录入时间":
                            conds.exInputDate = nodes.Text;
                            break;
                        case "录入人":
                            conds.exInputMan = nodes.Text;
                            break;
                        case "折算系数":
                            conds.exConvert = nodes.Text;
                            break;
                        case "备注":
                            conds.exRemark = nodes.Text;
                            break;
                    }
                    nodes = nodes.Parent;
                }
                CostEditLogic logic = new CostEditLogic();
                DataTable dt = new DataTable();

                dt = logic.SelectAllData(conds);
                dgvShow.DataSource = dt;
                caleRecordAndMoney(dt);
                dgvShow.Columns["id"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList fields = new ArrayList();

            for (int i = 0; i< dgvShow.Columns.Count; i++)
            {
                if (!dgvShow.Columns[i].HeaderText.Trim().Equals("id"))
                    fields.Add(dgvShow.Columns[i].HeaderText);
            }
            FrmTreeField treeFieldForm = new FrmTreeField();
            treeFieldForm.FieldNames = fields;
            treeFieldForm.ShowDialog();
            if (treeFieldForm.DialogResult == DialogResult.Yes)
            {
                treefields = fields;
                viewStatus();

                if (fields.Count > 0)
                {
                    CostEditLogic logic = new CostEditLogic();
                    treeView1.Nodes.Clear();
                    logic.DistillExpenditureTree(ref treeView1, fields);
                }    
            }      
               
            

        }
        private void viewStatus()
        {
            toolStripStatusLabel3.Text = "提树字段名:";
            for (int i = 0; i < treefields.Count; i++)
            {
                toolStripStatusLabel3.Text += "<" + treefields[i].ToString() + ">";
            }
        }
        private void FormInit()
        {
            bottonSearch();
            treefields.Clear();
            treefields.Add("费用类别");
            CostEditLogic logic = new CostEditLogic();
            treeView1.Nodes.Clear();
            logic.DistillExpenditureTree(ref treeView1, treefields);
            viewStatus();
        }

        private void FrmCostCount_Shown(object sender, EventArgs e)
        {
            FormInit();
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbProductName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 随着产品名称的变化规格的列表变化
            long pnId;
            if (cmbProductName.SelectedValue == null)
            {
                pnId = 0;
                cmbProductmodel.SelectedIndex = -1;
                return;
            }
            pnId = Convert.ToInt64(cmbProductName.SelectedValue.ToString());
            cmbProductmodel.DataSource = costDetailLogic.distillProductModelLogic(pnId);
            cmbProductmodel.DisplayMember = "model";
            cmbProductmodel.ValueMember = "pmId";
            cmbProductmodel.Text = "";
            cmbProductmodel.SelectedIndex = -1;



        }

        private void cmbEquipmentName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 随着设备名称的变化规格列表的变化
            long enId;
            if (cmbEquipmentName.SelectedValue == null)
            {
                enId = 0;
                cmbEquipmentModel.SelectedIndex = -1;
                return;
            }
            enId = Convert.ToInt64(cmbEquipmentName.SelectedValue.ToString());
            cmbEquipmentModel.DataSource = costDetailLogic.distillEquipmentModelLogic(enId);
            cmbEquipmentModel.DisplayMember = "model";
            cmbEquipmentModel.ValueMember = "emId";
            cmbEquipmentModel.Text = "";
            cmbEquipmentModel.SelectedIndex = -1;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dtpStart.Enabled = true;
            }
            else
            {
                dtpStart.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                dtpEnd.Enabled = true;
            }
            else
            {
                dtpEnd.Enabled = false;
            }
        }

        private void btnDeleteExpenditure_Click(object sender, EventArgs e)
        {
            bool deleteStatus1=true;
            bool deleteStatus2=true;
            // 删除按钮 直接删除数据库中的记录重新绑定数据源
            if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int deleteIndex = dgvShow.SelectedRows.Count;
                for (int i = 0; i < deleteIndex; i++)
                {
                    // 当设备名称和规格 以及产品名称及规格都不为空的时候删除的是费用表中的记录 否则删除的是待摊费用表中的记录
                    if ((dgvShow.SelectedRows[i].Cells["设备名称"].FormattedValue.ToString() != "") && (dgvShow.SelectedRows[i].Cells["设备型号"].FormattedValue.ToString() != "")
                        && (dgvShow.SelectedRows[i].Cells["产品名称"].FormattedValue.ToString() != "") && (dgvShow.SelectedRows[i].Cells["产品型号"].FormattedValue.ToString() != ""))
                    {
                        deleteStatus1 = costDetailLogic.deleteExpenditureLogic(Convert.ToInt64(dgvShow.SelectedRows[i].Cells["id"].Value.ToString()));
                    }
                    else 
                    {
                        deleteStatus2 = costDetailLogic.deleteWaitDetachExpenditureLogic(Convert.ToInt64(dgvShow.SelectedRows[i].Cells["id"].Value.ToString()));
                    }
                }
                if ((deleteStatus1) && (deleteStatus2))
                    MessageBox.Show("删除成功！");
                else
                    MessageBox.Show("删除未成功！");

                dgvShow.DataSource = distillCostTable();
                caleRecordAndMoney(distillCostTable());
            }


        }
        // 删除表中的记录之后重新绑定数据源取表的过程
        private DataTable distillCostTable()
        {
            CostEditLogic logic = new CostEditLogic();
            DataTable dt = new DataTable();
            selectExpenditureClass conds = new selectExpenditureClass();
            conds.prName = cmbProductName.Text.Trim().Equals("") ? null : cmbProductName.Text;
            conds.prModel = cmbProductmodel.Text.Trim().Equals("") ? null : cmbProductmodel.Text;
            conds.eqName = cmbEquipmentName.Text.Trim().Equals("") ? null : cmbEquipmentName.Text;
            conds.eqModel = cmbEquipmentModel.Text.Trim().Equals("") ? null : cmbEquipmentModel.Text;
            if (checkBox1.Checked)
                conds.beginDateTime = dtpStart.Value.ToString();
            if (checkBox2.Checked)
                conds.endDateTime = dtpEnd.Value.ToString();

            dt = logic.SelectAllData(conds);
            return dt;

        }
        // 计算记录总数和总金额
        private void caleRecordAndMoney(DataTable dt)
        {
            long count = dt.Rows.Count;
            double sumMoney = 0.0;
            foreach (DataRow dr in dt.Rows)
            {
                sumMoney += Convert.ToDouble(dr["金额"].ToString());
            }

            toolStripStatusLabel1.Text = "记录数: " + count;
            toolStripStatusLabel2.Text = "总金额: " + sumMoney;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnStatisticsCost_Click(object sender, EventArgs e)
        {
            FrmBitumenDetach form = new FrmBitumenDetach();
            form.FormSort = 3;
            form.Text = "混合料成本分摊";
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCaleBitumenHeatCost caleForm = new FrmCaleBitumenHeatCost();
            caleForm.FormSort = 3;
            caleForm.Text = "计算混合料成本";
            caleForm.ShowDialog();
        }

        private void btn_assessor_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确认审核选中记录", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dgvShow.SelectedRows)
                    {
                        if ((dgvr.Cells["产品名称"].Value.ToString() != "") && (dgvr.Cells["产品型号"].Value.ToString() != ""))
                        {
                            MessageBox.Show(auditingActionExpenditure.DoAssessor(long.Parse(dgvr.Cells["id"].Value.ToString()), this.UserName).ToString());
                            dgvr.Cells["审核人"].Value = this.UserName;
                        }
                        else
                        {
                            MessageBox.Show(auditingActionExpenditureDetach.DoAssessor(long.Parse(dgvr.Cells["id"].Value.ToString()), this.UserName).ToString());
                            dgvr.Cells["审核人"].Value = this.UserName;
                        }
                    }
                }
            }
        }

        private void btn_checkupMan_Click(object sender, EventArgs e)
        {
            if (dgvShow.SelectedRows.Count > 0)
            {
                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    if ((dgvShow.SelectedRows[0].Cells["产品名称"].Value.ToString() != "") && (dgvShow.SelectedRows[0].Cells["产品型号"].Value.ToString() != ""))
                    {
                        int result = auditingActionExpenditure.DoConfirm(long.Parse(dgvShow.SelectedRows[0].Cells["id"].Value.ToString()), this.UserName, frmConfirm.Confirm);
                        switch (result)
                        {
                            case 0:
                                if (frmConfirm.Confirm)
                                {
                                    dgvShow.SelectedRows[0].Cells["审批人"].Value = this.UserName;
                                }
                                else
                                {
                                    dgvShow.SelectedRows[0].Cells["审批人"].Value = "";
                                    dgvShow.SelectedRows[0].Cells["审核人"].Value = "";
                                }
                                break;

                        }
                    }
                    else
                    {
                        int result = auditingActionExpenditureDetach.DoConfirm(long.Parse(dgvShow.SelectedRows[0].Cells["id"].Value.ToString()), this.UserName, frmConfirm.Confirm);
                        switch (result)
                        {
                            case 0:
                                if (frmConfirm.Confirm)
                                {
                                    dgvShow.SelectedRows[0].Cells["审批人"].Value = this.UserName;
                                }
                                else
                                {
                                    dgvShow.SelectedRows[0].Cells["审批人"].Value = "";
                                    dgvShow.SelectedRows[0].Cells["审核人"].Value = "";
                                }
                                break;

                        }
                    }
                }
            }
        }

     
        
    }
}
