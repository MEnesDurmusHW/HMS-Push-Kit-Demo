using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Huawei.Hms.Core;
using Huawei.Hms.Push;
using Java.Lang;

namespace XamarinHmsPushDemo.HMSPush
{
    [Service]
    [IntentFilter(new[] { "com.huawei.push.action.MESSAGING_EVENT" })]
    public class HMSPushMessageService : HmsMessageService
    {
        static readonly string HMSPushAction = "PushReceiver";
        static Context Context = Application.Context;
        public override void OnNewToken(string token)
        {
            // Obtain a token.
            string MethodName = "HMS"+System.Reflection.MethodBase.GetCurrentMethod().Name;
            Log.Info(MethodName, token);
            Intent intent = new Intent(Context, typeof(HMSPushReceiver));
            intent.PutExtra(HMSPushReceiver.Method, MethodName);
            intent.PutExtra(HMSPushReceiver.Token, token);

            SendBroadcast(intent);
        }
        public override void OnNewToken(string token, Bundle bundle)
        {
            // Obtain a token.
            string MethodName = "HMS" + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Log.Info(MethodName, token);
            Intent intent = new Intent(Context, typeof(HMSPushReceiver));
            intent.PutExtra(HMSPushReceiver.Method, MethodName);
            intent.PutExtra(HMSPushReceiver.Token, token);

            SendBroadcast(intent);
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            //It get triggered when data message comes or a notification comes which as foreground attributes false
            string MethodName = "HMS" + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Log.Info(MethodName, RemoteMessageUtils.FromMap(message).DictionaryToString());
            Intent intent = new Intent();
            intent.SetAction(HMSPushAction);
            intent.PutExtra(HMSPushReceiver.Method, MethodName);
            intent.PutExtra(HMSPushReceiver.Message, message);

            SendBroadcast(intent);
        }

        public override void OnMessageSent(string msgId)
        {
            // Obtain the message ID.
            string MethodName = "HMS" + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Log.Info(MethodName, msgId);
            Intent intent = new Intent();
            intent.SetAction(HMSPushAction);
            intent.PutExtra(HMSPushReceiver.Method, MethodName);
            intent.PutExtra(HMSPushReceiver.MsgId, msgId);

            SendBroadcast(intent);
        }

        public override void OnSendError(string msgId, Exception exception)
        {
            // If the sending fails, obtain the error message.
            string MethodName = "HMS" + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Log.Info(MethodName, $"msgId:{msgId}\nError/Exception:{exception.Message}");
            Intent intent = new Intent();
            intent.SetAction(HMSPushAction);
            intent.PutExtra(HMSPushReceiver.Method, MethodName);
            intent.PutExtra(HMSPushReceiver.MsgId, msgId);
            Android.OS.Bundle bundle = new Android.OS.Bundle();
            bundle.PutString(HMSPushReceiver.Message, exception.Message);
            bundle.PutInt(HMSPushReceiver.ErrorCode, ((BaseException)exception).ErrorCode);
            intent.PutExtra(HMSPushReceiver.Exception, bundle);
            SendBroadcast(intent);
        }

        public override void OnMessageDelivered(string msgId, Exception exception)
        {
            // Obtain the error code and description.
            string MethodName = "HMS" + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Log.Info(MethodName, $"msgId:{msgId}\nSituation:{exception.Message}");
            Intent intent = new Intent();
            intent.SetAction(HMSPushAction);
            intent.PutExtra(HMSPushReceiver.Method, MethodName);
            intent.PutExtra(HMSPushReceiver.MsgId, msgId);
            Android.OS.Bundle bundle = new Android.OS.Bundle();
            bundle.PutString(HMSPushReceiver.Message, exception.Message);
            bundle.PutInt(HMSPushReceiver.ErrorCode, ((BaseException)exception).ErrorCode);
            intent.PutExtra(HMSPushReceiver.Exception, bundle);
            SendBroadcast(intent);
        }

        public override void OnTokenError(Exception exception)
        {
            string MethodName = "HMS" + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Log.Info(MethodName, exception.Message);
            Intent intent = new Intent();
            intent.SetAction(HMSPushAction);
            intent.PutExtra(HMSPushReceiver.Method, MethodName);
            Android.OS.Bundle bundleException = new Android.OS.Bundle();
            bundleException.PutString(HMSPushReceiver.Message, exception.Message);
            bundleException.PutInt(HMSPushReceiver.ErrorCode, ((BaseException)exception).ErrorCode);
            intent.PutExtra(HMSPushReceiver.Exception, bundleException);
            SendBroadcast(intent);
        }
        public override void OnTokenError(Exception exception, Bundle bundle)
        {
            string MethodName = "HMS" + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Log.Info(MethodName, exception.Message);
            Intent intent = new Intent();
            intent.SetAction(HMSPushAction);
            intent.PutExtra(HMSPushReceiver.Method, MethodName);
            Android.OS.Bundle bundleException = new Android.OS.Bundle();
            bundleException.PutString(HMSPushReceiver.Message, exception.Message);
            bundleException.PutInt(HMSPushReceiver.ErrorCode, ((BaseException)exception).ErrorCode);
            intent.PutExtra(HMSPushReceiver.Exception, bundleException);
            intent.PutExtra(HMSPushReceiver.Bundle, bundle);
            SendBroadcast(intent);
        }

        public override void OnDeletedMessages()
        {
            string MethodName = "HMS" + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Log.Info(MethodName, $"{MethodName} has triggered.");
            Intent intent = new Intent();
            intent.SetAction(HMSPushAction);
            intent.PutExtra(HMSPushReceiver.Method, MethodName);
            SendBroadcast(intent);
        }

    }

}