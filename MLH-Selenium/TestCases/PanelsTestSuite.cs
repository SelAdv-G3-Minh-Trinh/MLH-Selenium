using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLH_Selenium.PageObject;
using MLH_Selenium.ObjectData;
using MLH_Selenium.Common;

namespace MLH_Selenium.TestCases
{

    [TestClass]
    public class PanelsTestSuite : TestBase
    {
        public void DA_PANEL_TC027()
        {
            Console.WriteLine("DA_PANEL_TC027 - Verify that when \"Choose panels\" form is expanded all pre-set panels are populated and sorted correctly ");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            //3    Go to Global Setting->Add page
            //4    Enter page name to Page Name field.	Page 1
            //5    Click OK button
            //6    Go to Global Setting->Create Panel
            //7    Enter Panel name into Display Name textbox
            //8    Select any value in Series* dropdown list. Click Ok button		
            //9    Click Ok button in Panel Configuration popup
            //10   Click on Choose Panel menu icon next to Global Setting icon
            //11   VP Verify that all pre - set panels are populated and sorted correctly       
            //post - condition  delete the created page
            //    close dashboard
        }

        [TestMethod]
        public void DA_PANEL_TC028()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC028 - Verify that when \"Add New Panel\" form is on focused all other control/form is disabled or locked.");


            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Click Administer link
            //4    Click Panel link
            //5    Click Add New link
            //6    Try to click other controls when Add New Panel dialog is opening
            //7    VP All control / form are disabled or locked when Add New Panel dialog is opening
            PanelPage panel = new PanelPage();

            dashboard.goToPage("Administer/Panels");
            panel = dashboard.gotoAddPanel();

            Assert.IsFalse(panel.isItemEnable(), "All control/form are not disabled or locked");

            //Post - Condition  Close TA Dashboard
            panel.Close();
        }

        [TestMethod]
        public void DA_PANEL_TC029()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC029 - Verify that user is unable to create new panel when (*) required field is not filled");

            //1    Navigate to Dashboard
            //2    Select specific repository
            //3    Enter valid username and password
            //4    Click on Login button
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //5    Click on Administer/ Panels link
            //6    Click on "Add new" link
            //7    Click on OK button
            //8    VP Warning message: "Display Name is required field" show up
            PanelPage panels = new PanelPage();
            dashboard.goToPage("Administer/Panels");
            panels = dashboard.gotoAddPanel();

            Panel panel = new Panel();
            panel.DisplayName = "";

            string actual = panels.addNewPanelInfo(panel).GetAlertMessage();
            string expected = "Display Name is a required field.";

            Assert.AreEqual(expected, actual);

            //Post - Condition  Logout
            //      Close Dashboard
            dashboard.Close();
        }

        [TestMethod]
        public void DA_PANEL_TC030()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC030 - Verify that no special character except '@' character is allowed to be inputted into \"Display Name\" field");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Click Administer link
            //4    Click Panel link
            //5    Click Add New link
            //6    Enter value into Display Name field with special characters except "@"  Display Name: Logigear#$%	
            //7    Click Ok button
            //8    VP Message "Invalid display name. The name can't contain high ASCII characters or any of following characters: /:*?<>|"#{[]{};" is displayed
            //9    Close Warning Message box
            PanelPage panels = new PanelPage();
            dashboard.goToPage("Administer/Panels");
            panels = dashboard.gotoAddPanel();

            Panel panel = new Panel();
            panel.DisplayName = "Logigear#$%";

            string actual = panels.addNewPanelInfo(panel).GetAlertMessage();
            string expected = "Invalid display name. The name cannot contain high ASCII characters or any of the following characters: /:*?<>|\"#[]{}=%;";

            Assert.AreEqual(expected, actual);

            //10   Click Add New link
            //11   Enter value into Display Name field with special character is @	Display Name: Logigear@	
            //12   VP new panel is created
            panel.DisplayName = "Logigear@";
            Assert.IsTrue(panels.addNewPanelInfo(panel).isPageLinkDisplayed(panel.DisplayName), "Panel is not created");

            //Post - Condition  Close TA Dashboard
            dashboard.Close();
        }

        public void DA_PANEL_TC031()
        {
            Console.WriteLine("DA_PANEL_TC031 - Verify that correct panel setting form is displayed with corresponding panel type selected");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            //3    Click on Administer/ Panels link
            //4    Click on Add new link
            //5    VP Chart panel setting form is displayed "chart setting" under Display Name field
            //6    Select Indicator type
            //7    VP indicator panel setting form is displayed "Indicator setting" under Display Name field
            //8    Select Report type
            //9    VP Report panel setting form is displayed "View mode" under Display Name.
            //Post - Condition  Delete all panels created
            //                  Delete the created page
        }

        [TestMethod]
        public void DA_PANEL_TC032()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC032 - Verify that user is not allowed to create panel with duplicated \"Display Name\"");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Click on Administer/ Panels link
            //4    Click on Add new link
            //5    Enter display name to "Display name" field.Duplicated panel
            //6    Click on OK button
            PanelPage panels = new PanelPage();
            dashboard.goToPage("Administer/Panels");
            panels = dashboard.gotoAddPanel();

            Panel panel = new Panel();
            panel.DisplayName = "Duplicated panel";

            panels.addNewPanelInfo(panel);

            //7    Click on Add new link again.
            //8    Enter display name same with previous display name to "display name" field.Duplicated panel
            //9    Click on OK button
            //10   VP Warning message: "Dupicated panel already exists. Please enter a different name" show up
            panels.goToAddPage();

            string actual = panels.addNewPanelInfo(panel).GetAlertMessage();
            string expected = "Dupicated panel already exists. Please enter a different name";

            Assert.AreEqual(expected, actual);
            //Post - Condition  Delete "Duplicated panel" panel
            //                  Close Dashboard
            dashboard.Close();
        }

        public void DA_PANEL_TC033()
        {
            Console.WriteLine("DA_PANEL_TC033 - Verify that \"Data Profile\" listing of \"Add New Panel\" and \"Edit Panel\" control/form are in alphabetical order");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            //3    Click on Administer/ Panels link
            //4    Click on Add new link
            //5    VP Data Profile list is in alphabetical order
            //6    Enter a display name to display name field giang -panel
            //7    Click on OK button
            //8    Click on Edit link
            //9    VP Data Profile list is in alphabetical order
            //Post - Condition  Delete "giang - panel" panel
        }

        public void DA_PANEL_TC034()
        {
            Console.WriteLine("DA_PANEL_TC034 - Verify that newly created data profiles are populated correctly under the \"Data Profile\" dropped down menu in  \"Add New Panel\" and \"Edit Panel\" control/form");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            //3    Click on Administer/ Data Profiles link
            //4    Click on add new link
            //5    Enter name to Name textbox 
            //6    Click on Finish button
            //7    Click on Administer/ Panels link
            //8    Click on add new link
            //9    VP Verify that "giang - data" data profiles are populated correctly under the "Data Profile" dropped down menu.
            //10   Enter display name to Display Name textbox
            //11   Click Ok button to create a panel
            //12   Click on edit link
            //13   VP Verify that "giang - data" data profiles are populated correctly under the "Data Profile" dropped down menu.
            //Post - Condition  Delete "giang - data" data profiles
            //                  Delete "giang - panel" panel
        }

        [TestMethod]
        public void DA_PANEL_TC035()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC035 - Verify that no special character except '@' character is allowed to be inputted into \"Chart Title\" field");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3    Click Administer link
            //4    Click Panel link
            //5    Click Add New link
            //6    Enter value into Display Name field Display Name: Logigear
            //     Enter value into Chart Title field with special characters except "@"   Chart Title: Chart#$%	
            //7    Click Ok button
            //8    VP Message "Invalid display name. The name can't contain high ASCII characters or any of following characters: /:*?<>|"#{[]{};" is displayed
            //9    Close Warning Message box
            PanelPage panels = new PanelPage();
            dashboard.goToPage("Administer/Panels");
            panels = dashboard.gotoAddPanel();

            Panel panel = new Panel();
            panel.TypeOfPanel = "Chart";
            panel.DisplayName = "Chart#$%";

            string actual = panels.addNewPanelInfo(panel).GetAlertMessage();
            string expected = "Invalid display name. The name cannot contain high ASCII characters or any of the following characters: /:*?<>|\"#[]{}=%;";

            Assert.AreEqual(expected, actual);

            //10   Click Add New link
            //11   Enter value into Display Name field Display Name: Logigear@	
            //     Enter value into Chart Title field with special character is @	Char Title: Chart@	
            panel.DisplayName = "Chart@";
            Assert.IsTrue(panels.addNewPanelInfo(panel).isPageLinkDisplayed(panel.DisplayName), "Panel is not created");

            //12    VP the new panel is created
            //Post - Condition  Delete the newly created panel
            //                  Close TA Dashboard
            dashboard.Close();
        }

        /// <exclude />
        [TestMethod]
        public void DA_PANEL_TC036()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC036 - Verify that all chart types ( Pie, Single Bar, Stacked Bar, Group Bar, Line ) are listed correctly under \"Chart Type\" dropped down menu.");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository Dashboard_STT
            //3    Enter valid Username and Password   hung.nguyen / (empty)
            //4    Click 'Login' button
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //5    Click 'Add Page' link
            //6    Enter Page Name main_hung
            //7    Click 'OK' button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);
            //8    Click 'Choose Panels' button
            //9    Click 'Create new panel' button
            PanelPage panels = new PanelPage();
            panels = dashboard.goToAddPanelByChoosePanel();

            //10   Click 'Chart Type' drop - down menu
            //11   VP 'Chart Type' are listed 5 options: 'Pie', 'Single Bar', 'Stacked Bar', 'Group Bar' and 'Line'
            Assert.IsTrue(panels.checkChartType(), "Chart Type is not 5 options");
            panels.Close();
        }

        [TestMethod]
        public void DA_PANEL_TC040()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC040 - Verify that all \"Data Labels\" check boxes are enabled and disabled correctly corresponding to each type of \"Chart Type\"");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository
            //3    Enter valid Username and Password
            //4    Click 'Login' button
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //5    Click 'Add Page' button
            //6    Enter Page Name
            //7    Click 'OK' button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);
            //8    Click 'Choose Panels' button below 'main_hung' button
            //9    Click 'Create new panel' button
            PanelPage panels = new PanelPage();
            panels = dashboard.goToAddPanelByChoosePanel();
            //10   Click 'Chart Type' drop - down menu
            //11   Select 'Pie' Chart Type
            //12   VP 'Categories' checkbox is disabled, 'Series' checkbox, 'Value' checkbox and 'Percentage' checkbox are enabled
            panels.selectChartType("Pie");

            Assert.IsFalse(panels.isDataLabelsCategoriesCheckboxEnable(), "Categories checkbox is enable");
            Assert.IsTrue(panels.isDataLabelsSeriesCheckboxEnable(), "Series checkbox is disable");
            Assert.IsTrue(panels.isDataLabelsValuesCheckboxEnable(), "Values checkbox is disable");
            Assert.IsTrue(panels.isDataLabelsPercentageCheckboxEnable(), "Percentage checkbox is disable");
            //13   Click 'Chart Type' drop - down menu
            //14   Select 'Single Bar' Chart Type
            //15   VP 'Categories' checkbox is disabled, 'Series' checkbox, 'Value' checkbox and 'Percentage' checkbox are enabled
            panels.selectChartType("Single Bar");

            Assert.IsFalse(panels.isDataLabelsCategoriesCheckboxEnable(), "Categories checkbox is enable");
            Assert.IsTrue(panels.isDataLabelsSeriesCheckboxEnable(), "Series checkbox is disable");
            Assert.IsTrue(panels.isDataLabelsValuesCheckboxEnable(), "Values checkbox is disable");
            Assert.IsTrue(panels.isDataLabelsPercentageCheckboxEnable(), "Percentage checkbox is disable");
            //16   Click 'Chart Type' drop - down menu
            //17   Select 'Stacked Bar' Chart Type
            //18   VP 'Categories' checkbox, 'Series' checkbox, 'Value' checkbox and 'Percentage' checkbox are enabled
            panels.selectChartType("Stacked Bar");

            Assert.IsTrue(panels.isDataLabelsCategoriesCheckboxEnable(), "Categories checkbox is disable");
            Assert.IsTrue(panels.isDataLabelsSeriesCheckboxEnable(), "Series checkbox is disable");
            Assert.IsTrue(panels.isDataLabelsValuesCheckboxEnable(), "Values checkbox is disable");
            Assert.IsTrue(panels.isDataLabelsPercentageCheckboxEnable(), "Percentage checkbox is disable");
            //19   Click 'Chart Type' drop - down menu
            //20   Select 'Group Bar' Chart Type
            //21   VP Categories' checkbox, 'Series' checkbox, 'Value' checkbox and 'Percentage' checkbox are enabled
            panels.selectChartType("Group Bar");

            Assert.IsTrue(panels.isDataLabelsCategoriesCheckboxEnable(), "Categories checkbox is disable");
            Assert.IsTrue(panels.isDataLabelsSeriesCheckboxEnable(), "Series checkbox is disable");
            Assert.IsTrue(panels.isDataLabelsValuesCheckboxEnable(), "Values checkbox is disable");
            Assert.IsTrue(panels.isDataLabelsPercentageCheckboxEnable(), "Percentage checkbox is disable");
            //22   Click 'Chart Type' drop - down menu
            //23   Select 'Line' Chart Type
            //24   VP 'Categories' checkbox, 'Series' checkbox, 'Value' checkbox and 'Percentage' checkbox are disabled
            panels.selectChartType("Line");

            Assert.IsFalse(panels.isDataLabelsCategoriesCheckboxEnable(), "Categories checkbox is enable");
            Assert.IsFalse(panels.isDataLabelsSeriesCheckboxEnable(), "Series checkbox is enable");
            Assert.IsFalse(panels.isDataLabelsValuesCheckboxEnable(), "Values checkbox is enable");
            //    Assert.IsFalse(panels.isDataLabelsPercentageCheckboxEnable(), "Percentage checkbox is enable");
        }

        public void DA_PANEL_TC041()
        {
            Console.WriteLine("DA_PANEL_TC041 - Verify that all settings within \"Add New Panel\" and \"Edit Panel\" form stay unchanged when user switches between \"Data Labels\" check boxes buttons");

            //1    Navigate to Dashboard login page
            //2    Login with valid account
            //3    Click Administer link
            //4    Click Panel link
            //5    Click Add New link
            //6    Check Series checkbox for Data Labels
            //7    VP  All settings are unchange in Add New Panel dialog
            //8    Uncheck Series checkbox
            //9    Check Value checkbox for Data Labels
            //10   VP  All settings are unchange in Add New Panel dialog
            //11   Uncheck Value checkbox
            //12   Check Percentage checbox for Data Labels
            //13   VP  All settings are unchange in Add New Panel dialog
            //14   Uncheck Percentage checkbox
            //15   Create a new panel
            //16   Click Edit Panel link
            //17   Check Series checkbox for Data Labels
            //18   VP  All settings are unchange in Edit New Panel dialog
            //19   Uncheck Series checkbox
            //20   Check Value checkbox for Data Labels
            //21   VP  All settings are unchange in Edit New Panel dialog
            //22   Uncheck Value checkbox
            //23   Check Percentage checbox for Data Labels
            //24   VP  All settings are unchange in Edit New Panel dialog
            //Post - Condition  Delete the newly create panel
            //Close TA Dashboard
        }

        [TestMethod]
        public void DA_PANEL_TC042()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC042 - Verify that all pages are listed correctly under the \"Select page * \" dropped down menu of \"Panel Configuration\" form/ control");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository
            //3    Enter valid Username and Password
            //4    Click 'Login' button
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //5    Click 'Add Page' button
            //6    Enter Page Name
            //7    Click 'OK' button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page1 = new Page();
            page1.InitPageInformation();

            dashboard = pages.addNewpage(page1);
            //8    Click 'Add Page' button
            //9    Enter Page Name
            //10   Click 'OK' button
            pages = dashboard.goToAddPage();

            Page page2 = new Page();
            page1.InitPageInformation();

            dashboard = pages.addNewpage(page2);
            //11   Click 'Add Page' button
            //12   Enter Page Name
            //13   Click 'OK' button
            pages = dashboard.goToAddPage();

            Page page3 = new Page();
            page1.InitPageInformation();

            dashboard = pages.addNewpage(page3);
            //14   Click 'Choose panels' button
            //15   Click on any Chart panel instance
            //16   Click 'Select Page*' drop - down menu
            //17   VP 'Select Page*' drop - down menu contains 3 items: 'main_hung1', 'main_hung2' and 'main_hung3'
            PanelPage panels = new PanelPage();
            panels.goToPanelConfigPage("Test&nbsp;Case&nbsp;Execution&nbsp;Failure&nbsp;Trend");

            Assert.IsTrue(panels.isItemBelongsToSelectPage(page1.PageName), "Item does not display in drop down list");
            Assert.IsTrue(panels.isItemBelongsToSelectPage(page2.PageName), "Item does not display in drop down list");
            Assert.IsTrue(panels.isItemBelongsToSelectPage(page3.PageName), "Item does not display in drop down list");
        }

        [TestMethod]
        public void DA_PANEL_TC043()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC043 - Verify that only integer number inputs from 300-800 are valid for \"Height * \" field ");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository
            //3    Enter valid Username and Password
            //4    Click 'Login' button
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //5    Click 'Add Page' button
            //6    Enter Page Name
            //7    Click 'OK' button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);
            //11   Click 'Choose panels' button
            //12   Click on any Chart panel instance
            //13   Enter integer number to 'Height *' field
            //14   Click OK button
            //15   VP Check that error message 'Panel height must be greater than or equal to 300 and lower than or equal to 800' display
            //16   Click OK button
            PanelPage panels = new PanelPage();
            panels = dashboard.goToPanelConfigPage("Test&nbsp;Case&nbsp;Execution&nbsp;Failure&nbsp;Trend");

            Panel panel = new Panel();
            panel.InitPanelInformation();
            panel.Height = "299";

            string actual1 = panels.addNewPageConfig(panel).GetAlertMessage();
            string expected1 = "Panel height must be greater than or equal to 300 and lower than or equal to 800";
            Assert.AreEqual(expected1, actual1);
            //17   Enter integer number to 'Height *' field
            //18   Click OK button
            //19   VP Check that error message 'Panel height must be greater than or equal to 300 and lower than or equal to 800' display
            //20   Click OK button
            panel.Height = "801";

            string actual2 = panels.addNewPageConfig(panel).GetAlertMessage();
            string expected2 = "Panel height must be greater than or equal to 300 and lower than or equal to 800";
            Assert.AreEqual(expected2, actual2);
            //21   Enter integer number to 'Height *' field
            //23   Click OK button
            //24   VP Check that error message 'Panel height must be greater than or equal to 300 and lower than or equal to 800' display
            //25   Click OK button
            panel.Height = "-2";

            string actual3 = panels.addNewPageConfig(panel).GetAlertMessage();
            string expected3 = "Panel height must be greater than or equal to 300 and lower than or equal to 800";
            Assert.AreEqual(expected3, actual3);
            //26   Enter integer number to 'Height *' field
            //27   Click OK button
            //28   Check that error message 'Panel height must be an integer number' display
            //29   Click OK button
            panel.Height = "3.1";

            string actual4 = panels.addNewPageConfig(panel).GetAlertMessage();
            string expected4 = "Panel height must be greater than or equal to 300 and lower than or equal to 800";
            Assert.AreEqual(expected4, actual4);
            //30   Enter integer number to 'Height *' field
            //31   Click OK button
            //32   VP Check that error message 'Panel height must be an integer number' display
            panel.Height = "abc";

            string actual = panels.addNewPageConfig(panel).GetAlertMessage();
            string expected = "Panel height must be greater than or equal to 300 and lower than or equal to 800";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DA_PANEL_TC044()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC044 - Verify that \"Height * \" field is not allowed to be empty");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository
            //3    Enter valid Username and Password
            //4    Click 'Login' button
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //5    Click 'Add Page' button
            //6    Enter Page Name
            //7    Click 'OK' button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);
            //11   Click 'Choose panels' button
            //12   Click on any Chart panel instance
            //13   Leave 'Height *' field empty
            //14   Click OK button
            //15   VP Check that 'Panel height is required field' message display
            PanelPage panels = new PanelPage();
            panels = dashboard.goToPanelConfigPage("Test&nbsp;Case&nbsp;Execution&nbsp;Failure&nbsp;Trend");

            Panel panel = new Panel();
            panel.InitPanelInformation();
            panel.Height = "";

            string actual = panels.addNewPageConfig(panel).GetAlertMessage();
            string expected = "Panel height is required fieldPanel height is required field";
            Assert.AreEqual(expected, actual);
        }

        public void DA_PANEL_TC045()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC045 - Verify that \"Folder\" field is not allowed to be empty");

            //1    Navigate to Dashboard login page
            //2    Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3    Create a new page
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);

            //4    Click Choose Panel button
            //5    Click Create New Panel button
            //6    Enter all required fields on Add New Panel page
            //7    Click Ok button
            PanelPage panels = new PanelPage();
            panels = dashboard.goToAddPanelByChoosePanel();

            Panel panel = new Panel();
            panel.InitPanelInformation();
            panels = panels.addNewPanelInfo(panel);
            //8    Leave empty on Folder field
            //9    Click Ok button on Panel Configuration dialog
            //10   VP There is message "Panel folder is incorrect"
            panel.Folder = "";

            string actual = panels.addNewPageConfig(panel).GetAlertMessage();
            string expected = "Panel folder is incorrect";
            Assert.AreEqual(expected, actual);
            //Post - Condition  Delete the newly created panel, page
            //Close TA Dashboard
        }

        public void DA_PANEL_TC046()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC046 - Verify that only valid folder path of corresponding item type ( e.g. Actions, Test Modules) are allowed to be entered into \"Folder\" field");

            //1    Navigate to Dashboard login page
            //2    Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3    Create a new page
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);

            //4    Click Choose Panel button
            //5    Click Create New Panel button
            //6    Enter all required fields on Add New Panel page
            //7    Click Ok button
            PanelPage panels = new PanelPage();
            panels = dashboard.goToAddPanelByChoosePanel();

            Panel panel = new Panel();
            panel.InitPanelInformation();
            panels = panels.addNewPanelInfo(panel);
            //8    Leave empty on Folder field
            //9    Click Ok button on Panel Configuration dialog
            //10   VP There is message "Panel folder is incorrect"
            panel.Folder = "";

            string actual = panels.addNewPageConfig(panel).GetAlertMessage();
            string expected = "Panel folder is incorrect";
            Assert.AreEqual(expected, actual);

            //11   Enter valid folder path
            //12   Click Ok button on Panel Configuration dialog
            //13   VP The new panel is created
            panel.Folder = "/Car Rental/Actions";

            Assert.IsTrue(panels.addNewPageConfig(panel).isPanelCreated(panel.DisplayName));
            //Post - Condition  Delete the newly created panel, page
            //Close TA Dashboard

        }

        public void DA_PANEL_TC047()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC047 - Verify that user is able to navigate properly to folders with \"Select Folder\" form");

            //1    Navigate to Dashboard login page
            //2    Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3    Create a new page
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);

            //4    Click Choose Panel button
            //5    Click Create New Panel button
            //6    Enter all required fields on Add New Panel page
            //7    Click Ok button
            PanelPage panels = new PanelPage();
            panels = dashboard.goToAddPanelByChoosePanel();

            Panel panel = new Panel();
            panel.InitPanelInformation();
            panels = panels.addNewPanelInfo(panel);
            //8    Click Select Folder button on Panel Configuration dialog
            //9    Choose folder name in Folder Form
            //10   Click Ok button on Select Folder form
            panels.selectFolderName("/Car Rental");
            //11   VP User is able to select properly folder with Select Folder form
            //Post - Condition  Close TA Dashboard

        }

        public void DA_PANEL_TC048()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC048 - Verify that population of corresponding item type ( e.g. Actions, Test Modules) folders is correct in \"Select Folder form");

            //1    Navigate to Dashboard login page
            //2    Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3    Create a new page
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);

            //4    Click Choose Panel button
            //5    Click Create New Panel button
            //6    Enter all required fields on Add New Panel page
            //7    Click Ok button
            PanelPage panels = new PanelPage();
            panels = dashboard.goToAddPanelByChoosePanel();

            Panel panel = new Panel();
            panel.InitPanelInformation();
            panels = panels.addNewPanelInfo(panel);
            //8    Click Select Folder button on Panel Configuration dialog
            string folder = "/Car Rental";
            panels.selectFolderName(folder);

            //11   VP Population of corresponding item type (e.g.Actions, Test Modules) folders is correct in "Select Folder form
            Assert.AreEqual(folder, panels.getFolderText());
            //Post - Condition  Close TA Dashboard
        }

        public void DA_PANEL_TC049()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC049 - Verify that all folder paths of corresponding item type ( e.g. Actions, Test Modules) are correct in \"Select Folder\" form ");

            //1    Navigate to Dashboard login page
            //2    Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3    Create a new page
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);

            //4    Click Choose Panel button
            //5    Click Create New Panel button
            //6    Enter all required fields on Add New Panel page
            //7    Click Ok button
            PanelPage panels = new PanelPage();
            panels = dashboard.goToAddPanelByChoosePanel();

            Panel panel = new Panel();
            panel.InitPanelInformation();
            panels = panels.addNewPanelInfo(panel);
            //8    Click Select Folder button on Panel Configuration dialog
            //9    Choose folder name in Folder Form
            //10   Click Ok button on Select Folder form
            //11   VP Folder path is displayed correctly after selecting folder in Select Folder form
            string folder = "/Car Rental";
            panels.selectFolderName(folder);

            Assert.AreEqual(folder, panels.getFolderText());
            //Post - Condition  Delete the newly created page and panel
            //Close TA Dashboard
        }

        public void DA_PANEL_TC050()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";
            Console.WriteLine("DA_PANEL_TC050 - Verify that user is able to successfully edit \"Display Name\" of any Panel providing that the name is not duplicated with existing Panels' name");

            //1     Navigate to Dashboard login page
            //2     Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3     Click Administer link
            //4     Click Panel link
            //5     Click Add New link
            dashboard.GotoAddPanels();
            //6   Step Enter a valid name into Display Name field
            //7   VP The new panel is created successfully
            //Post - Condition  Delete the newly created panel
            //Close TA Dashboard
        }

        [TestMethod]
        public void DA_PANEl_TC51()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC051 - Verify that user is unable to change \"Display Name\" of any Panel if there is special character except '@' inputted");
            //1     Navigate to Dashboard login page
            //2     Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3     Click Administer link
            //4     Click Panel link
            //5     Click Add New link
            dashboard.GotoAddPanels();
            //6     Create a new panel
            PanelPage panelpage = new PanelPage();
            panelpage.CreatePanel("Logigear", "Name");
            //7     Click Edit link
            //8     Edit panel name with special characters
            //9     Click Ok button

            //10    VP. Observe the current page
            string actual = panelpage.EditPanel("test#$").GetAlertMessage();
            string expected = "Invalid display name. The name can't contain high ASCII characters or any of following characters: /:*?<>|\"#{[]{};";
            Assert.AreEqual(expected, actual);
            //11    Close warning message box

            //12    Click Edit link
            //13    Edit panel name with special character is @
            //14    Click Ok button
            panelpage.EditPanel("test@");
            //15    VP. Observe the current page

            actual = panelpage.EditPanel("test#$").GetDisplayName("test@");
            expected = "test@";
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void DA_PANEl_TC52()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC052 - Verify that user is unable to edit  \"Height * \" field to anything apart from integer number with in 300-800 range");
            //1     Navigate to Dashboard login page
            //2     Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //3      Create a new page            
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            //4      Click Choose Panel button
            //5      Click Create New Panel button
            //6      Enter all required fields on Add New Panel page
            //7      Click Ok button
            //8      Enter invalid height into Height field
            //9      Click Ok button
            PanelPage panels = new PanelPage();
            panels = dashboard.goToAddPanelByChoosePanel();

            Panel panel = new Panel();
            panel.AddPanel("Chart", "Name", "200", "/Car Rental/Actions");
            panels = panels.addNewPanelInfo(panel).addNewPageConfig(panel);

            //10     Observe the current page
            //string actual = panel.AddPanel("Chart", "Name", "200", "/Car Rental/Actions").GetAlertMessage();
            //string expected = "Panel Height must be greater than or equal to 300 and lower than or equal to 800";
            //Assert.AreEqual(expected, actual);
            //11     Close Warning Message box

            //12     Enter valid height into Height field
            //13     Click Ok button
            //14     Observe the current page
        }

        [TestMethod]
        public void DA_PANEl_TC53()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC053 - Verify that newly created panel are populated and sorted correctly in Panel lists under \"Choose panels\" form");
            //1     Navigate to Dashboard login page
            //2     Select a specific repository
            //3     Enter valid Username and Password
            //4     Click 'Login' button
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //5     Click 'Add Page' button
            //6     Enter Page Name
            //7     Click 'OK' button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);
            //8     Click 'Choose Panels' button below 'main_hung' button
            //9     Click 'Create new panel' button
            //10    Enter a name to Display Name
            //11    Click OK button
            PanelPage panels = new PanelPage();
            panels = dashboard.goToAddPanelByChoosePanel();

            Panel panel = new Panel();
            panel.InitPanelInformation();
            panels = panels.addNewPanelInfo(panel);
            //12    Click Cancel button
            panels.PanelConfigurationCancel_Btn.Click();
            //13    Click 'Create new panel' button
            //14    Enter a name to Display Name
            //15    Click OK button
            panels.CreatePanel_Btn.Click();
            panel.InitPanelInformation();
            panels = panels.addNewPanelInfo(panel);
            //16    Click Cancel button
            panels.PanelConfigurationCancel_Btn.Click();
            //17    Click 'Create new panel' button
            //18    Select 'Type' radio button
            //19    Enter a name to Display Name
            //20    Click OK button
            //21    Click Cancel button
            //22    Click 'Create new panel' button
            //23    Select 'Type' radio button
            //24    Enter a name to Display Name
            //25    Click OK button
            //26    Click Cancel button
            //27    Click main_hung button
            //28    Click 'Choose Panels' button below 'main_hung' button
            //29    Check that 'hung_chart_a' panel and 'hung_chart_b' panel are existed in Chart section of 'Choose panels' form
            //30    Check that 'hung_report' panel is existed in Report section of 'Choose panels' form
            //31    Check that 'hung_indicator' panel is existed in Indicator section of 'Choose panels' form
            //32    Check that 'hung_chart_a' panel is placed before 'hung_chart_b' panel
        }

        [TestMethod]
        public void DA_PANEl_TC54()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC054 - Verify that user is able to successfully edit \"Folder\" field with valid path");
            //1     Navigate to Dashboard login page
            //2     Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3     Create a new page
            //4     Create a new panel
            //5     Click Choose Panel button
            //6     Click on the newly created panel link
            //7     Edit valid folder path
            //8     Click Ok button
            //9     Observe the current page
        }

        [TestMethod]
        public void DA_PANEl_TC55()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC055 - Verify that user is unable to edit \"Folder\" field with invalid path");
            //1     Navigate to Dashboard login page
            //2     Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3     Create a new page
            //4     Create a new panel
            //5     Click Choose Panel button
            //6     Click on the newly created panel link
            //7     Edit valid folder path
            //8     Click Ok button
            //9     Observe the current page
        }

        [TestMethod]
        public void DA_PANEl_TC56()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC056 - Verify that user is unable to edit \"Folder\" field with empty value");
            //1     Navigate to Dashboard login page
            //2     Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3     Create a new page
            //4     Create a new panel
            //5     Click Choose Panel button
            //6     Click on the newly created panel link
            //7     Edit valid folder path
            //8     Click Ok button
            //9     Observe the current page
        }

        [TestMethod]
        public void DA_PANEl_TC57()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC057 - Verify that user is able to successfully edit \"Chart Type\"");
            //1     Navigate to Dashboard login page
            //2     Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3     Click Administer link
            //4     Click Panel link
            //5     Click Add New link
            //6     Create a new panel
            //7     Click Edit link
            //8     Change Chart Type for panel
            //9     Click Ok button
            //10    Observe the current page
        }

        [TestMethod]
        public void DA_PANEl_TC58()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC058 - Verify that \"Category\", \"Series\" and \"Caption\" field are enabled and disabled correctly corresponding to each type of the \"Chart Type\" in \"Edit Panel\" form");
            //1     Navigate to Dashboard login page
            //2     Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3     Click Administer link
            //4     Click Panel link
            //5     Click Add New link
            //6     Create a new panel
            //7     Click Edit link
            //8     Change Chart Type for panel
            //9     Observe the current page
            //10    Change Chart Type for panel
            //11    Observe the current page
            //12    Change Chart Type for panel
            //13    Observe the current page
            //14    Change Chart Type for panel
            //15    Observe the current page
            //16    Change Chart Type for panel
            //17    Observe the current page
        }

        [TestMethod]
        public void DA_PANEl_TC59()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC059 - Verify that all settings within \"Add New Panel\" and \"Edit Panel\" form stay unchanged when user switches between \"2D\" and \"3D\" radio buttons in \"Edit Panel\" form");
            //1     Navigate to Dashboard login page
            //2     Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3     Click Administer link
            //4     Click Panel link
            //5     Click Add New link
            //6     Switch between "2D" and "3D"
            //7     Observe the current page
            //8     Create a new panel
            //9     Click Edit link
            //10    Switch between "2D" and "3D"
            //11    Observe the current page
        }

        [TestMethod]
        public void DA_PANEl_TC60()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC60 - Verify that all settings within \"Add New Panel\" and \"Edit Panel\" form stay unchanged when user switches between \"Legends\" radio buttons in \"Edit Panel\" form");
            //1     Navigate to Dashboard login page
            //2     Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3     Click Administer link
            //4     Click Panel link
            //5     Click Add New link
            //6     Click None radio button for Legends
            //7     Observe the current page
            //8     Click Top radio button for Legends
            //9     Observe the current page
            //10    Click Right radio button for Legends
            //11    Observe the current page
            //12    Click Bottom radio button for Legends
            //13    Observe the current page
            //14    Click Left radio button for Legends
            //15    Observe the current page
            //16    Create a new panel
            //17    Click Edit link
            //18    Click None radio button for Legends
            //19    Observe the current page
            //20    Click Top radio button for Legends
            //21    Observe the current page
            //22    Click Right radio button for Legends
            //23    Observe the current page
            //24    Click Bottom radio button for Legends
            //25    Observe the current page
            //26    Click Left radio button for Legends
            //27    Observe the current page
        }
    }
}
