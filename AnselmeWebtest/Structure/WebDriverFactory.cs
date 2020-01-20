using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AnselmeWebtest.Structure
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browser browser, string driverPath, bool showBrowser, DriverOptions options = null)
        {
            IWebDriver webDriver = null;
            bool headless = !showBrowser;

            switch (browser)
            {
                case Browser.Firefox:
                    if (options == null) options = new FirefoxOptions();
                    if (headless) ((FirefoxOptions)options).AddArgument("--headless");
                    webDriver = new FirefoxDriver(driverPath, (FirefoxOptions)options);
                    break;

                case Browser.Opera:
                    throw new NotImplementedException();
                    

                case Browser.InternetExplorer:
                    throw new NotImplementedException();
                    

                case Browser.Chrome:
                    if (options == null) options = new ChromeOptions();
                    if (headless) ((ChromeOptions)options).AddArgument("--headless");
                    webDriver = new ChromeDriver(driverPath, (ChromeOptions)options);
                    break;

                case Browser.Edge:
                    if (options == null) options = new EdgeOptions();
                    if (headless) throw new ArgumentException("Edge do not have headless mode.");
                    webDriver = new EdgeDriver(driverPath, (EdgeOptions)options);
                    break;

                case Browser.Safari:
                    throw new NotImplementedException();
                    

                case Browser.Brave:
                    throw new NotImplementedException();
                    

                default:
                    throw new NotImplementedException();
                    
            }

            return webDriver;
        }

    }
}