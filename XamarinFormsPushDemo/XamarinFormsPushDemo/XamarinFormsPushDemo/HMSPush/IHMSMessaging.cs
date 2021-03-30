using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsPushDemo.HMSPush.Model;

namespace XamarinFormsPushDemo.HMSPush
{
    public interface IHMSMessaging
    {
        bool AutoInitEnabled { get; set; }
        Task SubscribeAsync(string topic);
        Task UnsubscribeAsync(string topic);
        Task TurnOffPushAsync();
        Task TurnOnPushAsync();
        void Send(RemoteMessage message);
    }
}
