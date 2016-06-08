using System.Collections;
using System.Collections.Generic;

namespace MLH_Selenium.Common
{
    public class Constant
    {
        public static Hashtable driverTable = new Hashtable();
        public const string url = @"http://groupba.dyndns.org:54000/TADashboard/login.jsp";
        //public const string url = @"http://192.168.1.101:54000/TADashboard/login.jsp";
        public const int timeout = 5;
        public const bool debug = false;
        public const string AlphanumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public const string nonBreakingSpace = "\u00A0";

        public static string[] chartTypes = { "Pie", "Single Bar", "Stacked Bar", "Group Bar", "Line" };

        public static string[] profiles = { "Action Implementation By Status", "Test Case Execution", "Test Case Execution Failed Trend", "Test Case Execution History", "Test Case Execution Results",
                                            "Test Case Execution Trend", "Test Module Execution", "Test Module Execution Failure Trend", "Test Module Execution History","Test Module Execution Results",
                                            "Test Module Execution Results Report", "Test Module Execution Trend", "Test Module Implementation By Priority", "Test Module Implementation By Status",
                                            "Test Module Status per Assigned Users", "Test Objective Execution"};

        public static string[] itemTypes = { "Test Modules", "Test Cases", "Test Objectives", "Data Sets", "Actions",
                                            "Interface Entities", "Test Results", "Test Case Results"};

        public static string[,] listRelatedData = new string [8,3] { { "Test Modules", "Related Test Results","Related Test Cases" }, {"Test Cases","Related Run Results","Related Objectives" } , { "Test Objectives","Related Run Results","Related Test Cases"},
                                                        { "Data Sets","",""}, { "Actions","Action Arguments",""}, { "Interface Entities","Interface Elements",""},
                                                        { "Test Results","Related Test Modules","Related Test Cases"}, { "Test Case Results","",""} };

        public static string[,] listRelatedFields = new string[8,18] {
                                                        { "Test Modules","Name","Description","Version","Priority","Last update date","Creation date","Notes","Check out machine","Location","Recent result","Assigned user","Status","Last updated by","Created by","Check out user","",""},
                                                        { "Test Cases","Name","Title","Notes"," Location","Recent result","","","","","","","","","","","",""},
                                                        { "Test Objectives","Name","Title","Notes","Location","Recent result","Source","","","","","","","","","","",""},
                                                        { "Data Sets","Name","Description","Assigned user","Last update date","Creation date","Notes","Check out machine","Location","Version","Status","Last updated by","Created by","Check out user","","","",""},
                                                        { "Actions","Name","Description","Assigned user","Last update date","Creation date","Notes","Check out machine","Location","Version","Status","Last updated by","Created by","Verbose description","Check out user","","",""},
                                                        { "Interface Entities","Name","Description","Assigned user","Last update date","Creation date","Notes","Check out machine","Location","Version","Status","Last updated by","Created by","Check out user","","","",""},
                                                        { "Test Results","Name","Reported by","Start time","Duration","Variation","Passed","Warnings","Automated/Manual","Notes","Location","Date of run","End time","Comment","Result","Failed","Errors","Run Machine"},
                                                        { "Test Case Results","Name","Date of run","Passed","Warnings","Notes","Location","Result","Failed","Errors","","","","","","","",""} };

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