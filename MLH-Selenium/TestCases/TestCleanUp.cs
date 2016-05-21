using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLH_Selenium.PageObject;
using MLH_Selenium.Common;

namespace MLH_Selenium.TestCases
{
    [TestClass]
    public class TestCleanUp : TestBase
    {
        [TestMethod]
        public void CleanUp_RemoveAllPage()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.open();
            DashboardPage dashboardPage = loginPage.LoginWithValidUser(Constant.mainRepository, Constant.adminUser, Constant.adminPassword);
            dashboardPage.deleteAllPages();
        }
    }
}
