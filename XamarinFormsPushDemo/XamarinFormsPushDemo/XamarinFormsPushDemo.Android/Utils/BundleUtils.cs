using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinFormsPushDemo.Droid.Utils
{
    public static class BundleUtils
    {
        public static void AddString(this Bundle bundle, string key, Dictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(key))
                bundle.PutString(key, (string)dictionary[key]);
        }
        public static void AddStringArray(this Bundle bundle, string key, Dictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(key))
                bundle.PutStringArray(key, (string[])dictionary[key]);
        }
        public static void AddInt(this Bundle bundle, string key, Dictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(key))
                bundle.PutInt(key, (int)dictionary[key]);
        }
        public static void AddDouble(this Bundle bundle, string key, Dictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(key))
                bundle.PutDouble(key, (double)dictionary[key]);
        }
        public static void AddLong(this Bundle bundle, string key, Dictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(key))
                bundle.PutLong(key, Convert.ToInt64(dictionary[key]));
        }
        public static void AddBool(this Bundle bundle, string key, Dictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(key))
                bundle.PutBoolean(key, (bool)dictionary[key]);
        }
    }
}