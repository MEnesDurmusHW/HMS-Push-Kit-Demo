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

namespace XamarinFormsPushDemo.Droid.HMSPush
{
    public interface IHMSTokenEvent
    {
        /// <summary>
        /// Called when a token fails to be applied for.
        /// </summary>
        /// <param name="exp"></param>
        void HMSOnTokenError(int errorCode, string errorMessage, Bundle bundle);
        /// <summary>
        ///  Called when a new token is received.
        /// </summary>
        /// <param name="token"></param>
        void HMSOnNewToken(string token, Bundle bundle);
    }
}