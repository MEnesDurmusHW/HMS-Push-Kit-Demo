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
using NativeRemoteMessage = Huawei.Hms.Push.RemoteMessage;
using RMBuilder = XamarinFormsPushDemo.HMSPush.Model.RemoteMessageBuilder;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinFormsPushDemo.Droid.HMSPush.HMSMessaging))]
namespace XamarinFormsPushDemo.Droid.HMSPush
{
    public class HMSMessaging : IHMSMessaging
    {
        public bool AutoInitEnabled
        {
            get => HmsMessaging.GetInstance(Application.Context).AutoInitEnabled;
            set => HmsMessaging.GetInstance(Application.Context).AutoInitEnabled = value;
        }

        public void Send(RMBuilder remoteMessageBuilder)
        {
            var rmBuilder = remoteMessageBuilder.Builder;
            NativeRemoteMessage.Builder builder = new NativeRemoteMessage.Builder(rmBuilder[RMBuilder.To].ToString())
                .SetCollapseKey(rmBuilder[RMBuilder.CollapseKey] as string)
                .SetMessageId(rmBuilder[RMBuilder.MessageId] as string)
                .SetMessageType(rmBuilder[RMBuilder.MessageType] as string)
                .SetTtl((int)rmBuilder[RMBuilder.Ttl])
                .SetData((IDictionary<string,string>)rmBuilder[RMBuilder.Data])
                .SetSendMode((int)rmBuilder[RMBuilder.SendMode])
                .SetReceiptMode((int)rmBuilder[RMBuilder.ReceiptMode]);

            NativeRemoteMessage message = builder.Build();

            //Get Token before send RemoteMessage
            HmsMessaging.GetInstance(Application.Context).Send(message);

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