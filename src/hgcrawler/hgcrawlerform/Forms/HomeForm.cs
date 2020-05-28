using Dijing.Common.Core.Utility;
using hgcrawler.common.Agents;
using hgcrawler.common.Enums;
using hgcrawler.rules;
using hgcrawler.util;
using hgcrawlerform.Datastruct;
using hgcrawlerform.Forms;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        NaverRuleConfig _naverRuleConfig { get; set; } = new NaverRuleConfig();
        List<NaverVistiRule> _naverVistiRules { get; set; } = new List<NaverVistiRule>();



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
            Start();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        

        private void InitWebdriver()
        {
            if (_driverHelper == null)
                _driverHelper = new ChromeDriverHelper();
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
            InitWebdriver();
        }




        private void SaveVisitRules()
        {
            var list = new List<NaverVistiRule>();
            int i = 0;

            var dgvRoles = dgvVisitRule.Rows;
            foreach (DataGridViewRow row in dgvRoles)
            {
                i++;
                if (i == dgvRoles.Count)
                    break;

                var rule = new NaverVistiRule();
                rule.SearchKeys = row.Cells[0].Value?.ToString();
                rule.WaitSecsMinInSearch = Convert.ToInt32(row.Cells[1].Value?.ToString());
                rule.WaitSecsMaxInSearch = Convert.ToInt32(row.Cells[2].Value?.ToString());
                rule.ProductKeys = row.Cells[3].Value?.ToString();
                rule.WaitSecsMinInProduct = Convert.ToInt32(row.Cells[4].Value?.ToString());
                rule.WaitSecsMaxInProduct = Convert.ToInt32(row.Cells[5].Value?.ToString());
                rule.PriceKeys = row.Cells[6].Value?.ToString();
                rule.WaitSecsMinInPrice = Convert.ToInt32(row.Cells[7].Value?.ToString());
                rule.WaitSecsMaxInPrice = Convert.ToInt32(row.Cells[8].Value?.ToString());

                list.Add(rule);
            }
            var pcVisitRules = JsonConvert.SerializeObject(list);

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory().Substring(0, 3);
            saveFileDialog.FileName = "visit_rule";
            saveFileDialog.Filter = "visit_rule(*.db)|*.db|All Files(*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = saveFileDialog.FileName;
                File.WriteAllText(localFilePath, pcVisitRules, Encoding.UTF8);
                Serilog.Log.Information("visit rules export success");
            }
            else
            {
                Serilog.Log.Warning("visit rules export failed");
            }
        }
        private void LoadVisitRules()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "visit rule(*.db)|*.db|All Files(*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = openFileDialog.FileName;
                var respage = File.ReadAllText(localFilePath, Encoding.UTF8);

                dgvVisitRule.Rows.Clear();
                var list = JsonConvert.DeserializeObject<List<NaverVistiRule>>(respage);

                foreach (var v in list)
                {
                    int index = this.dgvVisitRule.Rows.Add();
                    this.dgvVisitRule.Rows[index].Cells[0].Value = v.SearchKeys;
                    this.dgvVisitRule.Rows[index].Cells[1].Value = v.WaitSecsMinInSearch;
                    this.dgvVisitRule.Rows[index].Cells[2].Value = v.WaitSecsMaxInSearch;
                    this.dgvVisitRule.Rows[index].Cells[3].Value = v.ProductKeys;
                    this.dgvVisitRule.Rows[index].Cells[4].Value = v.WaitSecsMinInProduct;
                    this.dgvVisitRule.Rows[index].Cells[5].Value = v.WaitSecsMaxInProduct;
                    this.dgvVisitRule.Rows[index].Cells[6].Value = v.PriceKeys;
                    this.dgvVisitRule.Rows[index].Cells[7].Value = v.WaitSecsMinInPrice;
                    this.dgvVisitRule.Rows[index].Cells[8].Value = v.WaitSecsMaxInPrice;
                }
                Serilog.Log.Information("visit rules load success");
            }
            else
            {
                Serilog.Log.Warning("cancel load visit rules");
            }
        }
        private void DeleteVisitRules()
        {
            try
            {
                var selectedCells = this.dgvVisitRule.SelectedCells;
                foreach (DataGridViewCell cell in selectedCells)
                {
                    if (dgvVisitRule.Rows.Count - 1 == cell.RowIndex)
                    {
                        Serilog.Log.Warning("invalid row");
                        continue;
                    }

                    var row = dgvVisitRule.Rows[cell.RowIndex];
                    dgvVisitRule.Rows.Remove(row);
                    Serilog.Log.Information("{0} row delete success",cell.RowIndex);
                }

                SaveVisitRules();
            }
            catch(Exception ex)
            {
                MessageBox.Show("pls select specified rows and then delete it", "error notice");
                Serilog.Log.Error(ex, "DeleteVisitRules error");
            }
        }
        private bool CacheVisitRules()
        {
            var list = new List<NaverVistiRule>();
            int i = 0;

            var dgvRoles = dgvVisitRule.Rows;
            foreach (DataGridViewRow row in dgvRoles)
            {
                i++;
                if (i == dgvRoles.Count)
                    break;

                var rule = new NaverVistiRule();
                rule.SearchKeys = row.Cells[0].Value?.ToString();
                rule.WaitSecsMinInSearch = Convert.ToInt32(row.Cells[1].Value?.ToString());
                rule.WaitSecsMaxInSearch = Convert.ToInt32(row.Cells[2].Value?.ToString());
                rule.ProductKeys = row.Cells[3].Value?.ToString();
                rule.WaitSecsMinInProduct = Convert.ToInt32(row.Cells[4].Value?.ToString());
                rule.WaitSecsMaxInProduct = Convert.ToInt32(row.Cells[5].Value?.ToString());
                rule.PriceKeys = row.Cells[6].Value?.ToString();
                rule.WaitSecsMinInPrice = Convert.ToInt32(row.Cells[7].Value?.ToString());
                rule.WaitSecsMaxInPrice = Convert.ToInt32(row.Cells[8].Value?.ToString());

                list.Add(rule);
            }

            if (list.Count > 0)
            {
                _naverVistiRules.Clear();
                _naverVistiRules.AddRange(list);
                Serilog.Log.Information("cache visit rules success");
                return true;
            }
            else
            {
                Serilog.Log.Warning("no visit rules");
                return false;
            }
        }
        private void CacheBrowserConfig()
        {
            _naverRuleConfig.VisitRuleType = EnumHelper.GetEnumType<VisitRuleTypeEnum>(comVisitRuleType.Text);
            _naverRuleConfig.UserAgentChangeMode = EnumHelper.GetEnumType<ChangeModeEnum>(comUserAgentChangeMode.Text);
            var ruleConfigStr = JsonConvert.SerializeObject(_naverRuleConfig);

            Properties.Settings.Default.RuleConfig = ruleConfigStr;
            Properties.Settings.Default.Save();

            Serilog.Log.Information("Browser Control Config save success");
        }






        private void Start()
        {
            //缓存浏览器规则
            CacheBrowserConfig();

            //检测访问规则
            if (!CacheVisitRules())
                return;

            //获取useragetn
            var userAgent = GetUserAgent();

            //启动chromedriver
            _webDriver = _driverHelper.StartDriver(userAgent);
        }

        private string GetUserAgent()
        {
            UserAgentTypeEnum userAgentType = (_naverRuleConfig.VisitRuleType == VisitRuleTypeEnum.PC ? UserAgentTypeEnum.PCUserAgent : UserAgentTypeEnum.MobileUserAgent);

            if (_naverRuleConfig.UserAgentChangeMode == ChangeModeEnum.NoAction)
            {
                return string.Empty;
            }
            else if(_naverRuleConfig.UserAgentChangeMode==ChangeModeEnum.Single)
            {
                return _userAgentHelper.GetRandomUserAgent(userAgentType);
            }
            else
            {
                return _userAgentHelper.GetRandomUserAgent(userAgentType);
            }
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
            DeleteVisitRules();
        }
        private void CMenuSavePCRule_Click(object sender, EventArgs e)
        {
            SaveVisitRules();
        }
        private void CMenuLoadPCRule_Click(object sender, EventArgs e)
        {
            LoadVisitRules();
        }
    }
}
