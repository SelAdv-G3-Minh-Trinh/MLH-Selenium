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
        /// <summary>
        /// Gets or sets the type of panel.
        /// </summary>
        /// <value>
        /// The type of panel.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public string TypeOfPanel
        {
            get { return typeOfPanel; }
            set { typeOfPanel = value; }
        }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        /// <value>
        /// The series.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public string Series
        {
            get { return series; }
            set { series = value; }
        }

        /// <summary>
        /// Gets or sets the select page.
        /// </summary>
        /// <value>
        /// The select page.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public string SelectPage
        {
            get { return selectPage; }
            set { selectPage = value; }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public string Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Gets or sets the folder.
        /// </summary>
        /// <value>
        /// The folder.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public string Folder
        {
            get { return folder; }
            set { folder = value; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Panel"/> class.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
        public Panel() { }

        /// <summary>
        /// Initializes the panel information.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>5/21/2016</createdDate>
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
