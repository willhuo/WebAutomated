using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hgcrawler.util
{
    public interface IDriverHelper
    {
        IWebDriver StartDriver(string userAgent = null);
        void CloseWedriver(IWebDriver webDriver);
    }
}
