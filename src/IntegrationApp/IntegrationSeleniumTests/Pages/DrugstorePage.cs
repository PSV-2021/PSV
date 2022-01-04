using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Support.UI;
using Xunit.Sdk;

namespace IntegrationSeleniumTests.Pages
{
    public class DrugstorePage
    {
        private readonly IWebDriver _driver;
        //private const string Url = "http://localhost:3001/drugstore/1";

        private IWebElement Title => _driver.FindElement(By.Id("title"));
        private IWebElement Address => _driver.FindElement(By.Id("address"));
        private IWebElement Comment => _driver.FindElement(By.Id("comment"));
        private IWebElement ChangeButton => _driver.FindElement(By.Id("change"));

        public DrugstorePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void InsertComment(string text)
        {
            Comment.SendKeys(Keys.Tab);
            Comment.Clear();
            Comment.SendKeys(text);
        }

        public void ClickChangeButton()
        {
            ChangeButton.Click();
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
        public bool CommentInputDisplayed()
        {
            return Comment.Displayed;
        }

        public string GetTitle()
        {
            return Title.Text;
        }

        public string GetAddress()
        {
            return Address.Text;
        }

        public string GetComment()
        {
            return Comment.GetAttribute("value");
        }

        public void Navigate(string url)
            => _driver.Navigate().GoToUrl(url);
    }
}
