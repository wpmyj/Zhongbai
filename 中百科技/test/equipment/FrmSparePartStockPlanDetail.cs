/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：FrmSparePartStockPlanDetail.cs
 * 文件功能描述：备品配件采购计划明细 窗体
 *
 * 创建人：关启学
 * 创建时间：2009-03-23
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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.equipment
{
    public partial class FrmSparePartStockPlanDetail : common.BaseForm
    {

        #region//参数初始化

        // “备品配件采购计划”数据库操作对象
        private SparePartStockPlanDB sparePartStockPlanDB = new SparePartStockPlanDB();

        // “备品配件采购计划”实体对象
        private SparePartStockPlan sparePartStockPlan = new SparePartStockPlan();

        // “备品配件”实体对象
        private SparePart sparePart = new SparePart();

        // 用于该子窗体关闭后，其父窗体能够访问在子窗体加入的设备保修计划id值
        public long SparePartStockPlanId
        {
            get { return sparePartStockPlan.Id; }
        }

        // 构造方法
        public FrmSparePartStockPlanDetail()
        {
            InitializeComponent();
        }

        // 构造方法
        public FrmSparePartStockPlanDetail(string inputMan)
        {
            InitializeComponent();
            this.userName = inputMan;
        }

        #endregion

        
        #region//窗体事件

        // 事件：窗体加载事件
        private void FrmSparePartStockPlanDetail_Load(object sender, EventArgs e)
        {
            InitialOverall();
            InitailDetail();
        }

        // 事件：“新建明细按钮”点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDetailRow();
            ClearDetail();
        }

        // 事件：“删除明细按钮”点击事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteDetailRow();
        }

        // 事件：“保存计划按钮”点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;

            sparePartStockPlan.ApplicationDate = dtpApplicationDate.Value;
            sparePartStockPlan.Proposer = cbProposer.SelectedValue.ToString();
            sparePartStockPlan.DId = Convert.ToInt64(cbDepartment.SelectedValue.ToString());
            //sparePartStockPlan.DId2 = Convert.ToInt64(cbDocumentNo.SelectedValue.ToString());

            //如果不存在该条记录，就插入
            DataTable dt = (DataTable)(dgvDetail.DataSource);
            sparePartStockPlanDB.InsertSparePartStockPlan(sparePartStockPlan, dt);


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 事件：“文档编码下拉列表”选择提交事件
        private void cbDocumentNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //tbDocumentName.Text = sparePartStockPlanDB.GetDocumentName(Convert.ToInt64(cbDocumentNo.SelectedValue.ToString()));
        }

        // 事件：“备品配件编码下拉列表”选择提交事件
        private void cbSparePartNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SearchSparePartInfo();
        }

        #endregion


        #region//事件处理方法

        // 方法：初始化主表信息
        private void InitialOverall()
        {
            //文档编号、名称
            //cbDocumentNo.DataSource = sparePartStockPlanDB.GetDocument();
            //cbDocumentNo.ValueMember = "id";
            //cbDocumentNo.DisplayMember = "no";
            //tbDocumentName.Text = sparePartStockPlanDB.GetDocumentName(Convert.ToInt64(cbDocumentNo.SelectedValue.ToString()));

            //申请人
            cbProposer.DataSource = sparePartStockPlanDB.GetPersonnelInfo();
            cbProposer.ValueMember = "name";
            cbProposer.DisplayMember = "name";

            //申请部门
            cbDepartment.DataSource = sparePartStockPlanDB.GetDepartment();
            cbDepartment.ValueMember = "id";
            cbDepartment.DisplayMember = "name";
        }

        // 方法：初始化从表信息
        private void InitailDetail()
        {
            //物料信息
            cbSparePartNo.DataSource = sparePartStockPlanDB.GetSparePartNo();
            cbSparePartNo.ValueMember = "id";
            cbSparePartNo.DisplayMember = "no";
            SearchSparePartInfo();
                        

            //设置计划明细的DataGridView
            dgvDetail.DataSource = sparePartStockPlanDB.GetSparePartStockPlanDetail(0);
            dgvDetail.Columns["id"].Visible = false;
            dgvDetail.Columns["spbiId"].Visible = false;
            dgvDetail.Columns["spspId"].Visible = false;
            dgvDetail.Columns["inputDate"].Visible = false;
            dgvDetail.Columns["inputMan"].Visible = false;

        }

        // 方法：根据“备品配件id”查询“备品配件”的“名称”、“种类”、“规格”、“最大库存”、“最小库存”、“单位”和“当前库存数量”
        private void SearchSparePartInfo()
        {
            sparePart = sparePartStockPlanDB.GetSparePart(Convert.ToInt64(cbSparePartNo.SelectedValue.ToString()));
            tbSparePartName.Text = sparePart.Name;
            tbSparePartSort.Text = sparePart.Sort;
            tbSparePartModel.Text = sparePart.Model;
            tbMaxStock.Text = sparePart.MaxStock.ToString();
            tbMinStock.Text = sparePart.MinStock.ToString();
            tbSparePartUnit.Text = sparePart.Unit;
            tbCurrentQuantity.Text = sparePart.CurrentQuantity.ToString();
        }
        

        // 方法：从控件中获取信息，并形成“明细”添加到从表中
        private void AddDetailRow()
        {
            DataTable dt = (DataTable)(dgvDetail.DataSource);

            //具有相同的备品配件编号的备品配件在同一个采购计划中不能出现两次以上
            foreach (DataRow r in dt.Rows)
            {
                if (r["sparePartNo"].ToString().Equals(cbSparePartNo.Text))
                {
                    MessageBox.Show("编号“" + cbSparePartNo.Text + "”的备品配件已经产生计划！不能再次计划！");
                    return;
                }
            }

            DataRow row = dt.NewRow();
            row["sparePartNo"] = cbSparePartNo.Text;
            row["sparePartName"] = tbSparePartName.Text;
            row["sparePartSort"] = tbSparePartSort.Text;
            row["sparePartModel"] = tbSparePartModel.Text;
            row["sparePartUnit"] = tbSparePartUnit.Text;

            long i = 0;
            if (tbCurrentQuantity.Text != "")
            {
                i = Convert.ToInt64(tbCurrentQuantity.Text);
            }
            row["currentQuantity"] = i;

            i = 0;
            if (tbMaxStock.Text != "")
            {
                i = Convert.ToInt64(tbMaxStock.Text);
            }
            row["maxStock"] = i;

            i = 0;
            if (tbMinStock.Text != "")
            {
                i = Convert.ToInt64(tbMinStock.Text);
            }
            row["minStock"] = i;


            row["requirementDate"] = dtpRequirementDate.Value;
            row["producer"] = tbProducer.Text;
            row["provider"] = tbProvider.Text;
            row["contactMan"] = tbContactMan.Text;
            row["contactMethod"] = tbContactMethod.Text;

            i = 0;
            if (tbCount.Text != "")
            {
                i = Convert.ToInt64(tbCount.Text);
            }
            row["count"] = i;

            decimal d = 0;
            if (tbUnitPrice.Text != "")
            {
                d = Convert.ToInt64(tbUnitPrice.Text);
            }
            row["unitPrice"] = d;

            row["inputMan"] = this.userName;
            row["spbiId"] = Convert.ToInt64(cbSparePartNo.SelectedValue.ToString());
                        

            dt.Rows.Add(row);
        }

        // 方法：清空从表控件的内容，为下次录入准备
        private void ClearDetail()
        {
            cbSparePartNo.SelectedIndex = 0;
            SearchSparePartInfo();

            dtpRequirementDate.Value = DateTime.Now;
            tbProducer.Text = "";
            tbProvider.Text = "";
            tbContactMan.Text = "";
            tbContactMethod.Text = "";
            tbCount.Text = "";
            tbUnitPrice.Text = "";
        }        

        // 方法：从表现层view获得后面绑定的数据层model源
        private void DeleteDetailRow()
        {
            if (dgvDetail.SelectedRows.Count > 0)
            {
                DataTable dt = (DataTable)(dgvDetail.DataSource);
                DataRowView rowView = dgvDetail.CurrentRow.DataBoundItem as DataRowView;
                DataRow row = rowView.Row;

                dt.Rows.Remove(row);
            }
        }        

        #endregion

    }
}
