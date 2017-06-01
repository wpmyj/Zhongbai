/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：FrmInquiryStatistics.cs
* 文件功能描述：称重数据统计查询
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.metage
{
    public partial class FrmInquiryStatistics : BaseForm
    {

        MetageFindClass Findlogic = new MetageFindClass();
        public FrmInquiryStatistics()
        {
            InitializeComponent();
        }

        private void FrmInquiryStatistics_Load(object sender, EventArgs e)
        {
            InitForm();
            FindInfo();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitForm()
        {
            WeighingLogic logic = new WeighingLogic();
            MetageFindClass findClass = new MetageFindClass();
            
            logic.GetTruckNoItem(ref CBTruckNo);
            logic.GetContractItem(WeighingStyle.InStyle,ref CBContract);
            logic.GetSite(ref CBInSite);
            logic.GetSite(ref CBToSite);
            findClass.GetMateriaName(ref CBGoodsName);

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
            dt = Findlogic.FindInInfo(Conds);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            FindInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CBGoodsName_TextChanged(object sender, EventArgs e)
        {
            if ((CBGoodsName.SelectedIndex >= 0) && (CBGoodsName.ValueMember != ""))
            {
                MetageFindClass findClass = new MetageFindClass();
                findClass.GetMateriaModel(CBGoodsName.Text,ref CBModel);
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否审核所选记录", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    MetageFindClass findClass = new MetageFindClass();
                    InWeighingClass info = new InWeighingClass();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        info.Id = dataGridView1.SelectedRows[i].Cells["id"].Value.ToString();
                        info.Assessor = "审核人";
                        findClass.AssessorInInfo(info);
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
                    InWeighingClass info = new InWeighingClass();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        info.Id = dataGridView1.SelectedRows[i].Cells["id"].Value.ToString();
                        info.CheckupMan = "审批人";
                        findClass.checkupInInfo(info);
                    }
                    MessageBox.Show("审批完成");
                    FindInfo();
                }
            }
        }       
    }
}
