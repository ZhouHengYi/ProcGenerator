using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AutoCoder.Common;
using System.Text.RegularExpressions;
using System.IO;


namespace SQL.NET
{
    public partial class Growup : Form
    {
        public string webConfigCode;
        public Growup()
        {
            InitializeComponent();
            //this.skinEngine1.SkinFile = "SportsBlack.ssk";
            textBox_Username.Text = "sa";
            textBox_Password.Text = "sa.";
            comboBox_Target.SelectedIndex = 0;
        }

        private void but_getDatabase_Click(object sender, EventArgs e)
        {
            string service = comboBox_Service.Text.ToString();
            string username = textBox_Username.Text.ToString();
            string password = textBox_Password.Text.ToString();
            if (service == "")
            {
                MessageBox.Show("请选择服务器！");
                return;
            }
            if (username == "")
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (password == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            DataSet ds = DataAccess.GetDataBase(service, username, password);

            if (DBHelper.IsEmptyDS(ds))
            {
                comboBox_Database.DataSource = ds.Tables[0];
                comboBox_Database.DisplayMember = "name";
                comboBox_Database.ValueMember = "dbid";
            }
        }

        private void comboBox_Service_Click(object sender, EventArgs e)
        {
            if (comboBox_Service.Items.Count <= 0)
            {
                string[] serverList = SqlLocator.GetLocalSqlServerNamesWithAPI();
                if (serverList == null || serverList.Length <= 0)
                    return;

                comboBox_Service.Items.Clear();
                foreach (string serverName in serverList)
                {
                    comboBox_Service.Items.Add(serverName);
                }
            }
        }

        private void comboBox_Database_SelectedIndexChanged(object sender, EventArgs e)
        {
            string service = comboBox_Service.Text.ToString();
            string database = comboBox_Database.Text.ToString();
            string username = textBox_Username.Text.ToString();
            string password = textBox_Password.Text.ToString();
            if (database == "System.Data.DataRowView")
            {
                return;
            }
            if (service == "")
            {
                MessageBox.Show("请选择服务器！");
                return;
            }
            if (database == "")
            {
                MessageBox.Show("请选择数据库！");
                return;
            }
            if (username == "")
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (password == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            DataSet ds = DataAccess.GetTable(service, database, username, password);

            if (DBHelper.IsEmptyDS(ds))
            {
                listBox_Table.DataSource = ds.Tables[0];
                listBox_Table.DisplayMember = "name";
                listBox_Table.ValueMember = "id";
            }
        }

        private void listBox_Table_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 验证
            if (listBox_Table.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            string service = comboBox_Service.Text.ToString();
            string database = comboBox_Database.Text.ToString();
            string username = textBox_Username.Text.ToString();
            string password = textBox_Password.Text.ToString();
            if (service == "")
            {
                MessageBox.Show("请选择服务器！");
                return;
            }
            if (database == "")
            {
                MessageBox.Show("请选择数据库！");
                return;
            }
            if (username == "")
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (password == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            #endregion

            DataSet ds = DataAccess.GetFilers(service, database, username, password, listBox_Table.SelectedValue.ToString(), listBox_Table.Text.ToString());
            string files = "";
            if (DBHelper.IsEmptyDS(ds))
            {
                txt_tabname.Text = listBox_Table.Text.ToString();
                txt_ModelName.Text = txt_tabname.Text;
                if (ds.Tables["tb2"].Rows.Count > 0)
                {
                    txt_key.Text = ds.Tables["tb2"].Rows[0]["COLUMN_NAME"].ToString();
                    txt_ModelKey.Text = txt_key.Text;
                }
                else
                {
                    MessageBox.Show("当前表无主键！");
                    return;
                }
                string _files = "";
                foreach (DataRow dr in ds.Tables["tb1"].Rows)
                {
                    if (dr["tyname"].ToString() == "varchar")
                    {
                        files += dr["name"].ToString() + "[" + dr["tyname"] + "(" + dr["length"] + ")]" + "{" + dr["Description"] + "},";
                    }
                    else if (dr["tyname"].ToString() == "nvarchar")
                    {
                        files += dr["name"].ToString() + "[" + dr["tyname"] + "(" + Convert.ToInt32(dr["length"].ToString()) / 2 + ")]" + "{" + dr["Description"] + "},";
                    }
                    else
                    {
                        files += dr["name"].ToString() + "[" + dr["tyname"] + "]" + "{" + dr["Description"] + "},";
                        string sss = ds.Tables["tb2"].Rows[0]["COLUMN_NAME"].ToString();
                    }

                    if (dr["name"].ToString() != txt_key.Text)
                    {
                        _files += "@" + dr["name"].ToString() + ",";
                    }
                }
                textBox4.Text = "<!--" + txt_tabname.Text + "表的Sql操作-->\n<add key=\"USP_" + txt_tabname.Text + "_ADD\" value=\"" + _files.Remove(_files.Length - 1) + ",@AdminId,@AdminName,@IP,@MAC\"/>\n<add key=\"USP_" + txt_tabname.Text + "_Update\" value=\"@" + txt_key.Text + "," + _files.Remove(_files.Length - 1) + ",@AdminId,@AdminName,@IP,@MAC\"/>\n<add key=\"USP_" + txt_tabname.Text + "_GetModel\" value=\"@" + txt_key.Text + "\"/>\n";
                txt_fields.Text = files.Remove(files.Length - 1);
                webConfigCode += textBox4.Text;
            }
        }

        private void comboBox_Database_Click(object sender, EventArgs e)
        {
            if (comboBox_Database.Text == "")
            {
                but_getDatabase_Click(null, null);
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            this.textBox4.SelectAll();
            textBox4.Copy();
        }

        #region 存储过程生成
        private void But_CreateProc_Click(object sender, EventArgs e)
        {
            if (txt_tabname.Text.Trim() == "")
            {
                Lb_tabname.Text = "表名不能为空!";
                return;
            }
            if (txt_key.Text.Trim() == "")
            {
                Lb_Key.Text = "主键不能为空!";
                return;
            }
            string tabname = txt_tabname.Text;
            string key = txt_key.Text;
            string[] fields = txt_fields.Text.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries);
            if (fields.Length == 0)
            {
                Lb_field.Text = "字段集不能为空!";
                return;
            }
            if (!txt_fields.Text.Contains(key))
            {
                Lb_Key.Text = "此处主键必须与字段处一致!";
                return;
            }
            CreateSqlCode(tabname, key, fields);
            MessageBox.Show("生成成功！");
        }

        private void CreateSqlCode(string tabname, string key, string[] fields)
        {
            string datetime = DateTime.Now.ToString();

            string[,] _fields = new string[fields.Length, 2];
            string field = "";
            for (int i = 0; i < fields.Length; i++)
            {
                field = fields[i];
                _fields[i, 0] = field.Substring(0, field.IndexOf('['));
                _fields[i, 1] = field.Substring(field.IndexOf('[') + 1, field.IndexOf(']') - field.IndexOf('[') - 1);
            }

            string strProc = "";
            string strIf = "";
            string sp_type = "";
            string sp_value = "";
            int len = _fields.Length;

            #region 添加数据
            strProc += "use " + comboBox_Database.Text + "\nGO\n\n";

            strProc += "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[USP_" + tabname + "_ADD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)\ndrop procedure [dbo].[USP_" + tabname + "_ADD]\nGO\n";
            strProc += "------------------------------------\n";
            strProc += "/*\n用途：增加一条数据\n";
            strProc += "表名：" + tabname + "\n";
            strProc += "日期：" + datetime + "\n*/\n";
            strProc += "------------------------------------\n";
            strProc += "CREATE PROCEDURE USP_" + tabname + "_ADD\n";
            for (int i = 0; i < len / 2; i++)
            {
                if (_fields[i, 0] != key)
                {

                    strProc += "@" + _fields[i, 0] + " " + _fields[i, 1] + "=null,\n";
                    sp_type += "@" + _fields[i, 0] + " " + _fields[i, 1] + ",";
                    sp_value += "@" + _fields[i, 0] + ",";

                    if (_fields[i, 1].Contains("text"))
                        strIf += "if(@" + _fields[i, 0] + " is not null)\n";
                    else
                        strIf += "if(@" + _fields[i, 0] + " is not null)\n";

                    strIf += "begin\n";
                    strIf += "set @strSql1 = @strSql1 + '[" + _fields[i, 0] + "],'\n";
                    strIf += "set @strSql2 = @strSql2 +'@" + _fields[i, 0] + ",'\n";
                    strIf += "end\n";
                }
                else
                {
                    //strProc += "@" + _fields[i, 0] + " " + _fields[i, 1] + " output,\n";
                }
            }
            strProc = strProc.Remove(strProc.Length - 1);
            sp_type = sp_type.Remove(sp_type.Length - 1);
            sp_value = sp_value.Remove(sp_value.Length - 1);
            if (tabname != "WebLog")
                strProc += "\n@AdminId int=null,\n@AdminName nvarchar(50)=null,\n@IP varchar(15)=null,\n@MAC varchar(17)=null\n";
            else
            {
                strProc = strProc.Remove(strProc.Length - 1);
                strProc += "\n";
            }
            strProc += "as\ndeclare @strSql nvarchar(" + len * 50 + "),@strSql1 nvarchar(" + len * 25 + "),@strSql2 nvarchar(" + len * 25 + ")\n";
            strProc += "set @strSql = ''\nset @strSql1 = ''\nset @strSql2 = ''\n";
            strProc += strIf;
            strProc += "set @strSql1 = substring(@strSql1,0,len(@strSql1))\n";
            strProc += "set @strSql2 = substring(@strSql2,0,len(@strSql2))\n";
            strProc += "set @strSql = 'INSERT INTO [" + tabname + "] ('+@strSql1+')VALUES('+@strSql2+')'\n";
            strProc += "exec sp_executesql @strSql";
            strProc += ",N'" + sp_type + "'," + sp_value + "\n";
            if (tabname != "WebLog")
            {
                strProc += "Declare @Id int\nSET @Id = @@IDENTITY";
                strProc += "--写入添加日志\ninsert into WebLog (Admin_Id,Content,IP,MAC) values (@AdminId,'管理员 '+@AdminName+' 添加 表 [" + tabname + "] 编号 ['+ltrim(str(@Id))+']',@IP,@MAC)\n";
            }
            strProc += "GO";
            #endregion

            #region 修改数据
            strIf = "";
            strProc += "\n\n";
            strProc += "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[USP_" + tabname + "_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)\ndrop procedure [dbo].[USP_" + tabname + "_Update]\nGO\n";
            strProc += "------------------------------------\n";
            strProc += "/*\n用途：修改一条数据\n";
            strProc += "表名：" + tabname + "\n";
            strProc += "日期：" + datetime + "\n*/\n";
            strProc += "------------------------------------\n";
            strProc += "CREATE PROCEDURE USP_" + tabname + "_Update\n";
            for (int i = 0; i < len / 2; i++)
            {
                strProc += "@" + _fields[i, 0] + " " + _fields[i, 1] + "=null,\n";

                if (_fields[i, 0] != key)
                {
                    if (_fields[i, 1].Contains("text"))
                        strIf += "if(@" + _fields[i, 0] + " is not null)\n";
                    else
                        strIf += "if(@" + _fields[i, 0] + " is not null)\n";
                    strIf += "begin\n";
                    strIf += "set @strVal = @strVal + '[" + _fields[i, 0] + "] =@" + _fields[i, 0] + ",'\n";
                    strIf += "end\n";
                }
            }
            strProc = strProc.Remove(strProc.Length - 1);
            if (tabname != "WebLog")
                strProc += "\n@AdminId int=null,\n@AdminName nvarchar(50)=null,\n@IP varchar(15)=null,\n@MAC varchar(17)=null\n";
            else
            {
                strProc = strProc.Remove(strProc.Length - 1);
                strProc += "\n";
            }
            strProc += "as\ndeclare @strSql nvarchar(" + len * 50 + "),@strVal nvarchar(" + len * 50 + ")\n";
            strProc += "set @strSql = ''\nset @strVal = ''\n";

            strProc += strIf;
            strProc += "set @strVal = substring(@strVal,0,len(@strVal));\n";
            strProc += "set @strSql = 'update [" + tabname + "] set '+@strVal+' where " + key + " ='+str(@" + key + ");\n";
            strProc += "exec sp_executesql @strSql";
            strProc += ",N'" + sp_type + "'," + sp_value + "\n";
            if (tabname != "WebLog")
                strProc += "--写入修改日志\ninsert into WebLog (Admin_Id,Content,IP,MAC) values (@AdminId,'管理员 '+@AdminName+' 修改 表 [" + tabname + "] 编号 ['+ltrim((@Id))+']',@IP,@MAC)\n";
            strProc += "GO";

            #endregion

            #region 查询数据
            #region Return Model
            strProc += "\n\n";
            strProc += "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[USP_" + tabname + "_GetModel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)\ndrop procedure [dbo].[USP_" + tabname + "_GetModel]\nGO\n";
            strProc += "------------------------------------\n";
            strProc += "/*\n用途：得到实体对象的详细信息\n";
            strProc += "表名：" + tabname + "\n";
            strProc += "日期：" + datetime + "\n*/\n";
            strProc += "------------------------------------\n";
            strProc += "CREATE PROCEDURE USP_" + tabname + "_GetModel\n";
            strProc += "@" + key + " int\n";
            strProc += "AS\n";
            strProc += "\tSELECT ";
            for (int i = 0; i < len / 2; i++)
            {

                strProc += "[" + _fields[i, 0] + "],";

            }
            strProc = strProc.Remove(strProc.Length - 1);
            strProc += " FROM [" + tabname + "] WHERE " + key + "=@" + key + "\n";
            strProc += "GO";
            #endregion

            #endregion

            if (comboBox_Target.SelectedIndex == 0)
            {
                if (!Directory.Exists(comboBox_Database.Text + "/SqlCode/"))
                {
                    Directory.CreateDirectory(comboBox_Database.Text + "/SqlCode/");
                }
                File.WriteAllText(comboBox_Database.Text + "/SqlCode/" + tabname + ".sql", strProc, Encoding.UTF8);
                if (listBox_Table.SelectedIndex != listBox_Table.Items.Count - 1)
                    listBox_Table.SelectedIndex = listBox_Table.SelectedIndex + 1;
                else
                    listBox_Table.SelectedIndex = 0;
            }
        }
        #endregion

        #region 创建实体
        private void btn_CreateModel_Click(object sender, EventArgs e)
        {
            if (txt_tabname.Text.Trim() == "")
            {
                Lb_tabname.Text = "表名不能为空!";
                return;
            }
            if (txt_key.Text.Trim() == "")
            {
                Lb_Key.Text = "主键不能为空!";
                return;
            }
            string tabname = txt_tabname.Text;
            string key = txt_key.Text;
            string[] fields = txt_fields.Text.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries);
            if (fields.Length == 0)
            {
                Lb_field.Text = "字段集不能为空!";
                return;
            }
            if (!txt_fields.Text.Contains(key))
            {
                Lb_Key.Text = "此处主键必须与字段处一致!";
                return;
            }
            CreateModel(tabname, fields);
            MessageBox.Show("生成成功！");
        }
        #endregion

        #region 创建实体方法
        private void CreateModel(string tabname, string[] fields)
        {
            try
            {
                string[,] _fields = new string[fields.Length, 3];
                string field = "";
                for (int i = 0; i < fields.Length; i++)
                {
                    field = fields[i];
                    _fields[i, 0] = field.Substring(0, field.IndexOf('['));
                    _fields[i, 1] = field.Substring(field.IndexOf('[') + 1, field.IndexOf(']') - field.IndexOf('[') - 1);
                    _fields[i, 2] = field.Substring(field.IndexOf('{') + 1, field.IndexOf('}') - field.IndexOf('{') - 1);
                }

                string strProc = "";
                string model_type = "";
                int len = _fields.Length;

                strProc += "using System;";
                strProc += "\nnamespace Maticsoft.Model";
                strProc += "\n{";
                strProc += "\n\t/// <summary>";
                strProc += "\n\t/// " + txt_tabname.Text + ":实体类(属性说明自动提取数据库字段的描述信息)";
                strProc += "\n\t/// </summary>";
                strProc += "\n\t[Serializable]";
                strProc += "\n\tpublic class " + txt_tabname.Text + "DO";
                strProc += "\n\t{";
                strProc += "\n\t\tpublic " + txt_tabname.Text + "DO() { }";
                strProc += "\n\t\t#region Model";
                for (int i = 0; i < len / 3; i++)
                {
                    if (_fields[i, 1] == "int")
                        model_type = "int";
                    else if (_fields[i, 1] == "datetime")
                        model_type = "DateTime";
                    else if (_fields[i, 1] == "money")
                        model_type = "double";
                    else if (_fields[i, 1] == "float")
                        model_type = "double";
                    else if (_fields[i, 1] == "text")
                        model_type = "string";
                    else if (_fields[i, 1] == "ntext")
                        model_type = "string";
                    else if (_fields[i, 1].ToString().IndexOf("varchar") > 0 || _fields[i, 1].ToString().IndexOf("nvarchar") > 0)
                        model_type = "string";
                    int index = _fields[i, 1].ToString().IndexOf("nvarchar");
                    strProc += "\n\t\tprivate " + model_type + " _" + _fields[i, 0] + ";";
                    strProc += "\n\t\t/// <summary>";
                    strProc += "\n\t\t/// " + _fields[i, 2];
                    strProc += "\n\t\t/// </summary>";
                    strProc += "\n\t\tpublic " + model_type + " " + _fields[i, 0];
                    strProc += "\n\t\t{";
                    strProc += "\n\t\t\tset { _" + _fields[i, 0] + " = value; }";
                    strProc += "\n\t\t\tget { return _" + _fields[i, 0] + "; }";
                    strProc += "\n\t\t}";
                }
                //其他信息
                if (txt_tabname.Text != "WebLog" && txt_tabname.Text != "GetList" && txt_tabname.Text != "GetPage")
                    strProc += CreateModelAttributeInfo(tabname);
                strProc += "\n\t\t#endregion";
                strProc += "\n\t}";
                strProc += "\n}";
                if (!Directory.Exists(comboBox_Database.Text + "/Model/"))
                {
                    Directory.CreateDirectory(comboBox_Database.Text + "/Model/");
                }
                File.WriteAllText(comboBox_Database.Text + "/Model/" + tabname + "DO.cs", strProc, Encoding.UTF8);
                if (listBox_Table.SelectedIndex != listBox_Table.Items.Count - 1)
                    listBox_Table.SelectedIndex = listBox_Table.SelectedIndex + 1;
                else
                    listBox_Table.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 获取实体其他属性信息
        public string CreateModelAttributeInfo(string tblName)
        {
            string strProc = string.Empty;
            strProc += "\n\t\t/// <summary>";
            strProc += "\n\t\t/// 当前机器Ip";
            strProc += "\n\t\t/// </summary>";
            strProc += "\n\t\tpublic string Ip";
            strProc += "\n\t\t{";
            strProc += "\n\t\t\tget { return Common.GetIP(); }";
            strProc += "\n\t\t}";

            strProc += "\n\t\t/// <summary>";
            strProc += "\n\t\t/// MAC地址";
            strProc += "\n\t\t/// </summary>";
            strProc += "\n\t\tpublic string MAC";
            strProc += "\n\t\t{";
            strProc += "\n\t\t\tget { return Common.GetMAC(); }";
            strProc += "\n\t\t}";

            strProc += "\n\t\t/// <summary>";
            strProc += "\n\t\t/// 管理员ID";
            strProc += "\n\t\t/// </summary>";
            strProc += "\n\t\tpublic int AdminId";
            strProc += "\n\t\t{";
            strProc += "\n\t\t\tget { return Common.GetAdminId(); }";
            strProc += "\n\t\t}";

            strProc += "\n\t\t/// <summary>";
            strProc += "\n\t\t/// 管理员名称";
            strProc += "\n\t\t/// </summary>";
            strProc += "\n\t\tpublic string AdminName";
            strProc += "\n\t\t{";
            strProc += "\n\t\t\tget { return Common.GetAdminName(); }";
            strProc += "\n\t\t}";

            strProc += "\n\t\t/// <summary>";
            strProc += "\n\t\t/// 对应的表名";
            strProc += "\n\t\t/// </summary>";
            strProc += "\n\t\tpublic string TblName";
            strProc += "\n\t\t{";
            strProc += "\n\t\t\tget { return \"" + tblName + "\" ; }";
            strProc += "\n\t\t}";

            strProc += "\n\t\tprivate string _Ids;";
            strProc += "\n\t\t/// <summary>";
            strProc += "\n\t\t/// ID集合";
            strProc += "\n\t\t/// </summary>";
            strProc += "\n\t\tpublic string Ids";
            strProc += "\n\t\t{";
            strProc += "\n\t\t\tset { _Ids = value; }";
            strProc += "\n\t\t\tget { return _Ids ; }";
            strProc += "\n\t\t}";
            return strProc;
        }
        #endregion

        #region 生成通用方法
        private void btn_CreateTY_Click(object sender, EventArgs e)
        {
            try
            {
                string strProc = "use " + comboBox_Database.Text;
                strProc += "\nGo";
                //Delete
                strProc += "\nif exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)";
                strProc += "\ndrop procedure [dbo].[Delete]";
                strProc += "\nGO";
                strProc += "\n------------------------------------";
                strProc += "\n--删除信息";
                strProc += "\n------------------------------------";
                strProc += "\nCreate PROCEDURE [dbo].[Delete]";
                strProc += "\n@TblName nvarchar(1000)=null,";
                strProc += "\n@Ids nvarchar(1000) = null,";
                strProc += "\n@AdminId int=null,";
                strProc += "\n@AdminName nvarchar(50)=null,";
                strProc += "\n@IP varchar(15)=null,";
                strProc += "\n@MAC varchar(17)=null";
                strProc += "\nAS";
                strProc += "\nDeclare @StrSql nvarchar(1000)";
                strProc += "\nif (patindex('%,%',@ids)>0)";
                strProc += "\nBEGIN";
                strProc += "\nSet @StrSql = 'Delete [' + @TblName + '] Where Id in ('+@Ids+')'";
                strProc += "\nexec(@StrSql)";
                strProc += "\nEND";
                strProc += "\nelse";
                strProc += "\nBEGIN";
                strProc += "\nSet @StrSql = 'Delete [' + @TblName + '] Where Id = '+@Ids+''";
                strProc += "\nexec(@StrSql)";
                strProc += "\nEND";
                strProc += "\n--写入删除日志";
                strProc += "\ninsert into [WebLog] (Admin_Id,Content,IP,MAC) values (@AdminId,'管理员 '+@AdminName+' 删除 表 ['+@TblName+'] 编号 ['+ltrim(@Ids)+']',@IP,@MAC)";
                strProc += "\nGo";
                //UpdateStatus
                strProc += "\nif exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)";
                strProc += "\ndrop procedure [dbo].[UpdateStatus]";
                strProc += "\nGO";
                strProc += "\n------------------------------------";
                strProc += "\n--更新信息状态";
                strProc += "\n------------------------------------";
                strProc += "\nCreate PROCEDURE [dbo].[UpdateStatus]";
                strProc += "\n@TblName nvarchar(1000)=null,";
                strProc += "\n@Ids nvarchar(1000) = null,";
                strProc += "\n@Status nvarchar(100) = null,";
                strProc += "\n@AdminId int=null,";
                strProc += "\n@AdminName nvarchar(50)=null,";
                strProc += "\n@IP varchar(15)=null,";
                strProc += "\n@MAC varchar(17)=null";
                strProc += "\nAS";
                strProc += "\nDeclare @StrSql nvarchar(1000)";
                strProc += "\nif (patindex('%,%',@ids)>0)";
                strProc += "\nBEGIN";
                strProc += "\nSet @StrSql = 'Update [' + @TblName + '] Set Status = '+cast(@Status as nvarchar(20))+' Where Id in ('+@Ids+')'";
                strProc += "\nexec(@StrSql)";
                strProc += "\nEND";
                strProc += "\nelse";
                strProc += "\nBEGIN";
                strProc += "\nSet @StrSql = 'Update [' + @TblName + '] Set Status = '+cast(@Status as nvarchar(20))+' Where Id = '+@Ids+''";
                strProc += "\nexec(@StrSql)";
                strProc += "\nEND";
                strProc += "\n--写入删除日志";
                strProc += "\ninsert into WebLog (Admin_Id,Content,IP,MAC) values (@AdminId,'管理员 '+@AdminName+' 伪删除 表 ['+@TblName+'] 编号 ['+ltrim(@Ids)+']',@IP,@MAC)";
                strProc += "\nGo";
                //GetList
                strProc += "\nif exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)";
                strProc += "\ndrop procedure [dbo].[GetList]";
                strProc += "\nGO";
                strProc += "\n------------------------------------";
                strProc += "\n--根据条件获取数据";
                strProc += "\n------------------------------------";
                strProc += "\nCreate PROCEDURE [dbo].[GetList]";
                strProc += "\n@Top nvarchar(10)=null,";
                strProc += "\n@Table nvarchar(200)=null,";
                strProc += "\n@Where nvarchar(1400)=null,";
                strProc += "\n@Order nvarchar(100)=null";
                strProc += "\nAS";
                strProc += "\ndeclare @strSql nvarchar(2040),@StrTop nvarchar(20),@StrTable nvarchar(200),@StrWhere nvarchar(1110),@StrOrder nvarchar(110)";
                strProc += "\nset @StrTop = ''";
                strProc += "\nset @StrTable = ''";
                strProc += "\nset @StrWhere = ' where Status <> 99'";
                strProc += "\nset @StrOrder = ''";
                strProc += "\nif(IsNull(@Top,'')<>'')";
                strProc += "\nbegin";
                strProc += "\nset @StrTop = 'top '+@Top";
                strProc += "\nend";
                strProc += "\nif(IsNull(@Table,'')<>'')";
                strProc += "\nbegin";
                strProc += "\nif(CharIndex('dbo.',@Table) = 0)";
                strProc += "\nBegin";
                strProc += "\nset @StrTable = 'From [' + @Table + ']'";                
                strProc += "\nEnd";
                strProc += "\nelse";
                strProc += "\nBegin";
                strProc += "\nset @StrTable = 'From ' + @Table";
                strProc += "\nEnd";
                strProc += "\nend";
                strProc += "\nif(IsNull(@Where,'')<>'')";
                strProc += "\nbegin";
                strProc += "\nset @StrWhere = @StrWhere + ' and ' + @Where";
                strProc += "\nend";
                strProc += "\nif(IsNull(@Order,'')<>'')";
                strProc += "\nbegin";
                strProc += "\nset @StrOrder = 'order by '+@Order";
                strProc += "\nend";
                strProc += "\nset @strSql= 'SELECT '+@StrTop+' * '+@StrTable+' '+@StrWhere+' '+@StrOrder";
                strProc += "\nprint @strSql";
                strProc += "\nexec(@strSql)";
                strProc += "\nGo";
                //GetPage
                strProc += "\nif exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)";
                strProc += "\ndrop procedure [dbo].[GetPage]";
                strProc += "\nGO";
                strProc += "\n------------------------------------";
                strProc += "\n--分页获取数据";
                strProc += "\n------------------------------------";
                strProc += "\nCreate PROCEDURE [dbo].[GetPage]";
                strProc += "\n(";
                strProc += "\n@CurrPage int = 1,                       --当前页页码 (即Top currPage) ";
                strProc += "\n@PageSize int = 10,                       --分页大小 ";
                strProc += "\n@TabName varchar(50),                     --需要查看的表名 (即 from table_name) ";
                strProc += "\n@StrColumn varchar(1000) = null,         --需要得到的字段 (即 column1,column2,......)";
                strProc += "\n@StrWhere nvarchar(1000) = null,         --查询条件 (即 where condition......) 不用加where关键字 ";
                strProc += "\n@StrOrder varchar(100) = null        --排序的字段名 (即 order by column asc/desc)";
                strProc += "\n)";
                strProc += "\nAS ";
                strProc += "\nDeclare @Sql nvarchar(max) --定义Sql语句";
                strProc += "\nDeclare @StartRowNum nvarchar(100),@EndRowNum nvarchar(100)";
                strProc += "\nSet @StartRowNum = cast((@CurrPage - 1) * @PageSize as nvarchar(10)) --开始RowNumber";
                strProc += "\nSet @EndRowNum = cast(@CurrPage * @PageSize as nvarchar(10))			 --结束RowNumber";
                strProc += "\nSet @Sql = 'Select * From(Select row_number() over('";
                strProc += "\n--排序部分";
                strProc += "\nif(@StrOrder <> '')";
                strProc += "\nBegin";
                strProc += "\nSet @Sql = @Sql + ' Order By ' + @StrOrder";
                strProc += "\nEnd";
                strProc += "\nelse";
                strProc += "\nBegin";
                strProc += "\nSet @Sql = @Sql + ' Order By Status Desc'";
                strProc += "\nEnd";
                strProc += "\nSet @Sql = @Sql + ') as rowNum,* From '";
                strProc += "\nSet @Sql = @Sql + '(Select Top ' + @EndRowNum";
                strProc += "\n--显示列";
                strProc += "\nif(@StrColumn <> '')";
                strProc += "\nBegin";
                strProc += "\nSet @Sql = @Sql + ' ' + @StrColumn";
                strProc += "\nEnd";
                strProc += "\nelse";
                strProc += "\nBegin";
                strProc += "\nSet @Sql = @Sql + ' *'";
                strProc += "\nEnd";
                strProc += "\n--查询表名";
                strProc += "\nif(@TabName <> '')";
                strProc += "\nBegin";
                strProc += "\nif(CharIndex('dbo.',@TabName) = 0)";
                strProc += "\nBegin";
                strProc += "\nSet @Sql = @Sql + ' From [' + @TabName + '] Where Status <> 99'";
                strProc += "\nEnd";
                strProc += "\nelse";
                strProc += "\nBegin";
                strProc += "\nSet @Sql = @Sql + ' From ' + @TabName + ' Where Status <> 99'";
                strProc += "\nEnd";
                strProc += "\nEnd";
                strProc += "\n--条件部分";
                strProc += "\nif(@StrWhere <> '')";
                strProc += "\nBegin";
                strProc += "\nSet @Sql = @Sql + ' and ' + @StrWhere";
                strProc += "\nEnd";
                strProc += "\n--排序部分";
                strProc += "\nif(@StrOrder <> '')";
                strProc += "\nBegin";
                strProc += "\nSet @Sql = @Sql + ' Order By ' + @StrOrder";
                strProc += "\nEnd";
                strProc += "\nSet @Sql = @Sql + ' ) t'";
                strProc += "\nSet @Sql = @Sql + ' ) tt Where Status <> 99 And rowNum > ' + @StartRowNum";
                strProc += "\n--获取总数量";
                strProc += "\nif(CharIndex('dbo.',@TabName) = 0)";
                strProc += "\nBegin";
                strProc += "\nSet @Sql = @Sql + ' Select Count(*) From [' + @TabName + '] Where Status <> 99'";
                strProc += "\nEnd";
                strProc += "\nelse";
                strProc += "\nBegin";
                strProc += "\nSet @Sql = @Sql + ' Select Count(*) From ' + @TabName + ' Where Status <> 99'";
                strProc += "\nEnd";
                strProc += "\n--条件部分";
                strProc += "\nif(@StrWhere <> '')";
                strProc += "\nBegin";
                strProc += "\nSet @Sql = @Sql + ' and ' + @StrWhere";
                strProc += "\nEnd";
                strProc += "\nprint @Sql";
                strProc += "\nExec (@Sql)";
                strProc += "\nGO";

                txt_TYCode.Text = "<!--根据条件获取数据-->\n<add key=\"GetList\" value=\"@Top,@Table,@Where,@Order\"/>";
                txt_TYCode.Text += "\n<!--分页获取数据-->\n<add key=\"GetPage\" value=\"@CurrPage,@PageSize,@TabName,@StrColumn,@StrWhere,@StrOrder\"/>";
                txt_TYCode.Text += "\n<!--真删-->\n<add key=\"Delete\" value=\"@TblName,@Ids,@AdminId,@AdminName,@IP,@MAC\"/>";
                txt_TYCode.Text += "\n<!--假删-->\n<add key=\"UpdateStatus\" value=\"@Status,@TblName,@Ids,@AdminId,@AdminName,@IP,@MAC\"/>";

                if (!Directory.Exists(comboBox_Database.Text + "/通用方法/"))
                {
                    Directory.CreateDirectory(comboBox_Database.Text + "/通用方法/");
                }
                File.WriteAllText(comboBox_Database.Text + "/通用方法/通用方法.sql", strProc, Encoding.UTF8);
                if (listBox_Table.SelectedIndex != listBox_Table.Items.Count - 1)
                    listBox_Table.SelectedIndex = listBox_Table.SelectedIndex + 1;
                else
                    listBox_Table.SelectedIndex = 0;
                MessageBox.Show("生成成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 生成所有实体
        private void btn_CreateModelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_Table.Items.Count; i++)
            {
                listBox_Table.SelectedIndex = i;

                #region 验证
                if (listBox_Table.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    return;
                }
                string service = comboBox_Service.Text.ToString();
                string database = comboBox_Database.Text.ToString();
                string username = textBox_Username.Text.ToString();
                string password = textBox_Password.Text.ToString();
                if (service == "")
                {
                    MessageBox.Show("请选择服务器！");
                    return;
                }
                if (database == "")
                {
                    MessageBox.Show("请选择数据库！");
                    return;
                }
                if (username == "")
                {
                    MessageBox.Show("用户名不能为空！");
                    return;
                }
                if (password == "")
                {
                    MessageBox.Show("密码不能为空！");
                    return;
                }
                #endregion
                DataSet ds = DataAccess.GetFilers(service, database, username, password, listBox_Table.SelectedValue.ToString(), listBox_Table.Text.ToString());
                string files = "";
                if (DBHelper.IsEmptyDS(ds))
                {
                    txt_tabname.Text = listBox_Table.Text.ToString();
                    txt_ModelName.Text = txt_tabname.Text;
                    if (ds.Tables["tb2"].Rows.Count > 0)
                    {
                        txt_key.Text = ds.Tables["tb2"].Rows[0]["COLUMN_NAME"].ToString();
                        txt_ModelKey.Text = txt_key.Text;
                    }
                    else
                    {
                        MessageBox.Show("当前表无主键！");
                        return;
                    }
                    string _files = "";
                    foreach (DataRow dr in ds.Tables["tb1"].Rows)
                    {
                        _files += "@" + dr["name"].ToString() + ",";
                        if (dr["tyname"].ToString() == "varchar")
                        {
                            files += dr["name"].ToString() + "[" + dr["tyname"] + "(" + dr["length"] + ")]" + "{" + dr["Description"] + "},";
                        }
                        else if (dr["tyname"].ToString() == "nvarchar")
                        {
                            files += dr["name"].ToString() + "[" + dr["tyname"] + "(" + Convert.ToInt32(dr["length"].ToString()) / 2 + ")]" + "{" + dr["Description"] + "},";
                        }
                        else
                        {
                            files += dr["name"].ToString() + "[" + dr["tyname"] + "]" + "{" + dr["Description"] + "},";
                            string sss = ds.Tables["tb2"].Rows[0]["COLUMN_NAME"].ToString();
                        }
                    }
                    textBox4.Text = "<!--" + txt_tabname.Text + "表的Sql操作-->\n<add key=\"USP_" + txt_tabname.Text + "_ADD\" value=\"" + _files.Remove(_files.Length - 1) + ",@AdminId,@AdminName,@IP,@MAC\"/>\n<add key=\"USP_" + txt_tabname.Text + "_Update\" value=\"" + _files.Remove(_files.Length - 1) + ",@AdminId,@AdminName,@IP,@MAC\"/>\n<add key=\"USP_" + txt_tabname.Text + "_GetModel\" value=\"@" + txt_key.Text + "\"/>\n";
                    txt_fields.Text = files.Remove(files.Length - 1);
                }
                string key = txt_key.Text;
                string[] fields = txt_fields.Text.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries);
                if (fields.Length == 0)
                {
                    Lb_field.Text = "字段集不能为空!";
                    return;
                }
                if (!txt_fields.Text.Contains(key))
                {
                    Lb_Key.Text = "此处主键必须与字段处一致!";
                    return;
                }
                CreateModel(txt_tabname.Text, fields);
            }
            MessageBox.Show("生成成功！");
        }
        #endregion

        #region 生成所有存储过程
        private void But_CreateProcAll_Click(object sender, EventArgs e)
        {
            textBox4.Text = string.Empty;
            for (int i = 0; i < listBox_Table.Items.Count; i++)
            {
                listBox_Table.SelectedIndex = i;

                #region 验证
                if (listBox_Table.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    return;
                }
                string service = comboBox_Service.Text.ToString();
                string database = comboBox_Database.Text.ToString();
                string username = textBox_Username.Text.ToString();
                string password = textBox_Password.Text.ToString();
                if (service == "")
                {
                    MessageBox.Show("请选择服务器！");
                    return;
                }
                if (database == "")
                {
                    MessageBox.Show("请选择数据库！");
                    return;
                }
                if (username == "")
                {
                    MessageBox.Show("用户名不能为空！");
                    return;
                }
                if (password == "")
                {
                    MessageBox.Show("密码不能为空！");
                    return;
                }
                #endregion
                DataSet ds = DataAccess.GetFilers(service, database, username, password, listBox_Table.SelectedValue.ToString(), listBox_Table.Text.ToString());
                string files = "";
                if (DBHelper.IsEmptyDS(ds))
                {
                    txt_tabname.Text = listBox_Table.Text.ToString();
                    txt_ModelName.Text = txt_tabname.Text;
                    if (ds.Tables["tb2"].Rows.Count > 0)
                    {
                        txt_key.Text = ds.Tables["tb2"].Rows[0]["COLUMN_NAME"].ToString();
                        txt_ModelKey.Text = txt_key.Text;
                    }
                    else
                    {
                        MessageBox.Show("当前表无主键！");
                        return;
                    }
                    string _files = "";
                    foreach (DataRow dr in ds.Tables["tb1"].Rows)
                    {
                        _files += "@" + dr["name"].ToString() + ",";
                        if (dr["tyname"].ToString() == "varchar")
                        {
                            files += dr["name"].ToString() + "[" + dr["tyname"] + "(" + dr["length"] + ")]" + "{" + dr["Description"] + "},";
                        }
                        else if (dr["tyname"].ToString() == "nvarchar")
                        {
                            files += dr["name"].ToString() + "[" + dr["tyname"] + "(" + Convert.ToInt32(dr["length"].ToString()) / 2 + ")]" + "{" + dr["Description"] + "},";
                        }
                        else
                        {
                            files += dr["name"].ToString() + "[" + dr["tyname"] + "]" + "{" + dr["Description"] + "},";
                            string sss = ds.Tables["tb2"].Rows[0]["COLUMN_NAME"].ToString();
                        }
                    }
                    textBox4.Text = "<!--" + txt_tabname.Text + "表的Sql操作-->\n<add key=\"USP_" + txt_tabname.Text + "_ADD\" value=\"" + _files.Remove(_files.Length - 1) + ",@AdminId,@AdminName,@IP,@MAC\"/>\n<add key=\"USP_" + txt_tabname.Text + "_Update\" value=\"" + _files.Remove(_files.Length - 1) + ",@AdminId,@AdminName,@IP,@MAC\"/>\n<add key=\"USP_" + txt_tabname.Text + "_GetModel\" value=\"@" + txt_key.Text + "\"/>\n";
                    txt_fields.Text = files.Remove(files.Length - 1);
                }
                string key = txt_key.Text;
                string[] fields = txt_fields.Text.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries);
                if (fields.Length == 0)
                {
                    Lb_field.Text = "字段集不能为空!";
                    return;
                }
                if (!txt_fields.Text.Contains(key))
                {
                    Lb_Key.Text = "此处主键必须与字段处一致!";
                    return;
                }
                CreateSqlCode(txt_tabname.Text, key, fields);
            }
            textBox4.Text = webConfigCode;
            MessageBox.Show("生成成功！");
        }
        #endregion

        #region 生成通用类
        private void btn_CreateTyModel_Click(object sender, EventArgs e)
        {
            string[] fields = { "CurrPage[int]{当前页页码}", "PageSize[int]{分页大小}", "TabName[nvarchar(50)]{需要查看的表名}", "StrColumn[nvarchar(1000)]{需要的字段}", "StrWhere[nvarchar(1000)]{查询条件}", "StrOrder[nvarchar(1000)]{查询排序}" };
            txt_tabname.Text = "GetPage";
            CreateModel(txt_tabname.Text, fields);
            string[] fields2 = { "Top[nvarchar(10)]{显示多少条}", "Table[nvarchar(200)]{表名}", "Where[nvarchar(1400)]{条件}", "PkColumn[nvarchar(20)]{主键名称}", "Order[nvarchar(100)]{排序}" };
            txt_tabname.Text = "GetList";
            CreateModel(txt_tabname.Text, fields2);
            MessageBox.Show("生成成功！");
        }
        #endregion

        private void txt_TYCode_Click(object sender, EventArgs e)
        {
            this.txt_TYCode.SelectAll();
            txt_TYCode.Copy();
        }

        private void Btn_CreateFunction_Click(object sender, EventArgs e)
        {
            try
            {
                string strProc = "use " + comboBox_Database.Text;
                strProc += "\nGo";
                //生成权限相关表          生成管理员和角色相关表
                strProc += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdminAndRole]') AND type in (N'U'))";
                strProc += "\nDROP TABLE [dbo].[AdminAndRole]";
                strProc += "\nGO";
                strProc += "\n/****** 管理员与角色关联表 ******/";
                strProc += "\nSET ANSI_NULLS ON";
                strProc += "\nGO";
                strProc += "\nSET QUOTED_IDENTIFIER ON";
                strProc += "\nGO";
                strProc += "\nCREATE TABLE [dbo].[AdminAndRole](";
                strProc += "\n[ID] [int] IDENTITY(1,1) NOT NULL,";
                strProc += "\n[Admin_ID] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_UserAndRole_Title]  DEFAULT ((0)),";
                strProc += "\n[Role_ID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_UserAndRole_Role_ID]  DEFAULT ((0)),";
                strProc += "\n[Status] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_UserAndRole_Status]  DEFAULT ((0)),";
                strProc += "\n[CreateDate] [datetime] NULL CONSTRAINT [DF_UserAndRole_CreateDate]  DEFAULT (getdate()),";
                strProc += "\n CONSTRAINT [PK_UserAndRole] PRIMARY KEY CLUSTERED ";
                strProc += "\n(";
                strProc += "\n	[ID] ASC";
                strProc += "\n)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]";
                strProc += "\n) ON [PRIMARY]";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户角色ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'AdminAndRole', @level2type=N'COLUMN', @level2name=N'ID'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'AdminAndRole', @level2type=N'COLUMN', @level2name=N'Admin_ID'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'AdminAndRole', @level2type=N'COLUMN', @level2name=N'Role_ID'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态(99为删除)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'AdminAndRole', @level2type=N'COLUMN', @level2name=N'Status'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'AdminAndRole', @level2type=N'COLUMN', @level2name=N'CreateDate'";
                strProc += "\nGo";
                strProc += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))";
                strProc += "\nDROP TABLE [dbo].[Role]";
                strProc += "\n/****** 角色表 ******/";
                strProc += "\nSET ANSI_NULLS ON";
                strProc += "\nGO";
                strProc += "\nSET QUOTED_IDENTIFIER ON";
                strProc += "\nGO";
                strProc += "\nCREATE TABLE [dbo].[Role](";
                strProc += "\n	[ID] [int] IDENTITY(1,1) NOT NULL,";
                strProc += "\n	[Title] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_Role_Title]  DEFAULT (''),";
                strProc += "\n	[Status] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_Role_Status]  DEFAULT ((0)),";
                strProc += "\n	[CreateDate] [datetime] NULL CONSTRAINT [DF_Role_CreateDate]  DEFAULT (getdate()),";
                strProc += "\n CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ";
                strProc += "\n(";
                strProc += "\n	[ID] ASC";
                strProc += "\n)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]";
                strProc += "\n) ON [PRIMARY]";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Role', @level2type=N'COLUMN', @level2name=N'ID'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Role', @level2type=N'COLUMN', @level2name=N'Title'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态(99为删除)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Role', @level2type=N'COLUMN', @level2name=N'Status'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Role', @level2type=N'COLUMN', @level2name=N'CreateDate'";
                strProc += "\nGo";
                strProc += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleAndFunction]') AND type in (N'U'))";
                strProc += "\nDROP TABLE [dbo].[RoleAndFunction]";
                strProc += "\nGO";
                strProc += "\n/****** 角色与权限关联表 ******/";
                strProc += "\nSET ANSI_NULLS ON";
                strProc += "\nGO";
                strProc += "\nSET QUOTED_IDENTIFIER ON";
                strProc += "\nGO";
                strProc += "\nCREATE TABLE [dbo].[RoleAndFunction](";
                strProc += "\n	[ID] [int] IDENTITY(1,1) NOT NULL,";
                strProc += "\n	[Role_ID] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_RoleAndFunction_Role_ID]  DEFAULT ((0)),";
                strProc += "\n	[Function_ID] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_RoleAndFunction_Function_ID]  DEFAULT ((0)),";
                strProc += "\n	[Status] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_RoleAndFunction_Status]  DEFAULT ((0)),";
                strProc += "\n	[CreateDate] [datetime] NULL CONSTRAINT [DF_RoleAndFunction_CreateDate]  DEFAULT (getdate()),";
                strProc += "\n CONSTRAINT [PK_RoleAndFunction] PRIMARY KEY CLUSTERED ";
                strProc += "\n(";
                strProc += "\n	[ID] ASC";
                strProc += "\n)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]";
                strProc += "\n) ON [PRIMARY]";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色权限ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RoleAndFunction', @level2type=N'COLUMN', @level2name=N'ID'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RoleAndFunction', @level2type=N'COLUMN', @level2name=N'Role_ID'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RoleAndFunction', @level2type=N'COLUMN', @level2name=N'Function_ID'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态(99为删除)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RoleAndFunction', @level2type=N'COLUMN', @level2name=N'Status'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'RoleAndFunction', @level2type=N'COLUMN', @level2name=N'CreateDate'";
                strProc += "\nGO";
                strProc += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Function]') AND type in (N'U'))";
                strProc += "\nDROP TABLE [dbo].[Function]";
                strProc += "\nGO";
                strProc += "\n/****** 权限表 ******/";
                strProc += "\nSET ANSI_NULLS ON";
                strProc += "\nGO";
                strProc += "\nSET QUOTED_IDENTIFIER ON";
                strProc += "\nGO";
                strProc += "\nCREATE TABLE [dbo].[Function](";
                strProc += "\n	[ID] [int] IDENTITY(1,1) NOT NULL,";
                strProc += "\n	[ParentId] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_Function_ParentId]  DEFAULT ((0)),";
                strProc += "\n	[Title] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_Function_Title]  DEFAULT (''),";
                strProc += "\n	[Url] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_Function_Url]  DEFAULT (''),";
                strProc += "\n	[Status] [nvarchar](10) COLLATE Chinese_PRC_CI_AS NULL CONSTRAINT [DF_Function_Status]  DEFAULT ((0)),";
                strProc += "\n	[CreateDate] [datetime] NULL CONSTRAINT [DF_Function_CreateDate]  DEFAULT (getdate()),";
                strProc += "\n CONSTRAINT [PK_Function] PRIMARY KEY CLUSTERED ";
                strProc += "\n(";
                strProc += "\n	[ID] ASC";
                strProc += "\n)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]";
                strProc += "\n) ON [PRIMARY]";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Function', @level2type=N'COLUMN', @level2name=N'ID'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父类ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Function', @level2type=N'COLUMN', @level2name=N'ParentId'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Function', @level2type=N'COLUMN', @level2name=N'Title'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限操作页面路径' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Function', @level2type=N'COLUMN', @level2name=N'Url'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态(99为删除)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Function', @level2type=N'COLUMN', @level2name=N'Status'";
                strProc += "\nGO";
                strProc += "\nEXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'Function', @level2type=N'COLUMN', @level2name=N'CreateDate'";
                strProc += "\n";
                //创建查询权限函数（显示方式为父类下面跟着子类）{Parentid = 0 的话只支持2及分类}
                strProc += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[myFun]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))";
                strProc += "\nDROP FUNCTION [dbo].[myFun]";
                strProc += "\nGo";
                strProc += "\nCreate Function [dbo].[myFun]()";
                strProc += "\nReturns @myTbl table";
                strProc += "\n--指定的表结构@myTbl";
                strProc += "\n(";
                strProc += "\nId int,";
                strProc += "\nParentId nvarchar(10),";
                strProc += "\nTitle nvarchar(500),";
                strProc += "\nUrl nvarchar(500),";
                strProc += "\nStatus nvarchar(10),";
                strProc += "\nStartTime datetime";
                strProc += "\n)";
                strProc += "\nAs";
                strProc += "\n    begin";
                strProc += "\n		Declare @Id int";
                strProc += "\n		--声明游标";
                strProc += "\n		Declare cursor_ele Cursor for";
                strProc += "\n			(Select id From [Function] Where ParentId = 0)";
                strProc += "\n		open cursor_ele";
                strProc += "\n		while(0=0)";
                strProc += "\n		begin";
                strProc += "\n			fetch next from cursor_ele into @Id";
                strProc += "\n			if(@@fetch_status <> 0)break";
                strProc += "\n			--查询语句";
                strProc += "\n			insert into @myTbl";
                strProc += "\n				Select * From [Function] Where Id = @Id or ParentID = @Id";
                strProc += "\n		end";
                strProc += "\n		close cursor_Ele";
                strProc += "\n		deallocate cursor_ele";
                strProc += "\n       return";
                strProc += "\n    end";
                strProc += "\nGo";
                //根据管理员ID获取角色
                strProc += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_Admin_ByIdGetRole]') AND type in (N'P', N'PC'))";
                strProc += "\nDROP PROCEDURE [dbo].[USP_Admin_ByIdGetRole]";
                strProc += "\nGo";
                strProc += "\nCreate Proc [dbo].[USP_Admin_ByIdGetRole]";
                strProc += "\n@ID int";
                strProc += "\nAs";
                strProc += "\n	Select * From [Role] Where ID in (Select Role_ID From AdminAndRole Where Admin_ID = @ID)";
                strProc += "\nGo";
                //获取管理员单独的权限
                strProc += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_Admin_GetAdminFunction]') AND type in (N'P', N'PC'))";
                strProc += "\nDROP PROCEDURE [dbo].[USP_Admin_GetAdminFunction]";
                strProc += "\nGo";
                strProc += "\nCREATE proc [dbo].[USP_Admin_GetAdminFunction]";
                strProc += "\n@ID int,";
                strProc += "\n@Functions nvarchar(4000)";
                strProc += "\nAs";
                strProc += "\n	Declare @Sql nvarchar(max)";
                strProc += "\n	Set @Sql = 'Select * From Admin Where ID = ' + cast(@ID as nvarchar(10)) + ' and '";
                strProc += "\n	Declare @Index int";
                strProc += "\n	Declare @lab int";
                strProc += "\n	Set @lab = 1";
                strProc += "\n	set @Index = Charindex(',',@Functions)";
                strProc += "\n	while(@Index > 1)";
                strProc += "\n	 Begin";
                strProc += "\n		Declare @Ids nvarchar(100)";
                strProc += "\n		Set @Ids = substring(@Functions,1,@Index -1)";
                strProc += "\n		Set @Functions = substring(@Functions,@Index + 1,len(@Functions))";
                strProc += "\n		if(@lab = 1)";
                strProc += "\n		 Begin";
                strProc += "\n			Set @Sql = @Sql + ' (Functions Like ''' + @Ids + ',%'' or Functions Like ''%,' + @Ids + ''''  + 'or Functions Like ''' + @Ids + ''')'";
                strProc += "\n		 End";
                strProc += "\n		else";
                strProc += "\n		 Begin";
                strProc += "\n			Set @Sql = @Sql + ' (or Functions Like ''' + @Ids + ',%'' or Functions Like ''%,' + @Ids + ''''  + 'or Functions Like ''' + @Ids + ''')'";
                strProc += "\n		 End";
                strProc += "\n		set @Index = Charindex(',',@Functions)";
                strProc += "\n		if(@Index = 0)";
                strProc += "\n		 Begin";
                strProc += "\n			Set @Ids = @Functions			";
                strProc += "\n			Set @Sql = @Sql + ' (or  Functions Like ''' + @Ids + ',%'' or Functions Like ''%,' + @Ids + ''''  + 'or Functions Like ''' + @Ids + ''')'";
                strProc += "\n		 End";
                strProc += "\n		Set @lab = 2";
                strProc += "\n	 End";
                strProc += "\n	if(@lab = 1)";
                strProc += "\n	 Begin";
                strProc += "\n		Set @Ids = @Functions";
                strProc += "\n		Set @Sql = @Sql + ' (Functions Like ''' + @Ids + ',%'' or Functions Like ''%,' + @Ids + '''' + 'or Functions Like ''' + @Ids + ''')'";
                strProc += "\n	 End";
                strProc += "\n	print @Sql";
                strProc += "\n	Exec (@Sql)";
                strProc += "\nGo";
                //根据管理员ID获取权限
                strProc += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_Admin_ByIdGetFunction]') AND type in (N'P', N'PC'))";
                strProc += "\nDROP PROCEDURE [dbo].[USP_Admin_ByIdGetFunction]";
                strProc += "\nGo";
                strProc += "\nCREATE Proc [dbo].[USP_Admin_ByIdGetFunction]";
                strProc += "\n@ID int,";
                strProc += "\n@Functions nvarchar(4000)";
                strProc += "\nAs";
                strProc += "\n	Select * From [function] Where Url = @Functions and ID in (";
                strProc += "\n	Select Function_ID From RoleAndFunction Where Role_ID in (";
                strProc += "\n		Select Role_ID From AdminAndRole Where Admin_ID = @ID";
                strProc += "\n		)";
                strProc += "\n	)";
                strProc += "\n	Exec USP_Admin_GetAdminFunction @ID,@Functions";
                strProc += "\nGo";
                //根绝管理员ID删除角色
                strProc += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_AdminAndRole_ByAdmin_IDDelRole]') AND type in (N'P', N'PC'))";
                strProc += "\nDROP PROCEDURE [dbo].[USP_AdminAndRole_ByAdmin_IDDelRole]";
                strProc += "\nGo";
                strProc += "\nCreate Proc [dbo].[USP_AdminAndRole_ByAdmin_IDDelRole]";
                strProc += "\n@Admin_ID int";
                strProc += "\nAs";
                strProc += "\n	Delete AdminAndRole Where Admin_ID = @Admin_ID";
                strProc += "\nGo";
                //根绝角色删除权限
                strProc += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_RoleAndFunction_ByRole_IDDelFunction]') AND type in (N'P', N'PC'))";
                strProc += "\nDROP PROCEDURE [dbo].[USP_RoleAndFunction_ByRole_IDDelFunction]";
                strProc += "\nGo";
                strProc += "\nCreate Proc [dbo].[USP_RoleAndFunction_ByRole_IDDelFunction]";
                strProc += "\n@Role_ID int";
                strProc += "\nAs";
                strProc += "\n	Delete RoleAndFunction Where Role_ID = @Role_ID";
                strProc += "\nGo";
                strProc += "\n";
                //根据角色ID删除与管理员的关联
                strProc += "\nIF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_AdminAndRole_ByRole_IDDel]') AND type in (N'P', N'PC'))";
                strProc += "\nDROP PROCEDURE [dbo].[USP_AdminAndRole_ByRole_IDDel]";
                strProc += "\nGo";
                strProc += "\nCreate Proc [dbo].[USP_AdminAndRole_ByRole_IDDel]";
                strProc += "\n@Role_ID int";
                strProc += "\nAs";
                strProc += "\n	Delete AdminAndRole Where Role_ID = @Role_ID";
                strProc += "\nGo";
                strProc += "\n";

                Txt_Function.Text = "<!--根据管理员ID获取角色-->\n<add key=\"USP_Admin_ByIdGetRole\" value=\"@ID\"/>";
                Txt_Function.Text += "\n<!--获取管理员单独的权限-->\n<add key=\"USP_Admin_GetAdminFunction\" value=\"@ID,@Functions\"/>";
                Txt_Function.Text += "\n<!--根据管理员ID获取指定权限-->\n<add key=\"USP_Admin_ByIdGetFunction\" value=\"@ID,@Functions\"/>";
                Txt_Function.Text += "\n<!--根绝管理员ID删除角色-->\n<add key=\"USP_AdminAndRole_ByAdmin_IDDelRole\" value=\"@Admin_ID\"/>";
                Txt_Function.Text += "\n<!--根绝角色删除权限-->\n<add key=\"USP_RoleAndFunction_ByRole_IDDelFunction\" value=\"@Role_ID\"/>";
                Txt_Function.Text += "\n<!--根据角色ID删除与管理员的关联-->\n<add key=\"USP_AdminAndRole_ByRole_IDDel\" value=\"@Role_ID\"/>";

                if (!Directory.Exists(comboBox_Database.Text + "/权限相关/"))
                {
                    Directory.CreateDirectory(comboBox_Database.Text + "/权限相关/");
                }
                File.WriteAllText(comboBox_Database.Text + "/权限相关/权限相关表.sql", strProc, Encoding.UTF8);
                if (listBox_Table.SelectedIndex != listBox_Table.Items.Count - 1)
                    listBox_Table.SelectedIndex = listBox_Table.SelectedIndex + 1;
                else
                    listBox_Table.SelectedIndex = 0;
                MessageBox.Show("生成成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
