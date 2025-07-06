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