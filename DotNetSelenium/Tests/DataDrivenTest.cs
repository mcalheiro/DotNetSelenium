using DotNetSelenium.Models;
using DotNetSelenium.Pages;
using FluentAssertions;
using System.Text.Json;

namespace DotNetSelenium.Tests
{
    public class DataDrivenTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(Login))]
        public void TestWithModel(LoginModel loginModel)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickLoginLink();
            loginPage.Login(loginModel.username, loginModel.password);
            Assert.IsTrue(loginPage.IsLoggedIn().manageUsers);
        }

        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJSON))]
        public void TestWithJSON(LoginModel loginModel)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickLoginLink();
            loginPage.Login(loginModel.username, loginModel.password);
            Assert.IsTrue(loginPage.IsLoggedIn().employeeDetails);
        }

        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJSON))]
        public void TestWithFA(LoginModel loginModel)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickLoginLink();
            loginPage.Login(loginModel.username, loginModel.password);
            var getLoggedIn = loginPage.IsLoggedIn();
            // Fancy assertions
            getLoggedIn.employeeDetails.Should().BeTrue();
            getLoggedIn.manageUsers.Should().BeTrue();
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
            yield return new LoginModel()
            {
                username = "admin3",
                password = "password3"
            };
        }

        public static IEnumerable<LoginModel> LoginJSON()
        {
            string JsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "login.json");
            var jsonString = File.ReadAllText(JsonFilePath);
            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true
            });
            foreach (var userdata in loginModel)
            {
                yield return userdata;
            }
        }

        private void ReadJsonDile()
        {
            string JsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "login.json");
            var jsonString = File.ReadAllText(JsonFilePath);
            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
