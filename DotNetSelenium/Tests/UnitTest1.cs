using DotNetSelenium.Pages;

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
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}