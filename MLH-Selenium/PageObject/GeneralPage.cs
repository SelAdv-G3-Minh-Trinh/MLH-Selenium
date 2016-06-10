using OpenQA.Selenium;
using MLH_Selenium.Extension;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MLH_Selenium.Common;

namespace MLH_Selenium.PageObject
{
    public class GeneralPage : PageBase
    {
        #region Elements
        /// <summary>
        /// Gets the logout_ link.
        /// </summary>
        /// <value>
        /// The logout_ link.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/7/2016</createdDate>
        public WebElement Logout_Link
        {
            get { return findElementByStringAndMethod("//a[@href = 'logout.do' and text() = 'Logout']"); }
        }

        /// <summary>
        /// Gets the welcome_ link.
        /// </summary>
        /// <value>
        /// The welcome_ link.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/7/2016</createdDate>
        public WebElement Welcome_Link
        {
            get { return findElementByStringAndMethod("//a[@href='#Welcome']"); }
        }

        /// <summary>
        /// Gets the repository_ link.
        /// </summary>
        /// <value>
        /// The repository_ link.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/8/2016</createdDate>
        public WebElement Repository_Link
        {
            get { return findElementByStringAndMethod("//a[@href = '#Repository']/span"); }
        }

        /// <summary>
        /// Gets the global setting_ LNK.
        /// </summary>
        /// <value>
        /// The global setting_ LNK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        public WebElement GlobalSetting_Lnk
        {
            get { return findElementByStringAndMethod("//li[@class = 'mn-setting']"); }
        }

        /// <summary>
        /// Gets the administer_ LNK.
        /// </summary>
        /// <value>
        /// The administer_ LNK.
        /// </value>
        /// <author>Hoang Ha</author>
        /// <createdDate>5/31/2016</createdDate>
        public WebElement Administer_Lnk
        {
            get { return findElementByStringAndMethod(".//a[.='Administer']"); }
        }

        /// <summary>
        /// Gets the addnewpanels_ LNK.
        /// </summary>
        /// <value>
        /// The addnewpanels_ LNK.
        /// </value>
        /// <author>Hoang Ha</author>
        /// <createdDate>5/31/2016</createdDate>
        public WebElement Addnewpanels_Lnk
        {
            get { return findElementByStringAndMethod(".//a[.='Add New']"); }
        }

        /// <summary>
        /// Gets the add page_ LNK.
        /// </summary>
        /// <value>
        /// The add page_ LNK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        public WebElement AddPage_Lnk
        {
            get { return findElementByStringAndMethod("//a[@class='add' and text()='Add Page']"); }
        }

        /// <summary>
        /// Gets the delete page_ LNK.
        /// </summary>
        /// <value>
        /// The delete page_ LNK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>5/11/2016</modifyDate>
        public WebElement DeletePage_Lnk
        {
            get { return findElementByStringAndMethod("//a[@class='delete' and text()='Delete']"); }
        }

        /// <summary>
        /// Gets the edit page_ LNK.
        /// </summary>
        /// <value>
        /// The edit page_ LNK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/15/2016</createdDate>
        public WebElement EditPage_Lnk
        {
            get { return findElementByStringAndMethod("//a[@class='edit' and text()='Edit']"); }
        }

        /// <summary>
        /// Gets the panels_ LNK.
        /// </summary>
        /// <value>
        /// The panels_ LNK.
        /// </value>
        /// <author>Hoang Ha</author>
        /// <createdDate>5/31/2016</createdDate>
        public WebElement Panels_Lnk
        {
            get { return findElementByStringAndMethod(".//a[.='Panels']"); }
        }

        /// <summary>
        /// Gets the active page_ LNK.
        /// </summary>
        /// <value>
        /// The active page_ LNK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/15/2016</createdDate>
        public WebElement ActivePage_Lnk
        {
            get { return findElementByStringAndMethod("//a[starts-with(@class,'active')]"); }
        }

        /// <summary>
        /// Gets the add new_ LNK.
        /// </summary>
        /// <value>
        /// The add new_ LNK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/23/2016</createdDate>
        public WebElement AddNew_Lnk
        {
            get { return findElementByStringAndMethod("//a[text() = 'Add New']"); }
        }

        /// <summary>
        /// Gets the choose panel_ BTN.
        /// </summary>
        /// <value>
        /// The choose panel_ BTN.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/23/2016</createdDate>
        public WebElement ChoosePanel_Btn
        {
            get { return findElementByStringAndMethod("//a[@id='btnChoosepanel']"); }
        }

        /// <summary>
        /// Gets the create panel_ BTN.
        /// </summary>
        /// <value>
        /// The create panel_ BTN.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/23/2016</createdDate>
        public WebElement CreatePanel_Btn
        {
            get { return findElementByStringAndMethod("//span[text()='Create new panel']"); }
        }

        #endregion

        #region Actions

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        /// <returns>Login page displays after loging out successfully</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/7/2016</createdDate>
        public LoginPage Logout()
        {
            Welcome_Link.MouseHover(driver);
            Logout_Link.Click();
            return new LoginPage();
        }

        /// <summary>
        /// Changes the repository.
        /// </summary>
        /// <param name="repositoryName">Name of the repository.</param>
        /// <returns>Dashboard page displays after changing successfully</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        public DashboardPage ChangeRepository(string repositoryName)
        {
            string repoName = string.Format("//a[text()='{0}']", repositoryName);
            Repository_Link.MouseHover(driver);
            findElementByStringAndMethod(repoName).Click();
            return new DashboardPage();
        }

        /// <summary>
        /// Go to the add panels using administer -> panels link.
        /// </summary>
        /// <returns>Dashboard page displays after navigating</returns>
        /// <author>Hoang Ha</author>
        /// <createdDate>5/31/2016</createdDate>
        public DashboardPage GotoAddPanels()
        {            
            Administer_Lnk.MouseHover(driver);
            Panels_Lnk.Click();
            Addnewpanels_Lnk.Click();
            return new DashboardPage();
        }

        /// <summary>
        /// Gets the name of the repository.
        /// </summary>
        /// <returns>string name of repository</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/7/2016</createdDate>
        public string getRepositoryName()
        {
            Thread.Sleep(500);
            return Repository_Link.Text;
        }

        /// <summary>
        /// Gets the alert message.
        /// </summary>
        /// <returns>string message of alert</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/7/2016</createdDate>
        public string GetAlertMessage()
        {
            string message = driver.SwitchToAlert().Text;
            driver.SwitchToAlert().Accept();            
            return message;
        }

        /// <summary>
        /// Goes to page.
        /// </summary>
        /// <param name="linkPath">The link path.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>5/15/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>5/16/2016</modifyDate>
        public void goToPage(string linkPath)
        {
            string[] links = linkPath.Split('/');
            for (int i = 0; i < links.Length - 1; i++)
            {
                findElementByStringAndMethod(string.Format("//a[text()='{0}']", links[i].Replace(" ", "\u00A0"))).MouseHover(driver);
            }
            if (linkPath.Contains("Administer/"))
            {
                driver.WaitForElementToBeClickable(findElementByStringAndMethod(string.Format("//a[text()='{0}']", links[links.Length - 1])));
                findElementByStringAndMethod(string.Format("//a[text()='{0}']", links[links.Length - 1])).Click();
            }
            else {
                driver.WaitForElementToBeClickable(findElementByStringAndMethod(string.Format("//a[text()='{0}']", links[links.Length - 1].Replace(" ", "\u00A0"))));
                findElementByStringAndMethod(string.Format("//a[text()='{0}']", links[links.Length - 1].Replace(" ", "\u00A0"))).Click();
            }            
        }

        /// <summary>
        /// Goes to data profiles using Administer/Data Profiles.
        /// </summary>
        /// <returns>Manage profile page displays when navigating</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>6/9/2016</createdDate>
        public ManageProfilePage goToDataProfiles()
        {
            goToPage("Administer/Data Profiles");
            return new ManageProfilePage();
        }

        /// <summary>
        /// Deletes a page.
        /// </summary>
        /// <param name="linkPath">The link path.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>5/23/2016</modifyDate>
        public void deleteAPage(string linkPath)
        {
            goToPage(linkPath);
            GlobalSetting_Lnk.MouseHover(driver);     
            DeletePage_Lnk.Click();
            driver.SwitchToAlert().Accept();
            Thread.Sleep(500);
        }

        /// <summary>
        /// Gets the delet message.
        /// </summary>
        /// <param name="pagename">The pagename.</param>
        /// <returns>string of message displays when deleting one page</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/16/2016</createdDate>
        public string getDeletMessage(string pagename)
        {
            goToPage(pagename);
            GlobalSetting_Lnk.MouseHover(driver);
            DeletePage_Lnk.Click();
            string message = driver.SwitchToAlert().Text;
            driver.SwitchToAlert().Accept();
            Thread.Sleep(500);
            return message;
        }

        /// <summary>
        /// Accesses the delete LNK.
        /// </summary>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/15/2016</createdDate>
        public void accessDeleteLnk()
        {
            GlobalSetting_Lnk.MouseHover(driver);
            DeletePage_Lnk.Click();
        }

        /// <summary>
        /// Goes to add page.
        /// </summary>
        /// <returns>manage pages displays when navigating</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        public ManagePagesPage goToAddPage()
        {
            GlobalSetting_Lnk.MouseHover(driver);
            AddPage_Lnk.Click();
            return new ManagePagesPage();
        }

        /// <summary>
        /// Go to the edit page by clicking on name of page
        /// </summary>
        /// <param name="pagename">The pagename.</param>
        /// <returns>Manage page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/15/2016</createdDate>
        public ManagePagesPage gotoEditPage(string pagename)
        {
            goToPage(pagename);
            GlobalSetting_Lnk.MouseHover(driver);
            EditPage_Lnk.Click();
            return new ManagePagesPage();
        }

        /// <summary>
        /// Gets the name of the active page.
        /// </summary>
        /// <returns>string name of page</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/15/2016</createdDate>
        public string getActivePageName()
        {
            return ActivePage_Lnk.Text;
        }

        /// <summary>
        /// Checks the setting display.
        /// </summary>
        /// <returns>true if enable, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/15/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>5/16/2016</modifyDate>
        public bool checkSettingDisplay()
        {
            if (!GlobalSetting_Lnk.Enabled)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Checks the delete LNK.
        /// </summary>
        /// <returns>true if delete successfully, false if not</returns>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>5/23/2016</modifyDate>
        public bool checkDeleteLnk()
        {
            try
            {
                if (DeletePage_Lnk.Displayed)
                    return true;
                else
                    return false;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the name page next to.
        /// </summary>
        /// <param name="afterpage">The afterpage.</param>
        /// <returns>string name of page</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>5/11/2016</modifyDate>
        public string getNamePageNextTo(string afterpage)
        {
            afterpage = afterpage.Replace(" ", "\u00A0");            
            ReadOnlyCollection<IWebElement> pages = driver.FindElements(By.XPath(string.Format("//li[a[text()='{0}']]/following-sibling::li/a", afterpage)), Constant.timeout);            
            return pages[0].Text;
        }

        /// <summary>
        /// Deletes all pages.
        /// </summary>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/19/2016</createdDate>
        public void deleteAllPages()
        {
            List<string> lstPageNames = new List<string>();

            ReadOnlyCollection<IWebElement> childOverview = driver.FindElements(By.XPath(string.Format("//a[.='{0}']/../ul/li/a", "Overview")));
            if (childOverview.Count > 0)
            {
                foreach (IWebElement childPage in childOverview)
                {
                    lstPageNames.Add("Overview/" + childPage.GetAttribute("innerHTML").Replace("&nbsp;", Constant.nonBreakingSpace));
                }
            }
            
            ReadOnlyCollection<IWebElement> pages = driver.FindElements(By.XPath("//li[a[text()='Overview']]/following-sibling::li/a"), Constant.timeout);
            foreach (IWebElement page in pages)
            {
                string innerHTML = page.GetAttribute("innerHTML");
                if (innerHTML != "Execution&nbsp;Dashboard" && innerHTML != "")
                {
                    ReadOnlyCollection<IWebElement> childPages = driver.FindElements(By.XPath(string.Format("//a[.='{0}']/../ul/li/a", page.Text.Replace(" ", Constant.nonBreakingSpace))));
                    if (childPages.Count > 0)
                    {
                        foreach(IWebElement childPage in childPages)
                        {                            
                            lstPageNames.Add(page.Text + "/" + childPage.GetAttribute("innerHTML").Replace("&nbsp;", Constant.nonBreakingSpace));
                        }
                    }
                    lstPageNames.Add(page.Text);
                }
            }

            foreach (string name in lstPageNames)
            {
                if (name.Contains("/"))
                {                    
                    deleteAPage(name);                 
                }
            }

            foreach (string name in lstPageNames)
            {
                if (!name.Contains("/"))
                {
                    WebElement element = findElementByStringAndMethod(string.Format("//li/a[text()='{0}']", name.Replace(" ", Constant.nonBreakingSpace)));
                    deleteAPage(name);
                    driver.WaitForElementNotVisible(element, 5);
                }
            }
        }

        /// <summary>
        /// Gets the total columns.
        /// </summary>
        /// <param name="pageLink">The page link.</param>
        /// <returns>number of columns of page</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/17/2016</createdDate>
        public int getTotalColumns(string pageLink)
        {
            goToPage(pageLink);
            return driver.FindElements(By.XPath("//div[@id='columns']/ul[@class='column ui-sortable']")).Count;
        }

        /// <summary>
        /// Determines whether [is page link displayed] [the specified page link].
        /// </summary>
        /// <param name="pageLink">The page link.</param>
        /// <returns>true if page displays, false if not</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/23/2016</createdDate>
        public bool isPageLinkDisplayed(string pageLink)
        {
            string link = string.Format("//a[text()='{0}']", pageLink.Replace(" ", Constant.nonBreakingSpace));

            WebElement element = findElementByStringAndMethod(link);

            if (element == null)
                return false;
            else {
                if (element.Displayed)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Determines whether [is page visible] [the specified pagename].
        /// </summary>
        /// <param name="pagename">The pagename.</param>
        /// <returns>true if page visile, false is not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>5/16/2016</modifyDate>
        public bool isPageVisible(string pagename)
        {
            return driver.Title == "TestArchitect ™ - " + pagename ? true : false;
        }

        /// <summary>
        /// Determines whether [is pop up displayed] [the specified popupname].
        /// </summary>
        /// <param name="popupname">The popupname.</param>
        /// <returns>true if popup displays, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/15/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>5/16/2016</modifyDate>
        public bool isPopUpDisplayed(string popupname)
        {
            if (driver.FindElement(By.XPath(string.Format("//h2[text() = '{0}']", popupname))).Displayed)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gotoes the add panel.
        /// </summary>
        /// <returns>Panel page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public PanelPage gotoAddPanel()
        {
            AddNew_Lnk.Click();
            return new PanelPage();
        }

        /// <summary>
        /// Go to the add profile.
        /// </summary>
        /// <returns>manage profile page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        public ManageProfilePage gotoAddProfile()
        {
            AddNew_Lnk.Click();
            return new ManageProfilePage();
        }

        /// <summary>
        /// Determines whether [is items disable].
        /// </summary>
        /// <returns>true if enable, false if not</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/31/2016</createdDate>
        public bool isItemsDisable()
        {
            if (findElementByStringAndMethod("//div[@class = 'ui-dialog-overlay custom-overlay']").Displayed)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Goes to add panel by choose panel.
        /// </summary>
        /// <returns>panel page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/23/2016</createdDate>
        public PanelPage goToAddPanelByChoosePanel()
        {
            ChoosePanel_Btn.Click();
            CreatePanel_Btn.Click();

            return new PanelPage();
        }

        /// <summary>
        /// Goes to panel configuration page.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>panel page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/30/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>6/02/2016</modifyDate>
        public PanelPage goToPanelConfigPage(string name)
        {
            ChoosePanel_Btn.Click();

            findElementByStringAndMethod(string.Format("//a[text()='{0}']", name.Replace(" ", Constant.nonBreakingSpace))).Click();
            return new PanelPage();
        }

        /// <summary>
        /// Determines whether [is panel created] [the specified name].
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>true if panel is created, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/30/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>6/8/2016</modifyDate>
        public bool isPanelCreated(string name)
        {
            bool result = true;
            if (findElementByStringAndMethod(string.Format("//div[@title='{0}']", name)).Enabled == true)
                result = true;
            else
                result = false;
            return result;
        }

        /// <summary>
        /// Determines whether [is item belongs to dropdownlist] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="listitems">The listitems.</param>
        /// <returns>true if item has in list, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/8/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate></modifyDate>
        public bool isItemBelongsToDropdownlist(string item, ReadOnlyCollection<IWebElement> listitems)
        {
            bool result = true;
            foreach (IWebElement oneitem in listitems)
            {
                if (oneitem.Text == item)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Alphabets the order checking.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>true if sorted by alphabet, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/7/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>6/8/2016</modifyDate>
        public bool alphabetOrderChecking(ReadOnlyCollection<IWebElement> items)
        {
            bool t = true;
            if (items.Count > 1)
            {
                for (int i = 0; i < items.Count - 1; i++)
                {
                    if (string.Compare(items[i].Text, items[i + 1].Text) > 0)
                    {
                        t = false;
                        break;
                    }
                }
            }
            return t;
        }

        /// <summary>
        /// Checks the data profile order.
        /// </summary>
        /// <returns>true if order correctly, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/7/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate></modifyDate>
        public bool checkDataProfileOrder()
        {
            ReadOnlyCollection<IWebElement> listProfile = driver.FindElements(By.XPath("//select[@id='cbbProfile']/option"));
            return alphabetOrderChecking(listProfile);
        }

        /// <summary>
        /// Checks the choose panel order.
        /// </summary>
        /// <param name="typeChart">The type chart.</param>
        /// <returns>true if order correctly, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/7/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>6/8/2016</modifyDate>
        public bool checkChoosePanelOrder(string typeChart)
        {
            ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath(string.Format("//div[text()='{0}']/../table[@width='100%']/tbody/tr/td//li", typeChart)));
            return alphabetOrderChecking(rows);
        }

        /// <summary>
        /// Checks the data profile grid order.
        /// </summary>
        /// <returns>true if order correctly, false if not</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/7/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate></modifyDate>
        public bool checkDataProfileGridOrder()
        {
            ReadOnlyCollection<IWebElement> profiles = driver.FindElements(By.XPath(string.Format("//table[@class='GridView']//tr/td[count(//table[@class='GridView']//th[.='Data Profile']/preceding::th) + 1]")));
            return alphabetOrderChecking(profiles);
        }

        /// <summary>
        /// Go to the choose panel.
        /// </summary>
        /// <returns>Panel page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/7/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>6/8/2016</modifyDate>
        public PanelPage gotoChoosePanel()
        {
            Thread.Sleep(500);
            ChoosePanel_Btn.Click();
            return new PanelPage();
        }

        /// <summary>
        /// Gotoes the edit panelby clicking edit icon.
        /// </summary>
        /// <param name="panelName">Name of the panel.</param>
        /// <returns>Panel page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/7/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate></modifyDate>
        public PanelPage gotoEditPanelbyClickingEditIcon(string panelName)
        {            
            findElementByStringAndMethod(string.Format("//div[@title='{0}']/../following-sibling::div//ul//li[@title='Edit Panel']", panelName)).Click();
            return new PanelPage();
        }

        /// <summary>
        /// Removes the panel chart.
        /// </summary>
        /// <param name="panelName">Name of the panel.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>6/7/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate></modifyDate>
        public void removePanelChart(string panelName)
        {
            findElementByStringAndMethod(string.Format("//div[@title='{0}']/../following-sibling::div//ul//li[1]//div[@class='hm']", panelName)).Click();
            findElementByStringAndMethod(string.Format("//div[@title='{0}']/../following-sibling::div//ul//li[1]//div[@class='cc']//span[@title='Remove panel']", panelName)).Click();
        }

        /// <summary>
        /// Gotoes the name of the panel configuration page by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>panel page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>6/7/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate</modifyDate>
        public PanelPage gotoPanelConfigPageByName(string name)
        {
            gotoChoosePanel();
            findElementByStringAndMethod(string.Format("//table[@width='100%']//tr//td//a[contains(@title,'{0}')]", name.Replace(" ", Common.Constant.nonBreakingSpace))).Click();
            return new PanelPage();
        }
        #endregion
    }
}