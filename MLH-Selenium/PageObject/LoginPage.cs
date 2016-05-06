using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLH_Selenium.Extension;

namespace MLH_Selenium.PageObject
{
    public class LoginPage
    {
        public LoginPage()
        {

        }

        #region Elements
        public IWebElement Repository_ComboBox
        {
            get
            {
                return PageBase.convertToIWebElement("repository1", Constant.method.id);
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

        #region Actions   
        public DashboardPage loginWithValidUser(string repositoryName, string username, string password)
        {
            Repository_ComboBox.mSendKeys(repositoryName);
            UserName_TextBox.mSendKeys(username);
            if (password != null)
                Password_TextBox.mSendKeys(password);
            Login_Button.mClick();
            return new DashboardPage();
        }

        public LoginPage loginWithInvalidUser(string repositoryName, string username, string password)
        {
            Repository_ComboBox.mSendKeys(repositoryName);
            UserName_TextBox.mSendKeys(username);
            if (password != null)
                Password_TextBox.mSendKeys(password);
            Login_Button.mClick();
            return this;
        }
        #endregion
    }
}
