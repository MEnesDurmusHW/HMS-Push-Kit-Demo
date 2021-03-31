using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Huawei.Hms.Push;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsPushDemo.HMSPush;
using XamarinFormsPushDemo.HMSPush.Model;

namespace XamarinFormsPushDemo.Droid.HMSPush
{
    public class HMSMessaging : IHMSMessaging
    {
        public bool AutoInitEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Send(XamarinFormsPushDemo.HMSPush.Model.RemoteMessage message)
        {
            
        }

        public Task SubscribeAsync(string topic)
        {
            return HmsMessaging.GetInstance(Application.Context).SubscribeAsync(topic);
        }

        public Task TurnOffPushAsync()
        {
            return HmsMessaging.GetInstance(Application.Context).TurnOffPushAsync();
        }

        public Task TurnOnPushAsync()
        {
            return HmsMessaging.GetInstance(Application.Context).TurnOnPushAsync();
        }

        public Task UnsubscribeAsync(string topic)
        {
            return HmsMessaging.GetInstance(Application.Context).UnsubscribeAsync(topic);
        }

    }
}