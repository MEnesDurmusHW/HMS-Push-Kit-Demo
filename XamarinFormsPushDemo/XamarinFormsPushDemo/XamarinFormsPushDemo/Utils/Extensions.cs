using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsPushDemo.Utils
{
    public static class Extensions
    {
        public static string DictionaryToString(this IDictionary<string, string> dict)
        {
            //string result = string.Empty;

            //foreach (var key in value.Keys)
            //{
            //    result += $"\n{key}: {value[key]}";
            //}

            //return result;
            if (dict == null) return null;
            string result = string.Empty;
            foreach (var item in dict)
            {
                if (item.Value == null || item.Value == string.Empty) continue;
                result += item.Key + ": " + item.Value + "\n";
            }
            return result;
        }
    }
}
