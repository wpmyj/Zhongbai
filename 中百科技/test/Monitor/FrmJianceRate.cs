using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.system;

namespace DasherStation.Monitor
{
    public partial class FrmJianceRate : DasherStation.common.BaseForm
    {
        public FrmJianceRate()
        {
            InitializeComponent();
        }

        MonitorLogin monitorL = new MonitorLogin();
        MaterialLogic mLogic = new MaterialLogic();
        ProductLogic pLogic = new ProductLogic();

        #region setTEST()
        private void setTEST()
        {
            if (rbtn_material.Checked)
            {
                cbx_test.DataSource = monitorL.Search_TestGuideline(1);
            }
            if (rbtn_product.Checked)
            {
                cbx_test.DataSource = monitorL.Search_TestGuideline(0);
            }

            cbx_test.DisplayMember = "testGuideline";
            cbx_test.SelectedIndex = -1;
        }
        #endregion

        #region setM_DataGridView()
        private void setM_DataGridView()
        {
            int mnId, mmId, pnId, pmId;
            string begin_data = (dtp_being.Value.Date).ToString("yyyy-MM-dd") + " 00:00:00";
            string end_data = (dtp_end.Value.Date).ToString("yyyy-MM-dd") + " 23:59:59";
            string guide_line = "";
            int mid = 0, pid =0;
            if (!string.IsNullOrEmpty(cbx_test.Text.Trim()))
            {
                guide_line = cbx_test.Text.Trim();
            }
            if (rbtn_material.Checked)
            {
                #region 查出材料ID； 
                {
                    if (!string.IsNullOrEmpty(cbx_name.Text.Trim())) 
                    {
                        mnId = Convert.ToInt32(this.cbx_name.SelectedValue.ToString());
                        if (!string.IsNullOrEmpty(cbx_model.Text.Trim())) 
                        {
                            mmId = Convert.ToInt32(this.cbx_model.SelectedValue.ToString());
                        }
                        else
                        {
                            mmId = 0;
                        }
                    }
                    else
                    {
                        mnId = 0;
                        mmId = 0;
                    }
                    if ((mnId != 0) && (mmId != 0))
                    {
                        mid = mLogic.MaterialSearch(mnId, mmId);
                    }
                }
                #endregion 
                string str_sql = monitorL.Test_where(begin_data, end_data, guide_line, mid, 0);
                dataGridView1.DataSource = monitorL.Search_materialTest(str_sql);
                dataGridView1.Columns["mId"].Visible = false;
            }
            if (rbtn_product.Checked)
            {
                #region 查出产品ID；
                {

                    if (!string.IsNullOrEmpty(cbx_name.Text.Trim())) 
                    {
                        pnId = Convert.ToInt32(this.cbx_name.SelectedValue.ToString());
                        if (!string.IsNullOrEmpty(cbx_model.Text.Trim()))
                        {
                            pmId = Convert.ToInt32(this.cbx_model.SelectedValue.ToString());
                        }
                        else
                        {
                            pmId = 0;
                        }
                    }
                    else
                    {
                        pnId = 0;
                        pmId = 0;
                    }
                    if ((pnId != 0) && (pmId != 0))
                    {
                        pid = pLogic.PSearchID(pnId, pmId);
                    }
                }
                #endregion
                string str_sql = monitorL.Test_where(begin_data, end_data, guide_line, pid, 1);
                dataGridView1.DataSource = monitorL.Search_productTest(str_sql);
                dataGridView1.Columns["pId"].Visible = false;
            }

        }
        #endregion

        #region 为材料种类赋值
        private void setMKind()
        {
            cbx_kind.DataSource = mLogic.InitialMKindComboBox();
            cbx_kind.DisplayMember = "材料种类";
            cbx_kind.ValueMember = "id";
            cbx_kind.Text = "";
            cbx_kind.SelectedIndex = -1;
            
        }
        #endregion

        #region MLinkage() 选择材料种类后,材料名称联动;
        /*
         * 方法名称： MLinkage()
         * 方法功能描述：选择材料名称后，规格联动；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-19
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void MLinkage()
        {
            int mkId;

            if (cbx_kind.Text.Trim().Equals(""))
            {
                mkId = 0;
            }
            else
            {
                mkId = Convert.ToInt32(cbx_kind.SelectedValue.ToString());
            }

            cbx_name.DataSource = mLogic.InitialMNameComboBox(mkId);

            if (mLogic.InitialMNameComboBox(mkId).Rows.Count != 0)
            {
                cbx_name.DisplayMember = "材料名称";
                cbx_name.ValueMember = "id";
                cbx_name.Text = "";
                cbx_name.SelectedIndex = -1;
            }

            cbx_model.Text = "";
            cbx_model.SelectedIndex = -1;
        }
        #endregion

        #region setMmodel()选择材料名称后，规格联动
        /*
         * 方法名称： setMmodel()
         * 方法功能描述：选择材料名称后，规格联动；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-20
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setMmodel()
        {
            int mnId;
            if (cbx_name.SelectedValue == null)
            {
                mnId = 0;
            }
            else
            {
                mnId = Convert.ToInt32(cbx_name.SelectedValue.ToString());
            }

            cbx_model.DataSource = mLogic.InitialMModelComboBox(mnId);

            if (mLogic.InitialMModelComboBox(mnId).Rows.Count != 0)
            {
                cbx_model.DisplayMember = "材料规格";
                cbx_model.ValueMember = "id";
                cbx_model.Text = "";
                cbx_model.SelectedIndex = -1;
            }
        }
        #endregion

        #region 为产品种类赋值
        private void setPKind()
        {
            cbx_kind.DataSource = pLogic.InitialPKindComboBox();
            cbx_kind.DisplayMember = "产品种类";
            cbx_kind.ValueMember = "id";
            cbx_kind.Text = "";
            cbx_kind.SelectedIndex = -1;
        }
        #endregion

        #region PLinkage() 选择产品种类后,产品名称联动;
        /*
         * 方法名称： PLinkage()
         * 方法功能描述：选择材料名称后，规格联动；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-26
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void PLinkage()
        {
            int pkId;

            if (cbx_kind.SelectedValue == null)
            {
                pkId = 0;
            }
            else
            {
                pkId = Convert.ToInt32(cbx_kind.SelectedValue.ToString());
            }

            cbx_name.DataSource = pLogic.InitialPNameComboBox(pkId);

            if (pLogic.InitialPNameComboBox(pkId).Rows.Count != 0)
            {
                cbx_name.DisplayMember = "产品名称";
                cbx_name.ValueMember = "id";
                cbx_name.Text = "";
                cbx_name.SelectedIndex = -1;
            }

            cbx_model.Text = "";
            cbx_model.SelectedIndex = -1;
        }
        #endregion

        #region setPmodel()选择产品名称后，规格联动
        /*
         * 方法名称： setPmodel()
         * 方法功能描述：选择产品名称后，规格联动；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-20
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void setPmodel()
        {
            int pnId;
            if (cbx_name.SelectedValue == null)
            {
                pnId = 0;
            }
            else
            {
                pnId = Convert.ToInt32(cbx_name.SelectedValue.ToString());
            }

            cbx_model.DataSource = pLogic.InitialPModelComboBox(pnId);

            if (pLogic.InitialPModelComboBox(pnId).Rows.Count != 0)
            {
                cbx_model.DisplayMember = "产品规格";
                cbx_model.ValueMember = "id";
                cbx_model.Text = "";
                cbx_model.SelectedIndex = -1;
            }
        }
        #endregion

        private void FrmJianceRate_Load(object sender, EventArgs e)
        {
            setM_DataGridView();
            setTEST();
            setMKind();
        }

        private void rbtn_material_CheckedChanged(object sender, EventArgs e)
        {
            setTEST();
            setMKind();
            if (rbtn_material.Checked)
            {
                label4.Text = "材料种类";
                label5.Text = "材料名称";
                label6.Text = "材料规格";
            }

            cbx_kind.Text = "";
            cbx_kind.SelectedIndex = -1;
            cbx_name.Text = "";
            cbx_name.SelectedIndex = -1;
            cbx_model.Text = "";
            cbx_model.SelectedIndex = -1;
            setM_DataGridView();
        }

        private void rbtn_product_CheckedChanged(object sender, EventArgs e)
        {
            setTEST();
            setPKind();
            if (rbtn_product.Checked)
            {
                label4.Text = "产品种类";
                label5.Text = "产品名称";
                label6.Text = "产品规格";
            }
            cbx_kind.Text = "";
            cbx_kind.SelectedIndex = -1;
            cbx_name.Text = "";
            cbx_name.SelectedIndex = -1;
            cbx_model.Text = "";
            cbx_model.SelectedIndex = -1;
            setM_DataGridView();
        }

        private void cbx_kind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (rbtn_material.Checked)
            {
                MLinkage();
            }
            if (rbtn_product.Checked)
            {
                PLinkage();
            }
        }

        private void cbx_name_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (rbtn_material.Checked)
            {
                setMmodel();
            }
            if (rbtn_product.Checked)
            {
                setPmodel();
            }
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            setM_DataGridView();
            cbx_kind.Text = "";
            cbx_kind.SelectedIndex = -1;
            cbx_name.Text = "";
            cbx_name.SelectedIndex = -1;
            cbx_model.Text = "";
            cbx_model.SelectedIndex = -1;
        }

    }
}
