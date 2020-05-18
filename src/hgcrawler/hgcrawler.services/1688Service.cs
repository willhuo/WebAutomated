using hgcrawler.rules;
using hgcrawler.util;
using Microsoft.Extensions.Hosting;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace hgcrawler.services
{
    public class _1688Service : BackgroundService,IDisposable
    {
        IDriverHelper driverHelper { get; set; }
        IWebdriverAction webdriverAction { get; set; }
        IWebDriver webDriver { get; set; }

        public _1688Service(IDriverHelper driver, IWebdriverAction webdriverAction)
        {
            this.driverHelper = driver;
            this.webdriverAction = webdriverAction;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() => Run());
        }


        /// <summary>
        /// 初始化chromedriver
        /// </summary>
        private bool InitWebdriver()
        {
            webDriver = driverHelper.StartDriver();
            if (webDriver == default)
            {
                Serilog.Log.Warning("webdriver 初始化失败");
                return false;
            }
            else
            {
                Serilog.Log.Information("webdriver 初始化成功");
                return true;
            }
        }

        /// <summary>
        /// 识别商品图片
        /// </summary>
        /// <param name="ele"></param>
        /// <returns></returns>
        private string GetImgUrl(IWebElement ele)
        {
            var imgUrlBlock = ele.GetAttribute("style");
            var imgUrl = Regex.Match(imgUrlBlock, "https[^;]+").ToString();
            return imgUrl;
        }

        /// <summary>
        /// 识别标题
        /// </summary>
        /// <param name="ele"></param>
        /// <returns></returns>
        private string GetTitle(IWebElement ele)
        {
            return ele.Text;
        }

        /// <summary>
        /// 识别价格信息
        /// </summary>
        /// <param name="ele"></param>
        /// <returns></returns>
        private string GetPrice(IWebElement ele)
        {
            return ele.Text;
        }

        /// <summary>
        /// 解析商品信息
        /// </summary>
        /// <param name="eles"></param>
        private void ParseGoodsInfo(IReadOnlyCollection<IWebElement> eles)
        {
            int i = 0;
            foreach(var ele in eles)
            {
                i++;
                try
                {
                    string imgUrl = string.Empty;
                    string title = string.Empty;
                    string price = string.Empty;

                    //图片信息
                    var imgEle = webdriverAction.GetElementByXpath(".//div[@class='img']", ele);
                    if (imgEle != null)
                    {
                        imgUrl = GetImgUrl(imgEle);
                    }

                    //标题信息
                    var titleEle = webdriverAction.GetElementByXpath(".//div[@class='title']", ele);
                    if (titleEle != null)
                    {
                        title = GetTitle(titleEle);
                    }

                    //价格信息
                    var priceEle = webdriverAction.GetElementByXpath(".//div[@class='price']", ele);
                    if (priceEle != null)
                    {
                        price = GetPrice(priceEle);
                    }


                    Serilog.Log.Information("商品识别序号：{0}",i);
                    Serilog.Log.Information("title={0}", title);
                    Serilog.Log.Information("price={0}", price);
                    Serilog.Log.Information("imgurl={0}", imgUrl);
                    Serilog.Log.Information("----------------------------------------------");
                }
                catch(Exception ex)
                {
                    //Serilog.Log.Error(ex, "ParseGoodsInfo error");
                    Serilog.Log.Error("ParseGoodsInfo error，序号：{0}",i);
                    Serilog.Log.Information("----------------------------------------------");
                }
            }
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="ruleConfig"></param>
        /// <returns></returns>
        private bool CollectGoodsItems(_1688RuleConfig ruleConfig)
        {
            //TODO：应该进行页面循环

            //识别下一页位置
            var nextPageEle = webdriverAction.GetElementByXpath("//a[@class='fui-next']", webDriver);
            if (nextPageEle == null)
            {
                Serilog.Log.Warning("翻页元素查找失败");
                return false;
            }

            //滚动套翻页元素
            var nextPageScrollFlag= webdriverAction.ScrollToElement(nextPageEle, webDriver);
            if (!nextPageScrollFlag)
            {
                return false;
            }
            Thread.Sleep(1000);

            //获取当前页面商品列//div[@class='img]表
            var goodsItemBlocks = webdriverAction.GetEelements("//div[contains(@class,'common-offer-card')]", webDriver);
            if (goodsItemBlocks.flag == false)            
                return false;

            //识别商品信息
            ParseGoodsInfo(goodsItemBlocks.eles);

            return true;
        }

        /// <summary>
        /// 执行业务
        /// </summary>
        private void DoBusiness(_1688RuleConfig ruleConfig)
        {
            bool flag = false;

            //访问URL地址
            flag=webdriverAction.GotoUrl(ruleConfig.BeginUrl, webDriver);
            if (!flag) { return; }

            //输入关键词
            flag = webdriverAction.DoInput(ruleConfig.Keyword, "home-header-searchbox", webDriver);
            if (!flag) { return; }

            //回车进行搜索
            flag = webdriverAction.SendKeys(Keys.Enter,"//button[@class='single']", webDriver);
            if (!flag) { return; }

            //提取页面数据
            CollectGoodsItems(ruleConfig);
        }

        /// <summary>
        /// 开始运行
        /// </summary>
        private void Run()
        {
            try
            {
                //TODO:载入配置文件
                var ruleConfig = new _1688RuleConfig();

                //初始化
                if (!InitWebdriver())
                    return;

                //执行业务
                DoBusiness(ruleConfig);
            }
            catch(Exception ex)
            {
                Serilog.Log.Error(ex, "1688Service error");
                driverHelper.CloseWedriver(webDriver);
            }          
        }

        ///// <summary>
        ///// 析构函数
        ///// </summary>
        //~_1688Service()
        //{
        //    driverHelper.CloseWedriver(webDriver);
        //}
    }
}
