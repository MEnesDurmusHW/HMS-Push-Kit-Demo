using System;
using System.IO;
using Huawei.Agconnect.Config;
using Android.Content;
using Android.Util;

namespace HMSSample
{
    public class HmsLazyInputStream : LazyInputStream
    {
        public HmsLazyInputStream(Context context) : base(context)
        {
        }

        public override Stream Get(Context context)
        {
            try
            {
                return context.Assets.Open("agconnect-services.json");
            }
            catch (Exception e)
            {
                Log.Info(e.ToString(), "Can't open agconnect file");
                return null;
            }
        }

    }
}