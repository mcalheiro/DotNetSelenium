using DotNetSelenium.Pages;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

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
        public void TestWithModel(LoginModel loginModel)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickLoginLink();
            loginPage.Login(loginModel.username, loginModel.password);
            driver.Quit();
        }

        [Test]
        [Category("ddt")]
        [TestCaseSource(nameof(LoginJSON))]
        public void TestWithJSON(LoginModel loginModel)
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
            yield return new LoginModel()
            {
                username = "admin3",
                password = "password3"
            };
        }

        public static IEnumerable<LoginModel> LoginJSON()
        {
            string JsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
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
            string JsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(JsonFilePath);
            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
