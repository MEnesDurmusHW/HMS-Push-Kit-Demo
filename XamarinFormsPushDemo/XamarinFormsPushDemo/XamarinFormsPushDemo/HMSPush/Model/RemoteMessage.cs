using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsPushDemo.HMSPush.Model
{
    public class RemoteMessage
    {
        private Notification notification;
        public Notification Notification { get => notification; private set => notification = value; }
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
        public IDictionary<string, object> I { get; set; }
        public class Builder
        {
            private readonly IDictionary<string, object> builder;
            private IDictionary<string, string> data;

            private readonly string Data = "Data";
            private readonly string To = "To";
            private readonly string CollapseKey = "CollapseKey";
            private readonly string MessageId = "MessageId";
            private readonly string MessageType = "MessageType";
            private readonly string ReceiptMode = "ReceiptMode";
            private readonly string SendMode = "SendMode";
            private readonly string Ttl = "Ttl";
            public Builder(string to)
            {
                builder = new Dictionary<string, object>();
                data = new Dictionary<string, string>();
                builder[To] = to;
            }
            public Builder AddData(string key, string value) { data[key] = value; return this; }
            public RemoteMessage Build()
            {
                builder[Data] = data;

                return new RemoteMessage { I = builder };
            }

            public Builder ClearData() { data.Clear(); return this; }
            public Builder SetCollapseKey(string collapseKey) { builder[CollapseKey] = collapseKey; return this; }
            public Builder SetData(IDictionary<string, string> data) { this.data = data; return this; }
            public Builder SetMessageId(string messageId) { builder[MessageId] = messageId; return this; }
            public Builder SetMessageType(string messageType) { builder[MessageType] = messageType; return this; }
            public Builder SetReceiptMode(int receiptMode) { builder[ReceiptMode] = receiptMode; return this; }
            public Builder SetSendMode(int sendMode) { builder[SendMode] = sendMode; return this; }
            public Builder SetTtl(int ttl) { builder[Ttl] = ttl; return this; }
        }
    }
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
