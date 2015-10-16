using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using autocoder.Function;

namespace WindowsFormsApplication1.Function
{
    class MakeWeb
    {
        private static DataSet dsTableDetails;//表字段详细信息
        protected static DataSet TabDetails;    //表详细信息

        public static DataSet GetTable(string CON, string dbName, string tableName)
        {
            TabDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, Common.GetTabDetails(dbName, tableName));
            StringBuilder retCode = new StringBuilder();
            dsTableDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, string.Format(Common.GetTableDetails, dbName, tableName));
            return dsTableDetails;
        }
    }
}
