using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.system;

namespace DasherStation.equipment
{
    public partial class FrmEquipmentUpdate : DasherStation.common.BaseForm
    {
        public long id;
        public FrmEquipmentUpdate()
        {
            InitializeComponent();
        }
        EquipmentInfoLogic eLogic = new EquipmentInfoLogic();

        private void cbxKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cobBoBoxLinkage();
        }

        #region SetKind()设置设备类别
        private void SetKind()
        {
            cbxKind.DisplayMember = "设备类别";
            cbxKind.ValueMember = "id";
            cbxKind.DataSource = eLogic.SearchEquipmentKindAll();
        }
        #endregion

        #region cobBoBoxLinkage()选择类别后，设备名称联动

        private void cobBoBoxLinkage()
        {
            long ekId;

            if (cbxKind.SelectedValue == null)
            {
                ekId = 0;
            }
            else
            {
                ekId = Convert.ToInt64(cbxKind.SelectedValue.ToString());
            }
            if (eLogic.InitialEName(ekId).Rows.Count != 0)
            {
                cbxName.DataSource = eLogic.InitialEName(ekId);
                cbxName.DisplayMember = "设备名称";
                cbxName.ValueMember = "id";
            }
            else
            {
                cbxName.DataSource = eLogic.InitialEName(ekId);
            }

        }
        #endregion

        #region SetModel() 设置设备规格
        private void SetModel()
        {
            cbxModel.DataSource = eLogic.SearchEquipmentModelAll();
            cbxModel.DisplayMember = "设备规格";
            cbxModel.ValueMember = "id";
        }
        #endregion

        #region setDepartment() 设置部门名称;
        private void setDepartment()
        {
            cbxDId.DataSource = eLogic.SearchDepartment();
            cbxDId.DisplayMember = "name";
            cbxDId.ValueMember = "id";
        }
        #endregion

        #region setDocument() 设置文档编号;
        private void setDocument()
        {
            cbxDocument.DisplayMember = "no";
            cbxDocument.ValueMember = "id";
            cbxDocument.DataSource = eLogic.SearchDocument();         
 
        }
        #endregion

        private void BindMark()
        {
            this.cbx_mark.ValueMember = "key";
            this.cbx_mark.DisplayMember = "value";           
            this.cbx_mark.DataSource = new Mark[]
            {
                new Mark(){Key = "", Value= null},
                new Mark(){Key = "s", Value="拌合机一"},
                new Mark(){Key = "a", Value="拌合机二"},
                new Mark(){Key = "r", Value="乳化沥青机"},
                new Mark(){Key = "M", Value="热油炉"}
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.BindMark();
            SetKind();            
            
            EquipmentInformation entity = new EquipmentInfoLogic().GetDataByID(this.id);            
            using (DasherStation.common.SqlHelper oData = new DasherStation.common.SqlHelper())
            {
                try
                {
                    this.cbxKind.SelectedValue = oData.QueryForDateSet(string.Format(@"
                    select a.id from equmentKind a 
                    join equipmentName b on a.id = b.ekid
                    where b.id = {0}", entity.enId)).Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                }
            }
            
            SetModel();
            setDepartment();
            setDocument();

            this.txtNo.Text = entity.no;
            this.cbxName.SelectedValue = entity.enId;
            this.cbxModel.SelectedValue = entity.emId;
            this.txtCount.Text = entity.count.ToString();
            this.txtRMark.Text = entity.registrationMark;
            this.dtpBegin.Value = entity.beginUseTime.Value;
            if (entity.dId.HasValue)
            {
                this.cbxDId.SelectedValue = entity.dId;
            }
            this.txtPosition.Text = entity.installationPosition;
            this.txtSumPower.Text = entity.sumPower.ToString();
            this.txtAddMethod.Text = entity.addMethod;
            this.txtPValue.Text = entity.primaryValue.ToString();
            this.txtRemainsValue.Text = entity.remainsValue.ToString();
            this.txtDYear.Text = entity.depreciationYear.ToString();
            this.txtFactoryNo.Text = entity.factoryNo;
            if (entity.produceDate.HasValue)
            {
                this.dtpProduce.Value = entity.produceDate.Value;
            }
            this.txtWorkman.Text = entity.workMan;
            this.txtContackman.Text = entity.contactMan;
            this.txtContactMethod.Text = entity.contactMethod;
            this.txtZip.Text = entity.postCode;
            this.txtProducer.Text = entity.producer;
            if (entity.dId2.HasValue)
            {
                this.cbxDocument.SelectedValue = entity.dId2;
            }
            this.txtAdress.Text = entity.factoryAddress;
            if (entity.mark != null)
            {
                this.cbx_mark.SelectedValue = entity.mark;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (new DasherStation.transport.FormHelper().inputCheck(groupBox1))
            {
                EquipmentInformation entity = new EquipmentInformation();
                entity.id = this.id;
                entity.no = this.txtNo.Text.Trim();
                if(cbxName.SelectedValue != null)
                {
                    entity.enId = long.Parse(cbxName.SelectedValue.ToString());
                }
                if (cbxModel.SelectedValue != null)
                {
                    entity.emId = long.Parse(cbxModel.SelectedValue.ToString());
                }
                if (this.txtCount.Text.Trim() != "")
                {
                    entity.count = long.Parse(txtCount.Text);
                }
                
                
                    entity.registrationMark = this.txtRMark.Text;
                
                entity.beginUseTime = dtpBegin.Value;
                if (cbxDId.SelectedValue != null)
                {
                    entity.dId = long.Parse(cbxDId.SelectedValue.ToString());
                }
                entity.installationPosition = this.txtPosition.Text;
                if (this.txtSumPower.Text.Trim() != "")
                {
                    entity.sumPower = decimal.Parse(this.txtSumPower.Text);
                }
                entity.addMethod = this.txtAddMethod.Text;
                if (this.txtPValue.Text.Trim() != "")
                {
                    entity.primaryValue = decimal.Parse(this.txtPValue.Text);
                }
                if (this.txtRemainsValue.Text.Trim() != "")
                {
                    entity.remainsValue = decimal.Parse(this.txtRemainsValue.Text);
                }
                if (this.txtDYear.Text.Trim() != "")
                {
                    entity.depreciationYear = long.Parse(this.txtDYear.Text);
                }
                entity.factoryNo = this.txtFactoryNo.Text;
                entity.produceDate = this.dtpProduce.Value;
                entity.workMan = this.txtWorkman.Text;
                entity.contactMan = this.txtContackman.Text;
                entity.contactMethod = this.txtContactMethod.Text;
                entity.postCode = this.txtZip.Text;
                entity.producer = this.txtProducer.Text;
                if (this.cbxDocument.SelectedValue != null)
                {
                    entity.dId2 = long.Parse(this.cbxDocument.SelectedValue.ToString());
                }
                entity.factoryAddress = this.txtAdress.Text;
                if (this.cbx_mark.Text != "")
                {
                    entity.mark = this.cbx_mark.SelectedValue.ToString();
                }

                new EquipmentInfoLogic().Edit(entity);
                //DasherStation.HumanResource.CommUI.MsgOK();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cbxKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxKind_SelectionChangeCommitted(null, null);
        }

        private void FrmEquipmentUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }

    public class Mark
    {
        public string Key
        {
            set;
            get;
        }
        public string Value
        {
            set;
            get;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
