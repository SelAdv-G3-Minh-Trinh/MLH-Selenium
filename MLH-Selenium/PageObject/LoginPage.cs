using MLH_Selenium.Extension;
using MLH_Selenium.Common;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace MLH_Selenium.PageObject
{
    public class LoginPage : GeneralPage
    {      
        #region Elements
        public SelectElement Repository_ComboBox
        {
            get { return new SelectElement(findElementByStringAndMethod("repository", Constant.method.id)); }
        }

        public WebElement UserName_TextBox
        {
            get { return findElementByStringAndMethod("username", Constant.method.id); }
        }

        public WebElement Password_TextBox
        {
            get { return findElementByStringAndMethod("password", Constant.method.id); }
        }

        public WebElement Login_Button
        {
            get { return findElementByStringAndMethod("//div[@class='btn-login']"); }
        }
        #endregion

        #region Actions   
        public DashboardPage LoginWithValidUser(string repositoryName, string username, string password)
        {
            SubmitLoginForm(repositoryName, username, password);
            return new DashboardPage();
        }

        public LoginPage LoginWithInvalidUser(string repositoryName, string username, string password)
        {
            SubmitLoginForm(repositoryName, username, password);
            return this;
        }

        public LoginPage LoginWithBlankUser(string repositoryName, string username, string password)
        {
            SubmitLoginForm(repositoryName, username, password);
            return this;
        }

        public void SubmitLoginForm(string repositoryName, string username, string password)
        {
            Repository_ComboBox.SelectByText(repositoryName);
            UserName_TextBox.SendKeys(username);
            if (password != null)
                Password_TextBox.SendKeys(password);
            Login_Button.Click();
        }

        public LoginPage open()
        {
            driver.Navigate().GoToUrl(Constant.url);
            return this;
        }
        #endregion
    }
}