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

        #endregion
    }
}
