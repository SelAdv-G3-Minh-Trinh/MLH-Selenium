using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;

namespace MLH_Selenium.Extension
{
    public class WebElement : IWebElement
    {
        private IWebElement element;

        public WebElement(IWebElement element)
        {
            Element = element;
        }

        public bool Displayed
        {
            get
            {
                return Element.Displayed;
            }
        }

        public bool Enabled
        {
            get
            {
                return Element.Enabled;
            }
        }

        public System.Drawing.Point Location
        {
            get
            {
                return Element.Location;
            }
        }

        public bool Selected
        {
            get
            {
                return Element.Selected;
            }
        }

        public System.Drawing.Size Size
        {
            get
            {
                return Element.Size;
            }
        }

        public string TagName
        {
            get
            {
                return Element.TagName;
            }
        }

        public string Text
        {
            get
            {
                return Element.Text;
            }
        }

        public IWebElement Element
        {
            get
            {
                return element;
            }

            set
            {
                element = value;
            }
        }

        public void Clear()
        {
            Element.Clear();
        }

        public void Click()
        {
            Element.Click();
        }

        public IWebElement FindElement(By by)
        {
            return Element.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Element.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return Element.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return Element.GetCssValue(propertyName);
        }

        public void SendKeys(string text)
        {
            Element.SendKeys(text);
        }

        public void Submit()
        {
            Element.Submit();
        }

        public void DragAndDropElement(WebDriver driver, int X, int Y)
        {
            Actions builder = new Actions(driver.Driver);
            builder.DragAndDropToOffset(Element, X, Y).Build().Perform();
        }

        public void MouseHover(WebDriver driver)
        {
            Actions action = new Actions(driver.Driver);
            action.MoveToElement(Element).Perform();
        }

        public void Check()
        {
            if (!Element.Selected)
                element.Click();
        }

        public void UnCheck()
        {
            if (Element.Selected)
                element.Click();
        }

        public void HighlightElement(WebDriver driver)
        {
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: red"";";
            driver.ParseToJavaScriptExecutor().ExecuteScript(highlightJavascript, new object[] { Element });
        }
    }
}