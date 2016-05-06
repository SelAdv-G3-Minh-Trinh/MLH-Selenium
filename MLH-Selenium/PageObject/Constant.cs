﻿using OpenQA.Selenium;
using System;

namespace MLH_Selenium.PageObject
{
    public class Constant
    {
        public static IWebDriver driver;
        public const string url = @"http://localhost:54000/TADashboard/login.jsp";
        public const int implicitlyTimeSeconds = 30;

        public enum method
        {
            xpath,
            id,
            name
        }
    }
}
