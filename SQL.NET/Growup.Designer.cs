namespace SQL.NET
{
    partial class Growup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Growup));
            this.but_getDatabase = new System.Windows.Forms.Button();
            this.comboBox_Database = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.comboBox_Service = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listBox_Table = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox_Target = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txt_fields = new System.Windows.Forms.TextBox();
            this.txt_tabname = new System.Windows.Forms.TextBox();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.Lb_field = new System.Windows.Forms.Label();
            this.Lb_Key = new System.Windows.Forms.Label();
            this.Lb_tabname = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.But_CreateProcAll = new System.Windows.Forms.Button();
            this.But_CreateProc = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_ModelName = new System.Windows.Forms.TextBox();
            this.txt_ModelKey = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_CreateModelAll = new System.Windows.Forms.Button();
            this.btn_CreateTyModel = new System.Windows.Forms.Button();
            this.btn_CreateModel = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_CreateTY = new System.Windows.Forms.Button();
            this.txt_TYCode = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Btn_CreateFunction = new System.Windows.Forms.Button();
            this.Txt_Function = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_getDatabase
            // 
            this.but_getDatabase.Location = new System.Drawing.Point(534, 12);
            this.but_getDatabase.Name = "but_getDatabase";
            this.but_getDatabase.Size = new System.Drawing.Size(75, 23);
            this.but_getDatabase.TabIndex = 0;
            this.but_getDatabase.Text = "链接";
            this.but_getDatabase.UseVisualStyleBackColor = true;
            this.but_getDatabase.Click += new System.EventHandler(this.but_getDatabase_Click);
            // 
            // comboBox_Database
            // 
            this.comboBox_Database.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Database.FormattingEnabled = true;
            this.comboBox_Database.Location = new System.Drawing.Point(58, 49);
            this.comboBox_Database.Name = "comboBox_Database";
            this.comboBox_Database.Size = new System.Drawing.Size(100, 20);
            this.comboBox_Database.TabIndex = 1;
            this.comboBox_Database.SelectedIndexChanged += new System.EventHandler(this.comboBox_Database_SelectedIndexChanged);
            this.comboBox_Database.Click += new System.EventHandler(this.comboBox_Database_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "服务器";
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(232, 12);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(90, 21);
            this.textBox_Username.TabIndex = 3;
            // 
            // comboBox_Service
            // 
            this.comboBox_Service.FormattingEnabled = true;
            this.comboBox_Service.Location = new System.Drawing.Point(59, 13);
            this.comboBox_Service.Name = "comboBox_Service";
            this.comboBox_Service.Size = new System.Drawing.Size(100, 20);
            this.comboBox_Service.TabIndex = 1;
            this.comboBox_Service.Text = "PC-20110903AFRK\\SQLSERVER2005";
            this.comboBox_Service.Click += new System.EventHandler(this.comboBox_Service_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(471, -146);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(89, 21);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "(local)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密  码";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(404, 13);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(90, 21);
            this.textBox_Password.TabIndex = 3;
            this.textBox_Password.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "数据库";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox_Username);
            this.splitContainer1.Panel1.Controls.Add(this.but_getDatabase);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_Password);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_Database);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_Service);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(641, 437);
            this.splitContainer1.SplitterDistance = 79;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listBox_Table);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(641, 354);
            this.splitContainer2.SplitterDistance = 124;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // listBox_Table
            // 
            this.listBox_Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Table.FormattingEnabled = true;
            this.listBox_Table.ItemHeight = 12;
            this.listBox_Table.Location = new System.Drawing.Point(0, 0);
            this.listBox_Table.Name = "listBox_Table";
            this.listBox_Table.Size = new System.Drawing.Size(123, 352);
            this.listBox_Table.TabIndex = 0;
            this.listBox_Table.SelectedIndexChanged += new System.EventHandler(this.listBox_Table_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(512, 350);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox_Target);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.txt_fields);
            this.tabPage1.Controls.Add(this.txt_tabname);
            this.tabPage1.Controls.Add(this.txt_key);
            this.tabPage1.Controls.Add(this.Lb_field);
            this.tabPage1.Controls.Add(this.Lb_Key);
            this.tabPage1.Controls.Add(this.Lb_tabname);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.But_CreateProcAll);
            this.tabPage1.Controls.Add(this.But_CreateProc);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(504, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "存储过程生成";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox_Target
            // 
            this.comboBox_Target.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Target.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Target.FormattingEnabled = true;
            this.comboBox_Target.Items.AddRange(new object[] {
            "文件"});
            this.comboBox_Target.Location = new System.Drawing.Point(98, 101);
            this.comboBox_Target.Name = "comboBox_Target";
            this.comboBox_Target.Size = new System.Drawing.Size(168, 20);
            this.comboBox_Target.TabIndex = 34;
            this.comboBox_Target.Tag = "";
            // 
            // textBox4
            // 
            this.textBox4.ForeColor = System.Drawing.Color.Blue;
            this.textBox4.Location = new System.Drawing.Point(98, 143);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(336, 99);
            this.textBox4.TabIndex = 33;
            this.textBox4.Click += new System.EventHandler(this.textBox4_Click);
            // 
            // txt_fields
            // 
            this.txt_fields.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_fields.ForeColor = System.Drawing.Color.Blue;
            this.txt_fields.Location = new System.Drawing.Point(98, 143);
            this.txt_fields.Multiline = true;
            this.txt_fields.Name = "txt_fields";
            this.txt_fields.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_fields.Size = new System.Drawing.Size(336, 99);
            this.txt_fields.TabIndex = 27;
            // 
            // txt_tabname
            // 
            this.txt_tabname.ForeColor = System.Drawing.Color.Blue;
            this.txt_tabname.Location = new System.Drawing.Point(98, 23);
            this.txt_tabname.Name = "txt_tabname";
            this.txt_tabname.Size = new System.Drawing.Size(168, 21);
            this.txt_tabname.TabIndex = 23;
            // 
            // txt_key
            // 
            this.txt_key.ForeColor = System.Drawing.Color.Blue;
            this.txt_key.Location = new System.Drawing.Point(98, 62);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(168, 21);
            this.txt_key.TabIndex = 26;
            // 
            // Lb_field
            // 
            this.Lb_field.AutoSize = true;
            this.Lb_field.BackColor = System.Drawing.Color.White;
            this.Lb_field.ForeColor = System.Drawing.Color.Red;
            this.Lb_field.Location = new System.Drawing.Point(199, 188);
            this.Lb_field.Name = "Lb_field";
            this.Lb_field.Size = new System.Drawing.Size(0, 12);
            this.Lb_field.TabIndex = 32;
            // 
            // Lb_Key
            // 
            this.Lb_Key.AutoSize = true;
            this.Lb_Key.ForeColor = System.Drawing.Color.Red;
            this.Lb_Key.Location = new System.Drawing.Point(281, 75);
            this.Lb_Key.Name = "Lb_Key";
            this.Lb_Key.Size = new System.Drawing.Size(0, 12);
            this.Lb_Key.TabIndex = 31;
            // 
            // Lb_tabname
            // 
            this.Lb_tabname.AutoSize = true;
            this.Lb_tabname.ForeColor = System.Drawing.Color.Red;
            this.Lb_tabname.Location = new System.Drawing.Point(281, 26);
            this.Lb_tabname.Name = "Lb_tabname";
            this.Lb_tabname.Size = new System.Drawing.Size(0, 12);
            this.Lb_tabname.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "表 名：";
            // 
            // But_CreateProcAll
            // 
            this.But_CreateProcAll.Location = new System.Drawing.Point(305, 267);
            this.But_CreateProcAll.Name = "But_CreateProcAll";
            this.But_CreateProcAll.Size = new System.Drawing.Size(86, 32);
            this.But_CreateProcAll.TabIndex = 28;
            this.But_CreateProcAll.Text = "生成全部";
            this.But_CreateProcAll.UseVisualStyleBackColor = true;
            this.But_CreateProcAll.Click += new System.EventHandler(this.But_CreateProcAll_Click);
            // 
            // But_CreateProc
            // 
            this.But_CreateProc.Location = new System.Drawing.Point(98, 267);
            this.But_CreateProc.Name = "But_CreateProc";
            this.But_CreateProc.Size = new System.Drawing.Size(86, 32);
            this.But_CreateProc.TabIndex = 28;
            this.But_CreateProc.Text = "生成选中";
            this.But_CreateProc.UseVisualStyleBackColor = true;
            this.But_CreateProc.Click += new System.EventHandler(this.But_CreateProc_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "WebConfig：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "目 标：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "主 键：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txt_ModelName);
            this.tabPage3.Controls.Add(this.txt_ModelKey);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.btn_CreateModelAll);
            this.tabPage3.Controls.Add(this.btn_CreateTyModel);
            this.tabPage3.Controls.Add(this.btn_CreateModel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(504, 324);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Model";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_ModelName
            // 
            this.txt_ModelName.Location = new System.Drawing.Point(98, 50);
            this.txt_ModelName.Name = "txt_ModelName";
            this.txt_ModelName.Size = new System.Drawing.Size(166, 21);
            this.txt_ModelName.TabIndex = 2;
            // 
            // txt_ModelKey
            // 
            this.txt_ModelKey.Location = new System.Drawing.Point(98, 102);
            this.txt_ModelKey.Name = "txt_ModelKey";
            this.txt_ModelKey.Size = new System.Drawing.Size(166, 21);
            this.txt_ModelKey.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "表名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "主键";
            // 
            // btn_CreateModelAll
            // 
            this.btn_CreateModelAll.Location = new System.Drawing.Point(345, 174);
            this.btn_CreateModelAll.Name = "btn_CreateModelAll";
            this.btn_CreateModelAll.Size = new System.Drawing.Size(104, 35);
            this.btn_CreateModelAll.TabIndex = 0;
            this.btn_CreateModelAll.Text = "全部生成";
            this.btn_CreateModelAll.UseVisualStyleBackColor = true;
            this.btn_CreateModelAll.Click += new System.EventHandler(this.btn_CreateModelAll_Click);
            // 
            // btn_CreateTyModel
            // 
            this.btn_CreateTyModel.Location = new System.Drawing.Point(203, 174);
            this.btn_CreateTyModel.Name = "btn_CreateTyModel";
            this.btn_CreateTyModel.Size = new System.Drawing.Size(104, 35);
            this.btn_CreateTyModel.TabIndex = 0;
            this.btn_CreateTyModel.Text = "生成通用类";
            this.btn_CreateTyModel.UseVisualStyleBackColor = true;
            this.btn_CreateTyModel.Click += new System.EventHandler(this.btn_CreateTyModel_Click);
            // 
            // btn_CreateModel
            // 
            this.btn_CreateModel.Location = new System.Drawing.Point(56, 174);
            this.btn_CreateModel.Name = "btn_CreateModel";
            this.btn_CreateModel.Size = new System.Drawing.Size(104, 35);
            this.btn_CreateModel.TabIndex = 0;
            this.btn_CreateModel.Text = "单个生成";
            this.btn_CreateModel.UseVisualStyleBackColor = true;
            this.btn_CreateModel.Click += new System.EventHandler(this.btn_CreateModel_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_CreateTY);
            this.tabPage2.Controls.Add(this.txt_TYCode);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(504, 324);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "生成通用方法";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_CreateTY
            // 
            this.btn_CreateTY.Location = new System.Drawing.Point(204, 186);
            this.btn_CreateTY.Name = "btn_CreateTY";
            this.btn_CreateTY.Size = new System.Drawing.Size(86, 32);
            this.btn_CreateTY.TabIndex = 38;
            this.btn_CreateTY.Text = "生成";
            this.btn_CreateTY.UseVisualStyleBackColor = true;
            this.btn_CreateTY.Click += new System.EventHandler(this.btn_CreateTY_Click);
            // 
            // txt_TYCode
            // 
            this.txt_TYCode.ForeColor = System.Drawing.Color.Blue;
            this.txt_TYCode.Location = new System.Drawing.Point(101, 18);
            this.txt_TYCode.Multiline = true;
            this.txt_TYCode.Name = "txt_TYCode";
            this.txt_TYCode.Size = new System.Drawing.Size(377, 153);
            this.txt_TYCode.TabIndex = 37;
            this.txt_TYCode.Click += new System.EventHandler(this.txt_TYCode_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.ForeColor = System.Drawing.Color.Blue;
            this.textBox3.Location = new System.Drawing.Point(101, 18);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(377, 153);
            this.textBox3.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(202, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 12);
            this.label11.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 12);
            this.label12.TabIndex = 34;
            this.label12.Text = "WebConfig：";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.Btn_CreateFunction);
            this.tabPage4.Controls.Add(this.Txt_Function);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(504, 324);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "权限相关";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Btn_CreateFunction
            // 
            this.Btn_CreateFunction.Location = new System.Drawing.Point(204, 191);
            this.Btn_CreateFunction.Name = "Btn_CreateFunction";
            this.Btn_CreateFunction.Size = new System.Drawing.Size(86, 32);
            this.Btn_CreateFunction.TabIndex = 41;
            this.Btn_CreateFunction.Text = "生成";
            this.Btn_CreateFunction.UseVisualStyleBackColor = true;
            this.Btn_CreateFunction.Click += new System.EventHandler(this.Btn_CreateFunction_Click);
            // 
            // Txt_Function
            // 
            this.Txt_Function.ForeColor = System.Drawing.Color.Blue;
            this.Txt_Function.Location = new System.Drawing.Point(101, 23);
            this.Txt_Function.Multiline = true;
            this.Txt_Function.Name = "Txt_Function";
            this.Txt_Function.Size = new System.Drawing.Size(377, 153);
            this.Txt_Function.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 12);
            this.label13.TabIndex = 39;
            this.label13.Text = "WebConfig：";
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // Growup
            // 
            this.AcceptButton = this.but_getDatabase;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 437);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.textBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Growup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Growup";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_getDatabase;
        private System.Windows.Forms.ComboBox comboBox_Database;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.ComboBox comboBox_Service;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox listBox_Table;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBox_Target;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txt_fields;
        private System.Windows.Forms.TextBox txt_tabname;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.Label Lb_field;
        private System.Windows.Forms.Label Lb_Key;
        private System.Windows.Forms.Label Lb_tabname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button But_CreateProcAll;
        private System.Windows.Forms.Button But_CreateProc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txt_ModelName;
        private System.Windows.Forms.TextBox txt_ModelKey;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_CreateModelAll;
        private System.Windows.Forms.Button btn_CreateModel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_TYCode;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_CreateTY;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Button btn_CreateTyModel;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button Btn_CreateFunction;
        private System.Windows.Forms.TextBox Txt_Function;
        private System.Windows.Forms.Label label13;
    }
}