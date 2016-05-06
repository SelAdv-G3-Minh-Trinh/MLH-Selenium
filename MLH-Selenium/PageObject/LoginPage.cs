using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLH_Selenium.PageObject
{
    public class LoginPage
    {
        public LoginPage()
        {

        }

        #region WebElement
        public IWebElement Repository_ComboBox
        {
            get
            {
                return PageBase.convertToIWebElement("repository", Constant.method.id);
            }
        }

        public IWebElement UserName_TextBox
        {
            get
            {
                return PageBase.convertToIWebElement("username", Constant.method.id);
            }
        }

        public IWebElement Password_TextBox
        {
            get
            {
                return PageBase.convertToIWebElement("password", Constant.method.id);
            }
        }

        public IWebElement Login_Button
        {
            get
            {
                return PageBase.convertToIWebElement("//div[@class='btn-login']");
            }
        }
        #endregion

        #region HighLevelAction   
        public DashboardPage loginWithValidUser(string repositoryName, string username, string password)
        {
            Repository_ComboBox.SendKeys(repositoryName);
            UserName_TextBox.SendKeys(username);
            if (password != null)
                Password_TextBox.SendKeys(password);
            Login_Button.Click();
            return new DashboardPage();
        }
        #endregion

        public LoginPage loginWithInvalidUser(string repositoryName, string username, string password)
        {
            Repository_ComboBox.SendKeys(repositoryName);
            UserName_TextBox.SendKeys(username);
            if (password != null)
                Password_TextBox.SendKeys(password);
            Login_Button.Click();
            return this;
        }

    }
}
