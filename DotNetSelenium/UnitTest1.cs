using DotNetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DotNetSelenium
{
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
        }

        //[Test]
        //public void TestEAWebsite()
        //{
        //    _driver.FindElement(By.LinkText("Login")).Click();
        //    _driver.FindElement(By.Id("UserName")).SendKeys("admin");
        //    _driver.FindElement(By.Id("Password")).SendKeys("password");
        //    _driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        //    Assert.That(_driver.FindElement(By.CssSelector("a[href='/Manage']")).Text, Does.Contain("Hello admin!"));
        //    _driver.FindElement(By.LinkText("Log off")).Click();
        //    _driver.Quit();
        //}

        [Test]
        public void TestWithPOM()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLoginLink();
            loginPage.Login("admin", "password");
            _driver.Quit();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}