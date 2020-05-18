using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hgcrawler.util
{
    public interface IWebdriverAction
    {
        bool GotoUrl(string url, IWebDriver webDriver);
        bool DoInput(string content, string id, IWebDriver webDriver);
        bool DoClick(string xpath, IWebDriver webDriver);
        bool SendKeys(string keys, string xpath, IWebDriver webDriver, int delayMilliSecs = 2000);
        string GetPage(IWebDriver webDriver);
        IWebElement GetElementByXpath(string xpath, IWebElement webElement);
        IWebElement GetElementByXpath(string xpath, IWebDriver webDriver);
        (bool flag, IReadOnlyCollection<IWebElement> eles) GetEelements(string xpath, IWebDriver webDriver);
        bool ScrollToElement(IWebElement webElement, IWebDriver webDriver, int waitMiliSec = 5000, int step = 50, int offsetY = 400);
    }
}
