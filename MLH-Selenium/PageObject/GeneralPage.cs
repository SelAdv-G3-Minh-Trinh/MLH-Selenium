using OpenQA.Selenium;
using System.Linq;
using MLH_Selenium.Common;
using MLH_Selenium.Extension;

namespace MLH_Selenium.PageObject
{
    public class GeneralPage
    {
        #region Elements
        public WebElement Logout_Link
        {
            get { return PageBase.findElementByStringAndMethod("//a[@href = 'logout.do' and text() = 'Logout']"); }
        }

        public WebElement Welcome_Link
        {
            get { return PageBase.findElementByStringAndMethod("//a[@href='#Welcome']"); }
        }

        public WebElement Repository_Link
        {
            get { return PageBase.findElementByStringAndMethod("//a[@href = '#Repository']/span"); }
        }

        public WebElement GlobalSetting_Lnk
        {
            get { return PageBase.findElementByStringAndMethod("//li[@class = 'mn-setting']"); }
        }

        public WebElement AddPage_Lnk
        {
            get { return PageBase.findElementByStringAndMethod("//a[@class='add' and text()='Add Page']"); }
        }

        public WebElement DeletePage_Lnk
        {
            get { return PageBase.findElementByStringAndMethod("//a[@class='delete' and text()='Delete']"); }
        }

        #endregion

        #region Actions

        public LoginPage Logout()
        {
            Welcome_Link.MouseHover(Constant.driver);
            Logout_Link.Click();
            return new LoginPage();
        }

        public void Close()
        {
            Constant.driver.Dispose();
        }

        public DashboardPage ChangeRepository(string repositoryName)
        {
            string xpathRepoName = "//a[text()='{0}']";
            string repoName = string.Format(xpathRepoName, repositoryName);

            Repository_Link.MouseHover(Constant.driver);
            Constant.driver.FindElement(By.XPath(repoName)).Click();
            return new DashboardPage();

        }

        public void NavigatetoCurrentPage()
        {
            Constant.driver.SwitchTo().Window(Constant.driver.WindowHandles.Last());
        }

        public string getRepositoryName()
        {
            NavigatetoCurrentPage();
            return Repository_Link.Text;
        }

        public string GetAlertMessage()
        {
            return Constant.driver.SwitchToAlert().Text;
        }

        public ManagePagesPage goToAddPage()
        {
            GlobalSetting_Lnk.MouseHover(Constant.driver);
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
            string xpathPageName = "//a[text()='{0}']";
            string page = string.Format(xpathPageName, pagename);

            if (!Constant.driver.FindElement(By.XPath(page)).Displayed)
                return false;
            else
                return true;
        }

        public void deleteAPage(string pagename)
        {
            string xpathPageName = "//a[text()='{0}']";
            string page = string.Format(xpathPageName, pagename);

            Constant.driver.FindElement(By.XPath(page)).Click();

            GlobalSetting_Lnk.MouseHover(Constant.driver);
            DeletePage_Lnk.Click();

            Constant.driver.SwitchToAlert().Accept();
        }

        public string getNamePageNextTo(string newpage)
        {
            string xpathnewPage = ("//li[a[text()='{0}']]/following-sibling::li[1]/a");
            string newPage = string.Format(xpathnewPage,newpage);

            return Constant.driver.FindElement(By.XPath(newPage)).Text.ToString();
        }
        #endregion
    }
}