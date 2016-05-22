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
        [TestMethod]
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
            Console.WriteLine("DA_PANEL_TC028 - Verify that when \"Add New Panel\" form is on focused all other control/form is disabled or locked.");


            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            //3    Click Administer link
            //4    Click Panel link
            //5    Click Add New link
            //6    Try to click other controls when Add New Panel dialog is opening
            //7    VP All control / form are disabled or locked when Add New Panel dialog is opening
            //Post - Condition  Close TA Dashboard
        }

        [TestMethod]
        public void DA_PANEL_TC029()
        {
            Console.WriteLine("DA_PANEL_TC029 - Verify that user is unable to create new panel when (*) required field is not filled");

            //1    Navigate to Dashboard
            //2    Select specific repository
            //3    Enter valid username and password
            //4    Click on Login button
            //5    Click on Administer/ Panels link
            //6    Click on "Add new" link
            //7    Click on OK button
            //8    VP Warning message: "Display Name is required field" show up
            //Post - Condition  Logout
            //      Close Dashboard
        }

        [TestMethod]
        public void DA_PANEL_TC030()
        {
            Console.WriteLine("DA_PANEL_TC030 - Verify that no special character except '@' character is allowed to be inputted into \"Display Name\" field");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            //3    Click Administer link
            //4    Click Panel link
            //5    Click Add New link
            //6    Enter value into Display Name field with special characters except "@"  Display Name: Logigear#$%	
            //7    Click Ok button
            //8    VP Message "Invalid display name. The name can't contain high ASCII characters or any of following characters: /:*?<>|"#{[]{};" is displayed
            //9    Close Warning Message box
            //10   Click Add New link
            //11   Enter value into Display Name field with special character is @	Display Name: Logigear@	
            //12   VP new panel is created
            //Post - Condition  Close TA Dashboard
        }

        [TestMethod]
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
            Console.WriteLine("DA_PANEL_TC032 - Verify that user is not allowed to create panel with duplicated \"Display Name\"");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            //3    Click on Administer/ Panels link
            //4    Click on Add new link
            //5    Enter display name to "Display name" field.Duplicated panel
            //6    Click on OK button
            //7    Click on Add new link again.
            //8    Enter display name same with previous display name to "display name" field.Duplicated panel
            //9    Click on OK button
            //10   VP Warning message: "Dupicated panel already exists. Please enter a different name" show up
            //Post - Condition  Delete "Duplicated panel" panel
            //                  Close Dashboard
        }


        [TestMethod]
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

        [TestMethod]
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
            Console.WriteLine("DA_PANEL_TC035 - Verify that no special character except '@' character is allowed to be inputted into \"Chart Title\" field");

            //1    Navigate to Dashboard login page
            //2    Login with valid account test / test
            //3    Click Administer link
            //4    Click Panel link
            //5    Click Add New link
            //6    Enter value into Display Name field Display Name: Logigear
            //     Enter value into Chart Title field with special characters except "@"   Chart Title: Chart#$%	
            //7    Click Ok button
            //8    VP Message "Invalid display name. The name can't contain high ASCII characters or any of following characters: /:*?<>|"#{[]{};" is displayed
            //9    Close Warning Message box
            //10   Click Add New link
            //11   Enter value into Display Name field Display Name: Logigear@	
		    //     Enter value into Chart Title field with special character is @	Char Title: Chart@	
            //12   VP the new panel is created
            //Post - Condition  Delete the newly created panel
            //                  Close TA Dashboard
        }

        [TestMethod]
        public void DA_PANEL_TC036()
        {
            Console.WriteLine("DA_PANEL_TC036 - Verify that all chart types ( Pie, Single Bar, Stacked Bar, Group Bar, Line ) are listed correctly under \"Chart Type\" dropped down menu.");

            //1    Navigate to Dashboard login page
            //2    Select a specific repository Dashboard_STT
            //3    Enter valid Username and Password   hung.nguyen / (empty)
            //4    Click 'Login' button
            //5    Click 'Add Page' link
            //6    Enter Page Name main_hung
            //7    Click 'OK' button
            //8    Click 'Choose Panels' button
            //9    Click 'Create new panel' button
            //10   Click 'Chart Type' drop - down menu
            //11  VP 'Chart Type' are listed 5 options: 'Pie', 'Single Bar', 'Stacked Bar', 'Group Bar' and 'Line'
        }
    }
}
