using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Huawei.Hms.Aaid;
using Huawei.Hms.Aaid.Entity;
using Huawei.Hms.Push;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinFormsPushDemo.HMSPush;
using XamarinFormsPushDemo.HMSPush.Model;
using XamarinHmsPushDemo.HMSPush;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinFormsPushDemo.Droid.HMSPush.HMSInstanceId))]
namespace XamarinFormsPushDemo.Droid.HMSPush
{
    public class HMSInstanceId : IHMSInstanceId, IHMSPushEvent
    {
        internal static HMSInstanceId Instance { get; private set; }

        internal HmsInstanceId Client { get; set; }

        public event EventHandler<string> OnNewToken;

        public event EventHandler<Exception> OnTokenError;

        public bool AutoInitEnabled
        {
            get => HmsMessaging.GetInstance(Application.Context).AutoInitEnabled;
            set => HmsMessaging.GetInstance(Application.Context).AutoInitEnabled = value;
        }

        public long CreationTime { get => Client.CreationTime; }

        public string Id { get => Client.Id;  }

        public void Initialize()
        {
            Instance = this;
            Client = HmsInstanceId.GetInstance(Application.Context);
        }

        public void GetToken()
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    string token = Client.GetToken("102851541", HmsMessaging.DefaultTokenScope);
                    OnNewToken?.Invoke(null, token);
                }
                catch (Exception e)
                {
                    OnTokenError?.Invoke(null, e);
                }
            });
            thread.Start();
        }

        public async Task<string> GetAAIDAsync()
        {
            AAIDResult Result = await Client.GetAAIDAsync();
            return Result.Id;
        }

        public void DeleteAAID()
        {
            Thread thread = new Thread(() =>
            {
                Client.DeleteAAID();
            });
            thread.Start();
        }

        public void DeleteToken()
        {
            Thread thread = new Thread(() =>
            {
                Client.DeleteToken("102851541", HmsMessaging.DefaultTokenScope);
            });
            thread.Start();
        }

        #region IHMSPushEvent
        public void HMSOnNewToken(string token, Bundle bundle)
        {
            OnNewToken?.Invoke(null, token);
        }

        public void HMSOnMessageReceived(Huawei.Hms.Push.RemoteMessage message)
        {
            throw new NotImplementedException();
        }

        public void HMSOnMessageSent(string msgId)
        {
            throw new NotImplementedException();
        }

        public void HMSOnSendError(string msgId, int errorCode, string errorMessage)
        {
            throw new NotImplementedException();
        }

        public void HMSOnMessageDelivered(string msgId, int errorCode, string errorMessage)
        {
            throw new NotImplementedException();
        }

        public void HMSOnTokenError(int errorCode, string errorMessage, Bundle bundle)
        {
            OnTokenError?.Invoke(null, new Exception(errorMessage));
        }
        #endregion
    }
}