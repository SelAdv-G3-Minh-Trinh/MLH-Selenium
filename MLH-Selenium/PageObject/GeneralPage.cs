using OpenQA.Selenium;
using System.Linq;
using MLH_Selenium.Common;
using MLH_Selenium.Extension;
using System.Threading;

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
            return driver.SwitchToAlert().Text;
        }

        public ManagePagesPage goToAddPage()
        {
            GlobalSetting_Lnk.MouseHover(driver);
            AddPage_Lnk.Click();
            return new ManagePagesPage();
        }

        public bool checkSettingDisplay()
        {
            if (!GlobalSetting_Lnk.Displayed)
                return false;
            else
                return true;

        }

        public bool isPageVisible(string pagename)
        {
            string page = string.Format("//a[text()='{0}']", pagename);

            if (!driver.FindElement(By.XPath(page)).Displayed)
                return false;
            else
                return true;
        }

        public void deleteAPage(string pagename)
        {
            string page = string.Format("//a[text()='{0}']", pagename);

            driver.FindElement(By.XPath(page)).Click();

            GlobalSetting_Lnk.MouseHover(driver);
            DeletePage_Lnk.Click();

            driver.SwitchToAlert().Accept();
        }

        public string getNamePageNextTo(string newpage)
        {
            string xpathnewPage = ("//li[a[text()='{0}']]/following-sibling::li[1]/a");
            string newPage = string.Format(xpathnewPage,newpage);

            return driver.FindElement(By.XPath(newPage)).Text.ToString();
        }
        #endregion
    }
}