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
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region 选择表名，显示存储过程名
        private void Lbx_TableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectTblGetPro();
                SelectTblGetModelCode();
                SelectTblGetWeb();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }
        }

        protected void SelectTblGetPro()
        {
            using (DataSet ds = SqlHelper.ExecuteDataset(Config.Conn, CommandType.Text, string.Format(Common.GetTableUsp, Config.DataBase, Lbx_TableList.SelectedItem)))
            {
                Lbx_UspList.Items.Clear();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {                    
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Lbx_UspList.Items.Add(dr["uspname"].ToString());
                    }
                }
            }
        }

        protected void SelectTblGetModelCode()
        {
            if (Lbx_TableList.SelectedIndex > -1)
                Rtb_ModelCode.Text = MakeModel.GetModelCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());
        }

        protected void SelectTblGetWeb()
        {
            dataGridView1.DataSource = MakeWeb.GetTable(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString()).Tables[0];
            DataGridViewRow row = new DataGridViewRow();
        }

        #endregion

        #region 选择存储过程名，显示其内容
        private void Lbx_UspList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(Config.Conn, CommandType.Text, string.Format(Common.GetText, Config.DataBase, Lbx_UspList.SelectedItem)))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        Rtb_UspText.Clear();
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Rtb_UspText.AppendText(dr["text"].ToString());
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }
        }

        private void Lbx_GenerAlUspList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(Config.Conn, CommandType.Text, string.Format(Common.GetText, Config.DataBase, Lbx_GenerAlUspList.SelectedItem)))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        Rtb_GeneralUspText.Clear();
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Rtb_GeneralUspText.AppendText(dr["text"].ToString());
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }
        }
        #endregion

        #region 运行存储过程
        private void Btn_ExecuteCommand_Click(object sender, EventArgs e)
        {
            try
            {
                int result = SqlHelper.ExecuteNonQuery(Config.Conn + "Initial Catalog=" + Config.DataBase.ToString() + ";", CommandType.Text, Rtb_UspText.Text);
                MessageBox.Show("执行成功!");
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }
        }

        private void Btn_GeneralExecuteCommand_Click(object sender, EventArgs e)
        {
            try
            {
                int result = SqlHelper.ExecuteNonQuery(Config.Conn + "Initial Catalog=" + Config.DataBase.ToString() + ";", CommandType.Text, Rtb_GeneralUspText.Text);
                MessageBox.Show("执行成功!");
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }
        }
        #endregion

        #region 生成存储过程代码
        private void Btn_AutoCode_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.SelectedItem == null)
            {
                MessageBox.Show("请选择左侧数据表!");
                return;
            }
            if (ck_Select.Checked == false &&
                ck_Insert.Checked == false &&
                ck_Update.Checked == false &&
                ck_Delete.Checked == false &&
                ck_GetModelList.Checked == false)
            {
                return;
            }
            MakeSql mf = new MakeSql();
            mf.IsSetlect = ck_Select.Checked;
            mf.IsInsert = ck_Insert.Checked;
            mf.IsUpdate = ck_Update.Checked;
            mf.IsDelete = ck_Delete.Checked;
            mf.IsGetModelList = ck_GetModelList.Checked;
            mf.DBName = Config.DataBase;
            mf.TableName = Lbx_TableList.SelectedItem.ToString();
            mf.makeFile(Config.Conn);
            SelectTblGetPro();
            MessageBox.Show("生成成功");
            if (Lbx_TableList.SelectedIndex + 1 != Lbx_TableList.Items.Count)
                Lbx_TableList.SelectedIndex = Lbx_TableList.SelectedIndex + 1;
            else
                Lbx_TableList.SelectedIndex = 0;
        }
        #endregion


        private void Btn_GeneralAutoCode_Click(object sender, EventArgs e)
        {
            if (ck_GetList.Checked == false && ck_GenerDel.Checked == false
                && ck_GenerUpdate.Checked == false && ck_GenerGetPage.AutoCheck == false)
            {
                return;
            }
            MakeSql mf = new MakeSql();
            mf.IsGetList = ck_GetList.Checked;
            mf.IsGenerDel = ck_GenerDel.Checked;
            mf.IsGenerUpdate = ck_GenerUpdate.Checked;
            mf.IsGenerGetPage = ck_GenerGetPage.Checked;
            mf.DBName = Config.DataBase.ToString();
            mf.makeGeneralFile(Config.Conn);
            GetGeneral();
            MessageBox.Show("生成成功");
        }

        #region 右键删除存储过程
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (Lbx_UspList.SelectedIndex.ToString() == "-1")
            {
                MessageBox.Show("请选择需要删除的存储过程!");
                return;
            }
            int result = SqlHelper.ExecuteNonQuery(Config.Conn + "Initial Catalog=" + Config.DataBase.ToString() + ";", CommandType.Text, "Drop proc " + Lbx_UspList.SelectedItem.ToString());
            SelectTblGetPro();
            MessageBox.Show("删除成功!");
        }

        private void contextMenuStrip2_Click(object sender, EventArgs e)
        {
            if (Lbx_GenerAlUspList.SelectedIndex.ToString() == "-1")
            {
                MessageBox.Show("请选择需要删除的存储过程!");
                return;
            }
            int result = SqlHelper.ExecuteNonQuery(Config.Conn + "Initial Catalog=" + Config.DataBase.ToString() + ";", CommandType.Text, "Drop proc " + Lbx_GenerAlUspList.SelectedItem.ToString());
            GetGeneral();
            MessageBox.Show("删除成功!");
        }

        #endregion

        private void Btn_Model_CreateSel_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.SelectedItem == null)
            {
                MessageBox.Show("请选择左侧数据表!");
                return;
            }
            string modelCode = MakeModel.GetModelCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());

            if (Txt_ModelSaveUrl.Text == string.Empty)
            {
                if (!Directory.Exists(Config.DataBase + "/Model/"))
                    Directory.CreateDirectory(Config.DataBase + "/Model/");                
                File.WriteAllText(Config.DataBase + "/Model/" + Lbx_TableList.SelectedItem.ToString() + "DO.cs", modelCode, Encoding.UTF8);
            }
            else
            {
                if (!Directory.Exists(Txt_ModelSaveUrl.Text + "/Model/"))
                    Directory.CreateDirectory(Txt_ModelSaveUrl.Text + "/Model/");
                File.WriteAllText(Txt_ModelSaveUrl.Text + "/Model/" + Lbx_TableList.SelectedItem.ToString() + "DO.cs", modelCode, Encoding.UTF8);
            }
            MessageBox.Show("生成成功!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetTable();
        }

        /// <summary>
        /// 获取所有表
        /// </summary>
        protected void GetTable()
        {

            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(Config.Conn, CommandType.Text, string.Format(Common.GetTableName, Config.DataBase)))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        Lbx_TableList.Items.Clear();
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Lbx_TableList.Items.Add(dr["name"].ToString());
                        }
                    }
                }

                //显示通用存储过程
                GetGeneral();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }           
        }
        public void GetGeneral()
        {
            using (DataSet ds = SqlHelper.ExecuteDataset(Config.Conn, CommandType.Text, string.Format(Common.GetTableUsp, Config.DataBase, "General")))
            {
                Lbx_GenerAlUspList.Items.Clear();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Lbx_GenerAlUspList.Items.Add(dr["uspname"].ToString());
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            Application.Exit();            
        }


        private void Btn_SaveUrl_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            Txt_ModelSaveUrl.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Btn_CreateModelAll_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.Items.Count == 0)
            {
                MessageBox.Show("暂无表结构可生成!");
                return;
            }
            progressBar1.Maximum = Lbx_TableList.Items.Count;
            progressBar1.Minimum = 0;
            for (int i = 0; i < Lbx_TableList.Items.Count; i++)
            {
                string modelCode = MakeModel.GetModelCode(Config.Conn, Config.DataBase, Lbx_TableList.Items[i].ToString());

                if (Txt_ModelSaveUrl.Text == string.Empty)
                {
                    if (!Directory.Exists(Config.DataBase + "/Model/"))
                        Directory.CreateDirectory(Config.DataBase + "/Model/");
                    File.WriteAllText(Config.DataBase + "/Model/" + Lbx_TableList.Items[i].ToString() + "DO.cs", modelCode, Encoding.UTF8);
                }
                else
                {
                    if (!Directory.Exists(Txt_ModelSaveUrl.Text + "/Model/"))
                        Directory.CreateDirectory(Txt_ModelSaveUrl.Text + "/Model/");
                    File.WriteAllText(Txt_ModelSaveUrl.Text + "/Model/" + Lbx_TableList.Items[i].ToString() + "DO.cs", modelCode, Encoding.UTF8);
                }
                progressBar1.Value = i + 1;
            }
            progressBar1.Value = 0;            
            MessageBox.Show("生成成功!");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GetTable();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login login = new Login();
            login.Show();
        }        
    }
}
