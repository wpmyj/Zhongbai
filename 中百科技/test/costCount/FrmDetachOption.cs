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
    public partial class FrmDetachOption : BaseForm
    {
        //标注窗体是属于哪个核算，1沥青加热，2乳化沥青与改性沥青核算，3混合料生产
        private int formSort;

        public int FormSort
        {
            get { return formSort; }
            set { formSort = value; }
        }
        private DataTable recDataTable;
        public DataTable RecDataTable
        {
            get { return recDataTable; }
            set { recDataTable = value; }
        }
        // 年月的值设置为属性以使其能在分摊选项中被访问
        private string year;

        public string Year
        {
            get { return this.year; }
            set { this.year = value; }
        }

        private string month;

        public string Month
        {
            get { return this.month; }
            set { this.month = value; }
        }
        public FrmDetachOption()
        {
            InitializeComponent();
        }

        private void FormInit()
        {
            recDataTable = new DataTable();
            recDataTable.Columns.Add("pId");
            recDataTable.Columns.Add("设备编号");
            recDataTable.Columns.Add("eiId");            
            recDataTable.Columns.Add("工时");

            cmbYear.Text = year;
            cmbMonth.Text = month;

            costDetachDB db = new costDetachDB();
            DataTable dt = new DataTable();           
                      
                switch (formSort)
                {
                    case 1:
                        //costDetachDB db = new costDetachDB();
                        //DataTable dt = new DataTable();

                        //dt = db.SelectbitumenDetachParameter("2009", "3", 1);

                        dt = db.SelectbitumenDetachParameter(cmbYear.Text, cmbMonth.Text, 1);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["pid"].Visible = false;

                        break;
                    case 2:
                        //costDetachDB db = new costDetachDB();
                        //DataTable dt = new DataTable();
                        //dt = db.SelectbitumenDetachParameter("2009", "3", 2);

                        dt = db.SelectbitumenDetachParameter(cmbYear.Text, cmbMonth.Text, 2);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["pid"].Visible = false;

                        break;
                    case 3:
                        //costDetachDB db = new costDetachDB();
                        //DataTable dt = new DataTable();
                        //dt = db.SelectbitumenDetachParameter("2009", "3", 3);

                        dt = db.SelectbitumenDetachParameter(cmbYear.Text, cmbMonth.Text, 3);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["pid"].Visible = false;

                        break;
                }           
        }

        private void FrmDetachOption_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认分滩数据!!", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                YuanyuDBTemp dbLayer = new YuanyuDBTemp();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((dataGridView1.Rows[i].Cells["Column1"].Value!=null) && (dataGridView1.Rows[i].Cells["Column1"].Value.Equals(true)))                   
                    {
                        DataRow row = recDataTable.NewRow();
                        row["pId"] = dataGridView1.Rows[i].Cells["pId"].Value.ToString();
                        row["设备编号"] = dataGridView1.Rows[i].Cells["设备编号"].Value.ToString();
                        row["工时"] = dataGridView1.Rows[i].Cells["工时"].Value.ToString();
                        row["eiId"] = dbLayer.getEiId(row["设备编号"].ToString());

                        recDataTable.Rows.Add(row);
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmbYear_TextChanged(object sender, EventArgs e)
        {
            recDataTable = new DataTable();
            recDataTable.Columns.Add("pId");
            recDataTable.Columns.Add("设备编号");
            recDataTable.Columns.Add("eiId");
            recDataTable.Columns.Add("工时");           

            costDetachDB db = new costDetachDB();
            DataTable dt = new DataTable();

            switch (formSort)
            {
                case 1:                  
                    dt = db.SelectbitumenDetachParameter(cmbYear.Text, cmbMonth.Text, 1);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["pid"].Visible = false;

                    break;
                case 2:
                    dt = db.SelectbitumenDetachParameter(cmbYear.Text, cmbMonth.Text, 2);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["pid"].Visible = false;

                    break;
                case 3:              
                    dt = db.SelectbitumenDetachParameter(cmbYear.Text, cmbMonth.Text, 3);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["pid"].Visible = false;

                    break;
            }           
        }

        private void cmbMonth_TextChanged(object sender, EventArgs e)
        {
            recDataTable = new DataTable();
            recDataTable.Columns.Add("pId");
            recDataTable.Columns.Add("设备编号");
            recDataTable.Columns.Add("eiId");
            recDataTable.Columns.Add("工时");

            costDetachDB db = new costDetachDB();
            DataTable dt = new DataTable();

            switch (formSort)
            {
                case 1:
                    dt = db.SelectbitumenDetachParameter(cmbYear.Text, cmbMonth.Text, 1);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["pid"].Visible = false;

                    break;
                case 2:
                    dt = db.SelectbitumenDetachParameter(cmbYear.Text, cmbMonth.Text, 2);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["pid"].Visible = false;

                    break;
                case 3:
                    dt = db.SelectbitumenDetachParameter(cmbYear.Text, cmbMonth.Text, 3);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["pid"].Visible = false;

                    break;
            }           
        }
    }
}
