using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Support.UI;
using Xunit.Sdk;

namespace IntegrationSeleniumTests.Pages
{
    class TendersPage
    {
        private readonly IWebDriver _driver;
        //private const string Url = "http://localhost:3001/tender";

        private IWebElement Picker => _driver.FindElement(By.Id("picker"));
        private IWebElement StartDate => _driver.FindElement(By.Name("start"));
        private IWebElement EndDate => _driver.FindElement(By.Name("end"));
        private IWebElement UpdateButton => _driver.FindElement(By.Id("update"));
        private IWebElement Title => _driver.FindElement(By.Id("title"));


        public TendersPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void ClickUpdateButton()
        {
            UpdateButton.Click();
        }

        public void InsertStartDate(string startDate)
        {
            StartDate.SendKeys(Keys.Tab);
            StartDate.Clear();
            StartDate.SendKeys(startDate);
        }

        public void InsertEndDate(string endDate)
        {
            EndDate.SendKeys(Keys.Tab);
            EndDate.Clear();
            EndDate.SendKeys(endDate);
        }

        public void WaitToLoad()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 15));
            wait.Until(condition => Title.Text.Length != 0);
        }
        public void WaitToExecute()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 15));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            }
            catch (Exception e)
            { //Tako i treba
            }


        }
        public void Navigate(string url)
            => _driver.Navigate().GoToUrl(url);
    }
}
