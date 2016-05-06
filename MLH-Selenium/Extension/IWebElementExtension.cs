using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
