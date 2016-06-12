using MLH_Selenium.Extension;
using MLH_Selenium.ObjectData;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace MLH_Selenium.PageObject
{
    public class ManagePanelPage : GeneralPage
    {
        #region Elements
        /// <summary>
        /// Gets the panel name_ text.
        /// </summary>
        /// <value>
        /// The panel name_ text.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement PanelName_Txt
        {
            get { return findElementByStringAndMethod("//input[@name='txtDisplayName']"); }
        }

        /// <summary>
        /// Gets the delete_ LNK.
        /// </summary>
        /// <value>
        /// The delete_ LNK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement Delete_Lnk
        {
            get { return findElementByStringAndMethod("//div[@class='panel_tag2']/a[.='Delete']"); }
        }

        /// <summary>
        /// Gets the o k_ BTN.
        /// </summary>
        /// <value>
        /// The o k_ BTN.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement OK_Btn
        {
            get { return findElementByStringAndMethod("//div[@id='div_panelPopup']//div[@class='div_button']/input[@id='OK']"); }
        }

        /// <summary>
        /// Gets the cancel_ BTN.
        /// </summary>
        /// <value>
        /// The cancel_ BTN.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement Cancel_Btn
        {
            get { return findElementByStringAndMethod("//div[@id='div_panelPopup']//div[@class='div_button']/input[@id='Cancel']"); }
        }

        /// <summary>
        /// Gets the ok panel configuration_ BTN.
        /// </summary>
        /// <value>
        /// The ok panel configuration_ BTN.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement OKPanelConfiguration_Btn
        {
            get { return findElementByStringAndMethod("//div[@id='div_panelConfigurationDlg']//div[@class='div_button']/input[@id='OK']"); }
        }

        /// <summary>
        /// Gets the panel configuration cancel_ BTN.
        /// </summary>
        /// <value>
        /// The panel configuration cancel_ BTN.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement PanelConfigurationCancel_Btn
        {
            get { return findElementByStringAndMethod("//div[@id='div_panelConfigurationDlg']//div[@class='div_button']/input[@id='Cancel']"); }
        }

        /// <summary>
        /// Gets the edit_lnk.
        /// </summary>
        /// <value>
        /// The edit_lnk.
        /// </value>
        /// <author>Hoang Ha</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement Edit_lnk
        {
            get { return findElementByStringAndMethod(".//*[@id='chkDelPanel']"); }
        }

        /// <summary>
        /// Gets the data profile_ cb.
        /// </summary>
        /// <value>
        /// The data profile_ cb.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public SelectElement DataProfile_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@name='cbbProfile']")); }
        }

        /// <summary>
        /// Gets the chart type_ cb.
        /// </summary>
        /// <value>
        /// The chart type_ cb.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public SelectElement ChartType_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@name='cbbChartType']")); }
        }

        /// <summary>
        /// Gets the category_ cb.
        /// </summary>
        /// <value>
        /// The category_ cb.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public SelectElement Category_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//*[@id='cbbCategoryField']")); }
        }

        /// <summary>
        /// Gets the series_ cb.
        /// </summary>
        /// <value>
        /// The series_ cb.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public SelectElement Series_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@name='cbbSeriesField']")); }
        }

        /// <summary>
        /// Gets the data labels series_ CHK.
        /// </summary>
        /// <value>
        /// The data labels series_ CHK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement DataLabelsSeries_Chk
        {
            get { return findElementByStringAndMethod("//input[@name='chkSeriesName']"); }
        }

        /// <summary>
        /// Gets the data labels categories_ CHK.
        /// </summary>
        /// <value>
        /// The data labels categories_ CHK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement DataLabelsCategories_Chk
        {
            get { return findElementByStringAndMethod("//input[@name='chkCategoriesName']"); }
        }

        /// <summary>
        /// Gets the data labels value_ CHK.
        /// </summary>
        /// <value>
        /// The data labels value_ CHK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement DataLabelsValue_Chk
        {
            get { return findElementByStringAndMethod("//input[@name='chkValue']"); }
        }

        /// <summary>
        /// Gets the data labels percentage_ CHK.
        /// </summary>
        /// <value>
        /// The data labels percentage_ CHK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement DataLabelsPercentage_Chk
        {
            get { return findElementByStringAndMethod("//input[@name='chkPercentage']"); }
        }

        /// <summary>
        /// Gets the chart title_txt.
        /// </summary>
        /// <value>
        /// The chart title_txt.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement ChartTitle_txt
        {
            get { return findElementByStringAndMethod("//input[@id='txtChartTitle']"); }
        }

        /// <summary>
        /// Gets the show title_ CHK.
        /// </summary>
        /// <value>
        /// The show title_ CHK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement ShowTitle_Chk
        {
            get { return findElementByStringAndMethod("//input[@id='chkShowTitle']"); }
        }

        /// <summary>
        /// Gets the style2 d_ RAD.
        /// </summary>
        /// <value>
        /// The style2 d_ RAD.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement Style2D_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='rdoChartStyle2D']"); }
        }

        /// <summary>
        /// Gets the style3 d_ RAD.
        /// </summary>
        /// <value>
        /// The style3 d_ RAD.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement Style3D_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='rdoChartStyle3D']"); }
        }

        /// <summary>
        /// Gets the legend none_ RAD.
        /// </summary>
        /// <value>
        /// The legend none_ RAD.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement LegendNone_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='radPlacementNone']"); }
        }

        /// <summary>
        /// Gets the legend top_ RAD.
        /// </summary>
        /// <value>
        /// The legend top_ RAD.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement LegendTop_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='radPlacementTop']"); }
        }

        /// <summary>
        /// Gets the legend right_ RAD.
        /// </summary>
        /// <value>
        /// The legend right_ RAD.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement LegendRight_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='radPlacementRight']"); }
        }

        /// <summary>
        /// Gets the legend left_ RAD.
        /// </summary>
        /// <value>
        /// The legend left_ RAD.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement LegendLeft_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='radPlacementLeft']"); }
        }

        /// <summary>
        /// Gets the legend bottom_ RAD.
        /// </summary>
        /// <value>
        /// The legend bottom_ RAD.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement LegendBottom_Rad
        {
            get { return findElementByStringAndMethod("//input[@id='radPlacementBottom']"); }
        }

        /// <summary>
        /// Gets the select page_ cb.
        /// </summary>
        /// <value>
        /// The select page_ cb.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public SelectElement SelectPage_Cb
        {
            get { return new SelectElement(findElementByStringAndMethod("//select[@name='cbbPages']")); }
        }

        /// <summary>
        /// Gets the height_txt.
        /// </summary>
        /// <value>
        /// The height_txt.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement Height_txt
        {
            get { return findElementByStringAndMethod("//input[@id='txtHeight']"); }
        }

        /// <summary>
        /// Gets the folder_txt.
        /// </summary>
        /// <value>
        /// The folder_txt.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement Folder_txt
        {
            get { return findElementByStringAndMethod("//input[@id='txtFolder']"); }
        }

        /// <summary>
        /// Gets the ok select folder_btn.
        /// </summary>
        /// <value>
        /// The ok select folder_btn.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement OkSelectFolder_btn
        {
            get { return findElementByStringAndMethod("//input[@id='btnFolderSelectionOK']"); }
        }

        /// <summary>
        /// Gets the folder_img.
        /// </summary>
        /// <value>
        /// The folder_img.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement Folder_img
        {
            get { return findElementByStringAndMethod("//img[@src='images/folderopen.gif']"); }
        }

        /// <summary>
        /// Gets the caption X_TXT.
        /// </summary>
        /// <value>
        /// The caption X_TXT.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement CaptionX_txt
        {
            get { return findElementByStringAndMethod("//input[@id='txtCategoryXAxis']"); }
        }

        /// <summary>
        /// Gets the caption y_txt.
        /// </summary>
        /// <value>
        /// The caption y_txt.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement CaptionY_txt
        {
            get { return findElementByStringAndMethod("//input[@id='txtValueYAxis']"); }
        }

        /// <summary>
        /// Gets the check all_lnk.
        /// </summary>
        /// <value>
        /// The check all_lnk.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement CheckAll_lnk
        {
            get { return findElementByStringAndMethod("//a[text()='Check All']"); }
        }

        /// <summary>
        /// Gets the uncheck all_lnk.
        /// </summary>
        /// <value>
        /// The uncheck all_lnk.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public WebElement UncheckAll_lnk
        {
            get { return findElementByStringAndMethod("//a[text()='UnCheck All']"); }
        }

        #endregion

        #region Actions

        /// <summary>
        /// Selects the type of panel.
        /// </summary>
        /// <param name="paneltype">The paneltype.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
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

        /// <summary>
        /// Submitpanels the information.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
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

        /// <summary>
        /// Submits the panel configuration.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public void submitPanelConfig(Panel panel)
        {
            Folder_txt.SendKeys(panel.Folder);
            SelectPage_Cb.SelectByText(panel.SelectPage);
            Height_txt.SendKeys(panel.Height);
        }

        /// <summary>
        /// Adds the new panel information.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <returns>Manage Panel Page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public ManagePanelPage addNewPanelInfo(Panel panel)
        {
            submitpanelInformation(panel);
            OK_Btn.Click();

            return this;
        }

        /// <summary>
        /// Adds the new page configuration.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <returns>Mange Panel Page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public ManagePanelPage addNewPageConfig(Panel panel)
        {
            submitPanelConfig(panel);
            OKPanelConfiguration_Btn.Click();

            return this;
        }

        /// <summary>
        /// Adds the new page without configuration.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <returns>Manage Panel page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public ManagePanelPage addNewPageWithoutConfig(Panel panel)
        {
            submitpanelInformation(panel);
            OK_Btn.Click();
            PanelConfigurationCancel_Btn.Click();

            return this;
        }

        /// <summary>
        /// Checks the type of the chart.
        /// </summary>
        /// <returns>true if chart displays in drop-down list, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public bool checkChartType()
        {
            ReadOnlyCollection<IWebElement> types = driver.FindElements(By.XPath("//select[@name='cbbChartType']/option"), 5);

            int count = 0;
            foreach (IWebElement type in types)
            {
                foreach (string chartype in Common.Constant.chartTypes)
                {
                    if (type.Text == chartype)
                    {
                        count++;
                        break;
                    }
                }
            }

            if (count == Common.Constant.chartTypes.Length)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Determines whether [is data labels series checkbox enable].
        /// </summary>
        /// <returns>if Series drop down list is enable, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public bool isDataLabelsSeriesCheckboxEnable()
        {
            bool result = true;
            if (DataLabelsSeries_Chk.Enabled == true)
                result = true;
            else if (DataLabelsSeries_Chk.Enabled == false)
                result = false;
            return result;
        }

        /// <summary>
        /// Determines whether [is data labels categories checkbox enable].
        /// </summary>
        /// <returns>true if categories drop down list is enable, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public bool isDataLabelsCategoriesCheckboxEnable()
        {
            bool result = true;
            if (DataLabelsCategories_Chk.Enabled == true)
                result = true;
            else if (DataLabelsCategories_Chk.Enabled == false)
                result = false;
            return result;
        }

        /// <summary>
        /// Determines whether [is data labels values checkbox enable].
        /// </summary>
        /// <returns>true if enable, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public bool isDataLabelsValuesCheckboxEnable()
        {
            bool result = true;
            if (DataLabelsValue_Chk.Enabled == true)
                result = true;
            else if (DataLabelsValue_Chk.Enabled == false)
                result = false;
            return result;
        }

        /// <summary>
        /// Determines whether [is data labels percentage checkbox enable].
        /// </summary>
        /// <returns>true if enable, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public bool isDataLabelsPercentageCheckboxEnable()
        {
            bool result = true;
            if (DataLabelsPercentage_Chk.Enabled == true)
                result = true;
            else if (DataLabelsPercentage_Chk.Enabled == false)
                result = false;
            return result;
        }

        /// <summary>
        /// Selects the type of the chart.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public void selectChartType(string name)
        {
            Thread.Sleep(500);
            ChartType_Cb.SelectByText(name);
        }

        /// <summary>
        /// Gets the folder text.
        /// </summary>
        /// <returns>text of folder</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public string getFolderText()
        {
            return Folder_txt.GetAttribute("value");
        }

        /// <summary>
        /// Selects the folder.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
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

        /// <summary>
        /// Creates the panel.
        /// </summary>
        /// <param name="displayname">The displayname.</param>
        /// <param name="series">The series.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public void CreatePanel(string displayname, string series)
        {
            PanelName_Txt.SendKeys(displayname);
            Series_Cb.SelectByText(series);
            OK_Btn.Click();
        }

        /// <summary>
        /// Deletes the panel.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <returns>Manage Panel Page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public ManagePanelPage DeletePanel(string displayName)
        {
            WebElement element = findElementByStringAndMethod(string.Format("//a[.='{0}']/../preceding-sibling::td/input", displayName));
            element.Check();
            Delete_Lnk.Click();
            driver.SwitchToAlert().Accept();
            return this;
        }

        /// <summary>
        /// Edits the panel.
        /// </summary>
        /// <param name="displayname">The displayname.</param>
        /// <returns>Manage Panel Page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public ManagePanelPage EditPanel(string displayname)
        {
            PanelName_Txt.Clear();
            PanelName_Txt.SendKeys(displayname);
            OK_Btn.Click();
            return this;
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <param name="displayname">The displayname.</param>
        /// <returns>name of panel</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public string GetDisplayName(string displayname)
        {
            string xpathUsername = "//a[@href='javascript:Dashboard.configPanel('b4lac0wg1iyr');' and text() = '{0}']";
            string panelname = string.Format(xpathUsername, displayname);
            return driver.FindElement(By.XPath(panelname)).Text;
        }

        /// <summary>
        /// Gets the setting value.
        /// </summary>
        /// <param name="panelSetting">The panel setting.</param>
        /// <returns>panel setting panel displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public PanelSetting getSettingValue(PanelSetting panelSetting)
        {
            panelSetting.ChartTitle = ChartTitle_txt.GetAttribute("value");
            panelSetting.ShowTitle = ShowTitle_Chk.Selected.ToString();
            panelSetting.ChartType = ChartType_Cb.SelectedOption.Text;
            panelSetting.Cattegory = Category_Cb.SelectedOption.GetAttribute("disabled");
            panelSetting.Series = Series_Cb.SelectedOption.Text;
            panelSetting.LegendNone = LegendNone_Rad.GetAttribute("checked");
            panelSetting.LegendTop = LegendTop_Rad.GetAttribute("checked");
            panelSetting.LegendRight = LegendRight_Rad.GetAttribute("checked");
            panelSetting.LegendBottom = LegendBottom_Rad.GetAttribute("checked");
            panelSetting.LegendLeft = LegendLeft_Rad.GetAttribute("checked");
            panelSetting.CaptionX = CaptionX_txt.GetAttribute("value");
            panelSetting.CaptionY = CaptionY_txt.GetAttribute("value");
            return panelSetting;
        }

        /// <summary>
        /// Checks the setting value.
        /// </summary>
        /// <param name="expected">The expected.</param>
        /// <param name="actual">The actual.</param>
        /// <returns>true if corrected, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
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

        /// <summary>
        /// Selecteds the series checkbox.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public void selectedSeriesCheckbox()
        {
            DataLabelsSeries_Chk.Click();
        }

        /// <summary>
        /// Selecteds the percentage checkbox.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public void selectedPercentageCheckbox()
        {
            DataLabelsPercentage_Chk.Click();
        }

        /// <summary>
        /// Selecteds the value checkbox.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public void selectedValueCheckbox()
        {
            DataLabelsValue_Chk.Click();
        }

        /// <summary>
        /// go to the edit panel.
        /// </summary>
        /// <param name="panelName">Name of the panel.</param>
        /// <returns>manage panel page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public ManagePanelPage gotoEditPanel(string panelName)
        {
            findElementByStringAndMethod(string.Format("//a[.='{0}']/../following-sibling::td/a[text()='Edit']", panelName)).Click();
            return this;
        }

        /// <summary>
        /// Checks the setting form location.
        /// </summary>
        /// <param name="settingName">Name of the setting.</param>
        /// <returns>true if settting form displays, false if not </returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public bool checkSettingFormLocation (string settingName)
        {
            bool result = false;
            if(findElementByStringAndMethod(string.Format("//fieldset[@id='fdSettings']//legend[text()='{0}']", settingName))!=null)
                if (PanelName_Txt.Location.Y < findElementByStringAndMethod(string.Format("//fieldset[@id='fdSettings']//legend[text()='{0}']", settingName)).Location.Y)
                result = true;
            return result;
        }

        /// <summary>
        /// Determines whether [is panel created] [the specified panel name].
        /// </summary>
        /// <param name="panelName">Name of the panel.</param>
        /// <returns>true if panel displays, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/28/2016</createdDate>
        public bool isPanelCreated(string panelName)
        {
            return findElementByStringAndMethod(string.Format("//div[@class='al_lft' and .='{0}']", panelName)).Displayed;
        }

        /// <summary>
        /// Checks the page belongs to select page.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>true if item displays, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/28/2016</createdDate>
        public bool checkPageBelongsToSelectPage(string item)
        {
            ReadOnlyCollection<IWebElement> pages = driver.FindElements(By.XPath("//select[@name='cbbPages']/option"));
            return isItemBelongsToDropdownlist(item, pages);
        }

        /// <summary>
        /// Checks the data profile belong profile drop down.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>true if data displays, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/28/2016</createdDate>
        public bool checkDataProfileBelongProfileDropDown(string item)
        {
            ReadOnlyCollection<IWebElement> profiles = driver.FindElements(By.XPath("//select[@name='cbbProfile']/option"));
            return isItemBelongsToDropdownlist(item, profiles);
        }

        /// <summary>
        /// Edits the panel configuration.
        /// </summary>
        /// <param name="old">The old.</param>
        /// <param name="newvalue">The newvalue.</param>
        /// <returns>Dashboard page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/29/2016</createdDate>
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

        /// <summary>
        /// Gets the panel configuration value.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <returns>panel returns</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/29/2016</createdDate>
        public Panel getPanelConfigValue(Panel panel)
        {
            panel.SelectPage = SelectPage_Cb.SelectedOption.Text;
            panel.Height = Height_txt.Text;
            panel.Folder = Folder_txt.Text;

            return panel;
        }

        /// <summary>
        /// Edits the panel setting value.
        /// </summary>
        /// <param name="old">The old.</param>
        /// <param name="newvalue">The newvalue.</param>
        /// <returns>Dashboard page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/29/2016</createdDate>
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
                    CaptionY_txt.SendKeys(newvalue.CaptionY);
                OK_Btn.Click();
            }
            return new DashboardPage();
        }

        /// <summary>
        /// Closes the panel settingpage.
        /// </summary>
        /// <returns>Dashboard page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/28/2016</createdDate>
        public DashboardPage closePanelSettingpage()
        {
            OK_Btn.Click();
            return new DashboardPage();
        }

        /// <summary>
        /// Closes the panel configurepage.
        /// </summary>
        /// <returns>Dashboard page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/28/2016</createdDate>
        public DashboardPage closePanelConfigurepage()
        {
            OKPanelConfiguration_Btn.Click();
            return new DashboardPage();
        }

        /// <summary>
        /// Checks the statusof all checkbox.
        /// </summary>
        /// <returns>true if all check box is checked, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/28/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>5/29/2016</modifyDate>
        public bool checkStatusofAllCheckbox()
        {
            var collection = driver.FindElements(By.XPath("//table[@class='GridView']//tr/td[count(//table[@class='GridView']//th[text()='Panel Name'])]/input[@name='chkDelPanel']"));
            foreach (IWebElement elemement in collection)
            {
                if (elemement.Selected)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks all checkboxes are checked.
        /// </summary>
        /// <returns>true if checked, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/29/2016</createdDate>
        public bool checkAllCheckboxesAreChecked()
        {
            CheckAll_lnk.Click();
            return checkStatusofAllCheckbox();
        }

        /// <summary>
        /// Checks all checkboxes are un checked.
        /// </summary>
        /// <returns>true if checked, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/29/2016</createdDate>
        public bool checkAllCheckboxesAreUnChecked()
        {
            UncheckAll_lnk.Click();
            return checkStatusofAllCheckbox();
        }

        /// <summary>
        /// Clicks the create new panel.
        /// </summary>
        /// <returns>manage panel page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/29/2016</createdDate>
        public ManagePanelPage clickCreateNewPanel()
        {
            CreatePanel_Btn.Click();
            return this;
        }
        #endregion
    }
}
