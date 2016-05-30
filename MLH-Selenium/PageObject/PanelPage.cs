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

        public WebElement ChartTitle_Txt
        {
            get { return findElementByStringAndMethod(".//*[@id='txtChartTitle']"); }
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
        
        public SelectElement SelectPage_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod(".//*[@id='cbbPages']")); }
        }

        public WebElement Height_Txt
        {
            get { return findElementByStringAndMethod(".//*[@id='txtHeight']"); }
        }

        public WebElement Folder_Txt
        {
            get { return findElementByStringAndMethod(".//*[@id='txtFolder']"); }
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

        public void selectStyle(string style)
        {
            if (style == "2D")
            {
                findElementByStringAndMethod(".//*[@id='rdoChartStyle2D']").Click();
            }
            else
            {
                findElementByStringAndMethod(".//*[@id='rdoChartStyle3D']").Click();
            }
        }
        public void selectLegends(string legends)
        {
            if (legends=="None")
            {
                findElementByStringAndMethod(".//*[@id='radPlacementNone']").Click();
            }
            else if(legends == "Top")
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

        public void createPanel(string type, string dataprofile, string displayname, string Charttitle, bool showtitle, string charttype, string style, string category, string series, string legends)
        {
            if (type == "")
            {
                selectTypeOfPanel("Chart");
            }
            else
            {
                selectTypeOfPanel(type);
            }

            if (dataprofile == "")
            {
                DataProfile_Cb.SelectByText("Action Implementation By Status");
            }
            else
            {
                DataProfile_Cb.SelectByText(dataprofile);
            }

            PanelName_Txt.SendKeys(displayname);

            ChartTitle_Txt.SendKeys(Charttitle);

            if (showtitle == true)
            {
                ShowTitle_chk.Check();
            }
            else
            {
                ShowTitle_chk.UnCheck();
            }

            if (charttype == "")
            {
                ChartType_Cb.SelectByText("Pie");
            }
            else
            {
                ChartType_Cb.SelectByText(charttype);
            }

            if (style=="")
            {
                selectStyle("2D");
            }
            else
            {
                selectStyle(style);
            }

            if (category!="")
            {
                Category_Cb.SelectByText(category);
            }

            if (series!="")
            {
                Series_Cb.SelectByText(series);
            }

            if (legends == "")
            {
                selectLegends("bottom");
            }
            else
            {
                selectLegends(legends);
            }
        }

        public void panelConfiguration(string selectpage, string height, string folder)
        {
            SelectPage_Cb.SelectByText(selectpage);
            if (height == "")
            {
                Height_Txt.SendKeys(400.ToString());
            }
            Height_Txt.SendKeys(height.ToString());
            Folder_Txt.SendKeys(folder);
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

        public void checkCreatePanelSettings(string charttype, string dataprofile, string displayname, string charttitle, bool showtitle, string legends)
        {
            //ChartType_Cb.SelectByText(charttype);
            //DataProfile_Cb.SelectByText(dataprofile);
            //PanelName_Txt.Text(displayname);
            //ChartTitle_Txt.Text(charttitle);
            //ShowTitle_chk.Check = true;
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
        
        #endregion
    }
}
