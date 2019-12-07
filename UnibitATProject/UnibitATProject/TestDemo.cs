using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using UnibitATProject.PageObjects;

namespace UnibitATProject
{
    [TestClass]
    public class TestDemo
    {
        private IWebDriver driver;
        public MainPage mainPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            mainPage = new MainPage(driver);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void TestSuccessLogin()
        {
            mainPage.GoToMainPage();
            //driver.Navigate().GoToUrl("https://mail.bg/auth/login");
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 776);
            driver.FindElement(By.Id("imapuser")).SendKeys("ieee@mail.bg");
            driver.FindElement(By.Id("pass")).Click();
            driver.FindElement(By.Id("pass")).SendKeys("password");
            driver.FindElement(By.LinkText("ВЛЕЗ")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement greeting = wait.Until(d => d.FindElement(By.CssSelector("#widget_info h2")));
            Assert.Equals(greeting.Text, "Здравей, ieee");
        }

        [TestMethod]
        public void TestEmptyMailAndPassword()
        {
            mainPage.GoToMainPage();
            //driver.Navigate().GoToUrl("https://mail.bg/auth/login");
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 776);
            driver.FindElement(By.LinkText("ВЛЕЗ")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement errorMessage = wait.Until(d => d.FindElement(By.CssSelector(".hint_text")));
            Assert.AreEqual(errorMessage.Text, "Попълнете правилно и двете полета");
            driver.Close();
        }
    }
}
