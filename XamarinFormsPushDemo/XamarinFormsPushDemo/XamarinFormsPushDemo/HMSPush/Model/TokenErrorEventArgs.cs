using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsPushDemo.HMSPush.Model
{
    public class TokenErrorEventArgs : EventArgs
    {
        public Exception Exception { get; set; }
    }
}
