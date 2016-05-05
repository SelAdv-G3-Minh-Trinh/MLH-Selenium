using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace MLH_Selenium.PageObject
{
    public class PageBase
    {
        public static void openFireFoxBrowser()
        {
            Constant.driver = new FirefoxDriver();
        }

        public static IWebElement convertToIWebElement(string input, Constant.method m = Constant.method.xpath)
        {
            IWebElement element = null;
            try
            {
                if (m == Constant.method.xpath)
                    element = Constant.driver.FindElement(By.XPath(input));
                else if (m == Constant.method.id)
                    element = Constant.driver.FindElement(By.Id(input));
                else if (m == Constant.method.name)
                    element = Constant.driver.FindElement(By.Name(input));
            }
            catch (Exception)
            {
                throw;
            }
            return element;
        }      
    }
}
