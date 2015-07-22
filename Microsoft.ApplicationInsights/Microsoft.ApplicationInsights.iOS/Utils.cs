using Foundation;
using System.Collections.Generic;

namespace Microsoft.ApplicationInsights
{
    internal static class Utils
    {
        public static NSDictionary ToNSDictionary(this Dictionary<string, string> dictionary)
        {
            string[] keys = new string[dictionary.Count];
            dictionary.Keys.CopyTo(keys, 0);

            string[] values = new string[dictionary.Count];
            dictionary.Values.CopyTo(values, 0);

            NSDictionary convertedDict = NSDictionary.FromObjectsAndKeys(values, keys);
            return convertedDict;
        }
    }
}
