/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：FrmProductionScheduleMain.cs
     * 文件功能描述：生产计划
     *
     * 创建人： 付中华
     * 创建时间：2009-02-17
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
using DasherStation.common;

namespace DasherStation.produce
{
    public partial class FrmProductionScheduleMain :common.BaseForm 
    {
        public FrmProductionScheduleMain()
        {
            InitializeComponent();
        }
        ProduceLogic producelogicobj = new ProduceLogic();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmProductionSchedule fpsform = new FrmProductionSchedule();
            if (fpsform.ShowDialog(this) == DialogResult.OK)
            {
                dataBind();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //修改处调用的也是新增的生产计划 只不过是已经赋值的
            FrmProductionSchedule fpsform = new FrmProductionSchedule();
            fpsform.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            compareYear();
        }
        //比较起始年份和结束年份得到符合要求的查询条件
        private void compareYear()
        {
            int startyear;
            int endyear;
            startyear = Convert.ToInt32(cmbStart.Text.Trim());
            endyear = Convert.ToInt32(cmbEnd.Text.Trim());
            if (startyear <= endyear)
            {
                producelogicobj.frmproductShedule(Convert.ToString(startyear), Convert.ToString(endyear), this.dgvList);
            }
            else
            {
                MessageBox.Show("起始年份不能大于结束年份！");
            }
        }
        private void yearBind()
        {
            int theYear = DateTime.Now.Year;
            for (int i = -10; i <= 10; i++)
            {
                cmbStart.Items.Add(theYear+i);
                cmbEnd.Items.Add(theYear + i);
            }
            cmbStart.SelectedIndex = cmbStart.Items.IndexOf(theYear);
            cmbEnd.SelectedIndex = cmbStart.Items.IndexOf(theYear);
        }

        private void FrmProductionScheduleMain_Load(object sender, EventArgs e)
        {
            yearBind();
            
            dataBind();
    
        }
        //将新增的生产计划绑定过主界面来
        private void dataBind()
        {
             producelogicobj.getList(dgvList);
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 1)
            {
                string id = this.dgvList.SelectedRows[0].Cells[0].Value.ToString();
                producelogicobj.getListchild(id, dataGridView1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否确定删除所选择项目", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dr in dgvList.SelectedRows)
                    {
                        string pId = dr.Cells["id"].Value.ToString().Trim();
                        if (!producelogicobj.productionDel(pId))
                        {
                            MessageBox.Show("删除失败!","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    dataBind();
                }
            }
        }

        private void btn_need_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 1)
            {
                string ppid = this.dgvList.SelectedRows[0].Cells[0].Value.ToString();

                FrmProductionScheduleNeed frmProductionScheduleNeed = new FrmProductionScheduleNeed();
                frmProductionScheduleNeed.Ppid = ppid;
                frmProductionScheduleNeed.ShowDialog();
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            button5.ContextMenuStrip.Show((Button)sender,e.X,e.Y);
        }

        private void 打印年计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 1)
            {
                string id = this.dgvList.SelectedRows[0].Cells[0].Value.ToString();
                ReportProductClass report = new ReportProductClass();
                report.RunYearProducePlan(id);
            }
        }

        private void 打印年需求计划ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 1)
            {
                string ppid = this.dgvList.SelectedRows[0].Cells[0].Value.ToString();

                ReportProductClass report = new ReportProductClass();
                report.RunYearMaterialRequirementsPlanning(ppid);
           
            }
        }

       

      

       
    }
}
