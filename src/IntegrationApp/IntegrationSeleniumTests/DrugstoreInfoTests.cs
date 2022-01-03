using System;
using IntegrationSeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace IntegrationSeleniumTests
{
    public class DrugstoreInfoTests : IDisposable
    {
        private readonly IWebDriver Driver;
        private DrugstorePage DrugstorePage;

        public DrugstoreInfoTests()
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
            DrugstorePage = new DrugstorePage(Driver);
            DrugstorePage.Navigate();
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        [Fact]
        public void IsDrugstoreLoadCorrect()
        {
            DrugstorePage.WaitToLoad();
            Assert.Equal(Driver.Url, DrugstorePage.GetUrl());
            Assert.Equal("Apoteka prva", DrugstorePage.GetTitle());
            Assert.Equal("Tolstojeva 5, Novi Sad", DrugstorePage.GetAddress());
            Dispose();
        }

        [Fact]
        public void NewCommentSet()
        {
            DrugstorePage.WaitToLoad();
            DrugstorePage.InsertComment("Ovo je test komentar");
            DrugstorePage.ClickChangeButton();
            DrugstorePage.WaitToExecute();

            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Drugstore info updated succesfully!", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, DrugstorePage.GetUrl());
            Assert.Equal("Apoteka prva", DrugstorePage.GetTitle());
            Assert.Equal("Tolstojeva 5, Novi Sad", DrugstorePage.GetAddress());
            Assert.Equal("Ovo je test komentar", DrugstorePage.GetComment());

            Dispose();
        }
    }
}
