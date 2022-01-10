using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTests.Pages
{
    public class MedicalRecordPage
    {
        private readonly IWebDriver Driver;
        public const string URI = "http://localhost:4200/medicalRecord";

        private IWebElement CancelButton => Driver.FindElement(By.XPath("/html/body/app-root/div/app-medical-record/div/div/mat-card/app-appointments-observe/table/tbody/tr[3]/td[7]/button"));
        private IWebElement CancelText => Driver.FindElement(By.XPath("/html/body/app-root/div/app-medical-record/div/div/mat-card/app-appointments-observe/table/tbody/tr[3]/td[5]//div[contains(.,'CANCELLED')]"));

        public MedicalRecordPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void ClickCancel()
        {
            CancelButton.Click();
        }
        public void WaitToLoad()
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 20));
            wait.Until(condition => CancelButton.Displayed);
        }

        public bool CancelButtonDisplayed()
        {
            try
            {
                return CancelButton.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool CancelTextDisplayed()
        {
            try
            {
                return CancelText.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void  WaitText()
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));
            wait.Until(condition => CancelText.Displayed);
        }

        public void Navigate()
          => Driver.Navigate().GoToUrl(URI);
    }
}
