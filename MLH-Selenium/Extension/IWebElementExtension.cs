using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using MLH_Selenium.PageObject;

namespace MLH_Selenium.Extension
{
    public static class IWebElementExtension
    {
        public static void mClick(this IWebElement element)
        {
            element.Click();
        }

        public static void mSendKeys(this IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public static void mDragAndDropElement(this IWebElement element, int X, int Y)
        {                        
            Actions builder = new Actions(Constant.driver);
            IAction dragAndDrop = builder.DragAndDropToOffset(element, X, Y).Build();
            dragAndDrop.Perform();
        }

        public static void mHighlightElement(this IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)Constant.driver;
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: red"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }
    }
}
