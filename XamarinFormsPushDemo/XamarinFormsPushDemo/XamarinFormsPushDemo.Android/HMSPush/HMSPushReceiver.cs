/*
       Copyright 2020-2021. Huawei Technologies Co., Ltd. All rights reserved.

       Licensed under the Apache License, Version 2.0 (the "License");
       you may not use this file except in compliance with the License.
       You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

       Unless required by applicable law or agreed to in writing, software
       distributed under the License is distributed on an "AS IS" BASIS,
       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
       See the License for the specific language governing permissions and
       limitations under the License.
*/

using Android.Content;
using Android.OS;
using Huawei.Hms.Push;
using System;
using XamarinFormsPushDemo.Droid.HMSPush;

namespace XamarinHmsPushDemo.HMSPush
{
    [BroadcastReceiver(Enabled = true, Label = "Push Message Service Receiver")]
    public class HMSPushReceiver : BroadcastReceiver
    {
        public const string Method = "method";
        public const string Message = "message";
        public const string MsgId = "msgId";
        public const string Exception = "exception";
        public const string ErrorCode = "errorCode";
        public const string ErrorMessage = "errorMessage";
        public const string Token = "token";
        public const string Bundle = "bundle";
        public override void OnReceive(Context context, Intent intent)
        {
            //if (intent.Action != "PushReceiver") return;

            Bundle bundle = intent.Extras;

            IHMSPushEvent hmsPushEvent = HMSInstanceId.Instance;

            if (bundle.ContainsKey(Method))
            {
                string method = intent.Extras.GetString(Method);
                if (method == ((Action<string, Bundle>)hmsPushEvent.HMSOnNewToken).Method.Name)
                {
                    hmsPushEvent.HMSOnNewToken(bundle.GetString(Token), bundle.GetBundle(Bundle));
                }
                else if (method == ((Action<RemoteMessage>)hmsPushEvent.HMSOnMessageReceived).Method.Name)
                {
                    hmsPushEvent.HMSOnMessageReceived(bundle.Get(Message) as RemoteMessage);
                }
                else if (method == ((Action<string>)hmsPushEvent.HMSOnMessageSent).Method.Name)
                {
                    hmsPushEvent.HMSOnMessageSent(bundle.GetString(MsgId));
                }
                else if (method == ((Action<string, int, string>)hmsPushEvent.HMSOnSendError).Method.Name)
                {
                    hmsPushEvent.HMSOnSendError(
                        bundle.GetString(MsgId),
                        bundle.GetBundle(Exception).GetInt(ErrorCode),
                        bundle.GetBundle(Exception).GetString(ErrorMessage));
                }
                else if (method == ((Action<string, int, string>)hmsPushEvent.HMSOnMessageDelivered).Method.Name)
                {
                    hmsPushEvent.HMSOnMessageDelivered(
                        bundle.GetString(MsgId),
                        bundle.GetBundle(Exception).GetInt(ErrorCode),
                        bundle.GetBundle(Exception).GetString(ErrorMessage));
                }
                else if (method == ((Action<int, string, Bundle>)hmsPushEvent.HMSOnTokenError).Method.Name)
                {
                    hmsPushEvent.HMSOnTokenError(
                        bundle.GetBundle(Exception).GetInt(ErrorCode),
                        bundle.GetBundle(Exception).GetString(ErrorMessage),
                        bundle.GetBundle(Bundle));
                }
            }
        }

    }
}
