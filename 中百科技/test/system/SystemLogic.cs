/*
 * 类名称：
 * 类功能描述：
 *
 * 创建人：
 * 创建时间：20090214
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
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Drawing;
using DasherStation.common;


namespace DasherStation.system
{
    class SystemLogic
    {
        SystemDB systemDb = new SystemDB();

        #region 登录界面逻辑层调用方法

        /// <summary>
        /// 检查输入的用户名是否存在
        /// </summary>
        /// <param name="username"> 用户名</param>
        /// <returns>false 不存在</returns>
        public bool Search_username(string username)
        {
            return systemDb.Search_username(username);
        }

        /// <summary>
        /// 检查用户密码是否正确
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>false 密码错误,true 密码正确</returns>
        public bool Search_password(string username, string password)
        {
            return systemDb.Search_password(username, password);
        }

        /// <summary>
        /// 登录时,检查用户权限 
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>返回其权限信息</returns>
        public DataSet Check_Purview(string username)
        {
            return systemDb.Check_Purview(username);
        }

        /// <summary>
        /// 查询用户所有按钮
        /// </summary>
        /// <param name="username"> 用户名</param>
        /// <returns></returns>
        public DataSet Open_Frm(string username)
        {
            return systemDb.Open_Frm(username);
        }


        #endregion




        DataSet ds = new DataSet();

        private bool status;

        /*
        * 方法名称：FrmUserInfoSearch
        * 方法功能描述：调用数据类方法获得用户查询所得数据集并绑定DataGridView
        *
        * 创建人：夏阳明
         * * 创建时间：20090214
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void FrmUserInfoSearch(string searchStr, int verifyBit, DataGridView dgv)
        {
            ds = systemDb.FrmUserInfoSearch(searchStr, verifyBit, dgv);
            dgv.DataSource = ds.Tables[0];
        }
        /*
        * 方法名称：InitialCbxDuty
        * 方法功能描述：给Combobox赋值
        *
        * 创建人：夏阳明
        * 创建时间：20090214
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void InitialCbxDuty(ComboBox cbx)
        {
            ds = systemDb.InitialCbxDuty();
            cbx.DataSource = ds.Tables[0];
        }
        /*
        * 方法名称：FrmUserInfoSave
        * 方法功能描述：调用数据类方法将用户信息插入到数据库中并返回bool值判断是否插入成功
        *
        * 创建人：夏阳明
        * 创建时间：20090214
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmUserInfoSave(UserInfoClass userInfoClass, DataGridView dgv)
        {
            status = systemDb.FrmUserInfoSave(userInfoClass);

            if (status)
            {
                ds = systemDb.FrmUserInfoSearchAll();
                dgv.DataSource = ds.Tables[0];
                return true;
            }

            return false;
        }
        /*
        * 方法名称：FrmUserInfoUpdate
        * 方法功能描述：调用数据类方法将用户信息更新到数据库中并返回bool值判断是否更新成功
        *
        * 创建人：夏阳明
        * 创建时间：20090216
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmUserInfoUpdate(UserInfoClass userInfoClass, int id, DataGridView dgv)
        {
            status = systemDb.FrmUserInfoUpdate(userInfoClass, id);

            if (status)
            {
                ds = systemDb.FrmUserInfoSearchAll();
                dgv.DataSource = ds.Tables[0];
                return true;
            }

            return false;
        }
        /*
        * 方法名称：FrmUserInfoUpdateForDelete
        * 方法功能描述：调用数据类方法将用户记录中的deleteMark设置成1并更新到数据库中返回bool值判断是否更新成功
        *
        * 创建人：夏阳明
        * 创建时间：20090216
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmUserInfoUpdateForDelete(int id, DataGridView dgv)
        {
            status = systemDb.FrmUserInfoUpdateForDelete(id);

            if (status)
            {
                ds = systemDb.FrmUserInfoSearchAll();
                dgv.DataSource = ds.Tables[0];
                return true;
            }

            return false;
        }
        /*
        * 方法名称：FrmUserInfoSearchForUserName
        * 方法功能描述：调用数据类方法查询用户记录中符合条件的用户返回bool值判断是否有该用户
        *
        * 创建人：夏阳明
        * 创建时间：20090219
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmUserInfoSearchForUserName(string userName)
        {
            return systemDb.FrmUserInfoSearchForUserName(userName);
        }

        ////车辆窗体逻辑层方法;

        ///*
        // * 方法名称：FrmTruckSearch()
        // * 方法功能描述：调用数据类方法根据条件查询车辆信息并刷新DataGridView;
        // *
        // * 创建人：冯雪
        // * 创建时间：
        // *
        // * 修改人：
        // * 修改时间：
        // * 修改内容：
        // *
        // */
        //public void FrmTruckSearch(string searchStr, int verifyBit, DataGridView dgv)
        //{
        //    ds = systemDb.FrmTruckSearch(searchStr, verifyBit, dgv);
        //    dgv.DataSource = ds.Tables[0];
        //}
        ///*
        // * 方法名称：InitialTruckComboBox
        // * 方法功能描述：给TruckInfo窗体所有Combobox赋值
        // *
        // * 创建人：冯雪
        // * 创建时间：2009-02-16
        // *
        // * 修改人：
        // * 修改时间：
        // * 修改内容：
        // *
        // */
        //public void InitialTruckComboBox(ComboBox cbx)
        //{
        //    ds = systemDb.InitialTruckComboBox();
        //    cbx.DataSource = ds.Tables[0];
        //}
        ///*
        // * 方法名称：InitialTruckComboBox
        // * 方法功能描述：给TruckInfo窗体所有Combobox赋值
        // *
        // * 创建人：冯雪
        // * 创建时间：2009-02-16
        // *
        // * 修改人：
        // * 修改时间：
        // * 修改内容：
        // *
        // */
        //public void InitialTruckComboBox1(ComboBox cbx)
        //{
        //    ds = systemDb.InitialTruckComboBox1();
        //    cbx.DataSource = ds.Tables[0];
        //}
        ///*
        // * 方法名称：FrmTruckInsert()
        // * 方法功能描述：调用数据类方法将车辆信息插入到数据库中并返回bool值判断是否插入成功
        // *
        // * 创建人：冯雪
        // * 创建时间：2009-02-16
        // *
        // * 修改人：
        // * 修改时间：
        // * 修改内容：
        // *
        // */
        //public bool FrmTruckInsert(TruckClass truckClass, DataGridView dgv)
        //{
        //    status = systemDb.FrmTruckInsert(truckClass);

        //    if (status)
        //    {
        //        ds = systemDb.FrmTruckSearch("", 0, dgv);
        //        dgv.DataSource = ds.Tables[0];

        //        return true;
        //    }

        //    return false;
        //}
        ///*
        // * 方法名称：FrmTruckUpdate()
        // * 方法功能描述：调用数据类方法将车辆信息更新到数据库中并返回bool值判断是否插入成功
        // *
        // * 创建人：冯雪
        // * 创建时间：2009-02-16
        // *
        // * 修改人：
        // * 修改时间：
        // * 修改内容：
        // *
        // */
        //public bool FrmTruckUpdate(TruckClass truckClass, DataGridView dgv, int id)
        //{
        //    status = systemDb.FrmTruckUpdate(truckClass, id);

        //    if (status)
        //    {
        //        ds = systemDb.FrmTruckSearch("", 0, dgv);
        //        dgv.DataSource = ds.Tables[0];

        //        return true;
        //    }

        //    return false;
        //}
        ///*
        //* 方法名称：FrmTruckDelete()
        //* 方法功能描述：调用数据类方法将车辆记录中的deleteMark设置成1并更新到数据库中返回bool值判断是否更新成功
        //*
        //* 创建人：冯雪
        //* 创建时间：2009-02-16
        //*
        //* 修改人：
        //* 修改时间：
        //* 修改内容：
        //*
        //*/
        //public bool FrmTruckDelete(int id, DataGridView dgv)
        //{
        //    status = systemDb.FrmTruckDelete(id);

        //    if (status)
        //    {
        //        ds = systemDb.FrmTruckSearch("", 0, dgv);
        //        dgv.DataSource = ds.Tables[0];

        //        return true;
        //    }

        //    return false;
        //}
    }
    class CardClass
    {
        /*
         * 方法名称：dc_init
         * 方法功能描述：初始化通讯口
         * 
         * 参 数：port：取值为0～19时，表示串口1～20；为100时，表示USB口通讯，此时波特率无效。
         *      baud：为通讯波特率9600～115200
         *      
         * 返 回：成功则返回串口标识符>0，失败返回负值
         *
         * 创建人：袁宇
         * 创建时间：2009-2-9
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        [DllImport("dcrf32.dll")]
        public static extern int dc_init(int port, long baud);
        /*
         * 方法名称：dc_exit
         * 方法功能描述：关闭串口
         * 
         * 参 数：icdev：通讯设备标识符
         * 
         * 返 回：成功返回0
         * 
         * 例：dc_exit(icdev);
         * 
         * 注：在WIN32环境下icdev为串口的设备句柄，必须释放后才可以再次连接。
         * 
         * 创建人：袁宇
         * 创建时间：2009-2-9
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        [DllImport("dcrf32.dll")]
        public static extern int dc_exit(int icdev);
        /*
        * 方法名称：dc_card
        * 方法功能描述：寻卡，能返回在工作区域内某张卡的序列号
        * 参 数： icdev：通讯设备标识符
        *         _Mode：寻卡模式mode_card
        *         _Snr：返回的卡序列号
        * 返 回：成功则返回 0
        * 创建人：袁宇
        * 创建时间：2009-2-9
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        [DllImport("dcrf32.dll")]
        public static extern int dc_card(int icdev, byte _Mode, ref ulong _Snr);
        /*
         * 方法名称：dc_request
         * 方法功能描述：寻卡请求
         * 参 数： icdev：通讯设备标识符
         * 
         * _Mode：寻卡模式mode_card
         * 
         * Tagtype：卡类型值，0x0004为M1卡，0x0010为ML卡
         * 
         * 返 回：成功则返回 0
         * 
         * 创建人：袁宇
         * 创建时间：2009-2-9
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        [DllImport("dcrf32.dll")]
        public static extern int dc_request(int icdev, byte _Mode, out uint TagType);
        /*
         * 方法名称：dc_load_key_hex
         * 方法功能描述：装载密码
         * 
         * 
         * 
         * 返 回：成功则返回 0
         * 
         * 创建人：袁宇
         * 创建时间：2009-2-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        [DllImport("dcrf32.dll")]
        public static extern int dc_load_key_hex(int icdev, int mode, int secor, string skey);
        /*
         * 方法名称：dc_authentication
         * 方法功能描述：核对密码函数
         * 参 数：icdev: dc_init返回的设备描述符
         *_Mode： 密码验证模式
         *_SecNr：要验证密码的扇区号
         * 
         * 返 回：成功则返回 0
         * 
         * 创建人：袁宇
         * 创建时间：2009-2-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication(int icdev, byte _Mode, byte _SecNr);
        /*
         * 方法名称：dc_read_hex
         * 方法功能描述：读取卡中数据
         * 参 数：icdev: 返回的设备描述符
         * _Adr：块地址
         * sdata：读出数据
         * 
         * 返 回：成功则返回 0
         * 
         * 创建人：袁宇
         * 创建时间：2009-2-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */

        [DllImport("dcrf32.dll")]
        public static unsafe extern int dc_read_hex(int icdev, int adr, StringBuilder sdata);
        /*
         * 方法名称：dc_write_hex
         * 方法功能描述：向卡中写入数据
         * 参 数：icdev: 返回的设备描述符
         * Adr：块地址
         * sdata：写入数据
         * 
         * 返 回：成功则返回 0
         * 
         * 创建人：袁宇
         * 创建时间：2009-2-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        [DllImport("dcrf32.dll")]
        public static extern int dc_write_hex(int icdev, int adr, StringBuilder sdata);
        /*
         * 方法名称：dc_halt
         * 方法功能描述：中止对该卡操作
         * 参 数：icdev: 返回的设备描述符        
         * 
         * 返 回：成功则返回 0
         * 
         * 创建人：袁宇
         * 创建时间：2009-2-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        [DllImport("dcrf32.dll")]
        public static extern int dc_halt(int icdev);
        /*
         * 方法名称：
         * 方法功能描述：
         * 参 数：icdev: 返回的设备描述符        
         * 
         * 返 回：
         * 
         * 创建人：袁宇
         * 创建时间：2009-2-10
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        [DllImport("dcrf32.dll")]
        public static extern int dc_reset(int icdev, int msc);
        /*
        * 方法名称：dc_beep
        * 方法功能描述：蜂鸣
        * 参 数：参 数：icdev：通讯设备标识符
        * unsigned int _Msec：蜂鸣时间，单位是10毫秒
        * 
        * 返 回：
        * 
        * 创建人：袁宇
        * 创建时间：2009-2-10
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        [DllImport("dcrf32.dll")]
        public static extern int dc_beep(int icdev, uint _Msec);
        /*
        * 方法名称：dc_disp_str
        * 方法功能描述：在读写器的数码管上显示数字(RD800M读写器专用)
        * 功 能：在读写器的数码管上显示数字(RD800M读写器专用)
        * 参 数：icdev：通讯设备标识符
        * digit：要显示的字符串，由数值字符'0'-'F'和'.'组成
        * 返 回：成功则返回 0
        * 
        * 创建人：袁宇
        * 创建时间：2009-2-10
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        [DllImport("dcrf32.dll")]
        public static extern int dc_disp_str(int icdev, string digit);
        /*
        * 方法名称：AscArr2Str
        * 方法功能描述：byte[] 转换成string 函数
        * 功 能：数据类型转换
        * 参 数：b：要转换的byte[]类型      
        * 返 回：string 结果
        * 
        * 创建人：袁宇
        * 创建时间：2009-2-19
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public static string AscArr2Str(byte[] b)
        {
            return System.Text.UnicodeEncoding.Unicode.GetString(System.Text.ASCIIEncoding.Convert(System.Text.Encoding.ASCII, System.Text.Encoding.Unicode, b));
        }
    }

    #region 车辆信息窗体逻辑层方法

    /*
      * 类名称：TruckLogic
      * 类功能描述：车辆信息窗体逻辑层方法
      *
      * 创建人：冯雪
      * 创建时间：2009-02-23
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class TruckLogic
    {
        TruckDB truckDB = new TruckDB();

        //车辆窗体逻辑层方法;

        /*
         * 方法名称：FrmTruckSearch()
         * 方法功能描述：调用数据类方法根据条件查询车辆信息并刷新DataGridView;
         *
         * 创建人：冯雪
         * 创建时间：
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         * *
         */
        public DataTable FrmTruckSearch(string condition, int verifyBit)
        {
            return truckDB.FrmTruckSearch(condition, verifyBit);
        }
        /*
           * 方法名称：SearchTruckNo( )
           * 方法功能描述：查询要插入的字段在车辆信息表中是否存在;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-06
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool SearchTruckNo(string no)
        {
            return truckDB.SearchTruckNo(no);
        }
        /*
         * 方法名称：InitialTruckComboBox
         * 方法功能描述：给TruckInfo窗体所有Combobox赋值
         *
         * 创建人：冯雪
         * 创建时间：2009-02-16
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataTable InitialTruckComboBox(int state)
        {
            return truckDB.InitialTruckComboBox(state);
        }
        /*
         * 方法名称：InitialTruckComboBox
         * 方法功能描述：给TruckInfo窗体所有Combobox赋值
         *
         * 创建人：冯雪
         * 创建时间：2009-02-16
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataTable InitialTruckComboBox1()
        {
            return truckDB.InitialTruckComboBox1();
        }
        /*
         * 方法名称：FrmTruckInsert()
         * 方法功能描述：调用数据类方法将车辆信息插入到数据库中并返回bool值判断是否插入成功
         *
         * 创建人：冯雪
         * 创建时间：2009-02-16
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public bool FrmTruckInsert(TruckClass truckClass)
        {
            return truckDB.FrmTruckInsert(truckClass);
        }
        /*
         * 方法名称：FrmTruckUpdate()
         * 方法功能描述：调用数据类方法将车辆信息更新到数据库中并返回bool值判断是否插入成功
         *
         * 创建人：冯雪
         * 创建时间：2009-02-16
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public bool FrmTruckUpdate(TruckClass truckClass)
        {
            return truckDB.FrmTruckUpdate(truckClass);
        }
        /*
        * 方法名称：FrmTruckDelete()
        * 方法功能描述：调用数据类方法将车辆记录中的deleteMark设置成1并更新到数据库中返回bool值判断是否更新成功
        *
        * 创建人：冯雪
        * 创建时间：2009-02-16
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmTruckDelete(int id)
        {
            return truckDB.FrmTruckDelete(id);
        }
    }

    #endregion

    #region 运输单位窗体逻辑层方法

    /*
      * 类名称：TransportLogic
      * 类功能描述：运输单位窗体逻辑层方法
      *
      * 创建人：冯雪
      * 创建时间：2009-02-23
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class TransportLogic
    {
        TransportDB transportDB = new TransportDB();

        /*
         * 方法名称：FrmTransportSearchAll()
         * 方法功能描述：调用数据类方法根据条件查询车辆信息并刷新DataGridView;
         *
         * 创建人：冯雪
         * 创建时间：
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataTable FrmTransportSearchAll(string searchStr, int verifyBit)
        {
            return transportDB.FrmTransportSearchAll(searchStr, verifyBit);
        }
        /*
           * 方法名称：InitComboBox( )
           * 方法功能描述：查询运输单位信息表中所有负责人、邮编;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-05
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public DataTable InitComboBox(int state)
        {
            return transportDB.InitComboBox(state);
        }
        /*
           * 方法名称：SearchTransportName( )
           * 方法功能描述：查询要插入的字段在运输单位信息表中是否存在;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-06
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool SearchTransportName(string name)
        {
            return transportDB.SearchTransportName(name);
        }
        /*
           * 方法名称：FrmTransportInsert( )
           * 方法功能描述：向运输单位信息表中插入数据;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-06
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool FrmTransportInsert(TransportClass transportClass)
        {
            return transportDB.FrmTransportInsert(transportClass);
        }
        /*
       * 方法名称：FrmTransportDelete( )
       * 方法功能描述：向运输单位信息表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-06
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmTransportDelete(int transportId)
        {
            return transportDB.FrmTransportDelete(transportId);
        }
        /*
               * 方法名称：FrmTransportUpdate( )
               * 方法功能描述：向运输单位信息表中更新数据;
               *
               * 创建人：冯雪
               * 创建时间：2009-04-14
               *
               * 修改人：
               * 修改时间：
               * 修改内容：
               *
               */
        public bool FrmTransportUpdate(TransportClass transportClass)
        {
            return transportDB.FrmTransportUpdate(transportClass);
        }
    }

    #endregion

    #region 供应商窗体逻辑层方法

    /*
      * 类名称：ProviderLogic
      * 类功能描述：供应商窗体逻辑层方法
      *
      * 创建人：冯雪
      * 创建时间：2009-02-23
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class ProviderLogic
    {

        ProviderDB providerDB = new ProviderDB();
        DataSet ds = new DataSet();
        DataTable dataTable = new DataTable();
        private bool status;

        /*
         * 方法名称：FrmProviderSearch()
         * 方法功能描述：调用数据类方法根据条件查询车辆信息并刷新DataGridView;
         *
         * 创建人：冯雪
         * 创建时间：
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataTable FrmProviderSearch(string searchStr, int verifyBit)
        {
            dataTable = providerDB.FrmProviderSearch(searchStr, verifyBit);
            return dataTable;

        }
        /*
         * 方法名称：InitialProviderComboBox()
         * 方法功能描述：给ProviderInfo窗体的供应商名称、法人、负责人、邮编等Combobox赋值;
         * *
         * 创建人：冯雪
         * 创建时间：2009-02-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public void InitialProviderComboBox(ComboBox cbx, int state)
        {
            cbx.DataSource = providerDB.InitialProviderComboBox(state);
        }
        /*
         * 方法名称：FrmProviderInsert()
         * 方法功能描述：调用数据类方法将供应商信息插入到数据库中并返回bool值判断是否插入成功
         *
         * 创建人：冯雪
         * 创建时间：2009-02-16
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public bool FrmProviderInsert(ProviderClass providerClass)
        {
            return providerDB.FrmProviderInsert(providerClass);
        }
        /*
       * 方法名称：PSearchPName( )
       * 方法功能描述：查询要插入的供应商字段在表中是否存在;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool PSearchPName(string pname)
        {
            return providerDB.PSearchPName(pname);
        }
        /*
       * 方法名称：FrmProviderDelete( )
       * 方法功能描述：供应商表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmProviderDelete(int providerId)
        {
            return providerDB.FrmProviderDelete(providerId);
        }
        /*
        * 方法名称：FrmProviderUpdate
        * 方法功能描述：更新数据库操作并返回bool值（true为成功，false为失败）
        *
        * 创建人：冯雪
        * 创建时间：20090414
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmProviderUpdate(ProviderClass providerClass)
        {
            return providerDB.FrmProviderUpdate(providerClass);
        }

    }

    #endregion

    #region 供应商供应材料窗体逻辑层方法
    /// <summary>
    /// 供应商供应材料窗体逻辑层方法
    /// </summary>
    /*
      * 类名称：GMaterialLogin
      * 类功能描述：供应商供应材料窗体逻辑层方法
      *
      * 创建人：冯雪
      * 创建时间：2009-03-04
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class GMaterialLogin
    {
        GMaterialDB gmLogin = new GMaterialDB();

        /*
        * 方法名称：FrmGMaterialSearch()
        * 方法功能描述：按条件查询所有数据
        *
        * 创建人：冯雪
        * 创建时间：2009-03-04
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable FrmGMaterialSearch(int providerId, string searchStr, int verifyBit)
        {
            return gmLogin.FrmGMaterialSearch(providerId, searchStr, verifyBit);
        }
        /*
           * 方法名称：FrmMaterialInsert( )
           * 方法功能描述：向供应商供应材料表中插入数据;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-04
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool FrmGMaterialInsert(GMaterialClass gmaterialClass)
        {
            return gmLogin.FrmGMaterialInsert(gmaterialClass);
        }
        /*
           * 方法名称：FrmSearchGMP( )
           * 方法功能描述：查询要插入的字段在表中是否存在;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-02
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool FrmSearchGMP(int materialId, int providerId, int producerId)
        {
            return gmLogin.FrmSearchGMP(materialId, providerId, producerId);
        }
        /*
           * 方法名称：FrmGMaterialDelete( )
           * 方法功能描述：供应材料表中删除数据;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-04
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool FrmGMaterialDelete(int gMaterialId)
        {
            return gmLogin.FrmGMaterialDelete(gMaterialId);
        }
    }
    #endregion

    #region 人员信息窗体逻辑方法
    /// <summary>
    /// 人员信息窗体逻辑层方法
    /// </summary>  
    /*
    * 类名称：PersonnelLogic
    * 类功能描述：人员信息窗体逻辑方法
    *
    * 创建人：冯雪
    * 创建时间：2009-03-04
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class PersonnelLogic
    {
        PersonnelDB personnelDB = new PersonnelDB();
        /*
           * 方法名称：SearchPersonnelAll( )
           * 方法功能描述：查询人员信息表中所有信息;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-04
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public DataTable SearchPersonnelAll(string condition, int verifyBit)
        {
            return personnelDB.SearchPersonnelAll(condition, verifyBit);
        }
        /*
           * 方法名称：SearchPersonnelName( )
           * 方法功能描述：查询要插入的字段在人员信息表中是否存在;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-04
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool SearchPersonnelName(string name)
        {
            return personnelDB.SearchPersonnelName(name);
        }
        /*
           * 方法名称：FrmPersonnelInsert( )
           * 方法功能描述：向人员信息表中插入数据;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-04
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool FrmPersonnelInsert(PersonnelClass personnelClass)
        {
            return personnelDB.FrmPersonnelInsert(personnelClass);
        }
        /*
           * 方法名称：FrmPersonnelDelete( )
           * 方法功能描述：向人员信息表中删除数据;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-05
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool FrmPersonnelDelete(int personnelId)
        {
            return personnelDB.FrmPersonnelDelete(personnelId);
        }

    }
    #endregion

    #region 生产设备窗体逻辑方法
    /// <summary>
    /// 生产设备窗体逻辑方法
    /// </summary>  
    /*
    * 类名称：EquipmentLogic
    * 类功能描述：生产设备窗体逻辑方法
    *
    * 创建人：冯雪
    * 创建时间：2009-03-05
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class EquipmentInfoLogic
    {
        EquipmentInfoDB equipmentDB = new EquipmentInfoDB();


        public equipment.EquipmentInformation GetDataByID(long id)
        {
            return equipmentDB.QueryByID(id);
        }

        public void Edit(equipment.EquipmentInformation entity)
        {
            equipmentDB.Update(entity);
        }


        /*
       * 方法名称：SearchEquipmentAll( )
       * 方法功能描述：查询设备信息表中所有信息;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-04
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable SearchEquipmentAll(string condition)
        {
            return equipmentDB.SearchEquipmentAll(condition);
        }

        /*
       * 方法名称：SearchAll_NO( )
       * 方法功能描述：查询设备信息表中所有设备编号;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable SearchAll_NO()
        {
            return equipmentDB.SearchAll_NO();
        }

        /*
           * 方法名称：InitComboBox( )
           * 方法功能描述：查询设备信息表中所有经办人、联系人、邮编;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-05
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public DataTable InitComboBox(int state)
        {
            return equipmentDB.InitComboBox(state);
        }
        /*
            * 方法名称：InitialEName()
            * 方法功能描述：查询该设备种类下的所有设备名称;
            *
            * 创建人：冯雪
            * 创建时间：2009-02-28
            *
            * 修改人：
            * 修改时间：
            * 修改内容：
            *
            */
        public DataTable InitialEName(long ekId)
        {
            return equipmentDB.InitialEName(ekId);
        }

        /*
            * 方法名称：SearchDepartment()
            * 方法功能描述：查询所有部门名称;
            *
            * 创建人：冯雪
            * 创建时间：2009-03-22
            *
            * 修改人：
            * 修改时间：
            * 修改内容：
            *
            */
        public DataTable SearchDepartment()
        {
            return equipmentDB.SearchDepartment();
        }

        /*
            * 方法名称：SearchDocument()
            * 方法功能描述：查询所有文档编号;
            *
            * 创建人：冯雪
            * 创建时间：2009-03-22
            *
            * 修改人：
            * 修改时间：
            * 修改内容：
            *
            */
        public DataTable SearchDocument()
        {
            return equipmentDB.SearchDocument();
        }

        // 设备类别;
        /*
           * 方法名称：SearchEquipmentKindAll( )
           * 方法功能描述：查询设备类别所有信息;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-05
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public DataTable SearchEquipmentKindAll()
        {
            return equipmentDB.SearchEquipmentKindAll();
        }
        /*
           * 方法名称：SearchKind( )
           * 方法功能描述：查询要插入的字段在设备类别表中是否存在;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-21
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool SearchKind(string kind)
        {
            return equipmentDB.SearchKind(kind);
        }
        /*
           * 方法名称：InsertKind( )
           * 方法功能描述：向设备类别表中插入数据;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-05
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool InsertKind(EquipmentClass eClass)
        {
            return equipmentDB.InsertKind(eClass);
        }
        /*
           * 方法名称：DeleteKind( )
           * 方法功能描述：向设备种类表中删除数据;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-05
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool DeleteKind(int eKindId)
        {
            return equipmentDB.DeleteKind(eKindId);
        }

        // 设备名称;
        /*
       * 方法名称：SearchEquipmentNameAll( )
       * 方法功能描述：查询设备名称表中所有信息;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable SearchEquipmentNameAll(long ekid)
        {
            return equipmentDB.SearchEquipmentNameAll(ekid);
        }
        /*
       * 方法名称：SearchName( )
       * 方法功能描述：查询要插入的字段在设备名称表中是否存在;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool SearchName(string name, long ekId)
        {
            return equipmentDB.SearchName(name,ekId);
        }
        /*
       * 方法名称：InsertName( )
       * 方法功能描述：向设备名称表中插入数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool InsertName(EquipmentClass eClass)
        {
            return equipmentDB.InsertName(eClass);
        }
        /*
       * 方法名称：DeleteName( )
       * 方法功能描述：向设备名称表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool DeleteName(int eNameId)
        {
            return equipmentDB.DeleteName(eNameId);
        }

        // 设备规格;
        /*
       * 方法名称：SearchEquipmentModelAll( )
       * 方法功能描述：查询设备规格表中所有信息;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable SearchEquipmentModelAll()
        {
            return equipmentDB.SearchEquipmentModelAll();
        }
        /*
       * 方法名称：SearchModel( )
       * 方法功能描述：查询要插入的字段在设备规格表中是否存在;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool SearchModel(string model)
        {
            return equipmentDB.SearchModel(model);
        }
        /*
       * 方法名称：InsertModel( )
       * 方法功能描述：向设备名称表中插入数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool InsertModel(EquipmentClass eClass)
        {
            return equipmentDB.InsertModel(eClass);
        }
        /*
       * 方法名称：DeleteModel( )
       * 方法功能描述：向设备规格表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool DeleteModel(int eModelId)
        {
            return equipmentDB.DeleteModel(eModelId);
        }
        /*
       * 方法名称：SearchEquipmentPrincipalAll( )
       * 方法功能描述：查询设备表中所有负责人信息;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable SearchEquipmentPrincipalAll()
        {
            return equipmentDB.SearchEquipmentPrincipalAll();
        }
        /*
       * 方法名称：SearchNO( )
       * 方法功能描述：查询要插入的字段在设备表中是否存在;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool SearchNO(string no)
        {
            return equipmentDB.SearchNO(no);
        }
        /*
       * 方法名称：FrmEquipmentInsert( )
       * 方法功能描述：向生产设备表中插入数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-04
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmEquipmentInsert(EquipmentClass eClass)
        {
            return equipmentDB.FrmEquipmentInsert(eClass);
        }
        /*
       * 方法名称：FrmEquipmentDelete( )
       * 方法功能描述：向生产设备表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-04
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmEquipmentDelete(long equipmentId)
        {
            return equipmentDB.FrmEquipmentDelete(equipmentId);
        }

        // 液态罐信息;
        /*
       * 方法名称：InsertLiquidMatter( )
       * 方法功能描述：向设备表中更新液态罐的直径、高和罐样式信息,并向液态罐表中插入液态罐中存储材料、产品信息;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-26
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool InsertLiquidMatter(EquipmentClass eClass, int state)
        {
            return equipmentDB.InsertLiquidMatter(eClass,state);
        }
        /*
       * 方法名称：SearchLiquidMatter( )
       * 方法功能描述：在液态罐表中查询液态罐存储内容;;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-26
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable SearchLiquidMatter(long eiId)
        {
            return equipmentDB.SearchLiquidMatter(eiId);
        }
        /*
       * 方法名称：ExistLiquidMatter( )
       * 方法功能描述：在液态罐表中查询是否添加过该液态罐的内容;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-26
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool ExistLiquidMatter(long eiId)
        {
            DataTable dataTable = new DataTable();
            dataTable = SearchLiquidMatter(eiId);

            int id = dataTable.Rows.Count;

            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
           * 方法名称：searchMPInfo( )
           * 方法功能描述：查询罐中存的是什么材料或是什么产品;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-26
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public DataTable searchMPInfo(long id, int state)
        {
            return equipmentDB.searchMPInfo(id, state);
        }

        /*
        * 方法名称：searchNO( )
        * 方法功能描述：查询液态罐编号;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable searchYNO()
        {
            return equipmentDB.searchYNO();
        }

        /// <summary>
        /// 查找ComboBox值对应项的索引
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int FindIndex(ComboBox cmb, string value)
        {
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if (((DataRowView)cmb.Items[i]).Row[0].ToString() == value)
                {
                    return i;
                }
            }
            return 0;
        }

    }
    #endregion

    #region 选项窗体逻辑层方法
    /// <summary>
    /// 选项窗体逻辑层方法
    /// </summary>  
    /*
    * 类名称：OptionDB
    * 类功能描述：选项窗体逻辑层方法
    *
    * 创建人：冯雪
    * 创建时间：2009-03-04
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class OptionLogic
    {
        OptionDB optionDB = new OptionDB();

        /*
           * 方法名称：SearchPosition( )
           * 方法功能描述：查询职位所有信息;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-02
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public DataTable SearchPosition()
        {
            return optionDB.SearchPosition();
        }
        /*
           * 方法名称：SearchProduceTeam( )
           * 方法功能描述：查询生产班组所有信息;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-02
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public DataTable SearchProduceTeam()
        {
            return optionDB.SearchProduceTeam();
        }
        /*
           * 方法名称：SearchTeam( )
           * 方法功能描述：查询生产班组所有信息;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-02
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public DataTable SearchTeam()
        {
            return optionDB.SearchTeam();
        }
        /*
           * 方法名称：ValidateProduceTeam( )
           * 方法功能描述：查询要插入的生产班组是否存在;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-06
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool ValidateTeam(string team)
        {
            return optionDB.ValidateTeam(team);
        }   
        /*
           * 方法名称：ValidateSite( )
           * 方法功能描述：查询要插入的地点是否存在;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-06
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool ValidateSite(string site)
        {
            return optionDB.ValidateSite(site);
        }
        /*
        * 方法名称：SearchSite( )
        * 方法功能描述：查询地点所有信息;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-02
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable SearchSite()
        {
            return optionDB.SearchSite();
        }
        /*
           * 方法名称：SearchMethod( )
           * 方法功能描述：查询运输结算方式所有信息;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-06
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public DataTable SearchMethod()
        {
            return optionDB.SearchMethod();
        }
        /*
       * 方法名称：ValidateMethod( )
       * 方法功能描述：查询要插入的结算方式是否存在;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-06
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool ValidateMethod(string method)
        {
            return optionDB.ValidateMethod(method);
        }
        /*
           * 方法名称：Insert( )
           * 方法功能描述：插入;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-06
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool Insert(OptionClass optionClass)
        {
            return optionDB.Insert(optionClass);
        }
        /*
           * 方法名称：ValidatePosition( )
           * 方法功能描述：查询要插入的职位是否存在;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-06
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool ValidatePosition(string position)
        {
            return optionDB.ValidatePosition(position);
        }
    }
    #endregion

    #region 数据比对逻辑层方法
    /*
        * 类名称：MonitorDB
        * 类功能描述：数据比对数据方法
        *
        * 创建人：冯雪
        * 创建时间：2009-04-16
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
    class MonitorLogin
    {
        MonitorDB monitor = new MonitorDB();
        /*
       * 方法名称：Search_mixturePSsell( )
       * 方法功能描述：查询混合料生产量与销售量对比;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-16
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable Search_mixturePSsell(string where)
        {
            return monitor.Search_mixturePSsell(where);
        }

        /*
       * 方法名称：Search_eino()
       * 方法功能描述：查询设备编号;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-16
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable Search_eino(bool state)
        {
            return monitor.Search_eino(state);
        }

        /*
       * 方法名称：where( )
       * 方法功能描述：生成查询语句方法;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-16
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public string where(long eiid, string date_being, string date_end)
        {
            return monitor.where(eiid,date_being,date_end);
        }

        /*
       * 方法名称：Search_PMonitor( )
       * 方法功能描述：查询混合料生产不合格记录;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-16
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable Search_PMonitor(string where)
        {
            return monitor.Search_PMonitor(where);
        }

        /*
       * 方法名称：Search_materialTest( )
       * 方法功能描述：查询材料检测频率与实际对照;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-17
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable Search_materialTest(string sql_where)
        {
            return monitor.Search_materialTest(sql_where);
        }

        /*
       * 方法名称：Search_productTest( )
       * 方法功能描述：查询产品检测频率与实际对照;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-17
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable Search_productTest(string sql_where)
        {
            return monitor.Search_productTest(sql_where);
        }

        /*
       * 方法名称：Search_TemperatureValue( )
       * 方法功能描述：查询温度历史记录,用于画温度曲线;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-17
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable Search_TemperatureValue(long tId, string data)
        {
            return monitor.Search_TemperatureValue(tId, data);
        }

        /*
       * 方法名称：Search_TestGuideline( )
       * 方法功能描述：查询检测指标;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-17
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable Search_TestGuideline(int state)
        {
            return monitor.Search_TestGuideline(state);
        }

        /*
       * 方法名称：Test_where( )
       * 方法功能描述：生成检测频率查询语句方法;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-17
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public string Test_where(string data_begin, string data_end, string guide_line, int id, int state)
        {
            return monitor.Test_where(data_begin,data_end,guide_line,id,state);
        }

        /*
       * 方法名称：Search_T_NoName( )
       * 方法功能描述：查询所有温度计的名称和编号方法;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-17
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable Search_T_NoName()
        {
            return monitor.Search_T_NoName();
        }

        /*
       * 方法名称：Search_TName( )
       * 方法功能描述：根据温度编号查询温度名称方法;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-19
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public string Search_TName(long tid)
        {
            return monitor.Search_TName(tid);
        }

        /*
       * 方法名称：Stat_FlowmeterStat( )
       * 方法功能描述：查询所有流量计的此时间段内的累计流量值;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-21
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable Stat_FlowmeterStat(string begin_data, string end_data)
        {
            return monitor.Stat_FlowmeterStat(begin_data, end_data);
        }
    }
    #endregion

    #region  //车卡信息业务类
    /*
      * 类名称：BindInfoLogic
      * 类功能描述：车卡信息业务类
      *
      * 创建人：袁宇
      * 创建时间：2009-02-26
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class BindInfoLogic
    {
        BindinfoDBlayer dbLayer = new BindinfoDBlayer();
        // 实例化一个凯泰读卡接口;
        ICardHelper iCardHelper = CardFactory.Creat();

        /*
         * 方法名称：GetBindInfo()
         * 方法功能描述：用于查询已绑定卡信息,无查询条件
         *
         * 创建人：袁宇
         * 创建时间：2009-02-26
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataSet GetBindInfo()
        {
            DataSet ds = new DataSet();

            ds = dbLayer.SelectBindInfo("", "", "");
            return ds;
        }
        /*
         * 方法名称：GetBindInfo()
         * 方法功能描述：用于查询已绑定卡信息 有查询条件
         * 参数: unit 运输单位
         *       cardNo 卡号
         *       truckNo 车牌号
         * 创建人：袁宇
         * 创建时间：2009-02-26
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public DataSet GetBindInfo(string unit, string truckNo, string cardNo)
        {
            DataSet ds = new DataSet();

            ds = dbLayer.SelectBindInfo(unit, truckNo, cardNo);
            return ds;
        }
        /*
         * 方法名称：CreateCardNo()
         * 方法功能描述：创建一个新卡号,以微秒为单位
         * 
         * 返回: string 一个新卡号
         * 
         * 创建人：袁宇
         * 创建时间：2009-02-26
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public string CreateCardNo()
        {
            string year = System.DateTime.Now.Year.ToString();
            string month = System.DateTime.Now.Month.ToString("00");
            string day = System.DateTime.Now.Day.ToString("00");
            string hour = System.DateTime.Now.Hour.ToString("00");
            string minute = System.DateTime.Now.Minute.ToString("00");
            string millisecond = System.DateTime.Now.Millisecond.ToString();

            string Rec = "";
            Rec = year + month + day + hour + minute + millisecond;
            int count = Rec.Length;

            for (int i = 1; i <= 15 - count; i++)
                Rec += "0";
            return Rec;
        }
        /*
        * 方法名称：BindCardNo()
        * 方法功能描述：卡号与车号的绑定操作,
        *
        * 创建人：袁宇
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool BindCardNo(string truckNo, string cardNo)
        {
            if ((truckNo.Trim() != "") && (cardNo.Trim() != ""))
            {
                if (dbLayer.IsExistence(truckNo))
                {
                    return dbLayer.UpdateCardInfo(truckNo, cardNo);
                }
                else
                {
                    return dbLayer.InsertCardInfo(truckNo, cardNo);
                }
            }
            return false;
        }
        /*
        * 方法名称：SetTransportUnit()
        * 方法功能描述：设置运输单位信息下拉值
        *
        * 创建人：袁宇
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void SetTransportUnit(ref ComboBox cb)
        {
            cb.DataSource = dbLayer.GetTransportUnitItem();
            cb.DisplayMember = "name";
            cb.ValueMember = "id";

        }
        /*
        * 方法名称：SetVoitureNo()
        * 方法功能描述：设置运输单位信息下拉值
        * 参数: cb 车牌号码具体combobox
        *       unit 运输单位信息
        * 创建人：袁宇
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void SetVoitureNo(ref ComboBox cb, string unit)
        {
            cb.DataSource = dbLayer.GetVoitureNoItem(unit);
            cb.DisplayMember = "no";
            cb.ValueMember = "id";
            cb.SelectedIndex = -1;
        }
        /*
        * 方法名称：GetTruckInfo()
        * 方法功能描述：通过车牌号取得车辆信息
        * 参数: truckNo 车牌号
        *       
        * 创建人：袁宇
        * 创建时间：2009-02-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public BindInfoClass GetTruckInfo(string truckNo)
        {
            return dbLayer.SelecttruckInfo(truckNo);
        }
        /*
         * 方法名称：ClearCombobox()
         * 方法功能描述：清空界面所有车辆信息
         * 参数: tag 要清空控件的tag值
         *       
         * 创建人：袁宇
         * 创建时间：2009-02-28
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
        public void ClearCombobox(string tag, ref GroupBox gb)
        {
            ComboBox mycbx;
            int len, i;

            len = gb.Controls.Count;
            for (i = 0; i < len; i++)
            {
                if (gb.Controls[i] is ComboBox)
                {
                    mycbx = ((ComboBox)gb.Controls[i]);
                    if ((mycbx.Tag != null) && (mycbx.Tag.ToString().Equals(tag)))
                        mycbx.Text = "";

                }
            }

        }
        /*
         * 方法名称：WriteCard()
         * 方法功能描述：写卡
         * 参数: cardNo 写卡内空
         *       
         * 创建人：袁宇
         * 创建时间：2009-02-28
         *
         * 修改人： 冯雪
         * 修改时间：2009-03-29
         * 修改内容：换为凯态家的读卡器,重写的写卡方法;
         *
         */
        public bool WriteCard(string cardNo)
        {
            #region 以前读卡器写卡代码
            //int icdev;
            //string hexkey = "ffffffffffff";
            ////装入密码模式
            //int mode = 0;
            ////第一个扇区装载密码
            //int secor = 1;
            ////读卡扇区
            //byte sector = 0;
            ////寻卡模式，可返复写卡
            //byte cardmode = 1;
            ////卡序号
            //ulong tempint = 0;
            ////地址，*4
            //int address = 2;
           
            //StringBuilder str = new StringBuilder();
            //str.Append(cardNo + "00000000000000000");

            //icdev = CardClass.dc_init(0, 115200);
            //if (icdev > 0)
            //{
            //    if (CardClass.dc_load_key_hex(icdev, mode, secor, hexkey) == 0)
            //    {
            //        CardClass.dc_card(icdev, cardmode, ref tempint);
            //        if (CardClass.dc_authentication(icdev, 0, sector) == 0)
            //        {
            //            if (CardClass.dc_write_hex(icdev, address, str) == 0)
            //            {
            //                CardClass.dc_beep(icdev, 10);
            //                return true;
            //            }
            //        }
            //    }
            //}
            //return false;
            #endregion

            // 串口号;
            int ComPort = 1;
            // 扇区号;
            int SectorNo = 1;
            // 块号;
            int BlockNo = 2;
            // 要写入的数据;
            byte[] CardData = new byte[64];
            cardNo = cardNo + "00000000000000000";
            // 将要写的的数据转换为字符数组;
            char[] card = cardNo.ToCharArray();
            // 将字符数组转换为字节数组;
            for (int j = 0; j < 32; j++)
            {
                CardData[j] = decimal.ToByte(card[j]);
            }

            if (iCardHelper.Card_WriteDate(ComPort, SectorNo, BlockNo, CardData) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * 方法名称：ReadCard()
         * 方法功能描述：读卡中存储的卡号;
         *       
         * 创建人：袁宇
         * 创建时间：2009-02-28
         *
         * 修改人： 冯雪
         * 修改时间：2009-03-29
         * 修改内容：换为凯态家的读卡器,重写的读卡方法;
         *
         */
        public string ReadCard()
        {
            // 用来存储读出的数据;
            byte[] CardData = new byte[64];
            string data = "";
            // 串口号;
            int ComPort = 1;
            // 扇区号;
            int SectorNo = 1;
            // 块号;
            int BlockNo = 2; 

            if (iCardHelper.Card_ReadDate(ComPort, SectorNo, BlockNo, CardData) == 1)
            {
                for (int i = 0; i < 32; i++)
                {
                    string s = (Convert.ToChar(CardData[i])).ToString();
                    data = data + s;
                }
            }
            return data;
        }

        /*
         * 方法名称：Cardblankout()
         * 方法功能描述：删除卡绑定信息
         * 参数: id 卡信息表Id号
         *       
         * 创建人：袁宇
         * 创建时间：2009-02-28
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         */
        public bool Cardblankout(string id)
        {
            return dbLayer.DeleteCardInfo(id);

        }
    }
    #endregion

    #region 材料窗体逻辑层方法
    /*
      * 类名称：MaterialLogic
      * 类功能描述：材料窗体逻辑层方法
      *
      * 创建人：冯雪
      * 创建时间：2009-02-23
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class MaterialLogic
    {
        MaterialDB materialDB = new MaterialDB();
        /*
        * 方法名称：InitialMKindComboBox()
        * 方法功能描述：查询所有材料种类;
        *
        * 创建人：冯雪
        * 创建时间：2009-02-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable InitialMKindComboBox()
        {
            return materialDB.InitialMKindComboBox();
        }
        /*
        * 方法名称：InitialMNameComboBox()
        * 方法功能描述：查询该材料种类下的所有材料名称;
        *
        * 创建人：冯雪
        * 创建时间：2009-02-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable InitialMNameComboBox(int mkId)
        {
            return materialDB.InitialMNameComboBox(mkId);
        }
        /*
       * 方法名称：InitialMModelComboBox()
       * 方法功能描述：查询该材料种类下的所有材料名称;
       *
       * 创建人：冯雪
       * 创建时间：2009-02-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable InitialMModelComboBox(int mnId)
        {
            return materialDB.InitialMModelComboBox(mnId);
        }
        /*
       * 方法名称：FrmMaterialInsert( )
       * 方法功能描述：向材料名称规格对应表中插入数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmMaterialInsert(MaterialClass materialClass)
        {
            return materialDB.FrmMaterialInsert(materialClass);
        }
        /*
      * 方法名称：MSearchNameModel( )
      * 方法功能描述：查询要插入的字段在表中是否存在;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-02
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool MSearchNameModel(int mnid, int mmid)
        {
            return materialDB.MSearchNameModel(mnid, mmid);
        }
        /*
       * 方法名称：MSearchAll( )
       * 方法功能描述：查询材料所在信息;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable MSearchAll(string condition, int verifyBit)
        {
            return materialDB.MSearchAll(condition, verifyBit);
        }
        /*
       * 方法名称：FrmMaterialDelete( )
       * 方法功能描述：材料对应表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmMaterialDelete(int mId)
        {
            return materialDB.FrmMaterialDelete(mId);
        }
        /*
      * 方法名称：MSearchNameModel( )
      * 方法功能描述：查询要插入的字段在材料表中的ID;
      *
      * 创建人：冯雪
      * 创建时间：2009-03-02
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public int MaterialSearch(int mnid, int mmid)
        {
            return materialDB.MaterialSearch(mnid, mmid);
        }
        /*
          * 方法名称：MaterialUpdate( )
          * 方法功能描述：修改记录信息;
          *
          * 创建人：冯雪
          * 创建时间：2009-04-14
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
        public bool MaterialUpdate(MaterialClass materialClass)
        {
            return materialDB.MaterialUpdate(materialClass);
        }

    }
    #endregion

    #region  产品窗体逻辑层方法
    /*
      * 类名称：ProductLogic
      * 类功能描述：产品窗体逻辑层方法
      *
      * 创建人：冯雪
      * 创建时间：2009-02-23
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class ProductLogic
    {
        ProductDB productDB = new ProductDB();

        /*
       * 方法名称：
       * 方法功能描述：初始化制作人
       *
       * 创建人：付中华
       * 创建时间：2009-04-17
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable makerComboboxLogic()
        {
            return productDB.makerComboboxDb();
        }
        /*
        * 方法名称：InitialPKindComboBox()
        * 方法功能描述：查询所有产品种类;
        *
        * 创建人：冯雪
        * 创建时间：2009-02-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable InitialPKindComboBox()
        {
            return productDB.InitialPKindComboBox();
        }       
        /*
        * 方法名称：InitialMNameComboBox()
        * 方法功能描述：查询该产品种类下的所有产品名称;
        *
        * 创建人：冯雪
        * 创建时间：2009-02-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable InitialPNameComboBox(int pkId)
        {
            return productDB.InitialPNameComboBox(pkId);
        }
        /*
       * 方法名称：InitialPModelComboBox()
       * 方法功能描述：查询该产品名称下的所有材料规格;
       *
       * 创建人：冯雪
       * 创建时间：2009-02-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable InitialPModelComboBox(int pnId)
        {
            return productDB.InitialPModelComboBox(pnId);
        }
        /*
       * 方法名称：FrmPoeductInsert( )
       * 方法功能描述：向产品名称规格对应表中插入数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmPoeductInsert(ProductClass productClass)
        {
            return productDB.FrmPoeductInsert(productClass);
        }
        /*
       * 方法名称：PSearchNameModel( )
       * 方法功能描述：查询要插入的字段在表中是否存在;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool PSearchNameModel(int pnid, int pmid)
        {
            return productDB.PSearchNameModel(pnid, pmid);
        }
        /*
           * 方法名称：PSearchID( )
           * 方法功能描述：查询该编号规格在产品表中的ID;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-02
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public int PSearchID(int pnid, int pmid)
        {
            return productDB.PSearchID(pnid, pmid);
        }
        /*
       * 方法名称：PSearchAll( )
       * 方法功能描述：查询产品所在信息;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable PSearchAll(string condition, int verifyBit)
        {
            return productDB.PSearchAll(condition, verifyBit);
        }
        /*
       * 方法名称：FrmPoeductDelete( )
       * 方法功能描述：向产品应表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmPoeductDelete(int pId)
        {
            return productDB.FrmPoeductDelete(pId);
        }
        /*
           * 方法名称：FrmPoeductUpdate( )
           * 方法功能描述：向产品表中更新数据;
           *
           * 创建人：冯雪
           * 创建时间：2009-04-14
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool FrmPoeductUpdate(ProductClass productClass)
        {
            return productDB.FrmPoeductUpdate(productClass);
        }
    }
    #endregion

    #region 维护材料、产品 类别、名称 窗体逻辑层方法
    /*
      * 类名称：VindicateLogic
      * 类功能描述：维护材料、产品 类别、名称 窗体逻辑层方法
      *
      * 创建人：冯雪
      * 创建时间：2009-02-23
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class VindicateLogic
    {
        VindicateDB vindicateDB = new VindicateDB();
        //以下是产品信息操作；
        /*
        * 方法名称：PKindInsert()
        * 方法功能描述：插入产品种类;
        *
        * 创建人：冯雪
        * 创建时间：2009-02-28
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool PKindInsert(ProductClass productclass)
        {
            return vindicateDB.PKindInsert(productclass);
        }
        /*
       * 方法名称：PNameInsert( )
       * 方法功能描述：向产品名称表中插入数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-02-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool PNameInsert(ProductClass productclass)
        {
            return vindicateDB.PNameInsert(productclass);
        }
        /*
       * 方法名称：PModelInsert( )
       * 方法功能描述：向产品名称表中插入数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-02-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool PModelInsert(ProductClass productclass)
        {
            return vindicateDB.PModelInsert(productclass);
        }
        /*
       * 方法名称：PKindDelete( )
       * 方法功能描述：在产品种类表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool PKindDelete(int pkId)
        {
            return vindicateDB.PKindDelete(pkId);
        }
        /*
       * 方法名称：PNameDelete( )
       * 方法功能描述：在产品名称表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool PNameDelete(int pnId)
        {
            return vindicateDB.PNameDelete(pnId);
        }
        /*
       * 方法名称：PModleDelete( )
       * 方法功能描述：在规格型号表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool PModleDelete(int pmId)
        {
            return vindicateDB.PModleDelete(pmId);
        }
        /*
       * 方法名称：PSearchName( )
       * 方法功能描述：查询要插入的字段在表中是否存在;
       *
       * 创建人：冯雪
       * 创建时间：2009-02-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool PSearchName(string Pname, int verifyBit)
        {
            return vindicateDB.PSearchName(Pname, verifyBit);
        }
        /*
       * 方法名称：PModelSearch()
       * 方法功能描述：查询所有产品名称;
       *
       * 创建人：冯雪
       * 创建时间：2009-02-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable PModelSearch()
        {
            return vindicateDB.PModelSearch();
        }
        //以下是材料信息操作；
        /*
       * 方法名称：MKindInsert( )
       * 方法功能描述：向材料种类表中插入数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-02-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool MKindInsert(MaterialClass materialClass)
        {
            return vindicateDB.MKindInsert(materialClass);
        }
        /*
       * 方法名称：MNameInsert( )
       * 方法功能描述：向材料名称表中插入数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-02-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool MNameInsert(MaterialClass materialClass)
        {
            return vindicateDB.MNameInsert(materialClass);
        }
        /*
       * 方法名称：MModleInsert( )
       * 方法功能描述：向材料规格表中插入数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-02-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool MModleInsert(MaterialClass materialClass)
        {
            return vindicateDB.MModleInsert(materialClass);
        }
        /*
       * 方法名称：MKindDelete( )
       * 方法功能描述：在材料种类表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool MKindDelete(int mkId)
        {
            return vindicateDB.MKindDelete(mkId);
        }
        /*
       * 方法名称：MNameDelete( )
       * 方法功能描述：在材料名称表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool MNameDelete(int mnId)
        {
            return vindicateDB.MNameDelete(mnId);
        }
        /*
       * 方法名称：MModleDelete( )
       * 方法功能描述：在规格型号表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-02
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool MModleDelete(int mmId)
        {
            return vindicateDB.MModleDelete(mmId);
        }
        /*
       * 方法名称：MModelSearch()
       * 方法功能描述：查询所有材料规格名称;
       *
       * 创建人：冯雪
       * 创建时间：2009-02-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable MModelSearch()
        {
            return vindicateDB.MModelSearch();
        }
    }

    #endregion

    #region 生产厂家逻辑层方法
    /*
     * 类名称：ProducerLogic
     * 类功能描述：生产厂家窗体逻辑层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-04
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class ProducerLogic
    {
        ProducerDB producerDB = new ProducerDB();

        /*
       * 方法名称：SearchProducerName( )
       * 方法功能描述：查询要插入的生产厂家在表中是否存在;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-04
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool SearchProducerName(string producerName)
        {
            return producerDB.SearchProducerName(producerName);
        }
        /*
       * 方法名称：SearchProducerAll( )
       * 方法功能描述：查询生产厂家在表中所有信息;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-04
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable SearchProducerAll(string pName, int verifyBit)
        {
            return producerDB.SearchProducerAll(pName, verifyBit);
        }
        /*
       * 方法名称：FrmProducerInsert( )
       * 方法功能描述：向生产厂家表中插入数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-04
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmProducerInsert(ProducerClass producerClass)
        {
            return producerDB.FrmProducerInsert(producerClass);
        }
        /*
       * 方法名称：FrmProducerDelete( )
       * 方法功能描述：向生产厂家表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-04
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmProducerDelete(int producerId)
        {
            return producerDB.FrmProducerDelete(producerId);
        }
    }
    #endregion

    #region 客户信息窗体逻辑层方法
    /// <summary>
    /// 客户信息窗体逻辑层方法
    /// </summary>  

    /*
    * 类名称：ClientLogic
    * 类功能描述：客户信息窗体逻辑层方法
    *
    * 创建人：冯雪
    * 创建时间：2009-03-06
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class ClientLogic
    {
        ClientDB clientDB = new ClientDB();

        /*
           * 方法名称：SearchClientAll( )
           * 方法功能描述：查询客户信息表中所有信息;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-06
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public DataTable SearchClientAll(string condition)
        {
            return clientDB.SearchClientAll(condition);
        }
        /*
           * 方法名称：InitComboBox( )
           * 方法功能描述：查询客户信息表中所有负责人、邮编;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-05
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public DataTable InitComboBox(int state)
        {
            return clientDB.InitComboBox(state);
        }
        /*
           * 方法名称：SearchClientName( )
           * 方法功能描述：查询要插入的字段在客户信息表中是否存在;
           *
           * 创建人：冯雪
           * 创建时间：2009-03-06
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool SearchClientName(string name)
        {
            return clientDB.SearchClientName(name);
        }
        /*
        * 方法名称：FrmCliientInsert( )
        * 方法功能描述：向客户信息表中插入数据;
        *
        * 创建人：冯雪
        * 创建时间：2009-03-06
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmCliientInsert(ClientClass clientClass)
        {
            return clientDB.FrmCliientInsert(clientClass);
        }
        /*
       * 方法名称：FrmCliientDelete( )
       * 方法功能描述：向客户信息表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-06
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmCliientDelete(int clientId)
        {
            return clientDB.FrmCliientDelete(clientId);
        }
        /*
           * 方法名称：FrmCliientUpdate( )
           * 方法功能描述：向客户信息表中更新数据;
           *
           * 创建人：冯雪
           * 创建时间：2009-04-14
           *
           * 修改人：
           * 修改时间：
           * 修改内容：
           *
           */
        public bool FrmCliientUpdate(ClientClass clientClass)
        {
            return clientDB.FrmCliientUpdate(clientClass);
        }
    }
    #endregion

    /// <summary>
    /// 业务逻辑类warehouseInfo 的摘要说明。
    /// </summary>
    public class WarehouseInfo
    {
        warehouseInfoAction dal = new warehouseInfoAction();

        public WarehouseInfo()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(warehouseInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(warehouseInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long id)
        {

            dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public warehouseInfo GetModel(long id)
        {
            return dal.GetModel(id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得所有数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        #endregion  成员方法
    }

    /// <summary>
    /// 业务逻辑类projectName 的摘要说明。
    /// </summary>
    public class ProjectName
    {
        projectNameAction dal = new projectNameAction();
        public ProjectName()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(projectName model)
        {
            return dal.Add(model);
        }
        public bool selectItems(projectName model)
        {
            return dal.selectItems(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(projectName model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long id)
        {

            dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public projectName GetModel(long id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        #endregion  成员方法
    }

    /// <summary>
    /// 业务逻辑类basicInfo 的摘要说明。
    /// </summary>
    public class BasicInfo
    {
       basicInfoAction dal = new basicInfoAction();
        public BasicInfo()
        { }
        #region  成员方法

        /// <summary>
        /// 有则更新无则插入
        /// </summary>
        /// <param name="model">数据对象</param>
        public void UpdateOrInsert(basicInfo model)
        {
            if (dal.Exists())
            {
                Update(model);
            }
            else
            {
                Add(model);
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(basicInfo model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(basicInfo model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public basicInfo GetModel()
        {
            
            return dal.GetModel();
        }

        #endregion  成员方法
    }

}
