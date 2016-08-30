using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Cleverbot
{
    public class CleverBot
    {
        public CleverBotPostResult CleverBotStatus { get; protected set; }
        public string User { get; protected set; }
        public string Key { get; protected set; }

        public CleverBot(CleverBotPostResult Status, string user, string key) {
            CleverBotStatus = Status;
            User = user;
            Key = key;
        }

        public CleverBotResponse Ask(string Question) {
            using (var client = new HttpClient()) {
                var values = new Dictionary<string, string>
                {
                    { "user", User },
                    { "key", Key },
                    { "nick", CleverBotStatus.Nick},
                    { "text", Question }
                };


                var content = new FormUrlEncodedContent(values);

                var response = client.PostAsync("https://cleverbot.io/1.0/ask", content).Result;

                var data = response.Content.ReadAsStringAsync().Result;
                JavaScriptSerializer jss = new JavaScriptSerializer();
                return jss.Deserialize<CleverBotResponse>(data);
            }
        }
    }
}
