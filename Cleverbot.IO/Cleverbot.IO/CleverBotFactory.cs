using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Cleverbot
{
    public static class CleverBotFactory
    {
        public static CleverBot Create(String User, String Key, String Nick = "") {
            using (var client = new HttpClient()) {

                var values = new Dictionary<string, string>
                {
                    { "user", User },
                    { "key", Key }
                };

                if (Nick.Length > 0)
                    values.Add("nick", Nick);

                var content = new FormUrlEncodedContent(values);

                var response = client.PostAsync("https://cleverbot.io/1.0/create", content).Result;

                var data = response.Content.ReadAsStringAsync().Result;

                CleverBotPostResult result = JsonConvert.DeserializeObject<CleverBotPostResult>(data);

                if (result.Status == "success") {
                    //Console.WriteLine("Successfully created cleverbot instance.");
                    return new CleverBot(result, User, Key);
                }
                else {
                    //Console.WriteLine("Failed to create cleverbot instance check [User & Key] status " + result.Status);
                    return null;
                }
            }
        }
    }
}
