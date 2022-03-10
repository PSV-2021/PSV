using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SeleniumTests
{
    public class Test_cs
    {
        RemoteWebDriver driver;
        public Test_cs()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");
            Uri grid = new Uri("http://selenium:4444/wd/hub");
            driver = new RemoteWebDriver(grid, options);
            
        }
        [Fact]
        public void testTEst() {
            driver.Navigate().GoToUrl("https://www.bing.com");
            driver.Quit();
        }
        
    }
}
