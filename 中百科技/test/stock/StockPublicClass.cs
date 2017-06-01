/*
     * 版权单位：沈阳中百科技有限公司
     *
     * 文件名：采购计划实体类
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
using System.Linq;


namespace DasherStation.stock
{
    class StockPublicClass
    {

    }

    public class StockPlanClass//采购计划
    {
        #region//采购计划
        private long s_id;

        private DateTime? s_inputDate;

        private string s_inputMan;

        private string s_producer;

        private string s_assessor;

        private string s_checkupMan;

        private string s_planYear;

        private string s_remark;

        public long id
        {
            get
            {
                return this.s_id;
            }
            set
            {
                this.s_id = value;
            }
        }

        public DateTime? inputDate
        {
            get
            {
                return this.s_inputDate;
            }
            set
            {
                this.s_inputDate = value;
            }
        }

        public string inputMan
        {
            get
            {
                return this.s_inputMan;
            }
            set
            {
                this.s_inputMan = value;
            }
        }

        public string producer
        {
            get
            {
                return this.s_producer;
            }
            set
            {
                this.s_producer = value;
            }
        }

        public string assessor
        {
            get
            {
                return this.s_assessor;
            }
            set
            {
                this.s_assessor = value;
            }
        }

        public string checkupMan
        {
            get
            {
                return this.s_checkupMan;
            }
            set
            {
                this.s_checkupMan = value;
            }
        }

        public string planYear
        {
            get
            {
                return this.s_planYear;
            }
            set
            {
                this.s_planYear = value;
            }
        }

        public string remark
        {
            get
            {
                return this.s_remark;
            }
            set
            {
                this.s_remark = value;
            }
        }
        #endregion

    }
    public class StockPlanDetailClass//采购计划明细
    {
        #region//采购计划明细类
        private long s_id;

        private long s_mId;

        private long s_spId;

        private decimal? s_quantity;

        private decimal? s_january;

        private decimal? s_february;

        private decimal? s_march;

        private decimal? s_april;

        private decimal? s_may;

        private decimal? s_june;

        private decimal? s_july;

        private decimal? s_august;

        private decimal? s_september;

        private decimal? s_october;

        private decimal? s_november;

        private decimal? s_december;

        private string s_remark;

        private DateTime? s_inputDate;

        public long id
        {
            get
            {
                return this.s_id;
            }
            set
            {
                this.s_id = value;
            }
        }

        public long mId
        {
            get
            {
                return this.s_mId;
            }
            set
            {
                this.s_mId = value;
            }
        }

        public long spId
        {
            get
            {
                return this.s_spId;
            }
            set
            {
                this.s_spId = value;
            }
        }

        public decimal? quantity
        {
            get
            {
                return this.s_quantity;
            }
            set
            {
                this.s_quantity = value;
            }
        }

        public decimal? january
        {
            get
            {
                return this.s_january;
            }
            set
            {
                this.s_january = value;
            }
        }

        public decimal? february
        {
            get
            {
                return this.s_february;
            }
            set
            {
                this.s_february = value;
            }
        }

        public decimal? march
        {
            get
            {
                return this.s_march;
            }
            set
            {
                this.s_march = value;
            }
        }

        public decimal? april
        {
            get
            {
                return this.s_april;
            }
            set
            {
                this.s_april = value;
            }
        }

        public decimal? may
        {
            get
            {
                return this.s_may;
            }
            set
            {
                this.s_may = value;
            }
        }

        public decimal? june
        {
            get
            {
                return this.s_june;
            }
            set
            {
                this.s_june = value;
            }
        }

        public decimal? july
        {
            get
            {
                return this.s_july;
            }
            set
            {
                this.s_july = value;
            }
        }

        public decimal? august
        {
            get
            {
                return this.s_august;
            }
            set
            {
                this.s_august = value;
            }
        }

        public decimal? september
        {
            get
            {
                return this.s_september;
            }
            set
            {
                this.s_september = value;
            }
        }

        public decimal? october
        {
            get
            {
                return this.s_october;
            }
            set
            {
                this.s_october = value;
            }
        }

        public decimal? november
        {
            get
            {
                return this.s_november;
            }
            set
            {
                this.s_november = value;
            }
        }

        public decimal? december
        {
            get
            {
                return this.s_december;
            }
            set
            {
                this.s_december = value;
            }
        }

        public string remark
        {
            get
            {
                return this.s_remark;
            }
            set
            {
                this.s_remark = value;
            }
        }

        public DateTime? inputDate
        {
            get
            {
                return this.s_inputDate;
            }
            set
            {
                this.s_inputDate = value;
            }
        }
        #endregion


        internal int? GetObj()
        {
            throw new NotImplementedException();
        }
    }
    public class MaterialClass//材料
    {
        #region//材料类
        private long? s_id;

        private long? s_mnId;

        private long? s_mmId;

        private DateTime? s_inputDate;

        private string s_density;

        private string s_inputMan;

        private string s_remark;

        public long? id
        {
            get
            {
                return this.s_id;
            }
            set
            {
                this.s_id = value;
            }
        }

        public long? mnId
        {
            get
            {
                return this.s_mnId;
            }
            set
            {
                this.s_mnId = value;
            }
        }

        public long? mmId
        {
            get
            {
                return this.s_mmId;
            }
            set
            {
                this.s_mmId = value;
            }
        }

        public DateTime? inputDate
        {
            get
            {
                return this.s_inputDate;
            }
            set
            {
                this.s_inputDate = value;
            }
        }

        public string density
        {
            get
            {
                return this.s_density;
            }
            set
            {
                this.s_density = value;
            }
        }

        public string inputMan
        {
            get
            {
                return this.s_inputMan;
            }
            set
            {
                this.s_inputMan = value;
            }
        }

        public string remark
        {
            get
            {
                return this.s_remark;
            }
            set
            {
                this.s_remark = value;
            }
        }
        #endregion
    }
    public class MaterialKind//材料种类
    {
        #region //材料种类
        private long s_id;
        private string s_sort;
        private DateTime? s_inputdate;
        private string s_inputman;
        private string s_remark;
        /// <summary>
        /// 
        /// </summary>
        public long id
        {
            set { s_id = value; }
            get { return s_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sort
        {
            set { s_sort = value; }
            get { return s_sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? inputDate
        {
            set { s_inputdate = value; }
            get { return s_inputdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string inputMan
        {
            set { s_inputman = value; }
            get { return s_inputman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { s_remark = value; }
            get { return s_remark; }
        }
        #endregion
    }
    public class MaterialName//材料名称
    {
        #region //材料名称
        private long s_id;
        private string s_name;
        private int? s_mkid;
        private DateTime? s_inputdate;
        private string s_inputman;
        private string s_remark;
        /// <summary>
        /// 
        /// </summary>
        public long id
        {
            set { s_id = value; }
            get { return s_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { s_name = value; }
            get { return s_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? mkId
        {
            set { s_mkid = value; }
            get { return s_mkid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? inputDate
        {
            set { s_inputdate = value; }
            get { return s_inputdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string inputMan
        {
            set { s_inputman = value; }
            get { return s_inputman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { s_remark = value; }
            get { return s_remark; }
        }
        #endregion
    }
    public class MaterialModel//材料规格
    {
        #region //材料规格
        private long s_id;
        private string s_model;
        private DateTime? s_inputdate;
        private string s_inputman;
        private string s_remark;
        /// <summary>
        /// 
        /// </summary>
        public long id
        {
            set { s_id = value; }
            get { return s_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string model
        {
            set { s_model = value; }
            get { return s_model; }
        }
        /// <summary>
        /// 
        /// </summary>       
        public DateTime? inputDate
        {
            set { s_inputdate = value; }
            get { return s_inputdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string inputMan
        {
            set { s_inputman = value; }
            get { return s_inputman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { s_remark = value; }
            get { return s_remark; }
        }
        #endregion

    }

    public class stockContract//采购合同
    {
        public stockContract()
        { }
        #region 采购合同
        private long _id;
        private string _name;
        private string _no;
        private long _piid;
        private string _producer;
        private decimal? _sum;
        private DateTime? _inputdate;
        private string _squaremode;
        private string _inputman;
        private string _assessor;
        private string _checkupman;
        private long? _parentid;
        private string _remark;
        private DateTime? _startdate;
        private DateTime? _enddate;
        private decimal? _minquantity;
        private string _conveyancer;
        private string _no2;
        private bool _finishmark;
        /// <summary>
        /// 
        /// </summary>
        public long id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string no
        {
            set { _no = value; }
            get { return _no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long piId
        {
            set { _piid = value; }
            get { return _piid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string producer
        {
            set { _producer = value; }
            get { return _producer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? sum
        {
            set { _sum = value; }
            get { return _sum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? inputDate
        {
            set { _inputdate = value; }
            get { return _inputdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string squareMode
        {
            set { _squaremode = value; }
            get { return _squaremode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string inputMan
        {
            set { _inputman = value; }
            get { return _inputman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string assessor
        {
            set { _assessor = value; }
            get { return _assessor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string checkupMan
        {
            set { _checkupman = value; }
            get { return _checkupman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? parentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? startDate
        {
            set { _startdate = value; }
            get { return _startdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? endDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? minQuantity
        {
            set { _minquantity = value; }
            get { return _minquantity; }
        }
        /// <summary>
        /// 运输方
        /// </summary>
        public string conveyancer
        {
            set { _conveyancer = value; }
            get { return _conveyancer; }
        }
        public string no2
        {
            set { _no2 = value; }
            get { return this._no2; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool finishMark
        {
            set { _finishmark = value; }
            get { return _finishmark; }
        }
        #endregion Model
    }
    public class Indent//采购合同明细
    {
        public Indent()
        { }
        #region 采购合同明细
        private long _id;
        private long? _mid;
        private decimal? _quantity;
        private decimal? _unitprice;
        private string _inputman;
        private DateTime? _inputdate;
        private bool _finishmark;
        private long _scid;
        /// <summary>
        /// 
        /// </summary>
        public long id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? mId
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? unitPrice
        {
            set { _unitprice = value; }
            get { return _unitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string inputMan
        {
            set { _inputman = value; }
            get { return _inputman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? inputDate
        {
            set { _inputdate = value; }
            get { return _inputdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool finishMark
        {
            set { _finishmark = value; }
            get { return _finishmark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long scId
        {
            set { _scid = value; }
            get { return _scid; }
        }
        #endregion 采购合同明细

    }

    public class stockMaterialSettlement//采购核算表
    {
        private long s_id;

        private float s_totalWeight;

        private long s_scId;

        private decimal s_sum;

        private System.DateTime s_inputDate;

        private string s_inputMan;

        private string s_remark;

        private int s_count;

        public long id
        {
            get
            {
                return this.s_id;
            }
            set
            {
                this.s_id = value;
            }
        }

        public float totalWeight
        {
            get
            {
                return this.s_totalWeight;
            }
            set
            {
                this.s_totalWeight = value;
            }
        }

        public long scId
        {
            get
            {
                return this.s_scId;
            }
            set
            {
                this.s_scId = value;
            }
        }

        public decimal sum
        {
            get
            {
                return this.s_sum;
            }
            set
            {
                this.s_sum = value;
            }
        }

        public System.DateTime inputDate
        {
            get
            {
                return this.s_inputDate;
            }
            set
            {
                this.s_inputDate = value;
            }
        }

        public string inputMan
        {
            get
            {
                return this.s_inputMan;
            }
            set
            {
                this.s_inputMan = value;
            }
        }

        public string remark
        {
            get
            {
                return this.s_remark;
            }
            set
            {
                this.s_remark = value;
            }
        }

        public int count
        {
            get
            {
                return this.s_count;
            }
            set
            {
                this.s_count = value;
            }
        }
    }

    public class stockMaterialSettlementDetail//采购核算明细表
    {
        private long s_id;

        private long s_smsId;

        private long s_iId;

        private int s_count;

        private decimal s_sum;

        private System.DateTime s_inputDate;

        private string s_inputMan;

        public long id
        {
            get
            {
                return this.s_id;
            }
            set
            {
                this.s_id = value;
            }
        }

        public long smsId
        {
            get
            {
                return this.s_smsId;
            }
            set
            {
                this.s_smsId = value;
            }
        }

        public long iId
        {
            get
            {
                return this.s_iId;
            }
            set
            {
                this.s_iId = value;
            }
        }

        public int count
        {
            get
            {
                return this.s_count;
            }
            set
            {
                this.s_count = value;
            }
        }

        public decimal sum
        {
            get
            {
                return this.s_sum;
            }
            set
            {
                this.s_sum = value;
            }
        }

        public System.DateTime inputDate
        {
            get
            {
                return this.s_inputDate;
            }
            set
            {
                this.s_inputDate = value;
            }
        }

        public string inputMan
        {
            get
            {
                return this.s_inputMan;
            }
            set
            {
                this.s_inputMan = value;
            }
        }
    }

    public class stockMaterialNoteCorresponding//采购票据对应表
    {
        private long s_id;

        private long s_smsdId;

        private long s_snId;

        private System.DateTime s_inputDate;

        private string s_inputMan;

        public long id
        {
            get
            {
                return this.s_id;
            }
            set
            {
                this.s_id = value;
            }
        }

        public long smsdId
        {
            get
            {
                return this.s_smsdId;
            }
            set
            {
                this.s_smsdId = value;
            }
        }

        public long snId
        {
            get
            {
                return this.s_snId;
            }
            set
            {
                this.s_snId = value;
            }
        }

        public System.DateTime inputDate
        {
            get
            {
                return this.s_inputDate;
            }
            set
            {
                this.s_inputDate = value;
            }
        }

        public string inputMan
        {
            get
            {
                return this.s_inputMan;
            }
            set
            {
                this.s_inputMan = value;
            }
        }
    }
}
