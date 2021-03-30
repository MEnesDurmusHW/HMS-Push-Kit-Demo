using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsPushDemo.HMSPush.Model
{
    public class UplinkMessage
    {
        public IDictionary<string, object> I;
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
            public UplinkMessage Build()
            {
                builder[Data] = data;

                return new UplinkMessage { I = builder };
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

}
