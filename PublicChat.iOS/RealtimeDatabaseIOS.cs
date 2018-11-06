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
            string id = Database.DefaultInstance.GetReferenceFromPath(key).GetChildByAutoId().Key;

            if (!key.EndsWith("/", StringComparison.Ordinal))
            {
                key += "/";
            }

            return await Set(key + id, value);
        }

        public async Task<string> Get(string key)
        {
            TaskCompletionSource<string> task = new TaskCompletionSource<string>();

            Database.DefaultInstance.GetReferenceFromPath(key)
                    .ObserveSingleEvent(DataEventType.Value, (snapshot) =>
                    {
                        string value = snapshot.GetValue().ToString();

                        task.SetResult(value);
                    });

            return await task.Task;

        }

        public async Task<bool> Set(string key, object value)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();

            Database.DefaultInstance.GetReferenceFromPath(key)
                    .SetValue(ToDictionary(value), (error, reference) =>
                    {
                        task.SetResult(error == null);
                    });

            return await task.Task;
        }

        public void Subscribe(string key, Action<string> callback)
        {
            Database.DefaultInstance.GetReferenceFromPath(key)
                    .ObserveEvent(DataEventType.ChildAdded, (DataSnapshot snapshot) =>
                    {
                        callback.Invoke(ConvertSnapshot(snapshot));
                    });
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
