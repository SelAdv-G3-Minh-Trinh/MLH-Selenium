using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLH_Selenium.PageObject;
using MLH_Selenium.Extension;

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
            loginPage.loginWithValidUser("SampleRepository", "administrator", null); 
        }
    }
}
