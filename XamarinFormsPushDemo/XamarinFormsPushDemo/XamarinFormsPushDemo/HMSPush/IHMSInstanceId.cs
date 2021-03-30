using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsPushDemo.HMSPush
{
    public interface IHMSInstanceId
    {
        event EventHandler<string> OnNewToken;
        event EventHandler<Exception> OnTokenError;
        void Initialize();
        void GetToken();
        Task<string> GetAAIDAsync();
        void DeleteAAID();
        void DeleteToken();
        long CreationTime { get; }
        string Id { get; }
    }
}
