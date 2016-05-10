using MLH_Selenium.Extension;
using MLH_Selenium.ObjectData;
using OpenQA.Selenium.Support.UI;
using System;

namespace MLH_Selenium.PageObject
{
    public class ManagePagesPage: GeneralPage
    {
        #region Elements

        public WebElement TxtPageName
        {
            get
            {
                return PageBase.findElementByStringAndMethod("//input[@id='name']");
            }
        }

        public SelectElement CboParentPage
        {
            get
            {
                return new SelectElement(PageBase.findElementByStringAndMethod("//select[@id='parent']"));
            }
        }

        public SelectElement CboNumberPage
        {
            get
            {
                return new SelectElement(PageBase.findElementByStringAndMethod("//select[@id='columnnumber']"));
            }
        }

        public SelectElement CboAfterPage
        {
            get
            {
                return new SelectElement(PageBase.findElementByStringAndMethod("//select[@id='afterpage']"));
            }
        }

        public WebElement ChkPublic
        {
            get
            {
                return PageBase.findElementByStringAndMethod("//input[@id='ispublic']");
            }
        }

        public WebElement BtnOK
        {
            get
            {
                return PageBase.findElementByStringAndMethod("//input[@id='OK']");
            }
        }

        public WebElement BtnCancel
        {
            get
            {
                return PageBase.findElementByStringAndMethod("//input[@id='Cancel']");
            }
        }
        #endregion

        #region Actions

        public void submitPageInformation (Page page)
        {
            //Provide page's information
            TxtPageName.SendKeys(page.PageName);
            CboParentPage.SelectByText(page.ParentPage);
            CboNumberPage.SelectByText(page.NumberOfColumns.ToString());
            CboAfterPage.SelectByText(page.AfterPage);
            if (page.IsPublic == true)
                ChkPublic.Check(ChkPublic);

            //Click Ok button
            BtnOK.Click();  
        }

        public DashboardPage addNewpage(Page page)
        {
            //Provide page's information
            submitPageInformation(page);

            //return Dashboard page
            return new DashboardPage(); 
        }

        #endregion
    }
}
