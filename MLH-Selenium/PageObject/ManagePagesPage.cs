using MLH_Selenium.Extension;
using MLH_Selenium.ObjectData;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace MLH_Selenium.PageObject
{
    public class ManagePagesPage : GeneralPage
    {
        #region Elements
        /// <summary>
        /// Gets the page name_ text.
        /// </summary>
        /// <value>
        /// The page name_ text.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        public WebElement PageName_Txt
        {
            get
            {
                return findElementByStringAndMethod("//input[@id='name']");
            }
        }

        /// <summary>
        /// Gets the parent page_ CMB.
        /// </summary>
        /// <value>
        /// The parent page_ CMB.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        public SelectElement ParentPage_Cmb
        {
            get
            {
                return new SelectElement(findElementByStringAndMethod("//select[@id='parent']"));
            }
        }

        /// <summary>
        /// Gets the number page_ CMB.
        /// </summary>
        /// <value>
        /// The number page_ CMB.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        public SelectElement NumberPage_Cmb
        {
            get
            {
                Thread.Sleep(100);
                return new SelectElement(findElementByStringAndMethod("//select[@id='columnnumber']"));
            }
        }

        /// <summary>
        /// Gets the after page_ CMB.
        /// </summary>
        /// <value>
        /// The after page_ CMB.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        public SelectElement AfterPage_Cmb
        {
            get
            {
                return new SelectElement(findElementByStringAndMethod("//select[@id='afterpage']"));
            }
        }

        /// <summary>
        /// Gets the public_ CHK.
        /// </summary>
        /// <value>
        /// The public_ CHK.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        public WebElement Public_Chk
        {
            get
            {
                return findElementByStringAndMethod("//input[@id='ispublic']");
            }
        }

        /// <summary>
        /// Gets the o k_ BTN.
        /// </summary>
        /// <value>
        /// The o k_ BTN.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        public WebElement OK_Btn
        {
            get
            {
                return findElementByStringAndMethod("//input[@id='OK']");
            }
        }

        /// <summary>
        /// Gets the cancel_ BTN.
        /// </summary>
        /// <value>
        /// The cancel_ BTN.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        public WebElement Cancel_Btn
        {
            get
            {
                return findElementByStringAndMethod("//input[@id='Cancel']");
            }
        }
        #endregion

        #region Actions

        /// <summary>
        /// Submits the page information.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>5/117/2016</modifyDate>
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

        /// <summary>
        /// Adds the newpage.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>Dashboard Page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>5/117/2016</modifyDate>
        public DashboardPage addNewpage(Page page)
        {
            submitPageInformation(page);
            return new DashboardPage(); 
        }

        /// <summary>
        /// Edits the page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>Dashboard page displays</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/10/2016</createdDate>
        /// <modifyBy>Minh Trinh</modifyBy>
        /// <modifyDate>5/117/2016</modifyDate>
        public DashboardPage editPage(Page page)
        {
            submitPageInformation(page);
            return new DashboardPage();
        }

        #endregion
    }
}
