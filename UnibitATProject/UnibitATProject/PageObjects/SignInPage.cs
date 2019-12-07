using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibitATProject.PageObjects
{
    public class SignInPage
    {
        private IWebDriver driver;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GreetingMessage
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                IWebElement greeting = wait.Until(d => d.FindElement(By.CssSelector("#widget_info h2")));

                return greeting;
            }
        }
        
    }
}
