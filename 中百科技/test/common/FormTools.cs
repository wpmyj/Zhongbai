/*
 * 版权单位：沈阳中百科技有限公司
 *
 * 文件名：FormTools.cs
 * 文件功能描述：完成窗体特殊操作
 *
 * 创建人：金鹤 
 * 创建时间：20090209
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

namespace DasherStation.common
{
    /// <summary>
    /// 用于控制窗体的特殊动作
    /// </summary>
    public class FormTools
    {
        /*
         * 方法名称：打开新窗体
         * 方法功能描述：判断要打开窗体是否已经存在
         *
         * 创建人：金鹤 
         * 创建时间：20090209

        */
        /// <summary>
        /// 打开唯一的一个新的窗体
        /// </summary>
        /// <param name="mdiFrm">Mdi父窗体</param>
        /// <param name="sonFrm">将要打开的子窗体</param>
        public void showFrom(Form mdiFrm, Form sonFrm)
        {

                if (CheckFrom(mdiFrm, sonFrm))
                {
                    sonFrm.WindowState = FormWindowState.Normal;
                    sonFrm.MdiParent = mdiFrm;
                    sonFrm.Activate();
                    sonFrm.Show();
                }
                else
                {                   
                    sonFrm.Dispose();
                }

        }

        /// <summary>
        /// 判断窗体是否已经存在
        /// </summary>
        /// <param name="mdiFrm">Mdi父窗体</param>
        /// <param name="sonFrm">将要打开的字窗体</param>
        /// <returns>存在返回false,不存在返回true</returns>
        private bool CheckFrom(Form mdiFrm, Form sonFrm)
        {
            try
            {
                foreach (Form newFrm in mdiFrm.MdiChildren)
                {
                    if (newFrm.Name == sonFrm.Name)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }

        }



    }//class FormTools
}
