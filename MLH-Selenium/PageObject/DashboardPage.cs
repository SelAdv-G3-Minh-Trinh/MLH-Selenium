using OpenQA.Selenium;
using MLH_Selenium.Extension;

namespace MLH_Selenium.PageObject
{
    public class DashboardPage
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
    }
}
