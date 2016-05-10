using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
            string repoName = string.Format(xpathRepoName,repositoryName);

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
        #endregion
    }
}
