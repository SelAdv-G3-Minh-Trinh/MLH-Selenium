using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using MLH_Selenium.Extension;
using System.Threading;

namespace MLH_Selenium.PageObject
{
    public class PageBase
    {
        public static void openFireFoxBrowser()
        {
            Constant.driver = new FirefoxDriver();
            Constant.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Constant.implicitlyTimeSeconds));
        }

        public static IWebElement convertToIWebElement(string input, Constant.method m = Constant.method.xpath)
        {
            IWebElement element = null;
            try
            {             
                if (m == Constant.method.xpath)
                    element = Constant.driver.mFindElement(By.XPath(input));
                else if (m == Constant.method.id)
                    element = Constant.driver.mFindElement(By.Id(input));
                else if (m == Constant.method.name)
                    element = Constant.driver.mFindElement(By.Name(input));

                if (Constant.debug)
                {
                    element.mHighlightElement();
                    Thread.Sleep(1000);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return element;
        }      
    }
}
