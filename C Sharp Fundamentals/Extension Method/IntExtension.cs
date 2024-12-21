using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Method
{
    internal static  class IntExtension
    {
        public static bool IsBetween(this int value, int min, int max)
        {
            return value >= min && value <= max;

        }
    }
}
