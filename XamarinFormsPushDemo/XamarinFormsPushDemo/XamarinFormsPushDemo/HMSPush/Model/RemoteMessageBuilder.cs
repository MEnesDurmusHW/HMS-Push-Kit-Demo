using System.Collections.Generic;

namespace XamarinFormsPushDemo.HMSPush.Model
{
    public class RemoteMessageBuilder
    {
        private readonly IDictionary<string, object> builder;
        public IDictionary<string, object> Builder { get => builder; }
        private IDictionary<string, string> data { get => (IDictionary<string, string>)builder[Data]; set => builder[Data] = value; }

        public const string Data = "Data";
        public const string To = "To";
        public const string CollapseKey = "CollapseKey";
        public const string MessageId = "MessageId";
        public const string MessageType = "MessageType";
        public const string ReceiptMode = "ReceiptMode";
        public const string SendMode = "SendMode";
        public const string Ttl = "Ttl";
        public RemoteMessageBuilder(string to)
        {
            builder = new Dictionary<string, object>
            {
                [Data] = new Dictionary<string, string>(),
                [To] = to
            };
        }
        public RemoteMessageBuilder AddData(string key, string value) { data[key] = value; return this; }
        public RemoteMessageBuilder ClearData() { data.Clear(); return this; }
        public RemoteMessageBuilder SetData(IDictionary<string, string> data) { this.data = data; return this; }
        public RemoteMessageBuilder SetCollapseKey(string collapseKey) { builder[CollapseKey] = collapseKey; return this; }
        public RemoteMessageBuilder SetMessageId(string messageId) { builder[MessageId] = messageId; return this; }
        public RemoteMessageBuilder SetMessageType(string messageType) { builder[MessageType] = messageType; return this; }
        public RemoteMessageBuilder SetReceiptMode(int receiptMode) { builder[ReceiptMode] = receiptMode; return this; }
        public RemoteMessageBuilder SetSendMode(int sendMode) { builder[SendMode] = sendMode; return this; }
        public RemoteMessageBuilder SetTtl(int ttl) { builder[Ttl] = ttl; return this; }
    }

}
