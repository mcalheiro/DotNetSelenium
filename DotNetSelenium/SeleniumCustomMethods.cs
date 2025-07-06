using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DotNetSelenium
{
    internal class SeleniumCustomMethods
    {
        public static void Click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }

        public static void SelectDropdownByText(IWebDriver driver, By locator, string text)
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(locator));
            dropdown.SelectByText(text);
        }
    }
}
