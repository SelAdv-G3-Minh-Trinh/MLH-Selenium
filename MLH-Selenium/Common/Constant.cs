using MLH_Selenium.Extension;
using OpenQA.Selenium;
using System;
using System.Collections;

namespace MLH_Selenium.Common
{
    public class Constant
    {
        public static Hashtable driverTable = new Hashtable();
        public const string url = @"http://groupba.dyndns.org:54000/TADashboard/login.jsp";
        public const int timeout = 5;
        public const bool debug = false;
        public const string AlphanumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public const string adminUser = "administrator";
        public const string adminPassword = "";
        public const string mainRepository = "SampleRepository";
        public const string subRepository = "TestRepository";

        public enum method
        {
            xpath,
            id,
            name
        }
    }
}