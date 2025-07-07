namespace DotNetSelenium.Utils
{
    public static class SeleniumCustomMethods
    {
        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }

        public static void SubmitElement(this IWebElement locator)
        {
            locator.Submit();
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void SelectDropdownByText(this IWebElement locator, string text)
        {
            SelectElement dropdown = new SelectElement(locator);
            dropdown.SelectByText(text);
        }

        public static void MultiSelectDropdown(this IWebElement locator, string[] values)
        {
            SelectElement dropdown = new SelectElement(locator);
            foreach (string value in values)
            {
                dropdown.SelectByText(value);
            }
        }

        public static List<string> GetSelectedItems(IWebElement locator)
        {
            List<string> selectedItems = new List<string>();
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
