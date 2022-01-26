using IntegrationSeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace IntegrationSeleniumTests
{
    public class AddTenderTests : IDisposable
    {
        private readonly IWebDriver Driver;
        private AddTenderPage addTenderPage;


        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
        public AddTenderTests()
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
            addTenderPage = new AddTenderPage(Driver);
            addTenderPage.Navigate(Configuration.TendersPageUrl);
        }
        
        [Fact]
        public void SendSuccessfulRequest()
        {         
            addTenderPage.InsertDrugName("Brufen");
            addTenderPage.InsertDrugAmount("20");          
            addTenderPage.ClickAddDrugButton();
            addTenderPage.ClickSaveTenderButton();
            addTenderPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Tender has been added successfully !", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.TendersPageUrl);
            Dispose();
        }
        
        
        [Fact]
        public void DuplicateDrug()
        {
            //addTenderPage.ClearTenderEndate();
            addTenderPage.InsertDrugName("Brufen");
            addTenderPage.InsertDrugAmount("20");
            addTenderPage.ClickAddDrugButton();
            addTenderPage.InsertDrugName("Brufen");
            addTenderPage.InsertDrugAmount("20");
            addTenderPage.ClickAddDrugButton();    
            addTenderPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("You have already added that drug to tender !", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.TendersPageUrl);
            Dispose();
        }
        [Fact]
        public void EndDateInvalid()
        {
            addTenderPage.ClearTenderEndate();   
            addTenderPage.InsertDrugName("Brufen");
            addTenderPage.InsertDrugAmount("20");
            addTenderPage.ClickAddDrugButton();
            addTenderPage.InsertTenderEndDate("11/11/2021");
            addTenderPage.ClickSaveTenderButton();
            addTenderPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Your tender ending date must be valid (after today) and your drug list must contain at least one drug !", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.TendersPageUrl);
            Dispose();
        }

        [Fact]
        public void NoDrugsAdded()
        {
            //addTenderPage.ClearTenderEndate();
            addTenderPage.ClickAddDrugButton();
            addTenderPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Please, fill drug name and amount with valid data !", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.TendersPageUrl);
            Dispose();
        }

    }
}
