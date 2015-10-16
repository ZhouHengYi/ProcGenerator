using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AutoCoder.Common
{
    class DataAccess
    {
        #region 根据服务器名称 用户名 密码 返回数据库列表
        public static DataSet GetDataBase(string servicename, string username, string password)
        {

            DataSet ds = new DataSet();
            string MyCon = "Data Source = " + servicename + "; User ID = " + username + ";Password=" + password + ";";
            string sql = "SELECT * FROM Master..sysdatabases WHERE dbid>4 ORDER BY name";
            try
            {
                using (SqlConnection con = new SqlConnection(MyCon))
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand(sql, con);
                    con.Open();
                    sda.SelectCommand = command;
                    sda.Fill(ds);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;

        }
        #endregion

        #region 根据数据库名称返回表名列表
        public static DataSet GetTable(string servicename, string database, string username, string password)
        {
            string MyCon = "Data Source=" + servicename + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            string sql = "select name,id from dbo.sysobjects where xtype = 'u' and name <> 'dtproperties' and name <> 'sysdiagrams'";
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(MyCon))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    sda.Fill(ds);
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }
        #endregion

        #region 根据表名返回字段集合
        public static DataSet GetFilers(string servicename, string database, string username, string password, string Id, string TbName)
        {
            string MyCon = "Data Source=" + servicename + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            //string sql = "select col.name,col.xtype,col.length,ty.name as tyname from dbo.syscolumns as col left join dbo.systypes as ty on ty.xtype = col.xtype where ty.name <> 'sysname' and col.id = @id";
            string sql = "Select c.name, c.system_type_id as xtype,c.max_length as length,ty.name as tyname,[Description] = ex.value From sys.columns c , sys.extended_properties ex  , dbo.systypes as ty Where ex.major_id = c.object_id AND ex.minor_id = c.column_id AND ex.name = 'MS_Description' AND ty.xtype = c.system_type_id AND c.object_id = @id AND ty.name <> 'sysname' ORDER BY OBJECT_NAME(c.object_id), c.column_id";
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(MyCon))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                    command.Parameters.Add("@id", SqlDbType.Int, 4).Value = Id;
                    SqlDataAdapter sda = new SqlDataAdapter(command);

                    sda.Fill(ds, "tb1");
                    command = new SqlCommand("sp_pkeys", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@table_name", SqlDbType.VarChar).Value = TbName;
                    sda = new SqlDataAdapter(command);
                    sda.Fill(ds, "tb2");
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }
        #endregion

        #region 执行生成的存储过程语句
        public static void Execute(string servicename, string database, string username, string password,string sql)
        {
            string MyCon = "Data Source=" + servicename + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            try
            {
                using (SqlConnection con = new SqlConnection(MyCon))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

    }
}
