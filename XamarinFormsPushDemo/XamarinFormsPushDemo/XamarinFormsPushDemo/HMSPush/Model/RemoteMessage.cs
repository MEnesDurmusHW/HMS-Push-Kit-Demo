using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsPushDemo.HMSPush.Model
{
    public class RemoteMessage
    {
        private Notification notification;
        public Notification GetNotification() => notification;
        public IDictionary<string, string> DataOfMap { get; private set; }
        public string From { get; private set; }
        public string MessageId { get; private set; }
        public int ReceiptMode { get; private set; }
        public int OriginalUrgency { get; private set; }
        public string Data { get; private set; }
        public int SendMode { get; private set; }
        public long SentTime { get; private set; }
        public string To { get; private set; }
        public string Token { get; private set; }
        public int Ttl { get; private set; }
        public int Urgency { get; private set; }
        public string MessageType { get; private set; }
        public string CollapseKey { get; private set; }

        public class Notification
        {
            public int? BadgeNumber { get; }
            public string Body { get; }
            public string BodyLocalizationKey { get; }
            public string ChannelId { get; }
            public string ClickAction { get; }
            public string Color { get; }
            public string Icon { get; }
            public Uri ImageUrl { get; }
            public int? Importance { get; }
            public string IntentUri { get; }
            public bool IsAutoCancel { get; }
            public bool IsDefaultLight { get; }
            public bool IsDefaultSound { get; }
            public bool IsDefaultVibrate { get; }
            public bool IsLocalOnly { get; }
            public Uri Link { get; }
            public int NotifyId { get; }
            public string Sound { get; }
            public string Tag { get; }
            public string Ticker { get; }
            public string Title { get; }
            public string TitleLocalizationKey { get; }
            public int? Visibility { get; }
            public long When { get; }
            public string[] BodyLocalizationArgs { get; }
            public int[] LightSettings { get; }
            public string[] TitleLocalizationArgs { get; }
            public long[] VibrateConfig { get; }
        }
    }
}
