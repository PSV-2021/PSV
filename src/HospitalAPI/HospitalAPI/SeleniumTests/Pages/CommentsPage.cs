using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SeleniumTests.Pages
{
    public class CommentsPage
    {
        private readonly IWebDriver Driver;
        public const string URI = "http://localhost:4200/comments";

        private IWebElement FeedbackText => Driver.FindElement(By.Id("feedbackText"));
        private IWebElement StayAnonymous => Driver.FindElement(By.Id("anonymous"));
        private IWebElement Publish => Driver.FindElement(By.Id("publishCom"));
        private IWebElement SendButton => Driver.FindElement(By.Id("send"));
   

        public static readonly string ALERT_MESSAGE = "Comment sent!";
          
        public CommentsPage(IWebDriver driver)
        {
            Driver = driver;
        }
        public void InsertFeedback(string text) => FeedbackText.SendKeys(text);
        public void InsertAnonymus(bool isAnonymus)
        {
            if (isAnonymus)
            {
                StayAnonymous.Click();
            }
        }
        public void InsertPublishable(bool isPublishable)
        {
            if (isPublishable)
            {
                Publish.Click();
            }
        }

        public void ClickSend()
        {
            SendButton.Click();
        }
        public void WaitToLoad()
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
            wait.Until(condition => SendButton.Displayed
                );
        }

        public bool SendButtonDisplayed()
        {
            return SendButton.Displayed;
        }
        public bool FeedbackInputDisplayed()
        {
            return FeedbackText.Displayed;
        }
        public bool AnonymusButtonDisplayed()
        {
            return StayAnonymous.Displayed;
        }
        public bool PublishableButtonDisplayed()
        {
            return Publish.Displayed;
        }
        public void Navigate()
          => Driver.Navigate().GoToUrl(URI);
    }
}
