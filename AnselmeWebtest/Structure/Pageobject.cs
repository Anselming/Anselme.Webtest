using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnselmeWebtest.Structure
{
    public abstract class Pageobject : IDisposable
    {
        #region Pageobject: Properties and Attributes

        public IConfiguration Configuration { get; private set; }
        public Browser Browser { get; private set; }
        public IWebDriver Driver { get; private set; }
        public double Timeout { get; private set; }

        #endregion

        #region Pageobject: Constructors

        public Pageobject(IConfiguration configuration, Browser browser, bool showBrowser = false)
        {
            Configuration = configuration;
            Browser = browser;

            string driverPath = string.Empty;
            switch (browser)
            {
                case Browser.Firefox:
                    driverPath = Configuration.GetSection("Selenium:FirefoxDriver").Value;
                    break;
                case Browser.Opera:
                    driverPath = Configuration.GetSection("Selenium:OperaDriver").Value;
                    break;
                case Browser.InternetExplorer:
                    driverPath = Configuration.GetSection("Selenium:InternetexplorerDriver").Value;
                    break;
                case Browser.Chrome:
                    driverPath = Configuration.GetSection("Selenium:ChromeDriver").Value;
                    break;
                case Browser.Edge:
                    driverPath = Configuration.GetSection("Selenium:EdgeDriver").Value;
                    break;
                case Browser.Safari:
                    driverPath = Configuration.GetSection("Selenium:SafariDriver").Value;
                    break;
                case Browser.Brave:
                    driverPath = Configuration.GetSection("Selenium:BraveDriver").Value;
                    break;
                default:
                    break;
            }

            Driver = WebDriverFactory.CreateWebDriver(browser, driverPath, showBrowser);
            Timeout = double.Parse(Configuration.GetSection("Selenium:Timeout").Value);
        }

        #endregion

        #region Pageobject: Methods

        public virtual void LoadPage(string url)
        {
            Driver.LoadPage(TimeSpan.FromSeconds(Timeout), url);
        }

        public virtual void CloseBrowser()
        {
            Driver.Quit();
            Driver = null;
        }

        public void Dispose()
        {
            CloseBrowser();
        }

        #endregion
    }
}
