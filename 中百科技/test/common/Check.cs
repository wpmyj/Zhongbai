/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：Check.cs
 * 文件功能描述：验证文本框输入的信息
 *
 * 创建人：金鹤 
 * 创建时间：20090204
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

namespace DasherStation.common
{
    /// <summary>
    /// 用于校验用户输入的信息是否合法
    /// </summary>
    public class Check
    {


        /// <summary>
        /// 验证用户输入用户名是否符合正则表达式(符合为True)
        /// </summary>
        /// <param name="UserName">需要验证的用户名</param>
        /// <returns>符合为True</returns>
        public static bool CheckUserName(string UserName)
        {
            try
            {
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9]{1,20}$");
                return reg.IsMatch(UserName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 验证用户输入用户名是否为空(非空为True)
        /// </summary>
        /// <param name="UserName">需要验证的用户名</param>
        /// <returns>非空为true</returns>
        public static bool CheckEmpty(string UserName)
        {
            try
            {
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"\S+");
                return reg.IsMatch(UserName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 验证用户输入密码(符合标准为True)
        /// </summary>
        /// <param name="UserPassword">需要验证的密码</param>
        /// <returns>符合标准为True</returns>
        public static bool CheckPassword(string userPassword)
        {
            try
            {
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9]{6,18}$");
                return reg.IsMatch(userPassword);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 验证是否符合零或者正整数(符合为True)
        /// </summary>
        /// <param name="Number">需要验证的字符</param>
        /// <returns>符合为True</returns>
        public static bool CheckNumber(string Number)
        {
            try
            {
                if (string.IsNullOrEmpty(Number))
                {
                    return true;
                    ////袁宇修改2009-4-10，
                    ////原因：字符串是空的时候，我们也不认为它是数字
                    //return false;
                }
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^(0|[1-9][0-9]*)$");
                if (reg.IsMatch(Number))
                {
                    int num = Convert.ToInt32(Number);
                    return num < int.MaxValue;
                }
                else
                {
                    return false;
                }
            }
            //catch (OverflowException)
            //{
            //    throw new Exception("数字超出int值范围");
            //}
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 验证是否符合零或者正符点数(符合为True)
        /// </summary>
        /// <param name="Number">需要验证的字符</param>
        /// <returns>符合为True</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.OverflowException"></exception>
        /// <exception cref="System.FormatException"></exception>
        public static bool CheckFloat(string number)
        {
            try
            {
                if (string.IsNullOrEmpty(number))
                {
                    return true;
                    ////袁宇修改2009-4-10，
                    ////原因：字符串是空的时候，我们也不认为它是整浮点整
                    //return false;
                }
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^\d*\.?\d*$");
                if (reg.IsMatch(number))
                {
                    
                    Double num =Convert.ToDouble(number);
                    return num < Double.MaxValue;
                }
                else
                {
                    return false;
                }
            }
            //catch (OverflowException)
            //{
            //    throw new Exception("数字超出int值范围");
            //}
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 验证字符串是否包含特殊字符[除字母数字外](不包含为True)
        /// </summary>
        /// <param name="str">需要验证的字符</param>
        /// <returns>不包含为True</returns>
        public static bool CheckChar(string str)
        {
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^A-Za-z0-9]");
                return reg.IsMatch(str);
        }

        /// <summary>
        /// 验证字符串是否包含SQL注入字符不包括空格(不包含为True)
        /// </summary>
        /// <param name="str">需要验证的字符</param>
        /// <returns>不包含为True</returns>
        public static bool CheckQuery(string str)
        {

                //构造SQL的注入关键字符
                #region 攻击字符


                    string[] strBadChar = {"and"
                    ,"exec"
                    ,"insert"
                    ,"select"
                    ,"delete"
                    ,"update"
                    ,"count"
                    ,"or"
                    //,"*"
                    //,@"\/"
                    //,@"\\"
                    //,"%"
                    ,":"
                    ,"\'"
                    ,"\""
                    ,"chr"                    
                    ,"mid"
                    ,"master"
                    ,"truncate"
                    ,"char"
                    ,"declare"
                    ,"SiteName"
                    ,"net user"
                    //,"xp_cmdshell"
                    //,"/add"
                    //,"exec master.dbo.xp_cmdshell"
                    //,"net localgroup administrators"
                   };

                #endregion

                string str_Regex = ".*(";
                foreach (string queryChar in strBadChar)
                {
                    str_Regex += queryChar + "|";
                }
                str_Regex = str_Regex.Substring(0, str_Regex.Length - 1);//去掉最后一个|
                str_Regex += ").*";

                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(str_Regex);
                return !reg.IsMatch(str);
        
        }

        /// <summary>
        /// 验证字符串是否包含SQL注入字符包括空格(不包含为True)
        /// </summary>
        /// <param name="str">需要验证的字符</param>
        /// <returns>不包含为True</returns>
        public static bool CheckQueryIsEmpty(string str)
        {
    
                //构造SQL的注入关键字符
                #region 攻击字符


                string[] strBadChar = {"and"
                    ,"exec"
                    ,"insert"
                    ,"select"
                    ,"delete"
                    ,"update"
                    ,"count"
                    ,"or"
                    //,"*"
                    //,@"\"
                    //,@"\\"
                    //,"%"
                    ,":"
                    ,"\'"
                    ,"\""
                    ,"chr"
                    ," "
                    ,"mid"
                    ,"master"
                    ,"truncate"
                    ,"char"
                    ,"declare"
                    ,"SiteName"
                    ,"net user"
                    ,"xp_cmdshell"
                    ,"/add"
                    ,"exec master.dbo.xp_cmdshell"
                    ,"net localgroup administrators"};


                #endregion

                string str_Regex = ".*(";
                foreach (string queryChar in strBadChar)
                {
                    str_Regex += queryChar + "|";
                }
                str_Regex = str_Regex.Substring(0, str_Regex.Length - 1);//去掉最后一个|
                str_Regex += ").*";

                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(str_Regex);
                return !reg.IsMatch(str);

        }
        /// <summary>
        /// 验证时间
        /// </summary>
        /// <param name="str">需要验证的字符</param>
        /// <returns>True:符合</returns>
        public static bool CheckTime(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^([0-1][0-9]|[2][0-3]):([0-5][0-9])$");
            return reg.IsMatch(str);
        }
    }//class Check
}//namespace DasherTools
