using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLH_Selenium.PageObject;

namespace MLH_Selenium.TestCases
{
    [TestClass]
    public class Login_TestModule : TestBase
    {
        [TestMethod]
        public void DA_LOGIN_TC006()
        {
            string repo = "SampleRepository";
            string user = "hoangha";
            string pass = "PASSWORD";

            Console.WriteLine(@"DA_LOGIN_TC006 - Verify that 'Password' input is case sensitive");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Enter valid username and password in uppercase
            //3. Click on "Login" button
            //VP. Verify that Dashboard Error message "Username or password is invalid" appears
            string actual = loginPage.loginWithInvalidUser(repo, user, pass).getAlertMessage();
            string expected = "Username or password is invalid";
            Assert.AreEqual(expected, actual);

            // Pos. close:
            loginPage.Close();
        }

       [TestMethod]
       public void DA_LOGIN_TC007()
        {
            string repo = "SampleRepository";
            string user = "ADMINISTRATOR";
            string pass = "";

            Console.WriteLine(@"DA_LOGIN_TC007 - Verify that 'Username' is not case sensitive");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Enter username in uppercase and valid password
            //3. Click on "Login" button
            DashboardPage dashboard = new DashboardPage();
            dashboard = loginPage.loginWithValidUser(repo, user, pass);

            //VP. Verify that Dashboard Mainpage appears
            string actual = dashboard.getUserLogin(user);
            string expected = user;
            Assert.AreEqual(expected, actual);

            //Pos: close
            dashboard.Close();
        }

      [TestMethod]
        public void DA_LOGIN_TC008()
        {
            string repo = "SampleRepository";
            string user = "hoang.ha";
            string pass = "!@#$%^&*()";

            Console.WriteLine("DA_LOGIN_TC008 - Verify that password with special characters is working correctly");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Enter valid username and password with special characters
            //3. Click on "Login" button
            DashboardPage dashboard = new DashboardPage();
            dashboard = loginPage.loginWithValidUser(repo, user, pass);

            //VP. Verify that Dashboard Mainpage appears
            string actual = dashboard.getUserLogin(user);
            string expected = user;
            Assert.AreEqual(expected, actual);

            //Pos: close
            dashboard.Close();
        }

        [TestMethod]
        public void DA_LOGIN_TC009()
        {
            string repo = "SampleRepository";
            string user = "hoang.ha@logigear.com";
            string pass = "";

            Console.WriteLine("DA_LOGIN_TC009 - Verify that username with special characters is working correctly");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Enter username  with special characters and valid password
            //3. Click on "Login" button
            DashboardPage dashboard = new DashboardPage();
            dashboard = loginPage.loginWithValidUser(repo, user, pass);

            //VP. Verify that Dashboard Mainpage appears
            string actual = dashboard.getUserLogin(user);
            string expected = user;
            Assert.AreEqual(expected, actual);

            //Pos: close
            dashboard.Close();
        }

        [TestMethod]
        public void DA_LOGIN_TC010()
        {
            string repo = "SampleRepository";
            string user = "";
            string pass = "";

            Console.WriteLine("DA_LOGIN_TC0010 - Verify that the page works correctly for the case when no input entered to Password and Username field");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Do not enter username and password
            //3. Click on "Login" button
            //VP. Verify that Dashboard Error message "Please enter username!" appears
            string actual = loginPage.loginWithBlankUser(repo, user, pass).getAlertMessage();
            string expected = "Please enter username!";
            Assert.AreEqual(expected, actual);

            // Pos. close:
            loginPage.Close();
        }
    }
}
