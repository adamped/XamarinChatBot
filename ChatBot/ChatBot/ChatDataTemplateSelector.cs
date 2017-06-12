using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ChatBot.Framework;

namespace ChatBot
{
    public class ChatDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ServerTemplate { get; set; }

        public DataTemplate ClientTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var model = item as Message;

            switch (model.MessageType)
            {
                case MessageType.Sent:
                    return ClientTemplate;
                case MessageType.Received:
                default:
                    return ServerTemplate;
            }
        }
    }
}
