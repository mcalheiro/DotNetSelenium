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

        public static void MultiSelectDropdown(IWebDriver driver, By locator, string[] values)
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(locator));
            foreach (string value in values)
            {
                dropdown.SelectByText(value);
            }
        }

        public static List<String> GetSelectedItems(IWebDriver driver, By locator)
        {
            List<String> selectedItems = new List<String>();
            SelectElement dropdown = new SelectElement(driver.FindElement(locator));
            IList<IWebElement> selecteItems = dropdown.AllSelectedOptions;
            foreach (IWebElement item in selecteItems)
            {
                selectedItems.Add(item.Text);
            }
            return selectedItems;
        }
    }
}
