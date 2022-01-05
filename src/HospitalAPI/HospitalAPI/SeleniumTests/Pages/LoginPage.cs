using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTests.Pages
{
    class LoginPage
    {
        private readonly IWebDriver Driver;
        private IWebDriver driver;
        public const string URI = "http://localhost:4200/login";

        private IWebElement UsernameElement => Driver.FindElement(By.Id("username"));
        private IWebElement PasswordElement => Driver.FindElement(By.Id("password"));
        private IWebElement Login => Driver.FindElement(By.Id("login"));

        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void InsertUsername(string text) => UsernameElement.SendKeys(text);
        public void InsertPassword(string text) => PasswordElement.SendKeys(text);

        public void ClickLogin()
        {
            Login.Click();
        }
        public void WaitToLoad()
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
            wait.Until(condition => Login.Displayed
                );
        }

        public bool LoginButtonDisplayed()
        {
            return Login.Displayed;
        }
        public bool UsernameInputDisplayed()
        {
            return UsernameElement.Displayed;
        }
        public bool PasswordInputDisplayed()
        {
            return PasswordElement.Displayed;
        }
        public void Navigate()
          => Driver.Navigate().GoToUrl(URI);
    }
}
