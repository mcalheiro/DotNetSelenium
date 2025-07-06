using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DotNetSelenium
{
    internal class SeleniumCustomMethods
    {
        public static void Click(IWebElement locator)
        {
            locator.Click();
        }

        public static void Submit(IWebElement locator)
        {
            locator.Submit();
        }

        public static void EnterText(IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void SelectDropdownByText(IWebElement locator, string text)
        {
            SelectElement dropdown = new SelectElement(locator);
            dropdown.SelectByText(text);
        }

        public static void MultiSelectDropdown(IWebElement locator, string[] values)
        {
            SelectElement dropdown = new SelectElement(locator);
            foreach (string value in values)
            {
                dropdown.SelectByText(value);
            }
        }

        public static List<String> GetSelectedItems(IWebElement locator)
        {
            List<String> selectedItems = new List<String>();
            SelectElement dropdown = new SelectElement(locator);
            IList<IWebElement> selecteItems = dropdown.AllSelectedOptions;
            foreach (IWebElement item in selecteItems)
            {
                selectedItems.Add(item.Text);
            }
            return selectedItems;
        }
    }
}
