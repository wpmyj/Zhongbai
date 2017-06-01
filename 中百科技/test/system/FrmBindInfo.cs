/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：BindInfo
     * 文件功能描述：车卡绑定窗体
     *
     * 创建人：袁宇
     * 创建时间：2009-02-20
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using System.Collections;

namespace DasherStation.system
{
    public partial class FrmBindInfo : common.BaseForm
    {
        BindInfoLogic bindLogic = new BindInfoLogic();
        public FrmBindInfo()
        {
            InitializeComponent();
        }     

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            FrmBindInfoAdd bindInfoAdd = new FrmBindInfoAdd();            
            
            bindInfoAdd.ShowDialog();
            FindView();           
        }

        private void FrmBindInfo_Load(object sender, EventArgs e)
        {
            FindView();
            SetColumnsWidth();
        }
        private void SetColumnsWidth()
        {
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 110;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 100;
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].Width = 100;
        }
        private void FindView()
        {
            DataSet ds = new DataSet();

            switch (CBFind.Text.Trim())
            {
                case "运输单位":
                    ds = bindLogic.GetBindInfo(textBox1.Text, "", "");
                    break;
                case "车牌号":
                    ds = bindLogic.GetBindInfo("", textBox1.Text, "");
                    break;
                case "卡号":
                    ds = bindLogic.GetBindInfo("", "", textBox1.Text);
                    break;
                default:
                    ds = bindLogic.GetBindInfo("", "", "");
                    break;
            }

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["id"].Visible = false; 

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            FindView();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                FrmBindInfoAdd bindInfoAdd = new FrmBindInfoAdd();

                bindInfoAdd.FormMode = 1;
                bindInfoAdd.Unit = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                bindInfoAdd.TruckNo = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                bindInfoAdd.CardNo = dataGridView1.CurrentRow.Cells[3].Value.ToString();                
                bindInfoAdd.ShowDialog();
                FindView();                 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确认取消绑定卡与车辆信息", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        bindLogic.Cardblankout(dataGridView1.SelectedRows[i].Cells[0].Value.ToString());                        
                    }
                    FindView();
                }
                
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

    }
}
