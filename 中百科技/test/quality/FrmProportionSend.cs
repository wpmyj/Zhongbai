using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.system;
using DasherStation.common;

namespace DasherStation.quality
{
    public partial class FrmProportionSend :common.BaseForm
    {

        QualityLogic qualityLogic = new QualityLogic();

        ProductLogic pLogic = new ProductLogic();

        public ProportionSendClass PSClass = new ProportionSendClass();

        int PId;//配合比编号
        int TpId;//目标配合比编号
        int PpId;//生产配合比编号


        public FrmProportionSend()
        {
            InitializeComponent();
        }

        private void FrmProportionSend_Load(object sender, EventArgs e)
        {
            int verifyBit;

            try
            {
                verifyBit = qualityLogic.FrmProportionSendSearchRG(PSClass.Id);//确定是乳化沥青还是改性沥青

                if (Convert.ToInt32(this.Tag) == 0)
                {
                    InitialCombobox();
                }
                else //把查询出来的内容显示出来
                {
                    DisPlayInfo(verifyBit);
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

        public void DisPlayInfo(int verifyBit)
        {
            try
            {
                if (verifyBit == 0) //改性
                {
                    tabControl1.SelectedIndex = 2;
                    PId = qualityLogic.FrmProportionSendSearchGPId(PSClass.Id);

                    cbxGsort.Text = PSClass.Sort;
                    cbxGName.Text = PSClass.Name;
                    cbxGModel.Text = PSClass.Model;
                    cbxGEiId.Text = PSClass.EiId.ToString();
                    cbxGInputMan.Text = PSClass.InputMan;
                    dtpGDate.Value = PSClass.InputDate;
                    txtGRemark.Text = PSClass.Remark;
                    cbxGTId.Text = Convert.ToString(PId);
                    dgvG.DataSource = (qualityLogic.FrmProportionSendSearchPG(cbxGTId.Text.ToString().Trim())).Tables[0];

                    DisableCtrls();

                    btn_PrintG.Enabled = true;

                }
                else if (verifyBit == 1)//乳化
                {
                    tabControl1.SelectedIndex = 1;
                    PId = qualityLogic.FrmProportionSendSearchPId(PSClass.Id);

                    cbxRsort.Text = PSClass.Sort;
                    cbxRName.Text = PSClass.Name;
                    cbxRModel.Text = PSClass.Model;
                    cbxREiId.Text = PSClass.EiId.ToString();
                    cbxRInputMan.Text = PSClass.InputMan;
                    dtpRDate.Value = PSClass.InputDate;
                    txtRRemark.Text = PSClass.Remark;
                    cbxRTId.Text = Convert.ToString(PId);
                    dgvR.DataSource = (qualityLogic.FrmProportionSendSearchPG(cbxRTId.Text.ToString().Trim())).Tables[0];
                    DisableCtrls();
                    btn_PrintR.Enabled = true;
                }
                else //拌合料
                {
                    tabControl1.SelectedIndex = 0;
                    TpId = qualityLogic.FrmProportionSendSearchTpId(PSClass.Id);
                    PpId = qualityLogic.FrmProportionSendSearchPpId(PSClass.Id);

                    cbxPsort.Text = PSClass.Sort;
                    cbxPName.Text = PSClass.Name;
                    cbxPModel.Text = PSClass.Model;
                    cbxEiId.Text = PSClass.EiId.ToString();
                    cbxInputMan.Text = PSClass.InputMan;
                    dtpDate.Value = PSClass.InputDate;
                    txtRemark.Text = PSClass.Remark;
                    cbxTId.Text = Convert.ToString(TpId);
                    cbxPId.Text = Convert.ToString(PpId);
                    dgvDetail.DataSource = (qualityLogic.FrmProportionSendSearchTP(cbxTId.Text.Trim())).Tables[0];
                    qualityLogic.proportionBind(this.panelTable, cbxPId.Text.Trim());
                    DisableCtrls();
                    btn_PrintMix.Enabled = true;
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

        public void DisableCtrls()
        {
            try
            {
                cbxRsort.Enabled = false;
                cbxRName.Enabled = false;
                cbxRModel.Enabled = false;
                cbxREiId.Enabled = false;
                cbxRInputMan.Enabled = false;
                dtpRDate.Enabled = false;
                txtRRemark.Enabled = false;
                cbxRTId.Enabled = false;
                btnRSave.Enabled = false;

                cbxGsort.Enabled = false;
                cbxGName.Enabled = false;
                cbxGModel.Enabled = false;
                cbxGEiId.Enabled = false;
                cbxGInputMan.Enabled = false;
                dtpGDate.Enabled = false;
                txtGRemark.Enabled = false;
                cbxGTId.Enabled = false;
                btnGSave.Enabled = false;

                cbxPsort.Enabled = false;
                cbxPName.Enabled = false;
                cbxPModel.Enabled = false;
                cbxEiId.Enabled = false;
                cbxInputMan.Enabled = false;
                dtpDate.Enabled = false;
                txtRemark.Enabled = false;
                cbxTId.Enabled = false;
                cbxPId.Enabled = false;
                btnSend.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        public void InitialCombobox()
        {
            try
            {
                qualityLogic.InitialcbxPsort(cbxPsort);
                cbxPsort.DisplayMember = "sort";
                cbxPsort.ValueMember = "id";
                cbxPsort.SelectedIndex = -1;

                qualityLogic.InitialcbxPsort(cbxRsort);
                cbxRsort.DisplayMember = "sort";
                cbxRsort.ValueMember = "id";
                cbxRsort.SelectedIndex = -1;

                qualityLogic.InitialcbxPsort(cbxGsort);
                cbxGsort.DisplayMember = "sort";
                cbxGsort.ValueMember = "id";
                cbxGsort.SelectedIndex = -1;

                qualityLogic.InitialCbxEiId(cbxEiId);
                cbxEiId.DisplayMember = "no";
                cbxEiId.ValueMember = "id";
                cbxEiId.SelectedIndex = -1;

                qualityLogic.InitialcbxTId(cbxTId);
                cbxTId.DisplayMember = "id";
                cbxTId.ValueMember = "id";
                cbxTId.SelectedIndex = -1;

                qualityLogic.InitialcbxPId(cbxPId);
                cbxPId.DisplayMember = "id";
                cbxPId.ValueMember = "id";
                cbxPId.SelectedIndex = -1;

                qualityLogic.InitialcbxInputMan(cbxInputMan);
                cbxInputMan.DisplayMember = "inputMan";
                cbxInputMan.ValueMember = "inputMan";
                cbxInputMan.SelectedIndex = -1;

                qualityLogic.InitialCbxEiId(cbxREiId);
                cbxREiId.DisplayMember = "no";
                cbxREiId.ValueMember = "id";
                cbxREiId.SelectedIndex = -1;

                qualityLogic.InitialcbxInputMan(cbxRInputMan);
                cbxRInputMan.DisplayMember = "inputMan";
                cbxRInputMan.ValueMember = "inputMan";
                cbxRInputMan.SelectedIndex = -1;

                qualityLogic.InitialcbxRTId(cbxRTId);
                cbxRTId.DisplayMember = "id";
                cbxRTId.ValueMember = "id";
                cbxRTId.SelectedIndex = -1;

                qualityLogic.InitialCbxEiId(cbxGEiId);
                cbxGEiId.DisplayMember = "no";
                cbxGEiId.ValueMember = "id";
                cbxGEiId.SelectedIndex = -1;

                qualityLogic.InitialcbxInputMan(cbxGInputMan);
                cbxGInputMan.DisplayMember = "inputMan";
                cbxGInputMan.ValueMember = "inputMan";
                cbxGInputMan.SelectedIndex = -1;

                qualityLogic.InitialcbxGTId(cbxGTId);
                cbxGTId.DisplayMember = "id";
                cbxGTId.ValueMember = "id";
                cbxGTId.SelectedIndex = -1;
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
            int pkId;
            try
            {
                #region
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

        private void cbxRsort_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pkId;
            try
            {
                #region
                //if (cbxRsort.SelectedValue == null)
                //{
                //    pkId = 0;
                //    return;
                //}
                //pkId = Convert.ToInt32(cbxRsort.SelectedValue.ToString());

                //cbxRName.DataSource = pLogic.InitialPNameComboBox(pkId);
                //cbxRName.DisplayMember = "产品名称";
                //cbxRName.ValueMember = "id";
                //cbxRName.SelectedIndex = -1;

                //if (cbxRName.SelectedValue == null)
                //{
                //    pnId = 0;
                //    return;
                //}
                //pnId = Convert.ToInt32(cbxRName.SelectedValue.ToString());

                //cbxRModel.DataSource = pLogic.InitialPModelComboBox(pnId);
                //cbxRModel.DisplayMember = "产品规格";
                //cbxRModel.ValueMember = "id";
                //cbxRModel.SelectedIndex = -1;
                #endregion

                if (cbxRsort.SelectedValue == null)
                {
                    pkId = 0;
                }
                else
                {
                    pkId = Convert.ToInt32(cbxRsort.SelectedValue.ToString());
                }
                if (pLogic.InitialPNameComboBox(pkId).Rows.Count != 0)
                {
                    cbxRName.DataSource = pLogic.InitialPNameComboBox(pkId);
                    cbxRName.DisplayMember = "产品名称";
                    cbxRName.ValueMember = "id";
                    cbxRName.Text = "";
                    cbxRName.SelectedIndex = -1;
                }
                else
                {
                    cbxRName.DataSource = pLogic.InitialPNameComboBox(pkId);
                }
                cbxRModel.Text = "";
                cbxRModel.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void cbxGsort_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pkId;
            try
            {
                #region
                //if (cbxGsort.SelectedValue == null)
                //{
                //    pkId = 0;
                //    return;
                //}
                //pkId = Convert.ToInt32(cbxGsort.SelectedValue.ToString());

                //cbxGName.DataSource = pLogic.InitialPNameComboBox(pkId);
                //cbxGName.DisplayMember = "产品名称";
                //cbxGName.ValueMember = "id";
                //cbxGName.SelectedIndex = -1;

                //if (cbxGName.SelectedValue == null)
                //{
                //    pnId = 0;
                //    return;
                //}
                //pnId = Convert.ToInt32(cbxGName.SelectedValue.ToString());

                //cbxGModel.DataSource = pLogic.InitialPModelComboBox(pnId);
                //cbxGModel.DisplayMember = "产品规格";
                //cbxGModel.ValueMember = "id";
                //cbxGModel.SelectedIndex = -1;
                #endregion
                if (cbxGsort.SelectedValue == null)
                {
                    pkId = 0;
                }
                else
                {
                    pkId = Convert.ToInt32(cbxGsort.SelectedValue.ToString());
                }
                if (pLogic.InitialPNameComboBox(pkId).Rows.Count != 0)
                {
                    cbxGName.DataSource = pLogic.InitialPNameComboBox(pkId);
                    cbxGName.DisplayMember = "产品名称";
                    cbxGName.ValueMember = "id";
                    cbxGName.Text = "";
                    cbxGName.SelectedIndex = -1;
                }
                else
                {
                    cbxGName.DataSource = pLogic.InitialPNameComboBox(pkId);
                }
                cbxGModel.Text = "";
                cbxGModel.SelectedIndex = -1;
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

        private void cbxRName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pnId;
            try
            {
                #region
                //if (cbxRName.SelectedValue == null)
                //{
                //    pnId = 0;
                //    return;
                //}
                //pnId = Convert.ToInt32(cbxRName.SelectedValue.ToString());

                //if (pLogic.InitialPModelComboBox(pnId).Rows.Count != 0)
                //{
                //    cbxRModel.DataSource = pLogic.InitialPModelComboBox(pnId);
                //    cbxRModel.DisplayMember = "产品规格";
                //    cbxRModel.ValueMember = "id";
                //    cbxRModel.SelectedIndex = -1;
                //}
                #endregion
                if (cbxRName.SelectedValue == null)
                {
                    pnId = 0;
                }
                else
                {
                    pnId = Convert.ToInt32(cbxRName.SelectedValue.ToString());
                }
                if (pLogic.InitialPModelComboBox(pnId).Rows.Count != 0)
                {
                    cbxRModel.DataSource = pLogic.InitialPModelComboBox(pnId);
                    cbxRModel.DisplayMember = "产品规格";
                    cbxRModel.ValueMember = "id";
                    cbxRModel.Text = "";
                    cbxRModel.SelectedIndex = -1;
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

        private void cbxGName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pnId;
            try
            {
                #region
                //if (cbxGName.SelectedValue == null)
                //{
                //    pnId = 0;
                //    return;
                //}
                //pnId = Convert.ToInt32(cbxGName.SelectedValue.ToString());

                //if (pLogic.InitialPModelComboBox(pnId).Rows.Count != 0)
                //{
                //    cbxGModel.DataSource = pLogic.InitialPModelComboBox(pnId);
                //    cbxGModel.DisplayMember = "产品规格";
                //    cbxGModel.ValueMember = "id";
                //    cbxGModel.SelectedIndex = -1;
                //}
                #endregion
                if (cbxGName.SelectedValue == null)
                {
                    pnId = 0;
                }
                else
                {
                    pnId = Convert.ToInt32(cbxGName.SelectedValue.ToString());
                }
                if (pLogic.InitialPModelComboBox(pnId).Rows.Count != 0)
                {
                    cbxGModel.DataSource = pLogic.InitialPModelComboBox(pnId);
                    cbxGModel.DisplayMember = "产品规格";
                    cbxGModel.ValueMember = "id";
                    cbxGModel.Text = "";
                    cbxGModel.SelectedIndex = -1;
                }
                else
                {
                    cbxGModel.DataSource = pLogic.InitialPModelComboBox(pnId);
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

        private void cbxTId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cbxTId.SelectedIndex != -1)
                {
                    dgvDetail.DataSource = (qualityLogic.FrmProportionSendSearchTP(cbxTId.SelectedValue.ToString().Trim())).Tables[0];
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

        private void cbxPId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cbxPId.SelectedIndex != -1)
                {
                    string ppid = cbxPId.SelectedValue.ToString().Trim();
                    qualityLogic.proportionBind(this.panelTable, ppid);
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            bool status;
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

                //通知人输入不能为空
                if (!Check.CheckEmpty(cbxInputMan.Text.Trim()))
                {
                    MessageBox.Show("通知人不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxInputMan.Focus();
                    return;
                }
                //检查通知人是否含有非法字符
                else if (!Check.CheckQuery(cbxInputMan.Text.Trim()))
                {
                    MessageBox.Show("通知人包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxInputMan.Text = "";
                    cbxInputMan.Focus();
                    return;
                }

                //设备编号输入不能为空
                if (!Check.CheckEmpty(cbxEiId.Text.Trim()))
                {
                    MessageBox.Show("设备编号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxEiId.Focus();
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

                status = qualityLogic.FrmProportionSendSend(cbxInputMan.Text.Trim(), txtRemark.Text,
                         cbxEiId.SelectedValue.ToString(), cbxTId.Text, cbxPId.Text);

                if (status)
                {
                    MessageBox.Show("发送成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("发送失败，请重新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearCtrls();

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
            try
            {
                cbxPsort.SelectedIndex = -1;
                cbxPName.SelectedIndex = -1;
                cbxPModel.SelectedIndex = -1;
                cbxEiId.SelectedIndex = -1;
                cbxInputMan.SelectedIndex = -1;
                txtRemark.Clear();
                cbxTId.SelectedIndex = -1;
                cbxPId.SelectedIndex = -1;
                dgvDetail.DataSource = null;

                cbxRsort.SelectedIndex = -1;
                cbxRName.SelectedIndex = -1;
                cbxRModel.SelectedIndex = -1;
                cbxREiId.SelectedIndex = -1;
                cbxRInputMan.SelectedIndex = -1;
                cbxRTId.SelectedIndex = -1;
                txtRRemark.Clear();
                dgvR.DataSource = null;

                cbxGsort.SelectedIndex = -1;
                cbxGName.SelectedIndex = -1;
                cbxGModel.SelectedIndex = -1;
                cbxGEiId.SelectedIndex = -1;
                cbxGInputMan.SelectedIndex = -1;
                cbxGTId.SelectedIndex = -1;
                txtGRemark.Clear();
                dgvG.DataSource = null;


                foreach (object obj in panelTable.Controls)
                {
                    if (obj.GetType() == typeof(TextBox))
                    {
                        ((TextBox)obj).Clear();
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

        private void cbxRTId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cbxRTId.SelectedIndex != -1)
                {
                    dgvR.DataSource = (qualityLogic.FrmProportionSendSearchP(cbxRTId.SelectedValue.ToString().Trim())).Tables[0];
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

        private void btnRSave_Click(object sender, EventArgs e)
        {
            bool status;
            try
            {
                //产品种类输入不能为空
                if (!Check.CheckEmpty(cbxRsort.Text.Trim()))
                {
                    MessageBox.Show("产品种类不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxRsort.Focus();
                    return;
                }
                //产品名称输入不能为空
                if (!Check.CheckEmpty(cbxRName.Text.Trim()))
                {
                    MessageBox.Show("产品名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxRName.Focus();
                    return;
                }
                //产品型号输入不能为空
                if (!Check.CheckEmpty(cbxRModel.Text.Trim()))
                {
                    MessageBox.Show("产品型号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxRModel.Focus();
                    return;
                }

                //通知人输入不能为空
                if (!Check.CheckEmpty(cbxRInputMan.Text.Trim()))
                {
                    MessageBox.Show("通知人不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxRInputMan.Focus();
                    return;
                }
                //检查通知人是否含有非法字符
                else if (!Check.CheckQuery(cbxRInputMan.Text.Trim()))
                {
                    MessageBox.Show("通知人包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxRInputMan.Text = "";
                    cbxRInputMan.Focus();
                    return;
                }

                //设备编号输入不能为空
                if (!Check.CheckEmpty(cbxREiId.Text.Trim()))
                {
                    MessageBox.Show("设备编号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxREiId.Focus();
                    return;
                }
                //检查备注是否含有非法字符
                if (!Check.CheckQuery(txtRRemark.Text.Trim()))
                {
                    MessageBox.Show("备注包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRRemark.Clear();
                    txtRRemark.Focus();
                    return;
                }

                status = qualityLogic.FrmProportionRSendSend(cbxRInputMan.Text.Trim(), txtRRemark.Text,
                         cbxREiId.SelectedValue.ToString(), cbxRTId.Text);

                if (status)
                {
                    MessageBox.Show("发送成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("发送失败，请重新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearCtrls();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void cbxGTId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cbxGTId.SelectedIndex != -1)
                {
                    dgvG.DataSource = (qualityLogic.FrmProportionSendSearchPG(cbxGTId.SelectedValue.ToString().Trim())).Tables[0];
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

        private void btnGSave_Click(object sender, EventArgs e)
        {
            bool status;
            try
            {
                //产品种类输入不能为空
                if (!Check.CheckEmpty(cbxGsort.Text.Trim()))
                {
                    MessageBox.Show("产品种类不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxGsort.Focus();
                    return;
                }
                //产品名称输入不能为空
                if (!Check.CheckEmpty(cbxGName.Text.Trim()))
                {
                    MessageBox.Show("产品名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxGName.Focus();
                    return;
                }
                //产品型号输入不能为空
                if (!Check.CheckEmpty(cbxGModel.Text.Trim()))
                {
                    MessageBox.Show("产品型号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxGModel.Focus();
                    return;
                }

                //通知人输入不能为空
                if (!Check.CheckEmpty(cbxGInputMan.Text.Trim()))
                {
                    MessageBox.Show("通知人不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxGInputMan.Focus();
                    return;
                }
                //检查通知人是否含有非法字符
                else if (!Check.CheckQuery(cbxGInputMan.Text.Trim()))
                {
                    MessageBox.Show("通知人包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxGInputMan.Text = "";
                    cbxGInputMan.Focus();
                    return;
                }

                //设备编号输入不能为空
                if (!Check.CheckEmpty(cbxGEiId.Text.Trim()))
                {
                    MessageBox.Show("设备编号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxGEiId.Focus();
                    return;
                }
                //检查备注是否含有非法字符
                if (!Check.CheckQuery(txtGRemark.Text.Trim()))
                {
                    MessageBox.Show("备注包含非法字符，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGRemark.Clear();
                    txtGRemark.Focus();
                    return;
                }

                status = qualityLogic.FrmProportionGSendSend(cbxGInputMan.Text.Trim(), txtGRemark.Text,
                         cbxGEiId.SelectedValue.ToString(), cbxGTId.Text);

                if (status)
                {
                    MessageBox.Show("发送成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("发送失败，请重新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearCtrls();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void FrmProportionSend_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btn_PrintMix_Click(object sender, EventArgs e)
        {
            if (PSClass.Id != 0)
            {
                long id = long.Parse((PSClass.Id).ToString());

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProportionPSendTableAdapters.sendProportionTableAdapter", "sendProportion", new object[] { id }));
                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProportionPSendTableAdapters.produceProportionTableAdapter", "produceProportion", new object[] { id }));
                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProportionPSendTableAdapters.targetProportionTableAdapter", "targetProportion", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.ProportionPSend";
                reportData.ReportName = "DasherStation.Report.MixProportionTPSendReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }

        private void btn_PrintR_Click(object sender, EventArgs e)
        {
            if (PSClass.Id != 0)
            {
                long id = long.Parse((PSClass.Id).ToString());

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProportionRSendDataSetTableAdapters.sendProportionTableAdapter", "sendProportion", new object[] { id }));
                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProportionRSendDataSetTableAdapters.proportionDetailTableAdapter", "proportionDetail", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.ProportionRSendDataSet";
                reportData.ReportName = "DasherStation.Report.ProportionRSendReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }

        private void btn_PrintG_Click(object sender, EventArgs e)
        {
            if (PSClass.Id != 0)
            {
                long id = long.Parse((PSClass.Id).ToString());

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProportionGSendDataSetTableAdapters.sendProportionTableAdapter", "sendProportion", new object[] { id }));
                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProportionGSendDataSetTableAdapters.proportionDetailTableAdapter", "proportionDetail", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.ProportionGSendDataSet";
                reportData.ReportName = "DasherStation.Report.ProportionGSendReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }
    }
}
