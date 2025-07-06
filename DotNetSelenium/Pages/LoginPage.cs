using DotNetSelenium.Utils;

namespace DotNetSelenium.Pages
{
    internal class LoginPage(IWebDriver driver)
    {
        // Locators (page elements)
        IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));
        IWebElement UsernameField => driver.FindElement(By.Id("UserName"));
        IWebElement PasswordField => driver.FindElement(By.Id("Password"));
        IWebElement LoginButton => driver.FindElement(By.CssSelector(".btn"));
        IWebElement EmployeeDetailsLink => driver.FindElement(By.LinkText("Employee Details"));
        IWebElement ManageUsersLink => driver.FindElement(By.LinkText("Manage Users"));
        IWebElement LogOffLink => driver.FindElement(By.LinkText("Log off"));

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

        public (bool employeeDetails, bool manageUsers) IsLoggedIn()
        {
            return (EmployeeDetailsLink.Displayed, ManageUsersLink.Displayed);
        }

    }
}
