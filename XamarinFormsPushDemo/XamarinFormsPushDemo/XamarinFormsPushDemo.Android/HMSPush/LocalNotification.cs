using Android.App;
using Android.OS;
using Huawei.Hms.Push;
using Huawei.Hms.Push.LocalNotification;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFormsPushDemo.Droid.Utils;
using XamarinFormsPushDemo.HMSPush;
using XamarinFormsPushDemo.HMSPush.Constants;
using static Huawei.Hms.Push.LocalNotification.LocalNotificationConstants;
using NotifyConstants = XamarinFormsPushDemo.HMSPush.Constants.LocalNotificationAttribute;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinFormsPushDemo.Droid.HMSPush.LocalNotification))]
namespace XamarinFormsPushDemo.Droid.HMSPush
{
    public class LocalNotification : ILocalNotification
    {
        public void CancelAllNotifications()
        {
            NotificationController.CancelAllNotifications(Application.Context);
        }

        public void CancelNotifications()
        {
            NotificationController.CancelNotifications(Application.Context);
        }

        public void CancelNotificationsWith(XamarinFormsPushDemo.HMSPush.Model.CancelNotificationParameters[] idtags)
        {
            List<CancelNotificationParameters> list = new List<CancelNotificationParameters>();
            foreach (var idtag in idtags)
            {
                list.Add(new CancelNotificationParameters { Id = idtag.Id, Tag = idtag.Tag });
            }
            NotificationController.CancelNotificationsWith(Application.Context, list.ToArray());
        }

        public void CancelNotificationsWith(int[] ids)
        {
            NotificationController.CancelNotificationsWith(Application.Context, ids);
        }

        public void CancelNotificationsWith(string tag)
        {
            NotificationController.CancelNotificationsWith(Application.Context, tag);
        }

        public void CancelScheduledNotifications()
        {
            NotificationController.CancelScheduledNotifications(Application.Context);
        }

        public bool ChannelBlocked(string channelId)
        {
            return NotificationController.ChannelBlocked(Application.Context, channelId);
        }

        public bool ChannelExists(string channelId)
        {
            return NotificationController.ChannelExists(Application.Context, channelId);
        }

        public void DeleteChannel(string channelId)
        {
            NotificationController.DeleteChannel(Application.Context, channelId);
        }

        public List<XamarinFormsPushDemo.HMSPush.Model.NotificationChannel> GetChannels()
        {
            return NotificationController.GetChannels(Application.Context).ToNotificationChannels();
        }

        public List<Dictionary<string, string>> GetNotifications()
        {
            return NotificationController.GetNotifications(Application.Context);
        }

        public List<Dictionary<string, string>> GetScheduledNotifications()
        {
            return NotificationController.GetScheduledNotifications(Application.Context);
        }

        public void InvokeApp(XamarinFormsPushDemo.HMSPush.Model.LocalNotification notification)
        {
            NotificationController.InvokeApp(Application.Context, NotificationToBundle(notification));
        }

        public async Task LocalNotificationNow(XamarinFormsPushDemo.HMSPush.Model.LocalNotification notification)
        {
            await NotificationController.LocalNotificationNow(Application.Context, NotificationToBundle(notification));
        }

        public void LocalNotificationSchedule(XamarinFormsPushDemo.HMSPush.Model.LocalNotification notification)
        {
            NotificationController.LocalNotificationSchedule(Application.Context, NotificationToBundle(notification));
        }
        private Bundle NotificationToBundle(XamarinFormsPushDemo.HMSPush.Model.LocalNotification notification)
        {
            Bundle bundle = new Bundle();
            bundle.PutString(NotifyConstants.Title, notification.Title);
            bundle.PutString(NotifyConstants.Message, notification.Message);
            bundle.AddString(NotifyConstants.Importance, notification.Attributes);
            bundle.AddString(NotifyConstants.Priority, notification.Attributes);
            bundle.AddString(NotifyConstants.Visibility, notification.Attributes);
            bundle.AddString(NotifyConstants.BigText, notification.Attributes);
            bundle.AddString(NotifyConstants.SubText, notification.Attributes);
            bundle.AddString(NotifyConstants.Tag, notification.Attributes);
            bundle.AddString(NotifyConstants.Ticker, notification.Attributes);
            bundle.AddString(NotifyConstants.ChannelId, notification.Attributes);
            bundle.AddString(NotifyConstants.ChannelName, notification.Attributes);
            bundle.AddString(NotifyConstants.ChannelDescription, notification.Attributes);
            bundle.AddString(NotifyConstants.RepeatInterval, notification.Attributes);
            bundle.AddString(NotifyConstants.SoundName, notification.Attributes);
            bundle.AddString(NotifyConstants.Color, notification.Attributes);
            bundle.AddString(NotifyConstants.Group, notification.Attributes);
            bundle.AddString(NotifyConstants.LargeIconUrl, notification.Attributes);
            bundle.AddString(NotifyConstants.Number, notification.Attributes);
            bundle.AddString(NotifyConstants.BigPictureUrl, notification.Attributes);
            bundle.AddString(NotifyConstants.RepeatType, notification.Attributes);

            bundle.AddStringArray(NotifyConstants.Actions, notification.Attributes);

            bundle.AddInt(NotifyConstants.Id, notification.Attributes);
            bundle.AddInt(NotifyConstants.LargeIcon, notification.Attributes);

            bundle.AddDouble(NotifyConstants.VibrateDuration, notification.Attributes);

            bundle.AddLong(NotifyConstants.RepeatTime, notification.Attributes);
            bundle.AddLong(NotifyConstants.FireDate, notification.Attributes);

            bundle.AddBool(NotifyConstants.Vibrate, notification.Attributes);
            bundle.AddBool(NotifyConstants.Ongoing, notification.Attributes);
            bundle.AddBool(NotifyConstants.PlaySound, notification.Attributes);
            bundle.AddBool(NotifyConstants.AllowWhileIdle, notification.Attributes);
            bundle.AddBool(NotifyConstants.InvokeApp, notification.Attributes);
            bundle.AddBool(NotifyConstants.DontNotifyInForeground, notification.Attributes);
            bundle.AddBool(NotifyConstants.AutoCancel, notification.Attributes);
            bundle.AddBool(NotifyConstants.GroupSummary, notification.Attributes);
            bundle.AddBool(NotifyConstants.OnlyAlertOnce, notification.Attributes);
            bundle.AddBool(NotifyConstants.ShowWhen, notification.Attributes);

            bundle.PutInt(NotifyConstants.SmallIcon, Resource.Mipmap.HWIcon);

            return bundle;
        }
    }
}