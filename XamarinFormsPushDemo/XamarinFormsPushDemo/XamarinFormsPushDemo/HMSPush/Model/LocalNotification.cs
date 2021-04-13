using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsPushDemo.HMSPush.Model
{
    public class LocalNotification
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
        public LocalNotification()
        {
            Attributes = new Dictionary<string, object>();
        }
    }
}
