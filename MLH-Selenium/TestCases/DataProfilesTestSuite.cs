using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLH_Selenium.PageObject;
using MLH_Selenium.ObjectData;
using MLH_Selenium.Common;

namespace MLH_Selenium.TestCases
{
    [TestClass]
    public class DataProfilesTestSuite : TestBase
    {
        /// <summary>
        /// DA_LOGIN_TC065 - Verify that all Pre-set Data Profiles are populated correctly
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC065()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC065 - Verify that all Pre-set Data Profiles are populated correctly");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository
            //3    Enter valid Username and Password
            //4    Click Login
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //5    Click Administer->Data Profiles
            //6    VP Check Pre - set Data Profile are populated correctly in profiles page
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            Assert.IsTrue(profile.checkPresetProfilePopulate(), "Pre set does not display in data profile.");
            //Post - Condition  Close Dashboard
            profile.Close();
        }

        /// <summary>
        /// DA_LOGIN_TC066 - Verify that all Pre-set Data Profiles are populated correctly
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC066()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC066 - Verify that all Pre-set Data Profiles are populated correctly");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository
            //3    Enter valid Username and Password
            //4    Click Login
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //5    Click Administer->Data Profiles
            //6    VP Check there is no 'Delele' or 'Edit' link appears in Action section of Pre-set Data Profiles
            ManageProfilePage profile = dashboard.goToDataProfiles();            

            //7    Click on Pre-set Data Profile name
            //8    VP Check there is no link on Pre - set Data Profile name
            //9    VP Check there is no checkbox appears in the left of Pre-set Data Profiles
            Assert.IsFalse(profile.checkLinkExistInPresetProfile(), "Error: Pre set profile still has link");
            Assert.IsFalse(profile.checkCheckboxInPresetProfile(), "Error: Pre set profile still has checkbox");

            //Post - Condition  Close Dashboard
            profile.Close();
        }

        /// <summary>
        /// DA_LOGIN_TC067 - Verify that Data Profiles are listed alphabetically
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC067()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC067 - Verify that Data Profiles are listed alphabetically");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository
            //3    Enter valid Username and Password
            //4    Click Login
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //5    Click Administer->Data Profiles
            //6    VP Check Data Profiles are listed alphabetically
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            Assert.IsTrue(profile.checkDataProfileGridOrder(), "data profile id not sorted by alphabet.");
        }

        /// <summary>
        /// DA_LOGIN_TC068 - Verify that Check Boxes are only present for non-preset Data Profiles.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>6/6/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC068()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC068 - Verify that Check Boxes are only present for non-preset Data Profiles.");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository
            //3    Enter valid Username and Password
            //4    Click Login
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //5    Click Administer->Data Profiles
            //6    Create a new Data Profile
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            DataProfile data = new DataProfile();
            data.InitPanelInformation();

            profile = profile.addNewProfilewithNameOnly(data);
            //7    Back to Data Profiles page
            //8    VP Check Check Boxes are only present for non - preset Data Profiles.
            Assert.IsTrue(profile.checkProfileHasCheckboxExist(data.Name), "Error: Check box does not exist.");
        }

        /// <summary>
        /// DA_LOGIN_TC069 - Verify that user is unable to proceed to next step or finish creating data profile if  "Name *" field is left empty
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>6/7/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC069()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC069 - Verify that user is unable to proceed to next step or finish creating data profile if  \"Name * \" field is left empty");

            //1    Log in Dashboard
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //2    Navigate to Data Profiles page
            //3    Click on "Add New"
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            DataProfile data = new DataProfile();
            data.InitPanelInformation();
            data.Name = "";
            //4    Click on "Next Button"
            //5    VP Check dialog message "Please input profile name" appears
            Assert.AreEqual("Please input profile name.", profile.addNewProfilewithMoreInformation(data).GetAlertMessage());
            //6    Click on "Finish Button"
            //7    VP Check dialog message "Please input profile name" appears
            Assert.AreEqual("Please input profile name.", profile.addNewProfilewithNameOnly(data).GetAlertMessage());
            //Post - Condition  Close TA Dashboard
            profile.Close();
        }

        /// <summary>
        /// DA_LOGIN_TC070 - Verify that special characters ' /:*?<>|"#[ ]{}=%; 'is not allowed for input to "Name *" field
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC070()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC070 - Verify that special characters ' /:*?<>|\"#[ ]{}=%; 'is not allowed for input to \"Name *\" field");

            //1    Log in Dashboard
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //2    Navigate to Data Profiles page
            //3    Click on "Add New"
            //4    Input special character
            dashboard.goToPage("Administer/Data Profiles");            
            ManageProfilePage profile = dashboard.gotoAddProfile();

            DataProfile data = new DataProfile();
            data.InitPanelInformation();
            data.Name = "/:*?<>|\"#[ ]{}=%;";
            //5   VP Check dialog message indicates invalid characters: /:*?<>| "#[ ]{}=%; is not allowed as input for name field appears
            Assert.AreEqual("Invalid name. The name cannot contain high ASCII characters or any of the following characters: /:*?<>|\"#[]{}=%;", profile.addNewProfilewithNameOnly(data).GetAlertMessage());
            //Post - Condition  Close TA Dashboard
            profile.Close();
        }

        /// <summary>
        /// DA_LOGIN_TC071 - Verify that Data Profile names are not case sensitive
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC071()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC071 - Verify that Data Profile names are not case sensitive");

            //1    Log in Dashboard
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //2    Navigate to Data Profiles page
            //3    Click on "Add New"
            //4    Input charater 'A' into "Name *" field
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            DataProfile data = new DataProfile();
            data.InitPanelInformation();
            data.Name = "Test Case Execution";
            //5    Click "Next" button
            //6    VP Check dialog message "Data Profile name already exists"
            Assert.AreEqual("Data profile name already exists.",profile.addNewProfilewithMoreInformation(data).GetAlertMessage());

            //Post - Condition  Close TA Dashboard
            profile.Close();
        }

        /// <summary>
        /// DA_LOGIN_TC072 - Verify that all data profile types are listed under "Item Type" dropped down menu
        /// </summary>
        /// <author>Hoang Ha</author>
        /// <createdDate>6/5/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC072()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC072 - Verify that all data profile types are listed under \"Item Type\" dropped down menu");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository
            //3    Enter valid Username and Password
            //4    Click Login
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //5    Click Administer->Data Profiles
            //6    Click 'Add New' link
            //7    VP  "Check all data profile types are listed under ""Item Type"" dropped down menu in create profile page"
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            Assert.IsTrue(profile.checkItemTypeList(), "Item does not display in list");
            //Post - Condition  Close Dashboard
            profile.Close();
        }

        /// <summary>
        /// DA_LOGIN_TC073 - Verify that all data profile types are listed in priority order under "Item Type" dropped down menu
        /// </summary>
        /// <author>Hoang Ha</author>
        /// <createdDate>6/5/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC073()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC073 - Verify that all data profile types are listed in priority order under \"Item Type\" dropped down menu");

            //1    Log in Dashboard
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //2    Navigate to Data Profiles page
            //3    Click on "Add New"
            //4    Click on "Item Type" dropped down menu
            //5    VP Check "Item Type" items are listed in priority order
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            Assert.IsTrue(profile.checkItemTypeListbyPrio(), "Item type does not list by prioritize");
            //Post - Condition  Close TA Dashboard
            profile.Close();
        }

        /// <summary>
        /// DA_LOGIN_TC074 - Verify that appropriate "Related Data" items are listed correctly corresponding to the "Item Type" items.
        /// </summary>
        /// <author>Hoang Ha</author>
        /// <createdDate>6/6/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC074()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC074 - Verify that appropriate \"Related Data\" items are listed correctly corresponding to the \"Item Type\" items.");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository
            //3    Enter valid Username and Password
            //4    Click Login
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //5    Click Administer->Data Profiles
            //6    Click Add new link
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            //7    Select 'Test Modules' in 'Item Type' drop down list
            //8    VP Check 'Related Data' items listed correctly
            Assert.IsTrue(profile.checkRelatedDatePopulated("test modules"), "Related data is wrong");

            //9    Select 'Test Cases' in 'Item Type' drop down list
            //10   VP Check 'Related Data' items listed correctly
            Assert.IsTrue(profile.checkRelatedDatePopulated("test cases"), "Related data is wrong");

            //11   Select 'Test Objectives' in 'Item Type' drop down list
            //12   VP Check 'Related Data' items listed correctly
            Assert.IsTrue(profile.checkRelatedDatePopulated("test objectives"), "Related data is wrong");

            //13   Select 'Data Sets' in 'Item Type' drop down list
            //14   VP Check 'Related Data' items listed correctly
            Assert.IsTrue(profile.checkRelatedDatePopulated("data sets"), "Related data is wrong");

            //15   Select 'Actions' in 'Item Type' drop down list
            //16   VP Check 'Related Data' items listed correctly
            Assert.IsTrue(profile.checkRelatedDatePopulated("actions"), "Related data is wrong");

            //17   Select 'Interface Entities' in 'Item Type' drop down list
            //18   VP Check 'Related Data' items listed correctly
            Assert.IsTrue(profile.checkRelatedDatePopulated("interface entities"), "Related data is wrong");

            //19   Select 'Test Results' in 'Item Type' drop down list
            //20   VP Check 'Related Data' items listed correctly
            Assert.IsTrue(profile.checkRelatedDatePopulated("test results"), "Related data is wrong");

            //21   Select 'Test Case Results' in 'Item Type' drop down list
            //22   VP Check 'Related Data' items listed correctly0
            Assert.IsTrue(profile.checkRelatedDatePopulated("test cases results"), "Related data is wrong");
        }

        /// <summary>
        /// DA_LOGIN_TC075 - Verify that default settings are applied correctly for newly created data profiles if user only set up "General Settings" page and finishes.
        /// </summary>
        /// <author>Hoang Ha</author>
        /// <createdDate>6/6/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC075()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC075 - Verify that default settings are applied correctly for newly created data profiles if user only set up \"General Settings\" page and finishes.");

            //1    Navigate to Data Profiles page
            //2    Login with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3    Click on "Add New"
            //4    Input to "Name *" field
            //5    Click "Item Type" and choose an item
            //6    Click "Finish" button
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            DataProfile data = new DataProfile();
            data.InitPanelInformation();

            profile = profile.addNewProfilewithFinish(data);
            //7    Click on the newly created data profile
            //8    VP Check the setting of General Settings Page - "Name  *": Test1, "Item Type": Test Modules, Related Data: None
            profile.gotoProfileSettingPageByName(data.Name);

            Assert.IsTrue(profile.checkDataAtGeneralSettingPage(data), "Information is wrong.");
            //9    Click Next Button
            //10   VP Check the setting of Display Fields Page - All check boxes are un - checked
            profile.clickNextButton();
            Assert.IsFalse(profile.checkCheckboxinDisplayFieldisChecked(), "checkbox is checked.");
            //11   Click Next Button
            //12   VP Check the setting of Sort Fields Page - Empty Sort Criteria list
            profile.clickNextButton();
            Assert.IsTrue(profile.checkSortFiedlPageIsEmpty(), "List is not empty");
            //13   Click Next Button
            //14   VP Check the setting of Filter Fields Page -Empty Filter list
            profile.clickNextButton();
            Assert.IsTrue(profile.checkFilterFieldIsEmpty(), "List is not empty");
            //15   Click Next Button
            //16   VP Check the setting of Statistic Page - All check boxes are un-checked
            profile.clickNextButton();
            Assert.IsTrue(profile.checkCheckboxinField(), "checkbox is checked.");
            //Post - Condition  Close TA Dashboard
            profile.Close();
        }

        /// <summary>
        /// DA_LOGIN_TC076 - Verify that for newly created data profile, user is able to navigate through other setting pages on the left navigation panel.
        /// </summary>
        /// <author>Hoang Ha</author>
        /// <createdDate>6/7/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC076()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC076 - Verify that for newly created data profile, user is able to navigate through other setting pages on the left navigation panel.");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository
            //3    Enter valid Username and Password
            //4    Click Login
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);

            //5    Click Administer->Data Profiles
            //6    Click Add new link
            //7    Create new data profile
            //8    Back to Data Profiles page
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            DataProfile data = new DataProfile();
            data.InitPanelInformation();

            profile = profile.addNewProfilewithNameOnly(data);
            //9    Click on the data profile 'thinh-test'
            //10   Click on 'Display Fields' in the left navigation panel
            //11   VP Check Display Fields page appears
            profile.gotoProfileSettingPageByName(data.Name);
            Assert.IsTrue(profile.checkProfileSettingPageDisplay("Display Fields"), "Display Fields page does not display.");

            //12   Click on 'Sort Fields' in the left navigation panel
            //13   VP Check Sort Fields page appears
            Assert.IsTrue(profile.checkProfileSettingPageDisplay("Sort Fields"), "Sort Fields page does not display.");

            //14   Click on 'Filter Fields' in the left navigation panel
            //15   VP Check Filter Fields page appears
            Assert.IsTrue(profile.checkProfileSettingPageDisplay("Filter Fields"), "Filter Fields page does not display.");
         
            //16   Click on 'Statistic Fields' in the left navigation panel
            //17   VP Check Statistic Fields page appears
            Assert.IsTrue(profile.checkProfileSettingPageDisplay("Statistic Fields"), "Statistic Fields page does not display.");

            //18   Click on 'Display Sub-Fields' in the left navigation panel
            //19   VP Check Display Sub-Fields page appears
            Assert.IsFalse(profile.checkProfileSettingPageDisplay("Display Sub-Fields"), "Error - Display Sub-Fields page does not display.");

            //20   Click on 'Sort Sub-Fields' in the left navigation panel
            //21   VP Check Sort Sub-Fields page appears
            Assert.IsFalse(profile.checkProfileSettingPageDisplay("Sort Sub-Fields"), "Error - Sort Sub-Fields page does not display.");
          
            //22   Click on 'Filter Sub-Fields' in the left navigation panel
            //23   VP Check Filter Sub-Fields page appears
            Assert.IsFalse(profile.checkProfileSettingPageDisplay("Filter Sub-Fields"), "Error - Filter Sub-Fields page does not display.");
         
            //24   Click on 'Statistic Sub-Fields' in the left navigation panel
            //25   VP Check Statistic Sub-Fields page appears
            Assert.IsFalse(profile.checkProfileSettingPageDisplay("Statistic Sub-Fields"), "Error - Statistic Sub-Fields page does not display.");
        }

        /// <summary>
        /// DA_LOGIN_TC077 - Verify that all fields are displayed correctly
        /// </summary>
        /// <author>Hoang Ha</author>
        /// <createdDate>6/7/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC077()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC077 - Verify that all fields are displayed correctly");

            //1    Navigate to Dashboard login page
            //2    Log in specific repository with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3    Click on "Administer" llink
            //4    Click on "Data Profiles" link
            //5    Click "Add New" link
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            DataProfile data = new DataProfile();
            data.InitPanelInformation();
            //6    Enter Name field
            //7    Click Item Type listbox
            //8    Select specific Item Type
            //9    Click on "Next" button
            //10   VP Check all fields are displayed correctly
            Assert.AreEqual("Data Profile : " + data.Name, profile.addNewProfilewithMoreInformation(data).getProfileNameAtDisplayField(), "Wrong display name");
            //Post - Condition  Close TA Dashboard Page
            profile.Close();
        }

        /// <summary>
        /// DA_LOGIN_TC078 - Verify that all fields are pre-fixed with check boxes
        /// </summary>
        /// <author>Hoang Ha</author>
        /// <createdDate>6/8/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC078()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC078 - Verify that all fields are pre-fixed with check boxes");

            //1    Log in Dashboard
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //2    Navigate to Data Profiles page
            //3    Click on Data Profile "A"
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            DataProfile data = new DataProfile();
            data.InitPanelInformation();
            //4    Click on Next button
            //5    VP Check each field listed is prefixed with checkbox
            Assert.IsTrue(profile.addNewProfilewithMoreInformation(data).checkCheckboxinField(), "No checkbox display");
            //Post - Condition  Close TA Dashboard
            profile.Close();
        }

        /// <summary>
        /// DA_LOGIN_TC079 - Verify that Check All / Uncheck All Links are working correctly
        /// </summary>
        /// <author>Hoang Ha</author>
        /// <createdDate>6/8/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC079()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC079 - Verify that Check All / Uncheck All Links are working correctly");

            //1    Navigate to Dashboard login page
            //2    Log in with valid account
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //3    Click on "Administer" llink
            //4    Click on "Data Profiles" link
            //5    Click "Add New" link
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            DataProfile data = new DataProfile();
            data.InitPanelInformation();
            //6    Enter Name field
            //7    Click on "Next" button
            profile = profile.addNewProfilewithMoreInformation(data);
            //8    Click on "Check All" link
            //9    VP Verify that all checkbox is checked
            profile.clickCheckAll();
            Assert.IsTrue(profile.checkCheckboxinDisplayFieldisChecked(), "Some checkboxes are not checked.");
            //10   Click on "Uncheck All" link
            //11   VP Verify that all checkbox is unchecked
            profile.clickUncheckAll();
            Assert.IsFalse(profile.checkCheckboxinDisplayFieldisChecked(), "Some checkboxes are checked.");
            //Post - Condition  Delete newly added data profile
            //                  Close TA Dashboard Page
            profile.Close();
        }

        /// <summary>
        /// DA_LOGIN_TC080 - Verify that all fields are listed in the "Field" dropped down menu
        /// </summary>
        /// <author>Hoang Ha</author>
        /// <createdDate>6/8/2016</createdDate>
        [TestMethod]
        public void DA_DP_TC080()
        {
            string repo = "SampleRepository";
            string user = "administrator";
            string pass = "";

            Console.WriteLine("DA_DP_TC080 - Verify that all fields are listed in the \"Field\" dropped down menu");

            //1    Log in Dashboard
            LoginPage loginpage = new LoginPage();
            loginpage.open();

            DashboardPage dashboard = new DashboardPage();
            dashboard = loginpage.LoginWithValidUser(repo, user, pass);
            //2    Navigate to Data Profiles page
            //3    Input to "Name *" field
            //4    Click "Item Type" dropped down menu and choose Test Modules
            dashboard.goToPage("Administer/Data Profiles");
            ManageProfilePage profile = dashboard.gotoAddProfile();

            DataProfile data = new DataProfile();
            data.InitPanelInformation();
            data.Type = "test modules";

            profile = profile.addNewProfilewithMoreInformation(data);
            //5    Navigate to Sort Fields page
            //6    VP Check all fields of selected "Item Type" item are listed under the "Field" dropped down menu
            profile.navigateToProfileSettingPage("Sort Fields");
            Assert.IsTrue(profile.checkItemTypesPopulated(data.Type), "List is wrong");

            //7    Navigate to General Settings page
            //8    Click "Item Type" dropped down menu and choose Test Cases
            //9    Navigate to Sort Fields page
            //10   VP Check all fields of selected "Item Type" item are listed under the "Field" dropped down menu
            string type1 = "test cases";
            profile.navigateToProfileSettingPage("General Setting");
            profile.selectItemType(type1);
            profile.navigateToProfileSettingPage("Sort Fields");
            Assert.IsTrue(profile.checkItemTypesPopulated(type1), "List is wrong");

            //11   Navigate to General Settings page
            //12   Click "Item Type" dropped down menu and choose Test Objectives
            //13   Navigate to Sort Fields page
            //14   VP Check all fields of selected "Item Type" item are listed under the "Field" dropped down menu
            string type2 = "test objective";
            profile.navigateToProfileSettingPage("General Setting");
            profile.selectItemType(type2);
            profile.navigateToProfileSettingPage("Sort Fields");
            Assert.IsTrue(profile.checkItemTypesPopulated(type2), "List is wrong");

            //15   Navigate to General Settings page
            //16   Click "Item Type" dropped down menu and choose Data Sets
            //17   Navigate to Sort Fields page
            //18   VP Check all fields of selected "Item Type" item are listed under the "Field" dropped down menu
            string type3 = "data sets";
            profile.navigateToProfileSettingPage("General Setting");
            profile.selectItemType(type3);
            profile.navigateToProfileSettingPage("Sort Fields");
            Assert.IsTrue(profile.checkItemTypesPopulated(type3), "List is wrong");

            //19   Navigate to General Settings page
            //20   Click "Item Type" dropped down menu and choose Actions
            //21   Navigate to Sort Fields page
            //22   VP Check all fields of selected "Item Type" item are listed under the "Field" dropped down menu
            string type4 = "actions";
            profile.navigateToProfileSettingPage("General Setting");
            profile.selectItemType(type4);
            profile.navigateToProfileSettingPage("Sort Fields");
            Assert.IsTrue(profile.checkItemTypesPopulated(type4), "List is wrong");

            //23   Navigate to General Settings page
            //24   Click "Item Type" dropped down menu and choose Interface Entities
            //25   Navigate to Sort Fields page
            //26   VP Check all fields of selected "Item Type" item are listed under the "Field" dropped down menu
            string type5 = "interface entities";
            profile.navigateToProfileSettingPage("General Setting");
            profile.selectItemType(type5);
            profile.navigateToProfileSettingPage("Sort Fields");
            Assert.IsTrue(profile.checkItemTypesPopulated(type5), "List is wrong");

            //27   Navigate to General Settings page
            //28   Click "Item Type" dropped down menu and choose Test Results
            //29   Navigate to Sort Fields page
            //30   VP Check all fields of selected "Item Type" item are listed under the "Field" dropped down menu
            string type6 = "test results";
            profile.navigateToProfileSettingPage("General Setting");
            profile.selectItemType(type6);
            profile.navigateToProfileSettingPage("Sort Fields");
            Assert.IsTrue(profile.checkItemTypesPopulated(type6), "List is wrong");

            //31   Navigate to General Settings page
            //32   Click "Item Type" dropped down menu and choose Test Case Results
            //33   Navigate to Sort Fields page
            //34   VP Check all fields of selected "Item Type" item are listed under the "Field" dropped down menu
            string type7 = "test case results";
            profile.navigateToProfileSettingPage("General Setting");
            profile.selectItemType(type7);
            profile.navigateToProfileSettingPage("Sort Fields");
            Assert.IsTrue(profile.checkItemTypesPopulated(type7), "List is wrong");

            //Post - Condition  Close TA Dashboard
            profile.Close();
        }
    }
}
