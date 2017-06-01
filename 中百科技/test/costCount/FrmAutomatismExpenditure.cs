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
    public partial class FrmAutomatismExpenditure : BaseForm
    {

        public FrmAutomatismExpenditure()
        {
            InitializeComponent();
        }
        DataTable dt = null;
        ArrayList nameFieldsMain = new ArrayList();

        bitumenCostCountLogic bitumenCLogic = new bitumenCostCountLogic();
        private void FormInit()
        {
            CostEditLogic logic = new CostEditLogic();
            logic.SetExpenditureKind(ref cmbKind);
            cmbYear.Text = DateTime.Now.Year.ToString();
            cmbMonth.Text = DateTime.Now.Month.ToString();
            //logic.CreateExpenditureTree(treeView1);             
        }

        private void FrmAutomatismExpenditure_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            string yearDate = cmbYear.Text;
            int month = Convert.ToInt32(cmbMonth.Text);
            ArrayList fields = new ArrayList();

            switch (cmbKind.Text.Trim())
            {
                case "直接人工":
                    FrmDirectnessManOption DirectnessManOption = new FrmDirectnessManOption();
                    DirectnessManOption.NameFields = fields;

                    DirectnessManOption.ShowDialog();

                    if (DirectnessManOption.DialogResult == DialogResult.OK)
                    {
                        nameFieldsMain = fields;
                    }
                    //dt.Columns.Add(new DataColumn("name"));
                    //dt.Columns.Add(new DataColumn("id"));
                    dt.Columns.Add(new DataColumn("totalExpenditure"));
                    //dt.Columns.Add(new DataColumn("费用类型"));
                    //dt.Columns.Add(new DataColumn("费用描述"));
                    //dt.Columns.Add(new DataColumn("年"));
                    //dt.Columns.Add(new DataColumn("月"));
                    //dt.Columns.Add(new DataColumn("设备编号"));
                    dt.Columns.Add(new DataColumn("expenditureType"));
                    dt.Columns.Add(new DataColumn("expenditureDepict"));
                    dt.Columns.Add(new DataColumn("yearDate"));
                    dt.Columns.Add(new DataColumn("monthDate"));
                    dt.Columns.Add(new DataColumn("equipmentNo"));
                    dt.Columns.Add(new DataColumn("equipmentId"));
                    dt.Columns.Add(new DataColumn("productName"));
                    dt.Columns.Add(new DataColumn("quantity"));
                    dt.Columns.Add(new DataColumn("unitPrice"));
                    dt.Columns.Add(new DataColumn("ekId"));
                    dt.Columns.Add(new DataColumn("pId"));


                    int i = 0;
                    if ((cmbYear.Text == "") || (cmbMonth.Text == ""))
                    {
                        MessageBox.Show("年份或者月份都不能为空,请添加年份月份", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        return;
                    }
                    //MessageBox.Show(fields.Count.ToString());
                    foreach (string name in fields)
                    {
                        dt.Rows.Add(dt.NewRow());
                        //dt.Rows[i]["name"] = name.Split('_')[0];
                        //dt.Rows[i]["id"] = name.Split('_')[1];
                        string tempName = name.Split('_')[0];
                        string tempId= name.Split('_')[1];

                        dt.Rows[i]["totalExpenditure"] = bitumenCLogic.getDirectPersonCostLogic(Convert.ToInt64(tempId), month, yearDate).Rows[0][0];

                        dt.Rows[i]["expenditureType"] = cmbKind.Text;
                        dt.Rows[i]["ekId"] = bitumenCLogic.getExpenditureTypeIdLogic(cmbKind.Text).Rows[0][0];

                        dt.Rows[i]["expenditureDepict"] = "自动归集工资";
                        dt.Rows[i]["yearDate"] = cmbYear.Text.ToString();
                        dt.Rows[i]["monthDate"] = cmbMonth.Text.ToString();
                        dt.Rows[i]["pId"] = null;

                        if (bitumenCLogic.getEquipmentNoAndIdLogic(Convert.ToInt64(tempId)).Rows.Count != 0)
                        {
                            dt.Rows[i]["equipmentId"] = bitumenCLogic.getEquipmentNoAndIdLogic(Convert.ToInt64(tempId)).Rows[0]["id"];
                        }
                        if (bitumenCLogic.getEquipmentNoAndIdLogic(Convert.ToInt64(tempId)).Rows.Count != 0)
                        {
                            dt.Rows[i]["equipmentNo"] = bitumenCLogic.getEquipmentNoAndIdLogic(Convert.ToInt64(tempId)).Rows[0]["no"];
                        }
                        // 先到对应的待摊数据表中查询所有匹配信息的isAuto的值如果此值为true则再查询它对应的money值 如果不存在此信息则什么都不做
                        directManEntityClass directManEntity = new directManEntityClass();
                        directManEntity.totalExpenditure = dt.Rows[i]["totalExpenditure"].ToString();
                        directManEntity.ekId = dt.Rows[i]["ekId"].ToString();
                        directManEntity.expenditureDepict = dt.Rows[i]["expenditureDepict"].ToString();
                        directManEntity.yearDate = dt.Rows[i]["yearDate"].ToString();
                        directManEntity.monthDate = dt.Rows[i]["monthDate"].ToString();
                        if (!dt.Rows[i]["equipmentId"].ToString().Equals(""))
                        { directManEntity.equipmentId = dt.Rows[i]["equipmentId"].ToString(); }

                        if (!dt.Rows[i]["equipmentNo"].ToString().Equals(""))
                        { directManEntity.equipmentNo = dt.Rows[i]["equipmentNo"].ToString(); }

                        string hasAutoMoney = bitumenCLogic.isAutoMixerLogic(directManEntity);
                        if (hasAutoMoney == "-10000")
                        { }
                        else
                        {
                            if (!dt.Rows[i]["totalExpenditure"].ToString().Equals(""))
                            {
                                dt.Rows[i]["totalExpenditure"] = Convert.ToString(float.Parse(dt.Rows[i]["totalExpenditure"].ToString()) - float.Parse(hasAutoMoney));
                            }
                        }


                        i++;
                        if ((dt.Rows[i - 1]["totalExpenditure"].ToString() == "")||(dt.Rows[i-1]["totalExpenditure"].ToString()=="0"))
                        {
                            dt.Rows.Remove(dt.Rows[i - 1]);
                            i--;
                        }
                    }


                    dataGridView1.DataSource = dt;

                    break;
                case "直接材料费用":
                    if ((!cmbYear.Text.Trim().Equals("")) && (!cmbMonth.Text.Trim().Equals("")))
                    {
                        StuffExpenditureLogic stuffLogic = new StuffExpenditureLogic();
                        dt = stuffLogic.GetMixStuffExpenditure(cmbYear.Text, cmbMonth.Text);
                        dt = stuffLogic.groupBitumenStuffExpenditure(ref dt);
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("请选择年份与月份");
                    }
                    break;
                case "燃料动力费":
                    string year = cmbYear.Text;
                    string months = cmbMonth.Text;
                    dt = bitumenCLogic.autoFuelDriveExpenditureLogic(year, months);
                    // 用来分组的方法
                    dt = bitumenCLogic.groupBitumenFuelDrive(ref dt);
                    dataGridView1.DataSource = dt;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count != 0)
            {
                if (MessageBox.Show("确定要保存吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    return;

                bool saveSuccess;
                saveSuccess = bitumenCLogic.saveAutoCostTable(dt);
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
    }
}
