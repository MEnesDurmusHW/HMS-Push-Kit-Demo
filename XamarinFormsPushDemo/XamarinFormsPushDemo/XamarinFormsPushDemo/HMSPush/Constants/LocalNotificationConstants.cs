using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsPushDemo.HMSPush.Constants
{
    public static class LocalNotificationConstants
    {
        public static class Priority
        {
            public const string Max = "max";
            public const string High = "high";
            public const string Default = "default";
            public const string Low = "low";
            public const string Min = "min";
        }
        public static class Visibility
        {
            public const string Public = "public";
            public const string Secret = "secret";
            public const string Private = "private";
        }
        public static class Importance
        {
            public const string Max = "max";
            public const string High = "high";
            public const string Default = "default";
            public const string Low = "low";
            public const string Min = "min";
            public const string None = "none";
            public const string Unspecified = "unspecified";
        }
        public static class Repeat
        {
            public static class Type
            {
                public const string Second = "second";
                public const string Minute = "minute";
                public const string Hour = "hour";
                public const string Day = "day";
                public const string Week = "week";
                public const string CustomTime = "custom_time";
            }
            public static class Time
            {
                public const int OneSecond = 1000;
                public const int OneMinute = 60000;
                public const int OneHour = 3600000;
                public const int OneDay = 86400000;
                public const int OneWeek = 604800000;
            }
        }
    }
}
