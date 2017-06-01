using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DasherStation.common;
namespace DasherStation.costCount
{
    public partial class FrmCostParameter : BaseForm
    {
        public FrmCostParameter()
        {
            InitializeComponent();
        }
        CostparameterLogic costParamLogic = new CostparameterLogic();       
       
        private void FrmCostParameter_Load(object sender, EventArgs e)
        {
            #region
            // 标示是否是第一次打开工时系数表  
            //bool isOpenFirst = costParamLogic.isOpenFirstLogic();                     
            //if (isOpenFirst)
            //{                
                // 当第一次录入工时系数的时候调用此表的内容
            //    dgvSetParameters.DataSource = costParamLogic.productNameLogic();
            //}
            //else
            //{
                // 当第二次以后调出此表时调用查找produceQuotiety（工时折算系数）表的内容
            //    dgvSetParameters.DataSource = costParamLogic.existProduceQuotietyTableLogic();
            //}
            #endregion 

            dgvSetParameters.DataSource = costParamLogic.productNameLogic();
        }
        // 实现保存关闭功能
        private void btnOk_Click(object sender, EventArgs e)
        {
            #region
            // 标示是否是第一次打开工时系数表  
            //bool isOpenFirst = costParamLogic.isOpenFirstLogic();
            //if (isOpenFirst)
            //{
                // 为true表示是第一次打开执行的是插入操作
            //    saveDatas();
            //}
            //else
            //{
            //    // 执行的是更新操作已经存入过工时系数表
            //    updateDatas();
            //}
            //this.Close();
            #endregion

            saveAll();
            this.Close();
        }
        // 执行关闭操作
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // 执行保存操作  判断是第一次输入执行插入操作 如果已经存在了 则执行更新操作
        private void btnUse_Click(object sender, EventArgs e)
        {
            #region
            // 标示是否是第一次打开工时系数表  
            //bool isOpenFirst = costParamLogic.isOpenFirstLogic();
            //if (isOpenFirst)
            //{
                // 为true表示是第一次打开执行的是插入操作
            //    saveDatas();
            //}
            //else
            //{
            //    // 执行的是更新操作已经存入过工时系数表
            //    updateDatas();
            //}
            #endregion

            saveAll();
        }
        #region
        // 要保存的数据
        //private void saveDatas()
        //{
        //    string remark="";
        //    DataRow[] drRows = ((this.dgvSetParameters.DataSource) as DataTable).Select(null, null, DataViewRowState.ModifiedCurrent);
        //    var szPid = (from DataRow r in drRows
        //              select Int64.Parse(r[0].ToString())).ToArray();
        //    var szQuotiety = (from DataRow r in drRows
        //                   select float.Parse(r[2].ToString())).ToArray();
        //    //System.Collections.ArrayList a = new System.Collections.ArrayList(szPid);
        //    foreach (DataRow row in drRows)
        //    {
        //        var pid = row[0];
        //        var quotiety = row[2];
        //        costParamLogic.savePerProductHoursLogic(Convert.ToInt64(pid), float.Parse(quotiety.ToString()), remark);
        //    }
        //}
        // 要更新的数据
        //private void updateDatas()
        //{
        //    string remark = "";
        //    DataRow[] drRows = ((this.dgvSetParameters.DataSource) as DataTable).Select(null, null, DataViewRowState.ModifiedCurrent);
        //    var szPid = (from DataRow r in drRows
        //              select Int32.Parse(r[0].ToString())).ToArray();
        //    var szQuotiety = (from DataRow r in drRows
        //                   select Int32.Parse(r[2].ToString())).ToArray();
        //    var szId = (from DataRow r in drRows
        //                select Int64.Parse(r[3].ToString())).ToArray();
        //    foreach (DataRow row in drRows)
        //    {
        //        var pid = row[0];
        //        var quotiety = row[2];
        //        var id = row[3];
        //        costParamLogic.updatePerProductHoursLogic(Convert.ToInt64(pid),float.Parse(quotiety.ToString()),remark,Convert.ToInt64(id));
        //    }
        //} 
        #endregion

        // 设置工时系数
        private List<produceQuotiety> setQuotiety()
        {
            produceQuotiety proQuotiety = null;
            List<produceQuotiety> list = new List<produceQuotiety>();
            foreach (DataGridViewRow dgvr in dgvSetParameters.Rows)
            {
                proQuotiety = new produceQuotiety();
                proQuotiety.pId = Convert.ToInt64(dgvr.Cells["Pid"].Value.ToString());
                if (dgvr.Cells["perProductHours"].FormattedValue.ToString() != "")
                {
                    proQuotiety.quotiety = float.Parse(dgvr.Cells["perProductHours"].Value.ToString());
                }

                list.Add(proQuotiety);
            }
            return list;
        }
        // 批量保存
        private void saveAll()
        {
            List<produceQuotiety> list = setQuotiety();
            if (costParamLogic.saveQuotietytable(list))
            {
                // 看最后的提示信息怎么处理 再进行处理
                //MessageBox.Show("保存成功！");
            }

        }

    }
}
