using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DasherStation.common
{
    public interface ICardHelper
    {
        /// <summary>
        /// 读卡中数据
        /// </summary>
        /// <param name="ComPort"> 串口号 </param>
        /// <param name="SectorNo"> 扇区号 </param>
        /// <param name="BlockNo"> 块号 </param>
        /// <param name="CardData"> 用来存储读出的数据 </param>
        /// <returns> 成功则返回 1 </returns>
         unsafe int Card_ReadDate(int ComPort, int SectorNo, int BlockNo, byte[] CardData);
        
        /// <summary>
        /// 向卡中写数据
        /// </summary>
        /// <param name="ComPort"> 串口号 </param>
        /// <param name="SectorNo"> 扇区号 </param>
        /// <param name="BlockNo"> 块号 </param>
        /// <param name="CardData"> 要写入的数据</param>
        /// <returns> 成功则返回 1 </returns>
         unsafe int Card_WriteDate(int ComPort, int SectorNo, int BlockNo, byte[] CardData);

        /// <summary>
        /// 读卡号
        /// </summary>
        /// <param name="ComPort"> 串口号 </param>
        /// <param name="CardId"> 用来存储读出的卡号 </param>
        /// <returns> 成功则返回 1 </returns>
         unsafe int Card_ReadId(int ComPort, byte[] CardId);

        /// <summary>
        /// 传输密钥
        /// </summary>
        /// <param name="ComPort"> 串口号 </param>
        /// <param name="Password"> 密钥 </param>
        /// <returns> 成功则返回 1 </returns>
         int TransfersPassword(int ComPort, string Password);

        /// <summary>
        /// 传输密钥
        /// </summary>
        /// <param name="ComPort"> 串口号 </param>
        /// <param name="SectorNo"> 扇区号 </param>
        /// <param name="OriginalPassword"> 旧密钥 </param>
        /// <param name="NewPassword"> 新密钥 </param>
        /// <returns> 成功则返回 1 </returns>
         int AmendPassword(int ComPort, int SectorNo, string OriginalPassword, string NewPassword);

        /// <summary>
        /// 状态蜂鸣
        /// </summary>
        /// <param name="ComPort"> 串口号 </param>
        /// <param name="Status"> 状态( 0-1) </param>
        /// <returns></returns>
         void Set_BeepStatus(int ComPort, int Status);

        /// <summary>
        /// 初始化通讯口
        /// </summary>
        /// <param name="port"> 取值为0～19时，表示串口1～20;为100时，表示USB口通讯，此时波特率无效 </param>
        /// <param name="baud"> 为通讯波特率9600～115200 </param>
        /// <returns> 成功则返回串口标识 >0,失败返回负数 </returns>
         int Init_Port(int port, long baud);

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <param name="icdev"> 通讯设备标识符 </param>
        /// <returns> 成功返回0</returns>
         int Exit_Port(int icdev);

    }
}
