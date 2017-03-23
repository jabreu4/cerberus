using System;
using System.Collections.Generic;
using System.Text;

namespace CerberusAndroid
{
    public static class ExtMethods
    {
        //Adds the signature of the Contains method for searching for a list and we want to put a comparison type so its not case sensitive
        public static bool Contains (this string source, string toCheck, StringComparison comparisonType)
        {
            return (source.IndexOf(toCheck, comparisonType) >= 0);
        }
    }
}
