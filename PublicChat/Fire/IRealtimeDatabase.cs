using System;
using System.Threading.Tasks;

namespace PublicChat.Fire
{
    public interface IRealtimeDatabase
    {
        string InstanceId { get; }

        Task<bool> Set(string key, object value);

        Task<bool> Add(string key, object value);

        Task<string> Get(string key);

        void Subscribe(string key, Action<string> callback);
    }
}
