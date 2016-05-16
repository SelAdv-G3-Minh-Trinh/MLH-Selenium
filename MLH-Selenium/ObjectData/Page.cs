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
        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }

        public string ParentPage
        {
            get { return parentPage; }
            set { parentPage = value; }
        }


        public int NumberOfColumns
        {
            get { return numberOfColumns; }
            set { numberOfColumns = value; }
        }

        public string AfterPage
        {
            get { return afterPage; }
            set { afterPage = value; }
        }

        public bool IsPublic
        {
            get { return isPublic; }
            set { isPublic = value; }
        }
        #endregion

        #region Constructors

        public Page() { }

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
