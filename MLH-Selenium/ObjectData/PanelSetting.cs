namespace MLH_Selenium.ObjectData
{
    public class PanelSetting
    {
        #region Fields
        private string chartTitle;
        private string showTitle;
        private string chartType;
        private string style2D;
        private string style3D;
        private string cattegory;
        private string series;
        private string legendNone;
        private string legendTop;
        private string legendRight;
        private string legendBottom;
        private string legendLeft;
        private string captionX;
        private string captionY;
        #endregion

        #region Properties
        public string ChartTitle
        {
            get
            {
                return chartTitle;
            }

            set
            {
                chartTitle = value;
            }
        }

        public string ShowTitle
        {
            get
            {
                return showTitle;
            }

            set
            {
                showTitle = value;
            }
        }

        public string ChartType
        {
            get
            {
                return chartType;
            }

            set
            {
                chartType = value;
            }
        }

        public string Style2D
        {
            get
            {
                return style2D;
            }

            set
            {
                style2D = value;
            }
        }

        public string Style3D
        {
            get
            {
                return style3D;
            }

            set
            {
                style3D = value;
            }
        }

        public string Cattegory
        {
            get
            {
                return cattegory;
            }

            set
            {
                cattegory = value;
            }
        }

        public string Series
        {
            get
            {
                return series;
            }

            set
            {
                series = value;
            }
        }

        public string LegendNone
        {
            get
            {
                return legendNone;
            }

            set
            {
                legendNone = value;
            }
        }

        public string LegendTop
        {
            get
            {
                return legendTop;
            }

            set
            {
                legendTop = value;
            }
        }

        public string LegendRight
        {
            get
            {
                return legendRight;
            }

            set
            {
                legendRight = value;
            }
        }

        public string LegendBottom
        {
            get
            {
                return legendBottom;
            }

            set
            {
                legendBottom = value;
            }
        }

        public string LegendLeft
        {
            get
            {
                return legendLeft;
            }

            set
            {
                legendLeft = value;
            }
        }

        public string CaptionX
        {
            get
            {
                return captionX;
            }

            set
            {
                captionX = value;
            }
        }

        public string CaptionY
        {
            get
            {
                return captionY;
            }

            set
            {
                captionY = value;
            }
        }

        #endregion

        #region Constructors

        public PanelSetting() { }
        #endregion
    }
}
