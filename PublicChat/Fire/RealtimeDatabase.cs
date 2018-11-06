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
            return false; //todo
        }

        public async Task<User> GetUser(string uid)
        {
            return null; //todo
        }

        public async Task<bool> SendMessage(Message message)
        {
            return false; //todo
        }

        public void SubscribeToNewMessages(Action<Message> callback)
        {
            //todo
        }
    }
}
