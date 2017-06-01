/*
* 版权单位：沈阳中百科技有限公司
*
* 文件名：CNotifyDelegate.cs
* 文件功能描述：库存报警提示
*
* 创建人： 杨林
* 创建时间：2009-03-28
*
* 修改人：
* 修改时间：
* 修改内容：
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using DasherStation.storage;

namespace DasherStation.common
{
    public class CNotifyDelegate
    {
        public static void NotifyAlert(Index win)
        {
            System.Windows.Forms.MouseEventHandler oHandler = delegate(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                win.Activate();
                win.WindowState = System.Windows.Forms.FormWindowState.Normal;
            };
            win.oNotify.MouseDoubleClick += oHandler;
            win.oNotify.BalloonTipClicked += delegate(object sender, System.EventArgs e)
            {
                win.Activate();
                win.WindowState = System.Windows.Forms.FormWindowState.Normal;
            };

            System.Threading.Thread oThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(CheckInOrOut));
            oThread.IsBackground = true;
            oThread.Start(win);
        }

        static void CheckInOrOut(object arg)
        {
            Index win = arg as Index;
           
                while (true)
                {
                    try
                    {
                        DasherStation.storage.StockStatLogic oStockModel = new DasherStation.storage.StockStatLogic();
                        DataTable dttIn = oStockModel.InStat();
                        DataTable dttOut = oStockModel.OutStat();
                        bool bAlertIn = (from DataRow row in dttIn.Rows
                                         where row["最低库存量"].ToString() != ""
                                             && Convert.ToDecimal(row["库存"].ToString()) < Convert.ToDecimal(row["最低库存量"].ToString())
                                         select row[0]).Count() > 0;
                        bool bAlertOut = (from DataRow row in dttOut.Rows
                                          where row["最低库存量"].ToString() != ""
                                              && Convert.ToDecimal(row["库存"].ToString()) < Convert.ToDecimal(row["最低库存量"].ToString())
                                          select row[0]).Count() > 0;
                        SetState(win, bAlertIn, bAlertOut);
                    }
                    catch (System.Exception ex)
                    {
                        new Logging().LogWrite(new LogEntry() { ID = (int)DateTime.Now.Minute, LogEx = ex, LogMessage = ex.Message });
                    }
                    //配置文件中设置多少分钟检查一次.
                    double minute = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["StockAlertReFresh"]);
                    System.Threading.Thread.Sleep(TimeSpan.FromMinutes(minute));
                    

                }
           
        }

        static void SetState(Index win, bool bAlertIn, bool bAlertOut)
        {
            if (win.InvokeRequired == false)
            {
                if (bAlertIn || bAlertOut)
                {
                    win.oNotify.Visible = true;
                    FrmStockStat frmStockStat = null;
                    frmStockStat = (from child in win.MdiChildren.OfType<FrmStockStat>()
                                    select child).FirstOrDefault();

                    if (frmStockStat == null)
                    {
                        frmStockStat = new FrmStockStat();
                        FormTools formTools = new FormTools();
                        formTools.showFrom(win, frmStockStat);
                    }
                    else
                    {
                        frmStockStat.Activate();
                    }

                    if (bAlertIn)
                    {
                        frmStockStat.rbtnMaterial.Checked = true;
                    }
                    else if (bAlertOut)
                    {
                        frmStockStat.rbtnProduct.Checked = true;
                    }
                    win.oNotify.ShowBalloonTip(1000 * 10, "温馨提示", "账面库存小于最低库存量,请注意!!!", System.Windows.Forms.ToolTipIcon.Info);
                }
                else
                {
                    win.oNotify.Visible = false;
                }
            }
            else
            {
                win.Invoke(new Action<Index,bool,bool>(SetState), new object[] { win , bAlertIn, bAlertOut});                
            }
        }
    }
}
