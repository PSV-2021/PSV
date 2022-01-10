using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTests.Pages
{
    public class FeedbacksPage
    {
        private readonly IWebDriver Driver;
        public const string URI = "http://localhost:3001/feedbacks";
        private IWebElement ApproveButton => Driver.FindElement(By.XPath("/html/body/app-root/main/app-feedbacks/div/div[1]/div/mat-card/mat-card-content/button/span[1]"));
        private IWebElement FirstApproveButton => Driver.FindElement(By.XPath("/html/body/app-root/main/app-feedbacks/div/div[1]/div/mat-card/mat-card-content/button/span[1]"));
        private IWebElement SecondApproveButton => Driver.FindElement(By.XPath("/html/body/app-root/main/app-feedbacks/div/div[2]/div/mat-card/mat-card-content/button/span[1]"));
        private IWebElement ThirdApproveButton => Driver.FindElement(By.XPath("/html/body/app-root/main/app-feedbacks/div/div[3]/div/mat-card/mat-card-content/button/span[1]"));

        private IWebElement ReturnButton => Driver.FindElement(By.XPath("/html/body/app-root/main/app-feedbacks/div/div[2]/div/mat-card/mat-card-content/button/span[1]"));
      

        public FeedbacksPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void ApproveFeedback() {
            ApproveButton.Click();
        }
        public void Navigate()
          => Driver.Navigate().GoToUrl(URI);

        public bool ApproveButtonDisplayed()
        {
            return ApproveButton.Text.Contains("Approve");
        }
        public bool ApproveButtonsDisplayed()
        {
            if (FirstApproveButton.Text.Contains("Approve") || SecondApproveButton.Text.Contains("Approve") || ThirdApproveButton.Text.Contains("Approve"))
                return true;
            return false;
        }

        public bool ReturnButtonDisplayed()
        {
            if (FirstApproveButton.Text.Contains("Return") || SecondApproveButton.Text.Contains("Return") || ThirdApproveButton.Text.Contains("Return"))
                return true;
            return false;
        }
        public void WaitToLoad()
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            wait.Until(condition => ApproveButton.Displayed
                );
        }
        public void ReturnButtonIsDisplayed()
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));
            wait.Until(condition =>
            {
                try
                {
                    return ReturnButton.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
    }
}
