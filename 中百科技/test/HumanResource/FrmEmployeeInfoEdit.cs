using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.HumanResource
{
    public partial class FrmEmployeeInfoEdit : DasherStation.common.BaseForm
    {
        public long iHumanID;

        public FrmEmployeeInfoEdit()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitForm();
        }

        private void InitForm()
        {
            PersonnelInfo oEntity = new EmployeeLogic().GetEmployeeByID(this.iHumanID);
            List<Department> datasource = new DepartmentLogic().GetDepartMents();            
            this.cbo部门.DisplayMember = "name";
            this.cbo部门.ValueMember = "id";
            this.cbo部门.DataSource = datasource;
            if (oEntity.dId.HasValue)
            {
                this.cbo部门.SelectedValue = oEntity.dId;
            }


            DasherStation.system.SystemLogic p = new DasherStation.system.SystemLogic();
            this.cbo职位.DisplayMember = "name";
            this.cbo职位.ValueMember = "id";
            p.InitialCbxDuty(this.cbo职位);
            if (oEntity.pId.HasValue)
            {
                this.cbo职位.SelectedValue = oEntity.pId;
            }


            if (this.cbo部门.Items.Count > 0)
            {
                var yieldGroups = new EmployeeLogic().GetYieldGroupByDepID(long.Parse(this.cbo部门.SelectedValue.ToString()));
                yieldGroups.Insert(0, new ProduceTeam() { id = 0, name = "" });
                this.cbo生产班组.DataSource = yieldGroups;
                this.cbo生产班组.DisplayMember = "name";
                this.cbo生产班组.ValueMember = "id";
                if (oEntity.ptId.HasValue)
                {
                    this.cbo生产班组.SelectedValue = oEntity.ptId.Value;
                }
            }


            this.txtNo.Text = oEntity.no;
            this.txtName.Text = oEntity.name;
            if (oEntity.sex == "男")
            {
                this.radMan.Checked = true;
            }
            else
            {
                this.radWoman.Checked = true;
            }
            if (oEntity.judgeMarry == "己婚")
            {
                this.rad己婚.Checked = true;
            }
            else
            {
                this.rad未婚.Checked = true;
            }            
            this.txt政治.Text = oEntity.politicalVisage;
            if (oEntity.birthday.HasValue)
            {
                this.dBirthday.Value = oEntity.birthday.Value;
            }
            this.txt学位.Text = oEntity.tiptopDegree; 
            this.txt专业.Text  = oEntity.specialty;
            this.txt资格证书.Text = oEntity.competencyCertificate;
            this.txt身份证.Text = oEntity.IDCard;
            this.txt联系方式.Text = oEntity.contactMethod ;
            this.txt民族.Text = oEntity.nationality ;
            this.txt合同编号.Text = oEntity.contractNo  ;
            this.txt家庭住址.Text = oEntity.address  ;
            this.txt职称.Text = oEntity.function;
            if (oEntity.functionAssessDate.HasValue)
            {
                this.d职称评定时间.Value = oEntity.functionAssessDate.Value;
            }
            this.txt籍贯.Text = oEntity.nativePlace  ;
            if (oEntity.startWorkDate.HasValue)
            {
                this.d参加工作时间.Value = oEntity.startWorkDate.Value;
            }
            if (oEntity.salaryMethod == "日薪")
            {
                this.rad日薪.Checked = true;
            }
            else
            {
                this.rad月薪.Checked = true;
            }            
            this.txt简历.Text = oEntity.resume  ;
            this.txt奖惩.Text = oEntity.hortationCastigate ;
            if (oEntity.dimissionDate.HasValue)
            {
                this.d离职时间.Value = oEntity.dimissionDate.Value;
            }
            this.txt离职原因.Text = oEntity.dimissionReason ;
            if (oEntity.workDate.HasValue)
            {
                this.d入职时间.Value = oEntity.workDate.Value;
            }
            this.txt备注.Text = oEntity.remark  ;
            if (oEntity.kind.Value)
            {
                this.radEmployee.Checked = true;
            }
            else
            {
                this.radTemporary.Checked = true;
            }
            if (oEntity.mark.Value)
            {
                this.rad纳税.Checked = true;
            }
            else
            {
                this.rad不纳税.Checked = true;
            }

            this.txt基本工资.Text = oEntity.basicSalary.ToString();
            

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

        private bool CheckForm()
        {
            if (string.IsNullOrEmpty(this.txtNo.Text.Trim()))
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
                entity.id = this.iHumanID;
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
                entity.salaryMethod = this.rad月薪.Checked == false ? "日薪" : "月薪";
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

                new EmployeeLogic().Update(entity);                
                    //CommUI.MsgOK();
                    this.Close();
               
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
