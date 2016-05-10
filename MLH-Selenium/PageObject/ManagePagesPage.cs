﻿using MLH_Selenium.Extension;
using MLH_Selenium.ObjectData;
using OpenQA.Selenium.Support.UI;
using MLH_Selenium.Common;
using System;

namespace MLH_Selenium.PageObject
{
    public class ManagePagesPage: GeneralPage
    {
        #region Elements

        public WebElement PageName_Txt
        {
            get
            {
                return PageBase.findElementByStringAndMethod("//input[@id='name']");
            }
        }

        public SelectElement ParentPage_Cmb
        {
            get
            {
                return new SelectElement(PageBase.findElementByStringAndMethod("//select[@id='parent']"));
            }
        }

        public SelectElement NumberPage_Cmb
        {
            get
            {
                return new SelectElement(PageBase.findElementByStringAndMethod("//select[@id='columnnumber']"));
            }
        }

        public SelectElement AfterPage_Cmb
        {
            get
            {
                return new SelectElement(PageBase.findElementByStringAndMethod("//select[@id='afterpage']"));
            }
        }

        public WebElement Public_Chk
        {
            get
            {
                return PageBase.findElementByStringAndMethod("//input[@id='ispublic']");
            }
        }

        public WebElement OK_Btn
        {
            get
            {
                return PageBase.findElementByStringAndMethod("//input[@id='OK']");
            }
        }

        public WebElement Cancel_Btn
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
            PageName_Txt.SendKeys(page.PageName);
            ParentPage_Cmb.SelectByText(page.ParentPage);
            NumberPage_Cmb.SelectByText(page.NumberOfColumns.ToString());
            AfterPage_Cmb.SelectByText(page.AfterPage);
            if (page.IsPublic == true)
                Public_Chk.Check();

            //Click Ok button
            OK_Btn.Click();  
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
