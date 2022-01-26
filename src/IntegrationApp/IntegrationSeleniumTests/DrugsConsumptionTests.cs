using IntegrationSeleniumTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationSeleniumTests
{
    public class DrugsConsumptionTests : IDisposable
    {
        private readonly IWebDriver Driver;
        private DrugsConsumptionReportPage DrugsConsumptionReportPage;
        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        public DrugsConsumptionTests()
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
            DrugsConsumptionReportPage = new DrugsConsumptionReportPage(Driver);
            DrugsConsumptionReportPage.Navigate(Configuration.DrugConsumptionReportPageUrl);
        }

        [Fact]
        public void SendSuccessfulRequest()
        {
            DrugsConsumptionReportPage.InsertStartDate("11/11/2021");
            DrugsConsumptionReportPage.InsertEndDate("01/01/2022");
            DrugsConsumptionReportPage.ClickGenerateButton();
            DrugsConsumptionReportPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Your drug consumption report has been generated successfully !", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.DrugConsumptionReportPageUrl);
            Dispose();
        }

        [Fact]
        public void EndBeforeStart()
        {
            DrugsConsumptionReportPage.InsertStartDate("11/11/2021");
            DrugsConsumptionReportPage.InsertEndDate("01/11/2021");
            DrugsConsumptionReportPage.ClickGenerateButton();
            DrugsConsumptionReportPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Report can't be generated for this date range. Please, pick a valid date range.", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.DrugConsumptionReportPageUrl);
            Dispose();
        }

        [Fact]
        public void BadEndDate()
        {
            DrugsConsumptionReportPage.InsertStartDate("11/11/2021");
            DrugsConsumptionReportPage.InsertEndDate("01/11/2");
            DrugsConsumptionReportPage.ClickGenerateButton();
            DrugsConsumptionReportPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Report can't be generated for this date range. Please, pick a valid date range.", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.DrugConsumptionReportPageUrl);
            Dispose();
        }

        [Fact]
        public void BadStartDate()
        {
            DrugsConsumptionReportPage.InsertStartDate("05/0");
            DrugsConsumptionReportPage.InsertEndDate("01/11/2021");
            DrugsConsumptionReportPage.ClickGenerateButton();
            DrugsConsumptionReportPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Report can't be generated for this date range. Please, pick a valid date range.", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.DrugConsumptionReportPageUrl);
            Dispose();
        }

        [Fact]
        public void NoStartDate()
        {
            DrugsConsumptionReportPage.InsertStartDate("");
            DrugsConsumptionReportPage.InsertEndDate("01/11/2021");
            DrugsConsumptionReportPage.ClickGenerateButton();
            DrugsConsumptionReportPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Report can't be generated for this date range. Please, pick a valid date range.", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.DrugConsumptionReportPageUrl);
            Dispose();
        }

        [Fact]
        public void NoEndDate()
        {
            DrugsConsumptionReportPage.InsertStartDate("11/11/2021");
            DrugsConsumptionReportPage.InsertEndDate("");
            DrugsConsumptionReportPage.ClickGenerateButton();
            DrugsConsumptionReportPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Report can't be generated for this date range. Please, pick a valid date range.", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.DrugConsumptionReportPageUrl);
            Dispose();
        }

        [Fact]
        public void NoDate()
        {
            DrugsConsumptionReportPage.InsertStartDate("");
            DrugsConsumptionReportPage.InsertEndDate("");
            DrugsConsumptionReportPage.ClickGenerateButton();
            DrugsConsumptionReportPage.WaitToExecute();
            IAlert alert = Driver.SwitchTo().Alert();
            Assert.Equal("Report can't be generated for this date range. Please, pick a valid date range.", alert.Text);
            alert.Accept();
            Assert.Equal(Driver.Url, Configuration.DrugConsumptionReportPageUrl);
            Dispose();
        }
    }
}