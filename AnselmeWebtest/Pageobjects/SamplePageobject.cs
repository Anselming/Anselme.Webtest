using AnselmeWebtest.Structure;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnselmeWebtest.Pageobjects
{
    internal class WikipediaPageobject : Pageobject
    {
        public WikipediaPageobject(IConfiguration configuration, Browser browser, bool showBrowser = false) 
            : base(configuration, browser, showBrowser)
        {
        }

        public void DoSearch(string inputText)
        {
            By inputSearch = By.Id("searchInput");
            Driver.SetText(inputSearch, inputText);
            Driver.Submit(inputSearch);

            By elementToSeeInDestinationPage = By.Id("firstHeading");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Timeout));
            wait.Until(d => d.FindElement(elementToSeeInDestinationPage) != null);
        }

        public string GetHeading()
        {
            By heading = By.Id("firstHeading");
            return Driver.GetText(heading);
        }

    }
}
