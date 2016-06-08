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
        public WebElement Logout_Link
        {
            get { return findElementByStringAndMethod("//a[@href = 'logout.do' and text() = 'Logout']"); }
        }

        public WebElement Welcome_Link
        {
            get { return findElementByStringAndMethod("//a[@href='#Welcome']"); }
        }

        public WebElement Repository_Link
        {
            get { return findElementByStringAndMethod("//a[@href = '#Repository']/span"); }
        }

        public WebElement GlobalSetting_Lnk
        {
            get { return findElementByStringAndMethod("//li[@class = 'mn-setting']"); }
        }

        public WebElement Administer_Lnk
        {
            get { return findElementByStringAndMethod(".//a[.='Administer']"); }
        }

        public WebElement Addnewpanels_Lnk
        {
            get { return findElementByStringAndMethod(".//a[.='Add New']"); }
        }

        public WebElement AddPage_Lnk
        {
            get { return findElementByStringAndMethod("//a[@class='add' and text()='Add Page']"); }
        }

        public WebElement DeletePage_Lnk
        {
            get { return findElementByStringAndMethod("//a[@class='delete' and text()='Delete']"); }
        }

        public WebElement EditPage_Lnk
        {
            get { return findElementByStringAndMethod("//a[@class='edit' and text()='Edit']"); }
        }

        public WebElement Panels_Lnk
        {
            get { return findElementByStringAndMethod(".//a[.='Panels']"); }
        }

        public WebElement ActivePage_Lnk
        {
            get { return findElementByStringAndMethod("//a[starts-with(@class,'active')]"); }
        }

        public WebElement AddPanel_Lnk
        {
            get { return findElementByStringAndMethod("//a[text() = 'Add New']"); }
        }

        public WebElement ChoosePanel_Btn
        {
            get { return findElementByStringAndMethod("//a[@id='btnChoosepanel']"); }
        }

        public WebElement CreatePanel_Btn
        {
            get { return findElementByStringAndMethod("//span[text()='Create new panel']"); }
        }

        #endregion

        #region Actions

        public LoginPage Logout()
        {
            Welcome_Link.MouseHover(driver);
            Logout_Link.Click();
            return new LoginPage();
        }       

        public DashboardPage ChangeRepository(string repositoryName)
        {
            string repoName = string.Format("//a[text()='{0}']", repositoryName);
            Repository_Link.MouseHover(driver);
            findElementByStringAndMethod(repoName).Click();
            return new DashboardPage();
        }

        public DashboardPage GotoAddPanels()
        {            
            Administer_Lnk.MouseHover(driver);
            Panels_Lnk.Click();
            Addnewpanels_Lnk.Click();
            return new DashboardPage();
        }

        public string getRepositoryName()
        {
            Thread.Sleep(500);
            return Repository_Link.Text;
        }

        public string GetAlertMessage()
        {
            string message = driver.SwitchToAlert().Text;
            driver.SwitchToAlert().Accept();            
            return message;
        }

        public void goToPage(string linkPath)
        {
            string[] links = linkPath.Split('/');
            for (int i = 0; i < links.Length - 1; i++)
            {
                findElementByStringAndMethod(string.Format("//a[text()='{0}']", links[i].Replace(" ", "\u00A0"))).MouseHover(driver);
            }
            driver.WaitForElementToBeClickable(findElementByStringAndMethod(string.Format("//a[text()='{0}']", links[links.Length - 1].Replace(" ", "\u00A0"))));
            findElementByStringAndMethod(string.Format("//a[text()='{0}']", links[links.Length - 1].Replace(" ", "\u00A0"))).Click();
        }

        public void deleteAPage(string linkPath)
        {
            goToPage(linkPath);
            GlobalSetting_Lnk.MouseHover(driver);     
            DeletePage_Lnk.Click();
            driver.SwitchToAlert().Accept();
            Thread.Sleep(500);
        }

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

        public void accessDeleteLnk()
        {
            GlobalSetting_Lnk.MouseHover(driver);
            DeletePage_Lnk.Click();
        }

        public ManagePagesPage goToAddPage()
        {
            GlobalSetting_Lnk.MouseHover(driver);
            AddPage_Lnk.Click();
            return new ManagePagesPage();
        }

        public ManagePagesPage gotoEditPage(string pagename)
        {
            goToPage(pagename);
            GlobalSetting_Lnk.MouseHover(driver);
            EditPage_Lnk.Click();
            return new ManagePagesPage();
        }

        public string getActivePageName()
        {
            return ActivePage_Lnk.Text;
        }
        
        public bool checkSettingDisplay()
        {
            if (!GlobalSetting_Lnk.Enabled)
                return false;
            else
                return true;
        }

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

        public string getNamePageNextTo(string afterpage)
        {
            afterpage = afterpage.Replace(" ", "\u00A0");            
            ReadOnlyCollection<IWebElement> pages = driver.FindElements(By.XPath(string.Format("//li[a[text()='{0}']]/following-sibling::li/a", afterpage)), Constant.timeout);            
            return pages[0].Text;
        }

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

        public int getTotalColumns(string pageLink)
        {
            goToPage(pageLink);
            return driver.FindElements(By.XPath("//div[@id='columns']/ul[@class='column ui-sortable']")).Count;
        }

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

        public bool isPageVisible(string pagename)
        {
            return driver.Title == "TestArchitect ™ - " + pagename ? true : false;
        }

        public bool isPopUpDisplayed(string popupname)
        {
            if (driver.FindElement(By.XPath(string.Format("//h2[text() = '{0}']", popupname))).Displayed)
                return true;
            else
                return false;
        }

        public PanelPage gotoAddPanel()
        {
            AddPanel_Lnk.Click();
            return new PanelPage();
        }

        public bool isItemsDisable()
        {
            if (findElementByStringAndMethod("//div[@class = 'ui-dialog-overlay custom-overlay']").Displayed)
                return true;
            else
                return false;
        }

        public PanelPage goToAddPanelByChoosePanel()
        {
            ChoosePanel_Btn.Click();
            CreatePanel_Btn.Click();

            return new PanelPage();
        }

        public PanelPage goToPanelConfigPage(string name)
        {
            ChoosePanel_Btn.Click();

            findElementByStringAndMethod(string.Format("//a[text()='{0}']", name.Replace(" ", Constant.nonBreakingSpace))).Click();
            return new PanelPage();
        }

        public bool isPanelCreated(string name)
        {
            bool result = true;
            if (findElementByStringAndMethod(string.Format("//div[@title='{0}']", name)).Enabled == true)
                result = true;
            else
                result = false;
            return result;
        }


        #endregion
    }
}