using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;

namespace DasherStation.HumanResource
{    
    public partial class FrmEmployeeInfo : DasherStation.common.BaseForm
    {
        public FrmEmployeeInfo()
        {
            InitializeComponent();
        }

        private void BindDataGrid()
        {            
            this.dtgList.DataSource = new EmployeeLogic().GetEmployees();            
        }

        private void InitForm()
        {
            List<Department> datasource = new DepartmentLogic().GetDepartMents();
            this.部门数据源.DataSource = datasource;
            this.cbo部门.DisplayMember = "name";
            this.cbo部门.ValueMember = "id";
            this.cbo部门.DataSource = this.部门数据源;

            this.comboBox1.DisplayMember = "name";
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DataSource = this.部门数据源;
            this.comboBox1.SelectedIndex = -1;
            

            DasherStation.system.SystemLogic p = new DasherStation.system.SystemLogic();
            p.InitialCbxDuty(this.cbo职位);
            this.cbo职位.DisplayMember = "name";
            this.cbo职位.ValueMember = "id";

            if (this.cbo部门.Items.Count > 0)
            {
                var yieldGroups = new EmployeeLogic().GetYieldGroupByDepID(long.Parse(this.cbo部门.SelectedValue.ToString()));
                yieldGroups.Insert(0, new ProduceTeam() { id = 0, name = "" });
                this.cbo生产班组.DataSource = yieldGroups;
                this.cbo生产班组.DisplayMember = "name";
                this.cbo生产班组.ValueMember = "id";                
            }

            this.dtgList.AutoGenerateColumns = false;

            this.员工类别数据源.Add(new CKind() { TypeID = false, TypeName = "正式员工" });
            this.员工类别数据源.Add(new CKind() { TypeID = true, TypeName = "临时员工" });

            this.是否纳税数据源.Add(new CMark() { IsMark = false, Mark = "不纳税" });
            this.是否纳税数据源.Add(new CMark() { IsMark = true, Mark = "纳税" });


            this.Column23.DataSource = this.部门数据源;
            this.Column23.DisplayMember = "name";
            this.Column23.ValueMember = "id";

            this.职位数据源.DataSource = this.cbo职位.DataSource;
            this.Column24.DataSource = this.职位数据源;
            this.Column24.DisplayMember = "name";
            this.Column24.ValueMember = "id";

            this.生产班组数据源.DataSource = this.cbo生产班组.DataSource;
            this.Column25.DataSource = this.生产班组数据源;
            this.Column25.DisplayMember = "name";
            this.Column25.ValueMember = "id";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitForm();
            this.BindDataGrid();
            this.txtName.Focus();
        }

        private bool CheckForm()
        {
            if(string.IsNullOrEmpty(this.txtNo.Text.Trim()))
            {
                CommUI.AlertError("职工编号不能为空!");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                CommUI.AlertError("职工姓名不能为空!");
                return false;
            }
            if (string.IsNullOrEmpty(this.txt身份证.Text.Trim()))
            {
                CommUI.AlertError("身份证号不能为空!");
                return false;
            }
            if (string.IsNullOrEmpty(this.txt民族.Text.Trim()))
            {
                CommUI.AlertError("民族不能为空!");
                return false;
            }
            if (string.IsNullOrEmpty(this.txt基本工资.Text.Trim()))
            {
                CommUI.AlertError("基本工资不能为空!");
                return false;
            }
            decimal newValue;
            if (decimal.TryParse(this.txt基本工资.Text.Trim(), out newValue) == false)
            {
                CommUI.AlertError("请在基本工资项输入一个有效数值!");
                return false;
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckForm())
            {
                PersonnelInfo entity = new PersonnelInfo();
                entity.no = this.txtNo.Text.Trim();
                entity.name = this.txtName.Text.Trim();
                entity.sex = this.radMan.Checked ? "男" : "女";
                entity.judgeMarry = this.rad己婚.Checked ? "己婚" : "未婚";
                entity.politicalVisage = this.txt政治.Text.Trim();
                entity.birthday = this.dBirthday.Value;
                entity.tiptopDegree = this.txt学位.Text.Trim();
                entity.specialty = this.txt专业.Text.Trim();
                entity.competencyCertificate = this.txt资格证书.Text.Trim();
                entity.IDCard = this.txt身份证.Text.Trim();
                entity.contactMethod = this.txt联系方式.Text.Trim();
                entity.nationality = this.txt民族.Text.Trim();
                entity.contractNo = this.txt合同编号.Text.Trim();
                entity.address = this.txt家庭住址.Text.Trim();
                entity.function = this.txt职称.Text.Trim();
                entity.functionAssessDate = this.d职称评定时间.Value;
                entity.nativePlace = this.txt籍贯.Text.Trim();
                if (this.cbo部门.Text.Trim() != "")
                {
                    entity.dId = long.Parse(this.cbo部门.SelectedValue.ToString());
                }
                entity.startWorkDate = this.d参加工作时间.Value;
                entity.salaryMethod = this.rad月薪.Checked  == false ? "日薪" : "月薪";
                entity.resume = this.txt简历.Text;
                entity.hortationCastigate = this.txt奖惩.Text.Trim();
                entity.dimissionDate = this.d离职时间.Value;
                entity.dimissionReason = this.txt离职原因.Text.Trim();
                entity.workDate = this.d入职时间.Value;
                entity.remark = this.txt备注.Text;
                
                entity.inputMan = this.UserName;
                entity.inputDate = DateTime.Now;
                entity.kind = this.radEmployee.Checked ? true : false;
                if (this.cbo生产班组.Text.Trim() != "")
                {
                    entity.ptId = long.Parse(this.cbo生产班组.SelectedValue.ToString());
                }
                entity.mark = this.rad纳税.Checked ? true : false;
                entity.basicSalary = decimal.Parse(this.txt基本工资.Text.Trim());
                if (this.cbo职位.Text.Trim() != "")
                {
                    entity.pId = long.Parse(this.cbo职位.SelectedValue.ToString());
                }

                string strResult = new EmployeeLogic().Add(entity);
                if (!string.IsNullOrEmpty(strResult))
                {
                    CommUI.AlertError(strResult);
                }
                else
                {
                    //CommUI.MsgOK();
                    foreach (TextBox t in this.groupBox1.Controls.OfType<TextBox>())
                    {
                        t.Text = "";
                    }
                    this.BindDataGrid();
                }
            }
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dtgList.RowCount == 0
                || this.dtgList.SelectedRows.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("确定要删除吗?", "请确认", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            int[] rowsID = (from System.Windows.Forms.DataGridViewRow row in this.dtgList.SelectedRows
                            select int.Parse(row.Cells["id"].Value.ToString())).ToArray<int>();

            if (rowsID.Length == 0)
            {
                try
                {
                    rowsID = new int[1] { int.Parse(this.dtgList.CurrentRow.Cells["id"].Value.ToString()) };
                }
                catch (System.Exception) { }
                if (rowsID.Length == 0) return;
            }

            new EmployeeLogic().Remove(rowsID);
            this.BindDataGrid();
        }

        
        /// <summary>
        /// 单元格验证时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal newValue;
            if (this.dtgList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return;
            
            if (this.dtgList.Columns[e.ColumnIndex].HeaderText == "基本工资" 
                && decimal.TryParse(e.FormattedValue.ToString().Trim(), out newValue) == false)
            {
                e.Cancel = true;
                CommUI.AlertError("请输入一个有效数值!");
            }
            DateTime d;
            if (this.dtgList.Columns[e.ColumnIndex].HeaderText == "出生日期"
                && DateTime.TryParse(e.FormattedValue.ToString().Trim(), out d) == false)
            {
                e.Cancel = true;
                CommUI.AlertError("请输入一个有日期!");
            }
            if (this.dtgList.Columns[e.ColumnIndex].HeaderText == "职称评定时间"
                && DateTime.TryParse(e.FormattedValue.ToString().Trim(), out d) == false)
            {
                e.Cancel = true;
                CommUI.AlertError("请输入一个有日期!");
            }
            if (this.dtgList.Columns[e.ColumnIndex].HeaderText == "参加工作时间"
                && DateTime.TryParse(e.FormattedValue.ToString().Trim(), out d) == false)
            {
                e.Cancel = true;
                CommUI.AlertError("请输入一个有日期!");
            }
            if (this.dtgList.Columns[e.ColumnIndex].HeaderText == "入职日期"
                && DateTime.TryParse(e.FormattedValue.ToString().Trim(), out d) == false)
            {
                e.Cancel = true;
                CommUI.AlertError("请输入一个有日期!");
            }
            if (this.dtgList.Columns[e.ColumnIndex].HeaderText == "离职时间"
                && DateTime.TryParse(e.FormattedValue.ToString().Trim(), out d) == false)
            {
                e.Cancel = true;
                CommUI.AlertError("请输入一个有日期!");
            }
        }

        /// <summary>
        /// 行验证之后,更新行记录.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgList_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if ((sender as DataGridView).ContainsFocus)
            {
                PersonnelInfo entity = this.dtgList.Rows[e.RowIndex].DataBoundItem as PersonnelInfo;
                new EmployeeLogic().Update(entity);
            }
        }

        private void cbo部门_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbo部门.SelectedValue != null)
            {
                var yieldGroups = new EmployeeLogic().GetYieldGroupByDepID(long.Parse(this.cbo部门.SelectedValue.ToString()));
                yieldGroups.Insert(0, new ProduceTeam() { id = 0, name = "" });
                this.cbo生产班组.DataSource = yieldGroups;
                this.cbo生产班组.DisplayMember = "name";
                this.cbo生产班组.ValueMember = "id";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dtgList.SelectedRows.Count == 0)
            {
                CommUI.AlertError("请选择一条记录!");
                return;
            }
            var frmEdit = new FrmEmployeeInfoEdit();
            frmEdit.iHumanID = (this.dtgList.SelectedRows[0].DataBoundItem as PersonnelInfo).id;
            var result = frmEdit.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.BindDataGrid();
            }
        }

        private void FrmEmployeeInfo_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_PrintSingle_Click(object sender, EventArgs e)
        {
            if (dtgList.SelectedRows.Count > 0)
            {
                string id = dtgList.SelectedRows[0].Cells[2].Value.ToString();

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.PersonalInfoDataSetTableAdapters.personnelInfoTableAdapter", "personnelInfo", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.PersonalInfoDataSet";
                reportData.ReportName = "DasherStation.Report.PersonalInfoReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }

        private void btn_PrintMulit_Click(object sender, EventArgs e)
        {
            string id;
            if (checkBox1.Checked)
            {
                comboBox1.Text = "";
            }
            if (!string.IsNullOrEmpty(comboBox1.Text.Trim()))
            {
                 id = comboBox1.Text.Trim();
            }
            else
            {
                 id = "";
            }
                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.PersonalInfoDetailDataSetTableAdapters.personnelInfoTableAdapter", "personnelInfo", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.PersonalInfoDetailDataSet";
                reportData.ReportName = "DasherStation.Report.PersonalInfoDetailReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            
        }  


    }



}
