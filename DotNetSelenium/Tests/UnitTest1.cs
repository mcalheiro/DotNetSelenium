using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DotNetSelenium.Driver;
using DotNetSelenium.Pages;
using FluentAssertions;
using System.Data;

namespace DotNetSelenium.Tests
{
    [TestFixture("admin", "password", DriverType.Edge)]
    public class Tests
    {
        private IWebDriver driver;
        private string username;
        private string password;
        private DriverType driverType;
        private ExtentReports extentReport;
        private ExtentTest extentTest;

        public Tests(string username, string password, DriverType driverType)
        {
            this.username = username;
            this.password = password;
            this.driverType = driverType;
        }

        [SetUp]
        public void Setup()
        {
            SetupExtentReports();
            extentTest.Log(Status.Info, "Starting test setup");
            driver = GetDriverType(driverType);
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
        }

        private IWebDriver GetDriverType(DriverType driverType)
        {
            if (driverType == DriverType.Chrome)
            {
                return new ChromeDriver();
            }
            else if (driverType == DriverType.Firefox)
            {
                return new FirefoxDriver();
            }
            else if (driverType == DriverType.Edge)
            {
                return new EdgeDriver();
            }
            else
            {
                throw new ArgumentException("Unsupported driver type");
            }
        }

        private void SetupExtentReports()
        {
            extentReport = new ExtentReports();
            var spark = new ExtentSparkReporter("TestReport.html");
            extentReport.AttachReporter(spark);
            extentTest = extentReport.CreateTest("Login Test");
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
            wait.Until(d => d.FindElement(By.LinkText("Employee Details")).Displayed);
            loginPage.IsLoggedIn().employeeDetails.Should().BeTrue();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
            extentReport.Flush();
        }
    }
}