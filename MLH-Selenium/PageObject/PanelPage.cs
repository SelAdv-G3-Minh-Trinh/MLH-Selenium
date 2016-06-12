using MLH_Selenium.Extension;
using MLH_Selenium.ObjectData;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using MLH_Selenium.Common;

namespace MLH_Selenium.PageObject
{
    public class PanelPage : GeneralPage
    {
        #region Elements
        public WebElement Edit_lnk
        {
            get { return findElementByStringAndMethod(".//*[@id='chkDelPanel']"); }
        }

        public WebElement CategoryCaption_txt
        {
            get { return findElementByStringAndMethod(".//*[@id='txtCategoryXAxis']"); }
        }

        public WebElement SeriesCaption_txt
        {
            get { return findElementByStringAndMethod(".//*[@id='txtValueYAxis']"); }
        }

        public WebElement Cancel_Btn
        {
            get { return findElementByStringAndMethod("//div[@id='div_panelPopup']//div[@class='div_button']/input[@id='Cancel']"); }
        }

        public WebElement PanelName_Txt
        {
            get { return findElementByStringAndMethod("//input[@name='txtDisplayName']"); }
        }

        public WebElement ShowTitle_chk
        {
            get { return findElementByStringAndMethod(".//*[@id='chkShowTitle']"); }
        }

        public SelectElement Series_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@name='cbbSeriesField']")); }
        }

        public WebElement OK_Btn
        {
            get { return findElementByStringAndMethod("//input[@id='OK']"); }
        }

        public WebElement ConfigurationOK_Btn
        {
            get { return findElementByStringAndMethod(".//*[@id='OK']"); }
        }

        public WebElement PanelConfigurationCancel_Btn
        {
            get { return findElementByStringAndMethod(".//*[@id='Cancel']"); }
        }

        public WebElement Edit_lnkcate
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
            get { return new SelectElement(findElementByStringAndMethod(".//*[@id='cbbCategoryField']")); }
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

        public WebElement ChartTitle_txt
        {
            get { return findElementByStringAndMethod(".//*[@id='txtChartTitle']"); }
        }

        public WebElement Folder_img
        {
            get { return findElementByStringAndMethod("//img[@class='panel_setting_treefolder'"); }
        }

        public WebElement OkSelectFolder_btn
        {
            get { return findElementByStringAndMethod("//input[@id='btnFolderSelectionOK']"); }
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

        public void selectLegends(string legends)
        {
            if (legends== "None")
            {
                findElementByStringAndMethod(".//*[@id='radPlacementNone']").Click();
            }
            else if (legends == "Top")
            {
                findElementByStringAndMethod(".//*[@id='radPlacementTop']").Click();
            }
            else if (legends == "Right")
            {
                findElementByStringAndMethod(".//*[@id='radPlacementRight']").Click();
            }
            else if (legends == "Bottom")
            {
                findElementByStringAndMethod(".//*[@id='radPlacementBottom']").Click();
            }
            else
            {
                findElementByStringAndMethod(".//*[@id='radPlacementLeft']").Click();
            }
        }

        public void selectDataLabels(string datalabels)
        {
            if (datalabels == "Series")
            {
                findElementByStringAndMethod(".//*[@id='chkSeriesName']").Check();
            }
            else if (datalabels == "Categories")
            {
                findElementByStringAndMethod(".//*[@id='chkCategoriesName']").Check();
            }
            else if (datalabels == "Value")
            {
                findElementByStringAndMethod(".//*[@id='chkValue']").Check();
            }
            else
            {
                findElementByStringAndMethod(".//*[@id='chkPercentage']").Check();
            }
        }

        public void selectStyle(string stype)
        {
            if (stype=="2D")
            {
                findElementByStringAndMethod(".//*[@id='rdoChartStyle2D']").Click();
            }
            else
            {
                findElementByStringAndMethod(".//*[@id='rdoChartStyle3D']").Click();
            }
        }

        public void submitpanelInformation(Panel panel)
        {
            selectTypeOfPanel(panel.TypeOfPanel);
            PanelName_Txt.Clear();
            PanelName_Txt.SendKeys(panel.DisplayName);
            if (panel.TypeOfPanel == "Chart")
            {
                Thread.Sleep(500);
                Series_Cb.SelectByText(panel.Series);
            }
        }

        public void submitPanelConfig(Panel panel)
        {
            SelectPage_Cb.SelectByText(panel.SelectPage);
            Height_txt.SendKeys(panel.Height);
            Folder_txt.SendKeys(panel.Folder);
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
            OK_Btn.Click();

            return this;
        }

        public bool checkChartType()
        {
            List<string> charttypes = new List<string> { "Pie", "Single Bar", "Stacked Bar", "Group Bar", "Line" };

            ReadOnlyCollection<IWebElement> types = driver.FindElements(By.XPath("//select[@name='cbbChartType']/option"));

            int count = 0;
            foreach (IWebElement type in types)
            {
                foreach (string chartype in charttypes)
                {
                    count = 1;
                    if (type.Text != chartype)
                        break;
                    else
                        count++;
                }
            }

            if (count >= 5)
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

        public bool isCategoryCaptionTextboxEnable()
        {
            bool result = true;
            if (CategoryCaption_txt.Enabled == true)
                result = true;
            else if (CategoryCaption_txt.Enabled == false)
                result = false;
            return result;
        }

        public bool isSeriesCaptionTextboxEnable()
        {
            bool result = true;
            if (SeriesCaption_txt.Enabled == true)
                result = true;
            else if (SeriesCaption_txt.Enabled == false)
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

        public void selectShowTitle(bool showtitle)
        {
            if (showtitle==true)
            {
                ShowTitle_chk.Check();
            }

            else
            {
                ShowTitle_chk.UnCheck();
            }
        }

        public bool isItemBelongsToSelectPage(string item)
        {
            ReadOnlyCollection<IWebElement> pages = driver.FindElements(By.XPath("//select[@name='cbbPages']/option"));

            bool result = true;
            int count = 0;
            foreach (IWebElement page in pages)
            {
                if (page.Text == item)
                {
                    result = true;
                    break;
                }
                else
                    count++;
            }
            return result;
        }

        public void selectFolderName(string name)
        {
            Folder_img.Click();
            findElementByStringAndMethod(string.Format("//table//input[@value='{0}'")).Click();
            OkSelectFolder_btn.Click();
        }

        public string getFolderText()
        {
            return Folder_txt.Text;
        }

        public void CreatePanel(string displayname, string series)
        {
            PanelName_Txt.SendKeys(displayname);
            Series_Cb.SelectByText(series);
            OK_Btn.Click();
        }

        public void CloseWarningDialog()
        {
            driver.FindElement(By.Id("")).SendKeys(Keys.Escape);
        }


        public PanelPage EditPanel(string type, string series)
        {
            Edit_lnk.Click();
            selectTypeOfPanel(type);
            PanelName_Txt.SendKeys(Utilities.GenerateRandomString(5));
            Series_Cb.SelectByText(series);
            OK_Btn.Click();
            return this;
        }

        public PanelPage AddPanel(string type, string dataprofile, string charttitle, bool showtitle, string charttype, string style, string categorycaption ,string series, string seriescaption, string legends, string datalabels)
        {            
            selectTypeOfPanel(type);
            DataProfile_Cb.SelectByText(dataprofile);
            PanelName_Txt.SendKeys(Utilities.GenerateRandomString(5));
            ChartTitle_txt.SendKeys(charttitle);
            selectShowTitle(showtitle);
            ChartType_Cb.SelectByText(charttype);
            selectStyle(style);
            CategoryCaption_txt.SendKeys(categorycaption);
            Series_Cb.SelectByText(series);
            SeriesCaption_txt.SendKeys(seriescaption);
            selectLegends(legends);
            selectDataLabels(datalabels);
            OK_Btn.Click();
            return this;
        }

        public PanelPage AddPanelConfiguration(string height, string folder)
        {
            Height_txt.SendKeys(height);
            Folder_txt.SendKeys(folder);
            ConfigurationOK_Btn.Click();
            return this;
        }

        public DashboardPage ClosePanelConfiguration()
        {
            Cancel_Btn.Click();
            return new DashboardPage();
        }

        public string GetDisplayName(string displayname)
        {
            string xpathUsername = "//a[@href='javascript:Dashboard.configPanel('b4lac0wg1iyr');' and text() = '{0}']";
            string panelname = string.Format(xpathUsername, displayname);
            return driver.FindElement(By.XPath(panelname)).Text;
        }

        #endregion
    }
}
