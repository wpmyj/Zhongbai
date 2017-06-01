using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.quality
{
    public partial class FrmProportionSendQuery : common.BaseForm
    {

        QualityLogic qualityLogic = new QualityLogic();

       

        public FrmProportionSendQuery()
        {
            InitializeComponent();
        }

        private void FrmProportionSendQuery_Load(object sender, EventArgs e)
        {
            try
            {
                qualityLogic.FormFrmProportionSendSearch(dgvDetail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmProportionSend FormFrmProportionSend = new FrmProportionSend();
            try
            {
                FormFrmProportionSend.Tag = 0;
                if (FormFrmProportionSend.ShowDialog() == DialogResult.OK)
                {
                    qualityLogic.FormFrmProportionSendSearch(dgvDetail);
                    if (dgvDetail.Rows.Count != 0)
                    {
                        dgvDetail.Rows[0].Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
           
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string conditionStr;
            string condition;
            string searchStr;
            DateTime searchStrD;

            try
            {
                conditionStr = cbxCond.Text.Trim();

                searchStr = txtSearchStr.Text.Trim();

                searchStrD = dateTimePicker1.Value.Date;

                switch (conditionStr)
                {
                    case "产品种类":
                        condition = "sort";
                        break;
                    case "产品名称":
                        condition = "name";
                        break;
                    case "规格型号":
                        condition = "model";
                        break;
                    case "通知时间":
                        condition = "inputDate";
                        break;
                    default:
                        condition = "1";
                        break;

                }
                if (cbxCond.SelectedItem.ToString().Trim() != "通知时间")
                {
                    if ((condition != "1") && (searchStr != ""))
                    {
                        qualityLogic.FrmProportionSendQuery(searchStr, condition, 1, dgvDetail, searchStrD);
                        txtSearchStr.Clear();
                    }
                    else
                    {
                        qualityLogic.FrmProportionSendQuery(searchStr, condition, 0, dgvDetail, searchStrD);
                    }
                }
                else
                {
                    qualityLogic.FrmProportionSendQuery(searchStr, condition, 1, dgvDetail, searchStrD);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }  
        }

        private void cbxCond_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cbxCond.SelectedItem.ToString().Trim() == "通知时间")
                {
                    txtSearchStr.Visible = false;
                    dateTimePicker1.Visible = true;
                }
                else
                {
                    dateTimePicker1.Visible = false;
                    txtSearchStr.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
           
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmProportionSend formProportionSend = new FrmProportionSend();

            int id;

            try
            {
                id = int.Parse(dgvDetail.CurrentRow.Cells["id"].Value.ToString());//发送配合比表Id

                formProportionSend.PSClass.Id = id;
                formProportionSend.PSClass.Sort = dgvDetail.CurrentRow.Cells["sort"].Value.ToString();
                formProportionSend.PSClass.Name = dgvDetail.CurrentRow.Cells["name"].Value.ToString();
                formProportionSend.PSClass.Model = dgvDetail.CurrentRow.Cells["model"].Value.ToString();
                formProportionSend.PSClass.InputDate = Convert.ToDateTime(dgvDetail.CurrentRow.Cells["inputDate"].Value.ToString());
                formProportionSend.PSClass.InputMan = dgvDetail.CurrentRow.Cells["inputMan"].Value.ToString();
                if (dgvDetail.CurrentRow.Cells["confirmDate"].Value.ToString() != "")
                {
                    formProportionSend.PSClass.ConfirmDate = Convert.ToDateTime(dgvDetail.CurrentRow.Cells["confirmDate"].Value.ToString());
                }
                if (dgvDetail.CurrentRow.Cells["R"].Value.ToString() != null)
                {
                    formProportionSend.PSClass.Remark = dgvDetail.CurrentRow.Cells["R"].Value.ToString();
                }
                formProportionSend.PSClass.EiId = dgvDetail.CurrentRow.Cells["no"].Value.ToString();

                formProportionSend.Tag = 1;

                formProportionSend.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            } 
        }
    }
}
