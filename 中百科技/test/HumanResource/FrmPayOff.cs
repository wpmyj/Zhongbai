/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：FrmPayOff.cs
* 文件功能描述：工资发放窗体
*
* 创建人： 杨林
* 创建时间：2009-03-05
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

namespace DasherStation.HumanResource
{
    public partial class FrmPayOff : DasherStation.common.BaseForm
    {
        private string[] strInsuranceItems = new string[] { "养老保险", "医疗保险", "失业保险", "医疗大额保险", "住房公积金", "扣税" };
        private DataSet dtsWillBeStore = null;
        private PayRollItem[] strHeader = new PayOffLogic().GetPayRollItems();
       
        public FrmPayOff()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);            
            var chkBoxs = (this.MdiParent.ActiveMdiChild as FrmReadyPayOff).panPayRoll_flp.Controls.OfType<CheckBox>().Where(p=>p.Checked==true);            
            this.dtgAdd.ColumnCount = chkBoxs.Count();
            for(int i=0; i < this.dtgAdd.Columns.Count; i++)
            {
                this.dtgAdd.Columns[i].Name = chkBoxs.ElementAt(i).Text;
                this.dtgAdd.Columns[i].HeaderText = chkBoxs.ElementAt(i).Text;
                                if (this.strInsuranceItems.Contains(chkBoxs.ElementAt(i).Text))
                {
                    this.dtgAdd.Columns[i].ReadOnly = true;
                }
                DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
                dataGridViewCellStyle.Format = "N2";
                dataGridViewCellStyle.NullValue = null;
                this.dtgAdd.Columns[i].DefaultCellStyle = dataGridViewCellStyle;
            }            
            DataGridViewComboBoxColumn colCboHuman = new DataGridViewComboBoxColumn();            
            colCboHuman.HeaderText = "员工姓名";
            colCboHuman.Name = colCboHuman.HeaderText;
            colCboHuman.DataSource = HumanResourceLogic.GetAllPersonnel();
            colCboHuman.DisplayMember = "name";
            colCboHuman.ValueMember = "id";
            this.dtgAdd.Columns.Insert(0, colCboHuman);

            DataGridViewTextBoxColumn colWage = new DataGridViewTextBoxColumn();
            colWage.Name = "实领工资";
            colWage.DefaultCellStyle.Format = "N2";
            colWage.DefaultCellStyle.NullValue = null;
            colWage.ReadOnly = true;
            this.dtgAdd.Columns.Insert(this.dtgAdd.Columns.Count, colWage);

            this.dtsWillBeStore = new DataSet();
            this.dtsWillBeStore.Tables.Add(new DataTable());
            this.dtgList.AutoGenerateColumns = false;
            this.dtgList.ColumnCount = this.dtgAdd.ColumnCount;
            //this.dtgList.ReadOnly = true;            
            for (int i = 0; i < this.dtgAdd.ColumnCount; i++)
            {
                this.dtgList.Columns[i].Name = this.dtgAdd.Columns[i].Name;
                this.dtgList.Columns[i].HeaderText = this.dtgAdd.Columns[i].HeaderText;
                this.dtgList.Columns[i].DataPropertyName = this.dtgAdd.Columns[i].Name;
                this.dtsWillBeStore.Tables[0].Columns.Add(this.dtgAdd.Columns[i].Name);
            }
            this.dtsWillBeStore.Tables[0].Columns.Add("员工标识");            
        }        

        private void dtgAdd_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            this.dtgAdd.Rows[e.RowIndex].ErrorText = "";
            decimal newValue;
            // Don't try to validate the 'new row' until finished 
            // editing since there
            // is not any point in validating its initial value.
            if (this.dtgAdd.Rows[e.RowIndex].IsNewRow 
                || this.dtgAdd.Columns[e.ColumnIndex].Name == "员工姓名")
            {
                return; 
            }
            if (this.dtgAdd.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString() == "") return;
            if (!decimal.TryParse(e.FormattedValue.ToString().Trim(), out newValue))
            {
                e.Cancel = true;
                this.dtgAdd.Rows[e.RowIndex].ErrorText = "请输入一个有效数值!";                
            }            
        }

        /// <summary>
        /// 获取各保险金额
        /// </summary>
        /// <param name="strName">保险名称</param>
        /// <param name="mBase">基本工资引用</param>
        /// <param name="mV">基本工资</param>
        /// <returns></returns>
        private decimal GetInsuranceValue(string strName, ref decimal mRealy, decimal mBase)
        {
            decimal dValue = 0;
            switch (strName)
            {
                case "养老保险":
                    dValue = HumanResourceLogic.GetAnnuities(mBase);
                    mRealy -= dValue;
                    break;
                case "医疗保险" :
                    dValue = HumanResourceLogic.GetMedicare(mBase);
                    mRealy -= dValue;
                    break;
                case "失业保险":
                    dValue = HumanResourceLogic.GetUnemployment(mBase);
                    mRealy -= dValue;
                    break;
                case "住房公积金":
                    dValue = HumanResourceLogic.GetHousingFund(mBase);
                    mRealy -= dValue;
                    break;
                case "医疗大额保险":
                    dValue = HumanResourceLogic.GetBigMedicare();
                    mRealy -= dValue;
                    break;
                case "扣税" :
                    dValue = HumanResourceLogic.GetPersonnelIncomeTax(mBase);
                    //先不减掉税钱
                    break;
            }            
            return dValue;
        }

        private void dtgAdd_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgAdd.Rows[e.RowIndex].IsNewRow) { return; }
            decimal mBase = 0m;/*mAnnuities=0, mMedicare=0, mUnemployment=0, mBigMedicare=0, mHousingFund=0, mPTax=0;*/                      

            //遍历数据行与工资项配对,如果是增项,加到基本工资中,如果是前减项则从基本工资中减掉.
            this.CalculateIncrement(ref mBase, this.dtgAdd.Rows[e.RowIndex], this.strHeader);           

            //算保险列的值(如果选了某保险列,就算)
            decimal mRealy = mBase;
            foreach (DataGridViewColumn column in this.dtgAdd.Columns)
            {
                if (this.strInsuranceItems.Contains(column.Name))
                {
                    this.dtgAdd.Rows[e.RowIndex].Cells[column.Name].Value = GetInsuranceValue(column.Name, ref mRealy, mBase);
                }
            }                     
            
            //实际所得,税前工资(己扣掉保险,没扣税),减掉税钱.
            mRealy = mRealy - HumanResourceLogic.GetPersonnelIncomeTax(mRealy); ;
            //遍历数据行与工资项配对,如果存在后减项则从税后工资中减掉.
            this.CalculateDecrease(ref mRealy, this.dtgAdd.Rows[e.RowIndex], this.strHeader); 
            this.dtgAdd.Rows[e.RowIndex].Cells["实领工资"].Value = mRealy;
        }

        private void dtgAdd_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.dtgAdd.Rows[e.RowIndex].ErrorText = "";
            if (this.dtgAdd.Rows[e.RowIndex].IsNewRow) { return; }
            if (this.dtgAdd.Rows[e.RowIndex].Cells[0].FormattedValue.ToString().Trim() == "")
            {
                e.Cancel = true;
                this.dtgAdd.Rows[e.RowIndex].ErrorText = "请选择员工!";
            }
            // 如果有基本工资列,就必添
            else if (this.dtgAdd.Columns.OfType<DataGridViewColumn>().Where(p=>p.Name=="基本工资").Count()>0 
                && this.dtgAdd.Rows[e.RowIndex].Cells["基本工资"].FormattedValue.ToString().Trim() == "")
            {
                e.Cancel = true;
                this.dtgAdd.Rows[e.RowIndex].ErrorText = "请添写基本工资项!";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            for(int j=0; j < this.dtgAdd.Rows.Count; j++)
            {
                if (this.dtgAdd.Rows[j].IsNewRow) continue;
                DataRow row = this.dtsWillBeStore.Tables[0].NewRow();
                for(int i=0;i < this.dtgAdd.Rows[j].Cells.Count;i++)
                {
                    row[i] = this.dtgAdd.Rows[j].Cells[i].FormattedValue;
                }
                row["员工标识"] = this.dtgAdd.Rows[j].Cells["员工姓名"].Value;
                if (dtsWillBeStore.Tables[0].Select(string.Format("员工标识='{0}'", row["员工标识"])).Count() > 0)
                {
                    continue;
                }
                dtsWillBeStore.Tables[0].Rows.Add(row);
            }
            if (this.dtsWillBeStore.Tables[0].Rows.Count > 0)
            {
                this.dtgList.DataSource = dtsWillBeStore.Tables[0];
            }
            this.dtgAdd.Rows.Clear();
        }

        /// <summary>
        /// 计算增项/前减项
        /// </summary>
        /// <param name="mBase"></param>
        /// <param name="oRow"></param>
        /// <param name="oPayRollItems"></param>
        private void CalculateIncrement(ref decimal mBase, DataGridViewRow oRow, DasherStation.HumanResource.PayRollItem[] oPayRollItems)
        {
            foreach (DataGridViewCell cell in oRow.Cells)
            {
                string strColName = oRow.DataGridView.Columns[cell.ColumnIndex].Name;
                //增项
                var findPayRoll = (from item in oPayRollItems
                                      where 
                                        item.Name == strColName 
                                        && item.IsMinus == false
                                        //&& !strInsuranceItems.Contains(strColName)
                                        //&& strColName != "基本工资"
                                  select item).FirstOrDefault();
                if (cell.Value != null && findPayRoll != null)
                {
                    mBase += decimal.Parse(cell.Value.ToString());
                    continue;
                }
                //前减项
                findPayRoll = (from item in oPayRollItems
                                   where item.Name == strColName 
                                    && item.IsMinus == true
                                    && item.IsFirstMinus == true
                                    && !strInsuranceItems.Contains(strColName)//养老保险不算前减项
                                    //&& strColName != "基本工资"
                               select item).FirstOrDefault();
                if (cell.Value != null && findPayRoll != null)
                {
                    mBase -= decimal.Parse(cell.Value.ToString());
                }
            }
        }

        /// <summary>
        /// 计算后减项,该项要在税后再减
        /// </summary>
        /// <param name="mBase"></param>
        /// <param name="oRow"></param>
        /// <param name="oPayRollItems"></param>
        private void CalculateDecrease(ref decimal mBase, DataGridViewRow oRow, DasherStation.HumanResource.PayRollItem[] oPayRollItems)
        {
            foreach (DataGridViewCell cell in oRow.Cells)
            {
                string strColName = oRow.DataGridView.Columns[cell.ColumnIndex].Name;                
                var findPayRoll = (from item in oPayRollItems
                                       where 
                                       item.Name == strColName 
                                       && item.IsMinus == true
                                       && item.IsFirstMinus == false
                                       && !strInsuranceItems.Contains(strColName)//养老保险不算后减项
                                       //&& strColName != "基本工资"
                                   select item).FirstOrDefault();
                if (cell.Value != null && findPayRoll != null)
                {
                    mBase -= decimal.Parse(cell.Value.ToString());
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

            var oDataGridViewRows = from DataGridViewRow row in this.dtgList.SelectedRows
                                    select row;
            foreach (var row in oDataGridViewRows)
            {
                this.dtgList.Rows.RemoveAt(row.Index);
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            if (this.dtsWillBeStore.Tables[0].Rows.Count <= 0)
            {
                return;
            }
            if (this.txtPayOffName.Text.Trim() == "")
            {
                CommUI.MsgOK("工资发放名称不能为空!");
                this.txtPayOffName.Focus();
                return;
            }
            PayOffLogic oExec = new PayOffLogic();
            if(oExec.IsExistPayName(this.txtPayOffName.Text.Trim()))
            {
                CommUI.AlertError("工资发放名称己经存在,请修改!");
                this.txtPayOffName.Focus();
                return;
            }     
           
            PayOffDTS dtsPayOff = new PayOffDTS();            
            foreach (DataRow oRow in this.dtsWillBeStore.Tables[0].Rows)
            {
                PayOffDTS.payOffGatherRow drPayOffGather = dtsPayOff.payOffGather.NewpayOffGatherRow();
                drPayOffGather.piId = long.Parse(oRow["员工标识"].ToString());
                drPayOffGather.realIncome = decimal.Parse(oRow["实领工资"].ToString());
                drPayOffGather.month = this.datePayOff.Value;
                drPayOffGather.inputDate = DateTime.Now;
                drPayOffGather.cHumanName = oRow["员工姓名"].ToString();
                drPayOffGather.inputMan = this.UserName;
                drPayOffGather.name = this.txtPayOffName.Text.Trim();
                dtsPayOff.payOffGather.AddpayOffGatherRow(drPayOffGather);
                foreach (DataColumn oColumn in this.dtsWillBeStore.Tables[0].Columns)
                {
                    // 判断每一列是否为薪水项
                    PayRollItem oPayRollItem = this.strHeader.Where(arg => arg.Name == oColumn.ColumnName).FirstOrDefault();
                    if (oPayRollItem != null)
                    {
                        PayOffDTS.payOffDetailRow drPayOffDetail = dtsPayOff.payOffDetail.NewpayOffDetailRow();
                        drPayOffDetail.paid = oPayRollItem.ID;
                        drPayOffDetail.piId = drPayOffGather.piId;
                        drPayOffDetail.money = oRow[oColumn].ToString() == "" ? 0m : decimal.Parse(oRow[oColumn].ToString());
                        drPayOffDetail.month = drPayOffGather.month.Month;
                        drPayOffDetail.inputMan = this.UserName;                        
                        dtsPayOff.payOffDetail.AddpayOffDetailRow(drPayOffDetail);
                    }
                }
            }

            oExec.AddPayOff(dtsPayOff);
            CommUI.MsgOK();
            this.dtsWillBeStore.Tables[0].Rows.Clear();            
        }

        /// <summary>
        /// 单元格编辑之后时发生,在这里判断如果选择人了并且有基本工资列,就读数据库取基本工资值.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgAdd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgAdd.Columns[e.ColumnIndex].Name == "员工姓名"
                && this.dtgAdd.Columns.OfType<DataGridViewColumn>().Where(p=>p.Name=="基本工资").Count()>0)
            {

                //if (this.dtgAdd.Rows[e.RowIndex].Cells["基本工资"].Value == null)
                //{
                    decimal? mValue = HumanResourceLogic.GetBaseByHumanID(Int32.Parse(this.dtgAdd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
                    this.dtgAdd.Rows[e.RowIndex].Cells["基本工资"].Value = mValue.HasValue ? mValue.Value : 0;
                //}
            }
        }        
    }
}
