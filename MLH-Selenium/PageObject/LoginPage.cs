using OpenQA.Selenium;
using MLH_Selenium.Extension;
using MLH_Selenium.Common;

namespace MLH_Selenium.PageObject
{
    public class LoginPage: GeneralPage
    {
        #region Elements
        public WebElement Repository_ComboBox
        {
            get
            {
                return PageBase.findElementByStringAndMethod("repository", Constant.method.id);
            }
        }

        public WebElement UserName_TextBox
        {
            get
            {
                return PageBase.findElementByStringAndMethod("username", Constant.method.id);
            }
        }

        public WebElement Password_TextBox
        {
            get
            {
                return PageBase.findElementByStringAndMethod("password", Constant.method.id);
            }
        }

        public WebElement Login_Button
        {
            get
            {
                return PageBase.findElementByStringAndMethod("//div[@class='btn-login']");
            }
        }
        #endregion

        #region Actions   
        public DashboardPage loginWithValidUser(string repositoryName, string username, string password)
        {
            //Submit login credentails
            submitLoginForm(repositoryName, username, password);

            //Dashboard page returns
            return new DashboardPage();
        }

        public LoginPage loginWithInvalidUser(string repositoryName, string username, string password)
        {
            //Submit login credentails
            submitLoginForm(repositoryName, username, password);

            //Login page returns
            return this;
        }

        public LoginPage loginWithBlankUser(string repositoryName, string username, string password)
        {
            //Submit login credentails
            submitLoginForm(repositoryName, username, password);

            //Login page returns
            return this;
        }

        public void submitLoginForm(string repositoryName, string username, string password)
        {
            //Submit login credentails 
            Repository_ComboBox.SendKeys(repositoryName);
            UserName_TextBox.SendKeys(username);
            if (password != null)
                Password_TextBox.SendKeys(password);
            Login_Button.Click();
        }

        public LoginPage open()
        {
            Constant.driver.Navigate().GoToUrl(Constant.url);            
            return this;
        }
        #endregion
    }
}
