using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApplication1.Function
{
    public static class Config
    {
        private static string _conn;

        public static string Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }

        private static string _server;

        /// <summary>
        /// 连接服务器
        /// </summary>
        public static string Server
        {
            get { return _server; }
            set { _server = value; }
        }
        private static string _user;

        /// <summary>
        /// 连接用户名
        /// </summary>
        public static string User
        {
            get { return _user; }
            set { _user = value; }
        }
        private static string _pwd;

        /// <summary>
        /// 连接密码
        /// </summary>
        public static string Pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
        private static string _dataBase;

        /// <summary>
        /// 数据库名称
        /// </summary>
        public static string DataBase
        {
            get { return _dataBase; }
            set { _dataBase = value; }
        }


    }
}
