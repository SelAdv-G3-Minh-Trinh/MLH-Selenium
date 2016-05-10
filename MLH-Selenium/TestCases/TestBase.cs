using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLH_Selenium.PageObject;
using log4net.Config;
using log4net;
using System.Diagnostics;
using System.IO;

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

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            XmlConfigurator.Configure();
        }
    }
}