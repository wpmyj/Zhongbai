/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：HumanResourcePublicClass.cs
* 文件功能描述：人力资源公用实体类
*
* 创建人： 杨林
* 创建时间：2009-03-05
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DasherStation.HumanResource
{
    /*
      * 类名称：PayRollItem
      * 类功能描述：工资项实体类
      *
      * 创建人：杨林
      * 创建时间：2009-03-12
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
    */
    /// <summary>
    /// 工资项实体类
    /// </summary>
    public class PayRollItem
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int ID
        {
            set;
            get;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 是否为减项
        /// </summary>
        public bool IsMinus
        {
            get;
            set;
        }

        /// <summary>
        /// 是否为前减项
        /// </summary>
        public bool IsFirstMinus
        {
            get;
            set;
        }

        /// <summary>
        /// 应用员工类型
        /// </summary>
        public EnumEmployeeType EmployeeType
        {
            get;
            set;
        }
    }

    /*
      * 类名称：EnumEmployeeType
      * 类功能描述：员工类型枚举
      *
      * 创建人：杨林
      * 创建时间：2009-03-12
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
    */
    /// <summary>
    /// 员工类型枚举
    /// </summary>
    public enum EnumEmployeeType
    {
        /// <summary>
        /// 正式员工
        /// </summary>
        Official = 0,

        /// <summary>
        /// 临时工
        /// </summary>
        Temp=1,

        /// <summary>
        /// 全部员工
        /// </summary>
        Staff=2
    }

    /// <summary>
    /// UI方法通用类
    /// </summary>
    public abstract class CommUI
    {
        public static void MsgOK()
        {
            MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MsgOK(string strMsg)
        {
            MessageBox.Show(strMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void AlertError(string strMsg)
        {
            MessageBox.Show(strMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Confirm(string strMsg)
        {
            return MessageBox.Show(strMsg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
    }

    /// <summary>
    /// 员工类别数据源类
    /// </summary>
    public class CKind
    {
        public bool TypeID
        {
            set;
            get;
        }
        public string TypeName
        {
            set;
            get;
        }

    }

    /// <summary>
    /// 是否纳税数据源类
    /// </summary>
    public class CMark
    {
        public bool IsMark
        {
            set;
            get;
        }

        public string Mark
        {
            set;
            get;
        }
    }
}
