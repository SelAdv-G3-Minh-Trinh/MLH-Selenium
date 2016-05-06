using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLH_Selenium.PageObject;
using MLH_Selenium.Extension;
using System.Threading;
using System.Drawing;
using System.Runtime.InteropServices;
using OpenQA.Selenium;

namespace MLH_Selenium.TestCases
{
    [TestClass]
    public class Login_TestModule : TestBase
    {
        [TestMethod]
        public void DA_LOGIN_TC001()
        {         
            Constant.driver.mNavigate(Constant.url);
            LoginPage loginPage = new LoginPage();
            DashboardPage dashboardPage = loginPage.loginWithValidUser("SampleRepository", "administrator", null);
            dashboardPage.widget_head_panel.mDragAndDropElement(600, 900);                    
        }       
    }
}
