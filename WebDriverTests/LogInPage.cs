using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTests
{
    class LogInPage
    {
        private IWebDriver webDriver;
        //private IWebElement usernameinput => webDriver.FindElement(By.Id("UserName"));
        public IWebElement usernameinput => webDriver.FindElement(By.XPath("//*[@id=\"UserName\"]"));
        public IWebElement passwordinput => webDriver.FindElement(By.Id("Password"));
        public IWebElement loginButton => webDriver.FindElement(By.Name("Login"));
        public LogInPage(IWebDriver argWebDriver)
        {
            this.webDriver = argWebDriver;
        }
    }
}
