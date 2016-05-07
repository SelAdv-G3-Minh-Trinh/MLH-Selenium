using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace MLH_Selenium.PageObject
{
    public class GeneralPage
    {
        #region Locators
        static readonly By _btnLogout = By.XPath("//a[@href = 'logout.do' and text() = 'Logout']");
        static readonly By _btnUser = By.XPath("//a[@href='#Welcome']");
        static readonly By _btnRepository = By.XPath("//a[@href = '#Repository']/span");
        #endregion

        #region Elements
        public IWebElement BtnLogout
        {
            get { return Constant.driver.FindElement(_btnLogout); }
        }

        public IWebElement BtnUser
        {
            get { return Constant.driver.FindElement(_btnUser); }
        }

        public IWebElement BtnRepository
        {
            get { return Constant.driver.FindElement(_btnRepository); }
        }

        #endregion

        #region Actions

        public LoginPage Logout()
        {
            Actions action = new Actions(Constant.driver);
            
            //Hover on Logged user name
            action.MoveToElement(BtnUser).Perform();
            
            //Click Logout
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
