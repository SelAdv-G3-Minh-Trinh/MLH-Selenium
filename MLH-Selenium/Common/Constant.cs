using System.Collections;
using System.Collections.Generic;

namespace MLH_Selenium.Common
{
    public class Constant
    {
        public static Hashtable driverTable = new Hashtable();
        public const string url = @"http://groupba.dyndns.org:54000/TADashboard/login.jsp";
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

        public static string[,] listRelatedData = new string [8,6] {
                                                        {"Test Modules","None", "Related test results","Related bugs","Related test cases","" }, 
                                                        {"Test Cases","None","Related run results","Related bugs","Related objectives","Related steps" } ,
                                                        { "Test Objectives","None", "Related run results","Related test cases","",""},
                                                        { "Data Sets","None","","","",""}, 
                                                        { "Actions","None", "Action arguments","","",""},
                                                        { "Interface Entities","None","Interface elements","","",""},
                                                        { "Test Results","None", "Related bugs", "Related test modules","Related test cases",""}, 
                                                        { "Test Case Results","None","","","",""} };

        public static string[,] listRelatedFields = new string[8,26] {
{ "Test Modules","--- Select field ---","Name","Location","Description","Recent result","Source","Version","Assigned user","Priority","Status","Last update date","Last updated by","Creation date","Created by","Notes","Check out by","URL","","","","","","","",""},
{ "Test Cases","-- Select field ---","ID","Location","Title"," Recent result","Notes","Source","URL","","","","","","","","","","","","","","","","",""},
{ "Test Objectives","--- Select field ---","ID","Location","Title","Recent result","Notes","Source","URL","","","","","","","","","","","","","","","","",""},
{ "Data Sets","--- Select field ---","Name","Location","Description","Version","Assigned user","Status","Last update date","Last updated by","Creation date","Created by","Notes","Check out by","URL","","","","","","","","","","",""},
{ "Actions","--- Select field ---","Name","Location","Description","Version","Assigned user","Status","Last update date","Last updated by","Creation date","Created by","Notes","Check out by","URL","","","","","","","","","","",""},
{ "Interface Entities","--- Select field ---","Name","Location","Description","Version","Assigned user","Status","Last update date","Last updated by","Creation date","Created by","Notes","Check out by","URL","","","","","","","","","","",""},
{ "Test Results","--- Select field ---","Name","Location","Reported by","Date of run","Start time","End time","Duration","Comment","Variation","Result","Passed","Failed","Warnings","Errors","Automated/Manual","Run Machine","Notes","URL","Baseline","OS","Device OS","Device Name","Build Number","AUTVersion"},
{ "Test Case Results","--- Select field ---","Name","Location","Date of run","Result","Passed","Failed","Warnings","Errors","Notes","URL","Build Number","","","","","","","","","","","","",""} };

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