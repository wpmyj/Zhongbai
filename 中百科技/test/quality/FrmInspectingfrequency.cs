/*
      * 版权单位：沈阳中百科技有限公司
      *
      * 文件名：frmInspectingfrequency.cs
      * 文件功能描述：检验项目管理界面
      *
      * 创建人：夏阳明
      * 创建时间：2009-03-06
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
using DasherStation.system;
using DasherStation.stock;
using DasherStation.common;
using DasherStation.transport;


namespace DasherStation.quality
{
    public partial class FrmInspectingfrequency : common.BaseForm
    {

        QualityLogic qualityLogic = new QualityLogic();

        FrmInspectingfrequencyUpdate IFU = new FrmInspectingfrequencyUpdate();

        DasherStation.transport.TransportLogic transportLogic = new DasherStation.transport.TransportLogic();

        DoCombox doCombox;

        ProductLogic pLogic = new ProductLogic();

        purchaseScheDetaillogic purchaseSchedetaillogic = new purchaseScheDetaillogic();

        MaterialTestGuidelineClass MTGClass = new MaterialTestGuidelineClass();

        DataSet ds = null;

        private int count;          //记录dataGridView 中有多少行
        
        
        public FrmInspectingfrequency()
        {
            InitializeComponent();
        }

        private void frmInspectingfrequency_Load(object sender, EventArgs e)
        {
            try
            {
                //qualityLogic.InitialcbxKinds(cbxKinds);
                //cbxKinds.DisplayMember = "sort";
                //cbxKinds.ValueMember = "id";
                //cbxKinds.SelectedIndex = -1;

                qualityLogic.InitialcbxTestGuideline(cbxTestGuideline);
                cbxTestGuideline.DisplayMember = "testGuideline";
                cbxTestGuideline.SelectedIndex = -1;

                qualityLogic.InitialcbxFrequency(cbxFrequency);
                cbxFrequency.DisplayMember = "frequency";
                cbxFrequency.SelectedIndex = -1;

                qualityLogic.InitialcbxGuideline(cbxGuideline);
                cbxGuideline.DisplayMember = "eligibilityGuideline";
                cbxGuideline.SelectedIndex = -1;

                doCombox = new DoCombox(cbxKinds, cbxName, cbxModel, transportLogic.getType(rbttype1, rbttype2));
                rbttype1.CheckedChanged += rbttype_CheckedChanged;
                rbttype2.CheckedChanged += rbttype_CheckedChanged;

                TableDetaildata();
                if (rbttype1.Checked)
                {
                    dgvDetail.DataSource = (qualityLogic.SearchAll("", 0, 0)).Tables[0];
                }
                else
                {
                    dgvDetail.DataSource = (qualityLogic.SearchAll("", 0, 1)).Tables[0];
                }
                //dgvDetail.DataSource = (qualityLogic.SearchAll("", 0)).Tables[0];
                dgvDetail.Rows[0].Selected = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
        private void rbttype_CheckedChanged(object sender, EventArgs e)
        {
            doCombox = new DoCombox(cbxKinds, cbxName, cbxModel, transportLogic.getType(rbttype1, rbttype2));
        }

        private void TableDetaildata()
        {
            try
            {
                DataTable table = new DataTable();
                ds = new DataSet();

                table.Columns.Add("id");
                table.Columns.Add("sort");
                table.Columns.Add("name");
                table.Columns.Add("model");
                table.Columns.Add("testGuideline");
                table.Columns.Add("frequency");
                table.Columns.Add("eligibilityGuideline");
                table.Columns.Add("inputDate");
                table.Columns.Add("inputMan");
                table.Columns.Add("remark");
                table.Columns.Add("mId");

                ds.Tables.Add(table);

                dgvDetail.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }

        private void cbxKinds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            #region//种类是否被选中决定名称和规格
            try
            {
                int pkid, pnid;
                if (cbxKinds.SelectedValue == null)
                {
                    pkid = 0;
                    cbxName.SelectedIndex = -1;
                    return;
                }
                pkid = Convert.ToInt32(cbxKinds.SelectedValue.ToString());
                cbxName.DataSource = purchaseSchedetaillogic.materialNamelogic(pkid);
                cbxName.DisplayMember = "name";
                cbxName.ValueMember = "id";
                cbxName.Text = "";
                cbxName.SelectedIndex = -1;
                if (cbxName.SelectedValue == null)
                {
                    pnid = 0;
                    cbxModel.Text = "";
                    cbxModel.SelectedIndex = -1;
                    return;
                }
                pnid = Convert.ToInt32(cbxName.SelectedValue.ToString());
                cbxModel.DataSource = purchaseSchedetaillogic.materialModellogic(pnid);
                cbxModel.DisplayMember = "model";
                cbxModel.ValueMember = "id";
                cbxModel.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

            #endregion 
        }

        private void cbxName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            #region//名称是否被选中决定规格的值
            try
            {
                int pnid;
                if (cbxName.SelectedValue == null)
                {
                    pnid = 0;
                    cbxModel.SelectedIndex = -1;
                    return;
                }
                pnid = Convert.ToInt32(cbxName.SelectedValue.ToString());
                cbxModel.DataSource = purchaseSchedetaillogic.materialModellogic(pnid);
                cbxModel.DisplayMember = "model";
                cbxModel.ValueMember = "id";
                cbxModel.Text = "";
                cbxModel.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

            #endregion
        }

        //获得目标配合比多条明细表的信息
        private List<MaterialTestGuidelineClass> GetTPDetail()
        {
            MaterialTestGuidelineClass MTGClass = null;
            List<MaterialTestGuidelineClass> list = new List<MaterialTestGuidelineClass>();
            try
            {

                foreach (DataGridViewRow dgvr in dgvDetail.Rows)
                {
                    MTGClass = new MaterialTestGuidelineClass();

                    MTGClass.MId = int.Parse(dgvr.Cells["mId"].Value.ToString());
                    MTGClass.Guideline = dgvr.Cells["guideline"].Value.ToString();
                    MTGClass.TestGuideline = dgvr.Cells["testGuideline"].Value.ToString();
                    MTGClass.Frequency = dgvr.Cells["frequency"].Value.ToString();
                    MTGClass.Remark = dgvr.Cells["remark"].Value.ToString();
                    MTGClass.InputDate = Convert.ToDateTime(dgvr.Cells["inputDate"].Value.ToString());
                    MTGClass.InputMan = dgvr.Cells["inputMan"].Value.ToString();

                    list.Add(MTGClass);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return list;

        }

        private void FrmInspectingfrequency_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //如果关闭窗口，先检查该条概要信息是否存在详细信息，如果存在，关闭窗体；否则，删除该条概要信息
                if (MessageBox.Show("确定关闭窗口吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;

                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true; ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        public void ClearCtrls()
        {
            cbxKinds.Text = "";
            cbxName.Text = "";
            cbxModel.Text = "";
            cbxTestGuideline.Text = "";
            cbxFrequency.Text = "";
            cbxGuideline.Text = "";
            txtRemark.Clear();
        }

        public void SetParaDetail(int verifyBit)
        {
            try
            {
                MTGClass.MId = qualityLogic.FrmMixtureRatioAddSearchMaterialProductId(Convert.ToInt32(cbxName.SelectedValue.ToString()),
                                                                               Convert.ToInt32(cbxModel.SelectedValue.ToString()), verifyBit);
                MTGClass.TestGuideline = cbxTestGuideline.Text;
                MTGClass.Frequency = cbxFrequency.Text;
                MTGClass.InputDate = DateTime.Now;
                MTGClass.InputMan = this.userName;
                MTGClass.Remark = txtRemark.Text.Trim();
                MTGClass.Guideline = cbxGuideline.Text;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            #region
            try
            {
                if ((MessageBox.Show("确定删除选择的记录吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)) == DialogResult.OK)
                    foreach (DataGridViewRow dgvr in dgvDetail.SelectedRows)
                    {
                        this.dgvDetail.Rows.Remove(dgvr);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }

            #endregion
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            int verifyBit = 0;
            try
            {
                if (!Check.CheckEmpty(cbxTestGuideline.Text.Trim()))
                {
                    MessageBox.Show("检测指标不能为空！");
                    cbxTestGuideline.Focus();
                    return;
                }
                //检查检测指标是否含有非法字符
                else if (!Check.CheckQueryIsEmpty(cbxTestGuideline.Text.Trim()))
                {
                    MessageBox.Show("检测指标含有非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxTestGuideline.Text = "";
                    cbxTestGuideline.Focus();
                    return;
                }

                if (!Check.CheckEmpty(cbxFrequency.Text.Trim()))
                {
                    MessageBox.Show("检测频率不能为空！");
                    cbxFrequency.Focus();
                    return;
                }
                //检查检测频率是否含有非法字符
                else if (!Check.CheckQueryIsEmpty(cbxFrequency.Text.Trim()))
                {
                    MessageBox.Show("检测频率含有非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxFrequency.Text = "";
                    cbxFrequency.Focus();
                    return;
                }

                if (!Check.CheckEmpty(cbxGuideline.Text.Trim()))
                {
                    MessageBox.Show("合格标准不能为空！");
                    cbxGuideline.Focus();
                    return;
                }
                //检查合格标准是否含有非法字符
                else if (!Check.CheckQueryIsEmpty(cbxGuideline.Text.Trim()))
                {
                    MessageBox.Show("合格标准含有非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxGuideline.Text = "";
                    cbxGuideline.Focus();
                    return;
                }

                //材料种类输入不能为空
                if (!Check.CheckEmpty(cbxKinds.Text.Trim()))
                {
                    MessageBox.Show("材料种类不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxKinds.Focus();
                    return;
                }
                //材料名称输入不能为空
                if (!Check.CheckEmpty(cbxName.Text.Trim()))
                {
                    MessageBox.Show("材料名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxName.Focus();
                    return;
                }
                //材料型号输入不能为空
                if (!Check.CheckEmpty(cbxModel.Text.Trim()))
                {
                    MessageBox.Show("材料型号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxModel.Focus();
                    return;
                }
                if(rbttype1.Checked)
                {
                    verifyBit = 1;
                }
                if(rbttype2.Checked)
                {
                    verifyBit = 2;
                }
                SetParaDetail(verifyBit);

                qualityLogic.FrmInspectingfrequencyAddNew(MTGClass, ds.Tables[0], cbxKinds.Text, cbxName.Text,
                                                   cbxModel.Text);

                dgvDetail.DataSource = ds.Tables[0];

                dgvDetail.Rows[0].Selected = false;

                ClearCtrls();

                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
        }

        //批量保存
        private void SaveAll(int verifyBit)
        {
            bool status;

            try
            {
                List<MaterialTestGuidelineClass> list = GetTPDetail();

                status = qualityLogic.SaveFrmInspectingfrequency(list, verifyBit);

                if (status)
                {
                    // this.DialogResult = DialogResult.OK;
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败，请重新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int verifyBit = 0;
            try
            {
                count = dgvDetail.RowCount;

                if(rbttype1.Checked)
                {
                    verifyBit = 1; //选择原料
                }
                if (rbttype2.Checked)
                {
                    verifyBit = 2; //选择产品
                }

                if (count != 0)
                {
                    SaveAll(verifyBit);
                    for (int i = 0; i < count; i++)
                    {
                        this.dgvDetail.Rows.Remove(dgvDetail.Rows[0]);
                    }

                    //dgvDetail.DataSource = (qualityLogic.SearchAll("", 0)).Tables[0];
                    if (rbttype1.Checked)
                    {
                        dgvDetail.DataSource = (qualityLogic.SearchAll("", 0, 0)).Tables[0];
                        dgvDetail.Columns["mId"].Visible = false;
                    }
                    else
                    {
                        dgvDetail.DataSource = (qualityLogic.SearchAll("", 0, 1)).Tables[0];
                        dgvDetail.Columns["pId"].Visible = false;
                    }
                    dgvDetail.Rows[0].Selected = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    if (MessageBox.Show("还没有输入详细信息，确定退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) ==
                                 DialogResult.OK)
                    {
                        this.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string condition;

            int verifyBit;

            try
            {
                if (txtCondition.Text.Trim().Equals(""))
                {
                    //dgvDetail.DataSource = (qualityLogic.SearchAll("", 0)).Tables[0];
                    if (rbttype1.Checked)
                    {
                        dgvDetail.DataSource = (qualityLogic.SearchAll("", 0, 0)).Tables[0];
                    }
                    else
                    {
                        dgvDetail.DataSource = (qualityLogic.SearchAll("", 0, 1)).Tables[0];
                    }
                }
                else
                {
                    condition = cbxCondition.Text.Trim();

                    switch (condition)
                    {
                        case "种类":
                            verifyBit = 1;
                            break;
                        case "名称":
                            verifyBit = 2;
                            break;
                        case "规格型号":
                            verifyBit = 3;
                            break;
                        default:
                            verifyBit = 0;
                            break;
                    }
                    if (rbttype1.Checked)
                    {
                        dgvDetail.DataSource = (qualityLogic.SearchAll(txtCondition.Text.Trim(), verifyBit,0)).Tables[0];
                    }
                    else
                    {
                        dgvDetail.DataSource = (qualityLogic.SearchAll(txtCondition.Text.Trim(), verifyBit, 1)).Tables[0];
                    }
                    //dgvDetail.DataSource = (qualityLogic.SearchAll(txtCondition.Text.Trim(), verifyBit)).Tables[0];
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }  
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            MaterialTestGuidelineClass MTGDC = new MaterialTestGuidelineClass();

            MTGDC.Id = int.Parse(dgvDetail.SelectedRows[0].Cells["id"].Value.ToString());
            MTGDC.Sort = dgvDetail.SelectedRows[0].Cells[1].Value.ToString();
            MTGDC.Name = dgvDetail.SelectedRows[0].Cells[2].Value.ToString();
            MTGDC.Model = dgvDetail.SelectedRows[0].Cells[3].Value.ToString();
            MTGDC.TestGuideline = dgvDetail.SelectedRows[0].Cells[4].Value.ToString();
            MTGDC.Frequency = dgvDetail.SelectedRows[0].Cells[5].Value.ToString();
            MTGDC.Guideline = dgvDetail.SelectedRows[0].Cells[6].Value.ToString();
            MTGDC.Remark = dgvDetail.SelectedRows[0].Cells[9].Value.ToString();

            if (rbttype1.Checked)
            {
                MTGDC.VerityBit = 0; // 材料
            }
            else
            {
                MTGDC.VerityBit = 1; // 产品
            }

            IFU.MTGDC1 = MTGDC;

            if (IFU.ShowDialog() == DialogResult.OK)
            {
                //dgvDetail.DataSource = (qualityLogic.SearchAll("", 0)).Tables[0];
                if (rbttype1.Checked)
                {
                    dgvDetail.DataSource = (qualityLogic.SearchAll("", 0, 0)).Tables[0];
                }
                else
                {
                    dgvDetail.DataSource = (qualityLogic.SearchAll("", 0, 1)).Tables[0];
                }
                dgvDetail.Rows[0].Selected = false;
            }
            
        }

        private void rbttype1_Click(object sender, EventArgs e)
        {
            dgvDetail.DataSource = (qualityLogic.SearchAll("", 0, 0)).Tables[0];
            dgvDetail.Columns["mId"].Visible = false;
        }

        private void rbttype2_Click(object sender, EventArgs e)
        {
            dgvDetail.DataSource = (qualityLogic.SearchAll("", 0, 1)).Tables[0];
            dgvDetail.Columns["pId"].Visible = false;
        }
    }
}
