using MLH_Selenium.Common;

namespace MLH_Selenium.ObjectData
{
    public class Page
    {
        #region Fields
        private string pageName;
        private string parentPage;
        private int numberOfColumns;
        private string afterPage;
        private bool isPublic;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name of the page.
        /// </summary>
        /// <value>
        /// The name of the page.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }

        /// <summary>
        /// Gets or sets the parent page.
        /// </summary>
        /// <value>
        /// The parent page.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public string ParentPage
        {
            get { return parentPage; }
            set { parentPage = value; }
        }


        /// <summary>
        /// Gets or sets the number of columns.
        /// </summary>
        /// <value>
        /// The number of columns.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public int NumberOfColumns
        {
            get { return numberOfColumns; }
            set { numberOfColumns = value; }
        }

        /// <summary>
        /// Gets or sets the after page.
        /// </summary>
        /// <value>
        /// The after page.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public string AfterPage
        {
            get { return afterPage; }
            set { afterPage = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is public.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is public; otherwise, <c>false</c>.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public bool IsPublic
        {
            get { return isPublic; }
            set { isPublic = value; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public Page() { }

        /// <summary>
        /// Initializes the page information.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public void InitPageInformation()
        {
            this.PageName = Utilities.GenerateRandomString(5);
            this.ParentPage = "Select parent";
            this.NumberOfColumns = 2;
            if (this.parentPage != "Select parent")
            {
                this.AfterPage = "Select page";
            }
            else
            {
                this.AfterPage = "Overview";
            }
            IsPublic = false;
        }
        #endregion
    }
}
