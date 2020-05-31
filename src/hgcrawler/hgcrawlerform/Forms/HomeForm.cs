using Dijing.Common.Core.Utility;
using hgcrawler.common.Agents;
using hgcrawler.common.Enums;
using hgcrawler.common.Options;
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


        bool _isWorking { get; set; }
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

        

        private void ChangetTLabStatus(string msg)
        {
            if (btnStart.InvokeRequired)
            {
                btnStart.Invoke(new Action(() =>
                {
                    tlabStatus.Text = msg;
                }));
            }
            else
            {
                tlabStatus.Text = msg;
            }
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

            LoadBrowserConfig();
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

            _naverRuleConfig.PageMax = (int)numPageMax.Value;


            _naverRuleConfig.VisitRuleType = EnumHelper.GetEnumType<VisitRuleTypeEnum>(comVisitRuleType.Text);
            _naverRuleConfig.UserAgentChangeMode = EnumHelper.GetEnumType<ChangeModeEnum>(comUserAgentChangeMode.Text);
            var ruleConfigStr = JsonConvert.SerializeObject(_naverRuleConfig);

            Properties.Settings.Default.RuleConfig = ruleConfigStr;
            Properties.Settings.Default.Save();

            Serilog.Log.Information("Browser Control Config save success");
        }
        private void LoadBrowserConfig()
        {
            var ruleConfigStr = Properties.Settings.Default.RuleConfig;
            var ruleConfig = JsonConvert.DeserializeObject<NaverRuleConfig>(ruleConfigStr);


            numPageMax.Value = ruleConfig.PageMax;
            comVisitRuleType.Text = ruleConfig.VisitRuleType.ToString();
            comUserAgentChangeMode.Text = ruleConfig.UserAgentChangeMode.ToString();


            Serilog.Log.Information("Browser Control Config load success");
        }





        private string GetUserAgent()
        {
            UserAgentTypeEnum userAgentType = (_naverRuleConfig.VisitRuleType == VisitRuleTypeEnum.PC ? UserAgentTypeEnum.PCUserAgent : UserAgentTypeEnum.MobileUserAgent);

            if (_naverRuleConfig.UserAgentChangeMode == ChangeModeEnum.NoAction)
            {
                return string.Empty;
            }
            else if (_naverRuleConfig.UserAgentChangeMode == ChangeModeEnum.Single)
            {
                return _userAgentHelper.GetRandomUserAgent(userAgentType);
            }
            else
            {
                return _userAgentHelper.GetRandomUserAgent(userAgentType);
            }
        }
        private bool DoRule(NaverVistiRule rule)
        {
            if(_naverRuleConfig.VisitRuleType==VisitRuleTypeEnum.PC)
            {
                return DoPCRule(rule);
            }
            else
            {
                Serilog.Log.Warning("mobile rule not support currently!");
                return false;
            }
        }
        private void DoCycleRules()
        {
            //获取useragetn
            var userAgent = GetUserAgent();

            //启动chromedriver
            _webDriver = _driverHelper.StartDriver(userAgent);

            int index = 0;
            int i = 0;
            int times = 0;
            int ruleCount = _naverVistiRules.Count;            
            while (true)
            {
                try
                {
                    //循环索引
                    times = index / ruleCount;
                    i = index % ruleCount;

                    //TODO：执行清理

                    //获取规则
                    var rule = _naverVistiRules[i];

                    //执行规则
                    bool flag = DoRule(rule);
                    if(flag)                    
                        rule.SuccessCount++;
                    else                    
                        rule.FailedCount++;
                    
                    //执行结果更新
                }
                catch (Exception ex)
                {
                    Serilog.Log.Error(ex, "DoCycleRules error");
                }
            }
        }
        private void Start()
        {
            //缓存浏览器规则
            CacheBrowserConfig();

            //检测访问规则
            if (!CacheVisitRules())
                return;

            //规则循环执行
            if (_isWorking)
            {
                Serilog.Log.Warning("task is running");
                MessageBox.Show("task is running", "notice");
                return;
            }

            //启动任务线程
            Task.Run(() =>
            {
                _isWorking = true;
                ChangetTLabStatus("working");
                DoCycleRules();
            });        
        }





        private bool BrowserProductListAndVisitProduct(NaverVistiRule rule)
        {
            int currentPageNum = 0;

            //产品元素
            IWebElement product = null;


            //检测翻页是否超限
            if(currentPageNum>_naverRuleConfig.PageMax)
            {
                Serilog.Log.Warning("reach limit page max number");
                return false;
            }

            //获取页面内容
            var respage = _webdriverAction.GetPage(_webDriver);
            if (string.IsNullOrEmpty(respage))
                return false;

            //判断当前页面是包含产品关键词
            if (respage.Contains(rule.ProductKeys))
            {
                var productXpath = "//li[@data-nv-mid='" + rule.ProductKeys + "']/div[@class='info']//a";
                product = _webdriverAction.GetElementByXpath("", _webDriver);
            }

            //获取窗体高度
            if (!_webdriverAction.GetClientHeight(_webDriver, out int clientHeight))
                return false;







            try
            {
                bool flag = false;
                IWebElement product = null;

                if (_WebDriver.PageSource.Contains(_CurrentVisitRule.ProductKey))
                {
                    //此处规则变化过
                    product = _WebDriver.FindElement(By.XPath("//li[@data-nv-mid='" + _CurrentVisitRule.ProductKey + "']/div[@class='info']//a"));
                }
                else
                    LogHelper.Default.LogPrint($"当前页面不存在关键词：{_CurrentVisitRule.ProductKey}", 3);

                if (product == null)
                {
                    _CurrentPage++;
                    if (_CurrentPage >= _PCVisitControl.PageMax)
                    {
                        LogHelper.Default.LogPrint($"搜索超过最大页数，放弃继续翻页搜索", 3);
                        return false;
                    }

                    //下拉到最下边
                    ScrollDown(_CurrentVisitRule.ProductListWaitSec * 1000);

                    //进行翻页
                    flag = VisitPCNextPage();
                    if (flag == false)
                        return false;

                    //递归方式查找产品
                    flag = BrowserPCProductListAndVisitProduct();
                    if (flag == false)
                        return false;
                }
                else
                {
                    //浏览页面
                    ScrollDownAndUp(_CurrentVisitRule.ProductListWaitSec * 1000);

                    //定位到指定元素
                    ScrollToElement(_CurrentVisitRule.ProductListWaitSec * 500, product);

                    //获取产品连接并访问
                    var url = product.GetAttribute("href");
                    _WebDriver.Navigate().GoToUrl(url);
                    LogHelper.Default.LogPrint($"产品页面访问完成", 2);
                    Task.Delay(2000).Wait();

                    //检测页面是否有权访问
                    flag = AbormalPageCheck();
                    if (flag == false)
                        return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Default.LogDay($"BrowserPCProductListAndVisitProduct error,{ex}");
                LogHelper.Default.LogPrint($"BrowserPCProductListAndVisitProduct error,{ex.Message}", 4);
                return false;
            }
        }
        private bool VisitMoreProducts(NaverVistiRule rule)
        {           
            //获取页面内容
            var respage = _webdriverAction.GetPage(_webDriver);
            if (string.IsNullOrEmpty(respage))
                return false;

            //查找更多产品按钮
            IWebElement sectionMore = null;
            if (respage.Contains("쇼핑 더보기"))
            {
                sectionMore = _webdriverAction.GetElementByXpath("//a[text()='쇼핑 더보기']", _webDriver);
                if(sectionMore==null)
                {
                    Serilog.Log.Warning("find more product button failed");
                    return false;
                }
                else
                {
                    Serilog.Log.Information("find more product button success");
                }
            }
            else
            {                
                Serilog.Log.Warning("dom content can not find more product button trace");
                return false;
            }


            //提取入口URL地址
            var sectionMoreUrl = sectionMore.GetAttribute("href");
            Serilog.Log.Information("more product url:{0}",sectionMoreUrl);

            //定位到元素位置
            if (!_webdriverAction.ScrollToElement(sectionMore, _webDriver))
                return false;

            //访问更多商品地址
            if(_webdriverAction.GotoUrl(sectionMoreUrl, _webDriver))
            {
                Serilog.Log.Warning("visit more product url failed");
                return false;
            }
            {
                Serilog.Log.Information("visit more product url success");
            }


            Task.Delay(5000).Wait();
            return true;
        }
        private bool InputSearchKeyAndClick(NaverVistiRule rule)
        {
            //输入关键词
            if (!_webdriverAction.SendKeysById(rule.SearchKeys, "query", _webDriver, rule.WaitSecsInSearch))
            {
                Serilog.Log.Warning("input search key failed");
                return false;
            }
            else
            {
                Serilog.Log.Information("input search key success");
            }
            

            //点击搜索按钮
            if (!_webdriverAction.DoClickById("search_btn", _webDriver))
            {
                Serilog.Log.Warning("click search button failed");
                return false;
            }                
            else
            {
                Serilog.Log.Warning("click search button success");
                return true;
            }
        }
        private bool VisitHomePage(NaverVistiRule rule)
        {
            if (!_webdriverAction.GotoUrl(UrlEndPointsOption.EngineUrl(_naverRuleConfig.VisitRuleType), _webDriver))
            {
                Serilog.Log.Warning("home page visit failed");
                return false;
            }
            else
            {
                Serilog.Log.Information("home page visit success");
                return true;
            }
        }
        private bool DoPCRule(NaverVistiRule rule)
        {
            try
            {
                //访问主页
                if (!VisitHomePage(rule))
                    return false;

                //TODO：随机前置访问

                //输入关键词并点击搜索按钮
                if (InputSearchKeyAndClick(rule))
                    return false;

                //访问更多商品链接
                if (!VisitMoreProducts(rule))
                    return false;



                return true;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "DoRule error");
                return false;
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
