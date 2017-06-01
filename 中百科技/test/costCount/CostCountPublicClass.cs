using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DasherStation.costCount
{
    //用于存储树上结点Tag属性的结构形值
    struct TreeTagType
    {
        //记录Id
        public string id;
        //父结点ID
        public string parentId;
    }
    //枚举类型，费用一级科目
    enum CostStyle
    {
        //直接人工
        ManExpenditure,
        //制造费用
        MakeExpenditure,
        //季节性停工损失费用
        ShutdownExpenditure,
        //费品损失
        ScrapExpenditure,
        //直接材料费用
        StuffExpenditure
    }    
    /*
    * 类名称：produceQuotiety
    * 类功能描述：工时折算系数
    *
    * 创建人：付中华
    * 创建时间：2009-03-20
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    public class produceQuotiety
    {        
        private long s_id;

        private long s_pId;
        
        private float s_quotiety;
        
        private string s_remark;

        public long id
        {
            get {
                return this.s_id;
            }
            set {
                this.s_id = value;
            }
        }

        public long pId
        {
            get {
                return this.s_pId;
            }
            set {
                this.s_pId = value;
            }
        }
        
        public float quotiety {
            get {
                return this.s_quotiety;
            }
            set {
                this.s_quotiety = value;
            }
        }
        
        public string remark {
            get {
                return this.s_remark;
            }
            set {
                this.s_remark = value;
            }
        }
    }
    /*
   * 类名称：expenditureNameClass
   * 类功能描述：费用类别实体类
   *
   * 创建人：付中华
   * 创建时间：2009-03-23
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
    public class expenditureNameClass
    {
        private string s_id;

        private string s_name;

        private string s_parentId;

        private string s_level;

        private string s_inputDate;

        private string s_inputMan;

        private string s_remark;

        public string id
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

        public string name
        {
            get
            {
                return this.s_name;
            }
            set
            {
                this.s_name = value;
            }
        }

        public string parentId
        {
            get
            {
                return this.s_parentId;
            }
            set
            {
                this.s_parentId = value;
            }
        }

        public string level
        {
            get
            {
                return this.s_level;
            }
            set
            {
                this.s_level = value;
            }
        }

        public string inputDate
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
    }
    /*
   * 类名称：waitDetachExpenditureClass
   * 类功能描述：待分滩费用
   *
   * 创建人：付中华
   * 创建时间：2009-03-25
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
    public class waitDetachExpenditureClass
    {
        private string s_id;

        private string s_ekId;

        private string s_enId;

        private string s_ecId;

        private string s_expenditureDepict;

        private string s_year;

        private string s_month;

        private string s_eiId;

        private string s_number;

        private string s_unitPrice;

        private string s_money;

        private string s_inputDate;

        private string s_inputMan;

        private string s_assessor;

        private string s_checkupMan;

        private string s_isDetach;

        private string s_remark;

        private string s_convert;

        private string s_pId;

        private string s_isAuto;

        public string id
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

        public string ekId
        {
            get
            {
                return this.s_ekId;
            }
            set
            {
                this.s_ekId = value;
            }
        }

        public string enId
        {
            get
            {
                return this.s_enId;
            }
            set
            {
                this.s_enId = value;
            }
        }

        public string ecId
        {
            get
            {
                return this.s_ecId;
            }
            set
            {
                this.s_ecId = value;
            }
        }

        public string expenditureDepict
        {
            get
            {
                return this.s_expenditureDepict;
            }
            set
            {
                this.s_expenditureDepict = value;
            }
        }

        public string year
        {
            get
            {
                return this.s_year;
            }
            set
            {
                this.s_year = value;
            }
        }

        public string month
        {
            get
            {
                return this.s_month;
            }
            set
            {
                this.s_month = value;
            }
        }

        public string eiId
        {
            get
            {
                return this.s_eiId;
            }
            set
            {
                this.s_eiId = value;
            }
        }

        public string number
        {
            get
            {
                return this.s_number;
            }
            set
            {
                this.s_number = value;
            }
        }

        public string unitPrice
        {
            get
            {
                return this.s_unitPrice;
            }
            set
            {
                this.s_unitPrice = value;
            }
        }

        public string money
        {
            get
            {
                return this.s_money;
            }
            set
            {
                this.s_money = value;
            }
        }

        public string inputDate
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

        public string isDetach
        {
            get
            {
                return this.s_isDetach;
            }
            set
            {
                this.s_isDetach = value;
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
        public string convert
        {
            get
            {
                return this.s_convert;
            }
            set
            {
                this.s_convert = value;
            }
 
        }
        public string pId
        {
            get
            {
                return this.s_pId;
            }
            set
            {
                this.s_pId = value;
            }
        }

        public string isAuto
        {
            get
            {
                return this.s_isAuto;
            }
            set
            {
                this.s_isAuto = value;
            }
        }

    }

    /*
  * 类名称：expenditureClass
  * 类功能描述：费用表
  *
  * 创建人：付中华
  * 创建时间：2009-03-25
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */
    public class expenditureClass
    {
        private string s_id;

        private string s_ekId;

        private string s_enId;

        private string s_ecId;

        private string s_expenditureDepict;

        private string s_year;

        private string s_month;

        private string s_eiId;

        private string s_pId;

        private string s_number;

        private string s_unitPrice;

        private string s_money;

        private string s_inputDate;

        private string s_inputMan;

        private string s_assessor;

        private string s_checkupMan;

        private string s_isFromDetach;

        private string s_remark;

        private string s_convert;

        private string s_isAuto;

        public string id
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

        public string ekId
        {
            get
            {
                return this.s_ekId;
            }
            set
            {
                this.s_ekId = value;
            }
        }

        public string enId
        {
            get
            {
                return this.s_enId;
            }
            set
            {
                this.s_enId = value;
            }
        }

        public string ecId
        {
            get
            {
                return this.s_ecId;
            }
            set
            {
                this.s_ecId = value;
            }
        }

        public string expenditureDepict
        {
            get
            {
                return this.s_expenditureDepict;
            }
            set
            {
                this.s_expenditureDepict = value;
            }
        }

        public string year
        {
            get
            {
                return this.s_year;
            }
            set
            {
                this.s_year = value;
            }
        }

        public string month
        {
            get
            {
                return this.s_month;
            }
            set
            {
                this.s_month = value;
            }
        }

        public string eiId
        {
            get
            {
                return this.s_eiId;
            }
            set
            {
                this.s_eiId = value;
            }
        }

        public string pId
        {
            get
            {
                return this.s_pId;
            }
            set
            {
                this.s_pId = value;
            }
        }

        public string number
        {
            get
            {
                return this.s_number;
            }
            set
            {
                this.s_number = value;
            }
        }

        public string unitPrice
        {
            get
            {
                return this.s_unitPrice;
            }
            set
            {
                this.s_unitPrice = value;
            }
        }

        public string money
        {
            get
            {
                return this.s_money;
            }
            set
            {
                this.s_money = value;
            }
        }

        public string inputDate
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

        public string isFromDetach
        {
            get
            {
                return this.s_isFromDetach;
            }
            set
            {
                this.s_isFromDetach = value;
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
        public string convert
        {
            get
            {
                return this.s_convert;
            }
            set
            {
                this.s_convert = value;
            }

        }

        public string isAuto
        {
            get
            {
                return this.s_isAuto;
            }
            set
            {
                this.s_isAuto = value;
            }
        }
    }

    /*
    * 类名称：selectExpenditureClass
    * 类功能描述：用于查询的实体类
    *
    * 创建人：付中华
    * 创建时间：2009-03-26
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    public class selectExpenditureClass
    {
        private string s_exSort;

        private string s_exName;

        private string s_exDetail;

        private string s_exDepict;

        private string s_exYear;

        private string s_exMonth;
        
        private string s_eqName;

        private string s_eqModel;

        private string s_prName;

        private string s_prModel;

        private string s_exUnitPrice;

        private string s_exNumber;

        private string s_exMoney;

        private string s_exInputDate;

        private string s_exInputMan;

        private string s_exConvert;

        private string s_exRemark;

        private string s_beginDateTime;

        private string s_endDateTime;

        private string s_flag;

        public string flag
        {
            get { return s_flag; }
            set { s_flag = value; }
        }

        public string exSort
        {
            get { return this.s_exSort; }
            set { this.s_exSort = value; }
        }

        public string exName
        {
            get { return this.s_exName; }
            set { this.s_exName = value; }
        }

        public string exDetail
        {
            get { return this.s_exDetail; }
            set { this.s_exDetail = value; }
        }

        public string exDepict
        {
            get { return this.s_exDepict; }
            set { this.s_exDepict = value; }
        }

        public string exYear
        {
            get { return this.s_exYear; }
            set { this.s_exYear = value; }
        }

        public string exMonth
        {
            get { return this.s_exMonth; }
            set { this.s_exMonth = value; }
        }

        public string eqName
        {
            get { return this.s_eqName; }
            set { this.s_eqName = value; }
        }

        public string eqModel
        {
            get { return this.s_eqModel; }
            set { this.s_eqModel = value; }
        }

        public string prName
        {
            get { return this.s_prName; }
            set { this.s_prName = value; }
        }

        public string prModel
        {
            get { return this.s_prModel; }
            set { this.s_prModel = value; }
        }

        public string exUnitPrice
        {
            get { return this.s_exUnitPrice; }
            set { this.s_exUnitPrice = value; }
        }

        public string exNumber
        {
            get { return this.s_exNumber; }
            set { this.s_exNumber = value; }
        }

        public string exMoney
        {
            get { return this.s_exMoney; }
            set { this.s_exMoney = value; }
        }

        public string exInputDate
        {
            get { return this.s_exInputDate; }
            set { this.s_exInputDate = value; }
        }

        public string exInputMan
        {
            get { return this.s_exInputMan; }
            set { this.s_exInputMan = value; }
        }

        public string exConvert
        {
            get { return this.s_exConvert; }
            set { this.s_exConvert = value; }
        }

        public string exRemark
        {
            get { return this.s_exRemark; }
            set { this.s_exRemark = value; }
        }

        public string beginDateTime
        {
            get { return this.s_beginDateTime; }
            set { this.s_beginDateTime = value; }
        }

        public string endDateTime
        {
            get { return this.s_endDateTime; }
            set { this.s_endDateTime = value; }
        }
           
    }

    /*
 * 类名称：bitumenExpenditureClass
 * 类功能描述：沥青费用表
 *
 * 创建人：付中华
 * 创建时间：2009-03-28
 *
 * 修改人：
 * 修改时间：
 * 修改内容：
 *
 */
    public class bitumenExpenditureClass
    {
        private string s_id;

        private string s_ekId;

        private string s_enId;

        private string s_ecId;

        private string s_expenditureDepict;

        private string s_year;

        private string s_month;

        private string s_eiId;

        private string s_pId;

        private string s_number;

        private string s_unitPrice;

        private string s_money;

        private string s_inputDate;

        private string s_inputMan;

        private string s_assessor;

        private string s_checkupMan;

        private string s_isFromDetach;

        private string s_remark;

        private string s_convert;

        private string s_isAuto;

        public string id
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

        public string ekId
        {
            get
            {
                return this.s_ekId;
            }
            set
            {
                this.s_ekId = value;
            }
        }

        public string enId
        {
            get
            {
                return this.s_enId;
            }
            set
            {
                this.s_enId = value;
            }
        }

        public string ecId
        {
            get
            {
                return this.s_ecId;
            }
            set
            {
                this.s_ecId = value;
            }
        }

        public string expenditureDepict
        {
            get
            {
                return this.s_expenditureDepict;
            }
            set
            {
                this.s_expenditureDepict = value;
            }
        }

        public string year
        {
            get
            {
                return this.s_year;
            }
            set
            {
                this.s_year = value;
            }
        }

        public string month
        {
            get
            {
                return this.s_month;
            }
            set
            {
                this.s_month = value;
            }
        }

        public string eiId
        {
            get
            {
                return this.s_eiId;
            }
            set
            {
                this.s_eiId = value;
            }
        }

        public string pId
        {
            get
            {
                return this.s_pId;
            }
            set
            {
                this.s_pId = value;
            }
        }

        public string number
        {
            get
            {
                return this.s_number;
            }
            set
            {
                this.s_number = value;
            }
        }

        public string unitPrice
        {
            get
            {
                return this.s_unitPrice;
            }
            set
            {
                this.s_unitPrice = value;
            }
        }

        public string money
        {
            get
            {
                return this.s_money;
            }
            set
            {
                this.s_money = value;
            }
        }

        public string inputDate
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

        public string isFromDetach
        {
            get
            {
                return this.s_isFromDetach;
            }
            set
            {
                this.s_isFromDetach = value;
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
        public string convert
        {
            get
            {
                return this.s_convert;
            }
            set
            {
                this.s_convert = value;
            }

        }

        public string isAuto
        {
            get
            {
                return this.s_isAuto;
            }
            set
            {
                this.s_isAuto = value;
            }
        }
    }

    /*
 * 类名称：bitumenWaitDetachExpenditureClass
 * 类功能描述：沥青待摊费用表
 *
 * 创建人：付中华
 * 创建时间：2009-03-28
 *
 * 修改人：
 * 修改时间：
 * 修改内容：
 *
 */
    public class bitumenWaitDetachExpenditureClass
    {
        private string s_id;

        private string s_ekId;

        private string s_enId;

        private string s_ecId;

        private string s_expenditureDepict;

        private string s_year;

        private string s_month;

        private string s_eiId;

        private string s_number;

        private string s_unitPrice;

        private string s_money;

        private string s_inputDate;

        private string s_inputMan;

        private string s_assessor;

        private string s_checkupMan;

        private string s_isDetach;

        private string s_remark;

        private string s_convert;

        private string s_pId;

        private string s_isAuto;

        public string id
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

        public string ekId
        {
            get
            {
                return this.s_ekId;
            }
            set
            {
                this.s_ekId = value;
            }
        }

        public string enId
        {
            get
            {
                return this.s_enId;
            }
            set
            {
                this.s_enId = value;
            }
        }

        public string ecId
        {
            get
            {
                return this.s_ecId;
            }
            set
            {
                this.s_ecId = value;
            }
        }

        public string expenditureDepict
        {
            get
            {
                return this.s_expenditureDepict;
            }
            set
            {
                this.s_expenditureDepict = value;
            }
        }

        public string year
        {
            get
            {
                return this.s_year;
            }
            set
            {
                this.s_year = value;
            }
        }

        public string month
        {
            get
            {
                return this.s_month;
            }
            set
            {
                this.s_month = value;
            }
        }

        public string eiId
        {
            get
            {
                return this.s_eiId;
            }
            set
            {
                this.s_eiId = value;
            }
        }

        public string number
        {
            get
            {
                return this.s_number;
            }
            set
            {
                this.s_number = value;
            }
        }

        public string unitPrice
        {
            get
            {
                return this.s_unitPrice;
            }
            set
            {
                this.s_unitPrice = value;
            }
        }

        public string money
        {
            get
            {
                return this.s_money;
            }
            set
            {
                this.s_money = value;
            }
        }

        public string inputDate
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

        public string isDetach
        {
            get
            {
                return this.s_isDetach;
            }
            set
            {
                this.s_isDetach = value;
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
        public string convert
        {
            get
            {
                return this.s_convert;
            }
            set
            {
                this.s_convert = value;
            }

        }
        public string pId
        {
            get
            {
                return this.s_pId;
            }
            set
            {
                this.s_pId = value;
            }
        }

        public string isAuto
        {
            get
            {
                return this.s_isAuto;
            }
            set
            {
                this.s_isAuto = value;
            }
        }

    }

    /*
 * 类名称：alterBitumenExpenditureClass
 * 类功能描述：改性沥青与乳化沥青费用表
 *
 * 创建人：付中华
 * 创建时间：2009-03-28
 *
 * 修改人：
 * 修改时间：
 * 修改内容：
 *
 */
    public class alterBitumenExpenditureClass
    {
        private string s_id;

        private string s_ekId;

        private string s_enId;

        private string s_ecId;

        private string s_expenditureDepict;

        private string s_year;

        private string s_month;

        private string s_eiId;

        private string s_pId;

        private string s_number;

        private string s_unitPrice;

        private string s_money;

        private string s_inputDate;

        private string s_inputMan;

        private string s_assessor;

        private string s_checkupMan;

        private string s_isFromDetach;

        private string s_remark;

        private string s_convert;

        private string s_isAuto;

        public string id
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

        public string ekId
        {
            get
            {
                return this.s_ekId;
            }
            set
            {
                this.s_ekId = value;
            }
        }

        public string enId
        {
            get
            {
                return this.s_enId;
            }
            set
            {
                this.s_enId = value;
            }
        }

        public string ecId
        {
            get
            {
                return this.s_ecId;
            }
            set
            {
                this.s_ecId = value;
            }
        }

        public string expenditureDepict
        {
            get
            {
                return this.s_expenditureDepict;
            }
            set
            {
                this.s_expenditureDepict = value;
            }
        }

        public string year
        {
            get
            {
                return this.s_year;
            }
            set
            {
                this.s_year = value;
            }
        }

        public string month
        {
            get
            {
                return this.s_month;
            }
            set
            {
                this.s_month = value;
            }
        }

        public string eiId
        {
            get
            {
                return this.s_eiId;
            }
            set
            {
                this.s_eiId = value;
            }
        }

        public string pId
        {
            get
            {
                return this.s_pId;
            }
            set
            {
                this.s_pId = value;
            }
        }

        public string number
        {
            get
            {
                return this.s_number;
            }
            set
            {
                this.s_number = value;
            }
        }

        public string unitPrice
        {
            get
            {
                return this.s_unitPrice;
            }
            set
            {
                this.s_unitPrice = value;
            }
        }

        public string money
        {
            get
            {
                return this.s_money;
            }
            set
            {
                this.s_money = value;
            }
        }

        public string inputDate
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

        public string isFromDetach
        {
            get
            {
                return this.s_isFromDetach;
            }
            set
            {
                this.s_isFromDetach = value;
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
        public string convert
        {
            get
            {
                return this.s_convert;
            }
            set
            {
                this.s_convert = value;
            }

        }

        public string isAuto
        {
            get
            {
                return this.s_isAuto;
            }
            set
            {
                this.s_isAuto = value;
            }
        }
    }


    /*
* 类名称：alterBitumenWaitDetachExpenditureClass
* 类功能描述：改性沥青与乳化沥青待摊费用表
*
* 创建人：付中华
* 创建时间：2009-03-28
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/
    public class alterBitumenWaitDetachExpenditureClass
    {
        private string s_id;

        private string s_ekId;

        private string s_enId;

        private string s_ecId;

        private string s_expenditureDepict;

        private string s_year;

        private string s_month;

        private string s_eiId;

        private string s_number;

        private string s_unitPrice;

        private string s_money;

        private string s_inputDate;

        private string s_inputMan;

        private string s_assessor;

        private string s_checkupMan;

        private string s_isDetach;

        private string s_remark;

        private string s_convert;

        private string s_pId;

        private string s_isAuto;

        public string id
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

        public string ekId
        {
            get
            {
                return this.s_ekId;
            }
            set
            {
                this.s_ekId = value;
            }
        }

        public string enId
        {
            get
            {
                return this.s_enId;
            }
            set
            {
                this.s_enId = value;
            }
        }

        public string ecId
        {
            get
            {
                return this.s_ecId;
            }
            set
            {
                this.s_ecId = value;
            }
        }

        public string expenditureDepict
        {
            get
            {
                return this.s_expenditureDepict;
            }
            set
            {
                this.s_expenditureDepict = value;
            }
        }

        public string year
        {
            get
            {
                return this.s_year;
            }
            set
            {
                this.s_year = value;
            }
        }

        public string month
        {
            get
            {
                return this.s_month;
            }
            set
            {
                this.s_month = value;
            }
        }

        public string eiId
        {
            get
            {
                return this.s_eiId;
            }
            set
            {
                this.s_eiId = value;
            }
        }

        public string number
        {
            get
            {
                return this.s_number;
            }
            set
            {
                this.s_number = value;
            }
        }

        public string unitPrice
        {
            get
            {
                return this.s_unitPrice;
            }
            set
            {
                this.s_unitPrice = value;
            }
        }

        public string money
        {
            get
            {
                return this.s_money;
            }
            set
            {
                this.s_money = value;
            }
        }

        public string inputDate
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

        public string isDetach
        {
            get
            {
                return this.s_isDetach;
            }
            set
            {
                this.s_isDetach = value;
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
        public string convert
        {
            get
            {
                return this.s_convert;
            }
            set
            {
                this.s_convert = value;
            }

        }
        public string pId
        {
            get
            {
                return this.s_pId;
            }
            set
            {
                this.s_pId = value;
            }
        }

        public string isAuto
        {
            get
            {
                return this.s_isAuto;
            }
            set
            {
                this.s_isAuto = value;
            }
        }

    }

    /*
    * 类名称：selectBitumenExpenditureClass
    * 类功能描述：用于查询沥青的实体类
    *
    * 创建人：付中华
    * 创建时间：2009-03-28
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    public class selectBitumenExpenditureClass
    {
        private string s_exSort;

        private string s_exName;

        private string s_exDetail;

        private string s_exDepict;

        private string s_exYear;

        private string s_exMonth;

        private string s_eqName;

        private string s_eqModel;

        private string s_prName;

        private string s_prModel;

        private string s_exUnitPrice;

        private string s_exNumber;

        private string s_exMoney;

        private string s_exInputDate;

        private string s_exInputMan;

        private string s_exConvert;

        private string s_exRemark;

        private string s_beginDateTime;

        private string s_endDateTime;

        private string s_flag;

        public string flag
        {
            get { return s_flag; }
            set { s_flag = value; }
        }

        public string exSort
        {
            get { return this.s_exSort; }
            set { this.s_exSort = value; }
        }

        public string exName
        {
            get { return this.s_exName; }
            set { this.s_exName = value; }
        }

        public string exDetail
        {
            get { return this.s_exDetail; }
            set { this.s_exDetail = value; }
        }

        public string exDepict
        {
            get { return this.s_exDepict; }
            set { this.s_exDepict = value; }
        }

        public string exYear
        {
            get { return this.s_exYear; }
            set { this.s_exYear = value; }
        }

        public string exMonth
        {
            get { return this.s_exMonth; }
            set { this.s_exMonth = value; }
        }

        public string eqName
        {
            get { return this.s_eqName; }
            set { this.s_eqName = value; }
        }

        public string eqModel
        {
            get { return this.s_eqModel; }
            set { this.s_eqModel = value; }
        }

        public string prName
        {
            get { return this.s_prName; }
            set { this.s_prName = value; }
        }

        public string prModel
        {
            get { return this.s_prModel; }
            set { this.s_prModel = value; }
        }

        public string exUnitPrice
        {
            get { return this.s_exUnitPrice; }
            set { this.s_exUnitPrice = value; }
        }

        public string exNumber
        {
            get { return this.s_exNumber; }
            set { this.s_exNumber = value; }
        }

        public string exMoney
        {
            get { return this.s_exMoney; }
            set { this.s_exMoney = value; }
        }

        public string exInputDate
        {
            get { return this.s_exInputDate; }
            set { this.s_exInputDate = value; }
        }

        public string exInputMan
        {
            get { return this.s_exInputMan; }
            set { this.s_exInputMan = value; }
        }

        public string exConvert
        {
            get { return this.s_exConvert; }
            set { this.s_exConvert = value; }
        }

        public string exRemark
        {
            get { return this.s_exRemark; }
            set { this.s_exRemark = value; }
        }

        public string beginDateTime
        {
            get { return this.s_beginDateTime; }
            set { this.s_beginDateTime = value; }
        }

        public string endDateTime
        {
            get { return this.s_endDateTime; }
            set { this.s_endDateTime = value; }
        }

    }


    /*
    * 类名称：AlterBitumenWaitDetachExpenditure
    * 类功能描述：用于查询改性沥青和乳化沥青的实体类
    *
    * 创建人：付中华
    * 创建时间：2009-03-28
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    public class selectAlterBitumenWaitDetachExpenditure
    {
        private string s_exSort;

        private string s_exName;

        private string s_exDetail;

        private string s_exDepict;

        private string s_exYear;

        private string s_exMonth;

        private string s_eqName;

        private string s_eqModel;

        private string s_prName;

        private string s_prModel;

        private string s_exUnitPrice;

        private string s_exNumber;

        private string s_exMoney;

        private string s_exInputDate;

        private string s_exInputMan;

        private string s_exConvert;

        private string s_exRemark;

        private string s_beginDateTime;

        private string s_endDateTime;

        private string s_flag;

        public string flag
        {
            get { return s_flag; }
            set { s_flag = value; }
        }

        public string exSort
        {
            get { return this.s_exSort; }
            set { this.s_exSort = value; }
        }

        public string exName
        {
            get { return this.s_exName; }
            set { this.s_exName = value; }
        }

        public string exDetail
        {
            get { return this.s_exDetail; }
            set { this.s_exDetail = value; }
        }

        public string exDepict
        {
            get { return this.s_exDepict; }
            set { this.s_exDepict = value; }
        }

        public string exYear
        {
            get { return this.s_exYear; }
            set { this.s_exYear = value; }
        }

        public string exMonth
        {
            get { return this.s_exMonth; }
            set { this.s_exMonth = value; }
        }

        public string eqName
        {
            get { return this.s_eqName; }
            set { this.s_eqName = value; }
        }

        public string eqModel
        {
            get { return this.s_eqModel; }
            set { this.s_eqModel = value; }
        }

        public string prName
        {
            get { return this.s_prName; }
            set { this.s_prName = value; }
        }

        public string prModel
        {
            get { return this.s_prModel; }
            set { this.s_prModel = value; }
        }

        public string exUnitPrice
        {
            get { return this.s_exUnitPrice; }
            set { this.s_exUnitPrice = value; }
        }

        public string exNumber
        {
            get { return this.s_exNumber; }
            set { this.s_exNumber = value; }
        }

        public string exMoney
        {
            get { return this.s_exMoney; }
            set { this.s_exMoney = value; }
        }

        public string exInputDate
        {
            get { return this.s_exInputDate; }
            set { this.s_exInputDate = value; }
        }

        public string exInputMan
        {
            get { return this.s_exInputMan; }
            set { this.s_exInputMan = value; }
        }

        public string exConvert
        {
            get { return this.s_exConvert; }
            set { this.s_exConvert = value; }
        }

        public string exRemark
        {
            get { return this.s_exRemark; }
            set { this.s_exRemark = value; }
        }

        public string beginDateTime
        {
            get { return this.s_beginDateTime; }
            set { this.s_beginDateTime = value; }
        }

        public string endDateTime
        {
            get { return this.s_endDateTime; }
            set { this.s_endDateTime = value; }
        }

    }
     /*
    * 类名称：CaleBitumenHeatCostClass
    * 类功能描述：沥青加热成本类 此类用来对于界面数据上的所有条件查询类
    *
    * 创建人：付中华
    * 创建时间：2009-04-02
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    public class CaleBitumenHeatCostClass
    {
        private string yearDate;
        private string monthDate;
        private string startDate;
        private string endDate;
        private string equipmentNo;

        public string YearDate
        {
            get { return this.yearDate; }
            set { this.yearDate = value; }
        }

        public string MonthDate
        {
            get { return this.monthDate; }
            set { this.monthDate = value; }
        }

        public string StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        public string EndDate
        {
            get { return this.endDate; }
            set { this.endDate = value; }
        }

        public string Equipment
        {
            get { return this.equipmentNo; }
            set { this.equipmentNo = value; }
        }
    }

    /*
   * 类名称：directManEntityClass
   * 类功能描述：直接人工费用的实体类
   *
   * 创建人：付中华
   * 创建时间：2009-04-09
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
    public class directManEntityClass
    {
        public string totalExpenditure;

        public string ekId;

        public string expenditureDepict;

        public string yearDate;

        public string monthDate;

        public string equipmentId;

        public string equipmentNo;

    }
    /*
   * 类名称：direct
   * 类功能描述：直接材料费用的实体类
   *
   * 创建人：付中华
   * 创建时间：2009-04-10
   *
   * 修改人：
   * 修改时间：
   * 修改内容：
   *
   */
    public class directMaterialClass
    {
        public string ekId;

        public string expenditureDepict;

        public string year;

        public string month;

        public string eiId;
        
    }

}


