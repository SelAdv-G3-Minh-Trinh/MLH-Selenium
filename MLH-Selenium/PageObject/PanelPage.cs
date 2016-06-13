using MLH_Selenium.Extension;
using MLH_Selenium.ObjectData;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace MLH_Selenium.PageObject
{
    public class PanelPage : GeneralPage
    {
        #region Elements
        public WebElement PanelName_Txt
        {
            get { return findElementByStringAndMethod("//input[@name='txtDisplayName']"); }
        }

        public WebElement Delete_Lnk
        {
            get { return findElementByStringAndMethod("//div[@class='panel_tag2']/a[.='Delete']"); }
        }

        public WebElement OK_Btn
        {
            get { return findElementByStringAndMethod("//div[@id='div_panelPopup']//div[@class='div_button']/input[@id='OK']"); }
        }

        public WebElement Cancel_Btn
        {
            get { return findElementByStringAndMethod("//div[@id='div_panelPopup']//div[@class='div_button']/input[@id='Cancel']"); }
        }

        public WebElement OKPanelConfiguration_Btn
        {
            get { return findElementByStringAndMethod("//div[@id='div_panelConfigurationDlg']//div[@class='div_button']/input[@id='OK']"); }
        }

        public WebElement PanelConfigurationCancel_Btn
        {
            get { return findElementByStringAndMethod("//div[@id='div_panelConfigurationDlg']//div[@class='div_button']/input[@id='Cancel']"); }
        }

        public WebElement Edit_lnk
        {
            get { return findElementByStringAndMethod(".//*[@id='chkDelPanel']"); }
        }

        public SelectElement DataProfile_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@name='cbbProfile']")); }
        }

        public SelectElement ChartType_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@name='cbbChartType']")); }
        }

        public SelectElement Category_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//*[@id='cbbCategoryField']")); }
        }

        public SelectElement Series_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@name='cbbSeriesField']")); }
        }

        public WebElement DataLabelsSeries_Chk
        {
            get { return findElementByStringAndMethod("//input[@name='chkSeriesName']"); }
        }

        public WebElement DataLabelsCategories_Chk
        {
            get { return findElementByStringAndMethod("//input[@name='chkCategoriesName']"); }
        }

        public WebElement DataLabelsValue_Chk
        {
            get { return findElementByStringAndMethod("//input[@name='chkValue']"); }
        }

        public WebElement DataLabelsPercentage_Chk
        {
            get { return findElementByStringAndMethod("//input[@name='chkPercentage']"); }
        }

        public WebElement ChartTitle_txt
        {
            get { return findElementByStringAndMethod("//input[@id='txtChartTitle']"); }
        }

        public WebElement ShowTitle_Chk
        {
            get { return findElementByStringAndMethod("//input[@id='chkShowTitle']"); }
        }

        public WebElement Style2D_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='rdoChartStyle2D']"); }
        }

        public WebElement Style3D_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='rdoChartStyle3D']"); }
        }

        public WebElement LegendNone_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='radPlacementNone']"); }
        }

        public WebElement LegendTop_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='radPlacementTop']"); }
        }

        public WebElement LegendRight_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='radPlacementRight']"); }
        }

        public WebElement LegendLeft_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='radPlacementLeft']"); }
        }

        public WebElement LegendBottom_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='radPlacementBottom']"); }
        }

        public SelectElement SelectPage_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@name='cbbPages']")); }
        }

        public WebElement Height_txt
        {
            get { return findElementByStringAndMethod("//input[@id='txtHeight']"); }
        }

        public WebElement Folder_txt
        {
            get { return findElementByStringAndMethod("//input[@id='txtFolder']"); }
        }

        public WebElement OkSelectFolder_btn
        {
            get { return findElementByStringAndMethod("//input[@id='btnFolderSelectionOK']"); }
        }

        public WebElement Folder_img
        {
            get { return findElementByStringAndMethod("//img[@src='images/folderopen.gif']"); }
        }

        public WebElement CaptionX_txt
        {
            get { return findElementByStringAndMethod("//input[@id='txtCategoryXAxis']"); }
        }

        public WebElement CaptionY_txt
        {
            get { return findElementByStringAndMethod("//input[@id='txtValueYAxis']"); }
        }

        public WebElement CheckAll_lnk
        {
            get { return findElementByStringAndMethod("//a[text()='Check All']"); }
        }

        public WebElement UncheckAll_lnk
        {
            get { return findElementByStringAndMethod("//a[text()='UnCheck All']"); }
        }

        #endregion

        #region Actions

        public void selectTypeOfPanel(string paneltype)
        {
            if (paneltype == "Chart")
                findElementByStringAndMethod("//input[@id='radPanelType0']").Click();
            else if (paneltype == "Indicator")
                findElementByStringAndMethod("//input[@id='radPanelType1']").Click();
            else if (paneltype == "Report")
                findElementByStringAndMethod("//input[@id='radPanelType2']").Click();
            else if (paneltype == "Heat Map")
                findElementByStringAndMethod("//input[@id='radPanelType3").Click();
        }

        public void submitpanelInformation(Panel panel)
        {
            selectTypeOfPanel(panel.TypeOfPanel);
            PanelName_Txt.Clear();
            PanelName_Txt.SendKeys(panel.DisplayName);
            if (panel.TypeOfPanel == "Chart")
            {
                Thread.Sleep(500);
                Series_Cb.SelectByValue(panel.Series.ToLower());
            }
        }

        public void submitPanelConfig(Panel panel)
        {
            Folder_txt.SendKeys(panel.Folder);
            SelectPage_Cb.SelectByText(panel.SelectPage);
            Height_txt.SendKeys(panel.Height);
        }

        public PanelPage addNewPanelInfo(Panel panel)
        {
            submitpanelInformation(panel);
            OK_Btn.Click();

            return this;
        }

        public PanelPage addNewPageConfig(Panel panel)
        {
            submitPanelConfig(panel);
            OKPanelConfiguration_Btn.Click();

            return this;
        }

        public PanelPage addNewPageWithoutConfig(Panel panel)
        {
            submitpanelInformation(panel);
            OK_Btn.Click();
            PanelConfigurationCancel_Btn.Click();

            return this;
        }
        public bool checkChartType()
        {
            ReadOnlyCollection<IWebElement> types = driver.FindElements(By.XPath("//select[@name='cbbChartType']/option"), 5);
            string[] chartTypes = Common.Constant.chartTypes;

            int count = 0;
            foreach (IWebElement type in types)
            {
                foreach (string chartype in chartTypes)
                {
                    if (type.Text == chartype)
                    {
                        count++;
                        break;
                }
            }
            }

            if (count == chartTypes.Length)
                return true;
            else
                return false;
        }

        public bool isDataLabelsSeriesCheckboxEnable()
        {
            bool result = true;
            if (DataLabelsSeries_Chk.Enabled == true)
                result = true;
            else if (DataLabelsSeries_Chk.Enabled == false)
                result = false;
            return result;
        }

        public bool isDataLabelsCategoriesCheckboxEnable()
        {
            bool result = true;
            if (DataLabelsCategories_Chk.Enabled == true)
                result = true;
            else if (DataLabelsCategories_Chk.Enabled == false)
                result = false;
            return result;
        }

        public bool isDataLabelsValuesCheckboxEnable()
        {
            bool result = true;
            if (DataLabelsValue_Chk.Enabled == true)
                result = true;
            else if (DataLabelsValue_Chk.Enabled == false)
                result = false;
            return result;
        }

        public bool isDataLabelsPercentageCheckboxEnable()
        {
            bool result = true;
            if (DataLabelsPercentage_Chk.Enabled == true)
                result = true;
            else if (DataLabelsPercentage_Chk.Enabled == false)
                result = false;
            return result;
        }

        public void selectChartType(string name)
        {
            Thread.Sleep(500);
            ChartType_Cb.SelectByText(name);
        }

        public void enterFolderName(string name)
        {
            Folder_img.Click();
            findElementByStringAndMethod(string.Format("//table//input[@value='{0}'")).Click();
            OkSelectFolder_btn.Click();
        }

        public string getFolderText()
        {
            return Folder_txt.GetAttribute("value");
        }

        public void selectFolder(string path)
        {
            Folder_img.Click();

            string[] folderstrings = path.Split('/');

            if (folderstrings.Length > 2)
            {
                string folder = "";
                for (int i = 1; i < folderstrings.Length; i++)
                {
                    folder = folder + "/" + folderstrings[i];
                    findElementByStringAndMethod(string.Format("//input[@value='{0}']/preceding-sibling::a[@onclick='Dashboard.doToggle(this)']", folder)).Click();
                }
                findElementByStringAndMethod(string.Format("//input[@value='{0}']/preceding-sibling::a[@onclick='Dashboard.nodeSelected(this);']", path)).Click();

            }
            else if (folderstrings.Length == 2)
            {
                string folder = "/" + folderstrings[1];
                findElementByStringAndMethod(string.Format("//input[@value='{0}']/preceding-sibling::a[@onclick='Dashboard.nodeSelected(this);']", folder)).Click();
            }

            OkSelectFolder_btn.Click();
        }

        public void CreatePanel(string displayname, string series)
        {
            PanelName_Txt.SendKeys(displayname);
            Series_Cb.SelectByText(series);
            OK_Btn.Click();
        }

        public PanelPage DeletePanel(string displayName)
        {
            WebElement element = findElementByStringAndMethod(string.Format("//a[.='{0}']/../preceding-sibling::td/input", displayName));
            element.Check();
            Delete_Lnk.Click();
            driver.SwitchToAlert().Accept();
            return this;
        }

        public PanelPage EditPanel(string displayname)
        {
            PanelName_Txt.Clear();
            PanelName_Txt.SendKeys(displayname);
            OK_Btn.Click();
            return this;
        }

        public string GetDisplayName(string displayname)
        {
            string xpathUsername = "//a[@href='javascript:Dashboard.configPanel('b4lac0wg1iyr');' and text() = '{0}']";
            string panelname = string.Format(xpathUsername, displayname);
            return driver.FindElement(By.XPath(panelname)).Text;
        }

        public PanelSetting getSettingValue(PanelSetting panelSetting)
        {
            panelSetting.ChartTitle = ChartTitle_txt.Text;
            panelSetting.ShowTitle = ShowTitle_Chk.Selected.ToString();
            panelSetting.ChartType = ChartType_Cb.SelectedOption.Text;
            panelSetting.Cattegory = Category_Cb.SelectedOption.GetAttribute("disabled");
            panelSetting.Series = Series_Cb.SelectedOption.Text;
            panelSetting.LegendNone = LegendNone_Rad.GetAttribute("checked");
            panelSetting.LegendTop = LegendTop_Rad.GetAttribute("checked");
            panelSetting.LegendRight = LegendRight_Rad.GetAttribute("checked");
            panelSetting.LegendBottom = LegendBottom_Rad.GetAttribute("checked");
            panelSetting.LegendLeft = LegendLeft_Rad.GetAttribute("checked");
            panelSetting.CaptionX = CaptionX_txt.Text;
            panelSetting.CaptionY = CaptionY_txt.Text;
            return panelSetting;
        }

        public bool checkSettingValue(PanelSetting expected, PanelSetting actual)
        {
            bool result = true;
            if (expected.ChartTitle != actual.ChartTitle )
            {
                result = false;
            }
            else if (expected.ShowTitle != actual.ShowTitle)
            {
                result = false;
            }
            else if (expected.ChartType != actual.ChartType)
            {
                result = false;
            }
            else if (expected.Style2D != actual.Style2D)
            {
                result = false;
            }
            else if (expected.Style3D != actual.Style3D)
            {
                result = false;
            }
            else if (expected.Cattegory != actual.Cattegory)
            {
                result = false;
            }
            else if (expected.Series != actual.Series)
            {
                result = false;
            }
            else if (expected.LegendNone != actual.LegendNone)
            {
                result = false;
            }
            else if (expected.LegendTop != actual.LegendTop)
            {
                result = false;
            }
            else if (expected.LegendRight != actual.LegendRight)
            {
                result = false;
            }
            else if (expected.LegendBottom != actual.LegendBottom)
            {
                result = false;
            }
            else if (expected.LegendLeft != actual.LegendLeft)
            {
                result = false;
            }

            return result;
        }

        public void selectedSeriesCheckbox()
        {
            DataLabelsSeries_Chk.Click();
        }

        public void selectedPercentageCheckbox()
        {
            DataLabelsPercentage_Chk.Click();
        }

        public void selectedValueCheckbox()
        {
            DataLabelsValue_Chk.Click();
        }

        public PanelPage gotoEditPanel(string panelName)
            {
            findElementByStringAndMethod(string.Format("//a[.='{0}']/../following-sibling::td/a[text()='Edit']", panelName)).Click();
            return this;
        }

        public bool checkSettingFormLocation (string settingName)
                {
            bool result = false;
            if(findElementByStringAndMethod(string.Format("//fieldset[@id='fdSettings']//legend[text()='{0}']", settingName))!=null)
                if (PanelName_Txt.Location.Y < findElementByStringAndMethod(string.Format("//fieldset[@id='fdSettings']//legend[text()='{0}']", settingName)).Location.Y)
                    result = true;
            return result;
        }

        public bool isPanelCreated(string panelName)
        {
            return findElementByStringAndMethod(string.Format("//div[@class='al_lft' and .='{0}']", panelName)).Displayed;
        }

        public bool checkPageBelongsToSelectPage(string item)
        {
            ReadOnlyCollection<IWebElement> pages = driver.FindElements(By.XPath("//select[@name='cbbPages']/option"));
            return isItemBelongsToDropdownlist(item, pages);
        }

        public bool checkDataProfileBelongProfileDropDown(string item)
        {
            ReadOnlyCollection<IWebElement> profiles = driver.FindElements(By.XPath("//select[@name='cbbProfile']/option"));
            return isItemBelongsToDropdownlist(item, profiles);
        }

        public DashboardPage editPanelConfiguration(Panel old, Panel newvalue)
        {
            if (old.SelectPage == newvalue.SelectPage && old.Height == newvalue.Height && old.Folder == newvalue.Folder)
                OKPanelConfiguration_Btn.Click();
            else
            {
                if (old.SelectPage != newvalue.SelectPage)
                    SelectPage_Cb.SelectByText(newvalue.SelectPage);
                if (old.Height != newvalue.Height)
                    Height_txt.SendKeys(newvalue.Height);
                if (old.Folder != newvalue.Folder)
                    Folder_txt.SendKeys(newvalue.Folder);
                OKPanelConfiguration_Btn.Click();
            }
            Thread.Sleep(3000);            
            return new DashboardPage();
        }

        public Panel getPanelConfigValue(Panel panel)
        {
            panel.SelectPage = SelectPage_Cb.SelectedOption.Text;
            panel.Height = Height_txt.Text;
            panel.Folder = Folder_txt.Text;

            return panel;
                }

        public DashboardPage editPanelSettingValue (PanelSetting old, PanelSetting newvalue)
        {
            if (old.ChartTitle == newvalue.ChartTitle && old.ShowTitle == newvalue.ShowTitle && old.ChartType == newvalue.ChartType && old.Cattegory == newvalue.Cattegory
                && old.Series == newvalue.Series && old.LegendNone == newvalue.LegendNone && old.LegendTop == newvalue.LegendTop && old.LegendRight == newvalue.LegendRight
                && old.LegendBottom == newvalue.LegendBottom && old.LegendLeft == newvalue.LegendLeft && old.CaptionX == newvalue.CaptionX && old.CaptionY == newvalue.CaptionY)
                OK_Btn.Click();
                else
            {
                if (old.ChartTitle != newvalue.ChartTitle)
                    ChartTitle_txt.SendKeys(newvalue.ChartTitle);
                if (old.ShowTitle != newvalue.ShowTitle)
                    ShowTitle_Chk.Check();
                if (old.ChartType != newvalue.ChartType)
                    ChartType_Cb.SelectByText(newvalue.ChartType);
                if (old.Cattegory != newvalue.Cattegory)
                    Category_Cb.SelectByText(newvalue.Cattegory);
                if (old.Series != newvalue.Series)
                    Series_Cb.SelectByText(newvalue.Series);
                if (old.LegendNone != newvalue.LegendNone)
                    LegendNone_Rad.Check();
                if (old.LegendTop != newvalue.LegendTop)
                    LegendTop_Rad.Check();
                if (old.LegendRight != newvalue.LegendRight)
                    LegendRight_Rad.Check();
                if (old.LegendBottom != newvalue.LegendBottom)
                    LegendBottom_Rad.Check();
                if (old.LegendLeft != newvalue.LegendLeft)
                    LegendLeft_Rad.Check();
                if (old.CaptionX != newvalue.CaptionX)
                    CaptionX_txt.SendKeys(newvalue.CaptionX);
                if (old.CaptionY != newvalue.CaptionY)
                    CaptionX_txt.SendKeys(newvalue.CaptionY);
                OK_Btn.Click();
            }
            return new DashboardPage();
        }

        public DashboardPage closePanelSettingpage()
        {
            Cancel_Btn.Click();
            return new DashboardPage();
        }

        public bool checkAllCheckboxesAreChecked()
        {
            CheckAll_lnk.Click();
            int rows = int.Parse(findElementByStringAndMethod("//table[@class='GridView']//tr/td[count(//table[@class='GridView']//th[text()='Panel Name'])]").Size.ToString());
            for (int i = 2; i < rows; i++)
        {
                if (findElementByStringAndMethod(string.Format("//table[@class='GridView']//tr[{i}]/td[count(//table[@class='GridView']//th[text()='Panel Name'])]/input[@name='chkDelPanel']", i)).Selected == false)
                    return false;
            }
            return true;
        }

        public bool checkAllCheckboxesAreUnChecked()
        {
            UncheckAll_lnk.Click();
            int rows = int.Parse(findElementByStringAndMethod("//table[@class='GridView']//tr/td[count(//table[@class='GridView']//th[text()='Panel Name'])]").Size.ToString());
            for (int i = 2; i < rows; i++)
            {
                if (findElementByStringAndMethod(string.Format("//table[@class='GridView']//tr[{i}]/td[count(//table[@class='GridView']//th[text()='Panel Name'])]/input[@name='chkDelPanel']", i)).Selected == true)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
