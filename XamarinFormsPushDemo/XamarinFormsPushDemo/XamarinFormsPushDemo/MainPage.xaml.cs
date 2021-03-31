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

namespace XamarinFormsPushDemo
{
    public partial class MainPage : ContentPage
    {
        readonly string Tag = "MainPage";
        IHMSInstanceId hmsInstanceId;
        IHMSMessaging hmsMessaging;
        public MainPage()
        {
            InitializeComponent();
            hmsMessaging = DependencyService.Get<IHMSMessaging>();
            hmsInstanceId = DependencyService.Get<IHMSInstanceId>();
            hmsInstanceId.Initialize();
            hmsInstanceId.OnNewToken += HMSInstanceIdOnNewToken;
            hmsInstanceId.OnTokenError += HMSInstanceIdOnTokenError;
        }

        private void HMSInstanceIdOnTokenError(object sender, Exception exception)
        {
            Log.Warning(Tag, exception.Message);
        }

        private void HMSInstanceIdOnNewToken(object sender, string token)
        {
            Log.Warning(Tag, token);
            Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert("Title", token, "Ok");
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
            var id= hmsInstanceId.Id;
        }
        private void OnClickGetAAID(object sender, EventArgs e)
        {

        }
        private void OnClickGetOdid(object sender, EventArgs e)
        {

        }
        private void OnClickedGetToken(object sender, EventArgs e)
        {
            hmsInstanceId.GetToken();
        }
        private void OnClickGetCreationTime(object sender, EventArgs e)
        {

        }
        private void OnClickDeleteAAID(object sender, EventArgs e)
        {

        }
        private void OnClickDeleteToken(object sender, EventArgs e)
        {

        }
    }
}
