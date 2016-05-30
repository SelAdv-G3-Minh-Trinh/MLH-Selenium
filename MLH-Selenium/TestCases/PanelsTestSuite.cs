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

            //1    navigate to dashboard login page
            //2    login with valid account test / test
            //3    go to global setting->add page
            //4    enter page name to page name field.	page 1
            //5    click ok button
            //6    go to global setting->create panel
            //7    VP verify that all pre - set panels are populated and sorted correctly
            //            chart:
            //              +action implementation by status
            //              + test case execution failure trend
            //              + test case execution results
            //              +test case execution trend
            //              +test module execution failure trend
            //              +test module execution results
            //              + test module execution trend
            //              + test module implementation by priority
            //              +test module implementation by status
            //              +test module status per assigned users
            //            indicator:
            //              +test case execution
            //              + test module execution
            //              +test objective execution
            //            reports
            //              + test module execution results report
            //            heat maps:
            //              +test case execution history
            //            +test module execution history
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

            string actual = panels.addNewPanel(panel).GetAlertMessage();
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

            string actual = panels.addNewPanel(panel).GetAlertMessage();
            string expected = "Invalid display name. The name cannot contain high ASCII characters or any of the following characters: /:*?<>|\"#[]{}=%;";

            Assert.AreEqual(expected, actual);

            //10   Click Add New link
            //11   Enter value into Display Name field with special character is @	Display Name: Logigear@	
            //12   VP new panel is created
            panel.DisplayName = "Logigear@";
            Assert.IsTrue(panels.addNewPanel(panel).isPageLinkDisplayed(panel.DisplayName), "Panel is not created");

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

            dashboard = panels.addNewPanel(panel);

            //7    Click on Add new link again.
            //8    Enter display name same with previous display name to "display name" field.Duplicated panel
            //9    Click on OK button
            //10   VP Warning message: "Dupicated panel already exists. Please enter a different name" show up
            panels = dashboard.gotoAddPanel();

            string actual = panels.addNewPanel(panel).GetAlertMessage();
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
            //5    Enter name to Name textbox  giang - data
            //6    Click on Finish button
            //7    Click on Administer/ Panels link
            //8    Click on add new link
            //9    VP Verify that "giang - data" data profiles are populated correctly under the "Data Profile" dropped down menu.
            //10   Enter display name to Display Name textbox  giang - panel
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

            string actual = panels.addNewPanel(panel).GetAlertMessage();
            string expected = "Invalid display name. The name cannot contain high ASCII characters or any of the following characters: /:*?<>|\"#[]{}=%;";

            Assert.AreEqual(expected, actual);

            //10   Click Add New link
            //11   Enter value into Display Name field Display Name: Logigear@	
            //     Enter value into Chart Title field with special character is @	Char Title: Chart@	
            panel.DisplayName = "Chart@";
            Assert.IsTrue(panels.addNewPanel(panel).isPageLinkDisplayed(panel.DisplayName), "Panel is not created");

            //12   VP the new panel is created
            //Post - Condition  Delete the newly created panel
            //                  Close TA Dashboard
            dashboard.Close();
        }

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

        public void DA_PANEL_TC037()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC037 - Verify that \"Category\", \"Series\" and \"Caption\" field are enabled and disabled correctly corresponding to each type of the \"Chart Type\"");

            //1     Navigate to Dashboard login page
            //2     Select a specific repository Dashboard_STT
            //3     Enter valid Username and Password   hung.nguyen / (empty)
            //4     Click 'Login' button
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //5     Click 'Add Page' link
            //6     Enter Page Name main_hung
            //7     Click 'OK' button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);
            //8     Click 'Choose Panels' button
            //9     Click 'Create new panel' button
            PanelPage panels = new PanelPage();
            panels = dashboard.goToAddPanelByChoosePanel();

            //10    Click 'Chart Type' drop - down menu
            //11    Select 'Pie' Chart Type
            panels.ChartType_Cb.SelectByText("Pie");
            //12    VP. Check that 'Category' and 'Caption' are disabled, 'Series' is enabled
            Assert.IsTrue(panels.checkCategory());
            Assert.IsTrue(panels.checkSeries());
            Assert.IsTrue(panels.checkCaption());
            //13   Click 'Chart Type' drop - down menu            
            //14   Select 'Single Bar' Chart Type
            panels.ChartType_Cb.SelectByText("Single Bar");
            //15   VP. Check that 'Category' is disabled, 'Series' and 'Caption' are enabled
            Assert.IsTrue(panels.checkCategory());
            Assert.IsTrue(panels.checkSeries());
            Assert.IsTrue(panels.checkCaption());
            //16   Click 'Chart Type' drop - down menu
            //17   Select 'Stacked Bar' Chart Type
            panels.ChartType_Cb.SelectByText("Stacked Bar");
            //18   VP. Check that 'Category' ,'Series' and 'Caption' are enabled
            Assert.IsTrue(panels.checkCategory());
            Assert.IsTrue(panels.checkSeries());
            Assert.IsTrue(panels.checkCaption());
            //19   Click 'Chart Type' drop - down menu
            //20   Select 'Group Bar' Chart Type
            panels.ChartType_Cb.SelectByText("Group Bar");
            //21   VP. Check that 'Category' ,'Series' and 'Caption' are enabled
            Assert.IsTrue(panels.checkCategory());
            Assert.IsTrue(panels.checkSeries());
            Assert.IsTrue(panels.checkCaption());
            //22   Click 'Chart Type' drop - down menu
            //23   Select 'Line' Chart Type
            panels.ChartType_Cb.SelectByText("Line");
            //24   VP. Check that 'Category' ,'Series' and 'Caption' are enabled
            Assert.IsTrue(panels.checkCategory());
            Assert.IsTrue(panels.checkSeries());
            Assert.IsTrue(panels.checkCaption());
            panels.Close();
        }

        public void DA_PANEL_TC038()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC038 - Verify that all settings within \"Add New Panel\" and \"Edit Panel\" form stay unchanged when user switches between \"2D\" and \"3D\" radio buttons");

            //1     Navigate to Dashboard login page
            //2     Select a specific repository Dashboard_STT
            //3     Enter valid Username and Password   hung.nguyen / (empty)
            //4     Click 'Login' button
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //5     Click 'Add Page' link
            //6     Enter Page Name main_hung
            //7     Click 'OK' button
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();

            Page page = new Page();
            page.InitPageInformation();

            dashboard = pages.addNewpage(page);
            //8     Click 'Choose Panels' button
            //9     Click 'Create new panel' button
            PanelPage panels = new PanelPage();
            panels = dashboard.goToAddPanelByChoosePanel();
            //10    Click 'Chart Type' drop - down menu
            //11    Select a specific Chart Type
            panels.ChartType_Cb.SelectByText("Stacked Bar");
            //12    Select 'Data Profile' drop - down menu
            panels.DataProfile_Cb.SelectByText("Test Case Execution");
            //13    Enter 'Display Name' and 'Chart Title'          
            panels.PanelName_Txt.SendKeys("");
            panels.ChartTitle_Txt.SendKeys("");
            //14    Select 'Show Title' checkbox
            panels.ShowTitle_chk.Check();
            //15    select 'Legends' radio button
            panels.selectLegends("Top");
            //16    Select 'Style' radio button
            panels.selectStyle("3D");
            //17    VP. Check that settings of 'Chart Type', 'Data Profile', 'Display Name', 'Chart Title', 'Show Title' and 'Legends' stay unchanged.            
            
            //18    Select 'Style' radio button
            panels.selectStyle("2D");
            //19    VP. Check that settings of 'Chart Type', 'Data Profile', 'Display Name', 'Chart Title', 'Show Title' and 'Legends' stay unchanged.          
            
            //20    Click OK button
            panels.OK_Btn.Click();
            //21    Select a page in drop - down menu
            //22    Enter path of Folder
            panels.panelConfiguration("Execution Dashboard", "", "/Car Rental/Tests");
            //23    Click OK button
            panels.ConfigurationOK_Btn.Click();
            //24    Click 'Edit Panel' button of panel 'hung_panel'
            
            //25    Select 'Style' radio button
            panels.selectStyle("3D");
            //26    VP. Check that settings of 'Chart Type', 'Data Profile', 'Display Name', 'Chart Title', 'Show Title' and 'Legends' stay unchanged.            
            
            //27    Select 'Style' radio button
            panels.selectStyle("2D");
            //28    VP. Check that settings of 'Chart Type', 'Data Profile', 'Display Name', 'Chart Title', 'Show Title' and 'Legends' stay unchanged.           
            
        }

        public void DA_PANEL_TC039()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC039 - Verify that all settings within \"Add New Panel\" and \"Edit Panel\" form stay unchanged when user switches between \"Legends\" radio buttons");

            //1     Navigate to Dashboard login page
            //2     Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3     Click Administer link
            //4     Click Panel link
            //5     Click Add New link
            ManagePagesPage pages = new ManagePagesPage();
            pages = dashboard.goToAddPage();
            //6     Click None radio button for Legend
            
            //7     Observe the current page
            //8     Click Top radio button for Legend
            //9     Observe the current page
            //10    Click Right radio button for Legend
            //11    Observe the current page
            //12    Click Bottom radio button for Legend
            //13    Observe the current page
            //14    Click Left radio button for Legend
            //15    Observe the current page
            //16    Create a new panel
            //17    Click Edit Panel link
            //18    Click None radio button for Legend
            //19    Observe the current page
            //20    Click Top radio button for Legend
            //21    Observe the current page
            //22    Click Right radio button for Legend
            //23    Observe the current page
            //24    Click Bottom radio button for Legend
            //25    Observe the current page
            //26    Click Left radio button for Legend
            //27    Observe the current pages
        }

        public void DA_PANEL_TC040()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC040 - Verify that all settings within \"Add New Panel\" and \"Edit Panel\" form stay unchanged when user switches between \"2D\" and \"3D\" radio buttons");

            //1 Navigate to Dashboard login page
            //2 Select a specific repository Dashboard_STT
            //3 Enter valid Username and Password   hung.nguyen / (empty)
            //4 Click 'Login' button
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
            //11   Select a specific Chart Type
            panels.ChartType_Cb.SelectByText("Pie");
            //12   Select 'Data Profile' drop - down menu
            panels.DataProfile_Cb.SelectByText("Action Implementation By Status");
            //13   Enter 'Display Name' and 'Chart Title'

            //14   Select 'Show Title' checkbox
            //15   select 'Legends' radio button
            //16   Select 'Style' radio button
            //17   VP. Check that settings of 'Chart Type', 'Data Profile', 'Display Name', 'Chart Title', 'Show Title' and 'Legends' stay unchanged.
            //18   Select 'Style' radio button
            //19   VP. Check that settings of 'Chart Type', 'Data Profile', 'Display Name', 'Chart Title', 'Show Title' and 'Legends' stay unchanged.
            //20   Click OK button
            //21   Select a page in drop - down menu
            //22   Enter path of Folder
            //23   Click OK button
            //24   Click 'Edit Panel' button of panel 'hung_panel'
            //25   Select 'Style' radio button
            //26   VP. Check that settings of 'Chart Type', 'Data Profile', 'Display Name', 'Chart Title', 'Show Title' and 'Legends' stay unchanged.
            //27   Select 'Style' radio button
            //28   VP. Check that settings of 'Chart Type', 'Data Profile', 'Display Name', 'Chart Title', 'Show Title' and 'Legends' stay unchanged.
        }

        public void DA_PANEL_TC050()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC050 - Verify that user is able to successfully edit \"Display Name\" of any Panel providing that the name is not duplicated with existing Panels' name");
            //1     Navigate to Dashboard login page
            //2     Login with valid account
            //3     Click Administer link
            //4     Click Panel link
            //5     Click Add New link
            //6     Enter a valid name into Display Name field
            //7     VP. Observe the current page

        }

        public void DA_PANEL_TC051()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC051 - Verify that user is unable to change \"Display Name\" of any Panel if there is special character except '@' inputted");
            //1     Navigate to Dashboard login page
            //2     Login with valid account
            //3     Click Administer link
            //4     Click Panel link
            //5     Click Add New link
            //6     Create a new panel
            //7     Click Edit link
            //8     Edit panel name with special characters
            //9     Click Ok button
            //10    VP. Observe the current page
            //11    Close warning message box
            //12    Click Edit link
            //13    Edit panel name with special character is @
            //14    Click Ok button
            //15    VP. Observe the current page
        }

        public void DA_PANEL_TC052()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC052 - Verify that user is unable to edit  \"Height * \" field to anything apart from integer number with in 300-800 range");
            //1     Navigate to Dashboard login page
            //2     Login with valid account
            //3     Create a new page
            //4     Click Choose Panel button
            //5     Click Create New Panel button
            //6     Enter all required fields on Add New Panel page
            //7     Click Ok button
            //8     Enter invalid height into Height field
            //9     Click Ok button
            //10    VP. Observe the current page
            //11    Close Warning Message box
            //12    Enter valid height into Height field
            //13    Click Ok button
            //14    VP.Observe the current page
        }

        public void DA_PANEL_TC053()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC053 - Verify that newly created panel are populated and sorted correctly in Panel lists under \"Choose panels\" form");
            //Navigate to Dashboard login page
            //Select a specific repository
            //Enter valid Username and Password
            //Click 'Login' button
            //Click 'Add Page' button
            //Enter Page Name
            //Click 'OK' button
            //Click 'Choose Panels' button below 'main_hung' button
            //Click 'Create new panel' button
            //Enter a name to Display Name
            //Click OK button
            //Click Cancel button
            //Click 'Create new panel' button
            //Enter a name to Display Name
            //Click OK button
            //Click Cancel button
            //Click 'Create new panel' button
            //Select 'Type' radio button
            //Enter a name to Display Name
            //Click OK button
            //Click Cancel button
            //Click 'Create new panel' button
            //Select 'Type' radio button
            //Enter a name to Display Name
            //Click OK button
            //Click Cancel button
            //Click main_hung button
            //Click 'Choose Panels' button below 'main_hung' button
            //Check that 'hung_chart_a' panel and 'hung_chart_b' panel are existed in Chart section of 'Choose panels' form
            //Check that 'hung_report' panel is existed in Report section of 'Choose panels' form
            //Check that 'hung_indicator' panel is existed in Indicator section of 'Choose panels' form
            //Check that 'hung_chart_a' panel is placed before 'hung_chart_b' panel
        }

        public void DA_PANEL_TC054()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC054 - Verify that user is able to successfully edit \"Folder\" field with valid path");
            //Navigate to Dashboard login page
            //Login with valid account
            //Create a new page
            //Create a new panel
            //Click Choose Panel button
            //Click on the newly created panel link
            //Edit valid folder path
            //Click Ok button
            //Observe the current page
        }

        public void DA_PANEL_TC055()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC055 - Verify that user is unable to edit \"Folder\" field with invalid path");
            //Navigate to Dashboard login page
            //Login with valid account
            //Create a new page
            //Create a new panel
            //Click Choose Panel button
            //Click on the newly created panel link
            //Edit invalid folder path
            //Click Ok button
            //Observe the current page

        }

        public void DA_PANEL_TC056()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC056 - Verify that user is unable to edit \"Folder\" field with empty value");
            //Navigate to Dashboard login page
            //Login with valid account
            //Click Administer link
            //Click Panel link
            //Click Add New link
            //Create a new panel
            //Click Edit link
            //Change Chart Type for panel
            //Click Ok button
            //Observe the current page
        }

        public void DA_PANEL_TC057()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC057 - Verify that user is able to successfully edit \"Chart Type\"");
            //Navigate to Dashboard login page
            //Login with valid account
            //Click Administer link
            //Click Panel link
            //Click Add New link
            //Create a new panel
            //Click Edit link
            //Change Chart Type for panel
            //Click Ok button
            //Observe the current page

        }

        public void DA_PANEL_TC058()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC058 - Verify that \"Category\", \"Series\" and \"Caption\" field are enabled and disabled correctly corresponding to each type of the \"Chart Type\" in \"Edit Panel\" form");
            //Navigate to Dashboard login page
            //Login with valid account
            //Click Administer link
            //Click Panel link
            //Click Add New link
            //Create a new panel
            //Click Edit link
            //Change Chart Type for panel
            //Observe the current page
            //Change Chart Type for panel
            //Observe the current page
            //Change Chart Type for panel
            //Observe the current page
            //Change Chart Type for panel
            //Observe the current page
            //Change Chart Type for panel
            //Observe the current page
        }

        public void DA_PANEL_TC059()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC059 - Verify that all settings within \"Add New Panel\" and \"Edit Panel\" form stay unchanged when user switches between \"2D\" and \"3D\" radio buttons in \"Edit Panel\" form");
            //Navigate to Dashboard login page
            //Login with valid account
            //Click Administer link
            //Click Panel link
            //Click Add New link
            //Switch between "2D" and "3D"
            //Observe the current page
            //Create a new panel
            //Click Edit link
            //Switch between "2D" and "3D"
            //Observe the current page
        }

        public void DA_PANEL_TC060()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_PANEL_TC060 - Verify that all settings within \"Add New Panel\" and \"Edit Panel\" form stay unchanged when user switches between \"Legends\" radio buttons in \"Edit Panel\" form");
            //Navigate to Dashboard login page
            //Login with valid account
            //Click Administer link
            //Click Panel link
            //Click Add New link
            //Click None radio button for Legends
            //Observe the current page
            //Click Top radio button for Legends
            //Observe the current page
            //Click Right radio button for Legends
            //Observe the current page
            //Click Bottom radio button for Legends
            //Observe the current page
            //Click Left radio button for Legends
            //Observe the current page
            //Create a new panel
            //Click Edit link
            //Click None radio button for Legends
            //Observe the current page
            //Click Top radio button for Legends
            //Observe the current page
            //Click Right radio button for Legends
            //Observe the current page
            //Click Bottom radio button for Legends
            //Observe the current page
            //Click Left radio button for Legends
            //Observe the current page
        }
    }
}
