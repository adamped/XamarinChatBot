using ChatBot.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Model
{
    public class MainModel
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task EnsureConversationEstablished()
        {
            var activity = new Activity()
            {
                Type = ActivityTypes.ConversationUpdate,
                MembersAdded = new List<Member>() { new Member() { Id = "781ajk076fln20n86", Name = "Bot" } },
                Id = Guid.NewGuid().ToString(),
                ChannelId = "EmulatorTestChannelId",
                Timestamp = DateTime.UtcNow.ToString("o"),
                LocalTimestamp = DateTime.Now.ToString("o"),
                Recipient = new Member() { Id = "781ajk076fln20n86", Name = "Bot" },
                Conversation = new Conversation() { Id = "3kcmig40nn8hiiad3" },
                From = new Member() { Id = "default-user", Name = "User" },
                ServiceUrl = "https://localhost:44338"
            };

            var request = new HttpRequest()
            {
                // This is referencing a local instance
                // You would use directline, if using the Azure Bot Service
                Url = "https://localhost:44338/api/messages",
                Data = JsonConvert.SerializeObject(activity)
            };

            var response = await _httpClient.Post(request);



            activity = new Activity()
            {
                Type = ActivityTypes.ConversationUpdate,
                MembersAdded = new List<Member>() { new Member() { Id = "default-user", Name = "User" } },
                Id = Guid.NewGuid().ToString(),
                ChannelId = "EmulatorTestChannelId",
                Timestamp = DateTime.UtcNow.ToString("o"),
                LocalTimestamp = DateTime.Now.ToString("o"),
                Recipient = new Member() { Id = "781ajk076fln20n86", Name = "Bot" },
                Conversation = new Conversation() { Id = "3kcmig40nn8hiiad3" },
                From = new Member() { Id = "default-user", Name = "User" },
                ServiceUrl = "https://localhost:44338"
            };

            request = new HttpRequest()
            {
                // This is referencing a local instance
                // You would use directline, if using the Azure Bot Service
                Url = "https://localhost:44338/api/messages",
                Data = JsonConvert.SerializeObject(activity)
            };

            response = await _httpClient.Post(request);
        }

        public async Task Ping()
        {
            var activity = new Activity()
            {
                Type = ActivityTypes.Ping,
                ChannelId = "EmulatorTestChannelId",
                Id = Guid.NewGuid().ToString()
            };

            var data = JsonConvert.SerializeObject(activity);

            var response = await _httpClient.Post(new HttpRequest()
            {
                // This is referencing a local instance
                // You would use directline, if using the Azure Bot Service
                Url = "https://localhost:44338/api/messages",
                Data = data
            });
        }

        public async Task<Message> SendMessage(string message)
        {
            var activity = new Activity()
            {
                Text = message,
                Type = ActivityTypes.Message,
                ChannelId = "EmulatorTestChannelId",
                Id = Guid.NewGuid().ToString(),
                Recipient = new Member() { Id = "781ajk076fln20n86", Name = "Bot" },
                From = new Member() { Id = "default-user", Name = "User" },
                Timestamp = DateTime.UtcNow.ToString("o"),
                LocalTimestamp = DateTime.Now.ToString("o"),
                Conversation = new Conversation() { Id = "3kcmig40nn8hiiad3" },
                ServiceUrl = "https://localhost:44338"
            };

            var data = JsonConvert.SerializeObject(activity);

            var response = await _httpClient.Post(new HttpRequest()
            {
                // This is referencing a local instance
                // You would use directline, if using the Azure Bot Service
                Url = "https://localhost:44338/api/messages",
                Data = data
            });

			var text = string.Empty;

			if (!string.IsNullOrEmpty(response?.Data))
			{
				var activityResponse = JsonConvert.DeserializeObject<Activity>(response.Data);

				text = activityResponse.Text;
			}

            return new Message()
            {
                MessageType = MessageType.Received,
                Text = text,
                DateTime = DateTime.Now
            };


        }

    }
}
