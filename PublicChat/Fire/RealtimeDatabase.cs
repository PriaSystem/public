using System;
using System.Threading.Tasks;
using PublicChat.Entity;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PublicChat.Fire
{
    public class RealtimeDatabase
    {
        IRealtimeDatabase DB;

        public string UID { get { return DB.InstanceId; } }

        public RealtimeDatabase()
        {
            DB = DependencyService.Get<IRealtimeDatabase>();
        }

        public async Task<T> Get<T>(string key)
        {
            string json = await DB.Get(key);

            if (String.IsNullOrEmpty(json))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<bool> CreateUser(User user)
        {
            return await DB.Set($"/user/{user.Uid}", user);
        }

        public async Task<User> GetUser(string uid)
        {
            return await Get<User>($"/user/{uid}");
        }

        public async Task<bool> SendMessage(Message message)
        {
            return await DB.Add($"/messages/", message);
        }

        public void SubscribeToNewMessages(Action<Message> callback)
        {
            DB.Subscribe("/messages", (json) =>
            {
                callback?.Invoke(JsonConvert.DeserializeObject<Message>(json));
            });
        }
    }
}
