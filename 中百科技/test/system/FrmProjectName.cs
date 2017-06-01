using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
using DasherStation.transport;

namespace DasherStation.system
{
    public partial class FrmProjectName : BaseForm
    {
        public FrmProjectName()
        {
            InitializeComponent();
        }

        private void FrmProjectName_Load(object sender, EventArgs e)
        {
            QueryTypeBind(cmb_type);
            query();

        }
        ProjectName doProjectName = new ProjectName();

        FormHelper formHelper = new FormHelper();

        projectName projectNameObj;

        private void query(string str)
        {
            this.dgv_warehouseInfo.DataSource = doProjectName.GetList(str).Tables[0];
        }
        private void ClearAllTextBox()
        {
            txt_no.Clear();
            txt_name.Clear();
            txt_unitProject.Clear();
            txt_subsectionProject.Clear();
            txt_itemProject.Clear();
            txt_position.Clear();
        }
        private void query()
        {
            this.dgv_warehouseInfo.DataSource = doProjectName.GetAllList().Tables[0];
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(this.groupBox1))
            {
                projectNameObj = new projectName();

                projectNameObj.itemProject = this.txt_itemProject.Text.Trim();

                projectNameObj.name = this.txt_name.Text.Trim();

                projectNameObj.no = this.txt_no.Text.Trim();

                projectNameObj.position = this.txt_position.Text.Trim();

                projectNameObj.subsectionProject = this.txt_subsectionProject.Text.Trim();

                projectNameObj.unitProject = this.txt_unitProject.Text.Trim();

                projectNameObj.inputMan = this.UserName;

                bool isExist=doProjectName.selectItems(projectNameObj);
                if (isExist)
                {
                    MessageBox.Show("此记录已经存在无法添加！");
                    ClearAllTextBox();
                    return;
                }
                else
                {
                    doProjectName.Add(projectNameObj);
                }

                query();
            }
            ClearAllTextBox();

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除选中记录", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                if (dgv_warehouseInfo.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dgvr in dgv_warehouseInfo.SelectedRows)
                    {
                        doProjectName.Delete(long.Parse(dgvr.Cells["id"].Value.ToString()));
                    }
                }
                query();
            }
        }

        private void QueryTypeBind(ComboBox cbx)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("name");
            dt.Columns.Add("value");

            DataRow dr = dt.NewRow();

            dr["name"] = "全部";
            dr["value"] = "all";

            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["name"] = "单位工程";
            dr["value"] = "unitProject";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["name"] = "分部工程";
            dr["value"] = "subsectionProject";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["name"] = "工程编号";
            dr["value"] = "no";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["name"] = "分项工程";
            dr["value"] = "itemProject";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["name"] = "工程名称";
            dr["value"] = "name";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["name"] = "工程部位";
            dr["value"] = "position";

            dt.Rows.Add(dr);

            cbx.DataSource = dt;
            cbx.DisplayMember = "name";
            cbx.ValueMember = "value";
            cbx.SelectedIndex = -1;
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            if (this.cmb_type.SelectedValue.ToString() == "all")
            {
                txt_search.Clear();
                query("");
                return;
            }
            if (formHelper.inputCheck(this.groupBox2))
            {
                query(" " + this.cmb_type.SelectedValue.ToString() + " like '%" + this.txt_search.Text.Trim() + "%' ");
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgv_warehouseInfo.SelectedRows.Count > 0)
            {

                projectNameObj = new projectName();
                projectNameObj.id = long.Parse(dgv_warehouseInfo.SelectedRows[0].Cells["id"].Value.ToString());
                projectNameObj.name = dgv_warehouseInfo.SelectedRows[0].Cells["name"].Value.ToString();
                projectNameObj.no = dgv_warehouseInfo.SelectedRows[0].Cells["no"].Value.ToString();
                projectNameObj.unitProject = dgv_warehouseInfo.SelectedRows[0].Cells["unitProject"].Value.ToString();
                projectNameObj.subsectionProject = dgv_warehouseInfo.SelectedRows[0].Cells["subsectionProject"].Value.ToString();
                projectNameObj.itemProject = dgv_warehouseInfo.SelectedRows[0].Cells["itemProject"].Value.ToString();
                projectNameObj.position = dgv_warehouseInfo.SelectedRows[0].Cells["position"].Value.ToString();

                FrmProjectNameUpdate frmProjectNameUpdate = new FrmProjectNameUpdate();

                frmProjectNameUpdate.Model = projectNameObj;

                if (frmProjectNameUpdate.ShowDialog() == DialogResult.OK)
                {
                    projectNameObj.inputMan = this.UserName;
                    doProjectName.Update(projectNameObj);
                }

                query();
            }
        }

    }
}
