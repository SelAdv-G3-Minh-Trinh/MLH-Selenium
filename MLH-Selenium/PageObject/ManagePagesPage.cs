using MLH_Selenium.Extension;
using MLH_Selenium.ObjectData;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace MLH_Selenium.PageObject
{
    public class ManagePagesPage : GeneralPage
    {
        #region Elements
        public WebElement PageName_Txt
        {
            get
            {
                return findElementByStringAndMethod("//input[@id='name']");
            }
        }

        public SelectElement ParentPage_Cmb
        {
            get
            {
                return new SelectElement(findElementByStringAndMethod("//select[@id='parent']"));
            }
        }

        public SelectElement NumberPage_Cmb
        {
            get
            {
                Thread.Sleep(100);
                return new SelectElement(findElementByStringAndMethod("//select[@id='columnnumber']"));
            }
        }

        public SelectElement AfterPage_Cmb
        {
            get
            {
                return new SelectElement(findElementByStringAndMethod("//select[@id='afterpage']"));
            }
        }

        public WebElement Public_Chk
        {
            get
            {
                return findElementByStringAndMethod("//input[@id='ispublic']");
            }
        }

        public WebElement OK_Btn
        {
            get
            {
                return findElementByStringAndMethod("//input[@id='OK']");
            }
        }

        public WebElement Cancel_Btn
        {
            get
            {
                return findElementByStringAndMethod("//input[@id='Cancel']");
            }
        }
        #endregion

        #region Actions

        public void submitPageInformation(Page page)
        {
            PageName_Txt.Clear();
            PageName_Txt.SendKeys(page.PageName);
            ParentPage_Cmb.SelectByText(page.ParentPage);            
            NumberPage_Cmb.SelectByText(page.NumberOfColumns.ToString());
            AfterPage_Cmb.SelectByText(page.AfterPage);
            if (page.IsPublic == true)
                Public_Chk.Check();
            OK_Btn.Click();
            Thread.Sleep(500);
        }

        public DashboardPage addNewpage(Page page)
        {
            submitPageInformation(page);
            return new DashboardPage(); 
        }

        public DashboardPage editPage(Page page)
        {
            submitPageInformation(page);
            return new DashboardPage();
        }

        #endregion
    }
}
