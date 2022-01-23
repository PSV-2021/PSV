using IntegrationSeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationSeleniumTests
{
    public class ChartsUpdatingTest
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
            TendersPage.Navigate(Configuration.TendersPageUrl);
        }

        [Fact]
        public void SendSuccessfulRequest()
        {
            TendersPage.InsertStartDate("11/11/2021");
            TendersPage.InsertEndDate("01/01/2022");
            TendersPage.ClickUpdateButton();
            TendersPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Your drugstore tender chart has been updated successfully !", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.TendersPageUrl);
            Dispose();
        }

        [Fact]
        public void EndBeforeStart()
        {
            TendersPage.InsertStartDate("11/11/2021");
            TendersPage.InsertEndDate("01/11/2021");
            TendersPage.ClickUpdateButton();
            TendersPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Report can't be updated for this date range. Please, pick a valid date range.", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.TendersPageUrl);
            Dispose();
        }

        [Fact]
        public void BadEndDate()
        {
            TendersPage.InsertStartDate("11/11/2021");
            TendersPage.InsertEndDate("01/11/2");
            TendersPage.ClickUpdateButton();
            TendersPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Report can't be updated for this date range. Please, pick a valid date range.", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.TendersPageUrl);
            Dispose();
        }

        [Fact]
        public void BadStartDate()
        {
            TendersPage.InsertStartDate("05/0");
            TendersPage.InsertEndDate("01/11/2021");
            TendersPage.ClickUpdateButton();
            TendersPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Report can't be updated for this date range. Please, pick a valid date range.", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.TendersPageUrl);
            Dispose();
        }

        [Fact]
        public void NoStartDate()
        {
            TendersPage.InsertStartDate("");
            TendersPage.InsertEndDate("01/11/2021");
            TendersPage.ClickUpdateButton();
            TendersPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Report can't be updated for this date range. Please, pick a valid date range.", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.TendersPageUrl);
            Dispose();
        }

        [Fact]
        public void NoEndDate()
        {
            TendersPage.InsertStartDate("11/11/2021");
            TendersPage.InsertEndDate("");
            TendersPage.ClickUpdateButton();
            TendersPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Report can't be updated for this date range. Please, pick a valid date range.", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.TendersPageUrl);
            Dispose();
        }

        [Fact]
        public void NoDate()
        {
            TendersPage.InsertStartDate("");
            TendersPage.InsertEndDate("");
            TendersPage.ClickUpdateButton();
            TendersPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Report can't be updated for this date range. Please, pick a valid date range.", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.TendersPageUrl);
            Dispose();
        }


    }
}
