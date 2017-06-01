using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.transport;

namespace DasherStation.system
{
    public partial class FrmOption : common.BaseForm
    {
        public FrmOption()
        {
            InitializeComponent();
        }

        OptionLogic oLogic = new OptionLogic();
        OptionClass optionClass = new OptionClass();
        ProductLogic pLogic = new ProductLogic();
        FormHelper formHelper = new FormHelper();

        private string optionName;
        public string OptionName
        {
            get
            {
                return optionName;
            }
            set
            {
                optionName = value;
            }
        }

        #region SetPanel()将所有Panel控件设备不可见
        /*
      * 方法名称： SetPanel()
      * 方法功能描述：将所有Panel控件设备不可见；
      *
      * 创建人：冯雪
      * 创建时间：2009-02-18
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        private void SetPanel()
        {
            pnlPositin.Visible = false;
            pnlSite.Visible = false;
            pnlTeam.Visible = false;
            pnlMethod.Visible = false;

        }
        #endregion

        #region SetPara() 插入、更新时提取文本框、下拉列表框内容
        /*
        * 方法名称： SetPara()
        * 方法功能描述：插入、更新时提取文本框、下拉列表框内容；
        *
        * 创建人：冯雪
        * 创建时间：2009-02-23
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void SetPara()
        {
            //职位名称；
            if (!txtPositin.Text.Trim().Equals(""))
            {
                optionClass.PositionName = txtPositin.Text.Trim();
            }
            else
            {
                optionClass.PositionName = "";
            }
            //地点；
            if (!txtSite.Text.Trim().Equals(""))
            {
                optionClass.Site = txtSite.Text.Trim();
            }
            else
            {
                optionClass.Site = "";
            }
            //生产班组；
            if (!txtTeamName.Text.Trim().Equals(""))
            {
                optionClass.PTeamName = txtTeamName.Text.Trim();
            }
            else
            {
                optionClass.PTeamName = "";
            }
            //生产部门；
            if (!txtDepartment.Text.Trim().Equals(""))
            {
                optionClass.Department = txtDepartment.Text.Trim();
            }
            else
            {
                optionClass.Department = "";
            }
            //组长；
            if (!cbxPiId.Text.Trim().Equals(""))
            {
                optionClass.PId = Convert.ToInt32(cbxPiId.SelectedValue.ToString());
            }
            else
            {
                optionClass.PId = 0;
            }
            //总人数;
            if (!txtCount.Text.Trim().Equals(""))
            {
                optionClass.Count = Convert.ToInt32(txtCount.Text.Trim());
            }
            else
            {
                optionClass.Count = 0;
            }
            //结算方式;
            if (!txtMethod.Text.Trim().Equals(""))
            {
                optionClass.TMethod = txtMethod.Text.Trim();
            }
            else
            {
                optionClass.TMethod = "";
            }
            //录入人;
            optionClass.InputMan = this.userName;    
        }
        #endregion

        #region ClearAction() 清空文本框
        private void ClearAction()   
        {
            txtPositin.Clear();
            txtSite.Clear();
            txtTeamName.Clear();
            txtDepartment.Clear();
            txtCount.Clear();
            txtMethod.Clear();
        }
        #endregion

        #region Positin() 职位
        private void Positin()
        {
            SetPanel();

            pnlPositin.Visible = true;
            lstPositin.DataSource = oLogic.SearchPosition();
            lstPositin.DisplayMember = "职位名称";
        }
        #endregion

        #region Site() 地点
        private void Sites()
        {
            SetPanel();

            pnlSite.Visible = true;
            lstSite.DataSource = oLogic.SearchSite();
            lstSite.DisplayMember = "地点";
        }
        #endregion

        #region Team() 生产班组
        private void Team()
        {
            PersonnelLogic plLogic = new PersonnelLogic();

            SetPanel();
            pnlTeam.Visible = true;

            cbxPiId.DataSource = plLogic.SearchPersonnelAll("", 0);
            cbxPiId.DisplayMember = "姓名";
            cbxPiId.ValueMember = "id";

            dgvPTeam.DataSource = oLogic.SearchProduceTeam();
            dgvPTeam.Columns["id"].Visible = false;
            dgvPTeam.Columns["inputDate"].Visible = false;
            dgvPTeam.Columns["inputMan"].Visible = false;
            dgvPTeam.Columns["备注"].Visible = false;
        }
        #endregion

        #region Method() 结算方式
        private void Method()
        {
            SetPanel();

            pnlMethod.Visible = true;
            lstMethod.DataSource = oLogic.SearchMethod();
            lstMethod.DisplayMember = "结算方式";
        }
        #endregion

        #region 初始化产品种类
        private void setPKind()
        {
            //cbxPKind.DataSource = pLogic.InitialPKindComboBox(); 
            //cbxPKind.DisplayMember = "产品种类";
            //cbxPKind.ValueMember = "id";
            //cbxPKind.Text = "";
            //cbxPKind.SelectedIndex = -1;
        }
        #endregion
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (treeView1.SelectedNode.Text.Trim())
            {
                case "职位":
                    {
                        Positin();
                        break;
                    }
                case "地点":
                    {
                        Sites();
                        break;
                    }
                case "生产班组":
                    {
                        //Team();
                        break;
                    }
                case "运输结算方式":
                    {
                        Method();
                        break;
                    }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOption_Load(object sender, EventArgs e)
        {
            initialValue();
        }
        private void initialValue()
        {
            if (optionName == null)
            {
                optionName = "职位";
            }
            switch (optionName)
            {
                case "职位":
                    {
                        Positin();
                        break;
                    }
                case "地点":
                    {
                        Sites();
                        break;
                    }
                case "生产班组":
                    {
                        Team();
                        break;
                    }
                case "运输结算方式":
                    {
                        Method();
                        break;
                    }                    
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SetPara();
            try
            {
                if (!string.IsNullOrEmpty(txtSite.Text.Trim()))                    
                {
                    if (lstSite.DataSource != null)
                    {
                        DataTable dtSite = lstSite.DataSource as DataTable;
                        DataRow drSite = dtSite.NewRow();
                        drSite["地点"] = txtSite.Text.Trim();
                        dtSite.Rows.Add(drSite);
                    }
                    else
                    {
                        lstSite.Items.Add(txtSite.Text.Trim());
                    }
                }
                if (!string.IsNullOrEmpty(txtMethod.Text.Trim()))
                {
                    if (lstMethod.DataSource != null)
                    {
                        DataTable dt = lstMethod.DataSource as DataTable;
                        DataRow dr = dt.NewRow();
                        dr["结算方式"] = txtMethod.Text.Trim();
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        lstMethod.Items.Add(txtMethod.Text.Trim());
                    }
                }
                //插入信息记录；
                if (oLogic.Insert(optionClass))
                {
                    ClearAction();                   
                }
                //else
                //{
                //    MessageBox.Show("新增记录失败，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("空数据无法保存！");
            }
        }

        private void FrmOption_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("确定关闭窗口吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            //{
            //    this.DialogResult = DialogResult.OK;
            //    e.Cancel = false;
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }

        private void pnlTeam_Leave(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(pnlTeam))
            {
                if (oLogic.ValidateTeam(txtTeamName.Text.Trim()))
                {
                    MessageBox.Show("该生产班组已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTeamName.Clear();
                    txtDepartment.Clear();
                    cbxPiId.Text = "";
                    txtCount.Clear();
                    txtTeamName.Focus();
                    return;
                }
            }
        }

        private void pnlMethod_Leave(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(pnlMethod))
            {
                if (oLogic.ValidatePosition(txtPositin.Text.Trim()))
                {
                    MessageBox.Show("该职位已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPositin.Clear();
                    txtPositin.Focus();
                    return;
                }
            }
        }

        private void pnlSite_Leave(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(pnlSite))
            {
                if (oLogic.ValidateSite(txtSite.Text.Trim()))
                {
                    MessageBox.Show("该地点已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSite.Clear();
                    txtSite.Focus();
                    return;
                }
            }
        }

        private void pnlPositin_Leave(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(pnlPositin))
            {
                if (oLogic.ValidatePosition(txtPositin.Text.Trim()))
                {
                    MessageBox.Show("该职位已存在，请从新操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPositin.Clear();
                    txtPositin.Focus();
                    return;
                }
            }
        }

    }
}
