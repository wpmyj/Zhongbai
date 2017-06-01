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
    public partial class FrmWarehouseInfo : BaseForm
    {
        public FrmWarehouseInfo()
        {
            InitializeComponent();
        }

        WarehouseInfo doWarehouseInfo = new WarehouseInfo();

        FormHelper formHelper = new FormHelper();

        warehouseInfo warehouseInfoObj;

        private void FrmWarehouseInfo_Load(object sender, EventArgs e)
        {
            QueryTypeBind(cmb_type);
            query();

        }

        private void query(string str)
        {
            this.dgv_warehouseInfo.DataSource=doWarehouseInfo.GetList(str).Tables[0];
        }

        private void query()
        {
            this.dgv_warehouseInfo.DataSource = doWarehouseInfo.GetAllList().Tables[0];
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(this.groupBox1))
            {
                warehouseInfoObj = new warehouseInfo();

                warehouseInfoObj.name = this.txt_name.Text.Trim();

                warehouseInfoObj.no = this.txt_no.Text.Trim();

                warehouseInfoObj.inputMan = this.UserName;

                doWarehouseInfo.Add(warehouseInfoObj);

                query();
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除选中记录", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                if (dgv_warehouseInfo.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dgvr in dgv_warehouseInfo.SelectedRows)
                    {
                        doWarehouseInfo.Delete(long.Parse(dgvr.Cells["id"].Value.ToString()));
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

            dr["name"] = "仓库名称";
            dr["value"] = "name";

            dt.Rows.Add(dr);

            dr = dt.NewRow();

            dr["name"] = "仓库编号";
            dr["value"] = "no";

            dt.Rows.Add(dr);

            cbx.DataSource = dt;
            cbx.DisplayMember = "name";
            cbx.ValueMember = "value";
            cbx.SelectedIndex = -1;
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            if (formHelper.inputCheck(this.groupBox2))
            {
                query(" "+this.cmb_type.SelectedValue.ToString()+" like '%"+this.txt_search.Text.Trim()+"%' ");
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
                warehouseInfoObj = new warehouseInfo();
                warehouseInfoObj.id = long.Parse(dgv_warehouseInfo.SelectedRows[0].Cells["id"].Value.ToString());
                warehouseInfoObj.name = dgv_warehouseInfo.SelectedRows[0].Cells["name"].Value.ToString();
                warehouseInfoObj.no = dgv_warehouseInfo.SelectedRows[0].Cells["no"].Value.ToString();

                FrmWarehouseInfoUpdate frmWarehouseInfoUpdate = new FrmWarehouseInfoUpdate();

                frmWarehouseInfoUpdate.Model = warehouseInfoObj;

                if (frmWarehouseInfoUpdate.ShowDialog() == DialogResult.OK)
                {
                    warehouseInfoObj.inputMan = this.UserName;
                    doWarehouseInfo.Update(warehouseInfoObj);
                }

                query();  
            }
        }
    }
}
