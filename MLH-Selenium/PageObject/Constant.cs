using OpenQA.Selenium;
using System;

namespace MLH_Selenium.PageObject
{
    public class Constant
    {
        public static IWebDriver driver;
        public static string url = @"http://localhost:54000/TADashboard/login.jsp";
        public enum method
        {
            xpath,
            id,
            name
        }
    }
}
