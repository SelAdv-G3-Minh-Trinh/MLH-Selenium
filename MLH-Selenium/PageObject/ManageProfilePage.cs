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
            DataProfileName_txt.SendKeys(data.Name);
            ItemType_ddl.SelectByText(data.Type.ToLower());
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

        public bool checkProfileHasLinkExist(string profile)
        {
            WebElement element = findElementByStringAndMethod(string.Format("//table[@class='GridView']/tbody/tr/td[.='{0}']", profile.Replace(" ", Constant.nonBreakingSpace)));
            if (element.GetAttribute("innerHTML").Contains("<a"))
                return true;
            return false;
        }

        public bool checkProfileHasCheckboxExist(string profile)
        {
            WebElement element = findElementByStringAndMethod(string.Format("//table[@class='GridView']/tbody/tr/td[.='{0}']/../td[1]", profile.Replace(" ", Constant.nonBreakingSpace)));
            if (element.GetAttribute("innerHTML").Contains("<input"))
                return true;
            return false;
        }

        public bool checkProfileHasEditLinkExist(string profile)
        {
            WebElement element = findElementByStringAndMethod(string.Format("//table[@class='GridView']/tbody/tr/td[.='{0}']/../td[count(//table[@class='GridView']//th[.='Action']/preceding::th)+1]", profile.Replace(" ", Constant.nonBreakingSpace)));
            if (element.GetAttribute("innerHTML").Contains("Edit"))
                return true;
            return false;
        }

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
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@id='profilesettings']/tbody/tr/td"));

            foreach (WebElement element in elements)
            {
                if (!element.GetAttribute("innerHTML").Contains("<input") || !element.GetAttribute("innerHTML").Contains("type=\"checkbox\""))
                    return false;
            }
            return true;
        }

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

        public void clickCheckAll()
        {
            Checkall_lnk.Click();
        }

        public void clickUncheckAll()
        {
            Uncheckall_lnk.Click();
        }

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

        public bool checkProfileSettingPageDisplay(string name)
        {
            bool isExist = navigateToProfileSettingPage(name);
            if (isExist == true)
            {
                return findElementByStringAndMethod(string.Format("//td[@class='general_vertical_top']//td[text()='{0}']", name)).Displayed;
            }
            return false;
        }

        public ManageProfilePage gotoProfileSettingPageByName(string name)
        {
            findElementByStringAndMethod(string.Format("//table[@class='GridView']//tr/td[2]/a[text()='{0}']", name)).Click();
            return this;
        }

        public bool checkDataAtGeneralSettingPage(DataProfile data)
        {
            if (data.Name != DataProfileName_txt.GetAttribute("value") || data.Type != ItemType_ddl.SelectedOption.Text || data.RelatedData != RelatedData_ddl.SelectedOption.Text)
                return false;
            return true;
        }

        public void clickNextButton()
        {
            Next_btn.Click();
        }

        public bool checkSortFiedlPageIsEmpty()
        {
            Thread.Sleep(200);
            int row = driver.FindElements(By.XPath("//table[@id='profilesettings']//tr")).Count;
            if (row > 4)
                return true;
            return false;
        }

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
