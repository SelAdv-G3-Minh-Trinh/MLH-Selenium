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

        public void selectTypeOfChartType(string charttype)
        {
            if (charttype == "Pie")
                findElementByStringAndMethod(".//*[@id='cbbChartType' and @title='Pie']").Click();
            else if (charttype == "Single Bar")
                findElementByStringAndMethod(".//*[@id='cbbChartType' and @title='Single Bar']").Click();
            else if (charttype == "Stacked Bar")
                findElementByStringAndMethod(".//*[@id='cbbChartType' and @title='Stacked Bar']").Click();
            else if (charttype == "Group Bar")
                findElementByStringAndMethod(".//*[@id='cbbChartType' and @title='Group Bar']").Click();
            else if (charttype == "Line")
                findElementByStringAndMethod(".//*[@id='cbbChartType' and @title='Line']").Click();
        }

        public void selectTypeOfDataProfile(string dataprofile)
        {
            if (dataprofile == "Action Implementation By")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Action Implementation By Status']").Click();
            else if (dataprofile == "Data23May16230004398")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Data23May16230004398']").Click();
            else if (dataprofile == "Data23May16230327894")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Data23May16230327894']").Click();
            else if (dataprofile == "Functional Tests")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Functional Tests']").Click();
            else if (dataprofile == "Test Case Execution")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Case Execution']").Click();
            else if (dataprofile == "Test Case Execution Failure Trend")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Case Execution Failure Trend']").Click();
            else if (dataprofile == "Test Case Execution History")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Case Execution History']").Click();
            else if (dataprofile == "Test Case Execution Results")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Case Execution Results']").Click();
            else if (dataprofile == "Test Case Execution Trend")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Case Execution Trend']").Click();
            else if (dataprofile == "Test Module Execution")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Module Execution']").Click();
            else if (dataprofile == "Test Module Execution Failure Trend")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Module Execution Failure Trend']").Click();
            else if (dataprofile == "Test Module Execution Failure Trend by Build")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Module Execution Failure Trend by Build']").Click();
            else if (dataprofile == "Test Module Execution History")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Module Execution History']").Click();
            else if (dataprofile == "Test Module Execution Results")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Module Execution Results']").Click();
            else if (dataprofile == "Test Module Execution Results Report")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Module Execution Results Report']").Click();
            else if (dataprofile == "Test Module Execution Trend")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Module Execution Trend']").Click();
            else if (dataprofile == "Test Module Execution Trend by Build")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Module Execution Trend by Build']").Click();
            else if (dataprofile == "Test Module Execution Trend by Build")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Module Execution Trend by Build']").Click();
            else if (dataprofile == "Test Module Implementation By Priority")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Module Implementation By Priority']").Click();
            else if (dataprofile == "Test Module Implementation By Status")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Module Implementation By Status']").Click();
            else if (dataprofile == "Test Module Status per Assigned Users")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Module Status per Assigned Users']").Click();
            else if (dataprofile == "Test Objective Execution")
                findElementByStringAndMethod(".//*[@id='cbbProfile' and @title='Test Objective Execution']").Click();
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

        public DashboardPage addNewPanel(Panel panel)
        {
            submitpanelInformation(panel);
            OK_Btn.Click();

            return new DashboardPage();
        }

        public bool checkChartType ()
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

        public bool checkCategory()
        {
            WebElement category = findElementByStringAndMethod(".//*[@id='cbbCategoryField' and @class='panelDisabledCombo']");
            if (category.Displayed==true)
            {
                return false;
            }
            return true;
        }

        public bool checkCaption()
        {
            WebElement caption = findElementByStringAndMethod(".//*[@id='txtCategoryXAxis' and @class='panelDisabledTextbox']");
            if (caption.Displayed == true)
            {
                return false;
            }
            return true;
        }

        public bool checkSeries()
        {
            WebElement series = findElementByStringAndMethod(".//*[@id='cbbSeriesField' and @ class='panelEnabledCombo']");
            if (series.Displayed == true)
            {
                return true;
            }
            return false;
        }

        public WebElement ChartType_Cbb
        {
            get { return findElementByStringAndMethod(".//*[@id='cbbChartType']"); }
        }
        #endregion
    }
}
