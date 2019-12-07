using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibitATProject.PageObjects
{
    public class MainPage
    {
        private const string Url = "https://mail.bg/auth/login";
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToMainPage()
        {
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Window.Maximize();
        }
    }
}
