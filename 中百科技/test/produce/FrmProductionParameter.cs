/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：FrmProductionParameter.cs
 * 文件功能描述：生产参数 窗体
 *
 * 创建人：关启学
 * 创建时间：2009-04-15
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

namespace DasherStation.produce
{
    public partial class FrmProductionParameter : common.BaseForm
    {
        
        #region // 参数初始化


        // “生产参数”数据库操作对象
        private ProductionParameterDB productionParameterDB = new ProductionParameterDB();

        // “生产参数”实体类对象
        private ProductionParameter productionParameter = new ProductionParameter();

        // 构造方法
        public FrmProductionParameter()
        {
            InitializeComponent();
        }


        #endregion


        #region // 窗体事件


        // 事件：窗体加载事件
        private void FrmProductionParameter_Load(object sender, EventArgs e)
        {
            cbxSeachCondition.SelectedIndex = 0;

            dtpDate.MaxDate = DateTime.Today;
            
            cbEquipmentNo.DataSource = productionParameterDB.GetEquipmentInfo();
            cbEquipmentNo.DisplayMember = "no";
            cbEquipmentNo.ValueMember = "id";

            SetEquipmentInfo();

            SearchProductionParameter();

        }

        // 事件：“新建按钮”点击事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddProductionParameter())
            {
                MessageBox.Show("新建成功");
            }
            else
            {
                MessageBox.Show("新建失败！");
            }

            ClearControlText();
            SearchProductionParameter();
        }

        // 事件：“删除按钮”点击事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProductionParameter();
        }

        // 事件：“查询按钮”点击事件
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProductionParameter();
        }

        // 事件：“设备编号下拉列表”下拉提交事件
        private void cbEquipmentNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetEquipmentInfo();
        }
        
        // 事件：“查询条件下拉列表”下拉提交事件
        private void cbxSeachCondition_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxSeachCondition.Text.Equals("设定时间"))
            {
                dtpDate.Visible = true;
                tbSeachText.Visible = false;
            }
            else
            {
                dtpDate.Visible = false;
                tbSeachText.Visible = true;
            }

            dtpDate.Value = DateTime.Today;
            tbSeachText.Text = "";
        }


        #endregion


        #region // 事件处理方法


        // 方法：查询全部“生产参数”
        private void SearchProductionParameter()
        {
            switch (cbxSeachCondition.Text)
            {
                case "设备编号":
                    dgvDetail.DataSource = productionParameterDB.GetProductionParameterByNo(tbSeachText.Text.Trim());
                    break;
                case "设备名称":
                    dgvDetail.DataSource = productionParameterDB.GetProductionParameterByName(tbSeachText.Text.Trim());
                    break;
                case "设定时间":
                    dgvDetail.DataSource = productionParameterDB.GetProductionParameterByDate(dtpDate.Value);
                    break;
                default:
                    dgvDetail.DataSource = productionParameterDB.GetProductionParameter();
                    break;
            }            

            dgvDetail.Columns["mark"].Visible = false;
            dgvDetail.Columns["inputMan"].Visible = false;
            dgvDetail.Columns["id"].Visible = false;
            dgvDetail.Columns["eiId"].Visible = false;
        }
        
        // 方法：根据设备id，设置“设备名称”和“设备规格”的显示控件内容
        private void SetEquipmentInfo()
        {
            long equipmentId = Convert.ToInt64(cbEquipmentNo.SelectedValue.ToString());

            tbEquipmentName.Text = productionParameterDB.GetEquipmentName(equipmentId);
            tbEquipmentModel.Text = productionParameterDB.GetEquipmentModel(equipmentId);
        }
        
        // 方法：添加“生产参数”
        private bool AddProductionParameter()
        {
            productionParameter.EiId = Convert.ToInt64(cbEquipmentNo.SelectedValue.ToString());

            decimal d = 0;
            decimal.TryParse(tbMaxTemperature.Text.Trim(),out d);
            productionParameter.MaxTemperature = d;

            d = 0;
            decimal.TryParse(tbMinTemperature.Text.Trim(),out d);
            productionParameter.MinTemperature = d;

            double dbl = 0;
            double.TryParse(tbAsphaltumError.Text.Trim(), out dbl);
            productionParameter.AsphaltumError = dbl;

            dbl = 0;
            double.TryParse(tbStoneError.Text.Trim(), out dbl);
            productionParameter.StoneError = dbl;

            productionParameter.InputMan = this.UserName;
            productionParameter.Mark = false;

            return productionParameterDB.InsertProductionParameter(productionParameter);

        }

        // 方法：清空为表提供数据的控件内容，以便于下一次的新增记录
        private void ClearControlText()
        {
            cbxSeachCondition.SelectedIndex = 0;
            tbSeachText.Visible = true;
            tbSeachText.Text = "";
            dtpDate.Visible = false;
            
            cbEquipmentNo.SelectedIndex = 0;
            SetEquipmentInfo();

            tbMaxTemperature.Text = "";
            tbMinTemperature.Text = "";
            tbAsphaltumError.Text = "";
            tbStoneError.Text = "";
        }

        // 方法：删除“生产参数”
        private void DeleteProductionParameter()
        {
            if (dgvDetail.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否要删除选中的“设备使用记录？”", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    long productionParameterId = Convert.ToInt64(dgvDetail.SelectedRows[0].Cells["id"].Value.ToString());
                    productionParameterDB.DeleteProductionParameter(productionParameterId);

                    SearchProductionParameter();
                }
            }

        }        
           

        #endregion

    }
}
