namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Lbx_TableList = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelTb1Bottom = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Lbx_UspList = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Rtb_UspText = new System.Windows.Forms.RichTextBox();
            this.panelTb1Top = new System.Windows.Forms.Panel();
            this.Btn_ExecuteCommand = new System.Windows.Forms.Button();
            this.Btn_AutoCode = new System.Windows.Forms.Button();
            this.ck_GetModelList = new System.Windows.Forms.CheckBox();
            this.ck_Delete = new System.Windows.Forms.CheckBox();
            this.ck_Update = new System.Windows.Forms.CheckBox();
            this.ck_Insert = new System.Windows.Forms.CheckBox();
            this.ck_Select = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Rtb_GeneralUspText = new System.Windows.Forms.RichTextBox();
            this.Lbx_GenerAlUspList = new System.Windows.Forms.ListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.General_panl = new System.Windows.Forms.Panel();
            this.Btn_GeneralExecuteCommand = new System.Windows.Forms.Button();
            this.Btn_GeneralAutoCode = new System.Windows.Forms.Button();
            this.ck_GenerDel = new System.Windows.Forms.CheckBox();
            this.ck_GenerGetPage = new System.Windows.Forms.CheckBox();
            this.ck_GenerUpdate = new System.Windows.Forms.CheckBox();
            this.ck_GetList = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Btn_SaveUrl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_ModelSaveUrl = new System.Windows.Forms.TextBox();
            this.Rtb_ModelCode = new System.Windows.Forms.RichTextBox();
            this.Btn_CreateModelAll = new System.Windows.Forms.Button();
            this.Btn_Model_CreateSel = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelTb1Bottom.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panelTb1Top.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.General_panl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbx_TableList
            // 
            this.Lbx_TableList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Lbx_TableList.FormattingEnabled = true;
            this.Lbx_TableList.ItemHeight = 12;
            this.Lbx_TableList.Location = new System.Drawing.Point(7, 27);
            this.Lbx_TableList.Margin = new System.Windows.Forms.Padding(0);
            this.Lbx_TableList.Name = "Lbx_TableList";
            this.Lbx_TableList.Size = new System.Drawing.Size(193, 396);
            this.Lbx_TableList.TabIndex = 13;
            this.Lbx_TableList.SelectedIndexChanged += new System.EventHandler(this.Lbx_TableList_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(203, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(611, 387);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelTb1Bottom);
            this.tabPage1.Controls.Add(this.panelTb1Top);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(603, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "存储过程";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelTb1Bottom
            // 
            this.panelTb1Bottom.Controls.Add(this.splitContainer2);
            this.panelTb1Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTb1Bottom.Location = new System.Drawing.Point(3, 45);
            this.panelTb1Bottom.Name = "panelTb1Bottom";
            this.panelTb1Bottom.Size = new System.Drawing.Size(597, 313);
            this.panelTb1Bottom.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Lbx_UspList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.Rtb_UspText);
            this.splitContainer2.Size = new System.Drawing.Size(597, 313);
            this.splitContainer2.SplitterDistance = 199;
            this.splitContainer2.TabIndex = 0;
            // 
            // Lbx_UspList
            // 
            this.Lbx_UspList.BackColor = System.Drawing.SystemColors.Window;
            this.Lbx_UspList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Lbx_UspList.ContextMenuStrip = this.contextMenuStrip1;
            this.Lbx_UspList.FormattingEnabled = true;
            this.Lbx_UspList.ItemHeight = 12;
            this.Lbx_UspList.Location = new System.Drawing.Point(0, 0);
            this.Lbx_UspList.Name = "Lbx_UspList";
            this.Lbx_UspList.Size = new System.Drawing.Size(199, 312);
            this.Lbx_UspList.TabIndex = 1;
            this.Lbx_UspList.SelectedIndexChanged += new System.EventHandler(this.Lbx_UspList_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // Rtb_UspText
            // 
            this.Rtb_UspText.Location = new System.Drawing.Point(0, 0);
            this.Rtb_UspText.Name = "Rtb_UspText";
            this.Rtb_UspText.Size = new System.Drawing.Size(394, 317);
            this.Rtb_UspText.TabIndex = 2;
            this.Rtb_UspText.Text = "";
            // 
            // panelTb1Top
            // 
            this.panelTb1Top.Controls.Add(this.Btn_ExecuteCommand);
            this.panelTb1Top.Controls.Add(this.Btn_AutoCode);
            this.panelTb1Top.Controls.Add(this.ck_GetModelList);
            this.panelTb1Top.Controls.Add(this.ck_Delete);
            this.panelTb1Top.Controls.Add(this.ck_Update);
            this.panelTb1Top.Controls.Add(this.ck_Insert);
            this.panelTb1Top.Controls.Add(this.ck_Select);
            this.panelTb1Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTb1Top.Location = new System.Drawing.Point(3, 3);
            this.panelTb1Top.Name = "panelTb1Top";
            this.panelTb1Top.Size = new System.Drawing.Size(597, 42);
            this.panelTb1Top.TabIndex = 0;
            // 
            // Btn_ExecuteCommand
            // 
            this.Btn_ExecuteCommand.Location = new System.Drawing.Point(529, 10);
            this.Btn_ExecuteCommand.Name = "Btn_ExecuteCommand";
            this.Btn_ExecuteCommand.Size = new System.Drawing.Size(62, 23);
            this.Btn_ExecuteCommand.TabIndex = 14;
            this.Btn_ExecuteCommand.Text = "执行";
            this.Btn_ExecuteCommand.UseVisualStyleBackColor = true;
            this.Btn_ExecuteCommand.Click += new System.EventHandler(this.Btn_ExecuteCommand_Click);
            // 
            // Btn_AutoCode
            // 
            this.Btn_AutoCode.Location = new System.Drawing.Point(345, 10);
            this.Btn_AutoCode.Name = "Btn_AutoCode";
            this.Btn_AutoCode.Size = new System.Drawing.Size(75, 23);
            this.Btn_AutoCode.TabIndex = 13;
            this.Btn_AutoCode.Text = "生成";
            this.Btn_AutoCode.UseVisualStyleBackColor = true;
            this.Btn_AutoCode.Click += new System.EventHandler(this.Btn_AutoCode_Click);
            // 
            // ck_GetModelList
            // 
            this.ck_GetModelList.AutoSize = true;
            this.ck_GetModelList.Checked = true;
            this.ck_GetModelList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_GetModelList.Location = new System.Drawing.Point(273, 14);
            this.ck_GetModelList.Name = "ck_GetModelList";
            this.ck_GetModelList.Size = new System.Drawing.Size(66, 16);
            this.ck_GetModelList.TabIndex = 10;
            this.ck_GetModelList.Text = "GetList";
            this.ck_GetModelList.UseVisualStyleBackColor = true;
            // 
            // ck_Delete
            // 
            this.ck_Delete.AutoSize = true;
            this.ck_Delete.Checked = true;
            this.ck_Delete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_Delete.Location = new System.Drawing.Point(207, 14);
            this.ck_Delete.Name = "ck_Delete";
            this.ck_Delete.Size = new System.Drawing.Size(60, 16);
            this.ck_Delete.TabIndex = 10;
            this.ck_Delete.Text = "Delete";
            this.ck_Delete.UseVisualStyleBackColor = true;
            // 
            // ck_Update
            // 
            this.ck_Update.AutoSize = true;
            this.ck_Update.Checked = true;
            this.ck_Update.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_Update.Location = new System.Drawing.Point(141, 14);
            this.ck_Update.Name = "ck_Update";
            this.ck_Update.Size = new System.Drawing.Size(60, 16);
            this.ck_Update.TabIndex = 9;
            this.ck_Update.Text = "Update";
            this.ck_Update.UseVisualStyleBackColor = true;
            // 
            // ck_Insert
            // 
            this.ck_Insert.AutoSize = true;
            this.ck_Insert.Checked = true;
            this.ck_Insert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_Insert.Location = new System.Drawing.Point(93, 14);
            this.ck_Insert.Name = "ck_Insert";
            this.ck_Insert.Size = new System.Drawing.Size(42, 16);
            this.ck_Insert.TabIndex = 8;
            this.ck_Insert.Text = "Add";
            this.ck_Insert.UseVisualStyleBackColor = true;
            // 
            // ck_Select
            // 
            this.ck_Select.AutoSize = true;
            this.ck_Select.Checked = true;
            this.ck_Select.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_Select.Location = new System.Drawing.Point(15, 14);
            this.ck_Select.Name = "ck_Select";
            this.ck_Select.Size = new System.Drawing.Size(72, 16);
            this.ck_Select.TabIndex = 7;
            this.ck_Select.Text = "GetModel";
            this.ck_Select.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Rtb_GeneralUspText);
            this.tabPage2.Controls.Add(this.Lbx_GenerAlUspList);
            this.tabPage2.Controls.Add(this.General_panl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(603, 361);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "通用存储过程";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Rtb_GeneralUspText
            // 
            this.Rtb_GeneralUspText.Location = new System.Drawing.Point(206, 45);
            this.Rtb_GeneralUspText.Name = "Rtb_GeneralUspText";
            this.Rtb_GeneralUspText.Size = new System.Drawing.Size(394, 317);
            this.Rtb_GeneralUspText.TabIndex = 3;
            this.Rtb_GeneralUspText.Text = "";
            // 
            // Lbx_GenerAlUspList
            // 
            this.Lbx_GenerAlUspList.BackColor = System.Drawing.SystemColors.Window;
            this.Lbx_GenerAlUspList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Lbx_GenerAlUspList.ContextMenuStrip = this.contextMenuStrip2;
            this.Lbx_GenerAlUspList.FormattingEnabled = true;
            this.Lbx_GenerAlUspList.ItemHeight = 12;
            this.Lbx_GenerAlUspList.Location = new System.Drawing.Point(3, 45);
            this.Lbx_GenerAlUspList.Name = "Lbx_GenerAlUspList";
            this.Lbx_GenerAlUspList.Size = new System.Drawing.Size(199, 312);
            this.Lbx_GenerAlUspList.TabIndex = 2;
            this.Lbx_GenerAlUspList.SelectedIndexChanged += new System.EventHandler(this.Lbx_GenerAlUspList_SelectedIndexChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 26);
            this.contextMenuStrip2.Click += new System.EventHandler(this.contextMenuStrip2_Click);
            // 
            // 删除ToolStripMenuItem1
            // 
            this.删除ToolStripMenuItem1.Name = "删除ToolStripMenuItem1";
            this.删除ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem1.Text = "删除";
            // 
            // General_panl
            // 
            this.General_panl.Controls.Add(this.Btn_GeneralExecuteCommand);
            this.General_panl.Controls.Add(this.Btn_GeneralAutoCode);
            this.General_panl.Controls.Add(this.ck_GenerDel);
            this.General_panl.Controls.Add(this.ck_GenerGetPage);
            this.General_panl.Controls.Add(this.ck_GenerUpdate);
            this.General_panl.Controls.Add(this.ck_GetList);
            this.General_panl.Dock = System.Windows.Forms.DockStyle.Top;
            this.General_panl.Location = new System.Drawing.Point(3, 3);
            this.General_panl.Name = "General_panl";
            this.General_panl.Size = new System.Drawing.Size(597, 42);
            this.General_panl.TabIndex = 1;
            // 
            // Btn_GeneralExecuteCommand
            // 
            this.Btn_GeneralExecuteCommand.Location = new System.Drawing.Point(529, 10);
            this.Btn_GeneralExecuteCommand.Name = "Btn_GeneralExecuteCommand";
            this.Btn_GeneralExecuteCommand.Size = new System.Drawing.Size(62, 23);
            this.Btn_GeneralExecuteCommand.TabIndex = 14;
            this.Btn_GeneralExecuteCommand.Text = "执行";
            this.Btn_GeneralExecuteCommand.UseVisualStyleBackColor = true;
            this.Btn_GeneralExecuteCommand.Click += new System.EventHandler(this.Btn_GeneralExecuteCommand_Click);
            // 
            // Btn_GeneralAutoCode
            // 
            this.Btn_GeneralAutoCode.Location = new System.Drawing.Point(304, 10);
            this.Btn_GeneralAutoCode.Name = "Btn_GeneralAutoCode";
            this.Btn_GeneralAutoCode.Size = new System.Drawing.Size(75, 23);
            this.Btn_GeneralAutoCode.TabIndex = 13;
            this.Btn_GeneralAutoCode.Text = "生成";
            this.Btn_GeneralAutoCode.UseVisualStyleBackColor = true;
            this.Btn_GeneralAutoCode.Click += new System.EventHandler(this.Btn_GeneralAutoCode_Click);
            // 
            // ck_GenerDel
            // 
            this.ck_GenerDel.AutoSize = true;
            this.ck_GenerDel.Checked = true;
            this.ck_GenerDel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_GenerDel.Location = new System.Drawing.Point(87, 14);
            this.ck_GenerDel.Name = "ck_GenerDel";
            this.ck_GenerDel.Size = new System.Drawing.Size(60, 16);
            this.ck_GenerDel.TabIndex = 10;
            this.ck_GenerDel.Text = "Delete";
            this.ck_GenerDel.UseVisualStyleBackColor = true;
            // 
            // ck_GenerGetPage
            // 
            this.ck_GenerGetPage.AutoSize = true;
            this.ck_GenerGetPage.Checked = true;
            this.ck_GenerGetPage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_GenerGetPage.Location = new System.Drawing.Point(219, 14);
            this.ck_GenerGetPage.Name = "ck_GenerGetPage";
            this.ck_GenerGetPage.Size = new System.Drawing.Size(66, 16);
            this.ck_GenerGetPage.TabIndex = 9;
            this.ck_GenerGetPage.Text = "GetPage";
            this.ck_GenerGetPage.UseVisualStyleBackColor = true;
            // 
            // ck_GenerUpdate
            // 
            this.ck_GenerUpdate.AutoSize = true;
            this.ck_GenerUpdate.Checked = true;
            this.ck_GenerUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_GenerUpdate.Location = new System.Drawing.Point(153, 14);
            this.ck_GenerUpdate.Name = "ck_GenerUpdate";
            this.ck_GenerUpdate.Size = new System.Drawing.Size(60, 16);
            this.ck_GenerUpdate.TabIndex = 9;
            this.ck_GenerUpdate.Text = "Update";
            this.ck_GenerUpdate.UseVisualStyleBackColor = true;
            // 
            // ck_GetList
            // 
            this.ck_GetList.AutoSize = true;
            this.ck_GetList.Checked = true;
            this.ck_GetList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_GetList.Location = new System.Drawing.Point(15, 14);
            this.ck_GetList.Name = "ck_GetList";
            this.ck_GetList.Size = new System.Drawing.Size(66, 16);
            this.ck_GetList.TabIndex = 7;
            this.ck_GetList.Text = "GetList";
            this.ck_GetList.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Btn_SaveUrl);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.Txt_ModelSaveUrl);
            this.tabPage3.Controls.Add(this.Rtb_ModelCode);
            this.tabPage3.Controls.Add(this.Btn_CreateModelAll);
            this.tabPage3.Controls.Add(this.Btn_Model_CreateSel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(603, 361);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Model";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Btn_SaveUrl
            // 
            this.Btn_SaveUrl.Location = new System.Drawing.Point(275, 334);
            this.Btn_SaveUrl.Name = "Btn_SaveUrl";
            this.Btn_SaveUrl.Size = new System.Drawing.Size(50, 23);
            this.Btn_SaveUrl.TabIndex = 4;
            this.Btn_SaveUrl.Text = "浏览";
            this.Btn_SaveUrl.UseVisualStyleBackColor = true;
            this.Btn_SaveUrl.Click += new System.EventHandler(this.Btn_SaveUrl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "保存路径：";
            // 
            // Txt_ModelSaveUrl
            // 
            this.Txt_ModelSaveUrl.Enabled = false;
            this.Txt_ModelSaveUrl.Location = new System.Drawing.Point(77, 335);
            this.Txt_ModelSaveUrl.Name = "Txt_ModelSaveUrl";
            this.Txt_ModelSaveUrl.Size = new System.Drawing.Size(192, 21);
            this.Txt_ModelSaveUrl.TabIndex = 2;
            // 
            // Rtb_ModelCode
            // 
            this.Rtb_ModelCode.Location = new System.Drawing.Point(0, 0);
            this.Rtb_ModelCode.Name = "Rtb_ModelCode";
            this.Rtb_ModelCode.Size = new System.Drawing.Size(603, 331);
            this.Rtb_ModelCode.TabIndex = 1;
            this.Rtb_ModelCode.Text = "";
            // 
            // Btn_CreateModelAll
            // 
            this.Btn_CreateModelAll.Location = new System.Drawing.Point(470, 334);
            this.Btn_CreateModelAll.Name = "Btn_CreateModelAll";
            this.Btn_CreateModelAll.Size = new System.Drawing.Size(75, 23);
            this.Btn_CreateModelAll.TabIndex = 0;
            this.Btn_CreateModelAll.Text = "生成全部";
            this.Btn_CreateModelAll.UseVisualStyleBackColor = true;
            this.Btn_CreateModelAll.Click += new System.EventHandler(this.Btn_CreateModelAll_Click);
            // 
            // Btn_Model_CreateSel
            // 
            this.Btn_Model_CreateSel.Location = new System.Drawing.Point(352, 334);
            this.Btn_Model_CreateSel.Name = "Btn_Model_CreateSel";
            this.Btn_Model_CreateSel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Model_CreateSel.TabIndex = 0;
            this.Btn_Model_CreateSel.Text = "生成当前";
            this.Btn_Model_CreateSel.UseVisualStyleBackColor = true;
            this.Btn_Model_CreateSel.Click += new System.EventHandler(this.Btn_Model_CreateSel_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(603, 361);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Web";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(607, 366);
            this.dataGridView1.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(203, 412);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(611, 13);
            this.progressBar1.TabIndex = 15;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(819, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton1.Text = "刷  新";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton2.Text = "注  销";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(819, 426);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Lbx_TableList);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeGenerator Beta 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelTb1Bottom.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelTb1Top.ResumeLayout(false);
            this.panelTb1Top.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.General_panl.ResumeLayout(false);
            this.General_panl.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Lbx_TableList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelTb1Bottom;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox Lbx_UspList;
        private System.Windows.Forms.RichTextBox Rtb_UspText;
        private System.Windows.Forms.Panel panelTb1Top;
        private System.Windows.Forms.Button Btn_AutoCode;
        private System.Windows.Forms.CheckBox ck_Delete;
        private System.Windows.Forms.CheckBox ck_Update;
        private System.Windows.Forms.CheckBox ck_Insert;
        private System.Windows.Forms.CheckBox ck_Select;
        private System.Windows.Forms.Button Btn_ExecuteCommand;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel General_panl;
        private System.Windows.Forms.Button Btn_GeneralExecuteCommand;
        private System.Windows.Forms.Button Btn_GeneralAutoCode;
        private System.Windows.Forms.CheckBox ck_GenerDel;
        private System.Windows.Forms.CheckBox ck_GenerUpdate;
        private System.Windows.Forms.CheckBox ck_GetList;
        private System.Windows.Forms.ListBox Lbx_GenerAlUspList;
        private System.Windows.Forms.RichTextBox Rtb_GeneralUspText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem1;
        private System.Windows.Forms.CheckBox ck_GetModelList;
        private System.Windows.Forms.CheckBox ck_GenerGetPage;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button Btn_Model_CreateSel;
        private System.Windows.Forms.RichTextBox Rtb_ModelCode;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_ModelSaveUrl;
        private System.Windows.Forms.Button Btn_SaveUrl;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button Btn_CreateModelAll;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}

