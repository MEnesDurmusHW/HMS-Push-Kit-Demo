using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Huawei.Hms.Core;
using Huawei.Hms.Push;
using Java.Lang;

namespace XamarinFormsPushDemo.Droid.HMSPush
{
    [Service]
    [IntentFilter(new[] { "com.huawei.push.action.MESSAGING_EVENT" })]
    public class HMSPushMessageService : HmsMessageService
    {
        public override void OnNewToken(string token)
        {
            // Obtain a token.
        }
        public override void OnNewToken(string token, Bundle bundle)
        {
            // Obtain a token.
            IHMSTokenEvent hmsTokenEvent = HMSInstanceId.Instance;
            hmsTokenEvent.HMSOnNewToken(token, bundle);
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            //It get triggered when data message comes or a notification comes which as foreground attributes false
            IHMSPushEvent hmsPushEvent = HMSPushEvent.Instance;
            hmsPushEvent.HMSOnMessageReceived(message);
        }

        public override void OnMessageSent(string msgId)
        {
            // Obtain the message ID.
            IHMSPushEvent hmsPushEvent = HMSPushEvent.Instance;
            hmsPushEvent.HMSOnMessageSent(msgId);
        }

        public override void OnSendError(string msgId, Exception exception)
        {
            // If the sending fails, obtain the error message.
            IHMSPushEvent hmsPushEvent = HMSPushEvent.Instance;
            hmsPushEvent.HMSOnSendError(msgId, ((BaseException)exception).ErrorCode, ((BaseException)exception).Message);
        }

        public override void OnMessageDelivered(string msgId, Exception exception)
        {
            // Obtain the error code and description.
            IHMSPushEvent hmsPushEvent = HMSPushEvent.Instance;
            hmsPushEvent.HMSOnMessageDelivered(msgId, ((BaseException)exception).ErrorCode, ((BaseException)exception).Message);
        }

        public override void OnTokenError(Exception exception)
        {
        }
        public override void OnTokenError(Exception exception, Bundle bundle)
        {
            IHMSTokenEvent hmsTokenEvent = HMSInstanceId.Instance;
            hmsTokenEvent.HMSOnTokenError(((BaseException)exception).ErrorCode, ((BaseException)exception).Message,bundle);
        }

        public override void OnDeletedMessages()
        {
        }

    }

}