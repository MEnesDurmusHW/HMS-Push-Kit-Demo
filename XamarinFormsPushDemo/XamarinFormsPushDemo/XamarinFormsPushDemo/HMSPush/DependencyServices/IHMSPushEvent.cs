using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsPushDemo.HMSPush.Model;

namespace XamarinFormsPushDemo.HMSPush
{
    public interface IHMSPushEvent
    {
        event OnMessageReceivedHandler OnMessageReceived;
        event OnMessageSentHandler OnMessageSent;
        event OnSendErrorHandler OnSendError;
        event OnMessageDeliveredHandler OnMessageDelivered;
        event InitialNotificationHandler OnInitialNotification;
        void Initialize();
        IDictionary<string, string> InitialNotification { get; set; }
    }
}
