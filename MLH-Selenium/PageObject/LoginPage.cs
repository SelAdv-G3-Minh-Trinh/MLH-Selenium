using MLH_Selenium.Extension;
using MLH_Selenium.Common;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace MLH_Selenium.PageObject
{
    public class LoginPage : GeneralPage
    {
        #region Elements
        /// <summary>
        /// Gets the repository_ ComboBox.
        /// </summary>
        /// <value>
        /// The repository_ ComboBox.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/5/2016</createdDate>
        public SelectElement Repository_ComboBox
        {
            get { return new SelectElement(findElementByStringAndMethod("repository", Constant.method.id)); }
        }

        /// <summary>
        /// Gets the user name_ text box.
        /// </summary>
        /// <value>
        /// The user name_ text box.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/5/2016</createdDate>
        public WebElement UserName_TextBox
        {
            get { return findElementByStringAndMethod("username", Constant.method.id); }
        }

        /// <summary>
        /// Gets the password_ text box.
        /// </summary>
        /// <value>
        /// The password_ text box.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/5/2016</createdDate>
        public WebElement Password_TextBox
        {
            get { return findElementByStringAndMethod("password", Constant.method.id); }
        }

        /// <summary>
        /// Gets the login_ button.
        /// </summary>
        /// <value>
        /// The login_ button.
        /// </value>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/5/2016</createdDate>
        public WebElement Login_Button
        {
            get { return findElementByStringAndMethod("//div[@class='btn-login']"); }
        }
        #endregion

        #region Actions   
        /// <summary>
        /// Logins the with valid user.
        /// </summary>
        /// <param name="repositoryName">Name of the repository.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Dashboard page when login successfully</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/5/2016</createdDate>
        public DashboardPage LoginWithValidUser(string repositoryName, string username, string password)
        {
            SubmitLoginForm(repositoryName, username, password);
            return new DashboardPage();
        }

        /// <summary>
        /// Logins the with invalid user.
        /// </summary>
        /// <param name="repositoryName">Name of the repository.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Login page when login failed</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/5/2016</createdDate>
        public LoginPage LoginWithInvalidUser(string repositoryName, string username, string password)
        {
            SubmitLoginForm(repositoryName, username, password);
            return this;
        }

        /// <summary>
        /// Logins the with blank user.
        /// </summary>
        /// <param name="repositoryName">Name of the repository.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Login page when login failed</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/5/2016</createdDate>
        public LoginPage LoginWithBlankUser(string repositoryName, string username, string password)
        {
            SubmitLoginForm(repositoryName, username, password);
            return this;
        }

        /// <summary>
        /// Submits the login form.
        /// </summary>
        /// <param name="repositoryName">Name of the repository.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>5/7/2016</createdDate>
        public void SubmitLoginForm(string repositoryName, string username, string password)
        {
            Repository_ComboBox.SelectByText(repositoryName);
            UserName_TextBox.SendKeys(username);
            if (password != null)
                Password_TextBox.SendKeys(password);
            Login_Button.Click();
        }

        /// <summary>
        /// Opens this instance.
        /// </summary>
        /// <returns>Login page displays when navigating to website</returns>
        /// <author>Minh Trinh</author>
        /// <createdDate>5/5/2016</createdDate>
        public LoginPage open()
        {
            driver.Navigate().GoToUrl(Constant.url);
            return this;
        }
        #endregion
    }
}