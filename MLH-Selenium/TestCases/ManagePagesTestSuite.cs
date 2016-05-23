using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLH_Selenium.PageObject;
using MLH_Selenium.ObjectData;
using MLH_Selenium.Common;

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

            //1    Navigate to Dashboard login page
            //2    Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo,user,pass);

            //3    Go to Global Setting->Add page
            //4    Try to go to Global Setting->Add page again
            //5    VP: User cannot go to Global Setting -> Add page while "New Page" dialog appears.
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
            string pagenext = "Overview";

            Console.WriteLine("DA_MP_TC012 - Verify that user is able to add additional pages besides \"Overview\" page successfully");

            //1    Navigate to Dashboard login page
            //2    Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Go to Global Setting->Add page
            //4    Enter Page Name field
            //5    Click OK button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);

            //6    VP "Test" page is displayed besides "Overview" page
            string actual = dashboard.getNamePageNextTo(pagenext);
            string expected = page.PageName;
            Assert.AreEqual(expected, actual);

            //Post - Condition  Delete newly added page
            //    Close TA Dashboard Main Page
            dashboard.deleteAPage(page.PageName);
            dashboard.Close();
        }

        [TestMethod]
        public void DA_MP_TC013()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_MP_TC013 - Verify that the newly added main parent page is positioned at the location specified as set with \"Displayed After\" field of \"New Page\" form on the main page bar/\"Parent Page\" dropped down menu");

            //1    Navigate to Dashboard login page
            //2    Log in specific repository with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Go to Global Setting->Add page
            //4    Enter Page Name field
            //5    Click OK button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page first = new Page();
            first.InitPageInformation();

            dashboard = pages.addNewpage(first);

            //6    Go to Global Setting->Add page
            //7    Enter Page Name field
            //8    Click on Displayed After dropdown list
            //9    Select specific page
            //10    Click OK button
            Page second = new Page();
            second.InitPageInformation();

            second.AfterPage = first.PageName;

            pages = dashboard.goToAddPage();
            dashboard = pages.addNewpage(second);

            //11.VP "Another Test" page is positioned besides the "Test" page
            string actual = dashboard.getNamePageNextTo(first.PageName);
            string expected = second.PageName;
            Assert.AreEqual(expected, actual);

            //Post - Condition  Delete newly added main child page and its parent page
            //    Close TA Dashboard Main Page
            dashboard.deleteAPage(second.PageName);
            dashboard.deleteAPage(first.PageName);
            dashboard.Close();       

        }

        [TestMethod]
        public void DA_MP_TC014()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";
            string user2 = "test";
            string pass2 = "admin";

            Console.WriteLine("DA_MP_TC014 - Verify that \"Public\" pages can be visible and accessed by all users of working repository");

            //1    Navigate to Dashboard login page
            //2    Log in specific repository with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Go to Global Setting->Add page
            //4    Enter Page Name field
            //5    Check Public checkbox
            //6    Click OK button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();
            page.IsPublic = true;

            dashboard = pages.addNewpage(page);

            //7    Click on Log out link
            //8    Log in with another valid account
            loginpage = dashboard.Logout();
            dashboard = loginpage.LoginWithValidUser(repo, user2, pass2);

            //9     VP newly added page is visibled
            Assert.IsTrue(dashboard.isPageLinkDisplayed(page.PageName));

            //Post    Log in  as creator page account and delete newly added page	
            //post    Close TA Dashboard Main Page
            loginpage = dashboard.Logout();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            dashboard.deleteAPage(page.PageName);
            dashboard.Close();
        }

        [TestMethod]
        public void DA_MP_TC015()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";
            string user2 = "test";
            string pass2 = "admin";

            Console.WriteLine("DA_MP_TC015 - Verify that non \"Public\" pages can only be accessed and visible to their creators with condition that all parent pages above it are \"Public\"");

            //1    Navigate to Dashboard login page
            //2    Log in specific repository with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Go to Global Setting->Add page
            //4    Enter Page Name field
            //5    Check Public checkbox
            //6    Click OK button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page first = new Page();
            first.InitPageInformation();
            first.IsPublic = true;

            dashboard = pages.addNewpage(first);

            //7    Go to Global Setting->Add page
            //8    Enter Page Name field
            //9    Click on Select Parent dropdown list
            //10    Select specific page
            //11    Click OK button
            Page second = new Page();
            second.InitPageInformation();

            second.AfterPage = first.PageName;

            pages = dashboard.goToAddPage();
            dashboard = pages.addNewpage(second);

            //12    Click on Log out link
            //13    Log in with another valid account
            loginpage = dashboard.Logout();
            dashboard = loginpage.LoginWithValidUser(repo, user2, pass2);

            //14    VP children is invisibled
            Assert.IsFalse(dashboard.isPageLinkDisplayed(second.PageName), "Error: Bug - child page is still displayed");
            //Post - Condition  Log in  as creator page account and delete newly added page and its parent page
            //      Close TA Dashboard Main Page
            dashboard.Logout();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            dashboard.deleteAPage(second.PageName);
            dashboard.deleteAPage(first.PageName);
            dashboard.Close();

        }

        [TestMethod]
        public void DA_MP_TC016()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";
            string user2 = "test";
            string pass2 = "admin";
            string popupName = "Edit Page";

            Console.WriteLine("DA_MP_TC016 - Verify that user is able to edit the \"Public\" setting of any page successfully");

            //1    Navigate to Dashboard login page
            //2    Log in specific repository with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Go to Global Setting->Add page
            //4    Enter Page Name
            //5    Click OK button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page first = new Page();
            first.InitPageInformation();
 
            dashboard = pages.addNewpage(first);

            //6    Go to Global Setting->Add page
            //7    Enter Page Name
            //8    Check Public checkbox
            //9    Click OK button
            Page second = new Page();
            second.InitPageInformation();

            second.AfterPage = first.PageName;
            second.IsPublic = true;

            pages = dashboard.goToAddPage();
            dashboard = pages.addNewpage(second);

            //10    Click on "Test" page
            //11    Click on "Edit" link
            //12    Check "Edit Page" pop up window is displayed
            pages = dashboard.gotoEditPage(first.PageName);
            pages.isPopUpDisplayed(popupName);

            //13    Check Public checkbox
            //14    Click OK button
            first.IsPublic = true;
            dashboard = pages.editPage(first);

            //15    Click on "Another Test" page
            //16    Click on "Edit" link
            //17    VP "Edit Page" pop up window is displayed
            pages = dashboard.gotoEditPage(second.PageName);
            pages.isPopUpDisplayed(popupName);

            //18    Uncheck Public checkbox
            //19    VP Click OK button
            second.IsPublic = false;
            dashboard = pages.editPage(second);

            //20    Click Log out link
            //21    Log in with another valid account
            loginpage = dashboard.Logout();
            dashboard = loginpage.LoginWithValidUser(repo, user2, pass2);

            //22    VP  "Test" Page is visible and can be accessed
            //23    VP  "Another Test" page is invisible
            Assert.IsTrue(dashboard.isPageLinkDisplayed(first.PageName), string.Format("Error: Page {0} is invisible", first.PageName));
            Assert.IsFalse(dashboard.isPageLinkDisplayed(second.PageName), string.Format("Error: Bug - Page {0} is visible", second.PageName));

            //Post - Condition  Log in  as creator page account and delete newly added page
            //Close TA Dashboard Main Page
            dashboard.Logout();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            dashboard.deleteAPage(second.PageName);
            dashboard.deleteAPage(first.PageName);
            dashboard.Close();

        }

        [TestMethod]
        public void DA_MP_TC017()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";
            string deletepage = "Are you sure you want to remove this page?";
            string firstpage = "Overview";

            Console.WriteLine("DA_MP_TC017 - Verify that user can remove any main parent page except \"Overview\" page successfully and the order of pages stays persistent as long as there is not children page under it");

            //1    Navigate to Dashboard login page
            //2    Log in specific repository with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Add a new parent page
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page parent = new Page();
            parent.InitPageInformation();

            dashboard = pages.addNewpage(parent);

            //4    Add a children page of newly added page
            Page child = new Page();
            child.InitPageInformation();

            child.ParentPage = parent.PageName;
            child.AfterPage = "Select page";

            pages = dashboard.goToAddPage();
            dashboard = pages.addNewpage(child);

            //5    Click on parent page
            //6    Click "Delete" link
            //7    VP confirm message "Are you sure you want to remove this page?" appears
            //8    Click OK button            
            string actualparent = dashboard.getDeletMessage(parent.PageName);
            string expectedparent = deletepage;
            Assert.AreEqual(expectedparent, actualparent);

            //9    VP warning message "Can not delete page 'Test' since it has children page(s)" appears
            //10   Click OK button
            string actualpopup = dashboard.GetAlertMessage().Trim();
            string expectedpopup = "Cannot delete page '" + parent.PageName + "' since it has child page(s).";
            Assert.AreEqual(expectedpopup, actualpopup);

            //11   Click on children page
            //12   Click "Delete" link
            //13   VP confirm message "Are you sure you want to remove this page?" appears
            //14   Click OK button
            //15   VP children page is deleted
            string actualchild = dashboard.getDeletMessage(parent.PageName + "/" + child.PageName);
            string expectedchild = deletepage;
            Assert.AreEqual(expectedchild, actualchild);
            Assert.IsFalse(dashboard.isPageLinkDisplayed(child.PageName), string.Format("Error: Page {0} still exists", child.PageName));

            //16   Click on parent page
            //17   Click "Delete" link
            //18   VP confirm message "Are you sure you want to remove this page?" appears
            //19   Click OK button
            //20   VP parent page is deleted
            dashboard.goToPage(parent.PageName);
            string actual = dashboard.getDeletMessage(parent.PageName);
            string expected = deletepage;
            Assert.AreEqual(expected, actual);
            Assert.IsFalse(dashboard.isPageLinkDisplayed(parent.PageName), string.Format("Error: Page {0} still exists", parent.PageName));

            //21   Click on "Overview" page
            //22   VP "Delete" link disappears
            dashboard.goToPage(firstpage);
            Assert.IsFalse(dashboard.checkDeleteLnk(), "Error: Delete link still exists");

            //Post - Condition  Close TA Dashboard Main Page
            dashboard.Close();
        }

        [TestMethod]
        public void DA_MP_TC018()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_MP_TC018 - Verify that user is able to add additional sibbling pages to the parent page successfully");

            //1    Navigate to Dashboard login page
            //2    Log in specific repository with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Go to Global Setting->Add page
            //4    Enter Page Name
            //5    Click OK button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page parent = new Page();
            parent.InitPageInformation();

            dashboard = pages.addNewpage(parent);

            //6    Go to Global Setting->Add page
            //7    Enter Page Name
            //8    Click on Parent Page dropdown list
            //9    Select a parent page
            //10   Click OK button
            Page child1 = new Page();
            child1.InitPageInformation();

            child1.ParentPage = parent.ParentPage;

            pages = dashboard.goToAddPage();
            dashboard = pages.addNewpage(child1);

            //11   Go to Global Setting->Add page
            //12   Enter Page Name
            //13   Click on Parent Page dropdown list
            //14   Select a parent page
            //15   Click OK button
            Page child2 = new Page();
            child2.InitPageInformation();

            child2.ParentPage = parent.ParentPage;

            pages = dashboard.goToAddPage();
            dashboard = pages.addNewpage(child2);

            //16  VP "Test Child 2" is added successfully
            Assert.IsTrue(dashboard.isPageLinkDisplayed(child2.PageName), string.Format("Error: Page {0} does not exist", child2.PageName));

            //Post - Condition  Log in  as creator page account and delete newly added page, its sibling page and parent page
            //    Close TA Dashboard Main Page
            dashboard.deleteAPage(child2.PageName);
            dashboard.deleteAPage(child1.PageName);
            dashboard.deleteAPage(parent.PageName);
            dashboard.Close();

        }

        [TestMethod]
        public void DA_MP_TC019()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_MP_TC019 - Verify that user is able to add additional sibbling page levels to the parent page successfully.");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Go to Global Setting->Add page
            //4    Enter info into all required fields on New Page dialog  
            //5   VP User is able to add additional sibbling page levels to parent page successfully. In this case: Overview is parent page of page 1
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page child = new Page();
            child.InitPageInformation();

            dashboard = pages.addNewpage(child);
            Assert.IsTrue(dashboard.isPageLinkDisplayed(child.PageName), string.Format("Error: Page {0} does not exist", child.PageName));

            //Post - Condition  Close TA Dashboard
            dashboard.Close();
        }

        [TestMethod]
        public void DA_MP_TC020()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_MP_TC020 - Verify that user is able to delete sibbling page as long as that page has not children page under it");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Go to Global Setting->Add page
            //4    Enter info into all required fields on New Page dialog    
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page first = new Page();
            first.InitPageInformation();

            dashboard = pages.addNewpage(first);

            //5    Go to Global Setting->Add page
            //6    Enter info into all required fields on New Page dialog  
            Page second = new Page();
            second.InitPageInformation();
            second.ParentPage = first.PageName;
            second.AfterPage = "Select page";

            pages = dashboard.goToAddPage();
            dashboard = pages.addNewpage(second);

            //7    Go to the first created page Page 1
            //8    Click Delete link
            //9    Click Ok button on Confirmation Delete page
            //10   VP There is a message "Can't delete page "page 1" since it has children page"
            //11   Close confirmation dialog
            string actual = dashboard.getDeletMessage(first.PageName);
            string actualpopup = dashboard.GetAlertMessage().Trim();
            string expectedpopup = "Cannot delete page '" + first.PageName + "' since it has child page(s).";
            Assert.AreEqual(expectedpopup, actualpopup);

            //12   Go to the second page
            //13   Click Delete link
            //14   Click Ok button on Confirmation Delete page
            //15  VP Page 2 is deleted successfully
            dashboard.deleteAPage(first.PageName + "/" + second.PageName);
            Assert.IsFalse(dashboard.isPageLinkDisplayed(second.PageName), string.Format("Error: Page {0} still exists", second.PageName));

            //Post - Condition  Close TA Dashboard
            dashboard.deleteAPage(first.PageName);
            dashboard.Close();

        }

        [TestMethod]
        public void DA_MP_TC021()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_MP_TC021 - Verify that user is able to edit the name of the page (Parent/Sibbling) successfully");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Go to Global Setting->Add page
            //4    Enter info into all required fields on New Page dialog
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page first = new Page();
            first.InitPageInformation();

            dashboard = pages.addNewpage(first);

            //5    Go to Global Setting->Add page
            //6    Enter info into all required fields on New Page dialog
            Page second = new Page();
            second.InitPageInformation();
            second.ParentPage = first.PageName;
            second.AfterPage = "Select page";

            pages = dashboard.goToAddPage();
            dashboard = pages.addNewpage(second);

            //7    Go to the first created page Page 1
            //8    Click Edit link
            //9    Enter another name into Page Name field
            //10   Click Ok button on Edit Page dialog
            //11   VP User is able to edit the name of parent page successfully
            pages = dashboard.gotoEditPage(first.PageName);
            first.PageName = Utilities.GenerateRandomString(5);

            dashboard = pages.editPage(first);

            string actualfirst = dashboard.getActivePageName();
            string expectedfirst = first.PageName;
            Assert.AreEqual(expectedfirst, actualfirst);
            Assert.IsTrue(dashboard.isPageVisible(first.PageName), string.Format("Error: Page {0} is visible", first.PageName));

            //12   Go to the second created page Page 2
            //13   Click Edit link
            //14   Enter another name into Page Name field 
            //15   Click Ok button on Edit Page dialog
            //16  VP User is able to edit the name of sibbling page successfully
            pages = dashboard.gotoEditPage(first.PageName + "/" + second.PageName);
            second.PageName = Utilities.GenerateRandomString(5);
            second.ParentPage = first.PageName;
            dashboard = pages.editPage(second);

            Assert.IsTrue(dashboard.isPageVisible(second.PageName), string.Format("Error: Page {0} is visible", second.PageName));

            //Post - Condition  Close TA Dashboard
            dashboard.deleteAPage(first.PageName + "/" + second.PageName);
            dashboard.deleteAPage(first.PageName);
            dashboard.Close();
        }

        [TestMethod]
        public void DA_MP_TC022()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_MP_TC022 - Verify that user is unable to duplicate the name of sibbling page under the same parent page");

            //1    Navigate to Dashboard login page
            //2    Log in specific repository with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Add a new page
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page parent = new Page();
            parent.InitPageInformation();

            dashboard = pages.addNewpage(parent);

            //4    Add a sibling page of new page
            Page child = new Page();
            child.InitPageInformation();
            child.ParentPage = parent.PageName;

            dashboard = pages.addNewpage(child);

            //6    Go to Global Setting->Add page
            //7    Enter Page Name
            //8    Click on Parent Page dropdown list
            //9    Select a parent page
            //10    Click OK button
            //11    VP warning message "Test child already exist    Please enter a diffrerent name" appears
            Page child2 = new Page();
            child2.InitPageInformation();

            child2.PageName = child.PageName;
            child2.ParentPage = parent.PageName;

            string actual = pages.addNewpage(child2).GetAlertMessage();
            string expected = child2.PageName + "already exist. Please enter a diffrerent name";

            //Post - Condition  Log in  as creator page account and delete newly added page and its parent page
            //      Close TA Dashboard Main Page
            dashboard.deleteAPage(child.PageName);
            dashboard.deleteAPage(parent.PageName);
            dashboard.Close();

        }

        [TestMethod]
        public void DA_MP_TC023()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_MP_TC023 - Verify that user is able to edit the parent page of the sibbling page successfully");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Go to Global Setting->Add page
            //4    Enter info into all required fields on New Page dialog  
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page parent = new Page();
            parent.InitPageInformation();

            dashboard = pages.addNewpage(parent);

            //5    Go to Global Setting->Add page
            //6    Enter info into all required fields on New Page dialog  
            Page child = new Page();
            child.InitPageInformation();
            child.ParentPage = parent.PageName;

            dashboard = pages.addNewpage(child);

            //7    Go to the first created page Page 1
            //8    Click Edit link
            //9    Enter another name into Page Name field Page name: Page 3
            //10    Click Ok button on Edit Page dialog
            //11     VP User is able to edit the parent page of the sibbling page successfully
            dashboard.goToPage(parent.PageName);

            parent.PageName = Utilities.GenerateRandomString(5);

            string actual = pages.editPage(parent).getActivePageName();
            string expected = parent.PageName;
            Assert.AreEqual(expected, actual);

            //Post - Condition     Close TA Dashboard
            dashboard.deleteAPage(child.PageName);
            dashboard.deleteAPage(parent.PageName);
            dashboard.Close();

        }

        [TestMethod]
        public void DA_MP_TC024()
        {
            Console.WriteLine("DA_MP_TC024 - Verify that \"Bread Crums\" navigation is correct");

            //1. Navigate to Dashboard login page
            //2. Login with valid account
            LoginPage loginPage = new LoginPage();
            loginPage.open();
            DashboardPage dashboardPage = loginPage.LoginWithValidUser(Constant.mainRepository, Constant.adminUser, Constant.adminPassword);

            //3. Go to Global Setting -> Add page            
            //4. Enter info into all required fields on New Page dialog            
            ManagePagesPage pages = dashboardPage.goToAddPage();
            Page page1 = new Page();
            page1.InitPageInformation();
            page1.ParentPage = "Overview";
            page1.PageName = "Page1" + Utilities.GenerateRandomString(6);
            page1.AfterPage = "Select page";
            page1.IsPublic = true;
            dashboardPage = pages.addNewpage(page1);            

            //5. Go to Global Setting -> Add page
            //6. Enter info into all required fields on New Page dialog
            pages = dashboardPage.goToAddPage();       
            Page page2 = new Page();
            page2.InitPageInformation();
            page2.ParentPage = "    " + page1.PageName;
            page2.PageName = "Page2" + Utilities.GenerateRandomString(6);
            page2.AfterPage = "Select page";
            page2.IsPublic = true;
            dashboardPage = pages.addNewpage(page2);

            //7. Click the first breadcrums
            //8. VP The first page is navigated
            dashboardPage.goToPage("Overview/" + page1.PageName);            
            Assert.AreEqual(true, dashboardPage.isPageVisible(page1.PageName), string.Format("Error: page '{0}' does not exist", page1.PageName));
            
            //9. Click the second breadcrums
            //10. VP The second page is navigated
            dashboardPage.goToPage("Overview/" + page1.PageName + "/" + page2.PageName);                        
            Assert.AreEqual(true, dashboardPage.isPageVisible(page2.PageName), string.Format("Error: page '{0}' does not exist", page2.PageName));

            //Post - Condition
            dashboardPage.deleteAPage("Overview/" + page1.PageName + "/" + page2.PageName);
            dashboardPage.deleteAPage("Overview/" + page1.PageName);
        }

        [TestMethod]
        public void DA_MP_TC025()
        {
            Console.WriteLine("DA_MP_TC025 - Verify that page listing is correct when user edit \"Display After\" field of a specific page");

            //1. Navigate to Dashboard login page
            //2. Login with valid account
            LoginPage loginPage = new LoginPage();
            loginPage.open();
            DashboardPage dashboardPage = loginPage.LoginWithValidUser(Constant.mainRepository, Constant.adminUser, Constant.adminPassword);

            //3. Go to Global Setting -> Add page            
            //4. Enter info into all required fields on New Page dialog            
            ManagePagesPage pages = dashboardPage.goToAddPage();
            Page page1 = new Page();
            page1.InitPageInformation();            
            page1.PageName = "Page1" + Utilities.GenerateRandomString(6);            
            dashboardPage = pages.addNewpage(page1);

            //5. Go to Global Setting -> Add page
            //6. Enter info into all required fields on New Page dialog
            pages = dashboardPage.goToAddPage();
            Page page2 = new Page();
            page2.InitPageInformation();            
            page2.PageName = "Page2" + Utilities.GenerateRandomString(6);            
            dashboardPage = pages.addNewpage(page2);

            //7. Click Edit link for the second created page
            //8. Change value Display After for the second created page to after Overview page
            //9. Click Ok button on Edit Page dialog
            page2.AfterPage = "Overview";
            pages.gotoEditPage(page2.PageName);
            dashboardPage = pages.editPage(page2);

            //10. VP Position of the second page follow Overview page      
            string actual = dashboardPage.getNamePageNextTo("Overview");
            Assert.AreEqual(page2.PageName, actual, "Error: Postion of the second page does not follow Overview page");

            //Post - Condition
            dashboardPage.deleteAPage(page2.PageName);
            dashboardPage.deleteAPage(page1.PageName);
        }

        [TestMethod]
        public void DA_MP_TC026()
        {
            Console.WriteLine("DA_MP_TC026 - Verify that page column is correct when user edit \"Number of Columns\" field of a specific page");

            //1. Navigate to Dashboard login page
            //2. Login with valid account
            LoginPage loginPage = new LoginPage();
            loginPage.open();
            DashboardPage dashboardPage = loginPage.LoginWithValidUser(Constant.mainRepository, Constant.adminUser, Constant.adminPassword);

            //3. Go to Global Setting -> Add page            
            //4. Enter info into all required fields on New Page dialog            
            ManagePagesPage pages = dashboardPage.goToAddPage();
            Page page1 = new Page();
            page1.InitPageInformation();
            page1.PageName = "Page1" + Utilities.GenerateRandomString(6);
            page1.NumberOfColumns = 2;
            dashboardPage = pages.addNewpage(page1);

            //5. Go to Global Setting -> Edit link
            //6. Edit Number of Columns for the above created page
            //7. Click Ok button on Edit Page dialog
            page1.NumberOfColumns = 3;
            pages.gotoEditPage(page1.PageName);
            dashboardPage = pages.editPage(page1);

            //8. VP Observe the current page      
            int actual = dashboardPage.getTotalColumns(page1.PageName);
            Assert.AreEqual(3, actual, string.Format("Error: Page '{0}' has {1} columns", page1.PageName, actual));

            //Post - Condition            
            dashboardPage.deleteAPage(page1.PageName);
        }
    }
}
