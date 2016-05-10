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
        public WebElement BtnLogout
        {
            get { return PageBase.findElementByStringAndMethod("//a[@href = 'logout.do' and text() = 'Logout']"); }
        }

        public WebElement BtnUser
        {
            get { return PageBase.findElementByStringAndMethod("//a[@href='#Welcome']"); }
        }

        public WebElement BtnRepository
        {
            get { return PageBase.findElementByStringAndMethod("//a[@href = '#Repository']/span"); }
        }

        #endregion

        #region Actions

        public LoginPage Logout()
        {
            //hover on user name
            BtnUser.MouseHover(BtnUser, Constant.driver);

            //click logout button
            BtnLogout.Click();

            //Login page return
            return new LoginPage();
        }

        public void Close()
        {
            Constant.driver.Dispose();
        }

        public DashboardPage changeRepository(string repositoryName)
        {
            string xpathRepoName = "//a[text()='{0}']";
            string repoName = string.Format(xpathRepoName,repositoryName);

            //Hover on Repository menu
            Actions action = new Actions(Constant.driver);
            action.MoveToElement(BtnRepository).Perform();

            //Click on repository name
            Constant.driver.FindElement(By.XPath(repoName)).Click();

            //Dashboard return
            return new DashboardPage();
      
        }

        public void NavigatetoCurrentPage()
        {
            Constant.driver.SwitchTo().Window(Constant.driver.WindowHandles.Last());
        }

        public string getRepositoryName()
        {
            NavigatetoCurrentPage();
            return BtnRepository.Text;
        }

        public string getAlertMessage()
        {
            IAlert alert = Constant.driver.SwitchTo().Alert();
            return alert.Text;
        }
        #endregion
    }
}
