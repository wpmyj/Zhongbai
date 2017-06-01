using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DasherStation.common;

namespace DasherStation.stock
{
    public partial class materialNeeding :common.BaseForm 
    {
        public materialNeeding()
        {
            InitializeComponent();
        }
        purchaseScheDetaillogic stockPlanDetail = new purchaseScheDetaillogic();

       
        //private string year;
        //public string Year
        //{
        //    get { return this.year; }
        //    set { this.year = value; }
        //}
        // 材料需求计划表就用当年的
        private void materialNeeding_Load(object sender, EventArgs e)
        {
            txtYear.Text = DateTime.Now.Year.ToString();
            showMaterialNeedPlan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showMaterialNeedPlan();
        }
        private void showMaterialNeedPlan()
        {
            string year = txtYear.Text;
            if (txtYear.Text == "")
            {
                MessageBox.Show("查询年份不能为空请输入年份！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (!Check.CheckNumber(txtYear.Text))
                {
                    MessageBox.Show("请输入正确的年份格式，如“2009”！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.DataSource = stockPlanDetail.materialNeedPlanShowLogic(year);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 以后可能用到的方法
            int count=0;
            foreach (DataGridViewRow dgvr in dataGridView1.Rows )
            {
                if (dgvr.Selected)
                {
                    count = count + 1;
                }
            }
            if (count > 1)
            {
                MessageBox.Show("只能选中一行进行赋值", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //ArrayList list=new ArrayList();
               

            }
        }
       
    }
}
