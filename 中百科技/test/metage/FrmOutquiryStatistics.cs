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
    public partial class FrmOutquiryStatistics : BaseForm
    {
        MetageFindClass Findlogic = new MetageFindClass();

        public FrmOutquiryStatistics()
        {
            InitializeComponent();
        }

        
        private void InitForm()
        {
            WeighingLogic logic = new WeighingLogic();
            MetageFindClass findClass = new MetageFindClass();

            logic.GetTruckNoItem(ref CBTruckNo);
            logic.GetContractItem(WeighingStyle.OutStyle, ref CBContract);   
            logic.GetSite(ref CBInSite);
            logic.GetSite(ref CBToSite);
            findClass.GetProductName(ref CBGoodsName);
            FindInfo();
        }
        private void FindInfo()
        {
            FindCondClass Conds = new FindCondClass();
            DataTable dt = new DataTable();

            Conds.TruckNo = CBTruckNo.Text;
            Conds.ContractName = CBContract.Text;
            Conds.GoodsName = CBGoodsName.Text;
            Conds.GoodsModel = CBModel.Text;
            Conds.InSite = CBInSite.Text;
            Conds.ToSite = CBToSite.Text;
            if (checkBox1.Checked)
                Conds.InDate = date1.Value.ToString();
            if (checkBox2.Checked)
                Conds.ToDate = date2.Value.ToString();
            switch (CBStyle.Text)
            {
                case "待审核":
                    Conds.Style = "0";
                    break;
                case "待审批":
                    Conds.Style = "1";
                    break;
                case "审核审批通过":
                    Conds.Style = "2";
                    break;
                default:
                    Conds.Style = "";
                    break;
            }
            dt = Findlogic.FindOutInfo(Conds);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;
        }       

        private void CBGoodsName_TextChanged(object sender, EventArgs e)
        {
            if ((CBGoodsName.SelectedIndex >= 0) && (CBGoodsName.ValueMember != ""))
            {
                MetageFindClass findClass = new MetageFindClass();
                findClass.GetProductModel(CBGoodsName.Text, ref CBModel);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                date1.Enabled = true;
            }
            else
            {
                date1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                date2.Enabled = true;
            }
            else
            {
                date2.Enabled = false;
            }
        }

        private void btnQuery_Click_1(object sender, EventArgs e)
        {
            FindInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否审核所选记录", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    MetageFindClass findClass = new MetageFindClass();
                    OutWeighingClass info = new OutWeighingClass();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        info.Id = dataGridView1.SelectedRows[i].Cells["id"].Value.ToString();
                        info.Assessor = "审核人";
                        findClass.AssessorOutInfo(info);
                    }
                    MessageBox.Show("审核完成");
                    FindInfo();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否审批所选记录", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    MetageFindClass findClass = new MetageFindClass();
                    OutWeighingClass info = new OutWeighingClass();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        info.Id = dataGridView1.SelectedRows[i].Cells["id"].Value.ToString();
                        info.CheckupMan = "审批人";
                        findClass.checkupOutInfo(info);
                    }
                    MessageBox.Show("审批完成");
                    FindInfo();
                }
            }
        }

        private void FrmOutquiryStatistics_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }
        
    }
}
