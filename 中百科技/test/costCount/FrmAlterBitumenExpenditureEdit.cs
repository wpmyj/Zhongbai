using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.costCount
{
    public partial class FrmAlterBitumenExpenditureEdit  : BaseForm
    {
        CostCountLogic logic = new CostCountLogic();
        CostEditLogic editLogic = new CostEditLogic();

        DataTable tempDataTable = new DataTable();

        // 用于保存最后要存到数据库中的表
        DataTable dtLast = null;

        public FrmAlterBitumenExpenditureEdit()
        {
            InitializeComponent();
        }


        private void FrmExpenditureEdit_Load(object sender, EventArgs e)
        {
            FormInit();
        }
        //树节点被选择后,提取费用科目到界面上
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treev1.SelectedNode != null)
            {
                TreeNode node = treev1.SelectedNode;

                //cmbExpenditureSort.Text = "";
                cmbExpenditureSort.SelectedIndex = -1;
                cmbExpenditureName.SelectedIndex = -1;
                cmbExpenditureDetail.SelectedIndex = -1;
                for (int i = 0; i < treev1.SelectedNode.Level; i++)
                {
                    switch (node.Level)
                    {
                        case 0:
                            cmbExpenditureSort.Text = node.Text;
                            //cmbExpenditureSort.SelectedValue = ((TreeTagType)node.Tag).id.ToString();
                            break;
                        case 1:
                            cmbExpenditureName.Text = node.Text;
                            //cmbExpenditureName.SelectedValue = ((TreeTagType)node.Tag).id.ToString();
                            break;
                        case 2:
                            cmbExpenditureDetail.Text = node.Text;
                            //cmbExpenditureDetail.SelectedValue = ((TreeTagType)node.Tag).id.ToString(); 
                            break;
                    }
                    node = node.Parent;
                }
                cmbExpenditureSort.Text = node.Text;
                LoadForm(node.Text);
            }
        }
        //关闭窗体
        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        //判断窗体上用于新增的数据是否完整
        private string IsFull()
        {
            string msg = "";
            if ((cmbExpenditureSort.Text.Trim().Equals("")) && (cmbExpenditureName.Text.Trim().Equals("")) && (cmbExpenditureDetail.Text.Trim().Equals("")))
            {
                msg += "科目不能为空\n";
            }
            if (cmbYear.Text.Trim().Equals(""))
                msg += "年度值不能为空\n";
            if (cmbMonth.Text.Trim().Equals(""))
                msg += "月份值不能为空\n";
            if (cmbExpenditureMoney.Text.Trim().Equals(""))
                msg += "金额不能为空\n";
            if (!Check.CheckFloat(cmbExpenditureUnitPrice.Text))
                msg += "费用单价应该是数字!\n";
            return msg;
        }
        //根据当前费用类型，设定窗体样式
        private void LoadForm(string name)
        {
            switch (name.Trim())
            {
                case "直接人工":
                    cmbConvertQuotiety.Visible = false;
                    label9.Visible = false;
                    break;
                case "直接材料费用":
                    cmbConvertQuotiety.Visible = false;
                    label9.Visible = false;
                    break;
                case "废品损失":
                    cmbConvertQuotiety.Visible = true;
                    label9.Visible = true;
                    break;
                case "制造费用":
                    cmbConvertQuotiety.Visible = false;
                    label9.Visible = false;
                    break;
                case "季节性停工损失费用":
                    cmbConvertQuotiety.Visible = false;
                    label9.Visible = false;
                    break;
                default:
                    break;
            }
        }
        //窗体初始化
        private void FormInit()
        {
            logic.CreateExpenditureTree(treev1);
            treev1.ExpandAll();
            cmbYear.Text = DateTime.Now.Year.ToString();
            cmbMonth.Text = DateTime.Now.Month.ToString();
            CostEditLogic costEditLogic = new CostEditLogic();
            costEditLogic.SetExpenditureKind(ref cmbExpenditureSort);
            costEditLogic.SetExpenditureName(ref cmbExpenditureName);
            costEditLogic.SetExpenditureDetail(ref cmbExpenditureDetail);
            costEditLogic.SetEquipmentName(ref cmbEquipmentName);
            costEditLogic.SetProductName(ref cmbProductName);

            tempDataTable.Columns.Add("id");
            tempDataTable.Columns.Add("ekId");
            tempDataTable.Columns.Add("enId");
            tempDataTable.Columns.Add("ecId");
            tempDataTable.Columns.Add("expenditureDepict");
            tempDataTable.Columns.Add("year");
            tempDataTable.Columns.Add("month");
            tempDataTable.Columns.Add("eiId");
            tempDataTable.Columns.Add("pId");
            tempDataTable.Columns.Add("number");
            tempDataTable.Columns.Add("unitPrice");
            tempDataTable.Columns.Add("money");
            tempDataTable.Columns.Add("inputDate");
            tempDataTable.Columns.Add("inputMan");
            tempDataTable.Columns.Add("convert");
            tempDataTable.Columns.Add("remark");
            tempDataTable.Columns.Add("费用类别");
            tempDataTable.Columns.Add("费用名称");
            tempDataTable.Columns.Add("费用明细");
            tempDataTable.Columns.Add("设备名称");
            tempDataTable.Columns.Add("产品名称");

            dateTimePicker1.Value = DateTime.Now;

            dataGridView1.DataSource = tempDataTable;
        }
        //窗体上的值装入实体类expenditureClass
        private alterBitumenExpenditureClass GetValueExpenditure()
        {
            alterBitumenExpenditureClass recInfo = new alterBitumenExpenditureClass();

            recInfo.ekId = cmbExpenditureSort.SelectedValue == null ? null : cmbExpenditureSort.SelectedValue.ToString();
            recInfo.enId = cmbExpenditureName.SelectedValue == null ? null : cmbExpenditureName.SelectedValue.ToString();
            recInfo.ecId = cmbExpenditureDetail.SelectedValue == null ? null : cmbExpenditureDetail.SelectedValue.ToString();
            recInfo.eiId = cmbEquipmentName.SelectedValue == null ? null : cmbEquipmentName.SelectedValue.ToString();
            recInfo.expenditureDepict = cmbExpenditureDepict.Text;
            recInfo.year = cmbYear.Text;
            recInfo.month = cmbMonth.Text;
            recInfo.pId = cmbProductName.SelectedValue == null ? null : cmbProductName.SelectedValue.ToString();
            recInfo.unitPrice = cmbExpenditureUnitPrice.Text;
            recInfo.number = upDownExpenditureQuantity.Value.ToString();
            recInfo.money = cmbExpenditureMoney.Text;
            recInfo.inputDate = dateTimePicker1.Value.ToString();
            recInfo.inputMan = "测试";
            recInfo.convert = cmbConvertQuotiety.Text;
            recInfo.remark = richTextRemark.Text;

            return recInfo;

        }
        //窗体上的值装入实体类expenditureClass
        private alterBitumenWaitDetachExpenditureClass GetValueWaitDetachExpenditure()
        {
            alterBitumenWaitDetachExpenditureClass recInfo = new alterBitumenWaitDetachExpenditureClass();

            recInfo.ekId = cmbExpenditureSort.SelectedValue == null ? null : cmbExpenditureSort.SelectedValue.ToString();
            recInfo.enId = cmbExpenditureName.SelectedValue == null ? null : cmbExpenditureName.SelectedValue.ToString();
            recInfo.ecId = cmbExpenditureDetail.SelectedValue == null ? null : cmbExpenditureDetail.SelectedValue.ToString();
            recInfo.eiId = cmbEquipmentName.SelectedValue == null ? null : cmbEquipmentName.SelectedValue.ToString();
            recInfo.expenditureDepict = cmbExpenditureDepict.Text;
            recInfo.year = cmbYear.Text;
            recInfo.month = cmbMonth.Text;
            recInfo.pId = cmbProductName.SelectedValue == null ? null : cmbProductName.SelectedValue.ToString();
            recInfo.unitPrice = cmbExpenditureUnitPrice.Text;
            recInfo.number = upDownExpenditureQuantity.Value.ToString();
            recInfo.money = cmbExpenditureMoney.Text;
            //recInfo.inputDate = dateTimePicker1.Text;
            recInfo.inputDate = dateTimePicker1.Value.ToString();
            recInfo.inputMan = "测试";
            recInfo.convert = cmbConvertQuotiety.Text;
            recInfo.remark = richTextRemark.Text;

            return recInfo;
        }
        // 向datatable中加行
        // 向表中添加一行然后返回表用于放到逻辑层进行判断用以确定是存入费用表还是待摊费用表
        private DataTable AddDateTable()
        {
            if ((!cmbEquipmentName.Text.Trim().Equals("")) && (!cmbEquipmentName.Text.Trim().Equals("")))
            {
                alterBitumenExpenditureClass info = new alterBitumenExpenditureClass();
                info = GetValueExpenditure();
                DataRow row = tempDataTable.NewRow();

                ExpenditureToDataRow(info, ref row);
                tempDataTable.Rows.Add(row);
            }
            else
            {
                alterBitumenWaitDetachExpenditureClass waitDetachInfo = new alterBitumenWaitDetachExpenditureClass();
                waitDetachInfo = GetValueWaitDetachExpenditure();
                DataRow row1 = tempDataTable.NewRow();

                WaitDetachExpenditureToDataRow(waitDetachInfo, ref row1);
                tempDataTable.Rows.Add(row1);
            }
            return tempDataTable;
        }
        public void ClearCombobox(string tag, ref GroupBox gb)
        {
            ComboBox mycbx;
            int len, i;

            len = gb.Controls.Count;
            for (i = 0; i < len; i++)
            {
                if (gb.Controls[i] is ComboBox)
                {
                    mycbx = ((ComboBox)gb.Controls[i]);
                    if ((mycbx.Tag != null) && (mycbx.Tag.ToString().Equals(tag)))
                    {
                        mycbx.Text = "";
                        mycbx.SelectedIndex = -1;
                    }

                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string meg = "";

            meg = IsFull();

            if (meg.Trim().Length == 0)
            {
                //DataTable dt = AddDateTable();
                dtLast = AddDateTable();
                ClearCombobox("1", ref groupBox2);
                richTextRemark.Text = "";
            }
            else
                MessageBox.Show(meg);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[i]);
                }
            }
        }
        /*
        * 方法名称：ExpenditureToDataRow
        * 方法功能描述：实体类信息转换为DataRow
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
        public void ExpenditureToDataRow(alterBitumenExpenditureClass info, ref DataRow dr)
        {
            dr["id"] = info.id == null ? "" : info.id;
            dr["ekId"] = info.ekId == null ? "" : info.ekId;
            dr["enId"] = info.enId == null ? "" : info.enId;
            dr["ecId"] = info.ecId == null ? "" : info.ecId;
            dr["expenditureDepict"] = info.expenditureDepict == null ? "" : info.expenditureDepict;
            dr["year"] = info.year == null ? "" : info.year;
            dr["month"] = info.month == null ? "" : info.month;
            dr["eiId"] = info.eiId == null ? "" : info.eiId;
            dr["pId"] = info.pId == null ? "" : info.pId;
            dr["number"] = info.number == null ? "" : info.number;
            dr["unitPrice"] = info.unitPrice == null ? "" : info.unitPrice;
            dr["money"] = info.money == null ? "" : info.money;
            dr["inputDate"] = info.inputDate == null ? "" : info.inputDate;
            dr["inputMan"] = info.inputMan == null ? "" : info.inputMan;
            dr["convert"] = info.convert == null ? "" : info.convert;
            dr["remark"] = info.remark == null ? "" : info.remark;
            dr["费用类别"] = cmbExpenditureSort.Text;
            dr["费用名称"] = cmbExpenditureName.Text;
            dr["费用明细"] = cmbExpenditureDetail.Text;
            dr["设备名称"] = cmbEquipmentName.Text;
            dr["产品名称"] = cmbProductName.Text;
        }
        /*
        * 方法名称：WaitDetachExpenditureToDataRow
        * 方法功能描述：实体类信息转换为DataRow
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
        public void WaitDetachExpenditureToDataRow(alterBitumenWaitDetachExpenditureClass info, ref DataRow dr)
        {
            dr["id"] = info.id == null ? "" : info.id;
            dr["ekId"] = info.ekId == null ? "" : info.ekId;
            dr["enId"] = info.enId == null ? "" : info.enId;
            dr["ecId"] = info.ecId == null ? "" : info.ecId;
            dr["expenditureDepict"] = info.expenditureDepict == null ? "" : info.expenditureDepict;
            dr["year"] = info.year == null ? "" : info.year;
            dr["month"] = info.month == null ? "" : info.month;
            dr["eiId"] = info.eiId == null ? "" : info.eiId;
            dr["pId"] = info.pId == null ? "" : info.pId;
            dr["number"] = info.number == null ? "" : info.number;
            dr["unitPrice"] = info.unitPrice == null ? "" : info.unitPrice;
            dr["money"] = info.money == null ? "" : info.money;
            dr["inputDate"] = info.inputDate == null ? "" : info.inputDate;
            dr["inputMan"] = info.inputMan == null ? "" : info.inputMan;
            dr["convert"] = info.convert == null ? "" : info.convert;
            dr["remark"] = info.remark == null ? "" : info.remark;
            dr["费用类别"] = cmbExpenditureSort.Text;
            dr["费用名称"] = cmbExpenditureName.Text;
            dr["费用明细"] = cmbExpenditureDetail.Text;
            dr["设备名称"] = cmbEquipmentName.Text;
            dr["产品名称"] = cmbProductName.Text;
        }
        /*
     * 方法名称：
     * 方法功能描述：应用按钮的实现  将datagridview里面的数据保存到数据库中
     * 参数: 
     *      
     * 
     * 创建人：付中华
     * 创建时间：2009-03-26
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtLast.Rows.Count != 0)
            {
                if (MessageBox.Show("确定要保存吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    return;

                bool saveSuccess;
                saveSuccess = editLogic.saveLastAlterBitumenTable(dtLast);
                if (saveSuccess)
                {
                    MessageBox.Show("保存成功！");
                    // 将datagridview中的内容全部删除掉
                    for (int i = 0; i < dataGridView1.Rows.Count + 1; i++)
                    {
                        foreach (DataGridViewRow dgvr in dataGridView1.Rows)
                        {
                            dataGridView1.Rows.Remove(dgvr);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }

            }
        }
        private void cmbExpenditureUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if ((cmbExpenditureUnitPrice.Text != "") && (upDownExpenditureQuantity.Value.ToString() != ""))
                if ((Check.CheckFloat(cmbExpenditureUnitPrice.Text)) && (Check.CheckFloat(upDownExpenditureQuantity.Text)))
                    cmbExpenditureMoney.Text = Convert.ToString(Convert.ToDouble(cmbExpenditureUnitPrice.Text) * (Convert.ToInt64(upDownExpenditureQuantity.Value.ToString())));
        }

        private void upDownExpenditureQuantity_ValueChanged(object sender, EventArgs e)
        {
            if ((cmbExpenditureUnitPrice.Text != "") && (upDownExpenditureQuantity.Value.ToString() != ""))
                if ((Check.CheckFloat(cmbExpenditureUnitPrice.Text)) && (Check.CheckFloat(upDownExpenditureQuantity.Text)))
                    cmbExpenditureMoney.Text = Convert.ToString(Convert.ToDouble(cmbExpenditureUnitPrice.Text) * (Convert.ToInt64(upDownExpenditureQuantity.Value.ToString())));
        }


    }
}

