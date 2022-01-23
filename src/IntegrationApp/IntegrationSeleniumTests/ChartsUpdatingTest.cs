using IntegrationSeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationSeleniumTests
{
    class ChartsUpdatingTest
    {
        private readonly IWebDriver Driver;
        private TendersPage TendersPage;
        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
        public ChartsUpdatingTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArgument("--disable-popup-blocking");
            options.AddArguments("--no-sandbox");
            //options.AddArguments("--disable-notifications");

            Driver = new ChromeDriver(options);
            TendersPage = new TendersPage(Driver);
            TendersPage.Navigate(Configuration.DrugPurchasePageUrl);
        }
    }
}
