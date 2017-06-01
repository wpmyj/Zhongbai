using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.metage
{
    public partial class FrmOtherWeighing : BaseForm
    {
        OtherWeighingLogic logic = new OtherWeighingLogic();
        public FrmOtherWeighing()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOtherWeighingAdd form = new FrmOtherWeighingAdd();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
                findData();
        }
        private void InitForm()
        {            
            
            dataGridView1.DataSource = logic.GetThirdPartyWeight(CBName.Text, CBModel.Text, "");
            dataGridView1.Columns["id"].Visible = false;
        }
        private void findData()
        {
            dataGridView1.DataSource = logic.GetThirdPartyWeight(CBName.Text, CBModel.Text, CBClient.Text);
            dataGridView1.Columns["id"].Visible = false;
        }
        private void FrmOtherWeighing_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            findData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确定删除数据", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (logic.delData(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString()))
                    {
                        MessageBox.Show("删除成功");
                        findData();
                    }
                    else
                        MessageBox.Show("删除失败");

            }
        }
        
        
    }
}
