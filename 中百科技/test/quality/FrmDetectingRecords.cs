/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：DetectingRecords.cs
 * 文件功能描述：检测记录台帐界面
 *
 * 创建人：关启学
 * 创建时间：2009-02-04
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
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DasherStation.common;


namespace DasherStation.quality
{
    public partial class FrmDetectingRecords : common.BaseForm
    {
        //引用数据层对象
        private DetectingRecordsDB detectingRecordsDB = new DetectingRecordsDB();

        //三表联动操作对象  Kind,Name,Model 包含“材料”和“产品”
        private KindNameModel kindNameModel = new KindNameModel();


        #region //窗体公共事件与处理方法

        public FrmDetectingRecords()
        {
            InitializeComponent();
        }
        
        //事件：“窗体”加载
        private void DetectingRecords_Load(object sender, EventArgs e)
        { 
            IntializeData();
        }

        //事件：“tab页”选择
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tpMaterial)
            {
                dgvMaterialTestAccount.Visible = true;
                dgvProductTestAccount.Visible = false;

            }
            else
            {
                dgvMaterialTestAccount.Visible = false;
                dgvProductTestAccount.Visible = true;
            }
        }

        //事件：“移出按钮”点击
        private void btnMoveOut_Click(object sender, EventArgs e)
        {
            MoveOut();
        }

        //事件：“移入按钮”点击，将dgvLabTestInfo中选中的行（试验数据）移入相应的dgvMaterialTest（材料）或dgvProductTest（产品）中
        private void btnMoveIn_Click(object sender, EventArgs e)
        {
            MoveIn();
        }

        //事件：“时间控件”时间变化
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            IntializeData();
        }

        

        
        //方法：“窗体”初始化
        private void IntializeData()
        {
            // Set the MinDate and MaxDate.
            dateTimePicker1.MaxDate = DateTime.Today;

            //搜索“试验信息”
            SearchAccount();

            //初始化两个“tab页”
            InitialTpMaterial();
            InitialTpProduct();

            //默认显示“材料tab页”
            tabControl1.SelectedTab = tpMaterial;
        }        

        //方法：“移出按钮”点击，将相应的tab页的DataGridView中选中的“台帐”数据移到表示“试验信息”的DataGridView中
        private void MoveOut()
        {
            DataTable dtLabTest = (DataTable)(dgvLabTestInfo.DataSource);
            DataGridView dgvTest;
            DataRow row;

            if (tabControl1.SelectedTab == tpMaterial)
            {
                dgvTest = dgvMaterialTest;
            }
            else
            {
                dgvTest = dgvProductTest;
            }


            foreach (DataGridViewRow dr in dgvTest.SelectedRows)
            {
                row = dtLabTest.NewRow();
                row["试验编号"] = dr.Cells["试验编号"].Value.ToString();
                row["试验名称"] = dr.Cells["试验名称"].Value.ToString();
                row["试验员"] = dr.Cells["试验员"].Value.ToString();
                dtLabTest.Rows.Add(row);
                dgvTest.Rows.Remove(dr);
            }
        }

        //方法：“移入按钮”点击
        private void MoveIn()
        {
            DataTable dtTest;
            DataRow row;

            if (tabControl1.SelectedTab == tpMaterial)
            {
                dtTest = (DataTable)dgvMaterialTest.DataSource;
            }
            else
            {
                dtTest = (DataTable)dgvProductTest.DataSource;
            }


            foreach (DataGridViewRow dr in dgvLabTestInfo.SelectedRows)
            {
                row = dtTest.NewRow();
                row["试验编号"] = dr.Cells["试验编号"].Value.ToString();
                row["试验名称"] = dr.Cells["试验名称"].Value.ToString();
                row["试验员"] = dr.Cells["试验员"].Value.ToString();
                dtTest.Rows.Add(row);
                dgvLabTestInfo.Rows.Remove(dr);
            }

        }

        //方法：台帐查询
        private void SearchAccount()
        {
            dgvLabTestInfo.DataSource = detectingRecordsDB.GetLabTestInfo(dateTimePicker1.Value);
            //dgvLabTestInfo.Columns["试验日期"].Visible = false;

            dgvMaterialTestAccount.DataSource = detectingRecordsDB.GetMaterialTestAccount(dateTimePicker1.Value);
            dgvMaterialTestAccount.Columns["id"].Visible = false;
            dgvMaterialTestAccount.Columns["mId"].Visible = false;
            dgvMaterialTestAccount.Columns["mkId"].Visible = false;
            dgvMaterialTestAccount.Columns["mnId"].Visible = false;
            dgvMaterialTestAccount.Columns["mmId"].Visible = false;


            dgvProductTestAccount.DataSource = detectingRecordsDB.GetProductTestAccount(dateTimePicker1.Value);
            dgvProductTestAccount.Columns["id"].Visible = false;
            dgvProductTestAccount.Columns["pId"].Visible = false;
            dgvProductTestAccount.Columns["pkId"].Visible = false;
            dgvProductTestAccount.Columns["pnId"].Visible = false;
            dgvProductTestAccount.Columns["pmId"].Visible = false;
        }

        #endregion



        #region //关于“材料”的窗体事件与处理方法

        //材料事件：“材料种类”下拉控件，选中值变化事件
        private void cbxMaterialKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetMaterialNameList();
            SetMaterialModelList();

            SetMaterialQuantity();
        }

        //材料事件：“材料名称”下拉控件，选中值变化事件
        private void cbxMaterialName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetMaterialModelList();

            SetMaterialQuantity();
        }

        //材料事件：“材料规格”下拉控件，选中值变化事件
        private void cbxMaterialModel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetMaterialQuantity();
        }

        //材料事件：“保存按钮”点击
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMaterialTestAccount();
        }

        //材料事件：“材料台帐”记录选中事件
        private void dgvMaterialTestAccount_SelectionChanged(object sender, EventArgs e)
        {
            MaterialCopyRow(dgvMaterialTestAccount, dgvMaterialTest);
        }



        //材料方法：“tab标签（tpMaterial）”初始化
        private void InitialTpMaterial()
        {
            dgvMaterialTest.DataSource = detectingRecordsDB.GetMaterialTestAccount(dateTimePicker1.Value);
            //((DataTable)dgvMaterialTest.DataSource).Clear();
            dgvMaterialTest.Columns["id"].Visible = false;
            dgvMaterialTest.Columns["mId"].Visible = false;
            dgvMaterialTest.Columns["mkId"].Visible = false;
            dgvMaterialTest.Columns["mnId"].Visible = false;
            dgvMaterialTest.Columns["mmId"].Visible = false;
            dgvMaterialTest.Columns["台帐日期"].Visible = false;
            dgvMaterialTest.Columns["材料种类"].Visible = false;
            dgvMaterialTest.Columns["材料名称"].Visible = false;
            dgvMaterialTest.Columns["材料规格"].Visible = false;
            dgvMaterialTest.Columns["当日进货量"].Visible = false;
            dgvMaterialTest.Columns["累计进货量"].Visible = false;
            dgvMaterialTest.Columns["录入时间"].Visible = false;
            dgvMaterialTest.Columns["录入人员"].Visible = false;
            dgvMaterialTest.Columns["实际频率"].Visible = false;

            dgvMaterialTest.Columns["试验编号"].ReadOnly = true;
            dgvMaterialTest.Columns["试验名称"].ReadOnly = true;
            dgvMaterialTest.Columns["试验员"].ReadOnly = true;

            tbMAccountDate.Text = dateTimePicker1.Value.ToShortDateString();

            SetMaterialKindList();
            SetMaterialNameList();
            SetMaterialModelList();

            //设置“当日进货量”和“累计进货量”
            SetMaterialQuantity();

        }

        //材料方法：“材料种类”下拉列表设置
        private void SetMaterialKindList()
        {
            cbxMaterialKind.DataSource = kindNameModel.GetMaterialKind();
            cbxMaterialKind.ValueMember = "id";
            cbxMaterialKind.DisplayMember = "sort";
        }

        //材料方法：“材料名称”下拉列表设置
        private void SetMaterialNameList()
        {
            DataTable dt = kindNameModel.GetMaterialName(Convert.ToInt64(cbxMaterialKind.SelectedValue.ToString()));
            if (dt.Rows.Count == 0)
            {
                cbxMaterialName.DataSource = null;
            }
            else
            {
                cbxMaterialName.DataSource = dt;
                cbxMaterialName.ValueMember = "id";
                cbxMaterialName.DisplayMember = "name";
            }
        }

        //材料方法：“材料规格”下拉列表设置
        private void SetMaterialModelList()
        {
            if (cbxMaterialName.SelectedValue == null)
            {
                cbxMaterialModel.DataSource = null;
            }
            else
            {
                DataTable dt = kindNameModel.GetMaterialModel(Convert.ToInt64(cbxMaterialName.SelectedValue.ToString()));
                if (dt.Rows.Count == 0)
                {
                    cbxMaterialModel.DataSource = null;
                }
                else
                {
                    cbxMaterialModel.DataSource = dt;
                    cbxMaterialModel.ValueMember = "id";
                    cbxMaterialModel.DisplayMember = "model";
                }
                
            }
        }

        //材料方法：保存“材料试验台帐”
        private void SaveMaterialTestAccount()
        {
            //获得 指定日期的相应材料的试验台帐信息
            DataTable materialTable = (DataTable)(dgvMaterialTest.DataSource);
            
            //材料Id
            long mId = GetMaterialId(cbxMaterialName, cbxMaterialModel);

            //当日进货量
            double dayQuantity = 0;
            if (tbMDayQuantity.Text != "")
            {
                dayQuantity = Convert.ToDouble(tbMDayQuantity.Text);
            }

            //累计进货量
            double totalQuantity = 0;
            if (tbMTotalQuantity.Text != "")
            {
                totalQuantity = Convert.ToDouble(tbMTotalQuantity.Text);
            }


            foreach (DataRow row in materialTable.Rows)
            {
                row["mId"] = mId;
                row["当日进货量"] = dayQuantity;
                row["累计进货量"] = totalQuantity;
                row["台帐日期"] = tbMAccountDate.Text;
                row["实际频率"] = detectingRecordsDB.GetMaterialFrequency(mId,row["试验名称"].ToString(),tbMAccountDate.Text);
                row["录入人员"] = this.UserName;
            }



            //保存 指定日期的相应材料的试验台帐信息
            detectingRecordsDB.SaveMartialTestAccount(materialTable);

            //重置TpMaterial内的控件为初始状态，以便下一次更新
            InitialTpMaterial();


            //刷新 指定日期的所有材料的试验台帐信息——dgvMaterialTestAccount内的数据
            dgvMaterialTestAccount.DataSource = detectingRecordsDB.GetMaterialTestAccount(dateTimePicker1.Value);

        }

        //材料方法：复制“材料台帐”DataGridView选中的记录到相应TAB页内的DataGridView
        private void MaterialCopyRow(DataGridView dgvSource, DataGridView dgvDest)
        {
            DataTable dtTest = (DataTable)dgvDest.DataSource;
            DataRow row;


            //清空台帐编辑处内的数据
            MoveOut();
            if (dtTest != null)
            {
                dtTest.Clear();
            }

            //将材料台帐所选中的行复制到编辑处，用于编辑
            foreach (DataGridViewRow dr in dgvSource.SelectedRows)
            {
                row = dtTest.NewRow();

                row["id"] = Convert.ToInt64(dr.Cells["id"].Value.ToString());
                row["mId"] = Convert.ToInt64(dr.Cells["mId"].Value.ToString()); ;
                row["台帐日期"] = dr.Cells["台帐日期"].Value.ToString();
                row["mkId"] = Convert.ToInt64(dr.Cells["mkId"].Value.ToString());
                row["材料种类"] = dr.Cells["材料种类"].Value.ToString();
                row["mnId"] = Convert.ToInt64(dr.Cells["mnId"].Value.ToString());
                row["材料名称"] = dr.Cells["材料名称"].Value.ToString();
                row["mmId"] = Convert.ToInt64(dr.Cells["mmId"].Value.ToString());
                row["材料规格"] = dr.Cells["材料规格"].Value.ToString();
                row["当日进货量"] = Convert.ToDouble(dr.Cells["当日进货量"].Value.ToString());
                row["累计进货量"] = Convert.ToDouble(dr.Cells["累计进货量"].Value.ToString());
                row["试验编号"] = dr.Cells["试验编号"].Value.ToString();
                row["试验名称"] = dr.Cells["试验名称"].Value.ToString();
                row["试验员"] = dr.Cells["试验员"].Value.ToString();
                row["试验结果"] = dr.Cells["试验结果"].Value.ToString();
                row["是否合格"] = dr.Cells["是否合格"].Value.ToString();
                row["实际频率"] = dr.Cells["实际频率"].Value.ToString();
                row["备注"] = dr.Cells["备注"].Value.ToString();
                row["录入时间"] = dr.Cells["录入时间"].Value.ToString();
                row["录入人员"] = dr.Cells["录入人员"].Value.ToString();

                dtTest.Rows.Add(row);

                //将row的状态从“Added”为“Modified”,为生成“update”SQL语句做准备
                row.AcceptChanges();
                row.SetModified();


                //根据所选中的材料台帐，显示对应的“材料种类”
                cbxMaterialKind.SelectedValue = Convert.ToInt64(dr.Cells["mkId"].Value.ToString());
                //根据相应的“材料种类”设置“材料名称”下拉列表
                SetMaterialNameList();


                //根据所选中的材料台帐，显示对应的“材料名称”
                cbxMaterialName.SelectedValue = Convert.ToInt64(dr.Cells["mnId"].Value.ToString());
                //根据相应的“材料名称”设置“材料规格”下拉列表
                SetMaterialModelList();


                //根据所选中的材料台帐，显示对应的“材料规格”
                cbxMaterialModel.SelectedValue = Convert.ToInt64(dr.Cells["mmId"].Value.ToString());
            }
        }

        //材料方法：设置“当日进货量”和“累计进货量”
        private void SetMaterialQuantity()
        {
            long mId = GetMaterialId(cbxMaterialName, cbxMaterialModel);

            tbMDayQuantity.Text = detectingRecordsDB.GetMaterialDayQuantity(mId, dateTimePicker1.Value).ToString();
            tbMTotalQuantity.Text = detectingRecordsDB.GetMaterialTotalQuantity(mId).ToString();
        }

        //材料方法：获得“材料id”
        private long GetMaterialId(ComboBox materialName,ComboBox materialModel)
        {
            long mnId = 0;
            if (materialName.SelectedValue != null)
            {
                mnId = Convert.ToInt64(materialName.SelectedValue.ToString());
            }

            long mmId = 0;
            if (materialModel.SelectedValue != null)
            {
                mmId = Convert.ToInt64(materialModel.SelectedValue.ToString());
            }


            long mId = kindNameModel.GetMaterialId(mnId, mmId);
            return mId;
        }


        #endregion

        

        #region //关于“产品”的窗体事件与处理方法

        //产品事件：“产品种类”下拉控件，选中值变化事件
        private void cbxProductKind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetProductNameList();
            SetProductModelList();
            
            SetProductQuantity();           
        }

        //产品事件：“产品名称”下拉控件，选中值变化事件
        private void cbxProductName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetProductModelList();

            SetProductQuantity();
        }

        //产品事件：“产品规格”下拉控件，选中值变化事件        
        private void cbxProductModel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetProductQuantity();
        }

        //产品事件：“保存按钮”点击
        private void button2_Click(object sender, EventArgs e)
        {
            SaveProductTestAccount();
        }

        //产品事件：“材料台帐”记录选中事件
        private void dgvProductTestAccount_SelectionChanged(object sender, EventArgs e)
        {
            ProductCopyRow(dgvProductTestAccount, dgvProductTest);
        }



        //产品方法：初始化“产品”tab标签（tpProduct）
        private void InitialTpProduct()
        {
            tbPAccountDate.Text = dateTimePicker1.Value.ToShortDateString();

            dgvProductTest.DataSource = detectingRecordsDB.GetProductTestAccount(dateTimePicker1.Value);
            ((DataTable)dgvProductTest.DataSource).Clear();
            dgvProductTest.Columns["id"].Visible = false;
            dgvProductTest.Columns["pId"].Visible = false;
            dgvProductTest.Columns["pkId"].Visible = false;
            dgvProductTest.Columns["pnId"].Visible = false;
            dgvProductTest.Columns["pmId"].Visible = false;
            dgvProductTest.Columns["台帐日期"].Visible = false;
            dgvProductTest.Columns["产品种类"].Visible = false;
            dgvProductTest.Columns["产品名称"].Visible = false;
            dgvProductTest.Columns["产品规格"].Visible = false;
            dgvProductTest.Columns["当日产量"].Visible = false;
            dgvProductTest.Columns["累计产量"].Visible = false;
            dgvProductTest.Columns["录入时间"].Visible = false;
            dgvProductTest.Columns["录入人员"].Visible = false;
            dgvProductTest.Columns["实际频率"].Visible = false;


            dgvProductTest.Columns["试验编号"].ReadOnly = true;
            dgvProductTest.Columns["试验名称"].ReadOnly = true;
            dgvProductTest.Columns["试验员"].ReadOnly = true;


            SetProductKindList();
            SetProductNameList();
            SetProductModelList();

            //设置“当日产量”和“累计产量”
            SetProductQuantity();
        }

        //产品方法：“材料种类”下拉列表设置
        private void SetProductKindList()
        {
            cbxProductKind.DataSource = kindNameModel.GetProductKind();
            cbxProductKind.ValueMember = "id";
            cbxProductKind.DisplayMember = "sort";
        }

        //产品方法：“材料名称”下拉列表设置
        private void SetProductNameList()
        {
            DataTable dt = kindNameModel.GetProductName(Convert.ToInt64(cbxProductKind.SelectedValue.ToString()));
            if (dt.Rows.Count == 0)
            {
                cbxProductName.DataSource = null;
            }
            else
            {
                cbxProductName.DataSource = dt;
                cbxProductName.ValueMember = "id";
                cbxProductName.DisplayMember = "name";
            }
        }

        //产品方法：“材料规格”下拉列表设置
        private void SetProductModelList()
        {
            if (cbxProductName.SelectedValue == null)
            {
                cbxProductModel.DataSource = null;
            }
            else
            {
                DataTable dt = kindNameModel.GetProductModel(Convert.ToInt64(cbxProductName.SelectedValue.ToString()));
                if (dt.Rows.Count == 0)
                {
                    cbxProductModel.DataSource = null;
                }
                else
                {
                    cbxProductModel.DataSource = dt;
                    cbxProductModel.ValueMember = "id";
                    cbxProductModel.DisplayMember = "model";
                }

            }
        }

        //产品方法：保存“材料试验台帐”
        private void SaveProductTestAccount()
        {
            //获得 指定日期的相应产品的试验台帐信息
            DataTable productTable = (DataTable)(dgvProductTest.DataSource);
            
            //产品Id
            long pId = GetProductId(cbxProductName, cbxProductModel); 

            //当日产量
            double dayQuantity = 0;
            if (tbPDayQuantity.Text != "")
            {
                dayQuantity = Convert.ToDouble(tbPDayQuantity.Text);
            }


            //累计产量
            double totalQuantity = 0;
            if (tbPTotalQuantity.Text != "")
            {
                totalQuantity = Convert.ToDouble(tbPTotalQuantity.Text);
            }

            foreach (DataRow row in productTable.Rows)
            {
                row["pId"] = pId;
                row["当日产量"] = dayQuantity;
                row["累计产量"] = totalQuantity;
                row["台帐日期"] = tbPAccountDate.Text;
                row["实际频率"] = detectingRecordsDB.GetProductFrequency(pId, row["试验名称"].ToString(), tbPAccountDate.Text);
                row["录入人员"] = this.UserName;
            }



            //保存 指定日期的相应产品的试验台帐信息
            detectingRecordsDB.SaveProductTestAccount(productTable);

            //重置TpProduct内的控件为初始状态，以便下一次更新
            InitialTpProduct();


            //刷新 指定日期的所有产品的试验台帐信息——dgvProductTestAccount内的数据
            dgvProductTestAccount.DataSource = detectingRecordsDB.GetProductTestAccount(dateTimePicker1.Value);

        }

        //产品方法：复制“产品台帐”DataGridView选中的记录到相应TAB页内的DataGridView
        private void ProductCopyRow(DataGridView dgvSource, DataGridView dgvDest)
        {
            DataTable dtTest = (DataTable)dgvDest.DataSource;
            DataRow row;


            //清空台帐编辑处内的数据
            MoveOut();
            if (dtTest != null)
            {
                dtTest.Clear();
            }

            //将材料台帐所选中的行复制到编辑处，用于编辑
            foreach (DataGridViewRow dr in dgvSource.SelectedRows)
            {
                row = dtTest.NewRow();

                row["id"] = dr.Cells["id"].Value.ToString();
                row["pId"] = Convert.ToInt64(dr.Cells["pId"].Value.ToString()); ;
                row["台帐日期"] = dr.Cells["台帐日期"].Value.ToString();
                row["pkId"] = Convert.ToInt64(dr.Cells["pkId"].Value.ToString());
                row["产品种类"] = dr.Cells["产品种类"].Value.ToString();
                row["pnId"] = Convert.ToInt64(dr.Cells["pnId"].Value.ToString());
                row["产品名称"] = dr.Cells["产品名称"].Value.ToString();
                row["pmId"] = Convert.ToInt64(dr.Cells["pmId"].Value.ToString());
                row["产品规格"] = dr.Cells["产品规格"].Value.ToString();
                row["当日产量"] = Convert.ToDouble(dr.Cells["当日产量"].Value.ToString());
                row["累计产量"] = Convert.ToDouble(dr.Cells["累计产量"].Value.ToString());
                row["试验编号"] = dr.Cells["试验编号"].Value.ToString();
                row["试验名称"] = dr.Cells["试验名称"].Value.ToString();
                row["试验员"] = dr.Cells["试验员"].Value.ToString();
                row["试验结果"] = dr.Cells["试验结果"].Value.ToString();
                row["是否合格"] = dr.Cells["是否合格"].Value.ToString();
                row["实际频率"] = dr.Cells["实际频率"].Value.ToString();
                row["备注"] = dr.Cells["备注"].Value.ToString();
                row["录入时间"] = dr.Cells["录入时间"].Value.ToString();
                row["录入人员"] = dr.Cells["录入人员"].Value.ToString();

                dtTest.Rows.Add(row);

                //将row的状态从“Added”为“Modified”,为生成“update”SQL语句做准备
                row.AcceptChanges();
                row.SetModified();


                //根据所选中的材料台帐，显示对应的“材料种类”
                cbxProductKind.SelectedValue = Convert.ToInt64(dr.Cells["pkId"].Value.ToString());
                //根据相应的“材料种类”设置“材料名称”下拉列表
                SetProductNameList();


                //根据所选中的材料台帐，显示对应的“材料名称”
                cbxProductName.SelectedValue = Convert.ToInt64(dr.Cells["pnId"].Value.ToString());
                //根据相应的“材料名称”设置“材料规格”下拉列表
                SetProductModelList();


                //根据所选中的材料台帐，显示对应的“材料规格”
                cbxProductModel.SelectedValue = Convert.ToInt64(dr.Cells["pmId"].Value.ToString());
            }
        }

        //产品方法：设置“当日产量”和“累计产量”
        private void SetProductQuantity()
        {
            long pId = GetProductId(cbxProductName, cbxProductModel);

            tbPDayQuantity.Text = detectingRecordsDB.GetProductDayQuantity(pId, dateTimePicker1.Value).ToString();
            tbPTotalQuantity.Text = detectingRecordsDB.GetProductTotalQuantity(pId).ToString();
        }

        //产品方法：获得“产品id”
        private long GetProductId(ComboBox productName, ComboBox productModel)
        {
            long pnId = 0;
            if (productName.SelectedValue != null)
            {
                pnId = Convert.ToInt64(productName.SelectedValue.ToString());
            }

            long pmId = 0;
            if (productModel.SelectedValue != null)
            {
                pmId = Convert.ToInt64(productModel.SelectedValue.ToString());
            }


            long pId = kindNameModel.GetProductId(pnId, pmId);
            return pId;
        }


        #endregion

        private void btn_PrintM_Click(object sender, EventArgs e)
        {
            if (dgvMaterialTestAccount.Rows.Count > 0)
            {
                DateTime id = dateTimePicker1.Value;

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.MaterialTestAccountDataSetTableAdapters.materialTestAccountTableAdapter", "materialTestAccount", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.MaterialTestAccountDataSet";
                reportData.ReportName = "DasherStation.Report.MaterialTestAccountReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }

        private void btn_PrintP_Click(object sender, EventArgs e)
        {
            if (dgvMaterialTestAccount.Rows.Count > 0)
            {
                DateTime id = dateTimePicker1.Value;

                ReportHelper reportServer = new ReportHelper();
                ReportData reportData = new ReportData();
                List<ReportSource> reportSourceList = new List<ReportSource>();

                reportSourceList.Add(reportServer.CreatReportSource("DasherStation.dataSet.ProductTestAccountDataSetTableAdapters.productTestAccountTableAdapter", "productTestAccount", new object[] { id }));

                reportData.DataSetName = "DasherStation.dataSet.ProductTestAccountDataSet";
                reportData.ReportName = "DasherStation.Report.ProductTestAccountReport.rdlc";

                reportData.ReportSourceList = reportSourceList;

                reportServer.ShowReport(reportData);
            }
        }


    }
}
