using Android.OS;
using Huawei.Hms.Push;

namespace XamarinHmsPushDemo.HMSPush
{
    public interface IHMSPushEvent
    {
        /// <summary>
        ///  Called when a new token is received.
        /// </summary>
        /// <param name="token"></param>
        void HMSOnNewToken(string token, Bundle bundle);
        /// <summary>
        /// Receives data messages pushed by the app server.
        /// </summary>
        /// <param name="message"></param>
        void HMSOnMessageReceived(RemoteMessage message);
        /// <summary>
        /// Called after an uplink message is successfully sent.
        /// </summary>
        /// <param name="msgId"></param>
        void HMSOnMessageSent(string msgId);
        /// <summary>
        /// Called after an uplink message fails to be sent.
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="errorInfo"></param>
        void HMSOnSendError(string msgId, int errorCode ,string errorMessage);

        /// <summary>
        /// Sends the response from the app server to the app after an uplink message reaches the app server if the receipt is enabled.
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        void HMSOnMessageDelivered(string msgId, int errorCode, string errorMessage);
        /// <summary>
        /// Called when a token fails to be applied for.
        /// </summary>
        /// <param name="exp"></param>
        void HMSOnTokenError(int errorCode, string errorMessage, Bundle bundle);
    }
}