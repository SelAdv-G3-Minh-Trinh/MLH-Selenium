using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLH_Selenium.Common
{
    public class Utilities
    {
        /// <summary>
        /// Generates the random string.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>A random string contains prefix: MLH and random string.</returns>
        /// <author>Linh Dang</author>
        /// <createdDate>5/14/2016</createdDate>
        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            return "MLH" + DateTime.Now.ToString("dd.mm.yyy") + new string(Enumerable.Repeat(Constant.AlphanumericCharacters, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
