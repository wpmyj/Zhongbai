using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DasherStation.system;

namespace DasherStation.metage
{    
    /*
     * 类名称：WeighingLogic
     * 类功能描述：称重逻辑类
     *
     * 创建人：袁宇
     * 创建时间：2009-03-04
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class WeighingLogic
    {
        public void GetWarehouseInfo(ref ComboBox CB)
        {
            WeighingDBlayer dbLayer = new WeighingDBlayer();
            CB.DataSource = dbLayer.SelectWarehouseInfo();
            CB.DisplayMember = "fullName";
            CB.SelectedIndex = -1;
            CB.ValueMember = "id";
        }
        /*
        * 方法名称：GetTruckNoItem
        * 方法功能描述：取得车牌号列表   
        * 参数:      
        * 返回: 
        * 创建人：袁宇
        * 创建时间：2009-03-04
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void GetTruckNoItem(ref ComboBox CB)
        {
            WeighingDBlayer dbLayer = new WeighingDBlayer();
            DataTable dt = new DataTable();

            dt = dbLayer.SelectTruckInfo("");
            CB.DataSource = dt;
            CB.DisplayMember = "no";
            CB.SelectedIndex = -1;
            CB.ValueMember = "id";
            
        }
        /*
        * 方法名称：GetTruckInfo
        * 方法功能描述：通过车牌号取得车辆信息   
        * 参数:      
        * 返回: 
        * 创建人：袁宇
        * 创建时间：2009-03-04
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public DataTable GetTruckInfo(string truckNo)
        {
            WeighingDBlayer dbLayer = new WeighingDBlayer();

            return dbLayer.SelectTruckInfo(truckNo);
        }
        /*
        * 方法名称：GetContractItem
        * 方法功能描述：取得合同列表   
        * 参数:   option 用于确定是销售合同，还是采购合同，取值：入库称重、出库称重   
        * 返回:  DataTable
        * 创建人：袁宇
        * 创建时间：2009-03-04
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void GetContractItem(string option,ref ComboBox box)
        {            
            switch (option)
            {
                case "入库称重":
                    InWeighingDBLayer dblayer1 = new InWeighingDBLayer();
                    DataTable dt1 = new DataTable();
                    dt1 = dblayer1.SelectStockContract();
                    box.DataSource = dt1; 
                    box.DisplayMember = "name";
                    box.SelectedIndex = -1;           
                    box.ValueMember = "id";
                    break;
                case "出库称重":
                    OutWeighingDBLayer dblayer2 = new OutWeighingDBLayer();
                    DataTable dt2 = new DataTable();
                    dt2 = dblayer2.SelectsellContract();
                    box.DataSource = dt2;
                    box.DisplayMember = "name";
                    box.SelectedIndex = -1;
                    box.ValueMember = "id";
                    
                    break;
                default:
                    ;
                    break;
            }           
        }
        /*
        * 方法名称：GetEquipmentItem
        * 方法功能描述：取得生产设备列表   
        * 参数:   cb 用于存放列表的下拉框   
        * 返回:  
        * 创建人：袁宇
        * 创建时间：2009-03-04
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void GetEquipmentItem(ref ComboBox cb)
        {
            OutWeighingDBLayer dblayer = new OutWeighingDBLayer();

            cb.DataSource = dblayer.SelectEquipmentInfo();
            cb.DisplayMember = "names";
            cb.SelectedIndex = -1;
            cb.ValueMember = "id";
            
        }
        /*
        * 方法名称：GetTransportContract
        * 方法功能描述：取得运输合同列表  
        * 参数:   cb 用于存放列表的下拉框 
        * 返回:  
        * 创建人：袁宇
        * 创建时间：2009-03-04
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void GetTransportInfo(string style,ref ComboBox cb)
        {
            WeighingDBlayer dblayer = new WeighingDBlayer();
            DataTable bt = new DataTable();
            switch (style)
            {
                case "入库称重":
                    bt = dblayer.SelectTransportMaterialInfo();
                    cb.DataSource = bt;
                    cb.DisplayMember = "contractName";
                    cb.SelectedIndex = -1;
                    cb.ValueMember = "id";
                    break;
                case "出库称重":
                    bt = dblayer.SelectTransportProductInfo();
                    cb.DataSource = bt;
                    cb.DisplayMember = "contractName";
                    cb.SelectedIndex = -1;
                    cb.ValueMember = "id";
                    break;
            }            
            
            
        }
        /*
        * 方法名称：GetSite1
        * 方法功能描述：取得启运地或止运地  
        * 参数:   cb 用于存放列表的下拉框 
        * 返回:  
        * 创建人：袁宇
        * 创建时间：2009-03-04
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void GetSite(ref ComboBox cb1)
        {
            WeighingDBlayer dblayer = new WeighingDBlayer();
            DataTable bt = new DataTable();

            bt = dblayer.SelectSite();
            cb1.DataSource = bt;
            cb1.DisplayMember = "site";
            cb1.SelectedIndex = -1;
            cb1.ValueMember = "id";
            
        }        
        /*
        * 方法名称：GetOwner
        * 方法功能描述：查询车主姓名  
        * 参数:   truckNo 车牌号 
        * 返回:  
        * 创建人：袁宇
        * 创建时间：2009-03-05
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public string GetOwner(string truckNo)
        {
            WeighingDBlayer dblayer = new WeighingDBlayer();
            DataTable bt = new DataTable();
            string Rec = "";

            bt = dblayer.SelectTruckInfo(truckNo);
            if ((!bt.Equals(null)) && (bt.Rows.Count > 0))
            {
                Rec = bt.Rows[0]["owner"].ToString();
            }
            return Rec;
        }
        /*
        * 方法名称：GetProjectName
        * 方法功能描述：查询工程项目
        * 参数:   truckNo 车牌号 
        * 返回:  
        * 创建人：袁宇
        * 创建时间：2009-03-05
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void GetProjectName(ref ComboBox cb)
        {
            OutWeighingDBLayer dblayer = new OutWeighingDBLayer();
            DataTable bt = new DataTable();
            bt = dblayer.SelectProjectName();
            cb.DataSource = bt;
            cb.DisplayMember = "projectName";
            cb.SelectedIndex = -1;
            cb.ValueMember = "id";           
        }
        /*
        * 方法名称：SetProvider
        * 方法功能描述：查询供应商或客户信息  
        * 参数:   option 确定出入库  scid 合同信息ID  cb 存列表的下拉
        * 返回:  
        * 创建人：袁宇
        * 创建时间：2009-03-05
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void SetProvider(string option, string scId, ref ComboBox cb)
        {
            DataTable dt = new DataTable();
            switch (option)
            {
                case "入库称重":
                    InWeighingDBLayer dblayer1 = new InWeighingDBLayer();
                    dt = dblayer1.SelectProvider(scId);
                    cb.Text = dt.Rows[0]["name2"].ToString();                    
                    break;
                case "出库称重":
                    OutWeighingDBLayer dblayer2 = new OutWeighingDBLayer();
                    dt = dblayer2.SelectClientInfo(scId);
                    cb.Text = dt.Rows[0]["name2"].ToString();
                    break;
                default:
                    ;
                    break;
            }        
             
        }
        /*
        * 方法名称：SetGoodsName
        * 方法功能描述：取得物品名称列表  
        * 参数:   option 确定出入库  scid 合同信息ID  cb 存列表的下拉
        * 返回:  
        * 创建人：袁宇
        * 创建时间：2009-03-05
        *
        * 修改人：
        * 修改时间：
        * 修改内容：
        *
        */
        public void SetGoodsName(string option, string scid, ref ComboBox cb)
        {
            DataTable dt = new DataTable();
            switch (option)
            {
                case "入库称重":
                    InWeighingDBLayer dblayer1 = new InWeighingDBLayer();
                    dt = dblayer1.SelectIndent(scid,"");
                    cb.DataSource = dt;
                    cb.DisplayMember = "name";
                    cb.SelectedIndex = -1;
                    cb.ValueMember = "id";
                    
                    break;
                case "出库称重":
                    OutWeighingDBLayer dblayer2 = new OutWeighingDBLayer();
                    dt = dblayer2.SelectInvoice(scid,"");
                    cb.DataSource = dt;
                    cb.DisplayMember = "name";
                    cb.SelectedIndex = -1;
                    cb.ValueMember = "id";                    
                    break;
                default:
                    ;
                    break;
            }
 
        }
        /*
       * 方法名称：SetGoodsModel
       * 方法功能描述：取得物品型号列表  
       * 参数:   option 确定出入库  scid 合同信息ID  cb 存列表的下拉 name 物品名称
       * 返回:  
       * 创建人：袁宇
       * 创建时间：2009-03-05
       *
       * 修改人：
       * 修改时间：
       * 修改内容：
       *
       */
        public void SetGoodsModel(string option, string scid,string name, ref ComboBox cb)
        {
            DataTable dt = new DataTable();
            switch (option)
            {
                case "入库称重":
                    InWeighingDBLayer dblayer1 = new InWeighingDBLayer();
                    dt = dblayer1.SelectIndent(scid, name);
                    cb.DataSource = dt;
                    cb.DisplayMember = "model";
                    cb.ValueMember = "id";
                    break;
                case "出库称重":
                    OutWeighingDBLayer dblayer2 = new OutWeighingDBLayer();
                    dt = dblayer2.SelectInvoice(scid, name);
                    cb.DataSource = dt;
                    cb.DisplayMember = "model";
                    cb.ValueMember = "id";
                    break;
                default:
                    ;
                    break;
            }

        }
        /*
       * 方法名称：ClearCombobox
       * 方法功能描述：清空Combobox  
       * 参数:  tag 清空标识  gb  容量
       * 返回:  
       * 创建人：袁宇
       * 创建时间：2009-03-06
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
                    {
                        mycbx.Text = "";
                        mycbx.SelectedIndex = -1;
                    }

                }
            }

        }
        /*
      * 方法名称：FindWeighingInfo
      * 方法功能描述：查询未称重结束信息 
      * 参数:  option 出入厂标识 truckId 车号Id
      * 返回:  
      * 创建人：袁宇
      * 创建时间：2009-03-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public DataTable FindWeighingInfo(string option,string truckId)
        {
            switch (option)
            {
                case "入库称重":
                    InWeighingDBLayer dblayer1 = new InWeighingDBLayer();
                    DataTable dt1 = new DataTable();
                    dt1 = dblayer1.SelectinWeighInfo(truckId);
                    return dt1;
                    //break;
                case "出库称重":
                    OutWeighingDBLayer dblayer2 = new OutWeighingDBLayer();
                    DataTable dt2 = new DataTable();
                    dt2 = dblayer2.SelectOutWeighInfo(truckId);
                    return dt2;
                    //break;
                default:
                    return null;
                   // break;
            }
        }
        /*
      * 方法名称：SaveInInfo
      * 方法功能描述：保存入厂称重信息 
      * 参数:  info 信息内容光
      * 返回:  
      * 创建人：袁宇
      * 创建时间：2009-03-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool SaveInInfo(InWeighingClass info, out long recId)
        {
            InWeighingDBLayer dbLayer = new InWeighingDBLayer();
            DataTable dt = new DataTable();

            dt = dbLayer.SelectinWeighInfo(info.ViId);
            if ((!dt.Equals(null)) && (dt.Rows.Count > 0))
            {
                //更新 
                info.Id = dt.Rows[0]["id"].ToString();
                if (dbLayer.UpdateInfo(info))
                {
                    recId = Convert.ToInt64(info.Id);
                    return true;
                }
                else
                {
                    recId = -1;
                    return false;
                }
            }
            else
            {
                //新增
                if (dbLayer.InsertInfo(info))
                {
                    recId = dbLayer.GetMaxInRecId();
                    return true;
                }
                else
                {
                    recId = -1;
                    return false;
                }
            }
           
        }        
        /*
      * 方法名称：SaveOutInfo
      * 方法功能描述：保存出厂称重信息 
      * 参数:  info 信息内容光
      * 返回:  
      * 创建人：袁宇
      * 创建时间：2009-03-06
      *
      * 修改人：
      * 修改时间：
      * 修改内容：
      *
      */
        public bool SaveOutInfo(OutWeighingClass info,out long recId)
        {
            OutWeighingDBLayer dbLayer = new OutWeighingDBLayer();
            DataTable dt = new DataTable();

            dt = dbLayer.SelectOutWeighInfo(info.ViId);
            if ((!dt.Equals(null)) && (dt.Rows.Count > 0))
            {
                //更新
                info.Id = dt.Rows[0]["id"].ToString();
                if (dbLayer.UpdateInfo(info))
                {
                    recId = Convert.ToInt64(info.Id);
                    return true;
                }
                else
                {
                    recId = -1;
                    return false;
                }
            }
            else
            {
                //新增
                if (dbLayer.InsertInfo(info))
                {
                    recId = dbLayer.GetMaxInRecId();
                    return true;
                }
                else
                {
                    recId = -1;
                    return false;
                }
            }

        }
        public bool UpdateIninfo(InWeighingClass info)
        {
            InWeighingDBLayer dbLayer = new InWeighingDBLayer();
            DataTable dt = new DataTable();

            if (dbLayer.UpdateInfo(info))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateOutinfo(OutWeighingClass info)
        {
            OutWeighingDBLayer dbLayer = new OutWeighingDBLayer();
            DataTable dt = new DataTable();

            if (dbLayer.UpdateInfo(info))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //取得卡号
        public string GetCardNo(int icdev)
        {            
            string hexkey = "ffffffffffff";
            //装入密码模式
            int mode = 0;
            //第一个扇区装载密码
            int secor = 1;
            //读卡扇区
            byte sector = 0;
            //寻卡模式，可返复写卡
            byte cardmode = 1;
            //卡序号
            ulong tempint=0;
            //地址，*4
            int address = 2;
            
            StringBuilder str = new StringBuilder();                 
            
            if (icdev > 0)
            {
                if (CardClass.dc_load_key_hex(icdev, mode, secor, hexkey) == 0)
                {
                    CardClass.dc_card(icdev, cardmode, ref tempint);                    
                    if (CardClass.dc_authentication(icdev, 0, sector) == 0)
                    {
                        if (CardClass.dc_read_hex(icdev, address, str) == 0)
                        {
                            CardClass.dc_beep(icdev, 10);
                            return str.ToString();
                        } 
                    }
                }
            }
            return "";        
        }

        // 读取卡中存储的卡号信息;
        public string Get_CardNo()
        {
            BindInfoLogic bindInfoLogic = new BindInfoLogic();
            return bindInfoLogic.ReadCard();
        }
      
    }
    class MetageFindClass
    {
        public DataTable FindOutInfo(FindCondClass conds)
        {
            DataTable dt = new DataTable();
            OutWeighingDBLayer dbLayer = new OutWeighingDBLayer();

            dt = dbLayer.SelectOutInfo(conds);
            return dt;
        }
        public DataTable FindInInfo(FindCondClass conds)
        {
            DataTable dt = new DataTable();
            InWeighingDBLayer dbLayer = new InWeighingDBLayer();

            dt = dbLayer.SelectInInfo(conds);
            return dt;
        }
        public void GetMateriaName(ref ComboBox cb)
        {
            DataTable dt = new DataTable();
            WeighingDBlayer dbLayer = new WeighingDBlayer();
            dt = dbLayer.SelectMaterialName();
            cb.DataSource = dt;
            cb.DisplayMember = "name";
            cb.SelectedIndex = -1;
            cb.ValueMember = "id";
        }
        public void GetMateriaModel(string name, ref ComboBox cb)
        {
            DataTable dt = new DataTable();
            WeighingDBlayer dbLayer = new WeighingDBlayer();
            dt = dbLayer.SelectMaterialModel(name);
            cb.DataSource = dt;
            cb.DisplayMember = "model";
            cb.SelectedIndex = -1;
            cb.ValueMember = "id";
        }
        public void GetProductName(ref ComboBox cb)
        {
            DataTable dt = new DataTable();
            WeighingDBlayer dbLayer = new WeighingDBlayer();
            dt = dbLayer.SelectproductName();
            cb.DataSource = dt;
            cb.DisplayMember = "name";
            cb.SelectedIndex = -1;
            cb.ValueMember = "id";
        }
        public void GetProductModel(string name, ref ComboBox cb)
        {
            DataTable dt = new DataTable();
            WeighingDBlayer dbLayer = new WeighingDBlayer();
            dt = dbLayer.SelectproductModel(name);
            cb.DataSource = dt;
            cb.DisplayMember = "model";
            cb.SelectedIndex = -1;
            cb.ValueMember = "id";
        }
        public bool AssessorInInfo(InWeighingClass info)
        {
            InWeighingDBLayer dbLayer = new InWeighingDBLayer();

            return dbLayer.UpdateInfo(info);
        }
        public bool AssessorOutInfo(OutWeighingClass info)
        {
            OutWeighingDBLayer dbLayer = new OutWeighingDBLayer();

            return dbLayer.UpdateInfo(info);
        }
        public bool checkupInInfo(InWeighingClass info)
        {
            InWeighingDBLayer dbLayer = new InWeighingDBLayer();

            return dbLayer.UpdateInfo(info);
        }
        public bool checkupOutInfo(OutWeighingClass info)
        {
            OutWeighingDBLayer dbLayer = new OutWeighingDBLayer();

            return dbLayer.UpdateInfo(info);
        }
        public void GetSiteValue(string tgicId,ref ComboBox cb1, ref ComboBox cb2)
        {
            WeighingDBlayer dbLayer = new WeighingDBlayer();
            DataTable dt = new DataTable();

            dt = dbLayer.SelectSiteValue(tgicId);
            if (dt.Rows.Count > 0)
            {
                cb1.Text = dt.Rows[0]["sname1"].ToString();
                cb2.Text = dt.Rows[0]["sname2"].ToString();
            } 
        }

    }
    /*
     * 类名称：OtherWeighingLogic
     * 类功能描述：第三方称重
     *
     * 创建人：袁宇
     * 创建时间：2009-03-04
     *
     * 修改人：
     * 修改时间：
     * 修改内容：
     *
     */
    class OtherWeighingLogic
    {
        OtherWeighingDB dbLayer = new OtherWeighingDB();
        public void SetPersonnelInfo(ref ComboBox cb)
        {
            DataTable dt = dbLayer.SelectPersonnelInfo();

            cb.DataSource = dt;
            cb.DisplayMember = "name";
            cb.SelectedIndex = -1;
            cb.ValueMember = "id";

        }
        public DataTable GetThirdPartyWeight(string name, string model, string Client)
        {
            return dbLayer.SelectThirdPartyWeight(name, model, Client);
        }
        public bool saveData(OtherweighingClass info)
        {
            return dbLayer.InsertThirdPartyWeight(info);
        }
        public bool delData(string id)
        {
            return dbLayer.DeleteThirdPartyWeight(id);
        }
    }
    
}
