using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationSeleniumTests.Pages
{
    public class AddTenderPage
    {
        private readonly IWebDriver _driver;

        private IWebElement TenderEndDate => _driver.FindElement(By.Name("tenderEndDate"));
        private IWebElement DrugName => _driver.FindElement(By.Name("drugName"));
        private IWebElement DrugAmount => _driver.FindElement(By.Name("drugAmount"));
        private IWebElement SaveTenderButton => _driver.FindElement(By.Id("saveTenderButton"));

        private IWebElement AddDrugButton => _driver.FindElement(By.Id("addDrugButton"));

        public AddTenderPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void InsertTenderEndDate(string date)
        {
            TenderEndDate.SendKeys(Keys.Tab);
            TenderEndDate.Clear();
            TenderEndDate.SendKeys(date);
        }
        public void ClearTenderEndate()
        {
            TenderEndDate.Clear();
        }

        public void InsertDrugName(string drugName)
        {
            DrugName.SendKeys(Keys.Tab);
            DrugName.Clear();
            DrugName.SendKeys(drugName);
        }
        public void InsertDrugAmount(string drugAmount)
        {
            DrugAmount.SendKeys(Keys.Tab);
            DrugAmount.Clear();
            DrugAmount.SendKeys(drugAmount);
        }

        public void ClickSaveTenderButton()
        {
            SaveTenderButton.Click();
        }
        public void ClickAddDrugButton()
        {
            AddDrugButton.Click();
        }

        public static IWebElement WaitForElementToAppear(IWebDriver driver, int waitTime, By waitingElement)
        {
            IWebElement wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementExists(waitingElement));
            return wait;
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
