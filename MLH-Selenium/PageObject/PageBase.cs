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
        public WebDriver driver;

        public PageBase()
        {
            if(driver==null)
                driver = (WebDriver)Constant.driverTable[Thread.CurrentThread.ManagedThreadId];
        }

        public void openFireFoxBrowser()
        {
            IWebDriver IDriver = new FirefoxDriver();
            driver = new WebDriver(IDriver);
            driver.Manage().Window.Maximize();
        }

        public WebElement findElementByStringAndMethod(string input, Constant.method m = Constant.method.xpath)
        {
            IWebElement element = null;
            WebElement elementOutput = null;

            try
            {
                if (m == Constant.method.xpath)
                    element = driver.FindElement(By.XPath(input), Constant.timeout);
                else if (m == Constant.method.id)
                    element = driver.FindElement(By.Id(input), Constant.timeout);
                else if (m == Constant.method.name)
                    element = driver.FindElement(By.Name(input), Constant.timeout);

                elementOutput = new WebElement(element);
                if (Constant.debug && elementOutput != null)
                {
                    elementOutput.HighlightElement(driver);
                    Thread.Sleep(500);
                }
            }
            catch (Exception)
            {
                return null;
            }

            return elementOutput;
        }

        public void Close()
        {
            Constant.driverTable.Remove(Thread.CurrentThread.ManagedThreadId);
            driver.Quit();
        }
    }
}