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
    public class WikipediaWebtest
    {
        IConfiguration _configuration;
        public WikipediaWebtest()
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
        [InlineData(Browser.Chrome, "Flamengo")]
        [InlineData(Browser.Chrome, "Brasil")]
        [InlineData(Browser.Chrome, "Teste")]
        [InlineData(Browser.Firefox, "Flamengo")]
        [InlineData(Browser.Firefox, "Brasil")]
        [InlineData(Browser.Firefox, "Teste")]
        public void SerachTestInWikipedia(Browser browser, string searchTerm)
        {
            using (WikipediaPageobject pageobject = new WikipediaPageobject(_configuration, browser, true))
            {
                string actual = string.Empty;
                string expected = searchTerm;

                pageobject.LoadPage("https://pt.wikipedia.org");
                pageobject.DoSearch(expected);
                actual = pageobject.GetHeading();

                Assert.Equal(expected, actual);
            }
        }
    }
}
