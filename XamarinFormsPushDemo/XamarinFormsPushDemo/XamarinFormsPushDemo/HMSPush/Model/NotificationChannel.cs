using System;
using System.Collections.Generic;
using System.Text;
using XamarinFormsPushDemo.HMSPush.Enums;

namespace XamarinFormsPushDemo.HMSPush.Model
{
    public class NotificationChannel
    {
        public NotificationVisibility LockscreenVisibility { get; set; }
        public int LightColor { get; set; }
        public NotificationImportance Importance { get; set; }
        public string Id { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public AudioAttributes AudioAttributes { get; set; }
        public Uri Sound { get; set; }
        public string NameFormatted { get; set; }
        public string Name { get; set; }
    }
}
