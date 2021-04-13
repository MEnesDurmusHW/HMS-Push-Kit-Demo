using System.Collections.Generic;
using System.Text;

namespace XamarinFormsPushDemo.HMSPush.Model
{
    public class RemoteMessage
    {
        public Notification Notification { get; set; }
        public IDictionary<string, string> DataOfMap { get; set; }
        public string From { get; set; }
        public string MessageId { get; set; }
        public int ReceiptMode { get; set; }
        public int OriginalUrgency { get; set; }
        public string Data { get; set; }
        public int SendMode { get; set; }
        public long SentTime { get; set; }
        public string To { get; set; }
        public string Token { get; set; }
        public int Ttl { get; set; }
        public int Urgency { get; set; }
        public string MessageType { get; set; }
        public string CollapseKey { get; set; }
    }
}
