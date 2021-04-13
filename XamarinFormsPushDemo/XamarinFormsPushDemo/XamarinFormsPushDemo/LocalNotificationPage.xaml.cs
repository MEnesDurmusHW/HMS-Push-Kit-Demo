using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using XamarinFormsPushDemo.HMSPush;
using XamarinFormsPushDemo.HMSPush.Constants;
using XamarinFormsPushDemo.HMSPush.Model;
using static XamarinFormsPushDemo.HMSPush.Constants.LocalNotificationConstants;

namespace XamarinFormsPushDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalNotificationPage : ContentPage
    {
        readonly ILocalNotification localNotification;
        readonly string ChannelId = "hms-push-kit";
        public LocalNotificationPage()
        {
            InitializeComponent();

            localNotification = DependencyService.Get<ILocalNotification>();
        }
        private void OnChildAdded(object sender, ElementEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                LogScrollView.ScrollToAsync(LogLayout.Children.Last(), ScrollToPosition.MakeVisible, true);
            });
        }
        private void AddLog(string category, string message)
        {
            Log.Warning(category, message);
            LogLayout.Children.Add(new Label { Text = $"[{category}]: {message}", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand });
        }

        private void AddCommonAttributes(IDictionary<string, object> notificationAttributes)
        {
            notificationAttributes[LocalNotificationAttribute.Importance] = Importance.Max;
            notificationAttributes[LocalNotificationAttribute.Priority] = Priority.Max;
            notificationAttributes[LocalNotificationAttribute.Visibility] = Visibility.Public;
            notificationAttributes[LocalNotificationAttribute.ChannelId] = ChannelId;
        }

        private async void OnClickDefaultNotification(object sender, EventArgs e)
        {
            string Tag = "Default";
            try
            {
                LocalNotification notification = new LocalNotification { Title = TxtTitle.Text, Message = TxtMessage.Text };
                AddCommonAttributes(notification.Attributes);
                await localNotification.LocalNotificationNow(notification);

                AddLog(Tag, "LocalNotification Succeeded.");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }

        private async void OnClickOnGoing(object sender, EventArgs e)
        {
            string Tag = "+OnGoing";
            try
            {
                LocalNotification notification = new LocalNotification { Title = TxtTitle.Text, Message = TxtMessage.Text };
                AddCommonAttributes(notification.Attributes);

                notification.Attributes[LocalNotificationAttribute.Ongoing] = true;
                await localNotification.LocalNotificationNow(notification);

                AddLog(Tag, "LocalNotification Succeeded.");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private async void OnClickSound(object sender, EventArgs e)
        {
            string Tag = "+Sound";
            try
            {
                LocalNotification notification = new LocalNotification { Title = TxtTitle.Text, Message = TxtMessage.Text };
                AddCommonAttributes(notification.Attributes);

                notification.Attributes[LocalNotificationAttribute.PlaySound] = true;
                notification.Attributes[LocalNotificationAttribute.SoundName] = "huawei.mp3";
                await localNotification.LocalNotificationNow(notification);

                AddLog(Tag, "LocalNotification Succeeded.");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private async void OnClickVibrate(object sender, EventArgs e)
        {
            string Tag = "+Vibrate";
            try
            {
                LocalNotification notification = new LocalNotification { Title = TxtTitle.Text, Message = TxtMessage.Text };
                AddCommonAttributes(notification.Attributes);

                notification.Attributes[LocalNotificationAttribute.Vibrate] = true;
                await localNotification.LocalNotificationNow(notification);

                AddLog(Tag, "LocalNotification Succeeded.");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private async void OnClickBigImage(object sender, EventArgs e)
        {
            string Tag = "+BigImage";
            try
            {
                LocalNotification notification = new LocalNotification { Title = TxtTitle.Text, Message = TxtMessage.Text };
                AddCommonAttributes(notification.Attributes);

                notification.Attributes[LocalNotificationAttribute.BigPictureUrl] = "https://www-file.huawei.com/-/media/corp/home/image/logo_400x200.png";
                await localNotification.LocalNotificationNow(notification);

                AddLog(Tag, "LocalNotification Succeeded.");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private async void OnClickRepeate(object sender, EventArgs e)
        {
            string Tag = "+Repeate";
            try
            {
                LocalNotification notification = new LocalNotification { Title = TxtTitle.Text, Message = TxtMessage.Text };
                AddCommonAttributes(notification.Attributes);

                notification.Attributes[LocalNotificationAttribute.RepeatType] = Repeat.Type.CustomTime;//Time when a scheduled notification message is pushed repeatedly.
                notification.Attributes[LocalNotificationAttribute.RepeatTime] = 5 * Repeat.Time.OneSecond;//Time when the next scheduled notification message is pushed repeatedly, in milliseconds.
                await localNotification.LocalNotificationNow(notification);

                AddLog(Tag, "LocalNotification Succeeded.");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private void OnClickScheduled(object sender, EventArgs e)
        {
            string Tag = "+Scheduled";
            try
            {
                LocalNotification notification = new LocalNotification { Title = TxtTitle.Text, Message = TxtMessage.Text };
                AddCommonAttributes(notification.Attributes);

                notification.Attributes[LocalNotificationAttribute.FireDate] = 10000L;
                localNotification.LocalNotificationSchedule(notification);

                AddLog(Tag, "LocalNotification Succeeded.");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private void OnClickGetChannels(object sender, EventArgs e)
        {
            string Tag = "GetChannels";
            try
            {
                var channels = localNotification.GetChannels();

                AddLog(Tag, $"There are {channels.Count} channel(s).");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private void OnClickChannelExists(object sender, EventArgs e)
        {
            string Tag = "ChannelExists";
            try
            {
                bool isExist = localNotification.ChannelExists(ChannelId + 50);
                if (isExist)
                    AddLog(Tag, "The channel exists!");
                else AddLog(Tag, "The channel does not exist!");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private void OnClickIsChannelBlocked(object sender, EventArgs e)
        {
            string Tag = "IsChannelBlocked";
            try
            {
                bool isChannelBlocked = localNotification.ChannelBlocked(ChannelId + 45);
                if (isChannelBlocked)
                    AddLog(Tag, "The channel is blocked!");
                else AddLog(Tag, "The channel is not blocked!");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private void OnClickDeleteChannel(object sender, EventArgs e)
        {
            string Tag = "DeleteChannel";
            try
            {
                localNotification.DeleteChannel(ChannelId + 49);

                AddLog(Tag, "Success");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private void OnClickCancelNotifications(object sender, EventArgs e)
        {
            string Tag = "CancelNotifications";
            try
            {
                localNotification.CancelNotifications();

                AddLog(Tag, "Success");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private void OnClickCancelNotificationsWith(object sender, EventArgs e)
        {
            string Tag = "CancelNotificationsWith";
            try
            {
                localNotification.CancelNotificationsWith(TxtTag.Text);

                AddLog(Tag, "Success");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private void OnClickGetScheduledNotifications(object sender, EventArgs e)
        {
            string Tag = "ScheduledNotifications";
            try
            {
                List<Dictionary<string, string>> notifications = localNotification.GetScheduledNotifications();

                AddLog(Tag, $"There are {notifications.Count} scheduled notification(s).");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private void OnClickCancelScheduledNotifications(object sender, EventArgs e)
        {
            string Tag = "CancelScheduledNotifications";
            try
            {
                localNotification.CancelScheduledNotifications();

                AddLog(Tag, "Success");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private void OnClickGetNotifications(object sender, EventArgs e)
        {
            string Tag = "Notifications";
            try
            {
                List<Dictionary<string, string>> notifications = localNotification.GetNotifications();

                AddLog(Tag, $"There are {notifications.Count} active notifications.");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
        private void OnClickCancelAllNotifications(object sender, EventArgs e)
        {
            string Tag = "CancelAllNotifications";
            try
            {
                localNotification.CancelAllNotifications();

                AddLog(Tag, "Success");
            }
            catch (Exception exception)
            {
                AddLog(Tag, "Error/Exception: " + exception);
            }
        }
    }
}