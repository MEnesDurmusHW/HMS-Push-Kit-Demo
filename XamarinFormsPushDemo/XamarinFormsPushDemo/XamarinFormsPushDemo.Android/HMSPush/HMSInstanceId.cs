using Android.App;
using Android.OS;
using Huawei.Hms.Aaid;
using Huawei.Hms.Aaid.Entity;
using Huawei.Hms.Push;
using System;
using System.Threading;
using System.Threading.Tasks;
using XamarinFormsPushDemo.HMSPush;
using XamarinFormsPushDemo.HMSPush.Model;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinFormsPushDemo.Droid.HMSPush.HMSInstanceId))]
namespace XamarinFormsPushDemo.Droid.HMSPush
{
    public class HMSInstanceId : IHMSInstanceId, IHMSTokenEvent
    {
        internal static HMSInstanceId Instance { get; private set; }

        private HmsInstanceId Client { get; set; }

        public event OnNewTokenHandler OnNewToken;

        public event OnTokenErrorHandler OnTokenError;

        public long GetCreationTime() => Client.CreationTime;

        public string GetId() => Client.Id;

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
                    OnNewToken?.Invoke(token);
                }
                catch (Exception e)
                {
                    OnTokenError?.Invoke(e);
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

        #region IHMSTokenEvent
        public void HMSOnNewToken(string token, Bundle bundle)
        {
            OnNewToken?.Invoke(token);
        }
        public void HMSOnTokenError(int errorCode, string errorMessage, Bundle bundle)
        {
            OnTokenError?.Invoke(new Exception(errorMessage));
        }
        #endregion
    }
}