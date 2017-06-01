/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：FrmProductionSchedule.cs
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
using DasherStation.sell;


namespace DasherStation.produce
{
    public partial class FrmProductionSchedule : common.BaseForm
    {
        public FrmProductionSchedule()
        {
            InitializeComponent();
        }

       
        ProduceLogic producelogicobj = new ProduceLogic();
        DataSet ds = null;
        productionScheduleDetail proSchedetail = null;

        Produce produce=new Produce();

        private void FrmProductionSchedule_Load(object sender, EventArgs e)
        {
            //建立委托事件处理十二个月输入后计算生产产量
            foreach (Object obj in this.panel3.Controls)
            {
                if (obj.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    ((TextBox)obj).Leave += new EventHandler(txt_Leave);
                }
            }


            produce.yearBind(cmbYear);
            producelogicobj.proSort(proSort);
            producelogicobj.makerR(comboBox1);
            //producelogicobj.targetmp(targetmp);

            scheDetaildata();            

        }
        ////计算十二个月的总和 
        private void Cale()
        {
            double sum = 0.0;
            foreach (Object obj in this.panel3.Controls)
            {
                if (obj.GetType() == typeof(System.Windows.Forms.TextBox))
                {           
                    string value = ((TextBox)obj).Text;

                    if (!Check.CheckEmpty(value))
                    {
                        value = "0";
                    }
                    if (Check.CheckFloat(value))
                    {
                        sum += Convert.ToDouble(value);
                    }
                    else
                    {
                        
                         MessageBox.Show("只能输入数字！");
                         ((TextBox)obj).Clear();
                         ((TextBox)obj).Focus();
                         return;
                    }
                    txtProTotal.Text = Convert.ToString(sum);
                }
            }
        }
        //清空十二个月的值
        private void ClearText()
        {
            foreach (Object obj in this.panel3.Controls)
            {
                if (obj.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    ((TextBox)obj).Clear();
                }
            }
            proSort.Text = "";
            proName.Text = "";
            proType.Text = "";
            targetmp.Text = "";
            txtProTotal.Text = "";

        }

       
        //要委托的事件
        private void txt_Leave(object sender, EventArgs e)
        {
            Cale();
        }
        //添加按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((Check.CheckEmpty(proSort.Text)) && (Check.CheckEmpty(proName.Text)) && (Check.CheckEmpty(proType.Text))
                 && (Check.CheckEmpty(targetmp.Text)) && (Check.CheckEmpty(txtProTotal.Text)))
            {
                productionScheduleDetail proSchedetail = new productionScheduleDetail();
                string Pnid = this.proName.SelectedValue.ToString();
                string Pmid = this.proType.SelectedValue.ToString();

                int Pid = produce.queryPid(Pnid, Pmid);
                if (Pid != 0)
                {
                    proSchedetail.Pid = Pid;
                }
                else
                {
                    MessageBox.Show("产品信息错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //目标配合比还没有定下来暂时这么处理等质量管理模块做完再调整
                //proSchedetail.Tpid = 1;
                proSchedetail.Tpid = Convert.ToInt32(this.targetmp.SelectedValue.ToString());
                proSchedetail.Inputdate = DateTime.Now;
                if (txtProTotal.Text.Trim() != "")
                {
                    proSchedetail.Producequantity = Convert.ToDouble(this.txtProTotal.Text.Trim());
                }
                else
                {
                    proSchedetail.Producequantity = null;
                }
                if (this.txtJan.Text.Trim() != "")
                {
                    proSchedetail.January = Convert.ToDouble(this.txtJan.Text.Trim());
                }
                else
                {
                    proSchedetail.January = null;
                }
                if (this.txtFeb.Text.Trim() != "")
                {
                    proSchedetail.February = Convert.ToDouble(this.txtFeb.Text.Trim());
                }
                else
                {
                    proSchedetail.February = null;
                }
                if (this.txtMar.Text.Trim() != "")
                {
                    proSchedetail.March = Convert.ToDouble(this.txtMar.Text.Trim());
                }
                else
                {
                    proSchedetail.March = null;
                }
                if (this.txtApr.Text.Trim() != "")
                {
                    proSchedetail.April = Convert.ToDouble(this.txtApr.Text.Trim());
                }
                else
                {
                    proSchedetail.April = null;
                }
                if (this.txtMay.Text.Trim() != "")
                {
                    proSchedetail.May = Convert.ToDouble(this.txtMay.Text.Trim());
                }
                else
                {
                    proSchedetail.May = null;
                }
                if (this.txtJun.Text.Trim() != "")
                {
                    proSchedetail.June = Convert.ToDouble(this.txtJun.Text.Trim());
                }
                else
                {
                    proSchedetail.June = null;
                }
                if (this.txtJul.Text.Trim() != "")
                {
                    proSchedetail.July = Convert.ToDouble(this.txtJul.Text.Trim());
                }
                else
                {
                    proSchedetail.July = null;
                }
                if (this.txtAug.Text.Trim() != "")
                {
                    proSchedetail.August = Convert.ToDouble(this.txtAug.Text.Trim());
                }
                else
                {
                    proSchedetail.August = null;
                }
                if (this.txtSep.Text.Trim() != "")
                {
                    proSchedetail.September = Convert.ToDouble(this.txtSep.Text.Trim());
                }
                else
                {
                    proSchedetail.September = null;
                }
                if (this.txtOct.Text.Trim() != "")
                {
                    proSchedetail.October = Convert.ToDouble(this.txtOct.Text.Trim());
                }
                else
                {
                    proSchedetail.October = null;
                }
                if (this.txtNov.Text.Trim() != "")
                {
                    proSchedetail.November = Convert.ToDouble(this.txtNov.Text.Trim());
                }
                else
                {
                    proSchedetail.November = null;
                }
                if (this.txtDec.Text.Trim() != "")
                {
                    proSchedetail.December = Convert.ToDouble(this.txtDec.Text.Trim());
                }
                else
                {
                    proSchedetail.December = null;
                }

                producelogicobj.proScheDeAdd(proSchedetail,ds.Tables[0],proSort.Text,proName.Text,proType.Text,targetmp.Text);

                ClearText();
            }
            else
            {
                MessageBox.Show("种类，名称，型号，目标配合比，总量不能为空！");
            }
           
         }


       

        private void btnSaveRec_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text == "") || (Convert.ToString(this.cmbYear.Text.Trim()) == ""))
            {
                MessageBox.Show("制作人和制作年份不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                saveProductShedule();
            }
        }
        //自己做的生产计划明细表
        private void scheDetaildata()
        {
            DataTable table = new DataTable();
            ds = new DataSet();
            if (proSchedetail == null)
            {            
                
                table.Columns.Add("prosort");
                table.Columns.Add("name");
                table.Columns.Add("model");
                table.Columns.Add("measure");
                table.Columns.Add("inputDate");
                table.Columns.Add("one");
                table.Columns.Add("two");
                table.Columns.Add("three");
                table.Columns.Add("four");
                table.Columns.Add("five");
                table.Columns.Add("six");
                table.Columns.Add("seven");
                table.Columns.Add("eight");
                table.Columns.Add("nine");
                table.Columns.Add("ten");
                table.Columns.Add("eleven");
                table.Columns.Add("twelve");
                table.Columns.Add("total");
                table.Columns.Add("pid");
                table.Columns.Add("tpid");
                ds.Tables.Add(table);
            }
            else
            {
 
            }
                        
            dgvRecord.DataSource = ds.Tables[0];

        }
        
        //将datagridview上的值显示到具体信息中
        private void dgvRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            proSort.Text = Convert.ToString(dgvRecord[0, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            proName.Text = Convert.ToString(dgvRecord[1, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            proType.Text = Convert.ToString(dgvRecord[2, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            targetmp.Text = Convert.ToString(dgvRecord[3, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            //日期这个不要显示
            txtJan.Text = Convert.ToString(dgvRecord.CurrentRow.Cells["one"].Value.ToString());
            txtFeb.Text =Convert.ToString(dgvRecord.CurrentRow.Cells["two"].Value.ToString());
            txtMar.Text = Convert.ToString(dgvRecord.CurrentRow.Cells["three"].Value.ToString());
            txtApr.Text = Convert.ToString(dgvRecord[8, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            txtMay.Text = Convert.ToString(dgvRecord[9, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            txtJun.Text = Convert.ToString(dgvRecord[10, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            txtJul.Text = Convert.ToString(dgvRecord[11, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            txtAug.Text = Convert.ToString(dgvRecord[12, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            txtSep.Text = Convert.ToString(dgvRecord[13, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            txtOct.Text = Convert.ToString(dgvRecord[14, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            txtNov.Text = Convert.ToString(dgvRecord[15, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            txtDec.Text = Convert.ToString(dgvRecord[16, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            txtProTotal.Text = Convert.ToString(dgvRecord[17, dgvRecord.CurrentCell.RowIndex].Value).Trim();
            //btnAdd.Enabled = false;
            //button1.Enabled = true;
            //btnDelete.Enabled = true;
        }

       //种类绑定出来名称
        private void productKindBind()
        {
            string pkid = proSort.SelectedValue.ToString();
            producelogicobj.proName(proName, pkid);
        }
        //名称绑定出来型号
        private void productNameBind()
        {
            
                string pnid = proName.SelectedValue.ToString();
                producelogicobj.proType(proType, pnid);
         }
        
        private void proSort_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.productKindBind();
            //this.productNameBind();
            producelogicobj.targetmp(proSort, targetmp);

        }

        private void proName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.productNameBind();
        }
        //添加按钮的控制
        private void right()
        {
            //btnAdd.Enabled = true;
        }
        private void proSort_TextChanged(object sender, EventArgs e)
        {
            //right();
        }
        //批量保存采购计划的方法
        private void saveProductShedule()
        {
            productionSchedule proSchedule = getProSchedule();
            List<productionScheduleDetail> list = getProScheduleDetail();
            //producelogicobj.saveProScheduleAdd(proSchedule, list);
            if (producelogicobj.saveProScheduleAdd(proSchedule, list))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("保存出错","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }
        //获得生产计划主表信息
        private productionSchedule getProSchedule()
        {
            productionSchedule proSchedule = new productionSchedule();
            proSchedule.producer = comboBox1.Text.ToString();
            proSchedule.produceTime =DateTime.Parse(cmbYear.Text.Trim()+"-01-01");
            proSchedule.remark = txtRemark.Text.Trim();

            return proSchedule;
        }
        //获得生产计划多条明细表的信息
        private List<productionScheduleDetail> getProScheduleDetail()
        {
            
            productionScheduleDetail proScheDetail = null;
            List<productionScheduleDetail> list = new List<productionScheduleDetail>();
            foreach (DataGridViewRow dgvr in dgvRecord.Rows)
            {
                proScheDetail = new productionScheduleDetail();
               
                proScheDetail.Pid = int.Parse(dgvr.Cells["pid"].Value.ToString());
               
                proScheDetail.Tpid = int.Parse(dgvr.Cells["tpid"].Value.ToString());

                proScheDetail.Inputdate = DateTime.Parse(dgvr.Cells["inputDatekk"].Value.ToString());
                if (!string.IsNullOrEmpty(dgvr.Cells["one"].Value.ToString()))
                {
                    proScheDetail.January = Convert.ToDouble(dgvr.Cells["one"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(dgvr.Cells["two"].Value.ToString()))
                {
                    proScheDetail.February = Convert.ToDouble(dgvr.Cells["two"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(dgvr.Cells["three"].Value.ToString()))
                {
                    proScheDetail.March = Convert.ToDouble(dgvr.Cells["three"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(dgvr.Cells["four"].Value.ToString()))
                {
                    proScheDetail.April = Convert.ToDouble(dgvr.Cells["four"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(dgvr.Cells["five"].Value.ToString()))
                {
                    proScheDetail.May = Convert.ToDouble(dgvr.Cells["five"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(dgvr.Cells["six"].Value.ToString()))
                {
                    proScheDetail.June = Convert.ToDouble(dgvr.Cells["six"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(dgvr.Cells["seven"].Value.ToString()))
                {
                    proScheDetail.July = Convert.ToDouble(dgvr.Cells["seven"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(dgvr.Cells["eight"].Value.ToString()))
                {
                    proScheDetail.August = Convert.ToDouble(dgvr.Cells["eight"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(dgvr.Cells["nine"].Value.ToString()))
                {
                    proScheDetail.September = Convert.ToDouble(dgvr.Cells["nine"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(dgvr.Cells["ten"].Value.ToString()))
                {
                    proScheDetail.October = Convert.ToDouble(dgvr.Cells["ten"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(dgvr.Cells["eleven"].Value.ToString()))
                {
                    proScheDetail.November = Convert.ToDouble(dgvr.Cells["eleven"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(dgvr.Cells["twelve"].Value.ToString()))
                {
                    proScheDetail.December = Convert.ToDouble(dgvr.Cells["twelve"].Value.ToString());
                }
                if (!string.IsNullOrEmpty(dgvr.Cells["total"].Value.ToString()))
                {
                    proScheDetail.Producequantity = Convert.ToDouble(dgvr.Cells["total"].Value.ToString());
                }

                list.Add(proScheDetail);
            }

            return list;

        }
        //更新按钮
        private void button1_Click(object sender, EventArgs e)
        {
            dgvRecord.CurrentRow.Cells[0].Value = this.proSort.Text.Trim().ToString();
            dgvRecord.CurrentRow.Cells[1].Value = this.proType.Text.Trim().ToString();
            dgvRecord.CurrentRow.Cells[2].Value = this.proType.Text.Trim().ToString();
            dgvRecord.CurrentRow.Cells[3].Value = this.targetmp.Text.Trim().ToString();
           
            ////日期这个不要显示
            dgvRecord.CurrentRow.Cells[5].Value =this.txtJan.Text.Trim().ToString();
            dgvRecord.CurrentRow.Cells[6].Value =this.txtFeb.Text.Trim().ToString();
            dgvRecord.CurrentRow.Cells[7].Value=this.txtMar.Text.Trim().ToString();
            dgvRecord.CurrentRow.Cells[8].Value=this.txtApr.Text.Trim().ToString();
            dgvRecord .CurrentRow .Cells[9].Value =this.txtMay.Text.Trim().ToString();
            dgvRecord.CurrentRow.Cells[10].Value =this.txtJun.Text.Trim().ToString();
            dgvRecord.CurrentRow.Cells[11].Value=this.txtJul.Text.Trim().ToString();
            dgvRecord .CurrentRow .Cells [12].Value =this.txtAug .Text.Trim().ToString();
            dgvRecord .CurrentRow .Cells [13].Value =this.txtSep .Text.Trim().ToString();
            dgvRecord .CurrentRow .Cells [14].Value =this.txtOct .Text.Trim().ToString ();
            dgvRecord .CurrentRow .Cells [15].Value =this.txtNov .Text.Trim().ToString ();
            dgvRecord .CurrentRow .Cells[16].Value =this.txtDec .Text.Trim().ToString();
            dgvRecord .CurrentRow .Cells[17].Value =this.txtProTotal .Text.Trim().ToString();
           
        }
        //删除按钮支持多条删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvRecord.SelectedRows)
            {
                this.dgvRecord.Rows.Remove(dgvr);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dgvRecord.Rows.Count.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmSalseProgram fspform = new FrmSalseProgram();
            fspform.Show();
        }



       


       


       

       

      

      
    }
}


        
       
  





