using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverTests
{
    class HomePage
    {
        private IWebDriver webDriver;
        public IWebElement companyLogo => webDriver.FindElement(By.Id("company_logo"));

        public HomePage(IWebDriver argWebDriver)
        {
            this.webDriver = argWebDriver;
        }
    }
}
