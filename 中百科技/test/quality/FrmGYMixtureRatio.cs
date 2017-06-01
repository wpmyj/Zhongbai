using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.system;
using DasherStation.stock;
using DasherStation.common;

namespace DasherStation.quality
{
    public partial class FrmGYMixtureRatio : common.BaseForm
    {

        QualityLogic qualityLogic = new QualityLogic();

        ProportionClass PClass = new ProportionClass();

        ProportionDetailClass PDClass = new ProportionDetailClass();

        ProductLogic pLogic = new ProductLogic();

        purchaseScheDetaillogic purchaseSchedetaillogic = new purchaseScheDetaillogic();

        DataSet ds = null;

        private int count;          //记录dataGridView 中有多少行

        public FrmGYMixtureRatio()
        {
            InitializeComponent();
        }

        private void FrmGYMixtureRatio_Load(object sender, EventArgs e)
        {
            try
            {
                qualityLogic.InitialcbxPsort(cbxPsort);
                cbxPsort.DisplayMember = "sort";
                cbxPsort.ValueMember = "id";
                cbxPsort.SelectedIndex = -1;

                qualityLogic.InitialcbxKinds(cbxKinds);
                cbxKinds.DisplayMember = "sort";
                cbxKinds.ValueMember = "id";
                cbxKinds.SelectedIndex = -1;

                qualityLogic.InitialcbxRProducer(cbxProducer);
                cbxProducer.DisplayMember = "producer";
                cbxProducer.SelectedIndex = -1;

                qualityLogic.InitialcbxAddress(cbxAddress);
                cbxAddress.DisplayMember = "address";
                cbxAddress.ValueMember = "id";
                cbxAddress.SelectedIndex = -1;

                qualityLogic.InitialcbxMaker(cbxMaker);
                cbxMaker.DisplayMember = "name";
                cbxMaker.ValueMember = "id";
                cbxMaker.SelectedIndex = -1;

                TableDetaildata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
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
                table.Columns.Add("proportionValue");
                table.Columns.Add("address");
                table.Columns.Add("name1");
                table.Columns.Add("inputDate");
                table.Columns.Add("inputMan");
                table.Columns.Add("producer");
                table.Columns.Add("mId");
                table.Columns.Add("Ppid");

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

        private void cbxPsort_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                #region
                //int pkId, pnId;

                //if (cbxPsort.SelectedValue == null)
                //{
                //    pkId = 0;
                //    return;
                //}
                //pkId = Convert.ToInt32(cbxPsort.SelectedValue.ToString());

                //cbxPName.DataSource = pLogic.InitialPNameComboBox(pkId);
                //cbxPName.DisplayMember = "产品名称";
                //cbxPName.ValueMember = "id";
                //cbxPName.SelectedIndex = -1;

                //if (cbxPName.SelectedValue == null)
                //{
                //    pnId = 0;
                //    return;
                //}
                //pnId = Convert.ToInt32(cbxPName.SelectedValue.ToString());

                //cbxPModel.DataSource = pLogic.InitialPModelComboBox(pnId);
                //cbxPModel.DisplayMember = "产品规格";
                //cbxPModel.ValueMember = "id";
                //cbxPModel.SelectedIndex = -1;
                #endregion
                int pkId;

                if (cbxPsort.SelectedValue == null)
                {
                    pkId = 0;
                }
                else
                {
                    pkId = Convert.ToInt32(cbxPsort.SelectedValue.ToString());
                }
                if (pLogic.InitialPNameComboBox(pkId).Rows.Count != 0)
                {
                    cbxPName.DataSource = pLogic.InitialPNameComboBox(pkId);
                    cbxPName.DisplayMember = "产品名称";
                    cbxPName.ValueMember = "id";
                    cbxPName.Text = "";
                    cbxPName.SelectedIndex = -1;
                }
                else
                {
                    cbxPName.DataSource = pLogic.InitialPNameComboBox(pkId);
                }
                cbxPModel.Text = "";
                cbxPModel.SelectedIndex = -1;
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

        private void cbxPName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                #region
                //int pnId;

                //if (cbxPName.SelectedValue == null)
                //{
                //    pnId = 0;
                //    return;
                //}
                //pnId = Convert.ToInt32(cbxPName.SelectedValue.ToString());

                //if (pLogic.InitialPModelComboBox(pnId).Rows.Count != 0)
                //{
                //    cbxPModel.DataSource = pLogic.InitialPModelComboBox(pnId);
                //    cbxPModel.DisplayMember = "产品规格";
                //    cbxPModel.ValueMember = "id";
                //    cbxPModel.SelectedIndex = -1;
                //}
                #endregion
                int pnId;
                if (cbxPName.SelectedValue == null)
                {
                    pnId = 0;
                }
                else
                {
                    pnId = Convert.ToInt32(cbxPName.SelectedValue.ToString());
                }
                if (pLogic.InitialPModelComboBox(pnId).Rows.Count != 0)
                {
                    cbxPModel.DataSource = pLogic.InitialPModelComboBox(pnId);
                    cbxPModel.DisplayMember = "产品规格";
                    cbxPModel.ValueMember = "id";
                    cbxPModel.Text = "";
                    cbxPModel.SelectedIndex = -1;
                }
                else
                {
                    cbxPModel.DataSource = pLogic.InitialPModelComboBox(pnId);
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

        private void FrmGYMixtureRatio_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //如果关闭窗口，先检查该条概要信息是否存在详细信息，如果存在，关闭窗体；否则，删除该条概要信息
                if (MessageBox.Show("确定关闭窗口吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    //  status = qualityLogic.FrmMixtureRatioAddSearchDetail(Convert.ToInt32(txtPId.Text)); 
                    //this.Close();
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
            txtRatio.Clear();
            cbxMaker.Text = "";
            cbxAddress.Text = "";
        }

        private ProportionClass SetPara()
        {
            #region
            ProportionClass PClass = new ProportionClass();
            try
            {
                PClass.PId = qualityLogic.FrmGYMixtureRatioSearchPId(Convert.ToInt32(cbxPName.SelectedValue.ToString()),
                                                                        Convert.ToInt32(cbxPModel.SelectedValue.ToString()));
                if (this.Text == "乳化沥青配合比")
                {
                    PClass.Mark2 = 1;
                }
                else
                {
                    PClass.Mark2 = 0;
                }
                PClass.Producer = cbxProducer.Text;
                PClass.Remark = txtRemark.Text;
                PClass.InputDate = DateTime.Now;
                PClass.InputMan = this.userName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return PClass;
            #endregion

        }

        public void SetParaDetail()
        {
            try
            {
                PDClass.MId = qualityLogic.FrmMixtureRatioAddSearchMaterialId(Convert.ToInt32(cbxName.SelectedValue.ToString()),
                                                                             Convert.ToInt32(cbxModel.SelectedValue.ToString()));
                PDClass.ProportionValue = Convert.ToDouble(txtRatio.Text.Trim());
                PDClass.Producer = cbxProducer.Text;
                PDClass.InputDate = DateTime.Now;
                PDClass.InputMan = this.userName;
                PDClass.Address = cbxAddress.Text.Trim();
                PDClass.Name = cbxMaker.Text.Trim();
                PDClass.PpId = int.Parse(cbxMaker.SelectedValue.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }


        }

        //获得目标配合比多条明细表的信息
        private List<ProportionDetailClass> GetTPDetail()
        {
            ProportionDetailClass PDClass = null;

            List<ProportionDetailClass> list = new List<ProportionDetailClass>();
            try
            {
                

                foreach (DataGridViewRow dgvr in dgvDetail.Rows)
                {
                    PDClass = new ProportionDetailClass();

                    PDClass.MId = int.Parse(dgvr.Cells["mId"].Value.ToString().Trim());
                    PDClass.ProportionValue = Convert.ToDouble(dgvr.Cells["proportionValue"].Value.ToString());
                    PDClass.Producer = dgvr.Cells["producer"].Value.ToString();
                    PDClass.InputDate = Convert.ToDateTime(dgvr.Cells["inputDate"].Value.ToString());
                    PDClass.InputMan = dgvr.Cells["inputMan"].Value.ToString();
                    PDClass.Address = dgvr.Cells["address"].Value.ToString();
                    PDClass.Name = dgvr.Cells["name1"].Value.ToString();
                    //PDClass.PpId = int.Parse(cbxMaker.SelectedValue.ToString());
                    PDClass.PpId = int.Parse(dgvr.Cells["Ppid"].Value.ToString()); 

                    list.Add(PDClass);
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

        //批量保存配合比的方法
        private void SaveAll()
        {
            try
            {
                int id;

                List<ProportionDetailClass> list = GetTPDetail();

                ProportionClass PClass = SetPara();

                id = Convert.ToInt32(qualityLogic.SaveProportionAdd(PClass, list).ToString());

                if (id != 0)
                {
                    txtPId.Text = id.ToString();
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

        private void btnSaveMain_Click(object sender, EventArgs e)
        {
            try
            {
                //产品种类输入不能为空
                if (!Check.CheckEmpty(cbxPsort.Text.Trim()))
                {
                    MessageBox.Show("产品种类不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxPsort.Focus();
                    return;
                }
                //产品名称输入不能为空
                if (!Check.CheckEmpty(cbxPName.Text.Trim()))
                {
                    MessageBox.Show("产品名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxPName.Focus();
                    return;
                }
                //产品型号输入不能为空
                if (!Check.CheckEmpty(cbxPModel.Text.Trim()))
                {
                    MessageBox.Show("产品型号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxPModel.Focus();
                    return;
                }
                //制定人输入不能为空
                if (!Check.CheckEmpty(cbxProducer.Text.Trim()))
                {
                    MessageBox.Show("制定人不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxProducer.Focus();
                    return;
                }
                //检查制定人是否含有非法字符
                else if (!Check.CheckQuery(cbxProducer.Text.Trim()))
                {
                    MessageBox.Show("制定人包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxProducer.Text = "";
                    cbxProducer.Focus();
                    return;
                }
                //检查备注是否含有非法字符
                if (!Check.CheckQuery(txtRemark.Text.Trim()))
                {
                    MessageBox.Show("备注包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRemark.Clear();
                    txtRemark.Focus();
                    return;
                }
                count = dgvDetail.RowCount;
                //     SetPara();
                if (count != 0)
                {
                    SaveAll();
                    for (int i = 0; i < count; i++)
                    {
                        this.dgvDetail.Rows.Remove(dgvDetail.Rows[0]);
                    }

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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Check.CheckEmpty(txtRatio.Text.Trim()))
                {
                    MessageBox.Show("原料比例不能为空！");
                    txtRatio.Focus();
                    return;
                }
                //检查原料比例是否为正符点数
                else if (!Check.CheckFloat(txtRatio.Text.Trim()))
                {
                    MessageBox.Show("原料比例只能是数字，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRatio.Clear();
                    txtRatio.Focus();
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
                if (!Check.CheckEmpty(cbxAddress.Text.Trim()))
                {
                    MessageBox.Show("材料产地不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxAddress.Focus();
                    return;
                }
                if (!Check.CheckEmpty(cbxMaker.Text.Trim()))
                {
                    MessageBox.Show("生产厂家不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxMaker.Focus();
                    return;
                }
                SetParaDetail();

                qualityLogic.FrmGYMRatioAddNew(PDClass, ds.Tables[0], cbxKinds.Text, cbxName.Text,
                                                   cbxModel.Text);

                dgvDetail.Rows[0].Selected = false;

                ClearCtrls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
        }
    }
}
