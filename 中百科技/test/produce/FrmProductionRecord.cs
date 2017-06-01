using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.produce;
using DasherStation.common;
using DasherStation.storage;

namespace DasherStation.produce
{
    public partial class FrmProductionRecord : common.BaseForm 
    {
        public FrmProductionRecord()
        {
            InitializeComponent();
        }

        ProducePlan producePlan = new ProducePlan();

        StockStatLogic stockStatLogic = new StockStatLogic();

        AuditingAction auditingAction = new AuditingAction("id", "mixtureProduceLog");

        AuditingAction auditingAction1 = new AuditingAction("id", "emulsificationAsphaltumProduceLog");

        AuditingAction auditingAction2 = new AuditingAction("id", "restructureAsphaltumProduceLog");

        private void FrmProductionRecord_Load(object sender, EventArgs e)
        {
            dgvBind(dgv_ProduceLog, ProducePlan.pType.Mixture);
            kingBind();

            auditingAction.AuditingEvent += new AuditingEventHandler(producePlan.AfterRecordConfirmInsert);
            auditingAction1.AuditingEvent += new AuditingEventHandler(producePlan.AfterRecordConfirmInsert1);
            auditingAction2.AuditingEvent += new AuditingEventHandler(producePlan.AfterRecordConfirmInsert2);
        }

        private void kingBind()
        {
            producePlan.productKindBind(cmb_productKind);
            producePlan.productKindBind(cmb_productKind1);
            producePlan.productKindBind(cmb_productKind2);         
        }

        private void dgvBind(DataGridView dgv,ProducePlan.pType type)
        {
            producePlan.ProduceLogBind(dgv, null, type);
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlStr = producePlan.getProduceSqlString(dtp_start, dtp_end, cmb_productName, cmb_productModel,null,null,null);
                query(dgv_ProduceLog, sqlStr, ProducePlan.pType.Mixture);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }       
        }

        private void query(DataGridView dgv,string strWhere,ProducePlan.pType type)
        {
            producePlan.ProduceLogBind(dgv, strWhere, type);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            FrmProductionRecordMix fprmform = new FrmProductionRecordMix();
            if (fprmform.ShowDialog() == DialogResult.OK)
            {
                dgvBind(dgv_ProduceLog,ProducePlan.pType.Mixture);
            }
        }

        private void cmb_productKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productKind.SelectedIndex != -1)
            {
                cmb_productName.DataSource = null;
                cmb_productName.Items.Clear();
                producePlan.productNameBind(cmb_productName,cmb_productKind.SelectedValue.ToString());
                cmb_productModel.DataSource = null;
                cmb_productModel.Items.Clear();
            }
        }

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
       
        private void cmb_productName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productName.SelectedIndex != -1)
            {
                producePlan.productModelBind(cmb_productModel, cmb_productName.SelectedValue.ToString());
            }
        }

        private void cmb_productName1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productName1.SelectedIndex != -1)
            {
                producePlan.productModelBind(cmb_productModel1, cmb_productName1.SelectedValue.ToString());
            }
        }

        private void cmb_productName2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_productName2.SelectedIndex != -1)
            {
                producePlan.productModelBind(cmb_productModel2, cmb_productName2.SelectedValue.ToString());
            }
        }       

        private void btn_new1_Click(object sender, EventArgs e)
        {
            FrmProductionRecordRBitumen fprrbform = new FrmProductionRecordRBitumen();
            fprrbform.Mark2 = 1;
            if (fprrbform.ShowDialog() == DialogResult.OK)
            {
                dgvBind(dgv_ProduceLog1,ProducePlan.pType.EmulsificationAsphaltum);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    dgvBind(dgv_ProduceLog,ProducePlan.pType.Mixture);
                    break;
                case 1:
                    dgvBind(dgv_ProduceLog1, ProducePlan.pType.EmulsificationAsphaltum);
                    break;
                case 2:
                    dgvBind(dgv_ProduceLog2, ProducePlan.pType.RestructureAsphaltum);
                    break;
                case 3:
                    dgvBind(dgv_ProduceLog3, ProducePlan.pType.AgainCalefaction);
                    break;
                default:                 
                    break;
            }
            
        }

        private void btn_query1_Click(object sender, EventArgs e)
        {
            string sqlStr = producePlan.getProduceSqlString(dtp_start1, dtp_end1, cmb_productName1, cmb_productModel1, null,null,null);
            query(dgv_ProduceLog1,sqlStr, ProducePlan.pType.EmulsificationAsphaltum);
        }

        private void btn_query2_Click(object sender, EventArgs e)
        {
            string sqlStr = producePlan.getProduceSqlString(dtp_start2, dtp_end2, cmb_productName2, cmb_productModel2, null,null, null);
            query(dgv_ProduceLog2, sqlStr, ProducePlan.pType.RestructureAsphaltum);
        }

        private void btn_query3_Click(object sender, EventArgs e)
        {
            string sqlStr = producePlan.getProduceSqlString(dtp_start3, dtp_end3, null, null, null, null, null);
            query(dgv_ProduceLog3, sqlStr, ProducePlan.pType.AgainCalefaction);
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认删除当前选中信息", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                del(dgv_ProduceLog, ProducePlan.pType.Mixture);
                dgvBind(dgv_ProduceLog, ProducePlan.pType.Mixture);
            }       
        }

        private void btn_del1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认删除当前选中信息", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                del(dgv_ProduceLog1, ProducePlan.pType.EmulsificationAsphaltum);
                dgvBind(dgv_ProduceLog1, ProducePlan.pType.EmulsificationAsphaltum);
            }    
        }

        private void btn_del2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认删除当前选中信息", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                del(dgv_ProduceLog2, ProducePlan.pType.RestructureAsphaltum);
                dgvBind(dgv_ProduceLog2, ProducePlan.pType.RestructureAsphaltum);
            }    
        }

        private void btn_del3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认删除当前选中信息", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                del(dgv_ProduceLog3, ProducePlan.pType.AgainCalefaction);
                dgvBind(dgv_ProduceLog3, ProducePlan.pType.AgainCalefaction);
            }    
        }

        private void btn_new2_Click(object sender, EventArgs e)
        {
            FrmProductionRecordRBitumen fprrbform = new FrmProductionRecordRBitumen();
            fprrbform.Mark2 = 0;
            if (fprrbform.ShowDialog() == DialogResult.OK)
            {
                dgvBind(dgv_ProduceLog2, ProducePlan.pType.RestructureAsphaltum);
            }
        }

        private void btn_new3_Click(object sender, EventArgs e)
        {
            FrmProductionRecordBitumenWarm frmProductionRecordBitumenWarm = new FrmProductionRecordBitumenWarm();
            if (frmProductionRecordBitumenWarm.ShowDialog() == DialogResult.OK)
            {
                dgvBind(dgv_ProduceLog3, ProducePlan.pType.AgainCalefaction);
            }
        }

        private void btn_close3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_close1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_close2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void del(DataGridView dgv,ProducePlan.pType type)
        {
            if(dgv.SelectedRows.Count>0)
            {
                producePlan.delProduceLog(dgv.SelectedRows[0].Cells[0].Value.ToString(), type);
            }
        }

        private void DoAssessor(DataGridView dgv, AuditingAction auditingAction, string id, string Assessor, string AssessorDate)
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
                                dgvr.Cells[AssessorDate].Value = DateTime.Now.ToShortDateString();
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

        private void DoCheckup(DataGridView dgv, AuditingAction auditingAction, string id, string Assessor, string AssessorDate, string Checkup, string checkupDate)
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
                                dgv.SelectedRows[0].Cells[checkupDate].Value = DateTime.Now.ToShortDateString();
                            }
                            else
                            {
                                dgv.SelectedRows[0].Cells[Assessor].Value = "";
                                dgv.SelectedRows[0].Cells[Checkup].Value = "";
                                dgv.SelectedRows[0].Cells[checkupDate].Value = "";
                                dgv.SelectedRows[0].Cells[AssessorDate].Value = "";
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

        private void btn_assessor_Click(object sender, EventArgs e)
        {
            DoAssessor(dgv_ProduceLog,auditingAction, "id", "assessor", "assessDate");
        }

        private void btn_checkupMan_Click(object sender, EventArgs e)
        {
            DoCheckup(dgv_ProduceLog, auditingAction, "id", "assessor", "assessDate", "checkupMan", "checkupDate");
            stockStatLogic.Stock_Material();
            stockStatLogic.Stock_Product();
        }

        private void btn_assessor1_Click(object sender, EventArgs e)
        {
            DoAssessor(dgv_ProduceLog1, auditingAction1, "id1", "assessor1", "assessDate1");
        }

        private void btn_checkupMan1_Click(object sender, EventArgs e)
        {
            DoCheckup(dgv_ProduceLog1, auditingAction1, "id1", "assessor1", "assessDate1", "checkupMan1", "checkupDate1");
            stockStatLogic.Stock_Material();
            stockStatLogic.Stock_Product();
        }

        private void btn_assessor2_Click(object sender, EventArgs e)
        {
            DoAssessor(dgv_ProduceLog2, auditingAction2, "id2", "assessor2", "assessDate2");
        }

        private void btn_checkupMan2_Click(object sender, EventArgs e)
        {
            DoCheckup(dgv_ProduceLog2, auditingAction2, "id2", "assessor2", "assessDate2", "checkupMan2", "checkupDate2");
            stockStatLogic.Stock_Material();
            stockStatLogic.Stock_Product();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgv_ProduceLog.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgv_ProduceLog.SelectedRows[0].Cells["id"].Value.ToString());
                long ppid = long.Parse(dgv_ProduceLog.SelectedRows[0].Cells["ppid"].Value.ToString());
                long tpid = long.Parse(dgv_ProduceLog.SelectedRows[0].Cells["tpid"].Value.ToString());

                producePlan.PrintRecordMix(id,ppid,tpid);
            }
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            if (dgv_ProduceLog1.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgv_ProduceLog1.SelectedRows[0].Cells["id1"].Value.ToString());
                long pid = long.Parse(dgv_ProduceLog1.SelectedRows[0].Cells["pid1"].Value.ToString());

                producePlan.PrintRecordRBitumen(id, pid);
            }
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            
            if(dgv_ProduceLog2.SelectedRows.Count > 0)
            {
                long id = long.Parse(dgv_ProduceLog2.SelectedRows[0].Cells["id2"].Value.ToString());
                long pid = long.Parse(dgv_ProduceLog2.SelectedRows[0].Cells["pid2"].Value.ToString());

                producePlan.PrintRecordRecordGBitumen(id, pid);
            }
        }

        private void btnPrint3_Click(object sender, EventArgs e)
        {
            producePlan.PrintBitumenWarm(DateTime.Parse(dtp_start3.Value.ToShortDateString()), DateTime.Parse(dtp_end3.Value.AddDays(1).ToShortDateString()));
        }

    }
}
