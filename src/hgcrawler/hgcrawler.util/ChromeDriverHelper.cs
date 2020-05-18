using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace hgcrawler.util
{
    public class ChromeDriverHelper: IDriverHelper
    {
        public ChromeDriverHelper()
        {
        }


        public IWebDriver StartDriver()
        {
            try
            {                
                Serilog.Log.Information("starting chrome driver");

                var options = new ChromeOptions();

                //老版本隐藏自动控制的方式
                //options.AddArgument("disable-infobars");  

                //新版本隐藏自动控制的方式
                options.AddExcludedArgument("enable-automation");
                options.AddAdditionalCapability("useAutomationExtension", false);

                //TODO:useragent
                //options.AddArgument("--user-agent=" + _UserAgent);

                options.AddArguments("--disk-cache-dir=" + Directory.GetCurrentDirectory() + "\\cache");
                options.AddArgument("–incognito");//启动无痕/隐私模式
                options.AddArguments("--user-data-dir=" + Directory.GetCurrentDirectory() + "\\userdata");

                ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;

                var webDriver = new ChromeDriver(driverService, options);
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                webDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(120);
                //webDriver.Manage().Window.Size = new Size(webDriver.Manage().Window.Size.Width, webDriver.Manage().Window.Size.Height);

                Serilog.Log.Information("chrome driver start success", 2);
                return webDriver;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "StartChromeDriver error");
                return default;
            }
        }

        public void CloseWedriver(IWebDriver webDriver)
        {
            if (webDriver != null)
            {
                webDriver?.Dispose();
                webDriver?.Close();
                webDriver?.Quit();
            }
        }
    }
}
