using MLH_Selenium.Common;

namespace MLH_Selenium.ObjectData
{
    public class Panel
    {
        #region Fields
        private string typeOfPanel;
        private string displayName;
        private string series;
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
        #endregion

        #region Constructors

        public Panel() { }

        public void InitPanelInformation()
        {
            this.typeOfPanel = "Chart";
            this.displayName = Utilities.GenerateRandomString(5);
            this.series = "Name";
        }
        #endregion
    }
}
