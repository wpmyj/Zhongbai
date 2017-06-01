using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using DasherStation.system;
using System.Collections;

namespace DasherStation.costCount
{
    public partial class FrmBitumenDetach : BaseForm
    {
        //标注窗体是属于哪个核算，1沥青加热，2乳化沥青与改性沥青核算，3混合料生产
        private int formSort;

        public int FormSort
        {
            get { return formSort; }
            set { formSort = value; }
        }
       
        public FrmBitumenDetach()
        {
            InitializeComponent();
        }

        CostCountDetailLogic costDetailLogic = new CostCountDetailLogic();
        private void button5_Click(object sender, EventArgs e)
        {          
            Close();
        }
        private void FormInit()
        {
            cmbYear.Text = DateTime.Now.Year.ToString();
            cmbMonth.Text = DateTime.Now.Month.ToString();         
            // 产品名称
            cmbProductName.DataSource = costDetailLogic.distillProductNameLogic();
            cmbProductName.DisplayMember = "name";
            cmbProductName.ValueMember = "pnId";
            cmbProductName.SelectedIndex = -1;
            Finddata();  
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDetachOption form = new FrmDetachOption();
            form.Year = cmbYear.Text;
            form.Month = cmbMonth.Text;
            YuanyuDBTemp db = new YuanyuDBTemp();
            bool isSelected = false;
             switch (formSort)
            {
                case 1:
                    form.FormSort = 1;
                    form.ShowDialog();                   
                    //YuanyuDBTemp db = new YuanyuDBTemp();
                    if (form.RecDataTable.Rows.Count > 0)
                    {
                        if (db.ExBitumenDetachData(dataGridView1, form.RecDataTable, isSelected))
                            MessageBox.Show("分滩成功");
                        else
                            MessageBox.Show("分滩失败");
                    }
                    else
                    {
                        MessageBox.Show("请选择要分滩的产品!!");
                    }
                    Finddata();
                    break;
                case 2:
                    form.FormSort = 2;
                    form.ShowDialog();
                    //YuanyuDBTemp db = new YuanyuDBTemp();
                    if (form.RecDataTable.Rows.Count > 0)
                    {
                        if (db.ExAlterBitumenDetachData(dataGridView1, form.RecDataTable, isSelected))
                            MessageBox.Show("分滩成功");
                        else
                            MessageBox.Show("分滩失败");
                    }
                    else
                    {
                        MessageBox.Show("请选择要分滩的产品!!"); 
                    }
                    Finddata();
                    break;
                case 3:
                    form.FormSort = 3;
                    form.ShowDialog();
                    //YuanyuDBTemp db = new YuanyuDBTemp();
                    if (form.RecDataTable.Rows.Count > 0)
                    {
                        if (db.ExMixBitumenDetachData(dataGridView1, form.RecDataTable, isSelected))
                            MessageBox.Show("分滩成功");
                        else
                            MessageBox.Show("分滩失败");
                    }
                    else
                    {
                        MessageBox.Show("请选择要分滩的产品!!");  
                    }
                    Finddata();
                    break;
            }           
        }
        private void Finddata()
        {
            DataTable dt = new DataTable();
            YuanyuDBTemp db = new YuanyuDBTemp();
            switch (formSort)
            {
                case 1:
                    dt = db.SelectBitumenDetachData(cmbYear.Text, cmbMonth.Text, cmbProductName.Text, cmbProductmodel.Text);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["ekId"].Visible = false;
                    dataGridView1.Columns["enId"].Visible = false;
                    dataGridView1.Columns["ecId"].Visible = false;
                    dataGridView1.Columns["eiId"].Visible = false;
                    dataGridView1.Columns["pId"].Visible = false;
                    //dataGridView1.Columns["自动还是手工"].Visible = false;
                    dataGridView1.Columns["自动还是手工"].ReadOnly = true;
                    break;
                case 2:
                    dt = db.SelectAlterBitumenDetachData(cmbYear.Text, cmbMonth.Text, cmbProductName.Text, cmbProductmodel.Text);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["ekId"].Visible = false;
                    dataGridView1.Columns["enId"].Visible = false;
                    dataGridView1.Columns["ecId"].Visible = false;
                    dataGridView1.Columns["eiId"].Visible = false;
                    dataGridView1.Columns["pId"].Visible = false;
                    //dataGridView1.Columns["自动还是手工"].Visible = false;
                    dataGridView1.Columns["自动还是手工"].ReadOnly = true;
                    break;
                case 3:
                    dt = db.SelectMixBitumenDetachData(cmbYear.Text, cmbMonth.Text, cmbProductName.Text, cmbProductmodel.Text);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["ekId"].Visible = false;
                    dataGridView1.Columns["enId"].Visible = false;
                    dataGridView1.Columns["ecId"].Visible = false;
                    dataGridView1.Columns["eiId"].Visible = false;
                    dataGridView1.Columns["pId"].Visible = false;
                    //dataGridView1.Columns["自动还是手工"].Visible = false;
                    dataGridView1.Columns["自动还是手工"].ReadOnly = true;
                    break;
            }
        }

        private void FrmBitumenDetach_Load(object sender, EventArgs e)
        {
            FormInit();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Finddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmDetachOption form = new FrmDetachOption();
            form.Year = cmbYear.Text;
            form.Month = cmbMonth.Text;
            YuanyuDBTemp db = new YuanyuDBTemp();
            bool isSelected = true;
            switch (formSort)
            {
                case 1:
                    form.FormSort = 1;
                    form.ShowDialog();
                    //YuanyuDBTemp db = new YuanyuDBTemp();
                    if (form.RecDataTable.Rows.Count > 0)
                    {
                        if (db.ExBitumenDetachData(dataGridView1, form.RecDataTable, isSelected))
                            MessageBox.Show("分滩成功");
                        else
                            MessageBox.Show("分滩失败");
                    }
                    else
                    {
                        MessageBox.Show("请选择要分滩的产品!!");
                    }
                    Finddata();
                    break;
                case 2:
                    form.FormSort = 2;
                    form.ShowDialog();
                    //YuanyuDBTemp db = new YuanyuDBTemp();
                    if (form.RecDataTable.Rows.Count > 0)
                    {
                        if (db.ExAlterBitumenDetachData(dataGridView1, form.RecDataTable, isSelected))
                            MessageBox.Show("分滩成功");
                        else
                            MessageBox.Show("分滩失败");
                    }
                    else
                    {
                        MessageBox.Show("请选择要分滩的产品!!");
                    }
                    Finddata();
                    break;
                case 3:
                    form.FormSort = 3;
                    form.ShowDialog();
                    //YuanyuDBTemp db = new YuanyuDBTemp();
                    if (form.RecDataTable.Rows.Count > 0)
                    {
                        if (db.ExMixBitumenDetachData(dataGridView1, form.RecDataTable, isSelected))
                            MessageBox.Show("分滩成功");
                        else
                            MessageBox.Show("分滩失败");
                    }
                    else
                    {
                        MessageBox.Show("请选择要分滩的产品!!");
                    }
                    Finddata();
                    break;
            }        
           
        }

               
    }
    class YuanyuDBTemp
    {
        SqlHelper sqlHelperObj = new SqlHelper();


        public int getEiId(string eINo)
        {
            DataTable dt = new DataTable();
            ArrayList sqlStr = new ArrayList();
            sqlStr.Add("select id from equipmentInformation where [no]=" + "'" + eINo + "'");

            dt = sqlHelperObj.QueryForDateSet(sqlStr).Tables[0];
            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0]["id"].ToString());
            return 0;
        }

        public bool ExBitumenDetachData(DataGridView grid, DataTable DetachDt, bool isSelected)
        {
            ArrayList sqlStr = new ArrayList();
            if (isSelected == false)
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    //确定分配基数,分滩是否能确定设备
                    DataTable tempDetachDt = new DataTable();
                    tempDetachDt.Columns.Add("pId");
                    tempDetachDt.Columns.Add("设备编号");
                    tempDetachDt.Columns.Add("eiId");
                    tempDetachDt.Columns.Add("工时");
                    if (grid.Rows[i].Cells["eiId"].Value.ToString().Trim().Equals(""))
                    {
                        tempDetachDt = DetachDt;
                    }
                    else
                    {
                        for (int j1 = 0; j1 < DetachDt.Rows.Count; j1++)
                        {
                            if (DetachDt.Rows[j1]["eiId"].ToString().Trim().Equals(grid.Rows[i].Cells["eiId"].Value.ToString().Trim()))
                            {
                                DataRow row = tempDetachDt.NewRow();
                                row["pid"] = DetachDt.Rows[j1]["pid"].ToString();
                                row["设备编号"] = DetachDt.Rows[j1]["设备编号"].ToString();
                                row["eiId"] = DetachDt.Rows[j1]["eiId"].ToString();
                                row["工时"] = DetachDt.Rows[j1]["工时"].ToString();
                                tempDetachDt.Rows.Add(row);
                            }
                        }
                    }
                    ///////////////////////////////////
                    bitumenExpenditureClass info = new bitumenExpenditureClass();

                    info.id = grid.Rows[i].Cells["Id"].Value.ToString();
                    info.ekId = grid.Rows[i].Cells["ekId"].Value.ToString();
                    info.enId = grid.Rows[i].Cells["enId"].Value.ToString();
                    info.ecId = grid.Rows[i].Cells["ecId"].Value.ToString();
                    info.expenditureDepict = grid.Rows[i].Cells["费用描述"].Value.ToString();
                    info.year = grid.Rows[i].Cells["年"].Value.ToString();
                    info.month = grid.Rows[i].Cells["月"].Value.ToString();
                    info.eiId = grid.Rows[i].Cells["eiId"].Value.ToString();
                    info.pId = grid.Rows[i].Cells["pId"].Value.ToString();
                    info.number = grid.Rows[i].Cells["数量"].Value.ToString();
                    info.unitPrice = grid.Rows[i].Cells["单价"].Value.ToString();                     
                    info.money = grid.Rows[i].Cells["金额"].Value.ToString();
                    info.inputDate = grid.Rows[i].Cells["录入时间"].Value.ToString();
                    info.inputMan = grid.Rows[i].Cells["录入人"].Value.ToString();
                    info.assessor = grid.Rows[i].Cells["审核人"].Value.ToString();
                    info.checkupMan = grid.Rows[i].Cells["审批人"].Value.ToString();
                    info.convert = grid.Rows[i].Cells["折算系数"].Value.ToString();
                    info.isAuto = grid.Rows[i].Cells["自动还是手工"].Value.ToString();
                    info.remark = grid.Rows[i].Cells["备注"].Value.ToString();
                    ArrayList list = BitumenDetachSql(info, tempDetachDt);
                    foreach (string s in list)
                    {
                        sqlStr.Add(s);
                    }

                }            
            }
            else
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    if ((grid.Rows[i].Cells["Column1"].Value!=null) && (grid.Rows[i].Cells["Column1"].Value.Equals(true)))
                    //确定分配基数,分滩是否能确定设备
                    {
                        DataTable tempDetachDt = new DataTable();
                        tempDetachDt.Columns.Add("pId");
                        tempDetachDt.Columns.Add("设备编号");
                        tempDetachDt.Columns.Add("eiId");
                        tempDetachDt.Columns.Add("工时");
                        if (grid.Rows[i].Cells["eiId"].Value.ToString().Trim().Equals(""))
                        {
                            tempDetachDt = DetachDt;
                        }
                        else
                        {
                            for (int j1 = 0; j1 < DetachDt.Rows.Count; j1++)
                            {
                                if (DetachDt.Rows[j1]["eiId"].ToString().Trim().Equals(grid.Rows[i].Cells["eiId"].Value.ToString().Trim()))
                                {
                                    DataRow row = tempDetachDt.NewRow();
                                    row["pid"] = DetachDt.Rows[j1]["pid"].ToString();
                                    row["设备编号"] = DetachDt.Rows[j1]["设备编号"].ToString();
                                    row["eiId"] = DetachDt.Rows[j1]["eiId"].ToString();
                                    row["工时"] = DetachDt.Rows[j1]["工时"].ToString();
                                    tempDetachDt.Rows.Add(row);
                                }
                            }
                        }
                        ///////////////////////////////////
                        bitumenExpenditureClass info = new bitumenExpenditureClass();

                        info.id = grid.Rows[i].Cells["Id"].Value.ToString();
                        info.ekId = grid.Rows[i].Cells["ekId"].Value.ToString();
                        info.enId = grid.Rows[i].Cells["enId"].Value.ToString();
                        info.ecId = grid.Rows[i].Cells["ecId"].Value.ToString();
                        info.expenditureDepict = grid.Rows[i].Cells["费用描述"].Value.ToString();
                        info.year = grid.Rows[i].Cells["年"].Value.ToString();
                        info.month = grid.Rows[i].Cells["月"].Value.ToString();
                        info.eiId = grid.Rows[i].Cells["eiId"].Value.ToString();
                        info.pId = grid.Rows[i].Cells["pId"].Value.ToString();
                        info.number = grid.Rows[i].Cells["数量"].Value.ToString();
                        info.unitPrice = grid.Rows[i].Cells["单价"].Value.ToString();
                        info.money = grid.Rows[i].Cells["金额"].Value.ToString();
                        info.inputDate = grid.Rows[i].Cells["录入时间"].Value.ToString();
                        info.inputMan = grid.Rows[i].Cells["录入人"].Value.ToString();
                        info.assessor = grid.Rows[i].Cells["审核人"].Value.ToString();
                        info.checkupMan = grid.Rows[i].Cells["审批人"].Value.ToString();
                        info.convert = grid.Rows[i].Cells["折算系数"].Value.ToString();
                        info.isAuto = grid.Rows[i].Cells["自动还是手工"].Value.ToString();
                        info.remark = grid.Rows[i].Cells["备注"].Value.ToString();
                        ArrayList list = BitumenDetachSql(info, tempDetachDt);
                        foreach (string s in list)
                        {
                            sqlStr.Add(s);
                        }

                    }                  
                }
            }
            if (sqlStr.Count > 0)
            {
                if (sqlHelperObj.ExecuteTransaction(sqlStr))
                    return true;
            }

            return false;

        }



        // 改性沥青和乳化沥青
        public bool ExAlterBitumenDetachData(DataGridView grid, DataTable DetachDt, bool isSelected)
        {
            ArrayList sqlStr = new ArrayList();
            if (isSelected == false)
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    //确定分配基数,分滩是否能确定设备
                    DataTable tempDetachDt = new DataTable();
                    tempDetachDt.Columns.Add("pId");
                    tempDetachDt.Columns.Add("设备编号");
                    tempDetachDt.Columns.Add("eiId");
                    tempDetachDt.Columns.Add("工时");
                    if (grid.Rows[i].Cells["eiId"].Value.ToString().Trim().Equals(""))
                    {
                        tempDetachDt = DetachDt;
                    }
                    else
                    {
                        for (int j1 = 0; j1 < DetachDt.Rows.Count; j1++)
                        {
                            if (DetachDt.Rows[j1]["eiId"].ToString().Trim().Equals(grid.Rows[i].Cells["eiId"].Value.ToString().Trim()))
                            {
                                DataRow row = tempDetachDt.NewRow();
                                row["pid"] = DetachDt.Rows[j1]["pid"].ToString();
                                row["设备编号"] = DetachDt.Rows[j1]["设备编号"].ToString();
                                row["eiId"] = DetachDt.Rows[j1]["eiId"].ToString();
                                row["工时"] = DetachDt.Rows[j1]["工时"].ToString();
                                tempDetachDt.Rows.Add(row);
                            }
                        }
                    }
                    ///////////////////////////////////
                    alterBitumenExpenditureClass info = new alterBitumenExpenditureClass();

                    info.id = grid.Rows[i].Cells["Id"].Value.ToString();
                    info.ekId = grid.Rows[i].Cells["ekId"].Value.ToString();
                    info.enId = grid.Rows[i].Cells["enId"].Value.ToString();
                    info.ecId = grid.Rows[i].Cells["ecId"].Value.ToString();
                    info.expenditureDepict = grid.Rows[i].Cells["费用描述"].Value.ToString();
                    info.year = grid.Rows[i].Cells["年"].Value.ToString();
                    info.month = grid.Rows[i].Cells["月"].Value.ToString();
                    info.eiId = grid.Rows[i].Cells["eiId"].Value.ToString();
                    info.pId = grid.Rows[i].Cells["pId"].Value.ToString();
                    info.number = grid.Rows[i].Cells["数量"].Value.ToString();
                    info.unitPrice = grid.Rows[i].Cells["单价"].Value.ToString();
                    info.money = grid.Rows[i].Cells["金额"].Value.ToString();
                    info.inputDate = grid.Rows[i].Cells["录入时间"].Value.ToString();
                    info.inputMan = grid.Rows[i].Cells["录入人"].Value.ToString();
                    info.assessor = grid.Rows[i].Cells["审核人"].Value.ToString();
                    info.checkupMan = grid.Rows[i].Cells["审批人"].Value.ToString();
                    info.convert = grid.Rows[i].Cells["折算系数"].Value.ToString();
                    info.isAuto = grid.Rows[i].Cells["自动还是手工"].Value.ToString();
                    info.remark = grid.Rows[i].Cells["备注"].Value.ToString();
                    ArrayList list = AlterBitumenDetachSql(info, tempDetachDt);
                    foreach (string s in list)
                    {
                        sqlStr.Add(s);
                    }

                }
            }
            else
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    if ((grid.Rows[i].Cells["Column1"].Value != null) && (grid.Rows[i].Cells["Column1"].Value.Equals(true)))
                    //确定分配基数,分滩是否能确定设备
                    {
                        DataTable tempDetachDt = new DataTable();
                        tempDetachDt.Columns.Add("pId");
                        tempDetachDt.Columns.Add("设备编号");
                        tempDetachDt.Columns.Add("eiId");
                        tempDetachDt.Columns.Add("工时");
                        if (grid.Rows[i].Cells["eiId"].Value.ToString().Trim().Equals(""))
                        {
                            tempDetachDt = DetachDt;
                        }
                        else
                        {
                            for (int j1 = 0; j1 < DetachDt.Rows.Count; j1++)
                            {
                                if (DetachDt.Rows[j1]["eiId"].ToString().Trim().Equals(grid.Rows[i].Cells["eiId"].Value.ToString().Trim()))
                                {
                                    DataRow row = tempDetachDt.NewRow();
                                    row["pid"] = DetachDt.Rows[j1]["pid"].ToString();
                                    row["设备编号"] = DetachDt.Rows[j1]["设备编号"].ToString();
                                    row["eiId"] = DetachDt.Rows[j1]["eiId"].ToString();
                                    row["工时"] = DetachDt.Rows[j1]["工时"].ToString();
                                    tempDetachDt.Rows.Add(row);
                                }
                            }
                        }
                        ///////////////////////////////////
                        alterBitumenExpenditureClass info = new alterBitumenExpenditureClass();

                        info.id = grid.Rows[i].Cells["Id"].Value.ToString();
                        info.ekId = grid.Rows[i].Cells["ekId"].Value.ToString();
                        info.enId = grid.Rows[i].Cells["enId"].Value.ToString();
                        info.ecId = grid.Rows[i].Cells["ecId"].Value.ToString();
                        info.expenditureDepict = grid.Rows[i].Cells["费用描述"].Value.ToString();
                        info.year = grid.Rows[i].Cells["年"].Value.ToString();
                        info.month = grid.Rows[i].Cells["月"].Value.ToString();
                        info.eiId = grid.Rows[i].Cells["eiId"].Value.ToString();
                        info.pId = grid.Rows[i].Cells["pId"].Value.ToString();
                        info.number = grid.Rows[i].Cells["数量"].Value.ToString();
                        info.unitPrice = grid.Rows[i].Cells["单价"].Value.ToString();
                        info.money = grid.Rows[i].Cells["金额"].Value.ToString();
                        info.inputDate = grid.Rows[i].Cells["录入时间"].Value.ToString();
                        info.inputMan = grid.Rows[i].Cells["录入人"].Value.ToString();
                        info.assessor = grid.Rows[i].Cells["审核人"].Value.ToString();
                        info.checkupMan = grid.Rows[i].Cells["审批人"].Value.ToString();
                        info.convert = grid.Rows[i].Cells["折算系数"].Value.ToString();
                        info.isAuto = grid.Rows[i].Cells["自动还是手工"].Value.ToString();
                        info.remark = grid.Rows[i].Cells["备注"].Value.ToString();
                        ArrayList list = AlterBitumenDetachSql(info, tempDetachDt);
                        foreach (string s in list)
                        {
                            sqlStr.Add(s);
                        }

                    }
                }
            }
            if (sqlStr.Count > 0)
            {
                if (sqlHelperObj.ExecuteTransaction(sqlStr))
                    return true;
            }

            return false;
        }
        // 混合料
        public bool ExMixBitumenDetachData(DataGridView grid, DataTable DetachDt, bool isSelected)
        {
            ArrayList sqlStr = new ArrayList();
            if (isSelected == false)
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    //确定分配基数,分滩是否能确定设备
                    DataTable tempDetachDt = new DataTable();
                    tempDetachDt.Columns.Add("pId");
                    tempDetachDt.Columns.Add("设备编号");
                    tempDetachDt.Columns.Add("eiId");
                    tempDetachDt.Columns.Add("工时");
                    if (grid.Rows[i].Cells["eiId"].Value.ToString().Trim().Equals(""))
                    {
                        tempDetachDt = DetachDt;
                    }
                    else
                    {
                        for (int j1 = 0; j1 < DetachDt.Rows.Count; j1++)
                        {
                            if (DetachDt.Rows[j1]["eiId"].ToString().Trim().Equals(grid.Rows[i].Cells["eiId"].Value.ToString().Trim()))
                            {
                                DataRow row = tempDetachDt.NewRow();
                                row["pid"] = DetachDt.Rows[j1]["pid"].ToString();
                                row["设备编号"] = DetachDt.Rows[j1]["设备编号"].ToString();
                                row["eiId"] = DetachDt.Rows[j1]["eiId"].ToString();
                                row["工时"] = DetachDt.Rows[j1]["工时"].ToString();
                                tempDetachDt.Rows.Add(row);
                            }
                        }
                    }
                    ///////////////////////////////////
                    expenditureClass info = new expenditureClass();

                    info.id = grid.Rows[i].Cells["Id"].Value.ToString();
                    info.ekId = grid.Rows[i].Cells["ekId"].Value.ToString();
                    info.enId = grid.Rows[i].Cells["enId"].Value.ToString();
                    info.ecId = grid.Rows[i].Cells["ecId"].Value.ToString();
                    info.expenditureDepict = grid.Rows[i].Cells["费用描述"].Value.ToString();
                    info.year = grid.Rows[i].Cells["年"].Value.ToString();
                    info.month = grid.Rows[i].Cells["月"].Value.ToString();
                    info.eiId = grid.Rows[i].Cells["eiId"].Value.ToString();
                    info.pId = grid.Rows[i].Cells["pId"].Value.ToString();
                    info.number = grid.Rows[i].Cells["数量"].Value.ToString();
                    info.unitPrice = grid.Rows[i].Cells["单价"].Value.ToString();
                    info.money = grid.Rows[i].Cells["金额"].Value.ToString();
                    info.inputDate = grid.Rows[i].Cells["录入时间"].Value.ToString();
                    info.inputMan = grid.Rows[i].Cells["录入人"].Value.ToString();
                    info.assessor = grid.Rows[i].Cells["审核人"].Value.ToString();
                    info.checkupMan = grid.Rows[i].Cells["审批人"].Value.ToString();
                    info.convert = grid.Rows[i].Cells["折算系数"].Value.ToString();
                    info.isAuto = grid.Rows[i].Cells["自动还是手工"].Value.ToString();
                    info.remark = grid.Rows[i].Cells["备注"].Value.ToString();
                    ArrayList list = MixBitumenDetachSql(info, tempDetachDt);
                    foreach (string s in list)
                    {
                        sqlStr.Add(s);
                    }

                }
            }
            else
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    if ((grid.Rows[i].Cells["Column1"].Value != null) && (grid.Rows[i].Cells["Column1"].Value.Equals(true)))
                    //确定分配基数,分滩是否能确定设备
                    {
                        DataTable tempDetachDt = new DataTable();
                        tempDetachDt.Columns.Add("pId");
                        tempDetachDt.Columns.Add("设备编号");
                        tempDetachDt.Columns.Add("eiId");
                        tempDetachDt.Columns.Add("工时");
                        if (grid.Rows[i].Cells["eiId"].Value.ToString().Trim().Equals(""))
                        {
                            tempDetachDt = DetachDt;
                        }
                        else
                        {
                            for (int j1 = 0; j1 < DetachDt.Rows.Count; j1++)
                            {
                                if (DetachDt.Rows[j1]["eiId"].ToString().Trim().Equals(grid.Rows[i].Cells["eiId"].Value.ToString().Trim()))
                                {
                                    DataRow row = tempDetachDt.NewRow();
                                    row["pid"] = DetachDt.Rows[j1]["pid"].ToString();
                                    row["设备编号"] = DetachDt.Rows[j1]["设备编号"].ToString();
                                    row["eiId"] = DetachDt.Rows[j1]["eiId"].ToString();
                                    row["工时"] = DetachDt.Rows[j1]["工时"].ToString();
                                    tempDetachDt.Rows.Add(row);
                                }
                            }
                        }
                        ///////////////////////////////////
                        expenditureClass info = new expenditureClass();

                        info.id = grid.Rows[i].Cells["Id"].Value.ToString();
                        info.ekId = grid.Rows[i].Cells["ekId"].Value.ToString();
                        info.enId = grid.Rows[i].Cells["enId"].Value.ToString();
                        info.ecId = grid.Rows[i].Cells["ecId"].Value.ToString();
                        info.expenditureDepict = grid.Rows[i].Cells["费用描述"].Value.ToString();
                        info.year = grid.Rows[i].Cells["年"].Value.ToString();
                        info.month = grid.Rows[i].Cells["月"].Value.ToString();
                        info.eiId = grid.Rows[i].Cells["eiId"].Value.ToString();
                        info.pId = grid.Rows[i].Cells["pId"].Value.ToString();
                        info.number = grid.Rows[i].Cells["数量"].Value.ToString();
                        info.unitPrice = grid.Rows[i].Cells["单价"].Value.ToString();
                        info.money = grid.Rows[i].Cells["金额"].Value.ToString();
                        info.inputDate = grid.Rows[i].Cells["录入时间"].Value.ToString();
                        info.inputMan = grid.Rows[i].Cells["录入人"].Value.ToString();
                        info.assessor = grid.Rows[i].Cells["审核人"].Value.ToString();
                        info.checkupMan = grid.Rows[i].Cells["审批人"].Value.ToString();
                        info.convert = grid.Rows[i].Cells["折算系数"].Value.ToString();
                        info.isAuto = grid.Rows[i].Cells["自动还是手工"].Value.ToString();
                        info.remark = grid.Rows[i].Cells["备注"].Value.ToString();
                        ArrayList list = MixBitumenDetachSql(info, tempDetachDt);
                        foreach (string s in list)
                        {
                            sqlStr.Add(s);
                        }

                    }
                }
            }
            if (sqlStr.Count > 0)
            {
                if (sqlHelperObj.ExecuteTransaction(sqlStr))
                    return true;
            }

            return false;
        }

        private ArrayList BitumenDetachSql(bitumenExpenditureClass info, DataTable tempDetachDt)
        {
            CostCountDB costCountDB = new CostCountDB();
            ArrayList sqlStr = new ArrayList();

            double dSum = 0;
            string sumMoney = info.money.ToString();
            tempDetachDt.Columns.Add("比例");
            for (int i = 0; i < tempDetachDt.Rows.Count; i++)
            {
                dSum += Double.Parse(tempDetachDt.Rows[i]["工时"].ToString());                
            }

            for (int i = 0; i < tempDetachDt.Rows.Count; i++)
            {
                info.pId = tempDetachDt.Rows[i]["pId"].ToString();
                info.eiId = tempDetachDt.Rows[i]["eiId"].ToString();
                info.money = (StrtoDouble(sumMoney) * (StrtoDouble(tempDetachDt.Rows[i]["工时"].ToString()) / dSum)).ToString();
                info.isFromDetach = "1";
                sqlStr.Add(costCountDB.insertExpenditure(info));
            }
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            ArrayList conds = new ArrayList();
            fields.Add("isDetach");
            values.Add("1");
            conds.Add("id=" + info.id);
            sqlStr.Add(costCountDB.UpdateTeble("bitumenWaitDetachExpenditure", fields, values,conds));

            return sqlStr;
        }

        private ArrayList AlterBitumenDetachSql(alterBitumenExpenditureClass info, DataTable tempDetachDt)
        {
            CostCountDB costCountDB = new CostCountDB();
            ArrayList sqlStr = new ArrayList();

            double dSum = 0;
            string sumMoney = info.money.ToString();
            tempDetachDt.Columns.Add("比例");
            for (int i = 0; i < tempDetachDt.Rows.Count; i++)
            {
                dSum += Double.Parse(tempDetachDt.Rows[i]["工时"].ToString());
            }

            for (int i = 0; i < tempDetachDt.Rows.Count; i++)
            {
                info.pId = tempDetachDt.Rows[i]["pId"].ToString();
                info.eiId = tempDetachDt.Rows[i]["eiId"].ToString();
                info.money = (StrtoDouble(sumMoney) * (StrtoDouble(tempDetachDt.Rows[i]["工时"].ToString()) / dSum)).ToString();
                info.isFromDetach = "1";
                sqlStr.Add(costCountDB.insertExpenditure(info));
            }
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            ArrayList conds = new ArrayList();
            fields.Add("isDetach");
            values.Add("1");
            conds.Add("id=" + info.id);
            sqlStr.Add(costCountDB.UpdateTeble("alterBitumenWaitDetachExpenditure", fields, values, conds));

            return sqlStr;
        }

        private ArrayList MixBitumenDetachSql(expenditureClass info, DataTable tempDetachDt)
        {
            CostCountDB costCountDB = new CostCountDB();
            ArrayList sqlStr = new ArrayList();

            double dSum = 0;
            string sumMoney = info.money.ToString();
            tempDetachDt.Columns.Add("比例");
            for (int i = 0; i < tempDetachDt.Rows.Count; i++)
            {
                dSum += Double.Parse(tempDetachDt.Rows[i]["工时"].ToString());
            }

            for (int i = 0; i < tempDetachDt.Rows.Count; i++)
            {
                info.pId = tempDetachDt.Rows[i]["pId"].ToString();
                info.eiId = tempDetachDt.Rows[i]["eiId"].ToString();
                info.money = (StrtoDouble(sumMoney) * (StrtoDouble(tempDetachDt.Rows[i]["工时"].ToString()) / dSum)).ToString();
                info.isFromDetach = "1";
                sqlStr.Add(costCountDB.insertExpenditure(info));
            }
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            ArrayList conds = new ArrayList();
            fields.Add("isDetach");
            values.Add("1");
            conds.Add("id=" + info.id);
            sqlStr.Add(costCountDB.UpdateTeble("WaitDetachExpenditure", fields, values, conds));

            return sqlStr;
        }

        private double StrtoDouble(string str)
        {
            if (!str.Trim().Equals(""))
            {
                try
                {
                    return Double.Parse(str);
                }
                catch
                {
                    return 0;
                }
            }
            else
                return 0;
        }

        //
        public DataTable SelectBitumenDetachData(string year,string month,string pName, string pModel)
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("bitumenWaitDetachExpenditure");
            linkS.TableNames.Add("expenditureName expenditureName1");
            linkS.LinkConds.Add("bitumenWaitDetachExpenditure.ekId=expenditureName1.id");
            linkS.TableNames.Add("expenditureName expenditureName2");
            linkS.LinkConds.Add("bitumenWaitDetachExpenditure.enId=expenditureName2.id");
            linkS.TableNames.Add("expenditureName expenditureName3");
            linkS.LinkConds.Add("bitumenWaitDetachExpenditure.ecId=expenditureName3.id");
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("bitumenWaitDetachExpenditure.eiId=equipmentInformation.id");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("bitumenWaitDetachExpenditure.pId=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");

            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.id");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.ekId");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.enId");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.ecId");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.pId");
            linkS.Viewfields.Add("expenditureName1.name as 费用类别");
            linkS.Viewfields.Add("expenditureName2.name as 费用名称");
            linkS.Viewfields.Add("expenditureName3.name as 费用明细");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.expenditureDepict as 费用描述");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.year as 年");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.month as 月");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.eiId");
            linkS.Viewfields.Add("equipmentInformation.[no] as 设备编号");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.number as 数量");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.unitPrice as 单价");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.money as 金额");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.inputDate as 录入时间");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.inputMan as 录入人");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.assessor as 审核人");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.checkupMan as 审批人");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.[convert] as 折算系数");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.isAuto as 自动还是手工");
            linkS.Viewfields.Add("bitumenWaitDetachExpenditure.remark as 备注");
            if (!year.Trim().Equals(""))
                linkS.Conds.Add("bitumenWaitDetachExpenditure.year=" + year);
            if (!month.Trim().Equals(""))
                linkS.Conds.Add("bitumenWaitDetachExpenditure.month=" + month);
            if (!pName.Trim().Equals(""))
                linkS.Conds.Add("productName.name=" + "'" + pName + "'");
            if (!pModel.Trim().Equals(""))
                linkS.Conds.Add("productModel.model=" + "'" + pModel + "'");
            linkS.Conds.Add("bitumenWaitDetachExpenditure.isDetach=0");

            return linkS.LeftLinkOpen().Tables[0];

        }

        public DataTable SelectAlterBitumenDetachData(string year, string month, string pName, string pModel)
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("alterBitumenWaitDetachExpenditure");
            linkS.TableNames.Add("expenditureName expenditureName1");
            linkS.LinkConds.Add("alterBitumenWaitDetachExpenditure.ekId=expenditureName1.id");
            linkS.TableNames.Add("expenditureName expenditureName2");
            linkS.LinkConds.Add("alterBitumenWaitDetachExpenditure.enId=expenditureName2.id");
            linkS.TableNames.Add("expenditureName expenditureName3");
            linkS.LinkConds.Add("alterBitumenWaitDetachExpenditure.ecId=expenditureName3.id");
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("alterBitumenWaitDetachExpenditure.eiId=equipmentInformation.id");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("alterBitumenWaitDetachExpenditure.pId=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");

            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.id");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.ekId");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.enId");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.ecId");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.pId");
            linkS.Viewfields.Add("expenditureName1.name as 费用类别");
            linkS.Viewfields.Add("expenditureName2.name as 费用名称");
            linkS.Viewfields.Add("expenditureName3.name as 费用明细");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.expenditureDepict as 费用描述");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.year as 年");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.month as 月");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.eiId");
            linkS.Viewfields.Add("equipmentInformation.[no] as 设备编号");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.number as 数量");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.unitPrice as 单价");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.money as 金额");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.inputDate as 录入时间");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.inputMan as 录入人");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.assessor as 审核人");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.checkupMan as 审批人");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.[convert] as 折算系数");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.isAuto as 自动还是手工");
            linkS.Viewfields.Add("alterBitumenWaitDetachExpenditure.remark as 备注");
            if (!year.Trim().Equals(""))
                linkS.Conds.Add("alterBitumenWaitDetachExpenditure.year=" + year);
            if (!month.Trim().Equals(""))
                linkS.Conds.Add("alterBitumenWaitDetachExpenditure.month=" + month);
            if (!pName.Trim().Equals(""))
                linkS.Conds.Add("productName.name=" + "'" + pName + "'");
            if (!pModel.Trim().Equals(""))
                linkS.Conds.Add("productModel.model=" + "'" + pModel + "'");
            linkS.Conds.Add("alterBitumenWaitDetachExpenditure.isDetach=0");

            return linkS.LeftLinkOpen().Tables[0];

        }

        public DataTable SelectMixBitumenDetachData(string year, string month, string pName, string pModel)
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("WaitDetachExpenditure");
            linkS.TableNames.Add("expenditureName expenditureName1");
            linkS.LinkConds.Add("WaitDetachExpenditure.ekId=expenditureName1.id");
            linkS.TableNames.Add("expenditureName expenditureName2");
            linkS.LinkConds.Add("WaitDetachExpenditure.enId=expenditureName2.id");
            linkS.TableNames.Add("expenditureName expenditureName3");
            linkS.LinkConds.Add("WaitDetachExpenditure.ecId=expenditureName3.id");
            linkS.TableNames.Add("equipmentInformation");
            linkS.LinkConds.Add("WaitDetachExpenditure.eiId=equipmentInformation.id");
            linkS.TableNames.Add("product");
            linkS.LinkConds.Add("WaitDetachExpenditure.pId=product.id");
            linkS.TableNames.Add("productName");
            linkS.LinkConds.Add("product.pnId=productName.id");
            linkS.TableNames.Add("productModel");
            linkS.LinkConds.Add("product.pmId=productModel.id");

            linkS.Viewfields.Add("WaitDetachExpenditure.id");
            linkS.Viewfields.Add("WaitDetachExpenditure.ekId");
            linkS.Viewfields.Add("WaitDetachExpenditure.enId");
            linkS.Viewfields.Add("WaitDetachExpenditure.ecId");
            linkS.Viewfields.Add("WaitDetachExpenditure.pId");
            linkS.Viewfields.Add("expenditureName1.name as 费用类别");
            linkS.Viewfields.Add("expenditureName2.name as 费用名称");
            linkS.Viewfields.Add("expenditureName3.name as 费用明细");
            linkS.Viewfields.Add("WaitDetachExpenditure.expenditureDepict as 费用描述");
            linkS.Viewfields.Add("WaitDetachExpenditure.year as 年");
            linkS.Viewfields.Add("WaitDetachExpenditure.month as 月");
            linkS.Viewfields.Add("WaitDetachExpenditure.eiId");
            linkS.Viewfields.Add("equipmentInformation.[no] as 设备编号");
            linkS.Viewfields.Add("WaitDetachExpenditure.number as 数量");
            linkS.Viewfields.Add("WaitDetachExpenditure.unitPrice as 单价");
            linkS.Viewfields.Add("WaitDetachExpenditure.money as 金额");
            linkS.Viewfields.Add("WaitDetachExpenditure.inputDate as 录入时间");
            linkS.Viewfields.Add("WaitDetachExpenditure.inputMan as 录入人");
            linkS.Viewfields.Add("WaitDetachExpenditure.assessor as 审核人");
            linkS.Viewfields.Add("WaitDetachExpenditure.checkupMan as 审批人");
            linkS.Viewfields.Add("WaitDetachExpenditure.[convert] as 折算系数");
            linkS.Viewfields.Add("WaitDetachExpenditure.isAuto as 自动还是手工");
            linkS.Viewfields.Add("WaitDetachExpenditure.remark as 备注");
            if (!year.Trim().Equals(""))
                linkS.Conds.Add("WaitDetachExpenditure.year=" + year);
            if (!month.Trim().Equals(""))
                linkS.Conds.Add("WaitDetachExpenditure.month=" + month);
            if (!pName.Trim().Equals(""))
                linkS.Conds.Add("productName.name=" + "'" + pName + "'");
            if (!pModel.Trim().Equals(""))
                linkS.Conds.Add("productModel.model=" + "'" + pModel + "'");
            linkS.Conds.Add("WaitDetachExpenditure.isDetach=0");

            return linkS.LeftLinkOpen().Tables[0];

        }
    }
}
