using MLH_Selenium.Extension;
using OpenQA.Selenium;
using System;

namespace MLH_Selenium.Common
{
    public class Constant
    {
        public static WebDriver driver;
        public const string url = @"http://localhost:54000/TADashboard/login.jsp";
        public const int implicitlyTimeSeconds = 30;
        public const bool debug = false;
        public enum method
        {
            xpath,
            id,
            name
        }
    }
}
