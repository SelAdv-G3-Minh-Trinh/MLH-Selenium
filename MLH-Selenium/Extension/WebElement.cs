using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace MLH_Selenium.Extension
{
    public class WebElement : IWebElement
    {
        private IWebElement element;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebElement"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public WebElement(IWebElement element)
        {
            Element = element;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="WebElement"/> is displayed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if displayed; otherwise, <c>false</c>.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public bool Displayed
        {
            get
            {
                return Element.Displayed;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="WebElement"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public bool Enabled
        {
            get
            {
                return Element.Enabled;
            }
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public System.Drawing.Point Location
        {
            get
            {
                return Element.Location;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="WebElement"/> is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public bool Selected
        {
            get
            {
                return Element.Selected;
            }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public System.Drawing.Size Size
        {
            get
            {
                return Element.Size;
            }
        }

        /// <summary>
        /// Gets the name of the tag.
        /// </summary>
        /// <value>
        /// The name of the tag.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public string TagName
        {
            get
            {
                return Element.TagName;
            }
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public string Text
        {
            get
            {
                return Element.Text;
            }
        }

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        /// <value>
        /// The element.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
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

        /// <summary>
        /// Clears this instance.
        /// </summary>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public void Clear()
        {
            Element.Clear();
        }

        /// <summary>
        /// Clicks this instance.
        /// </summary>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public void Click()
        {
            Element.Click();
        }

        /// <summary>
        /// Finds the element.
        /// </summary>
        /// <param name="by">The by.</param>
        /// <returns>element</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public IWebElement FindElement(By by)
        {
            return Element.FindElement(by);
        }

        /// <summary>
        /// Finds the elements.
        /// </summary>
        /// <param name="by">The by.</param>
        /// <returns>elements</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Element.FindElements(by);
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns>string</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public string GetAttribute(string attributeName)
        {
            return Element.GetAttribute(attributeName);
        }

        /// <summary>
        /// Gets the CSS value.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>string</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public string GetCssValue(string propertyName)
        {
            return Element.GetCssValue(propertyName);
        }

        /// <summary>
        /// Sends the keys.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public void SendKeys(string text)
        {
            Element.Clear();
            Element.SendKeys(text);
        }

        /// <summary>
        /// Submits this instance.
        /// </summary>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public void Submit()
        {
            Element.Submit();
        }

        /// <summary>
        /// Drags the and drop element.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public void DragAndDropElement(WebDriver driver, int X, int Y)
        {
            Actions builder = new Actions(driver.Driver);
            builder.DragAndDropToOffset(Element, X, Y).Build().Perform();
        }

        /// <summary>
        /// Mouses the hover.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public void MouseHover(WebDriver driver)
        {
            Actions action = new Actions(driver.Driver);
            action.MoveToElement(Element).Perform();            
        }

        /// <summary>
        /// Checks this instance.
        /// </summary>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public void Check()
        {
            if (!Element.Selected)
                element.Click();
        }

        /// <summary>
        /// Uns the check.
        /// </summary>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public void UnCheck()
        {
            if (Element.Selected)
                element.Click();
        }

        /// <summary>
        /// Highlights the element.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/9/2016</createdDate>
        public void HighlightElement(WebDriver driver)
        {
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: red"";";
            driver.ParseToJavaScriptExecutor().ExecuteScript(highlightJavascript, new object[] { Element });
        }
    }
}