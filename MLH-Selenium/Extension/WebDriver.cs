using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace MLH_Selenium.Extension
{
    public class WebDriver : IWebDriver
    {
        private IWebDriver driver;

        public WebDriver(IWebDriver driver)
        {
            Driver = driver;
        }

        public string CurrentWindowHandle
        {
            get
            {
                return Driver.CurrentWindowHandle;
            }
        }

        public string PageSource
        {
            get
            {
                return Driver.PageSource;
            }
        }

        public string Title
        {
            get
            {
                return Driver.Title;
            }
        }

        public string Url
        {
            get
            {
                return Driver.Url;
            }

            set
            {
                Driver.Url = value;
            }
        }

        public ReadOnlyCollection<string> WindowHandles
        {
            get
            {
                return Driver.WindowHandles;
            }
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }

            set
            {
                driver = value;
            }
        }

        public void Close()
        {
            Driver.Close();
        }

        public void Dispose()
        {
            Driver.Dispose();
        }

        public IWebElement FindElement(By by)
        {                        
            return Driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Driver.FindElements(by);
        }

        public IOptions Manage()
        {
            return Driver.Manage();
        }

        public INavigation Navigate()
        {
            return Driver.Navigate();
        }

        public void Quit()
        {
            Driver.Quit();
        }

        public ITargetLocator SwitchTo()
        {
            return Driver.SwitchTo();
        }

        public IWebElement FindElement(By by, int seconds)
        {
            if (seconds > 0)
            {
                IWebElement element = Driver.FindElement(by);
                //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
                //return wait.Until(drv => drv.FindElement(by));

                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
                wait.Until(ExpectedConditions.ElementExists(by));

                try
                {
                    wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(0.1));
                    bool t = wait.Until(ExpectedConditions.StalenessOf(Driver.FindElement(by)));
                }
                catch (Exception)
                {

                }
            }
            return Driver.FindElement(by);
        }

        public void WaitForElementNotVisible(WebElement element, int seconds=3)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                wait.Until(driver1 => !element.Displayed);
            }
            catch
            {  }
        }

        public void WaitForElementToBeClickable(WebElement element, int seconds = 3)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch
            { }
        }

        public IJavaScriptExecutor ParseToJavaScriptExecutor()
        {
            return (IJavaScriptExecutor)Driver;
        }

        public IAlert SwitchToAlert()
        {
            return Driver.SwitchTo().Alert();
        }
    }
}