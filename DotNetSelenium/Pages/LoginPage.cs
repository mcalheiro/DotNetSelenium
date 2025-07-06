using OpenQA.Selenium;

namespace DotNetSelenium.Pages
{
    internal class LoginPage
    {
        private readonly IWebDriver driver;

        // Constructor to initialize the driver
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Locators (page elements)
        IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));
        IWebElement UsernameField => driver.FindElement(By.Id("UserName"));
        IWebElement PasswordField => driver.FindElement(By.Id("Password"));
        IWebElement LoginButton => driver.FindElement(By.CssSelector(".btn"));

        // Methods (actions)
        public void ClickLoginLink()
        {
            LoginLink.ClickElement();
        }

        public void Login(string username, string password)
        {
            UsernameField.EnterText(username);
            PasswordField.EnterText(password);
            LoginButton.SubmitElement();
        }

    }
}
