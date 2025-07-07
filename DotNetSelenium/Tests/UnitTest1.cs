using DotNetSelenium.Pages;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;

namespace DotNetSelenium.Tests
{
    [TestFixture("admin", "password")]
    public class Tests
    {
        private IWebDriver driver;
        private string username;
        private string password;

        public Tests(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        [Category("POM")]
        public void TestWithPOM()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickLoginLink();
            loginPage.Login(username, password);

            // Explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
                Message = "Login failed, Employee Details link not found."
            };
            wait.Until(d => d.FindElement(By.LinkText("Employee Detailssss")).Displayed);
            loginPage.IsLoggedIn().employeeDetails.Should().BeTrue();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}