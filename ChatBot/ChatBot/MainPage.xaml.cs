using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ChatBot.ViewModel;

namespace ChatBot
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _model = new MainViewModel();
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = _model;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _model.StartConversation();
        }

    }
}
