using System;
using System.Collections.Generic;
using System.Text;
using IntegrationSeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace IntegrationSeleniumTests
{
    public class DrugPurchaseTests : IDisposable
    {
        private readonly IWebDriver Driver;
        private DrugPurchasePage DrugPurchasePage;
        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        public DrugPurchaseTests()
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
            DrugPurchasePage = new DrugPurchasePage(Driver);
            DrugPurchasePage.Navigate(Configuration.DrugPurchasePageUrl);
        }

        [Fact]
        public void IsDrugstoresLoadedCorrect()
        {
            DrugPurchasePage.WaitToLoad();
            Assert.Equal(Driver.Url, Configuration.DrugPurchasePageUrl);
            Dispose();
        }

        [Fact]
        public void SendSuccessfulRequest()
        {
            DrugPurchasePage.WaitToLoad();
            DrugPurchasePage.SelectOneDrugstore();
            DrugPurchasePage.InsertDrugAmount("10");
            DrugPurchasePage.InsertDrugName("Brufen");
            DrugPurchasePage.ClickRequestButton();
            DrugPurchasePage.WaitToExecute();

            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("You CAN order this drug from this drugstore.", alert.Text);
            alert.Accept();

            Assert.Equal(Driver.Url, Configuration.DrugPurchasePageUrl);
            Dispose();
        }

        [Fact]
        public void SendRequestForUnexistingDrug()
        {
            DrugPurchasePage.WaitToLoad();
            DrugPurchasePage.SelectOneDrugstore();
            DrugPurchasePage.InsertDrugAmount("10");
            DrugPurchasePage.InsertDrugName("Unexisting drug123");
            DrugPurchasePage.ClickRequestButton();
            DrugPurchasePage.WaitToExecute();

            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("You CAN'T order this drug from this drugstore.", alert.Text);
            alert.Accept();

            Assert.Equal(Driver.Url, Configuration.DrugPurchasePageUrl);
            Dispose();
        }

        [Fact]
        public void BadDrugAmountInput()
        {
            DrugPurchasePage.WaitToLoad();
            DrugPurchasePage.SelectOneDrugstore();
            DrugPurchasePage.InsertDrugAmount("10e");
            DrugPurchasePage.InsertDrugName("Some drug");
            DrugPurchasePage.ClickRequestButton();
            DrugPurchasePage.WaitToExecute();

            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Drug amount must be whole number!", alert.Text);
            alert.Accept();

            Assert.Equal(Driver.Url, Configuration.DrugPurchasePageUrl);
            Dispose();
        }

        [Fact]
        public void SuccesfullUrgentDrugPurchase()
        {
            DrugPurchasePage.WaitToLoad();
            DrugPurchasePage.SelectOneDrugstore();
            DrugPurchasePage.InsertDrugAmount("2");
            DrugPurchasePage.InsertDrugName("Brufen");
            DrugPurchasePage.ClickRequestButton();
            DrugPurchasePage.WaitToExecute();

            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("You CAN order this drug from this drugstore.", alert.Text);
            alert.Accept();

            DrugPurchasePage.ClickPurchaseButton();
            DrugPurchasePage.WaitToExecute();

            IAlert alertForPurchase = Driver.SwitchTo().Alert();
            Assert.Equal("You have successfully purchased drugs!", alertForPurchase.Text);
            alertForPurchase.Accept();

            Assert.Equal(Driver.Url, Configuration.DrugPurchasePageUrl);
            Dispose();
        }

    }
}
