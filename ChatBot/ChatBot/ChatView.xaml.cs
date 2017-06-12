using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatBot
{
    public partial class ChatView : ListView
    {
        public ChatView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty MessagesProperty = BindableProperty.Create(
                nameof(Messages),
                typeof(string),
                typeof(Label),
                string.Empty);

        private string _messages;
        public string Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged();
            }
        }
    }
}