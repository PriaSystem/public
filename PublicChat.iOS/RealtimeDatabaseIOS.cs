using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Firebase.Database;
using Foundation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PublicChat.Fire;
using PublicChat.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(RealtimeDatabaseIOS))]
namespace PublicChat.iOS
{
    public class RealtimeDatabaseIOS : IRealtimeDatabase
    {
        public string InstanceId => UIDevice.CurrentDevice.IdentifierForVendor.ToString();

        public RealtimeDatabaseIOS()
        {

        }

        public async Task<bool> Add(string key, object value)
        {
            string id = "uid"; //todo

            if (!key.EndsWith("/", StringComparison.Ordinal))
            {
                key += "/";
            }

            return await Set(key + id, value);
        }

        public async Task<string> Get(string key)
        {
            //todo

            return null;
        }

        public async Task<bool> Set(string key, object value)
        {
            //todo

            return false;
        }

        public void Subscribe(string key, Action<string> callback)
        {
            //todo
        }

        public NSDictionary<NSString, NSString> ToDictionary(object data)
        {
            Type type = data.GetType();

            var properties = type.GetRuntimeProperties().Where(x => x.GetCustomAttribute<JsonPropertyAttribute>() != null);

            int count = properties.Count();

            NSString[] keys = new NSString[count];
            NSString[] values = new NSString[count];

            int i = 0;
            foreach (var property in properties)
            {
                string key = property.GetCustomAttribute<JsonPropertyAttribute>().PropertyName;
                string value = property.GetValue(data).ToString();

                keys[i] = new NSString(key);
                values[i] = new NSString(value);

                i++;
            }

            return new NSDictionary<NSString, NSString>(keys, values);
        }

        public string ConvertSnapshot(DataSnapshot snapshot)
        {
            var data = snapshot.GetValue();
            Dictionary<string, string> output = new Dictionary<string, string>();
            if (data is NSDictionary values)
            {
                foreach (var value in values)
                {
                    output.Add(value.Key.ToString(), value.Value.ToString());
                }

                return JsonConvert.SerializeObject(output);
            }
            else
            {
                return snapshot.GetValue().ToString();
            }
        }
    }
}
