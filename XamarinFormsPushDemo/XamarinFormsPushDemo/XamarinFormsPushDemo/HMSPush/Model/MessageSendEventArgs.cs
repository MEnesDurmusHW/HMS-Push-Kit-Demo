using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsPushDemo.HMSPush.Model
{
    public class MessageSendEventArgs : EventArgs
    {
        public string MsgId { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
