using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsPushDemo.HMSPush.Model
{
    public delegate void OnNewTokenHandler(string token);
    public delegate void OnTokenErrorHandler(Exception exception);
    public delegate void OnMessageReceivedHandler(RemoteMessage message);
    public delegate void OnMessageSentHandler(string msgId);
    public delegate void OnSendErrorHandler(MessageSendEventArgs e);
    public delegate void OnMessageDeliveredHandler(MessageSendEventArgs e);
    public delegate void InitialNotificationHandler(IDictionary<string, string> notification);
}
