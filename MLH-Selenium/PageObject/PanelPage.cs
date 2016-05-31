using MLH_Selenium.Extension;
using MLH_Selenium.ObjectData;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using System.Timers;

namespace MLH_Selenium.PageObject
{
    public class PanelPage : GeneralPage
    {
        #region Elements
        public WebElement PanelName_Txt
        {
            get { return findElementByStringAndMethod("//input[@name='txtDisplayName']"); }
        }

        public SelectElement Series_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@name='cbbSeriesField']")); }
        }

        public WebElement OK_Btn
        {
            get { return findElementByStringAndMethod("//input[@id='OK']"); }
        }

        public SelectElement DataProfile_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@name='cbbProfile']")); }
        }

        public SelectElement ChartType_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@name='cbbChartType']")); }
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

        public WebElement OkSelectFolder_btn
        {
            get { return findElementByStringAndMethod("//input[@id='btnFolderSelectionOK']"); }
        }

        public WebElement Folder_img
        {
            get { return findElementByStringAndMethod("//img[@src='images/folderopen.gif']"); }
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
            OkSelectFolder_btn.Click();
  
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

        #endregion
    }
}
