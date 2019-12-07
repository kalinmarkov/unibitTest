using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnibitATProject
{
    [TestClass]
    public class TestDemo
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        [TestCleanup]
        protected void TearDown()
        {
            driver.Quit();
        }
        [TestMethod]
        public void testSuccessLogin()
        {
            driver.Navigate().GoToUrl("https://mail.bg/auth/login");
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 776);
            driver.FindElement(By.Id("imapuser")).SendKeys("ieee@mail.bg");
            driver.FindElement(By.Id("pass")).Click();
            driver.FindElement(By.Id("pass")).SendKeys("password");
            driver.FindElement(By.LinkText("ВЛЕЗ")).Click();
            Assert.That(driver.FindElement(By.CssSelector("#widget_info h2")).Text, Is.EqualTo("Здравей, ieee"));
        }

        [TestMethod]
        public void TestEmptyMailAndPassword()
        {
            driver.Navigate().GoToUrl("https://mail.bg/auth/login");
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 776);
            driver.FindElement(By.LinkText("ВЛЕЗ")).Click();
            Assert.That(driver.FindElement(By.CssSelector(".hint_text")).Text, Is.EqualTo("Попълнете правилно и двете полета"));
            driver.Close();
        }
    }
}
