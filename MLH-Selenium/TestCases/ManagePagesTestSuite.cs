using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLH_Selenium.PageObject;
using MLH_Selenium.ObjectData;

namespace MLH_Selenium.TestCases
{

    [TestClass]
    public class ManagePagesTestSuite : TestBase
    {
        [TestMethod]
        public void DA_MP_TC011()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_MP_TC011 - Verify that user is unable open more than 1 \"New Page\" dialog");

            //1. Navigate to Dashboard login page
            //2. Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo,user,pass);

            //3. Go to Global Setting->Add page
            //4. Try to go to Global Setting->Add page again
            //5. VP: User cannot go to Global Setting -> Add page while "New Page" dialog appears.
            ManagePagesPage page = new ManagePagesPage();
            page = dashboard.goToAddPage();

            Assert.IsTrue(page.checkSettingDisplay());

            //Post - Condition  Logout
            //Close TA Dashboard
            dashboard.Logout();
            loginpage.Close();

        }

        [TestMethod]
        public void DA_MP_TC012()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";
            string pagename = "Test";
            string pagenext = "Overview";

            Console.WriteLine("DA_MP_TC012 - Verify that user is able to add additional pages besides \"Overview\" page successfully");

            //1. Navigate to Dashboard login page
            //2. Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3. Go to Global Setting->Add page
            //4. Enter Page Name field
            //5. Click OK button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();
            page.PageName = pagename;

            dashboard = pages.addNewpage(page);
            dashboard.NavigatetoCurrentPage();

            //6. VP Check "Test" page is displayed besides "Overview" page
            string actual = dashboard.getNamePageNextTo(pagenext);
            string expected = pagename;
            Assert.AreEqual(expected, actual);

            //Post - Condition  Delete newly added page
            //    Close TA Dashboard Main Page
            dashboard.deleteAPage(pagename);
            dashboard.Close();
        }

        [TestMethod]
        public void DA_MP_TC013()
        {
            Console.WriteLine("DA_MP_TC013 - Verify that the newly added main parent page is positioned at the location specified as set with \"Displayed After\" field of \"New Page\" form on the main page bar/\"Parent Page\" dropped down menu");

            //1. Navigate to Dashboard login page
            //2. Log in specific repository with valid account
            //3. Go to Global Setting->Add page
            //4. Enter Page Name field
            //5. Click OK button
            //6. Go to Global Setting->Add page
            //7. Enter Page Name field
            //8. Click on Displayed After dropdown list
            //9. Select specific page
            //10. Click OK button
            //11.VP Check "Another Test" page is positioned besides the "Test" page
            //Post - Condition  Delete newly added main child page and its parent page
            //    Close TA Dashboard Main Page

        }

        [TestMethod]
        public void DA_MP_TC014()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";
            string pagename = "Test";
            string user2 = "test";
            string pass2 = "admin";

            Console.WriteLine("DA_MP_TC014 - Verify that \"Public\" pages can be visible and accessed by all users of working repository");

            //1. Navigate to Dashboard login page
            //2. Log in specific repository with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3. Go to Global Setting->Add page
            //4. Enter Page Name field
            //5. Check Public checkbox
            //6. Click OK button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();
            page.PageName = pagename;
            page.IsPublic = true;

            dashboard = pages.addNewpage(page);
            dashboard.NavigatetoCurrentPage();

            //7. Click on Log out link
            //8. Log in with another valid account
            loginpage = dashboard.Logout();
            dashboard = loginpage.LoginWithValidUser(repo, user2, pass2);

            //9.  VP Check newly added page is visibled
            Assert.IsTrue(dashboard.isPageVisible(pagename));

            //Post. Log in  as creator page account and delete newly added page	
            //post. Close TA Dashboard Main Page
            loginpage = dashboard.Logout();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            dashboard.deleteAPage(pagename);
            dashboard.Close();
        }

        [TestMethod]
        public void DA_MP_TC015()
        {
            Console.WriteLine("Verify that non \"Public\" pages can only be accessed and visible to their creators with condition that all parent pages above it are \"Public\"");

            //1. Navigate to Dashboard login page
            //2. Log in specific repository with valid account
            //3. Go to Global Setting->Add page
            //4. Enter Page Name field
            //5. Check Public checkbox
            //6. Click OK button
            //7. Go to Global Setting->Add page
            //8. Enter Page Name field
            //9. Click on Select Parent dropdown list
            //10. Select specific page
            //11. Click OK button
            //12. Click on Log out link
            //13. Log in with another valid account
            //14. VP Check children is invisibled
            //Post - Condition  Log in  as creator page account and delete newly added page and its parent page
            //      Close TA Dashboard Main Page

        }
    }
}
