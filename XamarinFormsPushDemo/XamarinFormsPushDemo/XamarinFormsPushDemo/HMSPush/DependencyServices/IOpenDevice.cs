using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsPushDemo.HMSPush
{
    public interface IOpenDevice
    {
        Task<string> GetOdidAsync();
    }
}
