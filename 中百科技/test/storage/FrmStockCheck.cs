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
using DasherStation.transport;

namespace DasherStation.storage
{
    public partial class FrmStockCheck : common.BaseForm
    {
        public FrmStockCheck()
        {
            InitializeComponent();
        }

        StockCheckRLogic stockCLogic = new StockCheckRLogic();
        ProductLogic pLogic = new ProductLogic();
        MaterialLogic mLogic = new MaterialLogic();
        FormHelper formHelper = new FormHelper();

        int mId, pid;

        #region 为dgvCheck赋值
        private void set_dgvCheck()
        {
            if (rbtnPMaterial.Checked)
            {
                dgvCheck.DataSource = stockCLogic.SearchCheckM();
                
                dgvCheck.Columns["mId"].Visible = false;
                
            }
            else
            {
                dgvCheck.DataSource = stockCLogic.SearchCheckP();
                dgvCheck.Columns["pId"].Visible = false;

            }

            if (dgvCheck.Rows.Count != 0)
            {
                dgvCheck.Columns["盘点日期"].DefaultCellStyle.Format = "d";
            }
            dgvCheck.Columns["id"].Visible = false;
            dgvCheck.Columns["库存ID"].Visible = false;
        }
        #endregion

        #region clearAction() 清空文本、下拉列表框内容;
        private void clearAction()
        {
            cbxPKind.Text = "";
            cbxPKind.SelectedIndex = -1;

            cbxPName.Text = "";
            cbxPName.SelectedIndex = -1;

            cbxPModel.Text = "";
            cbxPModel.SelectedIndex = -1;

            txtTheory.Clear();
            txtInventory.Clear();
            txtDiversity.Clear(); 
            txtDCause.Clear();
            txtRetouch.Clear();
        }
        #endregion

        #region 为盘点信息下材料种类赋值
        private void setPMKind()
        {
            cbxPKind.DataSource = stockCLogic.SearchPMKind();
            cbxPKind.DisplayMember = "sort";
            cbxPKind.ValueMember = "id";
            cbxPKind.Text = "";
            cbxPKind.SelectedIndex = -1;
        }
        #endregion

        #region cobBoBoxLinkage() 选择材料种类后,材料名称联动;
        /*
         * 方法名称： cobBoBoxLinkage()
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
            long mkId;

            if (cbxPKind.SelectedValue == null)  
            {
                mkId = 0;
            }
            else
            {
                mkId = Convert.ToInt64(cbxPKind.SelectedValue.ToString());
            }

            cbxPName.DataSource = stockCLogic.SearchPMName(mkId);

            if (stockCLogic.SearchPMName(mkId).Rows.Count != 0)
            {
                cbxPName.DisplayMember = "name";
                cbxPName.ValueMember = "id";
                cbxPName.Text = "";
                cbxPName.SelectedIndex = -1;
            }

            cbxPModel.Text = "";
            cbxPModel.SelectedIndex = -1;
        }
        #endregion

        #region setPMmodel()选择材料名称后，规格联动
        /*
         * 方法名称： setCbxPmodel()
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
        private void setPMmodel()
        {
            long mkId;
            if (cbxPName.SelectedValue == null)
            {
                mkId = 0;
            }
            else
            {
                mkId = Convert.ToInt64(cbxPKind.SelectedValue.ToString());  
            }

            cbxPModel.DataSource = stockCLogic.SearchPMModel(mkId);

            if (stockCLogic.SearchPMModel(mkId).Rows.Count != 0)
            {
                cbxPModel.DisplayMember = "model";
                cbxPModel.ValueMember = "id";
                cbxPModel.Text = "";
                cbxPModel.SelectedIndex = -1;
            }
        }
        #endregion

        #region 为盘点信息下产品种类赋值
        private void setPPKind()
        {
            cbxPKind.DataSource = stockCLogic.SearchPPKind();
            cbxPKind.DisplayMember = "sort";
            cbxPKind.ValueMember = "id";
            cbxPKind.Text = "";
            cbxPKind.SelectedIndex = -1;
        }
        #endregion

        #region PLinkage() 选择产品种类后,产品名称联动;
        /*
         * 方法名称： PLinkage()
         * 方法功能描述：选择产品种类后,产品名称联动；
         *
         * 创建人：冯雪
         * 创建时间：2009-03-20
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        private void PLinkage()
        {
            long pkId;

            if (cbxPKind.SelectedValue == null)
            {
                pkId = 0;
            }
            else
            {
                pkId = Convert.ToInt64(cbxPKind.SelectedValue.ToString());
            }

            cbxPName.DataSource = stockCLogic.SearchPPName(pkId);

            if (stockCLogic.SearchPPName(pkId).Rows.Count !=0)
            {
                cbxPName.DisplayMember = "name";
                cbxPName.ValueMember = "id";
                cbxPName.Text = "";
                cbxPName.SelectedIndex = -1;
            }

            cbxPModel.Text = "";
            cbxPModel.SelectedIndex = -1;
        }
        #endregion

        #region setPPmodel()选择产品名称后，规格联动
        /*
         * 方法名称： setPPmodel()
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
        private void setPPmodel()
        {
            long pkId;
            if (cbxPName.SelectedValue == null)
            {
                pkId = 0;
            }
            else
            {
                pkId = Convert.ToInt64(cbxPKind.SelectedValue.ToString());
            }

            cbxPModel.DataSource = stockCLogic.SearchPPModel(pkId);

            if (stockCLogic.SearchPPModel(pkId).Rows.Count != 0)
            {
                cbxPModel.DisplayMember = "model";
                cbxPModel.ValueMember = "id";
                cbxPModel.Text = "";
                cbxPModel.SelectedIndex = -1;
            }
        }
        #endregion

        private void FrmStockCheck_Load(object sender, EventArgs e)
        {
            // 初始化盘点材料种类信息；
            setPMKind();
            // 初始DataGridView信息；
            set_dgvCheck();
        }

        private void rbtnPProduct_CheckedChanged(object sender, EventArgs e)
        {
            // 如果选择产品，盘点时label显示产品信息；
            if (rbtnPProduct.Checked)
            {
                label1.Text = "产品种类"; 
                label2.Text = "产品名称";
                label3.Text = "产品规格";

                clearAction();
                setPPKind();
                set_dgvCheck();
            }
        }

        private void rbtnPMaterial_CheckedChanged(object sender, EventArgs e)
        {
            // 如果选择材料，盘点时label显示材料信息；
            if (rbtnPMaterial.Checked)
            {
                label1.Text = "材料种类";
                label2.Text = "材料名称";
                label3.Text = "材料规格";

                clearAction();
                setPMKind();
                set_dgvCheck();
            }
        }

        private void cbxPKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 如果选择材料，则材料种类、名称、规格三级联动；
            if (rbtnPMaterial.Checked)
            {
                MLinkage();
            }
            // 如果选择产品、则产品种类、名称、规格三级联动；
            if (rbtnPProduct.Checked)
            {
                PLinkage();
            }
        }

        private void cbxPName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 如果选择材料，则材料种类、名称、规格三级联动；
            if (rbtnPMaterial.Checked)
            {
                setPMmodel();
            }
            // 如果选择产品、则产品种类、名称、规格三级联动；
            if (rbtnPProduct.Checked)
            {
                setPPmodel();
            }
        }

        private void cbxPModel_Leave(object sender, EventArgs e)
        {
            // 如果选择材料，则取材料名称、规格在材料库存表中查询该记录的帐面库存量；
            #region 询该材料的库存量
            if (rbtnPMaterial.Checked)
            {
                int mnid, mmid;
                if (!cbxPName.Text.Trim().Equals(""))
                {
                    mnid = Convert.ToInt32(this.cbxPName.SelectedValue.ToString());
                }
                else
                {
                    mnid = 0;
                }
                if (!cbxPModel.Text.Trim().Equals(""))
                {
                    mmid = Convert.ToInt32(this.cbxPModel.SelectedValue.ToString());
                }
                else
                {
                    mmid = 0;
                }
                if ((mnid != 0) && (mmid != 0))
                {
                    mId = mLogic.MaterialSearch(mnid,mmid);

                    if (stockCLogic.SearchPMQuantity(mId).Rows.Count != 0)
                    {
                        txtTheory.Text = stockCLogic.SearchPMQuantity(mId).Rows[0][1].ToString();
                    }
                }
            }
            #endregion

            // 如果选择产品、则取产品名称、规格在产品库存表中查询该记录的帐面库存量；
            #region 询该产品的库存量
            if (rbtnPProduct.Checked)
            {
                int pnid, pmid;
                if (!cbxPName.Text.Trim().Equals(""))
                {
                    pnid = Convert.ToInt32(this.cbxPName.SelectedValue.ToString());
                }
                else
                {
                    pnid = 0;
                }
                if (!cbxPModel.Text.Trim().Equals(""))
                {
                    pmid = Convert.ToInt32(this.cbxPModel.SelectedValue.ToString());
                }
                else
                {
                    pmid = 0;
                }
                if ((pnid != 0) && (pmid != 0))
                {
                    pid = pLogic.PSearchID(pnid, pmid);

                    if (stockCLogic.SearchPPSuttle(pid).Rows.Count != 0)
                    {
                         txtTheory.Text = stockCLogic.SearchPPSuttle(pid).Rows[0][1].ToString();
                    }  
                }
            }
            #endregion
        }

        private void txtInventory_Leave(object sender, EventArgs e)
        {
            // 根据帐面库存，和输入的盘点库存，计算出差异值；
            if ((!txtTheory.Text.Trim().Equals("")) && (!txtInventory.Text.Trim().Equals("")))
            {
                decimal theory = decimal.Parse(txtTheory.Text.Trim());
                decimal inventory = decimal.Parse(txtInventory.Text.Trim());
                txtDiversity.Text = (theory - inventory).ToString();
            }         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 盘点数量、差异数量；
            CheckStockClass checkstockClass = new CheckStockClass();

            if (formHelper.inputCheck(groupBox1))
            {
                #region 取出盘点数据

                if (!txtInventory.Text.Trim().Equals(""))
                {
                    checkstockClass.CheckStock = decimal.Parse(txtInventory.Text.Trim());
                }
                else
                {
                    checkstockClass.CheckStock = 0;
                }
                if (!txtDiversity.Text.Trim().Equals(""))
                {
                    checkstockClass.Balance = decimal.Parse(txtDiversity.Text.Trim());
                }
                else
                {
                    checkstockClass.Balance = 0;
                }

                checkstockClass.InputMan = this.userName;
                checkstockClass.InputDate = dtpCheck.Value.ToString();

                if (!txtRetouch.Text.Trim().Equals(""))
                {
                    checkstockClass.Retouch = decimal.Parse(txtRetouch.Text.Trim());
                }
                else
                {
                    checkstockClass.Retouch = 0;
                }
                if (!txtDCause.Text.Trim().Equals(""))
                {
                    checkstockClass.Remark = txtDCause.Text.Trim();
                }
                else
                {
                    checkstockClass.Remark = "";
                }
                if (!txtTheory.Text.Trim().Equals(""))
                {
                    checkstockClass.RetouchStock = decimal.Parse(txtTheory.Text.Trim()) + checkstockClass.Retouch;
                }
                else
                {
                    checkstockClass.RetouchStock = 0 + checkstockClass.Retouch;
                }
                #endregion

                if (rbtnPMaterial.Checked)
                {
                    // 生成材料盘点数据
                    checkstockClass.MslId = Convert.ToInt64(stockCLogic.SearchPMQuantity(mId).Rows[0][2].ToString());

                    if (stockCLogic.InsertPMaterial(checkstockClass))
                    {
                        MessageBox.Show("保存记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearAction();
                        set_dgvCheck();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("保存记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // 生成产品盘点数据
                    checkstockClass.PslId = Convert.ToInt64(stockCLogic.SearchPPSuttle(pid).Rows[0][2].ToString());

                    if (stockCLogic.InsertPProduct(checkstockClass))
                    {
                        MessageBox.Show("保存记录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearAction();
                        set_dgvCheck();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("保存记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }


        }
    }
}
