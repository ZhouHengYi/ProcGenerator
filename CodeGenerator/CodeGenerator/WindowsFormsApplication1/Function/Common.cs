using System;
using System.Collections.Generic;
using System.Text;

namespace autocoder.Function
{
    public static class Common
    {
        public static string ConnectToDataBase = "SELECT * FROM Master..sysdatabases WHERE crdate > '2010-1-1' ORDER BY name";

        public static string GetDataBase = "SELECT * FROM Master..sysdatabases WHERE crdate > '2010-1-1' ORDER BY name";

        public static string GetTableName = " SELECT name,id FROM [{0}] ..sysobjects  "
            + " WHERE type='U' AND name <> 'dtproperties' "
            + " ORDER BY name ";

        //GetBaseTables  获取表里所有字段与详细信息
        public static string GetTableDetails = " use [{0}]  SELECT syscolumns.name as 'FieldName', systypes.name as 'FieldType', syscolumns.length as 'FieldLength', " +
                "		CASE syscolumns.isnullable WHEN 1 THEN 1 ELSE 0 END AS 'IsNull' ," +
                "		CASE A.INDID WHEN 1 THEN 1 ELSE 0 END AS 'IsPrimary' ," +
                "		CASE syscolumns.status WHEN 128 THEN 1 ELSE 0 END AS 'IsIdentity' ," +
                "		1 AS 'WinFormEnable' ," +
                "		1 AS 'InDataGrid' ," +
                "       (Select value From sys.extended_properties where major_id = syscolumns.id and minor_id = syscolumns.colid) as Remark" +
                " FROM sysobjects " +
                "		INNER JOIN syscolumns ON syscolumns.id = sysobjects.id " +
                "		INNER JOIN systypes ON systypes.xtype = syscolumns.xtype AND systypes.[name] <> 'sysname' " +
                "		LEFT JOIN ( " +
                "			SELECT sysindexkeys.* FROM sysindexkeys " +
                "				INNER JOIN sysobjects ON sysobjects.id = sysindexkeys.id " +
                "			WHERE sysindexkeys.indid = 1 " +
                "		) A " +
                "		ON A.ID = SYSOBJECTS.ID AND A.COLID = SYSCOLUMNS.COLID " +
                " WHERE (sysobjects.type='U' or sysobjects.type='V')" +
                "   AND sysobjects.name <> 'dtproperties' " +
                "	  AND sysobjects.name = '{1}'" +
                " ORDER BY syscolumns.colid";

        //getUp 获取该表的所有存储过程
        public static string GetTableUsp = "use [{0}] SELECT sysobjects.name as 'UspName' FROM sysobjects	WHERE sysobjects.xtype = 'P'  AND  sysobjects.name LIKE 'usp_{1}%' ORDER BY sysobjects.name";

        /// <summary>
        /// 获取表的描述信息
        /// </summary>
        /// <returns></returns>
        public static string GetTabDetails(string dbName,string tablName)
        {
            return "use ["+dbName+"] SELECT '" + tablName + "' as TableName,[value]as Remark From sys.extended_properties where major_id = object_id('" + tablName + "') and minor_Id = 0";
        }

        public static string GetText = "use [{0}] exec sp_helptext'{1}'";
    }
}
