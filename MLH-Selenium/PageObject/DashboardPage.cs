using OpenQA.Selenium;
using MLH_Selenium.Extension;
using MLH_Selenium.Common;
using System.Threading;

namespace MLH_Selenium.PageObject
{
    public class DashboardPage: GeneralPage
    {
        #region Elements

        #endregion

        #region Actions
        /// <summary>
        /// Gets the user login.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>string</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/7/2016</createdDate>
        public string getUserLogin(string username)
        {
            string xpathLoginUser = "//a[@href='#Welcome' and text() = '{0}']";
            string loginuser = string.Format(xpathLoginUser, username);
            return findElementByStringAndMethod(loginuser).Text;
        }
        #endregion
    }
}
