using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLH_Selenium.PageObject;

namespace MLH_Selenium.TestCases
{
    [TestClass]
    public class LoginTestSuite : TestBase
    {
        [TestMethod]
        public void DA_LOGIN_TC001()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_LOGIN_TC001 - Verify that user can login specific repository successfully via Dashboard login page with correct credentials");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Enter valid username and password
            //3. Click on "Login" button
            DashboardPage dashboard = new DashboardPage();
            dashboard = loginPage.LoginWithValidUser(repo, user, pass);

            //VP. Verify that Dashboard Mainpage appears
            string actual = dashboard.getUserLogin(user);
            string expected = user;
            Assert.AreEqual(expected, actual);

            //Pos: close
            dashboard.Close();
        }

        [TestMethod]
        public void DA_LOGIN_TC002()
        {
            string repo = "SampleRepository";
            string user = "abc";
            string pass = "abc";

            Console.WriteLine("DA_LOGIN_TC002 - Verify that user fails to login specific repository successfully via Dashboard login page with incorrect credentials");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Enter invalid username and password
            //3. Click on "Login" button
            //VP. Verify that Dashboard Error message "Username or password is invalid" appears
            string actual = loginPage.LoginWithInvalidUser(repo, user, pass).GetAlertMessage();
            string expected = "Username or password is invalid";
            Assert.AreEqual(expected, actual);

            // Pos. close:
            loginPage.Close();
        }

        [TestMethod]
        public void DA_LOGIN_TC003()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "abc";

            Console.WriteLine("DA_LOGIN_TC003 - Verify that user fails to log in specific repository successfully via Dashboard login page with correct username and incorrect password");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Enter valid username and invalid password
            //3. Click on "Login" button
            //VP. Verify that Dashboard Error message "Username or password is invalid" appears
            string actual = loginPage.LoginWithInvalidUser(repo, user, pass).GetAlertMessage();
            string expected = "Username or password is invalid";
            Assert.AreEqual(expected, actual);

            // Pos. close:
            loginPage.Close();
        }

        [TestMethod]
        public void DA_LOGIN_TC004()
        {
            string repo1 = "SampleRepository";
            string repo2 = "TestRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_LOGIN_TC004 - Verify that user is able to log in different repositories successfully after logging out current repository");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Enter valid username and password of default repository
            //3. Click on "Login" button
            //4. Click on "Logout" button 
            DashboardPage dashboard = new DashboardPage();
            dashboard = loginPage.LoginWithValidUser(repo1, user, pass);
            dashboard.Logout();

            //5. Select a different repository
            //6. Enter valid username and password of this repository
            //VP. Verify that Dashboard Mainpage appears
            string actual = loginPage.LoginWithValidUser(repo2, user, pass).getUserLogin(user);
            string expected = user;
            Assert.AreEqual(expected, actual);

            //Pos: close
            dashboard.Close();

        }

        [TestMethod]
        public void DA_LOGIN_TC005()
        {
            string repo1 = "SampleRepository";
            string repo2 = "TestRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_LOGIN_TC005 - Verify that there is no Login dialog when switching between 2 repositories with the same account");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Login with valid account for the first repository
            DashboardPage dashboard = new DashboardPage();
            dashboard = loginPage.LoginWithValidUser(repo1, user, pass);

            //3. Choose another repository in Repository list
            //VP1. There is no Login Repository dialog
            //VP2. The Repository menu displays name of switched repository
            string actual = dashboard.ChangeRepository(repo2).getRepositoryName();
            string expected = repo2;
            Assert.AreEqual(expected, actual);

            //Pos: close
            dashboard.Close();
        }

        [TestMethod]
        public void DA_LOGIN_TC006()
        {
            string repo = "SampleRepository";
            string user = "test";
            string pass = "ADMIN";

            Console.WriteLine(@"DA_LOGIN_TC006 - Verify that 'Password' input is case sensitive");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Enter valid username and password in uppercase
            //3. Click on "Login" button
            //VP. Verify that Dashboard Error message "Username or password is invalid" appears
            string actual = loginPage.LoginWithInvalidUser(repo, user, pass).GetAlertMessage();
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
            dashboard = loginPage.LoginWithValidUser(repo, user, pass);

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
            string user = "test1";
            string pass = "!@#$%^&*()";

            Console.WriteLine("DA_LOGIN_TC008 - Verify that password with special characters is working correctly");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Enter valid username and password with special characters
            //3. Click on "Login" button
            DashboardPage dashboard = new DashboardPage();
            dashboard = loginPage.LoginWithValidUser(repo, user, pass);

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
            string user = "test@logigear.com";
            string pass = "";

            Console.WriteLine("DA_LOGIN_TC009 - Verify that username with special characters is working correctly");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Enter username  with special characters and valid password
            //3. Click on "Login" button
            DashboardPage dashboard = new DashboardPage();
            dashboard = loginPage.LoginWithValidUser(repo, user, pass);

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

            Console.WriteLine("DA_LOGIN_TC010 - Verify that the page works correctly for the case when no input entered to Password and Username field");

            //1. Navigate to Dashboard login page
            LoginPage loginPage = new LoginPage();
            loginPage.open();

            //2. Do not enter username and password
            //3. Click on "Login" button
            //VP. Verify that Dashboard Error message "Please enter username!" appears
            string actual = loginPage.LoginWithBlankUser(repo, user, pass).GetAlertMessage();
            string expected = "Please enter username!";
            Assert.AreEqual(expected, actual);

            // Pos. close:
            loginPage.Close();
        }
    }
}