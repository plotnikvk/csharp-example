using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Support.Events;
using System.Collections.Generic;

namespace csharp_example
{
    [TestFixture]
    class FirstTestClass
    {
        private EventFiringWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new EventFiringWebDriver(new ChromeDriver("C:\\Users\\plotn\\Documents" +
                "\\Visual Studio 2017\\Projects\\csharp-example\\csharp-example\\drv\\"));
            driver.FindingElement += (sender, e) => Console.WriteLine(e.FindMethod);
            driver.FindElementCompleted += (sender, e) => Console.WriteLine(e.FindMethod + " found");
            driver.ExceptionThrown += (sender, e) => Console.WriteLine(e.ThrownException);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "http://www.google.com/";
            driver.FindElement(By.Name("q")).SendKeys("webdriver");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Tab);
            IWebElement searchButton = wait.Until(d => d.FindElement(By.Name("btnK")));
            
            //IList<IWebElement> links =  driver.FindElements(By.XPath("//h3/a"));
            //links[0].Click();
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
