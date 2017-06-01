using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DasherStation.transport
{
    class TransportPublicClass
    {
    }

    public class TransportContract
    {
        public TransportContract()
        { }
        #region Model
        private long _id;
        private string _contractname;
        private string _no;
        private long? _tuid;
        private DateTime? _contractinkdate;
        private DateTime? _contractstartdate;
        private DateTime? _contractenddate;
        private DateTime? _inputdate;
        private string _inputman;
        private string _assessor;
        private string _checkupman;
        private bool _mark;
        private string _remark;
        private long? parentId;

        public long? ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }
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
        public string contractName
        {
            set { _contractname = value; }
            get { return _contractname; }
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
        public long? tuId
        {
            set { _tuid = value; }
            get { return _tuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? contractInkDate
        {
            set { _contractinkdate = value; }
            get { return _contractinkdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? contractStartDate
        {
            set { _contractstartdate = value; }
            get { return _contractstartdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? contractEndDate
        {
            set { _contractenddate = value; }
            get { return _contractenddate; }
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
        public bool mark
        {
            set { _mark = value; }
            get { return _mark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }


        #endregion Model

    }//运输合同类

    public class TransportGoodsInformationCorresponding
    {
        public TransportGoodsInformationCorresponding()
        { }
        #region Model
        private long _id;
        private long? _tcid;
        private long? _mid;
        private long? _pid;
        private long? _sid1;
        private long? _sid2;
        private decimal? _distance;
        private DateTime? _inputdate;
        private string _inputman;
        private decimal? _price;
        private long? _tsmid;
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
        public long? tcId
        {
            set { _tcid = value; }
            get { return _tcid; }
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
        public long? pId
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? sId1
        {
            set { _sid1 = value; }
            get { return _sid1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? sId2
        {
            set { _sid2 = value; }
            get { return _sid2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? distance
        {
            set { _distance = value; }
            get { return _distance; }
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
        public string inputMan
        {
            set { _inputman = value; }
            get { return _inputman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? tsmId
        {
            set { _tsmid = value; }
            get { return _tsmid; }
        }
        #endregion Model

    }//运输合同明细实体类

    /// <summary>
    /// 实体类transportSettlement 。(运输核算表)
    /// </summary>
    public class TransportSettlement
    {
        public TransportSettlement()
        { }
        #region Model
        private long _id;
        private decimal? _totalweight;
        private long? _tcid;
        private decimal? _sum;
        private DateTime? _inputdate;
        private string _inputman;
        private int? _count;
        private string _remark;
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
        public decimal? totalWeight
        {
            set { _totalweight = value; }
            get { return _totalweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? tcId
        {
            set { _tcid = value; }
            get { return _tcid; }
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
        public string inputMan
        {
            set { _inputman = value; }
            get { return _inputman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? count
        {
            set { _count = value; }
            get { return _count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }

    /// <summary>
    /// 实体类transportSettlementDetail 。(运输核算明细表)
    /// </summary>
    public class TransportSettlementDetail
    {
        public TransportSettlementDetail()
        { }
        #region Model
        private long _id;
        private long? _tsid;
        private long? _tgicid;
        private int? _count;
        private decimal? _sum;
        private DateTime? _inputdate;
        private string _inputman;
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
        public long? tsId
        {
            set { _tsid = value; }
            get { return _tsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? tgicId
        {
            set { _tgicid = value; }
            get { return _tgicid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? count
        {
            set { _count = value; }
            get { return _count; }
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
        public string inputMan
        {
            set { _inputman = value; }
            get { return _inputman; }
        }
        #endregion Model

    }

    /// <summary>
    /// 实体类transportNoteCorresponding 。(运输票据对应表)
    /// </summary>
    public class TransportNoteCorresponding
    {
        public TransportNoteCorresponding()
        { }
        #region Model
        private long _id;
        private long? _tsdid;
        private long? _snid;
        private long? _cnid;
        private DateTime? _inputdate;
        private string _inputman;
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
        public long? tsdId
        {
            set { _tsdid = value; }
            get { return _tsdid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? snId
        {
            set { _snid = value; }
            get { return _snid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? cnId
        {
            set { _cnid = value; }
            get { return _cnid; }
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
        public string inputMan
        {
            set { _inputman = value; }
            get { return _inputman; }
        }
        #endregion Model

    }



}
