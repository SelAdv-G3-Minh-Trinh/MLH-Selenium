using MLH_Selenium.ObjectData;
using MLH_Selenium.Extension;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using MLH_Selenium.Common;
using System.Threading;

namespace MLH_Selenium.PageObject
{
    public class ManageProfilePage : GeneralPage
    {
        #region Elements
        /// <summary>
        /// Gets the data profile name_txt.
        /// </summary>
        /// <value>
        /// The data profile name_txt.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public WebElement DataProfileName_txt
        {
            get { return findElementByStringAndMethod("//input[@id='txtProfileName']"); }
        }

        /// <summary>
        /// Gets the finish_btn.
        /// </summary>
        /// <value>
        /// The finish_btn.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public WebElement Finish_btn
        {
            get { return findElementByStringAndMethod("//input[@value='Finish']"); }
        }

        /// <summary>
        /// Gets the next_btn.
        /// </summary>
        /// <value>
        /// The next_btn.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public WebElement Next_btn
        {
            get { return findElementByStringAndMethod("//input[@value='Next']"); }
        }

        /// <summary>
        /// Gets the item type_ddl.
        /// </summary>
        /// <value>
        /// The item type_ddl.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public SelectElement ItemType_ddl
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@id='cbbEntityType']")); }
        }

        /// <summary>
        /// Gets the related data_ddl.
        /// </summary>
        /// <value>
        /// The related data_ddl.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public SelectElement RelatedData_ddl
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@id='cbbSubReport']")); }
        }

        /// <summary>
        /// Gets the checkall_lnk.
        /// </summary>
        /// <value>
        /// The checkall_lnk.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public WebElement Checkall_lnk
        {
            get { return findElementByStringAndMethod("//td/a[text()='Check All']"); }
        }

        /// <summary>
        /// Gets the uncheckall_lnk.
        /// </summary>
        /// <value>
        /// The uncheckall_lnk.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public WebElement Uncheckall_lnk
        {
            get { return findElementByStringAndMethod("//td/a[text()='Uncheck All']"); }
        }

        /// <summary>
        /// Gets the sort field_ddl.
        /// </summary>
        /// <value>
        /// The sort field_ddl.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public SelectElement SortField_ddl
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@id='cbbFields']")); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Submits the data profile informationwith name only.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public void submitDataProfileInformationwithNameOnly(DataProfile data)
        {
            DataProfileName_txt.Clear();
            DataProfileName_txt.SendKeys(data.Name);
        }


        /// <summary>
        /// Submits the data profile with more information.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate> 
        public void submitDataProfileWithMoreInfo(DataProfile data)
        {
            DataProfileName_txt.SendKeys(data.Name);
            ItemType_ddl.SelectByText(data.Type.ToLower());
            RelatedData_ddl.SelectByText(data.RelatedData);
        }

        /// <summary>
        /// Adds the new profilewith name only.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>Manage Profile page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public ManageProfilePage addNewProfilewithNameOnly(DataProfile data)
        {
            submitDataProfileInformationwithNameOnly(data);
            Finish_btn.Click();

            return this;
        }

        /// <summary>
        /// Adds the new profilewith more information.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>Manage Profile page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public ManageProfilePage addNewProfilewithMoreInformation(DataProfile data)
        {
            submitDataProfileWithMoreInfo(data);
            Next_btn.Click();

            return this;
        }

        /// <summary>
        /// Adds the new profilewith finish.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>Manage Profile Page</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public ManageProfilePage addNewProfilewithFinish(DataProfile data)
        {
            submitDataProfileWithMoreInfo(data);
            Finish_btn.Click();

            return this;
        }

        /// <summary>
        /// Checks the preset profile populate.
        /// </summary>
        /// <returns>true if populated, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public bool checkPresetProfilePopulate()
        {
            ReadOnlyCollection<IWebElement> dataProfileGrid = driver.FindElements(By.XPath("//table[@class='GridView']//tr/td[count(//table[@class='GridView']//th[.='Data Profile']/preceding::th) + 1]"));
            string[] profiles = Common.Constant.profiles;

            bool result = true;
            foreach (string profile in profiles)
            {
                foreach (IWebElement dataProfile in dataProfileGrid)
                {
                    if (dataProfile.Text == profile)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Checks the profile has link exist.
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <returns>true if profile has link, false if not</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>6/9/2016</createdDate>
        public bool checkProfileHasLinkExist(string profile)
        {
            WebElement element = findElementByStringAndMethod(string.Format("//table[@class='GridView']/tbody/tr/td[.='{0}']", profile.Replace(" ", Constant.nonBreakingSpace)));
            if (element.GetAttribute("innerHTML").Contains("<a"))
                return true;
            return false;
        }

        /// <summary>
        /// Checks the profile has checkbox exist.
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <returns>true if profile has checkbox, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>6/9/2016</modifyDate>
        public bool checkProfileHasCheckboxExist(string profile)
        {
            WebElement element = findElementByStringAndMethod(string.Format("//table[@class='GridView']/tbody/tr/td[.='{0}']/../td[1]", profile.Replace(" ", Constant.nonBreakingSpace)));
            if (element.GetAttribute("innerHTML").Contains("<input"))
                return true;
            return false;
        }

        /// <summary>
        /// Checks the profile has edit link exist.
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <returns>true if Profile has Edit link, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>6/9/2016</modifyDate>
        public bool checkProfileHasEditLinkExist(string profile)
        {
            WebElement element = findElementByStringAndMethod(string.Format("//table[@class='GridView']/tbody/tr/td[.='{0}']/../td[count(//table[@class='GridView']//th[.='Action']/preceding::th)+1]", profile.Replace(" ", Constant.nonBreakingSpace)));
            if (element.GetAttribute("innerHTML").Contains("Edit"))
                return true;
            return false;
        }

        /// <summary>
        /// Checks the link exist in preset profile.
        /// </summary>
        /// <returns>true if has link, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public bool checkLinkExistInPresetProfile()
        {
            foreach (string profile in Common.Constant.profiles)
            {
                if (checkProfileHasLinkExist(profile) == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks the checkbox in preset profile.
        /// </summary>
        /// <returns>true if profile has checkbox, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public bool checkCheckboxInPresetProfile()
        {
            foreach (string profile in Common.Constant.profiles)
            {
                if (checkProfileHasCheckboxExist(profile) == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks the item type list.
        /// </summary>
        /// <returns>true if item belongs to list, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public bool checkItemTypeList()
        {
            bool result = true;
            ReadOnlyCollection<IWebElement> types = driver.FindElements(By.XPath("//select[@name='cbbEntityType']/option"));
            foreach (string item in Common.Constant.itemTypes)
            {
                if (isItemBelongsToDropdownlist(item, types) == false)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Checks the item type listby prio.
        /// </summary>
        /// <returns>true if list sort by alphabet, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public bool checkItemTypeListbyPrio()
        {
            bool result = true;
            ReadOnlyCollection<IWebElement> listitems = driver.FindElements(By.XPath("//select[@name='cbbEntityType']/option"));
            for (int i = 1; i < Common.Constant.itemTypes.Length; i++)
            {
                if (listitems[i].Text != Common.Constant.itemTypes[i])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the profile name at display field.
        /// </summary>
        /// <returns>true if Profile name displays at Display field</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public string getProfileNameAtDisplayField()
        {
            return findElementByStringAndMethod("//table[@id='profilesettings']//tr/td/strong").Text;
        }

        /// <summary>
        /// Checks the checkboxin field.
        /// </summary>
        /// <returns>true if having checkbox, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>6/9/2016</modifyDate>
        public bool checkCheckboxinField()
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@id='profilesettings']/tbody/tr/td"));

            foreach (WebElement element in elements)
            {
                if (!element.GetAttribute("innerHTML").Contains("<input") || !element.GetAttribute("innerHTML").Contains("type=\"checkbox\""))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the checkboxin display fieldis checked.
        /// </summary>
        /// <returns>true if checkbox is checked, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>6/9/2016</modifyDate>
        public bool checkCheckboxinDisplayFieldisChecked()
        {
            var collection = driver.FindElements(By.XPath("//table[@id='profilesettings']//input[@class='box']"));
            foreach (IWebElement elemement in collection)
            {
                if (elemement.Selected)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Clicks the check all.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public void clickCheckAll()
        {
            Checkall_lnk.Click();
        }

        /// <summary>
        /// Clicks the uncheck all.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public void clickUncheckAll()
        {
            Uncheckall_lnk.Click();
        }

        /// <summary>
        /// Gets the index of item in list.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="list">The list.</param>
        /// <returns>index of item in list</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/12/2016</createdDate>
        public int getIndexOfItemInList (IWebElement data, ReadOnlyCollection<IWebElement> list)
        {
            int index = 0;

            foreach (IWebElement item in list)
            {
                if (item.Text == data.Text)
                {
                    index = list.IndexOf(data) + 1;
                    break;
                }
            }
            return index;
        }

        /// <summary>
        /// Gets the row indexof itemin list.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="list">The list.</param>
        /// <returns>index of row of item in list</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/12/2016</createdDate>
        public int getRowIndexofIteminList(string item, string list)
        {
            int index = 0;
            if (list == "Related Data")
            {
                for (int i = 0; i <= Constant.listRelatedData.GetLength(0); i++)
                {
                    if (item == Constant.listRelatedData[i, 0])
                    {
                        index = i;
                        break;
                    }
                }
            }
            else if (list == "Related Type")
            {
                for (int i = 0; i <= Constant.listRelatedFields.GetLength(0); i++)
                {
                    if (item == Constant.listRelatedFields[i, 0])
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }

        /// <summary>
        /// Checks the related date populated.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>true if list in drop down list is populated correctly, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/12/2016</createdDate>
        public bool checkRelatedDatePopulated(string type)
        {
            ItemType_ddl.SelectByText(type.ToLower());

            ReadOnlyCollection<IWebElement> relatedData = driver.FindElements(By.XPath("//select[@id='cbbSubReport']/option"));
            int indexrow = getRowIndexofIteminList(type, "Related Data");
            foreach (IWebElement data in relatedData)
            {
                int indexcol = getIndexOfItemInList(data, relatedData);
                if (data.Text.ToLower() != Constant.listRelatedData[indexrow, indexcol].ToLower())
                    return false;
            }
            return true; ;
        }

        /// <summary>
        /// Checks the item types populated.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>true if list in drop down list is populated correctly, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/12/2016</createdDate>
        public bool checkItemTypesPopulated(string type)
        {
            ReadOnlyCollection<IWebElement> relatedType = driver.FindElements(By.XPath("//select[@id='cbbFields']/option"));
            int indexrow = getRowIndexofIteminList(type, "Related Type");
            foreach (IWebElement elem in relatedType)
            {
                int indexcol = getIndexOfItemInList(elem, relatedType);
                if (elem.Text.ToLower() != Constant.listRelatedFields[indexrow, indexcol].ToLower())
                    return false;
            }
            return true; ;
        }

        /// <summary>
        /// Navigates to profile setting page.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>true if able to go to Setting page, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public bool navigateToProfileSettingPage(string name)
        {
            WebElement element = findElementByStringAndMethod(string.Format("//td[@class='body_content_table_td']//li[text()='{0}']", name));
            if (element.GetAttribute("onclick") != null)
            {
                element.Click();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Selects the type of the item.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public void selectItemType(string type)
        {
            string result = type.TrimEnd('s').ToLower();
            if (result == "interface entitie")
            {
                result = "interface entity";
            }
            if (result == "test result")
            {
                result = "result";
            }
            ItemType_ddl.SelectByValue(result);
        }

        /// <summary>
        /// Checks the profile setting page display.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>true of profile setting page displays, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public bool checkProfileSettingPageDisplay(string name)
        {
            bool isExist = navigateToProfileSettingPage(name);
            if (isExist == true)
            {
                return findElementByStringAndMethod(string.Format("//td[@class='general_vertical_top']//td[text()='{0}']", name)).Displayed;
            }
            return false;
        }

        /// <summary>
        /// Go to profle setting page when clicking name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Manage Profile page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public ManageProfilePage gotoProfileSettingPageByName(string name)
        {
            findElementByStringAndMethod(string.Format("//table[@class='GridView']//tr/td[2]/a[text()='{0}']", name)).Click();
            return this;
        }

        /// <summary>
        /// Checks the data at general setting page.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>true if data is correct, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public bool checkDataAtGeneralSettingPage(DataProfile data)
        {
            if (data.Name != DataProfileName_txt.GetAttribute("value") || data.Type != ItemType_ddl.SelectedOption.Text || data.RelatedData != RelatedData_ddl.SelectedOption.Text)
                return false;
            return true;
        }

        /// <summary>
        /// Clicks the next button.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public void clickNextButton()
        {
            Next_btn.Click();
        }

        /// <summary>
        /// Checks the sort fiedl page is empty.
        /// </summary>
        /// <returns>true if sort field is has sort condition, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public bool checkSortFiedlPageIsEmpty()
        {
            Thread.Sleep(200);
            int row = driver.FindElements(By.XPath("//table[@id='profilesettings']//tr")).Count;
            if (row > 4)
                return true;
            return false;
        }

        /// <summary>
        /// Checks the filter field is empty.
        /// </summary>
        /// <returns>true if filter field has filter condition, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        public bool checkFilterFieldIsEmpty()
        {
            WebElement element = findElementByStringAndMethod("//select[@id='listCondition']");
            if (element.GetAttribute("innerHTML").Contains("<option"))
                return true;
            return false;
        }
        #endregion
    }
}
