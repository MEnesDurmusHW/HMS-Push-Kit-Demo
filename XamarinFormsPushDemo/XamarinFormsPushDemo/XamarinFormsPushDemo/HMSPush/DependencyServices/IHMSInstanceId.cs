using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsPushDemo.HMSPush.Model;

namespace XamarinFormsPushDemo.HMSPush
{
    public interface IHMSInstanceId
    {
        event OnNewTokenHandler OnNewToken;
        event OnTokenErrorHandler OnTokenError;
        void Initialize();
        void GetToken();
        Task<string> GetAAIDAsync();
        void DeleteAAID();
        void DeleteToken();
        long GetCreationTime();
        string GetId();
    }
}
