using OpenQA.Selenium;
using MLH_Selenium.Extension;
using MLH_Selenium.Common;

namespace MLH_Selenium.PageObject
{
    public class DashboardPage: GeneralPage
    {
        #region Elements

        #endregion

        #region Actions
        public string getUserLogin(string username)
        {
            string xpathLoginUser = "//a[@href='#Welcome' and text() = '{0}']";
            string loginuser = string.Format(xpathLoginUser, username);
            return Constant.driver.FindElement(By.XPath(loginuser)).Text;
        }
        #endregion
    }
}
