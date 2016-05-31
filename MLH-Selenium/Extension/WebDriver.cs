using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Threading;

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

        public object StopWatch { get; private set; }

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

        public ReadOnlyCollection<IWebElement> FindElements(By by, int timeout)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (timeout >= 0)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                    wait.Until(ExpectedConditions.ElementIsVisible(by));
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(100);
                    FindElements(by, timeout - stopwatch.Elapsed.Seconds);
                }
                catch (NullReferenceException)
                {
                    Thread.Sleep(100);
                    FindElements(by, timeout - stopwatch.Elapsed.Seconds);
                }              
            }
            stopwatch.Stop();
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

        public IWebElement FindElement(By by, int timeout)
        {
            IWebElement element = null;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (timeout >= 0)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                    wait.Until(ExpectedConditions.ElementIsVisible(by));
                    element = Driver.FindElement(by);
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(100);
                    FindElement(by, timeout - stopwatch.Elapsed.Seconds);
                }
                catch (NullReferenceException)
                {
                    Thread.Sleep(100);
                    FindElement(by, timeout - stopwatch.Elapsed.Seconds);
                }               
            }
            stopwatch.Stop();
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