using System;
using System.Linq;

namespace MLH_Selenium.Common
{
    public static class CommonMethod
    {
        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            return "MLH" + DateTime.Now.ToString("dd.mm.yyy") + new string(Enumerable.Repeat(Constant.AlphanumericCharacters, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
