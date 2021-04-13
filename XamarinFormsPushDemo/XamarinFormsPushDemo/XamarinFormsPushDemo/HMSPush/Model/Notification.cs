using System;

namespace XamarinFormsPushDemo.HMSPush.Model
{
    public class Notification
    {
        public int? BadgeNumber { get; set; }
        public string Body { get; set; }
        public string BodyLocalizationKey { get; set; }
        public string ChannelId { get; set; }
        public string ClickAction { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public Uri ImageUrl { get; set; }
        public int? Importance { get; set; }
        public string IntentUri { get; set; }
        public bool IsAutoCancel { get; set; }
        public bool IsDefaultLight { get; set; }
        public bool IsDefaultSound { get; set; }
        public bool IsDefaultVibrate { get; set; }
        public bool IsLocalOnly { get; set; }
        public Uri Link { get; set; }
        public int NotifyId { get; set; }
        public string Sound { get; set; }
        public string Tag { get; set; }
        public string Ticker { get; set; }
        public string Title { get; set; }
        public string TitleLocalizationKey { get; set; }
        public int? Visibility { get; set; }
        public long? When { get; set; }
        public string[] BodyLocalizationArgs { get; set; }
        public int[] LightSettings { get; set; }
        public string[] TitleLocalizationArgs { get; set; }
        public long[] VibrateConfig { get; set; }
    }
}
