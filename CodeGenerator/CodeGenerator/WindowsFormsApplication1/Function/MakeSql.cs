using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using autocoder.Function;

namespace WindowsFormsApplication1.Function
{
    public class MakeSql
    {
        StringBuilder sbContent = new StringBuilder();

        #region 查询
        private bool isSelect;
        /// <summary>
        /// 查询
        /// </summary>
        public bool IsSetlect
        {
            get { return this.isSelect; }
            set { this.isSelect = value; }
        }
        #endregion

        #region 更新
        private bool isUpdate;
        /// <summary>
        /// 更新
        /// </summary>
        public bool IsUpdate
        {
            get { return this.isUpdate; }
            set { this.isUpdate = value; }
        }
        #endregion

        #region 增加
        private bool isInsert;
        /// <summary>
        /// 增加
        /// </summary>
        public bool IsInsert
        {
            get { return this.isInsert; }
            set { this.isInsert = value; }
        }
        #endregion

        #region 删除
        private bool isDelete;
        /// <summary>
        /// 删除
        /// </summary>
        public bool IsDelete
        {
            get { return this.isDelete; }
            set { this.isDelete = value; }
        }
        #endregion

        #region 获取指定表集合
        private bool isGetModelList;
        /// <summary>
        /// 获取指定表集合
        /// </summary>
        public bool IsGetModelList
        {
            get { return this.isGetModelList; }
            set { this.isGetModelList = value; }
        }
        #endregion

        #region IsGetList
        private bool isGetList;
        /// <summary>
        /// GetList
        /// </summary>
        public bool IsGetList
        {
            get { return this.isGetList; }
            set { this.isGetList = value; }
        }
        #endregion

        #region IsGenerDel
        private bool isGenerDel;
        /// <summary>
        /// IsGenerDel
        /// </summary>
        public bool IsGenerDel
        {
            get { return this.isGenerDel; }
            set { this.isGenerDel = value; }
        }
        #endregion

        #region IsGenerUpdate
        private bool isGenerUpdate;
        /// <summary>
        /// IsGenerUpdate
        /// </summary>
        public bool IsGenerUpdate
        {
            get { return this.isGenerUpdate; }
            set { this.isGenerUpdate = value; }
        }
        #endregion

        #region IsGenerGetPage
        private bool isGenerGetPage;
        /// <summary>
        /// IsGenerGetPage
        /// </summary>
        public bool IsGenerGetPage
        {
            get { return this.isGenerGetPage; }
            set { this.isGenerGetPage = value; }
        }
        #endregion

        private string uspFieldName;
        public string UspFieldName
        {
            get { return this.uspFieldName; }
            set { this.uspFieldName = value; }
        }
        #region 数据库名称
        private string dbName;
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DBName
        {
            get { return this.dbName; }
            set { this.dbName = value; }
        }
        #endregion

        #region 表名
        private string tableName;
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get { return this.tableName; }
            set { this.tableName = value; }
        }
        #endregion

        private string fileName;//文件名

        private string titleName;//标题

        private DataSet dsTableDetails;//表字段详细信息

        #region 连接字符串
        private string conn;
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string CONN
        {
            get { return conn; }
            set { this.conn = value; }
        }
        #endregion

        #region 表中文名中文
        private string tbname;
        /// <summary>
        /// 表中文名中文
        /// </summary>
        public string TbName
        {
            get { return this.tbname; }
            set { this.tbname = value; }
        }
        #endregion

        #region 记录标题
        private string tbtitle;
        /// <summary>
        /// 记录标题
        /// </summary>
        public string TbTitle
        {
            get { return this.tbtitle; }
            set { this.tbtitle = value; }
        }
        #endregion

        #region 记录字段
        private string tbtitlefield;
        /// <summary>
        /// 记录字段
        /// </summary>
        public string TbTitleField
        {
            get { return this.tbtitlefield; }
            set { this.tbtitlefield = value; }
        }
        #endregion

        #region 生成所有存储过程
        public void makeFile(string CON)
        {
            this.CONN = CON;
            dsTableDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, string.Format(Common.GetTableDetails, dbName, tableName));
            if (isSelect)
            {
                makeSelectFile();
            }
            if (isInsert)
            {
                sbContent = new StringBuilder();
                makeInsertFile();
            }
            if (isUpdate)
            {
                sbContent = new StringBuilder();
                makeUpdateFile();
            }
            if (isDelete)
            {
                sbContent = new StringBuilder();
                makeDeleteFile();
            }
            if (isGetModelList)
            {
                sbContent = new StringBuilder();
                makeGetModeListFile();
            }
        }

        public void makeGeneralFile(string CON)
        {
            this.CONN = CON;
            dsTableDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, string.Format(Common.GetTableDetails, dbName, tableName));
            if (isGetList)
            {
                sbContent = new StringBuilder();
                makeGetList();
            }
            if (isGenerDel)
            {
                sbContent = new StringBuilder();
                makeGenerDel();
            }
            if (isGenerUpdate)
            {
                sbContent = new StringBuilder();
                makeGenerUpdate();
            }
            if (isGenerGetPage)
            {
                sbContent = new StringBuilder();
                makeGenerGetPage();
            }
        }
        #endregion

        #region 生成GetModel
        private void makeSelectFile()
        {
            sbContent = new StringBuilder();
            this.fileName = "usp_" + tableName + "_GetModel";
            this.titleName = "GetModel";
            sbContent.Append(this.getHeader(titleName));
            sbContent.Append("CREATE PROCEDURE " + fileName + " \r\n");
            sbContent.Append(this.getInPutField("IsPrimary = '1'"));
            sbContent.Append("\r\n) \r\nAS \r\n");
            sbContent.Append("SELECT * \r\n");
            sbContent.Append("FROM " + tableName + " \r\n");
            sbContent.Append(this.getWhereField("IsPrimary = '1'", "Select"));
            this.generateUspCode(fileName, sbContent.ToString());
        }
        #endregion

        #region 生成新增
        private void makeInsertFile()
        {
            sbContent = new StringBuilder();
            this.titleName = "Insert a record";
            this.fileName = "usp_" + tableName + "_Add";
            sbContent.Append(this.getHeader(titleName));
            sbContent.Append("CREATE PROCEDURE " + fileName + " \r\n");
            sbContent.Append(this.getInPutField("IsIdentity='0'"));
            sbContent.Append("\r\n)AS \r\n");
            sbContent.Append("Declare @strSql nvarchar(500)\r\n");
            sbContent.Append("Set @strSql = 'INSERT INTO " + tableName + "'\r\n");
            sbContent.Append(this.getEditCode("IsIdentity='0'", "Insert"));
            sbContent.Append(this.getExecuteField("IsIdentity='0'","Insert"));
            this.generateUspCode(fileName, sbContent.ToString());
        }
        #endregion

        #region 生成更新
        private void makeUpdateFile()
        {
            sbContent = new StringBuilder();
            this.fileName = "usp_" + tableName + "_Update";
            this.titleName = "Updata a record";
            sbContent.Append(this.getHeader(titleName));
            sbContent.Append("CREATE PROCEDURE " + fileName + " \r\n");
            sbContent.Append(this.getInPutField(""));
            sbContent.Append("\r\n) AS \r\n");
            sbContent.Append("Declare @strSql nvarchar(500)\r\n");
            sbContent.Append("Set @strSql = 'UPDATE " + tableName + " Set '\r\n");
            sbContent.Append(this.getEditCode("IsIdentity='0'", "Update"));
            sbContent.Append(this.getWhereField("IsIdentity='1'", "Update"));
            sbContent.Append(this.getExecuteField("",""));
            this.generateUspCode(fileName, sbContent.ToString());
        }
        #endregion

        #region 生成GetModeList
        private void makeGetModeListFile()
        {
            sbContent = new StringBuilder();
            this.fileName = "usp_" + tableName + "_GetList";
            this.titleName = "GetModeList";
            sbContent.Append(this.getHeader(titleName));
            sbContent.Append("CREATE PROCEDURE " + fileName + " \r\n");
            sbContent.Append(this.getInPutField(""));
            sbContent.Append("\r\n) AS \r\n");
            sbContent.Append("Declare @strSql nvarchar(500)\r\n");
            sbContent.Append("Set @strSql = 'Select * From " + tableName + " '\r\n");
            sbContent.Append(this.getWhereField("", "GetModelList"));
            sbContent.Append(this.getExecuteField("", ""));
            this.generateUspCode(fileName, sbContent.ToString());
        }
        #endregion

        #region 生成删除
        private void makeDeleteFile()
        {
            sbContent = new StringBuilder();
            this.fileName = "usp_" + tableName + "_Delete";
            this.titleName = "Delete a record";
            sbContent.Append(this.getHeader(titleName));
            sbContent.Append("CREATE PROCEDURE " + fileName + " \r\n");
            sbContent.Append(this.getInPutField("IsIdentity='1'"));
            sbContent.Append("\r\n) AS \r\n");
            sbContent.Append("Update " + tableName + " Set Status=99 \r\n");
            sbContent.Append(this.getWhereField("IsIdentity='1'", "Delete"));
            this.generateUspCode(fileName, sbContent.ToString());
        }
        #endregion

        #region 生成GetList
        private void makeGetList()
        {
            sbContent = new StringBuilder();
            this.fileName = "usp_General_GetList";
            this.titleName = "根据条件获取数据";
            sbContent.Append(this.getHeader(titleName));
            sbContent.Append("CREATE PROCEDURE " + fileName + " \r");
            sbContent.Append("\n@Top int=null,");
            sbContent.Append("\n@Files nvarchar(500)=null,");
            sbContent.Append("\n@Table nvarchar(200)=null,");
            sbContent.Append("\n@Where nvarchar(1400)=null,");
            sbContent.Append("\n@Order nvarchar(100)=null");
            sbContent.Append("\nAS");
            sbContent.Append("\nBEGIN");
            sbContent.Append("\n\tdeclare @strSql nvarchar(1100)");
            sbContent.Append("\n\tset @strSql = 'select '");
            sbContent.Append("\n\tif(ISNULL(@top,'')<>'')");
            sbContent.Append("\n\t\tset @strSql = @strSql + ' top '+cast(@top as nvarchar(50));");
            sbContent.Append("\n\tif(ISNULL(@order,'')<>'')");
            sbContent.Append("\n\t\tset @strSql = @strSql + ' Row_Number() over(Order By '+@order+') as RowId,';");
            sbContent.Append("\n\telse");
            sbContent.Append("\n\t\tset @strSql = @strSql + ' Row_Number() over(Order By ID Desc) as RowId,';");
            sbContent.Append("\n\tif(ISNULL(@Files,'')<>'')");
            sbContent.Append("\n\t\tset @strSql = @strSql +' '+@Files+' from '+ @table;");
            sbContent.Append("\n\telse");
            sbContent.Append("\n\t\tset @strSql = @strSql + ' * from '+@table;");
            sbContent.Append("\n\tif(ISNULL(@where,'')<>'')");
            sbContent.Append("\n\t\tset @strSql = @strSql + ' where '+@where;");
            sbContent.Append("\n\texec (@strSql);");
            sbContent.Append("\n\t");
            sbContent.Append("\nEND");
            this.generateUspCode(fileName, sbContent.ToString());
        }
        #endregion

        #region 生成GenerDel
        private void makeGenerDel()
        {
            sbContent = new StringBuilder();
            this.fileName = "usp_General_Delete";
            this.titleName = "根据条件获删除数据";
            sbContent.Append(this.getHeader(titleName));
            sbContent.Append("CREATE PROCEDURE " + fileName + " \r");
            sbContent.Append("\n@Table varchar(50)=null,");
            sbContent.Append("\n@Where varchar(3000)=null,");
            sbContent.Append("\n@Fake int = 0");
            sbContent.Append("\nAS");
            sbContent.Append("\nBEGIN");
            sbContent.Append("\n\tdeclare @strSql nvarchar(1100)");
            sbContent.Append("\n\tif(@Fake=0)");
            sbContent.Append("\n\t\tset @strSql = 'UPDATE '+@Table+' SET Status = 99 WHERE '+@Where;");
            sbContent.Append("\n\telse if(@Fake=1)");
            sbContent.Append("\n\t\tset @strSql = 'DELETE  FROM '+@Table+' WHERE '+@Where;");
            sbContent.Append("\n\texec (@strSql);");
            sbContent.Append("\nEND");
            this.generateUspCode(fileName, sbContent.ToString());
        }
        #endregion

        #region 生成GenerUpdate
        private void makeGenerUpdate()
        {
            sbContent = new StringBuilder();
            this.fileName = "usp_General_Update";
            this.titleName = "根据条件获更新数据";
            sbContent.Append(this.getHeader(titleName));
            sbContent.Append("CREATE PROCEDURE " + fileName + " \r");
            sbContent.Append("\n@Table varchar(50)=null,");
            sbContent.Append("\n@Files varchar(3000)=null,");
            sbContent.Append("\n@Where varchar(3000)=null");
            sbContent.Append("\nAS");
            sbContent.Append("\nBEGIN");
            sbContent.Append("\n\tdeclare @strSql nvarchar(2000)");
            sbContent.Append("\n\tset @strSql = 'UPDATE '+@Table+' SET '+@Files+' WHERE '+@Where;");
            sbContent.Append("\n\texec (@strSql);");
            sbContent.Append("\nEND");
            this.generateUspCode(fileName, sbContent.ToString());
        }
        #endregion

        #region 生成GenerGetPage
        private void makeGenerGetPage()
        {
            sbContent = new StringBuilder();
            this.fileName = "usp_General_GetPage";
            this.titleName = "分页获取数据";
            sbContent.Append(this.getHeader(titleName));
            sbContent.Append("\nCreate PROCEDURE " + fileName);
            sbContent.Append("\n(");
            sbContent.Append("\n@CurrPage int = 1,                       --当前页页码 (即Top currPage) ");
            sbContent.Append("\n@PageSize int = 10,                       --分页大小 ");
            sbContent.Append("\n@TabName varchar(50),                     --需要查看的表名 (即 from table_name) ");
            sbContent.Append("\n@StrColumn varchar(1000) = null,         --需要得到的字段 (即 column1,column2,......)");
            sbContent.Append("\n@StrWhere nvarchar(1000) = null,         --查询条件 (即 where condition......) 不用加where关键字 ");
            sbContent.Append("\n@StrOrder varchar(100) = null        --排序的字段名 (即 order by column asc/desc)");
            sbContent.Append("\n)");
            sbContent.Append("\nAS ");
            sbContent.Append("\nDeclare @Sql nvarchar(max) --定义Sql语句");
            sbContent.Append("\nDeclare @StartRowNum nvarchar(100),@EndRowNum nvarchar(100)");
            sbContent.Append("\nSet @StartRowNum = cast((@CurrPage - 1) * @PageSize as nvarchar(10)) --开始RowNumber");
            sbContent.Append("\nSet @EndRowNum = cast(@CurrPage * @PageSize as nvarchar(10))			 --结束RowNumber");
            sbContent.Append("\nSet @Sql = 'Select * From(Select row_number() over('");
            sbContent.Append("\n--排序部分");
            sbContent.Append("\nif(@StrOrder <> '')");
            sbContent.Append("\nBegin");
            sbContent.Append("\nSet @Sql = @Sql + ' Order By ' + @StrOrder");
            sbContent.Append("\nEnd");
            sbContent.Append("\nelse");
            sbContent.Append("\nBegin");
            sbContent.Append("\nSet @Sql = @Sql + ' Order By Status Desc'");
            sbContent.Append("\nEnd");
            sbContent.Append("\nSet @Sql = @Sql + ') as rowNum,* From '");
            sbContent.Append("\nSet @Sql = @Sql + '(Select Top ' + @EndRowNum");
            sbContent.Append("\n--显示列");
            sbContent.Append("\nif(@StrColumn <> '')");
            sbContent.Append("\nBegin");
            sbContent.Append("\nSet @Sql = @Sql + ' ' + @StrColumn");
            sbContent.Append("\nEnd");
            sbContent.Append("\nelse");
            sbContent.Append("\nBegin");
            sbContent.Append("\nSet @Sql = @Sql + ' *'");
            sbContent.Append("\nEnd");
            sbContent.Append("\n--查询表名");
            sbContent.Append("\nif(@TabName <> '')");
            sbContent.Append("\nBegin");
            sbContent.Append("\nif(CharIndex('dbo.',@TabName) = 0)");
            sbContent.Append("\nBegin");
            sbContent.Append("\nSet @Sql = @Sql + ' From [' + @TabName + '] Where Status <> 99'");
            sbContent.Append("\nEnd");
            sbContent.Append("\nelse");
            sbContent.Append("\nBegin");
            sbContent.Append("\nSet @Sql = @Sql + ' From ' + @TabName + ' Where Status <> 99'");
            sbContent.Append("\nEnd");
            sbContent.Append("\nEnd");
            sbContent.Append("\n--条件部分");
            sbContent.Append("\nif(@StrWhere <> '')");
            sbContent.Append("\nBegin");
            sbContent.Append("\nSet @Sql = @Sql + ' and ' + @StrWhere");
            sbContent.Append("\nEnd");
            sbContent.Append("\n--排序部分");
            sbContent.Append("\nif(@StrOrder <> '')");
            sbContent.Append("\nBegin");
            sbContent.Append("\nSet @Sql = @Sql + ' Order By ' + @StrOrder");
            sbContent.Append("\nEnd");
            sbContent.Append("\nSet @Sql = @Sql + ' ) t'");
            sbContent.Append("\nSet @Sql = @Sql + ' ) tt Where Status <> 99 And rowNum > ' + @StartRowNum");
            sbContent.Append("\n--获取总数量");
            sbContent.Append("\nif(CharIndex('dbo.',@TabName) = 0)");
            sbContent.Append("\nBegin");
            sbContent.Append("\nSet @Sql = @Sql + ' Select Count(*) From [' + @TabName + '] Where Status <> 99'");
            sbContent.Append("\nEnd");
            sbContent.Append("\nelse");
            sbContent.Append("\nBegin");
            sbContent.Append("\nSet @Sql = @Sql + ' Select Count(*) From ' + @TabName + ' Where Status <> 99'");
            sbContent.Append("\nEnd");
            sbContent.Append("\n--条件部分");
            sbContent.Append("\nif(@StrWhere <> '')");
            sbContent.Append("\nBegin");
            sbContent.Append("\nSet @Sql = @Sql + ' and ' + @StrWhere");
            sbContent.Append("\nEnd");
            sbContent.Append("\nprint @Sql");
            sbContent.Append("\nExec (@Sql)");
            this.generateUspCode(fileName, sbContent.ToString());
        }
        #endregion

        #region 设置存储过程头
        protected String getHeader(String titleName)
        {
            String format = "yyyy-MM-dd";
            DateTime date = System.DateTime.Now;
            String strDate = date.ToString(format);

            String rt = "---------------------------------------------------------------- \r\n";
            rt = rt + "-- Copyright \r\n";
            rt = rt + "-- All rights reserved. \r\n";
            rt = rt + "-- \r\n";
            rt = rt + "-- Author	:   珍岛研发";
            rt = rt + "-- Create date	:  " + strDate + " \r\n";
            rt = rt + "-- Description	:  " + titleName + " \r\n";
            rt = rt + "-- Modify date	:		By:		Why:\r\n";
            rt = rt + "------------------------------------------------------------------ \r\n\r\n";

            return rt;
        }
        #endregion

        #region 设置传入值
        /// <summary>
        /// 设置传入值
        /// select 时 取 主键 
        /// insert 时 取 除主键外
        /// update 时 取 所有字段
        /// delete 时 取 主键
        /// deletelist 时 除外
        /// </summary>
        /// <param name="rf"></param>
        /// <param name="hasType"></param>
        /// <param name="fieldNamePrefix"></param>
        /// <param name="uspFlag"></param>
        /// <returns></returns>
        private String getInPutField(String rf)
        {
            StringBuilder sbRes = new StringBuilder();
            sbRes.Append("(\r\n");

            DataView dv = new DataView(dsTableDetails.Tables[0]);
            dv.RowFilter = rf;//过滤条件 自动例如 非自动增长  自动增长 主键等。
            if (dv.Count > 0)
            {
                bool isIdentity;
                for (int i = 0; i < dv.Count; i++)//FieldName FieldType FieldLength IsIdentity
                {
                    isIdentity = int.Parse(dv[i]["IsIdentity"].ToString()) == 0 ? false : true;//是否是自动增长
                    sbRes.Append("\t@"
                        + dv[i]["FieldName"] + " "
                        + getDataTypeAndLen(dv[i]["FieldType"].ToString(), dv[i]["FieldLength"].ToString())
                        + (i + 1 == dv.Count ? "=null" : "=null,\r\n"));
                }
            }
            return sbRes.ToString();
        }
        #endregion

        #region 设置插入、修改
        /// <summary>
        /// 主要供 insert update  deletelist 使用
        /// 内容为：
        /// 增加
        /// (
        /// Title, 
        /// Content, 
        /// OperatorId, 
        /// StartTime, 
        /// Status
        /// ) 
        /// VALUES
        /// (
        /// @Title, 
        /// @Content, 
        /// @OperatorId, 
        /// getdate(), 
        /// 0
        /// ) 
        /// 修改
        /// SET Title = @Title,
        /// Content = @Content, 
        /// OperatorId = @OperatorId, 
        /// Status = @Status 
        /// </summary>
        /// <param name="rf"></param>
        /// <param name="uspFlag"></param>
        /// <returns></returns>
        private string getEditCode(String rf, String uspFlag)
        {
            StringBuilder sbRes = new StringBuilder();
            DataView dv = new DataView(dsTableDetails.Tables[0]);
            dv.RowFilter = rf;//过滤条件 自动例如 非自动增长  自动增长 主键等。
            //isIdentity = int.Parse(dv[i]["IsIdentity"].ToString()) == 0 ? false : true;//是否是自动增长
            switch (uspFlag)
            {
                case "Insert":
                    if (dv.Count > 0)
                    {                        
                        sbRes.Append("Declare @column nvarchar(500),@columnVal nvarchar(500)\r\n");
                        sbRes.Append("set @column = ''\r\n");
                        sbRes.Append("set @columnVal = ''\r\n");
                        for (int i = 0; i < dv.Count; i++)
                        {
                            sbRes.Append("if(@" + dv[i]["FieldName"] + " is not null)\r\n");
                            sbRes.Append("begin\r\n");
                            sbRes.Append("\tset @column = @column + '[" + dv[i]["FieldName"] + "],'\r\n");
                            sbRes.Append("\tset @columnVal = @columnVal + '@" + dv[i]["FieldName"] + ",'\r\n");
                            sbRes.Append("end\r\n");                            
                        }
                        sbRes.Append("set @column = substring(@column,1,len(@column) - 1)\r\n");
                        sbRes.Append("set @columnVal = substring(@columnVal,1,len(@columnVal) - 1)\r\n");
                        sbRes.Append("set @strSql = @strSql + '(' + @column + ')values('+@columnVal+')'");
                    }
                    break;
                case "Update":
                    if (dv.Count > 0)
                    {
                        for (int i = 0; i < dv.Count; i++)
                        {
                            sbRes.Append("if(@" + dv[i]["FieldName"] + " is not null)\r\n");
                            sbRes.Append("begin\r\n");
                            sbRes.Append("\tset @strSql = @strSql + '[" + dv[i]["FieldName"] + "] = @" + dv[i]["FieldName"] + ",'\r\n");                            
                            sbRes.Append("end\r\n");
                        }
                        sbRes.Append("set @strSql = substring(@strSql,1,len(@strSql) - 1)\r\n");
                    }
                    break;
            }
            return sbRes.ToString();
        }
        #endregion

        #region 设置选择条件、附加日志
        /// <summary>
        /// 设置选择条件where
        /// </summary>
        private string getWhereField(String rf, String uspFlag)
        {
            DataView dv = new DataView(dsTableDetails.Tables[0]);
            dv.RowFilter = rf;//过滤条件 自动例如 非自动增长  自动增长 主键等。
            StringBuilder sbRes = new StringBuilder();

            switch (uspFlag)
            {
                case "Select":
                    sbRes.Append("WHERE " + dv[0]["FieldName"] + "=@" + dv[0]["FieldName"] + " \r\n ");
                    break;
                case "Update":
                    sbRes.Append("Set @strSql = @strSql + ' WHERE " + dv[0]["FieldName"] + "=@" + dv[0]["FieldName"] + "' \r\n ");
                    break;
                case "Delete":
                    sbRes.Append("WHERE " + dv[0]["FieldName"] + "=@" + dv[0]["FieldName"] + " \r\n ");
                    sbRes.Append("return  @Id");
                    break;
                case "GetModelList":
                    if (dv.Count > 0)
                    {
                        sbRes.Append("Declare @strVal nvarchar(500)\r\n");
                        sbRes.Append("Set @strVal = ''\r\n");
                        for (int i = 0; i < dv.Count; i++)
                        {
                            sbRes.Append("if(@" + dv[i]["FieldName"] + " is not null)\r\n");
                            sbRes.Append("begin\r\n");
                            if(dv[i]["FieldType"].ToString() == "datetime")
                                sbRes.Append("\tSet @strVal = @strVal + 'DateDiff(dd,[" + dv[i]["FieldName"] + "],@" + dv[i]["FieldName"] + ") = 0 and '\r\n");
                            else
                                sbRes.Append("\tSet @strVal = @strVal + '[" + dv[i]["FieldName"] + "]= @" + dv[i]["FieldName"]+ (" and '\r\n"));
                            sbRes.Append("end\r\n");
                        }
                        sbRes.Append("if len(@strVal) > 0\r\n");
                        sbRes.Append("begin\r\n");
                        sbRes.Append("Set @strVal = substring(@strVal,1,len(@strVal) - 4)\r\n");
                        sbRes.Append("Set @strSql = @strSql + ' Where Status <> 99 and ' + @strVal\r\n");
                        sbRes.Append("end\r\n");
                        sbRes.Append("print @strSql\r\n");
                    }
                    break;
                case "GetList":
                    break;
            }
            return sbRes.ToString();
        }
        #endregion

        #region 设置执行语句变量
        /// <summary>
        /// 设置执行语句变量
        /// </summary>
        private string getExecuteField(String rf, String uspFlag)
        {
            DataView dv = new DataView(dsTableDetails.Tables[0]);
            dv.RowFilter = rf;//过滤条件 自动例如 非自动增长  自动增长 主键等。
            StringBuilder sbRes = new StringBuilder();
            string a = string.Empty;
            string b = string.Empty;
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["FieldType"].ToString() == "nvarchar" || dv[i]["FieldType"].ToString() == "varchar")
                    a += "@" + dv[i]["FieldName"] + " " + dv[i]["FieldType"] + "(" + dv[i]["FieldLength"] + "),";
                else if (dv[i]["FieldType"].ToString() == "decimal")
                    a += "@" + dv[i]["FieldName"] + " " + dv[i]["FieldType"] + "(18,2),";
                else
                    a += "@" + dv[i]["FieldName"] + " " + dv[i]["FieldType"] + ",";
                b += "@" + dv[i]["FieldName"] + ",";
            }
            a = a.Substring(0, a.Length - 1);
            b = b.Substring(0, b.Length - 1);
            sbRes.Append("\r\nexec sp_executesql @strSql,N'" + a + "'," + b + "\r\n");
            switch (uspFlag)
            {
                case "Insert":
                        sbRes.Append("return @@identity");
                    break;
            }
            
            return sbRes.ToString();
        }
        #endregion

        #region 获取字段类型、长度
        /// <summary>
        /// 获取字段类型、长度
        /// </summary>
        private string getDataTypeAndLen(string type, string length)
        {
            StringBuilder sbRes = new StringBuilder();

            if (type == "int" || type == "datetime" || type == "money" || type == "ntext")
            {
                sbRes.Append(type);
            }
            else if (type == "decimal")
            {
                sbRes.Append(type + "(18,4)");
            }
            else
            {
                sbRes.Append(type + "(" + length + ")");
            }
            return sbRes.ToString();
        }
        #endregion

        #region 生成存储过程
        private void generateUspCode(string uspName, string sqlExec)
        {
            try
            {
                bool isSqlScriptsGenerateToDatabase = true;
                bool isSqlScriptsDropOld = true;
                if (isSqlScriptsGenerateToDatabase)
                {
                    // Check if usp exists
                    string strSql = "use [" + dbName + "] select * from dbo.sysobjects where id = object_id(N'[dbo].[" + uspName + "]') and OBJECTPROPERTY(id, N'IsProcedure') = 1";
                    DataSet ds = SqlHelper.ExecuteDataset(CONN, CommandType.Text, strSql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (isSqlScriptsDropOld)
                        {
                            strSql = "use " + dbName + " drop procedure [dbo].[" + uspName + "]";
                            SqlHelper.ExecuteNonQuery(CONN, CommandType.Text, strSql);
                        }
                        else
                        {
                            return;
                        }
                    }

                    SqlHelper.ExecuteNonQuery(CONN + "Initial Catalog=" + dbName + ";", CommandType.Text, sqlExec);

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #endregion
    }
}
