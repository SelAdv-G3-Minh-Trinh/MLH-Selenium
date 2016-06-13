using MLH_Selenium.Common;

namespace MLH_Selenium.ObjectData
{
    public class DataProfile
    {
        #region Fields
        private string name;
        private string type;
        private string relatedData;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        /// <summary>
        /// Gets or sets the related data.
        /// </summary>
        /// <value>
        /// The related data.
        /// </value>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public string RelatedData
        {
            get
            {
                return relatedData;
            }

            set
            {
                relatedData = value;
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProfile"/> class.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public DataProfile() { }

        /// <summary>
        /// Initializes the panel information.
        /// </summary>
        /// <author>Linh Dang</author>
        /// <createdDate>6/5/2016</createdDate>
        public void InitPanelInformation()
        {
            this.name = Utilities.GenerateRandomString(5);
            this.type = "Test Modules";
            this.relatedData = "None";
        }
        #endregion
    }
}
