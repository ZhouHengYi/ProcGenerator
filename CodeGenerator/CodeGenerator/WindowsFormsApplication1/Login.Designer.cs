namespace WindowsFormsApplication1
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.Tb_Server = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tb_User = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Tb_Pwd = new System.Windows.Forms.TextBox();
            this.Btn_TestConnect = new System.Windows.Forms.Button();
            this.Btn_Connection = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Drop_DataBase = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "服务器：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Tb_Server
            // 
            this.Tb_Server.Location = new System.Drawing.Point(83, 22);
            this.Tb_Server.Name = "Tb_Server";
            this.Tb_Server.Size = new System.Drawing.Size(224, 21);
            this.Tb_Server.TabIndex = 1;
            this.Tb_Server.TextChanged += new System.EventHandler(this.Tb_Server_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "登录名：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Tb_User
            // 
            this.Tb_User.Location = new System.Drawing.Point(83, 62);
            this.Tb_User.Name = "Tb_User";
            this.Tb_User.Size = new System.Drawing.Size(141, 21);
            this.Tb_User.TabIndex = 2;
            this.Tb_User.TextChanged += new System.EventHandler(this.Tb_User_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "密　码：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Tb_Pwd
            // 
            this.Tb_Pwd.Location = new System.Drawing.Point(83, 102);
            this.Tb_Pwd.Name = "Tb_Pwd";
            this.Tb_Pwd.Size = new System.Drawing.Size(141, 21);
            this.Tb_Pwd.TabIndex = 3;
            this.Tb_Pwd.TextChanged += new System.EventHandler(this.Tb_Pwd_TextChanged);
            // 
            // Btn_TestConnect
            // 
            this.Btn_TestConnect.Location = new System.Drawing.Point(59, 180);
            this.Btn_TestConnect.Name = "Btn_TestConnect";
            this.Btn_TestConnect.Size = new System.Drawing.Size(75, 23);
            this.Btn_TestConnect.TabIndex = 6;
            this.Btn_TestConnect.Text = "测试连接";
            this.Btn_TestConnect.UseVisualStyleBackColor = true;
            this.Btn_TestConnect.Click += new System.EventHandler(this.Btn_TestConnect_Click);
            // 
            // Btn_Connection
            // 
            this.Btn_Connection.Location = new System.Drawing.Point(182, 180);
            this.Btn_Connection.Name = "Btn_Connection";
            this.Btn_Connection.Size = new System.Drawing.Size(75, 23);
            this.Btn_Connection.TabIndex = 7;
            this.Btn_Connection.Text = "确定";
            this.Btn_Connection.UseVisualStyleBackColor = true;
            this.Btn_Connection.Click += new System.EventHandler(this.Btn_Connection_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "数据库：";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Drop_DataBase
            // 
            this.Drop_DataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Drop_DataBase.FormattingEnabled = true;
            this.Drop_DataBase.Items.AddRange(new object[] {
            "暂未连接"});
            this.Drop_DataBase.Location = new System.Drawing.Point(83, 142);
            this.Drop_DataBase.Name = "Drop_DataBase";
            this.Drop_DataBase.Size = new System.Drawing.Size(121, 20);
            this.Drop_DataBase.TabIndex = 4;
            this.Drop_DataBase.SelectedIndexChanged += new System.EventHandler(this.Drop_DataBase_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(211, 146);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "保存登录信息";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(361, 219);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Drop_DataBase);
            this.Controls.Add(this.Btn_Connection);
            this.Controls.Add(this.Btn_TestConnect);
            this.Controls.Add(this.Tb_Pwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Tb_User);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tb_Server);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tb_Server;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tb_User;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Tb_Pwd;
        private System.Windows.Forms.Button Btn_Connection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Drop_DataBase;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button Btn_TestConnect;
    }
}