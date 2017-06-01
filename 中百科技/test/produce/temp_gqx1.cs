using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DasherStation.common;
using System.Collections;
using System.Data;

namespace DasherStation.produce
{


    //#region  //数据库操作类：备品配件入库单

    ///*
    //* 类名称：ProductionParameterDB
    //* 类功能描述：为“生产参数”提供数据库操作
    //*
    //* 创建人：关启学
    //* 创建时间：2009-04-15
    //*
    //* 修改人：
    //* 修改时间：
    //* 修改内容：
    //*
    //*/

    //class ProductionParameterDB
    //{
    //    #region // 参数初始化部分

    //    // 用户“拌和站软件”的数据库操作
    //    private SqlHelper sqlHelper = new SqlHelper();


    //    // 生产参数 SQL字符串
    //    private string productionParameterSelectStr =
    //        "   SELECT "
    //        + "   equipmentInformation.no                   AS [equipmentNo],"      //设备编号
    //        + "   equipmentName.name                        AS [equipmentName],"    //设备名称
    //        + "   equipmentModel.model                      AS [equipmentModel],"   //设备规格
    //        + "   produceMeasureParameter.maxTemperature    AS [maxTemperature],"   //温度上限
    //        + "   produceMeasureParameter.minTemperature    AS [minTemperature],"   //温度下限
    //        + "   produceMeasureParameter.asphaltumError    AS [asphaltumError],"   //沥青偏差
    //        + "   produceMeasureParameter.stoneError        AS [stoneError],"       //石料偏差
    //        + "   produceMeasureParameter.mark              AS [mark],"             //使用标记（标明该条记录是否使用）


    //        + "   produceMeasureParameter.inputDate         AS [inputDate],"        //录入时间
    //        + "   produceMeasureParameter.inputMan          AS [inputMan],"         //录入人
    //        + "   produceMeasureParameter.id                AS [id],"               //id
    //        + "   produceMeasureParameter.eiId              AS [eiId]"              //设备信息表id
    //        + " FROM produceMeasureParameter, equipmentInformation, equipmentName, equipmentModel"
    //        + " WHERE produceMeasureParameter.eiId = equipmentInformation.id"
    //        + " AND   equipmentInformation.enId = equipmentName.id"
    //        + " AND   equipmentInformation.emId = equipmentModel.id";

    //    #endregion


    //    #region//用于填充“下拉列表”、与下拉列表相关控件数据的方法

    //    //查询“设备信息”：用于下拉列表
    //    public DataTable GetEquipmentInfo()
    //    {
    //        string selectString = "SELECT id, no FROM equipmentInformation";
    //        return sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];
    //    }

    //    //查询“设备名称”，根据“设备id”
    //    public string GetEquipmentName(long enId)
    //    {
    //        string selectString =
    //            " SELECT equipmentName.name FROM equipmentName, equipmentInformation "
    //            + "WHERE equipmentName.id = equipmentInformation.enId AND equipmentInformation.id = " + enId;

    //        DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

    //        string name = "";
    //        if (dt.Rows.Count > 0)
    //        {
    //            name = dt.Rows[0]["name"].ToString();
    //        }

    //        return name;
    //    }

    //    //查询“设备规格”，根据“设备id”
    //    public string GetEquipmentModel(long emId)
    //    {
    //        string selectString =
    //            " SELECT equipmentModel.model FROM equipmentModel, equipmentInformation "
    //            + "WHERE equipmentModel.id = equipmentInformation.emId AND equipmentInformation.id = " + emId;

    //        DataTable dt = sqlHelper.QueryForDateSet(new ArrayList() { selectString }).Tables[0];

    //        string name = "";
    //        if (dt.Rows.Count > 0)
    //        {
    //            name = dt.Rows[0]["model"].ToString();
    //        }

    //        return name;
    //    }


    //    #endregion


    //    #region // 用于填充“DataGridView”数据内容的方法

    //    //查询“生产参数”
    //    public DataTable GetProductionParameter()
    //    {
    //        string select = productionParameterSelectStr;
    //        return sqlHelper.QueryForDateSet(new ArrayList() { select }).Tables[0];
    //    }

    //    //查询“生产参数”，按“设备编号”查询
    //    public DataTable GetProductionParameterByNo(string equipmentNo)
    //    {
    //        string select = productionParameterSelectStr + " AND equipmentInformation.no LIKE '%" + equipmentNo + "%'";
    //        return sqlHelper.QueryForDateSet(new ArrayList() { select }).Tables[0];
    //    }

    //    //查询“生产参数”，按“设备名称”查询
    //    public DataTable GetProductionParameterByName(string equipmentName)
    //    {
    //        string select = productionParameterSelectStr + " AND equipmentName.name LIKE '%" + equipmentName + "%'";
    //        return sqlHelper.QueryForDateSet(new ArrayList() { select }).Tables[0];
    //    }

    //    //查询“生产参数”，按“设备名称”查询
    //    public DataTable GetProductionParameterByDate(DateTime dt)
    //    {
    //        string select = productionParameterSelectStr + " AND produceMeasureParameter.inputDate >= '" + dt 
    //            + "' AND produceMeasureParameter.inputDate < '" + dt.AddDays(1) + "'";
    //        return sqlHelper.QueryForDateSet(new ArrayList() { select }).Tables[0];
    //    }
        
    //    #endregion


    //    #region//业务实体操作方法

    //    //插入新的“生产参数”
    //    public bool InsertProductionParameter(ProductionParameter productionParameter)
    //    {
    //        int mark = 0;
    //        if (productionParameter.Mark)
    //        {
    //            mark = 1;
    //        }

    //        string insertStr =
    //            "   INSERT INTO produceMeasureParameter"
    //            + " (maxTemperature, minTemperature, asphaltumError, stoneError, mark, eiId, inputDate, inputMan)"
    //            + " VALUES"
    //            + " ({0},{1},{2},{3},'{4}',{5},getdate(),'{6}')";


    //        string sqlString = string.Format(insertStr, productionParameter.MaxTemperature, productionParameter.MinTemperature, productionParameter.AsphaltumError
    //            , productionParameter.StoneError, productionParameter.Mark, productionParameter.EiId, productionParameter.InputMan);
    //        return sqlHelper.ExecuteTransaction(new ArrayList() { sqlString });

    //    }

    //    //删除“生产参数”，根据生产参数id
    //    public void DeleteProductionParamete(long id)
    //    {
    //        string sqlString = "DELETE FROM produceMeasureParameter WHERE id = " + id;
    //        sqlHelper.ExecuteTransaction(new ArrayList() { sqlString });
    //    }
    
    //    #endregion        

    //}

    //#endregion


}
