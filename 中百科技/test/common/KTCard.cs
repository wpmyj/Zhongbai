using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DasherStation.common
{
    class KTCard : ICardHelper
    {
        /*
         * 方法名称：ReadCardID
         * 方法功能描述： 读卡号
         * 
         * 参 数：ComPort:串口号（1-8） 
         * CardId:保存读取的卡号
         *      
         * 返 回：成功则返回串口标识符>0，失败返回负值
         *
         * 创建人：冯雪
         * 创建时间：2009-3-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        // 读卡号
        [DllImport("CS2040.dll")]
        private unsafe static extern int ReadCardID(int ComPort, byte* CardId);

        /*
         * 方法名称：InputPassword
         * 方法功能描述：传输密钥
         * 
         * 参 数：ComPort:串口号 
         * Password:密钥（12位字符）
         * 
         * 返 回：成功返回1
         * 
         * 
         * 创建人：冯雪
         * 创建时间：2009-3-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        // 传输密钥
        [DllImport("CS2040.dll")]
        private static extern int InputPassword(int ComPort, string Password);

        /*
        * 方法名称：ChangeCardPassword
        * 方法功能描述：修改卡密钥
        * 参 数： ComPort 串口号（1-8）
        * SectorNo 扇区号（0-15）
        * OriginalPassword 原密钥（12位字符）
        * NewPassword 新密钥
        *
        * 返 回：成功则返回 1
        * 创建人：冯雪
        * 创建时间：2009-3-23
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        // 修改卡密钥
        [DllImport("CS2040.dll")]
        private static extern int ChangeCardPassword(int ComPort, int SectorNo, string OriginalPassword, string NewPassword);

        /*
        * 方法名称：ReadCardData
        * 方法功能描述：读块的内容
        * 参 数： ComPort 串口号（1-8）
        * SectorNo 扇区号（0-15）
        * BlockNo 块号（0-3）
        * CardData 用于保存读取的数据
        *
        * 返 回：成功则返回 1
        * 创建人：冯雪
        * 创建时间：2009-3-23
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        // 读块的内容
        [DllImport("CS2040.dll")]
        private unsafe static extern int ReadCardData(int ComPort, int SectorNo, int BlockNo, byte* CardData);

        /*
        * 方法名称：WriteCardData
        * 方法功能描述：写块的内容
        * 参 数： ComPort 串口号（1-8）
        * SectorNo 扇区号（0-15）
        * BlockNo 块号（0-3）
        * CardData 用于传递写入的数据
        *
        * 返 回：成功则返回 1
        * 创建人：冯雪
        * 创建时间：2009-3-23
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *    
        */
        // 写块的内容
        [DllImport("CS2040.dll")]
        private unsafe static extern int WriteCardData(int ComPort, int SectorNo, int BlockNo, byte* CardData);

        /*
        * 方法名称：BeepStatus
        * 方法功能描述：状态蜂鸣
        * 参 数： ComPort 串口号（1-8）
        * Status 状态（0-1)
        *
        * 返 回：成功则返回 1
        * 创建人：冯雪
        * 创建时间：2009-3-23
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        // 状态蜂鸣
        [DllImport("CS2040.dll")]
        private static extern int BeepStatus(int ComPort, int Status);


        // 读卡中数据;
        /*
        * 方法名称：Card_ReadDate
        * 方法功能描述：读卡中数据
        * 参 数： ComPort 串口号
        * SectorNo 扇区号
        * BlockNo 块号
        * 
        * 返 回：成功则返回 1
        * 创建人：冯雪
        * 创建时间：2009-3-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public unsafe int Card_ReadDate(int ComPort, int SectorNo, int BlockNo, byte[] CardData)
        {
            string password = "FFFFFFFFFFFF";
            int state = 0;

            fixed (byte* plBuf = CardData)
            {
                if (InputPassword(ComPort, password) == 1)
                {
                    state = ReadCardData(ComPort, SectorNo, BlockNo, plBuf);
                }
            }
            // 成功蜂鸣;
            if (state == 1)
            {
                Set_BeepStatus(ComPort, state);
            }
            return state;
        }

        // 写卡中数据;
        /*
        * 方法名称：Card_WriteDate
        * 方法功能描述：写卡中数据
        * 参 数： ComPort 串口号
        * SectorNo 扇区号
        * BlockNo 块号
        * 
        * 返 回：成功则返回 1
        * 创建人：冯雪
        * 创建时间：2009-3-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public unsafe int Card_WriteDate(int ComPort, int SectorNo, int BlockNo, byte[] CardData)
        {
            // 此处密钥应该为用户设置好的; 暂时写死;
            string password = "FFFFFFFFFFFF";
            int state = 0;

            fixed (byte* plBuf = CardData)
            {
                if (InputPassword(ComPort, password) == 1)
                {
                    state = WriteCardData(ComPort, SectorNo, 2, plBuf);
                }
                if (state == 1)
                {
                    Set_BeepStatus(ComPort, state);
                }
                return state;
            }
        }

        // 读卡号;
        /*
        * 方法名称：Care_ReadId
        * 方法功能描述：读卡号
        * 
        * 参 数：ComPort:串口号（1-8） 
        *        CardId:保存读取的卡号
        *        
        * 返 回：成功则返回串口标识符>0，失败返回负值
        *
        * 创建人：冯雪
        * 创建时间：2009-3-23
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public unsafe int Card_ReadId(int ComPort, byte[] CardId)
        {
            // 调用DLL返回状态;
            int state;

            fixed (byte* plBuf = CardId)
            {
                state = ReadCardID(ComPort, plBuf);
            }
            // 成功蜂鸣;
            Set_BeepStatus(ComPort, state);
            return state;
        }

        // 传输密钥;
        /*
         * 方法名称：TransfersPassword
         * 方法功能描述：传输密钥
         * 
         * 参 数：ComPort:串口号 
         * Password:密钥（12位字符）
         * 
         * 返 回：成功返回1
         * 
         * 创建人：冯雪
         * 创建时间：2009-3-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public int TransfersPassword(int ComPort, string Password)
        {
            int state = InputPassword(ComPort, Password);
            // 成功蜂鸣;
            Set_BeepStatus(ComPort, state);
            return state;
        }

        // 修改密钥;
        /*
         * 方法名称：TransfersPassword
         * 方法功能描述：传输密钥
         * 
         * 参 数：ComPort:串口号 
         * SectorNo:扇区号
         * OriginalPassword:旧密钥（12位字符）
         * NewPassword:新密钥
         * 
         * 返 回：成功返回1
         * 
         * 创建人：冯雪
         * 创建时间：2009-3-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public int AmendPassword(int ComPort, int SectorNo, string OriginalPassword, string NewPassword)
        {
            int state = ChangeCardPassword(ComPort, SectorNo, OriginalPassword, NewPassword);
            // 成功蜂鸣;
            Set_BeepStatus(ComPort, state);
            return state;
        }

        // 状态蜂鸣
        /*
         * 方法名称：Set_BeepStatus
         * 方法功能描述：状态蜂鸣
         * 
         * 参 数：ComPort:串口号 
         * Status:状态( 0-1)
         * 
         * 返 回：成功返回1
         * 
         * 创建人：冯雪
         * 创建时间：2009-3-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public void Set_BeepStatus(int ComPort, int Status)
        {
            BeepStatus(ComPort, Status);
        }

        // 初始化通讯口
        /*
         * 方法名称：Init_Port
         * 方法功能描述：状态蜂鸣
         * 
         * 参 数：port:取值为0～19时，表示串口1～20;为100时，表示USB口通讯，此时波特率无效 
         * baud:为通讯波特率9600～115200
         * 
         * 返 回：成功则返回串口标识 >0,失败返回负数
         * 
         * 创建人：冯雪
         * 创建时间：2009-3-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public int Init_Port(int port, long baud)
        {
            return 1;
        }

        // 关闭串口
        /*
         * 方法名称：Exit_Port
         * 方法功能描述：关闭串口
         * 
         * 参 数：icdev:通讯设备标识符 
         * 
         * 返 回：成功返回0
         * 
         * 创建人：冯雪
         * 创建时间：2009-3-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public int Exit_Port(int icdev)
        {
            return 0;
        }

    }
}
