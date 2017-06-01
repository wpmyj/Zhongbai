using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DasherStation.produce
{
    class ProducePublicClass
    {
    }
    /*
      * 类名称：ProductionSchedule
      * 类功能描述：生产计划基本信息属性类
      *
      * 创建人：付中华
      * 创建时间：2009-2-25
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */

    public class productionSchedule
    {
        private int s_id;

        private string s_producer;

        private string s_assessor;

        private string s_checkupMan;

        private System.DateTime s_inputDate;

        private string s_inputMan;

        private string s_remark;

        private System.DateTime? s_produceTime;

        public int id
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

        public DateTime? produceTime
        {
            get
            {
                return this.s_produceTime;
            }
            set
            {
                this.s_produceTime = value;
            }

        }
    }
    /*
 * 类名称：ProductionScheduleDetail
 * 类功能描述：生产计划明细属性类
 *
 * 创建人：付中华
 * 创建时间：2009-2-25
 *
 * 修改人：
 * 修改时间：
 * 修改内容：
 *
 */
    public class productionScheduleDetail
    {
        private int id;

        private int pId;

        private int tpid;

        private double? producequantity;

        private System.DateTime inputdate;

        private string inputman;

        private double? january;

        private double? february;

        private double? march;

        private double? april;

        private double? may;

        private double? june;

        private double? july;

        private double? august;

        private double? september;

        private double? october;

        private double? november;

        private double? december;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public int Pid
        {
            get
            {
                return pId;
            }
            set
            {
                pId = value;
            }
        }


        public int Tpid
        {
            get
            {
                return tpid;
            }
            set
            {
                tpid = value;
            }
        }

        public double? Producequantity
        {
            get
            {
                return producequantity;
            }
            set
            {
                producequantity = value;
            }
        }

        public System.DateTime Inputdate
        {
            get
            {
                return inputdate;
            }
            set
            {
                inputdate = value;
            }
        }

        public string Inputman
        {
            get
            {
                return inputman;
            }
            set
            {
                inputman = value;
            }
        }

        public double? January
        {
            get
            {
                return january;
            }
            set
            {
                january = value;
            }
        }

        public double? February
        {
            get
            {
                return february;
            }
            set
            {
                february = value;
            }
        }

        public double? March
        {
            get
            {
                return march;
            }
            set
            {
                march = value;
            }
        }

        public double? April
        {
            get
            {
                return april;
            }
            set
            {
                april = value;
            }
        }

        public double? May
        {
            get
            {
                return may;
            }
            set
            {
                may = value;
            }
        }

        public double? June
        {
            get
            {
                return june;
            }
            set
            {
                june = value;
            }
        }

        public double? July
        {
            get
            {
                return july;
            }
            set
            {
                july = value;
            }
        }

        public double? August
        {
            get
            {
                return august;
            }
            set
            {
                august = value;
            }
        }

        public double? September
        {
            get
            {
                return september;
            }
            set
            {
                september = value;
            }
        }

        public double? October
        {
            get
            {
                return october;
            }
            set
            {
                october = value;
            }
        }

        public double? November
        {
            get
            {
                return november;
            }
            set
            {
                november = value;
            }
        }

        public double? December
        {
            get
            {
                return december;
            }
            set
            {
                december = value;
            }
        }
    }
    /*
 * 类名称：produceNotice
 * 类功能描述：生产通知单属性类
 *
 * 创建人：付中华
 * 创建时间：2009-2-25
 *
 * 修改人：
 * 修改时间：
 * 修改内容：
 *
 */
    /// <summary>
    /// 实体类produceNotice
    /// </summary>
    public class ProduceNotice
    {
        public ProduceNotice()
        { }
        #region Model
        private long _id;
        private long _spid;
        private decimal? _planquantity;
        private DateTime? _startdate;
        private long _ptid;
        private DateTime? _notifydate;
        private DateTime? _inputdate;
        private string _remark;
        private string _notifyman;
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
        public long spId
        {
            set { _spid = value; }
            get { return _spid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? planQuantity
        {
            set { _planquantity = value; }
            get { return _planquantity; }
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
        public long ptId
        {
            set { _ptid = value; }
            get { return _ptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? notifyDate
        {
            set { _notifydate = value; }
            get { return _notifydate; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string notifyMan
        {
            set { _notifyman = value; }
            get { return _notifyman; }
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
    /// 实体类sendProportion 。
    /// </summary>
    public class SendProportion
    {
        public SendProportion()
        { }
        #region Model
        private long _id;
        private string _inputman;
        private DateTime? _inputdate;
        private string _remark;
        private bool _confirm;
        private DateTime? _confirmdate;
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool confirm
        {
            set { _confirm = value; }
            get { return _confirm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? confirmDate
        {
            set { _confirmdate = value; }
            get { return _confirmdate; }
        }
        #endregion Model

    }

    /// <summary>
    /// 实体类produceSendProportionDetail 
    /// </summary>
    public class ProduceSendProportionDetail
    {
        public ProduceSendProportionDetail()
        { }
        #region Model
        private long _id;
        private long _ppid;
        private long _eiid;
        private long _spid;
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
        public long ppId
        {
            set { _ppid = value; }
            get { return _ppid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long eiId
        {
            set { _eiid = value; }
            get { return _eiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long spId
        {
            set { _spid = value; }
            get { return _spid; }
        }
        #endregion Model

    }

    /// <summary>
    /// 实体类targetSendProportionDetail 
    /// </summary>
    public class TargetSendProportionDetail
    {
        public TargetSendProportionDetail()
        { }
        #region Model
        private long _id;
        private long _tpid;
        private long _eiid;
        private long _spid;
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
        public long tpId
        {
            set { _tpid = value; }
            get { return _tpid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long eiId
        {
            set { _eiid = value; }
            get { return _eiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long spId
        {
            set { _spid = value; }
            get { return _spid; }
        }
        #endregion Model

    }

    /// <summary>
    /// 实体类sendProportionDetail 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class SendProportionDetail
    {
        public SendProportionDetail()
        { }
        #region Model
        private long _id;
        private long _pid;
        private long _eiid;
        private long _spid;
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
        public long pId
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long eiId
        {
            set { _eiid = value; }
            get { return _eiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long spId
        {
            set { _spid = value; }
            get { return _spid; }
        }
        #endregion Model

    }

    /// <summary>
    /// 实体类mixtureProduceLog 。(混合料生产记录)
    /// </summary>
    public class MixtureProduceLog
    {
        public MixtureProduceLog()
        { }
        #region Model
        private long _id;
        private DateTime? _startmachinetime;
        private long _pid;
        private long _tpid;
        private long _ppid;
        private long _eiid;
        private decimal? _quantity1;
        private decimal? _quantity2;
        private decimal? _quantity3;
        private DateTime? _inputdate;
        private string _inputman;
        private DateTime? _stopmachinetime;
        private DateTime? _producedate;
        private string _weather;
        private decimal? _coarsematerialhydratedrate;
        private decimal? _refinedmaterialhydratedrate;
        private decimal? _morningtemperature;
        private decimal? _noontemperature;
        private decimal? _nighttemperature;
        private long _ptid;
        private decimal? _total;
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
        public DateTime? startMachineTime
        {
            set { _startmachinetime = value; }
            get { return _startmachinetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long pId
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long tpId
        {
            set { _tpid = value; }
            get { return _tpid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ppId
        {
            set { _ppid = value; }
            get { return _ppid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long eiId
        {
            set { _eiid = value; }
            get { return _eiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity1
        {
            set { _quantity1 = value; }
            get { return _quantity1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity2
        {
            set { _quantity2 = value; }
            get { return _quantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity3
        {
            set { _quantity3 = value; }
            get { return _quantity3; }
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
        public DateTime? stopMachineTime
        {
            set { _stopmachinetime = value; }
            get { return _stopmachinetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? produceDate
        {
            set { _producedate = value; }
            get { return _producedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string weather
        {
            set { _weather = value; }
            get { return _weather; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? coarseMaterialHydratedRate
        {
            set { _coarsematerialhydratedrate = value; }
            get { return _coarsematerialhydratedrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? refinedMaterialHydratedRate
        {
            set { _refinedmaterialhydratedrate = value; }
            get { return _refinedmaterialhydratedrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? morningTemperature
        {
            set { _morningtemperature = value; }
            get { return _morningtemperature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? noonTemperature
        {
            set { _noontemperature = value; }
            get { return _noontemperature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? nightTemperature
        {
            set { _nighttemperature = value; }
            get { return _nighttemperature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ptId
        {
            set { _ptid = value; }
            get { return _ptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? total
        {
            set { _total = value; }
            get { return _total; }
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
    /// 实体类emulsificationAsphaltumProduceLog 。(乳化沥青生产记录)
    /// </summary>
    public class EmulsificationAsphaltumProduceLog
    {
        public EmulsificationAsphaltumProduceLog()
        { }
        #region Model
        private long _id;
        private long _eiid;
        private DateTime? _producedate;
        private DateTime? _startmachinetime;
        private DateTime? _stopmachinetime;
        private long _pid2;
        private long _pid;
        private decimal? _quantity1;
        private decimal? _quantity2;
        private long _ptid;
        private string _weather;
        private DateTime? _inputdate;
        private string _inputman;
        private string _remark;
        private decimal? _quantity3;
        private string _assessor;
        private string _checkupman;
        private DateTime? _assessdate;
        private DateTime? _checkupdate;
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
        public long eiId
        {
            set { _eiid = value; }
            get { return _eiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? produceDate
        {
            set { _producedate = value; }
            get { return _producedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? startMachineTime
        {
            set { _startmachinetime = value; }
            get { return _startmachinetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? stopMachineTime
        {
            set { _stopmachinetime = value; }
            get { return _stopmachinetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long pId2
        {
            set { _pid2 = value; }
            get { return _pid2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long pId
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity1
        {
            set { _quantity1 = value; }
            get { return _quantity1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity2
        {
            set { _quantity2 = value; }
            get { return _quantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ptId
        {
            set { _ptid = value; }
            get { return _ptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string weather
        {
            set { _weather = value; }
            get { return _weather; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity3
        {
            set { _quantity3 = value; }
            get { return _quantity3; }
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
        public DateTime? assessDate
        {
            set { _assessdate = value; }
            get { return _assessdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? checkupDate
        {
            set { _checkupdate = value; }
            get { return _checkupdate; }
        }
        #endregion Model

    }

    /// <summary>
    /// 实体类restructureAsphaltumProduceLog 。(改性沥青生产记录)
    /// </summary>
    public class RestructureAsphaltumProduceLog
    {
        public RestructureAsphaltumProduceLog()
        { }
        #region Model
        private long _id;
        private long _eiid;
        private DateTime? _producedate;
        private DateTime? _startmachinetime;
        private DateTime? _stopmachinetime;
        private long _pid2;
        private long _pid;
        private decimal? _quantity1;
        private decimal? _quantity2;
        private long _ptid;
        private string _weather;
        private DateTime? _inputdate;
        private string _inputman;
        private string _remark;
        private bool _computationmark;
        private decimal? _quantity3;
        private string _assessor;
        private string _checkupman;
        private DateTime? _assessdate;
        private DateTime? _checkupdate;
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
        public long eiId
        {
            set { _eiid = value; }
            get { return _eiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? produceDate
        {
            set { _producedate = value; }
            get { return _producedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? startMachineTime
        {
            set { _startmachinetime = value; }
            get { return _startmachinetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? stopMachineTime
        {
            set { _stopmachinetime = value; }
            get { return _stopmachinetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long pId2
        {
            set { _pid2 = value; }
            get { return _pid2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long pId
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity1
        {
            set { _quantity1 = value; }
            get { return _quantity1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity2
        {
            set { _quantity2 = value; }
            get { return _quantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ptId
        {
            set { _ptid = value; }
            get { return _ptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string weather
        {
            set { _weather = value; }
            get { return _weather; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool computationMark
        {
            set { _computationmark = value; }
            get { return _computationmark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity3
        {
            set { _quantity3 = value; }
            get { return _quantity3; }
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
        public DateTime? assessDate
        {
            set { _assessdate = value; }
            get { return _assessdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? checkupDate
        {
            set { _checkupdate = value; }
            get { return _checkupdate; }
        }
        #endregion Model

    }

    /// <summary>
    /// 实体类againCalefactionProduceLog 。(再加温生产日志)
    /// </summary>
    public class AgainCalefactionProduceLog
    {
        public AgainCalefactionProduceLog()
        { }
        #region Model
        private long _id;
        private DateTime? _producedate;
        private long _eiid;
        private DateTime? _startmachinetime;
        private DateTime? _stopmachinetime;
        private long _piid;
        private long _ptid;
        private string _weather;
        private DateTime? _inputdate;
        private string _inputman;
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
        public DateTime? produceDate
        {
            set { _producedate = value; }
            get { return _producedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long eiId
        {
            set { _eiid = value; }
            get { return _eiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? startMachineTime
        {
            set { _startmachinetime = value; }
            get { return _startmachinetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? stopMachineTime
        {
            set { _stopmachinetime = value; }
            get { return _stopmachinetime; }
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
        public long ptId
        {
            set { _ptid = value; }
            get { return _ptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string weather
        {
            set { _weather = value; }
            get { return _weather; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }

    /// <summary>
    /// 实体类dasherResourceConsumeDailyStatistics 。(拌合机能源消耗日报表)
    /// </summary>
    public class DasherResourceConsumeDailyStatistics
    {
        public DasherResourceConsumeDailyStatistics()
        { }
        #region Model
        private long? _id;
        private DateTime? _inputdate;
        private long? _eiid;
        private long? _pid;
        private decimal? _quantity;
        private decimal? _manhour;
        private decimal? _fuelwastage1;
        private decimal? _fuelwastage2;
        private long? _mid;
        private decimal? _consumerate1;
        private decimal? _consumerate2;
        private decimal? _consumecoulometry;
        private string _inputman;
        private DateTime? _producedate;

        public DateTime? Producedate
        {
            get { return _producedate; }
            set { _producedate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? id
        {
            set { _id = value; }
            get { return _id; }
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
        public long? eiId
        {
            set { _eiid = value; }
            get { return _eiid; }
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
        public decimal? quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? manHour
        {
            set { _manhour = value; }
            get { return _manhour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fuelWastage1
        {
            set { _fuelwastage1 = value; }
            get { return _fuelwastage1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fuelWastage2
        {
            set { _fuelwastage2 = value; }
            get { return _fuelwastage2; }
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
        public decimal? consumeRate1
        {
            set { _consumerate1 = value; }
            get { return _consumerate1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? consumeRate2
        {
            set { _consumerate2 = value; }
            get { return _consumerate2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? consumeCoulometry
        {
            set { _consumecoulometry = value; }
            get { return _consumecoulometry; }
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
    /// 实体类asphaltumConsumeDailyStatistics 。(改性沥青资源消耗日报表)
    /// </summary>
    public class AsphaltumConsumeDailyStatistics
    {
        public AsphaltumConsumeDailyStatistics()
        { }
        #region Model
        private long? _id;
        private DateTime? _producedate;
        private long? _eiid;
        private long? _pid;
        private long? _mid;
        private decimal? _quantity2;
        private decimal? _quantity1;
        private decimal? _manhour;
        private decimal? _fuelwastage1;
        private decimal? _fuelwastage2;
        private decimal? _consumerate1;
        private decimal? _consumerate2;
        private decimal? _consumecoulometry;
        private string _inputman;
        private DateTime? _inputdate;
        /// <summary>
        /// 
        /// </summary>
        public long? id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? produceDate
        {
            set { _producedate = value; }
            get { return _producedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? eiId
        {
            set { _eiid = value; }
            get { return _eiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? pId
        {
            set { _pid = value; }
            get { return _pid; }
        }

        public long? mId
        {
            set { _mid = value; }
            get { return _mid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity2
        {
            set { _quantity2 = value; }
            get { return _quantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity1
        {
            set { _quantity1 = value; }
            get { return _quantity1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? manHour
        {
            set { _manhour = value; }
            get { return _manhour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fuelWastage1
        {
            set { _fuelwastage1 = value; }
            get { return _fuelwastage1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fuelWastage2
        {
            set { _fuelwastage2 = value; }
            get { return _fuelwastage2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? consumeRate1
        {
            set { _consumerate1 = value; }
            get { return _consumerate1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? consumeRate2
        {
            set { _consumerate2 = value; }
            get { return _consumerate2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? consumeCoulometry
        {
            set { _consumecoulometry = value; }
            get { return _consumecoulometry; }
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
        #endregion Model

    }

    /// <summary>
    /// 实体类rebuildAsphaltConsumeDailyStatistics 。(乳化沥青资源消耗日报表)
    /// </summary>
    public class RebuildAsphaltConsumeDailyStatistics
    {
        public RebuildAsphaltConsumeDailyStatistics()
        { }
        #region Model
        private long? _id;
        private DateTime? _producedate;
        private long? _eiid;
        private long? _pid;
        private long? _mid;
        private decimal? _quantity2;
        private decimal? _quantity1;
        private decimal? _manhour;
        private decimal? _consumecoulometry;
        private decimal? _fuelwastage1;
        private decimal? _fuelwastage2;
        private decimal? _consumerate1;
        private decimal? _consumerate2;
        private string _inputman;
        private DateTime? _inputdate;
        private string _remark;


        /// <summary>
        /// 
        /// </summary>
        public long? id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? produceDate
        {
            set { _producedate = value; }
            get { return _producedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? eiId
        {
            set { _eiid = value; }
            get { return _eiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? pId
        {
            set { _pid = value; }
            get { return _pid; }
        }
        public long? mId
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity2
        {
            set { _quantity2 = value; }
            get { return _quantity2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quantity1
        {
            set { _quantity1 = value; }
            get { return _quantity1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? manHour
        {
            set { _manhour = value; }
            get { return _manhour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? consumeCoulometry
        {
            set { _consumecoulometry = value; }
            get { return _consumecoulometry; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fuelWastage1
        {
            set { _fuelwastage1 = value; }
            get { return _fuelwastage1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fuelWastage2
        {
            set { _fuelwastage2 = value; }
            get { return _fuelwastage2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? consumeRate1
        {
            set { _consumerate1 = value; }
            get { return _consumerate1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? consumeRate2
        {
            set { _consumerate2 = value; }
            get { return _consumerate2; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }


    /// <summary>
    /// 实体类deepFatConsumeDailyStatistics 。(热油炉能源消耗日报表)
    /// </summary>
    public class DeepFatConsumeDailyStatistics
    {
        public DeepFatConsumeDailyStatistics()
        { }
        #region Model
        private long? _id;
        private DateTime? _producedate;
        private long? _eiid;
        private decimal? _manhour;
        private decimal? _fuelwastage1;
        private decimal? _fuelwastage2;
        private long? _mid;
        private decimal? _consumerate1;
        private decimal? _consumerate2;
        private decimal? _consumecoulometry;
        private string _inputman;
        private DateTime? _inputdate;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public long? id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? produceDate
        {
            set { _producedate = value; }
            get { return _producedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? eiId
        {
            set { _eiid = value; }
            get { return _eiid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? manHour
        {
            set { _manhour = value; }
            get { return _manhour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fuelWastage1
        {
            set { _fuelwastage1 = value; }
            get { return _fuelwastage1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? fuelWastage2
        {
            set { _fuelwastage2 = value; }
            get { return _fuelwastage2; }
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
        public decimal? consumeRate1
        {
            set { _consumerate1 = value; }
            get { return _consumerate1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? consumeRate2
        {
            set { _consumerate2 = value; }
            get { return _consumerate2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? consumeCoulometry
        {
            set { _consumecoulometry = value; }
            get { return _consumecoulometry; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }

    /// <summary>
    /// 实体类deepFatConsumeDailyStatisticsDetail 。(热油炉能源消耗日报明细表)
    /// </summary>
    public class DeepFatConsumeDailyStatisticsDetail
    {
        #region Model
        private long _id;
        private long? _eiid;
        private long? _mid;
        private decimal? _fuelwastage;
        private long? _piid;
        private string _inputman;
        private DateTime? _inputdate;
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
        public long? eiId
        {
            set { _eiid = value; }
            get { return _eiid; }
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
        public decimal? fuelWastage
        {
            set { _fuelwastage = value; }
            get { return _fuelwastage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? piId
        {
            set { _piid = value; }
            get { return _piid; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }


    #region // 生产参数

    /*
    * 类名称：ProductionParameter
    * 类功能描述：生产参数 实体类
    *
    * 创建人：关启学
    * 创建时间：2009-04-15
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class ProductionParameter
    {
        private long id;                    // 生产参数id
        private double asphaltumError;      // 沥青偏差
        private double stoneError;          // 石料偏差
        private System.DateTime inputDate;  // 设定时间（录入时间）
        private decimal maxTemperature;     // 温度上限
        private decimal minTemperature;     // 温度下限
        private long eiId;                  // 设备id（equipmentInformation表id）
        private bool mark;                  // 是否使用（true：使用，false：未使用）
        private string inputMan;            // 录入人



        public long Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public double AsphaltumError
        {
            get
            {
                return this.asphaltumError;
            }
            set
            {
                this.asphaltumError = value;
            }
        }

        public double StoneError
        {
            get
            {
                return this.stoneError;
            }
            set
            {
                this.stoneError = value;
            }
        }

        public System.DateTime InputDate
        {
            get
            {
                return this.inputDate;
            }
            set
            {
                this.inputDate = value;
            }
        }

        public decimal MaxTemperature
        {
            get
            {
                return this.maxTemperature;
            }
            set
            {
                this.maxTemperature = value;
            }
        }

        public decimal MinTemperature
        {
            get
            {
                return this.minTemperature;
            }
            set
            {
                this.minTemperature = value;
            }
        }

        public long EiId
        {
            get
            {
                return this.eiId;
            }
            set
            {
                this.eiId = value;
            }
        }

        public bool Mark
        {
            get
            {
                return this.mark;
            }
            set
            {
                this.mark = value;
            }
        }

        public string InputMan
        {
            get
            {
                return this.inputMan;
            }
            set
            {
                this.inputMan = value;
            }
        }
    }

    #endregion

}


