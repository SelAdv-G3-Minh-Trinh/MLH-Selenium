using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLH_Selenium.Extension
{
    public static class WebDriverExtension
    {
        public static IWebElement mFindElement(this IWebDriver driver, By by, int seconds = 3)
        {
            if (seconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static void mNavigate(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
