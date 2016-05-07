using OpenQA.Selenium;
using MLH_Selenium.Extension;

namespace MLH_Selenium.PageObject
{
    public class DashboardPage: GeneralPage
    {
        #region Elements
        public IWebElement widget_head_panel
        {
            get
            {
                return PageBase.convertToIWebElement("//div[@class='widget-head']/div[@title='Test Modules Execution Result Details by Date']");
            }
        }
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
