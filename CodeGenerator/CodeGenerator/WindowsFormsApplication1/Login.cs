using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using autocoder.Function;
using System.Data.SqlClient;
using WindowsFormsApplication1.Function;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        string CONN;
        public Login()
        {
            InitializeComponent();
            Drop_DataBase.SelectedIndex = 0;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //判断注册表是否存在信息
            GetSettings();
        }

        private void Btn_TestConnect_Click(object sender, EventArgs e)
        {
            if (JudgeLogin())
            {
                CONN = "Server=" + Tb_Server.Text +
                     ";User=" + Tb_User.Text +
                     ";Pwd=" + Tb_Pwd.Text + ";";
                try
                {
                    using (DataSet ds = SqlHelper.ExecuteDataset(CONN, CommandType.Text, Common.GetDataBase))
                    {
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            Drop_DataBase.ValueMember = "name";
                            Drop_DataBase.DataSource = ds.Tables[0].DefaultView;
                        }
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.ToString());
                }
            }
        }

        private void Btn_Connection_Click(object sender, EventArgs e)
        {
            if (JudgeLogin())
            {
                if (Drop_DataBase.Text == "暂未连接")
                {
                    MessageBox.Show("请先测试连接,选择目标数据库!");
                    Btn_TestConnect.Focus();
                    return;
                }
                if (checkBox1.Checked)
                    SaveSettings();
                else
                    DeleteSettings();
                Config.DataBase = Drop_DataBase.SelectedValue.ToString();
                Config.Pwd = Tb_Pwd.Text;
                Config.Server = Tb_Server.Text;
                Config.User = Tb_User.Text;
                Config.Conn = CONN;
                this.Visible = false;
                Form1 f1 = new Form1();
                f1.Show();
            }
        }

        private bool JudgeLogin()
        {
            if (Tb_Server.Text == string.Empty)
            {
                MessageBox.Show("服务器不能为空!");
                Tb_Server.Focus();
                return false;
            }
            if (Tb_User.Text == string.Empty)
            {
                MessageBox.Show("用户名不能为空!");
                Tb_User.Focus();
                return false;
            }
            if (Tb_Pwd.Text == string.Empty)
            {
                MessageBox.Show("密码不能为空!");
                Tb_Pwd.Focus();
                return false;
            }
            return true;
        }

        private void GetSettings()
        {
            Microsoft.Win32.RegistryKey Reg;
            Reg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Zhy", true);
            //Reg.CreateSubKey("Zhy");
            if (Reg != null)
            {
                if (Reg.GetValue("ServerName", Tb_Server.Text).ToString() != string.Empty)
                {
                    this.Tb_Server.Text = Reg.GetValue("ServerName", Tb_Server.Text).ToString();
                    this.Tb_User.Text = Reg.GetValue("LoginName", Tb_User.Text).ToString();
                    this.Tb_Pwd.Text = Reg.GetValue("Password", Tb_Pwd.Text).ToString();
                    checkBox1.Checked = true;
                }
            }            
        }

        private void SaveSettings()
        {
            Microsoft.Win32.RegistryKey Reg;
            Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Zhy");
            Reg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Zhy", true);

            Reg.SetValue("ServerName", Tb_Server.Text);
            Reg.SetValue("LoginName", Tb_User.Text);
            Reg.SetValue("Password", Tb_Pwd.Text);
            Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }

        private void DeleteSettings()
        {
            Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Zhy");
            Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("Software\\Zhy", true);
        }

        private void Tb_Server_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Tb_User_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Tb_Pwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Drop_DataBase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
