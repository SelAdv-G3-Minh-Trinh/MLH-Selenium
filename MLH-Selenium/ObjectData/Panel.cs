using MLH_Selenium.Common;

namespace MLH_Selenium.ObjectData
{
    public class Panel
    {
        #region Fields
        private string typeOfPanel;
        private string displayName;
        private string series;
        private string selectPage;
        private string height;
        private string folder;
        #endregion

        #region Properties
        public string TypeOfPanel
        {
            get { return typeOfPanel; }
            set { typeOfPanel = value; }
        }

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        public string Series
        {
            get { return series; }
            set { series = value; }
        }

        public string SelectPage
        {
            get { return selectPage; }
            set { selectPage = value; }
        }

        public string Height
        {
            get { return height; }
            set { height = value; }
        }

        public string Folder
        {
            get { return folder; }
            set { folder = value; }
        }
        #endregion

        #region Constructors

        public Panel() { }

        public void InitPanelInformation()
        {
            this.typeOfPanel = "Chart";
            this.displayName = Utilities.GenerateRandomString(5);
            this.series = "Name";
            this.selectPage = "Overview";
            this.height = "400";
            this.folder = "/Car Rental/Actions";
        }
        #endregion
    }
}
