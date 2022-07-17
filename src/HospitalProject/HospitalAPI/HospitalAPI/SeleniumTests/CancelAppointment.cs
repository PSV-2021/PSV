using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SeleniumTests
{
    public class CancelAppointment
    {
        private readonly IWebDriver Driver;
        private MedicalRecordPage MedicalRecordPage;
        private LoginPage LoginPage;

        public CancelAppointment()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            Driver = new ChromeDriver(options);
            LoginPage = new LoginPage(Driver);
            LoginPage.Navigate();
            LoginPage.InsertUsername("mici97");
            LoginPage.InsertPassword("mici789");
            LoginPage.ClickLogin();

            MedicalRecordPage = new MedicalRecordPage(Driver);
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        [Fact]
        public void Cancel_Appointment()
        {
            MedicalRecordPage.WaitToLoad();
            Assert.True(MedicalRecordPage.CancelButtonDisplayed());
            MedicalRecordPage.ClickCancel();
            MedicalRecordPage.WaitText();
            Assert.True(MedicalRecordPage.CancelTextDisplayed());
            Assert.Equal(Driver.Url, Configurations.MedicalRecordUrl);            
            Dispose();
        }
    }
}
