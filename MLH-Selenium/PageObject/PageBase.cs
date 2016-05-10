using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using MLH_Selenium.Extension;
using MLH_Selenium.Common;
using System.Threading;

namespace MLH_Selenium.PageObject
{
    public class PageBase
    {
        public static void openFireFoxBrowser()
        {
            IWebDriver driver = new FirefoxDriver();
            Constant.driver = new WebDriver(driver);
            Constant.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Constant.implicitlyTimeSeconds));
        }

        public static WebElement findElementByStringAndMethod(string input, Constant.method m = Constant.method.xpath)
        {
            IWebElement element = null;
            WebElement elementOutput = null;
            try
            {
                if (m == Constant.method.xpath)
                    element = Constant.driver.FindElement(By.XPath(input), 3);
                else if (m == Constant.method.id)
                    element = Constant.driver.FindElement(By.Id(input), 3);
                else if (m == Constant.method.name)
                    element = Constant.driver.FindElement(By.Name(input), 3);

                elementOutput = new WebElement(element);
                if (Constant.debug && elementOutput != null)
                {
                    elementOutput.HighlightElement(Constant.driver);
                    Thread.Sleep(1000);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return elementOutput;
        }
    }
}