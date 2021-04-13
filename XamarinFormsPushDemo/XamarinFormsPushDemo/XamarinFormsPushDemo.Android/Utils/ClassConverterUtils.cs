using Android.OS;
using Android.Util;
using System;
using System.Collections.Generic;
using System.Reflection;
using XamarinFormsPushDemo.HMSPush.Enums;
using XamarinFormsPushDemo.HMSPush.Model;

namespace XamarinFormsPushDemo.Droid.Utils
{
    public static class ClassConverterUtils
    {
        internal static RemoteMessage ToRemoteMessage(this Huawei.Hms.Push.RemoteMessage message)
        {
            RemoteMessage result = new RemoteMessage();

            PropertyInfo[] properties = typeof(RemoteMessage).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                PropertyInfo messageProperty = message.GetType().GetProperty(property.Name);
                if (messageProperty != null)
                {
                    if (property.PropertyType == messageProperty.PropertyType)
                    {
                        property.SetValue(result, messageProperty.GetValue(message, null));
                    }
                    else
                        Log.Error("ToRemoteMessage", $"{property.PropertyType} is not equal to {messageProperty.PropertyType}");
                }
                else
                    Log.Error("ToRemoteMessage", $"{property.Name} is null");
            }
            result.Notification = message.GetNotification().ToNotification();

            return result;
        }
        internal static Notification ToNotification(this Huawei.Hms.Push.RemoteMessage.Notification notification)
        {
            Notification result = new Notification();

            PropertyInfo[] properties = typeof(Notification).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                PropertyInfo notificationProperty = notification.GetType().GetProperty(property.Name);
                if (notificationProperty != null)
                {
                    if (property.PropertyType == notificationProperty.PropertyType)
                    {
                        property.SetValue(result, notificationProperty.GetValue(notification, null));
                    }
                    else if (notificationProperty.PropertyType == typeof(Java.Lang.Integer) && property.PropertyType == typeof(int?))//Java.Lang.Integer to int?
                    {
                        object valueToSet = notificationProperty.GetValue(notification, null);
                        Java.Lang.Integer javaInt = valueToSet as Java.Lang.Integer;
                        if (javaInt != null)
                            property.SetValue(result, javaInt.IntValue());
                        else
                            Log.Error("ToNotification", $"({property.PropertyType.FullName}){property.Name} is null");
                    }
                    else if (notificationProperty.PropertyType == typeof(Java.Lang.Long) && property.PropertyType == typeof(long?))//Java.Lang.Long to long?
                    {
                        object valueToSet = notificationProperty.GetValue(notification, null);
                        Java.Lang.Long javaLong = valueToSet as Java.Lang.Long;
                        if (javaLong != null)
                            property.SetValue(result, javaLong.IntValue());
                        else
                            Log.Error("ToNotification", $"({property.PropertyType.FullName}){property.Name} is null");
                    }
                    else if (notificationProperty.PropertyType == typeof(Android.Net.Uri) && property.PropertyType == typeof(System.Uri))//Android.Net to System.Uri
                    {
                        object valueToSet = notificationProperty.GetValue(notification, null);
                        Android.Net.Uri androidUri = valueToSet as Android.Net.Uri;
                        if (androidUri != null)
                            property.SetValue(result, new System.Uri(androidUri.ToString()));
                        else
                            Log.Error("ToNotification", $"({property.PropertyType.FullName}){property.Name} is null");
                    }
                    else
                        Log.Error("ToNotification", $"[{property.Name}]{property.PropertyType} is not equal to {notificationProperty.PropertyType}");
                }
                else
                    Log.Error("ToNotification", $"{property.Name} is null");
            }

            return result;
        }
        internal static IDictionary<string, string> ToDictionary(this Bundle bundle)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            if (bundle != null)
            {
                var keySet = bundle.KeySet();
                if (keySet != null)
                    foreach (var item in keySet)
                    {
                        if (item == "_push_notifyid")
                            result.Add(item, ((Java.Lang.Number)bundle.Get("_push_notifyid")).IntValue().ToString());
                        else
                            result.Add(item, bundle.GetString(item));
                    }
            }

            return result;
        }
        internal static List<NotificationChannel> ToNotificationChannels(this List<Android.App.NotificationChannel> channels)
        {
            List<NotificationChannel> result = new List<NotificationChannel>();

            foreach (var channel in channels)
            {
                NotificationChannel newChannel = new NotificationChannel();
                newChannel.LockscreenVisibility = channel.LockscreenVisibility.EnumToEnum<NotificationVisibility>();
                newChannel.LightColor = channel.LightColor;
                newChannel.Importance = channel.Importance.EnumToEnum<NotificationImportance>();
                newChannel.Id = channel.Id;
                newChannel.Group = channel.Group;
                newChannel.Description = channel.Description;
                if (channel.Sound != null)
                    newChannel.Sound = new Uri(channel.Sound.ToString());
                newChannel.Name = channel.Name;
                newChannel.NameFormatted = channel.NameFormatted.ToString();

                if (channel.AudioAttributes != null)
                {
                    AudioAttributes newAudioAttributes = new AudioAttributes();
                    newAudioAttributes.ContentType = channel.AudioAttributes.ContentType.EnumToEnum<AudioContentType>();
                    newAudioAttributes.Flags = channel.AudioAttributes.Flags.EnumToEnum<AudioFlags>();
                    newAudioAttributes.Usage = channel.AudioAttributes.Usage.EnumToEnum<AudioUsageKind>();
                    newAudioAttributes.VolumeControlStream = channel.AudioAttributes.VolumeControlStream.EnumToEnum<Stream>();
                    newChannel.AudioAttributes = newAudioAttributes;
                }

                result.Add(newChannel);
            }

            return result;
        }
        private static T EnumToEnum<T>(this object value) => (T)value;
    }
}