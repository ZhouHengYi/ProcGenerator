using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AutoCoder.Common
{
    class Configuration
    {
        private string _service;
        private string _database;
        private string _username;
        private string _password;
        private string _MyCon;

        public string Service
        {
            get { return _service; }
            set
            {
              
                _service = value;
            }
        }
        public string DataBase
        {
            get { return _database; }
            set
            {
                
                _database = value;
            }
        }
        public string UserName
        {
            get { return _username; }
            set
            {
               _username = value;
            }
        }
        public string PassWord
        {
            get { return _password; }
            set
            {
                
                _password = value;
            }
        }
        public Configuration(string service, string username, string password, string database) :
            this(service, username, password)
        {
            this.DataBase = database;
            string str = "";
            if (this.Service != "")
                str += "Data Source = " + this.Service + ";";
            if (this.DataBase != "")
                str += "Initial Catalog=" + this.DataBase + ";Persist Security Info=True;";
            if (this.UserName != "")
                str += "User ID=" + this.UserName + ";";
            if (this.PassWord != "")
                str += "Password=" + this.PassWord;
            this.MyCon = str;
        }
        public Configuration(string service, string username, string password)
        {

            this.Service = service;
            this.UserName = username;
            this.PassWord = password;

            string str = "";
            if (this.Service != "")
                str += "Data Source = " + this.Service + ";";
            if (this.UserName != "")
                str += "User ID=" + this.UserName + ";";
            if (this.PassWord != "")
                str += "Password=" + this.PassWord;
            this.MyCon = str;
        }
        public string MyCon
        {
            get
            {
                return _MyCon;
            }
            set
            {
                _MyCon = value;
            }

        }
    }
}
