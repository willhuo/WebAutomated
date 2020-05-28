using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace hgcrawler.util
{
    public class WebdriverAction: IWebdriverAction
    {
        public WebdriverAction()
        {
        }

        public bool GotoUrl(string url, IWebDriver webDriver)
        {
            try
            {
                webDriver.Navigate().GoToUrl(url);
                Log.Information("URL：{0} visit finish",url);
                Thread.Sleep(2000);
                return true;
            }
            catch(Exception ex)
            {
                Serilog.Log.Error(ex, "GotoUrl error");
                return false;
            }
        }

        public bool DoInput(string content, string id,IWebDriver webDriver)
        {
            try
            {
                var ele= webDriver.FindElement(By.Id(id));
                if (ele == null)
                {
                    Serilog.Log.Warning("元素ID:{0}，查找失败",id);
                    return false;
                }

                ele.SendKeys(content);
                Serilog.Log.Information("元素ID:{0}，输入内容“{1}”完成", id, content);
                return true;
            }
            catch(Exception ex)
            {
                Serilog.Log.Error(ex, "DoInput error");
                return false;
            }
        }

        public bool DoClick(string xpath,IWebDriver webDriver)
        {
            try
            {
                var ele = webDriver.FindElements(By.XPath("//button[@class='single']"))?.First();
                if (ele == null)
                {
                    Serilog.Log.Warning("元素xpath:{0}，查找失败", xpath);
                    return false;
                }

                ele.Click();
                Serilog.Log.Information("元素xpath:{0}，点击完成", xpath);
                return true;
            }
            catch(Exception ex)
            {
                Serilog.Log.Error(ex, "DoClick error");
                return false;
            }
        }

        public bool SendKeys(string keys,string xpath, IWebDriver webDriver,int delayMilliSecs=2000)
        {
            try
            {
                var ele = webDriver.FindElements(By.XPath("//button[@class='single']"))?.First();
                if (ele == null)
                {
                    Serilog.Log.Warning("元素xpath:{0}，查找失败", xpath);
                    return false;
                }

                ele.SendKeys(keys);
                Serilog.Log.Information("元素xpath:{0}，发送按键{1}完成", xpath, keys);
                Thread.Sleep(delayMilliSecs);
                return true;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "DoClick error");
                return false;
            }
        }

        public string GetPage(IWebDriver webDriver)
        {
            try
            {
                var page = webDriver.PageSource;
                if (string.IsNullOrEmpty(page))
                {
                    Serilog.Log.Warning("DOM内容获取失败");
                    return string.Empty;
                }

                Serilog.Log.Information("DOM内容获取成功");
                return page;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "GetPage error");
                return string.Empty;
            }
        }

        public IWebElement GetElementByXpath(string xpath,IWebElement webElement)
        {
            try
            {
                var ele = webElement.FindElement(By.XPath(xpath));
                if (ele==null)
                {
                    Serilog.Log.Warning("元素xpath:{0}，查找失败", xpath);
                    return null;
                }
                else
                {
                    Serilog.Log.Information("元素xpath:{0},查找成功", xpath);
                    return ele;
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "GetElementByXpath error");
                return null;
            }
        }

        public IWebElement GetElementByXpath(string xpath, IWebDriver webDriver)
        {
            try
            {
                var ele = webDriver.FindElement(By.XPath(xpath));
                if (ele == null)
                {
                    Serilog.Log.Warning("元素xpath:{0}，查找失败", xpath);
                    return null;
                }
                else
                {
                    Serilog.Log.Information("元素xpath:{0},查找成功", xpath);
                    return ele;
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "GetElementByXpath error");
                return null;
            }
        }

        public (bool flag,IReadOnlyCollection<IWebElement> eles) GetEelements(string xpath, IWebDriver webDriver)
        {
            try
            {
                var eles = webDriver.FindElements(By.XPath(xpath));
                if (eles==null|| eles.Count==0)
                {
                    Serilog.Log.Warning("元素xpath:{0}，DOM元素列表获取失败",xpath);
                    return (false, default);
                }
                else
                {
                    Serilog.Log.Information("元素xpath:{0}，DOM元素列表获取成功，数量为：{1}", xpath, eles.Count);
                    return (true, eles);
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "GetEelements error");
                return (false, default);
            }
        }

        public bool ScrollToElement(IWebElement webElement,IWebDriver webDriver,int waitMiliSec=5000,int step=50,int offsetY=400)
        {
            try
            {
                var y = webElement.Location.Y;
                var scrollToY = webElement.Location.Y - offsetY;
                var times = (int)Math.Ceiling(1.0 * scrollToY / step);
                if (times == 0)
                {
                    Serilog.Log.Information("当前元素在视野内，无需滚动访问");
                    return true;
                }
                var waitMiliSecByStep = waitMiliSec / times;

                IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
                for (int i = 1; i <= times; i++)
                {
                    js.ExecuteScript("window.scrollTo(0," + step * i + ");");
                    Thread.Sleep(waitMiliSecByStep);
                }
                Thread.Sleep(1000);

                if (y != webElement.Location.Y)
                {
                    Serilog.Log.Warning("滚动后目标位置变更：{0}-->{1}，准备再次滚动", y, webElement.Location.Y);
                    return ScrollToElement(webElement, webDriver, waitMiliSec, step, offsetY);
                }
                else
                {
                    Serilog.Log.Information("滚动到指定元素完成");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "ScrollToElement error");
                return false;
            }
        }
    }
}
