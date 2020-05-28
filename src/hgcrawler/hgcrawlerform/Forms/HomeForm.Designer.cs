namespace hgcrawlerform
{
    partial class HomeForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sysLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlabStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labPublicIP = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvVisitRule = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvPCUserAgent = new System.Windows.Forms.DataGridView();
            this.UserAgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dgvMobileUserAgent = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMenuDeletePCRule = new System.Windows.Forms.ToolStripMenuItem();
            this.CMenuSavePCRule = new System.Windows.Forms.ToolStripMenuItem();
            this.CMenuLoadPCRule = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchKeys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaitSecsMinInSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaitSecsMaxInSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductKeys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaitSecsMinInProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaitSecsMaxInProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceKeys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaitSecsMinInPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaitSecsMaxInPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.comUserAgentChangeMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comVisitRuleType = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitRule)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPCUserAgent)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobileUserAgent)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sysLogToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // sysLogToolStripMenuItem
            // 
            this.sysLogToolStripMenuItem.Name = "sysLogToolStripMenuItem";
            this.sysLogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sysLogToolStripMenuItem.Text = "SysLog";
            this.sysLogToolStripMenuItem.Click += new System.EventHandler(this.sysLogToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlabStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlabStatus
            // 
            this.tlabStatus.Name = "tlabStatus";
            this.tlabStatus.Size = new System.Drawing.Size(43, 17);
            this.tlabStatus.Text = "Status";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 403);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 377);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Web Visit";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labPublicIP);
            this.splitContainer1.Panel1.Controls.Add(this.btnStop);
            this.splitContainer1.Panel1.Controls.Add(this.btnStart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(786, 371);
            this.splitContainer1.SplitterDistance = 85;
            this.splitContainer1.TabIndex = 0;
            // 
            // labPublicIP
            // 
            this.labPublicIP.AutoSize = true;
            this.labPublicIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPublicIP.Location = new System.Drawing.Point(216, 34);
            this.labPublicIP.Name = "labPublicIP";
            this.labPublicIP.Size = new System.Drawing.Size(106, 20);
            this.labPublicIP.TabIndex = 2;
            this.labPublicIP.Text = "IP：127.0.0.1";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.MistyRose;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(112, 16);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(85, 56);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Aquamarine;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(21, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(85, 56);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(786, 282);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvVisitRule);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(778, 256);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Visit Rules";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvVisitRule
            // 
            this.dgvVisitRule.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvVisitRule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisitRule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SearchKeys,
            this.WaitSecsMinInSearch,
            this.WaitSecsMaxInSearch,
            this.ProductKeys,
            this.WaitSecsMinInProduct,
            this.WaitSecsMaxInProduct,
            this.PriceKeys,
            this.WaitSecsMinInPrice,
            this.WaitSecsMaxInPrice,
            this.State});
            this.dgvVisitRule.ContextMenuStrip = this.contextMenuStrip;
            this.dgvVisitRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVisitRule.Location = new System.Drawing.Point(3, 3);
            this.dgvVisitRule.Name = "dgvVisitRule";
            this.dgvVisitRule.RowHeadersWidth = 51;
            this.dgvVisitRule.Size = new System.Drawing.Size(772, 250);
            this.dgvVisitRule.TabIndex = 1;
            this.dgvVisitRule.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVisitRule_CellEndEdit);
            this.dgvVisitRule.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvVisitRule_RowPostPaint);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.comVisitRuleType);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.comUserAgentChangeMode);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(778, 256);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Browser Control";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvPCUserAgent);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(778, 256);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "PC-UserAgent";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvPCUserAgent
            // 
            this.dgvPCUserAgent.AllowUserToAddRows = false;
            this.dgvPCUserAgent.AllowUserToDeleteRows = false;
            this.dgvPCUserAgent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPCUserAgent.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPCUserAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPCUserAgent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserAgent});
            this.dgvPCUserAgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPCUserAgent.Location = new System.Drawing.Point(3, 3);
            this.dgvPCUserAgent.Name = "dgvPCUserAgent";
            this.dgvPCUserAgent.ReadOnly = true;
            this.dgvPCUserAgent.RowHeadersWidth = 51;
            this.dgvPCUserAgent.Size = new System.Drawing.Size(772, 250);
            this.dgvPCUserAgent.TabIndex = 1;
            this.dgvPCUserAgent.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPCUserAgent_RowPostPaint);
            // 
            // UserAgent
            // 
            this.UserAgent.HeaderText = "UserAgent";
            this.UserAgent.MinimumWidth = 6;
            this.UserAgent.Name = "UserAgent";
            this.UserAgent.ReadOnly = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dgvMobileUserAgent);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(778, 256);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Mobile-UserAgent";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dgvMobileUserAgent
            // 
            this.dgvMobileUserAgent.AllowUserToAddRows = false;
            this.dgvMobileUserAgent.AllowUserToDeleteRows = false;
            this.dgvMobileUserAgent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMobileUserAgent.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMobileUserAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMobileUserAgent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6});
            this.dgvMobileUserAgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMobileUserAgent.Location = new System.Drawing.Point(3, 3);
            this.dgvMobileUserAgent.Name = "dgvMobileUserAgent";
            this.dgvMobileUserAgent.ReadOnly = true;
            this.dgvMobileUserAgent.RowHeadersWidth = 51;
            this.dgvMobileUserAgent.Size = new System.Drawing.Size(772, 250);
            this.dgvMobileUserAgent.TabIndex = 1;
            this.dgvMobileUserAgent.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMobileUserAgent_RowPostPaint);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "UserAgent";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 377);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Network Control";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMenuDeletePCRule,
            this.CMenuSavePCRule,
            this.CMenuLoadPCRule});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(149, 70);
            // 
            // CMenuDeletePCRule
            // 
            this.CMenuDeletePCRule.Name = "CMenuDeletePCRule";
            this.CMenuDeletePCRule.Size = new System.Drawing.Size(148, 22);
            this.CMenuDeletePCRule.Text = "Delete Rules";
            this.CMenuDeletePCRule.Click += new System.EventHandler(this.CMenuDeletePCRule_Click);
            // 
            // CMenuSavePCRule
            // 
            this.CMenuSavePCRule.Name = "CMenuSavePCRule";
            this.CMenuSavePCRule.Size = new System.Drawing.Size(148, 22);
            this.CMenuSavePCRule.Text = "Save Rules";
            this.CMenuSavePCRule.Click += new System.EventHandler(this.CMenuSavePCRule_Click);
            // 
            // CMenuLoadPCRule
            // 
            this.CMenuLoadPCRule.Name = "CMenuLoadPCRule";
            this.CMenuLoadPCRule.Size = new System.Drawing.Size(148, 22);
            this.CMenuLoadPCRule.Text = "Lora Rules";
            this.CMenuLoadPCRule.Click += new System.EventHandler(this.CMenuLoadPCRule_Click);
            // 
            // SearchKeys
            // 
            this.SearchKeys.HeaderText = "SearchKeys";
            this.SearchKeys.MinimumWidth = 6;
            this.SearchKeys.Name = "SearchKeys";
            // 
            // WaitSecsMinInSearch
            // 
            this.WaitSecsMinInSearch.HeaderText = "WaitMin";
            this.WaitSecsMinInSearch.MinimumWidth = 6;
            this.WaitSecsMinInSearch.Name = "WaitSecsMinInSearch";
            this.WaitSecsMinInSearch.Width = 55;
            // 
            // WaitSecsMaxInSearch
            // 
            this.WaitSecsMaxInSearch.HeaderText = "WaitMax";
            this.WaitSecsMaxInSearch.Name = "WaitSecsMaxInSearch";
            this.WaitSecsMaxInSearch.Width = 55;
            // 
            // ProductKeys
            // 
            this.ProductKeys.HeaderText = "ProductKeys";
            this.ProductKeys.MinimumWidth = 6;
            this.ProductKeys.Name = "ProductKeys";
            // 
            // WaitSecsMinInProduct
            // 
            this.WaitSecsMinInProduct.HeaderText = "WaitMin";
            this.WaitSecsMinInProduct.MinimumWidth = 6;
            this.WaitSecsMinInProduct.Name = "WaitSecsMinInProduct";
            this.WaitSecsMinInProduct.Width = 55;
            // 
            // WaitSecsMaxInProduct
            // 
            this.WaitSecsMaxInProduct.HeaderText = "WaitMax";
            this.WaitSecsMaxInProduct.Name = "WaitSecsMaxInProduct";
            this.WaitSecsMaxInProduct.Width = 55;
            // 
            // PriceKeys
            // 
            this.PriceKeys.HeaderText = "PriceKeys";
            this.PriceKeys.MinimumWidth = 6;
            this.PriceKeys.Name = "PriceKeys";
            // 
            // WaitSecsMinInPrice
            // 
            this.WaitSecsMinInPrice.HeaderText = "WaitMin";
            this.WaitSecsMinInPrice.MinimumWidth = 6;
            this.WaitSecsMinInPrice.Name = "WaitSecsMinInPrice";
            this.WaitSecsMinInPrice.Width = 55;
            // 
            // WaitSecsMaxInPrice
            // 
            this.WaitSecsMaxInPrice.HeaderText = "WaitMax";
            this.WaitSecsMaxInPrice.Name = "WaitSecsMaxInPrice";
            this.WaitSecsMaxInPrice.Width = 55;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.MinimumWidth = 6;
            this.State.Name = "State";
            this.State.Width = 60;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(778, 256);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "Visit Control";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // comUserAgentChangeMode
            // 
            this.comUserAgentChangeMode.FormattingEnabled = true;
            this.comUserAgentChangeMode.Items.AddRange(new object[] {
            "Single",
            "Grouply",
            "NoAction"});
            this.comUserAgentChangeMode.Location = new System.Drawing.Point(108, 45);
            this.comUserAgentChangeMode.Name = "comUserAgentChangeMode";
            this.comUserAgentChangeMode.Size = new System.Drawing.Size(121, 21);
            this.comUserAgentChangeMode.TabIndex = 0;
            this.comUserAgentChangeMode.Text = "NoAction";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserAgent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vist Rule Type";
            // 
            // comVisitRuleType
            // 
            this.comVisitRuleType.FormattingEnabled = true;
            this.comVisitRuleType.Items.AddRange(new object[] {
            "PC",
            "Mobile"});
            this.comVisitRuleType.Location = new System.Drawing.Point(108, 18);
            this.comVisitRuleType.Name = "comVisitRuleType";
            this.comVisitRuleType.Size = new System.Drawing.Size(121, 21);
            this.comVisitRuleType.TabIndex = 3;
            this.comVisitRuleType.Text = "PC";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "hgcrawler";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitRule)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPCUserAgent)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobileUserAgent)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sysLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tlabStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labPublicIP;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dgvVisitRule;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dgvPCUserAgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserAgent;
        private System.Windows.Forms.DataGridView dgvMobileUserAgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CMenuDeletePCRule;
        private System.Windows.Forms.ToolStripMenuItem CMenuSavePCRule;
        private System.Windows.Forms.ToolStripMenuItem CMenuLoadPCRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn SearchKeys;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitSecsMinInSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitSecsMaxInSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductKeys;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitSecsMinInProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitSecsMaxInProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceKeys;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitSecsMinInPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitSecsMaxInPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comUserAgentChangeMode;
        private System.Windows.Forms.ComboBox comVisitRuleType;
        private System.Windows.Forms.Label label2;
    }
}

