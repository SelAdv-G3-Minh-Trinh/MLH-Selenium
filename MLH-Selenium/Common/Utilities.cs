using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLH_Selenium.Common
{
    public class Utilities
    {
        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            return "MLH" + DateTime.Now.ToString("dd.mm.yyy") + new string(Enumerable.Repeat(Constant.AlphanumericCharacters, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
