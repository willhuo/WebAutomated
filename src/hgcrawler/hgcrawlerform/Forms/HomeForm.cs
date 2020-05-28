using hgcrawler.common.Agents;
using hgcrawler.util;
using hgcrawlerform.Datastruct;
using hgcrawlerform.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hgcrawlerform
{
    public partial class HomeForm : Form
    {
        UserAgentHelper _userAgentHelper { get; set; }
        IDriverHelper _driverHelper { get; set; }
        IWebdriverAction _webdriverAction { get; set; }
        IWebDriver _webDriver { get; set; }


        public HomeForm()
        {
            InitializeComponent();
        }
        private void HomeForm_Load(object sender, EventArgs e)
        {
            Init();
        }


        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStart_Click(null, null);
        }
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStop_Click(null, null);
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void sysLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SysConfig.LogForm.Show();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {

        }
        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        

        private void InitWebdriverAction()
        {
            if (_webdriverAction == null)
                _webdriverAction = new WebdriverAction();
        }
        private void InitUserAgent()
        {
            if(_userAgentHelper==null)
            {
                _userAgentHelper = new UserAgentHelper();

                //填充列表
                foreach (string line in _userAgentHelper.PCUserAgentList)
                {
                    this.dgvPCUserAgent.Rows.Add(line);
                }

                foreach (string line in _userAgentHelper.MobileUserAgentList)
                {
                    this.dgvMobileUserAgent.Rows.Add(line);
                }
            }
        }
        private void InitLog()
        {
            var logForm = new LogForm();
            SysConfig.LogForm = logForm;
            logForm.Show();
            logForm.Hide();
        }
        private void InitUI()
        {
            this.Text += $"[{Application.ProductVersion}]";
        }
        private void Init()
        {
            InitUI();
            InitLog();
            Serilog.Log.Information("hgcrawler start");

            InitUserAgent();
            InitWebdriverAction();
        }







        private void Start()
        {

        }




        private void dgvVisitRule_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvVisitRule_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvVisitRule.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvVisitRule.RowHeadersDefaultCellStyle.Font, rectangle, dgvVisitRule.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        private void dgvPCUserAgent_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvPCUserAgent.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvPCUserAgent.RowHeadersDefaultCellStyle.Font, rectangle, dgvPCUserAgent.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        private void dgvMobileUserAgent_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgvMobileUserAgent.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvMobileUserAgent.RowHeadersDefaultCellStyle.Font, rectangle, dgvMobileUserAgent.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }




        private void CMenuDeletePCRule_Click(object sender, EventArgs e)
        {

        }
        private void CMenuSavePCRule_Click(object sender, EventArgs e)
        {

        }
        private void CMenuLoadPCRule_Click(object sender, EventArgs e)
        {

        }


    }
}
