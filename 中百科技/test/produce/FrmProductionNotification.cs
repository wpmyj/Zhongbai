using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.produce
{
    public partial class FrmProductionNotification : common.BaseForm
    {
        public FrmProductionNotification()
        {
            InitializeComponent();
        }

        ProducePlan producePlan = new ProducePlan();

        AuditingAction auditingAction = new AuditingAction("id", "producenotice");


        //新建拌合机配合比窗体
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmProductionNotificationMixer fpnmform = new FrmProductionNotificationMixer();
                if (fpnmform.ShowDialog() == DialogResult.OK)
                {
                    dgvBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //窗体加载
        private void FrmProductionNotification_Load(object sender, EventArgs e)
        {

            
            try
            {
                dgvBind();
                producePlan.productKindBind(cmb_productKind);
                producePlan.productKindBind(cmb_productKind1);
                producePlan.productKindBind(cmb_productKind2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //绑定各配合比的通知单信息
        private void dgvBind()
        {
            producePlan.produceNoticeBind(this.dgv_notify, dgv_notify_1, dgv_notify_2, null);
        }

        //拌合机生产配合比删除按钮
        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否确认删除当前选中信息", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (dgv_notify.SelectedRows.Count > 0)
                    {
                        del(dgv_notify.SelectedRows[0].Cells["id"].Value.ToString());
                    }
                    dgvBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        //执行删除通知单操作
        private void del(string pnId)
        {
            producePlan.delProduceNotice(pnId);
        }

        //拌合机生产配合比查询按钮
        private void btn_query_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlStr = producePlan.getNoticeSqlString(dtp_start, dtp_end, cmb_productName, cmb_productModel);
                Querry(sqlStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //选择种类绑定名称
        private void cmb_productKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productKind.SelectedIndex != -1)
            {
                cmb_productName.DataSource = null;
                cmb_productName.Items.Clear();
                producePlan.productNameBind(cmb_productName, cmb_productKind.SelectedValue.ToString());
                cmb_productModel.DataSource = null;
                cmb_productModel.Items.Clear();
            }
        }

        //选择名称选择规格
        private void cmb_productName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productName.SelectedIndex != -1)
            {
                producePlan.productModelBind(cmb_productModel, cmb_productName.SelectedValue.ToString());
            }
        }

        //新建改性沥青生产通知单按钮
        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
                FrmProductionNotificationBitumen fpnbform = new FrmProductionNotificationBitumen();
                fpnbform.Mark2 = ProducePlan.pType.RestructureAsphaltum;
                if (fpnbform.ShowDialog() == DialogResult.OK)
                {
                    dgvBind();
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

        }

        //新建乳化沥青生产通知单按钮
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                FrmProductionNotificationBitumen fpnbform = new FrmProductionNotificationBitumen();
                fpnbform.Mark2 = ProducePlan.pType.EmulsificationAsphaltum;
                if (fpnbform.ShowDialog() == DialogResult.OK)
                {
                    dgvBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //乳化沥青查询按钮
        private void btn_query2_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlStr = producePlan.getNoticeSqlString(dtp_start2, dtp_end2, cmb_productName2, cmb_productModel2);
                Querry(sqlStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        //生产通知单查询操作
        private void Querry(string sqlStr)
        {
            producePlan.produceNoticeBind(this.dgv_notify, dgv_notify_1, dgv_notify_2, sqlStr);
        }

        //生产配合比查询按钮
        private void btn_query1_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlStr = producePlan.getNoticeSqlString(dtp_start1, dtp_end1, cmb_productName1, cmb_productModel1);
                Querry(sqlStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //选项卡切换按钮
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            dgvBind();
        }

        //改性沥青删除按钮
        private void btn_del1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否确认删除当前选中信息", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (dgv_notify.SelectedRows.Count > 0)
                    {
                        del(dgv_notify_1.SelectedRows[0].Cells["id1"].Value.ToString());
                    }
                    dgvBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //乳化沥青删除按钮
        private void btn_del2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否确认删除当前选中信息", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (dgv_notify.SelectedRows.Count > 0)
                    {
                        del(dgv_notify_2.SelectedRows[0].Cells["id2"].Value.ToString());
                    }
                    dgvBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //选择种类绑定名称
        private void cmb_productKind1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productKind1.SelectedIndex != -1)
            {
                cmb_productName1.DataSource = null;
                cmb_productName1.Items.Clear();
                producePlan.productNameBind(cmb_productName1, cmb_productKind1.SelectedValue.ToString());
                cmb_productModel1.DataSource = null;
                cmb_productModel1.Items.Clear();
            }
        }

        //选择种类绑定名称
        private void cmb_productKind2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productKind2.SelectedIndex != -1)
            {
                cmb_productName2.DataSource = null;
                cmb_productName2.Items.Clear();
                producePlan.productNameBind(cmb_productName2, cmb_productKind2.SelectedValue.ToString());
                cmb_productModel2.DataSource = null;
                cmb_productModel2.Items.Clear();
            }
        }

        //选择名称选择规格
        private void cmb_productName2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productName2.SelectedIndex != -1)
            {
                producePlan.productModelBind(cmb_productModel2, cmb_productName2.SelectedValue.ToString());
            }
        }

        //选择名称选择规格
        private void cmb_productName1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productName1.SelectedIndex != -1)
            {
                producePlan.productModelBind(cmb_productModel1, cmb_productName1.SelectedValue.ToString());
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (dgv_notify.SelectedRows.Count > 0)
            {
                ReportProductClass report = new ReportProductClass();
                report.RunMixingMachineProduceNotice(dgv_notify.SelectedRows[0].Cells["id"].Value.ToString());
                //ReportProductionNotification reportProductionNotification = new ReportProductionNotification();
                //reportProductionNotification.PNID = dgv_notify.SelectedRows[0].Cells["id"].Value.ToString();
                //reportProductionNotification.ShowDialog();
            }
        }

        private void btn_assessor_Click(object sender, EventArgs e)
        {
            DoAssessor(dgv_notify, "id", "assessor");
        }

        private void btn_checkupMan_Click(object sender, EventArgs e)
        {
            DoCheckup(dgv_notify, "id", "assessor", "checkupMan");
        }

        private void btn_assessor1_Click(object sender, EventArgs e)
        {
            DoAssessor(dgv_notify_1, "id1", "assessor1");
        }

        private void btn_checkupMan1_Click(object sender, EventArgs e)
        {
            DoCheckup(dgv_notify_1, "id1", "assessor1", "checkupMan1");
        }

        private void btn_checkupMan2_Click(object sender, EventArgs e)
        {
            DoCheckup(dgv_notify_2, "id2", "assessor2", "checkupMan2");
        }

        private void btn_assessor2_Click(object sender, EventArgs e)
        {
            DoAssessor(dgv_notify_2, "id2", "assessor2");
        }

        private void DoAssessor(DataGridView dgv, string id, string Assessor)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确认审核选中运输合同", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvr in dgv.SelectedRows)
                    {
                        switch (auditingAction.DoAssessor(long.Parse(dgvr.Cells[id].Value.ToString()), this.UserName))
                        {
                            case 0:
                                dgvr.Cells[Assessor].Value = this.UserName;
                                break;
                            case 1:
                                MessageBox.Show("该信息已被审核过", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                break;
                            default:
                                MessageBox.Show("审核失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                break;
                        }
                    }
                }
            }
        }

        private void DoCheckup(DataGridView dgv,string id,string Assessor, string Checkup)
        {
            if (dgv.SelectedRows.Count > 0)
            {

                FrmConfirm frmConfirm = new FrmConfirm();

                if (frmConfirm.ShowDialog() == DialogResult.OK)
                {
                    int result = auditingAction.DoConfirm(long.Parse(dgv.SelectedRows[0].Cells[id].Value.ToString()), this.UserName, frmConfirm.Confirm);
                    switch (result)
                    {
                        case 0:
                            if (frmConfirm.Confirm)
                            {
                                dgv.SelectedRows[0].Cells[Checkup].Value = this.UserName;
                            }
                            else
                            {
                                dgv.SelectedRows[0].Cells[Assessor].Value = "";
                                dgv.SelectedRows[0].Cells[Checkup].Value = "";
                            }
                            break;
                        case 1:
                            MessageBox.Show("该信息已被审批过", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            break;
                        case 3:
                            MessageBox.Show("信息审核之前不能被审批", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            break;
                        default:
                            MessageBox.Show("审批失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            break;
                    }
                }
            }
        }

    }
}
