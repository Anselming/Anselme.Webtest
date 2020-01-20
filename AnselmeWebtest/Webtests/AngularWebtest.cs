using AnselmeWebtest.Pageobjects;
using AnselmeWebtest.Structure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xunit;

namespace AnselmeWebtest.Webtests
{
    public class AngularWebteste
    {
        IConfiguration _configuration;
        public AngularWebteste()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();

            // Set Brazilian Culture
            var culture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        [Theory]
        [InlineData(Browser.Chrome, "John")]
        [InlineData(Browser.Chrome, "Baltmor")]
        [InlineData(Browser.Chrome, "Smart")]
        [InlineData(Browser.Firefox, "Splash")]
        [InlineData(Browser.Firefox, "Fast")]
        [InlineData(Browser.Firefox, "Hospital")]
        public void HelloInAngular(Browser browser, string text)
        {
            using (AngularPageobject pageobject = new AngularPageobject(_configuration, browser, true))
            {
                string actual = string.Empty;
                string expected = text;

                pageobject.LoadPage("https://angularjs.org/");
                pageobject.ChangeHello(text);
                actual = pageobject.GetHello();
                expected = $"Hello {expected}!";

                Assert.Equal(expected, actual);
            }
        }
    }
}
