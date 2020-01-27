using AnselmeWebtest.Structure;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

// Teste de comentário 2

namespace AnselmeWebtest.Pageobjects
{
    internal class AngularPageobject : Pageobject
    {
        public AngularPageobject(IConfiguration configuration, Browser browser, bool showBrowser = false) 
            : base(configuration, browser, showBrowser)
        {
        }


        public void ChangeHello(string inputText)
        {
	    // Set data on input that changes hello message
            By inputSearch = By.CssSelector(".ng-pristine:nth-child(2)");
            Driver.SetText(inputSearch, inputText);

	    // Get hello message after changes by this method to verify if it happens correctly
            By helloLocation = By.XPath("//div[2]/div/h1");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Timeout));
            wait.Until(d => d.FindElement(helloLocation) != null);
        }

        // Method that returns the Hello message
        public string GetHello()
        {
            By hello = By.XPath("//div[2]/div/h1");
            return Driver.GetText(hello);
        }

    }
}
