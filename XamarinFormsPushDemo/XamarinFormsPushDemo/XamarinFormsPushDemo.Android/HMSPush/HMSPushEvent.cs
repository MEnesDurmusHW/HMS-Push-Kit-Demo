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
using XamarinFormsPushDemo.Droid.Utils;
using XamarinFormsPushDemo.HMSPush.Model;
using static Huawei.Hms.Push.LocalNotification.LocalNotificationConstants;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinFormsPushDemo.Droid.HMSPush.HMSPushEvent))]
namespace XamarinFormsPushDemo.Droid.HMSPush
{
    public class HMSPushEvent : IHMSPushEvent, XamarinFormsPushDemo.HMSPush.IHMSPushEvent
    {
        internal static HMSPushEvent Instance;
        private static IDictionary<string, string> initialNotification;
        public IDictionary<string, string> InitialNotification
        {
            get => initialNotification;
            set => initialNotification = value;
        }

        public event OnMessageReceivedHandler OnMessageReceived;
        public event OnMessageSentHandler OnMessageSent;
        public event OnSendErrorHandler OnSendError;
        public event OnMessageDeliveredHandler OnMessageDelivered;
        public event InitialNotificationHandler OnInitialNotification;

        public void HMSOnMessageDelivered(string msgId, int errorCode, string errorMessage)
        {
            OnMessageDelivered?.Invoke(new MessageSendEventArgs { ErrorCode = errorCode, MsgId = msgId, ErrorMessage = errorMessage });
        }

        public void HMSOnMessageReceived(Huawei.Hms.Push.RemoteMessage message)
        {
            OnMessageReceived?.Invoke(message.ToRemoteMessage());
        }

        public void HMSOnMessageSent(string msgId)
        {
            OnMessageSent?.Invoke(msgId);
        }

        public void HMSOnSendError(string msgId, int errorCode, string errorMessage)
        {
            OnSendError?.Invoke(new MessageSendEventArgs { MsgId = msgId, ErrorMessage = errorMessage, ErrorCode = errorCode });
        }

        public void Initialize()
        {
            Instance = this;
        }
        public void HMSOnInitialNotification(Bundle bundle)
        {
            if (bundle != null)
            {
                var dictionary = ((Bundle)bundle.Get(NotificationConstants.Notification)).ToDictionary();
                OnInitialNotification?.Invoke(dictionary);
                InitialNotification = dictionary;
            }
        }
    }
}