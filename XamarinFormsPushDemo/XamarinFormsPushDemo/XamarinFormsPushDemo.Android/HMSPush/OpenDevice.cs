using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsPushDemo.HMSPush;

[assembly: Xamarin.Forms.Dependency(typeof(XamarinFormsPushDemo.Droid.HMSPush.OpenDevice))]
namespace XamarinFormsPushDemo.Droid.HMSPush
{
    public class OpenDevice : IOpenDevice
    {
        public async Task<string> GetOdidAsync()
        {
            return (await Huawei.Hms.Opendevice.OpenDevice.GetInstance(Application.Context).GetOdidAsync()).Id;
        }
    }
}