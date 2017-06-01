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
    public partial class FrmPMixtureRatio : common.BaseForm
    {
        QualityLogic qualityLogic = new QualityLogic();

        ProduceProportionClass PPClass = new ProduceProportionClass();

        ProduceProportionDetailClass PPDClass = null;

        ProductLogic pLogic = new ProductLogic();

        purchaseScheDetaillogic purchaseSchedetaillogic = new purchaseScheDetaillogic();

        DataSet ds = null;

        private int count;          //记录dataGridView 中有多少行

        public FrmPMixtureRatio()
        {
            InitializeComponent();
        }

        private void FrmPMixtureRatio_Load(object sender, EventArgs e)
        {
            try
            {
                qualityLogic.InitialcbxPsort(cbxPsort);
                cbxPsort.DisplayMember = "sort";
                cbxPsort.ValueMember = "id";
                cbxPsort.SelectedIndex = -1;

                qualityLogic.InitialcbxProducerPP(cbxProducer);
                cbxProducer.DisplayMember = "producer";
                cbxProducer.SelectedIndex = -1;
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
            #region
            //int pkId, pnId;
            //try
            //{
            //    if (cbxPsort.SelectedValue == null)
            //    {
            //        pkId = 0;
            //        return;
            //    }
            //    pkId = Convert.ToInt32(cbxPsort.SelectedValue.ToString());

            //    cbxPName.DataSource = pLogic.InitialPNameComboBox(pkId);
            //    cbxPName.DisplayMember = "产品名称";
            //    cbxPName.ValueMember = "id";
            //    cbxPName.SelectedIndex = -1;

            //    if (cbxPName.SelectedValue == null)
            //    {
            //        pnId = 0;
            //        return;
            //    }
            //    pnId = Convert.ToInt32(cbxPName.SelectedValue.ToString());

            //    cbxPModel.DataSource = pLogic.InitialPModelComboBox(pnId);
            //    cbxPModel.DisplayMember = "产品规格";
            //    cbxPModel.ValueMember = "id";
            //    cbxPModel.SelectedIndex = -1;
#endregion
            try
            {
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

        private void cbxPName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pnId;
            try
            {
                #region
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

        private ProduceProportionClass SetPara()
        {
            ProduceProportionClass PPClass = new ProduceProportionClass();
            try
            {
                PPClass.PId = qualityLogic.FrmMixtureRatioAddSearchPId(Convert.ToInt32(cbxPName.SelectedValue.ToString()),
                                                                        Convert.ToInt32(cbxPModel.SelectedValue.ToString()));
                PPClass.Producer = cbxProducer.Text;
                PPClass.Remark = txtRemark.Text;
                PPClass.InputDate = DateTime.Now;
                PPClass.InputMan = this.userName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return PPClass;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id;

            List<ProduceProportionDetailClass> list = new List<ProduceProportionDetailClass>();

            ProduceProportionDetailClass PPDClass = null;
            try
            {
                ProduceProportionClass PPClass = SetPara();

                foreach (object obj in panelTable.Controls)
                {
                    TextBox txtOjb = obj as TextBox;
                    if ( txtOjb != null )
                    {
                        if (txtOjb.Text != "") 
                        {
                            if (Check.CheckFloat((txtOjb.Text)))
                            {
                                PPDClass = new ProduceProportionDetailClass();

                                PPDClass.ProduceProportion = txtOjb.Tag.ToString();
                                PPDClass.ProduceProportionValue = Convert.ToDouble(txtOjb.Text);
                                PPDClass.Producer = cbxProducer.Text;
                                PPDClass.InputDate = DateTime.Now;
                                PPDClass.InputMan = this.userName;

                                list.Add(PPDClass);
                            }
                            else
                            {
                                MessageBox.Show("配合比详细信息只能是数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        
                    }
                }

                if (PPDClass == null)
                {
                    if (MessageBox.Show("还没有输入详细信息，确定退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) ==
                                 DialogResult.OK)
                    {
                        this.Close();
                    }
                    else
                    {
                        return;
                    }
                }
                
                id = Convert.ToInt32(qualityLogic.ProduceProportion(PPClass, list).ToString());

                if (id != 0)
                {
                    txtId.Text = id.ToString();
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (object obj in panelTable.Controls)
                    {
                        if (obj.GetType() == typeof(TextBox))
                        {
                            ((TextBox)obj).Clear();
                        }
                    }
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

        private void FrmPMixtureRatio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void FrmPMixtureRatio_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
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
     
    }
}
