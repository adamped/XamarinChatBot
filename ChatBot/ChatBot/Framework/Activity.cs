using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Framework
{
    public class ActivityTypes
    {
        public const string Message = "message";
        public const string ConversationUpdate = "conversationUpdate";
        public const string Ping = "ping";
    }


    public class Activity
    {        
        public string Text { get; set; }
        public string Type { get; set; }
        public string ChannelId { get; set; }
        public string Id { get; set; }

        public List<Member> MembersAdded { get; set; }

        public string Timestamp { get; set; }
        public string LocalTimestamp { get; set; }
        public Member Recipient { get; set; }

        public Conversation Conversation { get; set; }

        public Member From { get; set; }

        public string ServiceUrl { get; set; }
    }
}
