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
            this.dgvPCVisitRule = new System.Windows.Forms.DataGridView();
            this.SearchKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SectionMorePageWaitSec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductListWaitSec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPriceListWaitSec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dgvPCUserAgent = new System.Windows.Forms.DataGridView();
            this.UserAgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMobileUserAgent = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPCVisitRule)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPCUserAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobileUserAgent)).BeginInit();
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
            this.startToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
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
            this.sysLogToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.sysLogToolStripMenuItem.Text = "SysLog";
            this.sysLogToolStripMenuItem.Click += new System.EventHandler(this.sysLogToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
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
            this.labPublicIP.Location = new System.Drawing.Point(203, 34);
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
            this.tabPage3.Controls.Add(this.dgvPCVisitRule);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(778, 256);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Web Visit Rules";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvPCVisitRule
            // 
            this.dgvPCVisitRule.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPCVisitRule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPCVisitRule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SearchKey,
            this.SectionMorePageWaitSec,
            this.ProductKey,
            this.ProductListWaitSec,
            this.PriceKey,
            this.ProductPriceListWaitSec,
            this.State});
            this.dgvPCVisitRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPCVisitRule.Location = new System.Drawing.Point(3, 3);
            this.dgvPCVisitRule.Name = "dgvPCVisitRule";
            this.dgvPCVisitRule.RowHeadersWidth = 51;
            this.dgvPCVisitRule.Size = new System.Drawing.Size(772, 250);
            this.dgvPCVisitRule.TabIndex = 1;
            this.dgvPCVisitRule.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPCVisitRule_CellEndEdit);
            this.dgvPCVisitRule.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPCVisitRule_RowPostPaint);
            // 
            // SearchKey
            // 
            this.SearchKey.HeaderText = "搜索关键词";
            this.SearchKey.MinimumWidth = 6;
            this.SearchKey.Name = "SearchKey";
            // 
            // SectionMorePageWaitSec
            // 
            this.SectionMorePageWaitSec.HeaderText = "耗时";
            this.SectionMorePageWaitSec.MinimumWidth = 6;
            this.SectionMorePageWaitSec.Name = "SectionMorePageWaitSec";
            this.SectionMorePageWaitSec.Width = 60;
            // 
            // ProductKey
            // 
            this.ProductKey.HeaderText = "产品关键词";
            this.ProductKey.MinimumWidth = 6;
            this.ProductKey.Name = "ProductKey";
            // 
            // ProductListWaitSec
            // 
            this.ProductListWaitSec.HeaderText = "耗时";
            this.ProductListWaitSec.MinimumWidth = 6;
            this.ProductListWaitSec.Name = "ProductListWaitSec";
            this.ProductListWaitSec.Width = 60;
            // 
            // PriceKey
            // 
            this.PriceKey.HeaderText = "价格关键词";
            this.PriceKey.MinimumWidth = 6;
            this.PriceKey.Name = "PriceKey";
            // 
            // ProductPriceListWaitSec
            // 
            this.ProductPriceListWaitSec.HeaderText = "耗时";
            this.ProductPriceListWaitSec.MinimumWidth = 6;
            this.ProductPriceListWaitSec.Name = "ProductPriceListWaitSec";
            this.ProductPriceListWaitSec.Width = 60;
            // 
            // State
            // 
            this.State.HeaderText = "状态";
            this.State.MinimumWidth = 6;
            this.State.Name = "State";
            this.State.Width = 60;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.radioButton2);
            this.tabPage4.Controls.Add(this.radioButton1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(778, 256);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Webbrowser Control";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(54, 56);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(145, 56);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPCVisitRule)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPCUserAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobileUserAgent)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvPCVisitRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn SearchKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn SectionMorePageWaitSec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductListWaitSec;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductPriceListWaitSec;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
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
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

