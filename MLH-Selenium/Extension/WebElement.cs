using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;

namespace MLH_Selenium.Extension
{
    public class WebElement : IWebElement
    {
        public IWebElement element;

        public WebElement(IWebElement element)
        {
            this.element = element;
        }

        public bool Displayed
        {
            get
            {
                return element.Displayed;
            }
        }

        public bool Enabled
        {
            get
            {
                return element.Enabled;
            }
        }

        public System.Drawing.Point Location {
            get
            {
                return element.Location;
            }
        }

        public bool Selected
        {
            get
            {
                return element.Selected;
            }
        }

        public System.Drawing.Size Size
        {
            get
            {
                return element.Size;
            }
        }

        public string TagName
        {
            get
            {
                return element.TagName;
            }
        }

        internal void HighlightElement()
        {
            throw new NotImplementedException();
        }

        public string Text
        {
            get
            {
                return element.Text;
            }
        }

        public void Clear()
        {
            element.Clear();
        }

        public void Click()
        {
            element.Click();
        }

        public IWebElement FindElement(By by)
        {
            return element.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return element.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return element.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return element.GetCssValue(propertyName);
        }

        public void SendKeys(string text)
        {
            element.SendKeys(text);
        }

        public void Submit()
        {
            element.Submit();
        }

        public void DragAndDropElement(WebDriver driver, int X, int Y)
        {
            Actions builder = new Actions(driver);
            builder.DragAndDropToOffset(element, X, Y).Build().Perform();
        }

        public void HighlightElement(WebDriver driver)
        {
            var jsDriver = (IJavaScriptExecutor)driver;
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: red"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }
    }
}
