using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IntegrationSeleniumTests.Pages
{
    public class DrugPurchasePage
    {
        private readonly IWebDriver _driver;

        private IWebElement DrugName => _driver.FindElement(By.Id("drugName"));
        private IWebElement DrugAmount => _driver.FindElement(By.Id("drugAmount"));
        private IWebElement RequestButton => _driver.FindElement(By.Id("requestButton"));
        private IWebElement PurchaseButton => _driver.FindElement(By.Id("purchaseButton"));
        private IWebElement DrugstoreBox => _driver.FindElement(By.Id("drugstores"));
        private IWebElement OneDrugstore => _driver.FindElement(By.Id("Apoteka prva"));
        private ICollection<IWebElement> Drugstores => _driver.FindElements(By.ClassName("mat-option-text"));

        public DrugPurchasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void InsertDrugName(string text)
        {
            DrugName.SendKeys(Keys.Tab);
            DrugName.Clear();
            DrugName.SendKeys(text);
        }

        public void InsertDrugAmount(string text)
        {
            DrugAmount.SendKeys(Keys.Tab);
            DrugAmount.Clear();
            DrugAmount.SendKeys(text);
        }
        public void ClickRequestButton()
        {
            RequestButton.Click();
        }
        public void ClickPurchaseButton()
        {
            PurchaseButton.Click();
        }

        public void SelectOneDrugstore()
        {
            OneDrugstore.Click();
        }

        public void WaitToLoad()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 15));
            DrugstoreBox.Click();
            wait.Until(condition => Drugstores.Count > 0);
        }

        public void WaitToExecute()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 15));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            }
            catch (Exception e)
            { }
        }

        public void Navigate(string url)
            => _driver.Navigate().GoToUrl(url);
    }
}
