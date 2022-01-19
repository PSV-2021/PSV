using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationSeleniumTests.Pages
{
    public class DrugsConsumptionReportPage
    {
        private readonly IWebDriver _driver;

        private IWebElement Range => _driver.FindElement(By.Id("range"));
        private IWebElement StartDate => _driver.FindElement(By.Name("start"));
        private IWebElement EndDate => _driver.FindElement(By.Name("end"));
        private IWebElement GenerateButton => _driver.FindElement(By.Id("generateReport"));

        public DrugsConsumptionReportPage(IWebDriver driver)
        {
            _driver = driver;
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

        public void ClickGenerateButton()
        {
            GenerateButton.Click();
        }

        public void WaitToExecute()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 15));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            }
            catch (Exception e)
            {

            }
        }

        public void Navigate(string url)
            => _driver.Navigate().GoToUrl(url);
    }
}
