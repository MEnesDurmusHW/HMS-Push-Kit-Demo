using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinFormsPushDemo.HMSPush;
using XamarinFormsPushDemo.HMSPush.Model;
using XamarinFormsPushDemo.Utils;

namespace XamarinFormsPushDemo
{
    public partial class MainPage : ContentPage
    {
        IHMSInstanceId hmsInstanceId;
        IHMSMessaging hmsMessaging;
        IOpenDevice openDevice;
        IHMSPushEvent hmsPushEvent;
        public MainPage()
        {
            InitializeComponent();

            hmsMessaging = DependencyService.Get<IHMSMessaging>();

            openDevice = DependencyService.Get<IOpenDevice>();

            hmsPushEvent = DependencyService.Get<IHMSPushEvent>();
            hmsPushEvent.Initialize();
            hmsPushEvent.OnMessageReceived += OnMessageReceived;
            hmsPushEvent.OnInitialNotification += OnOpenedAppNotification;
            hmsPushEvent.OnMessageSent += OnMessageSent;

            hmsInstanceId = DependencyService.Get<IHMSInstanceId>();
            hmsInstanceId.Initialize();
            hmsInstanceId.OnNewToken += HMSInstanceIdOnNewToken;
            hmsInstanceId.OnTokenError += HMSInstanceIdOnTokenError;
        }

        private void OnMessageSent(string msgId)
        {
            AddLog("OnMessageSent", $"Message Id is {msgId}");
        }

        private void OnOpenedAppNotification(IDictionary<string, string> notification)
        {
            AddLog("OnOpenedAppNotification", notification.DictionaryToString());
        }

        private void OnMessageReceived(RemoteMessage message)
        {
            if (message != null)
                AddLog("OnMessageReceived", message.Data);
        }

        private void HMSInstanceIdOnTokenError(Exception exception)
        {
            AddLog("OnTokenError", exception.Message);
        }

        private void HMSInstanceIdOnNewToken(string token)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                AddLog("Token", token);
            });
        }

        private void OnClickedEnableAutoInit(object sender, EventArgs e)
        {
            hmsMessaging.AutoInitEnabled = true;
        }
        private void OnClickedDisableAutoInit(object sender, EventArgs e)
        {
            hmsMessaging.AutoInitEnabled = false;
        }
        private void OnClickTurnOffPush(object sender, EventArgs e)
        {
            hmsMessaging.TurnOffPushAsync();
        }
        private void OnClickTurnOnPush(object sender, EventArgs e)
        {
            hmsMessaging.TurnOnPushAsync();
        }
        private void OnClickGetID(object sender, EventArgs e)
        {
            var id = hmsInstanceId.GetId();
            AddLog("ID", id);
        }
        private async void OnClickGetAAID(object sender, EventArgs e)
        {
            string aaid = await hmsInstanceId.GetAAIDAsync();
            AddLog("AAID", aaid);
        }
        private async void OnClickGetOdid(object sender, EventArgs e)
        {
            string odid = await openDevice.GetOdidAsync();
            AddLog("Odid", odid);
        }
        private void OnClickedGetToken(object sender, EventArgs e)
        {
            hmsInstanceId.GetToken();
        }
        private void OnClickGetCreationTime(object sender, EventArgs e)
        {
            long creationTime = hmsInstanceId.GetCreationTime();
            AddLog("GetCreationTime", creationTime.ToString());
        }
        private void OnClickDeleteAAID(object sender, EventArgs e)
        {
            hmsInstanceId.DeleteAAID();
        }
        private void OnClickDeleteToken(object sender, EventArgs e)
        {
            hmsInstanceId.DeleteToken();
        }
        private void OnClickSubscribe(object sender, EventArgs e)
        {
            hmsMessaging.SubscribeAsync(TxtTopic.Text);
        }
        private void OnClickUnsubscribe(object sender, EventArgs e)
        {
            hmsMessaging.UnsubscribeAsync(TxtTopic.Text);
        }
        private void OnClickDisableAutoInit(object sender, EventArgs e)
        {
            hmsMessaging.AutoInitEnabled = false;
        }
        private void OnClickEnableAutoInit(object sender, EventArgs e)
        {
            hmsMessaging.AutoInitEnabled = true;
        }
        private void OnClickIsAutoInitEnabled(object sender, EventArgs e)
        {
            bool isAutoInitEnabled = hmsMessaging.AutoInitEnabled;
            AddLog("AutoInitEnabled", isAutoInitEnabled.ToString());
        }
        private void OnClickGetInitialNotification(object sender, EventArgs e)
        {
            AddLog("InitialNotification", hmsPushEvent.InitialNotification.DictionaryToString());
        }
        private void OnClickSendRemoteMessage(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string messageId = rnd.Next().ToString();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["key1"] = "test",
                ["message"] = "huawei-test",
            };

            // The input parameter of the RemoteMessage.Builder method is push.hcm.upstream, which cannot be changed.
            RemoteMessageBuilder uplinkMessage = new RemoteMessageBuilder("push.hcm.upstream")
                .SetCollapseKey("-1")
                .SetMessageId(messageId)
                .SetMessageType("hms")
                .SetTtl(120)
                .SetData(data)
                .SetSendMode(1)
                .SetReceiptMode(1);

            //Get Token before send RemoteMessage
            hmsMessaging.Send(uplinkMessage);
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

        private async void OnClickLocalNotification(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocalNotificationPage(),true);
        }
    }
}
