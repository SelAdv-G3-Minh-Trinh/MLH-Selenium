using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLH_Selenium.PageObject;

namespace MLH_Selenium.TestCases
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void BeforeMethod()
        {
            PageBase.openFireFoxBrowser();
        }
    }
}
