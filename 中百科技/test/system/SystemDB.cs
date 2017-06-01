using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DasherStation.common;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.IO;
using sqldmo;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;

namespace DasherStation.system
{
    class SystemDB
    {

        SqlHelper sqlHelper = new SqlHelper();



        #region 登录时,检查用户名是否存在
        /// <summary>
        /// 检查输入的用户名是否存在
        /// </summary>
        /// <param name="username"> 用户名</param>
        /// <returns>false 不存在</returns>
        public bool Search_username(string username)
        {
            string lSearchStr = "SELECT * FROM usersInfo WHERE name = '" + username + "'";

            DataTable dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 登录时,检查用户密码是否正确
        /// <summary>
        /// 检查用户密码是否正确
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>false 密码错误,true 密码正确</returns>
        public bool Search_password(string username, string password)
        {
            string lSearchStr = " SELECT * FROM usersInfo WHERE name = '" + username + "' and password = '" + password + "'";

            DataTable dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 登录时,检查用户的权限;
        /// <summary>
        /// 登录时,检查用户名,密码 
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>返回其权限信息</returns>
        public DataSet Check_Purview(string username)
        {
            string lSearchStr = " select m.id,m.name,controlName,visible ";
            lSearchStr = lSearchStr + " from menu m,userPopedomCorresponding up,usersInfo ui ";
            lSearchStr = lSearchStr + " where m.type=1 and m.id=up.mid and up.uiid=ui.id and ui.username='" + username + "'";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr });
        }
        #endregion

        #region 查询用户所有按钮
        /// <summary>
        /// 查询用户所有按钮
        /// </summary>
        /// <param name="username"> 用户名</param>
        /// <returns></returns>
        public DataSet Open_Frm(string name)
        {
            string lSearchStr = " select m.id,m.name,controlName,visible ";
            lSearchStr = lSearchStr + " from menu m,userPopedomCorresponding up,usersInfo ui ";
            lSearchStr = lSearchStr + " where m.type=2 and m.id=up.mid and up.uiid=ui.id and parentId=(select top 1 id from menu where controlName='" + name + "')";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr });
        }
        #endregion

        #region //用户信息
        DataSet ds = new DataSet();

        SqlHelper sqlHelperObj = new SqlHelper();
        /*
        * 方法名称：FrmUserInfoSearch
        * 方法功能描述：根据用户查询信息返回用户查询所得数据集
        *
        * 创建人：夏阳明
        * 创建时间：20090214
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet FrmUserInfoSearch(string searchStr, int verifyBit, DataGridView dgv)
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("usersInfo");
            linkS.TableNames.Add("position");
            linkS.LinkConds.Add("usersInfo.pId=position.id");
            linkS.Viewfields.Add("usersInfo.id");
            linkS.Viewfields.Add("'*********' as password");
            linkS.Viewfields.Add("usersInfo.name");
            linkS.Viewfields.Add("case sex when 1 then '男' when 2 then '女' else '男'end as sex");
            linkS.Viewfields.Add("age");
            linkS.Viewfields.Add("position.name as positionname");
            if (verifyBit == 0)
            {
                linkS.Conds.Add("usersInfo.name like '%" + searchStr + "%'");
            }
            return linkS.LeftLinkOpen();

            //string locsearchStr;

            ////如果真实姓名输入为空，查询全部
            //if (verifyBit == 1)
            //{
            //    locsearchStr = "select usersInfo.id,userName,'*********' as password,usersInfo.name,case sex when 1 then '男' when 2 then '女' ";
            //    locsearchStr = locsearchStr + "else '男'end as sex, age,position.name as positionname from usersInfo,position where ";
            //    locsearchStr = locsearchStr + "usersInfo.pId = position.id";

            //    ds = sqlHelperObj.QueryForDateSet(new ArrayList() { locsearchStr });
            //}
            ////按用户输入的真实姓名进行模糊查询
            //else if (verifyBit == 0)
            //{
            //    locsearchStr = "select usersInfo.id,userName,'*********' as password,usersInfo.name,case sex when 1 then '男' when 2 then '女' ";
            //    locsearchStr = locsearchStr + "else '男' end as sex, age,position.name as positionname from usersInfo,position where ";
            //    locsearchStr = locsearchStr + "usersInfo.pId = position.id and usersInfo.name like '%" + searchStr + "%'";

            //    ds = sqlHelperObj.QueryForDateSet(new ArrayList() { locsearchStr });
            //}

            //return ds;
        }
        /*
        * 方法名称：InitialCbxDuty
        * 方法功能描述：查询数据库并返回数据集
        *
        * 创建人：夏阳明
        * 创建时间：20090214
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet InitialCbxDuty()
        {
            string locSearchStr;

            locSearchStr = "select * from position";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList() { locSearchStr });

            return ds;
        }
        /*
        * 方法名称：FrmUserInfoSave
        * 方法功能描述：插入数据库操作并返回bool值（true为成功，false为失败）
         * *
        * 创建人：夏阳明
        * 创建时间：20090214
        *
        * 修改人：
        * 修改时间：
         * * 修改内容：
        *
        */
        public bool FrmUserInfoSave(UserInfoClass userInfoClass)
        {
            DataVar var = new DataVar();
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();

            if (!string.IsNullOrEmpty(userInfoClass.UserName))
            {
                fields.Add("userName");
                values.Add("'" + userInfoClass.UserName + "'");
            }

            if (!string.IsNullOrEmpty(userInfoClass.Password))
            {
                fields.Add("password");
                values.Add("'" + userInfoClass.Password + "'");
            }
            if (!string.IsNullOrEmpty(userInfoClass.Name))
            {
                fields.Add("Name");
                values.Add("'" + userInfoClass.Name + "'");
            }
            if (!string.IsNullOrEmpty(userInfoClass.Sex))
            {
                fields.Add("sex");
                values.Add(userInfoClass.Sex);
            }
            if (!string.IsNullOrEmpty(userInfoClass.Age))
            {
                fields.Add("age");
                values.Add(userInfoClass.Age);
            }
            if (!string.IsNullOrEmpty(userInfoClass.Duty))
            {
                fields.Add("pId");
                values.Add("'" + userInfoClass.Duty + "'");
            }
            return var.InsertTable("usersInfo", fields, values);

            //string locInsertStr;

            //bool status;

            //locInsertStr = "insert into usersInfo (userName,password,name,sex,age,pId) values('" + userInfoClass.UserName;
            //locInsertStr = locInsertStr + "','" + userInfoClass.Password + "','" + userInfoClass.Name + "',";
            //locInsertStr = locInsertStr + userInfoClass.Sex + "," + userInfoClass.Age + "," + userInfoClass.Duty + ")";

            //status = sqlHelperObj.Insert(new ArrayList() { locInsertStr });

            //return status;

        }
        /*
        * 方法名称：FrmUserInfoUpdate
        * 方法功能描述：更新数据库操作并返回bool值（true为成功，false为失败）
        *
        * 创建人：夏阳明
        * 创建时间：20090216
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmUserInfoUpdate(UserInfoClass userInfoClass, int id)
        {

            DataVar var = new DataVar();
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            ArrayList conds = new ArrayList();

            if (!string.IsNullOrEmpty(userInfoClass.UserName))
            {
                fields.Add("userName");
                values.Add("'" + userInfoClass.UserName + "'");
            }

            if (!string.IsNullOrEmpty(userInfoClass.Password))
            {
                fields.Add("password");
                values.Add("'" + userInfoClass.Password + "'");
            }
            if (!string.IsNullOrEmpty(userInfoClass.Name))
            {
                fields.Add("Name");
                values.Add("'" + userInfoClass.Name + "'");
            }
            if (!string.IsNullOrEmpty(userInfoClass.Sex))
            {
                fields.Add("sex");
                values.Add(userInfoClass.Sex);
            }
            if (!string.IsNullOrEmpty(userInfoClass.Age))
            {
                fields.Add("age");
                values.Add(userInfoClass.Age);
            }
            if (!string.IsNullOrEmpty(userInfoClass.Duty))
            {
                fields.Add("pId");
                values.Add("'" + userInfoClass.Duty + "'");
            }
            conds.Add("id=" + id);

            return var.UpdateTeble("usersInfo", fields, values, conds);
            //string locUpdateStr;

            //bool status;

            //locUpdateStr = "update usersInfo set userName = '" + userInfoClass.UserName;
            //locUpdateStr = locUpdateStr + "',password = '" + userInfoClass.Password;
            //locUpdateStr = locUpdateStr + "',name = '" + userInfoClass.Name + "',sex = ";
            //locUpdateStr = locUpdateStr + userInfoClass.Sex + ",age = " + userInfoClass.Age;
            //locUpdateStr = locUpdateStr + ",pId = " + userInfoClass.Duty + "where id = ";
            //locUpdateStr = locUpdateStr + id;

            //status = sqlHelperObj.Update(new ArrayList() { locUpdateStr });

            //return status;

        }
        /*
        * 方法名称：FrmUserInfoUpdate
        * 方法功能描述：更新数据库操作并返回bool值（true为成功，false为失败）
        *
        * 创建人：夏阳明
        * 创建时间：20090216
        *
        * 修改人：
         * * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmUserInfoUpdateForDelete(int id)
        {
            string locUpdateStr;

            bool status;

            locUpdateStr = "delete from usersInfo where usersInfo.id = " + id;

            status = sqlHelperObj.Delete(new ArrayList() { locUpdateStr });

            return status;
        }
        /*
        * 方法名称：FrmUserInfoSearchAll
        * 方法功能描述：查询所有用户信息
        *
        * 创建人：夏阳明
        * 创建时间：20090214
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet FrmUserInfoSearchAll()
        {
            LinkSelect linkS = new LinkSelect();

            linkS.TableNames.Add("usersInfo");
            linkS.TableNames.Add("position");
            linkS.LinkConds.Add("usersInfo.pId=position.id");
            linkS.Viewfields.Add("usersInfo.id");
            linkS.Viewfields.Add("'*********' as password");
            linkS.Viewfields.Add("usersInfo.name");
            linkS.Viewfields.Add("case sex when 1 then '男' when 2 then '女' else '男'end as sex");
            linkS.Viewfields.Add("age");
            linkS.Viewfields.Add("position.name as positionname");

            linkS.LeftLinkOpen();

            //string locsearchStr;

            //locsearchStr = "select usersInfo.id,userName,'*********' as password,usersInfo.name,case sex when 1 then '男' when 2 then '女' ";
            //locsearchStr = locsearchStr + "else '男'end as sex, age,position.name as positionname from usersInfo,position where ";
            //locsearchStr = locsearchStr + "usersInfo.pId = position.id";

            //ds = sqlHelperObj.QueryForDateSet(new ArrayList() { locsearchStr });

            return linkS.LeftLinkOpen();
        }
        /*
        * 方法名称：FrmUserInfoSearchForUserName
        * 方法功能描述：查询所有符合条件的用户信息
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
            string locsearchStr;

            locsearchStr = "select * from usersInfo where userName = '" + userName + "'";

            ds = sqlHelperObj.QueryForDateSet(new ArrayList() { locsearchStr });

            if (ds.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }


    #region 车辆信息窗体数据层方法
    /*
         * 类名称：TruckDB
         * 类功能描述：车辆信息窗体数据层方法
         *
         * 创建人：冯雪
         * 创建时间：2009-02-25
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
    class TruckDB
    {
        SqlHelper sqlHelper = new SqlHelper();

        public DataTable FrmTruckSearch(string condition, int verifyBit)
        {
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("voitureInfo.id");
            ls.Viewfields.Add("voitureInfo.no as 车牌号");
            ls.Viewfields.Add("transportUnit.name as 运输单位");
            ls.Viewfields.Add("voitureInfo.owner as 车主姓名");
            ls.Viewfields.Add("voitureInfo.driverName as 司机姓名");
            ls.Viewfields.Add("voitureInfo.model as 车辆型号");
            ls.Viewfields.Add("voitureInfo.color as 车辆颜色");
            ls.Viewfields.Add("voitureInfo.lenth as 车辆货箱长度");
            ls.Viewfields.Add("voitureInfo.width as 车辆货箱宽度");
            ls.Viewfields.Add("voitureInfo.height as 车辆货箱高度");
            ls.Viewfields.Add("voitureInfo.tare as 车辆皮重");
            ls.Viewfields.Add("voitureInfo.standardTare as 标准空载重量");
            ls.Viewfields.Add("voitureInfo.standardDeadWeight as 标准载重量");
            ls.Viewfields.Add("voitureInfo.inputDate as 录入日期");
            ls.Viewfields.Add("voitureInfo.inputMan as 录入人 ");
            ls.Viewfields.Add("voitureInfo.remark as 备注");

            ls.TableNames.Add("voitureInfo");
            ls.TableNames.Add("transportUnit");
            ls.LinkConds.Add("voitureInfo.tuId = transportUnit.id");

            switch (verifyBit)
            {
                case 1:
                    {
                        ls.Conds.Add("voitureInfo.no like " + "'%" + condition + "%'");
                        break;
                    }
                case 2:
                    {
                        ls.Conds.Add("transportUnit.name like " + "'%" + condition + "%'");
                        break;
                    }
                case 3:
                    {
                        ls.Conds.Add("voitureInfo.owner like " + "'%" + condition + "%'");
                        break;
                    }
                case 4:
                    {
                        ls.Conds.Add("voitureInfo.driverName like " + "'%" + condition + "%'");
                        break;
                    }
                case 5:
                    {
                        ls.Conds.Add("voitureInfo.model like " + "'%" + condition + "%'");
                        break;
                    }
                case 6:
                    {
                        ls.Conds.Add("voitureInfo.color like " + "'%" + condition + "%'");
                        break;
                    }
            }

            return dataTable = ls.LeftLinkOpen().Tables[0];

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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "SELECT * FROM voitureInfo WHERE no = '" + no + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
        * 方法名称：InitialTruckComboBox()
        * 方法功能描述：查询所有车辆型号、颜色信息
        *
        * 创建人：冯雪
        * 创建时间：2009-03-06
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
         */
        public DataTable InitialTruckComboBox(int state)
        {
            string lSearchStr;

            lSearchStr = "select distinct ";

            switch (state)
            {
                case 1:
                    {
                        lSearchStr = lSearchStr + "model";
                        break;
                    }
                case 2:
                    {
                        lSearchStr = lSearchStr + "color";
                        break;
                    }
                case 3:
                    {
                        lSearchStr = lSearchStr + "id,no";
                        break;
                    }
            }

            lSearchStr = lSearchStr + " from voitureInfo";



            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
        * 方法名称：InitialTruckComboBox1()
        * 方法功能描述：查询所有运输单位信息
        *
        * 创建人：冯雪
        * 创建时间：2009-03-06
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable InitialTruckComboBox1()
        {
            string lSearchStr;

            lSearchStr = "select name, id from transportUnit ";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
        * 方法名称：FrmTruckInsert
        * 方法功能描述：插入数据库操作并返回bool值（true为成功，false为失败）
        *
        * 创建人：冯雪
        * 创建时间：20090214
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmTruckInsert(TruckClass truckClass)
        {
            string lInsertStr;

            lInsertStr = "INSERT INTO  voitureInfo (no ,tuId ,owner ,driverName ,model ,color ";
            lInsertStr = lInsertStr + ",lenth ,width ,height ,tare ,standardTare ,standardDeadWeight";
            lInsertStr = lInsertStr + ",inputDate, inputMan ,remark) values('" + truckClass.No + "',";
            lInsertStr = lInsertStr + truckClass.Conveyancer + ",'" + truckClass.Owner + "','" + truckClass.DriverName + "','";
            lInsertStr = lInsertStr + truckClass.Model + "','" + truckClass.Color + "'," + truckClass.Lenth;
            lInsertStr = lInsertStr + "," + truckClass.Width + "," + truckClass.Height + "," + truckClass.Tare;
            lInsertStr = lInsertStr + "," + truckClass.StandardTare + "," + truckClass.StandardDeadWeight;
            lInsertStr = lInsertStr + ",getdate(),'" + truckClass.InputMan + "','" + truckClass.Remark + " ')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
        }
        /*
        * 方法名称：FrmTruckUpdate
        * 方法功能描述：更新数据库操作并返回bool值（true为成功，false为失败）
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
            string lUpdateStr;

            lUpdateStr = "update voitureInfo set tuid = " + truckClass.Conveyancer;
            lUpdateStr = lUpdateStr + ",owner = '" + truckClass.Owner + "',driverName =  '" + truckClass.DriverName;
            lUpdateStr = lUpdateStr + "',model = '" + truckClass.Model + "',color = '" + truckClass.Color;
            lUpdateStr = lUpdateStr + "',lenth =  " + truckClass.Lenth + ",width = " + truckClass.Width;
            lUpdateStr = lUpdateStr + ",height =  " + truckClass.Height + ",tare = " + truckClass.Tare;
            lUpdateStr = lUpdateStr + ",standardTare =  " + truckClass.StandardTare + ",standardDeadWeight = " + truckClass.StandardDeadWeight;
            lUpdateStr = lUpdateStr + ",remark =  '" + truckClass.Remark + "' where id =" + truckClass.Id;

            return sqlHelper.Update(new ArrayList() { lUpdateStr });
        }
        /*
        * 方法名称：FrmTruckDelete
        * 方法功能描述：更新数据库操作并返回bool值（true为成功，false为失败）
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
            string lDeleteStr;

            lDeleteStr = "delete from voitureInfo where id = " + id;

            return sqlHelper.Update(new ArrayList() { lDeleteStr });
        }
    }

    #endregion

    #region 运输单位窗体数据层方法
    /*
         * 类名称：TransportDB
         * 类功能描述：运输单位窗体数据层方法
         *
         * 创建人：冯雪
         * 创建时间：2009-02-23
         *
         * 修改人：
         * 修改时间：
         * 修改内容：
         *
         */
    class TransportDB
    {
        SqlHelper sqlHelper = new SqlHelper();

        /*
        * 方法名称：FrmTransportSearchAll
        * 方法功能描述：查询所有用户信息
        *
        * 创建人：冯雪
        * 创建时间：2009-02-19
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable FrmTransportSearchAll(string searchStr, int verifyBit)
        {
            string lSearchStr;

            lSearchStr = "SELECT id ,name as 单位名称 ,corporation as 法人,address as 单位地址,principal as 负责人";
            lSearchStr = lSearchStr + ",phone as 联系电话,Email as Email,postCode as 邮编,capability as 运输能力";
            lSearchStr = lSearchStr + ",inputDate ,inputMan ,remark as 备注 FROM transportUnit ";

            switch (verifyBit)
            {
                case 1:
                    lSearchStr = lSearchStr + " where transportUnit.name like '%" + searchStr + "%'";
                    break;
                case 2:
                    lSearchStr = lSearchStr + " where transportUnit.corporation like '%" + searchStr + "%'";
                    break;
                case 3:
                    lSearchStr = lSearchStr + " where transportUnit.principal like '%" + searchStr + "%'";
                    break;
                default:
                    break;
            }

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr;

            lSearchStr = "select distinct ";

            switch (state)
            {
                case 1:
                    {
                        lSearchStr = lSearchStr + "principal as 负责人";
                        break;
                    }
                case 2:
                    {
                        lSearchStr = lSearchStr + "postCode as 邮编";
                        break;
                    }
            }

            lSearchStr = lSearchStr + " from transportUnit";

            return sqlHelper.QueryForDateSet(new ArrayList { lSearchStr }).Tables[0];
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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "SELECT * FROM transportUnit WHERE name = '" + name + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            string lInsertStr;

            lInsertStr = " INSERT INTO  transportUnit (name ,corporation ,address ,principal ,phone ,Email";
            lInsertStr = lInsertStr + " ,postCode ,capability ,inputDate ,inputMan ,remark) VALUES( '";
            lInsertStr = lInsertStr + transportClass.Name + "','" + transportClass.Corporation + "','";
            lInsertStr = lInsertStr + transportClass.Address + "','" + transportClass.Principal + "','";
            lInsertStr = lInsertStr + transportClass.Phone + "','" + transportClass.Email + "','";
            lInsertStr = lInsertStr + transportClass.PostCode + "','" + transportClass.Capability + "',";
            lInsertStr = lInsertStr + "getdate(),'" + transportClass.InputMan + "','";
            lInsertStr = lInsertStr + transportClass.Remark + "')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lDeleteStr;

            lDeleteStr = "DELETE FROM transportUnit WHERE id = " + transportId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
            string lUpdateStr = "UPDATE  transportUnit SET corporation = '" + transportClass.Corporation;
            lUpdateStr = lUpdateStr + "',address = '" + transportClass.Address + "',principal = '" + transportClass.Principal;
            lUpdateStr = lUpdateStr + "',phone = '" + transportClass.Phone + "',Email = '" + transportClass.Email;
            lUpdateStr = lUpdateStr + "',postCode = '" + transportClass.PostCode + "',capability = '" + transportClass.Capability;
            lUpdateStr = lUpdateStr + "',remark = '" + transportClass.Remark + "'";
            lUpdateStr = lUpdateStr + " WHERE id = " + transportClass.Id;
            return sqlHelper.Update(new ArrayList() { lUpdateStr });
        }
    }

    #endregion

    #region 供应商窗体数据层方法
    /*
      * 类名称：ProviderDB
      * 类功能描述：供应商窗体数据层方法
      *
      * 创建人：冯雪
      * 创建时间：2009-02-23
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class ProviderDB
    {
        SqlHelper sqlHelper = new SqlHelper();

        /*
        * 方法名称：FrmProviderSearch
        * 方法功能描述：按条件查询所在数据
        *
        * 创建人：冯雪
        * 创建时间：2009-02-23
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable FrmProviderSearch(string searchStr, int verifyBit)
        {
            string lSearchStr;

            lSearchStr = "select id, name as 供应商名称, artificialMan as 法人, principal as 负责人";
            lSearchStr = lSearchStr + ",case mark when 0 THEN '原材料供应商' else '备品备件供应商' end  as 供应商类型";
            lSearchStr = lSearchStr + ",produceNo as 生产许可证编号, phone as 电话, postCode as 邮编, eMail as Email, Address as 地址";
            lSearchStr = lSearchStr + ", remark as 备注 from  providerInfo";

            switch (verifyBit)
            {
                case 1:
                    lSearchStr = lSearchStr + " where providerInfo.name like '%" + searchStr + "%'";
                    break;
                case 2:
                    lSearchStr = lSearchStr + " where materialName.name like '%" + searchStr + "%'";
                    break;
                case 3:
                    lSearchStr = lSearchStr + " where providerInfo.principal like '%" + searchStr + "%'";
                    break;
                default:
                    break;
            }

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
        * 方法名称：InitialProviderComboBox()
        * 方法功能描述：查询供应商名称、法人、负责人、邮编等信息增加到下拉列表框中; 
        *
        * 创建人：冯雪
        * 创建时间：2009-02-23
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable InitialProviderComboBox(int state)
        {
            string lSearchStr;

            lSearchStr = "select distinct ";

            switch (state)
            {
                case 1:
                    {
                        lSearchStr = lSearchStr + "name";
                        break;
                    }
                case 2:
                    {
                        lSearchStr = lSearchStr + "artificialMan";
                        break;
                    }
                case 3:
                    {
                        lSearchStr = lSearchStr + "principal";
                        break;
                    }
                case 4:
                    {
                        lSearchStr = lSearchStr + "postCode";
                        break;
                    }
            }

            lSearchStr = lSearchStr + " from providerInfo ";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
        * 方法名称：FrmProviderInsert
        * 方法功能描述：插入数据库操作并返回bool值（true为成功，false为失败）
        *
        * 创建人：冯雪
        * 创建时间：20090214
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool FrmProviderInsert(ProviderClass providerClass)
        {
            string lInsertStr;

            lInsertStr = "insert into providerInfo ";
            lInsertStr = lInsertStr + "(name, artificialMan, principal, phone, postCode, eMail, Address,inputDate,produceNo,mark,inputMan, remark) ";
            lInsertStr = lInsertStr + " values('" + providerClass.Name + "','" + providerClass.ArtificialMan + "','";
            lInsertStr = lInsertStr + providerClass.Principal + "','" + providerClass.Phone + "','" + providerClass.PostCode + "','";
            lInsertStr = lInsertStr + providerClass.EMail + "','" + providerClass.Address + "',getdate(),'";
            lInsertStr = lInsertStr + providerClass.ProduceNo + "'," + providerClass.Mark + ",'";
            lInsertStr = lInsertStr + providerClass.InputMan + "','" + providerClass.Remark + " ')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lSerachStr;
            DataTable dataTable = new DataTable();

            lSerachStr = " SELECT id ,name FROM providerInfo WHERE name = '" + pname + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSerachStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            string lDeleteStr;

            lDeleteStr = "DELETE FROM providerInfo WHERE id = " + providerId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
            string lUpdateStr = "UPDATE  providerInfo SET  artificialMan = '" + providerClass.ArtificialMan;
            lUpdateStr = lUpdateStr + "',address = '" + providerClass.Address + "',phone = '" + providerClass.Phone;
            lUpdateStr = lUpdateStr + "',principal = '" + providerClass.Principal + "',postCode = '" + providerClass.PostCode;
            lUpdateStr = lUpdateStr + "',eMail = '" + providerClass.EMail + "',remark = '" + providerClass.Remark;
            lUpdateStr = lUpdateStr + "',produceNo ='" + providerClass.ProduceNo + "',mark = '" + providerClass.Mark + "'";
            lUpdateStr = lUpdateStr + " Where id = " + providerClass.Id;

            return sqlHelper.Update(new ArrayList() { lUpdateStr });
        }
    }

    #endregion

    #region 供应商供应材料窗体数据层方法
    /*
          * 类名称：GMaterialDB
          * 类功能描述：供应商供应材料窗体数据层方法
          *
          * 创建人：冯雪
          * 创建时间：2009-03-04
          *
          * 修改人：
          * 修改时间：
          * 修改内容：
          *
          */
    class GMaterialDB
    {
        SqlHelper sqlHelper = new SqlHelper();

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
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("providerMaterialCorresponding.id");
            ls.Viewfields.Add("materialKind.sort as 材料种类");
            ls.Viewfields.Add("materialName.name as 材料名称");
            ls.Viewfields.Add("materialModel.model as 材料规格");
            ls.Viewfields.Add("producer.name as 生产厂家");
            ls.Viewfields.Add("providerMaterialCorresponding.distance as 运输距离");
            ls.Viewfields.Add("providerMaterialCorresponding.provideCapability as 供货能力 ");
            ls.Viewfields.Add("providerMaterialCorresponding.inputDate ");
            ls.Viewfields.Add("providerMaterialCorresponding.inputMan ");
            ls.Viewfields.Add("providerMaterialCorresponding.remark as 备注");

            ls.TableNames.Add("providerMaterialCorresponding");
            ls.TableNames.Add("producer");
            ls.LinkConds.Add("providerMaterialCorresponding.pId = producer.id");

            ls.TableNames.Add("material");
            ls.LinkConds.Add("providerMaterialCorresponding.mId = material.id");

            ls.TableNames.Add("materialModel");
            ls.LinkConds.Add("material.mmId = materialModel.id");

            ls.TableNames.Add("materialName");
            ls.LinkConds.Add("material.mnId = materialName.id");

            ls.TableNames.Add("materialKind");
            ls.LinkConds.Add("materialName.mKId = materialKind.id");

            ls.Conds.Add("providerMaterialCorresponding.piId = " + providerId);

            switch (verifyBit)
            {
                case 1:
                    {
                        ls.Conds.Add("materialKind.sort like " + "'%" + searchStr + "%'");
                        break;
                    }
                case 2:
                    {
                        ls.Conds.Add("materialName.name like " + "'%" + searchStr + "%'");
                        break;
                    }
                case 3:
                    {
                        ls.Conds.Add("materialModel.model like " + "'%" + searchStr + "%'");
                        break;
                    }
            }

            return dataTable = ls.LeftLinkOpen().Tables[0];
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
            string lInsertStr;

            lInsertStr = " INSERT INTO providerMaterialCorresponding (mId ,piId ,pId ,distance";
            lInsertStr = lInsertStr + " ,provideCapability ,inputDate ,inputMan ,remark) VALUES (  ";
            lInsertStr = lInsertStr + gmaterialClass.MaterialId + "," + gmaterialClass.ProviderId + ",";
            lInsertStr = lInsertStr + gmaterialClass.ProducerId + "," + gmaterialClass.Distance + ",'";
            lInsertStr = lInsertStr + gmaterialClass.ProvideCapability + "',getdate(),'";
            lInsertStr = lInsertStr + gmaterialClass.InputMan + "','" + gmaterialClass.Remark + "')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });

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
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "SELECT * FROM providerMaterialCorresponding WHERE mId = " + materialId;
            lSearchStr = lSearchStr + "and piId = " + providerId + " and pId = " + producerId;

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            string lDeleteStr;

            lDeleteStr = " DELETE FROM providerMaterialCorresponding WHERE id = " + gMaterialId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
        }


    }
    #endregion

    #region 材料信息窗体数据层方法
    /// <summary>
    /// 材料信息窗体数据层方法
    /// </summary>
    /*
  * 类名称：MaterialDB
  * 类功能描述：材料窗体数据层方法
  *
  * 创建人：冯雪
  * 创建时间：2009-02-23
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */
    class MaterialDB
    {
        SqlHelper sqlHelper = new SqlHelper();

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
            string lSearchStr;

            lSearchStr = "select distinct id,sort as 材料种类 from materialKind ";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr;

            lSearchStr = "select distinct id,name  as 材料名称 from materialName where mkId = " + mkId;

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr;
            DataTable dataTable;

            //先在材料规格型号对应表material中查询材料名称mnId下的所有材料规格mmId的id;  material
            lSearchStr = "select mmId from material where mnId = " + mnId;

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return dataTable;
            }
            else
            {
                //将查到的所有mmId,组合成SQL语句,并查询出材料规格表中对应的id,modle;
                lSearchStr = "select distinct id,model as 材料规格 from materialModel where id = " + Convert.ToInt32(dataTable.Rows[0][0].ToString());

                for (int curRow = 1; curRow < dataTable.Rows.Count; curRow++)
                {
                    lSearchStr = lSearchStr + " or id = " + dataTable.Rows[curRow][0].ToString();
                }

                return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
            }
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
            string lInsertStr;

            lInsertStr = "INSERT INTO material (mnId,mmId,density,rate,nadirStock,inputDate,inputMan,remark) ";
            lInsertStr = lInsertStr + "VALUES( " + materialClass.MnId + "," + materialClass.MmId + ",'";
            lInsertStr = lInsertStr + materialClass.Density + "'," + materialClass.Rate + ",";
            lInsertStr = lInsertStr + materialClass.NadirStock + ",getdate(),'";
            lInsertStr = lInsertStr + materialClass.InputMan + "','" + materialClass.Remark + " ')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = " SELECT * FROM material WHERE mnId = " + mnid;
            lSearchStr = lSearchStr + " and mmId = " + mmid;
            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("material.id");
            ls.Viewfields.Add("materialKind.sort as 材料种类");
            ls.Viewfields.Add("materialName.name as 材料名称");
            ls.Viewfields.Add("materialModel.model as 材料规格");
            ls.Viewfields.Add("material.density as 密度");
            ls.Viewfields.Add("material.rate as 损耗率");
            ls.Viewfields.Add("material.nadirStock as 最低库存量");
            ls.Viewfields.Add("material.inputDate as 录入日期");
            ls.Viewfields.Add("material.inputMan as 录入人 ");
            ls.Viewfields.Add("material.remark as 备注");

            ls.TableNames.Add("material");
            ls.TableNames.Add("materialModel");
            ls.LinkConds.Add("material.mmId = materialModel.id");

            ls.TableNames.Add("materialName");
            ls.LinkConds.Add("material.mnId = materialName.id");
            ls.TableNames.Add("materialKind");
            ls.LinkConds.Add("materialName.mKId = materialKind.id");

            switch (verifyBit)
            {
                case 1:
                    {
                        ls.Conds.Add("materialKind.sort like " + "'%" + condition + "%'");
                        break;
                    }
                case 2:
                    {
                        ls.Conds.Add("materialName.name like " + "'%" + condition + "%'");
                        break;
                    }
                case 3:
                    {
                        ls.Conds.Add("materialModel.model like " + "'%" + condition + "%'");
                        break;
                    }
            }

            return dataTable = ls.LeftLinkOpen().Tables[0];
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
            string lDeleteStr;

            lDeleteStr = "DELETE FROM material WHERE id = " + mId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
        public int MaterialSearch(int mnid, int mmid)
        {
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = " SELECT id FROM material WHERE mnId = " + mnid;
            lSearchStr = lSearchStr + " and mmId = " + mmid;
            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(dataTable.Rows[0][0].ToString());
            }
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
            string lUpdateStr = "UPDATE  material SET density = '" + materialClass.Density;
            lUpdateStr = lUpdateStr + "',nadirStock = " + materialClass.NadirStock;
            lUpdateStr = lUpdateStr + ",rate = " + materialClass.Rate;
            lUpdateStr = lUpdateStr + ",remark = '" + materialClass.Remark;
            lUpdateStr = lUpdateStr + "' WHERE id = " + materialClass.Id;
            return sqlHelper.Update(new ArrayList() { lUpdateStr });
        }
    }
    #endregion

    #region 产品信息窗体数据层方法
    /// <summary>
    /// 产品信息窗体数据层方法
    /// </summary>
    /*
  * 类名称：ProductDB
  * 类功能描述：产品窗体数据层方法
  *
  * 创建人：冯雪
  * 创建时间：2009-02-23
  *
  * 修改人：
  * 修改时间：
  * 修改内容：
  *
  */
    class ProductDB
    {
        SqlHelper sqlHelper = new SqlHelper();

        /*
       * 方法名称：
       * 方法功能描述：初始化合同制作人
       *
       * 创建人：付中华
       * 创建时间：2009-02-28
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable makerComboboxDb()
        {
            string SqlStr;

            SqlStr = "select id,name from usersInfo";
            ArrayList list = new ArrayList();
            list.Add(SqlStr.ToString());
            return sqlHelper.QueryForDateSet(list).Tables[0];

        }
        /*
        * 方法名称：InitialMKindComboBox()
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
            string lSearchStr;

            lSearchStr = "select distinct id,sort as 产品种类 from productKind ";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
        * 方法名称：InitialPNameComboBox()
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
            string lSearchStr;

            lSearchStr = "select distinct id,name as 产品名称 from productName where pkId = " + pkId;

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        /*
       * 方法名称：InitialPModelComboBox()
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
        public DataTable InitialPModelComboBox(int pnId)
        {
            string lSearchStr;
            DataTable dataTable;

            //先在产品规格型号对应表product中查询产品名称pnId下的所有产品规格pmId的id;
            lSearchStr = "select pmId from product where pnId = " + pnId;

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return dataTable;
            }
            else
            {
                //将查到的所有pmId,组合成SQL语句,并查询出产品规格表中对应的id,modle;
                lSearchStr = "select distinct id,model as 产品规格 from productModel where id = " + Convert.ToInt32(dataTable.Rows[0][0].ToString());
                for (int curRow = 1; curRow < dataTable.Rows.Count; curRow++)
                {
                    lSearchStr = lSearchStr + " or  id = " + dataTable.Rows[curRow][0].ToString();
                }

                return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
            }

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
            string lInsertStr;

            lInsertStr = "INSERT INTO product(pnId,pmId,density,rate,nadirStock,planPrice,inputDate,inputMan,remark)";
            lInsertStr = lInsertStr + "VALUES( " + productClass.PnId + "," + productClass.PmId + ",'";
            lInsertStr = lInsertStr + productClass.Density + "'," + productClass.Rate + ",";
            lInsertStr = lInsertStr + productClass.NadirStock + "," + productClass.PlanPrice;
            lInsertStr = lInsertStr + ",getdate(),'" + productClass.InputMan + "','";
            lInsertStr = lInsertStr + productClass.Remark + " ')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
        }
        /*
       * 方法名称：FrmPoeductUpdate( )
       * 方法功能描述：向产品表中更新数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-04-14
       *
       * 修改人：付中华
       * 修改时间：2009-4-22
       * 修改内容：密度和备注当为空时不进行更新
       *
       */
        public bool FrmPoeductUpdate(ProductClass productClass)
        {
            //string lUpdateStr = "UPDATE  product SET density = " + productClass.Density;
            //lUpdateStr = lUpdateStr + ",nadirStock = " + productClass.NadirStock;
            //lUpdateStr = lUpdateStr + ",rate = " + productClass.Rate;
            //lUpdateStr = lUpdateStr + ",planPrice = " + productClass.PlanPrice;
            //lUpdateStr = lUpdateStr + ",remark = '" + productClass.Remark + "'";
            //lUpdateStr = lUpdateStr + " Where id = " + productClass.Id;
            //return sqlHelper.Update(new ArrayList() { lUpdateStr });

            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();

            sqlStr.Append("update product set ");
            if (!string.IsNullOrEmpty(productClass.Density))
            {
                sqlStr.Append(" density='" + productClass.Density + "',");
            }
            sqlStr.Append(" nadirStock='" + productClass.NadirStock + "',");
            sqlStr.Append(" rate=" + productClass.Rate + ",");
            if (!string.IsNullOrEmpty(productClass.Remark))
            {
                sqlStr.Append(" remark ='" + productClass.Remark + "',");
            }
            sqlStr.Append(" planPrice =" + productClass.PlanPrice);

            sqlStr.Append("  Where id =" + productClass.Id);
            list.Add(sqlStr.ToString());

            return sqlHelper.Update(list);
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
            string lDeleteStr;

            lDeleteStr = "DELETE FROM product WHERE id = " + pId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("product.id");
            ls.Viewfields.Add("productKind.sort as 产品种类");
            ls.Viewfields.Add("productName.name as 产品名称");
            ls.Viewfields.Add("productModel.model as 产品规格");
            ls.Viewfields.Add("product.density as 密度");
            ls.Viewfields.Add("product.planPrice as 计划价格");
            //ls.Viewfields.Add("product.rate as 损耗率");
            ls.Viewfields.Add("product.nadirStock as 最低库存量");
            ls.Viewfields.Add("product.inputDate as 录入日期");
            ls.Viewfields.Add("product.inputMan as 录入人 ");
            ls.Viewfields.Add("product.remark as 备注");

            ls.TableNames.Add("product");
            ls.TableNames.Add("productModel");
            ls.LinkConds.Add("product.pmId = productModel.id");

            ls.TableNames.Add("productName");
            ls.LinkConds.Add("product.pnId = productName.id");
            ls.TableNames.Add("productKind");
            ls.LinkConds.Add("productName.pKId = productKind.id");

            switch (verifyBit)
            {
                case 1:
                    {
                        ls.Conds.Add("productKind.sort like " + "'%" + condition + "%'");
                        break;
                    }
                case 2:
                    {
                        ls.Conds.Add("productName.name like " + "'%" + condition + "%'");
                        break;
                    }
                case 3:
                    {
                        ls.Conds.Add("productModel.model like " + "'%" + condition + "%'");
                        break;
                    }
            }

            return dataTable = ls.LeftLinkOpen().Tables[0];
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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "SELECT * FROM product WHERE pnId = " + pnid;
            lSearchStr = lSearchStr + " and pmId = " + pmid;
            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = " SELECT id FROM product WHERE pnId = " + pnid;
            lSearchStr = lSearchStr + " and pmId = " + pmid;
            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            if (dataTable.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(dataTable.Rows[0][0].ToString());
            }
        }
    }
    #endregion

    #region 维护材料、产品 类别、名称 窗体数据层方法
    /*
      * 类名称：VindicateDB
      * 类功能描述：维护材料产品 类别、名称 窗体数据层方法
      *
      * 创建人：冯雪
      * 创建时间：2009-02-23
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class VindicateDB
    {
        SqlHelper sqlHelper = new SqlHelper();
        DataTable dataTable;
        //以下是对产品信息的操作；
        /*
       * 方法名称：PKindInsert( )
       * 方法功能描述：向产品种类表中插入数据;
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
            string lInsertStr;

            lInsertStr = "INSERT INTO productKind (sort,inputDate,inputMan,remark) VALUES ( '";
            lInsertStr = lInsertStr + productclass.Kind + "'," + "getdate(),'";
            lInsertStr = lInsertStr + productclass.InputMan + "','" + productclass.Remark + " ')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lInsertStr;

            lInsertStr = "INSERT INTO productName (name,pkId,inputDate,inputMan,remark) VALUES ( '";
            lInsertStr = lInsertStr + productclass.Name + "'," + productclass.PkId + "," + "getdate(),'";
            lInsertStr = lInsertStr + productclass.InputMan + "','" + productclass.Remark + " ')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lInsertStr;
            lInsertStr = "INSERT INTO productModel (model,inputDate,inputMan,remark) VALUES ( '";
            lInsertStr = lInsertStr + productclass.Model + "'," + "getdate(),'";
            lInsertStr = lInsertStr + productclass.InputMan + "','" + productclass.Remark + " ')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lDeleteStr;

            lDeleteStr = " DELETE FROM productKind WHERE id = " + pkId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
            string lDeleteStr;

            lDeleteStr = " DELETE FROM productName WHERE id =" + pnId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
            string lDeleteStr;

            lDeleteStr = " DELETE FROM productModel WHERE id =" + pmId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
        }
        /*
       * 方法名称：PSearchName( )
       * 方法功能描述：在材料和产品表中查询要插入的字段在表中是否存在;
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
            int id;
            string lSearchStr;

            switch (verifyBit)
            {
                case 1:
                    {
                        lSearchStr = "SELECT id ,sort FROM productKind WHERE sort = ";
                        break;
                    }
                case 2:
                    {
                        lSearchStr = "SELECT id,name FROM productName WHERE name = ";
                        break;
                    }
                case 3:
                    {
                        lSearchStr = "SELECT id,model FROM productModel WHERE model = ";
                        break;
                    }
                case 4:
                    {
                        lSearchStr = "SELECT id ,sort FROM materialKind WHERE sort = ";
                        break;
                    }
                case 5:
                    {
                        lSearchStr = "SELECT id,name FROM materialName WHERE name = ";
                        break;
                    }
                case 6:
                    {
                        lSearchStr = "SELECT id,model FROM materialModel WHERE model = ";
                        break;
                    }
                default:
                    lSearchStr = "";
                    break;
            }
            lSearchStr = lSearchStr + "'" + Pname + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
       * 方法名称：PModelSearch()
       * 方法功能描述：查询所有产品规格;
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
            string lSearchStr;

            lSearchStr = "select id,model as 产品规格 from productModel ";
            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
        //以下是对材料信息的操作；
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
            string lInsertStr;

            lInsertStr = "INSERT INTO materialKind(sort,inputDate,inputMan,remark) VALUES ( '";
            lInsertStr = lInsertStr + materialClass.Kind + "'," + "getdate(),'";
            lInsertStr = lInsertStr + materialClass.InputMan + "','" + materialClass.Remark + " ')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lInsertStr;
            lInsertStr = "INSERT INTO materialName(name,mkId,inputDate,inputMan,remark) VALUES ( '";
            lInsertStr = lInsertStr + materialClass.Name + "','" + materialClass.MkId + "',";
            lInsertStr = lInsertStr + "getdate(),'" + materialClass.InputMan + "','";
            lInsertStr = lInsertStr + materialClass.Remark + " ')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lInsertStr;
            lInsertStr = "INSERT INTO materialModel(model,inputDate,inputMan,remark) VALUES ( '";
            lInsertStr = lInsertStr + materialClass.Model + "'," + "getdate(),'";
            lInsertStr = lInsertStr + materialClass.InputMan + "','" + materialClass.Remark + " ')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lDeleteStr;

            lDeleteStr = " DELETE FROM materialKind WHERE id = " + mkId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
            string lDeleteStr;

            lDeleteStr = " DELETE FROM materialName WHERE id =" + mnId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
            string lDeleteStr;

            lDeleteStr = " DELETE FROM materialModel WHERE id =" + mmId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
            string lSearchStr;

            lSearchStr = "select id,model as 材料规格 from materialModel ";
            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
    }

    #endregion

    #region 生产厂家数据层方法
    /*
     * 类名称：ProducerDB
     * 类功能描述：生产厂家窗体数据层方法
     *
     * 创建人：冯雪
     * 创建时间：2009-03-04
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class ProducerDB
    {
        SqlHelper sqlHelper = new SqlHelper();

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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = " SELECT * FROM producer WHERE name = '" + producerName + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            string lSearchStr;

            lSearchStr = "SELECT id ,name as 生产厂家,address as 厂家地址 ,phone as 联系电话";
            lSearchStr = lSearchStr + ",inputDate ,inputMan ,remark as 备注 FROM producer ";

            if (verifyBit == 1)
            {
                lSearchStr = lSearchStr + " WHERE name like " + "'%" + pName + "%'";
            }

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lInsertStr;

            lInsertStr = "INSERT INTO producer (name ,address ,phone ,inputDate ,inputMan ";
            lInsertStr = lInsertStr + ",remark) VALUES ( '" + producerClass.Name + "','";
            lInsertStr = lInsertStr + producerClass.Address + "','" + producerClass.Phone + "',";
            lInsertStr = lInsertStr + "getdate(),'" + producerClass.InputMan + "','";
            lInsertStr = lInsertStr + producerClass.Remark + "')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lDeleteStr;

            lDeleteStr = " DELETE FROM producer WHERE id = " + producerId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });

        }
    }

    #endregion

    #region 人员信息窗体数据方法
    /*
        * 类名称：PersonnelDB
        * 类功能描述：人员信息窗体数据方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-04
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
    class PersonnelDB
    {
        SqlHelper sqlHelper = new SqlHelper();

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
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("personnelInfo.id");
            ls.Viewfields.Add("personnelInfo.name as 姓名");
            ls.Viewfields.Add("personnelInfo.sex as 性别");
            ls.Viewfields.Add("case personnelInfo.kind when 0 then '正式' else '临时工' end as 职工类别");
            ls.Viewfields.Add("position.name as 职位");
            ls.Viewfields.Add("produceTeam.name as 生产班");
            ls.Viewfields.Add("personnelInfo.inputDate as 录入日期");
            ls.Viewfields.Add("personnelInfo.inputMan as 录入人 ");
            ls.Viewfields.Add("personnelInfo.remark as 备注");

            ls.TableNames.Add("personnelInfo");
            ls.TableNames.Add("position");
            ls.LinkConds.Add("personnelInfo.pId = position.id");

            ls.TableNames.Add("produceTeam");
            ls.LinkConds.Add("personnelInfo.ptId = produceTeam.id");

            switch (verifyBit)
            {
                case 1:
                    {
                        ls.Conds.Add("personnelInfo.name like " + "'%" + condition + "%'");
                        break;
                    }
                case 2:
                    {
                        ls.Conds.Add("personnelInfo.sex like " + "'%" + condition + "%'");
                        break;
                    }
                case 3:
                    {
                        ls.Conds.Add("personnelInfo.kind like " + "'%" + condition + "%'");
                        break;
                    }
            }

            return dataTable = ls.LeftLinkOpen().Tables[0];
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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = " SELECT * FROM personnelInfo WHERE name = '" + name + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            string lInsertStr;

            lInsertStr = "INSERT INTO  personnelInfo (name ,sex ,age ,inputDate ,inputMan ";
            lInsertStr = lInsertStr + ",remark ,kind ,ptId ,pId) VALUES (  '" + personnelClass.Name + "',";
            lInsertStr = lInsertStr + personnelClass.Sex + "," + personnelClass.Age + ",";
            lInsertStr = lInsertStr + "getdate(),'" + personnelClass.InputMan + "','";
            lInsertStr = lInsertStr + personnelClass.Remark + "'," + personnelClass.Kind + ",";
            lInsertStr = lInsertStr + personnelClass.PtId + "," + personnelClass.PId + ")";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
        }
        /*
       * 方法名称：FrmPersonnelDelete( )
       * 方法功能描述：向人员信息表中删除数据;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-04
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool FrmPersonnelDelete(int personnelId)
        {
            string lDeleteStr;

            lDeleteStr = "DELETE FROM personnelInfo WHERE id = " + personnelId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
        }

    }
    #endregion

    #region 客户信息窗体数据方法
    /*
        * 类名称：PersonnelDB
        * 类功能描述：客户信息窗体数据方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-06
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
    class ClientDB
    {
        SqlHelper sqlHelper = new SqlHelper();
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
            string lSearchStr;

            lSearchStr = "SELECT id ,name as 客户名称,artificialMan as 法人,address as 地址,principal as 负责人,phone as 联系电话";
            lSearchStr = lSearchStr + ",postCode as 邮编,eMail as Email,inputDate ,inputMan ,remark as 备注 FROM clientInfo ";

            if (condition != "")
            {

                lSearchStr = lSearchStr + " WHERE name like " + "'%" + condition + "%'";
            }

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr;

            lSearchStr = "select distinct ";

            switch (state)
            {
                case 1:
                    {
                        lSearchStr = lSearchStr + "principal as 负责人";
                        break;
                    }
                case 2:
                    {
                        lSearchStr = lSearchStr + "postCode as 邮编";
                        break;
                    }
            }

            lSearchStr = lSearchStr + " from clientInfo";

            return sqlHelper.QueryForDateSet(new ArrayList { lSearchStr }).Tables[0];
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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "SELECT * FROM clientInfo WHERE name = '" + name + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            string lInsertStr;

            lInsertStr = " INSERT INTO clientInfo (name ,artificialMan ,address ,principal ,phone  ";
            lInsertStr = lInsertStr + ",postCode,eMail ,inputDate ,inputMan ,remark) VALUES( '";
            lInsertStr = lInsertStr + clientClass.Name + "','" + clientClass.ArtficialMan + "','";
            lInsertStr = lInsertStr + clientClass.Address + "','" + clientClass.Principal + "','";
            lInsertStr = lInsertStr + clientClass.Phone + "','" + clientClass.PostCode + "','";
            lInsertStr = lInsertStr + clientClass.EMail + "'," + "getdate(),'";
            lInsertStr = lInsertStr + clientClass.InputMan + "','" + clientClass.Remark + "')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lDeleteStr;

            lDeleteStr = "DELETE FROM clientInfo WHERE id = " + clientId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
            string lUpdateStr = "UPDATE  clientInfo SET artificialMan = '" + clientClass.ArtficialMan;
            lUpdateStr = lUpdateStr + "',address  = '" + clientClass.Address + "',principal = '" + clientClass.Principal;
            lUpdateStr = lUpdateStr + "',phone = '" + clientClass.Phone + "',postCode = '" + clientClass.PostCode;
            lUpdateStr = lUpdateStr + "',eMail = '" + clientClass.EMail + "',remark = '" + clientClass.Remark + "'";
            lUpdateStr = lUpdateStr + " Where id = " + clientClass.Id;
            return sqlHelper.Update(new ArrayList() { lUpdateStr });
        }
    }
    #endregion

    #region 生产设备窗体数据方法
    /*
        * 类名称：EquipmentDB
        * 类功能描述：生产设备窗体数据方法
        *
        * 创建人：冯雪
        * 创建时间：2009-03-05
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
    class EquipmentInfoDB
    {
        SqlHelper sqlHelper = new SqlHelper();

        public equipment.EquipmentInformation QueryByID(long id)
        {
            using (equipment.EquipmentDataContext oContext = new DasherStation.equipment.EquipmentDataContext(this.sqlHelper.SqlConn))
            {
                var result = from item in oContext.EquipmentInformation
                             where item.id == id
                             select item;
                return result.FirstOrDefault();
            }
        }

        public void Update(equipment.EquipmentInformation entity)
        {
            using (equipment.EquipmentDataContext oContext = new DasherStation.equipment.EquipmentDataContext(this.sqlHelper.SqlConn))
            {
                var result = (from item in oContext.EquipmentInformation
                              where item.id == entity.id
                              select item).FirstOrDefault();
                result.enId = entity.enId;
                result.emId = entity.emId;
                result.count = entity.count;
                result.registrationMark = entity.registrationMark;
                result.beginUseTime = entity.beginUseTime;
                result.dId = entity.dId;
                result.installationPosition = entity.installationPosition;
                result.sumPower = entity.sumPower;
                result.addMethod = entity.addMethod;
                result.primaryValue = entity.primaryValue;
                result.remainsValue = entity.remainsValue;
                result.depreciationYear = entity.depreciationYear;
                result.factoryNo = entity.factoryNo;
                result.produceDate = entity.produceDate;
                result.workMan = entity.workMan;
                result.contactMan = entity.contactMan;
                result.contactMethod = entity.contactMethod;
                result.postCode = entity.postCode;
                result.producer = entity.producer;
                result.dId2 = entity.dId2;
                result.factoryAddress = entity.factoryAddress;
                result.mark = entity.mark;
                oContext.SubmitChanges();
            }
        }

        /*
       * 方法名称：SearchEquipmentAll( )
       * 方法功能描述：查询设备信息表中所有信息;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public DataTable SearchEquipmentAll(string condition)
        {
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("equipmentInformation.id");
            ls.Viewfields.Add("equipmentInformation.no as 设备编号");
            ls.Viewfields.Add("equmentKind.sort as 设备类别");
            ls.Viewfields.Add("equipmentName.name as 设备名称");
            ls.Viewfields.Add("equipmentModel.model as 设备规格");
            ls.Viewfields.Add("department.name as 使用部门");
            ls.Viewfields.Add("document.no as 文档编号");
            ls.Viewfields.Add("equipmentInformation.[count] as 设备数量");
            ls.Viewfields.Add("equipmentInformation.registrationMark as 牌照号码");
            ls.Viewfields.Add("equipmentInformation.installationPosition as 安装位置");
            ls.Viewfields.Add("equipmentInformation.sumPower as 总功率");
            ls.Viewfields.Add("equipmentInformation.addMethod as 增置方式");
            ls.Viewfields.Add("equipmentInformation.primaryValue as 设备原值");
            ls.Viewfields.Add("equipmentInformation.remainsValue as 设备残值");
            ls.Viewfields.Add("equipmentInformation.depreciationYear as 折旧年限");
            ls.Viewfields.Add("equipmentInformation.produceDate as 生产日期");
            ls.Viewfields.Add("equipmentInformation.producer as 生产厂家");
            ls.Viewfields.Add("equipmentInformation.factoryNo as 出厂编号");
            ls.Viewfields.Add("equipmentInformation.contactMethod as 联系方式");
            ls.Viewfields.Add("equipmentInformation.postCode as 邮编");
            ls.Viewfields.Add("equipmentInformation.factoryAddress as 厂家地址");
            ls.Viewfields.Add("equipmentInformation.workMan as 经办人");
            ls.Viewfields.Add("equipmentInformation.beginUseTime as 投入使用时间");
            ls.Viewfields.Add("equipmentInformation.contactMan as 联系人");

            ls.Viewfields.Add("equipmentInformation.inputDate ");
            ls.Viewfields.Add("equipmentInformation.inputMan");
            ls.Viewfields.Add("equipmentInformation.remark as 备注");
            ls.TableNames.Add("equipmentInformation");
            ls.TableNames.Add("department");
            ls.LinkConds.Add("equipmentInformation.dId = department.id");
            ls.TableNames.Add("document");
            ls.LinkConds.Add("equipmentInformation.dId2= document.id");
            ls.TableNames.Add("equipmentModel");
            ls.LinkConds.Add("equipmentInformation.emId = equipmentModel.id");
            ls.TableNames.Add("equipmentName");
            ls.LinkConds.Add("equipmentInformation.enId = equipmentName.id");
            ls.TableNames.Add("equmentKind");
            ls.LinkConds.Add("equipmentName.ekId = equmentKind.id");

            if (!condition.Equals(""))
            {
                ls.Conds.Add("equipmentInformation.no like " + "'%" + condition + "%'");
            }

            return dataTable = ls.LeftLinkOpen().Tables[0];
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
            string lSearchStr = "select distinct id,no from equipmentInformation";
            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr;

            lSearchStr = "select distinct ";

            switch (state)
            {
                case 1:
                    {
                        lSearchStr = lSearchStr + "contactMan as 联系人";
                        break;
                    }
                case 2:
                    {
                        lSearchStr = lSearchStr + "workMan as 经办人";
                        break;
                    }
                case 3:
                    {
                        lSearchStr = lSearchStr + "postCode as 邮编";
                        break;
                    }
            }

            lSearchStr = lSearchStr + " from equipmentInformation";

            return sqlHelper.QueryForDateSet(new ArrayList { lSearchStr }).Tables[0];
        }

        /*
       * 方法名称：SearchNO( )
       * 方法功能描述：查询要插入的字段在设备表中是否存在;
       *
       * 创建人：冯雪
       * 创建时间：2009-03-21
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public bool SearchNO(string no)
        {
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "SELECT id ,no FROM equipmentInformation WHERE no = '" + no + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            string lSearchStr;

            lSearchStr = "select distinct id,name  as 设备名称 from equipmentName where ekId = " + ekId;

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr;

            lSearchStr = "SELECT id ,name FROM department";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

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
            string lSearchStr;

            lSearchStr = "SELECT id ,name ,no FROM document ";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

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
            string lSearchStr;

            lSearchStr = "SELECT id ,sort as 设备类别,inputDate ,inputMan ,remark as 备注 FROM equmentKind";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = " SELECT * FROM equmentKind WHERE sort = '" + kind + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            string lInsertStr;

            lInsertStr = "INSERT INTO equmentKind (sort ,inputDate ,inputMan ,remark) VALUES ( '";
            lInsertStr = lInsertStr + eClass.Sort + "'," + "getdate(),'";
            lInsertStr = lInsertStr + eClass.InputMan + "','" + eClass.Remark + "')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
        }
        /*
       * 方法名称：DeleteKind( )
       * 方法功能描述：向设备类别表中删除数据;
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
            string lDeleteStr;

            lDeleteStr = "DELETE FROM equmentKind WHERE id = " + eKindId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
        }

        // 设备名称;
        /*
       * 方法名称：SearchEquipmentNameAll( )
       * 方法功能描述：查询设备名称所有信息;
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
            string lSearchStr;

            lSearchStr = "SELECT id ,name as 设备名称,inputDate ,inputMan ,remark as 备注 FROM equipmentName where ekId = " + ekid;

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = " SELECT * FROM equipmentName WHERE name = '" + name + "' and ekid = " + ekId;

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            string lInsertStr;

            lInsertStr = "INSERT INTO equipmentName (name ,ekId,inputDate ,inputMan ,remark) VALUES ( '";
            lInsertStr = lInsertStr + eClass.Name + "'," + eClass.EkId + ",getdate(),'";
            lInsertStr = lInsertStr + eClass.InputMan + "','" + eClass.Remark + "')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lDeleteStr;

            lDeleteStr = "DELETE FROM equipmentName WHERE id = " + eNameId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
            string lSearchStr;

            lSearchStr = "SELECT id ,model as 设备规格 ,inputDate ,inputMan ,remark as 备注 FROM equipmentModel";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = " SELECT * FROM equipmentModel WHERE model = '" + model + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            string lInsertStr;

            lInsertStr = "INSERT INTO equipmentModel (model ,inputDate ,inputMan ,remark) VALUES ( '";
            lInsertStr = lInsertStr + eClass.Model + "'," + "getdate(),'";
            lInsertStr = lInsertStr + eClass.InputMan + "','" + eClass.Remark + "')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lDeleteStr;

            lDeleteStr = "DELETE FROM equipmentModel WHERE id = " + eModelId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
            string lSearchStr;

            lSearchStr = "SELECT id, principal FROM equipmentInformation";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lInsertStr;

            lInsertStr = " INSERT INTO equipmentInformation (no ,enId ,emId ,dId ,dId2 ,[count] ,registrationMark  ";
            lInsertStr = lInsertStr + ",installationPosition ,sumPower ,addMethod ,primaryValue ,remainsValue ";
            lInsertStr = lInsertStr + ",depreciationYear ,produceDate ,factoryNo ,contactMethod ,factoryAddress,postCode ";
            lInsertStr = lInsertStr + ",workMan ,beginUseTime ,contactMan ,producer ,inputDate ,inputMan ,mark) VALUES ('";
            //lInsertStr = lInsertStr + eClass.No + "'," + eClass.EnId + "," + eClass.EmId + "," + eClass.DId + "," + eClass.DId2 + ",";
            lInsertStr = lInsertStr + eClass.No + "'," + eClass.EnId + "," + eClass.EmId + "," + eClass.DId + "," + "NULL" + ",";
            lInsertStr = lInsertStr + eClass.Count + ",'" + eClass.RegistrationMark + "','" + eClass.InstallationPosition + "',";
            lInsertStr = lInsertStr + eClass.SumPower + ",'" + eClass.AddMethod + "'," + eClass.PrimaryValue + ",";
            lInsertStr = lInsertStr + eClass.RemainsValue + "," + eClass.DepreciationYear + ",'" + eClass.ProduceDate + "','";
            lInsertStr = lInsertStr + eClass.FactoryNo + "','" + eClass.ContactMethod + "','" + eClass.FactoryAddress + "','";
            lInsertStr = lInsertStr + eClass.PostCode + "','" + eClass.WorkMan + "','" + eClass.BeginUseTime + "','";
            lInsertStr = lInsertStr + eClass.ContactMan + "','" + eClass.Producer + "',";
            lInsertStr = lInsertStr + "getdate(),'" + eClass.InputMan + "','" + eClass.Mark + "')";

            return sqlHelper.Insert(new ArrayList() { lInsertStr });
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
            string lDeleteStr;

            lDeleteStr = "DELETE FROM equipmentInformation WHERE  id = " + equipmentId;

            return sqlHelper.Delete(new ArrayList() { lDeleteStr });
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
            ArrayList arrayList = new ArrayList();

            string lUpdateStr = "UPDATE  equipmentInformation SET ";
            lUpdateStr = lUpdateStr + "diameter  = " + eClass.Diameter;
            lUpdateStr = lUpdateStr + ", height = " + eClass.Height;
            lUpdateStr = lUpdateStr + ",kind = '" + eClass.PotKind + "'";
            lUpdateStr = lUpdateStr + " WHERE no = '" + eClass.No + "'";

            arrayList.Add(lUpdateStr);

            if (state == 1)
            {
                string lInsertStr = " INSERT INTO  liquidMatterStockList(eiId ";
                if ((eClass.MId != 0) && (eClass.MId != null))
                {
                    lInsertStr = lInsertStr + ",mId ";
                }
                else
                {
                    lInsertStr = lInsertStr + ",pId ";
                }
                if (eClass.LpnId != 0)
                {
                    lInsertStr = lInsertStr + ",lpnId ";
                }
                lInsertStr = lInsertStr + ",remark ,inputDate ,inputMan) VALUES (";
                lInsertStr = lInsertStr + eClass.Id + ",";
                if ((eClass.MId != 0) && (eClass.MId != null))
                {
                    lInsertStr = lInsertStr + eClass.MId + ",";
                }
                else
                {
                    lInsertStr = lInsertStr + eClass.PId + ",";
                }
                if (eClass.LpnId != 0)
                {
                    lInsertStr = lInsertStr + eClass.LpnId + ",";
                }
                lInsertStr = lInsertStr + "'"+ eClass.Remark + "',";
                lInsertStr = lInsertStr + "getdate(),'";
                lInsertStr = lInsertStr + eClass.InputMan + "')";

                arrayList.Add(lInsertStr);
            }

            else
            {
                lUpdateStr = " UPDATE liquidMatterStockList SET ";
                if ((eClass.MId == null))
                {
                    lUpdateStr = lUpdateStr + "mId = NULL";
                }
                else
                {
                    lUpdateStr = lUpdateStr + "mId =" + eClass.MId;
                }
                if (eClass.PId == null)
                {
                    lUpdateStr = lUpdateStr + ",pId =  NULL";
                }
                else
                {
                    lUpdateStr = lUpdateStr + ",pId =" + eClass.PId;
                }
                if (eClass.LpnId != 0) 
                {
                    lUpdateStr = lUpdateStr + ",lpnId = " + eClass.LpnId;
                }
                lUpdateStr = lUpdateStr + ",remark = '" + eClass.Remark + "'";
                lUpdateStr = lUpdateStr + " WHERE eiId =" + eClass.Id;

                arrayList.Add(lUpdateStr);
            }

            return sqlHelper.ExecuteTransaction(arrayList);
        }

        /*
       * 方法名称：SearchLiquidMatter( )
       * 方法功能描述：在液态罐表中查询液态罐存储内容;
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
            string lSearchStr;
            DataTable dataTable = new DataTable();

            lSearchStr = "SELECT lms.eiId, lms.pId, lms.mId, ei.height AS eHeight, ei.diameter,ei.kind, lms.remark, lpn.no";
            lSearchStr = lSearchStr + " FROM liquidMatterStockList AS lms left JOIN";
            lSearchStr = lSearchStr + " equipmentInformation AS ei ON lms.eiId = ei.id  left JOIN";
            lSearchStr = lSearchStr + " liquidPositionNo AS lpn ON lms.lpnid = lpn.id";
            lSearchStr = lSearchStr + " WHERE eiId = " + eiId;

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr;
            if (state == 1)
            {
                lSearchStr = "SELECT mk.sort,mk.id as kid, mn.name,mn.id as nid, mm.model, mm.id as mid ";
                lSearchStr = lSearchStr + " FROM material AS m INNER JOIN";
                lSearchStr = lSearchStr + " materialModel AS mm ON m.mmId = mm.id INNER JOIN";
                lSearchStr = lSearchStr + " materialName AS mn ON m.mnId = mn.id INNER JOIN";
                lSearchStr = lSearchStr + " materialKind AS mk ON mn.mkId = mk.id";
                lSearchStr = lSearchStr + " WHERE m.id = " + id;
            }
            else
            {
                lSearchStr = "SELECT pk.sort,pk.id as kid, pn.name,pn.id as nid, pm.model ,pm.id as mid";
                lSearchStr = lSearchStr + " FROM product AS p INNER JOIN";
                lSearchStr = lSearchStr + " productModel AS pm ON p.pmId = pm.id INNER JOIN";
                lSearchStr = lSearchStr + " productName AS pn ON p.pnId = pn.id INNER JOIN";
                lSearchStr = lSearchStr + " productKind AS pk ON pn.pkId = pk.id";
                lSearchStr = lSearchStr + " WHERE p.id = " + id;
            }

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr = "SELECT id, no FROM liquidPositionNo";
            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }

    }
    #endregion

    #region 选项窗体数据层方法
    /// <summary>
    /// 选项窗体数据层方法
    /// </summary>  
    /*
    * 类名称：OptionDB
    * 类功能描述：选项窗体数据层方法
    *
    * 创建人：冯雪
    * 创建时间：2009-03-04
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class OptionDB
    {
        SqlHelper sqlHelper = new SqlHelper();
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
            string lSearchStr;

            lSearchStr = " SELECT id ,name as 职位名称,inputDate ,inputMan  FROM position ";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "SELECT id ,name FROM position WHERE name = '" + position + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            LinkSelect ls = new LinkSelect();
            DataTable dataTable;

            ls.Viewfields.Add("produceTeam.id");
            ls.Viewfields.Add("produceTeam.name as 生产班组");
            ls.Viewfields.Add("produceTeam.department as 生产部门");
            ls.Viewfields.Add("personnelInfo.name as 组长");
            ls.Viewfields.Add("produceTeam.[count] as 总人数");
            ls.Viewfields.Add("produceTeam.inputDate ");
            ls.Viewfields.Add("produceTeam.inputMan  ");
            ls.Viewfields.Add("produceTeam.remark as 备注");

            ls.TableNames.Add("produceTeam");
            ls.TableNames.Add("personnelInfo");
            ls.LinkConds.Add("produceTeam.piId = personnelInfo.id");

            return dataTable = ls.LeftLinkOpen().Tables[0];
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
            string lSearchStr;

            lSearchStr = " SELECT id ,name as 生产班组 FROM produceTeam";
            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "SELECT id ,name FROM produceTeam WHERE name = '" + team + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            string lSearchStr;

            lSearchStr = " SELECT id,site as 地点,inputDate ,inputMan FROM  site  ";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "SELECT id ,site FROM site WHERE site = '" + site + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            string lSearchStr;

            lSearchStr = " SELECT id,method as 结算方式,inputDate ,inputMan FROM  transportSettlementMethod  ";

            return sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            int id;
            string lSearchStr;
            DataTable dataTable;

            lSearchStr = "SELECT id ,method FROM transportSettlementMethod WHERE method = '" + method + "'";

            dataTable = sqlHelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];

            id = dataTable.Rows.Count;

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
            ArrayList arrayList = new ArrayList();
            string lInsertStr;

            //判断职位是否为空;
            if (!optionClass.PositionName.Equals(""))
            {
                lInsertStr = "INSERT INTO position (name ,inputDate ,inputMan) VALUES ( '";
                lInsertStr = lInsertStr + optionClass.PositionName + "'," + "getdate(),'";
                lInsertStr = lInsertStr + optionClass.InputMan + "')";

                arrayList.Add(lInsertStr);
            }
            //判断生产班组是否为空;
            if (!optionClass.PTeamName.Equals(""))
            {
                lInsertStr = "";

                lInsertStr = "INSERT INTO produceTeam (name ,department ,piId ,[count] ,inputDate ,inputMan ) VALUES ( '";
                lInsertStr = lInsertStr + optionClass.PTeamName + "','" + optionClass.Department + "',";
                lInsertStr = lInsertStr + optionClass.PId + "," + optionClass.Count + ",";
                lInsertStr = lInsertStr + "getdate(),'" + optionClass.InputMan + "')";

                arrayList.Add(lInsertStr);
            }

            //判断地点是否为空;
            if (!optionClass.Site.Equals(""))
            {
                lInsertStr = "INSERT INTO site (site ,inputDate ,inputMan)  VALUES ('";
                lInsertStr = lInsertStr + optionClass.Site + "'," + "getdate(),'";
                lInsertStr = lInsertStr + optionClass.InputMan + "')";

                arrayList.Add(lInsertStr);
            }
            //判断结算方式是否为空;
            if (!optionClass.TMethod.Equals(""))
            {
                lInsertStr = "INSERT INTO  transportSettlementMethod (method ,inputDate ,inputMan )  VALUES ('";
                lInsertStr = lInsertStr + optionClass.TMethod + "'," + "getdate(),'";
                lInsertStr = lInsertStr + optionClass.InputMan + "')";

                arrayList.Add(lInsertStr);
            }

            return sqlHelper.Insert(arrayList);


        }


    }
    #endregion

    #region 数据比对数据方法
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
    class MonitorDB
    {
        SqlHelper sqlhelper = new SqlHelper();
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
            string lSearchStr = "select mp.pid ,mp.eiid ";
            lSearchStr = lSearchStr + ",(select pn.name from product p,productName pn where p.pnid=pn.id and p.id = mp.pid)as pname";
            lSearchStr = lSearchStr + ",(select pm.model from product p1,productModel pm where p1.pmid = pm.id and p1.id = mp.pid) as pmodel";
            lSearchStr = lSearchStr + ",(select ei.no from equipmentInformation ei where ei.id = mp.eiid) as eino";
            lSearchStr = lSearchStr + ",(select en.name from equipmentInformation ei1,equipmentName en where ei1.enid=en.id and ei1.id = mp.eiid ) as einame";
            lSearchStr = lSearchStr + ",sum( coalesce ( mp.quantity2,mp.quantity1)) as psum";
            lSearchStr = lSearchStr + ",(select sum(cn.suttle) from consignmentNote cn ,invoice i where cn.iId = i.id and i.pid = mp.pid) as ssum";
            lSearchStr = lSearchStr + " from mixtureProduceLog mp where 1=1";
            if (!where.Equals(""))
            {
                lSearchStr = lSearchStr + where;
            }

            lSearchStr = lSearchStr + " group by mp.pid,mp.eiid";
            return sqlhelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr = "select distinct mp.eiid as eiid,e.no as 设备编号";
            if (state)
            {
                // 查询混合料生产记录表中的设备;
                lSearchStr = lSearchStr + " from mixtureProduceLog AS mp INNER JOIN equipmentInformation AS e ON mp.eiId = e.id ";
                lSearchStr = lSearchStr + "  group by mp.eiid,e.no";
            }
            else
            {
                // 混合料生产不合格记录
                lSearchStr = lSearchStr + " from produceMeasureMonitor AS mp INNER JOIN equipmentInformation AS e ON mp.eiId = e.id ";
                lSearchStr = lSearchStr + " where mp.result = 0";
            }
            return sqlhelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr = "SELECT mp.id,mp.eiId,mp.inputDate as 生产日期,e.no as 设备编号 ";
            lSearchStr = lSearchStr + ",mp.asphaltumWeight as 沥青,mp.blockWeight as 石粉";
            lSearchStr = lSearchStr + ",mp.realMaterialWeight1 as '1#仓',mp.realMaterialWeight2 as '2#仓'";
            lSearchStr = lSearchStr + ",mp.realMaterialWeight3 as '3#仓',mp.realMaterialWeight4 as '4#仓'";
            lSearchStr = lSearchStr + ",mp.realMaterialWeight5 as '5#仓',mp.realMaterialWeight6 as '6#仓'";
            lSearchStr = lSearchStr + ",mp.stuffingWeight as 填料,mp.sumWeight as '批次产量(吨)' ,mp.temperature as '混合料温度(%)'";
            lSearchStr = lSearchStr + " FROM produceMeasureMonitor AS mp INNER JOIN equipmentInformation AS e ON mp.eiId = e.id ";
            lSearchStr = lSearchStr + " WHERE   mp.result = 0 ";

            if (!where.Equals(""))
            {
                lSearchStr = lSearchStr + where;
            }
            return sqlhelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string sql_where = "";
            if (eiid != 0)
            {
                sql_where = " and mp.eiid =" + eiid;
            }
            sql_where = sql_where + " and mp.inputdate between '" + date_being + "' and '" + date_end + "'";
            return sql_where;
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
            string lSearchStr = "SELECT mta.mId, mta.accountDate as 日期,materialKind.sort as 材料种类,materialName.name as 材料名称";
            lSearchStr = lSearchStr + ",materialModel.model as 材料规格, mta.totalQuantity AS 累计入库量, mtg.testGuideline AS 检测指标";
            lSearchStr = lSearchStr + ",(SELECT COUNT(*) AS Expr1 FROM materialTestAccount AS mta1 WHERE (mId = mta.mId)) AS 累计检测次数";
            lSearchStr = lSearchStr + ", mta.frequency AS 实际检测频, mtg.frequency AS 规定频率 ";
            lSearchStr = lSearchStr + " FROM materialTestAccount AS mta LEFT OUTER JOIN materialTestGuideline AS mtg ON  ";
            lSearchStr = lSearchStr + " mta.mId = mtg.mId Left Outer Join material ON  ";
            lSearchStr = lSearchStr + " mta.mId = material.id Left Outer Join materialModel ON  ";
            lSearchStr = lSearchStr + " material.mmId = materialModel.id Left Outer Join materialName ON  ";
            lSearchStr = lSearchStr + " material.mnId = materialName.id Left Outer Join materialKind ON  ";
            lSearchStr = lSearchStr + " materialName.mKId = materialKind.id  ";
            lSearchStr = lSearchStr + " WHERE (mta.accountDate IN (SELECT MAX(accountDate) AS Expr1 FROM materialTestAccount WHERE mId = mta.mId))";
            lSearchStr = lSearchStr + sql_where;
            return sqlhelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr = "SELECT pta.pId,pta.accountDate as 日期,productKind.sort as 产品种类,productName.name as 产品名称";
            lSearchStr = lSearchStr + ",productModel.model as 产品规格,pta.totalQuantity AS 累计入库量,ptg.testGuideline AS 检测指标";
            lSearchStr = lSearchStr + ",(SELECT COUNT(*) AS Expr1 FROM productTestAccount AS pta1 WHERE (pta1.pId = pta.pId)) AS 累计检测次数";
            lSearchStr = lSearchStr + ",pta.frequency AS 实际检测频, ptg.frequency AS 规定频率 ";
            lSearchStr = lSearchStr + " FROM productTestAccount pta LEFT OUTER JOIN productTestGuideline AS ptg ON  ";
            lSearchStr = lSearchStr + " pta.pId = ptg.pId Left Outer Join product ON  ";
            lSearchStr = lSearchStr + " pta.pId = product.id Left Outer Join productModel ON  ";
            lSearchStr = lSearchStr + " product.pmId = productModel.id Left Outer Join productName ON  ";
            lSearchStr = lSearchStr + " product.pnId = productName.id Left Outer Join productKind ON  ";
            lSearchStr = lSearchStr + " productName.pKId = productKind.id  ";
            lSearchStr = lSearchStr + " WHERE (pta.accountDate IN (SELECT MAX(accountDate) as date FROM productTestAccount WHERE pId = pta.pId))";
            lSearchStr = lSearchStr + sql_where;
            return sqlhelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr = " select date,value,minTemperature,maxTemperature from temperatureHistory where tId = " + tId;
            lSearchStr = lSearchStr + " and date between '" + data + " 00:00:00' and '" + data + " 23:59:59'";

            return sqlhelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr = "SELECT DISTINCT testGuideline FROM ";
            if (state == 1)
            {
                lSearchStr = lSearchStr + "  materialTestGuideline";
            }
            else
            {
                lSearchStr = lSearchStr + "  productTestGuideline";
            }
            return sqlhelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string where = "";
            if (state == 1)
            {
                if (id != 0)
                {
                    //根据产品ID查询检测频率对比
                    where = where + " and pta.pId = " + id;
                }

                if (!guide_line.Equals(""))
                {
                    where = where + " and ptg.testGuideline = '" + guide_line + "'";
                }
                where = where + " and pta.accountDate between '" + data_begin + "' and '" + data_end + "'";
            }
            else
            {
                if (id != 0)
                {
                    //根据产品ID查询检测频率对比
                    where = where + " and mta.mId = " + id;
                }
                if (!string.IsNullOrEmpty(guide_line))
                {
                    where = where + " and mtg.testGuideline = '" + guide_line + "'";
                }
                where = where + " and mta.accountDate between '" + data_begin + "' and '" + data_end + "'";
            }

            return where;
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
            string lSearchStr = "select DISTINCT id,name,no from temperatureNo ";
            return sqlhelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
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
            string lSearchStr = "select name from temperatureNo where id = " + tid;
            var table = sqlhelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
            if (table.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return (table.Rows[0][0].ToString());
            }
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
            string lSearchStr = "SELECT fh.fnid ,sum(value2)as fstat ";
            lSearchStr = lSearchStr + ",(select fn.no from flowmeterNo fn where fn.id = fh.fnid) as fno";
            lSearchStr = lSearchStr + ",(select fn.name from flowmeterNo fn where fn.id = fh.fnid) as fname";
            lSearchStr = lSearchStr + " FROM flowmeterHistory fh WHERE date between '";
            lSearchStr = lSearchStr + begin_data + " ' and  '" + end_data;
            lSearchStr = lSearchStr + "' group by fnid";

            return sqlhelper.QueryForDateSet(new ArrayList() { lSearchStr }).Tables[0];
        }
    }
    #endregion


    /*
      * 类名称：BindinfoDBlayer
      * 类功能描述：车卡绑定功能数据操作层
      *
      * 创建人：袁宇
      * 创建时间：2009-02-25
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class BindinfoDBlayer
    {
        SqlHelper sqlHelperObj = new SqlHelper();
        /*
        * 方法名称：SelectBindInfo
        * 方法功能描述：查询车卡信息
        * 参数: transporunit 运输单位
        *       truckNo      车牌号
        *       cardNo       卡号         
        *
        * 创建人：袁宇
        * 创建时间：2009-02-17
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet SelectBindInfo(string transportUnit, string truckNo, string cardNo)
        {

            DataSet Ret = new DataSet();
            LinkSelect ls = new LinkSelect();

            ls.Viewfields.Add("vehicleCardBinding.id");
            ls.Viewfields.Add("transportUnit.[name] as 运输单位");
            ls.Viewfields.Add("voitureInfo.[no] as 车牌号");
            ls.Viewfields.Add("vehicleCardBinding.cardNo as 卡号");
            ls.Viewfields.Add("voitureInfo.owner as 车主姓名");
            ls.Viewfields.Add("voitureInfo.driverName as 司机姓名");
            ls.Viewfields.Add("voitureInfo.model as 车辆名称型号");
            ls.Viewfields.Add("voitureInfo.tare as 车辆的皮重");
            ls.Viewfields.Add("voitureInfo.standardDeadWeight as 标准载重量");
            ls.Viewfields.Add("vehicleCardBinding.updateDate as 更新日期");
            ls.Viewfields.Add("vehicleCardBinding.inputMan as 录入人 ");
            ls.TableNames.Add("vehicleCardBinding");
            ls.TableNames.Add("voitureInfo");
            ls.LinkConds.Add("vehicleCardBinding.Viid = voitureInfo.id");
            ls.TableNames.Add("transportUnit");
            ls.LinkConds.Add("voitureInfo.tuid = transportUnit.id");
            if (transportUnit.Trim() != "")
            {
                ls.Conds.Add("transportUnit.name like " + "'%" + transportUnit.Trim() + "%'");
            }
            if (truckNo.Trim() != "")
            {
                ls.Conds.Add("voitureInfo.no like" + "'%" + truckNo.Trim() + "%'");
            }
            if (cardNo.Trim() != "")
            {
                ls.Conds.Add("vehicleCardBinding.cardNo like" + "'%" + cardNo.Trim() + "%'");
            }
            Ret = ls.LeftLinkOpen();
            return Ret;
        }
        /*
        * 方法名称：SelecttruckInfo
        * 方法功能描述：查询车辆信息
        * 参数: 
        *       truckNo      车牌号
        *              
        *
        * 创建人：袁宇
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public BindInfoClass SelecttruckInfo(string truckNo)
        {
            BindInfoClass bindInfo = new BindInfoClass();
            DataSet ds = new DataSet();
            LinkSelect ls = new LinkSelect();

            ls.Viewfields.Add("voitureInfo.[no]");
            ls.Viewfields.Add("transportUnit.[name]");
            ls.Viewfields.Add("voitureInfo.owner");
            ls.Viewfields.Add("voitureInfo.model");
            ls.Viewfields.Add("voitureInfo.color");
            ls.Viewfields.Add("voitureInfo.lenth");
            ls.Viewfields.Add("voitureInfo.width");
            ls.Viewfields.Add("voitureInfo.height");
            ls.Viewfields.Add("voitureInfo.tare");
            ls.Viewfields.Add("voitureInfo.standardTare");
            ls.Viewfields.Add("voitureInfo.standardDeadWeight");
            ls.Viewfields.Add("voitureInfo.remark");
            ls.TableNames.Add("voitureInfo");
            ls.TableNames.Add("transportUnit");
            ls.LinkConds.Add("voitureInfo.tuId = transportUnit.id");

            if (truckNo.Trim() != "")
            {
                ls.Conds.Add("voitureInfo.no like" + "'%" + truckNo.Trim() + "%'");
            }
            ds = ls.LeftLinkOpen();
            DataTable dt = ds.Tables[0];

            if ((!dt.Equals(null)) && (dt.Rows.Count > 0))
            {
                bindInfo.UnitName = dt.Rows[0]["name"].ToString();
                bindInfo.Owner = dt.Rows[0]["owner"].ToString();
                bindInfo.Model = dt.Rows[0]["model"].ToString();
                bindInfo.Color = dt.Rows[0]["color"].ToString();
                bindInfo.Lenth = dt.Rows[0]["lenth"].ToString();
                bindInfo.Width = dt.Rows[0]["width"].ToString();
                bindInfo.Heigth = dt.Rows[0]["height"].ToString();
                bindInfo.Tare = dt.Rows[0]["tare"].ToString();
                bindInfo.StandardTare = dt.Rows[0]["standardTare"].ToString();
                bindInfo.StandardDeadWeight = dt.Rows[0]["standardDeadWeight"].ToString();
                bindInfo.Remark = dt.Rows[0]["remark"].ToString();
                return bindInfo;
            }
            return null;

        }
        /*
        * 方法名称：GetTransportUnitItem
        * 方法功能描述：取得运输单位信息列表      
        *         
        *
        * 创建人：袁宇
        * 创建时间：2009-02-25
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable GetTransportUnitItem()
        {
            DataSet ds = new DataSet();
            ArrayList arraylist = new ArrayList();

            arraylist.Add("Select id,[name] from transportUnit");
            ds = sqlHelperObj.QueryForDateSet(arraylist);
            return ds.Tables[0];
        }
        /*
        * 方法名称：GetVoitureNoItem
        * 方法功能描述：根据运输单位取得车牌号      
        * 参数: transportUnit  运输单位        
        *
        * 创建人：袁宇
        * 创建时间：2009-02-25
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable GetVoitureNoItem(string transportUnit)
        {
            DataSet ds = new DataSet();
            LinkSelect ls = new LinkSelect();

            ls.TableNames.Add("voitureInfo");
            ls.TableNames.Add("transportUnit");
            ls.LinkConds.Add("voitureInfo.tuid=transportUnit.id");
            ls.Viewfields.Add("voitureInfo.[no]");
            ls.Viewfields.Add("transportUnit.[name]");
            ls.Viewfields.Add("voitureInfo.id");
            if (transportUnit.Trim() != "")
            {
                ls.Conds.Add("transportUnit.[name]=" + "'" + transportUnit + "'");
            }
            ds = ls.LeftLinkOpen();
            return ds.Tables[0];

        }
        /*
        * 方法名称：InsertCardInfo
        * 方法功能描述：添加卡信息，实现卡与现有车辆进行绑定     
        * 参数: voitureNo 车牌号   cardNo 卡号        
        * 返回: bool 为 true 成功  false 失败
        * 
        * 创建人：袁宇
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertCardInfo(string voitureNo, string cardNo)
        {
            if ((!voitureNo.Equals(null)) && (!voitureNo.Equals("")))
            {
                ArrayList arrayList = new ArrayList();
                StringBuilder strSql = new StringBuilder("");
                if (voitureNo.Trim() != "")
                {
                    strSql = new StringBuilder("");
                    strSql.Append("Insert into vehicleCardBinding(viid,cardNo,inputDate,inputMan,updateDate,updateMan) values(");
                    strSql.Append(voitureNo + ",");
                    strSql.Append("'" + cardNo + "',");
                    strSql.Append("'" + DateTime.Now + "',");
                    strSql.Append("'" + "当前用户" + "',");
                    strSql.Append("'" + DateTime.Now + "',");
                    strSql.Append("'" + "当前用户" + "')");
                    arrayList.Add(strSql.ToString());
                    if (sqlHelperObj.Insert(arrayList))
                        return true;
                }
            }
            return false;
        }
        /*
        * 方法名称：InsertCardInfo
        * 方法功能描述：更新卡信息，实现对车号重新绑定卡
        * 参数: bindInfo 车卡绑定信息实体类        
        * 返回: bool 为 true 成功  false 失败
        * 
        * 创建人：袁宇
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool UpdateCardInfo(string voitureNo, string cardNo)
        {
            DataVar dv = new DataVar();
            ArrayList fields = new ArrayList();
            ArrayList values = new ArrayList();
            ArrayList conds = new ArrayList();

            if ((cardNo != null) && (cardNo.Trim() != ""))
            {
                fields.Add("cardNo");
                values.Add("'" + cardNo + "'");
            }
            if ((voitureNo != null) && (voitureNo.Trim() != ""))
            {
                conds.Add("viId=" + voitureNo);
            }
            if (dv.UpdateTeble("vehicleCardBinding", fields, values, conds))
                return true;
            else
                return false;
        }
        /*
        * 方法名称：InsertCardInfo
        * 方法功能描述：车牌号是否已经绑定过卡号
        * 参数: bindInfo 车卡绑定信息实体类        
        * 返回: bool 为 true 成功  false 失败
        * 
        * 创建人：袁宇
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool IsExistence(string truckNo)
        {

            DataSet ds = new DataSet();
            ArrayList arraylist = new ArrayList();
            string strSql = "";
            if (truckNo.Trim() != "")
            {
                strSql += "Select * from vehicleCardBinding where viid=" + truckNo;
                arraylist.Add(strSql);
                ds = sqlHelperObj.QueryForDateSet(arraylist);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public bool DeleteCardInfo(string id)
        {
            string strSql = "";
            ArrayList arraylist = new ArrayList();

            strSql += "Delete From vehicleCardBinding where id=" + id;
            arraylist.Add(strSql);
            if (sqlHelperObj.Delete(arraylist))
                return true;
            else
                return false;
        }
    }
    /*
      * 类名称：LeftLinkSelect
      * 类功能描述：多表左联接查询
      *
      * 创建人：袁宇
      * 创建时间：2009-02-25
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
    class LinkSelect
    {
        SqlHelper sqlHelperObj = new SqlHelper();
        //要联接的表集合        
        private ArrayList tableNames = new ArrayList();
        //联接条件，如：表a.id=表b.id
        private ArrayList linkConds = new ArrayList();
        //字义结果集中显示哪些字段
        private ArrayList viewfields = new ArrayList();
        //查询条件集
        private ArrayList conds = new ArrayList();
        //分组
        private string groupBy;

        public string GroupBy
        {
            get
            {
                return groupBy;
            }
            set
            {
                groupBy = value;
            }
        }
        public ArrayList TableNames
        {
            get
            {
                return tableNames;
            }
            set
            {
                tableNames = value;
            }
        }
        public ArrayList LinkConds
        {
            get
            {
                return linkConds;
            }
            set
            {
                linkConds = value;
            }
        }
        public ArrayList Viewfields
        {
            get
            {
                return viewfields;
            }
            set
            {
                viewfields = value;
            }
        }
        public ArrayList Conds
        {
            get
            {
                return conds;
            }
            set
            {
                conds = value;
            }
        }
        private bool IsAvailability()
        {
            int i = 0;
            if (tableNames.Count >= 2)
            {
                i++;
            }
            if (linkConds.Count >= 1)
            {
                i++;
            }
            if (viewfields.Count >= 1)
            {
                i++;
            }
            if (i >= 3)
                return true;
            else
                return false;
        }
        /*
        * 方法名称：GetVoitureNoItem
        * 方法功能描述：左联接查询left Outer,可对多表进行左联接查询。   
        * 参数:         
        *
        * 创建人：袁宇
        * 创建时间：2009-02-25
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataSet LeftLinkOpen()
        {
            if (IsAvailability())
            {
                StringBuilder sqlStr = new StringBuilder("Select ");
                DataSet ds = new DataSet();
                ArrayList arraylist = new ArrayList();

                foreach (string x in viewfields)
                {
                    sqlStr.Append(x.Trim() + ",");
                }
                sqlStr.Remove(sqlStr.Length - 1, 1);
                sqlStr.Append(" From ");
                for (int i = 0; i < tableNames.Count - 1; i++)
                {
                    if (i == 0)
                    {
                        sqlStr.Append(tableNames[i]);
                        sqlStr.Append(" Left Outer Join ");
                        sqlStr.Append(tableNames[i + 1]);
                    }
                    else
                    {
                        sqlStr.Append(" Left Outer Join ");
                        sqlStr.Append(tableNames[i + 1]);
                    }
                    sqlStr.Append(" ON " + linkConds[i]);
                }
                sqlStr.Append(" where 1=1 ");
                if ((conds != null) && (conds.Count > 0))
                {
                    foreach (string x in conds)
                    {
                        sqlStr.Append(" and " + x);
                    }
                }
                if ((groupBy != null) && (!groupBy.Trim().Equals("")))
                {
                    sqlStr.Append(" " + groupBy);
                }
                arraylist.Add(sqlStr.ToString());
                ds = sqlHelperObj.QueryForDateSet(arraylist);
                return ds;
            }
            else
            {
                return null;
            }
        }
    }

    /*
    * 类名称：dataVar
    * 方法功能描述：存放一些拼接sql 语包的方法  
    * 参数: 
    * 
    * 创建人：袁宇
    * 创建时间：2009-02-26
    *
    * 修改人：
    * 修改时间：
    * 修改内容：
    *
    */
    class DataVar
    {
        SqlHelper sqlHelperObj = new SqlHelper();
        /*
        * 方法名称：UpdateTeble
        * 方法功能描述：更新字段与值对比字符串生成；  
        * 参数: list1 字段列表 
        *       List2 值列表
        *       Eval 操作符 
        *       compart  间隔符
        * 创建人：袁宇
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        private string EvaluateString(ArrayList List1, ArrayList List2, string Eval, string Compart)
        {
            StringBuilder Ret = new StringBuilder("");
            int I, Count;

            if (List1.Count == List2.Count)
            {
                Count = List1.Count - 1;
                for (I = 0; I <= Count; I++)
                {
                    Ret.Append(List1[I].ToString() + ' ' + Eval + ' ' + List2[I].ToString());
                    if (I < Count)
                    {
                        Ret.Append(Compart);
                    }
                }
            }
            return Ret.ToString();
        }
        /*
        * 方法名称：CombinationString
        * 方法功能描述：由字符串列表提供的内容组合成为字符串，参数Compart为分隔符；  
        * 参数:  list 要生成字符串的列表
        *        compart 间隔符
        *        
        *       
        * 创建人：袁宇
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
         * *
        */
        private string CombinationString(ArrayList List, string Compart)
        {
            StringBuilder Ret = new StringBuilder("");
            int Count, I;
            Count = List.Count;
            for (I = 0; I < Count; I++)
            {
                Ret.Append(List[I].ToString());
                if (I < Count - 1)
                {
                    Ret.Append(Compart);
                }
            }
            return Ret.ToString();
        }
        /*
        * 方法名称：UpdateTeble
        * 方法功能描述：更新表,拼接sql语句   
        * 参数: TabName 表名 
        *       FieldList 字段名列表
        *       ValueList 值列表
        *       Cond      条件列表
        * 创建人：袁宇
        * 创建时间：2009-02-26
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool UpdateTeble(string TabName, ArrayList FieldList, ArrayList ValueList, ArrayList Cond)
        {
            string Conds = "", Eval = "";
            StringBuilder SqlText = new StringBuilder("");
            ArrayList sql = new ArrayList();

            if ((!TabName.Trim().Equals("")) && (FieldList.Count.Equals(ValueList.Count)) && (FieldList.Count > 0) && (ValueList.Count > 0))
            {
                Eval = EvaluateString(FieldList, ValueList, "=", ",");
                SqlText.Append("Update " + TabName + " Set " + Eval);
                Conds = CombinationString(Cond, " ");
                if (Conds.Trim() != "")
                {
                    SqlText.Append(" Where " + Conds);
                }
                sql.Add(SqlText.ToString());
                if (sqlHelperObj.Update(sql))
                    return true;
            }
            return false;
        }
        /*
        * 方法名称：InsertTable
        * 方法功能描述：向指定表中，用指定字段和值插入一条数据  
        * 参数: TabName 表名 
        *       FieldList 字段名列表
        *       ValueList 值列表
        *       
        * 创建人：袁宇
        * 创建时间：2009-03-06
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public bool InsertTable(string TabName, ArrayList FieldList, ArrayList ValueList)
        {
            string Fields, Values;
            string SqlText = "";
            ArrayList sql = new ArrayList();
            if ((TabName.Trim() != "") && (FieldList.Count > 0) && (ValueList.Count > 0) && (FieldList.Count == ValueList.Count))
            {
                Fields = CombinationString(FieldList, ",");
                Values = CombinationString(ValueList, ",");
                SqlText = SqlText + "insert into " + TabName + "(" + Fields + ") values (" + Values + ")";
                sql.Add(SqlText);
                if (sqlHelperObj.Update(sql))
                    return true;
            }
            return false;

        }
    }

    /*
     * 类名称：DataBaseBackUp
     * 方法功能描述：对数据库的备份恢复及下载操作
     * 参数: 
     * 
     * 创建人：金鹤
     * 创建时间：20090303
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */


    /// <summary>
    /// 对数据库的备份恢复及下载操作
    /// </summary>
    class DataBaseBackUp
    {

        //服务器IP地址
        private string ftpServerIP;
        //ftp登陆名
        private string ftpUserID;
        //ftp登陆密码
        private string ftpPassword;
        //SQL用户名
        private string SqlUserName;
        //SQL用户密码
        private string SqlUserPwd;
        //传输协议对象
        private FtpWebRequest reqFTP;
        //进度条
        private ToolStripProgressBar PBar;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ftpServerIP">服务器IP地址</param>
        /// <param name="ftpUserID">ftp登陆名</param>
        /// <param name="ftpPassword">SQL用户名</param>
        /// <param name="SqlUserName">SQL用户密码</param>
        /// <param name="SqlUserPwd">传输协议对象</param>
        public DataBaseBackUp(string ftpServerIP, string ftpUserID, string ftpPassword, string SqlUserName, string SqlUserPwd)
        {
            this.ftpServerIP = ftpServerIP;
            this.ftpUserID = ftpUserID;
            this.ftpPassword = ftpPassword;
            this.SqlUserName = SqlUserName;
            this.SqlUserPwd = SqlUserPwd;
        }

        /// <summary>
        /// 连接FTP
        /// </summary>
        /// <param name="path">FTP服务器地址</param>
        private void Connect(String path)
        {

            // 根据uri创建FtpWebRequest对象

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(path));

            // 指定数据传输类型

            reqFTP.UseBinary = true;

            // ftp用户名和密码

            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

        }
        /// <summary>
        /// 获取FTP中文件的列表
        /// </summary>
        /// <returns></returns>
        public string[] GetFileList()
        {
            return GetFileList("ftp://" + ftpServerIP + "/", WebRequestMethods.Ftp.ListDirectory);
        }

        /// <summary>
        /// 获取FTP中文件的列表
        /// 
        /// </summary>
        /// <param name="path">服务器地址</param>
        /// <param name="WRMethods">如FTP请求一起使用的方法</param>
        /// <returns></returns>
        public string[] GetFileList(string path, string WRMethods)//上面的代码示例了如何从ftp服务器上获得文件列表
        {


            StringBuilder result = new StringBuilder();

            Connect(path);

            reqFTP.Method = WRMethods;

            WebResponse response = reqFTP.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);//中文文件名



            string line = reader.ReadLine();

            while (line != null)
            {

                result.Append(line);

                result.Append(" ");

                line = reader.ReadLine();

            }

            // to remove the trailing '' '' 

            result.Remove(result.ToString().LastIndexOf(' '), 1);

            reader.Close();

            response.Close();

            return result.ToString().Split(' ');


        }

        /// <summary>
        /// 执行数据库备份
        /// </summary>
        /// <param name="strDbName">数据库名称</param>
        /// <param name="strFileName">备份成的文件名称</param>
        /// <param name="PBarM">进度条对象</param>
        /// <returns></returns>
        public bool BackUPDB(string strDbName, string strFileName, ToolStripProgressBar PBarM)
        {

            PBar = PBarM;

            sqldmo.SQLServer svr = new sqldmo.SQLServerClass();

            try
            {

                svr.Connect(ftpServerIP, SqlUserName, SqlUserPwd);

                sqldmo.Backup bak = new sqldmo.BackupClass();

                bak.Action = SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database;

                bak.Initialize = true;

                sqldmo.BackupSink_PercentCompleteEventHandler pceh = new sqldmo.BackupSink_PercentCompleteEventHandler(Step);

                bak.PercentComplete += pceh;

                bak.Files = strFileName;

                bak.Database = strDbName;

                bak.SQLBackup(svr);

                return true;

            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                svr.DisConnect();
                PBar.Visible = false;

            }

        }

        /// <summary>
        /// 控制进度条委托函数
        /// </summary>
        /// <param name="message">完成比文字说明</param>
        /// <param name="percent">完成比进度说明</param>
        private void Step(string message, int percent)
        {
            PBar.Value = percent;
        }

        /// <summary>
        /// 执行数据库恢复操作
        /// </summary>
        /// <param name="strDbName">数据库名称</param>
        /// <param name="strFileName">备份文件名称</param>
        /// <param name="pgbMain">进度条对象</param>
        /// <returns></returns>
        public bool RestoreDB(string strDbName, string strFileName, ToolStripProgressBar pgbMain)
        {
            PBar = pgbMain;
            sqldmo.SQLServer svr = new sqldmo.SQLServerClass();
            try
            {
                svr.Connect(ftpServerIP, SqlUserName, SqlUserPwd);
                sqldmo.QueryResults qr = svr.EnumProcesses(-1);
                int iColPIDNum = -1;
                int iColDbName = -1;
                for (int i = 1; i <= qr.Columns; i++)
                {
                    string strName = qr.get_ColumnName(i);
                    if (strName.ToUpper().Trim() == "SPID")
                    {
                        iColPIDNum = i;
                    }
                    else if (strName.ToUpper().Trim() == "DBNAME")
                    {
                        iColDbName = i;
                    }
                    if (iColPIDNum != -1 && iColDbName != -1)
                        break;
                }

                for (int i = 1; i <= qr.Rows; i++)
                {
                    int lPID = qr.GetColumnLong(i, iColPIDNum);
                    string strDBName = qr.GetColumnString(i, iColDbName);
                    if (strDBName.ToUpper() == strDbName.ToUpper())
                        svr.KillProcess(lPID);
                }

                sqldmo.Restore res = new sqldmo.RestoreClass();
                res.Action = sqldmo.SQLDMO_RESTORE_TYPE.SQLDMORestore_Database;
                sqldmo.RestoreSink_PercentCompleteEventHandler pceh = new sqldmo.RestoreSink_PercentCompleteEventHandler(Step);
                res.PercentComplete += pceh;
                res.Files = strFileName;//可以写成路径+文件名

                res.Database = strDbName;
                res.ReplaceDatabase = true;
                res.SQLRestore(svr);



                return true;
            }
            catch (Exception err)
            {
                throw (new Exception("恢复数据库失败,请关闭所有和该数据库连接的程序！" + err.Message));
            }
            finally
            {
                svr.DisConnect();
                PBar.Visible = false;
            }
        }

        /// <summary>
        /// 从FTP上下载指定文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="errorinfo">异常描述</param>
        /// <returns>True:成功 False:失败</returns>
        public bool Download(string filePath, string fileName, out string errorinfo)
        {


            try
            {

                String onlyFileName = Path.GetFileName(fileName);

                string newFileName = filePath + fileName;

                if (File.Exists(newFileName))
                {

                    errorinfo = string.Format("本地文件{0}已存在,无法下载", newFileName);

                    return false;

                }

                string url = "ftp://" + ftpServerIP + "/" + fileName;

                Connect(url);//连接  



                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);



                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();



                Stream ftpStream = response.GetResponseStream();



                long cl = response.ContentLength;



                int bufferSize = 2048;



                int readCount;



                byte[] buffer = new byte[bufferSize];



                readCount = ftpStream.Read(buffer, 0, bufferSize);



                FileStream outputStream = new FileStream(newFileName, FileMode.Create);

                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);

                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();

                outputStream.Close();

                response.Close();

                errorinfo = "";

                return true;

            }

            catch (Exception ex)
            {

                errorinfo = string.Format("因{0},无法下载", ex.Message);

                return false;

            }

        }


    }

    /// <summary>
    /// 数据访问类warehouseInfoAction
    /// </summary>
    public class warehouseInfoAction
    {
        SqlHelper sqlHelper = new SqlHelper();
        public warehouseInfoAction()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(warehouseInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.name != null)
            {
                strSql1.Append("name,");
                strSql2.Append("'" + model.name + "',");
            }
            if (model.no != null)
            {
                strSql1.Append("no,");
                strSql2.Append("'" + model.no + "',");
            }
            if (model.remark != null)
            {
                strSql1.Append("remark,");
                strSql2.Append("'" + model.remark + "',");
            }

            strSql1.Append("inputDate,");
            strSql2.Append("getdate(),");

            if (model.inputMan != null)
            {
                strSql1.Append("inputMan,");
                strSql2.Append("'" + model.inputMan + "',");
            }
            strSql.Append("insert into warehouseInfo(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");

            return sqlHelper.Insert(new ArrayList() { strSql.ToString() });

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(warehouseInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update warehouseInfo set ");
            if (model.name != null)
            {
                strSql.Append("name='" + model.name + "',");
            }
            if (model.no != null)
            {
                strSql.Append("no='" + model.no + "',");
            }
            if (model.remark != null)
            {
                strSql.Append("remark='" + model.remark + "',");
            }

            strSql.Append("inputDate=getdate(),");

            if (model.inputMan != null)
            {
                strSql.Append("inputMan='" + model.inputMan + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + " ");

            return sqlHelper.Update(new ArrayList() { strSql.ToString() });

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete warehouseInfo ");
            strSql.Append(" where id=" + id + " ");
            sqlHelper.Delete(new ArrayList() { strSql.ToString() });
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public warehouseInfo GetModel(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,name,no,remark,inputDate,inputMan ");
            strSql.Append(" from warehouseInfo ");
            strSql.Append(" where id=" + id + " ");
            warehouseInfo model = new warehouseInfo();
            DataSet ds = sqlHelper.QueryForDateSet(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.no = ds.Tables[0].Rows[0]["no"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["inputDate"].ToString() != "")
                {
                    model.inputDate = DateTime.Parse(ds.Tables[0].Rows[0]["inputDate"].ToString());
                }
                model.inputMan = ds.Tables[0].Rows[0]["inputMan"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,no,remark,inputDate,inputMan ");
            strSql.Append(" FROM warehouseInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return sqlHelper.QueryForDateSet(strSql.ToString());
        }

        /*
        */

        #endregion  成员方法
    }

    /// <summary>
    /// 数据访问类projectName。
    /// </summary>
    public class projectNameAction
    {

        SqlHelper sqlHelper = new SqlHelper();

        public projectNameAction()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(projectName model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.name != null)
            {
                strSql1.Append("name,");
                strSql2.Append("'" + model.name + "',");
            }
            if (model.position != null)
            {
                strSql1.Append("position,");
                strSql2.Append("'" + model.position + "',");
            }

            strSql1.Append("inputDate,");
            strSql2.Append("getdate(),");

            if (model.unitProject != null)
            {
                strSql1.Append("unitProject,");
                strSql2.Append("'" + model.unitProject + "',");
            }
            if (model.subsectionProject != null)
            {
                strSql1.Append("subsectionProject,");
                strSql2.Append("'" + model.subsectionProject + "',");
            }
            if (model.no != null)
            {
                strSql1.Append("no,");
                strSql2.Append("'" + model.no + "',");
            }
            if (model.itemProject != null)
            {
                strSql1.Append("itemProject,");
                strSql2.Append("'" + model.itemProject + "',");
            }
            if (model.inputMan != null)
            {
                strSql1.Append("inputMan,");
                strSql2.Append("'" + model.inputMan + "',");
            }
            strSql.Append("insert into projectName(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return sqlHelper.Insert(new ArrayList() { strSql.ToString() });
        }
        public bool selectItems(projectName model)
        {
            StringBuilder sqlStr = new StringBuilder();
            ArrayList list = new ArrayList();
            sqlStr.Append("select count(*) from projectName where ");

            if (!string.IsNullOrEmpty(model.position))
            {
                sqlStr.Append(" position=" + "'" + model.position + "'and ");
            }
            if (!string.IsNullOrEmpty(model.itemProject))
            {
                sqlStr.Append(" itemProject=" + "'" + model.itemProject + "'and ");
            }
            if (!string.IsNullOrEmpty(model.subsectionProject))
            {
                sqlStr.Append(" subsectionProject=" + "'" + model.subsectionProject + "'and ");
            }
            if (!string.IsNullOrEmpty(model.unitProject))
            {
                sqlStr.Append(" unitProject=" + "'" + model.unitProject + "'and ");
            }
            if (!string.IsNullOrEmpty(model.name))
            {
                sqlStr.Append(" name=" + "'" + model.name + "'and ");
            }
            if (!string.IsNullOrEmpty(model.no))
            {
                sqlStr.Append(" no=" + "'" + model.no + "'");
            }
            list.Add(sqlStr.ToString());

           DataTable dt= sqlHelper.QueryForDateSet(list).Tables[0];
           if (Convert.ToInt32(dt.Rows[0][0].ToString())>0)
           { return true; }
           return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(projectName model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update projectName set ");
            if (model.name != null)
            {
                strSql.Append("name='" + model.name + "',");
            }
            if (model.position != null)
            {
                strSql.Append("position='" + model.position + "',");
            }

            strSql.Append("inputDate=getdate(),");

            if (model.unitProject != null)
            {
                strSql.Append("unitProject='" + model.unitProject + "',");
            }
            if (model.subsectionProject != null)
            {
                strSql.Append("subsectionProject='" + model.subsectionProject + "',");
            }
            if (model.no != null)
            {
                strSql.Append("no='" + model.no + "',");
            }
            if (model.itemProject != null)
            {
                strSql.Append("itemProject='" + model.itemProject + "',");
            }
            if (model.inputMan != null)
            {
                strSql.Append("inputMan='" + model.inputMan + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where id=" + model.id + " ");
            return sqlHelper.Update(new ArrayList() { strSql.ToString() });

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete projectName ");
            strSql.Append(" where id=" + id + " ");
            sqlHelper.Delete(new ArrayList() { strSql.ToString() });
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public projectName GetModel(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,name,position,inputDate,unitProject,subsectionProject,no,itemProject,inputMan ");
            strSql.Append(" from projectName ");
            strSql.Append(" where id=" + id + " ");
            projectName model = new projectName();
            DataSet ds = sqlHelper.QueryForDateSet(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.position = ds.Tables[0].Rows[0]["position"].ToString();
                if (ds.Tables[0].Rows[0]["inputDate"].ToString() != "")
                {
                    model.inputDate = DateTime.Parse(ds.Tables[0].Rows[0]["inputDate"].ToString());
                }
                model.unitProject = ds.Tables[0].Rows[0]["unitProject"].ToString();
                model.subsectionProject = ds.Tables[0].Rows[0]["subsectionProject"].ToString();
                model.no = ds.Tables[0].Rows[0]["no"].ToString();
                model.itemProject = ds.Tables[0].Rows[0]["itemProject"].ToString();
                model.inputMan = ds.Tables[0].Rows[0]["inputMan"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name,position,inputDate,unitProject,subsectionProject,no,itemProject,inputMan ");
            strSql.Append(" FROM projectName ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return sqlHelper.QueryForDateSet(strSql.ToString());
        }

        /*
        */

        #endregion  成员方法
    }

    /// <summary>
    /// 数据访问类basicInfo。
    /// </summary>
    public class basicInfoAction
    {

        SqlHelper sqlHelper = new SqlHelper();

        public basicInfoAction()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在记录
        /// </summary>
        public bool Exists()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from basicInfo");

            int a = sqlHelper.QueryForDateSet(strSql.ToString()).Tables[0].Rows.Count;

            return a > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(basicInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.maxHydrousImpurityRate != null)
            {
                strSql1.Append("maxHydrousImpurityRate,");
                strSql2.Append("" + model.maxHydrousImpurityRate + ",");
            }
            if (model.asphaltumError != null)
            {
                strSql1.Append("asphaltumError,");
                strSql2.Append("" + model.asphaltumError + ",");
            }
            if (model.systemUseTime != null)
            {
                strSql1.Append("systemUseTime,");
                strSql2.Append("'" + model.systemUseTime + "',");
            }
            if (model.dasherName != null)
            {
                strSql1.Append("dasherName,");
                strSql2.Append("'" + model.dasherName + "',");
            }
            if (model.inputDate != null)
            {
                strSql1.Append("inputDate,");
                strSql2.Append("getdate(),");
            }
            if (model.inputMan != null)
            {
                strSql1.Append("inputMan,");
                strSql2.Append("'" + model.inputMan + "',");
            }
            if (model.updateDate != null)
            {
                strSql1.Append("updateDate,");
                strSql2.Append("getdate(),");
            }
            if (model.updateMan != null)
            {
                strSql1.Append("updateMan,");
                strSql2.Append("'" + model.updateMan + "',");
            }
            if (model.address != null)
            {
                strSql1.Append("address,");
                strSql2.Append("'" + model.address + "',");
            }
            if (model.piId != null)
            {
                strSql1.Append("piId,");
                strSql2.Append("" + model.piId + ",");
            }
            if (model.enterpriseKind != null)
            {
                strSql1.Append("enterpriseKind,");
                strSql2.Append("'" + model.enterpriseKind + "',");
            }
            if (model.phone != null)
            {
                strSql1.Append("phone,");
                strSql2.Append("'" + model.phone + "',");
            }
            if (model.fax != null)
            {
                strSql1.Append("fax,");
                strSql2.Append("'" + model.fax + "',");
            }
            if (model.postNo != null)
            {
                strSql1.Append("postNo,");
                strSql2.Append("'" + model.postNo + "',");
            }
            strSql.Append("insert into basicInfo(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            sqlHelper.Insert(new ArrayList() { strSql.ToString() });
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(basicInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update basicInfo set ");
            if (model.maxHydrousImpurityRate != null)
            {
                strSql.Append("maxHydrousImpurityRate=" + model.maxHydrousImpurityRate + ",");
            }
            if (model.asphaltumError != null)
            {
                strSql.Append("asphaltumError=" + model.asphaltumError + ",");
            }
            if (model.systemUseTime != null)
            {
                strSql.Append("systemUseTime='" + model.systemUseTime + "',");
            }
            if (model.dasherName != null)
            {
                strSql.Append("dasherName='" + model.dasherName + "',");
            }
            if (model.inputDate != null)
            {
                strSql.Append("inputDate='" + model.inputDate + "',");
            }
            if (model.inputMan != null)
            {
                strSql.Append("inputMan='" + model.inputMan + "',");
            }

            strSql.Append("updateDate=getdate(),");

            if (model.updateMan != null)
            {
                strSql.Append("updateMan='" + model.updateMan + "',");
            }
            if (model.address != null)
            {
                strSql.Append("address='" + model.address + "',");
            }
            if (model.piId != null)
            {
                strSql.Append("piId=" + model.piId + ",");
            }
            if (model.enterpriseKind != null)
            {
                strSql.Append("enterpriseKind='" + model.enterpriseKind + "',");
            }
            if (model.phone != null)
            {
                strSql.Append("phone='" + model.phone + "',");
            }
            if (model.fax != null)
            {
                strSql.Append("fax='" + model.fax + "',");
            }
            if (model.postNo != null)
            {
                strSql.Append("postNo='" + model.postNo + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);

            sqlHelper.Update(new ArrayList() { strSql.ToString() });
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public basicInfo GetModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" maxHydrousImpurityRate,asphaltumError,systemUseTime,dasherName,inputDate,inputMan,updateDate,updateMan,address,piId,enterpriseKind,phone,fax,postNo ");
            strSql.Append(" from basicInfo ");

            basicInfo model = new basicInfo();
            DataSet ds = sqlHelper.QueryForDateSet(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["maxHydrousImpurityRate"].ToString() != "")
                {
                    model.maxHydrousImpurityRate = decimal.Parse(ds.Tables[0].Rows[0]["maxHydrousImpurityRate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["asphaltumError"].ToString() != "")
                {
                    model.asphaltumError = long.Parse(ds.Tables[0].Rows[0]["asphaltumError"].ToString());
                }
                if (ds.Tables[0].Rows[0]["systemUseTime"].ToString() != "")
                {
                    model.systemUseTime = DateTime.Parse(ds.Tables[0].Rows[0]["systemUseTime"].ToString());
                }
                model.dasherName = ds.Tables[0].Rows[0]["dasherName"].ToString();
                if (ds.Tables[0].Rows[0]["inputDate"].ToString() != "")
                {
                    model.inputDate = DateTime.Parse(ds.Tables[0].Rows[0]["inputDate"].ToString());
                }
                model.inputMan = ds.Tables[0].Rows[0]["inputMan"].ToString();
                if (ds.Tables[0].Rows[0]["updateDate"].ToString() != "")
                {
                    model.updateDate = DateTime.Parse(ds.Tables[0].Rows[0]["updateDate"].ToString());
                }
                model.updateMan = ds.Tables[0].Rows[0]["updateMan"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                if (ds.Tables[0].Rows[0]["piId"].ToString() != "")
                {
                    model.piId = long.Parse(ds.Tables[0].Rows[0]["piId"].ToString());
                }
                model.enterpriseKind = ds.Tables[0].Rows[0]["enterpriseKind"].ToString();
                model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                model.fax = ds.Tables[0].Rows[0]["fax"].ToString();
                model.postNo = ds.Tables[0].Rows[0]["postNo"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /*
        */

        #endregion  成员方法
    }
}

