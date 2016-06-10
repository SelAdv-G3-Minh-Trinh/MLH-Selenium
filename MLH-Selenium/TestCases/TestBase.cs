using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLH_Selenium.PageObject;
using log4net.Config;
using log4net;
using System.Diagnostics;
using System.IO;
using System.Threading;
using MLH_Selenium.Common;

namespace MLH_Selenium.TestCases
{
    [TestClass]
    public class TestBase
    {
        PageBase page;

        /// <summary>
        /// Befores the method.
        /// </summary>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/5/2016</createdDate>
        [TestInitialize]
        public void BeforeMethod()
        {
            page = new PageBase();
            page.openFireFoxBrowser();
            int currentThread = Thread.CurrentThread.ManagedThreadId;
            Constant.driverTable.Add(currentThread, page.driver);
        }

        /// <summary>
        /// After the method.
        /// </summary>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/11/2016</createdDate>
        [TestCleanup]
        public void AfterMethod()
        {            
            page.Close();
        }
    }
}