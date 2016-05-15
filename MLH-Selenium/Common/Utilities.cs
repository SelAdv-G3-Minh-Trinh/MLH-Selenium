using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLH_Selenium.Common
{
    public class Utilities
    {
        public static string randomString()
        {
            Random ran = new Random();
            return ran.Next(0, 9).ToString() + ran.Next(0, 9).ToString() + ran.Next(100, 999).ToString();
        }
    }
}
