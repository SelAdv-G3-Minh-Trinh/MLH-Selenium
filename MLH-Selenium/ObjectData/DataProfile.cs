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
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

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

        public DataProfile() { }

        public void InitPanelInformation()
        {
            this.name = Utilities.GenerateRandomString(5);
            this.type = "test modules";
            this.relatedData = "None";
        }
        #endregion
    }
}
