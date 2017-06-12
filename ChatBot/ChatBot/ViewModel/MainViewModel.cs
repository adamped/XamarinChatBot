using ChatBot.Framework;
using ChatBot.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatBot.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private MainModel _model = new MainModel();

        public MainViewModel()
        {

            Messages = new ObservableCollection<Message>();
            Messages.Add(new Message() { MessageType = MessageType.Sent, Text = "Hi", DateTime = DateTime.Now.AddSeconds(-15) });
            Messages.Add(new Message() { MessageType = MessageType.Received, Text = "You sent Hi which was 2 characters", DateTime = DateTime.Now.AddSeconds(-14) });
            Messages.Add(new Message() { MessageType = MessageType.Sent, Text = "Hi Again", DateTime = DateTime.Now.AddSeconds(-5) });
            Messages.Add(new Message() { MessageType = MessageType.Received, Text = "You sent Hi Again which was 8 characters", DateTime = DateTime.Now.AddSeconds(-5) });
        }

        public ObservableCollection<Message> Messages { get; set; }

        private string _text = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public async Task StartConversation()
        {
            await _model.EnsureConversationEstablished();
        }

        public Command SendCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Messages.Add(new Message()
                    {
                        DateTime = DateTime.Now,
                        Text = Text,
                        MessageType = MessageType.Sent
                    });

                    var receivedMessage = await _model.SendMessage(Text);

                    Messages.Add(receivedMessage);

                    Text = string.Empty;
                });
            }
        }
    }
}
