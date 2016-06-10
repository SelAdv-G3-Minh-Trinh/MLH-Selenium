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

        /// <summary>
        /// Initializes a new instance of the <see cref="WebDriver"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public WebDriver(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Gets the current window handle.
        /// </summary>
        /// <value>
        /// The current window handle.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public string CurrentWindowHandle
        {
            get
            {
                return Driver.CurrentWindowHandle;
            }
        }

        /// <summary>
        /// Gets the page source.
        /// </summary>
        /// <value>
        /// The page source.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public string PageSource
        {
            get
            {
                return Driver.PageSource;
            }
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public string Title
        {
            get
            {
                return Driver.Title;
            }
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
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

        /// <summary>
        /// Gets the window handles.
        /// </summary>
        /// <value>
        /// The window handles.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public ReadOnlyCollection<string> WindowHandles
        {
            get
            {
                return Driver.WindowHandles;
            }
        }

        /// <summary>
        /// Gets or sets the driver.
        /// </summary>
        /// <value>
        /// The driver.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
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

        /// <summary>
        /// Gets the stop watch.
        /// </summary>
        /// <value>
        /// The stop watch.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public object StopWatch { get; private set; }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public void Close()
        {
            Driver.Close();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public void Dispose()
        {
            Driver.Dispose();
        }

        /// <summary>
        /// Finds the element.
        /// </summary>
        /// <param name="by">The by.</param>
        /// <returns>element which is found</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public IWebElement FindElement(By by)
        {
            return Driver.FindElement(by);
        }

        /// <summary>
        /// Finds the elements.
        /// </summary>
        /// <param name="by">The by.</param>
        /// <returns>element which are found<</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Driver.FindElements(by);
        }

        /// <summary>
        /// Finds the elements.
        /// </summary>
        /// <param name="by">The by.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>elements which are found wihthin timeout</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
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

        /// <summary>
        /// Manages this instance.
        /// </summary>
        /// <returns>IOptions</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public IOptions Manage()
        {
            return Driver.Manage();
        }

        /// <summary>
        /// Navigates this instance.
        /// </summary>
        /// <returns>INavigation</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public INavigation Navigate()
        {
            return Driver.Navigate();
        }

        /// <summary>
        /// Quits this instance.
        /// </summary>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public void Quit()
        {
            Driver.Quit();
        }

        /// <summary>
        /// Switches to.
        /// </summary>
        /// <returns>ITargetLocator</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public ITargetLocator SwitchTo()
        {
            return Driver.SwitchTo();
        }

        /// <summary>
        /// Finds the element.
        /// </summary>
        /// <param name="by">The by.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>elements which are found wihthin timeout</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
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

        /// <summary>
        /// Waits for element not visible.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="seconds">The seconds.</param>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
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

        /// <summary>
        /// Waits for element to be clickable.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="seconds">The seconds.</param>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
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

        /// <summary>
        /// Parses to java script executor.
        /// </summary>
        /// <returns>IJavaScriptExecutor</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public IJavaScriptExecutor ParseToJavaScriptExecutor()
        {
            return (IJavaScriptExecutor)Driver;
        }

        /// <summary>
        /// Switches to alert.
        /// </summary>
        /// <returns>IAlert</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public IAlert SwitchToAlert()
        {
            return Driver.SwitchTo().Alert();
        }
    }
}