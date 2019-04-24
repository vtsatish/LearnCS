using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;


namespace WebDriverTests
{
    public class WSONEUITests
    {
        private IWebDriver webDriver;
        private String StartURL = "https://cnmain.ssdevrd.com";
        private String uname = "cassidy";
        private String pwd = "cassidy";
        private HomePage homePageObject;
        private LogInPage logInPageObject;


        public WSONEUITests()
        {
            //webDriver = new FirefoxDriver();
            webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            homePageObject = new HomePage(webDriver);
            logInPageObject = new LogInPage(webDriver);
        }
        [Fact]
        [Trait("category", "p0")]
        [Trait("priority", "p0")]
        public void VerifyCompanyLogoAfterLogin()
        {
            try
            {
                webDriver.Manage().Window.Maximize();
                webDriver.Url = StartURL;
                logInPageObject.usernameinput.SendKeys(uname);
                logInPageObject.loginButton.Click();
                logInPageObject.passwordinput.SendKeys(pwd);
                logInPageObject.loginButton.Click();
                Thread.Sleep(5000);
                Assert.True(homePageObject.companyLogo.Displayed);
            }
            finally
            {
                webDriver.Close();
                webDriver.Dispose();
            }
            

        }
        
    }
}
