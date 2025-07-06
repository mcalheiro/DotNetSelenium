using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotNetSelenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLoginLogout()
        {
            // Create a new instance of the ChromeDriver
            IWebDriver driver = new ChromeDriver();
            // Navigate to website
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            // Maximize the browser window
            driver.Manage().Window.Maximize();
            // Find elements on the page and fill data
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            // Click the login button
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            // Verify the login was successful
            Assert.That(driver.FindElement(By.Id("flash")).Text, Does.Contain("You logged into a secure area!"));
            // Logout
            driver.FindElement(By.CssSelector("a[href='/logout']")).Click();
            // Verify the logout was successful
            Assert.That(driver.FindElement(By.Id("flash")).Text, Does.Contain("You logged out of the secure area!"));
            // Close the browser
            driver.Quit();
        }
    }
}