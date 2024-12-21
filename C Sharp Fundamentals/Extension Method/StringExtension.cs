using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Method
{
    internal static class StringExtension
    {
        public static string RemoveWhiteSpace(this string value)
        {
            return value.Replace(" ", "");
        }
        public static string  Reverse(this string value)
        {
            var CharArray = value.ToCharArray();
            Array.Reverse(CharArray);
            return new string (CharArray);

        }
    }
}
