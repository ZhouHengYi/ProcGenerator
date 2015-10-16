using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using autocoder.Function;

namespace WindowsFormsApplication1.Function
{
    class MakeModel
    {
        private static DataSet dsTableDetails;//表字段详细信息
        protected static DataSet TabDetails;    //表详细信息

        public static string GetModelCode(string CON, string dbName, string tableName)
        {
            TabDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, Common.GetTabDetails(dbName, tableName));
            StringBuilder retCode = new StringBuilder();
            dsTableDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, string.Format(Common.GetTableDetails, dbName, tableName));
            DataView dv = new DataView(dsTableDetails.Tables[0]);
            if (dv.Count > 0)
            {
                retCode.Append("using System;\n");
                retCode.Append("using System.Text;\n");
                retCode.Append("using System.Collections.Generic;\n");
                retCode.Append("using System.Data;\n");
                retCode.Append("using DBUtility.Model;\n");
                retCode.Append("namespace Model\n");
                retCode.Append("{\n");
                if (TabDetails != null && TabDetails.Tables.Count > 0 && TabDetails.Tables[0].Rows.Count > 0)
                    retCode.Append("\t//" + TabDetails.Tables[0].Rows[0]["Remark"] + "\n");
                else
                    retCode.Append("\t//" + tableName + "\n");
                retCode.Append("\t[DataTbName(\"" + tableName + "\")]\n");
                retCode.Append("\t[Serializable]\n");
                retCode.Append("\tpublic class " + tableName + "DO\n");
                retCode.Append("\t{\n");
                retCode.Append("\t\tpublic " + tableName + "DO(){  }\n");
                retCode.Append("\t\tpublic " + tableName + "DO(int _id){  \n\t\t\tthis.Id = _id ;\n\t\t}\n");
                for (int i = 0; i < dv.Count; i++)//FieldName FieldType FieldLength IsIdentity
                {
                    string type = "";
                    string sss = dv[i]["FieldType"].ToString();
                    switch (dv[i]["FieldType"].ToString())
                    {
                        case "int":
                            type = "int?";
                            break;
                        case "datetime":
                            type = "DateTime?";
                            break;
                        case "money":
                            type = "decimal?";
                            break;
                        case "decimal":
                            type = "decimal?";
                            break;
                        case "float":
                            type = "float?";
                            break;
                        default:
                            type = "string";
                            break;
                    }

                    //string privateName = string.Empty;

                    retCode.Append("\t\tprivate " + type + " _" + dv[i]["FieldName"] + ";\n");
                    retCode.Append("\t\t/// <summary>\n");
                    retCode.Append("\t\t/// " + dv[i]["Remark"] + "\n");
                    retCode.Append("\t\t/// </summary>\n");

                    if (dv[i]["IsPrimary"].ToString() == "1")
                        retCode.Append("\t\t[DataField(\"" + dv[i]["FieldName"] + "\", IsPrimaryKey = true)]\n");
                    else
                        retCode.Append("\t\t[DataField(\"" + dv[i]["FieldName"] + "\")]\n");

                    retCode.Append("\t\tpublic " + type + " " + dv[i]["FieldName"] + "\n");
                    retCode.Append("\t\t{\n");
                    retCode.Append("\t\t\tget { return _" + dv[i]["FieldName"] + " ;}\n");
                    retCode.Append("\t\t\tset { _" + dv[i]["FieldName"] + " = value; }\n");
                    retCode.Append("\t\t}\n");
                    retCode.Append("\t\t\n");
                }
                retCode.Append("\t}\n");
                retCode.Append("}");
            }
            return retCode.ToString();
        }
    }
}
