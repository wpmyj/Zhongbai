/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：
     * 文件功能描述：
     *
     * 创建人：付中华
     * 创建时间：2009-3-2
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

namespace DasherStation.stock
{
    public partial class FrmProSettlementAdd : BaseForm
    {
        stockSettlementLogic stockSettlementLogic = new stockSettlementLogic();
        private bool isNew;
        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }
        private string stockContractId;
        public string StockContractId
        {
            get { return stockContractId; }
            set { stockContractId = value; }
        }
        private string scName;
        public string ScName
        {
            get { return scName; }
            set { scName = value; }
        }
        //当前核算单ID；
        private long MaterialSettlementNo;
        public FrmProSettlementAdd()
        {
            InitializeComponent();
        }        
        //初始化窗体
        private void FrmProSettlementAdd_Load(object sender, EventArgs e)
        {
            //初始化合同名称
            //comboBox1.DataSource = stockSettlementLogic.initialContractComboboxLogic();
            comboBox1.DataSource = stockSettlementLogic.initialContractComboboxSupplyLogic();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            comboBox1.SelectedIndex = -1;
            if (!isNew)
            {
                comboBox1.Text = scName;
                //if (comboBox1.Text == "")
                //{
                //    MessageBox.Show("合同名称尚未选中无法查看！");
                //    return;
                //}
                if ((stockContractId != null) && (!stockContractId.Trim().Equals("")))
                {
                    dgvMain.DataSource = stockSettlementLogic.correspondingContractDetailInfoLogic(Convert.ToInt64(stockContractId));

                    comboBox1_SelectionChangeCommitted( sender, e);
                    // 对维护核算单的大部分内容设置其不可见
                    comboBox1.Enabled = false;
                    label2.Visible = false;
                    textBox1.Visible = false;
                    btn_ok.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    btn_scan.Visible = false;

                    dgvDetail.DataSource = stockSettlementLogic.GetStockNote(stockContractId);
                }
            }
        }
        //扫描开始
        private void btn_scan_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
        // 选择合同信息，查出相应的合同明细
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            long mainId = Convert.ToInt64(this.comboBox1.SelectedValue.ToString());
            // 取得合同对应的明细信息datatable;
            dgvMain.DataSource =stockSettlementLogic.correspondingContractDetailInfoLogic(mainId);
            textBox1.Focus();
        }
        // 扫描票具成功后处理
        private void textBox1_KeyUp(object sender, KeyEventArgs e)          
        {
            //if (e.KeyValue == 13)
            //{
            //    string barCode = this.textBox1.Text.ToString();
            //    bool exist = false;
            //    if (this.dgvDetail.DataSource != null)
            //    {
            //        DataTable dt = dgvDetail.DataSource as DataTable;
            //        //判断小票是否存在
            //        foreach (DataGridViewRow dgvr in dgvDetail.Rows)
            //        {
            //            if (dgvr.Cells["条形码"].Value.ToString() == Convert.ToString(barCode))
            //            {
            //                exist = true;                     
            //            }
            //        }
            //        if (exist)
            //        {
            //            textBox1.Clear();
            //            MessageBox.Show("此小票的条码已经存在！");
            //        }
            //        else
            //        {
            //            //小票信息的DataTable与当前数据合并
            //            dt.Merge(stockSettlementLogic.barCodeInfoLogic(barCode));
            //            caleContractDetailMoney();
            //            textBox1.Clear();
            //        }
            //    }
            //    else
            //    {
            //        dgvDetail.DataSource = stockSettlementLogic.barCodeInfoLogic(barCode);
            //        dgvDetail.Columns["id"].Visible = false;
            //        textBox1.Clear();
            //        caleContractDetailMoney();                   
            //    }                
            //}            
        }
        //计算采购合同明细的总金额
        private bool caleContractDetailMoney()
        {            
            foreach (DataGridViewRow dgvr1 in dgvMain.Rows)
            {
                int count = 0;
                decimal totalWeight = 0;

                foreach (DataGridViewRow dgvr2 in dgvDetail.Rows)
                {
                    if (decimal.Parse(dgvr2.Cells["合同明细编号"].Value.ToString()) == decimal.Parse(dgvr1.Cells["indentId"].Value.ToString()))
                    {
                        decimal unitPrice = 0;
                        unitPrice = decimal.Parse(dgvr1.Cells["unitPrice"].Value.ToString());
                        totalWeight += decimal.Parse(dgvr2.Cells["车辆净重"].Value.ToString());
                        dgvr1.Cells["quantity"].Value = Convert.ToString(totalWeight);
                        dgvr1.Cells["money"].Value = Convert.ToString(unitPrice * totalWeight);
                        count = count + 1;
                        dgvr1.Cells["countNote"].Value = Convert.ToString(count);      
                    }
                }
            }                             
            totalWeightSumCount();           
            return true;
        }
        //计算总金额总重量小票总数
        private void totalWeightSumCount()
        {
            decimal totalWeight = 0;
            decimal totalMoney = 0;
            int totalCount = 0;
            foreach(DataGridViewRow dgvr in dgvMain.Rows)
            {
                if ((dgvr.Cells["quantity"].Value != null) && (dgvr.Cells["money"].Value != null)) 
                { 
                    totalWeight += decimal.Parse(dgvr.Cells["quantity"].Value.ToString());
                    totalMoney += decimal.Parse(dgvr.Cells["money"].Value.ToString());
                    
                }
                if (dgvr.Cells["countNote"].Value != null)
                    totalCount += int.Parse(dgvr.Cells["countNote"].Value.ToString());
            }
            textBox2.Text = Convert.ToString(totalWeight);
            textBox3.Text = Convert.ToString(totalMoney);
            textBox4.Text = Convert.ToString(totalCount);
        }
        
        private void saveAll()
        {
            //实体类
            stockMaterialSettlement stockSet = getStockSettlement();
            //合同明细列表
            List<stockMaterialSettlementDetail> list = getStockSettledetail();            
            //存合同明细
            MaterialSettlementNo = stockSettlementLogic.saveStockSettlementAdd(stockSet, list);
            if (MaterialSettlementNo >= 0)
            {
                List<stockMaterialNoteCorresponding> list1 = GetStockMaterialNote();
                List<string> UpdateList = GetStockNodeUpdateInfo();
                //stockSettlementLogic.saveMaterialNoteCorresponding(list1, UpdateList);
                if (stockSettlementLogic.saveMaterialNoteCorresponding(list1, UpdateList))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                { }
            }

        }
        private List<string> GetStockNodeUpdateInfo()
        {
            string stockNodeFlag;
            List<string> list = new List<string>();

            foreach (DataGridViewRow dgvr in dgvDetail.Rows)
            {
                stockNodeFlag = dgvr.Cells["id"].Value.ToString();
                list.Add(stockNodeFlag);
            }
            return list;
        }
        private stockMaterialSettlement getStockSettlement()
        {
            stockMaterialSettlement stockSet = new stockMaterialSettlement();
            stockSet.totalWeight = float.Parse(this.textBox2.Text);
            stockSet.scId = Convert.ToInt64(this.dgvMain.Rows[0].Cells["scId"].Value.ToString());
            stockSet.sum = decimal.Parse(this.textBox3.Text);
            stockSet.inputDate = DateTime.Now;
            stockSet.inputMan = this.userName;
            stockSet.count = Convert.ToInt32(this.textBox4.Text);

            return stockSet;
        }
        private List<stockMaterialSettlementDetail> getStockSettledetail()
        {
            stockMaterialSettlementDetail stockSetDetail = null;
            List<stockMaterialSettlementDetail> list=new List<stockMaterialSettlementDetail>();

            foreach(DataGridViewRow dgvr in dgvMain.Rows)
            {
                stockSetDetail = new stockMaterialSettlementDetail();
                stockSetDetail.iId = Convert.ToInt64(dgvr.Cells["indentId"].Value.ToString());
                if (dgvr.Cells["countNote"].Value !=null)
                {
                    stockSetDetail.count = int.Parse(dgvr.Cells["countNote"].Value.ToString());
                }
                else
                {
                    stockSetDetail.count = 0;
                }
                if (dgvr.Cells["money"].Value != null)
                {
                    stockSetDetail.sum = decimal.Parse(dgvr.Cells["money"].Value.ToString());
                }
                else
                {
                    stockSetDetail.sum = 0;
                }
                stockSetDetail.inputDate = DateTime.Now;
                stockSetDetail.inputMan = this.userName;
                list.Add(stockSetDetail);               
            }
            return list;
        }
        // 取得票具信息值
        private List<stockMaterialNoteCorresponding> GetStockMaterialNote()
        {
            stockMaterialNoteCorresponding note = null;
            List<stockMaterialNoteCorresponding> list = new List<stockMaterialNoteCorresponding>();

            foreach (DataGridViewRow dgvr in dgvDetail.Rows)
            {
                note = new stockMaterialNoteCorresponding();
                note.smsdId = stockSettlementLogic.GetDetailNo(MaterialSettlementNo.ToString(), dgvr.Cells["合同明细编号"].Value.ToString());
                note.inputDate = DateTime.Now;
                note.snId = Convert.ToInt64(dgvr.Cells["id"].Value.ToString());
                note.inputMan = this.userName;
                list.Add(note);
            }
            return list;
 
        }
        //票据核算
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (dgvDetail.RowCount == 0)
            {
                MessageBox.Show("未进行票据扫描无法结算", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                return;                
            }
            if(MessageBox.Show("所有票据是否已经扫描完毕？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)==DialogResult.OK)
            {
                saveAll();                
                stockSettlementLogic.getNeedIdLogic();
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // 判断小票是否属于此合同下的某条明细
        private bool isContainedIndent()
        {
            bool isContained=false;
            string barCode = this.textBox1.Text.ToString();
            DataTable dt = stockSettlementLogic.barCodeInfoLogic(barCode);

            if (dt.Rows.Count <= 0)
            {                
                return false;
            }
            foreach (DataGridViewRow dgvr1 in dgvMain.Rows)
            {
                if (dt.Rows[0]["合同明细编号"].ToString() == dgvr1.Cells["indentId"].Value.ToString())
                {
                    isContained = true;                    
                }                           
            }
            if (!isContained)
            {                
                return false;
            }     
            return true;
        }
        // 判断次小票是否已经结算过
        private bool isAccount(string barCode)
        {
            DataTable dt = stockSettlementLogic.checkBarCode(barCode);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            bool isAddNote;
            bool isAccounts;
            if (e.KeyValue == 13)
            {
                string barCode = this.textBox1.Text.Trim();
                bool exist = false;
                if ((this.dgvDetail.DataSource != null)&&(barCode !=""))
                {
                    DataTable dt = dgvDetail.DataSource as DataTable;
                    //判断小票是否存在
                    foreach (DataGridViewRow dgvr in dgvDetail.Rows)
                    {
                        if (dgvr.Cells["条形码"].Value.ToString() == Convert.ToString(barCode))
                        {
                            exist = true;
                        }
                    }
                    if (exist)
                    {
                        textBox1.Clear();
                        MessageBox.Show("此小票的条码已经存在！");
                    }
                    else
                    {
                        isAddNote = isContainedIndent();
                        if ((isAddNote)&&(barCode!=""))
                        //小票信息的DataTable与当前数据合并
                        {
                            dt.Merge(stockSettlementLogic.barCodeInfoLogic(barCode));
                            caleContractDetailMoney();
                            textBox1.Clear();
                        }
                        else
                        {
                            MessageBox.Show("票具信息失败！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }
                        textBox1.Clear();
                    }
                }
                else
                {                   
                    isAddNote = isContainedIndent();
                    isAccounts = isAccount(barCode);
                    if (isAccounts)
                    {
                        MessageBox.Show("此小票已经结算过，不能再进行结算！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        return;
                    }
                    if ((isAddNote)&&(barCode!=""))
                    {
                        dgvDetail.DataSource = stockSettlementLogic.barCodeInfoLogic(barCode);
                        caleContractDetailMoney();
                        dgvDetail.Columns["id"].Visible = false;
                        textBox1.Clear();
                    }
                    else
                    {
                        MessageBox.Show("票具信息失败！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    textBox1.Clear();                   
                }
            }            
        }
    }
}
