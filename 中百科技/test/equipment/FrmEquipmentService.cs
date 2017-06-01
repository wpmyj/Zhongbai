using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.transport;
using DasherStation.common;

namespace DasherStation.equipment
{
    public partial class FrmEquipmentService : common.BaseForm
    {
        public FrmEquipmentService()
        {
            InitializeComponent();
        }

        EquipmentLogic equipmentLogic = new EquipmentLogic();

        EquipmentServiceClass ESClass = new EquipmentServiceClass();

        FormHelper formHelper = new FormHelper();

        SqlHelper sqlHelperObj = new SqlHelper();

        DataTable dt;

        int count;

        private void FrmEquipmentService_Load(object sender, EventArgs e)
        {
            try
            {
                equipmentLogic.FrmEquipmentServiceInitialCbxENO(cbxENO);
                cbxENO.DisplayMember = "no";
                cbxENO.ValueMember = "no";
                cbxENO.SelectedIndex = -1;

                cbxRSort.SelectedIndex = -1;

                dt = equipmentLogic.CreatTable();
                dt.TableName = "Mine";
                dgvDetail.DataSource = dt;

                QueryBind(cbxQuery);
                cbxQuery.SelectedIndex = -1;

                dgvDetail.DataSource = equipmentLogic.FrmEquipmentServiceAllInfo("");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
        }

        private void cbxENO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                equipmentLogic.FrmEquipmentServiceLoadEquipNo(cbxENO.SelectedValue.ToString(), txtSort, txtName, txtModel);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dgvDetail.DataSource as DataTable;
            try
            {
                if (dataTable != null)
                {
                    if (dataTable.TableName.Equals("Mine"))
                    {
                        bool result = formHelper.inputCheck(groupBox2);

                        if (result)
                        {
                            add_row();
                            ClearCtrls(groupBox2);
                            dgvDetail.Rows[0].Selected = false;
                        }
                    }
                    else
                    {
                        dgvDetail.DataSource = dt;
                        bool result = formHelper.inputCheck(groupBox2);

                        if (result)
                        {
                            add_row();
                            ClearCtrls(groupBox2);
                            dgvDetail.Rows[0].Selected = false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void add_row()
        {
            DataRow dr = dt.NewRow();

            try
            {
                dr["no"] = cbxENO.SelectedValue.ToString();
                dr["sort"] = txtSort.Text.Trim();
                dr["name"] = txtName.Text.Trim();
                dr["model"] = txtModel.Text.Trim();
                dr["expenses"] = txtExpenses.Text.Trim();
                dr["serviceKind"] = cbxRSort.Text.Trim();
                dr["timeConsuming"] = txtTime.Text.Trim();
                dr["serviceDate"] = Convert.ToDateTime(dtpServiceDate.Text.Trim());
                dr["finishDate"] = Convert.ToDateTime(dtpFinishDate.Text.Trim());
                dr["interval"] = txtInterval.Text.Trim();
                dr["fno"] = txtFNO.Text.Trim();
                dr["serviceExplain"] = txtServiceExplain.Text.Trim();
                dr["changeAccessory"] = txtChangeAccessory.Text.Trim();
                dr["attemptRunExplain"] = txtAttemptRunExplain.Text.Trim();
                dr["testResult"] = txtTestResult.Text.Trim();
                dr["inputDate"] = System.DateTime.Now;
                //           dr["dasherName"] = equipmentLogic.FrmEquipmentServiceSearchDasherName();
                dr["inputMan"] = this.UserName;

                dt.Rows.Add(dr);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetail.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow dgvr in dgvDetail.SelectedRows)
                    {
                        this.dgvDetail.Rows.Remove(dgvr);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            count = dgvDetail.RowCount;
            try
            {
                if (count != 0)
                {
                    equipmentLogic.FrmEquipmentServiceSaveAll(getDetailInfo());

                    for (int i = 0; i < count; i++)
                    {
                        this.dgvDetail.Rows.Remove(dgvDetail.Rows[0]);
                    }
                    MessageBox.Show("保存成功！");

                }
                else
                {
                    if (MessageBox.Show("还没有输入详细信息，确定退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) ==
                                 DialogResult.OK)
                    {
                        this.Close();
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            } 
        }

        public void ClearCtrls(GroupBox containerName)
        {
            foreach (Object obj in containerName.Controls)
            {
                TextBox txt = obj as TextBox;
                
                if (txt != null)
                {
                    txt.Clear();
                    continue;
                }
                ComboBox cbx = obj as ComboBox;
                if (cbx != null)
                {
                    cbx.SelectedIndex = -1;
                    continue;
                }
                
            }
        }
        public void ClearCtrls(Panel containerName)
        {
            foreach (Object obj in containerName.Controls)
            {
                TextBox txt = obj as TextBox;

                if (txt != null)
                {
                    txt.Clear();
                    continue;
                }
                ComboBox cbx = obj as ComboBox;
                if (cbx != null)
                {
                    cbx.SelectedIndex = -1;
                    continue;
                }

            }
        }


        private List<EquipmentServiceClass> getDetailInfo()
        {

            EquipmentServiceClass ESClass;

            List<EquipmentServiceClass> list = new List<EquipmentServiceClass>();
            try
            {
                foreach (DataGridViewRow dgvr in dgvDetail.Rows)
                {
                    ESClass = new EquipmentServiceClass();

                    ESClass.No = dgvr.Cells["no"].Value.ToString();
                    ESClass.Sort = dgvr.Cells["sort"].Value.ToString();
                    ESClass.Name = dgvr.Cells["name"].Value.ToString();
                    ESClass.Model = dgvr.Cells["model"].Value.ToString();
                    ESClass.Expenses = double.Parse(dgvr.Cells["expenses"].Value.ToString());
                    ESClass.ServiceKind = dgvr.Cells["serviceKind"].Value.ToString();
                    ESClass.TimeConsuming = dgvr.Cells["timeConsuming"].Value.ToString();
                    ESClass.ServiceDate = DateTime.Parse(dgvr.Cells["serviceDate"].Value.ToString());
                    ESClass.FinishDate = DateTime.Parse(dgvr.Cells["finishDate"].Value.ToString());
                    ESClass.Interval = dgvr.Cells["interval"].Value.ToString();
                    ESClass.Fno = dgvr.Cells["fno"].Value.ToString();
                    ESClass.ServiceExplain = dgvr.Cells["serviceExplain"].Value.ToString();
                    ESClass.ChangeAccessory = dgvr.Cells["changeAccessory"].Value.ToString();
                    ESClass.AttemptRunExplain = dgvr.Cells["attemptRunExplain"].Value.ToString();
                    ESClass.TestResult = dgvr.Cells["testResult"].Value.ToString();
                    ESClass.InputDate = DateTime.Parse(dgvr.Cells["inputDate"].Value.ToString());
                    //                ESClass.DasherName = dgvr.Cells["dasherName"].Value.ToString();
                    ESClass.InputMan = dgvr.Cells["inputMan"].Value.ToString();

                    list.Add(ESClass);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
            return list;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string str = txtQueryStr.Text.Trim();
            try
            {
                if ((this.cbxQuery.SelectedIndex != -1) && (!(string.IsNullOrEmpty(str))))
                {
                    if (!Check.CheckQueryIsEmpty(str))
                    {
                        MessageBox.Show("查询关键字中不能包含特殊字符或空格", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string SqlStr = this.cbxQuery.SelectedValue.ToString() + " like '%" + str + "%'";
                    dataBind(SqlStr);
                    if (dgvDetail.Rows.Count != 0)
                    {
                        dgvDetail.Rows[0].Selected = false;
                    }
                }
                else
                {
                    dgvDetail.DataSource = equipmentLogic.FrmEquipmentServiceAllInfo("");
                    if (dgvDetail.Rows.Count != 0)
                    {
                        dgvDetail.Rows[0].Selected = false;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
        }
        private void dataBind(string strWhere)
        {
            try
            {
                this.dgvDetail.DataSource = equipmentLogic.FrmEquipmentServiceAllInfo(strWhere);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
        }
        //查询条件的绑定
        public void QueryBind(ComboBox cmb)
        {
            DataTable table = new DataTable();
            try
            {
                table.Columns.Add("ID");
                table.Columns.Add("Value");

                DataRow row = table.NewRow();

                row = table.NewRow();
                row["id"] = "EI.no";
                row["Value"] = "设备编号";
                table.Rows.Add(row);

                row = table.NewRow();
                row["id"] = "EK.sort";
                row["Value"] = "设备类别";
                table.Rows.Add(row);

                row = table.NewRow();
                row["id"] = "EN.name";
                row["Value"] = "设备名称";
                table.Rows.Add(row);

                row = table.NewRow();
                row["id"] = "EM.model";
                row["Value"] = "规格型号";
                table.Rows.Add(row);

                cmb.DataSource = table;
                cmb.ValueMember = "ID";
                cmb.DisplayMember = "Value";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedRows.Count > 0)
            {
                string id = dgvDetail.SelectedRows[0].Cells["no"].Value.ToString();

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.EquipmentServiceDataSetTableAdapters.equipmentServiceTableAdapter", "equipmentService", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.EquipmentServiceDataSet";
                reportData.ReportName = "DasherStation.Report.EquipmentServiceReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }
    }
}
