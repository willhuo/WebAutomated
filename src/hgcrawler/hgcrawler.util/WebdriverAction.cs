using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hgcrawler.util
{
    public class WebdriverAction: IWebdriverAction
    {
        public WebdriverAction()
        {
        }

        /// <summary>
        /// 访问URL地址
        /// </summary>
        /// <param name="url"></param>
        /// <param name="webDriver"></param>
        /// <returns></returns>
        public bool GotoUrl(string url, IWebDriver webDriver)
        {
            try
            {
                webDriver.Navigate().GoToUrl(url);
                Log.Information("visit url {0} success",url);
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

        /// <summary>
        /// 根据xpath规则查找元素并进行点击
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="webDriver"></param>
        /// <returns></returns>
        public bool DoClick(string xpath,IWebDriver webDriver)
        {
            try
            {
                var ele = webDriver.FindElements(By.XPath(xpath))?.First();
                if (ele == null)
                {
                    Serilog.Log.Warning("find element by xpath:{0} failed", xpath);
                    return false;
                }

                ele.Click();
                Serilog.Log.Information("click element by xpath:{0} success", xpath);
                return true;
            }
            catch(Exception ex)
            {
                Serilog.Log.Error(ex, "DoClick error");
                return false;
            }
        }

        /// <summary>
        /// 根据ID查找元素并进行点击
        /// </summary>
        /// <param name="id"></param>
        /// <param name="webDriver"></param>
        /// <returns></returns>
        public bool DoClickById(string id, IWebDriver webDriver)
        {
            try
            {
                var ele = webDriver.FindElement(By.Id(id));
                if (ele == null)
                {
                    Serilog.Log.Warning("find element by id {0} failed", id);
                    return false;
                }

                ele.Click();
                Serilog.Log.Information("click element by id {0} success", id);
                return true;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "DoClickById error");
                return false;
            }
        }

        /// <summary>
        /// 根据指定的xpath查找元素并发送按键
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="xpath"></param>
        /// <param name="webDriver"></param>
        /// <param name="delayMilliSecs"></param>
        /// <returns></returns>
        public bool SendKeys(string keys,string xpath, IWebDriver webDriver,int delayMilliSecs=2000)
        {
            try
            {
                var ele = webDriver.FindElements(By.XPath(xpath))?.First();
                if (ele == null)
                {
                    Serilog.Log.Warning("find element failed by xpath:{0}", xpath);
                    return false;
                }

                ele.SendKeys(keys);
                Serilog.Log.Information("send keys {0} by element xpath {1} success", keys, xpath);
                Thread.Sleep(delayMilliSecs);
                return true;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "SendKeys error");
                return false;
            }
        }

        /// <summary>
        /// 查找指定的元素ID并发送按键
        /// </summary>
        /// <param name="id"></param>
        /// <param name="xpath"></param>
        /// <param name="webDriver"></param>
        /// <param name="delayMilliSecs"></param>
        /// <returns></returns>
        public bool SendKeysById(string keys, string id, IWebDriver webDriver, int delayMilliSecs = 2000)
        {
            try
            {
                var ele = webDriver.FindElement(By.Id(id));
                if (ele == null)
                {
                    Serilog.Log.Warning("find element failed by id:{0}", id);
                    return false;
                }

                ele.SendKeys(keys);
                Serilog.Log.Information("send keys {0} by element id {1} success", keys, id);
                Thread.Sleep(delayMilliSecs);
                return true;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "SendKeysById error");
                return false;
            }
        }

        /// <summary>
        /// 获取dom页面内容
        /// </summary>
        /// <param name="webDriver"></param>
        /// <returns></returns>
        public string GetPage(IWebDriver webDriver)
        {
            try
            {
                var page = webDriver.PageSource;
                if (string.IsNullOrEmpty(page))
                {
                    Serilog.Log.Warning("get dom content failed");
                    return string.Empty;
                }

                Serilog.Log.Information("get dom content success");
                return page;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "GetPage error");
                return string.Empty;
            }
        }

        /// <summary>
        /// 根据xpath获取元素
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="webElement"></param>
        /// <returns></returns>
        public IWebElement GetElementByXpath(string xpath, IWebElement webElement)
        {
            try
            {
                var ele = webElement.FindElement(By.XPath(xpath));
                if (ele == null)
                {
                    Serilog.Log.Warning("find element by xpath {0} failed", xpath);
                    return null;
                }
                else
                {
                    Serilog.Log.Information("find element by xpath {0} success", xpath);
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

        /// <summary>
        /// 滚动到指定的元素位置
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="webDriver"></param>
        /// <param name="waitMiliSec"></param>
        /// <param name="step"></param>
        /// <param name="offsetY"></param>
        /// <returns></returns>
        public bool ScrollToElement(IWebElement webElement,IWebDriver webDriver,int waitMiliSec=5000,int step=50,int offsetY=400)
        {
            try
            {
                var y = webElement.Location.Y;
                var scrollToY = webElement.Location.Y - offsetY;
                var times = (int)Math.Ceiling(1.0 * scrollToY / step);
                if (times == 0)
                {
                    Serilog.Log.Information("element is visable in current window,no need to scroll");
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
                    Serilog.Log.Warning("element position changed after scroll operation:{0}-->{1}，ready to scroll again", y, webElement.Location.Y);
                    return ScrollToElement(webElement, webDriver, waitMiliSec, step, offsetY);
                }
                else
                {
                    Serilog.Log.Information("scroll to element success");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "ScrollToElement error");
                return false;
            }
        }

        /// <summary>
        /// 滚动到页面底部
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="webDriver"></param>
        /// <param name="clientHeight"></param>
        /// <param name="waitMiliSec"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public bool ScrollDown(IWebElement webElement, IWebDriver webDriver, int clientHeight, int waitMiliSec = 5000, int step = 50)
        {
            try
            {

                IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
                var scrollHeight = Convert.ToInt32(js.ExecuteScript("return window.document.body.scrollHeight;"));
                var height = scrollHeight - clientHeight;

                var times = (int)Math.Ceiling(1.0 * height / step);
                var waitSecStep = waitMiliSec / times;


                for (int i = 1; i <= times; i++)
                {
                    js.ExecuteScript("window.scrollTo(0," + step * i + ");");
                    Thread.Sleep(waitSecStep);
                }
                Serilog.Log.Information("scroll down success");
                Thread.Sleep(1000);
                return true;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "ScrollDown error");
                return false;
            }
        }

        /// <summary>
        /// 获取内容窗体高度
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="clientHeight"></param>
        /// <returns></returns>
        public bool GetClientHeight(IWebDriver webDriver,out int clientHeight)
        {
            clientHeight = 0;
            try
            {                
                Serilog.Log.Information("ready to get client height");
                IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
                clientHeight = Convert.ToInt32(js.ExecuteScript("return window.document.body.clientHeight;"));
                var browserWindowHeight = webDriver.Manage().Window.Size.Height;
                if (clientHeight > browserWindowHeight)
                    clientHeight = browserWindowHeight - 100;                

                if (clientHeight == 0)
                {                    
                    Serilog.Log.Information("get content window height failed");
                    return false;
                }
                else
                {
                    Serilog.Log.Information("content window height:{0}", clientHeight);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "GetClientHeight error");
                return false;
            }
        }
    }
}
