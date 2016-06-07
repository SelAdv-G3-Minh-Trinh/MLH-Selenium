using MLH_Selenium.ObjectData;
using MLH_Selenium.Extension;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MLH_Selenium.PageObject
{
    public class ManageProfilePage : GeneralPage
    {
        #region Elements
        public WebElement DataProfileName_txt
        {
            get { return findElementByStringAndMethod("//input[@id='txtProfileName']"); }
        }

        public WebElement Finish_btn
        {
            get { return findElementByStringAndMethod("//input[@value='Finish']"); }
        }

        public WebElement Next_btn
        {
            get { return findElementByStringAndMethod("//input[@value='Next']"); }
        }

        public SelectElement ItemType_ddl
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@id='cbbEntityType']")); }
        }

        public SelectElement RelatedData_ddl
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@id='cbbSubReport']")); }
        }

        public WebElement Checkall_lnk
        {
            get { return findElementByStringAndMethod("//td/a[text()='Check All']"); }
        }

        public WebElement Uncheckall_lnk
        {
            get { return findElementByStringAndMethod("//td/a[text()='Uncheck All']"); }
        }

        public SelectElement SortField_ddl
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@id='cbbFields']")); }
        }
        #endregion

        #region Methods
        public void submitDataProfileInformationwithNameOnly(DataProfile data)
        {
            DataProfileName_txt.Clear();
            DataProfileName_txt.SendKeys(data.Name);
        }


        public void submitDataProfileWithMoreInfo(DataProfile data)
        {
            DataProfileName_txt.Clear();
            DataProfileName_txt.SendKeys(data.Name);
            ItemType_ddl.SelectByValue(data.Type);
            RelatedData_ddl.SelectByText(data.RelatedData);
        }

        public ManageProfilePage addNewProfilewithNameOnly(DataProfile data)
        {
            submitDataProfileInformationwithNameOnly(data);
            Finish_btn.Click();

            return this;
        }

        public ManageProfilePage addNewProfilewithMoreInformation(DataProfile data)
        {
            submitDataProfileWithMoreInfo(data);
            Next_btn.Click();

            return this;
        }

        public ManageProfilePage addNewProfilewithFinish(DataProfile data)
        {
            submitDataProfileWithMoreInfo(data);
            Finish_btn.Click();

            return this;
        }

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

        public bool checkLinkExist(string profile)
        {
            if (findElementByStringAndMethod(string.Format("//table[@class='GridView']//tr/td[count(//table[@class='GridView']//th[.='Data Profile']/preceding::th + 1) and text()='{0}']/input", profile)).GetAttribute("href") != null)
                return true;
            return false;
        }

        public bool checkCheckboxExist(string profile)
        {
            if (findElementByStringAndMethod(string.Format("//table[@class='GridView']//tr/td[count(//table[@class='GridView']//th[.='Data Profile']/preceding::th) and text()='{0}']/input[@name='chkDel']", profile)) != null)
                return true;
            return false;
        }

        public bool checkEditLinkExist(string profile)
        {
            if (findElementByStringAndMethod(string.Format("//table[@class='GridView']//tr/td[count(//table[@class='GridView']//th[.='Data Profile']/preceding::th + 6) and text()='{0}']/a[text()='Edit']", profile)) != null)
                return true;
            return false;
        }

        public bool checkLinkExistInPresetProfile()
        {
            foreach (string profile in Common.Constant.profiles)
            {
                if (checkLinkExist(profile) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public bool checkCheckboxInPresetProfile()
        {
            foreach (string profile in Common.Constant.profiles)
            {
                if (checkCheckboxExist(profile) == false)
                {
                    return false;
                }
            }
            return true;
        }

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

        public string getProfileNameAtDisplayField()
        {
            return findElementByStringAndMethod("//table[@id='profilesettings']//tr/td/strong").Text;
        }

        public bool checkCheckboxinField()
        {
            bool result = true;
            int j = int.Parse(findElementByStringAndMethod("//table[@id='profilesettings']//tr").Size.ToString());
            for (int i = 3; i < j - 2; i++)
            {
                string xpath = string.Format("//table[@id='profilesettings']//tr[{0}]/td", i);
                int k = int.Parse(findElementByStringAndMethod(xpath).Size.ToString());
                for (int l = 1; l <= k; l++)
                {
                    if (findElementByStringAndMethod(string.Format(xpath + "/td[{1}]", l)).GetAttribute("name") == null)
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        public bool checkCheckboxinDisplayFieldisChecked()
        {
            int j = int.Parse(findElementByStringAndMethod("//table[@id='profilesettings']//tr").Size.ToString());
            for (int i = 3; i < j - 2; i++)
            {
                string xpath = string.Format("//table[@id='profilesettings']//tr[{0}]/td", i);
                int k = int.Parse(findElementByStringAndMethod(xpath).Size.ToString());
                for (int l = 1; l <= k; l++)
                {
                    if (!findElementByStringAndMethod(string.Format(xpath + "/td[{1}]/name[text()='chkDisplayField']", l)).Selected)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void clickCheckAll()
        {
            Checkall_lnk.Click();
        }

        public void clickUncheckAll()
        {
            Uncheckall_lnk.Click();
        }

        public bool checkRelatedDatePopulated(string type)
        {
            ReadOnlyCollection<IWebElement> relatedData = driver.FindElements(By.XPath("//select[@id='cbbSubReport']/option"));
            int numberOfRows = Common.Constant.listRelatedData.Rank;
            bool result = false;

            ItemType_ddl.SelectByValue(type);

            for (int i = 0; i <= numberOfRows; i++)
            {
                if (type == Common.Constant.listRelatedData[i, 0])
                {
                    int numberofColumns = Common.Constant.listRelatedData.GetLength(i);

                    foreach (IWebElement data in relatedData)
                    {
                        for (int j = 0; j <= numberofColumns; j++)
                        {
                            if (data.Text == Common.Constant.listRelatedData[i, j])
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }
        public bool checkItemTypesPopulated(string type)
        {
            ReadOnlyCollection<IWebElement> itemTypes = driver.FindElements(By.XPath("//select[@id='cbbEntityType']/option"));
            int numberOfRows = Common.Constant.listRelatedFields.Rank;
            bool result = false;

            SortField_ddl.SelectByText(type);

            for (int i = 0; i <= numberOfRows; i++)
            {
                if (type == Common.Constant.listRelatedFields[i, 0])
                {
                    int numberofColumns = Common.Constant.listRelatedFields.GetLength(i);

                    foreach (IWebElement data in itemTypes)
                    {
                        for (int j = 0; j <= numberofColumns; j++)
                        {
                            if (data.Text == Common.Constant.listRelatedFields[i, j])
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void navigateToProfileSettingPage(string name)
        {
            findElementByStringAndMethod(string.Format("//td[@class='body_content_table_td']//li[text()='{0}']", name)).Click();
        }

        public void selectItemType(string type)
        {
            ItemType_ddl.SelectByValue(type);
        }

        public bool checkProfileSettingPageDisplay(string name)
        {
            navigateToProfileSettingPage(name);
            return findElementByStringAndMethod(string.Format("//td[@class='general_vertical_top']//td[text()='{0}']", name)).Displayed;
        }

        public ManageProfilePage gotoProfileSettingPageByName(string name)
        {
            findElementByStringAndMethod(string.Format("//table[@class='GridView']//tr//td[text()='{0}']", name)).Click();
            return this;
        }

        public bool checkDataAtGeneralSettingPage(DataProfile data)
        {
            if (data.Name != DataProfileName_txt.Text || data.Type != ItemType_ddl.SelectedOption.Text || data.RelatedData != RelatedData_ddl.SelectedOption.Text)
                return false;
            return true;
        }

        public void clickNextButton()
        {
            Next_btn.Click();
        }

        public bool checkSortFiedlPageIsEmpty()
        {
            int row = int.Parse(findElementByStringAndMethod("//table[@id='profilesettings']//tr").Size.ToString());
            if (row > 4)
                return false;
            return true;
        }

        public bool checkFilterFieldIsEmpty()
        {
            int items = driver.FindElements(By.XPath("//select[@id='listCondition']/option")).Count;

            if (items > 0)
                return false;
            return true;

        }

        #endregion

    }
    }
