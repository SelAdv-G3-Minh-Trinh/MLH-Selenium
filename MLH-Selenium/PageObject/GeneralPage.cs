using OpenQA.Selenium;
using MLH_Selenium.Extension;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        public WebElement ActivePage_Lnk
        {
            get { return findElementByStringAndMethod("//a[@class = 'active']"); }
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
                findElementByStringAndMethod(string.Format("//a[text()='{0}']", links[i])).MouseHover(driver);
            }
            findElementByStringAndMethod(string.Format("//a[text()='{0}']", links[links.Length - 1])).Click();
        }

        public void deleteAPage(string linkPath)
        {
            goToPage(linkPath);
            GlobalSetting_Lnk.MouseHover(driver);     
            DeletePage_Lnk.Click();
            driver.SwitchToAlert().Accept();
        }

        public string getDeletMessage(string pagename)
        {
            goToPage(pagename);
            GlobalSetting_Lnk.MouseHover(driver);
            DeletePage_Lnk.Click();
            string message = driver.SwitchToAlert().Text;
            driver.SwitchToAlert().Accept();
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
            if (DeletePage_Lnk.Displayed)
                return true;
            else
                return false;
        }

        public string getNamePageNextTo(string afterpage)
        {
            ReadOnlyCollection<IWebElement> pages = driver.FindElements(By.XPath(string.Format("//li[a[text()='{0}']]/following-sibling::li/a", afterpage)));            
            return pages[0].Text;
        }

        public int getTotalColumns(string pageLink)
        {
            goToPage(pageLink);
            return driver.FindElements(By.XPath("//div[@id='columns']/ul[@class='column ui-sortable']")).Count;
        }
        
        public bool isPageLinkDisplayed(string pageLink)
        {
            string link = string.Format("//a[text()='{0}']", pageLink);

            if (!driver.FindElement(By.XPath(link)).Displayed)
                return false;
            else
                return true;
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
        #endregion
    }
}