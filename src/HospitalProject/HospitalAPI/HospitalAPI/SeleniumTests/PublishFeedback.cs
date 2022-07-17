using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SeleniumTests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace SeleniumTests
{
    public class PublishFeedback
    {
        private readonly IWebDriver Driver;
        private CommentsPage CommentPage;
        private LoginPage LoginPage;

        public PublishFeedback()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");
            Uri grid = new Uri("http://localhost:4444/wd/hub");
            Driver = new RemoteWebDriver(grid, options);
            //Driver = new ChromeDriver(options);
            LoginPage = new LoginPage(Driver);
            LoginPage.Navigate();
            LoginPage.InsertUsername("mici97");
            LoginPage.InsertPassword("mici789");
            LoginPage.ClickLogin();

            CommentPage = new CommentsPage(Driver);
            CommentPage.Navigate();
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }


        [Fact]
        public void Cancel_Examination()
        {
            CommentPage.WaitToLoad();
            CommentPage.InsertFeedback("Extra!");
            CommentPage.InsertAnonymus(true);
            CommentPage.InsertPublishable(true);
            CommentPage.ClickSend();
            Assert.Equal(Driver.Url, Configurations.CommentsUrl);
            Assert.True(CommentPage.SendButtonDisplayed());
            Assert.True(CommentPage.FeedbackInputDisplayed());
            Dispose();
        }

        [Fact]
        public void Cancel_ExaminationAnonymus()
        {
            CommentPage.WaitToLoad();
            CommentPage.InsertFeedback("Extra!");
            CommentPage.InsertAnonymus(false);
            CommentPage.InsertPublishable(true);
            CommentPage.ClickSend();
            Assert.Equal(Driver.Url, Configurations.CommentsUrl);
            Assert.True(CommentPage.SendButtonDisplayed());
            Assert.True(CommentPage.AnonymusButtonDisplayed());
            Dispose();
        }
        [Fact]
        public void Cancel_ExaminationNotPublishable()
        {
            CommentPage.WaitToLoad();
            CommentPage.InsertFeedback("Extra!");
            CommentPage.InsertAnonymus(true);
            CommentPage.InsertPublishable(false);
            CommentPage.ClickSend();
            Assert.Equal(Driver.Url, Configurations.CommentsUrl);
            Assert.True(CommentPage.SendButtonDisplayed());
            Assert.True(CommentPage.PublishableButtonDisplayed());
            Dispose();
        }
        [Fact]
        public void Cancel_ExaminationNotPublishableAndAnonymus()
        {
            CommentPage.WaitToLoad();
            CommentPage.InsertFeedback("Extra!");
            CommentPage.InsertAnonymus(false);
            CommentPage.InsertPublishable(false);
            CommentPage.ClickSend();
            Assert.Equal(Driver.Url, Configurations.CommentsUrl);
            Assert.True(CommentPage.SendButtonDisplayed());
            Assert.True(CommentPage.PublishableButtonDisplayed());
            Dispose();
        }
    }
}
