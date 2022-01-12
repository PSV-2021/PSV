using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace SeleniumTests
{
    public class ManagerPublishFeedback
    {
        private readonly IWebDriver Driver;
        private FeedbacksPage FeedbackPage;
        private FeedbacksPage FeedbackDeclinePage;


        public ManagerPublishFeedback()
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

            FeedbackPage = new FeedbacksPage(Driver);
            FeedbackPage.Navigate();

            FeedbackDeclinePage = new FeedbacksPage(Driver);
            FeedbackDeclinePage.Navigate();
        }
        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
        [Fact]
        public void Approve_Feedback()
        {
            FeedbackPage.WaitToLoad();
            Assert.True(FeedbackPage.ApproveButtonDisplayed());
            FeedbackPage.ApproveFeedback();
            FeedbackPage.Navigate();
            Assert.False(FeedbackPage.ReturnButtonDisplayed());

            Assert.Equal(Driver.Url, Configurations.FeedbacksUrl);
            Dispose();
        }

        [Fact]
        public void Return_Feedback()
        {
            FeedbackDeclinePage.WaitToLoad();
            if (FeedbackDeclinePage.ReturnButtonDisplayed())
            {
                FeedbackDeclinePage.ApproveFeedback();
                FeedbackDeclinePage.Navigate();
                Assert.True(FeedbackDeclinePage.ApproveButtonsDisplayed());
            }
            Assert.Equal(Driver.Url, Configurations.FeedbacksUrl);

            Dispose();
        }
    }
}
