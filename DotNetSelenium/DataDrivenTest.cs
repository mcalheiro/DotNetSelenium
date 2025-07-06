using DotNetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotNetSelenium
{
    public class DataDrivenTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(Login))]
        public void TestWithPOM(LoginModel loginModel)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickLoginLink();
            loginPage.Login(loginModel.username, loginModel.password);
            driver.Quit();
        }

        public static IEnumerable<LoginModel> Login()
        {
            yield return new LoginModel()
            { 
                username = "admin",
                password = "password"
            };
            yield return new LoginModel()
            {
                username = "admin2",
                password = "password2"
            };
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
