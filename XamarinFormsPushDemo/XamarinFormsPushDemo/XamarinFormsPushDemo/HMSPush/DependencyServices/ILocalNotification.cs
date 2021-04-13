using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFormsPushDemo.HMSPush.Model;

namespace XamarinFormsPushDemo.HMSPush
{
    public interface ILocalNotification
    {
        Task LocalNotificationNow(LocalNotification notification);
        void LocalNotificationSchedule(LocalNotification notification);
        void CancelAllNotifications();
        void CancelNotifications();
        void CancelScheduledNotifications();
        bool ChannelBlocked(string channelId);
        bool ChannelExists(string channelId);
        void CancelNotificationsWith(CancelNotificationParameters[] idtags);
        void CancelNotificationsWith(int[] ids);
        void CancelNotificationsWith(string tag);
        void DeleteChannel(string channelId);
        List<NotificationChannel> GetChannels();
        List<Dictionary<string, string>> GetNotifications();
        List<Dictionary<string, string>> GetScheduledNotifications();
        void InvokeApp(LocalNotification notification);
    }
}
